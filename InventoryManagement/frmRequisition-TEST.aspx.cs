using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using BOLAERO;
using BLLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using System.IO;
public partial class INVManagement_frmRequisition : System.Web.UI.Page
{
    BOLRequisition ObjBOL = new BOLRequisition();
    BLLRequisition ObjBLL = new BLLRequisition();
    commonclass1 cls = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Summary"] = null;
            EmptyDTRequition();
            Bind_Controls();
            Bind_Grid();
            Bind_ControlPartInfo();
        }
    }

    #region BIND FUNCTIONS

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControlsData(ObjBOL);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlReqNo, ds.Tables[0]);
            //}
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPreparedby, ds.Tables[1]);
                Utility.BindDropDownList(ddlPreparedByList, ds.Tables[1]);
                Utility.BindDropDownList(ddlApprovedby, ds.Tables[6]);
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
            ds = ObjBLL.GetControlsData(ObjBOL);

            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlfooterpartinfo, ds.Tables[3]);
                ddlfooterpartinfo.SelectedIndex = 0;
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlfooterpartno, ds.Tables[5]);
                ddlfooterpartno.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_ControlPartInfo()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartInfo, ds.Tables[0]);
            }
            else
            {
                ddlPartInfo.DataSource = "";
                ddlPartInfo.DataBind();
                ddlPartInfo.Items.Insert(0, new ListItem("Select", "0"));
                Reset();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_GridDropdowns()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDivision, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                // DropDownList ddlfooterpartinfo = gvRequition.FooterRow.FindControl("ddlfooterpartinfo") as DropDownList;
                Utility.BindDropDownList(ddlfooterpartinfo, ds.Tables[3]);
                //Utility.BindDropDownList(ddlPartInfo, ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                // DropDownList ddlfooterpartno = gvRequition.FooterRow.FindControl("ddlfooterpartno") as DropDownList;
                Utility.BindDropDownList(ddlfooterpartno, ds.Tables[5]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        ResetDetails();
    }

    private void BindSummaryTemp(DataTable dt)
    {
        try
        {
            DataTable DTSummary = dt;
            if (DTSummary.Rows.Count > 0)
            {
                gvRequition.DataSource = DTSummary;
                gvRequition.DataBind();
                ViewState["dirState"] = DTSummary;
            }
            else
            {
                gvRequition.DataSource = EmptyDT();
                gvRequition.DataBind();
                gvRequition.Rows[0].Visible = false;
            }
            Bind_GridDropdowns();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindSummaryTempForPrepareDT(DataTable dt)
    {
        try
        {
            DataTable DTSummary = dt;
            if (DTSummary.Rows.Count > 0)
            {
                gvRequition.DataSource = DTSummary;
                gvRequition.DataBind();
                ViewState["dirState"] = DTSummary;
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

    private void Bind_Lookup(int reqno)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartInfo, ds.Tables[0]);
                ddlPartInfo.SelectedValue = Convert.ToString(reqno);
                btnSave.Text = "Update";
                btnGenerate.Enabled = true;
                Bind_GridbyReq();
            }
            else
            {
                Utility.BindDropDownList(ddlPartInfo, ds.Tables[0]);
                btnGenerate.Enabled = false;
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
            ObjBOL.Operation = 6;
            if (ddlPartInfo.SelectedIndex > 0)
            {
                ObjBOL.Reqid = Convert.ToInt32(ddlPartInfo.SelectedValue);
            }
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                ViewState["Summary"] = dt;
                BindSummaryTemp(dt);
            }
            else
            {
                gvRequition.DataSource = EmptyDT();
                gvRequition.DataBind();
                gvRequition.Rows[0].Visible = false;
            }
            Bind_GridDropdowns();

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_GridbyReq()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 8;
            if (ddlPartInfo.SelectedIndex > 0)
            {
                ObjBOL.Reqid = Convert.ToInt32(ddlPartInfo.SelectedValue);
            }
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                ViewState["Summary"] = dt;
                BindSummaryTemp(dt);
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

    private void Bind_GridDetails()
    {
        try
        {
            DataTable selected = (DataTable)ViewState["Summary"];
            for (int i = selected.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = selected.Rows[i];
                if (dr["PartQty"].ToString() == "0")
                {
                    dr.Delete();
                }
            }
            gvRequition.DataBind();
            //selected.AcceptChanges();
            //if (selected.Rows.Count > 0)
            //{
            //    DataView dv = new DataView(selected);
            //    DataTable summarytemp = dv.ToTable("selected", false, "Partid", "PartQty", "Priority");
            //    ObjBOL.ReqDetails = summarytemp;
            //    if (ddlPartInfo.SelectedIndex > 0)
            //    {
            //        ObjBOL.Reqid = Convert.ToInt32(ddlPartInfo.SelectedValue);
            //    }
            //}
            //else
            //{
            //    DataTable emptytable = (DataTable)EmptyDTRequition();
            //    DataView dv = new DataView(emptytable);
            //    DataTable summarytemp = dv.ToTable("selected", false, "Partid", "PartQty", "Priority");
            //    ObjBOL.ReqDetails = summarytemp;
            //    gvRequition.DataSource = EmptyDT();
            //    gvRequition.DataBind();
            //    gvRequition.Rows[0].Visible = true;
            //}
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

            DataSet ds = new DataSet();
            ObjBOL.Operation = 13;
            ObjBOL.Reqid = Convert.ToInt32(ddlDivision.SelectedValue);
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProductLine, ds.Tables[0]);
                ddlProductLine.SelectedIndex = 0;
            }
            else
            {
                ddlProductLine.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }    

    #endregion

    #region DATATABLE FUNCTIONS

    private DataTable EmptyDT()
    {
        DataTable dtEmpty = new DataTable();
        try
        {
            dtEmpty.TableName = "GridSummary";
            dtEmpty.Columns.Add(new DataColumn("ReqDetailid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("ReqId", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Partid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Partnumber", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("PartDesc", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("revisionno", typeof(char)));
            dtEmpty.Columns.Add(new DataColumn("minqty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("maxqty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("stockinhand", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Intransit", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("InShop", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("PartQty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Priority", typeof(bool)));
            dtEmpty.Columns.Add(new DataColumn("Comments", typeof(string)));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(0, 0, 0, "", "", null, 0, 0, 0, 0, 0, 0, false, "");//adding row to the datatable  
            //dtEmpty.Rows.Add(datatRow);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    private DataTable EmptyDTRequition()
    {
        DataTable dt = new DataTable();
        try
        {
            //DataRow dr;            
            dt.TableName = "Summary";
            //TicketID   
            dt.Columns.Add(new DataColumn("ReqDetailid", typeof(int)));
            dt.Columns.Add(new DataColumn("ReqId", typeof(int)));
            dt.Columns.Add(new DataColumn("Partid", typeof(int)));
            dt.Columns.Add(new DataColumn("Partnumber", typeof(string)));
            dt.Columns.Add(new DataColumn("PartDesc", typeof(string)));
            dt.Columns.Add(new DataColumn("revisionno", typeof(string)));
            dt.Columns.Add(new DataColumn("minqty", typeof(int)));
            dt.Columns.Add(new DataColumn("maxqty", typeof(int)));
            dt.Columns.Add(new DataColumn("stockinhand", typeof(int)));
            dt.Columns.Add(new DataColumn("Intransit", typeof(int)));
            dt.Columns.Add(new DataColumn("InShop", typeof(int)));
            dt.Columns.Add(new DataColumn("PartQty", typeof(int)));
            dt.Columns.Add(new DataColumn("Priority", typeof(bool)));
            dt.Columns.Add(new DataColumn("Comments", typeof(string)));
            ViewState["Summary"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void PrePareDT(int ReqDetailid, int Reqid, int partid, string Partnumber, string revisionno, string partdescription, int min, int max, int stockinhand, int Intransit, int InShop, int qty, bool priority, string Comments)
    {
        try
        {
            DataTable dtCurrentTable = (DataTable)ViewState["Summary"];
            DataRow drCurrentRow = null;
            drCurrentRow = dtCurrentTable.NewRow();
            drCurrentRow["ReqDetailid"] = ReqDetailid;
            drCurrentRow["ReqId"] = Reqid;
            drCurrentRow["Partid"] = partid;
            drCurrentRow["Partnumber"] = Partnumber;
            drCurrentRow["revisionno"] = revisionno;
            drCurrentRow["PartDesc"] = partdescription;
            drCurrentRow["minqty"] = min;
            drCurrentRow["maxqty"] = max;
            drCurrentRow["stockinhand"] = stockinhand;
            drCurrentRow["Intransit"] = Intransit;
            drCurrentRow["InShop"] = InShop;
            drCurrentRow["PartQty"] = qty;
            drCurrentRow["Priority"] = priority;
            drCurrentRow["Comments"] = Comments;
            for (int i = dtCurrentTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtCurrentTable.Rows[i];
                int qty1 = qty;
                int qty2 = Convert.ToInt32(dr["PartQty"].ToString());
                if (dr["Partid"].ToString() == Convert.ToString(partid))
                {
                    drCurrentRow["PartQty"] = qty1 + qty2;
                    dr.Delete();
                }
            }
            if (drCurrentRow["Partnumber"].ToString() == "")
            {
                drCurrentRow.Delete();
            }
            dtCurrentTable.AcceptChanges();
            dtCurrentTable.Rows.Add(drCurrentRow);
            dtCurrentTable.DefaultView.Sort = "PartQty DESC";
            DataTable dt = (DataTable)ViewState["Summary"];
            BindSummaryTempForPrepareDT(dtCurrentTable);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void PopupGridEmpty()
    {
        try
        {
            gvInTransit.DataSource = "";
            gvInTransit.DataBind();
            gvInShop.DataSource = "";
            gvInShop.DataBind();
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

    #endregion

    #region VALIDATION FUNCTION

    private Boolean ValidationCheck()
    {
        try
        {
            if (ddlPreparedby.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select PreparedBy. !');", true);
                ddlPreparedby.Focus();
                return false;
            }
            if (txtReqNo.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Generate Requisition #. !');", true);
                txtReqNo.Focus();
                return false;
            }
            //if (ddlReqNo.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Requisition For. !');", true);
            //    ddlReqNo.Focus();
            //    return false;
            //}
            //if (ddlReqStatus.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Requisition Status. !');", true);
            //    ddlReqStatus.Focus();
            //    return false;
            //}
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

            if (ddlProductLine.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Product Line. !');", true);
                ddlProductLine.Focus();
                return false;
            }
            if (ddlfooterpartno.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Part#. !');", true);
                ddlfooterpartno.Focus();
                return false;
            }
            if (txtfooterqty.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Order Quantity. !');", true);
                txtfooterqty.Focus();
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

    #region EVENT FUNCTIONS LIKE Btn_Click, ddl_SelectedIndexChanged, gv_RowDelete etc.

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 2;
            msg = ObjBLL.GetRequisition(ObjBOL);
            if (msg != "")
            {
                txtReqNo.Text = msg;
                EnableControls();
                btnSave.Text = "Save";
            }
            else
            {
                txtReqNo.Text = String.Empty;
            }
            Reset();
            Bind_Grid();
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
            Savedata();
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
            ResetDetails();
            Reset();
            DisableControls();
            Bind_Grid();
            DisableControls();
            txtReqNo.Text = String.Empty;
            ddlfooterpartno.SelectedIndex = 0;
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
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataZero();
            rprt.Load(Server.MapPath("~/Reports/rptGenerateRequisition.rpt"));
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
            Utility.AddEditException(ex);
        }
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 11;
            ObjBOL.Reqid = Convert.ToInt32(ddlPartInfo.SelectedValue);
            ObjBOL.LoginUserId = Convert.ToInt32(Utility.GetCurrentSession().EmployeeID);
            msg = ObjBLL.UpdateIsSubmitted(ObjBOL);
            Utility.ShowMessage(this, msg);
            Reset();
            ResetDetails();
            Bind_Lookup(0);
            txtReqNo.Text = String.Empty;
            Bind_Grid();
            DisableControls();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DivisionListEvent();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPartInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPartInfo.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 5;
                ObjBOL.Reqid = Convert.ToInt32(ddlPartInfo.SelectedValue);
                ds = ObjBLL.GetControlsData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtReqNo.Text = ds.Tables[0].Rows[0]["ReqNo"].ToString();
                    //ddlReqNo.SelectedValue = ds.Tables[0].Rows[0]["ReqForId"].ToString();
                    ddlPreparedby.SelectedValue = ds.Tables[0].Rows[0]["PreparedBy"].ToString();
                    ddlPreparedByList.SelectedValue = ds.Tables[0].Rows[0]["PreparedBy"].ToString();
                    PreparedByListEvent();
                    ddlPartInfo.SelectedValue = ObjBOL.Reqid.ToString();
                    ddlApprovedby.SelectedValue = ds.Tables[0].Rows[0]["AppBy"].ToString();
                    txtTentativeshipdate.Text = cls.Converter(ds.Tables[0].Rows[0]["TentativeShipDate"].ToString());
                    txtActualShipdate.Text = cls.Converter(ds.Tables[0].Rows[0]["ActualShipDate"].ToString());
                    //ddlReqStatus.SelectedValue = ds.Tables[0].Rows[0]["ReqStatus"].ToString();
                    Bind_GridbyReq();
                    Bind_GridDropdowns();
                    btnSave.Enabled = true;
                    btnSubmit.Enabled = true;
                    btnSave.Text = "Update";
                    btnGenerate.Enabled = true;
                }
                else
                {
                    Reset();
                    txtReqNo.Text = String.Empty;
                }
            }
            else
            {
                Reset();
                Bind_Grid();
                btnSave.Enabled = false;
                btnGenerate.Enabled = false;
                btnSubmit.Enabled = false;
                txtReqNo.Text = String.Empty;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPreparedByList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            var temp = ddlPreparedByList.SelectedValue;
            Reset();
            ResetDetails();
            txtReqNo.Text = "";
            Bind_Grid();
            ddlPreparedByList.SelectedValue = temp;
            PreparedByListEvent();
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
            IntermediaryForDDLFooterInfo();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlProductLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ProductLineEvent(ddlProductLine.SelectedValue);
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
            IntermediaryForDDLFooterNo();
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
            string msg = "";
            DataTable dtCurrentTable = (DataTable)ViewState["Summary"];
            if (ddlPartInfo.SelectedIndex == 0 || ddlPartInfo.SelectedIndex == -1)
            {
                dtCurrentTable.Rows.RemoveAt(e.RowIndex);
            }
            else
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 8;
                if (ddlPartInfo.SelectedIndex > 0)
                {
                    ObjBOL.Reqid = Convert.ToInt32(ddlPartInfo.SelectedValue);
                }
                ds = ObjBLL.GetControlsData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvRequition.DataSource = ds.Tables[0];
                    gvRequition.DataBind();
                    ObjBOL.Operation = 9;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count != dtCurrentTable.Rows.Count)
                        {
                            dtCurrentTable.Rows.RemoveAt(e.RowIndex);
                        }
                        else
                        {
                            GridViewRow row = gvRequition.Rows[e.RowIndex];
                            Int32 ID = Convert.ToInt32(gvRequition.DataKeys[e.RowIndex].Value);
                            ObjBOL.Reqid = ID;
                            msg = ObjBLL.DeleteReqData(ObjBOL);
                            dtCurrentTable.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                    else
                    {
                        dtCurrentTable.Rows.RemoveAt(e.RowIndex);
                    }
                    gvRequition.DataSource = dtCurrentTable;
                    gvRequition.DataBind();
                    dtCurrentTable.AcceptChanges();
                    BindSummaryTemp(dtCurrentTable);
                    Bind_GridbyReq();
                }
                else
                {
                    dtCurrentTable.Rows.RemoveAt(e.RowIndex);
                }
            }
            gvRequition.DataSource = dtCurrentTable;
            gvRequition.DataBind();
            dtCurrentTable.AcceptChanges();
            BindSummaryTemp(dtCurrentTable);
            Bind_GridDropdowns();
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
            PopupGridEmpty();
            if (e.CommandName == "Select")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblID = (Label)clickedRow.FindControl("lblpartid");
                hfpartid.Value = Convert.ToString(lblID.Text);
                ObjBOL.partid = Convert.ToInt32(hfpartid.Value);
                ObjBOL.Operation = 1;
                ds = ObjBLL.GetTransitionData(ObjBOL);
                gvInTransit.DataSource = ds.Tables[0];
                gvInTransit.DataBind();
                ModalPopupExtender1.Show();
            }
            else if (e.CommandName == "Select2")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblID = (Label)clickedRow.FindControl("lblpartid");
                hfpartid.Value = Convert.ToString(lblID.Text);
                ObjBOL.partid = Convert.ToInt32(hfpartid.Value);
                ObjBOL.Operation = 1;
                ds = ObjBLL.GetInShopData(ObjBOL);
                gvInShop.DataSource = ds.Tables[0];
                gvInShop.DataBind();
                ModalPopupExtender2.Show();
            }
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
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                DataView dataView = new DataView(dtrslt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvRequition.DataSource = dataView;
                gvRequition.DataBind();
                //dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                //gvProposalSearch.DataSource = dtrslt;
                //gvProposalSearch.DataBind();
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + "DESC";
                gvRequition.DataSource = dtrslt;
                gvRequition.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Save Data Functions

    private void Savedata()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = "";
                ObjBOL.Operation = 3;
                ObjBOL.ReqNo = txtReqNo.Text;
                //ObjBOL.ReqForId = Convert.ToInt32(ddlReqNo.SelectedValue);
                ObjBOL.PreparedBy = Convert.ToInt32(ddlPreparedby.SelectedValue);
                ObjBOL.AppBy = Convert.ToInt32(ddlApprovedby.SelectedValue);
                if (txtTentativeshipdate.Text != "")
                {
                    ObjBOL.TentativeShipDate = Utility.ConvertDate(txtTentativeshipdate.Text);
                }
                if (txtActualShipdate.Text != "")
                {
                    ObjBOL.ActualShipDate = Utility.ConvertDate(txtActualShipdate.Text);
                }
                //ObjBOL.ReqStatus = Convert.ToInt32(ddlReqStatus.SelectedValue);
                CheckGridBeforeSave();
                DataTable selected = (DataTable)ViewState["Summary"];
                var temp = false;
                for (int i = selected.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = selected.Rows[i];
                    var temp1 = dr["PartQty"].ToString();
                    if (temp1.Trim() != "0")
                    {
                        temp = true;
                    }
                    if (dr["PartQty"].ToString() == "0")
                    {
                        dr.Delete();
                    }
                }
                if (!temp)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Order Quantity. !');", true);
                    //txtfooterqty.Focus();
                }
                else
                {
                    selected.AcceptChanges();
                    if (selected.Rows.Count > 0)
                    {
                        DataView dv = new DataView(selected);
                        DataTable summarytemp = dv.ToTable("selected", false, "Partid", "PartQty", "Priority", "Comments");
                        ObjBOL.ReqDetails = summarytemp;
                        if (ddlPartInfo.SelectedIndex > 0)
                        {
                            ObjBOL.Reqid = Convert.ToInt32(ddlPartInfo.SelectedValue);
                        }
                    }
                    else
                    {
                        DataTable emptytable = (DataTable)EmptyDTRequition();
                        DataView dv = new DataView(emptytable);
                        DataTable summarytemp = dv.ToTable("selected", false, "Partid", "PartQty", "Priority", "Comments");
                        ObjBOL.ReqDetails = summarytemp;
                    }
                    ObjBOL.LoginUserId = Convert.ToInt32(Utility.GetCurrentSession().EmployeeID);
                    msg = ObjBLL.SaveRequisitionData(ObjBOL);
                    if (btnSave.Text == "Save")
                    {
                        Utility.ShowMessage(this, "Requisition Created Successfully");
                    }
                    else if (btnSave.Text == "Update")
                    {
                        Utility.ShowMessage(this, "Requisition Updated Successfully");
                    }

                    if (msg != "")
                    {
                        ddlPreparedByList.SelectedValue = ObjBOL.PreparedBy.ToString();
                        PreparedByListEvent();
                        ddlPartInfo.SelectedValue = msg;
                    }
                    Bind_GridDropdowns();
                    btnSubmit.Enabled = true;
                }
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
            CheckGridBeforeSave();
            //string partid = (gvRequition.Rows[0].FindControl("ddlfooterpartinfo") as DropDownList).SelectedValue;
            string partid = ddlfooterpartinfo.SelectedValue;
            //string partnumber = (gvRequition.Rows[0].FindControl("ddlfooterpartno") as DropDownList).SelectedItem.Text;
            string partnumber = ddlfooterpartno.SelectedItem.Text;
            //string partdescription = (gvRequition.Rows[0].FindControl("ddlfooterpartinfo") as DropDownList).SelectedItem.Text;
            string partdescription = ddlfooterpartinfo.SelectedItem.Text;
            //string revisionno = (gvRequition.Rows[0].FindControl("lblfooterpartrevisionno") as Label).Text;
            string revisionno = lblfooterpartrevisionno.Text;
            //string qty = (gvRequition.Rows[0].FindControl("txtfooterqty") as TextBox).Text;
            string qty = txtfooterqty.Text;
            //string min = (gvRequition.Rows[0].FindControl("lblFooterMin") as Label).Text;
            string min = lblFooterMin.Text;
            //string max = (gvRequition.Rows[0].FindControl("lblFooterMax") as Label).Text;
            string max = lblFooterMax.Text;
            //string stockinhand = (gvRequition.Rows[0].FindControl("lblFooterStockinhand") as Label).Text;
            string stockinhand = lblFooterStockinhand.Text;
            //string lblInTransit = (gvRequition.Rows[0].FindControl("lnkFooterTransit") as LinkButton).Text;
            string lblInTransit = lnkFooterTransit.Text;
            //string lblInShop = (gvRequition.Rows[0].FindControl("lnkFooterShop") as LinkButton).Text;
            string lblInShop = lnkFooterShop.Text;
            //bool chkpriority = (gvRequition.Rows[0].FindControl("chkfooterPriority") as CheckBox).Checked;
            bool chkpriority = chkfooterPriority.Checked;
            string comments = txtcomments.Text;
            int reqid = 0;
            if (ddlPartInfo.SelectedIndex > 0)
            {
                reqid = Convert.ToInt32(ddlPartInfo.SelectedValue);
            }
            if (min == "")
            {
                min = "0";
            }
            if (max == "")
            {
                max = "0";
            }
            if (stockinhand == "")
            {
                stockinhand = "0";
            }
            if (lblInTransit == "")
            {
                lblInTransit = "0";
            }
            if (lblInShop == "")
            {
                lblInShop = "0";
            }

            PrePareDT(0, reqid, Convert.ToInt32(partid), partnumber, revisionno, partdescription, Convert.ToInt32(min), Convert.ToInt32(max), Convert.ToInt32(stockinhand), Convert.ToInt32(lblInShop), Convert.ToInt32(lblInTransit), Convert.ToInt32(qty), chkpriority, comments);
            gvRequition.DataBind();
            ddlfooterpartinfo.SelectedValue = partid;
            IntermediaryForDDLFooterInfo();

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckGridBeforeSave()
    {
        try
        {
            DataTable dt = EmptyDTRequition();
            DataRow dr;
            foreach (GridViewRow row in gvRequition.Rows)
            {
                TextBox qty = ((TextBox)row.FindControl("txtqty"));
                Label partid = ((Label)row.FindControl("lblpartid"));
                Label partnum = ((Label)row.FindControl("lblpartnumber"));
                Label partdesc = ((Label)row.FindControl("lblPartinfo"));
                Label partrevision = ((Label)row.FindControl("lblpartrevno"));
                Label min = ((Label)row.FindControl("lblMin"));
                Label max = ((Label)row.FindControl("lblMax"));
                LinkButton lblInTransit = ((LinkButton)row.FindControl("lnkItemTranstit"));
                LinkButton lblInShop = ((LinkButton)row.FindControl("lnkItemShop"));
                Label stockinhand = ((Label)row.FindControl("lblStockinHand"));
                bool isSelected = (row.FindControl("chkpriority") as CheckBox).Checked;
                TextBox comments = ((TextBox)row.FindControl("txtcomments"));
                dr = dt.NewRow();
                if (ddlPartInfo.SelectedIndex > 0)
                {
                    dr[1] = ddlPartInfo.SelectedValue;
                }
                else
                {
                    dr[1] = 0;
                }
                dr[2] = Convert.ToInt32(partid.Text);
                dr[3] = partnum.Text;
                dr[4] = partdesc.Text;
                if (partrevision.Text != "")
                {
                    dr[5] = Convert.ToChar(partrevision.Text);
                }
                if (min.Text != "")
                {
                    dr[6] = Convert.ToInt32(min.Text);
                }
                else
                {
                    dr[6] = 0;
                }
                if (max.Text != "")
                {
                    dr[7] = Convert.ToInt32(max.Text);
                }
                else
                {
                    dr[7] = 0;
                }
                if (stockinhand.Text != "")
                {
                    dr[8] = Convert.ToInt32(stockinhand.Text);
                }
                else
                {
                    dr[8] = 0;
                }
                if (lblInTransit.Text != "")
                {
                    dr[9] = Convert.ToInt32(lblInTransit.Text);
                }
                else
                {
                    dr[9] = 0;
                }
                if (lblInShop.Text != "")
                {
                    dr[10] = Convert.ToInt32(lblInShop.Text);
                }
                else
                {
                    dr[10] = 0;
                }
                if (qty.Text != "")
                {
                    dr[11] = Convert.ToInt32(qty.Text);
                }
                else
                {
                    dr[11] = 0;
                }
                dr[12] = isSelected;
                dr[13] = comments.Text;

                dt.Rows.Add(dr);
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow drdelete = dt.Rows[i];
                    if (drdelete["Partid"].ToString() == Convert.ToString(0))
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
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Event Functions

    private void ProductLineEvent(string Productid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 12;
            ObjBOL.Productid = Int32.Parse(Productid);
            ds = ObjBLL.GetRequisitionPartno(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlfooterpartno, ds.Tables[0]);
                Utility.BindDropDownList(ddlfooterpartinfo, ds.Tables[0]);
            }
            else
            {
                var DivisionId = ddlDivision.SelectedValue;
                ResetDetails();
                ClearFooterPartInfoAndNoList();
                ddlDivision.SelectedValue = DivisionId;
                bindProductLine();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        ResetGrid();
    }

    private void PreparedByListEvent()
    {
        try
        {
            if (ddlPreparedByList.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 15;
                ObjBOL.PreparedBy = Int32.Parse(ddlPreparedByList.SelectedValue);
                ds = ObjBLL.GetControlsData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlPartInfo, ds.Tables[0]);
                    ddlPartInfo.SelectedIndex = 0;
                }
                else
                {
                    ddlPartInfo.Items.Clear();
                }
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

    private void DivisionListEvent()
    {
        try
        {
            if (ddlDivision.SelectedIndex > 0) 
            {
                var DivisionId = ddlDivision.SelectedValue;
                ResetDetails();
                ClearFooterPartInfoAndNoList();
                ddlDivision.SelectedValue = DivisionId;
                bindProductLine();
            }
            else
            {
                ResetDetails();
                Bind_Ppage();
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void FooterPartNoAndInfoEvent(string InfoOrNo)
    {
        try
        {

            DataSet ds = new DataSet();
            ObjBOL.Operation = 7;
            if (InfoOrNo == "INFO")
            {
                ObjBOL.Productid = Convert.ToInt32(ddlfooterpartinfo.SelectedValue);
            }
            else if (InfoOrNo == "NO")
            {
                ObjBOL.Productid = Convert.ToInt32(ddlfooterpartno.SelectedValue);
            }
            int partId = ObjBOL.Productid;
            ObjBOL.revisionno = lblfooterpartrevisionno.Text;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {   
                ddlDivision.SelectedValue = ds.Tables[0].Rows[0]["DivisionId"].ToString();
                bindProductLine();
                ddlProductLine.SelectedValue = ds.Tables[0].Rows[0]["ProductId"].ToString();
                ProductLineEvent(ds.Tables[0].Rows[0]["ProductId"].ToString());
                ddlfooterpartno.SelectedValue = partId.ToString();
                ddlfooterpartinfo.SelectedValue = partId.ToString();
                //ddlfooterpartinfo.SelectedValue = ds.Tables[0].Rows[0]["partid"].ToString();
                lblfooterpartrevisionno.Text = ds.Tables[0].Rows[0]["revisionno"].ToString();
                lblFooterMin.Text = ds.Tables[0].Rows[0]["minqty"].ToString();
                if (lblFooterMin.Text == "")
                {
                    lblFooterMin.Text = "0";
                }
                lblFooterMax.Text = ds.Tables[0].Rows[0]["maxqty"].ToString();
                if (lblFooterMax.Text == "")
                {
                    lblFooterMax.Text = "0";
                }
                lblFooterStockinhand.Text = ds.Tables[0].Rows[0]["stockinhand"].ToString();
                if (lblFooterStockinhand.Text == "")
                {
                    lblFooterStockinhand.Text = "0";
                }
                lnkFooterTransit.Text = ds.Tables[0].Rows[0]["Intransit"].ToString();
                lnkFooterShop.Text = ds.Tables[0].Rows[0]["InShop"].ToString();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void IntermediaryForDDLFooterInfo()
    {
        try
        {
            if (ddlfooterpartinfo.SelectedIndex > 0)
            {
                FooterPartNoAndInfoEvent("INFO");
            }
            else
            {
                ResetForFooterPartInfoAndNo();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void IntermediaryForDDLFooterNo()
    {
        try
        {
            if (ddlfooterpartno.SelectedIndex > 0)
            {
                FooterPartNoAndInfoEvent("NO");
            }
            else
            {
                ResetForFooterPartInfoAndNo();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Resets

    private void Reset()
    {
        try
        {
            ddlPreparedByList.SelectedIndex = 0;
            Bind_ControlPartInfo();
            if (ddlPartInfo.Items.Count > 0)
            {
                ddlPartInfo.SelectedIndex = 0;
            }
            //ddlReqNo.SelectedIndex = 0;
            ddlPreparedby.SelectedIndex = 0;
            ddlApprovedby.SelectedIndex = 0;
            txtTentativeshipdate.Text = String.Empty;
            txtActualShipdate.Text = String.Empty;
            // ddlReqStatus.SelectedIndex = 0;
            btnSave.Text = "Save";
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
            ddlProductLine.Items.Clear();
            ddlDivision.SelectedIndex = 0;
            ddlfooterpartno.SelectedIndex = 0;
            ddlfooterpartinfo.SelectedIndex = 0;
            lblfooterpartrevisionno.Text = string.Empty;
            lblFooterMin.Text = string.Empty;
            lblFooterMax.Text = string.Empty;
            lblFooterStockinhand.Text = string.Empty;
            txtfooterqty.Text = string.Empty;
            lnkFooterTransit.Text = string.Empty;
            lnkFooterShop.Text = string.Empty;
            lnkFooterTransit.Text = string.Empty;
            chkfooterPriority.Checked = false;
            txtcomments.Text = string.Empty;
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
            lblFooterMin.Text = string.Empty;
            lblFooterMax.Text = string.Empty;
            lblFooterStockinhand.Text = string.Empty;
            txtfooterqty.Text = string.Empty;
            lnkFooterTransit.Text = string.Empty;
            lnkFooterShop.Text = string.Empty;
            lnkFooterTransit.Text = string.Empty;
            chkfooterPriority.Checked = false;
            txtcomments.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetForFooterPartInfoAndNo()
    {
        try
        {
            var DivisionId = ddlDivision.SelectedValue;
            var ProductLineId = ddlProductLine.SelectedValue;
            ResetDetails();
            ddlDivision.SelectedValue = DivisionId;
            bindProductLine();
            ddlProductLine.SelectedValue = ProductLineId;
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void ClearFooterPartInfoAndNoList()
    {
        try
        {
            ddlfooterpartno.Items.Clear();           
            ddlfooterpartinfo.Items.Clear();            
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Report

    private DataTable ReportDataZero()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[INV_GenerateRequisition] '" + ddlPartInfo.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    #endregion

    #region Enable/Disable controls

    private void EnableControls()
    {
        try
        {
            btnSubmit.Enabled = true;
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
            btnSubmit.Enabled = false;
            btnGenerate.Enabled = false;
            btnSave.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

}