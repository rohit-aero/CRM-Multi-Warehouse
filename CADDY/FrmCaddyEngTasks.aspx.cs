using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class CADDY_FrmCaddyEngTasks : System.Web.UI.Page
{
    BOLCADDYENGTasks ObjBOL = new BOLCADDYENGTasks();
    BLLManageCADDYENGTasks ObjBLL = new BLLManageCADDYENGTasks();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Utility.IsAuthorized())
            {
                if (Session["JobNo"] != null)
                {
                    var JobNo = Session["JobNo"].ToString();
                    AutofillDetailsByJobNo(JobNo);
                }
                BindLookUp();
                Bind_Status();
                CheckPermission();
                Bind_ProjectType();
                Bind_ProjectManager();
                Session["JobNo"] = null;
            }
            
        }
    }
    #region Bind Project Manager Drop Down
    public void Bind_ProjectManager()
    {
        try
        {
            if(txtJobType.Text == "Hood")
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 17;
                ds = ObjBLL.GetControls(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlProjectManager, ds.Tables[0]);
                    ddlProjectManager.SelectedIndex = 0;
                }
            }
                      
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Project Manager Text Box Permission Check
    private void CheckPermission()
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 12;
            ObjBOL.EmployeeID = Utility.GetCurrentSession().EmployeeID;
            msg = ObjBLL.CheckPermission(ObjBOL);
            if (msg == "1")
            {
                hfCheckProjectManageID.Value = msg;
                dvProjectManager.Visible = true;
            }
            else
            {
                hfCheckProjectManageID.Value = msg;
                dvProjectManager.Visible = false;
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }  
    #endregion

    #region Look Up Drop Down Bind
    private void BindLookUp()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPNumberHeaderList, ds.Tables[0]);
            }
            else
            {
                ddlPNumberHeaderList.DataSource = "";
                ddlPNumberHeaderList.DataBind();
                ddlPNumberHeaderList.Items.Insert(0, new ListItem("Select", "0"));
            }                      
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void Bind_Status()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlStatus, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);            
        }
    }   
    #endregion

    #region Validation Check
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtJobNumber.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Job Number !");
                txtJobNumber.Focus();
                return false;
            }
            if (txtJobName.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Job Name !");
                txtJobNumber.Focus();
                return false;
            }
            if (ddlProjectType.SelectedValue == "0")
            {
                Utility.ShowMessage_Error(Page, "Please Select Project Type !");
                ddlProjectType.Focus();
                return false;
            }
            if(txtJobType.Text == "Hood")
            {
                if(txtItemNo.Text=="")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Item No. !");
                    txtItemNo.Focus();
                    return false;
                }
                if (ddlModelType.SelectedValue == "0")
                {
                    Utility.ShowMessage_Error(Page, "Please Select Model Type. !");
                    ddlModelType.Focus();
                    return false;
                }
            }
            if (ddlPriority.SelectedValue == "0")
            {
                Utility.ShowMessage_Error(Page, "Please Select Priority!");
                ddlPriority.Focus();
                return false;
            }
            if (ddlStatus.SelectedValue == "0")
            {
                Utility.ShowMessage_Error(Page, "Please Select Status !");
                ddlStatus.Focus();
                return false;
            }
            if(ddlStatus.SelectedValue=="3")
            {
                if(ddlProgress.SelectedValue=="-1")
                {
                    Utility.ShowMessage_Error(Page, "Please Select Progress !");
                    ddlProgress.Focus();
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
    #endregion

    #region Bind Grid With Auto Complete Text Box
    private void BindGrid(string JobNo)
    {
        try
        {            
            DataSet ds = new DataSet();
            ObjBOL.Operation = 6;
            ObjBOL.JobNo = JobNo;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnGenerateReport.Enabled = true;
                gvTaskDetails.Visible = true;
                gvCadEngTasks.DataSource = ds.Tables[0];
                gvCadEngTasks.DataBind();
                if (hfJobType.Value == "Hood")
                {
                    gvCadEngTasks.Columns[1].Visible = true;
                    gvCadEngTasks.Columns[2].Visible = true;
                    gvCadEngTasks.Columns[3].Visible = true;
                    gvCadEngTasks.Columns[5].Visible = false;
                }
                else
                {
                    gvCadEngTasks.Columns[1].Visible = false;
                    gvCadEngTasks.Columns[2].Visible = false;
                    gvCadEngTasks.Columns[3].Visible = false;
                    gvCadEngTasks.Columns[5].Visible = true;
                }
                if (hfCheckProjectManageID.Value=="1")
                {
                    gvCadEngTasks.Columns[14].Visible = true;
                    gvCadEngTasks.Columns[14].Visible = true;
                }
                else
                {
                    gvCadEngTasks.Columns[14].Visible = false;
                }                
            }
            else
            {
                gvCadEngTasks.DataSource = "";
                gvCadEngTasks.DataBind();
                btnGenerateReport.Enabled = false;                
                gvTaskDetails.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion
    private void DivVisibleTrue()
    {
        try
        {
            dvItemNo.Visible = true;
            dvModelType.Visible = true;
            DivProjectManager.Visible = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DivVisibleFalse()
    {
        try
        {
            dvItemNo.Visible = false;
            dvModelType.Visible = false;
            DivProjectManager.Visible = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    #region Fill Detail on Job No/Job Name Auto Complete
    private void FillDetails(String JobNo)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 6;
            ObjBOL.JobNo = JobNo;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hfProjectID.Value = ds.Tables[0].Rows[0]["ProjectID"].ToString();
                txtJobNumber.Text = ds.Tables[0].Rows[0]["JobNo"].ToString();
                txtJobName.Text = ds.Tables[0].Rows[0]["JobName"].ToString();
                txtJobType.Text = ds.Tables[0].Rows[0]["JobType"].ToString();
                txtProjManaCaddy.Text = ds.Tables[0].Rows[0]["PMCaddy"].ToString();
                gvTaskDetails.Visible = true;
                gvCadEngTasks.DataSource = ds.Tables[0];
                gvCadEngTasks.DataBind();
                if (txtJobType.Text == "Hood")
                {
                    DivVisibleTrue();
                    BindCorrection(txtJobType.Text);
                    Bind_ProjectManager();
                    gvCadEngTasks.Columns[1].Visible = true;
                    gvCadEngTasks.Columns[2].Visible = true;
                    gvCadEngTasks.Columns[3].Visible = true;
                    gvCadEngTasks.Columns[5].Visible = false;
                }
                else
                {
                    DivVisibleFalse();
                    BindCorrection(txtJobType.Text);
                    Bind_ProjectManager();
                    gvCadEngTasks.Columns[1].Visible = false;
                    gvCadEngTasks.Columns[2].Visible = false;
                    gvCadEngTasks.Columns[3].Visible = false;
                    gvCadEngTasks.Columns[5].Visible = true;
                }
                if (hfCheckProjectManageID.Value == "1")
                {
                    gvCadEngTasks.Columns[14].Visible = true;
                }
                else
                {
                    gvCadEngTasks.Columns[14].Visible = false;
                }
            }
            else
            {
                gvTaskDetails.Visible = false;
            }
            Bind_Models(JobNo);
            BindModels(hfProjectID.Value, "");
            if (txtJobType.Text != "")
            {
                SyncEmployees("", txtJobType.Text);
            }
            else
            {
                ddlAssignedToEng.Items.Clear();
            }
            if (ddlPNumberHeaderList.SelectedIndex == 0)
            {
                ddlPNumberHeaderList.SelectedValue = JobNo;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Bind Models
    private void Bind_Models(string JobNo)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 10;
            ObjBOL.JobNo = JobNo;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string modelname = string.Empty;
                List<String> stringArr = new List<String>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    stringArr.Add(ds.Tables[0].Rows[i]["ModelName"].ToString());
                    modelname = string.Join("/", stringArr.ToArray());
                }
                txtModels.Text = modelname;
            }
            else
            {
                txtModels.Text = String.Empty;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Bind Project Type
    private void Bind_ProjectType()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 11;           
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectType, ds.Tables[0]);
                ddlProjectType.SelectedIndex = 0;
            }
            else
            {
                ddlProjectType.DataSource = "";
                ddlProjectType.DataBind();
                ddlProjectType.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Reset/Cancel Button
    private void Reset()
    {
        try
        {
            txtJobNumber.Text = String.Empty;
            txtJobName.Text = String.Empty;
            txtModels.Text = String.Empty;           
            txtProjManaCaddy.Text = String.Empty;
            txtJobType.Text = String.Empty;
            ResetTaskInfo();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetTaskInfo()
    {
        try
        {
            ddlProjectType.SelectedIndex = 0;
            ddlNatureOfTask.SelectedIndex = 0;
            dvCorrection.Visible = false;
            txtCorrection.Text = String.Empty;
            if (txtJobType.Text == "Hood")
            {
                ddlProjectManager.SelectedIndex = 0;
                if (ddlModelType.SelectedValue == "-1")
                {
                    ddlModelType.Items.Clear();
                }
                else
                {
                    ddlModelType.SelectedIndex = 0;
                }
                txtItemNo.Text = String.Empty;
            }
            rdbProjectAccepted.ClearSelection();
            txtReqForwardToIndia.Text = String.Empty;
            if(ddlAssignedToEng.Items.Count>0)
            {
                ddlAssignedToEng.SelectedIndex = 0;
            }            
            ddlStatus.SelectedIndex = 0;
            pnlProgress.Visible = false;
            ddlProgress.SelectedIndex = -1;
            txtProjectDueDate.Text = String.Empty;
            ddlPriority.SelectedIndex = 0;
            txtProjectSendToCaddy.Text = String.Empty;
            txtRemarks.Text = String.Empty;
            txtRemarksbyPM.Text = String.Empty;
            hfProjectEngID.Value = "-1";
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void TaskDetailsReset()
    {
        try
        {
            ddlPNumberHeaderList.SelectedIndex = 0;
            gvCadEngTasks.DataSource = "";
            gvCadEngTasks.DataBind();
            TextBoxEnabled();
            btnSave.Text = "Save";
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
            TaskDetailsReset();
            ddlAssignedToEng.Items.Clear();
            btnGenerateReport.Enabled = false;
            gvTaskDetails.Visible = false;
            Session["JobNo"] = null;
            DivVisibleFalse();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Save Button
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                SaveDetails();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SaveDetails()
    {
        try
        {
            string msg = "";
            if (hfProjectEngID.Value != "-1")
            {
                ObjBOL.Operation = 8;
                ObjBOL.EngProjectID = Convert.ToInt32(hfProjectEngID.Value);
            }
            else
            {
                ObjBOL.Operation = 4;
            }
            if (hfProjectID.Value != "-1")
            {
                ObjBOL.ProjectID = Convert.ToInt32(hfProjectID.Value);
            }
            if (ddlProjectType.SelectedIndex > 0)
            {
                ObjBOL.ProjectType = Convert.ToInt32(ddlProjectType.SelectedValue);
            }
            if(txtItemNo.Text != "")
            {
                ObjBOL.ItemNo = txtItemNo.Text;
            }
            if(ddlModelType.SelectedIndex>0)
            {
                ObjBOL.ModelId = Convert.ToInt32(ddlModelType.SelectedValue);
            }
            if (ddlNatureOfTask.SelectedIndex > 0)
            {
                ObjBOL.Nature = Convert.ToInt32(ddlNatureOfTask.SelectedValue);
            }
            ObjBOL.Correction = txtCorrection.Text;
            if (txtReqForwardToIndia.Text != "")
            {
                ObjBOL.ReqFWDToIndia = Utility.ConvertDateFormat(txtReqForwardToIndia.Text);
            }
            if (txtProjectDueDate.Text != "")
            {
                ObjBOL.ProjectDueDate = Utility.ConvertDateFormat(txtProjectDueDate.Text);
            }
            if (ddlAssignedToEng.SelectedIndex > 0)
            {
                ObjBOL.AssingedTo = Convert.ToInt32(ddlAssignedToEng.SelectedValue);
            }
            ObjBOL.Priority = Convert.ToInt32(ddlPriority.SelectedValue);
            if (txtProjectSendToCaddy.Text != "")
            {
                ObjBOL.SentToCaddy = Utility.ConvertDateFormat(txtProjectSendToCaddy.Text);
            }
            ObjBOL.Remarks = txtRemarks.Text;
            ObjBOL.RemarksByPM = txtRemarksbyPM.Text;
            if(ddlStatus.SelectedIndex>0)
            {
                ObjBOL.StatusID = Convert.ToInt32(ddlStatus.SelectedValue);
            }
            if (ddlStatus.SelectedIndex>0)
            {
                ObjBOL.Progress = Convert.ToInt32(ddlProgress.SelectedValue);
            }
            if (ddlProjectManager.SelectedIndex > 0)
            {
                ObjBOL.ProjectManagerID = Convert.ToInt32(ddlProjectManager.SelectedValue);
            }
            msg = ObjBLL.SaveEngTaskDetails(ObjBOL);
            if (msg != "Records Updated Successfully !")
            {
                Utility.ShowMessage_Success(Page, "Records Added Successfully !");
                Utility.MaintainLogsSpecial("FrmCaddyEngTasks", "Save", msg);
            }
            else
            {
                Utility.ShowMessage_Success(Page, msg);
                Utility.MaintainLogsSpecial("FrmCaddyEngTasks", "Update", hfProjectEngID.Value);
            }
            BindItemNoOnHood(txtJobType.Text);
            BindGrid(txtJobNumber.Text);            
            ResetTaskInfo();
            if (txtJobNumber.Text != "")
            {
                BindLookUp();
                ddlPNumberHeaderList.SelectedValue = txtJobNumber.Text;
            }
            TextBoxEnabled();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Grid Modify Template
    protected void gvCadEngTasks_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            int ID = Convert.ToInt32(gvCadEngTasks.DataKeys[e.NewEditIndex].Values[0]);
            ObjBOL.Operation = 7;
            ObjBOL.EngProjectID = ID;
            hfProjectEngID.Value = Convert.ToString(ID);
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlProjectType.SelectedValue = ds.Tables[0].Rows[0]["ProjectTypeID"].ToString();
                if (txtJobType.Text == "Hood")
                {
                    DivVisibleTrue();
                    ProjectTypeNesting(ddlProjectType.SelectedValue, txtJobType.Text);
                    txtItemNo.Text = ds.Tables[0].Rows[0]["ItemNo"].ToString();
                    if (ddlModelType.Items.FindByValue(ds.Tables[0].Rows[0]["ModelId"].ToString()) != null)
                    {
                        ddlModelType.SelectedValue = ds.Tables[0].Rows[0]["ModelId"].ToString();
                    }
                    else
                    {
                        ddlModelType.SelectedIndex = 0;
                    }
                }
                else
                {
                    ProjectTypeNesting(ddlProjectType.SelectedValue, txtJobType.Text);
                    BindCorrection(txtJobType.Text);
                    if (ds.Tables[0].Rows[0]["Correction"].ToString() != "")
                    {
                        txtCorrection.Text = ds.Tables[0].Rows[0]["Correction"].ToString();
                    }
                    else
                    {
                        txtCorrection.Text = String.Empty;
                    }
                    DivVisibleFalse();
                    txtItemNo.Text = String.Empty;
                    if (ddlModelType.SelectedIndex > 0)
                    {
                        ddlModelType.DataSource = "";
                        ddlModelType.DataBind();
                    }
                }
                ddlNatureOfTask.SelectedValue = ds.Tables[0].Rows[0]["Nature"].ToString();
                txtReqForwardToIndia.Text = ds.Tables[0].Rows[0]["ReqFWDToIndia"].ToString();
                if (ddlAssignedToEng.Items.FindByValue(ds.Tables[0].Rows[0]["AssingedTo"].ToString()) != null)
                {
                    ddlAssignedToEng.SelectedValue = ds.Tables[0].Rows[0]["AssingedTo"].ToString();
                }
                else
                {
                    ddlAssignedToEng.SelectedIndex = 0;
                }
                ddlPriority.SelectedValue = ds.Tables[0].Rows[0]["Priority"].ToString();
                txtProjectSendToCaddy.Text = ds.Tables[0].Rows[0]["SentToCaddy"].ToString();
                txtProjectDueDate.Text = ds.Tables[0].Rows[0]["ProjectDueDate"].ToString();
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
                    if (ddlStatus.SelectedValue == "3")
                    {
                        pnlProgress.Visible = true;
                    }
                    else
                    {
                        pnlProgress.Visible = false;
                    }
                }
                ddlProgress.SelectedValue = ds.Tables[0].Rows[0]["Progress"].ToString();
                txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                txtRemarksbyPM.Text = ds.Tables[0].Rows[0]["RemarksByPM"].ToString();
                if (txtJobType.Text == "Hood")
                {
                    if(ddlProjectManager.Items.FindByValue(ds.Tables[0].Rows[0]["ProjectManagerID"].ToString()) != null)
                    {
                        ddlProjectManager.SelectedValue = ds.Tables[0].Rows[0]["ProjectManagerID"].ToString();
                    }
                    else
                    {
                        ddlProjectManager.SelectedIndex = 0;
                    }            
                }
                TextBoxDisabled();
                btnSave.Text = "Update";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ProjectTypeNesting(string ProjectTypeid, string JobType)
    {
        try
        {
            if (JobType != "")
            {
                if (ProjectTypeid == "7")
                {
                    SyncEmployees(ProjectTypeid, JobType);
                }
                else
                {
                    SyncEmployees(ProjectTypeid, JobType);
                }
                if (JobType == "Hood" && ProjectTypeid == "7")
                {
                    txtItemNo.Text = "N/A";
                    txtItemNo.Enabled = false;
                    ddlModelType.Items.Clear();
                    ddlModelType.Items.Insert(0, new ListItem("N/A", "-1"));
                    ddlModelType.SelectedValue = "-1";
                    ddlModelType.Enabled = false;
                }
                else if(JobType == "Conveyor" && ProjectTypeid == "7")
                {
                    txtItemNo.Text = "";
                    txtItemNo.Enabled = true;
                    ddlModelType.Items.Clear();
                }
                else
                {
                    txtItemNo.Text = "";
                    txtItemNo.Enabled = true;
                    ddlModelType.Items.Clear();
                    BindModels(hfProjectID.Value, ProjectTypeid);
                    ddlModelType.Enabled = true;
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please Select Job Type !!");
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvCadEngTasks_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            int ID = Convert.ToInt32(gvCadEngTasks.DataKeys[e.RowIndex].Values[0]);
            ObjBOL.Operation = 9;
            ObjBOL.EngProjectID = ID;
            msg = ObjBLL.DeleteTaskDetails(ObjBOL);
            if (msg != "")
            {
                Utility.ShowMessage_Success(Page, msg);
                Utility.MaintainLogsSpecial("FrmCaddyEngTasks", "Delete", ddlPNumberHeaderList.SelectedValue);
                BindGrid(txtJobNumber.Text);
                CheckLookupData(txtJobNumber.Text);
                ResetTaskInfo();
                TextBoxEnabled();
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckLookupData(string JobNo)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 13;
            ObjBOL.JobNo = JobNo;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPNumberHeaderList.SelectedValue = ds.Tables[0].Rows[0]["JobNo"].ToString();
            }
            else
            {
                BindLookUp();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region JobNo/JobName Enable/Disable
    private void TextBoxEnabled()
    {
        try
        {
            txtJobNumber.Enabled = true;
            txtJobName.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void TextBoxDisabled()
    {
        try
        {
            txtJobNumber.Enabled = false;
            txtJobName.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Auto Complete Job No/Job Name Text Boxes
    protected void txtJobNumber_TextChanged(object sender, EventArgs e)
    {
        try
        {
            AutofillDetailsByJobNo(txtJobNumber.Text);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void AutofillDetailsByJobNo(String JobNo)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.JobNo = JobNo;
            ds = ObjBLL.AutoFillProjectInfo(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtJobNumber.Text = ds.Tables[0].Rows[0]["JobNo"].ToString();
                txtJobName.Text = ds.Tables[0].Rows[0]["JobName"].ToString();
                txtJobType.Text = ds.Tables[0].Rows[0]["JobType"].ToString();
                txtProjManaCaddy.Text = ds.Tables[0].Rows[0]["PMCaddy"].ToString();
                hfProjectID.Value = ds.Tables[0].Rows[0]["ProjectInfoID"].ToString();
                Bind_Models(txtJobNumber.Text);
                if (txtJobType.Text != "")
                {
                    SyncEmployees("", txtJobType.Text);
                }
                else
                {
                    ddlAssignedToEng.Items.Clear();
                }
                CheckLookupData(txtJobNumber.Text);
                BindItemNoOnHood(txtJobType.Text);
                BindCorrection(txtJobType.Text);
                BindModels(hfProjectID.Value, "");
                Bind_ProjectManager();
                BindGrid(txtJobNumber.Text);
                ProjectTypeNesting("", txtJobType.Text);
            }
            else
            {
                Reset();
                TaskDetailsReset();
                btnGenerateReport.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void BindItemNoOnHood(string JobType)
    {
        try
        {
            if(JobType == "Hood")
            {
                DivVisibleTrue();
                hfJobType.Value = JobType;
            }
            else
            {
                DivVisibleFalse();
                hfJobType.Value = "-1";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindCorrection(string JobType)
    {
        try
        {
            if(JobType == "Conveyor")
            {
                dvCorrection.Visible = true;
            }
            else
            {
                dvCorrection.Visible = false;
                txtCorrection.Text = String.Empty;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtJobName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            AutofillDetailsByJobName(txtJobName.Text);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void AutofillDetailsByJobName(String JobName)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            ObjBOL.JobName = JobName;
            ds = ObjBLL.AutoFillProjectInfo(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtJobNumber.Text = ds.Tables[0].Rows[0]["JobNo"].ToString();
                txtJobName.Text = ds.Tables[0].Rows[0]["JobName"].ToString();
                txtJobType.Text = ds.Tables[0].Rows[0]["JobType"].ToString();
                txtProjManaCaddy.Text = ds.Tables[0].Rows[0]["PMCaddy"].ToString();
                hfProjectID.Value = ds.Tables[0].Rows[0]["ProjectInfoID"].ToString();
                Bind_Models(txtJobNumber.Text);
                if (txtJobType.Text != "")
                {
                    SyncEmployees("", txtJobType.Text);
                }
                else
                {
                    ddlAssignedToEng.Items.Clear();
                }
                CheckLookupData(txtJobNumber.Text);
                BindItemNoOnHood(txtJobType.Text);
                BindCorrection(txtJobType.Text);
                BindModels(hfProjectID.Value, "");
                Bind_ProjectManager();
                BindGrid(txtJobNumber.Text);
                ProjectTypeNesting("", txtJobType.Text);
            }
            else
            {
                Reset();
                TaskDetailsReset();
                btnGenerateReport.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion    

    #region Look Up Drop Down
    protected void ddlPNumberHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPNumberHeaderList.SelectedIndex > 0)
            {
                ResetTaskInfo();
                TextBoxEnabled();
                FillDetails(ddlPNumberHeaderList.SelectedValue);
                btnGenerateReport.Enabled = true;                
            }
            else
            {
                Reset();
                gvCadEngTasks.DataSource = "";
                gvCadEngTasks.DataBind();
                btnGenerateReport.Enabled = false;
                gvTaskDetails.Visible = false;
                DivVisibleFalse();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Reports
    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[CADDY_EngTaskReport] '" + txtJobType.Text  + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenReport()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportData();
            rprt.Load(Server.MapPath("~/CADDY/rptEngTaskReportDaily_Caddy.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "CADDY ENGINEERING DAILY TASK REPORT"; 
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                rprt.Close();
                rprt.Dispose();
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "CADDY ENGINEERING DAILY TASK REPORT";
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
    
    private void GenReportHood()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportData();
            rprt.Load(Server.MapPath("~/CADDY/rptEngTaskReportHoodDaily_Caddy.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "CADDY ENGINEERING DAILY TASK REPORT";
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "CADDY ENGINEERING DAILY TASK REPORT";
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

    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        try
        {
            if(txtJobType.Text=="Conveyor")
            {
                GenReport();
            }
           else if(txtJobType.Text == "Hood")
            {
                GenReportHood();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion


    private void BindModels(string projectid, string projecttypeid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 16;
            ObjBOL.ProjectID = Convert.ToInt32(projectid);
            if (projecttypeid != "")
            {
                ObjBOL.ProjectType = Convert.ToInt32(projecttypeid);
            }
            else
            {
                ObjBOL.ProjectType = 0;
            }
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlModelType, ds.Tables[0]);
                ddlModelType.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnFilterDate_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/CADDY/FrmCaddyFilterData.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if(ddlStatus.SelectedValue=="3")
            {
                pnlProgress.Visible = true;
            }
            else
            {
                pnlProgress.Visible = false;
            }
            ddlProgress.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnReportType_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/CADDY/frmReportType.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SyncEmployees(string ProjectType, string JobType)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 15;
            ObjBOL.JobType = JobType;
            if (ProjectType != "")
            {
                ObjBOL.ProjectType = Convert.ToInt32(ProjectType);
            }
            else
            {
                ObjBOL.ProjectType = 0;
            }
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlAssignedToEng, ds.Tables[0]);
                ddlAssignedToEng.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void ddlProjectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            var ProjectTypeid = ddlProjectType.SelectedValue;
            string JobType = txtJobType.Text;
            ProjectTypeNesting(ProjectTypeid, JobType);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}