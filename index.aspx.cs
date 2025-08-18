using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Utility.EndCurrentSession();
    }

    public bool Verify()
    {
        bool Flag = true;
        try
        {
            if (txtUserName.Text == "")
            {
                Utility.ShowValidationMark(txtUserName);
                Flag = false;
            }
            else
            {
                Utility.RemoveValidationMark(txtUserName);
            }
            if (txtPassword.Text == "")
            {
                Utility.ShowValidationMark(txtPassword);
                Flag = false;
            }
            else
            {
                Utility.RemoveValidationMark(txtPassword);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return Flag;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (Verify())
            {
                lblErrorMessage.Text = Utility.Login(txtUserName.Text, txtPassword.Text, ddlLoginWith.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
    }
}
