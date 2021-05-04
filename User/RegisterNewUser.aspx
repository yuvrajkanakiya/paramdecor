<%@ Page Title="" Language="C#" MasterPageFile="~/Content/UserMasterPage.master" AutoEventWireup="true" CodeFile="RegisterNewUser.aspx.cs" Inherits="AdminPanel_RegisterNewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Start Bradcaump area -->
    <div class="ht__bradcaump__area bg-image--11">
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
    <!-- Start My Account Area -->
    <div class="row">
            <div class="col-sm-12">
                <div class="alert alert-success" id="divMessage" runat="server" visible="false">
                    <asp:Label ID="lblMessage" runat="server"/>
                </div>
            </div>
        </div>
    <section class="my_account_area pt--80 pb--55 bg--white">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 col-12">
                    <div class="my__account__wrapper">
                        <h3 class="account__title">Register</h3>
                        
                            <div class="account__form">
                                <div class="input__box">
                                    <label>User Name<span>*</span></label>
                                    <asp:TextBox runat="server" ID="txtUserName"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="Enter User Name" ControlToValidate="txtUserName" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>                                
                                <div class="input__box">
                                    <label>Email</label>
                                    <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Enter valid Email"
                                                    CssClass="text-danger" Display="Dynamic" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                               
                                <div class="input__box">
                                    <label>Password<span>*</span></label>
                                    <asp:TextBox runat="server" ID="txtPassword"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Enter Password" ControlToValidate="txtPassword" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form__btn">
                                    <asp:Button runat="server" ID="btnRegister" Text="Register" cssclass="btn btn-outline-success" OnClick="btnRegister_Click"/>
                                    <asp:Label runat="server" ID="lblNewUser" style="padding-left:10px;">already have account?</asp:Label>
                                <asp:HyperLink runat="server" ID="hlNewRegister" NavigateUrl="~/User/Login.aspx">Login</asp:HyperLink>
                                </div>

                            </div>
                        
                    </div>
                </div>

            </div>
        </div>
    </section>
    <!-- End My Account Area -->

</asp:Content>

