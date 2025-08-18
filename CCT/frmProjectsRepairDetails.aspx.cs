using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI.WebControls;

public partial class CCT_frmProjectsRepairDetails : System.Web.UI.Page
{
    BOLCustCareRepairForm ObjBOL = new BOLCustCareRepairForm();
    BLLManageProjectRepairDetails ObjBLL = new BLLManageProjectRepairDetails();
    commonclass1 cls = new commonclass1();
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
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;

            ds = ObjBLL.GetProjectRepairDetail(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlJobID, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectName, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlInstallationby, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlInstallatorA, ds.Tables[3]);
                Utility.BindDropDownList(ddlInstallatorB, ds.Tables[3]);
                Utility.BindDropDownList(ddlInstallorC, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlShipperID, ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConsultantRep, ds.Tables[5]);
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlOriginationRep, ds.Tables[6]);
            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDestinationRep, ds.Tables[7]);
            }
            if (ds.Tables[8].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDealer, ds.Tables[8]);
            }
            if (ds.Tables[9].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConsultant, ds.Tables[9]);
            }
            if (ds.Tables[10].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlHobartServiceBranch, ds.Tables[10]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Grid()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.TJobID = ddlJobID.SelectedItem.Text;
            ds = ObjBLL.DisplayTicketInformation(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvProjectRepairDetails.DataSource = ds;
                gvProjectRepairDetails.DataBind();
            }
            else
            {
                gvProjectRepairDetails.DataSource = "";
                gvProjectRepairDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetProjectData()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ObjBOL.TJobID = ddlJobID.SelectedItem.Text;
            ds = ObjBLL.DisplayJobInformation(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlConsultantRep.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ConsultRepID"]);
                ddlOriginationRep.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["OriginRepID"]);
                ddlDestinationRep.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["RepID"]);
                ddlDealer.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["DealerID"]);
                ddlConsultant.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ConsultantID"]);
                ddlInstallationby.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["InstallationBy"]);
                ddlInstallatorA.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["InstallatorA"]);
                txtInstallDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["InstallDate"].ToString()));
                ddlInstallatorB.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["InstallatorB"]);
                txtInstallationCompletionDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["InstallationCompletionDate"]));
                ddlInstallorC.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["InstallatorC"]);
                txtDemoDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["DemoDate"]));
                txtWarrantyStartDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["WarrantyStartDate"]));
                txtWarrantyEndDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["WarrantyEndDate"]));
                txtFollowUpDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["FollowUpDate"]));
                txtCustCarePackageSendDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["CustCarePackageSendDate"]));
                txtmanualDispatchDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["ManualDispatchDate"]));
                ddlShipperID.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ShipperID"]);
                txtShipDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["ShipDate"]));
                txtShipToArrive.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["ShipToArriveDate"]));
                txtArrivalDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["ArrivalDate"]));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void TicketGenerate()
    {
        try
        {
            string msg = "";
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.TJobID = ddlJobID.SelectedItem.Text;
            msg = ObjBLL.GetTicketDetails(ObjBOL);
            lblTicketNo.Text = msg;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlJobID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            PanelgvDisplay.Enabled = true;
            TicketGenerate();
            Bind_Grid();
            GetProjectData();
            ddlProjectName.SelectedValue = ddlJobID.SelectedValue;
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
            if (lblTicketNo.Text != "")
            {
                string msg = "";
                ObjBOL.Operation = 3;
                ObjBOL.TicketNo = lblTicketNo.Text;
                ObjBOL.TJobID = ddlJobID.SelectedItem.Text;
                ObjBOL.Task = ddlCategory.SelectedItem.Text;
                ObjBOL.Issue = txtIssue.Text;
                if (txtIssueopen.Text != "")
                {
                    ObjBOL.IssueOpenDate = Utility.ConvertDate(txtIssueopen.Text);
                }

                if (txtIssueClose.Text != "")
                {
                    ObjBOL.IssueCloseDate = Utility.ConvertDate(txtIssueClose.Text);
                }

                if (txtPromised.Text != "")
                {
                    ObjBOL.PromisedDate = Utility.ConvertDate(txtPromised.Text);
                }
                ObjBOL.Status = ddlstatus.SelectedItem.Text;
                ObjBOL.AssignTo = txtAssignedto.Text;

                if (txtFollowup.Text != "")
                {
                    ObjBOL.FollowUpDate = Utility.ConvertDate(txtFollowup.Text);
                }
                ObjBOL.ServicePO = txtServicePO.Text;
                ObjBOL.HobartServiceBranch = Convert.ToInt32(ddlHobartServiceBranch.SelectedValue);
                msg = ObjBLL.SaveTicketInformation(ObjBOL);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert(msg);", true);
                Utility.ShowMessage_Success(Page, msg);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvProjectRepairDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvProjectRepairDetails.EditIndex = e.NewEditIndex;
            Bind_Grid();
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            DropDownList ddlgvCategory = gvProjectRepairDetails.Rows[e.NewEditIndex].FindControl("ddlgvCategory") as DropDownList;
            Label lblCategorySelect = gvProjectRepairDetails.Rows[e.NewEditIndex].FindControl("lblCategorySelect") as Label;
            Label TicketNo = gvProjectRepairDetails.Rows[e.NewEditIndex].FindControl("lblgvTicketno") as Label;
            DropDownList ddlgvStatus = gvProjectRepairDetails.Rows[e.NewEditIndex].FindControl("ddlgvStatus") as DropDownList;
            Label lblStatusSelect = gvProjectRepairDetails.Rows[e.NewEditIndex].FindControl("lblStatusSelect") as Label;
            DropDownList ddlgvHobartServiceBranch = gvProjectRepairDetails.Rows[e.NewEditIndex].FindControl("ddlgvHobartServiceBranch") as DropDownList;
            Label lblHobartBarnchSelect = gvProjectRepairDetails.Rows[e.NewEditIndex].FindControl("lblHobartBarnchSelect") as Label;
            ObjBOL.TicketNo = TicketNo.Text;
            ds = ObjBLL.DisplayTicketInformationRowWise(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlgvHobartServiceBranch, ds.Tables[2]);
                ddlgvCategory.SelectedValue = lblCategorySelect.Text;
                ddlgvStatus.SelectedValue = lblStatusSelect.Text;
                ddlgvHobartServiceBranch.SelectedValue = lblHobartBarnchSelect.Text;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvProjectRepairDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvProjectRepairDetails.EditIndex = -1;
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvProjectRepairDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = gvProjectRepairDetails.Rows[e.RowIndex];
            ObjBOL.Operation = 3;
            ObjBOL.TJobID = ddlJobID.SelectedItem.Text;
            ObjBOL.TicketNo = (row.FindControl("lblgvTicketno") as Label).Text;
            ObjBOL.Task = (row.FindControl("ddlgvCategory") as DropDownList).SelectedValue;
            ObjBOL.Issue = (row.FindControl("txtgvIssue") as TextBox).Text;
            TextBox IssueOpenDate = row.FindControl("txtgvIssueOpen") as TextBox;
            ObjBOL.IssueOpenDate = Convert.ToDateTime(IssueOpenDate.Text);
            TextBox PromisedDate = row.FindControl("txtgvPromisedDate") as TextBox;
            ObjBOL.PromisedDate = Convert.ToDateTime(PromisedDate.Text);
            TextBox IssueCloseDate = row.FindControl("txtgvIssueClose") as TextBox;
            ObjBOL.IssueCloseDate = Convert.ToDateTime(IssueCloseDate.Text);
            ObjBOL.Status = (row.FindControl("ddlgvStatus") as DropDownList).SelectedValue;
            ObjBOL.AssignTo = (row.FindControl("txtgvAssignedTo") as TextBox).Text;
            TextBox FollowUpDate = row.FindControl("txtgvFollowup") as TextBox;
            ObjBOL.FollowUpDate = Convert.ToDateTime(FollowUpDate.Text);
            ObjBOL.ServicePO = (row.FindControl("txtgvServicePO") as TextBox).Text;
            ObjBOL.HobartServiceBranch = Convert.ToInt32((row.FindControl("ddlgvHobartServiceBranch") as DropDownList).SelectedValue);
            msg = ObjBLL.SaveTicketInformation(ObjBOL);
            gvProjectRepairDetails.EditIndex = -1;
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlProjectName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            PanelgvDisplay.Enabled = true;
            ddlJobID.SelectedValue = ddlProjectName.SelectedValue;
            TicketGenerate();
            Bind_Grid();
            GetProjectData();
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
            ddlJobID.SelectedIndex = 0;
            ddlProjectName.SelectedIndex = 0;
            ddlInstallationby.SelectedIndex = 0;
            ddlInstallatorA.SelectedIndex = 0;
            txtInstallDate.Text = String.Empty;
            ddlInstallatorB.SelectedIndex = 0;
            txtInstallationCompletionDate.Text = String.Empty;
            ddlInstallorC.SelectedIndex = 0;
            txtDemoDate.Text = String.Empty;
            txtWarrantyStartDate.Text = String.Empty;
            txtWarrantyEndDate.Text = String.Empty;
            txtFollowUpDate.Text = String.Empty;
            txtCustCarePackageSendDate.Text = String.Empty;
            txtmanualDispatchDate.Text = String.Empty;
            ddlShipperID.SelectedIndex = 0;
            txtShipToArrive.Text = String.Empty;
            txtArrivalDate.Text = String.Empty;
            ddlConsultantRep.SelectedIndex = 0;
            ddlOriginationRep.SelectedIndex = 0;
            ddlDestinationRep.SelectedIndex = 0;
            ddlDealer.SelectedIndex = 0;
            ddlConsultant.SelectedIndex = 0;
            lblTicketNo.Text = String.Empty;
            ddlCategory.SelectedIndex = 0;
            txtIssue.Text = String.Empty;
            txtIssueopen.Text = String.Empty;
            txtIssueClose.Text = String.Empty;
            txtPromised.Text = String.Empty;
            txtFollowup.Text = String.Empty;
            ddlstatus.SelectedIndex = 0;
            txtAssignedto.Text = String.Empty;
            txtServicePO.Text = String.Empty;
            ddlHobartServiceBranch.SelectedIndex = 0;
            gvProjectRepairDetails.DataSource = "";
            gvProjectRepairDetails.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
    }
}