using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Reports_frmTrimarkQuarterly : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                PopulateYears(2018);
            }
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
            if (ddlYear.SelectedValue == "0")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Year. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Year. !!");
                ddlYear.Focus();
                return false;
            }
            if (ddlQuarter.SelectedValue == "-1")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Quarter. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Quarter. !!");
                ddlQuarter.Focus();
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
            clscon.Return_DT(dt, "EXEC [dbo].[Get_TrimarkQuarterly] '" + ddlYear.SelectedItem.Text + "','" + ddlQuarter.SelectedValue + "'");
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
            if (ValidationCheck() == true)
            {
                DataTable dt = ReportData();
                string year = ddlYear.SelectedItem.Text;
                string quarterName = ddlQuarter.SelectedItem.Text;
                rprt.Load(Server.MapPath("~/Reports/rptTrimarkQuarterly.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Trimark Quarterly Report for " + year + " " + quarterName + " " + " Quarter";
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Trimark Quarterly Report for " + year + " " + quarterName + " " + " Quarter";
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
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

    private void GenrateReportExcel()
    {
        try
        {
            DataTable dt = ReportData();
            string year = ddlYear.SelectedItem.Text;
            string quarterName = ddlQuarter.SelectedItem.Text;

            rprt.Load(Server.MapPath("~/Reports/rptTrimarkQuarterly.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Trimark Quarterly Report for " + year + " " + quarterName + " " + " Quarter";
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Trimark Quarterly Report for " + year + " " + quarterName + " " + " Quarter";
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

    protected void btnGenerateExcel_Click(object sender, EventArgs e)
    {
        try
        {
            GenrateReportExcel();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlYear.SelectedValue = "0";
        ddlQuarter.SelectedValue = "-1";
    }

    public void PopulateYears(int startYear)
    {
        try
        {
            ddlYear.Items.Clear();
            List<int> years = new List<int>();
            int currentYear = DateTime.Now.Year;
            for (int year = startYear; year <= currentYear; year++)
            {
                years.Add(year);
            }

            // Bind the dropdownlist           
            ddlYear.DataSource = years;
            ddlYear.DataBind();
            ddlYear.Items.Insert(0, new ListItem("Select", "0"));

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}