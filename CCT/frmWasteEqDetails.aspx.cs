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
public partial class CCT_frmWasteEqDetails : System.Web.UI.Page
{
    BOLWasteEq ObjBOL = new BOLWasteEq();
    BLLManageWasteEqDetails ObjBLL = new BLLManageWasteEqDetails();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Control();
                Bind_Grid();
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
            ObjBOL.Operation = 1;
            ds = ObjBLL.BindDropDown(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlJobId, ds.Tables[0]);
                Utility.BindDropDownList(ddlproject, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlproject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlJobId.SelectedValue = ddlproject.SelectedValue;
            FillDetails();
            Bind_Grid();
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
            if (ddlJobId.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Job ID. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Job ID. !");
                ddlJobId.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private Boolean ValidationCheckAccessory()
    {
        try
        {
            DropDownList ddlftmanufacturer = (gvWasteEqDetails.FooterRow.FindControl("ddlftmanufacturer") as DropDownList);
            DropDownList ddlftwasteeqmanufacturer = (gvWasteEqDetails.FooterRow.FindControl("ddlftwasteeqmanufacturer") as DropDownList);
            DropDownList ddlftacc = (gvWasteEqDetails.FooterRow.FindControl("ddlftacc") as DropDownList);
            DropDownList ddlftusedforstock = (gvWasteEqDetails.FooterRow.FindControl("ddlftusedforstock") as DropDownList);
            //TextBox txtftgvrequestedon = (gvWasteEqDetails.FooterRow.FindControl("txtFRequestedOn") as TextBox);
            //TextBox txtftgvtrackingno = (gvWasteEqDetails.FooterRow.FindControl("txtFTrackingNo") as TextBox);
            //TextBox txtftgvestimateddeliverydate = (gvWasteEqDetails.FooterRow.FindControl("txtFEstDeliveryDate") as TextBox);
            //TextBox txtftgvrequestonshopon = (gvWasteEqDetails.FooterRow.FindControl("txtFreqonshopon") as TextBox);
            //TextBox txtftgvrecdate = (gvWasteEqDetails.FooterRow.FindControl("txtFReceivedDate") as TextBox);
            //txtftgvrecdate
            if (ddlftmanufacturer.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Manufacturer. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Manufacturer. !");
                ddlftmanufacturer.Focus();
                return false;
            }
            if (ddlftwasteeqmanufacturer.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Waste Equipment. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Waste Equipment. !");
                ddlftwasteeqmanufacturer.Focus();
                return false;
            }
            if (ddlftacc.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Accessory. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Accessory. !");
                ddlftacc.Focus();
                return false;
            }
            if (ddlftusedforstock.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Used for Stock. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Used for Stock. !");
                ddlftusedforstock.Focus();
                return false;
            }


        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private Boolean ValidationCheckEditAccessory()
    {
        try
        {
            DropDownList ddleditmanufacturer = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("ddlgvmanufacturer") as DropDownList;
            DropDownList ddleditwasteeqmanufacturer = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("ddlgvwasteeq") as DropDownList;
            DropDownList ddleditacc = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("ddlgvacc") as DropDownList;
            DropDownList ddleditusedforstock = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("ddlgvusedforstock") as DropDownList;
            //TextBox txteditgvrequestedondate = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("txtEditRequestedOn") as TextBox;
            //TextBox txteditgvtrackingno = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("txtEdittrackingno") as TextBox;
            //TextBox txteditgvestdeliverydate = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("txtEditEstDeliveryDate") as TextBox;
            //TextBox txteditgvreqonshopon = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("txtEditreqonshopon") as TextBox;
            //TextBox txteditgvrecdate = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("txtEditreceiveddate") as TextBox;
            //txtftgvrecdate
            if (ddleditmanufacturer.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Manufacturer. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Manufacturer. !");
                ddleditmanufacturer.Focus();
                return false;
            }
            if (ddleditwasteeqmanufacturer.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Waste Equipment. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Waste Equipment. !");
                ddleditwasteeqmanufacturer.Focus();
                return false;
            }
            if (ddleditacc.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Accessory. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Accessory. !");
                ddleditacc.Focus();
                return false;
            }
            if (ddleditusedforstock.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Used for Stock. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Used for Stock. !");
                ddleditusedforstock.Focus();
                return false;
            }


        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void ddlJobId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlproject.SelectedValue = ddlJobId.SelectedValue;
            FillDetails();
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillDetails()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.JobID = ddlJobId.SelectedValue;
            ds = ObjBLL.FillDetails(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                txtReleasedDate.Text = ds.Tables[1].Rows[0]["ReleaseDate"].ToString();
                txtShipDate.Text = ds.Tables[1].Rows[0]["ShipDate"].ToString();
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindFooterDropdownlist()
    {
        try
        {
            DropDownList ddlftmanufacturer = (gvWasteEqDetails.FooterRow.FindControl("ddlftmanufacturer") as DropDownList);
            DropDownList ddlftwasteeqmanufacturer = (gvWasteEqDetails.FooterRow.FindControl("ddlftwasteeqmanufacturer") as DropDownList);
            DropDownList ddlftacc = (gvWasteEqDetails.FooterRow.FindControl("ddlftacc") as DropDownList);
            DropDownList ddlftusedforstock = (gvWasteEqDetails.FooterRow.FindControl("ddlftusedforstock") as DropDownList);
            DropDownList ddlftgvremarks = (gvWasteEqDetails.FooterRow.FindControl("ddlftgvremarks") as DropDownList);
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.JobID = ddlJobId.SelectedValue;
            ds = ObjBLL.FillDetails(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlftmanufacturer, ds.Tables[1]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlftgvremarks, ds.Tables[4]);
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
            dtEmpty.Columns.Add(new DataColumn("id", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("makerid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("makername", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("eqid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("WasteEqName", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("accid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("acc_name", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("usedfromstock", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("requestondate", typeof(DateTime)));
            dtEmpty.Columns.Add(new DataColumn("trackingno", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("estimatdeliverydate", typeof(DateTime)));
            dtEmpty.Columns.Add(new DataColumn("reqbyshopon", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("acc_recieved", typeof(DateTime)));
            dtEmpty.Columns.Add(new DataColumn("remarks", typeof(string)));
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
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.JobID = ddlJobId.SelectedValue;
            ds = ObjBLL.FillDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvWasteEqDetails.DataSource = ds;
                gvWasteEqDetails.DataBind();
            }
            else
            {
                gvWasteEqDetails.DataSource = EmptyDT();
                gvWasteEqDetails.DataBind();
                gvWasteEqDetails.Rows[0].Visible = false;
            }
            BindFooterDropdownlist();
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
            foreach (Control ctrl in PanDetails.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ((TextBox)(ctrl)).Text = String.Empty;
                }
            }
            ddlJobId.SelectedIndex = -1;
            ddlproject.SelectedIndex = -1;
            gvWasteEqDetails.DataSource = EmptyDT();
            gvWasteEqDetails.DataBind();
            gvWasteEqDetails.Rows[0].Visible = false;
            //btnGenerateReport.Enabled = false;
            //btnExporttoExcel.Enabled = false;
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
            SaveData();
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

    protected void gvWasteEqDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvWasteEqDetails.EditIndex = e.NewEditIndex;
            Bind_Grid();
            DropDownList ddlgvmanufacturer = gvWasteEqDetails.Rows[e.NewEditIndex].FindControl("ddlgvmanufacturer") as DropDownList;
            Label lblgvmanufact = gvWasteEqDetails.Rows[e.NewEditIndex].FindControl("lblgvmanufact") as Label;
            DropDownList ddlgvwasteeq = gvWasteEqDetails.Rows[e.NewEditIndex].FindControl("ddlgvwasteeq") as DropDownList;
            Label lblgvwateequp = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("lblgvwateequp") as Label;
            DropDownList ddlgvacc = gvWasteEqDetails.Rows[e.NewEditIndex].FindControl("ddlgvacc") as DropDownList;
            Label lblgvac = gvWasteEqDetails.Rows[e.NewEditIndex].FindControl("lblgvac") as Label;
            DropDownList ddlgvusedforstock = gvWasteEqDetails.Rows[e.NewEditIndex].FindControl("ddlgvusedforstock") as DropDownList;
            Label lblgvusedinstock = gvWasteEqDetails.Rows[e.NewEditIndex].FindControl("lblgvusedinstock") as Label;
            DropDownList ddlgvremarks = gvWasteEqDetails.Rows[e.NewEditIndex].FindControl("ddlgvremarks") as DropDownList;
            Label lblgvremark = gvWasteEqDetails.Rows[e.NewEditIndex].FindControl("lblgvremark") as Label;
            DataSet ds = new DataSet();
            int ID = Convert.ToInt32(gvWasteEqDetails.DataKeys[e.NewEditIndex].Value);
            ObjBOL.Operation = 4;
            ObjBOL.Detailid = ID;
            ds = ObjBLL.FillDetails(ObjBOL);
            if (ds.Tables[5].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlgvmanufacturer, ds.Tables[1]);
                    ddlgvmanufacturer.SelectedValue = ds.Tables[5].Rows[0]["makerid"].ToString();
                }
                if (ddlgvmanufacturer.SelectedIndex > 0)
                {
                    DataSet dsEq = new DataSet();
                    ObjBOL.makerid = Convert.ToInt32(ddlgvmanufacturer.SelectedValue);
                    dsEq = ObjBLL.FillDetails(ObjBOL);
                    if (dsEq.Tables[2].Rows.Count > 0)
                    {
                        Utility.BindDropDownList(ddlgvwasteeq, dsEq.Tables[2]);
                        ddlgvwasteeq.SelectedValue = ds.Tables[5].Rows[0]["eqid"].ToString();
                    }
                }
                if (ddlgvwasteeq.SelectedIndex > 0)
                {
                    DataSet dsacc = new DataSet();
                    ObjBOL.WasteEq_id = Convert.ToInt32(ddlgvwasteeq.SelectedValue);
                    dsacc = ObjBLL.FillDetails(ObjBOL);
                    if (dsacc.Tables[3].Rows.Count > 0)
                    {
                        Utility.BindDropDownList(ddlgvacc, dsacc.Tables[3]);
                        ddlgvacc.SelectedValue = ds.Tables[5].Rows[0]["accid"].ToString();
                    }
                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlgvremarks, ds.Tables[4]);
                    ddlgvremarks.SelectedValue = ds.Tables[5].Rows[0]["remarksid"].ToString();
                }
                ddlgvusedforstock.SelectedValue = lblgvusedinstock.Text;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvWasteEqDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvWasteEqDetails.EditIndex = -1;
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvWasteEqDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            if (ValidationCheckEditAccessory() == true)
            {
                string msg = "";
                GridViewRow row = gvWasteEqDetails.Rows[e.RowIndex];
                int ID = Convert.ToInt32(gvWasteEqDetails.DataKeys[e.RowIndex].Value);
                ObjBOL.Operation = 6;
                ObjBOL.id = ID;
                ObjBOL.JobID = ddlJobId.SelectedValue;
                ObjBOL.makerid = Convert.ToInt32((row.FindControl("ddlgvmanufacturer") as DropDownList).SelectedValue);
                ObjBOL.eqid = Convert.ToInt32((row.FindControl("ddlgvwasteeq") as DropDownList).SelectedValue);
                ObjBOL.accid = Convert.ToInt32((row.FindControl("ddlgvacc") as DropDownList).SelectedValue);
                TextBox txtgvreqondate = row.FindControl("txtEditRequestedOn") as TextBox;
                ObjBOL.Employeeid = Utility.GetCurrentUser();
                ObjBOL.usedfromstock = (row.FindControl("ddlgvusedforstock") as DropDownList).SelectedValue;
                if (txtgvreqondate.Text != "")
                {
                    ObjBOL.requestondate = Utility.ConvertDate(txtgvreqondate.Text);
                }
                TextBox txtEditTrackingNo = row.FindControl("txtEdittrackingno") as TextBox;
                if (txtEditTrackingNo.Text != "")
                {
                    ObjBOL.TrackingNo = (row.FindControl("txtEdittrackingno") as TextBox).Text;
                }
                TextBox txtEditEstDeliveryDate = row.FindControl("txtEditEstDeliveryDate") as TextBox;
                if (txtEditEstDeliveryDate.Text != "")
                {
                    ObjBOL.estimatdeliverydate = Utility.ConvertDate((row.FindControl("txtEditEstDeliveryDate") as TextBox).Text);
                }
                TextBox txtEditreqonshopon = row.FindControl("txtEditreqonshopon") as TextBox;
                if (txtEditreqonshopon.Text != "")
                {
                    ObjBOL.requestonshopon = (row.FindControl("txtEditreqonshopon") as TextBox).Text;
                }
                TextBox txtEditReceivedDate = row.FindControl("txtEditreceiveddate") as TextBox;
                if (txtEditReceivedDate.Text != "")
                {
                    ObjBOL.acc_recieved = Utility.ConvertDate((row.FindControl("txtEditreceiveddate") as TextBox).Text);
                }
                DropDownList ddlgvremarks = row.FindControl("ddlgvremarks") as DropDownList;
                if (ddlgvremarks.SelectedItem.Text != "Select")
                {
                    ObjBOL.remarks = (row.FindControl("ddlgvremarks") as DropDownList).SelectedItem.Text;
                }
                msg = ObjBLL.SaveWasteEq(ObjBOL);
                if (msg.Trim() != "")
                {
                    Utility.ShowMessage_Success(Page, msg);
                    Utility.MaintainLogsSpecial("frmWasteEqDetails", "Update", ID.ToString());
                    gvWasteEqDetails.EditIndex = -1;
                    Bind_Grid();
                }
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
                if (ValidationCheckAccessory() == true)
                {
                    DropDownList ddlftmanufacturer = (gvWasteEqDetails.FooterRow.FindControl("ddlftmanufacturer") as DropDownList);
                    DropDownList ddlftwasteeqmanufacturer = (gvWasteEqDetails.FooterRow.FindControl("ddlftwasteeqmanufacturer") as DropDownList);
                    DropDownList ddlftacc = (gvWasteEqDetails.FooterRow.FindControl("ddlftacc") as DropDownList);
                    DropDownList ddlftusedforstock = (gvWasteEqDetails.FooterRow.FindControl("ddlftusedforstock") as DropDownList);
                    DropDownList ddlftgvremarks = (gvWasteEqDetails.FooterRow.FindControl("ddlftgvremarks") as DropDownList);
                    TextBox txtftgvrequestedon = (gvWasteEqDetails.FooterRow.FindControl("txtFRequestedOn") as TextBox);
                    TextBox txtftgvtrackingno = (gvWasteEqDetails.FooterRow.FindControl("txtFTrackingNo") as TextBox);
                    TextBox txtftgvestimateddeliverydate = (gvWasteEqDetails.FooterRow.FindControl("txtFEstDeliveryDate") as TextBox);
                    TextBox txtftgvrequestonshopon = (gvWasteEqDetails.FooterRow.FindControl("txtFreqonshopon") as TextBox);
                    TextBox txtftgvrecdate = (gvWasteEqDetails.FooterRow.FindControl("txtFReceivedDate") as TextBox);
                    string msg = "";
                    ObjBOL.JobID = ddlJobId.SelectedValue;
                    ObjBOL.makerid = Convert.ToInt32(ddlftmanufacturer.SelectedValue);
                    ObjBOL.eqid = Convert.ToInt32(ddlftwasteeqmanufacturer.SelectedValue);
                    ObjBOL.accid = Convert.ToInt32(ddlftacc.SelectedValue);
                    ObjBOL.usedfromstock = ddlftusedforstock.SelectedItem.Text;
                    if (txtftgvrequestedon.Text != "")
                    {
                        ObjBOL.requestondate = Utility.ConvertDate(txtftgvrequestedon.Text);
                    }
                    if (txtftgvtrackingno.Text != "")
                    {
                        ObjBOL.TrackingNo = txtftgvtrackingno.Text;
                    }
                    if (txtftgvestimateddeliverydate.Text != "")
                    {
                        ObjBOL.estimatdeliverydate = Utility.ConvertDate(txtftgvestimateddeliverydate.Text);
                    }
                    ObjBOL.requestonshopon = txtftgvrequestonshopon.Text;
                    ObjBOL.Employeeid = Utility.GetCurrentUser();
                    if (ddlftgvremarks.SelectedIndex > 0)
                    {
                        ObjBOL.remarks = ddlftgvremarks.SelectedItem.Text;
                    }
                    if (txtftgvrecdate.Text != "")
                    {
                        ObjBOL.acc_recieved = Utility.ConvertDate(txtftgvrecdate.Text);
                    }
                    ObjBOL.Operation = 5;
                    msg = ObjBLL.SaveWasteEq(ObjBOL);
                    if (msg.Trim() != "")
                    {
                        Utility.ShowMessage_Success(Page, msg);
                        Utility.MaintainLogsSpecial("frmWasteEqDetails", "Save", ddlJobId.SelectedValue);
                        Bind_Grid();
                    }
                }
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
            SaveData();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetftManufacturer()
    {
        try
        {
            DropDownList ddlftmanufacturer = (gvWasteEqDetails.FooterRow.FindControl("ddlftmanufacturer") as DropDownList);
            DropDownList ddlftwasteeqmanufacturer = (gvWasteEqDetails.FooterRow.FindControl("ddlftwasteeqmanufacturer") as DropDownList);
            DropDownList ddlftacc = (gvWasteEqDetails.FooterRow.FindControl("ddlftacc") as DropDownList);
            DataSet ds = new DataSet();
            ObjBOL.Operation = 7;
            ObjBOL.makerid = Convert.ToInt32(ddlftmanufacturer.SelectedValue);
            ds = ObjBLL.GetWasteEquipment(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlftwasteeqmanufacturer, ds.Tables[0]);
                if (ddlftacc.SelectedIndex > 0)
                {
                    ddlftacc.DataSource = "";
                    ddlftacc.DataBind();
                }
            }
            else
            {
                ddlftwasteeqmanufacturer.DataSource = "";
                ddlftwasteeqmanufacturer.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlftmanufacturer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetftManufacturer();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetftAccessory()
    {
        try
        {
            DropDownList ddlftwasteeqmanufacturer = (gvWasteEqDetails.FooterRow.FindControl("ddlftwasteeqmanufacturer") as DropDownList);
            DropDownList ddlftacc = (gvWasteEqDetails.FooterRow.FindControl("ddlftacc") as DropDownList);
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            ObjBOL.WasteEq_id = Convert.ToInt32(ddlftwasteeqmanufacturer.SelectedValue);
            ds = ObjBLL.GetWasteEq(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlftacc, ds.Tables[0]);
            }
            else
            {
                ddlftacc.DataSource = "";
                ddlftacc.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlftwasteeqmanufacturer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetftAccessory();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnPreviewReport_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Reports/frmCustomerCareReports.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlgvmanufacturer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddleditmanufacturer = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("ddlgvmanufacturer") as DropDownList;
            DropDownList ddlgvwasteeq = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("ddlgvwasteeq") as DropDownList;
            DropDownList ddlgvacc = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("ddlgvacc") as DropDownList;
            Label lblgvac = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("lblgvac") as Label;
            Label lblgvwateequp = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("lblgvwateequp") as Label;
            DataSet ds = new DataSet();
            int ID = Convert.ToInt32(gvWasteEqDetails.DataKeys[gvWasteEqDetails.EditIndex].Value);
            ObjBOL.Operation = 4;
            ObjBOL.Detailid = ID;
            ObjBOL.makerid = Convert.ToInt32(ddleditmanufacturer.SelectedValue);
            ds = ObjBLL.FillDetails(ObjBOL);
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlgvwasteeq, ds.Tables[2]);
                ddlgvacc.DataSource = "";
                ddlgvacc.DataBind();
            }
            else
            {
                ddlgvwasteeq.DataSource = "";
                ddlgvwasteeq.DataBind();
                ddlgvacc.DataSource = "";
                ddlgvacc.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetWasteEq()
    {
        try
        {
            DropDownList ddlgvwasteeq = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("ddlgvwasteeq") as DropDownList;
            DropDownList ddlgvacc = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("ddlgvacc") as DropDownList;
            Label lblgvac = gvWasteEqDetails.Rows[gvWasteEqDetails.EditIndex].FindControl("lblgvac") as Label;
            DataSet ds = new DataSet();
            int ID = Convert.ToInt32(gvWasteEqDetails.DataKeys[gvWasteEqDetails.EditIndex].Value);
            ObjBOL.Operation = 4;
            ObjBOL.Detailid = ID;
            ObjBOL.WasteEq_id = Convert.ToInt32(ddlgvwasteeq.SelectedValue);
            ds = ObjBLL.FillDetails(ObjBOL);
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlgvacc, ds.Tables[3]);
            }
            else
            {
                ddlgvacc.DataSource = "";
                ddlgvacc.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlgvwasteeq_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetWasteEq();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}