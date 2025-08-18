using System;
using System.Data;
using BOLAERO;
using BLLAERO;
using System.Web.UI.WebControls;


public partial class _Default_New : System.Web.UI.Page
{   
    BOLManageExtensions ObjBOLExt = new BOLManageExtensions();
    BLLManageExtensions ObjBLLExt = new BLLManageExtensions();  
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Utility.IsAuthorized())
                {                                    
                    BindControls(1);                            
                }              
            }            
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #region Page Load Bind Controls
    private void BindControls(int compantID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOLExt.Operation = 1;
            ds = ObjBLLExt.Return_DataSet(ObjBOLExt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlLookupCompany, ds.Tables[0]);
                if (ddlLookupCompany.Items.Count > 0 && compantID == 1)
                {
                    ddlLookupCompany.SelectedValue = "1";
                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlLookUpOffice, ds.Tables[1]);
                if (ddlLookUpOffice.Items.Count > 0)
                {
                    ddlLookUpOffice.SelectedIndex = 0;
                }
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlLookupDepartment, ds.Tables[2]);
                if (ddlLookupDepartment.Items.Count > 0)
                {
                    ddlLookupDepartment.SelectedIndex = 0;
                }
            }
            else
            {
                ddlLookupDepartment.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlExtension, ds.Tables[3]);
                if (ddlExtension.Items.Count > 0)
                {
                    ddlExtension.SelectedIndex = 0;
                }

            }
            else
            {
                ddlExtension.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlLookupEmployee, ds.Tables[4]);
                if (ddlLookupEmployee.Items.Count > 0)
                {
                    ddlLookupEmployee.SelectedIndex = 0;
                }
            }
            else
            {
                ddlLookupEmployee.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
            }
            if (ddlLookupCompany.SelectedValue == "1")
            {
                BindAllddls(ddlLookupCompany.SelectedValue);
            }
            BindExtGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BindAllddls(string companyid)
    {
        try
        {
            BIndOffice(companyid);
            AutoBindddls(companyid);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void AutoBindddls(string companyid)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOLExt.Operation = 9;
            ObjBOLExt.CompanyID = Convert.ToInt32(companyid);
            ds = ObjBLLExt.Return_DataSet(ObjBOLExt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlLookupDepartment, ds.Tables[0]);
                if (ddlLookupDepartment.Items.Count > 0)
                {
                    ddlLookupDepartment.SelectedIndex = 0;
                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlLookupEmployee, ds.Tables[1]);
                if (ddlLookupEmployee.Items.Count > 0)
                {
                    ddlLookupEmployee.SelectedIndex = 0;
                }
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlExtension, ds.Tables[2]);
                if (ddlExtension.Items.Count > 0)
                {
                    ddlExtension.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion


    #region Common Functions
    private void BIndExtensionEmployeesEmployee(string EmployeeDetailID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOLExt.Operation = 8;
            if (EmployeeDetailID != "")
            {
                ObjBOLExt.EmployeeDetailID = Convert.ToInt32(EmployeeDetailID);
            }
            ds = ObjBLLExt.Return_DataSet(ObjBOLExt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlLookupEmployee, ds.Tables[0]);
                if (ddlLookupEmployee.Items.Count > 0)
                {
                    ddlLookupEmployee.SelectedIndex = 0;
                }
            }

        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void SyncData(string EmployeeDetailID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOLExt.EmployeeDetailID = Convert.ToInt32(EmployeeDetailID);
            ObjBOLExt.Operation = 3;
            ds = ObjBLLExt.Return_DataSet(ObjBOLExt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["officeid"].ToString() != null)
                {
                    ddlLookupCompany.SelectedValue = ds.Tables[0].Rows[0]["companyid"].ToString();
                    ddlLookUpOffice.SelectedValue = ds.Tables[0].Rows[0]["officeid"].ToString();
                    BIndDepartment(ddlLookUpOffice.SelectedValue);
                    ddlLookupDepartment.SelectedValue = ds.Tables[0].Rows[0]["departmentid"].ToString();
                    BIndExtensionEmployeesEmployee(ddlExtension.SelectedValue);
                    ddlLookupEmployee.SelectedValue = ds.Tables[0].Rows[0]["EmployeeID"].ToString();
                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BIndOffice(string CompanyID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOLExt.Operation = 4;
            ObjBOLExt.CompanyID = Convert.ToInt32(CompanyID);
            ds = ObjBLLExt.Return_DataSet(ObjBOLExt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlLookUpOffice, ds.Tables[0]);
                if (ddlLookUpOffice.Items.Count > 0)
                {
                    ddlLookUpOffice.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BIndDepartment(string OfficeID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOLExt.Operation = 5;
            ObjBOLExt.CompanyOfficeID = Convert.ToInt32(OfficeID);
            ds = ObjBLLExt.Return_DataSet(ObjBOLExt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlLookupDepartment, ds.Tables[0]);
                if (ddlLookupDepartment.Items.Count > 0)
                {
                    ddlLookupDepartment.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BIndEmployee(string DepartmentID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOLExt.Operation = 6;
            ObjBOLExt.CompanyOfficeDepartmentID = Convert.ToInt32(DepartmentID);
            ds = ObjBLLExt.Return_DataSet(ObjBOLExt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlLookupEmployee, ds.Tables[0]);
                Utility.BindDropDownListAll(ddlExtension, ds.Tables[1]);
                if (ddlLookUpOffice.SelectedIndex == 0)
                {
                    Utility.BindDropDownListAll(ddlLookUpOffice, ds.Tables[2]);
                    if (ddlLookUpOffice.Items.Count > 0)
                    {
                        ddlLookUpOffice.SelectedIndex = 0;
                    }
                }
                if (ddlLookupEmployee.Items.Count > 0)
                {
                    ddlLookupEmployee.SelectedIndex = 0;
                }
                if (ddlExtension.Items.Count > 0)
                {
                    ddlExtension.SelectedIndex = 0;
                }

            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void BIndExt(string EmployeeID)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjBOLExt.Operation = 7;
            ObjBOLExt.EmployeeID = Convert.ToInt32(EmployeeID);
            ds = ObjBLLExt.Return_DataSet(ObjBOLExt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utility.BindDropDownListAll(ddlExtension, ds.Tables[0]);
                if (ddlLookupDepartment.Items.Count > 0)
                {
                    if (ddlLookupDepartment.SelectedIndex == 0)
                    {
                        Utility.BindDropDownListAll(ddlLookupDepartment, ds.Tables[1]);
                        if (ddlLookupDepartment.Items.Count > 0)
                        {
                            ddlLookupDepartment.SelectedIndex = 0;
                        }
                    }
                }
                if (ddlLookUpOffice.Items.Count > 0)
                {
                    if (ddlLookUpOffice.SelectedIndex == 0)
                    {
                        Utility.BindDropDownListAll(ddlLookUpOffice, ds.Tables[2]);
                        if (ddlLookUpOffice.Items.Count > 0)
                        {
                            ddlLookUpOffice.SelectedIndex = 0;
                        }
                    }
                }

                if (ddlExtension.Items.Count > 0)
                {
                    ddlExtension.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion
    #region Drop down Selected Index
    protected void ddlExtension_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetGrid();
            if (ddlExtension.SelectedIndex > 0)
            {
                SyncData(ddlExtension.SelectedValue);
            }
            else
            {
                BindControls(0);
            }
            BindExtGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void ddlLookupEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetEmployee();
            if (ddlLookupEmployee.SelectedIndex > 0)
            {
                BIndExt(ddlLookupEmployee.SelectedValue);
            }
            else
            {
                BindControls(0);
            }
            BindExtGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void ddlLookupDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetDepartment();
            if (ddlLookupDepartment.SelectedIndex > 0)
            {
                BIndEmployee(ddlLookupDepartment.SelectedValue);
            }
            else
            {
                BindControls(0);
            }
            BindExtGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void ddlLookUpOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetOffice();
            if (ddlLookUpOffice.SelectedIndex > 0)
            {
                BIndDepartment(ddlLookUpOffice.SelectedValue);
            }
            else
            {
                BindControls(0);
            }
            BindExtGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    protected void ddlLookupCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ResetCompany();
            if (ddlLookupCompany.SelectedIndex > 0)
            {
                BIndOffice(ddlLookupCompany.SelectedValue);
            }
            else
            {
                BindControls(0);
            }
            BindExtGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion
    #region Grid FFunctionality

    public void BindExtGrid()
    {
        try
        {
            DataSet ds = new DataSet();
            string Qstr = "";
            string FQstr = "";
            if (ddlLookupCompany.SelectedIndex > 0)
            {
                Qstr += " AND tblEmployeesDetail.companyid= '" + ddlLookupCompany.SelectedValue + "'";
            }
            if (ddlLookUpOffice.SelectedIndex > 0)
            {
                Qstr += " AND tblEmployeesDetail.officeid= '" + ddlLookUpOffice.SelectedValue + "'";
            }
            if (ddlLookupDepartment.SelectedIndex > 0)
            {
                Qstr += " AND tblEmployeesDetail.departmentid = '" + ddlLookupDepartment.SelectedValue + "'";
            }
            if (ddlLookupEmployee.SelectedIndex > 0)
            {
                Qstr += " AND tblEmployeesDetail.employeeid = '" + ddlLookupEmployee.SelectedValue + "'";
            }
            if (ddlExtension.SelectedIndex > 0)
            {
                string extension = ddlExtension.SelectedItem.Text.Substring(0, 3);
                Qstr += " AND tblEmployeesDetail.ext= '" + extension + "'";
            }
            Qstr += " order by CONCAT(Employee.FirstName + ' ', Employee.LastName),tblEmployeesDetail.officeid asc ";
            FQstr = Qstr;
            ObjBOLExt.Operation = 2;
            ObjBOLExt.SearchVar = FQstr;
            ds = ObjBLLExt.Return_DataSet(ObjBOLExt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvManageOffExt.DataSource = ds.Tables[0];
                gvManageOffExt.DataBind();
                ViewState["dirState"] = ds.Tables[0];
                lblShowRecords.Visible = true;
                lblShowRecords.Text = "Total No. of Records: " + Convert.ToString(ds.Tables[0].Rows.Count);
            }
            else
            {
                ResetGrid();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    protected void gvManageOffExt_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                DataView dataView = new DataView(dtrslt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                gvManageOffExt.DataSource = dataView;
                gvManageOffExt.DataBind();

            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + "DESC";
                gvManageOffExt.DataSource = dtrslt;
                gvManageOffExt.DataBind();
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private string ConvertSortDirectionToSql(System.Web.UI.WebControls.SortDirection sortDirection)
    {
        switch (GridViewSortDirection)
        {
            case "ASC":
                GridViewSortDirection = "DESC";
                break;

            case "DESC":
                GridViewSortDirection = "ASC";
                break;
        }
        return GridViewSortDirection;
    }

    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "DESC"; }
        set { ViewState["SortDirection"] = value; }
    }

    protected void btnExportDirToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            BindExtGrid();
            string fileName = "Directory";
            DataTable dt = (DataTable)ViewState["dirState"];
            string[] columnsToRemove = { "Company", "Office", "Department" };
            foreach (string col in columnsToRemove)
            {
                if (dt.Columns.Contains(col)) // Ensure the column exists before removing
                {
                    dt.Columns.Remove(col);
                }
            }
            dt.Columns["Name"].SetOrdinal(0);
            dt.Columns["OfficeExt"].ColumnName="Office";
            dt.Columns["Office"].SetOrdinal(1);
            Utility.ExportToExcelDT(dt, fileName);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    #endregion
    #region Reset
    private void ClearCompanyList()
    {
        try
        {
            if (ddlLookupCompany.Items.Count > 0)
            {
                ddlLookupCompany.SelectedIndex = 0;
                ddlLookupCompany.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearOfficeList()
    {
        try
        {
            if (ddlLookUpOffice.SelectedIndex > 0)
            {
                ddlLookUpOffice.SelectedIndex = 0;
                ddlLookUpOffice.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearDepartmentList()
    {
        try
        {
            if (ddlLookupDepartment.Items.Count > 0)
            {
                ddlLookupDepartment.Items.Clear();
                ddlLookupDepartment.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearEmployeeList()
    {
        try
        {
            if (ddlLookupEmployee.Items.Count > 0)
            {
                ddlLookupEmployee.Items.Clear();
                ddlLookupEmployee.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ClearExtensionList()
    {
        try
        {
            if (ddlExtension.Items.Count > 0)
            {
                ddlExtension.Items.Clear();
                ddlExtension.Items.Insert(0, new System.Web.UI.WebControls.ListItem("All", "0"));
            }
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
            ClearCompanyList();
            ClearOfficeList();
            ClearDepartmentList();
            ClearEmployeeList();
            ClearExtensionList();
            ResetGrid();
            BindControls(1);
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetCompany()
    {
        try
        {
            ClearOfficeList();
            ClearDepartmentList();
            ClearEmployeeList();
            ClearExtensionList();
            ResetGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetOffice()
    {
        try
        {
            ClearDepartmentList();
            ClearEmployeeList();
            ClearExtensionList();
            ResetGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetDepartment()
    {
        try
        {
            ClearEmployeeList();
            ClearExtensionList();
            ResetGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    private void ResetEmployee()
    {
        try
        {
            ClearExtensionList();
            ResetGrid();
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }


    private void ResetGrid()
    {
        try
        {
            gvManageOffExt.DataSource = "";
            gvManageOffExt.DataBind();
            lblShowRecords.Visible = false;
            lblShowRecords.Text = String.Empty;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }
    #endregion
}