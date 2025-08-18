using BLLAERO;
using BOLAERO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NACUFS_FrmDesignation : System.Web.UI.Page
{
    BOLManageDesg ObjBOL = new BOLManageDesg();
    BLLManageDesg ObjBLL = new BLLManageDesg();
    protected void Page_Load(object sender, EventArgs e)
    {
     
        if (!IsPostBack)
        {
            Control_Bind();

            if (string.IsNullOrEmpty(Request.QueryString["Designation"]) == false)

            {
                ddlDesg.SelectedItem.Text = Request.QueryString["Designation"];
                txtName.Text = Request.QueryString["Designation"];
            }
            if (Session["PNumber"] != null)
            {

                btnBack.Enabled = true;
            }
            else
            {
                btnBack.Enabled = false;
            }
        }
    }
    private void Control_Bind()
    {
        DataSet ds = new DataSet();
        ObjBOL.operation = 1;
        ds = ObjBLL.GetDesg(ObjBOL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Utility.BindDropDownList(ddlDesg, ds.Tables[0]);
        }

    }


    private Boolean ValidationCheck()
    {
        if (txtName.Text == "")
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Designation. !');", true);
            Utility.ShowMessage_Error(Page, "Please Enter Designation. !");
            txtName.Focus();
            return false;
        }

        return true;
    }
   private void Controls_Reset()
    {
        ddlDesg.SelectedIndex = 0;
        txtName.Text = string.Empty;
        lblMsg.Text = "";
        btnSave.Text = "Save";
       
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Controls_Reset();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidationCheck() == true)
        {
            string msg = "";
            if (ddlDesg.SelectedIndex > 0)
            {
                ObjBOL.id = Convert.ToInt32(ddlDesg.SelectedValue);
            }
            else
            {
                ObjBOL.id = 0;
            }
            ObjBOL.operation = 2;
            ObjBOL.DesgName = txtName.Text;
            msg = ObjBLL.SaveDesg(ObjBOL);
            if (ddlDesg.SelectedIndex > 0)
            {
                hfCusId.Value = ddlDesg.SelectedValue;
            }
            else
            {
                hfCusId.Value = msg;
            }
            Utility.ShowMessage_Success(this, msg);
            Utility.MaintainLogs("frmDesignation.aspx", "save");
            Control_Bind();
            Controls_Reset();


        }
    }

    protected void ddlDesg_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDesg.SelectedIndex > 0)
            {
                hfCusId.Value = ddlDesg.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.operation = 3;
                ObjBOL.id = Convert.ToInt32(ddlDesg.SelectedValue);
                ds = ObjBLL.GetDesg(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["DesgName"]);
                    lblMsg.Text = "";
                    btnSave.Text = "Update";
                }
            }
        }

        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
        }
    }
}
