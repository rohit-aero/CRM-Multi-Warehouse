using System;
using System.Collections.Generic;
using System.Data;
using BLLAERO;
using BOLAERO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class SalesManagement_FrmDailyQuoteReport : System.Web.UI.Page
{
    BLLDailyQuoteReport ObjBLL = new BLLDailyQuoteReport();
    BOLDailyQuoteReport ObjBOL = new BOLDailyQuoteReport();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Utility.IsAuthorized())
                {
                    CheckPermission();
                    BindControls();
                    if (Request.QueryString["pNumber"] != null)
                    {
                        txtSearchPNum.Text = Request.QueryString["pNumber"];
                        txtSearchPNum_TextChanged_Event();
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckPermission()
    {
        try
        {
            ObjBOL.Operation = 7;
            ObjBOL.ID = Utility.GetCurrentUser();
            string returnStatus = ObjBLL.GetString(ObjBOL);
            if (returnStatus.Trim() == "1")
            {
                txtRemarksByTL.Visible = true;
                lblRemarksByTL.Visible = true;
            }
            else
            {
                txtRemarksByTL.Visible = false;
                lblRemarksByTL.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindControls()
    {
        try
        {
            ObjBOL.Operation = 1;
            DataSet ds = ObjBLL.GetDataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlNature, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlStatus, ds.Tables[1]);
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectEngineer, ds.Tables[2]);
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPNumberHeaderList, ds.Tables[3]);
            }

            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlOptions, ds.Tables[4]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Boolean ValidationCheck()
    {
        try
        {
            if (txtSearchPNum.Text.Trim() == "" || txtSearchPName.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Select PNumber !");
                txtSearchPNum.Focus();
                return false;
            }

            if (txtSearchPName.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Select Project Name !");
                txtSearchPName.Focus();
                return false;
            }

            if (ddlNature.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Nature of Task. !");
                ddlNature.Focus();
                return false;
            }

            if (ddlStatus.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                ddlNature.Focus();
                return false;
            }
            else if (ddlStatus.SelectedValue == "4")
            {
                if (txtQuoteSent.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Date Quote Sent out. !");
                    txtQuoteSent.Focus();
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void ddlPNumberHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPNumberHeaderList_Event(true);
    }

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

    protected void btnQuoteReport_Click(object sender, EventArgs e)
    {
        btnQuoteReport_Click_Event();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave_Event();
    }

    protected void gvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int ID = Convert.ToInt32(gvDetail.DataKeys[e.RowIndex].Values[0]);
            ObjBOL.Operation = 6;
            ObjBOL.ID = ID;
            string return_msg = ObjBLL.GetString(ObjBOL);
            if (return_msg != "")
            {
                Utility.MaintainLogsSpecial("DailyQuoteReport", "Delete", ddlPNumberHeaderList.SelectedValue);
                Utility.ShowMessage_Success(Page, return_msg);
                var PNumber = ddlPNumberHeaderList.SelectedValue;
                Reset();
                ddlPNumberHeaderList.SelectedValue = PNumber;
                ddlPNumberHeaderList_Event(true);
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
            DisableSubHeaderSection();
            DataSet ds = new DataSet();
            int ID = Convert.ToInt32(gvDetail.DataKeys[e.NewEditIndex].Values[0]);
            HiddenDetailID.Value = ID.ToString();
            ObjBOL.Operation = 5;
            ObjBOL.ID = ID;
            ds = ObjBLL.GetDataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                ddlNature.SelectedValue = row["NatureID"].ToString();
                ddlStatus.SelectedValue = row["StatusID"].ToString();

                if (row["OptionID"].ToString() != "")
                {
                    ddlOptions.SelectedValue = row["OptionID"].ToString();
                }

                if (row["ProjectEngineerID"].ToString() != "")
                {
                    ddlProjectEngineer.SelectedValue = row["ProjectEngineerID"].ToString();
                }
                if (row["Priority"].ToString() != "")
                {
                    ddlPriority.SelectedValue = row["Priority"].ToString();
                }
                else
                {
                    ddlPriority.SelectedValue = "1";
                }
                txtReqByCustomer.Text = row["ReqByCustomer"].ToString();
                txtReqForwardedToQuoteTeam.Text = row["SentQuoteRequest"].ToString();
                txtQuoteSent.Text = row["SentToCustomer"].ToString();
                txtRemarks.Text = row["Remarks"].ToString();
                txtRemarksByTL.Text = row["RemarksByTL"].ToString();
                btnSave.Text = "Update";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtSearchJobID_TextChanged(object sender, EventArgs e)
    {
        txtSearchJobID_TextChanged_Event();
    }

    protected void txtSearchPNum_TextChanged(object sender, EventArgs e)
    {
        txtSearchPNum_TextChanged_Event();
    }

    protected void txtSearchPName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtSearchPName.Text != "")
            {
                string output = txtSearchPName.Text;
                int openTagEndPosition = output.IndexOf("#");
                output = output.Substring(openTagEndPosition + 1);
                SyncTextbox("NAME", output);
                LoadRelevantInfoForPNumber(true);
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
            Response.Redirect("~/Reports/frmQuoteReport.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void txtSearchJobID_TextChanged_Event()
    {
        try
        {
            if (txtSearchJobID.Text != "")
            {
                DataTable dt = new DataTable();
                string OutJnumber = "";
                OutJnumber = txtSearchJobID.Text;
                //SyncTextbox("JOB", OutJnumber);
                dt = Utility.ReturnProjects(27, OutJnumber);
                if (dt.Rows.Count > 0)
                {
                    txtSearchPNum.Text = Convert.ToString(Utility.ReturnProjects(27, OutJnumber).Rows[0]["PNumber"]);
                    LoadRelevantInfoForPNumber(true);
                }               
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void txtSearchPNum_TextChanged_Event()
    {
        try
        {
            if (txtSearchPNum.Text != "")
            {
                string OutPnumber = "";
                OutPnumber = txtSearchPNum.Text;
                DataTable dt = Utility.ReturnProposals(36, OutPnumber);
                if (dt.Rows.Count > 0)
                {
                    txtSearchPNum.Text = Convert.ToString(dt.Rows[0]["PNumber"]);
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "P# not found");
                }
                //SyncTextbox("NUM", OutPnumber);
                LoadRelevantInfoForPNumber(true);
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
                    dt = Utility.ReturnProposals(36, text);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchPName.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                        txtSearchJobID.Text = Convert.ToString(dt.Rows[0]["JobID"]);
                        GetProjectManager();
                    }
                    else
                    {
                        Utility.ShowMessage_Error(Page, "P# not found");
                        txtSearchPName.Text = "";
                        txtSearchPNum.Text = "";
                    }
                }
                else if (type == "NAME")
                {
                    dt = Utility.ReturnProposals(36, text);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchPNum.Text = Convert.ToString(dt.Rows[0]["PNumber"]);
                        txtSearchJobID.Text = Convert.ToString(dt.Rows[0]["JobID"]);
                        GetProjectManager();
                    }
                    else
                    {
                        Utility.ShowMessage_Error(Page, "PName not found");
                        txtSearchPNum.Text = "";
                        txtSearchPName.Text = "";
                    }
                }
                else if (type == "JOB")
                {
                    dt = Utility.ReturnProjects(27, text);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchPNum.Text = Convert.ToString(dt.Rows[0]["PNumber"]);
                        txtSearchPName.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                        GetProjectManager();
                    }
                    else
                    {
                        Utility.ShowMessage_Error(Page, "J# not found");
                        txtSearchPNum.Text = "";
                        txtSearchPName.Text = "";
                    }
                }

                if (ddlPNumberHeaderList.Items.FindByValue(txtSearchPNum.Text) != null)
                {
                    ddlPNumberHeaderList.SelectedValue = txtSearchPNum.Text;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlPNumberHeaderList_Event(bool callEvent)
    {
        try
        {
            EnableSubHeaderSection();
            if (ddlPNumberHeaderList.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.PNumber = ddlPNumberHeaderList.SelectedValue;
                //LoadQuoteDetail();
                txtSearchPNum.Text = ddlPNumberHeaderList.SelectedValue;
                SyncTextbox("NUM", ddlPNumberHeaderList.SelectedValue);
                LoadRelevantInfoForPNumber(callEvent);
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

    private void LoadRelevantInfoForPNumber(bool enableFeature)
    {
        try
        {
            string proposalNumber = txtSearchPNum.Text;
            if (enableFeature)
            {
                Reset();
                txtSearchPNum.Text = proposalNumber;
                SyncTextbox("NUM", proposalNumber);
                if (ddlPNumberHeaderList.Items.FindByValue((proposalNumber).ToUpper()) != null)
                {
                    ddlPNumberHeaderList.SelectedValue = (proposalNumber).ToUpper();
                    LoadQuoteDetail();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void LoadQuoteDetail()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.PNumber = ddlPNumberHeaderList.SelectedValue;
            ds = ObjBLL.GetDataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetail.DataSource = ds.Tables[0];
                ViewState["dirState"] = ds.Tables[0];
                gvDetail.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableSubHeaderSection()
    {
        try
        {
            txtSearchPNum.Enabled = false;
            txtSearchPName.Enabled = false;
            txtSearchJobID.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableSubHeaderSection()
    {
        try
        {
            txtSearchPNum.Enabled = true;
            txtSearchPName.Enabled = true;
            txtSearchJobID.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnSave_Event()
    {
        try
        {
            if (ValidationCheck())
            {
                ObjBOL.NatureID = Convert.ToInt32(ddlNature.SelectedValue);

                if (ddlOptions.SelectedIndex > 0)
                {
                    ObjBOL.OptionID = Convert.ToInt32(ddlOptions.SelectedValue);
                }

                if (ddlProjectEngineer.SelectedIndex > 0)
                {
                    ObjBOL.ProjectEngineerID = Convert.ToInt32(ddlProjectEngineer.SelectedValue);
                }

                if (ddlStatus.SelectedIndex > 0)
                {
                    ObjBOL.StatusID = Convert.ToInt32(ddlStatus.SelectedValue);
                }

                if (txtReqByCustomer.Text != "")
                {
                    ObjBOL.ReqByCustomer = Utility.ConvertDate(txtReqByCustomer.Text);
                }

                if (txtReqForwardedToQuoteTeam.Text != "")
                {
                    ObjBOL.SentQuoteRequest = Utility.ConvertDate(txtReqForwardedToQuoteTeam.Text);
                }

                if (txtQuoteSent.Text != "")
                {
                    ObjBOL.SentToCustomer = Utility.ConvertDate(txtQuoteSent.Text);
                }

                ObjBOL.Remarks = txtRemarks.Text;
                ObjBOL.RemarksByTL = txtRemarksByTL.Text;
                ObjBOL.PNumber = txtSearchPNum.Text.ToUpper();
                ObjBOL.Priority = ddlPriority.SelectedValue;
                string return_msg = "";
                if (btnSave.Text == "Save")
                {
                    ObjBOL.Operation = 2;
                    return_msg = ObjBLL.GetString(ObjBOL);
                }

                if (btnSave.Text == "Update")
                {
                    ObjBOL.Operation = 3;
                    ObjBOL.ID = Convert.ToInt32(HiddenDetailID.Value);
                    return_msg = ObjBLL.GetString(ObjBOL);
                }

                if (return_msg != "")
                {
                    Utility.MaintainLogsSpecial("DailyQuoteReport", btnSave.Text, txtSearchPNum.Text);
                    Utility.ShowMessage_Success(Page, return_msg);
                    var PNumber = txtSearchPNum.Text.ToUpper();
                    Reset();
                    BindControls();
                    ddlPNumberHeaderList.SelectedValue = PNumber;
                    ddlPNumberHeaderList_Event(true);
                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            DataSet ds = new DataSet();
            ds = ObjBLL.BindReport(ObjBOL);
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

    private void btnQuoteReport_Click_Event()
    {
        try
        {
            DataTable dt = ReportData();
            rprt.Load(Server.MapPath("~/Reports/rptDailyQuoteReport.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Quote Daily Report - " + DateTime.Now.ToString("dddd, dd MMMM yyyy").Replace(',', ' ');
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
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

    private void GetProjectManager()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 8;
            ObjBOL.PNumber = txtSearchPNum.Text.ToUpper();
            ds = ObjBLL.GetDataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtProjectManager.Text = ds.Tables[0].Rows[0][0].ToString();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #region Reset

    private void Reset()
    {
        try
        {
            //BindControls();
            EnableSubHeaderSection();

            if (ddlPNumberHeaderList.Items.Count > 0)
            {
                ddlPNumberHeaderList.SelectedIndex = 0;
            }

            txtSearchJobID.Text = string.Empty;
            txtSearchPName.Text = string.Empty;
            txtSearchPNum.Text = string.Empty;

            ResetInfo();
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void ResetInfo()
    {
        try
        {
            gvDetail.DataSource = "";
            gvDetail.DataBind();

            if (ddlOptions.Items.Count > 0)
            {
                ddlOptions.SelectedIndex = 0;
            }

            if (ddlNature.Items.Count > 0)
            {
                ddlNature.SelectedIndex = 0;
            }

            if (ddlStatus.Items.Count > 0)
            {
                ddlStatus.SelectedIndex = 0;
            }

            if (ddlProjectEngineer.Items.Count > 0)
            {
                ddlProjectEngineer.SelectedIndex = 0;
            }

            txtProjectManager.Text = string.Empty;
            txtReqByCustomer.Text = string.Empty;
            txtReqForwardedToQuoteTeam.Text = string.Empty;
            txtQuoteSent.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtRemarksByTL.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion
}