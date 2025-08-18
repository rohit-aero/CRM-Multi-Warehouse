using System;
using System.Data;
using System.Web.UI;
using System.Web.Services;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Linq;
using System.Globalization;

public partial class Reports_frmYTDConsultantProjects : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                int Month = DateTime.Now.Month;
                txtFromDate.Text = "01" + "/01/" + "2019";
                txtToDate.Text = "12" + "/31/" + "2021";
                BindConsultant();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindConsultant()
    {
        try
        {
            DataTable dt = new DataTable();
            clscon.Return_DT(dt, "EXEC [dbo].[Get_YTDConsultants]");
            Utility.BindDropDownListAll(ddlConsultant, dt);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Boolean ValidationCheckGovernmentSales()
    {
        try
        {
            if (txtFromDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Start Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Start Date. !!");
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
            if (ddlConsultant.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Consultant. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Consultant. !!");
                ddlConsultant.Focus();
                return false;
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }


        return true;
    }

    private DataTable ReportDataConsultantMain()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            clscon.Return_DT(dt, "EXEC [Get_ConsultantProjects] '" + "4" + "','" + ddlConsultant.SelectedValue + "','" + strDateFrom + "','" + strDateTo + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportDataConsultantMainAll()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [Get_ConsultantProjects] '" + "3" + "','" + "" + "','" + strDateFrom + "','" + strDateTo + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportDataConsultantSubPrime()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [Get_ConsultantProjects_Prime] '" + "1" + "','" + ddlConsultant.SelectedValue + "','" + strDateFrom + "','" + strDateTo + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportDataConsultantSubPrimeAll()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [Get_ConsultantProjects_Prime] '" + "2" + "','" + "" + "','" + strDateFrom + "','" + strDateTo + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportDataConsultantSubAlternate()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [Get_ConsultantProjects_Alternate] '" + "1" + "','" + ddlConsultant.SelectedValue + "','" + strDateFrom + "','" + strDateTo + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportDataConsultantSubAlternateAll()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [Get_ConsultantProjects_Alternate] '" + "2" + "','" + "" + "','" + strDateFrom + "','" + strDateTo + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void Get_DealersReport()
    {
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataSetForGet_YTD_SalesbyTSM_Pivot ds = new DataSetForGet_YTD_SalesbyTSM_Pivot();
            if (ddlConsultant.SelectedValue == "0")
            {
                DataTable dt = ReportDataConsultantMainAll();
                rprt.Load(Server.MapPath("~/Reports/rptConsultantProjectsMain.rpt"));
                if (dt.Rows.Count > 0)
                {
                    List<TextObject> textObjects = rprt.ReportDefinition.Sections["Section2"].ReportObjects.OfType<TextObject>().ToList();
                    List<TextObject> grandTotalObjects = rprt.ReportDefinition.Sections["Section4"].ReportObjects.OfType<TextObject>().ToList();
                    for (int i = 0; i < textObjects.Count; i++)
                    {
                        textObjects[i].Text = string.Empty;
                        string columnName = dt.Columns[i].ToString();
                        textObjects[i].Text = columnName;
                        if (i > 0)
                        {
                            grandTotalObjects[i].Text = string.Empty;
                            string expression = "Sum([" + columnName + "])";
                            object total = dt.Compute(expression, string.Empty);
                            if (total.ToString().Trim() != "")
                            {
                                grandTotalObjects[i].Text = "$" + float.Parse(total.ToString()).ToString("N", new CultureInfo("hi-IN"));
                            }
                        }

                    }


                    for (var it = 0; it < dt.Rows.Count; it++)
                    {
                        DataRow dr = ds.DynamicColumn.Rows.Add();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            string temp = dt.Rows[it][i].ToString();
                            if (i > 0)
                            {

                                dr[i] = (temp == null || temp.Trim().Length == 0) ? "-" : "$" + float.Parse(temp.Substring(0, temp.Length - 2)).ToString("N", new CultureInfo("hi-IN"));

                            }
                            else
                            {
                                dr[i] = temp;
                            }

                        }

                        if (dt.Rows[it][dt.Columns.Count - 2].ToString().Trim().Length > 0 && dt.Rows[it][dt.Columns.Count - 1].ToString().Trim().Length > 0)
                        {
                            var lastOne = float.Parse(dt.Rows[it][dt.Columns.Count - 1].ToString());
                            var secondLastOne = float.Parse(dt.Rows[it][dt.Columns.Count - 2].ToString());
                            var change = Math.Round((((lastOne - secondLastOne) / secondLastOne) * 100), 2).ToString();
                            //ds.Tables[0].Rows[it][ds.DynamicColumn.Columns.Count - 1] = change + " %";
                        }

                    }

                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Sales Report From " + ((Convert.ToDateTime(txtToDate.Text)).Year - 2) + " to " + (Convert.ToDateTime(txtToDate.Text)).Year;
                    rprt.SetDataSource(ds);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);                    
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Sales Report From " + ((Convert.ToDateTime(txtToDate.Text)).Year - 2) + " to " + (Convert.ToDateTime(txtToDate.Text)).Year;
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
            else
            {
                DataTable dt = ReportDataConsultantMain();
                rprt.Load(Server.MapPath("~/Reports/rptConsultantProjectsMain.rpt"));
                if (dt.Rows.Count > 0)
                {
                    List<TextObject> textObjects = rprt.ReportDefinition.Sections["Section2"].ReportObjects.OfType<TextObject>().ToList();
                    List<TextObject> grandTotalObjects = rprt.ReportDefinition.Sections["Section4"].ReportObjects.OfType<TextObject>().ToList();

                    for (int i = 0; i < textObjects.Count; i++)
                    {
                        textObjects[i].Text = string.Empty;
                        string columnName = dt.Columns[i].ToString();
                        textObjects[i].Text = columnName;
                        if (i > 0)
                        {
                            grandTotalObjects[i].Text = string.Empty;
                            string expression = "Sum([" + columnName + "])";
                            object total = dt.Compute(expression, string.Empty);
                            if (total.ToString().Trim() != "")
                            {
                                grandTotalObjects[i].Text = "$" + float.Parse(total.ToString()).ToString("N", new CultureInfo("hi-IN"));
                            }
                        }
                    }

                    for (var it = 0; it < dt.Rows.Count; it++)
                    {
                        DataRow dr = ds.DynamicColumn.Rows.Add();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            string temp = dt.Rows[it][i].ToString();
                            if (i > 0)
                            {

                                dr[i] = (temp == null || temp.Trim().Length == 0) ? "-" : "$" + float.Parse(temp.Substring(0, temp.Length - 2)).ToString("N", new CultureInfo("hi-IN"));

                            }
                            else
                            {
                                dr[i] = temp;
                            }

                        }

                        if (dt.Rows[it][dt.Columns.Count - 2].ToString().Trim().Length > 0 && dt.Rows[it][dt.Columns.Count - 1].ToString().Trim().Length > 0)
                        {
                            var lastOne = float.Parse(dt.Rows[it][dt.Columns.Count - 1].ToString());
                            var secondLastOne = float.Parse(dt.Rows[it][dt.Columns.Count - 2].ToString());
                            var change = Math.Round((((lastOne - secondLastOne) / secondLastOne) * 100), 2).ToString();
                            //ds.Tables[0].Rows[it][ds.DynamicColumn.Columns.Count - 1] = change + " %";
                        }

                    }

                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Sales Report From " + ((Convert.ToDateTime(txtToDate.Text)).Year - 2) + " to " + (Convert.ToDateTime(txtToDate.Text)).Year;
                    rprt.SetDataSource(ds);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Sales Report From " + ((Convert.ToDateTime(txtToDate.Text)).Year - 2) + " to " + (Convert.ToDateTime(txtToDate.Text)).Year;
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

    private void Get_DealersReportPrimeSpec()
    {
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            if (ddlConsultant.SelectedValue == "0")
            {
                DataTable dt = ReportDataConsultantSubPrimeAll();
                rprt.Load(Server.MapPath("~/Reports/rptConsultantProjectsPrimeSpec.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Prime Spec Report From " + strDateFrom + " to" + strDateTo;
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                    rprt.Dispose();
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Prime Spec Report From " + strDateFrom + " to" + strDateTo;
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
            else
            {
                DataTable dt = ReportDataConsultantSubPrime();
                rprt.Load(Server.MapPath("~/Reports/rptConsultantProjectsPrimeSpec.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = ddlConsultant.SelectedItem.Text + "  Prime Spec Report From " + strDateFrom + " to" + strDateTo;
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                    rprt.Dispose();
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Prime Spec Report From " + strDateFrom + " to" + strDateTo;
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
    }

    private void Get_DealersReportAlternate()
    {
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            if (ddlConsultant.SelectedValue == "0")
            {
                DataTable dt = ReportDataConsultantSubAlternateAll();
                rprt.Load(Server.MapPath("~/Reports/rptConsultantProjectsAlternate.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Alternate Report From " + strDateFrom + " to" + strDateTo;
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = "Alternate Report From " + strDateFrom + " to" + strDateTo;
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
            else
            {
                DataTable dt = ReportDataConsultantSubAlternate();
                rprt.Load(Server.MapPath("~/Reports/rptConsultantProjectsAlternate.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = ddlConsultant.SelectedItem.Text + "  Alternate Report From " + strDateFrom + " to" + strDateTo;
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = ddlConsultant.SelectedItem.Text + "  Alternate Report From " + strDateFrom + " to" + strDateTo;
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

    // Genrate report here
    protected void btnGenrate_Click1(object sender, EventArgs e)
    {
        try
        {
            if (rdbList.SelectedValue == "1")
            {
                Get_DealersReport();
            }
            else if (rdbList.SelectedValue == "2")
            {
                Get_DealersReportPrimeSpec();
            }
            else
            {
                Get_DealersReportAlternate();
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
            ddlConsultant.SelectedIndex = 0;
            rdbList.SelectedValue = "1";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }
}