<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="CarShineWeb.Booking" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Body" runat="server">

    <div class="site-blocks-cover inner-page-cover overlay aos-init aos-animate" style="height: 300px!important; min-height: 300px!important; background-image: url(&quot;images/hero_1.jpg&quot;); background-position: 50% 177px;" data-aos="fade" data-stellar-background-ratio="0.5">

        <div class="container">
            <div class="row align-items-center justify-content-center text-center" style="height: 350px !important; min-height: 350px !important;">

                <div class="col-md-10 aos-init aos-animate" data-aos="fade-up" data-aos-delay="400">

                    <div class="row justify-content-center mt-5">
                        <div class="col-md-8 text-center">
                            <h1>Book your Service Now!</h1>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>
    <style>
        .site-section label {
            font-weight: bolder;
        }
    </style>
    <div class="site-section bg-light" style="padding-top: 20px!important">
        <div class="container">
            <div class="row">
                <div class="col-md-12 mb-5" data-aos="fade">
                    <form runat="server">
                        <asp:Panel runat="server" ID="StatusPanel">
                            <div class="p-5 bg-white text-center">
                                <h4>Your Booking Request has been Generated with ID: <strong runat="server" id="bookingNumber"></strong></h4>
                                <a href="Booking.aspx" class="btn btn-primary">Make Another Request</a>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="InformationPanel">
                            <div class="p-5 bg-white">

                                <div class="row form-group" <%--style="border-bottom: 0.1px solid black"--%>>
                                    <div class="col-md-3 mb-3 mb-md-0">
                                        <label class="text-black">Date</label>
                                        <input type="date" runat="server" id="bookingDateTxt" class="form-control rounded" />
                                    </div>
                                    <div class="col-md-3 mb-3 mb-md-0">
                                        <label class="text-black">TimeSlot</label>
                                        <asp:DropDownList runat="server" ID="timeSlotDrp" CssClass="form-control rounded">
                                            <asp:ListItem>9 AM to 10 AM</asp:ListItem>
                                            <asp:ListItem>10 AM to 11 AM</asp:ListItem>
                                            <asp:ListItem>11 AM to 12 PM</asp:ListItem>
                                            <asp:ListItem>12 PM to 1 PM</asp:ListItem>
                                            <asp:ListItem>1 PM to 2 PM</asp:ListItem>
                                            <asp:ListItem>2 PM to 3 PM</asp:ListItem>
                                            <asp:ListItem>3 PM to 4 PM</asp:ListItem>
                                            <asp:ListItem>4 PM to 5 PM</asp:ListItem>
                                            <asp:ListItem>5 PM to 6 PM</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-md-3 mb-3 mb-md-0">
                                        <label class="text-black" for="drpIsWaterAvailable">Is Water Faicility Available?</label>
                                        <asp:DropDownList runat="server" CssClass="form-control rounded" ID="drpIsWaterAvailable">
                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-md-3 mb-3 mb-md-0">
                                        <label class="text-black" for="drpServiceTypes">Service Type</label>
                                        <asp:DropDownList runat="server" CssClass="form-control rounded" ID="drpServiceTypes">
                                            <asp:ListItem Value="Only Wash" Text="Only Wash"></asp:ListItem>
                                            <asp:ListItem Value="Wash & Polish" Text="Wash & Polish"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-md-3 mb-3 mb-md-0">
                                        <label class="text-black" for="fullNameTxt">Full Name</label>
                                        <input type="text" runat="server" id="fullNameTxt" class="form-control" required="required">
                                    </div>

                                    <div class="col-md-3">
                                        <label class="text-black" for="cellNumTxt">Cell #</label>
                                        <input type="text" runat="server" id="cellNumTxt" pattern="03\d{9}" title="Please Enter a valid Phone Number" class="form-control" placeholder="03001111111" required="required">
                                    </div>

                                </div>

                                <div class="row form-group">

                                    <div class="col-md-3 mb-3 mb-md-0">
                                        <label class="text-black" for="houseTxt">House #</label>
                                        <input type="text" runat="server" pattern="\d+" title="Please enter a valid House Number" id="houseTxt" class="form-control" required="required">
                                    </div>

                                    <div class="col-md-3 mb-3 mb-md-0">
                                        <label class="text-black" for="streetTxt">Street / Area</label>
                                        <input type="text" runat="server" id="streetTxt" class="form-control" required="required" />
                                    </div>

                                    <div class="col-md-3 mb-3 mb-md-0">
                                        <label class="text-black" for="drpSector">Sector</label>
                                        <asp:DropDownList runat="server" CssClass="form-control rounded" ID="drpSector">
                                            <asp:ListItem Value="Sector F8/1" Text="Sector F8/1"></asp:ListItem>
                                            <asp:ListItem Value="Sector F8/2" Text="Sector F8/2"></asp:ListItem>
                                            <asp:ListItem Value="Sector F8/3" Text="Sector F8/3"></asp:ListItem>
                                            <asp:ListItem Value="Sector F8/4" Text="Sector F8/4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-md-3 mb-3 mb-md-0">
                                        <label class="text-black" for="drpCity">City</label>
                                        <asp:DropDownList runat="server" CssClass="form-control rounded" ID="drpCity">
                                            <asp:ListItem Value="Islamabad" Text="Islamabad"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                </div>

                                <div class="row form-group">
                                    <div class="col-md-3 mb-3 mb-md-0">
                                        <label class="text-black" for="fname">Car Type</label>
                                        <asp:DropDownList runat="server" CssClass="form-control rounded" ID="drpCarType">
                                            <asp:ListItem Value="Mini">Mini</asp:ListItem>
                                            <asp:ListItem Value="Sedan">Sedan</asp:ListItem>
                                            <asp:ListItem Value="SUV">SUV</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3 mb-3 mb-md-0">
                                        <label class="text-black" for="fname">Company</label>
                                        <input type="text" runat="server" id="companyTxt" placeholder="Honda City, Corola XLI " class="form-control" required="required">
                                    </div>
                                    <div class="col-md-3 mb-3 mb-md-0">
                                        <label class="text-black" for="fname">Model Year</label>
                                        <input type="text" runat="server" pattern="\d{4}" title="Please Enter a valid model year" id="modelTxt" class="form-control" placeholder="2000 , 1995 " required="required">
                                    </div>
                                    <div class="col-md-3 mb-3 mb-md-0">
                                        <label class="text-black" for="payNow">Pay</label>

                                        <asp:DropDownList runat="server" CssClass="form-control rounded" ID="drpPayNow">
                                            <asp:ListItem Enabled="false" Value="Via Debit Card" Text="Via Debit Card"></asp:ListItem>
                                            <asp:ListItem Value="After Service" Text="After Service"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <!-- Submission Button -->
                                <div class="row form-group">
                                    <div class="col-md-12">
                                        <asp:Button runat="server" OnClick="BookingsubmitButton_Click" ID="BookingsubmitButton" CssClass="btn btn-primary btn-block mt-4 py-2 px-4 text-white" Text="Submit" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="PaymentPanel">
                        </asp:Panel>

                    </form>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
