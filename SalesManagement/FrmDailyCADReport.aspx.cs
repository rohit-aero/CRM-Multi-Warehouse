using BLLAERO;
using BOLAERO;
using CrystalDecisions.CrystalReports.Engine;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class SalesManagement_DailyCADReport : System.Web.UI.Page
{
    BLLDailyCADReport ObjBLL = new BLLDailyCADReport();
    BOLDailyCADReport ObjBOL = new BOLDailyCADReport();
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Utility.IsAuthorized())
                {
                    BindControls();
                    CheckPermission();
                    ddlProgress.Enabled = false;
                    if (Request.QueryString["pNumber"] != null)
                    {
                        // btnCADReport.Enabled = true;
                        if (ddlPNumberHeaderList.Items.FindByValue(Request.QueryString["pNumber"]) != null)
                        {
                            ddlPNumberHeaderList.SelectedValue = Request.QueryString["pNumber"];
                            ddlPNumberHeaderList_Event(false);
                            BindGrid();
                        }
                        else
                        {
                            txtSearchPNum.Text = Request.QueryString["pNumber"];
                            SyncTextbox("NUM", txtSearchPNum.Text);
                            syncPNumberDropdown_SelectedIndexChanged_Event(false);
                            HfPNumber.Value = Request.QueryString["pNumber"];
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

    #region Bind Functions

    private void BindControls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControls(ObjBOL);

            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlNature, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlStatus, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectEngineer, ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPNumberHeaderList, ds.Tables[5]);
            }
            ddlPriority.SelectedValue = "1";
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
        try
        {
            //if (txtReportDate.Text == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Report Date. !');", true);
            //    txtReportDate.Focus();
            //    return false;
            //}

            if (txtSearchPNum.Text.Trim().Length == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select PNumber. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select PNumber. !");
                txtSearchPNum.Focus();
                return false;
            }

            if (ddlNature.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Nature of Task. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Nature of Task. !");
                ddlNature.Focus();
                return false;
            }

            if (ddlStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Status. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                ddlNature.Focus();
                return false;
            }
            if (ddlStatus.SelectedValue == "5" || ddlStatus.SelectedValue == "3")
            {
                if (ddlProgress.SelectedIndex == 0)
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Progess. !');", true);
                    Utility.ShowMessage_Error(Page, "Please Select Progess. !");
                    ddlProgress.Focus();
                    return false;
                }
            }
            else if (ddlStatus.SelectedValue == "1")
            {
                if (txtProjectSendToRCD.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Date Project Sent to Customer. !");
                    txtProjectSendToRCD.Focus();
                    return false;
                }
            }
            //if (ddlProjectEngineer.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Project Engineer. !');", true);
            //    ddlNature.Focus();
            //    return false;
            //}

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void CheckPermission()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 11;
            ObjBOL.ID = Utility.GetCurrentUser();
            int permissionForPM = Int32.Parse(ObjBLL.SaveAndUpdate(ObjBOL));
            if (permissionForPM == 0)
            {
                txtRemarks.Visible = false;
                lblRemarks.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Event Handler Functions

    protected void ddlReportDateHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlReportDateHeaderList_Event();
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void ddlPNumberHeaderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlPNumberHeaderList_Event(true);
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void syncPNumberDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlProjectDesc.SelectedValue = ddlPNumber.SelectedValue;
        //LoadRelevantInfoForPNumberSync();
        syncPNumberDropdown_SelectedIndexChanged_Event(true);
    }

    protected void syncProjectDesc_SelectedIndexChanged(object sender, EventArgs e)
    {
        syncProjectDesc_SelectedIndexChanged_Event(true);
    }

    protected void gvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            DisableSubHeaderSection();
            DataSet ds = new DataSet();
            int ID = Convert.ToInt32(gvDetail.DataKeys[e.NewEditIndex].Values[0]);
            HiddenDetailID.Value = ID.ToString();
            ObjBOL.Operation = 8;
            ObjBOL.DetailID = ID;
            ds = ObjBLL.GetInformation(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                txtReportDate.Text = row["ReportDate"].ToString();
                if (ddlNature.Items.FindByValue(row["NatureID"].ToString()) != null)
                {
                    ddlNature.SelectedValue = row["NatureID"].ToString();
                }

                if (ddlStatus.Items.FindByValue(row["StatusID"].ToString()) != null)
                {
                    ddlStatus.SelectedValue = row["StatusID"].ToString();
                }

                if (ddlStatus.SelectedValue == "5" || ddlStatus.SelectedValue == "3")
                {
                    ddlProgress.Enabled = true;
                }
                else
                {
                    ddlProgress.Enabled = false;
                }

                if (ddlProgress.Items.FindByValue(row["Progress"].ToString()) != null)
                {
                    ddlProgress.SelectedValue = row["Progress"].ToString();
                }

                if (ddlProjectEngineer.Items.FindByValue(row["ProjectEngineerID"].ToString()) != null)
                {
                    ddlProjectEngineer.SelectedValue = row["ProjectEngineerID"].ToString();
                }

                if (ddlPriority.Items.FindByValue(row["Priority"].ToString()) != null)
                {
                    ddlPriority.SelectedValue = row["Priority"].ToString();
                }
                else
                {
                    ddlPriority.SelectedValue = "1";
                }
                txtCorrection.Text = row["Correction"].ToString();
                txtReqByRCD.Text = row["ReqRCD"].ToString();
                txtReqForwardedToIndia.Text = row["SentCAD"].ToString();
                txtProjectSendToRCD.Text = row["SentRCD"].ToString();
                txtComments.Text = row["Comments"].ToString();
                //txtCommentsByEngineer.Text = row["CommentsByEngineer"].ToString();
                txtRemarks.Text = row["Remarks"].ToString();
                btnSave.Text = "Update";
                //ddlProjectEngineer.SelectedValue = row["SentRCD"].ToString();
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
            if(HfPNumber.Value != "-1")
            {
                int ID = Convert.ToInt32(gvDetail.DataKeys[e.RowIndex].Values[0]);
                ObjBOL.Operation = 9;
                ObjBOL.DetailID = ID;
                string return_msg = ObjBLL.SaveAndUpdate(ObjBOL);
                if (return_msg != "")
                {
                    Utility.MaintainLogsSpecial("DailyCADReport", "Delete", HfPNumber.Value);
                    Utility.ShowMessage_Success(Page, return_msg);
                    var PNumber = ddlPNumberHeaderList.SelectedValue;
                    Reset();
                    ddlPNumberHeaderList.SelectedValue = PNumber;
                    ddlPNumberHeaderList_Event(false);
                    BindGrid();
                }
            }
            
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void gvDetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                DataView dataView = new DataView(dtrslt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvDetail.DataSource = dataView;
                gvDetail.DataBind();
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + "DESC";
                gvDetail.DataSource = dtrslt;
                gvDetail.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDailyProjectReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = DateTime.Now.ToLongDateString();
                HeaderCell.ColumnSpan = 11;
                HeaderGridRow.Cells.Add(HeaderCell);
                HeaderGridRow.HorizontalAlign = HorizontalAlign.Center;
                HeaderGridRow.BackColor = Color.Green;
                this.gvDailyProjectReport.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvDailyProjectReport_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "StatusID").ToString();
                string priority = DataBinder.Eval(e.Row.DataItem, "Priority").ToString();
                string changeColor = DataBinder.Eval(e.Row.DataItem, "ChangeColor").ToString();
                ObjBOL.Operation = 12;
                string color = "#FFFFFF";
                if (status != "")
                {
                    ObjBOL.ID = Int32.Parse(status);
                    color = ObjBLL.SaveAndUpdate(ObjBOL);
                }
                string css = "background-color: " + color + " !important;";
                if (priority.Trim().ToUpper() == "URGENT")
                {
                    css += "color:red;";
                }
                else if (changeColor.Trim() == "CHANGECOLOR" && status.Trim() == "5")
                {
                    css += "color:yellow;";
                }
                else
                {
                    css += "color:black;";
                }
                e.Row.Attributes["style"] = css;
                foreach (TableCell cell in e.Row.Cells)
                {
                    cell.Attributes["style"] = "border: 1px solid black !important;";
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    protected void btnCADReport_Click(object sender, EventArgs e)
    {
        try
        {
            GenerateReport();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnFilterForm_Click(object sender, EventArgs e)
    {
        try
        {
            //Session["PNumber"] = "";
            //Session["PNumber"] = HfPNumber.Value.Replace(",", "");
            //Response.Redirect("~/Reports/frmNewCADReport.aspx", false);
            Response.Redirect("~/Reports/FrmCADWeekendReport.aspx", false);

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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {

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
            txtSearchPName.Text = string.Empty;
            txtSearchPNum.Text = string.Empty;
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Internal Functions

    private void LoadRelevantInfoForPNumberSync(bool enableFeature)
    {
        try
        {
            string proposalNumber = HfPNumber.Value;
            ObjBOL.Operation = 2;
            ObjBOL.PNumber = proposalNumber;
            string projectManager = ObjBLL.SaveAndUpdate(ObjBOL);
            if (enableFeature)
            {
                Reset();
                HfPNumber.Value = proposalNumber;
                ddlProjectDesc.SelectedValue = proposalNumber;
                if (ddlPNumberHeaderList.Items.FindByValue(proposalNumber) != null)
                {
                    ddlPNumberHeaderList.SelectedValue = proposalNumber;
                    BindGrid();
                }
            }
            txtProjectManager.Text = projectManager;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void syncPNumberDropdown_SelectedIndexChanged_Event(bool enableFeature)
    {
        try
        {
            ddlProjectDesc.SelectedValue = HfPNumber.Value;
            LoadRelevantInfoForPNumberSync(enableFeature);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void syncProjectDesc_SelectedIndexChanged_Event(bool enableFeature)
    {
        try
        {
            HfPNumber.Value = ddlProjectDesc.SelectedValue;
            LoadRelevantInfoForPNumberSync(enableFeature);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlReportDateHeaderList_Event()
    {
        try
        {
            ResetInfo();
            EnableSubHeaderSection();
            if (ddlReportDateHeaderList.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 5;
                ObjBOL.ReportDate = Utility.ConvertDate(ddlReportDateHeaderList.SelectedValue);
                ds = ObjBLL.GetInformation(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlPNumberHeaderList, ds.Tables[0]);
                    btnCADReport.Enabled = true;
                }
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

    private void ddlPNumberHeaderList_Event(bool enableFeature)
    {
        try
        {
            EnableSubHeaderSection();
            if (ddlPNumberHeaderList.SelectedIndex > 0)
            {

                DataSet ds = new DataSet();
                ObjBOL.PNumber = ddlPNumberHeaderList.SelectedValue;
                //if (ddlReportDateHeaderList.SelectedIndex == 0)
                //{
                //    ObjBOL.Operation = 7;
                //    ddlReportDateHeaderList.SelectedValue = ObjBLL.GetInformation(ObjBOL).Tables[0].Rows[0][0].ToString();
                //    ddlReportDateHeaderList_Event();
                //    ddlPNumberHeaderList.SelectedValue = ObjBOL.PNumber;
                //}
                //BindGrid();
                //txtReportDate.Text = ddlReportDateHeaderList.SelectedValue;
                txtReportDate.Text = string.Empty;
                txtSearchPNum.Text = ddlPNumberHeaderList.SelectedValue;
                SyncTextbox("NUM", ddlPNumberHeaderList.SelectedValue);
                HfPNumber.Value = ddlPNumberHeaderList.SelectedValue;
                ddlProjectDesc.SelectedValue = ddlPNumberHeaderList.SelectedValue;
                LoadRelevantInfoForPNumberSync(enableFeature);
            }
            else
            {
                ResetInfo();
                txtSearchPName.Text = string.Empty;
                txtSearchPNum.Text = string.Empty;
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
            ObjBOL.Operation = 6;
            ObjBOL.PNumber = ddlPNumberHeaderList.SelectedValue;
            //ObjBOL.ReportDate = Convert.ToDateTime(ddlReportDateHeaderList.SelectedValue);
            ds = ObjBLL.GetInformation(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetail.DataSource = ds.Tables[0];
                ViewState["dirState"] = ds.Tables[0];
                gvDetail.DataBind();
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
                if (txtReportDate.Text != "")
                {
                    ObjBOL.ReportDate = Utility.ConvertDate(txtReportDate.Text);
                }

                ObjBOL.NatureID = Convert.ToInt32(ddlNature.SelectedValue);
                if (ddlProjectEngineer.SelectedIndex > 0)
                {
                    ObjBOL.ProjectEngineerID = Convert.ToInt32(ddlProjectEngineer.SelectedValue);
                }

                if (ddlStatus.SelectedIndex > 0)
                {
                    ObjBOL.StatusID = Convert.ToInt32(ddlStatus.SelectedValue);
                }
                if (ddlStatus.SelectedValue == "5" || ddlStatus.SelectedValue == "3")
                {
                    ObjBOL.Progress = ddlProgress.SelectedValue;
                }
                if (txtReqByRCD.Text != "")
                {
                    ObjBOL.ReqRCD = Utility.ConvertDate(txtReqByRCD.Text);
                }

                if (txtReqForwardedToIndia.Text != "")
                {
                    ObjBOL.SentCAD = Utility.ConvertDate(txtReqForwardedToIndia.Text);
                }

                if (txtProjectSendToRCD.Text != "")
                {
                    ObjBOL.SentRCD = Utility.ConvertDate(txtProjectSendToRCD.Text);
                }

                ObjBOL.Correction = txtCorrection.Text;
                ObjBOL.Comments = txtComments.Text;
                // ObjBOL.CommentsByEngineer = txtCommentsByEngineer.Text;
                ObjBOL.Remarks = txtRemarks.Text;
                ObjBOL.PNumber = HfPNumber.Value;
                ObjBOL.Priority = ddlPriority.SelectedValue;
                string return_msg = "";
                if (btnSave.Text == "Save")
                {
                    ObjBOL.Operation = 3;
                    return_msg = ObjBLL.SaveAndUpdate(ObjBOL);
                    AfterSaveUpdateOperation(return_msg, 1);
                }

                if (btnSave.Text == "Update")
                {
                    ObjBOL.Operation = 4;
                    ObjBOL.DetailID = Convert.ToInt32(HiddenDetailID.Value);
                    return_msg = ObjBLL.SaveAndUpdate(ObjBOL);
                    AfterSaveUpdateOperation(return_msg, 2);
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void AfterSaveUpdateOperation(string return_msg, int saveOrUpdate)
    {
        try
        {
            if (return_msg != "")
            {
                HfPNumber.Value = return_msg.Trim();
                if(HfPNumber.Value != "-1")
                {
                    Utility.MaintainLogsSpecial("DailyCADReport", btnSave.Text, HfPNumber.Value);
                }                
                if (saveOrUpdate == 1)
                {
                    Utility.ShowMessage_Success(Page, "Record Saved Successfully !!");
                    BindControls();
                }
                else
                {
                    Utility.ShowMessage_Success(Page, "Record Updated Successfully !!");
                }
                var PNumber = HfPNumber.Value;
                Reset();
                ddlPNumberHeaderList.SelectedValue = PNumber;
                HfPNumber.Value = PNumber;
                ddlPNumberHeaderList_Event(false);
                BindGrid();
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
            txtReportDate.Enabled = false;
            HfPNumber.Value = "-1";
            ddlProjectDesc.Enabled = false;
            txtSearchPNum.Enabled = false;
            txtSearchPName.Enabled = false;
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
            txtReportDate.Enabled = true;
            //ddlPNumber.Enabled = true;
            ddlProjectDesc.Enabled = true;
            txtSearchPNum.Enabled = true;
            txtSearchPName.Enabled = true;
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Report   

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            DataSet ds = new DataSet();
            ds = ObjBLL.BindReport(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    DataRow rowBlank = dt.NewRow();
            //    dt.Rows.Add(rowBlank);
            //    foreach (DataRow row in ds.Tables[1].Rows)
            //    {
            //        DataRow rowTemp = dt.NewRow();
            //        rowTemp["ProjectDescription"] = row[1];
            //        rowTemp["StatusID"] = row[0];
            //        dt.Rows.Add(rowTemp);
            //    }
            //    rowBlank = dt.NewRow();
            //    dt.Rows.Add(rowBlank);
            //    rowBlank = dt.NewRow();
            //    rowBlank["ProjectDescription"] = "Project with RED font color are URGENT Priority";
            //    dt.Rows.Add(rowBlank);
            //    rowBlank = dt.NewRow();
            //    rowBlank["ProjectDescription"] = "Project with YELLOW font color indicates that it was not delivered to the customer 2 days after it was forwarded to the CAD team.";
            //    rowBlank["StatusID"] = "5";
            //    dt.Rows.Add(rowBlank);
            //}
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    //private void BindReportGrid()
    //{
    //    DataTable dt = ReportData();
    //    if (dt.Rows.Count > 0)
    //    {
    //        gvDailyProjectReport.DataSource = dt;
    //        gvDailyProjectReport.DataBind();
    //    }
    //}

    private void GeneratePdf()
    {
        try
        {
            Response.ContentType = "application/pdf";
            string fullnam = "Daily Project Report - CAD Drawings-" + DateTime.Now.ToLongDateString() + ".pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=Daily CAD Report.pdf");
            Response.AddHeader("content-disposition", "attachment;filename=" + fullnam.Replace(",", ""));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Document pdfDoc = new Document(PageSize.A2, 2f, 2f, 5f, 0f);
            PdfPTable table = new PdfPTable(gvDailyProjectReport.Columns.Count - 2);
            table.WidthPercentage = 100;
            PdfPCell headerCell = new PdfPCell(new Phrase(DateTime.Now.ToLongDateString()));
            headerCell.Colspan = gvDailyProjectReport.Columns.Count - 2;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            // Add the additional header cell to the table
            var height = 40f;
            headerCell.MinimumHeight = height;
            table.AddCell(headerCell);
            float[] widths = new float[gvDailyProjectReport.Columns.Count - 2];
            for (int i = 0; i < widths.Length; i++)
            {
                if (i == 0)
                {
                    widths[i] = 1f;
                }
                else if (i == 1 || i == 2)
                {
                    widths[i] = 2f;
                }
                else if (i == 3 || i == widths.Length - 1)
                {
                    widths[i] = 7f;
                }
                else if (i == 10 || i == 7)
                {
                    widths[i] = 3f;
                }
                else if (i == 5)
                {
                    widths[i] = 2f;
                }
                else if (i == 11)
                {
                    widths[i] = 2f;
                }
                else
                {
                    widths[i] = 2f;
                }
            }
            table.SetWidths(widths);
            for (int i = 0; i < gvDailyProjectReport.HeaderRow.Cells.Count - 1; i++)
            {
                if (i != 0)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(gvDailyProjectReport.HeaderRow.Cells[i].Text));
                    pdfCell.MinimumHeight = height;
                    table.AddCell(pdfCell);
                }
            }
            for (int r = 0; r < gvDailyProjectReport.Rows.Count; r++)
            {
                GridViewRow row = gvDailyProjectReport.Rows[r];
                for (int i = 0; i < row.Cells.Count - 1; i++)
                {
                    if (i != 0)
                    {
                        iTextSharp.text.Font font = new iTextSharp.text.Font();
                        string style = row.Attributes["style"];
                        string fontcolor = System.Text.RegularExpressions.Regex.Match(style, "color:[red;]{4}|color:[yellow;]{7}|color:[black;]{6}").Value;

                        if (fontcolor == "color:red;")
                        {
                            font.SetColor(255, 0, 0);
                        }
                        else if (fontcolor == "color:yellow;")
                        {
                            font.SetColor(255, 255, 0);
                        }
                        else
                        {
                            font.SetColor(0, 0, 0);
                        }
                        if (r == gvDailyProjectReport.Rows.Count - 2)
                        {
                            font.SetColor(255, 0, 0);
                        }
                        if (r == gvDailyProjectReport.Rows.Count - 1)
                        {
                            font.SetColor(255, 255, 0);
                        }
                        if (row.Cells[i].Controls.Count > 0)
                        {
                            foreach (Control control in row.Cells[i].Controls)
                            {
                                if (control is Label)
                                {
                                    PdfPCell pdfCell = new PdfPCell(new Phrase(((Label)control).Text, font));
                                    string colorCode = System.Text.RegularExpressions.Regex.Match(style, "#[a-fA-F0-9]{6}").Value;
                                    pdfCell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml(colorCode));
                                    pdfCell.MinimumHeight = height;
                                    table.AddCell(pdfCell);
                                }
                            }
                        }
                        else
                        {
                            PdfPCell pdfCell = new PdfPCell(new Phrase(row.Cells[i].Text, font));
                            string colorCode = row.Attributes["style"];
                            pdfCell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml(colorCode));
                            pdfCell.MinimumHeight = height;
                            table.AddCell(pdfCell);
                        }
                    }
                }
            }
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(table);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlStatus_SelectedIndexChanged_Event();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ddlStatus_SelectedIndexChanged_Event()
    {
        try
        {
            if (ddlStatus.SelectedValue == "5" || ddlStatus.SelectedValue == "3")
            {
                ddlProgress.Enabled = true;
            }
            else if (ddlStatus.SelectedValue == "7")
            {
                txtComments.Text = "Submitted for checking.";
                ddlProgress.SelectedIndex = 0;
                ddlProgress.Enabled = false;
            }
            else
            {
                txtComments.Text = String.Empty;
                ddlProgress.SelectedIndex = 0;
                ddlProgress.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GenerateReport()
    {
        try
        {
            //BindReportGrid();
            //GeneratePdf();
            GeneratePdfCrystal();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GeneratePdfCrystal()
    {
        try
        {
            DataTable dt = ReportData();
            rprt.Load(Server.MapPath("~/Reports/rptCADDailyProjectReport.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = "CAD Daily Project Report - " + DateTime.Now.ToString("dddd, dd MMMM yyyy").Replace(',', ' ');
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

    #endregion

    #region Sort

    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "DESC"; }
        set { ViewState["SortDirection"] = value; }
    }

    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        switch (GridViewSortDirection)
        {
            case "ASC":
                GridViewSortDirection = "DESC";
                break;

            case "DESC":
                GridViewSortDirection = "ASC";
                break;
        }
        return GridViewSortDirection;
    }

    #endregion

    #region Reset

    private void Reset()
    {
        try
        {
            BindControls();
            EnableSubHeaderSection();
            //if (ddlReportDateHeaderList.Items.Count > 0)
            //{
            //    ddlReportDateHeaderList.SelectedIndex = 0;
            //}

            if (ddlPNumberHeaderList.Items.Count > 0)
            {
                ddlPNumberHeaderList.SelectedIndex = 0;
            }

            ResetInfo();
            btnSave.Text = "Save";
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
            gvDetail.DataSource = "";
            gvDetail.DataBind();
            txtReportDate.Text = string.Empty;
            if (ddlNature.Items.Count > 0)
            {
                ddlNature.SelectedIndex = 0;
            }

            //if (ddlPNumber.Items.Count > 0)
            //{
            //    ddlPNumber.SelectedIndex = 0;
            //}
            HfPNumber.Value = "-1";

            if (ddlProjectDesc.Items.Count > 0)
            {
                ddlProjectDesc.SelectedIndex = 0;
            }

            if (ddlStatus.Items.Count > 0)
            {
                ddlStatus.SelectedIndex = 0;
            }
            if (ddlProgress.Items.Count > 0)
            {
                ddlProgress.SelectedIndex = 0;
                ddlProgress.Enabled = false;
            }
            if (ddlProjectEngineer.Items.Count > 0)
            {
                ddlProjectEngineer.SelectedIndex = 0;
            }

            txtCorrection.Text = string.Empty;
            txtProjectManager.Text = string.Empty;
            txtReqByRCD.Text = string.Empty;
            txtReqForwardedToIndia.Text = string.Empty;
            txtProjectSendToRCD.Text = string.Empty;
            txtComments.Text = string.Empty;
            // txtCommentsByEngineer.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            //chkIsUrgent.Checked = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    protected void txtSearchPNum_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CallPNum();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CallPNum()
    {
        try
        {
            if (txtSearchPNum.Text != "")
            {
                string OutPnumber = "";
                OutPnumber = txtSearchPNum.Text.ToUpper();
                HfPNumber.Value = OutPnumber;
                LoadRelevantInfoForPNumberSync(true);
                SyncTextbox("NUM", OutPnumber);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void txtSearchPName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtSearchPName.Text != "")
            {
                string output = txtSearchPName.Text;
                int openTagEndPosition = output.IndexOf("#");
                output = output.Substring(openTagEndPosition + 1);
                HfPNumber.Value = output;
                LoadRelevantInfoForPNumberSync(true);
                SyncTextbox("NAME", output);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlProgress_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlProgress.SelectedValue == "NS")
            {
                txtComments.Text = "Not Started";
            }
            else
            {
                txtComments.Text = String.Empty;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlNature_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlNature.SelectedValue == "14")
            {
                ddlStatus.SelectedValue = "4";
                ddlStatus_SelectedIndexChanged_Event();
            }
            else if (ddlNature.SelectedValue == "15")
            {
                ddlStatus.SelectedValue = "3";
                ddlStatus_SelectedIndexChanged_Event();
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
                    dt = Utility.ReturnProposals(23, text);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchPName.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                    }
                    else
                    {
                        //Utility.ShowMessage(this, "P# not found");
                        Utility.ShowMessage_Error(Page, "P# not found");
                        txtSearchPName.Text = "";
                        txtSearchPNum.Text = "";
                    }
                }
                else
                {
                    dt = Utility.ReturnProposals(24, text);
                    if (dt.Rows.Count > 0)
                    {
                        txtSearchPNum.Text = Convert.ToString(dt.Rows[0]["PNumber"]);
                    }
                    else
                    {
                        //Utility.ShowMessage(this, "P# not found");
                        Utility.ShowMessage_Error(Page, "P# not found");
                        txtSearchPNum.Text = "";
                        txtSearchPName.Text = "";
                    }
                }                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}