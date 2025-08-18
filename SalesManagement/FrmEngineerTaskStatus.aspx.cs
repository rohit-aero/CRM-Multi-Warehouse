using System;
using BLLAERO;
using BOLAERO;
using System.Data;

public partial class SalesManagement_FrmEngineerTaskStatus : System.Web.UI.Page
{
    BLLDailyCADReport ObjBLL = new BLLDailyCADReport();
    BOLDailyCADReport ObjBOL = new BOLDailyCADReport();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                btnUpdate.Enabled = false;
                if (Request.QueryString["Id"] != null)
                {
                    BindControls(Int32.Parse(Request.QueryString["Id"]));
                }
                else
                {
                    BindControls(0);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindControls(int select)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 13;
            ObjBOL.ID = Utility.GetCurrentUser();
            ds = ObjBLL.GetInformation(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlTaskList, ds.Tables[0]);
                ddlTaskList.SelectedIndex = 0;
            }
            else
            {
                ddlTaskList.Items.Clear();
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlStatus, ds.Tables[1]);
                ddlStatus.SelectedIndex = 0;
            }

            if (select > 0)
            {
                ddlTaskList.SelectedValue = select.ToString();
                ddlTaskList_SelectedIndexChanged_Event();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlTaskList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTaskList_SelectedIndexChanged_Event();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlTaskList.SelectedIndex > 0)
            {
                ObjBOL.Operation = 15;
                ObjBOL.ID = Int32.Parse(ddlTaskList.SelectedValue);
                if (txtProjectSendToRCD.Text != "")
                {
                    ObjBOL.SentRCD = Utility.ConvertDate(txtProjectSendToRCD.Text);
                }
                //ObjBOL.CommentsByEngineer = txtRemarksByEngineer.Text;
                ObjBOL.StatusID = Int32.Parse(ddlStatus.SelectedValue);
                string returnStatus = ObjBLL.SaveAndUpdate(ObjBOL);
                if (returnStatus.Trim().Length > 0)
                {
                    Utility.MaintainLogsSpecial("EngineerTaskStatus", "UPDATE", ddlTaskList.SelectedValue);
                    Utility.ShowMessage(Page, returnStatus);
                    reset();
                    BindControls(0);
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
        reset();
    }

    private void ddlTaskList_SelectedIndexChanged_Event()
    {
        try
        {
            if (ddlTaskList.SelectedIndex > 0)
            {
                btnUpdate.Enabled = true;
                DataSet ds = new DataSet();
                ObjBOL.Operation = 14;
                ObjBOL.ID = Int32.Parse(ddlTaskList.SelectedValue);
                ds = ObjBLL.GetInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtProjectName.Text = ds.Tables[0].Rows[0]["PName"].ToString();
                    txtJobID.Text = ds.Tables[0].Rows[0]["JobID"].ToString();
                    txtTask.Text = ds.Tables[0].Rows[0]["Task"].ToString();
                    ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["StatusID"].ToString();
                    txtProjectSendToRCD.Text = ds.Tables[0].Rows[0]["SentRCD"].ToString();
                    txtProjectEngineer.Text = ds.Tables[0].Rows[0]["ProjectEngineer"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["CommentsByAssignee"].ToString();
                    // txtRemarksByEngineer.Text = ds.Tables[0].Rows[0]["CommentsByEngineer"].ToString();
                    txtPriority.Text = ds.Tables[0].Rows[0]["Priority"].ToString();
                }
            }
            else
            {
                reset();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void reset()
    {
        try
        {
            if (ddlTaskList.Items.Count > 0)
            {
                ddlTaskList.SelectedIndex = 0;
            }

            if (ddlStatus.Items.Count > 0)
            {
                ddlStatus.SelectedIndex = 0;
            }

            txtRemarks.Text = string.Empty;
            // txtRemarksByEngineer.Text = string.Empty;
            txtProjectEngineer.Text = string.Empty;
            txtProjectSendToRCD.Text = string.Empty;
            txtProjectName.Text = string.Empty;
            txtJobID.Text = string.Empty;
            txtTask.Text = string.Empty;
            txtPriority.Text = string.Empty;
            btnUpdate.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}