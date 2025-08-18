using BLLAERO;
using BOLAERO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalesManagement_FrmShopDwgIssueLog_Category : System.Web.UI.Page
{
    BOLShopDrawingCategory ObjBOL = new BOLShopDrawingCategory();
    BLLShopDrawingCategory ObjBLL = new BLLShopDrawingCategory();
    string formName = "FrmShopDwgIssueLog_Category.aspx";
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
                Utility.BindDropDownList(ddlCategoryLookup, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationCheck()
    {
        try
        {
            if (txtCategory.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter category !!");
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
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
                string message = "Record saved successfully !!";
                ObjBOL.Operation = 3;
                if (ddlCategoryLookup.SelectedIndex > 0)
                {
                    ObjBOL.Operation = 4;
                    ObjBOL.ID = Int32.Parse(ddlCategoryLookup.SelectedValue);
                    message = "Record update successfully !!";
                }

                ObjBOL.Category = txtCategory.Text;
                if (rdbActive.SelectedValue == "2")
                {
                    ObjBOL.Active = true;
                }
                else
                {
                    ObjBOL.Active = false;
                }

                string returnStatus = ObjBLL.Return_String(ObjBOL);

                if (returnStatus.Trim().Length > 0)
                {
                    if (returnStatus.Trim() == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "Duplicate record found !!");
                        return;
                    }
                    Utility.ShowMessage_Success(Page, message);
                    Utility.MaintainLogsSpecial(formName, btnSave.Text, returnStatus);
                    BindControls();
                    if (ddlCategoryLookup.Items.FindByValue(returnStatus) != null)
                    {
                        ddlCategoryLookup.SelectedValue = returnStatus;
                        ddlCategoryLookup_SelectedIndexChanged();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel_Click();
    }

    private void btnCancel_Click()
    {
        try
        {
            if (ddlCategoryLookup.SelectedIndex > 0)
            {
                ddlCategoryLookup.SelectedIndex = 0;
            }
            ResetInfo();
            btnSave.Text = "Save";
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
            txtCategory.Text = string.Empty;
            rdbActive.SelectedValue = "2";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCategoryLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCategoryLookup_SelectedIndexChanged();
    }

    private void ddlCategoryLookup_SelectedIndexChanged()
    {
        try
        {
            ResetInfo();
            if (ddlCategoryLookup.SelectedIndex > 0)
            {
                ObjBOL.Operation = 2;
                ObjBOL.ID = Int32.Parse(ddlCategoryLookup.SelectedValue);

                DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                    rdbActive.SelectedValue = ds.Tables[0].Rows[0]["Active"].ToString();
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