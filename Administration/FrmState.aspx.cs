using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
///  Proposal Form (06 December 2018) Rohit Kumar
/// </summary>
public partial class Administration_FrmState : System.Web.UI.Page
{
    BOLManageState ObjBOL = new BOLManageState();
    BLLManageState ObjBLL = new BLLManageState();

    // Page load event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Controls();
                if (string.IsNullOrEmpty(Request.QueryString["State"]) == false)
                {
                    ddlCountry.SelectedValue = Request.QueryString["CountryID"];
                    ddlCountryState.SelectedValue = Request.QueryString["CountryID"];
                    Bind_State(Convert.ToInt32(ddlCountry.SelectedValue));
                    ddlState.SelectedValue = Request.QueryString["StateID"];
                    txtName.Text = Request.QueryString["State"];
                    txtAbb.Text = Request.QueryString["StateAbb"];
                }
                if (Session["PNumber"] != null)
                {

                    btnBack.Enabled = true;
                }
                else
                {
                    btnBack.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    // Bind all dropdownlist here
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 1;
            ds = ObjBLL.GetState(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCountry, ds.Tables[0]);
                Utility.BindDropDownList(ddlCountryState, ds.Tables[0]);
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
            if (ddlCountryState.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Country. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Country. !");
                ddlCountryState.Focus();
                return false;
            }
            if (txtName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter State Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter State Name. !");
                txtName.Focus();
                return false;
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }


        return true;
    }

    // Reset all controls
    private void Reset()
    {
        try
        {
            ddlCountry.SelectedIndex = 0;
            ddlCountryState.SelectedIndex = 0;
            if (ddlState.Items.Count > 0)
            {
                ddlState.Items.Clear();
            }
            txtName.Text = string.Empty;
            txtAbb.Text = string.Empty;
            btnSave.Text = "Save";
            lblMsg.Text = "";
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    // Save data
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = "";
                ObjBOL.operation = 2;
                if (btnSave.Text == "Update")
                {
                    if (ddlState.SelectedIndex > 0)
                    {
                        ObjBOL.StateID = Convert.ToInt32(ddlState.SelectedValue);
                    }
                }
                else if (btnSave.Text == "Save")
                {
                    ddlState.SelectedValue = "0";
                }
                ObjBOL.CountryID = Convert.ToInt32(ddlCountryState.SelectedValue);
                ObjBOL.State = txtName.Text;
                ObjBOL.Sabb = txtAbb.Text;
                msg = ObjBLL.SaveState(ObjBOL);
                if (ddlState.SelectedIndex > 0)
                {
                    hfCusId.Value = ddlState.SelectedValue;
                }
                else
                {
                    hfCusId.Value = msg;
                }
                Utility.ShowMessage_Success(this, msg);
                Utility.MaintainLogs("FrmState.aspx", "Save");
                Bind_Controls();
                Bind_State(Convert.ToInt32(ddlCountryState.SelectedValue));
                Reset();
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    // Cancel command
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

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlState.SelectedIndex > 0)
            {
                hfCusId.Value = ddlState.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.operation = 3;
                ObjBOL.StateID = Convert.ToInt32(ddlState.SelectedValue);
                ds = ObjBLL.GetState(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlCountryState.SelectedValue = ds.Tables[0].Rows[0]["CountryID"].ToString();
                    txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["State"]);
                    txtAbb.Text = Convert.ToString(ds.Tables[0].Rows[0]["Sabb"]);
                    lblMsg.Text = "";
                    btnSave.Text = "Update";
                }
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }




    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/SalesManagement/FrmProposals.aspx");
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    private void Bind_State(Int32 CountryID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 4;
            ObjBOL.CountryID = CountryID;
            ds = ObjBLL.GetState(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlState, ds.Tables[0]);
                txtName.Text = String.Empty;
                txtAbb.Text = String.Empty;
            }
            else
            {
                if (ddlState.Items.Count > 0)
                {
                    ddlState.Items.Clear();
                }
                txtName.Text = String.Empty;
                txtAbb.Text = String.Empty;
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlCountryState.SelectedValue = ddlCountry.SelectedValue;
            Bind_State(Convert.ToInt32(ddlCountryState.SelectedValue));
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void ddlCountryState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Bind_State(Convert.ToInt32(ddlCountryState.SelectedValue));
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }
}