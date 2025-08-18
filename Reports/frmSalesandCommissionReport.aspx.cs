using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;

public partial class Reports_frmSalesandCommissionReport : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindControls();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable BindControls()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[Get_HobartReport] ");
            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlYear, dt);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    // check if data filled in required fields
    private Boolean ValidationCheck()
    {
        try
        {
            if (ddlYear.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Year. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Year. !!");
                ddlYear.Focus();
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
                else if (id == "1")
                {
                    GenrateReport_First();
                }
                else if (id == "2")
                {
                    GenrateReport_Second();
                }
                else if (id == "3")
                {
                    GenrateReport_Third();
                }
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

    private DataTable ReportDataZero()
    {
        DataTable dt = new DataTable();
        try
        {
            string YEAR = ddlYear.SelectedItem.Text;
            clscon.Return_DT(dt, "EXEC [dbo].[Get_SalesandComm2019] '" + YEAR + "'");
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
            DataTable dt = ReportDataZero();
            rprt.Load(Server.MapPath("~/Reports/rptSalesandCommission2019.rpt"));
            if (dt.Rows.Count > 0)
            {
                //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                //scriptManager.RegisterPostBackControl(this.btnGenrate);                          
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Sales and Commission Report " + ddlYear.SelectedItem.Text;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Sales and Commission Report " + ddlYear.SelectedItem.Text;
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

    private DataTable ReportDataFirst()
    {
        DataTable dt = new DataTable();
        try
        {
            string YEAR = ddlYear.SelectedItem.Text;
            clscon.Return_DT(dt, "EXEC [dbo].[Get_YTDRepGroupandRegioOpenP#] '" + YEAR + "'");
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
            DataTable dt = ReportDataFirst();

            rprt.Load(Server.MapPath("~/Reports/rptOpenpnumber.rpt"));

            if (dt.Rows.Count > 0)
            {
                //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                //scriptManager.RegisterPostBackControl(this.btnGenrate);                          
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Opportunities Report " + ddlYear.SelectedItem.Text;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Opportunities Report " + ddlYear.SelectedItem.Text;
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

    private DataTable ReportDataSecond()
    {
        DataTable dt = new DataTable();
        try
        {
            string YEAR = ddlYear.SelectedItem.Text;
            clscon.Return_DT(dt, "EXEC [dbo].[Get_YTDOrdersSalesReport] '" + YEAR + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport_Second()
    {
        try
        {
            DataTable dt = ReportDataSecond();

            rprt.Load(Server.MapPath("~/Reports/rptYTDSalesRepReport.rpt"));

            if (dt.Rows.Count > 0)
            {
                //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                //scriptManager.RegisterPostBackControl(this.btnGenrate);                          
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Sales Report " + ddlYear.SelectedItem.Text;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Sales Report " + ddlYear.SelectedItem.Text;
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

    private DataTable ReportDataThird()
    {
        DataTable dt = new DataTable();
        try
        {
            string YEAR = ddlYear.SelectedItem.Text;
            clscon.Return_DT(dt, "EXEC [dbo].[Get_EPISalesReport] '" + 2 + "','" + YEAR + "'");
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport_Third()
    {
        try
        {
            DataTable dt = ReportDataThird();

            rprt.Load(Server.MapPath("~/Reports/rptSalesandOppreport.rpt"));

            if (dt.Rows.Count > 0)
            {
                //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                //scriptManager.RegisterPostBackControl(this.btnGenrate);                          
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Opportunities Report Rep Group Wise " + ddlYear.SelectedItem.Text;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Opportunities Report Rep Group Wise " + ddlYear.SelectedItem.Text;
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

    private DataTable ReportDataFourth()
    {
        DataTable dt = new DataTable();
        try
        {
            string YEAR = ddlYear.SelectedItem.Text;
            clscon.Return_DT(dt, "EXEC [dbo].[Get_EPISalesReport] '" + 1 + "','" + YEAR + "'");
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport_Fourth()
    {
        try
        {
            DataTable dt = ReportDataFourth();

            rprt.Load(Server.MapPath("~/Reports/rptSalesandOppreport.rpt"));

            if (dt.Rows.Count > 0)
            {
                //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                //scriptManager.RegisterPostBackControl(this.btnGenrate);                          
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Sales Report Rep Group Wise " + ddlYear.SelectedItem.Text;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Sales Report Rep Group Wise " + ddlYear.SelectedItem.Text;
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
            if (ValidationCheck() == true)
            {
                Check_Url(rdbList.SelectedValue);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
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
            ddlYear.SelectedIndex = 0;
            rdbList.ClearSelection();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void rdbList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if(rdbList.SelectedValue=="1")
            //{
            //    ddlYear.SelectedValue = "2022";
            //}
            //else
            //{
            //    ddlYear.SelectedValue = "";
            //}
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }
}