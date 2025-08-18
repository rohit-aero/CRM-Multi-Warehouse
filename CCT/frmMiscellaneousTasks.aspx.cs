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

public partial class CCT_frmMiscellaneousTasks : System.Web.UI.Page
{
    BOLMiscellaneousTasks ObjBOL = new BOLMiscellaneousTasks();
    BLLMiscellaneousTasks ObjBLL = new BLLMiscellaneousTasks();
    public static readonly List<string> Extensions = new List<string> { "jpg", "doc", "pdf" };
    string saveFolder = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            GetFilePaths();
            if (!IsPostBack)
            {
                BindControls();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #region Bind Functions

    private void GetFilePaths()
    {
        try
        {
            saveFolder = Utility.MiscellaneousTaskPath();
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
            ds = ObjBLL.Return_DataSet(ObjBOL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlTaskHeaderList, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Validation

    private bool ValidationCheck()
    {
        try
        {
            if (txtCompanyName.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Company Name !");
                txtCompanyName.Focus();
                return false;
            }

            if (txtRefNo.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Reference No. !");
                txtRefNo.Focus();
                return false;
            }

            if (fpUploadDoc.HasFile)
            {
                if (!Extensions.Contains(fpUploadDoc.FileName.Split('.')[1]))
                {
                    Utility.ShowMessage_Error(Page, "Only .jpg, .doc, .pdf formats are allowed !");
                    return false;
                }
                else
                {
                    int fileSize = fpUploadDoc.PostedFile.ContentLength;
                    // Convert the bytes to Kilobytes (1 KB = 1024 Bytes)
                    double fileSizeInKB = fileSize / 1024.0;
                    if (fileSizeInKB > Utility.FileSizeLimits(fpUploadDoc.FileName.Split('.')[1]))
                    {
                        Utility.ShowMessage_Error(Page, "File size exceeds " + Utility.FileSizeLimits(fpUploadDoc.FileName.Split('.')[1]) + "KB. Please choose a smaller file. !!");
                        return false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    #endregion

    #region Event Handlers

    protected void ddlTaskHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTaskHeaderList_SelectedIndexChanged_Event();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave_Click_Event();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel_Click_Event();
    }

    protected void lnkDowload_Click(object sender, EventArgs e)
    {
        try
        {
            string folderPath = hfFileAddress.Value;
            string extension = hfFileAddress.Value.Split('.')[1];
            //string filePath = Server.MapPath(folderPath);
            string filePath = saveFolder + folderPath;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                if (file.Exists)
                {
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "text/plain";
                    Response.Flush();
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

    protected void btnFilterForm_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Reports/frmMiscellaneousTasksReport.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Other Functions

    private void ddlTaskHeaderList_SelectedIndexChanged_Event()
    {
        try
        {
            if (ddlTaskHeaderList.SelectedIndex > 0)
            {
                ObjBOL.ID = Int32.Parse(ddlTaskHeaderList.SelectedValue);
                ObjBOL.Operation = 2;
                DataSet ds = new DataSet();
                ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
                {
                    { "CompanyName", d => txtCompanyName.Text = d["CompanyName"].ToString() },
                    { "Location", d => txtLocation.Text = d["Location"].ToString() },
                    { "RefNo", d => txtRefNo.Text = d["RefNo"].ToString() },
                    { "Contact", d => txtContact.Text = d["Contact"].ToString() },
                    { "Issue", d => txtIssue.Text = d["Issue"].ToString() },
                    { "IssueDate", d => txtIssueDate.Text = d["IssueDate"].ToString() },
                    { "IssueBy", d => txtIssueBy.Text = d["IssueBy"].ToString() },
                    { "Solution", d => txtSolution.Text = d["Solution"].ToString() },
                    { "SolutionDate", d => txtSolutionDate.Text = d["SolutionDate"].ToString() },
                    { "Description", d => txtDescription.Text = d["Description"].ToString() },
                };

                    foreach (var assignment in assignments)
                    {
                        try
                        {
                            assignment.Value(dr);
                        }
                        catch (Exception ex)
                        {
                            Utility.AddEditException(ex, assignment.Key);
                        }
                    }

                    if (ds.Tables[0].Rows[0]["DocPath"].ToString() != "")
                    {
                        FileInfo file = new FileInfo(saveFolder + ds.Tables[0].Rows[0]["DocPath"].ToString());
                        if (file.Exists)
                        {
                            hfFileAddress.Value = ds.Tables[0].Rows[0]["DocPath"].ToString();
                            lnkDowload.Visible = true;
                        }
                        else
                        {
                            hfFileAddress.Value = string.Empty;
                            lnkDowload.Visible = false;
                        }
                    }
                    else
                    {
                        hfFileAddress.Value = string.Empty;
                        lnkDowload.Visible = false;
                    }
                    btnSave.Text = "Update";
                }
            }
            else
            {
                btnCancel_Click_Event();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnSave_Click_Event()
    {
        try
        {
            if (ValidationCheck())
            {
                string saveOrUpdate = "";
                ObjBOL.CompanyName = txtCompanyName.Text;
                ObjBOL.Location = txtLocation.Text;
                ObjBOL.RefNo = txtRefNo.Text;
                ObjBOL.Contact = txtContact.Text;
                ObjBOL.Issue = txtIssue.Text;
                ObjBOL.IssueBy = txtIssueBy.Text;
                ObjBOL.Solution = txtSolution.Text;
                ObjBOL.Description = txtDescription.Text;
                if (txtIssueDate.Text != "")
                {
                    ObjBOL.IssueDate = Utility.ConvertDate(txtIssueDate.Text);
                }

                if (txtSolutionDate.Text != "")
                {
                    ObjBOL.SolutionDate = Utility.ConvertDate(txtSolutionDate.Text);
                }

                if (fpUploadDoc.HasFile)
                {
                    //string folderPath = Server.MapPath(saveFolder);
                    string folderPath = saveFolder;
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string filename = fpUploadDoc.FileName.Replace(",", "").Replace("'", "");
                    fpUploadDoc.SaveAs(folderPath + fpUploadDoc.FileName.Replace(",", "").Replace("'", ""));
                    ObjBOL.DocPath = filename;
                }
                else
                {
                    ObjBOL.DocPath = hfFileAddress.Value;
                }

                if (btnSave.Text == "Save")
                {
                    ObjBOL.Operation = 3;
                    saveOrUpdate = "Save";
                }
                else
                {
                    ObjBOL.Operation = 4;
                    ObjBOL.ID = Int32.Parse(ddlTaskHeaderList.SelectedValue);
                    saveOrUpdate = "Update";
                }

                string returnValue = ObjBLL.Return_String(ObjBOL);
                if (returnValue.Trim() != "")
                {
                    if (saveOrUpdate == "Save")
                    {
                        btnCancel_Click_Event();
                        BindControls();
                        ddlTaskHeaderList.SelectedValue = returnValue.Trim();
                        ddlTaskHeaderList_SelectedIndexChanged_Event();
                        Utility.MaintainLogsSpecial("frmMiscellaneousTasks", "Save", returnValue.Trim());
                        Utility.ShowMessage_Success(Page, "Record Inserted Successfully !!");
                    }
                    else if (saveOrUpdate == "Update")
                    {
                        string selectedID = ddlTaskHeaderList.SelectedValue;
                        btnCancel_Click_Event();
                        BindControls();
                        ddlTaskHeaderList.SelectedValue = selectedID;
                        ddlTaskHeaderList_SelectedIndexChanged_Event();
                        Utility.MaintainLogsSpecial("frmMiscellaneousTasks", "Update", selectedID);
                        Utility.ShowMessage_Success(Page, returnValue.Trim());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnCancel_Click_Event()
    {
        try
        {
            if (ddlTaskHeaderList.Items.Count > 0)
            {
                ddlTaskHeaderList.SelectedIndex = 0;
            }
            txtCompanyName.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtRefNo.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtIssue.Text = string.Empty;
            txtIssueDate.Text = string.Empty;
            txtIssueBy.Text = string.Empty;
            txtSolution.Text = string.Empty;
            txtSolutionDate.Text = string.Empty;
            txtDescription.Text = string.Empty;
            hfFileAddress.Value = string.Empty;
            lnkDowload.Visible = false;
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion   
}