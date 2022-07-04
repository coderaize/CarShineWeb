<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" MasterPageFile="~/MasterPage.Master" Inherits="CarShineWeb.Gallery" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/fotorama/4.6.4/fotorama.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="Body" runat="server">

    <div class="site-blocks-cover inner-page-cover overlay aos-init aos-animate" style="height: 300px!important; min-height: 300px!important; background-image: url(&quot;images/hero_1.jpg&quot;); background-position: 50% 177px;" data-aos="fade" data-stellar-background-ratio="0.5">

        <div class="container">
            <div class="row align-items-center justify-content-center text-center" style="height: 350px !important; min-height: 350px !important;">

                <div class="col-md-10 aos-init aos-animate" data-aos="fade-up" data-aos-delay="400">

                    <div class="row justify-content-center mt-5">
                        <div class="col-md-8 text-center">
                            <h1>Gallery!</h1>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>

    <div class="site-section bg-light" style="padding-top: 20px!important">
        <div class="container">
            <div class="row">
                <div class="col-md-12 mb-5" data-aos="fade">
                    <div class="p-5 bg-white text-center">
                        <div class="fotorama"
                            data-nav="thumbs">
                            <% ImagesForGallery.ForEach(X => {  %>
                            <a href="new-images/gallery/<%= X %>">
                                <img src="new-images/gallery/<%= X %>" width="144" height="96">
                            </a>
                            <%}); %>
                        
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="ScriptContent" ContentPlaceHolderID="Scripts" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/fotorama/4.6.4/fotorama.js"></script>
</asp:Content>
