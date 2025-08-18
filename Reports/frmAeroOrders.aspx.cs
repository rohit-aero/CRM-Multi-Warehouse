using System;
using System.Web.UI;
using BOLAERO;
using BLLAERO;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
public partial class Reports_frmAeroOrders : System.Web.UI.Page
{
    BOLOpenProposalReports OBJBOL = new BOLOpenProposalReports();
    BLLOpenProposalReportDate OBJBLL = new BLLOpenProposalReportDate();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // int Month = DateTime.Now.Month + 2;
            txtProposalShipDateFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            // txtProposalShipDateTo.Text = DateTime.Now.AddDays(8).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(2).Month) + "/" + DateTime.Now.AddMonths(2).Year;
            txtProposalShipDateTo.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
        }
    }

    #region ValidationCheck
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtProposalShipDateFrom.Text == "" && txtProposalShipDateTo.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Proposal Ship Date From. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Proposal Ship Date From. !!");
                txtProposalShipDateFrom.Focus();
                return false;
            }
            if (txtProposalShipDateFrom.Text != "")
            {
                if (txtProposalShipDateTo.Text == "")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Proposal Ship Date To. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Enter Proposal Ship Date To. !!");
                    txtProposalShipDateTo.Focus();
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }
    #endregion

    private DataTable ReportDataQuoteOrder()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtProposalShipDateFrom.Text);
            DateTime dtto = Convert.ToDateTime(txtProposalShipDateTo.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_Quotes_YTDOrderTotal] '" + strDateFrom + "','" + strDateTo + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void Bind_Report2()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string headerText = "Orders Report ";
                if (txtProposalShipDateFrom.Text != "" && txtProposalShipDateTo.Text != "")
                {
                    headerText += "From " + txtProposalShipDateFrom.Text + " to " + txtProposalShipDateTo.Text;
                }
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                dt1 = ReportDataQuoteOrder();
                DateTime dtfrom = Convert.ToDateTime(txtProposalShipDateFrom.Text);
                DateTime dtto = Convert.ToDateTime(txtProposalShipDateTo.Text);
                string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
                string strDateTo = dtto.ToString("MM/dd/yyyy");
                clscon.Return_DT(dt, "EXEC [dbo].[Get_OrderInfo] 1,'" + strDateFrom + "','" + strDateTo + "'");
                rprt.Load(Server.MapPath("~/Reports/rptOrdersInfo.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = headerText;
                    rprt.SetDataSource(dt);
                    rprt.Subreports[0].SetDataSource(dt1);
                    rptSalesRepGroup.ReportSource = rprt;
                    rptSalesRepGroup.DataBind();
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
            Bind_Report2();
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
    }

    protected void btnClearProposal_Click(object sender, EventArgs e)
    {
        try
        {
            //ddlProjectStage.SelectedIndex = 0;                    
            int Month = DateTime.Now.Month + 2;
            txtProposalShipDateFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            txtProposalShipDateTo.Text = DateTime.Now.AddMonths(2).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.AddMonths(2).Year;
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
            BindOrderinExcel();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindOrderinExcel()
    {
        try
        {
            DataTable dt = new DataTable();
            DateTime dtfrom = Convert.ToDateTime(txtProposalShipDateFrom.Text);
            DateTime dtto = Convert.ToDateTime(txtProposalShipDateTo.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_OrderInfo] 2,'" + strDateFrom + "','" + strDateTo + "'");
            Utility.ExportToExcelDT(dt, "Orders Report From " + strDateFrom + " to " + strDateTo);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }
}