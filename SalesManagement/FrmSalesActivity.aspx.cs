using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
//using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;

public partial class SalesManagement_FrmSalesActivity : System.Web.UI.Page
{
    BOLSalesActivity ObjBOL = new BOLSalesActivity();
    BLLSalesActivity ObjBLL = new BLLSalesActivity();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
            ResetUser();
        }
    }

    private void BindControls()
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                ObjBOL.Operation = 1;
                ObjBOL.UserID = Utility.GetCurrentUser();
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlStakeHolderHeaderList, ds.Tables[0]);
                    Utility.BindDropDownList(ddlStakeholder, ds.Tables[0]);
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlStatus, ds.Tables[1]);
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlUsers, ds.Tables[2]);
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    hfPermission.Value = ds.Tables[3].Rows[0]["Permission"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindActivityHistoryGrid()
    {
        try
        {
            if (ddlStakeHolderHeaderList.SelectedIndex > 0 && ddlCompanyHeaderList.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                ObjBOL.Operation = 6;
                ObjBOL.StakeHolderId = Int32.Parse(ddlStakeHolderHeaderList.SelectedValue);
                ObjBOL.CompanyId = Int32.Parse(ddlCompanyHeaderList.SelectedValue);
                if (Utility.IsAuthorized())
                {
                    ObjBOL.UserID = Utility.GetCurrentUser();
                }

                dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    gvActivityHistory.DataSource = dt;
                    gvActivityHistory.DataBind();
                }
                else
                {
                    gvActivityHistory.DataSource = string.Empty;
                    gvActivityHistory.DataBind();
                }
            }
            else
            {
                gvActivityHistory.DataSource = string.Empty;
                gvActivityHistory.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindFollowupsGrid(int id)
    {
        try
        {
            if (ddlStakeHolderHeaderList.SelectedIndex > 0 && ddlCompanyHeaderList.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                ObjBOL.Operation = 9;
                ObjBOL.ActivityDetailId = id;

                dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    gvFollowups.DataSource = dt;
                    gvFollowups.DataBind();
                }
                else
                {
                    gvFollowups.DataSource = string.Empty;
                    gvFollowups.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindTravelLogsGrid(int id)
    {
        try
        {
            if (ddlStakeHolderHeaderList.SelectedIndex > 0 && ddlCompanyHeaderList.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                ObjBOL.Operation = 13;
                ObjBOL.ActivityDetailId = id;

                dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    gvTravelLogs.DataSource = dt;
                    gvTravelLogs.DataBind();
                }
                else
                {
                    gvTravelLogs.DataSource = string.Empty;
                    gvTravelLogs.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationCheck_Activity()
    {
        try
        {
            if (ddlStakeholder.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Stake Holder !");
                ddlStakeholder.Focus();
                return false;
            }

            if (ddlCompany.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Company Name !");
                ddlCompany.Focus();
                return false;
            }

            if (txtActivityDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Activity Date !");
                txtActivityDate.Focus();
                return false;
            }

            if (txtActivityObjective.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter activity Objective !");
                txtActivityObjective.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private bool ValidationCheck_Followup()
    {
        try
        {
            Modal_Followup.Show();
            if (txtFollowupDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Followup date !");
                txtFollowupDate.Focus();
                return false;
            }

            if (txtTask.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Task !");
                txtTask.Focus();
                return false;
            }

            if (ddlTypeOfContact.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Type of contact !");
                ddlTypeOfContact.Focus();
                return false;
            }

            if (ddlResponsiblePerson.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select responsible person !");
                ddlStakeholder.Focus();
                return false;
            }

            if (ddlStatus.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Status !");
                ddlCompany.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private bool ValidationCheck_TravelLogs()
    {
        try
        {
            Modal_TravelLogs.Show();
            if (txtTravelDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Travel date !");
                txtTravelDate.Focus();
                return false;
            }

            if (txtDestination.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Destination !");
                txtDestination.Focus();
                return false;
            }

            if (txtPurpose.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please select Purpose !");
                txtPurpose.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void gvFollowups_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditFollowup")
            {
                ObjBOL.Operation = 11;
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                var dataKeyValue = gvFollowups.DataKeys[rowIndex].Value.ToString();
                hfFollowupId.Value = dataKeyValue;
                ObjBOL.ID = Int32.Parse(dataKeyValue);
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    txtFollowupDate.Text = dr["Date"].ToString();
                    txtTask.Text = dr["Task"].ToString();
                    if (ddlTypeOfContact.Items.FindByValue(dr["TypeOfContact"].ToString()) != null)
                    {
                        ddlTypeOfContact.SelectedValue = dr["TypeOfContact"].ToString();
                    }

                    txtPNumber.Text = dr["PNumber"].ToString();
                    txtProjectName.Text = dr["ProjectName"].ToString();
                    if (ddlResponsiblePerson.Items.FindByValue(dr["ResponsiblePerson"].ToString()) != null)
                    {
                        ddlResponsiblePerson.SelectedValue = dr["ResponsiblePerson"].ToString();
                    }

                    txtDeadline.Text = dr["Deadline"].ToString();
                    txtRegionalIndustryUpdates.Text = dr["RegionalIndustryUpdates"].ToString();

                    if (ddlStatus.Items.FindByValue(dr["Status"].ToString()) != null)
                    {
                        ddlStatus.SelectedValue = dr["Status"].ToString();
                    }

                    txtNextFollowupDate.Text = dr["NextFollowupDate"].ToString();
                }
                btnAddFollowup.Text = "Update";
                Modal_Followup.Show();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvActivityHistory_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Followup")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvActivityHistory.Rows[rowIndex];
                var dataKeyValue = gvActivityHistory.DataKeys[rowIndex].Value.ToString();
                int id = Int32.Parse(dataKeyValue);

                Label lblDate = (Label)row.FindControl("lblDate");
                Label lblObjective = (Label)row.FindControl("lblObjective");
                lblActivity.Text = lblDate.Text + ", " + lblObjective.Text;
                hfActivityDetailId.Value = dataKeyValue;
                ResetDefaultFollowupDetails();
                Modal_Followup.Show();
                BindFollowupsGrid(id);
            }
            else if (e.CommandName == "TravelLogs")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvActivityHistory.Rows[rowIndex];
                var dataKeyValue = gvActivityHistory.DataKeys[rowIndex].Value.ToString();
                int id = Int32.Parse(dataKeyValue);

                Label lblDate = (Label)row.FindControl("lblDate");
                Label lblObjective = (Label)row.FindControl("lblObjective");
                lblTask.Text = lblDate.Text + ", " + lblObjective.Text;
                hfActivityDetailId.Value = dataKeyValue;
                ResetDefaultTravelLogDetails();
                Modal_TravelLogs.Show();
                BindTravelLogsGrid(id);
            }
            else if (e.CommandName == "EditActivity")
            {
                ObjBOL.Operation = 7;
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                var dataKeyValue = gvActivityHistory.DataKeys[rowIndex].Value.ToString();
                hfActivityDetailId.Value = dataKeyValue;
                ObjBOL.ID = Int32.Parse(dataKeyValue);
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    txtActivityDate.Text = dr["Date"].ToString();
                    txtActivityObjective.Text = dr["Objective"].ToString();
                    txtActivityOutcome.Text = dr["Outcome"].ToString();
                }
                disableStakeHolderDetails();
                btnSave.Text = "Update";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvTravelLogs_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditTravel")
            {
                ObjBOL.Operation = 15;
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                var dataKeyValue = gvTravelLogs.DataKeys[rowIndex].Value.ToString();
                hfTravelLogId.Value = dataKeyValue;
                ObjBOL.ID = Int32.Parse(dataKeyValue);
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    txtTravelDate.Text = dr["Date"].ToString();
                    txtPurpose.Text = dr["Purpose"].ToString();
                    txtDestination.Text = dr["Destination"].ToString();
                    txtOutcome.Text = dr["Outcome"].ToString();
                }
                btnAddTravelLog.Text = "Update";
                Modal_TravelLogs.Show();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel_Click();
    }

    private void btnCancel_Click()
    {
        try
        {
            btnSave.Text = "Save";
            ResetUser();
            ddlStakeHolderHeaderList.SelectedIndex = 0;
            ddlCompanyHeaderList.Items.Clear();
            ddlStakeholder.SelectedIndex = 0;
            ddlCompany.Items.Clear();
            txtCountry.Text = string.Empty;
            txtState.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtActivityDate.Text = string.Empty;
            txtActivityObjective.Text = string.Empty;
            txtActivityOutcome.Text = string.Empty;
            gvActivityHistory.DataSource = string.Empty;
            gvActivityHistory.DataBind();
            gvFollowups.DataSource = string.Empty;
            gvFollowups.DataBind();
            gvTravelLogs.DataSource = string.Empty;
            gvTravelLogs.DataBind();
            //hfPermission.Value = "-1";
            hfActivityDetailId.Value = "-1";
            hfFollowupId.Value = "-1";
            hfTravelLogId.Value = "-1";
            enableStakeHolderDetails();
            ResetDefaultTravelLogDetails();
            gvTravelLogs.DataSource = string.Empty;
            gvTravelLogs.DataBind();
            ResetDefaultFollowupDetails();
            gvFollowups.DataSource = string.Empty;
            gvFollowups.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancelFollowup_Click(object sender, EventArgs e)
    {
        ResetFollowupDetail();
    }

    protected void btnAddFollowup_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck_Followup())
            {
                if (btnAddFollowup.Text == "Add")
                {
                    ObjBOL.Operation = 10;
                }
                else if (btnAddFollowup.Text == "Update")
                {
                    ObjBOL.Operation = 12;
                    ObjBOL.ID = Int32.Parse(hfFollowupId.Value);
                }

                ObjBOL.ActivityDetailId = Int32.Parse(hfActivityDetailId.Value);
                if (txtFollowupDate.Text != "")
                {
                    ObjBOL.Date = Utility.ConvertDate(txtFollowupDate.Text);
                }
                ObjBOL.Task = txtTask.Text;

                if (ddlTypeOfContact.SelectedIndex > 0)
                {
                    ObjBOL.TypeOfContact = ddlTypeOfContact.SelectedValue;
                }

                ObjBOL.PNumber = txtPNumber.Text;
                ObjBOL.ProjectName = txtProjectName.Text;
                if (txtNextFollowupDate.Text != "")
                {
                    ObjBOL.NextFollowupDate = Utility.ConvertDate(txtNextFollowupDate.Text);
                }

                if (ddlResponsiblePerson.SelectedIndex > 0)
                {
                    ObjBOL.ResponsiblePerson = Int32.Parse(ddlResponsiblePerson.SelectedValue);
                }

                if (txtDeadline.Text != "")
                {
                    ObjBOL.Deadline = txtDeadline.Text;
                }

                if (ddlStatus.SelectedIndex > 0)
                {
                    ObjBOL.Status = Int32.Parse(ddlStatus.SelectedValue);
                }

                ObjBOL.RegionalIndustryUpdates = txtRegionalIndustryUpdates.Text;
                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim().Length > 0)
                {
                    if (btnAddFollowup.Text == "Add")
                    {
                        Utility.ShowMessage_Success(Page, "Followup saved successfully !!");
                        Utility.MaintainLogsSpecial("SalesActivity-Followup", btnAddFollowup.Text, returnStatus.Trim());
                    }
                    else if (btnAddFollowup.Text == "Update")
                    {
                        Utility.ShowMessage_Success(Page, "Followup updated successfully !!");
                        Utility.MaintainLogsSpecial("SalesActivity-Followup", btnAddFollowup.Text, returnStatus.Trim());
                    }
                    ResetFollowupDetail();
                    BindFollowupsGrid(ObjBOL.ActivityDetailId);
                    Modal_Followup.Show();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancelTravelLog_Click(object sender, EventArgs e)
    {
        ResetTravelLogsDetail();
    }

    protected void btnAddTravelLog_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck_TravelLogs())
            {
                if (btnAddTravelLog.Text == "Add")
                {
                    ObjBOL.Operation = 14;
                }
                else if (btnAddTravelLog.Text == "Update")
                {
                    ObjBOL.Operation = 16;
                    ObjBOL.ID = Int32.Parse(hfTravelLogId.Value);
                }

                ObjBOL.ActivityDetailId = Int32.Parse(hfActivityDetailId.Value);
                if (txtTravelDate.Text != "")
                {
                    ObjBOL.Date = Utility.ConvertDate(txtTravelDate.Text);
                }
                ObjBOL.Destination = txtDestination.Text;
                ObjBOL.Purpose = txtPurpose.Text;
                ObjBOL.Outcome = txtOutcome.Text;

                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim().Length > 0)
                {
                    if (btnAddTravelLog.Text == "Add")
                    {
                        Utility.ShowMessage_Success(Page, "Travel log saved successfully !!");
                        Utility.MaintainLogsSpecial("SalesActivity-Travel", btnAddTravelLog.Text, returnStatus.Trim());
                    }
                    else if (btnAddTravelLog.Text == "Update")
                    {
                        Utility.ShowMessage_Success(Page, "Travel log updated successfully !!");
                        Utility.MaintainLogsSpecial("SalesActivity-Travel", btnAddTravelLog.Text, returnStatus.Trim());
                    }
                    ResetTravelLogsDetail();
                    BindTravelLogsGrid(ObjBOL.ActivityDetailId);
                    Modal_TravelLogs.Show();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlStakeholder_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlStakeholder_SelectedIndexChanged();
    }

    private void ddlStakeholder_SelectedIndexChanged()
    {
        try
        {
            ResetCompanyRelatedInfo();
            if (ddlStakeholder.SelectedIndex > 0)
            {
                ObjBOL.Operation = 2;
                ObjBOL.StakeHolderId = Int32.Parse(ddlStakeholder.SelectedValue);
                DataTable dt = GetCompany();

                if (dt.Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlCompany, dt);
                }
                else
                {
                    ddlCompany.Items.Clear();
                }
            }
            else
            {
                ddlCompany.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable GetCompany()
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjBLL.Return_DataSet(ObjBOL);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return ds.Tables[0];
    }

    protected void ddlStakeHolderHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlStakeHolderHeaderList_SelectedIndexChanged();
    }

    private void ddlStakeHolderHeaderList_SelectedIndexChanged()
    {
        try
        {
            string stakeholder = ddlStakeHolderHeaderList.SelectedValue;
            btnCancel_Click();
            ddlStakeHolderHeaderList.SelectedValue = stakeholder;
            ddlStakeholder.SelectedValue = ddlStakeHolderHeaderList.SelectedValue;
            ResetCompanyRelatedInfo();
            ddlStakeholder_SelectedIndexChanged();
            if (ddlStakeHolderHeaderList.SelectedIndex > 0)
            {
                ObjBOL.Operation = 20;
                ObjBOL.StakeHolderId = Int32.Parse(ddlStakeHolderHeaderList.SelectedValue);
                DataTable dt = GetCompany();

                if (dt.Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlCompanyHeaderList, dt);
                    //Utility.BindDropDownList(ddlCompany, dt);
                }
                else
                {
                    ddlCompanyHeaderList.Items.Clear();
                    //ddlCompany.Items.Clear();
                }
            }
            else
            {
                ddlCompanyHeaderList.Items.Clear();
                //ddlCompany.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCompanyHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCompanyHeaderList_SelectedIndexChanged();
    }

    private void ddlCompanyHeaderList_SelectedIndexChanged()
    {
        try
        {
            ddlCompany.SelectedValue = ddlCompanyHeaderList.SelectedValue;
            ddlCompany_SelectedIndexChanged();
            BindActivityHistoryGrid();
            GetResponsiblePersonList();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCompany_SelectedIndexChanged();
    }

    private void ddlCompany_SelectedIndexChanged()
    {
        try
        {
            ResetCompanyRelatedInfo();
            if (ddlCompany.SelectedIndex > 0 && ddlStakeholder.SelectedIndex > 0)
            {
                ObjBOL.Operation = 3;
                ObjBOL.CompanyId = Int32.Parse(ddlCompany.SelectedValue);
                ObjBOL.StakeHolderId = Int32.Parse(ddlStakeholder.SelectedValue);
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    txtCountry.Text = dr["Country"].ToString();
                    txtState.Text = dr["State"].ToString();
                    txtCity.Text = dr["City"].ToString();
                    txtAddress.Text = dr["StreetAddress"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetCompanyRelatedInfo()
    {
        try
        {
            txtCountry.Text = string.Empty;
            txtState.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtAddress.Text = string.Empty;
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
            if (ValidationCheck_Activity())
            {
                if (btnSave.Text == "Save")
                {
                    ObjBOL.Operation = 4;
                }
                else if (btnSave.Text == "Update")
                {
                    ObjBOL.Operation = 5;
                    ObjBOL.ID = Int32.Parse(hfActivityDetailId.Value);
                }

                if (ddlStakeholder.SelectedIndex > 0)
                {
                    ObjBOL.StakeHolderId = Int32.Parse(ddlStakeholder.SelectedValue);
                }

                if (ddlCompany.SelectedIndex > 0)
                {
                    ObjBOL.CompanyId = Int32.Parse(ddlCompany.SelectedValue);
                }
                if (txtActivityDate.Text != "")
                {
                    ObjBOL.Date = Utility.ConvertDate(txtActivityDate.Text);
                }
                ObjBOL.Objective = txtActivityObjective.Text;
                ObjBOL.Outcome = txtActivityOutcome.Text;
                if (Utility.IsAuthorized())
                {
                    ObjBOL.UserID = Utility.GetCurrentUser();
                }
                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim().Length > 0)
                {
                    if (returnStatus.Trim() == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "Activity already exists for this company for given date !");
                        return;
                    }
                    if (btnSave.Text == "Save")
                    {
                        Utility.ShowMessage_Success(Page, "Activity saved successfully !!");
                        Utility.MaintainLogsSpecial("SalesActivity", btnSave.Text, returnStatus.Trim());
                    }
                    else if (btnSave.Text == "Update")
                    {
                        Utility.ShowMessage_Success(Page, "Activity updated successfully !!");
                        Utility.MaintainLogsSpecial("SalesActivity", btnSave.Text, returnStatus.Trim());
                    }
                    string stakeHolder = ddlStakeholder.SelectedValue;
                    string companyID = ddlCompany.SelectedValue;
                    ResetActivityDetail();
                    ddlStakeHolderHeaderList.SelectedValue = stakeHolder;
                    ddlStakeHolderHeaderList_SelectedIndexChanged();
                    ddlCompanyHeaderList.SelectedValue = companyID;
                    ddlCompanyHeaderList_SelectedIndexChanged();
                    //BindActivityHistoryGrid();
                    enableStakeHolderDetails();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetActivityDetail()
    {
        try
        {
            ResetUser();
            txtActivityDate.Text = string.Empty;
            txtActivityObjective.Text = string.Empty;
            txtActivityOutcome.Text = string.Empty;
            hfActivityDetailId.Value = "-1";
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetDefaultFollowupDetails()
    {
        try
        {
            txtFollowupDate.Text = string.Empty;
            txtTask.Text = string.Empty;
            if (ddlTypeOfContact.Items.Count > 0)
            {
                ddlTypeOfContact.SelectedIndex = 0;
            }

            txtPNumber.Text = string.Empty;
            txtProjectName.Text = string.Empty;
            if (ddlResponsiblePerson.Items.Count > 0)
            {
                ddlResponsiblePerson.SelectedIndex = 0;
            }
            txtDeadline.Text = string.Empty;
            txtRegionalIndustryUpdates.Text = string.Empty;
            if (ddlStatus.Items.Count > 0)
            {
                ddlStatus.SelectedIndex = 0;
            }
            txtNextFollowupDate.Text = string.Empty;

            //hfActivityDetailId.Value = "-1";
            hfFollowupId.Value = "-1";
            btnAddFollowup.Text = "Add";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetFollowupDetail()
    {
        try
        {
            ResetDefaultFollowupDetails();
            Modal_Followup.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetDefaultTravelLogDetails()
    {
        try
        {
            txtTravelDate.Text = string.Empty;
            txtDestination.Text = string.Empty;
            txtPurpose.Text = string.Empty;
            txtOutcome.Text = string.Empty;
            hfTravelLogId.Value = "-1";
            btnAddTravelLog.Text = "Add";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetTravelLogsDetail()
    {
        try
        {
            ResetDefaultTravelLogDetails();
            Modal_TravelLogs.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetResponsiblePersonList()
    {
        try
        {
            if (ddlStakeHolderHeaderList.SelectedIndex > 0 && ddlCompanyHeaderList.SelectedIndex > 0)
            {
                ObjBOL.Operation = 8;
                ObjBOL.ID = Int32.Parse(ddlCompanyHeaderList.SelectedValue);
                ObjBOL.StakeHolderId = Int32.Parse(ddlStakeHolderHeaderList.SelectedValue);
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlResponsiblePerson, ds.Tables[0]);
                    ddlResponsiblePerson.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvActivityHistory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            ObjBOL.Operation = 17;
            int ID = Convert.ToInt32(gvActivityHistory.DataKeys[e.RowIndex].Values[0]);
            //hfActivityDetailId.Value = ID.ToString();
            ObjBOL.ID = ID;
            string returnStatus = ObjBLL.Return_String(ObjBOL);
            if (returnStatus.Trim() != "")
            {
                if (returnStatus.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "Followups exists for activity !");
                    return;
                }

                if (returnStatus.Trim() == "ER02")
                {
                    Utility.ShowMessage_Error(Page, "Travel logs exists for activity !");
                    return;
                }
                Utility.MaintainLogsSpecial("SalesActivity", "delete", ddlStakeHolderHeaderList.SelectedValue + " | " + ddlCompanyHeaderList.SelectedValue);
                Utility.ShowMessage_Success(Page, "Activity deleted successfully !!");
                BindActivityHistoryGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvFollowups_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Modal_Followup.Show();
            if (btnAddFollowup.Text == "Update")
            {
                Utility.ShowMessage_Error(Page, "Followup Update in progress !!");
            }
            else
            {
                ObjBOL.Operation = 18;
                int ID = Convert.ToInt32(gvFollowups.DataKeys[e.RowIndex].Values[0]);
                ObjBOL.ID = ID;
                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim() != "")
                {
                    Utility.MaintainLogsSpecial("SalesActivity-Followup", "delete", hfActivityDetailId.Value);
                    Utility.ShowMessage_Success(Page, "Followup deleted successfully !!");
                    int id = Int32.Parse(hfActivityDetailId.Value);
                    BindFollowupsGrid(id);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvTravelLogs_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Modal_TravelLogs.Show();
            if (btnAddTravelLog.Text == "Update")
            {
                Utility.ShowMessage_Error(Page, "Travel Log Update in progress !!");
            }
            else
            {
                ObjBOL.Operation = 19;
                int ID = Convert.ToInt32(gvTravelLogs.DataKeys[e.RowIndex].Values[0]);
                ObjBOL.ID = ID;
                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim() != "")
                {
                    Utility.MaintainLogsSpecial("SalesActivity-Travel", "delete", hfActivityDetailId.Value);
                    Utility.ShowMessage_Success(Page, "Travel deleted successfully !!");
                    int id = Int32.Parse(hfActivityDetailId.Value);
                    BindTravelLogsGrid(id);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void disableStakeHolderDetails()
    {
        try
        {
            ddlStakeholder.Enabled = false;
            ddlCompany.Enabled = false;
            ddlStakeHolderHeaderList.Enabled = false;
            ddlCompanyHeaderList.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void enableStakeHolderDetails()
    {
        try
        {
            ddlStakeholder.Enabled = true;
            ddlCompany.Enabled = true;
            ddlStakeHolderHeaderList.Enabled = true;
            ddlCompanyHeaderList.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //private DataTable ReportData()
    //{
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        ObjBOL.Operation = 21;
    //        ds = ObjBLL.Return_DataSet(ObjBOL);      

    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //    return ds.Tables[0];
    //}

    //private DataTable ReportData_SubReport_Followup()
    //{
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        ObjBOL.Operation = 22;
    //        ds = ObjBLL.Return_DataSet(ObjBOL);
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //    return ds.Tables[0];
    //}

    //private DataTable ReportData_SubReport_TravelLogs()
    //{
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        ObjBOL.Operation = 23;
    //        ds = ObjBLL.Return_DataSet(ObjBOL);
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //    return ds.Tables[0];
    //}

    //protected void btnReport_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DataTable dtMain = ReportData();
    //        DataTable dtSubReport = ReportData_SubReport_Followup();
    //        DataTable dtSubReport_Travel = ReportData_SubReport_TravelLogs();
    //        rprt.Load(Server.MapPath("~/Reports/rptSalesActivity_V1.rpt"));
    //        if (dtMain.Rows.Count > 0)
    //        {
    //            TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
    //            txtheader.Text = "Sales Activity Report";
    //            rprt.SetDataSource(dtMain);
    //            rprt.Subreports[0].SetDataSource(dtSubReport);
    //            rprt.Subreports[1].SetDataSource(dtSubReport_Travel);
    //            rprtSalesActivity.ReportSource = rprt;
    //            rprtSalesActivity.DataBind();
    //            rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
    //        }
    //        else
    //        {
    //            Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //    finally
    //    {
    //        rprt.Close();
    //        rprt.Dispose();
    //    }
    //}

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Reports/FrmSalesActivityReport_V1.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetUser()
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                if (ddlUsers.Items.FindByValue(Utility.GetCurrentUser().ToString()) != null)
                {
                    ddlUsers.SelectedValue = Utility.GetCurrentUser().ToString();
                }
                else
                {
                    if (ddlUsers.Items.Count > 0)
                    {
                        ddlUsers.SelectedIndex = 0;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvActivityHistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find the TravelLogs button
                LinkButton btnTravelLogs = (LinkButton)e.Row.FindControl("btnTravelLogs");

                if (hfPermission.Value == "1")
                {
                    btnTravelLogs.Visible = true;
                }
                else
                {
                    btnTravelLogs.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Reports/FrmSalesActivityReport_V3.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void SearchPNumberButton_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = Utility.ReturnProposals(23, txtPNumber.Text);
            if (dt.Rows.Count > 0)
            {
                txtProjectName.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
            }
            else
            {
                Utility.ShowMessage_Error(Page, "P# not found");
                txtProjectName.Text = "";
                txtPNumber.Text = "";
            }

            Modal_Followup.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}