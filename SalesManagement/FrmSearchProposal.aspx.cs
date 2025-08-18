using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;

public partial class SalesManagement_FrmSearchProposal : System.Web.UI.Page
{
    BOLProposalSearch ObjBOL = new BOLProposalSearch();
    BLLProposalSearch ObjBLL = new BLLProposalSearch();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindControls();
                //SetValueonSession();
                // GridBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// SetValueonSession() store values from session to Data Table
    /// </summary>
    private void SetValueonSession()
    {
        try
        {
            if (Session["SessionProposalSearch"] != null)
            {
                DataTable dt = (DataTable)Session["SessionProposalSearch"];
                txtProposalName.Text = dt.Rows[0]["ProjectName"].ToString();
                ddlModelName.SelectedValue = dt.Rows[0]["ModelID"].ToString();
                ddlConveyorType.SelectedValue = dt.Rows[0]["ConveyorTypeID"].ToString();
                ddlPrimeSpec.SelectedValue = dt.Rows[0]["CompetitorID"].ToString();
                txtCity.Text = dt.Rows[0]["City"].ToString();
                ddlState.SelectedValue = dt.Rows[0]["StateID"].ToString();
                ddlCountry.SelectedValue = dt.Rows[0]["Country"].ToString();
                ddlConsultant.SelectedValue = dt.Rows[0]["ConsultantID"].ToString();
                ddldealer.SelectedValue = dt.Rows[0]["DealerID"].ToString();
                ddlSalesRep.SelectedValue = dt.Rows[0]["RepID"].ToString();
                txtFromDate.Text = Convert.ToDateTime(dt.Rows[0]["FromProposalDate"]).ToString("MM/dd/yyyy");
                txttodate.Text = Convert.ToDateTime(dt.Rows[0]["ToProposalDate"]).ToString("MM/dd/yyyy");
                GridBind();
                //Session.Contents.RemoveAll();
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
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetProposalSearch(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlModelName, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlConveyorType, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlPrimeSpec, ds.Tables[2]);
            }
            //if (ds.Tables[3].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlCity, ds.Tables[3]);
            //}
            //if (ds.Tables[4].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlState, ds.Tables[4]);
            //}
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlCountry, ds.Tables[5]);
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlConsultant, ds.Tables[6]);
            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddldealer, ds.Tables[7]);
            }
            if (ds.Tables[8].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlSalesRep, ds.Tables[8]);
            }
            if (ds.Tables[9].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlManager, ds.Tables[9]);
            }
            if (ds.Tables[10].Rows.Count > 0)
            {
                //Utility.BindDropDownListAll(ddlModelNew, ds.Tables[10]);
                ddlModelNewMultiSelectList.DataSource = ds.Tables[10];
                ddlModelNewMultiSelectList.DataBind();
            }
            if (ds.Tables[11].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlSalesRepGroup, ds.Tables[11]);
            }
            if (ds.Tables[12].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlIndustry, ds.Tables[12]);
            }
            if(ddlState.Items.Count == 0)
            {
                ResetState();
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
            txtProposalName.Text = String.Empty;
            txtFromDate.Text = String.Empty;
            txttodate.Text = String.Empty;
            ddlModelName.SelectedIndex = 0;
            ddlConveyorType.SelectedIndex = 0;
            //ddlModelNewMultiSelectList.Items.Clear();
            ddlPrimeSpec.SelectedIndex = 0;
            txtCity.Text = string.Empty;
            ddlCountry.SelectedIndex = 0;
            ResetState();
            ddlConsultant.SelectedIndex = 0;
            ddldealer.SelectedIndex = 0;
            ddlIndustry.SelectedIndex = 0;
            ddlSalesRep.SelectedIndex = 0;
            gvProposalSearch.Visible = false;
            lblRecordsCount.Visible = false;
            Session["SessionProposalSearch"] = null;
            rdbOrderFor.SelectedValue = "0";
            ddlSalesRepGroup.SelectedIndex = 0;
            //btnExportToExcel.Enabled = false;
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
                if (txtProposalName.Text != "")
                {
                    Qstr += " AND tblPFiles.ProjectName LIKE '%" + txtProposalName.Text.Replace("'", "") + "%' ";
                }
                if (ddlModelName.SelectedIndex > 0)
                {
                    Qstr += " AND tblConveyorModel.ModelID='" + ddlModelName.SelectedValue + "' ";
                }
                if (ddlConveyorType.SelectedIndex > 0)
                {
                    Qstr += " AND tblConveyorType.ConveyorTypeID='" + ddlConveyorType.SelectedValue + "' ";
                }
                if (ddlPrimeSpec.SelectedIndex > 0)
                {
                    Qstr += " AND tblCompetitor.CompetitorID='" + ddlPrimeSpec.SelectedValue + "' ";
                }
                if (txtCity.Text != "")
                {
                    Qstr += " AND tblPFiles.City LIKE '%" + txtCity.Text + "%' ";
                }
                if (ddlState.SelectedIndex > 0)
                {
                    Qstr += " AND tblPFiles.StateID='" + ddlState.SelectedValue + "' ";
                }
                if (ddlIndustry.SelectedIndex > 0)
                {
                    Qstr += " AND tblPFiles.Industry= '" + ddlIndustry.SelectedValue +"'";
                }
                if (ddlCountry.SelectedIndex > 0)
                {
                    Qstr += " AND tblPFiles.Country LIKE '%" + ddlCountry.SelectedItem.Text + "%' ";
                }
                if (ddlConsultant.SelectedIndex > 0)
                {
                    Qstr += " AND tblConsultants.ConsultantID='" + ddlConsultant.SelectedValue + "' ";
                }
                if (ddldealer.SelectedIndex > 0)
                {
                    Qstr += " AND tblDealers.DealerID='" + ddldealer.SelectedValue + "' ";
                }
                if (ddlSalesRepGroup.SelectedIndex > 0)
                {
                    Qstr += " AND tblHobartBranchListing.RepGroupID = " + ddlSalesRepGroup.SelectedValue + " ";
                }
                if (ddlSalesRep.SelectedIndex > 0)
                {
                    Qstr += " AND tblHobartListing.RepID='" + ddlSalesRep.SelectedValue + "' ";
                }
                if (ddlManager.SelectedIndex > 0)
                {
                    //Qstr += " AND (tblPFiles.projectmanagerid='" + ddlManager.SelectedValue + "'  OR tblPFiles.projectmanagerid=0) ";
                    Qstr += " AND tblPFiles.projectmanagerid='" + ddlManager.SelectedValue + "' ";
                }
                if (txtFromDate.Text != "")
                {
                    Qstr += " AND tblPFiles.ProposalDate>='" + txtFromDate.Text + "' ";
                }
                if (txttodate.Text != "")
                {
                    Qstr += " AND tblPFiles.ProposalDate<='" + txttodate.Text + "' ";
                }
                var index = 0;
                foreach (ListItem item in ddlModelNewMultiSelectList.Items)
                {
                    if (item.Selected && index == 0)
                    {
                        Qstr += " AND tblSelectedModels.ChildModelID IN ( ";
                        Qstr += "'" + item.Value + "'";
                        index++;
                    }
                    else if (item.Selected && index > 0)
                    {
                        Qstr += ",'" + item.Value + "'";
                        index++;
                    }
                }
                if (index > 0)
                {
                    Qstr += " ) ";
                }
                //if (rdbOrderFor.SelectedValue == "0")
                //{
                //    Qstr += " AND tblProjects.JobID IS NOT NULL ";
                //}
                //else 
                if (rdbOrderFor.SelectedValue == "1")
                {
                    Qstr += " AND tblProjects.JobID IS NOT NULL ";
                }
                else if (rdbOrderFor.SelectedValue == "2")
                {
                    Qstr += " AND tblProjects.JobID IS NULL ";
                }
                //if (chkJobs.Checked == true)
                //{                    
                //}
                //else if (chkJobs.Checked == false)
                //{                    
                //}
                Qstr += "  order by tblPFiles.PNumber desc";
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.SearchVar = Qstr;
                ds = ObjBLL.GetProposalSearch(ObjBOL);
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
                Session["PNumber"] = "";
                DataSet ds = new DataSet();
                ObjBOL.Operation = 3;
                int iIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = gvProposalSearch.Rows[iIndex];
                string PNumber = Server.HtmlDecode(gvRow.Cells[0].Text);
                ObjBOL.PNumber = PNumber;
                ds = ObjBLL.GetProposalSearch(ObjBOL);
                Session["PNumber"] = ds.Tables[0].Rows[0]["Pnumber"].ToString();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OpenWindow", "window.open('FrmProposals.aspx','_blank')", true);
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
                //dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                //gvProposalSearch.DataSource = dtrslt;
                //gvProposalSearch.DataBind();
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + "DESC";
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
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountry.SelectedIndex > 0)
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.country = Convert.ToInt32(ddlCountry.SelectedValue);
            ds = ObjBLL.GetProposalSearch(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlState, ds.Tables[0]);
            }
        }
        else
        {
            ResetState();
        }
    }

    private void ResetState()
    {
        try
        {
            ddlState.DataSource = "";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("All", "0"));
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
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
        string FileName = "Search Proposal Details";
        gvProposalSearch.Attributes.Remove("class");
        //DataTable dt = (DataTable)ViewState["dirState"];
        Utility.ExportToExcelGrid(gvProposalSearch, FileName);
        //Response.Clear();
        //Response.Buffer = true;
        //Response.ClearContent();        
        ////gvSearch.AllowPaging = false;
        //gvProposalSearch.AllowSorting = false;
        //GridBind();        
        //Response.AddHeader("Content-Disposition", string.Format("attachment;filename=" + FileName));
        //Response.Charset = "";
        //StringWriter strwritter = new StringWriter();
        //HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Response.ContentType = "application/vnd.ms-excel";
        //gvProposalSearch.RenderControl(htmltextwrtter);
        //Response.Write(strwritter.ToString());
        //Response.Flush();
        //Response.End();
    }
}