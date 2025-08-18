using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Reports_FrmDelayedProjects : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetDates();
        }
    }

    private void SetDates()
    {
        try
        {
            txtDateFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            txtDateTo.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
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
            SetDates();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationCheck()
    {
        try
        {
            if (txtDateFrom.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter From Date !");
                txtDateFrom.Focus();
                return false;
            }

            if (txtDateTo.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter To Date !");
                txtDateTo.Focus();
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
            string technician = string.Empty;
            string query = "EXEC Get_DelayedProjects 1, '" + Utility.ConvertDate(txtDateFrom.Text) + "', '" + Utility.ConvertDate(txtDateTo.Text) + "'";
            clscon.Return_DT(dt, query);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenerateReport()
    {
        try
        {
            if (ValidationCheck())
            {
                DataTable dt = ReportData();
                if (dt.Rows.Count > 0)
                {
                    rprt.Load(Server.MapPath("~/Reports/rptDelayedProjects.rpt"));
                    if (dt.Rows.Count > 0)
                    {
                        TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                        txtheader.Text = "Delayed Projects From " + txtDateFrom.Text + " to " + txtDateTo.Text;
                        rprt.SetDataSource(dt);
                        rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                    }
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Delayed Projects From " + txtDateFrom.Text + " to " + txtDateTo.Text;
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
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

    protected void btnReport_Click(object sender, EventArgs e)
    {
        GenerateReport();
    }
}