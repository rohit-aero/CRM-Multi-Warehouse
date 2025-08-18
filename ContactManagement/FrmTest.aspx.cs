using System;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
///  Proposal Form (06 December 2018) Rohit Kumar
/// </summary>
public partial class Masters_FrmTest : System.Web.UI.Page
{
    BOLManageCity ObjBOL = new BOLManageCity();
    BLLManageCity ObjBLL = new BLLManageCity();
    commonclass1 cls = new commonclass1();
    // Page load event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Bind_Controls();
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
       
    }

    // Bind all dropdownlist here
    private void Bind_Controls()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.operation = 1;
            ds = ObjBLL.GetTest(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                TextBox1.Text = cls.Converter(Convert.ToString(ds.Tables[0].Rows[0]["ShipDate"]));
            }
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
                         
    }   
    
    // Save data
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            ObjBOL.operation = 2;
            ObjBOL.ShipDate = Utility.ConvertDate(TextBox1.Text);
            msg = ObjBLL.SaveTest(ObjBOL);
            Utility.ShowMessage_Success(this, msg);
            Utility.MaintainLogs("FrmTest.aspx", "Save");
            Bind_Controls();
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
        
    }

    // Cancel command
    protected void btnCancel_Click(object sender, EventArgs e)
    {
       
    }    
}