using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;

public partial class Reports_frmTragenflex : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int Month = DateTime.Now.Month + 2;
            txtFromDate.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            txtToDate.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
            if (Request.QueryString["Country"] != null)
            {
                string country = Request.QueryString["Country"];
                if (country == "CANADA")
                {
                    hf.Value = "1";
                    CADP.Visible = true;
                    CADYTD.Visible = true;
                    USP.Visible = false;
                    USYTD.Visible = false;
                }
                else if (country == "US")
                {
                    hf.Value = "2";
                    CADP.Visible = false;
                    CADYTD.Visible = false;
                    USP.Visible = true;
                    USYTD.Visible = true;
                }
                else
                {
                    hf.Value = "-1";
                    CADP.Visible = false;
                    CADYTD.Visible = false;
                    USP.Visible = false;
                    USYTD.Visible = false;
                }
            }
        }
    }

    private Boolean ValidationCheck()
    {
        try
        {
            if (rdbList.SelectedValue == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select any Option. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select any Option. !!");
                rdbList.Focus();
                return false;
            }

            //if (txtYear.Text == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Year. !');", true);
            //    txtYear.Focus();
            //    return false;
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

        return true;
    }

    private DataTable ReportZero()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_TragenflexReports] '" + strDateFrom + "','" + strDateTo + "', " + hf.Value);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport_Zero()
    {
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportZero();
            rprt.Load(Server.MapPath("~/Reports/rptTragenFlexPandJ.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (hf.Value == "1")
                {
                    txtheader.Text = "Canada TragenFlex Sales Activity from " + strDateFrom + " to " + strDateTo;
                }
                else if (hf.Value == "2")
                {
                    txtheader.Text = "US TragenFlex Sales Activity from " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = "US & Canada TragenFlex Sales Activity from " + strDateFrom + " to " + strDateTo;
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (hf.Value == "1")
                {
                    txtheader.Text = "Canada TragenFlex Sales Activity from " + strDateFrom + " to " + strDateTo;
                }
                else if (hf.Value == "2")
                {
                    txtheader.Text = "US TragenFlex Sales Activity from " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = "US & Canada TragenFlex Sales Activity from " + strDateFrom + " to " + strDateTo;
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

    private void GenrateReport_ZeroExcel()
    {
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportZero();
            rprt.Load(Server.MapPath("~/Reports/rptTragenFlexPandJ.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "TragenFlex Sales Activity from " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "TragenFlex Sales Activity from " + strDateFrom + " to " + strDateTo;
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

    private DataTable ReportFirst()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_TragenFlexProposal] '" + strDateFrom + "','" + strDateTo + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport_First()
    {
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportFirst();
            rprt.Load(Server.MapPath("~/Reports/rptTragenFlexProposals.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (hf.Value == "1")
                {
                    txtheader.Text = "Canada TragenFlex Proposals from " + strDateFrom + " to " + strDateTo;
                }
                else if (hf.Value == "2")
                {
                    txtheader.Text = "US TragenFlex Proposals from " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = "US & Canada TragenFlex Proposals from " + strDateFrom + " to " + strDateTo;
                }

                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (hf.Value == "1")
                {
                    txtheader.Text = "Canada TragenFlex Proposals from " + strDateFrom + " to " + strDateTo;
                }
                else if (hf.Value == "2")
                {
                    txtheader.Text = "US TragenFlex Proposals from " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = "US & Canada TragenFlex Proposals from " + strDateFrom + " to " + strDateTo;
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

    private void GenrateReport_FirstExcel()
    {
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportFirst();
            rprt.Load(Server.MapPath("~/Reports/rptTragenFlexProposals.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "TragenFlex Proposals \nfrom " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "TragenFlex Proposals \nfrom " + strDateFrom + " to " + strDateTo;
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

    private void Reset()
    {
        try
        {
            //txtYear.Text = String.Empty;
            rdbList.ClearSelection();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                if (rdbList.SelectedValue == "1")
                {
                    GenrateReport_Zero();
                }
                else if (rdbList.SelectedValue == "2")
                {
                    GenrateReport_First();
                }
            }
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
            Reset();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnGenExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                if (rdbList.SelectedValue == "1")
                {
                    GenrateReport_ZeroExcel();
                }
                else if (rdbList.SelectedValue == "2")
                {
                    GenrateReport_FirstExcel();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}