using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
///  Proposal Form (06 December 2018) Rohit Kumar
/// </summary>
public partial class ContactManagement_FrmCompetitor : System.Web.UI.Page
{
    BOLManageCompetitor ObjBOL = new BOLManageCompetitor();
    BLLManageCompetitor ObjBLL = new BLLManageCompetitor();
    // Page load event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Controls();
                if (string.IsNullOrEmpty(Request.QueryString["competitor"]) == false)
                {
                    ddlCompetitor.SelectedItem.Text = Request.QueryString["competitor"];
                    txtName.Text = Request.QueryString["competitor"];
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// prepare ddlcompetitor drop down lists
    /// </summary>
    // Bind all dropdownlist here
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 1;
            ds = ObjBLL.GetCompetitor(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCompetitor, ds.Tables[0]);
            }
            //if (Session["PNumber"] != null)
            //{

            //    btnBack.Enabled = true;
            //}
            //else
            //{
            //    btnBack.Enabled = false;
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// check mandatory fields
    /// </summary>
    /// <returns></returns>
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Competitor Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Competitor Name. !");
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
    /// cancel all the controls
    /// </summary>
    // Reset all controls
    private void Reset()
    {
        try
        {
            ddlCompetitor.SelectedIndex = 0;
            txtName.Text = string.Empty;
            lblMsg.Text = "";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Save records if all the mandatory
    /// data entered
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
                if (ddlCompetitor.SelectedIndex > 0)
                {
                    ObjBOL.CompetitorID = Convert.ToInt32(ddlCompetitor.SelectedValue);
                }
                else
                {
                    ObjBOL.CompetitorID = 0;
                }
                ObjBOL.operation = 2;
                ObjBOL.CompetitorName = txtName.Text;
                msg = ObjBLL.SaveCompetitor(ObjBOL);
                if (ddlCompetitor.SelectedIndex > 0)
                {
                    hfCusId.Value = ddlCompetitor.SelectedValue;
                }
                else
                {
                    hfCusId.Value = msg;
                }
                Utility.ShowMessage_Success(this, msg);
                Utility.MaintainLogs("FrmCompetitor.aspx", "Save");
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
    /// change of ddlCompetitor
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlCompetitor_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCompetitor.SelectedIndex > 0)
            {
                hfCusId.Value = ddlCompetitor.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.operation = 3;
                ObjBOL.CompetitorID = Convert.ToInt32(ddlCompetitor.SelectedValue);
                ds = ObjBLL.GetCompetitor(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompetitorName"]);
                    lblMsg.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}