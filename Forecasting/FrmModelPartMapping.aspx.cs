using BLLAERO;
using BOLAERO;
using System;
using System.Data;

public partial class Forecasting_ModelTypePartMapping : System.Web.UI.Page
{
    BOLForecastingModelPartMapping ObjBOL = new BOLForecastingModelPartMapping();
    BLLForecastingModelPartMapping ObjBLL = new BLLForecastingModelPartMapping();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
        }
    }

    private void BindControls()
    {
        try
        {
            ObjBOL.Operation = 1;
            DataSet ds = new DataSet();
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConveyorModelLookup, ds.Tables[0]);
                Utility.BindDropDownList(ddlConveyorModel, ds.Tables[0]);
                ddlConveyorModelLookup.SelectedIndex = 0;
                ddlConveyorModel.SelectedIndex = 0;
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConveyorParentParts, ds.Tables[1]);
                Utility.BindDropDownList(ddlConveyorChildParts, ds.Tables[1]);
                ddlConveyorParentParts.SelectedIndex = 0;
                ddlConveyorChildParts.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlConveyorType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlConveyorType_SelectedIndexChanged_Event();
    }

    private void ddlConveyorType_SelectedIndexChanged_Event()
    {
        try
        {
            if (ddlConveyorType.SelectedIndex > 0)
            {
                ObjBOL.Operation = 3;
                ObjBOL.TypeID = Int32.Parse(ddlConveyorType.SelectedValue);
                DataSet ds = new DataSet();
                ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlConveyorSize, ds.Tables[0]);
                    ddlConveyorSize.SelectedIndex = 0;
                }
                else
                {
                    ddlConveyorSize.Items.Clear();
                }
            }
            else
            {
                ClearSizeAndGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlConveyorModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Reset();
            if (ddlConveyorModel.SelectedIndex > 0)
            {
                ObjBOL.Operation = 2;
                ObjBOL.ModelID = Int32.Parse(ddlConveyorModel.SelectedValue);
                DataSet ds = new DataSet();
                ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlConveyorType, ds.Tables[0]);
                }
                else
                {
                    ClearTypeSizeAndGrid();
                }
            }
            else
            {
                ClearTypeSizeAndGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlConveyorModelLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Reset();
            ddlConveyorModel.SelectedValue = ddlConveyorModelLookup.SelectedValue;
            ClearTypeSizeAndGrid_Lookup();
            if (ddlConveyorModelLookup.SelectedIndex > 0)
            {
                ObjBOL.Operation = 2;
                ObjBOL.ModelID = Int32.Parse(ddlConveyorModelLookup.SelectedValue);
                DataSet ds = new DataSet();
                ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlConveyorTypeLookup, ds.Tables[0]);
                    Utility.BindDropDownList(ddlConveyorType, ds.Tables[0]);
                }
                else
                {
                    ClearTypeSizeAndGrid_Lookup();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlConveyorTypeLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlConveyorType.SelectedValue = ddlConveyorTypeLookup.SelectedValue;
            ddlConveyorParentParts.SelectedIndex = 0;
            ClearSizeAndGrid_Lookup();
            if (ddlConveyorTypeLookup.SelectedIndex > 0)
            {
                ObjBOL.Operation = 3;
                ObjBOL.TypeID = Int32.Parse(ddlConveyorTypeLookup.SelectedValue);
                DataSet ds = new DataSet();
                ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlConveyorSizeLookup, ds.Tables[0]);
                    Utility.BindDropDownList(ddlConveyorSize, ds.Tables[0]);
                    ddlConveyorSizeLookup.SelectedIndex = 0;
                    ddlConveyorSize.SelectedIndex = 0;
                }
                else
                {
                    ClearSizeAndGrid_Lookup();
                }
                CheckForNoSizeParts();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckForNoSizeParts()
    {
        try
        {
            ObjBOL.Operation = 10;
            DataSet ds = new DataSet();
            ObjBOL.TypeID = Int32.Parse(ddlConveyorType.SelectedValue);
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConveyorParentLookup, ds.Tables[0]);
                ddlConveyorParentLookup.SelectedIndex = 0;
            }
            else
            {
                ddlConveyorParentLookup.Items.Clear();
            }
            //LoadGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlConveyorSizeLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlConveyorSizeLookup_SelectedIndexChanged();
    }

    private void ddlConveyorSizeLookup_SelectedIndexChanged()
    {
        try
        {
            ClearGrid();
            ddlConveyorParentLookup.Items.Clear();
            if (ddlConveyorSizeLookup.SelectedIndex > 0)
            {
                ObjBOL.Operation = 9;
                ObjBOL.SizeID = Int32.Parse(ddlConveyorSizeLookup.SelectedValue);
                DataSet ds = new DataSet();
                ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlConveyorParentLookup, ds.Tables[0]);
                    ddlConveyorParentLookup.SelectedIndex = 0;
                }
                ddlConveyorSize.SelectedValue = ddlConveyorSizeLookup.SelectedValue;
                //ddlConveyorSize_SelectedIndexChanged_Event();
                LoadGrid();
            }
            else
            {
                ddlConveyorSize.SelectedValue = ddlConveyorSizeLookup.SelectedValue;
                ddlConveyorParentParts.SelectedIndex = 0;
                CheckForNoSizeParts();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool Validation()
    {
        try
        {
            if (ddlConveyorModel.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Conveyor Model !");
                return false;
            }

            if (ddlConveyorType.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Conveyor Type !");
                return false;
            }

            //if (ddlConveyorSize.SelectedIndex == 0)
            //{
            //    Utility.ShowMessage_Error(Page, "Please select Conveyor Size !");
            //    return false;
            //}

            if (ddlConveyorParentParts.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Conveyor Parent Part !");
                return false;
            }

            if (ddlConveyorChildParts.SelectedIndex > 0)
            {
                if (txtPartQty.Text.Trim().Length == 0)
                {
                    Utility.ShowMessage_Error(Page, "Please enter qty !");
                    return false;
                }
            }

            if (btnSaveSize.Text.ToLower() == "update")
            {
                if (Int32.Parse(hfID.Value) <= 0)
                {
                    Utility.ShowMessage_Error(Page, "Entry ID for row missing !");
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnSaveSize_Click(object sender, EventArgs e)
    {
        try
        {
            if (Validation())
            {
                string op = "";
                if (btnSaveSize.Text.ToLower() == "save")
                {
                    ObjBOL.Operation = 5;
                    ObjBOL.ID = 0;
                    op = "Record saved successfully !!";
                }
                else
                {
                    ObjBOL.Operation = 6;//update
                    ObjBOL.ID = Int32.Parse(hfID.Value);
                    op = "Record updated successfully !!";
                }
                ObjBOL.ModelID = Int32.Parse(ddlConveyorModel.SelectedValue);
                ObjBOL.TypeID = Int32.Parse(ddlConveyorType.SelectedValue);
                if (ddlConveyorSize.SelectedIndex > 0)
                {
                    ObjBOL.SizeID = Int32.Parse(ddlConveyorSize.SelectedValue);
                }
                ObjBOL.ParentPartID = Int32.Parse(ddlConveyorParentParts.SelectedValue);
                if (ddlConveyorChildParts.SelectedIndex > 0)
                {
                    ObjBOL.IsBackendEntry = 1;
                    if (txtPartQty.Text != "")
                    {
                        ObjBOL.Qty = Decimal.Parse(txtPartQty.Text);
                    }
                    ObjBOL.ChildPartID = Int32.Parse(ddlConveyorChildParts.SelectedValue);
                }
                else
                {
                    ObjBOL.IsBackendEntry = 0;
                }

                ObjBOL.IsActive = Int32.Parse(ddlActive.SelectedValue);
                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim().Length > 0)
                {
                    if (returnStatus.Trim() == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "Part already exists !");
                    }
                    else if (returnStatus.Trim() == "ER02")
                    {
                        Utility.ShowMessage_Error(Page, "Entry cannot be updated !");
                        string temp = ddlConveyorSize.SelectedValue;
                        string partID = ddlConveyorParentParts.SelectedValue;
                        Reset();
                        ddlConveyorSize.SelectedValue = temp;
                        ddlConveyorParentParts.SelectedValue = partID;
                        LoadGrid();
                    }
                    else if (returnStatus.Trim() == "ER03")
                    {
                        Utility.ShowMessage_Error(Page, "Parent Part is referenced in Job Model !");
                    }
                    else
                    {
                        Utility.MaintainLogsSpecial("FrmModelPartMapping.aspx", btnSaveSize.Text, returnStatus);
                        Utility.ShowMessage_Success(Page, op);
                        string temp = ddlConveyorSize.SelectedValue;
                        string partID = ddlConveyorParentParts.SelectedValue;
                        Reset();
                        ddlConveyorSize.SelectedValue = temp;
                        ddlConveyorParentParts.SelectedValue = partID;
                        LoadGrid();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Reset()
    {
        try
        {
            if (ddlConveyorSize.Items.Count > 0)
            {
                ddlConveyorSize.SelectedIndex = 0;
            }
            ddlConveyorParentParts.SelectedIndex = 0;
            ddlConveyorChildParts.SelectedIndex = 0;
            EnableControls();
            ddlActive.SelectedValue = "1";
            txtPartQty.Text = string.Empty;
            gvList.DataSource = string.Empty;
            gvList.DataBind();
            hfID.Value = "-1";
            btnSaveSize.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvList_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        try
        {
            int userID = Utility.GetCurrentUser();
            int id = Convert.ToInt32(gvList.DataKeys[e.RowIndex].Values[0]);
            ObjBOL.Operation = 7;
            ObjBOL.ID = id;
            ObjBOL.ModelID = userID;
            string returnStatus = ObjBLL.Return_String(ObjBOL);
            if (returnStatus.Trim().Length > 0)
            {
                if (returnStatus.Trim() == "ER02")
                {
                    Utility.ShowMessage_Error(Page, "Entry cannot be deleted !");
                }
                else if (returnStatus.Trim() == "ER03")
                {
                    Utility.ShowMessage_Error(Page, "Not Authorized for deletion!");
                }
                else
                {
                    Utility.MaintainLogsSpecial("FrmModelPartMapping.aspx", "delete", ddlConveyorType.SelectedValue);
                    Utility.ShowMessage_Success(Page, returnStatus);
                    string val = ddlConveyorParentParts.SelectedValue;
                    ddlConveyorSizeLookup_SelectedIndexChanged();
                    if (ddlConveyorParentLookup.Items.FindByValue(val) != null)
                    {
                        ddlConveyorParentLookup.SelectedValue = val;
                        ddlConveyorParentParts.SelectedValue = ddlConveyorParentLookup.SelectedValue;
                        ddlConveyorParentParts_SelectedIndexChanged_Event();
                    }
                    else
                    {
                        LoadGrid();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            int ID = Convert.ToInt32(gvList.DataKeys[e.NewEditIndex].Values[0]);
            ObjBOL.Operation = 8;
            ObjBOL.ID = ID;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (ddlConveyorSize.Items.FindByValue(row["SizeID"].ToString()) != null)
                {
                    ddlConveyorSize.SelectedValue = row["SizeID"].ToString();
                }

                if (ddlConveyorParentParts.Items.FindByValue(row["ParentPartID"].ToString()) != null)
                {
                    ddlConveyorParentParts.SelectedValue = row["ParentPartID"].ToString();
                }

                if (ddlConveyorChildParts.Items.FindByValue(row["ChildPartID"].ToString()) != null)
                {
                    ddlConveyorChildParts.SelectedValue = row["ChildPartID"].ToString();
                }

                if (ddlActive.Items.FindByValue(row["IsActive"].ToString()) != null)
                {
                    ddlActive.SelectedValue = row["IsActive"].ToString();
                }

                txtPartQty.Text = row["Qty"].ToString();
                DisableControls();
                hfID.Value = ID.ToString();
                btnSaveSize.Text = "Update";
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
            ddlConveyorTypeLookup.Items.Clear();
            ddlConveyorSizeLookup.Items.Clear();
            ddlConveyorParentLookup.Items.Clear();
            ddlConveyorType.Items.Clear();
            ddlConveyorSize.Items.Clear();
            ddlConveyorModel.SelectedIndex = 0;
            ddlConveyorModelLookup.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableControls()
    {
        try
        {
            ddlConveyorModelLookup.Enabled = false;
            ddlConveyorModel.Enabled = false;
            ddlConveyorTypeLookup.Enabled = false;
            ddlConveyorType.Enabled = false;
            ddlConveyorSizeLookup.Enabled = false;
            ddlConveyorSize.Enabled = false;
            ddlConveyorParentLookup.Enabled = false;
            ddlConveyorParentParts.Enabled = false;
            ddlConveyorChildParts.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableControls()
    {
        try
        {
            ddlConveyorModelLookup.Enabled = true;
            ddlConveyorModel.Enabled = true;
            ddlConveyorTypeLookup.Enabled = true;
            ddlConveyorType.Enabled = true;
            ddlConveyorSizeLookup.Enabled = true;
            ddlConveyorSize.Enabled = true;
            ddlConveyorParentLookup.Enabled = true;
            ddlConveyorParentParts.Enabled = true;
            ddlConveyorChildParts.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearTypeSizeAndGrid()
    {
        try
        {
            ddlConveyorType.Items.Clear();
            ClearSizeAndGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearSizeAndGrid()
    {
        try
        {
            ddlConveyorSize.Items.Clear();
            ClearGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearGrid()
    {
        try
        {
            gvList.DataSource = string.Empty;
            gvList.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearTypeSizeAndGrid_Lookup()
    {
        try
        {
            ddlConveyorTypeLookup.Items.Clear();
            ddlConveyorType.Items.Clear();
            ClearSizeAndGrid_Lookup();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearSizeAndGrid_Lookup()
    {
        try
        {
            ddlConveyorSizeLookup.Items.Clear();
            ddlConveyorParentLookup.Items.Clear();
            ClearSizeAndGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlConveyorParentParts_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlConveyorParentLookup.Items.Count > 0)
        {
            ddlConveyorParentLookup.SelectedIndex = 0;
        }
        ddlConveyorParentParts_SelectedIndexChanged_Event();
    }

    private void ddlConveyorParentParts_SelectedIndexChanged_Event()
    {
        try
        {
            if (ddlConveyorParentParts.SelectedIndex == 0)
            {
                ClearGrid();
                return;
            }

            if (ddlConveyorParentParts.SelectedValue == ddlConveyorChildParts.SelectedValue)
            {
                ddlConveyorParentParts.SelectedIndex = 0;
                Utility.ShowMessage_Error(Page, "Parent and Child Part cannot be same !");
                return;
            }

            LoadGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlConveyorChildParts_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlConveyorChildParts.SelectedIndex == 0)
            {
                return;
            }

            if (ddlConveyorParentParts.SelectedValue == ddlConveyorChildParts.SelectedValue)
            {
                ddlConveyorChildParts.SelectedIndex = 0;
                Utility.ShowMessage_Error(Page, "Parent and Child Part cannot be same !");
                return;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlConveyorParentLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlConveyorParentParts.SelectedValue = ddlConveyorParentLookup.SelectedValue;
            ddlConveyorParentParts_SelectedIndexChanged_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void LoadGrid()
    {
        try
        {
            //if (ddlConveyorSize.SelectedIndex > 0 && ddlConveyorType.SelectedIndex > 0 && ddlConveyorParentParts.SelectedIndex > 0)
            if (ddlConveyorType.SelectedIndex > 0 && ddlConveyorParentParts.SelectedIndex > 0)
            {
                ObjBOL.Operation = 4;
                ObjBOL.TypeID = Int32.Parse(ddlConveyorType.SelectedValue);
                if (ddlConveyorSize.SelectedIndex > 0)
                {
                    ObjBOL.SizeID = Int32.Parse(ddlConveyorSize.SelectedValue);
                }
                else
                {
                    ObjBOL.SizeID = 0;
                }
                ObjBOL.ParentPartID = Int32.Parse(ddlConveyorParentParts.SelectedValue);
                DataSet ds = new DataSet();
                ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvList.DataSource = ds.Tables[0];
                    gvList.DataBind();
                }
                else
                {
                    gvList.DataSource = String.Empty;
                    gvList.DataBind();
                }
            }
            else
            {
                gvList.DataSource = String.Empty;
                gvList.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlConveyorSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlConveyorParentParts.SelectedIndex = 0;
            ClearGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}