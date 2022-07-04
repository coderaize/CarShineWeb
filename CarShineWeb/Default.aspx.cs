using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShineWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void homeSubmitBtn_Click(object sender, EventArgs e)
        {
            Session["Booking-Date"] = dateTxt.Value;//).ToShortDateString();
            Session["Booking-TimeSlot"] = timeSlotDrp.SelectedItem;
            Response.Redirect("Booking.aspx");
        }
    }
}