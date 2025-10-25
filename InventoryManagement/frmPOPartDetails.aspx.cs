using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.IO;

public partial class InventoryManagement_frmPOPartDetails : System.Web.UI.Page
{
    BOLPartWiseDetails ObjBOL = new BOLPartWiseDetails();
    BLLManagePartWiseDetail ObjBLL = new BLLManagePartWiseDetail();
    BOLRequisition ObjBOL_1 = new BOLRequisition();
    BLLRequisition ObjBLL_1 = new BLLRequisition();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Controls();
        }
    }

    private void Bind_Controls()
    {
        DataSet ds = new DataSet();
        try
        {
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetPartDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlPartNumber, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Grid()
    {
        DataSet ds = new DataSet();
        try
        {
            ObjBOL.Operation = 2;
            ObjBOL.PartId =Convert.ToInt32(ddlPartNumber.SelectedValue);
            ds = ObjBLL.GetPartDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvPOPartsDetail.DataSource = ds.Tables[0];
                gvPOPartsDetail.DataBind();
            }
            else
            {
                gvPOPartsDetail.DataSource = "";
                gvPOPartsDetail.DataBind();
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
            Bind_Grid();
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }
    //btnExportToExcel_Click
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Bind_Grid();
            string FileName = "Purchase Order Parts Detail" +".xls";          
            Utility.ExportToExcelGrid(gvPOPartsDetail, FileName);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddlPartNumber.SelectedIndex = 0;
            gvPOPartsDetail.EmptyDataText = String.Empty;
            gvPOPartsDetail.DataSource =null;
            gvPOPartsDetail.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvPOPartsDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if(e.CommandName == "Order")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblID = (Label)clickedRow.FindControl("lblpartid");
                LinkButton lnkOrderQty = (LinkButton)clickedRow.FindControl("lblOrderQty");
                if(lnkOrderQty.Text != "")
                {
                    ObjBOL_1.partid = Convert.ToInt32(lblID.Text);
                    ObjBOL_1.Operation = 1;
                    ds = ObjBLL_1.GetInOrderData(ObjBOL_1);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvOrderQty.DataSource = ds.Tables[0];
                        gvOrderQty.DataBind();
                        lblInStockPartNumber.Text = ds.Tables[0].Rows[0]["PartNumber"].ToString();
                        ModalPopupOrder.Show();
                    }
                    else
                    {
                        gvOrderQty.DataSource = "";
                        gvOrderQty.DataBind();
                        lblInStockPartNumber.Text = String.Empty;
                        ModalPopupOrder.Hide();
                    }
                } 
                             
            }
            if (e.CommandName == "Ship")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblID = (Label)clickedRow.FindControl("lblpartid");
                LinkButton lnkShipQty = (LinkButton)clickedRow.FindControl("lnkShipQty");
                if (lnkShipQty.Text != "")
                {
                    ObjBOL_1.partid = Convert.ToInt32(lblID.Text);
                    ObjBOL_1.Operation = 2;
                    ds = ObjBLL_1.GetInOrderData(ObjBOL_1);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvInTransit.DataSource = ds.Tables[0];
                        gvInTransit.DataBind();
                        lblPartNumber.Text = ds.Tables[0].Rows[0]["PartNumber"].ToString();
                        ModalPopupExtender1.Show();
                    }
                    else
                    {
                        gvInTransit.DataSource = "";
                        gvInTransit.DataBind();
                        lblPartNumber.Text = String.Empty;
                        ModalPopupExtender1.Hide();
                    }
                }
            }
            if(e.CommandName== "StockIn")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblID = (Label)clickedRow.FindControl("lblpartid");
                LinkButton lnkStockInQty = (LinkButton)clickedRow.FindControl("lnkStockInQty");
                if (lnkStockInQty.Text != "")
                {
                    ObjBOL_1.partid = Convert.ToInt32(lblID.Text);
                    ObjBOL_1.Operation = 3;
                    ds = ObjBLL_1.GetInOrderData(ObjBOL_1);                   
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvInsTock.DataSource = ds.Tables[0];
                        gvInsTock.DataBind();
                        lblStockInHand.Text = ds.Tables[0].Rows[0]["PartNumber"].ToString();
                        ModalPopupExtender3.Show();
                    }
                    else
                    {
                        gvInsTock.DataSource = "";
                        gvInsTock.DataBind();
                        lblStockInHand.Text = String.Empty;
                        ModalPopupExtender3.Hide();
                    }
                }
            }
            if (e.CommandName == "Pending")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblID = (Label)clickedRow.FindControl("lblpartid");
                Label lnkPendingQty = (Label)clickedRow.FindControl("lblPendingQty");
                if (lnkPendingQty.Text != "")
                {
                    ObjBOL_1.partid = Convert.ToInt32(lblID.Text);
                    ObjBOL_1.Operation = 4;
                    ds = ObjBLL_1.GetInOrderData(ObjBOL_1);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvPendingQty.DataSource = ds.Tables[0];
                        gvPendingQty.DataBind();
                        lblPendingQtyPartNumber.Text = ds.Tables[0].Rows[0]["PartNumber"].ToString();
                        ModalPopupExtender4.Show();
                    }
                    else
                    {
                        gvPendingQty.DataSource = "";
                        gvPendingQty.DataBind();
                        lblPendingQtyPartNumber.Text = String.Empty;
                        ModalPopupExtender4.Hide();
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvPOPartsDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            Label lnkPendingQty = (Label)e.Row.FindControl("lblPendingQty");
            if(lnkPendingQty.Text == "0")
            {
                lnkPendingQty.Attributes.Remove("href");
                if (lnkPendingQty.Enabled != false)
                {
                    lnkPendingQty.Enabled = false;
                    lnkPendingQty.Text = String.Empty;
                }
                else
                {
                    lnkPendingQty.Enabled = true;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}