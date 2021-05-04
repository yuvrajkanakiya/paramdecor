using ParamDecor.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Calendar : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            FillRepeatorCalendar();
        }
    }
    #endregion Load Event

    #region Fill Repeator Calendar
    private void FillRepeatorCalendar()
    {
        DataTable dtCalendar = new DataTable();
        ProductBAL balProduct = new ProductBAL();

        dtCalendar = balProduct.SelectAllCalendar();

        if (dtCalendar != null && dtCalendar.Rows.Count > 0)
        {
            rptCalendar.DataSource = dtCalendar;
            rptCalendar.DataBind();
        }
    }
    #endregion Fill Repeator Calendar
}