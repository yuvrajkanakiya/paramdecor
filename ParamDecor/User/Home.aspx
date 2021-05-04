<%@ Page Title="" Language="C#" MasterPageFile="~/Content/UserMasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="AdminPanel_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Start Slider area -->
    <div class="slider-area brown__nav slider--15 slide__activation slide__arrow01 owl-carousel owl-theme">
        <!-- Start Single Slide -->
        <div class="slide animation__style10 bg-image--5 fullscreen align__center--left">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="slider__content">
                            <div class="contentbox">
                                <h2>Buy <span>your </span></h2>
                                <h2>favourite <span>Calender </span></h2>
                                <h2>from <span>Here </span></h2>
                                <asp:hyperlink runat="server" id="hlCalander" navigateurl="~/User/Calendar.aspx" class="shopbtn">Shop Now</asp:hyperlink>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Single Slide -->
        <!-- Start Single Slide -->
        <div class="slide animation__style10 bg-image--8 fullscreen align__center--left">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="slider__content">
                            <div class="contentbox">
                                <h2>Buy <span>your </span></h2>
                                <h2>favourite <span>Canvas </span></h2>
                                <h2>from <span>Here </span></h2>
                                <asp:hyperlink runat="server" id="hlCanvas" navigateurl="~/User/Canvas.aspx" class="shopbtn">Shop Now</asp:hyperlink>
                                <%--<a class="shopbtn" href="banner.html">shop now</a>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Single Slide -->
    </div>
    <!-- End Slider area -->

    <section class="wn__bestseller__area bg--white pt--80  pb--30">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="section__title text-center">
                        <h2 class="title__be--2">All <span class="color--theme">Products</span></h2>
                        <p>You can count on Staples® Print & Marketing Services for all of your print jobs. Whether you choose our self-serve machines or get help from our experts, we’ve got you covered.</p>
                    </div>
                </div>
            </div>

            <div class="container">
                <div class="row">
                    <asp:repeater runat="server" id="rptProducts">
                        <ItemTemplate>
                    <div class="col-md-3 col-sm-6">
                        <div class="product-grid3">
                            <div class="product-image3">
                                <asp:hyperlink runat="server" id="hlProductPhoto" 
                                    NavigateUrl='<%# "~/User/ProductDetails.aspx?ProductID=" + Eval("ProductID").ToString() + "&CategoryName=" + Eval("CategoryName")  %>'>
                                    <asp:Image runat="server" ID="imgProductPhoto" ImageUrl='<%# Eval("ProductImage") %>' />
                                </asp:hyperlink>
                                <ul class="social">
                                    <li>
                                        <asp:hyperlink runat="server" id="hlWishlistIcon" 
                                            NavigateUrl='<%# "~/User/ProductDetails.aspx?ProductID=" + Eval("ProductID").ToString() + "&CategoryName=" + Eval("CategoryName") %>'>
                                            <i class="fa fa-shopping-bag"></i>
                                        </asp:hyperlink>

                                    </li>
                                    
                                    
                                </ul>
                                <span class="product-new-label">New</span>
                            </div>
                            <div class="product-content">
                                <h3 class="title"><a href="#"><%# Eval("ProductName") %></a></h3>
                                <div class="price">
                                    <span class="price">&#8377;<%# Eval("Price") %></span></div>                    
                                
                            </div>
                        </div>
                    </div>
                    </ItemTemplate>
                    </asp:repeater>
                </div>
            </div>

        </div>
    </section>

</asp:Content>

