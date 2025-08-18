using BLLAERO;
using BOLAERO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Service_FrmAwSchedule : System.Web.UI.Page
{
    BOLSchedule ObjBOL = new BOLSchedule();
    BLLSchedule ObjBLL = new BLLSchedule();
    BOLScheduleDetails ObjBOLDetails = new BOLScheduleDetails();
    BLLScheduleDetails ObjBLLDetails = new BLLScheduleDetails();
    commonclass1 cls = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Dropdowns();
        }
    }
    private void Bind_Dropdowns()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetScheduleData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddljobid, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {

                Utility.BindDropDownList(ddljobname, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {

                Utility.BindDropDownList(ddlNesting, ds.Tables[2]);
                Utility.BindDropDownList(ddlLaser, ds.Tables[2]);
                Utility.BindDropDownList(ddlForming, ds.Tables[2]);
                Utility.BindDropDownList(ddlWelding, ds.Tables[2]);
                Utility.BindDropDownList(ddlPolishing, ds.Tables[2]);
                Utility.BindDropDownList(ddlShipping, ds.Tables[2]);
                Utility.BindDropDownList(ddlStatus, ds.Tables[2]);
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
            if (ddljobid.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select  JobID. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select  JobID. !");
                ddljobid.Focus();
                return false;
            }
            if (txtRequiredshipdate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Required Ship Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Required Ship Date. !");
                txtRequiredshipdate.Focus();
                return false;
            }
            if (ddlStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select  Satus. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select  Satus. !");
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
    private Boolean ValidationCheckDetails()
    {
        try
        {
            if (ddljobid.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select  JobID. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select  JobID. !");
                ddljobid.Focus();
                return false;
            }
            if (txtRequiredshipdate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Required Ship Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Required Ship Date. !");
                txtRequiredshipdate.Focus();
                return false;
            }
            if (ddlStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select  Satus. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select  Satus. !");
                ddlStatus.Focus();
                return false;
            }
            if (txtPackNo.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Pack No. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Pack No. !");
                txtPackNo.Focus();
                return false;
            }
            if (txtPartNo.Text == "")
            {
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Part#. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Part#. !");
                txtPartNo.Focus();
                return false;
            }
            if (txtPartDescription.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Part Description. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Part Description. !");
                txtPartDescription.Focus();
                return false;
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }
    private void ResetSchedule()
    {
        try
        {
            //ddljobid.SelectedIndex = 0;
            //ddljobname.SelectedIndex = 0;
            ddlNesting.SelectedIndex = 0;
            ddlLaser.SelectedIndex = 0;
            ddlForming.SelectedIndex = 0;
            ddlWelding.SelectedIndex = 0;
            ddlPolishing.SelectedIndex = 0;
            ddlShipping.SelectedIndex = 0;
            ddlShipping.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            txtRequiredshipdate.Text = String.Empty;
            txtRleaseDate.Text = String.Empty;
            txtPackNo.Text = String.Empty;
            txtPartNo.Text = String.Empty;
            txtPartDescription.Text = String.Empty;
            btnSave.Text = "Save";
            lblMsg.Text = "";
            DataTable dt = new DataTable();
            gvMember.DataSource = dt;
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
            ddljobid.SelectedIndex = 0;
            ddljobname.SelectedIndex = 0;
            ddlNesting.SelectedIndex = 0;
            ddlLaser.SelectedIndex = 0;
            ddlForming.SelectedIndex = 0;
            ddlWelding.SelectedIndex = 0;
            ddlPolishing.SelectedIndex = 0;
            ddlShipping.SelectedIndex = 0;
            ddlShipping.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            txtRequiredshipdate.Text = String.Empty;
            txtRleaseDate.Text = String.Empty;
            txtPackNo.Text = String.Empty;
            txtPartNo.Text = String.Empty;
            txtPartDescription.Text = String.Empty;
            btnSave.Text = "Save";
            lblMsg.Text = "";
            DataTable dt = new DataTable();
            gvMember.DataSource = dt;
            gvMember.DataBind();
            gvMember.EmptyDataText = "";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void ResetDetails()
    {
        try
        {
            txtPackNo.Text = string.Empty;
            txtPartNo.Text = string.Empty;
            txtPartDescription.Text = string.Empty;
            txtRleaseDate.Text = string.Empty;
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }
    protected void ddljobid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddljobid.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 3;
                ObjBOL.JobID = Convert.ToString(ddljobid.SelectedValue);
                ds = ObjBLL.GetScheduleData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddljobname.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["JobID"]);
                }
            }
            ResetSchedule();
            FillScheduleDetail();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void ddljobname_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddljobname.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.JobID = Convert.ToString(ddljobname.SelectedValue);
                ds = ObjBLL.GetScheduleData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddljobid.SelectedValue = ds.Tables[0].Rows[0]["JobID"].ToString();
                }
            }
            else
            {
                ddljobid.SelectedIndex = 0;
            }
            ResetSchedule();
            FillScheduleDetail();

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void FillScheduleDetail()
    {
        try
        {
            if (ddljobid.SelectedIndex > 0)
            {

                hfCusId.Value = ddljobid.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.Operation = 4;
                ObjBOL.JobID = Convert.ToString(ddljobid.SelectedValue);
                ds = ObjBLL.GetSchedule(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnSave.Text = "Update";
                    txtRequiredshipdate.Text = cls.Converter(ds.Tables[0].Rows[0]["ReqShipDate"].ToString());
                    // txtRequiredshipdate.Text = ds.Tables[0].Rows[0]["ReqShipDate"].ToString();
                    ddlStatus.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                    ddlNesting.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["NestingStatus"]);
                    ddlLaser.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["LaserStatus"]);
                    ddlForming.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["FormingStatus"]);
                    ddlWelding.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["WeldingStatus"]);
                    ddlPolishing.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PolishingStatus"]);
                    ddlShipping.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ShippingStatus"]);
                    lblMsg.Text = "";

                }


                if (ds.Tables[1].Rows.Count > 0)
                {
                    gvMember.DataSource = ds.Tables[1];
                    gvMember.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    gvMember.DataSource = dt;
                    gvMember.DataBind();

                }
            }
            else
            {
                gvMember.AllowPaging = false;
                gvMember.DataSource = "";
                gvMember.DataBind();
                Reset();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void Bind_Schedule()
    {
        try
        {

            ObjBOLDetails.Operation = 4;
            // ObjBOLDetails.JobID = Convert.ToString(hfCusId.Value);
            ObjBOLDetails.JobID = Convert.ToString(hfCusId.Value);
            DataSet ds = new DataSet();
            ds = ObjBLLDetails.GetScheduleDetails(ObjBOLDetails);
            if (ds.Tables[1].Rows.Count > 0)
            {
                gvMember.DataSource = ds.Tables[1];
                gvMember.DataBind();
            }
            else
            {
                gvMember.AllowPaging = false;
                gvMember.DataSource = "";
                gvMember.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidationCheck() == true)
        {

            string msg = "";
            if (btnSave.Text == "Update")
            {
                ObjBOL.JobID = Convert.ToString(ddljobid.SelectedValue);
                ObjBOL.ID = 1;
            }
            else
            {
                ObjBOL.JobID = Convert.ToString(ddljobid.SelectedValue);
                ObjBOL.ID = 0;
            }

            ObjBOL.Operation = 5;
            ObjBOL.ReqShipDate = Utility.ConvertDate(txtRequiredshipdate.Text);
            ObjBOL.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            ObjBOL.NestingStatus = Convert.ToInt32(ddlNesting.SelectedValue);
            ObjBOL.LaserStatus = Convert.ToInt32(ddlLaser.SelectedValue);
            ObjBOL.FormingStatus = Convert.ToInt32(ddlForming.SelectedValue);
            ObjBOL.WeldingStatus = Convert.ToInt32(ddlWelding.SelectedValue);
            ObjBOL.PolishingStatus = Convert.ToInt32(ddlPolishing.SelectedValue);
            ObjBOL.ShippingStatus = Convert.ToInt32(ddlShipping.SelectedValue);
            msg = ObjBLL.SaveSchedule(ObjBOL);
            if (ddljobid.SelectedIndex > 0)
            {
                hfCusId.Value = ddljobid.SelectedValue;
            }
            else
            {
                hfCusId.Value = msg;
            }
            Utility.ShowMessage_Success(this, msg);

            Reset();
            ResetDetails();
            btnSave.Text = "Save";
        }
    }

    protected void btnaddSchedule_click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheckDetails() == true)
            {
                if (hfCusId.Value != "-1")
                {

                    string msg = "";
                    ObjBOLDetails.Operation = 6;
                    //  ObjBOL.JobID = Convert.ToString(ddljobid.SelectedValue);
                    ObjBOLDetails.JobID = Convert.ToString(ddljobid.SelectedValue);
                    ObjBOLDetails.PackNo = txtPackNo.Text;
                    ObjBOLDetails.PartNumber = txtPartNo.Text;
                    ObjBOLDetails.PartDescription = txtPartDescription.Text;
                    ObjBOLDetails.ReleaseDate = Utility.ConvertDate(txtRleaseDate.Text);
                    msg = ObjBLLDetails.SaveScheduleDetails(ObjBOLDetails);
                    Utility.ShowMessage_Success(this, msg);
                    Bind_Schedule();
                    ResetDetails();
                }

                else
                {
                    Utility.ShowMessage_Error(this, "please enter Schedule detail first !!");
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void gvMember_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        try
        {
            int ID = Convert.ToInt32(gvMember.DataKeys[e.RowIndex].Values[0]);
            string msg = "";
            ObjBOLDetails.Operation = 7;
            ObjBOLDetails.ID = ID;
            // ObjBOLDetails.JobID = Convert.ToString(hfCusId.Value);
            msg = ObjBLLDetails.DeleteScheduleDetails(ObjBOLDetails);
            Utility.ShowMessage_Success(this, "Details Deleted Successfully !!!");
            Bind_Schedule();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void gvMember_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            gvMember.EditIndex = e.NewEditIndex;
            Bind_Schedule();
            DataSet ds = new DataSet();
            ds = ObjBLL.GetSchedule(ObjBOL);

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void gvMember_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = gvMember.Rows[e.RowIndex];
            ObjBOLDetails.Operation = 8;
            ObjBOLDetails.ID = Convert.ToInt32(gvMember.DataKeys[e.RowIndex].Values[0]);
            ObjBOLDetails.PackNo = (row.FindControl("txtPackNo") as TextBox).Text;
            ObjBOLDetails.PartNumber = (row.FindControl("txtPartNo") as TextBox).Text;
            ObjBOLDetails.PartDescription = (row.FindControl("txtPartDescription") as TextBox).Text;
            TextBox ReleaseDate = row.FindControl("txtRleaseDate") as TextBox;
            ObjBOLDetails.ReleaseDate = Convert.ToDateTime(ReleaseDate.Text);
            msg = ObjBLLDetails.SaveScheduleDetails(ObjBOLDetails);
            Utility.ShowMessage_Success(this, "Details Updated Successfully !!!");
            gvMember.EditIndex = -1;
            Bind_Schedule();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void gvMember_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        try
        {
            gvMember.PageIndex = e.NewPageIndex;
            Bind_Schedule();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void gvMember_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvMember.EditIndex = -1;
            Bind_Schedule();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
        ResetDetails();
    }

}