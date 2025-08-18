using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
///  Proposal Form (30 May 2018) Rohit Kumar
/// </summary>
public partial class ContactManagement_FrmShipper : System.Web.UI.Page
{
    BOLManageShippers ObjBOL = new BOLManageShippers();
    BLLManageShipper ObjBLL = new BLLManageShipper();

    // Page load event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Controls("");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // Bind all dropdownlist here
    private void Bind_Controls(string ShipperID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 2;
            ds = ObjBLL.GetShipper(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlShipper, ds.Tables[0]);
                if (ShipperID != "")
                {
                    ddlShipper.SelectedValue = ShipperID;
                    return;
                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlComapnyState, ds.Tables[1]);                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlShipper_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlShipper.SelectedIndex > 0)
            {
                btnSave.Text = "Update";
                hfShipperID.Value = ddlShipper.SelectedValue;
                DataSet ds = new DataSet();
                ObjBOL.operation = 1;
                ObjBOL.ShipperID = Convert.ToInt32(ddlShipper.SelectedValue);
                ds = ObjBLL.GetShipper(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCompanyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
                    txtComapnyAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["StreetAddress"]);
                    txtCompanyCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]);
                    ddlComapnyState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["StateID"]);
                    //txtFName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                    //txtLName.Text = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                    //txtPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]);
                    //txtFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["Fax"]);
                    lblMsg.Text = "";
                    btnAdd.Enabled = true;
                    EnabledContactInfo();
                }
                BindGrid(ddlShipper.SelectedValue);
            }
            else
            {
                Reset();
                ResetGrid();
                DisabledContactInfo();
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
            if (txtCompanyName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Company Name. !');", true);
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

    // Reset all controls
    private void Reset()
    {
        try
        {
            Bind_Controls("");
            btnSave.Text = "Save";
            ddlShipper.SelectedIndex = 0;
            ddlComapnyState.SelectedIndex = 0;
            txtCompanyName.Text = string.Empty;
            txtCompanyCity.Text = string.Empty;
            txtComapnyAddress.Text = string.Empty;
            btnAdd.Enabled = false;
            //txtFName.Text = string.Empty;
            //txtLName.Text = string.Empty;
            //txtPhone.Text = string.Empty;
            //txtFax.Text = string.Empty;
            btnSave.Enabled = true;
            btnAdd.Text = "Add";
            lblMsg.Text = "";
            hfShipperID.Value = "-1";
            hfMemberID.Value = "-1";
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
            gvShipperMember.DataSource = "";
            gvShipperMember.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // Save data
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = "";
                if (ddlShipper.SelectedIndex > 0)
                {
                    ObjBOL.ShipperID = Convert.ToInt32(ddlShipper.SelectedValue);
                }
                else
                {
                    ObjBOL.ShipperID = 0;
                }
                ObjBOL.operation = 3;
                //ObjBOL.FirstName = txtFName.Text;
                //ObjBOL.LastName = txtLName.Text;
                ObjBOL.CompanyName = txtCompanyName.Text;
                ObjBOL.StreetAddress = txtComapnyAddress.Text;
                ObjBOL.City = txtCompanyCity.Text;
                ObjBOL.StateID = ddlComapnyState.SelectedValue;
                //ObjBOL.Phone = txtPhone.Text;
                //ObjBOL.Fax = txtFax.Text;
                msg = ObjBLL.SaveShipper(ObjBOL);
                if (ddlShipper.SelectedIndex > 0)
                {
                    hfShipperID.Value = ddlShipper.SelectedValue;
                    Utility.ShowMessage_Success(this, msg);
                    Utility.MaintainLogsSpecial("FrmShipper.aspx", "Update-CompanyInfo", hfShipperID.Value);
                }
                else
                {
                    hfShipperID.Value = msg;
                    Utility.ShowMessage_Success(this, "Shipper Added Successfully !");
                    Utility.MaintainLogsSpecial("FrmShipper.aspx", "Save-CompanyInfo", hfShipperID.Value);
                }                           
                Bind_Controls(hfShipperID.Value);
                BindGrid(hfShipperID.Value);
                EnabledContactInfo();
                btnSave.Text = "Update";              
            }
            else
            {
                DisabledContactInfo();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnabledContactInfo()
    {
        try
        {
            txtFName.Enabled = true;
            txtLName.Enabled = true;
            txtPhone.Enabled = true;
            txtEmail.Enabled = true;
            btnAdd.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisabledContactInfo()
    {
        try
        {
            txtFName.Enabled = false;
            txtLName.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;
            btnAdd.Enabled = false;
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
            ResetGrid();
            ResetMemberInfo();
            DisabledContactInfo();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private Boolean ValidationMemberCheck()
    {
        try
        {
            if (txtFName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Company Name. !');", true);
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


    public void SaveCompanyMembers()
    {
        try
        {
            if (ValidationMemberCheck() == true)
            {
                string msg = "";
                if(hfMemberID.Value != "-1")
                {
                    ObjBOL.operation = 5;
                    ObjBOL.ShipperMemberID = Convert.ToInt32(hfMemberID.Value);
                }
                else
                {
                    ObjBOL.operation = 4;
                }
                ObjBOL.ShipperID = Convert.ToInt32(ddlShipper.SelectedValue);
                ObjBOL.FirstName = txtFName.Text;
                ObjBOL.LastName = txtLName.Text;
                ObjBOL.Phone = txtPhone.Text;
                ObjBOL.Email = txtEmail.Text;
                msg = ObjBLL.SaveShipperMember(ObjBOL);
                if (msg != "I")
                {
                    Utility.ShowMessage_Success(Page, "Shipper Member Added Successfully !!");
                    Utility.MaintainLogsSpecial("FrmShippers", "Save-Member", ddlShipper.SelectedValue);
                    BindGrid(ddlShipper.SelectedValue);
                }
                else
                {
                    Utility.ShowMessage_Success(Page, "Shipper Member Updated Successfully !!");
                    Utility.MaintainLogsSpecial("FrmShippers", "Update-Member", ddlShipper.SelectedValue);
                    BindGrid(ddlShipper.SelectedValue);
                }
                ResetMemberInfo();
            }
            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlShipper.SelectedIndex > 0)
        {
            SaveCompanyMembers();
        }
        else
        {
            Utility.ShowMessage_Error(Page, "Please Select Company !!");
        }
    }

    private void ResetMemberInfo()
    {
        try
        {
            txtFName.Text = String.Empty;
            txtLName.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtEmail.Text = String.Empty;
            btnAdd.Text = "Add";
            btnSave.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void BindGrid(string ShipperID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 6;
            ObjBOL.ShipperID = Convert.ToInt32(ShipperID);
            ds = ObjBLL.GetShipper(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvShipperMember.DataSource = ds.Tables[0];
                gvShipperMember.DataBind();
            }
            else
            {
                gvShipperMember.DataSource = "";
                gvShipperMember.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShipperMember_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvShipperMember.EditIndex = e.NewEditIndex;
            Int32 shipperMemberID = Convert.ToInt32(gvShipperMember.DataKeys[e.NewEditIndex].Value);
            if (shipperMemberID > 0)
            {
                ObjBOL.ShipperMemberID = shipperMemberID;
                hfMemberID.Value =Convert.ToString(shipperMemberID);
            }
          
            Label lblFirstName=gvShipperMember.Rows[e.NewEditIndex].FindControl("lblGridFName") as Label;
            Label lblLName = gvShipperMember.Rows[e.NewEditIndex].FindControl("lblGridLName") as Label;
            Label lblPhone = gvShipperMember.Rows[e.NewEditIndex].FindControl("lblGridPhone") as Label;
            Label lblEmail = gvShipperMember.Rows[e.NewEditIndex].FindControl("lblGridEmail") as Label;
            if(lblFirstName.Text != "")
            {
                txtFName.Text = lblFirstName.Text;
            }
            else
            {
                txtFName.Text = String.Empty;
            }
            if(lblLName.Text != "")
            {
                txtLName.Text = lblLName.Text;
            }
            else
            {
                txtLName.Text = String.Empty;
            }
            if(lblPhone.Text != "")
            {
                txtPhone.Text = lblPhone.Text;
            }
            else
            {
                txtPhone.Text = String.Empty;
            }
            if(lblEmail.Text != "")
            {
                txtEmail.Text = lblEmail.Text;
            }
            else
            {
                txtEmail.Text = String.Empty;
            }
            btnSave.Enabled = false;
            btnAdd.Text = "Update";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShipperMember_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            Int32 shipperMemberID = Convert.ToInt32(gvShipperMember.DataKeys[e.RowIndex].Value);
            ObjBOL.operation = 7;
            ObjBOL.ShipperID =Convert.ToInt32(ddlShipper.SelectedValue);
            ObjBOL.ShipperMemberID = shipperMemberID;
            msg = ObjBLL.DeleteShipperMember(ObjBOL);
            if(msg == "D")
            {
                Utility.ShowMessage_Success(Page, "Shipper Member Deleted Successfully !");
                Utility.MaintainLogsSpecial("FrmShipper", "Member-Deleted", ddlShipper.SelectedValue);
                BindGrid(ddlShipper.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}