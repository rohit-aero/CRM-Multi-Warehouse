using System;
using System.Data;
using System.Web.UI;
using System.Web.Services;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using OfficeOpenXml.Style;
using System.IO;
using System.Web;
using OfficeOpenXml;
using System.Linq;

public partial class Reports_frmDealerRebate : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                int Month = DateTime.Now.Month;
                int Year = DateTime.Now.Year - 1;
                txtFromDate.Text = "01" + "/01/" + Year;
                txtToDate.Text = "12/31/" + Year;
                BindDealers();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindDealers()
    {
        try
        {
            Utility.BindDropDownList(ddlCountry, Utility.GetCountries());
            Utility.BindDropDownListAll(ddlRebate, Utility.GetDealers());
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
            if (ddlReportType.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter To Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Report Type. !!");
                ddlReportType.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private Boolean ValidationCheckGovernmentSales()
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
            if (ddlRebate.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Dealer. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Dealer. !!");
                ddlRebate.Focus();
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
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            if (ddlRebate.SelectedValue == "0")
            {
                clscon.Return_DT(dt, "EXEC [dbo].[aero_ManageRebatesAll] '" + strDateFrom + "','" + strDateTo + "'");
            }
            else
            {
                clscon.Return_DT(dt, "EXEC [dbo].[aero_ManageRebates] '" + strDateFrom + "','" + strDateTo + "','" + ddlRebate.SelectedValue + "'");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }



    private void Get_DealersReport()
    {
        try
        {
            DataTable dt = ReportData();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            if (ddlReportType.SelectedValue == "1")
            {
                rprt.Load(Server.MapPath("~/Reports/rptDealersRebatesAll.rpt"));
            }
            else if(ddlReportType.SelectedValue == "2")
            {
                rprt.Load(Server.MapPath("~/Reports/rptDealersRebatesByDivision.rpt"));
            }
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                string DealerName = string.Empty;
                if (ddlRebate.SelectedValue == "1")
                {
                    DealerName = "Aramark";
                }
                else if (ddlRebate.SelectedIndex > 0)
                {
                    DealerName = ddlRebate.SelectedItem.Text.Replace(",", "");
                }
                else
                {
                    DealerName = "All";
                }
                txtheader.Text = DealerName + "\nSales Rebate Report From " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                string DealerName = string.Empty;
                if (ddlRebate.SelectedValue == "1")
                {
                    DealerName = "Aramark";
                }
                else if (ddlRebate.SelectedIndex > 0)
                {
                    DealerName = ddlRebate.SelectedItem.Text.Replace(",", "");
                }
                else
                {
                    DealerName = "All";
                }
                txtheader.Text = DealerName + "\nSales Rebate Report From " + strDateFrom + " to " + strDateTo;
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
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

    private void Get_DealersReport_Excel()
    {
        try
        {
            DataTable dt = ReportData();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            if (ddlRebate.SelectedValue == "0")
            {
                rprt.Load(Server.MapPath("~/Reports/rptDealersRebatesAll.rpt"));
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptDealersRebates.rpt"));
            }

            clscon.Return_DT(dt, "EXEC [dbo].[aero_ManageRebates] '" + strDateFrom + "','" + strDateTo + "','" + ddlRebate.SelectedValue + "'");
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlRebate.SelectedItem.Text + "\nSales Rebate Report From " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
                rprt.Close();
                rprt.Dispose();
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlRebate.SelectedItem.Text + "\nSales Rebate Report From " + strDateFrom + " to " + strDateTo;
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
    }


    private DataTable BindMainGrid()
    {
        DataTable dt = new DataTable();
        try
        {         
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            if(ddlRebate.SelectedValue == "0")
            {
                clscon.Return_DT(dt, "EXEC [dbo].[aero_ManageRebatesAll] '" + strDateFrom + "','" + strDateTo + "'");
            }
            else
            {
                clscon.Return_DT(dt, "EXEC [dbo].[aero_ManageRebates] '" + strDateFrom + "','" + strDateTo + "','" + ddlRebate.SelectedValue + "'");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void BindDynamicExcelQuarterlyReport()
    {
        try
        {
            DataTable orderedQuarterlyTable = new DataTable();
            orderedQuarterlyTable.Columns.Add("DateInvoiceSent", typeof(string));            
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = (DataTable)BindMainGrid();
            var distinctQuarterlyTable = Utility.GetDistinctColumnValues(dt, "DateInvoiceSent");
            string[] allQuarters = { "First Quarter", "Second Quarter", "Third Quarter", "Fourth Quarter" };
            foreach (var quarter in allQuarters)
            {
                var row = distinctQuarterlyTable.AsEnumerable()
                    .FirstOrDefault(r => r.Field<string>("DateInvoiceSent") == quarter);

                if (row != null)
                {
                    orderedQuarterlyTable.Rows.Add(quarter);
                }
            }
            gvQuarterly.DataSource = orderedQuarterlyTable;
            gvQuarterly.DataBind();
            foreach (GridViewRow row in gvQuarterly.Rows)
            {
                // Add filtered companies to a new DataTable
                DataTable companyTable = new DataTable();
                companyTable.Columns.Add("CompanyName", typeof(string));
                string QuarterlyFilter = (row.FindControl("lblQuarterName") as Label).Text;
                var filteredCompanies = dt.AsEnumerable()
                .Where(r => r.Field<string>("DateInvoiceSent") == QuarterlyFilter)
                .OrderBy(r => r.Field<string>("CompanyName"))
                .Select(r => r.Field<string>("CompanyName")).Distinct();
                foreach (var company in filteredCompanies)
                {
                    DataRow newRow = companyTable.NewRow();
                    newRow["CompanyName"] = company;
                    companyTable.Rows.Add(newRow);
                }
                GridView gvChild = row.FindControl("gvChildCompanyDetails") as GridView;
                if (companyTable.Rows.Count > 0)
                {
                    gvChild.DataSource = companyTable;
                    gvChild.DataBind();
                    foreach (GridViewRow rowDetails in gvChild.Rows)
                    {
                        string companyNameFilter = (rowDetails.FindControl("lblCompanyName") as Label).Text;
                        var filteredRecords = dt.AsEnumerable()
                        .Where(r => r.Field<string>("DateInvoiceSent") == QuarterlyFilter && r.Field<string>("CompanyName") == companyNameFilter)
                        .OrderBy(r => r.Field<string>("CompanyName"))
                        .Distinct();

                        DataTable filteredDataTable = dt.Clone(); // Clone the structure of the original table

                        foreach (var record in filteredRecords)
                        {
                            filteredDataTable.ImportRow(record);
                        }
                        GridView gvChildDetails = rowDetails.FindControl("gvChildGridDetails") as GridView;
                        if (filteredDataTable.Rows.Count > 0)
                        {
                            gvChildDetails.DataSource = filteredDataTable;
                            gvChildDetails.DataBind();
                        }
                    }
                }

            }
            ExportQuarterlyGridData(gvQuarterly);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    public void ExportQuarterlyGridData(GridView mainGridView)
    {
        try
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
                DateTime dtto = Convert.ToDateTime(txtToDate.Text);
                string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
                string strDateTo = dtto.ToString("MM/dd/yyyy");
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var workSheet = excel.Workbook.Worksheets.Add("Sales Rebate Report");
                string HeaderText = string.Empty;
                if (ddlRebate.SelectedValue == "1")
                {
                    HeaderText = "Aramark";
                }
                else if (ddlRebate.SelectedIndex > 0)
                {
                    HeaderText = ddlRebate.SelectedItem.Text.Replace(",", "");
                }
                else
                {
                    HeaderText = "All";
                }
                string FinalHeaderText = HeaderText + " Sales Rebate Report From " + strDateFrom + " to " + strDateTo;                
                string previousQuarterName = null;
                double[] subTotals = new double[5];
                double[] grandTotals = new double[5];
                int[] columns = { 9, 10, 11, 12, 13 };
                //int[] filteredColumns = columns.Where(column => column != 12).ToArray();
                Utility.SetCellValueAndStyle(workSheet, 1, 1, FinalHeaderText, true, 22, null, 0);
                string[] headers = { "Quarter","Company", "P.O. #", "Invoice Date", "Invoice Number", "Job #", "Project Name", "Ship Date", "Total Invoiced Sales", "Rebatable Sales", "Non-Rebatable Sales", "Rebate %", "Rebate" };
                Utility.AddHeaders(workSheet, headers);
                // Set column widths
                int[] columnWidths = { 15, 60, 15, 25, 25, 25, 60, 25, 20, 20, 20, 15, 20 };

                for (int i = 0; i < columnWidths.Length; i++)
                {
                    workSheet.Column(i + 1).Width = columnWidths[i];
                }
                int rowMain = 3;
                foreach (GridViewRow mainRow in mainGridView.Rows)
                {
                    string QuarterName = ((Label)mainRow.FindControl("lblQuarterName")).Text;
                    if (previousQuarterName != null && previousQuarterName != QuarterName)
                    {
                        workSheet.Cells[rowMain, 8].Value = "Sub-Total";
                        workSheet.Cells[rowMain, 8].Style.Font.Bold = true;                        
                        Utility.AddSubtotal(workSheet, rowMain, subTotals, columns);
                        rowMain++;
                    }
                    previousQuarterName = QuarterName;
                    workSheet.Cells[rowMain, 1].Value = QuarterName;
                    workSheet.Cells[rowMain, 1].Style.Font.Bold = true;
                    GridView childGridView = (GridView)mainRow.FindControl("gvChildCompanyDetails");
                    rowMain++;                   
                    foreach (GridViewRow childGridViewCompanyName in childGridView.Rows)
                    {
                        string CompanyName = ((Label)childGridViewCompanyName.FindControl("lblCompanyName")).Text;
                        workSheet.Cells[rowMain, 2].Value = CompanyName;
                        workSheet.Cells[rowMain, 2].Style.Font.Bold = true;
                        GridView childGridDetailsView = (GridView)childGridViewCompanyName.FindControl("gvChildGridDetails");
                        rowMain++;
                        foreach (GridViewRow childGridViewDetails in childGridDetailsView.Rows)
                        {
                            string PONumber = ((Label)childGridViewDetails.FindControl("lblPONumber")).Text;
                            string InvoiceDate = ((Label)childGridViewDetails.FindControl("lblInvoiceDate")).Text;
                            string InvoiceNo = ((Label)childGridViewDetails.FindControl("lblInvoiceNo")).Text;
                            string JobNumber = ((Label)childGridViewDetails.FindControl("lblJobNo")).Text;
                            string ProjectName = ((Label)childGridViewDetails.FindControl("lblProjectName")).Text;
                            string ShipDate = ((Label)childGridViewDetails.FindControl("lblShipDate")).Text;
                            double totalInvoicedSales = double.Parse(((Label)childGridViewDetails.FindControl("lblTotalInvoicedSales")).Text);
                            double rebatableSales = double.Parse(((Label)childGridViewDetails.FindControl("lblRebatableSales")).Text);
                            double nonRebatableSales = double.Parse(((Label)childGridViewDetails.FindControl("lblNonRebatableSales")).Text);
                            double rebatePer = double.Parse(((Label)childGridViewDetails.FindControl("lblRebatePer")).Text);
                            double rebateCalculate = double.Parse(((Label)childGridViewDetails.FindControl("lblRebateCalculate")).Text);

                            SetRowValuesAndStylesQuartelyBasis(workSheet, rowMain, PONumber, InvoiceDate, InvoiceNo, JobNumber, ProjectName, ShipDate, totalInvoicedSales, rebatableSales, nonRebatableSales, rebatePer, rebateCalculate);

                            // Update company totals
                            subTotals[0] += totalInvoicedSales;
                            subTotals[1] += rebatableSales;
                            subTotals[2] += nonRebatableSales;
                            //subTotals[3] = rebatePer;
                            subTotals[4] += rebateCalculate;

                            //Update Grand Total
                            grandTotals[0] += totalInvoicedSales;
                            grandTotals[1] += rebatableSales;
                            grandTotals[2] += nonRebatableSales;
                            //grandTotals[3] = rebatePer;
                            grandTotals[4] += rebateCalculate;
                            rowMain++;
                        }                                   
                    }
                }
                //// Add total row for the last company
                if (previousQuarterName != null)
                {
                    workSheet.Cells[rowMain, 8].Value = "Sub-Total";
                    workSheet.Cells[rowMain, 8].Style.Font.Bold = true;
                    Utility.AddSubtotal(workSheet, rowMain, subTotals, columns);
                    rowMain++;
                }

                workSheet.Cells[rowMain, 8].Value = "Grand Total";
                workSheet.Cells[rowMain, 8].Style.Font.Bold = true;                
                Utility.AddGrandtotal(workSheet, rowMain, grandTotals, columns);
                // Set the content type and filename
                var stream = new MemoryStream();
                excel.SaveAs(stream);
                var content = stream.ToArray();
                var fileName = ddlRebate.SelectedItem.Text + " Sales Rebate Report From_" + strDateFrom + "to_" + strDateTo + ".xlsx";

                // Send the file to the client
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
                HttpContext.Current.Response.BinaryWrite(content);
                HttpContext.Current.Response.End();
            }
        }
        catch (Exception ex)
        {
            if (ex.ToString() != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }

        }
    }
   
    private void BindDynamicExcelDivisionReport()
    {
        try
        {       
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = (DataTable)BindMainGrid();
            DataTable distinctCompanyNameTable =Utility.GetDistinctColumnValues(dt, "CompanyName");
            DataTable sortedTable = Utility.SortDataTable(distinctCompanyNameTable, "CompanyName");
            if (dt.Rows.Count > 0)
            {
                gvMainSalesRebateReport.DataSource = sortedTable;
                gvMainSalesRebateReport.DataBind();
                foreach (GridViewRow row in gvMainSalesRebateReport.Rows)
                {
                    string companyNameFilter = (row.FindControl("lblCompanyName") as Label).Text;
                    DataTable filteredDataTable = Utility.FilterDataTable(dt, "CompanyName", companyNameFilter);

                    GridView gvChildContainer = row.FindControl("gvChildSalesRebateDetails") as GridView;
                    if (filteredDataTable.Rows.Count > 0)
                    {
                        gvChildContainer.DataSource = filteredDataTable;
                        gvChildContainer.DataBind();
                    }
                    else
                    {
                        gvChildContainer.DataSource = null;
                        gvChildContainer.DataBind();
                    }
                }
                ExportNestedGridViewToExcel(gvMainSalesRebateReport);
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

    public void ExportNestedGridViewToExcel(GridView mainGridView)
    {
        try
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
                DateTime dtto = Convert.ToDateTime(txtToDate.Text);
                string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
                string strDateTo = dtto.ToString("MM/dd/yyyy");
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var workSheet = excel.Workbook.Worksheets.Add("Sales Rebate Report");
                string HeaderText = string.Empty;
                if (ddlRebate.SelectedValue == "1")
                {
                    HeaderText = "Aramark";
                }
                else if (ddlRebate.SelectedIndex > 0)
                {
                    HeaderText = ddlRebate.SelectedItem.Text.Replace(",", "");
                }
                else
                {
                    HeaderText = "All";
                }
                string FinalHeaderText = HeaderText + " Sales Rebate Report From " + strDateFrom + " to " + strDateTo;
                string previousCompanyName = null;
                double[] subTotals = new double[5];
                double[] grandTotals = new double[5];
                int[] columns = { 8, 9, 10, 11, 12 };
                Utility.SetCellValueAndStyle(workSheet, 1, 1, FinalHeaderText, true, 22,null,0);
                string[] headers = { "Company", "P.O. #", "Invoice Date", "Invoice Number", "Job #", "Project Name", "Ship Date", "Total Invoiced Sales", "Rebatable Sales", "Non-Rebatable Sales", "Rebate %", "Rebate" };
                Utility.AddHeaders(workSheet, headers);
                // Set column widths
                int[] columnWidths = { 60, 15, 25, 25, 25, 60, 25, 20, 20, 20, 15, 20 };
                
                for (int i = 0; i < columnWidths.Length; i++)
                {
                    workSheet.Column(i + 1).Width = columnWidths[i];
                }
                int rowMain = 3;                
                foreach (GridViewRow mainRow in mainGridView.Rows)
                {
                    string companyName = ((Label)mainRow.FindControl("lblCompanyName")).Text;
                    //// Add total row for the previous company
                    if (previousCompanyName != null && previousCompanyName != companyName)
                    {
                        workSheet.Cells[rowMain, 7].Value = "Sub-Total";
                        workSheet.Cells[rowMain, 7].Style.Font.Bold = true;
                        //int[] filteredColumns = columns.Where(column => column != 11).ToArray();
                        Utility.AddSubtotal(workSheet, rowMain, subTotals, columns);
                        rowMain++;
                    }
                    previousCompanyName = companyName;
                    workSheet.Cells[rowMain, 1].Value = companyName;
                    workSheet.Cells[rowMain, 1].Style.Font.Bold = true;
                    rowMain++;
                    GridView childGridView = (GridView)mainRow.FindControl("gvChildSalesRebateDetails");
                    foreach (GridViewRow childGridViewDetails in childGridView.Rows)
                    {
                        string PONumber = ((Label)childGridViewDetails.FindControl("lblPONumber")).Text;
                        string InvoiceDate = ((Label)childGridViewDetails.FindControl("lblInvoiceDate")).Text;
                        string InvoiceNo = ((Label)childGridViewDetails.FindControl("lblInvoiceNo")).Text;
                        string JobNumber = ((Label)childGridViewDetails.FindControl("lblJobNo")).Text;
                        string ProjectName = ((Label)childGridViewDetails.FindControl("lblProjectName")).Text;
                        string ShipDate = ((Label)childGridViewDetails.FindControl("lblShipDate")).Text;
                        double totalInvoicedSales = double.Parse(((Label)childGridViewDetails.FindControl("lblTotalInvoicedSales")).Text);
                        double rebatableSales = double.Parse(((Label)childGridViewDetails.FindControl("lblRebatableSales")).Text);
                        double nonRebatableSales = double.Parse(((Label)childGridViewDetails.FindControl("lblNonRebatableSales")).Text);
                        double rebatePer = double.Parse(((Label)childGridViewDetails.FindControl("lblRebatePer")).Text);
                        double rebateCalculate = double.Parse(((Label)childGridViewDetails.FindControl("lblRebateCalculate")).Text);

                        SetRowValuesAndStyles(workSheet, rowMain, PONumber, InvoiceDate, InvoiceNo, JobNumber, ProjectName, ShipDate, totalInvoicedSales, rebatableSales, nonRebatableSales, rebatePer, rebateCalculate);

                        // Update company totals
                        subTotals[0] += totalInvoicedSales;
                        subTotals[1] += rebatableSales;
                        subTotals[2] += nonRebatableSales;
                        //subTotals[3] = rebatePer;
                        subTotals[4] += rebateCalculate;

                        //Update Grand Total
                        grandTotals[0] += totalInvoicedSales;
                        grandTotals[1] += rebatableSales;
                        grandTotals[2] += nonRebatableSales;
                        //grandTotals[3] = rebatePer;
                        grandTotals[4] += rebateCalculate;
                        rowMain++;
                    }
                }

                //// Add total row for the last company
                if (previousCompanyName != null)
                {
                    workSheet.Cells[rowMain, 7].Value = "Sub-Total";
                    workSheet.Cells[rowMain, 7].Style.Font.Bold = true;
                    Utility.AddSubtotal(workSheet, rowMain, subTotals, columns);
                    rowMain++;
                }
                
                workSheet.Cells[rowMain, 7].Value = "Grand Total";
                workSheet.Cells[rowMain, 7].Style.Font.Bold = true;
                Utility.AddGrandtotal(workSheet, rowMain, grandTotals, columns);
                // Set the content type and filename
                var stream = new MemoryStream();
                excel.SaveAs(stream);
                var content = stream.ToArray();
                var fileName =ddlRebate.SelectedItem.Text + " Sales Rebate Report From_" + strDateFrom + "to_" + strDateTo + ".xlsx";

                // Send the file to the client
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
                HttpContext.Current.Response.BinaryWrite(content);
                HttpContext.Current.Response.End();
            }
        }
        catch (Exception ex)
        {
            if (ex.ToString() != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }

        }
    }   

    private void SetRowValuesAndStylesQuartelyBasis(ExcelWorksheet worksheet, int row, string col1, string col2, string col3, string col4, string col5, string col6, double col7, double col8, double col9, double col10, double col11)
    {
        try
        {
            Utility.SetCellValue(worksheet, row, 3, col1, null, null);
            Utility.SetCellValue(worksheet, row, 4, col2, null, null);
            Utility.SetCellValue(worksheet, row, 5, col3, null, null);
            Utility.SetCellValue(worksheet, row, 6, col4, null, null);
            Utility.SetCellValue(worksheet, row, 7, col5, null, null);
            Utility.SetCellValue(worksheet, row, 8, col6, null, null);
            Utility.SetCellValue(worksheet, row, 9, col7, "$#,##0.00", ExcelHorizontalAlignment.Right);
            Utility.SetCellValue(worksheet, row, 10, col8, "$#,##0.00", ExcelHorizontalAlignment.Right);
            Utility.SetCellValue(worksheet, row, 11, col9, "$#,##0.00", ExcelHorizontalAlignment.Right);
            Utility.SetCellValue(worksheet, row, 12, col10, null, ExcelHorizontalAlignment.Right);
            Utility.SetCellValue(worksheet, row, 13, col11, "$#,##0.00", ExcelHorizontalAlignment.Right);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void SetRowValuesAndStyles(ExcelWorksheet worksheet, int row, string col1, string col2, string col3, string col4, string col5, string col6, double col7, double col8, double col9, double col10, double col11)
    {
        try
        {
            Utility.SetCellValue(worksheet, row, 2, col1, null, null);
            Utility.SetCellValue(worksheet, row, 3, col2, null, null);
            Utility.SetCellValue(worksheet, row, 4, col3, null, null);
            Utility.SetCellValue(worksheet, row, 5, col4, null, null);
            Utility.SetCellValue(worksheet, row, 6, col5, null, null);
            Utility.SetCellValue(worksheet, row, 7, col6, null, null);
            Utility.SetCellValue(worksheet, row, 8, col7, "$#,##0.00", ExcelHorizontalAlignment.Right);
            Utility.SetCellValue(worksheet, row, 9, col8, "$#,##0.00", ExcelHorizontalAlignment.Right);
            Utility.SetCellValue(worksheet, row, 10, col9, "$#,##0.00", ExcelHorizontalAlignment.Right);
            Utility.SetCellValue(worksheet, row, 11, col10, null, ExcelHorizontalAlignment.Right);
            Utility.SetCellValue(worksheet, row, 12, col11, "$#,##0.00", ExcelHorizontalAlignment.Right);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
       
    }

    // Genrate report here
    protected void btnGenrate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                Get_DealersReport();
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
            //if (ddlRebate.SelectedValue == "779")
            //{
            //    Get_DealersReport_Excel();
            //}
            //else if (ddlRebate.SelectedValue == "3725")
            //{
            //    Get_DealersReport_Excel();
            //}
            //else if (ddlRebate.SelectedValue == "246")
            //{

            //}
            //Get_DealersReport_Excel();
            if(ValidationCheck() == true)
            {
                if (ddlReportType.SelectedValue == "2")
                {
                    BindDynamicExcelDivisionReport();
                }
                else if (ddlReportType.SelectedValue == "1")
                {
                    BindDynamicExcelQuarterlyReport();
                }
            }
             
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
            ddlRebate.SelectedIndex = 0;
            ddlReportType.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}