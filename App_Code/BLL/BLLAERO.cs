using System;
using System.Data;
using DALAERO;
using BOLAERO;
/// <summary>
/// Summary description for BLLAERO
/// </summary>
namespace BLLAERO
{
    public class BLLProjectsFabricationAndNestingTasks
    {
        private DALProjectsFabricationAndNestingTasks ObjDAL = new DALProjectsFabricationAndNestingTasks();
        public DataSet Return_DataSet(BOLProjectsFabricationAndNestingTasks ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLProjectsFabricationAndNestingTasks ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(ObjBOL);
            return Status;
        }
    }

    public class BLLSalesOpportunity
    {
        private DALSalesOpportunity ObjDAL = new DALSalesOpportunity();
        public DataSet Return_DataSet(BOLSalesOpportunity ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }
    }

    public class BLLShippingHistory
    {
        private DALShippingHistory ObjDAL = new DALShippingHistory();
        public DataSet Return_DataSet(BOLShippingHistory ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }    
    }

    public class BLLYTDQuotesData
    {
        private DALYTDQuotesData ObjDAL = new DALYTDQuotesData();
        public DataSet GetYTDQuotesData(BOLQuotesandOrders ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.ReturnDataSet(ObjBOL);
            return ds;
        }
    }

    public class BLLShopDrawingCategory
    {
        private DALShopDrawingCategory ObjDAL = new DALShopDrawingCategory();
        public DataSet Return_DataSet(BOLShopDrawingCategory ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLShopDrawingCategory ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(ObjBOL);
            return Status;
        }
    }

    public class BLLShopDrawingImpact
    {
        private DALShopDrawingImpact ObjDAL = new DALShopDrawingImpact();
        public DataSet Return_DataSet(BOLShopDrawingImpact ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLShopDrawingImpact ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(ObjBOL);
            return Status;
        }
    }

    public class BLLShopDwgIssueLog
    {
        private DALShopDwgIssueLog ObjDAL = new DALShopDwgIssueLog();
        public DataSet Return_DataSet(BOLManageShopDwgIssueLog ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLManageShopDwgIssueLog ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(ObjBOL);
            return Status;
        }
    }

    public class BLLManageDealerRebate
    {
        private DALManageDealerRebate ObjDALRebateMaintain = new DALManageDealerRebate();
        public String SaveRebate(BOLManageDealersRebate ObjBOL)
        {
            string Status = "";
            Status = ObjDALRebateMaintain.SaveRebate(ObjBOL);
            return Status;
        }
        public DataSet GetControls(BOLManageDealersRebate ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDALRebateMaintain.GetControls(ObjBOL);
            return ds;
        }
    }


    public class BLLManageExtensions
    {
        private DALManageExtensions ObjDAL = new DALManageExtensions();
        public DataSet Return_DataSet(BOLManageExtensions ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }
    }
    public class BLLManageCompanyOfficeDepartment
    {
        private DALManageCompanyOfficeDepartment ObjDAL = new DALManageCompanyOfficeDepartment();
        public DataSet BindControls(BOLManageCompanyOfficeDepartment ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Returen_DS(ObjBOL);
            return ds;
        }

        public string SaveCompanyOfficeDepartment(BOLManageCompanyOfficeDepartment ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveCompanyOfficeDepartment(ObjBOL);
            return Status;
        }
    }




    public class BLLITWSize
    {
        private DALITWSize ObjDAL = new DALITWSize();
        public DataSet Return_DataSet(BOLITWSize ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLITWSize ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(ObjBOL);
            return Status;
        }
    }

    public class BLLITWCategory
    {
        private DALITWCategory ObjDAL = new DALITWCategory();
        public DataSet Return_DataSet(BOLITWCategory ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLITWCategory ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(ObjBOL);
            return Status;
        }
    }

    public class BLLExtensions
    {
        private DALExtensions ObjDAL = new DALExtensions();
        public DataSet BindControls(BOLExtensions ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }
        public String Return_String(BOLExtensions ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(ObjBOL);
            return Status;
        }
        public String DeleteExt(BOLExtensions ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.DeleteExt(ObjBOL);
            return Status;
        }
    }

    public class BLLAddMenu
    {
        private DALAddMenu ObjDAL = new DALAddMenu();
        public DataSet Return_DataSet(BOLAddMenu ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }
        public String Return_String(BOLAddMenu ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(ObjBOL);
            return Status;
        }
    }


    public class BLLDailyPurchaseRequester
    {
        private DALDailyPurchaseRequester ObjDAL = new DALDailyPurchaseRequester();
        public DataSet Return_DataSet(BOLDailyPurchaseRequester ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }
        public String Return_String(BOLDailyPurchaseRequester ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(ObjBOL);
            return Status;
        }
    }

    public class BLLPurchaseHistoryDetails
    {
        private DALPurchaseHistoryDetails ObjDAL = new DALPurchaseHistoryDetails();
        public DataSet GetPurchaseHistoryDetails(BOLPurchaseHistoryDetails ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetPurchaseHistoryDetails(ObjBOL);
            return ds;
        }
        public DataSet GetJobsStatusReport(BOLPurchaseHistoryDetails ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetJobsStatusReport(ObjBOL);
            return ds;
        }
    }
    public class BLLPurchaseHistory
    {
        private DALPurchaseHistory ObjDAL = new DALPurchaseHistory();
        public DataSet GetPurchaseHistory(BOLPurchaseHistory ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetPurchaseHistory(ObjBOL);
            return ds;
        }
    }
    public class BLLTrackContainerJobs
    {
        private DALTrackContainerJobs ObjDAL = new DALTrackContainerJobs();
        public DataSet Return_DS(BOLTrackContainerJobs ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DS(ObjBOL);
            return ds;
        }
    }

    public class BLLManageShipmentReport
    {
        private DALShipmentReport ObjDAL = new DALShipmentReport();
        public DataSet Return_DS(BOLShipmentReport ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DS(ObjBOL);
            return ds;
        }
        public string Return_String(BOLShipmentReport ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.Return_String(ObjBOL);
            return Status;
        }
    }

    public class BLLForecastingMonthlyEmailData
    {
        private DALForecastingMonthlyEmailData ObjDAL = new DALForecastingMonthlyEmailData();
        public DataSet Return_DataSet(BOLForecastingMonthlyEmailData ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }
        public String Return_String(BOLForecastingMonthlyEmailData ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(ObjBOL);
            return Status;
        }
    }

    public class BLLDailyPurchaseParts
    {
        private DALDailyPurchaseParts ObjDAL = new DALDailyPurchaseParts();
        public DataSet Return_DataSet(BOLDailyPurchaseParts ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }
        public String Return_String(BOLDailyPurchaseParts ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(ObjBOL);
            return Status;
        }
    }

    public class BLLDailyPurchase
    {
        private DALDailyPurchase ObjDAL = new DALDailyPurchase();
        public DataSet Return_DataSet(BOLDailyPurchase ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }
        public String Return_String(BOLDailyPurchase ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(ObjBOL);
            return Status;
        }
    }

    public class BLLSalesActivity
    {
        private DALSalesActivity ObjDAL = new DALSalesActivity();
        public DataSet Return_DataSet(BOLSalesActivity ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }
        public String Return_String(BOLSalesActivity ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(ObjBOL);
            return Status;
        }
    }

    public class BLLBindEmailAddress
    {
        private DALBindEmailAddress ObjDAL = new DALBindEmailAddress();
        public DataSet Return_DataSet(BOLBindEmailAddress ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

    }


    public class BLLReportDashboard
    {
        private DALReportDashboard ObjDAL = new DALReportDashboard();
        public DataSet Return_DataSet(BOLReportDashboard ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

    }


    public class BLLStockInHandAdjustment
    {
        private DALStockInHandAdjustment ObjDAL = new DALStockInHandAdjustment();
        public DataSet Return_DataSet(BOLStockInHandAdjustment ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }
        public String Return_String(BOLStockInHandAdjustment ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(ObjBOL);
            return Status;
        }

    }
    public class BLLStockInDashboard
    {
        private DALStockInDashboard ObjDAL = new DALStockInDashboard();
        public DataSet Return_DataSet(BOLStockInDashboard ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

    }
    public class BLLForecastingModelPartMapping
    {
        private DALForecastingModelPartMapping ObjDAL = new DALForecastingModelPartMapping();
        public DataSet Return_DataSet(BOLForecastingModelPartMapping ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLForecastingModelPartMapping objBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(objBOL);
            return Status;
        }
    }

    public class BLLForecastingModelSizeMapping
    {
        private DALForecastingModelSizeMapping ObjDAL = new DALForecastingModelSizeMapping();
        public DataSet Return_DataSet(BOLForecastingModelSizeMapping ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLForecastingModelSizeMapping objBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(objBOL);
            return Status;
        }
    }
    public class BLLForecastingModelTypeMapping
    {
        private DALForecastingModelTypeMapping ObjDAL = new DALForecastingModelTypeMapping();
        public DataSet Return_DataSet(BOLForecastingModelTypeMapping ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLForecastingModelTypeMapping objBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(objBOL);
            return Status;
        }
    }
    public class BLLForecastingSubAssembly
    {
        private DALForecastingSubAssembly ObjDAL = new DALForecastingSubAssembly();
        public DataSet Return_DataSet(BOLForecastingSubParts ObjBOL)
        {
            DataSet ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }
    }
    public class BLLEmployeeMaintain
    {
        private DALEmployeeMaintain ObjDALEmpMaintain = new DALEmployeeMaintain();
        public String SaveEmployeeRecord(BOLEmployeeMaintain ObjBOL)
        {
            string Status = "";
            Status = ObjDALEmpMaintain.SaveEmployeeRecord(ObjBOL);
            return Status;
        }
        public DataSet GetControls(BOLEmployeeMaintain ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDALEmpMaintain.GetControls(ObjBOL);
            return ds;
        }
    }
    public class BLLForecastingJobModels
    {
        private DALForecastingJobModels ObjDAL = new DALForecastingJobModels();
        public DataSet Return_DataSet(BOLForecastingJobModels ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLForecastingJobModels objBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(objBOL);
            return Status;
        }
    }

    public class BLLPostInstallFollowups
    {
        private DALPostInstallFollowups ObjDAL = new DALPostInstallFollowups();
        public DataSet Return_DataSet(BOLPostInstallFollowups ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLPostInstallFollowups objBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(objBOL);
            return Status;
        }
    }
    public class BLLManageRepActiveSales
    {
        private DALManageActiveRepSales ObjDAL = new DALManageActiveRepSales();
        public DataSet GetRepActiveSales(BOLRepActiveSales ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetRepActiveSales(ObjBOL);
            return ds;
        }

        public string SaveRepActiveSales(BOLRepActiveSales ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveRepActiveSales(ObjBOL);
            return Status;
        }
    }

    public class BLLShpDrgEng
    {
        private DALShpDrgEng ObjDALShpDrg = new DALShpDrgEng();
        public DataSet GetDataShpDrgs(BOLShpDrg ObjBOLShpDrg)
        {
            DataSet ds = new DataSet();
            ds = ObjDALShpDrg.GetDataShpDrg(ObjBOLShpDrg);
            return ds;
        }
        public String SaveDataShpDrg(BOLShpDrg ObjBOLShpDrg)
        {
            string Status = "";
            Status = ObjDALShpDrg.SaveDataShpDrg(ObjBOLShpDrg);
            return Status;
        }
    }

    public class BLLManageProjects_New
    {
        private DALManageProjects_New ObjDAL = new DALManageProjects_New();
        public DataSet GetProjects(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetProject(ObjBOL);
            return ds;
        }
        public string GetProjectStatus(BOLManageProjects ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.GetProjectStatus(ObjBOL);
            return Status;
        }
        public DataSet GetStates(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetStates(ObjBOL);
            return ds;
        }
        public string SaveProject(BOLManageProjects ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveProject(ObjBOL);
            return Status;
        }
        public DataSet ReturnProjects(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetProject(ObjBOL);
            return ds;
        }
        public DataSet FillControls(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.FillControls(ObjBOL);
            return ds;
        }

        public string GenrateJNumber(BOLManageProjects ObjBOL)
        {
            string jnumber = string.Empty;
            jnumber = ObjDAL.GenrateJNumber(ObjBOL);
            return jnumber;
        }

        public Decimal GetTaxAmount(BOLManageProjects ObjBOL)
        {
            Decimal jnumber = 0;
            jnumber = ObjDAL.GetTaxAmount(ObjBOL);
            return jnumber;
        }

        public Decimal GetCashDiscount(BOLManageProjects ObjBOL)
        {
            Decimal discper = 0;
            discper = ObjDAL.GetCashDiscount(ObjBOL);
            return discper;
        }

        public DataSet Return_DataSet(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }
    }

    public class BLLManageProjectsEng
    {
        private DALManageProjectsEng ObjDAL = new DALManageProjectsEng();
        public DataSet GetProjects(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetProject(ObjBOL);
            return ds;
        }
        public DataSet GetFilePath(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetFilePath(ObjBOL);
            return ds;
        }
        public string GetProjectStatus(BOLManageProjects ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.GetProjectStatus(ObjBOL);
            return Status;
        }

        public string SaveFileName(BOLManageProjects ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveFileName(ObjBOL);
            return Status;
        }

        public string SaveProject(BOLManageProjects ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveProject(ObjBOL);
            return Status;
        }
        public string CheckEmployeeLogin(BOLManageProjects ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.CheckEmployeeLogin(ObjBOL);
            return Status;
        }
        public DataSet ReturnProjects(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetProject(ObjBOL);
            return ds;
        }
        public DataSet FillControls(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.FillControls(ObjBOL);
            return ds;
        }
    }

    public class BLLSiteVisitInformation
    {
        private DALSiteVisitInformation ObjDAL = new DALSiteVisitInformation();
        public DataSet Return_DataSet(BOLSiteVisitInformation ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLSiteVisitInformation objBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(objBOL);
            return Status;
        }
    }

    public class BLLAppSetting
    {
        private DALAppSetting ObjDAL = new DALAppSetting();
        public DataSet Return_DataSet(BOLAppSetting ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLAppSetting objBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(objBOL);
            return Status;
        }
    }
    public class BLLException
    {
        private DALException ObjException = new DALException();
        public String SaveException(BOLException ObjBOLException)
        {
            string Status = "";
            Status = ObjException.SaveException(ObjBOLException);
            return Status;
        }
    }
    public class BLLSalesRepGroup
    {
        private DALSalesRepGroup ObjSalesRep = new DALSalesRepGroup();
        public DataSet GetSalesRepGroup(BOLSalesRepGroup ObjBOLSalesRep)
        {
            DataSet ds = new DataSet();
            ds = ObjSalesRep.GetSalesReport(ObjBOLSalesRep);
            return ds;
        }
    }
    public class BLLDealers
    {
        private DALDealers ObjDAL = new DALDealers();
        public DataSet GetDealers(BOLDealers ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetDealers(ObjBOL);
            return ds;
        }
    }
    //START BLL Proposal Search
    public class BLLProposalSearch
    {
        private DALProposalSearch ObjDALProposalSearch = new DALProposalSearch();
        public DataSet GetProposalSearch(BOLProposalSearch ObjBOLProposalSearch)
        {
            DataSet ds = new DataSet();
            ds = ObjDALProposalSearch.GetProposalSearch(ObjBOLProposalSearch);
            return ds;
        }
    }
    //START BLL Project Search
    public class BLLProjectSearch
    {
        private DALProjectSearch ObjDALProjectSearch = new DALProjectSearch();
        public DataSet GetProjectSearch(BOLProjectSearch ObjBOLProjectSearch)
        {
            DataSet ds = new DataSet();
            ds = ObjDALProjectSearch.GetProjectSearch(ObjBOLProjectSearch);
            return ds;
        }
    }
    //Start BLL Shop Drawing 
    public class BLLShpDrg
    {
        private DALShpDrg ObjDALShpDrg = new DALShpDrg();
        public DataSet GetDataShpDrgs(BOLShpDrg ObjBOLShpDrg)
        {
            DataSet ds = new DataSet();
            ds = ObjDALShpDrg.GetDataShpDrg(ObjBOLShpDrg);
            return ds;
        }
        public String SaveDataShpDrg(BOLShpDrg ObjBOLShpDrg)
        {
            string Status = "";
            Status = ObjDALShpDrg.SaveDataShpDrg(ObjBOLShpDrg);
            return Status;
        }
    }
    //End BLL Shop Drawings
    //public class BLLProposals
    //{
    //    private DALPackage ObjDALPackage = new DALPackage();
    //    public DataSet GetPackage(BOLPackage ObjBOLPackage)
    //    {
    //        DataSet ds = new DataSet();
    //        ds = ObjDALPackage.GetPackage(ObjBOLPackage);
    //        return ds;
    //    }
    //}
    public class BLLMenu
    {
        private DALMenu ObjDAL = new DALMenu();
        public DataSet GetMenu(BOLMenu ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetMenu(ObjBOL);
            return ds;
        }
    }
    public class BLLManageLogs
    {
        private DALManageLogs ObjDAL = new DALManageLogs();
        public string SaveLogs(BOLManageLogs ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveLogs(ObjBOL);
            return Status;
        }

    }

    public class BLLManageProposals
    {
        private DALManageProposals ObjDAL = new DALManageProposals();
        public DataSet GetProposals(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetProposal(ObjBOL);
            return ds;
        }
        public DataSet GetDealerMember(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetDealerMember(ObjBOL);
            return ds;
        }
        public string AddFollowUpRecord(BOLManageProposals ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveFollowUp(ObjBOL);
            return Status;
        }
        public string DeleteFollowUpRecord(BOLManageProposals ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteFollowUpRecord(ObjBOL);
            return Status;
        }
        public DataSet GetFollowups(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetFollowupData(ObjBOL);
            return ds;
        }
        public DataSet GetConsultantMember(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetConsultantMember(ObjBOL);
            return ds;
        }
        public DataSet GetStates(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetStates(ObjBOL);
            return ds;
        }
        public DataSet GetTypeid(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetTypeID(ObjBOL);
            return ds;
        }
        public DataSet GetWasteEqTypeid(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetWasteEqTypeid(ObjBOL);
            return ds;
        }
        public string SaveProposals(BOLManageProposals ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveProposal(ObjBOL);
            return Status;
        }
        public DataSet ReturnProposals(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetProposal(ObjBOL);
            return ds;
        }
        public DataSet GetFollowUpGrid(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetFollowupSummary(ObjBOL);
            return ds;
        }
        public DataSet FillControls(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.FillControls(ObjBOL);
            return ds;
        }
        public string GeneratePnumber(BOLManageProposals ObjBOL)
        {
            string pnumber = string.Empty;
            pnumber = ObjDAL.GeneratePnumber(ObjBOL);
            return pnumber;
        }
        public DataSet GetPendingProposals(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetPendingProposals(ObjBOL);
            return ds;
        }
        public string GenerateStatus(BOLManageProposals ObjBOL)
        {
            string pnumber = string.Empty;
            pnumber = ObjDAL.GenerateStatus(ObjBOL);
            return pnumber;
        }
        //public DataSet GetProposalSearch(BOLManageProposals ObjBOL)
        //{
        //    DataSet ds = new DataSet();
        //    ds = ObjDAL.GetProposalSearch(ObjBOL);
        //    return ds;
        //}
        public string SaveProposalsDwgs(BOLManageProposals ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveProDrawings(ObjBOL);
            return Status;
        }
        public string DeleteProDrgRecord(BOLManageProposals ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteProDrgRecord(ObjBOL);
            return Status;
        }

        public string AddExistingJobID(BOLManageProposals ObjBOL)
        {
            string pnumber = string.Empty;
            pnumber = ObjDAL.AddExistingJobID(ObjBOL);
            return pnumber;
        }
        public string DeleteExistingJobID(BOLManageProposals ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteExistingJobID(ObjBOL);
            return Status;
        }
        public string CheckEmailReminder(BOLManageProposals ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.CheckEmailReminder(ObjBOL);
            return Status;
        }
        public DataSet ReturnDatatable(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.ReturnDatatable(ObjBOL);
            return ds;
        }
    }

    public class BLLManageCustomers
    {
        private DALManageCustomers ObjDAL = new DALManageCustomers();
        public DataSet GetCustomers(BOLManageCustomers ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetCustomers(ObjBOL);
            return ds;
        }

        public DataSet GetCustomersState(BOLManageCustomers ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetCustomersState(ObjBOL);
            return ds;
        }

        public string SaveCustomers(BOLManageCustomers ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveCustomers(ObjBOL);
            return Status;
        }

        public DataSet ReturnCustomers(BOLManageCustomers ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.ReturnCustomers(ObjBOL);
            return ds;
        }

        public String DeleteCustomer(BOLManageCustomers ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteCustomer(ObjBOL);
            return Status;
        }
    }

    public class BLLManageCustomerMember
    {
        private DALManageCustomerMember ObjDAL = new DALManageCustomerMember();
        public DataSet GetCustomers(BOLManageCustomerMember ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetCustomerMember(ObjBOL);
            return ds;
        }
        public string SaveCustomerMember(BOLManageCustomerMember ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveCustomerMember(ObjBOL);
            return Status;
        }
        public string UpdateCustomerMember(BOLManageCustomerMember ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdateCustomerMember(ObjBOL);
            return Status;
        }
        public String DeleteCustomerMember(BOLManageCustomerMember ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteCustomerMember(ObjBOL);
            return Status;
        }
    }

    //Consultant
    public class BLLManageConsultant
    {
        private DALManageConsultant ObjDAL = new DALManageConsultant();
        public DataSet GetConsultant(BOLManageConsultant ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetConsultant(ObjBOL);
            return ds;
        }

        public DataSet GetConsultantState(BOLManageConsultant ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetConsultantState(ObjBOL);
            return ds;
        }

        public string DeleteConsultantEmailPath(BOLManageConsultant ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteEmailPath(ObjBOL);
            return Status;
        }

        public string SaveConsultant(BOLManageConsultant ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveConsultant(ObjBOL);
            return Status;
        }

        public DataSet ReturnConsultant(BOLManageConsultant ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.ReturnConsultant(ObjBOL);
            return ds;
        }

        public String DeleteConsultant(BOLManageConsultant ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteConsultant(ObjBOL);
            return Status;
        }
    }

    public class BLLManageConsultantMember
    {
        private DALManageConsultantMember ObjDAL = new DALManageConsultantMember();
        public DataSet GetCustomers(BOLManageConsultantMember ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetConsultantMember(ObjBOL);
            return ds;
        }

        public string SaveConsultantMember(BOLManageConsultantMember ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveCustomerMember(ObjBOL);
            return Status;
        }

        public String DeleteConsultantMember(BOLManageConsultantMember ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteConsultantMember(ObjBOL);
            return Status;
        }
    }

    // BOL Employee
    public class BLLManageEmployee
    {
        private DALManageEmployees ObjDAL = new DALManageEmployees();
        public DataSet GetEmployee(BOLManageEmployees ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetEmployees(ObjBOL);
            return ds;
        }

        public string SaveEmployee(BOLManageEmployees ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveEmployees(ObjBOL);
            return Status;
        }

    }

    public class BLLManageDealers
    {
        private DALManageDealers ObjDAL = new DALManageDealers();
        public DataSet GetDealers(BOLManageDealers ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetDealers(ObjBOL);
            return ds;
        }

        public string SaveDealers(BOLManageDealers ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveDealers(ObjBOL);
            return Status;
        }

        public DataSet GetDealersState(BOLManageDealers ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetDealerState(ObjBOL);
            return ds;
        }

        public DataSet ReturnDealers(BOLManageDealers ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.ReturnDealers(ObjBOL);
            return ds;
        }

        public String DeleteDealers(BOLManageDealers ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteDealers(ObjBOL);
            return Status;
        }
    }

    public class BLLManageDealerMember
    {
        private DALManageDealerMember ObjDAL = new DALManageDealerMember();
        public DataSet GetDealer(BOLManageDealerMember ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetDealerMember(ObjBOL);
            return ds;
        }

        public string SaveDealerMember(BOLManageDealerMember ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveDealerMember(ObjBOL);
            return Status;
        }

        public String DeleteDealerMember(BOLManageDealerMember ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteDealerMember(ObjBOL);
            return Status;
        }
    }


    public class BLLManageProjects
    {
        private DALManageProjects ObjDAL = new DALManageProjects();
        public DataSet GetProjects(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetProject(ObjBOL);
            return ds;
        }
        public string GetProjectStatus(BOLManageProjects ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.GetProjectStatus(ObjBOL);
            return Status;
        }
        public DataSet GetStates(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetStates(ObjBOL);
            return ds;
        }
        public string SaveProject(BOLManageProjects ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveProject(ObjBOL);
            return Status;
        }
        public DataSet ReturnProjects(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetProject(ObjBOL);
            return ds;
        }
        public DataSet FillControls(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.FillControls(ObjBOL);
            return ds;
        }

        public string GenrateJNumber(BOLManageProjects ObjBOL)
        {
            string jnumber = string.Empty;
            jnumber = ObjDAL.GenrateJNumber(ObjBOL);
            return jnumber;
        }

        public Decimal GetTaxAmount(BOLManageProjects ObjBOL)
        {
            Decimal jnumber = 0;
            jnumber = ObjDAL.GetTaxAmount(ObjBOL);
            return jnumber;
        }

        public Decimal GetCashDiscount(BOLManageProjects ObjBOL)
        {
            Decimal discper = 0;
            discper = ObjDAL.GetCashDiscount(ObjBOL);
            return discper;
        }
    }

    public class BLLManageRepBranches
    {
        private DALManageRepBranches ObjDAL = new DALManageRepBranches();
        public DataSet GetRepBranches(BOLManageRepBranches ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetRepBranches(ObjBOL);
            return ds;
        }

        public string SaveRepBranches(BOLManageRepBranches ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveRepBranches(ObjBOL);
            return Status;
        }

        public String DeleteRepBranches(BOLManageRepBranches ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteRepBranches(ObjBOL);
            return Status;
        }
    }


    public class BLLDistributors
    {
        private DALDistributors ObjDALDistributors = new DALDistributors();
        public DataSet GetDistributors(BOLDistributors ObjBOLDistributors)
        {
            DataSet ds = new DataSet();
            ds = ObjDALDistributors.GetDistributors(ObjBOLDistributors);
            return ds;
        }

        public string SaveUpdateDistributors(BOLDistributors ObjBOLDistributors)
        {
            string Status = "";
            Status = ObjDALDistributors.SaveUpdateDistributors(ObjBOLDistributors);
            return Status;
        }
    }

    public class BLLPackage
    {
        private DALPackage ObjDALPackage = new DALPackage();
        public DataSet GetPackage(BOLPackage ObjBOLPackage)
        {
            DataSet ds = new DataSet();
            ds = ObjDALPackage.GetPackage(ObjBOLPackage);
            return ds;
        }
        public string SaveUpdatePackage(BOLPackage ObjBOLPackage)
        {
            string Status = "";
            Status = ObjDALPackage.SaveUpdatePackage(ObjBOLPackage);
            return Status;
        }
    }

    public class BLLPackageDispatchSchedule
    {
        private DALPackageDispatchSchedule ObjDALPackageDispatchSchedule = new DALPackageDispatchSchedule();
        public DataSet GetPackageDispatchSchedule(BOLPackageDispatchSchedule ObjBOLPackageDispatchSchedule)
        {
            DataSet ds = new DataSet();
            ds = ObjDALPackageDispatchSchedule.GetPackageDispatchSchedule(ObjBOLPackageDispatchSchedule);
            return ds;
        }

        public string SaveUpdatePackageDispatchSchedule(BOLPackageDispatchSchedule ObjBOLPackageDispatchSchedule)
        {
            string Status = "";
            Status = ObjDALPackageDispatchSchedule.SaveUpdatePackageDispatchSchedule(ObjBOLPackageDispatchSchedule);
            return Status;
        }
    }

    public class BLLDesignation
    {
        private DALDesignation ObjDALDesignation = new DALDesignation();
        public DataSet GetDesignation(BOLDesignation ObjBOLDesignation)
        {
            DataSet ds = new DataSet();
            ds = ObjDALDesignation.GetDesignation(ObjBOLDesignation);
            return ds;
        }

        public string SaveDesignation(BOLDesignation ObjBOLDesignation)
        {
            string Status = "";
            Status = ObjDALDesignation.SaveDesignation(ObjBOLDesignation);
            return Status;
        }
    }

    public class BLLWorkStatus
    {
        private DALWorkStatus ObjDALWorkStatus = new DALWorkStatus();
        public DataSet GetWorkStatus(BOLWorkStatus ObjBOLWorkStatus)
        {
            DataSet ds = new DataSet();
            ds = ObjDALWorkStatus.GetWorkStatus(ObjBOLWorkStatus);
            return ds;
        }

        public string SaveWorkStatus(BOLWorkStatus ObjBOLWorkStatus)
        {
            string Status = "";
            Status = ObjDALWorkStatus.SaveWorkStatus(ObjBOLWorkStatus);
            return Status;
        }
    }

    public class BLLWorkType
    {
        private DALWorkType ObjDALWorkType = new DALWorkType();
        public DataSet GetWorkType(BOLWorkType ObjBOLWorkType)
        {
            DataSet ds = new DataSet();
            ds = ObjDALWorkType.GetWorkType(ObjBOLWorkType);
            return ds;
        }

        public string SaveWorkType(BOLWorkType ObjBOLWorkType)
        {
            string Status = "";
            Status = ObjDALWorkType.SaveWorkType(ObjBOLWorkType);
            return Status;
        }
    }

    public class BLLNotepad
    {
        private DALNotepad ObjDALWorkName = new DALNotepad();
        public DataSet GetWorkName(BOLNotepad ObjBOLWorkName)
        {
            DataSet ds = new DataSet();
            ds = ObjDALWorkName.GetWorkName(ObjBOLWorkName);
            return ds;
        }

        public string SaveWorkName(BOLNotepad ObjBOLWorkName)
        {
            string Status = "";
            Status = ObjDALWorkName.SaveWorkName(ObjBOLWorkName);
            return Status;
        }
    }

    public class BLLPaymentDetails
    {
        private DALPaymentDetails ObjDALPaymentDetails = new DALPaymentDetails();
        public DataSet GetPaymentDetails(BOLPaymentDetails ObjBOLPaymentDetails)
        {
            DataSet ds = new DataSet();
            ds = ObjDALPaymentDetails.GetPaymentDetails(ObjBOLPaymentDetails);
            return ds;
        }

        public string SavePaymentDetails(BOLPaymentDetails ObjBOLPaymentDetails)
        {
            string Status = "";
            Status = ObjDALPaymentDetails.SavePaymentDetails(ObjBOLPaymentDetails);
            return Status;
        }
    }


    public class BLLDiagnosis
    {
        private DALDiagnosis ObjDALDiagnosis = new DALDiagnosis();
        public DataSet GetDiagnosis(BOLDiagnosis ObjBOLDiagnosis)
        {
            DataSet ds = new DataSet();
            ds = ObjDALDiagnosis.GetDiagnosis(ObjBOLDiagnosis);
            return ds;
        }

        public string SaveDiagnosis(BOLDiagnosis ObjBOLDiagnosis)
        {
            string Status = "";
            Status = ObjDALDiagnosis.SaveDiagnosis(ObjBOLDiagnosis);
            return Status;
        }
    }

    public class BLLPatientMaster
    {
        private DALPatientMaster ObjDALPatientMaster = new DALPatientMaster();
        public DataSet GetDALPatientMaster(BOLPatientMaster ObjBOLPatientMaster)
        {
            DataSet ds = new DataSet();
            ds = ObjDALPatientMaster.GetAllPatientMaster(ObjBOLPatientMaster);
            return ds;
        }
        public DataSet GetPatientMasterMaxID(BOLPatientMaster ObjBOLPatientMaster)
        {
            DataSet ds = new DataSet();
            ds = ObjDALPatientMaster.GetPatientMasterMaxID(ObjBOLPatientMaster);
            return ds;
        }
        public DataSet GetPatientMasterCount(BOLPatientMaster ObjBOLPatientMaster)
        {
            DataSet ds = new DataSet();
            ds = ObjDALPatientMaster.GetPatientMasterCount(ObjBOLPatientMaster);
            return ds;
        }

        public string SavePatientMaster(BOLPatientMaster ObjBOLPatientMaster)
        {
            string Status = "";
            Status = ObjDALPatientMaster.SavePatientMaster(ObjBOLPatientMaster);
            return Status;
        }
        public String DeletePatientMaster(BOLPatientMaster ObjBOLPatientMaster)
        {
            string Status = "";
            Status = ObjDALPatientMaster.DeletePatientMaster(ObjBOLPatientMaster);
            return Status;
        }
        public DataSet GetAllSPatientMaster(BOLPatientMaster ObjBOLPatientMaster)
        {
            DataSet ds = new DataSet();
            ds = ObjDALPatientMaster.GetAllPatientMaster(ObjBOLPatientMaster);
            return ds;
        }
        public DataSet SearchPatientMaster(BOLPatientMaster ObjBOLPatientMaster)
        {
            DataSet ds = new DataSet();
            ds = ObjDALPatientMaster.SearchPatientMaster(ObjBOLPatientMaster);
            return ds;
        }
    }

    public class BLLSurgicalPathologyReport
    {
        private DALSurgicalPathologyReport ObjDALSurgicalPathologyReport = new DALSurgicalPathologyReport();
        public DataSet GetSurgicalPathologyReport(BOLSurgicalPathologyReport ObjBOLSurgicalPathologyReport)
        {
            DataSet ds = new DataSet();
            ds = ObjDALSurgicalPathologyReport.GetSurgicalPathologyReport(ObjBOLSurgicalPathologyReport);
            return ds;
        }
        public DataSet GetSurgicalPathologyReportMaxID(BOLSurgicalPathologyReport ObjBOLSurgicalPathologyReport)
        {
            DataSet ds = new DataSet();
            ds = ObjDALSurgicalPathologyReport.GetSurgicalPathologyReportMaxID(ObjBOLSurgicalPathologyReport);
            return ds;
        }
        public DataSet GetSurgicalPathologyReportCount(BOLSurgicalPathologyReport ObjBOLSurgicalPathologyReport)
        {
            DataSet ds = new DataSet();
            ds = ObjDALSurgicalPathologyReport.GetSurgicalPathologyReportCount(ObjBOLSurgicalPathologyReport);
            return ds;
        }

        public string SaveSurgicalPathologyReport(BOLSurgicalPathologyReport ObjBOLSurgicalPathologyReport)
        {
            string Status = "";
            Status = ObjDALSurgicalPathologyReport.SaveSurgicalPathologyReport(ObjBOLSurgicalPathologyReport);
            return Status;
        }
        public String DeleteSurgicalPathologyReport(BOLSurgicalPathologyReport ObjBOL)
        {
            string Status = "";
            Status = ObjDALSurgicalPathologyReport.DeleteSurgicalPathologyReport(ObjBOL);
            return Status;
        }

        public DataSet GetPatientDetail_2011(BOLSurgicalPathologyReport ObjBOLSurgicalPathologyReport)
        {
            DataSet ds = new DataSet();
            ds = ObjDALSurgicalPathologyReport.GetPatientDetail_2011(ObjBOLSurgicalPathologyReport);
            return ds;
        }

        public DataSet GetPatientDetail(BOLSurgicalPathologyReport ObjBOLSurgicalPathologyReport)
        {
            DataSet ds = new DataSet();
            ds = ObjDALSurgicalPathologyReport.GetPatientDetail(ObjBOLSurgicalPathologyReport);
            return ds;
        }

        //GetAllSurgicalPathologyReport
        public DataSet GetAllSurgicalPathologyReport(BOLSurgicalPathologyReport ObjBOLSurgicalPathologyReport)
        {
            DataSet ds = new DataSet();
            ds = ObjDALSurgicalPathologyReport.GetAllSurgicalPathologyReport(ObjBOLSurgicalPathologyReport);
            return ds;
        }
        public DataSet GetAllSurgicalPathologyReport_2011(BOLSurgicalPathologyReport ObjBOLSurgicalPathologyReport)
        {
            DataSet ds = new DataSet();
            ds = ObjDALSurgicalPathologyReport.GetAllSurgicalPathologyReport_2011(ObjBOLSurgicalPathologyReport);
            return ds;
        }
        //SearchPathologyReport
        public DataSet SearchPathologyReport(BOLSurgicalPathologyReport ObjBOLSurgicalPathologyReport)
        {
            DataSet ds = new DataSet();
            ds = ObjDALSurgicalPathologyReport.SearchPathologyReport(ObjBOLSurgicalPathologyReport);
            return ds;
        }
    }


    public class BLLSurgicalPathologyReportDetail
    {
        private DALSurgicalPathologyReportDetail ObjDALSurgicalPathologyReportDetail = new DALSurgicalPathologyReportDetail();
        public DataSet GetSurgicalPathologyReport(BOLSurgicalPathologyReportDetail ObjBOLSurgicalPathologyReportDetail)
        {
            DataSet ds = new DataSet();
            ds = ObjDALSurgicalPathologyReportDetail.GetSurgicalPathologyReportDetail(ObjBOLSurgicalPathologyReportDetail);
            return ds;
        }


        public string SaveSurgicalPathologyReportDetail(BOLSurgicalPathologyReportDetail ObjBOLSurgicalPathologyReportDetail)
        {
            string Status = "";
            Status = ObjDALSurgicalPathologyReportDetail.SaveSurgicalPathologyReportDetail(ObjBOLSurgicalPathologyReportDetail);
            return Status;
        }

    }


    public class BLLDiagnosisAutopsy
    {
        private DALDiagnosisAutopsy ObjDALDiagnosisAutopsy = new DALDiagnosisAutopsy();
        public DataSet GetDiagnosisAutopsy(BOLDiagnosisAutopsy ObjBOLDiagnosisAutopsy)
        {
            DataSet ds = new DataSet();
            ds = ObjDALDiagnosisAutopsy.GetDiagnosisAutopsy(ObjBOLDiagnosisAutopsy);
            return ds;
        }

        public string SaveDiagnosisAutopsy(BOLDiagnosisAutopsy ObjBOLDiagnosisAutopsy)
        {
            string Status = "";
            Status = ObjDALDiagnosisAutopsy.SaveDiagnosisAutopsy(ObjBOLDiagnosisAutopsy);
            return Status;
        }
    }

    public class BLLCPCAutopsy
    {
        private DALCPCAutopsy ObjDALCPCAutopsy = new DALCPCAutopsy();
        public DataSet GetCPCAutopsy(BOLCPCAutopsy ObjBOLCPCAutopsy)
        {
            DataSet ds = new DataSet();
            ds = ObjDALCPCAutopsy.GetCPCAutopsy(ObjBOLCPCAutopsy);
            return ds;
        }

        public string SaveCPCAutopsy(BOLCPCAutopsy ObjBOLCPCAutopsy)
        {
            string Status = "";
            Status = ObjDALCPCAutopsy.SaveCPCAutopsy(ObjBOLCPCAutopsy);
            return Status;
        }
    }


    public class BLLAutopsyReport
    {
        private DALAutopsyReport ObjDALAutopsyPathologyReport = new DALAutopsyReport();
        public DataSet GetAutopsyPathologyReport(BOLAutopsyReport ObjBOLAutopsyPathologyReport)
        {
            DataSet ds = new DataSet();
            ds = ObjDALAutopsyPathologyReport.GetAutopsyPathologyReport(ObjBOLAutopsyPathologyReport);
            return ds;
        }
        public DataSet GetAutopsyPathologyReportMaxID(BOLAutopsyReport ObjBOLAutopsyPathologyReport)
        {
            DataSet ds = new DataSet();
            ds = ObjDALAutopsyPathologyReport.GetAutopsyPathologyReportMaxID(ObjBOLAutopsyPathologyReport);
            return ds;
        }
        public DataSet GetAutopsyPathologyReportCount(BOLAutopsyReport ObjBOLAutopsyPathologyReport)
        {
            DataSet ds = new DataSet();
            ds = ObjDALAutopsyPathologyReport.GetAutopsyPathologyReportCount(ObjBOLAutopsyPathologyReport);
            return ds;
        }

        public string SaveAutopsyPathologyReport(BOLAutopsyReport ObjBOLAutopsyPathologyReport)
        {
            string Status = "";
            Status = ObjDALAutopsyPathologyReport.SaveAutopsyPathologyReport(ObjBOLAutopsyPathologyReport);
            return Status;
        }
        public String DeleteAutopsyPathologyReport(BOLAutopsyReport ObjBOL)
        {
            string Status = "";
            Status = ObjDALAutopsyPathologyReport.DeleteAutopsyPathologyReport(ObjBOL);
            return Status;
        }

        public DataSet GetAllAutopsyPathologyReport(BOLAutopsyReport ObjBOLAutopsyPathologyReport)
        {
            DataSet ds = new DataSet();
            ds = ObjDALAutopsyPathologyReport.GetAllAutopsyPathologyReport(ObjBOLAutopsyPathologyReport);
            return ds;
        }

        public DataSet SearchAutopsyPathologyReport(BOLAutopsyReport ObjBOLAutopsyPathologyReport)
        {
            DataSet ds = new DataSet();
            ds = ObjDALAutopsyPathologyReport.SearchAutopsyPathologyReport(ObjBOLAutopsyPathologyReport);
            return ds;
        }
    }
    public class BLLCustomerCategoryMaster
    {
        private DALCustomerCategoryMaster ObjDALCustomerCategoryMaster = new DALCustomerCategoryMaster();
        public DataSet GetCustomerCategory(BOLCustomerCategoryMaster ObjBOLCustomerCategoryMaster)
        {
            DataSet ds = new DataSet();
            ds = ObjDALCustomerCategoryMaster.GetCustomerCategory(ObjBOLCustomerCategoryMaster);
            return ds;
        }

        public string SaveCustomerCategory(BOLCustomerCategoryMaster ObjBOLCustomerCategoryMaster)
        {
            string Status = "";
            Status = ObjDALCustomerCategoryMaster.SaveCustomerCategory(ObjBOLCustomerCategoryMaster);
            return Status;
        }
    }

    public class BLLProductMaster
    {
        private DALProductMaster ObjDAL = new DALProductMaster();
        public DataSet GetProducts(BOLProductMaster ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetProducts(ObjBOL);
            return ds;
        }

        public string SaveProduct(BOLProductMaster ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveProduct(ObjBOL);
            return Status;
        }
    }

    public class BLLTrainingDetailMaster
    {
        private DALTrainingDetailMaster ObjDAL = new DALTrainingDetailMaster();
        public DataSet GetTrainingDetail(BOLTrainingDetailMaster ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetTrainingDetail(ObjBOL);
            return ds;
        }

        public string SaveTrainingDetail(BOLTrainingDetailMaster ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveTrainingDetail(ObjBOL);
            return Status;
        }
    }

    public class BLLProductSubtitle
    {
        private DALProductSubtitle ObjDAL = new DALProductSubtitle();
        public DataSet GetProductSubtitle(BOLProductSubtitle ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetProductSubtitle(ObjBOL);
            return ds;
        }

        public string SaveProductSubtitle(BOLProductSubtitle ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveProductSubtitle(ObjBOL);
            return Status;
        }
    }

    public class BLLStateDistCity
    {
        private DALStateDistCity ObjDAL = new DALStateDistCity();

        public DataSet GetCountry(BOLStateDistCity ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetCountry(ObjBOL);
            return ds;
        }

        public DataSet GetState(BOLStateDistCity ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetState(ObjBOL);
            return ds;
        }

        public string SaveState(BOLStateDistCity ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveState(ObjBOL);
            return Status;
        }

        public DataSet GetDistrict(BOLStateDistCity ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetDistrict(ObjBOL);
            return ds;
        }

        public string SaveDistrict(BOLStateDistCity ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveDistrict(ObjBOL);
            return Status;
        }

        public DataSet GetCity(BOLStateDistCity ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetCity(ObjBOL);
            return ds;
        }



        public string SaveCity(BOLStateDistCity ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveCity(ObjBOL);
            return Status;
        }
    }

    public class BLLTopography
    {
        private DALTopography ObjDAL = new DALTopography();
        public DataSet GetTopography(BOLTopography ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetTopography(ObjBOL);
            return ds;
        }

        public string SaveTopography(BOLTopography ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveTopography(ObjBOL);
            return Status;
        }
    }

    public class BLLCategory
    {
        private DALCategory ObjDAL = new DALCategory();
        public DataSet GetCategory(BOLCategory ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetCategory(ObjBOL);
            return ds;
        }

        public string SaveCategory(BOLCategory ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveCategory(ObjBOL);
            return Status;
        }
    }

    public class BLLCategoryType
    {
        private DALCategoryType ObjDAL = new DALCategoryType();
        public DataSet GetCategoryType(BOLCategoryType ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetCategoryType(ObjBOL);
            return ds;
        }

        public string SaveCategoryType(BOLCategoryType ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveCategoryType(ObjBOL);
            return Status;
        }
    }

    public class BLLFaculty
    {
        private DALFaculty ObjDAL = new DALFaculty();
        public DataSet GetFaculty(BOLFaculty ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetFaculty(ObjBOL);
            return ds;
        }

        public string SaveFaculty(BOLFaculty ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveFaculty(ObjBOL);
            return Status;
        }
    }


    public class BLLMorphology
    {
        private DALMorphology ObjDAL = new DALMorphology();
        public DataSet GetMorphology(BOLMorphology ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetMorphology(ObjBOL);
            return ds;
        }

        public string SaveMorphology(BOLMorphology ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveMorphology(ObjBOL);
            return Status;
        }
    }

    public class BLLOrgan
    {
        private DALOrgan ObjDAL = new DALOrgan();
        public DataSet GetOrgan(BOLOrgan ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetOrgan(ObjBOL);
            return ds;
        }

        public string SaveOrgan(BOLOrgan ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveOrgan(ObjBOL);
            return Status;
        }
    }

    public class BLLSufix
    {
        private DALSufix ObjDAL = new DALSufix();
        public DataSet GetSufix(BOLSufix ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Getsufix(ObjBOL);
            return ds;
        }

        public string SaveSufix(BOLSufix ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveSufix(ObjBOL);
            return Status;
        }
    }

    public class BLLPrefix
    {
        private DALPrefix ObjDAL = new DALPrefix();
        public DataSet GetPrefix(BOLPrefix ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetPrefix(ObjBOL);
            return ds;
        }

        public string SavePrefix(BOLPrefix ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SavePrefix(ObjBOL);
            return Status;
        }
    }



    public class BLLRoles
    {
        private DALRoles ObjDAL = new DALRoles();
        public DataSet GetRoles(BOLRoles ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetRoles(ObjBOL);
            return ds;
        }

        public string SaveRoles(BOLRoles ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveRoles(ObjBOL);
            return Status;
        }
    }

    public class BLLManageEmployees
    {
        // this one is for only login
        private DALManageEmployees ObjDAL = new DALManageEmployees();
        public DataSet GetEmployees(BOLManageEmployees ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetEmployees(ObjBOL);
            return ds;
        }

        public string SaveEmployees(BOLManageEmployees ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveEmployees(ObjBOL);
            return Status;
        }

        public DataSet GetEmployee(BOLManageEmployees ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetEmployee(ObjBOL);
            return ds;
        }
    }

    public class BLLManageShipper
    {
        // this one is for only login
        private DALManageShipper ObjDAL = new DALManageShipper();
        public DataSet GetShipper(BOLManageShippers ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetShipper(ObjBOL);
            return ds;
        }

        public string SaveShipper(BOLManageShippers ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveShipper(ObjBOL);
            return Status;
        }

        public string SaveShipperMember(BOLManageShippers ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveShipperMember(ObjBOL);
            return Status;
        }

        public string DeleteShipperMember(BOLManageShippers ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteShipperMember(ObjBOL);
            return Status;
        }
    }

    public class BLLManageGillRegion
    {
        // this one is for only login
        private DALManageGillRegions ObjDAL = new DALManageGillRegions();
        public DataSet GetGillRegion(BOLManageGillRegions ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetGillRegion(ObjBOL);
            return ds;
        }

        public string SaveGillRegion(BOLManageGillRegions ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveGillRegion(ObjBOL);
            return Status;
        }
    }

    public class BLLManageGillTerr
    {
        // this one is for only login
        private DALManageGillTerr ObjDAL = new DALManageGillTerr();
        public DataSet GetGillTerr(BOLManageGillTerr ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetGillTerr(ObjBOL);
            return ds;
        }

        public string SaveGillTerr(BOLManageGillTerr ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveGillTerr(ObjBOL);
            return Status;
        }
    }

    public class BLLManageCity
    {
        // this one is for only login
        private DALManageCity ObjDAL = new DALManageCity();
        public DataSet GetCity(BOLManageCity ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetCity(ObjBOL);
            return ds;
        }

        public string SaveCity(BOLManageCity ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveCity(ObjBOL);
            return Status;
        }

        public DataSet GetTest(BOLManageCity ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetTest(ObjBOL);
            return ds;
        }

        public string SaveTest(BOLManageCity ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveTest(ObjBOL);
            return Status;
        }
    }


    public class BLLManageUserGroup
    {
        // this one is for only login
        private DALManageUserGroup ObjDAL = new DALManageUserGroup();
        public DataSet GetUserGroup(BOLManageUserGroup ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetUserGroup(ObjBOL);
            return ds;
        }

        public string SaveUserGroup(BOLManageUserGroup ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveUserGroup(ObjBOL);
            return Status;
        }
    }

    public class BLLManageState
    {
        // this one is for only login
        private DALManageState ObjDAL = new DALManageState();
        public DataSet GetState(BOLManageState ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetState(ObjBOL);
            return ds;
        }

        public string SaveState(BOLManageState ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveState(ObjBOL);
            return Status;
        }
    }

    public class BLLManageCountry
    {
        // this one is for only login
        private DALManageCountry ObjDAL = new DALManageCountry();
        public DataSet GetCountry(BOLManageCountry ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetCountry(ObjBOL);
            return ds;
        }

        public string SaveCountry(BOLManageCountry ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveCountry(ObjBOL);
            return Status;
        }
    }

    public class BLLManageCompetitor
    {
        // this one is for only login
        private DALManageCompetitor ObjDAL = new DALManageCompetitor();
        public DataSet GetCompetitor(BOLManageCompetitor ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetCompetitor(ObjBOL);
            return ds;
        }

        public string SaveCompetitor(BOLManageCompetitor ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveCompetitor(ObjBOL);
            return Status;
        }
    }

    public class BLLManageCustTitle
    {
        // this one is for only login
        private DALManageCusTitle ObjDAL = new DALManageCusTitle();
        public DataSet GetCompetitor(BOLManageCusTitle ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetCusTitle(ObjBOL);
            return ds;
        }

        public string SaveCustTitle(BOLManageCusTitle ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveCusTitle(ObjBOL);
            return Status;
        }
    }

    public class BLLEmpCode
    {
        private DALEmpCode ObjDAL = new DALEmpCode();
        public String GetNextEmployeeCode()
        {
            String EmpCode = ObjDAL.GetNextEmployeeCode();
            return EmpCode;
        }
    }

    //START BLL 
    //BLLfrmCategory access business logic in frmCategory Page
    public class BLLfrmCategory
    {
        private DALfrmCategory objDAL = new DALfrmCategory();
        public String SaveCategory(BOLfrmCategory objBOL)
        {
            String Status = "";
            Status = objDAL.SaveCategory(objBOL);
            return Status;
        }
        public DataSet GetCategory(BOLfrmCategory objBOL)
        {
            DataSet ds = new DataSet();
            ds = objDAL.GetCategory(objBOL);
            return ds;
        }
    }
    //END BLL

    //START ACTIVE TROY EMPLOYEE FROM BLL
    //MANAGE TROY EMPLOYEE FORM
    public class BLLEmployeeListing
    {
        private DALEMPLOYEELISTING ObjDAL = new DALEMPLOYEELISTING();
        public string SaveEmployeeDetail(BOLEmployeeListing ObjBOL)
        {
            String status = "";
            status = ObjDAL.SaveEmployeeDetail(ObjBOL);
            return status;
        }
        public DataSet GetEmployeeDetail(BOLEmployeeListing ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetEmployeeDetail(ObjBOL);
            return ds;
        }
    }
    //END BLL

    //START REPS AND TROYS BLL

    //Manage Reps and Troy Details
    public class BLLRepsAndTroys
    {
        private DALRepsAndTroy ObjDAL = new DALRepsAndTroy();
        public String SaveRepsDetail(BOLEmployeeListing ObjBOL)
        {
            String status = "";
            status = ObjDAL.SaveRepsDetail(ObjBOL);
            return status;
        }
        public DataSet GetRepsDetail(BOLEmployeeListing ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetRepsDetail(ObjBOL);
            return ds;
        }
    }
    //END BLL

    //BLLSTANDARDPARTS START
    public class BLLStandardParts
    {
        private DALStandardParts ObjDAL = new DALStandardParts();
        public DataSet GetStandardParts(BOLStandardParts ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetStandardParts(ObjBOL);
            return ds;
        }
        public string SaveStandardParts(BOLStandardParts ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveStandardParts(ObjBOL);
            return Status;
        }
        public string DeleteStandardParts(BOLStandardParts ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteStandardParts(ObjBOL);
            return Status;
        }
    }

    //BLL END
    public class BLLBrowseDetail
    {
        private DALBrowseDetail ObjDAL = new DALBrowseDetail();
        public DataSet GetBrowseDetail(BOLBrowseDetail ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetBrowseDetail(ObjBOL);
            return ds;
        }

        public string SaveBrowseDetail(BOLBrowseDetail ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveBrowseDetail(ObjBOL);
            return Status;
        }
    }

    //Start BLL Assign Menu To Groups 
    public class BLLGroupName
    {
        private DALGroupName ObjDAL = new DALGroupName();
        public DataSet GetGroupName(BOLGroupName ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetRightsToGroups(ObjBOL);
            return ds;
        }
        public String SaveGroupDetail(BOLGroupName ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.AssignRightsToGroups(ObjBOL);
            return Status;
        }
    }
    //End Assign Menu To Groups
    //Start BLL Add Users To Groups
    public class BLLAddUsersToGroups
    {
        private DALAddUsersToGroups ObjDAL = new DALAddUsersToGroups();
        public DataSet GetAddUsersGroups(BOLAddUsersToGroups ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetAddUsersToGroups(ObjBOL);
            return ds;
        }
        public String SaveAddUsersGroups(BOLAddUsersToGroups ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveAddUsersToGroups(ObjBOL);
            return Status;
        }
    }
    //End BLL Add Users To Groups

    //Customer Care Repair Form 
    public class BLLManageProjectRepairDetails
    {
        private DALManageCustomerProjectRepairDetails ObjDAL = new DALManageCustomerProjectRepairDetails();
        public DataSet GetProjectRepairDetail(BOLCustCareRepairForm ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetCustCareRepairData(ObjBOL);
            return ds;
        }

        public string GetTicketDetails(BOLCustCareRepairForm ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.GetTicketDetails(ObjBOL);
            return Status;
        }

        public string SaveTicketInformation(BOLCustCareRepairForm ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveCustomerRepairServiceData(ObjBOL);
            return Status;
        }
        public DataSet DisplayTicketInformation(BOLCustCareRepairForm ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.DisplayCustomerRepairServiceData(ObjBOL);
            return ds;
        }

        public DataSet DisplayTicketInformationRowWise(BOLCustCareRepairForm ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.DisplayCustomerRepairServiceDataRowWise(ObjBOL);
            return ds;
        }
        public DataSet DisplayJobInformation(BOLCustCareRepairForm ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.DisplayCustomerRepairJobInformation(ObjBOL);
            return ds;
        }

    }

    //Customer Care ManageTicketsBLL
    public class BLLManageTickets
    {
        private DALManageTickets ObjDAL = new DALManageTickets();
        public DataSet BindDropDownManageTickets(BOLManageTickets ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.BindDropDownManageTickets(ObjBOL);
            return ds;
        }
        public DataSet GetTicketInfo(BOLManageTickets ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetTicketInfo(ObjBOL);
            return ds;
        }

        public DataSet GetTicketSummInfo(BOLManageTickets ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetTicketSummInfo(ObjBOL);
            return ds;
        }
        public string SaveTicketSummary(BOLManageTickets ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveTicketSummary(ObjBOL);
            return Status;
        }
        public string UpdateTicketSummary(BOLManageTickets ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdateTicketSummary(ObjBOL);
            return Status;
        }
    }

    public class BLLWasteEq_New
    {
        private DALWasteEq_New ObjDAL = new DALWasteEq_New();
        public DataSet Return_DataSet(BOLWasteEq_New ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLWasteEq_New objBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(objBOL);
            return Status;
        }

    }

    //BLL Waste Eq Details
    public class BLLManageWasteEqDetails
    {
        private DALManageWasteEqDetails ObjDAL = new DALManageWasteEqDetails();
        public DataSet BindDropDown(BOLWasteEq ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.BindDropDownDetails(ObjBOL);
            return ds;
        }
        public DataSet FillDetails(BOLWasteEq ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.FillDetails(ObjBOL);
            return ds;
        }
        public DataSet GetWasteEq(BOLWasteEq ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetWasteEqAcc(ObjBOL);
            return ds;
        }
        public DataSet GetWasteEquipment(BOLWasteEq ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetWasteEquipment(ObjBOL);
            return ds;
        }
        public string SaveWasteEq(BOLWasteEq ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveWasteEqSummary(ObjBOL);
            return Status;
        }
        public string SaveWasteEqDetails(BOLWasteEq ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveWasteEqDetail(ObjBOL);
            return Status;
        }
    }

    //DAL Stock Adjustments
    public class BLLManageStockAdjustments
    {
        private DALManageStockAdjustment ObjDAL = new DALManageStockAdjustment();
        public DataSet BindDropDown(BOLStockAdjustment ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetStockAdjustmentDropDownData(ObjBOL);
            return ds;
        }
        public string SaveStock(BOLStockAdjustment ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveStockAdjustmentData(ObjBOL);
            return Status;
        }
    }

    public class BLLOpenProposalReportDate
    {
        private DALOpenProposalReports ObjDALOpenProposalReport = new DALOpenProposalReports();
        public DataSet GetOpenProposalReport(BOLOpenProposalReports ObjBOLOpenProposalReport)
        {
            DataSet ds = new DataSet();
            ds = ObjDALOpenProposalReport.GetOpenProposalReportDataSearch(ObjBOLOpenProposalReport);
            return ds;
        }

        public DataSet GetSalesReport(BOLOpenProposalReports ObjBOLOpenProposalReport)
        {
            DataSet ds = new DataSet();
            ds = ObjDALOpenProposalReport.GetSalesReport(ObjBOLOpenProposalReport);
            return ds;
        }
    }

    public class BLLManagePartsMaintainance
    {
        private DALINVParts ObjDAL = new DALINVParts();
        public DataSet GetINVDetails(BOLPartMaintainanace ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetPartsInfo(ObjBOL);
            return ds;
        }
        public string SaveINVParts(BOLPartMaintainanace ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveINVPartsDetail(ObjBOL);
            return Status;
        }
        public string DeleteINVRecord(BOLPartMaintainanace ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteINVParts(ObjBOL);
            return Status;
        }
        //GetINVPartsDetails
        public DataSet GetINVPartsDetails(BOLPartMaintainanace ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetINVPartsDetails(ObjBOL);
            return ds;
        }
    }


    public class BLLINVPartsinfo
    {
        private DALINVPartsInfo ObjDAL = new DALINVPartsInfo();
        public DataSet GetINVPartsInfo(BOLINVPartsInfo ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetINVParts(ObjBOL);
            return ds;
        }
        public string SaveINVPartsInfo(BOLINVPartsInfo ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveINVParts(ObjBOL);
            return Status;
        }
        public string UpdateINVPartsInfo(BOLINVPartsInfo ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdateINVParts(ObjBOL);
            return Status;
        }
        public string DeleteINVPartsInfo(BOLINVPartsInfo ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteINVPartsInfo(ObjBOL);
            return Status;
        }
        public DataSet GetJobs(BOLINVPartsInfo ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetJobs(ObjBOL);
            return ds;
        }
        public string ReleaseProject(BOLINVPartsInfo ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.ReleaseProject(ObjBOL);
            return Status;
        }
        public string StockAdjustment(BOLINVPartsInfo ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.StockAdjustment(ObjBOL);
            return Status;
        }
        public DataSet GetStockAdjustment(BOLINVPartsInfo ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetStockAdjustment(ObjBOL);
            return ds;
        }
        public DataSet GetPartsCount(BOLINVPartsInfo ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetPartsCount(ObjBOL);
            return ds;
        }
        public DataSet CheckWeeklyCount(BOLINVPartsInfo ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.CheckWeeklyCount(ObjBOL);
            return ds;
        }
    }

    public class BLLManageQuotesInfo
    {
        private DALQuotes ObjDAL = new DALQuotes();
        public DataSet GetQuotesInfo(BOLManageQuotes ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetQuotesInfo(ObjBOL);
            return ds;
        }
        public string SaveQuote(BOLManageQuotes ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveQuoteInfoData(ObjBOL);
            return Status;
        }
        //DeleteQuote
        public string DeleteQuote(BOLManageQuotes ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteQuote(ObjBOL);
            return Status;
        }
    }

    public class BLLManageForecasting
    {
        private DALForecasting ObjDAL = new DALForecasting();
        public DataSet GetData(BOLManageForecasting ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetData(ObjBOL);
            return ds;
        }

    }

    public class BLLCustCareTickets
    {
        private DALCustCareTickets ObjDAL = new DALCustCareTickets();
        public DataSet GetControlsData(BOLCustCareTickets ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetControls(ObjBOL);
            return ds;
        }
        public string GetTicketNo(BOLCustCareTickets ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.GetCustCareTicketNo(ObjBOL);
            return Status;
        }
        public string SaveCustTicketRecord(BOLCustCareTickets ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveCustCareTicketDetail(ObjBOL);
            return Status;
        }
        public string SaveCustTicketSumm(BOLCustCareTickets ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveCustCareTicketSummary(ObjBOL);
            return Status;
        }
        //DeleteTicketRecord
        public string DeleteCustTicketSumm(BOLCustCareTickets ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteTicketRecord(ObjBOL);
            return Status;
        }
    }

    public class BLLManageModel
    {
        private DALManageModel ObjDAL = new DALManageModel();
        public DataSet GetModel(BOLManageModel ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetModel(ObjBOL);
            return ds;
        }
        public string SaveModel(BOLManageModel OBjBOL)
        {
            String Status = "";
            Status = ObjDAL.SaveModel(OBjBOL);
            return Status;
        }
    }
    public class BLLManageConveyor
    {
        private DALManageConveyor ObjDAL = new DALManageConveyor();
        public DataSet GetConveyor(BOLManageConveyor ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetConveyor(ObjBOL);
            return ds;
        }
        public string SaveConveyor(BOLManageConveyor ObjBOL)
        {
            String Status = "";
            Status = ObjDAL.SaveConveyor(ObjBOL);
            return Status;
        }
    }

    public class BLLRequisition
    {
        private DALRequisition ObjDAL = new DALRequisition();
        public DataSet GetControlsData(BOLRequisition ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetBindControls(ObjBOL);
            return ds;
        }
        public string GetRequisition(BOLRequisition ObjBOL)
        {
            string msg = "";
            msg = ObjDAL.GetRequisitionNumber(ObjBOL);
            return msg;
        }
        public string CheckApprovedStatus(BOLRequisition ObjBOL)
        {
            string msg = "";
            msg = ObjDAL.CheckApprovedStatus(ObjBOL);
            return msg;
        }
        public string SaveRequisitionData(BOLRequisition ObjBOL)
        {
            string msg = "";
            msg = ObjDAL.SaveRequisition(ObjBOL);
            return msg;
        }
        public string DeleteReqData(BOLRequisition ObjBOL)
        {
            string msg = "";
            msg = ObjDAL.DeleteRequisition(ObjBOL);
            return msg;
        }
        public DataSet GetTransitionData(BOLRequisition ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetTransitionData(ObjBOL);
            return ds;
        }
        public string UpdateIsSubmitted(BOLRequisition ObjBOL)
        {
            string msg = "";
            msg = ObjDAL.UpdateRequisitionIsSubmitted(ObjBOL);
            return msg;
        }
        public DataSet GetPartDetails(BOLRequisition ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetPartDetails(ObjBOL);
            return ds;
        }
        public DataSet GetInShopData(BOLRequisition ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetInShopData(ObjBOL);
            return ds;
        }
        public DataSet GetRequisitionPartno(BOLRequisition ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetRequisitionPartno(ObjBOL);
            return ds;

        }
        public string SavePopUpParts(BOLRequisition ObjBOL)
        {
            string msg = "";
            msg = ObjDAL.SavePopUpParts(ObjBOL);
            return msg;
        }
    }

    public class BLLManageBranchInformation
    {
        private DALManageBranchInformation ObjDAL = new DALManageBranchInformation();
        public DataSet GetBranchInformation(BOLManageBranchInformation ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetBranchInformation(ObjBOL);
            return ds;
        }
        public DataSet GetBranchState(BOLManageBranchInformation ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetBranchState(ObjBOL);
            return ds;
        }
        public string SaveBranchInformation(BOLManageBranchInformation ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveBranchInformation(ObjBOL);
            return Status;
        }
    }

    public class BLLManageShopEmployees
    {
        private DALManageShopEmployees ObjDAL = new DALManageShopEmployees();
        public DataSet GetEmployeeInformation(BOLManageShopEmployees ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetEmployeeInformation(ObjBOL);
            return ds;
        }

        public string SaveShopEmployees(BOLManageShopEmployees ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveShopEmployees(ObjBOL);
            return Status;
        }

        public string UpdateShopEmployees(BOLManageShopEmployees ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdateShopEmployees(ObjBOL);
            return Status;
        }
        public string BLLAddShopEmployeeTraining(BOLManageShopEmployees ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.AddShopEmployeesTraining(ObjBOL);
            return Status;
        }
    }
    public class BLLIssueCategory
    {
        private DALIssueCategory objDAL = new DALIssueCategory();
        public String SaveIssueCategory(BOLIssueCategory objBOL)
        {
            String Status = "";
            Status = objDAL.SaveIssueCategory(objBOL);
            return Status;
        }
        public DataSet GetIssueCategory(BOLIssueCategory objBOL)
        {
            DataSet ds = new DataSet();
            ds = objDAL.GetIssueCategory(objBOL);
            return ds;
        }
    }
    public class BLLCCT_SubAssembly
    {
        private DALCCT_SubAssembly objDAL = new DALCCT_SubAssembly();
        public String SaveCCT_SubAssembly(BOLCCT_SubAssembly objBOL)
        {
            String Status = "";
            Status = objDAL.SaveCCT_SubAssembly(objBOL);
            return Status;
        }
        public DataSet GetCCT_SubAssembly(BOLCCT_SubAssembly objBOL)
        {
            DataSet ds = new DataSet();
            ds = objDAL.GetCCT_SubAssembly(objBOL);
            return ds;
        }
    }
    public class BLLCCT_Category
    {
        private DALCCT_Category objDAL = new DALCCT_Category();
        public String SaveCCT_Category(BOLCCT_Category objBOL)
        {
            String Status = "";
            Status = objDAL.SaveCCT_Category(objBOL);
            return Status;
        }
        public DataSet GetCCT_Category(BOLCCT_Category objBOL)
        {
            DataSet ds = new DataSet();
            ds = objDAL.GetCCT_Category(objBOL);
            return ds;
        }
    }
    public class BLLCCT_IssueReportedBy
    {
        private DALCCT_IssueReportedBy objDAL = new DALCCT_IssueReportedBy();
        public String SaveCCT_IssueReportedBy(BOLCCT_IssueReportedBy objBOL)
        {
            String Status = "";
            Status = objDAL.SaveCCT_IssueReportedBy(objBOL);
            return Status;
        }
        public DataSet GetCCT_IssueReportedBy(BOLCCT_IssueReportedBy objBOL)
        {
            DataSet ds = new DataSet();
            ds = objDAL.GetCCT_IssueReportedBy(objBOL);
            return ds;
        }
    }

    public class BLLCalculateEngHours
    {
        private DALCalculateEngHours ObjDAL = new DALCalculateEngHours();
        public DataSet GetControls(BOLEngHoursCalculate ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.BindControls(ObjBOL);
            return ds;
        }
        public string SaveEngData(BOLEngHoursCalculate ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveEngTime(ObjBOL);
            return Status;
        }
    }
    public class BLLContainer
    {
        private DALContainer ObjDAL = new DALContainer();
        public DataSet GetBindControl(BOLContainer ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetBindControl(ObjBOL);
            return ds;
        }
        public string BLLSaveContainerInfo(BOLContainer ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveContainerInfo(ObjBOL);
            return Status;
        }
    }

    public class BLLContainerNew
    {
        private DALContainerNew ObjDAL = new DALContainerNew();
        public DataSet GetBindControl(BOLContainer ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetBindControl(ObjBOL);
            return ds;
        }
        public string SaveContainerInfo(BOLContainer ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveContainerInfo(ObjBOL);
            return Status;
        }
        public string UpdateStatus(BOLContainer ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdateStatus(ObjBOL);
            return Status;
        }
        public string UpdateContainerStatus(BOLContainer ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdateContainerStatus(ObjBOL);
            return Status;
        }
        public string SaveJobDetails(BOLContainer ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveJobDetails(ObjBOL);
            return Status;
        }
        public string DeleteJobDetails(BOLContainer ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteJobDetails(ObjBOL);
            return Status;
        }
    }


    public class BLLManageDesg
    {
        private DALManageDesg ObjDAL = new DALManageDesg();
        public DataSet GetDesg(BOLManageDesg ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetDesg(ObjBOL);
            return ds;
        }
        public string SaveDesg(BOLManageDesg ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveDesg(ObjBOL);
            return Status;

        }
    }
    public class BLLManageUniv
    {
        private DALManageUniv ObjDAL = new DALManageUniv();
        public DataSet GetUniv(BOLManageUniv ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetUniv(ObjBOL);
            return ds;
        }
        public string SaveUniv(BOLManageUniv ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveUniv(ObjBOL);
            return Status;
        }
    }

    public class BLLCampuses
    {
        private DALCampuses ObjDAL = new DALCampuses();
        public String SaveCampusDetails(BOLCampusListing ObjBOL)
        {
            String status = "";
            status = ObjDAL.SaveCampusDetails(ObjBOL);
            return status;
        }
        public DataSet GetCampusDetails(BOLCampusListing ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetCampusDetails(ObjBOL);
            return ds;
        }
    }

    public class BLLContacts
    {
        private DALContacts ObjDAL = new DALContacts();
        public String SaveContectDetails(BOLContactListing ObjBOL)
        {
            String status = "";
            status = ObjDAL.SaveContectDetails(ObjBOL);
            return status;
        }
        public DataSet GetContectDetails(BOLContactListing ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetContectDetails(ObjBOL);
            return ds;
        }
    }

    public class BLLRepsSearch
    {
        private DALRepSearch ObjDALRepSearch = new DALRepSearch();
        public DataSet GetRepSearch(BOLRepSearch ObjBOLRepSearch)
        {
            DataSet ds = new DataSet();
            ds = ObjDALRepSearch.GetRepSearch(ObjBOLRepSearch);
            return ds;
        }

        public DataSet GetCustomerSearch(BOLRepSearch ObjBOLRepSearch)
        {
            DataSet ds = new DataSet();
            ds = ObjDALRepSearch.GetCustomerSearch(ObjBOLRepSearch);
            return ds;
        }

        public DataSet GetProjects(BOLRepSearch ObjBOLRepSearch)
        {
            DataSet ds = new DataSet();
            ds = ObjDALRepSearch.GetProjects(ObjBOLRepSearch);
            return ds;
        }

    }
    public class BLLGaylordQuote
    {
        private DALGaylordQuote ObjDAL = new DALGaylordQuote();
        public DataSet GetGayQuote(BOLGaylordQuote ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetGaylordQuote(ObjBOL);
            return ds;
        }
        public string GenerateQuote(BOLGaylordQuote ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.GenerateQuote(ObjBOL);
            return Status;
        }
        public string SaveGaylordQuote(BOLGaylordQuote ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveGaylordQuote(ObjBOL);
            return Status;
        }
        public string DeleteGaylordPartinfo(BOLGaylordQuote ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeletePartInfo(ObjBOL);
            return Status;
        }
        public string UpdateGaylordPartinfo(BOLGaylordQuote ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdateGaylordQuote(ObjBOL);
            return Status;
        }
    }

    public class BLLManageShipmentTracker
    {
        private DALShipmentTracker ObjDAL = new DALShipmentTracker();
        public DataSet GetShipmentDetail(BOLShipmentTracker ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetShipmentDetails(ObjBOL);
            return ds;
        }
        public string SaveShipmentDetail(BOLShipmentTracker ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveShipmentDetails(ObjBOL);
            return Status;
        }
        public string SaveShipmentInfoDetail(BOLShipmentTracker ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveShipmentInfoDetails(ObjBOL);
            return Status;
        }
        public string UpdateShipmentInfoDetail(BOLShipmentTracker ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdateShipmentInfoDetails(ObjBOL);
            return Status;
        }
        public string DeleteShipmentInfoDetail(BOLShipmentTracker ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteShipmentInfoDetails(ObjBOL);
            return Status;
        }
        public DataSet GetShipmentReport(BOLShipmentTracker ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetShipmentDetailsReport(ObjBOL);
            return ds;
        }
    }
    public class BLLManageProjectsInfo
    {
        private DALGetProjectInfo ObjDAL = new DALGetProjectInfo();
        public DataSet GetProjectInfo(BOLManageProjectsInfo ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetProjectInfo(ObjBOL);
            return ds;
        }
        public string GenrateJNumber(BOLManageProjectsInfo ObjBOL)
        {
            string jnumber = string.Empty;
            jnumber = ObjDAL.GenrateJNumber(ObjBOL);
            return jnumber;
        }
        public string SaveProjectInfo(BOLManageProjectsInfo ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveProjectInfo(ObjBOL);
            return Status;
        }

        public DataSet GetProjects(BOLManageProjectsInfo ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetProjects(ObjBOL);
            return ds;
        }
    }
    public class BLLManageHobartSalesbyTSM
    {
        private DALManageHobartSalesbyTSM ObjDAL = new DALManageHobartSalesbyTSM();
        public DataSet GetSalesbyTSM(BOLHobartSalesbyTSM ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetSalesTSM(ObjBOL);
            return ds;
        }
    }
    public class BLLStockIn
    {
        private DALStockIn ObjDAL = new DALStockIn();
        public DataSet GetBindControl(BOLContainer ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetBindControl(ObjBOL);
            return ds;
        }

        private DALStockIn objDAL = new DALStockIn();
        public String StockIn(BOLContainer objBOL)
        {
            String Status = "";
            Status = objDAL.StockIN(objBOL);
            return Status;
        }

    }

    public class BLLManageSerProjects
    {
        private DALManageSerProjcts ObjDAL = new DALManageSerProjcts();
        public string GetSerProjects(BOLSerProjects ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.GetServiceProjects(ObjBOL);
            return Status;
        }
        public DataSet GetSerProjectsControls(BOLSerProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetSerProjectsControls(ObjBOL);
            return ds;
        }
        public string SaveSerProjects(BOLSerProjects ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveSerProjects(ObjBOL);
            return Status;
        }
    }



    public class BLLManageSerProposals
    {
        private DALManageSerProposals ObjDAL = new DALManageSerProposals();
        public string GetSerProposals(BOLSerProposals ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.GetServiceProposals(ObjBOL);
            return Status;
        }
        public DataSet GetSerProposalsControls(BOLSerProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetSerProposalsControls(ObjBOL);
            return ds;
        }
        public string SaveSerProposals(BOLSerProposals ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveSerProposals(ObjBOL);
            return Status;
        }
        public string DeleteSerProposals(BOLSerProposals ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteSerProposals(ObjBOL);
            return Status;
        }
        //UpdateSerProposalDetail
        public string UpdateSerProposalDetail(BOLSerProposals ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdateSerProposalDetail(ObjBOL);
            return Status;
        }
        public DataSet GetSerProposalsSearch(BOLSerProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetSerProposalsSearch(ObjBOL);
            return ds;
        }
    }

    public class BLLManageRepGroup
    {
        // this one is for only login
        private DALManageRepGroup ObjDAL = new DALManageRepGroup();
        public DataSet GetRepGroup(BOLManageRepGroup ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetRepGroup(ObjBOL);
            return ds;
        }

        public string SaveRepGroup(BOLManageRepGroup ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveRepGroup(ObjBOL);
            return Status;
        }
    }

    public class BLLModel
    {
        private DALModel ObjDAL = new DALModel();
        public DataSet GetModelData(BOLModel ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetBindControls(ObjBOL);
            return ds;
        }
        public DataSet GetSubModel(BOLModel ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetModelName(ObjBOL);
            return ds;
        }
        public string SaveModel(BOLModel ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveModel(ObjBOL);
            return Status;
        }
    }

    public class BLLSchedule
    {
        private DALSchedule objDAL = new DALSchedule();
        public DataSet GetScheduleData(BOLSchedule ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = objDAL.GetBindControls(ObjBOL);
            return ds;
        }
        public DataSet GetSchedule(BOLSchedule ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = objDAL.GetSchedule(ObjBOL);
            return ds;
        }
        public string SaveSchedule(BOLSchedule ObjBOL)
        {
            string Status = "";
            Status = objDAL.SaveSchedule(ObjBOL);
            return Status;
        }

    }

    public class BLLScheduleDetails
    {
        private DALScheduleDetails objDAL = new DALScheduleDetails();
        public DataSet GetScheduleDetails(BOLScheduleDetails ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = objDAL.GetScheduleDetails(ObjBOL);
            return ds;
        }
        public string SaveScheduleDetails(BOLScheduleDetails ObjBOL)
        {
            string Status = "";
            Status = objDAL.SaveScheduleDetails(ObjBOL);
            return Status;
        }
        public String DeleteScheduleDetails(BOLScheduleDetails ObjBOL)
        {
            string Status = "";
            Status = objDAL.DeleteScheduleDetails(ObjBOL);
            return Status;
        }
    }

    public class BLLServiceSchedule
    {
        private DALServiceSchedule ObjDAL = new DALServiceSchedule();
        public DataSet GetControlsData(BOLServiceSchedule ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.BindDropDowns(ObjBOL);
            return ds;
        }

        public string GetTicketNo(BOLServiceSchedule ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.GetPackInfo(ObjBOL);
            return Status;
        }

        public string SavePack(BOLServiceSchedule ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SavePack(ObjBOL);
            return Status;
        }

        public string SavePackInfo(BOLServiceSchedule ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SavePackInfo(ObjBOL);
            return Status;
        }

        public string SaveCustTicketRecord(BOLServiceSchedule ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SavePacktSummary(ObjBOL);
            return Status;
        }
        public DataSet GetDataSet(BOLServiceSchedule ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetDataSet(ObjBOL);
            return ds;
        }
        //DeleteTicketRecord


        public string DeletePackNoDetail(BOLServiceSchedule ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeletePackNoDetail(ObjBOL);
            return Status;
        }
    }
    public class BLLPurchaseOrder
    {
        private DALPurchaseOrder ObjDAL = new DALPurchaseOrder();
        public DataSet GetBindControl(BOLPurchaseOrder ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetBindControl(ObjBOL);
            return ds;
        }

        public string SavePurchaseOrderInfo(BOLPurchaseOrder ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SavePurchaseOrderInfo(ObjBOL);
            return Status;
        }

        public string UpdateStatus(BOLPurchaseOrder ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdateStatus(ObjBOL);
            return Status;
        }

        public string UpdatePurchaseOrderStatus(BOLPurchaseOrder ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdatePurchaseOrderStatus(ObjBOL);
            return Status;
        }
    }

    public class BLLPurchaseOrderManual
    {
        private DALPurchaseOrderManual ObjDAL = new DALPurchaseOrderManual();
        //GetTransitionData
        public DataSet GetTransitionData(BOLPurchaseOrder ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetTransitionData(ObjBOL);
            return ds;
        }
        public DataSet GetInStockData(BOLPurchaseOrder ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetInStockData(ObjBOL);
            return ds;
        }
        public DataSet GetBindControl(BOLPurchaseOrder ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetBindControl(ObjBOL);
            return ds;
        }

        public string SavePurchaseOrderInfo(BOLPurchaseOrder ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SavePurchaseOrderInfo(ObjBOL);
            return Status;
        }

        public string SavePurchaseOrderInfoAndDetail(BOLPurchaseOrder ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SavePurchaseOrderInfoAndDetail(ObjBOL);
            return Status;
        }

        public string UpdateStatus(BOLPurchaseOrder ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdateStatus(ObjBOL);
            return Status;
        }

        public string UpdatePurchaseOrderStatus(BOLPurchaseOrder ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdatePurchaseOrderStatus(ObjBOL);
            return Status;
        }

        public string GetPurchaseOrderNumber(BOLPurchaseOrder ObjBOL)
        {
            string msg = "";
            msg = ObjDAL.GetPurchaseOrderNumber(ObjBOL);
            return msg;
        }
        public DataSet GetInShopData(BOLPurchaseOrder ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetInShopData(ObjBOL);
            return ds;
        }
    }

    public class BLLVendorMaintenance
    {
        private DALVendorMaintenance ObjDAL = new DALVendorMaintenance();

        public DataSet Return_DataSet(BOLVendorMaintenance ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public string Return_String(BOLVendorMaintenance ObjBOL)
        {
            string status = "";
            status = ObjDAL.Return_String(ObjBOL);
            return status;
        }
    }
    public class BLLRegions
    {
        private DALRegions objDAL = new DALRegions();

        public DataSet BindControls(BOLRegions objBOL)
        {
            DataSet ds = new DataSet();
            ds = objDAL.BindControls(objBOL);
            return ds;
        }

        public string SaveAndUpdate(BOLRegions objBOL)
        {
            string status = "";
            status = objDAL.SaveAndUpdate(objBOL);
            return status;
        }
    }

    public class BLL_ITWProjects
    {
        private DAL_ITWProjects objDAL = new DAL_ITWProjects();

        public DataSet BindControls(BOL_ITWProjects objBOL)
        {
            DataSet ds = new DataSet();
            ds = objDAL.BindControls(objBOL);
            return ds;
        }

        public string SaveAndUpdate(BOL_ITWProjects objBOL)
        {
            string status = "";
            status = objDAL.SaveAndUpdate(objBOL);
            return status;
        }
    }

    public class BLLManageReps
    {
        private DALManageReps ObjDAL = new DALManageReps();
        public DataSet GetBranchInformation(BOLManageReps ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetBranchInformation(ObjBOL);
            return ds;
        }
        public DataSet GetControls(BOLManageReps ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetControls(ObjBOL);
            return ds;
        }
        public string SaveAndUpdate(BOLManageReps ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveAndUpdate(ObjBOL);
            return Status;
        }
    }
    public class BLLPreventativeMaintenanceCallLogs
    {
        private DALPreventativeMaintenanceCallLogs ObjDAL = new DALPreventativeMaintenanceCallLogs();
        public DataSet Return_DataSet(BOLPreventativeMaintenanceCallLogs ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLPreventativeMaintenanceCallLogs objBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(objBOL);
            return Status;
        }
    }

    public class BLLPreventiveMaintenance
    {
        private DALPreventiveMaintenance ObjDAL = new DALPreventiveMaintenance();

        public DataSet GetInformation(BOLPreventiveMaintenance ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetInformation(ObjBOL);
            return ds;
        }
        public DataSet GetControls(BOLPreventiveMaintenance ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetControls(ObjBOL);
            return ds;
        }
        public string SaveAndUpdate(BOLPreventiveMaintenance ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveAndUpdate(ObjBOL);
            return Status;
        }
    }

    public class BLLAeroInvoice
    {
        private DALAeroInvoice ObjDAL = new DALAeroInvoice();
        public DataSet GetReportData(BOLAeroInvoice ObjBOL)
        {
            DataSet ds = ObjDAL.GetReportData(ObjBOL);
            return ds;
        }
    }

    public class BLLManageSearchContainer
    {
        private DALManageSearchContainer ObjDAL = new DALManageSearchContainer();
        public DataSet GetSearchContainerData(BOLSearchContainer ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetSearchRecords(ObjBOL);
            return ds;
        }
        public string DeletePO(BOLSearchContainer ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeletePOData(ObjBOL);
            return Status;
        }
    }

    public class BLLDailyCADReport
    {
        private DALDailyCADReport ObjDAL = new DALDailyCADReport();

        public DataSet GetInformation(BOLDailyCADReport ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetInformation(ObjBOL);
            return ds;
        }
        public DataSet GetControls(BOLDailyCADReport ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetControls(ObjBOL);
            return ds;
        }
        public string SaveAndUpdate(BOLDailyCADReport ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveAndUpdate(ObjBOL);
            return Status;
        }
        public DataSet BindReport(BOLDailyCADReport ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.BindReport(ObjBOL);
            return ds;
        }
    }

    public class BLLManageSearchPO
    {
        private DALManageSearchPO ObjDAL = new DALManageSearchPO();
        public DataSet GetSearchPOData(BOLSearchPO ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetSearchRecords(ObjBOL);
            return ds;
        }
        public DataSet GetSearchPODataReport(BOLSearchPO ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetSearchReportData(ObjBOL);
            return ds;
        }
    }

    public class BLLManagePartWiseDetail
    {
        private DALManagePartWiseDetail ObjDAL = new DALManagePartWiseDetail();
        public DataSet GetPartDetails(BOLPartWiseDetails ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetPartDetails(ObjBOL);
            return ds;
        }
    }

    public class BLLManageInboundInpectionSummary
    {
        private DALManageInboundInspectionSummary ObjDAL = new DALManageInboundInspectionSummary();
        public DataSet GetInboundInspectionSummaryDetails(BOLInboundInspectionSummary ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetInboundInspectionSummaryDetails(ObjBOL);
            return ds;
        }
        public string SaveSummaryDetails(BOLInboundInspectionSummary ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveSummaryDetails(ObjBOL);
            return Status;
        }
        //DeleteDetails
        public string DeleteDetails(BOLInboundInspectionSummary ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteDetails(ObjBOL);
            return Status;
        }
    }

    public class BLLDailyQuoteReport
    {
        private DALDailyQuoteReport ObjDAL = new DALDailyQuoteReport();

        public DataSet GetDataSet(BOLDailyQuoteReport ObjBOL)
        {
            DataSet ds = ObjDAL.GetDataset(ObjBOL);
            return ds;
        }

        public string GetString(BOLDailyQuoteReport ObjBOL)
        {
            return ObjDAL.GetString(ObjBOL);
        }

        public DataSet BindReport(BOLDailyQuoteReport ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.BindReport(ObjBOL);
            return ds;
        }
    }

    public class BLLForecastingSubParts
    {
        private DALForecastingSubParts ObjDAL = new DALForecastingSubParts();
        public DataSet Return_DataSet(BOLForecastingSubParts ObjBOL)
        {
            DataSet ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }
    }

    public class BLLPrepareContainerNew
    {
        private DALPrepareContainerNew ObjDAL = new DALPrepareContainerNew();
        public DataSet GetBindControl(BOLPrepareContainer ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetBindControl(ObjBOL);
            return ds;
        }
        public string SaveContainerInfo(BOLPrepareContainer ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveContainerInfo(ObjBOL);
            return Status;
        }
        public string CheckContainerStatus(BOLPrepareContainer ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.CheckContainerStatus(ObjBOL);
            return Status;
        }
        public string UpdateStatus(BOLPrepareContainer ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdateStatus(ObjBOL);
            return Status;
        }
        public string UpdateContainerStatus(BOLPrepareContainer ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdateContainerStatus(ObjBOL);
            return Status;
        }
        public string SaveJobDetails(BOLPrepareContainer ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveJobDetails(ObjBOL);
            return Status;
        }
        public string DeleteJobDetails(BOLPrepareContainer ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteJobDetails(ObjBOL);
            return Status;
        }
    }

    #region CADDY BLL

    public class BLLManageCADDYENGTasks
    {
        private DALManageCADDYENGTasks ObjDAL = new DALManageCADDYENGTasks();
        public DataSet GetControls(BOLCADDYENGTasks ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetControls(ObjBOL);
            return ds;
        }
        public DataSet GetJobNo(BOLCADDYENGTasks ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetCADDYJobNumber(ObjBOL);
            return ds;
        }
        //GetJobName
        public DataSet GetJobName(BOLCADDYENGTasks ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetCADDYJobName(ObjBOL);
            return ds;
        }
        public DataSet AutoFillProjectInfo(BOLCADDYENGTasks ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.AutoFillProjectInfo(ObjBOL);
            return ds;
        }
        public string SaveEngTaskDetails(BOLCADDYENGTasks ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveEngTaskDetails(ObjBOL);
            return Status;
        }
        //DeleteTaskDetails
        public string DeleteTaskDetails(BOLCADDYENGTasks ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteTaskDetails(ObjBOL);
            return Status;
        }
        //CheckPermission
        public string CheckPermission(BOLCADDYENGTasks ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.CheckPermission(ObjBOL);
            return Status;
        }
        public DataSet GetFilterData(BOLCADDYENGTasks ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetFilterData(ObjBOL);
            return ds;
        }
    }

    public class BLLManageCADDYProjectInfo
    {
        private DALManageCADDYProjectInfo ObjDAL = new DALManageCADDYProjectInfo();
        public DataSet GetControls(BOLCADDYProjectInfo ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetControls(ObjBOL);
            return ds;
        }
        //SaveProjectInfo
        public string SaveProjectInfo(BOLCADDYProjectInfo ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveProjectInfo(ObjBOL);
            return Status;
        }
        public string SaveModels(BOLCADDYProjectInfo ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveModelInfo(ObjBOL);
            return Status;
        }
        public DataSet BindModelsDescriptionToolTip(BOLCADDYProjectInfo ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.BindModelsDescriptionToolTip(ObjBOL);
            return ds;
        }
        public DataSet BindConveyorDescriptionToolTip(BOLCADDYProjectInfo ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.BindConveyorDescriptionToolTip(ObjBOL);
            return ds;
        }
        public string CheckProjectType(BOLCADDYProjectInfo ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.CheckProjectType(ObjBOL);
            return Status;
        }
        //GetControlsModels
        public DataSet GetControlsModels(BOLCADDYProjectInfo ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.BindModels(ObjBOL);
            return ds;
        }
    }

    #endregion

    public class BLLStockIn_New
    {
        private DALStockIn_New ObjDAL = new DALStockIn_New();
        public DataSet Return_DataSet(BOLStockIn_New ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLStockIn_New objBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(objBOL);
            return Status;
        }

        public String UploadPackingList(BOLStockIn_New objBOL)
        {
            String Status = "";
            Status = ObjDAL.UploadPackingList(objBOL);
            return Status;
        }

    }

    // TW START

    public class BLLTurboWashPart
    {
        private DALTurboWashPart ObjDAL = new DALTurboWashPart();
        public DataSet GetDataSet(BOLTurboWashPart ObjBOL)
        {
            DataSet ds = ObjDAL.GetDataSet(ObjBOL);
            return ds;
        }

        public string GetString(BOLTurboWashPart ObjBOL)
        {
            return ObjDAL.GetString(ObjBOL);
        }
    }

    public class BLLTurboWashTransaction
    {
        private DALTurboWashTransaction ObjDAL = new DALTurboWashTransaction();
        public DataSet GetDataSet(BOLTurboWashTransaction ObjBOL)
        {
            DataSet ds = ObjDAL.GetDataSet(ObjBOL);
            return ds;
        }

        public string GetString(BOLTurboWashTransaction ObjBOL)
        {
            return ObjDAL.GetString(ObjBOL);
        }
    }


    // TW END

    public class BLLMiscellaneousTasks
    {
        private DALMiscellaneousTasks ObjDAL = new DALMiscellaneousTasks();
        public DataSet Return_DataSet(BOLMiscellaneousTasks ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLMiscellaneousTasks objBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(objBOL);
            return Status;
        }

    }

    public class BLLUserOTP
    {
        private DALUserOTP ObjDALUserOTP = new DALUserOTP();
        public String SaveDataShpDrg(BOLUserOTP ObjBOLUserOTP)
        {
            string Status = "";
            Status = ObjDALUserOTP.SaveDataUserOTP(ObjBOLUserOTP);
            return Status;
        }
    }

    public class BLLINVPartsinfo_CAD
    {
        private DALINVPartsInfo_CAD ObjDAL = new DALINVPartsInfo_CAD();
        public DataSet GetINVPartsInfo(BOLINVPartsInfo ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetINVParts(ObjBOL);
            return ds;
        }
        public string SaveINVPartsInfo(BOLINVPartsInfo ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.SaveINVParts(ObjBOL);
            return Status;
        }
        public string UpdateINVPartsInfo(BOLINVPartsInfo ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.UpdateINVParts(ObjBOL);
            return Status;
        }
        public string DeleteINVPartsInfo(BOLINVPartsInfo ObjBOL)
        {
            string Status = "";
            Status = ObjDAL.DeleteINVPartsInfo(ObjBOL);
            return Status;
        }
        public DataSet GetPartsCount(BOLINVPartsInfo ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetPartsCount(ObjBOL);
            return ds;
        }
    }

    public class BLLManageProductLine
    {
        private DALManageProductLine ObjDAL = new DALManageProductLine();
        public DataSet GetBindControls(BOLManageProductLine ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.GetBindControls(ObjBOL);
            return ds;
        }
        public String SaveProductLine(BOLManageProductLine objBOL)
        {
            String Status = "";
            Status = ObjDAL.SaveProductLine(objBOL);
            return Status;
        }
    }

    public class BLLManageITWProjects
    {
        private DALManageITWProjects ObjDAL = new DALManageITWProjects();
        public DataSet Return_DataSet(BOLManageITWProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLManageITWProjects objBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(objBOL);
            return Status;
        }
    }

    public class BLLManageITWProjectParts
    {
        private DALManageITWProjectParts ObjDAL = new DALManageITWProjectParts();
        public DataSet Return_DataSet(BOLManageITWProjectParts ObjBOL)
        {
            DataSet ds = new DataSet();
            ds = ObjDAL.Return_DataSet(ObjBOL);
            return ds;
        }

        public String Return_String(BOLManageITWProjectParts objBOL)
        {
            String Status = "";
            Status = ObjDAL.Return_String(objBOL);
            return Status;
        }
    }
}