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
}