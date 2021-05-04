using ParamDecor.BAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/User/Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["StateID"] != null)
                FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
        }
    }

    #region Button : Add
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region ServerSide Validation
        String strErrorMessage = "";

        if (txtStateName.Text == "")
            strErrorMessage += "Enter StateName";

        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            divMessage.Visible = true;
            return;
        }
        #endregion ServerSide Validation

        #region Collect FormData
        StateENT entState = new StateENT();

        if (txtStateName.Text != "")
            entState.StateName = txtStateName.Text.Trim();

        if (Session["UserID"] != null)
        {
            entState.UserID = Convert.ToInt32(Session["UserID"]);
        }

        #endregion Collect FormData

        StateBAL balState = new StateBAL();

        if (Request.QueryString["StateID"] == null)
        {
            if (balState.Insert(entState))
            {
                ClearControls();
                lblMessage.Text = "Add SuccessFully";
                divMessage.Visible = true;
            }
            else
            {
                lblMessage.Text = balState.Message;
                divMessage.Visible = true;
            }
        }
        else
        {
            entState.StateID = Convert.ToInt32(Request.QueryString["StateID"]);
            if (balState.Update(entState))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/State/StateList.aspx");
            }
            else
            {
                lblMessage.Text = balState.Message;
                divMessage.Visible = true;
            }
        }
    }
    #endregion Button : Add

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/StateList.aspx");
    }
    #endregion Button : Cancel

    #region Clear Controls

    public void ClearControls()
    {
        txtStateName.Text = "";

        txtStateName.Focus();
    }
    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 StateID)
    {
        StateBAL balState = new StateBAL();
        StateENT entState = new StateENT();

        entState = balState.SelectByPK(StateID);

        if (!entState.StateName.IsNull)
            txtStateName.Text = entState.StateName.Value.ToString();
    }
    #endregion Fill Controls
}