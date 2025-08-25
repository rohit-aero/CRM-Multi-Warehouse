using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Drawing;
using CrystalDecisions.CrystalReports.Engine;

public partial class InventoryManagement_FrmShipmentReport_New : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    BOLShipmentReport ObjBOL = new BOLShipmentReport();
    BLLManageShipmentReport ObjBLL = new BLLManageShipmentReport();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                if (!IsPostBack)
                {
                    Bind_Controls();
                }
            }
            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        
    }

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 20;
            ds = ObjBLL.Return_DS(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlVendorLookup, ds.Tables[0]);
                if (ddlVendorLookup.Items.Count > 0)
                {
                    ddlVendorLookup.SelectedIndex = 0;
                }                
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlContainerLookup, ds.Tables[1]);
                if (ddlContainerLookup.Items.Count > 0)
                {
                    ddlContainerLookup.SelectedIndex = 0;
                }                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    
    private void BindGrid()
    {
        try
        {            
            DataSet ds = new DataSet();
            string Qstr = "";
            ObjBOL.Operation = 19;            
            if (ddlVendorLookup.SelectedIndex > 0)
            {
                Qstr += " AND Inv_Container.Sourceid = '" + ddlVendorLookup.SelectedValue + "'";
            }
            if (ddlContainerLookup.SelectedIndex > 0)
            {
                Qstr += " and Inv_Container.id = '" + ddlContainerLookup.SelectedValue + "'";
            }
            Qstr += " order by InvoiceNo ASC";
            ObjBOL.SearchVar = Qstr;
            ds = ObjBLL.Return_DS(ObjBOL);
            Int32 test = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvShipmentTracker.DataSource = ds.Tables[0];
                gvShipmentTracker.DataBind();
            }
            else
            {
                ResetGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }       
    }

    //Event Handler for Button
    protected void btnPackingDetails_Click(object sender, EventArgs e)
    {
        //btnPackingDetails_Click_Event();
    }

    private void btnPackingDetails_Click_Event()
    {
        try
        {
            string invoice = "";
            string containerNo = "";
            string[] splitItem = ddlContainerLookup.SelectedItem.Text.Split('/');
            invoice = splitItem[0];
            if (splitItem.Length > 1)
            {
                containerNo = splitItem[1];
            }
            PrepareReport();
            rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, invoice);
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

    private Stream GetPackingDetailsReportStream()
    {
        PrepareReport();
        Stream reportStream;
        reportStream = (Stream)rprt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        rprt.Close();
        rprt.Dispose();
        return reportStream;
    }

    private void PrepareReport()
    {
        try
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt = ReportDataZero();
            dt1 = ReportDataFirst();
            rprt.Load(Server.MapPath("~/Reports/rptPackingDetails.rpt"));
            if (dt.Rows.Count > 0)
            {
                rprt.SetDataSource(dt);
                rprt.Subreports[0].SetDataSource(dt1);
                rptGenerateReport.ReportSource = rprt;
                rptGenerateReport.DataBind();
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
            clscon.Return_DT(dt, "EXEC [IV].[Get_PackingDetails_V1] '" + hfContainerID.Value + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable ReportDataFirst()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [IV].[Get_PackingDetails_Jobs] '" + hfContainerID.Value + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindGrid();         
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Reset()
    {
        try
        {
            ddlContainerLookup.SelectedIndex = 0;
            ddlVendorLookup.SelectedIndex = 0;           
            gvShipmentTracker.DataSource = "";
            gvShipmentTracker.DataBind();                     
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }     


    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            Reset();
            Bind_Controls();
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["dtShipmentTracer"];
            DataView dv = new DataView(dt);
            DataTable dt2 = dv.ToTable("selected", false, "Shipment From", "Shipment By", "Container No", "Ship Date", "ETA AS Per PL", "Received Date", "Comments");
            Utility.ExportToExcelDT(dt2, "ShipmentTrackerReport");
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void gvShipmentTracker_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Select")
            {
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblPackingList = (Label)clickedRow.FindControl("lblPackingList");
                string filePath = Utility.PackingListPath() + lblPackingList.Text;
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    if (file.Extension.ToLower() == ".pdf")
                    {
                        // Clear Rsponse reference  
                        Response.Clear();
                        // Add header by specifying file name  
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                        // Add header for content length  
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        // Specify content type  
                        Response.ContentType = "text/plain";
                        // Clearing flush  
                        Response.Flush();
                        // Transimiting file  
                        Response.TransmitFile(file.FullName);
                        Response.End();
                    }
                    else
                    {
                        Response.Clear();
                        Response.ContentType = "application/ms-excel";
                        Response.AppendHeader("content-disposition", "filename="
                            + file.Name.Replace(",", "").Replace("'", ""));
                        Response.WriteFile(filePath);
                        Response.Flush();
                        Response.End();
                    }
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "No Records Found !!");
                }
            }
            if (e.CommandName == "SelectPackingList")
            {
                try
                {
                    GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                    Label lblGeneratePackingList = (Label)clickedRow.FindControl("lblGeneratePackingList");
                    hfContainerID.Value = lblGeneratePackingList.Text;
                    string invoice = ((Label)clickedRow.FindControl("lblInvoiceNo")).Text;
                    PrepareReport();
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, invoice);
                }
                catch (Exception ex2)
                {
                    Utility.AddEditException(ex2);
                    
                }
                finally
                {
                    rprt.Close();
                    rprt.Dispose();
                }
                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
       
    }

    protected void gvShipmentTracker_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataRowView drview = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find textbox control
                LinkButton lnkPackingList = (LinkButton)e.Row.FindControl("lnkPackingList");
                string[] text = lnkPackingList.Text.Split(new char[] { '/' });
                string filename = text[0].ToString();
                lnkPackingList.Text = filename;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Event Handler for Dropdown
    protected void ddlVendorLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlVendorLookup_SelectedIndexChanged_Event();
    }

    private void ddlVendorLookup_SelectedIndexChanged_Event()
    {
        try
        {           
            if (ddlVendorLookup.SelectedIndex > 0)
            {                
                DataSet ds = new DataSet();
                ObjBOL.Operation = 21;
                ObjBOL.ID = Int32.Parse(ddlVendorLookup.SelectedValue);
                ds = ObjBLL.Return_DS(ObjBOL);
                Utility.BindDropDownListAll(ddlContainerLookup, ds.Tables[0]);
            }
            else
            {
                Reset();
                Bind_Controls();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }    

    //Event Handler for Dropdown
    protected void ddlContainerLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlContainerLookup_SelectedIndexChanged_Event();
    }

    private void ddlContainerLookup_SelectedIndexChanged_Event()
    {
        try
        {
            if (ddlContainerLookup.SelectedIndex > 0)
            {
                ResetGrid();
                btnPackingDetails.Enabled = true;         
                ObjBOL.Operation = 3;
                ObjBOL.ID = Int32.Parse(ddlContainerLookup.SelectedValue);
                string returnValue = ObjBLL.Return_String(ObjBOL);
                if (returnValue.Trim() != "")
                {
                    ddlVendorLookup.SelectedValue = returnValue;
                }               
            }
            else
            {
                Reset();
                ResetGrid();
                Bind_Controls();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetGrid()
    {
        try
        {
            gvShipmentTracker.DataSource = "";
            gvShipmentTracker.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}