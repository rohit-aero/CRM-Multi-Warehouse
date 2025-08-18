using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
public partial class Reports_frmPartsReport : System.Web.UI.Page
{
    BOLINVPartsInfo OBJBOL = new BOLINVPartsInfo();    
    BLLINVPartsinfo OBJBLL = new BLLINVPartsinfo();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
           Bind_Controls();
           divPartStatusReport.Attributes.Add("style", "display:block");
        }
    }
    private Boolean ValidationCheck()
    {
        try
        {
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return true;
    }
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            OBJBOL.operation = 8;
            ds = OBJBLL.GetPartsCount(OBJBOL);
            if(ds.Tables[0].Rows.Count>0)
            {
                Utility.BindDropDownListAll(ddlProduct, ds.Tables[0]);
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
            DataSet ds = new DataSet();
            OBJBOL.operation = 7;
            if (ddlProduct.SelectedIndex > 0)
            {
                OBJBOL.Productid = Convert.ToInt32(ddlProduct.SelectedValue);
            }
            ds = OBJBLL.GetPartsCount(OBJBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }
    private void Bind_Report()
    {
        try
        {
            if(ValidationCheck()==true)
            {                
                DataTable dt = ReportData();
                if (dt.Rows.Count > 0)
                {
                    gvSearch.DataSource = dt;
                    gvSearch.DataBind();
                }
                else
                {
                    gvSearch.DataSource = "";
                    gvSearch.DataBind();
                    Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
                }
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_ReportExcel()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                DataTable dt = ReportData(); 
                if (dt.Rows.Count > 0)
                {                    
                    string FileName = "Parts Information of " + ddlProduct.SelectedItem.Text + ".xls";
                    Utility.ExportToExcelDT(dt, FileName);                    
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
                }
            }
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
            Bind_Report();
            divPartStatusReport.Attributes.Add("style", "display:none");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnClearProposal_Click(object sender, EventArgs e)
    {
        try
        {
            ddlProduct.SelectedIndex = 0;                      
            int Month = DateTime.Now.Month + 2;
            gvSearch.DataSource = "";
            gvSearch.DataBind();
            //txtProposalShipDateFrom.Text = DateTime.Now.Month + "/01/" + DateTime.Now.Year;
            //txtProposalShipDateTo.Text = Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month + 2) + "/" + DateTime.Now.Year;
            divPartStatusReport.Attributes.Add("style", "display:block");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Bind_ReportExcel();
            divPartStatusReport.Attributes.Add("style", "display:none");
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}