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

public partial class ShipmentTracker_FrmShipmentReport : System.Web.UI.Page
{
    BOLShipmentTracker ObjBOL = new BOLShipmentTracker();
    BLLManageShipmentTracker ObjBLL = new BLLManageShipmentTracker();
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
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetShipmentReport(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlShipmentfrom, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlShipmentBy, ds.Tables[1]);
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
                if (ddlShipmentfrom.SelectedIndex > 0)
                {
                    Qstr += " AND ShipFromid = '" + ddlShipmentfrom.SelectedValue + "'";
                }
                if (ddlShipmentBy.SelectedIndex > 0)
                {
                    Qstr += " and shipbyid = '" + ddlShipmentBy.SelectedValue + "'";
                }
                if (txtContainerNo.Text != "")
                {
                    Qstr += " AND s.[Container No] LIKE '%" + txtContainerNo.Text + "%'";
                }
                if (txtShippmentFromDate.Text != "")
                {
                    Qstr += " AND s.[Ship Date] >= '" + txtShippmentFromDate.Text + "'";
                }
                if (txtShipmentToDate.Text != "")
                {
                    Qstr += " AND s.[Ship Date] <= '" + txtShipmentToDate.Text + "'";
                }
                Qstr += " Order by s.[Revised ETA] Desc";
                ObjBOL.Operation = 2;
                ObjBOL.SearchVar = Qstr;
                ds = ObjBLL.GetShipmentReport(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnExportToExcel.Enabled = true;
                    gvShipmentTracker.DataSource = ds.Tables[0];
                    gvShipmentTracker.DataBind();
                    ViewState["dtShipmentTracer"] = ds.Tables[0];
                }
                else
                {
                    btnExportToExcel.Enabled = false;
                    gvShipmentTracker.DataSource = "";
                    gvShipmentTracker.DataBind();
                }

           
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
       
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindGrid();
            divhelp.Attributes.Add("style", "display:none");
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
            ddlShipmentfrom.SelectedIndex = 0;
            ddlShipmentBy.SelectedIndex = 0;
            txtContainerNo.Text = String.Empty;
            txtShippmentFromDate.Text = String.Empty;
            txtShipmentToDate.Text = String.Empty;
            gvShipmentTracker.DataSource = "";
            gvShipmentTracker.DataBind();
            btnExportToExcel.Enabled = false;
            divhelp.Attributes.Add("style", "display:block");
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
        if (e.CommandName == "Select")
        {
            GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
            Label lblPackingList = (Label)clickedRow.FindControl("lblPackingList");
            string filePath = lblPackingList.Text;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {


                if (file.Extension == ".pdf")
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
}