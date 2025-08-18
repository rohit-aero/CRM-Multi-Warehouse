using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;

public partial class INVManagement_FrmRelease : System.Web.UI.Page
{
    BOLINVPartsInfo ObjBOL = new BOLINVPartsInfo();
    BLLINVPartsinfo ObjBLL = new BLLINVPartsinfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Bind_Control();
        }
    }

    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 1;
            ds = ObjBLL.GetJobs(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlJobID, ds.Tables[0]);
            }           
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }  

    protected void ddlJobID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlJobID.SelectedIndex > 0)
            {
                Bind_Grid();
                btnRelease.Enabled = true;
            }
            else
            {
                gvDetail.DataSource = "";
                gvDetail.DataBind();
                btnRelease.Enabled = false;
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
            ddlJobID.SelectedIndex = 0;
            gvDetail.DataSource = "";
            gvDetail.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Grid()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 4;
            ObjBOL.projectid = ddlJobID.SelectedValue.ToString();         
            ds = ObjBLL.GetJobs(ObjBOL);
            if (ds.Tables[0].Rows.Count>0)
            {
                gvDetail.DataSource = ds.Tables[0];
                gvDetail.DataBind();
            }
            else
            {
                gvDetail.DataSource = "";
                gvDetail.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnRelease_Click(object sender, EventArgs e)
    {
        if (ddlJobID.SelectedIndex > 0)
        {
            if (gvDetail.Rows.Count > 0)
            {
                string msg = "";
                ObjBOL.operation = 2;
                ObjBOL.projectid = ddlJobID.SelectedValue.ToString();
                ObjBOL.userid = Convert.ToInt32(Utility.GetCurrentUser());
                msg = ObjBLL.ReleaseProject(ObjBOL);
                Utility.ShowMessage(this, msg.Trim());
                Utility.ShowMessage_Success(Page, msg.Trim());
                if (msg.Trim() == "Project Released !!")
                {
                    Utility.MaintainLogsSpecial("frmRelease", "Release", ddlJobID.SelectedValue.ToString());
                }
                Bind_Control();
                gvDetail.DataSource = "";
                gvDetail.DataBind();
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
    }
}