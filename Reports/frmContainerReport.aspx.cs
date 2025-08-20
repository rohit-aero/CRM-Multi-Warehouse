using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

public partial class Reports_frmContainerReport : System.Web.UI.Page
{
    BOLSearchContainer ObjBOL = new BOLSearchContainer();
    BLLManageSearchContainer ObjBLL = new BLLManageSearchContainer();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Controls();
            BindDestWareHouse("");
        }
    }

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetSearchContainerData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlVendor, ds.Tables[0]);
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
            if (selectedSourceID != "")
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 3;
                if (selectedSourceID != "")
                {
                    ObjBOL.SourceID = Convert.ToInt32(selectedSourceID);
                }
                ds = ObjBLL.GetSearchContainerData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownListAll(ddlDestination, ds.Tables[0]);
                    if (ddlDestination.Items.Count > 0)
                    {
                        ddlDestination.SelectedIndex = 0;
                    }
                }
                else
                {
                    if (ddlDestination.Items.Count > 0)
                    {
                        ClearWareHouse();
                    }

                }
            }
            else
            {
                ClearWareHouse();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearWareHouse()
    {
        try
        {
            ddlDestination.Items.Clear();
            ddlDestination.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
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
            clscon.Return_DT(dt, "EXEC [IV].[Get_ContainerJobs]");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlVendor.SelectedIndex > 0)
            {
                BindDestWareHouse(ddlVendor.SelectedValue);
            }
            else
            {
                ClearWareHouse();
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
            DataTable dt1 = new DataTable();
            dt1 = ReportData();
            string Qstr = string.Empty;
            string FQstr = String.Empty;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            Qstr += "  DECLARE @Temptable as Table(  ContainerID int,  ContainerNo varchar(50),   InvoiceNo  varchar(50), ";
            Qstr += "  PONumber varchar(50),  Part# varchar(50), [Description] varchar(500),  OrderDate   varchar(50),  ";
            Qstr += "  SentDate    varchar(50),   Requestor   varchar(50),  Sourceid    varchar(10), [Destination] varchar(100), OrderQty    int,   ";
            Qstr += "  ShipQty     int,  PendingQty  int,  DetailsStatus varchar(10),  Shipmentby  VARCHAR(10),   ";
            Qstr += "  UM varchar(10),  POId int,  PartID int,  IsSubmitted int )   ";
            Qstr += " INSERT Into @Temptable  ";
            Qstr += " Select Inv_Container.id AS ContainerID,MIN(Inv_Container.ContainerNo) AS ContainerNo, ";
            Qstr += " MIN(InvoiceNo) AS InvoiceNo, Inv_PurchaseOrder_Manual.PONumber, MIN(Inv_Parts.PartNumber) AS Partnumber, ";
            Qstr += " MIN(Inv_Parts.PartDes) AS PartDesc, MIN(convert(varchar,Inv_PurchaseOrder_Manual.IssueDate,1)) AS OrderDate,  ";
            Qstr += " MIN(convert(varchar,Inv_Container.SentDate,1)) AS   SentDate,  ";
            Qstr += "  CASE WHEN MIN(Inv_PurchaseOrderDetail_Manual.Requestor) IS NULL THEN ";
            Qstr += " concat(MIN(EmpRequestor.FirstName) + ' ', MIN(EmpRequestor.LastName)) ";
            Qstr += " ELSE concat(MIN(EmpPORequestor.FirstName) + ' ', MIN(EmpPORequestor.LastName)) ";
            Qstr += " END AS Requestor, MIN(Inv_Source.[WarehouseName]) AS [Source], ";
            Qstr += " MIN(Inv_Warehouse.[WarehouseName]) AS [Destination],  MIN(Inv_ContainerDetail.OrderQty) AS OrderQty, ";
            Qstr += " MIN(Inv_ContainerDetail.ShipQty) AS Intransit, NULL AS PendingQty, ";
            Qstr += " NULL AS DetailsStatus, ";
            Qstr += " case when MIN(Inv_Container.Shipmentby)=1 then 'By Sea' Else 'By Air' End AS Shipmentby, ";
            Qstr += " MIN(Inv_UM.UM) AS UM,Inv_ContainerDetail.POId,Inv_ContainerDetail.PartId, ";
            Qstr += " MIN(Inv_Container.IsSubmitted) AS   IsSubmitted ";
            Qstr += " from Inv_Container ";
            Qstr += " LEFT JOIN Inv_ContainerDetail ON Inv_Container.id=Inv_ContainerDetail.ContainerId ";
            Qstr += " LEFT JOIN Inv_PurchaseOrderDetail_Manual ON Inv_PurchaseOrderDetail_Manual.PurchaseOrderId= ";
            Qstr += " Inv_ContainerDetail.POId ";
            Qstr += " LEFT JOIN Inv_Parts ON Inv_Parts.id=Inv_ContainerDetail.PartId ";
            Qstr += " LEFT JOIN Inv_PurchaseOrder_Manual ON Inv_PurchaseOrder_Manual.id=Inv_ContainerDetail.POId ";
            Qstr += " LEFT JOIN Inv_RequisitionDetail ON Inv_RequisitionDetail.id=Inv_PurchaseOrderDetail_Manual.ReqDetailID ";
            Qstr += " left join tblEmployees as EMPAttn on EMPAttn.EmployeeID=Inv_Container.Attn ";
            Qstr += " LEFT JOIN tblEmployees AS EMPIssuedBy on EMPIssuedBy.EmployeeID=Inv_Container.IssuedBy ";
            Qstr += " left join tblEmployees as EMPApprovedby on EMPApprovedby.EmployeeID=Inv_Container.ApprovedBy ";
            Qstr += " LEFT JOIN tblEmployees as EmpRequestor ON EmpRequestor.EmployeeID=Inv_RequisitionDetail.Requestor ";
            Qstr += " LEFT JOIN Inv_Warehouse AS Inv_Source ON Inv_Source.id=Inv_Container.Sourceid ";
            Qstr += " LEFT JOIN Inv_Warehouse ON Inv_Warehouse.Id=Inv_Container.WareHouseID ";
            Qstr += " LEFT JOIN Inv_UM ON   Inv_UM.id=Inv_Parts.UMId  ";
            Qstr += " LEFT JOIN tblEmployees as EmpPORequestor ON EmpPORequestor.EmployeeID=Inv_PurchaseOrderDetail_Manual.Requestor ";
            Qstr += " GROUP BY Inv_Container.id,Inv_ContainerDetail.POId,Inv_ContainerDetail.PartId,Inv_PurchaseOrder_Manual.PONumber, ";
            Qstr += " CONVERT(Varchar(10),INV_Container.TentativeSentDate,101) ";
            Qstr += " DECLARE @PART_ID int DECLARE @PO_id int DECLARE @Container_ID int ";
            Qstr += " DECLARE CUR_PART CURSOR	STATIC FOR SELECT Partid,POID,ContainerId FROM @Temptable ";
            Qstr += " OPEN CUR_PART IF @@CURSOR_ROWS > 0 BEGIN FETCH NEXT FROM CUR_PART INTO @PART_ID,@PO_id,@Container_ID ";
            Qstr += " WHILE @@Fetch_status = 0 BEGIN update @Temptable set PendingQty = ( Select ";
            Qstr += " MIN(ISNULL(Inv_ContainerDetail.OrderQty,0)) - SUM(ISNULL(Inv_ContainerDetail.ShipQty,0)) from  ";
            Qstr += " Inv_ContainerDetail where POId=@PO_id and Partid=@PART_ID   ";
            Qstr += " ) where Partid = @PART_ID and POID=@PO_id  ";
            Qstr += " UPDATE @Temptable SET DetailsStatus=( ";
            Qstr += " SELECT DISTINCT StatusID FROM Inv_PurchaseOrderDetail_Manual WHERE PurchaseOrderId=@PO_id AND  ";
            Qstr += " Partid=@PART_ID) where Partid=@PART_ID and POID=@PO_id	 ";
            Qstr += " FETCH NEXT FROM CUR_PART INTO @PART_ID,@PO_id,@Container_ID END END ";
            Qstr += " CLOSE CUR_PART DEALLOCATE CUR_PART ";
            Qstr += "  SELECT  ContainerID, ContainerNo,InvoiceNo,  PONumber,  Part#,   [Description],  ";
            Qstr += "  OrderDate,  SentDate, Requestor,  Sourceid, [Destination], OrderQty,  ShipQty,  CASE WHEN PendingQty<0 THEN 0 ELSE PendingQty  ";
            Qstr += " END AS PendingQty, ";
            Qstr += "  CASE WHEN ISNULL(DetailsStatus,1)=1 THEN 'Open' WHEN DetailsStatus=2 THEN 'Close' END AS DetailsStatus,  ";
            Qstr += "   Shipmentby,  UM,  POId,  PartID,  IsSubmitted   ";
            Qstr += "  FROM @Temptable Where InvoiceNo IS NOT NULL  ";

            if (ddlContainerCheckStatus.SelectedValue == "1")
            {
                Qstr += " AND IsSubmitted IS NOT NULL and ShipQty is not null ";
            }
            else if (ddlContainerCheckStatus.SelectedValue == "2")
            {
                Qstr += " AND IsSubmitted IS NULL ";
            }
            if (ddlVendor.SelectedIndex > 0)
            {
                Qstr += "And Sourceid='" + ddlVendor.SelectedItem.Text + "' ";
            }
            if (ddlDestination.SelectedIndex > 0)
            {
                Qstr += "And Destination='" + ddlDestination.SelectedItem.Text + "' ";
            }
            if (ddlStatus.SelectedIndex > 0)
            {
                if (ddlStatus.SelectedValue == "1")
                {
                    Qstr += " AND ([DetailsStatus] ='" + ddlStatus.SelectedValue + "' OR [DetailsStatus]  IS NULL) ";
                }
                else
                {
                    Qstr += "AND [DetailsStatus] ='" + ddlStatus.SelectedValue + "' ";
                }
            }
            Qstr += "  ORDER BY InvoiceNo asc,PartID asc  ";

            FQstr = Qstr;
            clscon.Return_DT(dt, FQstr);
            if (dt.Rows.Count > 0)
            {
                rprt.Load(Server.MapPath("~/Reports/rptContainerDetailReport.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Container Details";
                    rprt.SetDataSource(dt);
                    rprt.Subreports[0].SetDataSource(dt1);
                    rptPO.ReportSource = rprt;
                    rptPO.DataBind();
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Container Details";
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

    private DataTable ReportDataPendingQty()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [IV].[Get_ManagePrepareContainerNew_PendingQty]");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnGeneratePendingQty_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtPendingQty = new DataTable();
            dtPendingQty = ReportDataPendingQty();
            if (dtPendingQty.Rows.Count > 0)
            {
                rprt.Load(Server.MapPath("~/Reports/rptContainerDetailReportPendingQty.rpt"));
                if (dtPendingQty.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Pending Part Quantity";
                    rprt.SetDataSource(dtPendingQty);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Pending Part Quantity"; 
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                Utility.ShowMessage_Warning(Page, "No Data Found !!");
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

    //btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddlVendor.SelectedIndex = 0;
            if (ddlDestination.Items.Count > 0)
            {
                ClearWareHouse();
            }
            ddlStatus.SelectedIndex = 0;
            ddlContainerCheckStatus.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}