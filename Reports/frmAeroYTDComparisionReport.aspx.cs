using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using System.Linq;
using BOLAERO;
using BLLAERO;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class Reports_frmAeroYTDComparisionReport : System.Web.UI.Page
{
    BOLHobartSalesbyTSM ObjBOL = new BOLHobartSalesbyTSM();
    BLLManageHobartSalesbyTSM ObjBLL = new BLLManageHobartSalesbyTSM();

    BOLManageRepGroup ObjBOL1 = new BOLManageRepGroup();
    BLLManageRepGroup ObjBLL1 = new BLLManageRepGroup();

    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindSalesTSM();
                BindControl();
                int Month = DateTime.Now.Month + 2;
                txtFromDate.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
                txtEndDate.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
                txtOpperStart.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
                txtOpperEnd.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
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

    private void BindControl()
    {
        try
        {
            DataSet ds = new DataSet();
            clscon.Return_DS(ds, "EXEC [dbo].[Get_SalesReport] '','',11");
            if (ds.Tables[1].Rows.Count > 0)
            {
                //Utility.BindDropDownListAll(ddlProductLineList, ds.Tables[1]);
                ddlProductLineList.DataSource = ds.Tables[1];
                ddlProductLineList.DataBind();
                ddlProductLineList.Items.Insert(0, new ListItem("Both", "0"));
                ddlProductLineList.SelectedValue = "0";
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlSalesRep, ds.Tables[2]);
                Utility.BindDropDownListAll(ddlSaleRepAll, ds.Tables[2]);
            }
            BindControlForHobartRegion();
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
            DataTable dt = new DataTable();
            ObjBOL.Operation = 2;
            ds = ObjBLL.GetSalesbyTSM(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlSalesbyAllTSM, ds.Tables[0]);
            }
            dt.Columns.Add("Year");
            var startingYear = 2010;
            var currentYear = DateTime.Now.Year;
            for (var i = 0; i <= currentYear - startingYear; i++)
            {
                dt.Rows.Add();
                dt.Rows[i][0] = currentYear - i; // Add years in descending order
            }
            Utility.BindDropDownList(ddlSalesbyTSMYear, dt);
            Utility.BindDropDownList(ddlHobartRegionYear, dt);
            Utility.BindDropDownList(ddlRepGroupYear, dt);
            Utility.BindDropDownList(ddlSaleRepAllYear, dt);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public class RepGroup
    {
        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        String _Name;
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }

    [WebMethod]
    public static List<RepGroup> ddlProductLineList_SelectedIndexChanged(int ProductLineId)
    {
        List<RepGroup> returnList = new List<RepGroup>();
        try
        {
            return ProductLineEvent(ProductLineId);
        }
        catch (Exception ex)
        {
            //lblMsg.Text = ex.ToString();
            Utility.AddEditException(ex);

        }
        return returnList;
    }

    private static List<RepGroup> ProductLineEvent(int ProductLineId)
    {
        List<RepGroup> returnList = new List<RepGroup>();
        try
        {
            DataSet ds = new DataSet();
            commonclass1 cc = new commonclass1();
            cc.Return_DS(ds, "EXEC [dbo].[Get_SalesReport] '','',12,'" + ProductLineId + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Utility.BindDropDownList(ddlSalesRep, ds.Tables[0]);
                //ddlSalesRep.SelectedIndex = 0;
                RepGroup objRep = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    objRep = new RepGroup();
                    objRep.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["id"]);
                    objRep.Name = ds.Tables[0].Rows[i]["name"].ToString();
                    returnList.Add(objRep);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return returnList;
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
                clscon.Return_DT(dt, "EXEC [Get_YTD_SalesbyTSM] '" + "1" + "','" + ddlSalesbyAllTSM.SelectedValue + "','" + ddlSalesbyTSMYear.SelectedValue + "'");
            }
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.") { Utility.AddEditException(ex); }
        }
        return dt;
    }

    private DataTable ReportDataZeroPivot()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "[dbo].[Get_SalesbyTSMPivotIndividual]'" + ddlSalesbyAllTSM.SelectedValue + "','" + ddlSalesbyTSMYear.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.") { Utility.AddEditException(ex); }
        }
        return dt;
    }

    private void GenrateReport_Zero()
    {
        try
        {
            string TSM = null;
            DataRow drCurrentRow = null;
            DataTable dt = ReportDataZero();
            DataTable dt1 = ReportDataZeroPivot();
            DataSetForGet_YTD_SalesbyTSM_Pivot ds = new DataSetForGet_YTD_SalesbyTSM_Pivot();
            for (int i = dt1.Rows.Count - 1; i >= 0; i--)
            {
                if (dt1.Rows[i][ddlSalesbyTSMYear.SelectedValue].ToString() == "")
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
                List<TextObject> textObjects = rprt.Subreports[0].ReportDefinition.Sections["ReportHeaderSection1"].ReportObjects.OfType<TextObject>().ToList();

                for (int i = 0; i < textObjects.Count; i++)
                {
                    //Set the name of Column in TextObject.
                    textObjects[i].Text = string.Empty;
                    if (dt1.Columns.Count > i && i < dt1.Columns.Count - 1)
                    {
                        textObjects[i].Text = dt1.Columns[i + 1].ToString();
                    }

                }

                textObjects[textObjects.Count - 1].Text = "      % Change " + "[" + dt1.Columns[dt1.Columns.Count - 2].ColumnName + " - " + dt1.Columns[dt1.Columns.Count - 1].ColumnName + "]";

                for (var it = 0; it < dt1.Rows.Count; it++)
                {
                    DataRow dr = ds.DynamicColumn.Rows.Add();
                    for (int i = 0; i < dt1.Columns.Count; i++)
                    {
                        string temp = dt1.Rows[it][i].ToString();
                        if (i > 0)
                        {

                            dr[i] = (temp == null || temp.Trim().Length == 0) ? "-" : "$" + float.Parse(temp.Substring(0, temp.Length - 2)).ToString("N", new CultureInfo("hi-IN"));

                        }
                        else
                        {
                            dr[i] = temp;
                        }

                    }

                    if (dt1.Rows[it][dt1.Columns.Count - 2].ToString().Trim().Length > 0 && dt1.Rows[it][dt1.Columns.Count - 1].ToString().Trim().Length > 0)
                    {
                        var lastOne = float.Parse(dt1.Rows[it][dt1.Columns.Count - 1].ToString());
                        var secondLastOne = float.Parse(dt1.Rows[it][dt1.Columns.Count - 2].ToString());
                        var change = Math.Round((((lastOne - secondLastOne) / secondLastOne) * 100), 2).ToString();
                        ds.Tables[0].Rows[it][ds.DynamicColumn.Columns.Count - 1] = change + " %";
                    }

                }
                rprt.SetDataSource(dt);
                rprt.Subreports[0].SetDataSource(ds);
                rptSales.ReportSource = rprt;
                rptSales.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, ddlSalesbyAllTSM.SelectedItem.Text + " TSM - Sales Activity Report " + ddlSalesbyTSMYear.SelectedValue);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlSalesbyAllTSM.SelectedItem.Text + " TSM - Sales Activity Report " + ddlSalesbyTSMYear.SelectedValue;
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.") { Utility.AddEditException(ex); }
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
            clscon.Return_DT(dt, "[dbo].[Get_SalesbyTSM_YearlyTotal] " + ddlSalesbyTSMYear.SelectedValue);
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
            clscon.Return_DT(dt, "[dbo].[Get_SalesbyTSMPivot]" + ddlSalesbyTSMYear.SelectedValue);
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.") { Utility.AddEditException(ex); }
        }
        return dt;
    }

    private void GenrateReport_First()
    {
        try
        {
            string TSM = null;
            DataTable dt = ReportDataFirst();
            DataRow drCurrentRow = null;
            DataTable dt1 = ReportDataFirstPivot();
            DataSetForGet_YTD_SalesbyTSM_Pivot ds = new DataSetForGet_YTD_SalesbyTSM_Pivot();

            for (int i = dt1.Rows.Count - 1; i >= 0; i--)
            {
                if (dt1.Rows[i][ddlSalesbyTSMYear.SelectedValue].ToString() == "")
                {
                    drCurrentRow = dt.NewRow();
                    TSM = dt1.Rows[i]["TSM"].ToString();
                    drCurrentRow["TSM"] = TSM;
                    dt.AcceptChanges();
                    dt.Rows.Add(drCurrentRow);
                }
                if (dt1.Rows[i][1].ToString() == "" && dt1.Rows[i][2].ToString() == "" && dt1.Rows[i][3].ToString() == "")
                {
                    for (int i1 = dt.Rows.Count - 1; i1 >= 0; i1--)
                    {
                        if (dt1.Rows[i][0].ToString() == dt.Rows[i1][6].ToString() && dt.Rows[i1][0].ToString() == "" && dt.Rows[i1][1].ToString() == "" && dt.Rows[i1][2].ToString() == "" && dt.Rows[i1][3].ToString() == "" && dt.Rows[i1][4].ToString() == "")
                        {
                            dt.Rows[i1].Delete();
                            dt.AcceptChanges();
                            break;
                        }
                    }

                    dt1.Rows[i].Delete();
                    dt1.AcceptChanges();
                }
            }

            rprt.Load(Server.MapPath("~/Reports/rptSalesbyTSMYTDAll.rpt"));
            if (dt.Rows.Count > 0)
            {
                List<TextObject> textObjects = rprt.Subreports[0].ReportDefinition.Sections["ReportHeaderSection1"].ReportObjects.OfType<TextObject>().ToList();
                for (int i = 0; i < textObjects.Count; i++)
                {
                    //Set the name of Column in TextObject.
                    textObjects[i].Text = string.Empty;
                    if (dt1.Columns.Count > i && i < dt1.Columns.Count - 1)
                    {
                        textObjects[i].Text = dt1.Columns[i + 1].ToString();
                    }
                }
                textObjects[textObjects.Count - 1].Text = "      % Change " + "[" + dt1.Columns[dt1.Columns.Count - 2].ColumnName + " - " + dt1.Columns[dt1.Columns.Count - 1].ColumnName + "]";
                for (var it = 0; it < dt1.Rows.Count; it++)
                {
                    DataRow dr = ds.DynamicColumn.Rows.Add();
                    for (int i = 0; i < dt1.Columns.Count; i++)
                    {
                        string temp = dt1.Rows[it][i].ToString();
                        if (i > 0)
                        {
                            dr[i] = (temp == null || temp.Trim().Length == 0) ? "-" : "$" + float.Parse(temp.Substring(0, temp.Length - 2)).ToString("N", new CultureInfo("hi-IN"));
                        }
                        else
                        {
                            dr[i] = temp;
                        }
                    }
                    if (dt1.Rows[it][dt1.Columns.Count - 2].ToString().Trim().Length > 0 && dt1.Rows[it][dt1.Columns.Count - 1].ToString().Trim().Length > 0)
                    {
                        var lastOne = float.Parse(dt1.Rows[it][dt1.Columns.Count - 1].ToString());
                        var secondLastOne = float.Parse(dt1.Rows[it][dt1.Columns.Count - 2].ToString());
                        var change = Math.Round((((lastOne - secondLastOne) / secondLastOne) * 100), 2).ToString();
                        ds.Tables[0].Rows[it][ds.DynamicColumn.Columns.Count - 1] = change + " %";
                    }

                }

                rprt.SetDataSource(dt);
                rprt.Subreports[0].SetDataSource(ds);
                rptSales.ReportSource = rprt;
                rptSales.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "All TSM - Sales Activity Report " + ddlSalesbyTSMYear.SelectedValue);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "All TSM - Sales Activity Report " + ddlSalesbyTSMYear.SelectedValue;
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.") { Utility.AddEditException(ex); }
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
            clscon.Return_DT(dt, "Exec [dbo].[Get_YTD_SalesRepGroup] '" + ddlProductLineList.SelectedValue + "','" + ddlSalesRep.SelectedValue + "','" + ddlRepGroupYear.SelectedValue + "'");
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
            clscon.Return_DT(dt, "Exec [dbo].[Get_SalesbyRepHobartPivot] '" + ddlHobartSalesRep.SelectedValue + "','" + ddlHobartRegionYear.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.") { Utility.AddEditException(ex); }
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
            clscon.Return_DT(dt, "Exec [dbo].[Get_SalesbyRepPivot]'" + ddlRepGroupYear.SelectedValue + "', '" + ddlProductLineList.SelectedValue + "'");
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
            DataTable dt = ReportDataSalesbyRep();
            DataTable dt1 = ReportDataSecondPivot();
            DataSetForGet_YTD_SalesbyTSM_Pivot ds = new DataSetForGet_YTD_SalesbyTSM_Pivot();

            rprt.Load(Server.MapPath("~/Reports/rptSalesbyRep.rpt"));
            if (dt.Rows.Count > 0)
            {
                List<TextObject> textObjects = rprt.Subreports[0].ReportDefinition.Sections["ReportHeaderSection1"].ReportObjects.OfType<TextObject>().Reverse().ToList();

                for (int i = 0; i < textObjects.Count; i++)
                {
                    //Set the name of Column in TextObject.
                    textObjects[i].Text = string.Empty;
                    if (dt1.Columns.Count > i && i < dt1.Columns.Count - 1)
                    {
                        textObjects[i].Text = dt1.Columns[i + 1].ToString();
                    }

                }

                textObjects[textObjects.Count - 1].Text = "      % Change " + "[" + dt1.Columns[dt1.Columns.Count - 2].ColumnName + " - " + dt1.Columns[dt1.Columns.Count - 1].ColumnName + "]";

                for (var it = 0; it < dt1.Rows.Count; it++)
                {
                    DataRow dr = ds.DynamicColumn.Rows.Add();
                    for (int i = 0; i < dt1.Columns.Count; i++)
                    {
                        string temp = dt1.Rows[it][i].ToString();
                        if (i > 0)
                        {

                            dr[i] = (temp == null || temp.Trim().Length == 0) ? "-" : "$" + float.Parse(temp.Substring(0, temp.Length - 2)).ToString("N", new CultureInfo("en-US"));

                        }
                        else
                        {
                            dr[i] = temp;
                        }

                    }

                    if (dt1.Rows[it][dt1.Columns.Count - 2].ToString().Trim().Length > 0 && dt1.Rows[it][dt1.Columns.Count - 1].ToString().Trim().Length > 0)
                    {
                        var lastOne = float.Parse(dt1.Rows[it][dt1.Columns.Count - 1].ToString());
                        var secondLastOne = float.Parse(dt1.Rows[it][dt1.Columns.Count - 2].ToString());
                        var change = Math.Round((((lastOne - secondLastOne) / secondLastOne) * 100), 2).ToString();
                        ds.Tables[0].Rows[it][ds.DynamicColumn.Columns.Count - 1] = change + " %";
                    }

                }

                rprt.SetDataSource(dt);
                rprt.Subreports[0].SetDataSource(ds);
                rptSales.ReportSource = rprt;
                rptSales.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, ddlSalesRep.SelectedItem.Text + " Rep Group - Sales Activity Report " + ddlRepGroupYear.SelectedValue);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlSalesRep.SelectedItem.Text + " Rep Group - Sales Activity Report " + ddlRepGroupYear.SelectedValue;
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

    private void GenrateReport_Third()
    {
        try
        {
            DataTable dt = ReportDataSalesbyRepAll();
            // DataTable dt1 = ReportDataSecondPivot();
            rprt.Load(Server.MapPath("~/Reports/rptSalesRepSpecCreditProjects.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "All Rep Groups - Sales";
                rprt.SetDataSource(dt);
                rptSales.ReportSource = rprt;
                rptSales.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
                rprt.Close();
                rprt.Dispose();
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "All Rep Groups - Sales";
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
    }

    private DataTable ReportDataSalesbyRepHobart()
    {
        DataTable dt = new DataTable();
        string salesbyrepid = ddlHobartSalesRep.SelectedValue;
        try
        {
            clscon.Return_DT(dt, "Exec [dbo].[Get_YTD_HobartRegions] '" + salesbyrepid + "','" + ddlHobartRegionYear.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.") { Utility.AddEditException(ex); }
        }
        return dt;
    }

    private void GenrateReport_Fourth()
    {
        try
        {
            DataTable dt = ReportDataSalesbyRepHobart();
            DataTable dt1 = SalesbyRepHobart();
            DataSetForGet_YTD_SalesbyTSM_Pivot ds = new DataSetForGet_YTD_SalesbyTSM_Pivot();
            string salesbyrepid = ddlHobartSalesRep.SelectedValue;
            rprt.Load(Server.MapPath("~/Reports/rptSalesbyRep Hobart.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlHobartSalesRep.SelectedItem.Text + "-Sales";
                TextObject txtPageHeader = (TextObject)rprt.ReportDefinition.ReportObjects["txtPageHeader"];
                txtPageHeader.Text = ddlHobartSalesRep.SelectedItem.Text;
                List<TextObject> textObjects = rprt.Subreports[0].ReportDefinition.Sections["ReportHeaderSection1"].ReportObjects.OfType<TextObject>().Reverse().ToList();

                for (int i = 0; i < textObjects.Count; i++)
                {
                    //Set the name of Column in TextObject.
                    textObjects[i].Text = string.Empty;
                    if (dt1.Columns.Count > i && i < dt1.Columns.Count - 1)
                    {
                        textObjects[i].Text = dt1.Columns[i + 1].ToString();
                    }
                }
                textObjects[textObjects.Count - 1].Text = "      % Change " + "[" + dt1.Columns[dt1.Columns.Count - 2].ColumnName + " - " + dt1.Columns[dt1.Columns.Count - 1].ColumnName + "]";
                for (var it = 0; it < dt1.Rows.Count; it++)
                {
                    DataRow dr = ds.DynamicColumn.Rows.Add();
                    for (int i = 0; i < dt1.Columns.Count; i++)
                    {
                        string temp = dt1.Rows[it][i].ToString();
                        if (i > 0)
                        {
                            dr[i] = (temp == null || temp.Trim().Length == 0) ? "-" : "$" + float.Parse(temp.Substring(0, temp.Length - 2)).ToString("N", new CultureInfo("en-US"));
                        }
                        else
                        {
                            dr[i] = temp;
                        }
                    }
                    if (dt1.Rows[it][dt1.Columns.Count - 2].ToString().Trim().Length > 0 && dt1.Rows[it][dt1.Columns.Count - 1].ToString().Trim().Length > 0)
                    {
                        var lastOne = float.Parse(dt1.Rows[it][dt1.Columns.Count - 1].ToString());
                        var secondLastOne = float.Parse(dt1.Rows[it][dt1.Columns.Count - 2].ToString());
                        var change = Math.Round((((lastOne - secondLastOne) / secondLastOne) * 100), 2).ToString();
                        ds.Tables[0].Rows[it][ds.DynamicColumn.Columns.Count - 1] = change + " %";
                    }
                }
                rprt.SetDataSource(dt);
                rprt.Subreports[0].SetDataSource(ds);
                rptSales.ReportSource = rprt;
                rptSales.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, ddlHobartSalesRep.SelectedItem.Text + " Hobart Region - Sales Activity Report " + ddlHobartRegionYear.SelectedValue);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlHobartSalesRep.SelectedItem.Text + " Hobart Region - Sales Activity Report " + ddlHobartRegionYear.SelectedValue;
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

    private DataTable ReportDatafifth()
    {
        DataTable dt = new DataTable();
        try
        {
            //if (ddlSaleRepAll.SelectedIndex > 0)
            //{
            clscon.Return_DT(dt, "Exec [dbo].[Get_PMRSales] '" + ddlSaleRepAllYear.SelectedValue + "','" + ddlSaleRepAll.SelectedValue + "'");
            //}
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
        return dt;
    }

    private void GenrateReport_fifth()
    {
        try
        {
            DataTable dt = ReportDatafifth();
            rprt.Load(Server.MapPath("~/Reports/rptPMRSalesActivityReport.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlSaleRepAll.SelectedItem.Text + "-Sales Activity Report " + ddlSaleRepAllYear.SelectedItem.Text;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlSaleRepAll.SelectedItem.Text + "-Sales Activity Report " + ddlSaleRepAllYear.SelectedItem.Text;
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
            DataTable dt = ReportDataSixth2();
            rprt.Load(Server.MapPath("~/Reports/rptSalesRepSpecCreditProjects.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (ddlSaleRepAll.SelectedIndex == 0)
                {
                    txtheader.Text = "Spec Credit Report for All Rep Groups";
                }
                else
                {
                    txtheader.Text = "Spec Credit Report for " + ddlSaleRepAll.SelectedItem.Text + "";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (ddlSaleRepAll.SelectedIndex == 0)
                {
                    txtheader.Text = "Spec Credit Report for All Rep Groups";
                }
                else
                {
                    txtheader.Text = "Spec Credit Report for " + ddlSaleRepAll.SelectedItem.Text + "";
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
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = txtheader.Text = " from " + strDateFrom + " to " + strDateTo;
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
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = txtheader.Text = " from " + strDateFrom + " to " + strDateTo;
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

    private void GenrateReport_Eighth()
    {
        try
        {
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
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlRecCount.SelectedItem.Text + " Opportunities Report - " + ddlTopOpper.SelectedItem.Text + " \nfrom " + strDateFrom + " to " + strDateTo;
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
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlTopHobart.SelectedItem.Text + " Opportunities Report - " + ddlOppRegion.SelectedItem.Text + " \nfrom " + strDateFrom + " to " + strDateTo;
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
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlTopCon.SelectedItem.Text + " Consultants Summary Report \nfrom " + strDateFrom + " to " + strDateTo + " - By Value";
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
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlTopCon.SelectedItem.Text + " Consultants Detail Report \nfrom " + strDateFrom + " to " + strDateTo + " - By Value";
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
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlTopCon.SelectedItem.Text + " Consultants Summary Report \nfrom " + strDateFrom + " to " + strDateTo + " - By State";
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
    //Dealer summary report by state (18 AUG 2022)
    private void GenrateReport_Fourteen()
    {
        try
        {
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
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (ddlTopConDealer.SelectedValue == "")
                {
                    txtheader.Text = "Top " + txtNoOfRecs.Text + " Dealer Summary Report \nfrom " + strDateFrom + " to " + strDateTo + " - By State";
                }
                else
                {
                    txtheader.Text = ddlTopConDealer.SelectedItem.Text + " Dealer Summary Report \nfrom " + strDateFrom + " to " + strDateTo + " - By State";
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
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (ddlTopConDealer.SelectedValue == "")
                {
                    txtheader.Text = "Top " + txtNoOfRecs.Text + " Dealer Detail Report \nfrom " + strDateFrom + " to " + strDateTo + " - By State";
                }
                else
                {
                    txtheader.Text = ddlTopConDealer.SelectedItem.Text + " Dealer Detail Report \nfrom " + strDateFrom + " to " + strDateTo + " - By State";
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

    private void BindControlForHobartRegion()
    {
        try
        {
            DataSet ds = new DataSet();
            clscon.Return_DS(ds, "EXEC [dbo].[Get_YTD_HobartRegions] -1");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlHobartSalesRep, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
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
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select From Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select From Date. !!");
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
    private void GenrateReport_FourthAll()
    {
        try
        {
            DataTable dt = ReportDataSalesbyRepHobart();
            DataTable dt1 = SalesbyRepHobart();
            DataSetForGet_YTD_SalesbyTSM_Pivot ds = new DataSetForGet_YTD_SalesbyTSM_Pivot();
            string salesbyrepid = ddlHobartSalesRep.SelectedValue;
            rprt.Load(Server.MapPath("~/Reports/rptSalesbyRep HobartAll.rpt"));
            if (dt.Rows.Count > 0)
            {
                List<TextObject> textObjects = rprt.Subreports[0].ReportDefinition.Sections["ReportHeaderSection1"].ReportObjects.OfType<TextObject>().Reverse().ToList();
                for (int i = 0; i < textObjects.Count; i++)
                {
                    //Set the name of Column in TextObject.
                    textObjects[i].Text = string.Empty;
                    if (dt1.Columns.Count > i && i < dt1.Columns.Count - 1)
                    {
                        textObjects[i].Text = dt1.Columns[i + 1].ToString();
                    }
                }
                textObjects[textObjects.Count - 1].Text = "      % Change " + "[" + dt1.Columns[dt1.Columns.Count - 2].ColumnName + " - " + dt1.Columns[dt1.Columns.Count - 1].ColumnName + "]";
                for (var it = 0; it < dt1.Rows.Count; it++)
                {
                    DataRow dr = ds.DynamicColumn.Rows.Add();
                    for (int i = 0; i < dt1.Columns.Count; i++)
                    {
                        string temp = dt1.Rows[it][i].ToString();
                        if (i > 0)
                        {
                            dr[i] = (temp == null || temp.Trim().Length == 0) ? "-" : "$" + float.Parse(temp.Substring(0, temp.Length - 2)).ToString("N", new CultureInfo("en-US"));
                        }
                        else
                        {
                            dr[i] = temp;
                        }
                    }
                    if (dt1.Rows[it][dt1.Columns.Count - 2].ToString().Trim().Length > 0 && dt1.Rows[it][dt1.Columns.Count - 1].ToString().Trim().Length > 0)
                    {
                        var lastOne = float.Parse(dt1.Rows[it][dt1.Columns.Count - 1].ToString());
                        var secondLastOne = float.Parse(dt1.Rows[it][dt1.Columns.Count - 2].ToString());
                        var change = Math.Round((((lastOne - secondLastOne) / secondLastOne) * 100), 2).ToString();
                        ds.Tables[0].Rows[it][ds.DynamicColumn.Columns.Count - 1] = change + " %";
                    }
                }
                rprt.SetDataSource(dt);
                rprt.Subreports[0].SetDataSource(ds);
                rptSales.ReportSource = rprt;
                rptSales.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "All Hobart Regions - Sales Activity Report " + ddlHobartRegionYear.SelectedValue);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "All Hobart Regions - Sales Activity Report " + ddlHobartRegionYear.SelectedValue;
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


    // Call Function
    private void Check_Url(string id)
    {
        try
        {
            if (id != null)
            {
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
                    if (ddlHobartSalesRep.SelectedIndex == 0)
                    {
                        GenrateReport_FourthAll();
                    }
                    else
                    {
                        GenrateReport_Fourth();
                    }
                }
                else if (id == "4")
                {
                    // Sep 04 2023
                    //if (ddlSalesRep.SelectedIndex == 0)
                    //{
                    //    GenrateReport_Third();
                    //}
                    //else
                    //{
                    //    GenrateReport_Second();
                    //}
                    GenrateReport_Second();
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
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddlOptions.SelectedIndex = 0;
            BindControl();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}