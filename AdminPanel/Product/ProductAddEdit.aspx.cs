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

public partial class AdminPanel_Product_ProductAddEdit : System.Web.UI.Page
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
            FillDropDownList();
            if (Request.QueryString["ProductID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["ProductID"]));
            }
        }
    }
    #endregion Load Event

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListCategory(ddlCategoryID);
    }
    #endregion FillDropDownList

    #region Button : Add
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region ServerSide Validation
        String strErrorMessage = "";

        if (ddlCategoryID.SelectedIndex <= 0)
            strErrorMessage += "Select Category<br/>";

        if(txtProductName.Text == "")
            strErrorMessage += "Enter Product Name<br/>";

        if (txtDescription.Text == "")
            strErrorMessage += "Enter Description<br/>";

        if (txtPrice.Text == "")
            strErrorMessage += "Enter Price<br/>";

        if(strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            divMessage.Visible = true;
        }

        #endregion ServerSide Validation

        #region Collect FormData
        ProductENT entProduct = new ProductENT();

        if (ddlCategoryID.SelectedIndex != 0)
            entProduct.CategoryID = Convert.ToInt32(ddlCategoryID.SelectedValue);

        if (txtProductName.Text != "")
            entProduct.ProductName = txtProductName.Text.Trim();

        if (txtDescription.Text != "")
            entProduct.Description = txtDescription.Text.Trim();

        if (txtPrice.Text != "")
            entProduct.Price =Convert.ToInt32(txtPrice.Text.Trim());

        #region Upload File
        if(fuProductImage.HasFile)
        {
            string strPath = "~/ProductImage/";
            if(ddlCategoryID.SelectedItem.ToString() == "Calendar")
            {
                strPath += "Calendar/";
            }
            if (ddlCategoryID.SelectedItem.ToString() == "T-shirt")
            {
                strPath += "T-shirt/";
            }
            if (ddlCategoryID.SelectedItem.ToString() == "Canvas")
            {
                strPath += "Canvas/";
            }
            string strPhysicalPath = Server.MapPath(strPath) + fuProductImage.FileName;
            fuProductImage.SaveAs(strPhysicalPath);
            entProduct.ProductImage = strPath + fuProductImage.FileName;
            
        }
        else
        {
            lblMessage.Text = "Select File";
            divMessage.Visible = true;
        }
        #endregion Upload File

        #endregion Collect FormData

        ProductBAL balProduct = new ProductBAL();

        if(Request.QueryString["ProductID"] == null)
        {
            if(balProduct.Insert(entProduct))
            {
                ClearControls();
                lblMessage.Text = "Add Successfully";
                divMessage.Visible = true;
            }
            else
            {
                lblMessage.Text = balProduct.Message;
                divMessage.Visible = true;
            }
        }
        else
        {
            entProduct.ProductID = Convert.ToInt32(Request.QueryString["ProductID"]);

            if(balProduct.Update(entProduct))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Product/ProductList.aspx");
            }
            else
            {
                lblMessage.Text = balProduct.Message;
                divMessage.Visible = true;
            }
        }
        
    }
    #endregion Button : Add

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Product/ProductList.aspx");
    }
    #endregion Button : Cancel

    #region Clear Controls

    public void ClearControls()
    {
        ddlCategoryID.SelectedIndex = 0;
        txtProductName.Text = "";
        txtDescription.Text = "";
        txtPrice.Text = "";

        ddlCategoryID.Focus();
    }
    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 ProductID)
    {
        ProductBAL balProduct = new ProductBAL();
        ProductENT entProduct = new ProductENT();

        entProduct = balProduct.SelectByPK(ProductID);

        if (!entProduct.CategoryID.IsNull)
            ddlCategoryID.SelectedValue = entProduct.CategoryID.Value.ToString();

        if (!entProduct.ProductName.IsNull)
            txtProductName.Text = entProduct.ProductName.Value.ToString();

        if (!entProduct.Description.IsNull)
            txtDescription.Text = entProduct.Description.Value.ToString();

        if (!entProduct.Price.IsNull)
            txtPrice.Text = entProduct.Price.Value.ToString();

    }
    #endregion Fill Controls
}