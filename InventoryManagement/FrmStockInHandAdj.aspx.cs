using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI.WebControls;

public partial class InventoryManagement_FrmStockInHandAdj : System.Web.UI.Page
{
    BOLStockInHandAdjustment ObjBOL = new BOLStockInHandAdjustment();
    BLLStockInHandAdjustment ObjBLL = new BLLStockInHandAdjustment();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Control();
                EmptyDTParts();                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    
    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if(ds.Tables[0].Rows.Count>0)
            {
                Utility.BindDropDownListAll(ddlVendorLookup, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlContainerNo, ds.Tables[1]);                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_ContainerLookUp()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.Return_DataSet(ObjBOL);            
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlContainerNo, ds.Tables[1]);
                ddlContainerNo.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetGridOnVendor()
    {
        try
        {
            gvAddParts.DataSource = "";
            gvAddParts.DataBind();
            btnSubmit.Enabled = false;
            btnExportToExcel.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlVendorLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetGridOnVendor();
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.SourceID =Convert.ToInt32(ddlVendorLookup.SelectedValue);
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {                
                Utility.BindDropDownList(ddlContainerNo, ds.Tables[0]);
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

    protected void ddlContainerNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            ObjBOL.ContainerID =Convert.ToInt32(ddlContainerNo.SelectedValue);
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlVendorLookup.SelectedValue = ds.Tables[0].Rows[0]["Sourceid"].ToString();
                BInd_Grid();
                EnabledButton();
            }
            else
            {
                ResetPartNO();
            }          
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BInd_Grid()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            ObjBOL.ContainerID = Convert.ToInt32(ddlContainerNo.SelectedValue);
            //ObjBOL.PartID = Convert.ToInt32(ddlPartNo.SelectedValue);
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                gvAddParts.DataSource = ds.Tables[1];
                gvAddParts.DataBind();
            }
            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);            
        }
    }

    

    private void EnabledButton()
    {
        try
        {
            btnSubmit.Enabled = true;
            btnExportToExcel.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisabledButton()
    {
        try
        {
            btnSubmit.Enabled = false;
            btnExportToExcel.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //Create Temp Date Table
    private DataTable EmptyDT()
    {
        DataTable dtEmpty = new DataTable();
        try
        {
            dtEmpty.TableName = "GridSummary";            
            dtEmpty.Columns.Add(new DataColumn("PartID", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("StockInHand", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("TransactQty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("summary", typeof(string)));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);//adding row to the datatable            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    private DataTable EmptyDTParts()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.TableName = "PartsDetail";            
            dt.Columns.Add(new DataColumn("PartID", typeof(int)));           
            dt.Columns.Add(new DataColumn("StockInHand", typeof(int)));
            dt.Columns.Add(new DataColumn("TransactQty", typeof(int)));
            dt.Columns.Add(new DataColumn("summary", typeof(string)));
            ViewState["PartsDetail"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void ResetGrid()
    {
        try
        {
            Bind_Control();
            DisabledButton();
            ddlVendorLookup.SelectedIndex = 0;
            gvAddParts.DataSource = "";
            gvAddParts.DataBind();
            ViewState["PartsDetail"] = null;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetPartNO()
    {
        try
        {            
            DisabledButton();
            ddlVendorLookup.SelectedIndex = 0;
            gvAddParts.DataSource = "";
            gvAddParts.DataBind();
            ViewState["PartsDetail"] = null;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SaveStockInHandData()
    {
        try
        {
            DataTable dt = EmptyDTParts();
            foreach (GridViewRow row in gvAddParts.Rows)
            {
                DataRow dr;               
                if (row.RowType == DataControlRowType.DataRow)
                {
                    dr = dt.NewRow();                    
                    string partid=  (row.FindControl("lblPartID") as Label).Text;
                    string stockinhand= (row.FindControl("txtStockInHand") as Label).Text;
                    string transactqty= (row.FindControl("txtTransactQty") as TextBox).Text;
                    string summary = (row.FindControl("txtSummary") as TextBox).Text;
                    if(partid != "")
                    {
                        dr[0] = Convert.ToInt32(partid);
                    }
                    if(stockinhand != "")
                    {
                        dr[1] = Convert.ToInt32(stockinhand);
                    }
                    if(transactqty != "")
                    {                        
                        dr[2] = Convert.ToInt32(transactqty);
                    }                    
                    dr[3] = summary;
                    dt.Rows.Add(dr);
                    if (dr[2].ToString() == "")
                    {
                        dr.Delete();
                    }
                    dt.AcceptChanges();
                }
            }
            ViewState["PartsDetail"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SaveStockInHandData();
            string msg = "";
            DataTable selected = (DataTable)ViewState["PartsDetail"];
            DataView dv = new DataView(selected);
            DataTable summarytemp = dv.ToTable("selected", false, "PartID", "TransactQty", "summary");
            if(selected.Rows.Count==0)
            {
                Utility.ShowMessage_Error(Page, "Please add at least one closing stock qty. !");                
                return ;
            }
            ObjBOL.Operation = 4;
            if (ddlContainerNo.SelectedIndex > 0)
            {
                ObjBOL.ContainerID = Convert.ToInt32(ddlContainerNo.SelectedValue);
                ObjBOL.EmployeeID = Utility.GetCurrentSession().EmployeeID;
                ObjBOL.TempDataStockInHand = summarytemp;
                msg = ObjBLL.Return_String(ObjBOL);
                if (msg != "")
                {                    
                    Utility.ShowMessage_Success(Page, msg);
                    BInd_Grid();
                }
                else
                {
                    btnExportToExcel.Enabled = false;
                }
            }
            else
            {
                Utility.ShowMessage_Warning(Page, "Please Select Container No !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ResetGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    protected void gvAddParts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtSummary = (TextBox)e.Row.FindControl("txtSummary");
                if(txtSummary.Text == "")
                {
                    txtSummary.Text = "Stock Adjusted";
                }                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered, tem a ver com obotão de exportação para excel*/
    }

    private void BindExportToExcelGrid()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ObjBOL.ContainerID = Convert.ToInt32(ddlContainerNo.SelectedValue);
            //ObjBOL.PartID = Convert.ToInt32(ddlPartNo.SelectedValue);
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {           
                gvAddParts.DataSource = ds.Tables[1];
                gvAddParts.DataBind();           
            }
            else
            {
                gvAddParts.DataSource = "";
                gvAddParts.DataBind();
            }
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
            BindExportToExcelGrid();
            gvAddParts.Columns[0].Visible = false;
            string fileName = "StockAdjustment";
            Utility.ExportToExcelGrid(gvAddParts, fileName);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}