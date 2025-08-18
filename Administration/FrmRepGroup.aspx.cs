using BLLAERO;
using BOLAERO;
using System;
using System.Data;
using System.Web.UI;

public partial class Administration_FrmRepGroup : System.Web.UI.Page
{
    BOLManageRepGroup ObjBOL = new BOLManageRepGroup();
    BLLManageRepGroup ObjBLL = new BLLManageRepGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                CANCEL_ButtonPolicy();
                Bind_Controls();
                if (string.IsNullOrEmpty(Request.QueryString["Rep"]) == false)
                {
                    ddlRepGroupHeaderList.SelectedItem.Text = Request.QueryString["Rep"];
                    txtName.Text = Request.QueryString["Rep"];
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #region Bind Functions

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 1;
            ds = ObjBLL.GetRepGroup(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProductLineHeaderList, ds.Tables[0]);
                Utility.BindDropDownList(ddlProductLine, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPM, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Validation

    private Boolean ValidationCheck()
    {
        try
        {
            if (ddlProductLine.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select ProductLine !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Business Division !");
                ddlProductLine.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter RepGroup Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Rep Group Name. !");
                txtName.Focus();
                return false;
            }

            if(chkHobart.Checked == false && chkStero.Checked == false)
            {
                Utility.ShowMessage_Error(Page, "Please Select Hobart Or Stero in checkbox !");
                chkHobart.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    #endregion

    #region Event Functions like ddlRepGroup_SelectedIndexChanged, btnSave_Click etc

    protected void ddlRepGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlRepGroupHeaderList.SelectedIndex > 0)
            {
                LookUpPolicy();
                hfCusId.Value = ddlRepGroupHeaderList.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.operation = 3;
                ObjBOL.ID = Convert.ToInt32(ddlRepGroupHeaderList.SelectedValue);
                ds = ObjBLL.GetRepGroup(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                    //txtSortOrder.Text = ds.Tables[0].Rows[0]["SortOrder"].ToString();
                    ddlProductLine.SelectedValue = ds.Tables[0].Rows[0]["ProductLineID"].ToString();
                    ddlPM.SelectedValue = ds.Tables[0].Rows[0]["pmid"].ToString();
                    Boolean HobartGroup = Convert.ToBoolean(ds.Tables[0].Rows[0]["HobartGroup"]);
                    if (HobartGroup)
                    {
                        chkHobart.Checked = true;
                    }
                    else
                    {
                        chkHobart.Checked = false;
                    }
                    Boolean SteroGroup = Convert.ToBoolean(ds.Tables[0].Rows[0]["SteroGroup"]);
                    if (SteroGroup)
                    {
                        chkStero.Checked = true;
                    }
                    else
                    {
                        chkStero.Checked = false;
                    }
                    lblMsg.Text = "";
                    //EnableForUpdate_Legacy();                   
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]) == 1)
                {
                    IsActive.SelectedValue = "1";
                }
                else
                {
                    IsActive.SelectedValue = "0";
                }
            }
            else
            {
                ResetInfo();
                CANCEL_ButtonPolicy();
            }
        }
        catch (Exception ex)
        {
            //lblMsg.Text = ex.ToString();
            Utility.AddEditException(ex);
        }
    }

    protected void ddlProductLineList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetInfo();
            ClearRepGroup();
            ProductLineEvent();
        }
        catch (Exception ex)
        {
            //lblMsg.Text = ex.ToString();
            Utility.AddEditException(ex);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string returnStatus = "";
                if (ddlRepGroupHeaderList.SelectedIndex > 0)
                {
                    ObjBOL.ID = Convert.ToInt32(ddlRepGroupHeaderList.SelectedValue);
                }
                else
                {
                    ObjBOL.ID = 0;
                }
                ObjBOL.operation = 2;
                ObjBOL.Name = txtName.Text;
                //ObjBOL.SortOrder = Convert.ToInt32(txtSortOrder.Text);
                ObjBOL.ProductLineID = Convert.ToInt32(ddlProductLine.SelectedValue);
                ObjBOL.pmid = Convert.ToInt32(ddlPM.SelectedValue);
                if (IsActive.SelectedValue == "1")
                {
                    ObjBOL.IsActive = true;
                }
                else
                {
                    ObjBOL.IsActive = false;
                }

                if (chkHobart.Checked == true)
                {
                    ObjBOL.HobartGroup = true;
                }
                else
                {
                    ObjBOL.HobartGroup = false;
                }

                if (chkStero.Checked == true)
                {
                    ObjBOL.SteroGroup = true;
                }
                else
                {
                    ObjBOL.SteroGroup = false;
                }

                returnStatus = ObjBLL.SaveRepGroup(ObjBOL);

                if (returnStatus.Length > 0)
                {
                    if (returnStatus.Trim() == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "Rep Group with same already exists !!");
                        return;
                    }
                    if (ddlRepGroupHeaderList.SelectedIndex > 0)
                    {
                        hfCusId.Value = ddlRepGroupHeaderList.SelectedValue;
                    }
                    else
                    {
                        hfCusId.Value = returnStatus.Trim();
                    }
                    ClearRepGroup();
                    ddlProductLineHeaderList.SelectedValue = ddlProductLine.SelectedValue;
                    ProductLineEvent();
                    ddlRepGroupHeaderList.SelectedValue = returnStatus.Trim();
                    //EnableForUpdate_Legacy();
                    LookUpPolicy();
                    if (ObjBOL.ID > 0)
                    {
                        Utility.MaintainLogsSpecial("FrmRepGroup.aspx", "Update", ObjBOL.ID.ToString());
                        Utility.ShowMessage_Success(Page, "Data Updated Successfully !!");
                    }
                    else
                    {
                        Utility.MaintainLogsSpecial("FrmRepGroup.aspx", "Save", returnStatus);
                        Utility.ShowMessage_Success(Page, "Data Inserted Successfully !!");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblMsg.Text = ex.ToString();
            Utility.AddEditException(ex);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ADD_ButtonPolicy();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        EDIT_ButtonPolicy();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
        CANCEL_ButtonPolicy();
    }

    #endregion

    #region Event Functions

    private void ProductLineEvent()
    {
        try
        {
            CANCEL_ButtonPolicy();
            if (ddlProductLineHeaderList.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.operation = 4;
                ObjBOL.ProductLineID = Int32.Parse(ddlProductLineHeaderList.SelectedValue);
                ds = ObjBLL.GetRepGroup(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlRepGroupHeaderList, ds.Tables[0]);
                    ddlRepGroupHeaderList.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region enable/disable policies

    private void EnableForNewEntry_Legacy()
    {
        try
        {
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableForUpdate_Legacy()
    {
        try
        {
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CANCEL_ButtonPolicy()
    {
        try
        {
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            DisableEntryFields();
            btnAdd.Enabled = true;
            EnableLookUps();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ADD_ButtonPolicy()
    {
        try
        {
            btnEdit.Enabled = false;
            btnAdd.Enabled = false;
            DisableLookUps();
            btnSave.Enabled = true;
            EnableEntryFields();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EDIT_ButtonPolicy()
    {
        try
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            EnableEntryFields();
            btnSave.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableEntryFields()
    {
        try
        {
            ddlProductLine.Enabled = false;
            txtName.Enabled = false;
            // txtSortOrder.Enabled = false;
            IsActive.Enabled = false;
            ddlPM.Enabled = false;
            chkHobart.Enabled = false;
            chkStero.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableEntryFields()
    {
        try
        {
            ddlProductLine.Enabled = true;
            txtName.Enabled = true;
            // txtSortOrder.Enabled = true;
            IsActive.Enabled = true;
            ddlPM.Enabled = true;
            chkHobart.Enabled = true;
            chkStero.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableLookUps()
    {
        try
        {
            ddlProductLineHeaderList.Enabled = true;
            ddlRepGroupHeaderList.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableLookUps()
    {
        try
        {
            ddlProductLineHeaderList.Enabled = false;
            ddlRepGroupHeaderList.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void LookUpPolicy()
    {
        try
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            DisableEntryFields();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Resets

    private void Reset()
    {
        try
        {
            if (ddlProductLineHeaderList.Items.Count > 1)
            {
                ddlProductLineHeaderList.SelectedIndex = 0;
            }

            ResetInfo();
            ClearRepGroup();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearRepGroup()
    {
        try
        {
            if (ddlRepGroupHeaderList.Items.Count > 0)
            {
                //ddlRepGroupHeaderList.DataSource = "";
                //ddlRepGroupHeaderList.DataBind();
                ddlRepGroupHeaderList.Items.Clear();
            }
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
            if (ddlRepGroupHeaderList.Items.Count > 1)
            {
                ddlRepGroupHeaderList.SelectedIndex = 0;
            }
            txtName.Text = string.Empty;
            //txtSortOrder.Text = string.Empty;
            ddlProductLine.SelectedIndex = 0;
            IsActive.SelectedIndex = -1;
            lblMsg.Text = "";
            ddlPM.SelectedIndex = 0;
            chkHobart.Checked = false;
            chkStero.Checked = false;
            //EnableForNewEntry_Legacy();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion
}