using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class DailyPurchase_FrmDailyPurchase : System.Web.UI.Page
{
    BOLDailyPurchase ObjBOL = new BOLDailyPurchase();
    BLLDailyPurchase ObjBLL = new BLLDailyPurchase();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindControls();
                btnSaveDetail.Enabled = false;
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
            ObjBOL.Operation = 1;
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            int tableIndex = 0;
            if (ds.Tables[tableIndex].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPOHeaderList, ds.Tables[tableIndex]);
            }

            tableIndex = 1;
            if (ds.Tables[tableIndex].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlVendor, ds.Tables[tableIndex]);
            }

            tableIndex = 2;
            if (ds.Tables[tableIndex].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPart, ds.Tables[tableIndex]);
            }

            tableIndex = 3;
            if (ds.Tables[tableIndex].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRequester, ds.Tables[tableIndex]);
            }

            //tableIndex = 4;
            //if (ds.Tables[tableIndex].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlProject, ds.Tables[tableIndex]);
            //}

            //tableIndex = 5;
            //if (ds.Tables[tableIndex].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlDepartment, ds.Tables[tableIndex]);
            //}

            //tableIndex = 6;
            //if (ds.Tables[tableIndex].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlUM, ds.Tables[tableIndex]);
            //}

            //tableIndex = 4;
            //if (ds.Tables[tableIndex].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlOrderStatus, ds.Tables[tableIndex]);
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindHeaderOnly()
    {
        try
        {
            ObjBOL.Operation = 2;
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            int tableIndex = 0;
            if (ds.Tables[tableIndex].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPOHeaderList, ds.Tables[tableIndex]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationCheckMain()
    {
        try
        {
            if (txtPONo.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter PONo !");
                txtPONo.Focus();
                return false;
            }

            if (ddlVendor.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Vendor !");
                ddlVendor.Focus();
                return false;
            }           

            if (txtOrderDate.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Order Date !");
                txtOrderDate.Focus();
                return false;
            }          
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private bool ValidationCheckDetail()
    {
        try
        {
            if (ddlPOHeaderList.SelectedIndex <= 0)
            {
                Utility.ShowMessage_Error(Page, "Please select PO !");
                ddlPOHeaderList.Focus();
                return false;
            }

            if (ddlPart.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Part !");
                ddlPart.Focus();
                return false;
            }

            if (txtOrderQty.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Order Qty !");
                txtOrderQty.Focus();
                return false;
            }

            if (ddlRequester.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select requester !");
                ddlRequester.Focus();
                return false;
            }

            if (ddlDepartment.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Department !");
                ddlDepartment.Focus();
                return false;
            }

            if (ddlOrderStatus.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Status !");
                ddlOrderStatus.Focus();
                return false;
            }

            if (txtUnitPrice.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Unit Price !");
                txtUnitPrice.Focus();
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
        btnSave_Click();
    }

    private void btnSave_Click()
    {
        try
        {
            if (ValidationCheckMain())
            {
                string message = "";
                if (ddlPOHeaderList.SelectedIndex > 0)
                {
                    ObjBOL.Operation = 5;
                    ObjBOL.DailyPurchaseId = Int32.Parse(ddlPOHeaderList.SelectedValue);
                    message = "PO updated successfully !!";
                }
                else
                {
                    ObjBOL.Operation = 4;
                    message = "PO inserted successfully !!";
                }
                ObjBOL.PONo = txtPONo.Text.Trim();

                if (ddlVendor.SelectedIndex > 0)
                {
                    ObjBOL.VendorId = Int32.Parse(ddlVendor.SelectedValue);
                }                            

                if (txtOrderDate.Text.Trim() != "")
                {
                    ObjBOL.OrderDate = Utility.ConvertDate(txtOrderDate.Text);
                }
              
                string returnStatus = ObjBLL.Return_String(ObjBOL).Trim();
                if (returnStatus.Length > 0)
                {
                    if (returnStatus == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "PO No already exists !");
                        return;
                    }
                    Utility.ShowMessage_Success(Page, message);
                    Utility.MaintainLogsSpecial("FrmDailyPurchase.aspx", btnSave.Text, returnStatus);
                    BindHeaderOnly();
                    ddlPOHeaderList.SelectedValue = returnStatus;
                    ddlPOHeaderList_SelectedIndexChanged();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPOHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPOHeaderList_SelectedIndexChanged();
    }

    private void ddlPOHeaderList_SelectedIndexChanged()
    {
        try
        {
            ResetInfo();
            if (ddlPOHeaderList.SelectedIndex > 0)
            {
                ObjBOL.Operation = 3;
                ObjBOL.DailyPurchaseId = Int32.Parse(ddlPOHeaderList.SelectedValue);
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    txtPONo.Text = dr["PONumber"].ToString();
                    if (ddlVendor.Items.FindByValue(dr["VendorID"].ToString()) != null)
                    {
                        ddlVendor.SelectedValue = dr["VendorID"].ToString();
                    }

                    //if (ddlRequester.Items.FindByValue(dr["RequesterID"].ToString()) != null)
                    //{
                    //    ddlRequester.SelectedValue = dr["RequesterID"].ToString();
                    //}

                    txtOrderDate.Text = dr["OrderDate"].ToString();
                    //txtETA.Text = dr["ETA"].ToString();

                    //if (ddlOrderStatus.Items.FindByValue(dr["OrderStatus"].ToString()) != null)
                    //{
                    //    ddlOrderStatus.SelectedValue = dr["OrderStatus"].ToString();
                    //}
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    gvDailyPurchaseDetail.DataSource = ds.Tables[1];
                    ViewState["dirState"] = ds.Tables[1];
                    gvDailyPurchaseDetail.DataBind();
                }
                btnSave.Text = "Update";
                btnSaveDetail.Enabled = true;
            }
            else
            {
                btnSave.Text = "Save";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel_Click();
    }

    private void btnCancel_Click()
    {
        try
        {
            if (ddlPOHeaderList.Items.Count > 0)
            {
                ddlPOHeaderList.SelectedIndex = 0;
            }
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
            txtPONo.Text = string.Empty;

            btnSave.Enabled = true;
            btnSave.Text = "Save";
            btnSaveDetail.Text = "Add Part";
            btnSaveDetail.Enabled = false;

            if (ddlVendor.Items.Count > 0)
            {
                ddlVendor.SelectedIndex = 0;
            }

            if (ddlPart.Items.Count > 0)
            {
                ddlPart.SelectedIndex = 0;
            }

            if (ddlRequester.Items.Count > 0)
            {
                ddlRequester.SelectedIndex = 0;
            }

            if (ddlDepartment.Items.Count > 0)
            {
                ddlDepartment.SelectedIndex = 0;
            }

            txtOrderQty.Text = string.Empty;
            txtOrderDate.Text = string.Empty;

            if (ddlOrderStatus.Items.Count > 0)
            {
                ddlOrderStatus.SelectedIndex = 0;
            }

            txtETA.Text = string.Empty;
            txtReceivedDate.Text = string.Empty;
            txtRemarks.Text = string.Empty;

            txtReceivedQty.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtTotalCost.Text = string.Empty;
            hfDetailID.Value = "-1";

            gvDailyPurchaseDetail.DataSource = string.Empty;
            gvDailyPurchaseDetail.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSaveDetail_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheckDetail())
            {
                string message = "";
                if (hfDetailID.Value != "-1")
                {
                    ObjBOL.Operation = 7;
                    ObjBOL.Id = Int32.Parse(hfDetailID.Value);
                    message = "Record updated successfully !!";
                }
                else
                {
                    ObjBOL.Operation = 6;
                    message = "Record inserted successfully !!";
                }

                if (ddlPOHeaderList.SelectedIndex > 0)
                {
                    ObjBOL.DailyPurchaseId = Int32.Parse(ddlPOHeaderList.SelectedValue);
                }

                if (ddlPart.SelectedIndex > 0)
                {
                    ObjBOL.PartId = Int32.Parse(ddlPart.SelectedValue);
                }

                if (txtOrderQty.Text.Trim() != "")
                {
                    ObjBOL.OrderQty = Int32.Parse(txtOrderQty.Text);
                }

                if (txtReceivedQty.Text.Trim() != "")
                {
                    ObjBOL.ReceivedQty = Int32.Parse(txtReceivedQty.Text);
                }

                if (ddlRequester.SelectedIndex > 0)
                {
                    ObjBOL.RequesterId = Int32.Parse(ddlRequester.SelectedValue);
                }

                if (txtETA.Text.Trim() != "")
                {
                    ObjBOL.ETA = Utility.ConvertDate(txtETA.Text);
                }

                if (ddlDepartment.SelectedIndex > 0)
                {
                    ObjBOL.Department = ddlDepartment.SelectedValue;
                }

                if (ddlOrderStatus.SelectedIndex > 0)
                {
                    ObjBOL.OrderStatus = ddlOrderStatus.SelectedValue;
                }

                if (txtReceivedDate.Text.Trim() != "")
                {
                    ObjBOL.ReceivedDate = Utility.ConvertDate(txtReceivedDate.Text);
                }

                if (txtUnitPrice.Text.Trim() != "")
                {
                    ObjBOL.UnitPrice = Decimal.Parse(txtUnitPrice.Text);
                }

                if (txtTotalCost.Text.Trim() != "")
                {
                    ObjBOL.TotalCost = Decimal.Parse(txtTotalCost.Text);
                }

                if (txtRemarks.Text.Trim() != "")
                {
                    ObjBOL.Remarks = txtRemarks.Text;
                }
                string returnStatus = ObjBLL.Return_String(ObjBOL).Trim();
                if (returnStatus.Length > 0)
                {
                    if (returnStatus == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "Entry not found !");
                        return;
                    }
                    else if (returnStatus == "ER02")
                    {
                        Utility.ShowMessage_Error(Page, "Part already exists for PO!");
                        return;
                    }

                    Utility.ShowMessage_Success(Page, message);
                    Utility.MaintainLogsSpecial("FrmDailyPurchase.aspx", btnSaveDetail.Text, returnStatus);
                    ddlPOHeaderList_SelectedIndexChanged();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDailyPurchaseDetail_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            int ID = Convert.ToInt32(gvDailyPurchaseDetail.DataKeys[e.NewEditIndex].Values[0]);
            hfDetailID.Value = ID.ToString();
            ObjBOL.Operation = 8;
            ObjBOL.Id = ID;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (ddlPart.Items.FindByValue(row["PartId"].ToString()) != null)
                {
                    ddlPart.SelectedValue = row["PartId"].ToString();
                }
                else
                {
                    ddlPart.SelectedIndex = 0;
                }

                txtOrderQty.Text = row["OrderQty"].ToString();
                txtReceivedQty.Text = row["ReceivedQty"].ToString();
                txtReceivedDate.Text = row["ReceivedDate"].ToString();
                if (ddlRequester.Items.FindByValue(row["RequesterID"].ToString()) != null)
                {
                    ddlRequester.SelectedValue = row["RequesterID"].ToString();
                }
                txtETA.Text = row["ETA"].ToString();

                if (ddlDepartment.Items.FindByValue(row["DepartmentCode"].ToString()) != null)
                {
                    ddlDepartment.SelectedValue = row["DepartmentCode"].ToString();
                }
                else
                {
                    ddlDepartment.SelectedIndex = 0;
                }

                if (ddlOrderStatus.Items.FindByValue(row["Status"].ToString()) != null)
                {
                    ddlOrderStatus.SelectedValue = row["Status"].ToString();
                }
                else
                {
                    ddlOrderStatus.SelectedIndex = 0;
                }

                txtUnitPrice.Text = row["UnitPrice"].ToString();
                txtTotalCost.Text = row["TotalCost"].ToString();
                txtRemarks.Text = row["Remarks"].ToString();
                btnSave.Enabled = false;
                btnSaveDetail.Text = "Update Part";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDailyPurchaseDetail_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        try
        {
            int ID = Convert.ToInt32(gvDailyPurchaseDetail.DataKeys[e.RowIndex].Values[0]);
            ObjBOL.Operation = 9;
            ObjBOL.Id = ID;
            string returnStatus = ObjBLL.Return_String(ObjBOL).Trim();
            if (returnStatus.Length > 0)
            {
                Utility.MaintainLogsSpecial("FrmDailyPurchase.aspx", "Delete", ddlPOHeaderList.SelectedValue);
                Utility.ShowMessage_Success(Page, "Record deleted successfully !!");
                ddlPOHeaderList_SelectedIndexChanged();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDailyPurchaseDetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                DataView dataView = new DataView(dtrslt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvDailyPurchaseDetail.DataSource = dataView;
                gvDailyPurchaseDetail.DataBind();
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + "DESC";
                gvDailyPurchaseDetail.DataSource = dtrslt;
                gvDailyPurchaseDetail.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "DESC"; }
        set { ViewState["SortDirection"] = value; }
    }

    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        switch (GridViewSortDirection)
        {
            case "ASC":
                GridViewSortDirection = "DESC";
                break;

            case "DESC":
                GridViewSortDirection = "ASC";
                break;
        }
        return GridViewSortDirection;
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            ObjBOL.Operation = 10;
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenerateReport()
    {
        try
        {
            DataTable dt = ReportData();
            rprt.Load(Server.MapPath("~/DailyPurchase/rptDailyPurchase.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Daily Purchase Report - " + DateTime.Now.ToString("dddd, dd MMMM yyyy").Replace(',', ' ');
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }

    //protected void btnReport_Click(object sender, EventArgs e)
    //{
    //    GenerateReport();
    //}

    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "~/DailyPurchase/FrmDailyPurchaseReport.aspx";
            Response.Redirect(link);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtOrderQty_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalCost();
    }

    protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
    {
        CalculateTotalCost();
    }

    private void CalculateTotalCost()
    {
        try
        {
            int OrderQty = 0;
            decimal unitPrice = 0;
            if (txtOrderQty.Text != "")
            {
                OrderQty = Int32.Parse(txtOrderQty.Text);
            }

            if (txtUnitPrice.Text != "")
            {
                unitPrice = Decimal.Parse(txtUnitPrice.Text);
                unitPrice = Math.Round(unitPrice, 4);
                txtUnitPrice.Text = unitPrice.ToString();
            }

            txtTotalCost.Text = Convert.ToString(Math.Round(OrderQty * unitPrice, 2));
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnPartRedirect_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/DailyPurchase/FrmDailyPurchaseParts.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnVendorMaintenance_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/DailyPurchase/frmVendorMaintenance.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}