using System;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
public partial class Reports_frmSalesForecast : System.Web.UI.Page
{
    BOLOpenProposalReports OBJBOL = new BOLOpenProposalReports();
    BLLOpenProposalReportDate OBJBLL = new BLLOpenProposalReportDate();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                txtYear.Text = DateTime.Now.Year.ToString();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Boolean ValidationCheck()
    {
        try
        {
            if (txtYear.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Year. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Year. !!");
                txtYear.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            OBJBOL.Operation = 2;
            ds = OBJBLL.GetOpenProposalReport(OBJBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Utility.BindDropDownListAll(ddlProjectStage, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                //Utility.BindDropDownListAll(ddlProjectManagers, ds.Tables[1]);
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
            if (txtYear.Text.Trim() != "")
            {
                string FQstr = String.Empty;
                FQstr += "EXEC [dbo].[aero_GetSalesForecast] " + txtYear.Text.Trim();
                clscon.Return_DT(dt, FQstr);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void Bind_Report()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                DataTable dt = ReportData();
                if (dt.Rows.Count > 0)
                {
                    gvReport.DataSource = dt;
                    gvReport.DataBind();
                }
                else
                {
                    gvReport.DataSource = "";
                    gvReport.DataBind();
                    Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_ReportExcel()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                DataTable dt = ReportData();
                if (dt.Rows.Count > 0)
                {
                    dt.Columns.Remove("MONTHNUM");
                    dt.AcceptChanges();
                    Utility.ExportToExcelDT(dt, "Sales Forecast " + txtYear.Text.Trim());
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSearchProposal_Click(object sender, EventArgs e)
    {
        try
        {
            Bind_Report();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnClearProposal_Click(object sender, EventArgs e)
    {
        try
        {
            //ddlNestingStatus.SelectedIndex = 0;     
            txtYear.Text = DateTime.Now.Year.ToString();
            gvReport.DataSource = "";
            gvReport.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Bind_ReportExcel();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal varvalue;
                if (e.Row.Cells[3].Text != "&nbsp;")
                {
                    varvalue = Convert.ToDecimal(e.Row.Cells[3].Text.Replace("$", ""));
                    if (varvalue < 0)
                    {
                        //e.Row.Cells[3].Font.Bold = true;
                        e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}