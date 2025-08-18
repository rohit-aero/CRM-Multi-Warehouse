using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;

public partial class INVManagement_FrmStockAdjustment : System.Web.UI.Page
{
    BOLINVPartsInfo ObjBOL = new BOLINVPartsInfo();
    BLLINVPartsinfo ObjBLL = new BLLINVPartsinfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Control();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 1;
            ds = ObjBLL.GetJobs(ObjBOL);
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartNumber, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlReason, ds.Tables[3]);
            }
            //ddlReason
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Grid()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 6;
            ObjBOL.PartId = Convert.ToInt32(ddlPartNumber.SelectedValue);
            ds = ObjBLL.GetStockAdjustment(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvSearch.DataSource = ds.Tables[0];
                gvSearch.DataBind();
            }
            else
            {
                gvSearch.DataSource = "";
                gvSearch.DataBind();
            }
            //ddlReason
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearAll()
    {
        try
        {
            ddlPartNumber.SelectedIndex = 0;
            ddlType.SelectedIndex = 0;
            ddlReason.SelectedIndex = 0;
            txtQty.Text = string.Empty;
            txtSummary.Text = string.Empty;
            gvSearch.DataSource = "";
            gvSearch.DataBind();
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
            ClearAll();
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
            if (ddlPartNumber.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Part No.');", true);
                Utility.ShowMessage_Error(Page, "Please Select Part No.");
                ddlPartNumber.Focus();
                return false;
            }
            if (ddlType.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Adjustment Type.');", true);
                Utility.ShowMessage_Error(Page, "Please Select Adjustment Type.");
                ddlType.Focus();
                return false;
            }
            if (ddlReason.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Adjustment Reason.');", true);
                Utility.ShowMessage_Error(Page, "Please Select Adjustment Reason.");
                ddlReason.Focus();
                return false;
            }
            if (txtQty.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Quantity.');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Quantity.");
                txtQty.Focus();
                return false;
            }
            if (txtSummary.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Summary.');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Summary.");
                txtSummary.Focus();
                return false;
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {

                string msg = "";
                ObjBOL.operation = 5;
                ObjBOL.PartId = Convert.ToInt32(ddlPartNumber.SelectedValue);
                if (ddlType.SelectedValue == "1")
                {
                    ObjBOL.Qty = Convert.ToInt32(txtQty.Text);
                }
                //2 = out
                else if (ddlType.SelectedValue == "2")
                {
                    ObjBOL.Qty = -Math.Abs(Convert.ToInt32(txtQty.Text));
                }
                ObjBOL.adjustmentreasonid = Convert.ToInt32(ddlReason.SelectedValue);
                ObjBOL.transactsummary = txtSummary.Text;
                ObjBOL.userid = Convert.ToInt32(Utility.GetCurrentUser());
                msg = ObjBLL.StockAdjustment(ObjBOL);              
                Utility.ShowMessage_Success(Page, msg.Trim());
                if (msg.Trim() == "Stock Adjusted !!")
                {
                    Utility.MaintainLogsSpecial("frmStockAdjustmet", "StockAdjust", ddlPartNumber.SelectedValue.ToString());
                    BindPartNumber(ddlPartNumber.SelectedValue);
                }
                Bind_Grid();
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPartNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPartNumber.SelectedIndex > 0)
            {
                Bind_Grid();
            }
            else
            {
                gvSearch.DataSource = "";
                gvSearch.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void BindPartNumber(string PartID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 1;
            if(PartID != "")
            {
                ObjBOL.PartId = Convert.ToInt32(PartID);
                ds = ObjBLL.GetStockAdjustment(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlPartNumber, ds.Tables[2]);
                    ddlPartNumber.SelectedValue = PartID;
                }
            }  
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}