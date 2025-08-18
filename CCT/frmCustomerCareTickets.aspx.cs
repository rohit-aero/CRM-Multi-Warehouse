using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

public partial class CCT_frmCustomerCareTickets : System.Web.UI.Page
{
    BOLCustCareTickets ObjBOL = new BOLCustCareTickets();
    BLLCustCareTickets ObjBLL = new BLLCustCareTickets();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    commonclass1 cls = new commonclass1();
    string defval = "0";
    string saveFolder = string.Empty;
    public static readonly List<string> Extensions = new List<string> { "pdf", "doc" };
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            GetFilePaths();
            if (!IsPostBack)
            {
                Bind_Controls();
                EmptyDTSummary();
                btnGenerateRepairSchedule.Enabled = false;
                btnPreview.Enabled = false;
                btnPDF.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetFilePaths()
    {
        try
        {
            saveFolder = Utility.CustCareTicketPath();
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
            dtEmpty.TableName = "GridSummary";
            dtEmpty.Columns.Add(new DataColumn("TicketID", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("SummaryDate", typeof(DateTime)));
            dtEmpty.Columns.Add(new DataColumn("Summary", typeof(string)));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);//adding row to the datatable
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    private DataTable EmptyDTSummary()
    {
        DataTable dt = new DataTable();
        try
        {
            //DataRow dr;
            ViewState["Summary"] = null;
            dt.TableName = "Summary";
            //TicketID   
            dt.Columns.Add(new DataColumn("TicketID", typeof(int)));
            dt.Columns.Add(new DataColumn("SummaryDate", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("Summary", typeof(string)));
            ViewState["Summary"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void PrePareDT(int TicketID, DateTime? SummaryDate, string Summary)
    {
        try
        {
            DataTable dtCurrentTable = (DataTable)ViewState["Summary"];
            DataRow drCurrentRow = null;
            drCurrentRow = dtCurrentTable.NewRow();
            drCurrentRow["TicketID"] = TicketID;
            drCurrentRow["summarydate"] = SummaryDate;
            drCurrentRow["summary"] = Summary;
            dtCurrentTable.AcceptChanges();
            dtCurrentTable.Rows.Add(drCurrentRow);
            DataTable dt = (DataTable)ViewState["Summary"];
            BindSummaryTemp(dtCurrentTable);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //List all Drop Downs in Page
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlJobNo, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCategory, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlIssueCategory, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlStatus, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSubAssembly, ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlIssueReportedBy, ds.Tables[5]);
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlAssignedto, ds.Tables[6]);
            }
            if (ds.Tables[10].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlTechnician_1, ds.Tables[10]);
                Utility.BindDropDownList(ddlTechnician_2, ds.Tables[10]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //New Ticket Generate
    private void GenerateTicket()
    {
        try
        {
            string TicketNum = "";
            ObjBOL.Operation = 2;
            ObjBOL.TJobID = ddlJobNo.SelectedValue;
            TicketNum = ObjBLL.GetTicketNo(ObjBOL);
            if (TicketNum != "")
            {
                txtTicketno.Text = TicketNum;
            }
            else
            {
                txtTicketno.Text = String.Empty;
            }
            Reset();
            ddlTicketNo.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //New Ticket Generate
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            GenerateTicket();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void lnkDowload_Click(object sender, EventArgs e)
    {
        try
        {
            string folderPath = hfFileAddress.Value;
            string extension = hfFileAddress.Value.Split('.')[1];
            //string filePath = Server.MapPath(folderPath);
            string filePath = folderPath;
            FileInfo file = new FileInfo(saveFolder + filePath);
            if (file.Exists)
            {
                if (file.Exists)
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
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Save()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = "";
                if (btnSave.Text.ToLower() == "save")
                {
                    ObjBOL.Operation = 14;
                }
                else if (btnSave.Text.ToLower() == "update")
                {
                    ObjBOL.Operation = 13;
                }
                ObjBOL.TJobID = ddlJobNo.SelectedValue;
                ObjBOL.TicketNo = txtTicketno.Text;
                ObjBOL.Category = Convert.ToInt32(ddlCategory.SelectedValue);
                ObjBOL.CategoryOther = txtCategoryOther.Text;
                ObjBOL.Task = txtTask.Text;
                ObjBOL.IssueCategory = ddlIssueCategory.SelectedValue;
                ObjBOL.IssueCategoryOther = txtIssueCategoryOther.Text;
                if (txtOpenDate.Text != "")
                {
                    ObjBOL.OpenDate = Utility.ConvertDate(txtOpenDate.Text);
                }
                if (txtIssueClosedDate.Text != "")
                {
                    ObjBOL.IssueClosedDate = Utility.ConvertDate(txtIssueClosedDate.Text);
                }
                ObjBOL.SubAssemblyID = Convert.ToInt32(ddlSubAssembly.SelectedValue);
                ObjBOL.SubAssemblyOther = txtSubAssemblyOther.Text;
                ObjBOL.IssueReportedBy = Convert.ToInt32(ddlIssueReportedBy.SelectedValue);
                ObjBOL.Solution = txtSolution.Text;
                ObjBOL.Status = Convert.ToInt32(ddlStatus.SelectedValue);
                ObjBOL.AssignedTo = Convert.ToInt32(ddlAssignedto.SelectedValue);
                ObjBOL.ServicePO = txtServicePONo.Text;
                ObjBOL.FollowUpDate = Utility.ConvertDate(txtFollowUpDate.Text);
                if (ddlTicketNo.SelectedIndex > 0)
                {
                    ObjBOL.TicketID = Convert.ToInt32(ddlTicketNo.SelectedValue);
                }
                if (txtTotalCost.Text != "")
                {
                    ObjBOL.TotalCost = Convert.ToDecimal(txtTotalCost.Text);
                }
                ObjBOL.InvoiceDate = Utility.ConvertDate(txtInvoiceDate.Text);
                ObjBOL.InvoiceNo = txtInvoiceNo.Text;
                ObjBOL.PCS = txtPCS.Text;
                if (ddlTechnician_1.SelectedIndex > 0)
                {
                    ObjBOL.Technician_1 = Int32.Parse(ddlTechnician_1.SelectedValue);
                }

                if (ddlTechnician_2.SelectedIndex > 0)
                {
                    ObjBOL.Technician_2 = Int32.Parse(ddlTechnician_2.SelectedValue);
                }
                ObjBOL.OtherContacts = txtOtherContact.Text;
                ObjBOL.SDT = txtSDT.Text;
                ObjBOL.WorkingWindow = txtWorkingWindow.Text;
                ObjBOL.QuoteNo = txtQuoteNo.Text;
                if(txtQuoteAmount.Text != "")
                {
                    ObjBOL.QuoteAmt = Convert.ToDecimal(txtQuoteAmount.Text);
                }                
                ObjBOL.PORecDate =Utility.ConvertDate(txtPOReceivedDate.Text);
                if (fpUploadFile.HasFile)
                {
                    //string folderPath = Server.MapPath(saveFolder);
                    string folderPath = saveFolder;
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string filename = fpUploadFile.FileName.Replace(",", "").Replace("'", "");
                    fpUploadFile.SaveAs(folderPath + fpUploadFile.FileName.Replace(",", "").Replace("'", ""));
                    ObjBOL.FileAddress = filename;
                }
                else
                {
                    ObjBOL.FileAddress = hfFileAddress.Value;
                }
                if (btnSave.Text == "Save")
                {
                    msg = ObjBLL.SaveCustTicketRecord(ObjBOL);
                    if (msg == Utility.UniqueConstraintErrorCode())
                    {
                        Utility.ShowMessage_Error(Page, "Ticket already exists !!");
                    }
                    else
                    {
                        Utility.ShowMessage_Success(this, "Records Inserted Successfully. !!");
                        if(txtTicketno.Text != "")
                        {
                            Utility.MaintainLogsSpecial("FrmCustomerCareTickets", "Insert", txtTicketno.Text);
                        }                        
                        btnGenerateRepairSchedule.Enabled = true;
                        btnPreview.Enabled = true;
                        btnPDF.Enabled = true;
                        hfFileAddress.Value = ObjBOL.FileAddress;
                        if (hfFileAddress.Value.Trim() == "")
                        {
                            lnkDowload.Visible = false;
                        }
                        else
                        {
                            lnkDowload.Visible = true;
                        }
                        btnSave.Text = "Update";
                    }
                }
                else if (btnSave.Text == "Update")
                {
                    msg = ObjBLL.SaveCustTicketRecord(ObjBOL);
                    if (msg.Trim().Length > 0)
                    {
                        Utility.ShowMessage_Success(this, "Records Updated Successfully. !!");
                        if (txtTicketno.Text != "")
                        {
                            Utility.MaintainLogsSpecial("FrmCustomerCareTickets", "Update", txtTicketno.Text);
                        }                           
                        hfFileAddress.Value = ObjBOL.FileAddress;
                        if (hfFileAddress.Value.Trim() == "")
                        {
                            lnkDowload.Visible = false;
                        }
                        else
                        {
                            lnkDowload.Visible = true;
                        }
                    }
                }

                if (msg != "")
                {
                    defval = msg;
                }
                BindTickets(Convert.ToInt32(defval));
                BindSummary();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Save/Update function for Both Ticket and SUmmary
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Save();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Ticket AutoBind Function in Drop Down List
    private void BindTickets(int TicketID)
    {
        try
        {
            EmptyDTSummary();
            BindSummary();
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ObjBOL.TJobID = ddlJobNo.SelectedValue;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlTicketNo, ds.Tables[0]);
                if (TicketID != 0)
                {
                    ddlTicketNo.SelectedValue = Convert.ToString(TicketID);
                }
            }
            else
            {
                ddlTicketNo.DataSource = "";
                ddlTicketNo.DataBind();
                ddlTicketNo.Items.Insert(0, new ListItem("Select", "0"));
                btnSave.Text = "Save";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Bind Model if Added in Database
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlJobNo.SelectedIndex > 0)
            {
                if (ValidationCheckJobID() == true)
                {
                    EmptyDTSummary();
                    btnNew.Enabled = true;
                    Reset();
                    txtTicketno.Text = String.Empty;
                    string ModelName = "";
                    ObjBOL.Operation = 4;
                    ObjBOL.TJobID = ddlJobNo.SelectedValue;
                    ModelName = ObjBLL.GetTicketNo(ObjBOL);
                    if (ModelName != "")
                    {
                        txtModel.Text = ModelName;
                    }
                    else
                    {
                        txtModel.Text = String.Empty;
                    }
                    BindTickets(Convert.ToInt32(defval));
                    BindSummary();
                }
            }
            else
            {
                btnCancel_Click_Event();
                ResetOthersTextBox();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetOthersTextBox()
    {
        try
        {
            CategoryOtherTextBox();
            IssueCategoryOtherTextBox();
            SubAssemblyOtherTextBox();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Boolean ValidationCheckJobID()
    {
        try
        {
            if (ddlJobNo.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Job ID. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Job ID. !");
                ddlJobNo.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    //Validation for Ticket Save or Update
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtTicketno.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Generate Ticket Number. !');", true);
                Utility.ShowMessage_Error(Page, "Please Generate Ticket Number. !");
                txtTicketno.Focus();
                return false;
            }
            if (txtTask.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Task. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Task. !");
                txtTask.Focus();
                return false;
            }
            if (ddlCategory.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Category. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Category. !");
                txtTicketno.Focus();
                return false;
            }
            if (txtOpenDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Open Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Open Date. !");
                txtOpenDate.Focus();
                return false;
            }
            if (ddlStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Status. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                ddlStatus.Focus();
                return false;
            }
            if (ddlIssueCategory.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Issue Category. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Issue Category. !");
                ddlIssueCategory.Focus();
                return false;
            }

            if (txtFollowUpDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Follow Up Date !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Follow Up Date !");
                txtFollowUpDate.Focus();
                return false;
            }
            if (ddlAssignedto.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Assigned to. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Assigned to. !");
                ddlAssignedto.Focus();
                return false;
            }
           

            if (fpUploadFile.HasFile)
            {
                if (!Extensions.Contains(fpUploadFile.FileName.Split('.')[1]))
                {
                    Utility.ShowMessage_Error(Page, "Only .pdf or .doc is allowed");
                    return false;
                }
                else
                {
                    int fileSize = fpUploadFile.PostedFile.ContentLength;
                    // Convert the bytes to Kilobytes (1 KB = 1024 Bytes)
                    double fileSizeInKB = fileSize / 1024.0;
                    if (fileSizeInKB > Utility.FileSizeLimits(fpUploadFile.FileName.Split('.')[1]))
                    {
                        Utility.ShowMessage_Error(Page, "File size exceeds " + Utility.FileSizeLimits(fpUploadFile.FileName.Split('.')[1]) + "KB. Please choose a smaller file. !!");
                        return false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private Boolean ValidationCheckSummary()
    {
        try
        {
            TextBox TicketSummaryDate = gvSummary.FooterRow.FindControl("txtfooterSummDate") as TextBox;
            if (TicketSummaryDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Summary Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Summary Date. !");
                TicketSummaryDate.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    //Reset all controls
    private void Reset()
    {
        try
        {
            ddlCategory.SelectedIndex = 0;
            txtTask.Text = String.Empty;
            ddlIssueCategory.SelectedIndex = 0;
            txtCategoryOther.Text = String.Empty;
            txtIssueCategoryOther.Text = String.Empty;
            txtOpenDate.Text = String.Empty;
            ddlSubAssembly.SelectedIndex = 0;
            txtSubAssemblyOther.Text = String.Empty;
            ddlIssueReportedBy.SelectedIndex = 0;
            txtSolution.Text = String.Empty;
            txtInvoiceNo.Text = String.Empty;
            txtInvoiceDate.Text = String.Empty;
            ddlStatus.SelectedIndex = 0;
            ddlAssignedto.SelectedIndex = 0;
            txtServicePONo.Text = String.Empty;
            txtIssueClosedDate.Text = String.Empty;
            txtTotalCost.Text = String.Empty;
            txtFollowUpDate.Text = String.Empty;
            txtPCS.Text = string.Empty;
            ddlTechnician_1.SelectedIndex = 0;
            ddlTechnician_2.SelectedIndex = 0;
            txtOtherContact.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtWorkingWindow.Text = string.Empty;
            btnSave.Text = "Save";
            gvSummary.DataSource = EmptyDT();
            gvSummary.DataBind();
            gvSummary.Rows[0].Visible = false;
            btnGenerateRepairSchedule.Enabled = false;
            btnPreview.Enabled = false;
            btnPDF.Enabled = false;
            hfFileAddress.Value = string.Empty;
            lnkDowload.Visible = false;
            txtQuoteNo.Text = String.Empty;
            txtQuoteAmount.Text = String.Empty;
            txtPOReceivedDate.Text = String.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel_Click_Event();
    }

    private void btnCancel_Click_Event()
    {
        try
        {
            txtTicketno.Text = String.Empty;
            txtModel.Text = String.Empty;
            ddlJobNo.SelectedIndex = 0;
            ddlTicketNo.DataSource = "";
            ddlTicketNo.DataBind();
            Reset();
            btnNew.Enabled = false;
            ResetOthersTextBox();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindSummaryTemp(DataTable dt)
    {
        try
        {
            DataTable DTSummary = dt;
            if (DTSummary.Rows.Count > 0)
            {
                gvSummary.DataSource = DTSummary;
                gvSummary.DataBind();
            }
            else
            {
                gvSummary.DataSource = EmptyDT();
                gvSummary.DataBind();
                gvSummary.Rows[0].Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindSummary()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 8;
            if (ddlTicketNo.SelectedIndex > 0)
            {
                ObjBOL.TicketID = Convert.ToInt32(ddlTicketNo.SelectedValue);
                ds = ObjBLL.GetControlsData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvSummary.DataSource = ds.Tables[0];
                    gvSummary.DataBind();
                }
                else
                {
                    gvSummary.DataSource = EmptyDT();
                    gvSummary.DataBind();
                    gvSummary.Rows[0].Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Fill Details from Ticket No
    protected void ddlTicketNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlTicketNo.SelectedIndex > 0)
            {
                btnGenerateRepairSchedule.Enabled = true;
                btnPreview.Enabled = true;
                btnPDF.Enabled = true;
                DataSet ds = new DataSet();
                ObjBOL.Operation = 6;
                ObjBOL.TicketNo = ddlTicketNo.SelectedItem.Text;
                ds = ObjBLL.GetControlsData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTicketno.Text = ds.Tables[0].Rows[0]["TicketNo"].ToString();
                    if(ddlCategory.Items.FindByValue(ds.Tables[0].Rows[0]["CategoryID"].ToString()) != null)
                    {
                        ddlCategory.SelectedValue = ds.Tables[0].Rows[0]["CategoryID"].ToString();
                        if (ddlCategory.SelectedValue == "3")
                        {
                            PanelCategoryOther.Attributes.Add("style", "display:block");
                            txtCategoryOther.Text = ds.Tables[0].Rows[0]["CategoryOther"].ToString();
                        }
                        else
                        {
                            PanelCategoryOther.Attributes.Add("style", "display:none");
                            txtCategoryOther.Text = String.Empty;
                        }
                    }                    
                    txtTask.Text = ds.Tables[0].Rows[0]["Task"].ToString();
                    if(ddlIssueCategory.Items.FindByValue(ds.Tables[0].Rows[0]["IssueCategoryID"].ToString()) != null)
                    {
                        ddlIssueCategory.SelectedValue = ds.Tables[0].Rows[0]["IssueCategoryID"].ToString();
                        if (ddlIssueCategory.SelectedValue == "14")
                        {
                            PanelIssueCategory.Attributes.Add("style", "display:block");
                            txtIssueCategoryOther.Text = ds.Tables[0].Rows[0]["IssueCategoryOther"].ToString();
                        }
                        else
                        {
                            PanelIssueCategory.Attributes.Add("style", "display:none");
                            txtIssueCategoryOther.Text = String.Empty;
                        }
                    }                    
                    txtOpenDate.Text = cls.Converter(ds.Tables[0].Rows[0]["OpenDate"].ToString());
                    if(ddlSubAssembly.Items.FindByValue(ds.Tables[0].Rows[0]["SubAssemblyID"].ToString()) != null)
                    {
                        ddlSubAssembly.SelectedValue = ds.Tables[0].Rows[0]["SubAssemblyID"].ToString();
                        if (ddlSubAssembly.SelectedValue == "18")
                        {
                            PanelSubAssemblyOther.Attributes.Add("style", "display:block");
                            txtSubAssemblyOther.Text = ds.Tables[0].Rows[0]["SubAssemblyOther"].ToString();
                        }
                        else
                        {
                            PanelSubAssemblyOther.Attributes.Add("style", "display:none");
                            txtSubAssemblyOther.Text = String.Empty;
                        }
                    }                    
                    ddlIssueReportedBy.SelectedValue = ds.Tables[0].Rows[0]["ReportedBy"].ToString();
                    txtSolution.Text = ds.Tables[0].Rows[0]["Solution"].ToString();
                    ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["StatusID"].ToString();
                    if (ddlAssignedto.Items.FindByValue(ds.Tables[0].Rows[0]["AssignedTo"].ToString()) != null)
                    {
                        ddlAssignedto.SelectedValue = ds.Tables[0].Rows[0]["AssignedTo"].ToString();
                    }
                    else
                    {
                        ddlAssignedto.SelectedIndex = 0;
                    }
                    txtFollowUpDate.Text = cls.Converter(ds.Tables[0].Rows[0]["FollowUpDate"].ToString());
                    txtServicePONo.Text = ds.Tables[0].Rows[0]["ServicePO"].ToString();
                    txtIssueClosedDate.Text = cls.Converter(ds.Tables[0].Rows[0]["CloseDate"].ToString());
                    txtTotalCost.Text = ds.Tables[0].Rows[0]["TotalCost"].ToString();
                    txtInvoiceDate.Text = cls.Converter(ds.Tables[0].Rows[0]["InvoiceDate"].ToString());
                    txtInvoiceNo.Text = ds.Tables[0].Rows[0]["InvoiceNo"].ToString();
                    txtPCS.Text = ds.Tables[0].Rows[0]["PointOfContactOnSite"].ToString();
                    if (ddlTechnician_1.Items.FindByValue(ds.Tables[0].Rows[0]["Technician_1"].ToString().Trim()) != null)
                    {
                        ddlTechnician_1.SelectedValue = ds.Tables[0].Rows[0]["Technician_1"].ToString();
                    }
                    if (ddlTechnician_2.Items.FindByValue(ds.Tables[0].Rows[0]["Technician_2"].ToString().Trim()) != null)
                    {
                        ddlTechnician_2.SelectedValue = ds.Tables[0].Rows[0]["Technician_2"].ToString();
                    }
                    txtOtherContact.Text = ds.Tables[0].Rows[0]["OtherContacts"].ToString();
                    txtSDT.Text = ds.Tables[0].Rows[0]["StartDateAndTime"].ToString();
                    txtWorkingWindow.Text = ds.Tables[0].Rows[0]["WorkingWindow"].ToString();
                    txtQuoteNo.Text= ds.Tables[0].Rows[0]["QuoteNo"].ToString();
                    txtQuoteAmount.Text= ds.Tables[0].Rows[0]["QuoteAmount"].ToString();
                    txtPOReceivedDate.Text= ds.Tables[0].Rows[0]["POReceivedDate"].ToString();
                    if (ds.Tables[0].Rows[0]["FileAddress"].ToString() != "")
                    {
                        FileInfo file = new FileInfo(saveFolder + ds.Tables[0].Rows[0]["FileAddress"].ToString());
                        if (file.Exists)
                        {
                            hfFileAddress.Value = ds.Tables[0].Rows[0]["FileAddress"].ToString();
                            lnkDowload.Visible = true;
                        }
                        else
                        {
                            hfFileAddress.Value = string.Empty;
                            lnkDowload.Visible = false;
                        }
                    }
                    else
                    {
                        hfFileAddress.Value = string.Empty;
                        lnkDowload.Visible = false;
                    }
                    btnSave.Text = "Update";
                    BindSummary();
                }
            }
            else
            {
                string temp = ddlJobNo.SelectedValue;
                txtTicketno.Text = String.Empty;
                txtModel.Text = String.Empty;
                Reset();
                btnGenerateRepairSchedule.Enabled = false;
                btnPreview.Enabled = false;
                btnPDF.Enabled = false;
                ddlJobNo.SelectedValue = temp;
                gvSummary.DataSource = EmptyDT();
                gvSummary.DataBind();
                gvSummary.Rows[0].Visible = false;
                ResetOthersTextBox();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //GVSummary Editing
    protected void gvSummary_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvSummary.EditIndex = e.NewEditIndex;
            BindSummary();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //GVSummary Cancel
    protected void gvSummary_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvSummary.EditIndex = -1;
            BindSummary();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //GVSummary Update
    protected void gvSummary_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {            
            string msg = "";
            int ID = Convert.ToInt32(gvSummary.DataKeys[e.RowIndex].Value);
            ObjBOL.Operation = 9;
            ObjBOL.TicketID = ID;
            GridViewRow row = gvSummary.Rows[e.RowIndex];
            int rowid = row.RowIndex;
            TextBox txtgvSummDate = row.FindControl("txtgvSummDate") as TextBox;
            TextBox txtgvSumm = row.FindControl("txtgvSumm") as TextBox;
            ObjBOL.SummaryDate = Utility.ConvertDate(txtgvSummDate.Text);
            ObjBOL.Summary = txtgvSumm.Text;
            msg = ObjBLL.SaveCustTicketSumm(ObjBOL);
            if (msg.Trim() != "")
            {
                Utility.ShowMessage_Success(this, msg);
                if(txtTicketno.Text != "")
                {
                    Utility.MaintainLogsSpecial("FrmCustomerCareTickets", "Update-Summary", txtTicketno.Text);
                }                
                gvSummary.EditIndex = -1;
                BindSummary();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CategoryOtherTextBox()
    {
        try
        {
            if (ddlCategory.SelectedValue == "3")
            {
                PanelCategoryOther.Attributes.Add("style", "display:block");
            }
            else
            {
                PanelCategoryOther.Attributes.Add("style", "display:none");
                txtCategoryOther.Text = String.Empty;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Other Text Box Display/Hidden
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CategoryOtherTextBox();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void IssueCategoryOtherTextBox()
    {
        try
        {
            if (ddlIssueCategory.SelectedValue == "14")
            {
                PanelIssueCategory.Attributes.Add("style", "display:block");
            }
            else
            {
                PanelIssueCategory.Attributes.Add("style", "display:none");
                txtIssueCategoryOther.Text = String.Empty;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Other Text Box Display/Hidden
    protected void ddlIssueCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            IssueCategoryOtherTextBox();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SubAssemblyOtherTextBox()
    {
        try
        {
            if (ddlSubAssembly.SelectedValue == "18")
            {
                PanelSubAssemblyOther.Attributes.Add("style", "display:block");
            }
            else
            {
                PanelSubAssemblyOther.Attributes.Add("style", "display:none");
                txtSubAssemblyOther.Text = String.Empty;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Other Text Box Display/Hidden
    protected void ddlSubAssembly_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SubAssemblyOtherTextBox();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SummaryAdd()
    {
        try
        {
            if (ddlTicketNo.SelectedIndex > 0)
            {
                if (ValidationCheckSummary() == true)
                {
                    TextBox txtSummaryDate = gvSummary.FooterRow.FindControl("txtfooterSummDate") as TextBox;
                    TextBox txtSumm = gvSummary.FooterRow.FindControl("txtFootSumm") as TextBox;
                    string SummaryDate = txtSummaryDate.Text;
                    string Summary = txtSumm.Text;

                    ObjBOL.Operation = 7;
                    ObjBOL.TicketID = Int32.Parse(ddlTicketNo.SelectedValue);
                    ObjBOL.SummaryDate = Utility.ConvertDate(SummaryDate);
                    ObjBOL.Summary = Summary;
                    string msg = string.Empty;
                    msg = ObjBLL.SaveCustTicketSumm(ObjBOL);
                    if (msg.Trim() != "")
                    {
                        Utility.ShowMessage_Success(this, msg);
                        if (txtTicketno.Text != "")
                        {
                            Utility.MaintainLogsSpecial("FrmCustomerCareTickets", "Insert-Summary", txtTicketno.Text);
                        }                            
                        BindSummary();
                        txtSummaryDate.Text = String.Empty;
                        txtSumm.Text = String.Empty;
                    }
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please Save Ticket First!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            SummaryAdd();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSummary_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 10;
            GridViewRow row = gvSummary.Rows[e.RowIndex];
            Int32 ID = Convert.ToInt32(gvSummary.DataKeys[e.RowIndex].Value);
            ObjBOL.TicketID = ID;
            msg = ObjBLL.DeleteCustTicketSumm(ObjBOL);
            if (msg.Trim() != "")
            {
                if(txtTicketno.Text != "")
                {
                    Utility.MaintainLogsSpecial("FrmCustomerCareTickets", "Delete-Summary", txtTicketno.Text);
                }                
                Utility.ShowMessage_Success(this, "Record Deleted Successfully !!");
                BindSummary();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable ReportDataZero()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[Get_CCT_TicketDetails] '" + ddlTicketNo.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataZero();
            rprt.Load(Server.MapPath("~/Reports/rptCustCareTicketDetails.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Aerowerks Ticket Details";
                rprt.SetDataSource(dt);
                //rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false,txtheader.Text);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, false, txtheader.Text);
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

    protected void btnReports_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Reports/frmCustomerCareTickets.aspx");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnPDF_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataZero();
            rprt.Load(Server.MapPath("~/Reports/rptCustCareTicketDetails.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Aerowerks Ticket Details";
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                //rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, false, txtheader.Text);
                rprt.Close();
                rprt.Dispose();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable ReportDataRepairSchedule()
    {
        DataTable dt = new DataTable();
        try
        {
            if (ddlJobNo.SelectedIndex > 0)
            {
                clscon.Return_DT(dt, "EXEC [dbo].[aero_ManageCustCareTickets] 11, null, '" + ddlJobNo.SelectedValue + "', '" + ddlTicketNo.SelectedItem.Text.Trim() + "'");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable SubReportDataRepairSchedule()
    {
        DataTable dt = new DataTable();
        try
        {
            if (ddlJobNo.SelectedIndex > 0)
            {
                clscon.Return_DT(dt, "EXEC [dbo].[aero_ManageCustCareTickets] 12, null, '" + ddlJobNo.SelectedValue + "', '" + ddlTicketNo.SelectedItem.Text.Trim() + "'");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnGenerateRepairSchedule_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt = ReportDataRepairSchedule();
            dt1 = SubReportDataRepairSchedule();
            rprt.Load(Server.MapPath("~/Reports/rptRepairSchedule.rpt"));
            if (dt.Rows.Count > 0)
            {
                rprt.SetDataSource(dt);
                rprt.Subreports[0].SetDataSource(dt1);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Repair Schedule");
                //rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, false, txtheader.Text);
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

    protected void ddlTechnician_1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlTechnician_1.SelectedValue == ddlTechnician_2.SelectedValue)
            {
                ResetDropDownList(ddlTechnician_1);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlTechnician_2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlTechnician_1.SelectedValue == ddlTechnician_2.SelectedValue)
            {
                ResetDropDownList(ddlTechnician_2);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ResetDropDownList(DropDownList ddl)
    {
        try
        {
            if (ddl != null)
            {
                ddl.SelectedIndex = 0;
                Utility.ShowMessage_Error(Page, "Technician 1 and Technician 2 cannot be same!!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}