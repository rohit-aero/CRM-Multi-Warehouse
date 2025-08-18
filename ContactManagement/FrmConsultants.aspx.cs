using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
/// <summary>
///  Proposal Form (30 May 2018) Rohit Kumar
/// </summary>
public partial class ContactManagement_FrmConsultants : System.Web.UI.Page
{
    BOLManageConsultant ObjBOL = new BOLManageConsultant();
    BLLManageConsultant ObjBLL = new BLLManageConsultant();

    BOLManageConsultantMember ObjBOLMember = new BOLManageConsultantMember();
    BLLManageConsultantMember ObjBLLMember = new BLLManageConsultantMember();
    string saveFolder = string.Empty;
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    public static readonly List<string> Extensions = new List<string> { "jpg", "doc", "pdf" };
    // Page load event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            GetFilePaths();
            if (!IsPostBack)
            {
                Bind_Controls();
                if (string.IsNullOrEmpty(Request.QueryString["consultant"]) == false)
                {
                    ddlConsultant.SelectedValue = Request.QueryString["consultant"];
                    FillConsultantDetail();
                }
                if (Session["PNumber"] != null)
                {
                    //btnBack.Enabled = true;
                }
                else
                {
                    //btnBack.Enabled = false;
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
        saveFolder = Utility.ConsultantDocsPath();
    }

    /// <summary>
    /// Prepare drop down lists
    /// </summary>
    // Bind all dropdownlist here
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetConsultant(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConsultant, ds.Tables[0]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCountry, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSalesRep, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPrefVendor1, ds.Tables[4]);
                Utility.BindDropDownList(ddlPrefVendor2, ds.Tables[4]);
                Utility.BindDropDownList(ddlPrefVendor3, ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlFoodPref, ds.Tables[5]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    // Get P# from Project Name
    //protected void txtPName_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (txtCompanyName.Text != "")
    //        {
    //            string output = "";
    //            int openTagEndPosition = output.IndexOf("#");
    //            output = output.Substring(openTagEndPosition + 1);
    //            FillDetailsFromPnumber(output);
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        Utility.AddEditException(ex);
    //    }

    //}
    /// <summary>
    /// AutoFill records in the form
    /// if ddlconsultant changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlConsultant_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillConsultantDetail();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// FillConsultantDetail() function fetch values from database server
    /// and display records in the form
    /// </summary>
    private void FillConsultantDetail()
    {
        try
        {
            if (ddlConsultant.SelectedIndex > 0)
            {
                btnSave.Text = "Update";
                hfCusId.Value = ddlConsultant.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.ConsultantID = Convert.ToInt32(ddlConsultant.SelectedValue);
                ds = ObjBLL.GetConsultant(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
                {
                    { "CompanyName", d=> txtCompanyName.Text = Convert.ToString(d["CompanyName"]) },
                    { "StreetAdd", d => txtAddress.Text = Convert.ToString(d["StreetAdd"]) },
                    { "City", d => txtCity.Text = Convert.ToString(d["City"]) },
                    { "Country", d => ddlCountry.SelectedValue = Convert.ToString(d["ConsultantCountryID"]) },
                    { "ConsultantCountryID", d =>
                        {
                            if (d["ConsultantCountryID"].ToString() != "")
                            {
                                BindState(Convert.ToInt16(d["ConsultantCountryID"]));
                            }
                            if (Convert.ToString(d["StateID"]) != "")
                            {
                                ddlState.SelectedValue = Convert.ToString(d["StateID"]);
                                ddlStateAb.SelectedValue = Convert.ToString(d["StateID"]);
                            }
                        }
                    },
                    { "ZipCode", d => txtZipCode.Text = Convert.ToString(d["ZipCode"]) },
                    { "TollFree", d => txtTollFree.Text = Convert.ToString(d["TollFree"]) },
                    { "Fax", d => txtFax.Text = Convert.ToString(d["Fax"]) },
                    { "Phone", d => txtPhone.Text = Convert.ToString(d["Phone"]) },
                    { "PrefVendor1", d =>
                        {
                            if(ddlPrefVendor1.Items.FindByValue(Convert.ToString(d["PrefVendor1"])) != null)
                            {
                                ddlPrefVendor1.SelectedValue = Convert.ToString(d["PrefVendor1"]);
                            }
                        }
                    },
                    { "PrefVendor2", d =>
                        {
                            if(ddlPrefVendor2.Items.FindByValue(Convert.ToString(d["PrefVendor2"])) != null)
                            {
                                ddlPrefVendor2.SelectedValue = Convert.ToString(d["PrefVendor2"]);
                            }
                        }
                    },
                    { "PrefVendor3", d =>
                        {
                            if(ddlPrefVendor3.Items.FindByValue(Convert.ToString(d["PrefVendor3"])) != null)
                            {
                                ddlPrefVendor3.SelectedValue = Convert.ToString(d["PrefVendor3"]);
                            }
                        }
                    },
                    { "PrefFood", d =>
                        {
                            if(ddlFoodPref.Items.FindByValue(Convert.ToString(d["PrefFood"])) != null)
                            {
                                ddlFoodPref.SelectedValue = Convert.ToString(d["PrefFood"]);
                            }
                        }
                    },
                    { "NatureofConsultant", d =>
                        {
                            if(ddlnatureConsul.Items.FindByValue(Convert.ToString(d["NatureofConsultant"])) != null)
                            {
                               ddlnatureConsul.SelectedValue = Convert.ToString(d["NatureofConsultant"]);
                            }
                        }
                    },
                    { "ConsPref", d => txtConsPref.Text = Convert.ToString(d["ConsPref"]) },
                    { "Consultantstatus", d =>
                        {
                            if(ddlStatus.Items.FindByValue(Convert.ToString(d["Consultantstatus"])) != null)
                            {
                                ddlStatus.SelectedValue = Convert.ToString(d["Consultantstatus"]);
                            }
                        }
                    },
                    { "TSM", d =>
                        {
                            if(ddlSalesRep.Items.FindByValue(Convert.ToString(d["TSM"])) != null)
                            {
                                ddlSalesRep.SelectedValue = Convert.ToString(d["TSM"]);
                            }
                        }
                    }
                };

                    foreach (var assignment in assignments)
                    {
                        try
                        {
                            assignment.Value(ds.Tables[0].Rows[0]);
                        }
                        catch (Exception ex)
                        {
                            Utility.AddEditException(ex, assignment.Key);
                        }
                    }

                    if (ds.Tables[0].Rows[0]["emailpath"].ToString() != "")
                    {
                        FileInfo file = new FileInfo(saveFolder + ds.Tables[0].Rows[0]["emailpath"].ToString());
                        if (file.Exists)
                        {
                            btnDelete.Enabled = true;
                            string emailpath = ds.Tables[0].Rows[0]["emailpath"].ToString();
                            Hfemailpath.Value = saveFolder + emailpath;
                            //string[] emailname = emailpath.Split(new char[] { '/' });
                            lnkAttachment.Visible = true;
                            lnkAttachment.Text = emailpath.ToString();
                        }
                        else
                        {
                            lnkAttachment.Visible = false;
                            lnkAttachment.Text = String.Empty;
                            btnDelete.Enabled = false;
                        }
                    }
                    else
                    {
                        lnkAttachment.Visible = false;
                        lnkAttachment.Text = String.Empty;
                        btnDelete.Enabled = false;
                    }
                    lblMsg.Text = "";
                    btnProjects.Enabled = true;
                    btnProposals.Enabled = true;
                }
                else
                {
                    btnProjects.Enabled = false;
                    btnProposals.Enabled = false;
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    gvMember.DataSource = ds.Tables[1];
                    gvMember.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    gvMember.DataSource = dt;
                    gvMember.DataBind();
                }
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
    /// <summary>
    /// Bind_Members() function display related members of 
    /// consultant in 
    /// grid view control
    /// </summary>
    //Bind Members on Customer name change event
    private void Bind_Members()
    {
        try
        {
            ObjBOL.Operation = 2;
            ObjBOL.ConsultantID = Convert.ToInt32(hfCusId.Value);
            DataSet ds = new DataSet();
            ds = ObjBLL.GetConsultant(ObjBOL);
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            gvMember.DataSource = ds.Tables[1];
            gvMember.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // Fill all details 
    private void FillDetailsFromPnumber(string strPNumber)
    {
        try
        {
            //DataSet ds = new DataSet();
            //ObjBOL.Operation = 4;           
            //ds = ObjBLL.GetCustomers(ObjBOL);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    //txtProNO.Text = Convert.ToString(ds.Tables[0].Rows[0]["PNumber"]);
            //    //txtProDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["ProposalDate"]));
            //    //txtJobID.Text = Convert.ToString(ds.Tables[0].Rows[0]["JobID"]);
            //    //txtProjectName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProjectName"]);
            //    txtCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]);
            //    ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["StateID"]);
            //    ddlStateAb.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["StateID"]);
            //    ddlCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Country"]);
            //    lblMsg.Text = "";
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Display State Abbreviation on change of
    /// ddlState drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Set State value on Abbrevation
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlState.SelectedIndex > 0)
            {
                ddlStateAb.SelectedValue = ddlState.SelectedValue;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Display State on change of
    /// State Abbreviation Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Set Abbrevation value on State
    protected void ddlStateAb_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlStateAb.SelectedIndex > 0)
            {
                ddlState.SelectedValue = ddlStateAb.SelectedValue;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Mandatory check
    /// </summary>
    /// <returns></returns>
    // check if data filled in required fields
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtCompanyName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Company Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Company Name. !");
                txtCompanyName.Focus();
                return false;
            }
            if (ddlCountry.SelectedIndex <= 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Country. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Country. !");
                ddlCountry.Focus();
                return false;
            }
            if (ddlCountry.SelectedIndex > 0)
            {
                if (ddlState.SelectedIndex == 0)
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select State. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Select State. !");
                    ddlState.Focus();
                    return false;
                }
            }
            if (ddlStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Status. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                ddlStatus.Focus();
                return false;
            }

            if (fpUpload.HasFile)
            {
                if (!Extensions.Contains(fpUpload.FileName.Split('.')[1]))
                {
                    Utility.ShowMessage_Error(Page, "Only .jpg, .doc, .pdf formats are allowed !");
                    return false;
                }
                else
                {
                    int fileSize = fpUpload.PostedFile.ContentLength;
                    // Convert the bytes to Kilobytes (1 KB = 1024 Bytes)
                    double fileSizeInKB = fileSize / 1024.0;
                    if (fileSizeInKB > Utility.FileSizeLimits(fpUpload.FileName.Split('.')[1]))
                    {
                        Utility.ShowMessage_Error(Page, "File size exceeds " + Utility.FileSizeLimits(fpUpload.FileName.Split('.')[1]) + "KB. Please choose a smaller file. !!");
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
    /// <summary>
    /// Clear controls
    /// </summary>
    // Reset all controls
    private void Reset()
    {
        try
        {
            Bind_Controls();
            btnSave.Text = "Save";
            ddlConsultant.SelectedIndex = 0;
            txtCompanyName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            ddlState.DataSource = "";
            ddlState.DataBind();
            ddlStateAb.DataSource = "";
            ddlStateAb.DataBind();
            ddlCountry.SelectedIndex = 0;
            txtZipCode.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtTollFree.Text = string.Empty;
            txtFax.Text = string.Empty;
            ddlSalesRep.SelectedIndex = 0;
            ddlPrefVendor1.SelectedIndex = 0;
            ddlPrefVendor2.SelectedIndex = 0;
            ddlPrefVendor3.SelectedIndex = 0;
            ddlFoodPref.SelectedIndex = 0;
            ddlnatureConsul.SelectedIndex = 0;
            txtConsPref.Text = string.Empty;
            ddlStatus.SelectedIndex = 0;
            lnkAttachment.Text = String.Empty;
            lnkAttachment.Visible = false;
            btnDelete.Enabled = false;
            lblMsg.Text = "";
            DataTable dt = new DataTable();
            gvMember.DataSource = dt;
            gvMember.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Save data after entered mandatory data 
    /// in the form
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Save data
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = "";
                if (ddlConsultant.SelectedIndex > 0)
                {
                    ObjBOL.ConsultantID = Convert.ToInt32(ddlConsultant.SelectedValue);
                }
                else
                {
                    ObjBOL.ConsultantID = 0;
                }
                ObjBOL.Operation = 3;
                ObjBOL.CompanyName = txtCompanyName.Text;
                ObjBOL.StreetAdd = txtAddress.Text;
                ObjBOL.City = txtCity.Text;
                ObjBOL.Country = ddlCountry.SelectedItem.Text;
                if (ddlState.SelectedIndex > 0)
                {
                    ObjBOL.StateID = Convert.ToInt32(ddlState.SelectedValue);
                }
                ObjBOL.ZipCode = txtZipCode.Text;
                ObjBOL.Phone = txtPhone.Text;
                ObjBOL.TollFree = txtTollFree.Text;
                ObjBOL.Fax = txtFax.Text;
                ObjBOL.TSM = Convert.ToInt16(ddlSalesRep.SelectedValue);
                ObjBOL.ConsPref = txtConsPref.Text;
                ObjBOL.PrefVendor1 = Convert.ToInt32(ddlPrefVendor1.SelectedValue);
                ObjBOL.PrefVendor2 = Convert.ToInt32(ddlPrefVendor2.SelectedValue);
                ObjBOL.PrefVendor3 = Convert.ToInt32(ddlPrefVendor3.SelectedValue);
                ObjBOL.PrefFood = Convert.ToInt32(ddlFoodPref.SelectedValue);
                ObjBOL.NatureofConsultant = ddlnatureConsul.SelectedValue;
                if (ddlStatus.SelectedIndex > 0)
                {
                    ObjBOL.status = Convert.ToInt32(ddlStatus.SelectedValue);
                }
                if (fpUpload.HasFile)
                {
                    string consultantname = ddlConsultant.SelectedItem.Text;
                    string strpath = System.IO.Path.GetExtension(fpUpload.FileName);
                    //string name = saveFolder + fpUpload.FileName;
                    //string[] filename = name.Split(new char[] { '/' });
                    string changefilewithconsultant = ddlConsultant.SelectedItem.Text + strpath;
                    changefilewithconsultant = changefilewithconsultant.Replace(System.Environment.NewLine, string.Empty);
                    fpUpload.SaveAs(saveFolder + changefilewithconsultant);
                    ObjBOL.Emailpath = changefilewithconsultant;

                }
                else
                {
                    if (lnkAttachment.Text != "")
                    {
                        string consultantname = ddlConsultant.SelectedItem.Text;
                        string strpath = System.IO.Path.GetExtension(lnkAttachment.Text);
                        //string name = saveFolder + lnkAttachment.Text;
                        //string[] filename = name.Split(new char[] { '/' });
                        string changefilewithconsultant = ddlConsultant.SelectedItem.Text + strpath;
                        changefilewithconsultant = changefilewithconsultant.Replace(System.Environment.NewLine, string.Empty);
                        fpUpload.SaveAs(saveFolder + changefilewithconsultant);
                        ObjBOL.Emailpath = changefilewithconsultant;
                    }

                }
                msg = ObjBLL.SaveConsultant(ObjBOL);
                if (msg.Trim() != "")
                {
                    if (msg.Trim() == "ER01")
                    {
                        Utility.ShowMessage_Error(this, "Consultant with same company name and Address already exists !");
                        return;
                    }

                    if (msg.Trim() == "ER02")
                    {
                        Utility.ShowMessage_Error(this, "Consultant ID doesnot exists !");
                        return;
                    }

                    string successMessage = string.Empty;
                    if (ddlConsultant.SelectedIndex > 0)
                    {
                        hfCusId.Value = ddlConsultant.SelectedValue;
                        successMessage = "Record updated successfully !";
                    }
                    else
                    {
                        hfCusId.Value = msg;
                        successMessage = "Record inserted successfully !";
                    }
                    Utility.ShowMessage_Success(this, successMessage);
                    Utility.MaintainLogsSpecial("FrmConsultants.aspx", btnSave.Text, hfCusId.Value);
                    Reset();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    // Cancel command
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Reset();
            hfCusId.Value = "-1";
            btnProjects.Enabled = false;
            btnProposals.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // check if data filled in required fields of Member
    private Boolean ValidationCheckMember()
    {
        try
        {
            if (txtFName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter First Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter First Name. !");
                txtFName.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }
    /// <summary>
    /// Add members in the grid view control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddMember_Click(object sender, EventArgs e)
    {
        try
        {
            if (hfCusId.Value != "-1")
            {
                if (ValidationCheckMember() == true)
                {
                    string msg = "";
                    ObjBOLMember.Operation = 4;
                    ObjBOLMember.ConsultantID = Convert.ToInt16(ddlConsultant.SelectedValue);
                    ObjBOLMember.FirstName = txtFName.Text;
                    ObjBOLMember.LastName = txtLName.Text;
                    ObjBOLMember.JobTitle = txtJobTitle.Text;
                    ObjBOLMember.TelephoneExtension = txtExten.Text;
                    ObjBOLMember.Email = txtEmail.Text;
                    ObjBOLMember.DirectLine = txtDirectLine.Text;
                    msg = ObjBLLMember.SaveConsultantMember(ObjBOLMember);
                    if (msg.Trim() != "")
                    {
                        if (msg.Trim() == "ER01")
                        {
                            Utility.ShowMessage_Error(this, "Contact with the same name already exists for the consultant !");
                            return;
                        }
                        Utility.MaintainLogsSpecial("FrmConsultants.aspx", "Add-Contact", ddlConsultant.SelectedValue);
                        Utility.ShowMessage_Success(this, msg);
                        Bind_Members();
                        Reset_Member();
                    }
                }
            }
            else
            {
                Utility.ShowMessage_Error(this, "Please Enter Customer Detail First !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Clear member controls
    /// </summary>
    // clear member detail
    private void Reset_Member()
    {
        try
        {
            //ddlConsultant.SelectedIndex = 0;
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtJobTitle.Text = string.Empty;
            txtExten.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDirectLine.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Deleted member row data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMember_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        try
        {
            int ContactID = Convert.ToInt32(gvMember.DataKeys[e.RowIndex].Values[0]);
            string msg = "";
            ObjBOLMember.Operation = 6;
            ObjBOLMember.ConsultantMemberID = ContactID;
            ObjBOLMember.ConsultantID = Convert.ToInt16(hfCusId.Value);
            msg = ObjBLLMember.DeleteConsultantMember(ObjBOLMember);
            if (msg.Trim() != "")
            {
                Utility.ShowMessage_Success(Page, "Member Deleted Successfully !!");
                Utility.MaintainLogsSpecial("FrmConsultants.aspx", "Delete-Contact", ddlConsultant.SelectedValue);
            }
            Bind_Members();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Edit information 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMember_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            gvMember.EditIndex = e.NewEditIndex;
            Bind_Members();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Change in records
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMember_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = gvMember.Rows[e.RowIndex];
            ObjBOLMember.Operation = 5;
            ObjBOLMember.ConsultantMemberID = Convert.ToInt32(gvMember.DataKeys[e.RowIndex].Values[0]);
            ObjBOLMember.ConsultantID = Convert.ToInt16(ddlConsultant.SelectedValue);
            ObjBOLMember.JobTitle = (row.FindControl("txtTitle") as TextBox).Text;
            if ((row.FindControl("txtFName") as TextBox).Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter First Name. !");
                (row.FindControl("txtFName") as TextBox).Focus();
                return;
            }
            ObjBOLMember.FirstName = (row.FindControl("txtFName") as TextBox).Text;
            ObjBOLMember.LastName = (row.FindControl("txtLName") as TextBox).Text;
            ObjBOLMember.TelephoneExtension = (row.FindControl("txtExtension") as TextBox).Text;
            ObjBOLMember.DirectLine = (row.FindControl("txtDirect") as TextBox).Text;
            ObjBOLMember.Email = (row.FindControl("txtEmail") as TextBox).Text;
            msg = ObjBLLMember.SaveConsultantMember(ObjBOLMember);
            if (msg.Trim() != "")
            {
                if (msg.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(this, "Contact with the same name already exists for the consultant !");
                    return;
                }
                Utility.ShowMessage_Success(Page, "Member Updated Successfully !!");
                Utility.MaintainLogsSpecial("FrmConsultants.aspx", "Update-Contact", ddlConsultant.SelectedValue);
                gvMember.EditIndex = -1;
            }
            Bind_Members();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Fix no. of records in one time
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMember_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        try
        {
            gvMember.PageIndex = e.NewPageIndex;
            Bind_Members();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Cancel all information in members controls
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMember_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvMember.EditIndex = -1;
            Bind_Members();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Back to the proposal page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnBack_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Response.Redirect("~/Transactions/FrmProposals.aspx");
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            String msg = "";
            ObjBOL.Operation = 8;
            ObjBOL.ConsultantID = Convert.ToInt32(ddlConsultant.SelectedValue);
            msg = ObjBLL.DeleteConsultantEmailPath(ObjBOL);
            if (lnkAttachment.Text != "")
            {
                //Folder Path
                lnkAttachment.Visible = true;
                string filePath = Hfemailpath.Value;
                if (System.IO.File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Utility.ShowMessage_Success(this, msg);
                    lnkAttachment.Visible = false;
                    lnkAttachment.Text = string.Empty;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void lnkAttachment_Click(object sender, EventArgs e)
    {
        try
        {
            string filePath = Hfemailpath.Value;
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

    private void BindState(Int16 country)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 9;
            ObjBOL.CountryID = country;
            ds = ObjBLL.GetConsultantState(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlState, ds.Tables[0]);
            }
            else
            {
                ddlState.DataSource = "";
                ddlState.DataBind();
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlStateAb, ds.Tables[0]);
            }
            else
            {
                ddlStateAb.DataSource = "";
                ddlStateAb.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindState(Convert.ToInt16(ddlCountry.SelectedValue));
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnProposals_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlConsultant.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                rprt.Load(Server.MapPath("~/Reports/rptProposalsUnderConsultant.rpt"));
                clscon.Return_DT(dt, "EXEC [dbo].[Get_JobsUnderConsultant]  1," + ddlConsultant.SelectedValue + "");
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }

    protected void btnProjects_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlConsultant.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                rprt.Load(Server.MapPath("~/Reports/rptJobsUnderConsultant.rpt"));
                clscon.Return_DT(dt, "EXEC [dbo].[Get_JobsUnderConsultant]  2," + ddlConsultant.SelectedValue + "");
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
                rprt.Close();
                rprt.Dispose();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

}