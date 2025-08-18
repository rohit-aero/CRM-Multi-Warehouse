using System;
using BOLAERO;
using BLLAERO;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class CCT_frmPreventiveMaintenance : System.Web.UI.Page
{
    BOLPreventiveMaintenance ObjBOL = new BOLPreventiveMaintenance();
    BLLPreventiveMaintenance ObjBLL = new BLLPreventiveMaintenance();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                txtOrderNo.Enabled = false;
                BindControls();
                ddlOrderNoHeaderList.Enabled = false;
                if (Request.QueryString["JobId"] != null)
                {
                    var JNumber = Request.QueryString["JobId"];
                    if (ddlJobHeaderList.Items.FindByValue(JNumber) != null)
                    {
                        ddlJobHeaderList.SelectedValue = JNumber;
                        ddlJobHeaderList_SelectedIndexChanged();
                    }
                    else
                    {
                        Utility.ShowMessage_Error(Page, "Job Not present !");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #region Button Enabled Disabled

    private void EnabledButton()
    {
        try
        {
            btnAddNew.Enabled = true;
            btnPDF.Enabled = true;
            btnGenQuote.Enabled = true;
            btnGenQuotePdf.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisabledButton()
    {
        try
        {
            DisableAddNew();
            DisablePdfButton();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisablePdfButton()
    {
        try
        {
            btnPDF.Enabled = false;
            btnGenQuote.Enabled = false;
            btnGenQuotePdf.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableAddNew()
    {
        try
        {
            btnAddNew.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Bind Functions

    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlJobHeaderList, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlStatus, ds.Tables[1]);
            }
            //int year = Convert.ToInt32(DateTime.Now.Year.ToString());
            //DataTable yearList = new DataTable();
            //yearList.Columns.Add("Year", typeof(string));
            //for (var i = year; i >= year - 3; i--)
            //{
            //    DataRow row = yearList.NewRow();
            //    row["Year"] = i;
            //    yearList.Rows.Add(row);
            //}
            //Utility.BindDropDownList(ddlYearHeaderList, yearList);
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void BindEntryFields(Int32 id)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            ObjBOL.ID = id;
            ds = ObjBLL.GetInformation(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                txtOrderNo.Text = row["OrderNo"].ToString();
                ddlStatus.SelectedValue = row["StatusID"].ToString();
                txtAttention.Text = row["Attention"].ToString();
                txtQuoteSentDate.Text = row["QuoteSentDate"].ToString();
                txtQuoteAmount.Text = row["QuoteAmount"].ToString();
                txtQuoteDetails.Text = row["QuoteDetails"].ToString();
                txtPONumber.Text = row["PONumber"].ToString();
                txtPORecDate.Text = row["PORecDate"].ToString();
                txtContractStartDate.Text = row["ContractStartDate"].ToString();
                txtContractEndDate.Text = row["ContractEndDate"].ToString();
                txtLastTuneUpDate.Text = row["LastTuneDate"].ToString();
                txtNextTuneUpDate.Text = row["NextTuneDate"].ToString();
                txtInvoiceDate.Text = row["InvoiceDate"].ToString();
                txtInvoiceNo.Text = row["InvoiceNo"].ToString();
                txtFollowUpDate.Text = row["FollowUpDate"].ToString();
                txtRemarks.Text = row["Remarks"].ToString();
                HiddenID.Value = id.ToString();
                gvPreventiveMaintenance.Visible = true;
                GridDiv.Visible = true;
                btnSave.Text = "Update";
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region validation

    private Boolean ValidationCheck()
    {
        try
        {
            if (txtOrderNo.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Order No. !');", true);
                Utility.ShowMessage_Error(Page, "Please Generate Contract # !");
                txtOrderNo.Focus();
                return false;
            }

            if (ddlJobHeaderList.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select JobID. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select JobID. !");
                ddlJobHeaderList.Focus();
                return false;
            }

            if (ddlStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Status. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                ddlStatus.Focus();
                return false;
            }
            //if (ddlCategory.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Category. !');", true);
            //    ddlCategory.Focus();
            //    return false;
            //}
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        return true;
    }

    private Boolean ValidationCheckAdd()
    {
        try
        {
            if (ddlJobHeaderList.SelectedIndex < 1)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select JobID. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select JobID. !");
                ddlJobHeaderList.Focus();
                return false;
            }

        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        return true;
    }

    private Boolean ValidationCheckGrid()
    {
        try
        {
            TextBox Date = gvPreventiveMaintenance.FooterRow.FindControl("txtfooterPreventiveMaintenanceDate") as TextBox;
            if (Date.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Date. !");
                Date.Focus();
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

    #region DataTable Functions

    private void InitiateGridView()
    {
        try
        {
            gvPreventiveMaintenance.DataSource = EmptyDT();
            gvPreventiveMaintenance.DataBind();
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void ClearGridView()
    {
        try
        {
            gvPreventiveMaintenance.DataSource = EmptyDT();
            gvPreventiveMaintenance.DataBind();
            gvPreventiveMaintenance.Rows[0].Visible = false;
            gvPreventiveMaintenance.Visible = false;
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void AddTableToGridView(DataTable table)
    {
        try
        {
            gvPreventiveMaintenance.DataSource = table;
            gvPreventiveMaintenance.DataBind();
            gvPreventiveMaintenance.Rows[0].Visible = true;
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Event Handler Functions

    protected void ddlJobHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlJobHeaderList_SelectedIndexChanged();
    }

    private void ddlJobHeaderList_SelectedIndexChanged()
    {
        try
        {
            if (ddlJobHeaderList.SelectedIndex > 0)
            {
                btnAddNew.Enabled = true;
                btnPDF.Enabled = false;
                ddlJobHeaderEvent();
            }
            else
            {
                ResetForAddNew();
                ResetContact();
                DisabledButton();
                ResetOrderNo();
                GridDiv.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlOrderNoHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlOrderNoHeaderList.SelectedIndex > 0)
            {
                EnabledButton();
                ddlOrderNoHeaderEvent();
            }
            else
            {
                DisablePdfButton();
                ResetEntryFields();
                ResetGridView();
                GridDiv.Visible = false;
            }
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
            btnSave_Click_Event();
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
            btnAdd_Click_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            btnAddNew_Click_Event();
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
            Reset();
            ResetContact();
            DisabledButton();
            GridDiv.Visible = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    protected void gvPreventiveMaintenance_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            gvPreventiveMaintenance.EditIndex = e.NewEditIndex;
            ddlOrderNoHeaderEvent();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvPreventiveMaintenance_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        try
        {
            int ID = Convert.ToInt32(gvPreventiveMaintenance.DataKeys[e.RowIndex].Values[0]);
            string msg = "";
            ObjBOL.Operation = 6;
            ObjBOL.ID = ID;
            msg = ObjBLL.SaveAndUpdate(ObjBOL);
            if (msg.Length > 0)
            {
                Utility.MaintainLogsSpecial("frmPreventiveMaintenance", "Delete-Detail", txtOrderNo.Text);
                Utility.ShowMessage_Success(this, msg);
                ddlOrderNoHeaderEvent();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvPreventiveMaintenance_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        try
        {
            CancelEdit_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvPreventiveMaintenance_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow row = gvPreventiveMaintenance.Rows[e.RowIndex];
            int ID = Convert.ToInt32(gvPreventiveMaintenance.DataKeys[e.RowIndex].Values[0]);
            TextBox date = row.FindControl("txtgvPreventiveMaintenanceDate") as TextBox;
            TextBox remarks = row.FindControl("txtgvPreventiveMaintenanceRemarks") as TextBox;
            ObjBOL.Operation = 8;
            ObjBOL.ID = ID;
            ObjBOL.FollowUpDate = Utility.ConvertDate(date.Text);
            ObjBOL.Remarks = remarks.Text;
            string msg = ObjBLL.SaveAndUpdate(ObjBOL);
            if (msg.Length > 0)
            {
                Utility.MaintainLogsSpecial("frmPreventiveMaintenance", "Update-Detail", txtOrderNo.Text);
                Utility.ShowMessage_Success(Page, msg);
                CancelEdit_Event();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Event Internal Functions

    private void ddlJobHeaderEvent()
    {
        try
        {
            ResetOrderNo();
            if (ddlJobHeaderList.SelectedIndex > 0)
            {
                ObjBOL.Operation = 10;
                ObjBOL.JobID = ddlJobHeaderList.SelectedValue;
                DataSet ds = ObjBLL.GetInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlOrderNoHeaderList, ds.Tables[0]);
                    ddlOrderNoHeaderList.Enabled = true;
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtTitle.Text = ds.Tables[1].Rows[0]["Title"].ToString();
                    txtName.Text = ds.Tables[1].Rows[0]["Name"].ToString();
                    txtPhone.Text = ds.Tables[1].Rows[0]["Phone"].ToString();
                    txtEmail.Text = ds.Tables[1].Rows[0]["email"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlOrderNoHeaderEvent()
    {
        try
        {
            ResetEntryFields();
            InitiateGridView();
            if (ddlOrderNoHeaderList.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.JobID = ddlJobHeaderList.SelectedValue;
                ObjBOL.OrderNo = ddlOrderNoHeaderList.SelectedValue;
                ds = ObjBLL.GetInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    AddTableToGridView(ds.Tables[0]);
                }
                else
                {
                    ClearGridView();
                }

                if (ds.Tables[1].Rows[0][0].ToString() != "")
                {
                    BindEntryFields(Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString()));
                }
                else
                {
                    txtOrderNo.Text = ddlOrderNoHeaderList.SelectedValue;
                }
            }
            else
            {
                ClearGridView();
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
            if (ValidationCheck())
            {
                string op = "";
                if (btnSave.Text == "Save")
                {
                    ObjBOL.Operation = 4;
                    op = "Save";
                }

                if (btnSave.Text == "Update")
                {
                    ObjBOL.Operation = 5;
                    op = "Update";
                    ObjBOL.ID = Convert.ToInt32(HiddenID.Value);
                }
                ObjBOL.JobID = ddlJobHeaderList.SelectedValue;
                ObjBOL.OrderNo = txtOrderNo.Text;
                ObjBOL.StatusID = Convert.ToInt32(ddlStatus.SelectedValue);
                ObjBOL.Attention = txtAttention.Text;
                //ObjBOL.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                if (txtQuoteSentDate.Text.Trim() != "")
                {
                    ObjBOL.QuoteSentDate = Utility.ConvertDate(txtQuoteSentDate.Text);
                }

                if (txtQuoteAmount.Text.Trim() != "")
                {
                    ObjBOL.QuoteAmount = Convert.ToDecimal(txtQuoteAmount.Text);
                }

                ObjBOL.PONumber = txtPONumber.Text;
                if (txtPORecDate.Text.Trim() != "")
                {
                    ObjBOL.PORecDate = Utility.ConvertDate(txtPORecDate.Text);
                }

                if (txtContractStartDate.Text.Trim() != "")
                {
                    ObjBOL.ContractStartDate = Utility.ConvertDate(txtContractStartDate.Text);
                }

                if (txtContractEndDate.Text.Trim() != "")
                {
                    ObjBOL.ContractEndDate = Utility.ConvertDate(txtContractEndDate.Text);
                }

                if (txtLastTuneUpDate.Text.Trim() != "")
                {
                    ObjBOL.LastTuneUpDate = Utility.ConvertDate(txtLastTuneUpDate.Text);
                }

                if (txtNextTuneUpDate.Text.Trim() != "")
                {
                    ObjBOL.NextTuneUpDate = Utility.ConvertDate(txtNextTuneUpDate.Text);
                }

                if (txtInvoiceDate.Text.Trim() != "")
                {
                    ObjBOL.InvoiceDate = Utility.ConvertDate(txtInvoiceDate.Text);
                }

                ObjBOL.InvoiceNo = txtInvoiceNo.Text;
                if (txtQuoteDetails.Text != "")
                {
                    ObjBOL.QuoteDetails = txtQuoteDetails.Text;
                }
                //if (txtFollowUpDate.Text.Trim() != "")
                //{
                //    ObjBOL.FollowUpDate = Utility.ConvertDate(txtFollowUpDate.Text);
                //}

                //ObjBOL.Remarks = txtRemarks.Text;
                string msg = ObjBLL.SaveAndUpdate(ObjBOL);
                if (msg.Length > 0)
                {
                    if (msg == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "Entry For Contract No " + ObjBOL.OrderNo + " already Exist for JobID: " + ObjBOL.JobID);
                    }
                    else
                    {
                        Utility.MaintainLogsSpecial("frmPreventiveMaintenance", op, ObjBOL.OrderNo);
                        Utility.ShowMessage_Success(Page, msg);
                        var orderNo = txtOrderNo.Text;
                        ddlJobHeaderEvent();
                        ddlOrderNoHeaderList.SelectedValue = orderNo;
                        ddlOrderNoHeaderEvent();
                        EnabledButton();
                    }
                }
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void btnAdd_Click_Event()
    {
        try
        {
            if (ddlOrderNoHeaderList.SelectedIndex > 0)
            {
                if (Convert.ToInt32(HiddenID.Value) > 0)
                {
                    if (ValidationCheckGrid() == true)
                    {
                        string Date = (gvPreventiveMaintenance.FooterRow.FindControl("txtfooterPreventiveMaintenanceDate") as TextBox).Text;
                        string Remarks = (gvPreventiveMaintenance.FooterRow.FindControl("txtfooterPreventiveMaintenanceRemarks") as TextBox).Text;
                        ObjBOL.FollowUpDate = Utility.ConvertDate(Date);
                        ObjBOL.Remarks = Remarks;
                        ObjBOL.Operation = 7;
                        ObjBOL.ID = Convert.ToInt32(HiddenID.Value);
                        string msg = ObjBLL.SaveAndUpdate(ObjBOL);
                        if (msg.Length > 0)
                        {
                            Utility.MaintainLogsSpecial("frmPreventiveMaintenance", "Save-Detail", txtOrderNo.Text);
                            Utility.ShowMessage_Success(Page, msg);
                            ddlOrderNoHeaderEvent();
                        }
                    }
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "Please Save Year Info First !");
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please Select Year First !");
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void btnAddNew_Click_Event()
    {
        try
        {
            ResetForAddNew();
            if (ValidationCheckAdd())
            {
                ObjBOL.Operation = 9;
                ObjBOL.JobID = ddlJobHeaderList.SelectedValue;
                string msg = ObjBLL.SaveAndUpdate(ObjBOL);
                txtOrderNo.Text = msg;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CancelEdit_Event()
    {
        try
        {
            gvPreventiveMaintenance.EditIndex = -1;
            ddlOrderNoHeaderEvent();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Resets

    private void Reset()
    {
        try
        {
            if (ddlJobHeaderList.Items.Count > 0)
            {
                ddlJobHeaderList.SelectedIndex = 0;
            }
            ResetOrderNo();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void ResetOrderNo()
    {
        try
        {
            if (ddlOrderNoHeaderList.Items.Count > 0)
            {
                ddlOrderNoHeaderList.Items.Clear();
            }
            ddlOrderNoHeaderList.Enabled = false;
            ResetEntryFields();
            ResetGridView();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void ResetForAddNew()
    {
        try
        {
            if (ddlOrderNoHeaderList.Items.Count > 0)
            {
                ddlOrderNoHeaderList.SelectedIndex = 0;
            }
            ResetEntryFields();
            ResetGridView();
            GridDiv.Visible = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void ResetEntryFields()
    {
        try
        {
            txtOrderNo.Text = string.Empty;
            if (ddlStatus.Items.Count > 0)
            {
                ddlStatus.SelectedIndex = 0;
            }
            //ddlCategory.SelectedIndex = 0;
            txtQuoteSentDate.Text = string.Empty;
            txtQuoteAmount.Text = string.Empty;
            txtQuoteDetails.Text = string.Empty;
            txtPONumber.Text = string.Empty;
            txtPORecDate.Text = string.Empty;
            txtContractStartDate.Text = string.Empty;
            txtContractEndDate.Text = string.Empty;
            txtLastTuneUpDate.Text = string.Empty;
            txtNextTuneUpDate.Text = string.Empty;
            txtInvoiceDate.Text = string.Empty;
            txtInvoiceNo.Text = string.Empty;
            txtFollowUpDate.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtAttention.Text = string.Empty;
            btnSave.Text = "Save";
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
            dtEmpty.TableName = "EmptyGridView";
            dtEmpty.Columns.Add(new DataColumn("ID", typeof(Int32)));
            dtEmpty.Columns.Add(new DataColumn("Date", typeof(DateTime)));
            dtEmpty.Columns.Add(new DataColumn("Remarks", typeof(string)));
            DataRow row = dtEmpty.NewRow();
            dtEmpty.Rows.Add(row);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    private void ResetGridView()
    {
        try
        {
            gvPreventiveMaintenance.DataSource = "";
            gvPreventiveMaintenance.DataBind();
            HiddenID.Value = "0";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetContact()
    {
        try
        {
            txtTitle.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    protected void btnReports_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Reports/frmPreventiveMaintenanceReport.aspx", false);
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
            rprt.Load(Server.MapPath("~/Reports/rptPreventiveMaintenance.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Aerowerks Preventive Maintenance";
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
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

    private DataTable ReportDataZero()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[Get_PreventiveMaintenance] '" + ddlOrderNoHeaderList.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportDataGenQuote()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[Get_CCT_RT_GenQuote] '" + ddlOrderNoHeaderList.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnGenQuote_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataGenQuote();
            rprt.Load(Server.MapPath("~/Reports/rptGenerateQuote.rpt"));
            if (dt.Rows.Count > 0)
            {
                string FileName = "Quote_" + ddlOrderNoHeaderList.SelectedValue;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, false, FileName);
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

    protected void btnGenQuotePdf_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataGenQuote();
            rprt.Load(Server.MapPath("~/Reports/rptGenerateQuote.rpt"));
            if (dt.Rows.Count > 0)
            {
                string FileName = "Quote_" + ddlOrderNoHeaderList.SelectedValue;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, FileName);
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
}