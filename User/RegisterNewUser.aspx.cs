using ParamDecor.BAL;
using ParamDecor.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_RegisterNewUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Botton : Register
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        #region ServerSide Validation

        String strErrorMessage = "";

        if (txtUserName.Text == "")
            strErrorMessage += "Enter User Name<br/>";

        if (txtPassword.Text == "")
            strErrorMessage += "Enter Password<br/>";
        
        if(strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            divMessage.Visible = true;
            return;
        }
        #endregion ServerSide Validation

        #region Collect Form Data
        UserENT entUser = new UserENT();

        if (txtUserName.Text != "")
            entUser.UserName = txtUserName.Text.Trim();       

        if (txtEmail.Text != "")
            entUser.Email = txtEmail.Text.Trim();

        if (txtPassword.Text != "")
            entUser.Password = txtPassword.Text.Trim();

        #endregion Collect Form Data

        UserBAL balUser = new UserBAL();

        if(balUser.Insert(entUser))
        {
            ClearControls();
            lblMessage.Text = "Register SuccessFully";
            divMessage.Visible = true;
        }
        else
        {
            lblMessage.Text = balUser.Message;
            divMessage.Visible = true;
        }
    }

    #endregion Botton : Register

    #region Clear Controls

    public void ClearControls()
    {
        txtUserName.Text = "";
        txtEmail.Text = "";
        txtPassword.Text = "";

        txtUserName.Focus();
    }
    #endregion Clear Controls
}