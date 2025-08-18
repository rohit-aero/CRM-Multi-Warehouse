using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using BLLAERO;
using BOLAERO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_FrmModels : System.Web.UI.Page
{
    BOLManageModel ObjBOL = new BOLManageModel();
    BLLManageModel ObjBLL = new BLLManageModel();
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

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetModel(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlModels, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlModels_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlModels.SelectedIndex > 0)
            {
                hfCusId.Value = ddlModels.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.Operation = 3;
                ObjBOL.ModelID = Convert.ToInt32(ddlModels.SelectedValue);
                ds = ObjBLL.GetModel(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ModelName"]);
                    txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["ModelDescription"]);
                    lblMsg.Text = "";
                    btnSave.Text = "Update";
                    Utility.MaintainLogs("FrmModels.aspx", "Save");
                }
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Model Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Model Name. !");
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

    private void Reset()
    {
        try
        {
            ddlModels.SelectedIndex = 0;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            lblMsg.Text = "";
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                String msg = "";
                if (ddlModels.SelectedIndex > 0)
                {
                    ObjBOL.ModelID = Convert.ToInt32(ddlModels.SelectedValue);
                }
                else
                {
                    ObjBOL.ModelID = 0;
                }
                ObjBOL.Operation = 2;
                ObjBOL.ModelName = txtName.Text;
                ObjBOL.ModelDescription = txtDescription.Text;
                msg = ObjBLL.SaveModel(ObjBOL);
                if (ddlModels.SelectedIndex > 0)
                {
                    hfCusId.Value = ddlModels.SelectedValue;
                }
                else
                {
                    hfCusId.Value = msg;
                }
                Utility.ShowMessage_Success(this, msg);
                Bind_Controls();
                Reset();
                btnSave.Text = "Save";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}
