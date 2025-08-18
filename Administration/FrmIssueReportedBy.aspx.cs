using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using BOLAERO;
using BLLAERO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_IssueReportedBy : System.Web.UI.Page
{
    BOLCCT_IssueReportedBy objBOL = new BOLCCT_IssueReportedBy();
    BLLCCT_IssueReportedBy objBLL = new BLLCCT_IssueReportedBy();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Controls();
                Reset();
            }
        }
        catch(Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            objBOL.Operation = 1;
            ds = objBLL.GetCCT_IssueReportedBy(objBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlIssueReportedBy, ds.Tables[0]);

            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlIssueReportedBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlIssueReportedBy.SelectedIndex > 0)
            {
                hfCusId.Value = ddlIssueReportedBy.SelectedValue;
                DataSet ds = new DataSet();
                objBOL.Operation = 3;
                objBOL.id = Convert.ToInt32(ddlIssueReportedBy.SelectedValue);
                ds = objBLL.GetCCT_IssueReportedBy(objBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtIssueReportedBy.Text = Convert.ToString(ds.Tables[0].Rows[0]["name"]);
                    rdbStatus.SelectedValue = ds.Tables[0].Rows[0]["status"].ToString();
                    lblMsg.Text = "";
                    btnSave.Text = "Update";
                    Utility.MaintainLogs("FrmIssueReportedBy.aspx", "Save");
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["status"]) == 1)
                {
                    rdbStatus.SelectedValue = "1";
                }
                else
                {
                    rdbStatus.SelectedValue = "0";
                }
                //if (rdbStatus.SelectedIndex ==1)
                //{
                //    rdbStatus.Enabled = true;
                //}
                ////foreach (ListItem item in rdbStatus.Items)
                ////{
                ////    if (item.Text == "Disable")
                ////    {
                ////        item.Enabled = false;
                ////    }
                ////    else
                ////    {
                ////        item.Enabled = true;
                ////    }


                ////}
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void Reset()
    {
        try
        {
            ddlIssueReportedBy.SelectedIndex = 0;
            txtIssueReportedBy.Text = "";
            lblMsg.Text = "";
            rdbStatus.SelectedIndex = -1;
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtIssueReportedBy.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Issue . !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Issue . !");
                txtIssueReportedBy.Focus();
                return false;
            }

        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

        return true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                String msg = "";
                if (ddlIssueReportedBy.SelectedIndex > 0)
                {
                    objBOL.id = Convert.ToInt32(ddlIssueReportedBy.SelectedValue);
                }
                else
                {
                    objBOL.id = 0;
                }
                objBOL.Operation = 2;
                objBOL.name = txtIssueReportedBy.Text;
                objBOL.status = Convert.ToInt32(rdbStatus.SelectedValue);
                msg = objBLL.SaveCCT_IssueReportedBy(objBOL);
                if (ddlIssueReportedBy.SelectedIndex > 0)
                {
                    hfCusId.Value = ddlIssueReportedBy.SelectedValue;
                }
                else
                {
                    hfCusId.Value = msg;
                }

                Utility.ShowMessage_Success(this, msg);
                Bind_Controls();
                btnSave.Text = "Save";
                Reset();
            }
        }
        
        catch(Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Reset();
        }
        catch(Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}