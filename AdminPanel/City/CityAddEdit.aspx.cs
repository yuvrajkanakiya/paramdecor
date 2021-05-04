using ParamDecor;
using ParamDecor.BAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
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
            FillDropDownList();
            if (Request.QueryString["CityID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
            }
        }
    }
    #endregion Load Event

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListState(ddlStateID);
    }
    #endregion FillDropDownList

    #region Button : Add
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region ServerSide Validation
        String strErrorMessage = "";

        if (ddlStateID.SelectedIndex == 0)
            strErrorMessage += "Select State<br/>";

        if (txtCityName.Text == "")
            strErrorMessage += "Enter City Name<br/>";

        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            divMessage.Visible = true;
            return;
        }

        #endregion ServerSide Validation

        #region Collect FormData
        CityENT entCity = new CityENT();

        if (ddlStateID.SelectedIndex != 0)
            entCity.StateID = Convert.ToInt32(ddlStateID.SelectedValue);

        if (txtCityName.Text != "")
            entCity.CityName = txtCityName.Text.Trim();

        if (Session["UserID"] != null)
        {
            entCity.UserID = Convert.ToInt32(Session["UserID"]);
        }

        #endregion Collect FormData

        CityBAL balCity = new CityBAL();

        if (Request.QueryString["CityID"] == null)
        {
            if (balCity.Insert(entCity))
            {
                ClearControls();
                lblMessage.Text = "Add Successfully";
                divMessage.Visible = true;
            }
            else
            {
                lblMessage.Text = balCity.Message;
                divMessage.Visible = true;
            }
        }
        else
        {
            entCity.CityID = Convert.ToInt32(Request.QueryString["CityID"]);

            if (balCity.Update(entCity))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/City/CityList.aspx");
            }
            else
            {
                lblMessage.Text = balCity.Message;
                divMessage.Visible = true;
            }
        }
    }
    #endregion Button : Add

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityList.aspx");
    }
    #endregion Button : Cancel

    #region Clear Controls

    public void ClearControls()
    {
        ddlStateID.SelectedIndex = 0;
        txtCityName.Text = "";

        ddlStateID.Focus();
    }
    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 CityID)
    {
        CityBAL balCity = new CityBAL();
        CityENT entCity = new CityENT();

        entCity = balCity.SelectByPK(CityID);

        if (!entCity.StateID.IsNull)
            ddlStateID.SelectedValue = entCity.StateID.Value.ToString();

        if (!entCity.CityName.IsNull)
            txtCityName.Text = entCity.CityName.Value.ToString();

    }
    #endregion Fill Controls
}