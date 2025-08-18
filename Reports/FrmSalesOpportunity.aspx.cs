using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_FrmSalesOpportunity : System.Web.UI.Page
{
    BOLSalesOpportunity ObjBOL = new BOLSalesOpportunity();
    BLLSalesOpportunity ObjBLL = new BLLSalesOpportunity();
    ReportDocument rpt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
            //SetDates();
        }
    }

    private void SetDates()
    {
        try
        {
            txtFromDate.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            txtToDate.Text = DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Year;
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
            ObjBOL.Operation = 1;
            DataSet ds = new DataSet();
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlSalesOpportunity, ds.Tables[0]);
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
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            if (ddlSalesOpportunity.SelectedIndex > 0)
            {
                ObjBOL.SalesOpportunity = Int32.Parse(ddlSalesOpportunity.SelectedValue);
            }

            if (ddlStatus.SelectedIndex > 0)
            {
                ObjBOL.SalesOpportunityStatus = Int32.Parse(ddlStatus.SelectedValue);
            }

            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                ObjBOL.FromDate = Utility.ConvertDate(txtFromDate.Text);
                ObjBOL.ToDate = Utility.ConvertDate(txtToDate.Text);
            }

            ds = ObjBLL.Return_DataSet(ObjBOL);
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

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = ReportData();
            if (dt.Rows.Count > 0)
            {
                rpt.Load(Server.MapPath("~/Reports/rptSalesOpportunity.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rpt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtFromDate.Text != "" && txtToDate.Text != "")
                    {
                        txtheader.Text = "Sales Opportunity Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                    }
                    else
                    {
                        txtheader.Text = "Sales Opportunity Report ";
                    }
                    rpt.SetDataSource(dt);
                    rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
            else
            {
                rpt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rpt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Sales Opportunity Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Opportunity Report ";
                }
                rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            rpt.Close();
            rpt.Dispose();
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            //SetDates();
            if (ddlSalesOpportunity.Items.Count > 0)
            {
                ddlSalesOpportunity.SelectedIndex = 0;
            }

            if (ddlStatus.Items.Count > 0)
            {
                ddlStatus.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}