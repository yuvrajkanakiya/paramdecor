<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanelMasterPage.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row table-responsive" style="padding-top: 140px;">
        <div class="col-md-12 text-center">
            <h3>State</h3>
            <div class="alert alert-success" id="divMessage" runat="server" visible="false">
                <asp:Label ID="lblMessage" runat="server" />
            </div>
            <div>
                <asp:GridView ID="gvState" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="gvState_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="StateID" HeaderText="#" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />

                        <asp:TemplateField headertext="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" NavigateUrl='<%# "~/AdminPanel/State/StateAddEdit.aspx?StateID=" + Eval("StateID") %>' runat="server" cssClass="text-primary">  
													Edit&nbsp;<i class="bi bi-pencil-square"></i>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server"
                                    ToolTip="Delete Record"
                                    OnClientClick="javascript:return confirm('Are you sure you want to delete record ? ');"
                                    cssClass="text-danger"
                                    CommandName="DeleteRecord"
                                    CommandArgument='<%#Eval("StateID") %>'><i class="bi bi-trash"></i></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderTemplate>Remove</HeaderTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

