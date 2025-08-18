using BLLAERO;
using BOLAERO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InventoryManagement_frmSearchPart : System.Web.UI.Page
{
    BOLPartMaintainanace ObjBOL = new BOLPartMaintainanace();
    BLLManagePartsMaintainance ObjBLL = new BLLManagePartsMaintainance();
    string saveFolderDrawing = string.Empty;
    string saveFolderImage = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetFilePaths();
        if (!IsPostBack)
        {
            BindControls();
            btnSearch.Enabled = false;
        }
    }

    private void GetFilePaths()
    {
        try
        {
            saveFolderImage = Utility.PartImagePath();
            saveFolderDrawing = Utility.ShopDrawingPath();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            //ObjBOL.LoginUserId = Utility.GetCurrentSession().EmployeeID;
            ds = ObjBLL.GetINVDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProductCodeLookUp, ds.Tables[0]);
                ddlProductCodeLookUp.SelectedIndex = 0;
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartDescHeaderList, ds.Tables[4]);
                ddlPartDescHeaderList.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void PartsDesc(string productcode)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 16;
            ObjBOL.ProductCode = Convert.ToInt32(productcode);
            ds = ObjBLL.GetINVDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartDescHeaderList, ds.Tables[0]);
            }
            else
            {
                ddlPartDescHeaderList.DataSource = "";
                ddlPartDescHeaderList.DataBind();
                ddlPartDescHeaderList.Items.Insert(0, new ListItem("Select", "0"));

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlProductCodeLookUp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlProductCodeLookUp.SelectedIndex > 0)
            {
                ResetInfo();
                PartsDesc(ddlProductCodeLookUp.SelectedValue);
            }
            else
            {
                ResetInfo();
                BindControls();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetInfo()
    {
        try
        {
            clearGridAndImage();
            ddlPartDescHeaderList.DataSource = "";
            ddlPartDescHeaderList.DataBind();
            ddlPartDescHeaderList.Items.Insert(0, new ListItem("Select", "0"));
            btnSearch.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPartDescHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clearGridAndImage();
            if (ddlPartDescHeaderList.SelectedIndex > 0)
            {
                btnSearch.Enabled = true;
                BindProductCode(ddlPartDescHeaderList.SelectedValue);
            }
            else
            {
                btnSearch.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShopDwg_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "select")
        {
            GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
            Label lblDrawingName = (Label)clickedRow.FindControl("lblDrwaingnameNo");
            string folderPath = saveFolderDrawing;
            string filePath = folderPath + lblDrawingName.Text;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                DownloadShopDrawing(filePath);
            }
            else
            {
                DirectoryInfo directory = new DirectoryInfo(saveFolderDrawing);
                string drawingNameWithoutCommas = lblDrawingName.Text.Replace(",", "");

                FileInfo matchingFile = directory.GetFiles()
                    .FirstOrDefault(i => i.Name.Replace(",", "").Equals(drawingNameWithoutCommas));

                if (matchingFile != null)
                {
                    DownloadShopDrawing(saveFolderDrawing + matchingFile.Name);
                }
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 14;
            // ObjBOL.LoginUserId = Utility.GetCurrentSession().EmployeeID;
            ObjBOL.Partid = Convert.ToInt32(ddlPartDescHeaderList.SelectedValue);
            ds = ObjBLL.GetINVDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                BindEntryField(ds.Tables[0]);
            }
            Bind_GridShopDrawingsPartInfo();
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
            clearGridAndImage();
            BindControls();
            ddlPartDescHeaderList.SelectedIndex = 0;
            ddlProductCodeLookUp.SelectedIndex = 0;
            btnSearch.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindEntryField(DataTable table)
    {
        try
        {
            txtProductCode.Text = table.Rows[0]["productcode"].ToString();
            txtPartNo.Text = table.Rows[0]["PartNumber"].ToString();
            txtCustomerPartNo.Text = table.Rows[0]["CustomerPartNumber"].ToString();
            txtProductLine.Text = table.Rows[0]["ProductLine"].ToString();
            txtUM.Text = table.Rows[0]["UM"].ToString();
            txtRevision.Text = table.Rows[0]["RevisionNo"].ToString();
            txtDes.Text = table.Rows[0]["PartDes"].ToString();
            txtDepartment.Text = table.Rows[0]["Department"].ToString();
            txtSource.Text = table.Rows[0]["Source"].ToString();
            txtStockInHand.Text = table.Rows[0]["StockInHand"].ToString();
            txtMin.Text = table.Rows[0]["min"].ToString();
            txtMax.Text = table.Rows[0]["max"].ToString();
            txtReOrderPoint.Text = table.Rows[0]["reorderpoint"].ToString();
            txtReOrderQty.Text = table.Rows[0]["reorderqty"].ToString();
            txtLeadTime.Text = table.Rows[0]["leadtime"].ToString();
            txtStatus.Text = table.Rows[0]["PartStatus"].ToString();
            if (table.Rows[0]["PartImage"].ToString().Trim() != "")
            {
                FileInfo file = new FileInfo(saveFolderImage + table.Rows[0]["PartImage"].ToString().Trim());
                if (file.Exists)
                {
                    Image1.ImageUrl = "../ImageHandler.ashx?imagePath=" + saveFolderImage + table.Rows[0]["PartImage"].ToString();
                    Image1.Visible = true;
                }
                else
                {
                    Image1.ImageUrl = "";
                    Image1.Visible = false;
                }
            }
            else
            {
                Image1.ImageUrl = "";
                Image1.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_GridShopDrawingsPartInfo()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 10;
            ObjBOL.Partid = Convert.ToInt32(ddlPartDescHeaderList.SelectedValue);
            ds = ObjBLL.GetINVDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvShopDwg.DataSource = ds.Tables[0];
                gvShopDwg.DataBind();
                pangvShopdwg.Visible = true;
                lblMessage.Visible = true;
            }
            else
            {
                gvShopDwg.DataSource = "";
                gvShopDwg.DataBind();
                pangvShopdwg.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void clearGridAndImage()
    {
        try
        {
            clearEntryField();
            Image1.ImageUrl = "";
            gvShopDwg.DataSource = "";
            gvShopDwg.DataBind();
            lblMessage.Visible = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void clearEntryField()
    {
        try
        {
            txtProductCode.Text = String.Empty;
            txtCustomerPartNo.Text = String.Empty;
            txtProductLine.Text = String.Empty;
            txtPartNo.Text = "";
            txtRevision.Text = "";
            txtDes.Text = "";
            txtSource.Text = "";
            txtDepartment.Text = "";
            txtStockInHand.Text = "";
            txtMin.Text = "";
            txtMax.Text = "";
            txtReOrderPoint.Text = "";
            txtReOrderQty.Text = "";
            txtLeadTime.Text = "";
            txtStatus.Text = "";
            txtUM.Text = "";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindProductCode(string PartNo)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 17;
            ObjBOL.Partid = Convert.ToInt32(PartNo);
            ds = ObjBLL.GetINVDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlProductCodeLookUp.SelectedValue = ds.Tables[0].Rows[0]["productcode"].ToString();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DownloadShopDrawing(string filePath)
    {
        try
        {
            FileInfo file = new FileInfo(filePath);
            if (file.Exists && Response.IsClientConnected)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name.Replace(",", ""));
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/pdf";
                Response.Flush();
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

}