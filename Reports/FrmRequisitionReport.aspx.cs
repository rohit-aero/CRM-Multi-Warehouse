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

public partial class Reports_FrmRequisitionReport : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    BOLRequisition ObjBOL = new BOLRequisition();
    BLLRequisition ObjBLL = new BLLRequisition();
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
            ObjBOL.Operation = 19;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlPreparedBy, ds.Tables[0]);
                if (ddlPreparedBy.Items.Count > 0)
                {
                    ddlPreparedBy.SelectedIndex = 0;
                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlRequisition, ds.Tables[1]);
                if (ddlRequisition.Items.Count > 0)
                {
                    ddlRequisition.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetddlReq()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 19;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlRequisition, ds.Tables[1]);
                if (ddlRequisition.Items.Count > 0)
                {
                    ddlRequisition.SelectedIndex = 0;
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
            Qstr += " DECLARE @SQL AS NVARCHAR(MAX)=NULL SET @SQL=' ";
            Qstr += " SELECT id AS ReqID, ReqNo,Convert(Varchar(20),ReqDate,101) AS ReqDate, ";
            Qstr += " CONCAT(PreparedBy.FirstName + '' '', PreparedBy.LastName) AS PreparedBy ";
            Qstr += "  ,CONCAT(AppBy.FirstName + '' '', AppBy.LastName) AS AppBy,TentativeShipDate, ";
            Qstr += " CASE WHEN ReqStatus=1 Then ''Draft'' WHEN ReqStatus=2 THEN ''Submitted for review'' ";
            Qstr += " WHEN ReqStatus=3 THEN ''Approved'' WHEN ReqStatus=4 THEN ''Rejected'' ";
            Qstr += " WHEN ReqStatus=5 THEN ''On hold'' WHEN ReqStatus=6 THEN ''Cancelled''  ";
            Qstr += " when ReqStatus='''' THEN ''Draft'' End AS ReqStatus ";
            Qstr += " FROM Inv_Requisition INNER JOIN tblEmployees AS PreparedBy ON PreparedBy.EmployeeID=Inv_Requisition.PreparedBy ";
            Qstr += " INNER JOIN tblEmployees AS APPBy ON AppBy.EmployeeID=Inv_Requisition.AppBy ";
            Qstr += " WHERE Inv_Requisition.id IS NOT NULL ";
            if (ddlPreparedBy.SelectedIndex > 0)
            {
                Qstr += " AND PreparedBy.EmployeeID = ''" + ddlPreparedBy.SelectedValue + "''";
            }
            if (ddlRequisition.SelectedIndex > 0)
            {
                Qstr += " and Inv_Requisition.id = ''" + ddlRequisition.SelectedValue + "''";
            }
            Qstr += " Order by [Inv_Requisition].ReqNo ASC' ";
            Qstr += "  EXEC (@SQL)";
            clscon.Return_DS(ds, Qstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvRequitions.DataSource = ds.Tables[0];
                gvRequitions.DataBind();
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

    private void btnGenerateReport_Click_Event()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataZero();
            rprt.Load(Server.MapPath("~/Reports/rptGenerateRequisition.rpt"));
            if (dt.Rows.Count > 0)
            {
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Requisition Report ";
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

    private DataTable ReportDataZero()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[INV_GenerateRequisition] '" + hfReqID.Value + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnPreview_Click(object sender, EventArgs e)
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
            ddlPreparedBy.SelectedIndex = 0;
            ddlRequisition.SelectedIndex = 0;
            gvRequitions.DataSource = "";
            gvRequitions.DataBind();
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

    protected void gvRequitions_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Select")
            {
                try
                {
                    GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                    Label lblReqID = (Label)clickedRow.FindControl("lblReqID");
                    hfReqID.Value = lblReqID.Text;
                    string header = "Requisition Report";
                    btnGenerateReport_Click_Event();
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, header);
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

    protected void gvRequitions_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataRowView drview = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find textbox control
                LinkButton lnkRequisition = (LinkButton)e.Row.FindControl("lnkGenerateRequisition");
                Label lblGenerateRequisition = (Label)e.Row.FindControl("lblGenerateRequisition");
                lnkRequisition.Text = lblGenerateRequisition.Text;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Event Handler for Dropdown
    protected void ddlPrepareBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetGrid();
            if (ddlPreparedBy.SelectedIndex > 0)
            {
                ddlPreparedBy_SelectedIndexChanged_Event(ddlPreparedBy.SelectedValue);
            }
            else
            {
                ResetddlReq();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void ddlPreparedBy_SelectedIndexChanged_Event(string preparedBy)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 20;
            ObjBOL.PreparedBy = Int32.Parse(preparedBy);
            ds = ObjBLL.GetControlsData(ObjBOL);
            Utility.BindDropDownListAll(ddlRequisition, ds.Tables[0]);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindPreparedBy(string ReqID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 21;
            ObjBOL.Reqid = Convert.ToInt32(ReqID);
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPreparedBy.SelectedValue = ds.Tables[0].Rows[0]["EmployeeID"].ToString();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Event Handler for Dropdown
    protected void ddlRequisition_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetGrid();
            BindPreparedBy(ddlRequisition.SelectedValue);
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
            gvRequitions.DataSource = "";
            gvRequitions.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}