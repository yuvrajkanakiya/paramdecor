using ParamDecor.BAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["UserID"] == null)
        {
            Response.Redirect("~/User/Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            FillRepeatorCart();
            FillAddressDetails();            
        }
    }

    #region Fill Repeator Cart
    private void FillRepeatorCart()
    {
        DataTable dtCartDetails = new DataTable();
        CartBAL balCartDetails = new CartBAL();

        dtCartDetails = balCartDetails.SelectALL(Convert.ToInt32(Session["UserID"]));
        if (dtCartDetails != null && dtCartDetails.Rows.Count > 0)
        {
            rptCheckout.DataSource = dtCartDetails;
            rptCheckout.DataBind();
        }
        GrandTotal();

    }
    #endregion Fill Repeator Cart


    #region FillAddressDetails
    private void FillAddressDetails()
    {
        DataTable dtAddressDetails = new DataTable();
        AddressBAL balAddress = new AddressBAL();

        dtAddressDetails = balAddress.SelectALL(Convert.ToInt32(Session["UserID"]));
        if (dtAddressDetails != null && dtAddressDetails.Rows.Count > 0)
        {
            rptAddressDetails.DataSource = dtAddressDetails;
            rptAddressDetails.DataBind();
        }
    }
    #endregion FillAddressDetails

    #region GrandTotal
    private void GrandTotal()
    {
        float GTotal = 0f;
        for (int i = 0; i < rptCheckout.Items.Count; i++)
        {
            String total = (rptCheckout.Items[i].FindControl("lbltempTotal") as Label).Text;
            GTotal += Convert.ToSingle(total);
        }
        float temp = GTotal + 100;
        lblTotal.Text = "&#8377;" + GTotal.ToString();
        lblGrandTotal.Text = "&#8377;" + temp.ToString();
        lblShiping.Text = "&#8377;100";
    }
    #endregion GrandTotal



    protected void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        OrderENT entOrder = new OrderENT();
        OrderBAL balOrder = new OrderBAL();

        for (int i = 0; i < rptCheckout.Items.Count; i++)
        {
            entOrder.UserID = Convert.ToInt32(Session["UserID"]);
            entOrder.CartID = Convert.ToInt32((rptCheckout.Items[i].FindControl("lblCartID") as Label).Text);
            entOrder.AddressID = Convert.ToInt32(Session["AddressID"]);
            entOrder.Total = Convert.ToInt32((rptCheckout.Items[i].FindControl("lbltempTotal") as Label).Text);
     
            if(balOrder.Insert(entOrder))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "faileralert();", true);
            }
        }
    }
}