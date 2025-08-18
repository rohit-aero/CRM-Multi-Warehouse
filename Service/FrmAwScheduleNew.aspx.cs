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
using System.IO;

public partial class FrmAwScheduleNew : System.Web.UI.Page
{
    BOLServiceSchedule ObjBOL = new BOLServiceSchedule();
    BLLServiceSchedule ObjBLL = new BLLServiceSchedule();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    commonclass1 cls = new commonclass1();
    string defval = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Controls(0);
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
            dtEmpty.Columns.Add(new DataColumn("ID", typeof(Int32)));
            dtEmpty.Columns.Add(new DataColumn("ServiceScheduleID", typeof(Int32)));
            dtEmpty.Columns.Add(new DataColumn("PartNumber", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("PartDescription", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("PartQty", typeof(Int32)));
            dtEmpty.Columns.Add(new DataColumn("ReqShipDate", typeof(DateTime)));
            dtEmpty.Columns.Add(new DataColumn("PartReqOnSite", typeof(DateTime)));
            dtEmpty.Columns.Add(new DataColumn("ShipDate", typeof(DateTime)));
            dtEmpty.Columns.Add(new DataColumn("NestingStatus", typeof(Int32)));
            dtEmpty.Columns.Add(new DataColumn("LaserStatus", typeof(Int32)));
            dtEmpty.Columns.Add(new DataColumn("FormingStatus", typeof(Int32)));
            dtEmpty.Columns.Add(new DataColumn("WeldingStatus", typeof(Int32)));
            dtEmpty.Columns.Add(new DataColumn("PolishingStatus", typeof(Int32)));
            dtEmpty.Columns.Add(new DataColumn("FinalStatus", typeof(Int32)));
            dtEmpty.Columns.Add(new DataColumn("ShippingStatus", typeof(Int32)));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);//adding row to the datatable
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    //List all Drop Downs in Page
    private void Bind_Controls(int i)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (i == 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlJobNo, ds.Tables[0]);
                }
            }
            else if (i == 1)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    DropDownList ddlFooterNesting = gvSummary.FooterRow.FindControl("ddlFooterNesting") as DropDownList;
                    //DropDownList ddlNesting = (DropDownList)gvSummary.FooterRow.FindControl("ddlNesting");
                    Utility.BindDropDownList(ddlFooterNesting, ds.Tables[1]);
                    //Utility.BindDropDownList(ddlNesting, ds.Tables[1]);

                    DropDownList ddlFooterLaser = gvSummary.FooterRow.FindControl("ddlFooterLaser") as DropDownList;
                    //DropDownList ddlLaser = gvSummary.FooterRow.FindControl("ddlLaser") as DropDownList;
                    Utility.BindDropDownList(ddlFooterLaser, ds.Tables[1]);
                    //Utility.BindDropDownList(ddlLaser, ds.Tables[1]);

                    DropDownList ddlFooterForming = gvSummary.FooterRow.FindControl("ddlFooterForming") as DropDownList;
                    //DropDownList ddlForming = gvSummary.FooterRow.FindControl("ddlForming") as DropDownList;
                    Utility.BindDropDownList(ddlFooterForming, ds.Tables[1]);
                    //Utility.BindDropDownList(ddlForming, ds.Tables[1]);

                    DropDownList ddlFooterWelding = gvSummary.FooterRow.FindControl("ddlFooterWelding") as DropDownList;
                    //DropDownList ddlWelding = gvSummary.FooterRow.FindControl("ddlWelding") as DropDownList;
                    Utility.BindDropDownList(ddlFooterWelding, ds.Tables[1]);
                    //Utility.BindDropDownList(ddlWelding, ds.Tables[1]);

                    DropDownList ddlFooterPolishing = gvSummary.FooterRow.FindControl("ddlFooterPolishing") as DropDownList;
                    //DropDownList ddlPolishing = gvSummary.FooterRow.FindControl("ddlPolishing") as DropDownList;
                    Utility.BindDropDownList(ddlFooterPolishing, ds.Tables[1]);
                    //Utility.BindDropDownList(ddlPolishing, ds.Tables[1]);

                    DropDownList ddlFooterShiping = gvSummary.FooterRow.FindControl("ddlFooterShiping") as DropDownList;
                    //DropDownList ddlShiping = gvSummary.FooterRow.FindControl("ddlShiping") as DropDownList;
                    Utility.BindDropDownList(ddlFooterShiping, ds.Tables[1]);
                    //Utility.BindDropDownList(ddlShiping, ds.Tables[1]);

                    DropDownList ddlFooterFinal = gvSummary.FooterRow.FindControl("ddlFooterFinal") as DropDownList;
                    //DropDownList ddlShiping = gvSummary.FooterRow.FindControl("ddlShiping") as DropDownList;
                    Utility.BindDropDownList(ddlFooterFinal, ds.Tables[1]);
                    //Utility.BindDropDownList(ddlShiping, ds.Tables[1]);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindPackList()
    {
        try
        {
            ObjBOL.Operation = 4;
            ObjBOL.JobID = ddlJobNo.SelectedValue;
            DataSet ds = ObjBLL.GetDataSet(ObjBOL);
            Utility.BindDropDownList(ddlPackNo, ds.Tables[0]);
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    //New Ticket Generate
    private void GenerateTicket()
    {
        try
        {
            string TicketNum = "";
            ObjBOL.Operation = 2;
            ObjBOL.JobID = ddlJobNo.SelectedValue;
            TicketNum = ObjBLL.GetTicketNo(ObjBOL);
            if (TicketNum != "")
            {
                txtTicketno.Text = TicketNum;
            }
            else
            {
                txtTicketno.Text = String.Empty;
            }
            Reset();
            txtReleaseDate.Text = string.Empty;
            ddlPackNo.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //New Ticket Generate
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            GenerateTicket();
            //Bind_Controls(0);
            //Bind_Controls(1);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Save()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = "";
                string id = "";
                ObjBOL.Operation = 3;
                ObjBOL.JobID = ddlJobNo.SelectedValue;
                ObjBOL.EmployeeID = Utility.GetCurrentSession().EmployeeID;
                ObjBOL.PackNo = txtTicketno.Text;
                if (txtReleaseDate.Text != "")
                {
                    ObjBOL.ReleaseDate = Utility.ConvertDate(txtReleaseDate.Text);
                }

                if (btnSave.Text == "Save")
                {
                    msg = ObjBLL.SavePack(ObjBOL);
                    Utility.ShowMessage_Success(this, "Records Added Successfully. !!");
                    Utility.MaintainLogsSpecial("FrmAwScheduleNew", "Save", txtTicketno.Text);
                    BindPackList();
                }
                else if (btnSave.Text == "Update")
                {
                    ObjBOL.Operation = 6;
                    ObjBOL.ID = Int32.Parse(ddlPackNo.SelectedValue);
                    id = ddlPackNo.SelectedValue;
                    msg = ObjBLL.SavePackInfo(ObjBOL);
                    Utility.ShowMessage_Success(this, "Records Updated Successfully. !!");
                    Utility.MaintainLogsSpecial("FrmAwScheduleNew", "Update", txtTicketno.Text);
                }

                //BindSummary();

                if (btnSave.Text == "Save")
                {
                    ddlPackNo.SelectedValue = msg;
                    btnSave.Text = "Update";
                }
                else
                {
                    ddlPackNo.SelectedValue = id;
                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Save/Update function for Both Ticket and SUmmary
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Save();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Ticket AutoBind Function in Drop Down List
    //private void BindTickets(int TicketID)
    //{
    //    try
    //    {
    //        EmptyDTSummary();
    //        BindSummary();           
    //        DataSet ds = new DataSet();
    //        ObjBOL.Operation = 5;
    //        //ObjBOL.TJobID = ddlJobNo.SelectedValue;            
    //        ds = ObjBLL.GetControlsData(ObjBOL);
    //        if(ds.Tables[0].Rows.Count>0)
    //        {
    //            Utility.BindDropDownList(ddlTicketNo, ds.Tables[0]);              
    //            if(TicketID != 0)
    //            {
    //                ddlTicketNo.SelectedValue =Convert.ToString(TicketID);
    //            }
    //            btnSave.Text = "Update";

    //        }
    //        else
    //        {
    //            ddlTicketNo.DataSource = "";
    //            ddlTicketNo.DataBind();
    //            ddlTicketNo.Items.Insert(0, new ListItem("Select", "0"));
    //            btnSave.Text = "Save";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}

    //Bind Model if Added in Database
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlJobNo.SelectedIndex > 0)
            {
                btnNew.Enabled = true;
                ResetSchedule();
                Reset();
                BindPackList();
            }
            else
            {
                Reset();
                ResetSchedule();
                btnNew.Enabled = false;
                btnPartsPreview.Enabled = false;
                ddlPackNo.DataSource = "";
                ddlPackNo.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Boolean ValidationCheckJobID()
    {
        try
        {
            if (ddlJobNo.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Job ID. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Job ID. !");
                ddlJobNo.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    //Validation for Ticket Save or Update
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtTicketno.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Generate Ticket Number. !');", true);
                Utility.ShowMessage_Error(Page, "Please Generate Pack No. !");
                txtTicketno.Focus();
                return false;
            }

            if (txtReleaseDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Release Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Release Date. !");
                txtReleaseDate.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private Boolean ValidationCheckSummary()
    {
        try
        {
            // TextBox PartNo = (gvSummary.FooterRow.FindControl("txtFooterPartNo") as TextBox);
            TextBox PartDesc = (gvSummary.FooterRow.FindControl("txtFooterPartDesc") as TextBox);
            //TextBox reqDate = (gvSummary.FooterRow.FindControl("txtReqShipDateFooter") as TextBox);
            TextBox ReqShipDate = (gvSummary.FooterRow.FindControl("txtReqShipDateFooter") as TextBox);
            //if (PartNo.Text == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Part Number. !');", true);
            //    PartNo.Focus();
            //    return false;
            //}

            if (PartDesc.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Part Desc. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Part Desc. !");
                PartDesc.Focus();
                return false;
            }
            if (ReqShipDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Required Ship date !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Required Ship date !");
                ReqShipDate.Focus();
                return false;
            }
            //if (reqDate.Text == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Required Ship Date. !');", true);
            //    reqDate.Focus();
            //    return false;
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void ResetSchedule()
    {
        try
        {
            txtTicketno.Text = String.Empty;
            txtReleaseDate.Text = String.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Reset all controls
    private void Reset()
    {
        try
        {
            btnSave.Text = "Save";
            gvSummary.DataSource = EmptyDT();
            gvSummary.DataBind();
            gvSummary.Rows[0].Visible = false;
            Bind_Controls(1);
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
            ResetSchedule();
            ddlJobNo.SelectedIndex = 0;
            ddlPackNo.DataSource = "";
            ddlPackNo.DataBind();
            Reset();
            btnNew.Enabled = false;
            btnPartsPreview.Enabled = false;
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
            if (DTSummary.Rows.Count > 0)
            {
                gvSummary.DataSource = DTSummary;
                gvSummary.DataBind();
            }
            else
            {
                gvSummary.DataSource = EmptyDT();
                gvSummary.DataBind();
                gvSummary.Rows[0].Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindSummary()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 7;
            ObjBOL.ID = Int32.Parse(ddlPackNo.SelectedValue);
            if (ddlPackNo.SelectedIndex > 0)
            {
                //ObjBOL.TicketID = Convert.ToInt32(ddlTicketNo.SelectedValue);
                ds = ObjBLL.GetControlsData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvSummary.DataSource = ds.Tables[0];
                    gvSummary.DataBind();
                }
                else
                {
                    gvSummary.DataSource = EmptyDT();
                    gvSummary.DataBind();
                    gvSummary.Rows[0].Visible = false;
                }
            }
            else
            {
                btnPartsPreview.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Fill Details from PackNo
    protected void ddlTicketNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPackNo.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 5;
                ObjBOL.ID = Int32.Parse(ddlPackNo.SelectedValue);
                ds = ObjBLL.GetControlsData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTicketno.Text = ds.Tables[0].Rows[0]["PackNo"].ToString();
                    txtReleaseDate.Text = ds.Tables[0].Rows[0]["ReleaseDate"].ToString().Split(' ')[0];
                    btnSave.Text = "Update";
                    BindSummary();
                    Bind_Controls(1);
                    btnPartsPreview.Enabled = true;
                }

            }
            else
            {
                Reset();
                ResetSchedule();
                btnPartsPreview.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //gvsUMMARY Editing
    protected void gvSummary_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvSummary.EditIndex = e.NewEditIndex;

            BindSummary();
            DropDownList ddlNesting = gvSummary.Rows[e.NewEditIndex].FindControl("ddlNesting") as DropDownList;
            DropDownList ddlLaser = gvSummary.Rows[e.NewEditIndex].FindControl("ddlLaser") as DropDownList;
            DropDownList ddlForming = gvSummary.Rows[e.NewEditIndex].FindControl("ddlForming") as DropDownList;
            DropDownList ddlWelding = gvSummary.Rows[e.NewEditIndex].FindControl("ddlWelding") as DropDownList;
            DropDownList ddlPolishing = gvSummary.Rows[e.NewEditIndex].FindControl("ddlPolishing") as DropDownList;
            DropDownList ddlShiping = gvSummary.Rows[e.NewEditIndex].FindControl("ddlShiping") as DropDownList;
            DropDownList ddlFinal = gvSummary.Rows[e.NewEditIndex].FindControl("ddlFinal") as DropDownList;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlNesting, ds.Tables[1]);
                Utility.BindDropDownList(ddlLaser, ds.Tables[1]);
                Utility.BindDropDownList(ddlForming, ds.Tables[1]);
                Utility.BindDropDownList(ddlWelding, ds.Tables[1]);
                Utility.BindDropDownList(ddlPolishing, ds.Tables[1]);
                Utility.BindDropDownList(ddlShiping, ds.Tables[1]);
                Utility.BindDropDownList(ddlFinal, ds.Tables[1]);
            }

            ObjBOL.Operation = 11;
            int ID = Convert.ToInt32(gvSummary.DataKeys[e.NewEditIndex].Value);
            ObjBOL.ID = ID;
            ds = ObjBLL.GetControlsData(ObjBOL);
            ddlNesting.SelectedValue = ds.Tables[0].Rows[0]["NestingStatus"].ToString();
            ddlLaser.SelectedValue = ds.Tables[0].Rows[0]["LaserStatus"].ToString();
            ddlForming.SelectedValue = ds.Tables[0].Rows[0]["FormingStatus"].ToString();
            ddlWelding.SelectedValue = ds.Tables[0].Rows[0]["WeldingStatus"].ToString();
            ddlPolishing.SelectedValue = ds.Tables[0].Rows[0]["PolishingStatus"].ToString();
            ddlShiping.SelectedValue = ds.Tables[0].Rows[0]["ShippingStatus"].ToString();
            ddlFinal.SelectedValue = ds.Tables[0].Rows[0]["FinalStatus"].ToString();
            Bind_Controls(1);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //GVSummary Cancel
    protected void gvSummary_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvSummary.EditIndex = -1;
            BindSummary();
            Bind_Controls(1);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //GVSummary Update
    protected void gvSummary_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            int ID = Convert.ToInt32(gvSummary.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvSummary.Rows[e.RowIndex];
            int rowid = row.RowIndex;
            TextBox txtFooterPartNo = row.FindControl("txtPartNo") as TextBox;
            TextBox txtFooterPartDesc = row.FindControl("txtPartDesc") as TextBox;
            TextBox txtFooterPartQty = row.FindControl("txtPartQty") as TextBox;
            TextBox txtReqShipDateFooter = row.FindControl("txtReqShipDate") as TextBox;
            TextBox txtPartReqOnSiteFooter = row.FindControl("txtPartReqOnSite") as TextBox;
            TextBox txtShipDateFooter = row.FindControl("txtShipDate") as TextBox;
            DropDownList ddlNesting = gvSummary.Rows[rowid].FindControl("ddlNesting") as DropDownList;
            DropDownList ddlLaser = gvSummary.Rows[rowid].FindControl("ddlLaser") as DropDownList;
            DropDownList ddlForming = gvSummary.Rows[rowid].FindControl("ddlForming") as DropDownList;
            DropDownList ddlWelding = gvSummary.Rows[rowid].FindControl("ddlWelding") as DropDownList;
            DropDownList ddlPolishing = gvSummary.Rows[rowid].FindControl("ddlPolishing") as DropDownList;
            DropDownList ddlShiping = gvSummary.Rows[rowid].FindControl("ddlShiping") as DropDownList;
            DropDownList ddlFinal = gvSummary.Rows[rowid].FindControl("ddlFinal") as DropDownList;

            int intCarrier = -1;
            if (Int32.TryParse(ddlPackNo.SelectedValue, out intCarrier))
            {
                ObjBOL.ServiceScheduleID = intCarrier;
            }

            ObjBOL.PartNumber = txtFooterPartNo.Text;
            ObjBOL.PartDescription = txtFooterPartDesc.Text;

            if (txtFooterPartQty.Text != "")
            {
                intCarrier = -1;
                if (Int32.TryParse(txtFooterPartQty.Text, out intCarrier))
                {
                    ObjBOL.PartQty = intCarrier;
                }
            }

            ObjBOL.ReqShipDate = Utility.ConvertDate(txtReqShipDateFooter.Text.ToString());
            ObjBOL.PartReqOnSite = Utility.ConvertDate(txtPartReqOnSiteFooter.Text.ToString());
            ObjBOL.ShipDate = Utility.ConvertDate(txtShipDateFooter.Text.ToString());

            intCarrier = -1;
            if (Int32.TryParse(ddlNesting.SelectedValue, out intCarrier))
            {
                ObjBOL.NestingStatus = intCarrier;
            }

            intCarrier = -1;
            if (Int32.TryParse(ddlLaser.SelectedValue, out intCarrier))
            {
                ObjBOL.LaserStatus = intCarrier;
            }

            intCarrier = -1;
            if (Int32.TryParse(ddlForming.SelectedValue, out intCarrier))
            {
                ObjBOL.FormingStatus = intCarrier;
            }

            intCarrier = -1;
            if (Int32.TryParse(ddlWelding.SelectedValue, out intCarrier))
            {
                ObjBOL.WeldingStatus = intCarrier;
            }

            intCarrier = -1;
            if (Int32.TryParse(ddlPolishing.SelectedValue, out intCarrier))
            {
                ObjBOL.PolishingStatus = intCarrier;
            }

            intCarrier = -1;
            if (Int32.TryParse(ddlShiping.SelectedValue, out intCarrier))
            {
                ObjBOL.ShippingStatus = intCarrier;
            }

            intCarrier = -1;
            if (Int32.TryParse(ddlFinal.SelectedValue, out intCarrier))
            {
                ObjBOL.FinalStatus = intCarrier;
            }

            ObjBOL.Operation = 10;
            ObjBOL.ID = ID;
            ObjBOL.JobID = ddlJobNo.SelectedValue;
            ObjBOL.EmployeeID = Utility.GetCurrentSession().EmployeeID;
            string returnValue = ObjBLL.SavePack(ObjBOL);
            if (returnValue.Trim() != "")
            {
                if (returnValue.Trim() == "1")
                {
                    Utility.ShowMessage_Error(this, "Part Description already exists !!");
                }
                else
                {
                    Utility.MaintainLogsSpecial("FrmAwScheduleNew", "Update-Detail", txtTicketno.Text);
                    Utility.ShowMessage_Success(this, "Pack Details Updated Successfully. !!");
                    gvSummary.EditIndex = -1;
                    BindSummary();
                    Bind_Controls(1);
                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSummary_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 8;
            GridViewRow row = gvSummary.Rows[e.RowIndex];
            if (ddlPackNo.SelectedValue == "0")
            {
                DataTable dt = (DataTable)ViewState["Summary"];
                dt.Rows[e.RowIndex].Delete();
                BindSummaryTemp(dt);
            }
            else
            {
                Int32 ID = Convert.ToInt32(gvSummary.DataKeys[e.RowIndex].Value);
                ObjBOL.ID = ID;
                msg = ObjBLL.DeletePackNoDetail(ObjBOL);
                if (msg != "")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Data deleted successfully !');", true);
                    Utility.MaintainLogsSpecial("FrmAwScheduleNew", "Delete-Detail", txtTicketno.Text);
                    Utility.ShowMessage_Success(Page, "Data deleted successfully !");
                }
                BindSummary();
                Bind_Controls(1);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // 0 for save, 1 for update
    private void SummaryAdd(int saveOrUpdate)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                if (ValidationCheckSummary() == true)
                {
                    string txtFooterPartNo = (gvSummary.FooterRow.FindControl("txtFooterPartNo") as TextBox).Text;
                    string txtFooterPartDesc = (gvSummary.FooterRow.FindControl("txtFooterPartDesc") as TextBox).Text;
                    string txtFooterPartQty = (gvSummary.FooterRow.FindControl("txtPartQtyFooter") as TextBox).Text;
                    string txtReqShipDateFooter = (gvSummary.FooterRow.FindControl("txtReqShipDateFooter") as TextBox).Text;
                    string txtPartReqOnSiteFooter = (gvSummary.FooterRow.FindControl("txtPartReqOnSiteFooter") as TextBox).Text;
                    string txtShipDateFooter = (gvSummary.FooterRow.FindControl("txtShipDateFooter") as TextBox).Text;

                    DropDownList ddlNesting = gvSummary.FooterRow.FindControl("ddlFooterNesting") as DropDownList;
                    DropDownList ddlLaser = gvSummary.FooterRow.FindControl("ddlFooterLaser") as DropDownList;
                    DropDownList ddlForming = gvSummary.FooterRow.FindControl("ddlFooterForming") as DropDownList;
                    DropDownList ddlWelding = gvSummary.FooterRow.FindControl("ddlFooterWelding") as DropDownList;
                    DropDownList ddlPolishing = gvSummary.FooterRow.FindControl("ddlFooterPolishing") as DropDownList;
                    DropDownList ddlShiping = gvSummary.FooterRow.FindControl("ddlFooterShiping") as DropDownList;
                    DropDownList ddlFinal = gvSummary.FooterRow.FindControl("ddlFooterFinal") as DropDownList;
                    if (saveOrUpdate == 0)
                    {
                        //PrePareDT(0, Utility.ConvertDate(SummaryDate), Summary);
                        //PrePareDT(0, 0, txtFooterPartNo, txtFooterPartDesc, Utility.ConvertDate(txtReqShipDateFooter),
                        //Convert.ToInt32(ddlNesting.SelectedValue), Convert.ToInt32(ddlLaser.SelectedValue),
                        //Convert.ToInt32(ddlForming.SelectedValue), Convert.ToInt32(ddlWelding.SelectedValue),
                        //Convert.ToInt32(ddlPolishing.SelectedValue), Convert.ToInt32(ddlShiping.SelectedValue));
                        if (ValidationCheckSummary() == true)
                        {
                            if (ddlPackNo.SelectedIndex > 0)
                            {
                                //DataTable dtCurrentTable = (DataTable)ViewState["Summary"];
                                //dtCurrentTable.Rows.Clear();
                                //DataRow drCurrentRow = null;
                                //drCurrentRow = dtCurrentTable.NewRow();
                                //drCurrentRow["ID"] = 0;
                                ObjBOL.ID = 0;
                                //drCurrentRow["ServiceScheduleID"] = Convert.ToInt32(ddlPackNo.SelectedValue);
                                ObjBOL.ServiceScheduleID = Convert.ToInt32(ddlPackNo.SelectedValue);
                                //drCurrentRow["PartNumber"] = txtFooterPartNo;
                                ObjBOL.PartNumber = txtFooterPartNo;
                                //drCurrentRow["PartDescription"] = txtFooterPartDesc;
                                ObjBOL.PartDescription = txtFooterPartDesc;
                                if (txtFooterPartQty != "")
                                {
                                    //drCurrentRow["PartQty"] = txtFooterPartQty;
                                    ObjBOL.PartQty = Convert.ToInt32(txtFooterPartQty);
                                }
                                if (txtReqShipDateFooter != "")
                                {
                                    //drCurrentRow["ReqShipDate"] = Utility.ConvertDate(txtReqShipDateFooter);
                                    ObjBOL.ReqShipDate = Utility.ConvertDate(txtReqShipDateFooter);
                                }
                                if (txtPartReqOnSiteFooter != "")
                                {
                                    //drCurrentRow["PartReqOnSite"] = Utility.ConvertDate(txtPartReqOnSiteFooter);
                                    ObjBOL.PartReqOnSite = Utility.ConvertDate(txtPartReqOnSiteFooter);
                                }
                                if (txtShipDateFooter != "")
                                {
                                    //drCurrentRow["ShipDate"] = Utility.ConvertDate(txtShipDateFooter);
                                    ObjBOL.ShipDate = Utility.ConvertDate(txtShipDateFooter);
                                }
                                //drCurrentRow["NestingStatus"] = Convert.ToInt32(ddlNesting.SelectedValue);
                                ObjBOL.NestingStatus = Convert.ToInt32(ddlNesting.SelectedValue);
                                //drCurrentRow["LaserStatus"] = Convert.ToInt32(ddlLaser.SelectedValue);
                                ObjBOL.LaserStatus = Convert.ToInt32(ddlLaser.SelectedValue);
                                //drCurrentRow["FormingStatus"] = Convert.ToInt32(ddlForming.SelectedValue);
                                ObjBOL.FormingStatus = Convert.ToInt32(ddlForming.SelectedValue);
                                //drCurrentRow["WeldingStatus"] = Convert.ToInt32(ddlWelding.SelectedValue);
                                ObjBOL.WeldingStatus = Convert.ToInt32(ddlWelding.SelectedValue);
                                //drCurrentRow["PolishingStatus"] = Convert.ToInt32(ddlPolishing.SelectedValue);
                                ObjBOL.PolishingStatus = Convert.ToInt32(ddlPolishing.SelectedValue);
                                //drCurrentRow["ShippingStatus"] = Convert.ToInt32(ddlShiping.SelectedValue);
                                ObjBOL.ShippingStatus = Convert.ToInt32(ddlShiping.SelectedValue);
                                //drCurrentRow["FinalStatus"] = Convert.ToInt32(ddlFinal.SelectedValue);
                                ObjBOL.FinalStatus = Convert.ToInt32(ddlFinal.SelectedValue);
                                //dtCurrentTable.AcceptChanges();
                                //dtCurrentTable.Rows.Add(drCurrentRow);
                                ObjBOL.Operation = 9;
                                ObjBOL.JobID = ddlJobNo.SelectedValue;
                                //ObjBOL.PackDetail = dtCurrentTable;
                                //ObjBOL.EmployeeID = Utility.GetCurrentSession().EmployeeID;
                                string returnValue = ObjBLL.SavePack(ObjBOL);
                                if (returnValue.Trim() != "")
                                {
                                    if (returnValue.Trim() == "1")
                                    {
                                        Utility.ShowMessage_Error(this, "Part Description already exists !!");
                                    }
                                    else
                                    {
                                        Utility.MaintainLogsSpecial("FrmAwScheduleNew", "Save-Detail", txtTicketno.Text);
                                        Utility.ShowMessage_Success(this, "Pack Details Inserted Successfully. !!");
                                        txtFooterPartNo = String.Empty;
                                        txtFooterPartDesc = String.Empty;
                                        txtReqShipDateFooter = String.Empty;
                                        txtPartReqOnSiteFooter = String.Empty;
                                        txtShipDateFooter = String.Empty;
                                        ddlNesting.SelectedIndex = 0;
                                        ddlLaser.SelectedIndex = 0;
                                        ddlForming.SelectedIndex = 0;
                                        ddlWelding.SelectedIndex = 0;
                                        ddlPolishing.SelectedIndex = 0;
                                        ddlShiping.SelectedIndex = 0;
                                        BindSummary();
                                        Bind_Controls(1);
                                    }
                                }
                            }
                            else
                            {
                                Utility.ShowMessage_Error(this, "Please save Ticket First. !!");
                            }
                        }
                    }
                    // else if (saveOrUpdate == 1)
                    //{
                    //PrePareDT(0, Convert.ToInt32(ddlPackNo.SelectedValue),
                    //    txtFooterPartNo, txtFooterPartDesc, Utility.ConvertDate(txtReqShipDateFooter),
                    //   Convert.ToInt32(ddlNesting.SelectedValue), Convert.ToInt32(ddlLaser.SelectedValue),
                    //   Convert.ToInt32(ddlForming.SelectedValue), Convert.ToInt32(ddlWelding.SelectedValue),     
                    //   Convert.ToInt32(ddlPolishing.SelectedValue), Convert.ToInt32(ddlShiping.SelectedValue));

                    // }                    
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
            SummaryAdd(0);
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
            clscon.Return_DT(dt, "EXEC [dbo].[Get_CCT_TicketDetails] '" + ddlPackNo.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataZero();
            rprt.Load(Server.MapPath("~/Reports/rptCustCareTicketDetails.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Aerowerks Service Schedule Report";
                rprt.SetDataSource(dt);
                // rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false,txtheader.Text);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, false, txtheader.Text);
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

    protected void btnReports_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Service/frmAwScheduleReport.aspx");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnPDF_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataZero();
            rprt.Load(Server.MapPath("~/Reports/rptCustCareTicketDetails.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Aerowerks Service Schedule Report";
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                //rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, false, txtheader.Text);
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

    private DataTable ReportDataParts()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[Get_ServiceSchedule_Parts] '" + ddlPackNo.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnPartsPreview_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataParts();
            rprt.Load(Server.MapPath("~/Reports/rptServiceParts.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                string JobName = ddlJobNo.SelectedItem.Text.Replace(",", "");
                txtheader.Text = JobName;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                Utility.ShowMessage_Error(Page, "No Data Found !!");
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
}