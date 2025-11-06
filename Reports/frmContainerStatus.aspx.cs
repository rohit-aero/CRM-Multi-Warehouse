using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

public partial class Reports_frmContainerStatus : System.Web.UI.Page
{
    BOLSearchContainer ObjBOL = new BOLSearchContainer();
    BLLManageSearchContainer ObjBLL = new BLLManageSearchContainer();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Controls();            
        }
    }


    private void SetAutoDefaultDates()
    {
        try
        {
            txtSentDateFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            txtSentDateTo.Text = DateTime.Now.AddMonths(0).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month) + "/" + DateTime.Now.AddMonths(0).Year;
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
            ds = ObjBLL.GetSearchContainerData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlVendor, ds.Tables[0]);
                Utility.BindDropDownListAll(ddlDestination, ds.Tables[0]);
                if (ddlVendor.Items.Count > 0)
                {
                    ddlVendor.SelectedIndex = 0;
                }
                if (ddlDestination.Items.Count > 0)
                {
                    ddlDestination.SelectedIndex = 0;
                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlContainerNo, ds.Tables[1]);
                ddlContainerNo.SelectedIndex = 0;
            }
            //SetAutoDefaultDates();
            //BindContainer();            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindDestWareHouse(string SourceID, string DestinationID)
    {
        try
        {
            if (SourceID != "" || DestinationID != "")
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 3;
                if (SourceID != "")
                {
                    ObjBOL.SourceID = Convert.ToInt32(SourceID);
                }
                else
                {
                    ObjBOL.SourceID = Convert.ToInt32(DestinationID);
                }
                ds = ObjBLL.GetSearchContainerData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (SourceID != "")
                    {
                        Utility.BindDropDownListAll(ddlDestination, ds.Tables[0]);
                    }
                    else if (DestinationID != "")
                    {
                        Utility.BindDropDownListAll(ddlVendor, ds.Tables[0]);
                    }
                }
                else
                {
                    if (ddlVendor.Items.Count > 0)
                    {
                        ddlVendor.SelectedIndex = 0;
                    }
                    if (ddlDestination.Items.Count > 0)
                    {
                        ddlDestination.SelectedIndex = 0;
                    }

                }
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
            if (ValidationCheck() == true)
            {
                string fileName = "";
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                dt = ReportDataZero();
                dt1 = ReportDataFirst();
                rprt.Load(Server.MapPath("~/Reports/rptPackingDetails.rpt"));
                if (dt.Rows.Count > 0 || dt1.Rows.Count > 0)
                {
                    if (ddlContainerNo.SelectedIndex > 0)
                    {
                        fileName = ddlContainerNo.SelectedItem.Text;
                    }
                    rprt.SetDataSource(dt);
                    rprt.Subreports[0].SetDataSource(dt1);
                    rptGenerateReport.ReportSource = rprt;
                    rptGenerateReport.DataBind();
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, fileName);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = ddlContainerNo.SelectedItem.Text;
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
        }
        catch (Exception ex)
        {
            if (ex.ToString() != "Thread was being aborted.")
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
            clscon.Return_DT(dt, "EXEC [IV].[Get_PackingDetails_V1] '" + ddlContainerNo.SelectedValue + "'");
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
            clscon.Return_DT(dt, "EXEC [IV].[Get_PackingDetails_Jobs] '" + ddlContainerNo.SelectedValue + "'");
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
            //if(txtSentDateFrom.Text == "")
            //{
            //    Utility.ShowMessage_Warning(Page, "Please Enter Sent Date From !");
            //    txtSentDateFrom.Focus();
            //    return false;
            //}
            //if(txtSentDateFrom.Text != "" && txtSentDateTo.Text== "")
            //{
            //    Utility.ShowMessage_Warning(Page, "Please Enter Sent Date To !");
            //    txtSentDateTo.Focus();
            //    return false;
            //}
            if (ddlContainerNo.SelectedIndex == 0)
            {
                Utility.ShowMessage_Warning(Page, "Please Select Invoice No !");
                ddlContainerNo.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    //btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            txtSentDateFrom.Text = String.Empty;
            txtSentDateTo.Text = String.Empty;
            if (ddlVendor.Items.Count > 0)
            {
                ddlVendor.SelectedIndex = 0;
            }
            if (ddlDestination.Items.Count > 0)
            {
                ddlDestination.SelectedIndex = 0;
            }            
            ddlContainerCheckStatus.SelectedIndex = 0;
            ddlShipmentBy.SelectedIndex = 0;
            Bind_Controls();
            ddlContainerNo.SelectedIndex = 0;
            //SetAutoDefaultDates();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindContainer()
    {
        try
        {
            DataTable dt = new DataTable();
            string qstr = String.Empty;
            string FQstr = String.Empty;
            qstr += "Select id as Containerid, CASE WHEN Inv_Container.ContainerNo = '' THEN Inv_Container.InvoiceNo ELSE   ";
            qstr += " CONCAT(Inv_Container.InvoiceNo + '/ ', Inv_Container.ContainerNo + '') END AS InvoiceNo from Inv_Container ";
            qstr += "Where InvoiceNo is not null";
            if (ddlVendor.SelectedIndex > 0)
            {
                qstr += " AND Inv_Container.Sourceid= '" + ddlVendor.SelectedValue + "' ";
            }
            if (ddlDestination.SelectedIndex > 0)
            {
                qstr += " AND Inv_Container.WareHouseID= '" + ddlDestination.SelectedValue + "' ";
            }
            if (txtSentDateFrom.Text != "" && txtSentDateTo.Text != "")
            {
                qstr += "  AND ( Inv_Container.SentDate BETWEEN  '" + txtSentDateFrom.Text + "'  AND  '" + txtSentDateTo.Text + "'  OR Inv_Container.SentDate IS NULL) ";
            }            
            if (ddlContainerCheckStatus.SelectedIndex > 0)
            {
                if (ddlContainerCheckStatus.SelectedValue == "1")
                {
                    qstr += " AND Inv_Container.IsSubmitted= '" + 1 + "' ";
                }
                else if (ddlContainerCheckStatus.SelectedValue == "2")
                {
                    qstr += " AND Inv_Container.IsSubmitted IS NULL ";
                }
            }
            if (ddlShipmentBy.SelectedIndex > 0)
            {
                qstr += " AND Inv_Container.Shipmentby= '" + ddlShipmentBy.SelectedValue + "'";
            }
            qstr += " Order by Inv_Container.InvoiceNo ";
            FQstr = qstr;
            clscon.Return_DT(dt, FQstr);
            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlContainerNo, dt);
                if (ddlContainerNo.Items.Count > 0)
                {
                    ddlContainerNo.SelectedIndex = 0;
                }
            }
            else
            {
                ddlContainerNo.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlVendor.SelectedIndex > 0)
            {
                BindDestWareHouse(ddlVendor.SelectedValue,"");
            }
            else
            {
                Bind_Controls();                
            }       
            BindContainer();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlDestination_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if(ddlVendor.SelectedIndex == 0)
            {
                if (ddlDestination.SelectedIndex > 0)
                {
                    BindDestWareHouse("", ddlDestination.SelectedValue);
                }
                else
                {
                    Bind_Controls();
                }                
            }
            BindContainer();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlShipmentBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindContainer();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlContainerCheckStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindContainer();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtSentDateFrom_TextChanged(object sender, EventArgs e)
    {
        try
        {
            BindContainer();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtSentDateTo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            BindContainer();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}