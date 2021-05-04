<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanelMasterPage.master" AutoEventWireup="true" CodeFile="CategoryAddEdit.aspx.cs" Inherits="AdminPanel_Category_CategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <section class="my_account_area pt--80 pb--55 bg--white">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="alert alert-success" id="divMessage" runat="server" visible="false">
                        <asp:Label ID="lblMessage" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-12 text-center">
                    <div class="my__account__wrapper" style="padding-top: 30px;">
                        <h2 class="account__title">Category</h2>

                        <div class="account__form">
                            <div class="input__box">
                                <label>Category Name<span>*</span></label>
                                <asp:TextBox runat="server" ID="txtCategoryName"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" ErrorMessage="Enter Category Name" ControlToValidate="txtCategoryName" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form__btn">
                                <asp:Button runat="server" ID="btnAdd" Text="Add" CssClass="btn btn-outline-success" OnClick="btnAdd_Click" />
                                <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-outline-danger" OnClick="btnCancel_Click" ValidationGroup="btnCancel" />
                            </div>

                        </div>

                    </div>
                </div>

            </div>
        </div>
    </section>

</asp:Content>

