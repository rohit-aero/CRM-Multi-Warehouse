using BLLAERO;
using BOLAERO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NACUFS_FrmContact : System.Web.UI.Page
{
    BOLContactListing ObjBOL = new BOLContactListing();
    BLLContacts ObjBLL = new BLLContacts();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Control();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetContectDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlUniv, ds.Tables[0]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddldesg, ds.Tables[3]);
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
            if (ddlUniv.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select University. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select University. !");
                ddlUniv.Focus();
                return false;
            }
            //if (ddlCampus.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Campus. !');", true);
            //    ddlCampus.Focus();
            //    return false;
            //}
            if (txtFName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter First Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter First Name. !");
                txtFName.Focus();
                return false;
            }
            if (txtLName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Last Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Last Name. !");
                txtLName.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void Reset_ContactDetails()
    {
        try
        {
            txtFName.Text = "";
            txtLName.Text = "";
            ddldesg.SelectedIndex = 0;
            txtPhone.Text = "";
            txtEml.Text = "";
            txtCity.Text = "";
            txtStreet.Text = "";
            txtZipCode.Text = "";
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void ResetSpecial()
    {
        txtFName.Text = "";
        txtLName.Text = "";
        ddldesg.SelectedIndex = 0;
        ddlCampus.DataSource = "";
        ddlCampus.DataBind();
        ddlContacts.DataSource = "";
        ddlContacts.DataBind();
        txtPhone.Text = "";
        txtEml.Text = "";
        txtCity.Text = "";
        txtStreet.Text = "";
        txtZipCode.Text = "";
        btnSave.Text = "Save";
    }
    private void Reset()
    {
        try
        {
            ddlUniv.SelectedIndex = 0;
            ddlUniv.DataSource = "";
            //ddlContacts.SelectedIndex = 0;
            ddlContacts.DataSource = "";
            ddlContacts.DataBind();
            //ddlCampus.SelectedIndex = 0;
            ddlCampus.DataSource = "";
            ddlCampus.DataBind();
            ddldesg.SelectedIndex = 0;
            txtFName.Text = String.Empty;
            txtLName.Text = String.Empty;
            txtEml.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtCity.Text = String.Empty;
            txtStreet.Text = String.Empty;
            txtZipCode.Text = String.Empty;
            ddldesg.SelectedIndex = 0;
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void Bind_Campus(Int32 UniID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ObjBOL.UniID = UniID;
            ds = ObjBLL.GetContectDetails(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCampus, ds.Tables[1]);
            }
            else
            {
                ddlCampus.DataSource = "";
                ddlCampus.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }
    protected void ddlUniv_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlUniv.Items.Count > 0)
            {
                ResetSpecial();
            }
            if (ddlUniv.SelectedIndex > 0)
            {
                Bind_Campus(Convert.ToInt32(ddlUniv.SelectedValue));
                Bind_UniContacts(Convert.ToInt32(ddlUniv.SelectedValue));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void Bind_UniContacts(Int32 UniID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ObjBOL.UniID = UniID;
            ds = ObjBLL.GetContectDetails(ObjBOL);
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlContacts, ds.Tables[4]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void Bind_Contact(Int32 CampusID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ObjBOL.CampusID = CampusID;
            ds = ObjBLL.GetContectDetails(ObjBOL);
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlContacts, ds.Tables[2]);
            }
            else
            {
                ddlContacts.DataSource = "";
                ddlContacts.DataBind();
            }
            if (ddlContacts.SelectedIndex > 0)
            {
                ObjBOL.id = Convert.ToInt32(ddlContacts.SelectedValue);
                txtFName.Text = "";
            }
            if (ddlContacts.Items.Count == 0)
            {
                Reset_ContactDetails();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCampus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCampus.Items.Count > 0)
            {
                txtFName.Text = "";
                txtLName.Text = "";
                ddldesg.SelectedIndex = 0;
                ddlContacts.DataSource = "";
                ddlContacts.DataBind();
                txtPhone.Text = "";
                txtEml.Text = "";
                txtCity.Text = "";
                txtStreet.Text = "";
                txtZipCode.Text = "";
                btnSave.Text = "Save";
            }
            Bind_Contact(Convert.ToInt32(ddlCampus.SelectedValue));
            if (ddlCampus.SelectedIndex > 0)
            {
                Bind_Contact(Convert.ToInt32(ddlCampus.SelectedValue));
            }
            else
            {
                Bind_UniContacts(Convert.ToInt32(ddlUniv.SelectedValue));
                //txtFName.Text = String.Empty;
                //txtLName.Text = String.Empty;
                //ddldesg.SelectedIndex = 0;
                //txtPhone.Text = String.Empty;
                //txtEml.Text = String.Empty;
                //txtCity.Text = String.Empty;
                //txtStreet.Text = String.Empty;
                //txtZipCode.Text = String.Empty;
                //btnSave.Text = "Save";
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
            if (ValidationCheck() == true)
            {
                String msg = "";
                if (ddlUniv.SelectedIndex > 0)
                {
                    ObjBOL.UniID = Convert.ToInt32(ddlUniv.SelectedValue);
                }
                else
                {
                    ObjBOL.UniID = 0;
                }
                if (ddlContacts.SelectedIndex > 0)
                {
                    ObjBOL.ContactId = Convert.ToInt32(ddlContacts.SelectedValue);
                }
                else
                {
                    ObjBOL.ContactId = 0;
                }
                ObjBOL.Operation = 3;
                if (ddlCampus.SelectedIndex > 0)
                {
                    ObjBOL.CampusID = Convert.ToInt32(ddlCampus.SelectedValue);
                }
                ObjBOL.FirstName = txtFName.Text;
                ObjBOL.LastName = txtLName.Text;
                ObjBOL.DesgID = Convert.ToInt32(ddldesg.SelectedValue);
                ObjBOL.Phone = txtPhone.Text;
                ObjBOL.Email = txtEml.Text;
                ObjBOL.City = txtCity.Text;
                ObjBOL.StreetAddress = txtStreet.Text;
                ObjBOL.ZipCode = txtZipCode.Text;
                msg = ObjBLL.SaveContectDetails(ObjBOL);
                Utility.ShowMessage_Success(this, msg);
                Utility.MaintainLogs("FrmContacts.aspx", "Save");
                Bind_Control();
                btnSave.Text = "Save";
                Reset();
            }
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
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlContacts_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlContacts.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.ContactId = Convert.ToInt32(ddlContacts.SelectedValue);
                ds = ObjBLL.GetContectDetails(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtFName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                    txtLName.Text = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                    ddldesg.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["DesgID"]);
                    txtEml.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    txtPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]);
                    txtCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]);
                    txtStreet.Text = Convert.ToString(ds.Tables[0].Rows[0]["Street"]);
                    txtZipCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["ZipCode"]);
                    lblMsg.Text = "";
                    btnSave.Text = "Update";
                }
            }
            else
            {
                Reset_ContactDetails();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}

