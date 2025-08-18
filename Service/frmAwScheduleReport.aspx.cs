using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using BOLAERO;
using BLLAERO;

public partial class Reports_frmAwScheduleReport : System.Web.UI.Page
{
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    BOLServiceSchedule ObjBOL = new BOLServiceSchedule();
    BLLServiceSchedule ObjBLL = new BLLServiceSchedule();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //int Month = DateTime.Now.Month;
                //int Year = DateTime.Now.Year - 1;
                //txtFromDate.Text = "01" + "/01/" + Year;
                //txtEndDate.Text = "12/31/" + Year;
                Bind_Controls();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlJobNo, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private string PrepareSQLCommand()
    {
        try
        {
            string commonQuery = " ";
            commonQuery += " SELECT main.id,(ISNULL(main.JobID,'') + ', ' + ISNULL(cust.CompanyName,'') +', '+ ISNULL(cust.City,'')+', '+ISNULL(stateref.[State],'') +', '+ISNULL(country.Country,'')) AS JobID,  ";
            commonQuery += " PackNo,CONVERT(VARCHAR(8),main.[ReleaseDate], 1) AS ReleaseDate,  ";
            commonQuery += " CONVERT(VARCHAR(8),detail.[PartReqOnSite], 1) AS PartReqOnSite,  ";
            commonQuery += " CONVERT(VARCHAR(8),detail.[ShipDate], 1) AS ShipDate,detail.PartQty,  ";
            commonQuery += " CONVERT(VARCHAR(8),detail.[ReqShipDate], 1) AS ReqShipDate,  ";
            commonQuery += " [dbo].[ProperCase](detail.PartNumber) as PartNumber,[dbo].[ProperCase](detail.PartDescription) as PartDescription,  ";
            commonQuery += " serviceStatusNesting.Name AS NestingStatus,  ";
            commonQuery += " serviceStatusLaser.Name AS LaserStatus,  ";
            commonQuery += " serviceStatusForming.Name AS FormingStatus,  ";
            commonQuery += " serviceStatusWelding.Name AS WeldingStatus,  ";
            commonQuery += " serviceStatusPolishing.Name AS PolishingStatus,  ";
            commonQuery += " serviceStatusFinal.Name AS FinalStatus,  ";
            commonQuery += " serviceStatusShipping.Name AS ShippingStatus  ";
            commonQuery += " FROM tblServiceSchedule main  ";
            commonQuery += " LEFT JOIN tblServiceScheduleDetail detail ON detail.ServiceScheduleID =  main.id  ";
            commonQuery += " LEFT JOIN tblProjects pro ON pro.JobID = main.JobID  ";
            commonQuery += " LEFT JOIN tblCustomers cust ON cust.CustomerID = pro.CustomerID  ";
            commonQuery += " LEFT JOIN tblCountries country ON cust.CountryID=country.CountryID  ";
            commonQuery += " LEFT JOIN tblStates stateref ON cust.StateID=stateref.StateID  ";
            commonQuery += " LEFT JOIN tblServiceStatus serviceStatusNesting ON (detail.NestingStatus = serviceStatusNesting.id )  ";
            commonQuery += " LEFT JOIN tblServiceStatus serviceStatusLaser ON (detail.LaserStatus = serviceStatusLaser.id )  ";
            commonQuery += " LEFT JOIN tblServiceStatus serviceStatusForming ON (detail.FormingStatus = serviceStatusForming.id )  ";
            commonQuery += " LEFT JOIN tblServiceStatus serviceStatusWelding ON (detail.WeldingStatus = serviceStatusWelding.id )  ";
            commonQuery += " LEFT JOIN tblServiceStatus serviceStatusPolishing ON (detail.PolishingStatus = serviceStatusPolishing.id )  ";
            commonQuery += " LEFT JOIN tblServiceStatus serviceStatusFinal ON (detail.FinalStatus = serviceStatusFinal.id )  ";
            commonQuery += " LEFT JOIN tblServiceStatus serviceStatusShipping ON (detail.ShippingStatus = serviceStatusShipping.id )  ";
            commonQuery += " WHERE main.ID IS NOT NULL ";
            if (ddlJobNo.SelectedIndex > 0)
            {
                commonQuery += " AND main.JobID = '" + ddlJobNo.SelectedValue + "'";
            }
            if (ddlType.SelectedIndex > 0)
            {
                DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
                DateTime dtto = Convert.ToDateTime(txtEndDate.Text);
                string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
                string strDateTo = dtto.ToString("MM/dd/yyyy");
                if (ddlType.SelectedValue == "1")
                {
                    commonQuery += " AND main.ReleaseDate BETWEEN '" + strDateFrom + "' AND '" + strDateTo + "'";
                    commonQuery += "ORDER BY main.ReleaseDate ";
                }
                else if (ddlType.SelectedValue == "2")
                {
                    commonQuery += " AND detail.ReqShipDate BETWEEN '" + strDateFrom + "' AND '" + strDateTo + "'  ";
                    commonQuery += " ORDER BY detail.ReqShipDate ";
                }
            }

            return commonQuery;
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
            divError.Visible = true;
            string query = PrepareSQLCommand();
            if (query.Length > 1)
            {
                //clscon.Return_DT(dt, "EXEC [dbo].[aero_ServiceScheduleReport] " + ddlType.SelectedValue + ",'" + strDateFrom + "','" + strDateTo + "'");
                clscon.Return_DT(dt, query);
            }
            else
            {
                Utility.ShowMessage_Error(this.Page, "Something went wrong !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void Get_AwScheduleReport()
    {
        try
        {
            divError.Visible = true;
            DataTable dt = ReportData();
            //DateTime dtfrom = Convert.ToDateTime(txtFromDate.Text);
            //DateTime dtto = Convert.ToDateTime(txtEndDate.Text);
            //string strDateFrom = dtfrom.ToString("MM/dd/yyyy");
            //string strDateTo = dtto.ToString("MM/dd/yyyy");
            rprt.Load(Server.MapPath("~/Reports/rptAwScheduleNew.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Aerowerks Service Schedule Report ";
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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

    private Boolean ValidationCheck()
    {
        try
        {
            if (ddlType.SelectedIndex > 0)
            {
                if (txtFromDate.Text == "")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter From Date. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Enter From Date. !");
                    txtFromDate.Focus();
                    return false;
                }
                if (txtEndDate.Text == "")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter End Date. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Enter End Date. !");
                    txtFromDate.Focus();
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

    public void btnGenrate_Click(object sender, EventArgs e)
    {
        try
        {
            var validationAssessment = ValidationCheck();

            if (validationAssessment)
            {
                Get_AwScheduleReport();
            }
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            ddlType.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}