using System;
using System.Data;
using BOLAERO;
using BLLAERO;
using System.Web.Security;
using System.Collections.Generic;
using System.Web.UI;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using System.Web;

public partial class _DefaultSomat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {           
            if (!IsPostBack)
            {
                ResetSession();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetSession()
    {
        try
        {
            Session["PNumber"] = null;
            Session["JobID"] = null;
            Session["SessionProjectSearch"] = null;
            Session["SessionProposalSearch"] = null;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}