using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
/// <summary>
///  Proposal Form (30 May 2018) Rohit Kumar
/// </summary>
public partial class ContactManagement_FrmCustomers : System.Web.UI.Page
{
    BOLManageCustomers ObjBOL = new BOLManageCustomers();
    BLLManageCustomers ObjBLL = new BLLManageCustomers();

    BOLManageCustomerMember ObjBOLMember = new BOLManageCustomerMember();
    BLLManageCustomerMember ObjBLLMember = new BLLManageCustomerMember();
    // Page load event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Controls();
                if (Session["CustomerID"] != null)
                {
                    var CustomerID = Session["CustomerID"].ToString();
                    if (Session["JobID"] != null)
                    {
                        hfJobDetails.Value = Session["JobID"].ToString();
                    }
                    else
                    {
                        hfJobDetails.Value = null;
                    }
                    HfCustomerID.Value = CustomerID;
                    GetCustomerName();
                    if(HfCustomerID.Value != "-1")
                    {
                        CustomersDetail(HfCustomerID.Value);
                    }                    
                    btnBack.Enabled = true;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetCustomerName()
    {
        try
        {
            ObjBOL.Operation = 11;
            if(HfCustomerID.Value != "-1")
            {
                ObjBOL.CustomerID = Int32.Parse(HfCustomerID.Value);
                DataSet ds = new DataSet();
                ds = ObjBLL.GetCustomers(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCustomer.Text = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                }
                else
                {
                    HfCustomerID.Value = "-1";
                }
            }
            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Drop down bind in the form
    /// </summary>
    // Bind all dropdownlist here
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetCustomers(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCountry, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlSales, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlBusinessType, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlServiceRep, ds.Tables[4]);
            }
            //if (ds.Tables[5].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlTitle, ds.Tables[5]);
            //}
            //if (ds.Tables[6].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlCustomer, ds.Tables[6]);
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Not Used
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // Get P# from Project Name
    //protected void txtPName_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (txtCompanyName.Text != "")
    //        {
    //            string output = txtPName.Text;
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
    /// After change the value on ddlcustomer
    /// form filled below
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // On Customer Selection
    protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CheckForValidCustomer();
            if (txtCustomer.Text != "")
            {
                CustomersDetail("detail");
                btnBack.Enabled = true;
            }
            else
            {
                btnBack.Enabled = false;
                Reset();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckForValidCustomer()
    {
        try
        {
            ObjBOL.Operation = 10;
            ObjBOL.CompanyName = txtCustomer.Text;
            DataSet ds = new DataSet();
            ds = ObjBLL.ReturnCustomers(ObjBOL);
            if (ds.Tables[0].Rows.Count == 0)
            {
                txtCustomer.Text = string.Empty;
                HfCustomerID.Value = "-1";
            }
            else
            {
                HfCustomerID.Value = ds.Tables[0].Rows[0]["CustomerID"].ToString();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Fill the details in the form
    /// </summary>
    /// <param name="detail"></param>
    private void CustomersDetail(string detail)
    {
        try
        {
            if (HfCustomerID.Value != "-1")
            {
                btnSave.Text = "Update";
                if (HfCustomerID.Value != "-1")
                {
                    hfCusId.Value = HfCustomerID.Value;
                }                    
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.CustomerID = Convert.ToInt32(HfCustomerID.Value);
                ds = ObjBLL.GetCustomers(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
                {
                    { "CompanyName", d => txtCompanyName.Text = Convert.ToString(d["CompanyName"]) },
                    { "BusinessType", d =>
                        {
                            if (ddlBusinessType.Items.FindByValue(Convert.ToString(d["BusinessType"])) != null)
                            {
                                ddlBusinessType.SelectedValue = Convert.ToString(d["BusinessType"]);
                            }
                        }
                    },
                    { "StreetAddress", d => txtAddress.Text = Convert.ToString(d["StreetAddress"]) },
                    { "City", d => txtCity.Text = Convert.ToString(d["City"]) },
                    { "ZipCode", d => txtZipCode.Text = Convert.ToString(d["ZipCode"]) },
                    { "MainPhone", d => txtMainPhone.Text = Convert.ToString(d["MainPhone"]) },
                    { "Memo", d => txtMemo.Text = Convert.ToString(d["Memo"]) },
                    { "SiteAddress", d => txtSiteAddress.Text = Convert.ToString(d["SiteAddress"]) },
                    { "CountryID", d =>
                        {
                            if (ddlCountry.Items.FindByValue(Convert.ToString(d["CountryID"])) != null)
                            {
                                ddlCountry.SelectedValue = Convert.ToString(d["CountryID"]);
                                BindState(Convert.ToInt16(ddlCountry.SelectedValue));
                                if (ddlState.Items.FindByValue(Convert.ToString(d["StateID"])) != null)
                                {
                                    ddlState.SelectedValue = Convert.ToString(d["StateID"]);
                                    ddlStateAb.SelectedValue = Convert.ToString(d["StateID"]);
                                }
                            }
                        }
                    },
                    { "TSM", d =>
                        {
                            if (ddlSales.Items.FindByValue(Convert.ToString(d["TSM"])) != null)
                            {
                                ddlSales.SelectedValue = Convert.ToString(d["TSM"]);
                            }
                        }
                    },
                    { "SerRep", d =>
                        {
                            if (ddlServiceRep.Items.FindByValue(Convert.ToString(d["SerRep"])) != null)
                            {
                                ddlServiceRep.SelectedValue = Convert.ToString(d["SerRep"]);
                            }
                        }
                    },
                    { "JobID", d => hfJobDetails.Value = Convert.ToString(d["JobID"]) }
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

                    lblMsg.Text = "";
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
    /// Bind values in Grid View Control
    /// Values based on ddlcustomer 
    /// </summary>
    //Bind Members on Customer name change event
    private void Bind_Members()
    {
        try
        {
            ObjBOL.Operation = 2;
            ObjBOL.CustomerID = Convert.ToInt32(hfCusId.Value);
            DataSet ds = new DataSet();
            ds = ObjBLL.GetCustomers(ObjBOL);
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            gvMember.DataSource = ds.Tables[1];
            gvMember.DataBind();
            // }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strPNumber"></param>
    // Fill all details 
    private void FillDetailsFromPnumber(string strPNumber)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ds = ObjBLL.GetCustomers(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //txtProNO.Text = Convert.ToString(ds.Tables[0].Rows[0]["PNumber"]);
                //txtProDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["ProposalDate"]));
                //txtJobID.Text = Convert.ToString(ds.Tables[0].Rows[0]["JobID"]);
                //txtProjectName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProjectName"]);
                txtCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]);
                if (ddlState.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["StateID"])) != null)
                {
                    ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["StateID"]);
                }

                if (ddlStateAb.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["StateID"])) != null)
                {
                    ddlStateAb.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["StateID"]);
                }

                if (ddlCountry.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["Country"])) != null)
                {
                    ddlCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Country"]);
                }
                lblMsg.Text = "";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

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

    // check if data filled in required fields
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtCompanyName.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Company Name. !");
                txtCompanyName.Focus();
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
    /// Cancel all controls
    /// </summary>
    // Reset all controls
    private void Reset()
    {
        try
        {
            Bind_Controls();
            DataTable dt = new DataTable();
            gvMember.DataSource = dt;
            gvMember.DataBind();
            btnSave.Text = "Save";
            txtCustomer.Text = string.Empty;
            HfCustomerID.Value = "-1";
            hfJobDetails.Value = "-1";
            txtCompanyName.Text = string.Empty;
            ddlBusinessType.SelectedIndex = 0;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            //txtTollFree.Text = string.Empty;
            //txtTollFax.Text = string.Empty;
            //txtMainFax.Text = string.Empty;
            //txtRef.Text = string.Empty;
            txtMainPhone.Text = string.Empty;
            txtMemo.Text = string.Empty;
            ddlState.DataSource = "";
            ddlState.DataBind();
            ddlStateAb.DataSource = "";
            ddlStateAb.DataBind();
            ddlCountry.SelectedIndex = 0;
            ddlSales.SelectedIndex = 0;
            ddlServiceRep.SelectedIndex = 0;
            txtTitle.Text = string.Empty;
            txtFName.Text = String.Empty;
            txtLName.Text = String.Empty;
            txtPhone.Text = String.Empty;
            //txtFax.Text = String.Empty;    
            txtOfficePhone.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtSiteAddress.Text = String.Empty;
            chkRef.Checked = false;
            chkMain.Checked = false;
            lblMsg.Text = "";
            Session["CustomerID"] = null;
            Session["JobID"] = null;
            btnBack.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Save data after entering in mandatory fields
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
                string msg = string.Empty;
                string show = string.Empty;
                if (HfCustomerID.Value != "-1")
                {
                    ObjBOL.CustomerID = Convert.ToInt32(HfCustomerID.Value);
                    show = "Customer Updated Successfully !!";
                }
                else
                {
                    ObjBOL.CustomerID = 0;
                    show = "Customer Saved Successfully !!";
                }
                ObjBOL.Operation = 3;
                ObjBOL.CompanyName = txtCompanyName.Text;
                ObjBOL.BusinessType = ddlBusinessType.SelectedValue;
                ObjBOL.StreetAddress = txtAddress.Text;
                ObjBOL.City = txtCity.Text;
                if (ddlState.Items.Count > 0)
                {
                    ObjBOL.StateID = Convert.ToInt16(ddlState.SelectedValue);
                }
                ObjBOL.ZipCode = txtZipCode.Text;
                ObjBOL.CountryID = Convert.ToInt16(ddlCountry.SelectedValue);
                //ObjBOL.TollFree = txtTollFree.Text;
                //ObjBOL.TollFax = txtTollFax.Text;
                //ObjBOL.MainFax = txtMainFax.Text;
                //ObjBOL.References = txtRef.Text;
                ObjBOL.MainPhone = txtMainPhone.Text;
                ObjBOL.TSM = Convert.ToInt16(ddlSales.SelectedValue);
                ObjBOL.SerRep = Convert.ToInt16(ddlServiceRep.SelectedValue);
                ObjBOL.Memo = txtMemo.Text;
                ObjBOL.SiteAddress = txtSiteAddress.Text;
                msg = ObjBLL.SaveCustomers(ObjBOL);
                if (msg.Trim() != "")
                {
                    if (msg.Trim() == "ER01")
                    {
                        Utility.ShowMessage_Error(this, "Customer with same company name and Site Address already exists !");
                        return;
                    }

                    if (msg.Trim() == "ER02")
                    {
                        Utility.ShowMessage_Error(this, "Customer ID doesnot exists !");
                        return;
                    }

                    if (HfCustomerID.Value != "-1")
                    {
                        hfCusId.Value = HfCustomerID.Value;
                    }
                    else
                    {
                        hfCusId.Value = msg;
                    }
                    Utility.ShowMessage_Success(this, show);
                    Utility.MaintainLogsSpecial("FrmCustomers.aspx", btnSave.Text, hfCusId.Value);
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
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// check mandetory fields
    /// </summary>
    /// <returns></returns>
    // check if data filled in required fields of Member
    private Boolean ValidationCheckMember()
    {
        try
        {
            if (txtCompanyName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Title. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Customer Detail First !");
                txtCompanyName.Focus();
                return false;
            }
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
                    if(HfCustomerID.Value != "-1")
                    {
                        ObjBOLMember.CustomerID = Convert.ToInt16(HfCustomerID.Value);
                        ObjBOLMember.Title = txtTitle.Text;
                        ObjBOLMember.FName = txtFName.Text;
                        ObjBOLMember.LName = txtLName.Text;
                        ObjBOLMember.Phone = txtPhone.Text;
                        ObjBOLMember.OfficePhone = txtOfficePhone.Text;
                        ObjBOLMember.email = txtEmail.Text;
                        if (chkRef.Checked)
                        {
                            ObjBOLMember.ReferenceContact = true;
                        }
                        else
                        {
                            ObjBOLMember.ReferenceContact = false;
                        }
                        if (chkMain.Checked)
                        {
                            ObjBOLMember.MainContact = true;
                        }
                        else
                        {
                            ObjBOLMember.MainContact = false;
                        }
                        msg = ObjBLLMember.SaveCustomerMember(ObjBOLMember);
                        if (msg.Trim() != "")
                        {
                            if (msg.Trim() == "ER01")
                            {
                                Utility.ShowMessage_Error(this, "Contact with the same name already exists for the customer !");
                                return;
                            }
                            Utility.MaintainLogsSpecial("FrmCustomers.aspx", "Add-Contact", HfCustomerID.Value);
                            Utility.ShowMessage_Success(this, msg);
                            Bind_Members();
                            Reset_Member();
                        }
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
    /// Clear Controls
    /// </summary>
    // clear member detail
    private void Reset_Member()
    {
        try
        {
            txtTitle.Text = string.Empty;
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            //txtFax.Text = string.Empty;
            txtOfficePhone.Text = String.Empty;
            txtEmail.Text = string.Empty;
            chkRef.Checked = false;
            chkMain.Checked = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Delete single row
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMember_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        try
        {
            int ContactID = Convert.ToInt32(gvMember.DataKeys[e.RowIndex].Values[0]);
            string msg = "";
            ObjBOLMember.Operation = 5;
            ObjBOLMember.ContactID = ContactID;
            ObjBOLMember.CustomerID = Convert.ToInt16(hfCusId.Value);
            msg = ObjBLLMember.DeleteCustomerMember(ObjBOLMember);
            if (msg.Trim() != "")
            {
                if (msg.Trim() == "1")
                {
                    Utility.ShowMessage_Error(Page, "Contact cannot be deleted with existing call logs");
                }
                else
                {
                    Utility.ShowMessage_Success(Page, "Member Deleted Successfully !!");
                    Utility.MaintainLogsSpecial("FrmCustomers.aspx", "Delete-Contact", hfCusId.Value);
                }
            }
            Bind_Members();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    /// <summary>
    /// Edit records in grid view control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            //ds = ObjBLL.GetCustomers(ObjBOL);
            //if (ds.Tables[5].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlTtileIn, ds.Tables[5]);
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
    /// Update data in Grid View controls
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMember_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            GridViewRow row = gvMember.Rows[e.RowIndex];
            ObjBOLMember.Operation = 6;
            ObjBOLMember.ContactID = Convert.ToInt32(gvMember.DataKeys[e.RowIndex].Values[0]);
            TextBox txtTitle = (row.FindControl("txtTitleIn") as TextBox);
            ObjBOLMember.Title = txtTitle.Text;
            if (txtTitle.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Title. !");
                txtTitle.Focus();
                return;
            }
            TextBox txtFName = (row.FindControl("txtFName") as TextBox);
            if (txtFName.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter First Name. !");
                txtFName.Focus();
                return;
            }
            ObjBOLMember.FName = txtFName.Text;
            ObjBOLMember.LName = (row.FindControl("txtLName") as TextBox).Text;
            ObjBOLMember.Phone = (row.FindControl("txtPhone") as TextBox).Text;
            ObjBOLMember.OfficePhone = (row.FindControl("txtOfficePhone") as TextBox).Text;
            ObjBOLMember.email = (row.FindControl("txtEmail") as TextBox).Text;
            CheckBox chkRefIn = (CheckBox)row.FindControl("chkRef");
            CheckBox chkMainIn = (CheckBox)row.FindControl("chkMain");
            if (chkRefIn.Checked)
            {
                ObjBOLMember.ReferenceContact = true;
            }
            else
            {
                ObjBOLMember.ReferenceContact = false;
            }
            if (chkMainIn.Checked)
            {
                ObjBOLMember.MainContact = true;
            }
            else
            {
                ObjBOLMember.MainContact = false;
            }
            msg = ObjBLLMember.UpdateCustomerMember(ObjBOLMember);
            if (msg.Trim() != "")
            {
                if (msg.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(this, "Contact with the same name already exists for the customer !");
                    return;
                }
                Utility.ShowMessage_Success(Page, "Member Updated Successfully !!");
                if(HfCustomerID.Value != "-1")
                {
                    Utility.MaintainLogsSpecial("FrmCustomers.aspx", "Update-Contact", HfCustomerID.Value);
                }                
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
    /// Fix number of records per page
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
    /// Cancel all data in the grid view controls
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

    private void BindState(Int16 country)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 8;
            ObjBOL.CountryID = country;
            ds = ObjBLL.GetCustomersState(ObjBOL);
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

    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            if (hfJobDetails.Value != "-1")
            {
                Session["JobID"] = hfJobDetails.Value;
                Response.Redirect("~/SalesManagement/FrmProjects.aspx");
            }
            else
            {
                Utility.ShowMessage_Error(this, "JobID not Found !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}