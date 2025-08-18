using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;

public partial class Administration_FrmAssignMenuToGroups : System.Web.UI.Page
{
    BOLGroupName ObjBOL = new BOLGroupName();
    BLLGroupName ObjBLL = new BLLGroupName();
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
  /// BindControl() function prepare drop down of ddlGroup
  /// </summary>
    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 1;
            ds = ObjBLL.GetGroupName(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlGroup, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        
    }
    /// <summary>
    /// Update information of Groups
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            int groupid = Convert.ToInt32(ddlGroup.SelectedValue);
            for (int i = 0; i <= gvGroup.Rows.Count - 1; i++)
            {
                CheckBox chk = (CheckBox)gvGroup.Rows[i].Cells[0].FindControl("chkStatus");
                Label lblID = (Label)gvGroup.Rows[i].Cells[1].FindControl("lblID");
                //if (chk.Checked)
                //{
                ObjBOL.operation = 3;
                ObjBOL.groupid = groupid;
                int id = Convert.ToInt32(lblID.Text);
                ObjBOL.menuid = id;
                // ObjBOL.status = true;
                if (chk.Checked == true)
                {
                    ObjBOL.status = true;
                }
                else
                {
                    ObjBOL.status = false;
                }
                msg = ObjBLL.SaveGroupDetail(ObjBOL);
                Utility.ShowMessage_Success(this, msg);
                //}                   
            }
        }
        catch(Exception ex)
        {
            Utility.AddEditException(ex);
            
        }
    }         
    /// <summary>
    /// Display records in the time of change group fields
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
               
            PanelAssignMenuToGroups.Visible = true;
            DataSet ds = new DataSet();
            ObjBOL.operation = 4;
            ObjBOL.id = Convert.ToInt32(ddlGroup.SelectedValue);
            ObjBOL.status = true;
            ds = ObjBLL.GetGroupName(ObjBOL);
            Utility.BindGrid(gvGroup, ds.Tables[0]);
        
    }
    /// <summary>
    /// Check box Select or Deselect
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvGroup_RowDataBound(object sender, GridViewRowEventArgs e)
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
   
}  




   


