using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;

/// <summary>
///  Proposal Form (10 December 2018) Rohit Kumar
/// </summary>
public partial class ContactManagement_FrmActiveSales : System.Web.UI.Page
{
    BOLRepActiveSales ObjBOL = new BOLRepActiveSales();
    BLLManageRepActiveSales ObjBLL = new BLLManageRepActiveSales();

    /// <summary>
    /// Page load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
    /// Bind_Control() function prepare all the drop down lists
    /// </summary>
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetRepActiveSales(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRegion, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlBranchLocation, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlBranchMain, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlComState, ds.Tables[3]);
                Utility.BindDropDownList(ddlSaleState, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlComCountry, ds.Tables[4]);
                Utility.BindDropDownList(ddlSaleCountry, ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlAbbreviation, ds.Tables[5]);
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlJobTitle, ds.Tables[6]);
            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCity, ds.Tables[7]);
            }
            if (ds.Tables[8].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlState, ds.Tables[8]);
            }
            if (ds.Tables[9].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlBranch, ds.Tables[9]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Fill details after change of ddlBranch List items
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlBranch.SelectedIndex > 0)
            {
                btnEdit.Text = "Save";
                hfCusId.Value = ddlBranch.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.BranchID = Convert.ToInt32(ddlBranch.SelectedValue);
                ds = ObjBLL.GetRepActiveSales(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlRegion.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["RegionID"]);
                    ddlBranchMain.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["BranchName"]);
                    ddlBranchLocation.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["BranchLocation"]);
                    txtBranchCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["BranchCompanyName"]);
                    txtComStreet.Text = Convert.ToString(ds.Tables[0].Rows[0]["BranchAddress"]);
                    txtComCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["BranchCity"]);
                    ddlComState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["StateID"]);
                    ddlComCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CountryID"]);
                    txtComZip.Text = Convert.ToString(ds.Tables[0].Rows[0]["branchZipCode"]);
                    txtComTel.Text = Convert.ToString(ds.Tables[0].Rows[0]["BPhone"]);
                    txtComTollFree.Text = Convert.ToString(ds.Tables[0].Rows[0]["TollFree"]);
                    txtComTollFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TollFax"]);
                    txtComFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["BFax"]);
                    txtISSName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSName"]);
                    txtSaleCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCompanyName"]);
                    txtSaleAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSStreetAddress"]);
                    txtSaleCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISScity"]);
                    ddlSaleState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["IssStateID"]);
                    ddlSaleCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ISSCountryID"]);
                    txtSaleTel.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSPhone"]);
                    txtSaleFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSFax"]);
                    txtSaleCell.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCellPhone"]);
                    txtSaleEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSEmail"]);
                    txtFirstName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                    txtLastName.Text = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                    ddlAbbreviation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AbbreviationID"]);
                    ddlJobTitle.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AbbreviationID"]);
                    txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["REmail"]);
                    txtDirectPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["DirectPhone"]);
                    txtCellPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["CellPhone"]);
                    txtDirectFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["Fax"]);
                    txtPhoneMail.Text = Convert.ToString(ds.Tables[0].Rows[0]["PhoneMail"]);
                    ddlStatus.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                    Boolean RHomeOffice = Convert.ToBoolean(ds.Tables[0].Rows[0]["RHomeOffice"]);
                    if (RHomeOffice == true)
                    {
                        chkOffMail.Checked = true;
                    }
                    else
                    {
                        chkOffMail.Checked = false;
                    }
                    txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["HomeAddress"]);
                    ddlCity.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["HomeCity"]);
                    ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["HomeState"]);
                    txtPostalCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["HomePostalCode"]);
                    txtPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["HomePhone"]);
                    txtFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["HomeFax"]);
                    lblMsg.Text = "";
                    btnEdit.Text = "Save";
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// check if data filled in required fields
    /// </summary>
    /// <returns></returns>
    private Boolean ValidationCheck()
    {
        try
        {
            if (ddlBranch.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Rep. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Rep. !");
                ddlBranch.Focus();
                return false;
            }
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
            if (ddlStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Employee Status. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Employee Status. !");
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
    /// Reset all controls
    /// </summary>
    /// <returns></returns>
    private void Reset()
    {
        try
        {
            ddlRegion.SelectedIndex = 0;
            ddlBranchMain.SelectedIndex = 0;
            ddlBranchLocation.SelectedIndex = 0;
            ddlBranchLocation.SelectedItem.Text = String.Empty;
            txtBranchCompany.Text = String.Empty;
            txtComStreet.Text = String.Empty;
            txtComCity.Text = String.Empty;
            ddlComState.SelectedIndex = 0;
            ddlComCountry.SelectedIndex = 0;
            txtComZip.Text = String.Empty;
            txtComTel.Text = String.Empty;
            txtComTollFree.Text = String.Empty;
            txtComTollFax.Text = String.Empty;
            txtComFax.Text = String.Empty;
            txtISSName.Text = String.Empty;
            txtSaleCompany.Text = String.Empty;
            txtSaleAddress.Text = String.Empty;
            txtSaleCity.Text = String.Empty;
            ddlSaleState.SelectedIndex = 0;
            ddlSaleCountry.SelectedIndex = 0;
            txtSaleTel.Text = String.Empty;
            txtSaleFax.Text = String.Empty;
            txtSaleCell.Text = String.Empty;
            txtSaleEmail.Text = String.Empty;
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            ddlAbbreviation.SelectedIndex = 0;
            txtEmail.Text = String.Empty;
            txtDirectPhone.Text = String.Empty;
            txtCellPhone.Text = String.Empty;
            txtDirectFax.Text = String.Empty;
            txtPhoneMail.Text = String.Empty;
            ddlStatus.SelectedIndex = 0;
            chkOffMail.Checked = false;
            txtAddress.Text = String.Empty;
            ddlJobTitle.SelectedIndex = 0;
            ddlCity.SelectedIndex = 0;
            ddlCity.SelectedItem.Text = String.Empty;
            ddlState.SelectedIndex = 0;
            txtPostalCode.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtFax.Text = String.Empty;
            ddlBranch.SelectedIndex = 0;
            btnEdit.Text = "Edit";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Save data if all the validations check true
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = "";
                if (ddlBranch.SelectedIndex > 0)
                {
                    ObjBOL.BranchID = Convert.ToInt32(ddlBranch.SelectedValue);
                }
                else
                {
                    ObjBOL.BranchID = 0;
                }
                ObjBOL.Operation = 3;
                ObjBOL.FirstName = txtFirstName.Text;
                ObjBOL.LastName = txtLastName.Text;
                ObjBOL.AbbreviationID = Convert.ToInt32(ddlAbbreviation.SelectedValue);
                ObjBOL.Email = txtEmail.Text;
                ObjBOL.Phone = txtDirectPhone.Text;
                ObjBOL.Fax = txtDirectFax.Text;
                ObjBOL.CellPhone = txtCellPhone.Text;
                ObjBOL.PhoneMail = Convert.ToInt32(txtPhoneMail.Text);
                ObjBOL.Status = ddlStatus.SelectedItem.Text;
                if (chkOffMail.Checked == true)
                {
                    ObjBOL.HomeOffice = true;
                }
                else
                {
                    ObjBOL.HomeOffice = false;
                }
                ObjBOL.HomeAddress = txtAddress.Text;
                ObjBOL.HomeCity = ddlCity.SelectedItem.Text;
                ObjBOL.HomeState = ddlState.SelectedValue;
                ObjBOL.HomePostalCode = txtPostalCode.Text;
                ObjBOL.HomeFax = txtFax.Text;
                ObjBOL.HomePhone = txtPhone.Text;
                msg = ObjBLL.SaveRepActiveSales(ObjBOL);
                Utility.ShowMessage_Success(this, "Branch Updated !!");
                Utility.MaintainLogs("FrmActiveSales.aspx", "Save");
                Reset();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Cancel all the fields
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

    /// <summary>
    /// Check branch location
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlBranchLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlBranchLocation.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 4;
                ObjBOL.BranchID = Convert.ToInt32(ddlBranchLocation.SelectedValue);
                ds = ObjBLL.GetRepActiveSales(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlRegion.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["RegionID"]);
                    ddlBranchMain.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["BranchName"]);
                    ddlBranchLocation.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["BranchLocation"]);
                    txtBranchCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCompanyName"]);
                    txtComStreet.Text = Convert.ToString(ds.Tables[0].Rows[0]["BAddress"]);
                    txtComCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCity"]);
                    ddlComState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["BState"]);
                    ddlComCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CountryID"]);
                    txtComZip.Text = Convert.ToString(ds.Tables[0].Rows[0]["BZip"]);
                    txtComTel.Text = Convert.ToString(ds.Tables[0].Rows[0]["BPhone"]);
                    txtComTollFree.Text = Convert.ToString(ds.Tables[0].Rows[0]["TollFree"]);
                    txtComTollFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TollFax"]);
                    txtComFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["BFax"]);
                    txtISSName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSName"]);
                    txtSaleCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCompanyName"]);
                    txtSaleAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSStreetAddress"]);
                    txtSaleCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISScity"]);
                    ddlSaleState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["IssStateID"]);
                    ddlSaleCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ISSCountryID"]);
                    txtSaleTel.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSPhone"]);
                    txtSaleFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSFax"]);
                    txtSaleCell.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCellPhone"]);
                    txtSaleEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSEmail"]);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}