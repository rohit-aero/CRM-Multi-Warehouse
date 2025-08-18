using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;
using CrystalDecisions.CrystalReports.Engine;

public partial class InventoryManagement_frmInboundInspectionReport : System.Web.UI.Page
{
    BOLInboundInspectionSummary ObjBOL = new BOLInboundInspectionSummary();
    BLLManageInboundInpectionSummary ObjBLL = new BLLManageInboundInpectionSummary();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Utility.IsAuthorized())
        {
            if (!IsPostBack)
            {
                Bind_Control();
                BindAllParts();
            }
        }        
    }

    #region Drop Down Events Functions
    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetInboundInspectionSummaryDetails(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProductCodeLookUp, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindAllParts()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetInboundInspectionSummaryDetails(ObjBOL);
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlPartNo, ds.Tables[2]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindProductCode(string PartNo)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.PartID = Convert.ToInt32(PartNo);
            ds = ObjBLL.GetInboundInspectionSummaryDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlProductCodeLookUp.SelectedValue = ds.Tables[0].Rows[0]["productcode"].ToString();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlProductCodeLookUp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlProductCodeLookUp.SelectedIndex > 0)
            {
                ResetProductCodeLookup();
                PartsDesc(ddlProductCodeLookUp.SelectedValue);

            }
            else
            {
                ResetProductCodeLookup();
                BindAllParts();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void PartsDesc(string productcode)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 10;
            ObjBOL.ProductCode = Convert.ToInt32(productcode);
            ds = ObjBLL.GetInboundInspectionSummaryDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlPartNo, ds.Tables[0]);
            }
            else
            {
                ResetPartNo();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void ResetProductCodeLookup()
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

    #endregion   

    #region Reset Module
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            //Reset();            
            Bind_Control();
            ddlStatus.SelectedIndex = 0;
            ddlProductCodeLookUp.SelectedIndex = 0;
            BindAllParts();
            ddlPartNo.SelectedIndex = 0;
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
            ResetPartNo();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetPartNo()
    {
        try
        {
            ddlPartNo.DataSource = "";
            ddlPartNo.DataBind();
            ddlPartNo.Items.Insert(0, new ListItem("All", "0"));
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Report Section
    private DataTable ReportDataZero()
    {
        DataTable dt = new DataTable();
        string qstr = "";
        try
        {
            qstr += "Select CONCAT(Inv_Parts.PartNumber+ ' ', CustomerPartNumber) AS PartNumber,Inv_Parts.PartDes, Inv_InboundInspection_Detail.containerno as containerid,Inv_InboundInspection_Detail.id AS InspectionDetailID, ";
            qstr += " CASE WHEN plant=1 THEN 'Agilent' ELSE 'Triflex' END AS plant,plant as plantid, ";
            qstr += " case when qtyapproved=0 then null else qtyapproved end as qtyapproved,remarks, ";
            qstr += " case when qtyinspected=0 then null else qtyinspected end as qtyinspected, ";
            qstr += " convert(varchar(10),inspectiondate,101) as inspectiondate, ";
            qstr += " substring([filename], 20,200) as [filename],   ";
            qstr += " case when [status]=1 then 'Approved' when [status]=2 then 'Rejected' end as [Status], ";
            qstr += "  Ship_Info.ContainerNo,case when qtyreceived=0 then null else qtyreceived end as qtyreceived ";
            qstr += " from Inv_InboundInspection_Detail ";
            qstr += " INNER JOIN Inv_InboundInspection ON Inv_InboundInspection.id=Inv_InboundInspection_Detail.inspectionid ";
            qstr += " INNER JOIN Inv_Parts ON Inv_Parts.id=Inv_InboundInspection.partid ";
            qstr += " INNER JOIN Ship_Info ON INV_InboundInspection_Detail.containerno = Ship_Info.id";
            qstr += " LEFT JOIN Inv_ProductCode ON Inv_ProductCode.ID = Inv_Parts.productcode ";
            qstr += " where Inv_InboundInspection_Detail.plant is not null ";
            if (ddlProductCodeLookUp.SelectedIndex > 0)
            {
                qstr += " AND Inv_ProductCode.id= '" + ddlProductCodeLookUp.SelectedIndex + "' ";
            }
            if (ddlPartNo.SelectedIndex > 0)
            {
                qstr += " AND Inv_InboundInspection.partid='" + ddlPartNo.SelectedValue + "' ";
            }
            if (ddlStatus.SelectedIndex > 0)
            {
                qstr += " AND INV_InboundInspection_Detail.status='" + ddlStatus.SelectedValue + "' ";
            }
            clscon.Return_DT(dt, qstr);
            if (dt.Rows.Count == 0)
            {
                Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataZero();
            rprt.Load(Server.MapPath("~/Reports/rptInboundSummaryReport.rpt"));
            if (dt.Rows.Count > 0)
            {
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "InboundInspectionSummary");
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
    #endregion    

    protected void ddlPartNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPartNo.SelectedIndex > 0)
            {
                BindProductCode(ddlPartNo.SelectedValue);
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}