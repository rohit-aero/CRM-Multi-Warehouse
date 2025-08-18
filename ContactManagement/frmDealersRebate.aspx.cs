using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;

public partial class ContactManagement_frmDealersRebate : System.Web.UI.Page
{
    BOLManageDealersRebate ObjBOL = new BOLManageDealersRebate();
    BLLManageDealerRebate ObjBLL = new BLLManageDealerRebate();

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
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlLookupDealers, ds.Tables[0]);               
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
            if (txtSalesFrom.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Sales From !");
                txtSalesFrom.Focus();
                return false;
            }

            if (txtSalesTo.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Sales To !");
                txtSalesTo.Focus();
                return false;
            }
            if (txtPercent.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Percent !");
                txtPercent.Focus();
                return false;
            }
            if (txtEffectiveDate.Text == "")
            {
                Utility.ShowMessage_Error(Page, "Please Enter Effective Date !");
                txtEffectiveDate.Focus();
                return false;
            }
            if (ddlCalculated.SelectedIndex == 0)
            {
                Utility.ShowMessage_Error(Page, "Please Select Calculated !");
                ddlCalculated.Focus();
                return false;
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private void SaveData()
    {
        try
        {
            if (ValidationCheck())
            {
                string msg = "";
                if (ddlLookupDealers.SelectedIndex > 0)
                {
                    ObjBOL.DealerID = Convert.ToInt32(ddlLookupDealers.SelectedValue);
                }           
                if(txtSalesFrom.Text != "")
                {
                    ObjBOL.SalesFrom = Convert.ToDecimal(txtSalesFrom.Text);
                }
                if(txtSalesTo.Text != "")
                {
                    ObjBOL.SalesTo = Convert.ToDecimal(txtSalesTo.Text);
                }                
                if(txtPercent.Text != "")
                {
                    ObjBOL.Percent = Convert.ToDecimal(txtPercent.Text);
                }                
                if(txtEffectiveDate.Text != "")
                {
                    ObjBOL.EffectiveDate = Utility.ConvertDate(txtEffectiveDate.Text);
                }               
                ObjBOL.Calculated =ddlCalculated.SelectedValue;
                if (btnSave.Text == "Save")
                {
                    ObjBOL.Operation = 3;
                }
                else
                {
                    ObjBOL.Operation = 2;
                    if(HfDealerDebateID.Value != "-1")
                    {
                        ObjBOL.DealerRebateID = Convert.ToInt32(HfDealerDebateID.Value);
                    }                    
                }                             
                msg = ObjBLL.SaveRebate(ObjBOL).Trim();
                if (msg.Length > 0)
                {
                    if (msg == "ER")
                    {
                        Utility.ShowMessage_Error(Page, "Dealer Rebate already exists !!");
                        return;
                    }

                    if (msg != "U")
                    {
                        Utility.ShowMessage_Success(Page, "Records Added Successfully !!");                     
                        Utility.MaintainLogsSpecial("FrmDealersRebate", "Save", ddlLookupDealers.SelectedValue);
                    }
                    else
                    {
                        Utility.ShowMessage_Success(Page, "Record Updated successfully !!");                      
                        Utility.MaintainLogsSpecial("FrmDealersRebate", "Update", ddlLookupDealers.SelectedValue);                        
                    }
                }
                Bind_Grid();
                Reset();
                btnSave.Text = "Save";
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
   

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Reset();
            ResetGrid();
            ddlLookupDealers.SelectedIndex = 0;
            btnSave.Enabled = false;
            btnSave.Text = "Save";
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
            txtSalesFrom.Text = String.Empty;
            txtSalesTo.Text = String.Empty;
            txtPercent.Text = String.Empty;
            txtEffectiveDate.Text = String.Empty;
            ddlCalculated.SelectedIndex = 0;                    
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }



    protected void ddlLookupDealers_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Reset();
            Bind_Grid();
            btnSave.Text = "Save";
            if (ddlLookupDealers.SelectedIndex > 0)
            {                
                btnSave.Enabled = true;       
            }
            else
            {
                btnSave.Enabled = false;
            }
            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillData(int DealerRebateID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            if(DealerRebateID>0)
            {
                ObjBOL.DealerRebateID = DealerRebateID;
            }
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtSalesFrom.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["SalesFrom"]).ToString("F2"); ;
                txtSalesTo.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["SalesTo"]).ToString("F2"); ;
                txtPercent.Text = ds.Tables[0].Rows[0]["Percent"].ToString();
                txtEffectiveDate.Text = ds.Tables[0].Rows[0]["EffectiveDate"].ToString();
                ddlCalculated.SelectedValue = ds.Tables[0].Rows[0]["Calculated"].ToString();
                btnSave.Text = "Update";
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
            if (ddlLookupDealers.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 4;
                ObjBOL.DealerID = Convert.ToInt32(ddlLookupDealers.SelectedValue);
                ds = ObjBLL.GetControls(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        row["SalesFrom"] = Math.Round(Convert.ToDecimal(row["SalesFrom"]), 2);
                        row["SalesTo"] = Math.Round(Convert.ToDecimal(row["SalesTo"]), 2);
                    }
                    dt.AcceptChanges();
                    gvManageDealerRebate.DataSource = dt;
                    gvManageDealerRebate.DataBind();
                }
                else
                {
                    ResetGrid();
                }
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

    private void ResetGrid()
    {
        try
        {
            gvManageDealerRebate.DataSource = "";
            gvManageDealerRebate.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvManageDealerRebate_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int DealerRebateID = Convert.ToInt32(gvManageDealerRebate.DataKeys[e.NewEditIndex].Values[0]);
            if(DealerRebateID>0)
            {
                HfDealerDebateID.Value = DealerRebateID.ToString();
            }
            FillData(DealerRebateID);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvManageDealerRebate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int ID = Convert.ToInt32(gvManageDealerRebate.DataKeys[e.RowIndex].Values[0]);
            string msg = "";
            ObjBOL.Operation = 6;
            ObjBOL.DealerRebateID = ID;
            msg = ObjBLL.SaveRebate(ObjBOL);
            if (msg != "")
            {
                Utility.ShowMessage_Success(Page, "Record Deleted Successfully !");
                Utility.MaintainLogsSpecial("FrmDealersRebate", "Delete", ddlLookupDealers.SelectedValue);
                Bind_Grid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
   
}