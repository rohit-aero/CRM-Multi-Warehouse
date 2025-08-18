using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using BLLAERO;
using BOLAERO;

public partial class Reports_frmSpecCredit : System.Web.UI.Page
{
    BOLOpenProposalReports OBJBOL = new BOLOpenProposalReports();
    BLLOpenProposalReportDate OBJBLL = new BLLOpenProposalReportDate();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                int Month = DateTime.Now.Month + 2;
                txtFromDate.Text = "01" + "/01/" + DateTime.Now.Year;
                txtToDate.Text = "12" + "/31/" + DateTime.Now.Year;
                BindControls();
                if (rdbList.SelectedValue == "0")
                {
                    ddlCountry.SelectedValue = "2";
                }
                else
                {
                    ddlCountry.SelectedIndex = 0;
                }
            }
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
            DataSet ds = new DataSet();
            OBJBOL.Operation = 7;
            ds = OBJBLL.GetSalesReport(OBJBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlCountry, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlModel, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlDealer, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlConsultant, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlRep, ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlType, ds.Tables[5]);
            }
            // Utility.BindDropDownList(ddlCountry, Utility.GetCountries());
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

    private void Check_Url(string id)
    {
        try
        {
            if (id != null)
            {
                //State Wise
                if (id == "0")
                {
                    GenrateReport_Zero();
                }
                //CONVEYOR MODEL
                else if (id == "1")
                {
                    GenrateReport_First();
                }
                //DEALER
                else if (id == "2")
                {
                    GenrateReport_Second();
                }
                //CONSULTANT
                else if (id == "3")
                {
                    GenrateReport_Third();
                }
                //SALES REP
                else if (id == "4")
                {
                    GenrateReport_Fourth();
                }
                //CONVEYOR TYPE
                else if (id == "5")
                {
                    GenrateReport_Fifth();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Check_UrlExcel(string id)
    {
        try
        {
            if (id != null)
            {
                //STATE WISE
                if (id == "0")
                {
                    GenrateReport_ZeroExcel();
                }
                //CONVEYOR MODEL
                else if (id == "1")
                {
                    GenrateReport_FirstExcel();
                }
                //DEALERt
                else if (id == "2")
                {
                    GenrateReport_SecondExcel();
                }
                //CONSULTANT
                else if (id == "3")
                {
                    GenrateReport_ThirdExcel();
                }
                //SALES REP
                else if (id == "4")
                {
                    GenrateReport_FourthExcel();
                }
                //CONVEYOR TYPE
                else if (id == "5")
                {
                    GenrateReport_FifthExcel();
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
            string operation = string.Empty;
            if (ddlCountry.SelectedIndex > 0)
            {
                operation = "1";
            }
            else
            {
                operation = "8";
            }

            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_SalesRepGroupwithStates] '" + strDateFrom + "','" + strDateTo + "','" + ddlCountry.SelectedValue + "','" + operation + "'");
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

            rprt.Load(Server.MapPath("~/Reports/rptSalesRepGroupwithState.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text + ddlCountry.SelectedItem.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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

            rprt.Load(Server.MapPath("~/Reports/rptSalesRepGroupwithState.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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
            string operation = string.Empty;
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            if (ddlModel.SelectedIndex > 0)
            {
                operation = "12";
            }
            else
            {
                operation = "2";
            }
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_SalesRepGroupwithStates] '" + strDateFrom + "','" + strDateTo + "','" + ddlModel.SelectedValue + "','" + operation + "'");
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

            rprt.Load(Server.MapPath("~/Reports/rptSalesConveyorModel.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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

            rprt.Load(Server.MapPath("~/Reports/rptSalesConveyorModel.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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
            string operation = string.Empty;
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            if (ddlDealer.SelectedIndex > 0)
            {
                operation = "10";
            }
            else
            {
                operation = "3";
            }
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_SalesRepGroupwithStates] '" + strDateFrom + "','" + strDateTo + "','" + ddlDealer.SelectedValue + "','" + operation + "'");
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
            rprt.Load(Server.MapPath("~/Reports/rptSalesDealer.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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

            rprt.Load(Server.MapPath("~/Reports/rptSalesDealer.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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
            string operation = string.Empty;
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            if (ddlConsultant.SelectedIndex > 0)
            {
                operation = "11";
            }
            else
            {
                operation = "4";
            }
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_SalesRepGroupwithStates] '" + strDateFrom + "','" + strDateTo + "','" + ddlConsultant.SelectedValue + "','" + operation + "'");
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

            rprt.Load(Server.MapPath("~/Reports/rptSalesConsultant.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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

            rprt.Load(Server.MapPath("~/Reports/rptSalesConsultant.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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
            string operation = "5";
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            if (ddlRep.SelectedIndex > 0)
            {
                operation = "9";
            }
            else
            {
                operation = "5";
            }
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_SalesRepGroupwithStates] '" + strDateFrom + "','" + strDateTo + "','" + ddlRep.SelectedValue + "','" + operation + "'");
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
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptSalesRep.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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

    private void GenrateReport_FourthExcel()
    {
        try
        {
            DataTable dt = ReportDataThird();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptSalesRep.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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

    private DataTable ReportDataFifth()
    {
        DataTable dt = new DataTable();
        try
        {
            string operation = string.Empty;
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            if (ddlType.SelectedIndex > 0)
            {
                operation = "13";
            }
            else
            {
                operation = "6";
            }
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_SalesRepGroupwithStates] '" + strDateFrom + "','" + strDateTo + "','" + ddlType.SelectedValue + "','" + operation + "'");
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport_Fifth()
    {
        try
        {
            DataTable dt = ReportDataFifth();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptSalesConveyorType.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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

    private void GenrateReport_FifthExcel()
    {
        try
        {
            DataTable dt = ReportDataZero();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptSalesConveyorType.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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
                    txtheader.Text = "Sales Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Sales Report ";
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

    protected void btnGenrate_Click(object sender, EventArgs e)
    {
        try
        {
            if (rdbList.SelectedValue != "")
            {
                Check_Url(rdbList.SelectedValue);
            }
            else
            {
                Utility.ShowMessage(this, "Please Select Report Type !!");
            }

        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    //protected void rdbList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (rdbList.SelectedValue == "0")
    //    {

    //        ShowDiv.Attributes.Add("style", "display:block");
    //    }
    //    else
    //    {
    //        ShowDiv.Attributes.Add("style", "display:none");
    //        ddlCountry.SelectedIndex = 0;
    //    }
    //}

    protected void btnGenerateExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Check_UrlExcel(rdbList.SelectedValue);
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        int Month = DateTime.Now.Month + 2;
        txtFromDate.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
        txtToDate.Text = DateTime.Now.AddMonths(2).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.AddMonths(2).Year;
        rdbList.SelectedValue = "4";
    }
}