using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
public partial class Reports_frmAeroNesting : System.Web.UI.Page
{
    BOLOpenProposalReports OBJBOL = new BOLOpenProposalReports();
    BLLOpenProposalReportDate OBJBLL = new BLLOpenProposalReportDate();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
           // Bind_Controls();
            int Month = DateTime.Now.Month + 2;
            txtProposalShipDateFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            txtProposalShipDateTo.Text = DateTime.Now.AddMonths(2).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(2).Month) + "/" + DateTime.Now.AddMonths(2).Year;

        }
    }

    private Boolean ValidationCheck()
    {
        try
        {
            if (txtProposalShipDateFrom.Text == "" && txtProposalShipDateTo.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Proposal Ship Date From. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Proposal Ship Date From. !!");
                txtProposalShipDateFrom.Focus();
                return false;
            }
            if (txtProposalShipDateFrom.Text != "" )
            {
                if(txtProposalShipDateTo.Text == "")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Proposal Ship Date To. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Enter Proposal Ship Date To. !!");
                    txtProposalShipDateTo.Focus();
                    return false;
                }                
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
            if(ds.Tables[0].Rows.Count>0)
            {
                //Utility.BindDropDownListAll(ddlProjectStage, ds.Tables[0]);
            }
            if(ds.Tables[1].Rows.Count>0)
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
            string Qstr = String.Empty;
            string NQstr = String.Empty;
            string FQstr = String.Empty;

            Qstr += "SELECT DISTINCT qryNewProjects.JobID, qryNewProjects.ProjectName +', '+ ISNULL(qryNewProjects.City,'') + ', '+ ISNULL(qryNewProjects.[State],'')  AS ProjectName, ";
            Qstr += " ISNULL(qryNewProjects.shipdate, '') as [Approximate Ship Date], qryNewProjects.ReleasedToNesting AS [Nesting Start Date],  ISNULL(CONVERT(NVARCHAR, qryNewProjects.ReleasedToShop, 101), '') as  ";
            Qstr += " [Nesting Completion Date],  CASE WHEN qryNewProjects.NestingStatus IS NULL THEN '' WHEN qryNewProjects.NestingStatus='0' THEN 'Not started'    ";
            Qstr += " WHEN qryNewProjects.NestingStatus='1' THEN 'In Progress' WHEN qryNewProjects.NestingStatus='2' THEN 'Completed'  WHEN qryNewProjects.NestingStatus='3' THEN 'Shipment within 4 weeks' ";
            Qstr += " WHEN qryNewProjects.NestingStatus='4' THEN '(P.O / Drawings) Not Received'  WHEN qryNewProjects.NestingStatus='5' THEN 'On Hold' END AS NestingStatus, ";
            Qstr += " CASE WHEN tblMfgFacility.FacilityName Is Null THEN 'Canada' ELSE tblMfgFacility.FacilityName END AS FacilityName  ";
            Qstr += " FROM tblMfgFacility RIGHT JOIN tblHobartBranchListing INNER JOIN qryShpDrgsSales RIGHT JOIN qryAeroDesigners  ";
            Qstr += " RIGHT JOIN tblStates RIGHT JOIN tblCustomers RIGHT JOIN tblDealers RIGHT JOIN qryNewProjects ON tblDealers.DealerID = qryNewProjects.DealerID ";
            Qstr += " ON tblCustomers.CustomerID = qryNewProjects.CustomerID ON tblStates.StateID = tblCustomers.StateID ON qryAeroDesigners.EmployeeID = qryNewProjects.ProjectDesignerID ";
            Qstr += " LEFT JOIN tblEmployees ON qryAeroDesigners.EmployeeID = tblEmployees.EmployeeID  ";
            Qstr += " LEFT JOIN tblEmployees AS tblEmployees_1 ON qryNewProjects.ReviewedBy = tblEmployees_1.EmployeeID  ";
            Qstr += " LEFT JOIN tblConveyorModel ON qryNewProjects.ModelID = tblConveyorModel.ModelID ON qryShpDrgsSales.sDrgJid = qryNewProjects.JobID  ";
            Qstr += " INNER JOIN tblHobartListing ON qryNewProjects.RepID = tblHobartListing.RepID ON tblHobartBranchListing.BranchID = tblHobartListing.BranchID  ";
            Qstr += " ON tblMfgFacility.ID = qryNewProjects.MfgFacilityID ";
            Qstr += " WHERE qryNewProjects.JobID  IS NOT NULL ";
           
            if (ddlNestingStatus.SelectedIndex > 0)
            {
                Qstr += " AND qryNewProjects.NestingStatus='" + ddlNestingStatus.SelectedValue + "' ";
            }
            if (txtProposalShipDateFrom.Text != "")
            {
                Qstr += " AND qryNewProjects.shipdate >='" + txtProposalShipDateFrom.Text + "'  ";
            }
            if (txtProposalShipDateTo.Text != "")
            {
                Qstr += " AND qryNewProjects.shipdate <='" + txtProposalShipDateTo.Text + "'  ";
            }
            Qstr += " ORDER BY [Approximate Ship Date] "; 
            FQstr += Qstr + NQstr;
            clscon.Return_DT(dt, FQstr);

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
            if(ValidationCheck()==true)
            {
                
                DataTable dt = ReportData();
                rprt.Load(Server.MapPath("~/Reports/rptNesting.rpt"));
                
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtProposalShipDateFrom.Text != "" && txtProposalShipDateTo.Text != "")
                    {
                        txtheader.Text = "Nesting Report From " + txtProposalShipDateFrom.Text + " to " + txtProposalShipDateTo.Text;
                    }                   
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    //Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Nesting Report From " + txtProposalShipDateFrom.Text + " to " + txtProposalShipDateTo.Text;
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

    private void Bind_ReportExcel()
    {
        try
        {
            if (ValidationCheck() == true)
            {

                DataTable dt = ReportData();
                rprt.Load(Server.MapPath("~/Reports/rptNesting.rpt"));

                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtProposalShipDateFrom.Text != "" && txtProposalShipDateTo.Text != "")
                    {
                        txtheader.Text = "Nesting Report From " + txtProposalShipDateFrom.Text + " To " + txtProposalShipDateTo.Text;
                    }
                    
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
                }
                else
                {
                    //Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Nesting Report From " + txtProposalShipDateFrom.Text + " To " + txtProposalShipDateTo.Text;
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
            ddlNestingStatus.SelectedIndex = 0;                       
            int Month = DateTime.Now.Month + 2;
            txtProposalShipDateFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            txtProposalShipDateTo.Text = DateTime.Now.AddMonths(2).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.AddMonths(2).Year;
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
}