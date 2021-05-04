using ParamDecor.BAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Product_ProductList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["UserID"] == null)
        {
            Response.Redirect("~/User/Login.aspx");
        }
        if(!Page.IsPostBack)
        {
            FillProductGridView();
        }
    }
    #endregion Load Event

    #region FillProductGridView
    public void FillProductGridView()
    {
        DataTable dtProduct = new DataTable();
        ProductBAL balProduct = new ProductBAL();

        dtProduct = balProduct.SelectAll();

        if(dtProduct != null && dtProduct.Rows.Count > 0)
        {
            gvProduct.DataSource = dtProduct;
            gvProduct.DataBind();
        }
    }
    #endregion FillProductGridView

    #region Delete Records
    protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "DeleteRecord")
        {
            if(e.CommandArgument != null)
            {
                ProductBAL balProduct = new ProductBAL();
                ProductENT entProduct = new ProductENT();

                #region Delete image from folder
                entProduct = balProduct.SelectByPK(Convert.ToInt32(e.CommandArgument.ToString()));
                FileInfo path = new FileInfo(Server.MapPath(entProduct.ProductImage.Value.ToString()));
                path.Delete();
                #endregion Delete image from folder

                if (balProduct.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillProductGridView();
                }
                else
                {
                    lblMessage.Text = balProduct.Message;
                    divMessage.Visible = true;
                }
            }
        }
    }
    #endregion Delete Records
}