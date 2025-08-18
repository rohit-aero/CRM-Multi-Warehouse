using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_FrmFabricationChinaDailyReport : System.Web.UI.Page
{
    commonclass1 cls = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = ReportData_FabChinaDailyReport();
            rprt.Load(Server.MapPath("~/Reports/rptFabChinaDailyReport.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Fabrication China Daily Report " + DateTime.Now.ToShortDateString();
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Fabrication China Daily Report " + DateTime.Now.ToShortDateString();
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

    private DataTable ReportData_FabChinaDailyReport()
    {
        DataTable dt = new DataTable();
        try
        {
            string issuedBy = "";
            string query = string.Empty;
            if (ddlIssued.SelectedIndex > 0)
            {
                issuedBy = ddlIssued.SelectedValue;
            }

            query = "EXEC Get_FabricationChinaDailyReport 1, '" + issuedBy + "'";
            cls.Return_DT(dt, query);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            ddlIssued.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}