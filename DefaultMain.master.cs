using System;
using System.Web.UI.WebControls;
using BOLAERO;
using BLLAERO;
using System.Data;

public partial class _DefaultMain : System.Web.UI.MasterPage
{
    BOLMenu ObjBOL = new BOLMenu();
    BLLMenu ObjBLL = new BLLMenu();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Utility.IsAuthorized())
            {
                throw new Exception("User is not logged In");
            }
        }
        catch (Exception exfirst)
        {
            Utility.AddEditException(exfirst);
            Utility.LogOut();
        }
        try
        {
            if (!IsPostBack)
            {
                if (Utility.IsAuthorized())
                {
                    lblwelcomemsg.Text = "Hi " + Utility.GetCurrentSession().EmployeeName; //+ " Welcome to " + Utility.GetCurrentSession().CustomerName;            
                    populateMenuItem();
                    if (Utility.GetCurrentSession().CountryID == 19)
                    {
                        lnkPolicy.Visible = true;
                    }
                    else
                    {
                        lnkPolicy.Visible = false;
                    }
                }
                else
                {
                    Utility.SendToLoginPage();
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void populateMenuItem()
    {
        try
        {
            DataTable menuData = GetMenuData();
            AddTopMenuItems(menuData);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private DataTable GetMenuData()
    {
        DataSet ds = new DataSet();
        try
        {
            if (Session["Menu"] == null)
            {
                ObjBOL.Operation = 1;
                ObjBOL.id = Utility.GetCurrentUser();
                ds = ObjBLL.GetMenu(ObjBOL);
                Session["Menu"] = ds;
            }
            else
            {
                ds = (DataSet)Session["Menu"];
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return ds.Tables[0];
    }

    private void AddTopMenuItems(DataTable menuData)
    {
        try
        {
            DataView view = new DataView(menuData);
            view.RowFilter = "parent_id=0";
            foreach (DataRowView row in view)
            {
                //Adding the menu item
                MenuItem newMenuItem = new MenuItem(row["name"].ToString(), row["id"].ToString());
                newMenuItem.NavigateUrl = row["url"].ToString();
                menu.Items.Add(newMenuItem);
                AddChildMenuItems(menuData, newMenuItem);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
            //lblMenu.Text = ex.ToString();
        }
    }

    private void AddChildMenuItems(DataTable menuData, MenuItem parentMenuItem)
    {
        try
        {
            DataView view = new DataView(menuData);
            view.RowFilter = "parent_id=" + parentMenuItem.Value;
            foreach (DataRowView row in view)
            {
                MenuItem newMenuItem = new MenuItem(row["name"].ToString(), row["id"].ToString());
                newMenuItem.NavigateUrl = row["url"].ToString();
                parentMenuItem.ChildItems.Add(newMenuItem);
                // This code is used to recursively add child menu items filtering by ParentID
                AddChildMenuItems(menuData, newMenuItem);
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
            //lblMenu.Text = ex.ToString();
        }
    }
}
