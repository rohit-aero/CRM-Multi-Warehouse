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
        try
        {
            if (!IsPostBack)
            {
                BindControls();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/TurboWash/FrmTWParts.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
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
        try
        {
            ddlCategoryLookupList_SelectedIndexChanged_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

    protected void ddlPartLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlPartLookupList_SelectedIndexChanged_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

    protected void ddlOptionLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlOptionLookupList_SelectedIndexChanged_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        
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
        try
        {
            // select category which is WASH SINK 
            SelectCategory("2");
            ddlCategoryLookupList_SelectedIndexChanged_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

    private void ddlPartLookupList_SelectedIndexChanged_Event()
    {
        try
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
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
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
                    Utility.ShowMessage_Error(Page, "Part No already exists !");
                }
                else if (returnStatus.Trim().Length > 0)
                {
                    if (btnSave.Text == "Save")
                    {
                        Utility.ShowMessage_Success(Page, "Record Inserted Successfully !!");
                        Utility.MaintainLogsSpecial("FrmParts", "Save", returnStatus);
                    }
                    else if (btnSave.Text == "Update")
                    {
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
        try
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
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

    private void PopulatePartLookup()
    {
        try
        {
            DataTable dt = new DataTable();
            string query = " SELECT [ID], [PartNo]  ";
            query += " FROM TW_Part_List() ";
            query += " WHERE TW_Part_List.ID IS NOT NULL ";
            if (ddlCategoryLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part_List.CategoryID = " + ddlCategoryLookupList.SelectedValue;
            }
            if (ddlSizeLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part_List.SizeID = " + ddlSizeLookupList.SelectedValue;
            }
            if (ddlOrientationLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part_List.Direction = '" + ddlOrientationLookupList.SelectedValue + "' ";
            }
            if (ddlOptionLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part_List.OptionID = " + ddlOptionLookupList.SelectedValue;
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
        try
        {
            if (ddlCategoryLookupList.SelectedValue == "2")
            {
                ddlOptionLookupList.Enabled = true;
            }
            else if (ddlCategoryLookupList.SelectedIndex > 0)
            {
                ddlOptionLookupList.Enabled = false;
                ddlOptionLookupList.SelectedIndex = 0;
            }
            else
            {
                ddlOptionLookupList.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

    private void SelectCategory(string categoryID)
    {
        try
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
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void SelectSize(string sizeID)
    {
        try
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
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

    private void SelectDirection(string directionID)
    {
        try
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
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

    private void SelectOption(string optionID)
    {
        try
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
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

    #endregion

    #region Reset

    private void ResetAll()
    {
        try
        {
            if (ddlCategoryLookupList.Items.Count > 0)
            {
                ddlCategoryLookupList.SelectedIndex = 0;
            }

            ddlSizeLookupList.Items.Clear();
            ddlOrientationLookupList.SelectedIndex = 0;
            ddlOptionLookupList.SelectedIndex = 0;
            ddlOptionLookupList.Enabled = true;
            BindControls();
            ResetPart();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

    private void ResetPart()
    {
        try
        {
            if (ddlPartLookupList.Items.Count > 0)
            {
                ddlPartLookupList.SelectedIndex = 0;
            }

            btnSave.Text = "Save";
            ResetPartInfo();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

    private void ResetPartInfo()
    {
        try
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
            hfId.Value = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

    private void ClearSizeLookup()
    {
        try
        {
            ddlSizeLookupList.Items.Clear();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

    private void ClearPartLookup()
    {
        try
        {
            ddlPartLookupList.Items.Clear();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }
    #endregion     
}