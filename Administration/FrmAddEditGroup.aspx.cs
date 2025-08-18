using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
///  (18 April 2019) Rohit Kumar
/// </summary>
public partial class Administration_FrmAddEditGroup : System.Web.UI.Page
{
    BOLManageUserGroup ObjBOL = new BOLManageUserGroup();
    BLLManageUserGroup ObjBLL = new BLLManageUserGroup();

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

    // Bind all dropdownlist here
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 1;
            ds = ObjBLL.GetUserGroup(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlGroup, ds.Tables[0]);
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
            if (txtName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter City Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter City Name. !");
                txtName.Focus();
                return false;
            }
            if (ddlStatus.SelectedIndex <= 0)
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

    // Reset all controls
    private void Reset()
    {
        try
        {
            ddlGroup.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
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
                if (ddlGroup.SelectedIndex > 0)
                {
                    ObjBOL.id = Convert.ToInt32(ddlGroup.SelectedValue);
                }
                else
                {
                    ObjBOL.id = 0;
                }
                ObjBOL.operation = 2;
                ObjBOL.name = txtName.Text;
                ObjBOL.description = txtDescription.Text;
                if (ddlStatus.SelectedValue == "1")
                {
                    ObjBOL.status = true;
                }
                else
                {
                    ObjBOL.status = false;
                }

                msg = ObjBLL.SaveUserGroup(ObjBOL);
                if (ddlGroup.SelectedIndex > 0)
                {
                    hfCusId.Value = ddlGroup.SelectedValue;
                }
                else
                {
                    hfCusId.Value = msg;
                }
                Utility.ShowMessage_Success(this, msg);
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

    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlGroup.SelectedIndex > 0)
            {
                btnSave.Text = "Update";
                hfCusId.Value = ddlGroup.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.operation = 3;
                ObjBOL.id = Convert.ToInt32(ddlGroup.SelectedValue);
                ds = ObjBLL.GetUserGroup(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["name"]);
                    txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["description"]);
                    Boolean sts = Convert.ToBoolean(ds.Tables[0].Rows[0]["status"]);
                    if (sts == true)
                    { ddlStatus.SelectedValue = "1"; }
                    else
                    { ddlStatus.SelectedValue = "2"; }
                    lblMsg.Text = "";
                }
            }
            else
            {
                Reset();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}