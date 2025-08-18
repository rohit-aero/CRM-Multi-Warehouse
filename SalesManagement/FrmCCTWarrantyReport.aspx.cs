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

public partial class FrmCCTWarrantyReport : System.Web.UI.Page
{
    BOLRepSearch ObjBOL = new BOLRepSearch();
    BLLRepsSearch ObjBLL = new BLLRepsSearch();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = "01" + "/01/" + DateTime.Now.Year;
                txttodate.Text = "12" + "/31/" + DateTime.Now.Year;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    ///  BindControl() function bind all Drop Down Lists on the Search Proposal PAGE 
    /// </summary>
    

    /// <summary>
    /// Reset all the controls
    /// </summary>
    private void Reset()
    {
        try
        {
            txtFromDate.Text = String.Empty;
            txttodate.Text = String.Empty;           
            //ddlSalesRepGroup.DataSource = "";
            //ddlSalesRepGroup.DataBind();                
            gvProposalSearch.Visible = false;
            lblRecordsCount.Visible = false;          
                   
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// GridBind method prepare data in grid view from Project page to Search Project Page
    /// </summary>
    private void GridBind()
   {
        try
        {
            if (ValidationCheck() == true)
             {
                DataTable dt = new DataTable();
                 string Qstr = String.Empty;
                string SearchVar = String.Empty;               
                if (txtFromDate.Text != "")
                {
                    Qstr += " AND tblProjects.WarrantyEndDate>='" + txtFromDate.Text + "' ";
                }
                if (txttodate.Text != "")
                {
                    Qstr += " AND tblProjects.WarrantyEndDate<='" + txttodate.Text + "' ";
                }                      
                Qstr += " order by tblPFiles.PNumber desc";
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.SearchVar = Qstr;
                ds = ObjBLL.GetProjects(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblRecordsCount.Text = "Total No. of Records:" + ds.Tables[0].Rows.Count.ToString();
                    lblRecordsCount.Visible = true;
                    gvProposalSearch.DataSource = ds;
                    gvProposalSearch.DataBind();
                    DataTable dtsearch = new DataTable();
                    dtsearch = ds.Tables[0];
                    ViewState["dirState"] = dtsearch;
                    gvProposalSearch.Visible = true;
                    btnExportToExcel.Enabled = true;
                }
                else
                {
                    lblRecordsCount.Text = "No Record Found.";
                    lblRecordsCount.Visible = true;
                    gvProposalSearch.DataSource = "";
                    gvProposalSearch.DataBind();
                    btnExportToExcel.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Search Button displays matching condition data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchProposal_Click(object sender, EventArgs e)
    {
        try
        {
            GridBind();
        }            
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

    /// <summary>
    /// Validation Check used for fields mandetory.
    /// </summary>
    /// <returns></returns>
    private Boolean ValidationCheck()
    {
        try
        {
            //if (txtFromDate.Text == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter From Date. !');", true);
            //    txtFromDate.Focus();
            //    return false;
            //}
            //if (txttodate.Text == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter To Date. !');", true);
            //    txttodate.Focus();
            //    return false;
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    /// <summary>
    /// Clear Button Reset all the TextBoxes and Drop Down Values
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearProposal_Click(object sender, EventArgs e)
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

    /// <summary>
    /// It used for mouse hand design
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProposalSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Change the mouse cursor to Hand symbol to show the user the cell is selectable
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.cursor = 'Pointer'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                //e.Row.Attributes["OnClientClick"] = "SetTarget();";
                e.Row.ToolTip = "Click to select this row.";
                //Attach the click event to each cells
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvProposalSearch, "Select$" + e.Row.RowIndex);
                //PrepareDT();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

    /// <summary>
    /// It used for read a row record from the Grid View Control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProposalSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Select")
            {                
                Session["JobID"] = "";                
                DataSet ds = new DataSet();
                ObjBOL.Operation = 3;
                int iIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = gvProposalSearch.Rows[iIndex];
                string PNumber = Server.HtmlDecode(gvRow.Cells[1].Text);
                //ObjBOL.PNumber = PNumber;
                //ds = ObjBLL.GetRepSearch(ObjBOL);
                //Session["JobID"] = ds.Tables[0].Rows[0]["JobID"].ToString();
                Session["JobID"] = PNumber;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OpenWindow", "window.open('FrmProjects.aspx','_blank')", true);
                //Response.Redirect("~/SalesManagement/FrmProposals.aspx");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Selected number of records display in the Grid View Control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProposalSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvProposalSearch.PageIndex = e.NewPageIndex;
            GridBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }       
    }  

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProposalSearch_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                DataView dataView = new DataView(dtrslt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvProposalSearch.DataSource = dataView;
                gvProposalSearch.DataBind();
            
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression  + "DESC";
                gvProposalSearch.DataSource = dtrslt;
                gvProposalSearch.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);   
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "DESC"; }
        set { ViewState["SortDirection"] = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sortDirection"></param>
    /// <returns></returns>
    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        switch (GridViewSortDirection)
        {
            case "ASC":
                GridViewSortDirection = "DESC";
                break;

            case "DESC":
                GridViewSortDirection = "ASC";
                break;
        }
        return GridViewSortDirection;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>    
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered, tem a ver com obotão de exportação para excel*/
    }  

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExportToExcel_Click1(object sender, EventArgs e)
    {
        string FileName = "Search Reps Details";
        gvProposalSearch.Attributes.Remove("class");
        //Utility.ExportToExcelGrid(gvProposalSearch, FileName);

        DataTable dt = (DataTable)ViewState["dirState"];
        Utility.ExportToExcelDT(dt, FileName);

    }
}