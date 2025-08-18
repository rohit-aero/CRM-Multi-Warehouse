using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;

public partial class ContactManagement_FrmBranchInformation : System.Web.UI.Page
{
    BOLManageBranchInformation ObjBOL = new BOLManageBranchInformation();
    BLLManageBranchInformation ObjBLL = new BLLManageBranchInformation();
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

    #region Binding

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetBranchInformation(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDivisionHeaderList, ds.Tables[0]);
                Utility.BindDropDownList(ddlDivision, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRegion, ds.Tables[1]);
            }

            //if (ds.Tables[2].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlSaleName, ds.Tables[2]);
            //}
            //if (ds.Tables[3].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlState, ds.Tables[3]);
            //    Utility.BindDropDownList(ddlSaleState, ds.Tables[3]);
            //}
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCountry, ds.Tables[3]);
                //Utility.BindDropDownList(ddlSaleCountry, ds.Tables[3]);
            }

            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRepGroup, ds.Tables[4]);
            }

            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRepHeaderList, ds.Tables[5]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindState(Int16 country)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ObjBOL.CountryID = country;
            ds = ObjBLL.GetBranchState(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlState, ds.Tables[0]);
            }
            else
            {
                ddlState.DataSource = "";
                ddlState.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindAfterUpdate()
    {
        try
        {
            ObjBOL.Operation = 8;
            ObjBOL.RepGroupID = Int32.Parse(ddlRepGroup.SelectedValue);
            string divisionIdForRep = ObjBLL.SaveBranchInformation(ObjBOL);
            var repGroup = ddlRepGroup.SelectedValue;
            var branch = ddlbranch.SelectedValue;
            Reset();
            if (Int32.Parse(branch) > 0)
            {
                ddlDivisionHeaderList.SelectedValue = divisionIdForRep.Trim();
                ddlDivisionHeaderEvent();
                ddlRepGroupHeaderList.SelectedValue = repGroup;
                ddlRepGroupHeaderEvent();
                ddlbranch.SelectedValue = branch;
                ddlBranchEvent();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Validation Function

    private Boolean ValidationCheck()
    {
        try
        {
            if (ddlDivision.SelectedIndex == 0)
            {
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Region. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Division. !");
                ddlDivision.Focus();
                return false;
            }

            if (ddlRepGroup.SelectedIndex == 0)
            {
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Region. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Rep Group. !");
                ddlRepGroup.Focus();
                return false;
            }

            if (txtBranchLocation.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Branch Location. !')", true);
                Utility.ShowMessage_Error(Page, "Please Enter Branch Location. !");
                txtBranchLocation.Focus();
                return false;
            }

            if (txtBranchName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Branch Name. !')", true);
                Utility.ShowMessage_Error(Page, "Please Enter Branch Name. !");
                txtBranchName.Focus();
                return false;
            }

            if (ddlRegion.SelectedIndex == 0)
            {
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Region. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Region. !");
                ddlRegion.Focus();
                return false;
            }

            if (txtCompanyName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Company Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Company Name. !");
                txtCompanyName.Focus();
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

    #region Event Functions

    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlBranchEvent();
            GetRepsForBranch();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlSaleName_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            //DataSet ds = new DataSet();
            //ObjBOL.Operation = 4;
            //ObjBOL.BranchID = Convert.ToInt32(ddlSaleName.SelectedValue);
            //ds = ObjBLL.GetBranchInformation(ObjBOL);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    txtSaleCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCompanyName"]);
            //    txtSaleAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSStreetAddress"]);
            //    txtSaleCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISScity"]);
            //    ddlSaleState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["IssStateID"]);
            //    ddlSaleCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ISSCountryID"]);
            //    txtSaleTelephone.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSPhone"]);
            //    txtSaleCellPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCellPhone"]);
            //    txtSaleFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSFax"]);
            //    txtSaleEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSEmail"]);
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindState(Convert.ToInt16(ddlCountry.SelectedValue));
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlRepGroupHeader_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlRepGroupHeaderEvent();
            GetAllReps();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlDivisionHeader_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlDivisionHeaderEvent();
            GetAllReps();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlDivisionEvent();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlRepHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlRepHeaderList.SelectedIndex > 0)
            {
                ObjBOL.Operation = 9;
                ObjBOL.RepGroupID = Int32.Parse(ddlRepHeaderList.SelectedValue);
                DataSet ds = new DataSet();
                ds = ObjBLL.GetBranchInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (ddlDivisionHeaderList.Items.FindByValue(row["ProductLineID"].ToString()) != null)
                    {
                        ddlDivisionHeaderList.SelectedValue = row["ProductLineID"].ToString();
                        ddlDivisionHeaderEvent();
                        if (ddlRepGroupHeaderList.Items.FindByValue(row["RepGroupID"].ToString()) != null)
                        {
                            ddlRepGroupHeaderList.SelectedValue = row["RepGroupID"].ToString();
                            ddlRepGroupHeaderEvent();
                            if (ddlbranch.Items.FindByValue(row["BranchID"].ToString()) != null)
                            {
                                ddlbranch.SelectedValue = row["BranchID"].ToString();
                                ddlBranchEvent();
                            }
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
            if (ValidationCheck() == true)
            {
                String msg = "";
                if (ddlbranch.SelectedIndex > 0)
                {
                    ObjBOL.BranchID = Convert.ToInt32(ddlbranch.SelectedValue);
                }
                else
                {
                    ObjBOL.BranchID = 0;
                }
                ObjBOL.Operation = 3;
                ObjBOL.BranchLocation = txtBranchLocation.Text;
                ObjBOL.BranchName = txtBranchName.Text;
                if (ddlRegion.SelectedIndex > 0)
                {
                    ObjBOL.RegionID = Convert.ToInt16(ddlRegion.SelectedValue);
                }
                if (ddlRepGroup.SelectedIndex > 0)
                {
                    ObjBOL.RepGroupID = Int32.Parse(ddlRepGroup.SelectedValue);
                }
                ObjBOL.CompanyName = txtCompanyName.Text;
                ObjBOL.StreetAddress = txtStrAddress.Text;
                if (ddlCountry.SelectedIndex > 0)
                {
                    ObjBOL.CountryID = Convert.ToInt16(ddlCountry.SelectedValue);
                }
                if (ddlState.SelectedIndex > 0)
                {
                    ObjBOL.StateID = Convert.ToInt16(ddlState.SelectedValue);
                }
                ObjBOL.City = txtCity.Text;
                ObjBOL.ZipCode = txtZipCode.Text;
                ObjBOL.Telephone = txtTelephone.Text;
                ObjBOL.FaxNumber = txtFaxNumber.Text;
                ObjBOL.TollFree = txtTollFree.Text;
                ObjBOL.TollFax = txtTollFax.Text;
                //if (ddlSaleName.SelectedIndex > 0)
                //{
                //    ObjBOL.InsideSalesSupportID = Convert.ToInt32(ddlSaleName.SelectedValue);
                //}
                ObjBOL.StatesCovered = txtStates.Text;
                //if (chkHobart.Checked == true)
                //{
                //    ObjBOL.HobartGroup = true;
                //}
                //else
                //{
                //    ObjBOL.HobartGroup = false;
                //}
                //if (chkStero.Checked == true)
                //{
                //    ObjBOL.SteroGroup = true;
                //}
                //else
                //{
                //    ObjBOL.SteroGroup = false;
                //}
                msg = ObjBLL.SaveBranchInformation(ObjBOL);
                if (msg.Trim() != "")
                {
                    if (msg.Trim() == "ER01")
                    {
                        Utility.ShowMessage_Error(this, "Branch with same name and location already exists !");
                        return;
                    }

                    if (msg.Trim() == "ER02")
                    {
                        Utility.ShowMessage_Error(this, "Branch ID doesnot exists !");
                        return;
                    }

                    if (ddlbranch.SelectedIndex > 0)
                    {
                        hfCusId.Value = ddlbranch.SelectedValue;
                        Utility.ShowMessage_Success(this, "Branch Updated Successfully !!");
                        Utility.MaintainLogsSpecial("FrmBranchInformation.aspx", "Update", msg.Trim());
                        BindAfterUpdate();
                    }
                    else
                    {
                        hfCusId.Value = msg;
                        Utility.ShowMessage_Success(this, "Branch Inserted Successfully !!");
                        Utility.MaintainLogsSpecial("FrmBranchInformation.aspx", "Save", msg.Trim());
                    }
                }

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
            GetAllReps();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion 

    #region EventInternalFunctions

    private void ddlRepGroupHeaderEvent()
    {
        try
        {
            ResetInfo();
            if (ddlRepGroupHeaderList.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 6;
                ObjBOL.BranchID = Int32.Parse(ddlRepGroupHeaderList.SelectedValue);
                ds = ObjBLL.GetBranchInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlbranch, ds.Tables[0]);
                }
                else
                {
                    ddlbranch.Items.Clear();
                    ResetInfo();
                }
            }
            else
            {
                ddlbranch.Items.Clear();
                ResetInfo();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlBranchEvent()
    {
        try
        {
            if (ddlbranch.SelectedIndex > 0)
            {
                ddlDivision.SelectedValue = ddlDivisionHeaderList.SelectedValue;
                ddlDivisionEvent();
                hfCusId.Value = ddlbranch.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.BranchID = Convert.ToInt32(ddlbranch.SelectedValue);
                ds = ObjBLL.GetBranchInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if(ddlbranch.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["branchId"])) != null)
                    {
                        ddlbranch.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["branchId"]);
                    }                    
                    txtBranchName.Text = Convert.ToString(ds.Tables[0].Rows[0]["BranchName"]);
                    //Boolean HobartGroup = Convert.ToBoolean(ds.Tables[0].Rows[0]["HobartGroup"]);
                    //if (HobartGroup)
                    //{
                    //    chkHobart.Checked = true;
                    //}
                    //else
                    //{
                    //    chkHobart.Checked = false;
                    //}
                    //Boolean SteroGroup = Convert.ToBoolean(ds.Tables[0].Rows[0]["SteroGroup"]);
                    //if (SteroGroup)
                    //{
                    //    chkStero.Checked = true;
                    //}
                    //else
                    //{
                    //    chkStero.Checked = false;
                    //}
                    txtBranchLocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["BranchLocation"]);
                    if(ddlRegion.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["RegionId"])) != null)
                    {
                        ddlRegion.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["RegionId"]);
                    }              
                    if(ddlRepGroup.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["RepGroupID"])) != null)
                    {
                        ddlRepGroup.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["RepGroupID"]);
                    }                          
                    txtCompanyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCompanyName"]);
                    txtStrAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["BAddress"]);
                    if (ddlCountry.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["CountryId"])) != null)
                    {
                        ddlCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CountryId"]);
                        BindState(Convert.ToInt16(ddlCountry.SelectedValue));
                    }
                    if (ddlState.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["BState"])) != null)
                    {
                        ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["BState"]);
                    }
                    txtCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["BCity"]);
                    txtZipCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["BZip"]);
                    txtTelephone.Text = Convert.ToString(ds.Tables[0].Rows[0]["Bphone"]);
                    txtFaxNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["BFax"]);
                    txtTollFree.Text = Convert.ToString(ds.Tables[0].Rows[0]["TollFree"]);
                    txtTollFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["TollFax"]);
                    //txtSaleCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCompanyName"]);
                    //ddlSaleName.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["InsideSalesSupportID"]);
                    //txtSaleAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSStreetAddress"]);
                    //ddlSaleCountry.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCountryID"]);
                    //ddlSaleState.Text = Convert.ToString(ds.Tables[0].Rows[0]["IssStateID"]);
                    //txtSaleCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISScity"]);
                    //txtSaleTelephone.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSPhone"]);
                    //txtSaleCellPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCellPhone"]);
                    //txtSaleFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSFax"]);
                    //txtSaleEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSEmail"]);
                    txtStates.Text = Convert.ToString(ds.Tables[0].Rows[0]["StatesCovered"]);
                    lblMsg.Text = "";
                    btnSave.Text = "Update";
                }
            }
            else
            {
                ResetInfo();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlDivisionHeaderEvent()
    {
        try
        {
            ResetForDivisionHeader();
            if (ddlDivisionHeaderList.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 7;
                ObjBOL.BranchID = Int32.Parse(ddlDivisionHeaderList.SelectedValue);
                ds = ObjBLL.GetBranchInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlRepGroupHeaderList, ds.Tables[0]);
                }
                else
                {
                    ResetForDivisionHeader();
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

    private void ddlDivisionEvent()
    {
        try
        {
            ddlRepGroup.Items.Clear();
            if (ddlDivision.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 7;
                ObjBOL.BranchID = Int32.Parse(ddlDivision.SelectedValue);
                ds = ObjBLL.GetBranchInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlRepGroup, ds.Tables[0]);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetRepsForBranch()
    {
        try
        {
            if (ddlbranch.SelectedIndex > 0)
            {
                ObjBOL.Operation = 10;
                ObjBOL.RepGroupID = Int32.Parse(ddlbranch.SelectedValue);
                DataSet ds = new DataSet();
                ds = ObjBLL.GetBranchInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlRepHeaderList, ds.Tables[0]);
                }
                else
                {
                    ddlRepHeaderList.Items.Clear();
                }
            }
            else
            {
                GetAllReps();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetAllReps()
    {
        try
        {
            ObjBOL.Operation = 11;
            DataSet ds = new DataSet();
            ds = ObjBLL.GetBranchInformation(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRepHeaderList, ds.Tables[0]);
                ddlRepHeaderList.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region reset

    private void Reset()
    {
        try
        {
            if (ddlRepHeaderList.Items.Count > 0)
            {
                ddlRepHeaderList.SelectedIndex = 0;
            }
            ddlDivisionHeaderList.SelectedIndex = 0;
            ResetForDivisionHeader();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetInfo()
    {
        try
        {
            txtBranchLocation.Text = String.Empty;
            txtBranchName.Text = String.Empty;
            ddlDivision.SelectedIndex = 0;
            ddlRegion.SelectedIndex = 0;
            ddlRepGroup.Items.Clear();
            //if (ddlSaleState.Items.Count > 0)
            //{
            //    ddlSaleState.SelectedIndex = 0;
            //}
            ddlCountry.SelectedIndex = 0;
            ddlState.Items.Clear();
            //ddlSaleCountry.SelectedIndex = 0;
            //if (ddlSaleName.Items.Count > 0)
            //{
            //    ddlSaleName.SelectedIndex = 0;
            //}
            //chkHobart.Checked = false;
            //chkStero.Checked = false;
            txtCompanyName.Text = String.Empty;
            txtStrAddress.Text = String.Empty;
            txtCity.Text = String.Empty;
            txtZipCode.Text = String.Empty;
            txtTelephone.Text = String.Empty;
            txtFaxNumber.Text = String.Empty;
            txtTollFree.Text = String.Empty;
            txtTollFax.Text = String.Empty;
            txtCompanyName.Text = String.Empty;
            //txtSaleAddress.Text = String.Empty;
            //txtSaleCity.Text = String.Empty;
            //txtSaleCompany.Text = String.Empty;
            //txtSaleTelephone.Text = String.Empty;
            //txtSaleCellPhone.Text = String.Empty;
            //txtSaleFax.Text = String.Empty;
            //txtSaleEmail.Text = String.Empty;
            txtStates.Text = string.Empty;
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetForDivisionHeader()
    {
        try
        {
            ddlRepGroupHeaderList.Items.Clear();
            ddlbranch.Items.Clear();
            ResetInfo();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion    
}