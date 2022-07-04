using CarShineServices.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CarShineServices.ServiceControllers
{
    public class EmailService
    {
        public EmailSettings EmailSettings { get; set; }
        const string EmailSettingsConfigFile = "EmailConfig.xml";
        Form Invoker { get; set; }
        public int rotatedTimes = 0;
        public int LastFetchCount = 0;
        public List<int> LastFetchID { get; set; }

        private MailAddress FromAddress { get; set; }
        public event EventHandler RotationFetched;

        public EmailService(Form form)
        {
            EmailSettings = GetSetConfigFile();
            Invoker = form;
            //////////
            FromAddress = new MailAddress(EmailSettings.Email, EmailSettings.Name);
        }

        System.Timers.Timer T;
        public void StartService()
        {
            Rotation();
            T = new System.Timers.Timer();
            T.Interval = EmailSettings.TimeInterval;
            T.Elapsed += (x, y) =>
            {
                Rotation();
                Invoker.Invoke(new Action(delegate
                {
                    rotatedTimes++;
                    RotationFetched?.Invoke(null, new EventArgs());
                    if (rotatedTimes == int.MaxValue)
                        rotatedTimes = 0;
                }));

            };
            T.Start();
        }

        public void StopService()
        {
            T.Stop();
            T.Dispose();
            GC.Collect();
        }

        void Rotation()
        {

            // Get List //
            string getQuery = "select ID,NotifTo,NotifCC,NotifSubject,NotifBody " +
                "FROM [dBCarShine].[dbo].[cs_exNotificationStore]" +
                " WHERE InsertTime > DATEADD(Hour,-6,GETDATE()) " +
                "and isSent = 0 and NotifType = 'EMAIL'";
            InfoDataBase.DataSetAsync(getQuery, new List<Pair>(), (dS) =>
            {
                LastFetchID = new List<int>();
                foreach (DataRow getDR in dS.Tables[0].Rows)
                {
                    var ID = getDR["ID"]?.ToString();
                    LastFetchID.Add(int.Parse(ID));

                    SendMail(getDR["NotifTo"]?.ToString(),
                        getDR["NotifCC"]?.ToString(), getDR["NotifSubject"]?.ToString(),
                        getDR["NotifBody"]?.ToString(),
                        (sentStatus, errorException) =>
                        {
                            string SentQuery = "UPDATE [dBCarShine].[dbo].[cs_exNotificationStore] " +
                            "SET isSent = 1, SentTime = GETDATE() " +
                            " where ID = @ID ";
                            //
                            string failedQuery = "UPDATE [dBCarShine].[dbo].[cs_exNotificationStore] " +
                            "SET isSent = 0, Exception = @Exception " +
                            " where ID = @ID ";
                            //
                            if (sentStatus)
                            {
                                Logger.WriteLogs(ID + "{sent}");
                                InfoDataBase.DataSetAsync(SentQuery, new List<Pair> { new Pair("ID", ID) },
                                (dSSent) =>
                                {

                                });
                            }
                            else
                            {
                                Logger.WriteLogs(ID + "{failed}");
                                Logger.WriteException(errorException);
                                InfoDataBase.DataSetAsync(failedQuery, new List<Pair> {
                                    new Pair("ID", ID),
                                    new Pair("Exception", errorException.Message+"\r\n\r\n\r\n"+errorException.StackTrace)
                                },
                                (dSSent) => { });
                            }

                        });

                }
                LastFetchCount = int.Parse(dS.Tables[0].Rows.Count.ToString());
                Invoker.Invoke(new Action(delegate
                {

                    RotationFetched?.Invoke(null, new EventArgs());
                }));
                Logger.WriteLogs("Fetched: " + dS.Tables[0].Rows.Count.ToString());
            });

        }


        void SendMail(string To, string CC, string Subject, string Body, Action<bool, SmtpException> AfterAction)
        {
            new Thread(new ThreadStart(delegate
            {
                var message = new MailMessage()
                {
                    From = new MailAddress(EmailSettings.Email, EmailSettings.Name),
                    Subject = Subject,
                    Body = Body,
                    IsBodyHtml = true
                };
                To += ",";
                foreach (string m in To.Split(','))
                {
                    if (!string.IsNullOrEmpty(m))
                        message.To.Add(m);
                }
                CC += ",";
                foreach (string C in CC.Split(','))
                {
                    if (!string.IsNullOrEmpty(C))
                        message.CC.Add(C);
                }
                var password = EmailSettings.Password.isDecypted == true ? EmailSettings.Password.Password : Crypto.DecryptURLAES(EmailSettings.Password.Password);
                var SmtpClient = new SmtpClient
                {
                    Host = EmailSettings.Server.Server,
                    //Port = 587,
                    Port = EmailSettings.Server.Port,
                    EnableSsl = EmailSettings.Server.isSSL,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(FromAddress.Address, password)
                };
                try
                {
                    SmtpClient.Send(message);
                    message.Dispose();
                    Invoker.Invoke(new Action(delegate
                    {
                        AfterAction(true, null);
                    }));
                }
                catch (SmtpException t)
                {
                    Invoker.Invoke(new Action(delegate
                    {
                        AfterAction(false, t);
                    }));
                }
                GC.Collect();
            })).Start();
        }


        EmailSettings GetSetConfigFile()
        {
            // bulk check
            if (!File.Exists(EmailSettingsConfigFile))
            {
                EmailSettings emailSettings = new EmailSettings();
                emailSettings.Server = new EmailServer
                {
                    Server = "webmail.carshines.com",
                    isSSL = true,
                    Port = 25
                };
                emailSettings.UserName = "info@carshines.com";
                emailSettings.Email = "info@carshines.com";
                emailSettings.Password = new EmailPassword
                {
                    isDecypted = false,
                    Password = Crypto.EncryptURLAES("Janan#124")
                };
                File.WriteAllText(EmailSettingsConfigFile, XML.SerializeObject(emailSettings));
            }
            ///// pass check and retieve
            if (File.Exists(EmailSettingsConfigFile))
            {
                var eSettings = XML.DeserializeObject<EmailSettings>(File.ReadAllText(EmailSettingsConfigFile));
                if (eSettings.Password.isDecypted == true)
                {
                    eSettings.Password.Password = Crypto.EncryptURLAES(eSettings.Password.Password);
                    eSettings.Password.isDecypted = false;
                    File.WriteAllText(EmailSettingsConfigFile, XML.SerializeObject(eSettings));
                }
                return eSettings;
            }
            return null;
        }



    }

    [Serializable]
    public class EmailSettings
    {

        public EmailServer Server { get; set; }
        [XmlAttribute]
        public string Email { get; set; }
        [XmlAttribute]
        public string UserName { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public int TimeInterval { get; set; } = 2000;
        public EmailPassword Password { get; set; }
    }
    [Serializable]
    public class EmailPassword
    {
        [XmlAttribute]
        public string Password { get; set; }
        [XmlAttribute]
        public bool isDecypted { get; set; }
    }

    [Serializable]
    public class EmailServer
    {
        [XmlAttribute]
        public string Server { get; set; } = "";
        [XmlAttribute]
        public int Port { get; set; } = 25;
        [XmlAttribute]
        public bool isSSL { get; set; } = true;
    }


}
