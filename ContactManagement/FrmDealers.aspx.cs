using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
/// <summary>
///  Proposal Form (30 May 2018) Rohit Kumar
/// </summary>
public partial class ContactManagement_FrmDealers : System.Web.UI.Page
{
    // Create objects of Classes
    BOLManageDealers ObjBOL = new BOLManageDealers();
    BLLManageDealers ObjBLL = new BLLManageDealers();
    BOLManageDealerMember ObjBOLMember = new BOLManageDealerMember();
    BLLManageDealerMember ObjBLLMember = new BLLManageDealerMember();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    string saveFolder = string.Empty;
    public static readonly List<string> Extensions = new List<string> { ".pdf" };
    // Page load event
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
                    chkHeadOffice.Enabled = true;
                    if (string.IsNullOrEmpty(Request.QueryString["dealer"]) == false)
                    {
                        ddlDealer.SelectedValue = Request.QueryString["dealer"];
                        FillDealerDetail();
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
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void GetFilePaths()
    {
        saveFolder = Utility.DealerW9Path();
    }

    /// <summary>
    /// Bind drop down lists in the form
    /// </summary>
    // Bind all dropdownlist here
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetDealers(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCountry, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDealer, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRegion, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlFoodPre, ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRep, ds.Tables[5]);
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlHeadOffice, ds.Tables[6]);
            }
            //if (ds.Tables[7].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlTitle, ds.Tables[7]);
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// fill details on change of dealer drop down values
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>/
    // On Customer Selection
    protected void ddlDealer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillDealerDetail();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// For fill data in the form
    /// </summary>
    private void FillDealerDetail()
    {
        try
        {
            if (ddlDealer.SelectedIndex > 0)
            {
                btnSave.Text = "Update";
                hfCusId.Value = ddlDealer.SelectedValue;
                chkHeadOffice.Checked = false;
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.DealerID = Convert.ToInt32(ddlDealer.SelectedValue);
                ds = ObjBLL.GetDealers(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
                {
                    { "CompanyName", d => txtCompanyName.Text = Convert.ToString(d["CompanyName"]) },
                    { "FederalID", d => txtFedral.Text = Convert.ToString(d["FederalID"]) },
                    { "StreetAddress", d => txtAddress.Text = Convert.ToString(d["StreetAddress"]) },
                    { "City", d => txtCity.Text = Convert.ToString(d["City"]) },
                    { "CountryState", d =>
                        {
                            if(ddlCountry.Items.FindByValue(Convert.ToString(d["DealerCountryID"])) != null)
                            {
                                ddlCountry.SelectedValue = Convert.ToString(d["DealerCountryID"]);
                                BindState(d["DealerCountryID"].ToString());
                                if(ddlState.Items.FindByValue(Convert.ToString(d["StateID"])) != null)
                                {
                                    ddlState.SelectedValue = Convert.ToString(d["StateID"]);
                                    ddlStateAb.SelectedValue = ddlState.SelectedValue;
                                }                                
                            }
                        }
                    },
                    { "ZipCode", d => txtZipCode.Text = Convert.ToString(d["ZipCode"]) },
                    { "RegionID", d =>
                        {
                            if(ddlRegion.Items.FindByValue(Convert.ToString(d["RegionID"])) != null)
                            {
                                ddlRegion.SelectedValue = Convert.ToString(d["RegionID"]);
                            }
                        }
                    },
                    { "Phone", d => txtMainPhone.Text = Convert.ToString(d["Phone"]) },
                    { "TollFree", d => txtTollFree.Text = Convert.ToString(d["TollFree"]) },
                    { "Fax", d => txtMainFax.Text = Convert.ToString(d["Fax"]) },
                    { "TollFax", d => txtTollFax.Text = Convert.ToString(d["TollFax"]) },
                    { "Agreement", d =>
                        {
                            if (Convert.ToBoolean(d["Agreement"]) == true)
                            {
                                chkAgree.Checked = true;
                            }
                            else
                            {
                                chkAgree.Checked = false;
                            }
                        }
                    },
                    { "FoodPref", d =>
                        {
                            if(ddlFoodPre.Items.FindByValue(d["FoodPref"].ToString()) != null)
                            {
                                ddlFoodPre.SelectedValue = d["FoodPref"].ToString();
                            }
                        }
                    },
                    { "AgreedDiscount", d => txtDiscount.Text = Convert.ToString(d["AgreedDiscount"]) },
                    { "TSM", d =>
                        {
                            if(ddlRep.Items.FindByValue(Convert.ToString(d["TSM"])) != null)
                            {
                                ddlRep.SelectedValue = Convert.ToString(d["TSM"]);
                            }
                        }
                    },
                    { "HeadOffice", d =>
                        {
                                if(Convert.ToString(d["HeadOffice"]) == "0")
                                {
                                    //Head Office
                                    chkHeadOffice.Enabled=true;
                                    EnabledDisabledHeadOffice(chkHeadOffice.Checked);
                                    if(ddlHeadOffice.Items.FindByValue(Convert.ToString(d["HeadOffice"])) != null)
                                    {
                                        ddlHeadOffice.SelectedValue = Convert.ToString(d["HeadOffice"]);
                                    }
                                    
                                }
                                else
                                {
                                    //Select HeadOfice to Dealer Or Individual Dealer
                                    chkHeadOffice.Enabled=false;
                                    EnabledDisabledHeadOffice(chkHeadOffice.Checked);
                                    if(ddlHeadOffice.Items.FindByValue(Convert.ToString(d["HeadOffice"])) != null)
                                    {
                                        ddlHeadOffice.SelectedValue = Convert.ToString(d["HeadOffice"]);
                                        btnEditHeadOffice.Enabled=true;
                                    }
                                }
                        }
                    },
                    { "DealerPref", d => txtPrefrences.Text = Convert.ToString(d["DealerPref"]) },
                    { "Dealerstatus", d =>
                        {
                            if(ddlStatus.Items.FindByValue(d["Dealerstatus"].ToString()) != null)
                            {
                                ddlStatus.SelectedValue = d["Dealerstatus"].ToString();

                            }
                        }
                    },
                    {
                       "W9form", d =>
                       {
                           if(Convert.ToString(d["W9form"]) != null)
                           {
                               FileInfo file = new FileInfo(saveFolder + Convert.ToString(d["W9form"]));
                               if (file.Exists)
                                {                                                           
                                    string path = Convert.ToString(d["W9form"]);
                                    string pathLower= path.ToLower();
                                    Hfw9formpath.Value = pathLower.Replace(".pdf","");
                                    //string[] emailname = emailpath.Split(new char[] { '/' });
                                    lnkAttachment.Visible = true;
                                    lnkAttachment.Text = Hfw9formpath.Value;
                                }
                                else
                                {
                                    lnkAttachment.Visible = false;
                                    lnkAttachment.Text = String.Empty;                                    
                                }
                           }
                       }
                    },
                    {
                            "LastUpdatedDate", d=>
                            {
                                if(Convert.ToString(d["LastUpdatedDate"]) != null)
                                {
                                    dvLatUpdatedDate.Visible=true;
                                    lnkLastUpdatedDate.Text=Convert.ToString(d["LastUpdatedDate"]);
                                }
                                else
                                {
                                    lnkLastUpdatedDate.Text=String.Empty;
                                    dvLatUpdatedDate.Visible=false;
                                }
                            }

                    }
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

                    lblMsg.Text = "";
                    btnProposals.Enabled = true;
                }
                else
                {
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
                Reset_Member();
                ResetHeadOffice();
                //gvMember.AllowPaging = false;
                //gvMember.DataSource = "";
                //gvMember.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Bind members in Gridview control
    /// all the members linked with dealer drop down list
    /// </summary>
    // Bind Members on Customer name change event
    private void Bind_Members()
    {
        try
        {
            ObjBOL.Operation = 2;
            ObjBOL.DealerID = Convert.ToInt32(hfCusId.Value);
            DataSet ds = new DataSet();
            ds = ObjBLL.GetDealers(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                gvMember.DataSource = ds.Tables[1];
                gvMember.DataBind();
            }
            else
            {
                gvMember.AllowPaging = false;
                gvMember.DataSource = "";
                gvMember.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// get State Abbreviation
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
    /// Get State in the drop down list
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
    /// Check add in the particular controls
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
            if (ddlStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Status. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                ddlStatus.Focus();
                return false;
            }
            if (fpUploadW9Form.HasFile)
            {
                string File = System.IO.Path.GetExtension(fpUploadW9Form.FileName).ToLower();
                if (!Extensions.Contains(File))
                {
                    Utility.ShowMessage_Error(Page, "Only .pdf formats are allowed !");
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
    /// <summary>
    /// Cancel all entered values in the form controls
    /// </summary>
    // Reset all controls
    private void Reset()
    {
        try
        {
            Bind_Controls();
            ddlDealer.SelectedIndex = 0;
            txtCompanyName.Text = string.Empty;
            //ddlBusinessType.SelectedValue = "0";
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            txtTollFree.Text = string.Empty;
            txtTollFax.Text = string.Empty;
            txtFedral.Text = string.Empty;
            txtMainFax.Text = string.Empty;
            //txtMemo.Text = string.Empty;
            //txtRef.Text = string.Empty;
            ddlState.DataSource = "";
            ddlState.DataBind();
            ddlStateAb.DataSource = "";
            ddlStateAb.DataBind();
            txtMainPhone.Text = string.Empty;
            txtDiscount.Text = String.Empty;
            chkAgree.Checked = false;
            txtPrefrences.Text = String.Empty;
            if (ddlStatus.Items.Count > 0)
            {
                ddlStatus.SelectedValue = "1";
            }           
            txtTitle.Text = String.Empty;
            txtFName.Text = String.Empty;
            txtLName.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtCell.Text = String.Empty;
            txtExtension.Text = String.Empty;
            //ddlServiceRep.SelectedValue = "0";
            ddlRegion.SelectedIndex = 0;
            ddlFoodPre.SelectedIndex = 0;
            ddlRep.SelectedIndex = 0;
            ddlHeadOffice.SelectedIndex = 0;
            lblMsg.Text = "";
            btnSave.Text = "Save";
            DataTable dt = new DataTable();
            gvMember.DataSource = dt;
            gvMember.DataBind();
            lnkAttachment.Text = String.Empty;
            Hfw9formpath.Value = "-1";
            lnkLastUpdatedDate.Text = String.Empty;                 
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetHeadOffice()
    {
        try
        {
            chkHeadOffice.Enabled = true;
            chkHeadOffice.Checked = false;
            btnEditHeadOffice.Enabled = false;
            EnabledDisabledHeadOffice(chkHeadOffice.Checked);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Save Details entered by user
    /// after entering minimum validated fields
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
                if (ddlDealer.SelectedIndex > 0)
                {
                    ObjBOL.DealerID = Convert.ToInt32(ddlDealer.SelectedValue);
                }
                else
                {
                    ObjBOL.DealerID = 0;
                }
                ObjBOL.Operation = 3;
                ObjBOL.CompanyName = txtCompanyName.Text;
                ObjBOL.FederalID = txtFedral.Text;
                //ObjBOL.GroupName = ddlBusinessType.SelectedValue;
                ObjBOL.StreetAddress = txtAddress.Text;
                ObjBOL.City = txtCity.Text;
                if (ddlState.SelectedIndex > 0)
                {
                    ObjBOL.StateID = Convert.ToInt16(ddlState.SelectedValue);
                }
                if (ddlCountry.SelectedIndex > 0)
                {
                    ObjBOL.Country = ddlCountry.SelectedItem.Text;
                }                
                ObjBOL.ZipCode = txtZipCode.Text;
                ObjBOL.TollFree = txtTollFree.Text;
                ObjBOL.TollFax = txtTollFax.Text;
                ObjBOL.Phone = txtMainPhone.Text;
                ObjBOL.Fax = txtMainFax.Text;
                ObjBOL.RegionID = Convert.ToInt16(ddlRegion.SelectedValue);
                ObjBOL.TSM = Convert.ToString(ddlRep.SelectedValue);
                if (chkHeadOffice.Checked == true)
                {
                    //Case Head Office
                    ObjBOL.HeadOffice = "0";
                }
                else
                {
                    if (ddlHeadOffice.SelectedIndex > 0)
                    {
                        ObjBOL.HeadOffice = ddlHeadOffice.SelectedValue;
                    }                    
                }
                ObjBOL.FoodPref = Convert.ToInt32(ddlFoodPre.SelectedValue);
                if (ddlStatus.SelectedIndex > 0)
                {
                    ObjBOL.status = Convert.ToInt32(ddlStatus.SelectedValue);
                }
                if (chkAgree.Checked == true)
                {
                    ObjBOL.Agreement = true;
                }
                else
                {
                    ObjBOL.Agreement = false;
                }
                ObjBOL.AgreedDiscount = txtDiscount.Text;
                //ObjBOL.SerRep = Convert.ToInt16(ddlServiceRep.SelectedValue);
                ObjBOL.DealerPref = txtPrefrences.Text;
                //ObjBOL.Memo = txtMemo.Text;
                if (fpUploadW9Form.HasFile)
                {                                       
                    fpUploadW9Form.SaveAs(saveFolder + fpUploadW9Form.FileName);                    
                    ObjBOL.W9form = fpUploadW9Form.FileName.Trim();
                    ObjBOL.LastUpdatedDate = DateTime.Now;                
                }
                else
                {
                    if(lnkAttachment.Text != "")
                    {
                        DateTime parsedDate;
                        string strpath = lnkAttachment.Text.Trim() + ".pdf";                        
                        ObjBOL.W9form = strpath;
                        if(lnkLastUpdatedDate.Text != "")
                        {
                            if(DateTime.TryParse(lnkLastUpdatedDate.Text, out parsedDate))
                            {
                                ObjBOL.LastUpdatedDate = parsedDate;
                            }
                            
                        }
                       
                    }
                }                
                msg = ObjBLL.SaveDealers(ObjBOL);
                if (msg.Trim() != "")
                {
                    if (msg.Trim() == "ER01")
                    {
                        Utility.ShowMessage_Error(this, "Dealer with same company name and Address already exists !");
                        return;
                    }

                    if (msg.Trim() == "ER02")
                    {
                        Utility.ShowMessage_Error(this, "Dealer ID doesnot exists !");
                        return;
                    }
                    if (ddlDealer.SelectedIndex > 0)
                    {
                        hfCusId.Value = ddlDealer.SelectedValue;
                        Utility.ShowMessage_Success(this, "Record Updated Successfully !!");
                    }
                    else
                    {
                        hfCusId.Value = msg;
                        Utility.ShowMessage_Success(this, "Record Inserted Successfully !!");
                    }
                    Utility.MaintainLogsSpecial("FrmDealers.aspx", btnSave.Text, hfCusId.Value);
                    Reset();
                    ResetHeadOffice();
                    BindHeadOffice("");
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Cancel all the information in the form controls
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Cancel command
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Reset();
            ResetHeadOffice();
            hfCusId.Value = "-1";
            btnProposals.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Add validation for member
    /// </summary>
    /// <returns></returns>
    // Check if data filled in required fields of Member
    private Boolean ValidationCheckMember()
    {
        try
        {
            if (txtTitle.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Title. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Title. !");
                txtTitle.Focus();
                return false;
            }

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
    /// Add new member
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Add Member
    protected void btnAddMember_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlDealer.SelectedIndex>0)
            {
                if (ValidationCheckMember() == true)
                {
                    string msg = "";
                    ObjBOLMember.Operation = 4;
                    ObjBOLMember.DealerID = Convert.ToInt16(ddlDealer.SelectedValue);
                    ObjBOLMember.Title = txtTitle.Text;
                    ObjBOLMember.FName = txtFName.Text;
                    ObjBOLMember.LName = txtLName.Text;
                    ObjBOLMember.Phone = txtPhone.Text;
                    ObjBOLMember.Cell = txtCell.Text;
                    ObjBOLMember.email = txtEmail.Text;
                    ObjBOLMember.Extension = txtExtension.Text;
                    msg = ObjBLLMember.SaveDealerMember(ObjBOLMember);
                    if (msg.Trim() != "")
                    {
                        if (msg.Trim() == "ER01")
                        {
                            Utility.ShowMessage_Error(this, "Contact with the same name already exists for the dealer !");
                            return;
                        }
                        Utility.MaintainLogsSpecial("FrmDealers.aspx", "Save-Member", ddlDealer.SelectedValue);
                        Utility.ShowMessage_Success(this, msg);
                        Bind_Members();
                        Reset_Member();
                    }
                }
            }
            else
            {
                Utility.ShowMessage_Error(this, "Please Enter Dealer Detail First !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Clear member details enter by user
    /// </summary>
    // Clear member detail
    private void Reset_Member()
    {
        try
        {
            txtTitle.Text = string.Empty;
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtCell.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtExtension.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Delete row of member
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Menber Row Deleting
    protected void gvMember_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        try
        {
            int ContactID = Convert.ToInt32(gvMember.DataKeys[e.RowIndex].Values[0]);
            string msg = "";
            ObjBOLMember.Operation = 5;
            ObjBOLMember.ContactID = ContactID;
            ObjBOLMember.DealerID = Convert.ToInt16(hfCusId.Value);
            msg = ObjBLLMember.DeleteDealerMember(ObjBOLMember);
            if (msg.Trim() != "")
            {
                Utility.ShowMessage_Success(Page, "Member Deleted Successfully !!");
                Utility.MaintainLogsSpecial("FrmDealers.aspx", "Delete-Member", ddlDealer.SelectedValue);
                Bind_Members();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Edit member details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Menber Row Editing
    protected void gvMember_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            gvMember.EditIndex = e.NewEditIndex;
            Bind_Members();
            //DropDownList ddlTtileIn = gvMember.Rows[e.NewEditIndex].FindControl("ddlTitleIn") as DropDownList;
            //Label lblMem = gvMember.Rows[e.NewEditIndex].FindControl("lblTitleIn") as Label;
            //string name = lblMem.Text;
            //DataSet ds = new DataSet();
            //ObjBOL.Operation = 1;
            //ds = ObjBLL.GetDealers(ObjBOL);
            //if (ds.Tables[7].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlTtileIn, ds.Tables[7]);
            //    ddlTtileIn.SelectedValue = lblMem.Text;
            //}
            //ddlTtileIn.Focus();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Change previous data 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Menber Row Updating
    protected void gvMember_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = gvMember.Rows[e.RowIndex];
            ObjBOLMember.Operation = 6;
            ObjBOLMember.ContactID = Convert.ToInt32(gvMember.DataKeys[e.RowIndex].Values[0]);
            ObjBOLMember.Title = (row.FindControl("txtTitleIn") as TextBox).Text;
            ObjBOLMember.FName = (row.FindControl("txtFName") as TextBox).Text;
            ObjBOLMember.LName = (row.FindControl("txtLName") as TextBox).Text;
            ObjBOLMember.Phone = (row.FindControl("txtPhone") as TextBox).Text;
            ObjBOLMember.Cell = (row.FindControl("txtCell") as TextBox).Text;
            ObjBOLMember.Extension = (row.FindControl("txtExtension") as TextBox).Text;
            ObjBOLMember.email = (row.FindControl("txtEmail") as TextBox).Text;
            TextBox txtTitle1 = (row.FindControl("txtTitleIn") as TextBox);
            if (txtTitle1.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Title. !");
                txtTitle1.Focus();
                return;
            }
            TextBox txtFName1 = (row.FindControl("txtFName") as TextBox);
            if (txtFName1.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter First Name. !");
                txtFName1.Focus();
                return;
            }
            msg = ObjBLLMember.SaveDealerMember(ObjBOLMember);
            if (msg.Trim() != "")
            {
                if (msg.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(this, "Contact with the same name already exists for the dealer !");
                    return;
                }
                Utility.ShowMessage_Success(Page, "Member Updated Successfully !!");
                Utility.MaintainLogsSpecial("FrmDealers.aspx", "Update-Member", ddlDealer.SelectedValue);
                gvMember.EditIndex = -1;
                Bind_Members();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Set no. of records display on the grid view control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Menber Row Index Changing
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
    /// Cancel the control values
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Menber Row Row Cancel Edit
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
    /// Back to the proposal Page
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

    private void BindState(string country)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 9;
            ObjBOL.Country = country;
            ds = ObjBLL.GetDealersState(ObjBOL);
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
            BindState(ddlCountry.SelectedValue);
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
            if (ddlDealer.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                rprt.Load(Server.MapPath("~/Reports/rptProposalsUnderConsultant.rpt"));
                clscon.Return_DT(dt, "EXEC [dbo].[Get_JobsUnderConsultant]  3," + ddlDealer.SelectedValue + "");
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
            //if (ddlDealer.SelectedIndex > 0)
            //{
            //    DataTable dt = new DataTable();
            //    rprt.Load(Server.MapPath("~/Reports/rptJobsUnderConsultant.rpt"));
            //    clscon.Return_DT(dt, "EXEC [dbo].[Get_JobsUnderConsultant]  4," + ddlDealer.SelectedValue + "");
            //    rprt.SetDataSource(dt);
            //    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            //    rprt.Close();
            //    rprt.Dispose();
            //}
            Response.Redirect("~/Reports/frmDealerSales.aspx");
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
            string filePath =saveFolder + Hfw9formpath.Value + ".pdf";
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

    protected void chkHeadOffice_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            EnabledDisabledHeadOffice(chkHeadOffice.Checked);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void EnabledDisabledHeadOffice(bool headoffice)
    {
        try
        {
            if(headoffice == true)
            {
                ddlHeadOffice.Enabled = false;
                btnEditHeadOffice.Enabled = false;
                if (ddlHeadOffice.Items.Count > 0)
                {
                    ddlHeadOffice.SelectedIndex = 0;
                }
            }
            else
            {
                ddlHeadOffice.Enabled = true;
                if (ddlHeadOffice.SelectedIndex > 0)
                {
                    btnEditHeadOffice.Enabled = true;
                }                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindHeadOffice(string HeadOfficeID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetDealers(ObjBOL);
            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlHeadOffice, ds.Tables[6]);
                if(HeadOfficeID != "")
                {
                    ddlHeadOffice.SelectedValue = HeadOfficeID;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //#region Edit functionality Head Office

    private void BindHeadOffice_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetDealers(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlHeadOfficeCountry, ds.Tables[1]);
            }           
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlHeadOffRegion, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlHeadOfficeFoodPref, ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlHeadOffSalesRep, ds.Tables[5]);
            }           
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    protected void ddlHeadOfficeCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindHeadOfficeState(ddlHeadOfficeCountry.SelectedValue);
            ModalPopupExtenderShowParts.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindHeadOfficeState(string country)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 9;
            ObjBOL.Country = country;
            ds = ObjBLL.GetDealersState(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlHeadOffState, ds.Tables[0]);
            }
            else
            {
                ddlHeadOffState.DataSource = "";
                ddlHeadOffState.DataBind();
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlHeadOfficeStateAbb, ds.Tables[0]);
            }
            else
            {
                ddlHeadOfficeStateAbb.DataSource = "";
                ddlHeadOfficeStateAbb.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlHeadOffState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlHeadOffState.SelectedIndex > 0)
            {
                ddlHeadOfficeStateAbb.SelectedValue = ddlHeadOffState.SelectedValue;               
            }
            ModalPopupExtenderShowParts.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Get State in the drop down list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Set Abbrevation value on State
    protected void ddlHeadOfficeStateAbb_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlHeadOfficeStateAbb.SelectedIndex > 0)
            {
                ddlHeadOffState.SelectedValue = ddlHeadOfficeStateAbb.SelectedValue;
            }
            ModalPopupExtenderShowParts.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnEditHeadOffice_Click(object sender, EventArgs e)
    {
        try
        {
            ModalPopupExtenderShowParts.Show();
            BindHeadOffice_Controls();
            btnEditHeadOffice.Enabled = true;
            FillHeadOfficeDealerDetail();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Boolean ValidationCheckHeadOffice()
    {
        try
        {
            if (txtHeadOfficeCompany.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Company Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Company Name. !");
                txtHeadOfficeCompany.Focus();
                ModalPopupExtenderShowParts.Show();
                return false;
            }
            if (ddlHeadOfficeStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Status. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                ddlHeadOfficeStatus.Focus();
                ModalPopupExtenderShowParts.Show();
                return false;
            }
            if (fpHeadOfficeW9.HasFile)
            {
                string File = System.IO.Path.GetExtension(fpHeadOfficeW9.FileName).ToLower();
                if (!Extensions.Contains(File))
                {
                    Utility.ShowMessage_Error(Page, "Only .pdf formats are allowed !");
                    ModalPopupExtenderShowParts.Show();
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

    protected void btnHeadOfficeUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlHeadOffice.SelectedIndex > 0)
            {
                if (ValidationCheckHeadOffice() == true)
                {
                    string message = "";
                    ObjBOL.Operation = 3;
                    ObjBOL.CompanyName = txtHeadOfficeCompany.Text;
                    ObjBOL.DealerID = Convert.ToInt32(ddlHeadOffice.SelectedValue);
                    ObjBOL.FederalID = txtHeadOfficeFedID.Text;
                    ObjBOL.StreetAddress = txtHeadOffAddress.Text;
                    ObjBOL.City = txtHeadOffCity.Text;
                    if (ddlHeadOffState.SelectedIndex > 0)
                    {
                        ObjBOL.StateID = Convert.ToInt16(ddlHeadOffState.SelectedValue);
                    }
                    if (ddlHeadOfficeCountry.SelectedIndex > 0)
                    {
                        ObjBOL.Country = ddlHeadOfficeCountry.SelectedItem.Text;
                    }                    
                    ObjBOL.ZipCode = txtHeadOffZipCode.Text;
                    ObjBOL.TollFree = txtHeadOffTollFree.Text;
                    ObjBOL.TollFax = txtHeadOfficeTollFax.Text;
                    ObjBOL.Phone = txtHeadOffPhone.Text;
                    ObjBOL.Fax = txtHeadOfficeFax.Text;
                    ObjBOL.RegionID = Convert.ToInt16(ddlHeadOffRegion.SelectedValue);
                    ObjBOL.TSM = Convert.ToString(ddlHeadOffSalesRep.SelectedValue);
                    ObjBOL.FoodPref = Convert.ToInt32(ddlHeadOfficeFoodPref.SelectedValue);
                    ObjBOL.HeadOffice = "0";
                    if (ddlHeadOfficeStatus.SelectedIndex > 0)
                    {
                        ObjBOL.status = Convert.ToInt32(ddlHeadOfficeStatus.SelectedValue);
                    }
                    if (chkHeadOffAgreement.Checked == true)
                    {
                        ObjBOL.Agreement = true;
                    }
                    else
                    {
                        ObjBOL.Agreement = false;
                    }
                    ObjBOL.AgreedDiscount = txtHeadOffAgreedDiscount.Text;
                    ObjBOL.DealerPref = txtHeadOfficePref.Text;
                    if (fpHeadOfficeW9.HasFile)
                    {
                        fpHeadOfficeW9.SaveAs(saveFolder + fpHeadOfficeW9.FileName);
                        ObjBOL.W9form = fpHeadOfficeW9.FileName.Trim();
                        ObjBOL.LastUpdatedDate = DateTime.Now;
                    }
                    else
                    {
                        if (lnkHeadOfficeW9.Text != "")
                        {
                            DateTime parsedDate;
                            string strpath = lnkHeadOfficeW9.Text.Trim() + ".pdf";
                            ObjBOL.W9form = strpath;
                            if (lblHeadOfficeUpdatedDatetime.Text != "")
                            {
                                if (DateTime.TryParse(lblHeadOfficeUpdatedDatetime.Text, out parsedDate))
                                {
                                    ObjBOL.LastUpdatedDate = parsedDate;
                                }

                            }

                        }
                    }
                    message = ObjBLL.SaveDealers(ObjBOL);
                    if (message.Trim() != "")
                    {
                        if (message.Trim() == "ER01")
                        {
                            Utility.ShowMessage_Error(this, "Head Office with same name already exists !");
                            ModalPopupExtenderShowParts.Show();
                            return;
                        }

                        if (message.Trim() == "ER02")
                        {
                            Utility.ShowMessage_Error(this, "Head Office ID doesnot exists !");
                            ModalPopupExtenderShowParts.Show();
                            return;
                        }
                        hfCusId.Value = ddlDealer.SelectedValue;
                        Utility.ShowMessage_Success(this, "Record Updated Successfully !!");
                        Utility.MaintainLogsSpecial("FrmDealers.aspx", "Update-HO", ddlHeadOffice.SelectedValue);
                        BindHeadOffice(ddlHeadOffice.SelectedValue);
                    }
                    FillHeadOfficeDealerDetail();
                    ModalPopupExtenderShowParts.Show();
                }
                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void lnkHeadOfficeW9_Click(object sender, EventArgs e)
    {
        try
        {
            string filePath = saveFolder + HfHeadOffW9path.Value + ".pdf";
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                ModalPopupExtenderShowParts.Hide();
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
                ModalPopupExtenderShowParts.Show();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillHeadOfficeDealerDetail()
    {
        try
        {
            if (ddlHeadOffice.SelectedIndex > 0)
            {                
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.DealerID = Convert.ToInt32(ddlHeadOffice.SelectedValue);
                ds = ObjBLL.GetDealers(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
                {
                    { "CompanyName", d => txtHeadOfficeCompany.Text = Convert.ToString(d["CompanyName"]) },
                    { "FederalID", d => txtHeadOfficeFedID.Text = Convert.ToString(d["FederalID"]) },
                    { "StreetAddress", d => txtHeadOffAddress.Text = Convert.ToString(d["StreetAddress"]) },
                    { "City", d => txtHeadOffCity.Text = Convert.ToString(d["City"]) },
                    { "CountryState", d =>
                        {
                            if(ddlHeadOfficeCountry.Items.FindByValue(Convert.ToString(d["DealerCountryID"])) != null)
                            {
                                ddlHeadOfficeCountry.SelectedValue = Convert.ToString(d["DealerCountryID"]);
                                BindHeadOfficeState(d["DealerCountryID"].ToString());
                                if(ddlHeadOffState.Items.FindByValue(Convert.ToString(d["StateID"])) != null)
                                {
                                    ddlHeadOffState.SelectedValue = Convert.ToString(d["StateID"]);
                                    ddlHeadOfficeStateAbb.SelectedValue = ddlHeadOffState.SelectedValue;
                                }
                            }
                        }
                    },
                    { "ZipCode", d => txtHeadOffZipCode.Text = Convert.ToString(d["ZipCode"]) },
                    { "RegionID", d =>
                        {
                            if(ddlHeadOffRegion.Items.FindByValue(Convert.ToString(d["RegionID"])) != null)
                            {
                                ddlHeadOffRegion.SelectedValue = Convert.ToString(d["RegionID"]);
                            }
                        }
                    },
                    { "Phone", d => txtHeadOffPhone.Text = Convert.ToString(d["Phone"]) },
                    { "TollFree", d => txtHeadOffTollFree.Text = Convert.ToString(d["TollFree"]) },
                    { "Fax", d => txtHeadOfficeFax.Text = Convert.ToString(d["Fax"]) },
                    { "TollFax", d => txtHeadOfficeTollFax.Text = Convert.ToString(d["TollFax"]) },
                    { "Agreement", d =>
                        {
                            if (Convert.ToBoolean(d["Agreement"]) == true)
                            {
                                chkHeadOffAgreement.Checked = true;
                            }
                            else
                            {
                                chkHeadOffAgreement.Checked = false;
                            }
                        }
                    },
                    { "FoodPref", d =>
                        {
                            if(ddlHeadOfficeFoodPref.Items.FindByValue(d["FoodPref"].ToString()) != null)
                            {
                                ddlHeadOfficeFoodPref.SelectedValue = d["FoodPref"].ToString();
                            }
                        }
                    },
                    { "AgreedDiscount",
                            d => {
                                if(Convert.ToString(d["AgreedDiscount"]) != "")
                                {
                                    decimal decimalValue;
                                    if (decimal.TryParse(Convert.ToString(d["AgreedDiscount"]), NumberStyles.Float, CultureInfo.InvariantCulture, out decimalValue))
                                    {                                        
                                        txtHeadOffAgreedDiscount.Text = decimalValue.ToString();
                                    }
                                 
                                }
                                
                            }
                       },
                    { "TSM", d =>
                        {
                            if(ddlHeadOffSalesRep.Items.FindByValue(Convert.ToString(d["TSM"])) != null)
                            {
                                ddlHeadOffSalesRep.SelectedValue = Convert.ToString(d["TSM"]);
                            }
                        }
                    },                    
                    { "DealerPref", d => txtHeadOfficePref.Text = Convert.ToString(d["DealerPref"]) },
                    { "Dealerstatus", d =>
                        {
                            if(ddlHeadOfficeStatus.Items.FindByValue(d["Dealerstatus"].ToString()) != null)
                            {
                                ddlHeadOfficeStatus.SelectedValue = d["Dealerstatus"].ToString();

                            }
                        }
                    },
                    {
                       "W9form", d =>
                       {
                           if(Convert.ToString(d["W9form"]) != null)
                           {
                               FileInfo file = new FileInfo(saveFolder + Convert.ToString(d["W9form"]));
                               if (file.Exists)
                                {
                                    string path = Convert.ToString(d["W9form"]);
                                    string pathLower= path.ToLower();
                                    HfHeadOffW9path.Value = pathLower.Replace(".pdf","");
                                    //string[] emailname = emailpath.Split(new char[] { '/' });
                                    lnkHeadOfficeW9.Visible = true;
                                    lnkHeadOfficeW9.Text = HfHeadOffW9path.Value;
                                }
                                else
                                {
                                    lnkHeadOfficeW9.Visible = false;
                                    lnkHeadOfficeW9.Text = String.Empty;
                                }
                           }
                       }
                    },
                    {
                            "LastUpdatedDate", d=>
                            {
                                if(Convert.ToString(d["LastUpdatedDate"]) != null)
                                {
                                    dvHeadOfficeUpdatedDatetime.Visible=true;
                                    lblHeadOfficeUpdatedDatetime.Text=Convert.ToString(d["LastUpdatedDate"]);
                                }
                                else
                                {
                                    lblHeadOfficeUpdatedDatetime.Text=String.Empty;
                                    dvHeadOfficeUpdatedDatetime.Visible=false;
                                }
                            }

                    }
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
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    gvDealerHOMember.DataSource = ds.Tables[1];
                    gvDealerHOMember.DataBind();
                }
                else
                {
                    ResetHeadOfficeGrid();
                }
            }
            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetHeadOfficeGrid()
    {
        try
        {
            gvDealerHOMember.AllowPaging = false;
            gvDealerHOMember.DataSource = "";
            gvDealerHOMember.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnHeadOfficeCancel_Click(object sender, EventArgs e)
    {
        try
        {
            txtHeadOfficeFedID.Text = String.Empty;
            txtHeadOffAddress.Text = String.Empty;
            if (ddlHeadOffRegion.Items.Count > 0)
            {
                ddlHeadOffRegion.SelectedIndex = 0;
            }            
            if (ddlHeadOfficeCountry.Items.Count > 0)
            {
                ddlHeadOfficeCountry.SelectedIndex = 0;
            }            
            if (ddlHeadOffState.Items.Count > 0)
            {
                ddlHeadOffState.Items.Clear();
                ddlHeadOfficeStateAbb.Items.Clear();
            }
            txtHeadOffCity.Text = String.Empty;
            txtHeadOffZipCode.Text = String.Empty;
            txtHeadOffPhone.Text = String.Empty;
            txtHeadOffTollFree.Text = String.Empty;
            txtHeadOfficeTollFax.Text = String.Empty;
            txtHeadOfficeFax.Text = String.Empty;
            if (ddlHeadOfficeFoodPref.Items.Count > 0)
            {
                ddlHeadOfficeFoodPref.SelectedIndex = 0;
            }            
            txtHeadOffAgreedDiscount.Text = String.Empty;
            if (ddlHeadOffSalesRep.Items.Count > 0)
            {
                ddlHeadOffSalesRep.SelectedIndex = 0;
            }           
            chkHeadOffAgreement.Checked = false;
            txtHeadOfficePref.Text = String.Empty;
            if (ddlHeadOfficeStatus.Items.Count > 0)
            {
                ddlHeadOfficeStatus.SelectedValue = "1";
            }
            lnkHeadOfficeW9.Text = String.Empty;
            lblHeadOfficeUpdatedDatetime.Text = String.Empty;
            ModalPopupExtenderShowParts.Show();
            Reset_DealerHOMember();
            ResetHeadOfficeGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    //#endregion

    protected void ddlHeadOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlHeadOffice.SelectedIndex > 0)
            {
                btnEditHeadOffice.Enabled = true;
            }
            else
            {
                btnEditHeadOffice.Enabled = false;
                if (ddlHeadOffice.Items.Count > 0)
                {
                    ddlHeadOffice.SelectedIndex = 0;
                }                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "Exec [dbo].[Get_Dealers]");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnExportData_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtHeadOffice = ReportData();           
            rprt.Load(Server.MapPath("~/Reports/rptDealersReport.rpt"));
            if (dtHeadOffice.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "Dealer Detail Report ";
                rprt.SetDataSource(dtHeadOffice);
                //rprt.Subreports[0].SetDataSource(dtHeadOffice);
                //rptDealersReport.ReportSource = rprt;
                //rptDealersReport.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
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




    //GVHeadOfficeMember
    protected void gvDealerHOMember_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        try
        {
            int ContactID = Convert.ToInt32(gvDealerHOMember.DataKeys[e.RowIndex].Values[0]);
            string msg = "";
            ObjBOLMember.Operation = 5;
            ObjBOLMember.ContactID = ContactID;
            ObjBOLMember.DealerID = Convert.ToInt16(ddlHeadOffice.SelectedValue);
            msg = ObjBLLMember.DeleteDealerMember(ObjBOLMember);
            if (msg.Trim() != "")
            {
                Utility.ShowMessage_Success(Page, "Member Deleted Successfully !!");
                Utility.MaintainLogsSpecial("FrmDealers.aspx", "Delete-HO-Member", ddlHeadOffice.SelectedValue);
                Bind_DealerHOMembers();
            }
            ModalPopupExtenderShowParts.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Edit member details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Menber Row Editing
    protected void gvDealerHOMember_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            gvDealerHOMember.EditIndex = e.NewEditIndex;
            Bind_DealerHOMembers();
            ModalPopupExtenderShowParts.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Change previous data 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Menber Row Updating
    protected void gvDealerHOMember_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = gvDealerHOMember.Rows[e.RowIndex];
            ObjBOLMember.Operation = 6;
            ObjBOLMember.ContactID = Convert.ToInt32(gvDealerHOMember.DataKeys[e.RowIndex].Values[0]);
            ObjBOLMember.Title = (row.FindControl("txtHOTitleIn") as TextBox).Text;
            ObjBOLMember.FName = (row.FindControl("txtHOFName") as TextBox).Text;
            ObjBOLMember.LName = (row.FindControl("txtHOLName") as TextBox).Text;
            ObjBOLMember.Phone = (row.FindControl("txtHOPhone") as TextBox).Text;
            ObjBOLMember.Cell = (row.FindControl("txtHOCell") as TextBox).Text;
            ObjBOLMember.Extension = (row.FindControl("txtHOExtension") as TextBox).Text;
            ObjBOLMember.email = (row.FindControl("txtHOEmail") as TextBox).Text;
            TextBox txtTitle1 = (row.FindControl("txtHOTitleIn") as TextBox);
            if (txtTitle1.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Title. !");
                txtTitle1.Focus();
                ModalPopupExtenderShowParts.Show();
                return;
            }
            TextBox txtFName1 = (row.FindControl("txtHOFName") as TextBox);
            if (txtFName1.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter First Name. !");
                txtFName1.Focus();
                ModalPopupExtenderShowParts.Show();
                return;
            }
            msg = ObjBLLMember.SaveDealerMember(ObjBOLMember);
            if (msg.Trim() != "")
            {
                if (msg.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(this, "Contact with the same name already exists for the dealer !");
                    return;
                }
                Utility.ShowMessage_Success(Page, "Member Updated Successfully !!");
                Utility.MaintainLogsSpecial("FrmDealers.aspx", "Update-HO-Member", ddlHeadOffice.SelectedValue);
                gvDealerHOMember.EditIndex = -1;
                Bind_DealerHOMembers();
            }
            ModalPopupExtenderShowParts.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Set no. of records display on the grid view control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Menber Row Index Changing
    protected void gvDealerHOMember_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        try
        {
            gvDealerHOMember.PageIndex = e.NewPageIndex;
            Bind_DealerHOMembers();
            ModalPopupExtenderShowParts.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Cancel the control values
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Menber Row Row Cancel Edit
    protected void gvDealerHOMember_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvDealerHOMember.EditIndex = -1;
            Bind_DealerHOMembers();
            ModalPopupExtenderShowParts.Show();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void Bind_DealerHOMembers()
    {
        try
        {
            ObjBOL.Operation = 2;
            ObjBOL.DealerID = Convert.ToInt32(ddlHeadOffice.SelectedValue);
            DataSet ds = new DataSet();
            ds = ObjBLL.GetDealers(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                gvDealerHOMember.DataSource = ds.Tables[1];
                gvDealerHOMember.DataBind();
            }
            else
            {
                ResetHeadOfficeGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private Boolean ValidationCheckHOMember()
    {
        try
        {
            if (txtHeadOfficeTitle.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Title. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Title. !");
                txtHeadOfficeTitle.Focus();
                ModalPopupExtenderShowParts.Show();
                return false;
            }

            if (txtHeadOfficeFName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter First Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter First Name. !");
                txtHeadOfficeFName.Focus();
                ModalPopupExtenderShowParts.Show();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void Reset_DealerHOMember()
    {
        try
        {
            txtHeadOfficeTitle.Text = string.Empty;
            txtHeadOfficeFName.Text = string.Empty;
            txtHeadOfficeLName.Text = string.Empty;
            txtHeadOfficePhone.Text = string.Empty;
            txtHeadOfficeCell.Text = string.Empty;
            txtHeadOfficeEmail.Text = string.Empty;
            txtHeadOfficeExtension.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnHOAddMember_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlHeadOffice.SelectedIndex > 0)
            {
                if (ValidationCheckHOMember() == true)
                {
                    string msg = "";
                    ObjBOLMember.Operation = 4;
                    ObjBOLMember.DealerID = Convert.ToInt16(ddlHeadOffice.SelectedValue);
                    ObjBOLMember.Title = txtHeadOfficeTitle.Text;
                    ObjBOLMember.FName = txtHeadOfficeFName.Text;
                    ObjBOLMember.LName = txtHeadOfficeLName.Text;
                    ObjBOLMember.Phone = txtHeadOfficePhone.Text;
                    ObjBOLMember.Cell = txtHeadOfficeCell.Text;
                    ObjBOLMember.email = txtHeadOfficeEmail.Text;
                    ObjBOLMember.Extension = txtHeadOfficeExtension.Text;
                    msg = ObjBLLMember.SaveDealerMember(ObjBOLMember);
                    if (msg.Trim() != "")
                    {
                        if (msg.Trim() == "ER01")
                        {
                            Utility.ShowMessage_Error(this, "Contact with the same name already exists for the dealer !");
                            return;
                        }
                        Utility.MaintainLogsSpecial("FrmDealers.aspx", "Save-HO-Member", ddlHeadOffice.SelectedValue);
                        Utility.ShowMessage_Success(this, msg);
                        Bind_DealerHOMembers();
                        Reset_DealerHOMember();
                    }
                }
                ModalPopupExtenderShowParts.Show();
            }
            else
            {
                Utility.ShowMessage_Error(this, "Please Enter Dealer Head Office Detail First !!");
                ModalPopupExtenderShowParts.Show();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}