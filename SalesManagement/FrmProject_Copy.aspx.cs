using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
/// <summary>
///  Project Form (10 May 2018) Rohit Kumar
/// </summary>
public partial class SalesManagement_FrmProject : System.Web.UI.Page
{
    BOLManageProjects ObjBOL = new BOLManageProjects();
    BLLManageProjects ObjBLL = new BLLManageProjects();
    BOLProposalSearch ObjBOLSearch = new BOLProposalSearch();
    BLLProposalSearch ObjBLLSearch = new BLLProposalSearch();
    BOLShpDrg ObjBOLShpDrg = new BOLShpDrg();
    BLLShpDrg ObjBLLShpDrg = new BLLShpDrg();
    BOLModel ObjBOL1 = new BOLModel();
    BLLModel ObjBLL1 = new BLLModel();
    commonclass1 cls = new commonclass1();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

    MailAddress from = new MailAddress(Utility.Email(), Utility.EmailDisplayName());
    MailAddress sendtoAshish = new MailAddress("ashish@aero-werks.com", "Ashish");
    MailAddress sendtoPrateek = new MailAddress("prateek@aero-werks.com", "Prateek");
    //MailAddress cc = new MailAddress("aeroit@aero-werks.com", "Rohit Kumar");
    string UserName = "aerowerksindia@gmail.com";
    string Password = "Aero@123";
    string Do_Not_Reply = "[Please do not reply to this message. Replies to this message are routed to an unmonitored mailbox. If you have questions please go to https://www.aero-werks.com/contact-us]";
    public string SelectedOutlookEntryID { get; private set; }

    // Page load event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                btnProposalRedirect.Text = "Models";
                ddlPurchasedItems.Enabled = false;
                ShowHideControls();
                Bind_Controls();
                if (Request.QueryString["jid"] != null)
                {
                    var JNumber = Request.QueryString["jid"];
                    FillJnumber(JNumber);
                    SyncTextbox("NUM", JNumber);
                    SyncTextbox("NAME", JNumber);
                }
                if (Session["JobID"] != null)
                {
                    var JNumber = Session["JobID"].ToString();
                    FillJnumber(JNumber);
                    SyncTextbox("NUM", JNumber);
                    SyncTextbox("NAME", JNumber);
                }
                hfCurrentUser.Value = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
                SpecCredit();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ShowHideControls()
    {
        string CRuser = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
        if (CRuser == "288")
        {
            btnAdd.Visible = false;
            btnSave.Visible = false;
            btnSearch.Visible = false;
            btnCuspack.Visible = false;
            btnAcknoledgement.Visible = false;
            btnInf.Visible = true;
        }
        else
        {
            btnAdd.Visible = true;
            btnSave.Visible = true;
            btnSearch.Visible = true;
            btnCuspack.Visible = true;
            btnAcknoledgement.Visible = true;
        }
        var Reviewedby = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
        var ReviewedbyID = new List<string> { "19", "263", "66", "229" };
        if (ReviewedbyID.Contains(Reviewedby))
        {
            //btnopener.Visible = true;
            //btnopenerNotFollowedup.Visible = true;
            txtCashDiscountAmount.Enabled = true;
            txtCashDiscountPer.Enabled = true;
            txtAmountInvoiced.Enabled = true;
            txtinvnumber.Enabled = true;
            txtInvodate.Enabled = true;
        }
        else
        {
            txtCashDiscountAmount.Enabled = false;
            txtCashDiscountPer.Enabled = false;
            txtAmountInvoiced.Enabled = false;
            txtinvnumber.Enabled = false;
            txtInvodate.Enabled = false;
        }
    }

    private void SpecCredit()
    {
        try
        {
            //EnableDisableShipDate();
            //to do
            //string strMethodName = "getCheckedRadio();";
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
            string strMethodName2 = "EnableDisableSpecCredit();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName2, true);
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
            //GetCashDiscountFromDealer();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Send Email if Ship To Arrive Date Created First Time or Changed after Update Details
    /// </summary>
    /// <param name="Message"></param>
    /// <param name="Subject"></param>
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
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(UserName, Password);
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

    private void SendEmail()
    {
        try
        {
            string Message = string.Empty;
            string Subject = string.Empty;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 19;
            ObjBOL.JobID = txtJobId.Text;
            ds = ObjBLL.GetProjects(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Message += "<p><b>Hi Team,</b></p><p><b>Ship Date to </b><strong>Job ID : </strong>" + ds.Tables[0].Rows[0]["JobID"].ToString() + "</p>" + "<p><b> has been Updated Please find the details below:</b></p>";
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                Message += "<li><strong>Job ID : </strong>" + ds.Tables[0].Rows[0]["JobID"].ToString() + "</li>";
                Message += "<li><strong>Project Name : </strong>" + ds.Tables[0].Rows[0]["ProjectName"].ToString() + "</li>";
                Message += "<li><strong>Ship Date : </strong>" + ds.Tables[0].Rows[0]["ShipToArriveDate"].ToString() + "</li>";
                Message += "<li><strong>Consultant Rep : </strong>" + ds.Tables[0].Rows[0]["ConsultantRep"].ToString() + "</li>";
                Message += "<li><strong>Origination Rep : </strong>" + ds.Tables[0].Rows[0]["OriginationRep"].ToString() + "</li>";
                Message += "<li><strong>Destination Rep : </strong>" + ds.Tables[0].Rows[0]["DestinationRep"].ToString() + "</li>";
                Message += "<li><strong>Consultant : </strong>" + ds.Tables[0].Rows[0]["Consultant"].ToString() + "</li>";
                Message += "<li><strong>Prime Spec : </strong>" + ds.Tables[0].Rows[0]["CompetitorName"].ToString() + "</li>";
                Message += "</ul><p><span style='font - size:10px;'><span style='font - family:verdana,geneva,sans - serif;'><span style='color:#FF0000;'><u>" + Do_Not_Reply + "</u></span></span></span></p>";
                //Send_Email(Message, ds.Tables[0].Rows[0]["ProjectName"].ToString());
                Message = "";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    // Bind all dropdownlist here
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ds = ObjBLL.GetProjects(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlOASentTo, ds.Tables[1]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPreparedBy, ds.Tables[3]);
                Utility.BindDropDownList(ddlReviewedByAI, ds.Tables[3]);
                Utility.BindDropDownList(ddlReviewedByHO, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCustomer, ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConsultantRep, ds.Tables[5]);
                Utility.BindDropDownList(ddlOrgRep, ds.Tables[5]);
                Utility.BindDropDownList(ddlDesRep, ds.Tables[5]);
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDealer, ds.Tables[6]);
            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConsultant, ds.Tables[7]);
            }
            if (ds.Tables[8].Rows.Count > 0)
            {
                //Utility.BindDropDownList(ddlDesigner, ds.Tables[8]);
            }
            if (ds.Tables[9].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSalesSource, ds.Tables[9]);
            }
            if (ds.Tables[10].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConveyorType, ds.Tables[10]);
            }
            //
            if (ds.Tables[11].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlModel, ds.Tables[11]);
            }
            if (ds.Tables[12].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlServiceRep, ds.Tables[12]);
            }
            if (ds.Tables[13].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSpecCredit, ds.Tables[13]);
            }
            if (ds.Tables[14].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlReviewedBy, ds.Tables[14]);
            }
            if (ds.Tables[15].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlInstallationBy, ds.Tables[15]);
            }
            if (ds.Tables[16].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlInstallerA, ds.Tables[16]);
                Utility.BindDropDownList(ddlInstallerB, ds.Tables[16]);
                Utility.BindDropDownList(ddlInstallerC, ds.Tables[16]);
            }
            if (ds.Tables[17].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCurrency, ds.Tables[17]);
            }
            if (ds.Tables[18].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlFOB, ds.Tables[18]);
            }
            if (ds.Tables[19].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlTerm, ds.Tables[19]);
            }
            if (ds.Tables[20].Rows.Count > 0)
            {
                //Utility.BindDropDownList(ddlCommissionRate, ds.Tables[20]);
                Utility.BindDropDownList(ddlRate, ds.Tables[20]);
            }
            //
            if (ds.Tables[21].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlShipper, ds.Tables[21]);
            }
            if (ds.Tables[22].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlcountry, ds.Tables[22]);
            }
            if (ds.Tables[23].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlMfgFacility, ds.Tables[23]);
            }
            if (ds.Tables[26].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectDesigner, ds.Tables[26]);
                //ddlProjectDesigner.DataSource = ds.Tables[26];
                //ddlProjectDesigner.DataBind();
                //ddlProjectDesigner.Items.Insert(0, new ListItem("", "0"));
            }
            if (ds.Tables[27].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectDesCanada, ds.Tables[27]);
                //ddlProjectDesCanada.DataSource = ds.Tables[27];
                //ddlProjectDesCanada.DataBind();
                //ddlProjectDesCanada.Items.Insert(0, new ListItem("", "0"));
            }
            if (ds.Tables[28].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlManuFac, ds.Tables[28]);
                //ddlManuFac.DataSource = ds.Tables[9];
                //ddlManuFac.DataBind();
                //ddlManuFac.Items.Insert(0, new ListItem("", "0"));
            }
            //if (ds.Tables[29].Rows.Count > 0)
            //{
            //    //Utility.BindDropDownList(ddlExistingJobno, ds.Tables[29]);
            //    //ddlExistingJobno.DataSource = ds.Tables[10];
            //    //ddlExistingJobno.DataBind();
            //    //ddlExistingJobno.Items.Insert(0, new ListItem("", "0"));
            //}
            //if (ds.Tables[30].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlProjectType, ds.Tables[30]);
            //    //ddlProjectType.DataSource = ds.Tables[11];
            //    //ddlProjectType.DataBind();
            //    //ddlProjectType.Items.Insert(0, new ListItem("", "0"));
            //}
            if (ds.Tables[31].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectManager, ds.Tables[31]);
                //ddlProjectManager.DataSource = ds.Tables[12];
                //ddlProjectManager.DataBind();
                //ddlProjectManager.Items.Insert(0, new ListItem("", "0"));
            }
            if (ds.Tables[32].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPNumber, ds.Tables[32]);
                //ddlProjectManager.DataSource = ds.Tables[12];
                //ddlProjectManager.DataBind();
                //ddlProjectManager.Items.Insert(0, new ListItem("", "0"));
            }
            //ddlPNumber
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Control2()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 21;
            ds = ObjBLL.GetProjects(ObjBOL);
            //todo
            //cboJNumber.SelectedValue = Request.QueryString["JobID"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlModel, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlServiceRep, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSpecCredit, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlReviewedBy, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlInstallationBy, ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlInstallerA, ds.Tables[5]);
                Utility.BindDropDownList(ddlInstallerB, ds.Tables[5]);
                Utility.BindDropDownList(ddlInstallerC, ds.Tables[5]);
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCurrency, ds.Tables[6]);
            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlFOB, ds.Tables[7]);
            }
            if (ds.Tables[8].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlTerm, ds.Tables[8]);
            }
            if (ds.Tables[9].Rows.Count > 0)
            {
                //Utility.BindDropDownList(ddlCommissionRate, ds.Tables[20]);
                Utility.BindDropDownList(ddlRate, ds.Tables[9]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Control3()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 22;
            ds = ObjBLL.GetProjects(ObjBOL);
            //todo
            //cboJNumber.SelectedValue = Request.QueryString["JobID"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlShipper, ds.Tables[0]);
            }
            //if (ds.Tables[22].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlcity, ds.Tables[22]);
            //}
            //if (ds.Tables[23].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlState, ds.Tables[23]);
            //}
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlcountry, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlMfgFacility, ds.Tables[4]);
            }

            if (ds.Tables[7].Rows.Count > 0)
            {
                ddlProjectDesigner.DataSource = ds.Tables[7];
                ddlProjectDesigner.DataBind();
                ddlProjectDesigner.Items.Insert(0, new ListItem("", "0"));
            }
            if (ds.Tables[8].Rows.Count > 0)
            {
                ddlProjectDesCanada.DataSource = ds.Tables[8];
                ddlProjectDesCanada.DataBind();
                ddlProjectDesCanada.Items.Insert(0, new ListItem("", "0"));
            }
            if (ds.Tables[9].Rows.Count > 0)
            {
                ddlManuFac.DataSource = ds.Tables[9];
                ddlManuFac.DataBind();
                ddlManuFac.Items.Insert(0, new ListItem("", "0"));
            }
            //if (ds.Tables[10].Rows.Count > 0)
            //{
            //    ddlExistingJobno.DataSource = ds.Tables[10];
            //    ddlExistingJobno.DataBind();
            //    ddlExistingJobno.Items.Insert(0, new ListItem("", "0"));
            //}
            //if (ds.Tables[11].Rows.Count > 0)
            //{
            //    ddlProjectType.DataSource = ds.Tables[11];
            //    ddlProjectType.DataBind();
            //    ddlProjectType.Items.Insert(0, new ListItem("", "0"));
            //}
            if (ds.Tables[12].Rows.Count > 0)
            {
                ddlProjectManager.DataSource = ds.Tables[12];
                ddlProjectManager.DataBind();
                ddlProjectManager.Items.Insert(0, new ListItem("", "0"));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_ControlReset()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 22;
            ds = ObjBLL.GetProjects(ObjBOL);
            //todo
            //cboJNumber.SelectedValue = Request.QueryString["JobID"];            
            if (ds.Tables[2].Rows.Count > 0)
            {
                //Utility.BindDropDownList(ddlExistingJobno, ds.Tables[2]);
                //ddlExistingJobno.DataSource = ds.Tables[10];
                //ddlExistingJobno.DataBind();
                //ddlExistingJobno.Items.Insert(0, new ListItem("", "0"));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetState(ddlcountry.SelectedValue);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
            SpecCredit();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetState(string Countryid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.ShipToCountry = Countryid;
            ObjBOL.Operation = 20;
            ds = ObjBLL.GetStates(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlState, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //private void EnabledReportButtons()
    //{
    //    try
    //    {
    //        btnAcknoledgement.Enabled = true;
    //        btnInf.Enabled = true;
    //        btnCuspack.Enabled = true;
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}

    private void DisabledReportButtons()
    {
        try
        {
            btnAcknoledgement.Enabled = false;
            btnInf.Enabled = false;
            btnCuspack.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // Get P# from Project Name
    private void EnableDisableReports()
    {
        if (ddlprojectstatus.SelectedValue != "0")
        {
            btnAcknoledgement.Enabled = false;
            btnInf.Enabled = false;
            btnCuspack.Enabled = false;
            btnWarrntyLetter.Enabled = false;
        }
        else
        {
            btnAcknoledgement.Enabled = true;
            btnInf.Enabled = true;
            btnCuspack.Enabled = true;
            btnWarrntyLetter.Enabled = true;
        }
    }

    /// <summary>
    /// Combine all the values in Project Name
    /// </summary>
    /// <param name="Jnumber"></param>
    private void FillJnumber(string Jnumber)
    {
        try
        {
            if (Jnumber != "")
            {
                txtPONumber.Text = string.Empty;
                string strJnumber = Jnumber;
                string OutJnumber = string.Empty;
                if (strJnumber != "")
                {
                    if (Jnumber.Length > 7)
                    {
                        OutJnumber = strJnumber.Substring(0, strJnumber.IndexOf(','));
                    }
                    else
                    {
                        OutJnumber = Jnumber;
                    }
                    FillDetailsFromJnumber(OutJnumber);
                    SyncTextbox("NAME", OutJnumber);
                    HfJObID.Value = OutJnumber;
                }
                else
                {
                    FillDetailsFromJnumber(strJnumber);
                    SyncTextbox("NUM", strJnumber);
                    HfJObID.Value = strJnumber;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// FillNumber() AutoFill Project Name in Project Name Text Box
    /// </summary>
    /// <param name="Pnumber"></param>
    // synchronized

    /// <summary>
    /// FillProposalNumber() autofill all PNumber in Proposal Text Box
    /// </summary>
    /// <param name="PNumber"></param>
    private void FillProposalNumber()
    {
        try
        {
            DataTable dt = Utility.GetPNumber(18);
            if (dt.Rows.Count > 0)
            {
                ddlPNumber.DataSource = dt;
                ddlPNumber.DataBind();
                ddlPNumber.Items.Insert(0, new ListItem("", "0"));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //private void GetConsultantMember(Int32 Consultantid)
    //{
    //    DataSet ds = new DataSet();
    //    ObjBOL.Operation = 15;
    //    ObjBOL.ConsultantID = Consultantid;
    //    ds = ObjBLL.GetProjects(ObjBOL);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        Utility.BindDropDownList(ddlConsultantMember, ds.Tables[0]);
    //    }
    //}

    /// <summary>
    /// Fill Details in Project Page
    /// </summary>
    /// <param name="strJNumber"></param>
    // Fill all details
    private void FillDetailsFromJnumber(string strJNumber)
    {
        try
        {
            hfShipToArriveDateFillDetail.Value = "";
            hfReleased.Value = "";
            DataSet ds = new DataSet();
            ObjBOL.Operation = 9;
            ObjBOL.ProjectName = strJNumber;
            ObjBOL.JobID = strJNumber;
            ds = ObjBLL.GetProjects(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                ddlPurchasedItems.Enabled = true;
                // First Tab
                txtJobId.Text = Convert.ToString(dr["JobID"]);
                ddlPNumber.SelectedValue = Convert.ToString(dr["ProposalID"]);
                btnProposalRedirect.Text = Convert.ToString(dr["Models_New"]);
                ddlOASentTo.SelectedValue = Convert.ToString(dr["OASentTo"]);

                txtJobOrderDate.Text = cls.Converter(Convert.ToString(dr["JobOrderDate"]));
                txtOrderAckDate.Text = cls.Converter(Convert.ToString(dr["JobOrderAck"]));
                txtOADispatch.Text = cls.Converter(Convert.ToString(dr["JobOADis"]));
                //if (dr["OASentToContact"].ToString() != "")
                //{
                //    ddlContact.SelectedValue = Convert.ToString(dr["OASentToContact"]);
                //}
                //chkCanel.Checked = Convert.ToBoolean(dr["CancelJob"]);
                ddlCustomer.SelectedValue = Convert.ToString(dr["CustomerID"]);
                txtPONumber.Text = Convert.ToString(dr["PONumber"]);
                ddlConsultantRep.SelectedValue = Convert.ToString(dr["ConsultRepID"]);
                ddlOrgRep.SelectedValue = Convert.ToString(dr["OriginRepID"]);
                if (Convert.ToString(dr["RepID"]) != "0")
                {
                    ddlDesRep.SelectedValue = Convert.ToString(dr["RepID"]);
                }
                ddlDealer.SelectedValue = Convert.ToString(dr["DealerID"]);
                ddlConsultant.SelectedValue = Convert.ToString(dr["ConsultantID"]);
                int Consultantid = Convert.ToInt32(dr["ConsultantID"]);
                //if (Consultantid != 0)
                //{
                //    GetConsultantMember(Consultantid);
                //    ddlConsultantMember.SelectedValue = Convert.ToString(dr["ConsultantMemberID"]);
                //}
                //ddlDesigner.SelectedValue = Convert.ToString(dr["ProjectDesignerID"]);
                ddlSalesSource.SelectedValue = Convert.ToString(dr["SalesSourceID"]);
                ddlServiceRep.SelectedValue = Convert.ToString(dr["SerRep"]);
                txtPoRecDate.Text = cls.Converter(Convert.ToString(dr["PORec"]));
                if (Convert.ToInt32(dr["OrderBelongsTo"]) == 1)
                {
                    rdbOrderFor.SelectedValue = "1";
                }
                else
                {
                    rdbOrderFor.SelectedValue = "2";
                }
                txtQuote.Text = Convert.ToString(dr["QuoteSelected"]);
                //txtDateAssigned.Text = cls.Converter(Convert.ToString(dr["DateAssigned"]));
                ddlConveyorType.SelectedValue = Convert.ToString(dr["ConveyorTypeID"]);
                ddlModel.SelectedValue = Convert.ToString(dr["ModelID"]);
                ddlPreparedBy.SelectedValue = Convert.ToString(dr["ProjDataPrepBy"]);
                ddlReviewedByAI.SelectedValue = Convert.ToString(dr["ProjFormReviewByAI"]);
                txtReviewedByAI.Text = cls.Converter(Convert.ToString(dr["PFRBAIDate"]));
                ddlReviewedByHO.SelectedValue = Convert.ToString(dr["ProjFormReviewByHO"]);
                txtReviewedByHO.Text = cls.Converter(Convert.ToString(dr["PFRBHODate"]));
                if (Convert.ToString(dr["SpecCredits"]) != "0")
                {
                    rdbSpecCredit.SelectedValue = Convert.ToString(dr["SpecCredits"]);
                }
                else
                {
                    rdbSpecCredit.SelectedValue = null;
                }
                //rdbSpecCredit.SelectedValue = Convert.ToString(dr["SpecCredits"]);
                ddlSpecCredit.SelectedValue = Convert.ToString(dr["SpecCreditPercentID"]);
                txtSpecAmount.Text = Convert.ToString(dr["SpecCreditAmount"]);
                txtSpecConsultantRep.Text = ddlConsultantRep.SelectedItem.Text;
                txtSpecConsultant.Text = ddlConsultant.SelectedItem.Text;
                txtSpecCheque.Text = Convert.ToString(dr["SpecCreditCheckNo"]);
                txtSpecPaid.Text = cls.Converter(Convert.ToString(dr["SpecCreditPaidDate"]));
                txtReleased.Text = cls.Converter(Convert.ToString(dr["ReleaseDate"]));
                txtFabReleasedDate.Text = cls.Converter(Convert.ToString(dr["ReleaseDate"]));
                txtExpectedArrivalDatefromChina.Text = cls.Converter(Convert.ToString(dr["ExpectedArrivalDatefromChina"]));
                txtDateBuiltDrgsSent.Text = cls.Converter(Convert.ToString(dr["DateAsBuiltDrgsSent"]));
                txtEstimatedCom.Text = cls.Converter(Convert.ToString(dr["EstCompletionDate"]));
                txtActualCom.Text = cls.Converter(Convert.ToString(dr["ActualCompletionDate"]));
                txtTestRun.Text = cls.Converter(Convert.ToString(dr["TestRunDate"]));
                var Reviewedby = Convert.ToString(dr["ReviewedBy"]);
                //if (Reviewedby == "33" || Reviewedby == "40" || Reviewedby == "75" || Reviewedby == "89" || Reviewedby == "161")
                var ReviewedbyID = new List<string> { "33", "40", "75", "89", "161" };
                if (ReviewedbyID.Contains(Reviewedby))
                {
                    ddlReviewedBy.SelectedValue = Convert.ToString(dr["ReviewedBy"]);
                }
                ddlFabStatus.SelectedValue = Convert.ToString(dr["Status"]);
                ddlPurchasedItems.SelectedValue = Convert.ToString(dr["PurchasedItems"]);
                ddlPurchasedItemsCAD.SelectedValue = Convert.ToString(dr["PurchasedItemsCAD"]);
                ddlInstallationBy.SelectedValue = Convert.ToString(dr["InstallationBy"]);
                ddlInstallerA.SelectedValue = Convert.ToString(dr["InstallatorA"]);
                ddlInstallerB.SelectedValue = Convert.ToString(dr["InstallatorB"]);
                ddlInstallerC.SelectedValue = Convert.ToString(dr["InstallatorC"]);
                txtInstallationStart.Text = cls.Converter(Convert.ToString(dr["InstallDate"]));
                txtInstallationEnd.Text = cls.Converter(Convert.ToString(dr["InstallationCompletionDate"]));
                txtDemo.Text = cls.Converter(Convert.ToString(dr["DemoDate"]));
                txtWarrantyStart.Text = cls.Converter(Convert.ToString(dr["WarrantyStartDate"]));
                txtWarrantyEnd.Text = cls.Converter(Convert.ToString(dr["WarrantyEndDate"]));
                txtFollowUp.Text = cls.Converter(Convert.ToString(dr["FollowUpDate"]));
                txtCarePack.Text = cls.Converter(Convert.ToString(dr["CustCarePackageSendDate"]));
                txtManualsDisp.Text = cls.Converter(Convert.ToString(dr["ManualDispatchDate"]));
                txtTestRemarks.Text = Convert.ToString(dr["Comments"]);
                if (Convert.ToInt32(dr["PMPack"]) == 0)
                {
                    rdbPM.SelectedValue = "0";
                }
                else
                {
                    rdbPM.SelectedValue = "1";
                }
                //txtConsultantFeedback.Text = Convert.ToString(dr["FeedBackConsultant"]);
                //txtDealerFeedback.Text = Convert.ToString(dr["FeedBackDealer"]);
                //txtSummary.Text = Convert.ToString(dr["SummofSugg"]);
                // Second Tab
                ddlCurrency.SelectedValue = Convert.ToString(dr["CurrencyID"]);
                txtEqPrice.Text = Convert.ToDecimal(dr["Price"]).ToString("N");
                txtEqDiscount.Text = Convert.ToDecimal(dr["EqDiscount"]).ToString("N");
                txtEqDisAmount.Text = Convert.ToDecimal(dr["EqDisAmount"]).ToString("N");
                txtNetEqPrice.Text = Convert.ToDecimal(dr["NetEqPrice"]).ToString("N");

                txtFreight.Text = Convert.ToDecimal(dr["Freight"]).ToString("N");
                txtInstall.Text = Convert.ToDecimal(dr["Installation"]).ToString("N");
                txtExWarranty.Text = Convert.ToDecimal(dr["ExWarrantyPrice"]).ToString("N");
                //txtNetAmount.Text = Convert.ToDecimal(dr["NetAmount"]).ToString("F");
                txtNetAmount.Text = CalculateNetAmount().ToString("N");
                txtAmountInvoiced.Text = txtNetAmount.Text;
                txtHST.Text = Convert.ToDecimal(dr["GST"]).ToString("N");
                txtTotalAmount.Text = Convert.ToDecimal(CalculateTotal()).ToString("N");
                txtinvnumber.Text = Convert.ToString(dr["InvoiceNumber"]);
                txtInvodate.Text = cls.Converter(Convert.ToString(dr["DateInvoiceSent"]));
                txtChequeNo.Text = Convert.ToString(dr["AeroChequeNum"]);
                txtIndComDate.Text = cls.Converter(Convert.ToString(dr["IndComDate"]));
                txtDateReceived.Text = cls.Converter(Convert.ToString(dr["DatePaymentReceived"]));
                txtDiscount.Text = Convert.ToDecimal(dr["discount"]).ToString("N");
                txtAmount.Text = Convert.ToDecimal(CalculateCommission()).ToString("N");
                ddlFOB.Text = Convert.ToString(dr["fob"]);
                ddlTerm.Text = Convert.ToString(dr["term"]);
                txtActualFreight.Text = Convert.ToDecimal(dr["FreightPaid"]).ToString("N");
                ddlRate.SelectedValue = Convert.ToString(dr["CommissionType"]);
                txtProjectCommNotes.Text = Convert.ToString(dr["CommissionText"]);
                //todo
                txtCommAmount.Text = Convert.ToDecimal(CalculateCommissionMain()).ToString("N");
                txtCommCheque.Text = Convert.ToString(dr["KflexCheckNumber"]);
                txtCommDate.Text = cls.Converter(Convert.ToString(dr["DateCommissionPaid"]));
                string comtype = Convert.ToString(dr["GSICommissionType"]);
                if (string.IsNullOrEmpty(comtype) == true)
                {
                    txtCommissionRate.Text = null;
                }
                else
                {
                    txtCommissionRate.Text = Convert.ToString(dr["GSICommissionType"]);
                }
                txtCommissionAmount.Text = Convert.ToDecimal(dr["GSICommissionAmount"]).ToString("N");
                txtCommissionChequeNo.Text = Convert.ToString(dr["GSICommissionCheckNo"]);
                txtCommissionDateSent.Text = cls.Converter(Convert.ToString(dr["GSICommissionSentDate"]));
                //todo
                ddlShipper.SelectedValue = Convert.ToString(dr["ShipperID"]);
                string sc = Convert.ToString(dr["ShippingCommit"]);
                if (sc != " ")
                {
                    ddlShippingComit.SelectedValue = Convert.ToString(dr["ShippingCommit"]);
                }
                else
                {
                    ddlShippingComit.SelectedValue = "";
                }
                //string st = string.Empty;
                //st = Convert.ToString(dr["ShipStatus"]);
                //if (st !=" ")
                //{
                //    ddlShippingStatus.SelectedValue = Convert.ToString(dr["ShipStatus"]);
                //}
                //else
                //{
                //    ddlShippingStatus.SelectedValue = "";
                //}
                ddlShippingStatus.SelectedValue = Convert.ToString(dr["ShipStatus"]);
                // txtShipDate.Text = cls.Converter(Convert.ToString(dr["ShipDate"]));
                //var Temp = dr["shipdate"];
                txtShipDate.Text = cls.Converter(Convert.ToString(dr["projectshipdate"]));
                txtShipToArrive.Text = cls.Converter(Convert.ToString(dr["ShipToArriveDate"]));
                hfShipToArriveDateFillDetail.Value = txtShipToArrive.Text;
                txtArrivalDate.Text = cls.Converter(Convert.ToString(dr["ArrivalDate"]));
                txtCompany.Text = Convert.ToString(dr["ShipToName"]);
                txtAddress.Text = Convert.ToString(dr["ShipToStreet"]);
                txtCity.Text = Convert.ToString(dr["ShipToCity"]);
                ddlcountry.SelectedValue = Convert.ToString(dr["CountryID"]);
                GetState(ddlcountry.SelectedValue);
                if (Convert.ToString(dr["ShipToState"]) != "")
                {
                    ddlState.SelectedValue = Convert.ToString(dr["ShipToState"]);
                }
                txtZip.Text = Convert.ToString(dr["ShipToZipCode"]);
                txtContactPerson.Text = Convert.ToString(dr["SiteContact"]);
                txtPhone.Text = Convert.ToString(dr["SiteContactTelephone"]);
                txtSMCost.Text = Convert.ToString(dr["ConCost"]);
                //todo
                txtRoyalAmount.Text = Convert.ToString(dr["ConRoylAmt"]);
                txtCheq.Text = Convert.ToString(dr["ConCheckNo"]);
                txtDatePaid.Text = cls.Converter(Convert.ToString(dr["ConChqPaidDt"]));
                txtConRoyalAmount.Text = Convert.ToString(dr["ConRoylAmt"]);
                //ddlMfgFacility.SelectedValue = Convert.ToString(dr["MfgFacilityID"]);
                btnSave.Text = "Update";
                if (ddlConveyorType.SelectedValue == "82")
                {
                    // To do check Panel Removed from aspx by designer (28 Oct 2020)
                    // pnlSpaceMiser.Visible = true;
                }
                else
                {
                    // pnlSpaceMiser.Visible = false;
                }
                if (Convert.ToString(dr["DealerID"]) == "814")
                {
                    txtCommissionRate.Text = "5";
                    txtCommissionAmount.Text = Convert.ToDecimal(Convert.ToDecimal(txtNetEqPrice.Text) * 5 / 100).ToString("N");
                }
                txtFabStartDate.Text = cls.Converter(Convert.ToString(dr["DateAssigned"]));
                ddlProjectDesigner.SelectedValue = dr["ProjectDesignerID"].ToString();
                txtDueToCanda.Text = cls.Converter(Convert.ToString(dr["DueDateCanada"]));
                txtFabtrication.Text = cls.Converter(Convert.ToString(dr["FabSentToCanada"]));
                //if (dr["EngineerCanada"].ToString() != "" && dr["EngineerCanada"].ToString() != "Select")
                //{
                //    ddlProjectDesCanada.SelectedValue = dr["EngineerCanada"].ToString();
                //}

                ddlManuFac.SelectedValue = dr["MfgFacilityID"].ToString();
                txtReleasetoNesting.Text = cls.Converter(Convert.ToString(dr["ReleasedToNesting"]));
                txtProjectReleasedToShop.Text = cls.Converter(Convert.ToString(dr["ReleasedToShop"]));
                ddlNestingStatus.SelectedValue = dr["NestingStatus"].ToString();
                //if (dr["JobType"].ToString() != "")
                //{
                //    ddlProjectType.SelectedIndex = ddlProjectType.Items.IndexOf(ddlProjectType.Items.FindByText(dr["JobType"].ToString()));
                //}
                //if (dr["ExistingJobID"].ToString() != "0")
                //{
                //    ddlExistingJobno.SelectedItem.Text = dr["ExistingJobID"].ToString();
                //}
                if (dr["ProjectStatus"].ToString() != "")
                {
                    ddlprojectstatus.SelectedValue = dr["ProjectStatus"].ToString();
                }
                ddlProjectManager.SelectedValue = dr["ProjectManager"].ToString();
                hfReleased.Value = dr["ReleaseToShop"].ToString();
                txtCashDiscountAmount.Text = Convert.ToDecimal(dr["CashDisAmt"]).ToString("N");
                decimal cashper = Convert.ToDecimal(dr["CashDisPer"]);
                txtCashDiscountPer.Text = cashper.ToString("N");
                if (cashper <= 0)
                {
                    txtAmountForComision.Text = Convert.ToDecimal(dr["NetEqPrice"]).ToString("N");
                    //txtTAmountRec.Text = txtNetAmount.Text;
                    txtTAmountRec.Text = txtTotalAmount.Text;
                }
                else
                {
                    txtAmountForComision.Text = Convert.ToDecimal(dr["AmountForComission"]).ToString("N");
                    txtTAmountRec.Text = Convert.ToDecimal(dr["CashAmtRec"]).ToString("N");
                }
                //ddlNestingStatus
                //TO DO UMCOMMENT AFTER changes
                EnableDisableShipDate();
                Get_Tax();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    GvShpDrg.DataSource = ds.Tables[1];
                    GvShpDrg.DataBind();
                }
                else
                {
                    GvShpDrg.DataSource = EmptyDT();
                    GvShpDrg.DataBind();
                    GvShpDrg.Rows[0].Visible = false;
                }
                string strMethodName = "GetConsultant();";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
                string strMethodRepName = "GetConsultantRep();";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodRepName, true);
                //FillDetails(strJNumber);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "text", "getCheckedRadio();", true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "text", "getCalc();", true);
                //getCalc();
                EnableDisableReports();
                CheckUserForRelease();
                if (ddlProjectManager.SelectedIndex > 0)
                {
                    lblPM.Text = "Project Manager : <b>" + ddlProjectManager.SelectedItem.Text + "</b>";
                    //spn.Visible = true;
                    lblPM.Visible = true;
                }
                else
                {
                    lblPM.Text = String.Empty;
                    lblPM.Visible = false;
                }
                if (ddlDesRep.SelectedIndex > 0)
                {
                    lblDesRep.Text = "Destination Rep : <b>" + ddlDesRep.SelectedItem.Text + "</b>";
                    lblDesRep.Visible = true;
                }
                else
                {
                    lblDesRep.Text = String.Empty;
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

    // For Commission Calculation
    private decimal CalculateNetAmount()
    {
        //=Nz([NetAmount]*[Discount%]/100)
        //txtNetAmount + txtDiscount  
        Decimal TAmount = 0;
        try
        {
            if ((txtNetEqPrice.Text != "" || txtNetEqPrice.Text != "0"))
            {
                TAmount = (Convert.ToDecimal(txtNetEqPrice.Text) + Convert.ToDecimal(txtFreight.Text) + Convert.ToDecimal(txtInstall.Text) + Convert.ToDecimal(txtExWarranty.Text));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return TAmount;
    }

    //// For Total calculation
    private decimal CalculateTotal()
    {
        //=Nz([NetAmount])+Nz([GST])
        //txtNetAmount + txtHST
        Decimal TAmount = 0;
        try
        {
            if ((txtNetAmount.Text != "" || txtNetAmount.Text == "0") && (txtHST.Text != "" || txtHST.Text == "0"))
            {
                TAmount = Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtHST.Text);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return TAmount;
    }

    //// For Commission Calculation
    private decimal CalculateCommission()
    {
        //=Nz([NetAmount]*[Discount%]/100)
        //txtNetAmount + txtDiscount    
        Decimal TAmount = 0;
        try
        {
            if ((txtNetAmount.Text != "" || txtNetAmount.Text != "0") && (txtDiscount.Text != "" || txtDiscount.Text != "0"))
            {
                TAmount = (Convert.ToDecimal(txtNetAmount.Text) * Convert.ToDecimal(txtDiscount.Text) / 100);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return TAmount;
    }

    //// For Commission Calculation Main
    private decimal CalculateCommissionMain()
    {
        //=Nz([NetEqPrice]*[CommissionType]/100)
        //txtNetAmount + txtDiscount   
        Decimal TAmount = 0;
        try
        {
            if ((txtNetEqPrice.Text != "" || txtNetEqPrice.Text != "0") && (ddlRate.SelectedIndex > 0))
            {
                TAmount = (Convert.ToDecimal(txtNetEqPrice.Text) * Convert.ToDecimal(ddlRate.SelectedValue) / 100);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return TAmount;
    }

    // TO DO HST Calculation
    //private void CaseFirst()
    //{
    //    if (string.IsNullOrEmpty(txtEqPrice.Text) == false)
    //    {
    //        Decimal EqPrice = Utility.ToDecimal(txtEqPrice.Text);
    //        Decimal DisPer = Utility.ToDecimal(txtEqDiscount.Text);
    //        Decimal DisAmt = Utility.ToDecimal(txtEqDisAmount.Text);
    //        //Decimal NetEqPrice = Utility.ToDecimal(txtNetEqPrice.Text);
    //        Decimal Freight = Utility.ToDecimal(txtFreight.Text);
    //        Decimal Install = Utility.ToDecimal(txtInstall.Text);
    //        Decimal Warranty = Utility.ToDecimal(txtExWarranty.Text);
    //        //Decimal NetAmt = Utility.ToDecimal(txtNetAmount.Text);
    //        Decimal HST = Utility.ToDecimal(txtHST.Text);
    //        //Decimal TotalAmt = Utility.ToDecimal(txtTotalAmount.Text);
    //        Decimal DisAmt_Show = 0;
    //        if (DisPer > 0)
    //        {
    //            DisAmt_Show = (EqPrice * DisPer) / 100;
    //        }

    //        Decimal NetEqPrice_Show = (EqPrice - DisAmt);
    //        Decimal NetAmt_Show = (EqPrice + Freight + Install + Warranty);
    //        Decimal TotalAmt_Show = (NetAmt_Show + HST);

    //        txtEqDisAmount.Text = Convert.ToDecimal(DisAmt_Show).ToString("F");
    //        txtNetEqPrice.Text = Convert.ToDecimal(NetEqPrice_Show).ToString("F");
    //        txtNetAmount.Text = Convert.ToDecimal(NetAmt_Show).ToString("F");
    //        txtTotalAmount.Text = Convert.ToDecimal(TotalAmt_Show).ToString("F");

    //        // Cahnge discount values also as percentage depends on Net Amount
    //        // discount Percentage
    //        Decimal dis_Per = Utility.ToDecimal(txtDiscount.Text);
    //        Decimal Show_Discount = (NetAmt_Show * dis_Per) / 100;
    //        // discount Amount
    //        txtAmount.Text = Convert.ToDecimal(Show_Discount).ToString("F");


    //        // Change in Commission Info           
    //        Decimal comm_Per = Utility.ToDecimal(ddlRate.SelectedValue);
    //        Decimal Show_comm = (NetAmt_Show * comm_Per) / 100;
    //        txtCommAmount.Text = Convert.ToDecimal(Show_comm).ToString("F");

    //        // Govt Sales
    //        //txtCommissionAmount
    //        //Decimal comm_Per_Gov = Utility.ToDecimal(ddlCommissionRate.SelectedValue);
    //        //Decimal Show_comm_Gov = (NetAmt_Show * comm_Per_Gov) / 100;
    //        //txtCommissionAmount.Text = Convert.ToDecimal(Show_comm_Gov).ToString("F");
    //    }
    //}

    //// Calculations
    //private void CaseSecond()
    //{
    //    Decimal EqPrice = Utility.ToDecimal(txtEqPrice.Text);
    //    Decimal DisPer = Utility.ToDecimal(txtEqDiscount.Text);
    //    Decimal DisAmt = Utility.ToDecimal(txtEqDisAmount.Text);
    //    //Decimal NetEqPrice = Utility.ToDecimal(txtNetEqPrice.Text);
    //    Decimal Freight = Utility.ToDecimal(txtFreight.Text);
    //    Decimal Install = Utility.ToDecimal(txtInstall.Text);
    //    Decimal Warranty = Utility.ToDecimal(txtExWarranty.Text);
    //    //Decimal NetAmt = Utility.ToDecimal(txtNetAmount.Text);
    //    Decimal HST = Utility.ToDecimal(txtHST.Text);
    //    Decimal TotalAmt = Utility.ToDecimal(txtTotalAmount.Text);

    //    Decimal DisAmount_Show = (EqPrice * DisPer) / 100;
    //    Decimal NetEqPrice_Show = (EqPrice - DisAmount_Show);
    //    Decimal NetAmt_Show = (NetEqPrice_Show + Freight + Install + Warranty);
    //    Decimal TotalAmt_Show = (NetAmt_Show + HST);

    //    txtEqDisAmount.Text = Convert.ToDecimal(DisAmount_Show).ToString("F");
    //    txtNetEqPrice.Text = Convert.ToDecimal(NetEqPrice_Show).ToString("F");
    //    txtNetAmount.Text = Convert.ToDecimal(NetAmt_Show).ToString("F");
    //    txtTotalAmount.Text = Convert.ToDecimal(TotalAmt_Show).ToString("F");

    //    // Cahnge discount values also as percentage depends on Net Amount
    //    // discount Percentage
    //    Decimal dis_Per = Utility.ToDecimal(txtDiscount.Text);
    //    Decimal Show_Discount = (NetAmt_Show * dis_Per) / 100;
    //    // discount Amount
    //    txtAmount.Text = Convert.ToDecimal(Show_Discount).ToString("F");


    //    // Change in Commission Info           
    //    Decimal comm_Per = Utility.ToDecimal(ddlRate.SelectedValue);
    //    Decimal Show_comm = (NetEqPrice_Show * comm_Per) / 100;
    //    txtCommAmount.Text = Convert.ToDecimal(Show_comm).ToString("F");

    //    // Govt Sales
    //    //txtCommissionAmount
    //    //Decimal comm_Per_Gov = Utility.ToDecimal(ddlCommissionRate.SelectedValue);
    //    //Decimal Show_comm_Gov = (NetEqPrice_Show * comm_Per_Gov) / 100;
    //    //txtCommissionAmount.Text = Convert.ToDecimal(Show_comm_Gov).ToString("F");

    //}

    //// Calculations
    //private void CaseThird()
    //{
    //    Decimal EqPrice = Utility.ToDecimal(txtEqPrice.Text);
    //    Decimal DisAmt = Utility.ToDecimal(txtEqDisAmount.Text);
    //    Decimal NetEqPrice = Utility.ToDecimal(txtNetEqPrice.Text);
    //    Decimal Freight = Utility.ToDecimal(txtFreight.Text);
    //    Decimal Install = Utility.ToDecimal(txtInstall.Text);
    //    Decimal Warranty = Utility.ToDecimal(txtExWarranty.Text);

    //    Decimal NetEqPrice_Show = (EqPrice - DisAmt);
    //    Decimal NetAmt_Show = (EqPrice + Freight + Install + Warranty);
    //    Decimal DisPer_Show = (DisAmt / EqPrice * 100);

    //    txtNetEqPrice.Text = Convert.ToDecimal(NetEqPrice_Show).ToString("F");
    //    txtNetAmount.Text = Convert.ToDecimal(NetAmt_Show).ToString("F");
    //    txtEqDiscount.Text = Convert.ToDecimal(DisPer_Show).ToString("F");

    //    // Cahnge discount values also as percentage depends on Net Amount
    //    // discount Percentage
    //    Decimal dis_Per = Utility.ToDecimal(txtDiscount.Text);
    //    Decimal Show_Discount = (NetAmt_Show * dis_Per) / 100;
    //    // discount Amount
    //    txtAmount.Text = Convert.ToDecimal(Show_Discount).ToString("F");


    //    // Change in Commission Info           
    //    Decimal comm_Per = Utility.ToDecimal(ddlRate.SelectedValue);
    //    Decimal Show_comm = (NetAmt_Show * comm_Per) / 100;
    //    txtCommAmount.Text = Convert.ToDecimal(Show_comm).ToString("F");

    //    // Govt Sales
    //    //txtCommissionAmount
    //    //Decimal comm_Per_Gov = Utility.ToDecimal(ddlCommissionRate.SelectedValue);
    //    //Decimal Show_comm_Gov = (NetAmt_Show * comm_Per_Gov) / 100;
    //    //txtCommissionAmount.Text = Convert.ToDecimal(Show_comm_Gov).ToString("F");
    //}

    //// Calculations
    //private void CaseFourth()
    //{
    //    Decimal NetEqPrice = Utility.ToDecimal(txtNetEqPrice.Text);
    //    Decimal Freight = Utility.ToDecimal(txtFreight.Text);
    //    Decimal Install = Utility.ToDecimal(txtInstall.Text);
    //    Decimal Warranty = Utility.ToDecimal(txtExWarranty.Text);

    //    Decimal NetAmt_Show = (NetEqPrice + Freight + Install + Warranty);
    //    txtNetAmount.Text = Convert.ToDecimal(NetAmt_Show).ToString("F");


    //    // Cahnge discount values also as percentage depends on Net Amount
    //    // discount Percentage
    //    Decimal dis_Per = Utility.ToDecimal(txtDiscount.Text);
    //    Decimal Show_Discount = (NetAmt_Show * dis_Per) / 100;
    //    // discount Amount
    //    txtAmount.Text = Convert.ToDecimal(Show_Discount).ToString("F");


    //    // Change in Commission Info           
    //    Decimal comm_Per = Utility.ToDecimal(ddlRate.SelectedValue);
    //    Decimal Show_comm = (NetAmt_Show * comm_Per) / 100;
    //    txtCommAmount.Text = Convert.ToDecimal(Show_comm).ToString("F");

    //    // Govt Sales
    //    //txtCommissionAmount
    //    //Decimal comm_Per_Gov = Utility.ToDecimal(ddlCommissionRate.SelectedValue);
    //    //Decimal Show_comm_Gov = (NetAmt_Show * comm_Per_Gov) / 100;
    //    //txtCommissionAmount.Text = Convert.ToDecimal(Show_comm_Gov).ToString("F");
    //}

    //// Calculations
    //private void CaseFifth()
    //{
    //    Decimal NetAmt = Utility.ToDecimal(txtNetAmount.Text);
    //    Decimal HST = Utility.ToDecimal(txtHST.Text);

    //    Decimal TotalAmt_Show = (NetAmt + HST);
    //    txtTotalAmount.Text = Convert.ToDecimal(TotalAmt_Show).ToString("F");
    //}

    /// <summary>
    /// Calculate HST in Project Page
    /// </summary>
    // Calculations 
    private void Get_Tax()
    {
        // if (string.IsNullOrEmpty(txtEqPrice.Text) == false)
        try
        {
            Decimal TaxAmount = 0;
            int CustomerID = Convert.ToInt32(ddlCustomer.SelectedValue);
            DateTime? JobOrderDate = Utility.ConvertDate(txtJobOrderDate.Text);
            Decimal NetAmount = Utility.ToDecimal(txtNetAmount.Text);
            if ((CustomerID != 0) && (JobOrderDate != null) && (NetAmount != 0))
            {
                ObjBOL.CustomerID = CustomerID;
                ObjBOL.JobOrderDate = JobOrderDate;
                ObjBOL.NetAmount = NetAmount;
                TaxAmount = ObjBLL.GetTaxAmount(ObjBOL);
                txtHST.Text = Convert.ToString(TaxAmount);
                Decimal NetAmt = Utility.ToDecimal(txtNetAmount.Text);
                Decimal HST = Utility.ToDecimal(txtHST.Text);
                Decimal TotalAmt_Show = (NetAmt + HST);
                txtTotalAmount.Text = Convert.ToDecimal(TotalAmt_Show).ToString("N");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckPaymentInfo()
    {
        try
        {
            var Reviewedby = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
            var ReviewedbyID = new List<string> { "19", "66" };
            // 19 = PING, 66 = GOVAR (13 AUG 2022) 
            if (ReviewedbyID.Contains(Reviewedby) == false)
            {
                if (txtCommDate.Text != "")
                {
                    ddlConsultantRep.Enabled = false;
                    ddlOrgRep.Enabled = false;
                    ddlDesRep.Enabled = false;
                }
                else
                {
                    ddlConsultantRep.Enabled = true;
                    ddlOrgRep.Enabled = true;
                    ddlDesRep.Enabled = true;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    //// TO DO COMMENT
    //protected void txtEqPrice_TextChanged(object sender, EventArgs e)
    //{
    //    CaseFirst();
    //}

    //// Calculations
    //protected void txtEqDiscount_TextChanged(object sender, EventArgs e)
    //{
    //    CaseSecond();
    //}

    //// Calculations
    //protected void txtEqDisAmount_TextChanged(object sender, EventArgs e)
    //{
    //    CaseThird();
    //}

    //// Calculations
    //protected void txtFreight_TextChanged(object sender, EventArgs e)
    //{
    //    CaseFourth();
    //}

    //// Calculations
    //protected void txtInstall_TextChanged(object sender, EventArgs e)
    //{
    //    CaseFourth();
    //}

    //// Calculations
    //protected void txtExWarranty_TextChanged(object sender, EventArgs e)
    //{
    //    CaseFourth();
    //}

    //// Calculations
    //protected void txtHST_TextChanged(object sender, EventArgs e)
    //{
    //    CaseFifth();
    //}

    // Set State value on Abbrevation
    //protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlOrgRep.SelectedIndex > 0)
    //    {
    //        //ddlStateAb.SelectedValue = ddlState.SelectedValue;
    //    }
    //}

    //// Set Abbrevation value on State
    //protected void ddlStateAb_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //if (ddlStateAb.SelectedIndex > 0)
    //    //{
    //    //    ddlState.SelectedValue = ddlStateAb.SelectedValue;
    //    //}
    //}
    /// <summary>
    /// Generate New JNumber
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Genrate new Jnumber
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Reset();
            string msg = "";
            ObjBOL.Operation = 10;
            msg = ObjBLL.GenrateJNumber(ObjBOL);
            txtJobId.Text = msg;
            txtJobOrderDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            // FillDetails(cboJNumber.SelectedItem.Text);
            FillDetails(txtSearchPNum.Text);
            btnAdd.Enabled = false;
            SpecCredit();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Check Validation Controls Before Save and Update data
    /// </summary>
    /// <returns></returns>
    // check if data filled in required fields
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtJobId.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Generate Poject Number. !');", true);
                Utility.ShowMessage_Error(Page, "Please Generate Poject Number. !");
                txtJobId.Focus();
                return false;
            }
            if (ddlPNumber.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Proposal Number. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Proposal Number. !");
                ddlPNumber.Focus();
                return false;
            }
            if (ddlProjectManager.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Project Manager. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Project Manager. !");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFirst()", true);
                lblProjectManager.Focus();
                lblProjectManager.Attributes.Add("Style", "color:red;");
                return false;
            }
            else
            {
                lblProjectManager.Attributes.Add("Style", "color:black;");
            }
            if (ddlCustomer.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Customer. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Customer. !");
                ddlCustomer.Focus();
                return false;
            }
            if (ddlprojectstatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Project Status. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Project Status. !");
                ddlprojectstatus.Focus();
                return false;
            }
            //if (ddlSalesSource.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Sales Source. !');", true);
            //    ddlSalesSource.Focus();
            //    return false;
            //}
            //if (ddlConveyorType.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Conveyor Type. !');", true);
            //    ddlConveyorType.Focus();
            //    return false;
            //}
            //if (ddlModel.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Conveyor Model. !');", true);
            //    ddlModel.Focus();
            //    return false;
            //}
            //Spec Credit Rep and Consultant Validation
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
            if (ddlCurrency.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Currency. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Currency. !");
                ddlCurrency.Focus();
                return false;
            }
            if (ddlShippingComit.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Shipping Commitment. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Shipping Commitment. !");
                ddlShippingComit.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                return false;
            }
            if (ddlShippingStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Shipment Status. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Shipment Status. !");
                ddlShippingStatus.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                return false;
            }
            if (txtShipDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Ship Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Ship Date. !");
                txtShipDate.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                return false;
            }
            if (txtShipToArrive.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Ship to Arrive Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Ship to Arrive Date. !");
                txtShipToArrive.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                return false;
            }
            if (ddlFOB.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select FOB. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select FOB. !");
                ddlFOB.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                return false;
            }
            if (ddlTerm.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Term. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Term. !");
                ddlTerm.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                return false;
            }
            //if (ddlRate.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Commission Rate. !');", true);               
            //    ddlRate.Focus();
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
            //    return false;
            //}
            decimal rate = Convert.ToDecimal(ddlRate.SelectedValue);
            if (rate == 0 && txtProjectCommNotes.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Project Commission Notes. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Project Commission Notes. !");
                txtProjectCommNotes.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private string GetProjectStatus(string Jobid)
    {
        string sts = string.Empty;
        try
        {
            ObjBOL.JobID = Jobid;
            ObjBOL.Operation = 23;
            sts = ObjBLL.GetProjectStatus(ObjBOL);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return sts;
    }

    /// <summary>
    /// Update Values
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Save/Update data
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            if (ValidationCheck() == true)
            {
                //error in below columns
                //EstReleaseDate
                //EstCompletionDate
                //PreInspectionDate
                //AppDrgAck
                //BuiltDrgWithUnderStruSent
                //DrgSentOutforApproval
                //AppDrgWithFieldDimension
                //AppDrgAck
                //EquipDelConfirmed
                //AccReqFromCustomer
                //PFRBAIDate
                //FDRBHODate
                string sts = GetProjectStatus(HfJObID.Value);
                if (sts == "0" || sts == "1" || sts == "")
                {
                    SaveData();
                }
                if (sts == "2" && ddlprojectstatus.SelectedIndex <= 2 || sts == "3" && ddlprojectstatus.SelectedIndex <= 2)
                {
                    SaveData();
                }
                else if (sts == "2" && ddlprojectstatus.SelectedIndex > 2 || sts == "3" && ddlprojectstatus.SelectedIndex > 2)
                {
                    msg = "This Project is cancelled/Onhold please change project status to make any update";
                    //Utility.ShowMessage(this, msg);
                    Utility.ShowMessage_Error(Page, msg);
                }
                //Reset();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SaveData()
    {
        try
        {
            string msg = string.Empty;
            ObjBOL.Operation = 3;
            ObjBOL.JobID = txtJobId.Text;
            if (txtJobOrderDate.Text != "")
            {
                ObjBOL.JobOrderDate = Utility.ConvertDate(txtJobOrderDate.Text);
            }
            else
            {
                ObjBOL.JobOrderDate = null;
            }
            if (rdbOrderFor.SelectedValue == "1")
            {
                ObjBOL.OrderBelongsToDELETE = 1;
            }
            else if (rdbOrderFor.SelectedValue == "2")
            {
                ObjBOL.OrderBelongsToDELETE = 2;
            }
            ObjBOL.PORec = Utility.ConvertDate(txtPoRecDate.Text);
            ObjBOL.OASentTo = ddlOASentTo.SelectedValue;
            //ObjBOL.OASentToContact = ddlContact.SelectedValue;
            ObjBOL.QuoteSelected = txtQuote.Text;
            ObjBOL.JobOrderAck = Utility.ConvertDate(txtOrderAckDate.Text);
            ObjBOL.JobOADis = Utility.ConvertDate(txtOADispatch.Text);
            ObjBOL.ProposalID = ddlPNumber.SelectedValue;
            ObjBOL.CustomerID = Convert.ToInt32(ddlCustomer.SelectedValue);
            ObjBOL.ModelID = Convert.ToInt32(ddlModel.SelectedValue);
            ObjBOL.ConveyorTypeID = Convert.ToInt32(ddlConveyorType.SelectedValue);
            ObjBOL.ServiceRepID = Convert.ToInt32(ddlServiceRep.SelectedValue);
            ObjBOL.ShipperID = Convert.ToInt32(ddlShipper.SelectedValue);
            ObjBOL.ShippingCommit = Convert.ToString(ddlShippingComit.SelectedValue);
            ObjBOL.ShipStatus = Convert.ToString(ddlShippingStatus.SelectedValue);
            ObjBOL.SiteContact = txtContactPerson.Text;
            ObjBOL.SiteContactTelephone = txtPhone.Text;
            ObjBOL.DateAsBuiltDrgsSent = Utility.ConvertDate(txtDateBuiltDrgsSent.Text);
            // to do
            //ObjBOL.EstReleaseDate = Utility.ConvertDate(txtReleased.Text);
            ObjBOL.ReleaseDate = Utility.ConvertDate(txtReleased.Text);
            ObjBOL.ReleaseDate = Utility.ConvertDate(txtFabReleasedDate.Text);
            ObjBOL.ExpectedArrivalDatefromChina = Utility.ConvertDate(txtExpectedArrivalDatefromChina.Text);
            ObjBOL.TestRunDate = Utility.ConvertDate(txtTestRun.Text);
            ObjBOL.EstCompletionDate = Utility.ConvertDate(txtEstimatedCom.Text);
            ObjBOL.ActualCompletionDate = Utility.ConvertDate(txtActualCom.Text);
            ObjBOL.ShipDate = Utility.ConvertDate(txtShipDate.Text);
            ObjBOL.ShipToArriveDate = Utility.ConvertDate(txtShipToArrive.Text);
            ObjBOL.ArrivalDate = Utility.ConvertDate(txtArrivalDate.Text);
            ObjBOL.ManualDispatchDate = Utility.ConvertDate(txtManualsDisp.Text);
            ObjBOL.InstallationBy = Convert.ToInt16(ddlInstallationBy.SelectedValue);
            ObjBOL.InstallDate = Utility.ConvertDate(txtInstallationStart.Text);
            ObjBOL.InstallationCompletionDate = Utility.ConvertDate(txtInstallationEnd.Text);
            // to do
            //ObjBOL.NoInstallation = txtJobId.Text;
            ObjBOL.DemoDate = Utility.ConvertDate(txtDemo.Text);
            ObjBOL.WarrantyStartDate = Utility.ConvertDate(txtWarrantyStart.Text);
            ObjBOL.WarrantyEndDate = Utility.ConvertDate(txtWarrantyEnd.Text);
            ObjBOL.FollowUpDate = Utility.ConvertDate(txtFollowUp.Text);
            ObjBOL.CustCarePackageSendDate = Utility.ConvertDate(txtCarePack.Text);
            ObjBOL.PONumber = txtPONumber.Text;
            ObjBOL.InvoiceNumber = txtinvnumber.Text;
            ObjBOL.DateInvoiceSent = Utility.ConvertDate(txtInvodate.Text);
            ObjBOL.DatePaymentReceived = Utility.ConvertDate(txtDateReceived.Text);
            ObjBOL.DateCommissionPaid = Utility.ConvertDate(txtCommDate.Text);
            ObjBOL.KflexCheckNumber = txtCommCheque.Text;
            ObjBOL.CommissionType = ddlRate.SelectedValue;
            ObjBOL.SalesSourceID = Convert.ToInt32(ddlSalesSource.SelectedValue);
            //ObjBOL.ProjectDesignerID = Convert.ToInt32(ddlDesigner.SelectedValue);
            //ObjBOL.DateAssigned = Utility.ConvertDate(txtDateAssigned.Text);
            ObjBOL.ShipToName = txtCompany.Text;
            ObjBOL.ShipToStreet = txtAddress.Text;
            ObjBOL.ShipToCity = txtCity.Text;
            ObjBOL.ShipToState = ddlState.SelectedValue;
            ObjBOL.ShipToCountry = ddlcountry.SelectedItem.Text;
            ObjBOL.ShipToZipCode = txtZip.Text;
            ObjBOL.discount = Utility.ToDecimal(txtDiscount.Text);
            ObjBOL.fob = Convert.ToInt32(ddlFOB.SelectedValue);
            ObjBOL.term = Convert.ToInt32(ddlTerm.SelectedValue);
            ObjBOL.IndComDate = Utility.ConvertDate(txtIndComDate.Text);
            ObjBOL.AeroChequeNum = txtChequeNo.Text;
            // to do 
            //ObjBOL.PreInspectionDate = txt.Text;
            //ObjBOL.CheckedByOffice = txtJobId.Text;
            //ObjBOL.CheckedByPlant = txtJobId.Text;
            //if (chkCanel.Checked == true)
            //{
            //    ObjBOL.CancelJob = true;
            //}
            //else
            //{
            //    ObjBOL.CancelJob = false;
            //}
            //ObjBOL.DigitalPicOnServer = txtJobId.Text;
            //ObjBOL.ReferenceDrawing = txtJobId.Text;
            //ObjBOL.DealerMember = ddlme.Text;
            //ObjBOL.BuyOutCost = txtJobId.Text;
            //ObjBOL.RawMaterial = txtJobId.Text;
            //ObjBOL.ExWarrantyPrice = txtJobId.Text;
            ObjBOL.NetAmount = Utility.ToDecimal(txtNetAmount.Text);
            ObjBOL.FreightPaid = Utility.ToDecimal(txtActualFreight.Text);
            ObjBOL.GST = Utility.ToDecimal(txtHST.Text);
            ObjBOL.InstallatorA = Convert.ToInt16(ddlInstallerA.SelectedValue);
            ObjBOL.InstallatorB = Convert.ToInt16(ddlInstallerB.SelectedValue);
            ObjBOL.InstallatorC = Convert.ToInt16(ddlInstallerC.SelectedValue);
            ObjBOL.ConCost = Utility.ToDecimal(txtSMCost.Text);
            ObjBOL.ConRoylAmt = Utility.ToDecimal(txtRoyalAmount.Text);
            ObjBOL.ConCheckNo = txtCheq.Text;
            ObjBOL.ConChqPaidDt = Utility.ConvertDate(txtDatePaid.Text);
            ObjBOL.Comments = txtTestRemarks.Text;
            //0= false, 1=true
            if (rdbPM.SelectedValue == "0")
            {
                ObjBOL.PMPack = false;
            }
            else if (rdbPM.SelectedValue == "1")
            {
                ObjBOL.PMPack = true;
            }
            ObjBOL.ReviewedBy = Convert.ToInt32(ddlReviewedBy.SelectedValue);
            ObjBOL.Status = Convert.ToInt32(ddlFabStatus.SelectedValue);
            ObjBOL.PurchasedItems = ddlPurchasedItems.SelectedValue;
            ObjBOL.PurchasedItemsCAD = ddlPurchasedItemsCAD.SelectedValue;
            // todo
            //ObjBOL.DrgSentOutforApproval = txtJobId.Text;
            //ObjBOL.AppDrgWithFieldDimension = txtJobId.Text;
            //ObjBOL.AppDrgAck = txtJobId.Text;
            //ObjBOL.EquipDelConfirmed = txtJobId.Text;
            //ObjBOL.AccReqFromCustomer = txtJobId.Text;
            //ObjBOL.BuiltDrgWithUnderStruSent = txtJobId.Text;
            ObjBOL.ProjDataPrepBy = Convert.ToInt32(ddlPreparedBy.SelectedValue);
            ObjBOL.ProjFormReviewByAI = Convert.ToInt32(ddlReviewedByAI.SelectedValue);
            ObjBOL.ProjFormReviewByHO = Convert.ToInt32(ddlReviewedByHO.SelectedValue);
            //ObjBOL.FabDrgReviewByAI = Utility.ConvertDate(txtReviewedByAI.Text);
            //ObjBOL.FabDrgReviewByHO = txtJobId.Text;
            ObjBOL.PFRBAIDate = Utility.ConvertDate(txtReviewedByAI.Text);
            //ObjBOL.PFRBIDate = txtReviewedByAI.Text;
            ObjBOL.PFRBHODate = Utility.ConvertDate(txtReviewedByHO.Text);
            //ObjBOL.FDRBAIDate = Utility.ConvertDate(txtReviewedByAI.Text);
            //ObjBOL.FDRBHODate = txtJobId.Text;
            //ObjBOL.FeedBackConsultant = txtConsultantFeedback.Text;
            //ObjBOL.FeedBackDealer = txtDealerFeedback.Text;
            //ObjBOL.SummofSugg = txtSummary.Text;
            //ObjBOL.SpecCredit = Convert.ToString(rdbSpecCredit.SelectedValue);
            if (rdbSpecCredit.SelectedValue != "")
            {
                ObjBOL.SpecCredits = Convert.ToInt32(rdbSpecCredit.SelectedValue);
            }
            else if (rdbSpecCredit.SelectedValue == "1")
            {
                ObjBOL.SpecCredits = Convert.ToInt32(rdbSpecCredit.SelectedValue);
            }
            ObjBOL.SpecCreditPercentID = Convert.ToInt32(ddlSpecCredit.SelectedValue);
            ObjBOL.SpecCreditAmount = Utility.ToDecimal(txtSpecAmount.Text);
            ObjBOL.SpecCreditCheckNo = txtSpecCheque.Text;
            ObjBOL.SpecCreditPaidDate = Utility.ConvertDate(txtSpecPaid.Text);
            ObjBOL.GSICommissionType = txtCommissionRate.Text;
            ObjBOL.GSICommissionAmount = Utility.ToDecimal(txtCommissionAmount.Text);
            ObjBOL.GSICommissionCheckNo = txtCommissionChequeNo.Text;
            ObjBOL.GSICommissionSentDate = Utility.ConvertDate(txtCommissionDateSent.Text);
            // pfile
            ObjBOL.DealerID = Convert.ToInt16(ddlDealer.SelectedValue);
            ObjBOL.ConveyorTypeID = Convert.ToInt32(ddlConveyorType.SelectedValue);
            ObjBOL.OriginRepID = Convert.ToInt32(ddlOrgRep.SelectedValue);
            ObjBOL.ConsultRepID = Convert.ToInt32(ddlConsultantRep.SelectedValue);
            ObjBOL.RepID = Convert.ToInt32(ddlDesRep.SelectedValue);
            ObjBOL.ConsultantID = Convert.ToInt32(ddlConsultant.SelectedValue);
            //ObjBOL.ConsultantMemberId = Convert.ToInt32(ddlConsultantMember.SelectedValue);
            ObjBOL.Price = Utility.ToDecimal(txtEqPrice.Text);
            ObjBOL.Freight = Utility.ToDecimal(txtFreight.Text);
            ObjBOL.Installation = Utility.ToDecimal(txtInstall.Text);
            ObjBOL.CurrencyID = Convert.ToInt32(ddlCurrency.SelectedValue);
            //ObjBOL.CurrentStatus = Convert.ToString(ddlStatus.);
            //ObjBOL.OrderProbabilityID = Convert.ToInt32(ddlpr.SelectedValue);
            //ObjBOL.DetailedQuote = ddlCommissionRate.SelectedValue;
            //ObjBOL.Specifications = Utility.ToDecimal(txtCommissionAmount.Text);
            // ObjBOL.RefDrawing = txtCommissionChequeNo.Text;
            ObjBOL.EqDisAmount = Utility.ToDecimal(txtEqDisAmount.Text);
            ObjBOL.EqDiscount = Utility.ToDecimal(txtEqDiscount.Text);
            ObjBOL.NetEqPrice = Utility.ToDecimal(txtNetEqPrice.Text);
            ObjBOL.ExWarrantyPrice = Utility.ToDecimal(txtExWarranty.Text);
            //ObjBOL.MfgFacilityID = Convert.ToInt32(ddlMfgFacility.SelectedValue);
            ObjBOL.DateAssigned = Utility.ConvertDate(txtFabStartDate.Text);
            ObjBOL.ProjectDesignerID = Convert.ToInt32(ddlProjectDesigner.SelectedValue);
            ObjBOL.MfgFacilityID = Convert.ToInt32(ddlManuFac.SelectedValue);
            ObjBOL.DueDateCanada = Utility.ConvertDate(txtDueToCanda.Text);
            ObjBOL.FabSentToCanada = Utility.ConvertDate(txtFabtrication.Text);
            //ObjBOL.EngineerCanada = ddlProjectDesCanada.SelectedItem.Text;
            ObjBOL.ReleasedToNesting = Utility.ConvertDate(txtReleasetoNesting.Text);
            ObjBOL.ReleasedToShop = Utility.ConvertDate(txtProjectReleasedToShop.Text);
            ObjBOL.NestingStatus = ddlNestingStatus.SelectedValue.ToString();
            ObjBOL.ProjectStatus = Convert.ToInt32(ddlprojectstatus.SelectedValue);
            // ObjBOL.JobType = ddlProjectType.SelectedItem.Text;
            // ObjBOL.ExistingJobID = ddlExistingJobno.SelectedItem.Text;
            ObjBOL.ProjectManager = Convert.ToInt32(ddlProjectManager.SelectedValue);
            ObjBOL.ProjectCommNotes = txtProjectCommNotes.Text;
            ObjBOL.UserID = Utility.GetCurrentSession().EmployeeID;
            ObjBOL.CashDisAmt = Utility.ToDecimal(txtCashDiscountAmount.Text);
            ObjBOL.CashDisPer = Utility.ToDecimal(txtCashDiscountPer.Text);
            ObjBOL.CashAmtRec = Utility.ToDecimal(txtTAmountRec.Text);
            ObjBOL.AmountForComission = Utility.ToDecimal(txtAmountForComision.Text);
            msg = ObjBLL.SaveProject(ObjBOL);
            //Utility.ShowMessage(this, msg);
            if (msg == "1")
            {
                //lblMsg.Text = "Project Updated !!";
                Utility.ShowMessage_Success(Page, "Project Updated !!");
                Utility.MaintainLogsSpecial("FrmProject.aspx", "Update", txtJobId.Text);
            }
            else if (msg == "0")
            {
                //lblMsg.Text = "Project Inserted !!";
                Utility.ShowMessage_Success(Page, "Project Inserted !!");
                Utility.MaintainLogsSpecial("FrmProject.aspx", "Save", txtJobId.Text);
            }
            btnAdd.Enabled = true;
            btnSave.Text = "Update";
            string strMethodName = "GetConsultant();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
            string strMethodRepName = "GetConsultantRep();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodRepName, true);
            hfShipToArriveDate.Value = txtShipDate.Text;
            string strMethodNameNew = "GetValue();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);
            //todo.....
            //CREATEAPPOINTMENT();
            EnableDisableShipDate();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // Reset Controls
    private void Reset()
    {
        try
        {
            ddlPurchasedItems.Enabled = false;
            DisabledReportButtons();
            //Bind_Controls();
            //Bind_Control2();
            //Bind_Control3();
            //Bind_ControlReset();           
            //lblPShow.Text = String.Empty;
            ddlprojectstatus.SelectedIndex = 0;
            ddlProjectManager.SelectedIndex = 0;
            //cboProjectName.Items.Clear();
            //cboJNumber.Items.Clear();
            //cboProjectName.SelectedValue = "0";
            //cboJNumber.SelectedValue = "0";
            txtJobId.Text = string.Empty;
            ddlPNumber.SelectedIndex = 0;
            ddlOASentTo.SelectedIndex = 0;
            txtJobOrderDate.Text = string.Empty;
            txtOrderAckDate.Text = string.Empty;
            txtOADispatch.Text = string.Empty;
            //ddlContact.SelectedIndex = 0;
            //chkCanel.Checked = false;
            ddlCustomer.SelectedIndex = 0;
            txtPONumber.Text = string.Empty;
            ddlConsultantRep.SelectedIndex = 0;
            ddlOrgRep.SelectedIndex = 0;
            ddlDesRep.SelectedIndex = 0;
            ddlDealer.SelectedIndex = 0;
            ddlConsultant.SelectedIndex = 0;
            //ddlConsultantMember.SelectedIndex = 0;
            //ddlDesigner.SelectedIndex = 0;
            ddlSalesSource.SelectedIndex = 0;
            ddlServiceRep.SelectedIndex = 0;
            txtPoRecDate.Text = string.Empty;
            rdbOrderFor.ClearSelection();
            txtQuote.Text = string.Empty;
            //txtDateAssigned.Text = string.Empty;
            ddlConveyorType.SelectedIndex = 0;
            ddlModel.SelectedIndex = 0;
            ddlPreparedBy.SelectedIndex = 0;
            ddlReviewedByAI.SelectedIndex = 0;
            txtReviewedByAI.Text = string.Empty;
            ddlReviewedByHO.SelectedIndex = 0;
            txtReviewedByHO.Text = string.Empty;
            txtFabReleasedDate.Text = String.Empty;
            //todo
            rdbSpecCredit.ClearSelection();
            ddlSpecCredit.SelectedIndex = 0;
            txtSpecAmount.Text = string.Empty;
            txtSpecConsultantRep.Text = string.Empty;
            txtSpecConsultant.Text = string.Empty;
            txtSpecCheque.Text = string.Empty;
            txtSpecPaid.Text = string.Empty;
            txtReleased.Text = string.Empty;
            txtDateBuiltDrgsSent.Text = string.Empty;
            txtEstimatedCom.Text = string.Empty;
            txtActualCom.Text = string.Empty;
            txtTestRun.Text = string.Empty;
            ddlReviewedBy.SelectedIndex = 0;
            ddlFabStatus.SelectedIndex = 0;
            ddlPurchasedItems.SelectedIndex = 0;
            ddlPurchasedItemsCAD.SelectedIndex = 0;
            ddlInstallationBy.SelectedIndex = 0;
            ddlInstallerA.SelectedIndex = 0;
            ddlInstallerB.SelectedIndex = 0;
            ddlInstallerC.SelectedIndex = 0;
            txtInstallationStart.Text = string.Empty;
            txtInstallationEnd.Text = string.Empty;
            txtDemo.Text = string.Empty;
            txtWarrantyStart.Text = string.Empty;
            txtWarrantyEnd.Text = string.Empty;
            txtFollowUp.Text = string.Empty;
            txtCarePack.Text = string.Empty;
            txtManualsDisp.Text = string.Empty;
            txtTestRemarks.Text = string.Empty;
            rdbPM.SelectedValue = "0";
            //txtConsultantFeedback.Text = string.Empty;
            //txtDealerFeedback.Text = string.Empty;
            //txtSummary.Text = string.Empty;
            // Second Tab
            ddlCurrency.SelectedIndex = 0;
            txtEqPrice.Text = string.Empty;
            txtEqDiscount.Text = string.Empty;
            txtEqDisAmount.Text = string.Empty;
            txtCashDiscountAmount.Text = string.Empty;
            txtCashDiscountPer.Text = string.Empty;
            txtTAmountRec.Text = string.Empty;
            txtAmountForComision.Text = string.Empty;
            txtNetEqPrice.Text = string.Empty;
            txtAmountInvoiced.Text = String.Empty;
            txtFreight.Text = string.Empty;
            txtInstall.Text = string.Empty;
            txtExWarranty.Text = string.Empty;
            txtNetAmount.Text = string.Empty;
            txtHST.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            txtinvnumber.Text = string.Empty;
            txtInvodate.Text = string.Empty;
            txtChequeNo.Text = string.Empty;
            txtIndComDate.Text = string.Empty;
            txtDateReceived.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtAmount.Text = string.Empty;
            ddlFOB.SelectedIndex = 0;
            ddlTerm.SelectedIndex = 0;
            txtActualFreight.Text = string.Empty;
            ddlRate.SelectedIndex = 0;
            //todo
            txtCommAmount.Text = string.Empty;
            txtCommCheque.Text = string.Empty;
            txtCommDate.Text = string.Empty;
            txtCommissionRate.Text = string.Empty;
            txtCommissionAmount.Text = string.Empty;
            txtCommissionChequeNo.Text = string.Empty;
            txtCommissionDateSent.Text = string.Empty;
            //todo
            ddlShipper.SelectedIndex = 0;
            ddlShippingComit.SelectedIndex = 0;
            ddlShippingStatus.SelectedIndex = 0;
            txtShipDate.Text = string.Empty;
            txtShipToArrive.Text = string.Empty;
            txtArrivalDate.Text = string.Empty;
            txtCompany.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlState.SelectedIndex = 0;
            ddlcountry.SelectedIndex = 0;
            txtZip.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtSMCost.Text = string.Empty;
            //todo
            txtRoyalAmount.Text = string.Empty;
            txtCheq.Text = string.Empty;
            txtDatePaid.Text = string.Empty;
            txtConRoyalAmount.Text = string.Empty;
            Session["PNumber"] = null;
            btnSave.Text = "Save";
            btnAdd.Enabled = true;
            Session["JobID"] = null;
            GvShpDrg.DataSource = EmptyDT();
            GvShpDrg.DataBind();
            GvShpDrg.Rows[0].Visible = false;
            txtFabStartDate.Text = String.Empty;
            ddlProjectDesigner.SelectedIndex = 0;
            txtDueToCanda.Text = String.Empty;
            txtFabtrication.Text = String.Empty;
            ddlProjectDesCanada.SelectedIndex = 0;
            ddlManuFac.SelectedIndex = 0;
            txtReleasetoNesting.Text = String.Empty;
            txtProjectReleasedToShop.Text = String.Empty;
            //ddlProjectType.SelectedIndex = 0;
            //ddlExistingJobno.SelectedIndex = -1;
            txtSearchPName.Text = "";
            txtSearchPNum.Text = "";
            txtExpectedArrivalDatefromChina.Text = string.Empty;
            lblDesRep.Text = String.Empty;
            lblPM.Text = String.Empty;
            lblConsultant.Text = String.Empty;
            //lblDealer.Text = String.Empty;
            lblDesRep.Visible = false;
            lblPM.Visible = false;
            lblConsultant.Visible = false;
            btnProposalRedirect.Text = "Models";
            //lblDealer.Visible = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }
    /// <summary>
    /// Reset All Controls in Project Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Reset controls
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

    //// Calculate Amount on Percentage Change
    //protected void ddlRate_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlRate.SelectedIndex > 0)
    //        {
    //            if (txtNetEqPrice.Text != "")
    //            {
    //                Decimal EqPrice = Convert.ToDecimal(txtNetEqPrice.Text);
    //                Decimal ComPercentage = Convert.ToDecimal(ddlRate.SelectedValue);
    //                Decimal CalAmount = (EqPrice * ComPercentage) / 100;
    //                txtCommAmount.Text = CalAmount.ToString("F");
    //            }
    //            else
    //            {
    //                txtCommAmount.Text = "0";
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }

    //}

    // Calculate Amount on Commission Change
    //protected void ddlCommissionRate_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlCommissionRate.SelectedIndex > 0)
    //    {
    //        if (txtNetEqPrice.Text != "")
    //        {
    //            Decimal EqPrice = Convert.ToDecimal(txtNetEqPrice.Text);
    //            Decimal ComPercentage = Convert.ToDecimal(ddlCommissionRate.SelectedValue);
    //            Decimal CalAmount = (EqPrice * ComPercentage) / 100;
    //            txtCommissionAmount.Text = CalAmount.ToString("F");
    //        }
    //    }
    //    else
    //    {
    //        txtCommissionAmount.Text = "0";
    //    }
    //}

    //// Calculate Amount on Discount Change
    //protected void txtDiscount_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (txtDiscount.Text != "")
    //        {
    //            if (txtNetEqPrice.Text != "")
    //            {
    //                Decimal EqPrice = Convert.ToDecimal(txtNetAmount.Text);
    //                Decimal ComPercentage = Convert.ToDecimal(txtDiscount.Text);
    //                Decimal CalAmount = (EqPrice * ComPercentage) / 100;
    //                txtAmount.Text = CalAmount.ToString("F");
    //            }
    //        }
    //        else
    //        {
    //            txtAmount.Text = "0";
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }

    //}
    /// <summary>
    /// Visible  Space Miser DIV if Conveyor Model Drop Down Value is Space Miser
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //Space Miser Show/Hide
    protected void ddlConveyorType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlConveyorType.SelectedValue == "82")
            {
                //pnlSpaceMiser.Visible = true;
            }
            else
            {
                //pnlSpaceMiser.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }
    /// <summary>
    /// Depends on Invoice Number Text Box.
    /// If Invoice fills then Ship To Arrive Date Disabled other wise enabled.
    /// </summary>
    // logic to Enable/Disable Ship date
    private void EnableDisableShipDate()
    {
        try
        {
            if (string.IsNullOrEmpty(txtinvnumber.Text) == false || string.IsNullOrEmpty(txtinvnumber.Text) == false)
            {
                if (string.IsNullOrEmpty(txtShipDate.Text) == false)
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

    /// <summary>
    /// FillDetails() Method Fill Grid View if user Add new records or update records.
    /// 
    /// </summary>
    /// <param name="strJNumber"></param>
    /// 
    //Bind Shop Drawing Grid View
    private void FillDetails(string strJNumber)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOLShpDrg.Operation = 11;
            ObjBOLShpDrg.JobID = strJNumber;
            ds = ObjBLLShpDrg.GetDataShpDrgs(ObjBOLShpDrg);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvShpDrg.DataSource = ds;
                GvShpDrg.DataBind();
            }
            else
            {
                GvShpDrg.DataSource = EmptyDT();
                GvShpDrg.DataBind();
                GvShpDrg.Rows[0].Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Create New Data Table for New Records entry in Grid View Control.
    /// </summary>
    /// <returns></returns>
    //Empty Grid View
    private DataTable EmptyDT()
    {
        DataTable dtEmpty = new DataTable();
        try
        {
            dtEmpty.Columns.Add("sDrgNum", typeof(string));
            dtEmpty.Columns.Add("sDrgJID", typeof(string));
            dtEmpty.Columns.Add("sDrgReqBy", typeof(int));
            dtEmpty.Columns.Add("SDrgsNature", typeof(string));
            dtEmpty.Columns.Add("sDrgReqDateByRCD", typeof(DateTime));
            dtEmpty.Columns.Add("sDrgReqRecInIndia", typeof(DateTime));
            dtEmpty.Columns.Add("sDrgProjEngg", typeof(int));
            dtEmpty.Columns.Add("sDrgSentToCA", typeof(DateTime));
            dtEmpty.Columns.Add("sDrgSentToRCD", typeof(DateTime));
            dtEmpty.Columns.Add("sDrgAppDate", typeof(DateTime));
            dtEmpty.Columns.Add("sDrgComment", typeof(string));
            dtEmpty.Columns.Add("sDrgWantDate", typeof(DateTime));
            dtEmpty.Columns.Add("sDrgPromiseDate", typeof(DateTime));
            dtEmpty.Columns.Add("sDrgExpecApprovalDate", typeof(DateTime));
            dtEmpty.Columns.Add("sNextFolowupDate", typeof(DateTime));
            dtEmpty.Columns.Add("sDateFollowedUp", typeof(DateTime));
            dtEmpty.Columns.Add("sDateReleasedToFab", typeof(DateTime));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);//adding row to the datatable
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    /// <summary>
    /// Update previous entred records in grid view Control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //Update Records in Grid View
    protected void GvShpDrg_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = GvShpDrg.Rows[e.RowIndex];
            ObjBOLShpDrg.Operation = 13;
            TextBox txtDrgSentToRCD = row.FindControl("txtDrgSentToRCD") as TextBox;
            if (txtDrgSentToRCD.Text != "")
            {
                ObjBOLShpDrg.sDrgNum = (row.FindControl("txtDrgNum") as TextBox).Text;
                ObjBOLShpDrg.sDrgJID = (row.FindControl("txtDrgJID") as TextBox).Text;
                TextBox txtDrgWantDate = row.FindControl("txtDrgWantDate") as TextBox;
                ObjBOLShpDrg.sDrgWantDate = Utility.ConvertDate(txtDrgWantDate.Text);
                TextBox txtDrgPromisedDate = row.FindControl("txtDrgPromisedDate") as TextBox;
                ObjBOLShpDrg.sDrgPromiseDate = Utility.ConvertDate(txtDrgPromisedDate.Text);
                TextBox txtDrgExpectedApprovalDate = row.FindControl("txtDrgExpectedApprovalDate") as TextBox;
                ObjBOLShpDrg.sDrgExpecApprovalDate = Utility.ConvertDate(txtDrgExpectedApprovalDate.Text);
                ObjBOLShpDrg.sDrgSentToRCD = Utility.ConvertDate(txtDrgSentToRCD.Text);
                TextBox txtDrgAppDate = row.FindControl("txtDrgAppDate") as TextBox;
                ObjBOLShpDrg.sDrgAppDate = Utility.ConvertDate(txtDrgAppDate.Text);
                TextBox txtDrgNextFollowupDate = row.FindControl("txtDrgNextFollowupDate") as TextBox;
                ObjBOLShpDrg.sNextFolowupDate = Utility.ConvertDate(txtDrgNextFollowupDate.Text);
                TextBox txtDateReleasedToFab = row.FindControl("txtDateReleasedToFab") as TextBox;
                ObjBOLShpDrg.sDateReleasedToFab = Utility.ConvertDate(txtDateReleasedToFab.Text);
                TextBox txtDrgDateFollowedUp = row.FindControl("txtDrgDateFollowedUp") as TextBox;
                ObjBOLShpDrg.sDateFollowedUp = Utility.ConvertDate(txtDrgDateFollowedUp.Text);
                ObjBOLShpDrg.sDrgComment = (row.FindControl("txtDrgComment") as TextBox).Text;
                msg = ObjBLLShpDrg.SaveDataShpDrg(ObjBOLShpDrg);
                GvShpDrg.EditIndex = -1;
                //Utility.ShowMessage(this, msg);
                Utility.ShowMessage_Success(Page, msg);
                FillDetails(HfJObID.Value);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
                SpecCredit();
            }
            else
            {
                //Utility.ShowMessage(this, "Please fill DwgSentToRCD !!");
                Utility.ShowMessage_Error(Page, "Please fill DwgSentToRCD !!");
                txtDrgSentToRCD.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
                SpecCredit();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Cancel all impormation from grid view control and return to the Edit.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //Cancel Records in Grid View Control
    protected void GvShpDrg_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        try
        {
            GvShpDrg.EditIndex = -1;
            FillDetails(HfJObID.Value);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
            SpecCredit();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// It handles 10 Records one time in a Page.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //Grid View Page Indexing
    protected void GvShpDrg_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        try
        {
            GvShpDrg.PageIndex = e.NewPageIndex;
            FillDetails(HfJObID.Value);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
            SpecCredit();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Insert a new Record in Grid View Control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //Insert Records in Grid View
    protected void GvShpDrg_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Insert" && Page.IsValid)
            {
                string msg = "";
                ObjBOLShpDrg.Operation = 14;
                ObjBOLShpDrg.sDrgJID = txtJobId.Text;
                TextBox FtxtDrgSentToRCD = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgSentToRCD");
                if (FtxtDrgSentToRCD.Text != "")
                {
                    TextBox FtxtDrgNum = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgNum");
                    TextBox FtxtJobID = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtJobID");
                    TextBox FtxtDrgPromisedDate = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgPromisedDate");
                    TextBox FtxtDrgExpectedApprovalDate = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgExpectedApprovalDate");
                    TextBox FtxtDrgWantDate = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgWantDate");
                    TextBox FtxtDrgAppDate = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgAppDate");
                    TextBox FtxtDrgNextFollowupDate = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgNextFollowupDate");
                    TextBox FtxtDrgDateFollowedUp = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgDateFollowedUp");
                    TextBox FtxtDateReleasedToFab = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDateReleasedToFab");
                    TextBox FtxtDrgComment = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgComment");
                    ObjBOLShpDrg.sDrgWantDate = Utility.ConvertDate(FtxtDrgWantDate.Text);
                    ObjBOLShpDrg.sDrgPromiseDate = Utility.ConvertDate(FtxtDrgPromisedDate.Text);
                    ObjBOLShpDrg.sDrgExpecApprovalDate = Utility.ConvertDate(FtxtDrgExpectedApprovalDate.Text);
                    ObjBOLShpDrg.sDrgSentToRCD = Utility.ConvertDate(FtxtDrgSentToRCD.Text);
                    ObjBOLShpDrg.sDrgAppDate = Utility.ConvertDate(FtxtDrgAppDate.Text);
                    ObjBOLShpDrg.sNextFolowupDate = Utility.ConvertDate(FtxtDrgNextFollowupDate.Text);
                    ObjBOLShpDrg.sDateFollowedUp = Utility.ConvertDate(FtxtDrgDateFollowedUp.Text);
                    ObjBOLShpDrg.sDateReleasedToFab = Utility.ConvertDate(FtxtDateReleasedToFab.Text);
                    ObjBOLShpDrg.sDrgComment = FtxtDrgComment.Text;
                    msg = ObjBLLShpDrg.SaveDataShpDrg(ObjBOLShpDrg);
                    //Utility.ShowMessage(this, msg);
                    Utility.ShowMessage_Success(Page, msg);
                    FillDetails(HfJObID.Value);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
                    SpecCredit();
                }
                else
                {
                    //Utility.ShowMessage(this, "Please fill DwgSentToRCD !!");
                    Utility.ShowMessage_Error(Page, "Please fill DwgSentToRCD !!");
                    FtxtDrgSentToRCD.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Shop Drawing Edit Button Click
    /// After Click it Display Update and Cancel Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //Edit Button Control in Grid View
    protected void GvShpDrg_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            GvShpDrg.EditIndex = e.NewEditIndex;
            FillDetails(HfJObID.Value);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
            SpecCredit();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// ImgPnumber Moves to the Proposal Page and find deails of particular PNumber
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImgPNumber_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ddlPNumber.SelectedIndex > 0)
            {
                Session["PNumber"] = "";
                DataSet ds = new DataSet();
                ObjBOLSearch.Operation = 3;
                ObjBOLSearch.PNumber = ddlPNumber.SelectedValue;
                ds = ObjBLLSearch.GetProposalSearch(ObjBOLSearch);
                Session["PNumber"] = ds.Tables[0].Rows[0]["Pnumber"].ToString();
                Response.Redirect("~/SalesManagement/FrmProposals.aspx");
            }
            else
            {
                Utility.ShowMessage_Error(Page, "PNumber not Found !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnProposalRedirect_Click(object sender, EventArgs e)
    {
        ProposalRedirect();
    }

    protected void ProposalRedirect()
    {
        try
        {
            if (ddlPNumber.SelectedIndex > 0)
            {
                Session["PNumber"] = "";
                DataSet ds = new DataSet();
                ObjBOLSearch.Operation = 3;
                ObjBOLSearch.PNumber = ddlPNumber.SelectedValue;
                ds = ObjBLLSearch.GetProposalSearch(ObjBOLSearch);
                Session["PNumber"] = ds.Tables[0].Rows[0]["Pnumber"].ToString();
                string script = "openInNewTab('/SalesManagement/FrmProposals.aspx');";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "OpenNewTab", script, true);
            }
            else
            {
                Utility.ShowMessage_Error(Page, "PNumber not Found !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Redirect to the customer page and saw details of particular customer
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImgCustomer_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ddlCustomer.SelectedIndex > 0)
            {
                Response.Redirect("~/ContactManagement/FrmCustomers.aspx?cusid=" + ddlCustomer.SelectedItem.Text);
            }
            else
            {
                //Utility.ShowMessage(this, "Customer not Found !!");
                Utility.ShowMessage_Error(Page, "Customer not Found !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
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
                    //emp.LastName = Convert.ToString(ds.Tables[0].Rows[i]["LastName"]);
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
                    //emp.LastName = Convert.ToString(ds.Tables[0].Rows[i]["LastName"]);
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
                    //emp.LastName = Convert.ToString(ds.Tables[0].Rows[i]["LastName"]);
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
        String _CusState;
        public String CusState
        {
            get { return _CusState; }
            set { _CusState = value; }
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
                    emp.CusState = Convert.ToString(ds.Tables[0].Rows[i]["CusState"]);
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

    /// <summary>
    /// Move to the Project Seach Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/SalesManagement/FrmSearchProject.aspx");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public class CheckAssignedPNumber
    {
        String _PNumber;
        public String PNumber
        {
            get { return _PNumber; }
            set { _PNumber = value; }
        }
    }
    /// <summary>
    /// HideDuplicatePNumber() display Message if Pnumber is already linked with another JNumber.
    /// </summary>
    /// <param name="PNumber">
    /// /// </param>
    /// <returns>Return alert Message</returns>
    [WebMethod]
    public static string HideDuplicatePNumber(String PNumber)
    {
        //List<CheckAssignedPNumber> pnumber = new List<CheckAssignedPNumber>();
        string pnumber = "";
        try
        {
            DataSet ds = new DataSet();
            ds = Utility.CheckPNumber(PNumber);
            CheckAssignedPNumber detail = null;
            detail = new CheckAssignedPNumber();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //for(int i = 0; i< ds.Tables[0].Rows.Count;i++ )
                //{
                pnumber = Convert.ToString(ds.Tables[0].Rows[0]["JobID"]);
                // pnumber.Add(detail);
                // }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return pnumber;
    }

    public class AutoFillPNumberDetails
    {
        Int32 _DealerID;
        public Int32 DealerID
        {
            get { return _DealerID; }
            set { _DealerID = value; }
        }
        Int32 _ConveyorTypeID;
        public Int32 ConveyorTypeID
        {
            get { return _ConveyorTypeID; }
            set { _ConveyorTypeID = value; }
        }
        Int32 _OriginRepID;
        public Int32 OriginRepID
        {
            get { return _OriginRepID; }
            set { _OriginRepID = value; }
        }
        Int32 _ConsultRepID;
        public Int32 ConsultRepID
        {
            get { return _ConsultRepID; }
            set { _ConsultRepID = value; }
        }
        Int32 _RepID;
        public Int32 RepID
        {
            get { return _RepID; }
            set { _RepID = value; }
        }
        Int32 _ConsultantID;
        public Int32 ConsultantID
        {
            get { return _ConsultantID; }
            set { _ConsultantID = value; }
        }
        Int32 _ModelID;
        public Int32 ModelID
        {
            get { return _ModelID; }
            set { _ModelID = value; }
        }
        Decimal _Price;
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        Decimal _Freight;
        public Decimal Freight
        {
            get { return _Freight; }
            set { _Freight = value; }
        }
        Decimal _Installation;
        public Decimal Installation
        {
            get { return _Installation; }
            set { _Installation = value; }
        }
        Int32 _CurrencyID;
        public Int32 CurrencyID
        {
            get { return _CurrencyID; }
            set { _CurrencyID = value; }
        }
        Int32 _ProjectDesignerID;
        public Int32 ProjectDesignerID
        {
            get { return _ProjectDesignerID; }
            set { _ProjectDesignerID = value; }
        }
        Decimal _EqDiscount;
        public Decimal EqDiscount
        {
            get { return _EqDiscount; }
            set { _EqDiscount = value; }
        }
        Decimal _EqDisAmount;
        public Decimal EqDisAmount
        {
            get { return _EqDisAmount; }
            set { _EqDisAmount = value; }
        }
        Decimal _NetEqPrice;
        public Decimal NetEqPrice
        {
            get { return _NetEqPrice; }
            set { _NetEqPrice = value; }
        }
        Int32 _SpecCredits;
        public Int32 SpecCredits
        {
            get { return _SpecCredits; }
            set { _SpecCredits = value; }
        }
        Int32 _SpecCreditPercentID;
        public Int32 SpecCreditPercentID
        {
            get { return _SpecCreditPercentID; }
            set { _SpecCreditPercentID = value; }
        }
        Decimal _SpecCreditAmount;
        public Decimal SpecCreditAmount
        {
            get { return _SpecCreditAmount; }
            set { _SpecCreditAmount = value; }
        }
        String _SpecCreditCheckNo;
        public String SpecCreditCheckNo
        {
            get { return _SpecCreditCheckNo; }
            set { _SpecCreditCheckNo = value; }
        }
        DateTime _SpecCreditPaidDate;
        public DateTime SpecCreditPaidDate
        {
            get { return _SpecCreditPaidDate; }
            set { _SpecCreditPaidDate = value; }
        }
        Int32 _OrderBelongsTo;
        public Int32 OrderBelongsTo
        {
            get { return _OrderBelongsTo; }
            set { _OrderBelongsTo = value; }

        }
        DateTime? _shipdate;
        public DateTime? shipdate
        {
            get { return _shipdate; }
            set { _shipdate = value; }
        }
        String _JobType;
        public String JobType
        {
            get { return _JobType; }
            set { _JobType = value; }
        }
        String _ExistingJobID;
        public String ExistingJobID
        {
            get { return _ExistingJobID; }
            set { _ExistingJobID = value; }
        }
    }

    private void AutoFillDetails(string PNumber)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = Utility.AutoFillPNumber(PNumber);
            AutoFillPNumberDetails detail = null;
            detail = new AutoFillPNumberDetails();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(ds.Tables[0].Rows[0]["DealerID"]) != "")
                {
                    ddlDealer.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["DealerID"]);
                }
                if (Convert.ToString(ds.Tables[0].Rows[0]["ConveyorTypeID"]) != "")
                {
                    ddlConveyorType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ConveyorTypeID"]);
                }
                if (Convert.ToString(ds.Tables[0].Rows[0]["OriginRepID"]) != "")
                {
                    ddlOrgRep.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["OriginRepID"]);
                }
                ddlConsultantRep.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ConsultRepID"]);
                ddlDesRep.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["RepID"]);
                ddlConsultant.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ConsultantID"]);
                ddlModel.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ModelID"]);
                Decimal EqPrice = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["Price"]), 2);
                txtEqPrice.Text = Convert.ToString(EqPrice);
                Decimal Freight = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["Freight"]), 2);
                txtFreight.Text = Convert.ToString(Freight);
                Decimal Installation = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["Installation"]), 2);
                txtInstall.Text = Convert.ToString(Installation);
                ddlCurrency.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CurrencyID"]);
                Decimal EqDiscount = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["EqDiscount"]), 2);
                txtEqDiscount.Text = Convert.ToString(EqDiscount);
                Decimal EqDisAmount = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["EqDisAmount"]), 2);
                txtEqDisAmount.Text = Convert.ToString(EqDisAmount);
                Decimal NetEqPrice = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["NetEqPrice"]), 2);
                txtNetEqPrice.Text = Convert.ToString(NetEqPrice);
                if (Convert.ToString(ds.Tables[0].Rows[0]["SpecCredits"]) != "0")
                {
                    rdbSpecCredit.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SpecCredits"]);
                }
                ddlSpecCredit.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SpecCreditPercentID"]);
                Decimal SpecAmount = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["SpecCreditAmount"]), 2);
                txtSpecAmount.Text = Convert.ToString(SpecAmount);
                txtSpecCheque.Text = Convert.ToString(ds.Tables[0].Rows[0]["SpecCreditCheckNo"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["SpecCreditPaidDate"]) != "")
                {
                    txtSpecPaid.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["SpecCreditPaidDate"]));
                }
                if (ddlConsultant.SelectedIndex > 0)
                {
                    txtSpecConsultant.Text = ddlConsultant.SelectedItem.Text;
                }
                if (ddlConsultantRep.SelectedIndex > 0)
                {
                    txtSpecConsultantRep.Text = ddlConsultantRep.SelectedItem.Text;
                }
                rdbOrderFor.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["OrderBelongsTo"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["shipdate"]) != "")
                {
                    txtShipDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["shipdate"]));
                }
                //if(Convert.ToString(ds.Tables[0].Rows[0]["JobTypeid"]) != "")
                //{
                //    ddlProjectType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["JobTypeid"]);
                //}                   
                //if(Convert.ToString(ds.Tables[0].Rows[0]["ExistingJobID"]) != "")
                //{                    
                //    ddlExistingJobno.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ExistingJobID"]);
                //}
                if (Convert.ToString(ds.Tables[0].Rows[0]["ProjectManager"]) != "")
                {
                    ddlProjectManager.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ProjectManager"]);
                }

            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    public class AutoFillPNumberBind
    {
        String _PNumber;
        public String PNumber
        {
            get { return _PNumber; }
            set { _PNumber = value; }
        }
    }

    //public void CREATEAPPOINTMENT()
    //{
    //    Outlook.Application application = new Outlook.Application();
    //    Outlook.NameSpace ONS = application.GetNamespace("MAPI");
    //    Outlook.MAPIFolder folder = ONS.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar) as Outlook.Folder;
    //    Outlook.Items calenderitems = folder.Items;
    //    Outlook.AppointmentItem myapt = folder.Items.Add(Outlook.OlItemType.olAppointmentItem) as Outlook.AppointmentItem;
    //    {
    //        var withBlock = myapt;            
    //        myapt.Start = Convert.ToDateTime(txtShipDate.Text);
    //        myapt.End = Convert.ToDateTime(txtShipDate.Text);
    //      //  myapt.RequiredAttendees = "J193043";
    //        myapt.Subject = txtProject.Text;
    //        DeleteAppointment();
    //        myapt.Save();

    //    }
    //}

    //public void DeleteAppointment()
    //{
    //    Microsoft.Office.Interop.Outlook.Application OlApp = new Microsoft.Office.Interop.Outlook.Application();
    //    Outlook.NameSpace OlNameSpace = OlApp.GetNamespace("MAPI");
    //    Outlook.MAPIFolder Appointmentfolder = OlNameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar);
    //    Appointmentfolder.Items.IncludeRecurrences = true;
    //    foreach (Outlook.AppointmentItem app in Appointmentfolder.Items)
    //    {

    //        if (app.Subject == txtProject.Text)
    //        {
    //            app.Delete();

    //        }

    //    }

    //}

    protected void btnInf_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            rprt.Load(Server.MapPath("~/Reports/rptProjectShippingInf.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_qryProjectsInstallation] '" + HfJObID.Value + "'");
            rprt.SetDataSource(dt);
            rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            rprt.Close();
            rprt.Dispose();
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
    }

    protected void btnCuspack_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            rprt.Load(Server.MapPath("~/Reports/rptCustCarePackageLetter.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_qryCustMemberMain] '" + HfJObID.Value + "'");
            rprt.SetDataSource(dt);
            rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            rprt.Close();
            rprt.Dispose();
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
    }

    protected void btnAcknoledgement_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = ReportData();
            rprt.Load(Server.MapPath("~/Reports/rptOrderAcknowledgment.rpt"));
            rprt.SetDataSource(dt);
            rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            rprt.Close();
            rprt.Dispose();
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        clscon.Return_DT(dt, "EXEC [dbo].[Get_qryOrderProbability] '" + HfJObID.Value + "'");
        return dt;
    }

    protected void txtReleased_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtFabReleasedDate.Text = txtReleased.Text;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtFabReleasedDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtReleased.Text = txtFabReleasedDate.Text;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFab()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Get_Tax();
            SpecCredit();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void MatchingProposalwithJob(string PNumber)
    {
        try
        {
            string JobID = "";
            DataSet ds = new DataSet();
            ds = Utility.CheckPNumber(PNumber);
            if (ds.Tables[0].Rows.Count > 0)
            {
                JobID = Convert.ToString(ds.Tables[0].Rows[0]["JobID"]);
                if (JobID != "")
                {
                    string PNum = ddlPNumber.SelectedValue;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('" + JobID +"'  );", true);
                    Utility.ShowMessage_Error(Page, "'" + JobID + "'");
                    ddlPNumber.SelectedIndex = 0;
                    ddlPNumber.Focus();
                }
            }
            else
            {
                AutoFillDetails(ddlPNumber.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtinvnumber_TextChanged(object sender, EventArgs e)
    {
        try
        {
            EnableDisableShipDate();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            MatchingProposalwithJob(ddlPNumber.SelectedValue);
            SpecCredit();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvShpDrg_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            string ID = Convert.ToString(GvShpDrg.DataKeys[e.RowIndex].Value);
            ObjBOLShpDrg.Operation = 24;
            ObjBOLShpDrg.sDrgNum = ID;
            msg = ObjBLLShpDrg.SaveDataShpDrg(ObjBOLShpDrg);
            FillDetails(HfJObID.Value);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
            SpecCredit();
            Utility.MaintainLogsSpecial("frmProjects", "Delete Shop Dwg", ID);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtSearchPName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtSearchPName.Text != "")
            {
                txtSearchPNum.Text = string.Empty;
                string output = txtSearchPName.Text;
                int openTagEndPosition = output.IndexOf("#");
                output = output.Substring(openTagEndPosition + 1);
                FillDetailsFromJnumber(output);
                SpecCredit();
                HfJObID.Value = output;
                EnableDisableReports();
                SyncTextbox("NUM", output);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SyncTextbox(string type, string text)
    {
        if (type != "")
        {
            DataTable dt = new DataTable();
            if (type == "NUM")
            {
                dt = Utility.ReturnProjects(26, text);
                if (dt.Rows.Count > 0)
                {
                    txtSearchPNum.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                }
                else
                {
                    txtSearchPNum.Text = "";
                    txtSearchPName.Text = "";
                    //Utility.ShowMessage(this, "J# not Found");
                    Utility.ShowMessage_Error(Page, "J# not Found");
                }
            }
            else
            {
                dt = Utility.ReturnProjects(25, text);
                if (dt.Rows.Count > 0)
                {
                    txtSearchPName.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                }
                else
                {
                    txtSearchPNum.Text = "";
                    txtSearchPName.Text = "";
                    //Utility.ShowMessage(this, "J# not Found");
                    Utility.ShowMessage_Error(Page, "J# not Found");
                }
            }
            CheckPaymentInfo();
            //GetCashDiscountFromDealer();
        }
    }

    protected void txtSearchPNum_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtSearchPNum.Text.Length >= 7)
            {
                //EnabledReportButtons();
                string OutJnumber = string.Empty;
                if (txtSearchPNum.Text.Length > 7)
                {
                    OutJnumber = txtSearchPNum.Text.Substring(0, txtSearchPNum.Text.IndexOf(','));
                }
                else
                {
                    OutJnumber = txtSearchPNum.Text;
                }
                HfJObID.Value = OutJnumber;
                FillJnumber(txtSearchPNum.Text);
                SpecCredit();
                EnableDisableReports();
                //SyncTextbox("NAME", OutJnumber);
                return;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckUserForRelease()
    {
        int userid = Convert.ToInt32(Utility.GetCurrentUser());
        //89 = Bhatiwal, 96 = kalsi
        if (userid == 89 || userid == 96 || userid == 263)
        {
            if (hfReleased.Value == "True")
            {
                btnRelease.Enabled = false;
                btnRollback.Enabled = true;
            }
            else if (hfReleased.Value == "False")
            {
                btnRelease.Enabled = true;
                btnRollback.Enabled = false;
            }
        }
    }

    BOLINVPartsInfo ObjBOLRel = new BOLINVPartsInfo();
    BLLINVPartsinfo ObjBLLRel = new BLLINVPartsinfo();
    protected void btnRelease_Click(object sender, EventArgs e)
    {
        try
        {
            if (HfJObID.Value != "")
            {
                string msg = "";
                ObjBOLRel.operation = 2;
                ObjBOLRel.projectid = HfJObID.Value;
                ObjBOLRel.userid = Convert.ToInt32(Utility.GetCurrentUser());
                msg = ObjBLLRel.ReleaseProject(ObjBOLRel);
                //Utility.ShowMessage(this, msg.Trim());
                Utility.ShowMessage_Success(Page, msg.Trim());
                if (msg.Trim() == "Project Released !!")
                {
                    Utility.MaintainLogsSpecial("frmRelease", "Release", HfJObID.Value.ToString());
                    FillDetailsFromJnumber(HfJObID.Value);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnRollback_Click(object sender, EventArgs e)
    {
        try
        {
            if (HfJObID.Value != "")
            {
                string msg = "";
                ObjBOLRel.operation = 3;
                ObjBOLRel.projectid = HfJObID.Value;
                ObjBOLRel.userid = Convert.ToInt32(Utility.GetCurrentUser());
                msg = ObjBLLRel.ReleaseProject(ObjBOLRel);
                //Utility.ShowMessage(this, msg.Trim());
                Utility.ShowMessage_Success(Page, msg.Trim());
                if (msg.Trim() == "Project Rollbacked !!")
                {
                    Utility.MaintainLogsSpecial("frmRollback", "Rollback", HfJObID.Value.ToString());
                    FillDetailsFromJnumber(HfJObID.Value);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void lnkRedirecttoCustomer_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCustomer.SelectedIndex > 0 && txtJobId.Text != "")
            {
                Session["CustomerID"] = "";
                Session["CustomerID"] = ddlCustomer.SelectedValue;
                Session["JobID"] = HfJObID.Value;
                Response.Redirect("~/ContactManagement/FrmCustomers.aspx", false);
            }
            else
            {
                if (txtSearchPNum.Text == "")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Job Details. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Enter Job Details. !");
                    txtSearchPNum.Focus();
                    return;
                }
                if (ddlCustomer.SelectedIndex == 0)
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Customer. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Select Customer. !");
                    ddlCustomer.Focus();
                    return;
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
    }

    protected void txtShipDate_TextChanged(object sender, EventArgs e)
    {
        if (txtJobId.Text.Trim() != "")
        {
            if (txtShipDate.Text.Trim() != "")
            {
                DateTime shipdate = Convert.ToDateTime(txtShipDate.Text);
                shipdate = shipdate.AddDays(7);
                txtShipToArrive.Text = shipdate.ToString("MM/dd/yyyy");
                DataSet ds = new DataSet();
                ObjBOLRel.operation = 1;
                ObjBOLRel.shipdate = Utility.ConvertDate(txtShipDate.Text);
                ds = ObjBLLRel.CheckWeeklyCount(ObjBOLRel);
                // Utility.ShowMessage(this, msg.Trim());
                Decimal NetAmount = 0;
                int PCount = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    NetAmount = Utility.ToDecimal(ds.Tables[0].Rows[0]["WTotal"].ToString());
                    PCount = Convert.ToInt32(ds.Tables[0].Rows[0]["ProjectCount"].ToString());
                }
                if (NetAmount > 300000 || PCount >= 8)
                {
                    //Utility.ShowMessage(this, "Total value of the week is $" + Convert.ToDecimal(ds.Tables[0].Rows[0]["WTotal"]).ToString("N") + " \\nAnd number of Projects is " + Convert.ToDecimal(ds.Tables[0].Rows[0]["ProjectCount"]));
                    Utility.ShowMessage_Success(Page, "Total value of the week is $" + Convert.ToDecimal(ds.Tables[0].Rows[0]["WTotal"]).ToString("N") + " \\nAnd number of Projects is " + Convert.ToDecimal(ds.Tables[0].Rows[0]["ProjectCount"]));
                }
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
            }
        }
    }

    protected void btnWarrntyLetter_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtSearchPNum.Text != "")
            {
                DataTable dt = new DataTable();
                rprt.Load(Server.MapPath("~/Reports/rptCustCareWarrantyLetter.rpt"));
                clscon.Return_DT(dt, "EXEC [dbo].[Get_WarrantyLetter] '" + HfJObID.Value + "'");
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtJobId.Text + " - Warranty Letter");
                rprt.Close();
                rprt.Dispose();
            }
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
    }

    protected void txtWarrantyStart_TextChanged(object sender, EventArgs e)
    {
        if (txtWarrantyStart.Text != "")
        {
            DateTime WEnddate = Convert.ToDateTime(txtWarrantyStart.Text).AddYears(1);
            txtWarrantyEnd.Text = cls.Converter(Convert.ToString(WEnddate));
        }
    }

    protected void ddlDealer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDealer.SelectedIndex > 0)
            {
                GetCashDiscountFromDealer();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetCashDiscountFromDealer()
    {
        try
        {
            decimal DiscountPer = 0;
            ObjBOL.DealerID = Convert.ToInt16(ddlDealer.SelectedValue);
            DiscountPer = ObjBLL.GetCashDiscount(ObjBOL);
            if (DiscountPer != 0)
            {
                txtCashDiscountPer.Text = DiscountPer.ToString();
                GetCashDiscountFromPer();
                //decimal EqPrice = Convert.ToDecimal(txtNetEqPrice.Text);
                //decimal DiscountPercent = Convert.ToDecimal(txtCashDiscountPer.Text);
                //decimal DiscountAmt = 0;
                //decimal AmtRec = 0;
                //DiscountAmt = (EqPrice * DiscountPercent) / 100;
                //txtCashDiscountAmount.Text = DiscountAmt.ToString("N");
                //AmtRec = (EqPrice - DiscountAmt);
                //txtAmountForComision.Text = AmtRec.ToString("N");
                //if (txtAmountForComision.Text == "")
                //{
                //    txtAmountForComision.Text = txtNetEqPrice.Text;
                //}
            }
            else
            {
                txtCashDiscountPer.Text = String.Empty;
                txtCashDiscountAmount.Text = String.Empty;
                txtAmountForComision.Text = txtNetEqPrice.Text;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetCashDiscountFromPer()
    {
        try
        {
            decimal EqPrice = Convert.ToDecimal(txtNetEqPrice.Text);
            decimal TAmtInvoiced = Convert.ToDecimal(txtAmountInvoiced.Text);
            decimal DiscountPercent = 0;
            decimal TAmtRec = 0;
            if (txtCashDiscountPer.Text != "")
            {
                DiscountPercent = Convert.ToDecimal(txtCashDiscountPer.Text);
            }
            decimal DiscountAmt = 0;
            decimal DiscountAmtRec = 0;
            decimal AmtRec = 0;
            DiscountAmt = (EqPrice * DiscountPercent) / 100;

            DiscountAmtRec = (EqPrice * DiscountPercent) / 100;
            TAmtRec = (TAmtInvoiced - DiscountAmt);
            txtCashDiscountAmount.Text = DiscountAmt.ToString("N");

            AmtRec = (EqPrice - DiscountAmtRec);

            txtAmountForComision.Text = AmtRec.ToString("N");
            txtTAmountRec.Text = TAmtRec.ToString("N");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //TODO
    private void GetCashDiscountFromAmt()
    {
        try
        {
            //decimal EqPrice = Convert.ToDecimal(txtNetEqPrice.Text);   
            decimal EqPrice = Convert.ToDecimal(txtNetEqPrice.Text);
            decimal TAmtInvoiced = 0;
            if (txtAmountInvoiced.Text == "")
            {
                TAmtInvoiced = 0;
            }
            else
            {
                TAmtInvoiced = Convert.ToDecimal(txtAmountInvoiced.Text);
            }

            decimal DiscountAmt = 0;
            if (txtCashDiscountAmount.Text != "")
            {
                DiscountAmt = Convert.ToDecimal(txtCashDiscountAmount.Text);
            }
            decimal DiscountAmtRec = 0;
            decimal DiscountPercent = 0;
            decimal AmtRec = 0;
            decimal TAmtRec = 0;
            DiscountPercent = (DiscountAmt / EqPrice) * 100;
            txtCashDiscountPer.Text = DiscountPercent.ToString("N");
            DiscountAmtRec = (EqPrice * DiscountPercent) / 100;

            //txtCashDiscountAmount.Text = DiscountAmt.ToString();
            AmtRec = (EqPrice - DiscountAmtRec);
            TAmtRec = (TAmtInvoiced - DiscountAmt);


            txtAmountForComision.Text = AmtRec.ToString("N");
            txtTAmountRec.Text = TAmtRec.ToString("N");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtCashDiscountPer_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //if (txtCashDiscountPer.Text != "")
            //{
            GetCashDiscountFromPer();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtCashDiscountAmount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //if (txtCashDiscountAmount.Text != "")
            //{
            GetCashDiscountFromAmt();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
            // }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtAmountInvoiced_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //if (txtCashDiscountAmount.Text != "")
            //{
            GetCashDiscountFromAmt();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
            //}
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

    protected void btnCADReport_Click(object sender, EventArgs e)
    {
        try
        {
            //Session["PNumber"] = "";
            //Session["PNumber"] = HfPNumber.Value.Replace(",", "");
            Response.Redirect("~/SalesManagement/FrmDailyCADReport.aspx?pNumber=" + ddlPNumber.SelectedValue, false);
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
            Response.Redirect("~/SalesManagement/FrmSiteVisitInformation.aspx?pNumber=" + ddlPNumber.SelectedValue, false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

}