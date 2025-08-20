using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using BOLAERO;
using BLLAERO;
using System.Data;
using System.Text;
using System.IO;
using SD = System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using CrystalDecisions.CrystalReports.Engine;
using System.Net.Mail;
using System.Configuration;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Globalization;

public static class Utility
{
    public static DataSet GeYTDQuotesData(int Operation)
    {
        DataSet ds = new DataSet();
        BOLQuotesandOrders ObjBOL = new BOLQuotesandOrders();
        BLLYTDQuotesData ObjBLL = new BLLYTDQuotesData();
        ObjBOL.Operation = Operation;
        ds = ObjBLL.GetYTDQuotesData(ObjBOL);
        return ds;
    }

    public static DataSet GetDashboardData(int Operation)
    {
        DataSet ds = new DataSet();
        commonclass1 cls = new commonclass1();
        cls.Return_DS(ds, "EXEC Get_DashboardReports " + Operation);
        return ds;
    }
    //public Utility()
    //{
    //	//
    //	// TODO: Add constructor logic here
    //	//
    //}
    enum Oper
    {
        Select = 'S',
        Update = 'U',
        Insert = 'I',
        Exception = 'E'
    }
    public enum EmailType
    {
        Inventory,
        Sales
    }

    //Two Level Export to Excel Grid
    public static DataTable GetDistinctColumnValues(DataTable dt, string columnName)
    {
        DataTable distinctTable = new DataTable();
        distinctTable.Columns.Add(columnName, typeof(string));
        var distinctValues = dt.AsEnumerable().Select(row => row.Field<string>(columnName)).Distinct();
        foreach (var value in distinctValues)
        {
            DataRow newRow = distinctTable.NewRow();
            newRow[columnName] = value;
            distinctTable.Rows.Add(newRow);
        }
        return distinctTable;
    }

    public static DataTable SortDataTable(DataTable dt, string columnName)
    {
        try
        {
            DataView dataView = dt.DefaultView;
            dataView.Sort = columnName + " ASC";
            return dataView.ToTable();
        }
        catch (Exception ex)
        {
           AddEditException(ex);
        }
        return dt;
    }

    public static DataTable FilterDataTable(DataTable dt, string columnName, string filterValue)
    {
        DataTable filteredDataTable = new DataTable();
        try
        {
            DataRow[] filteredRows = dt.Select(columnName + " = '" + filterValue + "'");
            filteredDataTable = dt.Clone();
            foreach (DataRow row in filteredRows)
            {
                filteredDataTable.ImportRow(row);
            }
        }
        catch (Exception ex)
        {
            AddEditException(ex);
        }
        return filteredDataTable;
    }

    public static void AddSubtotal(ExcelWorksheet workSheet, int rowMain, double[] subTotals, int[] columns)
    {
        try
        {
            for (int i = 1; i < columns.Length + 1; i++)
            {
                workSheet.Cells[rowMain, columns[i - 1]].Value = subTotals[i - 1];
                workSheet.Cells[rowMain, columns[i - 1]].Style.Font.Bold = true;
                workSheet.Cells[rowMain, columns[i - 1]].Style.Numberformat.Format = "$#,##0.00"; // Format as currency
                workSheet.Cells[rowMain, columns[i - 1]].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            }

            // Reset totals for the new company
            for (int i = 0; i < subTotals.Length; i++)
            {
                subTotals[i] = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public static void AddGrandtotal(ExcelWorksheet workSheet, int rowMain, double[] GrandTotals, int[] columns)
    {
        try
        {
            for (int i = 1; i < columns.Length + 1; i++)
            {
                workSheet.Cells[rowMain, columns[i - 1]].Value = GrandTotals[i - 1];
                workSheet.Cells[rowMain, columns[i - 1]].Style.Font.Bold = true;
                workSheet.Cells[rowMain, columns[i - 1]].Style.Numberformat.Format = "$#,##0.00"; // Format as currency
                workSheet.Cells[rowMain, columns[i - 1]].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            }

            // Reset totals for the new company
            for (int i = 0; i < GrandTotals.Length; i++)
            {
                GrandTotals[i] = 0;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public static void AddHeaders(ExcelWorksheet worksheet, string[] headers)
    {
        try
        {
            for (int i = 0; i < headers.Length; i++)
            {
                SetCellValueAndStyle(worksheet, 2, i + 1, headers[i], true, 0, null, 0);
            }
            worksheet.Cells["A2:L2"].Style.Font.Bold = true;
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public static void SetCellValueAndStyle(ExcelWorksheet worksheet, int row, int column, object value, bool isBold, int? fontSize, string numberFormat, int? width)
    {
        try
        {
            worksheet.Cells[row, column].Value = value;
            if (isBold)
            {
                worksheet.Cells[row, column].Style.Font.Bold = true;
            }
            if (fontSize.HasValue)
            {
                worksheet.Cells[row, column].Style.Font.Size = fontSize.Value;
            }
            if (numberFormat != null)
            {
                worksheet.Cells[row, column].Style.Numberformat.Format = numberFormat;
            }
            if (width.HasValue)
            {
                worksheet.Column(column).Width = width.Value;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }

    }

    public static void SetCellValue(ExcelWorksheet worksheet, int row, int column, object value, string numberFormat, ExcelHorizontalAlignment? alignment)
    {
        try
        {
            worksheet.Cells[row, column].Value = value;
            if (!string.IsNullOrEmpty(numberFormat))
            {
                worksheet.Cells[row, column].Style.Numberformat.Format = numberFormat;
            }
            if (alignment.HasValue)
            {
                worksheet.Cells[row, column].Style.HorizontalAlignment = alignment.Value;
            }
        }
        catch (Exception ex)
        {
            Utility.AddEditException(ex);
        }
    }

    public static HashSet<MailAddress> GetMailAddresses(EmailType emailType, string group, Dictionary<EmailType, Dictionary<string, HashSet<MailAddress>>> emailDictionary, string displayNameFilter, int operation, string formName, string formOperation)
    {
        try
        {
            if (emailDictionary.ContainsKey(emailType) && emailDictionary[emailType].ContainsKey(group))
            {
                // Pass the display name filter to the BindInvEmailFromDatabase method
                BindInvEmailFromDatabase(emailType, group, displayNameFilter, operation, formName, formOperation);
                return emailDictionary[emailType][group];
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            AddEditException(ex);
            return null;
        }
    }

    public static Dictionary<EmailType, Dictionary<string, HashSet<MailAddress>>> emailDictionaryInventory = new Dictionary<EmailType, Dictionary<string, HashSet<MailAddress>>>
    {
        { EmailType.Inventory, new Dictionary<string, HashSet<MailAddress>>
            {
                { "SendToList", new HashSet<MailAddress>() },
                { "ccList", new HashSet<MailAddress>() },
            }
        },
        { EmailType.Sales, new Dictionary<string, HashSet<MailAddress>>
            {
                { "SendToList", new HashSet<MailAddress>() },
                { "ccList", new HashSet<MailAddress>() },
            }
        }
    };

    public static void BindInvEmailFromDatabase(EmailType emailType, string group, string displayNameFilter, int operation, string formName, string formOperation)
    {
        try
        {
            BOLBindEmailAddress ObjBOL = new BOLBindEmailAddress();
            BLLBindEmailAddress ObjBLL = new BLLBindEmailAddress();
            DataSet ds = new DataSet();
            if (displayNameFilter != "")
            {
                ObjBOL.Operation = operation;
            }
            else
            {
                ObjBOL.Operation = operation;
            }
            ObjBOL.formOperation = formOperation;
            ObjBOL.emailType = emailType.ToString();
            ObjBOL.group = group;
            ObjBOL.displayNameFilter = displayNameFilter;
            ObjBOL.formName = formName;
            ds = ObjBLL.Return_DataSet(ObjBOL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable emailTable = ds.Tables[0];
                foreach (DataRow row in emailTable.Rows)
                {
                    string emailAddress = row["emailAddress"].ToString();
                    string displayName = row["displayName"].ToString();
                    string emailtype = row["emailType"].ToString();
                    string listType = row["listType"].ToString();
                    int status = Convert.ToInt32(row["status"]);
                    if (status == 1)
                    {
                        if (emailAddress != "" && (string.IsNullOrEmpty(displayNameFilter) || displayName.Contains(displayNameFilter)))
                        {
                            MailAddress mailAddress = new MailAddress(emailAddress, displayName);
                            if (Enum.IsDefined(typeof(EmailType), emailType))
                            {
                                EmailType parsedEmailType = (EmailType)Enum.Parse(typeof(EmailType), emailtype);
                                if (emailDictionaryInventory.ContainsKey(parsedEmailType))
                                {
                                    // Now check for the specific list you want to add to
                                    if (emailDictionaryInventory[parsedEmailType].ContainsKey(listType))
                                    {
                                        emailDictionaryInventory[parsedEmailType][listType].Add(mailAddress);
                                    }
                                }
                            }
                        }

                    }
                }
            }
        }
        catch (Exception ex)
        {
            AddEditException(ex);
        }
    }

    public static void RemoveEmailFromCcList(HashSet<MailAddress> ccList, string displayName)
    {
        try
        {
            // Find the MailAddress with the specified display name
            MailAddress mailToRemove = null;

            foreach (var mailAddress in ccList)
            {
                if (mailAddress.DisplayName.Equals(displayName, StringComparison.OrdinalIgnoreCase))
                {
                    mailToRemove = mailAddress;
                    break; // Exit the loop once found
                }
            }

            // If found, remove it from the HashSet
            if (mailToRemove != null)
            {
                ccList.Remove(mailToRemove);
            }
        }
        catch (Exception ex)
        {

            AddEditException(ex);
        }
    }

    public const int AllowedFileSize = 300;//in KB

    public const int AllowedFileSize_Pdf = 1500;//in KB

    public static DataSet BindProposalData()
    {
        BOLManageProposals ObjBOL = new BOLManageProposals();
        BLLManageProposals ObjBLL = new BLLManageProposals();
        DataSet ds = new DataSet();
        ObjBOL.Operation = 5;
        ds = ObjBLL.GetProposals(ObjBOL);
        return ds;
    }

    public static int FileSizeLimits(string extension)
    {
        if (extension.Trim().ToLower() == "pdf" || extension.Trim().ToLower() == ".pdf")
        {
            return AllowedFileSize_Pdf;
        }
        return AllowedFileSize;
    }

    public static bool InventoryEmailSwitch()
    {
        bool returnValue = false;
        BOLAppSetting ObjBOL = new BOLAppSetting();
        BLLAppSetting ObjBLL = new BLLAppSetting();
        ObjBOL.Operation = 1;
        ObjBOL.ID = 1;
        string returnStatus = ObjBLL.Return_String(ObjBOL);
        if (Boolean.TryParse(returnStatus, out returnValue))
        {
            return returnValue;
        }
        else
        {
            return false;
        }
    }

    public static bool InventorySalesSwitch()
    {
        bool returnValue = false;
        BOLAppSetting ObjBOL = new BOLAppSetting();
        BLLAppSetting ObjBLL = new BLLAppSetting();
        ObjBOL.Operation = 2;
        ObjBOL.ID = 1;
        string returnStatus = ObjBLL.Return_String(ObjBOL);
        if (Boolean.TryParse(returnStatus, out returnValue))
        {
            return returnValue;
        }
        else
        {
            return false;
        }
    }

    public static String GetMinutes()
    {
        BOLUserOTP ObjBOL = new BOLUserOTP();
        BLLUserOTP ObjBLL = new BLLUserOTP();
        ObjBOL.Operation = 4;
        return ObjBLL.SaveDataShpDrg(ObjBOL);
    }

    public static void AddEditException(Exception e)
    {
        AddEditException(e, null);
    }

    public static void AddEditException(Exception e, string identifier)
    {
        if (e.Message != "Thread was being aborted.")
        {
            BOLException objBOLEx = new BOLException();
            BLLException objBLLEx = new BLLException();
            string msg = string.Empty;
            var trace = new StackTrace(e);
            var frame = trace.GetFrame(0);
            var method = frame.GetMethod();
            StackFrame[] frames = trace.GetFrames();
            DateTime date = DateTime.Now;
            if (e != null)
            {
                objBOLEx.Action = (Char)(Oper.Exception);
                objBOLEx.module_name = method.Name;
                //objBolEx.hresult = HResult;
                objBOLEx.source = Convert.ToString(e.Source);
                if (identifier != null)
                {
                    objBOLEx.message = "[" + identifier + "] " + Convert.ToString(e.Message);
                }
                else
                {
                    objBOLEx.message = Convert.ToString(e.Message);
                }
                objBOLEx.data = Convert.ToString(e.Data);
                objBOLEx.target_site = Convert.ToString(e.TargetSite);
                objBOLEx.stack_trace = Convert.ToString(e.StackTrace + ':' + frame.GetFileLineNumber() + ':' + frame.GetFileColumnNumber());
                objBOLEx.date = date;
                msg = objBLLEx.SaveException(objBOLEx);
            }
        }
    }

    public static DataSet GetDealerMemberDetailPopUp(Int32 DealerID)
    {
        DataSet ds = new DataSet();
        BOLManageDealers ObjBOL = new BOLManageDealers();
        BLLManageDealers ObjBLL = new BLLManageDealers();
        ObjBOL.Operation = 8;
        ObjBOL.DealerID = DealerID;
        ds = ObjBLL.GetDealers(ObjBOL);
        return ds;
    }
    //Aerowerks
    public static DataTable GetPatientDetails(decimal CrNo)
    {
        DataTable dt = new DataTable();
        BOLPatientMaster ObjBOL = new BOLPatientMaster();
        BLLPatientMaster ObjBLL = new BLLPatientMaster();
        ObjBOL.Patient_CrNo = CrNo;
        ObjBOL.op = 1;
        dt = ObjBLL.SearchPatientMaster(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetTopographyID(String TopoName)
    {
        DataTable dt = new DataTable();
        BOLTopography ObjBOL = new BOLTopography();
        BLLTopography ObjBLL = new BLLTopography();
        ObjBOL.TopographyName = TopoName;
        ObjBOL.op = 9;
        dt = ObjBLL.GetTopography(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetPNumber(Int32 op)
    {
        BOLManageProjects ObjBOL = new BOLManageProjects();
        BLLManageProjects ObjBLL = new BLLManageProjects();
        DataTable dt;
        ObjBOL.Operation = op;
        dt = ObjBLL.ReturnProjects(ObjBOL).Tables[0];
        return dt;
    }

    public static DataSet GetConsultantRepPopUp(Int32 Repid)
    {
        DataSet ds = new DataSet();
        BOLEmployeeListing ObjBOL = new BOLEmployeeListing();
        BLLRepsAndTroys ObjBLL = new BLLRepsAndTroys();
        ObjBOL.Operation = 5;
        ObjBOL.RepID = Repid;
        ds = ObjBLL.GetRepsDetail(ObjBOL);
        return ds;
    }

    public static DataSet GetConsultantMemberPopUp(Int32 ConsultantId)
    {
        DataSet ds = new DataSet();
        BOLManageProposals ObjBOL = new BOLManageProposals();
        BLLManageProposals ObjBLL = new BLLManageProposals();
        ObjBOL.Operation = 10;
        ObjBOL.ConsultantID = ConsultantId;
        ds = ObjBLL.GetProposals(ObjBOL);
        return ds;
    }

    public static DataSet GetOriginationRepPopUp(Int32 Repid)
    {
        DataSet ds = new DataSet();
        BOLEmployeeListing ObjBOL = new BOLEmployeeListing();
        BLLRepsAndTroys ObjBLL = new BLLRepsAndTroys();
        ObjBOL.Operation = 5;
        ObjBOL.RepID = Repid;
        ds = ObjBLL.GetRepsDetail(ObjBOL);
        return ds;
    }

    public static DataSet GetDestinationRepPopUp(Int32 Repid)
    {
        DataSet ds = new DataSet();
        BOLEmployeeListing ObjBOL = new BOLEmployeeListing();
        BLLRepsAndTroys ObjBLL = new BLLRepsAndTroys();
        ObjBOL.Operation = 5;
        ObjBOL.RepID = Repid;
        ds = ObjBLL.GetRepsDetail(ObjBOL);
        return ds;
    }

    public static DataSet GetConsultantPopUp(Int32 ConsultantID)
    {
        DataSet ds = new DataSet();
        BOLManageConsultant ObjBOL = new BOLManageConsultant();
        BLLManageConsultant ObjBLL = new BLLManageConsultant();
        ObjBOL.Operation = 7;
        ObjBOL.ConsultantID = ConsultantID;
        ds = ObjBLL.GetConsultant(ObjBOL);
        return ds;
    }

    public static DataSet GetConsultantMember(Int32 ConsultantID)
    {
        DataSet ds = new DataSet();
        BOLManageProposals ObjBOL = new BOLManageProposals();
        BLLManageProposals ObjBLL = new BLLManageProposals();
        ObjBOL.Operation = 10;
        ObjBOL.ConsultantID = ConsultantID;
        ds = ObjBLL.GetProposals(ObjBOL);
        return ds;
    }

    public static DataSet GetCustomerPopUp(Int32 CustomerID)
    {
        DataSet ds = new DataSet();
        BOLManageCustomers ObjBOL = new BOLManageCustomers();
        BLLManageCustomers ObjBLL = new BLLManageCustomers();
        ObjBOL.Operation = 7;
        ObjBOL.CustomerID = CustomerID;
        ds = ObjBLL.GetCustomers(ObjBOL);
        return ds;
    }

    public static DataSet CheckPNumber(String PNumber)
    {
        DataSet ds = new DataSet();
        BOLManageProjects ObjBOL = new BOLManageProjects();
        BLLManageProjects ObjBLL = new BLLManageProjects();
        ObjBOL.Operation = 16;
        ObjBOL.ProposalID = PNumber;
        ds = ObjBLL.GetProjects(ObjBOL);
        return ds;
    }

    public static DataSet AutoFillPNumber(String PNumber)
    {
        DataSet ds = new DataSet();
        BOLManageProjects ObjBOL = new BOLManageProjects();
        BLLManageProjects ObjBLL = new BLLManageProjects();
        ObjBOL.Operation = 17;
        ObjBOL.ProposalID = PNumber;
        ds = ObjBLL.GetProjects(ObjBOL);
        return ds;
    }

    public static DataSet AutoFillPNumberBind(String PNumber)
    {
        DataSet ds = new DataSet();
        BOLManageProjects ObjBOL = new BOLManageProjects();
        BLLManageProjects ObjBLL = new BLLManageProjects();
        ObjBOL.Operation = 18;
        ObjBOL.ProposalID = PNumber;
        ds = ObjBLL.GetProjects(ObjBOL);
        return ds;
    }

    public static DataTable GetDealers()
    {
        DataTable dt = new DataTable();
        BOLDealers ObjBOL = new BOLDealers();
        BLLDealers ObjBLL = new BLLDealers();
        ObjBOL.op = 1;
        dt = ObjBLL.GetDealers(ObjBOL).Tables[0];
        return dt;
    }

    public static DataSet GetDealerDetailPopUp(Int32 DealerID)
    {
        DataSet ds = new DataSet();
        BOLManageDealers ObjBOL = new BOLManageDealers();
        BLLManageDealers ObjBLL = new BLLManageDealers();
        ObjBOL.Operation = 7;
        ObjBOL.DealerID = DealerID;
        ds = ObjBLL.GetDealers(ObjBOL);
        return ds;
    }

    public static DataTable GetTopographyID_2011(String TopoName)
    {
        DataTable dt = new DataTable();
        BOLTopography ObjBOL = new BOLTopography();
        BLLTopography ObjBLL = new BLLTopography();
        ObjBOL.TopographyName = TopoName;
        ObjBOL.op = 8;
        dt = ObjBLL.GetTopography(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetProductsListHierarchy()
    {
        BOLProductMaster ObjBOL = new BOLProductMaster();
        BLLProductMaster ObjBLL = new BLLProductMaster();
        DataTable dt = new DataTable();
        ObjBOL.op = 8;
        DataSet ds = new DataSet();
        DataSet dsFinal = new DataSet();
        ds = ObjBLL.GetProducts(ObjBOL);
        dsFinal = ds;
        string ProductName = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (Int32 i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                ObjBOL.op = 6;
                ObjBOL.ProductID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductID"]);
                DataSet dsp = new DataSet();
                dsp = ObjBLL.GetProducts(ObjBOL);
                if (dsp.Tables[0].Rows.Count > 1)
                {
                    ProductName = "";
                    for (Int32 j = dsp.Tables[0].Rows.Count - 1; j >= 0; j--)
                    {
                        ProductName = ProductName + dsp.Tables[0].Rows[j]["ProductName"].ToString() + ">";
                    }
                    if (ProductName != "")
                    {
                        ProductName = ProductName.Substring(0, ProductName.Length - 1);
                    }
                    dsFinal.Tables[0].Rows[i]["ProductName"] = ProductName;
                }
            }
        }
        dt = dsFinal.Tables[0];
        return dt;
    }

    public static bool ISNumber(string id)
    {
        try
        {
            Convert.ToInt32(id);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static DataTable GetCountries()
    {
        DataTable dt = new DataTable();
        BOLStateDistCity ObjBOL = new BOLStateDistCity();
        BLLStateDistCity ObjBLL = new BLLStateDistCity();
        ObjBOL.op = 1;
        dt = ObjBLL.GetCountry(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetSpecificCountries()
    {
        DataTable dt = new DataTable();
        BOLStateDistCity ObjBOL = new BOLStateDistCity();
        BLLStateDistCity ObjBLL = new BLLStateDistCity();
        ObjBOL.op = 2;
        dt = ObjBLL.GetCountry(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetStates()
    {
        DataTable dt = new DataTable();
        BOLStateDistCity ObjBOL = new BOLStateDistCity();
        BLLStateDistCity ObjBLL = new BLLStateDistCity();
        ObjBOL.op = 4;
        dt = ObjBLL.GetState(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetDistricts(Int32 StateID)
    {
        DataTable dt = new DataTable();
        BOLStateDistCity ObjBOL = new BOLStateDistCity();
        BLLStateDistCity ObjBLL = new BLLStateDistCity();
        ObjBOL.StateID = StateID;
        ObjBOL.op = 6;
        dt = ObjBLL.GetDistrict(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetCities(Int32 StateID, Int32 DistrictID)
    {
        DataTable dt = new DataTable();
        BOLStateDistCity ObjBOL = new BOLStateDistCity();
        BLLStateDistCity ObjBLL = new BLLStateDistCity();
        ObjBOL.StateID = StateID;
        ObjBOL.DistrictID = DistrictID;
        ObjBOL.op = 6;
        dt = ObjBLL.GetCity(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetMaxPatientID()
    {
        DataTable dt = new DataTable();
        BOLPatientMaster ObjBOLS = new BOLPatientMaster();
        BLLPatientMaster ObjBLLS = new BLLPatientMaster();
        ObjBOLS.op = 9;
        dt = ObjBLLS.GetPatientMasterMaxID(ObjBOLS).Tables[0];
        return dt;
    }

    public static DataTable GetMaxSurgicalID()
    {
        DataTable dt = new DataTable();
        BOLSurgicalPathologyReport ObjBOLS = new BOLSurgicalPathologyReport();
        BLLSurgicalPathologyReport ObjBLLS = new BLLSurgicalPathologyReport();
        ObjBOLS.op = 2;
        dt = ObjBLLS.GetSurgicalPathologyReportMaxID(ObjBOLS).Tables[0];
        return dt;
    }

    public static DataTable GetMaxAutopsySurgicalID()
    {
        DataTable dt = new DataTable();
        BOLAutopsyReport ObjBOLS = new BOLAutopsyReport();
        BLLAutopsyReport ObjBLLS = new BLLAutopsyReport();
        ObjBOLS.op = 2;
        dt = ObjBLLS.GetAutopsyPathologyReportMaxID(ObjBOLS).Tables[0];
        return dt;
    }

    public static DataTable GetCountSurgicalID()
    {
        DataTable dt = new DataTable();
        BOLSurgicalPathologyReport ObjBOLS = new BOLSurgicalPathologyReport();
        BLLSurgicalPathologyReport ObjBLLS = new BLLSurgicalPathologyReport();
        ObjBOLS.op = 9;
        dt = ObjBLLS.GetSurgicalPathologyReportCount(ObjBOLS).Tables[0];
        return dt;
    }

    public static DataTable GetCountAutopsyID()
    {
        DataTable dt = new DataTable();
        BOLAutopsyReport ObjBOLS = new BOLAutopsyReport();
        BLLAutopsyReport ObjBLLS = new BLLAutopsyReport();
        ObjBOLS.op = 9;
        dt = ObjBLLS.GetAutopsyPathologyReportCount(ObjBOLS).Tables[0];
        return dt;
    }

    public static void ClearDropDownList(DropDownList ddl)
    {
        var firstitem = ddl.Items[0];
        ddl.Items.Clear();

        ddl.Items.Add(firstitem);
    }

    public static DataTable GetCutsomerCategories()
    {
        DataTable dt = new DataTable();
        BOLCustomerCategoryMaster ObjBOL = new BOLCustomerCategoryMaster();
        BLLCustomerCategoryMaster ObjBLL = new BLLCustomerCategoryMaster();
        ObjBOL.op = 4;
        dt = ObjBLL.GetCustomerCategory(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetDesignations()
    {
        DataTable dt = new DataTable();
        BOLDesignation ObjBOL = new BOLDesignation();
        BLLDesignation ObjBLL = new BLLDesignation();
        ObjBOL.op = 4;
        dt = ObjBLL.GetDesignation(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetEmployeeRoles()
    {
        DataTable dt = new DataTable();
        BOLRoles ObjBOL = new BOLRoles();
        BLLRoles ObjBLL = new BLLRoles();
        ObjBOL.op = 4;
        dt = ObjBLL.GetRoles(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetTrainingDetails()
    {
        DataTable dt = new DataTable();
        BOLTrainingDetailMaster ObjBOL = new BOLTrainingDetailMaster();
        BLLTrainingDetailMaster ObjBLL = new BLLTrainingDetailMaster();
        ObjBOL.op = 4;
        dt = ObjBLL.GetTrainingDetail(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetEmployees()
    {
        DataTable dt = new DataTable();
        BOLManageEmployees ObjBOL = new BOLManageEmployees();
        BLLManageEmployees ObjBLL = new BLLManageEmployees();
        ObjBOL.operation = 4;
        dt = ObjBLL.GetEmployees(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetUserLogins()
    {
        DataTable dt = new DataTable();
        BOLManageEmployees ObjBOL = new BOLManageEmployees();
        BLLManageEmployees ObjBLL = new BLLManageEmployees();
        ObjBOL.operation = 7;
        dt = ObjBLL.GetEmployees(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetSpecificEmployees(Int32 op, String Name, Int32 CustomerID, Int32 EmployeeID, Int32 LoginID)
    {
        DataTable dt = new DataTable();
        BOLManageEmployees ObjBOL = new BOLManageEmployees();
        BLLManageEmployees ObjBLL = new BLLManageEmployees();
        ObjBOL.operation = op;
        ObjBOL.FirstName = Name;
        ObjBOL.EmployeeID = EmployeeID;
        //ObjBOL.LoginID = LoginID;
        dt = ObjBLL.GetEmployees(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetSpecificTopography(Int32 op, String Name)
    {
        DataTable dt = new DataTable();
        BOLTopography ObjBOL = new BOLTopography();
        BLLTopography ObjBLL = new BLLTopography();
        ObjBOL.op = op;
        ObjBOL.TopographyName = Name;
        dt = ObjBLL.GetTopography(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetSpecificMorphology(Int32 op, String Name)
    {
        DataTable dt = new DataTable();
        BOLMorphology ObjBOL = new BOLMorphology();
        BLLMorphology ObjBLL = new BLLMorphology();
        ObjBOL.op = op;
        ObjBOL.MorphologyName = Name;
        dt = ObjBLL.GetMorphology(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetSpecificMorphology_2011(Int32 op, String Name)
    {
        DataTable dt = new DataTable();
        BOLMorphology ObjBOL = new BOLMorphology();
        BLLMorphology ObjBLL = new BLLMorphology();
        ObjBOL.op = op;
        ObjBOL.MorphologyName = Name;
        dt = ObjBLL.GetMorphology(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetSpecificFaculty(Int32 op, String Name)
    {
        DataTable dt = new DataTable();
        BOLFaculty ObjBOL = new BOLFaculty();
        BLLFaculty ObjBLL = new BLLFaculty();
        ObjBOL.op = op;
        ObjBOL.FacultyName = Name;
        dt = ObjBLL.GetFaculty(ObjBOL).Tables[0];
        return dt;
    }

    public static String GetNextEmployeeCode()
    {
        BLLEmpCode ObjBLL = new BLLEmpCode();
        return ObjBLL.GetNextEmployeeCode();
    }

    public static String GetWeekSum()
    {
        BLLEmpCode ObjBLL = new BLLEmpCode();
        return ObjBLL.GetNextEmployeeCode();
    }

    public static DateTime ConvertDateFormat(string date)
    {

        string[] arr;
        string dd = "";
        string mm = "";
        string yy = "";

        if (date != "")
        {
            arr = date.Split(' ');
            arr = arr[0].Split('/');
            dd = arr[1];
            mm = arr[0];
            yy = arr[2];
            if (mm.Length < 2)
            {
                mm = "0" + mm;
            }
            if (dd.Length < 2)
            {
                dd = "0" + dd;
            }
        }
        else
        {
            mm = "01";
            dd = "01";
            yy = "1900";
        }

        return Convert.ToDateTime(mm + "/" + dd + "/" + yy);
    }

    public static DateTime? ConvertDate(string date)
    {

        string[] arr;
        string dd = "";
        string mm = "";
        string yy = "";

        bool b3 = string.IsNullOrEmpty(date);
        if (!b3)
        {
            arr = date.Split(' ');
            arr = arr[0].Split('/');
            dd = arr[1];
            mm = arr[0];
            yy = arr[2];
            if (mm.Length < 2)
            {
                mm = "0" + mm;
            }
            if (dd.Length < 2)
            {
                dd = "0" + dd;
            }
        }
        else
        {
            return null;
        }

        DateTime result;
        bool success = DateTime.TryParse(mm + "/" + dd + "/" + yy, out result);
        if (success)
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public static Decimal ToDecimal(string amount)
    {
        Decimal FAmont = 0;
        if (string.IsNullOrEmpty(amount) == false)
            return FAmont = Convert.ToDecimal(amount);
        else
            return FAmont = 0;
    }

    public static Double ToDouble(string amount)
    {
        Double FAmont = 0;
        if (string.IsNullOrEmpty(amount) == false)
            return FAmont = Convert.ToDouble(amount);
        else
            return FAmont = 0;
    }

    public static string UniqueConstraintErrorCode()
    {
        return "2627";
    }

    public static void ShowMessage(Page obj, string Message)
    {
        ScriptManager.RegisterClientScriptBlock(obj, obj.GetType(), "Warning", "alert('" + Message.Replace("'", "") + "')", true);
    }

    public static void ShowMessage_Success(Page obj, string Message)
    {
        ScriptManager.RegisterClientScriptBlock(obj, obj.GetType(), "Success", "toastr.success('" + Message + "','',{'timeOut': 5000, 'hideDuration': 100, 'closeButton': true});", true);
    }

    public static void ShowMessage_Info(Page obj, string Message)
    {
        ScriptManager.RegisterClientScriptBlock(obj, obj.GetType(), "Info", "toastr.info('" + Message + "','',{'timeOut': 5000, 'hideDuration': 100, 'closeButton': true});", true);
    }

    public static void ShowMessage_Warning(Page obj, string Message)
    {
        ScriptManager.RegisterClientScriptBlock(obj, obj.GetType(), "Warning", "toastr.warning('" + Message + "','',{'timeOut': 5000, 'hideDuration': 100, 'closeButton': true});", true);
    }

    public static void ShowMessage_Error(Page obj, string Message)
    {
        ScriptManager.RegisterClientScriptBlock(obj, obj.GetType(), "Error", "toastr.error('" + Message + "','',{'timeOut': 5000, 'hideDuration': 100, 'closeButton': true}); ", true);
    }

    public static void ShowMessage_Error_NoTimeout(Page obj, string Message)
    {
        ScriptManager.RegisterClientScriptBlock(obj, obj.GetType(), "Error", "toastr.error('" + Message + "','',{'timeOut': 0, 'hideDuration': 100, 'closeButton': true, 'extendedTimeOut': 0}); ", true);
    }

    public static void ShowMessage_Error_Forced(Page obj, string Message)
    {
        string script = "toastr.error('" + Message + "','',{'timeOut': 0, 'hideDuration': 100, 'closeButton': false, 'tapToDismiss': false, 'extendedTimeOut': 0}); var toastrElement = $('.toast'); toastrElement.css('width', toastrElement.width() + 1500 + 'px'); ";
        ScriptManager.RegisterClientScriptBlock(obj, obj.GetType(), "Error", script, true);
    }

    public static void ShowMessage_Error_SingleNotification(Page obj, string Message)
    {
        string script = "if ($('.toast').length > 0) {  $('.toast#ErrorId').remove();  } toastr.error('" + Message + "','',{'timeOut': 5000, 'hideDuration': 100, 'closeButton': true}); var toastrElement = $('.toast'); toastrElement.css('width', toastrElement.width() + 1500 + 'px'); toastrElement.attr('id', 'ErrorId'); ";
        ScriptManager.RegisterClientScriptBlock(obj, obj.GetType(), "Error", script, true);
    }

    public static void ToastrClear(Page obj)
    {
        ScriptManager.RegisterClientScriptBlock(obj, obj.GetType(), "Error", " $('.toast#ErrorId').remove(); ", true);
    }

    public static DataTable ReturnProposals(Int32 op, String Pnumber)
    {
        BOLManageProposals ObjBOL = new BOLManageProposals();
        BLLManageProposals ObjBLL = new BLLManageProposals();
        DataTable dt;
        ObjBOL.PNumber = Pnumber;
        ObjBOL.Operation = op;
        dt = ObjBLL.ReturnProposals(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable ReturnProjects(Int32 op, String ProjectName)
    {
        BOLManageProjects ObjBOL = new BOLManageProjects();
        BLLManageProjects ObjBLL = new BLLManageProjects();
        DataTable dt;
        ObjBOL.ProjectName = ProjectName;
        ObjBOL.Operation = op;
        dt = ObjBLL.ReturnProjects(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable ReturnPNumber(Int32 op, String ProposalID)
    {
        BOLManageProjects ObjBOL = new BOLManageProjects();
        BLLManageProjects ObjBLL = new BLLManageProjects();
        DataTable dt;
        ObjBOL.ProposalID = ProposalID;
        ObjBOL.Operation = op;
        dt = ObjBLL.ReturnProjects(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable ReturnCustomers(Int32 op, Int32 CustomerID, String CustomerName)
    {
        BOLManageCustomers ObjBOL = new BOLManageCustomers();
        BLLManageCustomers ObjBLL = new BLLManageCustomers();
        DataTable dt;
        ObjBOL.CustomerID = CustomerID;
        ObjBOL.CompanyName = CustomerName;
        ObjBOL.Operation = op;
        dt = ObjBLL.ReturnCustomers(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable ReturnpatientDetail_2011(Int32 op, Int32 PatientID, Int32 Sur_Path_ID)
    {
        BOLSurgicalPathologyReport ObjBOL = new BOLSurgicalPathologyReport();
        BLLSurgicalPathologyReport ObjBLL = new BLLSurgicalPathologyReport();
        DataTable dt;
        ObjBOL.PatientID = PatientID;
        ObjBOL.Sur_Path_ID = Sur_Path_ID;
        ObjBOL.op = op;
        dt = ObjBLL.GetPatientDetail_2011(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable ReturnpatientDetail(Int32 op, Int32 PatientID, Int32 Sur_Path_ID)
    {
        BOLSurgicalPathologyReport ObjBOL = new BOLSurgicalPathologyReport();
        BLLSurgicalPathologyReport ObjBLL = new BLLSurgicalPathologyReport();
        DataTable dt;
        ObjBOL.PatientID = PatientID;
        ObjBOL.Sur_Path_ID = Sur_Path_ID;
        ObjBOL.op = op;
        dt = ObjBLL.GetPatientDetail(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable ReturnSurgicalPathologyReport(Int32 op, Int32 PatientID)
    {
        BOLSurgicalPathologyReport ObjBOL = new BOLSurgicalPathologyReport();
        BLLSurgicalPathologyReport ObjBLL = new BLLSurgicalPathologyReport();
        DataTable dt;
        ObjBOL.PatientID = PatientID;
        ObjBOL.op = op;
        dt = ObjBLL.GetAllSurgicalPathologyReport(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable ReturnSurgicalPathologyReport_2011(Int32 op, Int32 PatientID)
    {
        BOLSurgicalPathologyReport ObjBOL = new BOLSurgicalPathologyReport();
        BLLSurgicalPathologyReport ObjBLL = new BLLSurgicalPathologyReport();
        DataTable dt;
        ObjBOL.PatientID = PatientID;
        ObjBOL.op = op;
        dt = ObjBLL.GetAllSurgicalPathologyReport_2011(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable ReturnAutopsyPathologyReport(Int32 op, Int32 Sur_ID)
    {
        BOLAutopsyReport ObjBOL = new BOLAutopsyReport();
        BLLAutopsyReport ObjBLL = new BLLAutopsyReport();
        DataTable dt;
        ObjBOL.Autopsy_Path_ID = Sur_ID;
        ObjBOL.op = op;
        dt = ObjBLL.GetAllAutopsyPathologyReport(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable ReturnCPCAutopsy(Int32 op, Int32 Sur_ID)
    {
        BOLCPCAutopsy ObjBOL = new BOLCPCAutopsy();
        BLLCPCAutopsy ObjBLL = new BLLCPCAutopsy();
        DataTable dt;
        ObjBOL.Autopsy_Path_ID = Sur_ID;
        ObjBOL.CPCDoneDate = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")); ;
        ObjBOL.op = op;
        dt = ObjBLL.GetCPCAutopsy(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable SearchPathologyReport(Int32 op, String Qry)
    {
        BOLSurgicalPathologyReport ObjBOL = new BOLSurgicalPathologyReport();
        BLLSurgicalPathologyReport ObjBLL = new BLLSurgicalPathologyReport();
        DataTable dt;
        ObjBOL.Sur_Path_BiopsyNo = Qry;
        ObjBOL.op = op;
        dt = ObjBLL.SearchPathologyReport(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable SearchAutopsyPathologyReport(Int32 op, String Qry)
    {
        BOLAutopsyReport ObjBOL = new BOLAutopsyReport();
        BLLAutopsyReport ObjBLL = new BLLAutopsyReport();
        DataTable dt;
        ObjBOL.Autopsy_Path_PMNo = Qry;
        ObjBOL.op = op;
        dt = ObjBLL.SearchAutopsyPathologyReport(ObjBOL).Tables[0];
        return dt;
    }

    public static void BindDropDownList(DropDownList ddl, DataTable dt)
    {
        ddl.DataSource = dt;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("Select", "0"));
    }

    public static void BindListBoxList(ListBox ddl, DataTable dt)
    {
        ddl.DataSource = dt;
        ddl.DataBind();
        //ddl.Items.Insert(0, new ListItem("Select", "0"));
    }

    public static void BindDropDownListAll(DropDownList ddl, DataTable dt)
    {
        ddl.DataSource = dt;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("All", "0"));
    }

    public static void BindCheckBoxList(CheckBoxList ddl, DataTable dt)
    {
        ddl.DataSource = dt;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("All", "-1"));
    }

    public static void BindCheckBoxListWOAll(CheckBoxList chk, DataTable dt)
    {
        chk.DataSource = dt;
        chk.DataBind();

    }

    public static void BindGrid(GridView gv, DataTable dt)
    {
        gv.DataSource = dt;
        gv.DataBind();
    }

    public static void ShowValidationMark(Object Obj)
    {
        if (Obj is TextBox)
        {
            TextBox txt = (TextBox)Obj;
            txt.Attributes.Add("Style", "background-color:#FFCECE;");
        }
        else if (Obj is DropDownList)
        {
            DropDownList drp = (DropDownList)Obj;
            drp.Attributes.Add("Style", "background-color:#FFCECE;");
        }
        else if (Obj is HtmlTextArea)
        {
            HtmlTextArea txtarea = (HtmlTextArea)Obj;
            txtarea.Attributes.Add("Style", "background-color:#FFCECE;");
        }
    }

    public static void RemoveValidationMark(Object Obj)
    {
        if (Obj is TextBox)
        {
            TextBox txt = (TextBox)Obj;
            txt.Attributes.Add("Style", "background-color:#FFF;");
        }
        else if (Obj is DropDownList)
        {
            DropDownList drp = (DropDownList)Obj;
            drp.Attributes.Add("Style", "background-color:#FFF;");
        }
        else if (Obj is HtmlTextArea)
        {
            HtmlTextArea txtarea = (HtmlTextArea)Obj;
            txtarea.Attributes.Add("Style", "background-color:#FFF;");
        }
    }

    public static BOLLoginInfo GetLoginInfo(string UserName, string Password)
    {
        BOLLoginInfo ObjBOLLogin = new BOLLoginInfo();
        BOLManageEmployees ObjBOL = new BOLManageEmployees();
        BLLManageEmployees ObjBLL = new BLLManageEmployees();
        ObjBOL.operation = 1;
        ObjBOL.Username = UserName;
        ObjBOL.Passwd = Password;
        DataTable dt = ObjBLL.GetEmployees(ObjBOL).Tables[0];
        if (dt.Rows.Count > 0)
        {
            ObjBOLLogin.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
            ObjBOLLogin.EmployeeName = Convert.ToString(dt.Rows[0]["EmployeeName"]);
            ObjBOLLogin.CountryID = Convert.ToInt32(dt.Rows[0]["CountryId"]);
            ObjBOLLogin.RoleName = Convert.ToString(dt.Rows[0]["Department"]);
            ObjBOLLogin.Email = Convert.ToString(dt.Rows[0]["Email"]);
        }
        else
        {
            ObjBOLLogin.EmployeeID = 0;
            ObjBOLLogin.EmployeeName = "";
        }
        return ObjBOLLogin;
    }

    public static bool CheckSession()
    {
        if (HttpContext.Current.Session["login"] == null)
        {
            return false;
        }
        return true;
    }

    public static BOLLoginInfo GetCurrentSession()
    {
        BOLLoginInfo ObjBOLLogin = new BOLLoginInfo();
        ObjBOLLogin = (BOLLoginInfo)HttpContext.Current.Session["login"];
        return ObjBOLLogin;
    }

    public static Int32 GetCurrentUser()
    {
        return GetCurrentSession().EmployeeID;
    }

    public static Int32 GetCurrentUserCountryId()
    {
        return GetCurrentSession().CountryID;
    }

    public static String GetCurrentUserRole()
    {
        return GetCurrentSession().RoleName;
    }

    //public static String GetCurrentUserName()
    //{
    //    return GetCurrentSession().EmployeeName;
    //}

    //public static String GetCurrentCustomerName()
    //{
    //    return GetCurrentSession().CustomerName;
    //}

    public static bool IsAuthorized()
    {
        bool Flag = true;
        if (GetCurrentSession() == null)
            Flag = false;
        return Flag;
    }

    public static String GetRootPath()
    {
        String RootPath = System.Configuration.ConfigurationManager.AppSettings["Path"];
        return RootPath;
    }

    public static void SendToLoginPage()
    {
        try
        {
            string fullPath = GetRootPath() + "/index.aspx";
            HttpContext.Current.Response.Redirect(fullPath, false);
            //HttpContext.Current.Response.ClearHeaders();
            //HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            //HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
    }

    public static void SendUserToCorrespondingPage()
    {
        try
        {
            HttpContext.Current.Response.Redirect(GetRootPath() + GetCurrentSession().RoleName + "/index.aspx");
        }
        catch (Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
    }

    public static String ManageBrowseDetails(Int32 op)
    {
        BOLBrowseDetail ObjBOL = new BOLBrowseDetail();
        BLLBrowseDetail ObjBLL = new BLLBrowseDetail();
        ObjBOL.BrowseID = 0;
        ObjBOL.EmployeeID = GetCurrentSession().EmployeeID;
        ObjBOL.CustomerID = GetCurrentSession().CustomerID;
        ObjBOL.CurrentSessionID = GetCurrentBrowseID(); //HttpContext.Current.Session.SessionID;
        if (HttpContext.Current.Request.UserAgent.Contains("Chrome"))
        {
            ObjBOL.BrowserType = "Chrome " + Convert.ToString(HttpContext.Current.Request.Browser.Version);
        }
        else
        {
            ObjBOL.BrowserType = HttpContext.Current.Request.Browser.Browser;
        }
        ObjBOL.op = op;
        String Message = ObjBLL.SaveBrowseDetail(ObjBOL);
        return Message;
    }

    public static String Login(string UserName, String Password, string ProductLine)
    {
        String Message = "";
        BOLLoginInfo ObjBOL = Utility.GetLoginInfo(UserName.Replace("'", ""), Password.Replace("'", ""));
        if (ObjBOL.EmployeeID == 0)
        {
            Message = "Invalid User or Account is not Acive !!";
        }
        else
        {
            if (ObjBOL.LoginActiveStatus == "N")
            {
                Message = "Your Account Status Is InActive.";
            }
            else
            {
                if (ObjBOL.CustomerActiveStatus == "N")
                {
                    Message = "Your Account Status Is InActive. Please Cunsult Administration.";
                }
                else
                {
                    HttpContext.Current.Session["login"] = ObjBOL;
                    //String BrowseID=ManageBrowseDetails(1); // Save Login Info
                    //HttpContext.Current.Session["BrowseID"] = BrowseID;
                    //SendUserToCorrespondingPage();
                    //0 FOR AEROWERKS
                    if (ProductLine == "0")
                    {
                        HttpContext.Current.Response.Redirect("~/Default.aspx");
                    }
                    else if (ProductLine == "1")
                    {
                        HttpContext.Current.Response.Redirect("~/DefaultGL.aspx");
                    }
                    else if (ProductLine == "2")
                    {
                        HttpContext.Current.Response.Redirect("~/DefaultSomat.aspx");
                    }
                }
            }
        }
        return Message;
    }

    public static void MaintainLogs(string strFormName, string strOperation)
    {
        BOLManageLogs ObjBOLS = new BOLManageLogs();
        BLLManageLogs ObjBLLS = new BLLManageLogs();
        ObjBOLS.Operation = 1;
        ObjBOLS.userid = GetCurrentSession().EmployeeID;
        ObjBOLS.formname = strFormName;
        ObjBOLS.logoperation = strOperation;
        String Message = ObjBLLS.SaveLogs(ObjBOLS);
    }

    public static void MaintainLogsSpecial(string strFormName, string strOperation, string PK)
    {
        BOLManageLogs ObjBOLS = new BOLManageLogs();
        BLLManageLogs ObjBLLS = new BLLManageLogs();
        ObjBOLS.Operation = 1;
        ObjBOLS.userid = GetCurrentSession().EmployeeID;
        ObjBOLS.formname = strFormName;
        ObjBOLS.logoperation = strOperation;
        ObjBOLS.pk = PK;
        String Message = ObjBLLS.SaveLogs(ObjBOLS);
    }

    public static String GetCurrentBrowseID()
    {
        return Convert.ToString(HttpContext.Current.Session["BrowseID"]);
    }

    public static void LogOut()
    {
        //ManageBrowseDetails(2); // Update Login Info
        EndCurrentSession();
        SendToLoginPage();
    }

    public static void EndCurrentSession()
    {
        HttpContext.Current.Session["login"] = null;
        HttpContext.Current.Session["Menu"] = null;
        HttpContext.Current.Session["BrowseID"] = null;
        HttpContext.Current.Session.Abandon();
        HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
    }

    public static String CheckIfAdmin()
    {
        return "Admin";
    }

    public static String CheckIfBusinessDeveloper()
    {
        return "BusinessDeveloper";
    }

    public static String CheckIfTeacher()
    {
        return "Teacher";
    }

    public static String CheckIfExecutiveAccountant()
    {
        return "ExecutiveAccountant";
    }

    public static String CheckIfPrincipal()
    {
        return "Principal";
    }

    public static DataTable GetCurrentLoggedUsers(Int32 CustomerID)
    {
        BOLBrowseDetail ObjBOL = new BOLBrowseDetail();
        BLLBrowseDetail ObjBLL = new BLLBrowseDetail();
        ObjBOL.CustomerID = CustomerID;
        ObjBOL.op = 5;
        DataTable dt = ObjBLL.GetBrowseDetail(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetNotepad(Int32 UserID)
    {
        BOLNotepad ObjBOL = new BOLNotepad();
        BLLNotepad ObjBLL = new BLLNotepad();
        ObjBOL.UserID = UserID;
        ObjBOL.op = 6;
        DataTable dt = ObjBLL.GetWorkName(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetTopography()
    {
        DataTable dt = new DataTable();
        BOLTopography ObjBOL = new BOLTopography();
        BLLTopography ObjBLL = new BLLTopography();
        ObjBOL.op = 5;
        dt = ObjBLL.GetTopography(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetCategory()
    {
        DataTable dt = new DataTable();
        BOLCategory ObjBOL = new BOLCategory();
        BLLCategory ObjBLL = new BLLCategory();
        ObjBOL.op = 5;
        dt = ObjBLL.GetCategory(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetCategoryType()
    {
        DataTable dt = new DataTable();
        BOLCategoryType ObjBOL = new BOLCategoryType();
        BLLCategoryType ObjBLL = new BLLCategoryType();
        ObjBOL.op = 5;
        dt = ObjBLL.GetCategoryType(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetMorphology(int TopographyID)
    {
        DataTable dt = new DataTable();
        BOLMorphology ObjBOL = new BOLMorphology();
        BLLMorphology ObjBLL = new BLLMorphology();
        ObjBOL.op = 6;
        ObjBOL.TopographyID = TopographyID;
        dt = ObjBLL.GetMorphology(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetOrgans()
    {
        DataTable dt = new DataTable();
        BOLOrgan ObjBOL = new BOLOrgan();
        BLLOrgan ObjBLL = new BLLOrgan();
        ObjBOL.op = 5;
        dt = ObjBLL.GetOrgan(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable GetBrowsingDetails(Int32 CustomerID, Int32 EmployeeID)
    {
        BOLBrowseDetail ObjBOL = new BOLBrowseDetail();
        BLLBrowseDetail ObjBLL = new BLLBrowseDetail();
        ObjBOL.CustomerID = CustomerID;
        ObjBOL.EmployeeID = EmployeeID;
        ObjBOL.op = 4;
        DataTable dt = ObjBLL.GetBrowseDetail(ObjBOL).Tables[0];
        return dt;
    }

    public static string UploadImage(FileUpload Upload, string ImageName)
    {
        String path = GetRootPath() + "images\\";
        string Message = "";
        Boolean FileOK = false;
        Boolean FileSaved = false;
        if (Upload.HasFile)
        {
            HttpContext.Current.Session["WorkingImage"] = ImageName;
            String FileExtension = Path.GetExtension(HttpContext.Current.Session["WorkingImage"].ToString()).ToLower();
            String[] allowedExtensions = { ".png", ".jpeg", ".jpg", ".gif" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (FileExtension == allowedExtensions[i])
                {
                    FileOK = true;
                }
            }
        }
        if (FileOK)
        {
            try
            {
                Upload.PostedFile.SaveAs(path + HttpContext.Current.Session["WorkingImage"]);
                FileSaved = true;
            }
            catch (Exception ex)
            {
                Message = "File could not be uploaded." + ex.Message.ToString();
                FileSaved = false;
            }
        }

        else
        {
            Message = "Cannot accept files of this type.";
        }
        if (FileSaved)
        {
            Message = "";
        }
        return Message;
    }

    public static void CropThisImage(string W, string H, string X, string Y)
    {
        String path = GetRootPath() + "images\\";
        string ImageName = HttpContext.Current.Session["WorkingImage"].ToString();
        int w = Convert.ToInt32(W);
        int h = Convert.ToInt32(H);
        int x = Convert.ToInt32(X);
        int y = Convert.ToInt32(Y);
        byte[] CropImage = Crop(path + ImageName, w, h, x, y);
        using (MemoryStream ms = new MemoryStream(CropImage, 0, CropImage.Length))
        {
            ms.Write(CropImage, 0, CropImage.Length);
            using (SD.Image CroppedImage = SD.Image.FromStream(ms, true))
            {
                string SaveTo = path + ImageName;
                CroppedImage.Save(SaveTo, CroppedImage.RawFormat);
            }
        }
    }

    static byte[] Crop(string Img, int Width, int Height, int X, int Y)
    {
        try
        {
            using (SD.Image OriginalImage = SD.Image.FromFile(Img))
            {
                using (SD.Bitmap bmp = new SD.Bitmap(Width, Height))
                {
                    bmp.SetResolution(OriginalImage.HorizontalResolution, OriginalImage.VerticalResolution);
                    using (SD.Graphics Graphic = SD.Graphics.FromImage(bmp))
                    {
                        Graphic.SmoothingMode = SmoothingMode.AntiAlias;
                        Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Graphic.DrawImage(OriginalImage, new SD.Rectangle(0, 0, Width, Height), X, Y, Width, Height, SD.GraphicsUnit.Pixel);
                        MemoryStream ms = new MemoryStream();
                        bmp.Save(ms, OriginalImage.RawFormat);
                        return ms.GetBuffer();
                    }
                }
            }
        }
        catch (Exception Ex)
        {
            throw (Ex);
        }
    }

    public static void ExportToExcelGrid(GridView gridView, string sheetName)
    {
        // Store original settings
        bool originalAllowSorting = gridView.AllowSorting;
        bool originalAllowPaging = gridView.AllowPaging;

        try
        {
            // Disable sorting and paging
            gridView.AllowSorting = false;
            gridView.AllowPaging = false;

            // Rebind the GridView to reflect the current data
            // Assuming you have a method to bind data to the GridView
            // BindGridViewData(gridView); // Uncomment and implement this method as needed

            using (ExcelPackage excel = new ExcelPackage())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var workSheet = excel.Workbook.Worksheets.Add(sheetName);
                string headerText = string.Empty;
                // Add headers from the GridView
                int excelColumnIndex = 1; // Start from the first column in Excel
                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    if (!gridView.Columns[i].Visible) // Check if the column is visible
                    {
                        continue; // Skip this column if it's not visible
                    }


                    if (gridView.Columns[i] is TemplateField)
                    {
                        TemplateField templateField = (TemplateField)gridView.Columns[i];
                        Control headerControl = new Control();
                        if (templateField.HeaderTemplate != null)
                        {
                            // Create a new instance of the header template
                            headerControl = new Control();
                            templateField.HeaderTemplate.InstantiateIn(headerControl);
                            Label headerLabel = headerControl.FindControl("HeaderLabel") as Label;
                            if (headerLabel != null)
                            {
                                headerText = headerLabel.Text;
                            }
                        }
                        else
                        {
                            // Fallback to HeaderText property if HeaderTemplate is not defined
                            headerText = templateField.HeaderText;
                        }
                    }
                    else if (gridView.Columns[i] is BoundField)
                    {
                        BoundField boundField = (BoundField)gridView.Columns[i];
                        headerText = boundField.HeaderText;
                    }
                    else
                    {
                        // For non-template fields, get the header text directly
                        headerText = gridView.HeaderRow.Cells[i].Text;
                    }

                    // Clean up the header text
                    headerText = headerText.Replace("&nbsp;", "").Replace("&amp;", "&");
                    workSheet.Cells[1, excelColumnIndex].Value = headerText;
                    workSheet.Cells["A1:" + GetColumnLetter(excelColumnIndex) + "1"].Style.Font.Bold = true;
                    workSheet.Cells["A1:" + GetColumnLetter(excelColumnIndex) + "1"].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    workSheet.Column(excelColumnIndex).Width = 20;

                    excelColumnIndex++; // Increment the Excel column index
                }
                if (gridView.Columns.Count == 0)
                {
                    for (int i = 0; i < gridView.HeaderRow.Cells.Count; i++)
                    {
                        headerText = GetTextFromHtml(gridView.HeaderRow.Cells[i].Text);
                        if(headerText == "")
                        {
                            headerText = gridView.HeaderRow.Cells[i].Text;
                        }
                        workSheet.Cells[1, excelColumnIndex].Value = headerText.Replace("&nbsp;", "").Replace("&amp;", "&").Replace("&quot;", " ");
                        workSheet.Cells["A1:" + GetColumnLetter(excelColumnIndex) + "1"].Style.Font.Bold = true;
                        workSheet.Cells["A1:" + GetColumnLetter(excelColumnIndex) + "1"].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                        workSheet.Column(excelColumnIndex).Width = 20;
                        excelColumnIndex++;
                    }
                }

                int row = 2; // Start from the second row
                foreach (GridViewRow gridViewRow in gridView.Rows)
                {
                    excelColumnIndex = 1; // Reset for each row
                    for (int i = 0; i < gridViewRow.Cells.Count; i++)
                    {
                        if (gridView.Columns.Count > 0)
                        {
                            // Check if the column is visible
                            if (!gridView.Columns[i].Visible)
                            {
                                continue; // Skip this column if it's not visible
                            }
                        }

                        string cellText = string.Empty;

                        // Check if the cell contains controls
                        if (gridViewRow.Cells[i].Controls.Count > 0)
                        {
                            foreach (Control control in gridViewRow.Cells[i].Controls)
                            {
                                Label label = control as Label; // Use 'as' for safe casting
                                if (label != null)
                                {
                                    cellText = label.Text;
                                    break; // Exit the loop once we find the label
                                }

                                TextBox textBox = control as TextBox; // Use 'as' for safe casting
                                if (textBox != null)
                                {
                                    cellText = textBox.Text;
                                    break; // Exit the loop once we find the textbox
                                }
                                var itemStyle = ((TemplateField)gridView.Columns[i]).ItemStyle;
                                if (itemStyle.HorizontalAlign == HorizontalAlign.Right)
                                {
                                    workSheet.Cells[row, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                }
                                else if (itemStyle.HorizontalAlign == HorizontalAlign.Center)
                                {
                                    workSheet.Cells[row, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                }
                                else
                                {
                                    workSheet.Cells[row, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                }
                                if (itemStyle.BackColor != System.Drawing.Color.Empty)
                                {
                                    workSheet.Cells[row, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    workSheet.Cells[row, i + 1].Style.Fill.BackgroundColor.SetColor(itemStyle.BackColor);
                                }

                            }
                        }

                        // If no control was found, fallback to the cell text
                        if (string.IsNullOrEmpty(cellText))
                        {
                            cellText = gridViewRow.Cells[i].Text;
                        }

                        // Check if the value starts with '$'
                        if (cellText.StartsWith("$"))
                        {
                            // Remove the dollar sign and commas
                            cellText = cellText.Substring(1).Replace(",", "");
                            decimal numericValue;
                            // Try to parse the cell text as a decimal
                            if (decimal.TryParse(cellText, NumberStyles.Any, CultureInfo.InvariantCulture, out numericValue))
                            {
                                workSheet.Cells[row, excelColumnIndex].Value = numericValue; // Set the numeric value
                                workSheet.Cells[row, excelColumnIndex].Style.Numberformat.Format = "$#,##0.00"; // Apply currency format
                                workSheet.Cells[row, excelColumnIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            }
                            else
                            {
                                // If parsing fails, set as string
                                workSheet.Cells[row, excelColumnIndex].Value = cellText.Replace("&nbsp;", "").Replace("&amp;", "&").Replace("&quot;", " ");
                                workSheet.Cells[row, excelColumnIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            }
                        }
                        else
                        {
                            decimal numericValue;
                            if (decimal.TryParse(cellText, NumberStyles.Any, CultureInfo.InvariantCulture, out numericValue))
                            {
                                if (cellText.StartsWith("`"))
                                {
                                    workSheet.Cells[row, excelColumnIndex].Style.Numberformat.Format = "@";
                                    workSheet.Cells[row, excelColumnIndex].Value = numericValue.ToString().Replace("`", ""); // Set the numeric value
                                }
                                else
                                {
                                    workSheet.Cells[row, excelColumnIndex].Value = numericValue;
                                }
                                workSheet.Cells[row, excelColumnIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            }
                            else
                            {
                                // If it doesn't start with '$', just set the value as is 
                                if (cellText.StartsWith("`"))
                                {
                                    workSheet.Cells[row, excelColumnIndex].Style.Numberformat.Format = "@";
                                    workSheet.Cells[row, excelColumnIndex].Value = cellText.Replace("&nbsp;", "").Replace("&amp;", "&").Replace("&quot;", " ").Replace("`", "");
                                }
                                else
                                {
                                    workSheet.Cells[row, excelColumnIndex].Value = cellText.Replace("&nbsp;", "").Replace("&amp;", "&").Replace("&quot;", " ");
                                }    
                                workSheet.Cells[row, excelColumnIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            }

                        }

                        // Apply ItemStyle properties if applicable
                        if (gridView.Columns.Count > 0)
                        {
                            if (gridView.Columns[i] is BoundField)
                            {
                                BoundField boundField = (BoundField)gridView.Columns[i];
                                var itemStyle = boundField.ItemStyle;
                                ApplyItemStyle(workSheet.Cells[row, excelColumnIndex], itemStyle);
                            }
                        }


                        excelColumnIndex++; // Increment the Excel column index only for visible columns
                    }
                    row++; // Move to the next row in Excel
                }

                // Set the content type and filename
                var stream = new MemoryStream();
                excel.SaveAs(stream);
                var content = stream.ToArray();
                var fileName = sheetName + ".xlsx";

                // Send the file to the client
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
                HttpContext.Current.Response.BinaryWrite(content);
                HttpContext.Current.Response.End();
            }
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "Thread was being aborted.")
            {
                Utility.AddEditException(ex);
            }
        }
        finally
        {
            // Restore original settings
            gridView.AllowSorting = originalAllowSorting;
            gridView.AllowPaging = originalAllowPaging;

            // Rebind the GridView if necessary
            // BindGridViewData(gridView); // Uncomment and implement this method as needed
        }
    }

    private static string GetColumnLetter(int columnIndex)
    {
        int dividend = columnIndex;
        string columnLetter = String.Empty;
        int modulo;

        while (dividend > 0)
        {
            modulo = (dividend - 1) % 26;
            columnLetter = Convert.ToChar(65 + modulo).ToString() + columnLetter;
            dividend = (int)((dividend - modulo) / 26);
        }
        return columnLetter;
    }

    private static string GetTextFromHtml(string html)
    {
        // Find the start and end of the text
        int startIndex = html.IndexOf('>') + 1; // Find the first '>' and move to the next character
        int endIndex = html.LastIndexOf('<'); // Find the last '<'

        // Extract the text between the tags
        if (startIndex >= 0 && endIndex > startIndex)
        {
            return html.Substring(startIndex, endIndex - startIndex).Trim(); // Extract and trim the text
        }

        return string.Empty; // Return empty if no text found
    }

    private static void ApplyItemStyle(ExcelRange cell, TableItemStyle itemStyle)
    {
        if (itemStyle.HorizontalAlign == HorizontalAlign.Right)
        {
            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
        }
        else if (itemStyle.HorizontalAlign == HorizontalAlign.Center)
        {
            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }
        else
        {
            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
        }
    }

    //public static void ExportToExcelGrid(GridView gv, string filename)
    //{
    //    try
    //    {
    //        filename = filename + ".xls";
    //        System.Web.HttpContext.Current.Response.Clear();
    //        gv.AllowPaging = false;
    //        gv.AllowSorting = false;           
    //        System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename);
    //        System.Web.HttpContext.Current.Response.ContentType = ".xls";
    //        StringWriter StringWriter = new System.IO.StringWriter();
    //        System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
    //        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
    //        HtmlTextWriter.Write("<html xmlns:o=\"urn:schemas-microsoft-com:office:office\" ");
    //        HtmlTextWriter.Write("xmlns:x=\"urn:schemas-microsoft-com:office:excel\" ");
    //        HtmlTextWriter.Write("<head> ");
    //        HtmlTextWriter.Write("<!--[if gte mso 9]><xml> ");
    //        HtmlTextWriter.Write("<x:ExcelWorkbook> ");
    //        HtmlTextWriter.Write("<x:ExcelWorksheets> ");
    //        HtmlTextWriter.Write("<x:ExcelWorksheet> ");
    //        HtmlTextWriter.Write("<x:Name>Sheet1</x:Name> ");
    //        HtmlTextWriter.Write("<x:WorksheetOptions> ");
    //        HtmlTextWriter.Write("<x:Selected/> ");
    //        HtmlTextWriter.Write("<x:ProtectContents>False</x:ProtectContents> ");
    //        HtmlTextWriter.Write("<x:ProtectObjects>False</x:ProtectObjects> ");
    //        HtmlTextWriter.Write("<x:ProtectScenarios>False</x:ProtectScenarios> ");
    //        HtmlTextWriter.Write("</x:WorksheetOptions> ");
    //        HtmlTextWriter.Write("</x:ExcelWorksheet> ");
    //        HtmlTextWriter.Write("</x:ExcelWorksheets> ");
    //        HtmlTextWriter.Write("</x:ExcelWorkbook> ");
    //        HtmlTextWriter.Write("</xml><![endif]--> ");
    //        HtmlTextWriter.Write("</head>");
    //        HtmlTextWriter.WriteLine("");
    //        gv.HeaderStyle.Reset();
    //        gv.FooterStyle.Reset();
    //        gv.RowStyle.Reset();
    //        gv.GridLines = GridLines.None;
    //        gv.CssClass = "text";            
    //        gv.RenderControl(HtmlTextWriter);
    //        string style = @"<style> .textmode { mso-number-format:\@; } </style> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>";
    //        System.Web.HttpContext.Current.Response.Write(style);
    //        System.Web.HttpContext.Current.Response.Output.Write(StringWriter.ToString());
    //        System.Web.HttpContext.Current.Response.Flush();
    //        System.Web.HttpContext.Current.Response.End();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw (ex);
    //    }

    //}

    public static void ExportToExcelDT(DataTable dataTable, string fileName)
    {
        try
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                // Create a new worksheet
                var workSheet = excel.Workbook.Worksheets.Add(fileName);

                // Load the DataTable into the worksheet, starting from cell A1
                workSheet.Cells["A1"].LoadFromDataTable(dataTable, true);

                // Optional: Format the header
                using (var headerRange = workSheet.Cells[1, 1, 1, dataTable.Columns.Count])
                {
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }

                // Set column widths
                for (int i = 1; i <= dataTable.Columns.Count; i++)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        workSheet.Column(i).Width = 20;

                        if (dataTable.Columns[i - 1].DataType == typeof(string))
                        {
                            workSheet.Column(i).Style.WrapText = true;
                        }
                    }
                }

                // Set the content type and filename
                var stream = new MemoryStream();
                excel.SaveAs(stream);
                var content = stream.ToArray();

                // Send the file to the client
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".xlsx");
                HttpContext.Current.Response.BinaryWrite(content);
                HttpContext.Current.Response.End();
            }
        }
        catch (Exception ex)
        {
            AddEditException(ex);
        }
    }

    public static DateTime AddBusinessDays(DateTime date, int daysToAdd)
    {
        while (daysToAdd > 0)
        {
            date = date.AddDays(1);
            if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                daysToAdd -= 1;
            }
        }
        return date;
    }

    public static DataTable ReturnITWProjects(Int32 op, String ProjectName)
    {
        BOLManageITWProjects ObjBOL = new BOLManageITWProjects();
        BLLManageITWProjects ObjBLL = new BLLManageITWProjects();
        DataTable dt;
        ObjBOL.ProjectName = ProjectName;
        ObjBOL.Operation = op;
        dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
        return dt;
    }

    public static DataTable ReturnITWProjectParts(Int32 op, String ProjectName)
    {
        BOLManageITWProjectParts ObjBOL = new BOLManageITWProjectParts();
        BLLManageITWProjectParts ObjBLL = new BLLManageITWProjectParts();
        DataTable dt;
        ObjBOL.JobID = ProjectName;
        ObjBOL.Operation = op;
        dt = ObjBLL.Return_DataSet(ObjBOL).Tables[0];
        return dt;
    }

    public static void ExportToExcelGridImages(GridView gv, string filename)
    {
        try
        {
            filename = filename + ".xls";
            System.Web.HttpContext.Current.Response.Clear();
            gv.AllowPaging = false;
            gv.AllowSorting = false;
            System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            System.Web.HttpContext.Current.Response.ContentType = ".xls";
            StringWriter StringWriter = new System.IO.StringWriter();
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
            HtmlTextWriter.Write("<html xmlns:o=\"urn:schemas-microsoft-com:office:office\" ");
            HtmlTextWriter.Write("xmlns:x=\"urn:schemas-microsoft-com:office:excel\" ");
            HtmlTextWriter.Write("<head> ");
            HtmlTextWriter.Write("<!--[if gte mso 9]><xml> ");
            HtmlTextWriter.Write("<x:ExcelWorkbook> ");
            HtmlTextWriter.Write("<x:ExcelWorksheets> ");
            HtmlTextWriter.Write("<x:ExcelWorksheet> ");
            HtmlTextWriter.Write("<x:Name>Sheet1</x:Name> ");
            HtmlTextWriter.Write("<x:WorksheetOptions> ");
            HtmlTextWriter.Write("<x:Selected/> ");
            HtmlTextWriter.Write("<x:ProtectContents>False</x:ProtectContents> ");
            HtmlTextWriter.Write("<x:ProtectObjects>False</x:ProtectObjects> ");
            HtmlTextWriter.Write("<x:ProtectScenarios>False</x:ProtectScenarios> ");
            HtmlTextWriter.Write("</x:WorksheetOptions> ");
            HtmlTextWriter.Write("</x:ExcelWorksheet> ");
            HtmlTextWriter.Write("</x:ExcelWorksheets> ");
            HtmlTextWriter.Write("</x:ExcelWorkbook> ");
            HtmlTextWriter.Write("</xml><![endif]--> ");
            HtmlTextWriter.Write("</head>");
            HtmlTextWriter.WriteLine("");
            gv.HeaderStyle.Reset();
            gv.FooterStyle.Reset();
            gv.RowStyle.Reset();
            gv.GridLines = GridLines.None;
            gv.CssClass = "text";
            gv.RenderControl(HtmlTextWriter);
            string style = @"<style> .textmode { mso-number-format:\@; } </style> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>";
            System.Web.HttpContext.Current.Response.Write(style);
            System.Web.HttpContext.Current.Response.Output.Write(StringWriter.ToString());
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    public static DataTable ReturnCADDYJobNo(Int32 op, String JobNo)
    {
        BOLCADDYENGTasks ObjBOL = new BOLCADDYENGTasks();
        BLLManageCADDYENGTasks ObjBLL = new BLLManageCADDYENGTasks();
        DataTable dt;
        ObjBOL.Operation = op;
        ObjBOL.JobNo = JobNo;
        dt = ObjBLL.GetJobNo(ObjBOL).Tables[0];
        return dt;
    }
    //ReturnCADDYJobName
    public static DataTable ReturnCADDYJobName(Int32 op, String JobName)
    {
        BOLCADDYENGTasks ObjBOL = new BOLCADDYENGTasks();
        BLLManageCADDYENGTasks ObjBLL = new BLLManageCADDYENGTasks();
        DataTable dt;
        ObjBOL.Operation = op;
        ObjBOL.JobName = JobName;
        dt = ObjBLL.GetJobName(ObjBOL).Tables[1];
        return dt;
    }

    public static void ExportToExcel_TwoGrids(GridView gv1, GridView gv2, string filename)
    {
        try
        {
            filename = filename + ".xls";
            System.Web.HttpContext.Current.Response.Clear();
            gv1.AllowPaging = false;
            gv1.AllowSorting = false;
            gv2.AllowPaging = false;
            gv2.AllowSorting = false;
            System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            System.Web.HttpContext.Current.Response.ContentType = ".xls";
            StringWriter StringWriter = new System.IO.StringWriter();
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

            // Write Excel file headers and formatting here...
            gv1.HeaderStyle.Reset();
            gv1.FooterStyle.Reset();
            gv1.RowStyle.Reset();
            gv1.GridLines = GridLines.Both;
            gv1.CssClass = "text";
            gv1.RenderControl(HtmlTextWriter);

            // Add a line break to separate the two tables
            HtmlTextWriter.Write("<br><br>");
            gv2.HeaderStyle.Reset();
            gv2.FooterStyle.Reset();
            gv2.RowStyle.Reset();
            gv2.GridLines = GridLines.Both;
            gv2.CssClass = "text";
            gv2.RenderControl(HtmlTextWriter);

            string style = @"<style> .textmode { mso-number-format:\@; } </style> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>";
            System.Web.HttpContext.Current.Response.Write(style);
            System.Web.HttpContext.Current.Response.Output.Write(StringWriter.ToString());
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    public static DataTable ReturnFabJobDetail(Int32 op, String ProjectName)
    {
        BOLINVPartsInfo ObjBOL = new BOLINVPartsInfo();
        BLLINVPartsinfo ObjBLL = new BLLINVPartsinfo();
        DataTable dt;
        ObjBOL.projectid = ProjectName;
        ObjBOL.operation = op;
        dt = ObjBLL.GetINVPartsInfo(ObjBOL).Tables[0];
        return dt;
    }

    public static string BasePath()
    {
        return "C:/inetpub/CRM_DATA/";
    }

    public static string Email()
    {
        return "aerowerksmohali@gmail.com";
    }


    public static string EmailDisplayName()
    {
        return "Liezl Sezirahiga";
    }

    public static string PartImageForExport()
    {
        return "~/INV_PartImages/";
    }

    public static string PartImagePath()
    {
        //return BasePath() + "INV_PartImages/";
        return HttpContext.Current.Server.MapPath(PartImageForExport());
    }

    public static string DealerW9Path()
    {
        return BasePath() + "DealerW9Form/";
    }

    public static string ShopDrawingPath()
    {
        return BasePath() + "INV_ShopDrawings/";
    }

    public static string ConsultantDocsPath()
    {
        return BasePath() + "Consultant_Docs/";
    }

    public static string ContainerDocsPath()
    {
        return BasePath() + "Container_Docs/";
    }

    public static string CustCareTicketPath()
    {
        return BasePath() + "CCT_CustCareTicketFiles/";
    }

    public static string MiscellaneousTaskPath()
    {
        return BasePath() + "CCT_Misc_Tasks_Docs/";
    }

    public static string PackingListPath()
    {
        return BasePath() + "INV_PackingLists/";
    }

    public static string ShopEmployeePath()
    {
        return BasePath() + "ShopEmployee_Pics/";
    }

    public static string InboundInspectionDataPath()
    {
        return BasePath() + "InboundInspection_Docs/";
    }

    public static string PlanViewPath()
    {
        return BasePath() + "ProjectFiles/";
    }

    public static string CombinedPDFPath()
    {
        return BasePath() + "CombinedPDFPath/";
    }
}

namespace Junto.WebControls
{
    /// 
    /// If CausesValidation then check the current ValidationGroup is valid
    /// and if so, disable the button.
    /// 
    [ToolboxData("<{0}:EnhancedButton runat=server>")]
    public class EnhancedButton : Button
    {
        protected override void OnPreRender(EventArgs e)
        {
            if (this.CausesValidation)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("if (typeof(Page_ClientValidate) == 'function') { ");
                sb.Append("if (Page_ClientValidate('" + this.ValidationGroup + "') == false) { return false; }} ");
                sb.Append("this.value = 'Please wait';");
                sb.Append("this.disabled = true; ");
                sb.Append(this.Page.GetPostBackEventReference(this));
                sb.Append(";");
                this.Attributes.Add("onclick", sb.ToString());
            }

            base.OnPreRender(e);
        }
    }
}