using ParamDecor.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Tshirt : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillRepeatorTshirt();
        }
    }
    #endregion Load Event

    #region Fill Repeator T-shirt
    private void FillRepeatorTshirt()
    {
        DataTable dtTshirt = new DataTable();
        ProductBAL balProduct = new ProductBAL();

        dtTshirt = balProduct.SelectAllTshirt();

        if (dtTshirt != null && dtTshirt.Rows.Count > 0)
        {
            rptTshirt.DataSource = dtTshirt;
            rptTshirt.DataBind();
        }
    }
    #endregion Fill Repeator T-shirt
}