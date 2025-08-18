using BLLAERO;
using BOLAERO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NACUFS_FrmUniversity : System.Web.UI.Page
{
    BOLManageUniv ObjBOL = new BOLManageUniv();
    BLLManageUniv ObjBLL = new BLLManageUniv();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Controls();

            if (string.IsNullOrEmpty(Request.QueryString["University"]) == false)

            {
                ddlUniv.SelectedItem.Text = Request.QueryString["University"];
                txtName.Text = Request.QueryString["University"];
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
    private void Bind_Controls()
    {
        DataSet ds = new DataSet();
        ObjBOL.operation = 1;
        ds = ObjBLL.GetUniv(ObjBOL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Utility.BindDropDownList(ddlUniv, ds.Tables[0]);
        }
    }
    private Boolean ValidationCheck()
    {
        if (txtName.Text == "")
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter University Name. !');", true);
            Utility.ShowMessage_Error(Page, "Please Enter University Name. !");
            txtName.Focus();
            return false;
        }

        return true;
    }
    /// <summary>
    /// Reset all Controls
    /// </summary>
    private void Reset()
    {
        ddlUniv.SelectedIndex = 0;
        txtName.Text = string.Empty;
        lblMsg.Text = "";
        btnSave.Text = "Save";

    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidationCheck() == true)
        {
            string msg = "";
            if (ddlUniv.SelectedIndex > 0)
            {
                ObjBOL.id = Convert.ToInt32(ddlUniv.SelectedValue);
            }
            else
            {
                ObjBOL.id = 0;
            }
            ObjBOL.operation = 2;
            ObjBOL.UniName = txtName.Text;
            msg = ObjBLL.SaveUniv(ObjBOL);
            if (ddlUniv.SelectedIndex > 0)
            {
                hfCusId.Value = ddlUniv.SelectedValue;
            }
            else
            {
                hfCusId.Value = msg;
            }
            Utility.ShowMessage_Success(this, msg);
            Utility.MaintainLogs("FrmUniversity.aspx", "Save");
            Bind_Controls();
            Reset();
        }
    }

    protected void ddlUniv_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlUniv.SelectedIndex > 0)
            {
                hfCusId.Value = ddlUniv.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.operation = 3;
                ObjBOL.id = Convert.ToInt32(ddlUniv.SelectedValue);
                ds = ObjBLL.GetUniv(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["UniName"]);
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SalesManagement/FrmProposals.aspx");
    }
}

