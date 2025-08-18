using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;

public partial class Reports_frmTrimark : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {        
    }

    private Boolean ValidationCheck()
    {
        try
        {
            if (rdbList.SelectedValue == "" )
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select any Option. !');", true);
                rdbList.Focus();
                return false;
            }

            if (txtYear.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Year. !');", true);
                txtYear.Focus();
                return false;
            }
            if (rdbList.SelectedValue == "4")
            {
                if (ddlQuarter.SelectedValue == "-1")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Quarter. !');", true);
                    ddlQuarter.Focus();
                    return false;
                }
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        return true;
    }

    private DataTable ReportDataZero()
    {
        DataTable dt = new DataTable();
        try
        {
            String Year = txtYear.Text;
            string Qstr = String.Empty;
            string FQstr = String.Empty;
            Qstr += " DECLARE @sql     NVARCHAR(MAX) = ''; ";
            Qstr += " SET @sql='SELECT CompanyName,[1] as [January],[2] as [February],[3] as [March],[4] as [April],[5] as [May],[6] as [June],[7] as [July], [8] as [August], ";
            Qstr += " [9] as [September],[10] as [October],[11] as [November],[12] as [December] ";
            Qstr += " FROM ( SELECT qryTrimarkBase.[CompanyName], MONTH(PORec) AS PORec,qryTrimarkBase.CashAmtRec ";
            Qstr += " FROM qryTrimarkBase WHERE YEAR(PORec)=YEAR('' " + Year + " '') GROUP BY qryTrimarkBase.[CompanyName],PORec,CashAmtRec ";
            Qstr += " ) as p PIVOT ( SUM(CashAmtRec) FOR [PORec] IN ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12]) ";
            Qstr += " ) AS Pivot_Table' EXEC sp_executesql @sql ";

            //Qstr += " DECLARE @sql     NVARCHAR(MAX) = ''; ";
            //Qstr += " SET @sql='SELECT CompanyName,[1] as [January],[2] as [February],[3] as [March],[4] as [April],[5] as [May],[6] as [June],[7] as [July], [8] as [August], ";
            //Qstr += " [9] as [September],[10] as [October],[11] as [November],[12] as [December] ";
            //Qstr += " FROM ( SELECT qryTrimarkBaseRebate.[CompanyName], MONTH(DateInvoiceSent) AS DateInvoiceSent,qryTrimarkBaseRebate.NetEqPrice ";
            //Qstr += " FROM qryTrimarkBaseRebate WHERE YEAR(DateInvoiceSent)=YEAR('' " + Year + " '') GROUP BY qryTrimarkBaseRebate.[CompanyName],DateInvoiceSent,NetEqPrice ";
            //Qstr += " ) as p PIVOT ( SUM(NetEqPrice) FOR [DateInvoiceSent] IN ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12]) ";
            //Qstr += " ) AS Pivot_Table' EXEC sp_executesql @sql ";

            FQstr = Qstr;
            clscon.Return_DT(dt, FQstr);
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
            String Year = txtYear.Text;
            divError.Visible = true;            
            DataTable dt = ReportDataZero();
            rprt.Load(Server.MapPath("~/Reports/rptTrimarkPivot.rpt"));            
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "  Trimark Gross Purchases " + Year;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "  Trimark Gross Purchases " + Year;
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
            String Year = txtYear.Text;
            divError.Visible = true;
            DataTable dt = ReportDataZero();
            rprt.Load(Server.MapPath("~/Reports/rptTrimarkPivot.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "  Trimark Gross Purchases " + Year;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "  Trimark Gross Purchases " + Year;
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
            String Year = txtYear.Text;
            string Qstr = String.Empty;
            string FQstr = String.Empty;
            Qstr += " DECLARE @sql NVARCHAR(MAX) = ''; ";
            Qstr += " SET @sql='SELECT CompanyName,[1] as [January],[2] as [February],[3] as [March],[4] as [April],[5] as [May],[6] as [June],[7] as [July], [8] as [August], ";
            Qstr += " [9] as [September],[10] as [October],[11] as [November],[12] as [December] ";
            Qstr += " FROM ( SELECT qryTrimarkBaseRebate.[CompanyName], MONTH(DateInvoiceSent) AS DateInvoiceSent,qryTrimarkBaseRebate.CashAmtRec ";
            Qstr += " FROM qryTrimarkBaseRebate WHERE YEAR(DateInvoiceSent)=YEAR('' " + Year + " '') GROUP BY qryTrimarkBaseRebate.[CompanyName],DateInvoiceSent,CashAmtRec ";
            Qstr += " ) as p PIVOT ( SUM(CashAmtRec) FOR [DateInvoiceSent] IN ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12]) ";
            Qstr += " ) AS Pivot_Table' EXEC sp_executesql @sql ";
            FQstr = Qstr;
            clscon.Return_DT(dt, FQstr);
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
            divError.Visible = true;
            String Year = txtYear.Text;
            DataTable dt = ReportDataFirst();
            rprt.Load(Server.MapPath("~/Reports/rptRebatableTrimarkPivot.rpt"));            
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "  Trimark Rebatable Purchases " + Year;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "  Trimark Rebatable Purchases " + Year;
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
            divError.Visible = true;
            DataTable dt = new DataTable();
            DateTime dtfrom = Convert.ToDateTime("01/01/" + txtYear.Text);
            DateTime dtto = Convert.ToDateTime("12/31/" + txtYear.Text);
            int year = dtfrom.Year;
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptTrimark.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_Trimark] '" + strDateFrom + "','" + strDateTo + "'");
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "TriMark Corporate Rebate Program " + year;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "TriMark Corporate Rebate Program " + year;
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

    private void GenrateReport_last()
    {
        try
        {
            divError.Visible = true;
            DataTable dt = new DataTable();
            DateTime dtfrom = Convert.ToDateTime("01/01/" + txtYear.Text);
            DateTime dtto = Convert.ToDateTime("12/31/" + txtYear.Text);
            int year = dtfrom.Year;
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptTrimark.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_TrimarkQuarterly] '" + strDateFrom + "','" + strDateTo + "'");
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "TriMark Corporate Rebate Program " + year;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "TriMark Corporate Rebate Program " + year;
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
            divError.Visible = true;
            String Year = txtYear.Text;
            DataTable dt = ReportDataFirst();
            rprt.Load(Server.MapPath("~/Reports/rptRebatableTrimarkPivot.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "  Trimark Rebatable Purchases " + Year;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "  Trimark Rebatable Purchases " + Year;
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

    private void GenrateReport_Second_Excel()
    {
        try
        {
            divError.Visible = true;
            DataTable dt = new DataTable();
            DateTime dtfrom = Convert.ToDateTime("01/01/" + txtYear.Text);
            DateTime dtto = Convert.ToDateTime("12/31/" + txtYear.Text);
            int year = dtfrom.Year;
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptTrimark.rpt"));
            clscon.Return_DT(dt, "EXEC [dbo].[Get_Trimark] '" + strDateFrom + "','" + strDateTo + "'");
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "TriMark Corporate Rebate Program " + year;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "TriMark Corporate Rebate Program " + year;
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
            txtYear.Text = String.Empty;
            ddlQuarter.SelectedValue = "-1";
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
                else if (rdbList.SelectedValue == "3")
                {
                    GenrateReport_Second();
                }
                else if (rdbList.SelectedValue == "4")
                {
                    GenrateQuarterlyReport();
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
                else if (rdbList.SelectedValue == "3")
                {
                    GenrateReport_Second_Excel();
                }
                else if (rdbList.SelectedValue == "4")
                {
                    GenrateQuarterlyReportExcel();
                }
            }
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
            ddlQuarter.SelectedIndex = 0;
            if(rdbList.SelectedValue=="1" || rdbList.SelectedValue == "2" || rdbList.SelectedValue == "3")
            {
                ddlQuarter.Enabled = false;
            }
            else
            {
                ddlQuarter.Enabled = true;
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
            clscon.Return_DT(dt, "EXEC [dbo].[Get_TrimarkQuarterly] '" + txtYear.Text + "','" + ddlQuarter.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }


    private void GenrateQuarterlyReport()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                divError.Visible = true;
                DataTable dt = ReportData();
                string year = txtYear.Text;               
                string quarterName = string.Empty;
                if (ddlQuarter.SelectedIndex == 0)
                {
                    quarterName = "";
                }
                else
                {
                    quarterName = ddlQuarter.SelectedItem.Text + " Quarter";
                }
                rprt.Load(Server.MapPath("~/Reports/rptTrimarkQuarterly.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Trimark Quarterly Report for " + quarterName + " " + year + "";
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Trimark Quarterly Report for " + quarterName + " " + year + "";
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
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

    private void GenrateQuarterlyReportExcel()
    {
        try
        {
            divError.Visible = true;
            DataTable dt = ReportData();
            string year = txtYear.Text;
            string quarterName = string.Empty;
            if (ddlQuarter.SelectedIndex == 0)
            {
                quarterName = "";
            }
            else
            {
                quarterName = ddlQuarter.SelectedItem.Text + " Quarter";
            }
            rprt.Load(Server.MapPath("~/Reports/rptTrimarkQuarterly.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Trimark Quarterly Report for " + quarterName + " " + year + "";
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Trimark Quarterly Report for " + quarterName + " " + year + "";
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
}