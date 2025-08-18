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
using iTextSharp.text.html.simpleparser;
using System.Configuration;

public partial class Reports_frmForecastingNew : System.Web.UI.Page
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
            GridViewHelper helper = new GridViewHelper(this.gvSearch);
            helper.RegisterGroup("Product", true, true);
            helper.GroupHeader += new GroupEvent(helper_GroupHeader);
            helper.GroupHeader += new GroupEvent(helper_Header);
            helper.GroupSummary += new GroupEvent(helper_Bug);
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
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlShop, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        if (groupName == "Product")
        {
            row.Cells[0].BackColor = Color.LightGray;
        }
    }

    private void helper_Footer(string groupName, object[] values, GridViewRow row)
    {
        if (groupName == "Product")
        {
            //row.Cells[0].Text = "$" + row.Cells[1].Text;
        }
    }

    private void helper_Bug(string groupName, object[] values, GridViewRow row)
    {
        if (groupName == null) return;
        row.Cells[0].BackColor = Color.Yellow;
        row.Cells[1].BackColor = Color.Yellow;
        row.Cells[0].Font.Bold = true;
        row.Cells[0].Font.Size = 12;
        row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
        row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
        row.Cells[1].Font.Bold = true;
        row.Cells[1].Font.Size = 12;
        row.Cells[0].Text = "[ Sub-Total for  " + values[0] + " ]";
        row.Cells[1].Text = "$" + row.Cells[1].Text;
    }

    private void helper_Header(string groupName, object[] values, GridViewRow row)
    {
        if (groupName == null) return;
        row.Cells[0].Font.Size = 14;
        row.Cells[0].Font.Bold = true;
        if (groupName != null)
        {
            int count = (int)ViewState["dtColumn"];
            row.Cells[0].ColumnSpan = count;
            row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }
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
                Qstr += " DECLARE @Columns NVARCHAR(MAX)='',  ";
                Qstr += "  @SqlStatement NVARCHAR(MAX)=''  ";
                Qstr += " SELECT @Columns += QUOTENAME(UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + ', '  + Inv_ProjectParts.projectid + ', '   +  ";
                Qstr += " ISNULL(tblCustomers.CompanyName,'')) )  + ', '  ";
                Qstr += " From Inv_Parts   LEFT JOIN Inv_ProjectParts ON Inv_ProjectParts.partid=Inv_Parts.id   ";
                Qstr += " LEFT JOIN tblProjects ON Inv_ProjectParts.projectid=tblProjects.JobID  LEFT JOIN tblCustomers ON tblCustomers.CustomerID=tblProjects.CustomerID   ";
                Qstr += " LEFT JOIN tblStates ON tblStates.StateID=tblCustomers.StateID   ";
                Qstr += " WHERE Inv_ProjectParts.qty IS NOT NULL  AND tblProjects.ProjectStatus NOT IN (2,3)  AND  ";
                Qstr += " tblProjects.ShipDate BETWEEN  '" + strDateFrom + "' AND '" + strDateTo + "'  ";
                if (ddlShop.SelectedIndex > 0)
                {
                    Qstr += " AND  tblProjects.MfgFacilityID=" + ddlShop.SelectedValue + " ";
                }
                if (ddlProduct.SelectedIndex > 0)
                {
                    Qstr += " AND  Inv_Parts.ProductId=" + ddlProduct.SelectedValue + " ";
                }
                Qstr += " GROUP BY UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + ', '  + Inv_ProjectParts.projectid + ', '   + ISNULL(tblCustomers.CompanyName,'')  )  ";
                Qstr += " if(@columns <>'')   begin SET @columns = LEFT(@columns, LEN(@columns) - 1);  ";
                Qstr += " SET @SqlStatement='  Select * from ( Select Inv_Product.Product, CASE WHEN min(Inv_Parts.PartStatus)=2 THEN  ''(Obsolete) '' +  MIN(Inv_Parts.PartNumber) +'' ''+  ";
                Qstr += " MIN(ISNULL(Inv_Parts.revisionno,'''')) ELSE MIN(Inv_Parts.PartNumber) +'' '' END  AS [Part Number],MIN(Inv_Parts.PartDes) AS [Part Des], ";
                Qstr += " MIN(Inv_Parts.PartImage) AS [Part Image__________], CASE WHEN MIN(convert(int, Inv_Parts.StockItem))=1 THEN ''Yes'' ELSE ''No'' END AS [Stock Item],MIN(Inv_Parts.stockinhand) AS [Stock In Hand],  ";
                Qstr += " MIN(UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + '', '' +  Inv_ProjectParts.projectid + '', ''  ";
                Qstr += " + ISNULL(tblCustomers.CompanyName,'''') ";
                Qstr += " )) AS [Project_Name],   ";
                Qstr += " MIN(Inv_ProjectParts.qty) as Qty  from Inv_Parts   ";
                Qstr += "  INNER JOIN Inv_Product ON Inv_Product.id=Inv_Parts.ProductId  ";
                Qstr += " LEFT JOIN Inv_ProjectParts ON Inv_ProjectParts.partid=Inv_Parts.id   ";
                Qstr += "  LEFT JOIN tblProjects ON Inv_ProjectParts.projectid=tblProjects.JobID  ";
                Qstr += " LEFT JOIN tblCustomers ON tblCustomers.CustomerID=tblProjects.CustomerID  ";
                Qstr += "  LEFT JOIN tblStates ON tblStates.StateID=tblCustomers.StateID  ";
                Qstr += "  WHERE Inv_ProjectParts.qty IS NOT NULL  AND tblProjects.ProjectStatus NOT IN (2,3)  AND Inv_Parts.StockItem=1 ";
                Qstr += " AND  tblProjects.ShipDate BETWEEN ''" + strDateFrom + "'' AND ''" + strDateTo + "'' ";
                //if (ddlShop.SelectedIndex > 0)
                //{                   
                //     Qstr += " AND  tblProjects.MfgFacilityID=" + ddlShop.SelectedValue + " ";                  
                //}
                if (ddlProduct.SelectedIndex > 0)
                {
                    Qstr += " AND  Inv_Parts.ProductId=" + ddlProduct.SelectedValue + " ";
                }
                Qstr += "  GROUP BY Inv_Product.Product,Inv_Parts.PartNumber,  UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + '',  '' + Inv_ProjectParts.projectid + '', '' +  ";
                Qstr += "  ISNULL(tblCustomers.CompanyName,'''') ";
                Qstr += "  )) AS  P  ";
                Qstr += "  PIVOT (SUM (Qty) FOR [Project_Name] IN (' + @Columns + ') ) AS PIVOT_TABLE order by Product,[Part Number], [Part Des],'  ";
                Qstr += "  + @Columns + '' EXEC sp_executesql @SqlStatement  END ";
                FQstr += Qstr;
                clscon.Return_DT(dt, FQstr);
                if (dt.Rows.Count > 0)
                {

                    ViewState["dtColumn"] = 0;
                    ViewState["dtColumn"] = dt.Columns.Count;
                    DataColumn Col = dt.Columns.Add("Total Quantity Required", typeof(int));
                    Col.SetOrdinal(6);// to put the column in position 0;                   
                                      //DataColumn Col1 = dt.Columns.Add("Closing Stock", typeof(int));
                                      //Col1.SetOrdinal(7);
                    foreach (DataRow row in dt.Rows)
                    {
                        int rowSum = 0;
                        int closestock = 0;
                        int opstock = 0;
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

                                if (col.ToString() != "Part Number")
                                {
                                    if (col.ToString() != "Min Qty")
                                    {
                                        if (col.ToString() != "Max Qty")
                                        {

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
                                                    //[Stock In Hand]
                                                    if (col.ToString() != "Stock In Hand")
                                                    {
                                                        string stringValue = row[col].ToString();
                                                        int d;
                                                        if (int.TryParse(stringValue, out d))
                                                            rowSum += d;
                                                        closestock = (opstock - rowSum);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        row.SetField("Total Quantity Required", rowSum);
                        //row.SetField("Closing Stock", closestock);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void BindGrid()
    {
        DataTable dt = (DataTable)ReportData();
        if (dt.Rows.Count > 0)
        {
            btnGenerateExcel.Enabled = true;
            btnExporttoPdf.Enabled = true;
            gvSearch.DataSource = dt;
            gvSearch.DataBind();
            //gvSearch.Columns[0].Visible = false;
        }
        else
        {
            btnGenerateExcel.Enabled = false;
            btnExporttoPdf.Enabled = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('All Projects has been Released to Production. Please add new Projects !!');", true);
            gvSearch.DataSource = "";
            gvSearch.DataBind();
        }
    }

    protected void btnGenrate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                BindGrid();
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

    private void GenrateReport_SecondExcel()
    {
        try
        {

            if (gvSearch.Rows.Count > 0)
            {
                Response.Buffer = true;
                string FileName = "Forecasing from " + txtFromDate.Text + " to " + txtToDate.Text + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    //To Export all pages.
                    gvSearch.AllowPaging = false;
                    BindGrid();
                    foreach (GridViewRow dr in gvSearch.Rows)
                    {
                        //dr["Part Number"] = "=\"" + dr["Part Number"] + "\"";
                        dr.Cells[0].Text = "=\"" + dr.Cells[0].Text + "\"";
                    }
                    GridViewRow Row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                    TableHeaderCell cell = new TableHeaderCell();
                    int count = (int)ViewState["dtColumn"];
                    cell.Text = "Forecasing from " + txtFromDate.Text + " to " + txtToDate.Text;
                    cell.ColumnSpan = count;
                    cell.Font.Size = 20;
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    //cell.BackColor = Color.DarkBlue;
                    //cell.ForeColor = Color.White;
                    Row.Controls.Add(cell);
                    gvSearch.HeaderRow.ForeColor = Color.White;
                    gvSearch.HeaderRow.Parent.Controls.AddAt(0, Row);
                    foreach (GridViewRow row in gvSearch.Rows)
                    {
                        row.Cells[3].Style.Add("width", "100");
                        row.Cells[3].Style.Add("Height", "110");
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                gvSearch.HeaderRow.Cells[i].Style.Add("background-color", "#0856A1");
                                if (i >= 4)
                                {
                                    row.Cells[i].HorizontalAlign = HorizontalAlign.Center;
                                    row.Cells[i].VerticalAlign = VerticalAlign.Top;
                                    row.Cells[i].Font.Size = 14;
                                }
                                else
                                {
                                    row.Cells[i].HorizontalAlign = HorizontalAlign.Left;
                                    row.Cells[i].VerticalAlign = VerticalAlign.Top;
                                }
                            }
                        }
                    }
                    gvSearch.RenderControl(hw);
                    //Style to format numbers to string.
                    string style = @"<style> .textmode { mso-number-format:\@; } </style> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }

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
            if (ddlShop.Items.Count > 0)
            {
                ddlShop.SelectedIndex = 0;
            }

            if (ddlProduct.Items.Count > 0)
            {
                ddlProduct.SelectedIndex = 0;
            }

            SetDate();
            gvSearch.DataSource = "";
            gvSearch.DataBind();
            divAerowerksForecastingReport.Attributes.Add("style", "display:block");
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
                gvSearch.Rows[i].Cells[0].Style.Add("Horizontal-align", "left");
                //row.Cells[i].HorizontalAlign = HorizontalAlign.Left;


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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string field2 = "";
                field2 = dr["Part Image__________"].ToString();
                string fullPath = Utility.PartImageForExport().Replace("~", "") + field2;
                FileInfo file = new FileInfo(Server.MapPath(fullPath));
                if (field2 != "" && file.Exists)
                {
                    var boundFields2 = e.Row.Cells.Cast<DataControlFieldCell>()
                    .Select(cell => cell.ContainingField).Cast<BoundField>().ToList();

                    int idx2 = boundFields2.IndexOf(
                        boundFields2.FirstOrDefault(f => f.DataField == "Part Image__________"));//../ImageHandler.ashx?imagePath=
                    e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<img height='100' width='100' src =\'" + ConfigurationManager.AppSettings["PartImage"] + fullPath + "'> " + "</img>");
                    //e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<img height='100' width='100' src =\'" + fullPath + "'> " + "</img>");
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
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {

                    if (i > 6)
                    {
                        string qty = e.Row.Cells[i].Text;
                        if (e.Row.Cells[i].Text != "&nbsp;")
                        {
                            e.Row.Cells[i].BackColor = System.Drawing.Color.Yellow;
                        }
                        //else
                        //{
                        //    e.Row.Cells[i].BackColor = System.Drawing.Color.SkyBlue;
                        //}

                    }
                    if (i == 0)
                    {
                        e.Row.Cells[i].Visible = false;
                    }
                    //if(i == 4)
                    //{
                    //    e.Row.Cells[i].Visible = false;
                    //}
                    //if (i == 5)
                    //{
                    //    e.Row.Cells[i].Visible = false;
                    //}
                    //if (i == 7)
                    //{
                    //    e.Row.Cells[i].Visible = false;
                    //}
                    //if (i == 8)
                    //{
                    //    e.Row.Cells[i].Visible = false;
                    //}
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Text = "<div class=\"verticalHeaderText\" style='writing-mode:vertical-rl; transform: rotate(180deg)'>" + e.Row.Cells[i].Text + "</div>";
                    //e.Row.Cells[i].Text = e.Row.Cells[i].Text;
                    //e.Row.Cells[0].Visible = false;
                    e.Row.Cells[0].Visible = false;
                    //e.Row.Cells[4].Visible = false;
                    //e.Row.Cells[5].Visible = false;
                    //e.Row.Cells[7].Visible = false;
                    //e.Row.Cells[8].Visible = false;
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
            gvSearch.AllowPaging = false;
            this.BindGrid();
            Response.ContentType = "application/pdf";
            string FileName = "Forecasing " + DateTime.Now.ToString("MM/dd/yyyy") + ".pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvSearch.RenderControl(hw);
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

    private DataTable ReportData_MonthlyReport()
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
                Qstr += " DECLARE @Columns NVARCHAR(MAX) = '', @SqlStatement NVARCHAR(MAX) = '' DECLARE @FromDate DATE = '" + strDateFrom + "'; DECLARE @ToDate DATE = '" + strDateTo + "'; ";
                Qstr += " ;WITH MonthList AS ( ";
                Qstr += " SELECT @FromDate AS MonthStart ";
                Qstr += " UNION ALL ";
                Qstr += " SELECT DATEADD(MONTH, 1, MonthStart) FROM MonthList ";
                Qstr += " WHERE DATEADD(MONTH, 1, MonthStart) <= @ToDate) ";
                Qstr += " SELECT  @Columns = STUFF(( ";
                Qstr += " SELECT ', ' + '[' + UPPER(DATENAME(MONTH, MonthStart) + ' ' + CAST(YEAR(MonthStart) AS VARCHAR(4))) + ']' ";
                Qstr += " FROM MonthList ";
                Qstr += " FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '')  ";
                Qstr += " OPTION (MAXRECURSION 0); ";
                Qstr += " SET @SqlStatement='  SELECT * FROM (Select UPPER(FORMAT(tblProjects.ShipDate, ''MMMM yyyy'')  ) AS [Ship_Date], Inv_Product.Product,  ";
                Qstr += " CASE WHEN min(Inv_Parts.PartStatus) = 2 THEN  ''(Obsolete) '' +  MIN(Inv_Parts.PartNumber) +'' ''+ MIN(ISNULL(Inv_Parts.revisionno,'''')) ELSE MIN(Inv_Parts.PartNumber) + '' '' END  AS [Part Number],  ";
                Qstr += " MIN(Inv_Parts.PartDes) AS [Part Des], MIN(Inv_Parts.PartImage) AS [Part Image], CASE WHEN MIN(CONVERT(int, Inv_Parts.StockItem))=1 THEN ''Yes'' ELSE ''No'' END AS [Stock Item],  ";
                Qstr += " MIN(Inv_Parts.stockinhand) AS [Stock In Hand], SUM(Inv_ProjectParts.qty) AS Qty ";
                Qstr += " FROM Inv_Parts ";
                Qstr += " INNER JOIN Inv_Product ON Inv_Product.id = Inv_Parts.ProductId ";
                Qstr += " LEFT JOIN Inv_ProjectParts ON Inv_ProjectParts.partid = Inv_Parts.id ";
                Qstr += " LEFT JOIN tblProjects ON Inv_ProjectParts.projectid = tblProjects.JobID ";
                Qstr += " LEFT JOIN tblCustomers ON tblCustomers.CustomerID = tblProjects.CustomerID ";
                Qstr += " LEFT JOIN tblStates ON tblStates.StateID = tblCustomers.StateID ";
                Qstr += " WHERE Inv_ProjectParts.qty IS NOT NULL  AND tblProjects.ProjectStatus NOT IN (2, 3)  AND Inv_Parts.StockItem = 1 ";
                Qstr += " AND tblProjects.ShipDate BETWEEN ''" + strDateFrom + "'' AND ''" + strDateTo + "'' ";
                if (ddlShop.SelectedIndex > 0)
                {
                    Qstr += " AND  tblProjects.MfgFacilityID = " + ddlShop.SelectedValue + " ";
                }
                if (ddlProduct.SelectedIndex > 0)
                {
                    Qstr += " AND  Inv_Parts.ProductId = " + ddlProduct.SelectedValue + " ";
                }
                Qstr += " GROUP BY Inv_Product.Product, Inv_Parts.PartNumber, UPPER(FORMAT(tblProjects.ShipDate, ''MMMM yyyy''))  ) AS P ";
                Qstr += " PIVOT (SUM(Qty) FOR Ship_Date IN (' + @Columns + ')) AS PIVOTT ORDER BY Product, [Part Number], [Part Des] ' ";
                Qstr += " EXEC sp_executesql @SqlStatement ";
                FQstr += Qstr;
                clscon.Return_DT(dt, FQstr);
                if (dt.Rows.Count > 0)
                {

                    ViewState["dtColumn"] = 0;
                    ViewState["dtColumn"] = dt.Columns.Count;
                    DataColumn Col = dt.Columns.Add("Total Quantity Required", typeof(int));
                    Col.SetOrdinal(6);// to put the column in position 0;                   
                                      //DataColumn Col1 = dt.Columns.Add("Closing Stock", typeof(int));
                                      //Col1.SetOrdinal(7);
                    foreach (DataRow row in dt.Rows)
                    {
                        int rowSum = 0;
                        int closestock = 0;
                        int opstock = 0;
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

                                if (col.ToString() != "Part Number")
                                {
                                    if (col.ToString() != "Min Qty")
                                    {
                                        if (col.ToString() != "Max Qty")
                                        {

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
                                                    //[Stock In Hand]
                                                    if (col.ToString() != "Stock In Hand")
                                                    {
                                                        string stringValue = row[col].ToString();
                                                        int d;
                                                        if (int.TryParse(stringValue, out d))
                                                            rowSum += d;
                                                        closestock = (opstock - rowSum);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        row.SetField("Total Quantity Required", rowSum);
                        //row.SetField("Closing Stock", closestock);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnMonthlyReport_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)ReportData_MonthlyReport();
            Response.Buffer = true;
            string FileName = "Forecasing from " + txtFromDate.Text + " to " + txtToDate.Text + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                //To Export all pages.
                gvMonthlyExportToExcel.AllowPaging = false;
                gvMonthlyExportToExcel.DataSource = dt;
                gvMonthlyExportToExcel.DataBind();
                foreach (GridViewRow dr in gvMonthlyExportToExcel.Rows)
                {
                    //dr["Part Number"] = "=\"" + dr["Part Number"] + "\"";
                    //dr.Cells[0].Text = "=\"" + dr.Cells[0].Text + "\"";
                    dr.Cells[1].Text = "=\"" + dr.Cells[1].Text + "\"";
                }
                GridViewRow Row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                TableHeaderCell cell = new TableHeaderCell();
                int count = (int)ViewState["dtColumn"];
                cell.Text = "Forecasing from " + txtFromDate.Text + " to " + txtToDate.Text;
                cell.ColumnSpan = count;
                cell.Font.Size = 20;
                cell.HorizontalAlign = HorizontalAlign.Left;
                //cell.BackColor = Color.DarkBlue;
                //cell.ForeColor = Color.White;
                Row.Controls.Add(cell);
                gvMonthlyExportToExcel.HeaderRow.ForeColor = Color.White;
                gvMonthlyExportToExcel.HeaderRow.Parent.Controls.AddAt(0, Row);
                foreach (GridViewRow row in gvMonthlyExportToExcel.Rows)
                {
                    row.Cells[3].Style.Add("width", "100");
                    row.Cells[3].Style.Add("Height", "110");
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            gvMonthlyExportToExcel.HeaderRow.Cells[i].Style.Add("background-color", "#0856A1");
                            if (i >= 4)
                            {
                                row.Cells[i].HorizontalAlign = HorizontalAlign.Center;
                                row.Cells[i].VerticalAlign = VerticalAlign.Top;
                                row.Cells[i].Font.Size = 14;
                            }
                            else
                            {
                                row.Cells[i].HorizontalAlign = HorizontalAlign.Left;
                                row.Cells[i].VerticalAlign = VerticalAlign.Top;
                            }
                        }
                    }
                }
                gvMonthlyExportToExcel.RenderControl(hw);
                //Style to format numbers to string.
                string style = @"<style> .textmode { mso-number-format:\@; } </style> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvMonthlyExportToExcel_DataBound(object sender, EventArgs e)
    {
        try
        {
            for (int i = gvMonthlyExportToExcel.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvMonthlyExportToExcel.Rows[i];
                GridViewRow previousRow = gvMonthlyExportToExcel.Rows[i - 1];
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
                gvMonthlyExportToExcel.Rows[i].Cells[0].Style.Add("vertical-align", "top");
                gvMonthlyExportToExcel.Rows[i].Cells[0].Style.Add("Horizontal-align", "left");
                //row.Cells[i].HorizontalAlign = HorizontalAlign.Left;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvMonthlyExportToExcel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string field2 = "";
                field2 = dr["Part Image"].ToString();
                string fullPath = Utility.PartImageForExport().Replace("~", "") + field2;
                FileInfo file = new FileInfo(Server.MapPath(fullPath));
                if (field2 != "" && file.Exists)
                {
                    var boundFields2 = e.Row.Cells.Cast<DataControlFieldCell>()
                    .Select(cell => cell.ContainingField).Cast<BoundField>().ToList();

                    int idx2 = boundFields2.IndexOf(
                        boundFields2.FirstOrDefault(f => f.DataField == "Part Image"));//../ImageHandler.ashx?imagePath=
                    e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<img height='100' width='100' src =\'" + ConfigurationManager.AppSettings["PartImage"] + fullPath + "'> " + "</img>");
                    //e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<img height='100' width='100' src =\'" + fullPath + "'> " + "</img>");
                    //e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<img height = '100px' width = '100px' src =\'" + e.Row.Cells[idx2].Text.Replace("~", "") + "'> " + "</img>");
                }
                else
                {
                    var boundFields2 = e.Row.Cells.Cast<DataControlFieldCell>()
                    .Select(cell => cell.ContainingField).Cast<BoundField>().ToList();

                    int idx2 = boundFields2.IndexOf(
                        boundFields2.FirstOrDefault(f => f.DataField == "Part Image"));
                    //e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<img height='100' width='100' src =\'" + ConfigurationManager.AppSettings["PartImage"] + e.Row.Cells[idx2].Text.Replace("~", "") + "'> " + "</img>");
                    e.Row.Cells[idx2].Text = HttpUtility.HtmlDecode("<p> " + "</p>");
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    #region Export To Excel
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
                Qstr += " DECLARE @Columns NVARCHAR(MAX)='',  ";
                Qstr += "  @SqlStatement NVARCHAR(MAX)=''  ";
                Qstr += " SELECT @Columns += QUOTENAME(UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + ', '  + Inv_ProjectParts.projectid + ', '   +  ";
                Qstr += " ISNULL(tblCustomers.CompanyName,'')) )  + ', '  ";
                Qstr += " From Inv_Parts   LEFT JOIN Inv_ProjectParts ON Inv_ProjectParts.partid=Inv_Parts.id   ";
                Qstr += " LEFT JOIN tblProjects ON Inv_ProjectParts.projectid=tblProjects.JobID  LEFT JOIN tblCustomers ON tblCustomers.CustomerID=tblProjects.CustomerID   ";
                Qstr += " LEFT JOIN tblStates ON tblStates.StateID=tblCustomers.StateID   ";
                Qstr += " WHERE Inv_ProjectParts.qty IS NOT NULL  AND tblProjects.ProjectStatus NOT IN (2,3)  AND  ";
                Qstr += " tblProjects.ShipDate BETWEEN  '" + strDateFrom + "' AND '" + strDateTo + "'  ";
                if (ddlShop.SelectedIndex > 0)
                {
                    Qstr += " AND  tblProjects.MfgFacilityID=" + ddlShop.SelectedValue + " ";
                }
                if (ddlProduct.SelectedIndex > 0)
                {
                    Qstr += " AND  Inv_Parts.ProductId=" + ddlProduct.SelectedValue + " ";
                }
                Qstr += " GROUP BY UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + ', '  + Inv_ProjectParts.projectid + ', '   + ISNULL(tblCustomers.CompanyName,'')  )  ";
                Qstr += " if(@columns <>'')   begin SET @columns = LEFT(@columns, LEN(@columns) - 1);  ";
                Qstr += " SET @SqlStatement='  Select * from ( Select Inv_Product.Product, CASE WHEN min(Inv_Parts.PartStatus)=2 THEN  ''(Obsolete) '' + ''`'' + MIN(Inv_Parts.PartNumber) +'' ''+  ";
                Qstr += " MIN(ISNULL(Inv_Parts.revisionno,'''')) ELSE ''`'' + MIN(Inv_Parts.PartNumber) +'' '' END  AS [Part Number],MIN(Inv_Parts.PartDes) AS [Part Des], ";
                Qstr += " CASE WHEN MIN(convert(int, Inv_Parts.StockItem))=1 THEN ''Yes'' ELSE ''No'' END AS [Stock Item],MIN(Inv_Parts.stockinhand) AS [Stock In Hand],  ";
                Qstr += " MIN(UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + '', '' +  Inv_ProjectParts.projectid + '', ''  ";
                Qstr += " + ISNULL(tblCustomers.CompanyName,'''') ";
                Qstr += " )) AS [Project_Name],   ";
                Qstr += " MIN(Inv_ProjectParts.qty) as Qty  from Inv_Parts   ";
                Qstr += "  INNER JOIN Inv_Product ON Inv_Product.id=Inv_Parts.ProductId  ";
                Qstr += " LEFT JOIN Inv_ProjectParts ON Inv_ProjectParts.partid=Inv_Parts.id   ";
                Qstr += "  LEFT JOIN tblProjects ON Inv_ProjectParts.projectid=tblProjects.JobID  ";
                Qstr += " LEFT JOIN tblCustomers ON tblCustomers.CustomerID=tblProjects.CustomerID  ";
                Qstr += "  LEFT JOIN tblStates ON tblStates.StateID=tblCustomers.StateID  ";
                Qstr += "  WHERE Inv_ProjectParts.qty IS NOT NULL  AND tblProjects.ProjectStatus NOT IN (2,3)  AND Inv_Parts.StockItem=1 ";
                Qstr += " AND  tblProjects.ShipDate BETWEEN ''" + strDateFrom + "'' AND ''" + strDateTo + "'' ";
                //if (ddlShop.SelectedIndex > 0)
                //{                   
                //     Qstr += " AND  tblProjects.MfgFacilityID=" + ddlShop.SelectedValue + " ";                  
                //}
                if (ddlProduct.SelectedIndex > 0)
                {
                    Qstr += " AND  Inv_Parts.ProductId=" + ddlProduct.SelectedValue + " ";
                }
                Qstr += "  GROUP BY Inv_Product.Product,Inv_Parts.PartNumber,  UPPER(CONVERT(VARCHAR, tblProjects.ShipDate,101) + '',  '' + Inv_ProjectParts.projectid + '', '' +  ";
                Qstr += "  ISNULL(tblCustomers.CompanyName,'''') ";
                Qstr += "  )) AS  P  ";
                Qstr += "  PIVOT (SUM (Qty) FOR [Project_Name] IN (' + @Columns + ') ) AS PIVOT_TABLE order by Product,[Part Number], [Part Des],'  ";
                Qstr += "  + @Columns + '' EXEC sp_executesql @SqlStatement  END ";
                FQstr += Qstr;
                clscon.Return_DT(dt, FQstr);
                if (dt.Rows.Count > 0)
                {

                    ViewState["dtColumn"] = 0;
                    ViewState["dtColumn"] = dt.Columns.Count;
                    DataColumn Col = dt.Columns.Add("Total Quantity Required", typeof(int));
                    Col.SetOrdinal(6);// to put the column in position 0;                   
                                      //DataColumn Col1 = dt.Columns.Add("Closing Stock", typeof(int));
                                      //Col1.SetOrdinal(7);
                    foreach (DataRow row in dt.Rows)
                    {
                        int rowSum = 0;
                        int closestock = 0;
                        int opstock = 0;
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

                                if (col.ToString() != "Part Number")
                                {
                                    if (col.ToString() != "Min Qty")
                                    {
                                        if (col.ToString() != "Max Qty")
                                        {

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
                                                    //[Stock In Hand]
                                                    if (col.ToString() != "Stock In Hand")
                                                    {
                                                        string stringValue = row[col].ToString();
                                                        int d;
                                                        if (int.TryParse(stringValue, out d))
                                                            rowSum += d;
                                                        closestock = (opstock - rowSum);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        row.SetField("Total Quantity Required", rowSum);
                        //row.SetField("Closing Stock", closestock);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void BindExporttoExcelGrid()
    {
        DataTable dt = (DataTable)ExporttoExcelData();
        if (dt.Rows.Count > 0)
        {
            btnGenerateExcel.Enabled = true;
            btnExporttoPdf.Enabled = true;
            gvSearchExportToExcel.DataSource = dt;
            gvSearchExportToExcel.DataBind();
            //gvSearch.Columns[0].Visible = false;
        }
        else
        {
            btnGenerateExcel.Enabled = false;
            btnExporttoPdf.Enabled = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('All Projects has been Released to Production. Please add new Projects !!');", true);
            gvSearchExportToExcel.DataSource = "";
            gvSearchExportToExcel.DataBind();
        }
    }

    protected void gvSearchExportToExcel_DataBound(object sender, EventArgs e)
    {
        try
        {
            for (int i = gvSearchExportToExcel.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvSearchExportToExcel.Rows[i];
                GridViewRow previousRow = gvSearchExportToExcel.Rows[i - 1];
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
                gvSearchExportToExcel.Rows[i].Cells[0].Style.Add("vertical-align", "top");
                gvSearchExportToExcel.Rows[i].Cells[0].Style.Add("Horizontal-align", "left");
                //row.Cells[i].HorizontalAlign = HorizontalAlign.Left;


            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSearchExportToExcel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {

                    if (i > 6)
                    {
                        string qty = e.Row.Cells[i].Text;
                        if (e.Row.Cells[i].Text != "&nbsp;")
                        {
                            e.Row.Cells[i].BackColor = System.Drawing.Color.Yellow;
                        }
                        //else
                        //{
                        //    e.Row.Cells[i].BackColor = System.Drawing.Color.SkyBlue;
                        //}

                    }
                    if (i == 0)
                    {
                        e.Row.Cells[i].Visible = false;
                    }

                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Text = "<div class=\"verticalHeaderText\" style='writing-mode:vertical-rl; transform: rotate(180deg)'>" + e.Row.Cells[i].Text + "</div>";
                    e.Row.Cells[0].Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion
}

//var selectedColumns = dt.Columns.Cast<DataColumn>().Take(8).ToList();
//dt.AsEnumerable()
//    .Where(row => row["Part Image"] != DBNull.Value)
//    .ToList()
//    .ForEach(row =>
//    {
//        string imageFileName = row["Part Image"].ToString();
//        string filePath = Path.Combine(ConfigurationManager.AppSettings["PartImage"], Server.MapPath(Utility.PartImageForExport().Replace("~", "") + imageFileName));
//        //string fullPath = ConfigurationManager.AppSettings["PartImage"] + Utility.PartImageForExport().Replace("~", "") + imageFileName;
//        row["Part Image"] = filePath;
//        //string filePath = Path.Combine(ConfigurationManager.AppSettings["PartImage"], Server.MapPath(Utility.PartImageForExport().Replace("~", "") + imageFileName));
//        ////string fullPath = ConfigurationManager.AppSettings["PartImage"] + Utility.PartImageForExport().Replace("~", "") + imageFileName;
//        //row["Part Image"] = filePath;
//    });
//DataTable dtSelectedColumns = dt.DefaultView.ToTable(false, selectedColumns.Select(c => c.ColumnName).ToArray());
//rprt.Load(Server.MapPath("~/Reports/rptForecastingNew.rpt"));
//if (dt.Rows.Count > 0)
//{
//    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
//    txtheader.Text = "Forecasting Report From " + txtFromDate.Text + " to " + txtToDate.Text;
//    //rprt.SetDataSource(dtSelectedColumns);
//    rprt.SetDataSource(dt);
//    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
//    rprt.Close();
//    rprt.Dispose();
//}
//}