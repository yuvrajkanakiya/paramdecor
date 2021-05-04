using ParamDecor.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Canvas : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillRepeatorCanvas();
        }
    }
    #endregion Load Event

    #region Fill Repeator Canvas
    private void FillRepeatorCanvas()
    {
        DataTable dtCanvas = new DataTable();
        ProductBAL balProduct = new ProductBAL();

        dtCanvas = balProduct.SelectAllCanvas();

        if (dtCanvas != null && dtCanvas.Rows.Count > 0)
        {
            rptCanvas.DataSource = dtCanvas;
            rptCanvas.DataBind();
        }
    }
    #endregion Fill Repeator Canvas
}