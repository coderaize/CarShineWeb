using CarShineWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShineWeb
{
    public partial class Booking : System.Web.UI.Page
    {
        public string BookingID { get; set; } = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Booking-Date"] != null && Session["Booking-TimeSlot"] != null)
            {
                bookingDateTxt.Value = Session["Booking-Date"]?.ToString();
                foreach (ListItem li in timeSlotDrp.Items)
                {
                    if (li.Text == Session["Booking-TimeSlot"]?.ToString())
                        li.Selected = true;
                }
            }


            if (!IsPostBack || !IsCallback)
            {
                StatusPanel.Visible = false;
                PaymentPanel.Visible = false;
                InformationPanel.Visible = true;
            }
        }

        protected void BookingsubmitButton_Click(object sender, EventArgs e)
        {

            bool isWaterAvailable = drpIsWaterAvailable.SelectedValue.ToLower() == "yes";
            string serviceType = drpServiceTypes.SelectedValue;
            string fullName = fullNameTxt.Value;
            string cellNumber = cellNumTxt.Value;
            string houseNumber = houseTxt.Value;
            string streetNumber = streetTxt.Value;
            string sector = drpSector.SelectedValue;
            string city = drpCity.SelectedValue;
            string carType = drpCarType.SelectedValue;
            string company = companyTxt.Value;
            string modelYear = modelTxt.Value;
            string payType = drpPayNow.SelectedValue;
            string bookingDate = bookingDateTxt.Value;
            string timeSlot = timeSlotDrp.SelectedItem.Text;
            string bid = DataBaseOps.GetDsBySource("EXEC cs_CreateBookingRequest " +
                "@Name=@Name,@Phone=@Phone,@HouseNumber=@HouseNumber,@StreetNumber=@StreetNumber,@BookingDate=@BookingDate,@TimeSlot=@TimeSlot," +
                "@Society=@Society,@City=@City,@CarType=@CarType,@Company = @Company,@ModelYear=@ModelYear," +
                "@ServiceType=@ServiceType,@isWaterAvailable=@isWaterAvailable,@PaymentType=@PaymentType", new System.Collections.Hashtable {
                    {"Name",fullName },
                    {"Phone",cellNumber },
                    {"HouseNumber", houseNumber },
                    { "StreetNumber",streetNumber},
                    {"Society", sector },
                    {"City",city },
                    { "CarType",carType},
                    { "Company",company},
                    { "ModelYear",modelYear},
                    { "ServiceType",serviceType},
                    { "isWaterAvailable",isWaterAvailable==true?1:0},
                    { "PaymentType",payType},
                    { "BookingDate", bookingDate },
                    {"TimeSlot", timeSlot },

            }).Tables[0].Rows[0][0].ToString();
            bookingNumber.InnerHtml = bid;
            if (payType == "After Service")
            {
                PaymentPanel.Visible = false;
                InformationPanel.Visible = false;
                StatusPanel.Visible = true;
            }
            else if (payType == "Via Debit")
            {
                PaymentPanel.Visible = true;
                InformationPanel.Visible = false;
                StatusPanel.Visible = false;
            }
        }
    }
}