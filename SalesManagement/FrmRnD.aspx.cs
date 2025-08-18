using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.Security;
using System.Web.Services;
using System.Collections;
using System.Collections.Generic;
using AjaxControlToolkit;
using System.Web.UI.WebControls;
/// <summary>
///  R & D (05 May 2021) Rohit Kumar
/// </summary>
public partial class SalesManagement_FrmRnD : System.Web.UI.Page
{
    commonclass1 cls = new commonclass1();
    BOLManageProjectsInfo ObjBOL = new BOLManageProjectsInfo();
    BLLManageProjectsInfo ObjBLL = new BLLManageProjectsInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Controls_Bind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Controls_Bind()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetProjectInfo(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlConType, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlModel, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlCurrency, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlProjectEng, ds.Tables[3]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlReviewed, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPName, ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlPNumber, ds.Tables[5]);
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
            ddlPNumber.SelectedIndex = 0;
            ddlPName.SelectedIndex = 0;
            ddlModel.SelectedIndex = 0;
            ddlProjectEng.SelectedIndex = 0;
            ddlReviewed.SelectedIndex = 0;
            ddlCurrency.SelectedIndex = 0;
            ddlConType.SelectedIndex = 0;
            txtProjectNumber.Text = "";
            txtProjectName.Text = "";
            txtShipToArrive.Text = "";
            txtEqPrice.Text = "";
            txtFabDate.Text = "";
            txtProDate.Text = "";
            txtNesDate.Text = "";
            txtEqPrice.Text = "";
            btnSave.Text = "Save";
            btnAdd.Enabled = true;
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
            ResetControls();
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
            ResetControls();
            string msg = "";
            ObjBOL.Operation = 4;
            msg = ObjBLL.GenrateJNumber(ObjBOL);
            txtProjectNumber.Text = msg;
            txtProDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            btnAdd.Enabled = false;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    // Check if data filled in required fields
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtProjectNumber.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Generate New Project Number. !');", true);
                Utility.ShowMessage_Error(Page, "Please Generate New Project Number. !");
                txtProjectNumber.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = string.Empty;
            if (ValidationCheck() == true)
            {
                ObjBOL.Operation = 2;
                ObjBOL.JobID = txtProjectNumber.Text;
                if (txtProDate.Text != "")
                {
                    ObjBOL.ProjectDate = Utility.ConvertDate(txtProDate.Text);
                }
                else
                {
                    ObjBOL.ProjectDate = null;
                }
                ObjBOL.ProjectName = txtProjectName.Text;
                ObjBOL.ShipToArriveDate = Utility.ConvertDate(txtShipToArrive.Text);
                ObjBOL.FabDateIssue = Utility.ConvertDate(txtFabDate.Text);
                ObjBOL.NestDateIssue = Utility.ConvertDate(txtNesDate.Text);
                ObjBOL.ProjectEng = Convert.ToInt32(ddlProjectEng.SelectedValue);
                ObjBOL.ReviewedBy = Convert.ToInt32(ddlReviewed.SelectedValue);
                ObjBOL.ModelID = Convert.ToInt32(ddlModel.SelectedValue);
                ObjBOL.ConveyorID = Convert.ToInt32(ddlConType.SelectedValue);
                ObjBOL.CurrencyID = Convert.ToInt32(ddlCurrency.SelectedValue);
                ObjBOL.EqPrice = Utility.ToDouble(txtEqPrice.Text);
                msg = ObjBLL.SaveProjectInfo(ObjBOL);
                //Utility.ShowMessage(this, msg);
                Utility.ShowMessage_Success(Page, msg);
                Controls_Bind();
                ResetControls();
                btnAdd.Enabled = true;
                Utility.MaintainLogsSpecial("FrmRnD.aspx", "Save", txtProjectNumber.Text);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillDetailsFromPName()
    {
        try
        {
            btnSave.Text = "Update";
            HfJObID.Value = ddlPName.SelectedValue;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            if (ddlPName.SelectedIndex > 0)
            {
                ObjBOL.ID = Convert.ToInt32(ddlPName.SelectedValue);
            }
            else
            {
                ResetControls();
            }
            ds = ObjBLL.GetProjects(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtProjectName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProjectName"]);
                ddlPNumber.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["id"]);
                txtProjectNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["JobID"]);
                txtProDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["ProjectDate"]));
                txtShipToArrive.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["ShipToArriveDate"]));
                txtFabDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["FabDateIssue"]));
                txtNesDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["NestDateIssue"]));
                ddlProjectEng.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ProjectEng"]);
                ddlReviewed.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ReviewedBy"]);
                ddlModel.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ModelID"]);
                ddlConType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ConveyorID"]);
                ddlCurrency.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Currency"]);
                txtEqPrice.Text = Convert.ToString(ds.Tables[0].Rows[0]["EqPrice"]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillDetailsFromPNumber()
    {
        try
        {
            btnSave.Text = "Update";
            HfJObID.Value = ddlPNumber.SelectedValue;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            if (ddlPNumber.SelectedIndex > 0)
            {
                ObjBOL.ID = Convert.ToInt32(ddlPNumber.SelectedValue);
            }
            else
            {
                ResetControls();
            }
            ds = ObjBLL.GetProjects(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtProjectName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProjectName"]);
                ddlPName.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["id"]);
                txtProjectNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["JobID"]);
                txtProDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["ProjectDate"]));
                txtShipToArrive.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["ShipToArriveDate"]));
                txtFabDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["FabDateIssue"]));
                txtNesDate.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["NestDateIssue"]));
                ddlProjectEng.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ProjectEng"]);
                ddlReviewed.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ReviewedBy"]);
                ddlModel.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ModelID"]);
                ddlConType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ConveyorID"]);
                ddlCurrency.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Currency"]);
                txtEqPrice.Text = Convert.ToString(ds.Tables[0].Rows[0]["EqPrice"]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillDetailsFromPName();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnSearchProposal_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/SalesManagement/FrmSearchProject.aspx");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlPNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillDetailsFromPNumber();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}