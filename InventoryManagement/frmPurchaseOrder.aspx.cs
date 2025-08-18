using System;
using BOLAERO;
using BLLAERO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class InventoryManagement_frmPurchaseOrder : System.Web.UI.Page
{
    BOLPurchaseOrder ObjBOL = new BOLPurchaseOrder();
    BLLPurchaseOrder ObjBLL = new BLLPurchaseOrder();
    commonclass1 cls = new commonclass1();
    string msg = "";
    string status = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfPurchaseOrderIdGetFromDB.Value = null;
            EmptyDT();
            Bind_Controls(msg);
            Bind_Grid();
            Bind_GridContainer();
        }
    }


    private void Bind_Controls(string controllerId)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPurchaseOrder, ds.Tables[0]);
                if (controllerId != "")
                {
                    ddlPurchaseOrder.SelectedValue = controllerId;
                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSource, ds.Tables[1]);
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPreparedby, ds.Tables[2]);
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private DataTable EmptyDT()
    {
        DataTable dtEmpty = new DataTable();
        try
        {
            dtEmpty.TableName = "GridSummary";
            dtEmpty.Columns.Add(new DataColumn("PurchaseOrderId", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("ReqDetailId", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("OrderQty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("PartId", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("ShipQty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Pendingqty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Remarks", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("IsSelected", typeof(int)));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);//adding row to the datatable            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    private void Bind_Grid()
    {

        DataSet ds = new DataSet();
        ObjBOL.Operation = 6;
        var EmployeeID = Utility.GetCurrentSession().EmployeeID;
        //if (EmployeeID == 237)
        //{
        //    ObjBOL.ReqForId = 1;
        //}
        //else if (EmployeeID == 263)
        //{
        //    ObjBOL.ReqForId = 2;
        //}
        ds = ObjBLL.GetBindControl(ObjBOL);
        if (EmployeeID == 263 || EmployeeID == 237)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvMainRequisitionDetail.DataSource = ds.Tables[0];
                gvMainRequisitionDetail.DataBind();
            }
        }
    }

    private void Bind_GridContainer()
    {
        try
        {
            DataSet ds = new DataSet();
            DataSet ds_1 = new DataSet();
            ObjBOL.Operation = 12;
            ds_1 = ObjBLL.GetBindControl(ObjBOL);
            foreach (GridViewRow row in gvMainRequisitionDetail.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    Label ReqNo = (row.FindControl("ReqNo") as Label);
                    DropDownList ddlstatus = (row.FindControl("ddlstatus") as DropDownList);
                    string status = (row.FindControl("lblStatus") as Label).Text;
                    string ReqforId = (row.FindControl("lblReqforId") as Label).Text;
                    ddlstatus.Items.FindByValue(status).Selected = true;
                    GridView gvContainer = row.FindControl("gvContainer") as GridView;
                    string reqId = gvMainRequisitionDetail.DataKeys[row.RowIndex].Value.ToString();

                    ObjBOL.Operation = 7;
                    ObjBOL.ReqId = Convert.ToInt32(reqId);
                    ObjBOL.ReqForId = Convert.ToInt32(ReqforId);
                    ds = ObjBLL.GetBindControl(ObjBOL);
                    DataTable dtContainer = new DataTable();
                    var EmployeeID = Utility.GetCurrentSession().EmployeeID;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtContainer = ds.Tables[0];
                    }
                    //for (int i = dtContainer.Rows.Count - 1; i >= 0; i--)
                    //{
                    //    DataRow dr = dtContainer.Rows[i];
                    //    if (dr["OrderQty"].ToString() == "0")
                    //        dr.Delete();
                    //    dtContainer.AcceptChanges();
                    //}
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvContainer.DataSource = dtContainer;
                        gvContainer.DataBind();

                        foreach (GridViewRow rowChild in gvContainer.Rows)
                        {

                            Label lblItemPartId = ((Label)rowChild.FindControl("lblItemPartid") as Label);
                            DropDownList SourceListChild = ((DropDownList)rowChild.FindControl("ddlSourceChild"));
                            Utility.BindDropDownList(SourceListChild, ds_1.Tables[0]);

                            ObjBOL.Operation = 13;
                            ObjBOL.SourceID = lblItemPartId.Text;
                            DataSet SourceDataset = ObjBLL.GetBindControl(ObjBOL);
                            if (SourceDataset.Tables[0].Rows.Count > 0)
                            {
                                if (Int32.Parse(SourceDataset.Tables[0].Rows[0][0].ToString()) > 0)
                                {
                                    SourceListChild.SelectedValue = SourceDataset.Tables[0].Rows[0][0].ToString();
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_GridAfterSubmit()
    {

        DataSet ds = new DataSet();
        ObjBOL.Operation = 9;
        var EmployeeID = Utility.GetCurrentSession().EmployeeID;
        if (EmployeeID == 237)
        {
            ObjBOL.ReqForId = 1;
        }

        else if (EmployeeID == 263)
        {
            ObjBOL.ReqForId = 2;
        }

        if (hfPurchaseOrderIdGetFromDB.Value != "")
        {
            ObjBOL.PONumberID = Convert.ToInt32(hfPurchaseOrderIdGetFromDB.Value);
        }

        ds = ObjBLL.GetBindControl(ObjBOL);
        if (EmployeeID == 263 || EmployeeID == 237)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvMainRequisitionDetail.DataSource = ds.Tables[0];
                gvMainRequisitionDetail.DataBind();
            }

        }

    }

    private void Bind_GridChangeContainer()
    {
        try
        {
            var EmployeeID = Utility.GetCurrentSession().EmployeeID;
            //hfContaineridgetfromdb.Value = ddlRequisitionNo.SelectedValue;           

            Bind_GridAfterSubmit();

            //DataTable TempData = (DataTable)ViewState["ContainerSummary"];
            btnSave.Text = "Update";
            //Bind_GridOnChangeContainer();
            DataSet ds = new DataSet();
            DataSet ds_1 = new DataSet();
            ObjBOL.Operation = 12;
            ds_1 = ObjBLL.GetBindControl(ObjBOL);
            foreach (GridViewRow row in gvMainRequisitionDetail.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Label ReqNo = (row.FindControl("ReqNo") as Label);
                    Label ReqForId = (row.FindControl("lblReqforId") as Label);
                    DropDownList ddlstatus = (row.FindControl("ddlstatus") as DropDownList);
                    //Select the Country of Customer in DropDownList                    
                    string status = (row.FindControl("lblStatus") as Label).Text;
                    ddlstatus.ClearSelection();
                    ddlstatus.Items.FindByValue(status).Selected = true;
                    string reqId = gvMainRequisitionDetail.DataKeys[row.RowIndex].Value.ToString();

                    ObjBOL.Operation = 7;
                    ObjBOL.ReqId = Convert.ToInt32(reqId);
                    ObjBOL.ReqForId = Convert.ToInt32(ReqForId.Text);
                    ds = ObjBLL.GetBindControl(ObjBOL);
                    DataTable dtContainer = new DataTable();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtContainer = ds.Tables[0];
                    }

                    GridView gvContainer = row.FindControl("gvContainer") as GridView;
                    ObjBOL.ReqId = Convert.ToInt32(reqId);
                    ObjBOL.PONumberID = Convert.ToInt32(ddlPurchaseOrder.SelectedValue);
                    ObjBOL.ReqForId = Convert.ToInt32(ReqForId.Text);
                    ObjBOL.Operation = 8;
                    ds = ObjBLL.GetBindControl(ObjBOL);
                    DataTable dtPurchaseOrderUpdate = new DataTable();
                    if (EmployeeID == 263 || EmployeeID == 237)
                    {
                        dtPurchaseOrderUpdate = ds.Tables[0];

                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow dtRow in dtContainer.Rows)
                            {
                                foreach (DataRow dtRow1 in dtPurchaseOrderUpdate.Rows)
                                {
                                    if (dtRow["ReqDetailId"].ToString() == dtRow1["ReqDetailId"].ToString())
                                    {
                                        dtRow["ShippedQty"] = dtRow1["ShippedQty"];
                                        dtRow["Remarks"] = dtRow1["Remarks"];
                                        break;
                                    }
                                }
                            }

                            gvContainer.DataSource = dtContainer;
                            gvContainer.DataBind();

                        }
                        else
                        {
                            gvContainer.DataSource = dtContainer;
                            gvContainer.DataBind();

                        }
                        foreach (GridViewRow rowChild in gvContainer.Rows)
                        {
                            CheckBox IsSelected = ((CheckBox)rowChild.FindControl("chkIsSelected"));
                            Label ReqDetailId = ((Label)rowChild.FindControl("lblReqDetailId") as Label);
                            Label lblItemPartId = ((Label)rowChild.FindControl("lblItemPartid") as Label);
                            TextBox ShippedQty = ((TextBox)rowChild.FindControl("txtShippingQty"));

                            DropDownList SourceListChild = ((DropDownList)rowChild.FindControl("ddlSourceChild"));
                            Utility.BindDropDownList(SourceListChild, ds_1.Tables[0]);

                            ObjBOL.Operation = 13;
                            ObjBOL.SourceID = lblItemPartId.Text;
                            DataSet SourceDataset = ObjBLL.GetBindControl(ObjBOL);
                            if (SourceDataset.Tables[0].Rows.Count > 0)
                            {
                                if (Int32.Parse(SourceDataset.Tables[0].Rows[0][0].ToString()) > 0)
                                {
                                    SourceListChild.SelectedValue = SourceDataset.Tables[0].Rows[0][0].ToString();
                                }
                            }

                            foreach (DataRow dtRow1 in dtPurchaseOrderUpdate.Rows)
                            {
                                if (ReqDetailId.Text == dtRow1["ReqDetailId"].ToString())
                                {
                                    ObjBOL.Operation = 15;
                                    ObjBOL.SourceID = lblItemPartId.Text;
                                    DataSet SourceDataset_1 = ObjBLL.GetBindControl(ObjBOL);
                                    if (SourceDataset_1.Tables[0].Rows.Count > 0)
                                    {
                                        if (Int32.Parse(SourceDataset_1.Tables[0].Rows[0][0].ToString()) > 0)
                                        {
                                            SourceListChild.SelectedValue = SourceDataset_1.Tables[0].Rows[0][0].ToString();
                                        }
                                    }
                                    IsSelected.Checked = true;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        dtPurchaseOrderUpdate = ds.Tables[1];
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            gvContainer.DataSource = dtPurchaseOrderUpdate;
                            gvContainer.DataBind();
                            foreach (GridViewRow rowChild in gvContainer.Rows)
                            {
                                CheckBox IsSelected = ((CheckBox)rowChild.FindControl("chkIsSelected"));
                                Label ReqDetailId = ((Label)rowChild.FindControl("lblReqDetailId") as Label);
                                Label lblItemPartId = ((Label)rowChild.FindControl("lblItemPartid") as Label);
                                TextBox ShippedQty = ((TextBox)rowChild.FindControl("txtShippingQty"));

                                DropDownList SourceListChild = ((DropDownList)rowChild.FindControl("ddlSourceChild"));
                                Utility.BindDropDownList(SourceListChild, ds_1.Tables[0]);

                                ObjBOL.Operation = 13;
                                ObjBOL.SourceID = lblItemPartId.Text;
                                DataSet SourceDataset = ObjBLL.GetBindControl(ObjBOL);
                                if (SourceDataset.Tables[0].Rows.Count > 0)
                                {
                                    if (Int32.Parse(SourceDataset.Tables[0].Rows[0][0].ToString()) > 0)
                                    {
                                        SourceListChild.SelectedValue = SourceDataset.Tables[0].Rows[0][0].ToString();
                                    }
                                }
                                foreach (DataRow dtRow1 in dtPurchaseOrderUpdate.Rows)
                                {
                                    if (ReqDetailId.Text == dtRow1["ReqDetailId"].ToString())
                                    {
                                        IsSelected.Checked = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPurchaseOrder.SelectedIndex > 0)
            {
                msg = ddlPurchaseOrder.SelectedValue;
                AutoFillData();
                Bind_GridChangeContainer();
                hfPurchaseOrderIdGetFromDB.Value = ddlPurchaseOrder.SelectedValue;
                btnSave.Text = "Update";
            }
            else
            {
                Bind_GridContainer();
                ResetControls();
                btnSave.Text = "Save";
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }


    protected void ddlSourceChild_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlSourceChild = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlSourceChild.NamingContainer;
            TextBox remarks = (TextBox)row.FindControl("txtItemRemarks");
            remarks.Focus();
            remarks.Text = "Remarks are required for source change";
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
            if (txtPurchaseOrderNo.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Purchase Order No. !');", true);
                txtPurchaseOrderNo.Focus();
                return false;
            }
            if (ddlSource.SelectedIndex < 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Vendor No. !');", true);
                ddlPurchaseOrder.Focus();
                return false;
            }
            if (txtissuedate.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Issue Date. !');", true);
                txtissuedate.Focus();
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
            if (ValidationCheck() == true)
            {
                if (btnSave.Text == "Save")
                {
                    SavePurchaseOrderInfo();
                }
                else if (btnSave.Text == "Update")
                {
                    UpdatePurchaseOrderInfo();
                }
                btnSubmit.Enabled = true;
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
            ResetControls();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 14;
            if (ddlPurchaseOrder.SelectedIndex > 0)
            {
                ObjBOL.PONumberID = Convert.ToInt32(ddlPurchaseOrder.SelectedValue);
            }
            msg = ObjBLL.UpdatePurchaseOrderStatus(ObjBOL);
            Utility.ShowMessage(this, msg);
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable EmptyDTPurchaseOrderDetail()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.TableName = "PurchaseOrderDetailSummary";
            dt.Columns.Add(new DataColumn("ReqDetailId", typeof(int)));
            dt.Columns.Add(new DataColumn("ReqStatus", typeof(int)));
            dt.Columns.Add(new DataColumn("PurchaseOrderId", typeof(int)));
            dt.Columns.Add(new DataColumn("OrderQty", typeof(int)));
            dt.Columns.Add(new DataColumn("PartId", typeof(int)));
            dt.Columns.Add(new DataColumn("ShipQty", typeof(int)));
            dt.Columns.Add(new DataColumn("PendingQty", typeof(int)));
            dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
            dt.Columns.Add(new DataColumn("IsSelected", typeof(int)));
            dt.Columns.Add(new DataColumn("SourceChildId", typeof(int)));
            dt.Columns.Add(new DataColumn("Id", typeof(int)));
            ViewState["PurchaseOrderDetailSummary"] = dt;

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void SaveGridData()
    {
        try
        {

            DataTable dt = EmptyDTPurchaseOrderDetail();
            foreach (GridViewRow row in gvMainRequisitionDetail.Rows)
            {
                DataRow dr;
                if (row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ReqStatus = (row.FindControl("ddlstatus") as DropDownList);
                    //Label ReqNo = (row.FindControl("lblReqId") as Label);
                    GridView gvContainer = row.FindControl("gvContainer") as GridView;
                    foreach (GridViewRow Containerrow in gvContainer.Rows)
                    {
                        Label ReqDetailId = ((Label)Containerrow.FindControl("lblReqDetailId") as Label);
                        if (Containerrow.RowType == DataControlRowType.DataRow)
                        {
                            dr = dt.NewRow();
                            Label PartId = ((Label)Containerrow.FindControl("lblItemPartid"));
                            Label PartNo = ((Label)Containerrow.FindControl("lblPartnumber"));
                            Label RevisionNo = ((Label)Containerrow.FindControl("lblRevisionNo"));
                            Label PartDes = ((Label)Containerrow.FindControl("lblPartDes"));
                            Label ReqPriority = ((Label)Containerrow.FindControl("lblReqprority"));
                            Label OrderQty = ((Label)Containerrow.FindControl("lblOrderQty"));
                            Label Pending = ((Label)Containerrow.FindControl("lblPendingQty"));
                            TextBox ShippedQty = ((TextBox)Containerrow.FindControl("txtShippingQty"));
                            TextBox ItemRemarks = ((TextBox)Containerrow.FindControl("txtItemRemarks"));
                            CheckBox IsSelected = ((CheckBox)Containerrow.FindControl("chkIsSelected"));
                            DropDownList SourceChildId = (Containerrow.FindControl("ddlSourceChild") as DropDownList);

                            if (ReqDetailId.Text != "")
                            {
                                dr[0] = Convert.ToInt32(ReqDetailId.Text);
                            }
                            if (ReqStatus.SelectedValue == "")
                            {
                                dr[1] = 0;
                            }
                            else
                            {
                                dr[1] = ReqStatus.SelectedValue;
                            }
                            dr[2] = 0;
                            dr[3] = OrderQty.Text;
                            dr[4] = PartId.Text;
                            if (ShippedQty.Text != "")
                            {
                                dr[5] = ShippedQty.Text;
                            }
                            else
                            {
                                dr[5] = 0;
                            }
                            int OrderQuantity;
                            if (OrderQty.Text != "")
                            {
                                OrderQuantity = Convert.ToInt32(OrderQty.Text);
                            }
                            else
                            {
                                OrderQuantity = 0;
                            }
                            int ShippedQuantity;
                            if (ShippedQty.Text != "")
                            {
                                ShippedQuantity = Convert.ToInt32(ShippedQty.Text);
                            }
                            else
                            {
                                ShippedQuantity = 0;
                            }

                            int PendingQty;
                            PendingQty = OrderQuantity - ShippedQuantity;
                            dr[6] = PendingQty;
                            dr[7] = ItemRemarks.Text;
                            if (IsSelected.Checked)
                            {
                                dr[8] = 1;
                            }
                            else
                            {
                                dr[8] = 0;
                            }
                            dr[9] = SourceChildId.SelectedValue;
                            dr[10] = 0;
                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                        }
                    }
                }

            }
            ViewState["PurchaseOrderDetailSummary"] = dt;

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SavePurchaseOrderInfo()
    {
        try
        {
            var EmployeeID = Utility.GetCurrentSession().EmployeeID;
            ObjBOL.Operation = 2;//save new
            ObjBOL.EmployeeID = EmployeeID;
            ObjBOL.PONumber = txtPurchaseOrderNo.Text;
            ObjBOL.SourceID = ddlSource.SelectedValue;
            ObjBOL.PreparedBy = ddlPreparedby.SelectedValue;
            ObjBOL.PONumberID = Int32.Parse(ddlPurchaseOrder.SelectedValue);
            if (txtissuedate.Text != "")
            {
                ObjBOL.IssueDate = Utility.ConvertDate(txtissuedate.Text);
            }
            //CHECK IF PONumber EXISTS
            SaveGridData();
            DataTable selected = (DataTable)ViewState["PurchaseOrderDetailSummary"];
            DataView dv = new DataView(selected);
            DataTable summarytemp = dv.ToTable("selected", false, "Id", "ReqStatus", "PurchaseOrderId", "ReqDetailId", "PartId", "OrderQty", "ShipQty", "PendingQty", "Remarks", "IsSelected", "SourceChildId");
            ObjBOL.PurchaseOrderDetails = summarytemp;
            msg = ObjBLL.SavePurchaseOrderInfo(ObjBOL);
            if (msg != "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('PONUMBER EXISTS');", true);
                return;
            }
            else
            {
                ObjBOL.Operation = 3;

                msg = ObjBLL.SavePurchaseOrderInfo(ObjBOL);
                if (msg == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('DATA CANNOT BE INSERTED');", true);
                    return;
                }
                else
                {

                    ResetControls();
                    Bind_Controls(msg);
                    UpdateReqStatus();
                    AutoFillData();
                    //ResetBind_GridContainer();
                    Bind_GridChangeContainer();
                    Utility.ShowMessage(this, "Records Added Successfully !!!");
                }
            }
            btnSave.Text = "Update";
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void UpdatePurchaseOrderInfo()
    {
        try
        {
            var EmployeeID = Utility.GetCurrentSession().EmployeeID;
            ObjBOL.Operation = 11;
            ObjBOL.EmployeeID = EmployeeID;
            ObjBOL.PONumber = txtPurchaseOrderNo.Text;
            ObjBOL.SourceID = ddlSource.SelectedValue;
            ObjBOL.PreparedBy = ddlPreparedby.SelectedValue;
            ObjBOL.PONumberID = Int32.Parse(ddlPurchaseOrder.SelectedValue);
            if (txtissuedate.Text != "")
            {
                ObjBOL.IssueDate = Utility.ConvertDate(txtissuedate.Text);
            }
            //CHECK IF PONumber EXISTS and return its id
            SaveGridData();
            DataTable selected = (DataTable)ViewState["PurchaseOrderDetailSummary"];
            DataView dv = new DataView(selected);
            DataTable summarytemp = dv.ToTable("selected", false, "Id", "ReqStatus", "PurchaseOrderId", "ReqDetailId", "PartId", "OrderQty", "ShipQty", "PendingQty", "Remarks", "IsSelected", "SourceChildId");
            ObjBOL.PurchaseOrderDetails = summarytemp;
            msg = ObjBLL.SavePurchaseOrderInfo(ObjBOL);
            if (msg == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('DATA CANNOT BE UPDATED');", true);
                return;
            }
            else if (msg == "WORKING")
            {
                ObjBOL.Operation = 5;
                msg = ObjBLL.SavePurchaseOrderInfo(ObjBOL);
                if (msg == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('DATA CANNOT BE UPDATED');", true);
                    return;
                }
                else
                {

                    ResetControls();
                    Bind_Controls(msg);
                    UpdateReqStatus();
                    AutoFillData();
                    Bind_GridChangeContainer();
                    Utility.ShowMessage(this, "Records UPDATE Successfully !!!");
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('PO NUMBER EXISTS');", true);
            }
            btnSave.Text = "Update";
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void AutoFillData()
    {
        try
        {
            if (ddlPurchaseOrder.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 4;
                ObjBOL.PONumberID = Int32.Parse(msg);
                ds = ObjBLL.GetBindControl(ObjBOL);
                ddlPreparedby.SelectedIndex = 0;
                ddlSource.SelectedIndex = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtPurchaseOrderNo.Text = ds.Tables[0].Rows[0]["PONumber"].ToString();
                    txtissuedate.Text = ds.Tables[0].Rows[0]["IssueDate"].ToString();
                    ddlSource.SelectedValue = ds.Tables[0].Rows[0]["SourceID"].ToString();
                    ddlPreparedby.SelectedValue = ds.Tables[0].Rows[0]["PreparedBy"].ToString();
                }
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void ResetControls()
    {
        try
        {
            btnSave.Text = "Save";
            txtissuedate.Text = String.Empty;
            txtPurchaseOrderNo.Text = String.Empty;
            ddlSource.SelectedIndex = 0;
            ddlPurchaseOrder.SelectedIndex = 0;
            ddlPreparedby.SelectedIndex = 0;
            //ResetBind_GridContainer();
            Bind_GridContainer();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void ResetBind_GridContainer()
    {
        try
        {
            foreach (GridViewRow row in gvMainRequisitionDetail.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    GridView gvContainer = row.FindControl("gvContainer") as GridView;
                    foreach (GridViewRow rowChild in gvContainer.Rows)
                    {
                        CheckBox IsSelected = ((CheckBox)rowChild.FindControl("chkIsSelected"));
                        Label ReqDetailId = ((Label)rowChild.FindControl("lblReqDetailId") as Label);
                        TextBox ShippedQty = ((TextBox)rowChild.FindControl("txtShippingQty"));
                        IsSelected.Checked = false;
                    }

                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void UpdateReqStatus()
    {
        try
        {
            DataSet ds = new DataSet();
            foreach (GridViewRow row in gvMainRequisitionDetail.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    ObjBOL.Operation = 10;
                    string reqId = gvMainRequisitionDetail.DataKeys[row.RowIndex].Value.ToString();
                    ObjBOL.ReqId = Convert.ToInt32(reqId);
                    DropDownList ddlstatus = row.FindControl("ddlstatus") as DropDownList;
                    ObjBOL.ReqStatus = Convert.ToInt32(ddlstatus.SelectedValue);
                    ObjBLL.UpdateStatus(ObjBOL);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

}