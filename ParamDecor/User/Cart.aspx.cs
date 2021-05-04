using ParamDecor.BAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Cart : System.Web.UI.Page
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
        DataTable dtCartDetails = new DataTable();
        CartBAL balCartDetails = new CartBAL();
        
        dtCartDetails = balCartDetails.SelectALL(Convert.ToInt32(Session["UserID"]));
        if (dtCartDetails != null && dtCartDetails.Rows.Count > 0)
        {
            gvCartDetails.DataSource = dtCartDetails;
            gvCartDetails.DataBind();
        }
        GrandTotal();
    }
    #endregion FillProductDetailsGridView

    #region Delete Record
    protected void gvCartDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            if (e.CommandArgument != null)
            {
                CartBAL balCart = new CartBAL();
                if (balCart.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"])))
                {
                    FillProductDetailsGridView();
                }
                else
                {
                    lblMessage.Text = balCart.Message;
                    divMessage.Visible = true;
                }
            }
        }
    }
    #endregion Delete Record

    #region Button : Update Cart
    protected void btnUpdateCart_Click(object sender, EventArgs e)
    {
        CartBAL balCart = new CartBAL();
        CartENT entCart = new CartENT();

        foreach (GridViewRow row in gvCartDetails.Rows)
        {
            int intCartID = int.Parse((row.FindControl("lblCartID") as Label).Text);
            entCart.ProductDetailsID = int.Parse((row.FindControl("lblProductDetailsID") as Label).Text);
            entCart.Quantity = int.Parse((row.FindControl("txtQuantity") as TextBox).Text);

            if (balCart.Update(entCart, intCartID, Convert.ToInt32(Session["UserID"])))
            {                
                FillProductDetailsGridView();
            }
            else
            {
                lblMessage.Text = balCart.Message;
                divMessage.Visible = true;
            }
        }
       
    }
    #endregion Button : Update Cart

    #region GrandTotal
    private void GrandTotal()
    {
        float GTotal = 0f;
        for (int i = 0; i < gvCartDetails.Rows.Count; i++)
        {
            String total = (gvCartDetails.Rows[i].FindControl("lblTotal") as Label).Text;
            GTotal += Convert.ToSingle(total);
        }
        lblGrandTotal.Text = GTotal.ToString();
    }
    #endregion GrandTotal

    #region Button : Checkout
    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        if (Session["AddressID"] != null)
            Response.Redirect("~/User/Order.aspx");

        else
            Response.Redirect("~/User/Address.aspx");
    }
    #endregion Button : Checkout
}