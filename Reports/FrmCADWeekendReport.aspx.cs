using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_FrmCADWeekendReport : System.Web.UI.Page
{
    commonclass1 cls = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            cls.Return_DT(dt, "EXEC Get_CADReport " + ddlDays.SelectedValue);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnExportToPDF_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = ReportData();
            rprt.Load(Server.MapPath("~/Reports/rptCADDailyProjectReport.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "CAD Daily Project Report - " + DateTime.Now.ToString("dddd, dd MMMM yyyy").Replace(',', ' ');
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "CAD Daily Project Report - " + DateTime.Now.ToString("dddd, dd MMMM yyyy").Replace(',', ' ');
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
}