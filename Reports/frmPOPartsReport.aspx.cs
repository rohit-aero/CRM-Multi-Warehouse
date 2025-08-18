using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

public partial class Reports_frmPOPartsReport : System.Web.UI.Page
{
    BOLSearchContainer ObjBOL = new BOLSearchContainer();
    BLLManageSearchContainer ObjBLL = new BLLManageSearchContainer();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int Month = DateTime.Now.Month + 2;
            txtOrderDateFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;            
            txtOrderDateTo.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;           
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if(ValidationCheck()==true)
            {
          
                DataTable dt = new DataTable();

                DateTime dtfrom = Convert.ToDateTime(txtOrderDateFrom.Text);
                DateTime dtto = Convert.ToDateTime(txtOrderDateTo.Text);

                string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
                string strDateTo = dtto.ToString("MM/dd/yyyy");

                dt = ReportDataZero();                
                rprt.Load(Server.MapPath("~/Reports/rptPOPartsReport.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Purchase Order Parts Detail From " + strDateFrom + " to " + strDateTo;
                    rprt.SetDataSource(dt);                    
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Purchase Order Parts Detail From " + strDateFrom + " to " + strDateTo;
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
        }
        catch (Exception ex)
        {
            if(ex.ToString() != "Thread was being aborted.")
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

    private DataTable ReportDataZero()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[Inv_GeneratePOPartsReport] '"  + txtOrderDateFrom.Text + "','" + txtOrderDateTo.Text +"'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private Boolean ValidationCheck()
    {
        try
        {
            if (txtOrderDateFrom.Text == "")
            {
                Utility.ShowMessage_Warning(Page, "Please Enter Order Date From !");
                txtOrderDateFrom.Focus();
                return false;
            }
            if (txtOrderDateTo.Text == "")
            {
                Utility.ShowMessage_Warning(Page, "Please Enter Order Date To !");
                txtOrderDateTo.Focus();
                return false;
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    //btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            int Month = DateTime.Now.Month + 2;
            txtOrderDateFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;           
            txtOrderDateTo.Text = DateTime.Now.AddMonths(2).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(2).Month) + "/" + DateTime.Now.AddMonths(2).Year;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    } 
}