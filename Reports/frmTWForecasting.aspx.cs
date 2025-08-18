using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Reports_frmTWForecasting : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {           
        try
        {
            if (!IsPostBack)
            {
                
            }           
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
            gvSearch.Visible = true;
            string Qstr = String.Empty;
            string NQstr = String.Empty;
            string FQstr = String.Empty;
            Qstr += " DECLARE @Columns NVARCHAR(MAX)='',  @SqlStatement NVARCHAR(MAX)=''   ";
            Qstr += " SELECT @Columns += QUOTENAME(UPPER(TW_StockTransactions.JobID)) + ', ' ";
            Qstr += " FROM TW_Part  INNER JOIN TW_Category ON TW_Part.CategoryID=TW_Category.id ";
            Qstr += " INNER JOIN TW_Size ON TW_Size.ID=TW_Part.SizeID ";
            Qstr += " INNER JOIN TW_StockTransactions ON TW_StockTransactions.PartID=TW_Part.ID ";
            Qstr += " WHERE TW_StockTransactions.TransactQty<0 ";
            Qstr += " GROUP BY UPPER(TW_StockTransactions.JobID) ";
            Qstr += " if(@columns <>'')  ";
            Qstr += " begin SET @columns = LEFT(@columns, LEN(@columns) - 1);  ";
            Qstr += "  SET @SqlStatement='SELECT * FROM(SELECT PartNo as [Part No], TW_Category.[name] AS [Description], ";
            Qstr += " TW_Size.SizeName as [Size],UPPER(TW_StockTransactions.JobID) AS [Project_Name],ABS(TransactQty) as TransactQty ";
            Qstr += " FROM TW_Part  INNER JOIN TW_Category ON TW_Part.CategoryID=TW_Category.id ";
            Qstr += " INNER JOIN TW_Size ON TW_Size.ID=TW_Part.SizeID ";
            Qstr += " INNER JOIN TW_StockTransactions ON TW_StockTransactions.PartID=TW_Part.ID ";
            Qstr += " WHERE TW_StockTransactions.TransactQty<0  ";
            Qstr += " 	GROUP BY PartNo, TW_Category.[name],TW_Size.SizeName,TW_StockTransactions.JobID,TransactQty) AS P ";
            Qstr += " PIVOT (SUM(TransactQty) FOR [Project_Name] IN (' +  @Columns + '))  AS PIVOT_TABLE Order by [Description]  asc' ";
            Qstr += "  EXEC sp_executesql @SqlStatement  END  ";
            FQstr += Qstr;
            clscon.Return_DT(dt, FQstr);
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("Total", typeof(int));
                foreach (DataRow row in dt.Rows)
                {
                    int total = 0;
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName != "Part No" && col.ColumnName != "Description" && col.ColumnName != "Size")
                        {
                            if(row[col].ToString() != "")
                            total += Convert.ToInt32(row[col]);
                        }
                    }
                    row["Total"] = total;
                }
                //AddSumRowsToDataTable(dt);
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
        try
        {
            DataTable dt = (DataTable)ReportData();
            if (dt.Rows.Count > 0)
            {
                btnExportToExcel.Enabled = true;
                gvSearch.DataSource = dt;
                gvSearch.DataBind();
            }
            else
            {
                btnExportToExcel.Enabled = false;
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
            BindGrid();
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
            DataRow sumRow = dt.NewRow();
            int startingIndex = 3;
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

    protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Attributes.Add("style", "text-align:left;");                
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Text = "<div class=\"verticalHeaderText\" style='writing-mode:vertical-rl; transform: rotate(180deg)'>" + e.Row.Cells[i].Text + "</div>";
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Width = new Unit("150px");
                e.Row.Cells[0].Attributes.Add("style", "text-align:left;");                             
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
                gvSearch.Rows[i].Cells[cell].Style.Add("vertical-align", "middle");
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

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {          
            string filename = "Turbowash Forecasting " + DateTime.Now.ToString("MM/dd/yyyy") + ".xls";
            System.Web.HttpContext.Current.Response.Clear();
            gvSearch.AllowPaging = false;
            gvSearch.AllowSorting = false;            
            System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            System.Web.HttpContext.Current.Response.ContentType = ".xls";
            StringWriter StringWriter = new System.IO.StringWriter();
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

            // Write Excel file headers and formatting here...
            gvSearch.HeaderStyle.Reset();
            gvSearch.FooterStyle.Reset();
            gvSearch.RowStyle.Reset();
            gvSearch.GridLines = GridLines.Both;
            gvSearch.CssClass = "text";
            gvSearch.RenderControl(HtmlTextWriter);
            

            string style = @"<style> .textmode { mso-number-format:\@; } </style> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>";
            System.Web.HttpContext.Current.Response.Write(style);
            System.Web.HttpContext.Current.Response.Output.Write(StringWriter.ToString());
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
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
            btnExportToExcel.Enabled = false;
            gvSearch.DataSource = "";
            gvSearch.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}