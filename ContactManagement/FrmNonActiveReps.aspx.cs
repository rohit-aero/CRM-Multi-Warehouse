using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

public partial class FrmNonActiveReps : System.Web.UI.Page
{
    BOLEmployeeListing ObjBOL = new BOLEmployeeListing();
    BLLRepsAndTroys ObjBLL = new BLLRepsAndTroys();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Control();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetRepsDetail(ObjBOL);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlSalesRep, ds.Tables[0]);

            //}
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlAbbreviation, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCity, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlState, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRegion, ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCompanyBranch, ds.Tables[5]);
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCompanyState, ds.Tables[6]);
            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCompanyCountry, ds.Tables[7]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlSalesRep_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSalesRep.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.RepID = Convert.ToInt32(ddlSalesRep.SelectedValue);
                ds = ObjBLL.GetRepsDetail(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtFirstName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                    txtLastName.Text = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                    ddlAbbreviation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AbbreviationID"]);
                    txtPhoneMail.Text = Convert.ToString(ds.Tables[0].Rows[0]["PhoneMail"]);
                    txtPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]);
                    txtCellPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["CellPhone"]);
                    txtDirectFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["Fax"]);
                    txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    ddlStatus.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["HomeOffice"]) == true)
                    {
                        ChkHomeOffice.Checked = true;
                    }
                    else
                    {
                        ChkHomeOffice.Checked = false;
                    }
                    txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["HomeAddress"]);
                    ddlCity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["HomeCity"]);
                    ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["HomeState"]);
                    txtPostCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["HomePostalCode"]);
                    txtTelephone.Text = Convert.ToString(ds.Tables[0].Rows[0]["HomePhone"]);
                    txtFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["HomeFax"]);
                    ddlRegion.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CompanyRegionID"]);
                    ddlCompanyBranch.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["BranchID"]);
                    txtCompanyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
                    txtCompanyAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyAddress"]);
                    txtCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyCity"]);
                    ddlCompanyState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CompanyStateID"]);
                    ddlCompanyCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CompanyCountryId"]);
                    txtCompanyZipCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyZipCode"]);
                    txtCompanyTelephone.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyTelephone"]);
                    txtCompanyTollFree.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyTollFree"]);
                    txtCompanyFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyFax"]);
                    txtISSFName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSFirstName"]);
                    txtISSLName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSLastName"]);
                    txtISSCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCompanyName"]);
                    txtISSSAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSStreetAddress"]);
                    txtISSCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISScity"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["IssStateID"]) != "0")
                    {
                        txtISSState.Text = Convert.ToString(ds.Tables[0].Rows[0]["IssStateID"]);
                    }
                    if (Convert.ToString(ds.Tables[0].Rows[0]["ISSCountryID"]) != "0")
                    {
                        txtISSCountry.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCountryID"]);
                    }
                    txtISSPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSPhone"]);
                    txtISSFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSFax"]);
                    txtISSCellPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCellPhone"]);
                    txtISSEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSEmail"]);
                    ddlProductLine.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ProductLine"]);
                    lblMsg.Text = "";
                    btnSave.Text = "Update";
                    btnProposals.Enabled = true;
                    btnProjects.Enabled = true;
                }
                else
                {
                    btnProposals.Enabled = false;
                    btnProjects.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                String msg = "";
                if (ddlSalesRep.SelectedIndex > 0)
                {
                    ObjBOL.RepID = Convert.ToInt32(ddlSalesRep.SelectedValue);
                }
                else
                {
                    ObjBOL.RepID = 0;
                }
                ObjBOL.Operation = 3;
                ObjBOL.BranchID = Convert.ToInt32(ddlCompanyBranch.SelectedValue);
                ObjBOL.FirstName = txtFirstName.Text;
                ObjBOL.LastName = txtLastName.Text;
                ObjBOL.AbbreviationID = Convert.ToInt32(ddlAbbreviation.SelectedValue);
                ObjBOL.PhoneMail = txtPhoneMail.Text;
                ObjBOL.Phone = txtPhone.Text;
                ObjBOL.CellPhone = txtCellPhone.Text;
                ObjBOL.Fax = txtDirectFax.Text;
                ObjBOL.Email = txtEmail.Text;
                ObjBOL.Status = ddlStatus.SelectedValue;
                ObjBOL.ProductLine = ddlProductLine.SelectedValue;
                if (ChkHomeOffice.Checked == true)
                {
                    ObjBOL.HomeOffice = true;
                }
                else
                {
                    ObjBOL.HomeOffice = false;
                }
                ObjBOL.HomeAddress = txtAddress.Text;
                ObjBOL.HomeCity = ddlCity.SelectedValue;
                ObjBOL.HomeState = ddlState.SelectedValue;
                ObjBOL.HomePostalCode = txtPostCode.Text;
                ObjBOL.HomePhone = txtTelephone.Text;
                ObjBOL.HomeFax = txtFax.Text;
                msg = ObjBLL.SaveRepsDetail(ObjBOL);
                Utility.ShowMessage_Success(this, msg);
                Utility.MaintainLogs("FrmRepsAndTroys.aspx", "Save");
                Bind_Control();
                Reset();
                btnSave.Text = "Save";
            }
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
            if (txtFirstName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter First Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter First Name. !");
                txtFirstName.Focus();
                return false;
            }
            if (txtLastName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Last Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Last Name. !");
                txtLastName.Focus();
                return false;
            }
            if (ddlAbbreviation.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Abbreviation. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Abbreviation. !");
                ddlAbbreviation.Focus();
                return false;
            }
            if (ddlStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Status. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                ddlStatus.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void Reset()
    {
        try
        {
            ddlSalesRepGroup.SelectedIndex = 0;
            ddlSalesRep.DataSource = "";
            ddlSalesRep.DataBind();
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            ddlAbbreviation.SelectedIndex = 0;
            txtPhoneMail.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtCellPhone.Text = String.Empty;
            txtDirectFax.Text = String.Empty;
            txtEmail.Text = String.Empty;
            ddlStatus.SelectedIndex = 0;
            txtAddress.Text = String.Empty;
            ddlCity.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            txtPostCode.Text = String.Empty;
            txtTelephone.Text = String.Empty;
            txtFax.Text = String.Empty;
            ddlSalesRep.SelectedIndex = -1;
            ChkHomeOffice.Checked = false;
            txtISSFName.Text = String.Empty;
            txtISSLName.Text = String.Empty;
            txtISSSAddress.Text = String.Empty;
            txtISSCompany.Text = String.Empty;
            txtISSCity.Text = String.Empty;
            txtISSState.Text = String.Empty;
            txtISSCountry.Text = String.Empty;
            txtISSPhone.Text = String.Empty;
            txtISSFax.Text = String.Empty;
            txtISSCellPhone.Text = String.Empty;
            txtISSEmail.Text = String.Empty;
            ddlRegion.SelectedIndex = 0;
            txtCompanyName.Text = String.Empty;
            txtCompanyAddress.Text = String.Empty;
            txtCity.Text = String.Empty;
            ddlCompanyState.SelectedIndex = 0;
            ddlCompanyCountry.SelectedIndex = 0;
            txtCompanyTelephone.Text = String.Empty;
            txtCompanyTollFree.Text = String.Empty;
            txtCompanyFax.Text = String.Empty;
            txtCompanyZipCode.Text = String.Empty;
            ddlCompanyBranch.SelectedIndex = 0;
            ddlProductLine.SelectedIndex = 0;
            btnSave.Text = "Save";
            btnProposals.Enabled = false;
            btnProjects.Enabled = false;
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
            Reset();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCompanyBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCompanyBranch.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 4;
                ObjBOL.BranchID = Convert.ToInt32(ddlCompanyBranch.SelectedValue);
                ds = ObjBLL.GetRepsDetail(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlRegion.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CompanyRegionID"]);
                    txtCompanyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
                    txtCompanyAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyAddress"]);
                    txtCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyCity"]);
                    ddlCompanyState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CompanyStateID"]);
                    ddlCompanyCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CompanyCountryId"]);
                    txtCompanyZipCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyZipCode"]);
                    txtCompanyTelephone.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyTelephone"]);
                    txtCompanyTollFree.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyTollFree"]);
                    txtCompanyFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyFax"]);
                    txtISSFName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSFirstName"]);
                    txtISSLName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSLastName"]);
                    txtISSCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCompanyName"]);
                    txtISSSAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSStreetAddress"]);
                    txtISSCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISScity"]);
                    txtISSState.Text = Convert.ToString(ds.Tables[0].Rows[0]["IssStateID"]);
                    txtISSCountry.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCountryID"]);
                    txtISSPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSPhone"]);
                    txtISSFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSFax"]);
                    txtISSCellPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSCellPhone"]);
                    txtISSEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["ISSEmail"]);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlSalesRepGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSalesRepGroup.SelectedIndex > 0)
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 7;
            ObjBOL.BranchID = Convert.ToInt32(ddlSalesRepGroup.SelectedValue);
            ds = ObjBLL.GetRepsDetail(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSalesRep, ds.Tables[0]);
            }
            else
            {
                ddlSalesRep.DataSource = "";
                ddlSalesRep.DataBind();
            }
        }
        else
        {
            ddlSalesRep.DataSource = "";
            ddlSalesRep.DataBind();
        }
    }

    // For Related Proposals Report
    protected void btnProposals_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlSalesRep.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                rprt.Load(Server.MapPath("~/Reports/rptProposalsUnderConsultant.rpt"));
                clscon.Return_DT(dt, "EXEC [dbo].[Get_JobsUnderConsultant]  5," + ddlSalesRep.SelectedValue + "");
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
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

    // For Related Projects Report
    protected void btnProjects_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlSalesRep.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                rprt.Load(Server.MapPath("~/Reports/rptJobsUnderConsultant.rpt"));
                clscon.Return_DT(dt, "EXEC [dbo].[Get_JobsUnderConsultant]  6," + ddlSalesRep.SelectedValue + "");
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
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
}