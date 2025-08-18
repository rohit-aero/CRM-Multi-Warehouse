using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_frmNewCADReport : System.Web.UI.Page
{
    BLLDailyCADReport ObjBLL = new BLLDailyCADReport();
    BOLDailyCADReport ObjBOL = new BOLDailyCADReport();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

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
            ds = ObjBLL.GetControls(ObjBOL);

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlNatureOfTaskList, ds.Tables[2]);
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlStatusList, ds.Tables[3]);
            }

            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectEngineer, ds.Tables[4]);
            }

            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectList, ds.Tables[5]);
            }

            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectManagerList, ds.Tables[6]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Event Handler Functions    

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Reset();
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "StatusID").ToString();
                string priority = DataBinder.Eval(e.Row.DataItem, "Priority").ToString();
                string changeColor = DataBinder.Eval(e.Row.DataItem, "ChangeColor").ToString();
                ObjBOL.Operation = 12;
                string color = "#FFFFFF";
                if (status != "")
                {
                    ObjBOL.ID = Int32.Parse(status);
                    color = ObjBLL.SaveAndUpdate(ObjBOL);
                }
                string css = "background-color: RGB(" + color + ") !important;";
                if (priority.Trim().ToUpper() == "URGENT")
                {
                    css += "color:red;";
                }
                else if (changeColor.Trim() == "CHANGECOLOR" && status.Trim() == "5")
                {
                    css += "color:yellow;";
                }
                else
                {
                    css += "color:black;";
                }
                e.Row.Attributes["style"] = css;
                foreach (TableCell cell in e.Row.Cells)
                {
                    cell.Attributes["style"] = "border: 1px solid black !important;";
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnGenerateExcel(object sender, EventArgs e)
    {
        BindGrid();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    #endregion

    #region Report   

    private void BindGrid()
    {
        btnExportToExcel.Enabled = true;
        btnExportToPDF.Enabled = true;
        GenerateReport();
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            DataSet ds = new DataSet();
            if (ddlProjectManagerList.SelectedIndex > 0)
            {
                ObjBOL.ID = Convert.ToInt32(ddlProjectManagerList.SelectedValue);
            }
            if (ddlProjectEngineer.SelectedIndex > 0)
            {
                ObjBOL.ProjectEngineerID = Convert.ToInt32(ddlProjectEngineer.SelectedValue);
            }
            if (ddlProjectList.SelectedIndex > 0)
            {
                ObjBOL.PNumber = ddlProjectList.SelectedValue;
            }
            if (ddlNatureOfTaskList.SelectedIndex > 0)
            {
                ObjBOL.NatureID = Convert.ToInt32(ddlNatureOfTaskList.SelectedValue);
            }
            if (ddlStatusList.SelectedIndex > 0)
            {
                ObjBOL.StatusID = Convert.ToInt32(ddlStatusList.SelectedValue);
            }
            ds = ObjBLL.BindReport(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                DataRow rowBlank = dt.NewRow();
                dt.Rows.Add(rowBlank);
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    DataRow rowTemp = dt.NewRow();
                    rowTemp["ProjectDescription"] = row[1];
                    rowTemp["StatusID"] = row[0];
                    dt.Rows.Add(rowTemp);
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
            DataTable dt = ReportData();
            if (dt.Rows.Count > 0)
            {
                lblRecordsCount.Text = "Total No. of Records: " + dt.Rows.Count.ToString();
                lblRecordsCount.Visible = true;
                gvDailyProjectReport.DataSource = dt;
                gvDailyProjectReport.DataBind();
                ExportToExcel();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ExportToExcel()
    {
        string FileName = "Daily CAD Report";
        gvDailyProjectReport.Attributes.Remove("class");
        Utility.ExportToExcelGrid(gvDailyProjectReport, FileName);
    }

    private string PrepareSQLCommandForReport()
    {
        try
        {
            string query = string.Empty;
            query += " SELECT CONVERT(VARCHAR(10), SUB.ReportDate, 101) AS ReportDate, ";
            query += " SUB4.PNumber +', ' + SUB4.ProjectName +', '+ CONCAT(SUB4.City , ', ' + SUB5.[State] , ', ' + SUB4.Country,', ' + SUB6.FirstName , ', ' + SUB3.JobID) AS PName, ";
            query += " SUB6.FirstName AS ProjectManager,  CASE WHEN MAIN.Correction IS NOT NULL AND MAIN.Correction <> '' THEN CONCAT(SUB1.Task, ', ', MAIN.Correction) ELSE SUB1.Task END AS Task, SUB2.[Status], CONVERT(VARCHAR(10), MAIN.ReqRCD, 101) AS ReqRCD,CONVERT(VARCHAR(10), MAIN.SentCAD, 101) AS SentCAD, MAIN.StatusID, ";
            query += " CONVERT(VARCHAR(10), MAIN.SentRCD, 101) AS SentRCD, CONCAT(SUB7.FirstName + ' ',SUB7.LastName) AS ProjectEngineer, MAIN.Comments, MAIN.Remarks, ";
            query += " CASE WHEN MAIN.[Priority] = '2' THEN 'URGENT' ELSE 'REGULAR' END AS [Priority], ";
            query += " CASE WHEN DATEDIFF(DAY, SentCAD, GETDATE()) <= 2 AND SentRCD IS NULL THEN 'YELLOW' WHEN DATEDIFF(DAY, SentCAD, GETDATE()) > 2 AND SentRCD IS NULL THEN 'RED' ELSE 'DEFAULT' END AS MarkRed, ";
            query += " CASE WHEN SentRCD IS NULL AND DATEDIFF(DAY, ReqRCD, GETDATE()) > 0 THEN DATEDIFF(DAY, ReqRCD, GETDATE()) WHEN SentRCD IS NULL AND DATEDIFF(DAY, ReqRCD, GETDATE()) = 0 THEN '' END AS ResponseTime ";
            query += " FROM tblCADReportDetail MAIN ";
            query += " LEFT JOIN tblCADReport SUB ON SUB.ID = MAIN.CADReportID ";
            query += " LEFT JOIN tblCADNatureOfTask SUB1 ON SUB1.ID = MAIN.NatureID ";
            query += " LEFT JOIN tblCADStatus SUB2 ON SUB2.ID = MAIN.StatusID ";
            query += " LEFT JOIN tblProjects SUB3 ON SUB3.ProposalID = SUB.PNumber ";
            query += " LEFT JOIN tblPFiles SUB4 ON SUB4.PNumber = SUB.PNumber ";
            query += " LEFT JOIN tblStates SUB5 ON SUB4.StateID = SUB5.StateID ";
            query += " LEFT JOIN tblEmployees SUB6 ON SUB6.EmployeeID = SUB4.projectmanagerid ";
            query += " LEFT JOIN tblEmployees SUB7 ON SUB7.EmployeeID = MAIN.ProjectEngineerID ";
            query += " WHERE MAIN.ID IS NOT NULL ";

            if (txtReqByRCDFrom.Text != "" && txtReqByRCDTo.Text != "")
            {
                query += " AND MAIN.ReqRCD >= '" + txtReqByRCDFrom.Text + "' ";
                query += " AND MAIN.ReqRCD <= '" + txtReqByRCDTo.Text + "' ";
            }

            if (txtProjectSendToRCDFrom.Text != "" && txtProjectSendToRCDTo.Text != "")
            {
                query += " AND MAIN.SentRCD >= '" + txtProjectSendToRCDFrom.Text + "' ";
                query += " AND MAIN.SentRCD <= '" + txtProjectSendToRCDTo.Text + "' ";
            }

            if (ddlProjectManagerList.SelectedIndex > 0)
            {
                query += " AND SUB6.EmployeeID = " + ddlProjectManagerList.SelectedValue;
            }

            if (ddlProjectEngineer.SelectedIndex > 0)
            {
                query += " AND SUB7.EmployeeID = " + ddlProjectEngineer.SelectedValue;
            }

            if (ddlProjectList.SelectedIndex > 0)
            {
                query += " AND SUB.PNumber LIKE '%" + ddlProjectList.SelectedValue + "%'";
            }

            if (ddlNatureOfTaskList.SelectedIndex > 0)
            {
                query += " AND SUB1.ID = " + ddlNatureOfTaskList.SelectedValue;
            }

            if (ddlStatusList.SelectedIndex > 0)
            {
                query += " AND SUB2.ID = " + ddlStatusList.SelectedValue;
            }

            query += " ORDER BY SUB7.FirstName, SUB6.FirstName, SUB4.PNumber +', ' + SUB4.ProjectName +', '+ CONCAT(SUB4.City , ', ' + SUB5.[State] , ', ' + SUB4.Country , ', ' + SUB3.JobID) DESC";
            return query;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return "";
    }

    private DataTable ReportDataCrystal()
    {
        DataTable dt = new DataTable();
        try
        {

            string query = PrepareSQLCommandForReport();
            if (query.Length > 1)
            {
                clscon.Return_DT(dt, query);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenerateReportCrystal()
    {
        try
        {
            DataTable dt = ReportDataCrystal();
            rprt.Load(Server.MapPath("~/Reports/rptCADReport.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "CAD Report ";
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "CAD Report ";
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

    #endregion

    #region Reset

    private void Reset()
    {
        try
        {
            txtReqByRCDFrom.Text = string.Empty;
            txtReqByRCDTo.Text = string.Empty;
            txtProjectSendToRCDFrom.Text = string.Empty;
            txtProjectSendToRCDTo.Text = string.Empty;
            ddlNatureOfTaskList.SelectedIndex = 0;
            ddlProjectList.SelectedIndex = 0;
            ddlProjectManagerList.SelectedIndex = 0;
            ddlProjectEngineer.SelectedIndex = 0;
            ddlStatusList.SelectedIndex = 0;
            lblRecordsCount.Visible = false;
            btnExportToExcel.Enabled = true;
            btnExportToPDF.Enabled = true;
            lblRecordsCount.Text = "";
            gvDailyProjectReport.DataSource = "";
            gvDailyProjectReport.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    protected void btnExportToPDF_Click(object sender, EventArgs e)
    {
        try
        {
            GenerateReportCrystal();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    protected void gvDailyProjectReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = DateTime.Now.ToLongDateString();
            HeaderCell.ColumnSpan = 11;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderGridRow.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.BackColor = Color.Green;
            this.gvDailyProjectReport.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }
}