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

public partial class Reports_frmForecastingSubParts : System.Web.UI.Page
{
    BLLForecastingSubParts ObjBLL = new BLLForecastingSubParts();
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

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidationCheck())
            {
                return;
            }
            bool checkIfFirstGridIsEmpty = false;
            ObjBOL.Operation = 2;
            ObjBOL.Product = ddlProduct.SelectedIndex > 0 ? Int32.Parse(ddlProduct.SelectedValue) : 0;
            ObjBOL.StartDate = txtStartDate.Text;
            ObjBOL.EndDate = txtEndDate.Text;

            DataTable dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
            DataTable dt1 = new DataTable();
            if (dt.Rows.Count == 0)
            {
                ResetGrid_Search();
                checkIfFirstGridIsEmpty = true;
            }
            else
            {
                dt1 = AddSumRowsToDataTable(dt);
                BindDataToGridView(dt1);
            }

            ObjBOL.Operation = 3;
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);

            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            else
            {
                dt = new DataTable();
            }

            if (dt.Rows.Count == 0)
            {
                ResetGrid_Project();
                if (checkIfFirstGridIsEmpty)
                {
                    DisableControls();
                }
            }
            else
            {
                dt1 = AddSumRowsToDataTableProject(dt);
                BindDataToGridViewProject(dt1);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable AddSumRowsToDataTable(DataTable dt)
    {
        //try
        //{
        //    DataColumn sortOrderColumn = new DataColumn("SortOrder", typeof(int));
        //    dt.Columns.Add(sortOrderColumn);

        //    sortOrderColumn.SetOrdinal(0);

        //    var productGroups = dt.AsEnumerable().Select(r => r.Field<string>("Product")).Distinct();
        //    List<DataRow> sumRows = new List<DataRow>();
        //    Dictionary<int, object> grandTotals = new Dictionary<int, object>();
        //    int startingIndex = 5;

        //    foreach (string product in productGroups)
        //    {
        //        DataRow sumRow = dt.NewRow();
        //        sumRow["Product"] = product;
        //        sumRow[2] = "Sub-Total";
        //        sumRow["SortOrder"] = 1;
        //        for (int i = startingIndex; i < dt.Columns.Count; i++)
        //        {
        //            object productTotal = dt.Compute("Sum([" + dt.Columns[i].ColumnName + "])", "[Product] = '" + product + "'");
        //            sumRow[i] = productTotal;
        //            if (grandTotals.ContainsKey(i))
        //            {
        //                grandTotals[i] = Convert.ToDecimal(grandTotals[i]) + Convert.ToDecimal(productTotal);
        //            }
        //            else
        //            {
        //                grandTotals[i] = productTotal;
        //            }
        //        }
        //        sumRows.Add(sumRow);
        //    }

        //    foreach (DataRow row in sumRows)
        //    {
        //        dt.Rows.Add(row);
        //    }

        //    DataView dv = dt.DefaultView;
        //    dv.Sort = "Product asc, SortOrder asc";
        //    dt = dv.ToTable();

        //    DataRow grandTotalRow = dt.NewRow();
        //    grandTotalRow[2] = "Grand Total";
        //    for (int i = startingIndex; i < dt.Columns.Count; i++)
        //    {
        //        grandTotalRow[i] = grandTotals.ContainsKey(i) ? grandTotals[i] : DBNull.Value;
        //    }
        //    dt.Rows.Add(grandTotalRow);

        //    return dt;
        //}
        //catch (Exception ex)
        //{
        //    Utility.AddEditException(ex);
        //}
        return dt;
    }

    private DataTable AddSumRowsToDataTableProject(DataTable dt)
    {
        try
        {            
            DataRow sumRow =dt.NewRow();
            int startingIndex = 1;
            sumRow[0] = "Grand Total";
            for (int i = startingIndex; i < dt.Columns.Count; i++)
            {
                object total = dt.Compute("Sum([" + dt.Columns[i].ColumnName + "])", "");
                sumRow[i] = total;               
            }           

            dt.Rows.Add(sumRow);

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

    private void BindDataToGridViewProject(DataTable dt)
    {
        try
        {
            gvSearchProject.DataSource = dt;
            gvSearchProject.DataBind();
            btnExportToExcel.Enabled = true;
            btnExportToPdf.Enabled = true;
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
            SetDates();
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

    protected void gvSearchProject_DataBound(object sender, EventArgs e)
    {
        try
        {
            int cell = 0;
            for (int i = gvSearchProject.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvSearchProject.Rows[i];
                GridViewRow previousRow = gvSearchProject.Rows[i - 1];
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
                gvSearchProject.Rows[i].Cells[cell].Style.Add("vertical-align", "top");
            }
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
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Attributes.Add("style", "text-align:left;");
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell cell in e.Row.Cells)
                {
                    // Check if the content in the cell is a string (text)
                    bool isText = !string.IsNullOrEmpty(cell.Text.Trim());

                    // Try to parse the content as a number
                    double number;
                    if (double.TryParse(cell.Text, out number))
                    {
                        cell.HorizontalAlign = HorizontalAlign.Center;
                    }
                    else
                    {
                        // If parsing fails, treat it as text (left-align)
                        cell.HorizontalAlign = HorizontalAlign.Left;
                    }
                }

                if (e.Row.Cells[0].Text == "Grand Total")
                {
                    e.Row.Font.Bold = true;
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
            int cell = 1;
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
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[2].Attributes.Add("style", "text-align:left;");
            e.Row.Cells[3].Attributes.Add("style", "text-align:left;");
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
            for (int i = 3; i < e.Row.Cells.Count; i++)
            {
                TableCell cell = e.Row.Cells[i];

                // Check if the content in the cell is a string (text)
                bool isText = !string.IsNullOrEmpty(cell.Text.Trim());

                // Try to parse the content as a number
                double number;
                if (double.TryParse(cell.Text, out number))
                {
                    cell.HorizontalAlign = HorizontalAlign.Center;
                }
                else
                {
                    // If parsing fails, treat it as text (left-align)
                    cell.HorizontalAlign = HorizontalAlign.Left;
                }
            }

            if (e.Row.Cells[2].Text == "Sub-Total" || e.Row.Cells[2].Text == "Grand Total")
            {
                e.Row.Font.Bold = true;
            }
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

    protected void btnExportToPdf_Click(object sender, EventArgs e)
    {
        try
        {
            gvSearch.AllowPaging = false;
            gvSearch.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gvSearch.HeaderRow.Cells)
            {
                cell.BackColor = gvSearch.HeaderStyle.BackColor;
            }

            foreach (TableCell cell in gvSearchProject.HeaderRow.Cells)
            {
                cell.BackColor = gvSearchProject.HeaderStyle.BackColor;
            }

            foreach (GridViewRow row in gvSearch.Rows)
            {
                row.Cells[3].Style.Add("width", "50");
                row.Cells[3].Style.Add("Height", "50");
            }
            Response.ContentType = "application/pdf";
            string FileName = "Forecasting Sub-Assembly from " + txtStartDate.Text.Replace("/", "_") + " to " + txtEndDate.Text.Replace("/", "_") + ".pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvSearchProject.RenderControl(hw);
            hw.Write("<div style='page-break-after: always;'></div>");
            hw.Write("<br />");
            gvSearch.RenderControl(hw);
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
}