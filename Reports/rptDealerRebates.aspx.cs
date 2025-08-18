using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
public partial class Reports_rptDealerRebates : System.Web.UI.Page
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
                txtFromDate.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
                txtToDate.Text = DateTime.Now.AddMonths(2).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(2).Month) + "/" + DateTime.Now.AddMonths(2).Year;
                BindCountry();
                ddlCountry.SelectedValue = "2";
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

    // Call Function
    private void Check_Url(string id)
    {
        try
        {
            if (id != null)
            {
                //Aramark Rebate Report
                if (id == "0")
                {
                    GenrateReport_Zero();
                }
                //Boelter Rebate Report
                else if (id == "1")
                {
                    GenrateReport_First();
                }
                //Edward Don Rebate Report
                else if (id == "2")
                {
                    GenrateReport_Second();
                }
                //Government Sales Inc.
                else if (id == "3")
                {
                    GenrateReport_Third();
                }
                //Trimark
                else if (id == "4")
                {
                    GenrateReport_Fourth();
                }

            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    private void GenrateReport_Zero()
    {
        try
        {
            DataTable dt = new DataTable();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            int year = dtfrom.Year;

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptAramark.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_Aramark] '" + strDateFrom + "','" + strDateTo + "'");
            if (dt.Rows.Count > 0)
            {

                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                //TextObject txtTotal=  (TextObject)rprt.ReportDefinition.ReportObjects["RTotal01"];
                //TextObject txtPercentage = (TextObject)rprt.ReportDefinition.ReportObjects["RebatePercentage1"];
                //TextObject txtAmount = (TextObject)rprt.ReportDefinition.ReportObjects["txtRebateAmount"];
                ////txtRebateAmount

                //Decimal famount = (Convert.ToDecimal(txtTotal.Text) * Convert.ToDecimal(txtPercentage.Text)) / 100;

                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Aramark Sales Rebate Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Aramark Sales Rebate Report " + year;
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Aramark Sales Rebate Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Aramark Sales Rebate Report " + year;
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

    private void GenrateReport_First()
    {
        try
        {
            DataTable dt = new DataTable();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            int year = dtfrom.Year;
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptBoelter.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_Boelter] '" + strDateFrom + "','" + strDateTo + "'");
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Boelter Rebate Program From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Boelter Rebate Program ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Boelter Rebate Program From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Boelter Rebate Program ";
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

    private void GenrateReport_Second()
    {
        try
        {
            DataTable dt = new DataTable();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            int year = dtfrom.Year;
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptEdwordDon.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_EdwardDon] '" + strDateFrom + "','" + strDateTo + "'");
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "EdwardDon Rebate Program From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "EdwardDon Rebate Program ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "EdwardDon Rebate Program From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "EdwardDon Rebate Program ";
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

    private void GenrateReport_Third()
    {
        try
        {
            DataTable dt = new DataTable();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptGSICommission.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_GSICommission] '" + strDateFrom + "','" + strDateTo + "','" + ddlCountry.SelectedValue + "'");
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Government Sales Inc Commission Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Government Sales Inc Commission Report ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Government Sales Inc Commission Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Government Sales Inc Commission Report ";
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

    private void GenrateReport_Fourth()
    {
        try
        {
            DataTable dt = new DataTable();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            int year = dtfrom.Year;
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptTrimark.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_Trimark] '" + strDateFrom + "','" + strDateTo + "'");
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "TriMark Corporate Rebate Program From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "TriMark Corporate Rebate Program ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "TriMark Corporate Rebate Program From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "TriMark Corporate Rebate Program ";
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

    // Genrate report here
    protected void btnGenrate_Click(object sender, EventArgs e)
    {
        try
        {
            Check_Url(rdbList.SelectedValue);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}