using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections.Generic;
using System.Linq;
using BOLAERO;
using BLLAERO;

public partial class Reports_frmJobsStatusReport : System.Web.UI.Page
{
    BOLPurchaseHistoryDetails ObjBOL = new BOLPurchaseHistoryDetails();
    BLLPurchaseHistoryDetails ObjBLL = new BLLPurchaseHistoryDetails();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Controls();
        }
    }

    private void Bind_Controls()
    {
        try
        {
            string Qstr = String.Empty;
            DataTable dt = new DataTable();
            DataTable dtProjectNumber = new DataTable();
            DataTable dtProjectName = new DataTable();
            Qstr += " Order by ProjectNumber DESC";
            clscon.Return_DT(dt, "EXEC [dbo].[Get_ContainerJobs_RT] 1,'" + Qstr + "'");
            if (dt.Rows.Count > 0)
            {
                dtProjectNumber = Utility.GetDistinctColumnValues(dt, "Project Number");
                dtProjectName = Utility.GetDistinctColumnValues(dt, "Project Name");
                if (dtProjectNumber.Rows.Count > 0)
                {
                    Utility.BindDropDownListAll(ddlProjectNumber, dtProjectNumber);
                    if (ddlProjectNumber.Items.Count > 0)
                    {
                        ddlProjectNumber.SelectedIndex = 0;
                    }
                }
                if (dtProjectName.Rows.Count > 0)
                {
                    Utility.BindDropDownListAll(ddlProjectName, dtProjectName);
                    if (ddlProjectName.Items.Count > 0)
                    {
                        ddlProjectName.SelectedIndex = 0;
                    }
                }
                BindProjectManager();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindProjectManager()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ds = ObjBLL.GetJobsStatusReport(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectManager, ds.Tables[0]);
                if (ddlProjectManager.Items.Count > 0)
                {
                    ddlProjectManager.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public static DataTable GetDistinctColumns(DataTable dt, params string[] columnNames)
    {
        DataTable distinctTable = new DataTable();
        try
        {

            // Add specified columns to the result table
            foreach (var columnName in columnNames)
            {
                distinctTable.Columns.Add(columnName, dt.Columns[columnName].DataType);
            }

            // Use a HashSet to track unique combinations
            HashSet<string> uniqueKeys = new HashSet<string>();

            foreach (DataRow row in dt.Rows)
            {
                // Create a unique key by combining column values
                string key = string.Join("|", columnNames.Select(column => row[column] == null ? "" : row[column].ToString()).ToArray());

                // Check if the key already exists in the HashSet
                if (uniqueKeys.Add(key)) // Add returns true if key is new
                {
                    // If unique, add the row values to the distinct table
                    DataRow newRow = distinctTable.NewRow();
                    foreach (var columnName in columnNames)
                    {
                        newRow[columnName] = row[columnName];
                    }
                    distinctTable.Rows.Add(newRow);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }


        return distinctTable;
    }

    private Boolean ValidationCheck()
    {
        try
        {
            if (txtFromDate.Text != "")
            {
                if (txtToDate.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter To Date !!");
                    txtToDate.Focus();
                    return false;
                }
            }
            if (txtToDate.Text != "")
            {
                if (txtFromDate.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter From Date !!");
                    txtToDate.Focus();
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private DataTable Bind_Report()
    {
        DataTable dt = new DataTable();
        try
        {
            DataSet ds = new DataSet();
            string Qstr = string.Empty;
            if (ddlProjectStatus.SelectedIndex > 0)
            {
                Qstr += " AND [Status] = '" + ddlProjectStatus.SelectedValue + "' ";
            }
            if (ddlProjectNumber.SelectedIndex > 0)
            {
                Qstr += " And ProjectNumber='" + ddlProjectNumber.SelectedValue + "' ";
            }
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
                DateTime dtto = Convert.ToDateTime(txtToDate.Text);
                string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
                string strDateTo = dtto.ToString("MM/dd/yyyy");
                Qstr += " AND Shipdate BETWEEN '" + strDateFrom + "' AND '" + strDateTo + "'";
            }
            if (ddlProjectName.SelectedIndex > 0)
            {
                Qstr += " AND ProjectName Like '%" + ddlProjectName.SelectedItem.Text + "%'";
            }
            if (ddlProjectManager.SelectedIndex > 0)
            {
                Qstr += " AND ProjectManager Like '%" + ddlProjectManager.SelectedItem.Text + "%'";
            }
            Qstr += " Order by ProjectNumber DESC";
            ObjBOL.Operation = 1;
            ObjBOL.SearchVar = Qstr;
            ds = ObjBLL.GetJobsStatusReport(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }




    //btnGenerate_Click
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string headerText = "Project Status Report ";
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    headerText += " From " + txtFromDate.Text + " to " + txtToDate.Text;
                }
                DataTable dtReport = new DataTable();
                dtReport = (DataTable)Bind_Report();
                rprt.Load(Server.MapPath("~/Reports/rptJobsStatus.rpt"));

                if (dtReport.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = headerText;
                    rprt.SetDataSource(dtReport);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = headerText;
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
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


    //btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddlProjectStatus.SelectedIndex = 0;
            txtFromDate.Text = String.Empty;
            txtToDate.Text = String.Empty;
            Bind_Controls();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


}