using System;
using System.Data;
using System.Web.UI;
using BOLAERO;
using BLLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.UI.WebControls;
using System.Web;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;

public partial class Reports_FrmDashboardReport : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    BOLReportDashboard ObjBOL = new BOLReportDashboard();
    BLLReportDashboard ObjBLL = new BLLReportDashboard();

    BOLPurchaseOrder ObjBOL_1 = new BOLPurchaseOrder();
    BLLPurchaseOrderManual ObjBLL_1 = new BLLPurchaseOrderManual();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //txtFromDate.Text = "01" + "/01/" + DateTime.Now.Year;
                //txtToDate.Text = "12" + "/31/" + DateTime.Now.Year;
                BindControls();
                if (ddlReportType.SelectedValue == "1")
                {
                    EnabledButton();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlVendor, ds.Tables[0]);
                ddlVendor.SelectedIndex = 0;
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProductLine, ds.Tables[1]);
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlPartNo, ds.Tables[2]);
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProductCode, ds.Tables[3]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // check if data filled in required fields
    private Boolean ValidationCheck()
    {
        try
        {
            if (ddlReportType.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Report Type. !!");
                ddlReportType.Focus();
                return false;
            }
            //if (txtFromDate.Text == "")
            //{
            //    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter From Date. !');", true);
            //    Utility.ShowMessage_Error(Page, "Please Enter From Date. !!");
            //    txtFromDate.Focus();
            //    return false;
            //}
            //if (txtToDate.Text == "")
            //{
            //    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter To Date. !');", true);
            //    Utility.ShowMessage_Error(Page, "Please Enter To Date. !!");
            //    txtToDate.Focus();
            //    return false;
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            CheckReportType();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ExportToExcelInventory()
    {
        try
        {
            string Qstr = string.Empty;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 9;
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                Qstr += " AND Inv_Container.ReceivedDate Between '" + txtFromDate.Text + "' AND '" + txtToDate.Text + "' ";
            }

            if (ddlVendor.SelectedIndex > 0)
            {
                Qstr += " AND WarehouseName= '" + ddlVendor.SelectedItem.Text + "' ";
            }

            if (ddlProductCode.SelectedIndex > 0)
            {
                Qstr += " AND Inv_Product.ProductLineSubID = '" + ddlProductCode.SelectedValue + "' ";
            }

            if (ddlProductLine.SelectedIndex > 0)
            {
                Qstr += " AND Inv_Product.id = '" + ddlProductLine.SelectedValue + "' ";
            }

            if (ddlPartNo.SelectedIndex > 0)
            {
                Qstr += " AND Inv_Parts.id = '" + ddlPartNo.SelectedValue + "' ";
            }

            if (ddlPartStatus.SelectedIndex > 0)
            {
                Qstr += " AND Inv_Parts.PartStatus = '" + ddlPartStatus.SelectedValue + "' ";
            }
            //Qstr += " Order by Inv_Parts.PartNumber asc";
            ObjBOL.searchvar = Qstr;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["dirState"] = ds.Tables[0];
                gvInventoryReportExcel.DataSource = ds.Tables[0];
                gvInventoryReportExcel.DataBind();
            }
            else
            {
                gvInventoryReportExcel.DataSource = "";
                gvInventoryReportExcel.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckReportTypeExcel()
    {
        try
        {
            if (ddlReportType.SelectedValue == "1")
            {
                BindInTransitGrid();
            }
            else if (ddlReportType.SelectedValue == "2")
            {
                BindArrivedContainerGrid();
            }
            else if (ddlReportType.SelectedValue == "3")
            {
                ExportToExcelInventory();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    protected void btnGenerateExcel_Click(object sender, EventArgs e)
    {
        try
        {
            CheckReportTypeExcel();
            ExportDatatabletoExcel();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ExportDatatabletoExcel()
    {
        try
        {
            DataTable dt = (DataTable)ViewState["dirState"];
            string FileName = "";
            if (ddlReportType.SelectedValue == "1")
            {
                FileName = "In-Transit";
                dt.Columns.RemoveAt(0);
            }
            else if (ddlReportType.SelectedValue == "2")
            {
                FileName = "Arrived";
                dt.Columns.RemoveAt(0);
            }
            else if (ddlReportType.SelectedValue == "3")
            {
                FileName = "Inventory";
                dt.Columns.RemoveAt(1);
            }
            Utility.ExportToExcelDT(dt, FileName);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckReportType()
    {
        try
        {
            if (ddlReportType.SelectedValue == "1")
            {
                BindInTransitGrid();
            }
            else if (ddlReportType.SelectedValue == "2")
            {
                BindArrivedContainerGrid();
            }
            else if (ddlReportType.SelectedValue == "3")
            {
                BindInventoryGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindInTransitGrid()
    {
        try
        {
            string Qstr = string.Empty;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                Qstr += " And Inv_Container.ArrivalInAerowerks Between '" + txtFromDate.Text + "' AND '" + txtToDate.Text + "' ";
            }
            if (ddlVendor.SelectedIndex > 0)
            {
                Qstr += " And Inv_Warehouse.[WarehouseName] = '" + ddlVendor.SelectedItem.Text + "' ";
            }
            Qstr += " Group By Inv_Container.id ";
            Qstr += " Order by MIN(InvoiceNo),MIN(Inv_Container.ArrivalInAerowerks) DESC ";
            ObjBOL.searchvar = Qstr;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblgvDashboard.Text = "In-Transit";
                ViewState["dirState"] = ds.Tables[0];
                gvShowStockData.DataSource = ds.Tables[0];
                gvShowStockData.DataBind();
            }
            else
            {
                ResetGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindArrivedContainerGrid()
    {
        try
        {
            string Qstr = string.Empty;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                Qstr += " And ReceivedDate Between '" + txtFromDate.Text + "' AND '" + txtToDate.Text + "' ";
            }
            if (ddlVendor.SelectedIndex > 0)
            {
                Qstr += " And Source= '" + ddlVendor.SelectedItem.Text + "' ";
            }
            Qstr += "  Order by  [Source] ASC,[Received Date] DESC ";
            ObjBOL.searchvar = Qstr;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblgvDashboard.Text = "Arrived";
                ViewState["dirState"] = ds.Tables[0];
                gvShowStockData.DataSource = ds.Tables[0];
                gvShowStockData.DataBind();
            }
            else
            {
                ResetGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnabledOrDisabledPartNo()
    {
        try
        {
            if (ddlReportType.SelectedValue == "3")
            {
                divPartNo.Visible = true;
            }
            else
            {
                divPartNo.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindInventoryGrid()
    {
        try
        {
            string Qstr = string.Empty;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                Qstr += " AND Inv_Container.ReceivedDate Between '" + txtFromDate.Text + "' AND '" + txtToDate.Text + "' ";
            }

            if (ddlVendor.SelectedIndex > 0)
            {
                Qstr += " AND WarehouseName= '" + ddlVendor.SelectedItem.Text + "' ";
            }

            if (ddlProductCode.SelectedIndex > 0)
            {
                Qstr += " AND Inv_Product.ProductLineSubID = '" + ddlProductCode.SelectedValue + "' ";
            }

            if (ddlProductLine.SelectedIndex > 0)
            {
                Qstr += " AND Inv_Product.id = '" + ddlProductLine.SelectedValue + "' ";
            }

            if (ddlPartNo.SelectedIndex > 0)
            {
                Qstr += " AND Inv_Parts.id = '" + ddlPartNo.SelectedValue + "' ";
            }

            if (ddlPartStatus.SelectedIndex > 0)
            {
                Qstr += " AND Inv_Parts.PartStatus = '" + ddlPartStatus.SelectedValue + "' ";
            }
            //Qstr += " Order by Inv_Parts.PartNumber asc";
            ObjBOL.searchvar = Qstr;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblgvDashboard.Text = "Inventory";
                ViewState["dirState"] = ds.Tables[0];
                gvInventoryReport.DataSource = ds.Tables[0];
                gvInventoryReport.DataBind();
            }
            else
            {
                ResetGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    protected void btnGeneratePDF_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlReportType.SelectedValue == "3")
            {
                ExportDataTableToPdf_Inventory();
            }
            else
            {
                ExportDataTableToPdf();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
    }

    private void ResetGrid()
    {
        try
        {
            lblgvDashboard.Text = String.Empty;
            gvShowStockData.DataSource = "";
            gvShowStockData.DataBind();
            gvInventoryReport.DataSource = string.Empty;
            gvInventoryReport.DataBind();
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
            ddlReportType.SelectedValue = "1";
            txtFromDate.Text = String.Empty;
            txtToDate.Text = String.Empty;
            ddlVendor.SelectedIndex = 0;
            //txtFromDate.Text = "01" + "/01/" + DateTime.Now.Year;
            //txtToDate.Text = "12" + "/31/" + DateTime.Now.Year;
            ResetGrid();
            EnabledOrDisabledPartNo();
            BindControls();
            ddlProductCode.SelectedIndex = 0;
            ddlPartStatus.SelectedIndex = 0;
            ddlPartNo.SelectedIndex = 0;
            ddlProductLine.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            EnabledButton();
            EnabledOrDisabledPartNo();
            ResetGrid();
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
            btnShow.Enabled = true;
            btnGeneratePDF.Enabled = true;
            btnGenerateExcel.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisabledButton()
    {
        try
        {
            btnShow.Enabled = false;
            btnGeneratePDF.Enabled = false;
            btnGenerateExcel.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShowStockData_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                if (gvShowStockData.Rows.Count >= 0 && gvShowStockData.HeaderRow != null)
                {
                    foreach (TableCell cell in gvShowStockData.HeaderRow.Cells)
                    {
                        cell.ForeColor = System.Drawing.Color.White; // Change to white                        
                    }
                    if (ddlReportType.SelectedValue == "3")
                    {
                        e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    }

                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //#region Sorting Section
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

    protected void gvShowStockData_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                DataView dataView = new DataView(dtrslt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvShowStockData.DataSource = dataView;
                gvShowStockData.DataBind();

            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + "DESC";
                gvShowStockData.DataSource = dtrslt;
                gvShowStockData.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    //#endregion

    //#region Export To PDF
    public void ExportDataTableToPdf()
    {
        try
        {

            //GridView gv = new GridView();           
            gvShowStockData.AllowPaging = false;
            gvShowStockData.AllowSorting = false;

            Response.ContentType = "application/pdf";
            CheckReportType();
            string FileName = "";
            if (ddlReportType.SelectedValue == "1")
            {
                FileName = "In-Transit " + DateTime.Now.ToString("MM/dd/yyyy") + ".pdf";
                //gv = gvShowStockData;
            }
            else if (ddlReportType.SelectedValue == "2")
            {
                FileName = "Arrived " + DateTime.Now.ToString("MM/dd/yyyy") + ".pdf";
                //gv = gvShowStockData;
            }
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            foreach (DataControlFieldHeaderCell headerCell in gvShowStockData.HeaderRow.Cells)
            {
                headerCell.ForeColor = System.Drawing.Color.Black; // Set header text color to black
                headerCell.Font.Bold = true;
            }
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvShowStockData.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDocument = new Document(PageSize.A3, 10f, 10f, 10f, 10f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDocument);
            pdfDocument.SetPageSize(PageSize.A3.Rotate());
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            pdfDocument.Open();
            htmlparser.Parse(sr);
            pdfDocument.Close();
            Response.Write(pdfDocument);
            Response.End();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public void ExportDataTableToPdf_Inventory()
    {
        try
        {

            string FileName = "";

            gvInventoryReport.AllowPaging = false;
            gvInventoryReport.AllowSorting = false;

            Response.ContentType = "application/pdf";

            CheckReportType();
            if (ddlReportType.SelectedValue == "3")
            {
                FileName = "Inventory " + DateTime.Now.ToString("MM/dd/yyyy") + ".pdf";
            }

            foreach (GridViewRow row in gvInventoryReport.Rows)
            {
                LinkButton lnkInTransit = (LinkButton)row.FindControl("lnkInTransit");
                Label lblInTransit = (Label)row.FindControl("lblInTransit");
                LinkButton lnkInProduction = (LinkButton)row.FindControl("lnkInProduction");
                Label lblInProduction = (Label)row.FindControl("lblInProduction");
                LinkButton lnkInForcast = (LinkButton)row.FindControl("lnkInForcast");
                Label lblInForcast = (Label)row.FindControl("lblInForcast");
                if (lnkInTransit != null)
                {
                    if (lnkInTransit.Text != "0")
                    {
                        lnkInTransit.Attributes.Remove("href");
                        lnkInTransit.Enabled = false;
                    }
                }

                if (lnkInProduction != null)
                {
                    if (lnkInProduction.Text != "0")
                    {
                        lnkInProduction.Attributes.Remove("href");
                        lnkInProduction.Enabled = false;
                    }
                }

                if (lnkInForcast != null)
                {
                    if (lnkInForcast.Text != "0")
                    {
                        lnkInForcast.Attributes.Remove("href");
                        lnkInForcast.Enabled = false;
                    }
                }
                lblInTransit.Visible = true;
                lblInProduction.Visible = true;
                lblInForcast.Visible = true;
                lnkInTransit.Visible = false;
                lnkInProduction.Visible = false;
                lnkInForcast.Visible = false;
            }

            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            foreach (DataControlFieldHeaderCell headerCell in gvInventoryReport.HeaderRow.Cells)
            {
                headerCell.ForeColor = System.Drawing.Color.Black; // Set header text color to black
                headerCell.Font.Bold = true;
            }
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvInventoryReport.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDocument = new Document(PageSize.A3, 10f, 10f, 10f, 10f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDocument);
            pdfDocument.SetPageSize(PageSize.A3.Rotate());
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            pdfDocument.Open();
            htmlparser.Parse(sr);
            pdfDocument.Close();
            Response.Write(pdfDocument);
            Response.End();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //#endregion    

    protected void ddlProductLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlProductLine_SelectedIndexChanged();
    }

    private void ddlProductLine_SelectedIndexChanged()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ObjBOL.ProductLine = Int32.Parse(ddlProductLine.SelectedValue);
            ds = ObjBLL.Return_DataSet(ObjBOL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlPartNo, ds.Tables[0]);
            }
            else
            {
                ddlPartNo.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvInventoryReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            LinkButton lnkInTransit = (LinkButton)e.Row.FindControl("lnkInTransit");
            LinkButton lnkInProduction = (LinkButton)e.Row.FindControl("lnkInProduction");
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

            if (lnkInProduction != null)
            {
                if (lnkInProduction.Text == "0")
                {
                    lnkInProduction.Attributes.Remove("href");
                    if (lnkInProduction.Enabled != false)
                    {
                        lnkInProduction.Enabled = false;
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[0].Visible = false;
                if (gvInventoryReport.Rows.Count >= 0 && gvInventoryReport.HeaderRow != null)
                {
                    foreach (TableCell cell in gvInventoryReport.HeaderRow.Cells)
                    {
                        cell.ForeColor = System.Drawing.Color.White; // Change to white                        
                    }
                    if (ddlReportType.SelectedValue == "3")
                    {
                        e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    }

                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvInventoryReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "TransitCommand")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblID = (Label)clickedRow.FindControl("lblItemPartid");
                LinkButton lnkTranstit = (LinkButton)clickedRow.FindControl("lnkInTransit");
                if (lnkTranstit.Text == "0")
                {
                    return;
                }
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int id = (int)gvInventoryReport.DataKeys[rowIndex]["id"];
                ObjBOL_1.PartId = id;
                ObjBOL_1.Operation = 1;
                ds = ObjBLL_1.GetTransitionData(ObjBOL_1);
                gvInTransit.DataSource = ds.Tables[0];
                gvInTransit.DataBind();
                lblPartNumber.Text = ds.Tables[0].Rows[0]["Partnumber"].ToString();
                ModalPopupExtender1.Show();
            }
            else if (e.CommandName == "ProductionCommand")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                LinkButton lnkInProduction = (LinkButton)clickedRow.FindControl("lnkInProduction");
                if (lnkInProduction.Text == "0")
                {
                    return;
                }
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int id = (int)gvInventoryReport.DataKeys[rowIndex]["id"];
                ObjBOL_1.PartId = id;
                ObjBOL_1.Operation = 1;
                ds = ObjBLL_1.GetInShopData(ObjBOL_1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvInShop.DataSource = ds.Tables[0];
                    gvInShop.DataBind();
                    lblInShopPartNumber.Text = ds.Tables[0].Rows[0]["Partnumber"].ToString();
                    ModalPopupExtender2.Show();
                }
            }
            else if (e.CommandName == "ForcastCommand")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                LinkButton lnkInForcast = (LinkButton)clickedRow.FindControl("lnkInForcast");
                if (lnkInForcast.Text == "0")
                {
                    return;
                }
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                int id = (int)gvInventoryReport.DataKeys[rowIndex]["id"];
                ObjBOL.ProductLine = id;
                ObjBOL.Operation = 6;
                ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvInForcast.DataSource = ds.Tables[0];
                    gvInForcast.DataBind();
                    lblTitle.Text = ds.Tables[1].Rows[0][1].ToString();
                    ModalPopupExtender3.Show();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvInventoryReport_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                DataView dataView = new DataView(dtrslt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvInventoryReport.DataSource = dataView;
                gvInventoryReport.DataBind();

            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + "DESC";
                gvInventoryReport.DataSource = dtrslt;
                gvInventoryReport.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlProductCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 7;
            ObjBOL.ProductLine = Int32.Parse(ddlProductCode.SelectedValue);
            ds = ObjBLL.Return_DataSet(ObjBOL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProductLine, ds.Tables[0]);
            }
            else
            {
                ddlProductLine.Items.Clear();
            }
            ddlProductLine_SelectedIndexChanged();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}