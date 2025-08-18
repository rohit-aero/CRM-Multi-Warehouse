using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;


public partial class ContactManagement_FrmActiveTroyEmployeeListing : System.Web.UI.Page
{
    BOLEmployeeListing ObjBOL = new BOLEmployeeListing();
    BLLEmployeeListing ObjBLL = new BLLEmployeeListing();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Control();
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }
    /// <summary>
    /// Prepare Drop Down List Values
    /// </summary>
    //Bind Data in Drop Down List
    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetEmployeeDetail(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlTroyEmployee, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlAbbreviation, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlBranch, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCity, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlState, ds.Tables[4]);
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }
    /// <summary>
    /// After change on ddlTroyEmployee autofill 
    /// all the information in fields
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //Troy Employee Reps Data Selected Index
    protected void ddlTroyEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlTroyEmployee.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.RepID = Convert.ToInt32(ddlTroyEmployee.SelectedValue);
                ds = ObjBLL.GetEmployeeDetail(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtFirstName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                    txtLastName.Text = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                    ddlAbbreviation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AbbreviationID"]);
                    txtPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]);
                    txtPhoneMail.Text = Convert.ToString(ds.Tables[0].Rows[0]["PhoneMail"]);
                    txtDirectFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["Fax"]);
                    txtCellPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["CellPhone"]);
                    txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    ddlStatus.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                    txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["HomeAddress"]);
                    if (ddlCity.Items.FindByText(ds.Tables[0].Rows[0]["HomeCity"].ToString()) != null)
                    {
                        ddlCity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["HomeCity"]);
                    }

                    if (ddlState.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["HomeState"])) != null)
                    {
                        ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["HomeState"]);
                    }
                    else if (ddlState.Items.Count > 0)
                    {
                        ddlState.SelectedIndex = 0;
                    }
                    txtPostCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["HomePostalCode"]);
                    txtTelephone.Text = Convert.ToString(ds.Tables[0].Rows[0]["HomePhone"]);
                    txtBranchName.Text = Convert.ToString(ds.Tables[0].Rows[0]["BranchName"]);
                    txtCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
                    ddlBranch.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["BranchID"]);
                    txtFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["HomeFax"]);
                    lblMsg.Text = "";
                    btnSave.Text = "Update";
                }

            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Save information if all the
    /// mandetory information entered or present
    /// on the page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //Save Data
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                String msg = "";
                if (ddlTroyEmployee.SelectedIndex > 0)
                {
                    ObjBOL.RepID = Convert.ToInt32(ddlTroyEmployee.SelectedValue);
                }
                else
                {
                    ObjBOL.RepID = 0;
                }
                ObjBOL.Operation = 3;
                ObjBOL.BranchID = 7;
                ObjBOL.FirstName = txtFirstName.Text;
                ObjBOL.LastName = txtLastName.Text;
                ObjBOL.AbbreviationID = Convert.ToInt32(ddlAbbreviation.SelectedValue);
                ObjBOL.Phone = txtPhone.Text;
                ObjBOL.PhoneMail = txtPhoneMail.Text;
                ObjBOL.Fax = txtFax.Text;
                ObjBOL.CellPhone = txtCellPhone.Text;
                ObjBOL.Email = txtEmail.Text;
                ObjBOL.Status = ddlStatus.SelectedValue;
                ObjBOL.HomeAddress = txtAddress.Text;
                ObjBOL.HomeCity = ddlCity.SelectedValue;
                ObjBOL.HomeState = ddlState.SelectedValue;
                ObjBOL.HomePostalCode = txtPostCode.Text;
                ObjBOL.HomePhone = txtTelephone.Text;
                ObjBOL.HomeFax = txtFax.Text;

                msg = ObjBLL.SaveEmployeeDetail(ObjBOL);
                Utility.ShowMessage_Success(this, msg);
                Bind_Control();
                Reset();
                btnSave.Text = "Save";
                Utility.MaintainLogs("FrmActiveTroyEmployeeListing.aspx", "Save");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }
    /// <summary>
    /// After change on ddlBranch autofill 
    /// all the information in fields
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    // Comapny Information
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlBranch.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 4;
                ObjBOL.BranchID = Convert.ToInt32(ddlBranch.SelectedValue);
                ds = ObjBLL.GetEmployeeDetail(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtBranchName.Text = Convert.ToString(ds.Tables[0].Rows[0]["BranchName"]);
                    txtCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
                    lblMsg.Text = "";

                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }
    /// <summary>
    /// for mandetory fields in the page
    /// </summary>
    /// <returns></returns>
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtFirstName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter First Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter First Name. !");
                txtFirstName.Focus();
                return false;
            }

            if (txtLastName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Last Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Last Name. !");
                txtLastName.Focus();
                return false;
            }
            if (ddlAbbreviation.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Abbreviation. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Abbreviation. !");
                ddlAbbreviation.Focus();
                return false;
            }
            if (ddlBranch.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Company Branch. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Company Branch. !");
                ddlBranch.Focus();
                return false;
            }
            if (ddlStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Status. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
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
    /// <summary>
    /// clear all records
    /// </summary>
    private void Reset()
    {
        try
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            ddlAbbreviation.SelectedIndex = 0;
            txtPhone.Text = String.Empty;
            txtPhoneMail.Text = String.Empty;
            txtCellPhone.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtDirectFax.Text = String.Empty;
            ddlStatus.SelectedIndex = 0;
            txtAddress.Text = String.Empty;
            ddlCity.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            txtPostCode.Text = String.Empty;
            txtTelephone.Text = String.Empty;
            txtFax.Text = String.Empty;
            txtCompany.Text = String.Empty;
            txtBranchName.Text = String.Empty;
            ddlBranch.SelectedIndex = 0;
            ddlTroyEmployee.SelectedIndex = 0;
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    /// <summary>
    /// Cancel Records
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

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
}