<%@ Page Title="" Language="C#" MasterPageFile="~/Content/UserMasterPage.master" AutoEventWireup="true" CodeFile="Wishlist.aspx.cs" Inherits="User_Wishlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="wrapper" id="wrapper">

        <!-- Start Bradcaump area -->
        <div class="ht__bradcaump__area bg-image--2">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="bradcaump__inner text-center">
                            <h2 class="bradcaump-title">Wishlist</h2>
                            <nav class="bradcaump-content">
                                <asp:HyperLink runat="server" NavigateUrl="~/User/Home.aspx" ID="hlBradecaumpHome">Home</asp:HyperLink>
                                <span class="brd-separetor">/</span>
                                <span>Wishlist</span>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Bradcaump area -->

        <div class="wishlist-area section-padding--lg bg__white">
            <div class="row table-responsive" style="padding-top: 140px;">
                <div class="col-md-12 text-center">

                    <div class="alert alert-success" id="divMessage" runat="server" visible="false">
                        <asp:Label ID="lblMessage" runat="server" />
                        <asp:hyperlink runat="server" ID="hlMessage" visible="false" class="alert-link" NavigateUrl="~/User/Cart.aspx"></asp:hyperlink>
                    </div>
                    <div>
                        <asp:GridView ID="gvProductDetails" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="gvProductDetails_RowCommand">
                            <Columns>
                                <asp:ImageField DataImageUrlField="ProductImage" HeaderText="Image" ControlStyle-Height="50" ControlStyle-Width="50"></asp:ImageField>
                                <asp:BoundField DataField="ProductName" HeaderText="Product" />
                                <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price")  %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Price(&#8377;)
                                </HeaderTemplate>
                            </asp:TemplateField>
                                <asp:BoundField DataField="Size" HeaderText="Size" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDelete" runat="server"
                                            ToolTip="Delete Record"
                                            OnClientClick="javascript:return confirm('Are you sure you want to Remvoe record ? ');"
                                            CommandName="Remove"
                                            CssClass="text-danger"
                                            CommandArgument='<%#Eval("ProductDetailsID") %>' Font-Size="Large"><i class="bi bi-trash"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderTemplate>
                                        Remove
                                    </HeaderTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Cart">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnAddToCart" runat="server" CommandArgument='<%#Eval("ProductDetailsID") %>'
                                            CommandName="AddtoCart" Font-Size="Large">
                                            <i class="fa fa-shopping-cart" aria-hidden="true"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

