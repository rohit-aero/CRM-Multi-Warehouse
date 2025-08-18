using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;

public partial class Administration_ConveyorType : System.Web.UI.Page
{
    BOLManageConveyor objBOL = new BOLManageConveyor();
    BLLManageConveyor objBLL = new BLLManageConveyor();
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
            objBOL.Operation = 1;
            ds = objBLL.GetConveyor(objBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConveyor, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    protected void ddlConveyor_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlConveyor.SelectedIndex > 0)
            {
                HfConveyorTypeId.Value = ddlConveyor.SelectedValue;
                DataSet ds = new DataSet();
                objBOL.Operation = 3;
                objBOL.ConveyorTypeID = Convert.ToInt32(ddlConveyor.SelectedValue);
                ds = objBLL.GetConveyor(objBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ConveyorType"]);
                    lblMsg.Text = "";
                    btnSave.Text = "Update";
                    Utility.MaintainLogs("ConveyorType.aspx", "Save");
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
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Conveyor Type. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Conveyor Type. !");
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                String msg = "";
                if (ddlConveyor.SelectedIndex > 0)
                {
                    objBOL.ConveyorTypeID = Convert.ToInt32(ddlConveyor.SelectedValue);
                }
                else
                {
                    objBOL.ConveyorTypeID = 0;
                }
                objBOL.Operation = 2;
                objBOL.ConveyorType = txtName.Text;
                msg = objBLL.SaveConveyor(objBOL);
                if (ddlConveyor.SelectedIndex > 0)
                {
                    HfConveyorTypeId.Value = ddlConveyor.SelectedValue;
                }
                else
                {
                    HfConveyorTypeId.Value = msg;
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
    private void Reset()
    {
        try
        {
            ddlConveyor.SelectedIndex = 0;
            txtName.Text = string.Empty;
            lblMsg.Text = "";
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }
}

