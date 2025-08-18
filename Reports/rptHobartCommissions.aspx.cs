using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
public partial class Reports_frmAeroCommissions : System.Web.UI.Page
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

    // Call Function
    private void Check_Url(string id)
    {
        try
        {
            if (id != null)
            {
                //Hobart Commission Report 
                if (id == "0")
                {
                    GenrateReport_Zero();
                }
                //Internal Commission Report
                else if (id == "1")
                {
                    GenrateReport_First();
                }
                //Monthly Commission Report
                else if (id == "2")
                {
                    GenrateReport_Second();
                }
                //Hobart Commission Payment Report
                else if (id == "3")
                {
                    GenrateReport_Third();
                }
                //TragenFlex Commission Report
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

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptHobartCommission.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_HobartCommission] '" + strDateFrom + "','" + strDateTo + "','" + ddlCountry.SelectedValue + "'");
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
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
                if (txtFromDate.Text != "" && txtToDate.Text != "")
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

    private void GenrateReport_First()
    {
        try
        {
            DataTable dt = new DataTable();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptHobartCommissionInternal.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_HobartCommission] '" + strDateFrom + "','" + strDateTo + "','" + ddlCountry.SelectedValue + "'");
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
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
                if (txtFromDate.Text != "" && txtToDate.Text != "")
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

    private void GenrateReport_Second()
    {
        try
        {
            DataTable dt = new DataTable();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptHobartCommissionMonthly.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_HobartCommission] '" + strDateFrom + "','" + strDateTo + "','" + ddlCountry.SelectedValue + "'");
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
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
                if (txtFromDate.Text != "" && txtToDate.Text != "")
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

    private void GenrateReport_Third()
    {
        try
        {
            DataTable dt = new DataTable();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptHobartCommissionPayment.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_HobartCommissionPayment] '" + strDateFrom + "','" + strDateTo + "','" + ddlCountry.SelectedValue + "'");
            if (dt.Rows.Count > 0)
            {

                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = ddlCountry.SelectedItem.Text + " Hobart Commission Payment Details From " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = ddlCountry.SelectedItem.Text + " Hobart Commission Payment Details Report ";
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
                    txtheader.Text = ddlCountry.SelectedItem.Text + " Hobart Commission Payment Details From " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = ddlCountry.SelectedItem.Text + " Hobart Commission Payment Details Report ";
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

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptTragenFlex.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_TragenFlexCommission] '" + strDateFrom + "','" + strDateTo + "'");
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "TragenFlex Commission Report From " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "TragenFlex Commission Report From " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = "TragenFlex Commission Report ";
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