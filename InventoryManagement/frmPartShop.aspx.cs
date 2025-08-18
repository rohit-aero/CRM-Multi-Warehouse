using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Collections.Generic;

public partial class InventoryManagement_frmPartShop : System.Web.UI.Page
{
    BOLPartMaintainanace ObjBOL = new BOLPartMaintainanace();
    BLLManagePartsMaintainance ObjBLL = new BLLManagePartsMaintainance();
    commonclass1 clscon = new commonclass1();
    string folderPath = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            Bind_Control();
            ddlProductLine.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
        }
    }

    private void GetFilePaths()
    {
        try
        {
            folderPath = "../ImageHandler.ashx?imagePath=" + Utility.PartImagePath();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #region Bind
    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ObjBOL.LoginUserId = Utility.GetCurrentSession().EmployeeID;
            ds = ObjBLL.GetINVDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProductCode, ds.Tables[0]);
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Event Handlers
    protected void gvPartsDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                int field1 = 0;
                string field2 = "";
                field2 = dr["PartImage"].ToString();
                string fullPath = Utility.PartImageForExport().Replace("~", "") + field2;
                FileInfo file = new FileInfo(Server.MapPath(fullPath));
                if (field2 != "" && file.Exists)
                {
                    var boundFields2 = e.Row.Cells.Cast<DataControlFieldCell>()
                    .Select(cell => cell.ContainingField).Cast<BoundField>().ToList();

                    int idx2 = boundFields2.IndexOf(
                        boundFields2.FirstOrDefault(f => f.DataField == "PartImage"));
                    e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<img height='100' width='100' src =\'" + ConfigurationManager.AppSettings["PartImage"] + fullPath + "'> " + "</img>");
                    //e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<img height = '100px' width = '100px' src =\'" + e.Row.Cells[idx2].Text.Replace("~", "") + "'> " + "</img>");
                }  
                else
                {
                    var boundFields2 = e.Row.Cells.Cast<DataControlFieldCell>()
                        .Select(cell => cell.ContainingField).Cast<BoundField>().ToList();

                    int idx2 = boundFields2.IndexOf(
                        boundFields2.FirstOrDefault(f => f.DataField == "PartImage"));

                    e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<img height='100' width='100' src =\'" + ConfigurationManager.AppSettings["PartImage"] + fullPath + "'> " + "</img>");
                    e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<p> " + "</p>");
                }             
            }
            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSearch_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                DataView dataView = new DataView(dtrslt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvSearch.DataSource = dataView;
                gvSearch.DataBind();
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + "DESC";
                gvSearch.DataSource = dtrslt;
                gvSearch.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        //GridBind();
        try
        {
            btnShow_Click_Event();
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

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            btnExportToExcel_Click_Event();
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

    #endregion

    #region other functions

    private string PrepareSqlQuery()
    {
        GetFilePaths();
        string query = string.Empty;
        query = " SELECT DISTINCT Inv_ProductCode.[name] as [ProductCode], Inv_Product.[Product] as Product, ";
        query += " CASE WHEN Inv_Parts.revisionno IS NULL OR Inv_Parts.revisionno = '' THEN  ";
        query += " concat(Inv_Parts.PartNumber + ' ', Inv_Parts.CustomerPartNumber) ";
        query += " ELSE concat(Inv_Parts.PartNumber + ' ', Inv_Parts.CustomerPartNumber) + ', ' + ISNULL(Inv_Parts.revisionno, '') END AS [PartNumber], ";
        query += " Inv_Parts.PartDes AS [PartDes], Inv_UM.UM, CASE WHEN Partimage IS NULL THEN NULL ELSE '"+ folderPath +"' + Partimage END AS PartImage, ";
        query += " CASE WHEN INV_PartsDWG.drawingname IS NULL THEN 'No' ELSE 'Yes' END AS [DwgAttached], ";
        query += " CASE WHEN Inv_Parts.PartStatus=1 THEN 'Current' ELSE 'Obsolete' END AS [Status], ";
        query += " CASE WHEN Inv_Parts.StockItem=1 THEN 'Yes' ELSE 'No' END AS [StockItem], ";
        query += " Inv_Parts.stockinhand AS [StockInHand], ";
        query += " Inv_Parts.reorderpoint AS [ReorderPoint], ";
        query += " Inv_Parts.reorderqty AS [ReorderQty],Inv_Parts.leadtime AS [LeadTime], ";
        query += " Case when Inv_Parts.LineStopper=1 Then 'Yes' Else 'No' End AS [LineStopper] ";
        query += " FROM Inv_Parts INNER JOIN Inv_ProductCode ON Inv_ProductCode.id=Inv_Parts.productcode ";
        query += "  INNER JOIN Inv_Product ON Inv_Product.id=Inv_Parts.ProductId ";
        query += " LEFT JOIN Inv_UM ON Inv_UM.id = Inv_Parts.UMId ";
        query += " LEFT JOIN INV_PartsDWG ON INV_PartsDWG.partid=Inv_Parts.id ";
        query += " WHERE Inv_Parts.id IS NOT NULL ";
        if (ddlProductCode.SelectedIndex > 0)
        {
            query += " AND INV_Parts.productcode = " + ddlProductCode.SelectedValue + " ";
        }
        if (ddlProductLine.SelectedIndex > 0)
        {
            query += " AND Inv_Parts.ProductId = " + ddlProductLine.SelectedValue + " ";
        }
        if (ddlLineStoppers.SelectedValue == "0" || ddlLineStoppers.SelectedValue == "1")
        {
            query += " AND INV_Parts.LineStopper = " + ddlLineStoppers.SelectedValue + " ";
        }
        if (ddlPartStatus.SelectedValue == "0" || ddlPartStatus.SelectedValue == "1")
        {
            query += " AND Inv_Parts.PartStatus = " + ddlPartStatus.SelectedValue + " ";
        }       
        if (ddlDwgAttached.SelectedValue == "1" || ddlDwgAttached.SelectedValue == "0")
        {
            if (ddlDwgAttached.SelectedValue == "1")
            {
                query += " AND  INV_PartsDWG.drawingname IS NOT NULL";
            }
            else
            {
                query += " AND  INV_PartsDWG.drawingname IS NULL";
            }
        }
        if (txtPartNum.Text.Trim() != "")
        {
            query += " AND (Inv_Parts.PartNumber LIKE '%" + txtPartNum.Text + "%' ";
            query += " OR Inv_Parts.CustomerPartNumber LIKE '%" + txtPartNum.Text + "%' ";
            query += " OR Inv_UM.UM LIKE '%" + txtPartNum.Text + "%' ";
            query += " OR Inv_Parts.PartDes LIKE '%" + txtPartNum.Text + "%') ";
        }
        query += " ORDER BY [PartNumber] asc";
        return query;
    }

    private string PrepareSqlQueryExcel()
    {
        string query = string.Empty;
        query = " SELECT DISTINCT Inv_ProductCode.[name] as [Product Code], ";
        query += " CASE WHEN Inv_Parts.revisionno IS NULL OR Inv_Parts.revisionno = '' THEN  ";
        query += " concat(Inv_Parts.PartNumber + ' ', Inv_Parts.CustomerPartNumber) ";
        query += " ELSE concat(Inv_Parts.PartNumber + ' ', Inv_Parts.CustomerPartNumber) + ', ' + ISNULL(Inv_Parts.revisionno, '') END AS [Part Number], ";
        query += " Inv_Parts.PartDes AS [Part Des], Inv_Product.[Product] as [Product Line],  ";
        query += " Inv_UM.UM, CASE WHEN Partimage IS NULL THEN NULL ELSE  Partimage END AS PartImage, ";
        query += " CASE WHEN Inv_Parts.StockItem=1 THEN 'Yes' ELSE 'No' END AS [Stock Item], ";
        query += " CASE WHEN INV_PartsDWG.drawingname IS NULL THEN 'No' ELSE 'Yes' END AS [Dwg Attached], ";
        query += " CASE WHEN Inv_Parts.PartStatus=1 THEN 'Current' ELSE 'Obsolete' END AS [Status], ";
        query += " Inv_Parts.stockinhand AS [Stock In Hand], ";
        query += " Inv_Parts.reorderpoint AS [Reorder Point], ";
        query += " Inv_Parts.reorderqty AS [ReorderQty],Inv_Parts.leadtime AS [Lead Time], ";        
        query += " Case when Inv_Parts.LineStopper=1 Then 'Yes' Else 'No' End AS [Line Stopper] ";
        query += " FROM Inv_Parts INNER JOIN Inv_ProductCode ON Inv_ProductCode.id=Inv_Parts.productcode ";
        query += "  INNER JOIN Inv_Product ON Inv_Product.id=Inv_Parts.ProductId ";
        query += " LEFT JOIN Inv_UM ON Inv_UM.id = Inv_Parts.UMId ";
        query += " LEFT JOIN INV_PartsDWG ON INV_PartsDWG.partid=Inv_Parts.id ";
        query += " WHERE Inv_Parts.id IS NOT NULL ";
        if (ddlProductCode.SelectedIndex > 0)
        {
            query += " AND INV_Parts.productcode = " + ddlProductCode.SelectedValue + " ";
        }
        if (ddlProductLine.SelectedIndex > 0)
        {
            query += " AND Inv_Parts.ProductId = " + ddlProductLine.SelectedValue + " ";
        }
        if (ddlLineStoppers.SelectedValue == "0" || ddlLineStoppers.SelectedValue == "1")
        {
            query += " AND INV_Parts.LineStopper = " + ddlLineStoppers.SelectedValue + " ";
        }
        if (ddlPartStatus.SelectedValue == "0" || ddlPartStatus.SelectedValue == "1")
        {
            query += " AND Inv_Parts.PartStatus = " + ddlPartStatus.SelectedValue + " ";
        }
        if (ddlDwgAttached.SelectedValue == "1" || ddlDwgAttached.SelectedValue == "0")
        {
            if (ddlDwgAttached.SelectedValue == "1")
            {
                query += " AND  INV_PartsDWG.drawingname IS NOT NULL";
            }
            else
            {
                query += " AND  INV_PartsDWG.drawingname IS NULL";
            }
        }
        if (txtPartNum.Text.Trim() != "")
        {
            query += " AND (Inv_Parts.PartNumber LIKE '%" + txtPartNum.Text + "%' ";
            query += " OR Inv_Parts.CustomerPartNumber LIKE '%" + txtPartNum.Text + "%' ";
            query += " OR Inv_UM.UM LIKE '%" + txtPartNum.Text + "%' ";
            query += " OR Inv_Parts.PartDes LIKE '%" + txtPartNum.Text + "%') ";
        }
        query += " ORDER BY [Part Number] asc";
        return query;
    }
    #endregion

    #region Internal Event Functions

    private void btnShow_Click_Event()
    {
        try
        {
            DataTable dt = new DataTable();
            ViewState["dirState"] = null;
            string query = PrepareSqlQuery();
            clscon.Return_DT(dt, query);
            if (dt.Rows.Count > 0)
            {
                gvSearch.DataSource = dt;
                gvSearch.DataBind();
                ViewState["dirState"] = dt;
                gvSearch.Visible = true;
                btnExporttoExcel.Enabled = true;
                btnExporttoPdf.Enabled = true;
                lblRecordsCount.Text = "Total No. of Records:" + dt.Rows.Count.ToString();
                lblRecordsCount.Visible = true;
            }
            else
            {
                gvSearch.DataSource = string.Empty;
                gvSearch.DataBind();
                btnExporttoExcel.Enabled = false;
                btnExporttoPdf.Enabled = false;
                lblRecordsCount.Text = "Total No. of Records:" + dt.Rows.Count.ToString();
                lblRecordsCount.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable btnShow_Click_Event_Export()
    {
        DataTable dt = new DataTable();
        try
        {            
            ViewState["GridExport"] = null;
            string query = PrepareSqlQueryExcel();
            clscon.Return_DT(dt, query);
            //if (dt.Rows.Count > 0)
            //{
            //    ViewState["GridExport"] = dt;
            //    gvPartsDetails.DataSource = dt;
            //    gvPartsDetails.DataBind();                             
            //}            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void BindProduct(string ProductCode)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 18;
            ObjBOL.ProductCode = Convert.ToInt32(ProductCode);
            ds = ObjBLL.GetINVDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProductLine, ds.Tables[0]);
            }
            else
            {
                ResetProduct();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnExportToExcel_Click_Event()
    {
        try
        {
            System.Data.DataTable dt = (DataTable)btnShow_Click_Event_Export();
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Remove("PartImage");
                dt.AcceptChanges();
                string FileName = "Parts List " + DateTime.Now.ToString("MM/dd/yyyy");
                Utility.ExportToExcelDT(dt, FileName);
                //Response.Clear();
                //Response.Buffer = true;
                
                //Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
                //Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                //using (StringWriter sw = new StringWriter())
                //{
                //    HtmlTextWriter hw = new HtmlTextWriter(sw);
                //    //To Export all pages.                  
                //    gvPartsDetails.AllowPaging = false;                    
                //    gvPartsDetails.HeaderRow.BackColor = Color.White;
                //    foreach (TableCell cell in gvPartsDetails.HeaderRow.Cells)
                //    {
                //        cell.BackColor = gvPartsDetails.HeaderStyle.BackColor;
                //    }
                //    foreach (GridViewRow row in gvPartsDetails.Rows)
                //    {
                //        row.Cells[5].Style.Add("width", "110");
                //        row.Cells[5].Style.Add("Height", "110");
                //    }
                //    gvPartsDetails.RenderControl(hw);                    
                //    //Style to format numbers to string.
                //    string style = @"<style> .textmode { } </style>";
                //    Response.Write(style);
                //    Response.Output.Write(sw.ToString());
                //    Response.Flush();
                //    Response.End();
                //}
            }
            else
            {
                Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
            }


        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnExportToPdf_Click(object sender, EventArgs e)
    {
        try
        {
            Response.ContentType = "application/pdf";
            string FileName = ddlProductCode.SelectedItem.Text + " Parts List" + ".pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Document pdfDoc = new Document(PageSize.A2, 2f, 2f, 5f, 0f);
            PdfPTable table = new PdfPTable(gvSearch.Columns.Count);
            table.WidthPercentage = 100;
            PdfPCell headerCell = new PdfPCell(new Phrase(DateTime.Now.ToLongDateString()));
            //headerCell.Colspan = gvSearch.Columns.Count - 2;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            var height = 40f;
            float[] widths = new float[gvSearch.Columns.Count];
            for (int i = 0; i < widths.Length; i++)
            {
                if (i == 2)
                {
                    widths[i] = 5f;
                }
                else if (i == 4 || i == 10)
                {
                    widths[i] = 1f;
                }
                else
                {
                    widths[i] = 2f;
                }
            }
            table.SetWidths(widths);
            for (int i = 0; i < gvSearch.HeaderRow.Cells.Count; i++)
            {
                iTextSharp.text.Font font = FontFactory.GetFont("Cambria", 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                int red = Convert.ToInt32("08", 16);
                int green = Convert.ToInt32("56", 16);
                int blue = Convert.ToInt32("A1", 16);
                PdfPCell pdfCell = new PdfPCell(new Phrase(gvSearch.HeaderRow.Cells[i].Text, font));
                pdfCell.MinimumHeight = height;
                pdfCell.BackgroundColor = new BaseColor(red, green, blue);
                //pdfCell.BackgroundColor = new BaseColor(System.Drawing.Color.Blue);
                table.AddCell(pdfCell);
            }

            for (int r = 0; r < gvSearch.Rows.Count; r++)
            {
                GridViewRow row = gvSearch.Rows[r];
                for (int i = 0; i < row.Cells.Count; i++)
                {

                    iTextSharp.text.Font font = new iTextSharp.text.Font();
                    if (row.Cells[i].Controls.Count > 0)
                    {
                        foreach (Control control in row.Cells[i].Controls)
                        {
                            if (control is Label)
                            {
                                PdfPCell pdfCell = new PdfPCell(new Phrase(((Label)control).Text));
                                pdfCell.MinimumHeight = height;
                                table.AddCell(pdfCell);
                            }
                            else if (control is System.Web.UI.WebControls.Image)
                            {
                                System.Web.UI.WebControls.Image webImage = (System.Web.UI.WebControls.Image)control;
                                string imageUrl = webImage.ImageUrl;
                                if(imageUrl != "")
                                {
                                    const string removeString = "../ImageHandler.ashx?imagePath=";
                                    int index = imageUrl.IndexOf(imageUrl);
                                    int length = removeString.Length;
                                    String startOfString = imageUrl.Substring(0, index);
                                    String endOfString = imageUrl.Substring(index + length);
                                    String UrlPath = startOfString + endOfString;
                                    if (System.IO.File.Exists(UrlPath))
                                    {
                                        iTextSharp.text.Image itextImage = iTextSharp.text.Image.GetInstance(UrlPath);
                                        itextImage.ScaleToFit(80f, 80f);
                                        PdfPCell pdfCell = new PdfPCell(itextImage);
                                        pdfCell.MinimumHeight = height;
                                        table.AddCell(pdfCell);
                                    }
                                    else
                                    {
                                        PdfPCell pdfCell = new PdfPCell(new Phrase(" "));
                                        pdfCell.MinimumHeight = height;
                                        table.AddCell(pdfCell);
                                    }
                                }
                                else
                                {
                                    PdfPCell pdfCell = new PdfPCell(new Phrase(" "));
                                    pdfCell.MinimumHeight = height;
                                    table.AddCell(pdfCell);
                                }
                            }

                        }
                    }
                }
            }

            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(table);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Grid Sort

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

    #region reset
    private void Reset()
    {
        try
        {
            gvSearch.Visible = false;
            ddlLineStoppers.SelectedIndex = 0;
            ddlProductCode.SelectedIndex = 0;            
            ddlPartStatus.SelectedIndex = 0;
            ddlDwgAttached.SelectedIndex = 0;
            txtPartNum.Text = string.Empty;
            lblRecordsCount.Visible = false;
            ResetProduct();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion   

    protected void ddlProductCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if(ddlProductCode.SelectedIndex>0)
            {
                BindProduct(ddlProductCode.SelectedValue);
            }
            else
            {
                ResetProduct();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetProduct()
    {
        try
        {
            ddlProductLine.DataSource = "";
            ddlProductLine.DataBind();
            ddlProductLine.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}