using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_FrmSiteVisitReport : System.Web.UI.Page
{
    BOLSiteVisitInformation ObjBOL = new BOLSiteVisitInformation();
    BLLSiteVisitInformation ObjBLL = new BLLSiteVisitInformation();
    commonclass1 cls = new commonclass1();
    ReportDocument rpt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControl();
        }
    }

    private void BindControl()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.Return_DataSet(ObjBOL);

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlJobNo, ds.Tables[0]);
            //}

            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlEmployee, ds.Tables[3]);
            }

            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlState, ds.Tables[4]);
            }

            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRegion, ds.Tables[5]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool IsNullOrWhiteSpace(string value)
    {
        return value == null || value.Trim().Length == 0;
    }

    private bool ValidationCheck()
    {
        try
        {
            if ((!IsNullOrWhiteSpace(txtFromDate.Text) && IsNullOrWhiteSpace(txtToDate.Text)) ||
            (IsNullOrWhiteSpace(txtFromDate.Text) && !IsNullOrWhiteSpace(txtToDate.Text)))
            {
                Utility.ShowMessage_Error(Page, "Please Select Both From And To Site Visit Date !");
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            ddlEmployee.SelectedIndex = 0;
            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;
            ddlRegion.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            //ddlJobNo.SelectedIndex = 0;
            txtSearch.Text = string.Empty;
            gvSearch.DataSource = string.Empty;
            gvSearch.DataBind();
            btnExportToExcel.Enabled = false;
            btnExportToPDF.Enabled = false;
            gvSearch.Visible = false;
            lblRecordsCount.Visible = false;
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
            if (ValidationCheck())
            {
                DataTable dt = new DataTable();
                dt = ReportData();
                if (dt.Rows.Count > 0)
                {
                    btnExportToExcel.Enabled = true;
                    btnExportToPDF.Enabled = true;
                    gvSearch.Visible = true;

                    lblRecordsCount.Text = "Total No. of Records:" + dt.Rows.Count.ToString();
                    lblRecordsCount.Visible = true;
                    gvSearch.DataSource = dt;
                    ViewState["dirState"] = dt;
                    gvSearch.DataBind();
                }
                else
                {
                    btnExportToExcel.Enabled = false;
                    btnExportToPDF.Enabled = false;
                    gvSearch.Visible = true;
                    lblRecordsCount.Visible = false;
                    gvSearch.DataSource = string.Empty;
                    ViewState["dirState"] = string.Empty;
                    gvSearch.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnExportToPDF_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportData();
            rpt.Load(Server.MapPath("~/Reports/rptSiteVisitReport.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rpt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Site Visit Information From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Site Visit Information ";
                }
                rpt.SetDataSource(dt);
                rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rpt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rpt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = "Site Visit Information From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                else
                {
                    txtheader.Text = "Site Visit Information ";
                }
                rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            rpt.Close();
            rpt.Dispose();
        }
    }

    protected void btnGenerateExcel(object sender, EventArgs e)
    {
        try
        {
            Utility.ExportToExcelGrid(gvSearch, "Site_Visit_Information");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void gvSearch_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                DataView dataView = new DataView(dtrslt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvSearch.DataSource = dataView;
                gvSearch.DataBind();
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + "DESC";
                gvSearch.DataSource = dtrslt;
                gvSearch.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
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

    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "DESC"; }
        set { ViewState["SortDirection"] = value; }
    }

    private string PrepareQuery()
    {
        string query = "";
        try
        {
            query += " SELECT Region, ";
            query += " CASE WHEN PurposeID = 1 THEN 'Presale meeting' WHEN PurposeID = 2 THEN 'Exisiting projects site visits'  WHEN PurposeID = 3 THEN 'Post-install site visits' END AS Purpose, tblEmployees.FirstName AS Requestor, ";
            query += " ( SELECT STRING_AGG(tblEmployees.FirstName, ', ') FROM tblEmployees WHERE ',' + tblSiteVisitInformation.EmployeeIDs + ',' LIKE '%,' + CAST(tblEmployees.EmployeeID AS VARCHAR(10)) + ',%' ) AS [Employee Names], ";
            query += " tblPFiles.PNumber, ";
            query += " CONCAT(tblProjects.JobID + ', ', tblPFiles.ProjectName, ', ' + tblPFiles.City, ', ' + S1.[State], ', ' + tblPFiles.Country) AS [Project Name], ";
            query += " CONVERT(VARCHAR, SiteVisitDate, 101) AS [Site Visit Date], CONVERT(VARCHAR, NextVisitDate, 101) AS [Next Visit Date], tblSiteVisitInformation.SiteContactName AS [Site Contact Name], tblSiteVisitInformation.SiteContactNumber AS [Site Contact Number], Remarks, tblStates.[State] ";
            query += " FROM tblSiteVisitInformation ";
            query += " LEFT JOIN tblCountries ON tblCountries.CountryID = tblSiteVisitInformation.CountryID ";
            query += " LEFT JOIN tblStates ON tblStates.StateID = tblSiteVisitInformation.StateID ";
            query += " LEFT JOIN tblProjects ON tblProjects.ProposalID = tblSiteVisitInformation.PNumber ";
            query += " LEFT JOIN tblPFiles ON tblPFiles.PNumber = tblSiteVisitInformation.PNumber ";
            query += " LEFT JOIN tblStates S1 ON S1.StateID = tblPfiles.StateID ";
            query += " LEFT JOIN tblHobartRegions ON tblHobartRegions.RegionID = tblSiteVisitInformation.RegionID ";
            query += " LEFT JOIN tblEmployees ON tblEmployees.EmployeeID = tblSiteVisitInformation.RequestorID ";
            query += " WHERE tblSiteVisitInformation.ID IS NOT NULL ";
            if (ddlRegion.SelectedIndex > 0)
            {
                query += " AND tblSiteVisitInformation.RegionID = " + ddlRegion.SelectedValue + " ";
            }

            if (ddlState.SelectedIndex > 0)
            {
                query += " AND tblSiteVisitInformation.StateID = " + ddlState.SelectedValue + " ";
            }

            if (txtSearch.Text != "")
            {
                query += " AND (tblPFiles.PNumber Like '" + txtSearch.Text + "' + '%' ";
                query += " OR tblProjects.JobID Like '" + txtSearch.Text + "'+ '%') ";
            }

            if (txtFromDate.Text != "")
            {
                query += " AND tblSiteVisitInformation.SiteVisitDate >= '" + txtFromDate.Text + "' ";
            }

            if (txtToDate.Text != "")
            {
                query += " AND tblSiteVisitInformation.SiteVisitDate <= '" + txtToDate.Text + "' ";
            }

            if (ddlEmployee.SelectedIndex > 0)
            {
                query += " AND ',' + tblSiteVisitInformation.EmployeeIDs + ',' LIKE '%,' + CAST(" + ddlEmployee.SelectedValue + " AS VARCHAR(10)) + ',%'  ";
            }
            query += " ORDER BY [Site Visit Date] ";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

        return query;
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = PrepareQuery();
            if (query.Trim() != "")
            {
                cls.Return_DT(dt, query);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }
}