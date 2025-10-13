using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

public partial class TurboWash_FrmITWProjects_V1 : System.Web.UI.Page
{
    BOLManageITWProjects ObjBOL = new BOLManageITWProjects();
    BLLManageITWProjects ObjBLL = new BLLManageITWProjects();
    ReportDocument rprt = new ReportDocument();
    commonclass1 cls = new commonclass1();
    string formName = "FrmITWProjects_V1.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlWarehouse.SelectedValue = "4";
            ReleaseRollbackPermissions();
            BindControls();
            LoadParts(false);
        }
    }

    private string PermissionStatus()
    {
        string permission = string.Empty;
        try
        {
            if (Utility.IsAuthorized())
            {
                ObjBOL.Operation = 24;
                ObjBOL.LoginUserID = Utility.GetCurrentUser();
                permission = ObjBLL.Return_String(ObjBOL);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return permission;
    }

    private void ReleaseRollbackPermissions()
    {
        try
        {
            if (Utility.IsAuthorized())
            {
                string returnStatus = PermissionStatus();
                if (returnStatus.Trim() == "S")
                {
                    btnRelease.Visible = true;
                    btnRollback.Visible = true;
                }
                else
                {
                    btnRelease.Visible = false;
                    btnRollback.Visible = false;
                }
            }
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
            ObjBOL.Operation = 3;
            DataSet ds = new DataSet();
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCompany, ds.Tables[0]);
                Utility.BindDropDownList(ddlCompanyLookupList, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListWithoutFiller(ddlPOType, ds.Tables[1]);
                ddlPOType.SelectedValue = "1";
                ddlPOType_SelectedIndexChanged();
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProductCodeLookup, ds.Tables[2]);
                ddlProductCodeLookup.SelectedValue = "2";
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlWarehouse, ds.Tables[3]);
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
            if (txtRefId.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please create Ref Id!");
                txtRefId.Focus();
                return false;
            }

            if (ddlCompany.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Company !");
                ddlCompany.Focus();
                return false;
            }

            if (txtJobId.Text == "" && txtPONumber.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Atleast JobID or PO# !");
                ddlCompany.Focus();
                return false;
            }

            if (txtPOReceivedDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter PO Received Date !");
                txtPOReceivedDate.Focus();
                return false;
            }

            if (txtShipDate.Text == "" && ddlPOType.SelectedValue == "1")
            {
                Utility.ShowMessage_Error(Page, "Please enter confirmed Ship Date !");
                txtShipDate.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void txtSearchPName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtSearchPName.Text != "")
            {
                SyncLookups("NAME");
            }
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
            if (txtSearchPNum.Text != "")
            {
                SyncLookups("NUMBER");
            }
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
            ObjBOL.Operation = 7;
            if (lookupSelector.ToUpper() == "NAME")
            {
                ObjBOL.ProjectName = txtSearchPName.Text.Split(',')[0];
            }
            else if (lookupSelector.ToUpper() == "NUMBER")
            {
                ObjBOL.JobID = txtSearchPNum.Text.Split(',')[0];
            }

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = ObjBLL.Return_DataSet(ObjBOL);
            dt = ds.Tables[0];
            int count = dt.Rows.Count;
            if (count > 0)
            {
                if (dt.Rows[0]["JobID"].ToString() != "")
                {
                    txtSearchPNum.Text = dt.Rows[0]["JobID"].ToString();
                }
                else
                {
                    txtSearchPNum.Text = dt.Rows[0]["PONumber"].ToString();
                }
                txtSearchPName.Text = dt.Rows[0]["ProjectName"].ToString();
                FetchInfo(ds);
                return true;
            }
            else
            {
                btnCancel_Click();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return false;
    }

    private void FetchInfo(DataSet ds)
    {
        try
        {
            DataTable dt = ds.Tables[0];
            Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
            {
                { "CompanyId", d =>
                    {
                       if(ddlCompany.Items.FindByValue(d["CompanyId"].ToString()) != null)
                        {
                            ddlCompany.SelectedValue = d["CompanyId"].ToString();
                            LoadParts(false);
                        }
                        else
                        {
                            if(ddlCompany.Items.Count > 0)
                            {
                                ddlCompany.SelectedIndex = 0;
                            }
                        }
                    }
                },
                { "RefId", d => txtRefId.Text = d["RefId"].ToString() },
                { "JobID", d => txtJobId.Text = d["JobID"].ToString() },
                { "PONumber", d => txtPONumber.Text = d["PONumber"].ToString() },
                { "HobartDrawingNumber", d => txtHobartDrawingNumber.Text = d["HobartDrawingNumber"].ToString() },
                { "HobartDrawingRevisionNo", d => txtHobartDrawingRevisionNo.Text = d["HobartDrawingRevisionNo"].ToString() },
                { "CI", d => txtCINumber.Text = d["CI"].ToString() },
                { "ProjectName", d => txtProjectName.Text = d["ProjectName"].ToString() },
                { "POReceivedDate", d => txtPOReceivedDate.Text = d["POReceivedDate"].ToString() },
                { "ReqShipDate", d => txtReqShipDate.Text = d["ReqShipDate"].ToString() },
                { "ShipDate", d => txtShipDate.Text = d["ShipDate"].ToString() },
                { "EqPrice", d => txtEqPrice.Text = Convert.ToDecimal(d["EqPrice"]).ToString("N") },
                { "DrawingReleaseDate", d => txtDrawingReleaseDate.Text = d["DrawingReleaseDate"].ToString() },
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
                },
                { "POType", d =>
                    {
                       //ddlPOType.Enabled = false;
                       if(ddlPOType.Items.FindByValue(d["POType"].ToString()) != null)
                        {
                            ddlPOType.SelectedValue = d["POType"].ToString();
                            ddlPOType_SelectedIndexChanged();
                        }
                        else
                        {
                            if(ddlPOType.Items.Count > 0)
                            {
                                ddlPOType.SelectedIndex = 0;
                            }
                        }
                    }
                },
                { "NestingStatusId", d =>
                    {
                       if(ddlNestingStatus.Items.FindByValue(d["NestingStatusId"].ToString()) != null)
                        {
                            ddlNestingStatus.SelectedValue = d["NestingStatusId"].ToString();
                        }
                        else
                        {
                            if(ddlNestingStatus.Items.Count > 0)
                            {
                                ddlNestingStatus.SelectedIndex = 0;
                            }
                        }
                    }
                },
                { "NestingStartDate", d => txtNestingStartDate.Text = d["NestingStartDate"].ToString() },
                { "NestingEndDate", d => txtNestingEndDate.Text = d["NestingEndDate"].ToString() },
                { "SentDate", d => txtSentDate.Text = d["SentDate"].ToString() },
                { "SentToProduction", d => chkSendToProduction.Checked = bool.Parse(d["SentToProduction"].ToString()) },
                { "WarehouseId", d =>
                    {
                       if(ddlWarehouse.Items.FindByValue(d["WarehouseId"].ToString()) != null)
                        {
                            ddlWarehouse.SelectedValue = d["WarehouseId"].ToString();
                        }
                        else
                        {
                            if(ddlWarehouse.Items.Count > 0)
                            {
                                ddlWarehouse.SelectedIndex = 0;
                            }
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
            btnClear_Click();
            BindGrid();
            btnSave.Text = "Update";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableProjectParts()
    {
        try
        {
            ddlProductCodeLookup.Enabled = false;
            ddlPartsDetail.Enabled = false;
            ddlPartNo.Enabled = false;
            ddlWarehouse.Enabled = false;
            txtQty.Enabled = false;
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
            ddlProductCodeLookup.Enabled = true;
            ddlPartsDetail.Enabled = true;
            ddlPartNo.Enabled = true;
            ddlWarehouse.Enabled = true;
            txtQty.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
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
                    //txtSearchPNum.Text = txtSearchPName.Text;
                }
                else if (lookupSelector.ToUpper() == "NUMBER")
                {
                    //txtSearchPName.Text = txtSearchPNum.Text;
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
        btnCancel_Click();
    }

    protected void btnCancel_Click()
    {
        try
        {
            txtSearchPName.Text = string.Empty;
            txtSearchPNum.Text = string.Empty;
            txtRefId.Text = string.Empty;
            txtJobId.Text = string.Empty;
            txtProjectName.Text = string.Empty;
            txtHobartDrawingNumber.Text = string.Empty;
            txtHobartDrawingRevisionNo.Text = string.Empty;
            txtPONumber.Text = string.Empty;
            txtPOReceivedDate.Text = string.Empty;
            txtReqShipDate.Text = string.Empty;
            txtShipDate.Text = string.Empty;
            txtEqPrice.Text = string.Empty;
            txtNestingStartDate.Text = string.Empty;
            txtNestingEndDate.Text = string.Empty;
            txtSentDate.Text = string.Empty;
            ddlNestingStatus.SelectedIndex = 0;
            chkSendToProduction.Checked = false;
            txtDrawingReleaseDate.Text = string.Empty;
            txtCINumber.Text = string.Empty;
            chkSendToProduction.Checked = false;

            if (ddlCompany.Items.Count > 0)
            {
                ddlCompany.SelectedIndex = 0;
            }

            if (ddlPOType.Items.Count > 0)
            {
                ddlPOType.Enabled = true;
                ddlPOType.SelectedValue = "1";
                ddlPOType_SelectedIndexChanged();
            }

            if (ddlWarehouse.Items.Count > 0)
            {
                ddlWarehouse.SelectedValue = "4";
                ddlWarehouse.Enabled = true;
            }

            btnCancelShipmentDetail_Click();
            DisableButtons();
            btnClear_Click();
            ClearGrid();
            btnSave.Text = "Save";
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave_Click();
    }

    private void btnSave_Click()
    {
        if (ValidationCheck())
        {
            string op = "save";
            string message = "Record inserted successfully !!";
            ObjBOL.Operation = 5;
            if (btnSave.Text.ToLower() == "update")
            {
                ObjBOL.Operation = 6;
                message = "Record updated successfully !!";
                op = "update";
            }

            ObjBOL.RefId = txtRefId.Text;

            if (ddlCompany.SelectedIndex > 0)
            {
                ObjBOL.Company = Int32.Parse(ddlCompany.SelectedValue);
            }

            ObjBOL.JobID = txtJobId.Text;
            ObjBOL.ProjectName = txtProjectName.Text;
            ObjBOL.HobartDrawingNumber = txtHobartDrawingNumber.Text;
            ObjBOL.HobartDrawingRevisionNo = txtHobartDrawingRevisionNo.Text;
            ObjBOL.PONumber = txtPONumber.Text;
            ObjBOL.POType = Int32.Parse(ddlPOType.SelectedValue);
            ObjBOL.POReceivedDate = Utility.ConvertDate(txtPOReceivedDate.Text);
            ObjBOL.ReqShipDate = Utility.ConvertDate(txtReqShipDate.Text);
            ObjBOL.ShipDate = Utility.ConvertDate(txtShipDate.Text);
            ObjBOL.NestingStartDate = Utility.ConvertDate(txtNestingStartDate.Text);
            ObjBOL.NestingEndDate = Utility.ConvertDate(txtNestingEndDate.Text);
            ObjBOL.SentDate = Utility.ConvertDate(txtSentDate.Text);
            if (ddlNestingStatus.SelectedIndex > 0)
            {
                ObjBOL.NestingStatusId = Int32.Parse(ddlNestingStatus.SelectedValue);
            }

            if (ddlWarehouse.SelectedIndex > 0)
            {
                ObjBOL.WarehouseId = Int32.Parse(ddlWarehouse.SelectedValue);
            }
            ObjBOL.SendToProduction = chkSendToProduction.Checked;

            if (txtEqPrice.Text.Trim() != "")
            {
                ObjBOL.EqPrice = decimal.Parse(txtEqPrice.Text);
            }

            ObjBOL.DrawingReleaseDate = Utility.ConvertDate(txtDrawingReleaseDate.Text);
            ObjBOL.CI = txtCINumber.Text;

            string returnStatus = ObjBLL.Return_String(ObjBOL);

            if (returnStatus.Trim() == "ER01")
            {
                Utility.ShowMessage_Error(Page, "Ref Id already exists !!");
                return;
            }

            if (returnStatus.Trim() == "ER02")
            {
                Utility.ShowMessage_Error(Page, "Ref Id doesnot exists !!");
                return;
            }

            if (returnStatus.Trim() == "ER03")
            {
                Utility.ShowMessage_Error(Page, "JobId already exists !!");
                return;
            }

            if (returnStatus.Trim() == "ER04")
            {
                Utility.ShowMessage_Error(Page, "PO already exists !!");
                return;
            }

            if (returnStatus.Trim() == "S" || returnStatus.Trim() == "S01" || returnStatus.Trim() == "S02")
            {
                if (returnStatus.Trim() == "S01")
                {
                    op += " POType";
                    Utility.ShowMessage_Success(Page, "PO changed. All existing parts and shipments deleted !!");
                }

                if (returnStatus.Trim() == "S02")
                {
                    Utility.ShowMessage_Error(Page, "Project/Shipment released cannot change PO Type. Rest of the changes are saved !!");
                }
                Utility.MaintainLogsSpecial(formName, op, txtRefId.Text);
                Utility.ShowMessage_Success(Page, message);
                AfterSaveOrUpdateSequence();
            }
        }
    }

    private void AfterSaveOrUpdateSequence()
    {
        try
        {
            ObjBOL.Operation = 19;
            ObjBOL.RefId = txtRefId.Text;
            DataTable dt = new DataTable();
            dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
            btnCancel_Click();
            txtSearchPNum.Text = dt.Rows[0]["ProjectName"].ToString();
            SyncLookups("NUMBER");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            ObjBOL.Operation = 4;
            string returnStatus = ObjBLL.Return_String(ObjBOL);
            if (returnStatus.Trim() != "")
            {
                btnCancel_Click();
                txtRefId.Text = returnStatus.Trim();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPOType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (btnSave.Text.ToLower() == "update")
        {
            Utility.ShowMessage_Error(Page, "Changing PO will delete all old parts and shipments !!");
        }
        ddlPOType_SelectedIndexChanged();
    }

    private void ddlPOType_SelectedIndexChanged()
    {
        try
        {
            if (ddlPOType.SelectedValue == "1")
            {
                lblConfirmedShipDate.Attributes["class"] = "text-danger";
                lblConfirmedShipDate.InnerText = "Confirmed Ship Date*";
            }
            else
            {
                lblConfirmedShipDate.Attributes["class"] = "";
                lblConfirmedShipDate.InnerText = "Confirmed Ship Date";
                DisableButtons();
            }
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
            ObjBOL.Operation = 9;
            ObjBOL.RefId = txtRefId.Text;
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

    private void EnableProjectpartsDropdowns()
    {
        try
        {
            ddlProductCodeLookup.Enabled = true;
            ddlPartNo.Enabled = true;
            ddlPartsDetail.Enabled = true;
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
            ddlProductCodeLookup.Enabled = false;
            ddlPartNo.Enabled = false;
            ddlPartsDetail.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        btnClear_Click();
    }

    private void btnClear_Click()
    {
        try
        {
            EnableProjectpartsDropdowns();
            if (ddlPartsDetail.Items.Count > 0)
            {
                ddlPartsDetail.SelectedIndex = 0;
            }

            if (ddlPartNo.Items.Count > 0)
            {
                ddlPartNo.SelectedIndex = 0;
            }

            txtUM.Text = String.Empty;
            txtComments.Text = String.Empty;
            txtQty.Text = string.Empty;
            HfProjectPartId.Value = "-1";

            if (ddlProductCodeLookup.Items.Count > 0)
            {
                ddlProductCodeLookup.SelectedValue = "2";
                if (ddlCompanyLookupList.Items.Count > 0)
                {
                    ddlCompanyLookupList.SelectedIndex = 0;
                }
                LoadParts(false);
            }

            btnSave.Enabled = true;
            btnAdd.Text = "Add Part";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationCheck_ProjectParts()
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
            if (ValidationCheck_ProjectParts())
            {
                string op = "save-part";
                string message = "Record inserted successfully !!";
                if (HfProjectPartId.Value == "-1")
                {
                    ObjBOL.Operation = 10;//SAVE
                    ObjBOL.PartId = Int32.Parse(ddlPartNo.SelectedValue);
                }
                else
                {
                    ObjBOL.Operation = 11;//UPDATE
                    ObjBOL.Id = Int32.Parse(HfProjectPartId.Value);
                    op = "update-part";
                    message = "Record updated successfully !!";
                }

                ObjBOL.RefId = txtRefId.Text;
                if (ddlCompany.SelectedIndex > 0)
                {
                    ObjBOL.Company = Int32.Parse(ddlCompany.SelectedValue);
                }

                ObjBOL.Comments = txtComments.Text;
                ObjBOL.Qty = Int32.Parse(txtQty.Text);

                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "Project already released !!");
                    return;
                }

                if (returnStatus.Trim() != "")
                {
                    Utility.ShowMessage_Success(Page, message);
                    Utility.MaintainLogsSpecial(formName, op, txtRefId.Text + " [" + returnStatus.Trim() + "]");
                    btnClear_Click();
                    ClearGrid();
                    BindGrid();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindUM(string PartID)
    {
        try
        {
            DataTable dt = (DataTable)ViewState["Parts"];
            if (dt.Rows.Count > 0)
            {
                var filteredRows = dt.AsEnumerable()
                          .Where(row => row.Field<int>("id") == Convert.ToInt32(PartID)).ToList();
                if (filteredRows.Count > 0)
                {
                    txtUM.Text = filteredRows[0][3].ToString();
                }
                else
                {
                    txtUM.Text = String.Empty;
                }
            }
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
                BindUM(ddlPartsDetail.SelectedValue);
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
                BindUM(ddlPartsDetail.SelectedValue);
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

    protected void gvDetail_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ShipmentGrid")
            {
                if (ddlPOType.SelectedValue != "1")
                {
                    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;

                    int id = Convert.ToInt32(gvDetail.DataKeys[rowIndex].Values[0]);

                    //if (((Label)gvr.FindControl("lblShipmentStatus")).Text == "Close")
                    //{
                    //    Utility.ShowMessage_Error(Page, "Shipment Status is closed !!");
                    //    return;
                    //}
                    Label lblPartNo = (Label)gvr.FindControl("lblPartNo");
                    string label = string.Empty;
                    if (txtPONumber.Text.Trim() == "")
                    {
                        label = txtJobId.Text;
                    }
                    else
                    {
                        label = txtPONumber.Text;
                    }
                    lblOrderAndPartNo.Text = label + " / " + lblPartNo.Text;

                    txtOrderQty.Text = ((Label)gvr.FindControl("lblQty")).Text;
                    btnCancelShipmentDetail_Click();
                    HfProjectPartId.Value = id.ToString();

                    GetShipmentHistory();
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "Regular PO Type doesnot support Shipments !");
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BeforeEditPart()
    {
        try
        {
            btnSave.Enabled = false;
            DisableProjectpartsDropdowns();
            ddlProductCodeLookup.SelectedIndex = 0;
            LoadParts(true);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDetail_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            //if (btnRelease.Enabled)
            //{
            BeforeEditPart();
            DataSet ds = new DataSet();
            int ID = Convert.ToInt32(gvDetail.DataKeys[e.NewEditIndex].Values[0]);
            HfProjectPartId.Value = ID.ToString();
            ObjBOL.Operation = 12;
            ObjBOL.PartId = ID;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                if (ddlPartsDetail.Items.FindByValue(row["PartID"].ToString()) != null)
                {
                    ddlPartsDetail.SelectedValue = row["PartID"].ToString();
                    ddlPartNo.SelectedValue = row["PartID"].ToString();
                }
                else
                {
                    ddlPartsDetail.SelectedIndex = 0;
                    ddlPartNo.SelectedIndex = 0;
                }

                txtUM.Text = row["UM"].ToString();
                txtComments.Text = row["Comments"].ToString();
                txtQty.Text = row["Qty"].ToString();
                //txtRequestedReceiveDate.Text = row["RequestedReceiveDate"].ToString();
                btnAdd.Text = "Update Part";
            }
            //}
            //else
            //{
            //    Utility.ShowMessage_Error(Page, "Project is already released !");
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDetail_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        try
        {
            //if (btnRelease.Enabled)
            //{
            int ID = Convert.ToInt32(gvDetail.DataKeys[e.RowIndex].Values[0]);
            ObjBOL.Operation = 13;
            ObjBOL.PartId = ID;
            string returnStatus = ObjBLL.Return_String(ObjBOL);
            if (returnStatus.Trim() == "ER01")
            {
                Utility.ShowMessage_Error(Page, "Part already has shipments. Cannot be deleted !!");
                return;
            }

            if (returnStatus.Trim() == "ER02")
            {
                Utility.ShowMessage_Error(Page, "Project already released !");
                return;
            }

            if (returnStatus.Trim() == "S")
            {
                Utility.MaintainLogsSpecial(formName, "Delete", txtRefId.Text);
                Utility.ShowMessage_Success(Page, "Record deleted sucessfully !!");
                btnClear_Click();
                ClearGrid();
                BindGrid();
            }
            //}
            //else
            //{
            //    Utility.ShowMessage_Error(Page, "Project is already released !");
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDetail_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPendingQty = (Label)e.Row.FindControl("lblPendingQty");

                if (Convert.ToInt32(lblPendingQty.Text) < 0)
                {
                    lblPendingQty.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCompanyLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadParts(false);
    }

    protected void ddlProductCodeLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadParts(false);
    }

    private void LoadParts(bool loadAll)
    {
        try
        {
            ObjBOL.Operation = 8;

            if (!loadAll)
            {
                if (ddlCompanyLookupList.SelectedIndex > 0)
                {
                    ObjBOL.Company = Int32.Parse(ddlCompanyLookupList.SelectedValue);
                }

                if (ddlProductCodeLookup.SelectedIndex > 0)
                {
                    ObjBOL.LoginUserID = Int32.Parse(ddlProductCodeLookup.SelectedValue);
                }
            }
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartNo, ds.Tables[0]);
                Utility.BindDropDownList(ddlPartsDetail, ds.Tables[0]);
                ddlPartNo.SelectedIndex = 0;
                ddlPartsDetail.SelectedIndex = 0;
                ViewState["Parts"] = ds.Tables[0];
            }
            else
            {
                ddlPartNo.Items.Clear();
                ddlPartsDetail.Items.Clear();
                ViewState["Parts"] = null;
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool ValidationCheckShipment()
    {
        try
        {
            ModalShipmentDetails.Show();
            if (txtShipQty.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Ship Qty !!");
                txtShipQty.Focus();
                return false;
            }

            if (txtShipmentShipDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Ship Date !!");
                txtShipmentShipDate.Focus();
                return false;
            }

            if (txtShipmentComments.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter Comments !!");
                txtShipmentComments.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnAddShipmentDetail_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheckShipment())
            {
                string op = "save-ship";
                string message = "Record inserted successfully !!";
                ObjBOL.Operation = 14;
                if (HfShipmentId.Value != "-1")
                {
                    op = "update-ship";
                    message = "Record updated successfully !!";
                    ObjBOL.Operation = 23;
                    ObjBOL.PartId = Int32.Parse(HfShipmentId.Value);
                }
                ObjBOL.Id = Int32.Parse(HfProjectPartId.Value);
                ObjBOL.ShipQty = Int32.Parse(txtShipQty.Text);
                ObjBOL.ShipDate = Utility.ConvertDate(txtShipmentShipDate.Text);
                ObjBOL.Comments = txtShipmentComments.Text;
                ObjBOL.LoginUserID = Utility.GetCurrentUser();
                ObjBOL.ReqShipDate = Utility.ConvertDate(txtRequestedReceiveDate.Text);
                string returnStatus = ObjBLL.Return_String(ObjBOL);

                if (returnStatus.Trim() == "ER02")
                {
                    Utility.ShowMessage_Error(Page, "Shipment already released !!");
                    return;
                }

                if (returnStatus.Trim() == "S")
                {
                    Utility.MaintainLogsSpecial(formName, op, HfProjectPartId.Value);
                    Utility.ShowMessage_Success(Page, message);
                    GetShipmentHistory();
                    BindGrid();
                    ModalShipmentDetails.Show();
                    btnCancelShipmentDetail_Click();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancelShipmentDetail_Click(object sender, EventArgs e)
    {
        ModalShipmentDetails.Show();
        btnCancelShipmentDetail_Click();
    }

    private void btnCancelShipmentDetail_Click()
    {
        try
        {
            txtShipmentShipDate.Text = DateTime.Now.ToShortDateString();
            txtShipQty.Text = string.Empty;
            txtShipmentComments.Text = string.Empty;
            HfShipmentId.Value = "-1";
            txtRequestedReceiveDate.Text = string.Empty;
            btnAddShipmentDetail.Text = "Add Ship Qty";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShipmentHistory_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        try
        {
            string Id = Convert.ToString(gvShipmentHistory.DataKeys[e.RowIndex].Value);
            ObjBOL.Operation = 16;
            ObjBOL.Id = Int32.Parse(Id);
            string returnStatus = ObjBLL.Return_String(ObjBOL);
            if (returnStatus.Trim() == "ER01")
            {
                Utility.ShowMessage_Error(Page, "Shipment already released !!");
                ModalShipmentDetails.Show();
                return;
            }

            if (returnStatus.Trim() == "S")
            {
                Utility.MaintainLogsSpecial(formName, "Del-Ship", HfProjectPartId.Value);
                Utility.ShowMessage_Success(Page, "Record deleted successfully !!");
                GetShipmentHistory();
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShipmentHistory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            ModalShipmentDetails.Show();
            string permissions = PermissionStatus();
            if (e.CommandName == "Release")
            {
                if (permissions.Trim() == "S")
                {
                    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;

                    string selectedIds = gvShipmentHistory.DataKeys[rowIndex].Values[0].ToString();

                    if (Utility.IsAuthorized())
                    {
                        ObjBOL.Operation = 20;
                        ObjBOL.Comments = selectedIds;
                        ObjBOL.RefId = txtRefId.Text;
                        ObjBOL.LoginUserID = Utility.GetCurrentUser();
                        ObjBOL.Id = Int32.Parse(HfProjectPartId.Value);
                        string returnStatus = ObjBLL.Return_String(ObjBOL);
                        if (returnStatus.Trim() == "ER01")
                        {
                            Utility.ShowMessage_Error(Page, "Database error occured !!");
                            return;
                        }

                        if (returnStatus.Trim() == "ER02")
                        {
                            Utility.ShowMessage_Error(Page, "Shipment already released !!");
                            return;
                        }

                        if (returnStatus.Trim() == "ER03")
                        {
                            Utility.ShowMessage_Error(Page, "Warehouse not selected !!");
                            return;
                        }

                        if (returnStatus.Trim() == "S")
                        {
                            Utility.MaintainLogsSpecial(formName, "Release", selectedIds);
                            Utility.ShowMessage_Success(Page, "Shipments Released Successfully !!");
                            GetShipmentHistory();
                        }
                    }
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "You are not authorized !!");
                }
            }
            else if (e.CommandName == "Rollback")
            {
                if (permissions.Trim() == "S")
                {
                    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;

                    string selectedIds = gvShipmentHistory.DataKeys[rowIndex].Values[0].ToString();

                    if (Utility.IsAuthorized())
                    {
                        ObjBOL.Operation = 21;
                        ObjBOL.Comments = selectedIds;
                        ObjBOL.RefId = txtRefId.Text;
                        ObjBOL.LoginUserID = Utility.GetCurrentUser();
                        ObjBOL.Id = Int32.Parse(HfProjectPartId.Value);
                        string returnStatus = ObjBLL.Return_String(ObjBOL);
                        if (returnStatus.Trim() == "ER01")
                        {
                            Utility.ShowMessage_Error(Page, "Database error occured !!");
                            return;
                        }

                        if (returnStatus.Trim() == "ER02")
                        {
                            Utility.ShowMessage_Error(Page, "Shipment is not released yet !!");
                            return;
                        }

                        if (returnStatus.Trim() == "ER03")
                        {
                            Utility.ShowMessage_Error(Page, "Warehouse not selected !!");
                            return;
                        }

                        if (returnStatus.Trim() == "S")
                        {
                            Utility.MaintainLogsSpecial(formName, "Rollback", selectedIds);
                            Utility.ShowMessage_Success(Page, "Shipments Rollbacked Successfully !!");
                            GetShipmentHistory();
                        }
                    }
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "You are not authorized !!");
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetShipmentHistory()
    {
        try
        {
            ObjBOL.Operation = 15;
            ObjBOL.Id = Int32.Parse(HfProjectPartId.Value);
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvShipmentHistory.DataSource = ds.Tables[0];
                gvShipmentHistory.DataBind();
            }
            else
            {
                gvShipmentHistory.DataSource = string.Empty;
                gvShipmentHistory.DataBind();
            }
            ModalShipmentDetails.Show();
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

    private bool ValidationCheck_Release()
    {
        try
        {
            if (txtRefId.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please select project !");
                return false;
            }

            if (ddlPOType.SelectedValue != "1")
            {
                Utility.ShowMessage_Error(Page, "PO Type doesnot support Project Release !");
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnRelease_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck_Release())
            {
                ObjBOL.Operation = 17;
                ObjBOL.RefId = txtRefId.Text;
                ObjBOL.LoginUserID = Utility.GetCurrentUser();
                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "Warehouse not selected !!");
                    return;
                }

                if (returnStatus.Trim() == "S")
                {
                    Utility.MaintainLogsSpecial(formName, "Release", txtRefId.Text);
                    Utility.ShowMessage_Success(Page, "Project Released !!");
                    btnRelease.Enabled = false;
                    btnRollback.Enabled = true;
                    DisableProjectParts();
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
            if (ValidationCheck_Release())
            {
                ObjBOL.Operation = 18;
                ObjBOL.RefId = txtRefId.Text;
                ObjBOL.LoginUserID = Utility.GetCurrentUser();
                string returnStatus = ObjBLL.Return_String(ObjBOL);

                if (returnStatus.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "Warehouse not selected !!");
                    return;
                }

                if (returnStatus.Trim() == "S")
                {
                    Utility.MaintainLogsSpecial(formName, "Rollback", txtRefId.Text);
                    Utility.ShowMessage_Success(Page, "Project Rollbacked !!");
                    btnRelease.Enabled = true;
                    btnRollback.Enabled = false;
                    EnableProjectParts();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            cls.Return_DT(dt, "EXEC Get_ITWProjects_V1_Report 1, '" + txtRefId.Text + "' ");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnPreviewReport_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtRefId.Text.Trim() != "")
            {
                DataTable dt = ReportData();
                rprt.Load(Server.MapPath("~/TurboWash/rptITWProjects_V1.rpt"));
                if (dt.Rows.Count > 0)
                {
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = txtSearchPNum.Text + " - " + DateTime.Now.ToString("dddd, dd MMMM yyyy").Replace(',', ' ');
                    rprt.SetDataSource(dt);
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
                else
                {
                    rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                    TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                    txtheader.Text = txtSearchPNum.Text + " - " + DateTime.Now.ToString("dddd, dd MMMM yyyy").Replace(',', ' ');
                    rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please Select Job !");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }

    protected void btnReleasePart_Click(object sender, EventArgs e)
    {
        try
        {
            ModalShipmentDetails.Show();
            List<string> ids = new List<string>();

            foreach (GridViewRow row in gvShipmentHistory.Rows)
            {
                CheckBox chk = row.FindControl("chkRelease") as CheckBox;
                if (chk != null && chk.Enabled && chk.Checked)
                {
                    string id = gvShipmentHistory.DataKeys[row.RowIndex].Value.ToString();
                    ids.Add(id);
                }
            }

            if (ids.Count == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select atleast one shipment to release");
                return;
            }

            string selectedIds = string.Join(",", ids.ToArray());

            if (Utility.IsAuthorized())
            {
                ObjBOL.Operation = 20;
                ObjBOL.Comments = selectedIds;
                ObjBOL.RefId = txtRefId.Text;
                ObjBOL.LoginUserID = Utility.GetCurrentUser();
                ObjBOL.Id = Int32.Parse(HfProjectPartId.Value);
                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "Database error occured !!");
                    return;
                }

                if (returnStatus.Trim() == "S")
                {
                    Utility.MaintainLogsSpecial(formName, "Release", selectedIds);
                    Utility.ShowMessage_Success(Page, "Shipments Released Successfully !!");
                    GetShipmentHistory();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShipmentHistory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            int ID = Convert.ToInt32(gvShipmentHistory.DataKeys[e.NewEditIndex].Values[0]);
            HfShipmentId.Value = ID.ToString();
            ObjBOL.Operation = 22;
            ObjBOL.Id = ID;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                txtShipQty.Text = row["ShipQty"].ToString();
                txtShipmentShipDate.Text = row["ShipDate"].ToString();
                txtShipmentComments.Text = row["Comments"].ToString();
                txtRequestedReceiveDate.Text = row["RequestedReceiveDate"].ToString();
                btnAddShipmentDetail.Text = "Update Ship Qty";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnClose_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        ModalShipmentDetails.Hide();
        HfProjectPartId.Value = "-1";
        btnCancelShipmentDetail_Click();
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/TurboWash/FrmITWProjectsReport_V1.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}