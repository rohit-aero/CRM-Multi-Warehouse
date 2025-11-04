using System;
using System.Data;
using BOLAERO;
using BLLAERO;
using System.Web.Security;
using System.Collections.Generic;
using System.Web.UI;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Drawing;
using System.Net.Mime;
using System.Net;
using CrystalDecisions.Shared;
using System.Threading;

public partial class _Default : System.Web.UI.Page
{
    BOLManageProposals ObjBOL = new BOLManageProposals();
    BLLManageProposals ObjBLL = new BLLManageProposals();
    BLLDailyCADReport ObjBLL1 = new BLLDailyCADReport();
    BOLDailyCADReport ObjBOL1 = new BOLDailyCADReport();
    BOLForecastingMonthlyEmailData ObjBOLForecating = new BOLForecastingMonthlyEmailData();
    BLLForecastingMonthlyEmailData ObjBLLForecasting = new BLLForecastingMonthlyEmailData();
    BOLTrackContainerJobs ObjBOLTrackJobs = new BOLTrackContainerJobs();
    BLLTrackContainerJobs ObjBLLTrackJobs = new BLLTrackContainerJobs();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    int CheckContainerIndia = 0;
    int CheckContainerChina = 0;
    string Do_Not_Reply = "[Please do not reply to this message. Replies to this message are routed to an unmonitored mailbox]";
    string ForecastingdepartmentID = String.Empty;
    string ForecastingReportDate = String.Empty;
    int currentYear = DateTime.Now.Year;
    private static Dictionary<string, DateTime> userLastCall = new Dictionary<string, DateTime>();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //divDashboard.Visible = false;
            if (!IsPostBack)
            {
                if (Utility.IsAuthorized())
                {
                    ShowButtons();
                    ResetSession();
                    CheckEngineer();
                    AutomateEmail();
                    TrackJobsButtonEnabledDisabled();
                    BindQuotesandOrders();
                    GetDasboardData();
                    //TestForecastingReport();
                    //CheckForecatingUserPermission();                    
                }

                //For Live only (Send Emails for Pending followups)
                //Check_PendingProposals();
                //BindProposals();
                //var Reviewedby = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
                //var ReviewedbyID = new List<string> { "85", "257", "96", "240", "28", "245", "313" };
                //if (ReviewedbyID.Contains(Reviewedby))
                //{
                //    BindProposals();
                //}
                //else
                //{
                //    opener.Visible = false;
                //    openerNotFollowedup.Visible = false;
                //}               
            }
            else
            {
                ReBindGuageChart();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void TrackJobsButtonEnabledDisabled()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOLTrackJobs.ProjectManagerID = Utility.GetCurrentSession().EmployeeID;
            ds = ObjBLLTrackJobs.Return_DS(ObjBOLTrackJobs);
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnTrackJobs.Enabled = true;
            }
            else
            {
                btnTrackJobs.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindContainerJobs()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOLTrackJobs.ProjectManagerID = Utility.GetCurrentSession().EmployeeID;
            ds = ObjBLLTrackJobs.Return_DS(ObjBOLTrackJobs);
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnTrackJobs.Enabled = true;
                gvContainerJobs.DataSource = ds.Tables[0];
                gvContainerJobs.DataBind();
                string strMethodName = "ShowContainerJobs();";
                containerJobsHeader.InnerText = "Track Jobs Status ";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
            }
            else
            {
                btnTrackJobs.Enabled = false;
                gvContainerJobs.DataSource = "";
                gvContainerJobs.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void ResetSession()
    {
        try
        {
            Session["PNumber"] = null;
            Session["JobID"] = null;
            Session["SessionProjectSearch"] = null;
            Session["SessionProposalSearch"] = null;
            Session["CustomerID"] = null;
            Session["SJID"] = null;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ShowButtons()
    {
        try
        {
            String UserDep = string.Empty;
            UserDep = Convert.ToString(Utility.GetCurrentSession().RoleName);
            if (string.IsNullOrEmpty(UserDep) == false)
            {
                if (UserDep == "SD")
                {
                    btnopener.Visible = true;
                    btnopenerNotFollowedup.Visible = true;
                    btnTrackJobs.Visible = true;
                    if (Utility.GetCurrentSession().EmployeeID == 96)
                    {
                        btnShipDateUpdates.Visible = true;
                    }
                    else
                    {
                        btnShipDateUpdates.Visible = false;
                    }
                }
                else
                {
                    btnTrackJobs.Visible = false;
                    btnopener.Visible = false;
                    btnopenerNotFollowedup.Visible = false;
                    btnShipDateUpdates.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
            Response.Redirect("~/index.aspx");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Check_PendingProposals()
    {
        try
        {
            //if Friday
            if ((System.DateTime.Now.ToString("dddd") == "Friday"))
            {
                TimeSpan start = new TimeSpan(6, 00, 0); //6 o'clock
                TimeSpan end = new TimeSpan(9, 0, 0); //9 o'clock
                TimeSpan now = DateTime.Now.TimeOfDay;
                if ((now > start) && (now < end))
                {
                    //Check email sent for current week
                    DataSet ds = new DataSet();
                    String msg = string.Empty;
                    ObjBOL.Operation = 3;
                    msg = ObjBLL.GenerateStatus(ObjBOL);
                    //if -1 Need to Send email
                    if (msg == "-1")
                    {
                        SendEmail();
                    }
                }
            }
            SendEmail_NotFollowdup();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void SendEmail()
    {
        try
        {
            string Message = string.Empty;
            string Subject = string.Empty;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetPendingProposals(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Message += "<!DOCTYPE html><html><head><title>Aerowerks</title><style>body { background-color: white;text-align: left;color: black;font-family: Arial, Helvetica, sans-serif;}";
                Message += "</style></head><body><h2>Here is list of Pending Followups</h2>";
                // Message += "<p><b>Hey,</b></p><p><b> Project Manager has been updated, Please find the details below:</b></p>";
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Message += "<p>Proposal ID  : </strong>" + ds.Tables[0].Rows[0]["PNumber"].ToString() + "</p>";
                //Message += "<p>Project Name : </strong>" + ds.Tables[0].Rows[0]["ProjectName"].ToString() + "</p>";
                //Message += "<p>Updated PM   : </strong>" + ds.Tables[0].Rows[0]["NEWPM"].ToString() + "</p>";
                //Message += "<p>Updated By   : </strong>" + Utility.GetCurrentSession().EmployeeName + "</p>";
                //Message += "<p>Updated Time : </strong>" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "</p>";
                Message += ConvertDataTableToHTML(ds.Tables[0]);
                Message += "<p><span style='font - size:10px;'><span style='font - family:verdana,geneva,sans - serif;'><span style='color:#FF0000;'><u>" + Do_Not_Reply + "</u></span></span></span></p></body></html>";
                Send_Email(Message, "Pending Followups");
                Message = "";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// 
    /// </summary>Bilaspur, Himachal Pradesh
    private void SendEmail_NotFollowdup()
    {
        try
        {
            string Message = string.Empty;
            string Subject = string.Empty;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 6;
            ds = ObjBLL.GetPendingProposals(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Message += "<!DOCTYPE html><html><head><title>Aerowerks</title><style>body { background-color: white;text-align: left;color: black;font-family: Arial, Helvetica, sans-serif;}";
                Message += "</style></head><body><h2>List of Projects have not been followed up</h2>";
                // Message += "<p><b>Hey,</b></p><p><b> Project Manager has been updated, Please find the details below:</b></p>";
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Message += "<p>Proposal ID  : </strong>" + ds.Tables[0].Rows[0]["PNumber"].ToString() + "</p>";
                //Message += "<p>Project Name : </strong>" + ds.Tables[0].Rows[0]["ProjectName"].ToString() + "</p>";
                //Message += "<p>Updated PM   : </strong>" + ds.Tables[0].Rows[0]["NEWPM"].ToString() + "</p>";
                //Message += "<p>Updated By   : </strong>" + Utility.GetCurrentSession().EmployeeName + "</p>";
                //Message += "<p>Updated Time : </strong>" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "</p>";
                Message += ConvertDataTableToHTML(ds.Tables[0]);
                Message += "<p><span style='font - size:10px;'><span style='font - family:verdana,geneva,sans - serif;'><span style='color:#FF0000;'><u>" + Do_Not_Reply + "</u></span></span></span></p></body></html>";
                Send_Email(Message, "Projects Not Followed up");
                Message = "";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string ConvertDataTableToHTML(DataTable dt)
    {
        string html = string.Empty;
        try
        {
            html = "<style>#customers { font-family: Arial, Helvetica, sans-serif; border-collapse: collapse; width: 100%;} ";
            html += " #customers td, #customers th { border: 1px solid #ddd;padding: 8px;} ";
            html += " #customers tr:nth-child(even){background-color: #f2f2f2;} #customers tr:hover {background-color: #ddd;} ";
            html += " #customers th {  padding-top: 12px; padding-bottom: 12px; text-align: left; background-color: #0856a1; color: white;}  </style>";
            html += "<table id='customers'>";
            //add header row
            html += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<td><span style='font - weight:bold'>" + dt.Columns[i].ColumnName + "</span></td>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            html += "</table>";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return html;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Message"></param>
    /// <param name="Subject"></param>
    private void Send_Email(String Message, String Subject)
    {
        try
        {
            MailMessage message = new MailMessage();
            //message.To.Add(new MailAddress("aeroit@aero-werks.com"));
            message.To.Add(new MailAddress("aman@aero-werks.com"));
            message.To.Add(new MailAddress("sunil@aero-werks.com"));
            message.CC.Add(new MailAddress("plchan@aero-werks.com"));
            message.From = new MailAddress("aerowerksmohali@gmail.com");
            string mailbody = Message;
            //message.CC.Add(sendtoAman);
            message.Subject = Subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["Host"], 587);
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromMail"], ConfigurationManager.AppSettings["Password"]);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            client.Send(message);
            Message = string.Empty;
            string msg = "";
            ObjBOL.Operation = 5;
            msg = ObjBLL.GenerateStatus(ObjBOL);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPendingList_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Select")
            {
                GridViewRow clickedRow = gvPendingList.Rows[Convert.ToInt32(e.CommandArgument)];
                string pnumber = clickedRow.Cells[0].Text.ToString();
                Session["PNumber"] = pnumber + ", " + clickedRow.Cells[2].Text.ToString();
                string link = "window.open('/SalesManagement/FrmProposals.aspx', '_blank');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "openWindow", link, true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModal", "$('#myModal').modal('hide');", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModal", "$('.modal-backdrop').remove(); $('#myModal').modal('show');", true);
                string scrollValue = hfModalScroll.Value;

                if (string.IsNullOrEmpty(scrollValue))
                    scrollValue = "0";

                string script = string.Format(@"
                $('.modal-backdrop').remove();
                $('#myModal').modal('show');
                setTimeout(function() {{
                    $('#myModal .modal-body').scrollTop({0});
                }}, 300);", scrollValue);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModal", script, true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPendingList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string pNumber = DataBinder.Eval(e.Row.DataItem, "PNumber") as string;

                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.cursor = 'Pointer'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.ToolTip = "Click to visit proposal";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvPendingList, "Select$" + e.Row.RowIndex);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// 
    private void BindProposals(int oper)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.ProjectManagerid = Convert.ToInt32(Utility.GetCurrentSession().EmployeeID);
            ds = ObjBLL.GetPendingProposals(ObjBOL);
            if (oper == 1)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvPendingList.DataSource = ds.Tables[0];
                    gvPendingList.DataBind();
                    //opener.Visible = true;
                    btnopener.Enabled = true;
                    dvMsg.Visible = false;
                    string strMethodName = "ShowPoup();";
                    Header.InnerText = "Pending Followups List for " + Convert.ToString(Utility.GetCurrentSession().EmployeeName);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
                }
                else
                {
                    gvPendingList.DataSource = "";
                    gvPendingList.DataBind();
                    //opener.Visible = false;
                    btnopener.Enabled = false;
                    dvMsg.Visible = true;
                    lblMsg.Text = "There is not any Pending Followups";
                    openerNotFollowedup.Visible = false;
                }
            }
            else if (oper == 2)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    gvListNot.DataSource = ds.Tables[1];
                    gvListNot.DataBind();
                    //openerNotFollowedup.Visible = true;
                    btnopenerNotFollowedup.Enabled = true;
                    dvMsg.Visible = false;
                    string strMethodName = "ShowPoupNew();";
                    H1.InnerText = "Not Followedup List for " + Convert.ToString(Utility.GetCurrentSession().EmployeeName);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
                }
                else
                {
                    gvListNot.DataSource = "";
                    gvListNot.DataBind();
                    //openerNotFollowedup.Visible = false;
                    btnopenerNotFollowedup.Enabled = false;
                    dvMsg.Visible = true;
                    lblMsg.Text = "Not Followedup List is empty";
                    H1.InnerText = "";
                }
            }
            else if (oper == 3)
            {
                if (ds.Tables[2].Rows.Count > 0)
                {
                    gvShipDateUpdates.DataSource = ds.Tables[2];
                    gvShipDateUpdates.DataBind();
                    dvMsg.Visible = false;
                    string strMethodName = "ShowPoupShipDates();";
                    H2.InnerText = "Ship Date Updates History ";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
                }
                else
                {
                    gvListNot.DataSource = "";
                    gvListNot.DataBind();
                    dvMsg.Visible = true;
                    lblMsg.Text = "Not Followedup List is empty";
                    H1.InnerText = "";
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnopener_Click(object sender, EventArgs e)
    {
        BindProposals(1);
    }

    protected void btnopenerNotFollowedup_Click(object sender, EventArgs e)
    {
        BindProposals(2);
    }

    protected void btnShipDateUpdates_Click(object sender, EventArgs e)
    {
        BindProposals(3);
    }

    protected void btnTrackJobs_Click(object sender, EventArgs e)
    {
        try
        {
            BindContainerJobs();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckEngineer()
    {
        try
        {
            ObjBOL1.Operation = 16;
            ObjBOL1.ID = Utility.GetCurrentUser();
            bool returnStatus = bool.Parse(ObjBLL1.SaveAndUpdate(ObjBOL1));
            if (returnStatus)
            {
                btnEngineerTask.Visible = true;
            }
            else
            {
                btnEngineerTask.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvEngineerTask_Editing(object sender, GridViewEditEventArgs e)
    {
        int ID = Convert.ToInt32(gvEngineerTask.DataKeys[e.NewEditIndex].Value);
        string url = "~/SalesManagement/FrmEngineerTaskStatus.aspx?Id=" + ID;
        Response.Redirect(url, false);
    }

    protected void btnEngineerTask_Click(object sender, EventArgs e)
    {
        BindEngineerTask();
    }

    public void BindEngineerTask()
    {
        try
        {
            ObjBOL1.Operation = 17;
            ObjBOL1.ID = Utility.GetCurrentUser();
            DataSet ds = ObjBLL1.GetInformation(ObjBOL1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvEngineerTask.DataSource = ds.Tables[0];
                gvEngineerTask.DataBind();
            }
            else
            {
                gvEngineerTask.DataSource = string.Empty;
                gvEngineerTask.DataBind();
            }
            EngineerTaskHeader.InnerText = "Pending Task List for " + Convert.ToString(Utility.GetCurrentSession().EmployeeName);
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #region Follow Up Module
    private void AutomateEmail()
    {
        try
        {
            if (Utility.GetCurrentSession().EmployeeID == 335 || Utility.GetCurrentSession().EmployeeID == 340)
            {
                if (Utility.GetCurrentSession().EmployeeID == 335)
                {
                    CheckContainerIndia = 335;
                    CheckEmailReminder();
                    SendFollowUpEmail_Prepare();
                }
                else if (Utility.GetCurrentSession().EmployeeID == 340)
                {
                    CheckContainerChina = 340;
                    CheckEmailReminder();
                    SendFollowUpEmail_Prepare();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SendFollowUpEmail_Prepare()
    {
        try
        {
            if (Utility.InventoryEmailSwitch())
            {
                string Subject = "";
                if (CheckContainerIndia == 335)
                {
                    Subject = "Follow-up Email : India Pending Orders";
                }
                else if (CheckContainerChina == 340)
                {
                    Subject = "Follow-up Email : China Pending Orders";
                }

                string Message = string.Empty;
                Message += "<!doctype><html lang='en'><head><meta charset = 'utf-8'><meta name = 'viewport' content = 'width=device-width, initial-scale=1'> ";
                Message += " <title> Follow Up: India </title></head><body><table cellpadding='0' cellspacing='0' style='border-collapse:collapse;width:100%;font-family:Calibri;font-size:1.15rem'> ";
                Message += " <tr><td><table border='1' cellpadding='8' cellspacing='0' style='border-collapse:collapse;width:100%;max-width:580px;margin:0 auto;border-color:#ddd'> ";
                if (CheckContainerIndia == 335)
                {
                    Message += " <tr><td colspan='2'><h2 style='margin:0;font-size:1.15rem'> Hi Jeevan,</h2> ";
                }
                else if (CheckContainerChina == 340)
                {
                    Message += " <tr><td colspan='2'><h2 style='margin:0;font-size:1.15rem'> Hi Smile,</h2> ";
                }

                Message += " <p style = 'margin-top:5px'>Please find Attached Pending PO's. </p> ";
                Message += " </td ></tr><tr><td colspan='2'><div style = 'width:80px;margin:0 auto'> ";
                Message += " <svg version='1.1' xmlns:xlink='http://www.w3.org/1999/xlink' id = 'Capa_1' enable-background='new 0 0 512 512' viewBox='0 0 512 512' style='width:100%;height:100%;' xmlns='http://www.w3.org/2000/svg'><g><g><g><path d='m369.4 76.49v401.05c0 3.26-.45 6.41-1.3 9.4-4.09 14.46-17.39 25.06-33.16 25.06h-239.78c-19.03 0-34.45-15.43-34.45-34.46v-401.05c0-19.03 15.42-34.46 34.45-34.46h239.78c19.03 0 34.46 15.43 34.46 34.46z' fill = '#a1412b' /><path d = 'm132.73 394.716v60.854c0 17.33 14.04 31.37 31.37 31.37h204c.85-2.99 1.3-6.14 1.3-9.4v-82.824z' fill = '#7f392c' /><path d = 'm334.941 42.034h-239.78c-19.031 0-34.455 15.424-34.455 34.455v401.053c0 19.031 15.424 34.455 34.455 34.455h239.781c19.031 0 34.455-15.424 34.455-34.455v-401.053c-.001-19.031-15.424-34.455-34.456-34.455zm-2.143 433.365h-235.494v-396.767h235.494z' fill= '#db765a' /> ";
                Message += " <path d = 'm369.4 394.72v82.82c0 3.26-.45 6.41-1.3 9.4h-204c-9.8 0-18.56-4.49-24.31-11.54h193.01v-80.68z' fill='#b55434' /><path d = 'm95.161 42.034c-19.029 0-34.455 15.426-34.455 34.455v219.149c0 10.106 8.193 18.299 18.299 18.299 10.106 0 18.299-8.193 18.299-18.299v-217.006h41.798c10.106 0 18.299-8.193 18.299-18.299 0-10.106-8.193-18.299-18.299-18.299z' fill='#f2886b' /><path d = 'm97.304 223.144v-82.649c0-10.106-8.193-18.299-18.299-18.299-10.106 0-18.299 8.193-18.299 18.299v82.649c0 10.106 8.193 18.299 18.299 18.299 10.106 0 18.299-8.193 18.299-18.299z' fill='#f79a7c' /></g><g><path d = 'm289.014 246.714v204.031h-124.915c-17.325 0-31.37-14.045-31.37-31.37v-162.204c0-5.775 4.682-10.457 10.457-10.457z' fill='#d8d4c9' /><path d='m289.01 246.71v204.04h-124.91c-11.88 0-22.22-6.6-27.54-16.34 26.46-35.27 42.13-79.09 42.13-126.57 0-21.26-3.14-41.78-8.99-61.13z' fill='#b5b1a4' /><path d='m195.728 419.376v-408.919c0-5.775 4.682-10.457 10.457-10.457h234.652c5.775 0 10.457 4.682 10.457 10.457v408.919c0 17.325-14.045 31.37-31.37 31.37h-255.565c17.325 0 31.369-14.045 31.369-31.37z' fill='#f1eee0' /><path d='m213.1 252.167c-9.593 0-17.37-7.777-17.37-17.37v-175.393c0-9.593 7.777-17.37 17.37-17.37 9.593 0 17.37 7.777 17.37 17.37v175.392c.001 9.594-7.776 17.371-17.37 17.371z' fill='#f9f8f2' /> ";
                Message += " <path d = 'm451.29 10.46v408.92c0 17.32-14.04 31.37-31.37 31.37h-99.7c62.77-106.75 98.77-231.12 98.77-363.91 0-29.39-1.76-58.37-5.19-86.84h27.04c5.77 0 10.45 4.68 10.45 10.46z' fill='#e8e4d8' /><path d='m195.73 344.78h255.56v21.67h-255.56z' fill='#ffc751' /><path d='m327.904 344.78h-93.578c-5.984 0-10.835 4.851-10.835 10.835 0 5.984 4.851 10.835 10.835 10.835h93.578c5.984 0 10.835-4.851 10.835-10.835 0-5.984-4.851-10.835-10.835-10.835z' fill='#ffe059' /> ";
                Message += " <path d = 'm451.29 10.46v70.63h-255.56v-70.63c0-5.78 4.68-10.46 10.46-10.46h234.65c5.77 0 10.45 4.68 10.45 10.46z' fill='#ffc751' /> ";
                Message += " <path d = 'm451.29 10.46v70.63h-32.32c-.22-27.42-1.96-54.48-5.17-81.09h27.04c5.77 0 10.45 4.68 10.45 10.46z' fill='#ffaf40' /></g></g><g><g> ";
                Message += " <g fill = '#8f8b81'><path d = 'm251.009 132.32h-18.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h18.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /> ";
                Message += " <path d = 'm306.009 160.899h-73.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h73.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /></g></g><g><g> ";
                Message += " <path d = 'm421.837 139.355c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889s5.793-5.194 8.957-7.278z' fill='#ffaf40' /></g></g></g><g><g> ";
                Message += " <g fill = '#8f8b81'><path d='m251.009 208.021h-18.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h18.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /> ";
                Message += " <path d = 'm306.009 236.6h-73.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h73.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /></g></g><g><g> ";
                Message += " <path d = 'm421.837 215.056c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889 2.789-2.769 5.793-5.194 8.957-7.278z' fill='#ffaf40' /></g></g></g><g><g><g> ";
                Message += " <path d = 'm251.009 283.722h-18.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h18.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' fill='#8f8b81' /> ";
                Message += " <path d = 'm306.009 312.301h-73.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h73.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' fill='#8f8b81' /><g fill='#b5b1a4'> ";
                Message += " <path d = 'm259.14 294.383h-16.15c-4.948 0-8.959 4.011-8.959 8.959 0 4.948 4.011 8.959 8.959 8.959h16.149c4.948 0 8.959-4.011 8.959-8.959.001-4.948-4.01-8.959-8.958-8.959z' /> ";
                Message += " <path d = 'm259.14 218.682h-16.15c-4.948 0-8.959 4.011-8.959 8.959 0 4.948 4.011 8.959 8.959 8.959h16.149c4.948 0 8.959-4.011 8.959-8.959.001-4.948-4.01-8.959-8.958-8.959z' /> ";
                Message += " <path d = 'm259.14 142.981h-16.15c-4.948 0-8.959 4.011-8.959 8.959 0 4.948 4.011 8.959 8.959 8.959h16.149c4.948 0 8.959-4.011 8.959-8.959.001-4.948-4.01-8.959-8.958-8.959z' /></g> ";
                Message += " <path d = 'm351.009 418.538h-118.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h118.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' fill='#8f8b81' /> ";
                Message += " <path d = 'm281.558 409.579c0 4.948 4.011 8.959 8.959 8.959h28.472c4.948 0 8.959-4.011 8.959-8.959 0-4.948-4.011-8.959-8.959-8.959h-28.472c-4.948.001-8.959 4.012-8.959 8.959z' fill = '#b5b1a4' /></g></g><g><g> ";
                Message += " <path d = 'm421.837 290.757c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889s5.793-5.194 8.957-7.278z' fill='#229bff' /></g></g><g><g> ";
                Message += " <path d= 'm421.837 410.49c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889s5.793-5.194 8.957-7.278z' fill='#229bff' /></g></g></g> ";
                Message += " <path d = 'm375.049 58.537h-103.076c-5.523 0-10-4.477-10-10v-18.822c0-5.523 4.477-10 10-10h103.076c5.523 0 10 4.477 10 10v18.822c0 5.523-4.477 10-10 10z' fill='#f1eee0' /> ";
                Message += " <path d = 'm451.29 344.78v21.67h-88.71c3.04-7.16 5.95-14.39 8.75-21.67z' fill='#ffaf40' /> ";
                Message += " <path d = 'm230.47 59.4v21.69h-34.74v-21.69c0-9.59 7.78-17.37 17.37-17.37 4.8 0 9.14 1.95 12.28 5.09s5.09 7.48 5.09 12.28z' fill='#ffe059' /></g></svg></div> ";
                Message += " <h1 style ='font-size:1.65rem;margin:.3rem 0 0;color:#000;text-align:center'>Follow Up</h1></td></tr> ";
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'>Follow Up Date/Time </td><td style='font-weight:600;width:99%'> " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt") + "</td></tr>";
                Message += " <tr><td colspan = '2'>If you have any questions or concerns regarding your order, please contact the concerned department. <br /><br /> ";
                Message += " Thanks, <br/ > <strong> " + Utility.EmailDisplayName() + "</strong> <br /> ";
                Message += " </td></tr><tr><td colspan='2' style='color:Red'>" + Do_Not_Reply + "</td></tr></table></td></tr></table></body></html> ";

                List<MailAddress> sendToList = new List<MailAddress>();
                List<MailAddress> ccList = new List<MailAddress>();
                HashSet<MailAddress> sendToListAsList = new HashSet<MailAddress>();
                HashSet<MailAddress> ccListAsList = new HashSet<MailAddress>();
                if (CheckContainerIndia == 335)
                {
                    sendToListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "SendToList", Utility.emailDictionaryInventory, "Triflex", 1, "F", "");
                    ccListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "ccList", Utility.emailDictionaryInventory, "", 2, "F", "");
                }
                else if (CheckContainerChina == 340)
                {
                    sendToListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "SendToList", Utility.emailDictionaryInventory, "Office", 1, "F", "");
                    ccListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "ccList", Utility.emailDictionaryInventory, "", 2, "F", "");
                }
                sendToList = sendToListAsList.ToList();
                ccList = ccListAsList.ToList();
                Send_EmailFollowUp(Message, Subject, sendToList, ccList);
                sendToListAsList.Clear();
                ccListAsList.Clear();
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void Send_EmailFollowUp(String Message, String Subject, List<MailAddress> sendToList, List<MailAddress> ccList)
    {
        try
        {
            if (sendToList.Count > 0)
            {
                MailMessage message = new MailMessage(new MailAddress(Utility.Email(), Utility.EmailDisplayName()), sendToList[0]);
                string filename = string.Empty;
                if (CheckContainerIndia == 335)
                {
                    filename = "India Pending Orders" + ".pdf";
                }
                else if (CheckContainerChina == 340)
                {
                    filename = "China Pending Orders" + ".pdf";
                }
                string mailbody = Message;
                message.Subject = Subject;
                message.Body = mailbody;
                ReportDataFollowUp();
                if (HfCheckOpenParts.Value != "-1")
                {
                    Attachment file = new Attachment(GetPOReportStream(), filename, "application/pdf");
                    message.Attachments.Add(file);
                    foreach (var sendto in sendToList)
                    {
                        if (!message.To.Contains(sendto))
                        {
                            message.To.Add(sendto);
                        }
                    }
                    foreach (var cc in ccList)
                    {
                        if (!message.CC.Contains(cc))
                        {
                            message.CC.Add(cc);
                        }

                    }
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
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Stream GetPOReportStream()
    {
        Stream reportStream = null;
        try
        {
            if (PrepareReportFollowUp() == true)
            {
                reportStream = (Stream)rprt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            if (rprt != null)
            {
                rprt.Close();
                rprt.Dispose();
            }
        }
        return reportStream;
    }

    private bool PrepareReportFollowUp()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["dtOpenParts"];
            if (dt.Rows.Count > 0)
            {
                rprt.Load(Server.MapPath("~/Reports/rptOpenPartsFollowUp.rpt"));
                if (dt.Rows.Count > 0)
                {
                    rprt.SetDataSource(dt);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private DataTable ReportDataFollowUp()
    {
        DataTable dt = new DataTable();
        try
        {
            if (CheckContainerIndia == 335)
            {
                if (HfReminderCheck.Value == "1")
                {
                    dt = BindReminderDatatble();
                }
                else
                {
                    HfReminderCheck.Value = "-1";
                    //clscon.Return_DT(dt, "EXEC [dbo].[Get_FollowUpIndia] ");
                }
                if (dt.Rows.Count > 0)
                {
                    HfCheckOpenParts.Value = "1";
                    ViewState["dtOpenParts"] = dt;
                }
                else
                {
                    HfCheckOpenParts.Value = "-1";
                    ViewState["dtOpenParts"] = null;
                }
            }
            else if (CheckContainerChina == 340)
            {
                if (HfReminderCheck.Value == "1")
                {
                    dt = BindReminderDatatble();
                }
                else
                {
                    HfReminderCheck.Value = "-1";
                    //clscon.Return_DT(dt, "EXEC [dbo].[Get_FollowUpChina] ");
                }
                if (dt.Rows.Count > 0)
                {
                    HfCheckOpenParts.Value = "1";
                    ViewState["dtOpenParts"] = dt;
                }
                else
                {
                    HfCheckOpenParts.Value = "-1";
                    ViewState["dtOpenParts"] = null;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }
    #endregion

    #region CheckEmailReminder
    private void CheckEmailReminder()
    {
        try
        {
            string msg = "";
            if (CheckContainerIndia == 335)
            {
                ObjBOL.Operation = 1;
                msg = ObjBLL.CheckEmailReminder(ObjBOL);
                if (msg == "1")
                {
                    HfReminderCheck.Value = msg;
                }
            }
            if (CheckContainerChina == 340)
            {
                ObjBOL.Operation = 2;
                msg = ObjBLL.CheckEmailReminder(ObjBOL);
                if (msg == "1")
                {
                    HfReminderCheck.Value = msg;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable BindReminderDatatble()
    {

        DataTable dt = new DataTable();
        try
        {
            DataSet ds = new DataSet();
            if (CheckContainerIndia == 335)
            {
                ObjBOL.Operation = 3;
            }
            else if (CheckContainerChina == 340)
            {
                ObjBOL.Operation = 4;
            }
            ds = ObjBLL.ReturnDatatable(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }
    #endregion

    #region Forecasting Automate Email Content Monthly Basis ON Date 1

    private void CheckForecatingUserPermission()
    {
        try
        {
            string msg = "";
            ObjBOLForecating.Operation = 2;
            ObjBOLForecating.EmployeeID = Utility.GetCurrentSession().EmployeeID;
            msg = ObjBLLForecasting.Return_String(ObjBOLForecating);
            if (msg.Trim() == "2")
            {
                ForecastingdepartmentID = msg.Trim();
                AutomateEmailOnceForDepartment();
            }
            else
            {
                ForecastingdepartmentID = null;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    private DataTable BindGrid()
    {
        DataTable dt = new DataTable();
        try
        {
            DataSet ds = new DataSet();
            ObjBOLForecating.Operation = 3;
            ds = ObjBLLForecasting.Return_DataSet(ObjBOLForecating);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
                ForecastingReportDate = ds.Tables[1].Rows[0]["ForecastingDate"].ToString();
                if (dt.Rows.Count > 0)
                {
                    var columnNames = dt.Columns.Cast<DataColumn>()
                                       .Take(11) // Take the first 9 columns after excluding the 4th
                                       .Select(c => c.ColumnName)
                                       .ToArray();
                    DataTable newDt = dt.DefaultView.ToTable(false, columnNames);
                    gvSearch.AllowPaging = false;
                    gvSearch.DataSource = newDt;
                    gvSearch.DataBind();
                    gvSearch.HeaderRow.BackColor = Color.White;

                    // Set header row background color
                    foreach (TableCell cell in gvSearch.HeaderRow.Cells)
                    {
                        cell.BackColor = gvSearch.HeaderStyle.BackColor;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private string GenerateEmailBody()
    {
        string Message = string.Empty;
        try
        {

            Message += "<!doctype><html lang='en'><head><meta charset = 'utf-8'><meta name = 'viewport' content = 'width=device-width, initial-scale=1'> ";
            Message += " <title> Forecasting Summary Report </title></head><body><table cellpadding='0' cellspacing='0' style='border-collapse:collapse;width:100%;font-family:Calibri;font-size:1.15rem'> ";
            Message += " <tr><td><table border='1' cellpadding='8' cellspacing='0' style='border-collapse:collapse;width:100%;max-width:580px;margin:0 auto;border-color:#ddd'> ";
            Message += " <tr><td colspan='2'><h2 style='margin:0;font-size:1.15rem'> Hi " + Utility.GetCurrentSession().EmployeeName + ",</h2> ";

            Message += " <p style = 'margin-top:5px'>Please find Attached Forecasting Summary Report <strong>" + ForecastingReportDate + "</strong>. </p> ";
            Message += " </td ></tr><tr><td colspan = '2'><div style = 'width:80px;margin:0 auto'> ";
            Message += " <svg version='1.1' xmlns:xlink='http://www.w3.org/1999/xlink' id = 'Capa_1' enable-background='new 0 0 512 512' viewBox='0 0 512 512' style='width:100%;height:100%;' xmlns='http://www.w3.org/2000/svg'><g><g><g><path d='m369.4 76.49v401.05c0 3.26-.45 6.41-1.3 9.4-4.09 14.46-17.39 25.06-33.16 25.06h-239.78c-19.03 0-34.45-15.43-34.45-34.46v-401.05c0-19.03 15.42-34.46 34.45-34.46h239.78c19.03 0 34.46 15.43 34.46 34.46z' fill = '#a1412b' /><path d = 'm132.73 394.716v60.854c0 17.33 14.04 31.37 31.37 31.37h204c.85-2.99 1.3-6.14 1.3-9.4v-82.824z' fill = '#7f392c' /><path d = 'm334.941 42.034h-239.78c-19.031 0-34.455 15.424-34.455 34.455v401.053c0 19.031 15.424 34.455 34.455 34.455h239.781c19.031 0 34.455-15.424 34.455-34.455v-401.053c-.001-19.031-15.424-34.455-34.456-34.455zm-2.143 433.365h-235.494v-396.767h235.494z' fill= '#db765a' /> ";
            Message += " <path d = 'm369.4 394.72v82.82c0 3.26-.45 6.41-1.3 9.4h-204c-9.8 0-18.56-4.49-24.31-11.54h193.01v-80.68z' fill='#b55434' /><path d = 'm95.161 42.034c-19.029 0-34.455 15.426-34.455 34.455v219.149c0 10.106 8.193 18.299 18.299 18.299 10.106 0 18.299-8.193 18.299-18.299v-217.006h41.798c10.106 0 18.299-8.193 18.299-18.299 0-10.106-8.193-18.299-18.299-18.299z' fill='#f2886b' /><path d = 'm97.304 223.144v-82.649c0-10.106-8.193-18.299-18.299-18.299-10.106 0-18.299 8.193-18.299 18.299v82.649c0 10.106 8.193 18.299 18.299 18.299 10.106 0 18.299-8.193 18.299-18.299z' fill='#f79a7c' /></g><g><path d = 'm289.014 246.714v204.031h-124.915c-17.325 0-31.37-14.045-31.37-31.37v-162.204c0-5.775 4.682-10.457 10.457-10.457z' fill='#d8d4c9' /><path d='m289.01 246.71v204.04h-124.91c-11.88 0-22.22-6.6-27.54-16.34 26.46-35.27 42.13-79.09 42.13-126.57 0-21.26-3.14-41.78-8.99-61.13z' fill='#b5b1a4' /><path d='m195.728 419.376v-408.919c0-5.775 4.682-10.457 10.457-10.457h234.652c5.775 0 10.457 4.682 10.457 10.457v408.919c0 17.325-14.045 31.37-31.37 31.37h-255.565c17.325 0 31.369-14.045 31.369-31.37z' fill='#f1eee0' /><path d='m213.1 252.167c-9.593 0-17.37-7.777-17.37-17.37v-175.393c0-9.593 7.777-17.37 17.37-17.37 9.593 0 17.37 7.777 17.37 17.37v175.392c.001 9.594-7.776 17.371-17.37 17.371z' fill='#f9f8f2' /> ";
            Message += " <path d = 'm451.29 10.46v408.92c0 17.32-14.04 31.37-31.37 31.37h-99.7c62.77-106.75 98.77-231.12 98.77-363.91 0-29.39-1.76-58.37-5.19-86.84h27.04c5.77 0 10.45 4.68 10.45 10.46z' fill='#e8e4d8' /><path d='m195.73 344.78h255.56v21.67h-255.56z' fill='#ffc751' /><path d='m327.904 344.78h-93.578c-5.984 0-10.835 4.851-10.835 10.835 0 5.984 4.851 10.835 10.835 10.835h93.578c5.984 0 10.835-4.851 10.835-10.835 0-5.984-4.851-10.835-10.835-10.835z' fill='#ffe059' /> ";
            Message += " <path d = 'm451.29 10.46v70.63h-255.56v-70.63c0-5.78 4.68-10.46 10.46-10.46h234.65c5.77 0 10.45 4.68 10.45 10.46z' fill='#ffc751' /> ";
            Message += " <path d = 'm451.29 10.46v70.63h-32.32c-.22-27.42-1.96-54.48-5.17-81.09h27.04c5.77 0 10.45 4.68 10.45 10.46z' fill='#ffaf40' /></g></g><g><g> ";
            Message += " <g fill = '#8f8b81'><path d = 'm251.009 132.32h-18.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h18.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /> ";
            Message += " <path d = 'm306.009 160.899h-73.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h73.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /></g></g><g><g> ";
            Message += " <path d = 'm421.837 139.355c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889s5.793-5.194 8.957-7.278z' fill='#ffaf40' /></g></g></g><g><g> ";
            Message += " <g fill = '#8f8b81'><path d='m251.009 208.021h-18.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h18.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /> ";
            Message += " <path d = 'm306.009 236.6h-73.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h73.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /></g></g><g><g> ";
            Message += " <path d = 'm421.837 215.056c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889 2.789-2.769 5.793-5.194 8.957-7.278z' fill='#ffaf40' /></g></g></g><g><g><g> ";
            Message += " <path d = 'm251.009 283.722h-18.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h18.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' fill='#8f8b81' /> ";
            Message += " <path d = 'm306.009 312.301h-73.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h73.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' fill='#8f8b81' /><g fill='#b5b1a4'> ";
            Message += " <path d = 'm259.14 294.383h-16.15c-4.948 0-8.959 4.011-8.959 8.959 0 4.948 4.011 8.959 8.959 8.959h16.149c4.948 0 8.959-4.011 8.959-8.959.001-4.948-4.01-8.959-8.958-8.959z' /> ";
            Message += " <path d = 'm259.14 218.682h-16.15c-4.948 0-8.959 4.011-8.959 8.959 0 4.948 4.011 8.959 8.959 8.959h16.149c4.948 0 8.959-4.011 8.959-8.959.001-4.948-4.01-8.959-8.958-8.959z' /> ";
            Message += " <path d = 'm259.14 142.981h-16.15c-4.948 0-8.959 4.011-8.959 8.959 0 4.948 4.011 8.959 8.959 8.959h16.149c4.948 0 8.959-4.011 8.959-8.959.001-4.948-4.01-8.959-8.958-8.959z' /></g> ";
            Message += " <path d = 'm351.009 418.538h-118.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h118.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' fill='#8f8b81' /> ";
            Message += " <path d = 'm281.558 409.579c0 4.948 4.011 8.959 8.959 8.959h28.472c4.948 0 8.959-4.011 8.959-8.959 0-4.948-4.011-8.959-8.959-8.959h-28.472c-4.948.001-8.959 4.012-8.959 8.959z' fill = '#b5b1a4' /></g></g><g><g> ";
            Message += " <path d = 'm421.837 290.757c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889s5.793-5.194 8.957-7.278z' fill='#229bff' /></g></g><g><g> ";
            Message += " <path d= 'm421.837 410.49c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889s5.793-5.194 8.957-7.278z' fill='#229bff' /></g></g></g> ";
            Message += " <path d = 'm375.049 58.537h-103.076c-5.523 0-10-4.477-10-10v-18.822c0-5.523 4.477-10 10-10h103.076c5.523 0 10 4.477 10 10v18.822c0 5.523-4.477 10-10 10z' fill='#f1eee0' /> ";
            Message += " <path d = 'm451.29 344.78v21.67h-88.71c3.04-7.16 5.95-14.39 8.75-21.67z' fill='#ffaf40' /> ";
            Message += " <path d = 'm230.47 59.4v21.69h-34.74v-21.69c0-9.59 7.78-17.37 17.37-17.37 4.8 0 9.14 1.95 12.28 5.09s5.09 7.48 5.09 12.28z' fill='#ffe059' /></g></svg></div> ";
            Message += " If you have any questions or concerns regarding this, please contact the concerned department. <br /><br /> ";
            Message += " Thanks, <br/ > <strong> " + Utility.EmailDisplayName() + " </strong> <br /> ";
            Message += " </td></tr><tr><td colspan='2' style='color:Red'>" + Do_Not_Reply + "</td></tr></table></td></tr></table></body></html> ";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return Message;
    }

    protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].CssClass = "column-width-500";
                // Apply border style to header row
                foreach (TableCell cell in e.Row.Cells)
                {
                    cell.Style["font-weight"] = "bold";
                    cell.Style["border"] = "1px solid black"; // Set header border thickness and color
                    cell.Font.Size = 14;
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Align text to the right for specific columns, with index check
                int[] columnsToAlign = { 3, 4, 5, 6, 7, 8, 9, 10, 11 };
                foreach (int index in columnsToAlign)
                {
                    if (index < e.Row.Cells.Count) // Check if the index is within the valid range
                    {
                        e.Row.Cells[index].HorizontalAlign = HorizontalAlign.Right;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public bool CanCallFunction()
    {
        try
        {
            if (userLastCall.ContainsKey(ForecastingdepartmentID))
            {
                DateTime lastCall = userLastCall[ForecastingdepartmentID];
                if (lastCall.Date == DateTime.Today)
                {
                    return false; // Function already called today
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        userLastCall[ForecastingdepartmentID] = DateTime.Now;
        return true; // Function can be called
    }

    public void AutomateEmailOnceForDepartment()
    {
        try
        {
            if (CanCallFunction())
            {
                AutoMateForecastingEmail();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private MemoryStream GeneratePdfFromHtml(float width, float height, GridView gvSearch)
    {
        MemoryStream pdfStream = new MemoryStream();
        Document pdfDocument = null;
        PdfWriter writer = null;

        try
        {
            // Create a PDF document
            iTextSharp.text.Rectangle PageSize = new iTextSharp.text.Rectangle(width, height);
            pdfDocument = new Document(PageSize, 10, 10f, 10f, 10f);
            writer = PdfWriter.GetInstance(pdfDocument, pdfStream);
            writer.CloseStream = false;
            pdfDocument.Open();

            // Add text before the table
            iTextSharp.text.Font textFont = FontFactory.GetFont("Arial", 26, iTextSharp.text.Font.BOLD);
            string PdfHeaderText = "Forecating Summary Report " + ForecastingReportDate;
            Paragraph preTableText = new Paragraph(PdfHeaderText, textFont)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 10f // Add some space after the paragraph                
            };
            pdfDocument.Add(preTableText);


            // Create a PdfPTable and set the widths of columns            
            int numColumns = gvSearch.HeaderRow.Cells.Count;
            PdfPTable table = new PdfPTable(numColumns);
            table.WidthPercentage = 100; // Set table width to 100% of the page width

            // Set column widths (example widths)
            float[] columnWidths = new float[] { 1f, 1f, 3f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f };
            table.SetWidths(columnWidths);

            // Render the GridView header
            gvSearch.HeaderRow.TableSection = TableRowSection.TableHeader;
            iTextSharp.text.Font headerFont = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD);
            foreach (TableCell headerCell in gvSearch.HeaderRow.Cells)
            {
                string headerCellText = CleanHtml(headerCell.Text);
                Phrase phrase = new Phrase(headerCellText, headerFont);
                PdfPCell pdfCell = new PdfPCell(phrase)
                {
                    BackgroundColor = BaseColor.WHITE,
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    Padding = 5,
                    BorderWidth = 2,
                    BorderColor = BaseColor.BLACK,
                    FixedHeight = 40f

                };
                table.AddCell(pdfCell);
            }

            // Render the GridView rows
            iTextSharp.text.Font dataFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL);
            foreach (GridViewRow gridViewRow in gvSearch.Rows)
            {
                for (int i = 0; i < gridViewRow.Cells.Count; i++)
                {
                    TableCell gridViewCell = gridViewRow.Cells[i];
                    string cellText = CleanHtml(gridViewCell.Text);
                    PdfPCell pdfCell = new PdfPCell(new Phrase(cellText, dataFont))
                    {
                        HorizontalAlignment = (i >= 3) ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT,
                        Padding = 5,
                        BorderWidth = 1,
                        BorderColor = BaseColor.BLACK,
                        FixedHeight = 30f
                    };
                    table.AddCell(pdfCell);
                }
            }


            // Add the table to the document
            pdfDocument.Add(table);
            pdfDocument.Close();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return pdfStream;
    }

    private Forecasting_Email PrepareDataSet()
    {
        Forecasting_Email ds = new Forecasting_Email();
        try
        {
            List<TextObject> textObjects = rprt.ReportDefinition.Sections["Section2"].ReportObjects.OfType<TextObject>().ToList();
            DataTable dt = new DataTable();
            ObjBOLForecating.Operation = 3;
            dt = ObjBLLForecasting.Return_DataSet(ObjBOLForecating).Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < textObjects.Count; i++)
                {
                    textObjects[i].Text = string.Empty;
                    if (dt.Columns.Count > i && i < dt.Columns.Count)
                    {
                        textObjects[i].Text = dt.Columns[i].ToString();
                    }
                }

                for (var it = 0; it < dt.Rows.Count; it++)
                {
                    DataRow dr = ds.DynamicColumn.Rows.Add();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dr[i] = dt.Rows[it][i].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return ds;
    }

    private void TestForecastingReport()
    {
        try
        {
            rprt.Load(Server.MapPath("~/Reports/rptForecasting_Email.rpt"));
            Forecasting_Email dataSet = PrepareDataSet();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Forecasting - " + DateTime.Now.ToString("dddd, dd MMMM yyyy").Replace(',', ' ');

                rprt.SetDataSource(dataSet);
                rprt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Forecasting_Test");
                rprt.Close();
                rprt.Dispose();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Stream ForecastingEmail_CrystalReport()
    {
        Stream pdfStream = null;
        try
        {
            rprt.Load(Server.MapPath("~/Reports/rptForecasting_Email.rpt"));

            Forecasting_Email dataSet = PrepareDataSet();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Forecasting - " + DateTime.Now.ToString("dddd, dd MMMM yyyy").Replace(',', ' ');

                rprt.SetDataSource(dataSet);

                ExportOptions exportOptions = rprt.ExportOptions;
                PdfFormatOptions pdfFormatOptions = new PdfFormatOptions();
                exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                exportOptions.FormatOptions = pdfFormatOptions;

                pdfStream = (Stream)rprt.ExportToStream(ExportFormatType.PortableDocFormat);
                pdfStream.Position = 0;
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

        return pdfStream;
    }

    private void AutoMateForecastingEmail()
    {
        try
        {
            if (Utility.InventoryEmailSwitch())
            {
                DataTable dt = (DataTable)BindGrid();
                string Subject = "Forecasting Summary Report";
                List<MailAddress> sendToList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "SendToList", Utility.emailDictionaryInventory, "", 3, "O", "").ToList();
                List<MailAddress> ccList = new List<MailAddress>();

                using (MailMessage message = new MailMessage(new MailAddress(Utility.Email(), Utility.EmailDisplayName()), sendToList[0]))
                {
                    if (sendToList.Count > 0)
                    {
                        string mailbody = GenerateEmailBody();
                        message.Subject = Subject;
                        message.Body = mailbody;
                        message.BodyEncoding = Encoding.UTF8;
                        message.IsBodyHtml = true;

                        if (dt.Rows.Count > 0)
                        {
                            foreach (var sendto in sendToList)
                            {
                                if (!message.To.Contains(sendto))
                                {
                                    message.To.Add(sendto);
                                }
                            }

                            foreach (var cc in ccList)
                            {
                                if (!message.CC.Contains(cc))
                                {
                                    message.CC.Add(cc);
                                }
                            }

                            Stream pdfStream = ForecastingEmail_CrystalReport();
                            if (pdfStream != null)
                            {
                                pdfStream.Position = 0;

                                Attachment attachment = new Attachment(pdfStream, "Forecasting_Summary_Report.pdf", MediaTypeNames.Application.Pdf);
                                message.Attachments.Add(attachment);

                                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["Host"], 587)
                                {
                                    EnableSsl = true,
                                    UseDefaultCredentials = false,
                                    Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FromMail"], ConfigurationManager.AppSettings["Password"])
                                };

                                client.Send(message);
                                pdfStream.Dispose();
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private string CleanHtml(string htmlContent)
    {
        // Replace unnecessary text
        htmlContent = htmlContent.Replace("&quot;", " ");
        htmlContent = htmlContent.Replace("&nbsp;", " ");
        // Add more replacements as needed
        // htmlContent = htmlContent.Replace("&amp;", "&");
        // htmlContent = htmlContent.Replace("&lt;", "<");
        // htmlContent = htmlContent.Replace("&gt;", ">");   
        return htmlContent;

    }
    #endregion

    public class YTDQuotesMonthly
    {
        String _QuoteMonth;
        public String QuoteMonth
        {
            get { return _QuoteMonth; }
            set { _QuoteMonth = value; }
        }
        Decimal _MonthlyTotal;
        public Decimal MonthlyTotal
        {
            get { return _MonthlyTotal; }
            set { _MonthlyTotal = value; }
        }
        Int32 _MonthlyQuoteCount;
        public Int32 MonthlyQuoteCount
        {
            get { return _MonthlyQuoteCount; }
            set { _MonthlyQuoteCount = value; }
        }
    }

    public class MonthlySales
    {
        String _Region;
        public String Region
        {
            get { return _Region; }
            set { _Region = value; }
        }
        Decimal _NetAmount;
        public Decimal NetAmount
        {
            get { return _NetAmount; }
            set { _NetAmount = value; }
        }
    }

    public class ShippedProjects
    {
        String _MonthName;
        public String MonthName
        {
            get { return _MonthName; }
            set { _MonthName = value; }
        }

        Decimal _USNetAmount;
        public Decimal USNetAmount
        {
            get { return _USNetAmount; }
            set { _USNetAmount = value; }
        }

        Decimal _CADNetAmount;
        public Decimal CADNetAmount
        {
            get { return _CADNetAmount; }
            set { _CADNetAmount = value; }
        }

        Int32 _USProjectCount;
        public Int32 USProjectCount
        {
            get { return _USProjectCount; }
            set { _USProjectCount = value; }
        }

        Int32 _CADProjectCount;
        public Int32 CADProjectCount
        {
            get { return _CADProjectCount; }
            set { _CADProjectCount = value; }
        }
    }

    public class YTDOrdersMonthlyTotal
    {
        String _OrdersMonth;
        public String OrdersMonth
        {
            get { return _OrdersMonth; }
            set { _OrdersMonth = value; }
        }
        Int32 _CanadaOrderCount;
        public Int32 CanadaOrderCount
        {
            get { return _CanadaOrderCount; }
            set { _CanadaOrderCount = value; }
        }
        Decimal _TotalCanadaPORec;
        public Decimal TotalCanadaPORec
        {
            get { return _TotalCanadaPORec; }
            set { _TotalCanadaPORec = value; }
        }
        Int32 _USOrderCount;
        public Int32 USOrderCount
        {
            get { return _USOrderCount; }
            set { _USOrderCount = value; }
        }
        Decimal _TotalUSPORec;
        public Decimal TotalUSPORec
        {
            get { return _TotalUSPORec; }
            set { _TotalUSPORec = value; }
        }
    }

    public class YTDOrdersGrandTotal
    {
        Int32 _OrdersCount;
        public Int32 OrdersCount
        {
            get { return _OrdersCount; }
            set { _OrdersCount = value; }
        }
        Decimal _OrdersGrandTotal;
        public Decimal OrdersGrandTotal
        {
            get { return _OrdersGrandTotal; }
            set { _OrdersGrandTotal = value; }
        }

    }

    public class ProjectedVsActual
    {
        String _Month;
        public String Month
        {
            get { return _Month; }
            set { _Month = value; }
        }

        Decimal _ProjectedSales;
        public Decimal ProjectedSales
        {
            get { return _ProjectedSales; }
            set { _ProjectedSales = value; }
        }

        Decimal _ActualSales;
        public Decimal ActualSales
        {
            get { return _ActualSales; }
            set { _ActualSales = value; }
        }
    }

    public void Bind_GridMonthlyQuotes()
    {
        try
        {
            int Operation = 3;
            DataSet ds = Utility.GeYTDQuotesData(Operation); // Your data source
            DataTable dtQuotes = ds.Tables[0];
            DataTable dtFinal = dtQuotes.AsEnumerable()
           .Where(row => !row.IsNull("MonthlyTotal"))
           .CopyToDataTable();
            if (dtFinal.Rows.Count > 0)
            {
                gvQuotesMonthly.DataSource = dtFinal;
                gvQuotesMonthly.DataBind();
            }
            else
            {
                gvQuotesMonthly.DataSource = "";
                gvQuotesMonthly.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public void Bind_GridMonthlyOrders()
    {
        try
        {
            int Operation = 4;
            int totalNoofOrders = 0;
            decimal totalValueofOrders = 0;
            DataSet ds = Utility.GeYTDQuotesData(Operation); // Your data source
            DataTable dtOrders = ds.Tables[0];
            DataTable dtFinal = dtOrders.AsEnumerable()
           .Where(row => !row.IsNull("TotalUSPORec"))
           .CopyToDataTable();
            if (dtFinal.Rows.Count > 0)
            {
                // Find the row where OrdersMonth column has the text "Grand Total"
                DataRow grandTotalRow = dtFinal.AsEnumerable()
                    .FirstOrDefault(r => r.Field<string>("OrdersMonth") == "Grand Total");
                if (grandTotalRow != null)
                {
                    // Example: Read values from other columns in that row
                    decimal totalUS = grandTotalRow.Field<decimal>("TotalUSPORec");
                    decimal totalCanada = grandTotalRow.Field<decimal>("TotalCanadaPORec");
                    int totalUSCount = grandTotalRow.Field<int>("USOrderCount");
                    int totalCanadaCount = grandTotalRow.Field<int>("CanadaOrderCount");
                    totalNoofOrders = totalUSCount + totalCanadaCount;
                    totalValueofOrders = totalUS + totalCanada;
                }
                if (totalNoofOrders > 0)
                {
                    dvOrdersBooked.Visible = true;
                    lblNoofOrdersBooked.Text = totalNoofOrders.ToString();
                }
                else
                {
                    dvOrdersBooked.Visible = false;
                }
                if (totalValueofOrders > 0)
                {
                    dvTotal.Visible = true;
                    lblValueofOrders.Text = totalValueofOrders.ToString("C2");
                }
                else
                {
                    dvTotal.Visible = false;
                }
                gvOrders.DataSource = dtFinal;
                gvOrders.DataBind();
            }
            else
            {
                gvOrders.DataSource = "";
                gvOrders.DataBind();
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindQuotesandOrders()
    {
        try
        {
            //Bind_GridMonthlyQuotes();
            //Bind_GridMonthlyOrders();
            Bind_GridMonthlyQuotesandOrders();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    [WebMethod]
    public static List<ProjectedVsActual> GetProjectsSalesVsActualSales()
    {
        List<ProjectedVsActual> projectVsActual = new List<ProjectedVsActual>();

        try
        {
            DataSet ds = Utility.GeYTDQuotesData(7); // Your data source
            DataTable dt = ds.Tables[0];
            DataTable dtFinal = dt.AsEnumerable()          
           .CopyToDataTable();
            foreach (DataRow row in dtFinal.Rows)
            {
                if (row["Month"].ToString() == "Grand Total")
                    continue;
                projectVsActual.Add(new ProjectedVsActual
                {
                    Month = row["Month"].ToString(),
                    ProjectedSales = Convert.ToDecimal(row["ProjectedSales"].ToString()),
                    ActualSales = Convert.ToDecimal(row["ActualSales"].ToString())
                });
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

        return projectVsActual;
    }


    [WebMethod]
    public static List<YTDQuotesMonthly> GetYTDQuotesMonthly()
    {
        List<YTDQuotesMonthly> YTDQuotesMonthlyList = new List<YTDQuotesMonthly>();

        try
        {
            int Operation = 3;
            DataSet ds = Utility.GeYTDQuotesData(Operation); // Your data source
            DataTable dt = ds.Tables[0];
            DataTable dtFinal = dt.AsEnumerable()
           .Where(row => !row.IsNull("MonthlyTotal"))
           .CopyToDataTable();
            foreach (DataRow row in dtFinal.Rows)
            {
                if (row["QuoteMonth"].ToString() == "Grand Total")
                    continue;
                YTDQuotesMonthlyList.Add(new YTDQuotesMonthly
                {
                    QuoteMonth = row["QuoteMonth"].ToString(),
                    MonthlyTotal = Convert.ToDecimal(row["MonthlyTotal"]),
                    MonthlyQuoteCount = Convert.ToInt32(row["MonthlyQuoteCount"])
                });
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

        return YTDQuotesMonthlyList;
    }

    [WebMethod]
    public static List<MonthlySales> GetMonthlySales()
    {
        List<MonthlySales> MonthlySales = new List<MonthlySales>();

        try
        {
            DataSet ds = Utility.GetDashboardData(5); // Your data source
            DataTable dt = ds.Tables[0];
            DataTable dtFinal = dt.AsEnumerable()
           .Where(row => !row.IsNull("NetAmount"))
           .CopyToDataTable();
            foreach (DataRow row in dtFinal.Rows)
            {
                if (row["Region"].ToString() == "Grand Total")
                    continue;
                MonthlySales.Add(new MonthlySales
                {
                    Region = row["Region"].ToString(),
                    NetAmount = Convert.ToDecimal(row["NetAmount"]),
                });
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

        return MonthlySales;
    }

    [WebMethod]
    public static List<ShippedProjects> GetMonthlWiseProjectAndAmount()
    {
        List<ShippedProjects> MonthlySales = new List<ShippedProjects>();
        Dictionary<string, ShippedProjects> monthMap = new Dictionary<string, ShippedProjects>();
        try
        {
            DataSet ds = Utility.GetDashboardData(6); // Your data source
            DataTable dt = ds.Tables[0];
            DataTable dtFinal = dt.AsEnumerable()
           .Where(row => !row.IsNull("AmountForMonth"))
           .CopyToDataTable();

            foreach (DataRow row in dtFinal.Rows)
            {
                string month = row["MonthName"].ToString();
                string currency = row["Currency"].ToString();
                decimal amount = Convert.ToDecimal(row["AmountForMonth"]);
                int projectCount = Convert.ToInt32(row["ProjectsForMonth"]);

                if (!monthMap.ContainsKey(month))
                {
                    monthMap[month] = new ShippedProjects
                    {
                        MonthName = month
                    };
                }

                var shipped = monthMap[month];

                if (currency == "US")
                {
                    shipped.USNetAmount = amount;
                    shipped.USProjectCount = projectCount;
                }
                else if (currency == "Canadian")
                {
                    shipped.CADNetAmount = amount;
                    shipped.CADProjectCount = projectCount;
                }
            }
            MonthlySales = monthMap.Values.ToList();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

        return MonthlySales;
    }

    [WebMethod]
    public static List<YTDOrdersMonthlyTotal> GetYTDOrdersMonthlyTotal()
    {
        List<YTDOrdersMonthlyTotal> YTDOrdersMonthlyTotalList = new List<YTDOrdersMonthlyTotal>();

        try
        {
            int Operation = 4;
            DataSet ds = Utility.GeYTDQuotesData(Operation); // Your data source
            DataTable dt = ds.Tables[0];
            DataTable dtFinal = dt.AsEnumerable()
           .Where(row => !row.IsNull("TotalUSPORec"))
           .CopyToDataTable();
            foreach (DataRow row in dtFinal.Rows)
            {
                if (row["OrdersMonth"].ToString() == "Grand Total")
                    continue;
                YTDOrdersMonthlyTotalList.Add(new YTDOrdersMonthlyTotal
                {
                    OrdersMonth = row["OrdersMonth"].ToString(),
                    CanadaOrderCount = Convert.ToInt32(row["CanadaOrderCount"].ToString()),
                    TotalCanadaPORec = Convert.ToDecimal(row["TotalCanadaPORec"].ToString()),
                    USOrderCount = Convert.ToInt32(row["USOrderCount"].ToString()),
                    TotalUSPORec = Convert.ToDecimal(row["TotalUSPORec"].ToString()),
                });
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

        return YTDOrdersMonthlyTotalList;
    }

    protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblMonthOrders = (Label)e.Row.FindControl("lblMonthOrders");
                if (lblMonthOrders != null && lblMonthOrders.Text == "Grand Total")
                {
                    // Loop through all cells in the row and apply styling
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        cell.Font.Bold = true;
                        //cell.BackColor = System.Drawing.Color.LightYellow; // Optional styling
                        cell.ForeColor = System.Drawing.Color.DarkBlue;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvQuotesMonthly_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblMonthOrders = (Label)e.Row.FindControl("lblMonth");
                if (lblMonthOrders != null && lblMonthOrders.Text == "Grand Total")
                {
                    // Loop through all cells in the row and apply styling
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        cell.Font.Bold = true;
                        //cell.BackColor = System.Drawing.Color.LightYellow; // Optional styling
                        cell.ForeColor = System.Drawing.Color.DarkBlue;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }    

    private void GetDasboardData()
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                int userId = Utility.GetCurrentUser();
                DataTable dt = new DataTable();
                clscon.Return_DT(dt, "EXEC Get_DashboardReports 8, " + userId);
                if (dt.Rows.Count > 0)
                {
                    divDashboard.Visible = true;
                    DataSet ds = Utility.GetDashboardData(1);
                    #region Not in use
                    StringBuilder allScripts = new StringBuilder();
                    BindReportDropdowns(ds.Tables[1], ds.Tables[2]);
                    ViewState["GuageChart"] = ds.Tables[0];
                    string litScriptGauge = FirstBlock(ds.Tables[0]);
                    allScripts.Append(litScriptGauge);
                    FirstBlock_V1();
                    //ForthBlock();
                    //FifthBlock();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "DrawGoogleCharts", allScripts.ToString(), false);
                    #endregion
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        gvSalesMonthWiseSearch.DataSource = ds.Tables[3];
                        gvSalesMonthWiseSearch.DataBind();
                    }

                    ddlReps_SelectedIndexChanged();
                }
                else
                {
                    divDashboard.Visible = false;
                }
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ReBindGuageChart()
    {
        try
        {
            object viewStateData = ViewState["GuageChart"];

            // Only proceed if ViewState contains a valid DataTable with rows
            if (viewStateData != null && viewStateData is DataTable && ((DataTable)viewStateData).Rows.Count > 0)
            {
                StringBuilder allScripts = new StringBuilder();
                string litScriptGauge = FirstBlock((DataTable)viewStateData);
                allScripts.Append(litScriptGauge);

                if (!string.IsNullOrEmpty(allScripts.ToString()) &&
                    allScripts.ToString().Trim().Length > 0 &&
                    allScripts.ToString().Contains("<script"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "DrawGoogleCharts", allScripts.ToString(), false);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private string FirstBlock(DataTable dt)
    {
        try
        {
            if (dt.Rows.Count == 2)
            {
                DataRow dr = dt.Rows[0];
                DataRow dr_1 = dt.Rows[1];
                decimal totalTarget = Convert.ToDecimal(dr["TotalTarget"]) + Convert.ToDecimal(dr_1["TotalTarget"]);
                decimal actualSales = Convert.ToDecimal(dr["ActualSales"]) + Convert.ToDecimal(dr_1["ActualSales"]);

                lblSalesTarget.InnerHtml = DateTime.Now.Year + " - <strong>$" + (totalTarget).ToString("N2") + "</strong>";
                lblUSTarget.InnerHtml = "US - <strong>$" + Convert.ToDecimal(dr_1["TotalTarget"]).ToString("N2") + "</strong>";
                lblCADTarget.InnerHtml = " | CAD - <strong>$" + Convert.ToDecimal(dr["TotalTarget"]).ToString("N2") + "</strong>";

                lblActualSales.InnerHtml = DateTime.Now.Year + " - <strong>$" + (actualSales).ToString("N2") + "</strong>";
                lblUSSales.InnerHtml = "US - <strong>$" + Convert.ToDecimal(dr_1["ActualSales"]).ToString("N2") + "</strong>";
                lblCADSales.InnerHtml = " | CAD - <strong>$" + Convert.ToDecimal(dr["ActualSales"]).ToString("N2") + "</strong>";

                string completionPercent = totalTarget == 0
                    ? "0.00%"
                    : "<strong>" + ((actualSales / totalTarget) * 100).ToString("N2") + "%</strong>";
                lblTargetCompletion.InnerHtml = completionPercent;

                decimal canadaTarget = Convert.ToDecimal(dr["TotalTarget"]);
                decimal canadaActual = Convert.ToDecimal(dr["ActualSales"]);
                string canadaCompletion = canadaTarget == 0
                    ? "0.00%"
                    : "| CAD<strong> - " + ((canadaActual / canadaTarget) * 100).ToString("N2") + "%</strong>";

                decimal usTarget = Convert.ToDecimal(dr_1["TotalTarget"]);
                decimal usActual = Convert.ToDecimal(dr_1["ActualSales"]);
                string usCompletion = usTarget == 0
                    ? "0.00%"
                    : "US <strong> - " + ((usActual / usTarget) * 100).ToString("N2") + "%</strong>";

                lblUSCompletionPercent.InnerHtml = usCompletion;
                lblCADCompletionPercent.InnerHtml = canadaCompletion;

                string target = FormatMillions(totalTarget);
                string trimmedTarget = target.Substring(0, target.Length - 1);
                string sales = FormatMillions(actualSales);
                string trimmedSales = sales.Substring(0, sales.Length - 1);
                string ticksArray = GenerateTicks(0, totalTarget, 7);

                return GenerateGaugeScript_TotalPercent(actualSales, trimmedSales, Decimal.Parse(trimmedTarget), ticksArray);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return "";
    }

    private string FormatMillions(decimal value)
    {
        return (value / 1000000.0m).ToString("0.#") + "M";
    }

    private string GenerateTicks(decimal min, decimal max, int numTicks)
    {
        try
        {
            List<string> ticks = new List<string>();

            decimal step = (max - min) / (numTicks - 1); // 6 intervals = 7 ticks

            for (int i = 0; i < numTicks; i++)
            {
                decimal tickValue = min + (step * i);
                string label = (tickValue / 1000000m).ToString("0.#") + "M";
                ticks.Add("'" + label + "'");
            }

            return string.Join(", ", ticks.ToArray());
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return "";
    }

    private string GenerateGaugeScript_TotalPercent(decimal value, string formatted, decimal max, string ticksArray)
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<script type='text/javascript'>");
            sb.AppendLine("google.charts.load('current', { packages: ['gauge'] });");
            sb.AppendLine("google.charts.setOnLoadCallback(drawChart);");
            sb.AppendLine("function drawChart() {");
            sb.AppendLine("  var value = " + formatted.ToString() + ";");
            //sb.AppendLine("  document.getElementById('custom_chtTotal_value').innerText = '" + formatted + "';");
            sb.AppendLine("  var data = google.visualization.arrayToDataTable([");
            sb.AppendLine("    ['Label', 'Value'],");
            sb.AppendLine("    ['', value]");
            sb.AppendLine("  ]);");
            sb.AppendLine("  var options = {");
            sb.AppendLine("    min: 0,");
            sb.AppendLine("    max: " + max.ToString() + ",");
            sb.AppendLine("    minorTicks: 3,");
            sb.AppendLine("    majorTicks: [" + ticksArray + "],");
            sb.AppendLine("    textStyle: { fontSize: 10 }");
            sb.AppendLine("  };");
            sb.AppendLine("  var chart = new google.visualization.Gauge(document.getElementById('chtTotal'));");
            sb.AppendLine("  chart.draw(data, options);");
            sb.AppendLine("}");
            sb.AppendLine("</script>");
            return sb.ToString();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return "";
    }

    private string ForthBlock()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = Utility.GetDashboardData(5).Tables[0];
            decimal totalNetEqPrice = 0m;

            foreach (DataRow row in dt.Rows)
            {
                if (row["NetAmount"] != DBNull.Value)
                {
                    totalNetEqPrice += Convert.ToDecimal(row["NetAmount"]);
                }
            }
            lblTotalSales.InnerHtml = "Total Sales " + currentYear + " - <strong>$" + totalNetEqPrice.ToString("N2") + "</strong>";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return "";
    }

    private void BindReportDropdowns(DataTable dt_1, DataTable dt_2)
    {
        try
        {
            if (dt_1.Rows.Count > 0 && ddlRegions.Items.Count == 0)
            {
                Utility.BindDropDownListAll(ddlRegions, dt_1);
            }

            if (dt_2.Rows.Count > 0 && ddlReps.Items.Count == 0)
            {
                Utility.BindDropDownListAll(ddlReps, dt_2);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private string FifthBlock()
    {
        try
        {
            decimal totalAmount = 0;
            int totalProjects = 0;
            decimal cadAmount = 0;
            int cadTotal = 0;
            decimal usAmount = 0;
            int usTotal = 0;
            DataTable dt = new DataTable();
            dt = Utility.GetDashboardData(6).Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                if (row["AmountForMonth"] != DBNull.Value)
                {
                    totalAmount += Convert.ToDecimal(row["AmountForMonth"]);

                    if (row["Currency"].ToString() == "Canadian")
                    {
                        cadAmount += Convert.ToDecimal(row["AmountForMonth"]);
                    }

                    if (row["Currency"].ToString() == "US")
                    {
                        usAmount += Convert.ToDecimal(row["AmountForMonth"]);
                    }
                }

                if (row["ProjectsForMonth"] != DBNull.Value)
                {
                    totalProjects += Convert.ToInt32(row["ProjectsForMonth"]);

                    if (row["Currency"].ToString() == "Canadian")
                    {
                        cadTotal += Convert.ToInt32(row["ProjectsForMonth"]);
                    }

                    if (row["Currency"].ToString() == "US")
                    {
                        usTotal += Convert.ToInt32(row["ProjectsForMonth"]);
                    }
                }
            }

            lblTotalProjectsShipped.InnerHtml = currentYear + " - <strong>" + totalProjects + "</strong>";
            lblValuesOfProjectsShipped.InnerHtml = currentYear + " - <strong>$" + totalAmount.ToString("N2") + "</strong>";

            lblUSProjectsShipped.InnerHtml = "US - <strong>" + usTotal + "</strong>";
            lblCADProjectsShipped.InnerHtml = "| CAD - <strong>" + cadTotal + "</strong>";

            lblUSProjectsShippedAmount.InnerHtml = "US - <strong>$" + usAmount.ToString("N2") + "</strong>";
            lblCADProjectsShippedAmount.InnerHtml = "| CAD - <strong>$" + cadAmount.ToString("N2") + "</strong>";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return "";
    }

    protected void gvSalesMonthWiseSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Check if Region is 'GrandTotal'
                object regionVal = DataBinder.Eval(e.Row.DataItem, "Region");

                if (regionVal != null && regionVal.ToString() == "Grand Total")
                {
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        //cell.ForeColor = System.Drawing.Color.Red;
                        cell.Font.Bold = true;
                        //cell.BackColor = System.Drawing.Color.LightYellow; // Optional styling
                        cell.ForeColor = System.Drawing.Color.DarkBlue;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSalesMonthWiseSearch_Rep_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Check if Region is 'GrandTotal'
                object regionVal = DataBinder.Eval(e.Row.DataItem, "Rep");

                if (regionVal != null && regionVal.ToString() == "Grand Total")
                {
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        //cell.ForeColor = System.Drawing.Color.Red;
                        cell.Font.Bold = true;
                        //cell.BackColor = System.Drawing.Color.LightYellow; // Optional styling
                        cell.ForeColor = System.Drawing.Color.DarkBlue;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlReps_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlReps_SelectedIndexChanged();
        string script = string.Format(
                       @"$(document).ready(function () {{
                $('#dashboardTabs a[href=""#{0}""]').tab('show');
            }});", "tab-six");

        ScriptManager.RegisterStartupScript(this, this.GetType(), "ActivateTabScript", script, true);
    }

    private void ddlReps_SelectedIndexChanged()
    {
        try
        {
            DataTable dt = new DataTable();
            clscon.Return_DT(dt, "EXEC Get_DashboardReports 2, NULL," + ddlReps.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                gvSalesMonthWiseSearch_Rep.DataSource = dt;
                gvSalesMonthWiseSearch_Rep.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //protected void Page_PreRender(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        // Add Bootstrap 5 CSS
    //        Literal css = new Literal();
    //        css.Text = @" <link rel='Stylesheet' href='bootstrap5/css/bootstrap.min.css' />";
    //        Page.Header.Controls.Add(css);

    //        // Add Bootstrap 5 JS
    //        Literal js = new Literal();
    //        js.Text = @" <script src='bootstrap5/js/bootstrap.bundle.min.js'></script>";
    //        Page.Header.Controls.Add(js);
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}


    private void FirstBlock_V1()
    {
        try
        {
            DataSet ds = Utility.GetDashboardData(7);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvProjectedVsActual.DataSource = ds.Tables[0];
                gvProjectedVsActual.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    int totalTarget = 0;
    int totalActual = 0;
    protected void gvProjectedVsActual_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Assuming column 1 = Target, column 2 = Actual
                int target = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ProjectedSales"));
                int actual = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ActualSales"));

                totalTarget += target;
                totalActual += actual;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total:";
                //e.Row.Cells[0].ColumnSpan = 2;
                e.Row.Cells[1].Font.Bold = true;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

                // Remove the now-unused second cell
                //e.Row.Cells.RemoveAt(1);

                e.Row.Cells[2].Text = "$" + totalTarget.ToString("N0"); // Adjust column index as needed
                e.Row.Cells[3].Text = "$" + totalActual.ToString("N0");
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].Font.Bold = true;
                e.Row.Cells[3].Font.Bold = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public class YTDQuotesandOrders
    {
        String _MonthName;
        public String MonthName
        {
            get { return _MonthName; }
            set { _MonthName = value; }
        }
        Decimal _TotalQuoteValue;
        public Decimal TotalQuoteValue
        {
            get { return _TotalQuoteValue; }
            set { _TotalQuoteValue = value; }
        }
        Int32 _MonthlyQuoteCount;
        public Int32 MonthlyQuoteCount
        {
            get { return _MonthlyQuoteCount; }
            set { _MonthlyQuoteCount = value; }
        }
        Decimal _TotalBookedValue;
        public Decimal TotalBookedValue
        {
            get { return _TotalBookedValue; }
            set { _TotalBookedValue = value; }
        }
        Int32 _OrderCount;
        public Int32 OrderCount
        {
            get { return _OrderCount; }
            set { _OrderCount = value; }
        }
    }

    [WebMethod]
    public static List<YTDQuotesandOrders> GetYTDQuotesandOrdersMonthlyTotal()
    {
        List<YTDQuotesandOrders> YTDQuotesandOrdersMonthlyTotalList = new List<YTDQuotesandOrders>();

        try
        {
            int Operation = 9;
            DataSet ds = Utility.GeYTDQuotesData(Operation); // Your data source
            DataTable dt = ds.Tables[0];   
            foreach (DataRow row in dt.Rows)
            {
                if (row["MonthName"].ToString() == "Total")
                    continue;
                YTDQuotesandOrdersMonthlyTotalList.Add(new YTDQuotesandOrders
                {
                    MonthName = row["MonthName"].ToString(),
                    TotalQuoteValue = Convert.ToInt32(row["TotalQuoteValue"].ToString()),
                    MonthlyQuoteCount = Convert.ToInt32(row["MonthlyQuoteCount"].ToString()),
                    TotalBookedValue = Convert.ToInt32(row["TotalBookedValue"].ToString()),
                    OrderCount = Convert.ToInt32(row["OrderCount"].ToString()),
                });
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

        return YTDQuotesandOrdersMonthlyTotalList;
    }
    public void Bind_GridMonthlyQuotesandOrders()
    {
        try
        {
            int Operation = 9;
            DataSet ds = Utility.GeYTDQuotesData(Operation); // Your data source
            DataTable dt= ds.Tables[0];            
            if (dt.Rows.Count > 0)
            {
                gvQuotesandOrders.DataSource = dt;
                gvQuotesandOrders.DataBind();
            }
            else
            {
                gvQuotesandOrders.DataSource = "";
                gvQuotesandOrders.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvQuotesandOrders_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblMonthOrders = (Label)e.Row.FindControl("lblQuotesandOrdersMonth");
                if (lblMonthOrders != null && lblMonthOrders.Text == "Total")
                {
                    // Loop through all cells in the row and apply styling
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        cell.Font.Bold = true;
                        //cell.BackColor = System.Drawing.Color.LightYellow; // Optional styling
                        cell.HorizontalAlign = HorizontalAlign.Right;
                    }
                }
            }
                
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnExportToExcel_PendingFollowupList_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        string FileName = Header.InnerText + ".xls";
        //gvSearch.AllowPaging = false;
        gvPendingList.AllowSorting = false;
        gvPendingList.AllowSorting = false;
        BindProposals(1);
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename=" + FileName));
        Response.Charset = "";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        gvPendingList.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.Flush();
        Response.End();
    }

    protected void btnExportToExcel_NotFollowedupList_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        string FileName = H1.InnerText + ".xls";
        //gvSearch.AllowPaging = false;
        gvListNot.AllowSorting = false;
        gvListNot.AllowSorting = false;
        BindProposals(2);
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename=" + FileName));
        Response.Charset = "";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        gvListNot.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.Flush();
        Response.End();
    }

    protected void btnExportToExcel_ShipDateHistory_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        string FileName = H2.InnerText + ".xls";
        //gvSearch.AllowPaging = false;
        gvShipDateUpdates.AllowSorting = false;
        gvShipDateUpdates.AllowSorting = false;
        BindProposals(3);
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename=" + FileName));
        Response.Charset = "";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        gvShipDateUpdates.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.Flush();
        Response.End();
    }

    protected void btnExportToExcel_TrackJobStatus_Click(object sender, EventArgs e)
    {
        try
        {
            Utility.ExportToExcelGrid(gvContainerJobs, "Track Jobs Status");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }       
    }
}