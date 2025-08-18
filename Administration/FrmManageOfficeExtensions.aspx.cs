using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Administration_FrmManageOfficeExtensions : System.Web.UI.Page
{
    BOLExtensions ObjBOL = new BOLExtensions();
    BLLExtensions ObjBLL = new BLLExtensions();
    BOLEmployeeMaintain ObjBOLEmp = new BOLEmployeeMaintain();
    BLLEmployeeMaintain ObjBLLEmp = new BLLEmployeeMaintain();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Controls("");
                BindCompanyandOffice();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Controls(string employeeid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.BindControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlLookupEmployee, ds.Tables[0]);                
                if (ddlLookupEmployee.Items.Count > 0)
                {
                    if(employeeid != "")
                    {
                        if(ddlLookupEmployee.Items.FindByValue(employeeid) != null)
                        {
                            ddlLookupEmployee.SelectedValue = employeeid;
                        }                        
                    }
                    else
                    {
                        ddlLookupEmployee.SelectedIndex = 0;
                    }
                    
                }
                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }   


    private void BindCompanyandOffice()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.BindControls(ObjBOL);            
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCompany, ds.Tables[1]);
                if (ddlCompany.Items.Count > 0)
                {
                    ddlCompany.SelectedIndex = 0;
                }
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlOffice, ds.Tables[2]);
                if (ddlOffice.Items.Count > 0)
                {
                    ddlOffice.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
            throw;
        }
    }



    private void BindDepartment(string officeID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            if(officeID != "")
            {
                ObjBOL.OfficeID = Convert.ToInt32(officeID);
            }            
            ds = ObjBLL.BindControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDepartment, ds.Tables[0]);
                if(ddlDepartment.Items.Count>0)
                {
                    ddlDepartment.SelectedIndex = 0;
                }
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindOfficeAll()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.BindControls(ObjBOL);
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlOffice, ds.Tables[2]);
                if (ddlOffice.Items.Count > 0)
                {
                    ddlOffice.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    
    private void BindOffice(string companyid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            if(companyid != "")
            {
                ObjBOL.CompanyID = Convert.ToInt32(companyid);
            }            
            ds = ObjBLL.BindControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {                
                Utility.BindDropDownList(ddlOffice, ds.Tables[0]);
                if (ddlOffice.Items.Count > 0)
                {
                    ddlOffice.SelectedIndex = 0;
                }         
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void BindEmployee(string officeid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            if (officeid != "")
            {
                ObjBOL.OfficeID = Convert.ToInt32(officeid);
            }
            ds = ObjBLL.BindControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlLookupEmployee, ds.Tables[0]);
                //Utility.BindDropDownList(ddlEmployee, ds.Tables[0]);
                if (ddlLookupEmployee.Items.Count > 0)
                {
                    ddlLookupEmployee.SelectedIndex = 0;
                }
            }
            else
            {
                if (ddlLookupEmployee.Items.Count > 0)
                {
                    ddlLookupEmployee.Items.Clear();
                }
            }
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
            if (ddlCompany.SelectedIndex == 0)
            {               
                Utility.ShowMessage_Error(Page, "Please Select Company. !");
                ddlCompany.Focus();
                ModelAddNewEmployee.Show();
                return false;
            }
            if (ddlOffice.SelectedIndex == 0)
            {                
                Utility.ShowMessage_Error(Page, "Please Select Office. !");
                ddlOffice.Focus();
                ModelAddNewEmployee.Show();
                return false;
            }
            if (ddlDepartment.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Department. !");
                ddlDepartment.Focus();
                ModelAddNewEmployee.Show();
                return false;
            }            
            if (txtExtension.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Extension. !");
                txtExtension.Focus();
                ModelAddNewEmployee.Show();
                return false;
            }           
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void SaveData()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = "";
                if (btnAdd.Text == "Update")
                {
                    ObjBOL.Operation = 7;
                    ObjBOL.EmployeeDetailID = Convert.ToInt32(HfEmployeeID.Value);
                }
                else
                {
                    ObjBOL.Operation = 5;
                }

                if (ddlCompany.SelectedIndex > 0)
                {
                    ObjBOL.CompanyID = Convert.ToInt32(ddlCompany.SelectedValue);
                }
                if (ddlOffice.Items.Count > 0)
                {
                    ObjBOL.OfficeID = Convert.ToInt32(ddlOffice.SelectedValue);
                }
                if (ddlDepartment.Items.Count > 0)
                {
                    ObjBOL.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);
                }
                if (ddlLookupEmployee.SelectedIndex > 0)
                {
                    ObjBOL.EmployeeID = Convert.ToInt32(ddlLookupEmployee.SelectedValue);
                }
                ObjBOL.FirstName = txtFName.Text;
                ObjBOL.LastName = txtLName.Text;
                ObjBOL.Abbreviation = txtAbbriviation.Text;
                if (txtExtension.Text != "")
                {
                    ObjBOL.Extension = Convert.ToInt32(txtExtension.Text);
                }
                ObjBOL.Direct = txtDirect.Text;
                ObjBOL.CellNumber = txtCellNumber.Text;
                ObjBOL.Email = txtEmail.Text;
                ObjBOL.ShowExt = chkShowExt.Checked;
                msg = ObjBLL.Return_String(ObjBOL);
                if (msg != "")
                {
                    if (btnAdd.Text == "Save")
                    {
                        if (msg == "ER")
                        {
                            Utility.ShowMessage_Error(Page, "Extension Already Exists !");
                        }                        
                        else
                        {
                            Utility.ShowMessage_Success(Page, "Record Added Successfully !");
                            Utility.MaintainLogsSpecial("FrmCompanyExtensions", "Save-Extension", msg);
                            ModelAddNewEmployee.Show();
                        }
                    }
                    else
                    {
                        if (msg == "ER")
                        {
                            Utility.ShowMessage_Error(Page, "Extension Already Exists !");
                        }                        
                        else
                        {
                            Utility.ShowMessage_Success(Page, "Record Updated Successfully !");
                            Utility.MaintainLogsSpecial("FrmCompanyExtensions", "Update-Extension", ddlLookupEmployee.SelectedValue);
                            ModelAddNewEmployee.Hide();
                        }

                    }
                    Bind_Grid();
                    Reset();
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
            SaveEmployee();            
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
            txtExtension.Text = String.Empty;            
            txtCellNumber.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtDirect.Text = String.Empty;
            txtAbbriviation.Text = String.Empty;
            chkShowExt.Checked = false;          
            HfEmployeeID.Value = "-1";           
            btnAdd.Text = "Save";                   
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
            if (ddlCompany.Items.Count > 0)
            {
                ddlCompany.SelectedIndex = 0;
            }
            if (ddlOffice.Items.Count > 0)
            {
                ddlOffice.SelectedIndex = 0;
            }
            if (ddlDepartment.Items.Count > 0)
            {
                ddlDepartment.Items.Clear();
            }
            if (ddlLookupEmployee.Items.Count > 0)
            {
                ddlLookupEmployee.SelectedIndex = 0;
            }
            ResetEmployeeForm();
            Reset();
            Bind_Controls("");
            ResetGrid();
            btnAddExt.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetGrid()
    {
        try
        {
            gvManageOffExt.DataSource = "";
            gvManageOffExt.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }    

    private void ResetCompany()
    {
        try
        {            
            if (ddlOffice.Items.Count > 0)
            {
                ddlOffice.SelectedIndex = 0;
            }
            if (ddlDepartment.Items.Count > 0)
            {
                ddlDepartment.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetCompany();
            if (ddlCompany.SelectedIndex > 0)
            {
                BindOffice(ddlCompany.SelectedValue);
            }
            else
            {                        
                Reset();
                BindOfficeAll();
            }
            ModelAddNewEmployee.Show();                
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetOffice()
    {
        try
        {            
            if (ddlDepartment.Items.Count > 0)
            {
                ddlDepartment.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetOffice();
            if (ddlOffice.SelectedIndex > 0)
            {
                BindDepartment(ddlOffice.SelectedValue);
            }
            else
            {                
                Reset();
            }
            ModelAddNewEmployee.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }   

    private void FilleEmployeeDetail()
    {
        try
        {
            if (ddlLookupEmployee.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 13;
                ObjBOL.EmployeeID =Convert.ToInt32(ddlLookupEmployee.SelectedValue);
                ds = ObjBLL.BindControls(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtFName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    txtLName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                    bool isActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["Active"]);
                    string ddlValue = isActive ? "1" : "0"; // Map true to "1" and false to "0"
                    if(ddlStatus.Items.FindByValue(ddlValue) != null)
                    {
                        ddlStatus.SelectedValue = ddlValue;
                    }
                    btnSave.Text = "Update";
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlLookupEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlLookupEmployee.SelectedIndex > 0)
            {
                FilleEmployeeDetail();
                btnAddExt.Enabled = true;
                Bind_Grid();
            }
            else
            {
                Reset();
                ResetEmployeeForm();
                ResetGrid();
                btnAddExt.Enabled = false;
            }
            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillDetails(int EmployeeDetailID)
    {
        try
        {
            if (ddlLookupEmployee.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 6;
                ObjBOL.EmployeeDetailID = EmployeeDetailID;
                ds = ObjBLL.BindControls(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if(ddlCompany.Items.FindByValue(ds.Tables[0].Rows[0]["CompanyID"].ToString())!= null)
                    {
                        ddlCompany.SelectedValue = ds.Tables[0].Rows[0]["CompanyID"].ToString();
                    }
                    if (ddlOffice.Items.FindByValue(ds.Tables[0].Rows[0]["OfficeID"].ToString()) != null)
                    {
                        ddlOffice.SelectedValue = ds.Tables[0].Rows[0]["OfficeID"].ToString();
                    }                        
                    if(ds.Tables[0].Rows[0]["OfficeID"].ToString() != null)
                    {
                        BindDepartment(ddlOffice.SelectedValue);
                        if(ddlDepartment.Items.FindByValue(ds.Tables[0].Rows[0]["DepartmentID"].ToString()) != null)
                        {
                            ddlDepartment.SelectedValue = ds.Tables[0].Rows[0]["DepartmentID"].ToString();
                        }                        
                    }                    
                    txtExtension.Text = ds.Tables[0].Rows[0]["ext"].ToString();
                    txtDirect.Text = ds.Tables[0].Rows[0]["Direct"].ToString();
                    txtCellNumber.Text = ds.Tables[0].Rows[0]["cellnumber"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();                                    
                    txtAbbriviation.Text = ds.Tables[0].Rows[0]["abbrevation"].ToString();
                    bool isActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["showext"]);
                    string ddlValue = isActive ? "1" : "0"; // Map true to "1" and false to "0"
                    if (ddlValue == "1")
                    {
                        chkShowExt.Checked = true;
                    }
                    else
                    {
                        chkShowExt.Checked = false;
                    }
                    btnAdd.Text = "Update";
                }
                else
                {
                    Reset();
                    ddlCompany.SelectedIndex = 0;
                    ddlOffice.SelectedIndex = 0;
                    ddlDepartment.SelectedIndex = 0;
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
            ObjBOL.Operation = 9;
            ObjBOL.EmployeeID = Convert.ToInt32(ddlLookupEmployee.SelectedValue);
            ds = ObjBLL.BindControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvManageOffExt.DataSource = ds.Tables[0];
                gvManageOffExt.DataBind();
            }
            else
            {
                gvManageOffExt.DataSource = "";
                gvManageOffExt.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvManageOffExt_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int EmployeeDetailID = Convert.ToInt32(gvManageOffExt.DataKeys[e.NewEditIndex].Values[0]);
            if (EmployeeDetailID > 0)
            {
                HfEmployeeID.Value = EmployeeDetailID.ToString();
            }
            ModelAddNewEmployee.Show();
            FillDetails(EmployeeDetailID);
            btnAdd.Text = "Update";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvManageOffExt_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int ID = Convert.ToInt32(gvManageOffExt.DataKeys[e.RowIndex].Values[0]);
            string msg = "";
            ObjBOL.Operation = 10;
            ObjBOL.EmployeeDetailID = ID;
            msg = ObjBLL.DeleteExt(ObjBOL);
            if(msg != "")
            {
                Utility.ShowMessage_Success(Page, "Record Deleted Successfully !");
                Utility.MaintainLogsSpecial("FrmCompanyExtensions", "Delete-Extension", ddlLookupEmployee.SelectedValue);
                Bind_Grid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnAddExt_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlLookupEmployee.SelectedIndex > 0)
            {
                if (ddlCompany.Items.Count > 0)
                {
                    ddlCompany.SelectedIndex = 0;
                }
                if (ddlOffice.Items.Count > 0)
                {
                    ddlOffice.SelectedIndex = 0;
                }
                if (ddlDepartment.Items.Count > 0)
                {
                    ddlDepartment.Items.Clear();
                }                
                Reset();
                BindOfficeAll();
                ModelAddNewEmployee.Show();
                btnAdd.Text = "Save";
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please Select Employee !");
                return;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
       
    }

    private bool EmployeeValidationCheck()
    {
        try
        {
            if(txtFName.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter First Name !");
                txtFName.Focus();               
                return false;
            }
            if (ddlStatus.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Status !");
                ddlStatus.Focus();                
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }  

    private void SaveEmployee()
    {
        try
        {
            if (EmployeeValidationCheck() == true)
            {
                string msg = "";
                if(ddlLookupEmployee.SelectedIndex == 0)
                {
                    ObjBOL.Operation = 11;
                }
                else
                {
                    ObjBOL.Operation = 12;
                    if (ddlLookupEmployee.SelectedIndex > 0)
                    {
                        ObjBOL.EmployeeID = Convert.ToInt32(ddlLookupEmployee.SelectedValue);
                    }                   
                }
                ObjBOL.FirstName = txtFName.Text;
                ObjBOL.LastName = txtLName.Text;
                if (ddlStatus.SelectedIndex > 0)
                {
                    if (ddlStatus.SelectedValue == "1")
                    {
                        ObjBOL.Active = true;
                    }
                    else
                    {
                        ObjBOL.Active = false;
                    }
                }
                msg = ObjBLL.Return_String(ObjBOL).Trim();
                if (msg.Length > 0)
                {
                    if (msg == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "Name already exists !!");                        
                        return;
                    }                   

                    if (msg == "U")
                    {
                        Utility.ShowMessage_Success(Page, "Employee Updated Successfully !!");
                        Utility.MaintainLogsSpecial("FrmCompanyExtensions", "Update", ddlLookupEmployee.SelectedValue);
                        Bind_Controls(ddlLookupEmployee.SelectedValue);
                    }
                    else
                    {
                        Utility.ShowMessage_Success(Page, "Employee Added Successfully !!");
                        Utility.MaintainLogsSpecial("FrmCompanyExtensions", "Save", msg);
                        Bind_Controls(msg);
                        btnSave.Text = "Update";
                        btnAddExt.Enabled = true;
                    }
                }               
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }




    //btnAdd_Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            SaveData();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetEmployeeForm()
    {
        try
        {
            txtFName.Text = String.Empty;
            txtLName.Text = String.Empty;
            ddlStatus.SelectedIndex = 0;
            btnSave.Text = "Save";        
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    

    //btnReset_Click
    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCompany.Items.Count > 0)
            {
                ddlCompany.SelectedIndex = 0;
            }
            if (ddlOffice.Items.Count > 0)
            {
                ddlOffice.SelectedIndex = 0;
            }
            if (ddlDepartment.Items.Count > 0)
            {
                ddlDepartment.Items.Clear();
            }
            Reset();
            BindOfficeAll();
            ModelAddNewEmployee.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
       
    }
}