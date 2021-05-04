using ParamDecor.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Category_CategoryList : System.Web.UI.Page
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
            FillCategoryGridView();
        }
    }
    #endregion Load Event

    #region FillCategoryGridView
    private void FillCategoryGridView()
    {
        CategoryBAL balCategory = new CategoryBAL();
        DataTable dtCategory = new DataTable();

        dtCategory = balCategory.SelectAll();
        
        if(dtCategory != null && dtCategory.Rows.Count > 0)
        {
            gvCategory.DataSource = dtCategory;
            gvCategory.DataBind();
        }
    }
    #endregion FillCategoryGridView

    #region gvCategory_RowCommand Event
    protected void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "DeleteRecord")
        {
            if(e.CommandArgument != null)
            {
                CategoryBAL balCategory = new CategoryBAL();
                if (balCategory.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillCategoryGridView();
                }
                else
                {
                    lblMessage.Text = balCategory.Message;
                    divMessage.Visible = true;
                }
            }
        }
    }
    #endregion gvCategory_RowCommand Event
}