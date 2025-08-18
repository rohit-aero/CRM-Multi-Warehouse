using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
public partial class Reports_frmAeroOpenProposals : System.Web.UI.Page
{
    BOLOpenProposalReports OBJBOL = new BOLOpenProposalReports();
    BLLOpenProposalReportDate OBJBLL = new BLLOpenProposalReportDate();
    commonclass1 clscon = new commonclass1();
    ReportDocument rprt = new ReportDocument();

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
            DataTable dt = new DataTable();
            clscon.Return_DT(dt, "EXEC [dbo].[Get_OpenProposals] 3");
            if (dt.Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlRepGroup, dt);
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
            DataTable dt = new DataTable();
            string strDateFrom = "";
            string strDateTo = "";
            string headerText = ddlRepGroup.SelectedItem.Text + " - Open Proposals Report ";
            if (txtProposalDateFrom.Text != "" && txtProposalDateTo.Text != "")
            {
                DateTime dtfrom = Convert.ToDateTime(txtProposalDateFrom.Text);
                DateTime dtto = Convert.ToDateTime(txtProposalDateTo.Text);
                strDateFrom = dtfrom.ToString("MM/dd/yyyy");
                strDateTo = dtto.ToString("MM/dd/yyyy");
                headerText += " From " + txtProposalDateFrom.Text + " to " + txtProposalDateTo.Text;
            }
            string Qstr = string.Empty;
            if (ddlRepGroup.SelectedIndex > 0)
            {
                Qstr += " AND tblRepGroup.id = " + ddlRepGroup.SelectedValue;
            }
            if (txtProposalDateFrom.Text != "" && txtProposalDateTo.Text != "")
            {
                Qstr += " AND tblPFiles.ProposalDate BETWEEN ''" + strDateFrom + "'' AND ''" + strDateTo + "''";
            }
            Qstr += " ORDER BY tblRepGroup.[name], tblPFiles.ProposalDate";
            clscon.Return_DT(dt, "EXEC [dbo].[Get_OpenProposals] 1,'" + Qstr + "'");
            rprt.Load(Server.MapPath("~/Reports/rptOpenProposals.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = headerText;
                rprt.SetDataSource(dt);
                rptSalesRepGroup.ReportSource = rprt;
                rptSalesRepGroup.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                //Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = headerText;
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
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

    private void Bind_ReportProjects()
    {
        try
        {
            DataTable dt = new DataTable();
            string strDateFrom = "";
            string strDateTo = "";
            string headerText = ddlRepGroup.SelectedItem.Text + " - Projects Report ";
            if (txtProposalDateFrom.Text != "" && txtProposalDateTo.Text != "")
            {
                DateTime dtfrom = Convert.ToDateTime(txtProposalDateFrom.Text);
                DateTime dtto = Convert.ToDateTime(txtProposalDateTo.Text);
                strDateFrom = dtfrom.ToString("MM/dd/yyyy");
                strDateTo = dtto.ToString("MM/dd/yyyy");
                headerText += " From " + txtProposalDateFrom.Text + " to " + txtProposalDateTo.Text;
            }

            string Qstr = string.Empty;
            if (ddlRepGroup.SelectedIndex > 0)
            {
                Qstr += " AND tblRepGroup.id = " + ddlRepGroup.SelectedValue;
            }
            if (txtProposalDateFrom.Text != "" && txtProposalDateTo.Text != "")
            {
                Qstr += " AND tblPFiles.ProposalDate BETWEEN ''" + strDateFrom + "'' AND ''" + strDateTo + "''";
            }
            Qstr += " ORDER BY tblRepGroup.[name], tblPFiles.ProposalDate";
            clscon.Return_DT(dt, "EXEC [dbo].[Get_OpenProposals] 2,'" + Qstr + "'");
            rprt.Load(Server.MapPath("~/Reports/rptJobsReport.rpt"));
            if (dt.Rows.Count > 0)
            {
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = headerText;
                rprt.SetDataSource(dt);
                rptSalesRepGroup.ReportSource = rprt;
                rptSalesRepGroup.DataBind();
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
            }
            else
            {
                //Utility.ShowMessage_Error(Page, "No Matching Data Found !!");
                rprt.Load(Server.MapPath("~/Reports/rptNoDataFound.rpt"));
                TextObject txtheader = (TextObject)rprt.ReportDefinition.ReportObjects["txtHeader"];
                txtheader.Text = headerText;
                rprt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, txtheader.Text);
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

    protected void btnSearchProposal_Click(object sender, EventArgs e)
    {
        try
        {
            if (rdbOptions.SelectedValue == "1")
            {
                Bind_Report();
            }
            else if (rdbOptions.SelectedValue == "2")
            {
                Bind_ReportProjects();
            }
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
    }

    protected void btnClearProposal_Click(object sender, EventArgs e)
    {
        try
        {
            ddlRepGroup.SelectedIndex = 0;
            rdbOptions.SelectedValue = "1";
            txtProposalDateFrom.Text = String.Empty;
            txtProposalDateTo.Text = String.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}