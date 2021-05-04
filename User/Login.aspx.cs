using ParamDecor.BAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region ServerSide Validatiion
        String strErrorMessage = "";

        if (txtUserName.Text == "")
            strErrorMessage += "Enter User Name<br/>";

        if (txtPassword.Text == "")
            strErrorMessage += "Enter Password<br/>";

        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            divMessage.Visible = true;
            return;
        }
        #endregion ServerSide Validatiion

        #region Collect Data
        String UserName = txtUserName.Text.ToString();
        String Password = txtPassword.Text.ToString();

        UserENT entUser = new UserENT();
        UserBAL balUser = new UserBAL();

        entUser = balUser.SelectByUserPassword(UserName, Password);

        if (!entUser.UserID.IsNull)
            Session["UserID"] = entUser.UserID.Value.ToString();

        if (!entUser.UserName.IsNull)
            Session["UserName"] = entUser.UserName.Value.ToString();

        if(!entUser.UserID.IsNull)
        {
            #region Get AddressID
            AddressENT entAddress = new AddressENT();
            AddressBAL balAddress = new AddressBAL();

            entAddress = balAddress.GetAddressIDByUserID(entUser.UserID.Value);

            if(!entAddress.AddressID.IsNull)
                Session["AddressID"] = entAddress.AddressID.Value;
                
            #endregion Get AddressID
        }

        if (!entUser.UserID.IsNull)
            if(entUser.UserType == "user")
                Response.Redirect("~/User/Home.aspx");

            else
                Response.Redirect("~/AdminPanel/Product/ProductList.aspx");

        else
        {
            lblMessage.Text = "Enter Valid Name or Password";
            divMessage.Visible = true;
        }

        #endregion Collect Data
    }
}