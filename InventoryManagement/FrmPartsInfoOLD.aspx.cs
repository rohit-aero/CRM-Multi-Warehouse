using System;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;
using System.Collections.Generic;
using System.IO;
using System.Web.Services;

public partial class INVManagement_FrmPartsInfo : System.Web.UI.Page
{
    BOLINVPartsInfo ObjBOL = new BOLINVPartsInfo();
    BLLINVPartsinfo ObjBLL = new BLLINVPartsinfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnDownloadPdf.Enabled = false;
            if (Request.QueryString["fileName"] != null)
            {
                SaveFile(Request.QueryString["fileName"]);
            }
            else
            {
                Bind_Control();
            }
        }
    }

    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 1;
            ds = ObjBLL.GetINVPartsInfo(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlJobID, ds.Tables[0]);
            }
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

    protected void ddlJobID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Panel2.Visible = true;
            Reset();
            Bind_Grid();
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
            ObjBOL.projectid = ddlJobID.SelectedValue;
            ds = ObjBLL.GetINVPartsInfo(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetail.DataSource = ds.Tables[0];
                gvDetail.DataBind();
                btnDownloadPdf.Enabled = true;
                GetFileNames();
            }
            else
            {
                gvDetail.DataSource = "";
                gvDetail.DataBind();
                ddlFileName.Items.Clear();
                btnDownloadPdf.Enabled = false;
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
            string msg = "";
            ObjBOL.operation = 3;
            ObjBOL.projectid = ddlJobID.SelectedValue;
            ObjBOL.PartId = Convert.ToInt32(ddlPartsDetail.SelectedValue);
            ObjBOL.Qty = Convert.ToInt32(txtQty.Text);
            msg = ObjBLL.SaveINVPartsInfo(ObjBOL);
            Utility.ShowMessage(this, msg);
            Bind_Grid();
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
            Bind_Grid();
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
            TextBox txtqty = row.FindControl("txtQty") as TextBox;
            ObjBOL.projectid = ddlJobID.SelectedValue;
            ObjBOL.PartId = Partid;
            ObjBOL.Qty = Convert.ToInt32(txtqty.Text);
            msg = ObjBLL.UpdateINVPartsInfo(ObjBOL);
            gvDetail.EditIndex = -1;
            Bind_Grid();
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void GetFileNames()
    {
        var partFileNames = new List<string>();
        try
        {
            foreach (GridViewRow row in gvDetail.Rows)
            {
                Label partId = (Label)(row.FindControl("lblPartId"));
                DataSet ds = new DataSet();
                ObjBOL.operation = 10;
                ObjBOL.PartId = Convert.ToInt32(partId.Text);
                ds = ObjBLL.GetINVPartsInfo(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    partFileNames.Add(ds.Tables[0].Rows[0]["drawingname"].ToString());
                }
            }

            ddlFileName.DataSource = partFileNames;
            ddlFileName.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnDownloader_Click(object sender, EventArgs e)
    {
        SaveFile(hdFileName.Value);
    }

    private void SaveFile(string fileName)
    {
        try
        {
            string folderPath = "~/ShopDrawing/" + fileName;
            string filePath = Server.MapPath(folderPath);
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/pdf";
                Response.Flush();
                Response.TransmitFile(file.FullName);
                Response.End();
            }
            string jScript = "<script>window.close();</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "keyClientBlock", jScript);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}