using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
///  Proposal Form (06 December 2018) Rohit Kumar
/// </summary>
public partial class Administration_FrmCity : System.Web.UI.Page
{
    BOLManageCity ObjBOL = new BOLManageCity();
    BLLManageCity ObjBLL = new BLLManageCity();

    // Page load event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Controls();

            if (string.IsNullOrEmpty(Request.QueryString["city"]) == false)
            {
                ddlCity.SelectedItem.Text = Request.QueryString["city"];
                txtName.Text = Request.QueryString["city"];
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
    /// <summary>
    /// Prepare drop down list ddlCity
    /// </summary>
    // Bind all dropdownlist here
    private void Bind_Controls()
    {
        DataSet ds = new DataSet();
        ObjBOL.operation = 1;
        ds = ObjBLL.GetCity(ObjBOL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Utility.BindDropDownList(ddlCity, ds.Tables[0]);
        }
    }
    /// <summary>
    /// Mandetory fields check
    /// </summary>
    /// <returns></returns>
    private Boolean ValidationCheck()
    {
        if (txtName.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter City Name. !');", true);
            Utility.ShowMessage_Error(Page, "Please Enter City Name. !");
            txtName.Focus();
            return false;
        }

        return true;
    }
    /// <summary>
    /// clear controls
    /// </summary>
    // Reset all controls
    private void Reset()
    {
        ddlCity.SelectedIndex = 0;
        txtName.Text = string.Empty;
        lblMsg.Text = "";
    }
    /// <summary>
    /// Save infromation if mandetory fields
    /// entered in page controls
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Save data
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidationCheck() == true)
        {
            string msg = "";
            if (ddlCity.SelectedIndex > 0)
            {
                ObjBOL.CityID = Convert.ToInt32(ddlCity.SelectedValue);
            }
            else
            {
                ObjBOL.CityID = 0;
            }
            ObjBOL.operation = 2;
            ObjBOL.CityName = txtName.Text;
            msg = ObjBLL.SaveCity(ObjBOL);
            if (ddlCity.SelectedIndex > 0)
            {
                hfCusId.Value = ddlCity.SelectedValue;
            }
            else
            {
                hfCusId.Value = msg;
            }
            Utility.ShowMessage_Success(this, msg);
            Utility.MaintainLogs("FrmCity.aspx", "Save");
            Bind_Controls();
            Reset();
        }
    }
    /// <summary>
    /// Cancel information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Cancel command
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
    }
    /// <summary>
    /// Cancel all the information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCity.SelectedIndex > 0)
            {
                hfCusId.Value = ddlCity.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.operation = 3;
                ObjBOL.CityID = Convert.ToInt32(ddlCity.SelectedValue);
                ds = ObjBLL.GetCity(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CityName"]);
                    lblMsg.Text = "";
                }
            }
        }

        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
            //Utility.ShowMessage(Page, ex.ToString());
            //throw ex;
        }
    }
    /// <summary>
    /// Back to the Proposal Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SalesManagement/FrmProposals.aspx");
    }
}