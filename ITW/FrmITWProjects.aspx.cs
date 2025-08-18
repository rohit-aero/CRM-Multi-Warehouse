using BLLAERO;
using BOLAERO;
using System;
using System.Data;
using System.Web.UI;

public partial class ITW_FrmITWProjects : System.Web.UI.Page
{
    BOL_ITWProjects objBOL = new BOL_ITWProjects();
    BLL_ITWProjects objBLL = new BLL_ITWProjects();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindControl();
        }
    }

    #region Bind Functions

    private void BindControl()
    {
        try
        {
            DataSet ds = new DataSet();
            objBOL.Operation = 1;
            ds = objBLL.BindControls(objBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPOHeaderList, ds.Tables[0]);
                ddlPOHeaderList.SelectedIndex = 0;
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlDepartmentHeaderList, ds.Tables[1]);
                ddlDepartmentHeaderList.SelectedIndex = 0;
                Utility.BindDropDownList(ddlDepartment, ds.Tables[1]);
                ddlDepartment.SelectedIndex = 0;
            }

        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Validation Functions

    private Boolean ValidationCheck()
    {
        if (ddlDepartment.SelectedIndex == 0)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Department !');", true);
            Utility.ShowMessage_Error(Page, "Please Select Department !!");
            ddlDepartment.Focus();
            return false;
        }

        if (txtPONumber.Text == "")
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter PO Number. !');", true);
            Utility.ShowMessage_Error(Page, "Please Enter PO Number. !!");
            txtPONumber.Focus();
            return false;
        }

        return true;
    }

    #endregion

    #region Event Handler Functions

    protected void ddlPOHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlPOHeaderList_Event();
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void ddlDepartmentHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlDepartmentHeaderList_Event();
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
            btnSave_Event();
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

    #endregion

    #region Internal Event Functions

    private void ddlPOHeaderList_Event()
    {
        try
        {
            //ResetInfo();
            if (ddlPOHeaderList.SelectedIndex > 0)
            {
                var POID = Convert.ToInt32(ddlPOHeaderList.SelectedValue);
                BindHeaderListByDepartment();
                ddlPOHeaderList.SelectedValue = POID.ToString();
                DataSet ds = new DataSet();
                objBOL.Operation = 2;
                objBOL.POID = POID;
                ds = objBLL.BindControls(objBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["DepartmentID"].ToString()) > 0)
                    {
                        ddlDepartment.SelectedValue = ds.Tables[0].Rows[0]["DepartmentID"].ToString();
                    }
                    txtPONumber.Text = ds.Tables[0].Rows[0]["PO"].ToString();
                    txtVMOrderID.Text = ds.Tables[0].Rows[0]["VMOrderID"].ToString();
                    txtPOCost.Text = ds.Tables[0].Rows[0]["POCost"].ToString();
                    txtPORecDate.Text = ds.Tables[0].Rows[0]["PORecDate"].ToString();
                    txtPOReleaseDate.Text = ds.Tables[0].Rows[0]["POReleaseDate"].ToString();
                    txtComments.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
                }
                ddlPOHeaderList.SelectedValue = POID.ToString();
                btnSave.Text = "Update";
            }
            else
            {
                ResetInfo();
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void ddlDepartmentHeaderList_Event()
    {
        try
        {
            var departmentID = Convert.ToInt32(ddlDepartmentHeaderList.SelectedValue);
            var selectedIndex = ddlDepartmentHeaderList.SelectedIndex;
            ResetInfo();
            ClearPOHeaderList();
            if (selectedIndex > 0)
            {
                DataSet ds = new DataSet();
                objBOL.Operation = 5;
                objBOL.DepartmentID = departmentID;
                ds = objBLL.BindControls(objBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlPOHeaderList, ds.Tables[0]);
                    ddlPOHeaderList.SelectedIndex = 0;
                }
            }
            else
            {
                BindControl();
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void btnSave_Event()
    {
        try
        {
            if (ValidationCheck())
            {
                var showMessageSuccess = "";
                var operation = "";
                objBOL.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);
                objBOL.PONumber = txtPONumber.Text;
                if (txtPORecDate.Text != "")
                {
                    objBOL.PORecDate = Convert.ToDateTime(txtPORecDate.Text);
                }

                if (txtPOReleaseDate.Text != "")
                {
                    objBOL.POReleaseDate = Convert.ToDateTime(txtPOReleaseDate.Text);
                }
                objBOL.VMOrderID = txtVMOrderID.Text;
                if (txtPOCost.Text != "")
                {
                    objBOL.POCost = Convert.ToDecimal(txtPOCost.Text);
                }
                objBOL.Comments = txtComments.Text;
                if (ddlPOHeaderList.SelectedIndex > 0)
                {
                    objBOL.Operation = 4;
                    objBOL.POID = Convert.ToInt32(ddlPOHeaderList.SelectedValue);
                    showMessageSuccess = "Data Updated Successfully !!";
                    operation = "Update";
                }
                else
                {
                    objBOL.Operation = 3;
                    showMessageSuccess = "Data Inserted Successfully !!";
                    operation = "Save";
                }
                var returnId = objBLL.SaveAndUpdate(objBOL);
                if (returnId.Length > 0)
                {
                    if (returnId == "ER_01")
                    {
                        //Utility.ShowMessage(Page, "PONumber Already Exists !");
                        Utility.ShowMessage_Error(Page, "PONumber Already Exists !!");
                    }
                    else
                    {
                        Utility.MaintainLogsSpecial("FrmITWProjects", operation, returnId);
                        //Utility.ShowMessage(Page, showMessageSuccess);
                        Utility.ShowMessage_Success(Page, showMessageSuccess);
                        AfterSaveOrUpdateDataBind(returnId);
                    }
                }
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region others

    private void BindHeaderListByDepartment()
    {
        try
        {
            objBOL.Operation = 6;
            objBOL.POID = Convert.ToInt32(ddlPOHeaderList.SelectedValue);
            ddlDepartmentHeaderList.SelectedValue = objBLL.SaveAndUpdate(objBOL);
            ddlDepartmentHeaderList_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void AfterSaveOrUpdateDataBind(string returnPOId)
    {
        try
        {
            BindControl();
            ddlPOHeaderList.SelectedValue = returnPOId;
            ddlPOHeaderList_Event();
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Reset

    private void Reset()
    {
        try
        {
            if (ddlDepartmentHeaderList.Items.Count > 0)
            {
                ddlDepartmentHeaderList.SelectedIndex = 0;
            }
            ResetInfo();
            BindControl();
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
            if (ddlPOHeaderList.Items.Count > 0)
            {
                ddlPOHeaderList.SelectedIndex = 0;
            }

            if (ddlDepartment.Items.Count > 0)
            {
                ddlDepartment.SelectedIndex = 0;
            }

            txtPONumber.Text = String.Empty;
            txtPORecDate.Text = String.Empty;
            txtPOReleaseDate.Text = String.Empty;
            txtVMOrderID.Text = String.Empty;
            txtPOCost.Text = String.Empty;
            txtComments.Text = String.Empty;
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void ClearPOHeaderList()
    {
        try
        {
            ddlPOHeaderList.Items.Clear();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

}