using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;

public partial class CCT_frmStockAdjustment : System.Web.UI.Page
{
    BOLStockAdjustment ObjBOL = new BOLStockAdjustment();
    BLLManageStockAdjustments ObjBLL = new BLLManageStockAdjustments();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Controls();
        }
    }

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.BindDropDown(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlManufacturer, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlManufacturer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.Makerid = Convert.ToInt32(ddlManufacturer.SelectedValue);
            ds = ObjBLL.BindDropDown(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlWasteEq, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlWasteEq_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            ObjBOL.WasteEqid = Convert.ToInt32(ddlWasteEq.SelectedValue);
            ds = ObjBLL.BindDropDown(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlAcc, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private Boolean CheckValidations()
    {
        try
        {
            if (ddlManufacturer.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Stock Options. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Manufacturer. !");
                ddlManufacturer.Focus();
                return false;
            }
            if (ddlWasteEq.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Stock Options. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Waste Eq. !");
                ddlWasteEq.Focus();
                return false;
            }
            if (ddlAcc.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Stock Options. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Accessory. !");
                ddlAcc.Focus();
                return false;
            }
            if (ddlStockOptions.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Stock Options. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Stock Options. !");
                ddlStockOptions.Focus();
                return false;
            }
            if (txtQty.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Qty. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Qty. !");
                txtQty.Focus();
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
            if (CheckValidations() == true)
            {
                String msg = "";
                ObjBOL.Operation = 4;
                ObjBOL.manuf = Convert.ToInt32(ddlManufacturer.SelectedValue);
                ObjBOL.wasteeq = Convert.ToInt32(ddlWasteEq.SelectedValue);
                ObjBOL.accessory = Convert.ToInt32(ddlAcc.SelectedValue);
                ObjBOL.stockinhand = Convert.ToInt32(txtQtyAvailable.Text);
                ObjBOL.stockin = Convert.ToInt32(txtQty.Text);
                ObjBOL.stockinoption = ddlStockOptions.SelectedValue;
                ObjBOL.stockinby = Utility.GetCurrentSession().EmployeeID;
                ObjBOL.stockindate = Convert.ToDateTime(txtAdjDate.Text);
                ObjBOL.summary = txtSummary.Text;
                msg = ObjBLL.SaveStock(ObjBOL);
                Utility.ShowMessage_Success(this, msg);
                Reset();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlAcc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtAdjDate.Text = Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy");
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ObjBOL.WasteEqid = Convert.ToInt32(ddlWasteEq.SelectedValue);
            ObjBOL.accessory = Convert.ToInt32(ddlAcc.SelectedValue);
            ds = ObjBLL.BindDropDown(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtQtyAvailable.Text = ds.Tables[0].Rows[0]["stockinhand"].ToString();
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
            ddlManufacturer.SelectedIndex = 0;
            ddlWasteEq.SelectedIndex = 0;
            ddlAcc.SelectedIndex = 0;
            txtQtyAvailable.Text = String.Empty;
            txtQty.Text = String.Empty;
            txtAdjDate.Text = String.Empty;
            ddlStockOptions.SelectedIndex = 0;
            txtSummary.Text = String.Empty;
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
}