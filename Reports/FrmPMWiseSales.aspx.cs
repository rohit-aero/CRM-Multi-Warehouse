using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_FrmPMWiseSales : System.Web.UI.Page
{
    commonclass1 cls = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateYearList();
            BindControls();
        }
    }

    private void BindControls()
    {
        try
        {
            DataTable dt = new DataTable();
            cls.Return_DT(dt, "EXEC [Get_PMWiseSales] 1");
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

    private void GenerateYearList()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("id", typeof(int));
            int startYear = 2023;
            int endYear = DateTime.Now.Year;

            for (int year = endYear; year >= startYear; year--)
            {
                DataRow dr = dt.NewRow();
                dr["text"] = year;
                dr["id"] = year;

                dt.Rows.Add(dr);
            }
            Utility.BindDropDownList(ddlYears, dt);
            ddlYears.SelectedValue = endYear.ToString();
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
            if (ddlYears.Items.Count > 0)
            {
                ddlYears.SelectedIndex = 1;
            }

            if (ddlProjectManager.Items.Count > 0)
            {
                ddlProjectManager.SelectedIndex = 0;
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
            String year = ddlYears.SelectedValue;
            string pm = "0";
            if (ddlProjectManager.SelectedIndex > 0)
            {
                pm = ddlProjectManager.SelectedValue;
            }
            cls.Return_DT(dt, "EXEC [Get_PMWiseSales] 2, " + year + ", " + pm);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {

            DataTable dt = ReportData();
            if (dt.Rows.Count > 0)
            {
                rprt.Load(Server.MapPath("~/Reports/rptPMWiseSales.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "PM Wise Sales Report - " + ddlYears.SelectedValue;
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "PM Wise Sales Report - " + ddlYears.SelectedValue;
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