using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.IO;

public partial class Service_frmServiceProjects : System.Web.UI.Page
{
    BOLSerProjects ObjBOL = new BOLSerProjects();
    BLLManageSerProjects ObjBLL = new BLLManageSerProjects();

    BOLSerProposals ObjBOLProposal = new BOLSerProposals();
    BLLManageSerProposals ObjBLLProposal = new BLLManageSerProposals();
    // Page load event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Controls();
                Bind_ControlsProposals();
                Bind_ControlServiceJob();
                if (Session["SJID"] != null)
                {
                    GetJbDetails(Session["SJID"].ToString());
                }
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
            ds = ObjBLL.GetSerProjectsControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPNo, ds.Tables[0]);
            }
            else
            {
                ddlPNo.Items.Clear();
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlAssignedto, ds.Tables[3]);
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

    private void Bind_ControlsProposals()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOLProposal.Operation = 2;
            ds = ObjBLLProposal.GetSerProposalsControls(ObjBOLProposal);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlTechnician, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_ControlServiceJob()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ds = ObjBLL.GetSerProjectsControls(ObjBOL);
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectJobID, ds.Tables[2]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnNewJob_Click(object sender, EventArgs e)
    {
        try
        {
            Reset();
            string msg = "";
            ObjBOL.Operation = 1;
            msg = ObjBLL.GetSerProjects(ObjBOL);
            if (msg != "")
            {
                txtJobid.Text = msg;
            }
            else
            {
                txtJobid.Text = String.Empty;
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
            if (txtJobid.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Generate Job ID First. !');", true);
                Utility.ShowMessage_Error(Page, "Please Generate Job ID First. !");
                txtJobid.Focus();
                return false;
            }
            if (ddlPNo.SelectedIndex <= 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Proposal No. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Proposal No. !");
                ddlPNo.Focus();
                return false;
            }
            if (txtPONumber.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter PO Number. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter PO Number. !");
                txtPONumber.Focus();
                return false;
            }
            if (txtPORecDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter PO Rec. date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter PO Rec. date. !");
                txtPORecDate.Focus();
                return false;
            }
            if (txtPOAmount.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter PO Amount. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter PO Amount. !");
                txtPOAmount.Focus();
                return false;
            }
            if (txtFollowUpDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Follow Up Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Follow Up Date. !");
                txtFollowUpDate.Focus();
                return false;
            }
            if (txtActual.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Actual Amount. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Actual Amount. !");
                txtActual.Focus();
                return false;
            }
            if (ddlAssignedto.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Assigned To. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Assigned To. !");
                ddlAssignedto.Focus();
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

    private Boolean ValidationCheckMember()
    {
        try
        {
            if (ddlProjectJobID.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, " Please Select Service Project !");
                ddlProjectJobID.Focus();
                return false;
            }

            if (txtDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Date !");
                txtDate.Focus();
                return false;
            }

            if (txtSerRemarks.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Remarks !");
                txtSerRemarks.Focus();
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
                    string[] jno = ddlProjectJobID.SelectedValue.Split(',');
                    ObjBOL.JobNo = jno[0].ToString();
                }
                //Project Controls Start
                ObjBOL.JNo = txtJobid.Text;
                ObjBOL.PNo = ddlPNo.SelectedValue;
                ObjBOL.SerProposal = ddlPNo.SelectedValue;
                ObjBOL.PORecDate = Utility.ConvertDate(txtPORecDate.Text);
                ObjBOL.POAmount = Convert.ToDecimal(txtPOAmount.Text);
                ObjBOL.PONo = txtPONumber.Text;
                ObjBOL.RepairDate = Utility.ConvertDate(txtRepairDate.Text);
                ObjBOL.FollowupDate = Utility.ConvertDate(txtFollowUpDate.Text);
                ObjBOL.AssignedTo = Convert.ToInt32(ddlAssignedto.SelectedValue);
                ObjBOL.InvoiceDate = Utility.ConvertDate(txtInvoiceDate.Text);
                ObjBOL.InvoiceNo = txtInvoiceNo.Text;
                ObjBOL.ActualAmount = Convert.ToDecimal(txtActual.Text);
                //Project Controls End

                //Proposal Controls Start
                ObjBOL.ConveyorSpecID = Convert.ToInt32(ddlProductLine.SelectedValue);
                ObjBOL.Comments = txtPComments.Text.Trim();
                if (ddlTechnician.SelectedIndex > 0)
                {
                    ObjBOL.Technician = Convert.ToInt32(ddlTechnician.SelectedValue);
                }
                ObjBOL.AssessmentDate = Utility.ConvertDate(txtAssessmentDate.Text);
                ObjBOL.QuoteSentDate = Utility.ConvertDate(txtQuoteSentDate.Text);
                ObjBOL.Status = Convert.ToInt32(ddlStatus.SelectedValue);
                if (txtQuoteAmount.Text != "")
                {
                    ObjBOL.QuoteAmount = Convert.ToDecimal(txtQuoteAmount.Text);
                }
                ObjBOL.Date = Utility.ConvertDate(txtDate.Text);

                //Proposal Controls End
                msg = ObjBLL.SaveSerProjects(ObjBOL);
                if (msg != "")
                {
                    if (btnSave.Text.ToLower().Trim() == "save")
                    {
                        Utility.MaintainLogsSpecial("FrmServiceProjects", "Save", msg.Trim());
                        Utility.ShowMessage_Success(Page, "Record Inserted Successfully !!");
                        Bind_Controls();
                        Bind_ControlServiceJob();
                        Reset();
                        txtJobid.Text = String.Empty;
                    }
                    else if (btnSave.Text.ToLower().Trim() == "update")
                    {
                        Utility.MaintainLogsSpecial("FrmServiceProjects", "Update", msg.Trim());
                        Utility.ShowMessage_Success(Page, "Record Updated Successfully !!");
                        txtDate.Text = String.Empty;
                        txtSerRemarks.Text = String.Empty;
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

    private void Reset()
    {
        try
        {
            ddlProjectJobID.SelectedIndex = 0;
            Bind_Controls();
            if (ddlPNo.Items.Count > 0)
            {
                ddlPNo.SelectedIndex = 0;
            }
            txtPComments.Text = string.Empty;
            txtPORecDate.Text = String.Empty;
            txtPOAmount.Text = String.Empty;
            txtPONumber.Text = String.Empty;
            txtRepairDate.Text = String.Empty;
            txtFollowUpDate.Text = String.Empty;
            ddlAssignedto.SelectedIndex = 0;
            txtInvoiceDate.Text = String.Empty;
            txtInvoiceNo.Text = String.Empty;
            txtActual.Text = String.Empty;
            txtProposalJobID.Text = String.Empty;
            txtActual.Text = String.Empty;
            // txtRemarks.Text = String.Empty;
            ddlTechnician.SelectedIndex = 0;
            txtAssessmentDate.Text = String.Empty;
            txtQuoteSentDate.Text = String.Empty;
            txtQuoteAmount.Text = String.Empty;
            txtNetEqPrice.Text = String.Empty;
            ddlStatus.SelectedIndex = 0;
            txtDate.Text = String.Empty;
            txtSerRemarks.Text = String.Empty;
            btnSave.Text = "Save";
            gvProposalDetails.DataSource = "";
            gvProposalDetails.DataBind();

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
            if (txtJobid.Text != "")
            {
                string msg = "";
                ObjBOLProposal.Operation = 6;
                string[] RefJobid = ddlProjectJobID.SelectedValue.Split(',');
                ObjBOLProposal.RefJobID = RefJobid[1].ToString().Trim();
                msg = ObjBLLProposal.GetSerProposals(ObjBOLProposal);
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Reset();
            txtJobid.Text = String.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlProjectJobID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlProjectJobID.SelectedIndex > 0)
            {
                GetJbDetails(ddlProjectJobID.SelectedValue);
            }
            else
            {
                Reset();
                txtJobid.Text = String.Empty;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetJbDetails(string SJID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ddlProjectJobID.SelectedValue = SJID;
            string[] Jobno = SJID.Split(',');
            ObjBOL.JNo = Jobno[0].ToString();
            ds = ObjBLL.GetSerProjectsControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
                    {
                        { "JNo", d =>
                            {
                                txtJobid.Text = d["JNo"].ToString();
                                Bind_Controls();
                            }
                        },
                        { "PNo", d =>
                            {
                                if (ddlPNo.Items.FindByValue(d["PNo"].ToString()) != null)
                                {
                                    ddlPNo.SelectedValue = d["PNo"].ToString();
                                    GetProposalInfo(ddlPNo.SelectedValue);
                                }
                            }
                        },
                        { "PORecDate", d => txtPORecDate.Text = d["PORecDate"].ToString() },
                        { "POAmount", d => txtPOAmount.Text = Convert.ToDecimal(d["POAmount"]).ToString("N") },
                        { "PONo", d => txtPONumber.Text = d["PONo"].ToString() },
                        { "RepairDate", d => txtRepairDate.Text = d["RepairDate"].ToString() },
                        { "FollowupDate", d => txtFollowUpDate.Text = d["FollowupDate"].ToString() },
                        { "InvoiceDate", d => txtInvoiceDate.Text = d["InvoiceDate"].ToString() },
                        { "InvoiceNo", d => txtInvoiceNo.Text = d["InvoiceNo"].ToString() },
                        { "ActualAmount", d => txtActual.Text = Convert.ToDecimal(d["ActualAmount"]).ToString("N") },
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
                btnSave.Text = "Update";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetProposalInfo(string ServicePNo)
    {
        try
        {
            if (ddlPNo.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOLProposal.Operation = 4;
                ObjBOLProposal.PNo = ServicePNo;
                ds = ObjBLLProposal.GetSerProposalsControls(ObjBOLProposal);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
                    {
                        { "ConveyorSpecID", d =>
                            {
                                if (ddlProductLine.Items.FindByValue(d["ConveyorSpecID"].ToString()) != null)
                                {
                                    ddlProductLine.SelectedValue = d["ConveyorSpecID"].ToString();
                                }
                            }
                        },
                        { "Comments", d => txtPComments.Text = d["Comments"].ToString() },
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
                        { "ProjectRefJobID", d => txtProposalJobID.Text = d["ProjectRefJobID"].ToString() },
                        { "NetEqPrice", d => txtNetEqPrice.Text = Convert.ToDecimal(d["NetEqPrice"]).ToString("N") },
                        { "SerProposalStatus", d =>
                            {
                                if (ddlStatus.Items.FindByValue(d["SerProposalStatus"].ToString()) != null)
                                {
                                    ddlStatus.SelectedValue = d["SerProposalStatus"].ToString();
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
            }
            else
            {
                ResetProposalInfo();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetProposalInfo()
    {
        try
        {
            ddlAssignedto.SelectedIndex = 0;
            ddlTechnician.SelectedIndex = 0;
            txtAssessmentDate.Text = String.Empty;
            txtQuoteSentDate.Text = String.Empty;
            txtQuoteAmount.Text = String.Empty;
            ddlStatus.SelectedIndex = 0;
            txtNetEqPrice.Text = String.Empty;
            ddlProductLine.SelectedIndex = 0;
            txtPComments.Text = String.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetProposalInfo(ddlPNo.SelectedValue);
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
                ObjBOL.Operation = 6;
                ObjBOL.PNo = ddlPNo.SelectedValue;
                ObjBOL.Date = Utility.ConvertDate(txtDate.Text);
                ObjBOL.SUMMARY = Convert.ToString(txtSerRemarks.Text);
                msg = ObjBLL.SaveSerProjects(ObjBOL);
                if (msg.Trim() != "")
                {
                    Utility.MaintainLogsSpecial("FrmServiceProjects", "Insert - Remarks", txtJobid.Text);
                    Utility.ShowMessage_Success(Page, "Record Inserted Successfully !!");
                    Bind_Grid();
                    txtDate.Text = String.Empty;
                    txtSerRemarks.Text = String.Empty;
                }
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
            string[] pnumber = ddlPNo.SelectedValue.Split(',');
            ObjBOLProposal.Operation = 4;
            ObjBOLProposal.PNo = pnumber[0].ToString();
            ds = ObjBLLProposal.GetSerProposalsControls(ObjBOLProposal);
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
            ObjBOLProposal.Operation = 9;
            GridViewRow row = gvProposalDetails.Rows[e.RowIndex];
            Int32 ID = Convert.ToInt32(gvProposalDetails.DataKeys[e.RowIndex].Value);
            ObjBOLProposal.SerProposalDetailid = ID;
            msg = ObjBLLProposal.DeleteSerProposals(ObjBOLProposal);
            if (msg.Trim() != "")
            {
                Utility.MaintainLogsSpecial("FrmServiceProjects", "Delete - Remarks", txtJobid.Text);
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
            ObjBOLProposal.Operation = 10;
            ObjBOLProposal.SerProposalDetailid = ID;
            GridViewRow row = gvProposalDetails.Rows[e.RowIndex];
            int rowid = row.RowIndex;
            TextBox txtgvDate = row.FindControl("txtEditDate") as TextBox;
            TextBox txtgvSumm = row.FindControl("txtEditSummary") as TextBox;
            ObjBOLProposal.Date = Utility.ConvertDate(txtgvDate.Text);
            ObjBOLProposal.SUMMARY = txtgvSumm.Text;
            msg = ObjBLLProposal.UpdateSerProposalDetail(ObjBOLProposal);
            if (msg.Trim() != "")
            {
                Utility.MaintainLogsSpecial("FrmServiceProjects", "Update - Remarks", txtJobid.Text);
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
}