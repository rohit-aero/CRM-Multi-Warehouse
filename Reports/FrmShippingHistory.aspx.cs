using BLLAERO;
using BOLAERO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_FrmShippingHistory : System.Web.UI.Page
{
    commonclass1 commonClass = new commonclass1();
    BOLShippingHistory ObjBOL = new BOLShippingHistory();
    BLLShippingHistory ObjBLL = new BLLShippingHistory();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
        }
    }

    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            commonClass.Return_DS(ds, "EXEC Get_ShippingHistory 1");

            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlCountry, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlState, ds.Tables[1]);
                ViewState["StateList"] = ds.Tables[1];
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlIndustry, ds.Tables[2]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShippingHistory_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                DataView dataView = new DataView(dtrslt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvShippingHistory.DataSource = dataView;
                gvShippingHistory.DataBind();
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + "DESC";
                gvShippingHistory.DataSource = dtrslt;
                gvShippingHistory.DataBind();
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

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            if (ddlCountry.SelectedIndex > 0)
            {
                ObjBOL.CountryId = Int32.Parse(ddlCountry.SelectedValue);
            }

            if (ddlState.SelectedIndex > 0)
            {
                ObjBOL.StateId = Int32.Parse(ddlState.SelectedValue);
            }

            if (ddlIndustry.SelectedIndex > 0)
            {
                ObjBOL.IndustryId = Int32.Parse(ddlIndustry.SelectedValue);
            }

            ObjBOL.City = txtCity.Text;
            if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
            {
                ObjBOL.FromDate = Utility.ConvertDate(txtFromDate.Text);
                ObjBOL.ToDate = Utility.ConvertDate(txtToDate.Text);
            }

            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvShippingHistory.DataSource = ds.Tables[0];
                gvShippingHistory.DataBind();
                ViewState["dirState"] = ds.Tables[0];
                lblRecordsCount.Text = "Total No. of Records: " + ds.Tables[0].Rows.Count.ToString();
                lblRecordsCount.Visible = true;
                btnExportToExcel.Enabled = true;
            }
            else
            {
                gvShippingHistory.DataSource = string.Empty;
                gvShippingHistory.DataBind();
                lblRecordsCount.Text = "No Record Found.";
                lblRecordsCount.Visible = true;
                btnExportToExcel.Enabled = false;
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
            Utility.ExportToExcelGrid(gvShippingHistory, "Shipping History");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            ddlCountry.SelectedIndex = 0;
            Utility.BindDropDownListAll(ddlState, (DataTable)ViewState["StateList"]);
            ddlState.SelectedIndex = 0;
            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlIndustry.SelectedIndex = 0;
            gvShippingHistory.DataSource = string.Empty;
            gvShippingHistory.DataBind();
            lblRecordsCount.Text = string.Empty;
            lblRecordsCount.Visible = false;
            btnExportToExcel.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCountry.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                commonClass.Return_DT(dt, "EXEC Get_ShippingHistory 2, " + ddlCountry.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    Utility.BindDropDownListAll(ddlState, dt);
                }
                else
                {
                    ddlState.Items.Clear();
                }
            }
            else
            {
                Utility.BindDropDownListAll(ddlState, (DataTable)ViewState["StateList"]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered (used for export to excel)*/
    }

    protected void gvShippingHistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.cursor = 'Pointer'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.ToolTip = "Click to visit project";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvShippingHistory, "Select$" + e.Row.RowIndex);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShippingHistory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Select")
            {
                GridViewRow clickedRow = gvShippingHistory.Rows[Convert.ToInt32(e.CommandArgument)];
                Label lblJobID = (Label)clickedRow.FindControl("lblJobID");
                string jobId = lblJobID.Text.ToString();
                string link = "window.open('/SalesManagement/FrmProjects.aspx?jid=" + jobId + "', '_blank');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "openWindow", link, true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}