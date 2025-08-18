using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Settings : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Utility.IsAuthorized())
        //{
        //    lblwelcomemsg.Text = "Hi " + Utility.GetCurrentSession().EmployeeName + " Welcome to " + Utility.GetCurrentSession().CustomerName;
        //}
        //else
        //{
        //    Utility.SendToLoginPage();
        //}
    }

    //protected void btnHome_Click(object sender, EventArgs e)
    //{
    //    Utility.SendUserToCorrespondingPage();
    //}

    protected void btnAddManageLoginInfo_Click(object sender, EventArgs e)
    {
        //if (Utility.GetCurrentSession().RoleName == Utility.CheckIfAdmin())
        //{

        //}
        //else
        //{
        //    Utility.ShowMessage(this.Page, "You are not authorized to view this page.");
        //}
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Utility.LogOut();
    }
   
}
