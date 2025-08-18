using System;
using BOLAERO;
using BLLAERO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CCT_FrmPostInstallFollowups : System.Web.UI.Page
{
    BLLPostInstallFollowups ObjBLL = new BLLPostInstallFollowups();
    BOLPostInstallFollowups ObjBOL = new BOLPostInstallFollowups();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ddlJobSearch.Enabled = false;
            SetDates();
            BindAllJobs();
        }
    }

    private void SetDates()
    {
        try
        {
            txtFromDate.Text = "01/01/" + DateTime.Now.Year;
            txtToDate.Text = "12/31/" + DateTime.Now.Year;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationCheck()
    {
        try
        {
            if (txtFromDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter the From Date !");
                txtFromDate.Focus();
                return false;
            }

            if (txtToDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter the To Date !");
                txtToDate.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void BindAllJobs()
    {
        try
        {
            ObjBOL.Operation = 7;
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlJobSearch, ds.Tables[0]);
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
            if (ValidationCheck())
            {
                Reset();
                ObjBOL.Operation = 1;
                ObjBOL.FromDate = Utility.ConvertDate(txtFromDate.Text);
                ObjBOL.ToDate = Utility.ConvertDate(txtToDate.Text);
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //ddlJobSearch.Enabled = true;
                    Utility.BindDropDownList(ddlJobSearch, ds.Tables[0]);
                }
                else
                {
                    ddlJobSearch.Items.Clear();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlJobSearch_SelectedIndexChanged_Event()
    {
        try
        {
            if (ddlJobSearch.SelectedIndex > 0)
            {
                ObjBOL.Operation = 2;
                ObjBOL.JobID = ddlJobSearch.SelectedValue;
                DataSet ds = new DataSet();
                ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
                    {
                        { "JobName", d => txtJob.Text = d["JobName"].ToString() },
                        { "City", d => txtCity.Text = d["City"].ToString() },
                        { "State", d => txtState.Text = d["State"].ToString() },
                        { "Country", d => txtCountry.Text = d["Country"].ToString() },
                        { "InstallationBy", d => txtInstallationBy.Text = d["InstallationBy"].ToString() },
                        { "InstallationEndDate", d => txtInstallationEndDate.Text = d["InstallationEndDate"].ToString() },
                        { "NetEqPrice", d => txtNetEqPrice.Text = Convert.ToDecimal(d["NetEqPrice"]).ToString("N") },
                        { "Freight", d => txtFreight.Text = Convert.ToDecimal(d["Freight"]).ToString("N") },
                        { "Installation", d => txtInstallation.Text =  Convert.ToDecimal(d["Installation"]).ToString("N") },
                        { "ExWarrantyPrice", d => txtExWarrantyPrice.Text = Convert.ToDecimal(d["ExWarrantyPrice"]).ToString("N") },
                        { "NetAmount", d => txtNetAmount.Text = Convert.ToDecimal(d["NetAmount"]).ToString("N") },
                        { "GST", d => txtHST.Text = Convert.ToDecimal(d["GST"]).ToString("N") },
                        { "TotalAmount", d => txtTotalAmount.Text = Convert.ToDecimal(d["TotalAmount"]).ToString("N") },
                        { "Models", d => txtModels.Text = d["Models"].ToString() }
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
                        gvCustomerMember.DataSource = ds.Tables[1];
                        gvCustomerMember.DataBind();
                    }
                    else
                    {
                        gvCustomerMember.DataSource = string.Empty;
                        gvCustomerMember.DataBind();
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        gvFollowup.DataSource = ds.Tables[2];
                        gvFollowup.DataBind();
                    }
                    else
                    {
                        gvFollowup.DataSource = EmptyDT();
                        gvFollowup.DataBind();
                        gvFollowup.Rows[0].Visible = false;
                    }
                }
            }
            else
            {
                ResetInfo();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlJobSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlJobSearch_SelectedIndexChanged_Event();
    }

    private void Reset()
    {
        try
        {
            ddlJobSearch.Items.Clear();
            //ddlJobSearch.Enabled = false;
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
            txtJob.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtInstallationBy.Text = string.Empty;
            txtInstallationEndDate.Text = string.Empty;
            txtNetEqPrice.Text = string.Empty;
            txtFreight.Text = string.Empty;
            txtInstallation.Text = string.Empty;
            txtExWarrantyPrice.Text = string.Empty;
            txtNetAmount.Text = string.Empty;
            txtHST.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            txtModels.Text = string.Empty;
            gvCustomerMember.DataSource = string.Empty;
            gvCustomerMember.DataBind();
            gvFollowup.DataSource = string.Empty;
            gvFollowup.DataBind();
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
            dtEmpty.Columns.Add("ID", typeof(Int32));
            dtEmpty.Columns.Add("FollowupWith", typeof(string));
            dtEmpty.Columns.Add("FollowupDate", typeof(DateTime));
            dtEmpty.Columns.Add("ScheduledFollowupDate", typeof(DateTime));
            dtEmpty.Columns.Add("Notes", typeof(string));
            dtEmpty.Columns.Add("FollowupType", typeof(string));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    protected void gvFollowup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvFollowup.PageIndex = e.NewPageIndex;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvFollowup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvFollowup.EditIndex = -1;
            ddlJobSearch_SelectedIndexChanged_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvFollowup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (ddlJobSearch.SelectedIndex > 0)
            {
                if (e.CommandName == "Insert")
                {
                    string msg = "";
                    DropDownList FollowUpWith = gvFollowup.FooterRow.FindControl("FddlFollowupwith") as DropDownList;
                    DropDownList FddlFollowupNature = gvFollowup.FooterRow.FindControl("FddlFollowupNature") as DropDownList;
                    TextBox FollowUpDate = gvFollowup.FooterRow.FindControl("FtxtFollowupDate") as TextBox;
                    TextBox NextFollowedUpDate = gvFollowup.FooterRow.FindControl("FtxtNextFollowedUpDate") as TextBox;
                    TextBox Notes = gvFollowup.FooterRow.FindControl("FtxtNotes") as TextBox;

                    if (FollowUpWith.SelectedIndex > 0)
                    {
                        ObjBOL.FollowupWith = FollowUpWith.SelectedValue;
                        ObjBOL.FollowupType = FddlFollowupNature.SelectedValue;

                        if (FollowUpDate.Text != "")
                        {
                            ObjBOL.FollowupDate = Utility.ConvertDate(FollowUpDate.Text);
                        }
                        else
                        {
                            msg = "Please Enter Followup Date !!";
                            Utility.ShowMessage_Error(Page, msg);
                            FollowUpDate.Focus();
                            return;
                        }

                        if (NextFollowedUpDate.Text != "")
                        {
                            ObjBOL.ScheduledFollowupDate = Utility.ConvertDate(NextFollowedUpDate.Text);
                        }
                        else
                        {
                            msg = "Please Enter Scheduled Followup Date !!";
                            Utility.ShowMessage_Error(Page, msg);
                            NextFollowedUpDate.Focus();
                            return;
                        }

                        if (Notes.Text.Trim() == "")
                        {
                            msg = "Please Enter Notes !!";
                            Utility.ShowMessage_Error(Page, msg);
                            Notes.Focus();
                            return;
                        }
                        else
                        {
                            ObjBOL.Notes = Notes.Text.Trim();
                        }
                        ObjBOL.Operation = 4;
                        ObjBOL.JobID = ddlJobSearch.SelectedValue;
                        msg = ObjBLL.Return_String(ObjBOL).Trim();
                        if (msg != "")
                        {
                            Utility.MaintainLogsSpecial("FrmPostInstallFollowups.aspx", "Save", ddlJobSearch.SelectedValue);
                            Utility.ShowMessage_Success(Page, "Record inserted successfully !!");
                            ddlJobSearch_SelectedIndexChanged_Event();
                        }
                    }
                    else
                    {
                        if (FollowUpWith.SelectedIndex == 0)
                        {
                            Utility.ShowMessage_Error(Page, "Please Select Followup With !!");
                            FollowUpWith.Focus();
                            return;
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

    protected void gvFollowup_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            Int32 ID = Convert.ToInt32(gvFollowup.DataKeys[e.RowIndex].Value);
            ObjBOL.Operation = 5;
            ObjBOL.ID = ID;
            msg = ObjBLL.Return_String(ObjBOL).Trim();
            if (msg != "")
            {
                Utility.MaintainLogsSpecial("FrmPostInstallFollowups.aspx", "Delete", ddlJobSearch.SelectedValue);
                Utility.ShowMessage_Success(Page, "Record deleted successfully !!");
                ddlJobSearch_SelectedIndexChanged_Event();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvFollowup_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvFollowup.EditIndex = e.NewEditIndex;
            ddlJobSearch_SelectedIndexChanged_Event();
            DropDownList FollowUpWith = gvFollowup.Rows[e.NewEditIndex].FindControl("ddlFollowupwith") as DropDownList;
            DropDownList FollowupType = gvFollowup.Rows[e.NewEditIndex].FindControl("ddlFollowupNature") as DropDownList;
            TextBox FollowUpDate = gvFollowup.Rows[e.NewEditIndex].FindControl("txtFollowupDate") as TextBox;
            TextBox NextFollowUpDate = gvFollowup.Rows[e.NewEditIndex].FindControl("txtNextFollowUpDate") as TextBox;
            TextBox Notes = gvFollowup.Rows[e.NewEditIndex].FindControl("txtNotes") as TextBox;

            ObjBOL.Operation = 3;
            ObjBOL.ID = Int32.Parse(gvFollowup.DataKeys[e.NewEditIndex].Value.ToString());
            DataSet ds = new DataSet();
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                FollowUpWith.SelectedValue = dr["FollowupWith"].ToString();
                FollowupType.SelectedValue = dr["FollowupType"].ToString();
                if (dr["FollowupDate"].ToString() != "")
                {
                    FollowUpDate.Text = dr["FollowupDate"].ToString();
                }

                if (dr["ScheduledFollowupDate"].ToString() != "")
                {
                    NextFollowUpDate.Text = dr["ScheduledFollowupDate"].ToString();
                }

                Notes.Text = dr["Notes"].ToString();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvFollowup_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            if (ddlJobSearch.SelectedIndex > 0)
            {
                string msg = "";
                GridViewRow row = gvFollowup.Rows[e.RowIndex];
                ObjBOL.Operation = 6;
                ObjBOL.ID = Convert.ToInt32(gvFollowup.DataKeys[e.RowIndex].Values[0]);
                DropDownList FollowUpWith = (row.FindControl("ddlFollowupwith") as DropDownList);
                DropDownList FddlFollowupNature = (row.FindControl("ddlFollowupNature") as DropDownList);

                if (FollowUpWith.SelectedIndex == 0)
                {
                    Utility.ShowMessage_Error(Page, "Please select Followup With !!");
                    FollowUpWith.Focus();
                    return;
                }

                //if (FddlFollowupNature.SelectedIndex == 0)
                //{
                //    Utility.ShowMessage_Error(Page, "Please select Followup Type !!");
                //    FddlFollowupNature.Focus();
                //    return;
                //}

                ObjBOL.FollowupWith = FollowUpWith.SelectedValue;
                ObjBOL.FollowupType = FddlFollowupNature.SelectedValue;

                TextBox FollowupDate_Textbox = row.FindControl("txtFollowupDate") as TextBox;
                TextBox ScheduledFollowupDate_Textbox = row.FindControl("txtNextFollowUpDate") as TextBox;

                string FollowupDate = FollowupDate_Textbox.Text;
                string NextFollowedupDate = ScheduledFollowupDate_Textbox.Text;
                if (FollowupDate != "")
                {
                    ObjBOL.FollowupDate = Utility.ConvertDate(FollowupDate);
                }
                else
                {
                    Utility.ShowMessage_Error(Page, msg);
                    FollowupDate_Textbox.Focus();
                    return;
                }

                if (NextFollowedupDate != "")
                {
                    ObjBOL.ScheduledFollowupDate = Utility.ConvertDate(NextFollowedupDate);
                }
                else
                {
                    Utility.ShowMessage_Error(Page, msg);
                    ScheduledFollowupDate_Textbox.Focus();
                    return;
                }

                TextBox txtnotes = row.FindControl("txtNotes") as TextBox;
                if (txtnotes.Text == "")
                {
                    msg = "Please Enter Notes !!";
                    Utility.ShowMessage_Error(Page, msg);
                    txtnotes.Focus();
                    return;
                }
                else
                {
                    ObjBOL.Notes = txtnotes.Text;
                }

                msg = ObjBLL.Return_String(ObjBOL).Trim();
                if (msg != "")
                {
                    Utility.MaintainLogsSpecial("FrmPostInstallFollowups.aspx", "Update", ddlJobSearch.SelectedValue);
                    Utility.ShowMessage_Success(Page, "Record updated successfully !!");
                    gvFollowup.EditIndex = -1;
                    ddlJobSearch_SelectedIndexChanged_Event();
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please Select Job !!");
                ddlJobSearch.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void FddlFollowupwith_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Reset();
            BindAllJobs();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}