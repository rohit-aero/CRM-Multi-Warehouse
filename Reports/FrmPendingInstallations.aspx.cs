using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Reports_FrmPendingInstallations : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
            SetDates();
        }
    }

    private void BindControls()
    {
        try
        {
            DataTable dt = new DataTable();
            clscon.Return_DT(dt, "EXEC Get_PendingInstallations 1");
            if (dt.Rows.Count > 0)
            {
                ddlTechinician.DataSource = dt;
                ddlTechinician.DataBind();
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

    private bool ValidationCheck()
    {
        try
        {
            if (txtDateFrom.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter From Date !");
                txtDateFrom.Focus();
                return false;
            }

            if (txtDateTo.Text.Trim() == "")
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
            var index = 0;
            string priority = ddlInstallationPriority.SelectedValue;
            string technician = string.Empty;
            foreach (ListItem item in ddlTechinician.Items)
            {
                if (item.Selected && index == 0)
                {
                    technician += "" + item.Value + "";
                    index++;
                }
                else if (item.Selected && index > 0)
                {
                    technician += "," + item.Value + "";
                    index++;
                }
            }

            string query = "EXEC Get_PendingInstallations 2, '" + Utility.ConvertDate(txtDateFrom.Text) + "', '" + Utility.ConvertDate(txtDateTo.Text) + "', '" + technician + "', " + rdbDateSettings.SelectedValue + ", '" + priority + "'";
            clscon.Return_DT(dt, query);
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
                if (dt.Rows.Count > 0)
                {
                    rprt.Load(Server.MapPath("~/Reports/rptPendingInstallations.rpt"));
                    if (dt.Rows.Count > 0)
                    {
                        TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                        if (rdbDateSettings.SelectedValue == "1")
                        {
                            txtheader.Text = "All Pending Installations";
                        }
                        else
                        {
                            txtheader.Text = "Pending Installations From " + txtDateFrom.Text + " to " + txtDateTo.Text;
                        }
                        rprt.SetDataSource(dt);
                        rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                    }
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (rdbDateSettings.SelectedValue == "1")
                    {
                        txtheader.Text = "All Pending Installations";
                    }
                    else
                    {
                        txtheader.Text = "Pending Installations From " + txtDateFrom.Text + " to " + txtDateTo.Text;
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
            SetDates();
            if (ddlTechinician.Items.Count > 0)
            {
                foreach (ListItem item in ddlTechinician.Items)
                {
                    item.Selected = false;
                }
            }
            rdbDateSettings.SelectedValue = "2";
            ddlInstallationPriority.SelectedIndex = 0;
            txtDateFrom.Enabled = true;
            txtDateTo.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void rdbDateSettings_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdbDateSettings.SelectedValue == "1")
            {
                txtDateFrom.Enabled = false;
                txtDateTo.Enabled = false;
            }
            else if (rdbDateSettings.SelectedValue == "2")
            {
                txtDateFrom.Enabled = true;
                txtDateTo.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}