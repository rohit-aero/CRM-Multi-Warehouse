using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
///  Proposal Form (30 May 2018) Rohit Kumar
/// </summary>
public partial class ContactManagement_FrmEmployees : System.Web.UI.Page
{
    BOLManageEmployees ObjBOL = new BOLManageEmployees();
    BLLManageEmployees ObjBLL = new BLLManageEmployees();

    // Page load event
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
    /// <summary>
    /// Bind all the employees list in the drop down control
    /// </summary>
    // Bind all dropdownlist here
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 2;
            ds = ObjBLL.GetEmployees(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlEmployee, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCountry, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Change data of employees
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlEmployee.SelectedIndex > 0)
            {
                btnSave.Text = "Update";
                hfCusId.Value = ddlEmployee.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.operation = 5;
                ObjBOL.EmployeeID = Convert.ToInt32(ddlEmployee.SelectedValue);
                ds = ObjBLL.GetEmployee(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlDep.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Department"]);
                    txtUserName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Username"]);
                    txtPassword.Text = Convert.ToString(ds.Tables[0].Rows[0]["Passwd"]);
                    txtFName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                    txtLName.Text = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                    txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                    txtCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]);
                    txtState.Text = Convert.ToString(ds.Tables[0].Rows[0]["StateOrProvince"]);
                    txtPref.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    //ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["StateID"]);
                    ddlCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CountryId"]);
                    txtZipCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["PostalCode"]);
                    txtCell.Text = Convert.ToString(ds.Tables[0].Rows[0]["CellPhone"]);
                    txtExt.Text = Convert.ToString(ds.Tables[0].Rows[0]["OfficeExtension"]);
                    txtPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["HomePhone"]);
                    txtNotes.Text = Convert.ToString(ds.Tables[0].Rows[0]["Notes"]);
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Active"]))
                    {
                        ddlStatus.SelectedIndex = 1;
                    }
                    else
                    {
                        ddlStatus.SelectedIndex = 2;
                    }
                    lblMsg.Text = "";
                }
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
    /// <summary>
    /// Validate fields before apply any anction
    /// on the server side
    /// </summary>
    /// <returns></returns>
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtFName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Company Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Company Name. !");
                txtFName.Focus();
                return false;
            }
            if (txtCity.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter City. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter City. !");
                txtCity.Focus();
                return false;
            }
            if (ddlCountry.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Country. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Country. !");
                ddlCountry.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }
    /// <summary>
    /// Cancel all controls
    /// </summary>
    // Reset all controls
    private void Reset()
    {
        try
        {
            Bind_Controls();
            btnSave.Text = "Save";
            ddlEmployee.SelectedIndex = 0;
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            ddlCountry.SelectedIndex = 0;
            txtZipCode.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtCell.Text = string.Empty;
            txtExt.Text = string.Empty;
            ddlStatus.SelectedIndex = 0;
            ddlDep.SelectedIndex = 0;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtNotes.Text = string.Empty;
            lblMsg.Text = "";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Save records after entering validate field values
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Save data
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = "";
                if (ddlEmployee.SelectedIndex > 0)
                {
                    ObjBOL.EmployeeID = Convert.ToInt32(ddlEmployee.SelectedValue);
                }
                else
                {
                    ObjBOL.EmployeeID = 0;
                }
                ObjBOL.operation = 3;
                ObjBOL.Branch = "C";
                ObjBOL.Username = txtUserName.Text;
                ObjBOL.Passwd = txtPassword.Text;
                ObjBOL.Department = ddlDep.SelectedValue;
                ObjBOL.Email = txtPref.Text;
                ObjBOL.FirstName = txtFName.Text;
                ObjBOL.LastName = txtLName.Text;
                ObjBOL.Address = txtAddress.Text;
                ObjBOL.City = txtCity.Text;
                ObjBOL.StateOrProvince = txtState.Text;
                ObjBOL.CountryId = ddlCountry.SelectedValue;
                ObjBOL.PostalCode = txtZipCode.Text;
                ObjBOL.HomePhone = txtPhone.Text;
                ObjBOL.OfficeExtension = txtExt.Text;
                ObjBOL.CellPhone = txtCell.Text;
                ObjBOL.Notes = txtNotes.Text;
                if (ddlStatus.SelectedValue == "1")
                {
                    ObjBOL.Active = true;
                }
                else
                {
                    ObjBOL.Active = false;
                }
                msg = ObjBLL.SaveEmployees(ObjBOL);
                if (ddlEmployee.SelectedIndex > 0)
                {
                    hfCusId.Value = ddlEmployee.SelectedValue;
                }
                else
                {
                    hfCusId.Value = msg;
                }
                Utility.ShowMessage(this, msg);
                Utility.MaintainLogs("FrmEmployees.aspx", "Save");
                Reset();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Cancel information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Cancel command
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
    /// <summary>
    /// members control validation check before 
    /// applying action to the server
    /// </summary>
    /// <returns></returns>
    // check if data filled in required fields of Member
    private Boolean ValidationCheckMember()
    {
        try
        {
            if (txtFName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter First Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter First Name. !");
                txtFName.Focus();
                return false;
            }
            if (txtUserName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter User Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter User Name. !");
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Password. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Password. !");
                txtPassword.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

}