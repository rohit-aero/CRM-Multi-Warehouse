using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using BOLAERO;
using BLLAERO;

public partial class Reports_SalesRepGroup : System.Web.UI.Page
{
    BOLManageRepGroup ObjBOL = new BOLManageRepGroup();
    BLLManageRepGroup ObjBLL = new BLLManageRepGroup();

    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                int year = Convert.ToInt32(DateTime.Now.Year);
                int month = Convert.ToInt32(DateTime.Now.Month);
                string day = Convert.ToString(DateTime.DaysInMonth(year, month));
                txtFromDate.Text = "01" + "/01/" + DateTime.Now.Year;
                txtToDate.Text = "12" + "/31/" + DateTime.Now.Year;
                BindControl();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindControl()
    {
        try
        {
            DataSet ds = new DataSet();
            clscon.Return_DS(ds, "EXEC [dbo].[Get_SalesReport] '','',11");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlRep, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProductLineList, ds.Tables[1]);
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlSalesRepGroup, ds.Tables[2]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Check_Url(string id)
    {
        try
        {
            if (id != null)
            {
                //GenerateReport();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GenerateReportPDF()
    {
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportData();
            rprt.Load(Server.MapPath("~/Reports/rptSalesRepGroup.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = ddlSalesRepGroup.SelectedItem.Text.ToUpper() + " \nSALES REPORT FROM " + strDateFrom + " TO " + strDateTo;
                }
                else
                {
                    txtheader.Text = ddlSalesRepGroup.SelectedItem.Text.ToUpper() + " \nSALES REPORT ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = ddlSalesRepGroup.SelectedItem.Text.ToUpper() + " \nSALES REPORT FROM " + strDateFrom + " TO " + strDateTo;
                }
                else
                {
                    txtheader.Text = ddlSalesRepGroup.SelectedItem.Text.ToUpper() + " \nSALES REPORT ";
                }
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

    private void GenerateReportEXCEL()
    {
        try
        {
            DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtto = Convert.ToDateTime(txtToDate.Text);
            string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            string strDateTo = dtto.ToString("MM/dd/yyyy");
            DataTable dt = ReportData();
            rprt.Load(Server.MapPath("~/Reports/rptSalesRepGroup.rpt"));

            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = ddlSalesRepGroup.SelectedItem.Text + " \nSales Report From " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = ddlSalesRepGroup.SelectedItem.Text + " \nSales Report ";
                }
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, txtheader.Text);
            }
            else
            {
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    txtheader.Text = ddlSalesRepGroup.SelectedItem.Text + " \nSales Report From " + strDateFrom + " to " + strDateTo;
                }
                else
                {
                    txtheader.Text = ddlSalesRepGroup.SelectedItem.Text + " \nSales Report ";
                }
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

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            GenerateReportPDF();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable ReportData()
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
            Qstr += "SELECT tblHobartBranchListing.CompanyName,qryNewProjects.JobID,";
            Qstr += " tblCustomers.CompanyName+','+tblCustomers.City+','+tblStates.Sabb AS Customer,";
            Qstr += " tblStates.Sabb,qryNewProjects.ConsultantID,tblDealers.CompanyName AS Dealer,";
            Qstr += " qryNewProjects.PONumber, qryNewProjects.ShipToArriveDate,";
            Qstr += " qryNewProjects.projectstatus,qryNewProjects.NetEqPrice, tblHobartListing_1.FirstName+' '+tblHobartListing_1.LastName AS OrgRep,";
            Qstr += " tblHobartListing.FirstName+' '+tblHobartListing.LastName AS DesRep, qryNewProjects.DateInvoiceSent";
            Qstr += " FROM  tblStates RIGHT JOIN tblHobartBranchListing INNER JOIN tblCustomers RIGHT JOIN tblDealers";
            Qstr += " RIGHT JOIN qryNewProjects ON tblDealers.DealerID = qryNewProjects.DealerID ON tblCustomers.CustomerID = qryNewProjects.CustomerID";
            Qstr += " LEFT JOIN tblConveyorModel ON qryNewProjects.ModelID = tblConveyorModel.ModelID";
            Qstr += " INNER JOIN tblHobartListing ON qryNewProjects.RepID = tblHobartListing.RepID ON tblHobartBranchListing.BranchID = tblHobartListing.BranchID";
            Qstr += " LEFT JOIN tblHobartListing  AS tblHobartListing_1 ON qryNewProjects.OriginRepID = tblHobartListing_1.RepID ON tblStates.StateID = tblCustomers.StateID";
            Qstr += " WHERE qryNewProjects.projectstatus NOT IN (2, 3) AND qryNewProjects.NetEqPrice > 0 AND tblHobartListing.RepID <> 812 AND CurrencyID = 2 ";
            Qstr += "  AND qryNewProjects.DateInvoiceSent BETWEEN '" + strDateFrom.ToString() + "' AND '" + strDateTo.ToString() + "'";
            if (ddlSalesRepGroup.SelectedIndex > 0)
            {

                NQstr += " AND tblHobartBranchListing.RepGroupID = '" + ddlSalesRepGroup.SelectedValue + "' ";
                //if (ddlSalesRepGroup.SelectedValue == "0")
                //{
                //    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "Premier Marketing Group" + "%' ";
                //}
                //if (ddlSalesRepGroup.SelectedValue == "1")
                //{
                //    NQstr += " AND tblHobartListing.BranchID='" + 115 + "' ";
                //}
                //else if (ddlSalesRepGroup.SelectedValue == "0")
                //{
                //    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "Premier Marketing Group" + "%' ";
                //}
                //else if (ddlSalesRepGroup.SelectedValue == "3")
                //{
                //    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "Hri" + "%' ";
                //}
                //else if (ddlSalesRepGroup.SelectedValue == "4")
                //{
                //    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "Posternak" + "%' ";
                //}
                //else if (ddlSalesRepGroup.SelectedValue == "5")
                //{
                //    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "Woolsey" + "%' ";
                //}
                //else if (ddlSalesRepGroup.SelectedValue == "6")
                //{
                //    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "Equipment Preference" + "%' ";
                //}
                //else if (ddlSalesRepGroup.SelectedValue == "7")
                //{
                //    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "KLH" + "%' ";
                //}
                //else if (ddlSalesRepGroup.SelectedValue == "2")
                //{
                //    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "Professional Manufacturers" + "%' ";
                //}
                //else if (ddlSalesRepGroup.SelectedValue == "9")
                //{
                //    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "Squier" + "%' ";
                //}
                //else if (ddlSalesRepGroup.SelectedValue == "10")
                //{
                //    NQstr += " AND tblHobartBranchListing.CompanyName LIKE '%" + "hobart" + "%' ";
                //    if (ddlRep.SelectedIndex > 0)
                //    {
                //        NQstr += " AND tblHobartListing.Repid ='" + ddlRep.SelectedValue + "' ";
                //    }
                //}
            }
            NQstr += " ORDER BY qryNewProjects.DateInvoiceSent";
            FQstr += Qstr + NQstr;
            clscon.Return_DT(dt, FQstr);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void ddlProductLineList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //ResetInfo();
            //ClearRepGroup();
            ProductLineEvent();
        }

        catch (Exception ex)
        {
            //lblMsg.Text = ex.ToString();
            Utility.AddEditException(ex);
        }
    }

    private void ProductLineEvent()
    {
        try
        {

            //if (ddlProductLineList.SelectedIndex > 0)
            //{
            DataSet ds = new DataSet();
            ObjBOL.operation = 4;
            ObjBOL.ProductLineID = Int32.Parse(ddlProductLineList.SelectedValue);
            //ds = ObjBLL.GetRepGroup(ObjBOL);
            clscon.Return_DS(ds, "EXEC [dbo].[Get_SalesReport] '','',12,'" + ObjBOL.ProductLineID + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlSalesRepGroup, ds.Tables[0]);
                ddlSalesRepGroup.SelectedIndex = 0;
            }
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnGenExcel_Click(object sender, EventArgs e)
    {
        try
        {
            GenerateReportEXCEL();
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
            txtFromDate.Text = "01" + "/01/" + DateTime.Now.Year;
            txtToDate.Text = "12" + "/31/" + DateTime.Now.Year;
            BindControl();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}