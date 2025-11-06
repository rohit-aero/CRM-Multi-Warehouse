using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using BOLAERO;
using BLLAERO;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Text;

public partial class INVManagement_frmRequisitionNew : System.Web.UI.Page
{
    DataTable dt_DropdownData = new DataTable();
    BOLRequisition ObjBOL = new BOLRequisition();
    BLLRequisition ObjBLL = new BLLRequisition();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Utility.IsAuthorized())
        {
            if (!IsPostBack)
            {
                Bind_Controls();
                BindReqNo();
                BindStatus();               
            }
        }        
    }

    private void ShowPartsPopUp()
    {
        try
        {
            //string strMethodName = "ShowPoup();";
           // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
            ModalPopupExtenderShowParts.Show();
            BindStatus();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void HidePopUp()
    {
        try
        {
            //string strMethodName = "HidePoup();";
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strMethodName, true);
            ModalPopupExtenderShowParts.Hide();
            BindStatus();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindPartsGrid()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 22;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ShowPartsPopUp();
                gvShowParts.DataSource = ds.Tables[0];
                gvShowParts.DataBind();            
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    protected void btnShowParts_Click(object sender, EventArgs e)
    {
        try
        {
            BindPartsGrid();
            BindStatus();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable CheckPartsAlreadyAddedInGrid()
    {
        DataTable dtCheckExistingPartsData = new DataTable();
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 24;
            if (ddlReq.Items.Count > 0)
            {
                if (ddlReq.SelectedIndex > 0)
                {
                    ObjBOL.Reqid = Convert.ToInt32(ddlReq.SelectedValue);
                }                
            }
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dtCheckExistingPartsData = ds.Tables[0];
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtCheckExistingPartsData;
    }


    private DataTable EmptyDT()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.TableName = "AddParts";
            dt.Columns.Add(new DataColumn("ReqId", typeof(int)));            
            dt.Columns.Add(new DataColumn("PartId", typeof(int)));
            dt.Columns.Add(new DataColumn("Partnumber", typeof(string)));
            dt.Columns.Add(new DataColumn("PartDesc", typeof(string)));
            dt.Columns.Add(new DataColumn("ProductCode", typeof(string)));
            dt.Columns.Add(new DataColumn("Source", typeof(string)));
            dt.Columns.Add(new DataColumn("Department", typeof(string)));
            dt.Columns.Add(new DataColumn("UM", typeof(string)));
            dt.Columns.Add(new DataColumn("MinQty", typeof(string)));
            dt.Columns.Add(new DataColumn("MaxQty", typeof(string)));
            dt.Columns.Add(new DataColumn("StockInHand", typeof(string)));
            dt.Columns.Add(new DataColumn("OrderQty", typeof(string)));
            ViewState["AddParts"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }


    private Boolean SavePopupPartDetails()
    {
        try
        {            
            DataTable dtExistingParts=(DataTable)CheckPartsAlreadyAddedInGrid();
            DataTable dt=(DataTable)EmptyDT();
            DataRow dr;
            foreach (GridViewRow row in gvShowParts.Rows)
            {
                int minqty = 0;
                int qty = 0;
                dr =dt.NewRow();
                int ID = Convert.ToInt32(gvShowParts.DataKeys[row.RowIndex].Value);
                Label lblPartNo = ((Label)row.FindControl("lblPartNo"));
                Label lblPartDesc = ((Label)row.FindControl("lblPartDesc"));
                Label lblProductCode = ((Label)row.FindControl("lblProductCode"));
                Label lblSource = ((Label)row.FindControl("lblSource"));
                Label lblDepartment = ((Label)row.FindControl("lblDepartment"));
                Label lblUM = ((Label)row.FindControl("lblUM"));
                Label lblMin = ((Label)row.FindControl("lblMin"));
                Label lblMax = ((Label)row.FindControl("lblMax"));
                Label lblStockInHand = ((Label)row.FindControl("lblStockInHand"));
                TextBox txtQty = ((TextBox)row.FindControl("txtQty"));
                if (ddlReq.Items.Count > 0)
                {
                    if (ddlReq.SelectedIndex > 0)
                    {
                        dr[0] = ddlReq.SelectedValue;
                    }
                    else
                    {
                        Savedata();
                        dr[0] = HfReqID.Value;
                    }
                }
                else
                {
                    if(HfReqID.Value == "-1")
                    {
                        Savedata();
                    }
                    dr[0] = HfReqID.Value;
                }
                dr[1] = ID;
                dr[2] = lblPartNo.Text;
                dr[3] = lblPartDesc.Text;
                dr[4] = lblProductCode.Text;
                dr[5] = lblSource.Text;
                dr[6] = lblDepartment.Text;
                dr[7] = lblUM.Text;
                dr[8] = lblMin.Text;
                dr[9] = lblMax.Text;
                dr[10] = lblStockInHand.Text;
                if(lblMin.Text != "")
                {
                    minqty = Convert.ToInt32(lblMin.Text);
                }            
                if(txtQty.Text == "")
                {
                    dr[11] = qty;
                }
                else
                {
                    dr[11] = txtQty.Text;
                    qty = Convert.ToInt32(txtQty.Text);
                }
                if(txtQty.Text != "")
                {
                    if (qty < minqty)
                    {
                        Utility.ShowMessage_Error(Page, "Please enter order qty greater than min !");
                        txtQty.Focus();
                        txtQty.Text = "";
                        HfCheckDuplicateParts.Value = "false";
                        return false;
                    }
                }                
                           
                dt.Rows.Add(dr);
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow drdelete = dt.Rows[i];
                    if (drdelete["OrderQty"].ToString() == Convert.ToString(0))
                    {
                        drdelete.Delete();
                    }
                }
                
                if (dtExistingParts.Rows.Count > 0)
                {
                    foreach (DataRow newRow in dt.AsEnumerable().ToList())
                    {
                        bool isDuplicate = dtExistingParts.AsEnumerable().Any(existingRow =>
                        existingRow.Field<int>("ID") == newRow.Field<int>("PartId"));

                        if (isDuplicate)
                        {
                            Utility.ShowMessage_Error(Page, "Part no already exists. !");
                            txtQty.Text = "";
                            dt.Rows.Remove(newRow);
                            txtQty.Focus();
                            return false;
                        }
                    }
                   
                }
                dt.AcceptChanges();
            }
            ViewState["AddParts"] = dt;
            HfCheckDuplicateParts.Value = "true";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            BindStatus();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }      
    }

    protected void btnAddParts_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                if(SaveReqDataOnShowParts() == true)
                {
                    if (HfCheckDuplicateParts.Value == "true")
                    {
                        //Add functionality to Show Parts In Grid View Main
                        DataTable dtCheckRows = (DataTable)ViewState["AddParts"];
                        if (dtCheckRows.Rows.Count > 0)
                        {
                            string msg = string.Empty;
                            ObjBOL.Operation = 23;
                            if (ddlReq.Items.Count > 0)
                            {
                                if (ddlReq.SelectedIndex == 0)
                                {
                                    ObjBOL.Reqid = Convert.ToInt32(HfReqID.Value);
                                }
                                else
                                {
                                    ObjBOL.Reqid = Convert.ToInt32(ddlReq.SelectedValue);
                                }
                            }
                            else
                            {
                                ObjBOL.Reqid = Convert.ToInt32(HfReqID.Value);
                            }
                            DataTable dtselected = (DataTable)ViewState["AddParts"];
                            DataView dv = new DataView(dtselected);
                            DataTable dtTemp = dv.ToTable("selected", false, "ReqId", "PartId", "OrderQty");
                            ObjBOL.dtPopUpParts = dtTemp;
                            msg = ObjBLL.SavePopUpParts(ObjBOL);
                            Bind_Grid();
                            HidePopUp();
                        }
                        else
                        {
                            ShowPartsPopUp();
                        }
                    }
                    else
                    {
                        ShowPartsPopUp();
                    }                         
                }
                else
                {
                    ShowPartsPopUp();
                }                  
            }
            else
            {
                ShowPartsPopUp();
            }
            BindStatus();     
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private bool SaveReqDataOnShowParts()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                if (SavePopupPartDetails() == true)
                {
                    DataTable dtShowParts = (DataTable)ViewState["AddParts"];
                    if (dtShowParts.Rows.Count > 0)
                    {
                        string msg = "";
                        ObjBOL.ReqNo = txtReqNo.Text;
                        if (ddlPreparedby.Items.FindByValue(ddlPreparedby.SelectedValue) != null)
                        {
                            ObjBOL.PreparedBy = Convert.ToInt32(ddlPreparedby.SelectedValue);
                        }
                        if (ddlApprovedby.Items.FindByValue(ddlApprovedby.SelectedValue) != null)
                        {
                            ObjBOL.AppBy = Convert.ToInt32(ddlApprovedby.SelectedValue);
                        }
                        DateTime currentDate = DateTime.Now;
                        if (txtTentativeshipdate.Text != "")
                        {
                            ObjBOL.TentativeShipDate = Utility.ConvertDate(txtTentativeshipdate.Text);
                        }
                        ObjBOL.LoginUserId = Convert.ToInt32(Utility.GetCurrentSession().EmployeeID);
                        if (ddlReqStatus.Items.FindByValue(ddlReqStatus.SelectedValue) != null)
                        {
                            ObjBOL.ReqStatus = Convert.ToInt32(ddlReqStatus.SelectedValue);
                        }
                        if (ddlReq.Items.Count > 0)
                        {
                            ObjBOL.Reqid = Convert.ToInt32(ddlReq.SelectedValue);
                        }
                        if (btnAdd.Text == "Update")
                        {
                            ObjBOL.ReqDetailID = Convert.ToInt32(HfReqDetailID.Value);
                        }
                        if (ddlReq.SelectedIndex > 0)
                        {
                            ObjBOL.Operation = 17;
                        }
                        else
                        {
                            ObjBOL.Operation = 3;
                        }
                        msg = ObjBLL.SaveRequisitionData(ObjBOL);
                        if (msg == "2627")
                        {
                            Utility.ShowMessage_Error(Page, "Duplicate Requisition !!");
                            return false;
                        }
                        else
                        {
                            if (ddlPreparedByList.SelectedIndex == 0)
                            {
                                HfReqID.Value = msg;
                                Utility.ShowMessage_Success(Page, "Requisition Added Successfully !");
                            }
                            else
                            {
                                Utility.ShowMessage_Success(Page, "Requisition Updated Successfully !");
                            }
                            ddlPreparedByList.SelectedValue = ObjBOL.PreparedBy.ToString();
                            BindReqNoOnPreparedBy();
                            ddlReq.SelectedValue = msg;                            
                            btnSave.Text = "Update";
                            CheckStatus();
                        }
                    }
                    else
                    {
                        Utility.ShowMessage_Error(Page, "Please Enter Atleast One Part !");
                    }
                    
                }
               
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    #region BIND FUNCTIONS
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControlsData(ObjBOL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPreparedByList, ds.Tables[0]);
                Utility.BindDropDownList(ddlPreparedby, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlApprovedby, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlfooterpartno, ds.Tables[2]);
                Utility.BindDropDownList(ddlfooterpartinfo, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlOrderType, ds.Tables[3]);
                ddlOrderType.SelectedValue = "1";
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRequestor, ds.Tables[4]);
                ddlRequestor.SelectedValue = "110";
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void GetEngDep()
    {
        try
        {
            String msg = "";
            ObjBOL.Operation = 18;
            ObjBOL.LoginUserId = Utility.GetCurrentSession().EmployeeID;
            msg = ObjBLL.GetRequisition(ObjBOL);
            if(msg== "7")
            {
                HfEngDepID.Value = msg;
            }
            else
            {
                HfEngDepID.Value = String.Empty;
            }
            foreach (ListItem item in ddlReqStatus.Items)
            {
                if (msg != "7")
                {
                    if (item.Text != "Select" && item.Text != "Draft" && item.Text != "Submitted for review")
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                }
                else
                {                    
                    item.Attributes.Add("enabled", "enabled");
                }
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindStatus()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 15;
            ObjBOL.LoginUserId = Utility.GetCurrentSession().EmployeeID;
            if (ddlReq.Items.Count > 0)
            {
                ObjBOL.Reqid = Convert.ToInt32(ddlReq.SelectedValue);
            }
            HfReqStatus.Value = ddlReqStatus.SelectedValue;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ClearDropdown(ddlReqStatus);
                Utility.BindDropDownList(ddlReqStatus, ds.Tables[0]);
                GetEngDep();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                if (ddlReqStatus.Items.FindByValue(ds.Tables[1].Rows[0]["ReqStatus"].ToString()) != null)
                {
                    ddlReqStatus.SelectedValue = ds.Tables[1].Rows[0]["ReqStatus"].ToString();
                }
                else
                {
                    ddlReqStatus.SelectedIndex = 0;
                }
            }
            else
            {
                ddlReqStatus.SelectedValue = HfReqStatus.Value;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ChkPermissionRequisitionSubmit()
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 9;
            ObjBOL.LoginUserId = Utility.GetCurrentSession().EmployeeID;
            if (ddlReq.Items.Count > 0)
            {
                if (ddlReq.SelectedIndex > 0)
                {
                    ObjBOL.Reqid = Convert.ToInt32(ddlReq.SelectedValue);
                    msg = ObjBLL.GetRequisition(ObjBOL);
                    if (msg == "1")
                    {
                        btnSubmit.Visible = true;
                    }
                    else
                    {
                        btnSubmit.Visible = false;
                    }
                }
                else
                {
                    btnSubmit.Visible = false;
                }
            }
            else
            {
                btnSubmit.Visible = false;
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region VALIDATION FUNCTION
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtReqNo.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Generate Requisition #. !');", true);
                Utility.ShowMessage_Error(Page, "Please Generate Requisition #. !");
                txtReqNo.Focus();
                return false;
            }
            if (ddlPreparedby.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select PreparedBy. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select PreparedBy. !");
                ddlPreparedby.Focus();
                return false;
            }
            if (ddlReqStatus.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select PreparedBy. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Status. !");
                ddlReqStatus.Focus();
                return false;
            }
            if (ddlReqStatus.SelectedValue == "2")
            {
                if (ddlApprovedby.SelectedIndex == 0)
                {
                    Utility.ShowMessage_Error(Page, "Please Select Approved by. !");
                    ddlApprovedby.Focus();
                    return false;
                }
            }


        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private Boolean ValidationCheckAppBy()
    {
        try
        {
            if (ddlApprovedby.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Generate Requisition #. !');", true);
                Utility.ShowMessage_Error(Page, "Please Select App By.");
                ddlApprovedby.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private Boolean ValidationCheckPartDetails()
    {
        try
        {
            if (ddlfooterpartno.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Part#. !");
                ddlfooterpartno.Focus();
                return false;
            }
            if (txtfooterqty.Text == "" || txtfooterqty.Text == "0")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Order Quantity. !");
                txtfooterqty.Text = String.Empty;
                txtfooterqty.Focus();
                return false;
            }
            if (ddlOrderType.SelectedValue == "4")
            {
                if (txtcomments.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Comments. !");
                    txtcomments.Focus();
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    #endregion

    #region EVENT FUNCTIONS LIKE Btn_Click, ddl_SelectedIndexChanged, gv_RowDelete etc.
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 2;
            msg = ObjBLL.GetRequisition(ObjBOL);
            if (msg != "")
            {
                txtReqNo.Text = msg;
                DateTime currentDate = DateTime.Now;
                DateTime threeMonthsLater = currentDate.AddDays(90);
                txtTentativeshipdate.Text = threeMonthsLater.ToString("MM/dd/yyyy");
                btnSave.Text = "Save";
            }
            else
            {
                txtReqNo.Text = String.Empty;
            }
            Reset();
            ResetDetails();
            ResetGrid();
            BindReqNo();
            ResetReqStatus();
            ddlPreparedByList.SelectedIndex = 0;
            btnAdd.Text = "Add";
            btnSubmit.Visible = false;
            ButtonEnabled();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool Savedata()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                string msg = "";
                ObjBOL.ReqNo = txtReqNo.Text;
                if (ddlPreparedby.Items.FindByValue(ddlPreparedby.SelectedValue) != null)
                {
                    ObjBOL.PreparedBy = Convert.ToInt32(ddlPreparedby.SelectedValue);
                }
                if (ddlApprovedby.Items.FindByValue(ddlApprovedby.SelectedValue) != null)
                {
                    ObjBOL.AppBy = Convert.ToInt32(ddlApprovedby.SelectedValue);
                }
                DateTime currentDate = DateTime.Now;
                if(txtTentativeshipdate.Text != "")
                {
                    ObjBOL.TentativeShipDate = Utility.ConvertDate(txtTentativeshipdate.Text);
                }               
                ObjBOL.LoginUserId = Convert.ToInt32(Utility.GetCurrentSession().EmployeeID);
                if (ddlReqStatus.Items.FindByValue(ddlReqStatus.SelectedValue) != null)
                {
                    ObjBOL.ReqStatus = Convert.ToInt32(ddlReqStatus.SelectedValue);
                }
                if (ddlReq.Items.Count > 0)
                {
                    ObjBOL.Reqid = Convert.ToInt32(ddlReq.SelectedValue);
                }
                if (btnAdd.Text == "Update")
                {
                    ObjBOL.ReqDetailID = Convert.ToInt32(HfReqDetailID.Value);
                }
                if (ddlReq.SelectedIndex > 0)
                {
                    ObjBOL.Operation = 17;
                }
                else
                {
                    ObjBOL.Operation = 3;
                }                
                msg = ObjBLL.SaveRequisitionData(ObjBOL);
                if(msg == "2627")
                {
                    Utility.ShowMessage_Error(Page, "Duplicate Requisition !!");
                    return false;
                }
                else
                {
                    if (ddlPreparedByList.SelectedIndex == 0)
                    {
                        HfReqID.Value = msg;
                        Utility.ShowMessage_Success(Page, "Requisition Added Successfully !!");
                    }
                    else
                    {
                        Utility.ShowMessage_Success(Page, "Requisition Updated Successfully !!");
                    }
                    ddlPreparedByList.SelectedValue = ObjBOL.PreparedBy.ToString();
                    BindReqNoOnPreparedBy();
                    ddlReq.SelectedValue = msg;
                    Bind_Grid();
                    btnSave.Text = "Update";
                    CheckStatus();
                }                
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }  

    private void SavePartDetails()
    {
        try
        {
            string msg = "";
            if (btnAdd.Text == "Update")
            {
                ObjBOL.Operation = 12;
                ObjBOL.ReqDetailID = Convert.ToInt32(HfReqDetailID.Value);
            }
            else
            {
                ObjBOL.Operation = 11;
            }
            ObjBOL.LoginUserId = Utility.GetCurrentSession().EmployeeID;
            if (ddlReq.SelectedIndex > 0)
            {
                ObjBOL.Reqid = Convert.ToInt32(ddlReq.SelectedValue);
            }
            if (ddlfooterpartno.SelectedIndex > 0)
            {
                ObjBOL.PartId = Convert.ToInt32(ddlfooterpartno.SelectedValue);
            }
            if (lblSourceID.Text != "")
            {
                ObjBOL.VendorID = Convert.ToInt32(lblSourceID.Text);
            }
            if (ddlOrderType.SelectedIndex > 0)
            {
                ObjBOL.OrderType = Convert.ToInt32(ddlOrderType.SelectedValue);
            }
            if (ddlShipBy.SelectedIndex > 0)
            {
                ObjBOL.ShipBy = Convert.ToInt32(ddlShipBy.SelectedValue);
            }
            if (ddlRequestor.SelectedIndex > 0)
            {
                ObjBOL.Requestor = Convert.ToInt32(ddlRequestor.SelectedValue);
            }

            int InTransitQty = 0;
            if (lblInTransit.Text != "")
            {
                InTransitQty = Convert.ToInt32(lblInTransit.Text);
            }
            int OrderQty = 0;
            if (txtfooterqty.Text != "")
            {
                OrderQty = Convert.ToInt32(txtfooterqty.Text);
            }
            //if(OrderQty<InTransitQty && InTransitQty>0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "text", "IndexChange();", true);                
            //}
            int ReOrderQty = 0;
            if (lblReOrder.Text != "")
            {
                ReOrderQty = Convert.ToInt32(lblReOrder.Text);
            }
            //if(ReOrderQty>OrderQty)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "MyFunctionCall", "IndexChange();", true);
            //}
            if (txtfooterqty.Text != "")
            {
                ObjBOL.PartQty = Convert.ToInt32(txtfooterqty.Text);
            }
            ObjBOL.Priority = Convert.ToBoolean(chkfooterPriority.Checked);
            ObjBOL.Remarks = txtcomments.Text;
            msg = ObjBLL.SaveRequisitionData(ObjBOL);
            if (msg == "Part No Already Exists !!")
            {
                Utility.ShowMessage_Error(Page, msg);
            }
            else
            {
                Utility.ShowMessage_Success(Page, msg);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindReqNoOnPreparedBy()
    {
        try
        {
            if (ddlPreparedByList.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 6;
                ObjBOL.LoginUserId = Utility.GetCurrentSession().EmployeeID;
                if (ddlPreparedByList.Items.FindByValue(ddlPreparedByList.SelectedValue) != null)
                {
                    ObjBOL.PreparedBy = Convert.ToInt32(ddlPreparedByList.SelectedValue);
                }
                ds = ObjBLL.GetControlsData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Utility.BindDropDownList(ddlReq, ds.Tables[0]);
                }
                else
                {
                    ddlReq.DataSource = "";
                    ddlReq.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void SavePartInfoandDetail()
    {
        try
        {
            if (Savedata() == true)
            {
                if (ddlfooterpartno.SelectedIndex > 0)
                {
                    if (ValidationCheckPartDetails() == true)
                    {
                        SavePartDetails();
                        ResetDetails();
                        Bind_Grid();
                        btnAdd.Text = "Add";
                        btnSave.Enabled = true;

                    }

                }
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
            if (ddlReqStatus.SelectedValue == "0" || ddlReqStatus.SelectedValue == "1")
            {
                SavePartInfoandDetail();
                BindStatus();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindOrderListInGridView()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[3].Rows.Count > 0)
            {
                dt_DropdownData = ds.Tables[3];
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearDropdown(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            ddl.SelectedValue = null;
            ddl.Text = null;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    private void BindReqNo()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 7;
            ObjBOL.LoginUserId = Utility.GetCurrentSession().EmployeeID;
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ClearDropdown(ddlReq);
                Utility.BindDropDownList(ddlReq, ds.Tables[0]);
                ddlReq.SelectedIndex = 0;
            }
            else
            {
                ddlReq.DataSource = "";
                ddlReq.DataBind();
            }
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
            ResetDetails();
            Reset();
            ResetGrid();
            txtReqNo.Text = String.Empty;
            ddlPreparedByList.SelectedIndex = 0;
            BindReqNo();
            ResetReqStatus();
            txtTentativeshipdate.Text = String.Empty;
            btnAdd.Text = "Add";
            btnSave.Enabled = true;
            btnAdd.Enabled = true;
            btnShowParts.Enabled = true;
            InTransit.Visible = false;
            DivInShop.Visible = false;
            DivInStock.Visible = false;
            btnSubmit.Visible = false;
            btnGenerate.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void AddDetails()
    {
        try
        {
            if (ddlReq.SelectedIndex == 0 || ddlReq.SelectedIndex == -1)
            {
                if (Savedata() == true)
                {
                    SavePartDetails();
                    ResetDetails();
                    Bind_Grid();
                    btnAdd.Text = "Add";
                }
            }
            else
            {
                SavePartDetails();
                ResetDetails();
                Bind_Grid();
                btnAdd.Text = "Add";
            }
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
            if (ValidationCheck() == true)
            {
                if (ValidationCheckPartDetails() == true)
                {
                    AddDetails();                    
                }
            }
            BindStatus();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataZero();
            rprt.Load(Server.MapPath("~/Reports/rptGenerateRequisition.rpt"));
            if (dt.Rows.Count > 0)
            {
                string reqNo = ddlReq.SelectedItem.Text;
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, reqNo);
            }
            else
            {
                Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
            }
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
        finally
        {
            rprt.Close();
            rprt.Dispose();
        }
    }

    private void SubmitReq()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                if (ValidationCheckAppBy() == true)
                {
                    DataTable dt = new DataTable();
                    dt = ReportDataZero();
                    if (dt.Rows.Count > 0)
                    {
                        string msg = "";
                        ObjBOL.Operation = 8;
                        if (ddlReq.Items.FindByValue(ddlReq.SelectedValue) != null)
                        {
                            ObjBOL.Reqid = Convert.ToInt32(ddlReq.SelectedValue);
                        }
                        ObjBOL.LoginUserId = Convert.ToInt32(Utility.GetCurrentSession().EmployeeID);
                        msg = ObjBLL.UpdateIsSubmitted(ObjBOL);
                        Utility.ShowMessage_Success(Page, msg);
                        SendEmail_Prepare();
                        Reset();
                        ResetDetails();
                        ResetGrid();
                        txtReqNo.Text = String.Empty;
                        ddlPreparedByList.SelectedIndex = 0;
                        txtTentativeshipdate.Text = String.Empty;
                        BindReqNo();
                        btnSubmit.Visible = false;
                        btnGenerate.Enabled = false;
                        ButtonDisabled();
                    }
                    else
                    {
                        Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SubmitReq();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetLink()
    {
        try
        {
            if (lblInTransit.Text == "" || lblInTransit.Text == "0")
            {
                lblInTransit.Attributes.Remove("href");
                if (lblInTransit.Enabled != false)
                {
                    lblInTransit.Enabled = false;
                }
            }
            else if(lnkInStock.Text == "" || lnkInStock.Text == "0")
            {
                lnkInStock.Attributes.Remove("href");
                if (lnkInStock.Enabled != false)
                {
                    lnkInStock.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindPartDetails()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            if (ddlfooterpartno.Items.FindByValue(ddlfooterpartno.SelectedValue) != null)
            {
                ObjBOL.partid = Convert.ToInt32(ddlfooterpartno.SelectedValue);
            }
            ds = ObjBLL.GetPartDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
                {
                    {"Source", d=>
                        {
                            txtSource.Text=Convert.ToString(d["Source"]);
                            if(txtSource.Text != "")
                            {
                                lblSourceID.Text=Convert.ToString(d["SourceID"]);
                            }
                        }
                    },
                    { "ProductCode", d=> lblProductCode.Text=Convert.ToString(d["ProductCode"])},
                    { "UM", d=> lblUm.Text=Convert.ToString(d["UM"])},
                    { "Department", d=> lblDepartment.Text=Convert.ToString(d["Department"])},
                    { "stockinhand", d=>
                        {
                            lnkInStock.Text=Convert.ToString(d["stockinhand"]);
                            if(lnkInStock.Text != "")
                            {
                                DivInStock.Visible=true;
                            }
                            else
                            {
                                DivInStock.Visible=false;
                            }
                        }
                        

                    },
                    { "reorder", d=> lblReOrder.Text=Convert.ToString(d["reorder"]) },
                    { "InTransit", d=>
                        {
                            lblInTransit.Text=Convert.ToString(d["InTransit"]);
                            if (lblInTransit.Text != "")
                            {
                                InTransit.Visible = true;
                            }
                            else
                            {
                                InTransit.Visible = false;
                            }
                        }
                    },
                    {"InShop", d=>
                        {
                            lnkInShop.Text=Convert.ToString(d["InShop"]);
                            if (lnkInShop.Text != "")
                            {
                                DivInShop.Visible = true;
                            }
                            else
                            {
                                DivInShop.Visible = false;
                            }
                        }
                    },
                    {"reorderqty", d=>
                        {
                            if (Convert.ToString(d["reorderqty"]) != "")
                            {
                                HfReOrder.Value=Convert.ToString(d["reorderqty"]);
                                txtfooterqty.Text = HfReOrder.Value;
                            }
                         }
                    }
                };
                foreach (var assignment in assignments)
                {
                    try
                    {
                        assignment.Value(dr);
                    }
                    catch (Exception ex)
                    {
                        Utility.AddEditException(ex, assignment.Key);
                    }
                }
            }
            else
            {
                ResetDetailsOnPartNoandDesc();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    protected void lblInTransit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlfooterpartno.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                if (ddlfooterpartno.Items.FindByValue(ddlfooterpartno.SelectedValue) != null)
                {
                    ObjBOL.partid = Convert.ToInt32(ddlfooterpartno.SelectedValue);
                }
                ObjBOL.Operation = 1;
                ds = ObjBLL.GetTransitionData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvInTransit.DataSource = ds.Tables[0];
                    gvInTransit.DataBind();
                    lblPartNumber.Text = ds.Tables[0].Rows[0]["Partnumber"].ToString();
                    ModalPopupExtender1.Show();
                }
                else
                {
                    gvInTransit.DataSource = "";
                    gvInTransit.DataBind();
                    lblPartNumber.Text = String.Empty;
                    ModalPopupExtender1.Hide();
                }
            }
            BindStatus();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void lnkInStock_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlfooterpartno.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                if (ddlfooterpartno.Items.FindByValue(ddlfooterpartno.SelectedValue) != null)
                {
                    ObjBOL.partid = Convert.ToInt32(ddlfooterpartno.SelectedValue);
                }                
                ds = ObjBLL.GetInStockData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvInsTock.DataSource = ds.Tables[1];
                    gvInsTock.DataBind();
                    lblInStockPartNumber.Text = ds.Tables[0].Rows[0]["PartNumber"].ToString();
                    ModalPopupStockIn.Show();
                }
                else
                {
                    gvInsTock.DataSource = "";
                    gvInsTock.DataBind();
                    lblInStockPartNumber.Text = String.Empty;
                    ModalPopupStockIn.Hide();
                }
            }
            BindStatus();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindAllDetails()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            if (ddlReq.Items.FindByValue(ddlReq.SelectedValue) != null)
            {
                ObjBOL.Reqid = Convert.ToInt32(ddlReq.SelectedValue);
            }
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlReq.SelectedValue = ObjBOL.Reqid.ToString();
                DataRow dr = ds.Tables[0].Rows[0];
                Dictionary<string, Action<DataRow>> assignments = new Dictionary<string, Action<DataRow>>
                {
                    {"ReqNo", d=> txtReqNo.Text=Convert.ToString(d["ReqNo"]) },
                    {"PreparedBy", d=>
                        {
                            if(ddlPreparedby.Items.FindByValue(Convert.ToString(d["PreparedBy"])) != null)
                            {
                                ddlPreparedby.SelectedValue=Convert.ToString(d["PreparedBy"]);
                                ddlPreparedByList.SelectedValue=ddlPreparedby.SelectedValue;
                                BindReqNoOnPreparedBy();
                            }
                        }
                    },
                    { "AppBy", d=> {
                        if(ddlApprovedby.Items.FindByValue(Convert.ToString(d["AppBy"])) != null)
                        {
                            ddlApprovedby.SelectedValue=Convert.ToString(d["AppBy"]);
                        }

                    }

                  },
                  {"TentativeShipDate" , d=> txtTentativeshipdate.Text=Convert.ToString(d["TentativeShipDate"]) },
                  {"ReqStatus", d=>
                    {
                        if(ddlReqStatus.Items.FindByValue(Convert.ToString(d["ReqStatus"])) != null)
                        {
                            ddlReqStatus.SelectedValue=Convert.ToString(d["ReqStatus"]);
                        }
                    }
                  }

                };
                foreach (var assignment in assignments)
                {
                    try
                    {
                        assignment.Value(dr);
                    }
                    catch (Exception ex)
                    {
                        Utility.AddEditException(ex, assignment.Key);
                    }
                }
                //txtReqNo.Text = ds.Tables[0].Rows[0]["ReqNo"].ToString();
                //if (ddlPreparedby.Items.FindByValue(ds.Tables[0].Rows[0]["PreparedBy"].ToString()) != null)
                //{
                //    ddlPreparedby.SelectedValue = ds.Tables[0].Rows[0]["PreparedBy"].ToString();
                //    ddlPreparedByList.SelectedValue = ddlPreparedby.SelectedValue;
                //    BindReqNoOnPreparedBy();
                //}
                //ddlReq.SelectedValue = ObjBOL.Reqid.ToString();
                //if (ddlApprovedby.Items.FindByValue(ds.Tables[0].Rows[0]["AppBy"].ToString()) != null)
                //{
                //    ddlApprovedby.SelectedValue = ds.Tables[0].Rows[0]["AppBy"].ToString();
                //}
                //txtTentativeshipdate.Text = ds.Tables[0].Rows[0]["TentativeShipDate"].ToString();
                //if (ddlReqStatus.Items.FindByValue(ds.Tables[0].Rows[0]["ReqStatus"].ToString()) != null)
                //{
                //    ddlReqStatus.SelectedValue = ds.Tables[0].Rows[0]["ReqStatus"].ToString();
                //}
            }
            Bind_Grid();
        }

        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ButtonDisabled()
    {
        try
        {
            btnSave.Enabled = false;
            btnAdd.Enabled = false;
            btnShowParts.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ButtonEnabled()
    {
        try
        {
            btnGenerate.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = true;
            btnShowParts.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void CheckStatus()
    {
        try
        {
            string msg = String.Empty;
            int userID = Utility.GetCurrentSession().EmployeeID;
            ObjBOL.Operation = 14;
            if (ddlReq.Items.FindByValue(ddlReq.SelectedValue) != null)
            {
                ObjBOL.Reqid = Convert.ToInt32(ddlReq.SelectedValue);
            }
            msg = ObjBLL.CheckApprovedStatus(ObjBOL);
            if (msg == "3")
            {
                HfChekStatus.Value = msg;
                HfEmployeeID.Value = userID.ToString();
                ButtonDisabled();
            }
            else if (HfEngDepID.Value != "7" && (msg == "2" || msg == "4" || msg == "5" || msg == "6"))
            {
                HfChekStatus.Value = msg;
                HfEmployeeID.Value = userID.ToString();
                ButtonDisabled();
            }
            else
            {
                HfChekStatus.Value = msg;
                HfEmployeeID.Value = userID.ToString();
                ButtonEnabled();
            }
            ChkPermissionRequisitionSubmit();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlReq_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Reset();
            ResetDetails();
            ResetGrid();
            txtReqNo.Text = String.Empty;
            txtTentativeshipdate.Text = String.Empty;
            btnGenerate.Enabled = true;
            if (ddlReq.SelectedIndex > 0)
            {
                BindAllDetails();
                BindStatus();
                CheckStatus();
                btnSave.Text = "Update";
            }
            else
            {
                ButtonEnabled();
                DisableControls();
                ResetReqStatus();
                btnSave.Text = "Save";
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
            gvRequition.DataSource = "";
            gvRequition.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPreparedByList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPreparedByList.SelectedIndex == 0)
            {
                BindReqNo();
            }
            else
            {
                BindReqNoOnPreparedBy();
            }
            Reset();
            ResetDetails();
            ResetGrid();
            DisableControls();
            ButtonEnabled();
            txtTentativeshipdate.Text = String.Empty;
            if (ddlReq.Items.Count > 0)
            {
                ddlReq.SelectedIndex = 0;
            }
            txtReqNo.Text = String.Empty;
            ResetReqStatus();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetDetailsOnPartNoandDesc()
    {
        try
        {
            lblProductCode.Text = String.Empty;
            lblUm.Text = String.Empty;
            lblDepartment.Text = String.Empty;
            lblReOrder.Text = String.Empty;
            lnkInShop.Text = String.Empty;
            lblInTransit.Text = String.Empty;
            lnkInStock.Text = String.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlfooterpartinfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlfooterpartinfo.SelectedIndex > 0)
            {
                ddlfooterpartno.SelectedValue = ddlfooterpartinfo.SelectedValue;
                BindPartDetails();
            }
            else
            {
                ResetDetails();
                ResetReqStatus();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Grid()
    {
        try
        {
            CheckStatus();
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            if (ddlReq.Items.FindByValue(ddlReq.SelectedValue) != null)
            {
                ObjBOL.Reqid = Convert.ToInt32(ddlReq.SelectedValue);
            }
            ds = ObjBLL.GetControlsData(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {
                gvRequition.DataSource = ds.Tables[1];
                gvRequition.DataBind();
            }
            else
            {
                ResetGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlfooterpartno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlfooterpartno.SelectedIndex > 0)
            {
                ddlfooterpartinfo.SelectedValue = ddlfooterpartno.SelectedValue;
                BindPartDetails();
                BindStatus();
            }
            else
            {
                ResetDetails();
                ResetReqStatus();
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetReqStatus()
    {
        try
        {
            BindStatus();
            ddlReqStatus.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvRequition_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string msg = "";
            int ID = Convert.ToInt32(gvRequition.DataKeys[e.RowIndex].Values[0]);
            Label Partid = gvRequition.Rows[e.RowIndex].FindControl("lblpartid") as Label;
            if (ddlReq.Items.FindByValue(ddlReq.SelectedValue) != null)
            {
                ObjBOL.Reqid = Convert.ToInt32(ddlReq.SelectedValue);
            }
            ObjBOL.LoginUserId = Utility.GetCurrentSession().EmployeeID;
            ObjBOL.Operation = 13;
            ObjBOL.ReqDetailID = ID;
            if (Partid.Text != "")
            {
                ObjBOL.PartId = Convert.ToInt32(Partid.Text);
            }
            msg = ObjBLL.DeleteReqData(ObjBOL);
            Utility.ShowMessage_Success(Page, "Req Deleted Successfully !!");
            Bind_Grid();
            ResetDetails();
            btnAdd.Text = "Add";
            btnSubmit.Visible = false;
            ButtonEnabled();
            BindStatus();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    #region Resets
    private void Reset()
    {
        try
        {
            ddlPreparedby.SelectedIndex = 0;
            ddlApprovedby.SelectedIndex = 0;
            ddlReqStatus.SelectedIndex = 0;
            btnSave.Text = "Save";
            divError.Visible = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetDetails()
    {
        try
        {
            ddlfooterpartno.SelectedIndex = 0;
            ddlfooterpartinfo.SelectedIndex = 0;
            ddlRequestor.SelectedValue = "110";
            txtSource.Text = String.Empty;
            lblSourceID.Text = String.Empty;
            lblProductCode.Text = String.Empty;
            lblUm.Text = String.Empty;
            lblDepartment.Text = String.Empty;
            lnkInStock.Text = String.Empty;
            lnkInShop.Text = String.Empty;
            lblInTransit.Text = String.Empty;
            lblReOrder.Text = String.Empty;
            InTransit.Visible = false;
            DivInShop.Visible = false;
            DivInStock.Visible = false;
            ddlOrderType.SelectedValue = "1";
            ddlShipBy.SelectedValue = "1";
            txtfooterqty.Text = string.Empty;
            chkfooterPriority.Checked = false;
            txtcomments.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region Report

    private DataTable ReportDataZero()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [IV].[INV_GenerateRequisition] '" + ddlReq.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    #endregion

    #region Enable/Disable controls

    private void EnableControls()
    {
        try
        {
            //btnSubmit.Enabled = true;
            btnGenerate.Enabled = true;
            btnSave.Enabled = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void DisableControls()
    {
        try
        {
            btnGenerate.Enabled = false;            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    private void PopupGridEmpty()
    {
        try
        {
            gvInTransit.DataSource = "";
            gvInTransit.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvRequition_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Select")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblID = (Label)clickedRow.FindControl("lblpartid");
                LinkButton lnkTranstit = (LinkButton)clickedRow.FindControl("lnkInTransit");
                if (lnkTranstit != null)
                {
                    if (lnkTranstit.Text == "0")
                    {
                        return;
                    }
                    hfpartid.Value = Convert.ToString(lblID.Text);
                    ObjBOL.partid = Convert.ToInt32(hfpartid.Value);
                    ObjBOL.Operation = 1;
                    ds = ObjBLL.GetTransitionData(ObjBOL);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvInTransit.DataSource = ds.Tables[0];
                        gvInTransit.DataBind();
                        lblPartNumber.Text = ds.Tables[0].Rows[0]["Partnumber"].ToString();
                        ModalPopupExtender1.Show();
                    }
                    else
                    {
                        gvInTransit.DataSource = "";
                        gvInTransit.DataBind();
                        lblPartNumber.Text = String.Empty;
                        ModalPopupExtender1.Hide();
                    }
                }
                BindStatus();
            }
            if (e.CommandName == "Select2")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblID = (Label)clickedRow.FindControl("lblpartid");
                LinkButton lnShop = (LinkButton)clickedRow.FindControl("lnkgvInShop");
                ObjBOL.partid = Convert.ToInt32(lblID.Text);
                ObjBOL.Operation = 1;
                ds = ObjBLL.GetInShopData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvInShop.DataSource = ds.Tables[0];
                    gvInShop.DataBind();
                    lblInShopPartNumber.Text = ds.Tables[0].Rows[0]["Partnumber"].ToString();
                    ModalPopupExtender2.Show();
                }
                else
                {
                    gvInShop.DataSource = "";
                    gvInShop.DataBind();
                    lblInShopPartNumber.Text = String.Empty;
                    ModalPopupExtender2.Hide();
                }
                BindStatus();
            }
            if(e.CommandName == "InStock")
            {
                DataSet ds = new DataSet();
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblID = (Label)clickedRow.FindControl("lblpartid");
                LinkButton lnStock = (LinkButton)clickedRow.FindControl("lnkInStock");
                ObjBOL.partid = Convert.ToInt32(lblID.Text);
                ObjBOL.Operation = 1;
                ds = ObjBLL.GetInStockData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvInsTock.DataSource = ds.Tables[1];
                    gvInsTock.DataBind();
                    lblInStockPartNumber.Text = ds.Tables[0].Rows[0]["PartNumber"].ToString();
                    ModalPopupStockIn.Show();
                }
                else
                {
                    gvInsTock.DataSource = "";
                    gvInsTock.DataBind();
                    lblInStockPartNumber.Text = String.Empty;
                    ModalPopupStockIn.Hide();
                }
                BindStatus();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    protected void lnkInShop_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlfooterpartno.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.partid = Convert.ToInt32(ddlfooterpartno.SelectedValue);
                ObjBOL.Operation = 1;
                ds = ObjBLL.GetInShopData(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvInShop.DataSource = ds.Tables[0];
                    gvInShop.DataBind();
                    lblInShopPartNumber.Text = ds.Tables[0].Rows[0]["Partnumber"].ToString();
                    BindStatus();
                    ModalPopupExtender2.Show();
                }
                else
                {
                    gvInShop.DataSource = "";
                    gvInShop.DataBind();
                    lblInShopPartNumber.Text = String.Empty;
                    BindStatus();
                    ModalPopupExtender2.Hide();
                }
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvRequition_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            LinkButton lnkInTransit = (LinkButton)e.Row.FindControl("lnkInTransit");
            LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("Delete");
            if (lnkInTransit != null)
            {
                if (lnkInTransit.Text == "0")
                {
                    lnkInTransit.Attributes.Remove("href");
                    if (lnkInTransit.Enabled != false)
                    {
                        lnkInTransit.Enabled = false;
                    }
                }
            }
            if (lnkEdit != null && lnkDelete != null)
            {
                if (HfChekStatus.Value == "3")
                {

                    gvRequition.Columns[15].Visible = false;
                    lnkEdit.Visible = false;
                    lnkDelete.Visible = false;
                }
                else if (HfEngDepID.Value != "7" && (HfChekStatus.Value == "2" || HfChekStatus.Value == "4" || HfChekStatus.Value == "5" || HfChekStatus.Value == "6"))
                {
                    gvRequition.Columns[15].Visible = false;
                    lnkEdit.Visible = false;
                    lnkDelete.Visible = false;
                }
                else
                {
                    gvRequition.Columns[15].Visible = true;
                    lnkEdit.Visible = true;
                    lnkDelete.Visible = true;
                }
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    protected void gvRequition_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            int ReqDetailId = Convert.ToInt32(gvRequition.DataKeys[e.NewEditIndex].Values[0]);
            if (ReqDetailId > 0)
            {
                HfReqDetailID.Value = ReqDetailId.ToString();
            }
            ObjBOL.Operation = 10;
            ObjBOL.ReqDetailID = ReqDetailId;
            ds = ObjBLL.GetPartDetails(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ddlfooterpartno.Items.FindByValue(ds.Tables[0].Rows[0]["PartId"].ToString()) != null)
                {
                    ddlfooterpartno.SelectedValue = ds.Tables[0].Rows[0]["PartId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Source"].ToString() != "")
                {
                    txtSource.Text = ds.Tables[0].Rows[0]["Source"].ToString();
                    lblSourceID.Text = ds.Tables[0].Rows[0]["SourceID"].ToString();
                }
                lblProductCode.Text = ds.Tables[0].Rows[0]["ProductCode"].ToString();
                lblDepartment.Text = ds.Tables[0].Rows[0]["Department"].ToString();
                lblUm.Text = ds.Tables[0].Rows[0]["UM"].ToString();
                if (ds.Tables[0].Rows[0]["OrderType"].ToString() != "")
                {
                    ddlOrderType.SelectedValue = ds.Tables[0].Rows[0]["OrderType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Requestor"].ToString() != "")
                {
                    ddlRequestor.SelectedValue = ds.Tables[0].Rows[0]["Requestor"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ShipmentBy"].ToString() != "")
                {
                    ddlShipBy.SelectedValue = ds.Tables[0].Rows[0]["ShipmentBy"].ToString();
                }
                lnkInStock.Text = ds.Tables[0].Rows[0]["stockinhand"].ToString();
                if(lnkInStock.Text != "")
                {
                    DivInStock.Visible = true;
                }
                else
                {
                    DivInStock.Visible = false;
                }
                lblInTransit.Text = ds.Tables[0].Rows[0]["InTransit"].ToString();
                if (lblInTransit.Text != "")
                {
                    InTransit.Visible = true;
                }
                else
                {
                    InTransit.Visible = false;
                }
                if (lblInTransit.Text == "0")
                {
                    lblInTransit.Attributes.Remove("href");
                    if (lblInTransit.Enabled != false)
                    {
                        lblInTransit.Enabled = false;
                    }
                }
                lnkInShop.Text = ds.Tables[0].Rows[0]["InShop"].ToString();
                if (lnkInShop.Text != "")
                {
                    DivInShop.Visible = true;
                }
                else
                {
                    DivInShop.Visible = false;
                }
                if (lnkInShop.Text == "0")
                {
                    lnkInShop.Attributes.Remove("href");
                    if (lnkInShop.Enabled != false)
                    {
                        lnkInShop.Enabled = false;
                    }
                }
                lblReOrder.Text = ds.Tables[0].Rows[0]["reorderqty"].ToString();
                txtfooterqty.Text = ds.Tables[0].Rows[0]["PartQty"].ToString();
                if(ds.Tables[0].Rows[0]["Priority"].ToString() != "")
                {
                    chkfooterPriority.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Priority"].ToString());
                }                
                txtcomments.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
                btnAdd.Text = "Update";
                btnSave.Enabled = false;
            }
            BindStatus();

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SendEmail_Prepare()
    {
        try
        {
            if (Utility.InventoryEmailSwitch())
            {
                string preparedBy = string.Empty;
                string approvedBy = string.Empty;
                string Reqstatus = string.Empty;

                if (ddlPreparedby.SelectedItem.Text.Trim().ToLower() != "select")
                {
                    preparedBy = ddlPreparedby.SelectedItem.Text;
                }

                if (ddlApprovedby.SelectedItem.Text.Trim().ToLower() != "select")
                {
                    approvedBy = ddlApprovedby.SelectedItem.Text;
                }

                if (ddlReqStatus.SelectedItem.Text.Trim().ToLower() != "select")
                {
                    Reqstatus = ddlReqStatus.SelectedItem.Text;
                }
                string Message = string.Empty;
                Message += "<!doctype><html lang='en'><head><meta charset = 'utf-8'><meta name = 'viewport' content = 'width=device-width, initial-scale=1'> ";
                Message += " <title> Purchase Order List </title></head><body><table cellpadding='0' cellspacing='0' style='border-collapse:collapse;width:100%;font-family:Calibri;font-size:1.15rem'> ";
                Message += " <tr><td><table border='1' cellpadding='8' cellspacing='0' style='border-collapse:collapse;width:100%;max-width:580px;margin:0 auto;border-color:#ddd'> ";
                Message += " <tr><td colspan='2'><h2 style='margin:0;font-size:1.15rem'> Kishore,</h2> ";
                Message += " <p style = 'margin-top:5px'>Attached you will find the <strong>" + ddlReq.SelectedItem.Text + "</strong>.<br/>";
                // Message += " Please review and let us know by <strong>" + Utility.AddBusinessDays(DateTime.Now, 3).ToString("MMMM dd, yyyy") + "</strong> if you wish to make any changes</p> ";                
                Message += " </td ></tr><tr><td colspan='2'><div style = 'width:80px;margin:0 auto'> ";
                Message += " <svg version='1.1' xmlns:xlink='http://www.w3.org/1999/xlink' id = 'Capa_1' enable-background='new 0 0 512 512' viewBox='0 0 512 512' style='width:100%;height:100%;' xmlns='http://www.w3.org/2000/svg'><g><g><g><path d='m369.4 76.49v401.05c0 3.26-.45 6.41-1.3 9.4-4.09 14.46-17.39 25.06-33.16 25.06h-239.78c-19.03 0-34.45-15.43-34.45-34.46v-401.05c0-19.03 15.42-34.46 34.45-34.46h239.78c19.03 0 34.46 15.43 34.46 34.46z' fill = '#a1412b' /><path d = 'm132.73 394.716v60.854c0 17.33 14.04 31.37 31.37 31.37h204c.85-2.99 1.3-6.14 1.3-9.4v-82.824z' fill = '#7f392c' /><path d = 'm334.941 42.034h-239.78c-19.031 0-34.455 15.424-34.455 34.455v401.053c0 19.031 15.424 34.455 34.455 34.455h239.781c19.031 0 34.455-15.424 34.455-34.455v-401.053c-.001-19.031-15.424-34.455-34.456-34.455zm-2.143 433.365h-235.494v-396.767h235.494z' fill= '#db765a' /> ";
                Message += " <path d = 'm369.4 394.72v82.82c0 3.26-.45 6.41-1.3 9.4h-204c-9.8 0-18.56-4.49-24.31-11.54h193.01v-80.68z' fill='#b55434' /><path d = 'm95.161 42.034c-19.029 0-34.455 15.426-34.455 34.455v219.149c0 10.106 8.193 18.299 18.299 18.299 10.106 0 18.299-8.193 18.299-18.299v-217.006h41.798c10.106 0 18.299-8.193 18.299-18.299 0-10.106-8.193-18.299-18.299-18.299z' fill='#f2886b' /><path d = 'm97.304 223.144v-82.649c0-10.106-8.193-18.299-18.299-18.299-10.106 0-18.299 8.193-18.299 18.299v82.649c0 10.106 8.193 18.299 18.299 18.299 10.106 0 18.299-8.193 18.299-18.299z' fill='#f79a7c' /></g><g><path d = 'm289.014 246.714v204.031h-124.915c-17.325 0-31.37-14.045-31.37-31.37v-162.204c0-5.775 4.682-10.457 10.457-10.457z' fill='#d8d4c9' /><path d='m289.01 246.71v204.04h-124.91c-11.88 0-22.22-6.6-27.54-16.34 26.46-35.27 42.13-79.09 42.13-126.57 0-21.26-3.14-41.78-8.99-61.13z' fill='#b5b1a4' /><path d='m195.728 419.376v-408.919c0-5.775 4.682-10.457 10.457-10.457h234.652c5.775 0 10.457 4.682 10.457 10.457v408.919c0 17.325-14.045 31.37-31.37 31.37h-255.565c17.325 0 31.369-14.045 31.369-31.37z' fill='#f1eee0' /><path d='m213.1 252.167c-9.593 0-17.37-7.777-17.37-17.37v-175.393c0-9.593 7.777-17.37 17.37-17.37 9.593 0 17.37 7.777 17.37 17.37v175.392c.001 9.594-7.776 17.371-17.37 17.371z' fill='#f9f8f2' /> ";
                Message += " <path d = 'm451.29 10.46v408.92c0 17.32-14.04 31.37-31.37 31.37h-99.7c62.77-106.75 98.77-231.12 98.77-363.91 0-29.39-1.76-58.37-5.19-86.84h27.04c5.77 0 10.45 4.68 10.45 10.46z' fill='#e8e4d8' /><path d='m195.73 344.78h255.56v21.67h-255.56z' fill='#ffc751' /><path d='m327.904 344.78h-93.578c-5.984 0-10.835 4.851-10.835 10.835 0 5.984 4.851 10.835 10.835 10.835h93.578c5.984 0 10.835-4.851 10.835-10.835 0-5.984-4.851-10.835-10.835-10.835z' fill='#ffe059' /> ";
                Message += " <path d = 'm451.29 10.46v70.63h-255.56v-70.63c0-5.78 4.68-10.46 10.46-10.46h234.65c5.77 0 10.45 4.68 10.45 10.46z' fill='#ffc751' /> ";
                Message += " <path d = 'm451.29 10.46v70.63h-32.32c-.22-27.42-1.96-54.48-5.17-81.09h27.04c5.77 0 10.45 4.68 10.45 10.46z' fill='#ffaf40' /></g></g><g><g> ";
                Message += " <g fill = '#8f8b81'><path d = 'm251.009 132.32h-18.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h18.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /> ";
                Message += " <path d = 'm306.009 160.899h-73.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h73.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /></g></g><g><g> ";
                Message += " <path d = 'm421.837 139.355c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889s5.793-5.194 8.957-7.278z' fill='#ffaf40' /></g></g></g><g><g> ";
                Message += " <g fill = '#8f8b81'><path d='m251.009 208.021h-18.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h18.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /> ";
                Message += " <path d = 'm306.009 236.6h-73.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h73.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' /></g></g><g><g> ";
                Message += " <path d = 'm421.837 215.056c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889 2.789-2.769 5.793-5.194 8.957-7.278z' fill='#ffaf40' /></g></g></g><g><g><g> ";
                Message += " <path d = 'm251.009 283.722h-18.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h18.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' fill='#8f8b81' /> ";
                Message += " <path d = 'm306.009 312.301h-73.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h73.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' fill='#8f8b81' /><g fill='#b5b1a4'> ";
                Message += " <path d = 'm259.14 294.383h-16.15c-4.948 0-8.959 4.011-8.959 8.959 0 4.948 4.011 8.959 8.959 8.959h16.149c4.948 0 8.959-4.011 8.959-8.959.001-4.948-4.01-8.959-8.958-8.959z' /> ";
                Message += " <path d = 'm259.14 218.682h-16.15c-4.948 0-8.959 4.011-8.959 8.959 0 4.948 4.011 8.959 8.959 8.959h16.149c4.948 0 8.959-4.011 8.959-8.959.001-4.948-4.01-8.959-8.958-8.959z' /> ";
                Message += " <path d = 'm259.14 142.981h-16.15c-4.948 0-8.959 4.011-8.959 8.959 0 4.948 4.011 8.959 8.959 8.959h16.149c4.948 0 8.959-4.011 8.959-8.959.001-4.948-4.01-8.959-8.958-8.959z' /></g> ";
                Message += " <path d = 'm351.009 418.538h-118.706c-4.948 0-8.959-4.011-8.959-8.959 0-4.948 4.011-8.959 8.959-8.959h118.706c4.948 0 8.959 4.011 8.959 8.959-.001 4.948-4.012 8.959-8.959 8.959z' fill='#8f8b81' /> ";
                Message += " <path d = 'm281.558 409.579c0 4.948 4.011 8.959 8.959 8.959h28.472c4.948 0 8.959-4.011 8.959-8.959 0-4.948-4.011-8.959-8.959-8.959h-28.472c-4.948.001-8.959 4.012-8.959 8.959z' fill = '#b5b1a4' /></g></g><g><g> ";
                Message += " <path d = 'm421.837 290.757c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889s5.793-5.194 8.957-7.278z' fill='#229bff' /></g></g><g><g> ";
                Message += " <path d= 'm421.837 410.49c1.226-.808 1.226-2.601 0-3.409-3.164-2.084-6.168-4.51-8.957-7.278s-5.233-5.749-7.333-8.889c-.814-1.217-2.621-1.217-3.435 0-2.1 3.14-4.544 6.121-7.333 8.889s-5.793 5.193-8.957 7.278c-1.226.808-1.226 2.601 0 3.409 3.164 2.084 6.168 4.51 8.957 7.278s5.233 5.749 7.333 8.889c.814 1.217 2.621 1.217 3.435 0 2.1-3.14 4.544-6.121 7.333-8.889s5.793-5.194 8.957-7.278z' fill='#229bff' /></g></g></g> ";
                Message += " <path d = 'm375.049 58.537h-103.076c-5.523 0-10-4.477-10-10v-18.822c0-5.523 4.477-10 10-10h103.076c5.523 0 10 4.477 10 10v18.822c0 5.523-4.477 10-10 10z' fill='#f1eee0' /> ";
                Message += " <path d = 'm451.29 344.78v21.67h-88.71c3.04-7.16 5.95-14.39 8.75-21.67z' fill='#ffaf40' /> ";
                Message += " <path d = 'm230.47 59.4v21.69h-34.74v-21.69c0-9.59 7.78-17.37 17.37-17.37 4.8 0 9.14 1.95 12.28 5.09s5.09 7.48 5.09 12.28z' fill='#ffe059' /></g></svg></div> ";
                Message += " <h1 style ='font-size:1.65rem;margin:.3rem 0 0;color:#000;text-align:center'>Requisition List</h1> ";
                Message += " </td></tr><tr><td style='width:1%;white-space:nowrap'>Req #</td><td style='font-weight:600;width:99%'>" + txtReqNo.Text + " </td></tr>";
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'>Prepared By</td><td style='font-weight:600;width:99%'> " + preparedBy + "</td></tr>";
                Message += " <tr><td style='width:1%;white-space:nowrap'> Approved By </td><td style='font-weight:600;width:99%'>" + approvedBy + "</td></tr>";
                Message += " <tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Submitted By </td><td style='font-weight:600;width:99%'> " + Utility.GetCurrentSession().EmployeeName + "</td> ";
                Message += " </tr><tr><td style='width:1%;white-space:nowrap'> Submitted Date / Time </td><td style='font-weight:600;width:99%'> " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt") + "</td></tr>";
                Message += "<tr style='background:#efefef'><td style='width:1%;white-space:nowrap'> Status </td><td style='font-weight:600;width:99%'> " + Reqstatus + "</td></tr>";
                Message += " <tr><td colspan = '2'>If you have any questions or concerns regarding your requisition, please contact the purchasing department. <br /><br /> ";
                Message += " Thanks, <br/ > <strong> " + Utility.EmailDisplayName() + " </strong> <br /> ";
                Message += " </td></tr></table></td></tr></table></body></html> ";
                List<MailAddress> sendToList = new List<MailAddress>();
                List<MailAddress> ccList = new List<MailAddress>();
                HashSet<MailAddress> sendToListASMrSingh = new HashSet<MailAddress>();
                HashSet<MailAddress> sendToListASRamanSingh = new HashSet<MailAddress>();
                HashSet<MailAddress> sendToListASPurchasing = new HashSet<MailAddress>();
                HashSet<MailAddress> ccListAsList = new HashSet<MailAddress>();
                sendToListASPurchasing = Utility.GetMailAddresses(Utility.EmailType.Inventory, "SendToList", Utility.emailDictionaryInventory, "Purchasing", 1, "R","");
                sendToList = sendToListASPurchasing.ToList();
                if (ddlReqStatus.SelectedValue == "2" || ddlReqStatus.SelectedValue == "3")
                {
                    if (ddlApprovedby.SelectedValue == "44")
                    {                   
                        ccListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "ccList", Utility.emailDictionaryInventory, "", 2, "R", "AppByB");
                    }
                    else if (ddlApprovedby.SelectedValue == "110")
                    {                        
                        ccListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "ccList", Utility.emailDictionaryInventory, "", 2, "R", "AppByR");
                    }
                }                             
                ccListAsList = Utility.GetMailAddresses(Utility.EmailType.Inventory, "ccList", Utility.emailDictionaryInventory, "", 2, "R","");
                ccList = ccListAsList.ToList();
                Send_Email(Message, "Requisition List (" + txtReqNo.Text + ")", sendToList, ccList);
                sendToListASMrSingh.Clear();
                sendToListASRamanSingh.Clear();
                sendToListASPurchasing.Clear();
                ccListAsList.Clear();
            }
            else
            {
                Utility.ShowMessage_Error(Page, "Email disabled !");
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private bool PrepareReport()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataZero();
            rprt.Load(Server.MapPath("~/Reports/rptGenerateRequisition.rpt"));
            if (dt.Rows.Count > 0)
            {
                rprt.SetDataSource(dt);
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private Stream GetReqReportStream()
    {
        Stream reportStream = null;
        try
        {
            PrepareReport();
            reportStream = (Stream)rprt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        finally
        {
            if (rprt != null)
            {
                rprt.Close();
                rprt.Dispose();
            }
        }
        return reportStream;
    }

    private void Send_Email(String Message, String Subject, List<MailAddress> sendToList, List<MailAddress> ccList)
    {
        try
        {
            if (sendToList.Count > 0)
            {
                MailMessage message = new MailMessage(new MailAddress(Utility.Email(), Utility.EmailDisplayName()), sendToList[0]);

                string mailbody = Message;
                message.Subject = Subject;
                message.Body = mailbody;
                Attachment file = new Attachment(GetReqReportStream(), "Requisition List" + "(" + txtReqNo.Text + ")" + ".pdf", "application/pdf");
                message.Attachments.Add(file);

                foreach (var sendto in sendToList)
                {
                    if (!message.To.Contains(sendto))
                    {
                        message.To.Add(sendto);
                    }
                }
                foreach (var cc in ccList)
                {
                    if (!message.CC.Contains(cc))
                    {
                        message.CC.Add(cc);
                    }
                }
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                // SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp
                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["Host"], 587);
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromMail"], ConfigurationManager.AppSettings["Password"]);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                client.Send(message);
                Message = string.Empty;
                Utility.ShowMessage_Success(Page, "Email Sent Successfully!!");
            }
            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlOrderType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((GridViewRow)((DropDownList)sender).NamingContainer);
            DropDownList ddlOrderType = (DropDownList)row.FindControl("ddlOrderType");
            if (ddlOrderType.SelectedValue == "4")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "MyFunctionCall", "gvConfirmBox();", true);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    //protected void txtfooterqty_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int reorderQty = 0;
    //        int orderqty = 0;
    //        int IntransitQty = 0;
    //        if(lblReOrder.Text != "")
    //        {
    //            reorderQty = Convert.ToInt32(lblReOrder.Text);
    //        }
    //        if(txtfooterqty.Text != "")
    //        {
    //            orderqty = Convert.ToInt32(txtfooterqty.Text);
    //        }
    //        if(lblInTransit.Text != "")
    //        {
    //            IntransitQty = Convert.ToInt32(lblInTransit.Text);
    //        }
    //        if(orderqty < IntransitQty)
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "text", "InTransitMessage();", true);
    //        }
    //        if(orderqty > reorderQty && reorderQty>0 )
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "text", "ReOrderMessage();", true);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utility.AddEditException(ex);
    //    }
    //}

    protected void hiddenBtnYes_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlReqStatus.SelectedValue == "2" || ddlReqStatus.SelectedValue == "3" || ddlReqStatus.SelectedValue == "4" || ddlReqStatus.SelectedValue == "5" || ddlReqStatus.SelectedValue == "6")
            {
                DataTable dtSubmitforreview = new DataTable();
                dtSubmitforreview = ReportDataZero();
                if (dtSubmitforreview.Rows.Count > 0)
                {
                    if (ddlReqStatus.SelectedValue == "3")
                    {
                        SavePartInfoandDetail();
                    }
                    else
                    {
                        SavePartInfoandDetail();
                        SendEmail_Prepare();
                    }
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "Please Add atleast One Part in the Details Section !!");
                }
            }
            BindStatus();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    //hiddenBtnNo
    protected void hiddenBtnNo_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 16;
            if (ddlReq.Items.FindByValue(ddlReq.SelectedValue) != null)
            {
                ObjBOL.Reqid = Convert.ToInt32(ddlReq.SelectedValue);
                msg = ObjBLL.CheckApprovedStatus(ObjBOL);
                if (msg != "")
                {
                    ddlReqStatus.SelectedValue = msg;
                }
            }
            BindStatus();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}