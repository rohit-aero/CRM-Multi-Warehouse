using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalesManagement_FrmProjects : System.Web.UI.Page
{
    BOLManageProjects ObjBOL = new BOLManageProjects();
    BLLManageProjects_New ObjBLL = new BLLManageProjects_New();

    BOLProposalSearch ObjBOLSearch = new BOLProposalSearch();
    BLLProposalSearch ObjBLLSearch = new BLLProposalSearch();

    BOLINVPartsInfo ObjBOLRel = new BOLINVPartsInfo();
    BLLINVPartsinfo ObjBLLRel = new BLLINVPartsinfo();

    commonclass1 cls = new commonclass1();
    commonclass1 clscon = new commonclass1();

    ReportDocument rprt = new ReportDocument();
    string checkShipDate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                if (!IsPostBack)
                {
                    ShowHideControls();
                    Bind_Controls();
                    CheckInvoiceNotRequiredPermission();
                    CheckPaymentPermissions();
                    EnableDisablePaymentLogFields();
                    EnableDisable_ReasonForPriceUpdate();
                    if (Request.QueryString["jid"] != null)
                    {
                        var JNumber = Request.QueryString["jid"];
                        FillJnumber(JNumber);
                        SyncTextbox("NUM", JNumber);
                        SyncTextbox("NAME", JNumber);
                    }
                    if (Session["JobID"] != null)
                    {
                        var JNumber = Session["JobID"].ToString();
                        FillJnumber(JNumber);
                        SyncTextbox("NUM", JNumber);
                        SyncTextbox("NAME", JNumber);
                    }
                    hfCurrentUser.Value = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
                    //ReviewedFieldCheck(hfCurrentUser.Value);
                    SpecCredit();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableDisable_ReasonForPriceUpdate()
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                var PermissionsGranted = new List<string> { "263" };
                if (PermissionsGranted.Contains(Utility.GetCurrentUser().ToString()))
                {
                    txtReasonForPriceUpdate.Enabled = true;
                }
                else
                {
                    txtReasonForPriceUpdate.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckInvoiceNotRequiredPermission()
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                if (Utility.GetCurrentUser() == 19)
                {
                    divInr.Visible = true;
                }
                else
                {
                    divInr.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckPaymentPermissions()
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                ObjBOL.Operation = 15;
                ObjBOL.UserID = Utility.GetCurrentUser();
                string returnStatus = ObjBLL.GetProjectStatus(ObjBOL);
                if (returnStatus.Trim() == "S")
                {
                    EnableDisablePaymentControls(true);
                }
                else
                {
                    EnableDisablePaymentControls(false);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableDisablePaymentLogFields()
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                var PermissionsGranted = new List<string> { "276", "263" };
                if (PermissionsGranted.Contains(Utility.GetCurrentUser().ToString()))
                {
                    //txtReasonForPriceUpdate.Enabled = true;
                    chkUpdatedOnVisual.Enabled = true;
                    chkConfirmedFromGover.Enabled = true;
                    ddlProjectReviewedBy.Enabled = true;
                    txtProjectReviewedDate.Enabled = true;
                }
                else
                {
                    //txtReasonForPriceUpdate.Enabled = false;
                    chkUpdatedOnVisual.Enabled = false;
                    chkConfirmedFromGover.Enabled = false;
                    ddlProjectReviewedBy.Enabled = false;
                    txtProjectReviewedDate.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ReviewedFieldCheck(string EmployeeID)
    {
        try
        {
            string CheckRakeshID = "276";
            if (CheckRakeshID == EmployeeID)
            {
                ddlProjectReviewedBy.Enabled = true;
                txtProjectReviewedDate.Enabled = true;
            }
            else
            {
                ddlProjectReviewedBy.Enabled = false;
                txtProjectReviewedDate.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Disable_NetAmountFields()
    {
        try
        {
            if (txtInvodate.Text != "")
            {
                ddlCurrency.Enabled = false;
                txtEqPrice.Enabled = false;
                txtEqDiscount.Enabled = false;
                txtEqDisAmount.Enabled = false;
                txtFreight.Enabled = false;
                txtInstall.Enabled = false;
                txtExWarranty.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #region Others

    private void ShowHideControls()
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                string CRuser = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
                if (CRuser == "288")
                {
                    btnNew.Visible = false;
                    btnSave.Visible = false;
                    btnSearch.Visible = false;
                }
                else
                {
                    btnNew.Visible = true;
                    btnSave.Visible = true;
                    btnSearch.Visible = true;
                }
                var Reviewedby = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
                //var ReviewedbyID = new List<string> { "19", "263", "66", "229" };
                var ReviewedbyID = new List<string> { "66", "229" };
                if (ReviewedbyID.Contains(Reviewedby))
                {
                    txtCashDiscountAmount.Enabled = true;
                    txtCashDiscountPer.Enabled = true;
                    //txtAmountInvoiced.Enabled = true;
                    txtinvnumber.Enabled = true;
                    txtInvodate.Enabled = true;
                }
                else
                {
                    txtCashDiscountAmount.Enabled = false;
                    txtCashDiscountPer.Enabled = false;
                    //txtAmountInvoiced.Enabled = false;
                    txtinvnumber.Enabled = false;
                    txtInvodate.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SpecCredit()
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                string strMethodName2 = "EnableDisableSpecCredit();";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName2, true);
                string CRuser = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
                if (CRuser == "28")
                {
                    rdbSpecCredit.Enabled = true;
                }
                else
                {
                    rdbSpecCredit.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private decimal CalculateNetAmount()
    {
        //=Nz([NetAmount]*[Discount%]/100)
        //txtNetAmount + txtDiscount  
        Decimal TAmount = 0;
        try
        {
            if ((txtNetEqPrice.Text != "" || txtNetEqPrice.Text != "0"))
            {
                TAmount = (Convert.ToDecimal(txtNetEqPrice.Text) + Convert.ToDecimal(txtFreight.Text) + Convert.ToDecimal(txtInstall.Text) + Convert.ToDecimal(txtExWarranty.Text));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return TAmount;
    }

    private decimal CalculateTotal()
    {
        //=Nz([NetAmount])+Nz([GST])
        //txtNetAmount + txtHST
        Decimal TAmount = 0;
        try
        {
            if ((txtNetAmount.Text != "" || txtNetAmount.Text == "0") && (txtHST.Text != "" || txtHST.Text == "0"))
            {
                TAmount = Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtHST.Text);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return TAmount;
    }

    private decimal CalculateCommissionMain()
    {
        //=Nz([NetEqPrice]*[CommissionType]/100)
        //txtNetAmount + txtDiscount   
        Decimal TAmount = 0;
        decimal result = 0;
        try
        {
            if ((txtNetEqPrice.Text != "" && txtNetEqPrice.Text != "0") && (ddlRate.SelectedIndex > 0))
            {
                TAmount = (Convert.ToDecimal(txtNetEqPrice.Text) * Convert.ToDecimal(ddlRate.SelectedValue) / 100);
                decimal roundedValue = Math.Floor(TAmount);
                if (TAmount - roundedValue >= 0.5m)
                {
                    roundedValue += 1;
                }

                result = roundedValue;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return result;
    }

    protected void ddlRate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string temp = CalculateCommissionMain().ToString("N");
            txtCommAmount.Text = temp;
            CalculateCommissionRate();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetCashDiscountFromAmt()
    {
        try
        {
            decimal EqPrice = 0;
            if (txtNetEqPrice.Text != "")
            {
                EqPrice = Convert.ToDecimal(txtNetEqPrice.Text);
            }
            decimal TAmtInvoiced = 0;
            if (txtAmountInvoiced.Text == "")
            {
                TAmtInvoiced = 0;
            }
            else
            {
                TAmtInvoiced = Convert.ToDecimal(txtAmountInvoiced.Text);
            }

            decimal DiscountAmt = 0;
            if (txtCashDiscountAmount.Text != "")
            {
                DiscountAmt = Convert.ToDecimal(txtCashDiscountAmount.Text);
            }
            decimal DiscountAmtRec = 0;
            decimal DiscountPercent = 0;
            decimal DiscountPercent_1 = 0;
            decimal AmtRec = 0;
            decimal TAmtRec = 0;
            if (EqPrice == 0)
            {
                DiscountPercent = 0;
            }
            else
            {
                DiscountPercent = (DiscountAmt / EqPrice) * 100;
            }

            if (DiscountAmt != 0)
            {
                DiscountPercent_1 = (DiscountAmt / TAmtInvoiced) * 100;
            }
            txtCashDiscountPer.Text = DiscountPercent_1.ToString("N");
            DiscountAmtRec = (EqPrice * DiscountPercent) / 100;

            AmtRec = (EqPrice - DiscountAmtRec);
            TAmtRec = (TAmtInvoiced - DiscountAmt);
            txtTAmountRec.Text = TAmtRec.ToString("N");
            CalculateRebatableAmountForCommission();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckPaymentInfo()
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                var Reviewedby = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
                var ReviewedbyID = new List<string> { "19", "66" };
                // 19 = PING, 66 = GOVAR (13 AUG 2022) 
                if (ReviewedbyID.Contains(Reviewedby) == false)
                {
                    if (txtCommDate.Text != "")
                    {
                        ddlConsultantRep.Enabled = false;
                        ddlOrgRep.Enabled = false;
                        ddlDesRep.Enabled = false;
                    }
                    else
                    {
                        ddlConsultantRep.Enabled = true;
                        ddlOrgRep.Enabled = true;
                        ddlDesRep.Enabled = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableDisableReports()
    {
        if (ddlprojectstatus.SelectedValue != "0")
        {
            btnWarrntyLetter.Enabled = false;
        }
        else
        {
            btnWarrntyLetter.Enabled = true;
        }
    }

    private bool CheckDepartmentID()
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                ObjBOL.Operation = 12;
                ObjBOL.CustomerID = Utility.GetCurrentUser();
                string returnStatus = ObjBLL.SaveProject(ObjBOL);
                if (returnStatus.Trim() == "1")
                {
                    return true;
                }
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return false;
    }

    private Boolean ValidationCheck()
    {
        try
        {
            if (txtJobId.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Generate Poject Number. !");
                txtJobId.Focus();
                return false;
            }

            if (txtPNumber.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please Select Proposal Number. !");
                txtPNumber.Focus();
                return false;
            }

            if (HfCustomerID.Value == "-1")
            {
                Utility.ShowMessage_Error(Page, "Please Select Customer. !");
                txtCustomer.Focus();
                return false;
            }

            if (!CheckDepartmentID())
            {
                if (ddlProjectManager.SelectedIndex == 0)
                {
                    Utility.ShowMessage_Error(Page, "Please Select Project Manager. !");
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFirst()", true);
                    lblProjectManager.Focus();
                    lblProjectManager.Attributes.Add("Style", "color:red;");
                    return false;
                }
                else
                {
                    lblProjectManager.Attributes.Add("Style", "color:black;");
                }

                if (ddlprojectstatus.SelectedIndex == 0)
                {
                    Utility.ShowMessage_Error(Page, "Please Select Project Status. !");
                    ddlprojectstatus.Focus();
                    return false;
                }

                if (rdbSpecCredit.SelectedValue == "2" || rdbSpecCredit.SelectedValue == "3")
                {
                    if (ddlConsultantRep.SelectedValue == "0" || ddlConsultantRep.SelectedValue == "552")
                    {
                        Utility.ShowMessage_Error(Page, "Consultant Rep Should not be Blank or Not Applicable in Case of Spec Credit Application. !");
                        ddlConsultantRep.Focus();
                        return false;
                    }

                    if (ddlConsultant.SelectedValue == "0" || ddlConsultant.SelectedValue == "360")
                    {
                        Utility.ShowMessage_Error(Page, "Consultant Should not be Blank or Not Applicable in Case of Spec Credit Application. !");
                        ddlConsultant.Focus();
                        return false;
                    }
                }

                if (ddlCurrency.SelectedIndex == 0)
                {
                    Utility.ShowMessage_Error(Page, "Please Select Currency. !");
                    ddlCurrency.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                    return false;
                }

                if (ddlShippingComit.SelectedIndex == 0)
                {
                    Utility.ShowMessage_Error(Page, "Please Select Shipping Commitment. !");
                    ddlShippingComit.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
                    return false;
                }

                if (ddlShippingStatus.SelectedIndex == 0)
                {
                    Utility.ShowMessage_Error(Page, "Please Select Shipment Status. !");
                    ddlShippingStatus.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
                    return false;
                }

                if (txtShipDate.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Select Ship Date. !");
                    txtShipDate.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
                    return false;
                }

                if (txtShipToArrive.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Select Ship to Arrive Date. !");
                    txtShipToArrive.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
                    return false;
                }

                if (ddlFOB.SelectedIndex == 0)
                {
                    Utility.ShowMessage_Error(Page, "Please Select FOB. !");
                    ddlFOB.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                    return false;
                }

                if (ddlTerm.SelectedIndex == 0)
                {
                    Utility.ShowMessage_Error(Page, "Please Select Term. !");
                    ddlTerm.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                    return false;
                }

                decimal rate = Convert.ToDecimal(ddlRate.SelectedValue);
                if (rate == 0 && txtProjectCommNotes.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Project Commission Notes. !");
                    txtProjectCommNotes.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                    return false;
                }
                //var ProjectReviewedby = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
                //var ProjectReviewedbyID = new List<string> { "276" };
                //if (ProjectReviewedby.Contains(ProjectReviewedby))
                //{
                //    if (txtProjectReviewedDate.Text != "" && ddlProjectReviewedBy.SelectedIndex == 0)
                //    {
                //        Utility.ShowMessage_Error(Page, "Please Select Reviewed By !!");
                //        ddlProjectReviewedBy.Focus();
                //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                //        return false;
                //    }
                //    if (txtProjectReviewedDate.Text == "" && ddlProjectReviewedBy.SelectedIndex > 0)
                //    {
                //        Utility.ShowMessage_Error(Page, "Please Enter Reviewed Date !!");
                //        txtProjectReviewedDate.Focus();
                //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                //        return false;
                //    }
                //}
                if (Utility.IsAuthorized())
                {
                    if (Utility.GetCurrentUser() == 276 && txtOrderAckDate.Text != "")
                    {
                        if (ddlProjectReviewedBy.SelectedIndex == 0)
                        {
                            Utility.ShowMessage_Error(Page, "Please Select Reviewed By !!");
                            ddlProjectReviewedBy.Focus();
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                            return false;
                        }
                        if (txtProjectReviewedDate.Text == "")
                        {
                            Utility.ShowMessage_Error(Page, "Please Enter Reviewed Date !!");
                            txtProjectReviewedDate.Focus();
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                            return false;
                        }
                        //if (!chkUpdatedOnVisual.Checked)
                        //{
                        //    Utility.ShowMessage_Error(Page, "Updated on visual field is required !");
                        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                        //    chkUpdatedOnVisual.Focus();
                        //    return false;
                        //}
                        //if (!chkConfirmedFromGover.Checked)
                        //{
                        //    Utility.ShowMessage_Error(Page, "Confirmed From Grover field is required !");
                        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                        //    chkUpdatedOnVisual.Focus();
                        //    return false;
                        //}
                    }
                }

            }
            else
            {
                //Utility.ShowMessage_Info(Page, "Bypassing Validations !");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    #endregion

    #region Bind Controls

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetProjects(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlOASentTo, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConsultantRep, ds.Tables[1]);
                Utility.BindDropDownList(ddlOrgRep, ds.Tables[1]);
                Utility.BindDropDownList(ddlDesRep, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDealer, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConsultant, ds.Tables[3]);
            }

            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSalesSource, ds.Tables[4]);
            }

            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSpecCredit, ds.Tables[5]);
            }

            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlInstallationBy, ds.Tables[6]);
            }

            if (ds.Tables[7].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlInstallerA, ds.Tables[7]);
                Utility.BindDropDownList(ddlInstallerB, ds.Tables[7]);
                Utility.BindDropDownList(ddlInstallerC, ds.Tables[7]);
            }

            if (ds.Tables[8].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCurrency, ds.Tables[8]);
            }

            if (ds.Tables[9].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlFOB, ds.Tables[9]);
            }

            if (ds.Tables[10].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlTerm, ds.Tables[10]);
            }

            if (ds.Tables[11].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRate, ds.Tables[11]);
            }

            if (ds.Tables[12].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlShipper, ds.Tables[12]);
            }

            if (ds.Tables[13].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlcountry, ds.Tables[13]);
            }

            if (ds.Tables[14].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectManager, ds.Tables[14]);
            }

            if (ds.Tables[15].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectReviewedBy, ds.Tables[15]);
            }

            if (ds.Tables[16].Rows.Count > 0)
            {
                Utility.BindCheckBoxListWOAll(chkTechnician, ds.Tables[16]);
            }

            if (ds.Tables[17].Rows.Count > 0)
            {
                ViewState["Department_Footer"] = ds.Tables[17];
            }

            if (ds.Tables[18].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSalesOpportunity, ds.Tables[18]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Project Lookup Section Events

    protected void txtSearchPName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtSearchPName.Text != "")
            {
                txtSearchPNum.Text = string.Empty;
                string output = txtSearchPName.Text;
                int openTagEndPosition = output.IndexOf("#");
                output = output.Substring(openTagEndPosition + 1);
                FillDetailsFromJnumber(output);
                SpecCredit();
                HfJObID.Value = output;
                SyncTextbox("NUM", output);
                btnCancel.Visible = true;
                btnGenerateCommReport.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtSearchPNum_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtSearchPNum.Text.Length >= 7)
            {
                string OutJnumber = string.Empty;
                if (txtSearchPNum.Text.Length > 7)
                {
                    int index = txtSearchPNum.Text.IndexOf(',');
                    if (index < 0)
                    {
                        index = 0;
                    }
                    OutJnumber = txtSearchPNum.Text.Substring(0, index);
                }
                else
                {
                    OutJnumber = txtSearchPNum.Text;
                }
                HfJObID.Value = OutJnumber;
                FillJnumber(txtSearchPNum.Text);
                SpecCredit();
                EnableDisableReports();
                btnCancel.Visible = true;
                btnGenerateCommReport.Enabled = true;
                return;
            }
            else
            {
                Reset();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            Reset();
            string msg = "";
            ObjBOL.Operation = 2;
            msg = ObjBLL.GenrateJNumber(ObjBOL);
            txtJobId.Text = msg;
            txtJobOrderDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            btnNew.Enabled = false;
            SpecCredit();
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
            string msg = "";
            if (ValidationCheck() == true)
            {
                string sts = GetProjectStatus(HfJObID.Value);
                if (sts == "0" || sts == "1" || sts == "")
                {
                    SaveData();
                }
                if (sts == "2" && ddlprojectstatus.SelectedIndex <= 2 || sts == "3" && ddlprojectstatus.SelectedIndex <= 2)
                {
                    SaveData();
                }
                else if (sts == "2" && ddlprojectstatus.SelectedIndex > 2 || sts == "3" && ddlprojectstatus.SelectedIndex > 2)
                {
                    msg = "This Project is cancelled/Onhold please change project status to make any update";
                    Utility.ShowMessage_Error(Page, msg);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/SalesManagement/FrmSearchProject.aspx");
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
            string job = txtJobId.Text;
            Reset();
            CancelExclusiveRefocus(job);
            btnGenerateCommReport.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillJnumber(string Jnumber)
    {
        try
        {
            if (Jnumber != "")
            {
                txtPONumber.Text = string.Empty;
                string strJnumber = Jnumber;
                string OutJnumber = string.Empty;
                if (strJnumber != "")
                {
                    int index = strJnumber.IndexOf(',');
                    if (Jnumber.Length > 7)
                    {
                        if (index != -1)
                        {
                            OutJnumber = strJnumber.Substring(0, strJnumber.IndexOf(','));
                        }
                    }
                    else
                    {
                        OutJnumber = Jnumber;
                    }
                    HfJObID.Value = OutJnumber;
                    FillSiteContactandDealerProjManager(OutJnumber);
                    FillDetailsFromJnumber(OutJnumber);
                    SyncTextbox("NAME", OutJnumber);

                }
                else
                {
                    HfJObID.Value = strJnumber;
                    FillSiteContactandDealerProjManager(OutJnumber);
                    FillDetailsFromJnumber(strJnumber);
                    SyncTextbox("NUM", strJnumber);
                }
                btnCancel.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool CheckForValidJobID(string jobID)
    {
        try
        {
            ObjBOL.Operation = 9;
            ObjBOL.JobID = jobID;
            string returnValue = ObjBLL.GetProjectStatus(ObjBOL);
            if (returnValue.Trim() == "S")
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return false;
    }

    private void SyncTextbox(string type, string text)
    {
        try
        {
            if (type != "")
            {
                //Utility.ToastrClear(Page);
                DataTable dt = new DataTable();
                if (type == "NUM")
                {
                    dt = Utility.ReturnProjects(26, text);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchPNum.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                        btnGenerateCommReport.Enabled = true;
                    }
                    else
                    {
                        txtSearchPNum.Text = "";
                        txtSearchPName.Text = "";
                        btnGenerateCommReport.Enabled = false;
                        Utility.ShowMessage_Error(Page, "J# not Found");
                    }
                }
                else
                {
                    dt = Utility.ReturnProjects(25, text);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchPName.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                        btnGenerateCommReport.Enabled = true;
                    }
                    else
                    {
                        txtSearchPNum.Text = "";
                        txtSearchPName.Text = "";
                        btnGenerateCommReport.Enabled = false;
                        Utility.ShowMessage_Error(Page, "J# not Found");
                    }
                }
                bool status = CheckForValidJobID(text);
                if (!status)
                {
                    Reset();
                }
                else
                {
                    CheckPaymentInfo();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //private void FillDetailsFromJnumber(string strJNumber)
    //{
    //    try
    //    {
    //        hfShipToArriveDateFillDetail.Value = "";
    //        hfReleased.Value = "";
    //        DataSet ds = new DataSet();
    //        ObjBOL.Operation = 3;
    //        ObjBOL.ProjectName = strJNumber;
    //        ObjBOL.JobID = strJNumber;
    //        ds = ObjBLL.GetProjects(ObjBOL);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            DataRow dr = ds.Tables[0].Rows[0];
    //            txtJobId.Text = Convert.ToString(dr["JobID"]);
    //            txtPNumber.Text = Convert.ToString(dr["ProposalID"]);

    //            #region Second tab  

    //            if (ddlCurrency.Items.FindByValue(Convert.ToString(dr["CurrencyID"])) != null)
    //            {
    //                ddlCurrency.SelectedValue = Convert.ToString(dr["CurrencyID"]);
    //            }
    //            txtEqPrice.Text = Convert.ToDecimal(dr["Price"]).ToString("N");
    //            txtEqDiscount.Text = Convert.ToDecimal(dr["EqDiscount"]).ToString("N");
    //            txtEqDisAmount.Text = Convert.ToDecimal(dr["EqDisAmount"]).ToString("N");
    //            txtNetEqPrice.Text = Convert.ToDecimal(dr["NetEqPrice"]).ToString("N");

    //            txtFreight.Text = Convert.ToDecimal(dr["Freight"]).ToString("N");
    //            txtInstall.Text = Convert.ToDecimal(dr["Installation"]).ToString("N");
    //            txtExWarranty.Text = Convert.ToDecimal(dr["ExWarrantyPrice"]).ToString("N");
    //            txtNetAmount.Text = CalculateNetAmount().ToString("N");
    //            txtAmountInvoiced.Text = txtNetAmount.Text;
    //            txtHST.Text = Convert.ToDecimal(dr["GST"]).ToString("N");
    //            txtTotalAmount.Text = Convert.ToDecimal(CalculateTotal()).ToString("N");
    //            txtinvnumber.Text = Convert.ToString(dr["InvoiceNumber"]);
    //            txtInvodate.Text = cls.Converter(Convert.ToString(dr["DateInvoiceSent"]));

    //            txtDateReceived.Text = cls.Converter(Convert.ToString(dr["DatePaymentReceived"]));
    //            if (ddlFOB.Items.FindByValue(Convert.ToString(dr["fob"])) != null)
    //            {
    //                ddlFOB.Text = Convert.ToString(dr["fob"]);
    //            }
    //            if (ddlTerm.Items.FindByValue(Convert.ToString(dr["term"])) != null)
    //            {
    //                ddlTerm.Text = Convert.ToString(dr["term"]);
    //            }
    //            if (ddlRate.Items.FindByValue(Convert.ToString(dr["CommissionType"])) != null)
    //            {
    //                ddlRate.SelectedValue = Convert.ToString(dr["CommissionType"]);
    //            }
    //            txtProjectCommNotes.Text = Convert.ToString(dr["CommissionText"]);

    //            txtCommAmount.Text = Convert.ToDecimal(CalculateCommissionMain()).ToString("N");
    //            txtCommCheque.Text = Convert.ToString(dr["KflexCheckNumber"]);
    //            txtCommDate.Text = cls.Converter(Convert.ToString(dr["DateCommissionPaid"]));
    //            string comtype = Convert.ToString(dr["GSICommissionType"]);
    //            if (ddlShipper.Items.FindByValue(Convert.ToString(dr["ShipperID"])) != null)
    //            {
    //                ddlShipper.SelectedValue = Convert.ToString(dr["ShipperID"]);
    //            }
    //            string sc = Convert.ToString(dr["ShippingCommit"]);
    //            if (sc.Trim() != "")
    //            {
    //                ddlShippingComit.SelectedValue = Convert.ToString(dr["ShippingCommit"]);
    //            }
    //            else
    //            {
    //                ddlShippingComit.SelectedValue = "";
    //            }

    //            if (ddlShippingStatus.Items.FindByValue(Convert.ToString(dr["ShipStatus"])) != null)
    //            {
    //                ddlShippingStatus.SelectedValue = Convert.ToString(dr["ShipStatus"]);
    //            }

    //            txtShipDate.Text = cls.Converter(Convert.ToString(dr["projectshipdate"]));
    //            txtShipToArrive.Text = cls.Converter(Convert.ToString(dr["ShipToArriveDate"]));
    //            hfShipToArriveDateFillDetail.Value = txtShipToArrive.Text;
    //            txtArrivalDate.Text = cls.Converter(Convert.ToString(dr["ArrivalDate"]));
    //            txtCompany.Text = Convert.ToString(dr["ShipToName"]);
    //            txtAddress.Text = Convert.ToString(dr["ShipToStreet"]);
    //            txtCity.Text = Convert.ToString(dr["ShipToCity"]);
    //            if (ddlcountry.Items.FindByValue(Convert.ToString(dr["CountryID"])) != null)
    //            {
    //                ddlcountry.SelectedValue = Convert.ToString(dr["CountryID"]);
    //                GetState(ddlcountry.SelectedValue);
    //            }
    //            if (Convert.ToString(dr["ShipToState"]) != "")
    //            {
    //                ddlState.SelectedValue = Convert.ToString(dr["ShipToState"]);
    //            }
    //            txtZip.Text = Convert.ToString(dr["ShipToZipCode"]);
    //            txtContactPerson.Text = Convert.ToString(dr["SiteContact"]);
    //            txtPhone.Text = Convert.ToString(dr["SiteContactTelephone"]);

    //            hfReleased.Value = dr["ReleaseToShop"].ToString();
    //            txtCashDiscountAmount.Text = Convert.ToDecimal(dr["CashDisAmt"]).ToString("N");
    //            decimal cashper = Convert.ToDecimal(dr["CashDisPer"]);
    //            txtCashDiscountPer.Text = cashper.ToString("N");
    //            if (cashper <= 0)
    //            {
    //                txtAmountForComision.Text = Convert.ToDecimal(dr["NetEqPrice"]).ToString("N");
    //                txtTAmountRec.Text = txtTotalAmount.Text;
    //            }
    //            else
    //            {
    //                txtAmountForComision.Text = Convert.ToDecimal(dr["AmountForComission"]).ToString("N");
    //                txtTAmountRec.Text = Convert.ToDecimal(dr["CashAmtRec"]).ToString("N");
    //            }

    //            #endregion

    //            #region First Tab

    //            if (ddlOASentTo.Items.FindByValue(Convert.ToString(dr["OASentTo"])) != null)
    //            {
    //                ddlOASentTo.SelectedValue = Convert.ToString(dr["OASentTo"]);
    //            }
    //            txtJobOrderDate.Text = cls.Converter(Convert.ToString(dr["JobOrderDate"]));
    //            txtOrderAckDate.Text = cls.Converter(Convert.ToString(dr["JobOrderAck"]));
    //            txtOADispatch.Text = cls.Converter(Convert.ToString(dr["JobOADis"]));

    //            HfCustomerID.Value = Convert.ToString(dr["CustomerID"]);
    //            txtCustomer.Text = Convert.ToString(dr["CustomerName"]);
    //            txtPONumber.Text = Convert.ToString(dr["PONumber"]);
    //            if (ddlConsultantRep.Items.FindByValue(Convert.ToString(dr["ConsultRepID"])) != null)
    //            {
    //                ddlConsultantRep.SelectedValue = Convert.ToString(dr["ConsultRepID"]);
    //            }
    //            if (ddlOrgRep.Items.FindByValue(Convert.ToString(dr["OriginRepID"])) != null)
    //            {
    //                ddlOrgRep.SelectedValue = Convert.ToString(dr["OriginRepID"]);
    //            }
    //            if (Convert.ToString(dr["RepID"]) != "0")
    //            {
    //                ddlDesRep.SelectedValue = Convert.ToString(dr["RepID"]);
    //            }
    //            if (ddlDealer.Items.FindByValue(Convert.ToString(dr["DealerID"])) != null)
    //            {
    //                ddlDealer.SelectedValue = Convert.ToString(dr["DealerID"]);
    //            }
    //            if (ddlConsultant.Items.FindByValue(Convert.ToString(dr["ConsultantID"])) != null)
    //            {
    //                ddlConsultant.SelectedValue = Convert.ToString(dr["ConsultantID"]);
    //            }
    //            int Consultantid = Convert.ToInt32(dr["ConsultantID"]);

    //            if (ddlSalesSource.Items.FindByValue(Convert.ToString(dr["SalesSourceID"])) != null)
    //            {
    //                ddlSalesSource.SelectedValue = Convert.ToString(dr["SalesSourceID"]);
    //            }
    //            txtPoRecDate.Text = cls.Converter(Convert.ToString(dr["PORec"]));
    //            if (Convert.ToInt32(dr["OrderBelongsTo"]) == 1)
    //            {
    //                rdbOrderFor.SelectedValue = "1";
    //            }
    //            else
    //            {
    //                rdbOrderFor.SelectedValue = "2";
    //            }
    //            txtQuote.Text = Convert.ToString(dr["QuoteSelected"]);

    //            if (Convert.ToString(dr["SpecCredits"]) != "0")
    //            {
    //                rdbSpecCredit.SelectedValue = Convert.ToString(dr["SpecCredits"]);
    //            }
    //            else
    //            {
    //                rdbSpecCredit.SelectedValue = null;
    //            }
    //            if (ddlSpecCredit.Items.FindByValue(Convert.ToString(dr["SpecCreditPercentID"])) != null)
    //            {
    //                ddlSpecCredit.SelectedValue = Convert.ToString(dr["SpecCreditPercentID"]);
    //            }
    //            txtSpecAmount.Text = Convert.ToString(dr["SpecCreditAmount"]);
    //            txtSpecConsultantRep.Text = ddlConsultantRep.SelectedItem.Text;
    //            txtSpecConsultant.Text = ddlConsultant.SelectedItem.Text;
    //            txtSpecCheque.Text = Convert.ToString(dr["SpecCreditCheckNo"]);
    //            txtSpecPaid.Text = cls.Converter(Convert.ToString(dr["SpecCreditPaidDate"]));
    //            txtReleased.Text = cls.Converter(Convert.ToString(dr["ReleaseDate"]));
    //            txtDateBuiltDrgsSent.Text = cls.Converter(Convert.ToString(dr["DateAsBuiltDrgsSent"]));
    //            txtEstimatedCom.Text = cls.Converter(Convert.ToString(dr["EstCompletionDate"]));
    //            txtActualCom.Text = cls.Converter(Convert.ToString(dr["ActualCompletionDate"]));
    //            txtTestRun.Text = cls.Converter(Convert.ToString(dr["TestRunDate"]));
    //            var Reviewedby = Convert.ToString(dr["ReviewedBy"]);

    //            var ReviewedbyID = new List<string> { "33", "40", "75", "89", "161" };
    //            if (ddlPurchasedItemsCAD.Items.FindByValue(Convert.ToString(dr["PurchasedItemsCAD"])) != null)
    //            {
    //                ddlPurchasedItemsCAD.SelectedValue = Convert.ToString(dr["PurchasedItemsCAD"]);
    //            }
    //            if (ddlInstallationBy.Items.FindByValue(Convert.ToString(dr["InstallationBy"])) != null)
    //            {
    //                ddlInstallationBy.SelectedValue = Convert.ToString(dr["InstallationBy"]);
    //            }
    //            if (ddlInstallerA.Items.FindByValue(Convert.ToString(dr["InstallatorA"])) != null)
    //            {
    //                ddlInstallerA.SelectedValue = Convert.ToString(dr["InstallatorA"]);
    //            }
    //            if (ddlInstallerB.Items.FindByValue(Convert.ToString(dr["InstallatorB"])) != null)
    //            {
    //                ddlInstallerB.SelectedValue = Convert.ToString(dr["InstallatorB"]);
    //            }
    //            if (ddlInstallerC.Items.FindByValue(Convert.ToString(dr["InstallatorC"])) != null)
    //            {
    //                ddlInstallerC.SelectedValue = Convert.ToString(dr["InstallatorC"]);
    //            }
    //            txtInstallationStart.Text = cls.Converter(Convert.ToString(dr["InstallDate"]));
    //            txtInstallationEnd.Text = cls.Converter(Convert.ToString(dr["InstallationCompletionDate"]));
    //            txtDemo.Text = cls.Converter(Convert.ToString(dr["DemoDate"]));
    //            txtWarrantyStart.Text = cls.Converter(Convert.ToString(dr["WarrantyStartDate"]));
    //            txtWarrantyEnd.Text = cls.Converter(Convert.ToString(dr["WarrantyEndDate"]));
    //            txtFollowUp.Text = cls.Converter(Convert.ToString(dr["FollowUpDate"]));
    //            txtCarePack.Text = cls.Converter(Convert.ToString(dr["CustCarePackageSendDate"]));
    //            txtManualsDisp.Text = cls.Converter(Convert.ToString(dr["ManualDispatchDate"]));
    //            txtTestRemarks.Text = Convert.ToString(dr["Comments"]);
    //            if (Convert.ToInt32(dr["PMPack"]) == 0)
    //            {
    //                rdbPM.SelectedValue = "0";
    //            }
    //            else
    //            {
    //                rdbPM.SelectedValue = "1";
    //            }

    //            if (dr["ProjectStatus"].ToString() != "")
    //            {
    //                ddlprojectstatus.SelectedValue = dr["ProjectStatus"].ToString();
    //            }

    //            if (ddlProjectManager.Items.FindByValue(dr["ProjectManager"].ToString()) != null)
    //            {
    //                ddlProjectManager.SelectedValue = dr["ProjectManager"].ToString();
    //            }

    //            #endregion

    //            btnSave.Text = "Update";

    //            EnableDisableShipDate();
    //            Get_Tax();

    //            string strMethodName = "GetConsultant();";
    //            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
    //            string strMethodRepName = "GetConsultantRep();";
    //            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodRepName, true);
    //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "text", "getCheckedRadio();", true);
    //            EnableDisableReports();
    //            if (ddlProjectManager.SelectedIndex > 0)
    //            {
    //                lblPM.Text = "Project Manager : <b>" + ddlProjectManager.SelectedItem.Text + "</b>";

    //                lblPM.Visible = true;
    //            }
    //            else
    //            {
    //                lblPM.Text = String.Empty;
    //                lblPM.Visible = false;
    //            }
    //            if (ddlDesRep.SelectedIndex > 0)
    //            {
    //                lblDesRep.Text = "Destination Rep : <b>" + ddlDesRep.SelectedItem.Text + "</b>";
    //                lblDesRep.Visible = true;
    //            }
    //            else
    //            {
    //                lblDesRep.Text = String.Empty;
    //                lblDesRep.Visible = false;
    //            }
    //            if (ddlConsultant.SelectedIndex > 0)
    //            {
    //                lblConsultant.Text = "Consultant : <b>" + ddlConsultant.SelectedItem.Text + "</b>";
    //                lblConsultant.Visible = true;
    //            }
    //            else
    //            {
    //                lblConsultant.Text = String.Empty;
    //                lblConsultant.Visible = false;
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        string newMessage = txtJobId.Text + " -- " + ex.Message;
    //        Exception newEx = new Exception(newMessage, ex);
    //        Utility.AddEditException(newEx);
    //    }
    //}

    private DataTable EmptyDT()
    {
        DataTable dtEmpty = new DataTable();
        try
        {
            dtEmpty.Columns.Add("RowNo", typeof(int));
            dtEmpty.Columns.Add("id", typeof(Int32));
            dtEmpty.Columns.Add("ShipDate", typeof(DateTime));
            dtEmpty.Columns.Add("Department", typeof(string));
            dtEmpty.Columns.Add("Comments", typeof(string));
            dtEmpty.Columns.Add("UpdatedBy", typeof(string));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    private void FillDetailsFromJnumber(string strJNumber)
    {
        try
        {
            CheckPaymentPermissions();
            EnableDisablePaymentLogFields();
            hfShipToArriveDateFillDetail.Value = "";
            hfReleased.Value = "";
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            ObjBOL.ProjectName = strJNumber;
            ObjBOL.JobID = strJNumber;
            ds = ObjBLL.GetProjects(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                Session["JobInfo"] = dr;
                Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
    {
        { "JobID", d => txtJobId.Text = Convert.ToString(d["JobID"]) },
        { "ProposalID", d => txtPNumber.Text = Convert.ToString(d["ProposalID"]) },
        { "CurrencyID", d =>
            {
                if (ddlCurrency.Items.FindByValue(Convert.ToString(d["CurrencyID"])) != null)
                {
                    ddlCurrency.SelectedValue = Convert.ToString(d["CurrencyID"]);
                }
                else if(ddlCurrency.Items.Count > 0)
                {
                    ddlCurrency.SelectedIndex = 0;
                }
            }
        },
        { "Price", d => txtEqPrice.Text = Convert.ToDecimal(d["Price"]).ToString("N") },
        { "EqDiscount", d => txtEqDiscount.Text = Convert.ToDecimal(d["EqDiscount"]).ToString("N") },
        { "EqDisAmount", d => txtEqDisAmount.Text = Convert.ToDecimal(d["EqDisAmount"]).ToString("N") },
        { "NetEqPrice", d => txtNetEqPrice.Text = Convert.ToDecimal(d["NetEqPrice"]).ToString("N") },
        { "Freight", d => txtFreight.Text = Convert.ToDecimal(d["Freight"]).ToString("N") },
        { "Installation", d => txtInstall.Text = Convert.ToDecimal(d["Installation"]).ToString("N") },
        { "ExWarrantyPrice", d => txtExWarranty.Text = Convert.ToDecimal(d["ExWarrantyPrice"]).ToString("N") },
        { "txtNetAmount", d => txtNetAmount.Text = CalculateNetAmount().ToString("N") },
        { "TotalAmtInv", d =>
            {
                txtAmountInvoiced.Text = Convert.ToDecimal(d["TotalAmtInv"]).ToString("N");
                //InvoiceAmountCheck();
            }
        },
        { "GST", d => txtHST.Text = Convert.ToDecimal(d["GST"]).ToString("N") },
        { "txtTotalAmount", d => txtTotalAmount.Text = Convert.ToDecimal(d["CashAmtRec"]).ToString("N") },
        { "InvoiceNumber", d => txtinvnumber.Text = Convert.ToString(d["InvoiceNumber"]) },
        { "DateInvoiceSent", d => {
                txtInvodate.Text = cls.Converter(Convert.ToString(d["DateInvoiceSent"]));
                DateTime? temp = Utility.ConvertDate(Convert.ToString(d["DateInvoiceSent"]));
                var PermissionsGranted = new List<string> { "66", "263" };
                if(temp != null && !PermissionsGranted.Contains(hfCurrentUser.Value))
                {
                    //if(temp <= DateTime.Now)
                    //{
                        EnableDisablePaymentControls(false);
                        EnableDisableControlRecursively(giGeneralInformation, false);
                    //}
                }
                else
                {
                    EnableDisableControlRecursively(giGeneralInformation, true);
                }
            }
        },
        { "DatePaymentReceived", d => txtDateReceived.Text = cls.Converter(Convert.ToString(d["DatePaymentReceived"])) },
        { "fob", d =>
            {
                if (ddlFOB.Items.FindByValue(Convert.ToString(d["fob"])) != null)
                {
                    ddlFOB.Text = Convert.ToString(d["fob"]);
                }
                else if(ddlFOB.Items.Count > 0)
                {
                    ddlFOB.SelectedIndex = 0;
                }
            }
        },
        { "term", d =>
            {
                if (ddlTerm.Items.FindByValue(Convert.ToString(d["term"])) != null)
                {
                    ddlTerm.Text = Convert.ToString(d["term"]);
                }
                else if(ddlTerm.Items.Count > 0)
                {
                    ddlTerm.SelectedIndex = 0;
                }
            }
        },
        { "CommissionType", d =>
            {
                if (ddlRate.Items.FindByValue(Convert.ToString(d["CommissionType"])) != null)
                {
                    ddlRate.SelectedValue = Convert.ToString(d["CommissionType"]);
                }
                else if(ddlRate.Items.Count > 0)
                {
                    ddlRate.SelectedIndex = 0;
                }
            }
        },
        { "CommissionText", d => txtProjectCommNotes.Text = Convert.ToString(d["CommissionText"]) },
        { "txtCommAmount", d => txtCommAmount.Text = Convert.ToDecimal(CalculateCommissionMain()).ToString("N") },
        { "txtNetRateCommission", d => txtNetRateCommission.Text = Convert.ToDecimal(d["NetCommissionRate"]).ToString("N") },
        { "KflexCheckNumber", d =>
            {
                txtCommCheque.Text = Convert.ToString(d["KflexCheckNumber"]);
                if(hfCurrentUser.Value == "229")
                {
                    txtCommCheque.Enabled = true;
                    txtCommDate.Enabled = true;
                }
            }
        },
        { "DateCommissionPaid", d => txtCommDate.Text = cls.Converter(Convert.ToString(d["DateCommissionPaid"])) },
        { "GSICommissionType", d => { string comtype = Convert.ToString(d["GSICommissionType"]); } },
        { "ShipperID", d =>
            {
                if (ddlShipper.Items.FindByValue(Convert.ToString(d["ShipperID"])) != null)
                {
                    ddlShipper.SelectedValue = Convert.ToString(d["ShipperID"]);
                    BindShipperContactName(ddlShipper.SelectedValue);
                }
                else if(ddlShipper.Items.Count > 0)
                {
                    ddlShipper.SelectedIndex = 0;
                }
            }
        },
        { "ShippingCommit", d =>
            {
                string sc = Convert.ToString(d["ShippingCommit"]);

                if (ddlShippingComit.Items.FindByValue(Convert.ToString(d["ShippingCommit"])) != null)
                {
                    ddlShippingComit.SelectedValue = Convert.ToString(d["ShippingCommit"]);
                }
                else if(ddlShippingComit.Items.Count > 0)
                {
                    ddlShippingComit.SelectedIndex = 0;
                }

                //if (sc.Trim() != "")
                //{
                //    ddlShippingComit.SelectedValue = Convert.ToString(d["ShippingCommit"]);
                //}
                //else
                //{
                //    ddlShippingComit.SelectedValue = "";
                //}
            }
        },
        { "ShipStatus", d =>
            {
                if (ddlShippingStatus.Items.FindByValue(Convert.ToString(d["ShipStatus"])) != null)
                {
                    ddlShippingStatus.SelectedValue = Convert.ToString(d["ShipStatus"]);
                }
                else if(ddlShippingStatus.Items.Count > 0)
                {
                    ddlShippingStatus.SelectedIndex = 0;
                }
            }
        },
        { "projectshipdate", d => txtShipDate.Text = cls.Converter(Convert.ToString(d["projectshipdate"])) },
        { "ShipToArriveDate", d => txtShipToArrive.Text = cls.Converter(Convert.ToString(d["ShipToArriveDate"])) },
        { "hfShipToArriveDateFillDetail", d => hfShipToArriveDateFillDetail.Value = txtShipToArrive.Text },
        { "ArrivalDate", d => txtArrivalDate.Text = cls.Converter(Convert.ToString(d["ArrivalDate"])) },
        { "ShipToName", d => txtCompany.Text = Convert.ToString(d["ShipToName"])},
        { "ShipToStreet", d => txtAddress.Text = Convert.ToString(d["ShipToStreet"]) },
        { "ShipToCity", d => txtCity.Text = Convert.ToString(d["ShipToCity"]) },
        { "CountryID", d =>
            {
                if (ddlcountry.Items.FindByValue(Convert.ToString(d["CountryID"])) != null)
                {
                    ddlcountry.SelectedValue = Convert.ToString(d["CountryID"]);
                    GetState(ddlcountry.SelectedValue);
                }
            }
        },
        { "ShipToState", d =>
            {
                if (ddlState.Items.FindByText(Convert.ToString(d["ShipToState"])) != null)
                {
                    ddlState.SelectedValue = Convert.ToString(d["ShipToState"]);
                }
                else if(ddlState.Items.Count > 0)
                {
                    ddlState.SelectedIndex = 0;
                }
            }
        },
        { "ShipToZipCode", d => txtZip.Text = Convert.ToString(d["ShipToZipCode"]) },
        { "ShipperContactName", d =>
        {
            if(ddlShipperContactName.Items.FindByText(d["ShipperContactName"].ToString()) != null){
                ListItem item = ddlShipperContactName.Items.FindByText(Convert.ToString(d["ShipperContactName"]));
                if (item != null)
                {
                    item.Selected = true;
                    //EnabledShipperContact();
                }
                else
                {
                    ResetShipperContact();
                }
                //ddlShipperContactName.SelectedItem.Text = Convert.ToString(d["ShipperContactName"]);
            }
            else
            {
                ResetShipperContact();
            }
        }
        },
        { "ShipperPhone", d => txtShipperPhone.Text = Convert.ToString(d["ShipperPhone"]) },
        { "ShipperEmail", d => txtShipperEmail.Text = Convert.ToString(d["ShipperEmail"]) },
        { "ShipperTrackingNo", d => txtShipperTrackingNo.Text = Convert.ToString(d["ShipperTrackingNo"]) },
        { "ShipperPickupFromShop", d => txtShipperPickupFromShop.Text = Convert.ToString(d["ShipperPickupFromShop"]) },
        { "ShippedVia", d =>
            {
                if (rdbShippedVia.Items.FindByValue(Convert.ToString(d["ShippedVia"])) != null)
                {
                    rdbShippedVia.SelectedValue = Convert.ToString(d["ShippedVia"]);
                }
                else
                {
                    rdbShippedVia.SelectedValue = null;
                }
            }
        },
        { "ActualShippingCost", d => txtActualShippingCost.Text = Convert.ToString(d["ActualShippingCost"]) },
        { "AdditionalCharges", d => txtAdditionalCharges.Text = Convert.ToString(d["AdditionalCharges"]) },
        { "ShipperNotes", d => txtShipperNotes.Text = Convert.ToString(d["ShipperNotes"]) },
        { "SiteContact", d => txtContactPerson.Text = Convert.ToString(d["SiteContact"]) },
        { "SiteContactTelephone", d => txtPhone.Text = Convert.ToString(d["SiteContactTelephone"]) },
        { "SiteContactEmail", d => txtEmail.Text = Convert.ToString(d["SiteContactEmail"]) },
        { "ReleaseToShop", d => hfReleased.Value = d["ReleaseToShop"].ToString() },
        { "CashDisAmt", d => txtCashDiscountAmount.Text = Convert.ToDecimal(d["CashDisAmt"]).ToString("N") },
        { "CashDisPer", d =>
            {
                decimal cashper = Convert.ToDecimal(d["CashDisPer"]);
                txtCashDiscountPer.Text = cashper.ToString("N");
                if (cashper <= 0)
                {
					//txtAmountForComision.Text = Convert.ToDecimal(d["NetEqPrice"]).ToString("N");
					txtTAmountRec.Text = txtTotalAmount.Text;
                }
                else
                {
                    txtTAmountRec.Text = Convert.ToDecimal(d["CashAmtRec"]).ToString("N");
                }
                txtAmountForComision.Text = Convert.ToDecimal(d["AmountForComission"]).ToString("N");
            }
        },
        { "OASentTo", d =>
            {
                if (ddlOASentTo.Items.FindByValue(Convert.ToString(d["OASentTo"])) != null)
                {
                    ddlOASentTo.SelectedValue = Convert.ToString(dr["OASentTo"]);
                }
                else if(ddlOASentTo.Items.Count > 0)
                {
                    ddlOASentTo.SelectedIndex = 0;
                }
            }
        },
        { "JobOrderDate", d => txtJobOrderDate.Text = cls.Converter(Convert.ToString(d["JobOrderDate"])) },
        { "JobOrderAck", d =>
            {
                txtOrderAckDate.Text = cls.Converter(Convert.ToString(d["JobOrderAck"]));
                EnableDisablePaymentLogFields();
            }
        },
        { "JobOADis", d => txtOADispatch.Text = cls.Converter(Convert.ToString(d["JobOADis"])) },
        { "CustomerID", d => HfCustomerID.Value = Convert.ToString(d["CustomerID"]) },
        { "CustomerName", d => txtCustomer.Text = Convert.ToString(d["CustomerName"]) },
        { "PONumber", d => txtPONumber.Text = Convert.ToString(d["PONumber"]) },
        { "ConsultRepID", d =>
            {
                if (ddlConsultantRep.Items.FindByValue(Convert.ToString(d["ConsultRepID"])) != null)
                {
                    ddlConsultantRep.SelectedValue = Convert.ToString(d["ConsultRepID"]);
                }
                else if(ddlConsultantRep.Items.Count > 0)
                {
                    ddlConsultantRep.SelectedIndex = 0;
                }
            }
        },
        { "OriginRepID", d =>
            {
                if (ddlOrgRep.Items.FindByValue(Convert.ToString(d["OriginRepID"])) != null)
                {
                    ddlOrgRep.SelectedValue = Convert.ToString(d["OriginRepID"]);
                }
                else if(ddlOrgRep.Items.Count > 0)
                {
                    ddlOrgRep.SelectedIndex = 0;
                }
            }
        },
        { "RepID", d =>
            {
                if (ddlDesRep.Items.FindByValue(Convert.ToString(d["RepID"])) != null)
                {
                    ddlDesRep.SelectedValue = Convert.ToString(d["RepID"]);
                }
                else if(ddlDesRep.Items.Count > 0)
                {
                    ddlDesRep.SelectedIndex = 0;
                }
            }
        },
        { "DealerID", d =>
            {
                if (ddlDealer.Items.FindByValue(Convert.ToString(d["DealerID"])) != null)
                {
                    ddlDealer.SelectedValue = Convert.ToString(d["DealerID"]);
                }
                else if(ddlDealer.Items.Count > 0)
                {
                    ddlDealer.SelectedIndex = 0;
                }
            }
        },
        { "ConsultantID", d =>
            {
                if (ddlConsultant.Items.FindByValue(Convert.ToString(d["ConsultantID"])) != null)
                {
                    ddlConsultant.SelectedValue = Convert.ToString(d["ConsultantID"]);
                }
                else if(ddlConsultant.Items.Count > 0)
                {
                    ddlConsultant.SelectedIndex = 0;
                }
                int Consultantid = Convert.ToInt32(d["ConsultantID"]);
            }
        },
        { "SalesSourceID", d =>
            {
                if (ddlSalesSource.Items.FindByValue(Convert.ToString(d["SalesSourceID"])) != null)
                {
                    ddlSalesSource.SelectedValue = Convert.ToString(d["SalesSourceID"]);
                }
                else if(ddlSalesSource.Items.Count > 0)
                {
                    ddlSalesSource.SelectedIndex = 0;
                }
            }
        },
        { "PORec", d => txtPoRecDate.Text = cls.Converter(Convert.ToString(d["PORec"])) },
        { "OrderBelongsTo", d =>
            {
                if (Convert.ToInt32(d["OrderBelongsTo"]) == 1)
                {
                    rdbOrderFor.SelectedValue = "1";
                }
                else
                {
                    rdbOrderFor.SelectedValue = "2";
                }
            }
        },
        { "QuoteSelected", d => txtQuote.Text = Convert.ToString(d["QuoteSelected"]) },
        { "SpecCredits", d =>
            {
                if (Convert.ToString(d["SpecCredits"]) != "0")
                {
                    rdbSpecCredit.SelectedValue = Convert.ToString(d["SpecCredits"]);
                }
                else
                {
                    rdbSpecCredit.SelectedValue = null;
                }
            }
        },
        { "SpecCreditPercentID", d =>
            {
                if (ddlSpecCredit.Items.FindByValue(Convert.ToString(d["SpecCreditPercentID"])) != null)
                {
                    ddlSpecCredit.SelectedValue = Convert.ToString(d["SpecCreditPercentID"]);
                }
                else if(ddlSpecCredit.Items.Count > 0)
                {
                    ddlSpecCredit.SelectedIndex = 0;
                }
            }
        },
        { "SpecCreditAmount", d => txtSpecAmount.Text = Convert.ToString(d["SpecCreditAmount"]) },
        { "txtSpecConsultantRep", d => txtSpecConsultantRep.Text = ddlConsultantRep.SelectedItem.Text },
        { "txtSpecConsultant", d => txtSpecConsultant.Text = ddlConsultant.SelectedItem.Text },
        { "SpecCreditCheckNo", d => txtSpecCheque.Text = Convert.ToString(d["SpecCreditCheckNo"]) },
        { "SpecCreditPaidDate", d => txtSpecPaid.Text = cls.Converter(Convert.ToString(d["SpecCreditPaidDate"])) },
        { "ReleaseDate", d => txtReleased.Text = cls.Converter(Convert.ToString(d["ReleaseDate"])) },
        { "DateAsBuiltDrgsSent", d => txtDateBuiltDrgsSent.Text = cls.Converter(Convert.ToString(d["DateAsBuiltDrgsSent"])) },
        { "EstCompletionDate", d => txtEstimatedCom.Text = cls.Converter(Convert.ToString(d["EstCompletionDate"])) },
        { "ActualCompletionDate", d => txtActualCom.Text = cls.Converter(Convert.ToString(d["ActualCompletionDate"])) },
        { "TestRunDate", d => txtTestRun.Text = cls.Converter(Convert.ToString(d["TestRunDate"])) },
        { "PurchasedItemsCAD", d =>
            {
                if (ddlPurchasedItemsCAD.Items.FindByValue(Convert.ToString(d["PurchasedItemsCAD"])) != null)
                {
                    ddlPurchasedItemsCAD.SelectedValue = Convert.ToString(d["PurchasedItemsCAD"]);
                }
                else if(ddlPurchasedItemsCAD.Items.Count > 0)
                {
                    ddlPurchasedItemsCAD.SelectedIndex = 0;
                }
            }
        },
        { "InstallationBy", d =>
            {
                if (ddlInstallationBy.Items.FindByValue(Convert.ToString(d["InstallationBy"])) != null)
                {
                    ddlInstallationBy.SelectedValue = Convert.ToString(d["InstallationBy"]);
                    if(ddlInstallationBy.SelectedIndex > 0)
                    {
                        ddInstalledBy(ddlInstallationBy.SelectedValue);
                        InstallationCommitment();
                    }
                }
                else if(ddlInstallationBy.Items.Count > 0)
                {
                    ddlInstallationBy.SelectedIndex = 0;
                }
            }
        },
        { "InstallatorA", d =>
            {
                if (ddlInstallerA.Items.FindByValue(Convert.ToString(d["InstallatorA"])) != null)
                {
                    ddlInstallerA.SelectedValue = Convert.ToString(d["InstallatorA"]);
                }
                else if(ddlInstallerA.Items.Count > 0)
                {
                    ddlInstallerA.SelectedIndex = 0;
                }
            }
        },
        { "InstallatorB", d =>
            {
                if (ddlInstallerB.Items.FindByValue(Convert.ToString(d["InstallatorB"])) != null)
                {
                    ddlInstallerB.SelectedValue = Convert.ToString(d["InstallatorB"]);
                }
                else if(ddlInstallerB.Items.Count > 0)
                {
                    ddlInstallerB.SelectedIndex = 0;
                }
            }
        },
        { "InstallatorC", d =>
            {
                if (ddlInstallerC.Items.FindByValue(Convert.ToString(d["InstallatorC"])) != null)
                {
                    ddlInstallerC.SelectedValue = Convert.ToString(d["InstallatorC"]);
                }
                else if(ddlInstallerC.Items.Count > 0)
                {
                    ddlInstallerC.SelectedIndex = 0;
                }
            }
        },
        { "InstallDate", d => txtInstallationStart.Text = cls.Converter(Convert.ToString(d["InstallDate"])) },
        { "InstallationCompletionDate", d => txtInstallationEnd.Text = cls.Converter(Convert.ToString(d["InstallationCompletionDate"])) },
        { "DemoDate", d => txtDemo.Text = cls.Converter(Convert.ToString(d["DemoDate"])) },
        { "WarrantyStartDate", d => txtWarrantyStart.Text = cls.Converter(Convert.ToString(d["WarrantyStartDate"])) },
        { "WarrantyEndDate", d => txtWarrantyEnd.Text = cls.Converter(Convert.ToString(d["WarrantyEndDate"])) },
        { "FollowUpDate", d => txtFollowUp.Text = cls.Converter(Convert.ToString(d["FollowUpDate"])) },
        { "CustCarePackageSendDate", d => txtCarePack.Text = cls.Converter(Convert.ToString(d["CustCarePackageSendDate"])) },
        { "ManualDispatchDate", d => txtManualsDisp.Text = cls.Converter(Convert.ToString(d["ManualDispatchDate"])) },
        { "Comments", d => txtTestRemarks.Text = Convert.ToString(d["Comments"]) },
        { "PMPack", d =>
            {
                if (Convert.ToInt32(d["PMPack"]) == 0)
                {
                    rdbPM.SelectedValue = "0";
                }
                else
                {
                    rdbPM.SelectedValue = "1";
                }
            }
        },
        { "ProjectStatus", d =>
            {
                if (d["ProjectStatus"].ToString() != "")
                {
                    ddlprojectstatus.SelectedValue = d["ProjectStatus"].ToString();
                }
                else if(ddlprojectstatus.Items.Count > 0)
                {
                    ddlprojectstatus.SelectedIndex = 0;
                }
            }
        },
        { "ProjectManager", d =>
            {
                if (ddlProjectManager.Items.FindByValue(d["ProjectManager"].ToString()) != null)
                {
                    ddlProjectManager.SelectedValue = d["ProjectManager"].ToString();
                }
                else if(ddlProjectManager.Items.Count > 0)
                {
                    ddlProjectManager.SelectedIndex = 0;
                }
            }
        },
        { "DeliveryPref", d =>
            {
                if (ddlDeliveryPref.Items.FindByValue(d["DeliveryPref"].ToString()) != null)
                {
                    ddlDeliveryPref.SelectedValue = d["DeliveryPref"].ToString();
                }
                else if(ddlDeliveryPref.Items.Count > 0)
                {
                    ddlDeliveryPref.SelectedIndex = 0;
                }
            }
        },
       { "DealerSiteContact", d =>
            {
                if (ddlCustomerSiteContact.Items.FindByValue(d["DealerSiteContact"].ToString()) != null)
                {
                    ddlCustomerSiteContact.SelectedValue = d["DealerSiteContact"].ToString();
                }
                else if(ddlCustomerSiteContact.Items.Count > 0)
                {
                    ddlCustomerSiteContact.SelectedIndex = 0;
                }
            }
        },
        { "DealerProjectManager", d =>
            {
                if (ddlDealerProjManager.Items.FindByValue(d["DealerProjectManager"].ToString()) != null)
                {
                    ddlDealerProjManager.SelectedValue = d["DealerProjectManager"].ToString();
                }
                else if(ddlDealerProjManager.Items.Count > 0)
                {
                    ddlDealerProjManager.SelectedIndex = 0;
                }
            }
        },
        { "WorkingHours", d =>
            {
                if (ddlWorkingHours.Items.FindByValue(d["WorkingHours"].ToString()) != null)
                {
                    ddlWorkingHours.SelectedValue = d["WorkingHours"].ToString();
                }
                else if(ddlWorkingHours.Items.Count > 0)
                {
                    ddlWorkingHours.SelectedIndex = 0;
                }
            }
        },
        { "MontoFriTime", d =>
            {
                //if (d["MontoFriTime"].ToString() != "")
                //{
                    txtMontoFriTime.Text = d["MontoFriTime"].ToString();
                //}

            }
        },
        { "SatSunTime", d =>
            {
                //if (d["SatSunTime"].ToString() != "")
                //{
                    txtSatSunTime.Text = d["SatSunTime"].ToString();
                //}
            }
        },
        { "ProjectReviewedBy", d =>
            {
                if(ddlProjectReviewedBy.Items.FindByValue(d["ProjectReviewedBy"].ToString()) != null)
                {
                    ddlProjectReviewedBy.SelectedValue = d["ProjectReviewedBy"].ToString();
                }
                else if(ddlProjectReviewedBy.Items.Count > 0)
                {
                    ddlProjectReviewedBy.SelectedIndex = 0;
                }
            }
        },
        { "ProjectReviewedDate", d =>
            {
                txtProjectReviewedDate.Text = cls.Converter(Convert.ToString(d["ProjectReviewedDate"]));
            }
        },
        { "ReasonForPriceUpdate", d => txtReasonForPriceUpdate.Text = d["ReasonForPriceUpdate"].ToString() },
        { "UpdatedOnVisual", d => chkUpdatedOnVisual.Checked = Convert.ToBoolean(d["UpdatedOnVisual"]) },
        { "ConfirmedFromGover", d => chkConfirmedFromGover.Checked = Convert.ToBoolean(d["ConfirmedFromGover"]) },
        { "InvoiceNotRequired", d => chkInvoiceNotRequired.Checked = Convert.ToBoolean(d["InvoiceNotRequired"]) },
        { "InstallationCommitment", d =>
            {
                if (ddlInstallationCommitment.Items.FindByValue(Convert.ToString(d["InstallationCommitment"])) != null)
                {
                    ddlInstallationCommitment.SelectedValue = Convert.ToString(d["InstallationCommitment"]);
                }
                else if(ddlInstallationCommitment.Items.Count > 0)
                {
                    ddlInstallationCommitment.SelectedIndex = 0;
                }
            }
        },
        { "InstallationPriority", d =>
            {
                if (ddlInstallationPriority.Items.FindByValue(Convert.ToString(d["InstallationPriority"])) != null)
                {
                    ddlInstallationPriority.SelectedValue = Convert.ToString(d["InstallationPriority"]);
                }
                else if(ddlInstallationPriority.Items.Count > 0)
                {
                    ddlInstallationPriority.SelectedIndex = 0;
                }
            }
        },
        { "StartupDate", d => txtStartupDate.Text = cls.Converter(Convert.ToString(d["StartupDate"])) },
        { "CommissioningDate", d => txtCommissioningDate.Text = cls.Converter(Convert.ToString(d["CommissioningDate"])) },
        { "ShippingReq", d =>
            {
                if (ddlShippingRequirements.Items.FindByValue(Convert.ToString(d["ShippingReq"])) != null)
                {
                    ddlShippingRequirements.SelectedValue = Convert.ToString(d["ShippingReq"]);
                }
                else if(ddlShippingRequirements.Items.Count > 0)
                {
                    ddlShippingRequirements.SelectedIndex = 0;
                }
            }
        },
        { "ShippingReqDetails", d => txtShippingRequirementDetails.Text = d["ShippingReqDetails"].ToString() },
        { "CertificateReqDetails", d => txtCertReq.Text = d["CertificateReqDetails"].ToString() },
        { "MannedFireWatch", d => chkMannedFireWatch.Checked = Convert.ToBoolean(d["MannedFireWatch"]) },
        { "MannedFireWatchDetails", d => txtMannedFireWatch.Text = d["MannedFireWatchDetails"].ToString() },
        { "HotWorkPermit", d => chkHotWorkPermit.Checked = Convert.ToBoolean(d["HotWorkPermit"]) },
        { "HotWorkPermitDetails", d => txtHotWorkPermit.Text = d["HotWorkPermitDetails"].ToString() },
        { "OrientTraining", d => rdbOrientTraining.SelectedValue = d["OrientTraining"].ToString() },
        { "OrientTrainingDetails", d => txtOrientationTraining.Text = d["OrientTrainingDetails"].ToString() },
        { "CanTechAccess", d => chkCanTechAccess.Checked = Convert.ToBoolean(d["CanTechAccess"]) },
        { "CanTechAccessDetails", d => txtCanTechAccess.Text = d["CanTechAccessDetails"].ToString() },
        { "Osha", d => chkOsha.Checked = Convert.ToBoolean(d["Osha"]) },
        { "OshaDetails", d => txtOsha.Text = d["OshaDetails"].ToString() },
        { "StateCertificate", d => chkStateCertificate.Checked = Convert.ToBoolean(d["StateCertificate"]) },
        { "StateCertificateDetails", d => txtStateCertificate.Text = d["StateCertificateDetails"].ToString() },
        { "DrugTestingCertificate", d => chkDrugTestingCertificate.Checked = Convert.ToBoolean(d["DrugTestingCertificate"]) },
        { "DrugTestingCertificateDetails", d => txtDrugTestingCertificate.Text = d["DrugTestingCertificateDetails"].ToString() },
        { "WHMIS", d => chkWHMIS.Checked = Convert.ToBoolean(d["WHMIS"]) },
        { "WHMISDetails", d => txtWHMIS.Text = d["WHMISDetails"].ToString() },
        { "FallProtection", d => chkFallProtection.Checked = Convert.ToBoolean(d["FallProtection"]) },
        { "FallProtectionDetails", d => txtFallProtection.Text = d["FallProtectionDetails"].ToString() },
        { "MedicalCertificate", d => chkMedicalCertificate.Checked = Convert.ToBoolean(d["MedicalCertificate"]) },
        { "MedicalCertificateDetails", d => txtMedicalCertificate.Text = d["MedicalCertificateDetails"].ToString() },
        { "InsuranceCertificate", d => chkInsuranceCertificate.Checked = Convert.ToBoolean(d["InsuranceCertificate"]) },
        { "InsuranceCertificateDetails", d => txtInsuranceCertificate.Text = d["InsuranceCertificateDetails"].ToString() },
        { "ScopeOfWork", d => txtScopeOfWork.Text = d["ScopeOfWork"].ToString() },
        { "ScopeDate", d => txtScopeDate.Text = d["ScopeDate"].ToString() },
        { "PlumbingElectricalSupply", d => txtPlumbingElectricalSupply.Text = d["PlumbingElectricalSupply"].ToString() },
        { "SalesOpportunity", d =>
            {
                if (ddlSalesOpportunity.Items.FindByValue(Convert.ToString(d["SalesOpportunity"])) != null)
                {
                    ddlSalesOpportunity.SelectedValue = Convert.ToString(d["SalesOpportunity"]);
                }
                else if(ddlSalesOpportunity.Items.Count > 0)
                {
                    ddlSalesOpportunity.SelectedIndex = 0;
                }
            }
        },
        { "SalesOpportunityStatus", d =>
            {
                if (ddlSalesOpportunityStatus.Items.FindByValue(Convert.ToString(d["SalesOpportunityStatus"])) != null)
                {
                    ddlSalesOpportunityStatus.SelectedValue = Convert.ToString(d["SalesOpportunityStatus"]);
                }
                else if(ddlSalesOpportunityStatus.Items.Count > 0)
                {
                    ddlSalesOpportunityStatus.SelectedIndex = 0;
                }
            }
        },
        { "ExpectedSalesDate", d => txtExpectedSalesDate.Text = d["ExpectedSalesDate"].ToString() }
    };

                var Reviewedby = Convert.ToString(dr["ReviewedBy"]);
                var ReviewedbyID = new List<string> { "33", "40", "75", "89", "161" };

                btnSave.Text = "Update";

                foreach (var assignment in assignments)
                {
                    try
                    {
                        assignment.Value(dr);
                    }
                    catch (Exception ex)
                    {
                        Utility.AddEditException(ex, assignment.Key);
                    }
                }

                ResetModels();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < chkTechnician.Items.Count; i++)
                    {
                        for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                        {
                            var chk = ds.Tables[1].Rows[j]["EmployeeID"];
                            if (chkTechnician.Items[i].Value == chk.ToString())
                            {
                                chkTechnician.Items[i].Selected = true;
                            }
                        }
                    }
                }

                ResetCertReq();
                if (ds.Tables[2].Rows.Count > 0)
                {
                    for (int i = 0; i < chkCertReq.Items.Count; i++)
                    {
                        for (int j = 0; j < ds.Tables[2].Rows.Count; j++)
                        {
                            var chk = ds.Tables[2].Rows[j]["CertificateReq"];
                            if (chkCertReq.Items[i].Value == chk.ToString())
                            {
                                chkCertReq.Items[i].Selected = true;
                            }
                        }
                    }
                }
                //BindShipDateGrid();
                CalculateTotalAmountReceived();
                RunAllCalculationBeforeUpdate();
                //CalculateRebatableAmountForCommission();
                //CalculateCommissionRate();
                CheckRegionForReps();
                EnableDisableShipDate();
                Disable_NetAmountFields();
                Get_Tax();
                InvoiceAmountCheck();
                //string strMethodName = "GetConsultant();";
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
                string strMethodRepName = "GetConsultantRep();";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodRepName, true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "text", "getCheckedRadio();", true);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetConsultant();", true);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "getCheckedRadio()", true);

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "enableDisable_MFW()", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "enableDisable_HWP()", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "enableDisable_CTA()", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "enableDisable_Osha()", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "enableDisable_StateCertificate()", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "enableDisable_DrugTestingCertificate()", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "enableDisable_WHMIS()", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "enableDisable_FallProtection()", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "enableDisable_MedicalCertificate()", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "enableDisable_InsuranceCertificate()", true);
                EnableDisableReports();
                LoadBulletLabels();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void LoadBulletLabels()
    {
        try
        {
            ObjBOL.Operation = 20;
            if (ddlConsultantRep.SelectedIndex > 0)
            {
                ObjBOL.ConsultRepID = Int32.Parse(ddlConsultantRep.SelectedValue);
            }

            if (ddlDesRep.SelectedIndex > 0)
            {
                ObjBOL.RepID = Int32.Parse(ddlDesRep.SelectedValue);
            }

            if (ddlOrgRep.SelectedIndex > 0)
            {
                ObjBOL.OriginRepID = Int32.Parse(ddlOrgRep.SelectedValue);
            }

            DataSet ds = ObjBLL.GetProjects(ObjBOL);

            if (ddlProjectManager.SelectedIndex > 0)
            {
                lblPM.Text = "PM : <b>" + ddlProjectManager.SelectedItem.Text + "</b>";

                lblPM.Visible = true;
            }
            else
            {
                lblPM.Text = String.Empty;
                lblPM.Visible = false;
            }

            if (ddlDesRep.SelectedIndex > 0)
            {
                string append = "";
                if (ds.Tables[2].Rows.Count > 0 && ds.Tables[2].Rows[0][0].ToString().Trim() != "")
                {
                    append = "(" + ds.Tables[2].Rows[0][0].ToString() + ")";
                }
                lblDesRep.Text = "Dest. Rep : <b>" + ddlDesRep.SelectedItem.Text + append + "</b>";
                lblDesRep.Visible = true;
            }
            else
            {
                lblDesRep.Text = String.Empty;
                lblDesRep.Visible = false;
            }

            if (ddlConsultantRep.SelectedIndex > 0)
            {
                string append = "";
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0].ToString().Trim() != "")
                {
                    append = "(" + ds.Tables[0].Rows[0][0].ToString() + ")";
                }
                lblConsultantRep.Text = "Consultant Rep : <b>" + ddlConsultantRep.SelectedItem.Text + append + "</b>";
                lblConsultantRep.Visible = true;
            }
            else
            {
                lblConsultantRep.Text = String.Empty;
                lblConsultantRep.Visible = false;
            }

            if (ddlOrgRep.SelectedIndex > 0)
            {
                string append = "";
                if (ds.Tables[1].Rows.Count > 0 && ds.Tables[1].Rows[0][0].ToString().Trim() != "")
                {
                    append = "(" + ds.Tables[1].Rows[0][0].ToString() + ")";
                }
                lblOrgRep.Text = "Org. Rep : <b>" + ddlOrgRep.SelectedItem.Text + append + "</b>";
                lblOrgRep.Visible = true;
            }
            else
            {
                lblOrgRep.Text = String.Empty;
                lblOrgRep.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CalculateCommissionRate()
    {
        try
        {
            if (txtCommDate.Text == "")
            {
                decimal NetRateCommAmount = 0;
                decimal RoundOffValue = 0;
                if ((txtAmountForComision.Text != "" && txtAmountForComision.Text != "0") && (ddlRate.SelectedIndex > 0))
                {
                    // txtNetRateCommission.Text 
                    NetRateCommAmount = (Convert.ToDecimal(txtAmountForComision.Text) * Convert.ToDecimal(ddlRate.SelectedValue) / 100);
                    RoundOffValue = Math.Floor(NetRateCommAmount);
                    if (NetRateCommAmount - RoundOffValue >= 0.5m)
                    {
                        RoundOffValue += 1;
                    }
                }
                txtNetRateCommission.Text = RoundOffValue.ToString("N");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void CalculateTotalAmountReceived()
    {
        try
        {
            if (txtAmountInvoiced.Text != "")
            {
                decimal TotalAmountInvoiced = 0;
                TotalAmountInvoiced = Convert.ToDecimal(txtAmountInvoiced.Text);
                if (txtCashDiscountAmount.Text != "")
                {
                    decimal CashDiscountAmount = 0;
                    decimal TotalAmountReceived = 0;
                    CashDiscountAmount = Convert.ToDecimal(txtCashDiscountAmount.Text);
                    TotalAmountReceived = TotalAmountInvoiced - CashDiscountAmount;
                    if (TotalAmountReceived > 0)
                    {
                        txtTAmountRec.Text = TotalAmountReceived.ToString("N");
                    }
                    else
                    {
                        txtTAmountRec.Text = "0";
                    }
                }
            }
            else
            {
                txtTAmountRec.Text = "0";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CalculateRebatableAmountForCommission()
    {
        try
        {
            decimal Freight = 0;
            decimal Installation = 0;
            if (txtFreight.Text != "")
            {
                Freight = Convert.ToDecimal(txtFreight.Text);
            }

            if (txtInstall.Text != "")
            {
                Installation = Convert.ToDecimal(txtInstall.Text);
            }

            decimal TAmtRec = 0;
            if (txtTAmountRec.Text == "")
            {
                TAmtRec = 0;
                txtAmountForComision.Text = "0";
            }
            else
            {
                TAmtRec = Convert.ToDecimal(txtTAmountRec.Text);
                if (TAmtRec > 0)
                {
                    txtAmountForComision.Text = (TAmtRec - Freight - Installation).ToString("N");
                    decimal ci = Convert.ToDecimal(txtAmountForComision.Text);
                    if (ci < 0)
                    {
                        txtAmountForComision.Text = "0";
                    }
                }
                else
                {
                    txtAmountForComision.Text = "0";
                }
            }
            CalculateCommissionRate();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableDisableShipDate()
    {
        try
        {
            if (string.IsNullOrEmpty(txtinvnumber.Text) == false || string.IsNullOrEmpty(txtinvnumber.Text) == false)
            {
                if (string.IsNullOrEmpty(txtShipDate.Text) == false)
                {
                    if (ddlShippingComit.SelectedValue == "F")
                    {
                        BindShipDateGrid();
                        txtShipDate.Enabled = false;
                    }
                }
                else
                {
                    ShipppingCommitShipDate();
                }
            }
            else
            {
                ShipppingCommitShipDate();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Get_Tax()
    {
        try
        {
            Decimal TaxAmount = 0;
            int CustomerID = Convert.ToInt32(HfCustomerID.Value);
            DateTime? JobOrderDate = Utility.ConvertDate(txtJobOrderDate.Text);
            Decimal NetAmount = Utility.ToDecimal(txtNetAmount.Text);
            if ((CustomerID != 0) && (JobOrderDate != null) && (NetAmount != 0))
            {
                ObjBOL.CustomerID = CustomerID;
                ObjBOL.JobOrderDate = JobOrderDate;
                ObjBOL.NetAmount = NetAmount;
                TaxAmount = ObjBLL.GetTaxAmount(ObjBOL);
                txtHST.Text = Convert.ToString(TaxAmount);
                Decimal NetAmt = Utility.ToDecimal(txtNetAmount.Text);
                Decimal HST = Utility.ToDecimal(txtHST.Text);
                Decimal TotalAmt_Show = (NetAmt + HST);
                txtTotalAmount.Text = Convert.ToDecimal(TotalAmt_Show).ToString("N");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private string GetProjectStatus(string Jobid)
    {
        string sts = string.Empty;
        try
        {
            ObjBOL.JobID = Jobid;
            ObjBOL.Operation = 5;
            sts = ObjBLL.GetProjectStatus(ObjBOL);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return sts;
    }

    private void SaveData()
    {
        try
        {
            if (!Utility.IsAuthorized())
            {
                return;
            }
            string msg = string.Empty;
            //AssignInitialValues();
            RunAllCalculationBeforeUpdate();

            if (btnSave.Text.ToLower() == "save")
            {
                ObjBOL.Operation = 11;
            }
            else if (btnSave.Text.ToLower() == "update")
            {
                ObjBOL.Operation = 10;
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Operation not clear !");
            }

            ObjBOL.JobID = txtJobId.Text;
            if (txtJobOrderDate.Text != "")
            {
                ObjBOL.JobOrderDate = Utility.ConvertDate(txtJobOrderDate.Text);
            }
            else
            {
                ObjBOL.JobOrderDate = null;
            }

            if (rdbOrderFor.SelectedValue == "1")
            {
                ObjBOL.OrderBelongsToDELETE = 1;
            }
            else if (rdbOrderFor.SelectedValue == "2")
            {
                ObjBOL.OrderBelongsToDELETE = 2;
            }

            if (txtPoRecDate.Text != "")
            {
                ObjBOL.PORec = Utility.ConvertDate(txtPoRecDate.Text);
            }

            if (ddlOASentTo.SelectedIndex > 0)
            {
                ObjBOL.OASentTo = ddlOASentTo.SelectedValue;
            }

            ObjBOL.QuoteSelected = txtQuote.Text;

            if (txtOrderAckDate.Text != "")
            {
                ObjBOL.JobOrderAck = Utility.ConvertDate(txtOrderAckDate.Text);
            }

            if (txtOADispatch.Text != "")
            {
                ObjBOL.JobOADis = Utility.ConvertDate(txtOADispatch.Text);
            }

            ObjBOL.ProposalID = txtPNumber.Text;

            if (HfCustomerID.Value != "-1")
            {
                ObjBOL.CustomerID = Convert.ToInt32(HfCustomerID.Value);
            }

            if (ddlShipper.SelectedIndex > 0)
            {
                ObjBOL.ShipperID = Convert.ToInt32(ddlShipper.SelectedValue);
            }
            ObjBOL.ShippingCommit = Convert.ToString(ddlShippingComit.SelectedValue);
            ObjBOL.ShipStatus = Convert.ToString(ddlShippingStatus.SelectedValue);

            ObjBOL.SiteContact = txtContactPerson.Text;
            ObjBOL.SiteContactTelephone = txtPhone.Text;
            ObjBOL.SiteContactEmail = txtEmail.Text;
            if (ddlShipperContactName.Items.Count > 0)
            {
                ObjBOL.ShipperContactName = ddlShipperContactName.SelectedItem.Text;
            }
            ObjBOL.ShipperPhone = txtShipperPhone.Text;
            ObjBOL.ShipperEmail = txtShipperEmail.Text;
            ObjBOL.ShipperTrackingNo = txtShipperTrackingNo.Text;
            ObjBOL.ShipperPickupFromShop = txtShipperPickupFromShop.Text;
            ObjBOL.ShipperNotes = txtShipperNotes.Text;
            ObjBOL.ShippedVia = rdbShippedVia.Text;
            if (txtActualShippingCost.Text.Trim() != "")
            {
                ObjBOL.ActualShippingCost = Decimal.Parse(txtActualShippingCost.Text);
            }

            if (txtAdditionalCharges.Text.Trim() != "")
            {
                ObjBOL.AdditionalCharges = Decimal.Parse(txtAdditionalCharges.Text);
            }

            if (txtDateBuiltDrgsSent.Text != "")
            {
                ObjBOL.DateAsBuiltDrgsSent = Utility.ConvertDate(txtDateBuiltDrgsSent.Text);
            }

            if (txtReleased.Text != "")
            {
                ObjBOL.ReleaseDate = Utility.ConvertDate(txtReleased.Text);
            }

            if (txtTestRun.Text != "")
            {
                ObjBOL.TestRunDate = Utility.ConvertDate(txtTestRun.Text);
            }

            if (txtEstimatedCom.Text != "")
            {
                ObjBOL.EstCompletionDate = Utility.ConvertDate(txtEstimatedCom.Text);
            }

            if (txtActualCom.Text != "")
            {
                ObjBOL.ActualCompletionDate = Utility.ConvertDate(txtActualCom.Text);
            }

            if (txtShipDate.Text != "")
            {
                ObjBOL.ShipDate = Utility.ConvertDate(txtShipDate.Text);
            }

            if (txtShipToArrive.Text != "")
            {
                ObjBOL.ShipToArriveDate = Utility.ConvertDate(txtShipToArrive.Text);
            }

            if (txtArrivalDate.Text != "")
            {
                ObjBOL.ArrivalDate = Utility.ConvertDate(txtArrivalDate.Text);
            }

            if (txtManualsDisp.Text != "")
            {
                ObjBOL.ManualDispatchDate = Utility.ConvertDate(txtManualsDisp.Text);
            }

            if (ddlInstallationBy.SelectedIndex > 0)
            {
                ObjBOL.InstallationBy = Convert.ToInt16(ddlInstallationBy.SelectedValue);
            }
            if (ddlInstallationPriority.SelectedIndex > 0)
            {
                ObjBOL.InstallationPriority = ddlInstallationPriority.SelectedValue;
            }

            if (ddlInstallationBy.SelectedValue == "1" || ddlInstallationBy.SelectedValue == "3")
            {
                if (ddlInstallationCommitment.SelectedIndex > 0)
                {
                    ObjBOL.InstallationCommitment = ddlInstallationCommitment.SelectedValue;
                }

                string selectedTechnician = string.Empty;
                for (int i = 0; i < chkTechnician.Items.Count; i++)
                {
                    if (chkTechnician.Items[i].Selected)
                    {
                        selectedTechnician += chkTechnician.Items[i].Value + ",";
                    }
                }
                if (selectedTechnician.Length > 0)
                {
                    ObjBOL.ProjectTechnician = selectedTechnician.Substring(0, selectedTechnician.Length - 1);
                }
            }

            if (txtInstallationStart.Text != "")
            {
                ObjBOL.InstallDate = Utility.ConvertDate(txtInstallationStart.Text);
            }

            if (txtInstallationEnd.Text != "")
            {
                ObjBOL.InstallationCompletionDate = Utility.ConvertDate(txtInstallationEnd.Text);
            }

            if (txtDemo.Text != "")
            {
                ObjBOL.DemoDate = Utility.ConvertDate(txtDemo.Text);
            }

            if (txtWarrantyStart.Text != "")
            {
                ObjBOL.WarrantyStartDate = Utility.ConvertDate(txtWarrantyStart.Text);
            }

            if (txtWarrantyEnd.Text != "")
            {
                ObjBOL.WarrantyEndDate = Utility.ConvertDate(txtWarrantyEnd.Text);
            }

            if (txtFollowUp.Text != "")
            {
                ObjBOL.FollowUpDate = Utility.ConvertDate(txtFollowUp.Text);
            }

            if (txtCarePack.Text != "")
            {
                ObjBOL.CustCarePackageSendDate = Utility.ConvertDate(txtCarePack.Text);
            }
            ObjBOL.PONumber = txtPONumber.Text;
            ObjBOL.InvoiceNumber = txtinvnumber.Text;

            if (txtInvodate.Text != "")
            {
                ObjBOL.DateInvoiceSent = Utility.ConvertDate(txtInvodate.Text);
            }

            if (txtDateReceived.Text != "")
            {
                ObjBOL.DatePaymentReceived = Utility.ConvertDate(txtDateReceived.Text);
            }

            if (txtCommDate.Text != "")
            {
                ObjBOL.DateCommissionPaid = Utility.ConvertDate(txtCommDate.Text);
            }
            ObjBOL.KflexCheckNumber = txtCommCheque.Text;
            ObjBOL.CommissionType = ddlRate.SelectedValue;

            if (ddlSalesSource.SelectedIndex > 0)
            {
                ObjBOL.SalesSourceID = Convert.ToInt32(ddlSalesSource.SelectedValue);
            }

            ObjBOL.ShipToName = txtCompany.Text;
            ObjBOL.ShipToStreet = txtAddress.Text;
            ObjBOL.ShipToCity = txtCity.Text;
            if (ddlState.Items.Count > 0)
            {
                ObjBOL.ShipToState = ddlState.SelectedValue;
            }
            
            if (ddlcountry.SelectedIndex > 0)
            {
                ObjBOL.ShipToCountry = ddlcountry.SelectedItem.Text;
            }

            ObjBOL.ShipToZipCode = txtZip.Text;
            if (ddlFOB.SelectedIndex > 0)
            {
                ObjBOL.fob = Convert.ToInt32(ddlFOB.SelectedValue);
            }

            if (ddlTerm.SelectedIndex > 0)
            {
                ObjBOL.term = Convert.ToInt32(ddlTerm.SelectedValue);
            }

            ObjBOL.NetAmount = Utility.ToDecimal(txtNetAmount.Text);
            ObjBOL.GST = Utility.ToDecimal(txtHST.Text);
            if (ddlInstallerA.SelectedIndex > 0)
            {
                ObjBOL.InstallatorA = Convert.ToInt16(ddlInstallerA.SelectedValue);
            }

            if (ddlInstallerB.SelectedIndex > 0)
            {
                ObjBOL.InstallatorB = Convert.ToInt16(ddlInstallerB.SelectedValue);
            }

            if (ddlInstallerC.SelectedIndex > 0)
            {
                ObjBOL.InstallatorC = Convert.ToInt16(ddlInstallerC.SelectedValue);
            }

            ObjBOL.Comments = txtTestRemarks.Text;
            //0 = false, 1 = true
            if (rdbPM.SelectedValue == "0")
            {
                ObjBOL.PMPack = false;
            }
            else if (rdbPM.SelectedValue == "1")
            {
                ObjBOL.PMPack = true;
            }
            if (ddlPurchasedItemsCAD.SelectedIndex > 0)
            {
                ObjBOL.PurchasedItemsCAD = ddlPurchasedItemsCAD.SelectedValue;
            }
            

            if (rdbSpecCredit.SelectedValue != "")
            {
                ObjBOL.SpecCredits = Convert.ToInt32(rdbSpecCredit.SelectedValue);
            }
            else if (rdbSpecCredit.SelectedValue == "1")
            {
                ObjBOL.SpecCredits = Convert.ToInt32(rdbSpecCredit.SelectedValue);
            }

            if (ddlSpecCredit.SelectedIndex > 0)
            {
                ObjBOL.SpecCreditPercentID = Convert.ToInt32(ddlSpecCredit.SelectedValue);
            }
            if(txtSpecAmount.Text != "")
            {
                ObjBOL.SpecCreditAmount = Utility.ToDecimal(txtSpecAmount.Text);
            }            
            ObjBOL.SpecCreditCheckNo = txtSpecCheque.Text;

            if (txtSpecPaid.Text != "")
            {
                ObjBOL.SpecCreditPaidDate = Utility.ConvertDate(txtSpecPaid.Text);
            }

            if (ddlDealer.SelectedIndex > 0)
            {
                ObjBOL.DealerID = Convert.ToInt16(ddlDealer.SelectedValue);
            }

            if (ddlOrgRep.SelectedIndex > 0)
            {
                ObjBOL.OriginRepID = Convert.ToInt32(ddlOrgRep.SelectedValue);
            }

            if (ddlConsultantRep.SelectedIndex > 0)
            {
                ObjBOL.ConsultRepID = Convert.ToInt32(ddlConsultantRep.SelectedValue);
            }

            if (ddlDesRep.SelectedIndex > 0)
            {
                ObjBOL.RepID = Convert.ToInt32(ddlDesRep.SelectedValue);
            }

            if (ddlConsultant.SelectedIndex > 0)
            {
                ObjBOL.ConsultantID = Convert.ToInt32(ddlConsultant.SelectedValue);
            }
            if(txtEqPrice.Text != "")
            {
                ObjBOL.Price = Utility.ToDecimal(txtEqPrice.Text);
            }
            if(txtFreight.Text != "")
            {
                ObjBOL.Freight = Utility.ToDecimal(txtFreight.Text);
            }
            if(txtInstall.Text != "")
            {
                ObjBOL.Installation = Utility.ToDecimal(txtInstall.Text);
            }            
            if (ddlCurrency.SelectedIndex > 0)
            {
                ObjBOL.CurrencyID = Convert.ToInt32(ddlCurrency.SelectedValue);
            }
            if(txtEqDisAmount.Text != "")
            {
                ObjBOL.EqDisAmount = Utility.ToDecimal(txtEqDisAmount.Text);
            }
            if(txtEqDiscount.Text != "")
            {
                ObjBOL.EqDiscount = Utility.ToDecimal(txtEqDiscount.Text);
            }
            if(txtNetEqPrice.Text != "")
            {
                ObjBOL.NetEqPrice = Utility.ToDecimal(txtNetEqPrice.Text);
            }
            if(txtExWarranty.Text != "")
            {
                ObjBOL.ExWarrantyPrice = Utility.ToDecimal(txtExWarranty.Text);
            }            
            if (ddlprojectstatus.SelectedIndex > 0)
            {
                ObjBOL.ProjectStatus = Convert.ToInt32(ddlprojectstatus.SelectedValue);
            }

            if (ddlProjectManager.SelectedIndex > 0)
            {
                ObjBOL.ProjectManager = Convert.ToInt32(ddlProjectManager.SelectedValue);
            }

            ObjBOL.ProjectCommNotes = txtProjectCommNotes.Text;
            ObjBOL.UserID = Utility.GetCurrentSession().EmployeeID;
            if(txtAmountInvoiced.Text != "")
            {
                ObjBOL.TotalAmtInv = Utility.ToDecimal(txtAmountInvoiced.Text);
            }
            if(txtCashDiscountAmount.Text != "")
            {
                ObjBOL.CashDisAmt = Utility.ToDecimal(txtCashDiscountAmount.Text);
            }
            if(txtCashDiscountPer.Text != "")
            {
                ObjBOL.CashDisPer = Utility.ToDecimal(txtCashDiscountPer.Text);
            }            
            if(txtTAmountRec.Text != "")
            {
                ObjBOL.CashAmtRec = Utility.ToDecimal(txtTAmountRec.Text);
            }
            if(txtAmountForComision.Text != "")
            {
                ObjBOL.AmountForComission = Utility.ToDecimal(txtAmountForComision.Text);
            }
            if(txtNetRateCommission.Text != "")
            {
                ObjBOL.NetCommissionRate = Utility.ToDecimal(txtNetRateCommission.Text);
            }            
            //Shipping Form
            if (ddlDeliveryPref.SelectedIndex > 0)
            {
                ObjBOL.DeliveryPref = Convert.ToInt32(ddlDeliveryPref.SelectedValue);
            }

            if (ddlCustomerSiteContact.SelectedIndex > 0)
            {
                ObjBOL.CustomerSiteContact = Convert.ToInt32(ddlCustomerSiteContact.SelectedValue);
            }

            if (ddlDealerProjManager.SelectedIndex > 0)
            {
                ObjBOL.DealerProjectManager = Convert.ToInt32(ddlDealerProjManager.SelectedValue);
            }

            if (ddlWorkingHours.SelectedIndex > 0)
            {
                ObjBOL.WorkingHours = Convert.ToInt32(ddlWorkingHours.SelectedValue);
            }

            if (txtMontoFriTime.Text != "")
            {
                ObjBOL.MontoFriTime = txtMontoFriTime.Text;
            }

            if (txtSatSunTime.Text != "")
            {
                ObjBOL.SatSunTime = txtSatSunTime.Text;

            }

            if (ddlProjectReviewedBy.SelectedIndex > 0 && txtProjectReviewedDate.Text != "")
            {
                ObjBOL.ProjectReviewedBy = Convert.ToInt32(ddlProjectReviewedBy.SelectedValue);
                ObjBOL.ProjectReviewedDate = Utility.ConvertDate(txtProjectReviewedDate.Text);
            }

            ObjBOL.ReasonForPriceUpdate = txtReasonForPriceUpdate.Text;

            if (chkUpdatedOnVisual.Checked)
            {
                ObjBOL.UpdatedOnVisual = true;
            }
            else
            {
                ObjBOL.UpdatedOnVisual = false;
            }

            if (chkConfirmedFromGover.Checked)
            {
                ObjBOL.ConfirmedFromGover = true;
            }
            else
            {
                ObjBOL.ConfirmedFromGover = false;
            }

            if (chkInvoiceNotRequired.Checked)
            {
                ObjBOL.InvoiceNotRequired = true;
            }
            else
            {
                ObjBOL.InvoiceNotRequired = false;
            }
            if(txtStartupDate.Text != "")
            {
                ObjBOL.StartupDate = Utility.ConvertDate(txtStartupDate.Text);
            }
            if(txtCommissioningDate.Text != "")
            {
                ObjBOL.CommissioningDate = Utility.ConvertDate(txtCommissioningDate.Text);
            }            
            if (ddlShippingRequirements.SelectedIndex > 0)
            {
                ObjBOL.ShippingReq = ddlShippingRequirements.SelectedValue;
            }

            ObjBOL.ShippingReqDetails = txtShippingRequirementDetails.Text;

            string selectedCertificateRequirements = string.Empty;
            for (int i = 0; i < chkCertReq.Items.Count; i++)
            {
                if (chkCertReq.Items[i].Selected)
                {
                    selectedCertificateRequirements += chkCertReq.Items[i].Value + ",";
                }
            }

            if (selectedCertificateRequirements.Length > 0)
            {
                ObjBOL.CertificateReq = selectedCertificateRequirements.Substring(0, selectedCertificateRequirements.Length - 1);
            }
            ObjBOL.CertificateReqDetails = txtCertReq.Text;

            if (chkMannedFireWatch.Checked)
            {
                ObjBOL.MannedFireWatch = true;
            }
            else
            {
                ObjBOL.MannedFireWatch = false;
            }
            ObjBOL.MannedFireWatchDetails = txtMannedFireWatch.Text;

            if (chkHotWorkPermit.Checked)
            {
                ObjBOL.HotWorkPermit = true;
            }
            else
            {
                ObjBOL.HotWorkPermit = false;
            }
            ObjBOL.HotWorkPermitDetails = txtHotWorkPermit.Text;

            if (chkOsha.Checked)
            {
                ObjBOL.Osha = true;
            }
            else
            {
                ObjBOL.Osha = false;
            }
            ObjBOL.OshaDetails = txtOsha.Text;

            if (chkStateCertificate.Checked)
            {
                ObjBOL.StateCertificate = true;
            }
            else
            {
                ObjBOL.StateCertificate = false;
            }
            ObjBOL.StateCertificateDetails = txtStateCertificate.Text;

            if (chkDrugTestingCertificate.Checked)
            {
                ObjBOL.DrugTestingCertificate = true;
            }
            else
            {
                ObjBOL.DrugTestingCertificate = false;
            }
            ObjBOL.DrugTestingCertificateDetails = txtDrugTestingCertificate.Text;

            if (chkWHMIS.Checked)
            {
                ObjBOL.WHMIS = true;
            }
            else
            {
                ObjBOL.WHMIS = false;
            }
            ObjBOL.WHMISDetails = txtWHMIS.Text;

            if (chkFallProtection.Checked)
            {
                ObjBOL.FallProtection = true;
            }
            else
            {
                ObjBOL.FallProtection = false;
            }
            ObjBOL.FallProtectionDetails = txtFallProtection.Text;

            if (chkMedicalCertificate.Checked)
            {
                ObjBOL.MedicalCertificate = true;
            }
            else
            {
                ObjBOL.MedicalCertificate = false;
            }
            ObjBOL.MedicalCertificateDetails = txtMedicalCertificate.Text;

            if (chkInsuranceCertificate.Checked)
            {
                ObjBOL.InsuranceCertificate = true;
            }
            else
            {
                ObjBOL.InsuranceCertificate = false;
            }
            ObjBOL.InsuranceCertificateDetails = txtInsuranceCertificate.Text;

            int result = 0;
            if (Int32.TryParse(rdbOrientTraining.SelectedValue, out result))
            {
                ObjBOL.OrientTraining = result;
            }
            ObjBOL.OrientTrainingDetails = txtOrientationTraining.Text;

            if (chkCanTechAccess.Checked)
            {
                ObjBOL.CanTechAccess = true;
            }
            else
            {
                ObjBOL.CanTechAccess = false;
            }
            ObjBOL.CanTechAccessDetails = txtCanTechAccess.Text;
            ObjBOL.ScopeOfWork = txtScopeOfWork.Text;
            if(txtScopeDate.Text != "")
            {
                ObjBOL.ScopeDate = Utility.ConvertDate(txtScopeDate.Text);
            }            
            ObjBOL.PlumbingElectricalSupply = txtPlumbingElectricalSupply.Text;
            if (ddlSalesOpportunity.SelectedIndex > 0)
            {
                ObjBOL.SalesOpportunity = Convert.ToInt32(ddlSalesOpportunity.SelectedValue);
            }

            if (ddlSalesOpportunityStatus.SelectedIndex > 0)
            {
                ObjBOL.SalesOpportunityStatus = Convert.ToInt32(ddlSalesOpportunityStatus.SelectedValue);
            }

            if (txtExpectedSalesDate.Text != "")
            {
                ObjBOL.ExpectedSalesDate = Utility.ConvertDate(txtExpectedSalesDate.Text);
            }

            msg = ObjBLL.SaveProject(ObjBOL).Trim();
            string notify = string.Empty;
            if (msg == Utility.UniqueConstraintErrorCode())
            {
                Utility.ShowMessage_Error(Page, "JobID already exists !!");
            }
            else if (msg == "1")
            {
                Utility.MaintainLogsSpecial("FrmProjects.aspx", "Update", txtJobId.Text);
                notify = "Project Updated !!";
            }
            else if (msg == "0")
            {
                Utility.MaintainLogsSpecial("FrmProjects.aspx", "Save", txtJobId.Text);
                notify = "Project Inserted !!";
            }

            if (msg == "0" || msg == "1")
            {
                //btnNew.Enabled = true;
                //btnSave.Text = "Update";
                //string strMethodName = "GetConsultant();";
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
                //string strMethodRepName = "GetConsultantRep();";
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodRepName, true);
                //hfShipToArriveDate.Value = txtShipDate.Text;
                ////string strMethodNameNew = "GetValue();";
                ////ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);
                ////todo.....
                ////CREATEAPPOINTMENT();
                //EnableDisableShipDate();
                //SyncTextbox("NUM", txtJobId.Text);
                //SyncTextbox("NAME", txtJobId.Text);
                //InvoiceAmountCheck();
                //LoadBulletLabels();
                Utility.ShowMessage_Success(Page, notify);
                string JobId = txtJobId.Text;
                //if (hfCheckShipDateChange.Value == "1")
                //{
                //    //TrackStatusData(txtJobId.Text, txtShipDate.Text);
                //}
                Reset();
                FillJnumber(JobId);
                SyncTextbox("NUM", JobId);
                SyncTextbox("NAME", JobId);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void EnableDisablePaymentControls(bool enable)
    {
        try
        {
            //var icsTab = (HtmlGenericControl)Page.FindControl("icsTab");
            EnableDisableControlRecursively(icsGeneralInformation, enable);
            EnableDisableControlRecursively(icsEarlyPaymentCashDiscount_1, enable);
            EnableDisableControlRecursively(icsEarlyPaymentCashDiscount_2, enable);
            EnableDisableControlRecursively(icsProjectCommissionInfo, enable);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableDisableControlRecursively(Control control, bool enable)
    {
        try
        {
            if (control is WebControl)
            {
                WebControl webControl = (WebControl)control;
                if (webControl.CssClass.Split(' ').Contains("paymentSection"))
                {
                    if (control is TextBox)
                    {
                        ((TextBox)control).Enabled = enable;
                    }
                    else if (control is DropDownList)
                    {
                        ((DropDownList)control).Enabled = enable;
                    }
                    else if (control is CheckBox)
                    {
                        ((CheckBox)control).Enabled = enable;
                    }
                }
            }

            if (control.HasControls())
            {
                foreach (Control childControl in control.Controls)
                {
                    EnableDisableControlRecursively(childControl, enable);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnProjectsEng_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "~/SalesManagement/FrmProjectsEng.aspx";
            if (txtJobId.Text.Trim() != "")
            {
                link += "?jid=" + txtJobId.Text.Trim();
            }
            Response.Redirect(link);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region General Information Tab Events

    #region Basic Info Events

    protected void ddlPNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtPNumber.Text.Trim() != "")
            {
                CheckForValidPNumber();
                MatchingProposalwithJob(txtPNumber.Text);
                SpecCredit();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ImgPNumber_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (txtPNumber.Text.Trim().Length > 6)
            {
                Session["PNumber"] = "";
                DataSet ds = new DataSet();
                ObjBOLSearch.Operation = 3;
                ObjBOLSearch.PNumber = txtPNumber.Text.Trim();
                ds = ObjBLLSearch.GetProposalSearch(ObjBOLSearch);
                Session["PNumber"] = ds.Tables[0].Rows[0]["Pnumber"].ToString();
                Response.Redirect("~/SalesManagement/FrmProposals.aspx");
            }
            else
            {
                Utility.ShowMessage_Error(Page, "PNumber not Found !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void MatchingProposalwithJob(string PNumber)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtPNumber.Text))
            {
                string JobID = "";
                DataSet ds = new DataSet();
                ds = Utility.CheckPNumber(PNumber);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    JobID = Convert.ToString(ds.Tables[0].Rows[0]["JobID"]);
                    if (JobID != "")
                    {
                        string PNum = txtPNumber.Text;
                        Utility.ShowMessage_Error(Page, JobID);
                        txtPNumber.Text = string.Empty;
                        txtPNumber.Focus();
                    }
                }
                else
                {
                    AutoFillDetails(txtPNumber.Text);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public class AutoFillPNumberDetails
    {
        Int32 _DealerID;
        public Int32 DealerID
        {
            get { return _DealerID; }
            set { _DealerID = value; }
        }
        Int32 _ConveyorTypeID;
        public Int32 ConveyorTypeID
        {
            get { return _ConveyorTypeID; }
            set { _ConveyorTypeID = value; }
        }
        Int32 _OriginRepID;
        public Int32 OriginRepID
        {
            get { return _OriginRepID; }
            set { _OriginRepID = value; }
        }
        Int32 _ConsultRepID;
        public Int32 ConsultRepID
        {
            get { return _ConsultRepID; }
            set { _ConsultRepID = value; }
        }
        Int32 _RepID;
        public Int32 RepID
        {
            get { return _RepID; }
            set { _RepID = value; }
        }
        Int32 _ConsultantID;
        public Int32 ConsultantID
        {
            get { return _ConsultantID; }
            set { _ConsultantID = value; }
        }
        Int32 _ModelID;
        public Int32 ModelID
        {
            get { return _ModelID; }
            set { _ModelID = value; }
        }
        Decimal _Price;
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        Decimal _Freight;
        public Decimal Freight
        {
            get { return _Freight; }
            set { _Freight = value; }
        }
        Decimal _Installation;
        public Decimal Installation
        {
            get { return _Installation; }
            set { _Installation = value; }
        }
        Int32 _CurrencyID;
        public Int32 CurrencyID
        {
            get { return _CurrencyID; }
            set { _CurrencyID = value; }
        }
        Int32 _ProjectDesignerID;
        public Int32 ProjectDesignerID
        {
            get { return _ProjectDesignerID; }
            set { _ProjectDesignerID = value; }
        }
        Decimal _EqDiscount;
        public Decimal EqDiscount
        {
            get { return _EqDiscount; }
            set { _EqDiscount = value; }
        }
        Decimal _EqDisAmount;
        public Decimal EqDisAmount
        {
            get { return _EqDisAmount; }
            set { _EqDisAmount = value; }
        }
        Decimal _NetEqPrice;
        public Decimal NetEqPrice
        {
            get { return _NetEqPrice; }
            set { _NetEqPrice = value; }
        }
        Int32 _SpecCredits;
        public Int32 SpecCredits
        {
            get { return _SpecCredits; }
            set { _SpecCredits = value; }
        }
        Int32 _SpecCreditPercentID;
        public Int32 SpecCreditPercentID
        {
            get { return _SpecCreditPercentID; }
            set { _SpecCreditPercentID = value; }
        }
        Decimal _SpecCreditAmount;
        public Decimal SpecCreditAmount
        {
            get { return _SpecCreditAmount; }
            set { _SpecCreditAmount = value; }
        }
        String _SpecCreditCheckNo;
        public String SpecCreditCheckNo
        {
            get { return _SpecCreditCheckNo; }
            set { _SpecCreditCheckNo = value; }
        }
        DateTime _SpecCreditPaidDate;
        public DateTime SpecCreditPaidDate
        {
            get { return _SpecCreditPaidDate; }
            set { _SpecCreditPaidDate = value; }
        }
        Int32 _OrderBelongsTo;
        public Int32 OrderBelongsTo
        {
            get { return _OrderBelongsTo; }
            set { _OrderBelongsTo = value; }

        }
        DateTime? _shipdate;
        public DateTime? shipdate
        {
            get { return _shipdate; }
            set { _shipdate = value; }
        }
        String _JobType;
        public String JobType
        {
            get { return _JobType; }
            set { _JobType = value; }
        }
        String _ExistingJobID;
        public String ExistingJobID
        {
            get { return _ExistingJobID; }
            set { _ExistingJobID = value; }
        }
    }

    private void AutoFillDetails(string PNumber)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = Utility.AutoFillPNumber(PNumber);
            AutoFillPNumberDetails detail = null;
            detail = new AutoFillPNumberDetails();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(ds.Tables[0].Rows[0]["DealerID"]) != "")
                {
                    ddlDealer.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["DealerID"]);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["OriginRepID"]) != "")
                {
                    ddlOrgRep.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["OriginRepID"]);
                }
                ddlConsultantRep.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ConsultRepID"]);
                ddlDesRep.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["RepID"]);
                ddlConsultant.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ConsultantID"]);

                Decimal EqPrice = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["Price"]), 2);
                txtEqPrice.Text = Convert.ToString(EqPrice);
                Decimal Freight = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["Freight"]), 2);
                txtFreight.Text = Convert.ToString(Freight);
                Decimal Installation = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["Installation"]), 2);
                txtInstall.Text = Convert.ToString(Installation);
                ddlCurrency.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CurrencyID"]);
                Decimal EqDiscount = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["EqDiscount"]), 2);
                txtEqDiscount.Text = Convert.ToString(EqDiscount);
                Decimal EqDisAmount = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["EqDisAmount"]), 2);
                txtEqDisAmount.Text = Convert.ToString(EqDisAmount);
                Decimal NetEqPrice = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["NetEqPrice"]), 2);
                txtNetEqPrice.Text = Convert.ToString(NetEqPrice);
                if (Convert.ToString(ds.Tables[0].Rows[0]["SpecCredits"]) != "0")
                {
                    rdbSpecCredit.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SpecCredits"]);
                }
                ddlSpecCredit.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SpecCreditPercentID"]);
                Decimal SpecAmount = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["SpecCreditAmount"]), 2);
                txtSpecAmount.Text = Convert.ToString(SpecAmount);
                txtSpecCheque.Text = Convert.ToString(ds.Tables[0].Rows[0]["SpecCreditCheckNo"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["SpecCreditPaidDate"]) != "")
                {
                    txtSpecPaid.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["SpecCreditPaidDate"]));
                }
                if (ddlConsultant.SelectedIndex > 0)
                {
                    txtSpecConsultant.Text = ddlConsultant.SelectedItem.Text;
                }
                if (ddlConsultantRep.SelectedIndex > 0)
                {
                    txtSpecConsultantRep.Text = ddlConsultantRep.SelectedItem.Text;
                }
                rdbOrderFor.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["OrderBelongsTo"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["shipdate"]) != "")
                {
                    txtShipDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["shipdate"]));
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["ProjectManager"]) != "")
                {
                    ddlProjectManager.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ProjectManager"]);
                }
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "getCalc();getPer()", true);
                txtAmountForComision.Text = NetEqPrice.ToString("N");
                decimal ExWarrantyPrice = 0;
                if (txtExWarranty.Text != "")
                {
                    ExWarrantyPrice = Math.Round(Convert.ToDecimal(txtExWarranty.Text), 2);
                }
                txtAmountInvoiced.Text = (NetEqPrice + Freight + Installation + ExWarrantyPrice).ToString("N");
                GetCashDiscountFromAmt();
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void CheckForValidPNumber()
    {
        try
        {
            if (txtPNumber.Text.Trim() != "")
            {
                ObjBOL.Operation = 8;
                ObjBOL.ProposalID = txtPNumber.Text;
                DataTable dt = ObjBLL.GetProjects(ObjBOL).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    txtPNumber.Text = string.Empty;
                    Utility.ShowMessage_Error(Page, "No Proposal ID Found !");
                }
                else
                {
                    string proposalID = dt.Rows[0]["ProposalID"].ToString();
                    if (proposalID.Trim() != "")
                    {
                        txtPNumber.Text = proposalID;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region General Information Events

    protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtCustomer.Text.Trim() != "")
            {
                GetCustomerID();
                Get_Tax();
                SpecCredit();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void lnkRedirecttoCustomer_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (HfCustomerID.Value != "-1" && txtJobId.Text != "")
            {
                Session["CustomerID"] = "";
                Session["CustomerID"] = HfCustomerID.Value;
                Session["JobID"] = HfJObID.Value;
                Response.Redirect("~/ContactManagement/FrmCustomers.aspx", false);
            }
            else
            {
                if (txtSearchPNum.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Job Details. !");
                    txtSearchPNum.Focus();
                    return;
                }
                if (HfCustomerID.Value == "-1")
                {
                    Utility.ShowMessage_Error(Page, "Please Select Customer. !");
                    txtCustomer.Focus();
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlDealer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDealer.SelectedIndex > 0)
            {
                GetCashDiscountFromDealer();
            }
            FillDealerProjectManager(ddlDealer.SelectedValue);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillDealerProjectManager(string DealerID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 14;
            ObjBOL.DealerID = Convert.ToInt16(DealerID);
            ds = ObjBLL.GetProjects(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDealerProjManager, ds.Tables[0]);
            }
            else
            {
                if (ddlDealerProjManager.Items.Count > 0)
                {
                    ddlDealerProjManager.Items.Clear();
                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtWarrantyStart_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtWarrantyStart.Text != "")
            {
                DateTime WEnddate = Convert.ToDateTime(txtWarrantyStart.Text).AddYears(1);
                txtWarrantyEnd.Text = cls.Converter(Convert.ToString(WEnddate));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnWarrntyLetter_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtSearchPNum.Text != "")
            {
                DataTable dt = new DataTable();
                rprt.Load(Server.MapPath("~/Reports/rptCustCareWarrantyLetter.rpt"));
                cls.Return_DT(dt, "EXEC [dbo].[Get_WarrantyLetter] '" + HfJObID.Value + "'");
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtJobId.Text + " - Warranty Letter");
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

    private void GetCashDiscountFromDealer()
    {
        try
        {
            decimal DiscountPer = 0;
            ObjBOL.DealerID = Convert.ToInt16(ddlDealer.SelectedValue);
            DiscountPer = ObjBLL.GetCashDiscount(ObjBOL);
            if (DiscountPer != 0)
            {
                txtCashDiscountPer.Text = DiscountPer.ToString();
                GetCashDiscountFromPer();
            }
            else
            {
                txtCashDiscountPer.Text = "0";
                txtCashDiscountAmount.Text = "0";
                CalculateTotalAmountReceived();
                CalculateRebatableAmountForCommission();
                CalculateCommissionRate();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetCashDiscountFromPer()
    {
        try
        {
            decimal EqPrice = Convert.ToDecimal(txtNetEqPrice.Text);
            decimal TAmtInvoiced = 0;
            decimal DiscountPercent = 0;
            decimal TAmtRec = 0;

            if (txtAmountInvoiced.Text == "")
            {
                TAmtInvoiced = 0;
            }
            else
            {
                TAmtInvoiced = Convert.ToDecimal(txtAmountInvoiced.Text);
            }

            if (txtCashDiscountPer.Text != "")
            {
                DiscountPercent = Convert.ToDecimal(txtCashDiscountPer.Text);
            }

            decimal DiscountAmt = 0;
            decimal DiscountAmtRec = 0;
            decimal AmtRec = 0;
            DiscountAmt = (TAmtInvoiced * DiscountPercent) / 100;

            DiscountAmtRec = (EqPrice * DiscountPercent) / 100;
            TAmtRec = (TAmtInvoiced - DiscountAmt);
            txtCashDiscountAmount.Text = DiscountAmt.ToString("N");

            AmtRec = (EqPrice - DiscountAmt);
            txtTAmountRec.Text = TAmtRec.ToString("N");
            CalculateRebatableAmountForCommission();
            CalculateCommissionRate();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtEqPrice_TextChanged(object sender, EventArgs e)
    {
        txtEqPrice_TextChanged();
    }

    private void txtEqPrice_TextChanged()
    {
        try
        {
            if (txtTAmountRec.Text != "")
            {
                CalculateTotalAmountInvoiced();
                CalculateRebatableAmountForCommission();
                CalculateCommissionRate();
                //if (CashDiscountAmount > 0)
                //{
                //    txtAmountForComision.Text = (NetEqPrice - CashDiscountAmount).ToString("N");
                //}
                //else
                //{
                //    txtAmountForComision.Text = NetEqPrice.ToString("N");
                //}

            }
            InvoiceAmountCheck();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CalculateTotalAmountInvoiced()
    {
        try
        {
            if (txtCommDate.Text == "")
            {
                decimal NetEqPrice = Utility.ToDecimal(txtNetEqPrice.Text);
                decimal Freight = Utility.ToDecimal(txtFreight.Text);
                decimal Installation = Utility.ToDecimal(txtInstall.Text);
                txtAmountInvoiced.Text = (NetEqPrice + Freight + Installation).ToString("N");
                GetCashDiscountFromAmt();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetCustomerID()
    {
        try
        {
            if (txtCustomer.Text.Trim() != "")
            {
                ObjBOL.Operation = 7;
                ObjBOL.ProjectName = txtCustomer.Text;
                DataTable dt = ObjBLL.GetProjects(ObjBOL).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    HfCustomerID.Value = "-1";
                    txtCustomer.Text = "";
                    Utility.ShowMessage_Error(Page, "No Matching Customer Found !");
                }
                else
                {
                    string CustomerID = dt.Rows[0]["CustomerID"].ToString();
                    if (CustomerID.Trim() != "")
                    {
                        HfCustomerID.Value = CustomerID;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #endregion

    #region Invoice, Commission and Shipping Tab Events

    #region General Information

    protected void txtFreightAndInstallation_TextChanged(object sender, EventArgs e)
    {
        txtFreightAndInstallation_TextChanged();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
    }

    private void txtFreightAndInstallation_TextChanged()
    {
        try
        {
            CalculateTotalAmountInvoiced();
            CalculateRebatableAmountForCommission();
            CalculateCommissionRate();
            InvoiceAmountCheck();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtinvnumber_TextChanged(object sender, EventArgs e)
    {
        try
        {
            EnableDisableShipDate();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtAmountInvoiced_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GetCashDiscountFromAmt();
            InvoiceAmountCheck();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtCashDiscountAmount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GetCashDiscountFromAmt();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtCashDiscountPer_TextChanged(object sender, EventArgs e)
    {
        try
        {
            GetCashDiscountFromPer();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Shipping Info Events

    protected void txtShipDate_TextChanged(object sender, EventArgs e)
    {
        txtShipDate_TextChanged();
    }

    private void txtShipDate_TextChanged()
    {
        try
        {
            if (txtJobId.Text.Trim() != "")
            {
                if (txtShipDate.Text.Trim() != "")
                {
                    DateTime shipdate = Convert.ToDateTime(txtShipDate.Text);
                    shipdate = shipdate.AddDays(7);
                    txtShipToArrive.Text = shipdate.ToString("MM/dd/yyyy");
                    DataSet ds = new DataSet();
                    ObjBOLRel.operation = 1;
                    ObjBOLRel.shipdate = Utility.ConvertDate(txtShipDate.Text);
                    ds = ObjBLLRel.CheckWeeklyCount(ObjBOLRel);
                    Decimal NetAmount = 0;
                    int PCount = 0;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        NetAmount = Utility.ToDecimal(ds.Tables[0].Rows[0]["WTotal"].ToString());
                        PCount = Convert.ToInt32(ds.Tables[0].Rows[0]["ProjectCount"].ToString());
                    }
                    if (NetAmount > 300000 || PCount >= 8)
                    {
                        Utility.ShowMessage_Info(Page, "Total value of the week is $" + Convert.ToDecimal(ds.Tables[0].Rows[0]["WTotal"]).ToString("N") + " \\nAnd number of Projects is " + Convert.ToDecimal(ds.Tables[0].Rows[0]["ProjectCount"]));
                    }
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Receiver Info Events

    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlcountry.SelectedIndex > 0)
            {
                GetState(ddlcountry.SelectedValue);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
                SpecCredit();
            }
            else
            {
                ddlState.Items.Clear();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetState(string Countryid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.ShipToCountry = Countryid;
            ObjBOL.Operation = 4;
            ds = ObjBLL.GetStates(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlState, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #endregion

    #region Web Methods

    #region Consultant Req Details

    public class ConsultantRep
    {
        Int32 _Repid;
        public Int32 Repid
        {
            get { return _Repid; }
            set { _Repid = value; }
        }
        String _FirstName;
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        String _LastName;
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        Int32 _AbbreviationID;
        public Int32 AbbreviationID
        {
            get { return _AbbreviationID; }
            set { _AbbreviationID = value; }
        }
        String _AbbreviationName;
        public String AbbreviationName
        {
            get { return _AbbreviationName; }
            set { _AbbreviationName = value; }
        }
        String _PhoneMail;
        public String PhoneMail
        {
            get { return _PhoneMail; }
            set { _PhoneMail = value; }
        }
        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        String _CellPhone;
        public String CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        String _Status;
        public String Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        String _RepState;
        public String RepState
        {
            get { return _RepState; }
            set { _RepState = value; }
        }
    }

    [WebMethod]
    public static List<ConsultantRep> GetConsultantRepDetails(Int32 Repid)
    {
        List<ConsultantRep> dbConsultantRep = new List<ConsultantRep>();
        try
        {
            DataSet ds = new DataSet();
            ds = Utility.GetConsultantRepPopUp(Repid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ConsultantRep emp = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    emp = new ConsultantRep();
                    emp.FirstName = Convert.ToString(ds.Tables[0].Rows[i]["RepName"]);
                    emp.AbbreviationID = Convert.ToInt32(ds.Tables[0].Rows[i]["AbbreviationID"]);
                    emp.AbbreviationName = Convert.ToString(ds.Tables[0].Rows[i]["AbbreviationName"]);
                    emp.PhoneMail = Convert.ToString(ds.Tables[0].Rows[i]["PhoneMail"]);
                    emp.Phone = Convert.ToString(ds.Tables[0].Rows[i]["Phone"]);
                    emp.CellPhone = Convert.ToString(ds.Tables[0].Rows[i]["CellPhone"]);
                    emp.Fax = Convert.ToString(ds.Tables[0].Rows[i]["Fax"]);
                    emp.Email = Convert.ToString(ds.Tables[0].Rows[i]["Email"]);
                    emp.Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]);
                    emp.RepState = Convert.ToString(ds.Tables[0].Rows[i]["RepState"]);
                    dbConsultantRep.Add(emp);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dbConsultantRep;
    }

    #endregion

    #region Origination Rep Details

    public class OriginationRep
    {
        Int32 _Repid;
        public Int32 Repid
        {
            get { return _Repid; }
            set { _Repid = value; }
        }
        String _FirstName;
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        String _LastName;
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        Int32 _AbbreviationID;
        public Int32 AbbreviationID
        {
            get { return _AbbreviationID; }
            set { _AbbreviationID = value; }
        }
        String _AbbreviationName;
        public String AbbreviationName
        {
            get { return _AbbreviationName; }
            set { _AbbreviationName = value; }
        }
        String _PhoneMail;
        public String PhoneMail
        {
            get { return _PhoneMail; }
            set { _PhoneMail = value; }
        }
        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        String _CellPhone;
        public String CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        String _Status;
        public String Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        String _RepState;
        public String RepState
        {
            get { return _RepState; }
            set { _RepState = value; }
        }
    }

    [WebMethod]
    public static List<OriginationRep> GetOriginationRepDetails(Int32 Repid)
    {
        List<OriginationRep> dbOriginationRep = new List<OriginationRep>();
        try
        {
            DataSet ds = new DataSet();
            ds = Utility.GetOriginationRepPopUp(Repid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                OriginationRep emp = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    emp = new OriginationRep();
                    emp.FirstName = Convert.ToString(ds.Tables[0].Rows[i]["RepName"]);
                    emp.AbbreviationID = Convert.ToInt32(ds.Tables[0].Rows[i]["AbbreviationID"]);
                    emp.AbbreviationName = Convert.ToString(ds.Tables[0].Rows[i]["AbbreviationName"]);
                    emp.PhoneMail = Convert.ToString(ds.Tables[0].Rows[i]["PhoneMail"]);
                    emp.Phone = Convert.ToString(ds.Tables[0].Rows[i]["Phone"]);
                    emp.CellPhone = Convert.ToString(ds.Tables[0].Rows[i]["CellPhone"]);
                    emp.Fax = Convert.ToString(ds.Tables[0].Rows[i]["Fax"]);
                    emp.Email = Convert.ToString(ds.Tables[0].Rows[i]["Email"]);
                    emp.Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]);
                    emp.RepState = Convert.ToString(ds.Tables[0].Rows[i]["RepState"]);
                    dbOriginationRep.Add(emp);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dbOriginationRep;
    }

    #endregion

    #region Destination Rep Details

    public class DestinationRep
    {
        Int32 _Repid;
        public Int32 Repid
        {
            get { return _Repid; }
            set { _Repid = value; }
        }
        String _FirstName;
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        String _LastName;
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        Int32 _AbbreviationID;
        public Int32 AbbreviationID
        {
            get { return _AbbreviationID; }
            set { _AbbreviationID = value; }
        }
        String _AbbreviationName;
        public String AbbreviationName
        {
            get { return _AbbreviationName; }
            set { _AbbreviationName = value; }
        }
        String _PhoneMail;
        public String PhoneMail
        {
            get { return _PhoneMail; }
            set { _PhoneMail = value; }
        }
        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        String _CellPhone;
        public String CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        String _Status;
        public String Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        String _RepState;
        public String RepState
        {
            get { return _RepState; }
            set { _RepState = value; }
        }
    }

    [WebMethod]
    public static List<DestinationRep> GetDestinationRepDetails(Int32 Repid)
    {
        List<DestinationRep> dbDestinationRep = new List<DestinationRep>();
        try
        {
            DataSet ds = new DataSet();
            ds = Utility.GetDestinationRepPopUp(Repid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DestinationRep emp = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    emp = new DestinationRep();
                    emp.FirstName = Convert.ToString(ds.Tables[0].Rows[i]["RepName"]);
                    emp.AbbreviationID = Convert.ToInt32(ds.Tables[0].Rows[i]["AbbreviationID"]);
                    emp.AbbreviationName = Convert.ToString(ds.Tables[0].Rows[i]["AbbreviationName"]);
                    emp.PhoneMail = Convert.ToString(ds.Tables[0].Rows[i]["PhoneMail"]);
                    emp.Phone = Convert.ToString(ds.Tables[0].Rows[i]["Phone"]);
                    emp.CellPhone = Convert.ToString(ds.Tables[0].Rows[i]["CellPhone"]);
                    emp.Fax = Convert.ToString(ds.Tables[0].Rows[i]["Fax"]);
                    emp.Email = Convert.ToString(ds.Tables[0].Rows[i]["Email"]);
                    emp.Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]);
                    emp.RepState = Convert.ToString(ds.Tables[0].Rows[i]["RepState"]);
                    dbDestinationRep.Add(emp);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dbDestinationRep;
    }

    #endregion

    #region Dealer Details

    public class Dealer
    {
        Int32 _DealerID;
        public Int32 DealerID
        {
            get { return _DealerID; }
            set { _DealerID = value; }
        }
        String _FederalID;
        public String FederalID
        {
            get { return _FederalID; }
            set { _FederalID = value; }
        }
        String _CompanyName;
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
        String _GroupName;
        public String GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
        String _StreetAddress;
        public String StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }
        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
        String _Country;
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
        String _TollFree;
        public String TollFree
        {
            get { return _TollFree; }
            set { _TollFree = value; }
        }
        String _TollFax;
        public String TollFax
        {
            get { return _TollFax; }
            set { _TollFax = value; }
        }
        String _DealerPhone;
        public String DealerPhone
        {
            get { return _DealerPhone; }
            set { _DealerPhone = value; }
        }
        String _DealerFax;
        public String DealerFax
        {
            get { return _DealerFax; }
            set { _DealerFax = value; }
        }
        String _RepName;
        public String RepName
        {
            get { return _RepName; }
            set { _RepName = value; }
        }
        String _DealerState;
        public String DealerState
        {
            get { return _DealerState; }
            set { _DealerState = value; }
        }

    }

    [WebMethod]
    public static List<Dealer> GetDealerDetails(Int32 DealerID)
    {
        List<Dealer> dbDealers = new List<Dealer>();
        try
        {
            DataSet ds = new DataSet();
            ds = Utility.GetDealerDetailPopUp(DealerID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Dealer emp = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    emp = new Dealer();
                    emp.FederalID = Convert.ToString(ds.Tables[0].Rows[i]["FederalID"]);
                    emp.CompanyName = Convert.ToString(ds.Tables[0].Rows[i]["CompanyName"]);
                    emp.GroupName = Convert.ToString(ds.Tables[0].Rows[i]["GroupName"]);
                    emp.StreetAddress = Convert.ToString(ds.Tables[0].Rows[i]["StreetAddress"]);
                    emp.City = Convert.ToString(ds.Tables[0].Rows[i]["City"]);
                    emp.Country = Convert.ToString(ds.Tables[0].Rows[i]["Country"]);
                    emp.TollFree = Convert.ToString(ds.Tables[0].Rows[i]["TollFree"]);
                    emp.TollFax = Convert.ToString(ds.Tables[0].Rows[i]["TollFax"]);
                    emp.DealerPhone = Convert.ToString(ds.Tables[0].Rows[i]["Phone"]);
                    emp.DealerFax = Convert.ToString(ds.Tables[0].Rows[i]["Fax"]);
                    emp.RepName = Convert.ToString(ds.Tables[0].Rows[i]["RepName"]);
                    emp.DealerState = Convert.ToString(ds.Tables[0].Rows[i]["DealerState"]);
                    dbDealers.Add(emp);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dbDealers;
    }

    #endregion

    #region Consultant Details

    public class Consultant
    {
        Int32 _ConsultantID;
        public Int32 ConsultantID
        {
            get { return _ConsultantID; }
            set { _ConsultantID = value; }
        }
        String _CompanyName;
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
        String _StreetAdd;
        public String StreetAdd
        {
            get { return _StreetAdd; }
            set { _StreetAdd = value; }
        }
        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
        String _Country;
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        String _TollFree;
        public String TollFree
        {
            get { return _TollFree; }
            set { _TollFree = value; }
        }
        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        String _TollFax;
        public String TollFax
        {
            get { return _TollFax; }
            set { _TollFax = value; }
        }
        String _RepName;
        public String RepName
        {
            get { return _RepName; }
            set { _RepName = value; }
        }
        String _ConsultantState;
        public String ConsultantState
        {
            get { return _ConsultantState; }
            set { _ConsultantState = value; }
        }
    }

    [WebMethod]
    public static List<Consultant> GetConsultantDetails(Int32 ConsultantID)
    {
        List<Consultant> dbConsulatnt = new List<Consultant>();
        try
        {
            DataSet ds = new DataSet();
            ds = Utility.GetConsultantPopUp(ConsultantID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Consultant emp = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    emp = new Consultant();
                    emp.CompanyName = Convert.ToString(ds.Tables[0].Rows[i]["CompanyName"]);
                    emp.StreetAdd = Convert.ToString(ds.Tables[0].Rows[i]["StreetAdd"]);
                    emp.City = Convert.ToString(ds.Tables[0].Rows[i]["City"]);
                    emp.Country = Convert.ToString(ds.Tables[0].Rows[i]["Country"]);
                    emp.Phone = Convert.ToString(ds.Tables[0].Rows[i]["Phone"]);
                    emp.TollFree = Convert.ToString(ds.Tables[0].Rows[i]["TollFree"]);
                    emp.Fax = Convert.ToString(ds.Tables[0].Rows[i]["Fax"]);
                    emp.TollFax = Convert.ToString(ds.Tables[0].Rows[i]["TollFax"]);
                    emp.RepName = Convert.ToString(ds.Tables[0].Rows[i]["RepName"]);
                    emp.ConsultantState = Convert.ToString(ds.Tables[0].Rows[i]["ConsultantState"]);
                    dbConsulatnt.Add(emp);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dbConsulatnt;
    }

    #endregion

    #endregion

    #region Resets

    private void CancelExclusiveRefocus(string JNumber)
    {
        try
        {
            if (string.IsNullOrEmpty(JNumber) || JNumber.Length < 4)
                return;

            JNumber = JNumber.Substring(0, 4);
            txtSearchPNum.Text = JNumber;

            // Call the JavaScript function to handle focus, cursor position, and autocomplete
            string script = @"refocusAndTriggerAutocomplete('{0}', '{1}');";

            // Register the JavaScript code to call our function
            ScriptManager.RegisterStartupScript(this, this.GetType(), "TriggerAutoComplete", string.Format(script, txtSearchPNum.ClientID, JNumber), true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Reset()
    {
        try
        {
            EnableDisableControlRecursively(giGeneralInformation, true);
            txtProjectCommNotes.Text = string.Empty;
            if (ddlprojectstatus.Items.Count > 0)
            {
                ddlprojectstatus.SelectedIndex = 0;
            }

            if (ddlProjectManager.Items.Count > 0)
            {
                ddlProjectManager.SelectedIndex = 0;
            }

            txtJobId.Text = string.Empty;
            txtPNumber.Text = string.Empty;
            if (ddlOASentTo.Items.Count > 0)
            {
                ddlOASentTo.SelectedIndex = 0;
            }

            txtJobOrderDate.Text = string.Empty;
            txtOrderAckDate.Text = string.Empty;
            txtOADispatch.Text = string.Empty;
            HfCustomerID.Value = "-1";
            HfJObID.Value = "-1";
            txtCustomer.Text = string.Empty;
            txtPONumber.Text = string.Empty;
            if (ddlConsultantRep.Items.Count > 0)
            {
                ddlConsultantRep.SelectedIndex = 0;
            }

            if (ddlOrgRep.Items.Count > 0)
            {
                ddlOrgRep.SelectedIndex = 0;
            }

            if (ddlDesRep.Items.Count > 0)
            {
                ddlDesRep.SelectedIndex = 0;
            }

            if (ddlDealer.Items.Count > 0)
            {
                ddlDealer.SelectedIndex = 0;
            }

            if (ddlConsultant.Items.Count > 0)
            {
                ddlConsultant.SelectedIndex = 0;
            }

            if (ddlSalesSource.Items.Count > 0)
            {
                ddlSalesSource.SelectedIndex = 0;
            }

            txtPoRecDate.Text = string.Empty;
            rdbOrderFor.ClearSelection();
            txtQuote.Text = string.Empty;
            rdbSpecCredit.ClearSelection();
            if (ddlSpecCredit.Items.Count > 0)
            {
                ddlSpecCredit.SelectedIndex = 0;
            }
            txtSpecAmount.Text = string.Empty;
            txtSpecConsultantRep.Text = string.Empty;
            txtSpecConsultant.Text = string.Empty;
            txtSpecCheque.Text = string.Empty;
            txtSpecPaid.Text = string.Empty;
            txtReleased.Text = string.Empty;
            txtDateBuiltDrgsSent.Text = string.Empty;
            txtEstimatedCom.Text = string.Empty;
            txtActualCom.Text = string.Empty;
            txtTestRun.Text = string.Empty;
            if (ddlPurchasedItemsCAD.Items.Count > 0)
            {
                ddlPurchasedItemsCAD.SelectedIndex = 0;
            }

            if (ddlInstallationBy.Items.Count > 0)
            {
                ddlInstallationBy.SelectedIndex = 0;
            }

            if (ddlInstallationCommitment.Items.Count > 0)
            {
                ddlInstallationCommitment.SelectedIndex = 0;
            }

            if (ddlInstallationPriority.Items.Count > 0)
            {
                ddlInstallationPriority.SelectedIndex = 0;
            }

            if (ddlInstallerA.Items.Count > 0)
            {
                ddlInstallerA.SelectedIndex = 0;
            }

            if (ddlInstallerB.Items.Count > 0)
            {
                ddlInstallerB.SelectedIndex = 0;
            }

            if (ddlInstallerC.Items.Count > 0)
            {
                ddlInstallerC.SelectedIndex = 0;
            }

            txtInstallationStart.Text = string.Empty;
            txtInstallationEnd.Text = string.Empty;
            txtDemo.Text = string.Empty;
            txtWarrantyStart.Text = string.Empty;
            txtWarrantyEnd.Text = string.Empty;
            txtFollowUp.Text = string.Empty;
            txtCarePack.Text = string.Empty;
            txtManualsDisp.Text = string.Empty;
            txtTestRemarks.Text = string.Empty;
            rdbPM.SelectedValue = "0";
            // Second Tab
            if (ddlCurrency.Items.Count > 0)
            {
                ddlCurrency.SelectedIndex = 0;
            }

            txtEqPrice.Text = string.Empty;
            txtEqDiscount.Text = string.Empty;
            txtEqDisAmount.Text = string.Empty;
            txtCashDiscountAmount.Text = string.Empty;
            txtCashDiscountPer.Text = string.Empty;
            txtTAmountRec.Text = string.Empty;
            txtAmountForComision.Text = string.Empty;
            txtNetEqPrice.Text = string.Empty;
            txtAmountInvoiced.Text = String.Empty;
            txtFreight.Text = string.Empty;
            txtInstall.Text = string.Empty;
            txtExWarranty.Text = string.Empty;
            txtNetAmount.Text = string.Empty;
            txtHST.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            txtinvnumber.Text = string.Empty;
            txtInvodate.Text = string.Empty;
            txtDateReceived.Text = string.Empty;
            if (ddlFOB.Items.Count > 0)
            {
                ddlFOB.SelectedIndex = 0;
            }

            if (ddlTerm.Items.Count > 0)
            {
                ddlTerm.SelectedIndex = 0;
            }

            if (ddlRate.Items.Count > 0)
            {
                ddlRate.SelectedIndex = 0;
            }

            //todo
            txtCommAmount.Text = string.Empty;
            txtNetRateCommission.Text = string.Empty;
            txtCommCheque.Text = string.Empty;
            txtCommDate.Text = string.Empty;
            //todo
            if (ddlShipper.Items.Count > 0)
            {
                ddlShipper.SelectedIndex = 0;
            }

            if (ddlShippingComit.Items.Count > 0)
            {
                ddlShippingComit.SelectedIndex = 0;
            }

            if (ddlShippingStatus.Items.Count > 0)
            {
                ddlShippingStatus.SelectedIndex = 0;
            }

            txtShipDate.Text = string.Empty;
            txtShipDate.Enabled = false;
            txtShipToArrive.Text = string.Empty;
            txtArrivalDate.Text = string.Empty;
            txtCompany.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            if (ddlState.Items.Count > 0)
            {
                ddlState.SelectedIndex = 0;
            }

            if (ddlcountry.Items.Count > 0)
            {
                ddlcountry.SelectedIndex = 0;
            }

            txtZip.Text = string.Empty;
            if (ddlShipperContactName.Items.Count > 0)
            {
                ddlShipperContactName.Items.Clear();
            }
            txtShipperPhone.Text = string.Empty;
            txtShipperEmail.Text = string.Empty;
            txtShipperTrackingNo.Text = string.Empty;
            txtShipperPickupFromShop.Text = string.Empty;
            txtShipperNotes.Text = string.Empty;
            txtActualShippingCost.Text = string.Empty;
            rdbShippedVia.SelectedValue = null;
            txtAdditionalCharges.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            //todo
            Session["PNumber"] = null;
            btnSave.Text = "Save";
            btnNew.Enabled = true;
            Session["JobID"] = null;
            txtSearchPName.Text = "";
            txtSearchPNum.Text = "";
            lblDesRep.Text = String.Empty;
            lblConsultantRep.Text = String.Empty;
            lblOrgRep.Text = String.Empty;
            lblPM.Text = String.Empty;
            lblConsultant.Text = String.Empty;
            lblDesRep.Visible = false;
            lblConsultantRep.Visible = false;
            lblOrgRep.Visible = false;
            lblPM.Visible = false;
            lblConsultant.Visible = false;
            if (ddlProjectReviewedBy.Items.Count > 0)
            {
                ddlProjectReviewedBy.SelectedIndex = 0;
            }
            txtProjectReviewedDate.Text = String.Empty;
            txtReasonForPriceUpdate.Text = string.Empty;
            chkUpdatedOnVisual.Checked = false;
            chkConfirmedFromGover.Checked = false;
            chkInvoiceNotRequired.Checked = false;
            CheckPaymentPermissions();
            EnableDisablePaymentLogFields();
            ResetShippingFormControls();
            ResetModels();
            ResetCertReq();
            gvShipDate.DataSource = string.Empty;
            gvShipDate.DataBind();
            InstallationCommitment();
            //hfCheckShipDateChange.Value = "";
            lblMessage.Text = string.Empty;
            lblMessage.Visible = false;
            //Utility.ToastrClear(Page);
            txtStartupDate.Text = string.Empty;
            txtCommissioningDate.Text = string.Empty;
            ddlShippingRequirements.SelectedIndex = 0;
            txtShippingRequirementDetails.Text = string.Empty;
            txtScopeOfWork.Text = string.Empty;
            txtScopeDate.Text = string.Empty;
            chkMannedFireWatch.Checked = false;
            txtMannedFireWatch.Text = string.Empty;
            chkHotWorkPermit.Checked = false;
            txtHotWorkPermit.Text = string.Empty;
            chkCanTechAccess.Checked = false;
            txtCanTechAccess.Text = string.Empty;
            txtCertReq.Text = string.Empty;
            rdbOrientTraining.SelectedValue = "0";
            txtOrientationTraining.Text = string.Empty;
            txtPlumbingElectricalSupply.Text = string.Empty;
            if (ddlSalesOpportunity.Items.Count > 0)
            {
                ddlSalesOpportunity.SelectedIndex = 0;
            }

            if (ddlSalesOpportunityStatus.Items.Count > 0)
            {
                ddlSalesOpportunityStatus.SelectedIndex = 0;
            }
            txtExpectedSalesDate.Text = string.Empty;
            chkOsha.Checked = false;
            txtOsha.Text = string.Empty;
            chkStateCertificate.Checked = false;
            txtStateCertificate.Text = string.Empty;
            chkDrugTestingCertificate.Checked = false;
            txtDrugTestingCertificate.Text = string.Empty;
            chkWHMIS.Checked = false;
            txtWHMIS.Text = string.Empty;
            chkFallProtection.Checked = false;
            txtFallProtection.Text = string.Empty;
            chkMedicalCertificate.Checked = false;
            txtMedicalCertificate.Text = string.Empty;
            chkInsuranceCertificate.Checked = false;
            txtInsuranceCertificate.Text = string.Empty;
            ClearShipperContactName();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetModels()
    {
        try
        {
            for (int i = 0; i < chkTechnician.Items.Count; i++)
            {
                chkTechnician.Items[i].Selected = false;
            }
            lblSelectedTechnician.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetCertReq()
    {
        try
        {
            for (int i = 0; i < chkCertReq.Items.Count; i++)
            {
                chkCertReq.Items[i].Selected = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public void ResetShippingFormControls()
    {
        try
        {
            ddlDeliveryPref.SelectedIndex = 0;
            if (ddlCustomerSiteContact.Items.Count > 0)
            {
                ddlCustomerSiteContact.Items.Clear();
            }
            if (ddlDealerProjManager.Items.Count > 0)
            {
                ddlDealerProjManager.Items.Clear();
            }
            btnShipping.Enabled = false;
            btnShipping.Text = "Generate Shipping Form";
            ddlWorkingHours.SelectedIndex = 0;
            txtMontoFriTime.Text = "";
            txtSatSunTime.Text = "";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    protected void btnProspecting_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "~/PMModule/PreventativeMaintenanceCallLogs.aspx";
            if (txtJobId.Text.Trim() != "")
            {
                link += "?jobId=" + txtJobId.Text.Trim();
            }
            Response.Redirect(link);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnServiceAgree_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "~/CCT/frmPreventiveMaintenance.aspx";
            if (txtJobId.Text.Trim() != "")
            {
                link += "?jobId=" + txtJobId.Text.Trim();
            }
            Response.Redirect(link);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillSiteContactandDealerProjManager(string JobID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 13;
            ObjBOL.JobID = JobID;
            ds = ObjBLL.GetProjects(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCustomerSiteContact, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                ddlDealerProjManager.ClearSelection();  // avoid invalid selected value
                ddlDealerProjManager.Items.Clear();     // clear old items
                Utility.BindDropDownList(ddlDealerProjManager, ds.Tables[1]);
                
                if (ddlDealerProjManager.Items.Count > 0)
                {
                    ddlDealerProjManager.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex, JobID);
        }
    }

    protected void ddlInstallationBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
            InstallationCommitment();
            if (ddlInstallationBy.SelectedIndex > 0)
            {
                ddInstalledBy(ddlInstallationBy.SelectedValue);
            }
            else
            {
                btnShipping.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddInstalledBy(string Installedby)
    {
        try
        {
            if (txtJobId.Text != "")
            {
                if (Installedby == "1")
                {
                    btnShipping.Enabled = true;
                    btnShipping.Text = "Generate Shipping & Assembly Form";
                }
                else if (Installedby == "2" || Installedby == "4")
                {
                    btnShipping.Enabled = true;
                    btnShipping.Text = "Generate Shipping Form";
                }
                else if (Installedby == "3")
                {
                    btnShipping.Enabled = true;
                    btnShipping.Text = "Generate Shipping & Assembly Supervision Form";
                }
                else if (Installedby == "5")
                {
                    btnShipping.Enabled = false;
                    btnShipping.Text = "Generate Shipping Form";
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please Enter Job ID !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable GetOrderBelongsTo()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[Get_ShippingForm] 2,'" + HfJObID.Value + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }


    protected void btnShipping_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            DataTable dtOrderBelongsTo = (DataTable)GetOrderBelongsTo();
            string txtHeader = String.Empty;
            string fullPath = String.Empty;
            string OrderBelongsTo = String.Empty;
            if (dtOrderBelongsTo.Rows.Count > 0)
            {
                OrderBelongsTo = dtOrderBelongsTo.Rows[0]["OrderBelongsTo"].ToString();
            }
            if (OrderBelongsTo == "1")
            {
                fullPath = Server.MapPath("~/images/logo.png");
            }
            else
            {
                fullPath = Server.MapPath("~/images/Tlogo.png");
            }

            clscon.Return_DT(dt, "EXEC [dbo].[Get_ShippingForm] 1,'" + HfJObID.Value + "','" + fullPath + "'");
            if (ddlInstallationBy.SelectedValue == "1")
            {
                rprt.Load(Server.MapPath("~/Reports/rptShippingandAssemblyForm.rpt"));
                txtHeader = "Shipping & Assembly Form";
            }
            else if (ddlInstallationBy.SelectedValue == "3")
            {
                rprt.Load(Server.MapPath("~/Reports/rptShippingandAssemblySupervisionForm.rpt"));
                txtHeader = "Shipping & Assembly Supervision Form";
            }
            else if (ddlInstallationBy.SelectedValue == "2" || ddlInstallationBy.SelectedValue == "4")
            {
                rprt.Load(Server.MapPath("~/Reports/rptShippingForm.rpt"));
                txtHeader = "Shipping Form";
            }
            if (dt.Rows.Count > 0)
            {
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtHeader);
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

    //private void AssignInitialValues()
    //{
    //    try
    //    {
    //        if (txtProjectReviewedDate.Text.Trim() != "")
    //        {
    //            DataRow d = (DataRow)Session["JobInfo"];
    //            if (ddlCurrency.Items.FindByValue(Convert.ToString(d["CurrencyID"])) != null)
    //            {
    //                ddlCurrency.SelectedValue = Convert.ToString(d["CurrencyID"]);
    //            }

    //            txtEqPrice.Text = Convert.ToDecimal(d["Price"]).ToString("N");
    //            txtEqDiscount.Text = Convert.ToDecimal(d["EqDiscount"]).ToString("N");
    //            txtEqDisAmount.Text = Convert.ToDecimal(d["EqDisAmount"]).ToString("N");
    //            txtNetEqPrice.Text = Convert.ToDecimal(d["NetEqPrice"]).ToString("N");
    //            txtFreight.Text = Convert.ToDecimal(d["Freight"]).ToString("N");
    //            txtInstall.Text = Convert.ToDecimal(d["Installation"]).ToString("N");
    //            txtExWarranty.Text = Convert.ToDecimal(d["ExWarrantyPrice"]).ToString("N");
    //            txtNetAmount.Text = CalculateNetAmount().ToString("N");
    //            txtAmountInvoiced.Text = Convert.ToDecimal(d["TotalAmtInv"]).ToString("N");
    //            txtHST.Text = Convert.ToDecimal(d["GST"]).ToString("N");
    //            txtTotalAmount.Text = Convert.ToDecimal(d["CashAmtRec"]).ToString("N");
    //            txtinvnumber.Text = Convert.ToString(d["InvoiceNumber"]);
    //            txtInvodate.Text = cls.Converter(Convert.ToString(d["DateInvoiceSent"]));
    //            txtDateReceived.Text = cls.Converter(Convert.ToString(d["DatePaymentReceived"]));
    //            if (ddlFOB.Items.FindByValue(Convert.ToString(d["fob"])) != null)
    //            {
    //                ddlFOB.Text = Convert.ToString(d["fob"]);
    //            }

    //            if (ddlTerm.Items.FindByValue(Convert.ToString(d["term"])) != null)
    //            {
    //                ddlTerm.Text = Convert.ToString(d["term"]);
    //            }

    //            if (d["ProjectReviewedBy"].ToString() != "")
    //            {
    //                if (ddlProjectReviewedBy.Items.FindByValue(d["ProjectReviewedBy"].ToString()) != null)
    //                {
    //                    ddlProjectReviewedBy.SelectedValue = d["ProjectReviewedBy"].ToString();
    //                }
    //            }

    //            if (d["ProjectReviewedDate"].ToString() != "")
    //            {
    //                if (d["ProjectReviewedDate"].ToString() != null)
    //                {
    //                    txtProjectReviewedDate.Text = d["ProjectReviewedDate"].ToString();
    //                }
    //            }

    //            txtCashDiscountAmount.Text = Convert.ToDecimal(d["CashDisAmt"]).ToString("N");
    //            decimal cashper = Convert.ToDecimal(d["CashDisPer"]);
    //            txtCashDiscountPer.Text = cashper.ToString("N");
    //            if (cashper <= 0)
    //            {
    //                //txtAmountForComision.Text = Convert.ToDecimal(d["NetEqPrice"]).ToString("N");
    //                txtTAmountRec.Text = txtTotalAmount.Text;
    //            }
    //            else
    //            {
    //                txtTAmountRec.Text = Convert.ToDecimal(d["CashAmtRec"]).ToString("N");
    //            }
    //            txtAmountForComision.Text = Convert.ToDecimal(d["AmountForComission"]).ToString("N");

    //            if (ddlRate.Items.FindByValue(Convert.ToString(d["CommissionType"])) != null)
    //            {
    //                ddlRate.SelectedValue = Convert.ToString(d["CommissionType"]);
    //            }

    //            txtCommAmount.Text = Convert.ToDecimal(CalculateCommissionMain()).ToString("N");
    //            txtNetRateCommission.Text = Convert.ToDecimal(d["NetCommissionRate"]).ToString("N");
    //            txtCommCheque.Text = Convert.ToString(d["KflexCheckNumber"]);
    //            txtCommDate.Text = cls.Converter(Convert.ToString(d["DateCommissionPaid"]));
    //            txtProjectCommNotes.Text = Convert.ToString(d["CommissionText"]);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}

    protected void txtOrderAckDate_TextChanged(object sender, EventArgs e)
    {
        EnableDisablePaymentLogFields();
    }

    private void InvoiceAmountCheck()
    {
        try
        {
            decimal correctAmount = Utility.ToDecimal(txtNetEqPrice.Text) + Utility.ToDecimal(txtFreight.Text) + Utility.ToDecimal(txtInstall.Text);
            decimal givenAmount = Utility.ToDecimal(txtAmountInvoiced.Text);
            if (correctAmount != givenAmount)
            {
                var CurrentUser = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
                var PermissionsGranted = new List<string> { "66", "263" };
                if (PermissionsGranted.Contains(CurrentUser))
                {
                    //Utility.ToastrClear(Page);
                    Utility.ShowMessage_Error_SingleNotification(Page, " [Total Amount Invoiced] should be equal to [NetEqPrice + Freight + Installation]");
                }
            }
            //else
            //{
            //    Utility.ToastrClear(Page);
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void InstallationCommitment()
    {
        try
        {
            if (ddlInstallationBy.SelectedValue == "1" || ddlInstallationBy.SelectedValue == "3")
            {
                //divInstallationCommitment.Visible = true;
                //divTechnician.Visible = true;
                ddlInstallationCommitment.Enabled = true;
                chkTechnician.Enabled = true;
                btnTechnician.Enabled = true;
            }
            else
            {
                //divInstallationCommitment.Visible = false;
                //divTechnician.Visible = false;
                ddlInstallationCommitment.Enabled = false;
                chkTechnician.Enabled = false;
                btnTechnician.Enabled = false;
                if (ddlInstallationCommitment.Items.Count > 0)
                {
                    ddlInstallationCommitment.SelectedIndex = 0;
                }
                ResetModels();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShipDate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (!Utility.IsAuthorized())
            {
                return;
            }

            if (txtInvodate.Text.Trim().Length > 0)
            {
                Utility.ShowMessage_Error(Page, "Invoice date entered, cannot change Ship Date !!");
                return;
            }

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
            int ID = Convert.ToInt32(gvShipDate.DataKeys[e.RowIndex].Values[0]);
            ObjBOL.Operation = 18;
            ObjBOL.ProjectReviewedBy = ID;
            ObjBOL.UserID = Utility.GetCurrentUser();
            string returnStatus = ObjBLL.SaveProject(ObjBOL).Trim();
            if (returnStatus.Length > 0)
            {
                if (returnStatus == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "Last Ship Date entry cannot be deleted !!");
                    return;
                }

                if (returnStatus == "ER02")
                {
                    Utility.ShowMessage_Error(Page, "Not Authorized to delete Ship date !!");
                    return;
                }

                if (returnStatus != "E")
                {
                    Utility.MaintainLogsSpecial("FrmProjects.aspx", "Delete-ShipDate", HfJObID.Value);
                    Utility.ShowMessage_Success(Page, "Ship Date deleted successfully !!");
                    txtShipDate.Text = returnStatus;
                    txtShipDate_TextChanged();
                    ShipppingCommitShipDate();
                    //BindShipDateGrid();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShipDate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
            if (e.CommandName == "Insert")
            {
                if (!Utility.IsAuthorized())
                {
                    return;
                }

                if (txtInvodate.Text.Trim().Length > 0)
                {
                    Utility.ShowMessage_Error(Page, "Invoice date entered, cannot change Ship Date !!");
                    return;
                }

                if (txtSearchPNum.Text == "")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Proposal No. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Select Job #. !");
                    txtSearchPNum.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
                    return;
                }

                if (txtSearchPName.Text == "")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Proposal Name. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Select Project Name. !");
                    txtSearchPName.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
                    return;
                }
                string msg = "";
                TextBox txtShipDate_Footer = gvShipDate.FooterRow.FindControl("txtShipDate_Footer") as TextBox;
                DropDownList ddlDepartment_Footer = gvShipDate.FooterRow.FindControl("ddlDepartment_Footer") as DropDownList;
                TextBox txtComments_Footer = gvShipDate.FooterRow.FindControl("txtComments_Footer") as TextBox;

                if (txtShipDate_Footer.Text.Trim() == "")
                {
                    Utility.ShowMessage_Error(Page, "Please enter Ship Date !");
                    txtShipDate_Footer.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
                    return;
                }

                //if (ddlDepartment_Footer.SelectedIndex <= 0)
                //{
                //    Utility.ShowMessage_Error(Page, "Please select Reason for delay !");
                //    ddlDepartment_Footer.Focus();
                //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                //    return;
                //}

                //if (txtComments_Footer.Text.Trim() == "")
                //{
                //    Utility.ShowMessage_Error(Page, "Please enter Comments !");
                //    txtComments_Footer.Focus();
                //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetICSCSS()", true);
                //    return;
                //}

                ObjBOL.Operation = 16;
                ObjBOL.JobID = HfJObID.Value;
                ObjBOL.ShipDate = Utility.ConvertDate(txtShipDate_Footer.Text);
                ObjBOL.ProjectTechnician = txtComments_Footer.Text;
                ObjBOL.ProjectReviewedBy = Int32.Parse(ddlDepartment_Footer.SelectedValue);
                ObjBOL.UserID = Utility.GetCurrentUser();
                string returnStatus = ObjBLL.SaveProject(ObjBOL).Trim();
                if (returnStatus.Length > 0)
                {
                    if (returnStatus == "ER02")
                    {
                        Utility.ShowMessage_Error(Page, "Not Authorized to change Ship date !!");
                        return;
                    }

                    if (returnStatus != "E")
                    {
                        Utility.MaintainLogsSpecial("FrmProjects.aspx", "Save-ShipDate", HfJObID.Value);
                        Utility.ShowMessage_Success(Page, "Ship Date added successfully !!");
                        txtShipDate.Text = returnStatus;
                        //hfCheckShipDateChange.Value = "1";
                        txtShipDate_TextChanged();
                        ShipppingCommitShipDate();
                        //BindShipDateGrid();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindShipDateGrid()
    {
        try
        {
            if (ddlShippingComit.SelectedValue == "F")
            {

                ObjBOL.Operation = 17;
                ObjBOL.JobID = HfJObID.Value;
                DataSet ds = ObjBLL.GetProjects(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvShipDate.DataSource = ds.Tables[0];
                    gvShipDate.DataBind();
                }
                else
                {
                    gvShipDate.DataSource = EmptyDT();
                    gvShipDate.DataBind();
                    gvShipDate.Rows[0].Visible = false;
                }
                DropDownList ddlDepartment_Footer = (DropDownList)gvShipDate.FooterRow.FindControl("ddlDepartment_Footer");
                Utility.BindDropDownList(ddlDepartment_Footer, (DataTable)ViewState["Department_Footer"]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckRegionForReps()
    {
        try
        {
            lblMessage.Text = string.Empty;
            lblMessage.Visible = false;
            ObjBOL.Operation = 19;
            ObjBOL.JobID = HfJObID.Value;
            string returnStatus = ObjBLL.GetProjectStatus(ObjBOL).Trim();
            if (returnStatus.Length > 0)
            {
                if (returnStatus == "S")
                {
                    //Utility.ShowMessage_Error_SingleNotification(Page, "CONSULTANT, ORIGIN and DESTINATION Reps are from different Regions !!");
                    lblMessage.Text = "CONSULTANT, ORIGIN and DESTINATION Reps are from different Regions !!";
                    lblMessage.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public void TrackStatusData(string JobNo, string UpdatedShipDate)
    {
        try
        {
            string Do_Not_Reply = "[Please do not reply to this message. Replies to this message are routed to an unmonitored mailbox]";
            commonclass1 con = new commonclass1();
            DataSet ds = new DataSet();
            if (JobNo != "" && UpdatedShipDate != "")
            {
                con.Return_DS(ds, "EXEC [Get_JobNotificationsEmailPM_ShipDateChange] '" + JobNo + "','" + UpdatedShipDate + "'");
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Show Email Notification
                    string PM = ds.Tables[0].Rows[0]["ProjectManager"].ToString();
                    string JobID = ds.Tables[0].Rows[0]["JobID"].ToString();
                    string JobName = ds.Tables[0].Rows[0]["ProjectName"].ToString();
                    string ShipDate = ds.Tables[0].Rows[0]["ShipDate"].ToString();
                    string Source = ds.Tables[0].Rows[0]["Source"].ToString();
                    string ContainerDetails = ds.Tables[0].Rows[0]["ContainerDetails"].ToString();
                    SendJobsStatusForPM_Prepare(PM, JobID, JobName, ShipDate, Source, ContainerDetails, Do_Not_Reply);
                    if (JobNo != "" && UpdatedShipDate != "")
                    {
                        Utility.MaintainLogsSpecial("FrmProject.aspx", "EmailSend", JobNo);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public void SendJobsStatusForPM_Prepare(string PM, string JobNo, string JobName, string ShipDate, string Source, string ContainerDetails, string Do_Not_Reply)
    {
        try
        {
            if (Utility.InventoryEmailSwitch())
            {
                string Subject = "Track Jobs Status";
                string Message = string.Empty;
                Message += "<!doctype><html lang='en'><head><meta charset = 'utf-8'><meta name = 'viewport' content = 'width=device-width, initial-scale=1'> ";
                Message += " <title> Track Jobs Status </title></head><body><table cellpadding='0' cellspacing='0' style='border-collapse:collapse;width:100%;font-family:Calibri;font-size:1.15rem'> ";
                Message += " <tr><td><table border='1' cellpadding='8' cellspacing='0' style='border-collapse:collapse;width:100%;max-width:580px;margin:0 auto;border-color:#ddd'> ";
                Message += " <tr><td colspan='2'><h2 style='margin:0;font-size:1.15rem'>" + PM + ",</h2> ";
                Message += " </td ></tr><tr><td colspan='2'><div style = 'width:80px;margin:0 auto'> ";
                Message += " <svg version='1.1' xmlns:xlink='http://www.w3.org/1999/xlink' id = 'Capa_1' enable-background='new 0 0 512 512' viewBox='0 0 512 512' style='width:100%;height:100%;' xmlns='http://www.w3.org/2000/svg'><g><g><g><path d='m369.4 76.49v401.05c0 3.26-.45 6.41-1.3 9.4-4.09 14.46-17.39 25.06-33.16 25.06h-239.78c-19.03 0-34.45-15.43-34.45-34.46v-401.05c0-19.03 15.42-34.46 34.45-34.46h239.78c19.03 0 34.46 15.43 34.46 34.46z' fill = '#a1412b' /><path d = 'm132.73 394.716v60.854c0 17.33 14.04 31.37 31.37 31.37h204c.85-2.99 1.3-6.14 1.3-9.4v-82.824z' fill = '#7f392c' /><path d = 'm334.941 42.034h-239.78c-19.031 0-34.455 15.424-34.455 34.455v401.053c0 19.031 15.424 34.455 34.455 34.455h239.781c19.031 0 34.455-15.424 34.455-34.455v-401.053c-.001-19.031-15.424-34.455-34.456-34.455zm-2.143 433.365h-235.494v-396.767h235.494z' fill= '#db765a' /> ";
                Message += " <path d = 'm369.4 394.72v82.82c0 3.26-.45 6.41-1.3 9.4h-204c-9.8 0-18.56-4.49-24.31-11.54h193.01v-80.68z' fill='#b55434' /><path d = 'm95.161 42.034c-19.029 0-34.455 15.426-34.455 34.455v219.149c0 10.106 8.193 18.299 18.299 18.299 10.106 0 18.299-8.193 18.299-18.299v-217.006h41.798c10.106 0 18.299-8.193 18.299-18.299 0-10.106-8.193-18.299-18.299-18.299z' fill='#f2886b' /><path d = 'm97.304 223.144v-82.649c0-10.106-8.193-18.299-18.299-18.299-10.106 0-18.299 8.193-18.299 18.299v82.649c0 10.106 8.193 18.299 18.299 18.299 10.106 0 18.299-8.193 18.299-18.299z' fill='#f79a7c' /></g><g><path d = 'm289.014 246.714v204.031h-124.915c-17.325 0-31.37-14.045-31.37-31.37v-162.204c0-5.775 4.682-10.457 10.457-10.457z' fill='#d8d4c9' /><path d='m289.01 246.71v204.04h-124.91c-11.88 0-22.22-6.6-27.54-16.34 26.46-35.27 42.13-79.09 42.13-126.57 0-21.26-3.14-41.78-8.99-61.13z' fill='#b5b1a4' /><path d='m195.728 419.376v-408.919c0-5.775 4.682-10.457 10.457-10.457h234.652c5.775 0 10.457 4.682 10.457 10.457v408.919c0 17.325-14.045 31.37-31.37 31.37h-255.565c17.325 0 31.369-14.045 31.369-31.37z' fill='#f1eee0' /><path d='m213.1 252.167c-9.593 0-17.37-7.777-17.37-17.37v-175.393c0-9.593 7.777-17.37 17.37-17.37 9.593 0 17.37 7.777 17.37 17.37v175.392c.001 9.594-7.776 17.371-17.37 17.371z' fill='#f9f8f2' /> ";
                Message += " <path d = 'm451.29 10.46v408.92c0 17.32-14.04 31.37-31.37 31.37h-99.7c62.77-106.75 98.77-231.12 98.77-363.91 0-29.39-1.76-58.37-5.19-86.84h27.04c5.77 0 10.45 4.68 10.45 10.46z' fill='#e8e4d8' /><path d='m195.73 344.78h255.56v21.67h-255.56z' fill='#ffc751' /><path d='m327.904 344.78h-93.578c-5.984 0-10.835 4.851-10.835 10.835 0 5.984 4.851 10.835 10.835 10.835h93.578c5.984 0 10.835-4.851 10.835-10.835 0-5.984-4.851-10.835-10.835-10.835z' fill='#ffe059' /> ";
                Message += " <path d = 'm451.29 10.46v70.63h-255.56v-70.63c0-5.78 4.68-10.46 10.46-10.46h234.65c5.77 0 10.45 4.68 10.45 10.46z' fill='#ffc751' /> ";
                Message += " <path d = 'm451.29 10.46v70.63h-32.32c-.22-27.42-1.96-54.48-5.17-81.09h27.04c5.77 0 10.45 4.68 10.45 10.46z' fill='#ffaf40' /></g></g><g><g> ";
                Message += " <g fill = '#8f8b81'><path d = 'm251.009 132.32h-18.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h18.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /> ";
                Message += " <path d = 'm306.009 160.899h-73.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h73.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /></g></g><g><g> ";

                Message += " <path d = 'm421.837 139.355c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889s5.793-5.194 8.957-7.278z' fill='#ffaf40' /></g></g></g><g><g> ";

                Message += " <g fill = '#8f8b81'><path d='m251.009 208.021h-18.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h18.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /> ";

                Message += " <path d = 'm306.009 236.6h-73.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h73.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /></g></g><g><g> ";

                Message += " <path d = 'm421.837 215.056c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889 2.789-2.769 5.793-5.194 8.957-7.278z' fill='#ffaf40' /></g></g></g><g><g><g> ";
                Message += " <path d = 'm251.009 283.722h-18.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h18.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' fill='#8f8b81' /> ";
                Message += " <path d = 'm306.009 312.301h-73.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h73.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' fill='#8f8b81' /><g fill='#b5b1a4'> ";
                Message += " <path d = 'm259.14 294.383h-16.15c-4.948 0-8.959 4.011-8.959 8.959 0 4.948 4.011 8.959 8.959 8.959h16.149c4.948 0 8.959-4.011 8.959-8.959.001-4.948-4.01-8.959-8.958-8.959z' /> ";
                Message += " <path d = 'm259.14 218.682h-16.15c-4.948 0-8.959 4.011-8.959 8.959 0 4.948 4.011 8.959 8.959 8.959h16.149c4.948 0 8.959-4.011 8.959-8.959.001-4.948-4.01-8.959-8.958-8.959z' /> ";
                Message += " <path d = 'm259.14 142.981h-16.15c-4.948 0-8.959 4.011-8.959 8.959 0 4.948 4.011 8.959 8.959 8.959h16.149c4.948 0 8.959-4.011 8.959-8.959.001-4.948-4.01-8.959-8.958-8.959z' /></g> ";
                Message += " <path d = 'm351.009 418.538h-118.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h118.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' fill='#8f8b81' /> ";
                Message += " <path d = 'm281.558 409.579c0 4.948 4.011 8.959 8.959 8.959h28.472c4.948 0 8.959-4.011 8.959-8.959 0-4.948-4.011-8.959-8.959-8.959h-28.472c-4.948.001-8.959 4.012-8.959 8.959z' fill = '#b5b1a4' /></g></g><g><g> ";
                Message += " <path d = 'm421.837 290.757c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889s5.793-5.194 8.957-7.278z' fill='#229bff' /></g></g><g><g> ";
                Message += " <path d= 'm421.837 410.49c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889s5.793-5.194 8.957-7.278z' fill='#229bff' /></g></g></g> ";
                Message += " <path d = 'm375.049 58.537h-103.076c-5.523 0-10-4.477-10-10v-18.822c0-5.523 4.477-10 10-10h103.076c5.523 0 10 4.477 10 10v18.822c0 5.523-4.477 10-10 10z' fill='#f1eee0' /> ";
                Message += " <path d = 'm451.29 344.78v21.67h-88.71c3.04-7.16 5.95-14.39 8.75-21.67z' fill='#ffaf40' /> ";
                Message += " <path d = 'm230.47 59.4v21.69h-34.74v-21.69c0-9.59 7.78-17.37 17.37-17.37 4.8 0 9.14 1.95 12.28 5.09s5.09 7.48 5.09 12.28z' fill='#ffe059' /></g></svg></div> ";
                Message += " <h1 style ='font-size:1.65rem;margin:.3rem 0 0;color:#000;text-align:center'>Job Status Details</h1></td></tr> ";
                Message += " <tr><td style='width:1%;white-space:nowrap'>Job No</td><td style='font-weight:600;width:99%'>" + JobNo + " </td></tr>";
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'>Job Name </td><td style='font-weight:600;width:99%'> " + JobName + "</td></tr>";
                Message += " <tr><td style='width:1%;white-space:nowrap'> Ship Date </td><td style='font-weight:600;width:99%'>" + ShipDate + "</td></tr> ";
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Source </td><td style='font-weight:600;width:99%' > " + Source + "</td></tr> ";
                Message += " <tr><td style='width:1%;white-space:nowrap'> Container No, ETA & Status </td><td style='font-weight:600;width:99%'>" + ContainerDetails + "</td></tr> ";
                Message += " <tr><td colspan = '2'> Thanks, <br/ > <strong> " + Utility.EmailDisplayName() + " </strong> <br /> ";
                Message += " </td></tr><tr><td colspan='2' style='color:Red'>" + Do_Not_Reply + "</td></tr></table></td></tr></table></body></html> ";
                List<MailAddress> sendToList = new List<MailAddress>();
                List<MailAddress> ccList = new List<MailAddress>();
                HashSet<MailAddress> sendToListAsList = new HashSet<MailAddress>();
                HashSet<MailAddress> ccListAsList = new HashSet<MailAddress>();
                sendToListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "SendToList", Utility.emailDictionaryInventory, "Ruth", 1, "T", "");
                ccListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "ccList", Utility.emailDictionaryInventory, "", 2, "T", "");
                sendToList = sendToListAsList.ToList();
                ccList = ccListAsList.ToList();
                Send_RevisedETAEmail(Message, Subject, sendToList, ccList);
                sendToListAsList.Clear();
                ccListAsList.Clear();
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Send_RevisedETAEmail(String Message, String Subject, List<MailAddress> sendToList, List<MailAddress> ccList)
    {
        try
        {
            if (sendToList.Count > 0)
            {
                MailMessage message = new MailMessage(new MailAddress(Utility.Email(), Utility.EmailDisplayName()), sendToList[0]);
                string filename = string.Empty;

                string mailbody = Message;
                message.Subject = Subject;
                message.Body = mailbody;
                foreach (var sendto in sendToList)
                {
                    if (!message.To.Contains(sendto))
                    {
                        message.To.Add(sendto);
                    }
                }
                foreach (var cc in ccList)
                {
                    if (!message.CC.Contains(cc))
                    {
                        message.CC.Add(cc);
                    }

                }
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                // SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp
                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["Host"], 587);
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromMail"], ConfigurationManager.AppSettings["Password"]);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                client.Send(message);
                Message = string.Empty;
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnTechnician_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
            mdlTechnician.Show();
            if (HfJObID.Value != "-1")
            {
                lblJob.Text = HfJObID.Value;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void chkTechnician_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            mdlTechnician.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlShippingComit_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ShipppingCommitShipDate();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ShipppingCommitShipDate()
    {
        try
        {
            if (ddlShippingComit.SelectedValue != "F")
            {
                gvShipDate.DataSource = string.Empty;
                gvShipDate.DataBind();
                if (txtInvodate.Text.Trim() == "")
                {
                    txtShipDate.Enabled = true;
                }
                else
                {
                    txtShipDate.Enabled = false;
                }
            }
            else
            {
                BindShipDateGrid();
                txtShipDate.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void RunAllCalculationBeforeUpdate()
    {
        txtFreightAndInstallation_TextChanged();
    }

    protected void btnGenerateCommReport_Click(object sender, EventArgs e)
    {
        try
        {
            if (HfJObID.Value != "-1")
            {
                DataTable dt = (DataTable)ReportData();
                rprt.Load(Server.MapPath("~/Reports/rptProjectCommReport.rpt"));
                if (dt.Rows.Count > 0)
                {
                    string headerText = "Project Communication Report ";
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, headerText);
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please Select Job ID !");
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

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            DataTable dtOrderBelongsTo = (DataTable)GetOrderBelongsTo();
            string fullPath = String.Empty;
            string OrderBelongsTo = String.Empty;
            if (dtOrderBelongsTo.Rows.Count > 0)
            {
                OrderBelongsTo = dtOrderBelongsTo.Rows[0]["OrderBelongsTo"].ToString();
            }
            if (OrderBelongsTo == "1")
            {
                fullPath = Server.MapPath("~/images/logo.png");
            }
            else
            {
                fullPath = Server.MapPath("~/images/Tlogo.png");
            }
            clscon.Return_DT(dt, "EXEC [dbo].[Get_ProjectCommReport] '" + HfJObID.Value + "','" + fullPath + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnSalesOpportunityRedirect_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "~/Reports/FrmSalesOpportunity.aspx";
            Response.Redirect(link);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindShipperContactName(string ShipperID)
    {
        try
        {
            ddlShipperContactName.Enabled = true;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 21;
            ObjBOL.ShipperID = Convert.ToInt32(ShipperID);
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlShipperContactName, ds.Tables[0]);
            }
            else
            {
                ClearShipperContactName();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearShipperContactName()
    {
        try
        {
            if (ddlShipperContactName.Items.Count > 0)
            {
                ddlShipperContactName.Items.Clear();
            }
            ddlShipperContactName.Enabled = false;
            ResetShipperContact();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlShipper_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (HfJObID.Value != "-1")
            {
                ClearShipperContactName();
                if (ddlShipper.SelectedIndex > 0)
                {
                    BindShipperContactName(ddlShipper.SelectedValue);
                }
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please Select Job ID !");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    protected void ddlShipperContactName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlShipperContactName.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 22;
                ObjBOL.ContactID = Convert.ToInt32(ddlShipperContactName.SelectedValue);
                ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //EnabledShipperContact();
                    txtShipperPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                    txtShipperEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
                }
            }
            else
            {
                ResetShipperContact();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetSICSS()", true);
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetShipperContact()
    {
        try
        {
            txtShipperPhone.Text = String.Empty;
            txtShipperEmail.Text = String.Empty;
            txtShipperPhone.Enabled = false;
            txtShipperEmail.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnabledShipperContact()
    {
        try
        {
            txtShipperPhone.Enabled = true;
            txtShipperEmail.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}