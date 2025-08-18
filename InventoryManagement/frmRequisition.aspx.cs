using System;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;
using CrystalDecisions.CrystalReports.Engine;

public partial class INVManagement_frmRequisition : System.Web.UI.Page
{
    BOLRequisition ObjBOL = new BOLRequisition();
    BLLRequisition ObjBLL = new BLLRequisition();
    commonclass1 cls = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Controls();
            BindReqNo();
            EmptyDTRequition();
        }
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
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }    
    #endregion

    #region DATATABLE FUNCTIONS

    private DataTable EmptyDTRequition()
    {
        DataTable dt = new DataTable();
        try
        {
            //DataRow dr;            
            dt.TableName = "Summary";
            //TicketID   
            dt.Columns.Add(new DataColumn("Reqid", typeof(int)));
            dt.Columns.Add(new DataColumn("ReqDetailid", typeof(int)));
            dt.Columns.Add(new DataColumn("Partid", typeof(int)));
            dt.Columns.Add(new DataColumn("Partnumber", typeof(string)));
            dt.Columns.Add(new DataColumn("PartDesc", typeof(string)));
            dt.Columns.Add(new DataColumn("ProductCode", typeof(string)));
            dt.Columns.Add(new DataColumn("Department", typeof(string)));
            dt.Columns.Add(new DataColumn("UM", typeof(string)));
            dt.Columns.Add(new DataColumn("PartQty", typeof(int)));
            dt.Columns.Add(new DataColumn("Priority", typeof(bool)));
            dt.Columns.Add(new DataColumn("Comments", typeof(string)));
            ViewState["Summary"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private DataTable EmptyDT()
    {
        DataTable dtEmpty = new DataTable();
        try
        {
            dtEmpty.TableName = "GridSummary";
            dtEmpty.Columns.Add(new DataColumn("Reqid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("ReqDetailid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Partid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Partnumber", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("PartDesc", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("ProductCode", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("Department", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("UM", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("PartQty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Priority", typeof(bool)));
            dtEmpty.Columns.Add(new DataColumn("Comments", typeof(string)));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(0,0,0, "", "", "","","", 0, false, "");//adding row to the datatable  
            //dtEmpty.Rows.Add(datatRow);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
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
                EnableControls();
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
            ddlPreparedByList.SelectedIndex = 0;                   
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }    

    private void SavePartDetails()
    {
        try
        {
            CheckGridBeforeSave();
            string partnumber = "";
            string partdescription = "";
            string qty = "0";
            string partid = ddlfooterpartinfo.SelectedValue;
            if(ddlfooterpartno.SelectedItem.Text != "Select")
            {
                partnumber = ddlfooterpartno.SelectedItem.Text;
            }
            else
            {
                partnumber="";
            }
            if(ddlfooterpartinfo.SelectedItem.Text != "Select")
            {
                partdescription = ddlfooterpartinfo.SelectedItem.Text;
            }
            else
            {
                partdescription = "";
            }
            string productcode = lblProductCode.Text;
            string um = lblUm.Text;
            string department = lblDepartment.Text;
            if(txtfooterqty.Text != "")
            {
                qty = txtfooterqty.Text;
            }            
            bool chkpriority = chkfooterPriority.Checked;
            string comments = txtcomments.Text;
            PrePareDT(0,0, Convert.ToInt32(partid), partnumber, partdescription, productcode,um ,department ,Convert.ToInt32(qty), chkpriority, comments);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);            
        }
    }

    private void BindSummaryTemp(DataTable dt)
    {
        try
        {
            DataTable DTSummary = dt;
            if (DTSummary.Rows.Count > 0)
            {
                gvRequition.DataSource = DTSummary;
                gvRequition.DataBind();
                ViewState["dirState"] = DTSummary;
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

    private void CheckGridBeforeSave()
    {
        try
        {
            DataTable dt = EmptyDTRequition();
            DataRow dr;
            foreach (GridViewRow row in gvRequition.Rows)
            {
                Label partid = ((Label)row.FindControl("lblpartid"));                               
                Label partnum = ((Label)row.FindControl("lblpartnumber"));
                Label partdesc = ((Label)row.FindControl("lblPartinfo"));
                Label productcode = ((Label)row.FindControl("lblgvProductCode"));
                Label department = ((Label)row.FindControl("lblgvDepartment"));
                Label um = ((Label)row.FindControl("lblgvUM"));
                TextBox qty = ((TextBox)row.FindControl("txtqty"));               
                bool isSelected = (row.FindControl("chkpriority") as CheckBox).Checked;
                TextBox comments = ((TextBox)row.FindControl("txtcomments"));
                dr = dt.NewRow();
                if (ddlReq.SelectedIndex > 0)
                {
                    dr[0] = ddlReq.SelectedValue;
                }
                else
                {
                    dr[0] = 0;
                }
                dr[2] = Convert.ToInt32(partid.Text);
                dr[3] = partnum.Text;
                dr[4] = partdesc.Text;
                if (productcode.Text != "")
                {
                    dr[5] = productcode.Text;
                }
                if (department.Text != "")
                {
                    dr[6] = department.Text;
                }
                else
                {
                    dr[6] = "";
                }
                if (um.Text != "")
                {
                    dr[7] = um.Text;
                }
                else
                {
                    dr[7] = "";
                }                
                if (qty.Text != "")
                {
                    dr[8] = Convert.ToInt32(qty.Text);
                }
                else
                {
                    dr[8] = 0;
                }
                dr[9] = isSelected;
                dr[10] = comments.Text;

                dt.Rows.Add(dr);
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow drdelete = dt.Rows[i];
                    if (drdelete["Partid"].ToString() == Convert.ToString(0))
                    {
                        drdelete.Delete();
                    }
                }
                dt.AcceptChanges();
            }          
            ViewState["Summary"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void PrePareDT(int Reqid, int ReqDetailid, int partid, string Partnumber, string partdescription, string productcode, string um, string department, int qty, bool priority, string Comments)
    {
        try
        {
            DataTable dtCurrentTable = (DataTable)ViewState["Summary"];
            DataRow drCurrentRow = null;
            drCurrentRow = dtCurrentTable.NewRow();
            drCurrentRow["ReqId"] = Reqid;
            drCurrentRow["ReqDetailid"] = ReqDetailid;
            drCurrentRow["Partid"] = partid;
            drCurrentRow["Partnumber"] = Partnumber;
            drCurrentRow["PartDesc"] = partdescription;
            drCurrentRow["productcode"] = productcode;
            drCurrentRow["um"] = um;
            drCurrentRow["department"] = department;
            drCurrentRow["PartQty"] = qty;
            drCurrentRow["Priority"] = priority;
            drCurrentRow["Comments"] = Comments;
            for (int i = dtCurrentTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtCurrentTable.Rows[i];
                if (dr["Partid"].ToString() == Convert.ToString(partid) && priority == false)
                {
                    drCurrentRow["Priority"] = dtCurrentTable.Rows[i]["Priority"].ToString();
                }
                if (dr["Partid"].ToString() == Convert.ToString(partid) && Comments == "")
                {
                    drCurrentRow["Comments"] = dtCurrentTable.Rows[i]["Comments"].ToString();
                }
                int qty1 = qty;
                int qty2 = Convert.ToInt32(dr["PartQty"].ToString());
                if (dr["Partid"].ToString() == Convert.ToString(partid))
                {
                    drCurrentRow["PartQty"] = qty1 + qty2;
                    dr.Delete();
                }
            }
            if (drCurrentRow["Partnumber"].ToString() == "")
            {
                drCurrentRow.Delete();
            }
            dtCurrentTable.AcceptChanges();
            dtCurrentTable.Rows.Add(drCurrentRow);
            dtCurrentTable.DefaultView.Sort = "PartQty DESC";
            DataTable dt = (DataTable)ViewState["Summary"];
            BindSummaryTemp(dt);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Savedata()
    {
        try
        {
            if(ValidationCheck()==true)
            {
                string msg = "";
                ObjBOL.Operation = 3;
                ObjBOL.ReqNo = txtReqNo.Text;
                ObjBOL.PreparedBy = Convert.ToInt32(ddlPreparedby.SelectedValue);
                ObjBOL.AppBy = Convert.ToInt32(ddlApprovedby.SelectedValue);
                ObjBOL.TentativeShipDate = Utility.ConvertDate(txtTentativeshipdate.Text);
                SavePartDetails();
                DataTable selected = (DataTable)ViewState["Summary"];
                DataView dv = new DataView(selected);
                DataTable summarytemp = dv.ToTable("selected", false, "Partid", "PartQty", "Priority", "Comments");
                ObjBOL.ReqDetails = summarytemp;
                ObjBOL.LoginUserId = Convert.ToInt32(Utility.GetCurrentSession().EmployeeID);
                if(ddlReq.SelectedIndex>0)
                {
                    ObjBOL.Reqid = Convert.ToInt32(ddlReq.SelectedValue);                    
                }
                msg = ObjBLL.SaveRequisitionData(ObjBOL);
                if (ddlPreparedByList.SelectedIndex==0)
                {
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
                ObjBOL.PreparedBy = Convert.ToInt32(ddlPreparedByList.SelectedValue);
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Savedata();
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
            ds = ObjBLL.GetControlsData(ObjBOL);
            if(ds.Tables[0].Rows.Count>0)
            {
                Utility.BindDropDownList(ddlReq, ds.Tables[0]);
                ddlReq.SelectedIndex = 0;
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
            DisableControls();            
            DisableControls();
            txtReqNo.Text = String.Empty;
            ddlPreparedByList.SelectedIndex = 0;         
            BindReqNo();
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
            if(ValidationCheck()==true)
            {
                if (ValidationCheckPartDetails() == true)
                {
                    SavePartDetails();
                    ResetDetails();
                }
            }
            
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
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 11;
            ObjBOL.Reqid = Convert.ToInt32(ddlReq.SelectedValue);
            ObjBOL.LoginUserId = Convert.ToInt32(Utility.GetCurrentSession().EmployeeID);
            msg = ObjBLL.UpdateIsSubmitted(ObjBOL);
            //Utility.ShowMessage(this, msg);
            Utility.ShowMessage_Success(Page, msg);
            Reset();
            ResetDetails();            
            txtReqNo.Text = String.Empty;           
            DisableControls();
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
            ObjBOL.partid =Convert.ToInt32(ddlfooterpartno.SelectedValue);
            ds = ObjBLL.GetPartDetails(ObjBOL);
            if(ds.Tables[0].Rows.Count>0)
            {
                lblProductCode.Text = ds.Tables[0].Rows[0]["ProjectCode"].ToString();
                lblUm.Text= ds.Tables[0].Rows[0]["UM"].ToString();
                lblDepartment.Text= ds.Tables[0].Rows[0]["Department"].ToString();
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

    private void BindAllDetails()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.Reqid =Convert.ToInt32(ddlReq.SelectedValue);
            ds = ObjBLL.GetControlsData(ObjBOL);
            if(ds.Tables[0].Rows.Count>0)
            {
                txtReqNo.Text = ds.Tables[0].Rows[0]["ReqNo"].ToString();
                ddlPreparedby.SelectedValue = ds.Tables[0].Rows[0]["PreparedBy"].ToString();
                ddlPreparedByList.SelectedValue = ddlPreparedby.SelectedValue;
                BindReqNoOnPreparedBy();
                ddlReq.SelectedValue = ObjBOL.Reqid.ToString();
                ddlApprovedby.SelectedValue = ds.Tables[0].Rows[0]["AppBy"].ToString();
                txtTentativeshipdate.Text =ds.Tables[0].Rows[0]["TentativeShipDate"].ToString();                
            }
            Bind_Grid();
            
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
            if(ddlReq.SelectedIndex>0)
            {
                BindAllDetails();
                EnableControls();
                btnSave.Text = "Update";
            }           
            else
            {
                DisableControls();
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
            if(ddlPreparedByList.SelectedIndex==0)
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
            if(ddlReq.Items.Count>0)
            {
                ddlReq.SelectedIndex = 0;
            }            
            txtReqNo.Text = String.Empty;            
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
            if(ddlfooterpartinfo.SelectedIndex>0)
            {
                ddlfooterpartno.SelectedValue = ddlfooterpartinfo.SelectedValue;
                BindPartDetails();
            }      
            else
            {
                ResetDetails();
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
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.Reqid =Convert.ToInt32(ddlReq.SelectedValue);
            ds = ObjBLL.GetControlsData(ObjBOL);
            if(ds.Tables[1].Rows.Count>0)
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
            if(ddlfooterpartno.SelectedIndex>0)
            {
                ddlfooterpartinfo.SelectedValue = ddlfooterpartno.SelectedValue;
                BindPartDetails();
            }
            else
            {
                ResetDetails();
            }

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
            CheckGridBeforeSave();
            DataTable dtCurrentTable = (DataTable)ViewState["Summary"];
            int index = e.RowIndex;
            dtCurrentTable.Rows[index]["PartQty"]=0;
            dtCurrentTable.Rows[index]["Priority"] = 0;
            dtCurrentTable.Rows[index]["Comments"] = "";
            gvRequition.DataSource = dtCurrentTable;
            gvRequition.DataBind();
            dtCurrentTable.AcceptChanges();            
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
            txtTentativeshipdate.Text = String.Empty;
            txtActualShipdate.Text = String.Empty;          
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
            lblProductCode.Text = String.Empty;
            lblUm.Text = String.Empty;
            lblDepartment.Text = String.Empty;           
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
            clscon.Return_DT(dt, "EXEC [dbo].[INV_GenerateRequisition] '" + ddlReq.SelectedValue + "'");
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
            //btnSubmit.Enabled = false;
            btnGenerate.Enabled = false;
            btnSave.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion    
}