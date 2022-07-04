<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarShineWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="Body" runat="server">


    <div class="site-blocks-cover overlay" style="background-image: url(new-images/bg-img.jpg);" data-aos="fade" data-stellar-background-ratio="0.5">
        <div class="container">
            <div class="row align-items-center justify-content-center text-center">

                <div class="col-md-12">


                    <div class="row justify-content-center mb-4">
                        <div class="col-md-8 text-center">
                            <h1 class="marquee-visibility-effect" data-aos="fade-up">It’s time to <span class=" text-primary text-uppercase">Shine</span></h1>
                            <p data-aos="fade-up" data-aos-delay="100">The car wash for busy people.</p>
                        </div>
                    </div>

                    <div class="form-search-wrap" data-aos="fade-up" data-aos-delay="200">
                        <form runat="server" id="form11">
                            <div class="row align-items-center">

                                <div class="col-sm-1">
                                    <label class="text-white">Date</label>
                                </div>
                                <div class="col-lg-12 mb-4 mb-xl-0 col-xl-3">
                                    <div class="select-wrap">
                                        <%--<span class="icon"><span class="icon-keyboard_arrow_down"></span></span>--%>
                                        <input type="date" runat="server" id="dateTxt" class="form-control rounded" />
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                    <label class="text-white">Time Slot</label>
                                </div>
                                <div class="col-lg-12 mb-4 mb-xl-0 col-xl-3">
                                    <div class="select-wrap">
                                        <span class="icon"><span class="icon-keyboard_arrow_down"></span></span>
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
                                <div class="col-lg-12 col-xl-2 ml-auto text-right">
                                    <asp:Button runat="server" ID="homeSubmitBtn" CssClass="btn btn-primary btn-block rounded" Text="Submit" OnClick="homeSubmitBtn_Click" />
                                </div>
                            </div>
                        </form>
                    </div>

                </div>
            </div>
        </div>
    </div>



    <div class="site-section bg-light">
        <div class="container">
            <div class="overlap-category mb-5">
                <div class="row align-items-stretch no-gutters">
                    <div class="col-sm-6 col-md-4 mb-4 mb-lg-0 col-lg-4">
                        <a href="#" class="popular-category h-100">
                            <span class="icon">
                                <img width="80" src="images/icons/mini-van.png" />
                            </span>
                            <span class="caption mb-2 d-block">Mini</span>
                            <span class="number">Wash: 300/- </span>
                            <br />
                            <span class="number">With Polish:500/- </span>
                        </a>
                    </div>
                    <div class="col-sm-6 col-md-4 mb-4 mb-lg-0 col-lg-4">
                        <a href="#" class="popular-category h-100">
                            <span class="icon">

                                <img width="80" src="images/icons/sedan.png" />
                            </span>
                            <span class="caption mb-2 d-block">Sedan</span>
                            <span class="number">Wash: 400/- </span>
                            <br />
                            <span class="number">With Polish:700/- </span>
                        </a>
                    </div>
                    <div class="col-sm-6 col-md-4 mb-4 mb-lg-0 col-lg-4">
                        <a href="#" class="popular-category h-100">
                            <span class="icon">
                                <img width="80" src="images/icons/automoblie.png" />
                            </span>
                            <span class="caption mb-2 d-block">SUV</span>
                            <span class="number">Wash: 700/- </span>
                            <br />
                            <span class="number">With Polish:1000/- </span>
                        </a>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <div class="site-section" data-aos="fade">
        <div class="container">
            <div class="row justify-content-center mb-5">
                <div class="col-md-7 text-center border-primary">
                    <h2 class="font-weight-light text-primary">Popular Products</h2>
                    <p class="color-black-opacity-5">Lorem Ipsum Dolor Sit Amet</p>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6 mb-4 mb-lg-4 col-lg-4">

                    <div class="listing-item">
                        <div class="listing-image">
                            <%--<img src="images/img_1.jpg" alt="Image" class="img-fluid">--%>
                            <img src="images/undraw/undraw_by_my_car_ttge.png" />
                        </div>
                        <%--<div class="listing-item-content">
                            <a href="#" class="bookmark" data-toggle="tooltip" data-placement="left" title="Bookmark"><span class="icon-heart"></span></a>
                            <a class="px-3 mb-3 category" href="#">Car &amp; Vehicles</a>
                            <h2 class="mb-1"><a href="#">Red Luxury Car</a></h2>
                            <span class="address">West Orange, New York</span>
                        </div>--%>
                    </div>

                </div>
                <style>
                    .listing-item img {
                        max-height: 250px !important;
                    }

                    .listing-item .img-h {
                        max-height: 350px !important;
                    }
                </style>
                <div class="col-md-6 mb-4 mb-lg-4 col-lg-4">

                    <div class="listing-item">
                        <div class="listing-image">
                            <%--<img src="images/img_2.jpg" alt="Image" class="img-fluid">--%>
                            <img src="images/undraw/undraw_clean_up_ucm0.png" />
                        </div>
                        <%--  <div class="listing-item-content">
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <a class="px-3 mb-3 category" href="#">Real Estate</a>
                            <h2 class="mb-1"><a href="#">House with Swimming Pool</a></h2>
                            <span class="address">West Orange, New York</span>
                        </div>--%>
                    </div>

                </div>
                <div class="col-md-6 mb-4 mb-lg-4 col-lg-4">

                    <div class="listing-item">
                        <div class="listing-image">
                            <%--<img src="images/img_3.jpg" alt="Image" class="img-fluid">--%>
                            <img src="images/undraw/undraw_off_road_9oae.png" />
                        </div>
                        <%--<div class="listing-item-content">
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <a class="px-3 mb-3 category" href="#">Furniture</a>
                            <h2 class="mb-1"><a href="#">Wooden Chair &amp; Table</a></h2>
                            <span class="address">West Orange, New York</span>
                        </div>--%>
                    </div>

                </div>

                <div class="col-md-6 mb-4 mb-lg-4 col-lg-6">

                    <div class="listing-item">
                        <div class="listing-image">
                            <img class="img-h" src="images/undraw/undraw_electric_car_b7hl.png" />
                        </div>
                        <%--  <div class="listing-item-content">
                            <a href="#" class="bookmark" data-toggle="tooltip" data-placement="left" title="Bookmark"><span class="icon-heart"></span></a>
                            <a class="px-3 mb-3 category" href="#">Electronics</a>
                            <h2 class="mb-1"><a href="#">iPhone X gray</a></h2>
                            <span class="address">West Orange, New York</span>
                        </div>--%>
                    </div>

                </div>
                <div class="col-md-6 mb-4 mb-lg-4 col-lg-6">

                    <div class="listing-item">
                        <div class="listing-image">
                            <img class="img-h" src="images/undraw/undraw_by_my_car_ttge.png" />
                        </div>
                        <%--  <div class="listing-item-content">
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <a class="px-3 mb-3 category" href="#">Real Estate</a>
                            <h2 class="mb-1"><a href="#">House with Swimming Pool</a></h2>
                            <span class="address">West Orange, New York</span>
                        </div>--%>
                    </div>

                </div>


            </div>
        </div>
    </div>


<%--    <div class="site-section bg-light">
        <div class="container">
            <div class="row mb-5">
                <div class="col-md-7 text-left border-primary">
                    <h2 class="font-weight-light text-primary">Trending Today</h2>
                </div>
            </div>
            <div class="row mt-5">
                <div class="col-lg-6">

                    <div class="d-block d-md-flex listing">
                        <a href="listings-single.html" class="img d-block" style="background-image: url('images/img_2.jpg')"></a>
                        <div class="lh-content">
                            <span class="category">Real Estate</span>
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <h3><a href="listings-single.html">House with Swimming Pool</a></h3>
                            <address>Don St, Brooklyn, New York</address>
                            <p class="mb-0">
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-secondary"></span>
                                <span class="review">(3 Reviews)</span>
                            </p>
                        </div>
                    </div>
                    <div class="d-block d-md-flex listing">
                        <a href="listings-single.html" class="img d-block" style="background-image: url('images/img_3.jpg')"></a>
                        <div class="lh-content">
                            <span class="category">Furniture</span>
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <h3><a href="listings-single.html">Wooden Chair &amp; Table</a></h3>
                            <address>Don St, Brooklyn, New York</address>
                            <p class="mb-0">
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-secondary"></span>
                                <span class="review">(3 Reviews)</span>
                            </p>
                        </div>
                    </div>

                    <div class="d-block d-md-flex listing">
                        <a href="listings-single.html" class="img d-block" style="background-image: url('images/img_4.jpg')"></a>
                        <div class="lh-content">
                            <span class="category">Electronics</span>
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <h3><a href="listings-single.html">iPhone X gray</a></h3>
                            <address>Don St, Brooklyn, New York</address>
                            <p class="mb-0">
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-secondary"></span>
                                <span class="review">(3 Reviews)</span>
                            </p>
                        </div>
                    </div>



                </div>
                <div class="col-lg-6">

                    <div class="d-block d-md-flex listing">
                        <a href="listings-single.html" class="img d-block" style="background-image: url('images/img_1.jpg')"></a>
                        <div class="lh-content">
                            <span class="category">Cars &amp; Vehicles</span>
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <h3><a href="listings-single.html">Red Luxury Car</a></h3>
                            <address>Don St, Brooklyn, New York</address>
                            <p class="mb-0">
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-secondary"></span>
                                <span class="review">(3 Reviews)</span>
                            </p>
                        </div>
                    </div>

                    <div class="d-block d-md-flex listing">
                        <a href="listings-single.html" class="img d-block" style="background-image: url('images/img_2.jpg')"></a>
                        <div class="lh-content">
                            <span class="category">Real Estate</span>
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <h3><a href="listings-single.html">House with Swimming Pool</a></h3>
                            <address>Don St, Brooklyn, New York</address>
                            <p class="mb-0">
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-secondary"></span>
                                <span class="review">(3 Reviews)</span>
                            </p>
                        </div>
                    </div>
                    <div class="d-block d-md-flex listing">
                        <a href="listings-single.html" class="img d-block" style="background-image: url('images/img_3.jpg')"></a>
                        <div class="lh-content">
                            <span class="category">Furniture</span>
                            <a href="#" class="bookmark"><span class="icon-heart"></span></a>
                            <h3><a href="listings-single.html">Wooden Chair &amp; Table</a></h3>
                            <address>Don St, Brooklyn, New York</address>
                            <p class="mb-0">
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-warning"></span>
                                <span class="icon-star text-secondary"></span>
                                <span class="review">(3 Reviews)</span>
                            </p>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>



    <div class="newsletter bg-primary py-5">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-md-6">
                    <h2>Newsletter</h2>
                    <p>Lorem ipsum dolor sit amet consectetur adipisicing elit.</p>
                </div>
                <div class="col-md-6">

                    <form class="d-flex">
                        <input type="text" class="form-control" placeholder="Email">
                        <input type="submit" value="Subscribe" class="btn btn-white">
                    </form>
                </div>
            </div>
        </div>
    </div>--%>





</asp:Content>
