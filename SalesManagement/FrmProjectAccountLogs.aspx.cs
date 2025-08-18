using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalesManagement_FrmProjectAccountLogs : System.Web.UI.Page
{
    commonclass1 cls = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SearchPNameButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtSearchPName.Text != "")
            {
                txtSearchPNum.Text = string.Empty;
                string output = txtSearchPName.Text;
                int openTagEndPosition = output.IndexOf("#");
                output = output.Substring(openTagEndPosition + 1);
                SyncTextbox("NUM", output);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void SearchJNumberButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtSearchPNum.Text.Length >= 7)
            {
                string OutJnumber = string.Empty;
                int index = txtSearchPNum.Text.IndexOf(',');
                if (txtSearchPNum.Text.Length > 7)
                {
                    if (index != -1)
                    {
                        OutJnumber = txtSearchPNum.Text.Substring(0, txtSearchPNum.Text.IndexOf(','));
                    }
                }
                else
                {
                    OutJnumber = txtSearchPNum.Text;
                }
                SyncTextbox("NAME", OutJnumber);
                return;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SyncTextbox(string type, string text)
    {
        try
        {
            if (type != "")
            {
                DataTable dt = new DataTable();
                if (type == "NUM")
                {
                    dt = Utility.ReturnProjects(26, text);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchPNum.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                        GetLogs(text);
                    }
                    else
                    {
                        txtSearchPNum.Text = "";
                        txtSearchPName.Text = "";
                        Utility.ShowMessage_Error(Page, "J# not Found");
                    }
                }
                else
                {
                    dt = Utility.ReturnProjects(25, text);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchPName.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                        GetLogs(text);
                    }
                    else
                    {
                        txtSearchPNum.Text = "";
                        txtSearchPName.Text = "";
                        Utility.ShowMessage_Error(Page, "J# not Found");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetLogs(string JobID)
    {
        try
        {
            DataTable dt = new DataTable();
            cls.Return_DT(dt, "EXEC aero_ManageProjectAccountLogs 1, '" + JobID + "' ");

            if (dt.Rows.Count > 0)
            {
                gvLogs.DataSource = dt;
                gvLogs.DataBind();
            }
            else
            {
                gvLogs.DataSource = string.Empty;
                gvLogs.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            txtSearchPName.Text = string.Empty;
            txtSearchPNum.Text = string.Empty;
            gvLogs.DataSource = string.Empty;
            gvLogs.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}