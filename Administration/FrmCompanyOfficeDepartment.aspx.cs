using BLLAERO;
using BOLAERO;
using System;
using System.Data;
using System.Web.UI;

public partial class Administration_FrmCompanyOfficeDepartment : System.Web.UI.Page
{
    BOLManageCompanyOfficeDepartment ObjBOL = new BOLManageCompanyOfficeDepartment();
    BLLManageCompanyOfficeDepartment ObjBLL = new BLLManageCompanyOfficeDepartment();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {                
                Bind_Controls();                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #region Bind Functions

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.BindControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlLookUpOffice, ds.Tables[0]);
                Utility.BindDropDownList(ddlOffice, ds.Tables[0]);
                if (ddlLookUpOffice.Items.Count > 0)
                {
                    ddlLookUpOffice.SelectedIndex = 0;
                }
                if (ddlOffice.Items.Count > 0)
                {
                    ddlOffice.SelectedIndex = 0;
                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlLookUpDepartment, ds.Tables[1]);
                if (ddlLookUpDepartment.Items.Count > 0)
                {
                    ddlLookUpDepartment.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    

    #endregion

    #region Validation

    private Boolean ValidationCheck()
    {
        try
        {
            if (ddlOffice.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select ProductLine !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Office !");
                ddlOffice.Focus();
                return false;
            }

            if (txtDepartment.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter RepGroup Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Department Name. !");
                txtDepartment.Focus();
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

    private void FilterDepartment(string officeID, string DepartmentID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.OfficeID = Convert.ToInt32(officeID);
            ds = ObjBLL.BindControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlLookUpDepartment, ds.Tables[0]);
                if(officeID != "")
                {
                    if(ddlLookUpOffice.Items.FindByValue(officeID) != null)
                    {
                        ddlLookUpOffice.SelectedValue = officeID;
                    }
                    
                }
                if (DepartmentID != "")
                {
                    if(ddlLookUpDepartment.Items.FindByValue(DepartmentID) != null)
                    {
                        ddlLookUpDepartment.SelectedValue = DepartmentID;
                    }
                   
                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlLookUpOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlLookUpOffice.SelectedIndex > 0)
            {
                FilterDepartment(ddlLookUpOffice.SelectedValue,"");
            }
            else
            {
                if (ddlLookUpDepartment.Items.Count > 0)
                {
                    ddlLookUpDepartment.Items.Clear();
                }
                ResetDetail();
                Bind_Controls();
            }
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
            if (ddlLookUpDepartment.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 5;
                ObjBOL.DepartmentID = Convert.ToInt32(ddlLookUpDepartment.SelectedValue);
                ds = ObjBLL.BindControls(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if(ddlLookUpOffice.Items.FindByValue(ds.Tables[0].Rows[0]["OfficeID"].ToString()) != null)
                    {
                        ddlLookUpOffice.SelectedValue = ds.Tables[0].Rows[0]["OfficeID"].ToString();
                        ddlOffice.SelectedValue = ds.Tables[0].Rows[0]["OfficeID"].ToString();
                        FilterDepartment(ddlOffice.SelectedValue, ddlLookUpDepartment.SelectedValue);
                    }             
                    txtDepartment.Text = ds.Tables[0].Rows[0]["Department"].ToString();
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["isAvtive"]) == true)
                    {
                        chkIsACtive.Checked = true;
                    }
                    else
                    {
                        chkIsACtive.Checked = false;
                    }
                    btnSave.Text = "Update";
                }
            }
            else
            {
                ddlOffice.SelectedIndex = 0;
                txtDepartment.Text = String.Empty;
                chkIsACtive.Checked = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlLookUpDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlLookUpDepartment.SelectedIndex > 0)
            {
                FillDetails();
            }
            else
            {
                ResetDetail();
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
                if (ddlLookUpDepartment.SelectedIndex > 0)
                {
                    ObjBOL.Operation = 4;
                    ObjBOL.DepartmentID = Convert.ToInt32(ddlLookUpDepartment.SelectedValue);
                }
                else
                {
                    ObjBOL.Operation = 3;
                }
                ObjBOL.OfficeID =Convert.ToInt32(ddlOffice.SelectedValue);
                ObjBOL.Department = txtDepartment.Text;
                ObjBOL.IsActive = chkIsACtive.Checked;
                msg = ObjBLL.SaveCompanyOfficeDepartment(ObjBOL);
                if(msg != "")
                {
                    if(btnSave.Text == "Save")
                    {
                        if (msg == "ER")
                        {
                            Utility.ShowMessage_Error(Page, "Department Already Exists !");
                            return;
                        }
                        else
                        {
                            Utility.ShowMessage_Success(Page, "Department Added Successfully !");
                            Utility.MaintainLogsSpecial("FrmCompanyOfficeDepartment", "Save-Department", msg);
                            FilterDepartment(ddlOffice.SelectedValue, msg);
                            btnSave.Text = "Update";
                        }
                    }
                    else
                    {
                        if (msg == "ER")
                        {
                            Utility.ShowMessage_Error(Page, "Department Already Exists !");
                            return;
                        }
                        else
                        {
                            Utility.ShowMessage_Success(Page, "Department Updated Successfully !");
                            Utility.MaintainLogsSpecial("FrmCompanyOfficeDepartment", "Update-Department", ddlLookUpDepartment.SelectedValue);
                            FilterDepartment(ddlOffice.SelectedValue, ddlLookUpDepartment.SelectedValue);
                        }
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
            Save();
        }
        catch (Exception ex)
        {
            
            Utility.AddEditException(ex);
        }
    }   

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
        Bind_Controls();
    }  


    #region Resets

    private void Reset()
    {
        try
        {
            ddlLookUpOffice.SelectedIndex = 0;
            if (ddlLookUpDepartment.Items.Count > 0)
            {
                ddlLookUpDepartment.SelectedIndex = 0;
            }
            ResetDetail();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }  

    private void ResetDetail()
    {
        try
        {
            ddlOffice.SelectedIndex = 0;
            txtDepartment.Text = String.Empty;
            chkIsACtive.Checked = false;
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion
}