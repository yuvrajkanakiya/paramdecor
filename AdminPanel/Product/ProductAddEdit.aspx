<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanelMasterPage.master" AutoEventWireup="true" CodeFile="ProductAddEdit.aspx.cs" Inherits="AdminPanel_Product_ProductAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function showpreview(input) {

            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgpreview').css('visibility', 'visible');
                    $('#imgpreview').attr('src', e.target.result);
                    $('.my__account__wrapper').css('visibility', 'visible');
                }
                reader.readAsDataURL(input.files[0]);
            }

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <section class="my_account_area pt--80 pb--55 bg--white">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="alert alert-success" id="divMessage" runat="server" visible="false">
                        <asp:Label ID="lblMessage" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row text-center">
                <div class="col-lg-6 col-6">
                    <div class="my__account__wrapper" style="padding-top: 30px;">
                        <h2 class="account__title">Product</h2>

                        <div class="account__form">
                            <div class="input__box">
                                <label>Category<span>*</span></label>
                                <asp:dropdownlist runat="server" ID="ddlCategoryID" CssClass="form-control"></asp:dropdownlist>
                            </div>
                            <div class="input__box">
                                <label>Product Name<span>*</span></label>
                                <asp:TextBox runat="server" ID="txtProductName"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ErrorMessage="Enter Product Name" ControlToValidate="txtProductName" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="input__box">
                                <label>Description<span>*</span></label>
                                <asp:TextBox runat="server" ID="txtDescription"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ErrorMessage="Enter Description" ControlToValidate="txtDescription" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="input__box">
                                <label>Price<span>*</span></label>
                                <asp:TextBox runat="server" ID="txtPrice"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="Enter Price" ControlToValidate="txtPrice" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>

                            <div class="input__box">
                                <label>Product Image<span>*</span></label>
                                <asp:fileupload runat="server" ID="fuProductImage" CssClass="form-control" onchange="showpreview(this);"></asp:fileupload>
                            </div>

                            <div class="form__btn">
                                <asp:Button runat="server" ID="btnAdd" Text="Add" CssClass="btn btn-outline-success" OnClick="btnAdd_Click" />
                                <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-outline-danger" ValidationGroup="btnCancel" OnClick="btnCancel_Click" />
                            </div>

                        </div>

                    </div>
                </div>

                <div class="col-lg-6 col-6" >
						<div class="my__account__wrapper" style="padding-top: 30px; visibility:hidden">
                            <h2 class="account__title">Image</h2>
                                <div class="account__form">
								    <img id="imgpreview" height="482" src="" style="border-width: 0px; visibility: hidden;" />
                                </div>
						</div>
					</div>

            </div>
        </div>
    </section>

</asp:Content>

