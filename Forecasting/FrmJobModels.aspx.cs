using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forecasting_FrmJobModels : System.Web.UI.Page
{
    BOLForecastingJobModels ObjBOL = new BOLForecastingJobModels();
    BLLForecastingJobModels ObjBLL = new BLLForecastingJobModels();
    ReportDocument rprt = new ReportDocument();
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
            ObjBOL.Operation = 1;
            DataSet ds = new DataSet();
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConveyorModel, ds.Tables[0]);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlAllParentParts, ds.Tables[1]);
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
            if (txtSearchPNum.Text.Length >= 7)
            {
                string OutJnumber = string.Empty;
                int index = txtSearchPNum.Text.IndexOf(',');
                if (txtSearchPNum.Text.Length > 7)
                {
                    if (index != -1)
                    {
                        OutJnumber = txtSearchPNum.Text.Substring(0, txtSearchPNum.Text.IndexOf(','));
                    }
                }
                else
                {
                    OutJnumber = txtSearchPNum.Text;
                }
                HfJobID.Value = OutJnumber;
                SyncTextbox("NAME", OutJnumber);
                ResetControls();
                return;
            }
            else
            {
                ResetControls();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void SearchPNameButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtSearchPName.Text != "")
            {
                txtSearchPNum.Text = string.Empty;
                string output = txtSearchPName.Text;
                int openTagEndPosition = output.IndexOf("#");
                output = output.Substring(openTagEndPosition + 1);
                HfJobID.Value = output;
                SyncTextbox("NUM", output);
                ResetControls();
            }
            else
            {
                ResetControls();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SyncTextbox(string type, string text)
    {
        try
        {
            if (type != "")
            {
                DataTable dt = new DataTable();
                if (type == "NUM")
                {
                    dt = Utility.ReturnProjects(26, text);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchPNum.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                        GetModelList(text);
                        GetProjectReleaseStatus(text);
                    }
                    else
                    {
                        txtSearchPNum.Text = "";
                        txtSearchPName.Text = "";
                        Utility.ShowMessage_Error(Page, "J# not Found");
                    }
                }
                else
                {
                    if (text != "")
                    {
                        dt = Utility.ReturnProjects(25, text);
                        if (dt.Rows.Count > 0)
                        {
                            txtSearchPName.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                            GetModelList(text);
                            GetProjectReleaseStatus(text);
                        }
                        else
                        {
                            txtSearchPNum.Text = "";
                            txtSearchPName.Text = "";
                            Utility.ShowMessage_Error(Page, "J# not Found");
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

    private void GetProjectReleaseStatus(string jobId)
    {
        try
        {
            ObjBOL.Operation = 12;
            ObjBOL.JobID = jobId;
            string returnValue = ObjBLL.Return_String(ObjBOL).Trim();
            if (returnValue.Length > 0)
            {
                if (returnValue == "1")
                {
                    btnSave.Enabled = false;
                    HfRelease.Value = "1";
                }
                else
                {
                    btnSave.Enabled = true;
                    HfRelease.Value = "-1";
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetControls()
    {
        try
        {
            ddlConveyorModel.SelectedIndex = 0;
            if (ddlConveyorType.Items.Count > 0)
            {
                ddlConveyorType.Items.Clear();
            }
            if (ddlConveyorSize.Items.Count > 0)
            {
                ddlConveyorSize.Items.Clear();
            }
            if (ddlConveyorParentParts.Items.Count > 0)
            {
                ddlConveyorParentParts.Items.Clear();
            }
            if (ddlAllParentParts.Items.Count > 0)
            {
                ddlAllParentParts.SelectedIndex = 0;
            }
            txtPartQty.Text = String.Empty;
            EnableSubHeaderSection();
            btnSave.Text = "Save";
            HfID.Value = "-1";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetModelList(string jobId)
    {
        try
        {
            if (ValidationCheck())
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 7;
                ObjBOL.JobID = jobId;
                ds = ObjBLL.Return_DataSet(ObjBOL);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvList.DataSource = ds.Tables[0];
                    gvList.DataBind();
                }
                else
                {
                    gvList.DataSource = string.Empty;
                    gvList.DataBind();
                }
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
            if (HfJobID.Value.Trim() == "-1")
            {
                Utility.ShowMessage_Error(Page, "Please Select Job !");
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private bool ValidationCheckSave()
    {
        try
        {
            if (HfJobID.Value.Trim() == "-1")
            {
                Utility.ShowMessage_Error(Page, "Please Select Job !");
                return false;
            }

            if (HfRelease.Value == "1")
            {
                Utility.ShowMessage_Error(Page, "Job already released. Job Model cannot change !");
                return false;
            }

            if (ddlConveyorModel.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Conveyor Model !");
                return false;
            }

            if (ddlConveyorType.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Conveyor Type !");
            }

            if (ddlConveyorParentParts.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please select Parent Part !");
                return false;
            }

            if (txtPartQty.Text.Trim() == "")
            {
                Utility.ShowMessage_Error(Page, "Please enter qty !");
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void ddlConveyorModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlConveyorModel_SelectedIndexChanged_Event();
    }

    private void ddlConveyorModel_SelectedIndexChanged_Event()
    {
        try
        {
            if (ValidationCheck())
            {
                ddlConveyorType.Items.Clear();
                ddlConveyorSize.Items.Clear();
                ddlConveyorParentParts.Items.Clear();
                txtPartQty.Text = string.Empty;
                if (ddlConveyorModel.SelectedIndex > 0)
                {
                    DataSet ds = new DataSet();
                    ObjBOL.Operation = 2;
                    ObjBOL.AWProductSubID = Int32.Parse(ddlConveyorModel.SelectedValue);
                    ds = ObjBLL.Return_DataSet(ObjBOL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Utility.BindDropDownList(ddlConveyorType, ds.Tables[0]);
                    }
                }
            }
            else
            {
                ddlConveyorModel.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlConveyorType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlConveyorType_SelectedIndexChanged();
    }

    private void ddlConveyorType_SelectedIndexChanged()
    {
        try
        {
            if (ValidationCheck())
            {
                ddlConveyorSize.Items.Clear();
                ddlConveyorParentParts.Items.Clear();
                txtPartQty.Text = string.Empty;
                if (ddlConveyorType.SelectedIndex > 0)
                {
                    DataSet ds = new DataSet();
                    ObjBOL.Operation = 3;
                    ObjBOL.AWProductSubID = Int32.Parse(ddlConveyorType.SelectedValue);
                    if (ddlConveyorSize.SelectedIndex > 0)
                    {
                        ObjBOL.SizeID = Int32.Parse(ddlConveyorModel.SelectedValue);
                    }
                    else
                    {
                        ObjBOL.SizeID = 0;
                    }
                    ds = ObjBLL.Return_DataSet(ObjBOL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Utility.BindDropDownList(ddlConveyorSize, ds.Tables[0]);
                    }
                    GetNoSizeParts();
                }
            }
            else
            {
                ddlConveyorType.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetNoSizeParts()
    {
        try
        {
            if (ddlConveyorType.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 10;
                ObjBOL.JobID = HfJobID.Value;
                ObjBOL.AWProductSubID = Int32.Parse(ddlConveyorType.SelectedValue);
                ds = ObjBLL.Return_DataSet(ObjBOL);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlConveyorParentParts, ds.Tables[0]);
                    ddlConveyorParentParts.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlConveyorSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlConveyorSize_SelectedIndexChanged_Event();
    }

    private void ddlConveyorSize_SelectedIndexChanged_Event()
    {
        try
        {
            if (ValidationCheck())
            {
                ddlConveyorParentParts.Items.Clear();
                txtPartQty.Text = string.Empty;
                if (ddlConveyorSize.SelectedIndex > 0)
                {
                    DataSet ds = new DataSet();
                    ObjBOL.Operation = 4;
                    ObjBOL.JobID = HfJobID.Value;
                    ObjBOL.AWProductSubID = Int32.Parse(ddlConveyorType.SelectedValue);
                    if (ddlConveyorSize.SelectedIndex > 0)
                    {
                        ObjBOL.SizeID = Int32.Parse(ddlConveyorSize.SelectedValue);
                    }
                    ds = ObjBLL.Return_DataSet(ObjBOL);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Utility.BindDropDownList(ddlConveyorParentParts, ds.Tables[0]);
                        ddlConveyorParentParts.SelectedIndex = 0;
                    }
                }
                else
                {
                    GetNoSizeParts();
                }
            }
            else
            {
                ddlConveyorSize.SelectedIndex = 0;
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
            if (Utility.IsAuthorized())
            {
                if (ValidationCheckSave())
                {
                    int userID = Utility.GetCurrentUser();
                    ObjBOL.Operation = 5;
                    if (Int32.Parse(HfID.Value) > 0)
                    {
                        ObjBOL.Operation = 15;
                        ObjBOL.ID = Int32.Parse(HfID.Value);
                    }
                    ObjBOL.UserID = userID;
                    ObjBOL.JobID = HfJobID.Value;
                    if (ddlConveyorSize.SelectedIndex > 0)
                    {
                        ObjBOL.SizeID = Int32.Parse(ddlConveyorSize.SelectedValue);
                    }

                    if (ddlConveyorType.SelectedIndex > 0)
                    {
                        ObjBOL.AWProductSubID = Int32.Parse(ddlConveyorType.SelectedValue);
                    }

                    if (ddlConveyorParentParts.SelectedIndex > 0)
                    {
                        ObjBOL.ParentPartID = Int32.Parse(ddlConveyorParentParts.SelectedValue);
                    }
                    if (txtPartQty.Text != "")
                    {
                        ObjBOL.Qty = Decimal.Parse(txtPartQty.Text);
                    }
                    string returnStatus = ObjBLL.Return_String(ObjBOL);
                    if (returnStatus.Trim().Length > 0)
                    {
                        if (returnStatus.Trim() == "ER01")
                        {
                            Utility.ShowMessage_Error(Page, "Part already exists !");
                        }
                        else if (returnStatus == "ER02")
                        {
                            Utility.ShowMessage_Error(Page, "Project already released !!");
                        }
                        else
                        {
                            if (Int32.Parse(HfID.Value) > 0)
                            {
                                Utility.MaintainLogsSpecial("FrmJobModels.aspx", "update", HfJobID.Value + "-" + HfID.Value);
                                GetModelList(HfJobID.Value);
                                ResetControls();
                            }
                            else
                            {
                                Utility.MaintainLogsSpecial("FrmJobModels.aspx", "save", HfJobID.Value + "-" + ddlConveyorModel.SelectedValue);
                                GetModelList(HfJobID.Value);
                                txtPartQty.Text = string.Empty;
                            }
                            Utility.ShowMessage_Success(Page, returnStatus);
                            //ddlConveyorSize_SelectedIndexChanged_Event();
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

    protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (HfRelease.Value == "-1")
            {
                int id = Convert.ToInt32(gvList.DataKeys[e.RowIndex].Values[0]);
                ObjBOL.Operation = 6;
                ObjBOL.ProjectsID = id;
                ObjBOL.JobID = HfJobID.Value;
                string returnStatus = ObjBLL.Return_String(ObjBOL).Trim();
                if (returnStatus.Length > 0)
                {
                    if (returnStatus == "ER02")
                    {
                        Utility.ShowMessage_Error(Page, "Project already released !!");
                    }
                    else
                    {
                        Utility.MaintainLogsSpecial("FrmJobModels.aspx", "delete", HfJobID.Value);
                        Utility.ShowMessage_Success(Page, returnStatus);
                        ddlConveyorSize_SelectedIndexChanged_Event();
                        GetModelList(HfJobID.Value);
                    }
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Project already released !");
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
            ObjBOL.Operation = 8;
            ObjBOL.JobID = HfJobID.Value;
            DataSet ds = new DataSet();
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = ReportData();
            rprt.Load(Server.MapPath("~/Forecasting/rptJobModelsPreview.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = dt.Rows[0]["JobID"].ToString().Replace(',', ' ');
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
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

    protected void ddlConveyorParentParts_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ddlConveyorParentParts.SelectedIndex > 0)
            //{
            //    ObjBOL.Operation = 9;
            //    ObjBOL.ID = Int32.Parse(ddlConveyorParentParts.SelectedValue);
            //    string returnValue = ObjBLL.Return_String(ObjBOL);
            //    if (returnValue.Trim().Length > 0)
            //    {
            //        txtPartQty.Text = returnValue;
            //    }
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlAllParentParts_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlAllParentParts.SelectedIndex > 0)
            {
                ObjBOL.Operation = 13;
                ObjBOL.ID = Int32.Parse(ddlAllParentParts.SelectedValue);
                DataSet ds = new DataSet();
                ds = ObjBLL.Return_DataSet(ObjBOL);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    LoadParentPart(dr);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool LoadParentPart(DataRow dr)
    {
        try
        {
            if (dr["ModelID"].ToString() != "0" && ddlConveyorModel.Items.FindByValue(dr["ModelID"].ToString()) != null)
            {
                ddlConveyorModel.SelectedValue = dr["ModelID"].ToString();
                ddlConveyorModel_SelectedIndexChanged_Event();
                if (dr["TypeID"].ToString() != "0" && ddlConveyorType.Items.FindByValue(dr["TypeID"].ToString()) != null)
                {
                    ddlConveyorType.SelectedValue = dr["TypeID"].ToString();
                    ddlConveyorType_SelectedIndexChanged();

                    if (dr["SizeID"].ToString() != "0")
                    {
                        if (ddlConveyorSize.Items.FindByValue(dr["SizeID"].ToString()) != null)
                        {
                            ddlConveyorSize.SelectedValue = dr["SizeID"].ToString();
                            ddlConveyorSize_SelectedIndexChanged_Event();
                            if (ddlConveyorParentParts.Items.FindByValue(dr["ParentPartID"].ToString()) != null)
                            {
                                ddlConveyorParentParts.SelectedValue = dr["ParentPartID"].ToString();
                            }
                            else
                            {
                                Utility.ShowMessage_Error(Page, "Parent Part not found in the list!");
                                return false;
                            }
                        }
                        else
                        {
                            Utility.ShowMessage_Error(Page, "Size not found in the list!");
                        }
                    }
                    else
                    {
                        if (ddlConveyorParentParts.Items.FindByValue(dr["ParentPartID"].ToString()) != null)
                        {
                            ddlConveyorParentParts.SelectedValue = dr["ParentPartID"].ToString();
                        }
                        else
                        {
                            Utility.ShowMessage_Error(Page, "Parent Part not found in the list!");
                            return false;
                        }
                    }
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "Type not found in the list!");
                    return false;
                }
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Model not found in the list!");
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void gvList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            int ID = Convert.ToInt32(gvList.DataKeys[e.NewEditIndex].Values[0]);
            ObjBOL.Operation = 14;
            ObjBOL.ID = ID;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (LoadParentPart(dr))
                {
                    DisableSubHeaderSection();
                    HfID.Value = ID.ToString();
                    txtPartQty.Text = dr["Qty"].ToString();
                    btnSave.Text = "Update";
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableSubHeaderSection()
    {
        try
        {
            ddlConveyorModel.Enabled = false;
            ddlConveyorType.Enabled = false;
            ddlConveyorSize.Enabled = false;
            ddlConveyorParentParts.Enabled = false;
            ddlAllParentParts.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void EnableSubHeaderSection()
    {
        try
        {
            ddlConveyorModel.Enabled = true;
            ddlConveyorType.Enabled = true;
            ddlConveyorSize.Enabled = true;
            ddlConveyorParentParts.Enabled = true;
            ddlAllParentParts.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}