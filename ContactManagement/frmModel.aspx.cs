using BLLAERO;
using BOLAERO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactManagement_frmModel : System.Web.UI.Page
{
    BOLModel ObjBOL = new BOLModel();
    BLLModel ObjBLL = new BLLModel();
    public Boolean test = false;
    public DataTable testData;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Dropdowns();
        }
    }

    private void Bind_Dropdowns()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetModelData(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownList(ddlTest, ds.Tables[0]);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 2;
            ObjBOL.id = Convert.ToInt32(ddlTest.SelectedValue);
            ds = ObjBLL.GetSubModel(ObjBOL);
            testData = ds.Tables[0];
            test = true;
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindCheckBoxListWOAll(chkChild, ds.Tables[0]);
                Utility.BindCheckBoxListWOAll(chk1, ds.Tables[1]);
                Utility.BindCheckBoxListWOAll(chk2, ds.Tables[2]);
                Utility.BindCheckBoxListWOAll(chk3, ds.Tables[3]);
                Utility.BindCheckBoxListWOAll(chk4, ds.Tables[4]);
                Utility.BindCheckBoxListWOAll(chk5, ds.Tables[5]);
                Utility.BindCheckBoxListWOAll(chk6, ds.Tables[6]);
                Utility.BindCheckBoxListWOAll(chk7, ds.Tables[7]);
                Utility.BindCheckBoxListWOAll(chk8, ds.Tables[8]);
                Utility.BindCheckBoxListWOAll(chk9, ds.Tables[9]);
                Utility.BindCheckBoxListWOAll(chk10, ds.Tables[10]);
                foreach (ListItem li in chkChild.Items)
                {
                    li.Attributes.Add("JSvalue", li.Value);
                    li.Attributes.Add("JSText", li.Text);
                    li.Attributes.Add("Title", li.Text);
                }
            }
            else
            {
                chkChild.DataSource = "";
                chkChild.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

}