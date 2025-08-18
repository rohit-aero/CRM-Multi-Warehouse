using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Web.UI;

public partial class Reports_FrmPostInstallFollowupsReport : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument();
    commonclass1 cls = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
            SetDates();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
        }
    }

    private void SetDates()
    {
        try
        {
            txtFromDate.Text = "01/01/" + DateTime.Now.Year;
            txtToDate.Text = "12/31/" + DateTime.Now.Year;
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
            cls.Return_DT(dt, "EXEC [Get_PostInstallFollowupsReport] 1");
            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlState, dt);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationCheck()
    {
        try
        {
            if (txtFromDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter From date !");
                txtFromDate.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
                return false;
            }

            if (txtToDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter To date !");
                txtToDate.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
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
            string query = "Exec Get_PostInstallFollowupsReport 2, '" + txtFromDate.Text + "', '" + txtToDate.Text + "', " + ddlState.SelectedValue + ", '" + ddlFilterReportOn.SelectedValue + "' ";
            cls.Return_DT(dt, query);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                DataTable dt = ReportData();
                rprt.Load(Server.MapPath("~/Reports/rptPostInstallFollowups.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtFromDate.Text != "" && txtToDate.Text != "")
                    {
                        txtheader.Text = "Post Install  Followups From " + txtFromDate.Text + " to " + txtToDate.Text;
                    }
                    else
                    {
                        txtheader.Text = "Post Install  Followups";
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
                        txtheader.Text = "Post Install  Followups From " + txtFromDate.Text + " to " + txtToDate.Text;
                    }
                    else
                    {
                        txtheader.Text = "Post Install  Followups";
                    }
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
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