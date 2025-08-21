using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalesManagement_FrmProjectsEng : System.Web.UI.Page
{
    BOLManageProjects ObjBOL = new BOLManageProjects();
    BLLManageProjectsEng ObjBLL = new BLLManageProjectsEng();
    BOLProposalSearch ObjBOLSearch = new BOLProposalSearch();
    BLLProposalSearch ObjBLLSearch = new BLLProposalSearch();
    BOLINVPartsInfo ObjBOLRel = new BOLINVPartsInfo();
    BLLINVPartsinfo ObjBLLRel = new BLLINVPartsinfo();

    BOLShpDrg ObjBOLShpDrg = new BOLShpDrg();
    BLLShpDrgEng ObjBLLShpDrg = new BLLShpDrgEng();
    BOLModel ObjBOL1 = new BOLModel();
    BLLModel ObjBLL1 = new BLLModel();

    BOLProjectsFabricationAndNestingTasks ObjBOL_FabricationAndNestingTasks = new BOLProjectsFabricationAndNestingTasks();
    BLLProjectsFabricationAndNestingTasks ObjBLL_FabricationAndNestingTasks = new BLLProjectsFabricationAndNestingTasks();

    commonclass1 cls = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    string DynamicFileSize = "";
    string DownLoadFileName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                string strMethodNameNew = "disableTabs(" + GetCountryForUser() + ");";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);
                if (!IsPostBack)
                {
                    btnSave.Enabled = false;
                    ddlPurchasedItems.Enabled = false;
                    DisableExpectedSubmissionDateForChina();
                    ShowHideControls();
                    BindControls();
                    BindModels();
                    if (Request.QueryString["jid"] != null)
                    {
                        var JNumber = Request.QueryString["jid"];
                        FillJnumber(JNumber);
                        GetFilePath(JNumber);
                        SyncTextbox("NUM", JNumber);
                        SyncTextbox("NAME", JNumber);
                        Fill_ModelDetails();
                    }
                    if (Session["JobID"] != null)
                    {
                        var JNumber = Session["JobID"].ToString();
                        FillJnumber(JNumber);
                        GetFilePath(JNumber);
                        SyncTextbox("NUM", JNumber);
                        SyncTextbox("NAME", JNumber);
                        Fill_ModelDetails();
                    }
                    hfCurrentUser.Value = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
                }
                checkCorrectedByPermission();
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableExpectedSubmissionDateForChina()
    {
        try
        {
            string returnStatus = "E";
            ObjBOL.Operation = 15;
            ObjBOL.UserID = Utility.GetCurrentUser();
            returnStatus = ObjBLL.SaveProject(ObjBOL);
            if (returnStatus.Trim() == "S")
            {
                txtExpectedSubmissionDate.Enabled = false;
            }
            else
            {
                txtExpectedSubmissionDate.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetFileSize()
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 10;
            msg = ObjBLL.CheckEmployeeLogin(ObjBOL);
            DynamicFileSize = msg;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private int GetCountryForUser()
    {
        int CountryId = 0;
        try
        {
            ObjBOL.Operation = 9;
            ObjBOL.UserID = Utility.GetCurrentUser();
            string temp = ObjBLL.SaveProject(ObjBOL);
            bool result = false;
            result = Int32.TryParse(temp, out CountryId);
            if (!result)
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return CountryId;
    }

    #region Others

    private void ShowHideControls()
    {
        try
        {
            string CRuser = Convert.ToString(Utility.GetCurrentSession().EmployeeID);
            if (CRuser == "288")
            {
                btnSave.Visible = false;
                btnSearch.Visible = false;
                btnCuspack.Visible = false;
                btnAcknoledgement.Visible = false;
            }
            else
            {
                btnSave.Visible = true;
                btnSearch.Visible = true;
                btnCuspack.Visible = true;
                btnAcknoledgement.Visible = true;
            }

            if (GetCountryForUser() == 13)
            {
                ddlIssued.Enabled = false;
                txtFabReleasedDateChina.Enabled = false;
            }
            else
            {
                ddlIssued.Enabled = true;
                txtFabReleasedDateChina.Enabled = true;
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable EmptyDT()
    {
        DataTable dtEmpty = new DataTable();
        try
        {
            dtEmpty.Columns.Add("sDrgNum", typeof(string));
            dtEmpty.Columns.Add("sDrgJID", typeof(string));
            dtEmpty.Columns.Add("sDrgReqBy", typeof(int));
            dtEmpty.Columns.Add("SDrgsNature", typeof(string));
            dtEmpty.Columns.Add("sDrgReqDateByRCD", typeof(DateTime));
            dtEmpty.Columns.Add("sDrgReqRecInIndia", typeof(DateTime));
            dtEmpty.Columns.Add("sDrgProjEngg", typeof(int));
            dtEmpty.Columns.Add("sDrgSentToCA", typeof(DateTime));
            dtEmpty.Columns.Add("sDrgSentToRCD", typeof(DateTime));
            dtEmpty.Columns.Add("sDrgAppDate", typeof(DateTime));
            dtEmpty.Columns.Add("sDrgComment", typeof(string));
            dtEmpty.Columns.Add("sDrgWantDate", typeof(DateTime));
            dtEmpty.Columns.Add("sDrgPromiseDate", typeof(DateTime));
            dtEmpty.Columns.Add("sDrgExpecApprovalDate", typeof(DateTime));
            dtEmpty.Columns.Add("sNextFolowupDate", typeof(DateTime));
            dtEmpty.Columns.Add("sDateFollowedUp", typeof(DateTime));
            dtEmpty.Columns.Add("sDateReleasedToFab", typeof(DateTime));
            dtEmpty.Columns.Add("sReleasedTo", typeof(Char));
            dtEmpty.Columns.Add("sReleasedToText", typeof(String));
            dtEmpty.Columns.Add("sReleasedToFabDate", typeof(DateTime));
            dtEmpty.Columns.Add("sReleasedToShopDate", typeof(DateTime));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    private Boolean ValidationCheck()
    {
        try
        {
            if (HfJObID.Value == "-1" || HfJObID.Value == "")
            {
                Utility.ShowMessage_Error(Page, "Please Select Project Number. !");
                return false;
            }

            if (ddlProductionStatus.SelectedValue == "P")
            {
                if (txtProductionRemarks.Text.Trim() == "")
                {
                    Utility.ShowMessage_Error(Page, "Production Remarks are required for Partially Completed Production Status !");
                    string strMethodNameNew = "SetCSSFabChina();";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);
                    txtProductionRemarks.Focus();
                    return false;
                }
            }
            string returnStatus = "E";
            ObjBOL.Operation = 15;
            ObjBOL.UserID = Utility.GetCurrentUser();
            returnStatus = ObjBLL.SaveProject(ObjBOL);
            if (ddlFabStatus.SelectedIndex == -1)
            {
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                string strMethodNameNew = "SetCSSFabChina();";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);
                ddlFabStatus.Focus();
                return false;
            }
            if (ddlIssued.SelectedIndex > 0 && ddlIssued.SelectedValue != "D" && txtShipDateFromChina.Text == "" && returnStatus.Trim() == "S")
            {
                Utility.ShowMessage_Error(Page, "Please enter Ship Date From China. !");
                string strMethodNameNew = "SetCSSFabChina();";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);
                txtShipDateFromChina.Focus();
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

    #region Bind Controls

    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetProjects(ObjBOL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlReviewedBy, ds.Tables[0]);
                Utility.BindDropDownList(ddlReviewedBy_Grid, ds.Tables[0]);
                Utility.BindDropDownList(ddlReviewedByChina, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectDesigner, ds.Tables[1]);
                Utility.BindDropDownList(ddlProjectDesigner_Grid, ds.Tables[1]);
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectDesCanada, ds.Tables[2]);
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlManuFac, ds.Tables[3]);
                Utility.BindDropDownList(ddlManuFacChina, ds.Tables[3]);
            }

            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectDesignerChina, ds.Tables[4]);
                Utility.BindDropDownList(ddlProjectReviewerChina, ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlFabChinaCorrectedBy, ds.Tables[5]);
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlWarehouse, ds.Tables[6]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindModels()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL1.Operation = 2;
            ds = ObjBLL1.GetSubModel(ObjBOL1);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindCheckBoxListWOAll(chk1, ds.Tables[1]);
                Utility.BindCheckBoxListWOAll(chk2, ds.Tables[2]);
                Utility.BindCheckBoxListWOAll(chk3, ds.Tables[3]);
                Utility.BindCheckBoxListWOAll(chk4, ds.Tables[4]);
                Utility.BindCheckBoxListWOAll(chk5, ds.Tables[5]);
                Utility.BindCheckBoxListWOAll(chk6, ds.Tables[6]);
                Utility.BindCheckBoxListWOAll(chk7, ds.Tables[7]);
                Utility.BindCheckBoxListWOAll(chk8, ds.Tables[8]);
                Utility.BindCheckBoxListWOAll(chk9, ds.Tables[9]);

                chk1_PopUp.Text = PrepareListFrontend(ds.Tables[1]);
                chk2_PopUp.Text = PrepareListFrontend(ds.Tables[2]);
                chk3_PopUp.Text = PrepareListFrontend(ds.Tables[3]);
                chk4_PopUp.Text = PrepareListFrontend(ds.Tables[4]);
                chk5_PopUp.Text = PrepareListFrontend(ds.Tables[5]);
                chk6_PopUp.Text = PrepareListFrontend(ds.Tables[6]);
                chk7_PopUp.Text = PrepareListFrontend(ds.Tables[7]);
                chk8_PopUp.Text = PrepareListFrontend(ds.Tables[8]);
                chk9_PopUp.Text = PrepareListFrontend(ds.Tables[9]);
                foreach (ListItem li in chk1.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk2.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk3.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk4.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk5.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk6.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk7.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk8.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
                foreach (ListItem li in chk9.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes["title"] = GetRoleTooltip(Convert.ToInt32(li.Value));
                }
            }
            else
            {
                chk1.DataSource = "";
                chk1.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private string PrepareListFrontend(DataTable tableToRender)
    {
        try
        {
            string list = "<ul> ";
            foreach (DataRow row in tableToRender.Rows)
            {
                list += "<li>" + row[3].ToString() + "</li> ";
            }
            list += "</ul>";
            return list;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return "";
    }

    private string GetRoleTooltip(int p)
    {
        string name = string.Empty;
        try
        {
            DataSet ds = new DataSet();
            ObjBOL1.Operation = 5;
            ObjBOL1.id = p;
            ds = ObjBLL1.GetSubModel(ObjBOL1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                name = ds.Tables[0].Rows[0]["description"].ToString();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return name;
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
                HfJObID.Value = output;
                SyncTextbox("NUM", output);
                BindAndFill_Models();
                GetFilePath(HfJObID.Value);
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
                int index = txtSearchPNum.Text.IndexOf(',');
                if (txtSearchPNum.Text.Length > 7)
                {
                    if (index != -1)
                    {
                        OutJnumber = txtSearchPNum.Text.Substring(0, txtSearchPNum.Text.IndexOf(','));
                    }
                }
                else
                {
                    OutJnumber = txtSearchPNum.Text;
                }
                HfJObID.Value = OutJnumber;
                FillJnumber(txtSearchPNum.Text);
                EnableDisableReports();
                BindAndFill_Models();
                GetFilePath(HfJObID.Value);
                return;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void SyncTextbox(string type, string text)
    {
        try
        {
            if (type != "")
            {
                DataTable dt = new DataTable();
                if (type == "NUM")
                {
                    dt = Utility.ReturnProjects(26, text);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchPNum.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                    }
                    else
                    {
                        txtSearchPNum.Text = "";
                        txtSearchPName.Text = "";
                        Utility.ShowMessage_Error(Page, "J# not Found");
                    }
                }
                else
                {
                    dt = Utility.ReturnProjects(25, text);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchPName.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                    }
                    else
                    {
                        txtSearchPNum.Text = "";
                        txtSearchPName.Text = "";
                        Utility.ShowMessage_Error(Page, "J# not Found");
                    }
                }
            }
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
                    FillDetailsFromJnumber(OutJnumber);
                    SyncTextbox("NAME", OutJnumber);
                    HfJObID.Value = OutJnumber;
                }
                else
                {
                    FillDetailsFromJnumber(strJnumber);
                    SyncTextbox("NUM", strJnumber);
                    HfJObID.Value = strJnumber;
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
    //        ObjBOL.Operation = 2;
    //        ObjBOL.ProjectName = strJNumber;
    //        ObjBOL.JobID = strJNumber;
    //        ds = ObjBLL.GetProjects(ObjBOL);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            DataRow dr = ds.Tables[0].Rows[0];
    //            HfJObID.Value = Convert.ToString(dr["JobID"]);
    //            hfPNumber.Value = Convert.ToString(dr["ProposalID"]);
    //            hfProjectStatus.Value = Convert.ToString(dr["ProjectStatus"]);
    //            txtFabReleasedDate.Text = cls.Converter(Convert.ToString(dr["ReleaseDate"]));
    //            txtFabReleasedDateChina.Text = cls.Converter(Convert.ToString(dr["ReleaseDateChina"]));
    //            txtExpectedArrivalDatefromChina.Text = cls.Converter(Convert.ToString(dr["ExpectedArrivalDatefromChina"]));

    //            var Reviewedby = Convert.ToString(dr["ReviewedBy"]);
    //            var ReviewedbyID = new List<string> { "33", "40", "75", "89", "161" };
    //            if (ReviewedbyID.Contains(Reviewedby))
    //            {
    //                ddlReviewedBy.SelectedValue = Convert.ToString(dr["ReviewedBy"]);
    //                ddlReviewedByChina.SelectedValue = Convert.ToString(dr["ReviewedBy"]);
    //            }
    //            if (ddlFabStatus.Items.FindByValue(Convert.ToString(dr["Status"])) != null)
    //            {
    //                ddlFabStatus.SelectedValue = Convert.ToString(dr["Status"]);
    //            }
    //            if (Convert.ToString(dr["PurchasedItemsCAD"]) == "Y")
    //            {
    //                ddlPurchasedItems.Enabled = true;
    //                ddlPurchasedItems.SelectedValue = Convert.ToString(dr["PurchasedItems"]);
    //            }
    //            else
    //            {
    //                ddlPurchasedItems.Enabled = false;
    //                //ddlPurchasedItems.SelectedValue = "0";
    //            }

    //            txtFabStartDate.Text = cls.Converter(Convert.ToString(dr["DateAssigned"]));
    //            txtFabStartDateChina.Text = cls.Converter(Convert.ToString(dr["DateAssignedChina"]));
    //            if (ddlProjectDesigner.Items.FindByValue(dr["ProjectDesignerID"].ToString()) != null)
    //            {
    //                ddlProjectDesigner.SelectedValue = dr["ProjectDesignerID"].ToString();
    //            }

    //            if (ddlProjectDesignerChina.Items.FindByValue(dr["ProjectDesignerChinaID"].ToString()) != null)
    //            {
    //                ddlProjectDesignerChina.SelectedValue = dr["ProjectDesignerChinaID"].ToString();
    //            }
    //            txtDueToCanda.Text = cls.Converter(Convert.ToString(dr["DueDateCanada"]));
    //            txtFabtrication.Text = cls.Converter(Convert.ToString(dr["FabSentToCanada"]));
    //            txtFabEndDateChina.Text = cls.Converter(Convert.ToString(dr["FabSentToCanada_China"]));
    //            if (ddlManuFac.Items.FindByValue(dr["MfgFacilityID"].ToString()) != null)
    //            {
    //                ddlManuFac.SelectedValue = dr["MfgFacilityID"].ToString();
    //                ddlManuFacChina.SelectedValue = dr["MfgFacilityID"].ToString();
    //            }
    //            if (ddlIssued.Items.FindByValue(dr["Issued"].ToString()) != null)
    //            {
    //                ddlIssued.SelectedValue = dr["Issued"].ToString();
    //            }

    //            txtReleasetoNesting.Text = cls.Converter(Convert.ToString(dr["ReleasedToNesting"]));
    //            txtProjectReleasedToShop.Text = cls.Converter(Convert.ToString(dr["ReleasedToShop"]));
    //            if (ddlNestingStatus.Items.FindByValue(dr["NestingStatus"].ToString()) != null)
    //            {
    //                ddlNestingStatus.SelectedValue = dr["NestingStatus"].ToString();
    //            }

    //            hfReleased.Value = dr["ReleaseToShop"].ToString();

    //            if (ds.Tables[1].Rows.Count > 0)
    //            {
    //                GvShpDrg.DataSource = ds.Tables[1];
    //                GvShpDrg.DataBind();
    //            }
    //            else
    //            {
    //                GvShpDrg.DataSource = EmptyDT();
    //                GvShpDrg.DataBind();
    //                GvShpDrg.Rows[0].Visible = false;
    //            }

    //            EnableDisableReports();
    //            CheckUserForRelease();

    //            if (Convert.ToString(dr["ProjectManager"]) != "")
    //            {
    //                lblPM.Text = "Project Manager : <b>" + Convert.ToString(dr["ProjectManager"]) + "</b>";
    //                lblPM.Visible = true;
    //            }
    //            else
    //            {
    //                lblPM.Text = String.Empty;
    //                lblPM.Visible = false;
    //            }
    //            if (Convert.ToString(dr["DestinationRep"]) != "")
    //            {
    //                lblDesRep.Text = "Destination Rep : <b>" + Convert.ToString(dr["DestinationRep"]) + "</b>";
    //                lblDesRep.Visible = true;
    //            }
    //            else
    //            {
    //                lblDesRep.Text = String.Empty;
    //                lblDesRep.Visible = false;
    //            }
    //            if (Convert.ToString(dr["Consultant"]) != "")
    //            {
    //                lblConsultant.Text = "Consultant : <b>" + Convert.ToString(dr["Consultant"]) + "</b>";
    //                lblConsultant.Visible = true;
    //            }
    //            else
    //            {
    //                lblConsultant.Text = String.Empty;
    //                lblConsultant.Visible = false;
    //            }
    //            btnSave.Enabled = true;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}

    private void FillDetailsFromJnumber(string strJNumber)
    {
        try
        {
            hfShipToArriveDateFillDetail.Value = "";
            hfReleased.Value = "";
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.ProjectName = strJNumber;
            ObjBOL.JobID = strJNumber;
            ds = ObjBLL.GetProjects(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
            {
                { "JobID", d => HfJObID.Value = Convert.ToString(d["JobID"]) },
                { "ProposalID", d => hfPNumber.Value = Convert.ToString(d["ProposalID"]) },
                { "ProjectStatus", d=> hfProjectStatus.Value = Convert.ToString(d["ProjectStatus"])},
                { "ReleaseDate", d => txtFabReleasedDate.Text = cls.Converter(Convert.ToString(d["ReleaseDate"])) },
                { "ReleaseDateChina", d => txtFabReleasedDateChina.Text = cls.Converter(Convert.ToString(d["ReleaseDateChina"])) },
                { "ExpectedSubmissionDate", d => txtExpectedSubmissionDate.Text = cls.Converter(Convert.ToString(d["ExpectedSubmissionDate"])) },
                { "ActualSubmissionDate", d => txtActualSubmissionDate.Text = cls.Converter(Convert.ToString(d["ActualSubmissionDate"])) },
                { "ExpectedArrivalDatefromChina", d => txtExpectedArrivalDatefromChina.Text = cls.Converter(Convert.ToString(d["ExpectedArrivalDatefromChina"])) },
                { "ReviewedBy", d=>
                    {
                        var Reviewedby = Convert.ToString(d["ReviewedBy"]);
                        var ReviewedbyID = new List<string> { "33", "40", "75", "89", "161" };
                        if (ReviewedbyID.Contains(Reviewedby))
                        {
                            if(ddlReviewedBy.Items.FindByValue(Convert.ToString(d["ReviewedBy"])) != null)
                            {
                                ddlReviewedBy.SelectedValue = Convert.ToString(d["ReviewedBy"]);
                            }
                            else if(ddlReviewedBy.Items.Count > 0)
                            {
                                ddlReviewedBy.SelectedIndex = 0;
                            }

                            if(ddlReviewedByChina.Items.FindByValue(Convert.ToString(d["ReviewedBy"])) != null)
                            {
                                ddlReviewedByChina.SelectedValue = Convert.ToString(d["ReviewedBy"]);
                            }
                            else if(ddlReviewedByChina.Items.Count > 0)
                            {
                                ddlReviewedByChina.SelectedIndex = 0;
                            }
                        }
                    }
                },
                { "DateAssigned", d => txtFabStartDate.Text = cls.Converter(Convert.ToString(d["DateAssigned"])) },
                { "DateAssignedChina", d => txtFabStartDateChina.Text = cls.Converter(Convert.ToString(d["DateAssignedChina"])) },
                { "Status", d=>
                    {
                       if (ddlFabStatus.Items.FindByValue(Convert.ToString(d["Status"])) != null)
                        {
                            ddlFabStatus.SelectedValue = Convert.ToString(d["Status"]);
                        }
                       else if(ddlFabStatus.Items.Count > 0)
                        {
                            ddlFabStatus.SelectedIndex = 0;
                        }
                    }
                },
                { "PurchasedItemsCAD", d=>
                    {
                       if (Convert.ToString(d["PurchasedItemsCAD"]) == "Y")
                        {
                            ddlPurchasedItems.Enabled = true;
                            ddlPurchasedItems.SelectedValue = Convert.ToString(d["PurchasedItems"]);
                        }
                        else
                        {
                            ddlPurchasedItems.Enabled = false;
							//ddlPurchasedItems.SelectedValue = "0";
						}
                    }
                },
                { "ProjectDesignerID", d=>
                    {
                       if (ddlProjectDesigner.Items.FindByValue(d["ProjectDesignerID"].ToString()) != null)
                        {
                            ddlProjectDesigner.SelectedValue = d["ProjectDesignerID"].ToString();
                        }
                       else if(ddlProjectDesigner.Items.Count > 0)
                        {
                            ddlProjectDesigner.SelectedIndex = 0;
                        }
                    }
                },
                { "CorrectedBy", d=>
                    {
                       if (ddlFabChinaCorrectedBy.Items.FindByValue(d["CorrectedBy"].ToString()) != null)
                        {
                            ddlFabChinaCorrectedBy.SelectedValue = d["CorrectedBy"].ToString();
                        }
                       else if(ddlFabChinaCorrectedBy.Items.Count > 0)
                        {
                            ddlFabChinaCorrectedBy.SelectedIndex = 0;
                        }
                    }
                },
                { "ProjectDesignerChinaID", d=>
                    {
                       if (ddlProjectDesignerChina.Items.FindByValue(d["ProjectDesignerChinaID"].ToString()) != null)
                        {
                            ddlProjectDesignerChina.SelectedValue = d["ProjectDesignerChinaID"].ToString();
                        }
                       else if(ddlProjectDesignerChina.Items.Count > 0)
                        {
                            ddlProjectDesignerChina.SelectedIndex = 0;
                        }
                    }
                },
                { "ProjectReviewerChinaID", d=>
                    {
                       if (ddlProjectReviewerChina.Items.FindByValue(d["FabProjectReviewerChinaID"].ToString()) != null)
                        {
                            ddlProjectReviewerChina.SelectedValue = d["FabProjectReviewerChinaID"].ToString();
                        }
                       else if(ddlProjectReviewerChina.Items.Count > 0)
                        {
                            ddlProjectReviewerChina.SelectedIndex = 0;
                        }
                    }
                },
                { "FabDrawingPercentage", d=>
                    {
                       if (ddlFabDrawingPercentage.Items.FindByValue(d["FabDrawingPercentage"].ToString()) != null)
                        {
                            ddlFabDrawingPercentage.SelectedValue = d["FabDrawingPercentage"].ToString();
                        }
                       else if(ddlFabDrawingPercentage.Items.Count > 0)
                        {
                            ddlFabDrawingPercentage.SelectedIndex = 0;
                        }
                    }
                },
                { "DueDateCanada", d => txtDueToCanda.Text = cls.Converter(Convert.ToString(d["DueDateCanada"])) },
                { "FabSentToCanada", d => txtFabtrication.Text = cls.Converter(Convert.ToString(d["FabSentToCanada"])) },
                { "FabSentToCanada_China", d => txtFabEndDateChina.Text = cls.Converter(Convert.ToString(d["FabSentToCanada_China"])) },
                { "MfgFacilityID", d=>
                    {
                       if (ddlManuFac.Items.FindByValue(d["MfgFacilityID"].ToString()) != null)
                        {
                            ddlManuFac.SelectedValue = d["MfgFacilityID"].ToString();
                        }
                       else if(ddlManuFac.Items.Count > 0)
                        {
                            ddlManuFac.SelectedIndex = 0;
                        }

                       if (ddlManuFacChina.Items.FindByValue(d["MfgFacilityID"].ToString()) != null)
                        {
                            ddlManuFacChina.SelectedValue = d["MfgFacilityID"].ToString();
                        }
                       else if(ddlManuFacChina.Items.Count > 0)
                        {
                            ddlManuFacChina.SelectedIndex = 0;
                        }
                    }
                },
                { "WarehouseId", d=>
                    {
                       if (ddlWarehouse.Items.FindByValue(d["WarehouseId"].ToString()) != null)
                        {
                            ddlWarehouse.SelectedValue = d["WarehouseId"].ToString();
                        }
                       else if(ddlWarehouse.Items.Count > 0)
                        {
                            ddlWarehouse.SelectedIndex = 0;
                        }

                       if (ddlWarehouse.Items.FindByValue(d["WarehouseId"].ToString()) != null)
                        {
                            ddlWarehouse.SelectedValue = d["WarehouseId"].ToString();
                        }
                       else if(ddlWarehouse.Items.Count > 0)
                        {
                            ddlWarehouse.SelectedIndex = 0;
                        }
                    }
                },
                { "Issued", d=>
                    {
                       if (ddlIssued.Items.FindByValue(d["Issued"].ToString()) != null)
                        {
                            ddlIssued.SelectedValue = d["Issued"].ToString();
                        }
                       else if(ddlIssued.Items.Count > 0)
                        {
                            ddlIssued.SelectedIndex = 0;
                        }
                    }
                },
                { "ReleasedToNesting", d => txtReleasetoNesting.Text = cls.Converter(Convert.ToString(d["ReleasedToNesting"])) },
                { "ReleasedToShop", d => txtProjectReleasedToShop.Text = cls.Converter(Convert.ToString(d["ReleasedToShop"])) },
                { "NestingStatus", d=>
                    {
                       if (ddlNestingStatus.Items.FindByValue(d["NestingStatus"].ToString()) != null)
                        {
                            ddlNestingStatus.SelectedValue = d["NestingStatus"].ToString();
                        }
                       else if(ddlNestingStatus.Items.Count > 0)
                        {
                            ddlNestingStatus.SelectedIndex = 0;
                        }
                    }
                },
                { "ReleaseToShop", d => hfReleased.Value = d["ReleaseToShop"].ToString() },
                { "ShipDateFromChina", d => txtShipDateFromChina.Text = cls.Converter(Convert.ToString(d["ShipDateFromChina"])) },
                { "ContainerNo", d => txtContainerNo.Text = d["ContainerNo"].ToString() },
                { "ProductionStatus", d=>
                    {
                       if (ddlProductionStatus.Items.FindByValue(d["ProductionStatus"].ToString()) != null)
                        {
                            ddlProductionStatus.SelectedValue = d["ProductionStatus"].ToString();
                        }
                       else if(ddlProductionStatus.Items.Count > 0)
                        {
                            ddlProductionStatus.SelectedIndex = 0;
                        }
                    }
                },
                { "ProductionRemarks", d => txtProductionRemarks.Text = d["ProductionRemarks"].ToString() }
            };

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

                if (ds.Tables[1].Rows.Count > 0)
                {
                    GvShpDrg.DataSource = ds.Tables[1];
                    GvShpDrg.DataBind();
                }
                else
                {
                    GvShpDrg.DataSource = EmptyDT();
                    GvShpDrg.DataBind();
                    GvShpDrg.Rows[0].Visible = false;
                }

                EnableDisableReports();
                CheckUserForRelease();
                ResetFabricationCanada();
                GetFabricationTasks();
                GetNestingTasks();
                if (Convert.ToString(dr["ProjectManager"]) != "")
                {
                    lblPM.Text = "Project Manager : <b>" + Convert.ToString(dr["ProjectManager"]) + "</b>";
                    lblPM.Visible = true;
                }
                else
                {
                    lblPM.Text = String.Empty;
                    lblPM.Visible = false;
                }
                if (Convert.ToString(dr["DestinationRep"]) != "")
                {
                    lblDesRep.Text = "Destination Rep : <b>" + Convert.ToString(dr["DestinationRep"]) + "</b>";
                    lblDesRep.Visible = true;
                }
                else
                {
                    lblDesRep.Text = String.Empty;
                    lblDesRep.Visible = false;
                }
                if (Convert.ToString(dr["Consultant"]) != "")
                {
                    lblConsultant.Text = "Consultant : <b>" + Convert.ToString(dr["Consultant"]) + "</b>";
                    lblConsultant.Visible = true;
                }
                else
                {
                    lblConsultant.Text = String.Empty;
                    lblConsultant.Visible = false;
                }
                btnSave.Enabled = true;
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
            string msg = "";
            if (ValidationCheck() == true)
            {
                GetFileSize();
                string sts = GetProjectStatus(HfJObID.Value);
                if (sts == "0" || sts == "1" || sts == "2" || sts == "")
                {
                    if (fileInput.HasFile)
                    {
                        string fileExtension = Path.GetExtension(fileInput.FileName);
                        if (fileExtension.ToLower() == ".pdf")
                        {
                            string folderPath = Utility.PlanViewPath();
                            if (!Directory.Exists(folderPath))
                            {
                                //If Directory (Folder) does not exists Create it.
                                Directory.CreateDirectory(folderPath);
                            }
                            string JobID = HfJObID.Value + ".pdf";
                            string FileName = JobID;
                            FileInfo currentfile = new FileInfo(fileInput.FileName);
                            // Get the file size in bytes
                            long fileSizeInBytes = fileInput.PostedFile.ContentLength;

                            // Convert bytes to KB for better readability
                            double fileSizeInKB = fileSizeInBytes / 1024.0;
                            if (fileSizeInKB <= Convert.ToInt32(DynamicFileSize) * 1024)
                            {
                                string newfilename = FileName;
                                fileInput.SaveAs(folderPath + newfilename);
                                SaveData(newfilename);
                                GetFilePath(HfJObID.Value);
                            }
                            else
                            {
                                Utility.ShowMessage_Error(Page, "File size exceeds " + DynamicFileSize + "KB. Please upload a smaller file.");
                            }
                        }
                        else
                        {
                            Utility.ShowMessage_Error(Page, "Only PDF files are allowed. Please upload a PDF file.");
                        }
                    }
                    else
                    {
                        var lnkfileName = lnkDowload.Text;
                        SaveData(lnkfileName);
                    }
                }
                else if (sts == "3")
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

    private string GetProjectStatus(string Jobid)
    {
        string sts = string.Empty;
        try
        {
            ObjBOL.JobID = Jobid;
            ObjBOL.Operation = 4;
            sts = ObjBLL.GetProjectStatus(ObjBOL);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return sts;
    }

    private void SaveData(string fileName)
    {
        try
        {
            string planview = string.Empty;
            string msg = string.Empty;
            ObjBOL.Operation = 7;
            ObjBOL.JobID = HfJObID.Value;
            ObjBOL.ReleaseDate = Utility.ConvertDate(txtFabReleasedDate.Text);
            ObjBOL.ReleaseDateChina = Utility.ConvertDate(txtFabReleasedDateChina.Text);
            ObjBOL.ExpectedSubmissionDate = Utility.ConvertDate(txtExpectedSubmissionDate.Text);
            ObjBOL.ActualSubmissionDate = Utility.ConvertDate(txtActualSubmissionDate.Text);
            ObjBOL.ExpectedArrivalDatefromChina = Utility.ConvertDate(txtExpectedArrivalDatefromChina.Text);
            if (ddlReviewedBy.SelectedIndex > 0)
            {
                ObjBOL.ReviewedBy = Convert.ToInt32(ddlReviewedBy.SelectedValue);
            }

            if (ddlFabChinaCorrectedBy.SelectedIndex > 0)
            {
                ObjBOL.CorrectedBy = Convert.ToInt32(ddlFabChinaCorrectedBy.SelectedValue);
            }

            if (ddlFabStatus.SelectedIndex > 0)
            {
                ObjBOL.Status = Convert.ToInt32(ddlFabStatus.SelectedValue);
            }
            ObjBOL.PurchasedItems = ddlPurchasedItems.SelectedValue;
            ObjBOL.DateAssigned = Utility.ConvertDate(txtFabStartDate.Text);
            ObjBOL.DateAssignedChina = Utility.ConvertDate(txtFabStartDateChina.Text);

            if (ddlProjectDesigner.SelectedIndex > 0)
            {
                ObjBOL.ProjectDesignerID = Convert.ToInt32(ddlProjectDesigner.SelectedValue);
            }

            if (ddlProjectDesignerChina.SelectedIndex > 0)
            {
                ObjBOL.ProjectDesignerChinaID = Convert.ToInt32(ddlProjectDesignerChina.SelectedValue);
            }

            if (ddlProjectReviewerChina.SelectedIndex > 0)
            {
                ObjBOL.ProjectReviewerChinaID = Convert.ToInt32(ddlProjectReviewerChina.SelectedValue);
            }

            if (ddlFabDrawingPercentage.SelectedIndex > 0)
            {
                ObjBOL.FabDrawingPercentage = Convert.ToInt32(ddlFabDrawingPercentage.SelectedValue);
            }

            if (ddlManuFac.SelectedIndex > 0)
            {
                ObjBOL.MfgFacilityID = Convert.ToInt32(ddlManuFac.SelectedValue);
            }

            if (ddlWarehouse.SelectedIndex > 0)
            {
                ObjBOL.WarehouseId = Convert.ToInt32(ddlWarehouse.SelectedValue);
            }
            ObjBOL.Issued = ddlIssued.SelectedValue;
            ObjBOL.DueDateCanada = Utility.ConvertDate(txtDueToCanda.Text);
            ObjBOL.FabSentToCanada = Utility.ConvertDate(txtFabtrication.Text);
            ObjBOL.FabSentToCanada_China = Utility.ConvertDate(txtFabEndDateChina.Text);
            ObjBOL.ReleasedToNesting = Utility.ConvertDate(txtReleasetoNesting.Text);
            ObjBOL.ReleasedToShop = Utility.ConvertDate(txtProjectReleasedToShop.Text);
            ObjBOL.NestingStatus = ddlNestingStatus.SelectedValue.ToString();
            ObjBOL.UserID = Utility.GetCurrentSession().EmployeeID;
            ObjBOL.ShipDateFromChina = Utility.ConvertDate(txtShipDateFromChina.Text);
            ObjBOL.ContainerNo = txtContainerNo.Text;
            ObjBOL.ProductionStatus = ddlProductionStatus.SelectedValue;
            ObjBOL.ProductionRemarks = txtProductionRemarks.Text;

            if (fileName != "")
            {
                ObjBOL.fileName = fileName.ToUpper();
            }
            msg = ObjBLL.SaveProject(ObjBOL);
            if (msg == "1")
            {
                Utility.ShowMessage_Success(Page, "Project Updated !!");
                //  Utility.MaintainLogsSpecial("FrmProjectsEng.aspx", "Update", HfJObID.Value);
                if (fileInput.HasFile && lnkDowload.Text != "")
                {
                    Utility.MaintainLogsSpecial("FrmProjectsEng.aspx", "PlanView-Updated", HfJObID.Value);
                }
                else if (fileInput.HasFile && lnkDowload.Text == "")
                {
                    Utility.MaintainLogsSpecial("FrmProjectsEng.aspx", "PlanView-Inserted", HfJObID.Value);
                }
                else
                {
                    Utility.MaintainLogsSpecial("FrmProjectsEng.aspx", "Update", HfJObID.Value);
                }
            }
            //else if (msg == "0")
            //{
            //    Utility.ShowMessage_Success(Page, "Project Inserted !!");
            //    Utility.MaintainLogsSpecial("FrmProjectsEng.aspx", "Save", HfJObID.Value);
            //}
            btnSave.Text = "Update";
            Save_Model();
            string strMethodNameNew = "GetValue();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable DTModel()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.TableName = "Summary";
            dt.Columns.Add(new DataColumn("PNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("ChildModelID", typeof(int)));
            ViewState["Summary"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void CheckModelBeforeSave()
    {
        try
        {
            DataTable dt = DTModel();
            DataRow dr;
            ViewState["Summary"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Save_Model()
    {
        try
        {
            ObjBOL1.Operation = 3;
            CheckModelBeforeSave();
            DataTable selected = (DataTable)ViewState["Summary"];
            DataView dv = new DataView(selected);
            DataTable summarytemp = dv.ToTable("selected", false, "PNumber", "ChildModelID");
            DataRow row;
            ObjBOL1.PNumber = hfPNumber.Value;
            for (int i = 0; i < chk1.Items.Count; i++)
            {
                if (chk1.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk1.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }

            for (int i = 0; i < chk2.Items.Count; i++)
            {
                if (chk2.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk2.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }

            for (int i = 0; i < chk3.Items.Count; i++)
            {
                if (chk3.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk3.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }

            for (int i = 0; i < chk4.Items.Count; i++)
            {
                if (chk4.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk4.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }

            for (int i = 0; i < chk5.Items.Count; i++)
            {
                if (chk5.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk5.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }

            for (int i = 0; i < chk6.Items.Count; i++)
            {
                if (chk6.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk6.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }

            for (int i = 0; i < chk7.Items.Count; i++)
            {
                if (chk7.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk7.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }

            for (int i = 0; i < chk8.Items.Count; i++)
            {
                if (chk8.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk8.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }
            for (int i = 0; i < chk9.Items.Count; i++)
            {
                if (chk9.Items[i].Selected)
                {
                    row = summarytemp.NewRow();
                    row["PNumber"] = ObjBOL1.PNumber.Split(',')[0];
                    row["ChildModelID"] = Int32.Parse(chk9.Items[i].Value);
                    summarytemp.Rows.Add(row);
                }
            }
            ObjBOL1.SelectDetails = summarytemp;
            ObjBLL1.SaveModel(ObjBOL1);
            BindAndFill_Models();
        }

        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void btnInf_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            rprt.Load(Server.MapPath("~/Reports/rptProjectShippingInf.rpt"));
            //cls.Return_DT(dt, "EXEC [dbo].[Get_ProjectInstallation] '" + HfJObID.Value + "'");
            //if (dt.Rows.Count == 1 && dt.Rows[0]["partno"].ToString().Trim() == "")
            //{
            cls.Return_DT(dt, "EXEC [dbo].[Get_qryProjectsInstallation] '" + HfJObID.Value + "'");
            //}
            rprt.SetDataSource(dt);
            rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
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

    protected void btnCuspack_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            rprt.Load(Server.MapPath("~/Reports/rptCustCarePackageLetter.rpt"));
            cls.Return_DT(dt, "EXEC [dbo].[Get_qryCustMemberMain] '" + HfJObID.Value + "'");
            rprt.SetDataSource(dt);
            rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
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

    protected void btnAcknoledgement_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = ReportData();
            rprt.Load(Server.MapPath("~/Reports/rptOrderAcknowledgment.rpt"));
            rprt.SetDataSource(dt);
            rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
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

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            cls.Return_DT(dt, "EXEC [dbo].[Get_qryOrderProbability] '" + HfJObID.Value + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
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

    #endregion

    #region Shop Drawing Events

    protected void GvShpDrg_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            GvShpDrg.EditIndex = e.NewEditIndex;
            string ID = Convert.ToString(GvShpDrg.DataKeys[e.NewEditIndex].Value);
            hfDataKeys.Value = ID;
            FillDetails(HfJObID.Value);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvShpDrg_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = GvShpDrg.Rows[e.RowIndex];
            ObjBOLShpDrg.Operation = 6;
            TextBox txtDrgSentToRCD = row.FindControl("txtDrgSentToRCD") as TextBox;
            if (txtDrgSentToRCD.Text != "")
            {
                ObjBOLShpDrg.sDrgNum = (row.FindControl("txtDrgNum") as TextBox).Text;
                ObjBOLShpDrg.sDrgJID = (row.FindControl("txtDrgJID") as TextBox).Text;
                TextBox txtDrgWantDate = row.FindControl("txtDrgWantDate") as TextBox;
                ObjBOLShpDrg.sDrgWantDate = Utility.ConvertDate(txtDrgWantDate.Text);
                TextBox txtDrgPromisedDate = row.FindControl("txtDrgPromisedDate") as TextBox;
                ObjBOLShpDrg.sDrgPromiseDate = Utility.ConvertDate(txtDrgPromisedDate.Text);
                TextBox txtDrgExpectedApprovalDate = row.FindControl("txtDrgExpectedApprovalDate") as TextBox;
                ObjBOLShpDrg.sDrgExpecApprovalDate = Utility.ConvertDate(txtDrgExpectedApprovalDate.Text);
                ObjBOLShpDrg.sDrgSentToRCD = Utility.ConvertDate(txtDrgSentToRCD.Text);
                TextBox txtDrgAppDate = row.FindControl("txtDrgAppDate") as TextBox;
                ObjBOLShpDrg.sDrgAppDate = Utility.ConvertDate(txtDrgAppDate.Text);
                TextBox txtDrgNextFollowupDate = row.FindControl("txtDrgNextFollowupDate") as TextBox;
                ObjBOLShpDrg.sNextFolowupDate = Utility.ConvertDate(txtDrgNextFollowupDate.Text);
                TextBox txtDateReleasedToFab = row.FindControl("txtDateReleasedToFab") as TextBox;
                ObjBOLShpDrg.sDateReleasedToFab = Utility.ConvertDate(txtDateReleasedToFab.Text);
                TextBox txtDrgDateFollowedUp = row.FindControl("txtDrgDateFollowedUp") as TextBox;
                ObjBOLShpDrg.sDateFollowedUp = Utility.ConvertDate(txtDrgDateFollowedUp.Text);
                ObjBOLShpDrg.sDrgComment = (row.FindControl("txtDrgComment") as TextBox).Text;
                DropDownList ddlEditReleasedTo = row.FindControl("ddlEditReleasedTo") as DropDownList;
                TextBox txtEditReleaseToFabDate = row.FindControl("txtEditReleaseToFabDate") as TextBox;
                ObjBOLShpDrg.sReleasedToFabDate = Utility.ConvertDate(txtEditReleaseToFabDate.Text);
                TextBox txtEditReleaseToShopDate = row.FindControl("txtEditReleaseToShopDate") as TextBox;
                ObjBOLShpDrg.sReleasedToShopDate = Utility.ConvertDate(txtEditReleaseToShopDate.Text);
                if (ddlEditReleasedTo.SelectedIndex > 0)
                {
                    ObjBOLShpDrg.sReleasedTo = Convert.ToChar(ddlEditReleasedTo.SelectedValue);
                }
                msg = ObjBLLShpDrg.SaveDataShpDrg(ObjBOLShpDrg);
                if (msg.Trim().Length > 0)
                {
                    Utility.MaintainLogsSpecial("FrmProjectsEng", "Update Shop Dwg", HfJObID.Value);
                    GvShpDrg.EditIndex = -1;
                    Utility.ShowMessage_Success(Page, msg);
                    FillDetails(HfJObID.Value);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please fill DwgSentToRCD !!");
                txtDrgSentToRCD.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvShpDrg_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        try
        {
            GvShpDrg.EditIndex = -1;
            FillDetails(HfJObID.Value);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvShpDrg_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        try
        {
            GvShpDrg.PageIndex = e.NewPageIndex;
            FillDetails(HfJObID.Value);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvShpDrg_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Insert" && Page.IsValid)
            {
                string msg = "";
                ObjBOLShpDrg.Operation = 8;
                ObjBOLShpDrg.sDrgJID = HfJObID.Value;
                TextBox FtxtDrgSentToRCD = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgSentToRCD");
                if (FtxtDrgSentToRCD.Text != "")
                {
                    TextBox FtxtDrgNum = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgNum");
                    TextBox FtxtJobID = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtJobID");
                    TextBox FtxtDrgPromisedDate = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgPromisedDate");
                    TextBox FtxtDrgExpectedApprovalDate = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgExpectedApprovalDate");
                    TextBox FtxtDrgWantDate = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgWantDate");
                    TextBox FtxtDrgAppDate = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgAppDate");
                    TextBox FtxtDrgNextFollowupDate = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgNextFollowupDate");
                    TextBox FtxtDrgDateFollowedUp = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgDateFollowedUp");
                    TextBox FtxtDateReleasedToFab = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDateReleasedToFab");
                    TextBox FtxtDrgComment = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtDrgComment");
                    DropDownList FddlReleasedTo = (DropDownList)GvShpDrg.FooterRow.FindControl("ddlFooterReleasedTo");
                    TextBox FtxtReleaseToFab = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtReleaseToFabDate");
                    TextBox FtxtReleaseToShop = (TextBox)GvShpDrg.FooterRow.FindControl("FtxtReleaseToShopDate");
                    ObjBOLShpDrg.sDrgWantDate = Utility.ConvertDate(FtxtDrgWantDate.Text);
                    ObjBOLShpDrg.sDrgPromiseDate = Utility.ConvertDate(FtxtDrgPromisedDate.Text);
                    ObjBOLShpDrg.sDrgExpecApprovalDate = Utility.ConvertDate(FtxtDrgExpectedApprovalDate.Text);
                    ObjBOLShpDrg.sDrgSentToRCD = Utility.ConvertDate(FtxtDrgSentToRCD.Text);
                    ObjBOLShpDrg.sDrgAppDate = Utility.ConvertDate(FtxtDrgAppDate.Text);
                    ObjBOLShpDrg.sNextFolowupDate = Utility.ConvertDate(FtxtDrgNextFollowupDate.Text);
                    ObjBOLShpDrg.sDateFollowedUp = Utility.ConvertDate(FtxtDrgDateFollowedUp.Text);
                    ObjBOLShpDrg.sDateReleasedToFab = Utility.ConvertDate(FtxtDateReleasedToFab.Text);
                    ObjBOLShpDrg.sDrgComment = FtxtDrgComment.Text;
                    ObjBOLShpDrg.sReleasedToFabDate = Utility.ConvertDate(FtxtReleaseToFab.Text);
                    ObjBOLShpDrg.sReleasedToShopDate = Utility.ConvertDate(FtxtReleaseToShop.Text);
                    if (FddlReleasedTo.SelectedIndex > 0)
                    {
                        ObjBOLShpDrg.sReleasedTo = Convert.ToChar(FddlReleasedTo.SelectedValue);
                    }
                    msg = ObjBLLShpDrg.SaveDataShpDrg(ObjBOLShpDrg);
                    if (msg.Trim().Length > 0)
                    {
                        Utility.MaintainLogsSpecial("FrmProjectsEng", "Insert Shop Dwg", HfJObID.Value);
                        Utility.ShowMessage_Success(Page, msg);
                        FillDetails(HfJObID.Value);
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
                    }
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "Please fill DwgSentToRCD !!");
                    FtxtDrgSentToRCD.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvShpDrg_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            string ID = Convert.ToString(GvShpDrg.DataKeys[e.RowIndex].Value);
            ObjBOLShpDrg.Operation = 5;
            ObjBOLShpDrg.sDrgNum = ID;
            msg = ObjBLLShpDrg.SaveDataShpDrg(ObjBOLShpDrg);
            if (msg.Trim().Length > 0)
            {
                FillDetails(HfJObID.Value);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSS()", true);
                Utility.MaintainLogsSpecial("FrmProjectsEng", "Delete Shop Dwg", ID);
                Utility.ShowMessage_Success(Page, msg);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillDetails(string strJNumber)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOLShpDrg.Operation = 3;
            ObjBOLShpDrg.JobID = strJNumber;
            ds = ObjBLLShpDrg.GetDataShpDrgs(ObjBOLShpDrg);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvShpDrg.DataSource = ds;
                GvShpDrg.DataBind();
            }
            else
            {
                GvShpDrg.DataSource = EmptyDT();
                GvShpDrg.DataBind();
                GvShpDrg.Rows[0].Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Fabrication Events

    protected void ddlReviewedBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlReviewedByChina.SelectedValue = ddlReviewedBy.SelectedValue;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFab()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlManuFac_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlManuFacChina.SelectedValue = ddlManuFac.SelectedValue;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFab()", true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnRelease_Click(object sender, EventArgs e)
    {
        try
        {
            if (HfJObID.Value != "")
            {
                string msg = "";
                ObjBOLRel.operation = 2;
                ObjBOLRel.projectid = HfJObID.Value;
                ObjBOLRel.userid = Convert.ToInt32(Utility.GetCurrentUser());
                msg = ObjBLLRel.ReleaseProject(ObjBOLRel);
                if (msg.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "No Warehouse present for the Job !!");
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "SetCSSFab()", true);
                    return;
                }

                if (msg.Trim() == "S")
                {
                    Utility.MaintainLogsSpecial("FrmProjectsEng", "Release", HfJObID.Value.ToString());
                    Utility.ShowMessage_Success(Page, "Project Released !!");
                    FillDetailsFromJnumber(HfJObID.Value);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnRollback_Click(object sender, EventArgs e)
    {
        try
        {
            if (HfJObID.Value != "")
            {
                string msg = "";
                ObjBOLRel.operation = 3;
                ObjBOLRel.projectid = HfJObID.Value;
                ObjBOLRel.userid = Convert.ToInt32(Utility.GetCurrentUser());
                msg = ObjBLLRel.ReleaseProject(ObjBOLRel);
                if (msg.Trim() == "S")
                {
                    Utility.MaintainLogsSpecial("frmRollback", "Rollback", HfJObID.Value.ToString());
                    Utility.ShowMessage_Success(Page, "Project Rollbacked !!");
                    FillDetailsFromJnumber(HfJObID.Value);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckUserForRelease()
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                int userid = Convert.ToInt32(Utility.GetCurrentUser());
                //89 = Bhatiwal, 96 = kalsi
                if (userid == 89 || userid == 96 || userid == 263 || userid == 264)
                {
                    if (hfReleased.Value == "True")
                    {
                        ddlWarehouse.Enabled = false;
                        btnRelease.Enabled = false;
                        btnRollback.Enabled = true;
                    }
                    else if (hfReleased.Value == "False")
                    {
                        ddlWarehouse.Enabled = true;
                        btnRelease.Enabled = true;
                        btnRollback.Enabled = false;
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

    #region Model Events

    protected void BindAndFill_Models()
    {
        BindModels();
        Fill_ModelDetails();
    }

    private void Fill_ModelDetails()
    {
        try
        {
            ObjBOL1.Operation = 4;
            DataSet ds = new DataSet();
            ObjBOL1.PNumber = hfPNumber.Value;
            ds = ObjBLL1.GetSubModel(ObjBOL1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < chk1.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk1.Items[i].Value == chk.ToString())
                        {
                            chk1.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk2.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk2.Items[i].Value == chk.ToString())
                        {
                            chk2.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk3.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk3.Items[i].Value == chk.ToString())
                        {
                            chk3.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk4.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk4.Items[i].Value == chk.ToString())
                        {
                            chk4.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk5.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk5.Items[i].Value == chk.ToString())
                        {
                            chk5.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk6.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk6.Items[i].Value == chk.ToString())
                        {
                            chk6.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk7.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk7.Items[i].Value == chk.ToString())
                        {
                            chk7.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk8.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk8.Items[i].Value == chk.ToString())
                        {
                            chk8.Items[i].Selected = true;
                        }
                    }
                }
                for (int i = 0; i < chk9.Items.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        var chk = ds.Tables[0].Rows[j]["ChildModelID"];
                        if (chk9.Items[i].Value == chk.ToString())
                        {
                            chk9.Items[i].Selected = true;
                        }
                    }
                }
                string strMethodName = "GetValue();";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Redirect Events

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

    protected void btnCADReport_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/SalesManagement/FrmDailyCADReport.aspx?pNumber=" + hfPNumber.Value, false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSiteVisit_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/SalesManagement/FrmSiteVisitInformation.aspx?pNumber=" + hfPNumber.Value, false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnProjects_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "~/SalesManagement/FrmProjects.aspx";
            if (HfJObID.Value.Trim() != "-1")
            {
                link += "?jid=" + HfJObID.Value.Trim();
            }
            Response.Redirect(link);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Resets

    private void EnableDisableReports()
    {
        try
        {
            if (hfProjectStatus.Value != "0")
            {
                btnAcknoledgement.Enabled = false;
                btnInf.Enabled = false;
                btnCuspack.Enabled = false;
            }
            else
            {
                btnAcknoledgement.Enabled = true;
                btnInf.Enabled = true;
                btnCuspack.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisabledReportButtons()
    {
        try
        {
            btnAcknoledgement.Enabled = false;
            btnInf.Enabled = false;
            btnCuspack.Enabled = false;
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
            HfJObID.Value = "-1";
            hfPNumber.Value = "-1";
            hfProjectStatus.Value = "-1";
            ddlPurchasedItems.Enabled = false;
            DisabledReportButtons();

            txtFabReleasedDate.Text = String.Empty;
            txtFabReleasedDateChina.Text = String.Empty;
            txtExpectedSubmissionDate.Text = String.Empty;
            txtActualSubmissionDate.Text = String.Empty;
            ddlReviewedBy.SelectedIndex = 0;
            ddlReviewedBy_Grid.SelectedIndex = 0;
            ddlReviewedByChina.SelectedIndex = 0;
            ddlFabChinaCorrectedBy.SelectedIndex = 0;
            ddlFabStatus.SelectedIndex = 0;
            ddlPurchasedItems.SelectedIndex = 0;
            ddlIssued.SelectedIndex = 0;
            Session["PNumber"] = null;
            Session["JobID"] = null;
            GvShpDrg.DataSource = EmptyDT();
            GvShpDrg.DataBind();
            GvShpDrg.Rows[0].Visible = false;
            txtFabStartDate.Text = String.Empty;
            txtFabStartDateChina.Text = String.Empty;
            ddlProjectDesigner.SelectedIndex = 0;
            ddlProjectDesigner_Grid.SelectedIndex = 0;
            ddlProjectDesignerChina.SelectedIndex = 0;
            ddlProjectReviewerChina.SelectedIndex = 0;
            ddlFabDrawingPercentage.SelectedIndex = 0;
            txtDueToCanda.Text = String.Empty;
            txtFabtrication.Text = String.Empty;
            txtFabEndDateChina.Text = String.Empty;
            ddlProjectDesCanada.SelectedIndex = 0;
            ddlManuFac.SelectedIndex = 0;
            ddlManuFacChina.SelectedIndex = 0;
            ddlWarehouse.SelectedIndex = 0;
            ddlWarehouse.Enabled = true;
            txtReleasetoNesting.Text = String.Empty;
            txtProjectReleasedToShop.Text = String.Empty;
            txtSearchPName.Text = "";
            txtSearchPNum.Text = "";
            txtExpectedArrivalDatefromChina.Text = string.Empty;
            txtShipDateFromChina.Text = string.Empty;
            txtContainerNo.Text = string.Empty;
            ddlProductionStatus.SelectedIndex = 0;
            txtProductionRemarks.Text = string.Empty;
            BindModels();
            lblDesRep.Text = String.Empty;
            lblPM.Text = String.Empty;
            lblConsultant.Text = String.Empty;
            lblDesRep.Visible = false;
            lblPM.Visible = false;
            lblConsultant.Visible = false;
            btnSave.Enabled = false;
            lnkDowload.Text = String.Empty;
            lnkDowload.Visible = false;
            btnDelete.Visible = false;
            ResetFabricationCanada();
            ResetNestingTaskGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetFilePath(string JobID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 12;
            ObjBOL.JobID = JobID;
            ds = ObjBLL.GetFilePath(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["filepath"].ToString() != "")
                {
                    lnkDowload.Visible = true;
                    btnDelete.Visible = true;
                    DownLoadFileName = ds.Tables[0].Rows[0]["filepath"].ToString();
                    lnkDowload.Text = DownLoadFileName.ToUpper();
                }
                else
                {
                    DownLoadFileName = "";
                    lnkDowload.Text = String.Empty;
                    lnkDowload.Visible = false;
                    btnDelete.Visible = false;
                }
            }
            else
            {
                DownLoadFileName = "";
                lnkDowload.Text = String.Empty;
                lnkDowload.Visible = false;
                btnDelete.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void lnkDowload_Click(object sender, EventArgs e)
    {
        try
        {
            GetFilePath(HfJObID.Value);
            string filePath = Utility.PlanViewPath() + DownLoadFileName;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists && Response.IsClientConnected)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/pdf";
                Response.Flush();
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    //btnDelete_Click
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            GetFilePath(HfJObID.Value);
            //Delete File Path From Folder
            string folderPath = Utility.PlanViewPath() + DownLoadFileName;
            if (File.Exists(folderPath))
            {
                File.Delete(folderPath);
            }
            //Delete File Path from table 
            string msg = "";
            ObjBOL.Operation = 13;
            ObjBOL.JobID = HfJObID.Value;
            msg = ObjBLL.GetProjectStatus(ObjBOL);
            if (msg != "")
            {
                Utility.ShowMessage_Success(Page, msg);
                Utility.MaintainLogsSpecial("FrmProjectsEng", "Delete Plan View", HfJObID.Value);
                GetFilePath(HfJObID.Value);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    #endregion   


    protected void GvShpDrg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == GvShpDrg.EditIndex)
                {
                    DropDownList ddlEditReleasedTo = (DropDownList)e.Row.FindControl("ddlEditReleasedTo");
                    Label lblEditReleasedTo = (Label)e.Row.FindControl("lblEditReleasedTo");
                    if (lblEditReleasedTo.Text != "")
                    {
                        ddlEditReleasedTo.SelectedValue = lblEditReleasedTo.Text;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void checkCorrectedByPermission()
    {
        try
        {

            string msg = "";
            ObjBOL.Operation = 14;
            ObjBOL.UserID = Utility.GetCurrentSession().EmployeeID;
            msg = ObjBLL.GetProjectStatus(ObjBOL);
            if (msg == "1")
            {
                ddlFabChinaCorrectedBy.Enabled = false;
            }
            else
            {
                ddlFabChinaCorrectedBy.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnFabChinaDailyReport_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "~/Reports/FrmFabricationChinaDailyReport.aspx";
            Response.Redirect(link);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetFabricationCanada()
    {
        try
        {
            hfFabricationCanadaId.Value = "-1";
            txtTaskNumber_Grid.Text = string.Empty;
            if (ddlNatureOfTask_Grid.SelectedIndex > 0)
            {
                ddlNatureOfTask_Grid.SelectedIndex = 0;
            }

            if (ddlReleaseType_Grid.SelectedIndex > 0)
            {
                ddlReleaseType_Grid.SelectedIndex = 0;
            }

            if (ddlProjectDesigner_Grid.SelectedIndex > 0)
            {
                ddlProjectDesigner_Grid.SelectedIndex = 0;
            }

            txtFabStartDate_Grid.Text = string.Empty;
            txtFabEndDate_Grid.Text = string.Empty;

            if (ddlReviewedBy_Grid.SelectedIndex > 0)
            {
                ddlReviewedBy_Grid.SelectedIndex = 0;
            }

            gvFabricationCanada.DataSource = string.Empty;
            gvFabricationCanada.DataBind();

            ddlNatureOfTask_Grid.Enabled = true;
            btnAddFabricationTask.Text = "Add";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetFabricationTasks()
    {
        try
        {
            ObjBOL_FabricationAndNestingTasks.Operation = 3;
            ObjBOL_FabricationAndNestingTasks.JobId = HfJObID.Value;
            DataSet ds = ObjBLL_FabricationAndNestingTasks.Return_DataSet(ObjBOL_FabricationAndNestingTasks);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvFabricationCanada.DataSource = ds.Tables[0];
                gvFabricationCanada.DataBind();
            }
            else
            {
                gvFabricationCanada.DataSource = string.Empty;
                gvFabricationCanada.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool Validation_FabricationCanada()
    {
        try
        {
            string strMethodNameNew = "SetCSSFab();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);

            if (HfJObID.Value.Length < 4)
            {
                Utility.ShowMessage_Error(Page, "Please select Job !");
                return false;
            }

            if (ddlNatureOfTask_Grid.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select nature of Task !");
                ddlNatureOfTask_Grid.Focus();

                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnAddFabricationTask_Click(object sender, EventArgs e)
    {
        try
        {
            if (Validation_FabricationCanada())
            {
                string op = "Add-PEng-FC";
                string message = "Task added successfully !!";
                if (hfFabricationCanadaId.Value == "-1")
                {
                    ObjBOL_FabricationAndNestingTasks.Operation = 1;
                }
                else
                {
                    ObjBOL_FabricationAndNestingTasks.Operation = 2;
                    ObjBOL_FabricationAndNestingTasks.ID = Int32.Parse(hfFabricationCanadaId.Value);
                    ObjBOL_FabricationAndNestingTasks.TaskNumber = txtTaskNumber_Grid.Text;
                    op = "Update-PEng-FC";
                    message = "Task updated successfully !!";
                }

                ObjBOL_FabricationAndNestingTasks.JobId = HfJObID.Value;
                ObjBOL_FabricationAndNestingTasks.NatureOfTask = ddlNatureOfTask_Grid.SelectedValue;
                ObjBOL_FabricationAndNestingTasks.ReleaseType = ddlReleaseType_Grid.SelectedValue;
                if (ddlProjectDesigner_Grid.SelectedIndex > 0)
                {
                    ObjBOL_FabricationAndNestingTasks.ProjectDesigner = Int32.Parse(ddlProjectDesigner_Grid.SelectedValue);
                }

                ObjBOL_FabricationAndNestingTasks.StartDate = Utility.ConvertDate(txtFabStartDate_Grid.Text);
                ObjBOL_FabricationAndNestingTasks.EndDate = Utility.ConvertDate(txtFabEndDate_Grid.Text);
                if (ddlReviewedBy_Grid.SelectedIndex > 0)
                {
                    ObjBOL_FabricationAndNestingTasks.ReviewedBy = Int32.Parse(ddlReviewedBy_Grid.SelectedValue);
                }

                string returnStatus = ObjBLL_FabricationAndNestingTasks.Return_String(ObjBOL_FabricationAndNestingTasks);

                if (returnStatus.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "Task already sent to Nesting !!");
                    return;
                }

                if (returnStatus.Trim() != "")
                {
                    Utility.MaintainLogsSpecial("FrmProjectsEng", op, returnStatus);
                    Utility.ShowMessage_Success(Page, message);
                    ResetFabricationCanada();
                    GetFabricationTasks();
                }
                string strMethodNameNew = "SetCSSFab();";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvFabricationCanada_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            string strMethodNameNew = "SetCSSFab();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);

            DataSet ds = new DataSet();
            int id = Int32.Parse(gvFabricationCanada.DataKeys[e.NewEditIndex].Values[0].ToString());
            hfFabricationCanadaId.Value = id.ToString();

            ObjBOL_FabricationAndNestingTasks.Operation = 4;
            ObjBOL_FabricationAndNestingTasks.ID = id;
            ds = ObjBLL_FabricationAndNestingTasks.Return_DataSet(ObjBOL_FabricationAndNestingTasks);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (Boolean.Parse(row["SentToNesting"].ToString()))
                {
                    Utility.ShowMessage_Error(Page, "Task already sent to Nesting !!");
                    return;
                }
                txtTaskNumber_Grid.Text = row["TaskNumber"].ToString();

                if (ddlNatureOfTask_Grid.Items.FindByValue(row["NatureOfTask"].ToString()) != null)
                {
                    ddlNatureOfTask_Grid.SelectedValue = row["NatureOfTask"].ToString();
                }
                else
                {
                    if (ddlNatureOfTask_Grid.Items.Count > 0)
                    {
                        ddlNatureOfTask_Grid.SelectedIndex = 0;
                    }
                }

                if (ddlReleaseType_Grid.Items.FindByValue(row["ReleaseType"].ToString()) != null)
                {
                    ddlReleaseType_Grid.SelectedValue = row["ReleaseType"].ToString();
                }
                else
                {
                    if (ddlReleaseType_Grid.Items.Count > 0)
                    {
                        ddlReleaseType_Grid.SelectedIndex = 0;
                    }
                }

                if (ddlProjectDesigner_Grid.Items.FindByValue(row["ProjectDesigner"].ToString()) != null)
                {
                    ddlProjectDesigner_Grid.SelectedValue = row["ProjectDesigner"].ToString();
                }
                else
                {
                    if (ddlProjectDesigner_Grid.Items.Count > 0)
                    {
                        ddlProjectDesigner_Grid.SelectedIndex = 0;
                    }
                }

                txtFabStartDate_Grid.Text = row["StartDate"].ToString();
                txtFabEndDate_Grid.Text = row["EndDate"].ToString();

                if (ddlReviewedBy_Grid.Items.FindByValue(row["ReviewedBy"].ToString()) != null)
                {
                    ddlReviewedBy_Grid.SelectedValue = row["ReviewedBy"].ToString();
                }
                else
                {
                    if (ddlReviewedBy_Grid.Items.Count > 0)
                    {
                        ddlReviewedBy_Grid.SelectedIndex = 0;
                    }
                }

                //ddlNatureOfTask_Grid.Enabled = false;
                btnAddFabricationTask.Text = "Update";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvFabricationCanada_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string strMethodNameNew = "SetCSSFab();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);

            int id = Int32.Parse(gvFabricationCanada.DataKeys[e.RowIndex].Values[0].ToString());

            ObjBOL_FabricationAndNestingTasks.Operation = 5;
            ObjBOL_FabricationAndNestingTasks.ID = id;
            string returnStatus = ObjBLL_FabricationAndNestingTasks.Return_String(ObjBOL_FabricationAndNestingTasks);

            if (returnStatus.Trim() == "ER01")
            {
                Utility.ShowMessage_Error(Page, "Task already sent to Nesting !!");
                return;
            }

            if (returnStatus.Trim() != "")
            {
                Utility.ShowMessage_Success(Page, "Task Deleted Successfully !!");
                Utility.MaintainLogsSpecial("FrmProjectsEng", "Delete-PEng-FC", id.ToString());
            }

            ResetFabricationCanada();
            GetFabricationTasks();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvFabricationCanada_Sorting(object sender, GridViewSortEventArgs e)
    {

    }

    protected void gvFabricationCanada_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Send")
            {
                string strMethodNameNew = "SetCSSFab();";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);

                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int id = Int32.Parse(gvFabricationCanada.DataKeys[rowIndex].Values[0].ToString());

                ObjBOL_FabricationAndNestingTasks.Operation = 6;
                ObjBOL_FabricationAndNestingTasks.ID = id;
                string returnStatus = ObjBLL_FabricationAndNestingTasks.Return_String(ObjBOL_FabricationAndNestingTasks);

                if (returnStatus.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "Task already sent to Nesting !!");
                    return;
                }

                if (returnStatus.Trim() != "")
                {
                    Utility.ShowMessage_Success(Page, "Task Sent to Nesting Successfully !!");
                    Utility.MaintainLogsSpecial("FrmProjectsEng", "Sent-PEng-FC", returnStatus);
                    GetFabricationTasks();
                    GetNestingTasks();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataSet BindNestingGridControls_Data()
    {
        DataSet ds = new DataSet();
        try
        {
            ObjBOL_FabricationAndNestingTasks.Operation = 8;
            ds = ObjBLL_FabricationAndNestingTasks.Return_DataSet(ObjBOL_FabricationAndNestingTasks);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return ds;
    }

    private void BindNestingGridControls()
    {
        try
        {
            DataSet ds = BindNestingGridControls_Data();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList ddlTaskType_FooterNesting = (DropDownList)gvNestingTasks.FooterRow.FindControl("ddlTaskType_FooterNesting");
                Utility.BindDropDownList(ddlTaskType_FooterNesting, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                DropDownList ddlProjectEngineer_FooterNesting = (DropDownList)gvNestingTasks.FooterRow.FindControl("ddlProjectEngineer_FooterNesting");
                Utility.BindDropDownList(ddlProjectEngineer_FooterNesting, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindNestingGridControls(DropDownList ddl1, DropDownList ddl2)
    {
        try
        {
            DataSet ds = BindNestingGridControls_Data();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddl1, ds.Tables[0]);
            }
            else
            {
                ddl1.Items.Clear();
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddl2, ds.Tables[1]);
            }
            else
            {
                ddl2.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable EmptyDT_NestingTasks()
    {
        DataTable dtEmpty = new DataTable();
        try
        {
            dtEmpty.Columns.Add("Id", typeof(int));
            dtEmpty.Columns.Add("TaskNumber", typeof(string));
            dtEmpty.Columns.Add("NatureOfTask", typeof(string));
            dtEmpty.Columns.Add("AssignedFrom", typeof(string));
            dtEmpty.Columns.Add("TaskType", typeof(int));
            dtEmpty.Columns.Add("ProjectEngineer", typeof(int));
            dtEmpty.Columns.Add("StartDate", typeof(DateTime));
            dtEmpty.Columns.Add("EndDate", typeof(DateTime));
            dtEmpty.Columns.Add("SentDate", typeof(DateTime));
            dtEmpty.Columns.Add("Status", typeof(int));
            dtEmpty.Columns.Add("SentToProduction", typeof(string));

            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    private void ResetNesting()
    {
        try
        {
            gvNestingTasks.DataSource = string.Empty;
            gvNestingTasks.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetNestingTaskGrid()
    {
        try
        {
            gvNestingTasks.DataSource = EmptyDT_NestingTasks();
            gvNestingTasks.DataBind();
            gvNestingTasks.Rows[0].Visible = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetNestingTasks()
    {
        try
        {
            ObjBOL_FabricationAndNestingTasks.Operation = 7;
            ObjBOL_FabricationAndNestingTasks.JobId = HfJObID.Value;
            DataSet ds = ObjBLL_FabricationAndNestingTasks.Return_DataSet(ObjBOL_FabricationAndNestingTasks);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvNestingTasks.DataSource = ds.Tables[0];
                gvNestingTasks.DataBind();
            }
            else
            {
                ResetNestingTaskGrid();
            }
            BindNestingGridControls();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvNestingTasks_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string strMethodNameNew = "SetCSSNesting();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);

            int id = Int32.Parse(gvNestingTasks.DataKeys[e.RowIndex].Values[0].ToString());

            ObjBOL_FabricationAndNestingTasks.Operation = 13;
            ObjBOL_FabricationAndNestingTasks.ID = id;
            string returnStatus = ObjBLL_FabricationAndNestingTasks.Return_String(ObjBOL_FabricationAndNestingTasks);

            if (returnStatus.Trim() == "ER01")
            {
                Utility.ShowMessage_Error(Page, "Task already sent to Production !!");
                return;
            }

            if (returnStatus.Trim() == "ER02")
            {
                Utility.ShowMessage_Error(Page, "Task forwarded from Fabrication. Cannot be deleted !!");
                return;
            }

            if (returnStatus.Trim() != "")
            {
                Utility.ShowMessage_Success(Page, "Task Deleted Successfully !!");
                Utility.MaintainLogsSpecial("FrmProjectsEng", "Delete-PEng-N", returnStatus);
            }

            GetNestingTasks();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvNestingTasks_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvNestingTasks.EditIndex = e.NewEditIndex;
            GetNestingTasks();
            string strMethodNameNew = "SetCSSNesting();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);

            DataSet ds = new DataSet();
            int id = Int32.Parse(gvNestingTasks.DataKeys[e.NewEditIndex].Values[0].ToString());

            ObjBOL_FabricationAndNestingTasks.Operation = 9;
            ObjBOL_FabricationAndNestingTasks.ID = id;
            ds = ObjBLL_FabricationAndNestingTasks.Return_DataSet(ObjBOL_FabricationAndNestingTasks);
            if (ds.Tables[0].Rows.Count > 0)
            {

                DataRow row = ds.Tables[0].Rows[0];
                if (Boolean.Parse(row["SentToProduction"].ToString()))
                {
                    Utility.ShowMessage_Error(Page, "Task already sent to Production !!");
                    gvNestingTasks.EditIndex = -1;
                    GetNestingTasks();
                    return;
                }

                Label lblTaskNumber_EditNesting = gvNestingTasks.Rows[e.NewEditIndex].FindControl("lblTaskNumber_EditNesting") as Label;
                lblTaskNumber_EditNesting.Text = row["TaskNumber"].ToString();


                DropDownList ddlNatureOfTask_EditNesting = gvNestingTasks.Rows[e.NewEditIndex].FindControl("ddlNatureOfTask_EditNesting") as DropDownList;
                if (ddlNatureOfTask_EditNesting.Items.FindByValue(row["NatureOfTask"].ToString()) != null)
                {
                    ddlNatureOfTask_EditNesting.SelectedValue = row["NatureOfTask"].ToString();
                }
                else
                {
                    if (ddlNatureOfTask_EditNesting.Items.Count > 0)
                    {
                        ddlNatureOfTask_EditNesting.SelectedIndex = 0;
                    }
                }

                DropDownList ddlAssignedFrom_EditNesting = gvNestingTasks.Rows[e.NewEditIndex].FindControl("ddlAssignedFrom_EditNesting") as DropDownList;
                if (ddlAssignedFrom_EditNesting.Items.FindByValue(row["AssignedFrom"].ToString()) != null)
                {
                    ddlAssignedFrom_EditNesting.SelectedValue = row["AssignedFrom"].ToString();
                }
                else
                {
                    if (ddlAssignedFrom_EditNesting.Items.Count > 0)
                    {
                        ddlAssignedFrom_EditNesting.SelectedIndex = 0;
                    }
                }

                //if (row["AssignedFrom"].ToString() == "F")
                //{
                ddlAssignedFrom_EditNesting.Enabled = false;
                ddlNatureOfTask_EditNesting.Enabled = false;
                //}
                //else
                //{
                //    ddlAssignedFrom_EditNesting.Enabled = true;
                //    ddlNatureOfTask_EditNesting.Enabled = true;
                //}

                DropDownList ddlTaskType_EditNesting = gvNestingTasks.Rows[e.NewEditIndex].FindControl("ddlTaskType_EditNesting") as DropDownList;
                DropDownList ddlProjectEngineer_EditNesting = gvNestingTasks.Rows[e.NewEditIndex].FindControl("ddlProjectEngineer_EditNesting") as DropDownList;

                BindNestingGridControls(ddlTaskType_EditNesting, ddlProjectEngineer_EditNesting);

                if (ddlTaskType_EditNesting.Items.FindByValue(row["TaskType"].ToString()) != null)
                {
                    ddlTaskType_EditNesting.SelectedValue = row["TaskType"].ToString();
                }
                else
                {
                    if (ddlTaskType_EditNesting.Items.Count > 0)
                    {
                        ddlTaskType_EditNesting.SelectedIndex = 0;
                    }
                }

                if (ddlProjectEngineer_EditNesting.Items.FindByValue(row["ProjectEngineer"].ToString()) != null)
                {
                    ddlProjectEngineer_EditNesting.SelectedValue = row["ProjectEngineer"].ToString();
                }
                else
                {
                    if (ddlProjectEngineer_EditNesting.Items.Count > 0)
                    {
                        ddlProjectEngineer_EditNesting.SelectedIndex = 0;
                    }
                }

                TextBox txtStartDate_EditNesting = gvNestingTasks.Rows[e.NewEditIndex].FindControl("txtStartDate_EditNesting") as TextBox;
                txtStartDate_EditNesting.Text = row["StartDate"].ToString();

                TextBox txtEndDate_EditNesting = gvNestingTasks.Rows[e.NewEditIndex].FindControl("txtEndDate_EditNesting") as TextBox;
                txtEndDate_EditNesting.Text = row["EndDate"].ToString();

                TextBox txtSentDate_EditNesting = gvNestingTasks.Rows[e.NewEditIndex].FindControl("txtSentDate_EditNesting") as TextBox;
                txtSentDate_EditNesting.Text = row["SentDate"].ToString();

                DropDownList ddlStatus_EditNesting = gvNestingTasks.Rows[e.NewEditIndex].FindControl("ddlStatus_EditNesting") as DropDownList;
                if (ddlStatus_EditNesting.Items.FindByValue(row["Status"].ToString()) != null)
                {
                    ddlStatus_EditNesting.SelectedValue = row["Status"].ToString();
                }
                else
                {
                    if (ddlStatus_EditNesting.Items.Count > 0)
                    {
                        ddlStatus_EditNesting.SelectedIndex = 0;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvNestingTasks_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string strMethodNameNew = "SetCSSNesting();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);

            if (e.CommandName == "Send")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int id = Int32.Parse(gvNestingTasks.DataKeys[rowIndex].Values[0].ToString());

                ObjBOL_FabricationAndNestingTasks.Operation = 12;
                ObjBOL_FabricationAndNestingTasks.ID = id;
                string returnStatus = ObjBLL_FabricationAndNestingTasks.Return_String(ObjBOL_FabricationAndNestingTasks);

                if (returnStatus.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "Task already sent to Production !!");
                    return;
                }

                if (returnStatus.Trim() == "ER02")
                {
                    Utility.ShowMessage_Error(Page, "Please enter Sent Date !!");
                    return;
                }

                if (returnStatus.Trim() != "")
                {
                    Utility.ShowMessage_Success(Page, "Task Sent to Production Successfully !!");
                    Utility.MaintainLogsSpecial("FrmProjectsEng", "Sent-PEng-N", id.ToString());
                    GetNestingTasks();
                }
            }

            else if (e.CommandName == "Insert")
            {
                GridViewRow row = gvNestingTasks.FooterRow;

                ObjBOL_FabricationAndNestingTasks.Operation = 11;
                DropDownList ddlNatureOfTask_FooterNesting = row.FindControl("ddlNatureOfTask_FooterNesting") as DropDownList;
                DropDownList ddlAssignedFrom_FooterNesting = row.FindControl("ddlAssignedFrom_FooterNesting") as DropDownList;

                DropDownList ddlTaskType_FooterNesting = row.FindControl("ddlTaskType_FooterNesting") as DropDownList;
                DropDownList ddlProjectEngineer_FooterNesting = row.FindControl("ddlProjectEngineer_FooterNesting") as DropDownList;
                DropDownList ddlStatus_FooterNesting = row.FindControl("ddlStatus_FooterNesting") as DropDownList;

                if (HfJObID.Value.Length < 4)
                {
                    Utility.ShowMessage_Error(Page, "Please select Job !");
                    return;
                }

                if (ddlNatureOfTask_FooterNesting.SelectedIndex == 0)
                {
                    Utility.ShowMessage_Error(Page, "Please select Nature of Task !");
                    return;
                }

                if (ddlAssignedFrom_FooterNesting.SelectedIndex == 0)
                {
                    Utility.ShowMessage_Error(Page, "Please select Assigned From !");
                    return;
                }

                //ObjBOL_FabricationAndNestingTasks.TaskNumber = (row.FindControl("lblTaskNumber_FooterNesting") as Label).Text;
                ObjBOL_FabricationAndNestingTasks.JobId = HfJObID.Value;
                ObjBOL_FabricationAndNestingTasks.NatureOfTask = ddlNatureOfTask_FooterNesting.SelectedValue;
                ObjBOL_FabricationAndNestingTasks.AssignedFrom = ddlAssignedFrom_FooterNesting.SelectedValue;
                if (ddlTaskType_FooterNesting.SelectedIndex > 0)
                {
                    ObjBOL_FabricationAndNestingTasks.TaskType = Int32.Parse(ddlTaskType_FooterNesting.SelectedValue);
                }

                if (ddlProjectEngineer_FooterNesting.SelectedIndex > 0)
                {
                    ObjBOL_FabricationAndNestingTasks.ProjectEngineer = Int32.Parse(ddlProjectEngineer_FooterNesting.SelectedValue);
                }

                ObjBOL_FabricationAndNestingTasks.StartDate = Utility.ConvertDate((row.FindControl("txtStartDate_FooterNesting") as TextBox).Text);
                ObjBOL_FabricationAndNestingTasks.EndDate = Utility.ConvertDate((row.FindControl("txtEndDate_FooterNesting") as TextBox).Text);
                ObjBOL_FabricationAndNestingTasks.SentDate = Utility.ConvertDate((row.FindControl("txtSentDate_FooterNesting") as TextBox).Text);

                if (ddlStatus_FooterNesting.SelectedIndex > 0)
                {
                    ObjBOL_FabricationAndNestingTasks.Status = Int32.Parse(ddlStatus_FooterNesting.SelectedValue);
                }

                string returnStatus = ObjBLL_FabricationAndNestingTasks.Return_String(ObjBOL_FabricationAndNestingTasks);

                if (returnStatus.Trim() != "")
                {
                    Utility.MaintainLogsSpecial("FrmProjectsEng", "Add-PEng-N", returnStatus);
                    Utility.ShowMessage_Success(Page, "Task inserted successfully !!");
                    GetNestingTasks();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvNestingTasks_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvNestingTasks.EditIndex = -1;
            GetNestingTasks();
            string strMethodNameNew = "SetCSSNesting();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvNestingTasks_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow row = gvNestingTasks.Rows[e.RowIndex];
            ObjBOL_FabricationAndNestingTasks.Operation = 10;
            DropDownList ddlNatureOfTask_EditNesting = row.FindControl("ddlNatureOfTask_EditNesting") as DropDownList;
            DropDownList ddlAssignedFrom_EditNesting = row.FindControl("ddlAssignedFrom_EditNesting") as DropDownList;

            DropDownList ddlTaskType_EditNesting = row.FindControl("ddlTaskType_EditNesting") as DropDownList;
            DropDownList ddlProjectEngineer_EditNesting = row.FindControl("ddlProjectEngineer_EditNesting") as DropDownList;
            DropDownList ddlStatus_EditNesting = row.FindControl("ddlStatus_EditNesting") as DropDownList;

            if (ddlNatureOfTask_EditNesting.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Nature of Task !");
                return;
            }

            if (ddlAssignedFrom_EditNesting.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Assigned From !");
                return;
            }
            string taskId = gvNestingTasks.DataKeys[e.RowIndex].Value.ToString();

            ObjBOL_FabricationAndNestingTasks.ID = Int32.Parse(taskId);
            ObjBOL_FabricationAndNestingTasks.JobId = HfJObID.Value;
            ObjBOL_FabricationAndNestingTasks.TaskNumber = (row.FindControl("lblTaskNumber_EditNesting") as Label).Text;
            ObjBOL_FabricationAndNestingTasks.NatureOfTask = ddlNatureOfTask_EditNesting.SelectedValue;
            ObjBOL_FabricationAndNestingTasks.AssignedFrom = ddlAssignedFrom_EditNesting.SelectedValue;
            if (ddlTaskType_EditNesting.SelectedIndex > 0)
            {
                ObjBOL_FabricationAndNestingTasks.TaskType = Int32.Parse(ddlTaskType_EditNesting.SelectedValue);
            }

            if (ddlProjectEngineer_EditNesting.SelectedIndex > 0)
            {
                ObjBOL_FabricationAndNestingTasks.ProjectEngineer = Int32.Parse(ddlProjectEngineer_EditNesting.SelectedValue);
            }

            ObjBOL_FabricationAndNestingTasks.StartDate = Utility.ConvertDate((row.FindControl("txtStartDate_EditNesting") as TextBox).Text);
            ObjBOL_FabricationAndNestingTasks.EndDate = Utility.ConvertDate((row.FindControl("txtEndDate_EditNesting") as TextBox).Text);
            ObjBOL_FabricationAndNestingTasks.SentDate = Utility.ConvertDate((row.FindControl("txtSentDate_EditNesting") as TextBox).Text);

            if (ddlStatus_EditNesting.SelectedIndex > 0)
            {
                ObjBOL_FabricationAndNestingTasks.Status = Int32.Parse(ddlStatus_EditNesting.SelectedValue);
            }

            string returnStatus = ObjBLL_FabricationAndNestingTasks.Return_String(ObjBOL_FabricationAndNestingTasks);

            if (returnStatus.Trim() == "ER01")
            {
                Utility.ShowMessage_Error(Page, "Task already sent to Production !!");
                return;
            }

            if (returnStatus.Trim() != "")
            {
                Utility.MaintainLogsSpecial("FrmProjectsEng", "Update-PEng-N", returnStatus);
                Utility.ShowMessage_Success(Page, "Task updated successfully !!");
                gvNestingTasks.EditIndex = -1;
                GetNestingTasks();
            }

            string strMethodNameNew = "SetCSSNesting();";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodNameNew, true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}