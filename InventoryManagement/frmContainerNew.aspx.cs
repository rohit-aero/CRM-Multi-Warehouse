using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;
using CrystalDecisions.CrystalReports.Engine;
public partial class INVManagement_frmContainerNew : System.Web.UI.Page
{
    BOLContainer ObjBOL = new BOLContainer();
    BLLContainerNew ObjBLL = new BLLContainerNew();
    commonclass1 cls = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    string msg = "";
    string status = "";
    int POFor = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfContaineridgetfromdb.Value = null;
            EmptyDT();
            Bind_Controls(msg);
            Bind_Grid();
            Bind_GridContainer();
        }
    }



    private void Bind_Controls(string Controllerid)
    {
        try
        {
            var EmployeeID = Utility.GetCurrentSession().EmployeeID;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ObjBOL.EmployeeID = EmployeeID;
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlContainerNo, ds.Tables[0]);
                if (Controllerid != "")
                {
                    ddlContainerNo.SelectedValue = Controllerid;
                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlAttn, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlIssuedBy, ds.Tables[2]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Grid()
    {
        var EmployeeID = Utility.GetCurrentSession().EmployeeID;
        DataSet ds = new DataSet();
        ObjBOL.Operation = 7;
        ObjBOL.EmployeeID = EmployeeID;
        ds = ObjBLL.GetBindControl(ObjBOL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvMainRequisitionDetail.DataSource = ds.Tables[0];
            gvMainRequisitionDetail.DataBind();
        }
    }

    private void Bind_GridContainer()
    {
        try
        {
            DataSet ds = new DataSet();
            foreach (GridViewRow row in gvMainRequisitionDetail.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    // Label ReqNo = (row.FindControl("ReqNo") as Label);
                    //DropDownList ddlstatus = (row.FindControl("ddlstatus") as DropDownList);
                    ////Select the Country of Customer in DropDownList
                    //string status = (row.FindControl("lblStatus") as Label).Text;
                    string POForId = (row.FindControl("lblPOForId") as Label).Text;
                    //ddlstatus.Items.FindByValue(status).Selected = true;
                    GridView gvContainer = row.FindControl("gvContainer") as GridView;
                    string poid = gvMainRequisitionDetail.DataKeys[row.RowIndex].Value.ToString();
                    var EmployeeID = Utility.GetCurrentSession().EmployeeID;
                    ObjBOL.POid = Convert.ToInt32(poid);
                    ObjBOL.Operation = 2;
                    ObjBOL.POForId = Convert.ToInt32(POForId);
                    ObjBOL.EmployeeID = EmployeeID;
                    ds = ObjBLL.GetBindControl(ObjBOL);
                    DataTable dtContainer = new DataTable();
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
                    if (dtContainer.Rows.Count > 0)
                    {
                        DataView dv = new DataView(dtContainer);
                        dv.Sort = "PendingQty DESC";
                        dtContainer = dv.ToTable();
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvContainer.DataSource = dtContainer;
                        gvContainer.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvContainer_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlstatus");
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            ddlStatus.SelectedValue = "1";
        }
    }

    private void ResetBind_GridContainer()
    {
        try
        {
            DataSet ds = new DataSet();
            foreach (GridViewRow row in gvMainRequisitionDetail.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    // Label ReqNo = (row.FindControl("ReqNo") as Label);
                    //DropDownList ddlstatus = (row.FindControl("ddlstatus") as DropDownList);
                    //Select the Country of Customer in DropDownList
                    //string status = (row.FindControl("lblStatus") as Label).Text;
                    string Reqforid = (row.FindControl("lblPOForId") as Label).Text;
                    //ddlstatus.ClearSelection();
                    //ddlstatus.Items.FindByValue(status).Selected = true;
                    GridView gvContainer = row.FindControl("gvContainer") as GridView;
                    string reqid = gvMainRequisitionDetail.DataKeys[row.RowIndex].Value.ToString();
                    ObjBOL.POid = Convert.ToInt32(reqid);
                    ObjBOL.Operation = 2;
                    var EmployeeID = Utility.GetCurrentSession().EmployeeID;
                    ObjBOL.POForId = Convert.ToInt32(Reqforid);
                    ObjBOL.EmployeeID = EmployeeID;
                    ds = ObjBLL.GetBindControl(ObjBOL);
                    DataTable dtContainer = new DataTable();
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
                    }
                }
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
            dtEmpty.Columns.Add(new DataColumn("Reqid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("ReqDetailid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("ReqStatus", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Containerid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("OrderQty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Partid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("ShipQty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Pendingqty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Remarks", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("PackingNo", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("Status", typeof(string)));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);//adding row to the datatable            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    private DataTable EmptyDTContainer()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.TableName = "ContainerSummary";
            dt.Columns.Add(new DataColumn("Reqid", typeof(int)));
            dt.Columns.Add(new DataColumn("ReqDetailid", typeof(int)));
            dt.Columns.Add(new DataColumn("ReqStatus", typeof(int)));
            dt.Columns.Add(new DataColumn("Containerid", typeof(int)));
            dt.Columns.Add(new DataColumn("OrderQty", typeof(int)));
            dt.Columns.Add(new DataColumn("partid", typeof(int)));
            dt.Columns.Add(new DataColumn("ShipQty", typeof(int)));
            dt.Columns.Add(new DataColumn("Pendingqty", typeof(int)));
            dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
            dt.Columns.Add(new DataColumn("PackingNo", typeof(string)));
            dt.Columns.Add(new DataColumn("Status", typeof(int)));
            ViewState["ContainerSummary"] = dt;

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void SaveContainerInfo()
    {
        try
        {
            var EmployeeID = Utility.GetCurrentSession().EmployeeID;
            
            ObjBOL.InvoiceNo = txtInvoiceNo.Text;
            ObjBOL.ContainerNo = txtContainerNo.Text;
            ObjBOL.SealNo = txtSealNo.Text;
            ObjBOL.SentDate = Utility.ConvertDate(txtsentdate.Text);
            ObjBOL.ArrivalinAerowerks = Utility.ConvertDate(txtArrivalinAerowerks.Text);
            ObjBOL.ContainerSize = txtContainer.Text;
            ObjBOL.Attn = Convert.ToInt32(ddlAttn.SelectedValue);
            ObjBOL.Issuedby = Convert.ToInt32(ddlIssuedBy.SelectedValue);
            SaveGridData();
            DataTable selected = (DataTable)ViewState["ContainerSummary"];
            DataView dv = new DataView(selected);
            DataTable summarytemp = dv.ToTable("selected", false, "Reqid", "ReqDetailid", "Partid", "OrderQty", "ShipQty", "Pendingqty", "Remarks", "PackingNo", "Status");
            ObjBOL.ContainerDetails = summarytemp;
            int Employeeid = Utility.GetCurrentSession().EmployeeID;
            ObjBOL.LoginUserId = Employeeid;
            ObjBOL.EmployeeID = EmployeeID;
            if (btnSave.Text == "Save")
            {
                ObjBOL.Operation = 3;
                if (Employeeid == 263 || Employeeid == 37 || EmployeeID== 237)
                {
                    msg = ObjBLL.SaveContainerInfo(ObjBOL);
                    if (msg == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Container Already in Process !!!. !');", true);
                        return;
                    }
                    if (msg != "")
                    {
                        hfContainerid.Value = msg;
                        Bind_Controls(msg);
                        UpdateReqStatus();
                        AutoFillData();
                        Bind_GridChangeContainer();
                        Utility.ShowMessage(this, "Records Added Successfully !!!");

                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('You are not Authorize to update data !!!. !');", true);
                }
                btnSave.Text = "Update";
            }
            else
            {
                btnSave.Text = "Update";
                ObjBOL.Operation = 9;
                if (Employeeid == 263 || Employeeid == 237)
                {
                    msg = ObjBLL.SaveContainerInfo(ObjBOL);
                    if (msg != "")
                    {
                        hfContainerid.Value = msg;
                        Bind_Controls(msg);
                        UpdateReqStatus();
                        AutoFillData();
                        Bind_GridChangeContainer();
                    }
                    Utility.ShowMessage(this, "Records Updated Successfully !!!");

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('You are not Authorize to update data !!!. !');", true);
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

            DataTable dt = EmptyDTContainer();
            foreach (GridViewRow row in gvMainRequisitionDetail.Rows)
            {
                DataRow dr;
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string Reqid = gvMainRequisitionDetail.DataKeys[row.RowIndex].Value.ToString();
                    //DropDownList ReqStatus = (row.FindControl("ddlstatus") as DropDownList);
                    Label ReqNo = (row.FindControl("lblPOId") as Label);
                    GridView gvContainer = row.FindControl("gvContainer") as GridView;
                    foreach (GridViewRow Containerrow in gvContainer.Rows)
                    {
                        Label ReqDetailid = ((Label)Containerrow.FindControl("lblReqDetailid") as Label);
                        if (Containerrow.RowType == DataControlRowType.DataRow)
                        {
                            dr = dt.NewRow();
                            Label Partid = ((Label)Containerrow.FindControl("lblItemPartid"));
                            Label PartNo = ((Label)Containerrow.FindControl("lblPartnumber"));
                            //Label RevisionNo = ((Label)Containerrow.FindControl("lblRevisionNo"));
                            Label PartDes = ((Label)Containerrow.FindControl("lblPartDes"));
                            //Label ReqPriority = ((Label)Containerrow.FindControl("lblReqprority"));
                            Label OrderQty = ((Label)Containerrow.FindControl("lblOrderQty"));
                            Label Pending = ((Label)Containerrow.FindControl("lblPendingQty"));
                            TextBox ShippedQty = ((TextBox)Containerrow.FindControl("txtShippingQty"));
                            TextBox ItemRemarks = ((TextBox)Containerrow.FindControl("txtItemRemarks"));
                            //TextBox PackingNo = ((TextBox)Containerrow.FindControl("txtPackingNo"));
                            DropDownList ddlStatus = ((DropDownList)Containerrow.FindControl("ddlstatus"));
                            dr[0] = Convert.ToInt32(Reqid);
                            if (ReqDetailid.Text != "")
                            {
                                dr[1] = ReqDetailid.Text;
                            }
                            //if (ReqStatus.SelectedValue == "")
                            //{
                            //    dr[2] = 0;
                            //}
                            //else
                            //{
                            //    dr[2] = ReqStatus.SelectedValue;
                            //}
                            dr[3] = 0;
                            dr[4] = OrderQty.Text;
                            dr[5] = Partid.Text;
                            if (ShippedQty.Text != "")
                            {
                                dr[6] = ShippedQty.Text;
                            }
                            else
                            {
                                dr[6] = 0;
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
                            dr[7] = PendingQty;
                            dr[8] = ItemRemarks.Text;
                            //dr[9] = PackingNo.Text;

                            if (ddlStatus.SelectedValue == "0")
                            {
                                dr[10] = "0";
                            }
                            else
                            {
                                dr[10] = Convert.ToInt32(ddlStatus.SelectedValue);
                            }
                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                        }
                    }
                }

            }
            ViewState["ContainerSummary"] = dt;

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
            if (txtInvoiceNo.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Invoice No. !');", true);
                txtInvoiceNo.Focus();
                return false;
            }
            if (txtContainerNo.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Container No. !');", true);
                txtContainerNo.Focus();
                return false;
            }
            if (txtsentdate.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Sent Date. !');", true);
                txtsentdate.Focus();
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
                SaveContainerInfo();
                btnSubmit.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_GridOnChangeContainer()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
            var EmployeeID = Utility.GetCurrentSession().EmployeeID;
            ObjBOL.EmployeeID = EmployeeID;
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (EmployeeID == 263)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    gvMainRequisitionDetail.DataSource = ds.Tables[1];
                    gvMainRequisitionDetail.DataBind();
                }
            }
            else
            {
                if (ds.Tables[3].Rows.Count > 0)
                {
                    gvMainRequisitionDetail.DataSource = ds.Tables[3];
                    gvMainRequisitionDetail.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_GridChangeContainer()
    {
        try
        {
            var EmployeeID = Utility.GetCurrentSession().EmployeeID;
            //hfContaineridgetfromdb.Value = ddlContainerNo.SelectedValue;           
            Bind_GridAfterSubmit();
            //DataTable TempData = (DataTable)ViewState["ContainerSummary"];
            btnSave.Text = "Update";
            //Bind_GridOnChangeContainer();
            DataSet ds = new DataSet();
            foreach (GridViewRow row in gvMainRequisitionDetail.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Label ReqNo = (row.FindControl("ReqNo") as Label);
                    Label ReqForid = (row.FindControl("lblPOForId") as Label);

                    string reqid = gvMainRequisitionDetail.DataKeys[row.RowIndex].Value.ToString();

                    ObjBOL.POid = Convert.ToInt32(reqid);
                    ObjBOL.Operation = 2;
                    ObjBOL.POForId = Convert.ToInt32(ReqForid.Text);
                    ObjBOL.EmployeeID = EmployeeID;
                    ds = ObjBLL.GetBindControl(ObjBOL);
                    DataTable dtContainer = new DataTable();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtContainer = ds.Tables[0];
                    }
                    GridView gvContainer = row.FindControl("gvContainer") as GridView;
                    ObjBOL.Reqid = Convert.ToInt32(reqid);
                    ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
                    ObjBOL.POForId = Convert.ToInt32(ReqForid.Text);
                    ObjBOL.Operation = 4;
                    ds = ObjBLL.GetBindControl(ObjBOL);
                    DataTable dtContainerUpdate = new DataTable();
                    if (EmployeeID == 263 || EmployeeID == 37 || EmployeeID==237)
                    {
                        dtContainerUpdate = ds.Tables[1];

                        if (ds.Tables[1].Rows.Count > 0)
                        {

                            foreach (DataRow dtRow in dtContainer.Rows)
                            {
                                foreach (DataRow dtRow1 in dtContainerUpdate.Rows)
                                {
                                    if (dtRow["PODetailid"].ToString() == dtRow1["PODetailid"].ToString())
                                    {
                                        dtRow["ShippedQty"] = dtRow1["ShippedQty"];
                                        dtRow["PackingNo"] = dtRow1["PackingNo"];
                                        dtRow["Remarks"] = dtRow1["Remarks"];
                                        dtRow["Status"] = dtRow1["Status"];
                                        break;
                                    }


                                }
                            }
                            if (dtContainer.Rows.Count > 0)
                            {
                                DataView dv = new DataView(dtContainer);
                                dv.Sort = "PendingQty DESC";
                                dtContainer = dv.ToTable();
                            }
                            gvContainer.DataSource = dtContainer;
                            gvContainer.DataBind();

                        }
                        else
                        {
                            gvContainer.DataSource = dtContainer;
                            gvContainer.DataBind();

                            //Bind_Grid();
                            //Bind_GridContainer();
                        }

                    }
                    else
                    {
                        dtContainerUpdate = ds.Tables[2];
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            gvContainer.DataSource = dtContainerUpdate;
                            gvContainer.DataBind();
                        }
                    }
                    foreach (GridViewRow Containerrow in gvContainer.Rows)
                    {
                        if (Containerrow.RowType == DataControlRowType.DataRow)
                        {
                            DropDownList ddlstatus = (Containerrow.FindControl("ddlstatus") as DropDownList);
                            Label lblstatus = (Containerrow.FindControl("lblStatus") as Label);
                            if (lblstatus != null)
                            {
                                ddlstatus.SelectedValue = lblstatus.Text;
                            }
                        }
                    }
                    //for (int i = dtContainerUpdate.Rows.Count - 1; i >= 0; i--)
                    //{
                    //    DataRow dr = dtContainerUpdate.Rows[i];
                    //    if (dr["OrderQty"].ToString() == "0")
                    //    dr.Delete();
                    //    dtContainerUpdate.AcceptChanges();
                    //}                        
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
            if (ddlContainerNo.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 4;
                ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
                ObjBOL.Reqid = Convert.ToInt32(ddlContainerNo.SelectedValue);
                ds = ObjBLL.GetBindControl(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtInvoiceNo.Text = ds.Tables[0].Rows[0]["InvoiceNo"].ToString();
                    txtContainerNo.Text = ds.Tables[0].Rows[0]["ContainerNo"].ToString();
                    txtSealNo.Text = ds.Tables[0].Rows[0]["SealNo"].ToString();
                    txtsentdate.Text = cls.Converter(ds.Tables[0].Rows[0]["SentDate"].ToString());
                    txtArrivalinAerowerks.Text = cls.Converter(ds.Tables[0].Rows[0]["ArrivalinAerowerks"].ToString());
                    txtContainer.Text = ds.Tables[0].Rows[0]["ContainerSize"].ToString();
                    ddlAttn.SelectedValue = ds.Tables[0].Rows[0]["Attn"].ToString();
                    ddlIssuedBy.SelectedValue = ds.Tables[0].Rows[0]["Issuedby"].ToString();

                }
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void ddlContainerNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlContainerNo.SelectedIndex > 0)
            {
                AutoFillData();
                Bind_GridChangeContainer();
                btnGenerate.Enabled = true;
                btnSubmit.Enabled = true;
                hfContaineridgetfromdb.Value = ddlContainerNo.SelectedValue;
            }
            else
            {
                Bind_GridChangeContainer();
                ResetControls();
                ddlContainerNo.SelectedIndex = 0;
                btnSubmit.Enabled = false;
                btnGenerate.Enabled = false;
                ResetBind_GridContainer();
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
            txtInvoiceNo.Text = String.Empty;
            txtContainerNo.Text = String.Empty;
            txtSealNo.Text = String.Empty;
            txtsentdate.Text = String.Empty;
            txtArrivalinAerowerks.Text = String.Empty;
            txtContainer.Text = String.Empty;
            ddlAttn.SelectedIndex = 0;
            ddlIssuedBy.SelectedIndex = 0;

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
            ddlContainerNo.SelectedIndex = 0;
            btnSubmit.Enabled = false;
            ResetBind_GridContainer();
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
                    ObjBOL.Operation = 5;
                    string reqid = gvMainRequisitionDetail.DataKeys[row.RowIndex].Value.ToString();
                    ObjBOL.POid = Convert.ToInt32(reqid);
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

    private DataTable ReportDataZero()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[INV_GenerateContainerDetail] '" + ddlContainerNo.SelectedValue + "'");
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
            rprt.Load(Server.MapPath("~/Reports/rptGenerateContainer.rpt"));
            if (dt.Rows.Count > 0)
            {
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
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

    private void Bind_GridAfterSubmit()
    {

        DataSet ds = new DataSet();
        ObjBOL.Operation = 8;
        var EmployeeID = Utility.GetCurrentSession().EmployeeID;
        ObjBOL.EmployeeID = EmployeeID;
        if (hfContaineridgetfromdb.Value != "")
        {
            ObjBOL.Containerid = Convert.ToInt32(hfContaineridgetfromdb.Value);
        }

        ds = ObjBLL.GetBindControl(ObjBOL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvMainRequisitionDetail.DataSource = ds.Tables[0];
            gvMainRequisitionDetail.DataBind();
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 6;
            if (ddlContainerNo.SelectedIndex > 0)
            {
                ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
            }
            msg = ObjBLL.UpdateContainerStatus(ObjBOL);
            Utility.ShowMessage(this, msg);
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}