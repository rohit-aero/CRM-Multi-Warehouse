using BLLAERO;
using BOLAERO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NACUFS_FrmCampus : System.Web.UI.Page
{
    BOLCampusListing ObjBOL = new BOLCampusListing();
    BLLCampuses ObjBLL = new BLLCampuses();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Controls();
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
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetCampusDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlUniv, ds.Tables[0]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCountry, ds.Tables[3]);
                Utility.BindDropDownList(ddlState, ds.Tables[2]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Campus(Int32 UniID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ObjBOL.id = UniID;
            ds = ObjBLL.GetCampusDetails(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCampus, ds.Tables[1]);
            }
            else
            {
                ddlCampus.DataSource = "";
                ddlCampus.DataBind();
            }
            if (ddlCampus.Items.Count == 0)
            {
                ResetContactDetails();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlUniv_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlUniv.Items.Count > 0)
            {
                ddlCampus.DataSource = "";
                ddlCampus.DataBind();
                ddlCountry.SelectedIndex = 0;
                ddlState.DataSource = "";
                ddlState.DataBind();
                ddlStateAb.DataSource = "";
                ddlStateAb.DataBind();
                txtCampus.Text = String.Empty;
                txtCity.Text = String.Empty;
                txtZipCode.Text = String.Empty;
                btnSave.Text = "Save";
            }
            Bind_Campus(Convert.ToInt32(ddlUniv.SelectedValue));
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        btnSave.Text = "Save";
    }
    private void Bind_State(Int32 Countryid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ObjBOL.CountryID = Countryid;
            ds = ObjBLL.GetCampusDetails(ObjBOL);
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlState, ds.Tables[2]);
            }
            else
            {
                ddlState.DataSource = "";
                ddlState.DataBind();
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlStateAb, ds.Tables[4]);
            }
            else
            {
                ddlStateAb.DataSource = "";
                ddlStateAb.DataBind();
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
            //ddlCountry.SelectedValue = ddlState.SelectedValue;
            Bind_State(Convert.ToInt32(ddlCountry.SelectedValue));
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
            if (ddlUniv.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select University. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select University. !");
                ddlUniv.Focus();
                return false;
            }
            if (txtCampus.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Campus Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Campus Name. !");
                txtCampus.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }


    protected void ddlCampus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCampus.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.CampusID = Convert.ToInt32(ddlCampus.SelectedValue);
                ds = ObjBLL.GetCampusDetails(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCampus.Text = Convert.ToString(ds.Tables[0].Rows[0]["CampusName"]);
                    txtCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]);
                    txtZipCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["PostalCode"]);
                    ddlCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CountryID"]);
                    Bind_State(Convert.ToInt16(ddlCountry.SelectedValue));
                    ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["StateID"]);
                    ddlStateAb.SelectedValue = ddlState.SelectedValue;
                    lblMsg.Text = "";
                    btnSave.Text = "Update";
                }
            }
            else
            {
                txtCampus.Text = "";
                ddlCountry.SelectedIndex = 0;
                ddlState.DataSource = "";
                ddlState.DataBind();
                ddlStateAb.DataSource = "";
                ddlStateAb.DataBind();
                txtCity.Text = "";
                txtZipCode.Text = "";
                btnSave.Text = "Save";
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
                if (ddlUniv.SelectedIndex > 0)
                {
                    ObjBOL.UniID = Convert.ToInt32(ddlUniv.SelectedValue);
                }
                else
                {
                    ObjBOL.UniID = 0;
                }

                ObjBOL.Operation = 3;
                if (ddlCampus.SelectedIndex > 0)
                {
                    ObjBOL.CampusID = Convert.ToInt32(ddlCampus.SelectedValue);
                }

                ObjBOL.CampusName = txtCampus.Text;
                ObjBOL.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                ObjBOL.StateID = Convert.ToInt32(ddlState.SelectedValue);
                ObjBOL.StateID = Convert.ToInt32(ddlStateAb.SelectedValue);
                ObjBOL.City = txtCity.Text;
                ObjBOL.PostalCode = txtZipCode.Text;
                msg = ObjBLL.SaveCampusDetails(ObjBOL);
                Utility.ShowMessage_Success(this, msg);
                Utility.MaintainLogs("FrmCampus.aspx", "Save");
                Bind_Controls();
                btnSave.Text = "Save";
                Reset();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void ResetContactDetails()
    {
        try
        {
            txtCampus.Text = "";
            ddlCountry.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            ddlStateAb.SelectedIndex = 0;
            txtCity.Text = "";
            txtZipCode.Text = "";
            btnSave.Text = "Save";

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
            ddlUniv.SelectedIndex = 0;
            ddlUniv.DataSource = "";
            ddlCampus.DataSource = "";
            ddlCampus.DataBind();
            ddlCountry.SelectedIndex = 0;
            ddlState.DataSource = "";
            ddlState.DataBind();
            ddlStateAb.DataSource = "";
            ddlStateAb.DataBind();
            txtCampus.Text = String.Empty;
            txtCity.Text = String.Empty;
            txtZipCode.Text = String.Empty;
            btnSave.Text = "Save";

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

    protected void ddlStateAb_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStateAb.SelectedIndex > 0)
        {
            ddlState.SelectedValue = ddlStateAb.SelectedValue;
        }
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlState.SelectedIndex > 0)
            {
                ddlStateAb.SelectedValue = ddlState.SelectedValue;
            }
            else
            {
                ddlStateAb.SelectedIndex = 0;
            }
        }

        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }
}