using System;
using BOLAERO;
using BLLAERO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TurboWash_FrmITWProjects : System.Web.UI.Page
{
    BOLManageITWProjects ObjBOL = new BOLManageITWProjects();
    BLLManageITWProjects ObjBLL = new BLLManageITWProjects();

    BOLManageITWProjectParts ObjBOL_1 = new BOLManageITWProjectParts();
    BLLManageITWProjectParts ObjBLL_1 = new BLLManageITWProjectParts();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisableButtons();
            BindControls();
        }
    }

    private bool ValidationCheck()
    {
        try
        {
            if (txtJobId.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter JobID !");
                txtJobId.Focus();
                return false;
            }

            if (txtHobartDrawingNumber.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Hobart Drawing Number !");
                txtHobartDrawingNumber.Focus();
                return false;
            }

            if (txtProjectName.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Project Name !");
                txtProjectName.Focus();
                return false;
            }

            if (txtPOReceivedDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter PO Received Date !");
                txtPOReceivedDate.Focus();
                return false;
            }

            if (txtReqShipDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Req. Ship Date !");
                txtReqShipDate.Focus();
                return false;
            }

            //if (txtShipDate.Text == "")
            //{
            //    Utility.ShowMessage_Error(Page, "Please enter Ship Date !");
            //    txtShipDate.Focus();
            //    return false;
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private bool ValidationCheck_Release()
    {
        try
        {
            if (txtReleaseDate.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Release Date !");
                txtReleaseDate.Focus();
                return false;
            }

            DateTime ReleaseDateTemp;
            if (!DateTime.TryParse(txtReleaseDate.Text, out ReleaseDateTemp))
            {
                Utility.ShowMessage_Error(Page, "Please enter valid Release Date !");
                txtReleaseDate.Focus();
                return false;
            }

            if (txtJobId.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please select JobID !");
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            btnCancel_Click_Event();
            ObjBOL.Operation = 3;
            txtJobId.Text = ObjBLL.Return_String(ObjBOL);
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
            if (ValidationCheck())
            {
                if (txtSearchPName.Text.Trim() == "")
                {
                    ObjBOL.Operation = 4;
                }
                else
                {
                    ObjBOL.Operation = 5;
                }

                ObjBOL.JobID = txtJobId.Text;
                ObjBOL.HobartDrawingNumber = txtHobartDrawingNumber.Text;
                ObjBOL.ProjectName = txtProjectName.Text;
                ObjBOL.Orientation = ddlOrientationList.SelectedValue;
                ObjBOL.OptionID = Int32.Parse(ddlOption.SelectedValue);
                if (txtPOReceivedDate.Text.Trim() != "")
                {
                    ObjBOL.POReceivedDate = Utility.ConvertDate(txtPOReceivedDate.Text);
                }

                if (txtReqShipDate.Text.Trim() != "")
                {
                    ObjBOL.ReqShipDate = Utility.ConvertDate(txtReqShipDate.Text);
                }

                if (txtShipDate.Text.Trim() != "")
                {
                    ObjBOL.ShipDate = Utility.ConvertDate(txtShipDate.Text);
                }

                if (txtEqPrice.Text.Trim() != "")
                {
                    ObjBOL.EqPrice = decimal.Parse(txtEqPrice.Text);
                }

                if (txtReleaseDate.Text.Trim() != "")
                {
                    ObjBOL.ReleaseDate = Utility.ConvertDate(txtReleaseDate.Text);
                }

                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim().Length > 0)
                {
                    if (returnStatus.Trim() == "ER01")
                    {
                        Utility.ShowMessage_Error(Page, "Job Id already exists !");
                    }
                    else
                    {
                        if (txtSearchPName.Text.Trim() == "")
                        {
                            Utility.MaintainLogsSpecial("ITWProjects", "Save", txtJobId.Text);
                            Utility.ShowMessage_Success(Page, "Project inserted successfully !!");
                        }
                        else
                        {
                            Utility.MaintainLogsSpecial("ITWProjects", "Update", txtJobId.Text);
                            Utility.ShowMessage_Success(Page, "Project updated successfully !!");
                        }
                        AfterSaveOrUpdateSequence(txtJobId.Text);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel_Click_Event();
    }

    protected void txtSearchPName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            SyncLookups("NAME");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtSearchPNum_TextChanged(object sender, EventArgs e)
    {
        try
        {
            SyncLookups("NUMBER");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidateProject(string lookupSelector)
    {
        try
        {
            ObjBOL.Operation = 6;
            if (lookupSelector.ToUpper() == "NAME")
            {
                ObjBOL.JobID = txtSearchPName.Text.Split(',')[0];
            }
            else if (lookupSelector.ToUpper() == "NUMBER")
            {
                ObjBOL.JobID = txtSearchPNum.Text.Split(',')[0];
            }
            DataTable dt = new DataTable();
            dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
            int count = dt.Rows.Count;
            if (count > 0)
            {
                FetchInfo(dt);
                return true;
            }
            else
            {
                txtSearchPName.Text = string.Empty;
                txtSearchPNum.Text = string.Empty;
                btnCancel_Click_Event();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return false;
    }

    private void SyncLookups(string lookupSelector)
    {
        try
        {
            bool validProject = ValidateProject(lookupSelector);
            if (validProject)
            {
                if (lookupSelector.ToUpper() == "NAME")
                {
                    txtSearchPNum.Text = txtSearchPName.Text;
                }
                else if (lookupSelector.ToUpper() == "NUMBER")
                {
                    txtSearchPName.Text = txtSearchPNum.Text;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnCancel_Click_Event()
    {
        try
        {
            txtSearchPName.Text = string.Empty;
            txtSearchPNum.Text = string.Empty;
            txtJobId.Text = string.Empty;
            txtHobartDrawingNumber.Text = string.Empty;
            txtProjectName.Text = string.Empty;
            ddlOrientationList.SelectedIndex = 0;
            ddlOption.SelectedIndex = 0;
            txtPOReceivedDate.Text = string.Empty;
            txtReqShipDate.Text = string.Empty;
            txtShipDate.Text = string.Empty;
            txtEqPrice.Text = string.Empty;
            txtReleaseDate.Text = string.Empty;
            DisableButtons();
            btnClear_Click_Event();
            ClearGrid();
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FetchInfo(DataTable dt)
    {
        try
        {
            Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
            {
                { "JobID", d => txtJobId.Text = d["JobID"].ToString() },
                { "HobartDrawingNumber", d => txtHobartDrawingNumber.Text = d["HobartDrawingNumber"].ToString() },
                { "ProjectName", d => txtProjectName.Text = d["ProjectName"].ToString() },
                { "Orientation", d =>
                    {
                       if(ddlOrientationList.Items.FindByValue(d["Orientation"].ToString()) != null)
                        {
                            ddlOrientationList.SelectedValue = d["Orientation"].ToString();
                        }
                    }
                },
                { "OptionID", d =>
                    {
                        if(ddlOption.Items.FindByValue(d["OptionID"].ToString()) != null)
                        {
                            ddlOption.SelectedValue = d["OptionID"].ToString();
                        }
                    }
                },
                { "POReceivedDate", d => txtPOReceivedDate.Text = d["POReceivedDate"].ToString() },
                { "ReqShipDate", d => txtReqShipDate.Text = d["ReqShipDate"].ToString() },
                { "ShipDate", d => txtShipDate.Text = d["ShipDate"].ToString() },
                { "EqPrice", d => txtEqPrice.Text = Convert.ToDecimal(d["EqPrice"]).ToString("N") },
                { "ReleaseDate", d => txtReleaseDate.Text = d["ReleaseDate"].ToString() },
                { "Release", d=>
                    {
                        btnRelease.Enabled = !bool.Parse(d["Release"].ToString());
                        btnRollback.Enabled = bool.Parse(d["Release"].ToString());
                        if(bool.Parse(d["Release"].ToString()))
                        {
                            DisableProjectParts();
                        }else
                        {
                            EnableProjectParts();
                        }
                    }
                }
            };

            foreach (var assignment in assignments)
            {
                try
                {
                    assignment.Value(dt.Rows[0]);
                }
                catch (Exception ex)
                {
                    Utility.AddEditException(ex, assignment.Key);
                }
            }
            btnClear_Click_Event();
            BindGrid();
            btnSave.Text = "Update";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void AfterSaveOrUpdateSequence(string JobID)
    {
        try
        {
            btnCancel_Click_Event();
            ObjBOL.ProjectName = JobID;
            ObjBOL.Operation = 1;
            DataTable dt = new DataTable();
            dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
            txtSearchPNum.Text = dt.Rows[0]["ProjectName"].ToString();
            SyncLookups("NUMBER");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnRelease_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck_Release())
            {
                ObjBOL.Operation = 7;
                ObjBOL.JobID = txtJobId.Text;
                ObjBOL.ReleaseDate = Convert.ToDateTime(txtReleaseDate.Text);
                ObjBOL.LoginUserID = Utility.GetCurrentUser();
                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim().Length > 0)
                {
                    if (returnStatus.Trim() == "ER01")
                    {
                        Utility.ShowMessage_Success(Page, "Job doesnot exists !");
                        return;
                    }
                    else
                    {
                        Utility.MaintainLogsSpecial("FrmITWProjects", "Release", txtJobId.Text);
                        Utility.ShowMessage_Success(Page, returnStatus);
                        AfterSaveOrUpdateSequence(txtJobId.Text);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnRollback_Click(object sender, EventArgs e)
    {
        try
        {
            ObjBOL.Operation = 8;
            ObjBOL.LoginUserID = Utility.GetCurrentUser();
            ObjBOL.JobID = txtJobId.Text;
            string returnStatus = ObjBLL.Return_String(ObjBOL);
            if (returnStatus.Trim().Length > 0)
            {
                if (returnStatus.Trim() == "ER01")
                {
                    Utility.ShowMessage_Success(Page, "Job doesnot exists !");
                    return;
                }
                else
                {
                    Utility.MaintainLogsSpecial("FrmITWProjects", "Rollback", txtJobId.Text);
                    Utility.ShowMessage_Success(Page, returnStatus);
                    AfterSaveOrUpdateSequence(txtJobId.Text);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableButtons()
    {
        try
        {
            btnRelease.Enabled = false;
            btnRollback.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindControls()
    {
        try
        {
            ObjBOL_1.Operation = 4;
            DataSet ds = new DataSet();
            ds = ObjBLL_1.Return_DataSet(ObjBOL_1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlCategory, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartsDetail, ds.Tables[1]);
                Utility.BindDropDownList(ddlPartNo, ds.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableProjectpartsDropdowns()
    {
        try
        {
            ddlCategory.Enabled = false;
            ddlPartNo.Enabled = false;
            ddlPartsDetail.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableProjectpartsDropdowns()
    {
        try
        {
            ddlCategory.Enabled = true;
            ddlPartNo.Enabled = true;
            ddlPartsDetail.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationCheck_Projectparts()
    {
        try
        {
            if (txtSearchPNum.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter job !");
                txtSearchPNum.Focus();
                return false;
            }

            if (ddlPartsDetail.SelectedIndex == 0 || ddlPartNo.SelectedIndex == 0)
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck_Projectparts())
            {
                if (HfProjectPartID.Value == "-1")
                {
                    ObjBOL_1.Operation = 7;
                    ObjBOL_1.PartID = Int32.Parse(ddlPartsDetail.SelectedValue);
                    ObjBOL_1.JobID = txtSearchPNum.Text.Split(',')[0];
                }
                else
                {
                    ObjBOL_1.Operation = 8;
                    ObjBOL_1.PartID = Int32.Parse(HfProjectPartID.Value);
                }

                ObjBOL_1.Qty = Int32.Parse(txtQty.Text);
                string returnStatus = ObjBLL_1.Return_String(ObjBOL_1);
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

    private void btnClear_Click_Event()
    {
        try
        {
            EnableProjectpartsDropdowns();
            ddlCategory.SelectedIndex = 0;
            ddlCategory_SelectedIndexChanged_Event();
            ddlPartsDetail.SelectedIndex = 0;
            ddlPartNo.SelectedIndex = 0;
            txtQty.Text = string.Empty;
            HfProjectPartID.Value = "-1";
            btnAdd.Text = "Save";
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

    private void BindGrid()
    {
        try
        {
            ObjBOL_1.Operation = 2;
            ObjBOL_1.JobID = txtJobId.Text;
            DataSet ds = new DataSet();
            ds = ObjBLL_1.Return_DataSet(ObjBOL_1);
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

    protected void gvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (btnRelease.Enabled)
            {
                int ID = Convert.ToInt32(gvDetail.DataKeys[e.RowIndex].Values[0]);
                ObjBOL_1.Operation = 9;
                ObjBOL_1.PartID = ID;
                string returnStatus = ObjBLL_1.Return_String(ObjBOL_1);
                if (returnStatus != "")
                {
                    Utility.MaintainLogsSpecial("FrmITWProjectParts", "Delete", txtSearchPNum.Text.Split(',')[0]);
                    Utility.ShowMessage_Success(Page, "Record deleted sucessfully !!");
                    btnClear_Click_Event();
                    ClearGrid();
                    BindGrid();
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Project is already released !");
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
            if (btnRelease.Enabled)
            {
                DisableProjectpartsDropdowns();
                DataSet ds = new DataSet();
                int ID = Convert.ToInt32(gvDetail.DataKeys[e.NewEditIndex].Values[0]);
                HfProjectPartID.Value = ID.ToString();
                ObjBOL_1.Operation = 3;
                ObjBOL_1.PartID = ID;
                ds = ObjBLL_1.Return_DataSet(ObjBOL_1);
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
                        ddlPartNo.SelectedValue = row["PartID"].ToString();
                    }

                    txtQty.Text = row["Qty"].ToString();
                    btnAdd.Text = "Update";
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Project is already released !");
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
            ObjBOL_1.Operation = 5;
            ObjBOL_1.CategoryID = Int32.Parse(ddlCategory.SelectedValue);
            DataSet ds = new DataSet();
            ds = ObjBLL_1.Return_DataSet(ObjBOL_1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartsDetail, ds.Tables[0]);
                Utility.BindDropDownList(ddlPartNo, ds.Tables[0]);
            }
            else
            {
                ddlPartsDetail.Items.Clear();
                ddlPartNo.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCategory_SelectedIndexChanged_Event();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        btnClear_Click_Event();
    }

    private void DisableProjectParts()
    {
        try
        {
            ddlCategory.Enabled = false;
            ddlPartsDetail.Enabled = false;
            ddlPartNo.Enabled = false;
            txtQty.Enabled = false;
            btnAdd.Enabled = false;
            btnClear.Enabled = false;
            gvDetail.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableProjectParts()
    {
        try
        {
            ddlCategory.Enabled = true;
            ddlPartsDetail.Enabled = true;
            ddlPartNo.Enabled = true;
            txtQty.Enabled = true;
            btnAdd.Enabled = true;
            btnClear.Enabled = true;
            gvDetail.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPartNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPartNo.SelectedIndex > 0)
            {
                ddlPartsDetail.SelectedValue = ddlPartNo.SelectedValue;
            }
            else
            {
                ddlPartsDetail.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPartsDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPartsDetail.SelectedIndex > 0)
            {
                ddlPartNo.SelectedValue = ddlPartsDetail.SelectedValue;
            }
            else
            {
                ddlPartNo.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}