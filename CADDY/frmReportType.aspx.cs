using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CADDY_frmReportType : System.Web.UI.Page
{
    BOLCADDYENGTasks ObjBOL = new BOLCADDYENGTasks();
    BLLManageCADDYENGTasks ObjBLL = new BLLManageCADDYENGTasks();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    int ReportType = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Utility.IsAuthorized())
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
                txtToDate.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
                Bind_Controls();
            }
        }

    }

    private void Bind_Controls()
    {
        try
        {
            DataTable dt = new DataTable();
            clscon.Return_DT(dt, "EXEC [dbo].[Caddy_EngTasks] 11");
            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectType, dt);
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
            if (ddlOpenReport.SelectedValue == "0")
            {
                Utility.ShowMessage_Error(Page, "Please Select Report Type !");
                ddlOpenReport.Focus();
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
        DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
        DateTime dtto = Convert.ToDateTime(txtToDate.Text);
        string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
        string strDateTo = dtto.ToString("MM/dd/yyyy");
        try
        {
            ReportType = Convert.ToInt32(ddlOpenReport.SelectedValue);
            clscon.Return_DT(dt, "EXEC [dbo].[CADDY_EngTaskReport_Conveeyor] '" + ddlJobType.SelectedItem.Text + "','" + strDateFrom + "','" + strDateTo + "','" + ReportType + "','" + ddlProjectType.SelectedItem.Text + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenReport_Caddy()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportData();
            rprt.Load(Server.MapPath("~/CADDY/rptEngTaskReport_Caddy.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT FROM " + txtFromDate.Text + " TO " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                rprt.Close();
                rprt.Dispose();
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT FROM " + txtFromDate.Text + " TO " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT ";
                }
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            if (ex.ToString() != "Thread was being aborted.")
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

    private DataTable ReportDataHood()
    {
        DataTable dt = new DataTable();
        DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
        DateTime dtto = Convert.ToDateTime(txtToDate.Text);
        string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
        string strDateTo = dtto.ToString("MM/dd/yyyy");
        try
        {
            ReportType = Convert.ToInt32(ddlOpenReport.SelectedValue);
            clscon.Return_DT(dt, "EXEC [dbo].[CADDY_EngTaskReport_Hood] '" + ddlJobType.SelectedItem.Text + "','" + strDateFrom + "','" + strDateTo + "','" + ReportType + "','" + ddlProjectType.SelectedItem.Text + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }


    private void GenReport()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportData();
            rprt.Load(Server.MapPath("~/CADDY/rptEngTaskReport.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT FROM " + txtFromDate.Text + " TO " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                rprt.Close();
                rprt.Dispose();
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT FROM " + txtFromDate.Text + " TO " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT ";
                }
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            if (ex.ToString() != "Thread was being aborted.")
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

    private void GenReportHood()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataHood();
            rprt.Load(Server.MapPath("~/CADDY/rptEngTaskReportHood.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT FROM " + txtFromDate.Text + " TO " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                rprt.Close();
                rprt.Dispose();
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT FROM " + txtFromDate.Text + " TO " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT ";
                }
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            if (ex.ToString() != "Thread was being aborted.")
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


    private void GenReportHood_Caddy()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataHood();
            rprt.Load(Server.MapPath("~/CADDY/rptEngTaskReportHood_Caddy.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT FROM " + txtFromDate.Text + " TO " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                rprt.Close();
                rprt.Dispose();
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT FROM " + txtFromDate.Text + " TO " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "CADDY ENGINEERING MONTHLY REPORT ";
                }
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            if (ex.ToString() != "Thread was being aborted.")
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

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {

                    if (ddlJobType.SelectedValue == "0")
                    {
                        if (ddlOpenReport.SelectedValue == "1")
                        {
                            GenReport();
                        }
                        else if (ddlOpenReport.SelectedValue == "2")
                        {
                            GenReport_Caddy();
                        }
                    }
                    else if (ddlJobType.SelectedValue == "1")
                    {
                        if (ddlOpenReport.SelectedValue == "1")
                        {
                            GenReport();
                        }
                        else if (ddlOpenReport.SelectedValue == "2")
                        {
                            GenReport_Caddy();
                        }
                    }
                    else if (ddlJobType.SelectedValue == "2")
                    {
                        if (ddlOpenReport.SelectedValue == "1")
                        {
                            GenReportHood();
                        }
                        else if (ddlOpenReport.SelectedValue == "2")
                        {
                            GenReportHood_Caddy();
                        }
                    }
                }
                else
                {
                    if (txtFromDate.Text == "")
                    {
                        Utility.ShowMessage_Error(Page, "Please Enter From Date !!");
                    }
                    if (txtToDate.Text == "")
                    {
                        Utility.ShowMessage_Error(Page, "Please Enter To Date !!");
                    }
                }

            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddlJobType.SelectedIndex = 0;
            ddlOpenReport.SelectedValue = "1";
            ddlProjectType.SelectedIndex = 0;
            txtFromDate.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            txtToDate.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlJobType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlOpenReport.SelectedValue = "1";
            if (ddlProjectType.Items.Count > 0)
            {
                ddlProjectType.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlOpenReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlProjectType.Items.Count > 0)
            {
                ddlProjectType.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}