using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BOLAERO;
using BLLAERO;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Net.Mail;
using System.Configuration;
using System.Text;
using System.IO;

public partial class InventoryManagement_FrmShipments : System.Web.UI.Page
{
    BOLStockIn_New ObjBOL = new BOLStockIn_New();
    BLLStockIn_New ObjBLL = new BLLStockIn_New();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    string invoiceNo = "";
    string containerNo = "";
    string shipmentDate = "";
    string vendorName = "";
    string ETA = "";
    string Notes = "";
    string shippmentMethod = "";
    string shippmentStatus = "";
    
    string Do_Not_Reply = "[Please do not reply to this message. Replies to this message are routed to an unmonitored mailbox]";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                if (!IsPostBack)
                {
                    DisableButton();
                    BindControls(false);
                    CheckReceivedDatePermission();
                }
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #region Bind Functions
    private void BindControls(bool BindOnlyContainerLookup)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0 && !BindOnlyContainerLookup)
            {
                Utility.BindDropDownListAll(ddlVendorLookup, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlContainerLookup, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    private void CheckReceivedDatePermission()
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 14;
            ObjBOL.EmployeeID= Utility.GetCurrentSession().EmployeeID;
            msg = ObjBLL.Return_String(ObjBOL);
            if (msg == "1")
            {
                HfCheckEmployee.Value = msg;
                txtReceiveDate.Enabled = true;
                btnUploadPackingList.Enabled = true;
                EnabledETAControls();
            }
            else
            {
                HfCheckEmployee.Value = msg;
                txtReceiveDate.Enabled = false;
                btnUploadPackingList.Enabled = false;
                DisabledETAControls();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnabledETAControls()
    {
        try
        {
            btnAdd.Enabled = true;
            txtAddRevisedETA.Enabled = true;
            txtAddComments.Enabled = true;
            ddlAddStatus.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisabledETAControls()
    {
        try
        {
            btnAdd.Enabled = false;
            txtAddRevisedETA.Enabled = false;
            txtAddComments.Enabled = false;
            ddlAddStatus.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //#region Enabled/Disabled Stock In Button
    //private void ShowEnabledStockInButton()
    //{
    //    try
    //    {
    //        string msg = "";
    //        ObjBOL.Operation = 12;
    //        ObjBOL.EmployeeID = Utility.GetCurrentSession().EmployeeID;
    //        ObjBOL.ID = Convert.ToInt32(ddlContainerLookup.SelectedValue);
    //        msg = ObjBLL.Return_String(ObjBOL);
    //        if(msg == "1")
    //        {
    //            btnSave.Enabled = true;
    //        }
    //        else
    //        {
    //            btnSave.Enabled = false;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}
    //#endregion

    #region Validation

    private bool ValidationCheckInfo()
    {
        try
        {
            if (txtReceiveDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Arrival Date !");
                txtReceiveDate.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private bool ValidationCheckShipmentStatus()
    {
        try
        {
            changeLabelText(ddlAddStatus.SelectedValue);
            if (ddlContainerLookup.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Invoice No./Container No. !");                              
                ddlContainerLookup.Focus();
                return false;
            }
            if(ddlAddStatus.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Status. !");             
                ddlAddStatus.Focus();
                return false;
            }
            if (txtAddRevisedETA.Text == "")
            {        
                if(ddlAddStatus.SelectedValue == "1")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Revised ETA at Port. !");
                }
                else if(ddlAddStatus.SelectedValue == "2")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Revised ETA on the Rail. !");
                }
                else if(ddlAddStatus.SelectedValue == "3")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Revised ETA at Plant. !");
                }
                txtAddRevisedETA.Focus();
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

    #region Event handler

    //Event Handler for Dropdown
    protected void ddlVendorLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlVendorLookup_SelectedIndexChanged_Event();
    }

    //Event Handler for Dropdown
    protected void ddlContainerLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlContainerLookup_SelectedIndexChanged_Event();
    }

    //Event Handler for Button
    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    btnSave_Click_Event();
    //}

    //Event Handler for Button
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
    }

    //Event Handler for Button
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        btnAdd_Click_Event();
    }

     //Event Handler for Button
     protected void btnPackingDetails_Click(object sender, EventArgs e)
     {
         btnPackingDetails_Click_Event();
     }

    //Event Handler for Button
    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        //btnSendEmail_Click_Event();
    }

    //private void GetETAandNotes(string ContainerID)
    //{
    //    try
    //    {
    //        DataSet ds = new DataSet();
    //        ObjBOL.ID =Convert.ToInt32(ContainerID);
    //        ObjBOL.Operation = 13;
    //        ds = ObjBLL.Return_DataSet(ObjBOL);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            HfReceivedETA.Value = ds.Tables[0].Rows[0]["RevisedETA"].ToString();
    //            HfComments.Value = ds.Tables[0].Rows[0]["Comments"].ToString();
    //        }
    //        else
    //        {
    //            HfReceivedETA.Value = String.Empty;
    //            HfComments.Value = String.Empty;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);           
    //    }
    //}

    private void EmailNotifications()
    {
        try
        {
            if (Utility.InventoryEmailSwitch())
            {
                string Subject = "";
                string containerText = "";     
                if (ddlVendorLookup.SelectedIndex > 0)
                {
                    vendorName = ddlVendorLookup.SelectedItem.Text;
                }
                if (ddlContainerLookup.SelectedIndex > 0)
                {                    
                    string[] splitItem = ddlContainerLookup.SelectedItem.Text.Split('/');                    
                    if (splitItem.Length > 1)
                    {
                        invoiceNo = splitItem[0];                        
                        containerNo = splitItem[1];
                    }
                    if(containerNo != "")
                    {
                        containerText = invoiceNo + "/" + containerNo;
                    }
                    else
                    {
                        containerText = ddlContainerLookup.SelectedItem.Text;
                    }
                }                             
                string AcctualArrivalDate = "";
                DateTime ArrivalDate;
                if (DateTime.TryParse(txtReceiveDate.Text, out ArrivalDate))
                {
                    AcctualArrivalDate = ArrivalDate.ToString("MMMM dd, yyyy");
                }

                string Message = string.Empty;
                Message += "<!doctype><html lang='en'><head><meta charset = 'utf-8'><meta name = 'viewport' content = 'width=device-width, initial-scale=1'> ";
                Message += " <title> Shipment Details </title></head><body><table cellpadding='0' cellspacing='0' style='border-collapse:collapse;width:100%;font-family:Calibri;font-size:1.15rem'> ";
                Message += " <tr><td><table border='1' cellpadding='8' cellspacing='0' style='border-collapse:collapse;width:100%;max-width:580px;margin:0 auto;border-color:#ddd'> ";
                Message += " <tr><td colspan='2'><h2 style='margin:0;font-size:1.15rem'> Kishore,</h2> ";
                if (containerNo != "")
                {
                    Message += " <p style = 'margin-top:5px'> <b>Invoice/Container No: " + containerText + "</b> has been Arrived.";
                }
                else
                {
                    Message += " <p style = 'margin-top:5px'> <b>Invoice No: " + containerText + "</b> has been Arrived.";
                }    

                Message += " </p></td ></tr><tr><td colspan='2'><div style = 'width:80px;margin:0 auto'> ";
                Message += " </div> ";
                Message += " <h1 style ='font-size:1.65rem;margin:.3rem 0 0;color:#000;text-align:center'>Container Details</h1></td></tr> ";
                Message += " <tr><td style='width:1%;white-space:nowrap'> Vendor </td><td style='font-weight:600;width:99%'>" + vendorName + " </td></tr>";
                if(containerNo != "")
                {
                    Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'>Invoice/Container No: </td><td style='font-weight:600;width:99%'> " + containerText + "</td></tr>";
                }
                else
                {
                    Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'>Invoice No: </td><td style='font-weight:600;width:99%'> " + containerText + "</td></tr>";
                }
                Message += " <tr><td style='width:1%;white-space:nowrap'> Actual Arrival Date </td><td style='font-weight:600;width:99%' > " + AcctualArrivalDate + "</td></tr> ";

                //Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Reviced ETA  </td><td style='font-weight:600;width:99%'> " + ETA + "</td></tr>";


                //Message += " <tr><td style='width:1%;white-space:nowrap'> Shipping Coordinator Notes </td><td style='font-weight:600;width:99%' > " + Notes + "</td></tr> ";
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Shipment Status </td><td style='font-weight:600;width:99%'> " + "Arrived" + " </td></tr>";

                //Message += " <tr><td style='width:1%;white-space:nowrap'>  Info Updated DateTime </td><td style='font-weight:600;width:99%'> " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt") + "</td></tr> ";
                //Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'>  </td><td style='font-weight:600;width:99%'> " + + "</td></tr>";


                Message += " <tr><td colspan = '2'>If you have any questions or concerns regarding the above information, please contact Liezl at liezl@aero-werks.com.<br /><br/ > ";
                Message += " Thanks, <br/ > <strong> " + Utility.EmailDisplayName() + " </strong> <br /> ";
                Message += " </td></tr><tr><td colspan='2' style='color:Red'>"+ Do_Not_Reply +"</td></tr></table></td></tr></table></body></html> ";
                List<MailAddress> sendToList = new List<MailAddress>();
                List<MailAddress> ccList = new List<MailAddress>();
                HashSet<MailAddress> sendToListAsList = new HashSet<MailAddress>();
                HashSet<MailAddress> ccListAsList = new HashSet<MailAddress>();
                sendToListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "SendToList", Utility.emailDictionaryInventory, "Purchasing", 1,"A","");
                sendToList = sendToListAsList.ToList();
                ccListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "ccList", Utility.emailDictionaryInventory, "", 2,"A","");
                ccList = ccListAsList.ToList();
                if (containerNo != "")
                {
                    Subject = "Invoice/Container No: " + containerText + " Arrived";
                }
                else
                {
                    Subject = "Invoice No: " + containerText + " Arrived";
                }
                Send_Email(Message,Subject, sendToList, ccList);
                sendToListAsList.Clear();
                ccListAsList.Clear();                
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Email Disabled !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Event Handler for Grid
    protected void GvShipmentTracker_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GvShipmentTracker.EditIndex = e.NewEditIndex;
            GetContainerHistory();
            Int32 ID = Convert.ToInt32(GvShipmentTracker.DataKeys[e.NewEditIndex].Value);
            HfEditRowID.Value =Convert.ToString(ID);
            Label lblEditStatus = GvShipmentTracker.Rows[e.NewEditIndex].FindControl("lblEditProjectStatus") as Label;
            Label lblEditRevisedETA = GvShipmentTracker.Rows[e.NewEditIndex].FindControl("txtRevisedETA") as Label;
            Label lblEditComments = GvShipmentTracker.Rows[e.NewEditIndex].FindControl("txtComments") as Label;
            if (lblEditStatus.Text != "")
            {
                ddlAddStatus.SelectedValue = lblEditStatus.Text;
                changeLabelText(ddlAddStatus.SelectedValue);
            }
            else
            {
                if (ddlAddStatus.Items.Count > 0)
                {
                    ddlAddStatus.SelectedIndex = 0;
                    changeLabelText("");
                }
            }
            if(lblEditRevisedETA.Text != "")
            {
                txtAddRevisedETA.Text = lblEditRevisedETA.Text;
            }
            else
            {
                txtAddRevisedETA.Text = String.Empty;
            }
            if(lblEditComments.Text != "")
            {
                txtAddComments.Text = lblEditComments.Text;
            }
            else
            {
                txtAddComments.Text = String.Empty;
            }
            btnAdd.Text = "Update";
            btnUploadPackingList.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void changeLabelText(string statusid)
    {
        try
        {
            if(statusid == "1")
            {
                lblAddRevisedETA.InnerText = "Revised ETA at Port*";
            }
            else if(statusid == "2")
            {
                lblAddRevisedETA.InnerText = "Revised ETA on the Rail*";
            }
            else if(statusid == "3")
            {
                lblAddRevisedETA.InnerText = "Revised ETA at Plant*";
            }
            else
            {
                lblAddRevisedETA.InnerText = "Revised ETA*";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Event Handler for Grid
    protected void GvShipmentTracker_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Int32 ID = Convert.ToInt32(GvShipmentTracker.DataKeys[e.RowIndex].Value);
            ObjBOL.Operation = 8;
            ObjBOL.ID = ID;
            string returnStatus = ObjBLL.Return_String(ObjBOL);
            if (returnStatus.Trim() != "")
            {
                Utility.MaintainLogsSpecial("FrmShipments.aspx", "delete-detail", ddlContainerLookup.SelectedValue);
                Utility.ShowMessage_Success(Page, returnStatus);
                GetContainerHistory();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Event Handler for Grid
    protected void GvShipmentTracker_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            GvShipmentTracker.EditIndex = -1;
            GetContainerHistory();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region other functions

    private void Send_Email(String Message, String Subject, List<MailAddress> sendToList, List<MailAddress> ccList)
    {
        try
        {
            if (sendToList.Count > 0)
            {
                string fileNameInEmail = String.Empty;
                string fileExtension = String.Empty;
                string filePath = String.Empty;
                MailMessage message = new MailMessage(new MailAddress(Utility.Email(), Utility.EmailDisplayName()), sendToList[0]);
                string mailbody = Message;
                //message.CC.Add(cc);
                message.Subject = Subject;
                message.Body = mailbody;
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
                //ClientScript.RegisterStartupScript(this.GetType(), "showemailnotification", "showemailnotification();", true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void SendEmail_Prepare(string invoice,string containerNo,string vendor,string receiveDateString,string revicedETA,string comments,string ContainerStatus)
    {
        try
        {
            if (Utility.InventoryEmailSwitch())
            {
                string EmailSubject = string.Empty;
                string Message = string.Empty;
                Message += "<!doctype><html lang='en'><head><meta charset = 'utf-8'><meta name = 'viewport' content = 'width=device-width, initial-scale=1'> ";
                Message += " <title> Shipment Details </title></head><body><table cellpadding='0' cellspacing='0' style='border-collapse:collapse;width:100%;font-family:Calibri;font-size:1.15rem'> ";
                Message += " <tr><td><table border='1' cellpadding='8' cellspacing='0' style='border-collapse:collapse;width:100%;max-width:580px;margin:0 auto;border-color:#ddd'> ";
                Message += " <tr><td colspan='2'><h2 style='margin:0;font-size:1.15rem'> Kishore,</h2> ";
                Message += " <p style = 'margin-top:5px'> You will find the Shipment Tracking Details of  <b>Invoice No: " + invoice + "</b>. ";

                Message += " </p></td ></tr><tr><td colspan='2'><div style = 'width:80px;margin:0 auto'> ";
                Message += " </div> ";
                Message += " <h1 style ='font-size:1.65rem;margin:.3rem 0 0;color:#000;text-align:center'> Shipment Details</h1></td></tr> ";
                Message += " <tr><td style='width:1%;white-space:nowrap'>Invoice No</td><td style='font-weight:600;width:99%'>" + invoice + " </td></tr>";
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'>Container No </td><td style='font-weight:600;width:99%'> " + containerNo + "</td></tr>";
                Message += " <tr><td style='width:1%;white-space:nowrap'> Vendor </td><td style='font-weight:600;width:99%' > " + vendor + "</td></tr> ";

                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> ETA </td><td style='font-weight:600;width:99%'> " + revicedETA + "</td></tr>";

                
                Message += " <tr><td style='width:1%;white-space:nowrap'> Comments  </td><td style='font-weight:600;width:99%' > " + comments + "</td></tr> ";
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Container Status </td><td style='font-weight:600;width:99%'> " + ContainerStatus + "</td></tr>";               
                Message += " <tr><td colspan = '2'>If you have any questions or concerns regarding the above information, please contact Liezl at liezl@aero-werks.com.<br /><br/ > ";
                Message += " Thanks, <br/ > <strong> " + Utility.EmailDisplayName() + " </strong> <br />";
                Message += " </td></tr><tr><td colspan='2' style='color:Red'>"+ Do_Not_Reply +"</td></tr></table></td></tr></table></body></html> ";                       
                if (containerNo == "")
                {
                    EmailSubject = "Invoice No " + invoice + " ETA " + revicedETA + ": " + ContainerStatus;
                }
                else
                {
                    EmailSubject = "Container No " + containerNo + " ETA " + revicedETA + ": " + ContainerStatus;
                }
                List<MailAddress> sendToList = new List<MailAddress>();
                List<MailAddress> ccList = new List<MailAddress>();
                HashSet<MailAddress> sendToListAsList = new HashSet<MailAddress>();
                HashSet<MailAddress> ccListAsList = new HashSet<MailAddress>();
                sendToListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "SendToList", Utility.emailDictionaryInventory, "Purchasing", 1,"E","");
                sendToList = sendToListAsList.ToList();
                ccListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "ccList", Utility.emailDictionaryInventory, "", 2,"E","");
                ccList = ccListAsList.ToList();
                Send_Email(Message, EmailSubject, sendToList, ccList);
                sendToListAsList.Clear();
                ccListAsList.Clear();
            }
            else
            {                
                ClientScript.RegisterStartupScript(this.GetType(), "showemailnotificationDisabled", "showemailnotificationDisabled();", true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //private void btnSendEmail_Click_Event()
    //{
    //    try
    //    {
    //        SendEmail_Prepare();
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}

    private DataTable EmptyDT()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("RevisedETA", typeof(string)));
            dt.Columns.Add(new DataColumn("Comments", typeof(string)));
            dt.Columns.Add(new DataColumn("ProjectStatus", typeof(string)));
            dt.Columns.Add(new DataColumn("StatusID", typeof(int)));
            DataRow datarow = dt.NewRow();
            dt.Rows.Add(datarow);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void ddlVendorLookup_SelectedIndexChanged_Event()
    {
        try
        {
            ResetDetail();
            ResetETAEntries();
            if (ddlVendorLookup.SelectedIndex > 0)
            {
                DisableButton();
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.ID = Int32.Parse(ddlVendorLookup.SelectedValue);
                ds = ObjBLL.Return_DataSet(ObjBOL);
                Utility.BindDropDownList(ddlContainerLookup, ds.Tables[0]);
            }
            else
            {
                Reset();                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlContainerLookup_SelectedIndexChanged_Event()
    {
        try
        {
            ResetETAEntries();
            if (ddlContainerLookup.SelectedIndex > 0)
            {               
                btnPackingDetails.Enabled = true;
                CheckReceivedDatePermission();
                ObjBOL.Operation = 3;
                ObjBOL.ID = Int32.Parse(ddlContainerLookup.SelectedValue);
                string returnValue = ObjBLL.Return_String(ObjBOL);
                if (returnValue.Trim() != "")
                {
                    ddlVendorLookup.SelectedValue = returnValue;
                }
                GetContainerInfo();                
                GetFilePath(ddlContainerLookup.SelectedValue);
                GetContainerHistory();
            }
            else
            {
                ResetDetail();                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //private void btnSave_Click_Event()
    //{
    //    try
    //    {
    //        if (ValidationCheckInfo())
    //        {
    //            ObjBOL.Operation = 9;
    //            ObjBOL.ID = Int32.Parse(ddlContainerLookup.SelectedValue);                
    //            ObjBOL.EmployeeID = Utility.GetCurrentUser();
    //            string returnStatus = ObjBLL.Return_String(ObjBOL);
    //            if (returnStatus.Trim() != "")
    //            {
    //                Utility.ShowMessage_Success(Page, returnStatus);                   
    //                Reset();
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}

    private void btnAdd_Click_Event()
    {
        try
        {
            if (ValidationCheckShipmentStatus())
            {
                string receiveDateString = string.Empty;
                string UpdateETADate = "";
                string vendor = "";
                string invoice = "";
                string containerNo = "";
                string ETAlabelText = "";
                string[] splitItem = ddlContainerLookup.SelectedItem.Text.Split('/');
                invoice = splitItem[0];
                if (splitItem.Length > 1)
                {
                    containerNo = splitItem[1];
                }
                if (ddlVendorLookup.SelectedIndex > 0)
                {
                    vendor = ddlVendorLookup.SelectedItem.Text;
                }
                DateTime receiveDate;
                if (DateTime.TryParse(txtAddRevisedETA.Text, out receiveDate))
                {
                    receiveDateString = receiveDate.ToString("MMMM dd, yyyy");
                }
                string ContainerID = ddlContainerLookup.SelectedValue;
                string RevisedETA = txtAddRevisedETA.Text;
                //if(RevisedETA != "")
                //{
                //    TrackStatusData(ContainerID, RevisedETA);
                //}
                string Comments = txtAddComments.Text; 
                if(btnAdd.Text == "Add")
                {
                    ObjBOL.Operation = 6;                    
                }
                else
                {
                    ObjBOL.Operation = 7;
                    ObjBOL.ContainerDetailID =Convert.ToInt32(HfEditRowID.Value);
                }                
                ObjBOL.ID = Int32.Parse(ddlContainerLookup.SelectedValue);
                ObjBOL.RevisedETA = Utility.ConvertDate(RevisedETA);
                ObjBOL.Comments = Comments;
                if(ContainerID != "")
                {
                    ObjBOL.ContainerID =Convert.ToInt32(ContainerID);
                }
                if (ddlAddStatus.SelectedIndex > 0)
                {
                    ObjBOL.Status = Convert.ToInt32(ddlAddStatus.SelectedValue);
                }
                string returnStatus = ObjBLL.Return_String(ObjBOL);                
                //if (ddlAddStatus.SelectedValue == "3")
                //{
                //    DateTime revisedDate = DateTime.ParseExact(RevisedETA, "MM/dd/yyyy", null);
                //    DateTime newDate = revisedDate.AddDays(10);
                //    UpdateETADate = newDate.ToString("MM/dd/yyyy");
                //}
                //else
                //{
                //    UpdateETADate = RevisedETA;
                //}
                UpdateETADate = RevisedETA;
                if (returnStatus.Trim() != "")
                {
                   
                    if (ddlContainerLookup.SelectedIndex > 0)
                    {
                        SendEmail_Prepare(invoice, containerNo, vendor, receiveDateString, UpdateETADate, Comments, ddlAddStatus.SelectedItem.Text);
                    }
                    if(returnStatus.Trim() != "Record updated successfully!!")
                    {
                        Utility.MaintainLogsSpecial("FrmShipments.aspx", "Save-detail", ddlContainerLookup.SelectedValue);
                        if (Utility.InventoryEmailSwitch())
                        {
                            Utility.ShowMessage_Success(Page, "Data Added Successfully and Email Sent !");
                        }
                        else
                        {
                            Utility.ShowMessage_Success(Page, "Data Added Successfully !");
                        }
                    }
                    else
                    {
                        Utility.MaintainLogsSpecial("FrmShipments.aspx", "update-detail", ddlContainerLookup.SelectedValue);
                        if (Utility.InventoryEmailSwitch())
                        {
                            Utility.ShowMessage_Success(Page, "Data Updated Successfully and Email Sent !");
                        }
                        else
                        {
                            Utility.ShowMessage_Success(Page, "Data Updated Successfully !");
                        }

                    }
                    GetContainerHistory();                    
                    HfReceivedETA.Value = RevisedETA;
                    HfComments.Value = Comments;
                    ResetETAEntries();
                }
            }
            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }



    private void ResetETAEntries()
    {
        try
        {
            ddlAddStatus.SelectedIndex = 0;
            txtAddRevisedETA.Text = String.Empty;
            txtAddComments.Text = String.Empty;
            btnUploadPackingList.Enabled = true;
            btnAdd.Text = "Add";
            changeLabelText("");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetContainerInfo()
    {
        try
        {
            if (ddlContainerLookup.SelectedIndex > 0)
            {
                ObjBOL.Operation = 4;
                ObjBOL.ID = Int32.Parse(ddlContainerLookup.SelectedValue);
                string returnValue = ObjBLL.Return_String(ObjBOL);
                if (returnValue.Trim() != "")
                {
                    txtReceiveDate.Text = returnValue;
                }
                else
                {
                    txtReceiveDate.Text = string.Empty;
                }
                GetContainerHistory();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetContainerHistory()
    {
        try
        {
            if (ddlContainerLookup.SelectedIndex > 0)
            {
                //CheckReceiveDate();
                DataSet ds = new DataSet();
                ObjBOL.Operation = 5;
                ObjBOL.ID = Int32.Parse(ddlContainerLookup.SelectedValue);
                ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {                    
                    GvShipmentTracker.DataSource = ds.Tables[0];
                    GvShipmentTracker.DataBind();                  
                }
                else
                {
                    GvShipmentTracker.DataSource = "";
                    GvShipmentTracker.DataBind();                                    
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableButton()
    {
        try
        {
            //ShowEnabledStockInButton();
            btnPackingDetails.Enabled = true;                        
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableButton()
    {
        try
        {
            btnPackingDetails.Enabled = false;
            //btnSave.Enabled = false;
            btnSendEmail.Enabled = false;
            btnUploadPackingList.Enabled = false;
            txtReceiveDate.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }  

    #endregion

    #region Report

    private DataTable ReportDataZero()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[Get_PackingDetails] '" + ddlContainerLookup.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportDataFirst()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[Get_PackingDetails_Jobs] '" + ddlContainerLookup.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void PrepareReport()
    {
        try
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt = ReportDataZero();
            dt1 = ReportDataFirst();
            rprt.Load(Server.MapPath("~/Reports/rptPackingDetails.rpt"));
            if (dt.Rows.Count > 0)
            {
                rprt.SetDataSource(dt);
                rprt.Subreports[0].SetDataSource(dt1);
                rptGenerateReport.ReportSource = rprt;
                rptGenerateReport.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnPackingDetails_Click_Event()
    {
        try
        {
            string invoice = "";
            string containerNo = "";
            string[] splitItem = ddlContainerLookup.SelectedItem.Text.Split('/');
            invoice = splitItem[0];
            if (splitItem.Length > 1)
            {
                containerNo = splitItem[1];
            }
            PrepareReport();
            rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, invoice);
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

    private Stream GetPackingDetailsReportStream()
    {
        PrepareReport();
        Stream reportStream;
        reportStream = (Stream)rprt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        rprt.Close();
        rprt.Dispose();
        return reportStream;
    }  

    #endregion

    #region resets

    private void Reset()
    {
        try
        {
            BindControls(false);
            ddlVendorLookup.SelectedIndex = 0;
            ddlContainerLookup.SelectedIndex = 0;
            lnkDowloadPackingList.Visible = false;
            lnkDowloadPackingList.Text = String.Empty;
            ViewState["IsPageLoaded"] = false;
            ResetDetail();
            ResetETAEntries();       
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetDetail()
    {
        try
        {
            DisableButton();
            txtReceiveDate.Text = string.Empty;
            GvShipmentTracker.DataSource = string.Empty;
            GvShipmentTracker.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    //Event Handler Upload Packing List
    private Boolean ValidationCheckShipping()
    {
        try
        {
            if (txtReceiveDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Received Date !");
                txtReceiveDate.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }



    protected void btnUploadPackingList_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlContainerLookup.SelectedIndex > 0)
            {
                btnUploadPackingList_Click_Event(ddlContainerLookup.SelectedValue);                                 
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please Select Invoice No./Container No. First !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void btnUploadPackingList_Click_Event(string ContainerID)
    {
        try
        {
            if (!string.IsNullOrEmpty(ContainerID))
            {                
                if (ValidationCheckInfo())
                {
                    string msg = "";
                    ObjBOL.Operation = 11;
                    ObjBOL.ID = Convert.ToInt32(ContainerID);
                    if (txtReceiveDate.Text != "")
                    {
                        ObjBOL.ReceivedDate = Utility.ConvertDate(txtReceiveDate.Text);
                    }
                    if (fpUpload.HasFile)
                    {
                        string fileName = Path.GetFileName(fpUpload.FileName);
                        string fileExtension = Path.GetExtension(fileName).ToLower();                        
                        if (fileExtension == ".pdf" || fileExtension == ".xls" || fileExtension == ".xlsx")
                        {
                            string folderPath = Utility.PackingListPath();
                            if (!Directory.Exists(folderPath))
                            {
                                //If Directory (Folder) does not exists Create it.
                                Directory.CreateDirectory(folderPath);
                            }
                            int fileSizeInBytes = fpUpload.PostedFile.ContentLength;
                            if (fileSizeInBytes <= 6291456) // 5120000/1024=5000 KB
                            {
                                string newfilename = fileName;
                                fpUpload.SaveAs(folderPath + newfilename);
                                ObjBOL.PackingList = fileName.ToUpper();
                            }
                            else
                            {
                                Utility.ShowMessage_Error(Page, "File size exceeds 6 MB. Please upload a smaller file.");
                                return;
                            }                           
                        }
                        else
                        {
                            Utility.ShowMessage_Error(Page, "Invalid file type. Please upload a PDF or Excel file.");
                            return;
                        }                        
                    }
                    msg = ObjBLL.UploadPackingList(ObjBOL);
                    Utility.ShowMessage_Success(Page, msg);
                    GetFilePath(ContainerID);
                    Utility.MaintainLogsSpecial("FrmShipments.aspx", "Update-Packing-list", ContainerID);
                    if (ValidationCheckShipping())
                    {
                        EmailNotifications();
                    }
                    Reset();                    
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "Please Select Invoice No./Container No. First !!");
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

            protected void GetFilePath(string ContainerID)
            {
                try
                {
                    DataSet ds = new DataSet();
                    ObjBOL.Operation = 10;
                    ObjBOL.ID = Convert.ToInt32(ContainerID);
                    ds = ObjBLL.Return_DataSet(ObjBOL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lnkDowloadPackingList.Visible = true;
                        lnkDowloadPackingList.Text = ds.Tables[0].Rows[0]["PackingList"].ToString();
                        hfPackingListName.Value= ds.Tables[0].Rows[0]["PackingList"].ToString();
                    }
                    else
                    {
                        lnkDowloadPackingList.Visible = false;
                        lnkDowloadPackingList.Text = String.Empty;
                        hfPackingListName.Value = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    Utility.AddEditException(ex);
                }
            }

            protected void lnkDowloadPackingList_Click(object sender, EventArgs e)
            {
                try
                {
                    GetFilePath(ddlContainerLookup.SelectedValue);
                    var fileName = lnkDowloadPackingList.Text;
                    string filePath = Utility.PackingListPath() + fileName;
                    FileInfo file = new FileInfo(filePath);
                    if (file.Exists && Response.IsClientConnected)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        Response.ContentType = "application/pdf";
                        Response.Flush();
                        Response.TransmitFile(file.FullName);
                        Response.End();
                    }
                }
                catch (Exception ex)
                {
                    Utility.AddEditException(ex);
                }
            }

    protected void GvShipmentTracker_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkEdit=(LinkButton)e.Row.FindControl("lnkEdit");                
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if(lnkEdit != null  && lnkDelete != null)
                {
                    if (HfCheckRecDate.Value == "-1" && HfCheckEmployee.Value == "1")
                    {
                        lnkEdit.CssClass = lnkEdit.CssClass.Replace("disabled", "").Trim();
                        lnkEdit.CssClass += " enabled";
                        lnkDelete.CssClass = lnkDelete.CssClass.Replace("disabled", "").Trim();
                        lnkDelete.CssClass += " enabled";
                    }
                    else
                    {
                        lnkEdit.CssClass += " disabled";
                        lnkDelete.CssClass += " disabled";
                        //lnkEdit.Enabled = false;                    
                        //lnkDelete.Enabled = false;
                    }
                }
                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    
    private void CheckReceiveDate()
    {
        string msg = "";
        try
        {
            ObjBOL.Operation = 17;
            ObjBOL.ID = Convert.ToInt32(ddlContainerLookup.SelectedValue);
            msg = ObjBLL.Return_String(ObjBOL);
            if(msg != "")
            {
                HfCheckRecDate.Value = msg;
                dvUpload.Visible = false;
                txtReceiveDate.Enabled = false;
                btnUploadPackingList.Enabled = false;
            }
            else
            {
                HfCheckRecDate.Value = "-1";
                dvUpload.Visible = true;
                txtReceiveDate.Enabled = true;
                btnUploadPackingList.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public void TrackStatusData(string ContainerID, string ETADate)
    {
        try
        {
            string Do_Not_Reply = "[Please do not reply to this message. Replies to this message are routed to an unmonitored mailbox]";
            commonclass1 con = new commonclass1();
            DataSet ds = new DataSet();             
            if (ContainerID != "" && ETADate != "")
            {
                con.Return_DS(ds, "EXEC [Get_JobNotificationsEmailPM_RevisedETAChange] '" + ContainerID + "','" + ETADate + "'");
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Show Email Notification
                    string PM = ds.Tables[0].Rows[0]["ProjectManager"].ToString();
                    string JobID = ds.Tables[0].Rows[0]["JobID"].ToString();
                    string JobName = ds.Tables[0].Rows[0]["ProjectName"].ToString();
                    string ShipDate = ds.Tables[0].Rows[0]["ShipDate"].ToString();
                    string Source = ds.Tables[0].Rows[0]["Source"].ToString();
                    string ContainerDetails = ds.Tables[0].Rows[0]["ContainerDetails"].ToString();
                    SendJobsStatusForPM_Prepare(PM, JobID, JobName, ShipDate, Source, ContainerDetails, Do_Not_Reply);
                    if (ContainerID != "" && ETADate != "")
                    {
                        Utility.MaintainLogsSpecial("FrmShipments.aspx", "EmailSend", ContainerID);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    public void SendJobsStatusForPM_Prepare(string PM, string JobNo, string JobName, string ShipDate, string Source, string ContainerDetails, string Do_Not_Reply)
    {
        try
        {
            if (Utility.InventoryEmailSwitch())
            {
                string Subject = "Track Jobs Status";
                string Message = string.Empty;
                Message += "<!doctype><html lang='en'><head><meta charset = 'utf-8'><meta name = 'viewport' content = 'width=device-width, initial-scale=1'> ";
                Message += " <title> Track Jobs Status </title></head><body><table cellpadding='0' cellspacing='0' style='border-collapse:collapse;width:100%;font-family:Calibri;font-size:1.15rem'> ";
                Message += " <tr><td><table border='1' cellpadding='8' cellspacing='0' style='border-collapse:collapse;width:100%;max-width:580px;margin:0 auto;border-color:#ddd'> ";
                Message += " <tr><td colspan='2'><h2 style='margin:0;font-size:1.15rem'>" + PM + ",</h2> ";
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
                Message += " <h1 style ='font-size:1.65rem;margin:.3rem 0 0;color:#000;text-align:center'>Job Status Details</h1></td></tr> ";
                Message += " <tr><td style='width:1%;white-space:nowrap'>Job No</td><td style='font-weight:600;width:99%'>" + JobNo + " </td></tr>";
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'>Job Name </td><td style='font-weight:600;width:99%'> " + JobName + "</td></tr>";
                Message += " <tr><td style='width:1%;white-space:nowrap'> Ship Date </td><td style='font-weight:600;width:99%'>" + ShipDate + "</td></tr> ";
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Source </td><td style='font-weight:600;width:99%' > " + Source + "</td></tr> ";
                Message += " <tr><td style='width:1%;white-space:nowrap'> Container No, ETA & Status </td><td style='font-weight:600;width:99%'>" + ContainerDetails + "</td></tr> ";
                Message += " <tr><td colspan = '2'> Thanks, <br/ > <strong> " + Utility.EmailDisplayName() + " </strong> <br /> ";
                Message += " </td></tr><tr><td colspan='2' style='color:Red'>" + Do_Not_Reply + "</td></tr></table></td></tr></table></body></html> ";
                List<MailAddress> sendToList = new List<MailAddress>();
                List<MailAddress> ccList = new List<MailAddress>();
                HashSet<MailAddress> sendToListAsList = new HashSet<MailAddress>();
                HashSet<MailAddress> ccListAsList = new HashSet<MailAddress>();
                sendToListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "SendToList", Utility.emailDictionaryInventory, "Ruth", 1, "T", "");
                ccListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "ccList", Utility.emailDictionaryInventory, "", 2, "T", "");
                sendToList = sendToListAsList.ToList();
                ccList = ccListAsList.ToList();
                Send_RevisedETAEmail(Message, Subject, sendToList, ccList);
                sendToListAsList.Clear();
                ccListAsList.Clear();
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void Send_RevisedETAEmail(String Message, String Subject, List<MailAddress> sendToList, List<MailAddress> ccList)
    {
        try
        {
            if (sendToList.Count > 0)
            {
                MailMessage message = new MailMessage(new MailAddress(Utility.Email(), Utility.EmailDisplayName()), sendToList[0]);
                string filename = string.Empty;

                string mailbody = Message;
                message.Subject = Subject;
                message.Body = mailbody;
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
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}