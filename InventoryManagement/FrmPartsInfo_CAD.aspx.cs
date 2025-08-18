using System;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;
using System.Collections.Generic;
using System.IO;
using Ionic.Zip;
using System.Linq;

public partial class INVManagement_FrmPartsInfo_CAD : System.Web.UI.Page
{
    BOLINVPartsInfo ObjBOL = new BOLINVPartsInfo();
    BLLINVPartsinfo_CAD ObjBLL = new BLLINVPartsinfo_CAD();
    string FileFolder = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            GetFilePaths();
            if (!IsPostBack)
            {               
                Bind_Control();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetFilePaths()
    {
        try
        {
            FileFolder = Utility.ShopDrawingPath();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 1;
            ds = ObjBLL.GetINVPartsInfo(ObjBOL);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlJobID, ds.Tables[0]);
            //}
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProduct, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartsDetail, ds.Tables[2]);
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
            if (HfJobID.Value.Length <= 5)
            {
                Utility.ShowMessage_Error(Page, "Please Select Job !");
                txtSearchJName.Focus();
                return false;
            }

            if (ddlPartsDetail.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Part !");
                ddlPartsDetail.Focus();
                return false;
            }

            if (txtQty.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Quantity !");
                txtQty.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            if (ddlProduct.SelectedIndex > 0)
            {
                ObjBOL.operation = 2;
                ObjBOL.product = Convert.ToInt32(ddlProduct.SelectedValue);
            }
            else
            {
                ObjBOL.operation = 9;
            }
            ds = ObjBLL.GetINVPartsInfo(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartsDetail, ds.Tables[0]);
            }
            //else
            //{
            //    ddlPartsDetail.DataSource = "";
            //    ddlPartsDetail.DataBind();
            //}
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
            ddlProduct.SelectedIndex = 0;
            ddlPartsDetail.SelectedIndex = 0;
            txtQty.Text = String.Empty;
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
            ObjBOL.projectid = HfJobID.Value;
            ds = ObjBLL.GetINVPartsInfo(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                string msg = "";
                ObjBOL.operation = 3;
                ObjBOL.projectid = HfJobID.Value;
                ObjBOL.PartId = Convert.ToInt32(ddlPartsDetail.SelectedValue);
                ObjBOL.Qty = Convert.ToInt32(txtQty.Text);
                msg = ObjBLL.SaveINVPartsInfo(ObjBOL);
                if (msg.Trim() != "")
                {
                    if (msg.Trim() == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "Part# Already Exists !!!");
                    }
                    else
                    {
                        //Utility.ShowMessage(this, msg);
                        Utility.MaintainLogsSpecial("frmPartsInfo_CAD.aspx", "Save", HfJobID.Value);
                        Utility.ShowMessage_Success(Page, msg);
                        Bind_Grid();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int ID = Convert.ToInt32(gvDetail.DataKeys[e.RowIndex].Values[0]);
            String msg = "";
            ObjBOL.operation = 5;
            ObjBOL.PartId = ID;
            msg = ObjBLL.DeleteINVPartsInfo(ObjBOL);
            if (msg.Trim() != "")
            {
                Utility.MaintainLogsSpecial("frmPartsInfo_CAD.aspx", "Delete", HfJobID.Value);
                Utility.ShowMessage_Success(Page, msg);
                Bind_Grid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvDetail.EditIndex = -1;
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvDetail.EditIndex = e.NewEditIndex;
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = gvDetail.Rows[e.RowIndex];
            int Partid = Convert.ToInt32(gvDetail.DataKeys[row.RowIndex].Values[0]);
            ObjBOL.operation = 6;
            Label lblPartDes = row.FindControl("lblEditPartDes") as Label;
            //Label lblPartId = row.FindControl("lblPartId") as Label;
            TextBox txtqty = row.FindControl("txtQty") as TextBox;
            ObjBOL.projectid = HfJobID.Value;
            ObjBOL.PartId = Partid;
            ObjBOL.Qty = Convert.ToInt32(txtqty.Text);
            msg = ObjBLL.UpdateINVPartsInfo(ObjBOL);
            if (msg.Trim() != "")
            {
                Utility.MaintainLogsSpecial("frmPartsInfo_CAD.aspx", "Update", HfJobID.Value);
                Utility.ShowMessage_Success(Page, msg);
                gvDetail.EditIndex = -1;
                Bind_Grid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }    

    protected void txtSearchJName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CheckForValidProject();
            if (txtSearchJName.Text.Trim() != "")
            {
                Panel2.Visible = true;
                Reset();
                Bind_Grid();
            }
            else
            {
                gvDetail.DataSource = "";
                gvDetail.DataBind();               
                HfJobID.Value = "";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckForValidProject()
    {
        try
        {
            ObjBOL.operation = 13;
            int index = txtSearchJName.Text.IndexOf(',');
            if(index != -1)
            {
                ObjBOL.projectid = txtSearchJName.Text.Trim();
                DataSet ds = ObjBLL.GetINVPartsInfo(ObjBOL);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    txtSearchJName.Text = string.Empty;
                }
                else
                {
                    HfJobID.Value = ds.Tables[0].Rows[0]["JobID"].ToString();
                }
            }
           
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}