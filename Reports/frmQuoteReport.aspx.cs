using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;

public partial class Reports_frmQuoteReport : System.Web.UI.Page
{
    BLLDailyQuoteReport ObjBLL = new BLLDailyQuoteReport();
    BOLDailyQuoteReport ObjBOL = new BOLDailyQuoteReport();
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
            ObjBOL.Operation = 1;
            DataSet ds = ObjBLL.GetDataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlNature, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlStatus, ds.Tables[1]);
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlAssignedTo, ds.Tables[2]);
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
            if ((!IsNullOrWhiteSpace(txtReqByCustomerFrom.Text) && IsNullOrWhiteSpace(txtReqByCustomerTo.Text)) ||
            (IsNullOrWhiteSpace(txtReqByCustomerFrom.Text) && !IsNullOrWhiteSpace(txtReqByCustomerTo.Text)))
            {
                Utility.ShowMessage_Error(Page, "Please Select Both From And To Req. By Customer Date !");
                return false;
            }

            if ((!IsNullOrWhiteSpace(txtQuoteSentOutFrom.Text) && IsNullOrWhiteSpace(txtQuoteSentOutTo.Text)) ||
            (IsNullOrWhiteSpace(txtQuoteSentOutFrom.Text) && !IsNullOrWhiteSpace(txtQuoteSentOutTo.Text)))
            {
                Utility.ShowMessage_Error(Page, "Please Select Both From And To Quote Sent Out Date !");
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
            if (ddlNature.Items.Count > 0)
            {
                ddlNature.SelectedIndex = 0;
            }

            if (ddlAssignedTo.Items.Count > 0)
            {
                ddlAssignedTo.SelectedIndex = 0;
            }

            if (ddlPriority.Items.Count > 0)
            {
                ddlPriority.SelectedIndex = 0;
            }

            if (ddlStatus.Items.Count > 0)
            {
                ddlStatus.SelectedIndex = 0;
            }

            txtReqByCustomerFrom.Text = string.Empty;
            txtReqByCustomerTo.Text = string.Empty;
            txtQuoteSentOutFrom.Text = string.Empty;
            txtQuoteSentOutTo.Text = string.Empty;
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
            query += " SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SerialNo, tblPFiles.PNumber PNumberCol, ISNULL(tblProjects.JobID, '') AS [JNumber], QS.[Status], ";
            query += " tblPFiles.ProjectName +', '+ ISNULL(tblPFiles.City,'') + ', '+ ISNULL(tblStates.[State],'') + ', ' + ISNULL(tblPFiles.Country, '') AS [ProjectDescription], ";
            query += " tblEmployees.FirstName AS [ProjectManager], QNT.Task AS [NatureOfTask], CONVERT(VARCHAR(10), QRD.ReqByCustomer, 6) AS [ReqByCustomer], ";
            query += " CONVERT(VARCHAR(10), QRD.SentQuoteRequest, 6) AS [SentQuoteRequest], CONVERT(VARCHAR(10), QRD.SentToCustomer, 6) AS [SentToCustomer], ";
            query += " ENG.FirstName AS [ProjectEngineer], QS.SortOrder, QRD.SentToCustomer AS SentToCustomerDate, QRD.[StatusID],tblPFiles.projectmanagerid,ENG.EmployeeID, ";
            query += " QR.PNumber,QRD.NatureID, CASE WHEN QRD.[Priority] = '2' THEN 'URGENT' ELSE 'REGULAR' END AS [Priority], ";
            query += " CASE WHEN DATEDIFF(DAY, SentQuoteRequest, GETDATE()) <= 2 AND SentToCustomer IS NULL THEN 'YELLOW' ";
            query += " WHEN DATEDIFF(DAY, SentQuoteRequest, GETDATE()) > 2 AND SentToCustomer IS NULL THEN 'RED' ELSE 'DEFAULT' END AS ChangeColor, ";
            query += " CASE WHEN SentToCustomer IS NULL AND dbo.Weekdays(SentQuoteRequest, GETDATE()) > 0 THEN dbo.Weekdays(SentQuoteRequest, GETDATE()) ";
            query += " WHEN SentToCustomer IS NULL AND dbo.Weekdays(SentQuoteRequest, GETDATE()) = 0 THEN '' ";
            query += " WHEN SentToCustomer IS NOT NULL THEN dbo.Weekdays(SentQuoteRequest, SentToCustomer) END AS ResponseTime, ";
            query += " QS.Color, QRD.Remarks ";
            query += " FROM tblQuoteReportDetail QRD ";
            query += " LEFT JOIN tblQuoteReport QR ON QR.ID = QRD.QuoteReportID ";
            query += " LEFT JOIN tblQuoteNatureOfTask QNT ON QNT.ID = QRD.NatureID ";
            query += " LEFT JOIN tblQuoteStatus QS ON QS.ID = QRD.StatusID ";
            query += " LEFT JOIN tblProjects ON tblProjects.ProposalID = QR.PNumber ";
            query += " LEFT JOIN tblPFiles ON tblPFiles.PNumber = QR.PNumber ";
            query += " LEFT JOIN tblStates ON tblStates.StateID = tblPFiles.StateID ";
            query += " LEFT JOIN tblEmployees ON tblEmployees.EmployeeID = tblPFiles.projectmanagerid ";
            query += " LEFT JOIN tblEmployees ENG ON ENG.EmployeeID = QRD.ProjectEngineerID ";
            query += " WHERE QRD.ID IS NOT NULL ";

            if (ddlNature.SelectedIndex > 0)
            {
                query += " AND QNT.ID = " + ddlNature.SelectedValue;
            }

            if (ddlAssignedTo.SelectedIndex > 0)
            {
                query += " AND ENG.EmployeeID = " + ddlAssignedTo.SelectedValue;
            }

            if (ddlPriority.SelectedIndex > 0)
            {
                query += " AND QRD.Priority = " + ddlPriority.SelectedValue;
            }

            if (ddlStatus.SelectedIndex > 0)
            {
                query += " AND QS.ID = " + ddlStatus.SelectedValue;
            }

            if (txtReqByCustomerFrom.Text != "" && txtReqByCustomerTo.Text != "")
            {
                query += " AND  QRD.ReqByCustomer >= '" + txtReqByCustomerFrom.Text + "' ";
                query += " AND  QRD.ReqByCustomer <= '" + txtReqByCustomerTo.Text + "' ";
            }

            if (txtQuoteSentOutFrom.Text != "" && txtQuoteSentOutTo.Text != "")
            {
                query += " AND QRD.SentToCustomer >= '" + txtQuoteSentOutFrom.Text + "' ";
                query += " AND QRD.SentToCustomer <= '" + txtQuoteSentOutTo.Text + "' ";
            }

            query += " ORDER BY SortOrder, ProjectEngineer ASC, QRD.SentQuoteRequest ASC ";
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
            rpt.Load(Server.MapPath("~/Reports/rptDailyQuoteReport.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rpt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Quote Task Report";
                rpt.SetDataSource(dt);
                rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rpt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rpt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Quote Task Report";
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