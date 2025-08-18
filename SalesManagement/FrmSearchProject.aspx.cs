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

public partial class SalesManagement_FrmSearchProject : System.Web.UI.Page
{
    BOLProjectSearch ObjBOL = new BOLProjectSearch();
    BLLProjectSearch ObjBLL = new BLLProjectSearch();
    commonclass1 cls = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindControls();
                //SetValueonSession();
                // Grd_Bind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// BindControl() function bind all Drop Down Lists on the Search Proposal PAGE 
    /// </summary>
    //Search Project Details Drop Down Control
    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetProjectSearch(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlModelName, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlConveyorName, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                //Utility.BindDropDownListAll(ddlBusinessName, ds.Tables[2]);
            }
            //if (ds.Tables[3].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlCityName, ds.Tables[3]);
            //}
            //if (ds.Tables[4].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlStateName, ds.Tables[4]);
            //}
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlCountryName, ds.Tables[5]);
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlConsultantName, ds.Tables[6]);
            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlDealerName, ds.Tables[7]);
            }
            if (ds.Tables[8].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlRepName, ds.Tables[8]);
            }
            if (ds.Tables[9].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlManager, ds.Tables[9]);
            }
            if (ds.Tables[10].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlMfacility, ds.Tables[10]);
            }

            if (ds.Tables[11].Rows.Count > 0)
            {
                //Utility.BindDropDownListAll(ddlModelNew, ds.Tables[10]);
                ddlModelNewMultiSelectList.DataSource = ds.Tables[11];
                ddlModelNewMultiSelectList.DataBind();
            }

            if (ds.Tables[12].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlSalesRepGroup, ds.Tables[12]);
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
    //Reset Controls
    private void ClearSearch()
    {
        try
        {
            txtProjectName.Text = String.Empty;
            txtFromDate.Text = String.Empty;
            txtToDate.Text = String.Empty;
            ddlModelName.SelectedIndex = 0;
            ddlConveyorName.SelectedIndex = 0;
            //ddlBusinessName.SelectedIndex = 0;
            txtCity.Text = "";
            //ddlStateName.SelectedIndex = 0;
            ddlCountryName.SelectedIndex = 0;
            ddlConsultantName.SelectedIndex = 0;
            ddlDealerName.SelectedIndex = 0;
            ddlRepName.SelectedIndex = 0;
            ddlStateName.DataSource = "";
            ddlStateName.DataBind();
            gvSearchProject.Visible = false;
            lblRecordsCount.Visible = false;
            Session["SessionProjectSearch"] = null;
            lblRecordsCount.Visible = false;
            gvSearchProject.DataSource = "";
            gvSearchProject.DataBind();
            btnExportToExcel.Enabled = false;
            ddlMfacility.SelectedIndex = 0;
            ddlSalesRepGroup.SelectedIndex = 0;
            txtPONo.Text = string.Empty;
            ddlManager.SelectedIndex = 0;
            foreach (System.Web.UI.WebControls.ListItem item in ddlModelNewMultiSelectList.Items)
            {
                item.Selected = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }
    /// <summary>
    /// Clear Button Reset all the TextBoxes and Drop Down Values
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //Search Clear Button
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            ClearSearch();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Grd_Bind method prepare data in grid view from Project page to Search Project Page
    /// </summary>
    //Grid View Return Data using Session from search to project page
    private void Grd_Bind()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                DataTable dt = new DataTable();
                string Qstr = string.Empty;
                if (txtProjectName.Text != "")
                {
                    Qstr += " AND tblCustomers.CompanyName LIKE '%" + txtProjectName.Text.Replace("'", "''") + "%' ";
                }
                if (ddlModelName.SelectedIndex > 0)
                {
                    Qstr += " AND tblPFiles.ModelID='" + ddlModelName.SelectedValue + "' ";
                }
                if (ddlConveyorName.SelectedIndex > 0)
                {
                    Qstr += " AND tblConveyorType.ConveyorTypeID='" + ddlConveyorName.SelectedValue + "' ";
                }
                if (ddlBusinessName.SelectedIndex > 0)
                {
                    Qstr += " AND tblBusinessType.BusinessTypeID='" + ddlBusinessName.SelectedValue + "' ";
                }
                if (txtCity.Text != "")
                {
                    Qstr += " AND tblCustomers.City LIKE '%" + txtCity.Text.Replace("'", "''") + "%' ";
                }
                if (ddlStateName.SelectedIndex > 0)
                {
                    Qstr += " AND tblStates.StateID='" + ddlStateName.SelectedValue + "' ";
                }
                if (ddlCountryName.SelectedIndex > 0)
                {
                    Qstr += " AND tblCustomers.CountryID='" + ddlCountryName.SelectedValue + "' ";
                }
                if (ddlConsultantName.SelectedIndex > 0)
                {
                    Qstr += " AND tblConsultants.ConsultantID='" + ddlConsultantName.SelectedValue + "' ";
                }
                if (ddlDealerName.SelectedIndex > 0)
                {
                    Qstr += " AND tblDealers.DealerID='" + ddlDealerName.SelectedValue + "' ";
                }
                if (ddlSalesRepGroup.SelectedIndex > 0)
                {
                    Qstr += " AND tblHobartBranchListing.RepGroupID = " + ddlSalesRepGroup.SelectedValue + " ";
                }
                if (ddlRepName.SelectedIndex > 0)
                {
                    Qstr += " AND tblHobartListing.RepID='" + ddlRepName.SelectedValue + "'  ";
                }
                if (ddlManager.SelectedIndex > 0)
                {
                    Qstr += " AND tblPFiles.projectmanagerid='" + ddlManager.SelectedValue + "' ";
                }
                if (txtPONo.Text != "")
                {
                    Qstr += " AND tblProjects.PONumber LIKE '%" + txtPONo.Text.Replace("'", "''") + "%' ";
                }
                if (txtFromDate.Text != "")
                {
                    Qstr += " AND tblProjects.ShipDate>='" + txtFromDate.Text + "'  ";
                }
                if (txtToDate.Text != "")
                {
                    Qstr += " AND tblProjects.ShipDate<='" + txtToDate.Text + "'  ";
                }
                if (ddlMfacility.SelectedIndex > 0)
                {
                    Qstr += " AND tblProjects.MfgFacilityID='" + ddlMfacility.SelectedValue + "' ";
                }

                var index = 0;
                foreach (System.Web.UI.WebControls.ListItem item in ddlModelNewMultiSelectList.Items)
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

                Qstr += "   Order By tblProjects.JobID desc";
                gvSearchProject.Visible = false;
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.SearchVar = Qstr;
                ds = ObjBLL.GetProjectSearch(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblRecordsCount.Text = "Total No. of Records:" + ds.Tables[0].Rows.Count.ToString();
                    lblRecordsCount.Visible = true;
                    gvSearchProject.DataSource = ds;
                    gvSearchProject.DataBind();
                    DataTable dtsearch = new DataTable();
                    dtsearch = ds.Tables[0];
                    ViewState["dirState"] = dtsearch;
                    gvSearchProject.Visible = true;
                    btnExportToExcel.Enabled = true;
                }
                else
                {
                    lblRecordsCount.Text = "No Records Found.";
                    lblRecordsCount.Visible = true;
                    gvSearchProject.DataSource = "";
                    gvSearchProject.DataBind();
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
    //Search Button Grid View Bind
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Grd_Bind();
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
    //Search page to Project Page Control
    protected void gvSearchProject_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Change the mouse cursor to Hand symbol to show the user the cell is selectable
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.cursor = 'Pointer'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                //Attach the click event to each cells
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvSearchProject, "Select$" + e.Row.RowIndex);
                //string jid = DataBinder.Eval(e.Row.DataItem, "JobID") + "";
                //e.Row.Attributes.Add("onclick", "opennewwindow('" + jid + "')");
                //PrepareDT();
                //this.style.textDecoration = 'underline';                                
            }
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
            //if (txtToDate.Text == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter To Date. !');", true);
            //    txtToDate.Focus();
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
    /// It used for read a row record from the Grid View Control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSearchProject_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Select")
            {
                Session["JobID"] = "";
                DataSet ds = new DataSet();
                ObjBOL.Operation = 3;
                int iIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = gvSearchProject.Rows[iIndex];
                string JobID = Server.HtmlDecode(gvRow.Cells[0].Text);
                ObjBOL.JobID = JobID;
                ds = ObjBLL.GetProjectSearch(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["JobID"] = ds.Tables[0].Rows[0]["JobID"].ToString();
                    //Response.Redirect("~/SalesManagement/FrmProject.aspx");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OpenWindow", "window.open('FrmProjects.aspx','_blank')", true);
                }
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

    protected void gvSearchProject_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                DataView dataView = new DataView(dtrslt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvSearchProject.DataSource = dataView;
                gvSearchProject.DataBind();
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + "DESC";
                gvSearchProject.DataSource = dtrslt;
                gvSearchProject.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSearchProject_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvSearchProject.PageIndex = e.NewPageIndex;
            Grd_Bind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCountryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountryName.SelectedIndex > 0)
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.country = Convert.ToInt32(ddlCountryName.SelectedValue);
            ds = ObjBLL.GetProjectSearch(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlStateName, ds.Tables[0]);
            }
        }
        else
        {
            ddlStateName.DataSource = "";
            ddlStateName.DataBind();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered, tem a ver com o botão de exportação para excel*/
    }

    protected void btnExportToExcel_Click1(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        string FileName = "Search Project Details" + ".xls";
        //gvSearch.AllowPaging = false;
        gvSearchProject.AllowSorting = false;
        gvSearchProject.AllowSorting = false;
        Grd_Bind();
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename=" + FileName));
        Response.Charset = "";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        gvSearchProject.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.Flush();
        Response.End();
    }
}