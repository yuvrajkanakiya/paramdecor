using ParamDecor.BAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Category_CategoryAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["CategoryID"] != null)
                FillControls(Convert.ToInt32(Request.QueryString["CategoryID"]));
        }
    }
    #endregion Load Event

    #region Button : Add
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region ServerSide Validation
        String strErrorMessage = "";

        if (txtCategoryName.Text == "")
            strErrorMessage += "Enter CategoryName";

        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            divMessage.Visible = true;
            return;
        }
        #endregion ServerSide Validation

        #region Collect FormData
        CategoryENT entCategory = new CategoryENT();

        if (txtCategoryName.Text != "")
            entCategory.CategoryName = txtCategoryName.Text.Trim();

        #endregion Collect FormData

        CategoryBAL balCategory = new CategoryBAL();

        if (Request.QueryString["CategoryID"] == null)
        {
            if (balCategory.Insert(entCategory))
            {
                ClearControls();
                lblMessage.Text = "Add SuccessFully";
                divMessage.Visible = true;
            }
            else
            {
                lblMessage.Text = balCategory.Message;
                divMessage.Visible = true;
            }
        }
        else
        {
            entCategory.CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
            if(balCategory.Update(entCategory))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Category/CategoryList.aspx");
            }
            else
            {
                lblMessage.Text = balCategory.Message;
                divMessage.Visible = true;
            }
        }
    }
    #endregion Button : Add

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Category/CategoryList.aspx");
    }
    #endregion Button : Cancel

    #region Clear Controls

    public void ClearControls()
    {
        txtCategoryName.Text = "";

        txtCategoryName.Focus();
    }
    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 CategoryID)
    {
        CategoryBAL balCategory = new CategoryBAL();
        CategoryENT entCategory = new CategoryENT();

        entCategory = balCategory.SelectByPK(CategoryID);

        if (!entCategory.CategoryName.IsNull)
            txtCategoryName.Text = entCategory.CategoryName.Value.ToString();
    }
    #endregion Fill Controls
}