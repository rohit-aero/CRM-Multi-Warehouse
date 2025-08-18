using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Connection
/// </summary>
public class Connection
{
    public string ConnectionString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
    public SqlConnection con = new SqlConnection();

    public Connection()
    {
        con.ConnectionString = ConnectionString;
    }

    public void OpenConnection()
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
    }

    public void CloseConnection()
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
    }
}
