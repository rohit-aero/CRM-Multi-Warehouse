using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;
using System.IO;
using System.Net;

public partial class ShipmentTracker_frmShipmentInfo : System.Web.UI.Page
{
    BOLShipmentTracker ObjBOL = new BOLShipmentTracker();
    BLLManageShipmentTracker ObjBLL = new BLLManageShipmentTracker();
    string FileExtention = null;
    public static readonly List<string> ImageExtensionsPdf = new List<string> { ".pdf", ".xlsx", ".xls" };
    int defval = 0;
    string saveFolder = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                GetFilePaths();
                if (!IsPostBack)
                {
                    Bind_Controls();
                    Bind_ControlContainer(defval);
                    EmptyDT();
                    Bind_Grid();
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
            saveFolder = Utility.PackingListPath();
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
            ds = ObjBLL.GetShipmentDetail(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlShipmentFrom, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlShipmentby, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_ControlContainer(int containerid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetShipmentDetail(ObjBOL);
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlContainerNo, ds.Tables[2]);
                ddlContainerNo.SelectedValue = Convert.ToString(containerid);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable EmptyDT()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.Columns.Add(new DataColumn("ShipInfoDetailId", typeof(int)));
            dt.Columns.Add(new DataColumn("RevisedETA", typeof(string)));
            dt.Columns.Add(new DataColumn("Comments", typeof(string)));
            DataRow datarow = dt.NewRow();
            dt.Rows.Add(datarow);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void Bind_Grid()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            if (ddlContainerNo.SelectedIndex > 0)
            {
                ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
            }
            ds = ObjBLL.GetShipmentDetail(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvShipmentTracker.DataSource = ds.Tables[0];
                GvShipmentTracker.DataBind();
            }
            else
            {
                GvShipmentTracker.DataSource = EmptyDT();
                GvShipmentTracker.DataBind();
                GvShipmentTracker.Rows[0].Visible = false;
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
            if (ddlShipmentFrom.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Shipment From. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Shipment From. !");
                ddlShipmentFrom.Focus();
                return false;
            }
            if (ddlShipmentby.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Shipment By. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Shipment By. !");
                ddlShipmentby.Focus();
                return false;
            }
            if (txtContainerNum.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Container No. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Container No. !");
                txtContainerNum.Focus();
                return false;
            }
            if (txtShippedDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Ship Date. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Ship Date. !");
                txtShippedDate.Focus();
                return false;
            }
            if (txtETAAsPerPL.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter ETA. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter ETA. !");
                txtETAAsPerPL.Focus();
                return false;
            }
            if (fpUploadDrawing.HasFile)
            {
                FileExtention = System.IO.Path.GetExtension(fpUploadDrawing.FileName.Replace(",", "").Replace("'", ""));
                string File = FileExtention.ToLower();
                if (ImageExtensionsPdf.Contains(File))
                {
                    //Code
                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Attach Only .pdf files. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Attach Only .pdf files. !");
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

    private Boolean ValidationCheckRevisedETA()
    {
        try
        {
            TextBox RevisedETA = (GvShipmentTracker.FooterRow.FindControl("txtFooterRevisedETA") as TextBox);
            if (RevisedETA.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Revised ETA. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Revised ETA. !");
                RevisedETA.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void Save()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string RevisedETA = (GvShipmentTracker.FooterRow.FindControl("txtFooterRevisedETA") as TextBox).Text;
                string Comments = (GvShipmentTracker.FooterRow.FindControl("txtFooterComments") as TextBox).Text;
                string msg = "";
                if (fpUploadDrawing.HasFile)
                {
                    string folderPath = saveFolder;
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string filename = fpUploadDrawing.FileName.Replace(",", "").Replace("'", "");
                    fpUploadDrawing.SaveAs(folderPath + fpUploadDrawing.FileName.Replace(",", "").Replace("'", ""));
                    ObjBOL.PackingList = filename;
                }
                else
                {
                    GetFilePath();
                    ObjBOL.PackingList = hfgetdrawing.Value;
                }
                if (btnSave.Text == "Save")
                {
                    ObjBOL.Operation = 3;
                }
                else
                {
                    ObjBOL.Operation = 9;
                }
                if (ddlContainerNo.SelectedIndex > 0)
                {
                    ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
                }
                else
                {
                    ObjBOL.Containerid = 0;
                }
                ObjBOL.ShipFromID = Convert.ToInt32(ddlShipmentFrom.SelectedValue);
                ObjBOL.ShipByID = Convert.ToInt32(ddlShipmentby.SelectedValue);
                ObjBOL.ContainerNo = txtContainerNum.Text.Trim();
                ObjBOL.ShipDate = Utility.ConvertDate(txtShippedDate.Text);
                ObjBOL.ETA = Utility.ConvertDate(txtETAAsPerPL.Text);
                ObjBOL.RecDate = Utility.ConvertDate(txtReceivedDate.Text);
                if (RevisedETA != "" || Comments != "")
                {
                    ObjBOL.RevisedETA = Utility.ConvertDate(RevisedETA);
                    ObjBOL.Comments = Comments;
                }
                msg = ObjBLL.SaveShipmentDetail(ObjBOL);
                if (msg == "Records Updated Successfully !!!" || msg == "Duplicate Container Number!!!")
                {
                    if (msg == "Duplicate Container Number!!!")
                    {
                        Utility.ShowMessage_Error(Page, msg);
                    }
                    else
                    {
                        Utility.ShowMessage_Success(this, msg);
                        Utility.MaintainLogsSpecial("FrmShipmentInfo", "Update", ddlContainerNo.SelectedValue);
                    }
                    if (ddlContainerNo.SelectedIndex > 0)
                    {
                        Bind_ControlContainer(Convert.ToInt32(ddlContainerNo.SelectedValue));
                    }
                }
                else
                {
                    Bind_ControlContainer(Convert.ToInt32(msg));
                    Utility.ShowMessage_Success(this, "Records Added Successfully !!!");
                    Utility.MaintainLogsSpecial("FrmShipmentInfo", "Save", msg);
                }
                Bind_Grid();
                FillDetails();
                ddlContainerNo.SelectedIndex = 0;
                Reset();
            }
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
            Save();
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
            lnkDowload.Visible = true;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 7;
            ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
            ds = ObjBLL.GetShipmentDetail(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlShipmentFrom.SelectedValue = ds.Tables[0].Rows[0]["ShipFromID"].ToString();
                ddlShipmentby.SelectedValue = ds.Tables[0].Rows[0]["ShipByid"].ToString();
                txtContainerNum.Text = ds.Tables[0].Rows[0]["ContainerNo"].ToString();
                txtShippedDate.Text = ds.Tables[0].Rows[0]["ShipDate"].ToString();
                txtETAAsPerPL.Text = ds.Tables[0].Rows[0]["ETA"].ToString();
                txtReceivedDate.Text = ds.Tables[0].Rows[0]["RecDate"].ToString();
                hfgetdrawing.Value = ds.Tables[0].Rows[0]["PackingList"].ToString();
                if (hfgetdrawing.Value != "")
                {
                    //string[] filename = hfgetdrawing.Value.Replace(",", "").Replace("'", "").Split(new char[] { '/' });
                    //string file = filename[4].ToString();
                    FileInfo file = new FileInfo(saveFolder + ds.Tables[0].Rows[0]["PackingList"].ToString());
                    if (file.Exists)
                    {
                        lnkDowload.Text = hfgetdrawing.Value;
                    }
                    else
                    {
                        lnkDowload.Text = String.Empty;
                    }
                }
                else
                {
                    lnkDowload.Text = String.Empty;
                }
                Bind_Grid();
                btnSave.Text = "Update";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlContainerNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlContainerNo.SelectedIndex > 0)
            {
                FillDetails();
            }
            else
            {
                Reset();
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
            if (ValidationCheck() == true)
            {
                //string RevisedETA = (GvShipmentTracker.FooterRow.FindControl("txtFooterRevisedETA") as TextBox).Text;
                //string Comments = (GvShipmentTracker.FooterRow.FindControl("txtFooterComments") as TextBox).Text;
                //string msg = "";
                //ObjBOL.Operation = 5;
                //ObjBOL.ShipInfo = Convert.ToInt32(ddlContainerNo.SelectedValue);
                //ObjBOL.RevisedETA = Utility.ConvertDate(RevisedETA);
                //ObjBOL.Comments = Comments;
                //msg = ObjBLL.SaveShipmentInfoDetail(ObjBOL);
                //Bind_Grid();
                if (ValidationCheckRevisedETA() == true)
                {
                    Save();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvShipmentTracker_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GvShipmentTracker.EditIndex = e.NewEditIndex;
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvShipmentTracker_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            GvShipmentTracker.EditIndex = -1;
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvShipmentTracker_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            Int32 ID = Convert.ToInt32(GvShipmentTracker.DataKeys[e.RowIndex].Value);
            ObjBOL.Operation = 6;
            ObjBOL.ShipInfoDetailid = ID;
            msg = ObjBLL.DeleteShipmentInfoDetail(ObjBOL);
            Utility.ShowMessage_Success(this, msg);
            Utility.MaintainLogsSpecial("FrmShipmentInfo", "Delete", ddlContainerNo.SelectedValue);
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void GvShipmentTracker_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow row = GvShipmentTracker.Rows[e.RowIndex];
            string RevisedETA = (row.FindControl("txtUpdateRevisedETA") as TextBox).Text;
            string Comments = (row.FindControl("txtUpdateComments") as TextBox).Text;
            string msg = "";
            Int32 ID = Convert.ToInt32(GvShipmentTracker.DataKeys[e.RowIndex].Value);
            ObjBOL.Operation = 4;
            ObjBOL.ShipInfoDetailid = ID;
            ObjBOL.ShipInfo = Convert.ToInt32(ddlContainerNo.SelectedValue);
            ObjBOL.RevisedETA = Utility.ConvertDate(RevisedETA);
            ObjBOL.Comments = Comments;
            msg = ObjBLL.UpdateShipmentInfoDetail(ObjBOL);
            Utility.ShowMessage_Success(this, "Records Updated Successfully !!!");
            Utility.MaintainLogsSpecial("FrmShipmentInfo", "Update", ddlContainerNo.SelectedValue);
            GvShipmentTracker.EditIndex = -1;
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
            ddlShipmentFrom.SelectedIndex = 0;
            ddlShipmentby.SelectedIndex = 0;
            txtContainerNum.Text = String.Empty;
            txtShippedDate.Text = String.Empty;
            txtReceivedDate.Text = String.Empty;
            txtETAAsPerPL.Text = String.Empty;
            lnkDowload.Text = String.Empty;
            GvShipmentTracker.DataSource = EmptyDT();
            GvShipmentTracker.DataBind();
            GvShipmentTracker.Rows[0].Visible = false;
            btnSave.Text = "Save";
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
            ddlContainerNo.SelectedIndex = 0;
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
            hfgetdrawing.Value = String.Empty;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 8;
            ObjBOL.Containerid = Convert.ToInt32(ddlContainerNo.SelectedValue);
            ds = ObjBLL.GetShipmentDetail(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hfgetdrawing.Value = ds.Tables[0].Rows[0]["PackingList"].ToString();
            }
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
            string filePath = saveFolder + hfgetdrawing.Value;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                ////Clear Rsponse reference
                //Response.Clear();
                //// Add header by specifying file name  
                //Response.AddHeader("Content-Disposition", "attachment; filename=\"" + file.Name + "");
                //// Add header for content length  
                //Response.AddHeader("Content-Length", file.Length.ToString());
                //// Specify content type  
                //Response.ContentType = "text/plain";
                //// Clearing flush  
                //Response.Flush();
                //// Transimiting file  
                //Response.TransmitFile(file.FullName);
                //Response.End();

                if (file.Extension == ".pdf")
                {
                    WebClient User = new WebClient();
                    Byte[] FileBuffer = User.DownloadData(filePath);
                    if (FileBuffer != null)
                    {

                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.AddHeader("Content-Disposition", "filename=\"" + file.Name.Replace(",", "").Replace("'", "") + "");
                        Response.AddHeader("Content-Length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                }
                else
                {
                    Response.Clear();
                    Response.ContentType = "application/ms-excel";
                    Response.AppendHeader("content-disposition", "filename="
                        + file.Name.Replace(",", "").Replace("'", ""));
                    Response.WriteFile(filePath);
                    Response.Flush();
                    Response.End();
                }


            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}