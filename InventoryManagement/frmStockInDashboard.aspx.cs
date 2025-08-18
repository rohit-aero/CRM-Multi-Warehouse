using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;

public partial class INVManagement_frmStockInDashboard : System.Web.UI.Page
{
    BOLStockInDashboard ObjBOL = new BOLStockInDashboard();
    BLLStockInDashboard ObjBLL = new BLLStockInDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Utility.IsAuthorized())
        {
            if (!IsPostBack)
            {
                BindGridInTransit();
            }
        }      

    }

    private void BindGridInTransit()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvInTransit.DataSource = ds.Tables[0];
                gvInTransit.DataBind();
            }
            else
            {
                gvInTransit.DataSource = "";
                gvInTransit.DataBind();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                gvContainerArrived.DataSource = ds.Tables[1];
                gvContainerArrived.DataBind();
            }
            else
            {
                gvContainerArrived.DataSource = "";
                gvContainerArrived.DataBind();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                ViewState["dirState"] = ds.Tables[2];
                gvStockInhand.DataSource = ds.Tables[2];
                gvStockInhand.DataBind();
            }
            else
            {
                gvStockInhand.DataSource = "";
                gvStockInhand.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        
    }

    protected void gvInTransit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    protected void gvContainerArrived_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void gvStockInhand_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                if (gvStockInhand.Rows.Count > 0 && gvStockInhand.HeaderRow != null)
                {
                    foreach (TableCell cell in gvStockInhand.HeaderRow.Cells)
                    {
                        cell.ForeColor = System.Drawing.Color.White; // Change to white
                    }
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

    protected void gvStockInhand_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                DataView dataView = new DataView(dtrslt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvStockInhand.DataSource = dataView;
                gvStockInhand.DataBind();

            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + "DESC";
                gvStockInhand.DataSource = dtrslt;
                gvStockInhand.DataBind();
            }
            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //protected void gvStockInhand_Sorted(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        // Change header text color after sorting
    //        foreach (TableCell cell in gvStockInhand.HeaderRow.Cells)
    //        {
    //            cell.ForeColor = System.Drawing.Color.White; // Change to white
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
        
    //}
}