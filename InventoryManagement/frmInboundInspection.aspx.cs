using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.IO;

public partial class InventoryManagement_frmInboundInspection : System.Web.UI.Page
{
    BOLInboundInspectionSummary ObjBOL = new BOLInboundInspectionSummary();
    BLLManageInboundInpectionSummary ObjBLL = new BLLManageInboundInpectionSummary();
    string FileExtention = null;
    public static readonly List<string> ImageExtensionsPdf = new List<string> { ".pdf" };
    commonclass1 clscon = new commonclass1();
    string folderPath = String.Empty;
    int qtyrec = 0;
    int qtyapp = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                GetFilePaths();
                if (!IsPostBack)
                {
                    Bind_Control();
                    Bind_PartDesc();
                    ResetContainerNo();
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
            folderPath = Utility.InboundInspectionDataPath();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    #region Drop Down Events Functions
    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetInboundInspectionSummaryDetails(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProductCodeLookUp, ds.Tables[1]);
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_PartDesc()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetInboundInspectionSummaryDetails(ObjBOL);
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartNo, ds.Tables[2]);
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
                ResetProductCodeLookup();
                PartsDesc(ddlProductCodeLookUp.SelectedValue);
            }
            else
            {
                ResetProductCodeLookup();
                Bind_PartDesc();
                ddlPartNo.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetProductCodeLookup()
    {
        try
        {
            ddlPartNo.DataSource = "";
            ddlPartNo.DataBind();
            Reset();
            ResetContainerNo();
            ResetFillDetails();
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
            ObjBOL.Operation = 10;
            ObjBOL.ProductCode = Convert.ToInt32(productcode);
            ds = ObjBLL.GetInboundInspectionSummaryDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartNo, ds.Tables[0]);
            }
            else
            {
                ddlPartNo.DataSource = "";
                ddlPartNo.DataBind();
                ddlPartNo.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void BindContainer(string plantid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            ObjBOL.plant = Convert.ToInt32(plantid);
            ds = ObjBLL.GetInboundInspectionSummaryDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlContainerNo, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }



    protected void ddlPlant_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPlant.SelectedIndex > 0)
            {
                BindContainer(ddlPlant.SelectedValue);
            }
            else
            {
                ResetContainerNo();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetOnChange()
    {
        try
        {
            ResetFillDetails();
            ResetGrid();
            ResetTable();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPartNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPartNo.SelectedIndex > 0)
            {
                ResetOnChange();
                Bind_Grid();
                FillDetails(ddlPartNo.SelectedValue);
                btnAdd.Enabled = true;
            }
            else
            {
                ResetOnChange();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void FillDetails(string partid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.PartID = Convert.ToInt32(partid);
            ds = ObjBLL.GetInboundInspectionSummaryDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtAeroPartNo.Text = ds.Tables[0].Rows[0]["PartNumber"].ToString();
                txtCusPartNo.Text = ds.Tables[0].Rows[0]["CustomerPartNumber"].ToString();
                txtProductCode.Text = ds.Tables[0].Rows[0]["product"].ToString();
                txtPartDes.Text = ds.Tables[0].Rows[0]["Partdes"].ToString();
                ddlProductCodeLookUp.SelectedValue = ds.Tables[0].Rows[0]["productcode"].ToString();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion   

    #region Events
    //btnGenerateReport_Click
    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/InventoryManagement/frmInboundInspectionReport.aspx", false);
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
            ddlProductCodeLookUp.SelectedIndex = 0;
            ddlPartNo.SelectedIndex = 0;
            btnAdd.Enabled = false;
            Bind_PartDesc();
            ddlPartNo.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Reset Modules
    private void CommonCategoryReset()
    {
        ResetPartNo();
        ResetAutoFillTextBoxes();
        ResetTable();
    }
    private void ResetContainerNo()
    {
        ddlContainerNo.DataSource = "";
        ddlContainerNo.DataBind();
        ddlContainerNo.Items.Insert(0, new ListItem("Select", "0"));
    }


    private void CommonProductLineReset()
    {
        ResetPartNo();
        ResetAutoFillTextBoxes();
        ResetTable();
    }

    private void CommonPartReset()
    {
        ResetAutoFillTextBoxes();
        ResetTable();
    }

    private void ResetFillDetails()
    {
        try
        {
            txtAeroPartNo.Text = String.Empty;
            txtCusPartNo.Text = String.Empty;
            txtProductCode.Text = String.Empty;
            txtPartDes.Text = String.Empty;
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
            ResetFillDetails();
            ResetContainerNo();
            ResetAutoFillTextBoxes();
            ResetTable();
            ResetGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetPartNo()
    {
        try
        {
            ddlPartNo.DataSource = "";
            ddlPartNo.DataBind();
            ddlPartNo.Items.Insert(0, new ListItem("Select", ""));
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetAutoFillTextBoxes()
    {
        try
        {
            txtAeroPartNo.Text = string.Empty;
            txtPartDes.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetGrid()
    {
        try
        {
            gvInboundSummDetails.DataSource = "";
            gvInboundSummDetails.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetTable()
    {
        try
        {
            ddlPlant.SelectedIndex = 0;
            ResetContainerNo();
            txtInspectionDate.Text = String.Empty;
            txtQtyInspected.Text = String.Empty;
            txtQtyReceived.Text = String.Empty;
            txtAppQty.Text = String.Empty;
            txtSummary.Text = string.Empty;
            ddlStatus.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Grid Entry Table Module
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnAddValidation() == true)
            {
                string msg = "";
                ObjBOL.Operation = 4;
                if (ddlPartNo.SelectedIndex > 0)
                {
                    ObjBOL.PartID = Convert.ToInt32(ddlPartNo.SelectedValue);
                }
                if (ddlPlant.SelectedIndex > 0)
                {
                    ObjBOL.plant = Convert.ToInt32(ddlPlant.SelectedValue);
                }
                if (txtQtyReceived.Text != "")
                {
                    ObjBOL.qtyreceived = Convert.ToInt32(txtQtyReceived.Text);
                    qtyrec = Convert.ToInt32(txtQtyReceived.Text);
                }
                if (ddlContainerNo.SelectedIndex > 0)
                {
                    ObjBOL.containerno = Convert.ToInt32(ddlContainerNo.SelectedValue);
                }
                if (txtInspectionDate.Text != "")
                {
                    ObjBOL.inspectiondate = Utility.ConvertDate(txtInspectionDate.Text);
                }
                if (txtQtyInspected.Text != "")
                {
                    ObjBOL.qtyinspected = Convert.ToInt32(txtQtyInspected.Text);
                }
                if (txtAppQty.Text != "")
                {
                    ObjBOL.qtyapproved = Convert.ToInt32(txtAppQty.Text);
                    qtyapp = Convert.ToInt32(txtAppQty.Text);
                }
                if (qtyapp > qtyrec)
                {
                    Utility.ShowMessage_Warning(Page, "Qty Approved Should not be more than Qty Received !");
                    txtAppQty.Text = String.Empty;
                    txtAppQty.Focus();
                    return;
                }
                ObjBOL.summary = txtSummary.Text;
                ObjBOL.userid = Utility.GetCurrentSession().EmployeeID;
                if (ddlStatus.SelectedIndex > 0)
                {
                    ObjBOL.status = Convert.ToInt32(ddlStatus.SelectedValue);
                }
                if (fpuploadfile.HasFile)
                {
                    if (SavePdf() == true)
                    {
                        ObjBOL.filename = fpuploadfile.FileName;
                    }
                    else
                    {
                        return;
                    }
                }

                msg = ObjBLL.SaveSummaryDetails(ObjBOL);
                //Utility.ShowMessage(this, msg);
                if (msg == "Duplicate Records !!!")
                {
                    Utility.ShowMessage_Warning(Page, msg);
                }
                else
                {
                    Utility.ShowMessage_Success(Page, msg);
                }

                if (msg != "")
                {
                    Utility.MaintainLogsSpecial("frmInboundInspection", "Add", ddlPartNo.SelectedValue);
                }
                Bind_Grid();
                ResetTable();
                btnAdd.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Validation Check
    private Boolean ValidationCheck()
    {
        try
        {
            if (ddlPartNo.SelectedValue == "0")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Part No. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Part No. !");
                ddlPartNo.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }
    private Boolean btnAddValidation()
    {
        try
        {
            if (ddlPartNo.SelectedValue == "0")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Part#. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Part#. !");
                ddlPartNo.Focus();
                return false;
            }
            if (ddlPlant.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Plant !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Plant !");
                ddlPlant.Focus();
                return false;
            }
            if (ddlContainerNo.SelectedValue == "0")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Part#. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Container No. !");
                ddlContainerNo.Focus();
                return false;
            }
            if (ddlStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Plant !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Status !");
                ddlStatus.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        return true;
    }
    #endregion

    #region Grid Module
    private void Bind_Grid()
    {
        DataTable dt = new DataTable();
        string qstr = "";
        try
        {
            qstr += "Select Inv_InboundInspection_Detail.containerno as ShipInfoid,Inv_InboundInspection_Detail.id AS InspectionDetailID, ";
            qstr += " CASE WHEN plant=1 THEN 'Agilent' ELSE 'Triflex' END AS plant,plant as plantid, ";
            qstr += " case when qtyapproved=0 then null else qtyapproved end as qtyapproved,remarks, ";
            qstr += " case when qtyinspected=0 then null else qtyinspected end as qtyinspected,inspectiondate,inspectiondate, ";
            qstr += " [filename] as [filename], ";
            qstr += "  Ship_Info.ContainerNo,case when qtyreceived=0 then null else qtyreceived end as qtyreceived, ";
            qstr += " case when INV_InboundInspection_Detail.[status]=1 then 'Approved' when INV_InboundInspection_Detail.[status]=2 then'Rejected' End as [status],[status] as StatusID ";
            qstr += " from Inv_InboundInspection_Detail ";
            qstr += " INNER JOIN Inv_InboundInspection ON Inv_InboundInspection.id=Inv_InboundInspection_Detail.inspectionid ";
            qstr += " INNER JOIN Inv_Parts ON Inv_Parts.id=Inv_InboundInspection.partid ";
            qstr += " INNER JOIN Ship_Info ON INV_InboundInspection_Detail.containerno = Ship_Info.id";
            qstr += " where  Inv_InboundInspection_Detail.plant is not null ";
            if (ddlPartNo.SelectedIndex > 0)
            {
                qstr += " AND Inv_InboundInspection.partid='" + ddlPartNo.SelectedValue + "' ";
            }
            qstr += " Order by Inv_InboundInspection_Detail.inspectiondate desc ";
            clscon.Return_DT(dt, qstr);
            if (dt.Rows.Count > 0)
            {
                gvInboundSummDetails.DataSource = dt;
                gvInboundSummDetails.DataBind();
            }
            else
            {
                ResetGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void gvInboundSummDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvInboundSummDetails.EditIndex = e.NewEditIndex;
            Bind_Grid();
            DropDownList PlantID = gvInboundSummDetails.Rows[gvInboundSummDetails.EditIndex].FindControl("gvEditddlPlant") as DropDownList;
            DropDownList ddlEditContainerNo = gvInboundSummDetails.Rows[gvInboundSummDetails.EditIndex].FindControl("ddlEditContainerNo") as DropDownList;
            Label lblEditContainer = gvInboundSummDetails.Rows[gvInboundSummDetails.EditIndex].FindControl("lblEditContainer") as Label;
            DropDownList ddlEditStatus = gvInboundSummDetails.Rows[gvInboundSummDetails.EditIndex].FindControl("ddlEditStatus") as DropDownList;
            Label lblEditStatus = gvInboundSummDetails.Rows[gvInboundSummDetails.EditIndex].FindControl("lblEditStatus") as Label;
            if (lblEditStatus.Text != "")
            {
                ddlEditStatus.SelectedValue = lblEditStatus.Text;
            }
            else
            {
                ddlEditStatus.SelectedItem.Text = "Select";
            }
            if (PlantID.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 3;
                ObjBOL.plant = Convert.ToInt32(PlantID.SelectedValue);
                ds = ObjBLL.GetInboundInspectionSummaryDetails(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlEditContainerNo, ds.Tables[0]);
                    ddlEditContainerNo.SelectedValue = lblEditContainer.Text;
                }
                else
                {
                    ddlEditContainerNo.DataSource = "";
                    ddlEditContainerNo.DataBind();
                    ddlEditContainerNo.Items.Insert(0, new ListItem("Select", "0"));
                }
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void gvInboundSummDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvInboundSummDetails.EditIndex = -1;
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void gvInboundSummDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = gvInboundSummDetails.Rows[e.RowIndex];
            DropDownList plantSelected = (row.FindControl("gvEditddlPlant") as DropDownList);
            DropDownList containerSelected = (row.FindControl("ddlEditContainerNo") as DropDownList);
            if (plantSelected.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Plant. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Plant. !");
                plantSelected.Focus();
                return;
            }
            if (containerSelected.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Plant. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Container No. !");
                containerSelected.Focus();
                return;
            }
            DropDownList status = (row.FindControl("ddlEditStatus") as DropDownList);
            if (status.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                status.Focus();
                return;
            }
            FileUpload fpedituploadfile = row.FindControl("fpedituploadfile") as FileUpload;
            TextBox txtQtyApproved = row.FindControl("gvEdittxtQtyApproved") as TextBox;
            ObjBOL.InspectionDetailID = Convert.ToInt32(gvInboundSummDetails.DataKeys[e.RowIndex].Values[0]);
            Label lblEditContainer = row.FindControl("lblEditContainer") as Label;
            if (lblEditContainer.Text != "")
            {
                ObjBOL.containerno = Convert.ToInt32((row.FindControl("ddlEditContainerNo") as DropDownList).SelectedValue);
            }

            ObjBOL.plant = Convert.ToInt32(plantSelected.SelectedValue);
            var InspectionDate = (row.FindControl("gvEdittxtInspectionDate") as TextBox).Text;
            ObjBOL.inspectiondate = Utility.ConvertDate(InspectionDate);
            var qtyinspected = (row.FindControl("gvEdittxtQtyInspected") as TextBox).Text;
            if (fpedituploadfile.HasFile)
            {
                if (fpedituploadfile.HasFile)
                {
                    FileExtention = System.IO.Path.GetExtension(fpedituploadfile.FileName);
                }
                string File = FileExtention.ToLower();
                if (ImageExtensionsPdf.Contains(File))
                {
                    int fileSize = fpedituploadfile.PostedFile.ContentLength;
                    // Convert the bytes to Kilobytes (1 KB = 1024 Bytes)
                    double fileSizeInKB = fileSize / 1024.0;
                    if (fileSizeInKB > Utility.FileSizeLimits(File))
                    {
                        Utility.ShowMessage_Error(Page, "File size exceeds " + Utility.AllowedFileSize_Pdf + "KB. Please choose a smaller file. !!");
                        return;
                    }
                    if (!Directory.Exists(folderPath))
                    {
                        //If Directory (Folder) does not exists Create it.
                        Directory.CreateDirectory(folderPath);
                    }
                    string PartInfo = ddlPartNo.SelectedValue;
                    string FileName = PartInfo.Trim();
                    FileInfo currentfile = new FileInfo(fpedituploadfile.FileName);
                    string newfilename = fpedituploadfile.FileName;
                    hfpartnodrwaing.Value = newfilename;
                    fpedituploadfile.SaveAs(folderPath + newfilename);
                    ObjBOL.filename = fpedituploadfile.FileName;
                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Attach Only .pdf file format. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Attach Only .pdf file format. !");
                    return;
                }
            }
            else
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 9;
                ObjBOL.InspectionDetailID = Convert.ToInt32(gvInboundSummDetails.DataKeys[e.RowIndex].Values[0]);
                ds = ObjBLL.GetInboundInspectionSummaryDetails(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ObjBOL.filename = ds.Tables[0].Rows[0]["filename"].ToString();
                }
            }
            if (qtyinspected != "")
            {
                ObjBOL.qtyinspected = Convert.ToInt32(qtyinspected);
            }
            var qtyReceived = (row.FindControl("gvEdittxtQtyReceived") as TextBox).Text;
            if (qtyReceived != "")
            {
                ObjBOL.qtyreceived = Convert.ToInt32(qtyReceived);
                qtyrec = Convert.ToInt32(qtyReceived);
            }
            var qtyApproved = (row.FindControl("gvEdittxtQtyApproved") as TextBox);
            if (qtyApproved.Text != "")
            {
                ObjBOL.qtyapproved = Convert.ToInt32(qtyApproved.Text);
                qtyapp = Convert.ToInt32(qtyApproved.Text);
            }
            if (qtyapp > qtyrec)
            {
                Utility.ShowMessage_Warning(Page, "Qty Approved Should not be more than Qty Received !");
                qtyApproved.Text = String.Empty;
                qtyApproved.Focus();
                return;
            }
            ObjBOL.summary = (row.FindControl("gvEdittxtSummary") as TextBox).Text;
            ObjBOL.userid = Utility.GetCurrentSession().EmployeeID;
            if (status.SelectedIndex > 0)
            {
                ObjBOL.status = Convert.ToInt32(status.SelectedValue);
            }
            ObjBOL.Operation = 7;
            msg = ObjBLL.SaveSummaryDetails(ObjBOL);
            if (msg != "")
            {
                Utility.MaintainLogsSpecial("frmInboundInspection", "Update", ddlPartNo.SelectedValue);
                Utility.ShowMessage_Success(Page, msg);
            }
            gvInboundSummDetails.EditIndex = -1;
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvInboundSummDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = gvInboundSummDetails.Rows[e.RowIndex];
            Int32 InspectionDetailID = Convert.ToInt32(gvInboundSummDetails.DataKeys[e.RowIndex].Value);
            ObjBOL.InspectionDetailID = InspectionDetailID;
            ObjBOL.Operation = 8;
            msg = ObjBLL.DeleteDetails(ObjBOL);
            if (msg != "")
            {
                Utility.MaintainLogsSpecial("frmInboundInspection", "Delete", ddlPartNo.SelectedValue);
                Utility.ShowMessage_Success(Page, msg);
            }
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void gvInboundSummDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "lnkSelect")
            {
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                LinkButton lnkDownload = (LinkButton)clickedRow.FindControl("lnkDownload");
                hfgetpartnodrwaing.Value = lnkDownload.Text;
                string filePath = folderPath + hfgetpartnodrwaing.Value;
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
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Upload Pdf Operations
    private Boolean SavePdf()
    {
        try
        {
            if (fpuploadfile.HasFile)
            {
                FileExtention = System.IO.Path.GetExtension(fpuploadfile.FileName);
            }
            string File = FileExtention.ToLower();
            if (ImageExtensionsPdf.Contains(File))
            {
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists Create it.
                    Directory.CreateDirectory(folderPath);
                }
                int fileSize = fpuploadfile.PostedFile.ContentLength;
                // Convert the bytes to Kilobytes (1 KB = 1024 Bytes)
                double fileSizeInKB = fileSize / 1024.0;
                if (fileSizeInKB > Utility.FileSizeLimits(File))
                {
                    Utility.ShowMessage_Error(Page, "File size exceeds " + Utility.AllowedFileSize_Pdf + "KB. Please choose a smaller file. !!");
                    return false;
                }
                string PartInfo = ddlPartNo.SelectedValue;
                string FileName = PartInfo.Trim();
                FileInfo currentfile = new FileInfo(fpuploadfile.FileName);
                string newfilename = fpuploadfile.FileName;
                hfpartnodrwaing.Value = newfilename;
                fpuploadfile.SaveAs(folderPath + newfilename);
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Attach Only .pdf file format. !');", true);
                Utility.ShowMessage_Error(Page, "Please Attach Only .pdf file format. !");
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }
    private Boolean UpdatePdf()
    {
        try
        {
            if (fpuploadfile.HasFile)
            {
                FileExtention = System.IO.Path.GetExtension(fpuploadfile.FileName);
            }
            string File = FileExtention.ToLower();
            if (ImageExtensionsPdf.Contains(File))
            {
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists Create it.
                    Directory.CreateDirectory(folderPath);
                }
                int fileSize = fpuploadfile.PostedFile.ContentLength;
                // Convert the bytes to Kilobytes (1 KB = 1024 Bytes)
                double fileSizeInKB = fileSize / 1024.0;
                if (fileSizeInKB > Utility.FileSizeLimits(File))
                {
                    Utility.ShowMessage_Error(Page, "File size exceeds " + Utility.AllowedFileSize_Pdf + "KB. Please choose a smaller file. !!");
                    return false;
                }
                string PartInfo = ddlPartNo.SelectedValue;
                string FileName = PartInfo.Trim();
                FileInfo currentfile = new FileInfo(fpuploadfile.FileName);
                string newfilename = fpuploadfile.FileName;
                hfpartnodrwaing.Value = newfilename;
                fpuploadfile.SaveAs(folderPath + newfilename);
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Attach Only .pdf file format. !');", true);
                Utility.ShowMessage_Error(Page, "Please Attach Only .pdf file format. !");
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }
    #endregion    

    protected void gvEditddlPlant_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList PlantID = gvInboundSummDetails.Rows[gvInboundSummDetails.EditIndex].FindControl("gvEditddlPlant") as DropDownList;
            DropDownList ddlEditContainerNo = gvInboundSummDetails.Rows[gvInboundSummDetails.EditIndex].FindControl("ddlEditContainerNo") as DropDownList;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            ObjBOL.plant = Convert.ToInt32(PlantID.SelectedValue);
            ds = ObjBLL.GetInboundInspectionSummaryDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlEditContainerNo, ds.Tables[0]);
            }
            else
            {
                ddlEditContainerNo.DataSource = "";
                ddlEditContainerNo.DataBind();
                ddlEditContainerNo.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvInboundSummDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkFileInfo = (LinkButton)e.Row.FindControl("lnkDownload");
                FileInfo file = new FileInfo(folderPath + lnkFileInfo.Text);
                if (file.Exists)
                {
                    lnkFileInfo.Visible = true;
                }
                else
                {
                    lnkFileInfo.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}