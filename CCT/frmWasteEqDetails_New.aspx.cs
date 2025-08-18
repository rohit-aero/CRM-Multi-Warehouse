using BLLAERO;
using BOLAERO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CCT_frmWasteEqDetails_New : System.Web.UI.Page
{
    BOLWasteEq_New ObjBOL = new BOLWasteEq_New();
    BLLWasteEq_New ObjBLL = new BLLWasteEq_New();
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

    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlTrackingNumberLookupList, ds.Tables[0]);
                ddlTrackingNumberLookupList.SelectedIndex = 0;
            }
            else
            {
                ddlTrackingNumberLookupList.Items.Clear();
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectLookupList, ds.Tables[1]);
                Utility.BindDropDownList(ddlJobID, ds.Tables[1]);
                ddlProjectLookupList.SelectedIndex = 0;
                ddlJobID.SelectedIndex = 0;
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlManufacturer, ds.Tables[2]);
                ddlManufacturer.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnFilterForm_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Reports/frmWasteEqDetailsReport.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationCheck()
    {
        try
        {
            if (ddlManufacturer.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Manufacturer!");
                ddlManufacturer.Focus();
                return false;
            }

            if (ddlWasteEq.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Waste equipment!");
                ddlWasteEq.Focus();
                return false;
            }

            if (ddlAccessory.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Accessory!");
                ddlAccessory.Focus();
                return false;
            }

            if (ddlUsedFromStock.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Used From Stock!");
                ddlUsedFromStock.Focus();
                return false;
            }

            if (txtTrackingNo.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Tracking Number!");
                txtTrackingNo.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void ddlTrackingNumberLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTrackingNumberLookupList_SelectedIndexChanged_Event();
    }

    protected void ddlProjectLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlProjectLookupList_SelectedIndexChanged_Event();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave_Click_Event();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
    }

    protected void ddlManufacturer_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlManufacturer_SelectedIndexChanged_Event();
    }

    protected void ddlWasteEq_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlWasteEq_SelectedIndexChanged_Event();
    }

    protected void gvWasteEqDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            int ID = Convert.ToInt32(gvWasteEqDetails.DataKeys[e.NewEditIndex].Values[0]);
            HiddenID.Value = ID.ToString();
            ObjBOL.Operation = 5;
            ObjBOL.Id = ID;
            dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["ManufacturerId"].ToString().Trim() != "")
                {
                    ddlManufacturer.SelectedValue = dt.Rows[0]["ManufacturerId"].ToString();
                    ddlManufacturer_SelectedIndexChanged_Event();

                    if (dt.Rows[0]["WasteEqId"].ToString().Trim() != "")
                    {
                        ddlWasteEq.SelectedValue = dt.Rows[0]["WasteEqId"].ToString();
                        ddlWasteEq_SelectedIndexChanged_Event();

                        if (dt.Rows[0]["AccId"].ToString().Trim() != "")
                        {
                            ddlAccessory.SelectedValue = dt.Rows[0]["AccId"].ToString();
                        }
                    }
                }

                if (dt.Rows[0]["UsedFromStock"].ToString().Trim() != "")
                {
                    ddlUsedFromStock.SelectedValue = dt.Rows[0]["UsedFromStock"].ToString();
                }

                if (dt.Rows[0]["JobID"].ToString().Trim() != "")
                {
                    ddlJobID.SelectedValue = dt.Rows[0]["JobID"].ToString();
                }

                txtTrackingNo.Text = dt.Rows[0]["TrackingNo"].ToString();
                txtServiceProvider.Text = dt.Rows[0]["ServiceProvider"].ToString();
                txtEstDeliveryDate.Text = dt.Rows[0]["EstDeliveryDate"].ToString();
                txtReqByShopDate.Text = dt.Rows[0]["RequiredByShop"].ToString();
                txtReceivedDate.Text = dt.Rows[0]["ReceivedDate"].ToString();
                txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
            }
            btnSave.Text = "Update";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvWasteEqDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int ID = Convert.ToInt32(gvWasteEqDetails.DataKeys[e.RowIndex].Values[0]);
            GridViewRow row = gvWasteEqDetails.Rows[e.RowIndex];
            Label lblTrackingNo = (Label)row.FindControl("lblTrackingNo");
            ObjBOL.Operation = 8;
            ObjBOL.Id = ID;
            string return_msg = ObjBLL.Return_String(ObjBOL);
            if (return_msg != "")
            {
                Utility.MaintainLogsSpecial("frmWasteEqDetails_New", "Delete", lblTrackingNo.Text);
                Utility.ShowMessage_Success(Page, "Record Deleted Successfully !!");
                Reset();
                BindControls();                
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void ddlTrackingNumberLookupList_SelectedIndexChanged_Event()
    {
        try
        {
            if (ddlTrackingNumberLookupList.SelectedIndex > 0)
            {
                ddlProjectLookupList.SelectedIndex = 0;
                ObjBOL.Operation = 9;
                ObjBOL.TrackingNo = ddlTrackingNumberLookupList.SelectedValue;
                string returnValue = ObjBLL.Return_String(ObjBOL);
                if (returnValue.Trim() != "" && ddlProjectLookupList.Items.FindByValue(returnValue) != null)
                {
                    ddlProjectLookupList.SelectedValue = returnValue;
                }
                ObjBOL.JobID = string.Empty;
                ObjBOL.TrackingNo = ddlTrackingNumberLookupList.SelectedValue;
                FilterGrid();
            }
            else
            {
                Reset();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlProjectLookupList_SelectedIndexChanged_Event()
    {
        try
        {
            if (ddlProjectLookupList.SelectedIndex > 0)
            {
                ddlTrackingNumberLookupList.SelectedIndex = 0;
                ObjBOL.Operation = 10;
                ObjBOL.JobID = ddlProjectLookupList.SelectedValue;
                string returnValue = ObjBLL.Return_String(ObjBOL);
                if (returnValue.Trim() != "" && ddlTrackingNumberLookupList.Items.FindByValue(returnValue) != null)
                {
                    ddlTrackingNumberLookupList.SelectedValue = returnValue;
                }
                ObjBOL.TrackingNo = string.Empty;
                ObjBOL.JobID = ddlProjectLookupList.SelectedValue;
                FilterGrid();
            }
            else
            {
                Reset();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FilterGrid()
    {
        try
        {

            if (ddlTrackingNumberLookupList.SelectedIndex == 0 && ddlProjectLookupList.SelectedIndex == 0)
            {
                Reset();
                return;
            }
            ResetEntryFields();
            DataTable dt = new DataTable();
            ObjBOL.Operation = 4;
            //if (ddlTrackingNumberLookupList.SelectedIndex > 0)
            //{
            //    ObjBOL.TrackingNo = ddlTrackingNumberLookupList.SelectedValue;
            //}
            //else
            //{
            //    ObjBOL.TrackingNo = string.Empty;
            //}

            //if (ddlProjectLookupList.SelectedIndex > 0)
            //{
            //    ObjBOL.JobID = ddlProjectLookupList.SelectedValue;
            //}
            //else
            //{
            //    ObjBOL.JobID = string.Empty;
            //}

            dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
            if (dt.Rows.Count > 0)
            {
                gvWasteEqDetails.DataSource = dt;
                gvWasteEqDetails.DataBind();
            }
            else
            {
                ResetGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlManufacturer_SelectedIndexChanged_Event()
    {
        try
        {
            ClearWasteEqList();
            ClearAccessoryList();
            if (ddlManufacturer.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                ObjBOL.Operation = 2;
                ObjBOL.ManufacturerId = Int32.Parse(ddlManufacturer.SelectedValue);
                dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlWasteEq, dt);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlWasteEq_SelectedIndexChanged_Event()
    {
        try
        {
            ClearAccessoryList();
            if (ddlWasteEq.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                ObjBOL.Operation = 3;
                ObjBOL.WasteEqId = Int32.Parse(ddlWasteEq.SelectedValue);
                dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlAccessory, dt);
                }
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
            if (!ValidationCheck())
            {
                return;
            }
            string message = string.Empty;
            ObjBOL.ManufacturerId = Int32.Parse(ddlManufacturer.SelectedValue);
            ObjBOL.WasteEqId = Int32.Parse(ddlWasteEq.SelectedValue);
            ObjBOL.AccessoryId = Int32.Parse(ddlAccessory.SelectedValue);
            ObjBOL.UsedFromStock = ddlUsedFromStock.SelectedValue;
            if (ddlJobID.SelectedIndex > 0)
            {
                ObjBOL.JobID = ddlJobID.SelectedValue;
            }
            else
            {
                ObjBOL.JobID = string.Empty;
            }
            ObjBOL.TrackingNo = txtTrackingNo.Text;
            ObjBOL.ServiceProvider = txtServiceProvider.Text;
            if (txtEstDeliveryDate.Text.Trim() != "")
            {
                ObjBOL.EstimatedDeliveryDate = Utility.ConvertDate(txtEstDeliveryDate.Text);
            }

            if (txtReqByShopDate.Text.Trim() != "")
            {
                ObjBOL.RequestedByShop = Utility.ConvertDate(txtReqByShopDate.Text);
            }

            if (txtReceivedDate.Text.Trim() != "")
            {
                ObjBOL.ReceivedDate = Utility.ConvertDate(txtReceivedDate.Text);
            }

            ObjBOL.EmployeeId = Utility.GetCurrentUser();

            if (HiddenID.Value == "0")
            {
                ObjBOL.Operation = 6;
                message = "Record Inserted Successfully !!";
            }
            else
            {
                ObjBOL.Operation = 7;
                ObjBOL.Id = Int32.Parse(HiddenID.Value);
                message = "Record Updated Successfully !!";
            }

            ObjBOL.Remarks = txtRemarks.Text;
            string return_msg = ObjBLL.Return_String(ObjBOL);

            if (return_msg.Trim() != "")
            {
                Utility.MaintainLogsSpecial("frmWasteEqDetails_New", btnSave.Text, return_msg);
                Utility.ShowMessage_Success(Page, message);
                Reset();
                BindControls();
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
            if (ddlTrackingNumberLookupList.Items.Count > 0)
            {
                ddlTrackingNumberLookupList.SelectedIndex = 0;
            }

            if (ddlProjectLookupList.Items.Count > 0)
            {
                ddlProjectLookupList.SelectedIndex = 0;
            }
            ResetEntryFields();
            ResetGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetEntryFields()
    {
        try
        {
            if (ddlManufacturer.Items.Count > 0)
            {
                ddlManufacturer.SelectedIndex = 0;
            }

            ClearWasteEqList();
            ClearAccessoryList();

            if (ddlUsedFromStock.Items.Count > 0)
            {
                ddlUsedFromStock.SelectedIndex = 0;
            }

            if (ddlJobID.Items.Count > 0)
            {
                ddlJobID.SelectedIndex = 0;
            }

            txtTrackingNo.Text = string.Empty;
            txtServiceProvider.Text = string.Empty;
            txtEstDeliveryDate.Text = string.Empty;
            txtReqByShopDate.Text = string.Empty;
            txtReceivedDate.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            HiddenID.Value = "0";
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearWasteEqList()
    {
        try
        {
            ddlWasteEq.Items.Clear();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearAccessoryList()
    {
        try
        {
            ddlAccessory.Items.Clear();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetGrid()
    {
        try
        {
            gvWasteEqDetails.DataSource = string.Empty;
            gvWasteEqDetails.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}