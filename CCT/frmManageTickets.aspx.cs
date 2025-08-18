using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;

public partial class CCT_frmManageTickets : System.Web.UI.Page
{
    BOLManageTickets ObjBOL = new BOLManageTickets();
    BLLManageTickets ObjBLL = new BLLManageTickets();
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
            ds = ObjBLL.BindDropDownManageTickets(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlTicketNo, ds.Tables[0]);
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
            ObjBOL.Operation = 3;
            ObjBOL.RepairID = ddlTicketNo.SelectedValue;
            ds = ObjBLL.GetTicketSummInfo(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                HfCustomerDetailid.Value = ds.Tables[0].Rows[0]["id"].ToString();
                gvSummary.DataSource = ds.Tables[0];
                gvSummary.DataBind();
            }
            else
            {
                gvSummary.DataSource = "";
                gvSummary.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    protected void ddlTicketNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            PanelgvInsert.Enabled = true;
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.TicketNo = ddlTicketNo.SelectedItem.Text;
            ds = ObjBLL.GetTicketInfo(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTicketno.Text = ds.Tables[0].Rows[0]["TicketNo"].ToString();
                txtTask.Text = ds.Tables[0].Rows[0]["Task"].ToString();
                txtissue.Text = ds.Tables[0].Rows[0]["Issue"].ToString();
                txtIssueOpen.Text = ds.Tables[0].Rows[0]["IssueOpenDate"].ToString();
                txtIssueClose.Text = ds.Tables[0].Rows[0]["IssueCloseDate"].ToString();
                txtPromised.Text = ds.Tables[0].Rows[0]["PromisedDate"].ToString();
                txtFollowupdate.Text = ds.Tables[0].Rows[0]["FollowUpDate"].ToString();
                txtStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
                txtAssgnedTo.Text = ds.Tables[0].Rows[0]["AssignTo"].ToString();
                Bind_Grid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSummary_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvSummary.EditIndex = e.NewEditIndex;
        Bind_Grid();
    }

    protected void gvSummary_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvSummary.EditIndex = -1;
        Bind_Grid();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            ObjBOL.Operation = 4;
            ObjBOL.RepairID = ddlTicketNo.SelectedValue;
            ObjBOL.Summary = txtSumm.Text;
            ObjBOL.SummDate = Utility.ConvertDate(txtSummDate.Text);
            msg = ObjBLL.SaveTicketSummary(ObjBOL);
            Utility.ShowMessage_Success(this, msg);
            txtSumm.Text = String.Empty;
            txtSummDate.Text = String.Empty;
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void gvSummary_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string msg = "";
            int ID = Convert.ToInt32(gvSummary.DataKeys[e.RowIndex].Value);
            ObjBOL.Operation = 5;
            GridViewRow row = gvSummary.Rows[e.RowIndex];
            ObjBOL.id = ID;
            ObjBOL.RepairID = ddlTicketNo.SelectedValue;
            TextBox txtgvSummDate = row.FindControl("txtgvSummDate") as TextBox;
            ObjBOL.SummDate = Utility.ConvertDate(txtgvSummDate.Text);
            ObjBOL.Summary = (row.FindControl("txtgvSumm") as TextBox).Text;
            msg = ObjBLL.UpdateTicketSummary(ObjBOL);
            gvSummary.EditIndex = -1;
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private void Reset()
    {
        ddlTicketNo.SelectedIndex = -1;
        foreach (Control ctrl in PanPersonelInformation.Controls)
        {
            if (ctrl.GetType() == typeof(TextBox))
            {
                ((TextBox)(ctrl)).Text = String.Empty;
            }
        }
        foreach (Control ctrl in PanelgvInsert.Controls)
        {
            if (ctrl.GetType() == typeof(TextBox))
            {
                ((TextBox)(ctrl)).Text = String.Empty;
            }
        }
        gvSummary.DataSource = "";
        gvSummary.DataBind();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
    }
}