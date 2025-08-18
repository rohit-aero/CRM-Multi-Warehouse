using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
///  Proposal Form (06 December 2018) Rohit Kumar
/// </summary>
public partial class ContactManagement_FrmGillRegion : System.Web.UI.Page
{
    BOLManageGillRegions ObjBOL = new BOLManageGillRegions();
    BLLManageGillRegion ObjBLL = new BLLManageGillRegion();

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
            ds = ObjBLL.GetGillRegion(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRegion, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlState, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCountry, ds.Tables[2]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlRegion.SelectedIndex > 0)
            {
                hfCusId.Value = ddlRegion.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.operation = 3;
                ObjBOL.RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
                ds = ObjBLL.GetGillRegion(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtRegion.Text = Convert.ToString(ds.Tables[0].Rows[0]["Region"]);
                    txtComapnyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
                    txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetAddress"]);
                    txtCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]);
                    ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["State"]);
                    ddlCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Country"]);
                    txtZipCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["ZipCode"]);
                    txtTollFree.Text = Convert.ToString(ds.Tables[0].Rows[0]["Phone1"]);
                    txtPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["Phone2"]);
                    txtFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["Fax"]);
                    lblMsg.Text = "";
                }
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
            if (txtRegion.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Company Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Company Name. !");
                txtRegion.Focus();
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
            ddlRegion.SelectedIndex = 0;
            txtComapnyName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlState.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
            txtRegion.Text = string.Empty;
            txtZipCode.Text = "";
            txtTollFree.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtFax.Text = string.Empty;
            lblMsg.Text = "";
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
                string msg = "";
                if (ddlRegion.SelectedIndex > 0)
                {
                    ObjBOL.RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
                }
                else
                {
                    ObjBOL.RegionId = 0;
                }
                ObjBOL.operation = 2;
                ObjBOL.Region = txtRegion.Text;
                ObjBOL.CompanyName = txtComapnyName.Text;
                ObjBOL.StreetAddress = txtAddress.Text;
                ObjBOL.City = txtAddress.Text;
                ObjBOL.State = ddlState.SelectedValue;
                ObjBOL.Country = ddlCountry.SelectedValue;
                ObjBOL.Phone1 = txtTollFree.Text;
                ObjBOL.Phone2 = txtPhone.Text;
                ObjBOL.Fax = txtFax.Text;
                ObjBOL.TollFax = txtFax.Text;
                ObjBOL.ZipCode = txtZipCode.Text;
                msg = ObjBLL.SaveGillRegion(ObjBOL);
                if (ddlRegion.SelectedIndex > 0)
                {
                    hfCusId.Value = ddlRegion.SelectedValue;
                }
                else
                {
                    hfCusId.Value = msg;
                }
                Utility.ShowMessage_Success(this, msg);
                Utility.MaintainLogs("FrmGillRegion.aspx", "Save");
                Bind_Controls();
                Reset();
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