using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;

public partial class Reports_frmProductionWeekly : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    // Get the current date
    DateTime currentDate = DateTime.Now;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                if (!IsPostBack)
                {
                    ddlShop_SelectedIndexChanged_Event();
                    BindControls();
                    int Month = DateTime.Now.Month + 2;
                    // Calculate the start date (current date - 2 weeks)
                    DateTime startDate = currentDate.AddDays(-14);
                    // Calculate the end date (current date + 3 months)
                    DateTime endDate = currentDate.AddMonths(2);
                    txtFromDate.Text = startDate.ToString("MM/dd/yyyy"); // Format as needed
                    txtToDate.Text = endDate.ToString("MM/dd/yyyy");     // Format as needed
                    int countryid = Utility.GetCurrentUserCountryId();
                    if (countryid == 13)
                    {
                        ddlShop.Enabled = false;
                        ddlShop.SelectedValue = "2";
                        rdbIssuedFor.Attributes.Add("style", "disabled:false");
                        rdbIssuedFor.SelectedValue = "B";
                        rdbForChina.Attributes.Add("style", "display:block");
                        //rdbIssuedFor.Enabled = true;
                        //rdbIssuedFor.SelectedValue = "B";
                        //rdbForChina.Visible = true;
                    }
                    else
                    {
                        ddlShop.Enabled = true;
                        ddlShop.SelectedIndex = -1;
                        rdbForChina.Attributes.Add("style", "display:none");
                    }
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
                }
            }
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
            DataTable dt = new DataTable();
            clscon.Return_DT(dt, "SELECT ID, WarehouseName AS [text] FROM Inv_Warehouse ORDER BY WarehouseName ");
            Utility.BindDropDownListAll(ddlShop, dt);
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
                clscon.Return_DT(dt, "EXEC [dbo].[Get_SalesUsaCanProduction] '" + strDateFrom + "','" + strDateTo + "',0 ");
            }
            else
            {
                clscon.Return_DT(dt, "EXEC [dbo].[Get_SalesUsaCanProduction] '" + strDateFrom + "','" + strDateTo + "'," + ddlShop.SelectedValue + ",'" + rdbIssuedFor.SelectedValue + "' ");
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
            if (ddlShop.SelectedIndex == 0)
            {
                rprt.Load(Server.MapPath("~/Reports/rptProductionWeekly.rpt"));
                HeaderText = "Production Report from " + strDateFrom + " to " + strDateTo;
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptProductionWeeklyShopWise.rpt"));
                HeaderText = ddlShop.SelectedItem.Text + " Production Report from " + strDateFrom + " to " + strDateTo;
            }
            if (dt.Rows.Count > 0)
            {
                CrystalDecisions.CrystalReports.Engine.Section section = rprt.ReportDefinition.Sections["Section2"];
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = HeaderText;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
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
            DataTable dt = ReportData();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            //rprt.Load(Server.MapPath("~/Reports/rptProductionWeekly.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = null;
                if (ddlShop.SelectedIndex == 0)
                {
                    rprt.Load(Server.MapPath("~/Reports/rptProductionWeekly.rpt"));
                    txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Production Report from " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptProductionWeeklyShopWise.rpt"));
                    txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = ddlShop.SelectedItem.Text + " Production Report from " + strDateFrom + " to " + strDateTo;
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
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
                ddlShop_SelectedIndexChanged_Event();
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
            ddlShop_SelectedIndexChanged_Event();
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
            txtFromDate.Text = DateTime.Today.ToString("MM/dd/yyyy");
            txtToDate.Text = DateTime.Today.ToString("MM/dd/yyyy");
            int Month = DateTime.Now.Month + 2;
            // Calculate the start date (current date - 2 weeks)
            DateTime startDate = currentDate.AddDays(-14);
            // Calculate the end date (current date + 3 months)
            DateTime endDate = currentDate.AddMonths(2);
            txtFromDate.Text = startDate.ToString("MM/dd/yyyy"); // Format as needed
            txtToDate.Text = endDate.ToString("MM/dd/yyyy");     // Format as needed
            ddlShop.SelectedIndex = 0;
            ddlShop_SelectedIndexChanged_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlShop_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlShop_SelectedIndexChanged_Event();
    }

    private void ddlShop_SelectedIndexChanged_Event()
    {
        try
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}