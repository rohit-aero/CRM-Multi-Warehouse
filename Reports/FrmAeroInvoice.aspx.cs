using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Web.UI;

public partial class Reports_FrmAeroInvoice : System.Web.UI.Page
{
    BOLAeroInvoice objBOL = new BOLAeroInvoice();
    BLLAeroInvoice objBLL = new BLLAeroInvoice();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            reset();
        }
    }

    protected void ddlReportType_SelectedIndexChange(object sender, EventArgs e)
    {
        try
        {
            if (ddlReportType.SelectedValue == "0")
            {
                lblFromDate.Text = "From&nbsp;Date&nbsp;";
                lblToDate.Text = "To&nbsp;Date&nbsp;";

            }
            else if (ddlReportType.SelectedValue == "1" || ddlReportType.SelectedValue == "2" || ddlReportType.SelectedValue == "4")
            {
                lblFromDate.Text = "Date&nbsp;Req.&nbsp;Fwd&nbsp;To&nbsp;CAD&nbsp;Team" + " From&nbsp;Date";
                lblToDate.Text = "Date&nbsp;Req.&nbsp;Fwd&nbsp;To&nbsp;CAD&nbsp;Team" + " To&nbsp;Date";
            }
            else if (ddlReportType.SelectedValue == "3")
            {
                lblFromDate.Text = "Released&nbsp;Date" + " From&nbsp;Date";
                lblToDate.Text = "Released&nbsp;Date" + " To&nbsp;Date";

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GenerateReport_ProposalDwg()
    {
        try
        {
            string headerText = "Proposal Drawing Report From " + txtFromDate.Text + " to " + txtToDate.Text;
            objBOL.Operation = 1;
            objBOL.FromDate = Convert.ToDateTime(txtFromDate.Text);
            objBOL.ToDate = Convert.ToDateTime(txtToDate.Text);
            DataTable dt = objBLL.GetReportData(objBOL).Tables[0];
            rprt.Load(Server.MapPath("~/Reports/rptAeroInvoice_Dwg.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = headerText;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                //Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = headerText;
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }

    private void GenerateReport_ShopDwg()
    {
        try
        {
            string headerText = "Shop Drawing Report From " + txtFromDate.Text + " to " + txtToDate.Text;
            objBOL.Operation = 2;
            objBOL.FromDate = Convert.ToDateTime(txtFromDate.Text);
            objBOL.ToDate = Convert.ToDateTime(txtToDate.Text);
            DataTable dt = objBLL.GetReportData(objBOL).Tables[0];
            rprt.Load(Server.MapPath("~/Reports/rptAeroInvoice_Dwg.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = headerText;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                //Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = headerText;
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }

    private void GenerateReport_Fabrication()
    {
        try
        {
            string headerText = "Fabrication Report From " + txtFromDate.Text + " to " + txtToDate.Text; ;
            objBOL.Operation = 3;
            objBOL.FromDate = Convert.ToDateTime(txtFromDate.Text);
            objBOL.ToDate = Convert.ToDateTime(txtToDate.Text);
            DataTable dt = objBLL.GetReportData(objBOL).Tables[0];
            rprt.Load(Server.MapPath("~/Reports/rptAeroInvoice_Fab.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = headerText;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                //Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = headerText;
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }

    private void GenerateReport_Revit()
    {
        try
        {
            string headerText = "Revit Report From " + txtFromDate.Text + " to " + txtToDate.Text;
            objBOL.Operation = 7;
            objBOL.FromDate = Convert.ToDateTime(txtFromDate.Text);
            objBOL.ToDate = Convert.ToDateTime(txtToDate.Text);
            DataTable dt = objBLL.GetReportData(objBOL).Tables[0];
            rprt.Load(Server.MapPath("~/Reports/rptAeroInvoice_Dwg.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = headerText;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                //Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = headerText;
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }

    private bool ValidationCheck()
    {
        try
        {
            if (ddlReportType.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Report Type !!');", true);
                Utility.ShowMessage_Error(Page, "Please Select Report Type !!");
                ddlReportType.Focus();
                return false;
            }
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

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        if (!ValidationCheck())
        {
            return;
        }
        if (ddlReportType.SelectedValue == "1")
        {
            GenerateReport_ProposalDwg();
        }
        else if (ddlReportType.SelectedValue == "2")
        {
            GenerateReport_ShopDwg();
        }
        else if (ddlReportType.SelectedValue == "3")
        {
            GenerateReport_Fabrication();
        }
        else if (ddlReportType.SelectedValue == "4")
        {
            GenerateReport_Revit();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        reset();
    }

    private void reset()
    {
        DateTime today = DateTime.Now;

        DateTime fromDate = new DateTime(today.Year, today.Month, 1);
        DateTime firstDayOfNextMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1);
        DateTime toDate = firstDayOfNextMonth.AddMonths(1).AddDays(-1);
        txtFromDate.Text = fromDate.ToShortDateString();
        txtToDate.Text = toDate.ToShortDateString();

        ddlReportType.SelectedIndex = 0;
    }

    private void GenerateExporttoExcel_ProposalDwg()
    {
        try
        {
            DataTable dt = new DataTable();
            string fileName = "Proposal Drawing Report From " + txtFromDate.Text + " to " + txtToDate.Text;
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_AeroInvoice]  4,'" + strDateFrom + "','" + strDateTo + "'");
            if (dt.Rows.Count > 0)
            {
                Utility.ExportToExcelDT(dt, fileName);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GenerateExporttoExcel_ShopDwg()
    {
        try
        {
            DataTable dt = new DataTable();
            string fileName = "Shop Drawing Report From " + txtFromDate.Text + " to " + txtToDate.Text;
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_AeroInvoice]  5,'" + strDateFrom + "','" + strDateTo + "'");
            if (dt.Rows.Count > 0)
            {
                Utility.ExportToExcelDT(dt, fileName);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GenerateExporttoExcel_Fabrication()
    {
        try
        {
            DataTable dt = new DataTable();
            string fileName = "Fabrication Report From " + txtFromDate.Text + " to " + txtToDate.Text;
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_AeroInvoice]  6,'" + strDateFrom + "','" + strDateTo + "'");
            if (dt.Rows.Count > 0)
            {
                Utility.ExportToExcelDT(dt, fileName);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GenerateExporttoExcel_Revit()
    {
        try
        {
            DataTable dt = new DataTable();
            string fileName = "Revit Report From " + txtFromDate.Text + " to " + txtToDate.Text;
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_AeroInvoice]  8,'" + strDateFrom + "','" + strDateTo + "'");
            if (dt.Rows.Count > 0)
            {
                Utility.ExportToExcelDT(dt, fileName);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidationCheck())
            {
                return;
            }
            if (ddlReportType.SelectedValue == "1")
            {
                GenerateExporttoExcel_ProposalDwg();
            }
            else if (ddlReportType.SelectedValue == "2")
            {
                GenerateExporttoExcel_ShopDwg();
            }
            else if (ddlReportType.SelectedValue == "3")
            {
                GenerateExporttoExcel_Fabrication();
            }
            else if (ddlReportType.SelectedValue == "4")
            {
                GenerateExporttoExcel_Revit();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}