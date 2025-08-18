using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;

public partial class ContactManagement_FrmCategoryMaster : System.Web.UI.Page
{
    BOLCategory ObjBOL = new BOLCategory();
    BLLCategory ObjBLL = new BLLCategory();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                bindGridview();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void clear()
    {
        try
        {
            txtCategoryName.Text = string.Empty;
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
            ObjBOL.CategoryName = txtCategoryName.Text;
            if (btnSave.Text == "Save")
            {
                ObjBOL.op = 1;
            }
            else
            {
                ObjBOL.op = 2;
                ObjBOL.CategoryID = Convert.ToInt32(ViewState["CategoryID"]);
            }
            string msg = ObjBLL.SaveCategory(ObjBOL);
            bindGridview();
            clear();
            Utility.ShowMessage_Success(this, msg);
            Utility.MaintainLogs("FrmCategoryMaster.aspx", "Save");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void bindGridview()
    {
        try
        {
            ObjBOL.op = 5;
            Utility.BindGrid(gv, ObjBLL.GetCategory(ObjBOL).Tables[0]);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            ObjBOL.op = 3;
            ObjBOL.CategoryID = Convert.ToInt32(gv.DataKeys[e.RowIndex].Values["CategoryID"]);
            string msg = ObjBLL.SaveCategory(ObjBOL);
            bindGridview();
            Utility.ShowMessage_Success(this, msg);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.op = 4;
            ObjBOL.CategoryID = Convert.ToInt32(gv.DataKeys[e.RowIndex].Values["CategoryID"]);
            ViewState["CategoryID"] = Convert.ToInt32(gv.DataKeys[e.RowIndex].Values["CategoryID"]);
            ds = ObjBLL.GetCategory(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnSave.Text = "Update";
                txtCategoryName.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
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
            clear();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}
