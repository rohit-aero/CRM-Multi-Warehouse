using System;
using System.Data;
using System.Web.UI;
using System.Web.Services;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;
using System.Linq;

public partial class Reports_frmYTDDealerRebate : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindDealers();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindDealers()
    {
        try
        {
            DataTable dt = new DataTable();
            clscon.Return_DT(dt, "EXEC [dbo].[Get_YTDDealers] 3,0");
            Utility.BindDropDownListAll(ddlRebate, dt);
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


            if (ddlRebate.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Dealer. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Dealer. !!");
                ddlRebate.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private Boolean ValidationCheckGovernmentSales()
    {
        try
        {

            if (ddlRebate.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Dealer. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Dealer. !!");
                ddlRebate.Focus();
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
        try
        {
            if (ddlRebate.SelectedValue == "0")
            {
                clscon.Return_DT(dt, "EXEC [dbo].[Get_YTDDealers] '" + "4" + "'");
            }
            else
            {
                clscon.Return_DT(dt, "EXEC [dbo].[Get_YTDDealers] '" + "5" + "','" + ddlRebate.SelectedValue + "'");
            }
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
            //divError.Visible = true;
            DataTable dt = ReportData();
            DataSetForGet_YTD_SalesbyTSM_Pivot ds = new DataSetForGet_YTD_SalesbyTSM_Pivot();
            rprt.Load(Server.MapPath("~/Reports/rptYTDSalesDealer.rpt"));

            if (dt.Rows.Count > 0)
            {
                List<TextObject> textObjects = rprt.ReportDefinition.Sections["Section2"].ReportObjects.OfType<TextObject>().ToList();
                for (int i = 0; i < textObjects.Count; i++)
                {
                    textObjects[i].Text = string.Empty;
                    textObjects[i].Text = dt.Columns[i].ToString();

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
                txtheader.Text = ddlRebate.SelectedItem.Text.Replace(",", "") + "\nDealers Performance Report From " + (DateTime.Now.Year - 2) + " to " + DateTime.Now.Year.ToString();
                rprt.SetDataSource(ds);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlRebate.SelectedItem.Text.Replace(",", "") + "\nDealers Performance Report From " + (DateTime.Now.Year - 2) + " to " + DateTime.Now.Year.ToString();
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
            Get_DealersReport();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        DataTable dt = ReportData();
        if (dt.Rows.Count > 0)
        {
            Utility.ExportToExcelDT(dt, "Reps Performance Report");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddlRebate.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}