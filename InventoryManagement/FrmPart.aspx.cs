using BLLAERO;
using BOLAERO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TurboWash_FrmPart : System.Web.UI.Page
{
    BOLTurboWashPart ObjBOL = new BOLTurboWashPart();
    BLLTurboWashPart ObjBLL = new BLLTurboWashPart();

    commonclass1 clscon = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
            txtStockInHand.Enabled = true;
        }
    }

    #region Bind

    private void BindControls()
    {
        try
        {
            ObjBOL.Operation = 1;
            DataSet ds = ObjBLL.GetDataSet(ObjBOL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCategory, ds.Tables[0]);
                Utility.BindDropDownList(ddlCategoryLookupList, ds.Tables[0]);
                ddlCategory.SelectedIndex = 0;
                ddlCategoryLookupList.SelectedIndex = 0;
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartLookupList, ds.Tables[1]);
                ddlPartLookupList.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Validation

    private bool ValidationCheck()
    {
        try
        {
            if (ddlCategory.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Category. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Category. !");
                ddlCategory.Focus();
                return false;
            }

            if (txtPartNo.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter PartNo !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter PartNo !");
                txtPartNo.Focus();
                return false;
            }

            if (ddlSize.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Size !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Size !");
                ddlSize.Focus();
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

    #region EventHandlers

    protected void ddlCategoryLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCategoryLookupList_SelectedIndexChanged_Event();
    }

    protected void ddlPartLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPartLookupList_SelectedIndexChanged_Event();
    }

    protected void ddlOptionLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlOptionLookupList_SelectedIndexChanged_Event();
    }

    protected void ddlOrientationLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlOrientationLookupList_SelectedIndexChanged_Event();
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCategory_SelectedIndexChanged_Event();
    }

    protected void ddlSizeLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSizeLookupList_SelectedIndexChanged_Event();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave_Click_Event();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ResetAll();
    }

    #endregion

    #region Internal Event Functions

    private void ddlCategoryLookupList_SelectedIndexChanged_Event()
    {
        try
        {
            PopulateSizeLookup();
            PopulatePartLookup();
            EnableAndDisableOptionLookup();
            // ORIENTATION and OPTIONS lookup are already populated
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlSizeLookupList_SelectedIndexChanged_Event()
    {
        try
        {
            //CATEGORY lookup is populated and selected
            // ORIENTATION and OPTIONS lookup are already populated
            PopulatePartLookup();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlOrientationLookupList_SelectedIndexChanged_Event()
    {
        try
        {
            PopulatePartLookup();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlOptionLookupList_SelectedIndexChanged_Event()
    {
        // select category which is WASH SINK 
        SelectCategory("2");
        ddlCategoryLookupList_SelectedIndexChanged_Event();
    }

    private void ddlPartLookupList_SelectedIndexChanged_Event()
    {
        if (ddlPartLookupList.SelectedIndex > 0)
        {
            ObjBOL.Operation = 3;
            ObjBOL.ID = Int32.Parse(ddlPartLookupList.SelectedValue);
            DataRow row = ObjBLL.GetDataSet(ObjBOL).Tables[0].Rows[0];
            SelectCategory(row["CategoryID"].ToString());
            PopulateSizeLookup();
            SelectSize(row["SizeID"].ToString());
            SelectDirection(row["Direction"].ToString());
            SelectOption(row["OptionID"].ToString());
            LoadPartInfo();
        }
        else
        {
            ResetPart();
        }
    }

    private void ddlCategory_SelectedIndexChanged_Event()
    {
        try
        {
            ddlSize.Items.Clear();
            if (ddlCategory.SelectedIndex > 0)
            {
                ObjBOL.Operation = 2;
                ObjBOL.CategoryID = Int32.Parse(ddlCategory.SelectedValue);
                DataSet ds = ObjBLL.GetDataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlSize, ds.Tables[0]);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void LoadPartInfo()
    {
        try
        {
            if (ddlPartLookupList.SelectedIndex > 0)
            {
                btnSave.Text = "Update";
                //btnExportToPDF.Enabled = true;
                txtStockInHand.Enabled = false;
                ObjBOL.Operation = 5;
                ObjBOL.ID = Int32.Parse(ddlPartLookupList.SelectedValue);
                DataTable dt = ObjBLL.GetDataSet(ObjBOL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ddlCategory.SelectedValue = dt.Rows[0]["CategoryID"].ToString();
                    txtPartNo.Text = dt.Rows[0]["PartNo"].ToString();
                    ddlCategory_SelectedIndexChanged_Event();
                    ddlSize.SelectedValue = dt.Rows[0]["SizeID"].ToString();
                    ddlDirection.SelectedValue = dt.Rows[0]["Direction"].ToString();
                    ddlOption.SelectedValue = dt.Rows[0]["OptionID"].ToString();
                    txtStockInHand.Text = dt.Rows[0]["StockInHand"].ToString();
                    hfId.Value = dt.Rows[0]["ID"].ToString();
                }
            }
            else
            {
                ResetPart();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnSave_Click_Event()
    {
        try
        {
            if (ValidationCheck())
            {
                if (btnSave.Text == "Save")
                {
                    ObjBOL.Operation = 6;
                    if (txtStockInHand.Text != "")
                    {
                        ObjBOL.StockInHand = Int32.Parse(txtStockInHand.Text);
                    }
                }
                else if (btnSave.Text == "Update")
                {
                    ObjBOL.Operation = 7;
                    ObjBOL.ID = Int32.Parse(hfId.Value);
                }
                ObjBOL.CategoryID = Int32.Parse(ddlCategory.SelectedValue);
                ObjBOL.PartNo = txtPartNo.Text;
                ObjBOL.Direction = ddlDirection.SelectedValue;
                ObjBOL.Size = Int32.Parse(ddlSize.SelectedValue);
                if (ddlOption.SelectedIndex > 0)
                {
                    ObjBOL.OptionID = Int32.Parse(ddlOption.SelectedValue);
                }
                string returnStatus = ObjBLL.GetString(ObjBOL);
                if (returnStatus.Trim() == "ER01")
                {
                    //Utility.ShowMessage(Page, "Part No already exists !");
                    Utility.ShowMessage_Error(Page, "Part No already exists !");
                }
                else if (returnStatus.Trim().Length > 0)
                {
                    if (btnSave.Text == "Save")
                    {
                        //Utility.ShowMessage(Page, "Record Inserted Successfully !!");
                        Utility.ShowMessage_Success(Page, "Record Inserted Successfully !!");
                        Utility.MaintainLogsSpecial("FrmParts", "Save", returnStatus);
                    }
                    else if (btnSave.Text == "Update")
                    {
                        //Utility.ShowMessage(Page, "Record Updated Successfully !!");
                        Utility.ShowMessage_Success(Page, "Record Updated Successfully !!");
                        Utility.MaintainLogsSpecial("FrmParts", "Update", returnStatus);
                    }
                    ResetAll();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void PopulateSizeLookup()
    {
        if (ddlCategoryLookupList.SelectedIndex > 0)
        {
            ObjBOL.Operation = 2;
            ObjBOL.CategoryID = Int32.Parse(ddlCategoryLookupList.SelectedValue);
            DataSet ds = ObjBLL.GetDataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSizeLookupList, ds.Tables[0]);
                ddlSizeLookupList.SelectedIndex = 0;
            }
        }
        else
        {
            ClearSizeLookup();
        }

    }

    private void PopulatePartLookup()
    {
        try
        {
            DataTable dt = new DataTable();
            string query = " SELECT [ID], [PartNo] AS PartNo FROM TW_Part WHERE ID IS NOT NULL ";
            if (ddlCategoryLookupList.SelectedIndex > 0)
            {
                query += " AND CategoryID = " + ddlCategoryLookupList.SelectedValue;
            }

            if (ddlSizeLookupList.SelectedIndex > 0)
            {
                query += " AND SizeID = " + ddlSizeLookupList.SelectedValue;
            }

            if (ddlOrientationLookupList.SelectedIndex > 0)
            {
                query += " AND Direction = '" + ddlOrientationLookupList.SelectedValue + "' ";
            }

            if (ddlOptionLookupList.SelectedIndex > 0)
            {
                query += " AND OptionID = " + ddlOptionLookupList.SelectedValue;
            }

            query += " ORDER BY [PartNo]";

            clscon.Return_DT(dt, query);

            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartLookupList, dt);
                ResetPartInfo();
            }
            else
            {
                ClearPartLookup();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableAndDisableOptionLookup()
    {
        if (ddlCategoryLookupList.SelectedValue == "2")
        {
            ddlOptionLookupList.Enabled = true;
        }
        else if (ddlCategoryLookupList.SelectedIndex > 0)
        {
            ddlOptionLookupList.Enabled = false;
        }
        else
        {
            ddlOptionLookupList.Enabled = true;
        }
    }

    private void SelectCategory(string categoryID)
    {
        if (categoryID.Trim() != "")
        {
            ddlCategoryLookupList.SelectedValue = categoryID;
        }
        else
        {
            ResetAll();

        }
    }

    private void SelectSize(string sizeID)
    {
        if (sizeID.Trim() != "")
        {
            ddlSizeLookupList.SelectedValue = sizeID;
        }
        else
        {
            ddlSizeLookupList.SelectedValue = "0";
        }
    }

    private void SelectDirection(string directionID)
    {
        if (directionID.Trim() != "")
        {
            ddlOrientationLookupList.SelectedValue = directionID;
        }
        else
        {
            ddlOrientationLookupList.SelectedValue = string.Empty;
        }
    }

    private void SelectOption(string optionID)
    {
        if (optionID.Trim() != "" && optionID.Trim() != "0")
        {
            ddlOptionLookupList.SelectedValue = optionID;
        }
        else
        {
            ddlOptionLookupList.SelectedValue = "0";
        }
    }

    #endregion

    #region Reset

    private void ResetAll()
    {
        if (ddlCategoryLookupList.Items.Count > 0)
        {
            ddlCategoryLookupList.SelectedIndex = 0;
        }

        ddlSizeLookupList.Items.Clear();
        ddlOrientationLookupList.SelectedIndex = 0;
        ddlOptionLookupList.SelectedIndex = 0;
        BindControls();
        ResetPart();
    }

    private void ResetPart()
    {
        if (ddlPartLookupList.Items.Count > 0)
        {
            ddlPartLookupList.SelectedIndex = 0;
        }

        btnSave.Text = "Save";
        ResetPartInfo();
    }

    private void ResetPartInfo()
    {
        if (ddlCategory.Items.Count > 0)
        {
            ddlCategory.SelectedIndex = 0;
        }

        ddlSize.Items.Clear();
        ddlOption.SelectedIndex = 0;
        ddlDirection.SelectedIndex = 0;

        txtPartNo.Text = string.Empty;
        txtStockInHand.Text = string.Empty;
        txtStockInHand.Enabled = true;
        hfId.Value = string.Empty;
    }

    private void ClearSizeLookup()
    {
        ddlSizeLookupList.Items.Clear();
    }

    private void ClearPartLookup()
    {
        ddlPartLookupList.Items.Clear();
    }

    #endregion     
}