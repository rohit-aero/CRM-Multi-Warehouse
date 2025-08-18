using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;
using CrystalDecisions.CrystalReports.Engine;
public partial class INVManagement_frmStockIn : System.Web.UI.Page
{
    BOLContainer ObjBOL = new BOLContainer();
    BLLStockIn ObjBLL = new BLLStockIn();
    commonclass1 cls = new commonclass1();
    string msg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Controls();
        }
    }
    #region Functions
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlVendor, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void Bind_Container()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 5;
            ObjBOL.SourceID = Convert.ToInt32(ddlVendor.SelectedValue);
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRequisitionNo, ds.Tables[0]);
            }
            else
            {
                ResetContainer();
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    private void ResetContainer()
    {
        try
        {
            ddlRequisitionNo.DataSource = "";
            ddlRequisitionNo.DataBind();
            ddlRequisitionNo.Items.Insert(0, new ListItem("Select", "0"));
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
            var EmployeeID = Utility.GetCurrentSession().EmployeeID;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 3;
            ObjBOL.SourceID = Int32.Parse(ddlVendor.SelectedValue);
            ObjBOL.Containerid = Convert.ToInt32(ddlRequisitionNo.SelectedValue);
            ds = ObjBLL.GetBindControl(ObjBOL);
            if (ds.Tables[1].Rows.Count > 0)
            {                
                gvMainRequisitionDetail.DataSource = ds.Tables[1];
                gvMainRequisitionDetail.DataBind();
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_GridChangeContainer()
    {
        try
        {                      
            Bind_Grid();           
            DataSet ds = new DataSet();
            foreach (GridViewRow row in gvMainRequisitionDetail.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Label POId = row.FindControl("lblPOId") as Label;
                    string partid = gvMainRequisitionDetail.DataKeys[row.RowIndex].Value.ToString();
                    ObjBOL.PartId = Convert.ToInt32(partid);
                    ObjBOL.POid = Convert.ToInt32(POId.Text);
                    ObjBOL.SourceID = Int32.Parse(ddlVendor.SelectedValue);
                    GridView gvContainer = row.FindControl("gvContainer") as GridView;
                    if (ddlRequisitionNo.SelectedIndex > 0)
                    {
                        ObjBOL.Containerid = Convert.ToInt32(ddlRequisitionNo.SelectedValue);
                    }
                    ObjBOL.Operation = 3;
                    ds = ObjBLL.GetBindControl(ObjBOL);
                    DataTable dtContainerUpdate = new DataTable();
                    dtContainerUpdate = ds.Tables[2];
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        if (dtContainerUpdate.Rows.Count > 0)
                        {
                            DataView dv = new DataView(dtContainerUpdate);
                            dv.Sort = "ShipQty DESC";
                            dtContainerUpdate = dv.ToTable();
                        }
                        gvContainer.DataSource = dtContainerUpdate;
                        gvContainer.DataBind();

                    }
                    else
                    {
                        gvContainer.DataSource = dtContainerUpdate;
                        gvContainer.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void AutoFillData()
    {
        try
        {
            if (ddlRequisitionNo.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 3;
                ObjBOL.Containerid = Convert.ToInt32(ddlRequisitionNo.SelectedValue);
                ObjBOL.Reqid = Convert.ToInt32(ddlRequisitionNo.SelectedValue);
                ds = ObjBLL.GetBindControl(ObjBOL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Bind_GridChangeContainer();
                }
                else
                {
                    ResetGrid();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion
    #region Validation/Reset
    private void ResetGrid()
    {
        try
        {
            gvMainRequisitionDetail.DataSource = "";
            gvMainRequisitionDetail.DataBind();
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }
    private void ResetContainerddl()
    {
        try
        {
            txtReciveDate.Text = String.Empty;
            ddlRequisitionNo.Items.Clear();
            ResetGrid();
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
            ddlVendor.SelectedIndex = 0;
            txtReciveDate.Text = String.Empty;
            ddlRequisitionNo.Items.Clear();
            ResetGrid();
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
            if (ddlVendor.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Vendor !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Vendor !");
                ddlVendor.Focus();
                return false;
            }
            if (ddlRequisitionNo.SelectedIndex == 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Container No !');", true);
                Utility.ShowMessage_Error(Page, "Please Select Container No !");
                ddlRequisitionNo.Focus();
                return false;
            }
            if (txtReciveDate.Text == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Receive Date !');", true);
                Utility.ShowMessage_Error(Page, "Please Enter Receive Date !");
                txtReciveDate.Focus();
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
    #region Event Handlers
    protected void ddlRequisitionNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtReciveDate.Text = String.Empty;
            if (ddlRequisitionNo.SelectedIndex > 0)
            {
                ResetGrid();
                AutoFillData();
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidationCheck() == true)
            {
                var EmployeeID = Utility.GetCurrentSession().EmployeeID;
                string msg = string.Empty;
                ObjBOL.Operation = 4;
                ObjBOL.Containerid = Convert.ToInt32(ddlRequisitionNo.SelectedValue);
                ObjBOL.ContainerNo = ddlRequisitionNo.SelectedItem.Text;
                if (txtReciveDate.Text != "")
                {
                    ObjBOL.ReceivedDate = Utility.ConvertDate(txtReciveDate.Text);
                }
                ObjBOL.EmployeeID = EmployeeID;
                msg = ObjBLL.StockIn(ObjBOL);
                //Utility.ShowMessage(this, msg);
                Utility.ShowMessage_Success(Page, msg);
                if (msg != "")
                {
                    Bind_Controls();
                    ResetControls();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }



    }
    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlVendor.SelectedIndex > 0)
            {
                ResetContainerddl();
                Bind_Container();
            }
            else
            {
                ResetContainerddl();                
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion
}