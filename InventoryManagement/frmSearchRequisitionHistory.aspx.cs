using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Web;
using System.Drawing;
using BOLAERO;
using BLLAERO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;
using System.Configuration;

public partial class InventoryManagement_frmSearchRequisitionHistory : System.Web.UI.Page
{
    private GridViewHelper helper;
    commonclass1 clscon = new commonclass1();
    BOLRequisition ObjBOL = new BOLRequisition();
    BLLRequisition ObjBLL = new BLLRequisition();
    protected void Page_Load(object sender, EventArgs e)
    {           
        try
        {
            if (!IsPostBack)
            {
                
            }
          
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    
    //check if data filled in required fields
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtFromDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter From Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter From Date. !");
                txtFromDate.Focus();
                return false;
            }
            if (txtToDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter To Date. !');", true);

                Utility.ShowMessage_Error(Page, "Please Enter To Date. !"); txtToDate.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }





    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }


    private DataTable HistoryData()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "Exec [Inv_RequisitionHistory ] '" + strDateFrom + "','" + strDateTo + "'");
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        return dt;
    }
  


    private void BindGrid()
    {
        try
        {
            if (ValidationCheck() == true)
            {

                DataTable dt = new DataTable();
                dt = HistoryData();
                if (dt.Rows.Count > 0)
                {
                    gvSearch.DataSource = dt;
                    gvSearch.DataBind();
                    btnGenerateExcel.Enabled = true;
                }
                else
                {
                    gvSearch.DataSource = "";
                    gvSearch.DataBind();
                    btnGenerateExcel.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }
    protected void btnGenrate_Click(object sender, EventArgs e)
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
    private void PopupGridEmpty()
    {
        try
        {
            gvInTransit.DataSource = "";
            gvInTransit.DataBind();
            gvInShop.DataSource = "";
            gvInShop.DataBind();
            btnGenerateExcel.Enabled = false;
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void gvSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            PopupGridEmpty();
            if (e.CommandName == "Select")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblID = (Label)clickedRow.FindControl("lblPartintransitid");
                hfpartid.Value = Convert.ToString(lblID.Text);
                ObjBOL.partid = Convert.ToInt32(hfpartid.Value);
                ObjBOL.Operation = 1;
                ds = ObjBLL.GetTransitionData(ObjBOL);
                gvInTransit.DataSource = ds.Tables[0];
                gvInTransit.DataBind();
                ModalPopupExtender1.Show();
            }
            else if (e.CommandName == "Select2")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblID = (Label)clickedRow.FindControl("lblPartshpid");
                hfpartid.Value = Convert.ToString(lblID.Text);
                ObjBOL.partid = Convert.ToInt32(hfpartid.Value);
                ObjBOL.Operation = 1;
                ds = ObjBLL.GetInShopData(ObjBOL);
                gvInShop.DataSource = ds.Tables[0];
                gvInShop.DataBind();
                ModalPopupExtender2.Show();
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
            txtFromDate.Text = String.Empty;
            txtToDate.Text = String.Empty;
            gvSearch.DataSource = "";
            gvSearch.DataBind();
            btnGenerateExcel.Enabled = false;
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void btnGenerateExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            string Filename = "Aerowerks Requisition History" + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename="+Filename);
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = String.Empty;
            this.BindGrid();
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);

            GridView exporterGridView = new GridView();
            var dataTable = (DataTable)gvSearch.DataSource;
            //Here you can refetch record directly from DB
            dataTable.Columns[0].ColumnName = "Category";
            dataTable.Columns[1].ColumnName = "Part #";
            dataTable.Columns[2].ColumnName = "Part Description";
            dataTable.Columns[3].ColumnName = "Stock In Hand";
            dataTable.Columns[4].ColumnName = "In Transit";
            dataTable.Columns[5].ColumnName = "In Shop";
            dataTable.Columns.RemoveAt(6);
            exporterGridView.DataSource = (DataTable)dataTable;
            exporterGridView.AllowPaging = false;
            exporterGridView.BorderStyle = BorderStyle.None;           
            exporterGridView.DataBind();

            exporterGridView.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }
}