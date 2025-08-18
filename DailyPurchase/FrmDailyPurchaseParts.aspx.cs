using BLLAERO;
using BOLAERO;
using System;
using System.Data;

public partial class DailyPurchase_FrmDailyPurchaseParts : System.Web.UI.Page
{
    BOLDailyPurchaseParts ObjBOL = new BOLDailyPurchaseParts();
    BLLDailyPurchaseParts ObjBLL = new BLLDailyPurchaseParts();
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
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartHeaderList, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlVendor, ds.Tables[1]);
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProductLine, ds.Tables[2]);
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlUM, ds.Tables[3]);
            }
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
            if (txtPartNo.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Part # is required!");
                txtPartNo.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void ddlPartHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPartHeaderList_SelectedIndexChanged();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave_Click();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel_Click();
    }

    private void ddlPartHeaderList_SelectedIndexChanged()
    {
        try
        {
            ResetInfo();
            if (ddlPartHeaderList.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 3;
                ObjBOL.ID = Int32.Parse(ddlPartHeaderList.SelectedValue);
                ds = ObjBLL.Return_DataSet(ObjBOL);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    txtPartNo.Text = dr["PartNumber"].ToString();
                    txtPartDescription.Text = dr["Description"].ToString();
                    if (ddlUM.Items.FindByValue(dr["UM"].ToString()) != null)
                    {
                        ddlUM.SelectedValue = dr["UM"].ToString();
                    }
                    txtMinOrderQty.Text = dr["MinOrderQty"].ToString();
                    txtMaxStockQty.Text = dr["MaxStockQty"].ToString();
                    txtReOrderPoint.Text = dr["ReorderPoint"].ToString();
                    txtLeadTimeDays.Text = dr["LeadTimeDays"].ToString();
                    if (ddlVendor.Items.FindByValue(dr["PreferredVendorID"].ToString()) != null)
                    {
                        ddlVendor.SelectedValue = dr["PreferredVendorID"].ToString();
                    }

                    if (ddlProductLine.Items.FindByValue(dr["ProductLine"].ToString()) != null)
                    {
                        ddlProductLine.SelectedValue = dr["ProductLine"].ToString();
                    }
                    btnSave.Text = "Update";
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnSave_Click()
    {
        try
        {
            if (ValidationCheck())
            {
                string message = string.Empty;
                if (ddlPartHeaderList.SelectedIndex > 0)
                {
                    ObjBOL.Operation = 4;
                    ObjBOL.ID = Int32.Parse(ddlPartHeaderList.SelectedValue);
                    message = "Record updated successfully !!";
                }
                else
                {
                    ObjBOL.Operation = 2;
                    message = "Record inserted successfully !!";
                }

                ObjBOL.PartNumber = txtPartNo.Text.Trim();
                ObjBOL.PartDescription = txtPartDescription.Text.Trim();
                if (ddlUM.SelectedIndex > 0)
                {
                    ObjBOL.UM = Int32.Parse(ddlUM.SelectedValue);
                }

                if (txtMinOrderQty.Text.Trim() != "")
                {
                    ObjBOL.MinOrderQty = Int32.Parse(txtMinOrderQty.Text);
                }

                if (txtMaxStockQty.Text.Trim() != "")
                {
                    ObjBOL.MaxStockQty = Int32.Parse(txtMaxStockQty.Text);
                }

                if (txtReOrderPoint.Text.Trim() != "")
                {
                    ObjBOL.ReOrderPoint = Int32.Parse(txtReOrderPoint.Text);
                }

                if (txtLeadTimeDays.Text.Trim() != "")
                {
                    ObjBOL.LeadTimeDays = Int32.Parse(txtLeadTimeDays.Text);
                }

                if (ddlVendor.SelectedIndex > 0)
                {
                    ObjBOL.PreferredVendorID = Int32.Parse(ddlVendor.SelectedValue);
                }

                if (ddlProductLine.SelectedIndex > 0)
                {
                    ObjBOL.ProductLine = Int32.Parse(ddlProductLine.SelectedValue);
                }
                string returnStatus = ObjBLL.Return_String(ObjBOL).Trim();

                if (returnStatus.Length > 0)
                {
                    if (returnStatus == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "Part already exists !");
                        return;
                    }

                    Utility.ShowMessage_Success(Page, message);
                    Utility.MaintainLogsSpecial("FrmDailyPurchaseParts.aspx", btnSave.Text, returnStatus);
                    BindControls();
                    ddlPartHeaderList.SelectedValue = returnStatus;
                    ddlPartHeaderList_SelectedIndexChanged();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnCancel_Click()
    {
        try
        {
            ddlPartHeaderList.SelectedIndex = 0;
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
            txtPartNo.Text = String.Empty;
            txtPartDescription.Text = String.Empty;
            if (ddlUM.Items.Count > 0)
            {
                ddlUM.SelectedIndex = 0;
            }
            txtMinOrderQty.Text = String.Empty;
            txtMaxStockQty.Text = String.Empty;
            txtReOrderPoint.Text = String.Empty;
            txtLeadTimeDays.Text = String.Empty;
            if (ddlVendor.Items.Count > 0)
            {
                ddlVendor.SelectedIndex = 0;
            }

            if (ddlProductLine.Items.Count > 0)
            {
                ddlProductLine.SelectedIndex = 0;
            }
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}