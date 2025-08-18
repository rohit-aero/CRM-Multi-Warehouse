using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.IO;

public partial class Service_frmServiceProposals : System.Web.UI.Page
{
    BOLSerProposals ObjBOL = new BOLSerProposals();
    BLLManageSerProposals ObjBLL = new BLLManageSerProposals();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Controls();
            Bind_ControlsServicePNo();
        }
    }

    private void Bind_ControlsServicePNo()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ds = ObjBLL.GetSerProposalsControls(ObjBOL);
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPNumber, ds.Tables[2]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProductLine, ds.Tables[4]);
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
            ObjBOL.Operation = 2;
            ds = ObjBLL.GetSerProposalsControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlJobID, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlTechnician, ds.Tables[1]);
                Utility.BindDropDownList(ddlAssignedto, ds.Tables[3]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnNewPNo_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 1;
            msg = ObjBLL.GetSerProposals(ObjBOL);
            if (msg != "")
            {
                Reset();
                txtServicePNo.Text = msg;
            }
            else
            {
                txtServicePNo.Text = string.Empty;
            }
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
            ddlPNumber.SelectedIndex = 0;
            ddlProductLine.SelectedIndex = 0;
            txtPComments.Text = String.Empty;
            ddlJobID.SelectedIndex = 0;
            ddlAssignedto.SelectedIndex = 0;
            ddlTechnician.SelectedIndex = 0;
            txtAssessmentDate.Text = String.Empty;
            txtQuoteSentDate.Text = String.Empty;
            txtQuoteAmount.Text = String.Empty;
            ddlStatus.SelectedIndex = 0;
            ddlNature.SelectedIndex = 0;
            txtNetEqPrice.Text = String.Empty;
            txtDate.Text = String.Empty;
            txtRemarks.Text = String.Empty;
            txtServiceJNo.Text = string.Empty;
            gvProposalDetails.DataBind();
            gvProposalDetails.DataSource = "";
            btnSave.Text = "Save";
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
            if (txtServicePNo.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Generate Service P#. !");
                txtServicePNo.Focus();
                return false;
            }

            if (ddlProductLine.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Product Line First. !");
                ddlProductLine.Focus();
                return false;
            }

            if (ddlStatus.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                ddlStatus.Focus();
                return false;
            }

            if (ddlNature.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Nature of Task. !");
                ddlNature.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private Boolean ValidationCheckMember()
    {
        try
        {
            if (ddlPNumber.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, " Please Select Service Proposal !");
                ddlPNumber.Focus();
                return false;
            }

            if (txtDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Date !");
                txtDate.Focus();
                return false;
            }

            if (txtRemarks.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Remarks !");
                txtRemarks.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void SaveButton()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = "";
                if (btnSave.Text == "Save")
                {
                    ObjBOL.Operation = 3;
                }
                else
                {
                    ObjBOL.Operation = 5;
                    string[] serviceproposalno = ddlPNumber.SelectedValue.Split(',');
                    ObjBOL.SerProposal = serviceproposalno[0].ToString();
                }
                ObjBOL.PNo = txtServicePNo.Text;
                ObjBOL.ConveyorSpecID = Convert.ToInt32(ddlProductLine.SelectedValue);
                ObjBOL.Comments = txtPComments.Text;
                ObjBOL.RefJobID = ddlJobID.SelectedValue;
                if (ddlAssignedto.SelectedIndex > 0)
                {
                    ObjBOL.AssignedTo = Convert.ToInt32(ddlAssignedto.SelectedValue);
                }
                if (ddlTechnician.SelectedIndex > 0)
                {
                    ObjBOL.Technician = Convert.ToInt32(ddlTechnician.SelectedValue);
                }
                ObjBOL.AssessmentDate = Utility.ConvertDate(txtAssessmentDate.Text);
                ObjBOL.QuoteSentDate = Utility.ConvertDate(txtQuoteSentDate.Text);
                if (txtQuoteAmount.Text != "")
                {
                    ObjBOL.QuoteAmount = Convert.ToDecimal(txtQuoteAmount.Text);
                }
                ObjBOL.Status = Convert.ToInt32(ddlStatus.SelectedValue);
                ObjBOL.Nature = Convert.ToInt32(ddlNature.SelectedValue);
                msg = ObjBLL.SaveSerProposals(ObjBOL);
                if (msg.Trim() != "")
                {
                    if (btnSave.Text.ToLower().Trim() == "save")
                    {
                        Utility.MaintainLogsSpecial("FrmServiceProposals", "Save", msg.Trim());
                        Utility.ShowMessage_Success(Page, "Record Inserted Successfully !!");
                        Bind_ControlsServicePNo();
                        Reset();
                        txtServicePNo.Text = String.Empty;
                    }
                    else if (btnSave.Text.ToLower().Trim() == "update")
                    {
                        Utility.MaintainLogsSpecial("FrmServiceProposals", "Update", msg.Trim());
                        Utility.ShowMessage_Success(Page, "Record Updated Successfully !!");
                        txtDate.Text = String.Empty;
                        txtRemarks.Text = String.Empty;
                    }
                    Bind_Grid();
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
            SaveButton();
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
            txtServicePNo.Text = String.Empty;
            Reset();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPNumber.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 4;
                string[] pnumber = ddlPNumber.SelectedValue.Split(',');
                ObjBOL.PNo = pnumber[0].ToString();
                ds = ObjBLL.GetSerProposalsControls(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
                    {
                        { "ProposalNo", d => txtServicePNo.Text = d["ProposalNo"].ToString() },
                        { "ConveyorSpecID", d =>
                            {
                                if (ddlProductLine.Items.FindByValue(d["ConveyorSpecID"].ToString()) != null)
                                {
                                    ddlProductLine.SelectedValue = d["ConveyorSpecID"].ToString();
                                }
                            }
                        },
                        { "Comments", d => txtPComments.Text = d["Comments"].ToString() },
                        { "JNo", d => txtServiceJNo.Text = d["JNo"].ToString() },
                        { "RefJobID", d =>
                            {
                                if (ddlJobID.Items.FindByValue(d["RefJobID"].ToString()) != null)
                                {
                                    ddlJobID.SelectedValue = d["RefJobID"].ToString();
                                    GetNetEqPrice(ddlJobID.SelectedValue);
                                }
                            }
                        },
                        { "AssignedTo", d =>
                            {
                                if (ddlAssignedto.Items.FindByValue(d["AssignedTo"].ToString()) != null)
                                {
                                    ddlAssignedto.SelectedValue = d["AssignedTo"].ToString();
                                }
                            }
                        },
                        { "Technician", d =>
                            {
                                if (ddlTechnician.Items.FindByValue(d["Technician"].ToString()) != null)
                                {
                                    ddlTechnician.SelectedValue = d["Technician"].ToString();
                                }
                            }
                        },
                        { "AssessmentDate", d => txtAssessmentDate.Text = d["AssessmentDate"].ToString() },
                        { "QuoteSentDate", d => txtQuoteSentDate.Text = d["QuoteSentDate"].ToString() },
                        { "QuoteAmount", d => txtQuoteAmount.Text = Convert.ToDecimal(d["QuoteAmount"]).ToString("N") },
                        { "SerProposalStatus", d =>
                            {
                                if (ddlStatus.Items.FindByValue(d["SerProposalStatus"].ToString()) != null)
                                {
                                    ddlStatus.SelectedValue = d["SerProposalStatus"].ToString();
                                }
                            }
                        },
                        { "Nature", d =>
                            {
                                if (ddlNature.Items.FindByValue(d["Nature"].ToString()) != null)
                                {
                                    ddlNature.SelectedValue = d["Nature"].ToString();
                                }
                            }
                        }
                    };

                    foreach (var assignment in assignments)
                    {
                        try
                        {
                            assignment.Value(ds.Tables[0].Rows[0]);
                        }
                        catch (Exception ex)
                        {
                            Utility.AddEditException(ex, assignment.Key);
                        }
                    }

                    Bind_Grid();
                }
                btnSave.Text = "Update";
            }
            else
            {
                Reset();
                txtServicePNo.Text = String.Empty;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void imgJobID_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ddlJobID.SelectedIndex > 0)
            {
                string msg = "";
                ObjBOL.Operation = 6;
                ObjBOL.RefJobID = ddlJobID.SelectedValue;
                msg = ObjBLL.GetSerProposals(ObjBOL);
                if (msg != "")
                {
                    Session["CustomerID"] = "";
                    Session["CustomerID"] = msg;                   
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OpenWindow", "window.open('../ContactManagement/FrmCustomers.aspx','_blank')", true);
                }
            }
            else
            {
                Utility.ShowMessage_Error(this, "Ref Job ID not Found !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetNetEqPrice(string JobID)
    {
        try
        {
            if (JobID != "")
            {
                string msg = "";
                ObjBOL.Operation = 7;
                ObjBOL.RefJobID = ddlJobID.SelectedValue;
                msg = ObjBLL.GetSerProposals(ObjBOL);
                if (msg != "")
                {
                    txtNetEqPrice.Text = Convert.ToDecimal(msg).ToString("N");
                }
            }
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
            if (ddlJobID.SelectedIndex > 0)
            {
                GetNetEqPrice(ddlJobID.SelectedValue);
            }
            else
            {
                Utility.ShowMessage_Error(this, "Ref Job ID not Found !!");
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
            string[] pnumber = ddlPNumber.SelectedValue.Split(',');
            ObjBOL.Operation = 4;
            ObjBOL.PNo = pnumber[0].ToString();
            ds = ObjBLL.GetSerProposalsControls(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                gvProposalDetails.DataSource = ds.Tables[1];
                gvProposalDetails.DataBind();
            }
            else
            {
                gvProposalDetails.DataSource = "";
                gvProposalDetails.DataBind();
            }
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
            if (ValidationCheckMember())
            {
                string msg = string.Empty;
                ObjBOL.Operation = 12;
                ObjBOL.PNo = txtServicePNo.Text;
                ObjBOL.Date = Utility.ConvertDate(txtDate.Text);
                ObjBOL.SUMMARY = Convert.ToString(txtRemarks.Text);
                msg = ObjBLL.SaveSerProposals(ObjBOL);
                if (msg.Trim() != "")
                {
                    Utility.MaintainLogsSpecial("FrmServiceProposals", "Insert - Remarks", txtServicePNo.Text);
                    Utility.ShowMessage_Success(Page, "Record Inserted Successfully !!");
                    Bind_Grid();
                    txtDate.Text = String.Empty;
                    txtRemarks.Text = String.Empty;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvProposalDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvProposalDetails.EditIndex = -1;
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvProposalDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvProposalDetails.EditIndex = e.NewEditIndex;
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvProposalDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 9;
            GridViewRow row = gvProposalDetails.Rows[e.RowIndex];
            Int32 ID = Convert.ToInt32(gvProposalDetails.DataKeys[e.RowIndex].Value);
            ObjBOL.SerProposalDetailid = ID;
            msg = ObjBLL.DeleteSerProposals(ObjBOL);
            if (msg.Trim() != "")
            {
                Utility.MaintainLogsSpecial("FrmServiceProposals", "Delete - Remarks", txtServicePNo.Text);
                Utility.ShowMessage_Success(Page, "Record Deleted Successfully !!");
                Bind_Grid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvProposalDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            int ID = Convert.ToInt32(gvProposalDetails.DataKeys[e.RowIndex].Value);
            ObjBOL.Operation = 10;
            ObjBOL.SerProposalDetailid = ID;
            GridViewRow row = gvProposalDetails.Rows[e.RowIndex];
            int rowid = row.RowIndex;
            TextBox txtgvDate = row.FindControl("txtEditDate") as TextBox;
            TextBox txtgvSumm = row.FindControl("txtEditSummary") as TextBox;
            ObjBOL.Date = Utility.ConvertDate(txtgvDate.Text);
            ObjBOL.SUMMARY = txtgvSumm.Text;
            msg = ObjBLL.UpdateSerProposalDetail(ObjBOL);
            if (msg.Trim() != "")
            {
                Utility.MaintainLogsSpecial("FrmServiceProposals", "Update - Remarks", txtServicePNo.Text);
                Utility.ShowMessage_Success(Page, "Record Updated Successfully !!");
                gvProposalDetails.EditIndex = -1;
                Bind_Grid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void imgSJID_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (txtServicePNo.Text != "")
            {
                string msg = "";
                ObjBOL.Operation = 11;
                ObjBOL.RefJobID = txtServicePNo.Text;
                msg = ObjBLL.GetSerProposals(ObjBOL);
                if (msg != "")
                {
                    Session["SJID"] = "";
                    Session["SJID"] = msg;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OpenWindow", "window.open('../Service/frmServiceProjects.aspx','_blank')", true);
                }
            }
            else
            {
                Utility.ShowMessage_Error(this, "Ref Job ID not Found !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}