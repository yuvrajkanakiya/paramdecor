<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanelMasterPage.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                                <label>State<span>*</span></label>
                                <asp:dropdownlist runat="server" ID="ddlStateID" CssClass="form-control"></asp:dropdownlist>
                            </div>
                            <div class="input__box">
                                <label>City Name<span>*</span></label>
                                <asp:TextBox runat="server" ID="txtCityName"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ErrorMessage="Enter CityName" ControlToValidate="txtCityName" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form__btn">
                                <asp:Button runat="server" ID="btnAdd" Text="Add" CssClass="btn btn-outline-success" OnClick="btnAdd_Click" />
                                <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-outline-danger" ValidationGroup="btnCancel" OnClick="btnCancel_Click" />
                            </div>

                        </div>

                    </div>
                </div>

            </div>
        </div>
    </section>

</asp:Content>

