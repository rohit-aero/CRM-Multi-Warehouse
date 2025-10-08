using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;

public partial class TurboWash_FrmITWProjectsReport_V1 : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument();
    commonclass1 commonClass = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
            SetDates();
        }
    }

    private void SetDates()
    {
        try
        {
            txtPODateFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            txtPODateTo.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
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
            commonClass.Return_DT(dt, "Exec Get_ITWProjects_V1_Report 2 ");
            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlPOType, dt);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "EXEC Get_ITWProjects_V1_Report 1, '' ";
            if (ddlPOType.SelectedIndex > 0)
            {
                query += ", " + ddlPOType.SelectedValue;
            }
            else
            {
                query += ", 0 ";
            }

            if (txtPODateFrom.Text != "" && txtPODateTo.Text != "")
            {
                query += ", '" + txtPODateFrom.Text + "' ";
                query += ", '" + txtPODateTo.Text + "' ";
            }
            commonClass.Return_DT(dt, query);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private bool ValidationCheck()
    {
        try
        {
            //if (txtPODateFrom.Text == "")
            //{
            //    Utility.ShowMessage_Error(Page, "Please enter PO Received From Date !");
            //    txtPODateFrom.Focus();
            //    return false;
            //}

            //if (txtPODateTo.Text == "")
            //{
            //    Utility.ShowMessage_Error(Page, "Please enter PO Received To Date !");
            //    txtPODateTo.Focus();
            //    return false;
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                DataTable dt = ReportData();
                rprt.Load(Server.MapPath("~/TurboWash/rptITWProjects_V1.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtPODateFrom.Text.Trim() != "" && txtPODateTo.Text.Trim() != "")
                    {
                        txtheader.Text = "ITW Projects From " + txtPODateFrom.Text + " to " + txtPODateTo.Text;
                    }
                    else
                    {
                        txtheader.Text = "ITW Projects";
                    }
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtPODateFrom.Text.Trim() != "" && txtPODateTo.Text.Trim() != "")
                    {
                        txtheader.Text = "ITW Projects From " + txtPODateFrom.Text + " to " + txtPODateTo.Text;
                    }
                    else
                    {
                        txtheader.Text = "ITW Projects";
                    }
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please Select Job !");
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
            ddlPOType.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}