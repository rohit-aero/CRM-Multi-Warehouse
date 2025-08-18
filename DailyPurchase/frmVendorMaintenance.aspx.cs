using BLLAERO;
using BOLAERO;
using System;
using System.Data;
using System.Web.UI;

public partial class DailyPurchase_frmVendorMaintenance : System.Web.UI.Page
{
    BOLVendorMaintenance ObjBOL = new BOLVendorMaintenance();
    BLLVendorMaintenance ObjBLL = new BLLVendorMaintenance();
    commonclass1 commonClass = new commonclass1();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
        }
    }

    //BIND DROPDOWNS

    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.Return_DataSet(ObjBOL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlVendorList, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //VALIDATION CHECKS

    private Boolean ValidationCheck()
    {
        try
        {
            if (txtVendorName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Vendor name is required!');", true);
                Utility.ShowMessage_Error(Page, "Vendor name is required!");
                txtVendorName.Focus();
                return false;
            }

            if (txtEmail.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Email is required!');", true);
                Utility.ShowMessage_Error(Page, "Email is required!");
                txtEmail.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    //EVENT FUNCTIONS

    protected void ddlVendorList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlVendorList_SelectedIndexChanged();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave_Click();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel_Click();
    }

    // FUNCTIONS USED IN EVENTS

    private void ddlVendorList_SelectedIndexChanged()
    {
        try
        {
            ResetInfo();
            if (ddlVendorList.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 4;
                ObjBOL.Id = Int32.Parse(ddlVendorList.SelectedValue);
                ds = ObjBLL.Return_DataSet(ObjBOL);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    txtVendorName.Text = dr["VendorName"].ToString();
                    txtLeadTimeDays.Text = dr["LeadTimeDays"].ToString();
                    txtNotes.Text = dr["Notes"].ToString();
                    txtStreetAddress.Text = dr["Address"].ToString();
                    txtContact.Text = dr["ContactPerson"].ToString();
                    txtPhone.Text = dr["Phone"].ToString();
                    txtEmail.Text = dr["Email"].ToString();

                    btnSave.Text = "Update";
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnSave_Click()
    {
        try
        {
            if (ValidationCheck())
            {
                string message = string.Empty;
                if (ddlVendorList.SelectedIndex > 0)
                {
                    ObjBOL.Operation = 5;
                    ObjBOL.Id = Int32.Parse(ddlVendorList.SelectedValue);
                    message = "Record updated successfully !!";
                }
                else
                {
                    ObjBOL.Operation = 3;
                    message = "Record inserted successfully !!";
                }

                ObjBOL.Name = txtVendorName.Text.Trim();
                if (txtLeadTimeDays.Text.Trim() != "")
                {
                    ObjBOL.LeadTimeDays = Int32.Parse(txtLeadTimeDays.Text);
                }
                ObjBOL.Notes = txtNotes.Text.Trim();
                ObjBOL.StreetAddress = txtStreetAddress.Text.Trim();
                ObjBOL.Contact = txtContact.Text.Trim();
                ObjBOL.Phone = txtPhone.Text;
                ObjBOL.Email = txtEmail.Text;
                string returnStatus = ObjBLL.Return_String(ObjBOL).Trim();

                if (returnStatus.Length > 0)
                {
                    if (returnStatus == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "Vendor already exists !");
                        return;
                    }

                    Utility.ShowMessage_Success(Page, message);
                    Utility.MaintainLogsSpecial("frmVendorMaintenance.aspx", btnSave.Text, returnStatus);
                    BindControls();
                    ddlVendorList.SelectedValue = returnStatus;
                    ddlVendorList_SelectedIndexChanged();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnCancel_Click()
    {
        try
        {
            ddlVendorList.SelectedIndex = 0;
            ResetInfo();
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
            txtVendorName.Text = String.Empty;
            txtLeadTimeDays.Text = String.Empty;
            txtContact.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtStreetAddress.Text = String.Empty;
            txtNotes.Text = String.Empty;
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}