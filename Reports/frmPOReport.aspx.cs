using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

public partial class Reports_frmPOReport : System.Web.UI.Page
{
    BOLSearchPO ObjBOL = new BOLSearchPO();
    BLLManageSearchPO ObjBLL = new BLLManageSearchPO();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Controls();
        }
    }

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetSearchPOData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlVendor, ds.Tables[0]);
                Utility.BindDropDownListAll(ddlDest, ds.Tables[0]);
                ddlVendor.SelectedIndex = 0;
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlLookupPart, ds.Tables[1]);
                ddlLookupPart.SelectedIndex = 0;
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindDestWareHouse(string SourceID,string DestinationID)
    {
        try
        {
            if (SourceID != "" || DestinationID != "")
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 4;
                if (SourceID != "")
                {
                    ObjBOL.SourceID = Convert.ToInt32(SourceID);
                }
                else
                {
                    ObjBOL.SourceID = Convert.ToInt32(DestinationID);
                }
                ds = ObjBLL.GetSearchPODataReport(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (SourceID != "")
                    {
                        Utility.BindDropDownListAll(ddlDest, ds.Tables[0]);
                        if (ddlDest.Items.Count > 0)
                        {
                            ddlDest.SelectedIndex = 0;
                        }
                    }
                    else if (DestinationID != "")
                    {
                        Utility.BindDropDownListAll(ddlVendor, ds.Tables[0]);
                        if (ddlVendor.Items.Count > 0)
                        {
                            ddlVendor.SelectedIndex = 0;
                        }
                    }
                }
                else
                {
                    if (ddlVendor.Items.Count > 0)
                    {
                        ddlVendor.SelectedIndex = 0;
                    }
                    if (ddlDest.Items.Count > 0)
                    {
                        ddlDest.SelectedIndex = 0;
                    }

                }
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
   

    private void BindPartNo()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetSearchPOData(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlLookupPart, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportData();
            if (dt.Rows.Count > 0)
            {
                rprt.Load(Server.MapPath("~/Reports/rptPurchaseOrderReport.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Purchase Order Detail Report";
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Purchase Order Detail Report";
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            if (ex.ToString() != "Thread was being aborted.")
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

    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {
            string url = ResolveUrl("~/InventoryManagement/frmPOPartDetails.aspx");
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

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        try
        {

            string url = ResolveUrl("~/Reports/frmPOStatus.aspx");
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

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            string Qstr = string.Empty;
            string FQstr = String.Empty;
            Qstr += " DECLARE @TempTable as Table( PONumber varchar(50), Part# varchar(50), ";
            Qstr += " [Description] varchar(500),  OrderDate   varchar(50), Requestor   varchar(50), ";
            Qstr += " Sourceid    varchar(10), Destination Varchar(20), OrderQty    int, ShipQty     int, PendingQty  int, ";
            Qstr += " DetailsStatus varchar(10), Shipmentby  VARCHAR(10), UM varchar(10),  ";
            Qstr += " POId int, PartID int,  IsSubmitted int, ReqDetailID int ) ";
            Qstr += " INSERT INTO @TempTable SELECT  ";
            Qstr += " Inv_PurchaseOrder_Manual.PONumber, ";
            Qstr += " MIN(Inv_Parts.PartNumber) AS PartNumber,MIN(Inv_Parts.PartDes) AS PartDes, ";
            Qstr += " MIN(convert(varchar(10),Inv_PurchaseOrder_Manual.IssueDate,101)) AS OrderDate, ";
            Qstr += " CASE WHEN MIN(Inv_PurchaseOrderDetail_Manual.Requestor) IS NULL THEN  ";
            Qstr += " concat(MIN(EmpRequestor.FirstName) + ' ', MIN(EmpRequestor.LastName)) ";
            Qstr += " ELSE concat(MIN(EmpPORequestor.FirstName) + ' ', MIN(EmpPORequestor.LastName)) end as Requestor, ";
            Qstr += "   MIN(Inv_Source.[WarehouseName]) AS [Source], MIN(Inv_Warehouse.[WarehouseName]),";
            Qstr += " NULL AS OrderQty,NULL AS ShipQty,NULL AS PendingQty, ";
            Qstr += " MIN(Inv_PurchaseOrderDetail_Manual.StatusID) AS StatusID, ";
            Qstr += " CASE WHEN MIN(Inv_PurchaseOrderDetail_Manual.ReqID) IS NULL THEN MIN(Inv_PurchaseOrderDetail_Manual.ShipmentBy) ";
            Qstr += " ELSE MIN(Inv_RequisitionDetail.ShipmentBy) END AS ShipmentBy,MIN(Inv_UM.UM) AS [UM],MIN(Inv_PurchaseOrder_Manual.Id) AS POId, ";
            Qstr += " Inv_Parts.id,MIN(Inv_PurchaseOrder_Manual.IsSubmitted) AS IsSubmitted,MIN(Inv_RequisitionDetail.id) AS ReqDetailID FROM Inv_PurchaseOrderDetail_Manual ";
            Qstr += " Inner join Inv_PurchaseOrder_Manual on Inv_PurchaseOrder_Manual.Id=Inv_PurchaseOrderDetail_Manual.PurchaseOrderId ";
            Qstr += " LEFT JOIN Inv_RequisitionDetail ON Inv_RequisitionDetail.id=Inv_PurchaseOrderDetail_Manual.ReqDetailID ";
            Qstr += " LEFT JOIN tblEmployees as EmpRequestor ON EmpRequestor.EmployeeID=Inv_RequisitionDetail.Requestor ";
            Qstr += " LEFT JOIN tblEmployees as EmpPORequestor ON EmpPORequestor.EmployeeID=Inv_PurchaseOrderDetail_Manual.Requestor ";
            Qstr += " LEFT JOIN Inv_Parts ON Inv_Parts.id=Inv_PurchaseOrderDetail_Manual.PartId ";
            Qstr += " LEFT JOIN Inv_Warehouse AS Inv_Source ON Inv_Source.id=Inv_PurchaseOrder_Manual.SourceId ";
            Qstr += " LEFT JOIN Inv_Warehouse ON Inv_Warehouse.Id=Inv_PurchaseOrder_Manual.WareHouseID ";
            Qstr += " LEFT JOIN Inv_UM ON Inv_UM.id=Inv_Parts.UMId ";
            Qstr += " Group by Inv_PurchaseOrder_Manual.PONumber,Inv_Parts.id ";
            Qstr += " DECLARE @PART_ID int  DECLARE @PO_id int DECLARE @ReqDetailID int DECLARE CUR_PART CURSOR ";
            Qstr += " STATIC FOR SELECT Partid,POID,ReqDetailID FROM @Temptable   OPEN  CUR_PART ";
            Qstr += " IF @@CURSOR_ROWS > 0  BEGIN FETCH NEXT FROM CUR_PART INTO @PART_ID,@PO_id,@ReqDetailID ";
            Qstr += "  WHILE @@Fetch_status = 0  BEGIN  ";
            Qstr += " UPDATE @TempTable SET OrderQty=(SELECT CASE WHEN MIN(ReqID) IS NOT NULL THEN SUM(OrderQty) ELSE MIN(OrderQty) END AS OrderQty FROM ";
            Qstr += " Inv_PurchaseOrderDetail_Manual  WHERE Inv_PurchaseOrderDetail_Manual.PartId=@PART_ID AND Inv_PurchaseOrderDetail_Manual.PurchaseOrderId=@PO_id ";
            Qstr += " GROUP BY Inv_PurchaseOrderDetail_Manual.PurchaseOrderId,PartId) WHERE PartID=@PART_ID AND POId=@PO_id ";
            Qstr += " UPDATE @TempTable SET ShipQty=(SELECT SUM(ShipQty) FROM Inv_ContainerDetail WHERE Inv_ContainerDetail.PartId=@PART_ID ";
            Qstr += " AND POId=@PO_id ) WHERE PartID=@PART_ID AND POId=@PO_id  ";    
            Qstr += " FETCH NEXT FROM CUR_PART INTO @PART_ID,@PO_id,@ReqDetailID ";
            Qstr += " END  END CLOSE CUR_PART DEALLOCATE CUR_PART ";
            Qstr += " SELECT PONumber,Part#,[Description],OrderDate, ";
            Qstr += " Requestor,Sourceid, Destination, OrderQty,ShipQty, ";
            Qstr += " case when (ISNULL(OrderQty,0)-ISNULL(ShipQty,0))<0 then 0 else (ISNULL(OrderQty,0)-ISNULL(ShipQty,0)) end as  PendingQty, ";
            Qstr += " CASE WHEN ISNULL(DetailsStatus,1)=1 Then 'Open' WHEN DetailsStatus=2 THEN 'Close' WHEN DetailsStatus=3 THEN 'Cancelled' End AS DetailsStatus, ";
            Qstr += " CASE WHEN Shipmentby=1 Then 'By Sea' When Shipmentby=2 Then 'By Air' End as Shipmentby,  ";
            Qstr += " UM,POId,PartID,IsSubmitted ";
            Qstr += " FROM @TempTable ";
            Qstr += " WHERE PONumber IS NOT NULL ";
            if (ddlPOCheckStatus.SelectedValue == "1")
            {
                Qstr += " AND Issubmitted IS NOT NULL and ShipQty is not null ";
            }
            else if (ddlPOCheckStatus.SelectedValue == "2")
            {
                Qstr += " AND Issubmitted IS NULL ";
            }
            if (ddlVendor.SelectedIndex > 0)
            {
                Qstr += "And SourceId='" + ddlVendor.SelectedItem.Text + "' ";
            }
            if (ddlDest.SelectedIndex > 0)
            {
                Qstr += "And Destination='" + ddlDest.SelectedItem.Text + "' ";
            }
            if (ddlStatus.SelectedIndex > 0)
            {
                if (ddlStatus.SelectedValue == "1")
                {
                    Qstr += " AND (DetailsStatus='" + ddlStatus.SelectedValue + "' OR DetailsStatus IS NULL) ";
                }
                else
                {
                    Qstr += "AND DetailsStatus='" + ddlStatus.SelectedValue + "' ";
                }
            }
            if (ddlLookupPart.SelectedIndex > 0)
            {
                Qstr += " AND PartID='" + ddlLookupPart.SelectedValue + "' ";
            }
            Qstr += "  ORDER BY PONumber asc,OrderQty desc ";
            FQstr = Qstr;
            clscon.Return_DT(dt, FQstr);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ExportDataToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        try
        {
            string Qstr = string.Empty;
            string FQstr = String.Empty;
            if (ddlPOCheckStatus.SelectedValue == "1")
            {
                Qstr += " AND Issubmitted IS NOT NULL and ShipQty is not null ";
            }
            else if (ddlPOCheckStatus.SelectedValue == "2")
            {
                Qstr += " AND Issubmitted IS NULL ";
            }
            if (ddlVendor.SelectedIndex > 0)
            {
                Qstr += "And SourceId='" + ddlVendor.SelectedItem.Text + "' ";
            }
            if (ddlDest.SelectedIndex > 0)
            {
                Qstr += "And Destination='" + ddlDest.SelectedItem.Text + "' ";
            }
            if (ddlStatus.SelectedIndex > 0)
            {
                if (ddlStatus.SelectedValue == "1")
                {
                    Qstr += " AND (DetailsStatus='" + ddlStatus.SelectedValue + "' OR DetailsStatus IS NULL) ";
                }
                else
                {
                    Qstr += "AND DetailsStatus='" + ddlStatus.SelectedValue + "' ";
                }
            }
            if (ddlLookupPart.SelectedIndex > 0)
            {
                Qstr += " AND PartID='" + ddlLookupPart.SelectedValue + "' ";
            }
            Qstr += "  ORDER BY SourceId asc,PONumber asc,OrderQty desc ";
            FQstr = Qstr;
            ObjBOL.Operation = 1;
            ObjBOL.SearchVar = FQstr;
            ds = ObjBLL.GetSearchPODataReport(ObjBOL);
            dt = ds.Tables[0];
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered, tem a ver com obotão de exportação para excel*/
    }

    protected void btnExporttoExcel_Click(object sender, EventArgs e)
    {
        BindGrid();
        ExportNestedGridViewToExcel(gvMainPOReport);
    }

    private void BindGrid()
    {
        try
        {
            try
            {
                string SourceID = "";
                DataSet dsChildPOParts = new DataSet();
                DataSet dsInnerChildPOParts = new DataSet();
                DataSet dsContainerParts = new DataSet();
                DataTable dt = new DataTable();
                dt = ExportDataToExcel();
                if (dt.Rows.Count > 0)
                {
                    btnExporttoExcel.Enabled = true;
                    gvMainPOReport.DataSource = dt;
                    gvMainPOReport.DataBind();
                    foreach (GridViewRow row in gvMainPOReport.Rows)
                    {
                        SourceID = (row.FindControl("lblSource") as Label).Text;
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            GridView gvChildContainer = row.FindControl("gvContainerInfo") as GridView;
                            string containerpoid = (row.FindControl("lblPOId") as Label).Text;
                            string partid = (row.FindControl("lblPartID") as Label).Text;
                            ObjBOL.Operation = 2;
                            ObjBOL.PurchaseOrderID = Convert.ToInt32(containerpoid);
                            ObjBOL.PartID = Convert.ToInt32(partid);
                            dsContainerParts = ObjBLL.GetSearchPODataReport(ObjBOL);
                            if (dsContainerParts.Tables[0].Rows.Count > 0)
                            {
                                gvChildContainer.DataSource = dsContainerParts.Tables[0];
                                gvChildContainer.DataBind();
                            }
                            else
                            {
                                gvChildContainer.DataSource = "";
                                gvChildContainer.DataBind();
                            }
                        }

                    }
                }
                else
                {
                    btnExporttoExcel.Enabled = false;
                    gvMainPOReport.DataSource = "";
                    gvMainPOReport.DataBind();
                }
            }
            catch (Exception ex)
            {
                Utility.AddEditException(ex);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    public void ExportNestedGridViewToExcel(GridView mainGridView)
    {
        try
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var workSheet = excel.Workbook.Worksheets.Add("PurchaseOrderDetails");
                // Add headers
                
                workSheet.Cells[1, 1].Value = "PO Number";
                workSheet.Cells[1, 2].Value = "Part Number";
                workSheet.Cells[1, 3].Value = "Part Description";
                workSheet.Cells[1, 4].Value = "Source";
                workSheet.Cells[1, 5].Value = "Destination";
                workSheet.Cells[1, 6].Value = "Invoice No";
                workSheet.Cells[1, 7].Value = "Container No";
                workSheet.Cells[1, 8].Value = "Sent Date";
                workSheet.Cells[1, 9].Value = "Received Date";
                workSheet.Cells[1, 10].Value = "Container Ship Qty";
                workSheet.Cells[1, 11].Value = "Order Date";
                workSheet.Cells[1, 12].Value = "Requestor";
                workSheet.Cells[1, 13].Value = "Ship by";
                workSheet.Cells[1, 14].Value = "Order Qty";
                workSheet.Cells[1, 15].Value = "UM";
                workSheet.Cells[1, 16].Value = "Ship Qty";
                workSheet.Cells[1, 17].Value = "Pending Qty";
                workSheet.Cells[1, 18].Value = "Status";
                workSheet.Cells["A1:R1"].Style.Font.Bold = true;


                workSheet.Column(1).Width = 15; // PO Number
                workSheet.Column(2).Width = 15; // Part Number
                workSheet.Column(3).Width = 60; // Part Description
                workSheet.Column(4).Width = 15; // Source
                workSheet.Column(5).Width = 15; // Destination
                workSheet.Column(6).Width = 25; // Invoice No
                workSheet.Column(7).Width = 25; // Container No
                workSheet.Column(8).Width = 15; // Sent Date
                workSheet.Column(9).Width = 15; // Received Date
                workSheet.Column(10).Width = 25; // Qty
                workSheet.Column(11).Width = 15; // Order Date
                workSheet.Column(12).Width = 20; // Requestor
                workSheet.Column(13).Width = 15; // Ship by
                workSheet.Column(14).Width = 15; // Order Qty
                workSheet.Column(15).Width = 10; // UM
                workSheet.Column(16).Width = 15; // Ship Qty
                workSheet.Column(17).Width = 15; // Pending Qty
                workSheet.Column(18).Width = 15; // Status
                int rowMain = 2;
                foreach (GridViewRow mainRow in mainGridView.Rows)
                {                    
                    string PONumber = ((Label)mainRow.FindControl("lblPONumber")).Text;
                    workSheet.Cells[rowMain, 1].Value = PONumber;
                    workSheet.Cells[rowMain, 1].Style.Font.Bold = true;
                    string PartNo = ((Label)mainRow.FindControl("lblPartNo")).Text;
                    string Description = ((Label)mainRow.FindControl("lblDescription")).Text;
                    string source = ((Label)mainRow.FindControl("lblSource")).Text;
                    workSheet.Cells[rowMain, 4].Value = source;
                    workSheet.Cells[rowMain, 4].Style.Font.Bold = true;
                    string orderDate = ((Label)mainRow.FindControl("lblOrderDate")).Text;
                    string requestor = ((Label)mainRow.FindControl("lblRequestor")).Text;
                    string shipBy = ((Label)mainRow.FindControl("lblShipby")).Text;
                    string orderQty = ((Label)mainRow.FindControl("lblOrderQty")).Text;
                    string um = ((Label)mainRow.FindControl("lblUM")).Text;
                    string shipQty = ((Label)mainRow.FindControl("lblShipQty")).Text;
                    string pendingQty = ((Label)mainRow.FindControl("lblPendingQty")).Text;
                    string status = ((Label)mainRow.FindControl("lblStatus")).Text;
                    workSheet.Cells[rowMain, 2].Value = PartNo;
                    workSheet.Cells[rowMain, 3].Value = Description;
                    workSheet.Cells[rowMain, 11].Value = orderDate;
                    workSheet.Cells[rowMain, 12].Value = requestor;
                    workSheet.Cells[rowMain, 13].Value = shipBy;
                    workSheet.Cells[rowMain, 14].Value = orderQty;
                    workSheet.Cells[rowMain, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    workSheet.Cells[rowMain, 15].Value = um;
                    workSheet.Cells[rowMain, 16].Value = shipQty;
                    workSheet.Cells[rowMain, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    workSheet.Cells[rowMain, 17].Value = pendingQty;
                    workSheet.Cells[rowMain, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    workSheet.Cells[rowMain, 18].Value = status;
                    rowMain = rowMain + 1;
                    GridView childContainerDetailGridView = (GridView)mainRow.FindControl("gvContainerInfo");
                    foreach (GridViewRow childContainerDetailRow in childContainerDetailGridView.Rows)
                    {
                        string Destination = ((Label)childContainerDetailRow.FindControl("lblDestination")).Text;
                        string InvoiceNo = ((Label)childContainerDetailRow.FindControl("lblInvoiceNo")).Text;
                        string ContainerNo = ((Label)childContainerDetailRow.FindControl("lblContainerNo")).Text;
                        string sentDate = ((Label)childContainerDetailRow.FindControl("lblSentDate")).Text;
                        string receiveDate = ((Label)childContainerDetailRow.FindControl("lblReceivedDate")).Text;
                        string Qty = ((Label)childContainerDetailRow.FindControl("lblShipQty")).Text;
                        workSheet.Cells[rowMain, 5].Value = Destination;
                        workSheet.Cells[rowMain, 6].Value = InvoiceNo;
                        workSheet.Cells[rowMain, 7].Value = ContainerNo;
                        workSheet.Cells[rowMain, 8].Value = sentDate;
                        workSheet.Cells[rowMain, 9].Value = receiveDate;
                        workSheet.Cells[rowMain, 10].Value = Qty;
                        workSheet.Cells[rowMain, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        rowMain++;
                    }
                }
                // Set the content type and filename
                var stream = new MemoryStream();
                excel.SaveAs(stream);
                var content = stream.ToArray();
                var fileName = "Purchase Order Detail Report" + ".xlsx";

                // Send the file to the client
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
                HttpContext.Current.Response.BinaryWrite(content);
                HttpContext.Current.Response.End();
            }
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }

        }
    }

    private void ResetGrid()
    {
        try
        {
            gvMainPOReport.DataSource = "";
            gvMainPOReport.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddlVendor.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            ddlPOCheckStatus.SelectedIndex = 0;
            ddlLookupPart.SelectedIndex = 0;
            btnExporttoExcel.Enabled = false;           
            ResetGrid();
            Bind_Controls();
            ddlDest.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable PreparePartsDT(int sourceid, int destID, string issubmitted, int statusid, int Partid)
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            string Qstr = string.Empty;
            string FQstr = String.Empty;
            if (issubmitted == "1")
            {
                Qstr += " AND Inv_PurchaseOrder_Manual.IsSubmitted=1 ";
            }
            else if (issubmitted == "2")
            {
                Qstr += " AND (Inv_PurchaseOrder_Manual.IsSubmitted IS NULL OR Inv_PurchaseOrder_Manual.IsSubmitted=0) ";
            }
            if (sourceid > 0)
            {
                Qstr += "And Inv_PurchaseOrder_Manual.SourceId='" + sourceid + "' ";
            }
            if (destID > 0)
            {
                Qstr += "And Inv_PurchaseOrder_Manual.WareHouseID='" + destID + "' ";
            }
            if (statusid > 0)
            {
                if (statusid == 1)
                {
                    Qstr += " AND (Inv_PurchaseOrderDetail_Manual.StatusID='" + statusid + "' OR Inv_PurchaseOrderDetail_Manual.StatusID IS NULL) ";
                }
                else
                {
                    Qstr += "AND Inv_PurchaseOrderDetail_Manual.StatusID='" + statusid + "' ";
                }
            }
            if (Partid > 0)
            {
                Qstr += " AND Inv_Parts.id='" + Partid + "' ";
            }
            Qstr += " Group by Inv_Parts.id,Concat(Inv_Parts.PartNumber + ' ',  ";
            Qstr += " Inv_Parts.PartDes) ";            
            Qstr += " Order by Concat(Inv_Parts.PartNumber + ' ', Inv_Parts.PartDes) asc";
            FQstr = Qstr;
            ObjBOL.Operation = 3;
            ObjBOL.SearchVar = FQstr;
            ds = ObjBLL.GetSearchPODataReport(ObjBOL);
            dt = ds.Tables[0];
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable CommonPartNoFunction()
    {
        DataTable dt = new DataTable();
        try
        {
            int sourceid = 0;
            string issubmitted = "";
            int statusid = 0;
            int partid = 0;
            int destid = 0;
            if (ddlVendor.SelectedIndex > 0)
            {
                sourceid = Convert.ToInt32(ddlVendor.SelectedValue);
                hidStatusID.Value = sourceid.ToString();
            }
            if (ddlDest.Items.Count > 0)
            {
                if (ddlDest.SelectedIndex > 0)
                {
                    destid = Convert.ToInt32(ddlDest.SelectedValue);
                }
            }
            if (ddlPOCheckStatus.SelectedIndex > 0)
            {
                issubmitted = ddlPOCheckStatus.SelectedValue;
                hidIsSubmittedID.Value = issubmitted.ToString();
            }
            if (ddlStatus.SelectedIndex > 0)
            {
                statusid = Convert.ToInt32(ddlStatus.SelectedValue);
                hidStatusID.Value = statusid.ToString();
            }
            if (ddlLookupPart.SelectedIndex > 0)
            {
                partid = Convert.ToInt32(ddlLookupPart.SelectedValue);
                hidPartID.Value = partid.ToString();
            }
            dt = PreparePartsDT(sourceid, destid, issubmitted, statusid, partid);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void BindPartNoOnSource(string sourceID)
    {
        try
        {
            DataTable dt = new DataTable();
            if(sourceID != "")
            {
                BindDestWareHouse(sourceID,"");
            }            
            dt = CommonPartNoFunction();
            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlLookupPart, dt);
            }
            else if (dt.Rows.Count == 0)
            {
                Utility.BindDropDownListAll(ddlLookupPart, dt);
            }
            if (ddlLookupPart.Items.Count > 0)
            {
                ddlLookupPart.SelectedIndex = 0;
            }
            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FilterPartNoOnDest()
    {
        try
        {
            DataTable dt = new DataTable();
            if (ddlVendor.SelectedIndex > 0 || ddlDest.SelectedIndex>0)
            {                
                dt = CommonPartNoFunction();
                if (dt.Rows.Count > 0)
                {
                    Utility.BindDropDownListAll(ddlLookupPart, dt);
                }
                else if (dt.Rows.Count == 0)
                {
                    Utility.BindDropDownListAll(ddlLookupPart, dt);
                }
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetGrid();
            if (ddlVendor.SelectedIndex>0)
            {
                BindPartNoOnSource(ddlVendor.SelectedValue);
            }
            else
            {
                Bind_Controls();                
            }
            BindPartNoOnSource("");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlDest_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetGrid();
            if (ddlVendor.SelectedIndex == 0)
            {
                if (ddlDest.SelectedIndex > 0)
                {
                    BindDestWareHouse("", ddlDest.SelectedValue);
                }
                else
                {
                    Bind_Controls();
                }
            }            
            FilterPartNoOnDest();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPOCheckStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetGrid();
            DataTable dt = new DataTable();
            if (ddlPOCheckStatus.SelectedIndex > 0)
            {
                dt = CommonPartNoFunction();
                if (dt.Rows.Count > 0)
                {
                    Utility.BindDropDownListAll(ddlLookupPart, dt);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetGrid();
            DataTable dt = new DataTable();
            dt = CommonPartNoFunction();
            Utility.BindDropDownListAll(ddlLookupPart, dt);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //protected void ddlLookupPart_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DataTable dt = new DataTable();            
    //        dt = CommonPartNoFunction();
    //        if (dt.Rows.Count > 0)
    //        {
    //            if(dt.Rows[0]["SourceId"].ToString() != "")
    //            {
    //                ddlVendor.SelectedValue = dt.Rows[0]["SourceId"].ToString();
    //            }
    //            else
    //            {
    //                ddlVendor.SelectedIndex = 0;
    //            }
    //            if(dt.Rows[0]["StatusID"].ToString() != "")
    //            {
    //                ddlStatus.SelectedValue = dt.Rows[0]["StatusID"].ToString();
    //            }
    //            else
    //            {
    //                ddlStatus.SelectedIndex = 0;
    //            }
    //            if(dt.Rows[0]["IsSubmitted"].ToString() != "")
    //            {
    //                ddlPOCheckStatus.SelectedValue = dt.Rows[0]["IsSubmitted"].ToString();
    //            }
    //            else
    //            {
    //                ddlPOCheckStatus.SelectedIndex = 0;
    //            }
    //        }            
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}
    protected void btnPreviewParts_Click(object sender, EventArgs e)
    {
        try
        {
            BindGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlLookupPart_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}