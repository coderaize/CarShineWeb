using CarShineServices.ServiceControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarShineServices
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            this.FormClosed += (x, y) => { Application.Exit(); };
            if (Properties.Settings.Default.StartEmailOnLoad)
            {
                StartMailService();
            }
            ServicePointManager.ServerCertificateValidationCallback +=
              (s, certificate, chain, sslPolicyErrors)
              => true;
            Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StartMailService();
        }
        EmailService emailService;
        void StartMailService()
        {
            emailService = new EmailService(this);
            emailService.StartService();
            btnEmailService.BackColor = Color.Green;
            emailService.RotationFetched += (x, y) =>
            {
                mailStatusBox.Text = "\r\nRotation #:" + emailService.rotatedTimes.ToString()
                + "\r\n"
                + "Found Counts: " + emailService.LastFetchCount
                + "\r\n Found ID's :" + string.Join(" , ", emailService.LastFetchID.ToArray());
                Logger.WriteLogs(mailStatusBox.Text);
            };
        }

        // bulkie
        private void button2_Click(object sender, EventArgs e)
        {
            EmailService emailService = new EmailService(this);
        }

        private void btnEmailServiceStop_Click(object sender, EventArgs e)
        {
            emailService.StopService();
            emailService = null;
            btnEmailService.BackColor = Color.White;
            emailService = new EmailService(this);
            emailService.StartService();
            btnEmailService.BackColor = Color.Green;
            emailService.RotationFetched += (x, y) =>
            {
                mailStatusBox.Text = "Rotated For:" + emailService.rotatedTimes.ToString();
            };
        }
    }
}
