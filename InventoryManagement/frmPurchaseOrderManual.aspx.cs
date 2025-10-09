using System;
using System.Data;
using BOLAERO;
using BLLAERO;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public partial class InventoryManagement_frmPurchaseOrderManual : System.Web.UI.Page
{
    BOLPurchaseOrder ObjBOL = new BOLPurchaseOrder();
    BLLPurchaseOrderManual ObjBLL = new BLLPurchaseOrderManual();
    commonclass1 cls = new commonclass1();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    string Do_Not_Reply = "[Please do not reply to this message. Replies to this message are routed to an unmonitored mailbox]";
    DataTable dt_DropdownData = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                if (!IsPostBack)
                {
                    Bind_Controls();
                    BindLookUpPO("");
                    BindReqParts();
                    BindGridReqInfoBySource();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    #region Bind Tables
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSource, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPreparedby, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindLookUpPO(string msg)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPurchaseOrder, ds.Tables[0]);
                if (msg != "")
                {
                    ddlPurchaseOrder.SelectedValue = msg;
                }
            }
            else
            {
                ddlPurchaseOrder.DataSource = "";
                ddlPurchaseOrder.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindReqNo(string PartID)
    {
        try
        {
            int count = 0;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 8;
            ObjBOL.PartId = Convert.ToInt32(PartID);
            ds = ObjBLL.GetBindControl(ObjBOL);
            count = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlReqNumber, ds.Tables[0]);
                if (count == 1)
                {
                    ddlReqNumber.SelectedValue = ds.Tables[0].Rows[0]["ReqID"].ToString();
                    if (ddlPartNo.SelectedIndex > 0 && ddlReqNumber.SelectedIndex > 0)
                    {
                        BindPartDetails(ddlPartNo.SelectedValue, ddlReqNumber.SelectedValue);
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindPartDetails(string PartID, string ReqID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 9;
            ObjBOL.PartId = Convert.ToInt32(PartID);
            ObjBOL.ReqId = Convert.ToInt32(ReqID);
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblReqOrderQty.Text = ds.Tables[0].Rows[0]["ReqQty"].ToString();
                lnkInTransit.Text = ds.Tables[0].Rows[0]["InStock"].ToString();
                lnkInTransit.Text = ds.Tables[0].Rows[0]["InTransit"].ToString();
                lblReqDetailID.Text = ds.Tables[0].Rows[0]["ReqDetailId"].ToString();
                lblReqNumber.Text = ds.Tables[0].Rows[0]["ReqNumber"].ToString();
                lblRequestor.Text = ds.Tables[0].Rows[0]["Requestor"].ToString();
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Priority"]) == true)
                {
                    chkPriority.Checked = true;
                }
                else
                {
                    chkPriority.Checked = false;
                }

            }
            else
            {
                ResetRequisitionTableOnReqNo();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Click Controls
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            ResetNewButton();
            ResetRequisitionTable();
            if (ddlPurchaseOrder.Items.Count > 0)
            {
                ddlPurchaseOrder.SelectedIndex = 0;
            }
            string msg = "";
            ObjBOL.Operation = 2;
            msg = ObjBLL.GetPurchaseOrderNumber(ObjBOL);
            if (msg != "")
            {
                txtPurchaseOrderNo.Text = msg;
                btnSave.Text = "Save";
                btnSave.Enabled = true;
                btnGenerate.Enabled = true;
                btnNotify.Enabled = false;
                btnSubmit.Enabled = false;
                btnGenerate.Enabled = false;
                BindGridReqInfoBySource();
            }
            else
            {
                txtPurchaseOrderNo.Text = String.Empty;
                ResetNewButton();
                ResetRequisitionTable();
                DisabledControls();
                BindGridReqInfoBySource();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                SaveData();
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
                AutoFillData();
                BindGridReqInfo();
                btnSave.Text = "Update";
                EnableControls();
            }
            else
            {
                btnSave.Text = "Save";
                ResetPOInformation();
                ResetRequisitionTable();
                DisabledControls();
                BindGridReqInfoBySource();
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
            ResetPOInformation();
            ResetRequisitionTable();
            DisabledControls();
            btnSave.Text = "Save";
            if (ddlPurchaseOrder.Items.Count > 0)
            {
                ddlPurchaseOrder.SelectedIndex = 0;
            }
            BindGridReqInfoBySource();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void UpdateStatusID()
    {
        try
        {
            ObjBOL.Operation = 14;
            ObjBOL.SourceID = ddlSource.SelectedValue;
            ObjBLL.GetBindControl(ObjBOL);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPartNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPartNo.SelectedIndex > 0)
            {
                BindReqNo(ddlPartNo.SelectedValue);
            }
            else
            {
                ResetRequisitionTableOnPartNo();
                ddlReqNumber.DataSource = "";
                ddlReqNumber.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //ddlReqNumber_SelectedIndexChanged
    protected void ddlReqNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPartNo.SelectedIndex > 0 && ddlReqNumber.SelectedIndex > 0)
            {
                BindPartDetails(ddlPartNo.SelectedValue, ddlReqNumber.SelectedValue);
            }
            else
            {
                ResetRequisitionTableOnReqNo();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                if (ValidationCheckPartDetails() == true)
                {
                    AddDetails();
                    ResetRequisitionTable();
                }

            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void lnkInTransit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlPartNo.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.PartId = Convert.ToInt32(ddlPartNo.SelectedValue);
                ObjBOL.Operation = 1;
                ds = ObjBLL.GetTransitionData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvInTransit.DataSource = ds.Tables[0];
                    gvInTransit.DataBind();
                    lblPartNumber.Text = ds.Tables[0].Rows[0]["Partnumber"].ToString();
                    ModalPopupExtender1.Show();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void btnNotify_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                SendEmail_Prepare(true);
            }

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
            SubmitPO();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Requisition Table
    private DataTable EmptyDTPurchaseOrder()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.TableName = "POSummary";
            dt.Columns.Add(new DataColumn("PurchaseOrderId", typeof(int)));
            dt.Columns.Add(new DataColumn("ReqID", typeof(int)));
            dt.Columns.Add(new DataColumn("ReqNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("ReqDetailID", typeof(int)));
            dt.Columns.Add(new DataColumn("Requestor", typeof(string)));
            dt.Columns.Add(new DataColumn("partid", typeof(int)));
            dt.Columns.Add(new DataColumn("PartNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("ReqQty", typeof(int)));
            dt.Columns.Add(new DataColumn("InStock", typeof(int)));
            dt.Columns.Add(new DataColumn("InTransit", typeof(int)));
            dt.Columns.Add(new DataColumn("InShop", typeof(int)));
            dt.Columns.Add(new DataColumn("POOrderQty", typeof(int)));
            dt.Columns.Add(new DataColumn("Priority", typeof(bool)));
            dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
            dt.Columns.Add(new DataColumn("StatusID", typeof(int)));
            ViewState["POSummary"] = dt;
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

            DataTable dt = EmptyDTPurchaseOrder();
            foreach (GridViewRow row in gvMainPartDetail.Rows)
            {
                DataRow dr;
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string Reqid = (row.FindControl("lblReqId") as Label).Text;
                    string PartId = gvMainPartDetail.DataKeys[row.RowIndex].Value.ToString();
                    string ReqDetailId = (row.FindControl("lblReqDetailId") as Label).Text;
                    string PartNo = (row.FindControl("lblPartNumber") as Label).Text;
                    GridView gvRequisitionInfo = row.FindControl("gvRequisitionInfo") as GridView;
                    foreach (GridViewRow PurchaseOrderrow in gvRequisitionInfo.Rows)
                    {
                        if (PurchaseOrderrow.RowType == DataControlRowType.DataRow)
                        {
                            dr = dt.NewRow();
                            Label PurchaseOrderReqid = ((Label)PurchaseOrderrow.FindControl("lblReqId"));
                            Label ReqNumber = ((Label)PurchaseOrderrow.FindControl("lblReqNumber"));
                            Label POReqDetailId = ((Label)PurchaseOrderrow.FindControl("lblReqDetailId"));
                            Label Partid = ((Label)PurchaseOrderrow.FindControl("lblItemPartid"));
                            Label lblRequestor = ((Label)PurchaseOrderrow.FindControl("lblGvRequestor"));
                            Label ReqQty = ((Label)PurchaseOrderrow.FindControl("lblReqQty"));
                            LinkButton InStock = ((LinkButton)PurchaseOrderrow.FindControl("lnkInTransit"));
                            LinkButton InTransit = ((LinkButton)PurchaseOrderrow.FindControl("lnkInTransit"));
                            LinkButton InShop = ((LinkButton)PurchaseOrderrow.FindControl("lnkInShop"));
                            TextBox POOrderQty = ((TextBox)PurchaseOrderrow.FindControl("txtPOOrderQty"));
                            CheckBox Priority = ((CheckBox)PurchaseOrderrow.FindControl("chkPriorityFooter"));
                            TextBox ItemRemarks = ((TextBox)PurchaseOrderrow.FindControl("txtItemRemarks"));
                            DropDownList ddlStatus = ((DropDownList)PurchaseOrderrow.FindControl("ddlReqStatus"));
                            Label StatusID = ((Label)PurchaseOrderrow.FindControl("lblStatusID"));
                            dr[0] = 0;
                            if (PurchaseOrderReqid.Text != "")
                            {
                                dr[1] = Convert.ToInt32(PurchaseOrderReqid.Text);
                            }
                            else
                            {
                                dr[1] = 0;
                            }
                            if (ReqNumber.Text != "")
                            {
                                dr[2] = ReqNumber.Text;
                            }
                            else
                            {
                                dr[2] = 0;
                            }
                            if (ReqDetailId != "")
                            {
                                dr[3] = POReqDetailId.Text;
                            }
                            else
                            {
                                dr[3] = 0;
                            }
                            dr[4] = lblRequestor.Text;
                            if (Partid.Text != "")
                            {
                                dr[5] = Partid.Text;
                            }
                            else
                            {
                                dr[5] = 0;
                            }
                            dr[6] = PartNo;
                            if (ReqQty.Text != "")
                            {
                                dr[7] = ReqQty.Text;
                            }
                            else
                            {
                                dr[7] = 0;
                            }
                            if (InStock.Text != "")
                            {
                                dr[8] = InStock.Text;
                            }
                            else
                            {
                                dr[8] = 0;
                            }
                            if (InTransit.Text != "")
                            {
                                dr[9] = InTransit.Text;
                            }
                            else
                            {
                                dr[9] = 0;
                            }
                            if (InShop.Text != "")
                            {
                                dr[10] = InShop.Text;
                            }
                            else
                            {
                                dr[10] = 0;
                            }
                            if (POOrderQty.Text != "")
                            {
                                dr[11] = POOrderQty.Text;
                            }
                            else
                            {
                                dr[11] = 0;
                            }
                            if (Priority.Checked == true)
                            {
                                dr[12] = Priority.Checked;
                            }
                            else
                            {
                                dr[12] = false;

                            }
                            dr[13] = ItemRemarks.Text;
                            if (ddlStatus.SelectedIndex > 0)
                            {
                                dr[14] = Convert.ToInt32(ddlStatus.SelectedValue);
                            }
                            else
                            {
                                dr[14] = 1;
                            }
                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                        }
                    }
                }

            }
            ViewState["POSummary"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void AddDetails()
    {
        try
        {
            SaveGridData();
            DataTable dt = (DataTable)ViewState["POSummary"];
            DataRow dr;
            dr = dt.NewRow();
            int PurchaseOrderID = 0;
            if (ddlPurchaseOrder.SelectedIndex > 0)
            {
                PurchaseOrderID = Convert.ToInt32(ddlPurchaseOrder.SelectedValue);
            }
            int Reqid = 0;
            if (ddlReqNumber.SelectedIndex > 0)
            {
                Reqid = Convert.ToInt32(ddlReqNumber.SelectedValue);
            }
            string ReqNumber = lblReqNumber.Text;
            int ReqDetailid = 0;
            if (lblReqDetailID.Text != "")
            {
                ReqDetailid = Convert.ToInt32(lblReqDetailID.Text);
            }
            int partid = 0;
            if (ddlPartNo.SelectedIndex > 0)
            {
                partid = Convert.ToInt32(ddlPartNo.SelectedValue);
            }
            string Requestor = "";
            if (lblRequestor.Text != "")
            {
                Requestor = lblRequestor.Text;
            }
            string PartNumber = ddlPartNo.SelectedItem.Text;
            int ReqQty = 0;
            if (lblReqOrderQty.Text != "")
            {
                ReqQty = Convert.ToInt32(lblReqOrderQty.Text);
            }
            int InStock = 0;
            if (lnkInStock.Text != "")
            {
                InStock = Convert.ToInt32(lnkInStock.Text);
            }
            int InTransit = 0;
            if (lnkInTransit.Text != "")
            {
                InTransit = Convert.ToInt32(lnkInTransit.Text);
            }
            int orderqty = 0;
            if (txtPOOrder.Text != "")
            {
                orderqty = Convert.ToInt32(txtPOOrder.Text);
            }
            bool priority = false;
            if (chkPriority.Checked == true)
            {
                priority = chkPriority.Checked;
            }
            string remarks = "";
            if (txtRemarks.Text != "")
            {
                remarks = txtRemarks.Text;
            }
            PrepareDT(PurchaseOrderID, ReqNumber, Reqid, ReqDetailid, partid, Requestor, PartNumber, ReqQty, InStock, InTransit, orderqty, priority, remarks);

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void PrepareDT(int PurchaseOrderID, string ReqNumber, int Reqid, int ReqDetailid, int partid, string Requestor, string PartNumber, int ReqQty, int InStock, int InTransit, int orderqty, bool priority, string remarks)
    {
        try
        {
            DataTable dtCurrentTable = (DataTable)ViewState["POSummary"];
            DataRow drCurrentRow = null;
            drCurrentRow = dtCurrentTable.NewRow();
            drCurrentRow["PurchaseOrderId"] = PurchaseOrderID;
            drCurrentRow["ReqNumber"] = ReqNumber;
            drCurrentRow["ReqID"] = Reqid;
            drCurrentRow["ReqDetailID"] = ReqDetailid;
            drCurrentRow["partid"] = partid;
            drCurrentRow["Requestor"] = Requestor;
            drCurrentRow["PartNumber"] = PartNumber;
            drCurrentRow["ReqQty"] = ReqQty;
            drCurrentRow["InStock"] = InStock;
            drCurrentRow["InTransit"] = InTransit;
            drCurrentRow["POOrderQty"] = orderqty;
            drCurrentRow["Priority"] = priority;
            drCurrentRow["remarks"] = remarks;
            for (int i = dtCurrentTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtCurrentTable.Rows[i];
                int qty1 = Convert.ToInt32(orderqty);
                int qty2 = Convert.ToInt32(dr["POOrderQty"].ToString());
                if (dr["ReqID"].ToString() == Convert.ToString(Reqid) && dr["Partid"].ToString() == Convert.ToString(partid))
                {
                    drCurrentRow["POOrderQty"] = qty1 + qty2;
                    dr.Delete();
                }
            }
            if (drCurrentRow["Partid"].ToString() == "")
            {
                drCurrentRow.Delete();
            }
            dtCurrentTable.AcceptChanges();
            dtCurrentTable.Rows.Add(drCurrentRow);
            dtCurrentTable.DefaultView.Sort = "ReqNumber ASC";
            DataTable dt = (DataTable)ViewState["POSummary"];
            BindSummaryTemp(dt);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void BindSummaryTemp(DataTable dt)
    {
        try
        {
            DataTable DTSummary = dt;
            DataTable dtMainTable = new DataTable();
            dtMainTable.TableName = "MainSummary";
            dtMainTable.Columns.Add(new DataColumn("ReqID", typeof(int)));
            dtMainTable.Columns.Add(new DataColumn("ReqDetailId", typeof(int)));
            dtMainTable.Columns.Add(new DataColumn("partid", typeof(int)));
            dtMainTable.Columns.Add(new DataColumn("PartNumber", typeof(string)));
            DataRow drMainRow = null;
            foreach (DataRow dtMainRow in DTSummary.Rows)
            {
                drMainRow = dtMainTable.NewRow();
                drMainRow["ReqID"] = dtMainRow["ReqID"].ToString();
                drMainRow["ReqDetailId"] = dtMainRow["ReqDetailId"].ToString();
                drMainRow["partid"] = dtMainRow["partid"].ToString();
                drMainRow["PartNumber"] = dtMainRow["PartNumber"].ToString();
                dtMainTable.AcceptChanges();
                dtMainTable.Rows.Add(drMainRow);
            }
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            foreach (DataRow drow in dtMainTable.Rows)
            {
                if (hTable.Contains(drow["Partid"]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow["Partid"], string.Empty);
            }

            foreach (DataRow dRow in duplicateList)
                dtMainTable.Rows.Remove(dRow);

            if (dtMainTable.Rows.Count > 0)
            {
                gvMainPartDetail.DataSource = dtMainTable;
                gvMainPartDetail.DataBind();
                foreach (GridViewRow row in gvMainPartDetail.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        string partid = gvMainPartDetail.DataKeys[row.RowIndex].Value.ToString();
                        GridView gvRequisitionInfo = row.FindControl("gvRequisitionInfo") as GridView;
                        DataTable updatedSummary = new DataTable();
                        updatedSummary.TableName = "ChildSummary";
                        updatedSummary.Columns.Add(new DataColumn("PurchaseOrderId", typeof(int)));
                        updatedSummary.Columns.Add(new DataColumn("ReqID", typeof(int)));
                        updatedSummary.Columns.Add(new DataColumn("ReqDetailID", typeof(int)));
                        updatedSummary.Columns.Add(new DataColumn("Requestor", typeof(string)));
                        updatedSummary.Columns.Add(new DataColumn("partid", typeof(int)));
                        updatedSummary.Columns.Add(new DataColumn("ReqNumber", typeof(string)));
                        updatedSummary.Columns.Add(new DataColumn("PartNumber", typeof(string)));
                        updatedSummary.Columns.Add(new DataColumn("ReqQty", typeof(int)));
                        updatedSummary.Columns.Add(new DataColumn("InStock", typeof(int)));
                        updatedSummary.Columns.Add(new DataColumn("InTransit", typeof(int)));
                        updatedSummary.Columns.Add(new DataColumn("POOrderQty", typeof(int)));
                        updatedSummary.Columns.Add(new DataColumn("Priority", typeof(bool)));
                        updatedSummary.Columns.Add(new DataColumn("Remarks", typeof(string)));
                        DataRow dr = null;
                        foreach (DataRow dtRow in DTSummary.Rows)
                        {
                            if (dtRow["partid"].ToString() == partid)
                            {
                                dr = updatedSummary.NewRow();
                                dr["PurchaseOrderId"] = dtRow["PurchaseOrderId"].ToString();
                                dr["ReqID"] = dtRow["ReqID"].ToString();
                                dr["ReqDetailID"] = dtRow["ReqDetailID"].ToString();
                                dr["Requestor"] = dtRow["Requestor"].ToString();
                                dr["partid"] = dtRow["partid"].ToString();
                                dr["ReqNumber"] = dtRow["ReqNumber"].ToString();
                                dr["PartNumber"] = dtRow["PartNumber"].ToString();
                                dr["ReqQty"] = dtRow["ReqQty"].ToString();
                                dr["InStock"] = dtRow["InStock"].ToString();
                                dr["InTransit"] = dtRow["InTransit"].ToString();
                                dr["POOrderQty"] = dtRow["POOrderQty"].ToString();
                                dr["Priority"] = dtRow["Priority"].ToString();
                                dr["Remarks"] = dtRow["Remarks"].ToString();
                                updatedSummary.AcceptChanges();
                                updatedSummary.Rows.Add(dr);
                                updatedSummary.DefaultView.Sort = "ReqNumber ASC";
                                gvRequisitionInfo.DataSource = updatedSummary;
                                gvRequisitionInfo.DataBind();
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

    #endregion

    #region Reset Section
    private void EnableControls()
    {
        try
        {
            btnSave.Enabled = true;
            btnGenerate.Enabled = true;
            btnNotify.Enabled = true;
            btnSubmit.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void DisabledControls()
    {
        try
        {
            btnSave.Enabled = false;
            btnGenerate.Enabled = false;
            btnNotify.Enabled = false;
            btnSubmit.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void ResetPOInformation()
    {
        try
        {
            txtPurchaseOrderNo.Text = String.Empty;
            ddlSource.SelectedIndex = 0;
            ddlPreparedby.SelectedIndex = 0;
            txtIssueDate.Text = String.Empty;
            ddlStatus.SelectedIndex = 0;
            txtPORemarks.Text = String.Empty;
            if (ddlWareHouse.Items.Count > 0)
            {
                ddlWareHouse.Items.Clear();
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void ResetPOInformationandDetail()
    {
        try
        {
            ddlPreparedby.SelectedIndex = 0;
            txtIssueDate.Text = String.Empty;
            ddlStatus.SelectedIndex = 0;
            txtPORemarks.Text = String.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void ResetNewButton()
    {
        try
        {
            ddlSource.SelectedIndex = 0;
            if (ddlWareHouse.Items.Count > 0)
            {
                ddlWareHouse.Items.Clear();
            }
            ddlPreparedby.SelectedIndex = 0;
            txtIssueDate.Text = String.Empty;
            ddlStatus.SelectedIndex = 0;
            txtPORemarks.Text = String.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_GridBySource()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 13;
            ObjBOL.SourceID = ddlSource.SelectedValue;
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvMainPartDetail.DataSource = ds.Tables[0];
                gvMainPartDetail.DataBind();
            }
            else
            {
                gvMainPartDetail.DataSource = "";
                gvMainPartDetail.DataBind();
            }
        }

        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindGridReqInfoBySource()
    {
        try
        {
            DataSet ds = new DataSet();
            Bind_GridBySource();
            foreach (GridViewRow row in gvMainPartDetail.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string partid = gvMainPartDetail.DataKeys[row.RowIndex].Value.ToString();
                    GridView gvChild = row.FindControl("gvRequisitionInfo") as GridView;
                    ObjBOL.PartId = Convert.ToInt32(partid);
                    ObjBOL.SourceID = ddlSource.SelectedValue;
                    ObjBOL.Operation = 13;
                    ds = ObjBLL.GetBindControl(ObjBOL);
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        gvChild.DataSource = ds.Tables[1];
                        gvChild.DataBind();
                    }
                    else
                    {
                        gvChild.DataSource = "";
                        gvChild.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetRequisitionTable()
    {
        try
        {
            if (ddlPartNo.Items.Count > 0)
            {
                ddlPartNo.SelectedIndex = 0;
            }
            if (ddlReqNumber.Items.Count > 0)
            {
                ddlReqNumber.Items.Clear();
            }
            ResetRequisitionTableOnReqNo();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetRequisitionTableOnPartNo()
    {
        try
        {
            if (ddlReqNumber.Items.Count > 0)
            {
                ddlReqNumber.Items.Clear();
            }
            ResetRequisitionTableOnReqNo();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetRequisitionTableOnReqNo()
    {
        try
        {
            lblReqOrderQty.Text = String.Empty;
            lblRequestor.Text = String.Empty;
            lnkInStock.Text = String.Empty;
            lnkInTransit.Text = String.Empty;
            txtPOOrder.Text = String.Empty;
            chkPriority.Checked = false;
            txtRemarks.Text = String.Empty;
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
            gvMainPartDetail.DataSource = "";
            gvMainPartDetail.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Gv Index Changes
    protected void gvRequisitionInfo_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatusID = (Label)e.Row.FindControl("lblStatusID");
                TextBox txtOrderQty = (TextBox)e.Row.FindControl("txtPOOrderQty");
                CheckBox chkPriority = (CheckBox)e.Row.FindControl("chkPriorityFooter");
                TextBox txtRemarks = (TextBox)e.Row.FindControl("txtItemRemarks");
                LinkButton lnkInTransit = (LinkButton)e.Row.FindControl("lnkInTransit");
                LinkButton lnkInShop = (LinkButton)e.Row.FindControl("lnkInShop");
                DropDownList ddlReqStatus = (DropDownList)e.Row.FindControl("ddlReqStatus");
                if (lnkInTransit != null)
                {
                    if (lnkInTransit.Text == "0")
                    {
                        lnkInTransit.Attributes.Remove("href");
                        if (lnkInTransit.Enabled != false)
                        {
                            lnkInTransit.Enabled = false;
                        }
                    }
                }
                if (lnkInShop != null)
                {
                    if (lnkInShop.Text == "0")
                    {
                        lnkInShop.Attributes.Remove("href");
                        if (lnkInShop.Enabled != false)
                        {
                            lnkInShop.Enabled = false;
                        }
                    }
                }
                if (lblStatusID.Text == "2")
                {
                    txtOrderQty.Enabled = false;
                    chkPriority.Enabled = false;
                    txtRemarks.Enabled = false;
                    ddlReqStatus.Enabled = false;

                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvRequisitionInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Select")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblID = (Label)clickedRow.FindControl("lblItemPartid");
                LinkButton lnkTranstit = (LinkButton)clickedRow.FindControl("lnkInTransit");
                if (lnkTranstit.Text == "0")
                {
                    return;
                }
                hfpartid.Value = Convert.ToString(lblID.Text);
                ObjBOL.PartId = Convert.ToInt32(hfpartid.Value);
                ObjBOL.Operation = 1;
                ds = ObjBLL.GetTransitionData(ObjBOL);
                gvInTransit.DataSource = ds.Tables[0];
                gvInTransit.DataBind();
                lblPartNumber.Text = ds.Tables[0].Rows[0]["Partnumber"].ToString();
                ModalPopupExtender1.Show();
            }
            if (e.CommandName == "Select2")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblID = (Label)clickedRow.FindControl("lblItemPartid");
                LinkButton lnShop = (LinkButton)clickedRow.FindControl("lnkInShop");
                if (lnShop.Text == "0")
                {
                    return;
                }
                ObjBOL.PartId = Convert.ToInt32(lblID.Text);
                ObjBOL.Operation = 1;
                ds = ObjBLL.GetInShopData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvInShop.DataSource = ds.Tables[0];
                    gvInShop.DataBind();
                    lblInShopPartNumber.Text = ds.Tables[0].Rows[0]["Partnumber"].ToString();
                    ModalPopupExtender2.Show();
                }
            }
            if (e.CommandName == "InStock")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblID = (Label)clickedRow.FindControl("lblItemPartid");
                LinkButton InStock = (LinkButton)clickedRow.FindControl("lnkInStock");
                if (InStock.Text == "0")
                {
                    return;
                }
                ObjBOL.PartId = Convert.ToInt32(lblID.Text);
                ObjBOL.Operation = 1;
                ds = ObjBLL.GetInStockData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvInsTock.DataSource = ds.Tables[1];
                    gvInsTock.DataBind();
                    lblInStockPartNumber.Text = ds.Tables[0].Rows[0]["PartNumber"].ToString();
                    ModalPopupExtender3.Show();
                }
            }
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
            ObjBOL.Operation = 15;
            ObjBOL.SourceID = ddlSource.SelectedValue;
            ObjBOL.PONumberID = Convert.ToInt32(ddlPurchaseOrder.SelectedValue);
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvMainPartDetail.DataSource = ds.Tables[0];
                gvMainPartDetail.DataBind();
            }
            else
            {
                gvMainPartDetail.DataSource = "";
                gvMainPartDetail.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindGridReqInfo()
    {
        try
        {
            DataSet ds = new DataSet();
            Bind_Grid();
            foreach (GridViewRow row in gvMainPartDetail.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string partid = gvMainPartDetail.DataKeys[row.RowIndex].Value.ToString();
                    GridView gvChild = row.FindControl("gvRequisitionInfo") as GridView;
                    ObjBOL.PONumberID = Convert.ToInt32(ddlPurchaseOrder.SelectedValue);
                    ObjBOL.SourceID = ddlSource.SelectedValue;
                    ObjBOL.PartId = Convert.ToInt32(partid);
                    ObjBOL.Operation = 11;
                    ds = ObjBLL.GetBindControl(ObjBOL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvChild.DataSource = ds.Tables[0];
                        gvChild.DataBind();
                    }
                    else
                    {
                        gvChild.DataSource = "";
                        gvChild.DataBind();
                    }

                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Requisition Table
    private void BindReqParts()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 6;
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartNo, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Save Data
    private void SaveData()
    {
        try
        {
            string msg = "";
            if (ddlPurchaseOrder.SelectedIndex > 0)
            {
                ObjBOL.PONumberID = Convert.ToInt32(ddlPurchaseOrder.SelectedValue);
                ObjBOL.Operation = 16;
            }
            else
            {
                ObjBOL.Operation = 3;
            }
            ObjBOL.EmployeeID = Utility.GetCurrentSession().EmployeeID;
            ObjBOL.PONumber = txtPurchaseOrderNo.Text;
            ObjBOL.SourceID = ddlSource.SelectedValue;
            ObjBOL.PreparedBy = ddlPreparedby.SelectedValue;
            if (txtIssueDate.Text != "")
            {
                ObjBOL.IssueDate = Utility.ConvertDateFormat(txtIssueDate.Text);
            }
            ObjBOL.WareHouseID = Convert.ToInt32(ddlWareHouse.SelectedValue);
            ObjBOL.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            ObjBOL.PORemarks = txtPORemarks.Text;
            SaveGridData();
            DataTable selected = (DataTable)ViewState["POSummary"];
            DataView dv = new DataView(selected);
            DataTable summarytemp = dv.ToTable("selected", false, "ReqID", "ReqDetailID", "Partid", "ReqQty", "POOrderQty", "Priority", "Remarks", "StatusID");
            ObjBOL.PurchaseOrderDetails = summarytemp;
            msg = ObjBLL.SavePurchaseOrderInfoAndDetail(ObjBOL);
            if (msg == "2627")
            {
                Utility.ShowMessage_Error(Page, "PO Duplicate !!");
            }
            else
            {
                if (msg != "PO Updated Successfully !!")
                {
                    BindLookUpPO(msg);
                    Utility.ShowMessage_Success(Page, "PO Added Successfully !!");
                }
                else
                {
                    Utility.ShowMessage_Success(Page, msg);

                }

                if (ddlStatus.SelectedValue == "2")
                {
                    ResetPOInformationandDetail();
                    ResetPOInformation();
                    BindGridReqInfoBySource();
                    BindLookUpPO("");
                    DisabledControls();
                    btnSave.Text = "Save";
                }
                else
                {
                    btnSave.Text = "Update";
                    EnableControls();
                    BindGridReqInfo();
                }
            }

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
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ObjBOL.PONumberID = Convert.ToInt32(ddlPurchaseOrder.SelectedValue);
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPurchaseOrderNo.Text = ds.Tables[0].Rows[0]["PONumber"].ToString();
                ddlSource.SelectedValue = ds.Tables[0].Rows[0]["SourceId"].ToString();
                if (ddlSource.Items.FindByValue(ds.Tables[0].Rows[0]["SourceId"].ToString()) != null)
                {
                    BindDestWareHouse(ddlSource.SelectedValue);
                }
                ddlPreparedby.SelectedValue = ds.Tables[0].Rows[0]["PreparedBy"].ToString();
                txtIssueDate.Text = ds.Tables[0].Rows[0]["IssueDate"].ToString();
                ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
                if (ddlWareHouse.Items.FindByValue(ds.Tables[0].Rows[0]["WareHouseID"].ToString()) != null)
                {
                    ddlWareHouse.SelectedValue = ds.Tables[0].Rows[0]["WareHouseID"].ToString();
                }
                txtPORemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region validation
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtPurchaseOrderNo.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Generate Purchase Order No#. !');", true);
                Utility.ShowMessage_Error(Page, "Please Generate Purchase Order No#. !");
                txtPurchaseOrderNo.Focus();
                return false;
            }
            if (ddlSource.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Vendor. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Source Warehouse !");
                ddlSource.Focus();
                return false;
            }
            if (ddlWareHouse.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Destination Warehouse !");
                ddlWareHouse.Focus();
                return false;
            }
            if (txtIssueDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Insert Issue Date !');", true);
                Utility.ShowMessage_Error(Page, "Please Insert Issue Date !");
                txtIssueDate.Focus();
                return false;
            }
            if (ddlStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Status !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Status !");
                ddlStatus.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private Boolean ValidationCheckPartDetails()
    {
        try
        {
            if (ddlPartNo.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Part#. !");
                ddlPartNo.Focus();
                return false;
            }

            if (ddlReqNumber.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Req Order Quantity. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Req Number. !");
                ddlReqNumber.Focus();
                return false;
            }

            if (txtPOOrder.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Order Quantity. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter PO Quantity. !");
                txtPOOrder.Focus();
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

    #region Report
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToPdf();
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
    }
    private DataTable ReportDataZero()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [IV].[Inv_GeneratePurchaseOrder] '" + ddlPurchaseOrder.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    #endregion

    private void SendEmail_Prepare(bool NotifyOnly)
    {
        try
        {
            if (Utility.InventoryEmailSwitch())
            {
                string vendor = string.Empty;
                string destination = string.Empty;
                string preparedBy = string.Empty;
                string status = string.Empty;
                string issueDateString = string.Empty;

                DateTime issueDate;
                if (DateTime.TryParse(txtIssueDate.Text, out issueDate))
                {
                    issueDateString = issueDate.ToString("MMMM dd, yyyy");
                }

                if (ddlSource.SelectedItem.Text.Trim().ToLower() != "select")
                {
                    vendor = ddlSource.SelectedItem.Text;
                }

                if (ddlWareHouse.SelectedItem.Text.Trim().ToLower() != "select")
                {
                    destination = ddlWareHouse.SelectedItem.Text;
                }

                if (ddlPreparedby.SelectedItem.Text.Trim().ToLower() != "select")
                {
                    preparedBy = ddlPreparedby.SelectedItem.Text;
                }

                if (ddlStatus.SelectedItem.Text.Trim().ToLower() != "select")
                {
                    status = ddlStatus.SelectedItem.Text;
                }

                string Message = string.Empty;
                Message += "<!doctype><html lang='en'><head><meta charset = 'utf-8'><meta name = 'viewport' content = 'width=device-width, initial-scale=1'> ";
                Message += " <title> Purchase Order List </title></head><body><table cellpadding='0' cellspacing='0' style='border-collapse:collapse;width:100%;font-family:Calibri;font-size:1.15rem'> ";
                Message += " <tr><td><table border='1' cellpadding='8' cellspacing='0' style='border-collapse:collapse;width:100%;max-width:580px;margin:0 auto;border-color:#ddd'> ";
                Message += " <tr><td colspan='2'><h2 style='margin:0;font-size:1.15rem'> Kishore,</h2> ";
                Message += " <p style = 'margin-top:5px'>Attached you will find the <strong>" + txtPurchaseOrderNo.Text + "</strong>.<br/>";
                if (NotifyOnly)
                {
                    Message += " Please review and let us know by <strong>" + Utility.AddBusinessDays(DateTime.Now, 3).ToString("MMMM dd, yyyy") + "</strong> if you wish to make any changes</p> ";
                }
                Message += " </td ></tr><tr><td colspan='2'><div style = 'width:80px;margin:0 auto'> ";
                Message += " <svg version='1.1' xmlns:xlink='http://www.w3.org/1999/xlink' id = 'Capa_1' enable-background='new 0 0 512 512' viewBox='0 0 512 512' style='width:100%;height:100%;' xmlns='http://www.w3.org/2000/svg'><g><g><g><path d='m369.4 76.49v401.05c0 3.26-.45 6.41-1.3 9.4-4.09 14.46-17.39 25.06-33.16 25.06h-239.78c-19.03 0-34.45-15.43-34.45-34.46v-401.05c0-19.03 15.42-34.46 34.45-34.46h239.78c19.03 0 34.46 15.43 34.46 34.46z' fill = '#a1412b' /><path d = 'm132.73 394.716v60.854c0 17.33 14.04 31.37 31.37 31.37h204c.85-2.99 1.3-6.14 1.3-9.4v-82.824z' fill = '#7f392c' /><path d = 'm334.941 42.034h-239.78c-19.031 0-34.455 15.424-34.455 34.455v401.053c0 19.031 15.424 34.455 34.455 34.455h239.781c19.031 0 34.455-15.424 34.455-34.455v-401.053c-.001-19.031-15.424-34.455-34.456-34.455zm-2.143 433.365h-235.494v-396.767h235.494z' fill= '#db765a' /> ";
                Message += " <path d = 'm369.4 394.72v82.82c0 3.26-.45 6.41-1.3 9.4h-204c-9.8 0-18.56-4.49-24.31-11.54h193.01v-80.68z' fill='#b55434' /><path d = 'm95.161 42.034c-19.029 0-34.455 15.426-34.455 34.455v219.149c0 10.106 8.193 18.299 18.299 18.299 10.106 0 18.299-8.193 18.299-18.299v-217.006h41.798c10.106 0 18.299-8.193 18.299-18.299 0-10.106-8.193-18.299-18.299-18.299z' fill='#f2886b' /><path d = 'm97.304 223.144v-82.649c0-10.106-8.193-18.299-18.299-18.299-10.106 0-18.299 8.193-18.299 18.299v82.649c0 10.106 8.193 18.299 18.299 18.299 10.106 0 18.299-8.193 18.299-18.299z' fill='#f79a7c' /></g><g><path d = 'm289.014 246.714v204.031h-124.915c-17.325 0-31.37-14.045-31.37-31.37v-162.204c0-5.775 4.682-10.457 10.457-10.457z' fill='#d8d4c9' /><path d='m289.01 246.71v204.04h-124.91c-11.88 0-22.22-6.6-27.54-16.34 26.46-35.27 42.13-79.09 42.13-126.57 0-21.26-3.14-41.78-8.99-61.13z' fill='#b5b1a4' /><path d='m195.728 419.376v-408.919c0-5.775 4.682-10.457 10.457-10.457h234.652c5.775 0 10.457 4.682 10.457 10.457v408.919c0 17.325-14.045 31.37-31.37 31.37h-255.565c17.325 0 31.369-14.045 31.369-31.37z' fill='#f1eee0' /><path d='m213.1 252.167c-9.593 0-17.37-7.777-17.37-17.37v-175.393c0-9.593 7.777-17.37 17.37-17.37 9.593 0 17.37 7.777 17.37 17.37v175.392c.001 9.594-7.776 17.371-17.37 17.371z' fill='#f9f8f2' /> ";
                Message += " <path d = 'm451.29 10.46v408.92c0 17.32-14.04 31.37-31.37 31.37h-99.7c62.77-106.75 98.77-231.12 98.77-363.91 0-29.39-1.76-58.37-5.19-86.84h27.04c5.77 0 10.45 4.68 10.45 10.46z' fill='#e8e4d8' /><path d='m195.73 344.78h255.56v21.67h-255.56z' fill='#ffc751' /><path d='m327.904 344.78h-93.578c-5.984 0-10.835 4.851-10.835 10.835 0 5.984 4.851 10.835 10.835 10.835h93.578c5.984 0 10.835-4.851 10.835-10.835 0-5.984-4.851-10.835-10.835-10.835z' fill='#ffe059' /> ";
                Message += " <path d = 'm451.29 10.46v70.63h-255.56v-70.63c0-5.78 4.68-10.46 10.46-10.46h234.65c5.77 0 10.45 4.68 10.45 10.46z' fill='#ffc751' /> ";
                Message += " <path d = 'm451.29 10.46v70.63h-32.32c-.22-27.42-1.96-54.48-5.17-81.09h27.04c5.77 0 10.45 4.68 10.45 10.46z' fill='#ffaf40' /></g></g><g><g> ";
                Message += " <g fill = '#8f8b81'><path d = 'm251.009 132.32h-18.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h18.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /> ";
                Message += " <path d = 'm306.009 160.899h-73.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h73.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /></g></g><g><g> ";
                Message += " <path d = 'm421.837 139.355c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889s5.793-5.194 8.957-7.278z' fill='#ffaf40' /></g></g></g><g><g> ";
                Message += " <g fill = '#8f8b81'><path d='m251.009 208.021h-18.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h18.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /> ";
                Message += " <path d = 'm306.009 236.6h-73.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h73.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /></g></g><g><g> ";
                Message += " <path d = 'm421.837 215.056c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889 2.789-2.769 5.793-5.194 8.957-7.278z' fill='#ffaf40' /></g></g></g><g><g><g> ";
                Message += " <path d = 'm251.009 283.722h-18.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h18.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' fill='#8f8b81' /> ";
                Message += " <path d = 'm306.009 312.301h-73.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h73.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' fill='#8f8b81' /><g fill='#b5b1a4'> ";
                Message += " <path d = 'm259.14 294.383h-16.15c-4.948 0-8.959 4.011-8.959 8.959 0 4.948 4.011 8.959 8.959 8.959h16.149c4.948 0 8.959-4.011 8.959-8.959.001-4.948-4.01-8.959-8.958-8.959z' /> ";
                Message += " <path d = 'm259.14 218.682h-16.15c-4.948 0-8.959 4.011-8.959 8.959 0 4.948 4.011 8.959 8.959 8.959h16.149c4.948 0 8.959-4.011 8.959-8.959.001-4.948-4.01-8.959-8.958-8.959z' /> ";
                Message += " <path d = 'm259.14 142.981h-16.15c-4.948 0-8.959 4.011-8.959 8.959 0 4.948 4.011 8.959 8.959 8.959h16.149c4.948 0 8.959-4.011 8.959-8.959.001-4.948-4.01-8.959-8.958-8.959z' /></g> ";
                Message += " <path d = 'm351.009 418.538h-118.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h118.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' fill='#8f8b81' /> ";
                Message += " <path d = 'm281.558 409.579c0 4.948 4.011 8.959 8.959 8.959h28.472c4.948 0 8.959-4.011 8.959-8.959 0-4.948-4.011-8.959-8.959-8.959h-28.472c-4.948.001-8.959 4.012-8.959 8.959z' fill = '#b5b1a4' /></g></g><g><g> ";
                Message += " <path d = 'm421.837 290.757c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889s5.793-5.194 8.957-7.278z' fill='#229bff' /></g></g><g><g> ";
                Message += " <path d= 'm421.837 410.49c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889s5.793-5.194 8.957-7.278z' fill='#229bff' /></g></g></g> ";
                Message += " <path d = 'm375.049 58.537h-103.076c-5.523 0-10-4.477-10-10v-18.822c0-5.523 4.477-10 10-10h103.076c5.523 0 10 4.477 10 10v18.822c0 5.523-4.477 10-10 10z' fill='#f1eee0' /> ";
                Message += " <path d = 'm451.29 344.78v21.67h-88.71c3.04-7.16 5.95-14.39 8.75-21.67z' fill='#ffaf40' /> ";
                Message += " <path d = 'm230.47 59.4v21.69h-34.74v-21.69c0-9.59 7.78-17.37 17.37-17.37 4.8 0 9.14 1.95 12.28 5.09s5.09 7.48 5.09 12.28z' fill='#ffe059' /></g></svg></div> ";
                Message += " <h1 style ='font-size:1.65rem;margin:.3rem 0 0;color:#000;text-align:center'>Purchase Order List</h1> ";
                Message += " </td></tr><tr><td style='width:1%;white-space:nowrap'>PO#</td><td style='font-weight:600;width:99%'>" + txtPurchaseOrderNo.Text + " </td></tr>";
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'>Vendor</td><td style='font-weight:600;width:99%'> " + vendor + "</td></tr>";
                Message += " <tr><td style='width:1%;white-space:nowrap'> Destination </td><td style='font-weight:600;width:99%'>" + destination + "</td></tr>";
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Prepared By </td><td style='font-weight:600;width:99%' > " + preparedBy + "</td></tr> ";
                Message += " <tr><td style='width:1%;white-space:nowrap'> Issue Date </td><td style='font-weight:600;width:99%'> " + issueDateString + "</td></tr>";
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> PO Status </td><td style='font-weight:600;width:99%' > " + status + "</td></tr> ";
                if (!NotifyOnly)
                {
                    Message += " <tr><td style='width:1%;white-space:nowrap'> Submitted By </td><td style='font-weight:600;width:99%'> " + Utility.GetCurrentSession().EmployeeName + "</td></tr>";
                    Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Submitted Date / Time </td><td style='font-weight:600;width:99%' > " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt") + "</td></tr> ";
                }
                Message += " <tr><td colspan = '2'>If you have any questions or concerns regarding your requisition, please contact the purchasing department. <br /><br /> ";
                Message += " Thanks, <br/ > <strong> " + Utility.EmailDisplayName() + " </strong> <br /> ";
                Message += " </td></tr></table></td></tr></table></body></html> ";
                List<MailAddress> sendToList = new List<MailAddress>();
                List<MailAddress> ccList = new List<MailAddress>();
                HashSet<MailAddress> sendToListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "SendToList", Utility.emailDictionaryInventory, "Purchasing", 1, "P", "");
                HashSet<MailAddress> ccListAsList = new HashSet<MailAddress>();
                ccListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "ccList", Utility.emailDictionaryInventory, "", 2, "P", "");
                sendToList = sendToListAsList.ToList();
                ccList = ccListAsList.ToList();
                Send_Email(Message, "Purchase Order List (" + txtPurchaseOrderNo.Text + ")", sendToList, ccList);
                sendToListAsList.Clear();
                ccListAsList.Clear();
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Email disabled !");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Send_Email(String Message, String Subject, List<MailAddress> sendToList, List<MailAddress> ccList)
    {
        try
        {
            if (sendToList.Count > 0)
            {
                MailMessage message = new MailMessage(new MailAddress(Utility.Email(), Utility.EmailDisplayName()), sendToList[0]);
                string mailbody = Message;
                message.Subject = Subject;
                message.Body = mailbody;
                Attachment file = new Attachment(GetPurchaseOrderReportStream(), "Purchase Order List" + "(" + txtPurchaseOrderNo.Text + ")" + ".pdf", "application/pdf");
                message.Attachments.Add(file);

                foreach (var sendto in sendToList)
                {
                    if (!message.To.Contains(sendto))
                    {
                        message.To.Add(sendto);
                    }
                }
                foreach (var cc in ccList)
                {
                    if (!message.CC.Contains(cc))
                    {
                        message.CC.Add(cc);
                    }

                }
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                // SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp
                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["Host"], 587);
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromMail"], ConfigurationManager.AppSettings["Password"]);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                client.Send(message);
                Message = string.Empty;
                Utility.ShowMessage_Success(Page, "Email Sent Successfully!!");
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool PrepareReport()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataZero();
            rprt.Load(Server.MapPath("~/Reports/rptPurchaseOrderManual.rpt"));
            if (dt.Rows.Count > 0)
            {
                rprt.SetDataSource(dt);
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void ExportToPdf()
    {
        try
        {
            bool check = PrepareReport();
            if (!check)
            {
                Utility.ShowMessage_Error(Page, "No Matching Data found !");
                return;
            }
            else
            {
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, ddlPurchaseOrder.SelectedItem.Text);
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

    private Stream GetPurchaseOrderReportStream()
    {
        Stream reportStream = null;
        try
        {
            PrepareReport();
            reportStream = (Stream)rprt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            if (rprt != null)
            {
                rprt.Close();
                rprt.Dispose();
            }
        }
        return reportStream;
    }

    //btnReport_Click
    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {
            string url = ResolveUrl("~/Reports/frmPOReport.aspx");            
            string script = "var a = document.createElement('a');" +
                "a.href = '" + url + "';" +
                "a.target = '_blank';" +
                "a.rel = 'noopener';" +
                "document.body.appendChild(a);" +
                "a.click();" +
                "document.body.removeChild(a);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "openTab", script, true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SubmitPO()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                int purchaseOrderID = Int32.Parse(ddlPurchaseOrder.SelectedValue);
                if (purchaseOrderID > 0)
                {
                    ObjBOL.PONumberID = Int32.Parse(ddlPurchaseOrder.SelectedValue);
                    var EmployeeID = Utility.GetCurrentSession().EmployeeID;
                    ObjBOL.EmployeeID = EmployeeID;
                    ObjBOL.Operation = 12;
                    string returnStatus = ObjBLL.SavePurchaseOrderInfo(ObjBOL);
                    if (returnStatus.Trim() != "")
                    {
                        Utility.ShowMessage_Success(Page, returnStatus);
                        SendEmail_Prepare(false);
                        UpdateStatusID();
                        ResetPOInformation();
                        ResetRequisitionTable();
                        btnSave.Text = "Save";
                        BindLookUpPO("");
                        if (ddlPurchaseOrder.Items.Count > 0)
                        {
                            ddlPurchaseOrder.SelectedIndex = 0;
                        }
                        BindGridReqInfoBySource();
                        btnSubmit.Enabled = false;
                        btnNotify.Enabled = false;
                        btnGenerate.Enabled = false;
                    }
                }
            }
            else
            {
                btnSubmit.Enabled = true;
                btnNotify.Enabled = true;
                btnGenerate.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtPOOrder_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int ReqQty = 0;
            int OrderQty = 0;
            int InTransitQty = 0;
            if (lnkInTransit.Text != "")
            {
                InTransitQty = Convert.ToInt32(lnkInTransit.Text);
            }
            if (txtPOOrder.Text != "")
            {
                OrderQty = Convert.ToInt32(txtPOOrder.Text);
            }
            if (lblReqOrderQty.Text != "")
            {
                ReqQty = Convert.ToInt32(lblReqOrderQty.Text);
            }
            if (OrderQty > InTransitQty && InTransitQty > 0)
            {
                Utility.ShowMessage_Error(Page, "Order Qty should greater then In-Transit Qty !!");
            }
            if (OrderQty > ReqQty)
            {
                Utility.ShowMessage_Error(Page, "Please Enter Remarks !");
                txtRemarks.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtPOOrderQty_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int ReqQty = 0;
            int OrderQty = 0;
            int InTransitQty = 0;
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            LinkButton lnkInTransit = (LinkButton)row.FindControl("lnkInTransit");
            Label lblReqNo = (Label)row.FindControl("lblReqQty");
            TextBox txtOrderQty = (TextBox)row.FindControl("txtPOOrderQty");
            TextBox txtRemarks = (TextBox)row.FindControl("txtItemRemarks");
            if (lblReqNo.Text != "")
            {
                ReqQty = Convert.ToInt32(lblReqNo.Text);
            }
            if (txtOrderQty.Text != "")
            {
                OrderQty = Convert.ToInt32(txtOrderQty.Text);
            }
            if (lnkInTransit.Text != "")
            {
                InTransitQty = Convert.ToInt32(lnkInTransit.Text);
            }
            if (OrderQty < InTransitQty && InTransitQty > 0)
            {
                Utility.ShowMessage_Error(Page, "Order Qty should greater then In-Transit Qty !!");
            }
            if (OrderQty > ReqQty && ReqQty > 0)
            {
                if (txtRemarks.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Remarks !!");
                    txtRemarks.Focus();
                }

            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindDestWareHouse(string selectedSourceID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 17;
            ObjBOL.SourceID = selectedSourceID;
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlWareHouse, ds.Tables[0]);
            }
            else
            {
                if (ddlWareHouse.Items.Count > 0)
                {
                    ddlWareHouse.Items.Clear();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlSource_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSource.SelectedIndex > 0)
            {
                BindDestWareHouse(ddlSource.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }



}