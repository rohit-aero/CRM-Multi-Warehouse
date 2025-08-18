using BLLAERO;
using BOLAERO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalesManagement_FrmShopDwgIssueLog : System.Web.UI.Page
{
    string formName = "FrmShopDwgIssueLog.aspx";
    BOLManageShopDwgIssueLog ObjBOL = new BOLManageShopDwgIssueLog();
    BLLShopDwgIssueLog ObjBLL = new BLLShopDwgIssueLog();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
            rdbFollowupRequired_SelectedIndexChanged();
        }
    }

    private void BindControls()
    {
        try
        {
            ObjBOL.Operation = 1;
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            int index = 0;
            if (ds.Tables[index].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlIssueLookup, ds.Tables[index]);
            }

            index = 1;
            if (ds.Tables[index].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlJobLookup, ds.Tables[index]);
            }

            index = 2;
            if (ds.Tables[index].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlImpact, ds.Tables[index]);
            }

            index = 3;
            if (ds.Tables[index].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCategory, ds.Tables[index]);
            }

            index = 4;
            if (ds.Tables[index].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlResponsiblePerson, ds.Tables[index]);
            }

            index = 5;
            if (ds.Tables[index].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlVerificationOutcome, ds.Tables[index]);
            }

            index = 6;
            if (ds.Tables[index].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlStatus, ds.Tables[index]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlIssueLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlIssueLookup_SelectedIndexChanged();
    }

    private void ddlIssueLookup_SelectedIndexChanged()
    {
        try
        {
            ResetExceptLookup();
            if (ddlIssueLookup.SelectedIndex > 0)
            {
                GetIssueInfo();
                ObjBOL.Operation = 2;
                ObjBOL.IssueNo = ddlIssueLookup.SelectedValue;
                string job = ObjBLL.Return_String(ObjBOL).Trim();
                if (job.Length > 0)
                {
                    if (ddlJobLookup.Items.FindByValue(job) != null)
                    {
                        ddlJobLookup.SelectedValue = job;
                    }
                    else
                    {
                        ddlJobLookup.SelectedIndex = 0;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlJobLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlJobLookup_SelectedIndexChanged();
    }

    private void ddlJobLookup_SelectedIndexChanged()
    {
        try
        {
            ResetExceptLookup();
            if (ddlJobLookup.SelectedIndex > 0)
            {
                ObjBOL.Operation = 3;
                ObjBOL.JobId = ddlJobLookup.SelectedValue;
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlIssueLookup, ds.Tables[0]);
                    ddlIssueLookup.SelectedIndex = ds.Tables[0].Rows.Count;
                    GetIssueInfo();
                }
                else
                {
                    ddlIssueLookup.Items.Clear();
                }
            }
            else
            {
                BindAllIssuesAndJobs(true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetIssueInfo()
    {
        try
        {
            if (ddlIssueLookup.SelectedIndex > 0)
            {
                ObjBOL.Operation = 9;
                ObjBOL.IssueNo = ddlIssueLookup.SelectedValue;
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    txtIssueNo.Text = dr["IssueNo"].ToString();
                    txtDateIdentified.Text = dr["DateIdentified"].ToString();
                    txtSearchJobID.Text = dr["JobId"].ToString();
                    SyncTextbox("NAME", txtSearchJobID.Text);
                    btnSaveMain.Text = "Update";
                }

                gvDetail.DataSource = ds.Tables[1];
                gvDetail.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindAllIssuesAndJobs(bool IssueOnly)
    {
        try
        {
            ObjBOL.Operation = 4;
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlIssueLookup, ds.Tables[0]);
            }
            else
            {
                ddlIssueLookup.Items.Clear();
            }

            if (!IssueOnly)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlJobLookup, ds.Tables[1]);
                }
                else
                {
                    ddlJobLookup.Items.Clear();
                }
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

    protected void btnCancel_Click()
    {
        try
        {
            ResetExceptLookup();
            BindAllIssuesAndJobs(false);
            if (ddlIssueLookup.Items.Count > 0)
            {
                ddlIssueLookup.SelectedIndex = 0;
            }

            if (ddlJobLookup.Items.Count > 0)
            {
                ddlJobLookup.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetExceptLookup()
    {
        try
        {
            txtIssueNo.Text = string.Empty;
            txtDateIdentified.Text = string.Empty;
            txtSearchJobID.Text = string.Empty;
            txtSearchPName.Text = string.Empty;
            txtIssueDescription.Text = string.Empty;
            txtRootCause.Text = string.Empty;
            if (ddlImpact.Items.Count > 0)
            {
                ddlImpact.SelectedIndex = 0;
            }

            if (ddlCategory.Items.Count > 0)
            {
                ddlCategory.SelectedIndex = 0;
            }

            txtInitialActionTaken.Text = string.Empty;
            txtCorrectiveAction.Text = string.Empty;
            txtPreventiveAction.Text = string.Empty;

            if (ddlResponsiblePerson.Items.Count > 0)
            {
                ddlResponsiblePerson.SelectedIndex = 0;
            }

            txtVerificationDate.Text = string.Empty;

            if (ddlVerificationOutcome.Items.Count > 0)
            {
                ddlVerificationOutcome.SelectedIndex = 0;
            }

            rdbFollowupRequired.SelectedValue = "1";
            txtFollowupDate.Enabled = false;
            txtFollowupDate.Text = string.Empty;
            txtComments.Text = string.Empty;

            if (ddlStatus.Items.Count > 0)
            {
                ddlStatus.SelectedIndex = 0;
            }

            gvDetail.DataSource = string.Empty;
            gvDetail.DataBind();
            hfDetailId.Value = "-1";
            btnSaveMain.Text = "Save";
            btnSaveDetail.Text = "Save Detail";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void SearchJobIDButton_Click(object sender, EventArgs e)
    {
        SearchJobIDButton_Click();
    }

    private void SearchJobIDButton_Click()
    {
        try
        {
            if (txtSearchJobID.Text != "")
            {
                ObjBOL.Operation = 5;
                ObjBOL.JobId = txtSearchJobID.Text;
                string returnStatus = ObjBLL.Return_String(ObjBOL).Trim();
                if (returnStatus != "S")
                {
                    Utility.ShowMessage_Error(Page, "Please enter a valid Job !");
                    txtSearchJobID.Text = string.Empty;
                    return;
                }

                SyncTextbox("NAME", txtSearchJobID.Text);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void SearchPNameButton_Click(object sender, EventArgs e)
    {
        SearchPNameButton_Click();
    }

    private void SearchPNameButton_Click()
    {
        try
        {
            if (txtSearchPName.Text != "")
            {
                string output = txtSearchPName.Text;
                int openTagEndPosition = output.IndexOf("#");
                output = output.Substring(openTagEndPosition + 1);
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
                        txtSearchJobID.Text = text;
                    }
                    else
                    {
                        txtSearchJobID.Text = "";
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
                        txtSearchJobID.Text = "";
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

    protected void btnNew_Click(object sender, EventArgs e)
    {
        btnNew_Click();
    }

    private void btnNew_Click()
    {
        try
        {
            btnCancel_Click();
            ObjBOL.Operation = 6;

            string returnValue = ObjBLL.Return_String(ObjBOL).Trim();
            if (returnValue.Length > 4)
            {
                txtIssueNo.Text = returnValue;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationCheckMain()
    {
        try
        {
            if (txtIssueNo.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please generate Issue !!");
                btnNew.Focus();
                return false;
            }

            if (txtDateIdentified.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Date identified !!");
                txtDateIdentified.Focus();
                return false;
            }

            if (txtSearchJobID.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Job# !!");
                txtSearchJobID.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnSaveMain_Click(object sender, EventArgs e)
    {
        btnSaveMain_Click();
    }

    private void btnSaveMain_Click()
    {
        try
        {
            if (ValidationCheckMain())
            {
                string message = "Record inserted successfully !!";
                string operation = "Save";
                ObjBOL.Operation = 7;
                if (ddlIssueLookup.SelectedIndex > 0)
                {
                    ObjBOL.Operation = 8;
                    message = "Record updated successfully !!";
                    operation = "Update";
                }

                ObjBOL.IssueNo = txtIssueNo.Text;
                ObjBOL.DateIdentified = Utility.ConvertDate(txtDateIdentified.Text);
                ObjBOL.JobId = txtSearchJobID.Text;
                string returnStatus = ObjBLL.Return_String(ObjBOL).Trim();

                if (returnStatus == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "Issue No already exists !!");
                    return;
                }

                if (returnStatus == "ER02")
                {
                    Utility.ShowMessage_Error(Page, "Issue already exists for this Job and Date Identified !!");
                    return;
                }

                if (returnStatus == "S")
                {
                    Utility.MaintainLogsSpecial(formName, operation, txtIssueNo.Text);
                    Utility.ShowMessage_Success(Page, message);
                    ReloadLookupAndSelect();
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ReloadLookupAndSelect()
    {
        try
        {
            string Issue = txtIssueNo.Text;
            btnCancel_Click();
            BindAllIssuesAndJobs(false);
            if (ddlIssueLookup.Items.FindByValue(Issue) != null)
            {
                ddlIssueLookup.SelectedValue = Issue;
                ddlIssueLookup_SelectedIndexChanged();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSaveDetail_Click(object sender, EventArgs e)
    {
        btnSaveDetail_Click();
    }

    private bool ValidationCheckDetail()
    {
        try
        {
            if (ddlIssueLookup.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Issue !!");
                ddlIssueLookup.Focus();
                return false;
            }

            if (txtIssueDescription.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Issue description !!");
                txtIssueDescription.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void btnSaveDetail_Click()
    {
        try
        {
            if (ValidationCheckDetail())
            {
                string message = "Record inserted successfully !!";
                string operation = "Save Detail";
                ObjBOL.Operation = 10;
                if (Int32.Parse(hfDetailId.Value) > 0)
                {
                    ObjBOL.Operation = 12;
                    ObjBOL.Id = Int32.Parse(hfDetailId.Value);
                    message = "Record updated successfully !!";
                    operation = "Update Detail";
                }

                ObjBOL.IssueNo = txtIssueNo.Text;
                ObjBOL.IssueDescription = txtIssueDescription.Text;
                ObjBOL.RootCause = txtRootCause.Text;

                if (ddlImpact.SelectedIndex > 0)
                {
                    ObjBOL.ImpactId = Int32.Parse(ddlImpact.SelectedValue);
                }

                if (ddlCategory.SelectedIndex > 0)
                {
                    ObjBOL.CategoryId = Int32.Parse(ddlCategory.SelectedValue);
                }

                ObjBOL.InitialActionTaken = txtInitialActionTaken.Text;
                ObjBOL.CorrectiveAction = txtCorrectiveAction.Text;
                ObjBOL.PreventiveAction = txtPreventiveAction.Text;

                if (ddlResponsiblePerson.SelectedIndex > 0)
                {
                    ObjBOL.ResponsiblePerson = Int32.Parse(ddlResponsiblePerson.SelectedValue);
                }

                ObjBOL.VerificationDate = Utility.ConvertDate(txtVerificationDate.Text);

                if (ddlVerificationOutcome.SelectedIndex > 0)
                {
                    ObjBOL.VerificationOutcomeId = Int32.Parse(ddlVerificationOutcome.SelectedValue);
                }

                ObjBOL.FollowupRequired = Int32.Parse(rdbFollowupRequired.SelectedValue);
                ObjBOL.FollowupDate = Utility.ConvertDate(txtFollowupDate.Text);
                ObjBOL.Comments = txtComments.Text;

                if (ddlStatus.SelectedIndex > 0)
                {
                    ObjBOL.StatusId = Int32.Parse(ddlStatus.SelectedValue);
                }

                string returnStatus = ObjBLL.Return_String(ObjBOL).Trim();

                if (returnStatus.Length > 0)
                {
                    Utility.MaintainLogsSpecial(formName, operation, returnStatus);
                    Utility.ShowMessage_Success(Page, message);
                    ReloadLookupAndSelect();
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            ObjBOL.Operation = 11;
            int ID = Convert.ToInt32(gvDetail.DataKeys[e.NewEditIndex].Values[0]);
            ObjBOL.Id = ID;
            hfDetailId.Value = ID.ToString();
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
                {
                    { "IssueDescription", d => txtIssueDescription.Text = Convert.ToString(d["IssueDescription"]) },
                    { "RootCause", d => txtRootCause.Text = Convert.ToString(d["RootCause"]) },
                    { "ImpactId", d =>
                        {
                            if (ddlImpact.Items.FindByValue(Convert.ToString(d["ImpactId"])) != null)
                            {
                                ddlImpact.SelectedValue = Convert.ToString(d["ImpactId"]);
                            }
                            else if(ddlImpact.Items.Count > 0)
                            {
                                ddlImpact.SelectedIndex = 0;
                            }
                        }
                    },
                    { "CategoryId", d =>
                        {
                            if (ddlCategory.Items.FindByValue(Convert.ToString(d["CategoryId"])) != null)
                            {
                                ddlCategory.SelectedValue = Convert.ToString(d["CategoryId"]);
                            }
                            else if(ddlCategory.Items.Count > 0)
                            {
                                ddlCategory.SelectedIndex = 0;
                            }
                        }
                    },
                     { "InitialActionTaken", d => txtInitialActionTaken.Text = Convert.ToString(d["InitialActionTaken"]) },
                     { "CorrectiveAction", d => txtCorrectiveAction.Text = Convert.ToString(d["CorrectiveAction"]) },
                     { "PreventiveAction", d => txtPreventiveAction.Text = Convert.ToString(d["PreventiveAction"]) },
                     { "ResponsiblePerson", d =>
                        {
                            if (ddlResponsiblePerson.Items.FindByValue(Convert.ToString(d["ResponsiblePerson"])) != null)
                            {
                                ddlResponsiblePerson.SelectedValue = Convert.ToString(d["ResponsiblePerson"]);
                            }
                            else if(ddlResponsiblePerson.Items.Count > 0)
                            {
                                ddlResponsiblePerson.SelectedIndex = 0;
                            }
                        }
                    },
                    { "VerificationDate", d => txtVerificationDate.Text = Convert.ToString(d["VerificationDate"]) },
                    { "VerificationOutcomeId", d =>
                        {
                            if (ddlVerificationOutcome.Items.FindByValue(Convert.ToString(d["VerificationOutcomeId"])) != null)
                            {
                                ddlVerificationOutcome.SelectedValue = Convert.ToString(d["VerificationOutcomeId"]);
                            }
                            else if(ddlVerificationOutcome.Items.Count > 0)
                            {
                                ddlVerificationOutcome.SelectedIndex = 0;
                            }
                        }
                    },
                    { "FollowupRequired", d =>
                        {
                            if (rdbFollowupRequired.Items.FindByValue(Convert.ToString(d["FollowupRequired"])) != null)
                            {
                                rdbFollowupRequired.SelectedValue = Convert.ToString(d["FollowupRequired"]);
                            }
                            else if(rdbFollowupRequired.Items.Count > 0)
                            {
                                rdbFollowupRequired.SelectedIndex = 0;
                            }
                            rdbFollowupRequired_SelectedIndexChanged();
                        }
                    },
                    { "FollowupDate", d => txtFollowupDate.Text = Convert.ToString(d["FollowupDate"]) },
                    { "Comments", d => txtComments.Text = Convert.ToString(d["Comments"]) },
                    { "Status", d =>
                        {
                            if (ddlStatus.Items.FindByValue(Convert.ToString(d["Status"])) != null)
                            {
                                ddlStatus.SelectedValue = Convert.ToString(d["Status"]);
                            }
                            else if(ddlStatus.Items.Count > 0)
                            {
                                ddlStatus.SelectedIndex = 0;
                            }
                        }
                    }
                };

                foreach (var assignment in assignments)
                {
                    try
                    {
                        assignment.Value(dr);
                    }
                    catch (Exception ex)
                    {
                        Utility.AddEditException(ex, assignment.Key);
                    }
                }

                btnSaveDetail.Text = "Update Detail";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int ID = Convert.ToInt32(gvDetail.DataKeys[e.RowIndex].Values[0]);
            ObjBOL.Operation = 13;
            ObjBOL.Id = ID;
            string returnStatus = ObjBLL.Return_String(ObjBOL).Trim();
            if (returnStatus == "S")
            {
                Utility.MaintainLogsSpecial(formName, "Delete", ddlIssueLookup.SelectedValue);
                Utility.ShowMessage_Success(Page, "Record deleted successfully !!");
                ReloadLookupAndSelect();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnFilterForm_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Reports/FrmShopDwgIssueLogReport.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void rdbFollowupRequired_SelectedIndexChanged(object sender, EventArgs e)
    {
        rdbFollowupRequired_SelectedIndexChanged();
    }

    private void rdbFollowupRequired_SelectedIndexChanged()
    {
        try
        {
            if (rdbFollowupRequired.SelectedValue == "1")
            {
                txtFollowupDate.Enabled = false;
            }
            else
            {
                txtFollowupDate.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}