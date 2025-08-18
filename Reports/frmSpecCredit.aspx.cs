using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;

public partial class Reports_frmSpecCredit : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
       
        try
        {
            if (!IsPostBack)
            {

                int Month = DateTime.Now.Month + 2;
                txtFromDate.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
                txtToDate.Text = DateTime.Now.AddMonths(2).Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(2).Month) + "/" + DateTime.Now.AddMonths(2).Year;
                BindCountry();
                ddlCountry.SelectedValue = "2";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void BindCountry()
    {
        try
        {
            Utility.BindDropDownList(ddlCountry, Utility.GetCountries());
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    private Boolean ValidationCheck()
    {
        try
        {
            if (txtFromDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter From Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter From Date. !!");
                txtFromDate.Focus();
                return false;
            }

            if (txtToDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter To Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter To Date. !!");
                txtToDate.Focus();
                return false;
            }

            if (ddlCountry.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Country. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Country. !!");
                ddlCountry.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }


        return true;
    }

    private void Check_Url(string id)
    {
        try
        {
            if (id != null)
            {
                //Hobart Commission Report 
                if (id == "0")
                {
                    GenrateReport_Zero();
                }
                //Internal Commission Report
                else if (id == "1")
                {
                    GenrateReport_First();
                }
                //Monthly Commission Report
                else if (id == "2")
                {
                    GenrateReport_Second();
                }
                //Hobart Commission Payment Report
                else if (id == "3")
                {
                    GenrateReport_Third();
                }
            }
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
    }

    private void Check_UrlExcel(string id)
    {
        try
        {
            if (id != null)
            {
                //Hobart Commission Report 
                if (id == "0")
                {
                    GenrateReport_ZeroExcel();
                }
                //Internal Commission Report
                else if (id == "1")
                {
                    GenrateReport_FirstExcel();
                }
                //Monthly Commission Report
                else if (id == "2")
                {
                    GenrateReport_SecondExcel();
                }
                //Hobart Commission Payment Report
                else if (id == "3")
                {
                    GenrateReport_ThirdExcel();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable ReportDataZero()
    {
        DataTable dt = new DataTable();
        try
        {            
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_SpecCreditCommisission] '" + strDateFrom + "','" + strDateTo + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport_Zero()
    {
        try
        {           
            DataTable dt = ReportDataZero();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptSpecCreditReport.rpt"));
            
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Spec Credit Commission Report From " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Spec Credit Commission Report From " + strDateFrom + " to " + strDateTo;
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

    private void GenrateReport_ZeroExcel()
    {
        try
        {            
            DataTable dt = ReportDataZero();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptSpecCreditReport.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Spec Credit Commission Report From " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Spec Credit Commission Report From " + strDateFrom + " to " + strDateTo;
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

    private DataTable ReportDataFirst()
    {
        DataTable dt = new DataTable();
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_SpecCreditCommissionPending] '" + strDateFrom + "','" + strDateTo + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport_First()
    {
        try
        {            
            DataTable dt = ReportDataFirst();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptSpecCreditCommissionPending.rpt"));            
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Spec Credit Application Pending Report From " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Spec Credit Application Pending Report From " + strDateFrom + " to " + strDateTo;
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

    private void GenrateReport_FirstExcel()
    {
        try
        {           
            DataTable dt = ReportDataFirst();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptSpecCreditCommissionPending.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Spec Credit Application Pending Report From " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Spec Credit Application Pending Report From " + strDateFrom + " to " + strDateTo;
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

    private DataTable ReportDataSecond()
    {
        DataTable dt = new DataTable();
        try
        {

            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            clscon.Return_DT(dt, "EXEC [dbo].[Get_SpecCreditWithoutJobID] '" + strDateFrom + "','" + strDateTo + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport_Second()
    {
        try
        {            
            DataTable dt = ReportDataSecond();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptSpecCreditCommissionWithoutJobID.rpt"));
            
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Spec Credit Without Job From " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Spec Credit Without Job From " + strDateFrom + " to " + strDateTo;
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

    private void GenrateReport_SecondExcel()
    {
        try
        {            
            DataTable dt = ReportDataSecond();
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");

            rprt.Load(Server.MapPath("~/Reports/rptSpecCreditCommissionWithoutJobID.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Spec Credit Without Job From " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Spec Credit Without Job From " + strDateFrom + " to " + strDateTo;
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

    private DataTable ReportDataThird()
    {
        DataTable dt = new DataTable();
        try
        {
            string Qstr = String.Empty;
            string NQstr = String.Empty;
            string FQstr = String.Empty;
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);

            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            Qstr += "SELECT tblHobartBranchListing.CompanyName AS SalesRepGroup,tblProjects.JobID, tblCustomers.CompanyName AS Customer,";
            Qstr += " tblConsultants.CompanyName+' , '+tblConsultants.City+' , '+tblStates.Sabb AS Consult,";
            Qstr += " tblDealers.CompanyName, tblProjects.ShipToArriveDate, UPPER(tblProjects.InvoiceNumber) AS InvoiceNumber,";
            Qstr += " tblProjects.DateInvoiceSent, tblPFiles.NetEqPrice, (tblPFiles.NetEqPrice * tblSpecCredit.Percentage /100) AS Com,";
            Qstr += " tblSpecCredit.Percentage, tblPFiles.SpecCreditPaidDate, tblPFiles.SpecCreditCheckNo,";
            Qstr += " tblHobartListing.FirstName +' '+tblHobartListing.LastName AS ConsultantRep";
            Qstr += " FROM tblHobartBranchListing INNER JOIN tblHobartListing ON tblHobartBranchListing.BranchID = tblHobartListing.BranchID";
            Qstr += " INNER JOIN  tblConsultants INNER JOIN tblSpecCredit RIGHT JOIN tblDealers INNER JOIN tblPFiles ON tblDealers.DealerID = tblPFiles.DealerID";
            Qstr += " INNER JOIN tblProjects ON tblPFiles.PNumber = tblProjects.ProposalID INNER JOIN tblCustomers ON tblProjects.CustomerID = tblCustomers.CustomerID ON";
            Qstr += " tblSpecCredit.ID = tblPFiles.SpecCreditPercentID ON tblConsultants.ConsultantID = tblPFiles.ConsultantID LEFT JOIN tblStates ON ";
            Qstr += "  tblConsultants.StateID = tblStates.StateID ON tblHobartListing.RepID = tblPFiles.ConsultRepID ";
            Qstr += " WHERE tblProjects.DateInvoiceSent Is Not Null AND tblPFiles.SpecCredits=2 ";
            Qstr += " AND tblProjects.DateInvoiceSent BETWEEN '" + strDateFrom.ToString() + "' AND '" + strDateTo.ToString() + "'";
            if (ddlIndividualSalesRep.SelectedIndex >= 0)
            {
                if (ddlIndividualSalesRep.SelectedValue == "0")
                {
                    NQstr += " AND tblHobartListing.BranchID='" + 115 + "' ";
                }
                else if (ddlIndividualSalesRep.SelectedValue == "1")
                {
                    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "Professional Manufacturers" + "%' ";
                }
                else if (ddlIndividualSalesRep.SelectedValue == "2")
                {
                    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "Hri" + "%' ";
                }
                else if (ddlIndividualSalesRep.SelectedValue == "3")
                {
                    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "Posternak" + "%' ";
                }
                else if (ddlIndividualSalesRep.SelectedValue == "4")
                {
                    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "Woolsey" + "%' ";
                }
                else if (ddlIndividualSalesRep.SelectedValue == "5")
                {
                    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "Equipment Preference" + "%' ";
                }
                else if (ddlIndividualSalesRep.SelectedValue == "6")
                {
                    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "KLH" + "%' ";
                }
                else if (ddlIndividualSalesRep.SelectedValue == "7")
                {
                    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "Premier Marketing" + "%' ";
                }
                else if (ddlIndividualSalesRep.SelectedValue == "8")
                {
                    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "Squier" + "%' ";
                }
                else if (ddlIndividualSalesRep.SelectedValue == "9")
                    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "hobart" + "%' ";
                NQstr += " ORDER BY tblProjects.JobID";
                FQstr += Qstr + NQstr;
                clscon.Return_DT(dt, FQstr);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void GenrateReport_Third()
    {
        try
        {                     
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportDataThird();
            if (ddlIndividualSalesRep.SelectedValue == "9")
            {
                rprt.Load(Server.MapPath("~/Reports/rptHobartAllRegions.rpt"));
            }
            else if(ddlIndividualSalesRep.SelectedValue == "-1")
            {
                rprt.Load(Server.MapPath("~/Reports/rptIndividualSalesRepCommReportAll.rpt"));
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptIndividualSalesRepCommReport.rpt"));
            }               
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlIndividualSalesRep.SelectedItem.Text + " COMMISSION REPORT-SPEC CREDIT From " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlIndividualSalesRep.SelectedItem.Text + " COMMISSION REPORT-SPEC CREDIT From " + strDateFrom + " to " + strDateTo;
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

    private void GenrateReport_ThirdExcel()
    {
        try
        {            
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportDataThird();
            if (ddlIndividualSalesRep.SelectedValue == "9")
            {
                rprt.Load(Server.MapPath("~/Reports/rptHobartAllRegions.rpt"));
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptIndividualSalesRepCommReport.rpt"));
            }
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlIndividualSalesRep.SelectedItem.Text + " COMMISSION REPORT-SPEC CREDIT From " + strDateFrom + " to " + strDateTo;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = ddlIndividualSalesRep.SelectedItem.Text + " COMMISSION REPORT-SPEC CREDIT From " + strDateFrom + " to " + strDateTo;
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

    protected void btnGenrate_Click(object sender, EventArgs e)
    {
        try
        {
            Check_Url(rdbList.SelectedValue);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }   

    protected void btnGenerateExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Check_UrlExcel(rdbList.SelectedValue);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            rdbList.SelectedValue = "0";
            ddlCountry.SelectedIndex = 0;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDiv();", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }    
}