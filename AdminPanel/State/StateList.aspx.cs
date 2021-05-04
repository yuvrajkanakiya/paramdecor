using ParamDecor.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_State_StateList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/User/Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            FillStateGridView();
        }
    }
    #endregion Load Event

    #region FillStateGridView
    private void FillStateGridView()
    {
        StateBAL balState = new StateBAL();
        DataTable dtState = new DataTable();

        dtState = balState.SelectAll();

        if (dtState != null && dtState.Rows.Count > 0)
        {
            gvState.DataSource = dtState;
            gvState.DataBind();
        }
    }
    #endregion FillCategoryGridView

    #region gvState_RowCommand Delete
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                StateBAL balState = new StateBAL();
                if (balState.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillStateGridView();
                }
                else
                {
                    lblMessage.Text = balState.Message;
                    divMessage.Visible = true;
                }
            }
        }
    }
    #endregion gvState_RowCommand Delete
}