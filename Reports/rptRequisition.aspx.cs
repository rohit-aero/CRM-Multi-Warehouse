using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

public partial class Reports_rptRequisition : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                int Month = DateTime.Now.Month + 2;
                txtFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
                txtTo.Text = DateTime.Now.AddMonths(2).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(2).Month) + "/" + DateTime.Now.AddMonths(2).Year;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            GenrateReport();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GenrateReport()
    {
        try
        {
            DataTable dt = new DataTable();
            DateTime dtfrom = Convert.ToDateTime(txtFrom.Text);
            DateTime dtto = Convert.ToDateTime(txtTo.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            rprt.Load(Server.MapPath("~/Reports/rptRequisition.rpt"));
            clscon.Return_DT_Visaul(dt, "EXEC [dbo].[aero_Req] '" + strDateFrom + "','" + strDateTo + "'");
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFrom.Text != "" && txtTo.Text != "")
                {
                    txtheader.Text = "PURCHASING REQUISITION REPORT FROM " + strDateFrom + " AND " + strDateTo;
                }
                else
                {
                    txtheader.Text = "PURCHASING REQUISITION REPORT ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Common");
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFrom.Text != "" && txtTo.Text != "")
                {
                    txtheader.Text = "PURCHASING REQUISITION REPORT FROM " + strDateFrom + " AND " + strDateTo;
                }
                else
                {
                    txtheader.Text = "PURCHASING REQUISITION REPORT ";
                }
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
}