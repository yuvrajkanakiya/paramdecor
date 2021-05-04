using ParamDecor;
using ParamDecor.BAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Address : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/User/Login.aspx");
        }
        if(!Page.IsPostBack)
        {
            FillDropDownList();
            FilAddressDetails();
        }
    }

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListState(ddlState);
        CommonFillMethods.FillDropDownListEmpty(ddlCity);
    }
    #endregion FillDropDownList

    #region FillDropDownListCityByStateID
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlState.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownListCityByStateID(ddlCity, Convert.ToInt32(ddlState.SelectedValue.Trim()));
            ddlCity.Focus();
        }
        else
        {
            CommonFillMethods.FillDropDownListEmpty(ddlCity);
        }
    }
    #endregion FillDropDownListCityByStateID

    #region Button : Previous
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/Cart.aspx");
    }
    #endregion Button : Previous

    #region Buttton : Next
    protected void btnNext_Click(object sender, EventArgs e)
    {
        #region ServerSide Validation

        String strErrorMessage = "";

        if (txtFullName.Text == "")
            strErrorMessage += "Enter Full Name<br/>";

        if (ddlState.SelectedIndex <= 0)
            strErrorMessage += "Select State<br/>";

        if (ddlCity.SelectedIndex <= 0)
            strErrorMessage += "Select City<br/>";

        if (txtAddressLine1.Text == "")
            strErrorMessage += "Enter AddressLine 1<br/>";

        if (txtMobileNo.Text == "")
            strErrorMessage += "Enter Mobile No.<br/>";

        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            divMessage.Visible = true;
            return;
        }
        #endregion ServerSide Validation

        #region Collect Form Data
        AddressENT entAddress = new AddressENT();

        if (Session["UserID"] != null)
            entAddress.UserID = Convert.ToInt32(Session["UserID"]);

        if (txtFullName.Text != "")
            entAddress.FullName = txtFullName.Text.Trim();

        if (ddlState.SelectedIndex > 0)
            entAddress.StateID = Convert.ToInt32(ddlState.SelectedValue.ToString());

        if (ddlCity.SelectedIndex > 0)
            entAddress.CityID = Convert.ToInt32(ddlCity.SelectedValue.ToString());

        if (txtAddressLine1.Text != "")
            entAddress.Address1 = txtAddressLine1.Text.Trim();

        if (txtAddressLine2.Text != "")
            entAddress.Address2 = txtAddressLine2.Text.Trim();

        if (txtPostCode.Text != "")
            entAddress.Postcode = Convert.ToInt32(txtPostCode.Text.Trim());

        if (txtMobileNo.Text != "")
             entAddress.MobileNo = txtMobileNo.Text.Trim();

        #endregion Collect Form Data
        AddressBAL balAddress = new AddressBAL();
        if (Session["AddressID"] == null)
        {
            if (balAddress.Insert(entAddress))
            {
                Session["AddressID"] = entAddress.AddressID.Value;
                ClearControls();
            }
            else
            {
                lblMessage.Text = balAddress.Message;
                divMessage.Visible = true;
            }
        }
        else
        {
            entAddress.AddressID = Convert.ToInt32(Session["AddressID"]);
            if (balAddress.Update(entAddress, entAddress.AddressID, entAddress.UserID))
            {
                ClearControls();
                Response.Redirect("~/User/Order.aspx");
            }
            else
            {
                lblMessage.Text = balAddress.Message;
                divMessage.Visible = true;
            }
        }
    }
    #endregion Buttton : Next

    #region ClearControls
    private void ClearControls()
    {
        txtFullName.Text = "";
        ddlState.SelectedIndex = 0;
        ddlCity.SelectedIndex = 0;
        txtAddressLine1.Text = "";
        txtAddressLine2.Text = "";
        txtPostCode.Text = "";
        txtMobileNo.Text = "";

        txtFullName.Focus();
    }
    #endregion ClearControls

    #region FilAddressDetails
    private void FilAddressDetails()
    {
        AddressBAL balAddress = new AddressBAL();
        AddressENT entAddress = new AddressENT();

        entAddress = balAddress.SelectByPK(Convert.ToInt32(Session["AddressID"]), Convert.ToInt32(Session["UserID"]));

        if (!entAddress.FullName.IsNull)
            txtFullName.Text = entAddress.FullName.Value;

        if (!entAddress.StateID.IsNull)
            ddlState.SelectedValue = entAddress.StateID.Value.ToString();

        if (!entAddress.CityID.IsNull)
        {
            ddlCity.SelectedValue = entAddress.CityID.Value.ToString();
            CommonFillMethods.FillDropDownListCityByStateID(ddlCity, entAddress.StateID);
        }

        if (!entAddress.Address1.IsNull)
            txtAddressLine1.Text = entAddress.Address1.Value;

        if (!entAddress.Address2.IsNull)
            txtAddressLine2.Text = entAddress.Address2.Value;

        if (!entAddress.Postcode.IsNull)
            txtPostCode.Text = entAddress.Postcode.Value.ToString();

        if (!entAddress.MobileNo.IsNull)
            txtMobileNo.Text = entAddress.MobileNo.Value;
    }
    #endregion FilAddressDetails

}