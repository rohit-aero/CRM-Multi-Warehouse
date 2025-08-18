using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Web.UI;

public partial class TurboWash_FrmTWParts : System.Web.UI.Page
{
    BOLTurboWashPart ObjBOL = new BOLTurboWashPart();
    BLLTurboWashPart ObjBLL = new BLLTurboWashPart();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

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
            ObjBOL.Operation = 1;
            DataSet ds = ObjBLL.GetDataSet(ObjBOL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlCategoryLookupList, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #region Event Handlers

    protected void ddlCategoryLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCategoryLookupList_SelectedIndexChanged_Event();
    }

    protected void ddlSizeLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlOrientationLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlOptionLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlOptionLookupList_SelectedIndexChanged_Event();
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        btnExportToPDF_Click_Event();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ResetAll();
    }

    #endregion

    #region Internal Functions

    private void ddlCategoryLookupList_SelectedIndexChanged_Event()
    {
        try
        {
            PopulateSizeLookup();
            EnableAndDisableOptionLookup();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlOptionLookupList_SelectedIndexChanged_Event()
    {
        SelectCategory("2");
        ddlCategoryLookupList_SelectedIndexChanged_Event();
    }

    private void PopulateSizeLookup()
    {
        try
        {
            if (ddlCategoryLookupList.SelectedIndex > 0)
            {
                ObjBOL.Operation = 2;
                ObjBOL.CategoryID = Int32.Parse(ddlCategoryLookupList.SelectedValue);
                DataSet ds = ObjBLL.GetDataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlSizeLookupList, ds.Tables[0]);
                    ddlSizeLookupList.SelectedIndex = 0;
                }
            }
            else
            {
                ClearSizeLookup();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableAndDisableOptionLookup()
    {
        try
        {
            if (ddlCategoryLookupList.SelectedValue == "2")
            {
                ddlOptionLookupList.Enabled = true;
            }
            else if (ddlCategoryLookupList.SelectedIndex > 0)
            {
                ddlOptionLookupList.Enabled = false;
                ddlOptionLookupList.SelectedIndex = 0;
            }
            else
            {
                ddlOptionLookupList.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SelectCategory(string categoryID)
    {
        try
        {
            if (categoryID.Trim() != "")
            {
                ddlCategoryLookupList.SelectedValue = categoryID;
            }
            else
            {
                ResetAll();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearSizeLookup()
    {
        ddlSizeLookupList.Items.Clear();
    }

    private void ResetAll()
    {
        try
        {
            if (ddlCategoryLookupList.Items.Count > 0)
            {
                ddlCategoryLookupList.SelectedIndex = 0;
            }

            ddlOptionLookupList.Enabled = true;
            ddlOrientationLookupList.SelectedIndex = 0;
            ddlOptionLookupList.SelectedIndex = 0;
            ClearSizeLookup();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private string PrepareSQLCommandForReport()
    {
        try
        {
            string query = string.Empty;
            query += " SELECT CASE WHEN TW_Category.ID = 2 THEN TW_Category.[name] + CASE WHEN OptionID = '1' THEN ' WITH DRAIN' WHEN OptionID = '2' THEN ' WITH SUMP' END ELSE TW_Category.[name] END AS CategoryName, TW_Size.SizeName, ISNULL(Direction, '-') AS Direction, ";
            query += " CASE WHEN OptionID = '1' THEN 'With Drain' WHEN OptionID = '2' THEN 'With Sump' ELSE '-' END AS [Option], TW_Part.PartNo AS PartNo, StockInHand, ";
            query += " SUM(CASE WHEN Inv_StockTransactions.TransactQty > 0 AND YEAR(Inv_StockTransactions.TransactDateTime) = YEAR(GETDATE()) THEN Inv_StockTransactions.TransactQty ELSE 0 END) AS StockYTDProduced, ";
            query += " ABS(SUM(CASE WHEN Inv_StockTransactions.TransactQty < 0 AND YEAR(Inv_StockTransactions.TransactDateTime) = YEAR(GETDATE()) THEN Inv_StockTransactions.TransactQty ELSE 0 END)) AS StockYTDUsed, ";
            query += " ISNULL((SELECT TOP 1 CLOSINGSTOCK FROM Inv_StockTransactions WHERE YEAR(TransactDateTime) <= (YEAR(GETDATE()) - 1 ) AND Inv_StockTransactions.PartID = TW_Part.ID ORDER BY TransactDateTime DESC), ISNULL((SELECT TOP 1 OpeningStock FROM Inv_StockTransactions WHERE YEAR(TransactDateTime) = YEAR(GETDATE()) AND Inv_StockTransactions.PartID = TW_Part.ID ORDER BY TransactDateTime ASC), TW_Part.StockInHand)) AS OpeningStockYTD ";
            query += " FROM Inv_StockTransactions ";
            query += " RIGHT JOIN TW_Part ON TW_Part.ID = Inv_StockTransactions.PartID ";
            query += " LEFT JOIN TW_Category ON TW_Category.id = TW_Part.CategoryID ";
            query += " LEFT JOIN TW_Size ON TW_Size.ID = TW_Part.SizeID ";
            query += " WHERE TW_Part.ID IS NOT NULL ";

            if (ddlCategoryLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part.CategoryID = " + ddlCategoryLookupList.SelectedValue + " ";
            }

            if (ddlSizeLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part.SizeID = " + ddlSizeLookupList.SelectedValue + " ";
            }

            if (ddlOrientationLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part.Direction = '" + ddlOrientationLookupList.SelectedValue + "' ";
            }

            if (ddlOptionLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part.OptionID = " + ddlOptionLookupList.SelectedValue + " ";
            }

            query += " GROUP BY TW_Part.ID, TW_Part.PartNo, TW_Category.[name],TW_Category.id, TW_Size.SizeName, TW_Part.Direction, TW_Part.OptionID, TW_Part.StockInHand ";
            query += " ORDER BY TW_Category.id";

            return query;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return "";
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            //string query = PrepareSQLCommandForReport();
            string query = "EXEC Get_TurbowashParts NULL, ";
            if (ddlCategoryLookupList.SelectedIndex > 0)
            {
                query += ddlCategoryLookupList.SelectedValue + ", ";
            }
            else
            {
                query += " NULL, ";
            }

            if (ddlSizeLookupList.SelectedIndex > 0)
            {
                query += ddlSizeLookupList.SelectedValue + ", ";
            }
            else
            {
                query += " NULL, ";
            }

            if (ddlOptionLookupList.SelectedIndex > 0)
            {
                query += ddlOptionLookupList.SelectedValue + ", ";
            }
            else
            {
                query += " NULL, ";
            }

            if (ddlOrientationLookupList.SelectedIndex > 0)
            {
                query += " '" + ddlOrientationLookupList.SelectedValue + "' ";
            }
            else
            {
                query += " NULL ";
            }

            if (query.Length > 1)
            {
                clscon.Return_DT(dt, query);
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void btnExportToPDF_Click_Event()
    {
        try
        {
            DataTable dt = ReportData();
            rprt.Load(Server.MapPath("~/TurboWash/rptTWParts.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Turbo Wash Parts Report " + DateTime.Now.Year.ToString();
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = ReportData();
            Utility.ExportToExcelDT(dt, "Turbowash Parts Report");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion
}