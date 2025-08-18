using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BOLAERO;
using BLLAERO;

public partial class ContactManagement_frmSearchCostingProjects : System.Web.UI.Page
{
    BOLEngHoursCalculate ObjBOL = new BOLEngHoursCalculate();
    BLLCalculateEngHours ObjBLL = new BLLCalculateEngHours();
    commonclass1 clscon = new commonclass1();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Control();
        }
    }

    private void Bind_Control()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOL.Operation = 1;
            ds = ObjBLL.GetControls(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlProjectNo, ds.Tables[0]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlDepartment, ds.Tables[1]);
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    private DataTable Bind_Grid()
    {
        
        try
        {
            string Qstr = String.Empty;
            Qstr += " SELECT ProposalID as [Proposal No.],tblEngDepartment.[name] as [Department Name],ISNULL(tblEmployees.FirstName,'') + ' '  +  ";
            Qstr += " ISNULL(tblEmployees.LastName,'') AS [Employee Name],Convert(varchar,TaskDate,101) as [Task Date],  ";           
            Qstr += " CASE WHEN TaskNature=1 THEN 'Proposal' WHEN TaskNature=2 THEN 'Drawing' WHEN TaskNature='3' THEN 'Revit' End AS [Nature of Task], ";          
            Qstr += " CASE WHEN TaskCategory=1 THEN 'New' WHEN TaskCategory=2 THEN 'Revision' WHEN TaskCategory=3 THEN 'Correction' End AS [Task Category], ";
            Qstr += " CONVERT(VARCHAR(5),StartTime,108) as [In Time],CONVERT(VARCHAR(5),EndTime,108) as [Out Time], ";
            Qstr += " CONVERT(VARCHAR(5),TotalTime,108) as [Total Hours] ";
            Qstr += " FROM tblEngTimeSheet INNER JOIN tblEmployees ON tblEmployees.EmployeeID=tblEngTimeSheet.EmployeeID ";
            Qstr += " LEFT JOIN tblEngDepartment  on tblEmployees.EngDepID=tblEngDepartment.id ";            
            Qstr += "WHERE tblEngTimeSheet.ProposalID IS NOT NULL ";
            if (ddlProjectNo.SelectedIndex > 0)
            {
                Qstr += " AND tblEngTimeSheet.ProposalID LIKE '%" + ddlProjectNo.SelectedValue + "%' ";
            }
            if (ddlDepartment.SelectedIndex > 0)
            {
                Qstr += " AND tblEmployees.EngDepID= '" + ddlDepartment.SelectedValue + "' ";
            }
            if (ddlEmployee.SelectedIndex > 0)
            {
                Qstr += " AND tblEngTimeSheet.EmployeeID= '" + ddlEmployee.SelectedValue + "' ";
            }
            if (ddlNatureOfTask.SelectedIndex > 0)
            {
                Qstr += " AND tblEngTimeSheet.TaskNature= '" + ddlNatureOfTask.SelectedValue + "' ";
            }
            if (ddlCategory.SelectedIndex > 0)
            {
                Qstr += " AND tblEngTimeSheet.TaskCategory= '" + ddlCategory.SelectedValue + "' ";
            }
            
            clscon.Return_DT(dt, Qstr);
            if(dt.Rows.Count>0)
            {                
                gvProjectSearch.DataSource = dt;
                gvProjectSearch.DataBind();
                btnExporttoExcel.Enabled = true;
            }
            else
            {
                gvProjectSearch.DataSource = "";
                gvProjectSearch.DataBind();
                btnExporttoExcel.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
        return dt;        
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Bind_Grid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddlProjectNo.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;
            ddlDepartment.SelectedIndex = 0;
            ddlEmployee.DataSource = "";
            ddlEmployee.DataBind();
            ddlCategory.SelectedIndex = 0;
            ddlNatureOfTask.SelectedIndex = 0;
            gvProjectSearch.DataSource = "";
            gvProjectSearch.DataBind();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }

    protected void btnExporttoExcel_Click(object sender, EventArgs e)
    {
        try
        {
            dt = Bind_Grid();
            Utility.ExportToExcelDT(dt, "Engineering Time Sheet");
        }
        catch (Exception ex)
        {

            Utility.AddEditException(ex);
        }
    }

    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDepartment.SelectedIndex > 0)
            {
                DataSet ds = new DataSet();
                ObjBOL.Operation = 1;
                ObjBOL.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);
                ds = ObjBLL.GetControls(ObjBOL);
                if (ds.Tables[2].Rows.Count > 0)
                {
                    Utility.BindDropDownListAll(ddlEmployee, ds.Tables[2]);
                }
                else
                {
                    ddlEmployee.DataSource = "";
                    ddlEmployee.DataBind();
                }
            }
            else
            {
                ddlEmployee.DataSource = "";
                ddlEmployee.DataBind();
            }           
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
}