using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Reports_FrmSalesActivityReport_V2 : System.Web.UI.Page
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
            DataTable dt = new DataTable();
            cls.Return_DT(dt, "EXEC Get_SalesActivityReport_V2 1");

            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectManager, dt);
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

    protected void ddlDateType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDateType.SelectedValue == "0")
            {
                lblFrom.InnerText = "Activity Date From";
                lblTo.InnerText = "Activity Date To";
            }
            else if (ddlDateType.SelectedValue == "1")
            {
                lblFrom.InnerText = "Proposal Date From";
                lblTo.InnerText = "Proposal Date To";
            }
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
            string selectedFilters = "";
            var index = 0;
            foreach (ListItem item in ddlOtherFilter.Items)
            {
                if (item.Selected && index == 0)
                {
                    selectedFilters = "'" + item.Value;
                    index++;
                }
                else if (item.Selected && index > 0)
                {
                    selectedFilters += "," + item.Value;
                    index++;
                }
            }

            if (index > 0)
            {
                selectedFilters += "'";
            }
            else
            {
                selectedFilters = "''";
            }

            string query = "EXEC Get_SalesActivityReport_V2 2, " + ddlDateType.SelectedValue + ", '" + txtDateFrom.Text + "', '" + txtDateTo.Text + "', " + ddlProjectManager.SelectedValue + ", " + selectedFilters;
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
                rprt.Load(Server.MapPath("~/Reports/rptSalesActivity_V2.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    TextObject dynamicDateLabel = (TextObject)rprt.ReportDefinition.ReportObjects["DynamicDateLabel"];
                    if (ddlDateType.SelectedValue == "0")
                    {
                        dynamicDateLabel.Text = "Activity Date";
                    }
                    else
                    {
                        dynamicDateLabel.Text = "Proposal Date";
                    }

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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlProjectManager.Items.Count > 0)
            {
                ddlProjectManager.SelectedIndex = 0;
            }

            if (ddlDateType.Items.Count > 0)
            {
                ddlDateType.SelectedIndex = 0;
            }

            SetDates();

            foreach (ListItem item in ddlOtherFilter.Items)
            {
                item.Selected = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}