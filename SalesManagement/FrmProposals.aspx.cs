using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.Services;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using System.Linq;
//using Outlook = Microsoft.Office.Interop.Outlook;
/// <summary>
///  Proposal Form (30 May 2018) Rohit Kumar
/// </summary>
public partial class SalesManagement_FrmProposals : System.Web.UI.Page
{
    BOLManageProposals ObjBOL = new BOLManageProposals();
    BLLManageProposals ObjBLL = new BLLManageProposals();
    commonclass1 cls = new commonclass1();
    BOLModel ObjBOL1 = new BOLModel();
    BLLModel ObjBLL1 = new BLLModel();
    BOLManageQuotes ObjBOLQuote = new BOLManageQuotes();
    BLLManageQuotesInfo ObjBLLQuote = new BLLManageQuotesInfo();
    //MailAddress from = new MailAddress("aerowerksindia@gmail.com", "Aero-Werks");
    MailAddress from = new MailAddress(Utility.Email(), Utility.EmailDisplayName());
    MailAddress sendtoAshish = new MailAddress("ashish@aero-werks.com", "Ashish");
    MailAddress sendtoPrateek = new MailAddress("prateek@aero-werks.com", "Prateek");
    MailAddress sendtoSunil = new MailAddress("aeroit@aero-werks.com", "Prateek");
    //public Boolean test = false;
    //public DataTable testData;

    string Do_Not_Reply = "[Please do not reply to this message. Replies to this message are routed to an unmonitored mailbox]";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Utility.IsAuthorized())
                {
                    Bind_Controls2();
                    Bind_Models();
                    btnCADReport.Enabled = false;
                    btnSiteVisit.Enabled = false;
                    if (Session["PNumber"] != null)
                    {
                        string pnum = Session["PNumber"].ToString();
                        int index = pnum.IndexOf(',');
                        if (index < 0)
                        {
                            index = 0;
                        }
                        pnum = pnum.Substring(0, index);
                        // txtSearchPNum.Text = pnum;
                        FillPnumber(pnum);
                        FillDetails(pnum);
                        SyncTextbox("NUM", pnum);
                        SyncTextbox("NAME", pnum);
                        HfPNumber.Value = string.Empty;
                        // CNumber = pnum;
                        HfPNumber.Value = pnum;
                        string strMethodName = "getCheckedRadio();";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "text", "getCalc();", true);
                        btnExistingJob.Enabled = true;
                        Fill_ModelDetails();
                    }
                    hfCurrentUser.Value = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
                    try
                    {
                        SpecCredit();
                    }
                    catch (Exception exs)
                    {
                        Utility.AddEditException(exs);
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // Bind all dropdownlist here
    private void Bind_Controls2()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ds = ObjBLL.GetProposals(ObjBOL);
            //ds = Utility.BindProposalData();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Utility.BindDropDownList(ddlState, ds.Tables[0]);
                //Utility.BindDropDownList(ddlStateAb, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCountry, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCurruncy, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                try
                {
                    Utility.BindDropDownList(ddlModel, ds.Tables[3]);
                    if (ddlModel.Items.Count > 0)
                    {
                        ddlModel.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    Utility.AddEditException(ex);
                }

            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConType, ds.Tables[4]);
                if (ddlConType.Items.Count > 0)
                {
                    ddlConType.SelectedIndex = 0;
                }
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDesigner, ds.Tables[5]);
                if (ddlDesigner.Items.Count > 0)
                {
                    ddlDesigner.SelectedIndex = 0;
                }
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConsultantRep, ds.Tables[6]);
                if (ddlConsultantRep.Items.Count > 0)
                {
                    ddlConsultantRep.SelectedIndex = 0;
                }
                Utility.BindDropDownList(ddlOriginationRep, ds.Tables[6]);
                if (ddlOriginationRep.Items.Count > 0)
                {
                    ddlOriginationRep.SelectedIndex = 0;
                }
                Utility.BindDropDownList(ddlDestRep, ds.Tables[6]);
                if (ddlDestRep.Items.Count > 0)
                {
                    ddlDestRep.SelectedIndex = 0;
                }
            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCompetitor, ds.Tables[7]);
                if (ddlCompetitor.Items.Count > 0)
                {
                    ddlCompetitor.SelectedIndex = 0;
                }
                Utility.BindDropDownList(ddlPrimeSpec, ds.Tables[7]);
                if (ddlPrimeSpec.Items.Count > 0)
                {
                    ddlPrimeSpec.SelectedIndex = 0;
                }
                Utility.BindDropDownList(ddlAlternate1, ds.Tables[7]);
                if (ddlAlternate1.Items.Count > 0)
                {
                    ddlAlternate1.SelectedIndex = 0;
                }
                //Utility.BindDropDownList(ddlAlternate2, ds.Tables[7]);
                //Utility.BindDropDownList(ddlAlternate3, ds.Tables[7]);
            }
            if (ds.Tables[8].Rows.Count > 0)
            {
                //Utility.BindDropDownList(ddlOrderProbability, ds.Tables[8]);
            }
            if (ds.Tables[9].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlStatus, ds.Tables[9]);
                if (ddlStatus.Items.Count > 0)
                {
                    ddlStatus.SelectedIndex = 0;
                }
            }
            if (ds.Tables[10].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConsultant, ds.Tables[10]);
                if (ddlConsultant.Items.Count > 0)
                {
                    ddlConsultant.SelectedIndex = 0;
                }
            }
            if (ds.Tables[11].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDealer, ds.Tables[11]);
                if (ddlDealer.Items.Count > 0)
                {
                    ddlDealer.SelectedIndex = 0;
                }
            }
            if (ds.Tables[12].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSpecCredit, ds.Tables[12]);
                if (ddlSpecCredit.Items.Count > 0)
                {
                    ddlSpecCredit.SelectedIndex = 0;
                }
            }
            if (ds.Tables[13].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPreparedBy, ds.Tables[13]);
            }
            if (ds.Tables[14].Rows.Count > 0)
            {
                //cboPName.DataSource = ds.Tables[14];
                //cboPName.DataTextField = "ProjectName";
                //cboPName.DataValueField = "PNumber";
                //cboPName.DataBind();
                //cboPName.Items.Insert(0, new ListItem("", "0"));
                //Utility.BindDropDownList(cboPName, ds.Tables[14]);
            }
            if (ds.Tables[15].Rows.Count > 0)
            {
                //cboPNumber.DataSource = ds.Tables[15];
                //cboPNumber.DataTextField = "ProjectName";
                //cboPNumber.DataValueField = "PNumber";
                //cboPNumber.DataBind();
                //cboPNumber.Items.Insert(0, new ListItem("", "0"));
                //Utility.BindDropDownList(cboPNumber, ds.Tables[15]);
            }
            if (ds.Tables[16].Rows.Count > 0)
            {
                //Utility.BindDropDownList(ddlDishPrimeSpec, ds.Tables[16]);
                //Utility.BindDropDownList(ddlDishAlternate, ds.Tables[16]);
                //Utility.BindDropDownList(ddlWastePrimeSpec, ds.Tables[16]);
                //Utility.BindDropDownList(ddlWasteAlternate, ds.Tables[16]);
                //Utility.BindDropDownList(ddlWasteEqMake, ds.Tables[16]);
            }
            if (ds.Tables[17].Rows.Count > 0)
            {
                //Utility.BindDropDownList(ddlDishType, ds.Tables[17]);
                //Utility.BindDropDownList(ddlDishTypeAlternate, ds.Tables[17]);
            }
            if (ds.Tables[18].Rows.Count > 0)
            {
                //Utility.BindDropDownList(ddlWasteEqType, ds.Tables[18]);
                //Utility.BindDropDownList(ddlWasteEqTypeAlternate, ds.Tables[18]);
            }
            if (ds.Tables[19].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlExistingJobID, ds.Tables[19]);
                if (ddlExistingJobID.Items.Count > 0)
                {
                    ddlExistingJobID.SelectedIndex = 0;
                }
            }
            if (ds.Tables[20].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectType, ds.Tables[20]);
                if (ddlProjectType.Items.Count > 0)
                {
                    ddlProjectType.SelectedIndex = 0;
                }
            }
            if (ds.Tables[21].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSourceLead, ds.Tables[21]);
                if (ddlSourceLead.Items.Count > 0)
                {
                    ddlSourceLead.SelectedIndex = 0;
                }
            }
            if (ds.Tables[22].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectBid, ds.Tables[22]);
                if (ddlProjectBid.Items.Count > 0)
                {
                    ddlProjectBid.SelectedIndex = 0;
                }
            }
            if (ds.Tables[23].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectManager, ds.Tables[23]);
                if (ddlProjectManager.Items.Count > 0)
                {
                    ddlProjectManager.SelectedIndex = 0;
                }
            }
            if (ds.Tables[24].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConveyorPrimeSpec, ds.Tables[24]);
                if (ddlConveyorPrimeSpec.Items.Count > 0)
                {
                    ddlConveyorPrimeSpec.SelectedIndex = 0;
                }
            }
            if (ds.Tables[25].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConveyorAlternate, ds.Tables[25]);
                if (ddlConveyorAlternate.Items.Count > 0)
                {
                    ddlConveyorAlternate.SelectedIndex = 0;
                }
            }
            if (ds.Tables[26].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlIndustry, ds.Tables[26]);
                if (ddlIndustry.Items.Count > 0)
                {
                    ddlIndustry.SelectedIndex = 0;
                }
            }
            //if (ds.Tables[27].Rows.Count > 0)
            //{
            //    //Utility.BindCheckBoxListWOAll(chkModels, ds.Tables[27]);
            //}
            //Bind_Followups();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Followups()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 15;
            ds = ObjBLL.GetFollowups(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectBid, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectManager, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConveyorPrimeSpec, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConveyorAlternate, ds.Tables[3]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindSourceLeadRef(Int32 ReferenceType)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 21;
            ds = ObjBLL.GetProposals(ObjBOL);
            if (ReferenceType == 3)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlSourceleadref.DataSource = ds.Tables[0];
                    ddlSourceleadref.DataTextField = "CompanyName";
                    ddlSourceleadref.DataValueField = "ConsultantID";
                    ddlSourceleadref.DataBind();
                    ddlSourceleadref.Items.Insert(0, new ListItem("Select", "0"));
                }
            }
            else if (ReferenceType == 2)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ddlSourceleadref.DataSource = ds.Tables[1];
                    ddlSourceleadref.DataTextField = "CompanyName";
                    ddlSourceleadref.DataValueField = "DealerID";
                    ddlSourceleadref.DataBind();
                    ddlSourceleadref.Items.Insert(0, new ListItem("Select", "0"));
                }
            }
            else if (ReferenceType == 4)
            {
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ddlSourceleadref.DataSource = ds.Tables[2];
                    ddlSourceleadref.DataTextField = "Name";
                    ddlSourceleadref.DataValueField = "EmployeeID";
                    ddlSourceleadref.DataBind();
                    ddlSourceleadref.Items.Insert(0, new ListItem("Select", "0"));
                }
            }
            else if (ReferenceType == 1)
            {
                if (ds.Tables[3].Rows.Count > 0)
                {
                    ddlSourceleadref.DataSource = ds.Tables[3];
                    ddlSourceleadref.DataTextField = "RepName";
                    ddlSourceleadref.DataValueField = "RepID";
                    ddlSourceleadref.DataBind();
                    ddlSourceleadref.Items.Insert(0, new ListItem("Select", "0"));
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlSourceLead_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSourceLead.SelectedIndex > 0)
            {
                if (ddlSourceLead.SelectedValue == "1")
                {
                    BindSourceLeadRef(1);
                }
                else if (ddlSourceLead.SelectedValue == "2")
                {
                    BindSourceLeadRef(2);
                }
                else if (ddlSourceLead.SelectedValue == "3")
                {
                    BindSourceLeadRef(3);
                }
                else if (ddlSourceLead.SelectedValue == "4")
                {
                    BindSourceLeadRef(4);
                }
            }
            else
            {
                ddlSourceleadref.DataSource = "";
                ddlSourceleadref.DataBind();
            }
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
            GetSpecConsultantandRep();
            try
            {
                SpecCredit();
            }
            catch (Exception exs)
            {
                Utility.AddEditException(exs);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlConveyorPrimeSpec_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlConveyorPrimeSpec.SelectedValue == "9")
            {
                PnlConveyorPrimeSpec.Visible = true;
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
            }
            else
            {
                PnlConveyorPrimeSpec.Visible = false;
                txtConveyorSpec.Text = String.Empty;
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
            }
            GetSpecConsultantandRep();
            try
            {
                SpecCredit();
            }
            catch (Exception exs)
            {
                Utility.AddEditException(exs);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlConveyorAlternate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlConveyorAlternate.SelectedValue == "9")
            {
                pnlConveyorAlternate.Visible = true;
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
            }
            else
            {
                pnlConveyorAlternate.Visible = false;
                txtConveyorAlternate.Text = String.Empty;
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
            }
            GetSpecConsultantandRep();
            try
            {
                SpecCredit();
            }
            catch (Exception exs)
            {
                Utility.AddEditException(exs);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillDetails(string strPNumber)
    {
        try
        {
            DataSet ds = new DataSet();
            string[] PNumber = strPNumber.Split(',');
            ObjBOL.PNumber = PNumber[0].ToString();
            string Proposal = PNumber[0].ToString();
            ObjBOL.Operation = 17;
            ds = ObjBLL.GetFollowUpGrid(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvFollowup.DataSource = ds.Tables[0];
                GvFollowup.DataBind();
                //TextBox ProposalNo = GvFollowup.FooterRow.FindControl("FProposalNo") as TextBox;
                //ProposalNo.Text = Proposal;
                //foreach (GridViewRow row in GvFollowup.Rows)
                //{
                //    DropDownList ddlFollowupwith = row.FindControl("ddlFollowupwith") as DropDownList;
                //    Label label = row.FindControl("lblFollowupwith") as Label;
                //    if (label.Text == "S")
                //    {
                //        label.Text = "Sales Rep";
                //    }
                //    else if (label.Text == "D")
                //    {
                //        label.Text = "Dealer";
                //    }
                //    else if (label.Text == "C")
                //    {
                //        label.Text = "Consultant";
                //    }
                //    else if (label.Text == "I")
                //    {
                //        label.Text = "In House";
                //    }
                //    DropDownList ddlFollowupNature = row.FindControl("ddlFollowupNature") as DropDownList;
                //    Label lblFollowupNature = row.FindControl("lblFollowupNature") as Label;
                //    if (lblFollowupNature.Text == "E")
                //    {
                //        lblFollowupNature.Text = "Email";
                //    }
                //    else if (lblFollowupNature.Text == "P")
                //    {
                //        lblFollowupNature.Text = "Phone";
                //    }
                //    else if (lblFollowupNature.Text == "T")
                //    {
                //        lblFollowupNature.Text = "Teams Meeting";
                //    }
                //}
            }
            else
            {
                GvFollowup.DataSource = EmptyDT();
                GvFollowup.DataBind();
                GvFollowup.Rows[0].Visible = false;
                TextBox ProposalNo = GvFollowup.FooterRow.FindControl("FProposalNo") as TextBox;
                ProposalNo.Text = Proposal;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void UpdateFollowupwith(string strPNumber)
    {
        try
        {
            DataSet ds = new DataSet();
            string[] PNumber = strPNumber.Split(',');
            ObjBOL.PNumber = PNumber[0].ToString();
            string Proposal = PNumber[0].ToString();
            ObjBOL.Operation = 17;
            ds = ObjBLL.GetFollowUpGrid(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvFollowup.DataSource = ds.Tables[0];
                GvFollowup.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable EmptyDT()
    {
        DataTable dtEmpty = new DataTable();
        try
        {
            dtEmpty.Columns.Add("showninreports", typeof(Boolean));
            dtEmpty.Columns.Add("Followupid", typeof(Int32));
            dtEmpty.Columns.Add("ProposalNo", typeof(string));
            dtEmpty.Columns.Add("followupwith", typeof(string));
            dtEmpty.Columns.Add("followupdate", typeof(DateTime));
            dtEmpty.Columns.Add("followedupdate", typeof(DateTime));
            dtEmpty.Columns.Add("nextfollowupdate", typeof(DateTime));
            dtEmpty.Columns.Add("notes", typeof(string));
            dtEmpty.Columns.Add("followupNature", typeof(string));
            dtEmpty.Columns.Add("expectedPOReceivedDate", typeof(DateTime));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);//adding row to the datatable            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    protected void GvFollowup_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            GvFollowup.EditIndex = e.NewEditIndex;
            if (txtSearchPNum.Text != "")
            {
                UpdateFollowupwith(txtSearchPNum.Text);
            }
            else
            {
                string[] PNumber = Session["PNumber"].ToString().Split(',');
                string pnum = PNumber[0].ToString();
                UpdateFollowupwith(pnum);
            }
            DropDownList ddlFollowUpWith = GvFollowup.Rows[e.NewEditIndex].FindControl("ddlFollowupwith") as DropDownList;
            Label lblFollowupwitHfPNumberropdown = GvFollowup.Rows[e.NewEditIndex].FindControl("lblFollowupwithdropdown") as Label;
            if (lblFollowupwitHfPNumberropdown.Text.Trim() != "")
            {
                string sv = lblFollowupwitHfPNumberropdown.Text[0].ToString();
                ddlFollowUpWith.SelectedValue = sv;
            }

            DropDownList ddlFollowupNature = GvFollowup.Rows[e.NewEditIndex].FindControl("ddlFollowupNature") as DropDownList;
            Label lblFollowupNaturedropdown = GvFollowup.Rows[e.NewEditIndex].FindControl("lblFollowupNaturedropdown") as Label;
            if (lblFollowupNaturedropdown.Text.Trim() != "")
            {
                string sv = lblFollowupNaturedropdown.Text[0].ToString();
                ddlFollowupNature.SelectedValue = sv;
            }

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
            GetSpecConsultantandRep();
            //Utility.MaintainLogsSpecial("frmProposals", "Edit Followup", txtProNO.Text);
            try
            {
                SpecCredit();
            }
            catch (Exception exs)
            {
                Utility.AddEditException(exs);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvFollowup_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        try
        {
            if (ddlProjectManager.SelectedIndex > 0)
            {
                string msg = "";
                GridViewRow row = GvFollowup.Rows[e.RowIndex];
                ObjBOL.Operation = 19;
                ObjBOL.Followupid = Convert.ToInt32(GvFollowup.DataKeys[e.RowIndex].Values[0]);
                string FollowUpWith = (row.FindControl("ddlFollowupwith") as DropDownList).SelectedValue;
                ObjBOL.FFollowUpWith = FollowUpWith;
                string FddlFollowupNature = (row.FindControl("ddlFollowupNature") as DropDownList).SelectedValue;
                ObjBOL.FFollowUpNature = FddlFollowupNature;
                // ObjBOL.FProposalNumber = (row.FindControl("txtProposalNo") as TextBox).Text;
                ObjBOL.FProposalNumber = txtProNO.Text.Replace(",", "").ToUpper();
                string showninreports = (row.FindControl("ddlShowninreports") as DropDownList).SelectedValue;
                if (showninreports == "1")
                {
                    ObjBOL.Fshowninreports = true;
                }
                else
                {
                    ObjBOL.Fshowninreports = false;
                }
                string FollowupDate = (row.FindControl("txtFollowupDate") as TextBox).Text;
                string FollowedupDate = (row.FindControl("txtFollowedupDate") as TextBox).Text;
                string NextFollowedupDate = (row.FindControl("txtNextFollowUpDate") as TextBox).Text;
                string ExpectedPOReceivedDate = (row.FindControl("txtExpectedPOReceivedDate") as TextBox).Text;
                if (FollowupDate != "")
                {
                    ObjBOL.FFollowUpDate = Utility.ConvertDate(FollowupDate);
                }
                if (FollowedupDate != "")
                {
                    ObjBOL.FFollowedUpDate = Utility.ConvertDate(FollowedupDate);
                }
                if (NextFollowedupDate != "")
                {
                    ObjBOL.FNextFollowedUpDate = Utility.ConvertDate(NextFollowedupDate);
                }
                if (ExpectedPOReceivedDate != "")
                {
                    ObjBOL.FExpectedPOReceivedDate = Utility.ConvertDate(ExpectedPOReceivedDate);
                }
                TextBox txtnotes = row.FindControl("txtNotes") as TextBox;
                if (txtnotes.Text == "")
                {
                    msg = "Please Enter Notes !!";
                    Utility.ShowMessage_Error(Page, msg);
                    //Utility.ShowMessage(this, msg);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
                    txtnotes.Focus();
                    return;
                }
                else
                {
                    ObjBOL.FNotes = txtnotes.Text;
                }
                if (FollowUpWith != "" && FollowupDate != "")
                {
                    msg = ObjBLL.AddFollowUpRecord(ObjBOL);
                    //Utility.ShowMessage(this, msg);
                    if (msg.Trim().Length > 0)
                    {
                        Utility.MaintainLogsSpecial("frmProposals", "Update Followup", txtProNO.Text);
                        Utility.ShowMessage_Success(Page, "Followup updated successfully !!");
                        GvFollowup.EditIndex = -1;
                        string pnum = string.Empty;
                        pnum = txtProNO.Text.Replace(",", "").ToUpper();
                        //CNumber = pnum;
                        if (pnum == Convert.ToString(','))
                        {
                            string[] PNumber = Session["PNumber"].ToString().Split(',');
                            string pnumber = PNumber[0].ToString();
                            UpdateFollowupwith(pnumber);
                        }
                        else
                        {
                            UpdateFollowupwith(txtProNO.Text.Replace(",", "").ToUpper());
                        }
                    }
                }
                else
                {
                    msg = "Please Select Follow Up With and Follow Up Date First !!";
                    //Utility.ShowMessage(this, msg);
                    Utility.ShowMessage_Error(Page, msg);
                    //
                }
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
                GetSpecConsultantandRep();
                try
                {
                    SpecCredit();
                }
                catch (Exception exs)
                {
                    Utility.AddEditException(exs);
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please Select Project Manager !!");
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Project Manager !!');", true);
                ddlProjectManager.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
                return;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvFollowup_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            Int32 ID = Convert.ToInt32(GvFollowup.DataKeys[e.RowIndex].Value);
            ObjBOL.Operation = 25;
            ObjBOL.Followupid = ID;
            msg = ObjBLL.DeleteFollowUpRecord(ObjBOL);
            if (msg.Trim().Length > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
                try
                {
                    SpecCredit();
                }
                catch (Exception exs)
                {
                    Utility.AddEditException(exs);
                }
                FillDetails(txtSearchPNum.Text);
                Utility.MaintainLogsSpecial("frmProposals", "Delete Followup", txtProNO.Text);
                Utility.ShowMessage_Success(Page, "Followup deleted successfully !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvFollowup_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        try
        {
            GvFollowup.EditIndex = -1;
            FillDetails(txtSearchPNum.Text);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
            GetSpecConsultantandRep();
            try
            {
                SpecCredit();
            }
            catch (Exception exs)
            {
                Utility.AddEditException(exs);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvFollowup_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        try
        {
            GvFollowup.PageIndex = e.NewPageIndex;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
            GetSpecConsultantandRep();
            try
            {
                SpecCredit();
            }
            catch (Exception exs)
            {
                Utility.AddEditException(exs);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //GvShpDrg_RowCommand
    protected void GvFollowup_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        try
        {
            if (ddlProjectManager.SelectedIndex > 0)
            {
                if (e.CommandName == "Insert")
                {
                    if (txtSearchPNum.Text == "")
                    {
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Proposal No. !');", true);
                        Utility.ShowMessage_Error(Page, "Please Select Proposal No. !");
                        txtSearchPNum.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSQuote()", true);
                        return;
                    }
                    if (txtSearchPName.Text == "")
                    {
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Proposal Name. !');", true);
                        Utility.ShowMessage_Error(Page, "Please Select Proposal Name. !");
                        txtSearchPName.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSQuote()", true);
                        return;
                    }
                    string msg = "";
                    TextBox ProposalNo = GvFollowup.FooterRow.FindControl("FProposalNo") as TextBox;
                    DropDownList FollowUpWith = GvFollowup.FooterRow.FindControl("FddlFollowupwith") as DropDownList;
                    DropDownList FddlFollowupNature = GvFollowup.FooterRow.FindControl("FddlFollowupNature") as DropDownList;
                    DropDownList showninreports = GvFollowup.FooterRow.FindControl("Fddlshowninreports") as DropDownList;
                    TextBox FollowUpDate = GvFollowup.FooterRow.FindControl("FtxtFollowupDate") as TextBox;
                    TextBox FollowedUpDate = GvFollowup.FooterRow.FindControl("FtxtFollowedupDate") as TextBox;
                    TextBox NextFollowedUpDate = GvFollowup.FooterRow.FindControl("FtxtNextFollowedUpDate") as TextBox;
                    TextBox Notes = GvFollowup.FooterRow.FindControl("FtxtNotes") as TextBox;
                    TextBox ExpectedPOReceivedDate = GvFollowup.FooterRow.FindControl("FtxtExpectedPOReceivedDate") as TextBox;

                    if (txtProNO.Text == "")
                    {
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Proposal No. !');", true);
                        Utility.ShowMessage_Error(Page, "Please Select Proposal No. !");
                        txtProNO.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSQuote()", true);
                        return;
                    }
                    if (FollowUpWith.SelectedIndex > 0)
                    {
                        ObjBOL.FProposalNumber = (txtProNO.Text.Replace(",", "").ToUpper());
                        ObjBOL.FFollowUpWith = FollowUpWith.SelectedValue;
                        ObjBOL.FFollowUpNature = FddlFollowupNature.SelectedValue;
                        if (showninreports.SelectedValue == "1")
                        {
                            ObjBOL.Fshowninreports = true;
                        }
                        else
                        {
                            ObjBOL.Fshowninreports = false;
                        }
                        if (FollowUpDate.Text != "")
                        {
                            ObjBOL.FFollowUpDate = Utility.ConvertDate(FollowUpDate.Text);
                        }
                        else
                        {
                            msg = "Please Enter Followup Date !!";
                            //Utility.ShowMessage(this, msg);
                            Utility.ShowMessage_Error(Page, msg);
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
                            FollowUpDate.Focus();
                            return;
                        }
                        if (FollowedUpDate.Text != "")
                        {
                            ObjBOL.FFollowedUpDate = Utility.ConvertDate(FollowedUpDate.Text);
                        }
                        if (NextFollowedUpDate.Text != "")
                        {
                            ObjBOL.FNextFollowedUpDate = Utility.ConvertDate(NextFollowedUpDate.Text);
                        }
                        if (ExpectedPOReceivedDate.Text != "")
                        {
                            ObjBOL.FExpectedPOReceivedDate = Utility.ConvertDate(ExpectedPOReceivedDate.Text);
                        }
                        if (Notes.Text.Trim() == "")
                        {
                            msg = "Please Enter Notes !!";
                            //Utility.ShowMessage(this, msg);
                            Utility.ShowMessage_Error(Page, msg);
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
                            Notes.Focus();
                            return;
                        }
                        else
                        {
                            ObjBOL.FNotes = Notes.Text.Trim();
                        }
                        ObjBOL.Operation = 16;
                        msg = ObjBLL.AddFollowUpRecord(ObjBOL);
                        if (msg.Trim().Length > 0)
                        {
                            FillDetails(txtProNO.Text);
                            Utility.ShowMessage_Success(Page, "Followup inserted successfully !!");
                            if(txtProNO.Text != "")
                            {
                                Utility.MaintainLogsSpecial("FrmProposals.aspx", "Insert Followup", txtProNO.Text);
                            }                            
                        }
                    }
                    else
                    {
                        if (FollowUpWith.SelectedIndex == 0)
                        {
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Followup With !!');", true);
                            Utility.ShowMessage_Error(Page, "Please Select Followup With !!");
                            FollowUpWith.Focus();
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
                            return;
                        }
                        if (FollowUpDate.Text == "")
                        {
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Followup Date !!');", true);
                            Utility.ShowMessage_Error(Page, "Please Enter Followup Date !!");
                            FollowUpDate.Focus();
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
                            return;
                        }
                    }
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
                    GetSpecConsultantandRep();
                    try
                    {
                        SpecCredit();
                    }
                    catch (Exception exs)
                    {
                        Utility.AddEditException(exs);
                    }
                }
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Project Manager !!');", true);
                Utility.ShowMessage_Error(Page, "Please Select Project Manager !!");
                ddlProjectManager.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
                return;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// FillPnumber Method Fill mutiple records like Proposal Number,Project Name,City,State,Country
    /// </summary>
    /// <param name="Pnumber"></param>
    private void FillPnumber(string Pnumber)
    {
        try
        {
            txtSearchPName.Text = string.Empty;
            string strPnumber = Pnumber;
            string OutPnumber = string.Empty;
            if (strPnumber.Contains(","))
            {
                OutPnumber = strPnumber.Substring(0, strPnumber.IndexOf(','));
                FillDetailsFromPnumber(OutPnumber);
                BindQuote(OutPnumber);
            }
            else
            {
                OutPnumber = strPnumber;
                FillDetailsFromPnumber(strPnumber);
                BindQuote(OutPnumber);
            }
            //FillPNumber(OutPnumber);
            btnSave.Text = "Update";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillDetailsFromPnumber(string strPNumber)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.PNumber = strPNumber;
            ds = ObjBLL.GetProposals(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
            {
                { "projectmanagerid", d =>
                    {
                        if (ddlProjectManager.Items.FindByValue(d["projectmanagerid"].ToString()) != null)
                        {
                            ddlProjectManager.SelectedValue = d["projectmanagerid"].ToString();
                        }
                        else if(ddlProjectManager.Items.Count > 0)
                        {
                            ddlProjectManager.SelectedIndex = 0;
                        }
                        hdfPM.Value = d["projectmanagerid"].ToString();
                    }
                },
                { "PNumber", d =>
                    {
                        txtProNO.Text = Convert.ToString(d["PNumber"]);
                        if (txtProNO.Text != "")
                        {
                            BindExistingJobID();
                        }
                    }
                },
                { "ProposalDate", d => txtProDate.Text = cls.Converter(Convert.ToString(d["ProposalDate"])) },
                { "JobID", d =>
                        {
                            txtJobID.Text = Convert.ToString(d["JobID"]);
                            if(txtJobID.Text.Trim() != "")
                            {
                                EnableDisablePaymentControls(false);
                            }
                            else
                            {
                                EnableDisablePaymentControls(true);
                            }
                        }
                    },
                { "ProjectName", d => txtProjectName.Text = Convert.ToString(d["ProjectName"]) },
                { "CountryID", d =>
                    {
                        if (ddlCountry.Items.FindByValue(Convert.ToString(d["CountryID"])) != null)
                        {
                            ddlCountry.SelectedValue = Convert.ToString(d["CountryID"]);
                        }
                        else if(ddlCountry.Items.Count > 0)
                        {
                            ddlCountry.SelectedIndex = 0;
                        }
                    }
                },
                { "StateID", d =>
                    {
                        GetState(ddlCountry.SelectedValue);
                        if(ddlState.Items.FindByValue(Convert.ToString(d["StateID"])) != null)
                        {
                            ddlState.SelectedValue = Convert.ToString(d["StateID"]);
                        }
                        else if(ddlState.Items.Count > 0)
                        {
                            ddlState.SelectedIndex = 0;
                        }

                        if(ddlStateAb.Items.FindByValue(Convert.ToString(d["StateID"])) != null)
                        {
                            ddlStateAb.SelectedValue = Convert.ToString(d["StateID"]);
                        }
                        else if(ddlStateAb.Items.Count > 0)
                        {
                            ddlStateAb.SelectedIndex = 0;
                        }
                    }
                },
                { "City", d => txtCity.Text = Convert.ToString(d["City"]) },
                { "CurrencyID", d =>
                    {
                        if (ddlCurruncy.Items.FindByValue(Convert.ToString(d["CurrencyID"])) != null)
                        {
                            ddlCurruncy.SelectedValue = Convert.ToString(d["CurrencyID"]);
                        }
                        else if(ddlCurruncy.Items.Count > 0)
                        {
                            ddlCurruncy.SelectedIndex = 0;
                        }
                    }
                },
                { "Price", d =>
                    {
                        if(Convert.ToString(d["Price"]) != "")
                        {
                            txtEqPrice.Text = Convert.ToDecimal(d["Price"]).ToString("N");
                        }
                    }
                },
                { "EqDiscount",
                        d =>
                        {
                            if(Convert.ToString(d["EqDiscount"]) != "")
                            {
                                txtDisPer.Text = Convert.ToDecimal(d["EqDiscount"]).ToString("N");
                            }
                        }
                },
                { "EqDisAmount",
                        d =>
                        {
                            if(Convert.ToString(d["EqDisAmount"]) != "")
                            {
                                txtDisAmount.Text = Convert.ToDecimal(d["EqDisAmount"]).ToString("N");
                            }
                        }
                },
                { "NetEqPrice",
                        d =>
                        {
                            if(Convert.ToString(d["NetEqPrice"]) != "")
                            {
                                txtNetEqPrice.Text = Convert.ToDecimal(d["NetEqPrice"]).ToString("N");
                            }
                        }
                },
                { "Freight",
                    d =>
                    {
                        if(Convert.ToString(d["Freight"]) != "")
                        {
                            txtFreight.Text = Convert.ToDecimal(d["Freight"]).ToString("N");
                        }
                    }
                },
                { "Installation",
                        d =>
                        {
                            if(Convert.ToString(d["Installation"]) != "")
                            {
                                txtInstall.Text = Convert.ToDecimal(d["Installation"]).ToString("N");
                            }
                        }
                },
                { "PriceProtection", d =>
                    {
                        if (Convert.ToBoolean(d["PriceProtection"]) == true)
                        {
                            chkProtection.Checked = true;
                        }
                        else
                        {
                            chkProtection.Checked = false;
                        }
                    }
                },
                { "ElevenFour", d =>
                    {
                         if (Convert.ToBoolean(d["ElevenFour"]) == true)
                        {
                            chk11400.Checked = true;
                        }
                        else
                        {
                            chk11400.Checked = false;
                        }
                    }
                },
                { "SpecialInstr", d => txtSpecialInstr.Text = d["SpecialInstr"].ToString() },
                { "txtTotalAmount", d => txtTotalAmount.Text = CalculateTotal().ToString("N") },
                { "PreparedBy", d =>
                    {
                        if (ddlPreparedBy.Items.FindByValue(Convert.ToString(d["PreparedBy"])) != null)
                        {
                            ddlPreparedBy.SelectedValue = Convert.ToString(d["PreparedBy"]);
                        }
                        else if(ddlPreparedBy.Items.Count > 0)
                        {
                            ddlPreparedBy.SelectedIndex = 0;
                        }
                    }
                },
                { "ModelID", d =>
                    {
                        if (ddlModel.Items.FindByValue(Convert.ToString(d["ModelID"])) != null)
                        {
                            ddlModel.SelectedValue = Convert.ToString(d["ModelID"]);
                        }
                        else if(ddlModel.Items.Count > 0)
                        {
                            ddlModel.SelectedIndex = 0;
                        }
                    }
                },
                { "ConveyorTypeID", d =>
                    {
                        if (ddlConType.Items.FindByValue(Convert.ToString(d["ConveyorTypeID"])) != null)
                        {
                            ddlConType.SelectedValue = Convert.ToString(d["ConveyorTypeID"]);
                        }
                        else if(ddlConType.Items.Count > 0)
                        {
                            ddlConType.SelectedIndex = 0;
                        }
                    }
                },
                { "ProjectDesignerID", d =>
                    {
                        string st = Convert.ToString(d["ProjectDesignerID"]);
                        if (string.IsNullOrEmpty(st))
                        {
                        }
                        else
                        {
                            if (ddlDesigner.Items.FindByValue(Convert.ToString(d["ProjectDesignerID"])) != null)
                            {
                                ddlDesigner.SelectedValue = Convert.ToString(d["ProjectDesignerID"]);
                            }
                            else if(ddlDesigner.Items.Count > 0)
                            {
                                ddlDesigner.SelectedIndex = 0;
                            }
                        }
                    }
                },
                { "PrimeSpec", d =>
                    {
                        if (ddlPrimeSpec.Items.FindByValue(Convert.ToString(d["PrimeSpec"])) != null)
                        {
                            ddlPrimeSpec.SelectedValue = Convert.ToString(d["PrimeSpec"]);
                        }
                        else if(ddlPrimeSpec.Items.Count > 0)
                        {
                            ddlPrimeSpec.SelectedIndex = 0;
                        }
                    }
                },
                { "alternate1", d =>
                    {
                        if (ddlAlternate1.Items.FindByValue(Convert.ToString(d["alternate1"])) != null)
                        {
                            ddlAlternate1.SelectedValue = Convert.ToString(d["alternate1"]);
                        }
                        else if(ddlAlternate1.Items.Count > 0)
                        {
                            ddlAlternate1.SelectedIndex = 0;
                        }
                    }
                },
                { "CurrentStatus", d =>
                    {
                        if (ddlStatus.Items.FindByValue(Convert.ToString(d["CurrentStatus"])) != null)
                        {
                            ddlStatus.SelectedItem.Text = Convert.ToString(d["CurrentStatus"]);
                        }
                        else if(ddlStatus.Items.Count > 0)
                        {
                            ddlStatus.SelectedIndex = 0;
                        }
                    }
                },
                { "ConsultantID", d =>
                    {
                        if (ddlConsultant.Items.FindByValue(Convert.ToString(d["ConsultantID"])) != null)
                        {
                            ddlConsultant.SelectedValue = Convert.ToString(d["ConsultantID"]);
                            BindConsultantMember();
                        }
                        else if(ddlConsultant.Items.Count > 0)
                        {
                            ddlConsultant.SelectedIndex = 0;
                        }
                    }
                },
                { "ConsultantMemberId", d =>
                    {
                        if (ddlConsultantMember.Items.FindByValue(d["ConsultantMemberId"].ToString()) != null)
                        {
                            ddlConsultantMember.SelectedValue = d["ConsultantMemberId"].ToString();
                        }
                        else if(ddlConsultantMember.Items.Count > 0)
                        {
                            ddlConsultantMember.SelectedIndex = 0;
                        }
                    }
                },
                { "DealerID", d =>
                    {
                        if (ddlDealer.Items.FindByValue(Convert.ToString(d["DealerID"])) != null)
                        {
                            ddlDealer.SelectedValue = Convert.ToString(d["DealerID"]);
                            GetDealerMember(ddlDealer.SelectedValue);
                        }
                        else if(ddlDealer.Items.Count > 0)
                        {
                            ddlDealer.SelectedIndex = 0;
                        }
                    }
                },
                { "ConsultRepID", d =>
                    {
                        if (ddlConsultantRep.Items.FindByValue(Convert.ToString(d["ConsultRepID"])) != null)
                        {
                            ddlConsultantRep.SelectedValue = Convert.ToString(d["ConsultRepID"]);
                        }
                         else if(ddlConsultantRep.Items.Count > 0)
                        {
                            ddlConsultantRep.SelectedIndex = 0;
                        }
                    }
                },
                { "OriginRepID", d =>
                    {
                        if (ddlOriginationRep.Items.FindByValue(Convert.ToString(d["OriginRepID"])) != null)
                        {
                            ddlOriginationRep.SelectedValue = Convert.ToString(d["OriginRepID"]);
                        }
                        else if(ddlOriginationRep.Items.Count > 0)
                        {
                            ddlOriginationRep.SelectedIndex = 0;
                        }
                    }
                },
                { "RepID", d =>
                    {
                        if (ddlDestRep.Items.FindByValue(Convert.ToString(d["RepID"])) != null)
                        {
                            ddlDestRep.SelectedValue = Convert.ToString(d["RepID"]);
                        }
                        else if(ddlDestRep.Items.Count > 0)
                        {
                            ddlDestRep.SelectedIndex = 0;
                        }
                    }
                },
                { "bidproject", d =>
                    {
                        if (ddlProjectBid.Items.FindByValue(d["bidproject"].ToString()) != null)
                        {
                            ddlProjectBid.SelectedValue = d["bidproject"].ToString();
                        }
                        else if(ddlProjectBid.Items.Count > 0)
                        {
                            ddlProjectBid.SelectedIndex = 0;
                        }
                    }
                },
                { "conveyorprimespec", d =>
                    {
                        if (ddlConveyorPrimeSpec.Items.FindByValue(d["conveyorprimespec"].ToString()) != null)
                        {
                            ddlConveyorPrimeSpec.SelectedValue = d["conveyorprimespec"].ToString();
                        }
                        else if(ddlConveyorPrimeSpec.Items.Count > 0)
                        {
                            ddlConveyorPrimeSpec.SelectedIndex = 0;
                        }
                    }
                },
                { "dealermemberid", d =>
                    {
                        if (ddlDealerMember.Items.FindByValue(d["dealermemberid"].ToString()) != null)
                        {
                            ddlDealerMember.SelectedValue = d["dealermemberid"].ToString();
                        }
                        else if(ddlDealerMember.Items.Count > 0)
                        {
                            ddlDealerMember.SelectedIndex = 0;
                        }
                    }
                },
                { "sourceleadid", d =>
                    {
                        if (d["sourceleadid"].ToString() != "")
                        {
                            if (ddlSourceLead.Items.FindByValue(d["sourceleadid"].ToString()) != null)
                            {
                                ddlSourceLead.SelectedValue = d["sourceleadid"].ToString();
                                BindSourceLeadRef(Convert.ToInt32(ddlSourceLead.SelectedValue));
                            }
                            else if(ddlSourceLead.Items.Count > 0)
                            {
                                ddlSourceLead.SelectedIndex = 0;
                            }

                            if (ddlSourceleadref.Items.FindByValue(d["Sourceleadref"].ToString()) != null)
                            {
                                ddlSourceleadref.SelectedValue = d["Sourceleadref"].ToString();
                            }
                            else if(ddlSourceleadref.Items.Count > 0)
                            {
                                ddlSourceleadref.SelectedIndex = 0;
                            }
                        }
                    }
                },
                { "EstimatedEquipmentWantDate", d => txtEstWantDate.Text = cls.Converter(Convert.ToString(d["EstimatedEquipmentWantDate"])) },
                { "SpecCreditPercentID", d =>
                    {
                        if (ddlSpecCredit.Items.FindByValue(Convert.ToString(d["SpecCreditPercentID"])) != null)
                        {
                            ddlSpecCredit.SelectedValue = Convert.ToString(d["SpecCreditPercentID"]);
                        }
                        else if(ddlSpecCredit.Items.Count > 0)
                        {
                            ddlSpecCredit.SelectedIndex = 0;
                        }
                    }
                },
                { "SpecCredits", d =>
                    {
                         if (Convert.ToString(d["SpecCredits"]) != "0")
                        {
                            rdbSpecCredit.SelectedValue = Convert.ToString(d["SpecCredits"]);
                        }
                        else
                        {
                            rdbSpecCredit.SelectedValue = null;
                        }
                    }
                },
                { "SpecCreditAmount",
                        d =>
                        {
                            if(Convert.ToString(d["SpecCreditAmount"]) != "")
                            {
                                txtSpecAmount.Text = Convert.ToDecimal(d["SpecCreditAmount"]).ToString("N");
                            }
                        }
                },
                { "txtSpecConsultantRep", d =>
                    {
                        txtSpecConsultantRep.Text = ddlConsultantRep.SelectedItem.Text;
                        txtSpecConsultant.Text = ddlConsultant.SelectedItem.Text;
                    }
                },
                { "SpecCreditCheckNo", d => txtSpecCheque.Text = Convert.ToString(d["SpecCreditCheckNo"]) },
                { "SpecCreditPaidDate", d => txtSpecPaid.Text = cls.Converter(Convert.ToString(d["SpecCreditPaidDate"])) },
                { "Compitetor", d =>
                    {
                        if (ddlCompetitor.Items.FindByText(Convert.ToString(d["Compitetor"])) != null)
                        {
                            ddlCompetitor.SelectedItem.Text = Convert.ToString(d["Compitetor"]);
                        }
                        else if(ddlCompetitor.Items.Count > 0)
                        {
                            ddlCompetitor.SelectedIndex = 0;
                        }
                    }
                },
                { "Comment", d => txtComments.Text = Convert.ToString(d["Comment"]) },
                    { "OrderBelongsTo", d =>
                        {
                            if(Convert.ToString(d["OrderBelongsTo"]) != "")
                            {
                                if (Convert.ToInt32(d["OrderBelongsTo"]) == 1)
                                {
                                    rdbOrderFor.SelectedValue = "1";
                                }
                                else
                                {
                                    rdbOrderFor.SelectedValue = "2";
                                }
                            }

                        }
                    },
                { "QuoteRequired", d =>
                    {
                        if (Convert.ToBoolean(d["QuoteRequired"]) == true)
                        {
                            chkQuoteReq.Checked = true;
                        }
                        else
                        {
                            chkQuoteReq.Checked = false;
                        }
                    }
                },
                { "HobartIssTag", d =>
                    {
                        if (Convert.ToBoolean(d["HobartIssTag"]) == true)
                        {
                            chkHobartISS.Checked = true;
                        }
                        else
                        {
                            chkHobartISS.Checked = false;
                        }
                    }
                },
                { "DrqRequired", d =>
                    {
                        if (Convert.ToBoolean(d["DrqRequired"]) == true)
                        {
                            chkDwgReq.Checked = true;
                        }
                        else
                        {
                            chkDwgReq.Checked = false;
                        }
                    }
                },
                { "IsGillProject", d =>
                    {
                        Boolean IsGillProject = Convert.ToBoolean(d["IsGillProject"]);
                        if (IsGillProject == true)
                        {
                            chkGillProject.Checked = true;
                        }
                        else
                        {
                            chkGillProject.Checked = false;
                        }
                    }
                },
                { "JobType", d =>
                    {
                        if (d["JobType"].ToString() != "0")
                        {
                            ddlProjectType.SelectedIndex = ddlProjectType.Items.IndexOf(ddlProjectType.Items.FindByText(d["JobType"].ToString()));
                        }
                    }
                },
                { "shipdate", d =>
                    {
                        if (d["shipdate"].ToString().Trim() != "")
                        {
                            txtShipDate.Text = cls.Converter(Convert.ToString(d["shipdate"].ToString()));
                        }
                    }
                },
                { "biddate", d =>
                    {
                        if (d["biddate"].ToString().Trim() != "")
                        {
                            txtBidDate.Text = cls.Converter(Convert.ToString(d["biddate"].ToString()));
                        }
                    }
                },
                { "conveyorprimespecother", d => txtConveyorSpec.Text = d["conveyorprimespecother"].ToString() },
                { "ddlConveyorPrimeSpec", d =>
                    {
                        if (ddlConveyorPrimeSpec.SelectedValue == "9")
                        {
                            PnlConveyorPrimeSpec.Visible = true;
                        }
                        else
                        {
                            PnlConveyorPrimeSpec.Visible = false;
                            txtConveyorSpec.Text = String.Empty;
                        }
                    }
                },
                { "conveyoralternate", d =>
                    {
                        if (ddlConveyorAlternate.Items.FindByValue(d["conveyoralternate"].ToString()) != null)
                        {
                            ddlConveyorAlternate.SelectedValue = d["conveyoralternate"].ToString();
                        }
                        else if(ddlConveyorAlternate.Items.Count > 0)
                        {
                            ddlConveyorAlternate.SelectedIndex = 0;
                        }

                        if (ddlConveyorAlternate.SelectedValue == "9")
                        {
                            pnlConveyorAlternate.Visible = true;
                        }
                        else
                        {
                            pnlConveyorAlternate.Visible = false;
                            txtConveyorAlternate.Text = String.Empty;
                        }
                    }
                },
                { "conveyoralternateother", d => txtConveyorAlternate.Text = d["conveyoralternateother"].ToString() },
                { "Industry", d =>
                    {
                        if (ddlIndustry.Items.FindByValue(d["Industry"].ToString()) != null)
                        {
                            ddlIndustry.SelectedValue = d["Industry"].ToString();
                        }
                        else if(ddlIndustry.Items.Count > 0)
                        {
                            ddlIndustry.SelectedIndex = 0;
                        }
                    }
                }
            };

                foreach (var assignment in assignments)
                {
                    try
                    {
                        assignment.Value(ds.Tables[0].Rows[0]);
                    }
                    catch (Exception ex)
                    {
                        Utility.AddEditException(ex, assignment.Key);
                    }
                }

                btnExistingJob.Enabled = true;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "text", "getCheckedRadio();", true);
                if (ddlProjectManager.SelectedIndex > 0)
                {
                    lblPM.Text = "Project Manager : <b>" + ddlProjectManager.SelectedItem.Text + "</b>";
                    lblPM.Visible = true;
                    //spn.Visible = true;
                }
                else
                {
                    lblPM.Text = String.Empty;
                    lblPM.Visible = false;
                    //spn.Visible = false;
                }
                if (ddlDestRep.SelectedIndex > 0)
                {
                    lblDesRep.Text = "Destination Rep : <b>" + ddlDestRep.SelectedItem.Text + "</b>";
                    //spn.Visible = true;
                    lblDesRep.Visible = true;
                }
                else
                {
                    lblDesRep.Text = String.Empty;
                    //spn.Visible = false;
                    lblDesRep.Visible = false;
                }
                if (ddlConsultant.SelectedIndex > 0)
                {
                    lblConsultant.Text = "Consultant : <b>" + ddlConsultant.SelectedItem.Text + "</b>";
                    lblConsultant.Visible = true;
                }
                else
                {
                    lblConsultant.Text = String.Empty;
                    lblConsultant.Visible = false;
                }
                //if (ddlDealer.SelectedIndex > 0)
                //{
                //    lblDealer.Text = "Dealer : <b>" + ddlDealer.SelectedItem.Text + "</b>";
                //    lblDealer.Visible = true;
                //}
                //else
                //{
                //    lblDealer.Text = String.Empty;
                //    lblDealer.Visible = false;
                //}
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void EnableDisablePaymentControls(bool enable)
    {
        try
        {
            //var icsTab = (HtmlGenericControl)Page.FindControl("icsTab");
            EnableDisableControlRecursively(pfEquipmentPrice, enable);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableDisableControlRecursively(Control control, bool enable)
    {
        try
        {
            if (control is WebControl)
            {
                WebControl webControl = (WebControl)control;
                if (control is TextBox)
                {
                    ((TextBox)control).Enabled = enable;
                }
                else if (control is DropDownList)
                {
                    ((DropDownList)control).Enabled = enable;
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).Enabled = enable;
                }

                if (webControl.CssClass.Split(' ').Contains("exempt"))
                {
                    ((TextBox)control).Enabled = false;
                }
            }

            if (control.HasControls())
            {
                foreach (Control childControl in control.Controls)
                {
                    EnableDisableControlRecursively(childControl, enable);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // For Total calculation
    private decimal CalculateTotal()
    {
        //=Nz([NetEqPrice])+Nz([Freight])+Nz([Installation])
        Decimal TAmount = 0;
        try
        {
            TAmount = Convert.ToDecimal(txtNetEqPrice.Text) + Convert.ToDecimal(txtFreight.Text) + Convert.ToDecimal(txtInstall.Text);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return TAmount;
    }

    /// <summary>
    /// Generate New Proposal Number
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // generate PNumber
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Reset();
            string msg = "";
            ObjBOL.Operation = 8;
            msg = ObjBLL.GeneratePnumber(ObjBOL);
            if(msg != "")
            {
                txtProNO.Text = msg;
                txtProDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                btnAdd.Enabled = false;
                rdbOrderFor.SelectedValue = "1";
                btnExistingJob.Enabled = true;
                if (txtProNO.Text != "")
                {
                    Utility.MaintainLogsSpecial("frmProposals", "Add Followup", txtProNO.Text.Trim());
                }
            }
                     
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Validation Check Before Save and Update data.
    /// </summary>
    /// <returns></returns>
    // check if data filled in required fields
    private Boolean ValidationCheck()
    {
        try
        {
            if (ddlIndustry.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Industry. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Industry. !");
                ddlIndustry.Focus();
                //
                return false;
            }
            if (ddlSourceLead.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Source Lead. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Source Lead. !");
                ddlSourceLead.Focus();
                //
                return false;
            }
            if (ddlSourceleadref.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Source Lead Ref. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Source Lead Ref. !");
                ddlSourceleadref.Focus();
                //
                return false;
            }
            if (ddlConveyorPrimeSpec.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Conveyor Prime Spec. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Conveyor Prime Spec. !");
                ddlConveyorPrimeSpec.Focus();

                return false;
            }
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "test", "ConsultantMemberDetails();", true);
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "blah", "ConsultantMemberDetails();", true);
            if (txtProNO.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Generate Porposal Number. !');", true);
                Utility.ShowMessage_Error(Page, "Please Generate Proposal Number. !");
                txtProNO.Focus();

                return false;
            }
            if (ddlProjectType.SelectedIndex == 0 || ddlProjectType.SelectedValue == "0")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Project Type. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Type. !");
                ddlProjectType.Focus();

                return false;
            }
            if (txtProjectName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Project Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Project Name. !");
                txtProjectName.Focus();

                return false;
            }
            //if (ddlCountry.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Country. !');", true);
            //    ddlCountry.Focus();
            //    return false;
            //}

            //if (ddlState.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select State. !');", true);
            //    ddlState.Focus();
            //    return false;
            //}
            //if (txtCity.Text == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter City. !');", true);
            //    txtCity.Focus();
            //    return false;
            //}      

            if (chkProtection.Checked == true)
            {
                if (txtSpecialInstr.Text == "")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Special Instructions. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Enter Special Instructions. !");
                    txtSpecialInstr.Focus();
                    Utility.ShowValidationMark(txtSpecialInstr);

                    return false;
                }
                else
                {
                    Utility.RemoveValidationMark(txtSpecialInstr);
                }
            }

            if (ddlConsultantRep.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Consultant Rep. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Consultant Rep. !");
                ddlConsultantRep.Focus();

                return false;
            }
            if (ddlDestRep.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Destination Rep !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Destination Rep !");
                ddlDestRep.Focus();

                return false;
            }
            //if (ddlPrimeSpec.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Prime Spec. !');", true);
            //    ddlPrimeSpec.Focus();
            //    return false;
            //}
            if (ddlConsultant.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Consultant. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Consultant. !");
                ddlConsultant.Focus();

                return false;
            }
            //if (ddlConsultantMember.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Consultant Member. !');", true);
            //    ddlConsultantMember.Focus();
            //    return false;
            //}
            //if (ddlDealer.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Dealer. !');", true);
            //    ddlDealer.Focus();
            //    return false;
            //}
            //Spec Credit Rep and Consultant Validation

            //if (ddlModel.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Conveyor Model. !');", true);
            //    ddlModel.Focus();
            //    
            //    return false;
            //}

            //if (ddlConType.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Conveyor Type. !');", true);
            //    ddlConType.Focus();
            //    
            //    return false;
            //}

            if (rdbSpecCredit.SelectedValue == "2" || rdbSpecCredit.SelectedValue == "3")
            {
                if (ddlConsultantRep.SelectedValue == "0" || ddlConsultantRep.SelectedValue == "552")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Consultant Rep Should not be Blank or Not Applicable in Case of Spec Credit Application. !');", true);
                    Utility.ShowMessage_Error(Page, "Consultant Rep Should not be Blank or Not Applicable in Case of Spec Credit Application. !");
                    ddlConsultantRep.Focus();

                    return false;
                }
                if (ddlConsultant.SelectedValue == "0" || ddlConsultant.SelectedValue == "360")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Consultant Should not be Blank or Not Applicable in Case of Spec Credit Application. !');", true);
                    Utility.ShowMessage_Error(Page, "Consultant Should not be Blank or Not Applicable in Case of Spec Credit Application. !");
                    ddlConsultant.Focus();

                    return false;
                }
            }

            if (ddlProjectBid.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Project Stage in Followup tab. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Project Stage in Followup tab. !");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
                ddlProjectBid.Focus();

                return false;
            }
            if (ddlProjectManager.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Project Manager. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Project Manager. !");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
                ddlProjectManager.Focus();

                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private Boolean ValidationGridColumnsCheck()
    {
        try
        {
        }
        catch (Exception)
        {
            throw;
        }
        return true;
    }

    private void ResetHobartControls()
    {
        try
        {
            if (ddlDealerMember.SelectedIndex > 0)
            {
                ddlDealerMember.DataSource = "";
                ddlDealerMember.DataBind();
            }
            //ddlProjectBid.SelectedIndex = 0;
            //ddlConveyorAlternate.SelectedIndex = 0;
            //ddlConveyorPrimeSpec.SelectedIndex = 0;
            //ddlProjectManager.SelectedIndex = 0;
            txtConveyorSpec.Text = String.Empty;
            txtConveyorAlternate.Text = String.Empty;
            GvFollowup.DataSource = EmptyDT();
            GvFollowup.DataBind();
            gvQuoteInfo.DataSource = EmptyDTQuote();
            gvQuoteInfo.DataBind();
            gvQuoteInfo.Rows[0].Visible = false;
            GvFollowup.Rows[0].Visible = false;
            GvProDwg.DataSource = EmptyDTProposalDwgs();
            GvProDwg.DataBind();
            GvProDwg.Rows[0].Visible = false;
            BindDropDownList();
            //ddlDishPrimeSpec.SelectedIndex = 0;
            //txtDishPrimeSpec.Text = String.Empty;
            //ddlDishType.SelectedIndex = 0;
            //txtDishType.Text = String.Empty;
            //if (ddlDishModel.SelectedIndex > 0)
            //{
            //    ddlDishModel.DataSource = "";
            //    ddlDishModel.DataBind();
            //}
            //txtDishModel.Text = String.Empty;
            //if (ddlDishStyle.SelectedIndex > 0)
            //{
            //    ddlDishStyle.DataSource = "";
            //    ddlDishStyle.DataBind();
            //}
            //txtDishStyle.Text = String.Empty;
            //ddlDishAlternate.SelectedIndex = 0;
            //txtDishTypeAlternate.Text = String.Empty;
            //if (ddlDishModelAlternate.SelectedIndex > 0)
            //{
            //    ddlDishModelAlternate.DataSource = "";
            //    ddlDishModelAlternate.DataBind();
            //}
            //txtDishModel.Text = String.Empty;
            //if (ddlDishStyleAlternate.SelectedIndex > 0)
            //{
            //    ddlDishStyleAlternate.DataSource = "";
            //    ddlDishStyleAlternate.DataBind();
            //}
            //txtDishStyleAlternate.Text = String.Empty;
            //ddlWastePrimeSpec.SelectedIndex = 0;
            //txtWastePrimeSpec.Text = String.Empty;
            //ddlWasteEqType.SelectedIndex = 0;
            //txtWasteEqType.Text = String.Empty;
            //if (ddlWasteEqModel.SelectedIndex > 0)
            //{
            //    ddlWasteEqModel.DataSource = "";
            //    ddlWasteEqModel.DataBind();
            //}
            //txtWasteEqModel.Text = String.Empty;
            //if (ddlWasteEqStyle.SelectedIndex > 0)
            //{
            //    ddlWasteEqStyle.DataSource = "";
            //    ddlWasteEqStyle.DataBind();
            //}
            //txtWasteEqStyle.Text = String.Empty;
            //ddlWasteAlternate.SelectedIndex = 0;
            //txtWasteEqAlternate.Text = String.Empty;
            //ddlWasteEqTypeAlternate.SelectedIndex = 0;
            //txtWasteEqTypeAlternate.Text = String.Empty;
            //if (ddlWasteEqModelAlternate.SelectedIndex > 0)
            //{
            //    ddlWasteEqModelAlternate.DataSource = "";
            //    ddlWasteEqModelAlternate.DataBind();
            //}
            //txtWasteEqModelAlternate.Text = String.Empty;
            //if (ddlWasteEqStyleAlternate.SelectedIndex > 0)
            //{
            //    ddlWasteEqStyleAlternate.DataSource = "";
            //    ddlWasteEqStyleAlternate.DataBind();
            //}
            //txtWasteEqStyleAlternate.Text = String.Empty;
            //pnlDishPrimeSpec.Attributes.Add("style", "display:none");
            //pnlDishType.Attributes.Add("style", "display:none");
            //pnlDishModel.Attributes.Add("style", "display:none");
            //pnlDishStyle.Attributes.Add("style", "display:none");
            //pnlDishAlternate.Attributes.Add("style", "display:none");
            //pnlDishTypeAlternate.Attributes.Add("style", "display:none");
            //pnlDishModelAlternate.Attributes.Add("style", "display:none");
            //pnlDishStyleAlternate.Attributes.Add("style", "display:none");
            //pnlWastePrimeSpec.Attributes.Add("style", "display:none");
            //pnlWasteEqType.Attributes.Add("style", "display:none");
            //pnlWasteEqModel.Attributes.Add("style", "display:none");
            //PanelWasteEqStyle.Attributes.Add("style", "display:none");
            //PanelWasteEqAlternate.Attributes.Add("style", "display:none");
            //PanelWasteEqType.Attributes.Add("style", "display:none");
            //PanelWasteEqModelAlternate.Attributes.Add("style", "display:none");
            //PanelWasteEqStyleAlternate.Attributes.Add("style", "display:none");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // reset all controls
    private void Reset()
    {
        try
        {
            EnableDisablePaymentControls(true);
            btnCADReport.Enabled = false;
            btnSiteVisit.Enabled = false;
            txtShipDate.Text = String.Empty;
            txtBidDate.Text = String.Empty;
            btnSave.Text = "Save";
            Bind_Controls2();
            txtProNO.Text = string.Empty;
            txtProDate.Text = string.Empty;
            txtJobID.Text = string.Empty;
            txtProjectName.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlCountry.SelectedIndex = 0;
            if (ddlState.Items.Count > 0)
            {
                ddlState.SelectedIndex = 0;
                ddlState.Items.Clear();
                ddlStateAb.Items.Clear();
            }
            ddlCurruncy.SelectedIndex = 0;
            txtEqPrice.Text = string.Empty;
            chkProtection.Checked = false;
            chk11400.Checked = false;
            txtSpecialInstr.Text = String.Empty;
            txtDisPer.Text = string.Empty;
            txtDisAmount.Text = string.Empty;
            txtNetEqPrice.Text = string.Empty;
            txtFreight.Text = string.Empty;
            txtInstall.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            //ddlConsultantRep.SelectedIndex = 0;
            //ddlOriginationRep.SelectedIndex = 0;
            //ddlDestRep.SelectedIndex = 0;
            //ddlPrimeSpec.SelectedIndex = 0;
            // ddlOrderProbability.SelectedIndex = 0;
            //ddlStatus.SelectedIndex = 0;
            //ddlCompetitor.SelectedIndex = 0;
            //ddlConsultant.SelectedIndex = 0;
            ddlConsultantMember.DataSource = "";
            ddlConsultantMember.DataBind();
            //ddlDealer.SelectedIndex = 0;
            //ddlProjectType.SelectedIndex = 0;
            //ddlExistingJobID.SelectedIndex = 0;
            txtEstWantDate.Text = string.Empty;
            ddlReason.SelectedValue = "";
            //if (ddlSpecCredit.Items.Count > 0)
            //{
            //    ddlSpecCredit.SelectedIndex = 0;
            //}
            rdbSpecCredit.SelectedValue = null;
            txtSpecAmount.Text = string.Empty;
            txtSpecConsultantRep.Text = string.Empty;
            txtSpecConsultant.Text = string.Empty;
            txtSpecCheque.Text = string.Empty;
            txtSpecPaid.Text = string.Empty;
            ddlSourceleadref.DataSource = "";
            ddlSourceleadref.DataBind();
            //ddlOrderProbability.SelectedIndex = 0;
            //ddlStatus.SelectedItem.Text = "";
            //ddlCompetitor.SelectedItem.Text = "";
            //ddlConsultant.SelectedIndex = 0;
            //ddlDealer.SelectedIndex = 0;
            txtEstWantDate.Text = string.Empty;
            ddlReason.SelectedIndex = 0;
            // txtNotes.Text = string.Empty;
            txtComments.Text = string.Empty;
            ddlPreparedBy.SelectedIndex = 0;
            txtSearchPName.Text = string.Empty;
            txtSearchPNum.Text = string.Empty;
            chkHobartISS.Checked = false;
            chkQuoteReq.Checked = false;
            chkDwgReq.Checked = false;
            chkGillProject.Checked = false;
            rdbOrderFor.ClearSelection();
            ResetHobartControls();
            Session["PNumber"] = null;
            btnAdd.Enabled = true;
            //ddlIndustry.SelectedIndex = 0;
            btnExistingJob.Enabled = false;
            lblExistingJobDetails.Visible = false;
            lblExistingJobDetails.Text = String.Empty;
            Bind_Models();
            lblDesRep.Text = String.Empty;
            lblPM.Text = String.Empty;
            lblConsultant.Text = String.Empty;
            // lblDealer.Text = String.Empty;
            //spn.Visible = false;
            lblPM.Visible = false;
            lblDesRep.Visible = false;
            lblConsultant.Visible = false;
            // lblDealer.Visible = false;
            EnableDisableShipDate();
            PnlConveyorPrimeSpec.Visible = false;
            pnlConveyorAlternate.Visible = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetN()
    {
        try
        {
            txtShipDate.Text = String.Empty;
            txtBidDate.Text = String.Empty;
            btnSave.Text = "Save";
            Bind_Controls2();
            txtProNO.Text = string.Empty;
            txtProDate.Text = string.Empty;
            txtJobID.Text = string.Empty;
            txtProjectName.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlCountry.SelectedItem.Text = "";
            if (ddlState.Items.Count > 0)
            {
                ddlState.SelectedIndex = 0;
                ddlStateAb.SelectedIndex = 0;
            }
            ddlCurruncy.SelectedIndex = 0;
            txtEqPrice.Text = string.Empty;
            txtDisPer.Text = string.Empty;
            txtDisAmount.Text = string.Empty;
            txtNetEqPrice.Text = string.Empty;
            txtFreight.Text = string.Empty;
            txtInstall.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            //ddlConsultantRep.SelectedValue = "0";
            //ddlOriginationRep.SelectedValue = "0";
            //ddlDestRep.SelectedValue = "0";
            //ddlPrimeSpec.SelectedValue = "0";
            // ddlOrderProbability.SelectedValue = "0";
            //ddlStatus.SelectedItem.Text = "";
            //ddlCompetitor.SelectedItem.Text = "";
            //ddlConsultant.SelectedValue = "0";
            ddlConsultantMember.DataSource = "";
            ddlConsultantMember.DataBind();
            //ddlDealer.SelectedValue = "0";
            //ddlProjectType.SelectedValue = "0";
            //ddlExistingJobID.SelectedValue = "0";
            txtEstWantDate.Text = string.Empty;
            // ddlReason.SelectedValue = "";
            //ddlSpecCredit.SelectedValue = "0";
            rdbSpecCredit.SelectedValue = null;
            txtSpecAmount.Text = string.Empty;
            txtSpecConsultantRep.Text = string.Empty;
            txtSpecConsultant.Text = string.Empty;
            txtSpecCheque.Text = string.Empty;
            txtSpecPaid.Text = string.Empty;
            ddlSourceleadref.DataSource = "";
            ddlSourceleadref.DataBind();
            // ddlOrderProbability.SelectedValue = "0";
            ddlStatus.SelectedItem.Text = "";
            //ddlCompetitor.SelectedItem.Text = "";
            //ddlConsultant.SelectedValue = "0";
            //ddlDealer.SelectedValue = "0";
            txtEstWantDate.Text = string.Empty;
            //  ddlReason.SelectedValue = "0";
            // txtNotes.Text = string.Empty;
            txtComments.Text = string.Empty;
            ddlPreparedBy.SelectedIndex = 0;
            chkHobartISS.Checked = false;
            chkQuoteReq.Checked = false;
            chkDwgReq.Checked = false;
            chkGillProject.Checked = false;
            rdbOrderFor.ClearSelection();
            ResetHobartControls();
            Session["PNumber"] = null;
            btnAdd.Enabled = true;
            //ddlIndustry.SelectedIndex = 0;
            lblExistingJobDetails.Visible = false;
            lblExistingJobDetails.Text = String.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }
    /// <summary>
    /// Save all the values 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Save data
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                //CalculateAmounts();
                string msg = "";
                if (btnSave.Text.ToLower() == "save")
                {
                    ObjBOL.Operation = 40;
                }
                else if (btnSave.Text.ToLower() == "update")
                {
                    ObjBOL.Operation = 39;
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "Operation not clear !");
                }
                ObjBOL.PNumber = txtProNO.Text;
                ObjBOL.ProjectName = txtProjectName.Text;
                ObjBOL.City = txtCity.Text;
                if (ddlState.SelectedIndex > 0)
                {
                    ObjBOL.StateID = Convert.ToInt32(ddlState.SelectedValue);
                }
                ObjBOL.Price = Utility.ToDouble(txtEqPrice.Text);
                ObjBOL.PriceProtectionRequired = chkProtection.Checked;
                ObjBOL.ElevenFour = chk11400.Checked;
                ObjBOL.SpecialInstr = txtSpecialInstr.Text;
                ObjBOL.Freight = Utility.ToDouble(txtFreight.Text);
                ObjBOL.Installation = Utility.ToDouble(txtInstall.Text);
                if (ddlCurruncy.SelectedIndex > 0)
                {
                    ObjBOL.CurrencyID = Convert.ToInt32(ddlCurruncy.SelectedValue);
                }
                ObjBOL.ProposalDate = Utility.ConvertDate(txtProDate.Text);
                ObjBOL.QuoteRequired = chkQuoteReq.Checked;
                ObjBOL.DrqRequired = chkDwgReq.Checked;
                ObjBOL.HobartIssTag = chkHobartISS.Checked;
                //if (chkQuoteReq.Checked == true)
                //{
                //    ObjBOL.QuoteRequired = true;
                //}
                ////else
                ////{
                ////    ObjBOL.QuoteRequired = false;
                ////}
                //if (chkDwgReq.Checked == true)
                //{
                //    ObjBOL.DrqRequired = true;
                //}
                ////else
                ////{
                ////    ObjBOL.DrqRequired = false;
                ////}
                //if (chkHobartISS.Checked == true)
                //{
                //    ObjBOL.HobartIssTag = true;
                //}
                ////else
                ////{
                ////    ObjBOL.HobartIssTag = false;
                ////}
                if (rdbOrderFor.SelectedValue == "1")
                {
                    ObjBOL.OrderBelongsTo = 1;
                }
                else if (rdbOrderFor.SelectedValue == "2")
                {
                    ObjBOL.OrderBelongsTo = 2;
                }
                // TODO
                //QuoteSTERO, QuoteID,ShpDrgNum
                ObjBOL.QuoteReqDate = null;
                ObjBOL.QuoteAckDate = null;
                ObjBOL.QuotePrepDate = null;
                ObjBOL.QuoteSentDate = null;
                //ObjBOL.ShpDrgNum = txtProNO.Text;
                if (ddlDesigner.SelectedIndex > 0)
                {
                    ObjBOL.ProjectDesignerID = Convert.ToInt32(ddlDesigner.SelectedValue);
                }

                if (ddlOriginationRep.SelectedIndex > 0)
                {
                    ObjBOL.OriginRepID = Convert.ToInt32(ddlOriginationRep.SelectedValue);
                }

                if (ddlConsultantRep.SelectedIndex > 0)
                {
                    ObjBOL.ConsultRepID = Convert.ToInt32(ddlConsultantRep.SelectedValue);
                }
                //ObjBOL.InitialRepId = txtProNO.Text;

                if (ddlDestRep.SelectedIndex > 0)
                {
                    ObjBOL.RepID = Convert.ToInt32(ddlDestRep.SelectedValue);
                }

                if (ddlModel.SelectedIndex > 0)
                {
                    ObjBOL.ModelID = Convert.ToInt32(ddlModel.SelectedValue);
                }

                if (ddlConType.SelectedIndex > 0)
                {
                    ObjBOL.ConveyorTypeID = Convert.ToInt32(ddlConType.SelectedValue);
                }

                if (ddlPrimeSpec.SelectedIndex > 0)
                {
                    ObjBOL.PrimeSpec = Convert.ToInt32(ddlPrimeSpec.SelectedValue);
                }
                ObjBOL.alternate1 = Convert.ToString(ddlAlternate1.SelectedValue);
                //ObjBOL.alternate2 = Convert.ToString(ddlAlternate2.SelectedValue);
                //ObjBOL.alternate3 = Convert.ToString(ddlAlternate3.SelectedValue);
                //ObjBOL.Specifications = txtProNO.Text;
                //ObjBOL.DetailedQuote = txtProNO.Text;
                // ObjBOL.OrderProbabilityID = Convert.ToInt32(ddlOrderProbability.SelectedValue);
                //ObjBOL.SalesCategoryID = txtProNO.Text;                      
                ObjBOL.EstimatedEquipmentWantDate = Utility.ConvertDate(txtEstWantDate.Text);

                if (ddlConsultant.SelectedIndex > 0)
                {
                    ObjBOL.ConsultantID = Convert.ToInt32(ddlConsultant.SelectedValue);
                }

                if (ddlConsultantMember.SelectedValue != "")
                {
                    ObjBOL.ConsultantMemberID = Convert.ToInt32(ddlConsultantMember.SelectedValue);
                }

                if (ddlDealer.SelectedIndex > 0)
                {
                    ObjBOL.DealerID = Convert.ToInt32(ddlDealer.SelectedValue);
                }
                //ObjBOL.Notes = txtNotes.Text;
                ObjBOL.Compitetor = ddlCompetitor.SelectedItem.Text;
                // ObjBOL.LostedReason = ddlReason.SelectedValue;
                ObjBOL.CurrentStatus = ddlStatus.SelectedItem.Text;
                ObjBOL.Country = ddlCountry.SelectedItem.Text;
                //ObjBOL.DPics = txtProNO.Text;
                //ObjBOL.RefDrawing = txtProNO.Text;
                ObjBOL.EqDiscount = Utility.ToDouble(txtDisPer.Text);
                ObjBOL.EqDisAmount = Utility.ToDouble(txtDisAmount.Text);
                ObjBOL.NetEqPrice = Utility.ToDouble(txtNetEqPrice.Text);
                ObjBOL.Comment = txtComments.Text;
                if (ddlPreparedBy.SelectedIndex > 0)
                {
                    ObjBOL.PreparedBy = Convert.ToInt32(ddlPreparedBy.SelectedValue);
                }
                if (chkGillProject.Checked == true)
                {
                    ObjBOL.IsGillProject = true;
                }
                else
                {
                    ObjBOL.IsGillProject = false;
                }
                if (rdbSpecCredit.SelectedValue != "")
                {
                    ObjBOL.SpecCredits = Convert.ToInt32(rdbSpecCredit.SelectedValue);
                }
                else if (rdbSpecCredit.SelectedValue == "1")
                {
                    ObjBOL.SpecCredits = Convert.ToInt32(rdbSpecCredit.SelectedValue);
                }
                else
                {
                    ObjBOL.SpecCredits = null;
                }

                if (ddlSpecCredit.SelectedIndex > 0)
                {
                    ObjBOL.SpecCreditPercentID = Convert.ToInt32(ddlSpecCredit.SelectedValue);
                }
                ObjBOL.SpecCreditAmount = Utility.ToDouble(txtSpecAmount.Text);
                ObjBOL.SpecCreditCheckNo = txtSpecCheque.Text;
                ObjBOL.SpecCreditPaidDate = Utility.ConvertDate(txtSpecPaid.Text);
                //ObjBOL.dishwasherprimespec = Convert.ToInt32(ddlDishPrimeSpec.SelectedValue);
                //ObjBOL.dishwasherprimespecother = txtDishPrimeSpec.Text;
                //ObjBOL.dishmachinetype = Convert.ToInt32(ddlDishType.SelectedValue);
                //ObjBOL.dishmachinetypeother = txtDishType.Text;
                //if (ddlDishModel.SelectedIndex > 0)
                //{
                //    ObjBOL.dishmachinemodel = Convert.ToInt32(ddlDishModel.SelectedValue);
                //}

                //ObjBOL.dishwashermodelother = txtDishModel.Text;
                //if (ddlDishStyle.SelectedIndex > 0)
                //{
                //    ObjBOL.dishmachinestyle = Convert.ToInt32(ddlDishStyle.SelectedValue);
                //}
                //ObjBOL.dishmachinestyleother = txtDishStyle.Text;
                //ObjBOL.dishwasheralternate = Convert.ToInt32(ddlDishAlternate.SelectedValue);
                //ObjBOL.dishwasheralternateother = txtDishAlternate.Text;
                //ObjBOL.dishmachinetypealternate = Convert.ToInt32(ddlDishTypeAlternate.SelectedValue);
                //ObjBOL.dishmachinetypealternateother = txtDishTypeAlternate.Text;
                //if (ddlDishModelAlternate.SelectedIndex > 0)
                //{
                //    ObjBOL.dishwashermodelalternate = Convert.ToInt32(ddlDishModelAlternate.SelectedValue);
                //}
                //ObjBOL.dishwashermodelalternateother = txtDishModelAlternate.Text;
                //if (ddlDishStyleAlternate.SelectedIndex > 0)
                //{
                //    ObjBOL.dishmachinestylealternate = Convert.ToInt32(ddlDishStyleAlternate.SelectedValue);
                //}
                //ObjBOL.dishmachinestylealternateother = txtDishStyleAlternate.Text;
                //ObjBOL.wasteeqprimespec = Convert.ToInt32(ddlWastePrimeSpec.SelectedValue);
                //ObjBOL.wasteeqprimespecother = txtWastePrimeSpec.Text;
                //ObjBOL.wasteeqtype = Convert.ToInt32(ddlWasteEqType.SelectedValue);
                //ObjBOL.wasteeqtypeother = txtWasteEqType.Text;
                //if (ddlWasteEqModel.SelectedIndex > 0)
                //{
                //    ObjBOL.wasteeqmodel = Convert.ToInt32(ddlWasteEqModel.SelectedValue);
                //}
                //ObjBOL.wasteeqmodelother = txtWasteEqModel.Text;
                //if (ddlWasteEqStyle.SelectedIndex > 0)
                //{
                //    ObjBOL.wasteeqstyle = Convert.ToInt32(ddlWasteEqStyle.SelectedValue);
                //}
                //ObjBOL.wasteeqstyleother = txtWasteEqStyle.Text;
                //ObjBOL.wasteeqalternate = Convert.ToInt32(ddlWasteAlternate.SelectedValue);
                //ObjBOL.wasteeqalternateother = txtWasteEqAlternate.Text;
                //ObjBOL.wasteeqalternatetype = Convert.ToInt32(ddlWasteEqTypeAlternate.SelectedValue);
                //ObjBOL.wasteeqalternatetypeother = txtWasteEqTypeAlternate.Text;
                //if (ddlWasteEqModelAlternate.SelectedIndex > 0)
                //{
                //    ObjBOL.wasteeqmodelalternate = Convert.ToInt32(ddlWasteEqModelAlternate.SelectedValue);
                //}

                //ObjBOL.wasteeqmodelalternateother = txtWasteEqModelAlternate.Text;
                //if (ddlWasteEqStyleAlternate.SelectedIndex > 0)
                //{
                //    ObjBOL.wasteeqstylealternate = Convert.ToInt32(ddlWasteEqStyleAlternate.SelectedValue);
                //}
                //ObjBOL.wasteeqstylealternateother = txtWasteEqStyleAlternate.Text;
                ObjBOL.JobType = ddlProjectType.SelectedItem.Text;
                if (ddlExistingJobID.SelectedIndex > 0)
                {
                    ObjBOL.ExistingJobID = ddlExistingJobID.SelectedItem.Text;
                }
                ObjBOL.shipdate = Utility.ConvertDate(txtShipDate.Text);
                ObjBOL.biddate = Utility.ConvertDate(txtBidDate.Text);

                if (ddlProjectBid.SelectedIndex > 0)
                {
                    ObjBOL.bidproject = Convert.ToInt32(ddlProjectBid.SelectedValue);
                }
                if (ddlProjectManager.SelectedIndex > 0)
                {
                    ObjBOL.projectmanagerid = Convert.ToInt32(ddlProjectManager.SelectedValue);
                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Project Manager. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Select Project Manager. !");
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
                    ddlProjectManager.Focus();
                    return;
                }

                if (ddlConveyorPrimeSpec.SelectedIndex > 0)
                {
                    ObjBOL.conveyorprimespec = Convert.ToInt32(ddlConveyorPrimeSpec.SelectedValue);
                }
                ObjBOL.conveyorprimespecother = txtConveyorSpec.Text;
                if (ddlConveyorAlternate.SelectedIndex > 0)
                {
                    ObjBOL.conveyoralternate = Convert.ToInt32(ddlConveyorAlternate.SelectedValue);
                }
                ObjBOL.conveyoralternateother = txtConveyorAlternate.Text;
                if (ddlDealerMember.SelectedValue != "")
                {
                    ObjBOL.dealermemberid = Convert.ToInt32(ddlDealerMember.SelectedValue);
                }

                if (ddlSourceLead.SelectedIndex > 0)
                {
                    ObjBOL.sourceleadid = Convert.ToInt32(ddlSourceLead.SelectedValue);
                }
                if (ddlSourceleadref.SelectedIndex > 0)
                {
                    ObjBOL.sourceleadref = Convert.ToInt32(ddlSourceleadref.SelectedValue);
                }
                if (ddlIndustry.SelectedIndex > 0)
                {
                    ObjBOL.Industry = Convert.ToInt32(ddlIndustry.SelectedValue);
                }
                if (Save_Model() == true)
                {
                    msg = ObjBLL.SaveProposals(ObjBOL);
                    btnAdd.Enabled = true;
                    string strMethodRepName = "ShowMessage();";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodRepName, true);
                    if (msg == Utility.UniqueConstraintErrorCode())
                    {
                        Utility.ShowMessage_Error(Page, "PNumber already exists !!");
                    }
                    else if (msg == "1")
                    {
                        //lblMsg.Text = "Proposal Updated !!";
                        Utility.ShowMessage_Success(Page, "Proposal Updated !!");
                        //if (hdfPM.Value != ddlProjectManager.SelectedValue)
                        //{
                        //    if (hdfPM.Value == "96")
                        //    {
                        //        // 08/29/2023 (ROHIT)
                        //        //SendEmail(1);
                        //    }
                        //    else if (hdfPM.Value == "85")
                        //    {
                        //        // 08/29/2023 (ROHIT)
                        //        //SendEmail(2);
                        //    }
                        //}
                        //if (ddlProjectBid.SelectedValue == "4" || ddlProjectBid.SelectedValue == "7")
                        //{
                        //    //SendEmailSunil();
                        //}
                        if(txtProNO.Text != "")
                        {
                            Utility.MaintainLogsSpecial("FrmProposals.aspx", "Update", txtProNO.Text.Trim());
                        }                        
                    }
                    else if (msg == "0")
                    {
                        // dvMsg.Visible = true;
                        //lblMsg.Text = "Proposal Created !!";
                        Utility.ShowMessage_Success(Page, "Proposal Created !!");
                        Utility.MaintainLogsSpecial("FrmProposals.aspx", "Save", txtProNO.Text.Trim());
                    }
                    //Utility.ShowMessage(this, msg);
                    //btnSave.Text = "Save";
                    if (msg == "0" || msg == "1")
                    {
                        FillDetailsFromPnumber(txtProNO.Text);
                        FillDetails(txtProNO.Text);
                        btnSave.Text = "Update";
                        txtSearchPNum.Text = txtProNO.Text;
                        BindAndFill_Models();
                    }
                }
            }
            GetSpecConsultantandRep();
            try
            {
                SpecCredit();
            }
            catch (Exception exs)
            {
                Utility.AddEditException(exs);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Send_Email(String Message, String Subject, MailAddress sendto)
    {
        try
        {
            MailMessage message = new MailMessage(from, sendto);
            string mailbody = Message;
            //message.CC.Add(cc);
            message.Subject = Subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            // SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp
            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["Host"], 587);
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromMail"], ConfigurationManager.AppSettings["Password"]);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            client.Send(message);
            Message = string.Empty;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void Send_Email2(String Message, String Subject)
    {
        try
        {
            //Outlook.Application oApp = new Outlook.Application();
            //Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
            //Outlook.Recipients oRecips = oMsg.Recipients;
            //List<string> oTORecip = new List<string>();
            ////List<string> oCCRecip = new List<string>();
            //oTORecip.Add("rohit@aero-werks.com");
            ////oCCRecip.Add("example@test.com");
            //foreach (string t in oTORecip)
            //{
            //    Outlook.Recipient oTORecipt = oRecips.Add(t);
            //    oTORecipt.Type = (int)Outlook.OlMailRecipientType.olTo;
            //    oTORecipt.Resolve();
            //}
            //oMsg.Subject = Subject + DateTime.Today.ToString("MM/dd/yyyy");
            //oMsg.HTMLBody = Message;
            //oMsg.Save();
            //oMsg.Send();
            ////Explicitly release objects.
            //oTORecip = null;
            //oMsg = null;
            //oApp = null;
            //string msg = "";
            //ObjBOL.Operation = 5;
            //msg = ObjBLL.GenerateStatus(ObjBOL);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SendEmail(int pm)
    {
        try
        {
            string Message = string.Empty;
            string Subject = string.Empty;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 26;
            ObjBOL.PNumber = txtProNO.Text;
            ds = ObjBLL.GetProposals(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Message += "<!DOCTYPE html><html><head><title>Aerowerks</title><style>body { background-color: white;text-align: left;color: black;font-family: Arial, Helvetica, sans-serif;}";
                Message += "</style></head><body><h1>Project Manager has been updated, Please find the details below</h1>";
                // Message += "<p><b>Hey,</b></p><p><b> Project Manager has been updated, Please find the details below:</b></p>";
                Message += "<p>Proposal ID  : </strong>" + ds.Tables[0].Rows[0]["PNumber"].ToString() + "</p>";
                Message += "<p>Project Name : </strong>" + ds.Tables[0].Rows[0]["ProjectName"].ToString() + "</p>";
                Message += "<p>Updated PM   : </strong>" + ds.Tables[0].Rows[0]["NEWPM"].ToString() + "</p>";
                Message += "<p>Updated By   : </strong>" + Utility.GetCurrentSession().EmployeeName + "</p>";
                Message += "<p>Updated Time : </strong>" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "</p>";
                Message += "<p><span style='font - size:10px;'><span style='font - family:verdana,geneva,sans - serif;'><span style='color:#FF0000;'><u>" + Do_Not_Reply + "</u></span></span></span></p></body></html>";
                // 1 = Pratekk 
                if (pm == 1)
                {
                    Send_Email(Message, "Manager has been updated for your Job", sendtoPrateek);
                }
                // 2 = Ashish 
                else if (pm == 2)
                {
                    Send_Email(Message, "Manager has been updated for your Job", sendtoAshish);
                }
                Message = "";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void SendEmailSunil()
    {
        try
        {
            string Message = string.Empty;
            if (ddlProjectBid.SelectedValue == "4" || ddlProjectBid.SelectedValue == "7")
            {
                Message += "<!DOCTYPE html><html><head><title>Aerowerks</title><style>body { background-color: white;text-align: left;color: black;font-family: Arial, Helvetica, sans-serif;}";
                Message += "</style></head><body><h2>Project status changed to " + ddlProjectBid.SelectedItem.Text + "</h2>";
                // Message += "<p><b>Hey,</b></p><p><b> Project Manager has been updated, Please find the details below:</b></p>";
                Message += "<p>Proposal ID  : </strong>" + txtProNO.Text + "</p>";
                Message += "<p>Project Name : </strong>" + txtProjectName.Text + " " + txtCity.Text + " " + ddlState.SelectedItem.Text + " " + ddlCountry.SelectedItem.Text + "</p>";
                Message += "<p>Project Stage : </strong>" + ddlProjectBid.SelectedItem.Text + "</p>";
                Message += "<p><span style='font - size:10px;'><span style='font - family:verdana,geneva,sans - serif;'><span style='color:#FF0000;'><u>" + Do_Not_Reply + "</u></span></span></span></p></body></html>";
                Send_Email(Message, "Project status changed to " + ddlProjectBid.SelectedItem.Text + "", sendtoSunil);
                Message = "";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Cancel all controls.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Cancel command
    protected void btnCancel_Click(object sender, EventArgs e)
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

    // to do
    protected void ddlSpecCredit_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSpecCredit.SelectedIndex > 0)
            {
                decimal EqPrice = 0;
                if (string.IsNullOrEmpty(txtNetEqPrice.Text) == false)
                    EqPrice = Utility.ToDecimal(txtNetEqPrice.Text);

                decimal SpecPer = Convert.ToDecimal(ddlSpecCredit.SelectedItem.Text);
                decimal Amt = (EqPrice * SpecPer) / 100;
                txtSpecAmount.Text = Amt.ToString("F");
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    /// <summary>
    /// Move to the Project page
    /// AutoFill details in the Project Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //Telescopic Button JobId in Proposal Page
    protected void imgJobID_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (txtJobID.Text != "")
            {
                Session["PNumber"] = "";
                Session["PNumber"] = HfPNumber.Value;
                Response.Redirect("~/SalesManagement/FrmProjects.aspx?jid=" + txtJobID.Text, false);
            }
            else
            {
                //Utility.ShowMessage(this, "JobID not Found !!");
                Utility.ShowMessage_Error(Page, "JobID not Found !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Move forward to City Page
    /// AutoFill City Page Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    //Telescopic Button DDLCity 
    protected void ImgCity_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (txtCity.Text != "")
            {
                Session["PNumber"] = "";
                Session["PNumber"] = txtSearchPNum.Text;
                Response.Redirect("~/Administration/FrmCity.aspx?city=" + txtCity.Text, false);
            }
            else
            {
                //Utility.ShowMessage(this, "City Details not Found !!");
                Utility.ShowMessage_Error(Page, "City Details not Found !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Move to the State Page
    /// AutoFill State Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //Telescopic Button DDLState
    protected void ImgState_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ddlState.SelectedIndex > 0)
            {
                Session["PNumber"] = "";
                Session["PNumber"] = txtSearchPNum.Text;
                Response.Redirect("~/Administration/FrmState.aspx?CountryID=" + ddlCountry.SelectedValue + "&State=" + ddlState.SelectedItem.Text + "&StateAbb=" + ddlStateAb.SelectedItem.Text + "&StateID=" + ddlState.SelectedValue, false);
            }
            else
            {
                //Utility.ShowMessage(this, "State Details not Found !!");
                Utility.ShowMessage_Error(Page, "State Details not Found !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Move to the Country Page.
    ///
    /// /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //Telescopic Button DDLCountry
    protected void ImgCountry_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ddlCountry.SelectedIndex > 0)
            {
                Session["PNumber"] = "";
                Session["PNumber"] = txtSearchPNum.Text;
                Response.Redirect("~/Administration/FrmCountry.aspx?country=" + ddlCountry.SelectedItem.Text + "&CountryID=" + ddlCountry.SelectedValue, false);
            }
            else
            {
                //Utility.ShowMessage(this, "Country Details not Found !!");
                Utility.ShowMessage_Error(Page, "Country Details not Found !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Telescopic Button DDLCompetitor
    protected void ImgCompetitor_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ddlCompetitor.SelectedIndex > 0)
            {
                Session["PNumber"] = "";
                Session["PNumber"] = txtSearchPNum.Text;
                Response.Redirect("~/ContactManagement/FrmCompetitor.aspx?competitor=" + ddlCompetitor.SelectedItem.Text, false);
            }
            else
            {
                //Utility.ShowMessage(this, "Competitor Details not Found !!");
                Utility.ShowMessage_Error(Page, "Competitor Details not Found !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Move Forward to Search Proposal Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchProposal_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SalesManagement/FrmSearchProposal.aspx", false);
    }

    protected void ddlConsultantRep_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlConsultantRep.SelectedIndex > 1)
            {
                txtSpecConsultantRep.Text = ddlConsultantRep.SelectedItem.Text;
                GetSpecConsultantandRep();
                try
                {
                    SpecCredit();
                }
                catch (Exception exs)
                {
                    Utility.AddEditException(exs);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public class ConsultantMember
    {
        String _ConsultantMemberName;
        public String ConsultantMemberName
        {
            get { return _ConsultantMemberName; }
            set { _ConsultantMemberName = value; }
        }
    }

    public class ConsultantRep
    {
        Int32 _Repid;
        public Int32 Repid
        {
            get { return _Repid; }
            set { _Repid = value; }
        }
        String _FirstName;
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        String _LastName;
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        Int32 _AbbreviationID;
        public Int32 AbbreviationID
        {
            get { return _AbbreviationID; }
            set { _AbbreviationID = value; }
        }
        String _AbbreviationName;
        public String AbbreviationName
        {
            get { return _AbbreviationName; }
            set { _AbbreviationName = value; }
        }
        String _PhoneMail;
        public String PhoneMail
        {
            get { return _PhoneMail; }
            set { _PhoneMail = value; }
        }
        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        String _CellPhone;
        public String CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        String _Status;
        public String Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        String _RepState;
        public String RepState
        {
            get { return _RepState; }
            set { _RepState = value; }
        }
        //RepState
    }

    /// <summary>
    /// GetConsultantRepDetails Method used for Rep Information like Name,Address,Phone Number etc
    /// </summary>
    /// <param name="Repid">
    /// Rep id used for get the particular Consultant Rep Details
    /// </param>
    /// <returns>List of Consultant Rep Details </returns>
    [WebMethod]
    public static List<ConsultantRep> GetConsultantRepDetails(Int32 Repid)
    {
        List<ConsultantRep> dbConsultantRep = new List<ConsultantRep>();

        try
        {
            DataSet ds = new DataSet();
            ds = Utility.GetConsultantRepPopUp(Repid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ConsultantRep emp = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    emp = new ConsultantRep();
                    //emp.Repid = Convert.ToInt32(ds.Tables[0].Rows[i]["Repid"]);
                    emp.FirstName = Convert.ToString(ds.Tables[0].Rows[i]["RepName"]);
                    emp.AbbreviationID = Convert.ToInt32(ds.Tables[0].Rows[i]["AbbreviationID"]);
                    emp.AbbreviationName = Convert.ToString(ds.Tables[0].Rows[i]["AbbreviationName"]);
                    emp.PhoneMail = Convert.ToString(ds.Tables[0].Rows[i]["PhoneMail"]);
                    emp.Phone = Convert.ToString(ds.Tables[0].Rows[i]["Phone"]);
                    emp.CellPhone = Convert.ToString(ds.Tables[0].Rows[i]["CellPhone"]);
                    emp.Fax = Convert.ToString(ds.Tables[0].Rows[i]["Fax"]);
                    emp.Email = Convert.ToString(ds.Tables[0].Rows[i]["Email"]);
                    emp.Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]);
                    emp.RepState = Convert.ToString(ds.Tables[0].Rows[i]["RepState"]);
                    dbConsultantRep.Add(emp);

                }
            }


        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dbConsultantRep;
    }

    public class OriginationRep
    {
        Int32 _Repid;
        public Int32 Repid
        {
            get { return _Repid; }
            set { _Repid = value; }
        }
        String _FirstName;
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        String _LastName;
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        Int32 _AbbreviationID;
        public Int32 AbbreviationID
        {
            get { return _AbbreviationID; }
            set { _AbbreviationID = value; }
        }
        String _AbbreviationName;
        public String AbbreviationName
        {
            get { return _AbbreviationName; }
            set { _AbbreviationName = value; }
        }
        String _PhoneMail;
        public String PhoneMail
        {
            get { return _PhoneMail; }
            set { _PhoneMail = value; }
        }
        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        String _CellPhone;
        public String CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        String _Status;
        public String Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        String _OriginationState;
        public String OriginationState
        {
            get { return _OriginationState; }
            set { _OriginationState = value; }
        }
        String _RepState;
        public String RepState
        {
            get { return _RepState; }
            set { _RepState = value; }
        }
    }

    /// <summary>
    /// GetOriginationRepDetails Method used for Rep Information like Name,Address,Phone Number etc
    /// </summary>
    /// <param name="Repid"></param>
    /// <returns>Return List</returns>
    [WebMethod]
    public static List<OriginationRep> GetOriginationRepDetails(Int32 Repid)
    {
        List<OriginationRep> dbOriginationRep = new List<OriginationRep>();

        try
        {
            DataSet ds = new DataSet();
            ds = Utility.GetOriginationRepPopUp(Repid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                OriginationRep emp = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    emp = new OriginationRep();
                    //emp.Repid = Convert.ToInt32(ds.Tables[0].Rows[i]["Repid"]);
                    emp.FirstName = Convert.ToString(ds.Tables[0].Rows[i]["RepName"]);
                    emp.AbbreviationID = Convert.ToInt32(ds.Tables[0].Rows[i]["AbbreviationID"]);
                    emp.AbbreviationName = Convert.ToString(ds.Tables[0].Rows[i]["AbbreviationName"]);
                    emp.PhoneMail = Convert.ToString(ds.Tables[0].Rows[i]["PhoneMail"]);
                    emp.Phone = Convert.ToString(ds.Tables[0].Rows[i]["Phone"]);
                    emp.CellPhone = Convert.ToString(ds.Tables[0].Rows[i]["CellPhone"]);
                    emp.Fax = Convert.ToString(ds.Tables[0].Rows[i]["Fax"]);
                    emp.Email = Convert.ToString(ds.Tables[0].Rows[i]["Email"]);
                    emp.Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]);
                    emp.RepState = Convert.ToString(ds.Tables[0].Rows[i]["RepState"]);
                    dbOriginationRep.Add(emp);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dbOriginationRep;
    }

    public class DestinationRep
    {
        Int32 _Repid;
        public Int32 Repid
        {
            get { return _Repid; }
            set { _Repid = value; }
        }
        String _FirstName;
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        String _LastName;
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        Int32 _AbbreviationID;
        public Int32 AbbreviationID
        {
            get { return _AbbreviationID; }
            set { _AbbreviationID = value; }
        }
        String _AbbreviationName;
        public String AbbreviationName
        {
            get { return _AbbreviationName; }
            set { _AbbreviationName = value; }
        }
        String _PhoneMail;
        public String PhoneMail
        {
            get { return _PhoneMail; }
            set { _PhoneMail = value; }
        }
        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        String _CellPhone;
        public String CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        String _Status;
        public String Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        String _RepState;
        public String RepState
        {
            get { return _RepState; }
            set { _RepState = value; }
        }
    }

    /// <summary>
    /// GetDestinationRepDetails Method Returns Particular information List in Pop Up Modal Dialog Box
    /// </summary>
    /// <param name="Repid">
    /// Return Particular Rep Id
    /// </param>
    /// <returns>List Return</returns>
    [WebMethod]
    public static List<DestinationRep> GetDestinationRepDetails(Int32 Repid)
    {
        List<DestinationRep> dbDestinationRep = new List<DestinationRep>();

        try
        {
            DataSet ds = new DataSet();
            ds = Utility.GetDestinationRepPopUp(Repid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DestinationRep emp = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    emp = new DestinationRep();
                    //emp.Repid = Convert.ToInt32(ds.Tables[0].Rows[i]["Repid"]);
                    emp.FirstName = Convert.ToString(ds.Tables[0].Rows[i]["RepName"]);
                    emp.AbbreviationID = Convert.ToInt32(ds.Tables[0].Rows[i]["AbbreviationID"]);
                    emp.AbbreviationName = Convert.ToString(ds.Tables[0].Rows[i]["AbbreviationName"]);
                    emp.PhoneMail = Convert.ToString(ds.Tables[0].Rows[i]["PhoneMail"]);
                    emp.Phone = Convert.ToString(ds.Tables[0].Rows[i]["Phone"]);
                    emp.CellPhone = Convert.ToString(ds.Tables[0].Rows[i]["CellPhone"]);
                    emp.Fax = Convert.ToString(ds.Tables[0].Rows[i]["Fax"]);
                    emp.Email = Convert.ToString(ds.Tables[0].Rows[i]["Email"]);
                    emp.Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]);
                    emp.RepState = Convert.ToString(ds.Tables[0].Rows[i]["RepState"]);
                    dbDestinationRep.Add(emp);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dbDestinationRep;
    }

    public class Dealer
    {
        Int32 _DealerID;
        public Int32 DealerID
        {
            get { return _DealerID; }
            set { _DealerID = value; }
        }
        String _FederalID;
        public String FederalID
        {
            get { return _FederalID; }
            set { _FederalID = value; }
        }
        String _CompanyName;
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
        String _GroupName;
        public String GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
        String _StreetAddress;
        public String StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }
        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
        String _Country;
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
        String _TollFree;
        public String TollFree
        {
            get { return _TollFree; }
            set { _TollFree = value; }
        }
        String _TollFax;
        public String TollFax
        {
            get { return _TollFax; }
            set { _TollFax = value; }
        }
        String _DealerPhone;
        public String DealerPhone
        {
            get { return _DealerPhone; }
            set { _DealerPhone = value; }
        }
        String _DealerFax;
        public String DealerFax
        {
            get { return _DealerFax; }
            set { _DealerFax = value; }
        }
        String _RepName;
        public String RepName
        {
            get { return _RepName; }
            set { _RepName = value; }
        }
        String _DealerState;
        public String DealerState
        {
            get { return _DealerState; }
            set { _DealerState = value; }
        }
    }

    /// <summary>
    /// GetDealerDetails() Method to prepare List of entries of Particlar Dealar.
    /// In the prepared list get information of Dealer like name,address etc in the pop-up window.
    /// </summary>
    /// <param name="DealerID">Return id of selected dealer</param>
    /// <returns>List Return</returns>
    [WebMethod]
    public static List<Dealer> GetDealerDetails(Int32 DealerID)
    {
        List<Dealer> dbDealers = new List<Dealer>();

        try
        {
            DataSet ds = new DataSet();
            ds = Utility.GetDealerDetailPopUp(DealerID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Dealer emp = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    emp = new Dealer();
                    emp.FederalID = Convert.ToString(ds.Tables[0].Rows[i]["FederalID"]);
                    emp.CompanyName = Convert.ToString(ds.Tables[0].Rows[i]["CompanyName"]);
                    emp.GroupName = Convert.ToString(ds.Tables[0].Rows[i]["GroupName"]);
                    emp.StreetAddress = Convert.ToString(ds.Tables[0].Rows[i]["StreetAddress"]);
                    emp.City = Convert.ToString(ds.Tables[0].Rows[i]["City"]);
                    emp.Country = Convert.ToString(ds.Tables[0].Rows[i]["Country"]);
                    emp.TollFree = Convert.ToString(ds.Tables[0].Rows[i]["TollFree"]);
                    emp.TollFax = Convert.ToString(ds.Tables[0].Rows[i]["TollFax"]);
                    emp.DealerPhone = Convert.ToString(ds.Tables[0].Rows[i]["Phone"]);
                    emp.DealerFax = Convert.ToString(ds.Tables[0].Rows[i]["Fax"]);
                    emp.RepName = Convert.ToString(ds.Tables[0].Rows[i]["RepName"]);
                    emp.DealerState = Convert.ToString(ds.Tables[0].Rows[i]["DealerState"]);
                    dbDealers.Add(emp);

                }
            }


        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dbDealers;
    }

    public class DealerMember
    {
        Int32 _ContactID;
        public Int32 ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }
        String _Title;
        public String Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        String _FName;
        public String FName
        {
            get { return _FName; }
            set { _FName = value; }
        }
        String _LName;
        public String LName
        {
            get { return _LName; }
            set { _LName = value; }
        }
        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        String _email;
        public String email
        {
            get { return _email; }
            set { _email = value; }
        }
        String _DealerMemberState;
        public String DealerMemberState
        {
            get { return _DealerMemberState; }
            set { _DealerMemberState = value; }
        }

    }

    [WebMethod]
    public static List<DealerMember> GetDealerMemberDetails(Int32 DealerMemberID)
    {
        List<DealerMember> dbDealerMember = new List<DealerMember>();

        try
        {
            DataSet ds = new DataSet();
            ds = Utility.GetDealerMemberDetailPopUp(DealerMemberID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DealerMember emp = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    emp = new DealerMember();
                    emp.ContactID = Convert.ToInt32(ds.Tables[0].Rows[i]["ContactID"]);
                    emp.Title = Convert.ToString(ds.Tables[0].Rows[i]["Title"]);
                    emp.FName = Convert.ToString(ds.Tables[0].Rows[i]["DealerMemberName"]);
                    emp.Phone = Convert.ToString(ds.Tables[0].Rows[i]["Phone"]);
                    emp.Fax = Convert.ToString(ds.Tables[0].Rows[i]["Fax"]);
                    emp.email = Convert.ToString(ds.Tables[0].Rows[i]["email"]);
                    dbDealerMember.Add(emp);

                }
            }


        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dbDealerMember;
    }

    public class Consultant
    {
        Int32 _ConsultantID;
        public Int32 ConsultantID
        {
            get { return _ConsultantID; }
            set { _ConsultantID = value; }
        }
        String _CompanyName;
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
        String _StreetAdd;
        public String StreetAdd
        {
            get { return _StreetAdd; }
            set { _StreetAdd = value; }
        }
        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
        String _Country;
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        String _TollFree;
        public String TollFree
        {
            get { return _TollFree; }
            set { _TollFree = value; }
        }
        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        String _TollFax;
        public String TollFax
        {
            get { return _TollFax; }
            set { _TollFax = value; }
        }
        String _RepName;
        public String RepName
        {
            get { return _RepName; }
            set { _RepName = value; }
        }
        String _ConsultantState;
        public String ConsultantState
        {
            get { return _ConsultantState; }
            set { _ConsultantState = value; }
        }

    }
    /// <summary>
    /// GetConsultantDetails() Method to prepare List of entries of Particlar Consultant.
    /// In the prepared list get information of Consultant like name,address etc in the pop-up window.
    /// </summary>
    /// <param name="ConsultantID">Return id of selected Consultant</param>
    /// <returns>List Return</returns>
    [WebMethod]
    public static List<Consultant> GetConsultantDetails(Int32 ConsultantID)
    {
        List<Consultant> dbConsulatnt = new List<Consultant>();

        try
        {
            DataSet ds = new DataSet();
            ds = Utility.GetConsultantPopUp(ConsultantID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Consultant emp = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    emp = new Consultant();
                    //emp.Repid = Convert.ToInt32(ds.Tables[0].Rows[i]["Repid"]);
                    emp.CompanyName = Convert.ToString(ds.Tables[0].Rows[i]["CompanyName"]);
                    emp.StreetAdd = Convert.ToString(ds.Tables[0].Rows[i]["StreetAdd"]);
                    emp.City = Convert.ToString(ds.Tables[0].Rows[i]["City"]);
                    emp.Country = Convert.ToString(ds.Tables[0].Rows[i]["Country"]);
                    emp.Phone = Convert.ToString(ds.Tables[0].Rows[i]["Phone"]);
                    emp.TollFree = Convert.ToString(ds.Tables[0].Rows[i]["TollFree"]);
                    emp.Fax = Convert.ToString(ds.Tables[0].Rows[i]["Fax"]);
                    emp.TollFax = Convert.ToString(ds.Tables[0].Rows[i]["TollFax"]);
                    emp.RepName = Convert.ToString(ds.Tables[0].Rows[i]["RepName"]);
                    emp.ConsultantState = Convert.ToString(ds.Tables[0].Rows[i]["ConsultantState"]);
                    dbConsulatnt.Add(emp);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dbConsulatnt;
    }

    public class Customer
    {
        Int32 _CustomerID;
        public Int32 CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        String _CompanyName;
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
        String _StreetAddress;
        public String StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }
        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
        String _Country;
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
        String _TollFree;
        public String TollFree
        {
            get { return _TollFree; }
            set { _TollFree = value; }
        }
        String _TollFax;
        public String TollFax
        {
            get { return _TollFax; }
            set { _TollFax = value; }
        }
        String _MainPhone;
        public String MainPhone
        {
            get { return _MainPhone; }
            set { _MainPhone = value; }
        }
        String _MainFax;
        public String MainFax
        {
            get { return _MainFax; }
            set { _MainFax = value; }
        }
        String _Branch;
        public String Branch
        {
            get { return _Branch; }
            set { _Branch = value; }
        }
        String _RepName;
        public String RepName
        {
            get { return _RepName; }
            set { _RepName = value; }
        }
    }
    /// <summary>
    /// GetCustomerDetails() Method to prepare List of entries of Particlar Customer.
    /// In the prepared list get information of Customer like name,address etc in the pop-up window.
    /// </summary>
    /// <param name="CustomerID">Customer id used to get data of paricular Customer</param>
    /// <returns>Return List</returns>
    [WebMethod]
    public static List<Customer> GetCustomerDetails(Int32 CustomerID)
    {
        List<Customer> dbCustomer = new List<Customer>();

        try
        {
            DataSet ds = new DataSet();
            ds = Utility.GetCustomerPopUp(CustomerID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Customer emp = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    emp = new Customer();
                    //emp.Repid = Convert.ToInt32(ds.Tables[0].Rows[i]["Repid"]);
                    emp.CompanyName = Convert.ToString(ds.Tables[0].Rows[i]["CompanyName"]);
                    emp.StreetAddress = Convert.ToString(ds.Tables[0].Rows[i]["StreetAddress"]);
                    emp.City = Convert.ToString(ds.Tables[0].Rows[i]["City"]);
                    emp.Country = Convert.ToString(ds.Tables[0].Rows[i]["Country"]);
                    emp.TollFree = Convert.ToString(ds.Tables[0].Rows[i]["TollFree"]);
                    emp.TollFax = Convert.ToString(ds.Tables[0].Rows[i]["TollFax"]);
                    emp.MainPhone = Convert.ToString(ds.Tables[0].Rows[i]["MainPhone"]);
                    emp.MainFax = Convert.ToString(ds.Tables[0].Rows[i]["MainFax"]);
                    emp.Branch = Convert.ToString(ds.Tables[0].Rows[i]["Branch"]);
                    emp.RepName = Convert.ToString(ds.Tables[0].Rows[i]["RepName"]);
                    dbCustomer.Add(emp);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dbCustomer;
    }

    private void GetState(string Countryid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Country = Countryid;
            HfCountryid.Value = Countryid;
            ObjBOL.Operation = 11;
            ds = ObjBLL.GetStates(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlState, ds.Tables[0]);
                Utility.BindDropDownList(ddlStateAb, ds.Tables[0]);
                ddlState.SelectedIndex = 0;
                ddlStateAb.SelectedIndex = 0;
            }
            else
            {
                if (ddlState.Items.Count > 0)
                {
                    ddlState.Items.Clear();
                    ddlStateAb.Items.Clear();
                }

            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCountry.SelectedIndex > 0)
            {
                GetState(ddlCountry.SelectedValue);
                GetSpecConsultantandRep();
                try
                {
                    SpecCredit();
                }
                catch (Exception exs)
                {
                    Utility.AddEditException(exs);
                }
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    //private void Bind_DishTypeFeatures(string Dishtype)
    //{
    //    try
    //    {
    //        ObjBOL.Operation = 13;
    //        ObjBOL.typeid = Convert.ToInt32(Dishtype);
    //        DataSet ds = new DataSet();
    //        ds = ObjBLL.GetTypeid(ObjBOL);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            Utility.BindDropDownList(ddlDishModel, ds.Tables[0]);
    //        }
    //        else
    //        {
    //            ddlDishModel.DataSource = "";
    //            ddlDishModel.DataBind();
    //        }
    //        if (ds.Tables[1].Rows.Count > 0)
    //        {
    //            Utility.BindDropDownList(ddlDishStyle, ds.Tables[1]);
    //        }
    //        else
    //        {
    //            ddlDishStyle.DataSource = "";
    //            ddlDishStyle.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }
    //}

    //private void Bind_AlternateFeatures(string DishAlternate)
    //{
    //    try
    //    {
    //        ObjBOL.Operation = 13;
    //        ObjBOL.typeid = Convert.ToInt32(DishAlternate);
    //        DataSet ds = new DataSet();
    //        ds = ObjBLL.GetTypeid(ObjBOL);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            Utility.BindDropDownList(ddlDishModelAlternate, ds.Tables[0]);
    //        }
    //        else
    //        {
    //            ddlDishModelAlternate.DataSource = "";
    //            ddlDishModelAlternate.DataBind();
    //        }
    //        if (ds.Tables[1].Rows.Count > 0)
    //        {
    //            Utility.BindDropDownList(ddlDishStyleAlternate, ds.Tables[1]);
    //        }
    //        else
    //        {
    //            ddlDishStyleAlternate.DataSource = "";
    //            ddlDishStyleAlternate.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }
    //}

    ////ddlDishPrimeSpec
    //protected void ddlDishPrimeSpec_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlDishPrimeSpec.SelectedItem.Text == "Other")
    //        {
    //            pnlDishPrimeSpec.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            pnlDishPrimeSpec.Attributes.Add("style", "display:none");
    //            txtDishPrimeSpec.Text = String.Empty;
    //        }
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }
    //}

    ////ddlDishAlternate
    //protected void ddlDishAlternate_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlDishAlternate.SelectedItem.Text == "Other")
    //        {
    //            pnlDishAlternate.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            pnlDishAlternate.Attributes.Add("style", "display:none");
    //            txtDishAlternate.Text = String.Empty;
    //        }
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }
    //}

    ////ddlDishTypeAlternate
    //protected void ddlDishType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlDishType.SelectedItem.Text == "Other")
    //        {
    //            pnlDishType.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            pnlDishType.Attributes.Add("style", "display:none");
    //            txtDishType.Text = String.Empty;
    //        }
    //        Bind_DishTypeFeatures(ddlDishType.SelectedValue);
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }
    //}

    //protected void ddlDishTypeAlternate_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlDishTypeAlternate.SelectedItem.Text == "Other")
    //        {
    //            pnlDishTypeAlternate.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            pnlDishTypeAlternate.Attributes.Add("style", "display:none");
    //            txtDishTypeAlternate.Text = String.Empty;
    //        }
    //        Bind_AlternateFeatures(ddlDishTypeAlternate.SelectedValue);
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }
    //}

    ////ddlDishModel
    //protected void ddlDishModel_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlDishModel.SelectedItem.Text == "Other")
    //        {
    //            pnlDishModel.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            pnlDishModel.Attributes.Add("style", "display:none");
    //            txtDishModel.Text = String.Empty;
    //        }
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }
    //}

    ////ddlDishModelAlternate
    //protected void ddlDishModelAlternate_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlDishModelAlternate.SelectedItem.Text == "Other")
    //        {
    //            pnlDishModelAlternate.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            pnlDishModelAlternate.Attributes.Add("style", "display:none");
    //            txtDishModelAlternate.Text = String.Empty;
    //        }
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}

    ////ddlDishStyle
    //protected void ddlDishStyle_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlDishStyle.SelectedItem.Text == "Other")
    //        {
    //            pnlDishStyle.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            pnlDishStyle.Attributes.Add("style", "display:none");
    //            txtDishStyle.Text = String.Empty;
    //        }
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }
    //}

    ////ddlDishStyleAlternate
    //protected void ddlDishStyleAlternate_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlDishStyleAlternate.SelectedItem.Text == "Other")
    //        {
    //            pnlDishStyleAlternate.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            pnlDishStyleAlternate.Attributes.Add("style", "display:none");
    //            txtDishStyleAlternate.Text = String.Empty;
    //        }
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }
    //}

    ////ddlWastePrimeSpec
    //protected void ddlWastePrimeSpec_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlWastePrimeSpec.SelectedItem.Text == "Other")
    //        {
    //            pnlWastePrimeSpec.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            pnlWastePrimeSpec.Attributes.Add("style", "display:none");
    //            txtWastePrimeSpec.Text = String.Empty;
    //        }
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }
    //}

    ////ddlWasteAlternate
    //protected void ddlWasteAlternate_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlWasteAlternate.SelectedItem.Text == "Other")
    //        {
    //            PanelWasteEqAlternate.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            PanelWasteEqAlternate.Attributes.Add("style", "display:none");
    //            txtWasteEqAlternate.Text = String.Empty;
    //        }
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}

    //protected void ddlWasteEqType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlWasteEqType.SelectedItem.Text == "Other")
    //        {
    //            pnlWasteEqType.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            pnlWasteEqType.Attributes.Add("style", "display:none");
    //            txtWasteEqType.Text = String.Empty;
    //        }
    //        Bind_WasteEqTypeFeatures(ddlWasteEqType.SelectedValue);
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}

    ////ddlWasteEqTypeAlternate
    //protected void ddlWasteEqTypeAlternate_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlWasteEqTypeAlternate.SelectedItem.Text == "Other")
    //        {
    //            PanelWasteEqType.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            PanelWasteEqType.Attributes.Add("style", "display:none");
    //            txtWasteEqTypeAlternate.Text = String.Empty;
    //        }
    //        WasteEqTypeAlternate(ddlWasteEqTypeAlternate.SelectedValue);
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }
    //}

    ////ddlWasteEqModel
    //protected void ddlWasteEqModel_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlWasteEqModel.SelectedItem.Text == "Other")
    //        {
    //            pnlWasteEqModel.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            pnlWasteEqModel.Attributes.Add("style", "display:none");
    //            txtWasteEqModel.Text = String.Empty;
    //        }
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}

    ////ddlWasteEqModelAlternate
    //protected void ddlWasteEqModelAlternate_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlWasteEqModelAlternate.SelectedItem.Text == "Other")
    //        {
    //            PanelWasteEqModelAlternate.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            PanelWasteEqModelAlternate.Attributes.Add("style", "display:none");
    //            txtWasteEqModelAlternate.Text = String.Empty;
    //        }
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}

    ////ddlWasteEqStyle
    //protected void ddlWasteEqStyle_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlWasteEqStyle.SelectedItem.Text == "Other")
    //        {
    //            PanelWasteEqStyle.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            PanelWasteEqStyle.Attributes.Add("style", "display:none");
    //            txtWasteEqStyle.Text = String.Empty;
    //        }
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}

    ////ddlWasteEqStyleAlternate
    //protected void ddlWasteEqStyleAlternate_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlWasteEqStyleAlternate.SelectedItem.Text == "Other")
    //        {
    //            PanelWasteEqStyleAlternate.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            PanelWasteEqStyleAlternate.Attributes.Add("style", "display:none");
    //            txtWasteEqStyleAlternate.Text = String.Empty;
    //        }
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
    //        GetSpecConsultantandRep();
    //        try
    //        {
    //            SpecCredit();
    //        }
    //        catch (Exception exs)
    //        {
    //            Utility.AddEditException(exs);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}

    //private void Bind_WasteEqTypeFeatures(string WasteEqType)
    //{
    //    try
    //    {
    //        ObjBOL.Operation = 14;
    //        ObjBOL.WasteEqTypeid = Convert.ToInt32(WasteEqType);
    //        DataSet ds = new DataSet();
    //        ds = ObjBLL.GetWasteEqTypeid(ObjBOL);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            Utility.BindDropDownList(ddlWasteEqModel, ds.Tables[0]);
    //        }
    //        else
    //        {
    //            ddlWasteEqModel.DataSource = "";
    //            ddlWasteEqModel.DataBind();
    //        }
    //        if (ds.Tables[1].Rows.Count > 0)
    //        {
    //            Utility.BindDropDownList(ddlWasteEqStyle, ds.Tables[1]);
    //        }
    //        else
    //        {
    //            ddlWasteEqStyle.DataSource = "";
    //            ddlWasteEqStyle.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }
    //}

    //private void WasteEqTypeAlternate(string WasteEqAlternateFeatures)
    //{
    //    try
    //    {
    //        ObjBOL.Operation = 14;
    //        ObjBOL.WasteEqTypeid = Convert.ToInt32(WasteEqAlternateFeatures);
    //        DataSet ds = new DataSet();
    //        ds = ObjBLL.GetWasteEqTypeid(ObjBOL);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            Utility.BindDropDownList(ddlWasteEqModelAlternate, ds.Tables[0]);
    //        }
    //        else
    //        {
    //            ddlWasteEqModelAlternate.DataSource = "";
    //            ddlWasteEqModelAlternate.DataBind();
    //        }
    //        if (ds.Tables[1].Rows.Count > 0)
    //        {
    //            Utility.BindDropDownList(ddlWasteEqStyleAlternate, ds.Tables[1]);
    //        }
    //        else
    //        {
    //            ddlWasteEqStyleAlternate.DataSource = "";
    //            ddlWasteEqStyleAlternate.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }
    //}

    [System.Web.Services.WebMethod]
    public static List<Model> GetModels(string TypeID)
    {
        List<Model> model = new List<Model>();
        Model country = new Model();
        commonclass1 cls = new commonclass1();
        DataSet ds = new DataSet();
        ds = cls.Get_DS("SELECT id,name FROM tblDishmachineModel WHERE typeid=" + TypeID + "  ORDER BY name ");

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Model models = new Model();
            models.name = ds.Tables[0].Rows[i]["name"].ToString();
            models.Id = ds.Tables[0].Rows[i]["id"].ToString();
            model.Add(models);
        }
        return model;
    }

    [System.Web.Services.WebMethod]
    public static List<Model> GetModelsAlternate(string TypeID)
    {
        List<Model> model = new List<Model>();
        Model country = new Model();
        commonclass1 cls = new commonclass1();
        DataSet ds = new DataSet();
        ds = cls.Get_DS("SELECT id,name FROM tblDishmachineModel WHERE typeid=" + TypeID + "  ORDER BY name ");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Model models = new Model();
            models.name = ds.Tables[0].Rows[i]["name"].ToString();
            models.Id = ds.Tables[0].Rows[i]["id"].ToString();
            model.Add(models);
        }
        return model;
    }

    [System.Web.Services.WebMethod]
    public static List<Model> BindStyles(string TypeID)
    {
        List<Model> model = new List<Model>();
        Model country = new Model();
        commonclass1 cls = new commonclass1();
        DataSet ds = new DataSet();
        ds = cls.Get_DS("SELECT id,name FROM tblDishmachineStyle WHERE typeid=" + TypeID + " ORDER BY sortorder ");

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Model models = new Model();
            models.name = ds.Tables[0].Rows[i]["name"].ToString();
            models.Id = ds.Tables[0].Rows[i]["id"].ToString();
            model.Add(models);
        }
        return model;
    }

    [System.Web.Services.WebMethod]
    public static List<Model> BindStylesAlternate(string TypeID)
    {
        List<Model> model = new List<Model>();
        Model country = new Model();
        commonclass1 cls = new commonclass1();
        DataSet ds = new DataSet();
        ds = cls.Get_DS("SELECT id,name FROM tblDishmachineStyle WHERE typeid=" + TypeID + " ORDER BY sortorder ");

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Model models = new Model();
            models.name = ds.Tables[0].Rows[i]["name"].ToString();
            models.Id = ds.Tables[0].Rows[i]["id"].ToString();
            model.Add(models);
        }
        return model;
    }

    [System.Web.Services.WebMethod]
    public static List<Model> BindWasteEqModel(string TypeID)
    {
        List<Model> model = new List<Model>();
        Model country = new Model();
        commonclass1 cls = new commonclass1();
        DataSet ds = new DataSet();
        ds = cls.Get_DS("SELECT id,name FROM tblWasteEqModel WHERE typeid=" + TypeID + " ORDER BY id ");

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Model models = new Model();
            models.name = ds.Tables[0].Rows[i]["name"].ToString();
            models.Id = ds.Tables[0].Rows[i]["id"].ToString();
            model.Add(models);
        }
        return model;
    }

    [System.Web.Services.WebMethod]
    public static List<Model> BindWasteEqStyle(string TypeID)
    {
        List<Model> model = new List<Model>();
        Model country = new Model();
        commonclass1 cls = new commonclass1();
        DataSet ds = new DataSet();
        ds = cls.Get_DS("SELECT id,name FROM tblWasteEqStyle WHERE typeid=" + TypeID + " ORDER BY id ");

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Model models = new Model();
            models.name = ds.Tables[0].Rows[i]["name"].ToString();
            models.Id = ds.Tables[0].Rows[i]["id"].ToString();
            model.Add(models);
        }
        return model;
    }

    public class Model
    {
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }

    private void BindConsultantMember()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 12;
            ObjBOL.ConsultantID = Convert.ToInt32(ddlConsultant.SelectedValue);
            ds = ObjBLL.GetConsultantMember(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConsultantMember, ds.Tables[0]);
            }
            else
            {
                ddlConsultantMember.DataSource = "";
                ddlConsultantMember.DataBind();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                ddlConsultantRep.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["TSM"]);
            }
            else
            {
                ddlConsultantRep.SelectedIndex = 0;
            }
            txtSpecConsultant.Text = ddlConsultant.SelectedItem.Text;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetSpecConsultantandRep()
    {
        try
        {
            string strMethodName = "GetConsultant();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
            string strMethodRepName = "GetConsultantRep();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodRepName, true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlConsultant_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindConsultantMember();
            GetSpecConsultantandRep();
            try
            {
                SpecCredit();
            }
            catch (Exception exs)
            {
                Utility.AddEditException(exs);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetDealerMember(string Dealer)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 20;
            ObjBOL.DealerID = Convert.ToInt32(Dealer);
            ds = ObjBLL.GetDealerMember(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDealerMember, ds.Tables[0]);
            }
            else
            {
                ddlDealerMember.DataSource = "";
                ddlDealerMember.DataBind();
            }
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    ddlOriginationRep.SelectedValue = Convert.ToString(ds.Tables[1].Rows[0]["TSM"]);
            //}
            //else
            //{
            //    ddlOriginationRep.SelectedIndex = 0;
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SpecCredit()
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                // Enable for 28 = Sunil only (16 AUG 2022) 
                string strMethodName2 = "EnableDisableSpecCredit();";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName2, true);

                string strMethodName = "getCheckedRadio();";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
                //EnableDisableSpecCredit()
                string CRuser = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
                if (CRuser == "28")
                {
                    rdbSpecCredit.Enabled = true;
                }
                else
                {
                    rdbSpecCredit.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    protected void ddlDealer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetDealerMember(ddlDealer.SelectedValue);
            GetSpecConsultantandRep();
            //getCheckedRadio()
            try
            {
                SpecCredit();
            }
            catch (Exception exs)
            {
                Utility.AddEditException(exs);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlProjectBid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ddlProjectBid.SelectedValue == "3")
            //{
            //    //ddlStatus.Visible = true;
            //    GetSpecConsultantandRep();
            //    SpecCredit();
            //}
            //else
            //{
            //    //divBiddate.Visible = false;
            //    //txtBidDate.Text = String.Empty;
            //    GetSpecConsultantandRep();
            //    SpecCredit();
            //}
            GetSpecConsultantandRep();
            try
            {
                SpecCredit();
            }
            catch (Exception exs)
            {
                Utility.AddEditException(exs);
            }
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public class ConsultantMemberDetail
    {
        String _JobTitle;
        public String JobTitle
        {
            get { return _JobTitle; }
            set { _JobTitle = value; }
        }
        String _FirstName;
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        String _LastName;
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        String _TelephoneExtension;
        public String TelephoneExtension
        {
            get { return _TelephoneExtension; }
            set { _TelephoneExtension = value; }
        }
        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        String _DirectLine;
        public String DirectLine
        {
            get { return _DirectLine; }
            set { _DirectLine = value; }
        }
    }
    /// <summary>
    /// Get ConsultantMemberDetails() function dispaly particular Member of Consultant Rep
    /// </summary>
    /// <param name="ConsultantID"></param>
    /// <returns></returns>
    [WebMethod]
    public static List<ConsultantMemberDetail> GetConsultantMember(String ConsultantID)
    {
        List<ConsultantMemberDetail> dbConsulatntMember = new List<ConsultantMemberDetail>();
        try
        {
            DataSet ds = new DataSet();
            if (ConsultantID != "")
            {
                Int32 Conid = Convert.ToInt32(ConsultantID);
                ds = Utility.GetConsultantMember(Conid);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ConsultantMemberDetail emp = null;
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        emp = new ConsultantMemberDetail();
                        //emp.Repid = Convert.ToInt32(ds.Tables[1].Rows[i]["Repid"]);
                        emp.JobTitle = Convert.ToString(ds.Tables[1].Rows[i]["JobTitle"]);
                        emp.FirstName = Convert.ToString(ds.Tables[1].Rows[i]["ConsultantMemberName"]);
                        //emp.LastName = Convert.ToString(ds.Tables[1].Rows[i]["LastName"]);
                        emp.TelephoneExtension = Convert.ToString(ds.Tables[1].Rows[i]["TelephoneExtension"]);
                        emp.Email = Convert.ToString(ds.Tables[1].Rows[i]["Email"]);
                        emp.DirectLine = Convert.ToString(ds.Tables[1].Rows[i]["DirectLine"]);
                        dbConsulatntMember.Add(emp);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dbConsulatntMember;
    }

    protected void txtSearchPName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtSearchPName.Text != "")
            {
                ResetN();
                HfPNumber.Value = string.Empty;
                string output = txtSearchPName.Text;
                int openTagEndPosition = output.IndexOf("#");
                output = output.Substring(openTagEndPosition + 1);
                FillDetailsFromPnumber(output);
                btnSave.Text = "Update";
                //FillDetails(txtSearchPName.Text);
                FillDetails(output);
                Bind_GridProDwgs(output);
                HfPNumber.Value = output;
                SyncTextbox("NAME", output);
                //
                BindAndFill_Models();
                //  CNumber = output;
                btnCADReport.Enabled = true;
                btnSiteVisit.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CallPNum()
    {
        try
        {
            if (txtSearchPNum.Text != "")
            {
                ResetN();
                string OutPnumber = "";
                if (txtSearchPNum.Text.Contains(","))
                {
                    OutPnumber = txtSearchPNum.Text.Substring(0, txtSearchPNum.Text.IndexOf(','));
                }
                else
                {
                    OutPnumber = txtSearchPNum.Text;
                }
                HfPNumber.Value = string.Empty;
                HfPNumber.Value = OutPnumber;
                FillPnumber(OutPnumber);
                FillDetails(OutPnumber);
                Bind_GridProDwgs(OutPnumber);
                SyncTextbox("NUM", OutPnumber);
                HfPNumber.Value = OutPnumber;
                //
                // CNumber = OutPnumber;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtSearchPNum_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CallPNum();
            BindAndFill_Models();
            btnCADReport.Enabled = true;
            btnSiteVisit.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool CheckForValidPNumber(string pNumber)
    {
        try
        {
            ObjBOL.Operation = 41;
            ObjBOL.FProposalNumber = pNumber;
            string returnValue = ObjBLL.AddFollowUpRecord(ObjBOL);
            if (returnValue.Trim() == "S")
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return false;
    }

    private void SyncTextbox(string type, string text)
    {
        try
        {
            if (type != "")
            {
                DataTable dt = new DataTable();
                if (type == "NUM")
                {
                    dt = Utility.ReturnProposals(23, text);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchPName.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                    }
                    else
                    {
                        //Utility.ShowMessage(this, "P# not found");
                        Utility.ShowMessage_Error(Page, "P# not found");
                        txtSearchPName.Text = "";
                        txtSearchPNum.Text = "";
                    }
                }
                else
                {
                    dt = Utility.ReturnProposals(24, text);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchPNum.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                    }
                    else
                    {
                        //Utility.ShowMessage(this, "P# not found");
                        Utility.ShowMessage_Error(Page, "P# not found");
                        txtSearchPNum.Text = "";
                        txtSearchPName.Text = "";
                    }
                }
                bool status = CheckForValidPNumber(text);
                if (!status)
                {
                    Reset();
                }
                else
                {
                    EnableDisableShipDate();
                    try
                    {
                        SpecCredit();
                    }
                    catch (Exception exs)
                    {
                        Utility.AddEditException(exs);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableDisableShipDate()
    {
        try
        {
            if (string.IsNullOrEmpty(txtJobID.Text) == false)
            {
                string invoiceNumber = cls.Return_string("SELECT InvoiceNumber FROM tblProjects WHERE JobID = '" + txtJobID.Text + "' ").Trim();
                if (string.IsNullOrEmpty(invoiceNumber) == false)
                {
                    txtShipDate.Enabled = false;
                }
                else
                {
                    txtShipDate.Enabled = true;
                }
            }
            else
            {
                txtShipDate.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable EmptyDTQuote()
    {
        DataTable dtEmpty = new DataTable();
        try
        {
            dtEmpty.Columns.Add("QuoteNum", typeof(string));
            dtEmpty.Columns.Add("QRevType", typeof(Char));
            dtEmpty.Columns.Add("QuoteReqDate", typeof(DateTime));
            dtEmpty.Columns.Add("QuoteAckDate", typeof(DateTime));
            dtEmpty.Columns.Add("QuoteSentDate", typeof(DateTime));
            dtEmpty.Columns.Add("QEqPrice", typeof(Decimal));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);//adding row to the datatable
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    // Bind all dropdownlist here  
    private void BindQuote(string PNumber)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOLQuote.Operation = 1;
            ObjBOLQuote.PQuoteNo = PNumber;
            ds = ObjBLLQuote.GetQuotesInfo(ObjBOLQuote);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvQuoteInfo.DataSource = ds.Tables[0];
                gvQuoteInfo.DataBind();
            }
            else
            {
                gvQuoteInfo.DataSource = EmptyDTQuote();
                gvQuoteInfo.DataBind();
                gvQuoteInfo.Rows[0].Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvQuoteInfo_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = gvQuoteInfo.Rows[e.RowIndex];
            string EditRevisionNo = (row.FindControl("txtEditItemRevisionNo") as TextBox).Text;
            string ddlEditRevisionNo = (row.FindControl("ddlEditRevisionNo") as DropDownList).SelectedValue;
            string txtEditQuoteReqDate = (row.FindControl("txtEditQuoteReqDate") as TextBox).Text;
            string txEditQuoteReqAck = (row.FindControl("txEditQuoteReqAck") as TextBox).Text;
            string txtEditQuoteSent = (row.FindControl("txtEditQuoteSent") as TextBox).Text;
            string txtEditAmount = (row.FindControl("txtEditAmount") as TextBox).Text;
            ObjBOLQuote.Operation = 4;
            string PNUM = txtProNO.Text.Replace(",", "").ToString();
            ObjBOLQuote.PQuoteNo = PNUM;
            ObjBOLQuote.QuoteNo = EditRevisionNo;
            ObjBOLQuote.RevisionFormat = ddlEditRevisionNo;
            ObjBOLQuote.QuoteReqDate = Utility.ConvertDate(txtEditQuoteReqDate);
            ObjBOLQuote.QuoteAckDate = Utility.ConvertDate(txEditQuoteReqAck);
            ObjBOLQuote.QuoteSent = Utility.ConvertDate(txtEditQuoteSent);
            ObjBOLQuote.EqAmount = Convert.ToDecimal(txtEditAmount);
            msg = ObjBLLQuote.SaveQuote(ObjBOLQuote).Trim();
            if (msg == "S")
            {
                gvQuoteInfo.EditIndex = -1;
                BindQuote(PNUM);
                Utility.MaintainLogsSpecial("FrmProposals", "Update Q", PNUM);
                Utility.ShowMessage_Success(Page, "Quote updated successfully !!");
                CallPNum();
            }
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSQuote()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvQuoteInfo_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            gvQuoteInfo.EditIndex = e.NewEditIndex;
            string PNUM = txtProNO.Text.Replace(",", "").ToString();
            BindQuote(PNUM);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSQuote()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvQuoteInfo_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        try
        {
            gvQuoteInfo.EditIndex = -1;
            string PNUM = txtProNO.Text.Replace(",", "").ToString();
            BindQuote(PNUM);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSQuote()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvQuoteInfo_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSQuote()", true);
        //works on hidden button click
    }

    protected void HiddenButton_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            DropDownList FRevisionFormat = gvQuoteInfo.FooterRow.FindControl("FRevisionNo") as DropDownList;
            TextBox FRevisionNo = gvQuoteInfo.FooterRow.FindControl("txtFRevisionNo") as TextBox;
            TextBox FQuoteReqDate = gvQuoteInfo.FooterRow.FindControl("FtxtQuoteReqDate") as TextBox;
            TextBox FQuoteAckDate = gvQuoteInfo.FooterRow.FindControl("FtxtQuoteReqAck") as TextBox;
            TextBox FQuoteSent = gvQuoteInfo.FooterRow.FindControl("FtxtQuoteSent") as TextBox;
            TextBox FEqAmount = gvQuoteInfo.FooterRow.FindControl("FtxtAmount") as TextBox;
            if (txtProNO.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Proposal No. !');", true);
                txtProNO.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSQuote()", true);
                return;
            }
            if (FRevisionFormat.SelectedValue == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Revision No. !');", true);
                FRevisionFormat.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSQuote()", true);
                return;
            }
            if (FEqAmount.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Quote Amount. !');", true);
                FEqAmount.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSQuote()", true);
                return;
            }
            ObjBOLQuote.Operation = 2;
            //string[] Pnumber = CNumber.Split(',');
            string PNUM = txtProNO.Text.Replace(",", "").ToString();
            ObjBOLQuote.PQuoteNo = txtProNO.Text.Replace(",", "").ToString();
            ObjBOLQuote.RevisionFormat = FRevisionFormat.SelectedValue;
            ObjBOLQuote.RevisionNo = FRevisionNo.Text;
            if (FQuoteReqDate.Text != "")
            {
                ObjBOLQuote.QuoteReqDate = Utility.ConvertDate(FQuoteReqDate.Text);
            }

            if (FQuoteAckDate.Text != "")
            {
                ObjBOLQuote.QuoteAckDate = Utility.ConvertDate(FQuoteAckDate.Text);
            }

            if (FQuoteSent.Text != "")
            {
                ObjBOLQuote.QuoteSent = Utility.ConvertDate(FQuoteSent.Text);
            }

            if (FEqAmount.Text != "")
            {
                ObjBOLQuote.EqAmount = Convert.ToDecimal(FEqAmount.Text);
            }

            msg = ObjBLLQuote.SaveQuote(ObjBOLQuote);
            if (msg.Trim() != "")
            {

                if (msg.Trim() != "Duplicate Quote No. !!!")
                {

                    BindQuote(PNUM);
                    //SetCSSQuote
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSQuote()", true);
                    GetSpecConsultantandRep();
                    try
                    {
                        SpecCredit();
                    }
                    catch (Exception exs)
                    {
                        Utility.AddEditException(exs);
                    }
                    CallPNum();
                    //Utility.ShowMessage(this, msg);
                    Utility.MaintainLogsSpecial("FrmProposals", "Add Q", PNUM);
                    Utility.ShowMessage_Success(Page, "Quote added successfully !!");
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "Duplicate Quote No. !!!");
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSQuote()", true);
                    FRevisionNo.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvQuoteInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            string ID = Convert.ToString(gvQuoteInfo.DataKeys[e.RowIndex].Value);
            ObjBOLQuote.Operation = 3;
            ObjBOLQuote.QuoteNo = ID;
            msg = ObjBLLQuote.DeleteQuote(ObjBOLQuote).Trim();
            if (msg == "S")
            {
                string[] Pnumber = txtSearchPNum.Text.Split(',');
                string PNUM = Pnumber[0].ToString();
                BindQuote(PNUM);
                Utility.MaintainLogsSpecial("FrmProposals", "Delete Q", PNUM);
                Utility.ShowMessage_Success(Page, "Quote Deleted Successfully !");
                GetSpecConsultantandRep();
            }
            else if (msg == "ER01")
            {
                Utility.ShowMessage_Error(Page, "Quote doesnot exists !");
            }
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSQuote()", true);
            try
            {
                SpecCredit();
            }
            catch (Exception exs)
            {
                Utility.AddEditException(exs);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void FddlFollowupwith_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Check last inserted Scheduled Followup Date
        //DropDownList ddlType = GvFollowup.FooterRow.FindControl("FddlFollowupwith") as DropDownList;
        //Label lblLast = GvFollowup.Rows[GvFollowup.Rows.Count-1].FindControl("lblNextFollowUpDate") as Label;
        //TextBox txtlast = GvFollowup.FooterRow.FindControl("FtxtNextFollowedUpDate") as TextBox;
        //string date = txtlast.Text;
        //DateTime lastdate = DateTime.Now;
        //if (date == "")
        //{
        //    lastdate = DateTime.Now;
        //}
        //else
        //{
        //    lastdate = Utility.ConvertDate(lblLast.Text);
        //}        
        //if (ddlType.SelectedValue != "")
        //{
        //    string type = ddlType.SelectedValue;
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFollowUps()", true);
        //    // Schedule followup date based on Source selection 
        //    //switch (type)
        //    //{
        //    //    case "C":
        //    //        txtlast.Text = lastdate.AddMonths(4).ToString("MM/dd/yyyy");
        //    //        break;
        //    //    case "D":
        //    //        txtlast.Text = lastdate.AddMonths(1).ToString("MM/dd/yyyy");
        //    //        break;
        //    //    case "S":
        //    //        txtlast.Text = lastdate.AddMonths(1).ToString("MM/dd/yyyy");
        //    //        break;
        //    //    case "I":
        //    //        txtlast.Text = lastdate.AddMonths(1).ToString("MM/dd/yyyy");
        //    //        break;              
        //    //}
        //}     
    }

    //Start Proposal Drawings
    private DataTable EmptyDTProposalDwgs()
    {
        DataTable dtEmpty = new DataTable();
        try
        {
            //EmployeeID,ProDwgid
            dtEmpty.Columns.Add("ProDwgid", typeof(int));
            dtEmpty.Columns.Add("EmployeeID", typeof(int));
            dtEmpty.Columns.Add("DwgNo", typeof(string));
            dtEmpty.Columns.Add("EmployeeName", typeof(string));
            dtEmpty.Columns.Add("DateReqByRCD", typeof(DateTime));
            dtEmpty.Columns.Add("DateFwdToCAD", typeof(DateTime));
            dtEmpty.Columns.Add("DwgSentToManger", typeof(DateTime));
            dtEmpty.Columns.Add("DwgFwdToRCD", typeof(DateTime));
            dtEmpty.Columns.Add("Remarks", typeof(string));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);//adding row to the datatable
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    private void Bind_GridProDwgs(string PNumber)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 29;
            ObjBOL.PNumber = PNumber;
            ds = ObjBLL.GetProposals(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvProDwg.DataSource = ds.Tables[0];
                GvProDwg.DataBind();
            }
            else
            {
                GvProDwg.DataSource = EmptyDTProposalDwgs();
                GvProDwg.DataBind();
                GvProDwg.Rows[0].Visible = false;
            }
            BindDropDownList();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindDropDownList()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 27;
            ds = ObjBLL.GetProposals(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList FddlEngName = (DropDownList)GvProDwg.FooterRow.FindControl("FddlEngName");
                Utility.BindDropDownList(FddlEngName, ds.Tables[0]);
                int index = GvProDwg.EditIndex;

                //DropDownList ddlEngName = GvProDwg.Rows[index].FindControl("ddlEngName") as DropDownList;
                //Utility.BindDropDownList(ddlEngName, ds.Tables[0]);
                //Label lblddlEngName = GvProDwg.Rows[index].FindControl("lblddlEngName") as Label;
                //string EngName = lblddlEngName.Text;
                //ddlEngName.SelectedValue = EngName;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvProDwg_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        try
        {
            if (txtSearchPName.Text != "" && txtSearchPNum.Text != "")
            {
                if (e.CommandName == "Insert" && Page.IsValid)
                {
                    string msg = "";
                    ObjBOL.Operation = 28;
                    ObjBOL.PNumber = txtProNO.Text.Replace(",", "").ToString();
                    TextBox FtxtDrgNum = (TextBox)GvProDwg.FooterRow.FindControl("FtxtDrgNum");
                    DropDownList FddlEngName = (DropDownList)GvProDwg.FooterRow.FindControl("FddlEngName");
                    TextBox FtxtDwgReqbyRCD = (TextBox)GvProDwg.FooterRow.FindControl("FtxtDwgReqbyRCD");
                    TextBox FtxtDwgReqFwdtoCAD = (TextBox)GvProDwg.FooterRow.FindControl("FtxtDwgReqFwdtoCAD");
                    TextBox FtxtDrgSenttoManager = (TextBox)GvProDwg.FooterRow.FindControl("FtxtDrgSenttoManager");
                    TextBox FtxtDrgFwdtoRCD = (TextBox)GvProDwg.FooterRow.FindControl("FtxtDrgFwdtoRCD");
                    TextBox FtxtDrgComment = (TextBox)GvProDwg.FooterRow.FindControl("FtxtDrgComment");
                    if (FddlEngName.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Eng Name. !');", true);
                        FddlEngName.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
                        return;
                    }
                    if (FtxtDwgReqbyRCD.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Req. By RCD. !');", true);
                        FtxtDwgReqbyRCD.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
                        return;
                    }
                    if (FtxtDwgReqFwdtoCAD.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Req. Forward to CAD. !');", true);
                        FtxtDwgReqFwdtoCAD.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
                        return;
                    }
                    if (FtxtDrgSenttoManager.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Dwg. Sent to Manager. !');", true);
                        FtxtDrgSenttoManager.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
                        return;
                    }
                    if (FtxtDrgFwdtoRCD.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Dwg. Foward to RCD. !');", true);
                        FtxtDrgFwdtoRCD.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
                        return;
                    }
                    if (FtxtDrgComment.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Remarks. !');", true);
                        FtxtDrgComment.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
                        return;
                    }
                    string PNumber = txtProNO.Text.Replace(",", "").ToString();
                    ObjBOL.pDrgNum = PNumber;
                    ObjBOL.pEngID = Convert.ToInt32(FddlEngName.SelectedValue);
                    ObjBOL.pReqByRcd = Utility.ConvertDate(FtxtDwgReqbyRCD.Text);
                    ObjBOL.pReqFwdtoCAD = Utility.ConvertDate(FtxtDwgReqFwdtoCAD.Text);
                    ObjBOL.pDwgSenttoManager = Utility.ConvertDate(FtxtDrgSenttoManager.Text);
                    ObjBOL.pDwgFwdtoRCD = Utility.ConvertDate(FtxtDrgFwdtoRCD.Text);
                    ObjBOL.Remarks = FtxtDrgComment.Text;
                    msg = ObjBLL.SaveProposalsDwgs(ObjBOL);
                    // Utility.ShowMessage(this, msg);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
                    Bind_GridProDwgs(PNumber);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Proposal Number. !');", true);
                txtSearchPNum.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvProDwg_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            GvProDwg.EditIndex = e.NewEditIndex;
            string PNumber = txtProNO.Text.Replace(",", "").ToString();
            Bind_GridProDwgs(PNumber);
            DataSet ds = new DataSet();
            ObjBOL.Operation = 27;
            ds = ObjBLL.GetProposals(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList ddlEngName = GvProDwg.Rows[e.NewEditIndex].FindControl("ddlEngName") as DropDownList;
                Utility.BindDropDownList(ddlEngName, ds.Tables[0]);
                Label lblddlEngName = GvProDwg.Rows[e.NewEditIndex].FindControl("lblddlEngName") as Label;
                string EngName = lblddlEngName.Text;
                ddlEngName.SelectedValue = EngName;
            }
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvProDwg_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        try
        {
            GvProDwg.EditIndex = -1;
            string PNumber = txtProNO.Text.Replace(",", "").ToString();
            Bind_GridProDwgs(PNumber);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvProDwg_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            string ID = Convert.ToString(GvProDwg.DataKeys[e.RowIndex].Value);
            ObjBOL.Operation = 30;
            ObjBOL.ProDwgid = Convert.ToInt32(ID);
            msg = ObjBLL.DeleteProDrgRecord(ObjBOL);
            // Utility.ShowMessage(this, msg);
            string PNumber = txtProNO.Text.Replace(",", "").ToString();
            Bind_GridProDwgs(PNumber);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvProDwg_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = GvProDwg.Rows[e.RowIndex];
            ObjBOL.Operation = 31;
            ObjBOL.PNumber = txtProNO.Text.Replace(",", "").ToString();
            TextBox DrgNum = row.FindControl("txtDrgNum") as TextBox;
            DropDownList EngName = row.FindControl("ddlEngName") as DropDownList;
            TextBox txtDwgReqbyRCD = row.FindControl("txtDwgReqbyRCD") as TextBox;
            TextBox txtDwgReqFwdtoCAD = row.FindControl("txtDwgReqFwdtoCAD") as TextBox;
            TextBox txtDrgSenttoManager = row.FindControl("txtDrgSenttoManager") as TextBox;
            TextBox txtDrgFwdtoRCD = row.FindControl("txtDrgFwdtoRCD") as TextBox;
            TextBox txtDrgComment = row.FindControl("txtDrgComment") as TextBox;
            if (EngName.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Eng Name. !');", true);
                EngName.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
                return;
            }
            if (txtDwgReqbyRCD.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Req. By RCD. !');", true);
                txtDwgReqbyRCD.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
                return;
            }
            if (txtDwgReqFwdtoCAD.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Req. Forward to CAD. !');", true);
                txtDwgReqFwdtoCAD.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
                return;
            }
            if (txtDrgSenttoManager.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Dwg. Sent to Manager. !');", true);
                txtDrgSenttoManager.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
                return;
            }
            if (txtDrgFwdtoRCD.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Dwg. Sent to Manager. !');", true);
                txtDrgFwdtoRCD.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
                return;
            }
            ObjBOL.pDrgNum = DrgNum.Text;
            ObjBOL.pEngID = Convert.ToInt32(EngName.SelectedValue);
            ObjBOL.pReqByRcd = Utility.ConvertDate(txtDwgReqbyRCD.Text);
            ObjBOL.pReqFwdtoCAD = Utility.ConvertDate(txtDwgReqFwdtoCAD.Text);
            ObjBOL.pDwgSenttoManager = Utility.ConvertDate(txtDrgSenttoManager.Text);
            ObjBOL.pDwgFwdtoRCD = Utility.ConvertDate(txtDrgFwdtoRCD.Text);
            ObjBOL.Remarks = txtDrgComment.Text;
            msg = ObjBLL.SaveProposalsDwgs(ObjBOL);
            //Utility.ShowMessage(this, msg);
            GvProDwg.EditIndex = -1;
            string PNumber = txtProNO.Text.Replace(",", "").ToString();
            Bind_GridProDwgs(PNumber);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlDestRep_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDestRep.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.ConsultantID = Convert.ToInt32(ddlDestRep.SelectedValue);
                ObjBOL.Operation = 32;
                ds = ObjBLL.GetProposals(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlProjectManager.SelectedValue = ds.Tables[0].Rows[0]["PMID"].ToString();
                }
                // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSProDrw()", true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindExistingJobID()
    {
        try
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ObjBOL.Operation = 34;
            if (txtSearchPNum.Text != "" && txtSearchPName.Text != "")
            {
                ObjBOL.PNumber = txtProNO.Text;
            }
            ds = ObjBLL.GetProposals(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblExistingJobDetails.Visible = true;
                gvExistingJobID.DataSource = ds.Tables[0];
                gvExistingJobID.DataBind();
                dt = ds.Tables[0];
                var column2Values = dt.AsEnumerable().Select(x => x.Field<string>("JobID"));
                lblExistingJobDetails.Text = String.Join(", ", column2Values.ToArray());
            }
            else
            {
                gvExistingJobID.DataSource = "";
                gvExistingJobID.DataBind();
                lblExistingJobDetails.Visible = false;
                lblExistingJobDetails.Text = String.Empty;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnExistingJob_Click(object sender, EventArgs e)
    {
        try
        {
            ModalPopupExtender1.Show();
            lblProposalNo.Text = txtProNO.Text;
            BindExistingJobID();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Boolean ValidationCheckExistingJobID()
    {
        try
        {
            if (ddlExistingJobID.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Job ID. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Job ID. !");
                ddlExistingJobID.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnAddExistingJobID_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheckExistingJobID() == true)
            {
                string msg = "";
                ObjBOL.Operation = 33;
                ObjBOL.PNumber = txtProNO.Text;
                ObjBOL.ExistingJobID = ddlExistingJobID.SelectedItem.Text;
                msg = ObjBLL.AddExistingJobID(ObjBOL);
                lblErrorExistingJobid.Text = msg;
                BindExistingJobID();
                ModalPopupExtender1.Show();
            }
            else
            {
                ModalPopupExtender1.Show();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvExistingJobID_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            string ID = Convert.ToString(gvExistingJobID.DataKeys[e.RowIndex].Value);
            ObjBOL.Operation = 35;
            ObjBOL.ExistingJobID = ID;
            msg = ObjBLL.DeleteExistingJobID(ObjBOL);
            if (msg != "")
            {
                lblErrorExistingJobid.Text = msg;
            }
            BindExistingJobID();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //btnCancelExistingJobID_Click
    protected void btnCancelExistingJobID_Click(object sender, EventArgs e)
    {
        try
        {
            ddlExistingJobID.SelectedIndex = 0;
            gvExistingJobID.DataSource = "";
            gvExistingJobID.DataBind();
            lblErrorExistingJobid.Text = String.Empty;
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // Model Selection Start
    private void Bind_Models()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL1.Operation = 2;
            ds = ObjBLL1.GetSubModel(ObjBOL1);
            //testData = ds.Tables[1];
            //test = true;
            if (ds.Tables[1].Rows.Count > 0)
            {
                //JSvalue="id" DataTextField="name" DataValueField="id"
                Utility.BindCheckBoxListWOAll(chk1, ds.Tables[1]);
                Utility.BindCheckBoxListWOAll(chk2, ds.Tables[2]);
                Utility.BindCheckBoxListWOAll(chk3, ds.Tables[3]);
                Utility.BindCheckBoxListWOAll(chk4, ds.Tables[4]);
                Utility.BindCheckBoxListWOAll(chk5, ds.Tables[5]);
                Utility.BindCheckBoxListWOAll(chk6, ds.Tables[6]);
                Utility.BindCheckBoxListWOAll(chk7, ds.Tables[7]);
                Utility.BindCheckBoxListWOAll(chk8, ds.Tables[8]);
                Utility.BindCheckBoxListWOAll(chk9, ds.Tables[9]);

                chk1_PopUp.Text = PrepareListFrontend(ds.Tables[1]);
                chk2_PopUp.Text = PrepareListFrontend(ds.Tables[2]);
                chk3_PopUp.Text = PrepareListFrontend(ds.Tables[3]);
                chk4_PopUp.Text = PrepareListFrontend(ds.Tables[4]);
                chk5_PopUp.Text = PrepareListFrontend(ds.Tables[5]);
                chk6_PopUp.Text = PrepareListFrontend(ds.Tables[6]);
                chk7_PopUp.Text = PrepareListFrontend(ds.Tables[7]);
                chk8_PopUp.Text = PrepareListFrontend(ds.Tables[8]);
                chk9_PopUp.Text = PrepareListFrontend(ds.Tables[9]);
                foreach (ListItem li in chk1.Items)
                {
                    //description
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk2.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    // li.Attributes.Add("Title", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk3.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    //  li.Attributes.Add("Title", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk4.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    // li.Attributes.Add("Title", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk5.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    // li.Attributes.Add("Title", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk6.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    //  li.Attributes.Add("Title", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk7.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    //li.Attributes.Add("Title", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk8.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    //li.Attributes.Add("Title", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk9.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    //li.Attributes.Add("Title", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
            }
            else
            {
                chk1.DataSource = "";
                chk1.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private string PrepareListFrontend(DataTable tableToRender)
    {
        try
        {
            string list = "<ul> ";
            foreach (DataRow row in tableToRender.Rows)
            {
                list += "<li>" + row[3].ToString() + "</li> ";
            }
            list += "</ul>";
            return list;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return "";
    }

    private string GetRoleTooltip(int p)
    {
        string name = string.Empty;
        DataSet ds = new DataSet();
        ObjBOL1.Operation = 5;
        ObjBOL1.id = p;
        ds = ObjBLL1.GetSubModel(ObjBOL1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            name = ds.Tables[0].Rows[0]["description"].ToString();
        }
        return name;
    }

    private Boolean Save_Model()
    {
        Boolean sts = false;
        try
        {
            ObjBOL1.Operation = 3;
            CheckModelBeforeSave();
            DataTable selected = (DataTable)ViewState["Summary"];
            DataView dv = new DataView(selected);
            DataTable summarytemp = dv.ToTable("selected", false, "PNumber", "ChildModelID");
            DataRow row;
            ObjBOL1.PNumber = txtProNO.Text;
            for (int i = 0; i < chk1.Items.Count; i++)
            {
                if (chk1.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk1.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }

            for (int i = 0; i < chk2.Items.Count; i++)
            {
                if (chk2.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk2.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }

            for (int i = 0; i < chk3.Items.Count; i++)
            {
                if (chk3.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk3.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }

            for (int i = 0; i < chk4.Items.Count; i++)
            {
                if (chk4.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk4.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }

            for (int i = 0; i < chk5.Items.Count; i++)
            {
                if (chk5.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk5.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }

            for (int i = 0; i < chk6.Items.Count; i++)
            {
                if (chk6.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk6.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }

            for (int i = 0; i < chk7.Items.Count; i++)
            {
                if (chk7.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk7.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }

            for (int i = 0; i < chk8.Items.Count; i++)
            {
                if (chk8.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk8.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }
            for (int i = 0; i < chk9.Items.Count; i++)
            {
                if (chk9.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk9.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }
            ObjBOL1.SelectDetails = summarytemp;
            if (summarytemp.Rows.Count > 0)
            {
                sts = true;
                ObjBLL1.SaveModel(ObjBOL1);
                BindAndFill_Models();
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Model. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Model. !");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSModels()", true);
                sts = false;
            }
        }

        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return sts;
    }

    private DataTable DTModel()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.TableName = "Summary";
            dt.Columns.Add(new DataColumn("PNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("ChildModelID", typeof(int)));

            ViewState["Summary"] = dt;
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void CheckModelBeforeSave()
    {
        try
        {
            DataTable dt = DTModel();
            DataRow dr;
            ViewState["Summary"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Fill_ModelDetails()
    {
        try
        {
            HfPNumber.Value = txtSearchPNum.Text;
            ObjBOL1.Operation = 4;
            DataSet ds = new DataSet();
            ObjBOL1.PNumber = txtSearchPNum.Text.Split(',')[0];
            ds = ObjBLL1.GetSubModel(ObjBOL1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //txtSearchPNum.Text = Convert.ToString(ds.Tables[0].Rows[0]["PNumber"]);
                for (int i = 0; i < chk1.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk1.Items[i].Value == chk.ToString())
                        {
                            chk1.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk2.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk2.Items[i].Value == chk.ToString())
                        {
                            chk2.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk3.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk3.Items[i].Value == chk.ToString())
                        {
                            chk3.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk4.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk4.Items[i].Value == chk.ToString())
                        {
                            chk4.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk5.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk5.Items[i].Value == chk.ToString())
                        {
                            chk5.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk6.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk6.Items[i].Value == chk.ToString())
                        {
                            chk6.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk7.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk7.Items[i].Value == chk.ToString())
                        {
                            chk7.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk8.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk8.Items[i].Value == chk.ToString())
                        {
                            chk8.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk9.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk9.Items[i].Value == chk.ToString())
                        {
                            chk9.Items[i].Selected = true;
                        }
                    }
                }
                string strMethodName = "GetValue();";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void BindAndFill_Models()
    {
        Bind_Models();
        Fill_ModelDetails();
    }

    // Model Selection End
    [WebMethod]
    public static string NextFollowUpDateEvent(string nextFollowUpDate, string projectManagerID)
    {
        try
        {
            commonclass1 cls = new commonclass1();
            string query = "Exec aero_ProposalScheduleFollowUpCount '" + nextFollowUpDate + "','" + projectManagerID + "'";
            string clr = cls.Return_string(query);
            return clr;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return "";
    }

    protected void btnCADReport_Click(object sender, EventArgs e)
    {
        try
        {
            //Session["PNumber"] = "";
            //Session["PNumber"] = HfPNumber.Value.Replace(",", "");
            Response.Redirect("~/SalesManagement/FrmDailyCADReport.aspx?pNumber=" + txtProNO.Text, false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSiteVisit_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/SalesManagement/FrmSiteVisitInformation.aspx?pNumber=" + txtProNO.Text, false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}