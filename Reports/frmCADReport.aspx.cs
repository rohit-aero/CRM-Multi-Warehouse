using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_frmCADReport : System.Web.UI.Page
{
    BLLDailyCADReport ObjBLL = new BLLDailyCADReport();
    BOLDailyCADReport ObjBOL = new BOLDailyCADReport();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
        }
    }

    #region Bind Functions

    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControls(ObjBOL);

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlNatureOfTaskList, ds.Tables[2]);
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlStatusList, ds.Tables[3]);
            }

            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectEngineer, ds.Tables[4]);
            }

            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectList, ds.Tables[5]);
            }

            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectManagerList, ds.Tables[6]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Event Handler Functions

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        btnExportToExcel.Enabled = true;
        btnExportToPDF.Enabled = true;
        GenerateReport();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Reset();
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int status = Int32.Parse(DataBinder.Eval(e.Row.DataItem, "StatusID").ToString());
            ObjBOL.Operation = 12;
            ObjBOL.ID = status;
            string color = ObjBLL.SaveAndUpdate(ObjBOL);
            e.Row.Attributes["style"] = "background-color: " + color + " !important;";
            foreach (TableCell cell in e.Row.Cells)
            {
                cell.Attributes["style"] = "border: 1px solid black !important;";
            }
        }
    }

    protected void btnGenerateExcel(object sender, EventArgs e)
    {
        string FileName = "Daily CAD Report";
        gvDailyProjectReport.Attributes.Remove("class");
        Utility.ExportToExcelGrid(gvDailyProjectReport, FileName);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    #endregion

    #region Report   

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            DataSet ds = new DataSet();
            if (ddlProjectManagerList.SelectedIndex > 0)
            {
                ObjBOL.ID = Convert.ToInt32(ddlProjectManagerList.SelectedValue);
            }
            if (ddlProjectEngineer.SelectedIndex > 0)
            {
                ObjBOL.ProjectEngineerID = Convert.ToInt32(ddlProjectEngineer.SelectedValue);
            }
            if (ddlProjectList.SelectedIndex > 0)
            {
                ObjBOL.PNumber = ddlProjectList.SelectedValue;
            }
            if (ddlNatureOfTaskList.SelectedIndex > 0)
            {
                ObjBOL.NatureID = Convert.ToInt32(ddlNatureOfTaskList.SelectedValue);
            }
            if (ddlStatusList.SelectedIndex > 0)
            {
                ObjBOL.StatusID = Convert.ToInt32(ddlStatusList.SelectedValue);
            }
            ds = ObjBLL.BindReport(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenerateReport()
    {
        try
        {
            DataTable dt = ReportData();
            if (dt.Rows.Count > 0)
            {
                lblRecordsCount.Text = "Total No. of Records: " + dt.Rows.Count.ToString();
                lblRecordsCount.Visible = true;
                gvDailyProjectReport.DataSource = dt;
                gvDailyProjectReport.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Reset

    private void Reset()
    {
        try
        {
            txtReportDateFrom.Text = string.Empty;
            txtReportDateTo.Text = string.Empty;
            ddlNatureOfTaskList.SelectedIndex = 0;
            ddlProjectList.SelectedIndex = 0;
            ddlProjectManagerList.SelectedIndex = 0;
            ddlProjectEngineer.SelectedIndex = 0;
            ddlStatusList.SelectedIndex = 0;
            lblRecordsCount.Visible = false;
            btnExportToExcel.Enabled = false;
            btnExportToPDF.Enabled = false;
            lblRecordsCount.Text = "";
            gvDailyProjectReport.DataSource = "";
            gvDailyProjectReport.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    protected void btnExportToPDF_Click(object sender, EventArgs e)
    {
        try
        {
            Response.ContentType = "application/pdf";
            string fullnam = "Daily Project Report - CAD Drawings-" + DateTime.Now.ToLongDateString() + ".pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=Daily CAD Report.pdf");
            Response.AddHeader("content-disposition", "attachment;filename=" + fullnam.Replace(",", ""));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Document pdfDoc = new Document(PageSize.A2, 2f, 2f, 5f, 0f);
            PdfPTable table = new PdfPTable(gvDailyProjectReport.Columns.Count - 1);
            table.WidthPercentage = 100;
            PdfPCell headerCell = new PdfPCell(new Phrase(DateTime.Now.ToLongDateString()));
            headerCell.Colspan = gvDailyProjectReport.Columns.Count - 1;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            // Add the additional header cell to the table
            table.AddCell(headerCell);
            float[] widths = new float[gvDailyProjectReport.Columns.Count - 1];
            for (int i = 0; i < widths.Length; i++)
            {
                if (i == 0 || i == 1 || i == 4 || i == 5 || i == 8 || i == widths.Length - 1)
                {
                    widths[i] = 5f;
                }
                else if (i == 2)
                {
                    widths[i] = 7f;
                }
                else
                {
                    widths[i] = 2f;
                }
            }
            table.SetWidths(widths);
            for (int i = 0; i < gvDailyProjectReport.HeaderRow.Cells.Count; i++)
            {
                if (i != 1)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(gvDailyProjectReport.HeaderRow.Cells[i].Text));
                    table.AddCell(pdfCell);
                }
            }
            foreach (GridViewRow row in gvDailyProjectReport.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (i != 1)
                    {
                        if (row.Cells[i].Controls.Count > 0)
                        {
                            foreach (Control control in row.Cells[i].Controls)
                            {
                                if (control is Label)
                                {
                                    PdfPCell pdfCell = new PdfPCell(new Phrase(((Label)control).Text));
                                    string style = row.Attributes["style"];
                                    string colorCode = System.Text.RegularExpressions.Regex.Match(style, "#[a-fA-F0-9]{6}").Value;
                                    pdfCell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml(colorCode));
                                    table.AddCell(pdfCell);
                                }
                            }
                        }
                        else
                        {
                            PdfPCell pdfCell = new PdfPCell(new Phrase(row.Cells[i].Text));
                            string colorCode = row.Attributes["style"];
                            pdfCell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml(colorCode));
                            table.AddCell(pdfCell);
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

    protected void gvDailyProjectReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = DateTime.Now.ToLongDateString();
                HeaderCell.ColumnSpan = 11;
                HeaderGridRow.Cells.Add(HeaderCell);
                HeaderGridRow.HorizontalAlign = HorizontalAlign.Center;
                HeaderGridRow.BackColor = Color.Green;
                this.gvDailyProjectReport.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}