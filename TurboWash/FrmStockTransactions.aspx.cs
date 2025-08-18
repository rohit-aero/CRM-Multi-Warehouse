using BLLAERO;
using BOLAERO;
using System;
using System.Data;
using System.Web.UI;

public partial class TurboWash_FrmStockTransactions : System.Web.UI.Page
{
    BOLTurboWashTransaction ObjBOL = new BOLTurboWashTransaction();
    BLLTurboWashTransaction ObjBLL = new BLLTurboWashTransaction();

    commonclass1 clscon = new commonclass1();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Utility.IsAuthorized())
                {
                    btnSave.Enabled = false;
                    BindControls();
                }               
            }
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
            ObjBOL.LoginUserID = Utility.GetCurrentUser();
            DataSet ds = ObjBLL.GetDataSet(ObjBOL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCategoryLookupList, ds.Tables[0]);
                ddlCategoryLookupList.SelectedIndex = 0;
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartLookupList, ds.Tables[1]);
                ddlPartLookupList.SelectedIndex = 0;
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlTransactionType, ds.Tables[2]);
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
            if (ddlTransactionType.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Transaction Type. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Transaction Type. !");
                ddlTransactionType.Focus();
                return false;
            }

            if (txtTransactQty.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter transaction Qty !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter transaction Qty !");
                txtTransactQty.Focus();
                return false;
            }
            if (Convert.ToInt32(txtTransactQty.Text) <= 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Transaction Quantity cannot be zero !');", true);
                Utility.ShowMessage_Error(Page, "Transaction Quantity cannot be zero !");
                txtTransactQty.Focus();
                return false;
            }
            if (txtRemarks.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Remarks !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Remarks !");
                txtRemarks.Focus();
                return false;
            }

            if (txtStockInHand.Text != "")
            {
                if (Int32.Parse(txtTransactQty.Text) > Int32.Parse(txtStockInHand.Text) && ddlTransactionType.SelectedValue == "2")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Transaction Qty cannot be more than Stock In Hand!');", true);
                    Utility.ShowMessage_Error(Page, "Transaction Qty cannot be more than Stock In Hand!");
                    txtTransactQty.Focus();
                    return false;
                }
            }
            else if (ddlTransactionType.SelectedValue == "2")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Transaction Qty cannot be more than Stock In Hand!');", true);
                Utility.ShowMessage_Error(Page, "Transaction Qty cannot be more than Stock In Hand!");
                txtTransactQty.Focus();
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

    protected void btnITWReport_Click(object sender, EventArgs e)
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
                btnSave.Enabled = true;
                ObjBOL.Operation = 6;
                ObjBOL.PartID = Int32.Parse(ddlPartLookupList.SelectedValue);
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

    private void LoadPartInfo()
    {
        try
        {
            if (ddlPartLookupList.SelectedIndex > 0)
            {
                txtStockInHand.Enabled = false;
                ObjBOL.Operation = 3;
                ObjBOL.PartID = Int32.Parse(ddlPartLookupList.SelectedValue);
                DataTable dt = ObjBLL.GetDataSet(ObjBOL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txtStockInHand.Text = dt.Rows[0]["StockInHand"].ToString();
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

    private void PopulateSizeLookup()
    {
        try
        {
            if (ddlCategoryLookupList.SelectedIndex > 0)
            {
                ObjBOL.Operation = 5;
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

    private void btnSave_Click_Event()
    {
        try
        {
            if (ValidationCheck())
            {
                ObjBOL.Operation = 4;
                ObjBOL.PartID = Int32.Parse(ddlPartLookupList.SelectedValue);
                ObjBOL.TransactType = Int32.Parse(ddlTransactionType.SelectedValue);
                ObjBOL.TransactQty = Int32.Parse(txtTransactQty.Text);
                ObjBOL.JobID = txtRemarks.Text;
                ObjBOL.LoginUserID = Utility.GetCurrentUser();
                string returnStatus = ObjBLL.GetString(ObjBOL);

                if (returnStatus.Trim().Length > 0)
                {
                    Utility.ShowMessage_Success(Page, returnStatus);
                    ResetAll();
                }
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

            btnSave.Enabled = false;
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
            if (ddlTransactionType.Items.Count > 0)
            {
                ddlTransactionType.SelectedIndex = 0;
            }

            txtStockInHand.Text = string.Empty;
            txtTransactQty.Text = string.Empty;
            txtRemarks.Text = string.Empty;
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