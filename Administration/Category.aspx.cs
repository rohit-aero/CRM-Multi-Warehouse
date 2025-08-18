using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Category : System.Web.UI.Page
{
    BOLCCT_Category objBOL = new BOLCCT_Category();
    BLLCCT_Category objBLL = new BLLCCT_Category();
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
            ds = objBLL.GetCCT_Category(objBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCategory, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCategory.SelectedIndex > 0)
            {
                hfCusId.Value = ddlCategory.SelectedValue;
                DataSet ds = new DataSet();
                objBOL.Operation = 3;
                objBOL.id = Convert.ToInt32(ddlCategory.SelectedValue);
                ds = objBLL.GetCCT_Category(objBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["name"]);
                    rdbStatus.SelectedValue = ds.Tables[0].Rows[0]["status"].ToString();
                    lblMsg.Text = "";
                    btnSave.Text = "Update";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["status"]) == 1)
                {
                    rdbStatus.SelectedValue = "1";
                }
                else
                {
                    rdbStatus.SelectedValue = "0";
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
            ddlCategory.SelectedIndex = 0;
            txtCategory.Text = "";
            lblMsg.Text = "";
            rdbStatus.SelectedIndex = -1;
            btnSave.Text = "Save";
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
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Category Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Category Name. !");
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
                if (ddlCategory.SelectedIndex > 0)
                {
                    objBOL.id = Convert.ToInt32(ddlCategory.SelectedValue);
                }
                else
                {
                    objBOL.id = 0;
                }
                objBOL.Operation = 2;
                objBOL.name = txtCategory.Text;
                objBOL.status = Convert.ToInt32(rdbStatus.SelectedValue);
                msg = objBLL.SaveCCT_Category(objBOL);
                if (msg.Trim() != "")
                {
                    if (msg != "ER1")
                    {
                        if (btnSave.Text == "Save")
                        {
                            hfCusId.Value = msg;
                            Utility.ShowMessage_Success(Page, "Records Added Successfully !!");
                            Utility.MaintainLogsSpecial("Category.aspx", "Save", msg);
                        }
                        else if (btnSave.Text == "Update")
                        {
                            hfCusId.Value = ddlCategory.SelectedValue;
                            Utility.ShowMessage_Success(Page, msg);
                            Utility.MaintainLogsSpecial("Category.aspx", "Update", ddlCategory.SelectedValue);
                        }
                        Bind_Controls();
                        Reset();
                    }
                    else
                    {
                        Utility.ShowMessage_Error(Page, "Record already exists !");
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

    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/CCT/frmCustomerCareTickets.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}