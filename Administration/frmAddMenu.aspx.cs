using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;

public partial class Administration_frmAddMenu : System.Web.UI.Page
{
    BOLAddMenu ObjBOL = new BOLAddMenu();
    BLLAddMenu ObjBLL = new BLLAddMenu();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Controls();
        }
    }

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlMenuLookUp, ds.Tables[0]);                
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlParentID, ds.Tables[1]);
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
            if (txtName.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Generate Poject Number. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Name. !");
                txtName.Focus();
                return false;
            }
            if (txtDesc.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Generate Poject Number. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Description. !");
                txtDesc.Focus();
                return false;
            }
            if (rdbStatus.SelectedValue == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Generate Poject Number. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                rdbStatus.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }


    private void BindMenuLookup(string MenuID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlMenuLookUp, ds.Tables[0]);
                if (ddlMenuLookUp.Items.Count > 0)
                {
                    ddlMenuLookUp.SelectedValue = MenuID;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    protected void ddlMenuLookUp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlMenuLookUp.SelectedIndex > 0)
            {
                FillDetails();
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


    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveData();
    }

    private void SaveData()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                bool Status = false;
                string msg = "";
                string notify = "";
                if (ddlMenuLookUp.SelectedIndex > 0)
                {
                    ObjBOL.Operation = 3;
                    ObjBOL.MenuID = Convert.ToInt32(ddlMenuLookUp.SelectedValue);
                }
                else
                {
                    ObjBOL.Operation = 2;

                }
                ObjBOL.Name = txtName.Text;
                ObjBOL.Description = txtDesc.Text;
                ObjBOL.Url = txtUrl.Text;
                if (ddlParentID.SelectedIndex > 0)
                {
                    ObjBOL.ParentID = Convert.ToInt32(ddlParentID.SelectedValue);
                }
                ObjBOL.Status = Convert.ToInt32(rdbStatus.SelectedValue);
                if (txtMenuSortOrder.Text != "")
                {
                    ObjBOL.SortOrder = Convert.ToInt32(txtMenuSortOrder.Text);
                }
                msg = ObjBLL.Return_String(ObjBOL);
                if (msg == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "Duplicate Records !!");
                }
                else
                {
                    if (msg != "Menu Updated Successfully !!")
                    {
                        BindMenuLookup(msg);
                        Utility.ShowMessage_Success(Page, "Menu Inserted Successfully !!");
                    }
                    else
                    {
                        Utility.ShowMessage_Success(Page, "Menu Updated Successfully !!");
                    }

                }
            }
            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillDetails()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.MenuID =Convert.ToInt32(ddlMenuLookUp.SelectedValue);
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string BindStatus = "";
                string ParentID = "";
                txtName.Text = ds.Tables[0].Rows[0]["Menu"].ToString();
                txtDesc.Text = ds.Tables[0].Rows[0]["Desc"].ToString();
                txtUrl.Text = ds.Tables[0].Rows[0]["Url"].ToString();
                ParentID = ds.Tables[0].Rows[0]["parent_id"].ToString();
                BindParentList(ParentID);   
                if(Convert.ToBoolean(ds.Tables[0].Rows[0]["status"]) == true)
                {
                    BindStatus = "1";
                }
                else
                {
                    BindStatus = "0";
                }
                rdbStatus.SelectedValue = BindStatus;
                txtMenuSortOrder.Text = ds.Tables[0].Rows[0]["sortorder"].ToString();
                btnSave.Text = "Update";
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindParentList(string ParentID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;                        
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlParentID, ds.Tables[0]);
                if (ddlParentID.Items.Count>0)
                {
                    ddlParentID.SelectedValue = ParentID;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Reset()
    {
        try
        {
            txtName.Text = String.Empty;
            txtDesc.Text = String.Empty;
            txtUrl.Text = String.Empty;
            ddlParentID.SelectedIndex = 0;
            rdbStatus.SelectedValue = "1";
            txtMenuSortOrder.Text = String.Empty;
            ddlMenuLookUp.SelectedIndex = 0;
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
    }
}