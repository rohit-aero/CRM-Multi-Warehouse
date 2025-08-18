using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Linq;
using System.Collections.Generic;
using BOLAERO;
using BLLAERO;

public partial class Reports_frmPurchaseHistoryDetails : System.Web.UI.Page
{
    BOLPurchaseHistoryDetails ObjBOL = new BOLPurchaseHistoryDetails();
    BLLPurchaseHistoryDetails ObjBLL = new BLLPurchaseHistoryDetails();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Controls();
        }
    }

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            clscon.Return_DS(ds, "EXEC [dbo].[Get_PurchaseHistoryDetails] 2,'" + null + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownListAll(ddlPartNo, ds.Tables[0]);
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    Utility.BindDropDownListAll(ddlVendor, ds.Tables[1]);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }




    private DataTable Bind_Report()
    {
        DataTable dt = new DataTable();
        try
        {
            DataSet ds = new DataSet();
            string Qstr = string.Empty;
            if (ddlVendor.SelectedIndex > 0)
            {
                Qstr += " AND [Source] Like '" + ddlVendor.SelectedItem.Text + "'";
            }
            if (ddlPartNo.SelectedIndex > 0)
            {
                Qstr += " AND PartID=" + ddlPartNo.SelectedValue;
            }
            if (ddlStatus.SelectedIndex > 0)
            {
                Qstr += " AND [DetailsStatus]= '" + ddlStatus.SelectedValue + "'";
            }
            Qstr += " ORDER BY PartNumber ASC";
            ObjBOL.Operation = 1;
            ObjBOL.SearchVar = Qstr;
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                ObjBOL.ShipDateFrom = Utility.ConvertDate(txtFromDate.Text);
                ObjBOL.ShipDateTo = Utility.ConvertDate(txtToDate.Text);
            }
            ds = ObjBLL.GetPurchaseHistoryDetails(ObjBOL);
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

    private Boolean ValidationCheck()
    {
        try
        {
            if (txtFromDate.Text != "")
            {
                if (txtToDate.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter To Date !!");
                    txtToDate.Focus();
                    return false;
                }
            }
            if (txtToDate.Text != "")
            {
                if (txtFromDate.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter From Date !!");
                    txtToDate.Focus();
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

    private DataTable SubReportContainerPOPartsData()
    {
        DataTable dt = new DataTable();
        try
        {
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
                DateTime dtto = Convert.ToDateTime(txtToDate.Text);
                string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
                string strDateTo = dtto.ToString("MM/dd/yyyy");
                clscon.Return_DT(dt, "Exec [dbo].[Get_POPartsDetails_ContainerInformation] '" + strDateFrom + "','" + strDateTo + "'");
            }
            else
            {
                clscon.Return_DT(dt, "Exec [dbo].[Get_POPartsDetails_ContainerInformation]");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable SubReportContainerJobsData()
    {
        DataTable dt = new DataTable();
        try
        {
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
                DateTime dtto = Convert.ToDateTime(txtToDate.Text);
                string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
                string strDateTo = dtto.ToString("MM/dd/yyyy");
                clscon.Return_DT(dt, "Exec [dbo].[Get_POPartsDetails_ContainerJobs] '" + strDateFrom + "','" + strDateTo + "'");
            }
            else
            {
                clscon.Return_DT(dt, "Exec [dbo].[Get_POPartsDetails_ContainerJobs]");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }


    //btnGenerate_Click
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                DataTable dtReport = new DataTable();
                dtReport = (DataTable)Bind_Report();
                DataTable dtSubReportContainerPOParts = SubReportContainerPOPartsData();
                DataTable dtSubReportContainerJobs = SubReportContainerJobsData();
                rprt.Load(Server.MapPath("~/Reports/rptPurchaseHistoryDetails.rpt"));
                if (dtReport.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtFromDate.Text != "" && txtToDate.Text != "")
                    {
                        txtheader.Text = "Parts Purchase History Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                    }
                    else
                    {
                        txtheader.Text = "Parts Purchase History Report ";
                    }
                    rprt.SetDataSource(dtReport);
                    rprt.Subreports[0].SetDataSource(dtSubReportContainerPOParts);
                    rprt.Subreports[1].SetDataSource(dtSubReportContainerJobs);
                    rptPurchaseHistoryDetails.ReportSource = rprt;
                    rptPurchaseHistoryDetails.DataBind();
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtFromDate.Text != "" && txtToDate.Text != "")
                    {
                        txtheader.Text = "Parts Purchase History Report From " + txtFromDate.Text + " to " + txtToDate.Text;
                    }
                    else
                    {
                        txtheader.Text = "Parts Purchase History Report ";
                    }
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
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


    //btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddlVendor.SelectedIndex = 0;
            ddlPartNo.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            txtFromDate.Text = String.Empty;
            txtToDate.Text = String.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}