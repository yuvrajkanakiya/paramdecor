<%@ Page Title="" Language="C#" MasterPageFile="~/Content/UserMasterPage.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="User_ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Start Bradcaump area -->
    <div class="ht__bradcaump__area bg-image--4">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcaump__inner text-center">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End Bradcaump area -->
    <div class="row">
        <div class="col-sm-12">
            <div class="alert alert-success" id="divMessage" runat="server" visible="false">
                <asp:label id="lblMessage" runat="server" />
                <asp:hyperlink runat="server" ID="hlMessage" visible="false" class="alert-link"></asp:hyperlink>
            </div>
        </div>
    </div>

    <!-- Start main Content -->
    <div class="maincontent bg--white pt--80 pb--55">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-12">
                    <div class="wn__single__product">
                        <div class="row">
                            <div class="col-lg-6 col-12">
                                <div class="wn__fotorama__wrapper">
                                    <div class="fotorama wn__fotorama__action" data-nav="thumbs">

                                        <asp:image runat="server" id="imgProduct" imageurl='<%# Eval("ProductImage") %>'></asp:image>

                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6 col-12">
                                <div class="product-info">
                                    <h1>
                                        <asp:label runat="server" id="lblProductName"><%# Eval("ProductName") %></asp:label>
                                    </h1>
                                    <div class="price-box-3">
                                        <div class="s-price-box">
                                            <span class="new-price">&#8377;<asp:label runat="server" id="lblPrice"><%# Eval("Price") %></asp:label></span>
                                        </div>
                                    </div>
                                    <div class="quick-desc">
                                        <asp:label runat="server" id="lblDescription"><%# Eval("Description") %></asp:label>
                                    </div>
                                    <asp:requiredfieldvalidator runat="server" ID="rfvTshirtSize" errormessage="Select Size" ControlToValidate="rblTshirtSize" CssClass="text-danger" Display="Dynamic" ValidationGroup="Size"></asp:requiredfieldvalidator>
                                    <asp:requiredfieldvalidator runat="server" ID="rfvCalendarSize" errormessage="Select Size" ControlToValidate="rblCalendarSize" CssClass="text-danger" Display="Dynamic" ValidationGroup="Size"></asp:requiredfieldvalidator>
                                    <asp:requiredfieldvalidator runat="server" ID="rfvCanvasSize" errormessage="Select Size" ControlToValidate="rblCanvasSize" CssClass="text-danger" Display="Dynamic" ValidationGroup="Size"></asp:requiredfieldvalidator>
                                    <div class="select__size" runat="server" ID="divTshirt" visible="false">
                                        <h2>Select size</h2>
                                        <ul class="color__list">
                                            <asp:radiobuttonlist runat="server" id="rblTshirtSize" repeatdirection="Horizontal" cellpadding="3" cellspacing="10">
                                                <asp:ListItem>L</asp:ListItem>
                                                <asp:ListItem>M</asp:ListItem>
                                                <asp:ListItem>S</asp:ListItem>
                                                <asp:ListItem>XL</asp:ListItem>
                                                <asp:ListItem>XXL</asp:ListItem>
                                            </asp:radiobuttonlist>
                                        </ul>
                                    </div>
                                    <div class="select__size" runat="server" ID="divCalendar" visible="false">
                                        <h2>Select size</h2>
                                        <ul class="color__list">
                                            <asp:radiobuttonlist runat="server" id="rblCalendarSize" repeatdirection="Horizontal" cellpadding="3" cellspacing="10">
                                                <asp:ListItem>16×20"</asp:ListItem>
                                                <asp:ListItem>20x30"</asp:ListItem>
                                                <asp:ListItem>11x14"</asp:ListItem>
                                                <asp:ListItem>8X11"</asp:ListItem>
                                                <asp:ListItem>12X12"</asp:ListItem>
                                            </asp:radiobuttonlist>

                                        </ul>
                                    </div>
                                    <div class="select__size" runat="server" ID="divCanvas" visible="false">
                                        <h2>Select size</h2>
                                        <ul class="color__list">
                                            <asp:radiobuttonlist runat="server" id="rblCanvasSize" repeatdirection="Horizontal" cellpadding="3" cellspacing="10">
                                                <asp:ListItem>6x6"</asp:ListItem>
                                                <asp:ListItem>7x5"</asp:ListItem>
                                                <asp:ListItem>8x8"</asp:ListItem>
                                                <asp:ListItem>10x8"</asp:ListItem>
                                                <asp:ListItem>12x12"</asp:ListItem>
                                            </asp:radiobuttonlist>

                                        </ul>
                                    </div>
                                    <div class="social-sharing">
                                        <div class="widget widget_socialsharing_widget">
                                            <h3 class="widget-title-modal">Share this product</h3>
                                            <ul class="social__net social__net--2 d-flex justify-content-start ">
                                                <li class="linkedin"><a href="#" class="linkedin social-icon"><i class="zmdi zmdi-email"></i></a></li>
                                                <li class="pinterest"><a href="#" class="pinterest social-icon"><i class="zmdi zmdi-whatsapp"></i></a></li>
                                                <li class="tumblr"><a href="#" class="tumblr social-icon"><i class="zmdi zmdi-instagram"></i></a></li>

                                            </ul>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="button-cart">
                                            <asp:button runat="server" ID="btnCart" text="Add to Cart" cssclass="btn btn-outline-dark" OnClick="btnCart_Click" />
                                        </div>
                                        <div class="col-md-7 button-wishlist">
                                            <asp:button runat="server" ID="btnWishList" text="Add WishList" cssclass="btn btn-outline-dark" OnClick="btnWishList_Click" ValidationGroup="Size" />
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="product__info__detailed">
                        <div class="pro_details_nav nav justify-content-start" role="tablist">
                            <a class="nav-item nav-link active" data-toggle="tab" href="#nav-details" role="tab">Details</a>
                        </div>
                        <div class="tab__container">
                            <!-- Start Single Tab Content -->
                            <div class="pro__tab_label tab-pane fade show active" id="nav-details" role="tabpanel">
                                <div class="description__attribute">
                                    <p>
                                        <h6>Paper Stock:</h6>
                                        Matte Stock: 300 gsm premium quality paper which is brighter/whiter.
Matte Paper with lamination: The premium matte stock covered with plastic matte lamination. Lamination increases stiffness of the cards and protects them from regular wear. Perfect for long lasting cards.
Textured Paper: 260 gsm paper with a textured finish. Good for people who want colors on the card maintained for a longer time.
Metallic Paper: Use 285 gsm special metallic paper with golden luster to make your card look aesthetically good.
                                    </p>

                                </div>
                            </div>
                            <!-- End Single Tab Content -->

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

