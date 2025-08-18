using BLLAERO;
using BOLAERO;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class SalesManagement_FrmSiteVisitInformation : System.Web.UI.Page
{
    BOLSiteVisitInformation ObjBOL = new BOLSiteVisitInformation();
    BLLSiteVisitInformation ObjBLL = new BLLSiteVisitInformation();
    string formName = "FrmSiteVisitInformation";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindControl();
                siteVisits.Visible = false;
                chkSameAsProjectLocation.Enabled = false;
                if (Request.QueryString["pNumber"] != null)
                {
                    HfPNumber.Value = Request.QueryString["pNumber"].Trim();
                    GetPName();
                    ddlPNumberLookupList_SelectedIndexChanged_Event();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindControl()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.Return_DataSet(ObjBOL);

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCountry, ds.Tables[2]);
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindListBoxList(ddlEmployee, ds.Tables[3]);
            }

            //if (ds.Tables[5].Rows.Count > 0)
            //{
            //    Utility.BindDropDownList(ddlRegion, ds.Tables[5]);
            //}

            if (ds.Tables[6].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRequestor, ds.Tables[6]);
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
            //bool check = false;

            //if (ddlPLookupList.SelectedIndex == 0)
            //{
            //    Utility.ShowMessage_Error(Page, "Please Select P# !");
            //    ddlPLookupList.Focus();
            //    return false;
            //}

            if (txtSearchPName.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Select P# !");
                txtSearchPName.Focus();
                return false;
            }

            //foreach (ListItem item in ddlEmployee.Items)
            //{
            //    if (item.Selected == true)
            //    {
            //        check = true;
            //    }
            //}

            //if (!check)
            //{
            //    Utility.ShowMessage_Error(Page, "Please Select atleast 1 Employee !");
            //    return false;
            //}

            if (ddlRequestor.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Requestor !");
                ddlRequestor.Focus();
                return false;
            }

            if (ddlPurpose.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Purpose !");
                ddlPurpose.Focus();
                return false;
            }

            //if (ddlRegion.SelectedIndex == 0)
            //{
            //    Utility.ShowMessage_Error(Page, "Please Select Region !");
            //    ddlRegion.Focus();
            //    return false;
            //}            

            //if (txtSiteAddress.Text.Trim() == "")
            //{
            //    Utility.ShowMessage_Error(Page, "Please Enter Site Address !");
            //    txtSiteAddress.Focus();
            //    return false;
            //}

            //if (ddlCountry.SelectedIndex == 0)
            //{
            //    Utility.ShowMessage_Error(Page, "Please Select Country !");
            //    ddlCountry.Focus();
            //    return false;
            //}

            //if (ddlState.SelectedIndex == 0)
            //{
            //    Utility.ShowMessage_Error(Page, "Please Select State !");
            //    ddlState.Focus();
            //    return false;
            //}

            //if (txtCity.Text.Trim() == "")
            //{
            //    Utility.ShowMessage_Error(Page, "Please Enter City !");
            //    txtCity.Focus();
            //    return false;
            //}

            if (txtSiteVisitDate.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Site Visit Date !");
                txtSiteVisitDate.Focus();
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
        ddlPNumberLookupList_SelectedIndexChanged_Event();
    }

    protected void txtSearchJName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CheckForValidProject();
            if (txtSearchJName.Text.Trim() != "")
            {
                ResetInfoAndDetail();
                syncLookupChanges("J");
                ddlPNumberLookupList_SelectedIndexChanged_Event();
            }
            else
            {
                btnCancel_Click_Event();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckForValidProject()
    {
        try
        {
            ObjBOL.Operation = 13;
            ObjBOL.EmployeeIDs = txtSearchJName.Text.Trim();
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count == 0)
            {
                txtSearchJName.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCountry_SelectedIndexChanged_Event();
    }

    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlRegion.SelectedIndex > 0)
            {
                ObjBOL.Operation = 6;
                ObjBOL.RegionID = Int32.Parse(ddlRegion.SelectedValue);
                string returnValue = ObjBLL.Return_String(ObjBOL);
                if (returnValue.Trim() != "")
                {
                    ddlCountry.SelectedValue = returnValue;
                    ddlCountry_SelectedIndexChanged_Event();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void chkSameAsProjectLocation_CheckedChanged(object sender, EventArgs e)
    {
        chkSameAsProjectLocation_CheckedChanged_Event();
    }

    protected void gvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int ID = Convert.ToInt32(gvDetail.DataKeys[e.RowIndex].Values[0]);
            ObjBOL.Operation = 8;
            ObjBOL.ID = ID;
            string return_msg = ObjBLL.Return_String(ObjBOL);
            if (return_msg != "")
            {
                Utility.MaintainLogsSpecial(formName, "Delete", HfPNumber.Value);
                Utility.ShowMessage_Success(Page, "Visit deleted successfully !!");
                var PNumber = HfPNumber.Value;
                btnCancel_Click_Event();
                HfPNumber.Value = PNumber;
                GetPName();
                ddlPNumberLookupList_SelectedIndexChanged_Event();
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
            LoadSiteDetails(gvDetail.DataKeys[e.NewEditIndex].Values[0].ToString());
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave_Click_Event();
    }

    protected void btnFilterForm_Click(object sender, EventArgs e)
    {
        btnFilterForm_Click_Event();
    }

    private void chkSameAsProjectLocation_CheckedChanged_Event()
    {
        try
        {
            if (chkSameAsProjectLocation.Checked)
            {
                GetSiteAddress();
                DisableSiteLocationSegment();
            }
            else
            {
                EnableSiteLocationSegment();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetSiteAddress()
    {
        try
        {
            DataTable dt = new DataTable();
            ObjBOL.Operation = 9;
            ObjBOL.PNumber = HfPNumber.Value;
            dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
            txtSiteAddress.Text = dt.Rows[0]["SiteAddress"].ToString();
            if (ddlCountry.Items.FindByValue(dt.Rows[0]["CountryID"].ToString()) != null)
            {
                ddlCountry.SelectedValue = dt.Rows[0]["CountryID"].ToString();
                ddlCountry_SelectedIndexChanged_Event();
                if (ddlState.Items.FindByValue(dt.Rows[0]["StateID"].ToString()) != null)
                {
                    ddlState.SelectedValue = dt.Rows[0]["StateID"].ToString();
                }
            }
            txtCity.Text = dt.Rows[0]["City"].ToString();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void syncLookupChanges(string forPorJ)
    {
        try
        {
            if (forPorJ == "P")
            {
                if (txtSearchPName.Text != "")
                {
                    ObjBOL.Operation = 10;
                    ObjBOL.PNumber = HfPNumber.Value;
                    DataSet ds = new DataSet();
                    ds = ObjBLL.Return_DataSet(ObjBOL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string JobName = ds.Tables[0].Rows[0]["JobName"].ToString();
                        if (JobName.Trim() != "")
                        {
                            txtSearchJName.Text = JobName.Trim();
                        }
                    }
                    else
                    {
                        txtSearchJName.Text = string.Empty;
                    }
                }
            }
            else if (forPorJ == "J")
            {
                if (txtSearchJName.Text != "")
                {
                    ObjBOL.Operation = 11;
                    ObjBOL.PNumber = txtSearchJName.Text.Split(',')[0];
                    DataSet ds = new DataSet();
                    ds = ObjBLL.Return_DataSet(ObjBOL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string PName = ds.Tables[0].Rows[0]["PName"].ToString();
                        if (PName.Trim() != "")
                        {
                            txtSearchPName.Text = PName.Trim();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlPNumberLookupList_SelectedIndexChanged_Event()
    {
        try
        {
            CheckForValidProposal();
            if (txtSearchPName.Text.Trim() != "")
            {
                HfPNumber.Value = txtSearchPName.Text.Split(',')[0];
                ResetInfoAndDetail();
                syncLookupChanges("P");
                chkSameAsProjectLocation.Enabled = true;
                BindGrid();
            }
            else
            {
                btnCancel_Click_Event();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }        
    }

    private void CheckForValidProposal()
    {
        try
        {
            ObjBOL.Operation = 12;
            ObjBOL.EmployeeIDs = txtSearchPName.Text.Trim();
            DataSet ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count == 0)
            {
                txtSearchPName.Text = string.Empty;
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
            DataSet ds = new DataSet();
            ObjBOL.Operation = 7;
            ObjBOL.PNumber = HfPNumber.Value;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetail.DataSource = ds.Tables[0];
                gvDetail.DataBind();
                siteVisits.Visible = true;
            }
            else
            {
                ResetGrid();
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                txtAddress_ProjectLocation.Text = ds.Tables[1].Rows[0]["SiteAddress"].ToString();
                txtCountry_ProjectLocation.Text = ds.Tables[1].Rows[0]["Country"].ToString();
                txtState_ProjectLocation.Text = ds.Tables[1].Rows[0]["State"].ToString();
                if (ddlCountry.Items.FindByValue(ds.Tables[1].Rows[0]["CountryID"].ToString()) != null)
                {
                    ddlCountry.SelectedValue = ds.Tables[1].Rows[0]["CountryID"].ToString();
                    ddlCountry_SelectedIndexChanged_Event();
                    if (ddlState.Items.FindByValue(ds.Tables[1].Rows[0]["StateID"].ToString()) != null)
                    {
                        ddlState.SelectedValue = ds.Tables[1].Rows[0]["StateID"].ToString();
                    }
                }
                txtCity_ProjectLocation.Text = ds.Tables[1].Rows[0]["City"].ToString();
                txtCity.Text = ds.Tables[1].Rows[0]["City"].ToString();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void LoadSiteDetails(string ID)
    {
        try
        {
            ResetInfoAndDetail();
            if (HfPNumber.Value != "-1")
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ObjBOL.Operation = 3;
                ObjBOL.ID = Int32.Parse(ID);
                ds = ObjBLL.Return_DataSet(ObjBOL);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    hfID.Value = row["ID"].ToString();

                    if (ddlRequestor.Items.FindByValue(row["RequestorID"].ToString()) != null)
                    {
                        ddlRequestor.SelectedValue = row["RequestorID"].ToString();
                    }

                    if (ddlPurpose.Items.FindByValue(row["PurposeID"].ToString()) != null)
                    {
                        ddlPurpose.SelectedValue = row["PurposeID"].ToString();
                    }

                    //if (ddlRegion.Items.FindByValue(row["RegionID"].ToString()) != null)
                    //{
                    //    ddlRegion.SelectedValue = row["RegionID"].ToString();
                    //}

                    txtSiteAddress.Text = row["SiteAddress"].ToString();
                    if (ddlCountry.Items.FindByValue(row["CountryID"].ToString()) != null)
                    {
                        ddlCountry.SelectedValue = row["CountryID"].ToString();
                        ddlCountry_SelectedIndexChanged_Event();

                        if (ddlState.Items.Count > 0 && ddlState.Items.FindByValue(row["StateID"].ToString()) != null)
                        {
                            ddlState.SelectedValue = row["StateID"].ToString();
                        }
                    }

                    txtCity.Text = row["City"].ToString();
                    txtSiteVisitDate.Text = row["SiteVisitDate"].ToString();
                    txtNextVisitDate.Text = row["NextVisitDate"].ToString();
                    txtSiteContactName.Text = row["SiteContactName"].ToString();
                    txtSiteContactNumber.Text = row["SiteContactNumber"].ToString();
                    txtRemarks.Text = row["Remarks"].ToString();
                    chkSameAsProjectLocation.Checked = bool.Parse(row["SameAsProjectLocation"].ToString());
                    chkSameAsProjectLocation_CheckedChanged_Event();

                    string employeeIDs = row["EmployeeIDs"].ToString();

                    if (!string.IsNullOrEmpty(employeeIDs))
                    {
                        string[] ids = employeeIDs.Split(',');

                        foreach (string id in ids)
                        {
                            ListItem item = ddlEmployee.Items.FindByValue(id);
                            if (item != null)
                            {
                                item.Selected = true;
                            }
                        }
                    }
                    else
                    {
                        ResetEmployee();
                    }
                    btnSave.Text = "Update Visit";
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtAddress_ProjectLocation.Text = ds.Tables[1].Rows[0]["SiteAddress"].ToString();
                    txtCountry_ProjectLocation.Text = ds.Tables[1].Rows[0]["Country"].ToString();
                    txtState_ProjectLocation.Text = ds.Tables[1].Rows[0]["State"].ToString();
                    txtCity_ProjectLocation.Text = ds.Tables[1].Rows[0]["City"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlCountry_SelectedIndexChanged_Event()
    {
        try
        {
            ddlState.Items.Clear();
            if (ddlCountry.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 2;
                ObjBOL.CountryID = Int32.Parse(ddlCountry.SelectedValue);
                ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlState, ds.Tables[0]);
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
            txtSearchJName.Text = string.Empty;
            HfPNumber.Value = "-1";
            chkSameAsProjectLocation.Enabled = false;
            ResetInfoAndDetail();
            ResetGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnSave_Click_Event()
    {
        try
        {
            if (ValidationCheck())
            {
                ObjBOL.Operation = 4;
                int id = 0;
                if (Int32.TryParse(hfID.Value, out id))
                {

                }
                ObjBOL.ID = id;
                if (HfPNumber.Value != "")
                {
                    ObjBOL.PNumber = HfPNumber.Value;
                }
                if (ddlRequestor.SelectedIndex > 0)
                {
                    ObjBOL.RequestorID = Int32.Parse(ddlRequestor.SelectedValue);
                }
                if (ddlPurpose.SelectedIndex > 0)
                {
                    ObjBOL.PurposeID = Int32.Parse(ddlPurpose.SelectedValue);
                }

                //if (ddlRegion.SelectedIndex > 0)
                //{
                //    ObjBOL.RegionID = Int32.Parse(ddlRegion.SelectedValue);
                //}

                if (ddlCountry.SelectedIndex > 0)
                {
                    ObjBOL.CountryID = Int32.Parse(ddlCountry.SelectedValue);
                }

                if (ddlState.SelectedIndex > 0)
                {
                    ObjBOL.StateID = Int32.Parse(ddlState.SelectedValue);
                }

                ObjBOL.SiteAddress = txtSiteAddress.Text;
                ObjBOL.City = txtCity.Text;
                if (txtSiteVisitDate.Text != "")
                {
                    ObjBOL.SiteVisitDate = Utility.ConvertDate(txtSiteVisitDate.Text);
                }

                if (txtNextVisitDate.Text != "")
                {
                    ObjBOL.NextVisitDate = Utility.ConvertDate(txtNextVisitDate.Text);
                }

                ObjBOL.SiteContactName = txtSiteContactName.Text;
                ObjBOL.SiteContactNumber = txtSiteContactNumber.Text;
                ObjBOL.Remarks = txtRemarks.Text;
                ObjBOL.SameAsProjectLocation = chkSameAsProjectLocation.Checked;
                ObjBOL.EmployeeIDs = SelectedEmployees();
                string returnValue = ObjBLL.Return_String(ObjBOL);
                if (returnValue.Trim() != "")
                {
                    if (id == 0)
                    {
                        Utility.MaintainLogsSpecial(formName, "Save", returnValue);
                        Utility.ShowMessage_Success(Page, "Visit added successfully !!");
                    }
                    else
                    {
                        Utility.MaintainLogsSpecial(formName, "Update", returnValue);
                        Utility.ShowMessage_Success(Page, "Visit updated successfully !!");
                    }
                    btnCancel_Click_Event();
                    HfPNumber.Value = returnValue.Trim();
                    GetPName();
                    ddlPNumberLookupList_SelectedIndexChanged_Event();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetPName()
    {
        try
        {
            ObjBOL.Operation = 14;
            ObjBOL.PNumber = HfPNumber.Value;
            DataSet ds = new DataSet();
            ds = ObjBLL.Return_DataSet(ObjBOL);
            string PName = ds.Tables[0].Rows[0]["PName"].ToString();
            if (PName.Trim() != "")
            {
                txtSearchPName.Text = PName.Trim();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private string SelectedEmployees()
    {
        try
        {
            int[] teamMembers = ddlEmployee.GetSelectedIndices();
            string SelectedEmployees = string.Empty;
            foreach (int index in teamMembers)
            {
                ListItem selectedItem = ddlEmployee.Items[index];
                if (!string.IsNullOrEmpty(SelectedEmployees))
                {
                    SelectedEmployees += ',';
                }
                SelectedEmployees += selectedItem.Value;
            }
            return SelectedEmployees;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return string.Empty;
    }

    private void btnFilterForm_Click_Event()
    {
        try
        {
            Response.Redirect("~/Reports/FrmSiteVisitReport.aspx", false);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetInfoAndDetail()
    {
        try
        {
            ddlRequestor.SelectedIndex = 0;
            ddlPurpose.SelectedIndex = 0;
            //ddlRegion.SelectedIndex = 0;
            txtSiteAddress.Text = string.Empty;
            ddlCountry.SelectedIndex = 0;
            ddlState.Items.Clear();
            txtCity.Text = string.Empty;
            txtSiteVisitDate.Text = string.Empty;
            txtNextVisitDate.Text = string.Empty;
            txtSiteContactName.Text = string.Empty;
            txtSiteContactNumber.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            ddlEmployee.SelectedIndex = 0;
            chkSameAsProjectLocation.Checked = false;
            txtAddress_ProjectLocation.Text = string.Empty;
            txtCountry_ProjectLocation.Text = string.Empty;
            txtState_ProjectLocation.Text = string.Empty;
            txtCity_ProjectLocation.Text = string.Empty;
            EnableSiteLocationSegment();
            hfID.Value = "0";
            ResetEmployee();
            btnSave.Text = "Add Visit";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetEmployee()
    {
        try
        {
            foreach (ListItem item in ddlEmployee.Items)
            {
                item.Selected = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetGrid()
    {
        try
        {
            gvDetail.DataSource = string.Empty;
            gvDetail.DataBind();
            siteVisits.Visible = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableSiteLocationSegment()
    {
        try
        {
            txtSiteAddress.Enabled = false;
            ddlCountry.Enabled = false;
            ddlState.Enabled = false;
            txtCity.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableSiteLocationSegment()
    {
        try
        {
            txtSiteAddress.Enabled = true;
            ddlCountry.Enabled = true;
            ddlState.Enabled = true;
            txtCity.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

}