using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Web;
using System.Drawing;
using BOLAERO;
using BLLAERO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;
using System.Configuration;

public partial class Reports_frmForecasting : System.Web.UI.Page
{
    private GridViewHelper helper;
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    BOLManageForecasting objBOL = new BOLManageForecasting();
    BLLManageForecasting objBLL = new BLLManageForecasting();
    string folderPath = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                SetDate();
                BindControls();
                divAerowerksForecastingReport.Attributes.Add("style", "display:block");
            }
            //GridViewHelper helper = new GridViewHelper(this.gvSearch);
            //helper.RegisterGroup("Product", true, true);           
            //helper.GroupHeader += new GroupEvent(helper_GroupHeader);
            //helper.GroupHeader += new GroupEvent(helper_Header);
            //helper.GroupSummary += new GroupEvent(helper_Bug);
            // helper.ApplyGroupSort();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SetDate()
    {
        try
        {
            int Month = DateTime.Now.Month + 2;
            txtFromDate.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            DateTime dateto = DateTime.Now.AddDays(60);
            string datenext = dateto.ToString("MM/dd/yyyy");
            //txtToDate.Text = DateTime.Now.AddMonths(2).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.AddMonths(2).Year;
            txtToDate.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
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
            folderPath = "../ImageHandler.ashx?imagePath=" + Utility.PartImagePath();
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
            objBOL.Operation = 1;
            ds = objBLL.GetData(objBOL);
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProduct, ds.Tables[2]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        //if (groupName == "Product")
        //{
        //    row.Cells[0].BackColor = Color.LightGray;
        //}
    }

    private void helper_Footer(string groupName, object[] values, GridViewRow row)
    {
        //if (groupName == "Product")
        //{
        //    //row.Cells[0].Text = "$" + row.Cells[1].Text;
        //}
    }

    private void helper_Bug(string groupName, object[] values, GridViewRow row)
    {
        //if (groupName == null) return;
        //row.Cells[0].BackColor = Color.Yellow;
        //row.Cells[1].BackColor = Color.Yellow;
        //row.Cells[0].Font.Bold = true;
        //row.Cells[0].Font.Size = 12;
        //row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
        //row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
        //row.Cells[1].Font.Bold = true;
        //row.Cells[1].Font.Size = 12;
        //row.Cells[0].Text = "[ Sub-Total for  " + values[0] + " ]";
        //row.Cells[1].Text = "$" + row.Cells[1].Text;
    }

    private void helper_Header(string groupName, object[] values, GridViewRow row)
    {
        //if (groupName == null) return;
        //row.Cells[0].Font.Size = 14;
        //row.Cells[0].Font.Bold = true;
    }

    // check if data filled in required fields
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtFromDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter From Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter From Date. !!");
                txtFromDate.Focus();
                return false;
            }
            if (txtToDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter To Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter To Date. !!");
                txtToDate.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            if (ValidationCheck() == true)
            {
                GetFilePaths();
                gvSearch.Visible = true;
                // gvSearch2.Visible = true;
                string strDateFrom = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy");
                string strDateTo = Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy");
                string Qstr = String.Empty;
                string NQstr = String.Empty;
                string FQstr = String.Empty;
                Qstr += "  DECLARE @Columns NVARCHAR(MAX)='',  @SqlStatement NVARCHAR(MAX)=''  ";
                Qstr += "  SELECT @Columns += QUOTENAME(UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + ',  '  + Inv_ProjectParts.projectid + ', ' + ISNULL(tblCustomers.CompanyName,'') + ', '    ";
                Qstr += " + ISNULL(tblCustomers.City,'') + ', '  + ISNULL(tblStates.[State],''))) + ', ' From Inv_Parts   ";
                Qstr += " LEFT JOIN Inv_ProjectParts ON Inv_ProjectParts.partid=Inv_Parts.id  ";
                Qstr += " LEFT JOIN tblProjects ON Inv_ProjectParts.projectid=tblProjects.JobID  ";
                Qstr += " LEFT JOIN tblCustomers ON tblCustomers.CustomerID=tblProjects.CustomerID  ";
                Qstr += " LEFT JOIN tblStates ON tblStates.StateID=tblCustomers.StateID  ";
                Qstr += " WHERE Inv_ProjectParts.qty IS NOT NULL  AND tblProjects.ProjectStatus NOT IN (2,3) AND Inv_Parts.ForecastItem=1  AND  ";
                Qstr += " tblProjects.ShipDate BETWEEN  '" + strDateFrom + "' AND '" + strDateTo + "' ";
                if (ddlProduct.SelectedIndex > 0)
                {
                    Qstr += " AND  Inv_Parts.ProductId=" + ddlProduct.SelectedValue + " ";
                }
                Qstr += "  GROUP BY UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + ',  '    ";
                Qstr += "  + Inv_ProjectParts.projectid + ', ' + ISNULL(tblCustomers.CompanyName,'') + ', '  + ISNULL(tblCustomers.City,'') + ', '  + ISNULL(tblStates.[State],''))  ";

                Qstr += " if(@columns <>'')   begin SET @columns = LEFT(@columns, LEN(@columns) - 1); SET @SqlStatement=' ";

                Qstr += " Select * from ( Select Inv_Product.Product,MIN(Inv_Parts.PartNumber) +'' ''+ MIN(ISNULL(Inv_Parts.revisionno,'''')) AS [Part Number],MIN(Inv_Parts.PartDes) AS [Part Des], ";
                Qstr += " MIN(Inv_Parts.PartImage) AS [Part Image__________], MIN(UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + '',  '' + Inv_ProjectParts.projectid + '', ''  ";
                Qstr += " + ISNULL(tblCustomers.CompanyName,'''') + '', '' + ISNULL(tblCustomers.City,'''') + '', ''  + ISNULL(tblStates.[State],''''))) AS [Project_Name], ";
                Qstr += " MIN(Inv_Parts.[min]) AS [Min Qty],MIN(Inv_Parts.max) AS [Max Qty],MIN(Inv_ProjectParts.qty) as Qty, Inv_Parts.stockinhand AS [Opening Stock] ";
                Qstr += " from Inv_Parts  ";
                Qstr += " INNER JOIN Inv_Product ON Inv_Product.id=Inv_Parts.ProductId ";
                Qstr += " LEFT JOIN Inv_ProjectParts ON Inv_ProjectParts.partid=Inv_Parts.id  ";
                Qstr += " LEFT JOIN tblProjects ON Inv_ProjectParts.projectid=tblProjects.JobID  ";
                Qstr += " LEFT JOIN tblCustomers ON tblCustomers.CustomerID=tblProjects.CustomerID  ";
                Qstr += " LEFT JOIN tblStates ON tblStates.StateID=tblCustomers.StateID  ";
                Qstr += " WHERE Inv_ProjectParts.qty IS NOT NULL  AND tblProjects.ProjectStatus NOT IN (2,3) AND Inv_Parts.ForecastItem=1   ";
                Qstr += " AND  tblProjects.ShipDate BETWEEN ''" + strDateFrom + "'' AND ''" + strDateTo + "'' ";
                if (ddlProduct.SelectedIndex > 0)
                {
                    Qstr += " AND  Inv_Parts.ProductId=" + ddlProduct.SelectedValue + " ";
                }
                Qstr += " GROUP BY Inv_Product.Product,Inv_Parts.PartNumber, ";
                Qstr += " UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + '',  '' + Inv_ProjectParts.projectid + '', '' + ISNULL(tblCustomers.CompanyName,'''') + '', '' ";
                Qstr += " + ISNULL(tblCustomers.City,'''') + '', ''  + ISNULL(tblStates.[State],'''')),Inv_Parts.stockinhand) AS  P ";
                Qstr += "  PIVOT (SUM (Qty) FOR [Project_Name] IN (' + @Columns + ') ) AS PIVOT_TABLE order by Product,[Part Number], [Part Des],' + @Columns + '' EXEC sp_executesql @SqlStatement  END ";
                FQstr += Qstr;
                clscon.Return_DT(dt, FQstr);
                if (dt.Rows.Count > 0)
                {
                    //0 AS[Closing Stock],0 AS[Re - Order(Y / N)], 0 AS[Production Run / Purchase Requisition *], 0 AS[Inventory After Stock In]
                    //dt.Columns.Add("Total Quantity Required", typeof(int));
                    DataColumn Col = dt.Columns.Add("Total Quantity Required", typeof(int));
                    Col.SetOrdinal(6);// to put the column in position 0;
                    //dt.Columns.Add("Category", typeof(int));
                    DataColumn Col1 = dt.Columns.Add("Closing Stock", typeof(int));
                    Col1.SetOrdinal(7);
                    //dt.Columns.Add(" ", typeof(string));
                    //dt.Columns.Add("Re - Order(Y/N)", typeof(string));
                    //dt.Columns.Add("Production Run/Purchase Requisition *", typeof(int));
                    //dt.Columns.Add("Inventory After Stock In", typeof(int));
                    foreach (DataRow row in dt.Rows)
                    {
                        int rowSum = 0;
                        int closestock = 0;
                        int opstock = 0;
                        //int reorderpoint = 0;
                        //int reorderqty = 0;
                        string[] firstnames = new String[]
                        { "Part Number", "Min Qty", "Max Qty",
                            "Re Order Point","Re Order Qty","UM",
                            "Lead Time (In Days)","Opening Stock",
                             "PartId"
                        };
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (!row.IsNull(col))
                            {
                                //if (col.ToString() == "Part Image")
                                //{                                    
                                //    row.SetField("Part Image", HttpUtility.HtmlDecode("<img height = '100px' width = '100px' src =\'" + row[col].ToString().Replace("~", "") + "'> " + "</img>"));
                                //}
                                if (col.ToString() != "Part Number")
                                {
                                    if (col.ToString() != "Min Qty")
                                    {
                                        if (col.ToString() != "Max Qty")
                                        {
                                            // if (col.ToString() != "Re Order Point")
                                            // {
                                            //  if (col.ToString() != "Re Order Qty")
                                            // {
                                            //if (col.ToString() != "UM")
                                            //{
                                            //if (col.ToString() != "Lead Time (In Days)")
                                            //{
                                            if (col.ToString() == "Opening Stock")
                                            {
                                                string stringclose = row[col].ToString();
                                                int d1;
                                                if (int.TryParse(stringclose, out d1))
                                                    opstock += d1;
                                            }
                                            if (col.ToString() != "Opening Stock")
                                            {
                                                if (col.ToString() != "Desc")
                                                {
                                                    string stringValue = row[col].ToString();
                                                    int d;
                                                    if (int.TryParse(stringValue, out d))
                                                        rowSum += d;
                                                    closestock = (opstock - rowSum);
                                                }
                                            }
                                            // }
                                            //}
                                            //}
                                            // }
                                        }
                                    }
                                }
                            }
                        }
                        // int ordqty = 0;
                        //if (closestock <= reorderpoint)
                        //{
                        //    row.SetField("Re - Order(Y/N)", "Y");
                        //    if (reorderpoint != 0 && reorderqty != 0)
                        //    {
                        //        for (int clstk = closestock; clstk <= reorderpoint;)
                        //        {
                        //            ordqty += reorderqty;
                        //            clstk += reorderqty;
                        //        }
                        //    }
                        //    // row.SetField("Inventory After Stock In", ordqty - Math.Abs(closestock));
                        //    row.SetField("Inventory After Stock In", ordqty + closestock);
                        //}
                        //else
                        //{
                        //    row.SetField("Re - Order(Y/N)", "N");
                        //    row.SetField("Inventory After Stock In", 0);
                        //}
                        // dt.SetColumnsOrder(new string[] { "Qty", "Unit", "Id" });
                        row.SetField("Total Quantity Required", rowSum);
                        row.SetField("Closing Stock", closestock);
                        //row.SetField("Production Run/Purchase Requisition *", ordqty);
                        //row.SetField(" ", "_____");                        
                    }
                    //gvSearch.HeaderStyle.VerticalAlign = VerticalAlign.Bottom;                  
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportData_Summary()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "EXEC Get_Forecast_Summary '" + txtFromDate.Text + "', '" + txtToDate.Text + "', ";
            if (ddlProduct.SelectedIndex > 0)
            {
                query += ddlProduct.SelectedValue + " ";
            }
            else
            {
                query += " NULL ";
            }
            clscon.Return_DT(dt, query);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void BindGrid(bool BindHeader)
    {
        DataTable dt = new DataTable();
        try
        {
            if (ddlReportType.SelectedValue == "D")
            {
                dt = ReportData();
            }
            else if (ddlReportType.SelectedValue == "S")
            {
                dt = ReportData_Summary();
            }
            if (dt.Rows.Count > 0)
            {
                btnGenerateExcel.Enabled = true;
                btnExporttoPdf.Enabled = true;
                gvSearch.DataSource = dt;
                gvSearch.DataBind();
                if (BindHeader)
                {
                    GridViewRow additionalHeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

                    TableHeaderCell additionalHeaderCell = new TableHeaderCell();
                    additionalHeaderCell.Text = "<span id=\"additionalHeader\">Forecast Report from " + txtFromDate.Text + " to " + txtToDate.Text + " </span>";
                    additionalHeaderCell.ColumnSpan = dt.Columns.Count;
                    additionalHeaderRow.Cells.Add(additionalHeaderCell);
                    gvSearch.Controls[0].Controls.AddAt(0, additionalHeaderRow);
                }
                //gvSearch.Columns[0].Visible = false;
            }
            else
            {
                btnGenerateExcel.Enabled = false;
                btnExporttoPdf.Enabled = false;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('All Projects has been Released to Production. Please add new Projects !!');", true);
                Utility.ShowMessage_Error(Page, "All Projects has been Released to Production. Please add new Projects !!");
                gvSearch.DataSource = "";
                gvSearch.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnGenrate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                BindGrid(false);
                divAerowerksForecastingReport.Attributes.Add("style", "display:none");
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

    //private void GenrateReport_SecondExcel()
    //{
    //    try
    //    {
    //        System.Data.DataTable dt = (DataTable)ReportData();
    //        DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
    //        DateTime dtto = Convert.ToDateTime(txtToDate.Text);
    //        string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
    //        string strDateTo = dtto.ToString("MM/dd/yyyy");
    //        if (dt.Rows.Count > 0)
    //        {
    //            foreach (DataRow dr in dt.Rows)
    //            {
    //                dr["Part Number"] = "=\"" + dr["Part Number"] + "\"";
    //            }
    //            Response.Clear();
    //            Response.Buffer = true;
    //            string FileName = "Forecasing " + ddlReportType.SelectedItem.Text + " " + DateTime.Now.ToString("MM/dd/yyyy") + ".xls";
    //            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
    //            Response.Charset = "";
    //            Response.ContentType = "application/vnd.ms-excel";
    //            using (StringWriter sw = new StringWriter())
    //            {
    //                HtmlTextWriter hw = new HtmlTextWriter(sw);
    //                //To Export all pages.
    //                gvSearch.AllowPaging = false;
    //                this.BindGrid();

    //                gvSearch.HeaderRow.BackColor = Color.White;
    //                foreach (TableCell cell in gvSearch.HeaderRow.Cells)
    //                {
    //                    cell.BackColor = gvSearch.HeaderStyle.BackColor;
    //                }
    //                foreach (GridViewRow row in gvSearch.Rows)
    //                {
    //                    row.Cells[3].Style.Add("width", "110");
    //                    row.Cells[3].Style.Add("Height", "20");
    //                }
    //                gvSearch.RenderControl(hw);
    //                //Style to format numbers to string.
    //                string style = @"<style> .textmode { } </style>";
    //                Response.Write(style);
    //                Response.Output.Write(sw.ToString());
    //                Response.Flush();
    //                Response.End();
    //            }
    //        }
    //        else
    //        {
    //            Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}   

    private void GenrateReport_SecondExcel()
    {
        try
        {
            ExportGridtoExcel(true);
            if (gvExportGrid.Rows.Count > 0)
            {
                string FileName = "Forecasing " + ddlReportType.SelectedItem.Text + " " + DateTime.Now.ToString("MM/dd/yyyy") + ".xls";
                Utility.ExportToExcelGrid(gvExportGrid, FileName);


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

    protected void btnGenerateExcel_Click(object sender, EventArgs e)
    {
        try
        {
            GenrateReport_SecondExcel();
            divAerowerksForecastingReport.Attributes.Add("style", "display:none");
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
            divAerowerksForecastingReport.Attributes.Add("style", "display:block");
            SetDate();
            if (ddlProduct.Items.Count > 0)
            {
                ddlProduct.SelectedIndex = 0;
            }

            if (ddlReportType.Items.Count > 0)
            {
                ddlReportType.SelectedIndex = 0;
            }
            btnExporttoPdf.Enabled = false;
            btnGenerateExcel.Enabled = false;
            gvSearch.DataSource = "";
            gvSearch.DataBind();
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void gvSearch_DataBound(object sender, EventArgs e)
    {
        try
        {
            string maxWidthForFirstColumn = "150px";
            string maxWidthForSecondColumn = "150px";
            string maxWidthForThirdColumn = "350px";
            for (int i = gvSearch.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvSearch.Rows[i];
                GridViewRow previousRow = gvSearch.Rows[i - 1];
                for (int j = 0; j < row.Cells.Count; j++)
                {
                    if (row.Cells[0].Text == previousRow.Cells[0].Text)
                    {
                        if (previousRow.Cells[0].RowSpan == 0)
                        {
                            if (row.Cells[0].RowSpan == 0)
                            {
                                previousRow.Cells[0].RowSpan += 2;
                            }
                            else
                            {
                                previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                            }
                            row.Cells[0].Visible = false;
                        }
                    }
                }
                // e.Row.Cells[i].Text = "<div class=\"verticalHeaderText\" style='writing-mode:vertical-rl; transform: rotate(180deg)'>" + e.Row.Cells[i].Text + "</div>";
                // gvSearch.Rows[i].Cells[0].Style.Add("class", "verticalHeaderText");
                gvSearch.Rows[i].Cells[0].Style.Add("vertical-align", "top");
                gvSearch.Rows[i].Cells[0].Style.Add("width", maxWidthForFirstColumn);
                gvSearch.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Left;
                gvSearch.Rows[i].Cells[1].Style.Add("width", maxWidthForSecondColumn);
                gvSearch.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Left;
                gvSearch.Rows[i].Cells[2].Style.Add("width", maxWidthForThirdColumn);
                gvSearch.Rows[i].Cells[2].HorizontalAlign = HorizontalAlign.Left;
                // gvSearch.Rows[i].Cells[0].CssClass = "locked";
                gvSearch.Rows[0].Cells[0].Style.Add("vertical-align", "top");
                gvSearch.Rows[0].Cells[0].Style.Add("width", maxWidthForFirstColumn);
                gvSearch.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
                gvSearch.Rows[0].Cells[1].HorizontalAlign = HorizontalAlign.Left;
                gvSearch.Rows[0].Cells[1].Style.Add("width", maxWidthForSecondColumn);
                gvSearch.Rows[0].Cells[2].HorizontalAlign = HorizontalAlign.Left;
                gvSearch.Rows[0].Cells[2].Style.Add("width", maxWidthForThirdColumn);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;
            int field1 = 0;
            string field2 = "";
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string temp = dr["Closing Stock"].ToString();
                if (temp.Trim() != "")
                {
                    field1 = int.Parse(temp);
                }
                else
                {
                    field1 = 0;
                }
            }
            if (ddlReportType.SelectedValue == "D")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    field2 = dr["Part Image__________"].ToString();
                    string fullPath = Utility.PartImageForExport().Replace("~", "") + field2;
                    FileInfo file = new FileInfo(Server.MapPath(fullPath));
                    //if(false)
                    if (field2 != "" && file.Exists)
                    {
                        var boundFields2 = e.Row.Cells.Cast<DataControlFieldCell>()
                        .Select(cell => cell.ContainingField).Cast<BoundField>().ToList();

                        int idx2 = boundFields2.IndexOf(
                            boundFields2.FirstOrDefault(f => f.DataField == "Part Image__________"));

                        //string imageUrl = "../ImageHandler.ashx?imagePath=" + HttpUtility.UrlPathEncode(Utility.PartImagePath() + field2);

                        e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<img height='100' width='100' src =\'" + ConfigurationManager.AppSettings["PartImage"] + fullPath + "'> " + "</img>");
                        //e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<img height='100' width='100' src =\'" + imageUrl + "'> " + "</img>");
                        //e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<img height = '100px' width = '100px' src =\'" + e.Row.Cells[idx2].Text.Replace("~", "") + "'> " + "</img>");
                    }
                    else
                    {
                        var boundFields2 = e.Row.Cells.Cast<DataControlFieldCell>()
                        .Select(cell => cell.ContainingField).Cast<BoundField>().ToList();

                        int idx2 = boundFields2.IndexOf(
                            boundFields2.FirstOrDefault(f => f.DataField == "Part Image__________"));
                        //e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<img height='100' width='100' src =\'" + ConfigurationManager.AppSettings["PartImage"] + e.Row.Cells[idx2].Text.Replace("~", "") + "'> " + "</img>");
                        e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<p> " + "</p>");
                    }
                }
            }

            foreach (TableCell cells in e.Row.Cells)
            {
                if (field1 < 0)
                {
                    //cells.ForeColor = Color.Red;
                    var boundFields = e.Row.Cells.Cast<DataControlFieldCell>()
                    .Select(cell => cell.ContainingField).Cast<BoundField>().ToList();

                    int idx = boundFields.IndexOf(
                        boundFields.FirstOrDefault(f => f.DataField == "Closing Stock"));
                    e.Row.Cells[idx].ForeColor = System.Drawing.Color.Red;
                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Text = "<div class=\"verticalHeaderText\" style='writing-mode:vertical-rl; transform: rotate(180deg)'>" + e.Row.Cells[i].Text + "</div>";
                    //e.Row.Cells[i].Text = e.Row.Cells[i].Text;
                    //e.Row.Cells[0].Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnExporttoPdf_Click(object sender, EventArgs e)
    {
        try
        {
            divAerowerksForecastingReport.Attributes.Add("style", "display:none");
            gvSearch.AllowPaging = false;
            this.BindGrid(true);
            gvSearch.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gvSearch.HeaderRow.Cells)
            {
                cell.BackColor = gvSearch.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvSearch.Rows)
            {
                row.Cells[3].Style.Add("width", "50");
                row.Cells[3].Style.Add("Height", "50");
            }
            Response.ContentType = "application/pdf";
            string FileName = "Forecasing " + ddlReportType.SelectedItem.Text + " " + DateTime.Now.ToString("MM/dd/yyyy") + ".pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvSearch.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDocument = new Document(PageSize.A3, 10, 10f, 10f, 10f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDocument);
            // pdfDocument.SetPageSize(PageSize.A3.Rotate());     
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

    #region Export Grid
    protected void gvExportGrid_DataBound(object sender, EventArgs e)
    {
        try
        {
            string maxWidthForFirstColumn = "150px";
            string maxWidthForSecondColumn = "150px";
            string maxWidthForThirdColumn = "350px";
            for (int i = gvExportGrid.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvExportGrid.Rows[i];
                GridViewRow previousRow = gvSearch.Rows[i - 1];
                for (int j = 0; j < row.Cells.Count; j++)
                {
                    if (row.Cells[0].Text == previousRow.Cells[0].Text)
                    {
                        if (previousRow.Cells[0].RowSpan == 0)
                        {
                            if (row.Cells[0].RowSpan == 0)
                            {
                                previousRow.Cells[0].RowSpan += 2;
                            }
                            else
                            {
                                previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                            }
                            row.Cells[0].Visible = false;
                        }
                    }
                }
                // e.Row.Cells[i].Text = "<div class=\"verticalHeaderText\" style='writing-mode:vertical-rl; transform: rotate(180deg)'>" + e.Row.Cells[i].Text + "</div>";
                // gvSearch.Rows[i].Cells[0].Style.Add("class", "verticalHeaderText");
                gvExportGrid.Rows[i].Cells[0].Style.Add("vertical-align", "top");
                gvExportGrid.Rows[i].Cells[0].Style.Add("width", maxWidthForFirstColumn);
                gvExportGrid.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Left;
                gvExportGrid.Rows[i].Cells[1].Style.Add("width", maxWidthForSecondColumn);
                gvExportGrid.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Left;
                gvExportGrid.Rows[i].Cells[2].Style.Add("width", maxWidthForThirdColumn);
                gvExportGrid.Rows[i].Cells[2].HorizontalAlign = HorizontalAlign.Left;
                // gvSearch.Rows[i].Cells[0].CssClass = "locked";

            }
            gvExportGrid.Rows[0].Cells[0].Style.Add("vertical-align", "top");
            gvExportGrid.Rows[0].Cells[0].Style.Add("width", maxWidthForFirstColumn);
            gvExportGrid.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
            gvExportGrid.Rows[0].Cells[1].HorizontalAlign = HorizontalAlign.Left;
            gvExportGrid.Rows[0].Cells[1].Style.Add("width", maxWidthForSecondColumn);
            gvExportGrid.Rows[0].Cells[2].HorizontalAlign = HorizontalAlign.Left;
            gvExportGrid.Rows[0].Cells[2].Style.Add("width", maxWidthForThirdColumn);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvExportGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;
            int field1 = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string temp = dr["Closing Stock"].ToString();
                if (temp.Trim() != "")
                {
                    field1 = int.Parse(temp);
                }
                else
                {
                    field1 = 0;
                }
            }

            foreach (TableCell cells in e.Row.Cells)
            {
                if (field1 < 0)
                {
                    //cells.ForeColor = Color.Red;
                    var boundFields = e.Row.Cells.Cast<DataControlFieldCell>()
                    .Select(cell => cell.ContainingField).Cast<BoundField>().ToList();

                    int idx = boundFields.IndexOf(
                        boundFields.FirstOrDefault(f => f.DataField == "Closing Stock"));
                    e.Row.Cells[idx].ForeColor = System.Drawing.Color.Red;
                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Text = "<div class=\"verticalHeaderText\" style='writing-mode:vertical-rl; transform: rotate(180deg)'>" + e.Row.Cells[i].Text + "</div>";
                    //e.Row.Cells[i].Text = e.Row.Cells[i].Text;
                    //e.Row.Cells[0].Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable ExporttoExcelData()
    {
        DataTable dt = new DataTable();
        try
        {
            if (ValidationCheck() == true)
            {
                GetFilePaths();
                gvSearch.Visible = true;
                // gvSearch2.Visible = true;
                string strDateFrom = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy");
                string strDateTo = Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy");
                string Qstr = String.Empty;
                string NQstr = String.Empty;
                string FQstr = String.Empty;
                Qstr += "  DECLARE @Columns NVARCHAR(MAX)='',  @SqlStatement NVARCHAR(MAX)=''  ";
                Qstr += "  SELECT @Columns += QUOTENAME(UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + ',  '  + Inv_ProjectParts.projectid + ', ' + ISNULL(tblCustomers.CompanyName,'') + ', '    ";
                Qstr += " + ISNULL(tblCustomers.City,'') + ', '  + ISNULL(tblStates.[State],''))) + ', ' From Inv_Parts   ";
                Qstr += " LEFT JOIN Inv_ProjectParts ON Inv_ProjectParts.partid=Inv_Parts.id  ";
                Qstr += " LEFT JOIN tblProjects ON Inv_ProjectParts.projectid=tblProjects.JobID  ";
                Qstr += " LEFT JOIN tblCustomers ON tblCustomers.CustomerID=tblProjects.CustomerID  ";
                Qstr += " LEFT JOIN tblStates ON tblStates.StateID=tblCustomers.StateID  ";
                Qstr += " WHERE Inv_ProjectParts.qty IS NOT NULL  AND tblProjects.ProjectStatus NOT IN (2,3) AND Inv_Parts.ForecastItem=1  AND  ";
                Qstr += " tblProjects.ShipDate BETWEEN  '" + strDateFrom + "' AND '" + strDateTo + "' ";
                if (ddlProduct.SelectedIndex > 0)
                {
                    Qstr += " AND  Inv_Parts.ProductId=" + ddlProduct.SelectedValue + " ";
                }
                Qstr += "  GROUP BY UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + ',  '    ";
                Qstr += "  + Inv_ProjectParts.projectid + ', ' + ISNULL(tblCustomers.CompanyName,'') + ', '  + ISNULL(tblCustomers.City,'') + ', '  + ISNULL(tblStates.[State],''))  ";

                Qstr += " if(@columns <>'')   begin SET @columns = LEFT(@columns, LEN(@columns) - 1); SET @SqlStatement=' ";

                Qstr += " Select * from ( Select Inv_Product.Product,MIN(''`'' + Inv_Parts.PartNumber) +'' ''+ MIN(ISNULL(Inv_Parts.revisionno,'''')) AS [Part Number],MIN(Inv_Parts.PartDes) AS [Part Des], ";
                Qstr += " MIN(UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + '',  '' + Inv_ProjectParts.projectid + '', ''  ";
                Qstr += " + ISNULL(tblCustomers.CompanyName,'''') + '', '' + ISNULL(tblCustomers.City,'''') + '', ''  + ISNULL(tblStates.[State],''''))) AS [Project_Name], ";
                Qstr += " MIN(Inv_Parts.[min]) AS [Min Qty],MIN(Inv_Parts.max) AS [Max Qty],MIN(Inv_ProjectParts.qty) as Qty, Inv_Parts.stockinhand AS [Opening Stock] ";
                Qstr += " from Inv_Parts  ";
                Qstr += " INNER JOIN Inv_Product ON Inv_Product.id=Inv_Parts.ProductId ";
                Qstr += " LEFT JOIN Inv_ProjectParts ON Inv_ProjectParts.partid=Inv_Parts.id  ";
                Qstr += " LEFT JOIN tblProjects ON Inv_ProjectParts.projectid=tblProjects.JobID  ";
                Qstr += " LEFT JOIN tblCustomers ON tblCustomers.CustomerID=tblProjects.CustomerID  ";
                Qstr += " LEFT JOIN tblStates ON tblStates.StateID=tblCustomers.StateID  ";
                Qstr += " WHERE Inv_ProjectParts.qty IS NOT NULL  AND tblProjects.ProjectStatus NOT IN (2,3) AND Inv_Parts.ForecastItem=1   ";
                Qstr += " AND  tblProjects.ShipDate BETWEEN ''" + strDateFrom + "'' AND ''" + strDateTo + "'' ";
                if (ddlProduct.SelectedIndex > 0)
                {
                    Qstr += " AND  Inv_Parts.ProductId=" + ddlProduct.SelectedValue + " ";
                }
                Qstr += " GROUP BY Inv_Product.Product,Inv_Parts.PartNumber, ";
                Qstr += " UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + '',  '' + Inv_ProjectParts.projectid + '', '' + ISNULL(tblCustomers.CompanyName,'''') + '', '' ";
                Qstr += " + ISNULL(tblCustomers.City,'''') + '', ''  + ISNULL(tblStates.[State],'''')),Inv_Parts.stockinhand) AS  P ";
                Qstr += "  PIVOT (SUM (Qty) FOR [Project_Name] IN (' + @Columns + ') ) AS PIVOT_TABLE order by Product,[Part Number], [Part Des],' + @Columns + '' EXEC sp_executesql @SqlStatement  END ";
                FQstr += Qstr;
                clscon.Return_DT(dt, FQstr);
                if (dt.Rows.Count > 0)
                {
                    //0 AS[Closing Stock],0 AS[Re - Order(Y / N)], 0 AS[Production Run / Purchase Requisition *], 0 AS[Inventory After Stock In]
                    //dt.Columns.Add("Total Quantity Required", typeof(int));
                    DataColumn Col = dt.Columns.Add("Total Quantity Required", typeof(int));
                    Col.SetOrdinal(6);// to put the column in position 0;
                    //dt.Columns.Add("Category", typeof(int));
                    DataColumn Col1 = dt.Columns.Add("Closing Stock", typeof(int));
                    Col1.SetOrdinal(7);
                    //dt.Columns.Add(" ", typeof(string));
                    //dt.Columns.Add("Re - Order(Y/N)", typeof(string));
                    //dt.Columns.Add("Production Run/Purchase Requisition *", typeof(int));
                    //dt.Columns.Add("Inventory After Stock In", typeof(int));
                    foreach (DataRow row in dt.Rows)
                    {
                        int rowSum = 0;
                        int closestock = 0;
                        int opstock = 0;
                        //int reorderpoint = 0;
                        //int reorderqty = 0;
                        string[] firstnames = new String[]
                        { "Part Number", "Min Qty", "Max Qty",
                            "Re Order Point","Re Order Qty","UM",
                            "Lead Time (In Days)","Opening Stock",
                             "PartId"
                        };
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (!row.IsNull(col))
                            {
                                //if (col.ToString() == "Part Image")
                                //{                                    
                                //    row.SetField("Part Image", HttpUtility.HtmlDecode("<img height = '100px' width = '100px' src =\'" + row[col].ToString().Replace("~", "") + "'> " + "</img>"));
                                //}
                                if (col.ToString() != "Part Number")
                                {
                                    if (col.ToString() != "Min Qty")
                                    {
                                        if (col.ToString() != "Max Qty")
                                        {
                                            // if (col.ToString() != "Re Order Point")
                                            // {
                                            //  if (col.ToString() != "Re Order Qty")
                                            // {
                                            //if (col.ToString() != "UM")
                                            //{
                                            //if (col.ToString() != "Lead Time (In Days)")
                                            //{
                                            if (col.ToString() == "Opening Stock")
                                            {
                                                string stringclose = row[col].ToString();
                                                int d1;
                                                if (int.TryParse(stringclose, out d1))
                                                    opstock += d1;
                                            }
                                            if (col.ToString() != "Opening Stock")
                                            {
                                                if (col.ToString() != "Desc")
                                                {
                                                    string stringValue = row[col].ToString();
                                                    int d;
                                                    if (int.TryParse(stringValue, out d))
                                                        rowSum += d;
                                                    closestock = (opstock - rowSum);
                                                }
                                            }
                                            // }
                                            //}
                                            //}
                                            // }
                                        }
                                    }
                                }
                            }
                        }
                        // int ordqty = 0;
                        //if (closestock <= reorderpoint)
                        //{
                        //    row.SetField("Re - Order(Y/N)", "Y");
                        //    if (reorderpoint != 0 && reorderqty != 0)
                        //    {
                        //        for (int clstk = closestock; clstk <= reorderpoint;)
                        //        {
                        //            ordqty += reorderqty;
                        //            clstk += reorderqty;
                        //        }
                        //    }
                        //    // row.SetField("Inventory After Stock In", ordqty - Math.Abs(closestock));
                        //    row.SetField("Inventory After Stock In", ordqty + closestock);
                        //}
                        //else
                        //{
                        //    row.SetField("Re - Order(Y/N)", "N");
                        //    row.SetField("Inventory After Stock In", 0);
                        //}
                        // dt.SetColumnsOrder(new string[] { "Qty", "Unit", "Id" });
                        row.SetField("Total Quantity Required", rowSum);
                        row.SetField("Closing Stock", closestock);
                        //row.SetField("Production Run/Purchase Requisition *", ordqty);
                        //row.SetField(" ", "_____");                        
                    }
                    //gvSearch.HeaderStyle.VerticalAlign = VerticalAlign.Bottom;                  
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportData_ExcelSummary()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "EXEC Get_Forecast_Summary_Excel '" + txtFromDate.Text + "', '" + txtToDate.Text + "', ";
            if (ddlProduct.SelectedIndex > 0)
            {
                query += ddlProduct.SelectedValue + " ";
            }
            else
            {
                query += " NULL ";
            }
            clscon.Return_DT(dt, query);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void ExportGridtoExcel(bool BindHeader)
    {
        DataTable dt = new DataTable();
        try
        {
            if (ddlReportType.SelectedValue == "D")
            {
                dt = ExporttoExcelData();
            }
            else if (ddlReportType.SelectedValue == "S")
            {
                dt = ReportData_ExcelSummary();
            }
            if (dt.Rows.Count > 0)
            {
                btnGenerateExcel.Enabled = true;
                btnExporttoPdf.Enabled = true;
                gvExportGrid.DataSource = dt;
                gvExportGrid.DataBind();
                if (BindHeader)
                {
                    GridViewRow additionalHeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

                    TableHeaderCell additionalHeaderCell = new TableHeaderCell();
                    additionalHeaderCell.Text = "<span id=\"additionalHeader\">Forecast Report from " + txtFromDate.Text + " to " + txtToDate.Text + " </span>";
                    additionalHeaderCell.ColumnSpan = dt.Columns.Count;
                    additionalHeaderRow.Cells.Add(additionalHeaderCell);
                    gvExportGrid.Controls[0].Controls.AddAt(0, additionalHeaderRow);
                }
                //gvSearch.Columns[0].Visible = false;
            }
            else
            {
                btnGenerateExcel.Enabled = false;
                btnExporttoPdf.Enabled = false;
                Utility.ShowMessage_Error(Page, "All Projects has been Released to Production. Please add new Projects !!");
                gvExportGrid.DataSource = "";
                gvExportGrid.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion
}