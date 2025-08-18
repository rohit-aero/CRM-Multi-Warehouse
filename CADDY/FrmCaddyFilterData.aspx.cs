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
public partial class CADDY_FrmCaddyFilterData : System.Web.UI.Page
{
    BOLCADDYENGTasks ObjBOL = new BOLCADDYENGTasks();
    BLLManageCADDYENGTasks ObjBLL = new BLLManageCADDYENGTasks();
    ReportDocument rprt = new ReportDocument();
    commonclass1 clscon = new commonclass1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Utility.IsAuthorized())
        {
            if (!IsPostBack)
            {
                Bind_Controls();
            }
        }

    }
    private Boolean ValidationCheck()
    {
        try
        {
            if (txtReqForwToIndiaFrom.Text != "")
            {
                if (txtReqForwToIndiaTo.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Req. Forward To India To");
                    txtReqForwToIndiaTo.Focus();
                    return false;
                }
            }
            if (txtReqForwToIndiaTo.Text != "")
            {
                if (txtReqForwToIndiaFrom.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Req. Forward To India From");
                    txtReqForwToIndiaFrom.Focus();
                    return false;
                }
            }
            if (txtSendToCaddyFrom.Text != "")
            {
                if (txtSendToCaddyTo.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Sent To Caddy To");
                    txtSendToCaddyTo.Focus();
                    return false;
                }
            }
            if (txtSendToCaddyTo.Text != "")
            {
                if (txtSendToCaddyFrom.Text == "")
                {
                    Utility.ShowMessage_Error(Page, "Please Enter Sent To Caddy From");
                    txtSendToCaddyFrom.Focus();
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

    private DataTable ReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            string Qstr = String.Empty;
            Qstr += "SELECT ProjectID,JobNo,JobName,ModelName,PMCaddy,  ";
            Qstr += " ProjectType,Nature,ReqFWDToIndia,AssingedTo,[Priority],ProjectDueDate,SentToCaddy, ";
            Qstr += " ChangeColor,ResponseTime,Remarks,Color, ";
            Qstr += " RemarksByPM,[Status],JobType,StatusID FROM CADDY_FILTERDATA() ";
            Qstr += "Where ProjectID IS NOT NULL ";
            if (ddlJobNo.SelectedIndex > 0)
            {
                Qstr += " AND ProjectID= '" + ddlJobNo.SelectedValue + "'";
            }
            if (ddlJobName.SelectedIndex > 0)
            {
                Qstr += " AND ProjectID= '" + ddlJobName.SelectedValue + "'";
            }
            if (ddlJobType.SelectedIndex > 0)
            {
                Qstr += " AND JobType= '" + ddlJobType.SelectedItem.Text + "'";
            }
            if (ddlProjectType.SelectedIndex > 0)
            {
                Qstr += " AND ProjectType= '" + ddlProjectType.SelectedItem.Text + "'";
            }
            if (ddlPMCaddy.SelectedIndex > 0)
            {
                Qstr += " AND PMCaddy= '" + ddlPMCaddy.SelectedItem.Text + "'";
            }
            if (ddlNature.SelectedIndex > 0)
            {
                Qstr += " AND Nature= '" + ddlNature.SelectedItem.Text + "'";
            }
            if (ddlStatus.SelectedIndex > 0)
            {
                Qstr += " AND [Status]= '" + ddlStatus.SelectedItem.Text + "'";
            }
            if (txtReqForwToIndiaFrom.Text != "" && txtReqForwToIndiaTo.Text != "")
            {
                Qstr += " AND ([ReqFWDToIndia] BETWEEN '" + txtReqForwToIndiaFrom.Text + "' AND '" + txtReqForwToIndiaTo.Text + "')";
            }
            if (txtSendToCaddyFrom.Text != "" && txtSendToCaddyTo.Text != "")
            {
                Qstr += " AND ([SentToCaddy] BETWEEN '" + txtSendToCaddyFrom.Text + "' AND '" + txtSendToCaddyTo.Text + "')";
            }
            clscon.Return_DT(dt, Qstr);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;
    }



    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 14;
            ds = ObjBLL.GetFilterData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlJobNo, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlJobName, ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlJobType, ds.Tables[2]);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlPMCaddy, ds.Tables[3]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlStatus, ds.Tables[4]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectType, ds.Tables[5]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void Bind_Report()
    {
        try
        {
            if (ValidationCheck() == true)
            {
                DataTable dt = ReportData();
                if (dt.Rows.Count > 0)
                {
                    rprt.Load(Server.MapPath("~/CADDY/rptEngTaskFilterDataReport.rpt"));
                    if (dt.Rows.Count > 0)
                    {
                        TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                        txtheader.Text = "CADDY ENGINEERING TASK Report - " + DateTime.Now.ToString("dddd, dd MMMM yyyy").Replace(',', ' ');
                        rprt.SetDataSource(dt);
                        rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                        rprt.Close();
                        rprt.Dispose();
                    }
                    else
                    {
                        rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                        TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                        txtheader.Text = "CADDY ENGINEERING TASK Report - " + DateTime.Now.ToString("dddd, dd MMMM yyyy").Replace(',', ' ');
                        rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
                    }
                }
                else
                {
                    Utility.ShowMessage_Error(Page, "No Data Matched !!");
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
            ddlJobNo.SelectedIndex = 0;
            ddlJobName.SelectedIndex = 0;
            ddlJobType.SelectedIndex = 0;
            ddlProjectType.SelectedIndex = 0;
            ddlPMCaddy.SelectedIndex = 0;
            ddlNature.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            txtReqForwToIndiaFrom.Text = String.Empty;
            txtReqForwToIndiaTo.Text = String.Empty;
            txtSendToCaddyFrom.Text = String.Empty;
            txtReqForwToIndiaTo.Text = String.Empty;
            ddlProjectType.Items.Insert(0, new ListItem("All", "0"));
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}