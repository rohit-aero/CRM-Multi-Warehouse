using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLLAERO;
using BOLAERO;

public partial class FrmStandardParts : System.Web.UI.Page
{
    BOLStandardParts ObjBOL = new BOLStandardParts();
    BLLStandardParts ObjBLL = new BLLStandardParts();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Control();

            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
       
    }

    //Bind Category Drop Down List
    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 1;
            ds = ObjBLL.GetStandardParts(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPartDesc, ds.Tables[0]);
            }
            if(ds.Tables[1].Rows.Count>0)
            {
                Utility.BindDropDownList(ddlJobID, ds.Tables[1]);
            }
            
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
       

    }
    // Add Parts 
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlJobID.SelectedIndex>0)
            {
                String msg = "";
                if (ValidationCheck() == true)
                {
                    ObjBOL.operation = 2;
                    ObjBOL.JobID = ddlJobID.SelectedValue;
                    ObjBOL.PartId = Convert.ToInt32(ddlPartDesc.SelectedValue);
                    if(ddlItem.SelectedIndex>0)
                    {
                        ObjBOL.Itemid = Convert.ToInt32(ddlItem.SelectedValue);
                    }                   
                    ObjBOL.Qty = Convert.ToInt32(txtQty.Text);
                    msg = ObjBLL.SaveStandardParts(ObjBOL);                    
                    FillDetailsFromJobId(ddlJobID.SelectedValue);
                }

            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        

    }
    //Validation Add
    private Boolean ValidationCheck()
    {
        try
        {
            if (ddlPartDesc.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Part Description !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Part Description !");
                ddlPartDesc.Focus();
                return false;
            }
                       
            if (txtQty.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Quantity !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Quantity !");
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

    //Syncronize Data With JNumber

  
  

  
  

    //Bind Data in Grid View
    private void FillDetailsFromJobId(string strJobId)
    {
        try
        {
            Panel2.Visible = true;
            DataSet ds = new DataSet();
            ObjBOL.operation = 5;
            ObjBOL.JobID = strJobId;
            ds = ObjBLL.GetStandardParts(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetail.DataSource = ds;
                gvDetail.DataBind();
            }
            else
            {
                gvDetail.DataSource = "";
                gvDetail.DataBind();
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        

    }


    //PARTNO DROP DOWN DISPLAY After Selection of Category Items
    protected void ddlPartDesc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPartDesc.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.operation = 3;
                ObjBOL.PartDescid = Convert.ToInt32(ddlPartDesc.SelectedValue);
                ds = ObjBLL.GetStandardParts(ObjBOL);
                if(ds.Tables[0].Rows.Count>0)
                {   
                    if(ds.Tables[0].Rows[0]["detailname"].ToString()=="")
                    {
                        ddlItem.DataSource = "";
                        ddlItem.DataBind();
                        txtPartNo.Text = ds.Tables[0].Rows[0]["Standardpartno"].ToString();
                    }      
                    else
                    {
                        Utility.BindDropDownList(ddlItem, ds.Tables[0]);
                    }           
                                     
                }
                else
                {
                    
                }
            }
            
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
       
    }
       //Delete Records in row wise in Grid 
    protected void gvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int ID = Convert.ToInt32(gvDetail.DataKeys[e.RowIndex].Values[0]);
            String msg = "";
            ObjBOL.operation = 6;
            ObjBOL.ID = ID;
            msg = ObjBLL.DeleteStandardParts(ObjBOL);           
            FillDetailsFromJobId(ddlJobID.SelectedValue);
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        
        
    }

    //Reset Control
    //private void Reset()
    //{
    //    txtJobID.Text = String.Empty;
    //    txtProject.Text = String.Empty;
    //    ddlCategory.SelectedIndex = 0;
    //    ddlPart.SelectedIndex = 0;
    //    txtQty.Text = String.Empty;

    //}

    //protected void gvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gvDetail.PageIndex = e.NewPageIndex;
    //    FillDetailsFromJobId(txtJobID.Text);
    //}

    protected void ddlJobID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {            
            FillDetailsFromJobId(ddlJobID.SelectedValue);
            ddlPartDesc.SelectedIndex = 0;
            ddlItem.DataSource = "";
            ddlItem.DataBind();
            txtPartNo.Text = String.Empty;
            txtQty.Text = String.Empty;
            
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }



    protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if(ddlItem.SelectedIndex>0)
            {
                DataSet ds = new DataSet();
                ObjBOL.operation = 4;
                ObjBOL.Itemid = Convert.ToInt32(ddlItem.SelectedValue);
                ds = ObjBLL.GetStandardParts(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtPartNo.Text = ds.Tables[0].Rows[0]["partno"].ToString();
                }
                else
                {
                    txtPartNo.Text = String.Empty;
                }
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }
}
   
    
