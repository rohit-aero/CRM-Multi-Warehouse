using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_FrmPOWeeklyReport : System.Web.UI.Page
{
    commonclass1 cls = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
            SetDate();
        }
    }

    private void BindControls()
    {
        try
        {
            DataTable dt = new DataTable();
            cls.Return_DT(dt, "EXEC aero_ManagePOWeeklySalesReport 1 ");
            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectManager, dt);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            int id = 0;
            if (ddlProjectManager.SelectedIndex > 0)
            {
                id = Int32.Parse(ddlProjectManager.SelectedValue);
            }
            string query = "EXEC Get_POWeeklySalesReport '" + txtFromDate.Text + "', '" + txtToDate.Text + "', " + id;
            cls.Return_DT(dt, query);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private bool ValidationCheck()
    {
        try
        {
            if (txtFromDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please select From Date !");
                txtFromDate.Focus();
                return false;
            }

            if (txtToDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please select To Date !");
                txtToDate.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnGenrate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                DataTable dt = ReportData();
                rprt.Load(Server.MapPath("~/Reports/rptPOWeeklyReport.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtFromDate.Text != "" && txtToDate.Text != "")
                    {
                        txtheader.Text = "Sales Activity Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                    }
                    else
                    {
                        txtheader.Text = "Sales Activity Report ";
                    }
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtFromDate.Text != "" && txtToDate.Text != "")
                    {
                        txtheader.Text = "Sales Activity Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                    }
                    else
                    {
                        txtheader.Text = "Sales Activity Report ";
                    }
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            SetDate();
            ddlProjectManager.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SetDate()
    {
        try
        {
            // Get the current date
            DateTime today = DateTime.Now;

            // Calculate the start of the week (Monday)
            int daysToMonday = (int)DayOfWeek.Monday - (int)today.DayOfWeek;
            if (daysToMonday > 0)
            {
                daysToMonday -= 7; // If today is after Monday, go back to the previous week
            }
            DateTime startOfWeek = today.AddDays(daysToMonday);

            // Calculate the end of the week (Saturday)
            DateTime endOfWeek = startOfWeek.AddDays(5); // Saturday is 5 days after Monday

            // Set the text boxes
            txtFromDate.Text = startOfWeek.ToString("MM/dd/yyyy");
            txtToDate.Text = endOfWeek.ToString("MM/dd/yyyy");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}