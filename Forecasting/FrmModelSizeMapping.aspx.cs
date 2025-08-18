using BLLAERO;
using BOLAERO;
using System;
using System.Data;

public partial class Forecasting_FrmModelSizeMapping : System.Web.UI.Page
{

    BOLForecastingModelSizeMapping ObjBOL = new BOLForecastingModelSizeMapping();
    BLLForecastingModelSizeMapping ObjBLL = new BLLForecastingModelSizeMapping();

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
                    ddlConveyorTypeLookup.Items.Clear();
                    ddlConveyorType.Items.Clear();
                }
            }
            else
            {
                ddlConveyorTypeLookup.Items.Clear();
                ddlConveyorType.Items.Clear();
            }
            AfterSaveReset();

            ddlConveyorModel.SelectedValue = ddlConveyorModelLookup.SelectedValue;
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
            AfterSaveReset();
            ddlConveyorType_SelectedIndexChanged_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool validationCheck()
    {
        try
        {
            if (ddlConveyorModel.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Conveyor Model !!");
                return false;
            }

            if (ddlConveyorType.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Conveyor Type !!");
                return false;
            }

            if (txtConveyorSize.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Size !!");
                return false;
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
            if (validationCheck())
            {
                string op = "";
                if (Int32.Parse(hfID.Value) > 0)
                {
                    ObjBOL.Operation = 4;
                    op = "Record updated successfully !!";
                }
                else
                {
                    ObjBOL.Operation = 5;
                    op = "Record saved successfully !!";
                }

                ObjBOL.TypeID = Int32.Parse(ddlConveyorType.SelectedValue);
                ObjBOL.SizeID = Int32.Parse(hfID.Value);
                ObjBOL.Size = txtConveyorSize.Text;
                ObjBOL.IsActive = Int32.Parse(ddlActive.SelectedValue);
                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim().Length > 0)
                {
                    if (returnStatus.Trim() == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "row doesnot exists !");
                    }
                    else if (returnStatus.Trim() == "ER02")
                    {
                        Utility.ShowMessage_Error(Page, "size already exists for the given type !!");
                    }
                    else
                    {
                        Utility.MaintainLogsSpecial("FrmModelSizeMapping.aspx", btnSaveSize.Text, returnStatus);
                        Utility.ShowMessage_Success(Page, op);
                        AfterSaveReset();
                        ddlConveyorType_SelectedIndexChanged_Event();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void AfterSaveReset()
    {
        try
        {
            txtConveyorSize.Text = string.Empty;
            ddlActive.SelectedValue = "1";
            hfID.Value = "-1";
            EmptyGrid();
            btnSaveSize.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel_Click_Event();
    }

    private void btnCancel_Click_Event()
    {
        try
        {
            ddlConveyorModelLookup.SelectedIndex = 0;
            ddlConveyorModel.SelectedIndex = 0;
            ddlConveyorTypeLookup.Items.Clear();
            ddlConveyorType.Items.Clear();
            txtConveyorSize.Text = string.Empty;
            ddlActive.SelectedIndex = 0;
            hfID.Value = "-1";
            EmptyGrid();
            btnSaveSize.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlConveyorModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlConveyorModel_SelectedIndexChanged_Event();
    }

    private void ddlConveyorModel_SelectedIndexChanged_Event()
    {
        try
        {
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
                    ddlConveyorType.Items.Clear();
                }
            }
            else
            {
                ddlConveyorType.Items.Clear();
            }
            EmptyGrid();
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
                    gvList.DataSource = ds.Tables[0];
                    gvList.DataBind();
                }
                else
                {
                    EmptyGrid();
                }
            }
            else
            {
                EmptyGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EmptyGrid()
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

    protected void gvList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            int ID = Convert.ToInt32(gvList.DataKeys[e.NewEditIndex].Values[0]);
            ObjBOL.Operation = 6;
            ObjBOL.SizeID = ID;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (ddlConveyorType.Items.FindByValue(row["AWProductSubID"].ToString()) != null)
                {
                    ddlConveyorType.SelectedValue = row["AWProductSubID"].ToString();
                }

                if (ddlActive.Items.FindByValue(row["IsActive"].ToString()) != null)
                {
                    ddlActive.SelectedValue = row["IsActive"].ToString();
                }

                txtConveyorSize.Text = row["Size"].ToString();

                hfID.Value = ID.ToString();
                btnSaveSize.Text = "Update";
            }
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
            int id = Convert.ToInt32(gvList.DataKeys[e.RowIndex].Values[0]);
            ObjBOL.Operation = 7;
            ObjBOL.SizeID = id;
            string returnStatus = ObjBLL.Return_String(ObjBOL);
            if (returnStatus.Trim().Length > 0)
            {
                if (returnStatus.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "Size referenced in Model Parts !");
                }                
                else if(returnStatus.Trim() == "S")
                {
                    Utility.MaintainLogsSpecial("FrmModelSizeMapping.aspx", "delete", ddlConveyorType.SelectedValue);
                    Utility.ShowMessage_Success(Page, "Size deleted Successfully !!");
                    ddlConveyorType_SelectedIndexChanged_Event();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}