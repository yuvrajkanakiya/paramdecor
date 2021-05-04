using ParamDecor.BAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            FillRepeatorProduct();
        }
    }

    #region Fill Repeator Product
    private void FillRepeatorProduct()
    {
        DataTable dtProduct = new DataTable();
        ProductBAL balProduct = new ProductBAL();

        dtProduct = balProduct.SelectAll();
        
        if (dtProduct != null && dtProduct.Rows.Count > 0)
        {
            rptProducts.DataSource = dtProduct;
            rptProducts.DataBind();
        }

    }
    #endregion Fill Repeator Product

}