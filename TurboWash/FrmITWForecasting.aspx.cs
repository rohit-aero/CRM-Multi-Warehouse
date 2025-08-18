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

public partial class TurboWash_FrmITWForecasting : System.Web.UI.Page
{
    commonclass1 cls = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
            SetDates();
        }
    }

    private void SetDates()
    {
        try
        {
            DateTime now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, 1);
            DateTime endDate = startDate.AddMonths(2).AddDays(-1);

            txtFromDate.Text = startDate.ToString("MM/dd/yyyy");
            txtToDate.Text = endDate.ToString("MM/dd/yyyy");
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
            cls.Return_DT(dt, "EXEC [TW_Forecasting] 1");
            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlCategory, dt);
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
            if (txtFromDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter From Date!");
                txtFromDate.Focus();
                return false;
            }

            if (txtToDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter To Date!");
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

    private DataTable ReportDataDetail()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "EXEC [TW_Forecasting] 2, '" + txtFromDate.Text + "', '" + txtToDate.Text + "', ";
            if (ddlCategory.SelectedIndex > 0)
            {
                query += ddlCategory.SelectedValue + " ";
            }
            else
            {
                query += " NULL ";
            }
            cls.Return_DT(dt, query);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportDataSummary()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "EXEC [TW_Forecasting] 3, '" + txtFromDate.Text + "', '" + txtToDate.Text + "', ";
            if (ddlCategory.SelectedIndex > 0)
            {
                query += ddlCategory.SelectedValue + " ";
            }
            else
            {
                query += " NULL ";
            }
            cls.Return_DT(dt, query);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnGenrate_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            if (ddlReportType.SelectedValue == "D")
            {
                dt = ReportDataDetail();
            }
            else
            {
                dt = ReportDataSummary();
            }
            gvSearch.DataSource = dt;
            gvSearch.DataBind();
            btnExporttoPdf.Enabled = true;
            btnGenerateExcel.Enabled = true;
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

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    protected void btnGenerateExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Utility.ExportToExcelGrid(gvSearch, "ITW Forecasting from " + txtFromDate.Text.Replace("/", "_") + " to " + txtToDate.Text.Replace("/", "_"));
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
            SetDates();
            ddlCategory.SelectedIndex = 0;
            ddlReportType.SelectedValue = "D";
            gvSearch.DataSource = string.Empty;
            gvSearch.DataBind();
            btnExporttoPdf.Enabled = false;
            btnGenerateExcel.Enabled = false;
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
            if (gvSearch.Rows.Count > 0)
            {
                string maxWidthForFirstColumn = "200px";
                string maxWidthForSecondColumn = "200px";
                string maxWidthForThirdColumn = "200px";
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

                    gvSearch.Rows[i].Cells[0].Style.Add("vertical-align", "top");
                    gvSearch.Rows[i].Cells[0].Style.Add("width", maxWidthForFirstColumn);
                    gvSearch.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Left;
                    gvSearch.Rows[i].Cells[1].Style.Add("width", maxWidthForSecondColumn);
                    gvSearch.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Left;
                    gvSearch.Rows[i].Cells[2].Style.Add("width", maxWidthForThirdColumn);
                    gvSearch.Rows[i].Cells[2].HorizontalAlign = HorizontalAlign.Left;
                }
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
}