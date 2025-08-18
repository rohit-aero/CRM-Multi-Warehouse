using System;
using System.Web.UI;
using BOLAERO;
using BLLAERO;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

public partial class Reports_frmcustomercaretickets : System.Web.UI.Page
{
    BOLCustCareTickets ObjBOL = new BOLCustCareTickets();
    BLLCustCareTickets ObjBLL = new BLLCustCareTickets();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Controls();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlCategory, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlIssueCategory, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlStatus, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlSubAssembly, ds.Tables[4]);
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlAssignedto, ds.Tables[6]);
            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlConveyorType, ds.Tables[7]);
            }
            if (ds.Tables[8].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectNameList, ds.Tables[8]);
            }
            if (ds.Tables[9].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectManager, ds.Tables[9]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable Bind_Grid()
    {
        DataTable dt = new DataTable();
        try
        {
            string Qstr = PrepareSQLCommandForSearch();
            clscon.Return_DT(dt, Qstr);
            if (dt.Rows.Count > 0)
            {
                dt.Columns.RemoveAt(0);
                gvSummary.DataSource = dt;
                gvSummary.DataBind();
                //  gvSummary.Columns[0].Visible = false;
                hfjobname.Value = dt.Rows[0]["Project Name"].ToString();
                btnExportToExcel.Enabled = true;
            }
            else
            {
                gvSummary.DataSource = "";
                gvSummary.DataBind();
                hfjobname.Value = String.Empty;
                btnExportToExcel.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }

    private void ExporttoExcel()
    {
        try
        {
            DataTable dt = Bind_Grid();
            if (dt.Rows.Count > 0)
            {
                Utility.ExportToExcelDT(dt, "Customercare Tickets");
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
            DataTable dt = Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Reset()
    {
        try
        {
            ddlProjectNameList.SelectedIndex = 0;
            ddlProjectManager.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;
            ddlIssueCategory.SelectedIndex = 0;
            ddlSubAssembly.SelectedIndex = 0;
            ddlAssignedto.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            ddlConveyorType.SelectedIndex = 0;
            txtfromdate.Text = String.Empty;
            txttodate.Text = String.Empty;
            txtPO.Text = String.Empty;
            txtTicketNo.Text = String.Empty;
            gvSummary.DataSource = "";
            gvSummary.DataBind();
            btnExportToExcel.Enabled = false;
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
            Reset();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            ExporttoExcel();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public void btnGenrate_Click(object sender, EventArgs e)
    {
        try
        {
            if (true)
            {
                Get_CustomerCareTicketReport();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private string PrepareSQLCommandForSearch()
    {
        try
        {
            string Qstr = String.Empty;
            Qstr += " SELECT * FROM ( ";
            Qstr += " Select ROW_NUMBER () over (PARTITION BY TicketID order by CCT_TicketDetails.summarydate DESC) as DenseRank, ";
            Qstr += " CONCAT(tblProjects.JobID + ', ', tblCustomers.CompanyName +', ', tblCustomers.City  +', ', tblStates.[State] +', ' , ";
            Qstr += " tblCountries.Country) AS [Project Name],  TicketNo as [Ticket No], ";
            Qstr += " CASE WHEN CCT_Ticket.CategoryID != 3 THEN CCT_Category.[name] ELSE CCT_Ticket.CategoryOther END AS [Category], ";
            Qstr += " CASE WHEN CCT_Ticket.IssueCategoryID != 14 THEN CCT_IssueCategory.[name] ELSE IssueCategoryOther END AS [Issue Category], ";
            Qstr += " CONVERT(varchar, OpenDate,1) as [Open Date], CONVERT(varchar,CloseDate,1) as [Close Date], CONVERT(varchar,CCT_Ticket.FollowUpDate,1)  as [FollowUp Date], ";
            Qstr += " CASE WHEN CCT_Ticket.SubAssemblyID=18 THEN CCT_Ticket.SubAssemblyOther ELSE CCT_SubAssembly.[name] end as [Sub Assembly],";
            Qstr += " tblConveyorType.ConveyorType as [Conveyor Type],CCT_Status.[name] as [Status], tblEmployees.FirstName as [Assigned To],CCT_Ticket.ServicePO as [Service PO], ";
            Qstr += " Task,CONVERT(varchar,CCT_TicketDetails.summarydate,1) as [Summary Date], summary as [Summary] ";
            Qstr += " from CCT_Ticket LEFT JOIN CCT_TicketDetails ON CCT_TicketDetails.TicketID=CCT_Ticket.id ";
            Qstr += " LEFT JOIN CCT_Category ON CCT_Category.id=CCT_Ticket.CategoryID ";
            Qstr += " LEFT JOIN CCT_IssueCategory ON CCT_IssueCategory.id=CCT_Ticket.IssueCategoryID ";
            Qstr += " LEFT JOIN CCT_IssueReportedBy  ON CCT_IssueReportedBy.id=CCT_Ticket.IssueCategoryID ";
            Qstr += " LEFT JOIN CCT_SubAssembly ON CCT_SubAssembly.id=CCT_Ticket.SubAssemblyID ";
            Qstr += " LEFT JOIN tblProjects ON tblProjects.JobID=CCT_Ticket.JobID LEFT join tblPFiles on tblPFiles.PNumber=tblProjects.ProposalID ";
            Qstr += " LEFT JOIN tblConveyorType ON tblConveyorType.ConveyorTypeID=tblPFiles.ConveyorTypeID ";
            Qstr += " left join CCT_Status on CCT_Status.id=CCT_Ticket.StatusID ";
            Qstr += " left join tblEmployees on CCT_Ticket.AssignedTo=tblEmployees.EmployeeID ";
            Qstr += " INNER JOIN tblCustomers ON tblCustomers.CustomerID=tblProjects.CustomerID ";
            Qstr += " LEFT JOIN tblCountries ON tblCustomers.CountryID=tblCountries.CountryID ";
            Qstr += " LEFT JOIN tblStates ON tblCustomers.StateID=tblStates.StateID  where TicketNo IS NOT NULL   ";
            if (ddlProjectNameList.SelectedIndex > 0)
            {
                Qstr += " AND tblProjects.JobID  LIKE '%" + ddlProjectNameList.SelectedValue.Split(',')[0] + "%' ";
            }
            if (txtTicketNo.Text != "")
            {
                Qstr += " AND CCT_Ticket.TicketNo = '" + txtTicketNo.Text + "' ";
            }
            if (ddlCategory.SelectedIndex > 0)
            {
                Qstr += " AND CCT_Ticket.CategoryID = '" + ddlCategory.SelectedValue + "' ";
            }
            if (ddlIssueCategory.SelectedIndex > 0)
            {
                Qstr += " AND CCT_Ticket.IssueCategoryID = '" + ddlIssueCategory.SelectedValue + "' ";
            }
            if (ddlAssignedto.SelectedIndex > 0)
            {
                Qstr += " AND CCT_Ticket.AssignedTo= '" + ddlAssignedto.SelectedValue + "' ";
            }
            if (ddlSubAssembly.SelectedIndex > 0)
            {
                Qstr += " AND CCT_Ticket.SubAssemblyID= '" + ddlSubAssembly.SelectedValue + "' ";
            }
            if (ddlConveyorType.SelectedIndex > 0)
            {
                Qstr += " AND tblPFiles.ConveyorTypeID= '" + ddlConveyorType.SelectedValue + "' ";
            }
            if (ddlStatus.SelectedIndex > 0)
            {
                Qstr += " AND CCT_Ticket.StatusID = '" + ddlStatus.SelectedValue + "' ";
            }
            if (txtfromdate.Text != "" && txttodate.Text != "")
            {
                if (txtfromdate.Text != "")
                {
                    Qstr += " AND CCT_Ticket.OpenDate >= '" + txtfromdate.Text + "' ";
                }
                if (txttodate.Text != "")
                {
                    Qstr += " AND CCT_Ticket.OpenDate <= '" + txttodate.Text + "' ";
                }
            }
            if (txtPO.Text != "")
            {
                Qstr += " AND CCT_Ticket.ServicePO  LIKE '%" + txtPO.Text + "%' ";
            }
            if (ddlProjectManager.SelectedIndex > 0)
            {
                Qstr += " AND tblPFiles.projectmanagerid = " + ddlProjectManager.SelectedValue;
            }
            Qstr += " ) T  order by [Project Name] ";
            return Qstr;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return "";
    }

    private string PrepareSQLCommandForReport()
    {
        try
        {
            string Qstr = String.Empty;
            Qstr += " SELECT * FROM ( ";
            Qstr += " Select ROW_NUMBER () over (PARTITION BY TicketID order by CCT_TicketDetails.summarydate DESC) as DenseRank, ";
            Qstr += " tblProjects.JobID, CONCAT(tblProjects.JobID + ', ', tblCustomers.CompanyName +', ', tblCustomers.City  +', ', tblStates.[State] +', ' , ";
            Qstr += " tblCountries.Country) AS [Project Name],  TicketNo as [Ticket No], ";
            Qstr += " CASE WHEN CCT_Ticket.CategoryID != 3 THEN CCT_Category.[name] ELSE CCT_Ticket.CategoryOther END AS [Category], ";
            Qstr += " ISNULL(UPPER(projectManager.FirstName), '') AS ProjectManager, ";
            //Qstr += " CASE WHEN CCT_Ticket.IssueCategoryID != 14 THEN CCT_IssueCategory.[name] ELSE IssueCategoryOther END AS [Issue Category], ";
            Qstr += " CONVERT(varchar, OpenDate,101) as [Open Date], CONVERT(varchar,CloseDate,101) as [Close Date], CONVERT(varchar,CCT_Ticket.FollowUpDate,101)  as [FollowUp Date], ";
            Qstr += " CASE WHEN CCT_Ticket.SubAssemblyID=18 THEN CCT_Ticket.SubAssemblyOther ELSE CCT_SubAssembly.[name] end as [Sub Assembly],";
            Qstr += " tblConveyorType.ConveyorType as [Conveyor Type],CCT_Status.[name] as [Status], tblEmployees.FirstName as [Assigned To],CCT_Ticket.ServicePO as [Service PO], ";
            Qstr += " Task,CONVERT(varchar,CCT_TicketDetails.summarydate,101) as [Summary Date], summary as [Summary] ";
            Qstr += " from CCT_Ticket LEFT JOIN CCT_TicketDetails on CCT_Ticket.id = CCT_TicketDetails.TicketID ";
            Qstr += " LEFT JOIN CCT_Category ON CCT_Category.id=CCT_Ticket.CategoryID ";
            Qstr += " LEFT JOIN CCT_IssueCategory ON CCT_IssueCategory.id=CCT_Ticket.IssueCategoryID ";
            Qstr += " LEFT JOIN CCT_IssueReportedBy  ON CCT_IssueReportedBy.id=CCT_Ticket.IssueCategoryID ";
            Qstr += " LEFT JOIN CCT_SubAssembly ON CCT_SubAssembly.id=CCT_Ticket.SubAssemblyID ";
            Qstr += " LEFT JOIN tblProjects ON tblProjects.JobID=CCT_Ticket.JobID LEFT join tblPFiles on tblPFiles.PNumber=tblProjects.ProposalID ";
            Qstr += " LEFT JOIN tblConveyorType ON tblConveyorType.ConveyorTypeID=tblPFiles.ConveyorTypeID ";
            Qstr += " left join CCT_Status on CCT_Status.id=CCT_Ticket.StatusID ";
            Qstr += " left join tblEmployees on CCT_Ticket.AssignedTo=tblEmployees.EmployeeID ";
            Qstr += " left join tblEmployees projectManager on tblPFiles.projectmanagerid=projectManager.EmployeeID  ";
            Qstr += " INNER JOIN tblCustomers ON tblCustomers.CustomerID=tblProjects.CustomerID ";
            Qstr += " LEFT JOIN tblCountries ON tblCustomers.CountryID=tblCountries.CountryID ";
            Qstr += " LEFT JOIN tblStates ON tblCustomers.StateID=tblStates.StateID  where TicketNo IS NOT NULL  ";
            if (ddlProjectNameList.SelectedIndex > 0)
            {
                Qstr += " AND tblProjects.JobID  LIKE '%" + ddlProjectNameList.SelectedValue.Split(',')[0] + "%' ";
            }
            if (txtTicketNo.Text != "")
            {
                Qstr += " AND CCT_Ticket.TicketNo = '" + txtTicketNo.Text + "' ";
            }
            if (ddlCategory.SelectedIndex > 0)
            {
                Qstr += " AND CCT_Ticket.CategoryID = '" + ddlCategory.SelectedValue + "' ";
            }
            if (ddlIssueCategory.SelectedIndex > 0)
            {
                Qstr += " AND CCT_Ticket.IssueCategoryID = '" + ddlIssueCategory.SelectedValue + "' ";
            }
            if (ddlAssignedto.SelectedIndex > 0)
            {
                Qstr += " AND CCT_Ticket.AssignedTo= '" + ddlAssignedto.SelectedValue + "' ";
            }
            if (ddlSubAssembly.SelectedIndex > 0)
            {
                Qstr += " AND CCT_Ticket.SubAssemblyID= '" + ddlSubAssembly.SelectedValue + "' ";
            }
            if (ddlConveyorType.SelectedIndex > 0)
            {
                Qstr += " AND tblPFiles.ConveyorTypeID= '" + ddlConveyorType.SelectedValue + "' ";
            }
            if (ddlStatus.SelectedIndex > 0)
            {

                Qstr += " AND CCT_Ticket.StatusID = '" + ddlStatus.SelectedValue + "' ";

            }
            if (txtfromdate.Text != "" && txttodate.Text != "")
            {
                if (txtfromdate.Text != "")
                {
                    Qstr += " AND CCT_Ticket.OpenDate >= '" + txtfromdate.Text + "' ";
                }
                if (txttodate.Text != "")
                {
                    Qstr += " AND CCT_Ticket.OpenDate <= '" + txttodate.Text + "' ";
                }
            }
            if (txtPO.Text != "")
            {
                Qstr += " AND CCT_Ticket.ServicePO  LIKE '%" + txtPO.Text + "%' ";
            }
            if (ddlProjectManager.SelectedIndex > 0)
            {
                Qstr += " AND tblPFiles.projectmanagerid = " + ddlProjectManager.SelectedValue;
            }
            Qstr += " ) T order by [Project Name] ";
            return Qstr;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return "";
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            //divError.Visible = true;
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

    private void Get_CustomerCareTicketReport()
    {
        try
        {
            string HeaderText = "Project Tickets Report ";
            if (txtfromdate.Text != "" && txttodate.Text != "")
            {
                HeaderText += " From " + txtfromdate.Text + " to " + txttodate.Text;
            }
            //divError.Visible = true;
            DataTable dt = ReportData();
            rprt.Load(Server.MapPath("~/Reports/rptCustomerCareTickets.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = HeaderText;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = HeaderText;
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
}