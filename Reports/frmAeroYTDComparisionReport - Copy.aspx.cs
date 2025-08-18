using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Linq;
using BOLAERO;
using BLLAERO;
public partial class Reports_frmAeroYTDComparisionReport : System.Web.UI.Page
{
    BOLHobartSalesbyTSM ObjBOL = new BOLHobartSalesbyTSM();
    BLLManageHobartSalesbyTSM ObjBLL = new BLLManageHobartSalesbyTSM();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindSalesTSM();
                int Month = DateTime.Now.Month + 2;
                txtFromDate.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
                txtEndDate.Text = DateTime.Now.AddMonths(2).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(2).Month) + "/" + DateTime.Now.AddMonths(2).Year;
                txtOpperStart.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
                txtOpperEnd.Text = DateTime.Now.AddMonths(2).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(2).Month) + "/" + DateTime.Now.AddMonths(2).Year;
                string startDate = "01/01/2021";
                string endDate = "06/30/2022";
                txtOpperFrom.Text = startDate;
                txtOpperTo.Text = endDate;
                txtTopOpperStart.Text = startDate;
                txtTopOpperEnd.Text = endDate;
                txtConFrom.Text = startDate;
                txtConTo.Text = endDate;
                txtDealerStartDate.Text = startDate;
                txtDealerEndDate.Text = endDate;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindSalesTSM()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ds = ObjBLL.GetSalesbyTSM(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlSalesbyAllTSM, ds.Tables[0]);
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
            if (ddlSalesbyAllTSM.SelectedValue == "0")
            {
                GenrateReport_First();
            }
            else
            {
                clscon.Return_DT(dt, "EXEC [Get_YTD_SalesbyTSM] '" + "1" + "','" + ddlSalesbyAllTSM.SelectedValue + "'");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportDataZeroPivot()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "[dbo].[Get_SalesbyTSMPivotIndividual]'" + ddlSalesbyAllTSM.SelectedValue + "'");
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
            string TSM = null;
            DataRow drCurrentRow = null;
            divError.Visible = false;
            DataTable dt = ReportDataZero();
            DataTable dt1 = ReportDataZeroPivot();
            for (int i = dt1.Rows.Count - 1; i >= 0; i--)
            {
                if (dt1.Rows[i]["2023"].ToString() == "")
                {
                    drCurrentRow = dt.NewRow();
                    TSM = dt1.Rows[i]["TSM"].ToString();
                    drCurrentRow["TSM"] = TSM;
                    dt.AcceptChanges();
                    dt.Rows.Add(drCurrentRow);
                }
                //DataRow dr = dt1.Rows[i];
                //if (dr["sortorder"].ToString() == sortorder)
                // dr.Delete();
            }
            rprt.Load(Server.MapPath("~/Reports/rptSalesbyTSMIndividual.rpt"));
            if (dt.Rows.Count > 0)
            {
                rprt.SetDataSource(dt);
                rprt.Subreports[0].SetDataSource(dt1);
                rptSales.ReportSource = rprt;
                rptSales.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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
            clscon.Return_DT(dt, "[dbo].[Get_SalesbyTSM_YearlyTotal] ");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportDataFirstPivot()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "[dbo].[Get_SalesbyTSMPivot]");
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
            string TSM = null;
            divError.Visible = false;
            DataTable dt = ReportDataFirst();
            DataRow drCurrentRow = null;
            DataTable dt1 = ReportDataFirstPivot();
            for (int i = dt1.Rows.Count - 1; i >= 0; i--)
            {
                if (dt1.Rows[i]["2023"].ToString() == "")
                {
                    drCurrentRow = dt.NewRow();
                    TSM = dt1.Rows[i]["TSM"].ToString();
                    drCurrentRow["TSM"] = TSM;
                    dt.AcceptChanges();
                    dt.Rows.Add(drCurrentRow);
                }
                //DataRow dr = dt1.Rows[i];
                //if (dr["sortorder"].ToString() == sortorder)
                // dr.Delete();
            }
            rprt.Load(Server.MapPath("~/Reports/rptSalesbyTSMYTD.rpt"));
            if (dt.Rows.Count > 0)
            {
                rprt.SetDataSource(dt);
                rprt.Subreports[0].SetDataSource(dt1);
                rptSales.ReportSource = rprt;
                rptSales.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private DataTable ReportDataSalesbyRep()
    {
        DataTable dt = new DataTable();
        string salesbyrepid = ddlSalesRep.SelectedValue;
        try
        {
            clscon.Return_DT(dt, "Exec [dbo].[Get_YTD_SalesRepGroup] '" + ddlSalesRep.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportDataSalesbyRepHobart()
    {
        DataTable dt = new DataTable();
        string salesbyrepid = ddlHobartSalesRep.SelectedValue;
        try
        {
            if (salesbyrepid == "1")
            {
                clscon.Return_DT(dt, "Exec [dbo].[Get_YTD_SalesRepGroup] '" + "13" + "'");
            }
            else if (salesbyrepid == "2")
            {
                clscon.Return_DT(dt, "Exec [dbo].[Get_YTD_SalesRepGroup] '" + "14" + "'");
            }
            else if (salesbyrepid == "3")
            {
                clscon.Return_DT(dt, "Exec [dbo].[Get_YTD_SalesRepGroup] '" + "11" + "'");
            }
            else if (salesbyrepid == "4")
            {
                clscon.Return_DT(dt, "Exec [dbo].[Get_YTD_SalesRepGroup] '" + "15" + "'");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportDataSalesbyRepAll()
    {
        DataTable dt = new DataTable();
        try
        {
            if (ddlSaleRepAll.SelectedValue == "0")
            {
                clscon.Return_DT(dt, "Exec [dbo].[Get_SalesRepSpecCreditProjects] '" + "0" + "'");
            }
            else
            {
                clscon.Return_DT(dt, "Exec [dbo].[Get_YTD_SalesRepGroupSpecCredit] '" + ddlSaleRepAll.SelectedValue + "'");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportDataSecondPivot()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "Exec [dbo].[Get_SalesbyRepPivot]");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable SalesbyRepHobart()
    {
        DataTable dt = new DataTable();
        string salesbyrepid = ddlHobartSalesRep.SelectedValue;
        try
        {
            if (salesbyrepid == "1")
            {
                clscon.Return_DT(dt, "Exec [dbo].[Get_SalesbyRepHobartPivot] '" + "1" + "'");
            }
            else if (salesbyrepid == "2")
            {
                clscon.Return_DT(dt, "Exec [dbo].[Get_SalesbyRepHobartPivot] '" + "2" + "'");
            }
            else if (salesbyrepid == "3")
            {
                clscon.Return_DT(dt, "Exec [dbo].[Get_SalesbyRepHobartPivot] '" + "3" + "'");
            }
            else if (salesbyrepid == "4")
            {
                clscon.Return_DT(dt, "Exec [dbo].[Get_SalesbyRepHobartPivot] '" + "4" + "'");
            }
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
            divError.Visible = false;
            DataTable dt = ReportDataSalesbyRep();
            DataTable dt1 = ReportDataSecondPivot();
            rprt.Load(Server.MapPath("~/Reports/rptSalesbyRep.rpt"));
            if (dt.Rows.Count > 0)
            {
                rprt.SetDataSource(dt);
                rprt.Subreports[0].SetDataSource(dt1);
                rptSales.ReportSource = rprt;
                rptSales.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private void GenrateReport_Third()
    {
        try
        {
            divError.Visible = false;
            DataTable dt = ReportDataSalesbyRepAll();
            //DataTable dt1 = ReportDataSecondPivot();
            rprt.Load(Server.MapPath("~/Reports/rptSalesRepSpecCreditProjects.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "All Rep Groups - Sales";
                rprt.SetDataSource(dt);
                rptSales.ReportSource = rprt;
                rptSales.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private void GenrateReport_Fourth()
    {
        try
        {
            divError.Visible = false;
            DataTable dt = ReportDataSalesbyRepHobart();
            DataTable dt1 = SalesbyRepHobart();
            string salesbyrepid = ddlHobartSalesRep.SelectedValue;
            rprt.Load(Server.MapPath("~/Reports/rptSalesbyRep Hobart.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlHobartSalesRep.SelectedItem.Text + "-Sales";
                TextObject txtPageHeader = (TextObject)rprt.ReportDefinition.ReportObjects["txtPageHeader"];
                txtPageHeader.Text = ddlHobartSalesRep.SelectedItem.Text; ;
                rprt.SetDataSource(dt);
                rprt.Subreports[0].SetDataSource(dt1);
                rptSales.ReportSource = rprt;
                rptSales.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtPageHeader.Text);
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private DataTable ReportDatafifth()
    {
        DataTable dt = new DataTable();
        try
        {
            //if (ddlSaleRepAll.SelectedIndex > 0)
            //{
            clscon.Return_DT(dt, "Exec [dbo].[Get_PMRSales] '" + ddlSaleRepAll.SelectedValue + "'");
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport_fifth()
    {
        try
        {
            divError.Visible = false;
            DataTable dt = ReportDatafifth();
            rprt.Load(Server.MapPath("~/Reports/rptPMRSalesActivityReport.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlSaleRepAll.SelectedItem.Text + "-Sales Activity Report";
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private DataTable ReportDataSixth2()
    {
        DataTable dt = new DataTable();
        try
        {
            if (ddlSaleRepAll.SelectedIndex == 0)
            {
                clscon.Return_DT(dt, "Exec [dbo].[Get_SalesRepSpecCreditProjects]  0");
            }
            else
            {
                clscon.Return_DT(dt, "Exec [dbo].[Get_SalesRepSpecCreditProjects]  " + ddlSaleRepAll.SelectedValue + "");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport_Sixth2()
    {
        try
        {
            divError.Visible = false;
            DataTable dt = ReportDataSixth2();
            rprt.Load(Server.MapPath("~/Reports/rptSalesRepSpecCreditProjects.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (ddlSaleRepAll.SelectedIndex == 0)
                {
                    txtheader.Text = "Spec Credit Report for All Rep Groups from 01/01/2019 to 12/31/2021";
                }
                else
                {
                    txtheader.Text = "Spec Credit Report for " + ddlSaleRepAll.SelectedItem.Text + " from 01/01/2019 to 12/31/2021";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private DataTable ReportDataSixth()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtEndDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            if (ddlOrders.SelectedValue == "0")
            {
                clscon.Return_DT(dt, "Exec [dbo].[aero_GetRepGroupPerformance] '" + "" + "','" + 0 + "','" + strDateFrom + "','" + strDateTo + "'");
            }
            else
            {
                clscon.Return_DT(dt, "Exec [dbo].[aero_GetRepGroupPerformance] '" + "" + "','" + ddlOrders.SelectedValue + "','" + strDateFrom + "','" + strDateTo + "'");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport_Sixth()
    {
        try
        {
            divError.Visible = false;
            DataTable dt = ReportDataSixth();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtEndDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            rprt.Load(Server.MapPath("~/Reports/rptOrdersReportRepGroup.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = " from " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private DataTable ReportDataSeventh()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtOpperStart.Text);
            DateTime dtto = Convert.ToDateTime(txtOpperEnd.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            if (ddlOppertunity.SelectedValue == "0")
            {
                clscon.Return_DT(dt, "Exec [dbo].[aero_GetRepGroupPerformance] '" + "" + "','" + 11 + "','" + strDateFrom + "','" + strDateTo + "'");
            }
            else
            {
                clscon.Return_DT(dt, "Exec [dbo].[aero_GetRepGroupPerformance] '" + "" + "','" + ddlOppertunity.SelectedValue + "','" + strDateFrom + "','" + strDateTo + "'");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport_Seventh()
    {
        try
        {
            divError.Visible = false;
            DateTime dtfrom = Convert.ToDateTime(txtOpperStart.Text);
            DateTime dtto = Convert.ToDateTime(txtOpperEnd.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportDataSeventh();
            rprt.Load(Server.MapPath("~/Reports/rptOpperRepGroup.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = " from " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private void GenrateReport_Eighth()
    {
        try
        {
            divError.Visible = false;
            DateTime dtfrom = Convert.ToDateTime(txtTopOpperStart.Text);
            DateTime dtto = Convert.ToDateTime(txtTopOpperEnd.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportDataEighth();
            rprt.Load(Server.MapPath("~/Reports/rptOpperRepGroupTopTwenty.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlRecCount.SelectedItem.Text + " Opportunities Report - " + ddlTopOpper.SelectedItem.Text + " \nfrom " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private DataTable ReportDataEighth()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtTopOpperStart.Text);
            DateTime dtto = Convert.ToDateTime(txtTopOpperEnd.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            if (ddlTopOpper.SelectedValue == "0")
            {
                //clscon.Return_DT(dt, "Exec [dbo].[aero_GetRepGroupPerformance] '" + "" + "','" + 11 + "','" + strDateFrom + "','" + strDateTo + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Rep Group. !');", true);
                ddlOppertunity.Focus();
            }
            else
            {
                clscon.Return_DT(dt, "Exec [dbo].[aero_GetRepGroupPerformance_TopTwenty] '" + ddlTopOpper.SelectedValue + "','" + ddlTopOpper.SelectedValue + "','" + strDateFrom + "','" + strDateTo + "', " + ddlRecCount.SelectedValue + "");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport_NinthTopTwenty()
    {
        try
        {
            divError.Visible = false;
            DateTime dtfrom = Convert.ToDateTime(txtOpperFrom.Text);
            DateTime dtto = Convert.ToDateTime(txtOpperTo.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportDataSalesbyRepHobartTopTwenty();
            rprt.Load(Server.MapPath("~/Reports/rptOpperRepGroupTopTwenty.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlTopHobart.SelectedItem.Text + " Opportunities Report - " + ddlOppRegion.SelectedItem.Text + " \nfrom " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private DataTable ReportDataSalesbyRepHobartTopTwenty()
    {
        DateTime dtfrom = Convert.ToDateTime(txtOpperFrom.Text);
        DateTime dtto = Convert.ToDateTime(txtOpperTo.Text);

        string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
        string strDateTo = dtto.ToString("MM/dd/yyyy");
        DataTable dt = new DataTable();
        string salesbyrepid = ddlOppRegion.SelectedValue;
        try
        {
            string oper = string.Empty;
            if (salesbyrepid == "1")
            {
                //Hobart North
                oper = "21";
            }
            else if (salesbyrepid == "2")
            {
                //Hobart South
                oper = "22";
            }
            else if (salesbyrepid == "3")
            {
                //Hobart West
                oper = "23";
            }
            else if (salesbyrepid == "4")
            {
                //Hobart West
                oper = "24";
            }
            clscon.Return_DT(dt, "Exec [dbo].[aero_GetRepGroupPerformance_TopTwenty] 0,'" + oper + "','" + strDateFrom + "','" + strDateTo + "', " + ddlTopHobart.SelectedValue + "");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    //11
    private void GenrateReport_Eleven()
    {
        try
        {
            divError.Visible = false;
            DateTime dtfrom = Convert.ToDateTime(txtConFrom.Text);
            DateTime dtto = Convert.ToDateTime(txtConTo.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportDataEleven();
            rprt.Load(Server.MapPath("~/Reports/rptConsultantSummary.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                TextObject txtPH = (TextObject)rprt.ReportDefinition.ReportObjects["txtPH"];
                txtheader.Text = ddlTopCon.SelectedItem.Text + " Consultants Summary Report \nfrom " + strDateFrom + " to " + strDateTo + " - By Value";
                txtPH.Text = ddlTopCon.SelectedItem.Text + " Consultants Summary Report- By Value";
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private DataTable ReportDataEleven()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtConFrom.Text);
            DateTime dtto = Convert.ToDateTime(txtConTo.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            if (strDateFrom == "")
            {
                //clscon.Return_DT(dt, "Exec [dbo].[aero_GetRepGroupPerformance] '" + "" + "','" + 11 + "','" + strDateFrom + "','" + strDateTo + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select From Date. !');", true);
                txtConFrom.Focus();
            }
            else
            {
                clscon.Return_DT(dt, "Exec [dbo].[aero_GetConsultantReport] '" + strDateFrom + "','" + strDateTo + "',1, " + ddlTopCon.SelectedValue + "");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    //12
    private void GenrateReport_Twelve()
    {
        try
        {
            divError.Visible = false;
            DateTime dtfrom = Convert.ToDateTime(txtConFrom.Text);
            DateTime dtto = Convert.ToDateTime(txtConTo.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportDataTwelve();
            rprt.Load(Server.MapPath("~/Reports/rptConsultantDetail.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                TextObject txtPH = (TextObject)rprt.ReportDefinition.ReportObjects["txtPH"];
                txtheader.Text = ddlTopCon.SelectedItem.Text + " Consultants Detail Report \nfrom " + strDateFrom + " to " + strDateTo + " - By Value";
                txtPH.Text = ddlTopCon.SelectedItem.Text + " Consultants Report- By Value";
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private DataTable ReportDataTwelve()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtConFrom.Text);
            DateTime dtto = Convert.ToDateTime(txtConTo.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            if (strDateFrom == "")
            {
                //clscon.Return_DT(dt, "Exec [dbo].[aero_GetRepGroupPerformance] '" + "" + "','" + 11 + "','" + strDateFrom + "','" + strDateTo + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select From Date. !');", true);
                ddlOppertunity.Focus();
            }
            else
            {
                clscon.Return_DT(dt, "Exec [dbo].[aero_GetConsultantReport] '" + strDateFrom + "','" + strDateTo + "',2, " + ddlTopCon.SelectedValue + "");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    //13
    private void GenrateReport_Thirteen()
    {
        try
        {
            divError.Visible = false;
            DateTime dtfrom = Convert.ToDateTime(txtConFrom.Text);
            DateTime dtto = Convert.ToDateTime(txtConTo.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportDataThirteen();
            rprt.Load(Server.MapPath("~/Reports/rptConsultantSummaryByState.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                TextObject txtPH = (TextObject)rprt.ReportDefinition.ReportObjects["txtPH"];
                txtheader.Text = ddlTopCon.SelectedItem.Text + " Consultants Summary Report \nfrom " + strDateFrom + " to " + strDateTo + " - By State";
                txtPH.Text = ddlTopCon.SelectedItem.Text + " Consultants Report- By State";
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private DataTable ReportDataThirteen()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtConFrom.Text);
            DateTime dtto = Convert.ToDateTime(txtConTo.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            if (strDateFrom == "")
            {
                //clscon.Return_DT(dt, "Exec [dbo].[aero_GetRepGroupPerformance] '" + "" + "','" + 11 + "','" + strDateFrom + "','" + strDateTo + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select From Date. !');", true);
                txtConFrom.Focus();
            }
            else
            {
                clscon.Return_DT(dt, "Exec [dbo].[aero_GetConsultantReport] '" + strDateFrom + "','" + strDateTo + "',3, " + ddlTopCon.SelectedValue + "");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    //14
    // Dealer summary report by state (18 AUG 2022)
    private void GenrateReport_Fourteen()
    {
        try
        {
            divError.Visible = false;
            DateTime dtfrom = Convert.ToDateTime(txtDealerStartDate.Text);
            DateTime dtto = Convert.ToDateTime(txtDealerStartDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportDataFourteen();
            rprt.Load(Server.MapPath("~/Reports/rptDealerSummaryByState.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                TextObject txtPH = (TextObject)rprt.ReportDefinition.ReportObjects["txtPH"];
                if (ddlTopConDealer.SelectedValue == "")
                {
                    txtPH.Text = "Top " + txtNoOfRecs.Text + " Dealer Report- By State";
                    txtheader.Text = "Top " + txtNoOfRecs.Text + " Dealer Summary Report \nfrom " + strDateFrom + " to " + strDateTo + " - By State";
                }
                else
                {
                    txtPH.Text = ddlTopConDealer.SelectedItem.Text + " Dealer Report- By State";
                    txtheader.Text = ddlTopConDealer.SelectedItem.Text + " Dealer Summary Report \nfrom " + strDateFrom + " to " + strDateTo + " - By State";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private DataTable ReportDataFourteen()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtDealerStartDate.Text);
            DateTime dtto = Convert.ToDateTime(txtDealerEndDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            int noOfRec = 0;
            if (ddlTopConDealer.SelectedValue == "*")
            {
                noOfRec = 0;
            }
            else if (ddlTopConDealer.SelectedValue == "")
            {
                noOfRec = Convert.ToInt32(txtNoOfRecs.Text);
            }
            else
            {
                noOfRec = Convert.ToInt32(ddlTopCon.SelectedValue);
            }
            if (strDateFrom == "" || strDateTo == "")
            {
                //clscon.Return_DT(dt, "Exec [dbo].[aero_GetRepGroupPerformance] '" + "" + "','" + 11 + "','" + strDateFrom + "','" + strDateTo + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select From Date. !');", true);
                txtConFrom.Focus();
            }
            else
            {
                clscon.Return_DT(dt, "Exec [dbo].[aero_GetDealerReport] '" + strDateFrom + "','" + strDateTo + "',3, " + noOfRec + "");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    //15
    private void GenrateReport_Fifteen()
    {
        try
        {
            divError.Visible = false;
            DateTime dtfrom = Convert.ToDateTime(txtDealerStartDate.Text);
            DateTime dtto = Convert.ToDateTime(txtDealerEndDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportDatafifteen();
            rprt.Load(Server.MapPath("~/Reports/rptDealerDetail.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                TextObject txtPH = (TextObject)rprt.ReportDefinition.ReportObjects["txtPH"];
                //txtheader.Text = ddlTopCon.SelectedItem.Text + " Dealer Detail Report \nfrom " + strDateFrom + " to " + strDateTo + " - By Value";
                //txtPH.Text = ddlTopCon.SelectedItem.Text + " Dealer Report- By Value";
                if (ddlTopConDealer.SelectedValue == "")
                {
                    txtPH.Text = "Top " + txtNoOfRecs.Text + " Dealer Report- By State";
                    txtheader.Text = "Top " + txtNoOfRecs.Text + " Dealer Detail Report \nfrom " + strDateFrom + " to " + strDateTo + " - By State";
                }
                else
                {
                    txtPH.Text = ddlTopConDealer.SelectedItem.Text + " Dealer Report- By State";
                    txtheader.Text = ddlTopConDealer.SelectedItem.Text + " Dealer Detail Report \nfrom " + strDateFrom + " to " + strDateTo + " - By State";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private DataTable ReportDatafifteen()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtDealerStartDate.Text);
            DateTime dtto = Convert.ToDateTime(txtDealerEndDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            int noOfRec = 0;
            if (ddlTopConDealer.SelectedValue == "*")
            {
                noOfRec = 0;
            }
            else if (ddlTopConDealer.SelectedValue == "")
            {
                noOfRec = Convert.ToInt32(txtNoOfRecs.Text);
            }
            else
            {
                noOfRec = Convert.ToInt32(ddlTopCon.SelectedValue);
            }
            if (strDateFrom == "")
            {
                //clscon.Return_DT(dt, "Exec [dbo].[aero_GetRepGroupPerformance] '" + "" + "','" + 11 + "','" + strDateFrom + "','" + strDateTo + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select From Date. !');", true);
                ddlOppertunity.Focus();
            }
            else
            {
                clscon.Return_DT(dt, "Exec [dbo].[aero_GetDealerReport] '" + strDateFrom + "','" + strDateTo + "',2, " + noOfRec + "");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    // Call Function
    private void Check_Url(string id)
    {
        try
        {
            if (id != null)
            {
                divError.Visible = false;
                //Hobart Commission Report 
                if (id == "1")
                {
                    GenrateReport_Zero();
                }
                else if (id == "2")
                {
                    GenrateReport_First();
                }
                else if (id == "3")
                {
                    GenrateReport_Fourth();
                }
                else if (id == "4")
                {
                    if (ddlSalesRep.SelectedIndex == 0)
                    {
                        GenrateReport_Third();
                    }
                    else
                    {
                        GenrateReport_Second();
                    }
                }
                else if (id == "5")
                {
                    GenrateReport_Sixth2();
                }
                else if (id == "6")
                {
                    GenrateReport_fifth();
                }
                else if (id == "7")
                {
                    GenrateReport_Sixth();
                }
                else if (id == "8")
                {
                    GenrateReport_Seventh();
                }
                else if (id == "9")
                {
                    GenrateReport_Eighth();
                }
                else if (id == "10")
                {
                    GenrateReport_NinthTopTwenty();
                }
                else if (id == "11")
                {
                    GenrateReport_Eleven();
                }
                else if (id == "12")
                {
                    GenrateReport_Twelve();
                }
                else if (id == "13")
                {
                    GenrateReport_Thirteen();
                }
                else if (id == "14")
                {
                    GenrateReport_Fourteen();
                }
                else if (id == "15")
                {
                    GenrateReport_Fifteen();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // Genrate report here
    protected void btnGenrate_Click(object sender, EventArgs e)
    {
        try
        {
            Check_Url(ddlOptions.SelectedValue);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}