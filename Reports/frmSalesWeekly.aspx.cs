using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using BOLAERO;
using BLLAERO;
using System.Web;
using System.IO;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using iTextSharp.text;
using System.Linq;

public partial class Reports_frmSalesWeekly : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    BOLManageProjects ObjBOL = new BOLManageProjects();
    BLLManageProjectsEng ObjBLL = new BLLManageProjectsEng();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                if (!IsPostBack)
                {
                    BindControls();
                    CheckEmployees();
                    int Month = DateTime.Now.Month + 2;
                    txtFromDate.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
                    txtToDate.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
                }
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void CheckEmployees()
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 11;
            ObjBOL.UserID = Utility.GetCurrentSession().EmployeeID;
            msg = ObjBLL.CheckEmployeeLogin(ObjBOL);
            if (msg == "1")
            {
                btnDownloadCombinedPlanView.Enabled = true;
            }
            else
            {
                btnDownloadCombinedPlanView.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnDownloadCombinedPlanView_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
                DateTime dtto = Convert.ToDateTime(txtToDate.Text);
                string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
                string strDateTo = dtto.ToString("MM/dd/yyyy");
                DataTable dt = new DataTable();
                dt = ReportData();
                string folderPath = Utility.PlanViewPath();
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                List<string> fileNames = new List<string>();
                fileNames = dt.AsEnumerable()
                .Select(row => row["filepath"])
                .Where(filePaths => filePaths != null && filePaths.ToString() != "")
                .SelectMany(filePaths => filePaths.ToString().Split(','))
                .Distinct()
                .ToList();
                if (fileNames.Count > 0)
                {
                    CombinePdfs(folderPath, fileNames, strDateFrom, strDateTo);
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "No Plan View Added");
                }
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

    private void BindControls()
    {
        DataTable dt = new DataTable();
        clscon.Return_DT(dt, "SELECT ID,FacilityName FROM tblMfgFacility ORDER BY FacilityName ");
        Utility.BindDropDownListAll(ddlShop, dt);
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
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            if (ddlShop.SelectedIndex == 0)
            {
                clscon.Return_DT(dt, "EXEC [dbo].[Get_SalesWeekly] '" + strDateFrom + "','" + strDateTo + "',0 ");
            }
            else
            {
                clscon.Return_DT(dt, "EXEC [dbo].[Get_SalesWeekly] '" + strDateFrom + "','" + strDateTo + "'," + ddlShop.SelectedValue + " ");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport()
    {
        try
        {
            string HeaderText = string.Empty;
            DataTable dt = ReportData();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            var reportType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            if (ddlShop.SelectedIndex == 0 && ddlReportType.SelectedValue == "1")
            {
                rprt.Load(Server.MapPath("~/Reports/rptSalesWeekly.rpt"));
                HeaderText = "Sales Report from " + strDateFrom + " to " + strDateTo;
            }
            else if (ddlReportType.SelectedValue == "2")
            {
                rprt.Load(Server.MapPath("~/Reports/rptSalesWeekly_Summary.rpt"));
                HeaderText = " Summary Sales Report from " + strDateFrom + " to " + strDateTo;
                //reportType = CrystalDecisions.Shared.ExportFormatType.Excel;
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptSalesWeeklyShopWise.rpt"));
                HeaderText = ddlShop.SelectedItem.Text + " Sales Report from " + strDateFrom + " to " + strDateTo;
            }
            //rprt.Load(Server.MapPath("~/Reports/rptSalesWeekly.rpt"));            
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                // TextObject ReleasedToShop = (TextObject)rprt.ReportDefinition.Sections[3].ReportObjects["ReleasedToShop"];
                //if (ReleasedToShop.Text == "")
                //{
                //    ReleasedToShop.Text = "Stock";
                //}
                //txtheader.Text = "Sales Report from " + strDateFrom + " to " + strDateTo;
                txtheader.Text = HeaderText;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(reportType, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = HeaderText;
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

    private void GenrateReportExcel()
    {
        try
        {
            string HeaderText = string.Empty;
            TextObject txtheader = null;
            DataTable dt = ReportData();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            if (ddlShop.SelectedIndex == 0 && ddlReportType.SelectedValue == "1")
            {
                rprt.Load(Server.MapPath("~/Reports/rptSalesWeekly.rpt"));
                txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Sales Report from " + strDateFrom + " to " + strDateTo;
                HeaderText = "Sales Report from " + strDateFrom + " to " + strDateTo;
            }
            else if (ddlReportType.SelectedValue == "2")
            {
                rprt.Load(Server.MapPath("~/Reports/rptSalesWeekly_Summary.rpt"));
                txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = " Summary Sales Report from " + strDateFrom + " to " + strDateTo;
                //reportType = CrystalDecisions.Shared.ExportFormatType.Excel;
                HeaderText = " Summary Sales Report from " + strDateFrom + " to " + strDateTo;
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptSalesWeeklyShopWise.rpt"));
                txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlShop.SelectedItem.Text + " Sales Report from " + strDateFrom + " to " + strDateTo;
                HeaderText = " Summary Sales Report from " + strDateFrom + " to " + strDateTo;
            }
            if (dt.Rows.Count > 0)
            {
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = HeaderText;
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

    protected void btnGenrate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                GenrateReport();
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

    protected void btnGenerateExcel_Click(object sender, EventArgs e)
    {
        try
        {
            GenrateReportExcel();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtFromDate.Text = DateTime.Today.ToString("MM/dd/yyyy");
        txtToDate.Text = DateTime.Today.ToString("MM/dd/yyyy");
        int Month = DateTime.Now.Month + 2;
        txtFromDate.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
        txtToDate.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
    }

    public void CombinePdfs(string folderPath, List<string> fileNames, string fromdate, string todate)
    {

        string combinedfilePath = "";
        try
        {
            int missingFileCount = 0;
            foreach (string fileName in fileNames)
            {
                string filePath = Path.Combine(folderPath, fileName);
                if (!File.Exists(filePath))
                {
                    missingFileCount++;
                }
            }

            if (missingFileCount == fileNames.Count)
            {
                // If all files are missing, exit
                Utility.ShowMessage_Error(Page, "No files found in the folder");
                return;
            }

            // Create a new PDF document
            Document document = new Document();
            string saveFolderPath = Utility.CombinedPDFPath();
            if (!Directory.Exists(saveFolderPath))
            {
                Directory.CreateDirectory(saveFolderPath);
            }

            // Create a unique file name with a timestamp
            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("MMddss");
            string combinedfileName = "PlanView_" + formattedDateTime + ".pdf";
            combinedfilePath = Path.Combine(saveFolderPath, combinedfileName);

            using (FileStream fileStream = new FileStream(combinedfilePath, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                document.Open();


                float scaleFactor = 0.9f;
                // Loop through each PDF file and add it to the document
                foreach (string fileName in fileNames)
                {
                    string filePath = Path.Combine(folderPath, fileName);
                    if (File.Exists(filePath))
                    {
                        PdfReader reader = new PdfReader(filePath);
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            // Get the page size and crop it
                            Rectangle pageSize = reader.GetPageSizeWithRotation(i);
                            PdfDictionary pageDict = reader.GetPageN(i);
                            PdfArray cropBox = pageDict.GetAsArray(PdfName.CROPBOX) ?? pageDict.GetAsArray(PdfName.MEDIABOX);

                            // Calculate the new page size based on the content
                            if (cropBox != null && cropBox.Size == 4)
                            {
                                float llx = cropBox.GetAsNumber(0).FloatValue;
                                float lly = cropBox.GetAsNumber(1).FloatValue;
                                float urx = cropBox.GetAsNumber(2).FloatValue;
                                float ury = cropBox.GetAsNumber(3).FloatValue;

                                // Create a new rectangle for cropping
                                Rectangle newPageSize = new Rectangle(llx, lly, urx, ury);

                                document.SetPageSize(newPageSize);
                                // Set the page size to landscape
                                if (pageSize.Rotation == 0)
                                {
                                    document.SetPageSize(newPageSize);
                                }
                                else
                                {
                                    // Swap width and height for landscape
                                    document.SetPageSize(new Rectangle(newPageSize.Height, newPageSize.Width));
                                }
                                document.NewPage(); // Create a new page with the new size                             
                            }
                            // Add the imported page to the document
                            PdfImportedPage page = writer.GetImportedPage(reader, i);
                            // Scale the content
                            PdfContentByte cb = writer.DirectContent;
                            cb.SaveState();
                            cb.ConcatCTM(scaleFactor, 0, 0, scaleFactor, (1 - scaleFactor) * page.Width / 2, (1 - scaleFactor) * page.Height / 2);

                            // Add the page
                            if (pageSize.Rotation == 0)
                            {
                                cb.AddTemplate(page, 0, 0);
                            }
                            else
                            {
                                cb.AddTemplate(page, 0, 1, -1, 0, page.Height, 0);
                            }
                            cb.RestoreState();
                        }
                        reader.Close();
                    }
                }
                // Close the document
                document.Close();

                // Send the file to the client for download
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + combinedfileName);
                Response.TransmitFile(combinedfilePath);
                Response.Flush(); // Flush the response to the client
                HttpContext.Current.ApplicationInstance.CompleteRequest(); // Complete the request

                // Delete the file after sending it to the client
                if (File.Exists(combinedfilePath))
                {
                    File.Delete(combinedfilePath);
                }
                btnDownloadCombinedPlanView.Enabled = true;
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
}