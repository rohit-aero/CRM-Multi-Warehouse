using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_FrmHobartSummaryAndDetailReport : System.Web.UI.Page
{
    commonclass1 cls = new commonclass1();
    ReportDocument rpt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateYearList();
        }
    }

    private void GenerateYearList()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("YearName", typeof(string));
            dt.Columns.Add("Year", typeof(int));
            int startYear = DateTime.Now.Year - 5;
            int endYear = DateTime.Now.Year;

            for (int year = endYear; year >= startYear; year--)
            {
                DataRow dr = dt.NewRow();
                dr["YearName"] = year;
                dr["Year"] = year;

                dt.Rows.Add(dr);
            }
            Utility.BindDropDownList(ddlYear, dt);
            ddlYear.SelectedValue = endYear.ToString();
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
            if (ddlYear.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Year !");
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private DataTable ReportData_Detail()
    {
        DataTable dt = new DataTable();
        try
        {
            cls.Return_DT(dt, "Exec [Get_HobartSummaryAndDetailReport] 2, " + ddlYear.SelectedValue);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportData_Summary()
    {
        DataTable dt = new DataTable();
        try
        {
            cls.Return_DT(dt, "Exec [Get_HobartSummaryAndDetailReport] 1, " + ddlYear.SelectedValue);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnExportToPdf_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                DataTable dt = new DataTable();
                string reportName = "";
                string reportHeader = "";
                if (ddlReportType.SelectedValue == "D")
                {
                    dt = ReportData_Detail();
                    reportName = "~/Reports/rptHobartDetail.rpt";
                    reportHeader = "Hobart Detail Sales Report " + ddlYear.SelectedItem.Text;
                }
                else if (ddlReportType.SelectedValue == "S")
                {
                    dt = ReportData_Summary();
                    reportName = "~/Reports/rptHobartSummary.rpt";
                    reportHeader = "Hobart Summary Sales Report " + ddlYear.SelectedItem.Text;
                }

                rpt.Load(Server.MapPath(reportName));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rpt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = reportHeader;
                    rpt.SetDataSource(dt);
                    rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    rpt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rpt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = reportHeader;
                    rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            rpt.Close();
            rpt.Dispose();
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            ddlReportType.SelectedValue = "S";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}