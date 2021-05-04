using ParamDecor.BAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ProductDetails : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["UserID"]==null)
        {
            Response.Redirect("~/User/Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            if(Request.QueryString["ProductID"] != null)
            FillProductDetails(Convert.ToInt32(Request.QueryString["ProductID"].ToString()));

            else
            {
                Response.Redirect("~/User/Home.aspx");
            }
        }
    }
    #endregion Load Event

    #region Fill Repeator Product
    private void FillProductDetails(Int32 ProductID)
    {
        ProductENT entProduct = new ProductENT();
        ProductBAL balProduct = new ProductBAL();

        entProduct = balProduct.SelectByPK(ProductID);

        if (!entProduct.Equals(null))
        {
            imgProduct.ImageUrl = entProduct.ProductImage.Value.ToString();
            lblProductName.Text = entProduct.ProductName.Value.ToString();
            lblPrice.Text = entProduct.Price.Value.ToString();
            lblDescription.Text = entProduct.Description.Value.ToString();

            if (Request.QueryString["CategoryName"] == "T-shirt")
                divTshirt.Visible = true;

            else if (Request.QueryString["CategoryName"] == "Calendar")
                divCalendar.Visible = true;

            else if (Request.QueryString["CategoryName"] == "Canvas")
                divCanvas.Visible = true;
        }
    }
    #endregion Fill Repeator Product

    Int32 tempProductDetailsID = 0;

    #region Botton : Add to Cart
    protected void btnCart_Click(object sender, EventArgs e)
    {
        InsertProductDetails();

        CartBAL balCart = new CartBAL();
        CartENT entCart = new CartENT();

        if (Session["UserID"] != null)
            entCart.UserID = Convert.ToInt32(Session["UserID"]);

        if (tempProductDetailsID != 0)
            entCart.ProductDetailsID = tempProductDetailsID;

        if (balCart.Insert(entCart))
        {
            lblMessage.Text = "Add to Cart SuccessFullly";
            divMessage.Visible = true;
            hlMessage.Text = "View Cart";
            hlMessage.NavigateUrl = ("~/User/Cart.aspx");
            hlMessage.Visible = true;
        }
        else
        {
            lblMessage.Text = balCart.Message;
            divMessage.Visible = true;
        }

    }
    #endregion Botton : Add to Cart

    #region Botton : Add Wishlist
    protected void btnWishList_Click(object sender, EventArgs e)
    {
        InsertProductDetails();
        lblMessage.Text = "Add to WishList SuccessFullly";
        divMessage.Visible = true;
        hlMessage.Text = "View Wishlist";
        hlMessage.NavigateUrl = ("~/User/Wishlist.aspx");
        hlMessage.Visible = true;

        if(rfvCalendarSize.IsValid)
        {
            rfvCalendarSize.Visible = true;
            rfvTshirtSize.Visible = false;
            rfvCanvasSize.Visible = false;
        }
            
        else if (rfvCanvasSize.IsValid)
        {
            rfvCanvasSize.Visible = true;
            rfvTshirtSize.Visible = false;
            rfvCalendarSize.Visible = false;
        }

        else if(rfvTshirtSize.IsValid)
        {
            rfvTshirtSize.Visible = true;
            rfvCalendarSize.Visible = false;
            rfvCanvasSize.Visible = false;
        }

        else
        {
            rfvCalendarSize.Visible = false;
            rfvCanvasSize.Visible = false;
            rfvTshirtSize.Visible = false;
        }
    }
    #endregion Botton : Add Wishlist
    
    #region InsertProduct Details
    private void InsertProductDetails()
    {
        if (rblCalendarSize.SelectedItem == null || rblCanvasSize.SelectedItem == null || rblTshirtSize.SelectedItem == null)
        {
            lblMessage.Text = "Select Size";
            divMessage.Visible = true;
        }
        ProductDetailsENT entProductDetails = new ProductDetailsENT();
        ProductDetailsBAL balProductDetails = new ProductDetailsBAL();

        if (Request.QueryString["ProductID"] != null)
            entProductDetails.ProductID = Convert.ToInt32(Request.QueryString["ProductID"].ToString());

        if (rblCalendarSize.SelectedItem != null)
            entProductDetails.Size = rblCalendarSize.SelectedItem.ToString();

        else if (rblCanvasSize.SelectedItem != null)
            entProductDetails.Size = rblCanvasSize.SelectedItem.ToString();

        else if (rblTshirtSize.SelectedItem != null)
            entProductDetails.Size = rblTshirtSize.SelectedItem.ToString();

        if (Session["UserID"] != null)
            entProductDetails.UserID = Convert.ToInt32(Session["UserID"]);

        if (balProductDetails.Insert(entProductDetails))
        {
            rblCalendarSize.SelectedValue = null;
            rblCanvasSize.SelectedValue = null;
            rblTshirtSize.SelectedValue = null;
            tempProductDetailsID = entProductDetails.ProductDetailsID.Value;
        }
        else
        {
            lblMessage.Text = balProductDetails.Message;
            divMessage.Visible = true;
        }
    }
    #endregion InsertProduct Details
}