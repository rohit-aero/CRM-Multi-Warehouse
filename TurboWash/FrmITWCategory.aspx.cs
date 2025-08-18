using BLLAERO;
using BOLAERO;
using System;
using System.Data;

public partial class TurboWash_FrmITWCategory : System.Web.UI.Page
{
    BOLITWCategory ObjBOL = new BOLITWCategory();
    BLLITWCategory ObjBLL = new BLLITWCategory();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
        }
    }

    private void BindControls()
    {
        try
        {
            ObjBOL.Operation = 1;
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCategoryLookupList, ds.Tables[0]);
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
            if (txtCategory.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Category !");
                txtCategory.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel_Click();
    }

    private void btnCancel_Click()
    {
        try
        {
            if (ddlCategoryLookupList.Items.Count > 0)
            {
                ddlCategoryLookupList.SelectedIndex = 0;
            }

            txtCategory.Text = string.Empty;
            chkOptionsApplicable.Checked = false;
            chkActive.Checked = false;
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave_Click();
    }

    private void btnSave_Click()
    {
        try
        {
            if (ValidationCheck())
            {
                string message = "Record inserted successfully !!";
                ObjBOL.Operation = 3;//insert
                if (ddlCategoryLookupList.SelectedIndex > 0)
                {
                    ObjBOL.ID = Int32.Parse(ddlCategoryLookupList.SelectedValue);
                    ObjBOL.Operation = 4;//update
                    message = "Record updated successfully !!";
                }
                ObjBOL.Category = txtCategory.Text;

                if (chkOptionsApplicable.Checked)
                {
                    ObjBOL.OptionsApplicable = true;
                }
                else
                {
                    ObjBOL.OptionsApplicable = false;
                }

                if (chkActive.Checked)
                {
                    ObjBOL.Active = true;
                }
                else
                {
                    ObjBOL.Active = false;
                }

                string returnStatus = ObjBLL.Return_String(ObjBOL).Trim();

                if (returnStatus.Length > 0)
                {
                    if (returnStatus == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "Category already exists !!");
                    }
                    else
                    {
                        Utility.MaintainLogsSpecial("FrmITWCategory.aspx", btnSave.Text, returnStatus);
                        Utility.ShowMessage_Success(Page, message);
                        BindControls();
                        if (ddlCategoryLookupList.Items.FindByValue(returnStatus) != null)
                        {
                            ddlCategoryLookupList.SelectedValue = returnStatus;
                            ddlCategoryLookupList_SelectedIndexChanged();
                        }
                        else
                        {
                            btnCancel_Click();
                            Utility.ShowMessage_Error(Page, "unexpected error occured !!");
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

    protected void ddlCategoryLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCategoryLookupList_SelectedIndexChanged();
    }

    private void ddlCategoryLookupList_SelectedIndexChanged()
    {
        try
        {
            if (ddlCategoryLookupList.SelectedIndex > 0)
            {
                ObjBOL.ID = Int32.Parse(ddlCategoryLookupList.SelectedValue);

                ObjBOL.Operation = 2;
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    txtCategory.Text = dr["name"].ToString();
                    bool optionApplicable;
                    bool.TryParse(dr["OptionApplicable"].ToString(), out optionApplicable);
                    if (optionApplicable)
                    {
                        chkOptionsApplicable.Checked = true;
                    }
                    else
                    {
                        chkOptionsApplicable.Checked = false;
                    }

                    bool Active;
                    bool.TryParse(dr["Active"].ToString(), out Active);
                    if (Active)
                    {
                        chkActive.Checked = true;
                    }
                    else
                    {
                        chkActive.Checked = false;
                    }
                    btnSave.Text = "Update";
                }
            }
            else
            {
                btnCancel_Click();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}