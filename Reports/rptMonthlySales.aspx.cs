using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

public partial class Reports_rptMonthlySales : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                int Month = DateTime.Now.Month + 2;
                txtFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
                txtTo.Text = DateTime.Now.AddMonths(2).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(2).Month) + "/" + DateTime.Now.AddMonths(2).Year;
                BindCountry();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindCountry()
    {
        try
        {
            Utility.BindDropDownList(ddlCountry, Utility.GetCountries());
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
            if (txtFrom.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter From Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter From Date. !!");
                txtFrom.Focus();
                return false;
            }

            if (txtTo.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter To Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter To Date. !!");
                txtTo.Focus();
                return false;
            }

            if (ddlCountry.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Country. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Country. !!");
                ddlCountry.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

        return true;
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            { GenrateReport(); }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GenrateReport()
    {
        try
        {
            DataTable dt = new DataTable();
            DateTime dtfrom = Convert.ToDateTime(txtFrom.Text);
            DateTime dtto = Convert.ToDateTime(txtTo.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptHobartCommissionMonthly.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_HobartCommission] '" + strDateFrom + "','" + strDateTo + "','" + ddlCountry.SelectedValue + "'");
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFrom.Text != "" && txtTo.Text != "")
                {
                    txtheader.Text = "Hobart " + ddlCountry.SelectedItem.Text + "  Commission Report From " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = "Hobart " + ddlCountry.SelectedItem.Text + "  Commission Report ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Hobart " + ddlCountry.SelectedItem.Text + "  Commission Report From " + strDateFrom + " to " + strDateTo);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFrom.Text != "" && txtTo.Text != "")
                {
                    txtheader.Text = "Hobart " + ddlCountry.SelectedItem.Text + "  Commission Report From " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = "Hobart " + ddlCountry.SelectedItem.Text + "  Commission Report ";
                }
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
}