using System;

using BOLAERO;
using BLLAERO;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

public partial class Reports_frmPOStatus : System.Web.UI.Page
{
    BOLSearchContainer ObjBOL = new BOLSearchContainer();
    BLLManageSearchContainer ObjBLL = new BLLManageSearchContainer();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Utility.IsAuthorized())
            {
                Bind_Controls();
                chkDeletePermission();               
            }
        }
    }


    private void chkDeletePermission()
    {
        try
        {
            string msg = "";
            int EmployeeID = Utility.GetCurrentSession().EmployeeID;
            ObjBOL.Operation = 1;
            ObjBOL.EmployeeID = EmployeeID;
            msg = ObjBLL.DeletePO(ObjBOL);
            if (msg == "1")
            {
                btnDeletePO.Enabled = true;
            }
            else
            {
                btnDeletePO.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnDeletePO_Click(object sender, EventArgs e)
    {
        try
        {
            DeletePO();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DeletePO()
    {
        try
        {
            string msg = "";
            var EmployeeID = Utility.GetCurrentSession().EmployeeID;
            if (ddlPurchaseOrder.SelectedIndex > 0)
            {
                string PurchaseOrderID = ddlPurchaseOrder.SelectedValue;
                ObjBOL.Operation = 2;
                ObjBOL.POId = Convert.ToInt32(ddlPurchaseOrder.SelectedValue);
                msg = ObjBLL.DeletePO(ObjBOL);
                if (msg != "")
                {
                    if (msg == "PO Deleted Successfully")
                    {
                        Utility.ShowMessage_Success(Page, msg);
                        Utility.MaintainLogsSpecial("FrmPOStatus", "Delete", PurchaseOrderID);
                        BindContainer();
                    }
                    else
                    {
                        Utility.ShowMessage_Error(Page, msg);
                    }
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please Select Purchase Order No. !!");
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
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPurchaseOrder, ds.Tables[2]);
                ddlPurchaseOrder.SelectedIndex = 0;
            }
            //BindContainer();
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
                string filename = String.Empty;
                if (ddlPurchaseOrder.SelectedIndex > 0)
                {
                    filename = ddlPurchaseOrder.SelectedItem.Text;
                }
                else
                {
                    filename = "";
                }
                DataTable dt = new DataTable();
                dt = ReportDataZero();
                rprt.Load(Server.MapPath("~/Reports/rptPurchaseOrderManual.rpt"));
                if (dt.Rows.Count > 0)
                {
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, filename);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    if (txtOrderDateFrom.Text != "" && txtOrderDateTo.Text != "")
                    {
                        txtheader.Text = "Purchase Order Report From " + txtOrderDateFrom.Text + " to " + txtOrderDateTo.Text;
                    }
                    else
                    {
                        txtheader.Text = "Purchase Order Report ";
                    }
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
            clscon.Return_DT(dt, "EXEC [IV].[Inv_GeneratePurchaseOrder] '" + ddlPurchaseOrder.SelectedValue + "'");
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
            if (ddlPurchaseOrder.SelectedIndex == 0)
            {
                Utility.ShowMessage_Warning(Page, "Please Select Purchase Order No !");
                ddlPurchaseOrder.Focus();
                return false;
            }
            //if (txtOrderDateFrom.Text == "")
            //{
            //    Utility.ShowMessage_Warning(Page, "Please Enter Order Date From !");
            //    txtOrderDateFrom.Focus();
            //    return false;
            //}
            //if (txtOrderDateTo.Text == "")
            //{
            //    Utility.ShowMessage_Warning(Page, "Please Enter Order Date To !");
            //    txtOrderDateTo.Focus();
            //    return false;
            //}
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
            txtOrderDateFrom.Text = String.Empty;
            txtOrderDateTo.Text = String.Empty;
            ddlVendor.SelectedIndex = 0;
            ddlPOStatus.SelectedValue = "1";
            ddlDestination.SelectedIndex = 0;
            Bind_Controls();
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
            qstr += "Select Inv_PurchaseOrder_Manual.id as [PurchaseOrderID],   ";
            qstr += " Inv_PurchaseOrder_Manual.PONumber from Inv_PurchaseOrder_Manual ";
            qstr += " Where Inv_PurchaseOrder_Manual.PONumber is not null";
            if (ddlVendor.SelectedIndex > 0)
            {
                qstr += " AND Inv_PurchaseOrder_Manual.SourceId= '" + ddlVendor.SelectedValue + "' ";
            }
            if (ddlDestination.SelectedIndex > 0)
            {
                qstr += " AND Inv_PurchaseOrder_Manual.WareHouseID= '" + ddlDestination.SelectedValue + "' ";
            }
            if (txtOrderDateFrom.Text != "" && txtOrderDateTo.Text != "")
            {
                qstr += " AND Inv_PurchaseOrder_Manual.IssueDate BETWEEN '" + txtOrderDateFrom.Text + "' AND '" + txtOrderDateTo.Text + "'";
            }
            if (ddlPOStatus.SelectedIndex > 0)
            {
                qstr += " AND Inv_PurchaseOrder_Manual.Status = '" + ddlPOStatus.SelectedValue + "' ";
            }
            qstr += " Order by Inv_PurchaseOrder_Manual.PONumber asc ";
            FQstr = qstr;
            clscon.Return_DT(dt, FQstr);
            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPurchaseOrder, dt);
                if (ddlPurchaseOrder.Items.Count > 0)
                {
                    ddlPurchaseOrder.SelectedIndex = 0;
                }
            }
            else
            {
                ddlPurchaseOrder.Items.Clear();
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
                        if (ddlDestination.Items.Count > 0)
                        {
                            ddlDestination.SelectedIndex = 0;
                        }
                    }
                    else if (DestinationID != "")
                    {
                        Utility.BindDropDownListAll(ddlVendor, ds.Tables[0]);
                        if (ddlVendor.Items.Count > 0)
                        {
                            ddlVendor.SelectedIndex = 0;
                        }
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

    protected void txtOrderDateFrom_TextChanged(object sender, EventArgs e)
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

    protected void txtOrderDateTo_TextChanged(object sender, EventArgs e)
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

    protected void ddlPOStatus_SelectedIndexChanged(object sender, EventArgs e)
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