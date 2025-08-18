using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
/// <summary>
///  Proposal Form (30 May 2018) Rohit Kumar
/// </summary>
public partial class CADDY_frmProjectInfo : System.Web.UI.Page
{
    BOLCADDYProjectInfo ObjBOL = new BOLCADDYProjectInfo();
    BLLManageCADDYProjectInfo ObjBLL = new BLLManageCADDYProjectInfo();
    // Page load event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                if (!IsPostBack)
                {
                    Session["JobNo"] = null;
                    Bind_Control();
                    BindLookUp();
                }
            }
            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlJobType, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjManagerCaddy, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Hoods()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            ds = ObjBLL.GetControlsModels(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindCheckBoxListWOAll(chkModel, ds.Tables[0]);
                foreach (ListItem li in chkModel.Items)
                {
                    //description
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltipConveyor(Convert.ToInt32(li.Value));
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);

        }
        string strMethodName = "GetValueHoods();";
        // System.Threading.Thread.SpinWait(10);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
    }

    private void Bind_Conveyor()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControlsModels(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindCheckBoxListWOAll(chk1, ds.Tables[0]);
                foreach (ListItem li in chk1.Items)
                {
                    //description
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltipConveyor(Convert.ToInt32(li.Value));
                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindCheckBoxListWOAll(chk2, ds.Tables[1]);
                foreach (ListItem li in chk2.Items)
                {
                    //description
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltipConveyor(Convert.ToInt32(li.Value));
                }
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindCheckBoxListWOAll(chk3, ds.Tables[2]);
                foreach (ListItem li in chk3.Items)
                {
                    //description
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltipConveyor(Convert.ToInt32(li.Value));
                }
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindCheckBoxListWOAll(chk4, ds.Tables[3]);
                foreach (ListItem li in chk4.Items)
                {
                    //description
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltipConveyor(Convert.ToInt32(li.Value));
                }
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindCheckBoxListWOAll(chk5, ds.Tables[4]);
                foreach (ListItem li in chk5.Items)
                {
                    //description
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltipConveyor(Convert.ToInt32(li.Value));
                }
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindCheckBoxListWOAll(chk6, ds.Tables[5]);
                foreach (ListItem li in chk6.Items)
                {
                    //description
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltipConveyor(Convert.ToInt32(li.Value));
                }
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindCheckBoxListWOAll(chk7, ds.Tables[6]);
                foreach (ListItem li in chk7.Items)
                {
                    //description
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltipConveyor(Convert.ToInt32(li.Value));
                }
            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                Utility.BindCheckBoxListWOAll(chk8, ds.Tables[7]);
                foreach (ListItem li in chk8.Items)
                {
                    //description
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltipConveyor(Convert.ToInt32(li.Value));
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        string strMethodName = "GetValue();";
        // System.Threading.Thread.SpinWait(10);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
    }

    private string GetRoleTooltip(int ModelID)
    {
        string name = string.Empty;
        DataSet ds = new DataSet();
        ObjBOL.Operation = 5;
        ObjBOL.ModelID = ModelID;
        ds = ObjBLL.BindModelsDescriptionToolTip(ObjBOL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            name = ds.Tables[0].Rows[0]["description"].ToString();
        }
        return name;
    }

    private string GetRoleTooltipConveyor(int ModelID)
    {
        string name = string.Empty;
        DataSet ds = new DataSet();
        ObjBOL.Operation = 2;
        ObjBOL.ModelID = ModelID;
        ds = ObjBLL.BindConveyorDescriptionToolTip(ObjBOL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            name = ds.Tables[0].Rows[0]["description"].ToString();
        }
        return name;
    }

    private void BindLookUp()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlLookUpJobDes, ds.Tables[2]);
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
            if (txtJobNo.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Job Number. !!");
                txtJobNo.Focus();
                return false;
            }
            if (txtJobName.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Job Name. !!");
                txtJobName.Focus();
                return false;
            }
            if (ddlJobType.SelectedValue == "0")
            {
                Utility.ShowMessage_Error(Page, "Please Select Job Type. !!");
                ddlJobType.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void SaveJobInfo()
    {
        try
        {
            string msg = "";
            if (ddlLookUpJobDes.Items.FindByValue(ddlLookUpJobDes.SelectedValue) != null)
            {
                ObjBOL.ProjectID = Convert.ToInt32(ddlLookUpJobDes.SelectedValue);
            }
            else
            {
                ObjBOL.ProjectID = 0;
            }
            ObjBOL.Operation = 2;
            ObjBOL.JobNo = txtJobNo.Text;
            ObjBOL.JobName = txtJobName.Text;
            if (ddlJobType.Items.FindByValue(ddlJobType.SelectedValue) != null)
            {
                ObjBOL.JobType = Convert.ToInt32(ddlJobType.SelectedValue);
            }
            if (ddlProjManagerCaddy.Items.FindByValue(ddlProjManagerCaddy.SelectedValue) != null)
            {
                ObjBOL.PMCaddy = Convert.ToInt32(ddlProjManagerCaddy.SelectedValue);
            }
            msg = ObjBLL.SaveProjectInfo(ObjBOL);
            if (msg != "")
            {
                if (ddlLookUpJobDes.SelectedIndex > 0)
                {
                    if (msg != "Job No Already Exists !")
                    {
                        hfProjectID.Value = ddlLookUpJobDes.SelectedValue;
                        Save_Model(hfProjectID.Value);
                        Utility.ShowMessage_Success(Page, msg);
                        Utility.MaintainLogsSpecial("frmProjectInfo", "Update", ddlLookUpJobDes.SelectedValue);
                        BindLookUp();
                        ddlLookUpJobDes.SelectedValue = hfProjectID.Value;
                        btnSave.Text = "Update";
                        btnAddTasks.Enabled = true;
                    }
                    else
                    {
                        Utility.ShowMessage_Error(Page, msg);
                    }
                }
                else
                {
                    if (msg != "Job No Already Exists !")
                    {
                        hfProjectID.Value = msg;
                        Save_Model(hfProjectID.Value);
                        Utility.MaintainLogsSpecial("frmProjectInfo", "Save", msg);
                        BindLookUp();
                        ddlLookUpJobDes.SelectedValue = hfProjectID.Value;
                        btnAddTasks.Enabled = true;
                        btnSave.Text = "Update";
                        Utility.ShowMessage_Success(Page, "Record Added Successfully !");
                    }
                    else
                    {
                        Utility.ShowMessage_Error(Page, msg);
                    }
                }
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
            if (ValidationCheck() == true)
            {
                SaveJobInfo();
                Bind_FillModels();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Save_Model(string ProjectID)
    {
        try
        {
            ObjBOL.Operation = 3;
            ObjBOL.ProjectID = Convert.ToInt32(ProjectID);
            CheckModelBeforeSave();
            DataTable selected = (DataTable)ViewState["Summary"];
            DataView dv = new DataView(selected);
            DataTable summarytemp = dv.ToTable("selected", false, "ProjectID", "ChildModelID");
            DataRow row;
            if (ddlJobType.SelectedValue == "1")
            {
                for (int i = 0; i < chk5.Items.Count; i++)
                {
                    if (chk5.Items[i].Selected)
                    {
                        row = summarytemp.NewRow();
                        row["ProjectID"] = ProjectID;
                        row["ChildModelID"] = Int32.Parse(chk5.Items[i].Value);
                        summarytemp.Rows.Add(row);
                    }
                }
                for (int i = 0; i < chk1.Items.Count; i++)
                {
                    if (chk1.Items[i].Selected)
                    {
                        row = summarytemp.NewRow();
                        row["ProjectID"] = ProjectID;
                        row["ChildModelID"] = Int32.Parse(chk1.Items[i].Value);
                        summarytemp.Rows.Add(row);
                    }
                }
                for (int i = 0; i < chk2.Items.Count; i++)
                {
                    if (chk2.Items[i].Selected)
                    {
                        row = summarytemp.NewRow();
                        row["ProjectID"] = ProjectID;
                        row["ChildModelID"] = Int32.Parse(chk2.Items[i].Value);
                        summarytemp.Rows.Add(row);
                    }
                }
                for (int i = 0; i < chk3.Items.Count; i++)
                {
                    if (chk3.Items[i].Selected)
                    {
                        row = summarytemp.NewRow();
                        row["ProjectID"] = ProjectID;
                        row["ChildModelID"] = Int32.Parse(chk3.Items[i].Value);
                        summarytemp.Rows.Add(row);
                    }
                }
                for (int i = 0; i < chk6.Items.Count; i++)
                {
                    if (chk6.Items[i].Selected)
                    {
                        row = summarytemp.NewRow();
                        row["ProjectID"] = ProjectID;
                        row["ChildModelID"] = Int32.Parse(chk6.Items[i].Value);
                        summarytemp.Rows.Add(row);
                    }
                }
                for (int i = 0; i < chk7.Items.Count; i++)
                {
                    if (chk7.Items[i].Selected)
                    {
                        row = summarytemp.NewRow();
                        row["ProjectID"] = ProjectID;
                        row["ChildModelID"] = Int32.Parse(chk7.Items[i].Value);
                        summarytemp.Rows.Add(row);
                    }
                }
                for (int i = 0; i < chk4.Items.Count; i++)
                {
                    if (chk4.Items[i].Selected)
                    {
                        row = summarytemp.NewRow();
                        row["ProjectID"] = ProjectID;
                        row["ChildModelID"] = Int32.Parse(chk4.Items[i].Value);
                        summarytemp.Rows.Add(row);
                    }
                }
                for (int i = 0; i < chk8.Items.Count; i++)
                {
                    if (chk8.Items[i].Selected)
                    {
                        row = summarytemp.NewRow();
                        row["ProjectID"] = ProjectID;
                        row["ChildModelID"] = Int32.Parse(chk8.Items[i].Value);
                        summarytemp.Rows.Add(row);
                    }
                }
                ObjBOL.SelectedItems = summarytemp;
                ObjBLL.SaveModels(ObjBOL);
            }
            else if (ddlJobType.SelectedValue == "2")
            {
                for (int i = 0; i < chkModel.Items.Count; i++)
                {
                    if (chkModel.Items[i].Selected)
                    {
                        row = summarytemp.NewRow();
                        row["ProjectID"] = ProjectID;
                        row["ChildModelID"] = Int32.Parse(chkModel.Items[i].Value);
                        summarytemp.Rows.Add(row);
                    }
                }
                ObjBOL.SelectedItems = summarytemp;
                ObjBLL.SaveModels(ObjBOL);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private DataTable DTModel()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.TableName = "Summary";
            dt.Columns.Add(new DataColumn("ProjectID", typeof(Int32)));
            dt.Columns.Add(new DataColumn("ChildModelID", typeof(Int32)));
            ViewState["Summary"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void CheckModelBeforeSave()
    {
        try
        {
            DataTable dt = DTModel();
            DataRow dr;
            ViewState["Summary"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearSelections()
    {
        try
        {
            chkModel.ClearSelection();
            chk1.ClearSelection();
            chk2.ClearSelection();
            chk3.ClearSelection();
            chk4.ClearSelection();
            chk5.ClearSelection();
            chk6.ClearSelection();
            chk7.ClearSelection();
            chk8.ClearSelection();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Reset()
    {
        try
        {
            txtJobNo.Text = String.Empty;
            txtJobName.Text = String.Empty;
            ddlJobType.SelectedIndex = 0;
            ddlProjManagerCaddy.SelectedIndex = 0;
            ClearSelections();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillHoods()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.ProjectID = Convert.ToInt32(ddlLookUpJobDes.SelectedValue);
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < chkModel.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                    {
                        var chk = ds.Tables[1].Rows[j]["Modelid"];
                        if (chkModel.Items[i].Value == chk.ToString())
                        {
                            chkModel.Items[i].Selected = true;
                        }
                    }
                }
            }
            string strMethodName = "GetValueHoods();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillConveyor()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.ProjectID = Convert.ToInt32(ddlLookUpJobDes.SelectedValue);
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < chk5.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                    {
                        var chk = ds.Tables[1].Rows[j]["Modelid"];
                        if (chk5.Items[i].Value == chk.ToString())
                        {
                            chk5.Items[i].Selected = true;
                        }
                    }
                }

                for (int i = 0; i < chk1.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                    {
                        var chk = ds.Tables[1].Rows[j]["Modelid"];
                        if (chk1.Items[i].Value == chk.ToString())
                        {
                            chk1.Items[i].Selected = true;
                        }
                    }
                }

                for (int i = 0; i < chk2.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                    {
                        var chk = ds.Tables[1].Rows[j]["Modelid"];
                        if (chk2.Items[i].Value == chk.ToString())
                        {
                            chk2.Items[i].Selected = true;
                        }
                    }
                }

                for (int i = 0; i < chk3.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                    {
                        var chk = ds.Tables[1].Rows[j]["Modelid"];
                        if (chk3.Items[i].Value == chk.ToString())
                        {
                            chk3.Items[i].Selected = true;
                        }
                    }
                }

                for (int i = 0; i < chk6.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                    {
                        var chk = ds.Tables[1].Rows[j]["Modelid"];
                        if (chk6.Items[i].Value == chk.ToString())
                        {
                            chk6.Items[i].Selected = true;
                        }
                    }
                }

                for (int i = 0; i < chk7.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                    {
                        var chk = ds.Tables[1].Rows[j]["Modelid"];
                        if (chk7.Items[i].Value == chk.ToString())
                        {
                            chk7.Items[i].Selected = true;
                        }
                    }
                }

                for (int i = 0; i < chk4.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                    {
                        var chk = ds.Tables[1].Rows[j]["Modelid"];
                        if (chk4.Items[i].Value == chk.ToString())
                        {
                            chk4.Items[i].Selected = true;
                        }
                    }
                }

                for (int i = 0; i < chk8.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                    {
                        var chk = ds.Tables[1].Rows[j]["Modelid"];
                        if (chk8.Items[i].Value == chk.ToString())
                        {
                            chk8.Items[i].Selected = true;
                        }
                    }
                }
            }
            string strMethodName = "GetValue();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void FillDetails()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.ProjectID = Convert.ToInt32(ddlLookUpJobDes.SelectedValue);
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtJobNo.Text = ds.Tables[0].Rows[0]["JobNo"].ToString();
                txtJobName.Text = ds.Tables[0].Rows[0]["JobName"].ToString();
                if (ddlJobType.Items.FindByValue(ds.Tables[0].Rows[0]["JobType"].ToString()) != null)
                {
                    ddlJobType.SelectedValue = ds.Tables[0].Rows[0]["JobType"].ToString();
                }
                if (ddlProjManagerCaddy.Items.FindByValue(ds.Tables[0].Rows[0]["PMCaddy"].ToString()) != null)
                {
                    ddlProjManagerCaddy.SelectedValue = ds.Tables[0].Rows[0]["PMCaddy"].ToString();
                }
            }
            Bind_FillModels();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_FillModels()
    {
        try
        {
            dvModelText.Visible = true;
            if (ddlJobType.SelectedValue == "1")
            {
                dvconveyor.Visible = true;
                dvhoods.Visible = false;
                Bind_Conveyor();
                FillConveyor();
            }
            else if (ddlJobType.SelectedValue == "2")
            {
                dvhoods.Visible = true;
                dvconveyor.Visible = false;
                Bind_Hoods();
                FillHoods();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    protected void ddlLookUpJobDes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlLookUpJobDes.SelectedIndex > 0)
            {
                Reset();
                FillDetails();
                btnSave.Text = "Update";
                btnAddTasks.Enabled = true;
            }
            else
            {
                Reset();
                btnSave.Text = "Save";
                ResetModel();
                btnAddTasks.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetModel()
    {
        try
        {
            dvconveyor.Visible = false;
            dvhoods.Visible = false;
            dvModelText.Visible = false;
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
            ddlLookUpJobDes.SelectedIndex = 0;
            btnSave.Text = "Save";
            btnAddTasks.Enabled = false;
            ResetModel();
            Session["JobNo"] = null;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlJobType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            dvModelText.Visible = true;
            if (ddlJobType.SelectedValue == "1")
            {
                dvconveyor.Visible = true;
                dvhoods.Visible = false;
                Bind_Conveyor();
            }
            else if (ddlJobType.SelectedValue == "2")
            {
                dvconveyor.Visible = false;
                dvhoods.Visible = true;
                Bind_Hoods();
            }
            else
            {
                ResetModel();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnAddTasks_Click(object sender, EventArgs e)
    {
        try
        {
            Session["JobNo"] = null;
            var JobNo = ddlLookUpJobDes.SelectedItem.Text;
            Session["JobNo"] = JobNo.Substring(0, JobNo.IndexOf(',')); ;
            Response.Redirect("~/CADDY/FrmCaddyEngTasks.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }
}