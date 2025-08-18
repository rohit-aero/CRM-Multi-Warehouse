using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_FrmSalesActivityReport_V1 : System.Web.UI.Page
{
    BOLSalesActivity ObjBOL = new BOLSalesActivity();
    BLLSalesActivity ObjBLL = new BLLSalesActivity();
    ReportDocument rprt = new ReportDocument();
    commonclass1 cls = new commonclass1();
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
            ObjBOL.Operation = 1;
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlStakeholder, ds.Tables[0]);
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlEmployees, ds.Tables[2]);
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

    private DataTable ReportData()
    {
        DataSet ds = new DataSet();
        try
        {
            ObjBOL.Operation = 21;
            ObjBOL.Date = Utility.ConvertDate(txtDateFrom.Text);
            ObjBOL.Date1 = Utility.ConvertDate(txtDateTo.Text);
            if (ddlEmployees.SelectedIndex > 0)
            {
                ObjBOL.UserID = Int32.Parse(ddlEmployees.SelectedValue);
            }
            if (ddlStakeholder.SelectedIndex > 0)
            {
                ObjBOL.StakeHolderId = Int32.Parse(ddlStakeholder.SelectedValue);
            }

            if (ddlCompany.SelectedIndex > 0)
            {
                ObjBOL.CompanyId = Int32.Parse(ddlCompany.SelectedValue);
            }
            ds = ObjBLL.Return_DataSet(ObjBOL);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return ds.Tables[0];
    }

    private DataTable ReportData_SubReport_Followup()
    {
        DataTable dt = new DataTable();
        try
        {
            cls.Return_DT(dt, "EXEC [Get_SalesActivity] 2");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportData_SubReport_TravelLogs()
    {
        DataTable dt = new DataTable();
        try
        {
            cls.Return_DT(dt, "EXEC [Get_SalesActivity] 3");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void ddlStakeholder_SelectedIndexChanged()
    {
        try
        {
            if (ddlStakeholder.SelectedIndex > 0)
            {
                ObjBOL.Operation = 20;
                ObjBOL.StakeHolderId = Int32.Parse(ddlStakeholder.SelectedValue);
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    Utility.BindDropDownListAll(ddlCompany, dt);
                }
                else
                {
                    ddlCompany.Items.Clear();
                }
            }
            else
            {
                ddlCompany.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtMain = ReportData();
            DataTable dtSubReport = ReportData_SubReport_Followup();
            DataTable dtSubReport_Travel = ReportData_SubReport_TravelLogs();
            rprt.Load(Server.MapPath("~/Reports/rptSalesActivity_V1.rpt"));
            if (dtMain.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];

                if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                {
                    txtheader.Text = "Sales Activity Report From " + txtDateFrom.Text + " to " + txtDateTo.Text;
                }
                else
                {
                    txtheader.Text = "Sales Activity Report ";
                }
                rprt.SetDataSource(dtMain);
                rprt.Subreports[0].SetDataSource(dtSubReport);
                rprt.Subreports[1].SetDataSource(dtSubReport_Travel);
                rprtSalesActivity.ReportSource = rprt;
                rprtSalesActivity.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtDateFrom.Text != "" && txtDateTo.Text != "")
                {
                    txtheader.Text = "Sales Activity Report From " + txtDateFrom.Text + " to " + txtDateTo.Text;
                }
                else
                {
                    txtheader.Text = "Sales Activity Report ";
                }
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
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
            ddlStakeholder.SelectedIndex = 0;
            ddlCompany.Items.Clear();
            ddlEmployees.SelectedIndex = 0;
            SetDates();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlStakeholder_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlStakeholder_SelectedIndexChanged();
    }
}