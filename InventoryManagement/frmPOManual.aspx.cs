using System;
using System.Data;
using BOLAERO;
using BLLAERO;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class InventoryManagement_frmPOManual : System.Web.UI.Page
{
    BOLPurchaseOrder ObjBOL = new BOLPurchaseOrder();
    BLLPurchaseOrderManual ObjBLL = new BLLPurchaseOrderManual();
    commonclass1 cls = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //btnAdd.Enabled = false;
            ViewState["Summary"] = null;
            EmptyDTPurchaseOrder();
            Bind_Controls();
            Bind_Grid();
            Bind_Ppage();
            btnGenerate.Enabled = false;
            //Bind_ControlPartInfo();
        }
    }

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

            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPurchaseOrder, ds.Tables[4]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Ppage()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetBindControl(ObjBOL);

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDivision, ds.Tables[2]);
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlfooterpartinfo, ds.Tables[3]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlfooterpartno, ds.Tables[5]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable EmptyDTPurchaseOrder()
    {
        DataTable dt = new DataTable();
        try
        {
            //DataRow dr;            
            dt.TableName = "Summary";
            //TicketID   
            dt.Columns.Add(new DataColumn("Id", typeof(int)));
            dt.Columns.Add(new DataColumn("PurchaseOrderId", typeof(string)));
            dt.Columns.Add(new DataColumn("PartId", typeof(string)));
            dt.Columns.Add(new DataColumn("OrderQty", typeof(int)));
            dt.Columns.Add(new DataColumn("ReqQty", typeof(int)));
            dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
            ViewState["Summary"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable EmptyDT()
    {
        DataTable dtEmpty = new DataTable();
        try
        {
            dtEmpty.TableName = "GridSummary";
            dtEmpty.Columns.Add(new DataColumn("Id", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("PurchaseOrderId", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("PartId", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("OrderQty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("ReqQty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("PartDesc", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("PartNumber", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("RevisionNo", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("Remarks", typeof(string)));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(0, 0, 0, 0, 0, "", "", "", "");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    private void Bind_Grid()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 10;
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                ViewState["Summary"] = dt;
                gvRequition.DataSource = dt;
                gvRequition.DataBind();
            }
            else
            {
                gvRequition.DataSource = EmptyDT();
                gvRequition.DataBind();
                gvRequition.Rows[0].Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_GridChange()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 11;
            ObjBOL.PONumberID = Convert.ToInt32(ddlPurchaseOrder.SelectedValue);
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                ViewState["Summary"] = dt;
                gvRequition.DataSource = dt;
                gvRequition.DataBind();
            }
            else
            {
                gvRequition.DataSource = EmptyDT();
                gvRequition.DataBind();
                gvRequition.Rows[0].Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void bindProductLine()
    {
        try
        {

            ddlProductLine.Items.Clear();
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            ObjBOL.PONumberID = Convert.ToInt32(ddlDivision.SelectedValue);
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProductLine, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void BindPartNumber(string ProductId)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.PONumberID = Int32.Parse(ProductId);
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlfooterpartno, ds.Tables[0]);
                Utility.BindDropDownList(ddlfooterpartinfo, ds.Tables[0]);
            }
            else
            {
                ddlfooterpartno.DataSource = "";
                ddlfooterpartno.DataBind();
                ResetDetails();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        ResetGrid();
    }

    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            bindProductLine();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlpartno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindPartNumber(ddlProductLine.SelectedValue);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlfooterpartno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlfooterpartno.SelectedIndex > 0)
            {

                DataSet ds = new DataSet();
                ObjBOL.Operation = 5;
                ObjBOL.PONumberID = Convert.ToInt32(ddlfooterpartno.SelectedValue);
                ObjBOL.PONumber = lblfooterpartrevisionno.Text;
                ds = ObjBLL.GetBindControl(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlfooterpartno.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PartId"]);
                    // BindPartNumber(ds.Tables[0].Rows[0]["partid"].ToString());
                    //ddlfooterpartno.SelectedValue = ds.Tables[0].Rows[0]["partid"].ToString();
                    ddlDivision.SelectedValue = ds.Tables[0].Rows[0]["DivisionId"].ToString();
                    bindProductLine();
                    ddlProductLine.SelectedValue = ds.Tables[0].Rows[0]["ProductId"].ToString();
                    ddlfooterpartinfo.SelectedValue = ds.Tables[0].Rows[0]["PartId"].ToString();
                    lblfooterpartrevisionno.Text = ds.Tables[0].Rows[0]["RevisionNo"].ToString();
                }
            }
            else
            {
                btnGenerate.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlfooterpartinfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ObjBOL.PONumberID = Convert.ToInt32(ddlfooterpartinfo.SelectedValue);
            ObjBOL.PONumber = lblfooterpartrevisionno.Text;
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDivision.SelectedValue = ds.Tables[0].Rows[0]["DivisionId"].ToString();
                bindProductLine();
                ddlProductLine.SelectedValue = ds.Tables[0].Rows[0]["ProductId"].ToString();
                // ddlfooterpartno.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["partid"]);
                // BindPartNumber(ds.Tables[0].Rows[0]["partid"].ToString());
                ddlfooterpartno.SelectedValue = ddlfooterpartinfo.SelectedValue;
                lblfooterpartrevisionno.Text = ds.Tables[0].Rows[0]["RevisionNo"].ToString();

            }
            btnGenerate.Enabled = true;
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
                Bind_GridChange();
                btnSave.Enabled = true;
                btnAdd.Enabled = true;
                btnGenerate.Enabled = true;
                btnSave.Text = "Update";
            }
            else
            {
                Reset();
                Bind_Grid();
                //btnAdd.Enabled = false;
                btnSave.Enabled = false;
                btnGenerate.Enabled = false;
                //btnSubmit.Enabled = false;
                txtPurchaseOrderNo.Text = String.Empty;
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
                Utility.ShowMessage_Error(Page, "Please Select Vendor. !");
                ddlSource.Focus();
                return false;
            }
            if (txtIssueDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Insert Issue Date !');", true);
                Utility.ShowMessage_Error(Page, "Please Insert Issue Date !");
                txtIssueDate.Focus();
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
            // DropDownList ddlpart = (gvRequition.FooterRow.FindControl("ddlfooterpartinfo") as DropDownList);
            //TextBox txtqty = (gvRequition.FooterRow.FindControl("txtfooterqty") as TextBox);

            //if (ddlPurchaseOrder.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('PLEASE SELECT OR SAVE PURCHASE ORDER FIRST. !');", true);
            //    ddlPurchaseOrder.Focus();
            //    return false;
            //}

            if (ddlProductLine.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Product Line. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Product Line. !");
                ddlProductLine.Focus();
                return false;
            }
            if (ddlfooterpartno.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Part#. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Part#. !");
                ddlfooterpartno.Focus();
                return false;
            }

            if (txtReqQty.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Req Order Quantity. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Req Order Quantity. !");
                txtReqQty.Focus();
                return false;
            }
            if (txtOrderQty.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Order Quantity. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Order Quantity. !");
                txtOrderQty.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }
    private Boolean ValidationCheckGrid()
    {
        var toReturn = true;
        try
        {
            foreach (GridViewRow row in gvRequition.Rows)
            {
                TextBox txtReqQtyFooter = ((TextBox)row.FindControl("txtReqQtyFooter"));
                TextBox txtOrderQtyFooter = ((TextBox)row.FindControl("txtOrderQtyFooter"));

                string reqQty = txtReqQtyFooter.Text;
                string orderQty = txtOrderQtyFooter.Text;

                if (reqQty == "0")
                {
                    reqQty = "";
                }

                if (orderQty == "0")
                {
                    orderQty = "";
                }

                if ((reqQty != "" && orderQty == "") || (reqQty == "" && orderQty != ""))
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Both ReqQty and OrderQty are required and must be greater than zero');", true);
                    Utility.ShowMessage_Error(Page, "Both ReqQty and OrderQty are required and must be greater than zero");
                    toReturn = false;
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return toReturn;
    }
    private void AutoFillData()
    {
        try
        {
            if (ddlPurchaseOrder.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 9;
                ObjBOL.PONumberID = Int32.Parse(ddlPurchaseOrder.SelectedValue);
                ds = ObjBLL.GetBindControl(ObjBOL);
                ddlPreparedby.SelectedIndex = 0;
                ddlSource.SelectedIndex = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtPurchaseOrderNo.Text = ds.Tables[0].Rows[0]["PONumber"].ToString();
                    txtIssueDate.Text = ds.Tables[0].Rows[0]["IssueDate"].ToString();
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

    private void SaveGridData()
    {
        try
        {
            if (ValidationCheckGrid() == true)
            {
                DataTable dt = EmptyDTPurchaseOrder();
                DataRow dr;
                foreach (GridViewRow row in gvRequition.Rows)
                {
                    Label lblpartId = ((Label)row.FindControl("lblpartid"));
                    TextBox txtReqQtyFooter = ((TextBox)row.FindControl("txtReqQtyFooter"));
                    TextBox txtOrderQtyFooter = ((TextBox)row.FindControl("txtOrderQtyFooter"));
                    dr = dt.NewRow();
                    dr[0] = 0;
                    if (ddlPurchaseOrder.SelectedIndex > 0)
                    {
                        dr[1] = ddlPurchaseOrder.SelectedValue;
                    }
                    else
                    {
                        dr[1] = 0;
                    }
                    dr[2] = Convert.ToInt32(lblpartId.Text);
                    if (txtOrderQtyFooter.Text != "")
                    {
                        dr[3] = txtOrderQtyFooter.Text;
                    }
                    else
                    {
                        dr[3] = 0;
                    }

                    if (txtReqQtyFooter.Text != "")
                    {
                        dr[4] = txtReqQtyFooter.Text;
                    }
                    else
                    {
                        dr[4] = 0;
                    }

                    dt.Rows.Add(dr);
                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow drdelete = dt.Rows[i];

                        //if (drdelete["OrderQty"].ToString() == Convert.ToString(0))
                        //{
                        //    drdelete.Delete();
                        //}

                        //if (drdelete["ReqQty"].ToString() == Convert.ToString(0))
                        //{
                        //    drdelete.Delete();
                        //}

                        if (drdelete["PartId"].ToString() == Convert.ToString(0))
                        {
                            drdelete.Delete();
                        }
                    }
                    dt.AcceptChanges();
                }

                //gvRequition.DataSource = EmptyDT();
                //gvRequition.DataBind();
                //gvRequition.Rows[0].Visible = true;
                ViewState["Summary"] = dt;
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SaveData()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = "";
                ObjBOL.Operation = 6;
                ObjBOL.PONumber = txtPurchaseOrderNo.Text;
                ObjBOL.IssueDate = Utility.ConvertDate(txtIssueDate.Text);
                ObjBOL.SourceID = ddlSource.SelectedValue;
                ObjBOL.PreparedBy = ddlPreparedby.SelectedValue;
                SaveGridData();
                DataTable selected = (DataTable)ViewState["Summary"];
                DataView dv = new DataView(selected);
                DataTable summarytemp = dv.ToTable("selected", false, "Id", "PurchaseOrderId", "PartId", "OrderQty", "ReqQty", "Remarks");
                ObjBOL.PurchaseOrderDetails = summarytemp;
                msg = ObjBLL.SavePurchaseOrderInfoAndDetail(ObjBOL);               
                if (msg == "")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Could not save Data');", true);
                    Utility.ShowMessage_Error(Page, "Could not save Data");
                    return;
                }
                else
                {
                    Reset();
                    ResetDetails();
                    Bind_Controls();
                    ddlPurchaseOrder.SelectedValue = msg;
                    Bind_GridChange();
                    AutoFillData();
                    //Utility.ShowMessage(this, "Records Added Successfully !!!");
                    Utility.ShowMessage_Success(Page, "Records Added Successfully !!!");
                }
                btnSave.Text = "Update";

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void UpdateData()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = "";
                ObjBOL.Operation = 7;
                ObjBOL.PONumber = txtPurchaseOrderNo.Text;
                ObjBOL.IssueDate = Utility.ConvertDate(txtIssueDate.Text);
                ObjBOL.SourceID = ddlSource.SelectedValue;
                ObjBOL.PreparedBy = ddlPreparedby.SelectedValue;
                ObjBOL.PONumberID = Int32.Parse(ddlPurchaseOrder.SelectedValue);
                SaveGridData();
                DataTable selected = (DataTable)ViewState["Summary"];
                DataView dv = new DataView(selected);
                DataTable summarytemp = dv.ToTable("selected", false, "Id", "PurchaseOrderId", "PartId", "OrderQty", "ReqQty", "Remarks");
                ObjBOL.PurchaseOrderDetails = summarytemp;
                msg = ObjBLL.SavePurchaseOrderInfoAndDetail(ObjBOL);
                if (msg == "")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Could not update Data');", true);
                    Utility.ShowMessage_Error(Page, "Could not update Data");
                    return;
                }
                else
                {
                    Reset();
                    ResetDetails();
                    Bind_Controls();
                    ddlPurchaseOrder.SelectedValue = msg;
                    Bind_GridChange();
                    AutoFillData();
                    //Utility.ShowMessage(this, "Records updated Successfully !!!");
                    Utility.ShowMessage_Success(Page, "Records updated Successfully !!!");
                }
                btnSave.Text = "Update";
                btnAdd.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void AddReqDetails()
    {
        try
        {
            //CheckGridBeforeSave();
            string msg = "";
            string partId = ddlfooterpartinfo.SelectedValue;
            string reqQty = txtReqQty.Text;
            string orderQty = txtOrderQty.Text;
            //string remarks = txtRemarks.Text;
            string remarks = "";
            string PurchaseOrderId = ddlPurchaseOrder.SelectedValue;

            if (reqQty == "")
            {
                reqQty = "0";
            }
            if (orderQty == "")
            {
                orderQty = "0";
            }

            DataTable dt = EmptyDT();
            DataRow dr;
            foreach (GridViewRow row in gvRequition.Rows)
            {
                Label lblpartId = ((Label)row.FindControl("lblpartid"));
                Label lblpartnumber = ((Label)row.FindControl("lblpartnumber"));
                Label lblpartrevno = ((Label)row.FindControl("lblpartrevno"));
                Label lblPartinfo = ((Label)row.FindControl("lblPartinfo"));
                Label lblDetailId = ((Label)row.FindControl("lblDetailId"));
                Label lblpartid = ((Label)row.FindControl("lblpartid"));
                TextBox txtReqQtyFooter = ((TextBox)row.FindControl("txtReqQtyFooter"));
                TextBox txtOrderQtyFooter = ((TextBox)row.FindControl("txtOrderQtyFooter"));

                dr = dt.NewRow();
                if (lblpartId.Text == partId)
                {
                    if (txtReqQtyFooter.Text == "")
                    {
                        dr["ReqQty"] = Convert.ToInt32(reqQty);
                    }
                    else
                    {
                        dr["ReqQty"] = Convert.ToInt32(txtReqQtyFooter.Text) + Convert.ToInt32(reqQty);
                    }

                    if (txtOrderQtyFooter.Text == "")
                    {
                        dr["OrderQty"] = Convert.ToInt32(orderQty);
                    }
                    else
                    {
                        dr["OrderQty"] = Convert.ToInt32(txtOrderQtyFooter.Text) + Convert.ToInt32(orderQty);
                    }

                    reqQty = "0";
                    orderQty = "0";
                }
                else
                {
                    if (txtReqQtyFooter.Text == "")
                    {
                        dr["ReqQty"] = "0";
                    }
                    else
                    {
                        dr["ReqQty"] = Convert.ToInt32(txtReqQtyFooter.Text);
                    }

                    if (txtOrderQtyFooter.Text == "")
                    {
                        dr["OrderQty"] = "0";
                    }
                    else
                    {
                        dr["OrderQty"] = Convert.ToInt32(txtOrderQtyFooter.Text);
                    }

                }
                dr["PartNumber"] = lblpartnumber.Text;
                dr["PartDesc"] = lblPartinfo.Text;
                dr["PartId"] = lblpartid.Text;
                dr["RevisionNo"] = lblpartrevno.Text;
                if (lblDetailId.Text != "")
                {
                    dr["Id"] = lblDetailId.Text;
                }

                dt.Rows.Add(dr);
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow drdelete = dt.Rows[i];

                    if (drdelete["PartId"].ToString() == Convert.ToString(0))
                    {
                        drdelete.Delete();
                    }
                }
                dt.AcceptChanges();
            }

            gvRequition.DataSource = dt;
            gvRequition.DataBind();

            //DataSet ds = new DataSet();
            //ObjBOL.Operation = 8;
            //ObjBOL.PONumberID = Convert.ToInt32(ddlDivision.SelectedValue);
            //ObjBOL.ReqId = Convert.ToInt32(reqQty);
            //ObjBOL.ReqForId = Convert.ToInt32(orderQty);
            //ObjBOL.Remarks = remarks;
            //ObjBOL.PartId = Convert.ToInt32(partId);
            //msg = ObjBLL.SavePurchaseOrderInfo(ObjBOL);

            //if (msg == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Could not save Data');", true);
            //    return;
            //}
            //Utility.ShowMessage(this, "Record Added Successfully !!!");
            ResetDetails();
            EnableControls();
            //Bind_GridChange();

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
            if (ValidationCheckPartDetails() == true)
            {
                // Bind_GridDetails();
                AddReqDetails();
                //EnableControls();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            Reset();
            ResetDetails();
            Bind_Grid();
            string msg = "";
            ObjBOL.Operation = 2;
            msg = ObjBLL.GetPurchaseOrderNumber(ObjBOL);
            if (msg != "")
            {
                txtPurchaseOrderNo.Text = msg;
                EnableControls();
                btnSave.Text = "Save";
            }
            else
            {
                txtPurchaseOrderNo.Text = String.Empty;
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
            if (btnSave.Text == "Save")
            {
                SaveData();
            }
            else if (btnSave.Text == "Update")
            {
                UpdateData();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable ReportDataZero()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[Inv_GeneratePurchaseOrder] '" + ddlPurchaseOrder.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataZero();
            rprt.Load(Server.MapPath("~/Reports/rptPurchaseOrderManual.rpt"));
            if (dt.Rows.Count > 0)
            {
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, ddlPurchaseOrder.SelectedItem.Text);
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
            }
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ResetDetails();
            Reset();
            DisableControls();
            Bind_Grid();

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvRequition_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        try
        {

            //string msg = "";
            DataTable dtCurrentTable = (DataTable)ViewState["Summary"];
            dtCurrentTable.Rows.RemoveAt(e.RowIndex);

            //else
            //{
            //    DataSet ds = new DataSet();
            //    ObjBOL.Operation = 8;
            //    if (ddlPurchaseOrder.SelectedIndex > 0)
            //    {
            //        ObjBOL.Reqid = Convert.ToInt32(ddlPurchaseOrder.SelectedValue);
            //    }
            //    ds = ObjBLL.GetControlsData(ObjBOL);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        gvRequition.DataSource = ds.Tables[0];
            //        gvRequition.DataBind();
            //        ObjBOL.Operation = 9;
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            if (ds.Tables[0].Rows.Count != dtCurrentTable.Rows.Count)
            //            {
            //                dtCurrentTable.Rows.RemoveAt(e.RowIndex);
            //            }
            //            else
            //            {
            //                GridViewRow row = gvRequition.Rows[e.RowIndex];
            //                Int32 ID = Convert.ToInt32(gvRequition.DataKeys[e.RowIndex].Value);
            //                ObjBOL.Reqid = ID;
            //                msg = ObjBLL.DeleteReqData(ObjBOL);
            //                dtCurrentTable.Rows.RemoveAt(e.RowIndex);
            //            }
            //        }
            //        else
            //        {
            //            dtCurrentTable.Rows.RemoveAt(e.RowIndex);
            //        }
            //        gvRequition.DataSource = dtCurrentTable;
            //        gvRequition.DataBind();
            //        dtCurrentTable.AcceptChanges();
            //        BindSummaryTemp(dtCurrentTable);
            //        Bind_GridbyReq();
            //    }
            //    else
            //    {
            //        dtCurrentTable.Rows.RemoveAt(e.RowIndex);
            //    }
            //}
            gvRequition.DataSource = dtCurrentTable;
            gvRequition.DataBind();
            dtCurrentTable.AcceptChanges();
            //BindSummaryTemp(dtCurrentTable);
            //Bind_GridDropdowns();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvRequition_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            //PopupGridEmpty();
            //if (e.CommandName == "Select")
            //{
            //    DataSet ds = new DataSet();
            //    GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
            //    Label lblID = (Label)clickedRow.FindControl("lblpartid");
            //    hfpartid.Value = Convert.ToString(lblID.Text);
            //    ObjBOL.partid = Convert.ToInt32(hfpartid.Value);
            //    ObjBOL.Operation = 1;
            //    ds = ObjBLL.GetTransitionData(ObjBOL);
            //    gvInTransit.DataSource = ds.Tables[0];
            //    gvInTransit.DataBind();
            //    ModalPopupExtender1.Show();
            //}
            //else if (e.CommandName == "Select2")
            //{
            //    DataSet ds = new DataSet();
            //    GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
            //    Label lblID = (Label)clickedRow.FindControl("lblpartid");
            //    hfpartid.Value = Convert.ToString(lblID.Text);
            //    ObjBOL.partid = Convert.ToInt32(hfpartid.Value);
            //    ObjBOL.Operation = 1;
            //    ds = ObjBLL.GetInShopData(ObjBOL);
            //    gvInShop.DataSource = ds.Tables[0];
            //    gvInShop.DataBind();
            //    ModalPopupExtender2.Show();
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvRequition_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            //DataTable dtrslt = (DataTable)ViewState["dirState"];
            //if (dtrslt.Rows.Count > 0)
            //{
            //    DataView dataView = new DataView(dtrslt);
            //    dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
            //    gvRequition.DataSource = dataView;
            //    gvRequition.DataBind();
            //    //dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
            //    //gvProposalSearch.DataSource = dtrslt;
            //    //gvProposalSearch.DataBind();
            //}
            //else
            //{
            //    dtrslt.DefaultView.Sort = e.SortExpression + "DESC";
            //    gvRequition.DataSource = dtrslt;
            //    gvRequition.DataBind();
            //}
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
            //btnSubmit.Enabled = true;
            btnGenerate.Enabled = true;
            btnSave.Enabled = true;
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
            //btnSubmit.Enabled = false;
            btnGenerate.Enabled = false;
            btnSave.Enabled = false;
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
            txtPurchaseOrderNo.Text = String.Empty;
            ddlProductLine.Items.Clear();
            if (ddlPurchaseOrder.Items.Count > 0)
            {
                ddlPurchaseOrder.SelectedIndex = 0;
            }

            if (ddlPreparedby.Items.Count > 0)
            {
                ddlPreparedby.SelectedIndex = 0;
            }

            if (ddlSource.Items.Count > 0)
            {
                ddlSource.SelectedIndex = 0;
            }

            ddlfooterpartno.SelectedIndex = 0;
            ddlfooterpartinfo.SelectedIndex = 0;
            txtIssueDate.Text = String.Empty;

            btnSave.Text = "Save";
            //btnAdd.Enabled = false;
            divError.Visible = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetDetails()
    {
        try
        {
            if (ddlProductLine.Items.Count > 0)
            {
                ddlProductLine.SelectedIndex = 0;
            }

            if (ddlDivision.Items.Count > 0)
            {
                ddlDivision.SelectedIndex = 0;
            }

            if (ddlfooterpartno.Items.Count > 0)
            {
                ddlfooterpartno.SelectedIndex = 0;
            }

            if (ddlfooterpartinfo.Items.Count > 0)
            {
                ddlfooterpartinfo.SelectedIndex = 0;
            }

            lblfooterpartrevisionno.Text = string.Empty;
            txtOrderQty.Text = string.Empty;
            txtReqQty.Text = string.Empty;
            //txtRemarks.Text = string.Empty;

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
            ddlfooterpartinfo.SelectedIndex = 0;
            lblfooterpartrevisionno.Text = string.Empty;
            txtReqQty.Text = string.Empty;
            txtOrderQty.Text = string.Empty;
            //txtRemarks.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


}