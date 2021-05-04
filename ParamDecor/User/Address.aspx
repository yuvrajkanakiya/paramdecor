<%@ Page Title="" Language="C#" MasterPageFile="~/Content/UserMasterPage.master" AutoEventWireup="true" CodeFile="Address.aspx.cs" Inherits="User_Address" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Start Bradcaump area -->
    <div class="ht__bradcaump__area bg-image--1">
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

    <div class="row" style="margin-top: 20px; color: #002d44;">
        <div class="col-md-6 col-md-offset-6" style="margin: auto">
            <fieldset>

                <!-- Form Name -->
                <legend style="padding-left: 33%;">Address Details</legend>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-sm-3 control-label" for="textinput">Full Name</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="First  Middle  Last"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ErrorMessage="Enter Full Name" ControlToValidate="txtFullName" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="textinput">State</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Select State" ControlToValidate="ddlState" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="textinput">City</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Select City" ControlToValidate="ddlCity" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="textinput">Address 1</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtAddressLine1" runat="server" CssClass="form-control" placeholder="Address Line 1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddressLine1" runat="server" ErrorMessage="Enter Address" ControlToValidate="txtAddressLine1" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-2 control-label" for="textinput">Address 2</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtAddressLine2" runat="server" CssClass="form-control" placeholder="Address Line 2"></asp:TextBox>
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-sm-3 control-label" for="textinput">Post Code</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtPostCode" runat="server" CssClass="form-control" placeholder="postcode"></asp:TextBox>
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-sm-3 control-label" for="textinput">Mobile No.</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ErrorMessage="Enter Mobile No." ControlToValidate="txtMobileNo" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-offset-12 col-sm-12">
                        <div class="pull-left">
                            <asp:LinkButton ID="btnNext" runat="server" CssClass="Next_Button" OnClick="btnNext_Click"><span>NEXT</span></asp:LinkButton>
                        </div>
                        <div class="pull-right">
                            <asp:LinkButton ID="btnPrevious" runat="server" CssClass="Previous_Button" OnClick="btnPrevious_Click" ValidationGroup="btnPrevious"><span>PREVIOUS</span></asp:LinkButton>
                        </div>
                    </div>
                </div>

            </fieldset>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->
</asp:Content>

