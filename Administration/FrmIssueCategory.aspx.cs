using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLLAERO;
using System.Data;
using BOLAERO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_FrmIssueCategory : System.Web.UI.Page
{
    BOLIssueCategory objBOL = new BOLIssueCategory();
    BLLIssueCategory objBLL = new BLLIssueCategory();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Controls();
                Reset();
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
            objBOL.Operation = 1;
            ds = objBLL.GetIssueCategory(objBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlIssueCategory, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlIssueCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlIssueCategory.SelectedIndex > 0)
            {
                hfCusId.Value = ddlIssueCategory.SelectedValue;
                DataSet ds = new DataSet();
                objBOL.Operation = 3;
                objBOL.id = Convert.ToInt32(ddlIssueCategory.SelectedValue);
                ds = objBLL.GetIssueCategory(objBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["name"]);
                    rdbStatus.SelectedValue = ds.Tables[0].Rows[0]["status"].ToString();
                    lblMsg.Text = "";
                    btnSave.Text = "Update";
                }
                if (ds.Tables[0].Rows[0]["status"].ToString().Trim() != "")
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["status"]) == 1)
                    {
                        rdbStatus.SelectedValue = "1";
                    }
                    else
                    {
                        rdbStatus.SelectedValue = "0";
                    }
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

    private void Reset()
    {
        try
        {
            ddlIssueCategory.SelectedIndex = 0;
            txtCategory.Text = "";
            lblMsg.Text = "";
            btnSave.Text = "Save";
            rdbStatus.SelectedIndex = -1;
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
            if (txtCategory.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter IssueCategory Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Issue Category Name. !");
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                String msg = "";
                String msg1 = "";
                if (ddlIssueCategory.SelectedIndex > 0)
                {
                    objBOL.id = Convert.ToInt32(ddlIssueCategory.SelectedValue);
                }
                else
                {
                    objBOL.id = 0;
                }
                objBOL.Operation = 2;
                objBOL.name = txtCategory.Text;
                objBOL.status = Convert.ToInt32(rdbStatus.SelectedValue);
                msg = objBLL.SaveIssueCategory(objBOL);
                if (msg.Trim() != "")
                {

                    if (msg.Trim() == "ER1")
                    {
                        Utility.ShowMessage_Error(Page, "Record already exists!");
                    }
                    else
                    {
                        if (ddlIssueCategory.SelectedIndex > 0)
                        {
                            hfCusId.Value = ddlIssueCategory.SelectedValue;
                            msg1 = "Record Updated Successfully !!";
                        }
                        else
                        {
                            hfCusId.Value = msg;
                            msg1 = "Record Inserted Successfully !!";
                        }
                        Utility.MaintainLogsSpecial("FrmIssueCategory.aspx", btnSave.Text, hfCusId.Value);
                        Utility.ShowMessage_Success(this, msg1);
                        Bind_Controls();
                        Reset();
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
        try
        {
            Reset();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}

