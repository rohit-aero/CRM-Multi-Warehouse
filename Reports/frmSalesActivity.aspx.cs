using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.UI;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Reports_frmSalesActivity : System.Web.UI.Page
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
                //int Month = DateTime.Now.Month + 2;
                txtDateFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
                //txtDateFrom.Text = "01" + "/01/" + DateTime.Now.Year;
                //txtDateTo.Text = Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Year;
                txtDateTo.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
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
        //try
        //{
        //    if (txtDateFrom.Text == "" )
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('" + lblDateFrom.Text + "');", true);
        //        txtDateFrom.Focus();
        //        return false;
        //    }
        //    if (txtDateFrom.Text != "" )
        //    {
        //        if(txtDateTo.Text == "")
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('" + lblDateTo.Text + "');", true);
        //            txtDateTo.Focus();
        //            return false;
        //        }

        //    }

        //}
        //catch (Exception ex)
        //{

        //    Utility.AddEditException(ex);
        //}
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
        DataTable dt = new DataTable();
        try
        {
            String str = "";
            string SQstr = String.Empty;
            string Qstr = String.Empty;
            string NQstr = String.Empty;
            string FQstr = String.Empty;

            for (int i = 0; i <= chkProjectStage.Items.Count - 1; i++)
            {
                if (chkProjectStage.Items[i].Selected)
                {
                    if (str == "")
                    {
                        str = chkProjectStage.Items[i].Text;
                        SQstr += " tblBidProject.name LIKE '%" + str + "%' ";
                    }
                    else
                    {
                        str = chkProjectStage.Items[i].Text;
                        SQstr += " OR tblBidProject.name LIKE '%" + str + "%' ";
                    }
                }
            }

            //var selectedValues = chkProjectStage.Items.OfType<ListItem>()
            //    .Where(i => i.Selected)
            //    .Select(i => i.Value)
            //    .ToList();

            //bool hasMinusOne = selectedValues.Contains("1001");
            //bool hasMinusTwo = selectedValues.Contains("1002");
            //bool hasMinusThree = selectedValues.Contains("1003");

            Qstr += " SELECT PNumber as [P-Number],ISNULL(tblProjects.JobID,'') AS JobID,ProposalDate as [Proposal Date],tblSourceLead.name as [Source Lead], ";
            Qstr += " CASE WHEN tblPFiles.sourceleadid=1 THEN (SourceREf_HOBLIS.[FirstName] + ' ' + ISNULL(SourceREf_HOBLIS.[LastName],'')) ";
            Qstr += " WHEN tblPFiles.sourceleadid=2 THEN ISNULL(tblDealers.CompanyName,'') WHEN tblPFiles.sourceleadid=3 THEN  tblConsultants.CompanyName ";
            Qstr += " WHEN tblPFiles.sourceleadid=4 then  EMP_INHOUSE.FirstName + ' '+ISNULL(EMP_INHOUSE.LastName,'') END AS SourceLeadRef, ISNULL(CONVERT(NVARCHAR,tblProjects.PORec,101),'') as PORec, ";
            Qstr += " tblEmployees.FirstName as [Project Manager],ISNULL(tblPFiles.ProjectName,'') +', '+ ISNULL(tblPFiles.City,'')  +', '+ ISNULL(tblStates.[State],'') as [Project Name], ";
            Qstr += " tblHobartListing.FirstName + ' ' + ISNULL(tblHobartListing.LastName, '') AS [Destination Rep], ";
            //string caseSql = " CASE ";

            //if (hasMinusThree)
            //{
            //    caseSql += " WHEN tblPFiles.conveyorprimespec IN (1) AND tblPFiles.conveyoralternate NOT IN (1) THEN 'Prime Spec Projects without Alternate' ";
            //}

            //if (hasMinusTwo)
            //{
            //    caseSql += " WHEN tblPFiles.conveyorprimespec IN (1) AND tblPFiles.conveyoralternate IN (1) THEN 'Prime Spec Projects with Alternate' ";
            //}

            //if (hasMinusOne)
            //{
            //    caseSql += " WHEN tblPFiles.conveyoralternate IN (1) THEN 'Alternate Specification Projects' ";
            //}

            //// If none of the above were added, or if no matches, fallback to project name
            //caseSql += " ELSE tblBidProject.name END ";
            //Qstr += caseSql;
            Qstr += " tblBidProject.name AS [Project Stage], ISNULL(CONVERT(NVARCHAR, tblPFiles.biddate, 101), '') as [Project Bid Date],  DEAL1.CompanyName AS [Dealer], ";
            Qstr += " ISNULL(CONVERT(NVARCHAR, tblPFiles.shipdate, 101), '') as [Approximate Ship Date],ISNULL(tblPFiles.NetEqPrice,0) + ISNULL(tblPFiles.Freight,0) + ISNULL(tblPFiles.Installation,0) AS NetEqPrice,tblPFilesFollowups.notes, ";
            Qstr += " tblPFilesFollowups.followupdate as followupdate, ";
            Qstr += " ISNULL(CONVERT(NVARCHAR, tblPFilesFollowups.followedupdate, 101), '') as followedupdate,  tblConveyorSpec.[name] AS PrimeSpec,tblConveyorAlternate.[name] AS Alternate, ";
            Qstr += " ISNULL(CONVERT(NVARCHAR, tblPFilesFollowups.nextfollowupdate, 101), '') as nextfollowupdate,tblConsultants2.CompanyName AS tblConsultants2 FROM tblPFiles ";
            Qstr += " LEFT JOIN tblProjects ON tblProjects.ProposalID=tblPFiles.PNumber ";
            Qstr += " LEFT JOIN tblSourceLead ON tblSourceLead.id=tblPFiles.sourceleadid ";
            Qstr += " LEFT JOIN tblBidProject ON tblBidProject.id=tblPFiles.bidproject ";
            Qstr += " LEFT JOIN tblConsultants ON tblConsultants.ConsultantID=tblPFiles.sourceleadref ";
            Qstr += " LEFT JOIN tblConsultants tblConsultants2 ON tblConsultants2.ConsultantID=tblPFiles.ConsultantID ";
            Qstr += " LEFT JOIN tblDealers ON tblDealers.DealerID=tblPFiles.sourceleadref ";
            Qstr += " LEFT JOIN tblEmployees AS EMP_INHOUSE ON EMP_INHOUSE.EmployeeID=tblPFiles.sourceleadref ";
            Qstr += " LEFT JOIN tblHobartListing AS SourceREf_HOBLIS ON SourceREf_HOBLIS.RepID=tblPFiles.sourceleadref ";
            Qstr += " LEFT JOIN  tblEmployees ON tblEmployees.EmployeeID=tblPFiles.projectmanagerid ";
            Qstr += " LEFT JOIN tblHobartListing ON tblHobartListing.RepID=tblPFiles.RepID ";
            Qstr += " LEFT JOIN tblDealers DEAL1 ON DEAL1.DealerID=tblPFiles.DealerID ";
            Qstr += " LEFT JOIN tblStates ON tblStates.StateID=tblPFiles.StateID ";
            Qstr += " INNER JOIN tblPFilesFollowups ON tblPFilesFollowups.ProposalNo=tblPFiles.PNumber ";
            Qstr += " LEFT JOIN tblConveyorSpec ON tblConveyorSpec.id=tblPFiles.conveyorprimespec ";
            Qstr += " LEFT JOIN tblConveyorAlternate ON tblConveyorAlternate.id=tblPFiles.conveyoralternate ";
            Qstr += " WHERE tblPFiles.projectmanagerid <> 0  AND (tblPFilesFollowups.showninreports  IS NULL  ";

            if (ddlShownInReports.SelectedValue == "1")
            {
                Qstr += " OR tblPFilesFollowups.showninreports=1) ";
            }
            else if (ddlShownInReports.SelectedValue == "2")
            {
                Qstr += " OR tblPFilesFollowups.showninreports=0) ";
            }
            else
            {
                Qstr += " OR tblPFilesFollowups.showninreports in (0,1)) ";
            }

            if (ddlProjectManagers.SelectedIndex > 0)
            {
                Qstr += " AND tblPFiles.projectmanagerid='" + ddlProjectManagers.SelectedValue + "' ";
            }

            if (ddlDateType.SelectedValue == "0")
            {
                if (txtDateFrom.Text != "")
                {
                    Qstr += " AND tblPFilesFollowups.followupdate >='" + txtDateFrom.Text + "'  ";
                }
                if (txtDateTo.Text != "")
                {
                    Qstr += " AND tblPFilesFollowups.followupdate <='" + txtDateTo.Text + "'  ";
                }
            }
            else
            {
                if (txtDateFrom.Text != "")
                {
                    Qstr += " AND tblPFiles.ProposalDate >='" + txtDateFrom.Text + "'  ";
                }
                if (txtDateTo.Text != "")
                {
                    Qstr += " AND tblPFiles.ProposalDate <='" + txtDateTo.Text + "'  ";
                }
            }

            if (ddlDestRep.SelectedIndex > 0)
            {
                Qstr += " AND tblPFiles.RepID='" + ddlDestRep.SelectedValue + "' ";
            }
            if (ddlState.SelectedIndex > 0)
            {
                Qstr += " AND tblPFiles.StateID='" + ddlState.SelectedValue + "' ";
            }

            //string checkboxConditions = "";

            //if (hasMinusThree)
            //{
            //    checkboxConditions += "tblPFiles.conveyorprimespec IN (1) ";

            //    if (!hasMinusOne && !hasMinusTwo)
            //    {
            //        checkboxConditions += "AND tblPFiles.conveyoralternate NOT IN (1) ";
            //    }
            //}
            //else
            //{
            //    if (hasMinusTwo)
            //    {
            //        checkboxConditions += "tblPFiles.conveyorprimespec IN (1) AND tblPFiles.conveyoralternate IN (1) ";
            //    }
            //    else if (hasMinusOne)
            //    {
            //        checkboxConditions += "tblPFiles.conveyoralternate IN (1) ";
            //    }
            //}

            //// Now build Qstr properly
            //if (checkboxConditions != "")
            //{
            //    checkboxConditions = "(" + checkboxConditions.Trim() + ")";
            //}

            //if (checkboxConditions != "" && SQstr != "")
            //{
            //    Qstr += " AND (" + checkboxConditions + " OR (" + SQstr + "))";
            //}
            //else if (checkboxConditions != "")
            //{
            //    Qstr += " AND " + checkboxConditions;
            //}
            //else if (SQstr != "")
            //{
            //    Qstr += " AND (" + SQstr + ")";
            //}

            if (SQstr != "")
            {
                Qstr += " AND (" + SQstr + ")";
            }

            Qstr += " UNION   SELECT PNumber as [P-Number],ISNULL(tblProjects.JobID,'') AS JobID,ProposalDate as [Proposal Date],";
            Qstr += " tblSourceLead.name as [Source Lead],  CASE WHEN tblPFiles.sourceleadid=1 THEN (SourceREf_HOBLIS.[FirstName] + ' ' + ISNULL(SourceREf_HOBLIS.[LastName],'')) ";
            Qstr += "  WHEN tblPFiles.sourceleadid=2 THEN ISNULL(tblDealers.CompanyName,'')   WHEN tblPFiles.sourceleadid=3 THEN  tblConsultants.CompanyName  ";
            Qstr += "  WHEN tblPFiles.sourceleadid=4 then  EMP_INHOUSE.FirstName + ' '+ISNULL(EMP_INHOUSE.LastName,'') END AS SourceLeadRef, ISNULL(CONVERT(NVARCHAR,tblProjects.PORec,101),'') as PORec, ";
            Qstr += " tblEmployees.FirstName as [Project Manager], ISNULL(tblPFiles.ProjectName,'') +', '+ ISNULL(tblPFiles.City,'')  +', '+ ISNULL(tblStates.[State],'') as [Project Name], ";
            Qstr += " tblHobartListing.FirstName + ' ' + ISNULL(tblHobartListing.LastName, '') AS[Destination Rep], ";
            //Qstr += caseSql;
            Qstr += " tblBidProject.name AS [Project Stage], ISNULL(CONVERT(NVARCHAR, tblPFiles.biddate, 101), '') as [Project Bid Date], DEAL1.CompanyName AS [Dealer],  ISNULL(CONVERT(NVARCHAR, tblPFiles.shipdate, 101), '') as [Approximate Ship Date],ISNULL(tblPFiles.NetEqPrice,0) + ISNULL(tblPFiles.Freight,0) + ISNULL(tblPFiles.Installation,0) AS NetEqPrice,tblPFilesFollowups.notes,  tblPFilesFollowups.followupdate as followupdate,";
            Qstr += " ISNULL(CONVERT(NVARCHAR, tblPFilesFollowups.followedupdate, 101), '') as followedupdate,  tblConveyorSpec.[name] AS PrimeSpec,tblConveyorAlternate.[name] AS Alternate,   ISNULL(CONVERT(NVARCHAR, tblPFilesFollowups.nextfollowupdate, 101), '') as nextfollowupdate, ";
            Qstr += " tblConsultants2.CompanyName AS tblConsultants2 FROM tblPFiles  LEFT JOIN tblProjects ON tblProjects.ProposalID=tblPFiles.PNumber LEFT JOIN tblSourceLead ON tblSourceLead.id=tblPFiles.sourceleadid  ";
            Qstr += "  LEFT JOIN tblBidProject ON tblBidProject.id=tblPFiles.bidproject  LEFT JOIN tblConsultants ON tblConsultants.ConsultantID=tblPFiles.sourceleadref    LEFT JOIN tblConsultants tblConsultants2 ON tblConsultants2.ConsultantID=tblPFiles.ConsultantID  ";
            Qstr += "  LEFT JOIN tblDealers ON tblDealers.DealerID=tblPFiles.sourceleadref LEFT JOIN tblEmployees AS EMP_INHOUSE ON EMP_INHOUSE.EmployeeID=tblPFiles.sourceleadref LEFT JOIN tblHobartListing AS SourceREf_HOBLIS ON SourceREf_HOBLIS.RepID=tblPFiles.sourceleadref LEFT JOIN  tblEmployees ON tblEmployees.EmployeeID=tblPFiles.projectmanagerid ";
            Qstr += "  LEFT JOIN tblHobartListing ON tblHobartListing.RepID=tblPFiles.RepID  LEFT JOIN tblDealers DEAL1 ON DEAL1.DealerID=tblPFiles.DealerID LEFT JOIN tblStates ON tblStates.StateID=tblPFiles.StateID INNER JOIN tblPFilesFollowups ON tblPFilesFollowups.ProposalNo=tblPFiles.PNumber ";
            Qstr += " LEFT JOIN tblConveyorSpec ON tblConveyorSpec.id=tblPFiles.conveyorprimespec  LEFT JOIN tblConveyorAlternate ON tblConveyorAlternate.id=tblPFiles.conveyoralternate  WHERE (tblPFilesFollowups.showninreports  IS NULL ";

            if (ddlShownInReports.SelectedValue == "1")
            {
                Qstr += " OR tblPFilesFollowups.showninreports=1) ";
            }
            else if (ddlShownInReports.SelectedValue == "2")
            {
                Qstr += " OR tblPFilesFollowups.showninreports=0) ";
            }
            else
            {
                Qstr += " OR tblPFilesFollowups.showninreports in (0,1)) ";
            }

            //checkboxConditions = "";

            //if (hasMinusThree)
            //{
            //    checkboxConditions += "tblPFiles.conveyorprimespec IN (1) ";

            //    if (!hasMinusOne && !hasMinusTwo)
            //    {
            //        checkboxConditions += "AND tblPFiles.conveyoralternate NOT IN (1) ";
            //    }
            //}
            //else
            //{
            //    if (hasMinusTwo)
            //    {
            //        checkboxConditions += "tblPFiles.conveyorprimespec IN (1) AND tblPFiles.conveyoralternate IN (1) ";
            //    }
            //    else if (hasMinusOne)
            //    {
            //        checkboxConditions += "tblPFiles.conveyoralternate IN (1) ";
            //    }
            //}

            //// Now build Qstr properly
            //if (checkboxConditions != "")
            //{
            //    checkboxConditions = "(" + checkboxConditions.Trim() + ")";
            //}

            //if (checkboxConditions != "" && SQstr != "")
            //{
            //    Qstr += " AND (" + checkboxConditions + " OR (" + SQstr + "))";
            //}
            //else if (checkboxConditions != "")
            //{
            //    Qstr += " AND " + checkboxConditions;
            //}
            //else if (SQstr != "")
            //{
            //    Qstr += " AND (" + SQstr + ")";
            //}

            if (SQstr != "")
            {
                Qstr += " AND (" + SQstr + ")";
            }

            Qstr += "    AND tblPFiles.PNumber IN ( SELECT PNumber as [P-Number] FROM tblPFiles  ";
            Qstr += " LEFT JOIN tblProjects ON tblProjects.ProposalID=tblPFiles.PNumber LEFT JOIN tblSourceLead ON tblSourceLead.id=tblPFiles.sourceleadid  LEFT JOIN tblBidProject ON tblBidProject.id=tblPFiles.bidproject LEFT JOIN tblConsultants ON tblConsultants.ConsultantID=tblPFiles.sourceleadref  LEFT JOIN tblConsultants tblConsultants2 ON tblConsultants2.ConsultantID=tblPFiles.ConsultantID  LEFT JOIN tblDealers ON tblDealers.DealerID=tblPFiles.sourceleadref ";
            Qstr += "  LEFT JOIN tblEmployees AS EMP_INHOUSE ON EMP_INHOUSE.EmployeeID=tblPFiles.sourceleadref   LEFT JOIN tblHobartListing AS SourceREf_HOBLIS ON SourceREf_HOBLIS.RepID=tblPFiles.sourceleadref LEFT JOIN  tblEmployees ON tblEmployees.EmployeeID=tblPFiles.projectmanagerid  LEFT JOIN tblHobartListing ON tblHobartListing.RepID=tblPFiles.RepID  LEFT JOIN tblDealers DEAL1 ON DEAL1.DealerID=tblPFiles.DealerID ";
            Qstr += "  LEFT JOIN tblStates ON tblStates.StateID=tblPFiles.StateID INNER JOIN tblPFilesFollowups ON tblPFilesFollowups.ProposalNo=tblPFiles.PNumber LEFT JOIN tblConveyorSpec ON tblConveyorSpec.id=tblPFiles.conveyorprimespec   LEFT JOIN tblConveyorAlternate ON tblConveyorAlternate.id=tblPFiles.conveyoralternate WHERE tblPFiles.projectmanagerid <> 0";
            if (ddlProjectManagers.SelectedIndex > 0)
            {
                Qstr += " AND tblPFiles.projectmanagerid='" + ddlProjectManagers.SelectedValue + "' ";
            }

            if (ddlDateType.SelectedValue == "0")
            {
                if (txtDateFrom.Text != "")
                {
                    Qstr += " AND tblPFilesFollowups.followupdate >='" + txtDateFrom.Text + "'  ";
                }
                if (txtDateTo.Text != "")
                {
                    Qstr += " AND tblPFilesFollowups.followupdate <='" + txtDateTo.Text + "'  ";
                }
            }
            else
            {
                if (txtDateFrom.Text != "")
                {
                    Qstr += " AND tblPFiles.ProposalDate >='" + txtDateFrom.Text + "'  ";
                }
                if (txtDateTo.Text != "")
                {
                    Qstr += " AND tblPFiles.ProposalDate <='" + txtDateTo.Text + "'  ";
                }
            }
            if (ddlDestRep.SelectedIndex > 0)
            {
                Qstr += " AND tblPFiles.RepID='" + ddlDestRep.SelectedValue + "' ";
            }
            if (ddlState.SelectedIndex > 0)
            {
                Qstr += " AND tblPFiles.StateID='" + ddlState.SelectedValue + "' ";
            }

            //Qstr += ") ORDER BY " + caseSql;
            Qstr += ") ORDER BY tblBidProject.name";
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
                rprt.Load(Server.MapPath("~/Reports/rptOpenProposalSales.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                    {
                        txtheader.Text = "Sales Followup From " + txtDateFrom.Text + " to " + txtDateTo.Text;
                    }
                    else
                    {
                        txtheader.Text = "Sales Followup Report ";
                    }
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                    {
                        txtheader.Text = "Sales Followup From " + txtDateFrom.Text + " to " + txtDateTo.Text;
                    }
                    else
                    {
                        txtheader.Text = "Sales Followup Report ";
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
                rprt.Load(Server.MapPath("~/Reports/rptOpenProposalSales.rpt"));

                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                    {
                        txtheader.Text = "Proposals Followup From " + txtDateFrom.Text + " to " + txtDateTo.Text;
                    }
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
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

    private DataTable ReportDataNextFollowupDate()
    {
        DataTable dt = new DataTable();
        try
        {
            string Qstr = String.Empty;
            string NQstr = String.Empty;
            string FQstr = String.Empty;
            Qstr += "SELECT PNumber as [P-Number],ProposalDate as [Proposal Date],tblSourceLead.name as [Source Lead], ";
            Qstr += " tblEmployees.FirstName as [Project Manager],tblPFiles.PNumber, tblPFiles.ProjectName +', '+ ISNULL(tblPFiles.City,'') + ', '+ ISNULL(tblStates.[State],'') + ', ' ";
            Qstr += "  + ISNULL(tblPFiles.Country,'') AS ProjectName, ";
            Qstr += " tblHobartListing.FirstName + ' ' + ISNULL(tblHobartListing.LastName, '') AS[Destination Rep],tblBidProject.name as [Project Stage], ";
            Qstr += " ISNULL(CONVERT(NVARCHAR, tblPFiles.biddate, 101), '') as [Project Bid Date], ";
            Qstr += " ISNULL(CONVERT(NVARCHAR, tblPFiles.shipdate, 101), '') as [Approximate Ship Date], ";
            Qstr += " ISNULL(tblPFiles.NetEqPrice,0) + ISNULL(tblPFiles.Freight,0) + ISNULL(tblPFiles.Installation,0) AS NetEqPrice,tblDealers.CompanyName AS DealerName,tblStates.[State] AS ProposalState,tblPFilesFollowups.nextfollowupdate  FROM tblPFiles LEFT JOIN tblStates ON tblStates.StateID=tblPFiles.StateID LEFT JOIN tblSourceLead ON tblSourceLead.id = tblPFiles.sourceleadid ";

            Qstr += " LEFT JOIN tblBidProject ON tblBidProject.id = tblPFiles.bidproject ";
            Qstr += "LEFT JOIN  tblEmployees ON tblEmployees.EmployeeID = tblPFiles.projectmanagerid ";
            Qstr += " LEFT JOIN tblHobartListing ON tblHobartListing.RepID = tblPFiles.RepID LEFT JOIN tblDealers ON tblDealers.DealerID=tblPFiles.DealerID LEFT JOIN tblPFilesFollowups ON tblPFilesFollowups.ProposalNo=tblPFiles.PNumber WHERE tblPFiles.PNUMBER IS NOT NULL   ";
            if (ddlProjectManagers.SelectedIndex > 0)
            {
                Qstr += " AND tblPFiles.projectmanagerid='" + ddlProjectManagers.SelectedValue + "' ";
            }

            if (txtDateFrom.Text != "")
            {
                Qstr += " AND tblPFilesFollowups.nextfollowupdate >='" + txtDateFrom.Text + "'  ";
            }
            if (txtDateTo.Text != "")
            {
                Qstr += " AND tblPFilesFollowups.nextfollowupdate <='" + txtDateTo.Text + "'  ";
            }

            FQstr += Qstr + NQstr;
            clscon.Return_DT(dt, FQstr);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void Bind_ReportNextFollowup()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                DataTable dt = ReportDataNextFollowupDate();
                rprt.Load(Server.MapPath("~/Reports/rptOpenProposalupcomingfolledups.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                    {
                        txtheader.Text = "Upcoming Followups From " + txtDateFrom.Text + " to " + txtDateTo.Text;
                    }
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
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

    private void Bind_ReportNextFollowupExcel()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                DataTable dt = ReportData();
                rprt.Load(Server.MapPath("~/Reports/rptOpenProposalupcomingfolledups.rpt"));

                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                    {
                        txtheader.Text = "Followed Up From " + txtDateFrom.Text + " to " + txtDateTo.Text;
                    }
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
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
            if (rdbType.SelectedValue == "1")
            {
                Bind_Report();
            }
            else if (rdbType.SelectedValue == "2")
            {
                Bind_ReportNextFollowup();
            }
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
            chkProjectStage.ClearSelection();
            //ddlProjectStage.SelectedIndex = 0;
            //txtAppShpDateFrom.Text = String.Empty;
            //txtAppShipDateTo.Text = String.Empty;            
            txtDateFrom.Text = String.Empty;
            txtDateTo.Text = String.Empty;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSearchProposalExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlDateType.SelectedValue == "0")
            {
                Bind_ReportExcel();
            }
            else if (ddlDateType.SelectedValue == "1")
            {
                Bind_ReportNextFollowupExcel();
            }
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}