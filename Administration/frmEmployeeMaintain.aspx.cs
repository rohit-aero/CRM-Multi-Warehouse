using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;

public partial class Administration_frmEmployeeMaintain : System.Web.UI.Page
{
    BOLEmployeeMaintain ObjBOL = new BOLEmployeeMaintain();
    BLLEmployeeMaintain ObjBLL = new BLLEmployeeMaintain();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEmployee("");
            Bind_Controls();
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
                Utility.BindDropDownList(ddlCountry, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlEngDepartment, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDivision, ds.Tables[2]);
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
            if (txtFirstName.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter First Name !!");
                txtFirstName.Focus();
                return false;
            }           

            //if (chkEmpStatus.Checked == false)
            //{
            //    Utility.ShowMessage_Error(Page, "Please Check Active !!");
            //    chkEmpStatus.Focus();
            //    return false;
            //}


            
            //if (txtEmail.Text == "")
            //{
            //    Utility.ShowMessage_Error(Page, "Please Enter Email !!");
            //    txtEmail.Focus();
            //    return false;
            //}
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
            if (ValidationCheck())
            {
                string msg = "";
                if (ddlLookupEmployee.SelectedIndex > 0)
                {
                    ObjBOL.EmployeeID = Convert.ToInt32(ddlLookupEmployee.SelectedValue);
                }
                ObjBOL.FirstName = txtFirstName.Text;
                ObjBOL.LastName = txtLastName.Text;
                ObjBOL.Branch = txtBranch.Text;
                ObjBOL.UserName = txtUserName.Text;
                ObjBOL.Password = txtPasssword.Text;
                if (ddlDepartment.SelectedIndex > 0)
                {
                    ObjBOL.Department = ddlDepartment.SelectedValue;
                }
                ObjBOL.Address = txtAddress.Text;
                if (ddlCountry.SelectedIndex > 0)
                {
                    ObjBOL.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
                }
                if (ddlState.SelectedIndex > 0)
                {
                    ObjBOL.StateOrProvince = ddlState.SelectedItem.Text;
                }
                ObjBOL.City = txtCity.Text;
                ObjBOL.PostalCode = txtPostalCode.Text;
                ObjBOL.HomePhone = txtHomePhone.Text;
                ObjBOL.Status = chkEmpStatus.Checked;
                ObjBOL.Notes = txtNotes.Text;
                ObjBOL.Abbrivation = txtAbbrivation.Text;
                ObjBOL.DOB = Utility.ConvertDate(txtDOB.Text);

                if (ddlEngDepartment.SelectedIndex > 0)
                {
                    ObjBOL.EngDepID = Convert.ToInt32(ddlEngDepartment.SelectedValue);
                }

                if (ddlDivision.SelectedIndex > 0)
                {
                    ObjBOL.DivisionID = Convert.ToInt32(ddlDivision.SelectedValue);
                }
                ObjBOL.Email = txtEmail.Text;               
                //ObjBOL.Full = chkFull.Checked;F
                //ObjBOL.Half = chkHalf.Checked;
                //ObjBOL.ViewandMinimum = chkViewandMinimum.Checked;
                //ObjBOL.Restrict = chkRestrict.Checked;
                //ObjBOL.ViewOnly = chkViewOnly.Checked;
                ObjBOL.Operation = 2;
                msg = ObjBLL.SaveEmployeeRecord(ObjBOL).Trim();
                if (msg.Length > 0)
                {
                    if (msg == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "Name already exists !!");
                        return;
                    }

                    if (msg != "S")
                    {
                        Utility.ShowMessage_Success(Page, "Records Added Successfully !!");
                        BindEmployee(msg);
                        btnSave.Text = "Update";
                        Utility.MaintainLogsSpecial("FrmEmployeeMaintain", "Save", msg);
                    }
                    else
                    {
                        Utility.ShowMessage_Success(Page, "Record Updated successfully !!");
                        BindEmployee(ddlLookupEmployee.SelectedValue);
                        Utility.MaintainLogsSpecial("FrmEmployeeMaintain", "Update", ddlLookupEmployee.SelectedValue);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindEmployee(string EmployeeID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlLookupEmployee, ds.Tables[0]);
                if (EmployeeID != "")
                {
                    ddlLookupEmployee.SelectedValue = EmployeeID;
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
        SaveData();
    }

    private void BindState(string CountryID)
    {
        try
        {
            if (ddlCountry.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 5;
                ObjBOL.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
                ds = ObjBLL.GetControls(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlState, ds.Tables[0]);
                }
                else
                {
                    if (ddlState.Items.Count > 0)
                    {
                        ddlState.Items.Clear();
                    }
                    
                }
            }
            else
            {
                if (ddlState.Items.Count > 0)
                {
                    ddlState.Items.Clear();
                }
               
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillEmployeeData()
    {
        try
        {
            if (ddlLookupEmployee.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 4;
                ObjBOL.EmployeeID = Convert.ToInt32(ddlLookupEmployee.SelectedValue);
                ds = ObjBLL.GetControls(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                    txtBranch.Text = ds.Tables[0].Rows[0]["Branch"].ToString();
                    txtUserName.Text = ds.Tables[0].Rows[0]["Username"].ToString();
                    txtPasssword.Text = ds.Tables[0].Rows[0]["Passwd"].ToString();
                    if (ddlDepartment.Items.FindByValue(ds.Tables[0].Rows[0]["Department"].ToString()) != null)
                    {
                        ddlDepartment.SelectedValue = ds.Tables[0].Rows[0]["Department"].ToString();
                    }
                    else
                    {
                        if (ddlDepartment.Items.Count > 0)
                        {
                            ddlDepartment.SelectedIndex = 0;
                        }
                    }

                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    if (ddlCountry.Items.FindByValue(ds.Tables[0].Rows[0]["CountryId"].ToString()) != null)
                    {
                        ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["CountryId"].ToString();
                        BindState(ddlCountry.SelectedValue);
                    }
                    else
                    {
                        if (ddlCountry.Items.Count > 0)
                        {
                            ddlCountry.SelectedIndex = 0;
                        }
                    }

                    if (ddlState.Items.FindByText(ds.Tables[0].Rows[0]["StateOrProvince"].ToString()) != null)
                    {
                        ListItem selectedStateItem = null;
                        selectedStateItem = ddlState.Items.FindByText(ds.Tables[0].Rows[0]["StateOrProvince"].ToString());
                        if (selectedStateItem != null)
                        {
                            selectedStateItem.Selected = true;
                        }
                    }
                    txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                    txtPostalCode.Text = ds.Tables[0].Rows[0]["PostalCode"].ToString();
                    txtHomePhone.Text = ds.Tables[0].Rows[0]["HomePhone"].ToString();                   
                    txtNotes.Text = ds.Tables[0].Rows[0]["Notes"].ToString();
                    txtAbbrivation.Text = ds.Tables[0].Rows[0]["Abbrivation"].ToString();
                    txtDOB.Text = ds.Tables[0].Rows[0]["dob"].ToString();
                    if (ddlEngDepartment.Items.FindByValue(ds.Tables[0].Rows[0]["EngDepID"].ToString()) != null)
                    {
                        ddlEngDepartment.SelectedValue = ds.Tables[0].Rows[0]["EngDepID"].ToString();
                    }
                    else
                    {
                        if (ddlEngDepartment.Items.Count > 0)
                        {
                            ddlEngDepartment.SelectedIndex = 0;
                        }
                    }

                    if (ddlDivision.Items.FindByValue(ds.Tables[0].Rows[0]["DivisionID"].ToString()) != null)
                    {
                        ddlDivision.SelectedValue = ds.Tables[0].Rows[0]["DivisionID"].ToString();
                    }
                    else
                    {
                        if (ddlDivision.Items.Count > 0)
                        {
                            ddlDivision.SelectedIndex = 0;
                        }
                    }
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Active"]) == true)
                    {
                        chkEmpStatus.Checked = true;
                    }
                    else
                    {
                        chkEmpStatus.Checked = false;
                    }                   
                    //if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Full"]) == true)
                    //{
                    //    chkFull.Checked = true;
                    //}
                    //else
                    //{
                    //    chkFull.Checked = false;
                    //}
                    //if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Half"]) == true)
                    //{
                    //    chkHalf.Checked = true;
                    //}
                    //else
                    //{
                    //    chkHalf.Checked = false;
                    //}
                    //if (Convert.ToBoolean(ds.Tables[0].Rows[0]["ViewAndMinimum"]) == true)
                    //{
                    //    chkViewandMinimum.Checked = true;
                    //}
                    //else
                    //{
                    //    chkViewandMinimum.Checked = false;
                    //}
                    //if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Restrict"]) == true)
                    //{
                    //    chkRestrict.Checked = true;
                    //}
                    //else
                    //{
                    //    chkRestrict.Checked = false;
                    //}
                    //if (Convert.ToBoolean(ds.Tables[0].Rows[0]["ViewOnly"]) == true)
                    //{
                    //    chkViewOnly.Checked = true;
                    //}
                    //else
                    //{
                    //    chkViewOnly.Checked = false;
                    //}
                    btnSave.Text = "Update";
                }
                else
                {
                    Reset();
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
                FillEmployeeData();
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

    private void Reset()
    {
        try
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtBranch.Text = String.Empty;
            txtUserName.Text = String.Empty;
            txtPasssword.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtDOB.Text = String.Empty;
            if (ddlDepartment.Items.Count > 0)
            {
                ddlDepartment.SelectedIndex = 0;
            }

            if (ddlEngDepartment.Items.Count > 0)
            {
                ddlEngDepartment.SelectedIndex = 0;
            }

            if (ddlDivision.Items.Count > 0)
            {
                ddlDivision.SelectedIndex = 0;
            }

            if (ddlCountry.Items.Count > 0)
            {
                ddlCountry.SelectedIndex = 0;
            }

            if (ddlState.Items.Count > 0)
            {
                ddlState.Items.Clear();
            }
            txtCity.Text = String.Empty;
            txtPostalCode.Text = String.Empty;
            txtHomePhone.Text = String.Empty;           
            chkEmpStatus.Checked = false;
            txtEmail.Text = String.Empty;
            txtAbbrivation.Text = String.Empty;
            txtNotes.Text = String.Empty;
            if (ddlLookupEmployee.Items.Count > 0)
            {
                ddlLookupEmployee.SelectedIndex = 0;
            }

            //chkFull.Checked = false;
            //chkHalf.Checked = false;
            //chkViewandMinimum.Checked = false;
            //chkRestrict.Checked = false;
            //chkViewOnly.Checked = false;            
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindState(ddlCountry.SelectedValue);
    }     
}