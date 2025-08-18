using System;
using BOLAERO;
using BLLAERO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TurboWash_FrmITWProjectParts : System.Web.UI.Page
{
    BOLManageITWProjectParts ObjBOL = new BOLManageITWProjectParts();
    BLLManageITWProjectParts ObjBLL = new BLLManageITWProjectParts();

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
            ObjBOL.Operation = 4;
            DataSet ds = new DataSet();
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlCategory, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartsDetail, ds.Tables[1]);
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
            if (txtSearchPNum.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter job !");
                txtSearchPNum.Focus();
                return false;
            }

            if (ddlPartsDetail.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select part !");
                ddlPartsDetail.Focus();
                return false;
            }

            if (txtQty.Text == "" || Int32.Parse(txtQty.Text) == 0)
            {
                Utility.ShowMessage_Error(Page, "Please enter qty !");
                txtQty.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCategory_SelectedIndexChanged_Event();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck())
            {
                if (HfProjectPartID.Value == "-1")
                {
                    ObjBOL.Operation = 7;
                    ObjBOL.PartID = Int32.Parse(ddlPartsDetail.SelectedValue);
                    ObjBOL.JobID = txtSearchPNum.Text.Split(',')[0];
                }
                else
                {
                    ObjBOL.Operation = 8;
                    ObjBOL.PartID = Int32.Parse(HfProjectPartID.Value);
                }

                ObjBOL.Qty = Int32.Parse(txtQty.Text);
                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim() != "")
                {
                    if (returnStatus.Trim() == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "Part already exists for the Job !");
                    }
                    else
                    {
                        if (HfProjectPartID.Value == "-1")
                        {
                            Utility.ShowMessage_Success(Page, "Record saved sucessfully !!");
                            Utility.MaintainLogsSpecial("FrmITWProjectParts", "Save", txtSearchPNum.Text.Split(',')[0]);
                        }
                        else
                        {
                            Utility.ShowMessage_Success(Page, "Record updated sucessfully !!");
                            Utility.MaintainLogsSpecial("FrmITWProjectParts", "Update", txtSearchPNum.Text.Split(',')[0]);
                        }
                        btnClear_Click_Event();
                        ClearGrid();
                        BindGrid();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        btnClear_Click_Event();
    }

    protected void txtSearchJName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (ValidateProject())
            {
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int ID = Convert.ToInt32(gvDetail.DataKeys[e.RowIndex].Values[0]);
            ObjBOL.Operation = 9;
            ObjBOL.PartID = ID;
            string returnStatus = ObjBLL.Return_String(ObjBOL);
            if (returnStatus != "")
            {
                Utility.MaintainLogsSpecial("FrmITWProjectParts", "Delete", txtSearchPNum.Text.Split(',')[0]);
                Utility.ShowMessage_Success(Page, "Record deleted sucessfully !!");
                btnClear_Click_Event();
                ClearGrid();
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            int ID = Convert.ToInt32(gvDetail.DataKeys[e.NewEditIndex].Values[0]);
            HfProjectPartID.Value = ID.ToString();
            ObjBOL.Operation = 3;
            ObjBOL.PartID = ID;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (ddlCategory.Items.FindByValue(row["CategoryID"].ToString()) != null)
                {
                    ddlCategory.SelectedValue = row["CategoryID"].ToString();
                    ddlCategory_SelectedIndexChanged_Event();
                }

                if (ddlPartsDetail.Items.FindByValue(row["PartID"].ToString()) != null)
                {
                    ddlPartsDetail.SelectedValue = row["PartID"].ToString();
                }

                txtQty.Text = row["Qty"].ToString();
                btnSave.Text = "Update";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlCategory_SelectedIndexChanged_Event()
    {
        try
        {
            ObjBOL.Operation = 5;
            ObjBOL.CategoryID = Int32.Parse(ddlCategory.SelectedValue);
            DataSet ds = new DataSet();
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartsDetail, ds.Tables[0]);
            }
            else
            {
                ddlPartsDetail.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnClear_Click_Event()
    {
        try
        {
            ddlCategory.SelectedIndex = 0;
            ddlPartsDetail.SelectedIndex = 0;
            txtQty.Text = string.Empty;
            HfProjectPartID.Value = "-1";
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearGrid()
    {
        try
        {
            gvDetail.DataSource = string.Empty;
            gvDetail.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidateProject()
    {
        try
        {
            ObjBOL.Operation = 6;
            ObjBOL.JobID = txtSearchPNum.Text;
            int returnStatus = ObjBLL.Return_DataSet(ObjBOL).Tables[0].Rows.Count;
            if (returnStatus > 0)
            {
                return true;
            }
            else
            {
                txtSearchPNum.Text = string.Empty;
                btnClear_Click_Event();
                ClearGrid();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return false;
    }

    private void BindGrid()
    {
        try
        {
            ObjBOL.Operation = 2;
            ObjBOL.JobID = txtSearchPNum.Text.Split(',')[0];
            DataSet ds = new DataSet();
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetail.DataSource = ds.Tables[0];
                gvDetail.DataBind();
            }
            else
            {
                ClearGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}