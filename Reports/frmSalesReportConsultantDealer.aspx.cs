using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
public partial class Reports_frmSalesReportConsultantDealer : System.Web.UI.Page
{
    BOLOpenProposalReports OBJBOL = new BOLOpenProposalReports();
    BLLOpenProposalReportDate OBJBLL = new BLLOpenProposalReportDate();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
        }
    }

    private Boolean ValidationCheck()
    {
        try
        {
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
            if (ddlNestingStatus.SelectedValue == "1")
            {
                clscon.Return_DT(dt, "EXEC [dbo].[Get_SalesReportConsultantDealer]  1");
            }
            else if (ddlNestingStatus.SelectedValue == "2")
            {
                clscon.Return_DT(dt, "EXEC [dbo].[Get_SalesReportConsultantDealer]  2");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void Bind_Report()
    {
        try
        {
            if(ValidationCheck()==true)
            {                
                DataTable dt = ReportData();
                rprt.Load(Server.MapPath("~/Reports/rptSalesReportConsultantDealer.rpt"));                
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (ddlNestingStatus.SelectedValue == "1")
                    {
                        txtheader.Text = "Sales By Dealer";
                    }                  
                    else if (ddlNestingStatus.SelectedValue == "2")
                    {
                        txtheader.Text = "Sales By Consultant";
                    }
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);                    
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (ddlNestingStatus.SelectedValue == "1")
                    {
                        txtheader.Text = "Sales By Dealer";
                    }
                    else if (ddlNestingStatus.SelectedValue == "2")
                    {
                        txtheader.Text = "Sales By Consultant";
                    }
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
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
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }
    
    private void Bind_ReportExcel()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                DataTable dt = ReportData();
                rprt.Load(Server.MapPath("~/Reports/rptSalesReportConsultantDealer.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (ddlNestingStatus.SelectedValue == "1")
                    {
                        txtheader.Text = "Sales By Dealer";
                    }
                    else if (ddlNestingStatus.SelectedValue == "2")
                    {
                        txtheader.Text = "Sales By Consultant";
                    }
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (ddlNestingStatus.SelectedValue == "1")
                    {
                        txtheader.Text = "Sales By Dealer";
                    }
                    else if (ddlNestingStatus.SelectedValue == "2")
                    {
                        txtheader.Text = "Sales By Consultant";
                    }
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
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
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }

    protected void btnSearchProposal_Click(object sender, EventArgs e)
    {
        try
        {
            Bind_Report();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnClearProposal_Click(object sender, EventArgs e)
    {
        try
        {
            ddlNestingStatus.SelectedIndex = 0;          
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Bind_ReportExcel();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}