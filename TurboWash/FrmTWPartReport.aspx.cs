using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;

public partial class TurboWash_FrmTWPartReport : System.Web.UI.Page
{
    BOLTurboWashPart ObjBOL = new BOLTurboWashPart();
    BLLTurboWashPart ObjBLL = new BLLTurboWashPart();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindControls();
                LoadAllPart();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
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

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlTransactionBy, ds.Tables[2]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void LoadAllPart()
    {
        try
        {
            DataTable dt = new DataTable();
            clscon.Return_DT(dt, "Select id, PartNo FROM TW_Part_List() ORDER BY PartNo");
            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlPartLookupList, dt);
                ddlPartLookupList.SelectedIndex = 0;
            }
            else
            {
                ddlPartLookupList.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCategoryLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCategoryLookupList_SelectedIndexChanged_Event();
    }

    protected void ddlPartLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPartLookupList_SelectedIndexChanged_Event();
    }

    protected void ddlOptionLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlOptionLookupList_SelectedIndexChanged_Event();
    }

    protected void ddlOrientationLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlOrientationLookupList_SelectedIndexChanged_Event();
    }

    protected void ddlSizeLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSizeLookupList_SelectedIndexChanged_Event();
    }

    private void ddlSizeLookupList_SelectedIndexChanged_Event()
    {
        try
        {
            //CATEGORY lookup is populated and selected
            // ORIENTATION and OPTIONS lookup are already populated
            PopulatePartLookup();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlOrientationLookupList_SelectedIndexChanged_Event()
    {
        try
        {
            PopulatePartLookup();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlOptionLookupList_SelectedIndexChanged_Event()
    {
        try
        {
            // select category which is WASH SINK 
            SelectCategory("2");
            ddlCategoryLookupList_SelectedIndexChanged_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void ddlPartLookupList_SelectedIndexChanged_Event()
    {
        try
        {
            if (ddlPartLookupList.SelectedIndex > 0)
            {
                ObjBOL.Operation = 3;
                ObjBOL.ID = Int32.Parse(ddlPartLookupList.SelectedValue);
                DataRow row = ObjBLL.GetDataSet(ObjBOL).Tables[0].Rows[0];
                SelectCategory(row["CategoryID"].ToString());
                PopulateSizeLookup();
                SelectSize(row["SizeID"].ToString());
                SelectDirection(row["Direction"].ToString());
                SelectOption(row["OptionID"].ToString());
            }
            else
            {
                ResetPart();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void ddlCategoryLookupList_SelectedIndexChanged_Event()
    {
        try
        {
            PopulateSizeLookup();
            PopulatePartLookup();
            EnableAndDisableOptionLookup();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
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

    private void PopulatePartLookup()
    {
        try
        {
            DataTable dt = new DataTable();
            string query = " SELECT [ID], [PartNo]  ";
            query += " FROM TW_Part_List() ";
            query += " WHERE TW_Part_List.ID IS NOT NULL ";
            if (ddlCategoryLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part_List.CategoryID = " + ddlCategoryLookupList.SelectedValue;
            }

            if (ddlSizeLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part_List.SizeID = " + ddlSizeLookupList.SelectedValue;
            }

            if (ddlOrientationLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part_List.Direction = '" + ddlOrientationLookupList.SelectedValue + "' ";
            }

            if (ddlOptionLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part_List.OptionID = " + ddlOptionLookupList.SelectedValue;
            }

            query += " ORDER BY [PartNo]";

            clscon.Return_DT(dt, query);

            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartLookupList, dt);
                //ResetPartInfo();
            }
            else
            {
                ClearPartLookup();
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

    private void SelectSize(string sizeID)
    {
        try
        {
            if (sizeID.Trim() != "")
            {
                ddlSizeLookupList.SelectedValue = sizeID;
            }
            else
            {
                ddlSizeLookupList.SelectedValue = "0";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void SelectDirection(string directionID)
    {
        try
        {
            if (directionID.Trim() != "")
            {
                ddlOrientationLookupList.SelectedValue = directionID;
            }
            else
            {
                ddlOrientationLookupList.SelectedValue = string.Empty;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void SelectOption(string optionID)
    {
        try
        {
            if (optionID.Trim() != "" && optionID.Trim() != "0")
            {
                ddlOptionLookupList.SelectedValue = optionID;
            }
            else
            {
                ddlOptionLookupList.SelectedValue = "0";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        btnPreview_Click_Event();
    }

    protected void btnExportToPDF_Click(object sender, EventArgs e)
    {
        btnExportToPDF_Click_Event();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ResetAll();
    }

    private string PrepareSQLCommandForReport(bool forGrid)
    {
        try
        {
            string query = string.Empty;
            query += " SELECT TW_StockTransactions.ID, TW_Category.[name] AS Category, TW_Part_List.[PartNo] AS PartGroup, ";
            query += " CASE WHEN TransactQty < 0 THEN 'OUT' WHEN TransactQty > -1 THEN 'IN' END AS [TransactionType], ";
            query += " [OpeningStock], ABS([TransactQty]) AS [TransactQty], [ClosingStock], ";
            query += " [TransactionDateTime], [FirstName] AS [TransactionBy], [JobID] ";
            query += " FROM TW_StockTransactions ";
            query += " INNER JOIN TW_Part_List() ON TW_Part_List.id = TW_StockTransactions.PartID ";
            query += " LEFT JOIN tblEmployees ON tblEmployees.EmployeeID = TransactionBy ";
            query += " LEFT JOIN TW_Category ON TW_Category.id = TW_Part_List.CategoryID ";
            query += " WHERE TW_StockTransactions.ID IS NOT NULL ";

            if (ddlCategoryLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part_List.CategoryID = " + ddlCategoryLookupList.SelectedValue + " ";
            }

            if (ddlSizeLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part_List.SizeID = " + ddlSizeLookupList.SelectedValue + " ";
            }

            if (ddlOrientationLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part_List.Direction = '" + ddlOrientationLookupList.SelectedValue + "' ";
            }

            if (ddlOptionLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part_List.OptionID = " + ddlOptionLookupList.SelectedValue + " ";
            }

            if (ddlPartLookupList.SelectedIndex > 0)
            {
                query += " AND TW_Part_List.ID = " + ddlPartLookupList.SelectedValue + " ";
            }

            if (ddlTransactionType.SelectedIndex > 0)
            {
                if (ddlTransactionType.SelectedItem.Text.ToUpper() == "IN")
                {
                    query += " AND TW_StockTransactions.TransactQty > -1 ";
                }
                else if (ddlTransactionType.SelectedItem.Text.ToUpper() == "OUT")
                {
                    query += " AND TW_StockTransactions.TransactQty < 0 ";
                }
            }

            if (ddlTransactionBy.SelectedIndex > 0)
            {
                query += " AND TW_StockTransactions.TransactionBy = " + ddlTransactionBy.SelectedValue + " ";
            }

            if (txtTransactionDateFrom.Text != "" && txtTransactionDateTo.Text != "")
            {
                query += " AND CAST(TW_StockTransactions.[TransactionDateTime] AS date) >= '" + txtTransactionDateFrom.Text + "' ";
                query += " AND CAST(TW_StockTransactions.[TransactionDateTime] AS date) <= '" + txtTransactionDateTo.Text + "' ";
            }

            if (forGrid)
            {
                query += " ORDER BY TransactionDateTime DESC";
            }
            else
            {
                query += " ORDER BY Category, TransactionDateTime DESC";
            }
            return query;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return "";
    }

    private DataTable ReportData(bool forGrid)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = PrepareSQLCommandForReport(forGrid);
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
            DataTable dt = ReportData(false);
            rprt.Load(Server.MapPath("~/TurboWash/rptTWPartReport.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "TurboWash Inventory Transaction Report ";
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

    private void btnPreview_Click_Event()
    {
        try
        {
            DataTable dt = ReportData(true);
            if (dt.Rows.Count > 0)
            {
                gvTransactions.DataSource = dt;
                gvTransactions.DataBind();
            }
            else
            {
                gvTransactions.DataSource = string.Empty;
                gvTransactions.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetPart()
    {
        LoadAllPart();
    }

    private void ResetAll()
    {
        try
        {
            if (ddlCategoryLookupList.Items.Count > 0)
            {
                ddlCategoryLookupList.SelectedIndex = 0;
            }

            ddlPartLookupList.Items.Clear();
            ddlOrientationLookupList.SelectedIndex = 0;
            ddlOptionLookupList.SelectedIndex = 0;
            ClearSizeLookup();
            ResetPart();
            gvTransactions.DataSource = string.Empty;
            gvTransactions.DataBind();
            ddlTransactionBy.SelectedIndex = 0;
            ddlTransactionType.SelectedIndex = 0;
            txtTransactionDateFrom.Text = string.Empty;
            txtTransactionDateTo.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearSizeLookup()
    {
        try
        {
            ddlSizeLookupList.Items.Clear();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearPartLookup()
    {
        try
        {
            ddlPartLookupList.Items.Clear();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}