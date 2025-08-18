using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;

public partial class Administration_AddUsersToGroup : System.Web.UI.Page
{
    BOLAddUsersToGroups ObjBOL = new BOLAddUsersToGroups();
    BLLAddUsersToGroups ObjBLL = new BLLAddUsersToGroups();
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
    /// <summary>
    /// Bind_Control() function prepare drop down list of Users add 
    /// in the list
    /// </summary>
    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 1;
            ds = ObjBLL.GetAddUsersGroups(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlAddUsersToGroup, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }
    /// <summary>
    /// if any user selected then a new panel displayed
    /// In a panel Grid View display all the Active Users 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlAddUsersToGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            PanelAssignEmployeesToGroups.Visible = true;
            DataSet ds = new DataSet();
            ObjBOL.operation = 3;
            ObjBOL.id = Convert.ToInt32(ddlAddUsersToGroup.SelectedValue);
            ObjBOL.Active = true;

            ds = ObjBLL.GetAddUsersGroups(ObjBOL);
            Utility.BindGrid(gvAddUsersToGroup, ds.Tables[0]);
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }

    /// <summary>
    /// Check Box Select or deselect
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void gvAddUsersToGroup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (CheckBox)e.Row.FindControl("chkStatus");
                if (chk.Text == "True")
                {
                    chk.Text = "";
                    chk.Checked = true;
                }
                else
                {
                    chk.Text = "";
                    chk.Checked = false;
                }

            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }
    /// <summary>
    /// Update Users in the Grid View Control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            int groupid = Convert.ToInt32(ddlAddUsersToGroup.SelectedValue);
            for (int i = 0; i <= gvAddUsersToGroup.Rows.Count - 1; i++)
            {
                CheckBox chk = (CheckBox)gvAddUsersToGroup.Rows[i].Cells[0].FindControl("chkStatus");
                Label lblID = (Label)gvAddUsersToGroup.Rows[i].Cells[1].FindControl("lblID");
                DataSet ds = new DataSet();
                ObjBOL.operation = 4;
                ObjBOL.groupid = groupid;
                int id = Convert.ToInt32(lblID.Text);
                ObjBOL.userid = id;
                // ObjBOL.status = true;
                if (chk.Checked == true)
                {
                    ObjBOL.status = true;
                }
                else
                {
                    ObjBOL.status = false;
                }
                msg = ObjBLL.SaveAddUsersGroups(ObjBOL);
                Utility.ShowMessage_Success(this, msg);

            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }

    }
}