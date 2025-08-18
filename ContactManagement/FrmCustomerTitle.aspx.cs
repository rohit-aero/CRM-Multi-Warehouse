using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
///  Proposal Form (06 December 2018) Rohit Kumar
/// </summary>
public partial class ContactManagement_FrmCustomerTitle : System.Web.UI.Page
{
    BOLManageCusTitle ObjBOL = new BOLManageCusTitle();
    BLLManageCustTitle ObjBLL = new BLLManageCustTitle();

    // Page load event
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

    /// <summary>
    /// Bind drop down in the form
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
                Utility.BindDropDownList(ddlFrmCustomerTitle, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// add mandatory check
    /// </summary>
    /// <returns></returns>       
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Title. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Title. !");
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
    /// Cancel controls
    /// </summary>
    // Reset all controls
    private void Reset()
    {
        try
        {
            ddlFrmCustomerTitle.SelectedIndex = 0;
            txtName.Text = string.Empty;
            lblMsg.Text = "";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Save data after entering mandatory fields
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
                if (ddlFrmCustomerTitle.SelectedIndex > 0)
                {
                    ObjBOL.ID = Convert.ToInt32(ddlFrmCustomerTitle.SelectedValue);
                }
                else
                {
                    ObjBOL.ID = 0;
                }
                ObjBOL.operation = 2;
                ObjBOL.Title = txtName.Text;
                msg = ObjBLL.SaveCustTitle(ObjBOL);
                if (ddlFrmCustomerTitle.SelectedIndex > 0)
                {
                    hfCusId.Value = ddlFrmCustomerTitle.SelectedValue;
                }
                else
                {
                    hfCusId.Value = msg;
                }
                Utility.ShowMessage_Success(this, msg);
                Utility.MaintainLogs("FrmCustomerTitle.aspx", "Save");
                Bind_Controls();
                Reset();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// cancel information in controls
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
    /// ddlFrmCustomerTitle selectedindexchanged
    /// display information on change of drop down customer
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlFrmCustomerTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlFrmCustomerTitle.SelectedIndex > 0)
            {
                hfCusId.Value = ddlFrmCustomerTitle.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.operation = 3;
                ObjBOL.ID = Convert.ToInt32(ddlFrmCustomerTitle.SelectedValue);
                ds = ObjBLL.GetCompetitor(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Title"]);
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