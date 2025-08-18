using BLLAERO;
using BOLAERO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_FrmForecastingSubAssembly : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    BLLForecastingSubAssembly ObjBLL = new BLLForecastingSubAssembly();
    BOLForecastingSubParts ObjBOL = new BOLForecastingSubParts();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                SetDates();
                BindControls();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SetDates()
    {
        try
        {
            DateTime now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, 1);
            DateTime endDate = startDate.AddMonths(2).AddDays(-1);

            txtStartDate.Text = startDate.ToString("MM/dd/yyyy");
            txtEndDate.Text = endDate.ToString("MM/dd/yyyy");
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
            DataTable dt = new DataTable();
            ObjBOL.Operation = 1;
            dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProduct, dt);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationCheck()
    {
        try
        {
            if (txtStartDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Start Date!");
                txtStartDate.Focus();
                return false;
            }

            if (txtEndDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter End Date!");
                txtEndDate.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private DataTable ReportData_ForecastingMain()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "EXEC Get_Forecast_Summary '" + txtStartDate.Text + "', '" + txtEndDate.Text + "', ";
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

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidationCheck())
            {
                return;
            }
            DataTable dt = new DataTable();
            if (ddlReportType.SelectedValue == "A")
            {
                gvSearch.DataSource = dt;
                gvSearch.DataBind();
                gvSearch.Visible = false;
                gvSearchProject.Visible = true;
                dt = ReportData_ForecastingMain();
                if (dt.Rows.Count == 0)
                {
                    ResetGrid_Project();
                }
                else
                {
                    gvSearchProject.DataSource = dt;
                    gvSearchProject.DataBind();
                    btnExportToExcel.Enabled = true;
                    btnExportToPdf.Enabled = true;
                }
            }
            else if (ddlReportType.SelectedValue == "S")
            {
                gvSearchProject.DataSource = dt;
                gvSearchProject.DataBind();
                gvSearchProject.Visible = false;
                gvSearch.Visible = true;
                ObjBOL.Operation = 4;
                ObjBOL.Product = ddlProduct.SelectedIndex > 0 ? Int32.Parse(ddlProduct.SelectedValue) : 0;
                ObjBOL.StartDate = txtStartDate.Text;
                ObjBOL.EndDate = txtEndDate.Text;

                dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    ResetGrid_Search();
                }
                else
                {
                    BindDataToGridView(dt);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable AddSumRowsToDataTable(DataTable dt)
    {
        try
        {
            DataColumn sortOrderColumn = new DataColumn("SortOrder", typeof(int));
            dt.Columns.Add(sortOrderColumn);

            sortOrderColumn.SetOrdinal(0);

            var productGroups = dt.AsEnumerable().Select(r => r.Field<string>("Product")).Distinct();
            List<DataRow> sumRows = new List<DataRow>();
            Dictionary<int, object> grandTotals = new Dictionary<int, object>();
            int startingIndex = 5;

            foreach (string product in productGroups)
            {
                DataRow sumRow = dt.NewRow();
                sumRow["Product"] = product;
                sumRow[2] = "Sub-Total";
                sumRow["SortOrder"] = 1;
                for (int i = startingIndex; i < dt.Columns.Count; i++)
                {
                    object productTotal = dt.Compute("Sum([" + dt.Columns[i].ColumnName + "])", "[Product] = '" + product + "'");
                    sumRow[i] = productTotal;
                    if (grandTotals.ContainsKey(i))
                    {
                        decimal productTotal_Out = 0;
                        decimal grandTotal_Out = 0;
                        if (!decimal.TryParse(productTotal.ToString(), out productTotal_Out))
                        {
                            productTotal_Out = 0;
                        }
                        if (!decimal.TryParse(grandTotals[i].ToString(), out grandTotal_Out))
                        {
                            grandTotal_Out = 0;
                        }
                        grandTotals[i] = grandTotal_Out + productTotal_Out;
                    }
                    else
                    {
                        grandTotals[i] = productTotal;
                    }
                }
                sumRows.Add(sumRow);
            }

            foreach (DataRow row in sumRows)
            {
                dt.Rows.Add(row);
            }

            DataView dv = dt.DefaultView;
            dv.Sort = "Product asc, SortOrder asc";
            dt = dv.ToTable();

            DataRow grandTotalRow = dt.NewRow();
            grandTotalRow[2] = "Grand Total";
            for (int i = startingIndex; i < dt.Columns.Count; i++)
            {
                grandTotalRow[i] = grandTotals.ContainsKey(i) ? grandTotals[i] : DBNull.Value;
            }
            dt.Rows.Add(grandTotalRow);

            return dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void BindDataToGridView(DataTable dt)
    {
        try
        {
            gvSearch.DataSource = dt;
            gvSearch.DataBind();
            btnExportToExcel.Enabled = true;
            btnExportToPdf.Enabled = true;
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

    private void ResetGrid_Search()
    {
        try
        {
            gvSearch.DataSource = string.Empty;
            gvSearch.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetGrid_Project()
    {
        try
        {
            gvSearchProject.DataSource = string.Empty;
            gvSearchProject.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableControls()
    {
        try
        {
            btnExportToExcel.Enabled = false;
            btnExportToPdf.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            ResetGrid_Project();
            ResetGrid_Search();
            DisableControls();
            ddlProduct.SelectedIndex = 0;
            ddlReportType.SelectedValue = "A";
            SetDates();
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


            if (ddlReportType.SelectedValue == "A")
            {
                foreach (TableCell cell in gvSearchProject.HeaderRow.Cells)
                {
                    cell.BackColor = gvSearchProject.HeaderStyle.BackColor;
                }
            }
            else if (ddlReportType.SelectedValue == "S")
            {
                gvSearch.AllowPaging = false;
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
            }

            Response.ContentType = "application/pdf";
            string FileName = "Forecasting Sub-Assembly from " + txtStartDate.Text.Replace("/", "_") + " to " + txtEndDate.Text.Replace("/", "_") + ".pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            if (ddlReportType.SelectedValue == "A")
            {
                gvSearchProject.RenderControl(hw);
            }
            else if (ddlReportType.SelectedValue == "S")
            {
                gvSearch.RenderControl(hw);
            }

            //hw.Write("<div style='page-break-after: always;'></div>");
            //hw.Write("<br />");

            StringReader sr = new StringReader(sw.ToString());
            Document pdfDocument = new Document(PageSize.A3, 10, 10f, 10f, 10f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDocument);
            pdfDocument.SetPageSize(PageSize.A2.Rotate());
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

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Utility.ExportToExcel_TwoGrids(gvSearchProject, gvSearch, "Forecasting Sub-Assembly from " + txtStartDate.Text.Replace("/", "_") + " to " + txtEndDate.Text.Replace("/", "_"));
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSearchProject_DataBound(object sender, EventArgs e)
    {
        try
        {
            string maxWidthForFirstColumn = "100px";
            string maxWidthForSecondColumn = "80px";
            string maxWidthForThirdColumn = "300px";
            for (int i = gvSearchProject.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvSearchProject.Rows[i];
                GridViewRow previousRow = gvSearchProject.Rows[i - 1];
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
                gvSearchProject.Rows[i].Cells[0].Style.Add("vertical-align", "top");
                gvSearchProject.Rows[i].Cells[0].Style.Add("width", maxWidthForFirstColumn);
                gvSearchProject.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Left;
                gvSearchProject.Rows[i].Cells[1].Style.Add("width", maxWidthForSecondColumn);
                gvSearchProject.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Left;
                gvSearchProject.Rows[i].Cells[2].Style.Add("width", maxWidthForThirdColumn);
                gvSearchProject.Rows[i].Cells[2].HorizontalAlign = HorizontalAlign.Left;
                // gvSearch.Rows[i].Cells[0].CssClass = "locked";

            }
            gvSearchProject.Rows[0].Cells[0].Style.Add("vertical-align", "top");
            gvSearchProject.Rows[0].Cells[0].Style.Add("width", maxWidthForFirstColumn);
            gvSearchProject.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
            gvSearchProject.Rows[0].Cells[1].HorizontalAlign = HorizontalAlign.Left;
            gvSearchProject.Rows[0].Cells[1].Style.Add("width", maxWidthForSecondColumn);
            gvSearchProject.Rows[0].Cells[2].HorizontalAlign = HorizontalAlign.Left;
            gvSearchProject.Rows[0].Cells[2].Style.Add("width", maxWidthForThirdColumn);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSearchProject_RowDataBound(object sender, GridViewRowEventArgs e)
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
                }
            }
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
            int cell = 0;
            for (int i = gvSearch.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvSearch.Rows[i];
                GridViewRow previousRow = gvSearch.Rows[i - 1];
                for (int j = 0; j < row.Cells.Count; j++)
                {
                    if (row.Cells[cell].Text == previousRow.Cells[cell].Text)
                    {
                        if (previousRow.Cells[cell].RowSpan == 0)
                        {
                            if (row.Cells[cell].RowSpan == 0)
                            {
                                previousRow.Cells[cell].RowSpan += 2;
                            }
                            else
                            {
                                previousRow.Cells[cell].RowSpan = row.Cells[cell].RowSpan + 1;
                            }
                            row.Cells[cell].Visible = false;
                        }
                    }
                }
                gvSearch.Rows[i].Cells[cell].Style.Add("vertical-align", "top");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        //{
        //    e.Row.Cells[0].Visible = false;
        //}

        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[1].Attributes.Add("style", "text-align:left;");
            e.Row.Cells[2].Attributes.Add("style", "text-align:left;");
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
            for (int i = 3; i < e.Row.Cells.Count; i++)
            {
                TableCell cell = e.Row.Cells[i];

                bool isText = !string.IsNullOrEmpty(cell.Text.Trim());

                double number;
                if (double.TryParse(cell.Text, out number))
                {
                    cell.HorizontalAlign = HorizontalAlign.Center;
                }
                else
                {
                    cell.HorizontalAlign = HorizontalAlign.Left;
                }
            }

            if (e.Row.Cells[2].Text == "Sub-Total" || e.Row.Cells[2].Text == "Grand Total")
            {
                e.Row.Font.Bold = true;
                //e.Row.Visible = false;
            }
        }
    }
}