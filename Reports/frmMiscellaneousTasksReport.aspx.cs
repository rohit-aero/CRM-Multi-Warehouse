using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_frmMiscellaneousTasksReport : System.Web.UI.Page
{
    BOLMiscellaneousTasks ObjBOL = new BOLMiscellaneousTasks();
    BLLMiscellaneousTasks ObjBLL = new BLLMiscellaneousTasks();
    commonclass1 cls = new commonclass1();
    ReportDocument rpt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
        }
    }

    #region Bind Functions

    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.Return_DataSet(ObjBOL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlCompanyName, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Validation

    private bool IsNullOrWhiteSpace(string value)
    {
        return value == null || value.Trim().Length == 0;
    }

    private bool ValidationCheck()
    {
        try
        {
            if ((!IsNullOrWhiteSpace(txtIssueDateFrom.Text) && IsNullOrWhiteSpace(txtIssueDateTo.Text)) ||
            (IsNullOrWhiteSpace(txtIssueDateFrom.Text) && !IsNullOrWhiteSpace(txtIssueDateTo.Text)))
            {
                Utility.ShowMessage_Error(Page, "Please Select Both From And To Issue Date !");
                return false;
            }

            if ((!IsNullOrWhiteSpace(txtSolutionDateFrom.Text) && IsNullOrWhiteSpace(txtSolutionDateTo.Text)) ||
            (IsNullOrWhiteSpace(txtSolutionDateFrom.Text) && !IsNullOrWhiteSpace(txtSolutionDateTo.Text)))
            {
                Utility.ShowMessage_Error(Page, "Please Select Both From And To Solution Date !");
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    #endregion

    #region Event Handlers

    protected void btnClear_Click(object sender, EventArgs e)
    {
        btnClear_Click_Event();
    }

    protected void btnExportToPDF_Click(object sender, EventArgs e)
    {
        GenerateReport();
    }

    #endregion

    #region Other Functions

    private void btnClear_Click_Event()
    {
        try
        {
            if (ddlCompanyName.Items.Count > 0)
            {
                ddlCompanyName.SelectedIndex = 0;
            }

            txtIssueDateFrom.Text = string.Empty;
            txtIssueDateTo.Text = string.Empty;
            txtSolutionDateFrom.Text = string.Empty;
            txtSolutionDateTo.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Report

    private string PrepareQuery()
    {
        try
        {
            string query = string.Empty;
            query += " SELECT [id], [CompanyName], [Location], [RefNo], [Contact], [Issue], CONVERT(VARCHAR, [IssueDate], 101) AS [IssueDate], [IssueBy], [Solution], ";
            query += " CONVERT(VARCHAR, [SolutionDate], 101) AS [SolutionDate], [Description], [DocPath] ";
            query += " FROM CCT_Misc_Tasks ";
            query += " WHERE id IS NOT NULL ";

            if (ddlCompanyName.SelectedIndex > 0)
            {
                query += " AND ID = " + ddlCompanyName.SelectedValue;
            }

            if (txtIssueDateFrom.Text != "" && txtIssueDateTo.Text != "")
            {
                query += " AND IssueDate >= '" + txtIssueDateFrom.Text + "' ";
                query += " AND IssueDate <= '" + txtIssueDateTo.Text + "' ";
            }

            if (txtSolutionDateFrom.Text != "" && txtSolutionDateTo.Text != "")
            {
                query += " AND SolutionDate >= '" + txtSolutionDateFrom.Text + "' ";
                query += " AND SolutionDate <= '" + txtSolutionDateTo.Text + "' ";
            }

            query += " ORDER BY [CompanyName] ASC ";
            return query;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return string.Empty;
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            if (ValidationCheck())
            {
                string query = PrepareQuery();
                if (query.Trim() != "")
                {
                    cls.Return_DT(dt, query);
                }
            }
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
            DataTable dt = new DataTable();
            dt = ReportData();
            rpt.Load(Server.MapPath("~/Reports/rptMiscellaneousTaskReport.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rpt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Miscellaneous Tasks";
                rpt.SetDataSource(dt);
                rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rpt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rpt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Miscellaneous Tasks";
                rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
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

    #endregion
}