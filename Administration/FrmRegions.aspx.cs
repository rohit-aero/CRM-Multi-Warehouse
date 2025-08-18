using BLLAERO;
using BOLAERO;
using System;
using System.Data;
using System.Web.UI;

public partial class Administration_FrmRegions : System.Web.UI.Page
{
    BOLRegions objBOL = new BOLRegions();
    BLLRegions objBLL = new BLLRegions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
        }
    }

    #region Bind functions

    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            objBOL.Operation = 1;
            ds = objBLL.BindControls(objBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCountryHeaderList, ds.Tables[0]);
                Utility.BindDropDownList(ddlCountry, ds.Tables[0]);
            }

        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Validation functions

    private Boolean ValidationCheck()
    {
        if (ddlCountry.SelectedIndex == 0)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Country !');", true);
            Utility.ShowMessage_Error(Page, "Please Select Country !");
            ddlCountry.Focus();
            return false;
        }

        if (txtRegionName.Text == "")
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Region Name. !');", true);
            Utility.ShowMessage_Error(Page, "Please Enter Region Name. !");
            txtRegionName.Focus();
            return false;
        }

        return true;
    }

    #endregion

    #region Event Handler functions

    protected void ddlCountryHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlCountryHeaderList_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlRegionHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlRegionHeaderList_Event();
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
            btnSave_Event();
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
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Internal Event Function

    private void ddlCountryHeaderList_Event()
    {
        try
        {
            ResetRegionHeaderList();
            ResetInfo();
            if (ddlCountryHeaderList.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                objBOL.Operation = 2;
                objBOL.CountryId = Convert.ToInt32(ddlCountryHeaderList.SelectedValue);
                ds = objBLL.BindControls(objBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlRegionHeaderList, ds.Tables[0]);
                }
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void ddlRegionHeaderList_Event()
    {
        try
        {
            var regionID = Convert.ToInt32(ddlRegionHeaderList.SelectedValue);
            var selectedIndex = ddlRegionHeaderList.SelectedIndex;
            ResetInfo();
            if (selectedIndex > 0)
            {
                DataSet ds = new DataSet();
                objBOL.Operation = 3;
                objBOL.RegionId = regionID;
                ds = objBLL.BindControls(objBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["CountryID"].ToString()) > 0)
                    {
                        ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["CountryID"].ToString();
                    }
                    txtRegionName.Text = ds.Tables[0].Rows[0]["Region"].ToString();
                    txtDirector.Text = ds.Tables[0].Rows[0]["RDirector"].ToString();
                    txtDirectorPhone.Text = ds.Tables[0].Rows[0]["RDPhone"].ToString();
                    txtDirectorEmail.Text = ds.Tables[0].Rows[0]["RDEmail"].ToString();
                }
                ddlRegionHeaderList.SelectedIndex = selectedIndex;
                btnSave.Text = "Update";
            }

        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void btnSave_Event()
    {
        try
        {
            if (ValidationCheck())
            {
                var showMessageSuccess = "";
                var operation = "";
                objBOL.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
                objBOL.RegionName = txtRegionName.Text;
                objBOL.Director = txtDirector.Text;
                objBOL.DirectorPhone = txtDirectorPhone.Text;
                objBOL.DirectorEmail = txtDirectorEmail.Text;

                if (ddlRegionHeaderList.SelectedIndex > 0)
                {
                    objBOL.Operation = 5;
                    objBOL.RegionId = Convert.ToInt32(ddlRegionHeaderList.SelectedValue);
                    showMessageSuccess = "Data Updated Successfully !!";
                    operation = "Update";
                }
                else
                {
                    objBOL.Operation = 4;
                    showMessageSuccess = "Data Inserted Successfully !!";
                    operation = "Save";
                }
                var returnId = objBLL.SaveAndUpdate(objBOL);
                if (returnId.Length > 0)
                {
                    Utility.MaintainLogsSpecial("FrmRegions", operation, returnId);
                    Utility.ShowMessage_Success(Page, showMessageSuccess);
                    AfterSaveOrUpdateDataBind(returnId);
                }

            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region others

    private void AfterSaveOrUpdateDataBind(string returnRegionId)
    {
        try
        {
            ddlCountryHeaderList.SelectedValue = ddlCountry.SelectedValue;
            ddlCountryHeaderList_Event();
            ddlRegionHeaderList.SelectedValue = returnRegionId;
            ddlRegionHeaderList_Event();
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Resets

    private void Reset()
    {
        try
        {
            ddlCountryHeaderList.SelectedIndex = 0;
            ResetRegionHeaderList();
            ResetInfo();
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
            if (ddlRegionHeaderList.Items.Count > 0)
            {
                ddlRegionHeaderList.SelectedIndex = 0;
            }

            if (ddlCountry.Items.Count > 0)
            {
                ddlCountry.SelectedIndex = 0;
            }

            txtRegionName.Text = String.Empty;
            txtDirector.Text = String.Empty;
            txtDirectorPhone.Text = String.Empty;
            txtDirectorEmail.Text = String.Empty;
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void ResetRegionHeaderList()
    {
        try
        {
            if (ddlRegionHeaderList.Items.Count > 0)
            {
                ddlRegionHeaderList.Items.Clear();
            }

        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    #endregion

}