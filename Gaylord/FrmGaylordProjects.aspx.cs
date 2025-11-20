using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Gaylord_FrmGaylordProjects : System.Web.UI.Page
{
    BOLGaylordProjects ObjBOL = new BOLGaylordProjects();
    BLLGaylordProjects ObjBLL = new BLLGaylordProjects();
    ReportDocument rprt = new ReportDocument();
    commonclass1 cls = new commonclass1();
    string formName = "FrmGaylordProjects.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindControls();
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
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;

            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListWithoutFiller(ddlPOType, ds.Tables[0]);
                ddlPOType.SelectedValue = "1";
                ddlPOType_SelectedIndexChanged();
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProductCodeLookup, ds.Tables[1]);
                ddlProductCodeLookup.SelectedValue = "3";
                ddlProductCodeLookup_SelectedIndexChanged();
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlModeOfShipment_Part, ds.Tables[2]);
                Utility.BindDropDownList(ddlModeOfShipment_Shipment, ds.Tables[2]);
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownListWithoutFiller(ddlItemType, ds.Tables[3]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindLayoutBy()
    {
        try
        {
            ObjBOL.Operation = 24;
            ObjBOL.Id = Int32.Parse(ddlPOType.SelectedValue);
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlLayoutBy, ds.Tables[0]);
            }
            else
            {
                ddlLayoutBy.Items.Clear();
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
            if (txtPONumber.Text.Trim() == "" && txtProjectName.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter either PO # or Project Name !! ");
                txtPONumber.Focus();
                return false;
            }

            if (txtPOReceivedDate.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter PO Received Date !! ");
                txtPOReceivedDate.Focus();
                return false;
            }

            if (txtShipDate.Text == "" && ddlPOType.SelectedValue == "1")
            {
                Utility.ShowMessage_Error(Page, "Please enter confirmed Ship Date !");
                txtShipDate.Focus();
                return false;
            }

            //if (ddlPOType.SelectedIndex == 0)
            //{
            //    Utility.ShowMessage_Error(Page, "Please select PO Type !! ");
            //    ddlPOType.Focus();
            //    return false;
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void SearchPNameButton_Click(object sender, EventArgs e)
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

    protected void SearchJNumberButton_Click(object sender, EventArgs e)
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
            ObjBOL.Operation = 6;
            if (lookupSelector.ToUpper() == "NAME")
            {
                ObjBOL.ProjectName = txtSearchPName.Text.Split(',')[0];
            }
            else if (lookupSelector.ToUpper() == "NUMBER")
            {
                ObjBOL.PONumber = txtSearchPNum.Text.Split(',')[0];
            }

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = ObjBLL.Return_DataSet(ObjBOL);
            dt = ds.Tables[0];
            int count = dt.Rows.Count;
            if (count > 0)
            {
                txtSearchPNum.Text = dt.Rows[0]["PONumber"].ToString();
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

    private void DisableProjectParts()
    {
        try
        {
            ddlWorkOrder.Enabled = false;
            ddlProductCodeLookup.Enabled = false;
            ddlPartsDetail.Enabled = false;
            ddlPartNo.Enabled = false;
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
            ddlWorkOrder.Enabled = false;
            ddlProductCodeLookup.Enabled = true;
            ddlPartsDetail.Enabled = true;
            ddlPartNo.Enabled = true;
            txtQty.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FetchInfo(DataSet ds)
    {
        try
        {
            DataTable dt = ds.Tables[0];
            Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
            {
                { "Id", d => HfPOId.Value = d["Id"].ToString() },
                { "PONumber", d => txtPONumber.Text = d["PONumber"].ToString() },
                { "ProjectName", d => txtProjectName.Text = d["ProjectName"].ToString() },
                { "DrawingReceivedDate", d => txtDrawingReceivedDate.Text = d["DrawingReceivedDate"].ToString() },
                { "POReceivedDate", d => txtPOReceivedDate.Text = d["POReceivedDate"].ToString() },
                { "ReqShipDate", d => txtReqShipDate.Text = d["ReqShipDate"].ToString() },
                { "ShipDate", d => txtShipDate.Text = d["ShipDate"].ToString() },
                { "TargetCompletionDate", d => txtTargetCompletionDate.Text = d["TargetCompletionDate"].ToString() },
                { "ShippingLocation", d => txtShippingLocation.Text = d["ShippingLocation"].ToString() },
                { "POType", d =>
                    {
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
            BindPartGrid();
            BindWorkOrderDropdown();
            btnSave.Text = "Update";
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
        try
        {
            if (ValidationCheck())
            {
                string op = "save";
                string message = "Record inserted successfully !!";
                ObjBOL.Operation = 4;
                if (btnSave.Text.ToLower() == "update")
                {
                    ObjBOL.Operation = 5;
                    ObjBOL.Id = Int32.Parse(HfPOId.Value);
                    message = "Record updated successfully !!";
                    op = "update";
                }

                ObjBOL.PONumber = txtPONumber.Text;
                ObjBOL.ProjectName = txtProjectName.Text;
                ObjBOL.DrawingReceivedDate = Utility.ConvertDate(txtDrawingReceivedDate.Text);
                ObjBOL.POReceivedDate = Utility.ConvertDate(txtPOReceivedDate.Text);
                ObjBOL.ReqShipDate = Utility.ConvertDate(txtReqShipDate.Text);
                ObjBOL.ShipDate = Utility.ConvertDate(txtShipDate.Text);
                ObjBOL.ReleaseToFab = Utility.ConvertDate(txtReleaseToFab.Text);
                ObjBOL.TargetCompletionDate = Utility.ConvertDate(txtTargetCompletionDate.Text);
                ObjBOL.ShippingLocation = txtShippingLocation.Text;
                ObjBOL.POType = Int32.Parse(ddlPOType.SelectedValue);

                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "PO already exists !!");
                    return;
                }

                if (returnStatus.Trim() == "ER02")
                {
                    Utility.ShowMessage_Error(Page, "Project Name already exists !!");
                    return;
                }

                if (returnStatus.Trim() == "S" || returnStatus.Trim() == "S01" || returnStatus.Trim() == "S02")
                {
                    if (returnStatus.Trim() == "S01")
                    {
                        op += " POType";
                        Utility.ShowMessage_Success(Page, "PO Type changed. All existing parts and shipments deleted !!");
                    }

                    if (returnStatus.Trim() == "S02")
                    {
                        Utility.ShowMessage_Error(Page, "Project/Shipment released cannot change PO Type. Rest of the changes are saved !!");
                    }
                    Utility.MaintainLogsSpecial(formName, op, txtPONumber.Text);
                    Utility.ShowMessage_Success(Page, message);
                    AfterSaveOrUpdateSequence();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void AfterSaveOrUpdateSequence()
    {
        try
        {
            ObjBOL.Operation = 7;
            ObjBOL.PONumber = txtPONumber.Text;
            ObjBOL.ProjectName = txtProjectName.Text;
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

    private void DisableButtons()
    {
        try
        {
            //btnRelease.Enabled = false;
            //btnRollback.Enabled = false;
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

    private void btnCancel_Click()
    {
        try
        {
            HfPOId.Value = "-1";
            txtSearchPName.Text = string.Empty;
            txtSearchPNum.Text = string.Empty;
            txtPONumber.Text = string.Empty;
            txtProjectName.Text = string.Empty;
            txtDrawingReceivedDate.Text = string.Empty;
            txtPOReceivedDate.Text = string.Empty;
            txtReqShipDate.Text = string.Empty;
            txtShipDate.Text = string.Empty;
            txtTargetCompletionDate.Text = string.Empty;
            ddlPOType.SelectedValue = "1";
            ddlPOType_SelectedIndexChanged();
            txtShippingLocation.Text = string.Empty;
            ddlWorkOrder.Items.Clear();
            DisableButtons();
            ClearGrid();
            btnClear_Click();
            btnCancelWorkOrder_Click();
            btnCancelShipmentDetail_Click();
            btnSave.Text = "Save";
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
                lblWorkOrder.Attributes["class"] = "text-danger";
                lblWorkOrder.InnerText = "Work Order*";
                ddlModeOfShipment_Part.Enabled = true;
                btnOpenWO.Enabled = true;
            }
            else
            {
                lblConfirmedShipDate.Attributes["class"] = "";
                lblConfirmedShipDate.InnerText = "Confirmed Ship Date";
                lblWorkOrder.Attributes["class"] = "";
                lblWorkOrder.InnerText = "Work Order";
                btnOpenWO.Enabled = false;
                ddlModeOfShipment_Part.Enabled = false;
                DisableButtons();
            }
            BindLayoutBy();
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
            if (HfPOId.Value == "-1")
            {
                Utility.ShowMessage_Error(Page, "Please select PO !");
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

    private void BindPartGrid()
    {
        try
        {
            ObjBOL.Operation = 16;
            ObjBOL.Id = Int32.Parse(HfPOId.Value);
            DataSet ds = new DataSet();
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvPartDetail.DataSource = ds.Tables[0];
                gvPartDetail.DataBind();
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

    private bool ValidationCheck_ProjectParts()
    {
        try
        {
            if (txtSearchPNum.Text.Trim() == "" && txtSearchPName.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please select PO !");
                txtSearchPNum.Focus();
                return false;
            }

            if (ddlPOType.SelectedValue == "1" && (ddlWorkOrder.SelectedIndex == 0 || ddlWorkOrder.Items.Count == 0))
            {
                Utility.ShowMessage_Error(Page, "Please select Work Order !");
                ddlWorkOrder.Focus();
                return false;
            }

            if ((ddlPartsDetail.SelectedIndex == 0 || ddlPartNo.SelectedIndex == 0) && ddlItemType.SelectedValue == "1")
            {
                Utility.ShowMessage_Error(Page, "Please select part !");
                ddlPartsDetail.Focus();
                return false;
            }

            if (txtPartNo.Text.Trim() == "" && ddlItemType.SelectedValue == "2")
            {
                Utility.ShowMessage_Error(Page, "Please enter Part !");
                txtPartNo.Focus();
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
                    ObjBOL.Operation = 14;//SAVE
                    ObjBOL.PartId = Int32.Parse(ddlPartNo.SelectedValue);
                }
                else
                {
                    ObjBOL.Operation = 15;//UPDATE
                    ObjBOL.ProjectPartId = Int32.Parse(HfProjectPartId.Value);
                    op = "update-part";
                    message = "Record updated successfully !!";
                }

                ObjBOL.Id = Int32.Parse(HfPOId.Value);
                if (ddlWorkOrder.SelectedIndex > 0)
                {
                    ObjBOL.WorkOrderId = Int32.Parse(ddlWorkOrder.SelectedValue);
                }

                ObjBOL.Comments = txtComments.Text;
                ObjBOL.Qty = Int32.Parse(txtQty.Text);

                if (ddlModeOfShipment_Part.SelectedIndex > 0)
                {
                    ObjBOL.ModeOfShipment = Int32.Parse(ddlModeOfShipment_Part.SelectedValue);
                }

                ObjBOL.ItemType = Int32.Parse(ddlItemType.SelectedValue);
                ObjBOL.PartNo = txtPartNo.Text;
                ObjBOL.PartDescription = txtPartDescription.Text;
                ObjBOL.ReleaseToFab = Utility.ConvertDate(txtReleaseToFab.Text);
                if (ddlLayoutBy.Items.Count > 0)
                {
                    ObjBOL.LayoutBy = Int32.Parse(ddlLayoutBy.SelectedValue);
                }

                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "Project already released !!");
                    return;
                }

                if (returnStatus.Trim() == "ER02")
                {
                    Utility.ShowMessage_Error(Page, "Part already exists !!");
                    return;
                }

                if (returnStatus.Trim() != "")
                {
                    Utility.ShowMessage_Success(Page, message);
                    Utility.MaintainLogsSpecial(formName, op, returnStatus.Trim());
                    btnClear_Click();
                    ClearGrid();
                    BindPartGrid();
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
        btnClear_Click();
    }

    private void btnClear_Click()
    {
        try
        {
            EnableProjectPartsDropdowns();
            if (ddlWorkOrder.Items.Count > 0)
            {
                ddlWorkOrder.SelectedIndex = 0;
            }

            if (ddlProductCodeLookup.Items.Count > 0)
            {
                ddlProductCodeLookup.SelectedIndex = 0;
                ddlProductCodeLookup_SelectedIndexChanged();
            }

            if (ddlModeOfShipment_Part.Items.Count > 0)
            {
                ddlModeOfShipment_Part.SelectedIndex = 0;
            }

            txtPartNo.Text = string.Empty;
            txtPartDescription.Text = string.Empty;

            if (ddlItemType.Items.Count > 0)
            {
                ddlItemType.SelectedIndex = 0;
                ddlItemType_SelectedIndexChanged();
            }

            if (ddlLayoutBy.Items.Count > 0)
            {
                ddlLayoutBy.SelectedIndex = 0;
            }

            txtUM.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtComments.Text = string.Empty;
            txtReleaseToFab.Text = string.Empty;
            HfProjectPartId.Value = "-1";
            btnAdd.Text = "Add Part";
            btnSave.Enabled = true;
            if (ddlPOType.SelectedValue == "1")
            {
                btnOpenWO.Enabled = true;
            }
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
            gvPartDetail.DataSource = string.Empty;
            gvPartDetail.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlProductCodeLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlProductCodeLookup_SelectedIndexChanged();
    }

    private void ddlProductCodeLookup_SelectedIndexChanged()
    {
        try
        {
            ObjBOL.Operation = 13;

            if (ddlProductCodeLookup.SelectedIndex > 0)
            {
                ObjBOL.LoginUserID = Int32.Parse(ddlProductCodeLookup.SelectedValue);
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

    protected void ddlPartNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPartNo.SelectedIndex > 0)
            {
                ddlPartsDetail.SelectedValue = ddlPartNo.SelectedValue;
                GetUM(ddlPartsDetail.SelectedValue);
            }
            else
            {
                ddlPartsDetail.SelectedIndex = 0;
                txtUM.Text = string.Empty;
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
                GetUM(ddlPartsDetail.SelectedValue);
            }
            else
            {
                ddlPartNo.SelectedIndex = 0;
                txtUM.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetUM(string PartID)
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

    protected void btnOpenWO_Click(object sender, EventArgs e)
    {
        btnOpenWO_Click();
    }

    protected void btnOpenWO_Click()
    {
        try
        {
            btnCancelWorkOrder_Click();
            if (HfPOId.Value != "-1")
            {
                GetWorkOrders();
                ModalWorkOrderDetails.Show();
                lblPOHeadingForWorkOrder.Text = txtPONumber.Text;
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Please select PO !!");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable FetchWorkOrdersData()
    {
        DataTable dt = new DataTable();
        try
        {
            ObjBOL.Operation = 8;
            ObjBOL.Id = int.Parse(HfPOId.Value);
            dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void BindWorkOrderGrid()
    {
        try
        {
            DataTable dt = FetchWorkOrdersData();

            if (dt.Rows.Count > 0)
            {
                gvWorkOrder.DataSource = dt;
                gvWorkOrder.DataBind();
            }
            else
            {
                gvWorkOrder.DataSource = string.Empty;
                gvWorkOrder.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindWorkOrderDropdown()
    {
        try
        {
            DataTable dt = FetchWorkOrdersData();

            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlWorkOrder, dt);
            }
            else
            {
                ddlWorkOrder.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetWorkOrders()
    {
        try
        {
            BindWorkOrderGrid();
            BindWorkOrderDropdown();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSaveWorkOrder_Click(object sender, EventArgs e)
    {
        btnSaveWorkOrder_Click();
    }

    private void btnSaveWorkOrder_Click()
    {
        try
        {
            ModalWorkOrderDetails.Show();
            if (txtWorkOrder.Text.Trim() != "")
            {
                string op = "save-WO";
                string message = "Record inserted successfully !!";
                ObjBOL.Operation = 9;
                if (btnSaveWorkOrder.Text.ToLower() == "update" && HfWorkOrderId.Value != "-1")
                {
                    op = "update-WO";
                    message = "Record updated successfully !!";
                    ObjBOL.Operation = 12;
                    ObjBOL.PartId = Int32.Parse(HfWorkOrderId.Value);
                }

                ObjBOL.WorkOrder = txtWorkOrder.Text;
                ObjBOL.Id = Int32.Parse(HfPOId.Value);
                string returnStatus = ObjBLL.Return_String(ObjBOL);
                if (returnStatus.Trim() == "ER01")
                {
                    Utility.ShowMessage_Error(Page, "Work Order already exists !!");
                    return;
                }

                if (returnStatus.Trim() == "ER02")
                {
                    Utility.ShowMessage_Error(Page, "Project already Released !!");
                    return;
                }

                if (returnStatus.Trim() == "S")
                {
                    Utility.ShowMessage_Success(Page, message);
                    Utility.MaintainLogsSpecial(formName, op, HfWorkOrderId.Value + " / " + txtWorkOrder.Text);
                    btnCancelWorkOrder_Click();
                    GetWorkOrders();
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancelWorkOrder_Click(object sender, EventArgs e)
    {
        ModalWorkOrderDetails.Show();
        btnCancelWorkOrder_Click();
    }

    private void btnCancelWorkOrder_Click()
    {
        try
        {
            HfWorkOrderId.Value = "-1";
            txtWorkOrder.Text = string.Empty;
            btnSaveWorkOrder.Text = "Add";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvWorkOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            ModalWorkOrderDetails.Show();
            int ID = Convert.ToInt32(gvWorkOrder.DataKeys[e.RowIndex].Values[0]);
            ObjBOL.Operation = 10;
            ObjBOL.Id = Int32.Parse(HfPOId.Value);
            ObjBOL.PartId = ID;
            string returnStatus = ObjBLL.Return_String(ObjBOL);
            if (returnStatus.Trim() == "ER01")
            {
                Utility.ShowMessage_Error(Page, "Work Order already has Parts. Cannot be deleted !!");
                return;
            }

            if (returnStatus.Trim() == "ER02")
            {
                Utility.ShowMessage_Error(Page, "Project already released !");
                return;
            }

            if (returnStatus.Trim() == "S")
            {
                Utility.ShowMessage_Success(Page, "Work Order deleted successfully !!");
                Utility.MaintainLogsSpecial(formName, "Del-WO", txtPONumber.Text);
                btnCancelWorkOrder_Click();
                GetWorkOrders();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvWorkOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            ModalWorkOrderDetails.Show();
            int id = Convert.ToInt32(gvWorkOrder.DataKeys[e.NewEditIndex].Value);

            ObjBOL.Operation = 11;
            ObjBOL.Id = id;
            HfWorkOrderId.Value = id.ToString();

            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                txtWorkOrder.Text = row["WorkOrder"].ToString();
                btnSaveWorkOrder.Text = "Update";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableProjectPartsDropdowns()
    {
        try
        {
            ddlWorkOrder.Enabled = true;
            ddlProductCodeLookup.Enabled = true;
            ddlPartNo.Enabled = true;
            ddlPartsDetail.Enabled = true;
            ddlItemType.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableProjectPartsDropdowns()
    {
        try
        {
            ddlWorkOrder.Enabled = false;
            ddlProductCodeLookup.Enabled = false;
            ddlPartNo.Enabled = false;
            ddlPartsDetail.Enabled = false;
            ddlItemType.Enabled = false;
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
            btnOpenWO.Enabled = false;
            DisableProjectPartsDropdowns();
            ddlProductCodeLookup.SelectedIndex = 0;
            ddlProductCodeLookup_SelectedIndexChanged();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvPartDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            //if (btnRelease.Enabled)
            //{
            BeforeEditPart();
            DataSet ds = new DataSet();
            int ID = Convert.ToInt32(gvPartDetail.DataKeys[e.NewEditIndex].Values[0]);
            HfProjectPartId.Value = ID.ToString();
            ObjBOL.Operation = 17;
            ObjBOL.ProjectPartId = ID;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                if (ddlWorkOrder.Items.FindByValue(row["WorkOrderId"].ToString()) != null)
                {
                    ddlWorkOrder.SelectedValue = row["WorkOrderId"].ToString();
                }
                else
                {
                    if (ddlWorkOrder.Items.Count > 0)
                    {
                        ddlWorkOrder.SelectedIndex = 0;
                    }
                }

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

                if (ddlModeOfShipment_Part.Items.FindByValue(row["ModeOfShipment"].ToString()) != null)
                {
                    ddlModeOfShipment_Part.SelectedValue = row["ModeOfShipment"].ToString();
                }
                else
                {
                    if (ddlModeOfShipment_Part.Items.Count > 0)
                    {
                        ddlModeOfShipment_Part.SelectedIndex = 0;
                    }
                }

                if (ddlItemType.Items.FindByValue(row["ItemType"].ToString()) != null)
                {
                    ddlItemType.SelectedValue = row["ItemType"].ToString();
                    ddlItemType_SelectedIndexChanged();
                }
                else
                {
                    if (ddlItemType.Items.Count > 0)
                    {
                        ddlItemType.SelectedIndex = 0;
                        ddlItemType_SelectedIndexChanged();
                    }
                }

                txtPartNo.Text = row["PartNo"].ToString();
                txtPartDescription.Text = row["PartDescription"].ToString();
                if (ddlLayoutBy.Items.FindByValue(row["LayoutBy"].ToString()) != null)
                {
                    ddlLayoutBy.SelectedValue = row["LayoutBy"].ToString();
                }
                else
                {
                    if (ddlLayoutBy.Items.Count > 0)
                    {
                        ddlLayoutBy.SelectedIndex = 0;
                    }
                }

                txtUM.Text = row["UM"].ToString();
                txtComments.Text = row["Comments"].ToString();
                txtQty.Text = row["Qty"].ToString();
                txtReleaseToFab.Text = row["ReleaseToFab"].ToString();
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

    protected void gvPartDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ShipmentGrid")
            {
                if (ddlPOType.SelectedValue != "1")
                {
                    btnCancelShipmentDetail_Click();
                    ModalShipmentDetails.Show();
                    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;

                    int id = Convert.ToInt32(gvPartDetail.DataKeys[rowIndex].Values[0]);
                    HfProjectPartId.Value = id.ToString();
                    Label lblPartNo = (Label)gvr.FindControl("lblPartNo");
                    string label = string.Empty;
                    label = txtPONumber.Text;
                    lblOrderAndPartNo.Text = label + " / " + lblPartNo.Text;

                    txtOrderQty.Text = ((Label)gvr.FindControl("lblQty")).Text;

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

    private void GetShipmentHistory()
    {
        try
        {
            ObjBOL.Operation = 20;
            ObjBOL.ProjectPartId = Int32.Parse(HfProjectPartId.Value);
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
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvPartDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //if (btnRelease.Enabled)
            //{
            int ID = Convert.ToInt32(gvPartDetail.DataKeys[e.RowIndex].Values[0]);
            ObjBOL.Operation = 18;
            ObjBOL.ProjectPartId = ID;
            ObjBOL.Id = Int32.Parse(HfPOId.Value);
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
                Utility.MaintainLogsSpecial(formName, "Delete", HfPOId.Value);
                Utility.ShowMessage_Success(Page, "Record deleted sucessfully !!");
                btnClear_Click();
                ClearGrid();
                BindPartGrid();
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

    protected void gvPartDetail_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void gvShipmentHistory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            ModalShipmentDetails.Show();
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
                txtUPSTrackingNo.Text = row["UPSTrackingNo"].ToString();
                txtRequestedReceiveDate.Text = row["RequestedReceiveDate"].ToString();
                if (ddlModeOfShipment_Shipment.Items.FindByValue(row["ModeOfShipment"].ToString()) != null)
                {
                    ddlModeOfShipment_Shipment.SelectedValue = row["ModeOfShipment"].ToString();
                }
                else
                {
                    if (ddlModeOfShipment_Shipment.Items.Count > 0)
                    {
                        ddlModeOfShipment_Shipment.SelectedIndex = 0;
                    }
                }
                btnAddShipmentDetail.Text = "Update Ship Qty";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvShipmentHistory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            ModalShipmentDetails.Show();
            string Id = Convert.ToString(gvShipmentHistory.DataKeys[e.RowIndex].Value);
            ObjBOL.Operation = 21;
            ObjBOL.Id = Int32.Parse(Id);
            string returnStatus = ObjBLL.Return_String(ObjBOL);
            if (returnStatus.Trim() == "ER01")
            {
                Utility.ShowMessage_Error(Page, "Shipment already released !!");
                return;
            }

            if (returnStatus.Trim() == "S")
            {
                Utility.MaintainLogsSpecial(formName, "Del-Ship", HfProjectPartId.Value);
                Utility.ShowMessage_Success(Page, "Record deleted successfully !!");
                GetShipmentHistory();
                BindPartGrid();
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
            ModalShipmentDetails.Show();
            if (ValidationCheckShipment())
            {
                string op = "save-ship";
                string message = "Record inserted successfully !!";
                ObjBOL.Operation = 19;
                if (HfShipmentId.Value != "-1")
                {
                    op = "update-ship";
                    message = "Record updated successfully !!";
                    ObjBOL.Operation = 23;
                    ObjBOL.Id = Int32.Parse(HfShipmentId.Value);
                }
                ObjBOL.ProjectPartId = Int32.Parse(HfProjectPartId.Value);
                ObjBOL.ShipQty = Int32.Parse(txtShipQty.Text);
                ObjBOL.ShipDate = Utility.ConvertDate(txtShipmentShipDate.Text);
                ObjBOL.Comments = txtShipmentComments.Text;
                ObjBOL.UPSTracking = txtUPSTrackingNo.Text;
                ObjBOL.LoginUserID = Utility.GetCurrentUser();
                ObjBOL.ReqShipDate = Utility.ConvertDate(txtRequestedReceiveDate.Text);
                if (ddlModeOfShipment_Shipment.SelectedIndex > 0)
                {
                    ObjBOL.ModeOfShipment = Int32.Parse(ddlModeOfShipment_Shipment.SelectedValue);
                }
                string returnStatus = ObjBLL.Return_String(ObjBOL);

                if (returnStatus.Trim() == "ER02")
                {
                    Utility.ShowMessage_Error(Page, "Shipment already released !!");
                    return;
                }

                if (returnStatus.Trim() != "")
                {
                    Utility.MaintainLogsSpecial(formName, op, returnStatus.Trim());
                    Utility.ShowMessage_Success(Page, message);
                    GetShipmentHistory();
                    BindPartGrid();
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
            if (ddlModeOfShipment_Shipment.Items.Count > 0)
            {
                ddlModeOfShipment_Shipment.SelectedIndex = 0;
            }
            txtShipmentShipDate.Text = DateTime.Now.ToShortDateString();
            txtShipQty.Text = string.Empty;
            txtShipmentComments.Text = string.Empty;
            HfShipmentId.Value = "-1";
            txtRequestedReceiveDate.Text = string.Empty;
            txtUPSTrackingNo.Text = string.Empty;
            btnAddShipmentDetail.Text = "Add Ship Qty";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlItemType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlItemType_SelectedIndexChanged();
    }

    private void ddlItemType_SelectedIndexChanged()
    {
        try
        {
            if (ddlItemType.SelectedValue == "1")
            {
                dvItemType_Stock.Visible = true;
                dvItemType_NonStock.Visible = false;
            }
            else
            {
                dvItemType_Stock.Visible = false;
                dvItemType_NonStock.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        try
        {
            btnClear_Click();
            btnCancelShipmentDetail_Click();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}