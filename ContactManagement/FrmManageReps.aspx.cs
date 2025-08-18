using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactManagement_FrmManageReps : System.Web.UI.Page
{
    BOLManageReps ObjBOL = new BOLManageReps();
    BLLManageReps ObjBLL = new BLLManageReps();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindControls();
                btnModalOpener.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #region Binding Function

    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProductLineHeaderList, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlAbbreviationAddList, ds.Tables[1]);
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRepHeaderList, ds.Tables[2]);
                ddlRepHeaderList.SelectedIndex = 0;
            }
            else
            {
                ddlRepHeaderList.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_GVSalesRep()
    {
        try
        {
            ObjBOL.Operation = 6;
            ObjBOL.BranchID = Convert.ToInt32(ddlBranchHeaderList.SelectedValue);
            DataSet ds = new DataSet();
            ds = ObjBLL.GetBranchInformation(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvSalesRep.DataSource = ds.Tables[0];
                gvSalesRep.DataBind();
            }
            else
            {
                gvSalesRep.AllowPaging = false;
                gvSalesRep.DataSource = "";
                gvSalesRep.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Validation

    private Boolean ValidationCheck()
    {
        try
        {
            if (txtFirstName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter First Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter First Name. !");
                txtFirstName.Focus();
                ModalPopupExtender1.Show();
                return false;
            }

            if (txtLastName.Text == "")
            {
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Last Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Last Name. !");
                txtLastName.Focus();
                ModalPopupExtender1.Show();
                return false;
            }

            if (ddlAbbreviationAddList.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Abbreviation. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Abbreviation. !");
                ddlAbbreviationAddList.Focus();
                ModalPopupExtender1.Show();
                return false;
            }

            if (ddlStatusAddList.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Status. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                ddlStatusAddList.Focus();
                ModalPopupExtender1.Show();
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

    #region Event Handler Functions

    protected void ddlProductLineHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ResetRepGroup();
        ClearRepGroup();
        ddlProductLineHeaderList_Event();
        GetAllReps();
    }

    protected void ddlRepGroupHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRepGroupHeaderList_Event();
        GetAllReps();
    }

    protected void ddlBranchHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlBranchHeaderList_Event();
        GetRepsForBranch();
    }

    protected void ddlRepHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlRepHeaderList.SelectedIndex > 0)
            {
                ObjBOL.Operation = 11;
                ObjBOL.RepGroupID = Int32.Parse(ddlRepHeaderList.SelectedValue);
                DataSet ds = new DataSet();
                ds = ObjBLL.GetBranchInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (ddlProductLineHeaderList.Items.FindByValue(row["ProductLineID"].ToString()) != null)
                    {
                        ddlProductLineHeaderList.SelectedValue = row["ProductLineID"].ToString();
                        ResetRepGroup();
                        ClearRepGroup();
                        ddlProductLineHeaderList_Event();
                        if (ddlRepGroupHeaderList.Items.FindByValue(row["RepGroupID"].ToString()) != null)
                        {
                            ddlRepGroupHeaderList.SelectedValue = row["RepGroupID"].ToString();
                            ddlRepGroupHeaderList_Event();
                            if (ddlBranchHeaderList.Items.FindByValue(row["BranchID"].ToString()) != null)
                            {
                                ddlBranchHeaderList.SelectedValue = row["BranchID"].ToString();
                                ddlBranchHeaderList_Event();
                            }
                        }
                    }
                }
            }
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave_Click_Event();
    }

    protected void btnOpenModal(object sender, EventArgs e)
    {
        try
        {
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlBranchHeaderList.SelectedIndex > 0)
            {
                if (ValidationCheck() == true)
                {
                    string msg = "";
                    ObjBOL.Operation = 9;
                    ObjBOL.BranchID = Convert.ToInt32(ddlBranchHeaderList.SelectedValue);
                    ObjBOL.FirstName = txtFirstName.Text;
                    ObjBOL.LastName = txtLastName.Text;
                    ObjBOL.Phone = txtPhone.Text;
                    ObjBOL.Email = txtEmail.Text;
                    ObjBOL.Status = ddlStatusAddList.SelectedValue;
                    ObjBOL.AbbreviationID = Convert.ToInt32(ddlAbbreviationAddList.SelectedValue);
                    msg = ObjBLL.SaveAndUpdate(ObjBOL);
                    if (msg.Trim() != "")
                    {
                        if (msg.Trim() == "ER01")
                        {
                            Utility.ShowMessage_Error(this, "Rep with the same name already exists for the branch !");
                            ModalPopupExtender1.Show();
                            return;
                        }
                        Utility.MaintainLogsSpecial("FrmManageReps", "Save", msg.Trim());
                        Utility.ShowMessage_Success(this, "Record Inserted Successfully !!");
                        ResetAddTable();
                        ModalPopupExtender1.Hide();
                        Bind_GVSalesRep();
                        BindControls();
                    }
                }
            }
            else
            {
                Utility.ShowMessage_Error(this, "Please Select Branch First !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnProposals_Click(object sender, EventArgs e)
    {
        try
        {
            //if (ddlSalesRep.SelectedIndex > 0)
            //{
            //    DataTable dt = new DataTable();
            //    rprt.Load(Server.MapPath("~/Reports/rptProposalsUnderConsultant.rpt"));
            //    clscon.Return_DT(dt, "EXEC [dbo].[Get_JobsUnderConsultant]  5," + ddlSalesRep.SelectedValue + "");
            //    rprt.SetDataSource(dt);
            //    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            //    rprt.Close();
            //    rprt.Dispose();
            //}
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
            //if (ddlSalesRep.SelectedIndex > 0)
            //{
            //    DataTable dt = new DataTable();
            //    rprt.Load(Server.MapPath("~/Reports/rptJobsUnderConsultant.rpt"));
            //    clscon.Return_DT(dt, "EXEC [dbo].[Get_JobsUnderConsultant]  6," + ddlSalesRep.SelectedValue + "");
            //    rprt.SetDataSource(dt);
            //    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            //    rprt.Close();
            //    rprt.Dispose();
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSalesRep_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
            int rowIndex = gvr.RowIndex;
            int salesRepID = Convert.ToInt32(gvSalesRep.DataKeys[rowIndex].Values[0]);

            if (e.CommandName == "Proposal")
            {
                DataTable dt = new DataTable();
                clscon.Return_DT(dt, "EXEC [dbo].[Get_JobsUnderConsultant]  5," + salesRepID + "");
                gvProposalAndProjectPopUpData.DataSource = dt;
                gvProposalAndProjectPopUpData.DataBind();
                ModalLabelHeader.Text = "Proposal Information";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "ProposalDialog", "openModal();", true);
            }
            else if (e.CommandName == "Project")
            {
                DataTable dt = new DataTable();
                clscon.Return_DT(dt, "EXEC [dbo].[Get_JobsUnderConsultant]  6," + salesRepID + "");
                gvProposalAndProjectPopUpData.DataSource = dt;
                gvProposalAndProjectPopUpData.DataBind();
                ModalLabelHeader.Text = "Project Information";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "ProjectDialog", "openModal();", true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSalesRep_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            gvSalesRep.EditIndex = e.NewEditIndex;
            Bind_GVSalesRep();
            DropDownList ddlAbbreviation = gvSalesRep.Rows[e.NewEditIndex].FindControl("ddlAbbreviation") as DropDownList;
            DropDownList ddlStatus = gvSalesRep.Rows[e.NewEditIndex].FindControl("ddlStatus") as DropDownList;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlAbbreviation, ds.Tables[0]);
                int ID = Convert.ToInt32(gvSalesRep.DataKeys[e.NewEditIndex].Value);

                ObjBOL.RepGroupID = ID;
                ObjBOL.Operation = 7;
                ds = ObjBLL.GetBranchInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlAbbreviation.SelectedValue = ds.Tables[0].Rows[0]["AbbreviationID"].ToString();
                    ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
                }

            }
            ddlAbbreviation.Focus();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSalesRep_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        try
        {
            int SalesRepID = Convert.ToInt32(gvSalesRep.DataKeys[e.RowIndex].Values[0]);
            string msg = "";
            ObjBOL.Operation = 10;
            ObjBOL.SalesRepID = SalesRepID;
            msg = ObjBLL.SaveAndUpdate(ObjBOL);
            if (msg.Trim() != "")
            {
                if (msg.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(this, "Projects exists for given rep !");
                }
                else
                {
                    Utility.MaintainLogsSpecial("FrmManageReps", "Delete", ddlBranchHeaderList.SelectedValue);
                    Utility.ShowMessage_Success(this, "Record Deleted Successfully !!");
                    Bind_GVSalesRep();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSalesRep_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = gvSalesRep.Rows[e.RowIndex];
            ObjBOL.Operation = 8;
            ObjBOL.SalesRepID = Convert.ToInt32(gvSalesRep.DataKeys[e.RowIndex].Values[0]);
            TextBox txtFirstNameGrid = (row.FindControl("txtFirstName") as TextBox);
            ObjBOL.FirstName = txtFirstNameGrid.Text;
            TextBox txtLastNameGrid = (row.FindControl("txtLastName") as TextBox);
            ObjBOL.LastName = txtLastNameGrid.Text;
            DropDownList ddlAbbGrid = (row.FindControl("ddlAbbreviation") as DropDownList);
            ObjBOL.AbbreviationID = Convert.ToInt32(ddlAbbGrid.SelectedValue);
            ObjBOL.Phone = (row.FindControl("txtPhone") as TextBox).Text;
            ObjBOL.Email = (row.FindControl("txtEmail") as TextBox).Text;
            DropDownList ddlStatusGrid = (row.FindControl("ddlStatus") as DropDownList);
            ObjBOL.Status = ddlStatusGrid.SelectedValue;
            if (txtFirstNameGrid.Text.Trim() == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter First Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter First Name. !");
                txtFirstNameGrid.Focus();
                return;
            }
            if (txtLastNameGrid.Text.Trim() == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter First Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Last Name. !");
                txtLastNameGrid.Focus();
                return;
            }
            if (ddlAbbGrid.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Abbrevation. !");
                ddlAbbGrid.Focus();
                return;
            }
            if (ddlStatusGrid.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                ddlStatusGrid.Focus();
                return;
            }
            msg = ObjBLL.SaveAndUpdate(ObjBOL);
            if (msg.Trim() != "")
            {
                if (msg.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(this, "Contact with the same name already exists for the branch !");
                    return;
                }
                gvSalesRep.EditIndex = -1;
                Utility.MaintainLogsSpecial("FrmManageReps", "Update", gvSalesRep.DataKeys[e.RowIndex].Values[0].ToString());
                Utility.ShowMessage_Success(this, "Record Updated Successfully !!");
                Bind_GVSalesRep();
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSalesRep_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        try
        {
            gvSalesRep.PageIndex = e.NewPageIndex;
            //bindtable
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSalesRep_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvSalesRep.EditIndex = -1;
            Bind_GVSalesRep();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Event Internal Functions

    private void ddlProductLineHeaderList_Event()
    {
        try
        {
            if (ddlProductLineHeaderList.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;//2
                ObjBOL.RepGroupID = Int32.Parse(ddlProductLineHeaderList.SelectedValue);
                ds = ObjBLL.GetBranchInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlRepGroupHeaderList, ds.Tables[0]);
                    ddlRepGroupHeaderList.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlRepGroupHeaderList_Event()
    {
        try
        {
            ClearBranch();
            ResetInfo();
            if (ddlRepGroupHeaderList.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 3;//3
                ObjBOL.BranchID = Convert.ToInt32(ddlRepGroupHeaderList.SelectedValue);
                ds = ObjBLL.GetBranchInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlBranchHeaderList, ds.Tables[0]);
                }
                else
                {
                    ClearBranch();
                    ResetInfo();
                }
            }
            else
            {
                ResetRepGroup();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlBranchHeaderList_Event()
    {
        try
        {
            if (ddlBranchHeaderList.SelectedIndex > 0)
            {
                //DataSet ds = new DataSet();
                //ObjBOL.Operation = 4;
                //ObjBOL.BranchID = Convert.ToInt32(ddlBranchHeaderList.SelectedValue);
                //ds = ObjBLL.GetBranchInformation(ObjBOL);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    txtBranchName.Text = Convert.ToString(ds.Tables[0].Rows[0]["BranchName"]);
                //    txtBranchLocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["BranchLocation"]);
                //    txtStrAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["BAddress"]);
                //}
                btnModalOpener.Enabled = true;
                btnSave.Text = "Update";
                Bind_GVSalesRep();
                btnModalOpener.Enabled = true;
            }
            else
            {
                ResetInfo();
                btnModalOpener.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnSave_Click_Event()
    {
        try
        {

        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void GetRepsForBranch()
    {
        try
        {
            if (ddlBranchHeaderList.SelectedIndex > 0)
            {
                ObjBOL.Operation = 12;
                ObjBOL.BranchID = Int32.Parse(ddlBranchHeaderList.SelectedValue);
                DataSet ds = new DataSet();
                ds = ObjBLL.GetBranchInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlRepHeaderList, ds.Tables[0]);
                    ddlRepHeaderList.SelectedIndex = 0;
                }
                else
                {
                    ddlRepHeaderList.Items.Clear();
                }
            }
            else
            {
                GetAllReps();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetAllReps()
    {
        try
        {
            ObjBOL.Operation = 13;
            DataSet ds = new DataSet();
            ds = ObjBLL.GetBranchInformation(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRepHeaderList, ds.Tables[0]);
                ddlRepHeaderList.SelectedIndex = 0;
            }
            else
            {
                ddlRepHeaderList.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Reset Functions

    private void Reset()
    {
        try
        {
            if (ddlProductLineHeaderList.Items.Count > 0)
            {
                ddlProductLineHeaderList.SelectedIndex = 0;
            }
            ddlRepGroupHeaderList.Items.Clear();
            ResetRepGroup();
            GetAllReps();
            btnModalOpener.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetRepGroup()
    {
        try
        {
            if (ddlRepGroupHeaderList.Items.Count > 0)
            {
                ddlRepGroupHeaderList.SelectedIndex = 0;
            }
            ClearBranch();
            ResetInfo();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetInfo()
    {
        try
        {
            if (ddlBranchHeaderList.Items.Count > 0)
            {
                ddlBranchHeaderList.SelectedIndex = 0;
            }
            //txtBranchName.Text = string.Empty;
            //txtBranchLocation.Text = string.Empty;
            //txtStrAddress.Text = string.Empty;
            btnSave.Text = "Save";
            gvSalesRep.DataSource = "";
            gvSalesRep.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearRepGroup()
    {
        try
        {
            ddlRepGroupHeaderList.Items.Clear();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearBranch()
    {
        try
        {
            ddlBranchHeaderList.Items.Clear();
            btnModalOpener.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetAddTable()
    {
        try
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ddlAbbreviationAddList.SelectedIndex = 0;
            ddlStatusAddList.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion       
}