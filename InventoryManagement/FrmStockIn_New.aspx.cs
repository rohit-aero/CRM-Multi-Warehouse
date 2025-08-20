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

public partial class InventoryManagement_FrmStockIn_New : System.Web.UI.Page
{
    BOLStockIn_New ObjBOL = new BOLStockIn_New();
    BLLStockIn_New ObjBLL = new BLLStockIn_New();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();    
    string containerNo = "";
    string shipmentDate = "";
    string vendorName = "";
    string ETA = "";
    string Notes = "";
    string shippmentMethod = "";
    string shippmentStatus = "";
   
    MailAddress MailAddress_AeroIt = new MailAddress(Utility.Email(), Utility.EmailDisplayName());
    MailAddress MailAddress_Purchasing = new MailAddress("purchasing@aero-werks.com", "Purchasing");

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
            ObjBOL.Operation = 15;
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
                //btnUploadPackingList.Enabled = true;
            }
            else
            {
                HfCheckEmployee.Value = msg;
                txtReceiveDate.Enabled = false;
                //btnUploadPackingList.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //#region Enabled/Disabled Stock In Button
    private void ShowEnabledStockInButton()
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 12;
            ObjBOL.EmployeeID = Utility.GetCurrentSession().EmployeeID;
            ObjBOL.ID = Convert.ToInt32(ddlContainerLookup.SelectedValue);
            msg = ObjBLL.Return_String(ObjBOL);
            if(msg == "1")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
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
            TextBox RevisedETA = (GvShipmentTracker.FooterRow.FindControl("txtFooterRevisedETA") as TextBox);
            if (RevisedETA.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Revised ETA. !");
                RevisedETA.Focus();
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave_Click_Event();
    }

    //Event Handler for Button
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
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
      
    #region other functions

    private void Send_Email(String Message, String Subject, List<MailAddress> sendToList, List<MailAddress> ccList)
    {
        try
        {
            string fileNameInEmail = String.Empty;
            string fileExtension = String.Empty;
            string filePath = String.Empty;
            MailMessage message = new MailMessage(MailAddress_AeroIt, sendToList[0]);
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
                message.CC.Add(cc);
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
            ClientScript.RegisterStartupScript(this.GetType(), "showemailnotification", "showemailnotification();", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void SendEmail_Prepare(string invoice,string containerNo,string vendor,string receiveDateString,string revicedETA,string comments)
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
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Shipment Status </td><td style='font-weight:600;width:99%'> " + "In-Transit" + "</td></tr>";
                Message += " <tr><td colspan = '2'>If you have any questions or concerns regarding the above Information, please contact the Liezl. liezl@aero-werks.com <br /><br/ > ";
                Message += " Thanks, <br/ > <strong> " + Utility.EmailDisplayName() + " </strong> <br />";
                Message += " </td></tr><tr><td colspan='2' style='color:Red'>"+ Do_Not_Reply +"</td></tr></table></td></tr></table></body></html> ";
               
                List<MailAddress> sendToList = new List<MailAddress>();
                List<MailAddress> ccList = new List<MailAddress>();
                sendToList.Add(MailAddress_Purchasing);    
                if(containerNo == "")
                {
                    EmailSubject = "Invoice No " + invoice + " ETA " + revicedETA;
                }
                else
                {
                    EmailSubject = "Container No " + containerNo + " ETA " + revicedETA;
                }         
                Send_Email(Message, EmailSubject, sendToList, ccList);
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
            if (ddlVendorLookup.SelectedIndex > 0)
            {
                DisableButton();
                DataSet ds = new DataSet();
                ObjBOL.Operation = 16;
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
            if (ddlContainerLookup.SelectedIndex > 0)
            {
                //CheckReceivedDatePermission();                
                ObjBOL.Operation = 3;
                ObjBOL.ID = Int32.Parse(ddlContainerLookup.SelectedValue);
                string returnValue = ObjBLL.Return_String(ObjBOL);
                if (returnValue.Trim() != "")
                {
                    ddlVendorLookup.SelectedValue = returnValue;
                }
                GetContainerInfo();
                EnableButton();
                GetFilePath(ddlContainerLookup.SelectedValue);                   
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

    private void btnSave_Click_Event()
    {
        try
        {
            if (ValidationCheckInfo())
            {
                ObjBOL.Operation = 9;
                ObjBOL.ID = Int32.Parse(ddlContainerLookup.SelectedValue);                
                ObjBOL.EmployeeID = Utility.GetCurrentUser();
                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim() != "")
                {
                    Utility.ShowMessage_Success(Page, returnStatus);                   
                    Reset();
                }
            }
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
                DataSet ds = new DataSet();
                ObjBOL.Operation = 5;
                ObjBOL.ID = Int32.Parse(ddlContainerLookup.SelectedValue);
                ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {                    
                    GvShipmentTracker.DataSource = ds.Tables[0];
                    GvShipmentTracker.DataBind();
                    //Button btnAdd = (Button)GvShipmentTracker.FooterRow.FindControl("btnAdd");
                    //if (HfCheckEmployee.Value == "1")
                    //{
                    //    btnAdd.Enabled = true;
                    //}
                    //else
                    //{
                    //    btnAdd.Enabled = false;
                    //}
                }
                else
                {
                    GvShipmentTracker.DataSource = "";
                    GvShipmentTracker.DataBind();
                    //GvShipmentTracker.Rows[0].Visible = false;
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
            ShowEnabledStockInButton();
            btnPackingDetails.Enabled = true;
            btnExportNegativeStock.Enabled = true;                  
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
            btnExportNegativeStock.Enabled = false;
            btnSave.Enabled = false;
            btnSendEmail.Enabled = false;
            //btnUploadPackingList.Enabled = false;
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
            clscon.Return_DT(dt, "EXEC [IV].[Get_PackingDetails_V1] '" + ddlContainerLookup.SelectedValue + "'");
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
            clscon.Return_DT(dt, "EXEC [IV].[Get_PackingDetails_Jobs] '" + ddlContainerLookup.SelectedValue + "'");
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
            divpackinglistlink.Visible = false;
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
                if(ds.Tables[0].Rows[0]["PackingList"].ToString() != "")
                {
                    divpackinglistlink.Visible = true;
                    lnkDowloadPackingList.Visible = true;
                    lnkDowloadPackingList.Text = ds.Tables[0].Rows[0]["PackingList"].ToString();
                    hfPackingListName.Value = ds.Tables[0].Rows[0]["PackingList"].ToString();
                }
                else
                {
                    divpackinglistlink.Visible = false;
                    lnkDowloadPackingList.Visible = false;
                    lnkDowloadPackingList.Text = String.Empty;
                    hfPackingListName.Value = string.Empty;
                }
            }
            else
            {
                divpackinglistlink.Visible = false;
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

    protected void btnRedirectToStockAdj_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/InventoryManagement/FrmStockInHandAdj.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered, tem a ver com obotão de exportação para excel*/
    }

    private void BindExportToExcelGrid()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 18;
            ObjBOL.ContainerID = Convert.ToInt32(ddlContainerLookup.SelectedValue);
            //ObjBOL.PartID = Convert.ToInt32(ddlPartNo.SelectedValue);
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvAddParts.DataSource = ds.Tables[0];
                gvAddParts.DataBind();
                string fileName = ddlContainerLookup.SelectedItem.Text + "_" + "NegativeStockAdjustment";
                Utility.ExportToExcelGrid(gvAddParts, fileName);
            }
            else
            {
                gvAddParts.DataSource = "";
                gvAddParts.DataBind();
                Utility.ShowMessage_Error(Page, "Negative Stock in Hand Items Not Found !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void btnExportNegativeStock_Click(object sender, EventArgs e)
    {
        try
        {
            BindExportToExcelGrid();            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

}