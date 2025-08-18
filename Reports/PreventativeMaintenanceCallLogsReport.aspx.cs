using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_PreventativeMaintenanceCallLogsReport : System.Web.UI.Page
{
    commonclass1 cls = new commonclass1();
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
            txtDateCalledFrom.Text = "01/01/" + DateTime.Now.Year;
            txtDateCalledTo.Text = DateTime.Now.ToShortDateString();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #region Validation

    private bool IsNullOrWhiteSpace(string value)
    {
        return value == null || value.Trim().Length == 0;
    }

    private bool ValidationCheck()
    {
        try
        {
            if ((!IsNullOrWhiteSpace(txtDateCalledFrom.Text) && IsNullOrWhiteSpace(txtDateCalledTo.Text)) ||
            (IsNullOrWhiteSpace(txtDateCalledFrom.Text) && !IsNullOrWhiteSpace(txtDateCalledTo.Text)))
            {
                Utility.ShowMessage_Error(Page, "Please Select Both From And To Date Called !");
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

    private string PrepareQuery()
    {
        string query = string.Empty;
        try
        {
            query += " SELECT h.[ID], h.[JobID], CONCAT(h.[JobID], ', ' + tblCustomers.CompanyName, ', ' + tblCustomers.City, ', ' + tblStates.[State]) AS JobName, ";
            query += " CONVERT(VARCHAR, h.[DateCalled], 101) AS [DateCalled], h.[ContactID], dbo.ProperCase(CONCAT(tblCustMember.FName, ' ' + tblCustMember.LName)) AS ContactName, ";
            query += " h.[CallDetails], h.[Notes], CASE WHEN [PMResponse] = 0 THEN 'NO' WHEN [PMResponse] = 1 THEN 'YES' END AS [PMResponse] ";
            query += " FROM tblPreventativeMaintenanceCallHistory h ";
            query += " INNER JOIN tblProjects ON tblProjects.JobID = h.JobID ";
            query += " LEFT JOIN tblPFiles ON tblPFiles.PNumber = tblProjects.ProposalID ";
            query += " LEFT JOIN tblCustomers ON  tblCustomers.CustomerID = tblProjects.CustomerID ";
            query += " LEFT JOIN tblStates ON tblStates.StateID = tblCustomers.StateID ";
            query += " LEFT JOIN tblCustMember ON tblCustMember.ContactID = h.ContactID ";
            query += " WHERE H.DateCalled IS NOT NULL ";

            if (txtDateCalledFrom.Text.Trim() != "")
            {
                query += " AND h.DateCalled >= '" + txtDateCalledFrom.Text.Trim() + "' ";
            }

            if (txtDateCalledTo.Text.Trim() != "")
            {
                query += " AND h.DateCalled <= '" + txtDateCalledTo.Text.Trim() + "' ";
            }

            if (txtJob.Text.Trim() != "")
            {
                query += " AND (h.JobID LIKE  '%" + txtJob.Text.Trim() + "%') OR (tblCustomers.CompanyName LIKE  '%" + txtJob.Text.Trim() + "%') ";
            }

            query += " ORDER BY h.DateCalled DESC ";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return query;
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = PrepareQuery();
            if (query != "")
            {
                cls.Return_DT(dt, query);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnExportToPDF_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                string header = "Preventative Maintenance Call Logs ";
                if(txtDateCalledFrom.Text != "" && txtDateCalledTo.Text != "")
                {
                    header += " From " + txtDateCalledFrom.Text + " to " + txtDateCalledTo.Text;
                }
                DataTable dt = ReportData();
                rprt.Load(Server.MapPath("~/Reports/rptPreventativeMaintenanceCallLogsReport.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = header;
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    //Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = header;
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

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            SetDates();
            txtJob.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}