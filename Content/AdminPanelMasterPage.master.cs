using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_AdminPanelMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["UserName"] != null)
        {
            lblUserName.Text = Session["UserName"].ToString().ToUpper();
            btnLogOut.Visible = true;
        }
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/User/Home.aspx");
    }
}
