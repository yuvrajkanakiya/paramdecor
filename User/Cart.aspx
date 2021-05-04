<%@ Page Title="" Language="C#" MasterPageFile="~/Content/UserMasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="User_Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">

        function OnTextKeyPress(obj) {

            var txtScore = document.getElementById(obj.id);
            var Score = txtScore.value;

            var lblTotal = document.getElementById(obj.id.replace('txtQuantity', 'lblTotal'));

            var lblPrice = document.getElementById(obj.id.replace('txtQuantity', 'lblPrice'));

            var lblCartTotal = document.getElementById(obj.id.replace('txtQuantity', 'lblGrandTotal'));

            var Total = parseInt(lblPrice.innerHTML) * parseInt(Score);

            lblTotal.innerHTML = Total;
            //Calculate and update Grand Total.
            var grandTotal = 0;
            $("[id*=lblTotal]").each(function () {
                grandTotal = grandTotal + parseFloat($(this).html());
            });
            $("[id*=lblGrandTotal]").html(grandTotal.toString());
        }

    </script>
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
                <asp:Label ID="lblMessage" runat="server" />
                <asp:HyperLink runat="server" ID="hlMessage" Visible="false" class="alert-link"></asp:HyperLink>
            </div>
        </div>
    </div>

    <!-- cart-main-area start -->
    <div class="cart-main-area section-padding--lg bg--white">
        <div class="row">
            <div class="col-md-12 col-sm-12 ol-lg-12">
                <div class="table-content wnro__table table-responsive">
                    <asp:GridView ID="gvCartDetails" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="gvCartDetails_RowCommand">
                        <Columns>
                            <asp:TemplateField visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblCartID" runat="server" Text='<%# Eval("CartID")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductDetailsID" runat="server" Text='<%# Eval("ProductDetailsID")  %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            <asp:ImageField DataImageUrlField="ProductImage" HeaderText="Image" ControlStyle-Height="50" ControlStyle-Width="50"></asp:ImageField>
                            <asp:BoundField DataField="ProductName" HeaderText="Product" />
                            <asp:BoundField DataField="Size" HeaderText="Size" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price")  %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Price(&#8377;)
                                </HeaderTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="txtQuantity" TextMode="Number" min="1" max="20" Text='<%# Eval("Quantity")  %>' onBlur="return OnTextKeyPress(this);">
                                    </asp:TextBox>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Quantity
                                </HeaderTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblTotal" runat="server" text ='<%# ((Convert.ToInt32(Eval("Quantity")))*(Convert.ToInt32(Eval("Price"))))%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Total
                                </HeaderTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server"
                                        ToolTip="Delete Record"
                                        OnClientClick="javascript:return confirm('Are you sure you want to Remvoe record ? ');"
                                        CommandName="Remove"
                                        CssClass="text-danger"
                                        CommandArgument='<%#Eval("CartID") %>' Font-Size="Large"><i class="bi bi-trash"></i></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Remove
                                </HeaderTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

                </div>
                <div class="row">
                    <div class="col-lg-6 offset-lg-6">
                        <div class="cartbox__total__area">

                            <div class="cart__total__amount">
                                <span>Grand Total</span>
                                <span>
                                    <i>&#8377;</i>&nbsp;<asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="cartbox__btn">
                    <ul class="cart__btn__list d-flex flex-wrap flex-md-nowrap flex-lg-nowrap justify-content-between">
                        <li></li>
                        <li></li>
                        <li>
                            <asp:LinkButton runat="server" ID="btnUpdateCart" OnClick="btnUpdateCart_Click">Update Cart</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="btnCheckOut" OnClick="btnCheckOut_Click" >Check Out</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </div>

    </div>
    <!-- cart-main-area end -->
</asp:Content>
