using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
public partial class Reports_frmOpenProposals : System.Web.UI.Page
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
                Bind_Controls();
                int Month = DateTime.Now.Month + 2;
                txtProposalShipDateFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
                txtProposalShipDateTo.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
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
            if (txtProposalShipDateFrom.Text == "" && txtProposalShipDateTo.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Proposal Ship Date From. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Proposal Ship Date From. !!");
                txtProposalShipDateFrom.Focus();
                return false;
            }
            if (txtProposalShipDateFrom.Text != "")
            {
                if (txtProposalShipDateTo.Text == "")
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
            if (ds.Tables[0].Rows.Count > 0)
            {
                chkProjectStage.DataSource = ds.Tables[0];
                chkProjectStage.DataTextField = "bidname";
                chkProjectStage.DataValueField = "bidid";
                chkProjectStage.DataBind();
                for (int i = 0; i < chkProjectStage.Items.Count; i++)
                {
                    chkProjectStage.Items[i].Selected = true;
                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectManagers, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlDestRep, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlState, ds.Tables[3]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable ReportData()
    {
        int selectedCount = 0;
        DataTable dt = new DataTable();
        try
        {
            String str = "";
            string Qstr = String.Empty;
            string NQstr = String.Empty;
            string FQstr = String.Empty;
            Qstr += " SELECT * FROM (";
            Qstr += "SELECT CONCAT(PNumber, ' ' + tblProjects.JobID) as [P-Number],ProposalDate as [Proposal Date],tblPFilesFollowups.nextfollowupdate as nextfollowupdate,tblSourceLead.name as [Source Lead], ";
            Qstr += " tblEmployees.FirstName as [Project Manager],tblPFiles.PNumber, tblPFiles.ProjectName +', '+ ISNULL(tblPFiles.City,'') + ', '+ ISNULL(tblStates.[State],'') + ', ' ";
            Qstr += " + ISNULL(tblPFiles.Country,'') AS ProjectName,  ";
            Qstr += " tblHobartListing.FirstName + ' ' + ISNULL(tblHobartListing.LastName,'') AS [Destination Rep],tblBidProject.name as [Project Stage], ";
            Qstr += "ISNULL(CONVERT(NVARCHAR,tblPFiles.biddate,101),'') as [Project Bid Date], ";
            Qstr += " ISNULL(CONVERT(NVARCHAR,tblPFiles.shipdate,101),'') as [Approximate Ship Date], ";
            Qstr += " NetEqPrice AS NetEqPrice,tblDealers.CompanyName AS DealerName,tblStates.[State] AS ProposalState,tblPFilesFollowups.notes AS Notes, ";
            Qstr += " tblPFiles.Country AS Country,tblPFilesFollowups.followupdate AS followupdate, tblConveyorSpec.[name] AS [Conveyor Prime Spec],Row_number() OVER ( partition BY PNumber ORDER BY tblPFilesFollowups.followupdate DESC ) AS rownum ";
            Qstr += " FROM tblPFiles ";
            Qstr += " LEFT JOIN tblProjects ON tblProjects.ProposalID=tblPFiles.PNumber ";
            Qstr += " LEFT JOIN tblStates ON tblStates.StateID=tblPFiles.StateID ";
            Qstr += " LEFT JOIN tblSourceLead ON tblSourceLead.id=tblPFiles.sourceleadid ";
            Qstr += " LEFT JOIN tblBidProject ON tblBidProject.id=tblPFiles.bidproject  ";
            Qstr += " LEFT JOIN tblEmployees ON tblEmployees.EmployeeID=tblPFiles.projectmanagerid ";
            Qstr += " LEFT JOIN tblHobartListing ON tblHobartListing.RepID=tblPFiles.RepID ";
            Qstr += " LEFT JOIN tblDealers ON tblDealers.DealerID=tblPFiles.DealerID ";
            Qstr += " LEFT JOIN tblPFilesFollowups ON tblPFilesFollowups.ProposalNo=tblPFiles.PNumber ";
            Qstr += " LEFT JOIN tblConveyorSpec ON tblConveyorSpec.id=tblPFiles.conveyorprimespec ";
            Qstr += " LEFT JOIN tblConveyorAlternate ON tblConveyorAlternate.id=tblPFiles.conveyoralternate ";
            //Qstr += " WHERE tblPFiles.PNUMBER IS NOT NULL AND tblProjects.JobID IS NULL ";
            Qstr += " WHERE tblPFiles.PNUMBER IS NOT NULL AND tblPFilesFollowups.nextfollowupdate IS NOT NULL AND tblEmployees.FirstName IS NOT NULL";

            if (ddlProjectManagers.SelectedIndex > 0)
            {
                Qstr += " AND tblPFiles.projectmanagerid='" + ddlProjectManagers.SelectedValue + "' ";
            }
            if (ddlProjectStage.SelectedIndex > 0)
            {
                Qstr += " AND tblPFiles.bidproject='" + ddlProjectStage.SelectedValue + "' ";
            }
            if (txtProposalShipDateFrom.Text != "")
            {
                Qstr += " AND tblPFilesFollowups.nextfollowupdate >='" + txtProposalShipDateFrom.Text + "'  ";
            }
            if (txtProposalShipDateTo.Text != "")
            {
                Qstr += " AND tblPFilesFollowups.nextfollowupdate <='" + txtProposalShipDateTo.Text + "'  ";
            }
            if (ddlDestRep.SelectedIndex > 0)
            {
                Qstr += " AND tblPFiles.RepID='" + ddlDestRep.SelectedValue + "' ";
            }
            if (ddlState.SelectedIndex > 0)
            {
                Qstr += " AND tblPFiles.StateID='" + ddlState.SelectedValue + "' ";
            }
            // Loop through the items in the CheckBoxList
            foreach (ListItem item in chkProjectStage.Items)
            {
                // Check if the item is selected
                if (item.Selected)
                {
                    selectedCount++;
                }
            }
            for (int i = 0; i <= chkProjectStage.Items.Count - 1; i++)
            {

                if (chkProjectStage.Items[i].Selected)
                {
                    if (str == "")
                    {
                        str = chkProjectStage.Items[i].Text;
                        Qstr += " AND (tblBidProject.name LIKE '%" + str + "%' ";
                    }
                    else
                    {
                        str = chkProjectStage.Items[i].Text;
                        Qstr += " OR tblBidProject.name LIKE '%" + str + "%' ";
                    }
                }
            }

            if ((chkAll.Checked == false || chkAll.Checked == true) && selectedCount > 0)
            {
                Qstr += " )";
            }

            Qstr += " ) T WHERE rownum=1 ORDER BY nextfollowupdate ";
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
            if (ValidationCheck() == true)
            {
                DataTable dt = ReportData();
                rprt.Load(Server.MapPath("~/Reports/rptSchedulefollowup.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtProposalShipDateFrom.Text != "" && txtProposalShipDateTo.Text != "")
                    {
                        txtheader.Text = "Scheduled Followups From " + txtProposalShipDateFrom.Text + " to " + txtProposalShipDateTo.Text;
                    }
                    else
                    {
                        txtheader.Text = "Scheduled Followups";
                    }
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtProposalShipDateFrom.Text != "" && txtProposalShipDateTo.Text != "")
                    {
                        txtheader.Text = "Scheduled Followups From " + txtProposalShipDateFrom.Text + " to " + txtProposalShipDateTo.Text;
                    }
                    else
                    {
                        txtheader.Text = "Scheduled Followups";
                    }
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
                rprt.Load(Server.MapPath("~/Reports/rptSchedulefollowup.rpt"));

                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtProposalShipDateFrom.Text != "" && txtProposalShipDateTo.Text != "")
                    {
                        txtheader.Text = "Scheduled Followups From " + txtProposalShipDateFrom.Text + " To " + txtProposalShipDateTo.Text;
                    }
                    else
                    {
                        txtheader.Text = "Scheduled Followups";
                    }

                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtProposalShipDateFrom.Text != "" && txtProposalShipDateTo.Text != "")
                    {
                        txtheader.Text = "Scheduled Followups From " + txtProposalShipDateFrom.Text + " to " + txtProposalShipDateTo.Text;
                    }
                    else
                    {
                        txtheader.Text = "Scheduled Followups";
                    }
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
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
    }

    protected void btnClearProposal_Click(object sender, EventArgs e)
    {
        try
        {
            ddlProjectManagers.SelectedIndex = 0;
            ddlProjectStage.SelectedIndex = 0;
            chkProjectStage.ClearSelection();
            int Month = DateTime.Now.Month + 2;
            txtProposalShipDateFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            txtProposalShipDateTo.Text = DateTime.Now.AddMonths(2).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.AddMonths(2).Year;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
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
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}