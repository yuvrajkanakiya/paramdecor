<%@ Page Title="" Language="C#" MasterPageFile="~/Content/UserMasterPage.master" AutoEventWireup="true" CodeFile="Calendar.aspx.cs" Inherits="User_Calendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Start Bradcaump area -->
    <div class="ht__bradcaump__area bg-image--5">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcaump__inner text-center">
                        <h2 class="bradcaump-title">Calendar</h2>
                        <nav class="bradcaump-content">
                            <asp:hyperlink runat="server" navigateurl="~/User/Home.aspx" id="hlBradecaumpHome">Home</asp:hyperlink>
                            <span class="brd-separetor">/</span>
                            <span class="breadcrumb_item active">Calendar</span>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End Bradcaump area -->

    <section class="wn__bestseller__area bg--white pt--80  pb--30">

        <div class="container">
            <div class="row">
                <asp:repeater runat="server" id="rptCalendar">
                        <ItemTemplate>
                            <div class="col-md-3 col-sm-6">
                                <div class="product-grid3">
                                    <div class="product-image3">
                                        <asp:HyperLink runat="server" ID="hlCalendar"
                                            NavigateUrl='<%# "~/User/ProductDetails.aspx?ProductID=" + Eval("ProductID").ToString() + "&CategoryName=" + Eval("CategoryName") %>'>
                                            <asp:Image runat="server" ID="imgCalendar" ImageUrl='<%# Eval("ProductImage") %>' />
                                        </asp:HyperLink>
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
                                            <span class="price">&#8377;<%# Eval("Price") %></span>

                                        </div>

                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:repeater>
            </div>
        </div>
    </section>
</asp:Content>

