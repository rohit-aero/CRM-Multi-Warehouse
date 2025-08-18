using BLLAERO;
using BOLAERO;
using System;
using System.Data;

public partial class Forecasting_FrmModelTypeMapping : System.Web.UI.Page
{
    BOLForecastingModelTypeMapping ObjBOL = new BOLForecastingModelTypeMapping();
    BLLForecastingModelTypeMapping ObjBLL = new BLLForecastingModelTypeMapping();

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
            ObjBOL.Operation = 2;
            ObjBOL.ModelID = Int32.Parse(ddlConveyorModelLookup.SelectedValue);
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
            ddlConveyorType_SelectedIndexChanged_Event();
            ddlConveyorModel.SelectedValue = ddlConveyorModelLookup.SelectedValue;
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
                ObjBOL.Operation = 5;
                ObjBOL.TypeID = Int32.Parse(ddlConveyorType.SelectedValue);
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
                String returnStatus = string.Empty;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    returnStatus = ds.Tables[0].Rows[0][0].ToString();
                    if (returnStatus.Trim().Length > 0)
                    {
                        ddlActive.SelectedValue = returnStatus.Trim();
                    }
                    txtConveyorType.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtConveyorTypeDescription.Text = ds.Tables[0].Rows[0][2].ToString();
                    btnSaveType.Text = "Update";
                }
            }
            else
            {
                txtConveyorType.Text = "";
                txtConveyorTypeDescription.Text = "";
                btnSaveType.Text = "Save";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationForType()
    {
        try
        {
            if (ddlConveyorModel.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select conveyor Model !");
                return false;
            }

            if (txtConveyorType.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter conveyor type !");
                txtConveyorType.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnSaveType_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationForType())
            {
                if (ddlConveyorType.SelectedIndex > 0)
                {
                    ObjBOL.Operation = 3;
                    ObjBOL.ModelID = Int32.Parse(ddlConveyorModel.SelectedValue);
                    ObjBOL.TypeID = Int32.Parse(ddlConveyorType.SelectedValue);
                    ObjBOL.Type = txtConveyorType.Text.Trim();
                    ObjBOL.TypeDesc = txtConveyorTypeDescription.Text.Trim();
                    ObjBOL.IsActive = Int32.Parse(ddlActive.SelectedValue);
                    string returnStatus = ObjBLL.Return_String(ObjBOL);
                    if (returnStatus.Trim().Length > 0)
                    {
                        Utility.ShowMessage_Success(Page, "Record updated successfully !!");
                        Utility.MaintainLogsSpecial("FrmModelTypeMapping.aspx", "Update", ddlConveyorType.SelectedValue);
                        Reset();
                        BindControls();
                    }
                }
                else
                {
                    ObjBOL.Operation = 4;
                    ObjBOL.TypeID = 0;
                    ObjBOL.ModelID = Int32.Parse(ddlConveyorModel.SelectedValue);
                    ObjBOL.Type = txtConveyorType.Text.Trim();
                    ObjBOL.TypeDesc = txtConveyorTypeDescription.Text.Trim();
                    ObjBOL.IsActive = Int32.Parse(ddlActive.SelectedValue);
                    string returnStatus = ObjBLL.Return_String(ObjBOL);
                    if (returnStatus.Trim().Length > 0)
                    {
                        Utility.ShowMessage_Success(Page, "Record inserted successfully !!");
                        Utility.MaintainLogsSpecial("FrmModelTypeMapping.aspx", "Save", returnStatus);
                        Reset();
                        BindControls();
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
            ddlConveyorModelLookup.SelectedIndex = 0;
            ddlConveyorModel.SelectedIndex = 0;
            ddlConveyorType.Items.Clear();
            txtConveyorType.Text = string.Empty;
            txtConveyorTypeDescription.Text = string.Empty;
            ddlActive.SelectedValue = "1";
            btnSaveType.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
    }
}