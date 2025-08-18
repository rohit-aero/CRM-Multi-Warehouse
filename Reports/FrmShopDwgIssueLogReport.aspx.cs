using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_FrmShopDwgIssueLogReport : System.Web.UI.Page
{
    BOLManageShopDwgIssueLog ObjBOL = new BOLManageShopDwgIssueLog();
    BLLShopDwgIssueLog ObjBLL = new BLLShopDwgIssueLog();
    ReportDocument rprt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //SetDate();
            BindControls();
        }
    }

    private void SetDate()
    {
        try
        {
            int Month = DateTime.Now.Month + 2;
            txtFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            DateTime dateto = DateTime.Now.AddDays(60);
            string datenext = dateto.ToString("MM/dd/yyyy");
            txtTo.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindControls()
    {
        try
        {
            ObjBOL.Operation = 1;
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            int index = 0;
            if (ds.Tables[index].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlIssues, ds.Tables[index]);
            }

            index = 1;
            if (ds.Tables[index].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlJobs, ds.Tables[index]);
            }

            index = 2;
            if (ds.Tables[index].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlImpact, ds.Tables[index]);
            }

            index = 3;
            if (ds.Tables[index].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlCategory, ds.Tables[index]);
            }

            index = 4;
            if (ds.Tables[index].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlResponsiblePerson, ds.Tables[index]);
            }

            index = 6;
            if (ds.Tables[index].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlStatus, ds.Tables[index]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        btnPreview_Click();
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 14;
            if (ddlIssues.SelectedIndex > 0)
            {
                ObjBOL.IssueNo = ddlIssues.SelectedValue;
            }

            if (ddlImpact.SelectedIndex > 0)
            {
                ObjBOL.ImpactId = Int32.Parse(ddlImpact.SelectedValue);
            }

            if (ddlCategory.SelectedIndex > 0)
            {
                ObjBOL.CategoryId = Int32.Parse(ddlCategory.SelectedValue);
            }

            if (ddlResponsiblePerson.SelectedIndex > 0)
            {
                ObjBOL.ResponsiblePerson = Int32.Parse(ddlResponsiblePerson.SelectedValue);
            }

            if (ddlStatus.SelectedIndex > 0)
            {
                ObjBOL.StatusId = Int32.Parse(ddlStatus.SelectedValue);
            }

            if (ddlJobs.SelectedIndex > 0)
            {
                ObjBOL.JobId = ddlJobs.SelectedValue;
            }

            if (txtFrom.Text.Trim() != "" && txtTo.Text.Trim() != "")
            {
                ObjBOL.DateIdentified = Utility.ConvertDate(txtFrom.Text);
                ObjBOL.FollowupDate = Utility.ConvertDate(txtTo.Text);
            }

            ObjBOL.IssueDescription = txtIssueDescription.Text;
            if (ddlGroupBy.SelectedIndex > 0)
            {
                ObjBOL.GroupBy = ddlGroupBy.SelectedValue;
            }

            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void btnPreview_Click()
    {
        try
        {
            DataTable dt = ReportData();
            if (dt.Rows.Count > 0)
            {
                rprt.Load(Server.MapPath("~/Reports/rptShopDwgIssueLogReport.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtFrom.Text != "" && txtTo.Text != "")
                    {
                        txtheader.Text = "Shop Dwg Issue Logs (" + ddlGroupBy.SelectedItem.Text + ") - From " + txtFrom.Text + " to " + txtTo.Text;
                    }
                    else
                    {
                        txtheader.Text = "Shop Dwg Issue Logs (" + ddlGroupBy.SelectedItem.Text + ") - " + DateTime.Now.ToString("dddd dd MMMM yyyy");
                    }
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFrom.Text != "" && txtTo.Text != "")
                {
                    txtheader.Text = "Shop Dwg Issue Logs (" + ddlGroupBy.SelectedItem.Text + ") - From " + txtFrom.Text + " to " + txtTo.Text;
                }
                else
                {
                    txtheader.Text = "Shop Dwg Issue Logs (" + ddlGroupBy.SelectedItem.Text + ") - " + DateTime.Now.ToString("dddd dd MMMM yyyy");
                }
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel_Click();
    }

    private void btnCancel_Click()
    {
        try
        {
            //SetDate();
            txtFrom.Text = String.Empty;
            txtTo.Text = String.Empty;
            if (ddlImpact.Items.Count > 0)
            {
                ddlImpact.SelectedIndex = 0;
            }

            if (ddlCategory.Items.Count > 0)
            {
                ddlCategory.SelectedIndex = 0;
            }

            if (ddlResponsiblePerson.Items.Count > 0)
            {
                ddlResponsiblePerson.SelectedIndex = 0;
            }

            if (ddlStatus.Items.Count > 0)
            {
                ddlStatus.SelectedIndex = 0;
            }

            if (ddlIssues.Items.Count > 0)
            {
                ddlIssues.SelectedIndex = 0;
            }

            if (ddlJobs.Items.Count > 0)
            {
                ddlJobs.SelectedIndex = 0;
            }

            if (ddlGroupBy.Items.Count > 0)
            {
                ddlGroupBy.SelectedIndex = 0;
            }

            txtIssueDescription.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        btnExportExcel_Click();
    }

    private void btnExportExcel_Click()
    {
        try
        {
            DataTable dt = ReportData();
            if (dt.Rows.Count > 0)
            {
                Utility.ExportToExcelDT(dt, "Shop Dwg Issue Logs - " + DateTime.Now.ToString("dddd dd MMMM yyyy"));
            }
            else
            {
                Utility.ShowMessage_Error(Page, "No Records Found !!");
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtIssueDescription_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string input = txtIssueDescription.Text.Trim();
            string[] keywords = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (keywords.Length > 5)
            {
                string limitedInput = keywords[0];

                for (int i = 1; i < 5; i++)
                {
                    limitedInput += " " + keywords[i];
                }

                txtIssueDescription.Text = limitedInput;

                Utility.ShowMessage_Error(Page, "Only 5 keywords are allowed. Extra keywords have been removed.");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}