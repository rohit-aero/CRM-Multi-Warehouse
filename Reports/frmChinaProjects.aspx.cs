using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using BOLAERO;
using BLLAERO;


public partial class Reports_frmChinaProjects : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    BOLManageProjects ObjBOL = new BOLManageProjects();
    BLLManageProjectsEng ObjBLL = new BLLManageProjectsEng();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string fromdate = "01/01/" + DateTime.Now.Year;
                txtFromDate.Text = fromdate;
                txtToDate.Text = "12/31/" + DateTime.Now.Year;
                BindDropdown();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindDropdown()
    {
        try
        {
            DataTable dt = new DataTable();
            clscon.Return_DT(dt, "EXEC [dbo].[Get_ChinaProjects] null, null," + 3 + " ");
            Utility.BindDropDownListAll(ddlReportType, dt);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // check if data filled in required fields
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtFromDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter From Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter From Date. !!");
                txtFromDate.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
                return false;
            }
            if (txtToDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter To Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter To Date. !!");
                txtToDate.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_ChinaProjects] '" + strDateFrom + "','" + strDateTo + "','" + 1 + "', " + ddlReportType.SelectedValue);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport()
    {
        try
        {
            string HeaderText = string.Empty;
            DataTable dt = ReportData();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            var reportType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            rprt.Load(Server.MapPath("~/Reports/rptChinaProjects.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = (ddlReportType.SelectedItem.Text == "All" ? "" : ddlReportType.SelectedItem.Text) + " Projects From " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(reportType, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = (ddlReportType.SelectedItem.Text == "All" ? "" : ddlReportType.SelectedItem.Text) + " Projects From " + strDateFrom + " to " + strDateTo;
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }

    protected void btnGenrate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                GenrateReport();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            string fromdate = "01/01/" + DateTime.Now.Year;
            txtFromDate.Text = fromdate;
            txtToDate.Text = "12/31/" + DateTime.Now.Year;
            ddlReportType.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable ReportDataExportToExcel()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_ChinaProjects] '" + strDateFrom + "','" + strDateTo + "','" + 2 + "', " + ddlReportType.SelectedValue);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                DataTable dt = ReportDataExportToExcel();
                DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
                DateTime dtto = Convert.ToDateTime(txtToDate.Text);
                string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
                string strDateTo = dtto.ToString("MM/dd/yyyy");
                string FileName = (ddlReportType.SelectedItem.Text == "All" ? "" : ddlReportType.SelectedItem.Text) + " Projects From " + strDateFrom + " to " + strDateTo;
                Utility.ExportToExcelDT(dt, FileName);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

}