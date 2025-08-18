using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;


public partial class Service_FrmSearchServiceProposal : System.Web.UI.Page
{
    BOLSerProposals ObjBOL = new BOLSerProposals();
    BLLManageSerProposals ObjBLL = new BLLManageSerProposals();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindControls();             
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
    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 13;
            ds = ObjBLL.GetSerProposalsSearch(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProductLine, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlAssignedTo, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlTechnician, ds.Tables[2]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }
    /// <summary>
    /// Reset all the controls
    /// </summary>
    private void Reset()
    {
        try
        {           
            txtQuoteSentFrom.Text = String.Empty;
            txtQuoteSentTo.Text = String.Empty;
            ddlAssignedTo.SelectedIndex = 0;
            ddlNature.SelectedIndex = 0;
            ddlProductLine.SelectedIndex = 0;  
            ddlStatus.SelectedIndex = 0;
            gvProposalSearch.Visible = false;
            lblRecordsCount.Visible = false;
            Session["SessionProposalSearch"] = null;
            ddlTechnician.SelectedValue = "0";           
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
                if (txtServiceP.Text != "")
                {
                    Qstr += " AND Ser_Proposals.PNo LIKE '%" + txtServiceP.Text.Replace("'", "") + "%' ";
                }
                if (ddlProductLine.SelectedIndex > 0)
                {
                    Qstr += " AND Ser_Proposals.ConveyorSpecID='" + ddlProductLine.SelectedValue + "' ";
                }
                if (ddlAssignedTo.SelectedIndex > 0)
                {
                    Qstr += " AND Ser_Proposals.AssignedTo='" + ddlTechnician.SelectedValue + "' ";
                }
                if (ddlTechnician.SelectedIndex > 0)
                {
                    Qstr += " AND Ser_Proposals.Technician='" + ddlTechnician.SelectedValue + "' ";
                }
                if (ddlStatus.SelectedIndex > 0)
                {
                    Qstr += " AND Ser_Proposals.[Status]='" + ddlTechnician.SelectedValue + "' ";
                }
                if (ddlNature.SelectedIndex > 0)
                {
                    Qstr += " AND Ser_Proposals.[Nature]='" + ddlTechnician.SelectedValue + "' ";
                }
                if (txtQuoteSentFrom.Text != "")
                {
                    Qstr += " AND Ser_Proposals.QuoteSentDate>='" + txtQuoteSentFrom.Text + "' ";
                }
                if (txtQuoteSentTo.Text != "")
                {
                    Qstr += " AND Ser_Proposals.QuoteSentDate<='" + txtQuoteSentTo.Text + "' ";
                }
                if (rdbInclude.SelectedValue == "1")
                {
                    Qstr += " AND Ser_Projects.JNO IS NOT NULL ";
                }
                else if (rdbInclude.SelectedValue == "2")
                {
                    Qstr += " AND Ser_Projects.JNO IS NULL ";
                }
                Qstr += "ORDER BY Ser_Proposals.PNo";
                DataSet ds = new DataSet();
                ObjBOL.Operation = 14;
                ObjBOL.SearchVar = Qstr;
                ds = ObjBLL.GetSerProposalsSearch(ObjBOL);
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
        //try
        //{
        //    if (e.CommandName == "Select")
        //    {                
        //        Session["PNumber"] = "";                
        //        DataSet ds = new DataSet();
        //        ObjBOL.Operation = 3;
        //        int iIndex = Convert.ToInt32(e.CommandArgument);
        //        GridViewRow gvRow = gvProposalSearch.Rows[iIndex];
        //        string PNumber = Server.HtmlDecode(gvRow.Cells[0].Text);
        //        ObjBOL.PNumber = PNumber;
        //        ds = ObjBLL.GetProposalSearch(ObjBOL);
        //        Session["PNumber"] = ds.Tables[0].Rows[0]["Pnumber"].ToString();                
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OpenWindow", "window.open('FrmProposals.aspx','_blank')", true);
        //        //Response.Redirect("~/SalesManagement/FrmProposals.aspx"); 
        //    }            
        //}
        //catch (Exception ex)
        //{
        //    Utility.AddEditException(ex);
        //}
       
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
                //dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                //gvProposalSearch.DataSource = dtrslt;
                //gvProposalSearch.DataBind();
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

    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "DESC"; }
        set { ViewState["SortDirection"] = value; }
    }

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

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered, tem a ver com obotão de exportação para excel*/
    }  

    protected void btnExportToExcel_Click1(object sender, EventArgs e)
    {
        string FileName = "Search Service Proposal Details";
        gvProposalSearch.Attributes.Remove("class");
    
        Utility.ExportToExcelGrid(gvProposalSearch, FileName);
        
    }
}