using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Reports_FrmSalesActivityReport_V3 : System.Web.UI.Page
{
    commonclass1 cls = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetDates();
            BindControls();
        }
    }

    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            cls.Return_DS(ds, "EXEC Get_SalesActivityReport_V3 1");

            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectManager, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlStakeHolder, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SetDates()
    {
        try
        {
            txtDateFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            txtDateTo.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
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
            if (ddlProjectManager.Items.Count > 0)
            {
                ddlProjectManager.SelectedIndex = 0;
            }

            if (ddlStakeHolder.Items.Count > 0)
            {
                ddlStakeHolder.SelectedIndex = 0;
            }

            SetDates();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Boolean ValidationCheck()
    {
        try
        {
            if (txtDateFrom.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter From Date !");
                txtDateFrom.Focus();
                return false;
            }

            if (txtDateTo.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter To Date !");
                txtDateTo.Focus();
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
            string query = "EXEC Get_SalesActivityReport_V3 2, '" + txtDateFrom.Text + "', '" + txtDateTo.Text + "', " + ddlProjectManager.SelectedValue + ", " + ddlStakeHolder.SelectedValue;
            cls.Return_DT(dt, query);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                DataTable dt = ReportData();
                rprt.Load(Server.MapPath("~/Reports/rptSalesActivity_V3.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                    {
                        txtheader.Text = "Sales Activity From " + txtDateFrom.Text + " to " + txtDateTo.Text;
                    }
                    else
                    {
                        txtheader.Text = "Sales Activity Report ";
                    }
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                    {
                        txtheader.Text = "Sales Activity From " + txtDateFrom.Text + " to " + txtDateTo.Text;
                    }
                    else
                    {
                        txtheader.Text = "Sales Followup Report ";
                    }
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }
}