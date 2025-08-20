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
using System.Linq;
using System.Collections;

public partial class InventoryManagement_frmPrepareContainerNew : System.Web.UI.Page
{
    BOLPrepareContainer ObjBOL = new BOLPrepareContainer();
    BLLPrepareContainerNew ObjBLL = new BLLPrepareContainerNew();
    commonclass1 cls = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    string FileExtention = null;
    public static readonly List<string> ImageExtensionsPdf = new List<string> { ".pdf" };
    string msg = "";
    int count = 0;
    string status = "";    
    string folderPath = string.Empty;    
    string Do_Not_Reply = "[Please do not reply to this message. Replies to this message are routed to an unmonitored mailbox]";
    bool MatchArrivalDateFromDB = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                if (!IsPostBack)
                {
                    pogrid.Visible = false;
                    containerProjects.Visible = false;
                    hfContaineridgetfromdb.Value = null;
                    EmptyDT();
                    AutoBindContainer(Utility.GetCurrentSession().EmployeeID);
                    Bind_Controls(msg, "");
                    Bind_ApprovedBy();

                }
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }
    #region Look Ups
    protected void ddlContainerNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetContainerOnLookups();
            if (ddlContainerNo.SelectedIndex > 0)
            {
                //BindPartNoandDesc(ddlVendorLookup.SelectedValue);
                pogrid.Visible = true;                
                containerProjects.Visible = true;
                AutoFillData();
                Bind_GridChangeContainer();
                BindJobGrid();
                CheckStatus();
                hfContaineridgetfromdb.Value = ddlContainerNo.SelectedValue;
            }
            else
            {
                var temp = ddlVendorLookup.SelectedValue;
                reset();
                ddlVendorLookup.SelectedValue = temp;
                VendorLookupEvent("");
                pogrid.Visible = false;
                dvContainerInfo.Visible = false;
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
            ResetContainerOnLookups();
            if (ddlVendor.SelectedIndex > 0)
            {                
                var temp = ddlVendor.SelectedValue;
                reset();
                ddlVendor.SelectedValue = temp;
                BindDestWareHouse(ddlVendor.SelectedValue);
                
            }
            else
            {
                reset();                
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
            ObjBOL.Operation = 22;
            if(selectedSourceID != "")
            {
                ObjBOL.SourceID = Convert.ToInt32(selectedSourceID);
            }            
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDestWareHouse, ds.Tables[0]);
                if (ddlDestWareHouse.Items.Count > 0)
                {
                    ddlDestWareHouse.SelectedIndex = 0;
                }
            }
            else
            {
                if (ddlDestWareHouse.Items.Count > 0)
                {
                    ddlDestWareHouse.Items.Clear();
                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlDestWareHouse_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDestWareHouse.SelectedIndex > 0)
            {
                string sourceID = string.Empty;
                string DestWareHouseID = string.Empty;
                sourceID = ddlVendor.SelectedValue;
                DestWareHouseID = ddlDestWareHouse.SelectedValue;
                BindPartNoandDesc(sourceID, DestWareHouseID);
                Bind_GridContainer();
            }
            else
            {
                GridReset();
                pogrid.Visible = false;
                containerProjects.Visible = false;
                dvContainerInfo.Visible = false;
            }
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
            ResetContainerOnLookups();
            if (ddlVendorLookup.SelectedIndex > 0)
            {
                //BindPartNoandDesc(ddlVendorLookup.SelectedValue);
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
                dvContainerInfo.Visible = false;
            }
            pogrid.Visible = false;
            containerProjects.Visible = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Container Details Table
    private void BindPartNoandDesc(string vendor, string DestWareHouse)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 7;
            if(vendor != "")
            {
                ObjBOL.SourceID = Convert.ToInt32(vendor);
            }
            if(DestWareHouse != "")
            {
                ObjBOL.WarehouseID = Convert.ToInt32(DestWareHouse);
            }            
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartNo, ds.Tables[0]);
                ddlPartNo.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void Bind_GridByVendor()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 7;
            ObjBOL.SourceID = Convert.ToInt32(ddlVendor.SelectedValue);
            ObjBOL.WarehouseID = Convert.ToInt32(ddlDestWareHouse.SelectedValue);
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
                gvMainRequisitionDetail.DataSource = "";
                gvMainRequisitionDetail.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindPONumber(string source, string PartId)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.SourceID = Convert.ToInt32(source);
            ObjBOL.PartId = Convert.ToInt32(PartId);
            ds = ObjBLL.GetBindControl(ObjBOL);
            count = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (count == 1)
                {
                    Utility.BindDropDownList(ddlPONumber, ds.Tables[0]);
                    ddlPONumber.SelectedValue = ds.Tables[0].Rows[0]["POid"].ToString();
                    BindPartInformation(ddlVendor.SelectedValue, ddlPartNo.SelectedValue, ddlPONumber.SelectedValue);
                }
                else
                {
                    Utility.BindDropDownList(ddlPONumber, ds.Tables[0]);
                    ddlPONumber.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindPartInformation(string source, string partid, string poid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.SourceID = Convert.ToInt32(source);
            ObjBOL.PartId = Convert.ToInt32(partid);
            ObjBOL.POid = Convert.ToInt32(poid);
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                lblOrder.Text = ds.Tables[1].Rows[0]["OrderQty"].ToString();
                lblPending.Text = ds.Tables[1].Rows[0]["PendingQty"].ToString();
                ddlStatus.SelectedValue = ds.Tables[1].Rows[0]["Status"].ToString();
                hfPODetailid.Value = ds.Tables[1].Rows[0]["PODetailid"].ToString();
                if (ddlStatus.SelectedValue == "2")
                {
                    Hide();
                }
                else
                {
                    Show();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Show()
    {
        try
        {
            txtShipped.Enabled = true;
            txtSkid.Enabled = true;
            txtRemarks.Enabled = true;
            ddlStatus.Enabled = true;
            btnAdd.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Hide()
    {
        try
        {
            txtShipped.Enabled = false;
            txtSkid.Enabled = false;
            txtRemarks.Enabled = false;
            ddlStatus.Enabled = false;
            btnAdd.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetContainerOnPONumber()
    {
        try
        {
            lblOrder.Text = String.Empty;
            lblPending.Text = String.Empty;
            txtShipped.Text = String.Empty;
            txtSkid.Text = String.Empty;
            txtRemarks.Text = String.Empty;
            ddlStatus.SelectedValue = "1";
            Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetContainerOnLookups()
    {
        try
        {            
            if(ddlPartNo.Items.Count>0)
            {
                ddlPartNo.Items.Clear();
            }            
            if (ddlPONumber.Items.Count > 0)
            {
                ddlPONumber.Items.Clear();
            }
            lblOrder.Text = String.Empty;
            lblPending.Text = String.Empty;
            txtShipped.Text = String.Empty;
            txtSkid.Text = String.Empty;
            txtRemarks.Text = String.Empty;
            ddlStatus.SelectedValue = "1";
            Show();
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
            ResetContainerOnPONumber();
            ddlPONumber.Items.Clear();
            if (ddlPartNo.SelectedIndex > 0)
            {
                if (ddlVendor.SelectedIndex > 0)
                {
                    BindPONumber(ddlVendor.SelectedValue, ddlPartNo.SelectedValue);
                }
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPONumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPONumber.SelectedIndex > 0)
            {
                BindPartInformation(ddlVendor.SelectedValue, ddlPartNo.SelectedValue, ddlPONumber.SelectedValue);
            }
            else
            {
                ResetContainerOnPONumber();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Boolean AddDetails()
    {
        try
        {
            SaveGridData();
            DataTable dt = (DataTable)ViewState["ContainerSummary"];
            DataRow dr;
            dr = dt.NewRow();
            int partid = Convert.ToInt32(ddlPartNo.SelectedValue);
            int poid = Convert.ToInt32(ddlPONumber.SelectedValue);
            string ponumber = ddlPONumber.SelectedItem.Text;
            int podetailid = Convert.ToInt32(hfPODetailid.Value);
            string partnumber = ddlPartNo.SelectedItem.Text;
            string orderqty = String.Empty;
            if (lblOrder.Text == "")
            {
                orderqty = "0";
            }
            else
            {
                orderqty = lblOrder.Text;
            }
            string pendingqty = String.Empty;
            if (lblPending.Text == "")
            {
                pendingqty = "0";
            }
            else
            {
                pendingqty = lblPending.Text;
            }
            string shipqty = String.Empty;
            if (txtShipped.Text == "")
            {
                shipqty = "0";
            }
            else
            {
                shipqty = txtShipped.Text;
            }
            if (Convert.ToInt32(shipqty) > Convert.ToInt32(pendingqty))
            {
                Utility.ShowMessage_Error(Page, "Ship Qty Not More than Pending Qty");
                txtShipped.Text = String.Empty;
                return false;
            }
            string skidno = txtSkid.Text;
            string remarks = txtRemarks.Text;
            string status = ddlStatus.SelectedValue;
            PrepareDT(poid, ponumber, podetailid, partid, partnumber, orderqty, pendingqty, shipqty, skidno, remarks, status);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void PrepareDT(int poid, string PONumber, int PoDetailid, int partid, string partnumber, string orderqty, string pendingqty, string shipqty, string skidno, string remarks, string status)
    {
        try
        {
            DataTable dtCurrentTable = (DataTable)ViewState["ContainerSummary"];
            DataRow drCurrentRow = null;
            drCurrentRow = dtCurrentTable.NewRow();
            drCurrentRow["poid"] = poid;
            drCurrentRow["PONumber"] = PONumber;
            drCurrentRow["PoDetailid"] = PoDetailid;
            drCurrentRow["Partid"] = partid;
            drCurrentRow["PartNumber"] = partnumber;
            drCurrentRow["orderqty"] = Convert.ToInt32(orderqty);
            drCurrentRow["pendingqty"] = Convert.ToInt32(pendingqty);
            drCurrentRow["shipqty"] = Convert.ToInt32(shipqty);
            drCurrentRow["skidno"] = skidno;
            drCurrentRow["remarks"] = remarks;
            drCurrentRow["status"] = Convert.ToInt32(status);
            for (int i = dtCurrentTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtCurrentTable.Rows[i];
                int qty1 = Convert.ToInt32(shipqty);
                int qty2 = Convert.ToInt32(dr["shipqty"].ToString());
                int poid1 = Convert.ToInt32(poid);
                int poid2 = Convert.ToInt32(dr["shipqty"].ToString());
                if (dr["poid"].ToString() == Convert.ToString(poid) && dr["Partid"].ToString() == Convert.ToString(partid))
                {
                    drCurrentRow["shipqty"] = qty1 + qty2;
                    dr.Delete();
                }
            }
            if (drCurrentRow["Partid"].ToString() == "")
            {
                drCurrentRow.Delete();
            }
            dtCurrentTable.AcceptChanges();
            dtCurrentTable.Rows.Add(drCurrentRow);
            dtCurrentTable.DefaultView.Sort = "PONumber ASC";
            DataTable dt = (DataTable)ViewState["ContainerSummary"];
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
            dtMainTable.Columns.Add(new DataColumn("POid", typeof(int)));
            dtMainTable.Columns.Add(new DataColumn("PODetailId", typeof(int)));
            dtMainTable.Columns.Add(new DataColumn("partid", typeof(int)));
            dtMainTable.Columns.Add(new DataColumn("PartNumber", typeof(string)));
            DataRow drMainRow = null;
            foreach (DataRow dtMainRow in DTSummary.Rows)
            {
                drMainRow = dtMainTable.NewRow();
                drMainRow["poid"] = dtMainRow["poid"].ToString();
                drMainRow["PoDetailid"] = dtMainRow["PoDetailid"].ToString();
                drMainRow["Partid"] = dtMainRow["Partid"].ToString();
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
                gvMainRequisitionDetail.DataSource = dtMainTable;
                gvMainRequisitionDetail.DataBind();
                foreach (GridViewRow row in gvMainRequisitionDetail.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        string partid = gvMainRequisitionDetail.DataKeys[row.RowIndex].Value.ToString();
                        GridView gvContainer = row.FindControl("gvContainer") as GridView;
                        DataTable updatedSummary = new DataTable();
                        updatedSummary.TableName = "ChildSummary";
                        updatedSummary.Columns.Add(new DataColumn("POid", typeof(int)));
                        updatedSummary.Columns.Add(new DataColumn("PONumber", typeof(string)));
                        updatedSummary.Columns.Add(new DataColumn("PODetailId", typeof(int)));
                        updatedSummary.Columns.Add(new DataColumn("partid", typeof(int)));
                        updatedSummary.Columns.Add(new DataColumn("PartNumber", typeof(string)));
                        updatedSummary.Columns.Add(new DataColumn("OrderQty", typeof(int)));
                        updatedSummary.Columns.Add(new DataColumn("Pendingqty", typeof(int)));
                        updatedSummary.Columns.Add(new DataColumn("ShipQty", typeof(int)));
                        updatedSummary.Columns.Add(new DataColumn("SkidNo", typeof(string)));
                        updatedSummary.Columns.Add(new DataColumn("Remarks", typeof(string)));
                        updatedSummary.Columns.Add(new DataColumn("Status", typeof(int)));
                        DataRow dr = null;
                        foreach (DataRow dtRow in DTSummary.Rows)
                        {
                            if (dtRow["partid"].ToString() == partid)
                            {
                                dr = updatedSummary.NewRow();
                                dr["poid"] = dtRow["poid"].ToString();
                                dr["PONumber"] = dtRow["PONumber"].ToString();
                                dr["PoDetailid"] = dtRow["PoDetailid"].ToString();
                                dr["Partid"] = dtRow["Partid"].ToString();
                                dr["PartNumber"] = dtRow["PartNumber"].ToString();
                                dr["orderqty"] = dtRow["orderqty"].ToString();
                                dr["pendingqty"] = dtRow["pendingqty"].ToString();
                                dr["shipqty"] = dtRow["shipqty"].ToString();
                                dr["skidno"] = dtRow["skidno"].ToString();
                                dr["remarks"] = dtRow["remarks"].ToString();
                                dr["status"] = dtRow["status"].ToString();
                                updatedSummary.AcceptChanges();
                                updatedSummary.Rows.Add(dr);
                                updatedSummary.DefaultView.Sort = "PONumber ASC";
                                gvContainer.DataSource = updatedSummary;
                                gvContainer.DataBind();
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                if (ValidationPartDetails() == true)
                {
                    pogrid.Visible = true;
                    if (AddDetails() ==true)
                    {
                        ResetContainerOnPONumber();
                        ddlPartNo.SelectedIndex = 0;
                        if (ddlPONumber.Items.Count > 0)
                        {
                            ddlPONumber.Items.Clear();
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

    private void DisabledButton()
    {
        try
        {
            btnSave.Enabled = false;
            btnNotify.Enabled = false;
            btnSubmit.Enabled = false;
            btnGenerate.Enabled = false;
            btnAddProjects.Enabled = false;
            btnPackingDetails.Enabled = false;
            btnPackingDetailsExcel.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnabledButton()
    {
        try
        {
            btnSave.Enabled = true;
            if (ddlVendorLookup.SelectedIndex > 0)
            {
                btnNotify.Enabled = true;
                btnSubmit.Enabled = true;
                btnGenerate.Enabled = true;
                btnPackingDetails.Enabled = true;
                btnPackingDetailsExcel.Enabled = true;
                btnAddProjects.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #region Upload PDF Module
    private void AutoBindContainer(int EmployeeID)
    {
        try
        {            
            DataSet ds = new DataSet();           
            ObjBOL.Operation = 19;
            ObjBOL.EmployeeID = Utility.GetCurrentSession().EmployeeID;
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlVendorLookup, ds.Tables[0]);
                    Utility.BindDropDownList(ddlVendor, ds.Tables[0]);
                    CheckStatus();
                }
                else
                {
                    CheckStatus();
                }
            }
            else
            {
                CheckStatus();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckStatus()
    {
        try
        {
            string ContainerStatus = "";
            ObjBOL.Operation = 20;
            ObjBOL.EmployeeID = Utility.GetCurrentSession().EmployeeID;
            ContainerStatus = ObjBLL.CheckContainerStatus(ObjBOL);
            ViewState["ContainerStatus"] = ContainerStatus;
            if (ContainerStatus == "True")
            {
                EnabledButton();
            }
            else
            {
                DisabledButton();
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

    private Boolean SavePdf()
    {
        try
        {
            GetFilePaths();
            if (fpuploadfile.HasFile)
            {
                FileExtention = System.IO.Path.GetExtension(fpuploadfile.FileName.Replace(",", ""));
            }
            string File = FileExtention.ToLower();
            if (ImageExtensionsPdf.Contains(File))
            {
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists Create it.
                    Directory.CreateDirectory(folderPath);
                }
                int fileSize = fpuploadfile.PostedFile.ContentLength;
                // Convert the bytes to Kilobytes (1 KB = 1024 Bytes)
                double fileSizeInKB = fileSize / 1024.0;
                if (fileSizeInKB > Utility.FileSizeLimits(File))
                {
                    Utility.ShowMessage_Error(Page, "File size exceeds " + Utility.AllowedFileSize_Pdf + "KB. Please choose a smaller file. !!");
                    return false;
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

    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        try
        {
            GetFilePaths();
            string filePath = folderPath + hfInvoiceNodrwaing.Value.Replace(",", "");
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

    #endregion    

    #region Grid Module
    private void Bind_Grid()
    {
        try
        {
            var EmployeeID = Utility.GetCurrentSession().EmployeeID;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.SourceID = Int32.Parse(ddlVendor.SelectedValue);
            ObjBOL.Containerid =Convert.ToInt32(ddlContainerNo.SelectedValue);            
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                pogrid.Visible = true;
                gvMainRequisitionDetail.DataSource = ds.Tables[1];
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
            Bind_GridByVendor();
            DataSet ds = new DataSet();
            foreach (GridViewRow row in gvMainRequisitionDetail.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string POid= (row.FindControl("lblPOId") as Label).Text;
                    string WareHouseID = (row.FindControl("lblWareHouseID") as Label).Text;
                    GridView gvContainer = row.FindControl("gvContainer") as GridView;
                    string partid = gvMainRequisitionDetail.DataKeys[row.RowIndex].Value.ToString();
                    var EmployeeID = Utility.GetCurrentSession().EmployeeID;
                    ObjBOL.PartId = Convert.ToInt32(partid);
                    ObjBOL.SourceID = Convert.ToInt32(ddlVendor.SelectedValue);
                    ObjBOL.POid = Convert.ToInt32(POid);
                    ObjBOL.WarehouseID = Convert.ToInt32(WareHouseID);
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
            dtEmpty.Columns.Add(new DataColumn("PONumber", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("ReqDetailid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("ReqStatus", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Containerid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("OrderQty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Partid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("PartNumber", typeof(string)));            
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
            dt.Columns.Add(new DataColumn("PONumber", typeof(string)));
            dt.Columns.Add(new DataColumn("PODetailId", typeof(int)));
            dt.Columns.Add(new DataColumn("ReqStatus", typeof(int)));
            dt.Columns.Add(new DataColumn("Containerid", typeof(int)));
            dt.Columns.Add(new DataColumn("OrderQty", typeof(int)));
            dt.Columns.Add(new DataColumn("partid", typeof(int)));
            dt.Columns.Add(new DataColumn("PartNumber", typeof(string)));            
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
                //if (ddlStatus.SelectedValue == "2")
                //{
                //    txtShipQty.Enabled = false;
                //    txtSkidNo.Enabled = false;
                //    txtItemRemarks.Enabled = false;
                //    //ddlStatus.Enabled = false;
                //}
                //else
                //{
                //    txtSkidNo.Enabled = true;
                //    txtShipQty.Enabled = true;
                //    txtItemRemarks.Enabled = true;
                //    //ddlStatus.Enabled = true;
                //}
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }
    #endregion

    #region Validation Module
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
            if (ddlApprovedBy.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Shipment By. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Approved By. !");
                ddlApprovedBy.Focus();
                return false;
            }
            if (ddlShipment.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Shipment By. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Shipment By. !");
                ddlShipment.Focus();
                return false;
            }
            if (ddlDestWareHouse.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Shipment By. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Destination WareHouse. !");
                ddlDestWareHouse.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private Boolean ValidationPartDetails()
    {
        try
        {
            if (ddlPartNo.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Part# (APN/CPN)");
                ddlPartNo.Focus();
                return false;
            }
            if (ddlPONumber.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select PO Number");
                ddlPONumber.Focus();
                return false;
            }
            if (txtShipped.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Ship Qty");
                txtShipped.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private Boolean CheckMandetoryFieldsBeforeSubmit()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 18;
            ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string vendor = ds.Tables[0].Rows[0]["Vendor"].ToString();
                string Warehouse= ds.Tables[0].Rows[0]["Warehouse"].ToString();
                string InvoiceNo = ds.Tables[0].Rows[0]["InvoiceNo"].ToString();
                string SealNo = ds.Tables[0].Rows[0]["SealNo"].ToString();
                string TentativeSentDate = ds.Tables[0].Rows[0]["TentativeSentDate"].ToString();
                string Approvedby = ds.Tables[0].Rows[0]["ApprovedBy"].ToString();
                string ShippmentBy = ds.Tables[0].Rows[0]["Shipmentby"].ToString();
                if (vendor == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Select Vendor and Update !!");
                    ddlVendor.Focus();
                    return false;
                }
                if(Warehouse == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Select Warehouse and Update !!");
                    ddlDestWareHouse.Focus();
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
                if (Approvedby == "" || Approvedby == "0")
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
    #endregion

    #region Save Module
    private void SaveContainerInfo()
    {
        try
        {
            var EmployeeID = Utility.GetCurrentSession().EmployeeID;
            if(txtInvoiceNo.Text != "")
            {
                ObjBOL.InvoiceNo = txtInvoiceNo.Text.Trim();
            }
            if(txtContainerNo.Text != "")
            {
                ObjBOL.ContainerNo = txtContainerNo.Text.Trim();
            }           
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
                if (SaveArrivalInAerowerksShipmentDateLogs() == true)
                {
                    MatchArrivalDateFromDB = true;
                }
                else
                {
                    MatchArrivalDateFromDB = false;
                }
            }
            ObjBOL.ContainerSize = txtContainer.Text;
            ObjBOL.ApprovedBy = Convert.ToInt32(ddlApprovedBy.SelectedValue);
            ObjBOL.Attn = Convert.ToInt32(ddlAttn.SelectedValue);
            ObjBOL.Issuedby = Convert.ToInt32(ddlIssuedBy.SelectedValue);
            ObjBOL.ShipmentBy = Convert.ToInt32(ddlShipment.SelectedValue);
            if (ddlDestWareHouse.Items.Count > 0)
            {
                ObjBOL.WarehouseID = Convert.ToInt32(ddlDestWareHouse.SelectedValue);
            }
            if (fpuploadfile.HasFile)
            {
                if (SavePdf() == true)
                {
                    ObjBOL.UploadDocument = fpuploadfile.FileName.Replace(",", "");
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (ddlContainerNo.SelectedIndex > 0)
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
                    Utility.ShowMessage_Error(Page, "Invoice No already exists!!");
                    return;
                }
                else if (msg == "ER02")
                {                   
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
            if (MatchArrivalDateFromDB == true)
            {
                SaveArrivalDateLogs();
            }
            btnAddProjects.Enabled = true;
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
                    string DestWareHouseID = (row.FindControl("lblWareHouseID") as Label).Text;
                    string POid = (row.FindControl("lblPOId") as Label).Text;
                    string PartId = gvMainRequisitionDetail.DataKeys[row.RowIndex].Value.ToString();
                    string PODetailId = (row.FindControl("lblPODetailId") as Label).Text;
                    string PartNo = (row.FindControl("lblPartNumber") as Label).Text;
                    GridView gvContainer = row.FindControl("gvContainer") as GridView;
                    foreach (GridViewRow Containerrow in gvContainer.Rows)
                    {
                        if (Containerrow.RowType == DataControlRowType.DataRow)
                        {
                            dr = dt.NewRow();
                            Label POConid = ((Label)Containerrow.FindControl("lblContainerPOId"));
                            Label PONumber = ((Label)Containerrow.FindControl("lblPONumber"));
                            Label PODetailConid = ((Label)Containerrow.FindControl("lblContainerPODetailId"));
                            Label Partid = ((Label)Containerrow.FindControl("lblItemPartid"));
                            Label OrderQty = ((Label)Containerrow.FindControl("lblOrderQty"));
                            Label Pending = ((Label)Containerrow.FindControl("lblPendingQty"));
                            TextBox ShippedQty = ((TextBox)Containerrow.FindControl("txtShippingQty"));
                            TextBox ItemRemarks = ((TextBox)Containerrow.FindControl("txtItemRemarks"));
                            DropDownList ddlStatus = ((DropDownList)Containerrow.FindControl("ddlstatus"));
                            //DropDownList ddlShipmentBy = ((DropDownList)Containerrow.FindControl("ddlShipmentBy"));
                            TextBox SkidNo = ((TextBox)Containerrow.FindControl("txtSkidNo"));
                            dr[0] = Convert.ToInt32(POConid.Text);
                            dr[1] = PONumber.Text;
                            if (PODetailId != "")
                            {
                                dr[2] = PODetailId;
                            }
                            dr[3] = 0;
                            dr[5] = OrderQty.Text;
                            dr[6] = Partid.Text;
                            dr[7] = PartNo;
                            if (ShippedQty.Text != "")
                            {
                                dr[8] = ShippedQty.Text;
                            }
                            else
                            {
                                dr[8] = 0;
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
                            if (Pending.Text != "")
                            {
                                dr[9] = PendingQty;
                            }
                            else
                            {
                                dr[9] = 0;
                            }
                            dr[10] = ItemRemarks.Text;
                            //dr[12] = PackingNo.Text;

                            if (ddlStatus.SelectedValue == "0")
                            {
                                dr[12] = "0";
                            }
                            else
                            {
                                dr[12] = Convert.ToInt32(ddlStatus.SelectedValue);
                            }
                            //if(ddlShipmentBy.SelectedIndex>0)
                            //{
                            //    dr[11] =Convert.ToInt32(ddlShipmentBy.SelectedValue);
                            //}
                            //else
                            //{
                            //    dr[11] = 0;
                            //}
                            if (SkidNo.Text != "")
                            {
                                dr[13] = SkidNo.Text;
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
                btnPackingDetailsExcel.Enabled = true;
                BindJobGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion    

    #region Auto Fill Data
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
                    ObjBOL.PartId = Convert.ToInt32(partid);
                    ObjBOL.POid = Convert.ToInt32(POId.Text);
                    ObjBOL.SourceID = Int32.Parse(ddlVendor.SelectedValue);
                    Label WareHouseID = row.FindControl("lblWareHouseID") as Label;
                    GridView gvContainer = row.FindControl("gvContainer") as GridView;                    
                    if (ddlContainerNo.SelectedIndex > 0)
                    {
                        ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
                    }                   
                    ObjBOL.Operation = 4;
                    if(WareHouseID.Text != "")
                    {
                        ObjBOL.WarehouseID = Convert.ToInt32(WareHouseID.Text);
                    }                                 
                    ds = ObjBLL.GetBindControl(ObjBOL);
                    DataTable dtContainerUpdate = new DataTable();
                    dtContainerUpdate = ds.Tables[2];
                    if (ds.Tables[2].Rows.Count > 0)
                    {                        
                        if (dtContainerUpdate.Rows.Count > 0)
                        {
                            DataView dv = new DataView(dtContainerUpdate);
                            dv.Sort = "ShipQty DESC";
                            dtContainerUpdate = dv.ToTable();
                        }
                        gvContainer.DataSource = dtContainerUpdate;
                        gvContainer.DataBind();
                        
                    }
                    else
                    {
                        gvContainer.DataSource = dtContainerUpdate;
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
                    BindDestWareHouse(ddlVendor.SelectedValue);
                    DataRow dr = ds.Tables[0].Rows[0];
                    Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
                    {
                        { "InvoiceNo", d=> txtInvoiceNo.Text = Convert.ToString(d["InvoiceNo"]) },
                        { "ContainerNo", d=> txtContainerNo.Text = Convert.ToString(d["ContainerNo"]) },
                        { "SealNo", d=> txtSealNo.Text = Convert.ToString(d["SealNo"]) },
                        { "TentativeSentDate", d=> txtTentativeSentDate.Text = cls.Converter(d["TentativeSentDate"].ToString()) },
                        { "SentDate", d=> txtsentdate.Text = cls.Converter(d["SentDate"].ToString()) },
                        { "ArrivalinAerowerks", d=> txtArrivalinAerowerks.Text = cls.Converter(d["ArrivalinAerowerks"].ToString()) },
                        { "ContainerSize", d=> txtContainer.Text = Convert.ToString(d["ContainerSize"]) },
                        { "Attn", d=>
                            {
                                if(ddlAttn.Items.FindByValue(Convert.ToString(d["Attn"])) != null)
                                {
                                    ddlAttn.SelectedValue=Convert.ToString(d["Attn"]);
                                }
                            }
                        },
                        { "ApprovedBy", d=>
                            {
                                if (ddlApprovedBy.Items.FindByValue(Convert.ToString(d["ApprovedBy"])) != null)
                                {
                                    ddlApprovedBy.SelectedValue=Convert.ToString(d["ApprovedBy"]);
                                }
                            }
                        },
                        { "Issuedby", d=>
                            {
                                if (ddlIssuedBy.Items.FindByValue(Convert.ToString(d["Issuedby"])) != null)
                                {
                                    ddlIssuedBy.SelectedValue = Convert.ToString(d["Issuedby"]);
                                }
                            }
                        },
                        { "Shipmentby", d=> ddlShipment.SelectedValue = Convert.ToString(d["Shipmentby"]) },
                        { "UploadDocument", d=> 
                            {
                                if (Convert.ToString(d["UploadDocument"]) != "")
                                {
                                    GetFilePaths();
                                    List<string> list = new List<string>();
                                    list.Add(Convert.ToString(d["UploadDocument"]));
                                    String[] str = list.ToArray();
                                    String[] invNo = str[0].Split('/');
                                    lnkDownload.Text = invNo[0].ToString();
                                    FileInfo file = new FileInfo(folderPath + Convert.ToString(d["UploadDocument"]));
                                    if(file.Exists)
                                    {
                                        lnkDownload.Visible = true;
                                        hfInvoiceNodrwaing.Value = lnkDownload.Text;
                                    }
                                    else
                                    {
                                        lnkDownload.Visible = false;
                                        lnkDownload.Text = String.Empty;
                                        hfInvoiceNodrwaing.Value = "-1";
                                    }
                                }
                                else
                                {
                                    lnkDownload.Visible = false;
                                    lnkDownload.Text = String.Empty;
                                    hfInvoiceNodrwaing.Value = "-1";
                                }
                            }
                        },
                        { "WareHouseID",
                                d=>
                                {
                                    ddlDestWareHouse.SelectedValue=Convert.ToString(d["WareHouseID"]);
                                }

                        },
                    };
                    foreach (var assignment in assignments)
                    {
                        try
                        {
                            assignment.Value(dr);
                        }
                        catch (Exception ex)
                        {
                            Utility.AddEditException(ex, assignment.Key);
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

    #region Report Generate Packing List
    private DataTable ReportDataFirst()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [IV].[Get_PackingDetails_Jobs] '" + ddlContainerNo.SelectedValue + "'");
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

    protected void btnPackingDetailsExcel_Click(object sender, EventArgs e)
    {
        try
        {
            // Step 1: Get your actual data
            DataTable dt = ReportDataZeroExcel();

            // Step 2: Define metadata columns (indexes and order)
            int[] metaColumnIndexes = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            int[] columnsToHide = new int[] {  };

            // Step 3: Build metadata (from dt's first row)
            var metaBuilder = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                foreach (int colIndex in metaColumnIndexes)
                {
                    if (colIndex < dt.Columns.Count)
                    {
                        string colName = dt.Columns[colIndex].ColumnName;
                        string colValue = dt.Rows[0][colIndex].ToString();
                        metaBuilder.AppendFormat("<b>{0}:</b> {1}<br>", HttpUtility.HtmlEncode(colName), HttpUtility.HtmlEncode(colValue));
                    }
                }
            }

            // Step 4: Copy and remove metadata columns from actual data
            DataTable dtCopy = dt.Copy();
            var allColumnsToRemove = metaColumnIndexes.Concat(columnsToHide).Distinct().ToList();

            // Sort in reverse so column indexes stay valid while removing
            allColumnsToRemove.Sort();
            allColumnsToRemove.Reverse();

            foreach (int colIndex in allColumnsToRemove)
            {
                if (colIndex < dtCopy.Columns.Count)
                {
                    dtCopy.Columns.RemoveAt(colIndex);
                }
            }
            
            // Step 5: Bind to GridView
            //GridView gridView = new GridView();
            gvPackingListExcelExport.AllowPaging = false;
            gvPackingListExcelExport.DataSource = dtCopy;
            gvPackingListExcelExport.DataBind();
            foreach (GridViewRow row in gvPackingListExcelExport.Rows)
            {
                row.Cells[7].Style.Add("width", "100");
                row.Cells[7].Style.Add("Height", "110");
                row.Cells[1].Text = row.Cells[1].Text.ToString();
                row.Cells[1].Attributes.Add("style", "mso-number-format:'\\@';");
            }

                // Step 6: Prepare Excel export
                Response.Clear();
            Response.Buffer = true;
            string fileName = txtInvoiceNo.Text + "-" + txtContainerNo.Text + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";

            using (StringWriter sw = new StringWriter())
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                // Write metadata above table
                hw.Write(metaBuilder.ToString());
                hw.Write("<br>");

                // Render table
                gvPackingListExcelExport.RenderControl(hw);

                // Output to response
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
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

    public override void VerifyRenderingInServerForm(Control control)
    {
        // Do nothing – required to avoid runtime error
    }
    #endregion

    #region Email Module
    private void GetPackingListDate()
    {
        try
        {
            DateTime date = DateTime.Now;
            int days = Convert.ToInt32(DateTime.Now.AddDays(14));
            Utility.AddBusinessDays(date, days);
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
            if (Utility.InventoryEmailSwitch())
            {
                string Message = string.Empty;
                Message += "<!doctype><html lang='en'><head><meta charset = 'utf-8'><meta name = 'viewport' content = 'width=device-width, initial-scale=1'> ";
                Message += " <title> Packing List </title></head><body><table cellpadding='0' cellspacing='0' style='border-collapse:collapse;width:100%;font-family:Calibri;font-size:1.15rem'> ";
                Message += " <tr><td><table border='1' cellpadding='8' cellspacing='0' style='border-collapse:collapse;width:100%;max-width:580px;margin:0 auto;border-color:#ddd'> ";
                Message += " <tr><td colspan='2'><h2 style='margin:0;font-size:1.15rem'> Kishore,</h2> ";
                Message += " <p style = 'margin-top:5px'> You will find the  <b>Invoice No: " + txtInvoiceNo.Text + "</b>. Attached, ";
                if (submitandnotify == "2")
                {
                    Message += " please review and let us know by <b> " + Utility.AddBusinessDays(DateTime.Now, 14).ToString("MMMM dd, yyyy") + " </b>, if you wish to make any changes.</p> ";
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
                if (ddlVendor.SelectedIndex > 0)
                {
                    Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Source </td><td style='font-weight:600;width:99%'> " + ddlVendor.SelectedItem.Text + "</td></tr>";
                }
                if (ddlDestWareHouse.SelectedIndex > 0)
                {
                    Message += " <tr><td style='width:1%;white-space:nowrap'> Destination </td><td style='font-weight:600;width:99%'> " + ddlDestWareHouse.SelectedItem.Text + "</td></tr> ";
                }
                
                if (submitandnotify == "1")
                {
                    Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Submitted By </td><td style='font-weight:600;width:99%'> " + Utility.GetCurrentSession().EmployeeName + "</td></tr>";
                    Message += " <tr><td style='width:1%;white-space:nowrap'> Submitted Date / Time </td><td style='font-weight:600;width:99%'> " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt") + "</td></tr> ";
                }
                Message += " <tr><td colspan = '2'>If you have any questions or concerns regarding your order, please contact the purchasing department. <br /><br /> ";
                Message += " Thanks, <br/ > <strong> " + Utility.EmailDisplayName() + " </strong> <br /> ";
                Message += " </td></tr></table></td></tr></table></body></html> ";
                List<MailAddress> sendToList = new List<MailAddress>();
                List<MailAddress> ccList = new List<MailAddress>();
                HashSet<MailAddress> sendToListAsList = new HashSet<MailAddress>();
                HashSet<MailAddress> ccListAsList = new HashSet<MailAddress>();
                sendToListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "SendToList", Utility.emailDictionaryInventory, "Purchasing", 1,"C","");
                ccListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "ccList", Utility.emailDictionaryInventory, "", 2,"C","");
                sendToList = sendToListAsList.ToList();
                ccList = ccListAsList.ToList();
                Send_Email(Message, "Packing List" + " (" + "Invoice No : " + txtInvoiceNo.Text + ") ", sendToList, ccList);
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

    private void Send_Email(String Message, string Subject, List<MailAddress> sendToList, List<MailAddress> ccList)
    {
        try
        {
            if (sendToList.Count > 0)
            {
                using (MemoryStream attachmentStream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(attachmentStream);
                }

                MailMessage message = new MailMessage(new MailAddress(Utility.Email(), Utility.EmailDisplayName()), sendToList[0]);
                string mailSubject = String.Empty;
                mailSubject = "Packing List" + "(" + txtInvoiceNo.Text + ")" + ".pdf";
                string mailbody = Message;
                message.Subject = Subject;
                message.Body = mailbody;

                Attachment file = new Attachment(GetPackingDetailsReportStream(), mailSubject, "application/pdf");
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
                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["Host"], 587);
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromMail"], ConfigurationManager.AppSettings["Password"]);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                client.Send(message);
                file.Dispose();
                Message = string.Empty;
                Utility.ShowMessage_Success(Page, "Email Sent Successfully!!");
            }
            
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
            reportStream=(Stream)rprt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
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
    //btnCrystalError_Click
    protected void btnCrystalError_Click(object sender, EventArgs e)
    {
        try
        {
            dvcrystalerror.Visible = false;
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
            if (ddlContainerNo.SelectedIndex > 0)
            {
                if (CheckMandetoryFieldsBeforeSubmit() == true)
                {
                    DataTable dtPackingData = new DataTable();
                    DataTable dtJobProjectData = new DataTable();
                    dtPackingData = ReportDataZero();
                    dtJobProjectData = ReportDataFirst();
                    if (dtPackingData.Rows.Count > 0 || dtJobProjectData.Rows.Count > 0)
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
                        SendEmail_Prepare("1");                        
                        ResetForm();
                        Utility.ShowMessage_Success(Page, "Container Submitted Successfully!!");
                        if (Utility.InventoryEmailSwitch() == true)
                        {
                            Utility.ShowMessage_Success(Page, "Email Sent Successfully!!");
                        }
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
                    DataTable dtTopGrid = new DataTable();
                    DataTable dtJobGrid = new DataTable();
                    dtTopGrid = ReportDataZero();
                    dtJobGrid = ReportDataFirst();
                    if (dtTopGrid.Rows.Count > 0 || dtJobGrid.Rows.Count > 0)
                    {
                        SendEmail_Prepare("2");
                        ResetForm();
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

    #endregion

    #region Add Job Module
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

    protected void btnJobSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (JobValidationCheck() == true)
            {
                string msg = "";
                ObjBOL.Operation = 12;
                ObjBOL.LoginUserId = Utility.GetCurrentSession().EmployeeID;
                ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
                ObjBOL.JobID = txtJobNo.Text;
                ObjBOL.Desc = txtDesc.Text;
                ObjBOL.Requestor = txtRequestor.Text;
                ObjBOL.SourceID = Convert.ToInt32(ddlVendorLookup.SelectedValue);
                ObjBOL.JobQty = Convert.ToInt32(txtJobQty.Text);
                ObjBOL.JobRemarks = txtJobRemarks.Text;
                msg = ObjBLL.SaveJobDetails(ObjBOL);
                if (msg == "Duplicate Job#/Part# !!!")
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
            if (ddlContainerNo.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 13;
                ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
                ds = ObjBLL.GetBindControl(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    containerProjects.Visible = true;
                    gvContainerProjects.DataSource = ds.Tables[0];
                    gvContainerProjects.DataBind();
                }
                else
                {
                    containerProjects.Visible = false;
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
    #endregion

    #region Reset Modules
    private void ResetControls()
    {
        try
        {
            btnSave.Text = "Save";
            if (ddlVendor.Items.Count > 0)
            {
                ddlVendor.SelectedIndex = 0;
            }            
            txtTentativeSentDate.Text = String.Empty;
            if (ddlApprovedBy.Items.Count > 0)
            {
                ddlApprovedBy.SelectedIndex = 0;
            }            
            txtInvoiceNo.Text = String.Empty;
            txtContainerNo.Text = String.Empty;
            txtSealNo.Text = String.Empty;
            txtsentdate.Text = String.Empty;
            txtArrivalinAerowerks.Text = String.Empty;
            txtContainer.Text = String.Empty;
            if (ddlAttn.Items.Count > 0)
            {
                ddlAttn.SelectedIndex = 0;
            }            
            if (ddlDestWareHouse.Items.Count > 0)
            {
                ddlDestWareHouse.SelectedIndex = 0;
            }
            if (ddlIssuedBy.Items.Count > 0)
            {
                ddlIssuedBy.SelectedIndex = 0;
            }
            if (ddlShipment.Items.Count > 0)
            {
                ddlShipment.SelectedIndex = 0;
            }            
            lnkDownload.Text = String.Empty;
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
            dvContainerInfo.Visible = false;
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
            if (ddlContainerNo.Items.Count > 0)
            {
                ddlContainerNo.Items.Clear();
            }
            if (ddlVendorLookup.Items.Count > 0)
            {
                ddlVendorLookup.SelectedIndex = 0;
            }            
            btnSubmit.Enabled = false;
            btnNotify.Enabled = false;
            btnAddProjects.Enabled = false;
            btnPackingDetails.Enabled = false;
            btnPackingDetailsExcel.Enabled = false;
            if (ddlDestWareHouse.Items.Count > 0)
            {
                ddlDestWareHouse.Items.Clear();
            }
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
    #endregion

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
            if (vendorID != "")
            {
                ddlVendorLookup.SelectedValue = vendorID;
                VendorLookupEvent(containerId);
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
            clscon.Return_DT(dt, "EXEC [IV].[Get_PackingDetails_V1] '" + ddlContainerNo.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportDataZeroExcel()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [IV].[Get_PackingDetails_V1] '" + ddlContainerNo.SelectedValue + "', 2");
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

    protected void txtShippingQty_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            TextBox txtShipQty = (TextBox)row.FindControl("txtShippingQty");
            Label lblOrderQty = (Label)row.FindControl("lblOrderQty");
            Label lblPendingQty = (Label)row.FindControl("lblPendingQty");
            int OrderQty = 0;
            int ShipQty = 0;
            int pendingQty = 0;
            if (lblPendingQty.Text != "")
            {
                pendingQty = Convert.ToInt32(lblPendingQty.Text);
            }
            else
            {
                pendingQty = -1;
            }
            if (txtShipQty.Text != "")
            {
                ShipQty = Convert.ToInt32(txtShipQty.Text);
            }
            if (lblOrderQty.Text != "")
            {
                OrderQty = Convert.ToInt32(lblOrderQty.Text);
            }
            if (ShipQty > OrderQty)
            {
                Utility.ShowMessage_Error(Page, "Ship qty not more than Order Qty !!");
                txtShipQty.Focus();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

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
    protected void gvContainerProjects_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            string CheckStatus = ViewState["ContainerStatus"].ToString();
            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
            if (lnkDelete != null)
            {
                if (CheckStatus == "False")
                {
                    gvContainerProjects.Columns[5].Visible = false;
                    lnkDelete.Visible = false;
                }
                else
                {
                    gvContainerProjects.Columns[5].Visible = true;
                    lnkDelete.Visible = true;
                }
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    

    public bool SaveArrivalInAerowerksShipmentDateLogs()
    {
        try
        {
            if(txtArrivalinAerowerks.Text == "")
            {
                return false;
            }
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            if (ddlContainerNo.Items.Count > 0)
            {
                ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
                ds = ObjBLL.GetBindControl(ObjBOL);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ArrivalinAerowerks"].ToString() != "")
                    {
                        DateTime ArrivalInAerowerksDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ArrivalinAerowerks"].ToString());
                        DateTime TextBoxArrivalDate;

                        // Try to parse the textbox date string into DateTime
                        if (DateTime.TryParse(txtArrivalinAerowerks.Text, out TextBoxArrivalDate))
                        {
                            if (ArrivalInAerowerksDate == TextBoxArrivalDate)
                            {
                                return false;
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
        return true;
    }

    public void SaveArrivalDateLogs()
    {
        try
        {
            ObjBOL.Operation = 21;
            if(hfContainerid.Value != "")
            {
                ObjBOL.Containerid = Convert.ToInt32(hfContainerid.Value);
            }
            ObjBLL.SaveJobDetails(ObjBOL);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvPackingListExcelExport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string field2 = "";
                field2 = dr["Picture"].ToString();
                string fullPath = Utility.PartImageForExport().Replace("~", "") + field2;
                FileInfo file = new FileInfo(Server.MapPath(fullPath));
                if (field2 != "" && file.Exists)
                {
                    var boundFields2 = e.Row.Cells.Cast<DataControlFieldCell>()
                    .Select(cell => cell.ContainingField).Cast<BoundField>().ToList();

                    int idx2 = boundFields2.IndexOf(
                        boundFields2.FirstOrDefault(f => f.DataField == "Picture"));
                    e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<img height='90' width='90' src =\'" + ConfigurationManager.AppSettings["PartImage"] + fullPath + "'> " + "</img>");
                }
                else
                {
                    var boundFields2 = e.Row.Cells.Cast<DataControlFieldCell>()
                    .Select(cell => cell.ContainingField).Cast<BoundField>().ToList();

                    int idx2 = boundFields2.IndexOf(
                        boundFields2.FirstOrDefault(f => f.DataField == "Picture"));
                    e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<p> " + "</p>");
                }               
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}