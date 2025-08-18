using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Configuration;

public partial class InventoryManagement_frmPrepareContainer : System.Web.UI.Page
{
    BOLPrepareContainer ObjBOL = new BOLPrepareContainer();
    BLLPrepareContainerNew ObjBLL = new BLLPrepareContainerNew();
    commonclass1 cls = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    string FileExtention = null;
    public static readonly List<string> ImageExtensionsPdf = new List<string> { ".pdf" };
    string msg = "";
    string status = "";
    string folderPath = string.Empty;
    MailAddress MailAddress_Amritpal = new MailAddress("amrit@aero-werks.com", "Amritpal Singh");
    MailAddress MailAddress_Raman = new MailAddress("raman@aero-werks.com", "Raman Singh");
    MailAddress MailAddress_MrSingh = new MailAddress("balbir@aero-werks.com", "Balbir Singh");
    MailAddress MailAddress_Kapil = new MailAddress("kapil@aero-werks.com", "Kapil Rana");
    MailAddress MailAddress_Saurabh = new MailAddress("Saurabh@aero-werks.com", "Saurabh");
    MailAddress MailAddress_Stan = new MailAddress("stan@aero-werks.com", "Stan");
    MailAddress MailAddress_Karam = new MailAddress("karam@aero-werks.com", "Karam");
    MailAddress MailAddress_Ping = new MailAddress("plchan@aero-werks.com", "Ping");
    MailAddress MailAddress_Triflex = new MailAddress("triflex@aero-werks.com", "Triflex");
    MailAddress MailAddress_Office = new MailAddress("office@aero-werks.com", "Office");
    MailAddress MailAddress_AeroIt = new MailAddress(Utility.Email(), Utility.EmailDisplayName());
    MailAddress MailAddress_Purchasing = new MailAddress("Purchasing@aero-werks.com", "Purchasing");
    string Do_Not_Reply = "[Please do not reply to this message. Replies to this message are routed to an unmonitored mailbox]";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                pogrid.Visible = false;
                containerProjects.Visible = false;
                hfContaineridgetfromdb.Value = null;
                EmptyDT();
                Bind_Controls(msg, "");
                Bind_ApprovedBy();
                AutoBindContainer(Utility.GetCurrentSession().EmployeeID);                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        
    }

    private void AutoBindContainer(int EmployeeID)
    {
        try
        {
            if (EmployeeID == Convert.ToInt32("335"))
            {
                ddlVendorLookup.SelectedValue = "1";
                VendorLookupAutoBind("1");

            }
            else if (EmployeeID == Convert.ToInt32("340"))
            {
                ddlVendorLookup.SelectedValue = "2";
                VendorLookupAutoBind("2");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void VendorLookupAutoBind(string SourceID)
    {
        try
        {
            if (SourceID != "")
            {
                ObjBOL.Operation = 10;
                ObjBOL.SourceID = Int32.Parse(SourceID);
                reset();
                ddlVendorLookup.SelectedValue = ObjBOL.SourceID.ToString();
                DataSet ds = ObjBLL.GetBindControl(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlContainerNo, ds.Tables[0]);
                    ddlContainerNo.SelectedIndex = 0;
                }
                else
                {
                    ddlContainerNo.DataSource = "";
                    ddlContainerNo.DataBind();
                }
            }
            else
            {
                reset();
            }
            pogrid.Visible = false;
            containerProjects.Visible = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetFilePaths()
    {
        try
        {
            folderPath = Utility.ContainerDocsPath();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_ApprovedBy()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 16;
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlApprovedBy, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Boolean SavePdf()
    {
        try
        {
            GetFilePaths();
            if (fpuploadfile.HasFile)
            {
                FileExtention = System.IO.Path.GetExtension(fpuploadfile.FileName.Replace(",",""));
            }
            string File = FileExtention.ToLower();
            if (ImageExtensionsPdf.Contains(File))
            {
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists Create it.
                    Directory.CreateDirectory(folderPath);
                }
                string ContainerNo = txtInvoiceNo.Text;
                string FileName = ContainerNo.Trim();
                FileInfo currentfile = new FileInfo(fpuploadfile.FileName.Replace(",", ""));
                string newfilename = fpuploadfile.FileName.Replace(",", "");
                hfInvoiceNodrwaing.Value = newfilename;
                fpuploadfile.SaveAs(folderPath + newfilename);
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Attach Only .pdf file format. !');", true);
                Utility.ShowMessage_Error(Page, "Please Attach Only .pdf file format. !");
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }
    private void Bind_Controls(string containerId, string vendorID)
    {
        try
        {
            var EmployeeID = Utility.GetCurrentSession().EmployeeID;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ObjBOL.EmployeeID = EmployeeID;
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlAttn, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlIssuedBy, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlVendorLookup, ds.Tables[3]);
                Utility.BindDropDownList(ddlVendor, ds.Tables[3]);
                if (vendorID != "")
                {
                    ddlVendorLookup.SelectedValue = vendorID;
                    VendorLookupEvent(containerId);
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
            var EmployeeID = Utility.GetCurrentSession().EmployeeID;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 7;
            ObjBOL.SourceID = Int32.Parse(ddlVendor.SelectedValue);
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                pogrid.Visible = true;
                gvMainRequisitionDetail.DataSource = ds.Tables[0];
                gvMainRequisitionDetail.DataBind();
            }
            else
            {
                pogrid.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
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
                    string POid= (row.FindControl("lblPOId") as Label).Text;
                    GridView gvContainer = row.FindControl("gvContainer") as GridView;
                    string partid = gvMainRequisitionDetail.DataKeys[row.RowIndex].Value.ToString();
                    var EmployeeID = Utility.GetCurrentSession().EmployeeID;
                    ObjBOL.PartId = Convert.ToInt32(partid);
                    ObjBOL.SourceID = Convert.ToInt32(ddlVendor.SelectedValue);
                    ObjBOL.POid = Convert.ToInt32(POid);
                    ObjBOL.Operation = 2;                                      
                    ds = ObjBLL.GetBindControl(ObjBOL);
                    DataTable dtContainer = new DataTable();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtContainer = ds.Tables[0];
                    }
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
                        foreach (GridViewRow rowStatus in gvContainer.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {

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
            //dtEmpty.Columns.Add(new DataColumn("ShipmentBy", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("SkidNo", typeof(string)));
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
            dt.Columns.Add(new DataColumn("POid", typeof(int)));
            dt.Columns.Add(new DataColumn("PODetailId", typeof(int)));
            dt.Columns.Add(new DataColumn("ReqStatus", typeof(int)));
            dt.Columns.Add(new DataColumn("Containerid", typeof(int)));
            dt.Columns.Add(new DataColumn("OrderQty", typeof(int)));
            dt.Columns.Add(new DataColumn("partid", typeof(string)));
            dt.Columns.Add(new DataColumn("ShipQty", typeof(int)));
            dt.Columns.Add(new DataColumn("Pendingqty", typeof(int)));
            dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
            dt.Columns.Add(new DataColumn("PackingNo", typeof(string)));
            dt.Columns.Add(new DataColumn("Status", typeof(int)));
            //dt.Columns.Add(new DataColumn("ShipmentBy", typeof(int)));
            dt.Columns.Add(new DataColumn("SkidNo", typeof(string)));
            ViewState["ContainerSummary"] = dt;

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GetSaveDocPath()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 17;
            ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ObjBOL.UploadDocument = ds.Tables[0].Rows[0]["UploadDocument"].ToString();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void SaveContainerInfo()
    {
        try
        {
            var EmployeeID = Utility.GetCurrentSession().EmployeeID;
            ObjBOL.InvoiceNo = txtInvoiceNo.Text;
            ObjBOL.ContainerNo = txtContainerNo.Text;
            ObjBOL.SealNo = txtSealNo.Text;
            if (txtTentativeSentDate.Text != "")
            {
                ObjBOL.TentativeSentDate = Utility.ConvertDate(txtTentativeSentDate.Text);
            }
            if (txtsentdate.Text != "")
            {
                ObjBOL.SentDate = Utility.ConvertDate(txtsentdate.Text);
            }
            if (txtArrivalinAerowerks.Text != "")
            {
                ObjBOL.ArrivalinAerowerks = Utility.ConvertDate(txtArrivalinAerowerks.Text);
            }
            ObjBOL.ContainerSize = txtContainer.Text;
            ObjBOL.ApprovedBy = Convert.ToInt32(ddlApprovedBy.SelectedValue);
            ObjBOL.Attn = Convert.ToInt32(ddlAttn.SelectedValue);
            ObjBOL.Issuedby = Convert.ToInt32(ddlIssuedBy.SelectedValue);
            ObjBOL.ShipmentBy = Convert.ToInt32(ddlShipment.SelectedValue);
            if (fpuploadfile.HasFile)
            {
                if (SavePdf() == true)
                {
                    ObjBOL.UploadDocument = fpuploadfile.FileName.Replace(",","");
                }
                else
                {
                    return;
                }
            }  
            else
            {
                if(ddlContainerNo.SelectedIndex>0)
                {
                    GetSaveDocPath();
                }                
            }          
            SaveGridData();
            DataTable selected = (DataTable)ViewState["ContainerSummary"];
            DataView dv = new DataView(selected);
            DataTable summarytemp = dv.ToTable("selected", false, "Poid", "PoDetailId", "Partid", "OrderQty", "ShipQty", "Pendingqty", "Remarks", "PackingNo", "Status", "SkidNo");
            ObjBOL.ContainerDetails = summarytemp;
            int Employeeid = Utility.GetCurrentSession().EmployeeID;
            ObjBOL.LoginUserId = Employeeid;
            ObjBOL.SourceID = Int32.Parse(ddlVendor.SelectedValue);
            if (btnSave.Text == "Save")
            {
                ObjBOL.Operation = 3;
                msg = ObjBLL.SaveContainerInfo(ObjBOL);
                if (msg == "ER01")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Invoice No already exists!!');", true);
                    Utility.ShowMessage_Error(Page, "Invoice No already exists!!");
                    return;
                }
                else if (msg == "ER02")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Container No already exists!!');", true);
                    Utility.ShowMessage_Error(Page, "Container No already exists!!");
                    return;
                }
                if (msg != "")
                {
                    hfContainerid.Value = msg;
                    Bind_Controls(msg, ddlVendor.SelectedValue);
                    UpdateReqStatus();
                    AutoFillData();
                    Bind_GridChangeContainer();
                    //Utility.ShowMessage(this, "Records Added Successfully !!!");
                    Utility.ShowMessage_Success(Page, "Container Added Successfully !!!");

                }
                btnSave.Text = "Update";
            }
            else
            {
                btnSave.Text = "Update";
                ObjBOL.Containerid = Int32.Parse(ddlContainerNo.SelectedValue);                              
                ObjBOL.Operation = 9;                
                msg = ObjBLL.SaveContainerInfo(ObjBOL);
                if (msg == "ER01")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Invoice No already exists!!');", true);
                    Utility.ShowMessage_Error(Page, "Invoice No already exists!!");
                    return;
                }
                else if (msg == "ER02")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Container No already exists!!');", true);
                    Utility.ShowMessage_Error(Page, "Container No already exists!!");
                    return;
                }
                if (msg != "")
                {
                    hfContainerid.Value = msg;
                    Bind_Controls(msg, ddlVendor.SelectedValue);
                    UpdateReqStatus();
                    AutoFillData();
                    Bind_GridChangeContainer();
                }
                //Utility.ShowMessage(this, "Records Updated Successfully !!!");
                Utility.ShowMessage_Success(Page, "Container Updated Successfully !!!");
            }
            btnAddProjects.Enabled = true;
            pogrid.Visible = true;
            containerProjects.Visible = true;
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
                    string POid = (row.FindControl("lblPOId") as Label).Text;
                    string PartId = gvMainRequisitionDetail.DataKeys[row.RowIndex].Value.ToString();                    
                    string PODetailId = (row.FindControl("lblPODetailId") as Label).Text;                                      
                    GridView gvContainer = row.FindControl("gvContainer") as GridView;                    
                    foreach (GridViewRow Containerrow in gvContainer.Rows)
                    {                        
                        if (Containerrow.RowType == DataControlRowType.DataRow)
                        {
                            dr = dt.NewRow();
                            Label POConid = ((Label)Containerrow.FindControl("lblContainerPOId"));
                            Label PODetailConid = ((Label)Containerrow.FindControl("lblContainerPODetailId"));
                            Label Partid = ((Label)Containerrow.FindControl("lblItemPartid"));
                            Label PartNo = ((Label)Containerrow.FindControl("lblPartnumber"));
                            Label PartDes = ((Label)Containerrow.FindControl("lblPartDes"));
                            Label OrderQty = ((Label)Containerrow.FindControl("lblOrderQty"));
                            Label Pending = ((Label)Containerrow.FindControl("lblPendingQty"));
                            TextBox ShippedQty = ((TextBox)Containerrow.FindControl("txtShippingQty"));
                            TextBox ItemRemarks = ((TextBox)Containerrow.FindControl("txtItemRemarks"));
                            DropDownList ddlStatus = ((DropDownList)Containerrow.FindControl("ddlstatus"));
                            //DropDownList ddlShipmentBy = ((DropDownList)Containerrow.FindControl("ddlShipmentBy"));
                            TextBox SkidNo = ((TextBox)Containerrow.FindControl("txtSkidNo"));
                            dr[0] = Convert.ToInt32(POConid.Text);
                            if (PODetailId != "")
                            {
                                dr[1] = PODetailConid.Text;
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
                            //if(ddlShipmentBy.SelectedIndex>0)
                            //{
                            //    dr[11] =Convert.ToInt32(ddlShipmentBy.SelectedValue);
                            //}
                            //else
                            //{
                            //    dr[11] = 0;
                            //}
                            if(SkidNo.Text != "")
                            {
                                dr[11] = SkidNo.Text;
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
            if (ddlVendor.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Vendor !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Vendor !");
                ddlVendor.Focus();
                return false;
            }
            if (txtInvoiceNo.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Container No. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Invoice No. !");
                txtInvoiceNo.Focus();
                return false;
            }
            if (txtSealNo.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Container No. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Seal No. !");
                txtSealNo.Focus();
                return false;
            }
            if (txtTentativeSentDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Sent Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Tentative Sent Date. !");
                txtTentativeSentDate.Focus();
                return false;
            }
            if (ddlShipment.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Shipment By. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Shipment By. !");
                ddlShipment.Focus();
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
                btnNotify.Enabled = true;
                btnPackingDetails.Enabled = true;
                BindJobGrid();
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
            Bind_Grid();
            //DataTable TempData = (DataTable)ViewState["ContainerSummary"];
            btnSave.Text = "Update";
            DataSet ds = new DataSet();
            foreach (GridViewRow row in gvMainRequisitionDetail.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Label POId = row.FindControl("lblPOId") as Label;
                    string partid = gvMainRequisitionDetail.DataKeys[row.RowIndex].Value.ToString();                                       
                    ObjBOL.Operation = 2;                    
                    ObjBOL.PartId = Convert.ToInt32(partid);
                    ObjBOL.POid = Convert.ToInt32(POId.Text);
                    ObjBOL.SourceID = Int32.Parse(ddlVendor.SelectedValue);                    
                    ds = ObjBLL.GetBindControl(ObjBOL);
                    DataTable dtContainer = new DataTable();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtContainer = ds.Tables[0];
                    }
                    GridView gvContainer = row.FindControl("gvContainer") as GridView;                    
                    if (ddlContainerNo.SelectedIndex > 0)
                    {
                        ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
                    }                   
                    ObjBOL.Operation = 4;                    
                    ds = ObjBLL.GetBindControl(ObjBOL);
                    DataTable dtContainerUpdate = new DataTable();
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
                                    //dtRow["PackingNo"] = dtRow1["PackingNo"];
                                    dtRow["Remarks"] = dtRow1["Remarks"];
                                    dtRow["Status"] = dtRow1["Status"];
                                    dtRow["SkidNo"] = dtRow1["SkidNo"];
                                    break;
                                }

                            }
                        }
                        if (dtContainer.Rows.Count > 0)
                        {
                            DataView dv = new DataView(dtContainer);
                            dv.Sort = "ShippedQty DESC";
                            dtContainer = dv.ToTable();
                        }
                        gvContainer.DataSource = dtContainer;
                        gvContainer.DataBind();
                        
                    }
                    else
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
                    ddlVendor.SelectedValue = ddlVendorLookup.SelectedValue;
                    txtInvoiceNo.Text = ds.Tables[0].Rows[0]["InvoiceNo"].ToString();
                    txtContainerNo.Text = ds.Tables[0].Rows[0]["ContainerNo"].ToString();
                    txtSealNo.Text = ds.Tables[0].Rows[0]["SealNo"].ToString();
                    txtTentativeSentDate.Text = cls.Converter(ds.Tables[0].Rows[0]["TentativeSentDate"].ToString());
                    txtsentdate.Text = cls.Converter(ds.Tables[0].Rows[0]["SentDate"].ToString());
                    txtArrivalinAerowerks.Text = cls.Converter(ds.Tables[0].Rows[0]["ArrivalinAerowerks"].ToString());
                    txtContainer.Text = ds.Tables[0].Rows[0]["ContainerSize"].ToString();
                    ddlAttn.SelectedValue = ds.Tables[0].Rows[0]["Attn"].ToString();
                    if (ds.Tables[0].Rows[0]["ApprovedBy"].ToString() != "")
                    {
                        ddlApprovedBy.SelectedValue = ds.Tables[0].Rows[0]["ApprovedBy"].ToString();
                    }
                    ddlIssuedBy.SelectedValue = ds.Tables[0].Rows[0]["Issuedby"].ToString();
                    ddlShipment.SelectedValue = ds.Tables[0].Rows[0]["Shipmentby"].ToString();
                    if (ds.Tables[0].Rows[0]["UploadDocument"].ToString() != "")
                    {
                        List<string> list = new List<string>();
                        list.Add(ds.Tables[0].Rows[0]["UploadDocument"].ToString());
                        String[] str = list.ToArray();
                        String[] invNo = str[0].Split('/');
                        lnkDownload.Text = invNo[0].ToString();
                        hfInvoiceNodrwaing.Value = lnkDownload.Text;
                    }
                    else
                    {
                        lnkDownload.Text = String.Empty;
                        hfInvoiceNodrwaing.Value = "-1";
                    }
                }
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private Boolean CheckMandetoryFieldsBeforeSubmit()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 18;
            ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
            ds = ObjBLL.GetBindControl(ObjBOL);
            if(ds.Tables[0].Rows.Count>0)
            {
                string vendor = ds.Tables[0].Rows[0]["Vendor"].ToString();
                string InvoiceNo = ds.Tables[0].Rows[0]["InvoiceNo"].ToString();
                string SealNo = ds.Tables[0].Rows[0]["SealNo"].ToString();
                string TentativeSentDate = ds.Tables[0].Rows[0]["TentativeSentDate"].ToString();
                string Approvedby = ds.Tables[0].Rows[0]["ApprovedBy"].ToString();
                string ShippmentBy = ds.Tables[0].Rows[0]["Shipmentby"].ToString();
                if(vendor=="")
                {
                    Utility.ShowMessage_Error(Page, "Please Select Vendor and Update !!");
                    ddlVendor.Focus();
                    return false;
                }
                if (InvoiceNo == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Invoice No and Update !!");
                    txtInvoiceNo.Focus();
                    return false;
                }
                if (SealNo == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Seal No and Update !!");
                    txtSealNo.Focus();
                    return false;
                }
                if (TentativeSentDate == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Tentative Sent Date and Update !!");
                    txtTentativeSentDate.Focus();
                    return false;
                }
                if (Approvedby == "" || Approvedby=="0")
                {
                    Utility.ShowMessage_Error(Page, "Please Select Approved by and Update !!");
                    ddlApprovedBy.Focus();
                    return false;
                }
                if (ShippmentBy == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Select Shippment By and Update !!");
                    ddlShipment.Focus();
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void ddlContainerNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlContainerNo.SelectedIndex > 0)
            {
                pogrid.Visible = true;
                containerProjects.Visible = true;
                AutoFillData();
                Bind_GridChangeContainer();
                BindJobGrid();                
                btnSubmit.Enabled = true;
                btnNotify.Enabled = true;
                btnAddProjects.Enabled = true;
                btnPackingDetails.Enabled = true;
                hfContaineridgetfromdb.Value = ddlContainerNo.SelectedValue;
            }
            else
            {
                var temp = ddlVendorLookup.SelectedValue;
                reset();
                ddlVendorLookup.SelectedValue = temp;
                VendorLookupEvent("");
                pogrid.Visible = false;
                containerProjects.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    protected void ddlVendorLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        VendorLookupEvent("");
    }

    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {            
            if (ddlVendor.SelectedIndex > 0)
            {                
                containerProjects.Visible = true;
                var temp = ddlVendor.SelectedValue;
                reset();
                ddlVendor.SelectedValue = temp;
                Bind_Grid();
                Bind_GridContainer();
            }
            else
            {
                reset();
                GridReset();
                pogrid.Visible = false;
                containerProjects.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvContainer_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtSkidNo = (TextBox)e.Row.FindControl("txtSkidNo");
                TextBox txtShipQty = (TextBox)e.Row.FindControl("txtShippingQty");
                TextBox txtItemRemarks = (TextBox)e.Row.FindControl("txtItemRemarks");
                DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlstatus");
                Label ddlStatusLabel = (Label)e.Row.FindControl("lblStatus");
                ddlStatus.SelectedValue = ddlStatusLabel.Text;
                //DropDownList ddlShipmentBy = (DropDownList)e.Row.FindControl("ddlShipmentBy");
                //Label lblShipmentBy = (Label)e.Row.FindControl("lblShipmentBy");
                //ddlShipmentBy.SelectedValue = lblShipmentBy.Text;
                if (ddlStatus.SelectedValue == "2")
                {
                    txtShipQty.Enabled = false;
                    txtSkidNo.Enabled = false;
                    txtItemRemarks.Enabled = false;
                    ddlStatus.Enabled = false;
                }
                else
                {
                    txtSkidNo.Enabled = true;
                    txtShipQty.Enabled = true;
                    txtItemRemarks.Enabled = true;
                    ddlStatus.Enabled = true;
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
            ddlVendor.SelectedIndex = 0;
            txtTentativeSentDate.Text = String.Empty;
            ddlApprovedBy.SelectedIndex = 0;
            txtInvoiceNo.Text = String.Empty;
            txtContainerNo.Text = String.Empty;
            txtSealNo.Text = String.Empty;
            txtsentdate.Text = String.Empty;
            txtArrivalinAerowerks.Text = String.Empty;
            txtContainer.Text = String.Empty;
            ddlAttn.SelectedIndex = 0;
            ddlIssuedBy.SelectedIndex = 0;
            ddlShipment.SelectedIndex = 0;
            lnkDownload.Text = String.Empty;

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void VendorLookupEvent(string containerID)
    {
        try
        {
            if (ddlVendorLookup.SelectedIndex > 0)
            {
                ObjBOL.Operation = 10;
                ObjBOL.SourceID = Int32.Parse(ddlVendorLookup.SelectedValue);
                reset();
                ddlVendorLookup.SelectedValue = ObjBOL.SourceID.ToString();
                DataSet ds = ObjBLL.GetBindControl(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlContainerNo, ds.Tables[0]);
                    if (containerID != "")
                    {
                        ddlContainerNo.SelectedValue = containerID;
                    }
                }
            }
            else
            {
                reset();
            }
            pogrid.Visible = false;
            containerProjects.Visible = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetForm()
    {
        try
        {
            reset();
            pogrid.Visible = false;
            btnNotify.Enabled = false;
            containerProjects.Visible = false;
            divError.Visible = false;
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
            ResetForm();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        
    }

    private void reset()
    {
        try
        {
            ResetControls();
            ddlContainerNo.Items.Clear();
            ddlVendorLookup.SelectedIndex = 0;
            btnSubmit.Enabled = false;
            btnNotify.Enabled = false;
            btnAddProjects.Enabled = false;
            btnPackingDetails.Enabled = false;          
            GridReset();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GridReset()
    {
        try
        {
            gvMainRequisitionDetail.DataSource = string.Empty;
            gvMainRequisitionDetail.DataBind();
            gvContainerProjects.DataSource = string.Empty;
            gvContainerProjects.DataBind();
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
            clscon.Return_DT(dt, "EXEC [dbo].[Get_PackingDetails] '" + ddlContainerNo.SelectedValue + "'");
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
            if (dt.Rows.Count > 0)
            {
                rprt.Load(Server.MapPath("~/Reports/rptPackingDetails.rpt"));
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            }
            else
            {
                Utility.ShowMessage_Warning(Page, "No Matching Data Found !!");
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if(ddlContainerNo.SelectedIndex>0)
            {
                if (CheckMandetoryFieldsBeforeSubmit() == true)
                {
                    DataTable dtPackingData = new DataTable();
                    dtPackingData = ReportDataZero();
                    if (dtPackingData.Rows.Count > 0)
                    {
                        string msg = "";
                        btnNotify.Enabled = true;
                        var EmployeeID = Utility.GetCurrentSession().EmployeeID;
                        ObjBOL.Operation = 6;
                        ObjBOL.LoginUserId = EmployeeID;
                        if (ddlContainerNo.SelectedIndex > 0)
                        {
                            ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
                        }
                        msg = ObjBLL.UpdateContainerStatus(ObjBOL);
                        Utility.ShowMessage_Success(Page, "Container Submitted Successfully !!");
                        SendEmail_Prepare("1");
                        ResetForm();
                        Response.Redirect("~/InventoryManagement/frmPrepareContainer.aspx", false);
                    }
                    else
                    {
                        Utility.ShowMessage_Warning(Page, "No Maching Data Found !!");
                    }
                }
            }
            else
            {
                Utility.ShowMessage_Warning(Page, "Please Select Container No.");
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
            if (ddlContainerNo.SelectedIndex > 0)
            {
                if (CheckMandetoryFieldsBeforeSubmit() == true)
                {
                    DataTable dt = new DataTable();
                    dt = ReportDataZero();
                    if (dt.Rows.Count > 0)
                    {
                        SendEmail_Prepare("2");
                        Utility.ShowMessage_Success(Page, "Email Sent Successfully !!");
                        ResetForm();
                        Response.Redirect("~/InventoryManagement/frmPrepareContainer.aspx", false);
                    }
                    else
                    {
                        Utility.ShowMessage_Warning(Page, "No Maching Data Found !!");
                    }
                }
            }
            else
            {
                Utility.ShowMessage_Warning(Page, "Please Select Container No.");
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnAddProjects_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlContainerNo.SelectedIndex > 0)
            {
                resetJobConrols();
                lblShowMsg.Text = String.Empty;
                ModalPopupExtender1.Show();
                lblJobProjects.Text = ddlContainerNo.SelectedItem.Text;                
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Boolean JobValidationCheck()
    {
        try
        {
            if (txtJobNo.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Job No !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Job No !");
                txtJobNo.Focus();
                ModalPopupExtender1.Show();
                return false;
            }
            if (txtJobQty.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Quantity !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Quantity !");
                txtJobQty.Focus();
                ModalPopupExtender1.Show();
                return false;
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        return true;
    }



    protected void btnJobSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (JobValidationCheck() == true)
            {
                string msg = "";
                ObjBOL.Operation = 12;
                ObjBOL.LoginUserId= Utility.GetCurrentSession().EmployeeID;
                ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
                ObjBOL.JobID = txtJobNo.Text;
                ObjBOL.Desc = txtDesc.Text;
                ObjBOL.Requestor = txtRequestor.Text;
                ObjBOL.SourceID =Convert.ToInt32(ddlVendorLookup.SelectedValue);
                ObjBOL.JobQty = Convert.ToInt32(txtJobQty.Text);
                ObjBOL.JobRemarks = txtJobRemarks.Text;
                msg = ObjBLL.SaveJobDetails(ObjBOL);
                if(msg== "Duplicate Job#/Part# !!!")
                {
                    Utility.ShowMessage_Warning(Page, msg);
                }
                else
                {
                    Utility.ShowMessage_Success(Page, msg);                    
                }
                //lblShowMsg.Text = msg;
                BindJobGrid();
                resetJobConrols();
                ModalPopupExtender1.Show();       
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
   
    protected void btnJobCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ModalPopupExtender1.Hide();
            resetJobConrols();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);            
        }
    }

    private void resetJobConrols()
    {
        try
        {
            txtJobNo.Text = String.Empty;
            txtDesc.Text = String.Empty;
            txtRequestor.Text = String.Empty;
            txtJobQty.Text = String.Empty;
            txtJobRemarks.Text = String.Empty;                       
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindJobGrid()
    {
        try
        {
            if(ddlContainerNo.SelectedIndex>0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 13;
                ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
                ds = ObjBLL.GetBindControl(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvContainerProjects.DataSource = ds.Tables[0];
                    gvContainerProjects.DataBind();
                }
                else
                {
                    gvContainerProjects.DataSource = string.Empty;
                    gvContainerProjects.DataBind();
                }
            }

        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }


    protected void gvContainerProjects_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = gvContainerProjects.Rows[e.RowIndex];
            Int32 ContainerProjectsID = Convert.ToInt32(gvContainerProjects.DataKeys[e.RowIndex].Value);
            ObjBOL.LoginUserId = Utility.GetCurrentSession().EmployeeID;
            ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
            ObjBOL.ContainerProjectsID = ContainerProjectsID;
            ObjBOL.Operation = 14;
            msg = ObjBLL.DeleteJobDetails(ObjBOL);
            BindJobGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    
    private DataTable ReportDataFirst()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[Get_PackingDetails_Jobs] '" + ddlContainerNo.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }
    protected void btnPackingDetails_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt = ReportDataZero();
            dt1 = ReportDataFirst();
            if (dt.Rows.Count > 0 || dt1.Rows.Count > 0)
            {
                rprt.Load(Server.MapPath("~/Reports/rptPackingDetails.rpt"));
                string txtheader = txtInvoiceNo.Text + "-" + txtContainerNo.Text;
                rprt.SetDataSource(dt);
                rprt.Subreports[0].SetDataSource(dt1);
                rptGenerateReport.ReportSource = rprt;
                rptGenerateReport.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader);
            }
            else
            {
                Utility.ShowMessage_Warning(Page, "No Maching Data Found !!");
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

    //btnContainerReport_Click
    protected void btnContainerReport_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Reports/frmContainerReport.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        try
        {
            GetFilePaths();
            string filePath = folderPath + hfInvoiceNodrwaing.Value.Replace(",","");
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                // Clear Rsponse reference
                Response.Clear();
                // Add header by specifying file name
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                // Add header for content length
                Response.AddHeader("Content-Length", file.Length.ToString());
                // Specify content type
                Response.ContentType = "text/plain";
                // Clearing flush
                Response.Flush();
                // Transimiting file
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetPackingListDate()
    {        
        try
        {
            DateTime date = DateTime.Now;
            int days=Convert.ToInt32(DateTime.Now.AddDays(14));
            Utility.AddBusinessDays(date,days);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);   
        }
        
    }

    public string ConverterDate(string ddate)
    {
        if (ddate != "")
        {
            ddate = Convert.ToDateTime(ddate).ToString("MMMM dd, yyyy");
            return ddate;
        }
        else
        {
            //return ddate.ToString();
            return null;
        }
    }

    private void SendEmail_Prepare(string submitandnotify)
    {
        try
        {
            string Message = string.Empty;
            Message += "<!doctype><html lang='en'><head><meta charset = 'utf-8'><meta name = 'viewport' content = 'width=device-width, initial-scale=1'> ";
            Message += " <title> Packing List </title></head><body><table cellpadding='0' cellspacing='0' style='border-collapse:collapse;width:100%;font-family:Calibri;font-size:1.15rem'> ";
            Message += " <tr><td><table border='1' cellpadding='8' cellspacing='0' style='border-collapse:collapse;width:100%;max-width:580px;margin:0 auto;border-color:#ddd'> ";
            Message += " <tr><td colspan='2'><h2 style='margin:0;font-size:1.15rem'> Amritpal,</h2> ";
            Message += " <p style = 'margin-top:5px'> You will find the  <b>Invoice No: " + txtInvoiceNo.Text + "</b>. Attached, "; 
            if (submitandnotify == "2")
            {
                Message += " please review and let us know by <b> "+ Utility.AddBusinessDays(DateTime.Now,14).ToString("MMMM dd, yyyy")  +" </b>, if you wish to make any changes.</p> ";
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
            Message += " <h1 style ='font-size:1.65rem;margin:.3rem 0 0;color:#000;text-align:center'>Packing List</h1></td></tr> ";
            Message += " <tr><td style='width:1%;white-space:nowrap'>Invoice No</td><td style='font-weight:600;width:99%'>" + txtInvoiceNo.Text + " </td></tr>";
            Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'>Container No </td><td style='font-weight:600;width:99%'> " + txtContainerNo.Text + "</td></tr>";
            Message += " <tr><td style='width:1%;white-space:nowrap'> Seal No </td><td style='font-weight:600;width:99%'>" + txtSealNo.Text + "</td></tr> ";
            Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Tentative Sent Date </td><td style='font-weight:600;width:99%' > " + ConverterDate(txtTentativeSentDate.Text) + "</td></tr> ";
            if (ddlIssuedBy.SelectedItem.Text != "Select")
            {
                Message += " <tr><td style='width:1%;white-space:nowrap'> Issued By </td><td style='font-weight:600;width:99%'>" + ddlIssuedBy.SelectedItem.Text + "</td></tr> ";
            }
            else
            {
                Message += " <tr><td style='width:1%;white-space:nowrap'> Issued By </td><td style='font-weight:600;width:99%'>" + "" + "</td></tr> ";
            }
            if (ddlApprovedBy.SelectedItem.Text != "Select")
            {
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Approved By </td><td style='font-weight:600;width:99%' > " + ddlApprovedBy.SelectedItem.Text + "</td></tr> ";
            }
            else
            {
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Approved By </td><td style='font-weight:600;width:99%' > " + "" + "</td></tr> ";
            }
            Message += " <tr><td style='width:1%;white-space:nowrap'> Tentative Arrival Date </td><td style='font-weight:600;width:99%'> " + ConverterDate(txtArrivalinAerowerks.Text) + "</td></tr> ";
            if (submitandnotify == "1")
            {
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Submitted By </td><td style='font-weight:600;width:99%'> " + Utility.GetCurrentSession().EmployeeName + "</td></tr>";
                Message += " <tr><td style='width:1%;white-space:nowrap'> Submitted Date / Time </td><td style='font-weight:600;width:99%'> " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt") + "</td></tr> ";
            }
            Message += " <tr><td colspan = '2'>If you have any questions or concerns regarding your order, please contact the purchasing department. <br /><br /> ";
            Message += " Thanks, <br/ > <strong> Aerowerks India </strong> <br /> ";
            Message += " </td></tr></table></td></tr></table></body></html> ";
            List<MailAddress> sendToList = new List<MailAddress>();                     
            List<MailAddress> ccList = new List<MailAddress>();
            sendToList.Add(MailAddress_Amritpal);
            ccList.Add(MailAddress_Raman);
            ccList.Add(MailAddress_MrSingh);
            ccList.Add(MailAddress_Kapil);
            ccList.Add(MailAddress_Saurabh);
            ccList.Add(MailAddress_Stan);
            ccList.Add(MailAddress_Karam);
            ccList.Add(MailAddress_Ping);
            ccList.Add(MailAddress_Purchasing);
            ccList.Add(MailAddress_AeroIt);
            if (ddlVendor.SelectedValue == "1")
            {
                ccList.Add(MailAddress_Triflex);
            }
            else if (ddlVendor.SelectedValue == "2")
            {
                ccList.Add(MailAddress_Office);
            }
            Send_Email(Message, "Packing List" + " (" + "Invoice No : " + txtInvoiceNo.Text + ") ", sendToList);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Send_Email(String Message, string Subject, List<MailAddress> sendToList)
    {
        try
        {
            MailMessage message = new MailMessage(MailAddress_AeroIt, sendToList[0]);

            string mailbody = Message;
            //message.CC.Add(cc);
            message.Subject = Subject;
            message.Body = mailbody;
            Attachment file = new Attachment(GetPackingDetailsReportStream(), "Packing List" + "(" + txtInvoiceNo.Text + ")" + ".pdf", "application/pdf");
            message.Attachments.Add(file);
            foreach (var sendto in sendToList)
            {
                message.To.Add(sendto);
            }
            //message.CC.Add(MailAddress_Kapil);
            //message.CC.Add(MailAddress_MrSingh);           
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
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void PrepareReport()
    {
        try
        {
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            dt2 = ReportDataZero();
            dt3 = ReportDataFirst();
            if (dt2.Rows.Count > 0 || dt3.Rows.Count > 0)
            {
                rprt.Load(Server.MapPath("~/Reports/rptPackingDetails.rpt"));
                rprt.SetDataSource(dt2);
                rprt.Subreports[0].SetDataSource(dt3);
                rptGenerateReport.ReportSource = rprt;
                rptGenerateReport.DataBind();
            }
            else
            {
                Utility.ShowMessage_Warning(Page, "No Matching Data Found !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Stream GetPackingDetailsReportStream()
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
                try
                {
                    rprt.Close();
                    rprt.Dispose();
                }
                catch (Exception ex)
                {
                    Utility.AddEditException(ex);
                }                
            }
        }
        return reportStream;
    }
}