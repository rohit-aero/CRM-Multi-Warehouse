using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
///  Proposal Form (06 December 2018) Rohit Kumar
/// </summary>
public partial class Administration_FrmCountry : System.Web.UI.Page
{
    BOLManageCountry ObjBOL = new BOLManageCountry();
    BLLManageCountry ObjBLL = new BLLManageCountry();

    // Page load event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Controls();
                if (string.IsNullOrEmpty(Request.QueryString["country"]) == false)
                {
                    ddlCountry.SelectedValue = Request.QueryString["CountryID"];
                    txtName.Text = Request.QueryString["country"];
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
    /// <summary>
    /// Bind_Control() function prepare dropdown ddlcountry
    /// </summary>
    // Bind all dropdownlist here
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 1;
            ds = ObjBLL.GetCountry(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCountry, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// mandatory fields check
    /// </summary>
    /// <returns></returns>

    private Boolean ValidationCheck()
    {
        try
        {
            if (txtName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Country Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Country Name. !");
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
    /// <summary>
    /// Cancel all controls
    /// </summary>
    // Reset all controls
    private void Reset()
    {
        try
        {
            ddlCountry.SelectedIndex = 0;
            txtName.Text = string.Empty;
            lblMsg.Text = "";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// After entering valid fields 
    /// data save in the database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Save data
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = "";
                if (ddlCountry.SelectedIndex > 0)
                {
                    ObjBOL.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                }
                else
                {
                    ObjBOL.CountryID = 0;
                }
                ObjBOL.operation = 2;
                ObjBOL.Country = txtName.Text;
                msg = ObjBLL.SaveCountry(ObjBOL);
                if (ddlCountry.SelectedIndex > 0)
                {
                    hfCusId.Value = ddlCountry.SelectedValue;
                }
                else
                {
                    hfCusId.Value = msg;
                }
                Utility.ShowMessage_Success(this, msg);
                Utility.MaintainLogs("FrmCountry.aspx", "Save");
                Bind_Controls();
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
    /// <summary>
    /// after change on ddlcountry values
    /// data fill in the form below
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCountry.SelectedIndex > 0)
            {
                hfCusId.Value = ddlCountry.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.operation = 3;
                ObjBOL.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                ds = ObjBLL.GetCountry(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Country"]);
                    lblMsg.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// back to the proposal page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

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
}