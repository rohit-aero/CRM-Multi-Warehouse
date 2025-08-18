using BLLAERO;
using BOLAERO;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_FrmProductLine : System.Web.UI.Page
{
    BOLManageProductLine ObjBOL = new BOLManageProductLine();
    BLLManageProductLine ObjBLL = new BLLManageProductLine();   
    DataTable TempDTProdCode_lookup = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Controls();
                btnOnLoadModule();
            }
            DisabledITWItem();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #region Bind Functions

    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetBindControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProductCode, ds.Tables[0]);                             
                Utility.BindDropDownList(ddlProdCode, ds.Tables[0]);
                
                if(ddlProductCode.Items.Count>0)
                {
                    DisabledITWItem();
                }                
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion

    #region

    private void DisabledITWItem()
    {
        try
        {
            foreach (ListItem item in ddlProductCode.Items)
            {
                if (item.Text == "ITW")
                {
                    item.Attributes.Add("disabled", "disabled");
                }
                else
                {
                    item.Attributes.Add("enabled", "enabled");
                }
            }
            foreach (ListItem item in ddlProdCode.Items)
            {
                if (item.Text == "ITW")
                {
                    item.Attributes.Add("disabled", "disabled");
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
    #endregion

    #region Validation

    private Boolean ValidationCheck()
    {
        try
        {
            if (ddlProdCode.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select ProductLine !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Product Code !!");
                ddlProductLine.Focus();
                return false;
            }

            if (txtProductLine.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter RepGroup Name. !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Product Line. !!");
                txtProductLine.Focus();
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

    #region Reset Module
    private void ResetProductLine()
    {
        try
        {
            ddlProductLine.DataSource = "";
            ddlProductLine.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);            
        }
    }

    private void btnOnLoadModule()
    {
        try
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnOnAddModule()
    {
        try
        {
            btnAdd.Enabled = false;     
            btnSave.Enabled = true;
            ddlProdCode.Enabled = true;
            txtProductLine.Enabled = true;
            ddlProductCode.Enabled = false;
            ddlProductLine.Enabled = false;
            ddlProductCode.SelectedIndex = 0;
            btnSave.Text = "Save";
            if(ddlProductLine.Items.Count>0)
            {
                ddlProductLine.SelectedIndex = 0;
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void btnOnEditModule()
    {
        try
        {
            btnSave.Text = "Update";
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            ddlProdCode.Enabled = false;
            txtProductLine.Enabled = true;
            ddlProductCode.Enabled = false;
            ddlProductLine.Enabled = false;
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
            ddlProductLine.Enabled = true;
            ddlProductCode.Enabled = true;
            ddlProdCode.Enabled = false;
            txtProductLine.Enabled = false;
            txtProductLine.Text = String.Empty;
            ddlProdCode.SelectedIndex = 0;
            ddlProductCode.SelectedIndex = 0;
            if(ddlProductLine.Items.Count>0)
            {
                ddlProductLine.Items.Clear();
            }
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void ResetOnddlProductLine()
    {
        try
        {
            ddlProductCode.Enabled = true;
            ddlProductLine.Enabled = true;            
            ddlProdCode.Enabled = false;
            txtProductLine.Enabled = false;
            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnSave.Text = "Save";
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void RsetProductLineInfo()
    {
        try
        {
            ddlProdCode.SelectedIndex = 0;
            txtProductLine.Text = String.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    protected void ddlProductCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if(ddlProductCode.SelectedIndex>0)
            {
                BindProductLine(ddlProductCode.SelectedValue,"");
            }
            else
            {
                btnOnLoadModule();
                RsetProductLineInfo();
                ResetProductLine();
                
            }
        }
        catch (Exception ex)
        {           
            Utility.AddEditException(ex);
        }
    }

    private void BindProductLine(string productcode, string productid)
    {
        try
        {            
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.ProductCode =Convert.ToInt32(productcode);
            ds = ObjBLL.GetBindControls(ObjBOL);
            if(ds.Tables[0].Rows.Count>0)
            {
                Utility.BindDropDownList(ddlProductLine, ds.Tables[0]);
                if(productid != "")
                {
                    ddlProductCode.SelectedValue = productcode;
                    ddlProductLine.SelectedValue = productid;
                }
            }
            else
            {
                ResetProductLine();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillProductLineDetails(string productcode, string product)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 4;
            ObjBOL.ProductCode = Convert.ToInt32(productcode);
            ObjBOL.Product = product;
            ds = ObjBLL.GetBindControls(ObjBOL);
            if(ds.Tables[0].Rows.Count>0)
            {
                ddlProdCode.SelectedValue = ds.Tables[0].Rows[0]["ProductCodeId"].ToString();
                txtProductLine.Text = ds.Tables[0].Rows[0]["Product"].ToString();
            }
            else
            {
                ddlProdCode.SelectedIndex = 0;
                txtProductLine.Text = String.Empty;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlProductLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetOnddlProductLine();
            if(ddlProductCode.SelectedIndex>0 && ddlProductLine.SelectedIndex>0)
            {
                FillProductLineDetails(ddlProductCode.SelectedValue,ddlProductLine.SelectedValue);
            }
            else
            {
                btnOnLoadModule();
                RsetProductLineInfo();
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
            if(ValidationCheck()==true)
            {
                string msg = "";
                if(ddlProductLine.SelectedIndex>0)
                {
                    //Edit Operation
                    ObjBOL.Operation = 5;
                }
                else
                {
                    //Save Operation
                    ObjBOL.Operation = 3;
                }                
                ObjBOL.ProductCode =Convert.ToInt32(ddlProdCode.SelectedValue);
                ObjBOL.Product = txtProductLine.Text;
                if(ddlProductLine.SelectedIndex>0)
                {
                    ObjBOL.ProductLineID = Convert.ToInt32(ddlProductLine.SelectedValue);
                }                
                msg = ObjBLL.SaveProductLine(ObjBOL);
                if(msg == "Product Line Already Exists !!")
                {
                    Utility.ShowMessage_Error(Page, msg);                    
                }
                else
                {                    
                    if(ddlProductLine.SelectedIndex>0)
                    {
                        Utility.ShowMessage_Success(Page, msg);
                        Utility.MaintainLogsSpecial("FrmProductLine", "Update", ObjBOL.ProductLineID.ToString());
                        BindProductLine(ObjBOL.ProductCode.ToString(), ObjBOL.ProductLineID.ToString());
                    }
                    else
                    {
                        Utility.ShowMessage_Success(Page, "Product Line Saved Successfully !!");
                        Utility.MaintainLogsSpecial("FrmProductLine", "Save", msg);
                        BindProductLine(ObjBOL.ProductCode.ToString(), msg);
                    }                    
                    ResetOnddlProductLine();
                }
            }
        }
        catch (Exception ex)
        {            
            Utility.AddEditException(ex);
        }
    }
    #region
    private void Add_Button()
    {
        try
        {
            btnOnAddModule();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Add_Button();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            btnOnEditModule();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
    }  
}