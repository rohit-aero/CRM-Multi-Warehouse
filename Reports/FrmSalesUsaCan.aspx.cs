using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
public partial class Reports_FrmSalesUsaCan : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;              
                txtToDate.Text = DateTime.Now.AddMonths(2).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(2).Month) + "/" + DateTime.Now.AddMonths(2).Year;
            }
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
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
        return true;
    }   

    private void GenrateReport()
    {
        try
        {            
            DataTable dt = new DataTable();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptSalesUsaCan.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_SalesUsaCan] '" + strDateFrom + "','" + strDateTo +"' ");
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "HOBART & STERO GROUP" + "\nUSA and CANADA Details Sales Report from " + strDateFrom + " to " + strDateTo + "\n**Projects Shipped and booked";
                
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "HOBART & STERO GROUP" + "\nUSA and CANADA Details Sales Report from " + strDateFrom + " to " + strDateTo + "\n**Projects Shipped and booked";
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
            Utility.AddEditException(ex);
        }        
    }
}