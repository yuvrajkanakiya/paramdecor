using ParamDecor.BAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Wishlist : System.Web.UI.Page
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
            FillProductDetailsGridView();
        }
    }
    #endregion Load Event

    #region FillProductDetailsGridView
    public void FillProductDetailsGridView()
    {
        DataTable dtProductDetails = new DataTable();
        ProductDetailsBAL balProductDetails = new ProductDetailsBAL();

        dtProductDetails = balProductDetails.SelectALL(Convert.ToInt32(Session["UserID"]));

        if (dtProductDetails != null && dtProductDetails.Rows.Count > 0)
        {
            gvProductDetails.DataSource = dtProductDetails;
            gvProductDetails.DataBind();
        }
    }
    #endregion FillProductDetailsGridView

    #region Delete Records
    protected void gvProductDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            if (e.CommandArgument != null)
            {
                ProductDetailsBAL balProductDetails = new ProductDetailsBAL();
                if (balProductDetails.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"])))
                {
                    FillProductDetailsGridView();
                }
                else
                {
                    lblMessage.Text = balProductDetails.Message;
                    divMessage.Visible = true;
                }
            }
        }
        else if(e.CommandName == "AddtoCart")
        {
            if(e.CommandArgument != null)
            {
                CartBAL balCart = new CartBAL();
                CartENT entCart = new CartENT();

                if (Session["UserID"] != null)
                    entCart.UserID = Convert.ToInt32(Session["UserID"]);

                if (e.CommandArgument != null)
                    entCart.ProductDetailsID = Convert.ToInt32(e.CommandArgument.ToString().Trim());

                if (balCart.Insert(entCart))
                {
                    lblMessage.Text = "Add to Cart Successfully";
                    divMessage.Visible = true;
                    hlMessage.Text = "View Cart";
                    hlMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = balCart.Message;
                    divMessage.Visible = true;
                }
            }
        }
    }
    #endregion Delete Records
}