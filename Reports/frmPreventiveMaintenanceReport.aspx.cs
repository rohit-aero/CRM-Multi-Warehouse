using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;

public partial class Reports_frmPreventiveMaintenanceReport : System.Web.UI.Page
{
    BOLPreventiveMaintenance ObjBOL = new BOLPreventiveMaintenance();
    BLLPreventiveMaintenance ObjBLL = new BLLPreventiveMaintenance();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
        }
    }

    #region Bind Functions

    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlJob, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlStatus, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Validation

    private bool IsNullOrWhiteSpace(string value)
    {
        return value == null || value.Trim().Length == 0;
    }

    private bool ValidationCheck()
    {
        try
        {
            if ((!IsNullOrWhiteSpace(txtPORecDateFrom.Text) && IsNullOrWhiteSpace(txtPORecDateTo.Text)) ||
            (IsNullOrWhiteSpace(txtPORecDateFrom.Text) && !IsNullOrWhiteSpace(txtPORecDateTo.Text)))
            {
                Utility.ShowMessage_Error(Page, "Please Select Both From And To PO Rec Date !");
                return false;
            }

            if ((!IsNullOrWhiteSpace(txtContractStartDateFrom.Text) && IsNullOrWhiteSpace(txtContractStartDateTo.Text)) ||
            (IsNullOrWhiteSpace(txtContractStartDateFrom.Text) && !IsNullOrWhiteSpace(txtContractStartDateTo.Text)))
            {
                Utility.ShowMessage_Error(Page, "Please Select Both From And To Contract Start Date !");
                return false;
            }

            if ((!IsNullOrWhiteSpace(txtContractEndDateFrom.Text) && IsNullOrWhiteSpace(txtContractEndDateTo.Text)) ||
            (IsNullOrWhiteSpace(txtContractEndDateFrom.Text) && !IsNullOrWhiteSpace(txtContractEndDateTo.Text)))
            {
                Utility.ShowMessage_Error(Page, "Please Select Both From And To Contract End Date !");
                return false;
            }

            if ((!IsNullOrWhiteSpace(txtInvoiceDateFrom.Text) && IsNullOrWhiteSpace(txtInvoiceDateTo.Text)) ||
            (IsNullOrWhiteSpace(txtInvoiceDateFrom.Text) && !IsNullOrWhiteSpace(txtInvoiceDateTo.Text)))
            {
                Utility.ShowMessage_Error(Page, "Please Select Both From And To Invoice Date !");
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    #endregion

    #region Event Handler Function

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }
    //}

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            ddlJob.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            txtPORecDateFrom.Text = string.Empty;
            txtPORecDateTo.Text = string.Empty;
            txtContractStartDateFrom.Text = string.Empty;
            txtContractStartDateTo.Text = string.Empty;
            txtContractEndDateFrom.Text = string.Empty;
            txtContractEndDateTo.Text = string.Empty;
            txtInvoiceDateFrom.Text = string.Empty;
            txtInvoiceDateTo.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnGenrate_Click(object sender, EventArgs e)
    {
        try
        {
            Get_PreventiveMaintenanceReport();
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
    }

    #endregion

    #region report functions

    private string PrepareSQLCommandForReport()
    {
        try
        {
            string Qstr = String.Empty;
            Qstr += " SELECT CONCAT(tblProjects.JobID, ', ' + tblCustomers.CompanyName, ', ' + tblCustomers.City, ', ' + tblStates.[State], ', ' + tblCountries.Country) AS [Project Name], ";
            Qstr += " ST.[Name] AS [status], MAIN.OrderNo, MAIN.[PONumber], CONVERT(VARCHAR, MAIN.[PORecDate], 101) AS [PORecDate], CONVERT(VARCHAR, MAIN.[ContractStartDate], 101) AS [ContractStartDate], ";
            Qstr += " CONVERT(VARCHAR, MAIN.[ContractEndDate], 101) AS [ContractEndDate], CONVERT(VARCHAR, MAIN.[LastTuneDate], 101) AS [LastTuneDate], CONVERT(VARCHAR, MAIN.[NextTuneDate], 101) AS [NextTuneDate], CONVERT(VARCHAR, MAIN.[InvoiceDate], 101) AS [InvoiceDate], MAIN.[InvoiceNo], ";
            Qstr += " CONVERT(CHAR(10), MAIN.[QuoteSentDate], 101) AS [QuoteSentDate], MAIN.QuoteAmount ";
            Qstr += " FROM CCT_tblPreventiveMaintenance MAIN ";
            Qstr += " LEFT JOIN tblProjects ON tblProjects.JobID = MAIN.JobID ";
            Qstr += " INNER JOIN tblCustomers ON tblCustomers.CustomerID = tblProjects.CustomerID ";
            Qstr += " LEFT JOIN tblCountries ON tblCustomers.CountryID = tblCountries.CountryID ";
            Qstr += " LEFT JOIN tblStates ON tblCustomers.StateID = tblStates.StateID ";
            Qstr += " LEFT JOIN CCT_tblPreventiveMaintenanceStatus ST on ST.ID = MAIN.StatusID ";
            Qstr += " WHERE tblProjects.JobID IS NOT NULL ";
            if (ddlJob.SelectedIndex > 0)
            {
                Qstr += " AND tblProjects.JobID  LIKE '%" + ddlJob.SelectedValue + "%' ";
            }

            if (ddlStatus.SelectedIndex > 0)
            {
                Qstr += " AND MAIN.StatusID = " + ddlStatus.SelectedValue + " ";
            }

            if (txtPORecDateFrom.Text != "" && txtPORecDateTo.Text != "")
            {
                if (txtPORecDateFrom.Text != "")
                {
                    Qstr += " AND MAIN.PORecDate >= '" + txtPORecDateFrom.Text + "' ";
                }
                if (txtPORecDateTo.Text != "")
                {
                    Qstr += " AND MAIN.PORecDate <= '" + txtPORecDateTo.Text + "' ";
                }
            }

            if (txtContractStartDateFrom.Text != "" && txtContractStartDateTo.Text != "")
            {
                if (txtContractStartDateFrom.Text != "")
                {
                    Qstr += " AND MAIN.ContractStartDate >= '" + txtContractStartDateFrom.Text + "' ";
                }
                if (txtContractStartDateTo.Text != "")
                {
                    Qstr += " AND MAIN.ContractStartDate <= '" + txtContractStartDateTo.Text + "' ";
                }
            }

            if (txtContractEndDateFrom.Text != "" && txtContractEndDateTo.Text != "")
            {
                if (txtContractEndDateFrom.Text != "")
                {
                    Qstr += " AND MAIN.ContractEndDate >= '" + txtContractEndDateFrom.Text + "' ";
                }
                if (txtContractEndDateTo.Text != "")
                {
                    Qstr += " AND MAIN.ContractEndDate <= '" + txtContractEndDateTo.Text + "' ";
                }
            }

            if (txtInvoiceDateFrom.Text != "" && txtInvoiceDateTo.Text != "")
            {
                if (txtInvoiceDateFrom.Text != "")
                {
                    Qstr += " AND MAIN.InvoiceDate >= '" + txtInvoiceDateFrom.Text + "' ";
                }
                if (txtInvoiceDateTo.Text != "")
                {
                    Qstr += " AND MAIN.InvoiceDate <= '" + txtInvoiceDateTo.Text + "' ";
                }
            }

            Qstr += " ORDER BY tblProjects.JobID ";
            return Qstr;
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
            //divError.Visible = true;
            if (ValidationCheck())
            {
                string query = PrepareSQLCommandForReport();
                if (query.Length > 1)
                {
                    clscon.Return_DT(dt, query);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void Get_PreventiveMaintenanceReport()
    {
        try
        {
            //divError.Visible = true;
            DataTable dt = ReportData();
            if (dt.Rows.Count > 0)
            {
                rprt.Load(Server.MapPath("~/Reports/rptPreventiveMaintenanceFilterReport.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Preventive Maintenance Filter Report ";
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Preventive Maintenance Filter Report ";
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }

    #endregion

}