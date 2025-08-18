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
public partial class INVManagement_frmContainer : System.Web.UI.Page
{
    BOLContainer ObjBOL = new BOLContainer();
    BLLContainer ObjBLL = new BLLContainer();
    commonclass1 cls = new commonclass1();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Bind_Controls();    
        }
    }

    private void  Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetBindControl(ObjBOL);
            if(ds.Tables[0].Rows.Count>0)
            {
                Utility.BindDropDownList(ddlRequisitionNo, ds.Tables[0]);
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
            if (ddlRequisitionNo.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Select Requisition. !');", true);
                ddlRequisitionNo.Focus();
                return false;
            }
            if (txtInvoiceNo.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Invoice No. !');", true);
                txtInvoiceNo.Focus();
                return false;
            }
            if (txtContainerNo.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Container No. !');", true);
                txtContainerNo.Focus();
                return false;
            }
            if (txtsentdate.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('Please Enter Sent Date. !');", true);
                txtsentdate.Focus();
                return false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }

    private DataTable EmptyDT()
    {
        DataTable dtEmpty = new DataTable();
        try
        {
            dtEmpty.TableName = "GridSummary";
            dtEmpty.Columns.Add(new DataColumn("Partid", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("PartNo", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("PartDes", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("ReqPriority", typeof(string)));
            dtEmpty.Columns.Add(new DataColumn("OrderQty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("ShippedQty", typeof(int)));
            dtEmpty.Columns.Add(new DataColumn("Remarks", typeof(string)));
            DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);
            //adding row to the datatable
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dtEmpty;
    }

    private DataTable EmptyDTContainer()
    {
        DataTable dt = new DataTable();
        try
        {
            dt.TableName = "ContainerSummary";
            dt.Columns.Add(new DataColumn("Partid", typeof(int)));
            dt.Columns.Add(new DataColumn("PartNo", typeof(string)));
            dt.Columns.Add(new DataColumn("PartDes", typeof(string)));
            dt.Columns.Add(new DataColumn("ReqPriority", typeof(string)));
            dt.Columns.Add(new DataColumn("OrderQty", typeof(int)));
            dt.Columns.Add(new DataColumn("ShippedQty", typeof(int)));
            dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
            ViewState["ContainerSummary"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    private void Bind_Grid()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.Reqid =Convert.ToInt32(ddlRequisitionNo.SelectedValue);
            ds = ObjBLL.GetBindControl(ObjBOL);
            if(ds.Tables[0].Rows.Count>0)
            {                
                gvContainer.DataSource = ds.Tables[0];
                gvContainer.DataBind();
                btnSave.Enabled = true;
                btnSubmit.Enabled = true;
                btnGenerate.Enabled = true;
            }
            else
            {
                gvContainer.DataSource = EmptyDTContainer();
                gvContainer.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlRequisitionNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillDetails();
            Bind_Grid();
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
            DataTable dt = EmptyDTContainer();
            DataRow dr;
            foreach (GridViewRow row in gvContainer.Rows)
            {
                dr = dt.NewRow();
                Label Partid = ((Label)row.FindControl("lblItemPartid"));
                Label partnum = ((Label)row.FindControl("lblItemPartNo"));
                Label partdesc = ((Label)row.FindControl("lblItemdes"));
                Label priority = ((Label)row.FindControl("lblItempriority"));
                Label OrderQty = ((Label)row.FindControl("lblItemOrderqty"));
                TextBox shipqty = ((TextBox)row.FindControl("txtItemshipqty"));
                TextBox REMARKS = ((TextBox)row.FindControl("txtItemRemarks"));
                dr[0] = Partid.Text;
                dr[1] = partnum.Text;
                dr[2] = partdesc.Text;
                dr[3] = priority.Text;
                dr[4] = OrderQty.Text;
                dr[5] = shipqty.Text;
                dr[6] = REMARKS.Text;
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            ViewState["ContainerSummary"] = dt;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SaveData()
    {
        try
        {
            if(ValidationCheck()==true)
            {
                string msg = "";
                ObjBOL.Operation = 3;
                ObjBOL.InvoiceNo = txtInvoiceNo.Text;
                ObjBOL.ContainerNo = txtContainerNo.Text;
                ObjBOL.SealNo = txtSealNo.Text;
                if (txtsentdate.Text != "")
                {
                    ObjBOL.SentDate = Utility.ConvertDate(txtsentdate.Text);
                }
                ObjBOL.Reqid = Convert.ToInt32(ddlRequisitionNo.SelectedValue);
                CheckGridBeforeSave();
                DataTable selected = (DataTable)ViewState["ContainerSummary"];               
                DataView dv = new DataView(selected);
                DataTable summarytemp = dv.ToTable("selected", false, "Partid", "ShippedQty", "Remarks");
                ObjBOL.ContainerDetails = summarytemp;
                ObjBOL.LoginUserId = Convert.ToInt32(Utility.GetCurrentSession().EmployeeID);
                msg = ObjBLL.BLLSaveContainerInfo(ObjBOL);
                Utility.ShowMessage(this, msg);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void FillDetails()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.Reqid = Convert.ToInt32(ddlRequisitionNo.SelectedValue);
            ds = ObjBLL.GetBindControl(ObjBOL);
            if(ds.Tables[1].Rows.Count>0)
            {
                txtInvoiceNo.Text = ds.Tables[1].Rows[0]["InvoiceNo"].ToString();
                txtContainerNo.Text = ds.Tables[1].Rows[0]["ContainerNo"].ToString();
                txtSealNo.Text = ds.Tables[1].Rows[0]["SealNo"].ToString();
                txtsentdate.Text = cls.Converter(ds.Tables[1].Rows[0]["SentDate"].ToString());
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
            SaveData();
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
            txtInvoiceNo.Text = String.Empty;
            txtContainerNo.Text = String.Empty;
            txtSealNo.Text = String.Empty;
            txtsentdate.Text = String.Empty;
            ddlRequisitionNo.SelectedIndex = 0;
            gvContainer.DataSource = "";
            gvContainer.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable ReportDataZero()
    {
        DataTable dt = new DataTable();
        try
        {
            clscon.Return_DT(dt, "EXEC [dbo].[INV_GenerateContainerDetail] '" + ddlRequisitionNo.SelectedValue + "'");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ReportDataZero();
            rprt.Load(Server.MapPath("~/Reports/rptGenerateContainer.rpt"));
            if (dt.Rows.Count > 0)
            {
                rprt.SetDataSource(dt);
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "");
            }
            else
            {
                divError.Visible = true;
                divError.InnerText = "No Matching Data Found !!";
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
}