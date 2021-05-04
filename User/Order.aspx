<%@ Page Title="" Language="C#" MasterPageFile="~/Content/UserMasterPage.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="User_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <script type="text/javascript">
        function successalert() {
            swal({
                title: 'Congratulations!',
                text: 'Your Order has been succesfully Completed',
                type: 'success',
                icon: 'success'
            });
        }
        function faileralert() {
            swal({
                title: 'Fail!',
                text: 'Order Fail',
                type: 'success',
                icon: 'warning'
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Start Bradcaump area -->
    <div class="ht__bradcaump__area bg-image--6" style="padding-bottom: 155px;">
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
            </div>
        </div>
    </div>
    <!--Section: Block Content-->
    <section>
        <div class="container">
            <!--Grid row-->
            <div class="row">

                <!--Grid column-->
                <div class="col-lg-7">

                    <!-- Card -->
                    <div class="mb-3">
                        <div class="pt-4 wish-list">

                            <h3 class="mb-4 text-center text-secondary">Checkout</h3>
                            <div style="overflow-x: hidden; overflow-y: scroll; height: 575px;">
                                <asp:Repeater runat="server" ID="rptCheckout">
                                    <ItemTemplate>
                                        <div class="row mb-4">
                                            <asp:Label ID="lblCartID" runat="server" Visible="false" Text='<%# Eval("CartID")  %>'></asp:Label>
                                            <div class="col-md-5 col-lg-3 col-xl-3">
                                                <div class="view zoom overlay z-depth-1 rounded mb-3 mb-md-0">
                                                    <asp:Image runat="server" ID="imgProductPhoto" ImageUrl='<%# Eval("ProductImage") %>' CssClass="rounded-right" BorderWidth="2" />

                                                </div>
                                            </div>
                                            <div class="col-md-7 col-lg-7 col-xl-7">
                                                <div>
                                                    <div class="d-flex justify-content-between">
                                                        <div>
                                                            <h5><%# Eval("ProductName") %></h5>
                                                            <p class="mb-2 text-muted text-uppercase small">'<%# Eval("CategoryName") %>'</p>
                                                            <p class="mb-2 text-muted text-uppercase">Quantity : '<%# Eval("Quantity") %>'</p>
                                                            <p class="mb-2 text-muted text-uppercase">Size : '<%# Eval("Size") %>'</p>
                                                        </div>
                                                        <h5 class="bi-cart-check-fill"></h5>
                                                    </div>
                                                    <div class="text-right">
                                                        <p><span><strong>Total &nbsp;:&nbsp; &#8377;<asp:Label runat="server" ID="lbltempTotal" Text='<%# ((Convert.ToInt32(Eval("Quantity")))*(Convert.ToInt32(Eval("Price")))) %>'></asp:Label></strong></span></p>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <!-- Card -->
                </div>
                <!--Grid column-->

                <!--Grid column-->
                <div class="col-lg-5">
                    <div class="mb-3">
                        <div class="pt-4">
                            <asp:Repeater runat="server" ID="rptAddressDetails">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-sm-7">
                                            <h5 class="mb-3">Shiping Details</h5>                                    
                                        </div>
                                        <div class="col-sm-5 text-right">
                                            <h4><asp:HyperLink runat="server" ID="hlAddressEdit" CssClass="bi bi-gear" title="Edit Address"
                                                NavigateUrl="~/User/Address.aspx">
                                            </asp:HyperLink></h4>
                                        </div>
                                    </div>
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <strong class="mb-0">Full Name</strong>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <%# Eval("FullName")  %>
                                                </div>
                                            </div>
                                            <hr />
                                            <br />
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <strong class="mb-0">State</strong>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <%# Eval("StateName")  %>
                                                </div>
                                            </div>
                                            <hr />
                                            <br />
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <strong class="mb-0">City</strong>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <%# Eval("CityName")  %>
                                                </div>
                                            </div>
                                            <hr />
                                            <br />
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <strong class="mb-0">Address</strong>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <%# Eval("Address1")  %>
                                                </div>
                                            </div>
                                            <hr />
                                            <br />
                                            <div class="row" id="rowPostCode">
                                                <div class="col-sm-3">
                                                    <strong class="mb-0">PostCode</strong>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <%# Eval("PostCode")  %>
                                                </div>
                                            </div>
                                            <hr />
                                            <br />
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <strong class="mb-0">Mobile No.</strong>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <%# Eval("MobileNo")  %>
                                                </div>
                                            </div>
                                            <hr />
                                            <br />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                    <!-- Card -->
                    <div class="mb-3">
                        <div class="pt-4">

                            <h5 class="mb-3">The Total Amount</h5>

                            <ul class="list-group list-group-flush">
                                <li class="list-group-item d-flex justify-content-between align-items-center border-0">Total Amount
                                <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">Shipping
                                    <asp:Label ID="lblShiping" runat="server"></asp:Label>
                                </li>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <div>
                                        <strong>Grand Total</strong>
                                    </div>
                                    <span>
                                        <strong><asp:Label runat="server" ID="lblGrandTotal"></asp:Label></strong>
                                    </span>
                                </li>
                            </ul>

                            <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" class="btn btn-primary btn-block" OnClick="btnPlaceOrder_Click" />

                        </div>
                    </div>
                    <!-- Card -->


                </div>
                <!--Grid column-->

            </div>
            <!-- Grid row -->
        </div>
    </section>
    <!--Section: Block Content-->
</asp:Content>

