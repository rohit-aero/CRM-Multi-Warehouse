using BLLAERO;
using BOLAERO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PMModule_PreventativeMaintenanceCallLogs : System.Web.UI.Page
{
    BOLPreventativeMaintenanceCallLogs ObjBOL = new BOLPreventativeMaintenanceCallLogs();
    BLLPreventativeMaintenanceCallLogs ObjBLL = new BLLPreventativeMaintenanceCallLogs();

    BOLManageCustomerMember ObjBOLMember = new BOLManageCustomerMember();
    BLLManageCustomerMember ObjBLLMember = new BLLManageCustomerMember();

    commonclass1 cls = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                SetDates();
                if (Request.QueryString["JobId"] != null)
                {
                    var JNumber = Request.QueryString["JobId"];
                    SyncTextbox("NUM", JNumber);
                    SyncTextbox("NAME", JNumber);
                    HfJObID.Value = JNumber;
                }
            }
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
                HfJObID.Value = output;
                SyncTextbox("NUM", output);
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
            if (txtSearchPNum.Text.Length >= 7)
            {
                string OutJnumber = string.Empty;
                int index = txtSearchPNum.Text.IndexOf(',');
                if (txtSearchPNum.Text.Length > 7)
                {
                    if (index != -1)
                    {
                        OutJnumber = txtSearchPNum.Text.Substring(0, txtSearchPNum.Text.IndexOf(','));
                    }
                }
                else
                {
                    OutJnumber = txtSearchPNum.Text;
                }
                HfJObID.Value = OutJnumber;
                SyncTextbox("NAME", OutJnumber);
                return;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
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
                    dt = Utility.ReturnProjects(26, text);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchPNum.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                    }
                    else
                    {
                        txtSearchPNum.Text = "";
                        txtSearchPName.Text = "";
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
                        Utility.ShowMessage_Error(Page, "J# not Found");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SetDates()
    {
        try
        {
            txtWarrantyEndDateFrom.Text = "01/01/" + DateTime.Now.Year;
            txtWarrantyEndDateTo.Text = DateTime.Now.ToShortDateString();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationCheck()
    {
        try
        {
            if (txtWarrantyEndDateFrom.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter From Date !");
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private bool ValidationCheckForCallHistory()
    {
        try
        {
            if (txtDateCalled.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Date Called !");
                txtDateCalled.Focus();
                modalForJob.Show();
                return false;
            }

            //if (txtContact.Text == "")
            //{
            //    Utility.ShowMessage_Error(Page, "Please enter Contact Name !");
            //    txtContact.Focus();
            //    modalForJob.Show();
            //    return false;
            //}

            if (ddlContactName.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Contact Name !");
                ddlContactName.Focus();
                modalForJob.Show();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private DataTable BindEmptyContact()
    {
        DataTable dtEmpty = new DataTable();
        try
        {
            dtEmpty.Columns.Add("ContactID", typeof(int));
            dtEmpty.Columns.Add("ContactName", typeof(string));
            dtEmpty.Columns.Add("FirstName", typeof(string));
            dtEmpty.Columns.Add("LastName", typeof(string));
            dtEmpty.Columns.Add("Title", typeof(string));
            dtEmpty.Columns.Add("Phone", typeof(string));
            dtEmpty.Columns.Add("OfficePhone", typeof(string));
            dtEmpty.Columns.Add("Email", typeof(string));
            dtEmpty.Columns.Add("ReferenceContact", typeof(bool), "false");
            dtEmpty.Columns.Add("MainContact", typeof(bool), "false");
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    protected void gvWarrantyEndJobs_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Select")
            {
                GridViewRow clickedRow = gvWarrantyEndJobs.Rows[Convert.ToInt32(e.CommandArgument)];
                Label lblJobID = (Label)clickedRow.FindControl("lblJobID");
                Label lblCompanyName = (Label)clickedRow.FindControl("lblCompanyName");
                Label lblCity = (Label)clickedRow.FindControl("lblCity");
                Label lblState = (Label)clickedRow.FindControl("lblState");
                Label lblWarrantyEndDate = (Label)clickedRow.FindControl("lblWarrantyEndDate");
                string var1 = lblJobID.Text;
                string var2 = lblCompanyName.Text;
                string var3 = lblCity.Text;
                string var4 = lblState.Text;
                string title = (var1 ?? "") + (var2 != "" ? ", " + var2 : "") + (var3 != "" ? ", " + var3 : "") + (var4 != "" ? ", " + var4 : "");
                LoadModal(lblJobID.Text);
                SetTitle(title, lblWarrantyEndDate.Text);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvWarrantyEndJobs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string lastCallDate = DataBinder.Eval(e.Row.DataItem, "LastCallDate") as string;

                if (!string.IsNullOrEmpty(lastCallDate))
                {
                    e.Row.Attributes.Add("style", "background-color: #d4edda !important; color: black !important;");
                }
                else
                {
                    e.Row.Attributes.Add("style", "color: black !important;");
                }

                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.cursor = 'Pointer'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.ToolTip = "Click to Add/View Call Logs";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvWarrantyEndJobs, "Select$" + e.Row.RowIndex);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvWarrantyEndJobs_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                DataView dataView = new DataView(dtrslt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvWarrantyEndJobs.DataSource = dataView;
                gvWarrantyEndJobs.DataBind();
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + "DESC";
                gvWarrantyEndJobs.DataSource = dtrslt;
                gvWarrantyEndJobs.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    protected void gvJobContacts_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Insert")
            {
                TextBox FooterFirstName = gvJobContacts.FooterRow.FindControl("txtFooterFirstName") as TextBox;
                TextBox FooterLastName = gvJobContacts.FooterRow.FindControl("txtFooterLastName") as TextBox;
                TextBox FooterTitle = gvJobContacts.FooterRow.FindControl("txtFooterTitle") as TextBox;
                TextBox FooterOfficePhone = gvJobContacts.FooterRow.FindControl("txtFooterOfficePhone") as TextBox;
                TextBox FooterPhone = gvJobContacts.FooterRow.FindControl("txtFooterPhone") as TextBox;
                TextBox FooterEmail = gvJobContacts.FooterRow.FindControl("txtFooterEmail") as TextBox;
                CheckBox FooterRef = gvJobContacts.FooterRow.FindControl("chkFooterRef") as CheckBox;
                CheckBox FooterMain = gvJobContacts.FooterRow.FindControl("chkFooterMain") as CheckBox;
                if (FooterTitle.Text.Trim() == "")
                {
                    Utility.ShowMessage_Error(Page, "Please enter Position!");
                    FooterTitle.Focus();
                    modalForJob.Show();
                    return;
                }

                if (FooterFirstName.Text.Trim() == "")
                {
                    Utility.ShowMessage_Error(Page, "Please enter First Name!");
                    FooterFirstName.Focus();
                    modalForJob.Show();
                    return;
                }
                ObjBOLMember.Operation = 4;
                ObjBOLMember.CustomerID = (short)GetCustomerID();
                ObjBOLMember.Title = FooterTitle.Text;
                ObjBOLMember.FName = FooterFirstName.Text;
                ObjBOLMember.LName = FooterLastName.Text;
                ObjBOLMember.Phone = FooterPhone.Text;
                ObjBOLMember.OfficePhone = FooterOfficePhone.Text;
                ObjBOLMember.email = FooterEmail.Text;
                //if (FooterRef.Checked)
                //{
                //    ObjBOLMember.ReferenceContact = true;
                //}
                //else
                //{
                //    ObjBOLMember.ReferenceContact = false;
                //}
                //if (FooterMain.Checked)
                //{
                //    ObjBOLMember.MainContact = true;
                //}
                //else
                //{
                //    ObjBOLMember.MainContact = false;
                //}
                string returnValue = ObjBLLMember.SaveCustomerMember(ObjBOLMember);
                if (returnValue.Trim() != "")
                {
                    Utility.ShowMessage_Success(Page, returnValue);
                    Utility.MaintainLogsSpecial("PreventativeMaintenanceCallLogs", "Save-Contact", hfJobIDTitleInModal.Value.Trim());
                    ResetCallHistoryModal();
                    LoadModal(hfJobIDTitleInModal.Value.Trim());
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvJobContacts_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int ContactID = Convert.ToInt32(gvJobContacts.DataKeys[e.RowIndex].Values[0]);
            ObjBOLMember.Operation = 5;
            ObjBOLMember.ContactID = ContactID;
            ObjBOLMember.CustomerID = (short)GetCustomerID();
            string returnValue = "";
            returnValue = ObjBLLMember.DeleteCustomerMember(ObjBOLMember);
            if (returnValue.Trim() != "")
            {
                if (returnValue.Trim() == "1")
                {
                    Utility.ShowMessage_Error(Page, "Contact cannot be deleted with existing call logs");
                    modalForJob.Show();
                }
                else
                {
                    Utility.ShowMessage_Success(Page, returnValue);
                    Utility.MaintainLogsSpecial("PreventativeMaintenanceCallLogs", "delete-Contact", hfJobIDTitleInModal.Value.Trim());
                    ResetCallHistoryModal();
                    LoadModal(hfJobIDTitleInModal.Value.Trim());
                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvJobContacts_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            gvJobContacts.EditIndex = e.NewEditIndex;
            LoadModal(hfJobIDTitleInModal.Value.Trim());
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvJobContacts_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        try
        {
            gvJobContacts.EditIndex = -1;
            LoadModal(hfJobIDTitleInModal.Value.Trim());
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvJobContacts_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow row = gvJobContacts.Rows[e.RowIndex];
            ObjBOLMember.Operation = 6;
            ObjBOLMember.ContactID = Convert.ToInt32(gvJobContacts.DataKeys[e.RowIndex].Values[0]);
            TextBox txtTitle = (row.FindControl("txtTitle") as TextBox);
            ObjBOLMember.Title = txtTitle.Text;
            if (txtTitle.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Title. !");
                txtTitle.Focus();
                modalForJob.Show();
                return;
            }

            TextBox txtFName = (row.FindControl("txtFirstName") as TextBox);
            if (txtFName.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter First Name. !");
                txtFName.Focus();
                modalForJob.Show();
                return;
            }
            ObjBOLMember.FName = txtFName.Text;
            ObjBOLMember.LName = (row.FindControl("txtLastName") as TextBox).Text;
            ObjBOLMember.Phone = (row.FindControl("txtPhone") as TextBox).Text;
            ObjBOLMember.OfficePhone = (row.FindControl("txtOfficePhone") as TextBox).Text;
            ObjBOLMember.email = (row.FindControl("txtEmail") as TextBox).Text;
            CheckBox chkRefIn = (CheckBox)row.FindControl("chkRef");
            CheckBox chkMainIn = (CheckBox)row.FindControl("chkMain");
            //if (chkRefIn.Checked)
            //{
            //    ObjBOLMember.ReferenceContact = true;
            //}
            //else
            //{
            //    ObjBOLMember.ReferenceContact = false;
            //}
            //if (chkMainIn.Checked)
            //{
            //    ObjBOLMember.MainContact = true;
            //}
            //else
            //{
            //    ObjBOLMember.MainContact = false;
            //}
            string returnValue = "";
            returnValue = ObjBLLMember.UpdateCustomerMember(ObjBOLMember);
            gvJobContacts.EditIndex = -1;
            if (returnValue.Trim() != "")
            {
                Utility.ShowMessage_Success(Page, returnValue);
                Utility.MaintainLogsSpecial("PreventativeMaintenanceCallLogs", "update-Contact", hfJobIDTitleInModal.Value.Trim());
                ResetCallHistoryModal();
                LoadModal(hfJobIDTitleInModal.Value.Trim());
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnAddContactRedirect_Click(object sender, EventArgs e)
    {
        try
        {
            int customerID = GetCustomerID();
            if (customerID > 0)
            {
                Session["CustomerID"] = customerID;
                Session["JobID"] = hfJobIDTitleInModal.Value;
                Response.Redirect("~/ContactManagement/FrmCustomers.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    protected void gvCallHistory_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        try
        {
            int ID = Convert.ToInt32(gvCallHistory.DataKeys[e.RowIndex].Values[0]);
            ObjBOL.Operation = 4;
            ObjBOL.ID = ID;
            string returnValue = ObjBLL.Return_String(ObjBOL);
            if (returnValue.Trim() != "")
            {
                Utility.ShowMessage_Success(Page, returnValue);
                Utility.MaintainLogsSpecial("PreventativeMaintenanceCallLogs", "Delete", hfJobIDTitleInModal.Value.Trim());
                LoadModal(hfJobIDTitleInModal.Value.Trim());
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvCallHistory_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            modalForJob.Show();
            BindBothModalGridViews(true);
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ObjBOL.ID = Int32.Parse(gvCallHistory.DataKeys[e.NewEditIndex].Value.ToString());
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hfDetailID.Value = ds.Tables[0].Rows[0]["ID"].ToString();
                txtDateCalled.Text = ds.Tables[0].Rows[0]["DateCalled"].ToString();
                txtContact.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
                if (ddlContactName.Items.FindByValue(ds.Tables[0].Rows[0]["ContactID"].ToString()) != null)
                {
                    ddlContactName.SelectedValue = ds.Tables[0].Rows[0]["ContactID"].ToString();
                }
                txtCallDetails.Text = ds.Tables[0].Rows[0]["CallDetails"].ToString();
                txtNotes.Text = ds.Tables[0].Rows[0]["Notes"].ToString();
                rdbPMResponse.SelectedValue = ds.Tables[0].Rows[0]["PMResponse"].ToString();
                btnSave.Text = "Update";
            }
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
            Utility.ExportToExcelGrid(gvWarrantyEndJobs, "WarrantyEndJobs");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnReportRedirect_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Reports/PreventativeMaintenanceCallLogsReport.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered (used for export to excel)*/
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            SetDates();
            //ddlJobID.SelectedIndex = 0;
            HfJObID.Value = "";
            txtSearchPNum.Text = "";
            txtSearchPName.Text = "";
            //ddlCustomer.SelectedIndex = 0;
            gvWarrantyEndJobs.DataSource = string.Empty;
            gvWarrantyEndJobs.DataBind();
            lblRecordsCount.Text = string.Empty;
            lblRecordsCount.Visible = false;
            btnExportToExcel.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ResetCallHistoryForm();
            ResetContactFooter();
            modalForJob.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            btnShow_Click_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheckForCallHistory())
            {
                ObjBOL.JobID = hfJobIDTitleInModal.Value.Trim();
                ObjBOL.DateCalled = Utility.ConvertDate(txtDateCalled.Text);
                ObjBOL.ContactID = Int32.Parse(ddlContactName.SelectedValue);
                ObjBOL.Contact = ddlContactName.SelectedItem.Text;
                ObjBOL.CallDetails = txtCallDetails.Text;
                ObjBOL.Notes = txtNotes.Text;
                ObjBOL.PMResponse = rdbPMResponse.SelectedValue.Equals("1") ? true : false;
                if (btnSave.Text == "Save")
                {
                    ObjBOL.Operation = 3;
                }
                else if (btnSave.Text == "Update")
                {
                    ObjBOL.Operation = 6;
                    ObjBOL.ID = Int32.Parse(hfDetailID.Value);
                }
                string returnValue = ObjBLL.Return_String(ObjBOL);
                if (returnValue.Trim() != "")
                {
                    Utility.ShowMessage_Success(Page, returnValue);
                    Utility.MaintainLogsSpecial("PreventativeMaintenanceCallLogs", btnSave.Text, hfJobIDTitleInModal.Value.Trim());
                    ResetCallHistoryModal();
                    LoadModal(hfJobIDTitleInModal.Value.Trim());
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ResetCallHistoryModal();
            modalForJob.Hide();
            btnShow_Click_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "DESC"; }
        set { ViewState["SortDirection"] = value; }
    }

    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        switch (GridViewSortDirection)
        {
            case "ASC":
                GridViewSortDirection = "DESC";
                break;

            case "DESC":
                GridViewSortDirection = "ASC";
                break;
        }
        return GridViewSortDirection;
    }

    private void btnShow_Click_Event()
    {
        try
        {
            if (ValidationCheck())
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 1;
                ObjBOL.WarrantyEndFromDate = Utility.ConvertDate(txtWarrantyEndDateFrom.Text);
                if (txtWarrantyEndDateTo.Text == "")
                {
                    txtWarrantyEndDateTo.Text = DateTime.Now.ToShortDateString();
                }
                ObjBOL.WarrantyEndToDate = Utility.ConvertDate(txtWarrantyEndDateTo.Text);
                //if (ddlJobID.SelectedIndex > 0)
                //{
                //    ObjBOL.JobID = ddlJobID.SelectedValue;
                //}
                if (HfJObID.Value.Length > 0)
                {
                    ObjBOL.JobID = HfJObID.Value;
                }
                //if (ddlCustomer.SelectedIndex > 0)
                //{
                //    ObjBOL.ContactID = Int32.Parse(ddlCustomer.SelectedValue);
                //}
                ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvWarrantyEndJobs.DataSource = ds.Tables[0];
                    gvWarrantyEndJobs.DataBind();
                    ViewState["dirState"] = ds.Tables[0];
                    lblRecordsCount.Text = "Total No. of Records:" + ds.Tables[0].Rows.Count.ToString() + ". Click on any row to add/view call logs";
                    lblRecordsCount.Visible = true;
                    btnExportToExcel.Enabled = true;
                }
                else
                {
                    gvWarrantyEndJobs.DataSource = string.Empty;
                    gvWarrantyEndJobs.DataBind();
                    lblRecordsCount.Text = "No Record Found. Click on any row to add/view call logs";
                    lblRecordsCount.Visible = true;
                    btnExportToExcel.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private int GetCustomerID()
    {
        try
        {
            var query = "SELECT tblProjects.CustomerID FROM tblProjects WHERE JobID ='" + hfJobIDTitleInModal.Value + "'";
            var customerID = cls.Return_Int(query);
            return customerID;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return 0;
    }

    private void SetTitle(string Title, string date)
    {
        try
        {
            lblJobIDTitleInModal.Text = Title;
            lblWarrantyEndDate.Text = date;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void LoadModal(string jobID)
    {
        try
        {
            if (jobID.Trim() != "")
            {
                hfJobIDTitleInModal.Value = jobID;
                BindBothModalGridViews(false);
                modalForJob.Show();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindBothModalGridViews(bool LoadCallHistoryOnly)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.JobID = hfJobIDTitleInModal.Value;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (!LoadCallHistoryOnly)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvJobContacts.DataSource = ds.Tables[0];
                    gvJobContacts.DataBind();
                    //gvJobContacts.Rows[0].Visible = false;
                    EnableSaveFeature();
                }
                else
                {
                    gvJobContacts.DataSource = BindEmptyContact();
                    gvJobContacts.DataBind();
                    gvJobContacts.Rows[0].Visible = false;
                    DisableSaveFeature();
                }
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                gvCallHistory.DataSource = ds.Tables[1];
                gvCallHistory.DataBind();
            }
            else
            {
                gvCallHistory.DataSource = string.Empty;
                gvCallHistory.DataBind();
            }

            //BIND CONTACTNAME DROPDOWN
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlContactName, ds.Tables[0]);
                ddlContactName.SelectedIndex = 0;
            }
            else
            {
                ddlContactName.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableSaveFeature()
    {
        try
        {
            btnSave.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableSaveFeature()
    {
        try
        {
            btnSave.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetCallHistoryModal()
    {
        try
        {
            ResetCallHistoryForm();
            gvCallHistory.DataSource = string.Empty;
            gvCallHistory.DataBind();
            gvJobContacts.DataSource = string.Empty;
            gvJobContacts.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetCallHistoryForm()
    {
        try
        {
            txtDateCalled.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtCallDetails.Text = string.Empty;
            txtNotes.Text = string.Empty;
            rdbPMResponse.SelectedValue = "1";
            hfDetailID.Value = string.Empty;
            if (ddlContactName.Items.Count > 0)
            {
                ddlContactName.SelectedIndex = 0;
            }
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetContactFooter()
    {
        try
        {
            TextBox FooterTitle = gvJobContacts.FooterRow.FindControl("txtFooterTitle") as TextBox;
            TextBox FooterFirstName = gvJobContacts.FooterRow.FindControl("txtFooterFirstName") as TextBox;
            TextBox FooterLastName = gvJobContacts.FooterRow.FindControl("txtFooterLastName") as TextBox;
            TextBox FooterOfficePhone = gvJobContacts.FooterRow.FindControl("txtFooterOfficePhone") as TextBox;
            TextBox FooterPhone = gvJobContacts.FooterRow.FindControl("txtFooterPhone") as TextBox;
            TextBox FooterEmail = gvJobContacts.FooterRow.FindControl("txtFooterEmail") as TextBox;

            FooterTitle.Text = string.Empty;
            FooterFirstName.Text = string.Empty;
            FooterLastName.Text = string.Empty;
            FooterOfficePhone.Text = string.Empty;
            FooterPhone.Text = string.Empty;
            FooterEmail.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}