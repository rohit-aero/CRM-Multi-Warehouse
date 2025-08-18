using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
///  Proposal Form (10 December 2018) Rohit Kumar
/// </summary>
public partial class ContactManagement_FrmRepBranches : System.Web.UI.Page
{
    BOLManageRepBranches ObjBOL = new BOLManageRepBranches();
    BLLManageRepBranches ObjBLL = new BLLManageRepBranches();

    BOLManageRepBranches ObjBOLMember = new BOLManageRepBranches();
    BLLManageRepBranches ObjBLLMember = new BLLManageRepBranches();
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
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetRepBranches(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlBranch, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRegion, ds.Tables[1]);
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
                Utility.BindDropDownList(ddlSaleName, ds.Tables[5]);
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlBranch.SelectedIndex > 0)
            {
                btnSave.Text = "Update";
                hfCusId.Value = ddlBranch.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.BranchID = Convert.ToInt32(ddlBranch.SelectedValue);
                ds = ObjBLL.GetRepBranches(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtLocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["BranchLocation"]);
                    txtBranchName.Text = Convert.ToString(ds.Tables[0].Rows[0]["BranchName"]);
                    Boolean HobartGroup = Convert.ToBoolean(ds.Tables[0].Rows[0]["HobartGroup"]);
                    if (HobartGroup)
                    {
                        chkHobart.Checked = true;
                    }
                    else
                    {
                        chkHobart.Checked = false;
                    }
                    Boolean SteroGroup = Convert.ToBoolean(ds.Tables[0].Rows[0]["SteroGroup"]);
                    if (SteroGroup)
                    {
                        chkStero.Checked = true;
                    }
                    else
                    {
                        chkStero.Checked = false;
                    }
                    ddlRegion.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["RegionID"]);
                    txtComName.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCompanyName"]);
                    txtComStreet.Text = Convert.ToString(ds.Tables[0].Rows[0]["BAddress"]);
                    txtComCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCity"]);
                    ddlComState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["BState"]);
                    ddlComCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CountryID"]);
                    txtComZip.Text = Convert.ToString(ds.Tables[0].Rows[0]["BZip"]);
                    txtComTel.Text = Convert.ToString(ds.Tables[0].Rows[0]["BPhone"]);
                    txtComTollFree.Text = Convert.ToString(ds.Tables[0].Rows[0]["TollFree"]);
                    txtComFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["BFax"]);
                    txtComTollFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TollFax"]);
                    ddlSaleName.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["InsideSalesSupportID"]);
                    txtSaleCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCompanyName"]);
                    txtSaleAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSStreetAddress"]);
                    txtSaleCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISScity"]);
                    ddlSaleState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["issStateID"]);
                    ddlSaleCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["issCountryID"]);
                    txtSaleTel.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSPhone"]);
                    txtSaleCell.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCellPhone"]);
                    txtSaleFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSFax"]);
                    txtSaleEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSEmail"]);
                    lblMsg.Text = "";
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    gvMember.DataSource = ds.Tables[1];
                    gvMember.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    gvMember.DataSource = dt;
                    gvMember.DataBind();
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


    //Bind Members on Customer name change event
    private void Bind_Members()
    {
        try
        {
            ObjBOL.Operation = 2;
            ObjBOL.BranchID = Convert.ToInt32(hfCusId.Value);
            DataSet ds = new DataSet();
            ds = ObjBLL.GetRepBranches(ObjBOL);
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            gvMember.DataSource = ds.Tables[1];
            gvMember.DataBind();
            // }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }


    }

    // Fill all details 
    private void FillDetailsFromPnumber(string strPNumber)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ds = ObjBLL.GetRepBranches(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //txtProNO.Text = Convert.ToString(ds.Tables[0].Rows[0]["PNumber"]);
                //txtProDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["ProposalDate"]));
                //txtJobID.Text = Convert.ToString(ds.Tables[0].Rows[0]["JobID"]);
                //txtProjectName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProjectName"]);
                //txtCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]);
                //ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["StateID"]);
                //ddlStateAb.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["StateID"]);
                //ddlCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Country"]);
                lblMsg.Text = "";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // Set State value on Abbrevation
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ddlState.SelectedIndex > 0)
            //{
            //    ddlStateAb.SelectedValue = ddlState.SelectedValue;
            //}   
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    // Set Abbrevation value on State
    protected void ddlStateAb_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ddlStateAb.SelectedIndex > 0)
            //{
            //    ddlState.SelectedValue = ddlStateAb.SelectedValue;
            //}
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    // check if data filled in required fields
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtLocation.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Location. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Location. !");
                txtLocation.Focus();
                return false;
            }

            if (txtBranchName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Branch. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Branch. !");
                txtBranchName.Focus();
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
            Bind_Controls();
            btnSave.Text = "Save";
            txtLocation.Text = String.Empty;
            txtBranchName.Text = String.Empty;
            chkHobart.Checked = false;
            chkStero.Checked = false;
            ddlRegion.SelectedIndex = 0;
            txtComName.Text = String.Empty;
            txtComStreet.Text = String.Empty;
            txtComCity.Text = String.Empty;
            ddlComState.SelectedIndex = 0;
            ddlComCountry.SelectedIndex = 0;
            txtComZip.Text = String.Empty;
            txtComTel.Text = String.Empty;
            txtComTollFree.Text = String.Empty;
            txtComFax.Text = String.Empty;
            txtComTollFax.Text = String.Empty;
            ddlSaleName.SelectedIndex = 0;
            txtSaleCompany.Text = String.Empty;
            txtSaleAddress.Text = String.Empty;
            txtSaleCity.Text = String.Empty;
            ddlSaleState.SelectedIndex = 0;
            ddlSaleCountry.SelectedIndex = 0;
            txtSaleTel.Text = String.Empty;
            txtSaleCell.Text = String.Empty;
            txtSaleFax.Text = String.Empty;
            txtSaleEmail.Text = String.Empty;
            lblMsg.Text = String.Empty;
            DataTable dt = new DataTable();
            gvMember.DataSource = dt;
            gvMember.DataBind();
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
                if (ddlBranch.SelectedIndex > 0)
                {
                    ObjBOL.BranchID = Convert.ToInt32(ddlBranch.SelectedValue);
                }
                else
                {
                    ObjBOL.BranchID = 0;
                }
                ObjBOL.Operation = 3;
                ObjBOL.BranchLocation = txtLocation.Text;
                ObjBOL.BranchName = txtBranchName.Text;
                ObjBOL.RegionID = Convert.ToInt16(ddlRegion.SelectedValue);
                ObjBOL.CompanyName = txtComName.Text;
                ObjBOL.StreetAddress = txtComStreet.Text;
                ObjBOL.City = txtComCity.Text;
                ObjBOL.StateID = Convert.ToInt16(ddlComState.SelectedValue);
                ObjBOL.CountryID = Convert.ToInt16(ddlComCountry.SelectedValue);
                ObjBOL.ZipCode = txtComZip.Text;
                ObjBOL.Telephone = txtComTel.Text;
                ObjBOL.TollFree = txtComTollFree.Text;
                ObjBOL.TollFax = txtComTollFax.Text;
                ObjBOL.FaxNumber = txtComFax.Text;
                ObjBOL.InsideSalesSupportID = Convert.ToInt32(ddlSaleName.SelectedValue);
                if (chkHobart.Checked == true)
                {
                    ObjBOL.HobartGroup = true;
                }
                else
                {
                    ObjBOL.HobartGroup = false;
                }
                if (chkStero.Checked == true)
                {
                    ObjBOL.SteroGroup = true;
                }
                else
                {
                    ObjBOL.SteroGroup = false;
                }
                msg = ObjBLL.SaveRepBranches(ObjBOL);
                if (ddlBranch.SelectedIndex > 0)
                {
                    hfCusId.Value = ddlBranch.SelectedValue;
                }
                else
                {
                    hfCusId.Value = msg;
                }
                Utility.ShowMessage_Success(this, "Branch Saved !!");
                Utility.MaintainLogs("FrmRepBranches.aspx", "Save");
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

    protected void gvMember_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        try
        {
            gvMember.PageIndex = e.NewPageIndex;
            Bind_Members();
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    protected void ddlSaleName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.BranchID = Convert.ToInt32(ddlSaleName.SelectedValue);
            ds = ObjBLL.GetRepBranches(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtSaleCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCompanyName"]);
                txtSaleAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSStreetAddress"]);
                txtSaleCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISScity"]);
                ddlSaleState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["IssStateID"]);
                ddlSaleCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ISSCountryID"]);
                txtSaleTel.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSPhone"]);
                txtSaleCell.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCellPhone"]);
                txtSaleFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSFax"]);
                txtSaleEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSEmail"]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}