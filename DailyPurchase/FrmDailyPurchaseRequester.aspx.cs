using System;
using BOLAERO;
using BLLAERO;
using System.Data;

public partial class DailyPurchase_FrmDailyPurchaseRequester : System.Web.UI.Page
{
    BOLDailyPurchaseRequester ObjbOL = new BOLDailyPurchaseRequester();
    BLLDailyPurchaseRequester ObjBLL = new BLLDailyPurchaseRequester();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControls();
        }
    }

    private void BindControls()
    {
        try
        {
            ObjbOL.Operation = 1;
            DataSet ds = new DataSet();
            ds = ObjBLL.Return_DataSet(ObjbOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRequesterHeaderList, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlRequesterHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRequesterHeaderList_SelectedIndexChanged();
    }

    private void ddlRequesterHeaderList_SelectedIndexChanged()
    {
        try
        {
            ResetInfo();
            if (ddlRequesterHeaderList.SelectedIndex > 0)
            {
                ObjbOL.Operation = 2;
                ObjbOL.ID = Int32.Parse(ddlRequesterHeaderList.SelectedValue);
                DataSet ds = new DataSet();
                ds = ObjBLL.Return_DataSet(ObjbOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    txtFirstName.Text = dr["FirstName"].ToString();
                    txtLastName.Text = dr["LastName"].ToString();
                    if (dr["Active"].ToString() == "1")
                    {
                        ddlActive.SelectedValue = "1";
                    }
                    else
                    {
                        ddlActive.SelectedValue = "0";
                    }
                }
                btnSave.Text = "Update";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationCheck()
    {
        try
        {
            if (txtFirstName.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter first name !!");
                txtFirstName.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave_Click();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel_Click();
    }

    private void btnSave_Click()
    {
        try
        {
            if (ValidationCheck())
            {
                string message = string.Empty;
                if (ddlRequesterHeaderList.SelectedIndex > 0)
                {
                    ObjbOL.Operation = 4;//update
                    ObjbOL.ID = Int32.Parse(ddlRequesterHeaderList.SelectedValue);
                    message = "Requester updated successfully !!";
                }
                else
                {
                    ObjbOL.Operation = 3;//insert
                    message = "Requester inserted successfully !!";
                }
                ObjbOL.FirstName = txtFirstName.Text;
                ObjbOL.LastName = txtLastName.Text;
                ObjbOL.Active = Int32.Parse(ddlActive.SelectedValue);
                string returnStatus = ObjBLL.Return_String(ObjbOL).Trim();
                if (returnStatus.Length > 0)
                {
                    if (returnStatus == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "Requester already exists !!");
                        return;
                    }

                    Utility.MaintainLogsSpecial("FrmDailyPurchaseRequester.aspx", btnSave.Text, returnStatus);
                    Utility.ShowMessage_Success(Page, message);
                    btnCancel_Click();
                    BindControls();
                    ddlRequesterHeaderList.SelectedValue = returnStatus;
                    ddlRequesterHeaderList_SelectedIndexChanged();
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
            if (ddlRequesterHeaderList.Items.Count > 0)
            {
                ddlRequesterHeaderList.SelectedIndex = 0;
            }
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
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            if (ddlActive.Items.Count > 0)
            {
                ddlActive.SelectedValue = "1";
            }
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}