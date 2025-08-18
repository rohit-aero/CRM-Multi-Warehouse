using BLLAERO;
using BOLAERO;
using System;
using System.Data;

public partial class TurboWash_FrmITWSize : System.Web.UI.Page
{
    BOLITWSize ObjBOL = new BOLITWSize();
    BLLITWSize ObjBLL = new BLLITWSize();
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
                Utility.BindDropDownList(ddlCategory, ds.Tables[0]);
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
            if (ddlCategory.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select category !");
                ddlCategory.Focus();
                return false;
            }

            if (txtSize.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Size !");
                txtSize.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void ddlSizeLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSizeLookupList_SelectedIndexChanged();
    }

    protected void ddlCategoryLookupList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCategoryLookupList_SelectedIndexChanged();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave_Click();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel_Click();
    }

    private void ddlCategoryLookupList_SelectedIndexChanged()
    {
        try
        {
            ResetInfo();
            if (ddlCategoryLookupList.SelectedIndex > 0)
            {
                ObjBOL.Operation = 2;
                ObjBOL.Category = Int32.Parse(ddlCategoryLookupList.SelectedValue);
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlSizeLookupList, ds.Tables[0]);
                }
                else
                {
                    ddlSizeLookupList.Items.Clear();
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

    private void ddlSizeLookupList_SelectedIndexChanged()
    {
        try
        {
            if (ddlSizeLookupList.SelectedIndex > 0)
            {
                ObjBOL.ID = Int32.Parse(ddlSizeLookupList.SelectedValue);

                ObjBOL.Operation = 3;
                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    if (ddlCategory.Items.FindByValue(dr["CategoryID"].ToString()) != null)
                    {
                        ddlCategory.SelectedValue = dr["CategoryID"].ToString();
                    }

                    txtSize.Text = dr["SizeName"].ToString();
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
                ResetInfo();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnSave_Click()
    {
        try
        {
            if (ValidationCheck())
            {
                string message = "Record inserted successfully !!";
                ObjBOL.Operation = 4;//insert
                if (ddlSizeLookupList.SelectedIndex > 0)
                {
                    ObjBOL.ID = Int32.Parse(ddlSizeLookupList.SelectedValue);
                    ObjBOL.Operation = 5;//update
                    message = "Record updated successfully !!";
                }

                if (ddlCategory.SelectedIndex > 0)
                {
                    ObjBOL.Category = Int32.Parse(ddlCategory.SelectedValue);
                }

                ObjBOL.Size = txtSize.Text;

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
                        Utility.ShowMessage_Error(Page, "Size for Category already exists !!");
                    }
                    else
                    {
                        Utility.MaintainLogsSpecial("FrmITWSize.aspx", btnSave.Text, returnStatus);
                        Utility.ShowMessage_Success(Page, message);
                        string category = ddlCategory.SelectedValue;                        
                        BindControls();
                        if (ddlCategoryLookupList.Items.FindByValue(category) != null)
                        {
                            ddlCategoryLookupList.SelectedValue = category;
                            ddlCategoryLookupList_SelectedIndexChanged();

                            if (ddlSizeLookupList.Items.FindByValue(returnStatus) != null)
                            {
                                ddlSizeLookupList.SelectedValue = returnStatus;
                                ddlSizeLookupList_SelectedIndexChanged();
                            }
                            else
                            {
                                btnCancel_Click();
                                Utility.ShowMessage_Error(Page, "unexpected error occured !!");
                            }
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

    private void btnCancel_Click()
    {
        try
        {
            ResetInfo();
            if (ddlCategoryLookupList.Items.Count > 0)
            {
                ddlCategoryLookupList.SelectedIndex = 0;
            }

            ddlSizeLookupList.Items.Clear();
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
            if (ddlCategory.Items.Count > 0)
            {
                ddlCategory.SelectedIndex = 0;
            }

            txtSize.Text = string.Empty;
            chkActive.Checked = false;
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}