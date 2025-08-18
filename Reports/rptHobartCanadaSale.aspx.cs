using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
public partial class Reports_rptHobartCanadaSale : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = "01" + "/01/" + DateTime.Now.Year;
                txtToDate.Text = "12" + "/31/" + DateTime.Now.Year;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // check if data filled in required fields
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtFromDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter From Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter From Date. !!");
                txtFromDate.Focus();
                return false;
            }
            if (txtToDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter To Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter To Date. !!");
                txtToDate.Focus();
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
    private void Check_UrlPDF(string id)
    {
        try
        {
            if (id != null)
            {
                //
                if (id == "0")
                {
                    GenrateReport_Zero();
                }
                //Hobart Canada Sales
                else if (id == "1")
                {
                    GenrateReport_First();
                }
                //Hobart Sales Province
                else if (id == "2")
                {
                    GenrateReport_Second();
                }
                //Hobart Sales Province With Rep
                else if (id == "3")
                {
                    GenrateReport_Third();
                }
                else if (id == "4")
                {
                    GenerateReport_Fourth();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void Check_UrlEXCEL(string id)
    {
        try
        {
            if (id != null)
            {
                //
                if (id == "0")
                {
                    GenrateReport_ZeroExcel();
                }
                //Hobart Canada Sales
                else if (id == "1")
                {
                    GenrateReport_FirstExcel();
                }
                //Hobart Sales Province
                else if (id == "2")
                {
                    GenrateReport_SecondExcel();
                }
                //Hobart Sales Province With Rep
                else if (id == "3")
                {
                    GenrateReport_ThirdExcel();
                }
                else if (id == "4")
                {
                    GenerateReport_FourthExcel();
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

            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_HobartCommission] '" + strDateFrom + "','" + strDateTo + "'");
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
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptHobartCommission.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "  Commission Report From " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = "Commission Report ";
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
                    txtheader.Text = "Commission Report From " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = "Commission Report ";
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
            DataTable dt = ReportDataZero();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptHobartCommission.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Commission Report From " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = "Commission Report ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Commission Report From " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = "Commission Report ";
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

    private DataTable ReportDataFirst()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_HobartMonthlySales] '" + strDateFrom + "','" + strDateTo + "'");
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
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptHobartCanadaSales.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " TO " + strDateTo;
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT ";
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
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " TO " + strDateTo;
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT ";
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
            DataTable dt = ReportDataFirst();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptHobartCanadaSales.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " TO " + strDateTo;
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " TO " + strDateTo;
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT ";
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

    private DataTable ReportDataSecond()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_HobartSalesProvince] '" + strDateFrom + "','" + strDateTo + "'");
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
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptHobartSalesProvince.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " TO " + strDateTo + " (BY PROVINCE)";
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT (BY PROVINCE)";
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
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " TO " + strDateTo + " (BY PROVINCE)";
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT (BY PROVINCE)";
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

    private void GenrateReport_SecondExcel()
    {
        try
        {
            DataTable dt = ReportDataSecond();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptHobartSalesProvince.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " TO " + strDateTo + " (BY PROVINCE)";
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT (BY PROVINCE)";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " TO " + strDateTo + " (BY PROVINCE)";
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT (BY PROVINCE)";
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

    private DataTable ReportDataThird()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_HobartMonthlySales] '" + strDateFrom + "','" + strDateTo + "'");
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
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptHobartSalesProvinceWithRep.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " TO " + strDateTo + " (BY PROVINCE WITH SALES REP)";
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT (BY PROVINCE WITH SALES REP)";
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
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " TO " + strDateTo + " (BY PROVINCE WITH SALES REP)";
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT (BY PROVINCE WITH SALES REP)";
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

    private void GenrateReport_ThirdExcel()
    {
        try
        {
            DataTable dt = ReportDataThird();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptHobartSalesProvinceWithRep.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " TO " + strDateTo + " (BY PROVINCE)";
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM (BY PROVINCE)";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " TO " + strDateTo + " (BY PROVINCE)";
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM (BY PROVINCE)";
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

    private DataTable ReportDataFourth()
    {
        DataTable dt = new DataTable();
        try
        {
            string Qstr = String.Empty;
            string FQstr = String.Empty;
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("yyyy");
            string strDateTo = dtto.ToString("yyyy");
            Qstr += " DECLARE @sql     NVARCHAR(MAX) = ''; ";
            Qstr += " SET @sql='SELECT * FROM(SELECT DesRep,MONTH(DateInvoiceSent) AS DateInvoiceSent,qryHobartBase.NetEqPrice FROM qryHobartBase ";
            Qstr += " WHERE YEAR(DateInvoiceSent)= Year('' " + strDateFrom + " '')";
            Qstr += " GROUP BY qryHobartBase.[DesRep],DateInvoiceSent,NetEqPrice ";
            Qstr += " )AS t PIVOT ( SUM(NetEqPrice) FOR [DateInvoiceSent] IN ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12]) ";
            Qstr += " ) as Pivot_Table' EXEC sp_executesql @sql;";
            FQstr = Qstr;
            clscon.Return_DT(dt, FQstr);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenerateReport_Fourth()
    {
        try
        {

            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("yyyy");
            string strDateTo = dtto.ToString("yyyy");
            DataTable dt = ReportDataFourth();
            rprt.Load(Server.MapPath("~/Reports/rptHobartPivot.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT ";
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
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT ";
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

    private void GenerateReport_FourthExcel()
    {
        try
        {

            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("yyyy");
            string strDateTo = dtto.ToString("yyyy");
            DataTable dt = ReportDataFourth();
            rprt.Load(Server.MapPath("~/Reports/rptHobartPivot.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT FROM " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = "HOBART CANADA \nSALES REPORT ";
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

    // Genrate report here
    protected void btnGenrate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                Check_UrlPDF(rdbList.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnGenerateExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Check_UrlEXCEL(rdbList.SelectedValue);
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
            txtFromDate.Text = "01" + "/01/" + DateTime.Now.Year;
            txtToDate.Text = "12" + "/31/" + DateTime.Now.Year;
            rdbList.SelectedValue = "1";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}