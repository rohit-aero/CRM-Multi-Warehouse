using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;
using System.IO;
using System.Linq;
using System.Web.UI.HtmlControls;

public partial class INVManagement_frmPartMaintainance : System.Web.UI.Page
{
    BOLPartMaintainanace ObjBOL = new BOLPartMaintainanace();
    BLLManagePartsMaintainance ObjBLL = new BLLManagePartsMaintainance();
    string FileExtention = null;
    public static readonly List<string> ImageExtensions = new List<string> { ".jpg" };
    public static readonly List<string> ImageExtensionsPdf = new List<string> { ".pdf" };
    string saveFolderImage = string.Empty;
    string saveFolderDrawing = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                GetFilePaths();
                if (!IsPostBack)
                {
                    ITWSwitch();
                    Bind_Controls();
                    //EnableDisableControls();
                    BindPartDesc();
                    CheckPremissionsForFormAccess();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckPremissionsForFormAccess()
    {
        try
        {
            string checkUserAccess = "";
            DataSet ds = new DataSet();
            ObjBOL.Operation = 20;
            ObjBOL.LoginUserId = Utility.GetCurrentSession().EmployeeID;
            ds = ObjBLL.GetINVDetails(ObjBOL);
            if (ds.Tables.Count > 0)
            {
                checkUserAccess = ds.Tables[0].Rows[0]["CheckAccess"].ToString();
                if (checkUserAccess == "1")
                {
                    hfcontrolaccess.Value = checkUserAccess;
                    EnableDisableControlRecursively(dvAccessControls, false, "control-access");
                    EnableDisableControlRecursively(dvAccessControls, true, "control-access-enabled");
                }
                else
                {
                    hfcontrolaccess.Value = checkUserAccess;
                    EnableDisableControlRecursively(dvAccessControls, true, "control-access");

                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableDisableControlRecursively(Control control, bool enable, string dynamicCssClass)
    {
        try
        {
            if (control is WebControl)
            {
                WebControl webControl = (WebControl)control;
                if (webControl.CssClass.Split(' ').Contains(dynamicCssClass))
                {
                    if (control is TextBox)
                    {
                        ((TextBox)control).Enabled = enable;
                    }
                    else if (control is DropDownList)
                    {
                        ((DropDownList)control).Enabled = enable;
                    }
                    else if (control is CheckBox)
                    {
                        ((CheckBox)control).Enabled = enable;
                    }
                    else if (control is FileUpload)
                    {
                        ((FileUpload)control).Enabled = enable;
                    }
                    else if (control is RadioButtonList)
                    {
                        ((RadioButtonList)control).Enabled = enable;
                    }
                }
            }

            if (control.HasControls())
            {
                foreach (Control childControl in control.Controls)
                {
                    EnableDisableControlRecursively(childControl, enable, dynamicCssClass);
                }
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
            saveFolderImage = Utility.PartImagePath();
            saveFolderDrawing = Utility.ShopDrawingPath();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableDisableControls()
    {
        try
        {
            var Reviewedby = Convert.ToString(Convert.ToInt32(Utility.GetCurrentUser()));
            //89 = Bhatiwal, 96 = kalsi      
            var ReviewedbyID = new List<string> { "89", "96", "263" };
            if (ReviewedbyID.Contains(Reviewedby))
            {
                txtMin.Enabled = true;
                txtMax.Enabled = true;
                txtReOrderPoint.Enabled = true;
                txtReOrderQty.Enabled = true;
                txtLeadTime.Enabled = true;
                txtMOQ.Enabled = true;
                txtEAU.Enabled = true;
                txtBatch.Enabled = true;
            }
            else
            {
                txtMin.Enabled = false;
                txtMax.Enabled = false;
                txtReOrderPoint.Enabled = false;
                txtReOrderQty.Enabled = false;
                txtLeadTime.Enabled = false;
                txtMOQ.Enabled = false;
                txtEAU.Enabled = false;
                txtBatch.Enabled = false;
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
            ObjBOL.LoginUserId = Utility.GetCurrentSession().EmployeeID;
            ds = ObjBLL.GetINVDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProductCodeLookUp, ds.Tables[0]);
                Utility.BindDropDownList(ddlProductCode, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDepartment, ds.Tables[1]);
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSource, ds.Tables[2]);
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlUM, ds.Tables[3]);
            }

            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCategory, ds.Tables[5]);
            }

            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCompany, ds.Tables[6]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindProduct(string ProductCode)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 18;
            ObjBOL.ProductCode = Convert.ToInt32(ProductCode);
            ds = ObjBLL.GetINVDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProductLineID, ds.Tables[0]);
            }
            else
            {
                if (ddlProductLineID.Items.Count > 0)
                {
                    ddlProductLineID.Items.Clear();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindPartDesc()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ObjBOL.LoginUserId = Utility.GetCurrentSession().EmployeeID;
            ds = ObjBLL.GetINVDetails(ObjBOL);
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartInfo, ds.Tables[4]);
                ddlPartInfo.SelectedIndex = 0;
            }
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
                Utility.BindDropDownList(ddlPartInfo, ds.Tables[0]);
            }
            else
            {
                ddlPartInfo.DataSource = "";
                ddlPartInfo.DataBind();
                ddlPartInfo.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //ddlProductCodeLookUp_SelectedIndexChanged
    protected void ddlProductCodeLookUp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Reset();
            ResetPartInfo();
            gvShopDwg.DataSource = "";
            gvShopDwg.DataBind();
            pangvShopdwg.Visible = false;
            rdbLineStopper.SelectedValue = "0";
            if (ddlLineStopperPriority.Items.Count > 0)
            {
                ddlLineStopperPriority.SelectedIndex = 0;
                ddlLineStopperPriority.Enabled = false;
            }
            if (ddlProductCodeLookUp.SelectedIndex > 0)
            {
                PartsDesc(ddlProductCodeLookUp.SelectedValue);
                BindProduct(ddlProductCodeLookUp.SelectedValue);
            }
            else
            {
                BindPartDesc();
                ddlPartInfo.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillDetails()
    {
        try
        {
            if (ddlPartInfo.SelectedIndex > 0)
            {
                btnSave.Text = "Update";
                ObjBOL.Operation = 3;
                ObjBOL.Partid = Convert.ToInt32(ddlPartInfo.SelectedValue);
                DataSet ds = new DataSet();
                ds = ObjBLL.GetINVDetails(ObjBOL);
                var partid = ds.Tables[0].Rows[0]["partid"].ToString();
                hfpartid.Value = partid;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    if (ddlProductCode.Items.FindByValue(dr["productcode"].ToString()) != null)
                    {
                        ddlProductCode.SelectedValue = dr["productcode"].ToString();
                    }
                    else
                    {
                        if (ddlProductCode.Items.Count > 0)
                        {
                            ddlProductCode.SelectedIndex = 0;
                        }
                    }

                    ITWSwitch();
                    BindProduct(ddlProductCode.SelectedValue);
                    txtCustPartNo.Text = dr["CustomerPartNumber"].ToString();
                    if (ddlDepartment.Items.FindByValue(dr["DepartmentId"].ToString()) != null)
                    {
                        ddlDepartment.SelectedValue = dr["DepartmentId"].ToString();
                    }
                    else
                    {
                        if (ddlDepartment.Items.Count > 0)
                        {
                            ddlDepartment.SelectedIndex = 0;
                        }
                    }

                    if (ddlSource.Items.FindByValue(dr["SourceId"].ToString()) != null)
                    {
                        ddlSource.SelectedValue = dr["SourceId"].ToString();
                    }
                    else
                    {
                        if (ddlSource.Items.Count > 0)
                        {
                            ddlSource.SelectedIndex = 0;
                        }
                    }

                    txtPartNo.Text = dr["PartNumber"].ToString();
                    if (ddlProductLineID.Items.FindByValue(dr["ProductLineID"].ToString()) != null)
                    {
                        ddlProductLineID.SelectedValue = dr["ProductLineID"].ToString();
                    }
                    else
                    {
                        if (ddlProductLineID.Items.Count > 0)
                        {
                            ddlProductLineID.SelectedIndex = 0;
                        }
                    }

                    txtDes.Text = dr["PartDes"].ToString();
                    // TO DO
                    rdbStockItem.SelectedValue = dr["StockItem"].ToString();
                    rdbForecast.SelectedValue = dr["ForecastItem"].ToString();
                    rdbLineStopper.SelectedValue = dr["LineStopper"].ToString();
                    if (ddlLineStopperPriority.Items.FindByValue(dr["LineStopperPriority"].ToString()) != null)
                    {
                        ddlLineStopperPriority.SelectedValue = dr["LineStopperPriority"].ToString();
                    }
                    else
                    {
                        if (ddlLineStopperPriority.Items.Count > 0)
                        {
                            ddlLineStopperPriority.SelectedIndex = 0;
                        }
                    }

                    if (dr["stockinhand"].ToString() != "")
                    {
                        txtStockInHand.Text = dr["stockinhand"].ToString();
                    }

                    string str = dr["revisionno"].ToString();
                    if (ddlRevisionNo.Items.FindByValue(str) != null)
                    {
                        ddlRevisionNo.SelectedValue = str;
                    }
                    else
                    {
                        if (ddlRevisionNo.Items.Count > 0)
                        {
                            ddlRevisionNo.SelectedIndex = 0;
                        }
                    }
                    //if (str != "")
                    //{
                    //    ddlRevisionNo.SelectedValue = ds.Tables[0].Rows[0]["revisionno"].ToString();
                    //}
                    txtMin.Text = dr["min"].ToString();
                    txtMax.Text = dr["max"].ToString();
                    txtReOrderPoint.Text = dr["reorderpoint"].ToString();
                    txtReOrderQty.Text = dr["reorderqty"].ToString();
                    txtLeadTime.Text = dr["leadtime"].ToString();
                    txtMOQ.Text = dr["MOQ"].ToString();
                    txtEAU.Text = dr["EAU"].ToString();
                    txtBatch.Text = dr["Batch"].ToString();

                    if (ddlPartStatus.Items.FindByValue(dr["PartStatus"].ToString()) != null)
                    {
                        ddlPartStatus.SelectedValue = dr["PartStatus"].ToString();
                    }
                    else
                    {
                        if (ddlPartStatus.Items.Count > 0)
                        {
                            ddlPartStatus.SelectedIndex = 0;
                        }
                    }

                    if (ddlUM.Items.FindByValue(dr["UMId"].ToString()) != null)
                    {
                        ddlUM.SelectedValue = dr["UMId"].ToString();
                    }
                    else
                    {
                        if (ddlUM.Items.Count > 0)
                        {
                            ddlUM.SelectedIndex = 0;
                        }
                    }

                    if (ddlCompany.Items.FindByValue(dr["CompanyId"].ToString()) != null)
                    {
                        ddlCompany.SelectedValue = dr["CompanyId"].ToString();
                    }
                    else
                    {
                        ddlCompany.SelectedIndex = 0;
                    }

                    if (ddlCategory.Items.FindByValue(dr["CategoryId"].ToString()) != null)
                    {
                        ddlCategory.SelectedValue = dr["CategoryId"].ToString();
                        ddlCategory_SelectedIndexChanged_Event();
                    }
                    else
                    {
                        ddlCategory.SelectedIndex = 0;
                    }

                    if (ddlSize.Items.FindByValue(dr["SizeID"].ToString()) != null)
                    {
                        ddlSize.SelectedValue = dr["SizeID"].ToString();
                    }
                    else
                    {
                        if (ddlSize.Items.Count > 0)
                        {
                            ddlSize.SelectedIndex = 0;
                        }
                    }

                    if (ddlDirection.Items.FindByValue(dr["Direction"].ToString()) != null)
                    {
                        ddlDirection.SelectedValue = dr["Direction"].ToString();
                    }
                    else
                    {
                        if (ddlDirection.Items.Count > 0)
                        {
                            ddlDirection.SelectedIndex = 0;
                        }
                    }

                    if (ddlOption.Items.FindByValue(dr["OptionID"].ToString()) != null)
                    {
                        ddlOption.SelectedValue = dr["OptionID"].ToString();
                    }
                    else
                    {
                        if (ddlOption.Items.Count > 0)
                        {
                            ddlOption.SelectedIndex = 0;
                        }
                    }

                    if (dr["Partimage"].ToString() != "")
                    {
                        FileInfo file = new FileInfo(saveFolderImage + dr["Partimage"].ToString());
                        if (file.Exists)
                        {
                            Image1.Visible = true;
                            Image1.ImageUrl = "../ImageHandler.ashx?imagePath=" + saveFolderImage + dr["Partimage"].ToString();
                        }
                    }
                    Bind_GridShopDrawingsPartInfo();
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    gvWarehouseStock.DataSource = ds.Tables[1];
                    gvWarehouseStock.DataBind();
                }
                else
                {
                    gvWarehouseStock.DataSource = string.Empty;
                    gvWarehouseStock.DataBind();
                }
            }
            rdbLineStopper_SelectedIndexChanged();
            //else
            //{
            //    Reset();
            //    btnSave.Text = "Save";
            //    pangvShopdwg.Visible = false;
            //    lblMessage.Text = String.Empty;
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
            txtCustPartNo.Text = String.Empty;

            if (ddlProductCode.Items.Count > 0)
            {
                ddlProductCode.SelectedIndex = 0;
            }

            if (ddlDepartment.Items.Count > 0)
            {
                ddlDepartment.SelectedIndex = 0;
            }

            if (ddlSource.Items.Count > 0)
            {
                ddlSource.SelectedIndex = 0;
            }

            txtPartNo.Text = String.Empty;
            txtDes.Text = String.Empty;
            rdbStockItem.SelectedValue = "0";
            rdbForecast.SelectedValue = "0";
            rdbLineStopper.SelectedValue = "0";
            if (ddlLineStopperPriority.Items.Count > 0)
            {
                ddlLineStopperPriority.SelectedIndex = 0;
                ddlLineStopperPriority.Enabled = false;
            }

            txtStockInHand.Text = String.Empty;
            txtMin.Text = String.Empty;
            txtMax.Text = String.Empty;
            txtStockInHand.Text = String.Empty;
            txtReOrderPoint.Text = String.Empty;
            txtReOrderQty.Text = String.Empty;
            txtLeadTime.Text = String.Empty;
            txtMOQ.Text = string.Empty;
            txtEAU.Text = string.Empty;
            txtBatch.Text = string.Empty;

            if (ddlRevisionNo.Items.Count > 0)
            {
                ddlRevisionNo.SelectedIndex = 0;
            }

            ddlPartStatus.SelectedIndex = 0;
            ddlUM.SelectedIndex = 0;
            btnSave.Text = "Save";
            Image1.ImageUrl = String.Empty;

            if (ddlPartStatus.Items.Count > 0)
            {
                ddlPartStatus.SelectedIndex = 0;
            }

            if (ddlProductLineID.Items.Count > 0)
            {
                ddlProductLineID.Items.Clear();
            }

            gvWarehouseStock.DataSource = string.Empty;
            gvWarehouseStock.DataBind();

            Disable_ITWSpecificFields();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetProductCode()
    {
        try
        {
            txtCustPartNo.Text = String.Empty;

            if (ddlDepartment.Items.Count > 0)
            {
                ddlDepartment.SelectedIndex = 0;
            }

            if (ddlSource.Items.Count > 0)
            {
                ddlSource.SelectedIndex = 0;
            }

            txtPartNo.Text = String.Empty;
            txtDes.Text = String.Empty;
            rdbStockItem.SelectedValue = "0";
            rdbForecast.SelectedValue = "0";
            rdbLineStopper.SelectedValue = "0";
            if (ddlLineStopperPriority.Items.Count > 0)
            {
                ddlLineStopperPriority.SelectedIndex = 0;
                ddlLineStopperPriority.Enabled = false;
            }
            txtStockInHand.Text = String.Empty;
            txtMin.Text = String.Empty;
            txtMax.Text = String.Empty;
            txtStockInHand.Text = String.Empty;
            txtReOrderPoint.Text = String.Empty;
            txtReOrderQty.Text = String.Empty;
            txtLeadTime.Text = String.Empty;
            txtMOQ.Text = string.Empty;
            txtEAU.Text = string.Empty;
            txtBatch.Text = string.Empty;
            if (ddlRevisionNo.Items.Count > 0)
            {
                ddlRevisionNo.SelectedIndex = 0;
            }

            if (ddlPartStatus.Items.Count > 0)
            {
                ddlPartStatus.SelectedIndex = 0;
            }

            if (ddlUM.Items.Count > 0)
            {
                ddlUM.SelectedIndex = 0;
            }

            btnSave.Text = "Save";
            Image1.ImageUrl = String.Empty;
            ddlPartStatus.SelectedIndex = 0;
            if (ddlProductLineID.Items.Count > 0)
            {
                ddlProductLineID.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetPartInfo()
    {
        try
        {
            ddlPartInfo.DataSource = "";
            ddlPartInfo.DataBind();
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
            if (ddlProductCode.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Product. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Product Code. !!");
                ddlProductCode.Focus();
                return false;
            }

            if (txtPartNo.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Part Number. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Aerowerks Part Number. !!");
                txtPartNo.Focus();
                return false;
            }

            if (fpUploadpartimage.FileName != "" && Image1.ImageUrl == "")
            {
                GetFilePath();
                if (fpUploadpartimage.HasFile)
                {
                    FileExtention = System.IO.Path.GetExtension(fpUploadpartimage.FileName);
                }
                else
                {
                    FileExtention = System.IO.Path.GetExtension(hfGetpartimage.Value);
                }
                string File = FileExtention.ToLower();
                if (ImageExtensions.Contains(File))
                {
                    //Code
                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Attach Only .jpg and .png files. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Attach Only .jpg files. !!");
                    return false;
                }
            }
            else if (fpUploadpartimage.FileName == "" && Image1.ImageUrl != "")
            {
                GetFilePath();
                if (fpUploadpartimage.HasFile)
                {
                    FileExtention = System.IO.Path.GetExtension(fpUploadpartimage.FileName);
                }
                else
                {
                    FileExtention = System.IO.Path.GetExtension(hfGetpartimage.Value);
                }
                string File = FileExtention.ToLower();
                if (ImageExtensions.Contains(File))
                {
                    if (fpUploadpartimage.HasFile)
                    {
                        int fileSize = fpUploadpartimage.PostedFile.ContentLength;
                        // Convert the bytes to Kilobytes (1 KB = 1024 Bytes)
                        double fileSizeInKB = fileSize / 1024.0;
                        if (fileSizeInKB > Utility.FileSizeLimits(File))
                        {
                            Utility.ShowMessage_Error(Page, "File size exceeds " + Utility.FileSizeLimits(File) + "KB. Please choose a smaller file. !!");
                            return false;
                        }
                    }

                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Attach Only .jpg and .png files. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Attach Only .jpg files. !!");
                    return false;
                }
            }
            else if (fpUploadpartimage.FileName != "" && Image1.ImageUrl != "")
            {
                GetFilePath();
                if (fpUploadpartimage.HasFile)
                {
                    FileExtention = System.IO.Path.GetExtension(fpUploadpartimage.FileName);
                }
                else
                {
                    FileExtention = System.IO.Path.GetExtension(hfGetpartimage.Value);
                }
                string File = FileExtention.ToLower();
                if (ImageExtensions.Contains(File))
                {
                    if (fpUploadpartimage.HasFile)
                    {
                        int fileSize = fpUploadpartimage.PostedFile.ContentLength;
                        // Convert the bytes to Kilobytes (1 KB = 1024 Bytes)
                        double fileSizeInKB = fileSize / 1024.0;
                        if (fileSizeInKB > Utility.FileSizeLimits(File))
                        {
                            Utility.ShowMessage_Error(Page, "File size exceeds " + Utility.FileSizeLimits(File) + "KB. Please choose a smaller file. !!");
                            return false;
                        }
                    }

                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Attach Only .jpg and .png files. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Attach Only .jpg files. !!");
                    return false;
                }
            }
            if (fpUploadShopDrawing.FileName != "")
            {
                GetFilePath();
                if (fpUploadShopDrawing.HasFile)
                {
                    FileExtention = System.IO.Path.GetExtension(fpUploadShopDrawing.FileName);
                    bool check = fpUploadShopDrawing.FileName.Contains(",");
                    if (check)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('ShopDrawing Name cannot contain COMMA(,) !');", true);
                        Utility.ShowMessage_Error(Page, "ShopDrawing Name cannot contain COMMA(,) !!");
                        return false;
                    }
                }
                string File = FileExtention.ToLower();
                if (ImageExtensionsPdf.Contains(File))
                {
                    if (fpUploadShopDrawing.HasFile)
                    {
                        int fileSize = fpUploadShopDrawing.PostedFile.ContentLength;
                        // Convert the bytes to Kilobytes (1 KB = 1024 Bytes)
                        double fileSizeInKB = fileSize / 1024.0;
                        if (fileSizeInKB > Utility.FileSizeLimits(File))
                        {
                            Utility.ShowMessage_Error(Page, "File size exceeds " + Utility.FileSizeLimits(File) + "KB. Please choose a smaller file. !!");
                            return false;
                        }
                    }

                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Attach Only .pdf file format. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Attach Only .pdf file format. !!");
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void SaveOrUpdatePartSuccessAction()
    {
        try
        {
            Reset();
            ResetPartInfo();
            Bind_Controls();
            BindPartDesc();
            lblMessage.Text = String.Empty;
            //ResetPartInfo();
            gvShopDwg.DataSource = "";
            gvShopDwg.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SavePartDetails()
    {
        try
        {
            string msg = "";
            if (ValidationCheck() == true)
            {
                ObjBOL.PartNumber = txtPartNo.Text.Trim();
                ObjBOL.PartDes = txtDes.Text;
                ObjBOL.CustomerPartNumber = txtCustPartNo.Text;
                if (ddlProductCode.SelectedIndex > 0)
                {
                    ObjBOL.ProductCode = Convert.ToInt32(ddlProductCode.SelectedValue);
                }
                if (ddlProductLineID.SelectedIndex > 0)
                {
                    ObjBOL.ProductId = Convert.ToInt32(ddlProductLineID.SelectedValue);
                }
                if (rdbStockItem.SelectedValue == "1")
                {
                    ObjBOL.StockItem = true;
                }
                else
                {
                    ObjBOL.StockItem = false;
                }
                if (rdbForecast.SelectedValue == "1")
                {
                    ObjBOL.ForecastItem = true;
                }
                else
                {
                    ObjBOL.ForecastItem = false;
                }
                if (rdbLineStopper.SelectedValue == "1")
                {
                    ObjBOL.LineStopper = true;
                }
                else
                {
                    ObjBOL.LineStopper = false;
                }
                if (ddlSource.SelectedIndex > 0)
                {
                    ObjBOL.SourceId = Convert.ToInt32(ddlSource.SelectedValue);
                }

                if (ddlDepartment.SelectedIndex > 0)
                {
                    ObjBOL.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
                }

                if (ddlCompany.SelectedIndex > 0)
                {
                    ObjBOL.CompanyID = Int32.Parse(ddlCompany.SelectedValue);
                }

                if (ddlCategory.SelectedIndex > 0)
                {
                    ObjBOL.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                    if (ddlSize.SelectedIndex > 0)
                    {
                        ObjBOL.Size = Convert.ToInt32(ddlSize.SelectedValue);
                    }
                }

                if (ddlDirection.SelectedIndex > 0)
                {
                    ObjBOL.Direction = ddlDirection.SelectedValue;
                }

                if (ddlOption.SelectedIndex > 0)
                {
                    ObjBOL.OptionID = Convert.ToInt32(ddlOption.SelectedValue);
                }

                if (ddlRevisionNo.SelectedIndex > 0)
                {
                    ObjBOL.RevisionNo = ddlRevisionNo.SelectedValue;
                }
                else
                {
                    ObjBOL.RevisionNo = "";
                }

                if (txtMin.Text != "")
                {
                    ObjBOL.min = Convert.ToInt32(txtMin.Text);
                }

                if (txtMax.Text != "")
                {
                    ObjBOL.max = Convert.ToInt32(txtMax.Text);
                }

                if (txtReOrderPoint.Text != "")
                {
                    ObjBOL.reorderpoint = Convert.ToInt32(txtReOrderPoint.Text);
                }
                if (txtReOrderQty.Text != "")
                {
                    ObjBOL.reorderqty = Convert.ToInt32(txtReOrderQty.Text);
                }

                if (txtMOQ.Text != "")
                {
                    ObjBOL.MOQ = Int32.Parse(txtMOQ.Text);
                }

                if (txtEAU.Text != "")
                {
                    ObjBOL.EAU = Int32.Parse(txtEAU.Text);
                }

                if (txtBatch.Text != "")
                {
                    ObjBOL.Batch = Int32.Parse(txtBatch.Text);
                }

                if (txtLeadTime.Text != "")
                {
                    ObjBOL.leadtime = Convert.ToInt32(txtLeadTime.Text);
                }

                if (ddlPartStatus.SelectedIndex > 0)
                {
                    ObjBOL.PartStatus = Convert.ToInt32(ddlPartStatus.SelectedValue);
                }

                if (ddlUM.SelectedIndex > 0)
                {
                    ObjBOL.UMId = Convert.ToInt32(ddlUM.SelectedValue);
                }

                if (fpUploadpartimage.HasFile)
                {
                    //SavePartImage();
                    ObjBOL.PathImage = fpUploadpartimage.FileName;
                }
                else
                {
                    GetFilePath();
                    ObjBOL.PathImage = hfGetpartimage.Value;
                }

                if (fpUploadShopDrawing.HasFile)
                {
                    //SaveShopDrawing();
                    ObjBOL.PathShopDrawing = fpUploadShopDrawing.FileName;
                }

                ObjBOL.LineStopperPriority = ddlLineStopperPriority.SelectedValue;

                if (btnSave.Text == "Save")
                {
                    ObjBOL.Operation = 2;
                    msg = ObjBLL.SaveINVParts(ObjBOL);
                    if (msg == "Duplicate Aerowerks Part No!!")
                    {
                        Utility.ShowMessage_Warning(Page, msg);
                    }
                    else
                    {
                        if (fpUploadpartimage.HasFile)
                        {
                            SavePartImage();
                            //ObjBOL.PathImage = "/PartImage/" + hfpartimage.Value;
                        }
                        if (fpUploadShopDrawing.HasFile)
                        {
                            SaveShopDrawing();
                            //ObjBOL.PathShopDrawing = fpUploadShopDrawing.FileName;
                        }
                        SaveOrUpdatePartSuccessAction();
                        //PartsDesc(ddlProductCode.SelectedValue);
                        ddlPartInfo.SelectedValue = msg;
                        Utility.MaintainLogsSpecial("frmPartMaintenance.aspx", "Save", ddlPartInfo.SelectedValue);
                        Utility.ShowMessage_Success(Page, "Records Added Successfully !!");
                    }
                }
                else if (btnSave.Text == "Update")
                {
                    ObjBOL.Operation = 5;
                    ObjBOL.Partid = Convert.ToInt32(hfpartid.Value);
                    msg = ObjBLL.SaveINVParts(ObjBOL);
                    if (msg == "Duplicate Aerowerks Part No!!")
                    {
                        Utility.ShowMessage_Warning(Page, msg);
                    }
                    else
                    {
                        if (fpUploadpartimage.HasFile)
                        {
                            SavePartImage();
                            //ObjBOL.PathImage = "/PartImage/" + hfpartimage.Value;
                        }
                        if (fpUploadShopDrawing.HasFile)
                        {
                            SaveShopDrawing();
                            //ObjBOL.PathShopDrawing = fpUploadShopDrawing.FileName;
                        }
                        Utility.MaintainLogsSpecial("frmPartMaintenance.aspx", "Update", ddlPartInfo.SelectedValue);
                        Utility.ShowMessage_Success(Page, msg);
                        SaveOrUpdatePartSuccessAction();
                    }
                }

                //Utility.ShowMessage(this, msg);

                //Bind_GridShopDrawings();

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_GridShopDrawings()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 9;
            ObjBOL.Partid = Convert.ToInt32(hfpartid.Value);
            ObjBOL.RevisionNo = ddlRevisionNo.SelectedValue;
            ds = ObjBLL.GetINVDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvShopDwg.DataSource = ds.Tables[0];
                gvShopDwg.DataBind();
            }
            else
            {
                gvShopDwg.DataSource = "";
                gvShopDwg.DataBind();
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
            ObjBOL.Partid = Convert.ToInt32(hfpartid.Value);
            ds = ObjBLL.GetINVDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvShopDwg.DataSource = ds.Tables[0];
                gvShopDwg.DataBind();
                pangvShopdwg.Visible = true;
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

    private void GetFilePath()
    {
        try
        {
            hfCusId.Value = String.Empty;
            hfGetpartimage.Value = String.Empty;
            hfgetshopdrawing.Value = String.Empty;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 7;
            if (ddlPartInfo.SelectedIndex > 0)
            {
                int partId = 0;
                if (Int32.TryParse(hfpartid.Value, out partId))
                {
                    ObjBOL.Partid = partId;
                }
                ds = ObjBLL.GetINVDetails(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    hfGetpartimage.Value = ds.Tables[0].Rows[0]["Partimage"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SavePartImage()
    {
        try
        {
            //string folderPath = Server.MapPath("~/PartImage/");
            string folderPath = saveFolderImage;
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists Create it.
                Directory.CreateDirectory(folderPath);
            }
            string PartInfo = ddlPartInfo.SelectedValue;
            string FileName = PartInfo.Trim();
            FileInfo currentfile = new FileInfo(fpUploadpartimage.FileName);
            string newfilename = fpUploadpartimage.FileName;
            hfpartimage.Value = newfilename;
            fpUploadpartimage.SaveAs(folderPath + newfilename);
            Image1.ImageUrl = folderPath + newfilename;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SaveShopDrawing()
    {
        try
        {
            //string folderPath = Server.MapPath("~/ShopDrawing/");
            string folderPath = saveFolderDrawing;
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists Create it.
                Directory.CreateDirectory(folderPath);
            }
            string FileName = fpUploadShopDrawing.FileName;
            hfshopdrawing.Value = FileName;
            fpUploadShopDrawing.SaveAs(folderPath + FileName);
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
            var ddlPI = ddlPartInfo.SelectedValue;
            SavePartDetails();
            if (ddlPI.Trim() != "")
            {
                if (Int32.Parse(ddlPI) > 0)
                {
                    ddlPartInfo.SelectedValue = ddlPI;
                }
                BindProductCode(ddlPartInfo.SelectedValue);
                FillDetails();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPartInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPartInfo.SelectedIndex > 0)
            {
                pangvShopdwg.Visible = true;
                Reset();
                FillDetails();
                BindProductCode(ddlPartInfo.SelectedValue);
                btnSave.Text = "Update";
            }
            else
            {
                pangvShopdwg.Visible = false;
                Reset();
                gvShopDwg.DataSource = "";
                gvShopDwg.DataBind();
            }
            CheckPremissionsForFormAccess();
            rdbLineStopper_SelectedIndexChanged();
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
            //ResetPartInfo();
            BindPartDesc();
            ddlPartInfo.SelectedIndex = 0;
            ddlProductCodeLookUp.SelectedIndex = 0;
            gvShopDwg.DataSource = "";
            gvShopDwg.DataBind();
            pangvShopdwg.Visible = false;
            Reset_ITWSpecificFields();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void lnkDowload_Click(object sender, EventArgs e)
    {
        try
        {
            GetFilePath();
            string filePath = hfgetshopdrawing.Value;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                // Clear Rsponse reference
                Response.Clear();
                // Add header by specifying file name
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                // Add header for content length
                Response.AddHeader("Content-Length", file.Length.ToString());
                // Specify content type
                Response.ContentType = "text/plain";
                // Clearing flush
                Response.Flush();
                // Transimiting file
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShopDwg_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "select")
            {
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblDrawingName = (Label)clickedRow.FindControl("lblDrwaingnameNo");
                //string folderPath = "~/ShopDrawing/" + lblDrawingName.Text;
                //string filePath = Server.MapPath(folderPath);
                string folderPath = saveFolderDrawing + lblDrawingName.Text;
                string filePath = folderPath;
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
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlRevisionNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Bind_GridShopDrawings();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShopDwg_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = gvShopDwg.Rows[e.RowIndex];
            Int32 ID = Convert.ToInt32(gvShopDwg.DataKeys[e.RowIndex].Value);
            ObjBOL.Partid = ID;
            ObjBOL.Operation = 6;
            msg = ObjBLL.DeleteINVRecord(ObjBOL);
            //Utility.ShowMessage(this, msg);
            Utility.ShowMessage_Success(Page, msg);
            Bind_GridShopDrawingsPartInfo();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/InventoryManagement/frmPartShop.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnITWReport_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/TurboWash/FrmTWParts.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlProductCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ITWSwitch();
            if (ddlProductCode.SelectedIndex > 0)
            {
                //ResetProductCode();
                BindProduct(ddlProductCode.SelectedValue);
            }
            else
            {
                ddlPartInfo.SelectedIndex = 0;
                //ResetProductCode();
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

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCategory_SelectedIndexChanged_Event();
    }

    private void ddlCategory_SelectedIndexChanged_Event()
    {
        try
        {
            ddlSize.Items.Clear();
            if (ddlCategory.SelectedIndex > 0)
            {
                ObjBOL.Operation = 19;
                ObjBOL.CategoryID = Int32.Parse(ddlCategory.SelectedValue);
                DataSet ds = ObjBLL.GetINVDetails(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlSize, ds.Tables[0]);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Enable_ITWSpecificFields()
    {
        try
        {
            ITWDiv.Visible = true;
            ddlCompany.Enabled = true;
            ddlCategory.Enabled = true;
            ddlSize.Enabled = true;
            ddlDirection.Enabled = true;
            ddlOption.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Disable_ITWSpecificFields()
    {
        try
        {
            //Reset_ITWSpecificFields();
            ddlCompany.Enabled = false;
            ddlCategory.Enabled = false;
            ddlSize.Enabled = false;
            ddlDirection.Enabled = false;
            ddlOption.Enabled = false;
            ITWDiv.Visible = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ITWSwitch()
    {
        try
        {
            if (ddlProductCode.SelectedValue == "2")
            {
                Enable_ITWSpecificFields();
            }
            else
            {
                Disable_ITWSpecificFields();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Reset_ITWSpecificFields()
    {
        try
        {
            if (ddlCompany.Items.Count > 0)
            {
                ddlCompany.SelectedIndex = 0;
            }

            if (ddlCategory.Items.Count > 0)
            {
                ddlCategory.SelectedIndex = 0;
            }
            ddlSize.Items.Clear();
            ddlDirection.SelectedIndex = 0;
            ddlOption.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShopDwg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find the LinkButton within the row
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                if (hfcontrolaccess.Value == "1")
                {
                    lnkDelete.CssClass += " disabled";
                }
                else
                {
                    lnkDelete.CssClass = lnkDelete.CssClass.Replace("disabled", "").Trim();
                    lnkDelete.CssClass += " enabled";
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void rdbLineStopper_SelectedIndexChanged(object sender, EventArgs e)
    {
        rdbLineStopper_SelectedIndexChanged();
    }

    private void rdbLineStopper_SelectedIndexChanged()
    {
        try
        {
            if (rdbLineStopper.SelectedValue == "1")
            {
                ddlLineStopperPriority.Enabled = true;
            }
            else
            {
                ddlLineStopperPriority.Enabled = false;
                ddlLineStopperPriority.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}