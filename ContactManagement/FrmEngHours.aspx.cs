using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class ContactManagement_FrmEngHours : System.Web.UI.Page
{
    BOLEngHoursCalculate ObjBOL = new BOLEngHoursCalculate();
    BLLCalculateEngHours ObjBLL = new BLLCalculateEngHours();
    DateTime starttime;
    DateTime finishtime;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                Bind_Controls();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectNo, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlEngDepartment, ds.Tables[1]);
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
            if (ddlProjectNo.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Project No');", true);
                Utility.ShowMessage_Error(Page, "Please Select Project No");
                ddlProjectNo.Focus();
                return false;
            }
            if (ddlEngDepartment.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Department');", true);
                Utility.ShowMessage_Error(Page, "Please Select Department");
                ddlEngDepartment.Focus();
                return false;
            }
            if (ddlEngDepartment.SelectedIndex > 0)
            {
                if (ddlEngEmployee.SelectedIndex == 0)
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Employee');", true);
                    Utility.ShowMessage_Error(Page, "Please Select Employee");
                    ddlEngEmployee.Focus();
                    return false;
                }
            }
            if (txtDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Date');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Date");
                txtDate.Focus();
                return false;
            }
            if (ddlNatureOfTask.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Nature of Task');", true);
                Utility.ShowMessage_Error(Page, "Please Select Nature of Task");
                ddlNatureOfTask.Focus();
                return false;
            }
            if (ddlCategory.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Category');", true);
                Utility.ShowMessage_Error(Page, "Please Select Category");
                ddlCategory.Focus();
                return false;
            }
            if (txtStartTime.Text == "__:__")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Start Time');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Start Time");
                txtStartTime.Focus();
                return false;
            }
            if (txtFinishTime.Text == "__:__")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Finish Time');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Finish Time");
                txtFinishTime.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void CalculateTotalHours()
    {
        try
        {
            //DateTime Case1 = Convert.ToDateTime("00:05");
            ////Morning Shift
            //DateTime MB = Convert.ToDateTime("07:00");
            //DateTime LB = Convert.ToDateTime("09:30");
            //DateTime TeaB = Convert.ToDateTime("12:00");
            ////Evening Shift
            //DateTime AFB = Convert.ToDateTime("11:00");
            ////DateTime DB = Convert.ToDateTime("09:30");
            ////DateTime NSB = Convert.ToDateTime("12:00");        
            //var MBT = Convert.ToDateTime("00:00");
            //DateTime LBT = Convert.ToDateTime("00:00");
            //DateTime TeaBT = Convert.ToDateTime("00:00");
            //DateTime ETBT = Convert.ToDateTime("00:00");
            ////DateTime DBT = Convert.ToDateTime("00:30");
            ////DateTime SNBT = Convert.ToDateTime("00:10");
            var val1 = Convert.ToDateTime(txtStartTime.Text);
            var val2 = Convert.ToDateTime(txtFinishTime.Text);
            var TotalHours = val2.TimeOfDay - val1.TimeOfDay;

            //if (TotalHours >= Case1.TimeOfDay)
            //{
            //    if (MB >= val1 && MB <= val2)
            //    {
            //        var FinalHours = TotalHours - MBT.TimeOfDay;
            //        txtTotalHours.Text = Convert.ToString(FinalHours);



            //        if (LB >= val1 && LB <= val2)
            //        {
            //            FinalHours = FinalHours - LBT.TimeOfDay;
            //            txtTotalHours.Text = Convert.ToString(FinalHours);
            //        }
            //        if (TeaB >= val1 && TeaB <= val2)
            //        {
            //            FinalHours = FinalHours - TeaBT.TimeOfDay;
            //            txtTotalHours.Text = Convert.ToString(FinalHours);
            //        }



            //    }
            //    else if (LB >= val1 && LB <= val2)
            //    {
            //        var FinalHours = TotalHours - LBT.TimeOfDay;
            //        txtTotalHours.Text = Convert.ToString(FinalHours);
            //        if (TeaB >= val1 && TeaB <= val2)
            //        {
            //            FinalHours = FinalHours - TeaBT.TimeOfDay;
            //            txtTotalHours.Text = Convert.ToString(FinalHours);
            //        }

            //    }
            //    else if (TeaB >= val1 && TeaB <= val2)
            //    {
            //        var FinalHours = TotalHours - TeaBT.TimeOfDay;
            //        txtTotalHours.Text = Convert.ToString(FinalHours);

            //    }
            //}
            //else
            //{

            //}
            var FinalHours = TotalHours;
            txtTotalHours.Text = Convert.ToString(FinalHours);
            DateTime ConvertHours = Convert.ToDateTime(txtTotalHours.Text);
            txtTotalHours.Text = ConvertHours.ToString("HH:mm");
            //ValidateTime(txtTotalHours.Text);
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
            if (ValidationCheck() == true)
            {
                string msg = "";
                ObjBOL.Operation = 2;
                ObjBOL.ProposalID = ddlProjectNo.SelectedValue;
                if (ddlEngDepartment.SelectedIndex > 0)
                {
                    ObjBOL.EmployeeID = Convert.ToInt32(ddlEngEmployee.SelectedValue);
                }
                ObjBOL.TaskDate = Utility.ConvertDate(txtDate.Text);
                ObjBOL.TaskNature = Convert.ToInt32(ddlNatureOfTask.SelectedValue);
                ObjBOL.TaskCategory = Convert.ToInt32(ddlCategory.SelectedValue);
                ObjBOL.StartTime = Convert.ToDateTime(txtStartTime.Text);
                ObjBOL.EndTime = Convert.ToDateTime(txtFinishTime.Text);
                ObjBOL.TotalTime = Convert.ToDateTime(txtTotalHours.Text);
                if (btnAdd.Text == "Update")
                {
                    ObjBOL.TimeSheetid = Convert.ToInt32(hfEmployeerowid.Value);
                }
                msg = ObjBLL.SaveEngData(ObjBOL);
                dvMsg.Visible = true;
                lblMsg.Text = msg;
                Bind_Grid();
                Reset();
                if (btnAdd.Text == "Save")
                {
                    Utility.MaintainLogsSpecial("frmEngHours", "Save", ddlProjectNo.SelectedValue);
                }
                else
                {
                    Utility.MaintainLogsSpecial("frmEngHours", "Update", ddlProjectNo.SelectedValue);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Boolean ValidationCheckStartTime()
    {
        try
        {
            //var val = Convert.ToDateTime("07:00");
            //var val2 = Convert.ToDateTime("23:55");

            //Changed by Rohit Sharma (Nov. 04 2020)
            var val = Convert.ToDateTime("05:00");
            var val2 = Convert.ToDateTime("23:55");
            if (txtStartTime.Text != "__:__")
            {
                var starttime = Convert.ToDateTime(txtStartTime.Text);
                if (starttime < val)
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('General Shift starts at 09:00 A.M.');", true);
                    Utility.ShowMessage_Error(Page, "General Shift starts at 09:00 A.M.");
                    txtStartTime.Text = "__:__";
                    txtStartTime.Focus();

                    return false;
                }
                if (txtFinishTime.Text != "__:__")
                {
                    DateTime finishtime = Convert.ToDateTime(txtFinishTime.Text);
                    if (finishtime < starttime)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Finish Time Should be  Greater than Start Time. Entry Start Time: 09:00 and Finish Time 14:00].');", true);
                        Utility.ShowMessage_Error(Page, "Finish Time Should be  Greater than Start Time. Entry Start Time: 09:00 and Finish Time 14:00].");
                        txtFinishTime.Text = "__:__";
                        txtFinishTime.Focus();
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

    private Boolean ValidationCheckFinishTime()
    {
        try
        {

            if (txtStartTime.Text != "__:__")
            {
                starttime = Convert.ToDateTime(txtStartTime.Text);
            }
            if (txtFinishTime.Text != "__:__")
            {
                finishtime = Convert.ToDateTime(txtFinishTime.Text);
            }

            if (finishtime < starttime)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Finish Time Should be  Greater than Start Time. Entry Start Time: 09:00 and Finish Time 14:00].');", true);
                Utility.ShowMessage_Error(Page, "Finish Time Should be  Greater than Start Time. Entry Start Time: 09:00 and Finish Time 14:00].");
                txtFinishTime.Text = "__:__";
                txtFinishTime.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void txtStartTime_TextChanged1(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheckStartTime() == true)
            {
                if (txtStartTime.Text != "__:__" && txtFinishTime.Text != "__:__")
                {
                    CalculateTotalHours();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetHours()
    {
        try
        {
            txtStartTime.Text = "__:__";
            txtFinishTime.Text = "__:__";
            txtTotalHours.Text = String.Empty;
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
            ddlProjectNo.SelectedIndex = 0;
            ddlNatureOfTask.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;
            ddlEngDepartment.SelectedIndex = 0;
            txtDate.Text = String.Empty;
            if (ddlEngEmployee.SelectedIndex > 0)
            {
                ddlEngEmployee.DataSource = "";
                ddlEngEmployee.DataBind();
            }
            ResetHours();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtFinishTime_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheckFinishTime() == true)
            {
                if (txtStartTime.Text != "__:__" && txtFinishTime.Text != "__:__")
                {
                    CalculateTotalHours();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Grid()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            ObjBOL.ProposalID = ddlProjectNo.SelectedValue;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvCaptureData.DataSource = ds.Tables[0];
                gvCaptureData.DataBind();
            }
            else
            {
                gvCaptureData.DataSource = "";
                gvCaptureData.DataBind();
            }
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
            ddlProjectNo.SelectedIndex = 0;
            ddlEngDepartment.SelectedIndex = 0;
            if (ddlEngEmployee.SelectedIndex > 0)
            {
                ddlEngEmployee.DataSource = "";
                ddlEngEmployee.DataBind();
            }
            gvCaptureData.DataSource = "";
            gvCaptureData.DataBind();
            txtDate.Text = String.Empty;
            btnAdd.Text = "Save";
            lblMsg.Text = String.Empty;
            dvMsg.Visible = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvCaptureData_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.TimeSheetid = Convert.ToInt32(hfEmployeerowid.Value);
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlProjectNo.SelectedValue = ds.Tables[0].Rows[0]["ProposalID"].ToString();
                ddlEngDepartment.SelectedValue = ds.Tables[0].Rows[0]["EngDepID"].ToString();
                BindControlEngDepartment(ddlEngDepartment.SelectedValue);
                ddlEngEmployee.SelectedValue = ds.Tables[0].Rows[0]["EmployeeID"].ToString();
                txtDate.Text = ds.Tables[0].Rows[0]["TaskDate"].ToString();
                ddlNatureOfTask.SelectedValue = ds.Tables[0].Rows[0]["TaskNature"].ToString();
                ddlCategory.SelectedValue = ds.Tables[0].Rows[0]["TaskCategory"].ToString();
                txtStartTime.Text = ds.Tables[0].Rows[0]["StartTime"].ToString();
                txtFinishTime.Text = ds.Tables[0].Rows[0]["EndTime"].ToString();
                txtTotalHours.Text = ds.Tables[0].Rows[0]["TotalTime"].ToString();
                btnAdd.Text = "Update";
            }
            else
            {
                btnAdd.Text = "Save";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvCaptureData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Update")
            {
                LinkButton lb = (LinkButton)e.CommandSource;
                GridViewRow gvr = (GridViewRow)lb.NamingContainer;
                int id = (int)gvCaptureData.DataKeys[gvr.RowIndex].Value;
                hfEmployeerowid.Value = Convert.ToString(id);
                btnAdd.Text = "Update";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindControlEngDepartment(string departmentid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            if (ddlEngDepartment.SelectedIndex > 0)
            {
                ObjBOL.DepartmentID = Convert.ToInt32(departmentid);
            }
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlEngEmployee, ds.Tables[2]);
            }
            else
            {
                ddlEngEmployee.DataSource = "";
                ddlEngEmployee.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlEngDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindControlEngDepartment(ddlEngDepartment.SelectedValue);
    }

    protected void ddlProjectNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Bind_Grid();
            ddlNatureOfTask.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;
            txtDate.Text = String.Empty;
            ResetHours();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}