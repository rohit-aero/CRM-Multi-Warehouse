using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
///  Proposal Form (06 December 2018) Rohit Kumar
/// </summary>
public partial class ContactManagement_FrmGillTerritory : System.Web.UI.Page
{
    // Classes
    BOLManageGillTerr ObjBOL = new BOLManageGillTerr();
    BLLManageGillTerr ObjBLL = new BLLManageGillTerr();

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

    // Bind all dropdownlist here
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 1;
            ds = ObjBLL.GetGillTerr(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlTerr, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlEmployee, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlState, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCountry, ds.Tables[3]);
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    // Get details from dropdown selection
    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlTerr.SelectedIndex > 0)
            {
                hfCusId.Value = ddlTerr.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.operation = 3;
                ObjBOL.TerritoryId = Convert.ToInt32(ddlTerr.SelectedValue);
                ds = ObjBLL.GetGillTerr(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTerrName.Text = Convert.ToString(ds.Tables[0].Rows[0]["TerritoryName"]);
                    ddlEmployee.SelectedValue = ds.Tables[0].Rows[0]["EmployeeId"].ToString();
                    //txtComapnyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
                    txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetAddress"]);
                    txtCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]);
                    ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["State"]);
                    ddlCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Country"]);
                    txtZipCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["ZipCode"]);
                    txtPrimaryPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["Phone1"]);
                    txtSecondPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["Phone2"]);
                    txtFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["Fax"]);
                    txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    lblMsg.Text = string.Empty;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // Validate control
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtTerrName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Company Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Company Name. !");
                txtTerrName.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

        return true;
    }

    // Reset all controls
    private void Reset()
    {
        try
        {
            ddlTerr.SelectedIndex = 0;
            //txtComapnyName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlState.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
            txtTerrName.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            txtPrimaryPhone.Text = string.Empty;
            txtSecondPhone.Text = string.Empty;
            txtFax.Text = string.Empty;
            lblMsg.Text = string.Empty;
            txtEmail.Text = String.Empty;
            ddlEmployee.SelectedIndex = 0;
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    // Save data
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = string.Empty;
                string opration = string.Empty;
                if (ddlTerr.SelectedIndex > 0)
                {
                    ObjBOL.TerritoryId = Convert.ToInt32(ddlTerr.SelectedValue);
                    opration = "Update";
                }
                else
                {
                    ObjBOL.TerritoryId = 0;
                    opration = "Save";
                }
                ObjBOL.operation = 2;
                ObjBOL.TerritoryName = txtTerrName.Text;
                ObjBOL.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedValue);
                ObjBOL.StreetAddress = txtAddress.Text;
                ObjBOL.City = txtAddress.Text;
                ObjBOL.State = ddlState.SelectedValue;
                ObjBOL.Country = ddlCountry.SelectedValue;
                ObjBOL.ZipCode = txtZipCode.Text;
                ObjBOL.Phone1 = txtPrimaryPhone.Text;
                ObjBOL.Phone2 = txtSecondPhone.Text;
                ObjBOL.Fax = txtFax.Text;
                ObjBOL.Email = txtFax.Text;
                msg = ObjBLL.SaveGillTerr(ObjBOL);
                Utility.ShowMessage_Success(this, msg);
                if (ddlTerr.SelectedIndex > 0)
                {
                    hfCusId.Value = ddlTerr.SelectedValue;
                }
                else
                {
                    hfCusId.Value = msg;
                }
                //Utility.ShowMessage(this, msg);
                Bind_Controls();
                Reset();
                Utility.MaintainLogs("FrmGillTerritory.aspx", opration);
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

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

}