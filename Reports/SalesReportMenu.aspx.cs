using System;
using System.Data;
using System.Web.UI;

public partial class Reports_SalesReportMenu : System.Web.UI.Page
{
    commonclass1 cls = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckCommissionPermissions();
        }
    }

    private void CheckCommissionPermissions()
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                int userID = Utility.GetCurrentUser();
                if (userID == 66)
                {
                    ank1.Enabled = true;
                    ank2.Enabled = true;
                    ank3.Enabled = true;
                    ank4.Enabled = true;
                    ank5.Enabled = true;
                }
                else
                {
                    ank1.Enabled = false;
                    ank2.Enabled = false;
                    ank3.Enabled = false;
                    ank4.Enabled = false;
                    ank5.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}