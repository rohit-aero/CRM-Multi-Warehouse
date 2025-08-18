using System;
using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

public partial class DailyPurchase_FrmDailyPurchaseReport : System.Web.UI.Page
{
    BOLDailyPurchase ObjBOL = new BOLDailyPurchase();
    BLLDailyPurchase ObjBLL = new BLLDailyPurchase();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindControls();
                SetDates();
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
            txtOrderDateFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            txtOrderDateTo.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
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
            ObjBOL.Operation = 1;
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            int tableIndex = 0;
            if (ds.Tables[tableIndex].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlPOHeaderList, ds.Tables[tableIndex]);
            }

            tableIndex = 1;
            if (ds.Tables[tableIndex].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlVendor, ds.Tables[tableIndex]);
            }

            tableIndex = 2;
            if (ds.Tables[tableIndex].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlPart, ds.Tables[tableIndex]);
            }

            tableIndex = 3;
            if (ds.Tables[tableIndex].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlRequester, ds.Tables[tableIndex]);
            }

            //tableIndex = 4;
            //if (ds.Tables[tableIndex].Rows.Count > 0)
            //{
            //    Utility.BindDropDownListAll(ddlProject, ds.Tables[tableIndex]);
            //}

            //tableIndex = 5;
            //if (ds.Tables[tableIndex].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlDepartment, ds.Tables[tableIndex]);
            //}

            //tableIndex = 6;
            //if (ds.Tables[tableIndex].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlUM, ds.Tables[tableIndex]);
            //}

            //tableIndex = 7;
            //if (ds.Tables[tableIndex].Rows.Count > 0)
            //{
            //    Utility.BindDropDownListAll(ddlOrderStatus, ds.Tables[tableIndex]);
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationCheck()
    {
        try
        {
            if (txtOrderDateFrom.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter From Date !");
                txtOrderDateFrom.Focus();
                return false;
            }

            if (txtOrderDateTo.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter To Date !");
                txtOrderDateTo.Focus();
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
            ObjBOL.Operation = 10;
            if (ddlPOHeaderList.SelectedIndex > 0)
            {
                ObjBOL.DailyPurchaseId = Int32.Parse(ddlPOHeaderList.SelectedValue);
            }

            if (ddlVendor.SelectedIndex > 0)
            {
                ObjBOL.VendorId = Int32.Parse(ddlVendor.SelectedValue);
            }

            if (ddlPart.SelectedIndex > 0)
            {
                ObjBOL.PartId = Int32.Parse(ddlPart.SelectedValue);
            }

            if (ddlRequester.SelectedIndex > 0)
            {
                ObjBOL.RequesterId = Int32.Parse(ddlRequester.SelectedValue);
            }

            if (ddlOrderStatus.SelectedIndex > 0)
            {
                ObjBOL.OrderStatus = ddlOrderStatus.SelectedValue;
            }

            if (txtOrderDateFrom.Text.Trim() != "")
            {
                ObjBOL.OrderDate = Utility.ConvertDate(txtOrderDateFrom.Text);
            }

            if (txtOrderDateTo.Text.Trim() != "")
            {
                ObjBOL.ReceivedDate = Utility.ConvertDate(txtOrderDateTo.Text);
            }
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenerateReport()
    {
        try
        {
            if (ValidationCheck())
            {
                DataTable dt = ReportData();
                if (dt.Rows.Count > 0)
                {
                    rprt.Load(Server.MapPath("~/DailyPurchase/rptDailyPurchase.rpt"));
                    if (dt.Rows.Count > 0)
                    {
                        TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                        txtheader.Text = "Daily Purchase Report - " + DateTime.Now.ToString("dddd, dd MMMM yyyy").Replace(',', ' ');
                        rprt.SetDataSource(dt);
                        rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                    }
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "Records not found !");
                }
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

    protected void btnReport_Click(object sender, EventArgs e)
    {
        GenerateReport();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel_Click();
    }

    private void btnCancel_Click()
    {
        try
        {
            if (ddlPOHeaderList.Items.Count > 0)
            {
                ddlPOHeaderList.SelectedIndex = 0;
            }

            if (ddlVendor.Items.Count > 0)
            {
                ddlVendor.SelectedIndex = 0;
            }

            if (ddlPart.Items.Count > 0)
            {
                ddlPart.SelectedIndex = 0;
            }

            if (ddlRequester.Items.Count > 0)
            {
                ddlRequester.SelectedIndex = 0;
            }

            if (ddlProject.Items.Count > 0)
            {
                ddlProject.SelectedIndex = 0;
            }

            txtOrderDateFrom.Text = string.Empty;
            txtOrderDateTo.Text = string.Empty;

            if (ddlOrderStatus.Items.Count > 0)
            {
                ddlOrderStatus.SelectedIndex = 0;
            }

            SetDates();

            gvDailyPurchaseDetail.DataSource = string.Empty;
            gvDailyPurchaseDetail.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                DataTable dt = ReportData();
                gvExportToExcel.DataSource = dt;
                gvExportToExcel.DataBind();
                string FileName = "Daily Purchase report from " + txtOrderDateFrom.Text + " to " + txtOrderDateTo.Text;
                Utility.ExportToExcelGrid(gvExportToExcel, FileName);
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlPOHeaderList.SelectedIndex > 0)
            {
                ObjBOL.Operation = 3;
                ObjBOL.DailyPurchaseId = Int32.Parse(ddlPOHeaderList.SelectedValue);
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);

                if (ds.Tables[1].Rows.Count > 0)
                {
                    gvDailyPurchaseDetail.DataSource = ds.Tables[1];
                    gvDailyPurchaseDetail.DataBind();
                }
                else
                {
                    gvDailyPurchaseDetail.DataSource = string.Empty;
                    gvDailyPurchaseDetail.DataBind();
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please select PO!!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}