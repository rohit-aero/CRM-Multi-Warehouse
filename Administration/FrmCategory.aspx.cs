using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;
///Summary
///Category Form designed By Rohit Kumar on 09-April-2019
public partial class Administration_frmCategory : System.Web.UI.Page
{
    BOLfrmCategory objBOL = new BOLfrmCategory();
    BLLfrmCategory objBLL = new BLLfrmCategory();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Controls();
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }


    }
    /// <summary>
    /// Prepare ddlCategory drop down list
    /// </summary>

    //Bind Category in Drop Down List
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            objBOL.Operation = 1;
            ds = objBLL.GetCategory(objBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCategory, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }
    /// <summary>
    /// After Category Changed event fill records in 
    /// the related textboxes

    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //Selected Index Changed Display Selected Data from Drop Down List
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCategory.SelectedIndex > 0)
            {
                hfCategoryID.Value = ddlCategory.SelectedValue;
                DataSet ds = new DataSet();
                objBOL.Operation = 3;
                objBOL.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                ds = objBLL.GetCategory(objBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Category"]);
                    txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["CategoryDescription"]);
                    lblMsg.Text = "";
                    btnSave.Text = "Update";
                    Utility.MaintainLogs("FrmCategory.aspx", "Save");
                }

            }

        }
        catch (Exception ex)

        {
            Utility.AddEditException(ex);
        }
    }
    /// <summary>
    /// Mandetory fields before Save the data
    /// </summary>
    /// <returns></returns>
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Category Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Category Name. !");
                txtName.Focus();
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
    /// Clear Records
    /// </summary>
    //RESET Operation
    private void Reset()
    {
        try
        {
            ddlCategory.SelectedIndex = 0;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            lblMsg.Text = "";
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }
    /// <summary>
    /// Save information from page to SQL Server database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //SAVE DATA 
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                String msg = "";
                if (ddlCategory.SelectedIndex > 0)
                {
                    objBOL.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                }
                else
                {
                    objBOL.CategoryID = 0;
                }
                objBOL.Operation = 2;
                objBOL.Category = txtName.Text;
                objBOL.CategoryDescription = txtDescription.Text;
                msg = objBLL.SaveCategory(objBOL);
                if (ddlCategory.SelectedIndex > 0)
                {
                    hfCategoryID.Value = ddlCategory.SelectedValue;
                }
                else
                {
                    hfCategoryID.Value = msg;
                }
                Utility.ShowMessage_Success(this, msg);
                Bind_Controls();
                Reset();
                btnSave.Text = "Save";
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }


    }
    /// <summary>
    /// Cancel entered information 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //CANCEL DATA
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
}