using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using BOLAERO;
using Microsoft.ApplicationBlocks.Data1;
/// <summary>
/// Summary description for DALKGPRO
/// </summary>
///

namespace DALAERO
{
    public class DALProjectsFabricationAndNestingTasks : Connection
    {
        public DataSet Return_DataSet(BOLProjectsFabricationAndNestingTasks ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@JobId", ObjBOL.JobId);
            param[2] = new SqlParameter("@TaskNumber", ObjBOL.TaskNumber);
            param[3] = new SqlParameter("@NatureOfTask", ObjBOL.NatureOfTask);
            param[4] = new SqlParameter("@ReleaseType", ObjBOL.ReleaseType);
            param[5] = new SqlParameter("@ProjectDesigner", ObjBOL.ProjectDesigner);
            param[6] = new SqlParameter("@StartDate", ObjBOL.StartDate);
            param[7] = new SqlParameter("@EndDate", ObjBOL.EndDate);
            param[8] = new SqlParameter("@ReviewedBy", ObjBOL.ReviewedBy);
            param[9] = new SqlParameter("@AssignedFrom", ObjBOL.AssignedFrom);
            param[10] = new SqlParameter("@TaskType", ObjBOL.TaskType);
            param[11] = new SqlParameter("@ProjectEngineer", ObjBOL.ProjectEngineer);
            param[12] = new SqlParameter("@SentDate", ObjBOL.SentDate);
            param[13] = new SqlParameter("@Status", ObjBOL.Status);
            param[14] = new SqlParameter("@Id", ObjBOL.ID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ForecastingAndNestingTasks]", param);
            return ds;
        }

        public string Return_String(BOLProjectsFabricationAndNestingTasks ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@JobId", ObjBOL.JobId);
            param[3] = new SqlParameter("@TaskNumber", ObjBOL.TaskNumber);
            param[4] = new SqlParameter("@NatureOfTask", ObjBOL.NatureOfTask);
            param[5] = new SqlParameter("@ReleaseType", ObjBOL.ReleaseType);
            param[6] = new SqlParameter("@ProjectDesigner", ObjBOL.ProjectDesigner);
            param[7] = new SqlParameter("@StartDate", ObjBOL.StartDate);
            param[8] = new SqlParameter("@EndDate", ObjBOL.EndDate);
            param[9] = new SqlParameter("@ReviewedBy", ObjBOL.ReviewedBy);
            param[10] = new SqlParameter("@AssignedFrom", ObjBOL.AssignedFrom);
            param[11] = new SqlParameter("@TaskType", ObjBOL.TaskType);
            param[12] = new SqlParameter("@ProjectEngineer", ObjBOL.ProjectEngineer);
            param[13] = new SqlParameter("@SentDate", ObjBOL.SentDate);
            param[14] = new SqlParameter("@Status", ObjBOL.Status);
            param[15] = new SqlParameter("@Id", ObjBOL.ID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ForecastingAndNestingTasks]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALSalesOpportunity : Connection
    {
        public DataSet Return_DataSet(BOLSalesOpportunity ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@SalesOpportunity", ObjBOL.SalesOpportunity);
            param[2] = new SqlParameter("@SalesOpportunityStatus", ObjBOL.SalesOpportunityStatus);
            param[3] = new SqlParameter("@FromDate", ObjBOL.FromDate);
            param[4] = new SqlParameter("@ToDate", ObjBOL.ToDate);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Get_SalesOpportunity]", param);
            return ds;
        }
    }

    public class DALShippingHistory : Connection
    {
        public DataSet Return_DataSet(BOLShippingHistory ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@CountryId", ObjBOL.CountryId);
            param[2] = new SqlParameter("@StateId", ObjBOL.StateId);
            param[3] = new SqlParameter("@City", ObjBOL.City);
            param[4] = new SqlParameter("@FromDate", ObjBOL.FromDate);
            param[5] = new SqlParameter("@ToDate", ObjBOL.ToDate);
            param[5] = new SqlParameter("@IndustryId", ObjBOL.IndustryId);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Get_ShippingHistory]", param);
            return ds;
        }
    }

    public class DALYTDQuotesData : Connection
    {
        public DataSet ReturnDataSet(BOLQuotesandOrders ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Get_DashboardReports]", param);
            return ds;
        }
    }

    public class DALShopDrawingCategory : Connection
    {
        public DataSet Return_DataSet(BOLShopDrawingCategory ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@Id", ObjBOL.ID);
            param[2] = new SqlParameter("@Category", ObjBOL.Category);
            param[3] = new SqlParameter("@Active", ObjBOL.Active);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ShopDwgIssueLogs_Category]", param);
            return ds;
        }

        public string Return_String(BOLShopDrawingCategory ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Id", ObjBOL.ID);
            param[3] = new SqlParameter("@Category", ObjBOL.Category);
            param[4] = new SqlParameter("@Active", ObjBOL.Active);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ShopDwgIssueLogs_Category]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALShopDrawingImpact : Connection
    {
        public DataSet Return_DataSet(BOLShopDrawingImpact ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@Id", ObjBOL.ID);
            param[2] = new SqlParameter("@Impact", ObjBOL.Impact);
            param[3] = new SqlParameter("@Active", ObjBOL.Active);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ShopDwgIssueLogs_Impact]", param);
            return ds;
        }

        public string Return_String(BOLShopDrawingImpact ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Id", ObjBOL.ID);
            param[3] = new SqlParameter("@Impact", ObjBOL.Impact);
            param[4] = new SqlParameter("@Active", ObjBOL.Active);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ShopDwgIssueLogs_Impact]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALShopDwgIssueLog : Connection
    {
        public DataSet Return_DataSet(BOLManageShopDwgIssueLog ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@IssueNo", ObjBOL.IssueNo);
            param[2] = new SqlParameter("@JobId", ObjBOL.JobId);
            param[3] = new SqlParameter("@DateIdentified", ObjBOL.DateIdentified);
            param[4] = new SqlParameter("@ID", ObjBOL.Id);
            param[5] = new SqlParameter("@IssueDescription", ObjBOL.IssueDescription);
            param[6] = new SqlParameter("@RootCause", ObjBOL.RootCause);
            param[7] = new SqlParameter("@ImpactId", ObjBOL.ImpactId);
            param[8] = new SqlParameter("@CategoryId", ObjBOL.CategoryId);
            param[9] = new SqlParameter("@InitialActionTaken", ObjBOL.InitialActionTaken);
            param[10] = new SqlParameter("@CorrectiveAction", ObjBOL.CorrectiveAction);
            param[11] = new SqlParameter("@PreventiveAction", ObjBOL.PreventiveAction);
            param[12] = new SqlParameter("@ResponsiblePerson", ObjBOL.ResponsiblePerson);
            param[13] = new SqlParameter("@VerificationDate", ObjBOL.VerificationDate);
            param[14] = new SqlParameter("@VerificationOutcomeId", ObjBOL.VerificationOutcomeId);
            param[15] = new SqlParameter("@FollowupRequired", ObjBOL.FollowupRequired);
            param[16] = new SqlParameter("@FollowupDate", ObjBOL.FollowupDate);
            param[17] = new SqlParameter("@Comments", ObjBOL.Comments);
            param[18] = new SqlParameter("@StatusId", ObjBOL.StatusId);
            param[19] = new SqlParameter("@GroupBy", ObjBOL.GroupBy);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ShopDwgIssueLogs]", param);
            return ds;
        }

        public string Return_String(BOLManageShopDwgIssueLog ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@IssueNo", ObjBOL.IssueNo);
            param[3] = new SqlParameter("@JobId", ObjBOL.JobId);
            param[4] = new SqlParameter("@DateIdentified", ObjBOL.DateIdentified);
            param[5] = new SqlParameter("@ID", ObjBOL.Id);
            param[6] = new SqlParameter("@IssueDescription", ObjBOL.IssueDescription);
            param[7] = new SqlParameter("@RootCause", ObjBOL.RootCause);
            param[8] = new SqlParameter("@ImpactId", ObjBOL.ImpactId);
            param[9] = new SqlParameter("@CategoryId", ObjBOL.CategoryId);
            param[10] = new SqlParameter("@InitialActionTaken", ObjBOL.InitialActionTaken);
            param[11] = new SqlParameter("@CorrectiveAction", ObjBOL.CorrectiveAction);
            param[12] = new SqlParameter("@PreventiveAction", ObjBOL.PreventiveAction);
            param[13] = new SqlParameter("@ResponsiblePerson", ObjBOL.ResponsiblePerson);
            param[14] = new SqlParameter("@VerificationDate", ObjBOL.VerificationDate);
            param[15] = new SqlParameter("@VerificationOutcomeId", ObjBOL.VerificationOutcomeId);
            param[16] = new SqlParameter("@FollowupRequired", ObjBOL.FollowupRequired);
            param[17] = new SqlParameter("@FollowupDate", ObjBOL.FollowupDate);
            param[18] = new SqlParameter("@Comments", ObjBOL.Comments);
            param[19] = new SqlParameter("@StatusId", ObjBOL.StatusId);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ShopDwgIssueLogs]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    //DALManageDealerRebate
    public class DALManageDealerRebate : Connection
    {
        public DataSet GetControls(BOLManageDealersRebate ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@DealerID", ObjBOL.DealerID);
            param[2] = new SqlParameter("@DealerRebateID", ObjBOL.DealerRebateID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManageDealerRebate]", param);
            return ds;
        }
        public string SaveRebate(BOLManageDealersRebate ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@DealerID", ObjBOL.DealerID);
            param[3] = new SqlParameter("@SalesFrom", ObjBOL.SalesFrom);
            param[4] = new SqlParameter("@SalesTo", ObjBOL.SalesTo);
            param[5] = new SqlParameter("@Percent", ObjBOL.Percent);
            param[6] = new SqlParameter("@EffectiveDate", ObjBOL.EffectiveDate);
            param[7] = new SqlParameter("@Calculated", ObjBOL.Calculated);
            param[8] = new SqlParameter("@DealerRebateID", ObjBOL.DealerRebateID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ManageDealerRebate]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }


    public class DALManageCompanyOfficeDepartment : Connection
    {
        public DataSet Returen_DS(BOLManageCompanyOfficeDepartment ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@OfficeID", ObjBOL.OfficeID);
            param[2] = new SqlParameter("@DepartmentID", ObjBOL.DepartmentID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManageCompanyOfficeDepartment]", param);
            return ds;
        }
        public string SaveCompanyOfficeDepartment(BOLManageCompanyOfficeDepartment ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@OfficeID", ObjBOL.OfficeID);
            param[3] = new SqlParameter("@DepartmentID", ObjBOL.DepartmentID);
            param[4] = new SqlParameter("@Department", ObjBOL.Department);
            param[5] = new SqlParameter("@IsActive", ObjBOL.IsActive);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ManageCompanyOfficeDepartment]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }



    public class DALManageExtensions : Connection
    {
        public DataSet Return_DataSet(BOLManageExtensions ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@SearchVar", ObjBOL.SearchVar);
            param[2] = new SqlParameter("@EmployeeDetailID", ObjBOL.EmployeeDetailID);
            param[3] = new SqlParameter("@CompanyID", ObjBOL.CompanyID);
            param[4] = new SqlParameter("@CompanyOfficeID", ObjBOL.CompanyOfficeID);
            param[5] = new SqlParameter("@CompanyOfficeDepartmentID", ObjBOL.CompanyOfficeDepartmentID);
            param[6] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Get_Extensions]", param);
            return ds;
        }
    }

    public class DALITWSize : Connection
    {
        public DataSet Return_DataSet(BOLITWSize ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@Category", ObjBOL.Category);
            param[2] = new SqlParameter("@Active", ObjBOL.Active);
            param[3] = new SqlParameter("@ID", ObjBOL.ID);
            param[4] = new SqlParameter("@Size", ObjBOL.Size);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[TW_ManageSize]", param);
            return ds;
        }

        public string Return_String(BOLITWSize ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Category", ObjBOL.Category);
            param[3] = new SqlParameter("@Active", ObjBOL.Active);
            param[4] = new SqlParameter("@ID", ObjBOL.ID);
            param[5] = new SqlParameter("@Size", ObjBOL.Size);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[TW_ManageSize]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALITWCategory : Connection
    {
        public DataSet Return_DataSet(BOLITWCategory ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@Category", ObjBOL.Category);
            param[2] = new SqlParameter("@OptionsApplicable", ObjBOL.OptionsApplicable);
            param[3] = new SqlParameter("@ID", ObjBOL.ID);
            param[4] = new SqlParameter("@Active", ObjBOL.Active);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[TW_ManageCategory]", param);
            return ds;
        }

        public string Return_String(BOLITWCategory ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Category", ObjBOL.Category);
            param[3] = new SqlParameter("@OptionsApplicable", ObjBOL.OptionsApplicable);
            param[4] = new SqlParameter("@ID", ObjBOL.ID);
            param[5] = new SqlParameter("@Active", ObjBOL.Active);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[TW_ManageCategory]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    //DALExtensions
    public class DALExtensions : Connection
    {
        public DataSet Return_DataSet(BOLExtensions ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@OfficeID", ObjBOL.OfficeID);
            param[2] = new SqlParameter("@DepartmentID", ObjBOL.DepartmentID);
            param[3] = new SqlParameter("@EmployeeDetailID", ObjBOL.EmployeeDetailID);
            param[4] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[5] = new SqlParameter("@CompanyID", ObjBOL.CompanyID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManageOfficeExtensions]", param);
            return ds;
        }
        public string Return_String(BOLExtensions ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@EmployeeDetailID", ObjBOL.EmployeeDetailID);
            param[3] = new SqlParameter("@CompanyID", ObjBOL.CompanyID);
            param[4] = new SqlParameter("@OfficeID", ObjBOL.OfficeID);
            param[5] = new SqlParameter("@DepartmentID", ObjBOL.DepartmentID);
            param[6] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[7] = new SqlParameter("@FirstName", ObjBOL.FirstName);
            param[8] = new SqlParameter("@LastName", ObjBOL.LastName);
            param[9] = new SqlParameter("@Extension", ObjBOL.Extension);
            param[10] = new SqlParameter("@Direct", ObjBOL.Direct);
            param[11] = new SqlParameter("@CellNumber", ObjBOL.CellNumber);
            param[12] = new SqlParameter("@Email", ObjBOL.Email);
            param[13] = new SqlParameter("@Abb", ObjBOL.Abbreviation);
            param[14] = new SqlParameter("@Active", ObjBOL.Active);
            param[15] = new SqlParameter("@ShowExt", ObjBOL.ShowExt);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ManageOfficeExtensions]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        //DeleteExt 
        public string DeleteExt(BOLExtensions ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@EmployeeDetailID", ObjBOL.EmployeeDetailID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ManageOfficeExtensions]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    //DALAddMenu
    public class DALAddMenu : Connection
    {
        public DataSet Return_DataSet(BOLAddMenu ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@MenuID", ObjBOL.MenuID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_AddMenu]", param);
            return ds;
        }

        public string Return_String(BOLAddMenu ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Name", ObjBOL.Name);
            param[3] = new SqlParameter("@Description", ObjBOL.Description);
            param[4] = new SqlParameter("@Url", ObjBOL.Url);
            param[5] = new SqlParameter("@ParentID", ObjBOL.ParentID);
            param[6] = new SqlParameter("@Status", ObjBOL.Status);
            param[7] = new SqlParameter("@SortOrder", ObjBOL.SortOrder);
            param[8] = new SqlParameter("@MenuID", ObjBOL.MenuID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_AddMenu]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALDailyPurchaseRequester : Connection
    {
        public DataSet Return_DataSet(BOLDailyPurchaseRequester ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ID", ObjBOL.ID);
            param[2] = new SqlParameter("@FirstName", ObjBOL.FirstName);
            param[3] = new SqlParameter("@LastName", ObjBOL.LastName);
            param[4] = new SqlParameter("@Active", ObjBOL.Active);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManageDailyPurchaseRequester]", param);
            return ds;
        }

        public string Return_String(BOLDailyPurchaseRequester ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ID", ObjBOL.ID);
            param[2] = new SqlParameter("@FirstName", ObjBOL.FirstName);
            param[3] = new SqlParameter("@LastName", ObjBOL.LastName);
            param[4] = new SqlParameter("@Active", ObjBOL.Active);
            param[5] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[5].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ManageDailyPurchaseRequester]", param);
            string msg = param[5].Value.ToString();
            return msg;
        }
    }

    public class DALPurchaseHistoryDetails : Connection
    {
        public DataSet GetPurchaseHistoryDetails(BOLPurchaseHistoryDetails ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@SearchVar", ObjBOL.SearchVar);
            param[2] = new SqlParameter("@ShipDateFrom", ObjBOL.ShipDateFrom);
            param[3] = new SqlParameter("@ShipDateTo", ObjBOL.ShipDateTo);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Get_PurchaseHistoryDetails]", param);
            return ds;
        }
        //GetJobsStatusReport
        public DataSet GetJobsStatusReport(BOLPurchaseHistoryDetails ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@SearchVar", ObjBOL.SearchVar);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Get_ContainerJobs_RT]", param);
            return ds;
        }
    }

    public class DALPurchaseHistory : Connection
    {
        public DataSet GetPurchaseHistory(BOLPurchaseHistory ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@SearchVar", ObjBOL.SearchVar);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Get_PartsPurchaseHistory", param);
            return ds;
        }
    }

    public class DALTrackContainerJobs : Connection
    {
        public DataSet Return_DS(BOLTrackContainerJobs ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ProjectManagerID", ObjBOL.ProjectManagerID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Get_ContainerJobsNotifications]", param);
            return ds;
        }
    }

    public class DALShipmentReport : Connection
    {
        public DataSet Return_DS(BOLShipmentReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ID", ObjBOL.ID);
            param[3] = new SqlParameter("@SearchVar", ObjBOL.SearchVar);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Inv_ManageStockInNew", param);
            return ds;
        }
        public String Return_String(BOLShipmentReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ID", ObjBOL.ID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Inv_ManageStockInNew", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }
    public class DALForecastingMonthlyEmailData : Connection
    {
        public DataSet Return_DataSet(BOLForecastingMonthlyEmailData ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Get_Forecast_Summary_V2]", param);
            return ds;
        }
        public string Return_String(BOLForecastingMonthlyEmailData ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[Get_Forecast_Summary_V2]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALDailyPurchaseParts : Connection
    {
        public DataSet Return_DataSet(BOLDailyPurchaseParts ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ID", ObjBOL.ID);
            param[2] = new SqlParameter("@PartNumber", ObjBOL.PartNumber);
            param[3] = new SqlParameter("@PartDescription", ObjBOL.PartDescription);
            param[4] = new SqlParameter("@UM", ObjBOL.UM);
            param[5] = new SqlParameter("@MinOrderQty", ObjBOL.MinOrderQty);
            param[6] = new SqlParameter("@MaxStockQty", ObjBOL.MaxStockQty);
            param[7] = new SqlParameter("@ReOrderPoint", ObjBOL.ReOrderPoint);
            param[8] = new SqlParameter("@LeadTimeDays", ObjBOL.LeadTimeDays);
            param[9] = new SqlParameter("@PreferredVendorID", ObjBOL.PreferredVendorID);
            param[10] = new SqlParameter("@ProductLine", ObjBOL.ProductLine);
            param[11] = new SqlParameter("@UnitPrice", ObjBOL.UnitPrice);
            param[12] = new SqlParameter("@SortOrder", ObjBOL.SortOrder);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManageDailyPurchaseParts]", param);
            return ds;
        }

        public string Return_String(BOLDailyPurchaseParts ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ID", ObjBOL.ID);
            param[2] = new SqlParameter("@PartNumber", ObjBOL.PartNumber);
            param[3] = new SqlParameter("@PartDescription", ObjBOL.PartDescription);
            param[4] = new SqlParameter("@UM", ObjBOL.UM);
            param[5] = new SqlParameter("@MinOrderQty", ObjBOL.MinOrderQty);
            param[6] = new SqlParameter("@MaxStockQty", ObjBOL.MaxStockQty);
            param[7] = new SqlParameter("@ReOrderPoint", ObjBOL.ReOrderPoint);
            param[8] = new SqlParameter("@LeadTimeDays", ObjBOL.LeadTimeDays);
            param[9] = new SqlParameter("@PreferredVendorID", ObjBOL.PreferredVendorID);
            param[10] = new SqlParameter("@ProductLine", ObjBOL.ProductLine);
            param[11] = new SqlParameter("@UnitPrice", ObjBOL.UnitPrice);
            param[12] = new SqlParameter("@SortOrder", ObjBOL.SortOrder);
            param[13] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[13].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ManageDailyPurchaseParts]", param);
            string msg = param[13].Value.ToString();
            return msg;
        }
    }

    public class DALDailyPurchase : Connection
    {
        public DataSet Return_DataSet(BOLDailyPurchase ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[19];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@PONo", ObjBOL.PONo);
            param[2] = new SqlParameter("@DailyPurchaseId", ObjBOL.DailyPurchaseId);
            param[3] = new SqlParameter("@VendorId", ObjBOL.VendorId);
            param[4] = new SqlParameter("@PartId", ObjBOL.PartId);
            param[5] = new SqlParameter("@RequesterId", ObjBOL.RequesterId);
            param[6] = new SqlParameter("@ProjectId", ObjBOL.ProjectId);
            param[7] = new SqlParameter("@Department", ObjBOL.Department);
            param[8] = new SqlParameter("@OrderQty", ObjBOL.OrderQty);
            param[9] = new SqlParameter("@UM", ObjBOL.UM);
            param[10] = new SqlParameter("@OrderDate", ObjBOL.OrderDate);
            param[11] = new SqlParameter("@OrderStatus", ObjBOL.OrderStatus);
            param[12] = new SqlParameter("@ETA", ObjBOL.ETA);
            param[13] = new SqlParameter("@ReceivedDate", ObjBOL.ReceivedDate);
            param[14] = new SqlParameter("@Remarks", ObjBOL.Remarks);
            param[15] = new SqlParameter("@Id", ObjBOL.Id);
            param[16] = new SqlParameter("@ReceivedQty", ObjBOL.ReceivedQty);
            param[17] = new SqlParameter("@UnitPrice", ObjBOL.UnitPrice);
            param[18] = new SqlParameter("@TotalCost", ObjBOL.TotalCost);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManageDailyPurchase]", param);
            return ds;
        }

        public string Return_String(BOLDailyPurchase ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@PONo", ObjBOL.PONo);
            param[2] = new SqlParameter("@DailyPurchaseId", ObjBOL.DailyPurchaseId);
            param[3] = new SqlParameter("@VendorId", ObjBOL.VendorId);
            param[4] = new SqlParameter("@PartId", ObjBOL.PartId);
            param[5] = new SqlParameter("@RequesterId", ObjBOL.RequesterId);
            param[6] = new SqlParameter("@ProjectId", ObjBOL.ProjectId);
            param[7] = new SqlParameter("@Department", ObjBOL.Department);
            param[8] = new SqlParameter("@OrderQty", ObjBOL.OrderQty);
            param[9] = new SqlParameter("@UM", ObjBOL.UM);
            param[10] = new SqlParameter("@OrderDate", ObjBOL.OrderDate);
            param[11] = new SqlParameter("@OrderStatus", ObjBOL.OrderStatus);
            param[12] = new SqlParameter("@ETA", ObjBOL.ETA);
            param[13] = new SqlParameter("@ReceivedDate", ObjBOL.ReceivedDate);
            param[14] = new SqlParameter("@Remarks", ObjBOL.Remarks);
            param[15] = new SqlParameter("@Id", ObjBOL.Id);
            param[16] = new SqlParameter("@ReceivedQty", ObjBOL.ReceivedQty);
            param[17] = new SqlParameter("@UnitPrice", ObjBOL.UnitPrice);
            param[18] = new SqlParameter("@TotalCost", ObjBOL.TotalCost);
            param[19] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[19].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ManageDailyPurchase]", param);
            string msg = param[19].Value.ToString();
            return msg;
        }
    }

    public class DALSalesActivity : Connection
    {
        public DataSet Return_DataSet(BOLSalesActivity ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[22];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@Id", ObjBOL.ID);
            param[2] = new SqlParameter("@StakeHolderId", ObjBOL.StakeHolderId);
            param[3] = new SqlParameter("@CompanyId", ObjBOL.CompanyId);
            param[4] = new SqlParameter("@ActivityId", ObjBOL.ActivityId);
            param[5] = new SqlParameter("@Date", ObjBOL.Date);
            param[6] = new SqlParameter("@Objective", ObjBOL.Objective);
            param[7] = new SqlParameter("@Outcome", ObjBOL.Outcome);
            param[8] = new SqlParameter("@ActivityDetailId", ObjBOL.ActivityDetailId);
            param[9] = new SqlParameter("@Task", ObjBOL.Task);
            param[10] = new SqlParameter("@ResponsiblePerson", ObjBOL.ResponsiblePerson);
            param[11] = new SqlParameter("@Deadline", ObjBOL.Deadline);
            param[12] = new SqlParameter("@Status", ObjBOL.Status);
            param[13] = new SqlParameter("@Destination", ObjBOL.Destination);
            param[14] = new SqlParameter("@Purpose", ObjBOL.Purpose);
            param[15] = new SqlParameter("@Date1", ObjBOL.Date1);
            param[16] = new SqlParameter("@UserID", ObjBOL.UserID);
            param[17] = new SqlParameter("@TypeOfContact", ObjBOL.TypeOfContact);
            param[18] = new SqlParameter("@PNumber", ObjBOL.PNumber);
            param[19] = new SqlParameter("@ProjectName", ObjBOL.ProjectName);
            param[20] = new SqlParameter("@NextFollowupDate", ObjBOL.NextFollowupDate);
            param[21] = new SqlParameter("@RegionalIndustryUpdates", ObjBOL.RegionalIndustryUpdates);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManageSalesActivity]", param);
            return ds;
        }
        public string Return_String(BOLSalesActivity ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[23];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@Id", ObjBOL.ID);
            param[2] = new SqlParameter("@StakeHolderId", ObjBOL.StakeHolderId);
            param[3] = new SqlParameter("@CompanyId", ObjBOL.CompanyId);
            param[4] = new SqlParameter("@ActivityId", ObjBOL.ActivityId);
            param[5] = new SqlParameter("@Date", ObjBOL.Date);
            param[6] = new SqlParameter("@Objective", ObjBOL.Objective);
            param[7] = new SqlParameter("@Outcome", ObjBOL.Outcome);
            param[8] = new SqlParameter("@ActivityDetailId", ObjBOL.ActivityDetailId);
            param[9] = new SqlParameter("@Task", ObjBOL.Task);
            param[10] = new SqlParameter("@ResponsiblePerson", ObjBOL.ResponsiblePerson);
            param[11] = new SqlParameter("@Deadline", ObjBOL.Deadline);
            param[12] = new SqlParameter("@Status", ObjBOL.Status);
            param[13] = new SqlParameter("@Destination", ObjBOL.Destination);
            param[14] = new SqlParameter("@Purpose", ObjBOL.Purpose);
            param[16] = new SqlParameter("@Date1", ObjBOL.Date1);
            param[17] = new SqlParameter("@UserID", ObjBOL.UserID);
            param[18] = new SqlParameter("@TypeOfContact", ObjBOL.TypeOfContact);
            param[19] = new SqlParameter("@PNumber", ObjBOL.PNumber);
            param[20] = new SqlParameter("@ProjectName", ObjBOL.ProjectName);
            param[21] = new SqlParameter("@NextFollowupDate", ObjBOL.NextFollowupDate);
            param[22] = new SqlParameter("@RegionalIndustryUpdates", ObjBOL.RegionalIndustryUpdates);
            param[15] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[15].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ManageSalesActivity]", param);
            string msg = param[15].Value.ToString();
            return msg;
        }
    }

    //DALBindEmailAddress
    public class DALBindEmailAddress : Connection
    {
        public DataSet Return_DataSet(BOLBindEmailAddress ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@group", ObjBOL.group);
            param[2] = new SqlParameter("@displayNameFilter", ObjBOL.displayNameFilter);
            param[3] = new SqlParameter("@formName", ObjBOL.formName);
            param[4] = new SqlParameter("@emailType", ObjBOL.emailType);
            param[5] = new SqlParameter("@formOperation", ObjBOL.formOperation);
            //DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Inv_ManageEmail]", param);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManageEmail_Dynamic]", param);
            return ds;
        }

    }
    public class DALReportDashboard : Connection
    {
        public DataSet Return_DataSet(BOLReportDashboard ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@searchvar", ObjBOL.searchvar);
            param[2] = new SqlParameter("@ProductLine", ObjBOL.ProductLine);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_RT_ReportDashboard]", param);
            return ds;
        }

    }


    public class DALStockInHandAdjustment : Connection
    {
        public DataSet Return_DataSet(BOLStockInHandAdjustment ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ContainerID", ObjBOL.ContainerID);
            param[2] = new SqlParameter("@SourceID", ObjBOL.SourceID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Inv_StockInHand_AdjustmentQty]", param);
            return ds;
        }
        public string Return_String(BOLStockInHandAdjustment ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[3] = new SqlParameter("@ContainerID", ObjBOL.ContainerID);
            param[4] = new SqlParameter("@TempDataStockInHand", ObjBOL.TempDataStockInHand);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[Inv_StockInHand_AdjustmentQty]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }


    public class DALStockInDashboard : Connection
    {
        public DataSet Return_DataSet(BOLStockInDashboard ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Inv_Dashboard]", param);
            return ds;
        }

    }


    public class DALPostInstallFollowups : Connection
    {
        public DataSet Return_DataSet(BOLPostInstallFollowups ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@FromDate", ObjBOL.FromDate);
            param[3] = new SqlParameter("@ToDate", ObjBOL.ToDate);
            param[4] = new SqlParameter("@ID", ObjBOL.ID);
            param[5] = new SqlParameter("@FollowupWith", ObjBOL.FollowupWith);
            param[6] = new SqlParameter("@FollowupDate", ObjBOL.FollowupDate);
            param[7] = new SqlParameter("@ScheduledFollowupDate", ObjBOL.ScheduledFollowupDate);
            param[8] = new SqlParameter("@Notes", ObjBOL.Notes);
            param[9] = new SqlParameter("@FollowupType", ObjBOL.FollowupType);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManagePostInstallFollowups]", param);
            return ds;
        }

        public string Return_String(BOLPostInstallFollowups ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@FromDate", ObjBOL.FromDate);
            param[3] = new SqlParameter("@ToDate", ObjBOL.ToDate);
            param[4] = new SqlParameter("@ID", ObjBOL.ID);
            param[5] = new SqlParameter("@FollowupWith", ObjBOL.FollowupWith);
            param[6] = new SqlParameter("@FollowupDate", ObjBOL.FollowupDate);
            param[7] = new SqlParameter("@ScheduledFollowupDate", ObjBOL.ScheduledFollowupDate);
            param[8] = new SqlParameter("@Notes", ObjBOL.Notes);
            param[9] = new SqlParameter("@FollowupType", ObjBOL.FollowupType);
            param[10] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[10].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ManagePostInstallFollowups]", param);
            string msg = param[10].Value.ToString();
            return msg;
        }
    }

    public class DALForecastingModelSizeMapping : Connection
    {
        public DataSet Return_DataSet(BOLForecastingModelSizeMapping ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ModelID", ObjBOL.ModelID);
            param[2] = new SqlParameter("@TypeID", ObjBOL.TypeID);
            param[3] = new SqlParameter("@SizeID", ObjBOL.SizeID);
            param[4] = new SqlParameter("@Size", ObjBOL.Size);
            param[5] = new SqlParameter("@IsActive", ObjBOL.IsActive);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ModelSizeMapping]", param);
            return ds;
        }

        public string Return_String(BOLForecastingModelSizeMapping ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ModelID", ObjBOL.ModelID);
            param[2] = new SqlParameter("@TypeID", ObjBOL.TypeID);
            param[3] = new SqlParameter("@SizeID", ObjBOL.SizeID);
            param[4] = new SqlParameter("@Size", ObjBOL.Size);
            param[5] = new SqlParameter("@IsActive", ObjBOL.IsActive);
            param[6] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[6].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ModelSizeMapping]", param);
            string msg = param[6].Value.ToString();
            return msg;
        }
    }

    public class DALForecastingModelPartMapping : Connection
    {
        public DataSet Return_DataSet(BOLForecastingModelPartMapping ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ModelID", ObjBOL.ModelID);
            param[2] = new SqlParameter("@TypeID", ObjBOL.TypeID);
            param[3] = new SqlParameter("@Qty", ObjBOL.Qty);
            param[4] = new SqlParameter("@IsActive", ObjBOL.IsActive);
            param[5] = new SqlParameter("@IsBackendEntry", ObjBOL.IsBackendEntry);
            param[6] = new SqlParameter("@ChildPartID", ObjBOL.ChildPartID);
            param[7] = new SqlParameter("@ParentPartID", ObjBOL.ParentPartID);
            param[8] = new SqlParameter("@SizeID", ObjBOL.SizeID);
            param[9] = new SqlParameter("@ID", ObjBOL.ID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ModelPartMapping]", param);
            return ds;
        }

        public string Return_String(BOLForecastingModelPartMapping ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ModelID", ObjBOL.ModelID);
            param[2] = new SqlParameter("@TypeID", ObjBOL.TypeID);
            param[3] = new SqlParameter("@Qty", ObjBOL.Qty);
            param[4] = new SqlParameter("@IsActive", ObjBOL.IsActive);
            param[5] = new SqlParameter("@IsBackendEntry", ObjBOL.IsBackendEntry);
            param[6] = new SqlParameter("@ChildPartID", ObjBOL.ChildPartID);
            param[7] = new SqlParameter("@ParentPartID", ObjBOL.ParentPartID);
            param[8] = new SqlParameter("@SizeID", ObjBOL.SizeID);
            param[9] = new SqlParameter("@ID", ObjBOL.ID);
            param[10] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[10].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ModelPartMapping]", param);
            string msg = param[10].Value.ToString();
            return msg;
        }
    }

    public class DALForecastingModelTypeMapping : Connection
    {
        public DataSet Return_DataSet(BOLForecastingModelTypeMapping ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ModelID", ObjBOL.ModelID);
            param[2] = new SqlParameter("@TypeID", ObjBOL.TypeID);
            param[3] = new SqlParameter("@Type", ObjBOL.Type);
            param[4] = new SqlParameter("@IsActive", ObjBOL.IsActive);
            param[4] = new SqlParameter("@TypeDesc", ObjBOL.TypeDesc);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ModelTypeMapping]", param);
            return ds;
        }

        public string Return_String(BOLForecastingModelTypeMapping ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ModelID", ObjBOL.ModelID);
            param[2] = new SqlParameter("@TypeID", ObjBOL.TypeID);
            param[3] = new SqlParameter("@Type", ObjBOL.Type);
            param[4] = new SqlParameter("@IsActive", ObjBOL.IsActive);
            param[5] = new SqlParameter("@TypeDesc", ObjBOL.TypeDesc);
            param[6] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[6].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ModelTypeMapping]", param);
            string msg = param[6].Value.ToString();
            return msg;
        }
    }

    public class DALForecastingJobModels : Connection
    {
        public DataSet Return_DataSet(BOLForecastingJobModels ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@UserID", ObjBOL.UserID);
            param[3] = new SqlParameter("@AWProductSubID", ObjBOL.AWProductSubID);
            param[4] = new SqlParameter("@SizeID", ObjBOL.SizeID);
            param[5] = new SqlParameter("@ParentID", ObjBOL.ParentPartID);
            param[6] = new SqlParameter("@ProjectsID", ObjBOL.ProjectsID);
            param[7] = new SqlParameter("@Qty", ObjBOL.Qty);
            param[8] = new SqlParameter("@ID", ObjBOL.ID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManageJobModels]", param);
            return ds;
        }

        public string Return_String(BOLForecastingJobModels ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@UserID", ObjBOL.UserID);
            param[3] = new SqlParameter("@AWProductSubID", ObjBOL.AWProductSubID);
            param[4] = new SqlParameter("@SizeID", ObjBOL.SizeID);
            param[5] = new SqlParameter("@ParentID", ObjBOL.ParentPartID);
            param[6] = new SqlParameter("@ProjectsID", ObjBOL.ProjectsID);
            param[7] = new SqlParameter("@Qty", ObjBOL.Qty);
            param[8] = new SqlParameter("@ID", ObjBOL.ID);
            param[9] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[9].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ManageJobModels]", param);
            string msg = param[9].Value.ToString();
            return msg;
        }
    }

    public class DALForecastingSubAssembly : Connection
    {
        public DataSet Return_DataSet(BOLForecastingSubParts ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@Product", ObjBOL.Product);
            param[2] = new SqlParameter("@StartDate", ObjBOL.StartDate);
            param[3] = new SqlParameter("@EndDate", ObjBOL.EndDate);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManageForecastingSubAssembly]", param);
            return ds;
        }
    }

    public class DALEmployeeMaintain : Connection
    {
        public DataSet GetControls(BOLEmployeeMaintain ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[3] = new SqlParameter("@CountryId", ObjBOL.CountryId);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageEmployee", param);
            return ds;
        }
        public String SaveEmployeeRecord(BOLEmployeeMaintain ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[29];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@FirstName", ObjBOL.FirstName);
            param[2] = new SqlParameter("@LastName", ObjBOL.LastName);
            param[3] = new SqlParameter("@Branch", ObjBOL.Branch);
            param[4] = new SqlParameter("@UserName", ObjBOL.UserName);
            param[5] = new SqlParameter("@Passwd", ObjBOL.Password);
            param[6] = new SqlParameter("@Department", ObjBOL.Department);
            param[7] = new SqlParameter("@Address", ObjBOL.Address);
            param[8] = new SqlParameter("@CountryId", ObjBOL.CountryId);
            param[9] = new SqlParameter("@StateOrProvince", ObjBOL.StateOrProvince);
            param[10] = new SqlParameter("@City", ObjBOL.City);
            param[11] = new SqlParameter("@PostalCode", ObjBOL.PostalCode);
            param[12] = new SqlParameter("@HomePhone", ObjBOL.HomePhone);
            param[13] = new SqlParameter("@OfficeExtension", ObjBOL.OfficeExtension);
            param[14] = new SqlParameter("@CellPhone", ObjBOL.CellPhone);
            param[15] = new SqlParameter("@Notes", ObjBOL.Notes);
            param[16] = new SqlParameter("@Abbrivation", ObjBOL.Abbrivation);
            param[17] = new SqlParameter("@DOB", ObjBOL.DOB);
            param[18] = new SqlParameter("@EngDepID", ObjBOL.EngDepID);
            param[19] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[20] = new SqlParameter("@DivisionID", ObjBOL.DivisionID);
            param[21] = new SqlParameter("@Email", ObjBOL.Email);
            param[22] = new SqlParameter("@Active", ObjBOL.Status);
            param[23] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[24] = new SqlParameter("@Full", ObjBOL.Full);
            param[25] = new SqlParameter("@Half", ObjBOL.Half);
            param[26] = new SqlParameter("@Viewandminium", ObjBOL.ViewandMinimum);
            param[27] = new SqlParameter("@Restrict", ObjBOL.Restrict);
            param[28] = new SqlParameter("@ViewOnly", ObjBOL.ViewOnly);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageEmployee", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }
    public class DALShpDrgEng : Connection
    {
        public DataSet GetDataShpDrg(BOLShpDrg ObjBOLShpDrg)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOLShpDrg.Operation);
            param[2] = new SqlParameter("@sDrgNum", ObjBOLShpDrg.sDrgNum);
            param[3] = new SqlParameter("@JobID", ObjBOLShpDrg.JobID);
            param[4] = new SqlParameter("@sDrgJID", ObjBOLShpDrg.sDrgJID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjectsEng", param);
            return ds;
        }
        public String SaveDataShpDrg(BOLShpDrg ObjBOLShpDrg)
        {
            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@sDrgNum", ObjBOLShpDrg.sDrgNum);
            param[2] = new SqlParameter("@sDrgJID", ObjBOLShpDrg.sDrgJID);
            param[3] = new SqlParameter("@sDrgWantDate", ObjBOLShpDrg.sDrgWantDate);
            param[4] = new SqlParameter("@sDrgPromiseDate", ObjBOLShpDrg.sDrgPromiseDate);
            param[5] = new SqlParameter("@sDrgExpecApprovalDate", ObjBOLShpDrg.sDrgExpecApprovalDate);
            param[6] = new SqlParameter("@sDrgSentToRCD", ObjBOLShpDrg.sDrgSentToRCD);
            param[7] = new SqlParameter("@sDrgAppDate", ObjBOLShpDrg.sDrgAppDate);
            param[8] = new SqlParameter("@sNextFolowupDate", ObjBOLShpDrg.sNextFolowupDate);
            param[9] = new SqlParameter("@sDateFollowedUp", ObjBOLShpDrg.sDateFollowedUp);
            param[10] = new SqlParameter("@sDrgComment", ObjBOLShpDrg.sDrgComment);
            param[11] = new SqlParameter("@sDateReleasedToFab", ObjBOLShpDrg.sDateReleasedToFab);
            param[12] = new SqlParameter("@Operation", ObjBOLShpDrg.Operation);
            param[13] = new SqlParameter("@sReleasedTo", ObjBOLShpDrg.sReleasedTo);
            param[14] = new SqlParameter("@sReleasedToFabDate", ObjBOLShpDrg.sReleasedToFabDate);
            param[15] = new SqlParameter("@sReleasedToShopDate", ObjBOLShpDrg.sReleasedToShopDate);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageProjectsEng", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }
    public class DALManageProjects_New : Connection
    {
        //DALManageProjects
        public string SaveProject(BOLManageProjects ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[212];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@JobOrderDate", ObjBOL.JobOrderDate);
            param[3] = new SqlParameter("@PORec", ObjBOL.PORec);
            param[4] = new SqlParameter("@OASentTo", ObjBOL.OASentTo);
            param[5] = new SqlParameter("@OASentToContact", ObjBOL.OASentToContact);
            param[6] = new SqlParameter("@QuoteSelected", ObjBOL.QuoteSelected);
            param[7] = new SqlParameter("@JobOrderAck", ObjBOL.JobOrderAck);
            param[8] = new SqlParameter("@JobOADis", ObjBOL.JobOADis);
            param[9] = new SqlParameter("@ProposalID", ObjBOL.ProposalID);
            param[10] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
            param[11] = new SqlParameter("@ModelID", ObjBOL.ModelID);
            param[12] = new SqlParameter("@ConveyorTypeID", ObjBOL.ConveyorTypeID);
            param[13] = new SqlParameter("@ServiceRepID", ObjBOL.ServiceRepID);
            param[14] = new SqlParameter("@ShipperID", ObjBOL.ShipperID);
            param[15] = new SqlParameter("@SiteContact", ObjBOL.SiteContact);
            param[16] = new SqlParameter("@SiteContactTelephone", ObjBOL.SiteContactTelephone);
            param[17] = new SqlParameter("@DateAsBuiltDrgsSent", ObjBOL.DateAsBuiltDrgsSent);
            param[18] = new SqlParameter("@EstReleaseDate", ObjBOL.EstReleaseDate);
            param[19] = new SqlParameter("@ReleaseDate", ObjBOL.ReleaseDate);
            param[20] = new SqlParameter("@TestRunDate", ObjBOL.TestRunDate);
            param[21] = new SqlParameter("@EstCompletionDate", ObjBOL.EstCompletionDate);
            param[22] = new SqlParameter("@ActualCompletionDate", ObjBOL.ActualCompletionDate);
            param[23] = new SqlParameter("@ShipDate", ObjBOL.ShipDate);
            param[24] = new SqlParameter("@ShipToArriveDate", ObjBOL.ShipToArriveDate);
            param[25] = new SqlParameter("@ArrivalDate", ObjBOL.ArrivalDate);
            param[26] = new SqlParameter("@ManualDispatchDate", ObjBOL.ManualDispatchDate);
            param[27] = new SqlParameter("@InstallationBy", ObjBOL.InstallationBy);
            param[28] = new SqlParameter("@InstallDate", ObjBOL.InstallDate);
            param[29] = new SqlParameter("@InstallationCompletionDate", ObjBOL.InstallationCompletionDate);
            param[30] = new SqlParameter("@NoInstallation", ObjBOL.NoInstallation);
            param[31] = new SqlParameter("@DemoDate", ObjBOL.DemoDate);
            param[32] = new SqlParameter("@WarrantyStartDate", ObjBOL.WarrantyStartDate);
            param[33] = new SqlParameter("@WarrantyEndDate", ObjBOL.WarrantyEndDate);
            param[34] = new SqlParameter("@FollowUpDate", ObjBOL.FollowUpDate);
            param[35] = new SqlParameter("@CustCarePackageSendDate", ObjBOL.CustCarePackageSendDate);
            param[36] = new SqlParameter("@PONumber", ObjBOL.PONumber);
            param[37] = new SqlParameter("@InvoiceNumber", ObjBOL.InvoiceNumber);
            param[38] = new SqlParameter("@DateInvoiceSent", ObjBOL.DateInvoiceSent);
            param[39] = new SqlParameter("@DatePaymentReceived", ObjBOL.DatePaymentReceived);
            param[40] = new SqlParameter("@DateCommissionPaid", ObjBOL.DateCommissionPaid);
            param[41] = new SqlParameter("@KflexCheckNumber", ObjBOL.KflexCheckNumber);
            param[42] = new SqlParameter("@CommissionType", ObjBOL.CommissionType);
            param[43] = new SqlParameter("@SalesSourceID", ObjBOL.SalesSourceID);
            param[44] = new SqlParameter("@ProjectDesignerID", ObjBOL.ProjectDesignerID);
            param[45] = new SqlParameter("@DateAssigned", ObjBOL.DateAssigned);
            param[46] = new SqlParameter("@ShipToName", ObjBOL.ShipToName);
            param[47] = new SqlParameter("@ShipToStreet", ObjBOL.ShipToStreet);
            param[48] = new SqlParameter("@ShipToCity", ObjBOL.ShipToCity);
            param[49] = new SqlParameter("@ShipToState", ObjBOL.ShipToState);
            param[50] = new SqlParameter("@ShipToCountry", ObjBOL.ShipToCountry);
            param[51] = new SqlParameter("@ShipToZipCode", ObjBOL.ShipToZipCode);
            param[52] = new SqlParameter("@discount", ObjBOL.discount);
            param[53] = new SqlParameter("@fob", ObjBOL.fob);
            param[54] = new SqlParameter("@term", ObjBOL.term);
            param[55] = new SqlParameter("@IndComDate", ObjBOL.IndComDate);
            param[56] = new SqlParameter("@AeroChequeNum", ObjBOL.AeroChequeNum);
            param[57] = new SqlParameter("@PreInspectionDate", ObjBOL.PreInspectionDate);
            param[58] = new SqlParameter("@CheckedByOffice", ObjBOL.CheckedByOffice);
            param[59] = new SqlParameter("@CheckedByPlant", ObjBOL.CheckedByPlant);
            // param[60] = new SqlParameter("@CancelJob", ObjBOL.CancelJob);
            param[61] = new SqlParameter("@DigitalPicOnServer", ObjBOL.DigitalPicOnServer);
            param[62] = new SqlParameter("@ReferenceDrawing", ObjBOL.ReferenceDrawing);
            param[63] = new SqlParameter("@DealerMember", ObjBOL.DealerMember);
            param[64] = new SqlParameter("@BuyOutCost", ObjBOL.BuyOutCost);
            param[65] = new SqlParameter("@RawMaterial", ObjBOL.RawMaterial);
            param[66] = new SqlParameter("@ExWarrantyPrice", ObjBOL.ExWarrantyPrice);
            param[67] = new SqlParameter("@NetAmount", ObjBOL.NetAmount);
            param[68] = new SqlParameter("@FreightPaid", ObjBOL.FreightPaid);
            param[69] = new SqlParameter("@GST", ObjBOL.GST);
            param[70] = new SqlParameter("@InstallatorA", ObjBOL.InstallatorA);
            param[71] = new SqlParameter("@InstallatorB", ObjBOL.InstallatorB);
            param[72] = new SqlParameter("@InstallatorC", ObjBOL.InstallatorC);
            param[73] = new SqlParameter("@ConCost", ObjBOL.ConCost);
            param[74] = new SqlParameter("@ConRoylAmt", ObjBOL.ConRoylAmt);
            param[75] = new SqlParameter("@ConCheckNo", ObjBOL.ConCheckNo);
            param[76] = new SqlParameter("@ConChqPaidDt", ObjBOL.ConChqPaidDt);
            param[77] = new SqlParameter("@Comments", ObjBOL.Comments);
            param[78] = new SqlParameter("@ReviewedBy", ObjBOL.ReviewedBy);
            param[79] = new SqlParameter("@DrgSentOutforApproval", ObjBOL.DrgSentOutforApproval);
            param[80] = new SqlParameter("@AppDrgWithFieldDimension", ObjBOL.AppDrgWithFieldDimension);
            param[81] = new SqlParameter("@AppDrgAck", ObjBOL.AppDrgAck);
            param[82] = new SqlParameter("@EquipDelConfirmed", ObjBOL.EquipDelConfirmed);
            param[83] = new SqlParameter("@AccReqFromCustomer", ObjBOL.AccReqFromCustomer);
            param[84] = new SqlParameter("@BuiltDrgWithUnderStruSent", ObjBOL.BuiltDrgWithUnderStruSent);
            param[85] = new SqlParameter("@ProjDataPrepBy", ObjBOL.ProjDataPrepBy);
            param[86] = new SqlParameter("@ProjFormReviewByAI", ObjBOL.ProjFormReviewByAI);
            param[87] = new SqlParameter("@ProjFormReviewByHO", ObjBOL.ProjFormReviewByHO);
            param[88] = new SqlParameter("@FabDrgReviewByAI", ObjBOL.FabDrgReviewByAI);
            param[89] = new SqlParameter("@FabDrgReviewByHO", ObjBOL.FabDrgReviewByHO);
            param[90] = new SqlParameter("@PFRBAIDate", ObjBOL.PFRBAIDate);
            param[91] = new SqlParameter("@PFRBHODate", ObjBOL.PFRBHODate);
            param[92] = new SqlParameter("@FDRBAIDate", ObjBOL.FDRBAIDate);
            param[93] = new SqlParameter("@FDRBHODate", ObjBOL.FDRBHODate);
            param[94] = new SqlParameter("@FeedBackConsultant", ObjBOL.FeedBackConsultant);
            param[95] = new SqlParameter("@FeedBackDealer", ObjBOL.FeedBackDealer);
            param[96] = new SqlParameter("@SummofSugg", ObjBOL.SummofSugg);
            //param[98] = new SqlParameter("@SpecCredit", ObjBOL.SpecCredit);        
            param[97] = new SqlParameter("@SpecCredits", ObjBOL.SpecCredits);
            param[98] = new SqlParameter("@SpecCreditPercentID", ObjBOL.SpecCreditPercentID);
            param[99] = new SqlParameter("@SpecCreditAmount", ObjBOL.SpecCreditAmount);
            param[100] = new SqlParameter("@SpecCreditCheckNo", ObjBOL.SpecCreditCheckNo);
            param[101] = new SqlParameter("@SpecCreditPaidDate", ObjBOL.SpecCreditPaidDate);
            param[102] = new SqlParameter("@GSICommissionType", ObjBOL.GSICommissionType);
            param[103] = new SqlParameter("@GSICommissionAmount", ObjBOL.GSICommissionAmount);
            param[104] = new SqlParameter("@GSICommissionCheckNo", ObjBOL.GSICommissionCheckNo);
            param[105] = new SqlParameter("@GSICommissionSentDate", ObjBOL.GSICommissionSentDate);
            //Pfile Columns           
            param[106] = new SqlParameter("@DealerID", ObjBOL.DealerID);
            //param[109] = new SqlParameter("@ConveyorTypeID", ObjBOL.ConveyorTypeID);
            param[107] = new SqlParameter("@OriginRepID", ObjBOL.OriginRepID);
            param[108] = new SqlParameter("@ConsultRepID", ObjBOL.ConsultRepID);
            param[109] = new SqlParameter("@RepID", ObjBOL.RepID);
            param[110] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
            param[111] = new SqlParameter("@Price", ObjBOL.Price);
            param[112] = new SqlParameter("@Freight", ObjBOL.Freight);
            param[113] = new SqlParameter("@Installation", ObjBOL.Installation);
            param[114] = new SqlParameter("@CurrencyID", ObjBOL.CurrencyID);
            param[115] = new SqlParameter("@CurrentStatus", ObjBOL.CurrentStatus);
            param[116] = new SqlParameter("@OrderProbabilityID", ObjBOL.OrderProbabilityID);
            param[117] = new SqlParameter("@DetailedQuote", ObjBOL.DetailedQuote);
            param[118] = new SqlParameter("@Specifications", ObjBOL.Specifications);
            param[119] = new SqlParameter("@DPics", ObjBOL.DPics);
            param[120] = new SqlParameter("@RefDrawing", ObjBOL.RefDrawing);
            param[121] = new SqlParameter("@EqDisAmount", ObjBOL.EqDisAmount);
            param[122] = new SqlParameter("@EqDiscount", ObjBOL.EqDiscount);
            param[123] = new SqlParameter("@NetEqPrice", ObjBOL.NetEqPrice);
            param[124] = new SqlParameter("@OrderBelongsToDELETE", ObjBOL.OrderBelongsToDELETE);
            param[125] = new SqlParameter("@MfgFacilityID", ObjBOL.MfgFacilityID);
            param[126] = new SqlParameter("@ConsultantMemberId", ObjBOL.ConsultantMemberId);
            param[127] = new SqlParameter("@operation", ObjBOL.Operation);
            param[128] = new SqlParameter("@DueDateCanada", ObjBOL.DueDateCanada);
            param[129] = new SqlParameter("@FabSentToCanada", ObjBOL.FabSentToCanada);
            param[130] = new SqlParameter("@EngineerCanada", ObjBOL.EngineerCanada);
            param[131] = new SqlParameter("@ReleasedToNesting", ObjBOL.ReleasedToNesting);
            param[132] = new SqlParameter("@ReleasedToShop", ObjBOL.ReleasedToShop);
            param[133] = new SqlParameter("@ProjectStatus", ObjBOL.ProjectStatus);
            param[134] = new SqlParameter("@ExistingJobID", ObjBOL.ExistingJobID);
            param[135] = new SqlParameter("@JobType", ObjBOL.JobType);
            param[136] = new SqlParameter("@projectmanager", ObjBOL.ProjectManager);
            param[137] = new SqlParameter("@ShippingCommit", ObjBOL.ShippingCommit);
            param[138] = new SqlParameter("@ProjectCommissionText", ObjBOL.ProjectCommNotes);
            param[139] = new SqlParameter("@NestingStatus", ObjBOL.NestingStatus);
            param[140] = new SqlParameter("@ShipStatus", ObjBOL.ShipStatus);
            param[141] = new SqlParameter("@UserID", ObjBOL.UserID);
            param[142] = new SqlParameter("@CashDisAmt", ObjBOL.CashDisAmt);
            param[143] = new SqlParameter("@CashDisPer", ObjBOL.CashDisPer);
            param[144] = new SqlParameter("@CashAmtRec", ObjBOL.CashAmtRec);
            param[145] = new SqlParameter("@AmountForComission", ObjBOL.AmountForComission);
            param[146] = new SqlParameter("@PMPack", ObjBOL.PMPack);
            param[147] = new SqlParameter("@Status", ObjBOL.Status);
            param[148] = new SqlParameter("@ExpectedArrivalDatefromChina", ObjBOL.ExpectedArrivalDatefromChina);
            param[149] = new SqlParameter("@PurchasedItems", ObjBOL.PurchasedItems);
            param[150] = new SqlParameter("@PurchasedItemsCAD", ObjBOL.PurchasedItemsCAD);
            param[151] = new SqlParameter("@TotalAmtInv", ObjBOL.TotalAmtInv);
            param[152] = new SqlParameter("@NetCommissionRate", ObjBOL.NetCommissionRate);
            //ProjectStatus
            //Shipping Parameters
            param[153] = new SqlParameter("@DeliveryPref", ObjBOL.DeliveryPref);
            param[154] = new SqlParameter("@CustomerSiteContact", ObjBOL.CustomerSiteContact);
            param[155] = new SqlParameter("@DealerProjectManager", ObjBOL.DealerProjectManager);
            param[156] = new SqlParameter("@WorkingHours", ObjBOL.WorkingHours);
            param[157] = new SqlParameter("@MontoFriTime", ObjBOL.MontoFriTime);
            param[158] = new SqlParameter("@SatSunTime", ObjBOL.SatSunTime);
            param[159] = new SqlParameter("@ProjectReviewedBy", ObjBOL.ProjectReviewedBy);
            param[160] = new SqlParameter("@ProjectReviewedDate", ObjBOL.ProjectReviewedDate);
            param[161] = new SqlParameter("@ReasonForPriceUpdate", ObjBOL.ReasonForPriceUpdate);
            param[162] = new SqlParameter("@UpdatedOnVisual", ObjBOL.UpdatedOnVisual);
            param[163] = new SqlParameter("@ConfirmedFromGover", ObjBOL.ConfirmedFromGover);
            param[164] = new SqlParameter("@InvoiceNotRequired", ObjBOL.InvoiceNotRequired);
            param[165] = new SqlParameter("@InstallationCommitment", ObjBOL.InstallationCommitment);
            param[166] = new SqlParameter("@ProjectTechnician", ObjBOL.ProjectTechnician);
            param[167] = new SqlParameter("@InstallationPriority", ObjBOL.InstallationPriority);
            param[168] = new SqlParameter("@StartupDate", ObjBOL.StartupDate);
            param[169] = new SqlParameter("@CommissioningDate", ObjBOL.CommissioningDate);
            param[170] = new SqlParameter("@ShippingReq", ObjBOL.ShippingReq);
            param[171] = new SqlParameter("@ShippingReqDetails", ObjBOL.ShippingReqDetails);
            param[172] = new SqlParameter("@CertificateReq", ObjBOL.CertificateReq);
            param[173] = new SqlParameter("@CertificateReqDetails", ObjBOL.CertificateReqDetails);
            param[174] = new SqlParameter("@MannedFireWatch", ObjBOL.MannedFireWatch);
            param[175] = new SqlParameter("@MannedFireWatchDetails", ObjBOL.MannedFireWatchDetails);
            param[176] = new SqlParameter("@HotWorkPermit", ObjBOL.HotWorkPermit);
            param[177] = new SqlParameter("@HotWorkPermitDetails", ObjBOL.HotWorkPermitDetails);
            param[178] = new SqlParameter("@OrientTraining", ObjBOL.OrientTraining);
            param[179] = new SqlParameter("@OrientTrainingDetails", ObjBOL.OrientTrainingDetails);
            param[180] = new SqlParameter("@CanTechAccess", ObjBOL.CanTechAccess);
            param[181] = new SqlParameter("@CanTechAccessDetails", ObjBOL.CanTechAccessDetails);
            param[182] = new SqlParameter("@ScopeOfWork", ObjBOL.ScopeOfWork);
            param[183] = new SqlParameter("@PlumbingElectricalSupply", ObjBOL.PlumbingElectricalSupply);
            param[184] = new SqlParameter("@ScopeDate", ObjBOL.ScopeDate);
            param[185] = new SqlParameter("@Osha", ObjBOL.Osha);
            param[186] = new SqlParameter("@OshaDetails", ObjBOL.OshaDetails);
            param[187] = new SqlParameter("@StateCertificate", ObjBOL.StateCertificate);
            param[188] = new SqlParameter("@StateCertificateDetails", ObjBOL.StateCertificateDetails);
            param[189] = new SqlParameter("@DrugTestingCertificate", ObjBOL.DrugTestingCertificate);
            param[190] = new SqlParameter("@DrugTestingCertificateDetails", ObjBOL.DrugTestingCertificateDetails);
            param[191] = new SqlParameter("@WHMIS", ObjBOL.WHMIS);
            param[192] = new SqlParameter("@WHMISDetails", ObjBOL.WHMISDetails);
            param[193] = new SqlParameter("@FallProtection", ObjBOL.FallProtection);
            param[194] = new SqlParameter("@FallProtectionDetails", ObjBOL.FallProtectionDetails);
            param[195] = new SqlParameter("@MedicalCertificate", ObjBOL.MedicalCertificate);
            param[196] = new SqlParameter("@MedicalCertificateDetails", ObjBOL.MedicalCertificateDetails);
            param[197] = new SqlParameter("@InsuranceCertificate", ObjBOL.InsuranceCertificate);
            param[198] = new SqlParameter("@InsuranceCertificateDetails", ObjBOL.InsuranceCertificateDetails);
            param[199] = new SqlParameter("@SiteContactEmail", ObjBOL.SiteContactEmail);
            param[200] = new SqlParameter("@ShipperContactName", ObjBOL.ShipperContactName);
            param[201] = new SqlParameter("@ShipperPhone", ObjBOL.ShipperPhone);
            param[202] = new SqlParameter("@ShipperEmail", ObjBOL.ShipperEmail);
            param[203] = new SqlParameter("@ShipperTrackingNo", ObjBOL.ShipperTrackingNo);
            param[204] = new SqlParameter("@ShipperPickupFromShop", ObjBOL.ShipperPickupFromShop);
            param[205] = new SqlParameter("@ShipperNotes", ObjBOL.ShipperNotes);
            param[206] = new SqlParameter("@ActualShippingCost", ObjBOL.ActualShippingCost);
            param[207] = new SqlParameter("@AdditionalCharges", ObjBOL.AdditionalCharges);
            param[208] = new SqlParameter("@ShippedVia", ObjBOL.ShippedVia);
            param[209] = new SqlParameter("@SalesOpportunity", ObjBOL.SalesOpportunity);
            param[210] = new SqlParameter("@SalesOpportunityStatus", ObjBOL.SalesOpportunityStatus);
            param[211] = new SqlParameter("@ExpectedSalesDate", ObjBOL.ExpectedSalesDate);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageProjects_New]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetProject(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@ProjectName", ObjBOL.ProjectName);
                param[3] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
                param[4] = new SqlParameter("@ProposalID", ObjBOL.ProposalID);
                param[5] = new SqlParameter("@JobID", ObjBOL.JobID);
                param[6] = new SqlParameter("@DealerID", ObjBOL.DealerID);
                param[7] = new SqlParameter("@ConsultRepID", ObjBOL.ConsultRepID);
                param[8] = new SqlParameter("@RepID", ObjBOL.RepID);
                param[9] = new SqlParameter("@OriginRepID", ObjBOL.OriginRepID);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjects_New", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        public string GetProjectStatus(BOLManageProjects ObjBOL)
        {
            string ProjectStatus = string.Empty;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@JobID", ObjBOL.JobID);
                param[3] = new SqlParameter("@UserID", ObjBOL.UserID);
                SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjects_New", param);
                ProjectStatus = param[0].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ProjectStatus;
        }

        public DataSet GetStates(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@ShipToCountry", ObjBOL.ShipToCountry);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjects_New", param);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ds;
        }

        public DataSet FillControls(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjects_New", param);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ds;
        }

        public string GenrateJNumber(BOLManageProjects ObjBOL)
        {
            string jnumber = string.Empty;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@operation", ObjBOL.Operation);
                SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageProjects_New]", param);
                jnumber = param[0].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return jnumber;
        }

        public Decimal GetTaxAmount(BOLManageProjects ObjBOL)
        {
            Decimal amount = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@EqDiscount", SqlDbType.Float);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
                param[2] = new SqlParameter("@JobOrderDate", ObjBOL.JobOrderDate);
                param[3] = new SqlParameter("@Price", ObjBOL.NetAmount);
                SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[Get_TaxAmount]", param);
                amount = Convert.ToDecimal(param[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return amount;
        }

        //GetCashDiscount
        public decimal GetCashDiscount(BOLManageProjects ObjBOL)
        {
            Decimal amount = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@EqDiscount", SqlDbType.Float);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@DealerID", ObjBOL.DealerID);
                SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[Get_CashDiscount]", param);
                amount = Convert.ToDecimal(param[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return amount;
        }

        public DataSet Return_DataSet(BOLManageProjects ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ShipperID", ObjBOL.ShipperID);
            param[2] = new SqlParameter("@ContactID", ObjBOL.ContactID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManageProjects_New]", param);
            return ds;
        }
    }

    public class DALManageProjectsEng : Connection
    {
        public string SaveProject(BOLManageProjects ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[167];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@JobOrderDate", ObjBOL.JobOrderDate);
            param[3] = new SqlParameter("@PORec", ObjBOL.PORec);
            param[4] = new SqlParameter("@OASentTo", ObjBOL.OASentTo);
            param[5] = new SqlParameter("@OASentToContact", ObjBOL.OASentToContact);
            param[6] = new SqlParameter("@QuoteSelected", ObjBOL.QuoteSelected);
            param[7] = new SqlParameter("@JobOrderAck", ObjBOL.JobOrderAck);
            param[8] = new SqlParameter("@JobOADis", ObjBOL.JobOADis);
            param[9] = new SqlParameter("@ProposalID", ObjBOL.ProposalID);
            param[10] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
            param[11] = new SqlParameter("@ModelID", ObjBOL.ModelID);
            param[12] = new SqlParameter("@ConveyorTypeID", ObjBOL.ConveyorTypeID);
            param[13] = new SqlParameter("@ServiceRepID", ObjBOL.ServiceRepID);
            param[14] = new SqlParameter("@ShipperID", ObjBOL.ShipperID);
            param[15] = new SqlParameter("@SiteContact", ObjBOL.SiteContact);
            param[16] = new SqlParameter("@SiteContactTelephone", ObjBOL.SiteContactTelephone);
            param[17] = new SqlParameter("@DateAsBuiltDrgsSent", ObjBOL.DateAsBuiltDrgsSent);
            param[18] = new SqlParameter("@EstReleaseDate", ObjBOL.EstReleaseDate);
            param[19] = new SqlParameter("@ReleaseDate", ObjBOL.ReleaseDate);
            param[20] = new SqlParameter("@TestRunDate", ObjBOL.TestRunDate);
            param[21] = new SqlParameter("@EstCompletionDate", ObjBOL.EstCompletionDate);
            param[22] = new SqlParameter("@ActualCompletionDate", ObjBOL.ActualCompletionDate);
            param[23] = new SqlParameter("@ShipDate", ObjBOL.ShipDate);
            param[24] = new SqlParameter("@ShipToArriveDate", ObjBOL.ShipToArriveDate);
            param[25] = new SqlParameter("@ArrivalDate", ObjBOL.ArrivalDate);
            param[26] = new SqlParameter("@ManualDispatchDate", ObjBOL.ManualDispatchDate);
            param[27] = new SqlParameter("@InstallationBy", ObjBOL.InstallationBy);
            param[28] = new SqlParameter("@InstallDate", ObjBOL.InstallDate);
            param[29] = new SqlParameter("@InstallationCompletionDate", ObjBOL.InstallationCompletionDate);
            param[30] = new SqlParameter("@NoInstallation", ObjBOL.NoInstallation);
            param[31] = new SqlParameter("@DemoDate", ObjBOL.DemoDate);
            param[32] = new SqlParameter("@WarrantyStartDate", ObjBOL.WarrantyStartDate);
            param[33] = new SqlParameter("@WarrantyEndDate", ObjBOL.WarrantyEndDate);
            param[34] = new SqlParameter("@FollowUpDate", ObjBOL.FollowUpDate);
            param[35] = new SqlParameter("@CustCarePackageSendDate", ObjBOL.CustCarePackageSendDate);
            param[36] = new SqlParameter("@PONumber", ObjBOL.PONumber);
            param[37] = new SqlParameter("@InvoiceNumber", ObjBOL.InvoiceNumber);
            param[38] = new SqlParameter("@DateInvoiceSent", ObjBOL.DateInvoiceSent);
            param[39] = new SqlParameter("@DatePaymentReceived", ObjBOL.DatePaymentReceived);
            param[40] = new SqlParameter("@DateCommissionPaid", ObjBOL.DateCommissionPaid);
            param[41] = new SqlParameter("@KflexCheckNumber", ObjBOL.KflexCheckNumber);
            param[42] = new SqlParameter("@CommissionType", ObjBOL.CommissionType);
            param[43] = new SqlParameter("@SalesSourceID", ObjBOL.SalesSourceID);
            param[44] = new SqlParameter("@ProjectDesignerID", ObjBOL.ProjectDesignerID);
            param[45] = new SqlParameter("@DateAssigned", ObjBOL.DateAssigned);
            param[46] = new SqlParameter("@ShipToName", ObjBOL.ShipToName);
            param[47] = new SqlParameter("@ShipToStreet", ObjBOL.ShipToStreet);
            param[48] = new SqlParameter("@ShipToCity", ObjBOL.ShipToCity);
            param[49] = new SqlParameter("@ShipToState", ObjBOL.ShipToState);
            param[50] = new SqlParameter("@ShipToCountry", ObjBOL.ShipToCountry);
            param[51] = new SqlParameter("@ShipToZipCode", ObjBOL.ShipToZipCode);
            param[52] = new SqlParameter("@discount", ObjBOL.discount);
            param[53] = new SqlParameter("@fob", ObjBOL.fob);
            param[54] = new SqlParameter("@term", ObjBOL.term);
            param[55] = new SqlParameter("@IndComDate", ObjBOL.IndComDate);
            param[56] = new SqlParameter("@AeroChequeNum", ObjBOL.AeroChequeNum);
            param[57] = new SqlParameter("@PreInspectionDate", ObjBOL.PreInspectionDate);
            param[58] = new SqlParameter("@CheckedByOffice", ObjBOL.CheckedByOffice);
            param[59] = new SqlParameter("@CheckedByPlant", ObjBOL.CheckedByPlant);
            // param[60] = new SqlParameter("@CancelJob", ObjBOL.CancelJob);
            param[61] = new SqlParameter("@DigitalPicOnServer", ObjBOL.DigitalPicOnServer);
            param[62] = new SqlParameter("@ReferenceDrawing", ObjBOL.ReferenceDrawing);
            param[63] = new SqlParameter("@DealerMember", ObjBOL.DealerMember);
            param[64] = new SqlParameter("@BuyOutCost", ObjBOL.BuyOutCost);
            param[65] = new SqlParameter("@RawMaterial", ObjBOL.RawMaterial);
            param[66] = new SqlParameter("@ExWarrantyPrice", ObjBOL.ExWarrantyPrice);
            param[67] = new SqlParameter("@NetAmount", ObjBOL.NetAmount);
            param[68] = new SqlParameter("@FreightPaid", ObjBOL.FreightPaid);
            param[69] = new SqlParameter("@GST", ObjBOL.GST);
            param[70] = new SqlParameter("@InstallatorA", ObjBOL.InstallatorA);
            param[71] = new SqlParameter("@InstallatorB", ObjBOL.InstallatorB);
            param[72] = new SqlParameter("@InstallatorC", ObjBOL.InstallatorC);
            param[73] = new SqlParameter("@ConCost", ObjBOL.ConCost);
            param[74] = new SqlParameter("@ConRoylAmt", ObjBOL.ConRoylAmt);
            param[75] = new SqlParameter("@ConCheckNo", ObjBOL.ConCheckNo);
            param[76] = new SqlParameter("@ConChqPaidDt", ObjBOL.ConChqPaidDt);
            param[77] = new SqlParameter("@Comments", ObjBOL.Comments);
            param[78] = new SqlParameter("@ReviewedBy", ObjBOL.ReviewedBy);
            param[79] = new SqlParameter("@DrgSentOutforApproval", ObjBOL.DrgSentOutforApproval);
            param[80] = new SqlParameter("@AppDrgWithFieldDimension", ObjBOL.AppDrgWithFieldDimension);
            param[81] = new SqlParameter("@AppDrgAck", ObjBOL.AppDrgAck);
            param[82] = new SqlParameter("@EquipDelConfirmed", ObjBOL.EquipDelConfirmed);
            param[83] = new SqlParameter("@AccReqFromCustomer", ObjBOL.AccReqFromCustomer);
            param[84] = new SqlParameter("@BuiltDrgWithUnderStruSent", ObjBOL.BuiltDrgWithUnderStruSent);
            param[85] = new SqlParameter("@ProjDataPrepBy", ObjBOL.ProjDataPrepBy);
            param[86] = new SqlParameter("@ProjFormReviewByAI", ObjBOL.ProjFormReviewByAI);
            param[87] = new SqlParameter("@ProjFormReviewByHO", ObjBOL.ProjFormReviewByHO);
            param[88] = new SqlParameter("@FabDrgReviewByAI", ObjBOL.FabDrgReviewByAI);
            param[89] = new SqlParameter("@FabDrgReviewByHO", ObjBOL.FabDrgReviewByHO);
            param[90] = new SqlParameter("@PFRBAIDate", ObjBOL.PFRBAIDate);
            param[91] = new SqlParameter("@PFRBHODate", ObjBOL.PFRBHODate);
            param[92] = new SqlParameter("@FDRBAIDate", ObjBOL.FDRBAIDate);
            param[93] = new SqlParameter("@FDRBHODate", ObjBOL.FDRBHODate);
            param[94] = new SqlParameter("@FeedBackConsultant", ObjBOL.FeedBackConsultant);
            param[95] = new SqlParameter("@FeedBackDealer", ObjBOL.FeedBackDealer);
            param[96] = new SqlParameter("@SummofSugg", ObjBOL.SummofSugg);
            //param[98] = new SqlParameter("@SpecCredit", ObjBOL.SpecCredit);        
            param[97] = new SqlParameter("@SpecCredits", ObjBOL.SpecCredits);
            param[98] = new SqlParameter("@SpecCreditPercentID", ObjBOL.SpecCreditPercentID);
            param[99] = new SqlParameter("@SpecCreditAmount", ObjBOL.SpecCreditAmount);
            param[100] = new SqlParameter("@SpecCreditCheckNo", ObjBOL.SpecCreditCheckNo);
            param[101] = new SqlParameter("@SpecCreditPaidDate", ObjBOL.SpecCreditPaidDate);
            param[102] = new SqlParameter("@GSICommissionType", ObjBOL.GSICommissionType);
            param[103] = new SqlParameter("@GSICommissionAmount", ObjBOL.GSICommissionAmount);
            param[104] = new SqlParameter("@GSICommissionCheckNo", ObjBOL.GSICommissionCheckNo);
            param[105] = new SqlParameter("@GSICommissionSentDate", ObjBOL.GSICommissionSentDate);
            //Pfile Columns           
            param[106] = new SqlParameter("@DealerID", ObjBOL.DealerID);
            //param[109] = new SqlParameter("@ConveyorTypeID", ObjBOL.ConveyorTypeID);
            param[107] = new SqlParameter("@OriginRepID", ObjBOL.OriginRepID);
            param[108] = new SqlParameter("@ConsultRepID", ObjBOL.ConsultRepID);
            param[109] = new SqlParameter("@RepID", ObjBOL.RepID);
            param[110] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
            param[111] = new SqlParameter("@Price", ObjBOL.Price);
            param[112] = new SqlParameter("@Freight", ObjBOL.Freight);
            param[113] = new SqlParameter("@Installation", ObjBOL.Installation);
            param[114] = new SqlParameter("@CurrencyID", ObjBOL.CurrencyID);
            param[115] = new SqlParameter("@CurrentStatus", ObjBOL.CurrentStatus);
            param[116] = new SqlParameter("@OrderProbabilityID", ObjBOL.OrderProbabilityID);
            param[117] = new SqlParameter("@DetailedQuote", ObjBOL.DetailedQuote);
            param[118] = new SqlParameter("@Specifications", ObjBOL.Specifications);
            param[119] = new SqlParameter("@DPics", ObjBOL.DPics);
            param[120] = new SqlParameter("@RefDrawing", ObjBOL.RefDrawing);
            param[121] = new SqlParameter("@EqDisAmount", ObjBOL.EqDisAmount);
            param[122] = new SqlParameter("@EqDiscount", ObjBOL.EqDiscount);
            param[123] = new SqlParameter("@NetEqPrice", ObjBOL.NetEqPrice);
            param[124] = new SqlParameter("@OrderBelongsToDELETE", ObjBOL.OrderBelongsToDELETE);
            param[125] = new SqlParameter("@MfgFacilityID", ObjBOL.MfgFacilityID);
            param[126] = new SqlParameter("@ConsultantMemberId", ObjBOL.ConsultantMemberId);
            param[127] = new SqlParameter("@operation", ObjBOL.Operation);
            param[128] = new SqlParameter("@DueDateCanada", ObjBOL.DueDateCanada);
            param[129] = new SqlParameter("@FabSentToCanada", ObjBOL.FabSentToCanada);
            param[130] = new SqlParameter("@EngineerCanada", ObjBOL.EngineerCanada);
            param[131] = new SqlParameter("@ReleasedToNesting", ObjBOL.ReleasedToNesting);
            param[132] = new SqlParameter("@ReleasedToShop", ObjBOL.ReleasedToShop);
            param[133] = new SqlParameter("@ProjectStatus", ObjBOL.ProjectStatus);
            param[134] = new SqlParameter("@ExistingJobID", ObjBOL.ExistingJobID);
            param[135] = new SqlParameter("@JobType", ObjBOL.JobType);
            param[136] = new SqlParameter("@projectmanager", ObjBOL.ProjectManager);
            param[137] = new SqlParameter("@ShippingCommit", ObjBOL.ShippingCommit);
            param[138] = new SqlParameter("@ProjectCommissionText", ObjBOL.ProjectCommNotes);
            param[139] = new SqlParameter("@NestingStatus", ObjBOL.NestingStatus);
            param[140] = new SqlParameter("@ShipStatus", ObjBOL.ShipStatus);
            param[141] = new SqlParameter("@UserID", ObjBOL.UserID);
            param[142] = new SqlParameter("@CashDisAmt", ObjBOL.CashDisAmt);
            param[143] = new SqlParameter("@CashDisPer", ObjBOL.CashDisPer);
            param[144] = new SqlParameter("@CashAmtRec", ObjBOL.CashAmtRec);
            param[145] = new SqlParameter("@AmountForComission", ObjBOL.AmountForComission);
            param[146] = new SqlParameter("@PMPack", ObjBOL.PMPack);
            param[147] = new SqlParameter("@Status", ObjBOL.Status);
            param[148] = new SqlParameter("@ExpectedArrivalDatefromChina", ObjBOL.ExpectedArrivalDatefromChina);
            param[149] = new SqlParameter("@PurchasedItems", ObjBOL.PurchasedItems);
            param[150] = new SqlParameter("@PurchasedItemsCAD", ObjBOL.PurchasedItemsCAD);
            param[151] = new SqlParameter("@Issued", ObjBOL.Issued);
            param[152] = new SqlParameter("@ProjectDesignerChinaID", ObjBOL.ProjectDesignerChinaID);
            param[153] = new SqlParameter("@ReleaseDateChina", ObjBOL.ReleaseDateChina);
            param[154] = new SqlParameter("@DateAssignedChina", ObjBOL.DateAssignedChina);
            param[155] = new SqlParameter("@FabSentToCanada_China", ObjBOL.FabSentToCanada_China);
            param[156] = new SqlParameter("@filepath", ObjBOL.fileName);
            param[157] = new SqlParameter("@ShipDateFromChina", ObjBOL.ShipDateFromChina);
            param[158] = new SqlParameter("@ContainerNo", ObjBOL.ContainerNo);
            param[159] = new SqlParameter("@CorrectedBy", ObjBOL.CorrectedBy);
            param[160] = new SqlParameter("@ProductionStatus", ObjBOL.ProductionStatus);
            param[161] = new SqlParameter("@ProductionRemarks", ObjBOL.ProductionRemarks);
            param[162] = new SqlParameter("@ProjectReviewerChinaID", ObjBOL.ProjectReviewerChinaID);
            param[163] = new SqlParameter("@FabDrawingPercentage", ObjBOL.FabDrawingPercentage);
            param[164] = new SqlParameter("@ExpectedSubmissionDate", ObjBOL.ExpectedSubmissionDate);
            param[165] = new SqlParameter("@ActualSubmissionDate", ObjBOL.ActualSubmissionDate);
            param[166] = new SqlParameter("@WarehouseId", ObjBOL.WarehouseId);
            //ProjectStatus
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageProjectsEng]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public string SaveFileName(BOLManageProjects ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@operation", ObjBOL.Operation);
            param[3] = new SqlParameter("@filepath", ObjBOL.fileName);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageProjectsEng]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        //CheckEmployeeLogin
        public string CheckEmployeeLogin(BOLManageProjects ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@UserID", ObjBOL.UserID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageProjectsEng]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetProject(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@ProjectName", ObjBOL.ProjectName);
                param[3] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
                param[4] = new SqlParameter("@ProposalID", ObjBOL.ProposalID);
                param[5] = new SqlParameter("@JobID", ObjBOL.JobID);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjectsEng", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        //GetFilePath
        public DataSet GetFilePath(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@JobID", ObjBOL.JobID);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjectsEng", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        public string GetProjectStatus(BOLManageProjects ObjBOL)
        {
            string ProjectStatus = string.Empty;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@JobID", ObjBOL.JobID);
                param[3] = new SqlParameter("@UserID", ObjBOL.UserID);
                SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjectsEng", param);
                ProjectStatus = param[0].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ProjectStatus;
        }

        public DataSet FillControls(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjectsEng", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }

    public class DALDealers : Connection
    {
        public DataSet GetDealers(BOLDealers ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", 1);

            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageRebatesDealers", param);
            return ds;
        }
    }
    public class DALManageCustomerProjectRepairDetails : Connection
    {
        //Customer Care Repair Form Drop Down Lists Operation
        public DataSet GetCustCareRepairData(BOLCustCareRepairForm ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_CustCare_ProjectRepairDetails", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        //Ticket Generation
        public string GetTicketDetails(BOLCustCareRepairForm ObjBOL)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@TJobID", ObjBOL.TJobID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_CustCare_ProjectRepairDetails", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        public String SaveCustomerRepairServiceData(BOLCustCareRepairForm ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@TJobID", ObjBOL.TJobID);
            param[2] = new SqlParameter("@TicketNo", ObjBOL.TicketNo);
            param[3] = new SqlParameter("@Task", ObjBOL.Task);
            param[4] = new SqlParameter("@Issue", ObjBOL.Issue);
            param[5] = new SqlParameter("@IssueOpenDate", ObjBOL.IssueOpenDate);
            param[6] = new SqlParameter("@PromisedDate", ObjBOL.PromisedDate);
            param[7] = new SqlParameter("@IssueCloseDate", ObjBOL.IssueCloseDate);
            param[8] = new SqlParameter("@Status", ObjBOL.Status);
            param[9] = new SqlParameter("@AssignTo", ObjBOL.AssignTo);
            param[10] = new SqlParameter("@FollowUpDate", ObjBOL.FollowUpDate);
            param[11] = new SqlParameter("@ServicePO", ObjBOL.ServicePO);
            param[12] = new SqlParameter("@HobartServiceBranch", ObjBOL.HobartServiceBranch);
            param[13] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_CustCare_ProjectRepairDetails", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet DisplayCustomerRepairServiceData(BOLCustCareRepairForm ObjBOL)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@TJobID", ObjBOL.TJobID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_CustCare_ProjectRepairDetails", param);
            return ds;
        }
        public DataSet DisplayCustomerRepairServiceDataRowWise(BOLCustCareRepairForm ObjBOL)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@TicketNo", ObjBOL.TicketNo);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_CustCare_ProjectRepairDetails", param);
            return ds;
        }
        public DataSet DisplayCustomerRepairJobInformation(BOLCustCareRepairForm ObjBOL)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@TJobID", ObjBOL.TJobID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_CustCare_ProjectRepairDetails", param);
            return ds;
        }
    }

    public class DALSiteVisitInformation : Connection
    {
        public DataSet Return_DataSet(BOLSiteVisitInformation ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[17];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@PNumber", ObjBOL.PNumber);
            param[2] = new SqlParameter("@PurposeID", ObjBOL.PurposeID);
            param[3] = new SqlParameter("@RegionID", ObjBOL.RegionID);
            param[4] = new SqlParameter("@SiteAddress", ObjBOL.SiteAddress);
            param[5] = new SqlParameter("@CountryID", ObjBOL.CountryID);
            param[6] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[7] = new SqlParameter("@City", ObjBOL.City);
            param[8] = new SqlParameter("@SiteVisitDate", ObjBOL.SiteVisitDate);
            param[9] = new SqlParameter("@SiteContactName", ObjBOL.SiteContactName);
            param[10] = new SqlParameter("@SiteContactNumber", ObjBOL.SiteContactNumber);
            param[11] = new SqlParameter("@ID", ObjBOL.ID);
            param[12] = new SqlParameter("@Remarks", ObjBOL.Remarks);
            param[13] = new SqlParameter("@EmployeeIDs", ObjBOL.EmployeeIDs);
            param[14] = new SqlParameter("@NextVisitDate", ObjBOL.NextVisitDate);
            param[15] = new SqlParameter("@SameAsProjectLocation", ObjBOL.SameAsProjectLocation);
            param[16] = new SqlParameter("@RequestorID", ObjBOL.RequestorID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManageSiteVisitInformation]", param);
            return ds;
        }

        public string Return_String(BOLSiteVisitInformation ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[18];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PNumber", ObjBOL.PNumber);
            param[3] = new SqlParameter("@PurposeID", ObjBOL.PurposeID);
            param[4] = new SqlParameter("@RegionID", ObjBOL.RegionID);
            param[5] = new SqlParameter("@SiteAddress", ObjBOL.SiteAddress);
            param[6] = new SqlParameter("@CountryID", ObjBOL.CountryID);
            param[7] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[8] = new SqlParameter("@City", ObjBOL.City);
            param[9] = new SqlParameter("@SiteVisitDate", ObjBOL.SiteVisitDate);
            param[10] = new SqlParameter("@SiteContactName", ObjBOL.SiteContactName);
            param[11] = new SqlParameter("@SiteContactNumber", ObjBOL.SiteContactNumber);
            param[12] = new SqlParameter("@ID", ObjBOL.ID);
            param[13] = new SqlParameter("@Remarks", ObjBOL.Remarks);
            param[14] = new SqlParameter("@EmployeeIDs", ObjBOL.EmployeeIDs);
            param[15] = new SqlParameter("@NextVisitDate", ObjBOL.NextVisitDate);
            param[16] = new SqlParameter("@SameAsProjectLocation", ObjBOL.SameAsProjectLocation);
            param[17] = new SqlParameter("@RequestorID", ObjBOL.RequestorID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ManageSiteVisitInformation]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALAppSetting : Connection
    {
        public DataSet Return_DataSet(BOLAppSetting ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ID", ObjBOL.ID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManageAppSetting]", param);
            return ds;
        }

        public string Return_String(BOLAppSetting ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 5);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ID", ObjBOL.ID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ManageAppSetting]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }
    //DAL Customer Care Manage Tickets
    public class DALManageTickets : Connection
    {
        public DataSet BindDropDownManageTickets(BOLManageTickets ObjBOL)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_CustCare_ManageTickets", param);
            return ds;
        }

        public DataSet GetTicketInfo(BOLManageTickets ObjBOL)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@TicketNo", ObjBOL.TicketNo);
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_CustCare_ManageTickets", param);
            return ds;
        }

        public DataSet GetTicketSummInfo(BOLManageTickets ObjBOL)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@RepairID", ObjBOL.RepairID);
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_CustCare_ManageTickets", param);
            return ds;
        }
        public string SaveTicketSummary(BOLManageTickets ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@RepairID", ObjBOL.RepairID);
            param[3] = new SqlParameter("@SummDate", ObjBOL.SummDate);
            param[4] = new SqlParameter("@Summary", ObjBOL.Summary);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_CustCare_ManageTickets]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public string UpdateTicketSummary(BOLManageTickets ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@RepairID", ObjBOL.RepairID);
            param[3] = new SqlParameter("@id", ObjBOL.id);
            param[4] = new SqlParameter("@SummDate", ObjBOL.SummDate);
            param[5] = new SqlParameter("@Summary", ObjBOL.Summary);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_CustCare_ManageTickets]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALWasteEq_New : Connection
    {
        public DataSet Return_DataSet(BOLWasteEq_New ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ID", ObjBOL.Id);
            param[2] = new SqlParameter("@ManufacturerId", ObjBOL.ManufacturerId);
            param[3] = new SqlParameter("@WasteEqId", ObjBOL.WasteEqId);
            param[4] = new SqlParameter("@AccessoryId", ObjBOL.AccessoryId);
            param[5] = new SqlParameter("@UsedFromStock", ObjBOL.UsedFromStock);
            param[6] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[7] = new SqlParameter("@TrackingNo", ObjBOL.TrackingNo);
            param[8] = new SqlParameter("@ServiceProvider", ObjBOL.ServiceProvider);
            param[9] = new SqlParameter("@EstimatedDeliveryDate", ObjBOL.EstimatedDeliveryDate);
            param[10] = new SqlParameter("@RequestedByShop", ObjBOL.RequestedByShop);
            param[11] = new SqlParameter("@ReceivedDate", ObjBOL.ReceivedDate);
            param[12] = new SqlParameter("@Remarks", ObjBOL.Remarks);
            param[13] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeId);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManageWasteEqDetails_New]", param);
            return ds;
        }

        public string Return_String(BOLWasteEq_New ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ID", ObjBOL.Id);
            param[2] = new SqlParameter("@ManufacturerId", ObjBOL.ManufacturerId);
            param[3] = new SqlParameter("@WasteEqId", ObjBOL.WasteEqId);
            param[4] = new SqlParameter("@AccessoryId", ObjBOL.AccessoryId);
            param[5] = new SqlParameter("@UsedFromStock", ObjBOL.UsedFromStock);
            param[6] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[7] = new SqlParameter("@TrackingNo", ObjBOL.TrackingNo);
            param[8] = new SqlParameter("@ServiceProvider", ObjBOL.ServiceProvider);
            param[9] = new SqlParameter("@EstimatedDeliveryDate", ObjBOL.EstimatedDeliveryDate);
            param[10] = new SqlParameter("@RequestedByShop", ObjBOL.RequestedByShop);
            param[11] = new SqlParameter("@ReceivedDate", ObjBOL.ReceivedDate);
            param[12] = new SqlParameter("@Remarks", ObjBOL.Remarks);
            param[13] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeId);
            param[14] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[14].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ManageWasteEqDetails_New]", param);
            string msg = param[14].Value.ToString();
            return msg;
        }
    }

    //Waste Eq Details
    public class DALManageWasteEqDetails : Connection
    {
        public DataSet BindDropDownDetails(BOLWasteEq ObjBOL)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_CustCare_WasteEqDetails", param);
            return ds;
        }
        public DataSet FillDetails(BOLWasteEq ObjBOL)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[3] = new SqlParameter("@WasteEq_id", ObjBOL.WasteEq_id);
            param[4] = new SqlParameter("@Detailid", ObjBOL.Detailid);
            param[5] = new SqlParameter("@makerid", ObjBOL.makerid);
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_CustCare_WasteEqDetails", param);
            return ds;
        }
        public DataSet GetWasteEquipment(BOLWasteEq ObjBOL)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Makerid", ObjBOL.makerid);
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_CustCare_WasteEqDetails", param);
            return ds;
        }
        public DataSet GetWasteEqAcc(BOLWasteEq ObjBOL)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@WasteEq_id", ObjBOL.WasteEq_id);
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_CustCare_WasteEqDetails", param);
            return ds;
        }
        public string SaveWasteEqDetail(BOLWasteEq ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@JobID", ObjBOL.JobID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_CustCare_WasteEqDetails]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public string SaveWasteEqSummary(BOLWasteEq ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[3] = new SqlParameter("@makerid", ObjBOL.makerid);
            param[4] = new SqlParameter("@eqid", ObjBOL.eqid);
            param[5] = new SqlParameter("@accid", ObjBOL.accid);
            param[6] = new SqlParameter("@usedfromstock", ObjBOL.usedfromstock);
            param[7] = new SqlParameter("@remarks", ObjBOL.remarks);
            param[8] = new SqlParameter("@Employeeid", ObjBOL.Employeeid);
            param[9] = new SqlParameter("@id", ObjBOL.id);
            param[10] = new SqlParameter("@requestondate", ObjBOL.requestondate);
            param[11] = new SqlParameter("@trackingno", ObjBOL.TrackingNo);
            param[12] = new SqlParameter("@estimatdeliverydate", ObjBOL.estimatdeliverydate);
            param[13] = new SqlParameter("@reqbyshopon", ObjBOL.requestonshopon);
            param[14] = new SqlParameter("@acc_recieved", ObjBOL.acc_recieved);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_CustCare_WasteEqDetails]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }
    // Stock Adjustments
    public class DALManageStockAdjustment : Connection
    {
        public DataSet GetStockAdjustmentDropDownData(BOLStockAdjustment ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Makerid", ObjBOL.Makerid);
            param[3] = new SqlParameter("@WasteEqid", ObjBOL.WasteEqid);
            param[4] = new SqlParameter("@accessory", ObjBOL.accessory);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_CustCare_StockAdjustments", param);
            return ds;
        }
        public string SaveStockAdjustmentData(BOLStockAdjustment ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@manuf", ObjBOL.manuf);
            param[3] = new SqlParameter("@wasteeq", ObjBOL.wasteeq);
            param[4] = new SqlParameter("@accessory", ObjBOL.accessory);
            param[5] = new SqlParameter("@stockinhand", ObjBOL.stockinhand);
            param[6] = new SqlParameter("@stockin", ObjBOL.stockin);
            param[7] = new SqlParameter("@stockinby", ObjBOL.stockinby);
            param[8] = new SqlParameter("@stockindate", ObjBOL.stockindate);
            param[9] = new SqlParameter("@stockinoption", ObjBOL.stockinoption);
            param[10] = new SqlParameter("@summary", ObjBOL.summary);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_CustCare_StockAdjustments", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALManageActiveRepSales : Connection
    {
        public string SaveRepActiveSales(BOLRepActiveSales ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[19];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@BranchID", ObjBOL.BranchID);
            param[2] = new SqlParameter("@FirstName", ObjBOL.FirstName);
            param[3] = new SqlParameter("@LastName", ObjBOL.LastName);
            param[4] = new SqlParameter("@Abbreviationid", ObjBOL.AbbreviationID);
            param[5] = new SqlParameter("@Email", ObjBOL.Email);
            param[6] = new SqlParameter("@phone", ObjBOL.Phone);
            param[7] = new SqlParameter("@fax", ObjBOL.Fax);
            param[8] = new SqlParameter("@cellphone", ObjBOL.CellPhone);
            param[9] = new SqlParameter("@phonemail", ObjBOL.PhoneMail);
            param[10] = new SqlParameter("@status", ObjBOL.Status);
            param[11] = new SqlParameter("@homeoffice", ObjBOL.HomeOffice);
            param[12] = new SqlParameter("@homeaddress", ObjBOL.HomeAddress);
            param[13] = new SqlParameter("@homecity", ObjBOL.HomeCity);
            param[14] = new SqlParameter("@homestate", ObjBOL.HomeState);
            param[15] = new SqlParameter("@homepostalcode", ObjBOL.HomePostalCode);
            param[16] = new SqlParameter("@homephone", ObjBOL.HomePhone);
            param[17] = new SqlParameter("@homefax", ObjBOL.HomeFax);
            param[18] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageRepSales", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetRepActiveSales(BOLRepActiveSales ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@BranchID", ObjBOL.BranchID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageRepSales", param);
            return ds;
        }
    }
    //Exception Class DAL
    public class DALException : Connection
    {
        public String SaveException(BOLException ObjBOLException)
        {
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Action", ObjBOLException.Action);
            param[2] = new SqlParameter("@module_name", ObjBOLException.module_name);
            param[3] = new SqlParameter("@source", ObjBOLException.source);
            param[4] = new SqlParameter("@message", ObjBOLException.message);
            param[5] = new SqlParameter("@data", ObjBOLException.data);
            param[6] = new SqlParameter("@target_site", ObjBOLException.target_site);
            param[7] = new SqlParameter("@stack_trace", ObjBOLException.stack_trace);
            param[8] = new SqlParameter("@date", ObjBOLException.date);
            param[9] = new SqlParameter("@counts", ObjBOLException.counts);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_AddEditException", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }
    //Start DAL
    public class DALSalesRepGroup : Connection
    {
        public DataSet GetSalesReport(BOLSalesRepGroup ObjBOLSalesReport)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@companyname", ObjBOLSalesReport.companyname);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Get_SalesRepGroup", param);
            return ds;
        }
    }
    //START DAL Proposal Search
    public class DALProposalSearch : Connection
    {
        public DataSet GetProposalSearch(BOLProposalSearch ObjBOLProposalSearch)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOLProposalSearch.Operation);
            param[2] = new SqlParameter("@country", ObjBOLProposalSearch.country);
            param[3] = new SqlParameter("@SearchVar", ObjBOLProposalSearch.SearchVar);
            param[4] = new SqlParameter("@PNumber", ObjBOLProposalSearch.PNumber);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_GetProposal", param);
            return ds;
        }
    }

    //START DAL Project Search
    public class DALProjectSearch : Connection
    {
        public DataSet GetProjectSearch(BOLProjectSearch ObjBOLProjectSearch)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOLProjectSearch.Operation);
            param[2] = new SqlParameter("@SearchVar", ObjBOLProjectSearch.SearchVar);
            param[3] = new SqlParameter("@JobID", ObjBOLProjectSearch.JobID);
            param[4] = new SqlParameter("@country", ObjBOLProjectSearch.country);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Get_SearchProjects", param);
            return ds;
        }
    }
    //START DAL Shop Drawing    
    public class DALShpDrg : Connection
    {
        public DataSet GetDataShpDrg(BOLShpDrg ObjBOLShpDrg)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOLShpDrg.Operation);
            param[2] = new SqlParameter("@sDrgNum", ObjBOLShpDrg.sDrgNum);
            param[3] = new SqlParameter("@JobID", ObjBOLShpDrg.JobID);
            param[4] = new SqlParameter("@sDrgJID", ObjBOLShpDrg.sDrgJID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjects", param);
            return ds;
        }
        public String SaveDataShpDrg(BOLShpDrg ObjBOLShpDrg)
        {
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@sDrgNum", ObjBOLShpDrg.sDrgNum);
            param[2] = new SqlParameter("@sDrgJID", ObjBOLShpDrg.sDrgJID);
            param[3] = new SqlParameter("@sDrgWantDate", ObjBOLShpDrg.sDrgWantDate);
            param[4] = new SqlParameter("@sDrgPromiseDate", ObjBOLShpDrg.sDrgPromiseDate);
            param[5] = new SqlParameter("@sDrgExpecApprovalDate", ObjBOLShpDrg.sDrgExpecApprovalDate);
            param[6] = new SqlParameter("@sDrgSentToRCD", ObjBOLShpDrg.sDrgSentToRCD);
            param[7] = new SqlParameter("@sDrgAppDate", ObjBOLShpDrg.sDrgAppDate);
            param[8] = new SqlParameter("@sNextFolowupDate", ObjBOLShpDrg.sNextFolowupDate);
            param[9] = new SqlParameter("@sDateFollowedUp", ObjBOLShpDrg.sDateFollowedUp);
            param[10] = new SqlParameter("@sDrgComment", ObjBOLShpDrg.sDrgComment);
            param[11] = new SqlParameter("@sDateReleasedToFab", ObjBOLShpDrg.sDateReleasedToFab);
            param[12] = new SqlParameter("@Operation", ObjBOLShpDrg.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageProjects", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }
    //End DAL Shop Drawings
    public class DALMenu : Connection
    {
        public DataSet GetMenu(BOLMenu ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", ObjBOL.id);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_DynamicMenu", param);
            return ds;

        }
    }

    public class DALManageLogs : Connection
    {
        public string SaveLogs(BOLManageLogs ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@userid", ObjBOL.userid);
            param[2] = new SqlParameter("@formname", ObjBOL.formname);
            param[3] = new SqlParameter("@logoperation", ObjBOL.logoperation);
            param[4] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[5] = new SqlParameter("@pk", ObjBOL.pk);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageLogs", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }


    public class DALManageProposals : Connection
    {
        //SaveFollowUp
        public string SaveFollowUp(BOLManageProposals ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ProposalNo", ObjBOL.FProposalNumber);
            param[2] = new SqlParameter("@followupwith", ObjBOL.FFollowUpWith);
            param[3] = new SqlParameter("@followupdate", ObjBOL.FFollowUpDate);
            param[4] = new SqlParameter("@followedupdate", ObjBOL.FFollowedUpDate);
            param[5] = new SqlParameter("@notesFollowup", ObjBOL.FNotes);
            param[6] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[7] = new SqlParameter("@Followupid", ObjBOL.Followupid);
            param[8] = new SqlParameter("@nextfollowupdate", ObjBOL.FNextFollowedUpDate);
            param[9] = new SqlParameter("@showninreports", ObjBOL.Fshowninreports);
            param[10] = new SqlParameter("@followupNature", ObjBOL.FFollowUpNature);
            param[11] = new SqlParameter("@ExpectedPOReceivedDate", ObjBOL.FExpectedPOReceivedDate);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageProposals]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        //DeleteFollowUpRecord
        public string DeleteFollowUpRecord(BOLManageProposals ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Followupid", ObjBOL.Followupid);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageProposals]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        //SaveProDrawings
        public string SaveProDrawings(BOLManageProposals ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PNumber", ObjBOL.PNumber);
            param[3] = new SqlParameter("@pDrgNum", ObjBOL.pDrgNum);
            param[4] = new SqlParameter("@pEngID", ObjBOL.pEngID);
            param[5] = new SqlParameter("@pReqByRcd", ObjBOL.pReqByRcd);
            param[6] = new SqlParameter("@pReqFwdtoCAD", ObjBOL.pReqFwdtoCAD);
            param[7] = new SqlParameter("@pDwgSenttoManager", ObjBOL.pDwgSenttoManager);
            param[8] = new SqlParameter("@pDwgFwdtoRCD", ObjBOL.pDwgFwdtoRCD);
            param[9] = new SqlParameter("@Remarks", ObjBOL.Remarks);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageProposals]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        //DeleteProDrgRecord
        public string DeleteProDrgRecord(BOLManageProposals ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ProDwgid", ObjBOL.ProDwgid);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageProposals]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public string SaveProposal(BOLManageProposals ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[109];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@PNumber", ObjBOL.PNumber);
            param[2] = new SqlParameter("@ProjectName", ObjBOL.ProjectName);
            param[3] = new SqlParameter("@City", ObjBOL.City);
            param[4] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[5] = new SqlParameter("@Price", ObjBOL.Price);
            param[6] = new SqlParameter("@Freight", ObjBOL.Freight);
            param[7] = new SqlParameter("@Installation", ObjBOL.Installation);
            param[8] = new SqlParameter("@CurrencyID", ObjBOL.CurrencyID);
            param[9] = new SqlParameter("@ProposalDate", ObjBOL.ProposalDate);
            param[10] = new SqlParameter("@QuoteRequired", ObjBOL.QuoteRequired);
            param[11] = new SqlParameter("@DrqRequired", ObjBOL.DrqRequired);
            param[12] = new SqlParameter("@HobartIssTag", ObjBOL.HobartIssTag);
            param[13] = new SqlParameter("@QuoteSTERO", ObjBOL.QuoteSTERO);
            param[14] = new SqlParameter("@QuoteID", ObjBOL.QuoteID);
            param[15] = new SqlParameter("@QuoteReqDate", ObjBOL.QuoteReqDate);
            param[16] = new SqlParameter("@QuoteAckDate", ObjBOL.QuoteAckDate);
            param[17] = new SqlParameter("@QuotePrepDate", ObjBOL.QuotePrepDate);
            param[18] = new SqlParameter("@QuoteSentDate", ObjBOL.QuoteSentDate);
            param[19] = new SqlParameter("@ShpDrgNum", ObjBOL.ShpDrgNum);
            param[20] = new SqlParameter("@ProjectDesignerID", ObjBOL.ProjectDesignerID);
            param[21] = new SqlParameter("@OriginRepID", ObjBOL.OriginRepID);
            param[22] = new SqlParameter("@ConsultRepID", ObjBOL.ConsultRepID);
            param[23] = new SqlParameter("@InitialRepId", ObjBOL.InitialRepId);
            param[24] = new SqlParameter("@RepID", ObjBOL.RepID);
            param[25] = new SqlParameter("@ModelID", ObjBOL.ModelID);
            param[26] = new SqlParameter("@ConveyorTypeID", ObjBOL.ConveyorTypeID);
            param[27] = new SqlParameter("@PrimeSpec", ObjBOL.PrimeSpec);
            param[28] = new SqlParameter("@Specifications", ObjBOL.Specifications);
            param[29] = new SqlParameter("@DetailedQuote", ObjBOL.DetailedQuote);
            param[30] = new SqlParameter("@OrderProbabilityID", ObjBOL.OrderProbabilityID);
            param[31] = new SqlParameter("@SalesCategoryID", ObjBOL.SalesCategoryID);
            param[32] = new SqlParameter("@EstimatedEquipmentWantDate", ObjBOL.EstimatedEquipmentWantDate);
            param[33] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
            param[34] = new SqlParameter("@DealerID", ObjBOL.DealerID);
            param[35] = new SqlParameter("@Notes", ObjBOL.Notes);
            param[36] = new SqlParameter("@Compitetor", ObjBOL.Compitetor);
            param[37] = new SqlParameter("@LostedReason", ObjBOL.LostedReason);
            param[38] = new SqlParameter("@CurrentStatus", ObjBOL.CurrentStatus);
            param[39] = new SqlParameter("@Country", ObjBOL.Country);
            // param[40] = new SqlParameter("@Specification", ObjBOL.Specification);
            param[40] = new SqlParameter("@DPics", ObjBOL.DPics);
            param[41] = new SqlParameter("@RefDrawing", ObjBOL.RefDrawing);
            param[42] = new SqlParameter("@EqDiscount", ObjBOL.EqDiscount);
            param[43] = new SqlParameter("@EqDisAmount", ObjBOL.EqDisAmount);
            param[44] = new SqlParameter("@NetEqPrice", ObjBOL.NetEqPrice);
            param[45] = new SqlParameter("@SiteFloor", ObjBOL.SiteFloor);
            param[46] = new SqlParameter("@Comment", ObjBOL.Comment);
            param[47] = new SqlParameter("@PreparedBy", ObjBOL.PreparedBy);
            param[48] = new SqlParameter("@IsGillProject", ObjBOL.IsGillProject);
            param[49] = new SqlParameter("@SpecCredits", ObjBOL.SpecCredits);
            param[50] = new SqlParameter("@SpecCreditPercentID", ObjBOL.SpecCreditPercentID);
            param[51] = new SqlParameter("@SpecCreditAmount", ObjBOL.SpecCreditAmount);
            param[52] = new SqlParameter("@SpecCreditCheckNo", ObjBOL.SpecCreditCheckNo);
            param[53] = new SqlParameter("@SpecCreditPaidDate", ObjBOL.SpecCreditPaidDate);
            param[54] = new SqlParameter("@ConsultantMemberId", ObjBOL.ConsultantMemberID);
            param[55] = new SqlParameter("@alternate1", ObjBOL.alternate1);
            param[56] = new SqlParameter("@alternate2", ObjBOL.alternate2);
            param[57] = new SqlParameter("@alternate3", ObjBOL.alternate3);
            param[58] = new SqlParameter("@operation", ObjBOL.Operation);
            param[59] = new SqlParameter("@orderbelongsto", ObjBOL.OrderBelongsTo);

            param[60] = new SqlParameter("@dishwasherprimespec", ObjBOL.dishwasherprimespec);
            param[61] = new SqlParameter("@dishwasherprimespecother", ObjBOL.dishwasherprimespecother);

            param[62] = new SqlParameter("@dishmachinetype", ObjBOL.dishmachinetype);
            param[63] = new SqlParameter("@dishmachinetypeother", ObjBOL.dishmachinetypeother);

            param[64] = new SqlParameter("@dishwashermodel", ObjBOL.dishmachinemodel);
            param[65] = new SqlParameter("@dishwashermodelother", ObjBOL.dishwashermodelother);

            param[66] = new SqlParameter("@dishmachinestyle", ObjBOL.dishmachinestyle);
            param[67] = new SqlParameter("@dishmachinestyleother", ObjBOL.dishmachinestyleother);

            param[68] = new SqlParameter("@dishwasheralternate", ObjBOL.dishwasheralternate);
            param[69] = new SqlParameter("@dishwasheralternateother", ObjBOL.dishwasheralternateother);

            param[70] = new SqlParameter("@dishmachinetypealternate", ObjBOL.dishmachinetypealternate);
            param[71] = new SqlParameter("@dishmachinetypealternateother", ObjBOL.dishmachinetypealternateother);

            param[72] = new SqlParameter("@dishwashermodelalternate", ObjBOL.dishwashermodelalternate);
            param[73] = new SqlParameter("@dishwashermodelalternateother", ObjBOL.dishwashermodelalternateother);

            param[74] = new SqlParameter("@dishmachinestylealternate", ObjBOL.dishmachinestylealternate);
            param[75] = new SqlParameter("@dishmachinestylealternateother", ObjBOL.dishmachinestylealternateother);

            param[76] = new SqlParameter("@wasteeqprimespec", ObjBOL.wasteeqprimespec);
            param[77] = new SqlParameter("@wasteeqprimespecother", ObjBOL.wasteeqprimespecother);

            param[78] = new SqlParameter("@wasteeqtype", ObjBOL.wasteeqtype);
            param[79] = new SqlParameter("@wasteeqtypeother", ObjBOL.wasteeqtypeother);

            param[80] = new SqlParameter("@wasteeqmodel", ObjBOL.wasteeqmodel);
            param[81] = new SqlParameter("@wasteeqmodelother", ObjBOL.wasteeqmodelother);

            param[82] = new SqlParameter("@wasteeqstyle", ObjBOL.wasteeqstyle);
            param[83] = new SqlParameter("@wasteeqstyleother", ObjBOL.wasteeqstyleother);

            param[84] = new SqlParameter("@wasteeqalternate", ObjBOL.wasteeqalternate);
            param[85] = new SqlParameter("@wasteeqalternateother", ObjBOL.wasteeqalternateother);

            param[86] = new SqlParameter("@wasteeqalternatetype", ObjBOL.wasteeqalternatetype);
            param[87] = new SqlParameter("@wasteeqalternatetypeother", ObjBOL.wasteeqalternatetypeother);

            param[88] = new SqlParameter("@wasteeqmodelalternate", ObjBOL.wasteeqmodelalternate);
            param[89] = new SqlParameter("@wasteeqmodelalternateother", ObjBOL.wasteeqmodelalternateother);

            param[90] = new SqlParameter("@wasteeqstylealternate", ObjBOL.wasteeqstylealternate);
            param[91] = new SqlParameter("@wasteeqstylealternateother", ObjBOL.wasteeqstylealternateother);

            param[92] = new SqlParameter("@JobType", ObjBOL.JobType);
            param[93] = new SqlParameter("@ExistingJobID", ObjBOL.ExistingJobID);

            param[94] = new SqlParameter("@shipdate", ObjBOL.shipdate);
            param[95] = new SqlParameter("@biddate", ObjBOL.biddate);

            param[96] = new SqlParameter("@bidproject", ObjBOL.bidproject);
            param[97] = new SqlParameter("@projectmanagerid", ObjBOL.projectmanagerid);

            param[98] = new SqlParameter("@conveyoralternate", ObjBOL.conveyoralternate);
            param[99] = new SqlParameter("@conveyoralternateother", ObjBOL.conveyoralternateother);

            param[100] = new SqlParameter("@conveyorprimespec", ObjBOL.conveyorprimespec);
            param[101] = new SqlParameter("@conveyorprimespecother", ObjBOL.conveyorprimespecother);

            param[102] = new SqlParameter("@dealermemberid", ObjBOL.dealermemberid);
            param[103] = new SqlParameter("@sourceleadid", ObjBOL.sourceleadid);

            param[104] = new SqlParameter("@Sourceleadref", ObjBOL.sourceleadref);

            param[105] = new SqlParameter("@PriceProtection", ObjBOL.PriceProtectionRequired);

            param[106] = new SqlParameter("@SpecialInstr", ObjBOL.SpecialInstr);

            //Industry
            param[107] = new SqlParameter("@Industry", ObjBOL.Industry);
            param[108] = new SqlParameter("@ElevenFour", ObjBOL.ElevenFour);

            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageProposals]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        //GetFollowupSummary
        public DataSet GetFollowupSummary(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@ProposalNo", ObjBOL.PNumber);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProposals", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetProposal(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@PNumber", ObjBOL.PNumber);
                param[3] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProposals", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        //GetPendingProposals
        public DataSet GetPendingProposals(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@ProjectManagerid", ObjBOL.ProjectManagerid);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_GetPendingProposals", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetDealerMember(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@DealerID", ObjBOL.DealerID);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProposals", param);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ds;
        }
        public DataSet GetFollowupData(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProposals", param);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ds;
        }

        public DataSet GetConsultantMember(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProposals", param);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ds;
        }
        public DataSet GetStates(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@Country", ObjBOL.Country);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProposals", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        public DataSet GetTypeID(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@typeid", ObjBOL.typeid);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProposals", param);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ds;
        }

        public DataSet GetWasteEqTypeid(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@WasteEqTypevalue", ObjBOL.WasteEqTypeid);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProposals", param);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ds;
        }
        public DataSet FillControls(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProposals", param);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ds;
        }


        public string GeneratePnumber(BOLManageProposals ObjBOL)
        {
            string pnumber = string.Empty;
            string dateofproposal = string.Empty;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageProposals]", param);
                pnumber = param[0].Value.ToString();
                dateofproposal = param[1].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return pnumber;
        }

        //GenerateStatus
        public string GenerateStatus(BOLManageProposals ObjBOL)
        {
            string pnumber = string.Empty;
            string dateofproposal = string.Empty;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_GetPendingProposals]", param);
                pnumber = param[0].Value.ToString();
                dateofproposal = param[1].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return pnumber;
        }

        //public DataSet GetProposalSearch(BOLManageProposals ObjBOL)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[3];
        //        param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
        //        param[0].Direction = ParameterDirection.Output;
        //        param[1] = new SqlParameter("@PNumber", ObjBOL.PNumber);
        //        param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
        //        ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_GetPendingProposals", param);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}

        //AddExistingJobID
        public string AddExistingJobID(BOLManageProposals ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PNumber", ObjBOL.PNumber);
            param[3] = new SqlParameter("@ExistingJobID", ObjBOL.ExistingJobID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageProposals]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        //DeleteExistingJobID
        public string DeleteExistingJobID(BOLManageProposals ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ExistingJobID", ObjBOL.ExistingJobID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageProposals]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        //CheckEmailReminder
        public string CheckEmailReminder(BOLManageProposals ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[IV].[EmailReminder]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        //ReturnDatatable
        public DataSet ReturnDatatable(BOLManageProposals ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[EmailReminder]", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }
    }


    public class DALManageCustomers : Connection
    {
        public string SaveCustomers(BOLManageCustomers ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[19];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
            param[2] = new SqlParameter("@CompanyName", ObjBOL.CompanyName);
            param[3] = new SqlParameter("@BusinessType", ObjBOL.BusinessType);
            param[4] = new SqlParameter("@StreetAddress", ObjBOL.StreetAddress);
            param[5] = new SqlParameter("@City", ObjBOL.City);
            param[6] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[7] = new SqlParameter("@ZipCode", ObjBOL.ZipCode);
            param[8] = new SqlParameter("@CountryID", ObjBOL.CountryID);
            param[9] = new SqlParameter("@TollFree", ObjBOL.TollFree);
            param[10] = new SqlParameter("@TollFax", ObjBOL.TollFax);
            param[11] = new SqlParameter("@MainPhone", ObjBOL.MainPhone);
            param[12] = new SqlParameter("@MainFax", ObjBOL.MainFax);
            param[13] = new SqlParameter("@TSM", ObjBOL.TSM);
            param[14] = new SqlParameter("@SerRep", ObjBOL.SerRep);
            param[15] = new SqlParameter("@References", ObjBOL.References);
            param[16] = new SqlParameter("@Memo", ObjBOL.Memo);
            param[17] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[18] = new SqlParameter("@SiteAddress", ObjBOL.SiteAddress);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCustomers", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetCustomers(BOLManageCustomers ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageCustomers", param);
            return ds;
        }

        public DataSet GetCustomersState(BOLManageCustomers ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CountryID", ObjBOL.CountryID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageCustomers", param);
            return ds;
        }

        public DataSet ReturnCustomers(BOLManageCustomers ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CompanyName", ObjBOL.CompanyName);
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[aero_ManageCustomers]", param);
            return ds;
        }

        public String DeleteCustomer(BOLManageCustomers ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
            param[1] = new SqlParameter("@CustomerName", ObjBOL.CompanyName);
            param[2] = new SqlParameter("@op", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPGetCustomers", param);
            string Msg = "Successfully Deleted !";
            return Msg;
        }
    }

    public class DALManageCustomerMember : Connection
    {
        public string SaveCustomerMember(BOLManageCustomerMember ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
            param[2] = new SqlParameter("@Title", ObjBOL.Title);
            param[3] = new SqlParameter("@FName", ObjBOL.FName);
            param[4] = new SqlParameter("@LName", ObjBOL.LName);
            param[5] = new SqlParameter("@Phone", ObjBOL.Phone);
            param[6] = new SqlParameter("@OfficePhone", ObjBOL.OfficePhone);
            param[7] = new SqlParameter("@Fax", ObjBOL.Fax);
            param[8] = new SqlParameter("@MainContact", ObjBOL.MainContact);
            param[9] = new SqlParameter("@ReferenceContact", ObjBOL.ReferenceContact);
            param[10] = new SqlParameter("@email", ObjBOL.email);
            param[11] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCustomers", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public string UpdateCustomerMember(BOLManageCustomerMember ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ContactID", ObjBOL.ContactID);
            param[2] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
            param[3] = new SqlParameter("@Title", ObjBOL.Title);
            param[4] = new SqlParameter("@FName", ObjBOL.FName);
            param[5] = new SqlParameter("@LName", ObjBOL.LName);
            param[6] = new SqlParameter("@Phone", ObjBOL.Phone);
            param[7] = new SqlParameter("@OfficePhone", ObjBOL.OfficePhone);
            param[8] = new SqlParameter("@Fax", ObjBOL.Fax);
            param[9] = new SqlParameter("@MainContact", ObjBOL.MainContact);
            param[10] = new SqlParameter("@ReferenceContact", ObjBOL.ReferenceContact);
            param[11] = new SqlParameter("@email", ObjBOL.email);
            param[12] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCustomers", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public DataSet GetCustomerMember(BOLManageCustomerMember ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageCustomers", param);
            return ds;
        }
        public String DeleteCustomerMember(BOLManageCustomerMember ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ContactID", ObjBOL.ContactID);
            param[2] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
            param[3] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCustomers", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    // Consultant
    public class DALManageConsultant : Connection
    {
        public string SaveConsultant(BOLManageConsultant ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[22];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
            param[2] = new SqlParameter("@CompanyName", ObjBOL.CompanyName);
            param[3] = new SqlParameter("@StreetAdd", ObjBOL.StreetAdd);
            param[4] = new SqlParameter("@City", ObjBOL.City);
            param[5] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[6] = new SqlParameter("@ZipCode", ObjBOL.ZipCode);
            param[7] = new SqlParameter("@Country", ObjBOL.Country);
            param[8] = new SqlParameter("@Phone", ObjBOL.Phone);
            param[9] = new SqlParameter("@TollFree", ObjBOL.TollFree);
            param[10] = new SqlParameter("@TollFax", ObjBOL.TollFax);
            param[11] = new SqlParameter("@Fax", ObjBOL.Fax);
            param[12] = new SqlParameter("@TSM", ObjBOL.TSM);
            param[13] = new SqlParameter("@ConsPref", ObjBOL.ConsPref);
            param[14] = new SqlParameter("@PrefVendor1", ObjBOL.PrefVendor1);
            param[15] = new SqlParameter("@PrefVendor2", ObjBOL.PrefVendor2);
            param[16] = new SqlParameter("@PrefVendor3", ObjBOL.PrefVendor3);
            param[17] = new SqlParameter("@PrefFood", ObjBOL.PrefFood);
            param[18] = new SqlParameter("@NatureofConsultant", ObjBOL.NatureofConsultant);
            param[19] = new SqlParameter("@Emailpath", ObjBOL.Emailpath);
            param[20] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[21] = new SqlParameter("@status", ObjBOL.status);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageConsultants", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public DataSet GetConsultant(BOLManageConsultant ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageConsultants", param);
            return ds;
        }



        public DataSet GetConsultantState(BOLManageConsultant ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@country", ObjBOL.CountryID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageConsultants", param);
            return ds;
        }



        public string DeleteEmailPath(BOLManageConsultant ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageConsultants", param);
            string Msg = "Successfully Deleted !";
            return Msg;
        }
        public DataSet ReturnConsultant(BOLManageConsultant ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@proposalname", ObjBOL.CompanyName);
            param[1] = new SqlParameter("@pnumber", ObjBOL.CompanyName);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[aero_ManageConsultants]", param);
            return ds;
        }
        public String DeleteConsultant(BOLManageConsultant ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
            param[1] = new SqlParameter("@CustomerName", ObjBOL.CompanyName);
            param[2] = new SqlParameter("@op", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageConsultants]", param);
            string Msg = "Successfully Deleted !";
            return Msg;
        }
    }

    // Consultant Member
    public class DALManageConsultantMember : Connection
    {
        public string SaveCustomerMember(BOLManageConsultantMember ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ConsultantMemberID", ObjBOL.ConsultantMemberID);
            param[2] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
            param[3] = new SqlParameter("@JobTitle", ObjBOL.JobTitle);
            param[4] = new SqlParameter("@FirstName", ObjBOL.FirstName);
            param[5] = new SqlParameter("@LastName", ObjBOL.LastName);
            param[6] = new SqlParameter("@TelephoneExtension", ObjBOL.TelephoneExtension);
            param[7] = new SqlParameter("@Email", ObjBOL.Email);
            param[8] = new SqlParameter("@DirectLine", ObjBOL.DirectLine);
            param[9] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageConsultants]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetConsultantMember(BOLManageConsultantMember ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[aero_ManageConsultants]", param);
            return ds;
        }

        public String DeleteConsultantMember(BOLManageConsultantMember ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@ConsultantMemberID", ObjBOL.ConsultantMemberID);
            param[1] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageConsultants]", param);
            string Msg = "Successfully Deleted !";
            return Msg;
        }
    }


    public class DALManageDealers : Connection
    {
        public string SaveDealers(BOLManageDealers ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[27];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@DealerID", ObjBOL.DealerID);
            param[2] = new SqlParameter("@FederalID", ObjBOL.FederalID);
            param[3] = new SqlParameter("@CompanyName", ObjBOL.CompanyName);
            param[4] = new SqlParameter("@GroupName", ObjBOL.GroupName);
            param[5] = new SqlParameter("@StreetAddress", ObjBOL.StreetAddress);
            param[6] = new SqlParameter("@City", ObjBOL.City);
            param[7] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[8] = new SqlParameter("@Country", ObjBOL.Country);
            param[9] = new SqlParameter("@ZipCode", ObjBOL.ZipCode);
            param[10] = new SqlParameter("@TollFree", ObjBOL.TollFree);
            param[11] = new SqlParameter("@TollFax", ObjBOL.TollFax);
            param[12] = new SqlParameter("@Phone", ObjBOL.Phone);
            param[13] = new SqlParameter("@Fax", ObjBOL.Fax);
            param[14] = new SqlParameter("@FoodPref", ObjBOL.FoodPref);
            param[15] = new SqlParameter("@RegionID", ObjBOL.RegionID);
            param[16] = new SqlParameter("@HobartDealer", ObjBOL.HobartDealer);
            param[17] = new SqlParameter("@ChristmasCard", ObjBOL.ChristmasCard);
            param[18] = new SqlParameter("@TSM", ObjBOL.TSM);
            param[19] = new SqlParameter("@HeadOffice", ObjBOL.HeadOffice);
            param[20] = new SqlParameter("@Agreement", ObjBOL.Agreement);
            param[21] = new SqlParameter("@AgreedDiscount", ObjBOL.AgreedDiscount);
            param[22] = new SqlParameter("@DealerPref", ObjBOL.DealerPref);
            param[23] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[24] = new SqlParameter("@status", ObjBOL.status);
            param[25] = new SqlParameter("@W9form", ObjBOL.W9form);
            param[26] = new SqlParameter("@LastUpdatedDate", ObjBOL.LastUpdatedDate);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageDealers", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public DataSet GetDealers(BOLManageDealers ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@DealerID", ObjBOL.DealerID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageDealers", param);
            return ds;
        }
        public DataSet GetDealerState(BOLManageDealers ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@country", ObjBOL.Country);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageDealers", param);
            return ds;
        }

        public DataSet ReturnDealers(BOLManageDealers ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@proposalname", ObjBOL.CompanyName);
            param[1] = new SqlParameter("@pnumber", ObjBOL.CompanyName);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[aero_ManageDealers]", param);
            return ds;
        }
        public String DeleteDealers(BOLManageDealers ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@DealerID", ObjBOL.DealerID);
            param[1] = new SqlParameter("@CustomerName", ObjBOL.CompanyName);
            param[2] = new SqlParameter("@op", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageDealers", param);
            string Msg = "Successfully Deleted !";
            return Msg;
        }
    }

    public class DALManageDealerMember : Connection
    {
        public string SaveDealerMember(BOLManageDealerMember ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ContactID", ObjBOL.ContactID);
            param[2] = new SqlParameter("@DealerID", ObjBOL.DealerID);
            param[3] = new SqlParameter("@Title", ObjBOL.Title);
            param[4] = new SqlParameter("@FName", ObjBOL.FName);
            param[5] = new SqlParameter("@LName", ObjBOL.LName);
            param[6] = new SqlParameter("@Phone", ObjBOL.Phone);
            param[7] = new SqlParameter("@Fax", ObjBOL.Fax);
            param[8] = new SqlParameter("@MainContact", ObjBOL.MainContact);
            param[9] = new SqlParameter("@Attention", ObjBOL.Attention);
            param[10] = new SqlParameter("@Extension", ObjBOL.Extension);
            param[11] = new SqlParameter("@email", ObjBOL.email);
            param[12] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[13] = new SqlParameter("@Cell", ObjBOL.Cell);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageDealers", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetDealerMember(BOLManageDealerMember ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CustomerID", ObjBOL.DealerID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageDealers", param);
            return ds;
        }

        public String DeleteDealerMember(BOLManageDealerMember ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@ContactID", ObjBOL.ContactID);
            param[1] = new SqlParameter("@DealerID", ObjBOL.DealerID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageDealers", param);
            string Msg = "Successfully Deleted !";
            return Msg;
        }
    }

    public class DALManageProjects : Connection
    {
        //DALManageProjects
        public string SaveProject(BOLManageProjects ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[151];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@JobOrderDate", ObjBOL.JobOrderDate);
            param[3] = new SqlParameter("@PORec", ObjBOL.PORec);
            param[4] = new SqlParameter("@OASentTo", ObjBOL.OASentTo);
            param[5] = new SqlParameter("@OASentToContact", ObjBOL.OASentToContact);
            param[6] = new SqlParameter("@QuoteSelected", ObjBOL.QuoteSelected);
            param[7] = new SqlParameter("@JobOrderAck", ObjBOL.JobOrderAck);
            param[8] = new SqlParameter("@JobOADis", ObjBOL.JobOADis);
            param[9] = new SqlParameter("@ProposalID", ObjBOL.ProposalID);
            param[10] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
            param[11] = new SqlParameter("@ModelID", ObjBOL.ModelID);
            param[12] = new SqlParameter("@ConveyorTypeID", ObjBOL.ConveyorTypeID);
            param[13] = new SqlParameter("@ServiceRepID", ObjBOL.ServiceRepID);
            param[14] = new SqlParameter("@ShipperID", ObjBOL.ShipperID);
            param[15] = new SqlParameter("@SiteContact", ObjBOL.SiteContact);
            param[16] = new SqlParameter("@SiteContactTelephone", ObjBOL.SiteContactTelephone);
            param[17] = new SqlParameter("@DateAsBuiltDrgsSent", ObjBOL.DateAsBuiltDrgsSent);
            param[18] = new SqlParameter("@EstReleaseDate", ObjBOL.EstReleaseDate);
            param[19] = new SqlParameter("@ReleaseDate", ObjBOL.ReleaseDate);
            param[20] = new SqlParameter("@TestRunDate", ObjBOL.TestRunDate);
            param[21] = new SqlParameter("@EstCompletionDate", ObjBOL.EstCompletionDate);
            param[22] = new SqlParameter("@ActualCompletionDate", ObjBOL.ActualCompletionDate);
            param[23] = new SqlParameter("@ShipDate", ObjBOL.ShipDate);
            param[24] = new SqlParameter("@ShipToArriveDate", ObjBOL.ShipToArriveDate);
            param[25] = new SqlParameter("@ArrivalDate", ObjBOL.ArrivalDate);
            param[26] = new SqlParameter("@ManualDispatchDate", ObjBOL.ManualDispatchDate);
            param[27] = new SqlParameter("@InstallationBy", ObjBOL.InstallationBy);
            param[28] = new SqlParameter("@InstallDate", ObjBOL.InstallDate);
            param[29] = new SqlParameter("@InstallationCompletionDate", ObjBOL.InstallationCompletionDate);
            param[30] = new SqlParameter("@NoInstallation", ObjBOL.NoInstallation);
            param[31] = new SqlParameter("@DemoDate", ObjBOL.DemoDate);
            param[32] = new SqlParameter("@WarrantyStartDate", ObjBOL.WarrantyStartDate);
            param[33] = new SqlParameter("@WarrantyEndDate", ObjBOL.WarrantyEndDate);
            param[34] = new SqlParameter("@FollowUpDate", ObjBOL.FollowUpDate);
            param[35] = new SqlParameter("@CustCarePackageSendDate", ObjBOL.CustCarePackageSendDate);
            param[36] = new SqlParameter("@PONumber", ObjBOL.PONumber);
            param[37] = new SqlParameter("@InvoiceNumber", ObjBOL.InvoiceNumber);
            param[38] = new SqlParameter("@DateInvoiceSent", ObjBOL.DateInvoiceSent);
            param[39] = new SqlParameter("@DatePaymentReceived", ObjBOL.DatePaymentReceived);
            param[40] = new SqlParameter("@DateCommissionPaid", ObjBOL.DateCommissionPaid);
            param[41] = new SqlParameter("@KflexCheckNumber", ObjBOL.KflexCheckNumber);
            param[42] = new SqlParameter("@CommissionType", ObjBOL.CommissionType);
            param[43] = new SqlParameter("@SalesSourceID", ObjBOL.SalesSourceID);
            param[44] = new SqlParameter("@ProjectDesignerID", ObjBOL.ProjectDesignerID);
            param[45] = new SqlParameter("@DateAssigned", ObjBOL.DateAssigned);
            param[46] = new SqlParameter("@ShipToName", ObjBOL.ShipToName);
            param[47] = new SqlParameter("@ShipToStreet", ObjBOL.ShipToStreet);
            param[48] = new SqlParameter("@ShipToCity", ObjBOL.ShipToCity);
            param[49] = new SqlParameter("@ShipToState", ObjBOL.ShipToState);
            param[50] = new SqlParameter("@ShipToCountry", ObjBOL.ShipToCountry);
            param[51] = new SqlParameter("@ShipToZipCode", ObjBOL.ShipToZipCode);
            param[52] = new SqlParameter("@discount", ObjBOL.discount);
            param[53] = new SqlParameter("@fob", ObjBOL.fob);
            param[54] = new SqlParameter("@term", ObjBOL.term);
            param[55] = new SqlParameter("@IndComDate", ObjBOL.IndComDate);
            param[56] = new SqlParameter("@AeroChequeNum", ObjBOL.AeroChequeNum);
            param[57] = new SqlParameter("@PreInspectionDate", ObjBOL.PreInspectionDate);
            param[58] = new SqlParameter("@CheckedByOffice", ObjBOL.CheckedByOffice);
            param[59] = new SqlParameter("@CheckedByPlant", ObjBOL.CheckedByPlant);
            // param[60] = new SqlParameter("@CancelJob", ObjBOL.CancelJob);
            param[61] = new SqlParameter("@DigitalPicOnServer", ObjBOL.DigitalPicOnServer);
            param[62] = new SqlParameter("@ReferenceDrawing", ObjBOL.ReferenceDrawing);
            param[63] = new SqlParameter("@DealerMember", ObjBOL.DealerMember);
            param[64] = new SqlParameter("@BuyOutCost", ObjBOL.BuyOutCost);
            param[65] = new SqlParameter("@RawMaterial", ObjBOL.RawMaterial);
            param[66] = new SqlParameter("@ExWarrantyPrice", ObjBOL.ExWarrantyPrice);
            param[67] = new SqlParameter("@NetAmount", ObjBOL.NetAmount);
            param[68] = new SqlParameter("@FreightPaid", ObjBOL.FreightPaid);
            param[69] = new SqlParameter("@GST", ObjBOL.GST);
            param[70] = new SqlParameter("@InstallatorA", ObjBOL.InstallatorA);
            param[71] = new SqlParameter("@InstallatorB", ObjBOL.InstallatorB);
            param[72] = new SqlParameter("@InstallatorC", ObjBOL.InstallatorC);
            param[73] = new SqlParameter("@ConCost", ObjBOL.ConCost);
            param[74] = new SqlParameter("@ConRoylAmt", ObjBOL.ConRoylAmt);
            param[75] = new SqlParameter("@ConCheckNo", ObjBOL.ConCheckNo);
            param[76] = new SqlParameter("@ConChqPaidDt", ObjBOL.ConChqPaidDt);
            param[77] = new SqlParameter("@Comments", ObjBOL.Comments);
            param[78] = new SqlParameter("@ReviewedBy", ObjBOL.ReviewedBy);
            param[79] = new SqlParameter("@DrgSentOutforApproval", ObjBOL.DrgSentOutforApproval);
            param[80] = new SqlParameter("@AppDrgWithFieldDimension", ObjBOL.AppDrgWithFieldDimension);
            param[81] = new SqlParameter("@AppDrgAck", ObjBOL.AppDrgAck);
            param[82] = new SqlParameter("@EquipDelConfirmed", ObjBOL.EquipDelConfirmed);
            param[83] = new SqlParameter("@AccReqFromCustomer", ObjBOL.AccReqFromCustomer);
            param[84] = new SqlParameter("@BuiltDrgWithUnderStruSent", ObjBOL.BuiltDrgWithUnderStruSent);
            param[85] = new SqlParameter("@ProjDataPrepBy", ObjBOL.ProjDataPrepBy);
            param[86] = new SqlParameter("@ProjFormReviewByAI", ObjBOL.ProjFormReviewByAI);
            param[87] = new SqlParameter("@ProjFormReviewByHO", ObjBOL.ProjFormReviewByHO);
            param[88] = new SqlParameter("@FabDrgReviewByAI", ObjBOL.FabDrgReviewByAI);
            param[89] = new SqlParameter("@FabDrgReviewByHO", ObjBOL.FabDrgReviewByHO);
            param[90] = new SqlParameter("@PFRBAIDate", ObjBOL.PFRBAIDate);
            param[91] = new SqlParameter("@PFRBHODate", ObjBOL.PFRBHODate);
            param[92] = new SqlParameter("@FDRBAIDate", ObjBOL.FDRBAIDate);
            param[93] = new SqlParameter("@FDRBHODate", ObjBOL.FDRBHODate);
            param[94] = new SqlParameter("@FeedBackConsultant", ObjBOL.FeedBackConsultant);
            param[95] = new SqlParameter("@FeedBackDealer", ObjBOL.FeedBackDealer);
            param[96] = new SqlParameter("@SummofSugg", ObjBOL.SummofSugg);
            //param[98] = new SqlParameter("@SpecCredit", ObjBOL.SpecCredit);        
            param[97] = new SqlParameter("@SpecCredits", ObjBOL.SpecCredits);
            param[98] = new SqlParameter("@SpecCreditPercentID", ObjBOL.SpecCreditPercentID);
            param[99] = new SqlParameter("@SpecCreditAmount", ObjBOL.SpecCreditAmount);
            param[100] = new SqlParameter("@SpecCreditCheckNo", ObjBOL.SpecCreditCheckNo);
            param[101] = new SqlParameter("@SpecCreditPaidDate", ObjBOL.SpecCreditPaidDate);
            param[102] = new SqlParameter("@GSICommissionType", ObjBOL.GSICommissionType);
            param[103] = new SqlParameter("@GSICommissionAmount", ObjBOL.GSICommissionAmount);
            param[104] = new SqlParameter("@GSICommissionCheckNo", ObjBOL.GSICommissionCheckNo);
            param[105] = new SqlParameter("@GSICommissionSentDate", ObjBOL.GSICommissionSentDate);
            //Pfile Columns           
            param[106] = new SqlParameter("@DealerID", ObjBOL.DealerID);
            //param[109] = new SqlParameter("@ConveyorTypeID", ObjBOL.ConveyorTypeID);
            param[107] = new SqlParameter("@OriginRepID", ObjBOL.OriginRepID);
            param[108] = new SqlParameter("@ConsultRepID", ObjBOL.ConsultRepID);
            param[109] = new SqlParameter("@RepID", ObjBOL.RepID);
            param[110] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
            param[111] = new SqlParameter("@Price", ObjBOL.Price);
            param[112] = new SqlParameter("@Freight", ObjBOL.Freight);
            param[113] = new SqlParameter("@Installation", ObjBOL.Installation);
            param[114] = new SqlParameter("@CurrencyID", ObjBOL.CurrencyID);
            param[115] = new SqlParameter("@CurrentStatus", ObjBOL.CurrentStatus);
            param[116] = new SqlParameter("@OrderProbabilityID", ObjBOL.OrderProbabilityID);
            param[117] = new SqlParameter("@DetailedQuote", ObjBOL.DetailedQuote);
            param[118] = new SqlParameter("@Specifications", ObjBOL.Specifications);
            param[119] = new SqlParameter("@DPics", ObjBOL.DPics);
            param[120] = new SqlParameter("@RefDrawing", ObjBOL.RefDrawing);
            param[121] = new SqlParameter("@EqDisAmount", ObjBOL.EqDisAmount);
            param[122] = new SqlParameter("@EqDiscount", ObjBOL.EqDiscount);
            param[123] = new SqlParameter("@NetEqPrice", ObjBOL.NetEqPrice);
            param[124] = new SqlParameter("@OrderBelongsToDELETE", ObjBOL.OrderBelongsToDELETE);
            param[125] = new SqlParameter("@MfgFacilityID", ObjBOL.MfgFacilityID);
            param[126] = new SqlParameter("@ConsultantMemberId", ObjBOL.ConsultantMemberId);
            param[127] = new SqlParameter("@operation", ObjBOL.Operation);
            param[128] = new SqlParameter("@DueDateCanada", ObjBOL.DueDateCanada);
            param[129] = new SqlParameter("@FabSentToCanada", ObjBOL.FabSentToCanada);
            param[130] = new SqlParameter("@EngineerCanada", ObjBOL.EngineerCanada);
            param[131] = new SqlParameter("@ReleasedToNesting", ObjBOL.ReleasedToNesting);
            param[132] = new SqlParameter("@ReleasedToShop", ObjBOL.ReleasedToShop);
            param[133] = new SqlParameter("@ProjectStatus", ObjBOL.ProjectStatus);
            param[134] = new SqlParameter("@ExistingJobID", ObjBOL.ExistingJobID);
            param[135] = new SqlParameter("@JobType", ObjBOL.JobType);
            param[136] = new SqlParameter("@projectmanager", ObjBOL.ProjectManager);
            param[137] = new SqlParameter("@ShippingCommit", ObjBOL.ShippingCommit);
            param[138] = new SqlParameter("@ProjectCommissionText", ObjBOL.ProjectCommNotes);
            param[139] = new SqlParameter("@NestingStatus", ObjBOL.NestingStatus);
            param[140] = new SqlParameter("@ShipStatus", ObjBOL.ShipStatus);
            param[141] = new SqlParameter("@UserID", ObjBOL.UserID);
            param[142] = new SqlParameter("@CashDisAmt", ObjBOL.CashDisAmt);
            param[143] = new SqlParameter("@CashDisPer", ObjBOL.CashDisPer);
            param[144] = new SqlParameter("@CashAmtRec", ObjBOL.CashAmtRec);
            param[145] = new SqlParameter("@AmountForComission", ObjBOL.AmountForComission);
            param[146] = new SqlParameter("@PMPack", ObjBOL.PMPack);
            param[147] = new SqlParameter("@Status", ObjBOL.Status);
            param[148] = new SqlParameter("@ExpectedArrivalDatefromChina", ObjBOL.ExpectedArrivalDatefromChina);
            param[149] = new SqlParameter("@PurchasedItems", ObjBOL.PurchasedItems);
            param[150] = new SqlParameter("@PurchasedItemsCAD", ObjBOL.PurchasedItemsCAD);
            //ProjectStatus
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageProjects]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetProject(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@ProjectName", ObjBOL.ProjectName);
                param[3] = new SqlParameter("@ConsultantID", ObjBOL.ConsultantID);
                param[4] = new SqlParameter("@ProposalID", ObjBOL.ProposalID);
                param[5] = new SqlParameter("@JobID", ObjBOL.JobID);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjects", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        public string GetProjectStatus(BOLManageProjects ObjBOL)
        {
            string ProjectStatus = string.Empty;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@JobID", ObjBOL.JobID);
                SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjects", param);
                ProjectStatus = param[0].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ProjectStatus;
        }

        public DataSet GetStates(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@ShipToCountry", ObjBOL.ShipToCountry);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjects", param);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ds;
        }

        public DataSet FillControls(BOLManageProjects ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjects", param);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ds;
        }

        public string GenrateJNumber(BOLManageProjects ObjBOL)
        {
            string jnumber = string.Empty;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@operation", ObjBOL.Operation);
                SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageProjects]", param);
                jnumber = param[0].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return jnumber;
        }

        public Decimal GetTaxAmount(BOLManageProjects ObjBOL)
        {
            Decimal amount = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@EqDiscount", SqlDbType.Float);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
                param[2] = new SqlParameter("@JobOrderDate", ObjBOL.JobOrderDate);
                param[3] = new SqlParameter("@Price", ObjBOL.NetAmount);
                SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[Get_TaxAmount]", param);
                amount = Convert.ToDecimal(param[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return amount;
        }

        //GetCashDiscount
        public decimal GetCashDiscount(BOLManageProjects ObjBOL)
        {
            Decimal amount = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@EqDiscount", SqlDbType.Float);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@DealerID", ObjBOL.DealerID);
                SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[Get_CashDiscount]", param);
                amount = Convert.ToDecimal(param[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return amount;
        }
    }

    public class DALManageRepBranches : Connection
    {
        public string SaveRepBranches(BOLManageRepBranches ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@BranchID", ObjBOL.BranchID);
            param[2] = new SqlParameter("@BranchLocation", ObjBOL.BranchLocation);
            param[3] = new SqlParameter("@BranchName", ObjBOL.BranchName);
            param[4] = new SqlParameter("@RegionID", ObjBOL.RegionID);
            param[5] = new SqlParameter("@CompanyName", ObjBOL.CompanyName);
            param[6] = new SqlParameter("@StreetAddress", ObjBOL.StreetAddress);
            param[7] = new SqlParameter("@City", ObjBOL.City);
            param[8] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[9] = new SqlParameter("@CountryID", ObjBOL.CountryID);
            param[10] = new SqlParameter("@ZipCode", ObjBOL.ZipCode);
            param[11] = new SqlParameter("@Telephone", ObjBOL.Telephone);
            param[12] = new SqlParameter("@TollFree", ObjBOL.TollFree);
            param[13] = new SqlParameter("@TollFax", ObjBOL.TollFax);
            param[14] = new SqlParameter("@FaxNumber", ObjBOL.FaxNumber);
            param[15] = new SqlParameter("@ChristmasCard", ObjBOL.ChristmasCard);
            param[16] = new SqlParameter("@InsideSalesSupportID", ObjBOL.InsideSalesSupportID);
            param[17] = new SqlParameter("@HobartGroup", ObjBOL.HobartGroup);
            param[18] = new SqlParameter("@SteroGroup", ObjBOL.SteroGroup);
            param[19] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageRepBranches", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetRepBranches(BOLManageRepBranches ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@BranchID", ObjBOL.BranchID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageRepBranches", param);
            return ds;
        }

        public String DeleteRepBranches(BOLManageRepBranches ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@BranchID", ObjBOL.BranchID);
            param[1] = new SqlParameter("@CustomerName", ObjBOL.CompanyName);
            param[2] = new SqlParameter("@op", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageRepBranches", param);
            string Msg = "Successfully Deleted !";
            return Msg;
        }
    }


    public class DALDistributors : Connection
    {
        public DataSet GetDistributors(BOLDistributors ObjBOLDistributors)
        {
            DataSet ds = new DataSet();

            OpenConnection();
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@DistributorID", ObjBOLDistributors.DistributorID);
            param[1] = new SqlParameter("@Name", ObjBOLDistributors.Name);
            param[2] = new SqlParameter("@StateID", ObjBOLDistributors.StateID);
            param[3] = new SqlParameter("@DistrictID", ObjBOLDistributors.DistrictID);
            param[4] = new SqlParameter("@CityID", ObjBOLDistributors.CityID);
            param[5] = new SqlParameter("@ProductID", ObjBOLDistributors.ProductID);
            param[6] = new SqlParameter("@Address", ObjBOLDistributors.Address);
            param[7] = new SqlParameter("@ContactNumber", ObjBOLDistributors.ContactNumber);
            param[8] = new SqlParameter("@EmailAddress", ObjBOLDistributors.EmailAddress);
            param[9] = new SqlParameter("@IsActive", ObjBOLDistributors.IsActive);
            param[10] = new SqlParameter("@UserID", ObjBOLDistributors.UserID);
            param[11] = new SqlParameter("@Action", ObjBOLDistributors.Action);
            param[12] = new SqlParameter("@Msg", SqlDbType.VarChar, 500);
            param[12].Direction = ParameterDirection.Output;
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "AddManageDistributors", param);
            string status = param[12].Value.ToString();
            CloseConnection();
            return ds;
        }

        public string SaveUpdateDistributors(BOLDistributors ObjBOLDistributors)
        {
            OpenConnection();
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@DistributorID", ObjBOLDistributors.DistributorID);
            param[1] = new SqlParameter("@Name", ObjBOLDistributors.Name);
            param[2] = new SqlParameter("@StateID", ObjBOLDistributors.StateID);
            param[3] = new SqlParameter("@DistrictID", ObjBOLDistributors.DistrictID);
            param[4] = new SqlParameter("@CityID", ObjBOLDistributors.CityID);
            param[5] = new SqlParameter("@ProductID", ObjBOLDistributors.ProductID);
            param[6] = new SqlParameter("@Address", ObjBOLDistributors.Address);
            param[7] = new SqlParameter("@ContactNumber", ObjBOLDistributors.ContactNumber);
            param[8] = new SqlParameter("@EmailAddress", ObjBOLDistributors.EmailAddress);
            param[9] = new SqlParameter("@IsActive", ObjBOLDistributors.IsActive);
            param[10] = new SqlParameter("@UserID", ObjBOLDistributors.UserID);
            param[11] = new SqlParameter("@Action", ObjBOLDistributors.Action);
            param[12] = new SqlParameter("@Msg", SqlDbType.VarChar, 500);
            param[12].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "AddManageDistributors", param);
            string status = param[12].Value.ToString();
            CloseConnection();
            return status;
        }
    }

    public class DALPackage : Connection
    {
        public string SaveUpdatePackage(BOLPackage ObjBOLPackage)
        {
            OpenConnection();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@PackageDetail", ObjBOLPackage.dt);
            param[1] = new SqlParameter("@PackageID", ObjBOLPackage.PackageID);
            param[2] = new SqlParameter("@WholePackageName", ObjBOLPackage.WholePackageName);
            param[3] = new SqlParameter("@PackageNameID", ObjBOLPackage.PackageNameID);
            param[4] = new SqlParameter("@UserID", ObjBOLPackage.UserID);
            param[5] = new SqlParameter("@Action", ObjBOLPackage.Action);
            param[6] = new SqlParameter("@Msg", SqlDbType.VarChar, 500);
            param[6].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "AddManagePackages", param);
            string status = param[6].Value.ToString();
            CloseConnection();
            return status;
        }

        public DataSet GetPackage(BOLPackage ObjBOLPackage)
        {
            OpenConnection();
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@PackageDetail", ObjBOLPackage.dt);
            param[1] = new SqlParameter("@PackageID", ObjBOLPackage.PackageID);
            param[2] = new SqlParameter("@WholePackageName", ObjBOLPackage.WholePackageName);
            param[3] = new SqlParameter("@PackageNameID", ObjBOLPackage.PackageNameID);
            param[4] = new SqlParameter("@UserID", ObjBOLPackage.UserID);
            param[5] = new SqlParameter("@Action", ObjBOLPackage.Action);
            param[6] = new SqlParameter("@Msg", SqlDbType.VarChar, 500);
            param[6].Direction = ParameterDirection.Output;
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "AddManagePackages", param);
            string status = param[6].Value.ToString();
            CloseConnection();
            return ds;
        }
    }

    public class DALPackageDispatchSchedule : Connection
    {
        public string SaveUpdatePackageDispatchSchedule(BOLPackageDispatchSchedule ObjBOLPackageDispatchSchedule)
        {
            OpenConnection();
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@DispatchID", ObjBOLPackageDispatchSchedule.DispatchID);
            param[1] = new SqlParameter("@PackageID", ObjBOLPackageDispatchSchedule.PackageID);
            param[2] = new SqlParameter("@CustomerID", ObjBOLPackageDispatchSchedule.CustomerID);
            param[3] = new SqlParameter("@state_id", ObjBOLPackageDispatchSchedule.state_id);
            param[4] = new SqlParameter("@district_id", ObjBOLPackageDispatchSchedule.district_id);
            param[5] = new SqlParameter("@city_id", ObjBOLPackageDispatchSchedule.city_id);
            param[6] = new SqlParameter("@SessionID", ObjBOLPackageDispatchSchedule.SessionID);
            param[7] = new SqlParameter("@PackStartDate", ObjBOLPackageDispatchSchedule.PackStartDate);
            param[8] = new SqlParameter("@PackEndDate", ObjBOLPackageDispatchSchedule.PackEndDate);
            param[9] = new SqlParameter("@SessionStartDate", ObjBOLPackageDispatchSchedule.PackStartDate);
            param[10] = new SqlParameter("@SessionEndDate", ObjBOLPackageDispatchSchedule.PackEndDate);
            param[11] = new SqlParameter("@UserID", ObjBOLPackageDispatchSchedule.UserID);
            param[12] = new SqlParameter("@Action", ObjBOLPackageDispatchSchedule.Action);
            param[13] = new SqlParameter("@Msg", SqlDbType.VarChar, 500);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ItemType", ObjBOLPackageDispatchSchedule.ItemType);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "AddManageDispatchSchedule", param);
            string status = param[13].Value.ToString();
            CloseConnection();
            return status;
        }

        public DataSet GetPackageDispatchSchedule(BOLPackageDispatchSchedule ObjBOLPackageDispatchSchedule)
        {
            OpenConnection();
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@DispatchID", ObjBOLPackageDispatchSchedule.DispatchID);
            param[1] = new SqlParameter("@PackageID", ObjBOLPackageDispatchSchedule.PackageID);
            param[2] = new SqlParameter("@CustomerID", ObjBOLPackageDispatchSchedule.CustomerID);
            param[3] = new SqlParameter("@state_id", ObjBOLPackageDispatchSchedule.state_id);
            param[4] = new SqlParameter("@district_id", ObjBOLPackageDispatchSchedule.district_id);
            param[5] = new SqlParameter("@city_id", ObjBOLPackageDispatchSchedule.city_id);
            param[6] = new SqlParameter("@SessionID", ObjBOLPackageDispatchSchedule.SessionID);
            param[7] = new SqlParameter("@PackStartDate", ObjBOLPackageDispatchSchedule.PackStartDate);
            param[8] = new SqlParameter("@PackEndDate", ObjBOLPackageDispatchSchedule.PackEndDate);
            param[9] = new SqlParameter("@SessionStartDate", ObjBOLPackageDispatchSchedule.SessionStartDate);
            param[10] = new SqlParameter("@SessionEndDate", ObjBOLPackageDispatchSchedule.SessionEndDate);
            param[11] = new SqlParameter("@UserID", ObjBOLPackageDispatchSchedule.UserID);
            param[12] = new SqlParameter("@Action", ObjBOLPackageDispatchSchedule.Action);
            param[13] = new SqlParameter("@Msg", SqlDbType.VarChar, 500);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ItemType", ObjBOLPackageDispatchSchedule.ItemType);
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "AddManageDispatchSchedule", param);
            string status = param[13].Value.ToString();
            CloseConnection();
            return ds;
        }
    }

    public class DALDesignation : Connection
    {
        public string SaveDesignation(BOLDesignation ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Desg_ID", ObjBOL.Desg_ID);
            param[2] = new SqlParameter("@Desg_Name", ObjBOL.Desg_Name);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPDesignationMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetDesignation(BOLDesignation ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Desg_ID", ObjBOL.Desg_ID);
            param[2] = new SqlParameter("@Desg_Name", ObjBOL.Desg_Name);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPDesignationMaster", param);
            return ds;
        }
    }

    public class DALWorkStatus : Connection
    {
        public string SaveWorkStatus(BOLWorkStatus ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@WorkStatus_ID", ObjBOL.WorkStatus_ID);
            param[2] = new SqlParameter("@WorkStatus_Name", ObjBOL.WorkStatus_Name);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPworkstatusMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetWorkStatus(BOLWorkStatus ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@WorkStatus_ID", ObjBOL.WorkStatus_ID);
            param[2] = new SqlParameter("@WorkStatus_Name", ObjBOL.WorkStatus_Name);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPworkstatusMaster", param);
            return ds;
        }
    }

    public class DALWorkType : Connection
    {
        public string SaveWorkType(BOLWorkType ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@WorkType_ID", ObjBOL.WorkType_ID);
            param[2] = new SqlParameter("@WorkType_Name", ObjBOL.WorkType_Name);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPWorkTypeMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetWorkType(BOLWorkType ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@WorkType_ID", ObjBOL.WorkType_ID);
            param[2] = new SqlParameter("@WorkType_Name", ObjBOL.WorkType_Name);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPWorkTypeMaster", param);
            return ds;
        }
    }

    public class DALDiagnosis : Connection
    {
        public string SaveDiagnosis(BOLDiagnosis ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@DiagID", ObjBOL.DiagID);
            param[2] = new SqlParameter("@Sur_Path_ID_Detail", ObjBOL.Sur_Path_ID_Detail);
            param[3] = new SqlParameter("@TopographyID", ObjBOL.TopographyID);
            param[4] = new SqlParameter("@MorphologyID", ObjBOL.MorphologyID);
            param[5] = new SqlParameter("@AdditionalInfo", ObjBOL.AdditionalInfo);
            param[6] = new SqlParameter("@Prefix", ObjBOL.Prefix);
            param[7] = new SqlParameter("@Sufix", ObjBOL.Sufix);
            param[8] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPDiagnosis", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetDiagnosis(BOLDiagnosis ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@DiagID", ObjBOL.DiagID);
            param[2] = new SqlParameter("@Sur_Path_ID_Detail", ObjBOL.Sur_Path_ID_Detail);
            param[3] = new SqlParameter("@TopographyID", ObjBOL.TopographyID);
            param[4] = new SqlParameter("@MorphologyID", ObjBOL.MorphologyID);
            param[5] = new SqlParameter("@AdditionalInfo", ObjBOL.AdditionalInfo);
            param[6] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPDiagnosis", param);
            return ds;
        }
    }
    public class DALNotepad : Connection
    {
        public string SaveWorkName(BOLNotepad ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Work_ID", ObjBOL.Work_ID);
            param[2] = new SqlParameter("@Work_Name", ObjBOL.Work_Name);
            param[3] = new SqlParameter("@Work_Status", ObjBOL.Work_Status);
            param[4] = new SqlParameter("@UserID", ObjBOL.UserID);
            param[5] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPNotepad", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetWorkName(BOLNotepad ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Work_ID", ObjBOL.Work_ID);
            param[2] = new SqlParameter("@Work_Name", ObjBOL.Work_Name);
            param[3] = new SqlParameter("@Work_Status", ObjBOL.Work_Status);
            param[4] = new SqlParameter("@UserID", ObjBOL.UserID);
            param[5] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPNotepad", param);
            return ds;
        }
    }

    public class DALPaymentDetails : Connection
    {
        public string SavePaymentDetails(BOLPaymentDetails ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[18];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Payment_ID", ObjBOL.Payment_ID);
            param[2] = new SqlParameter("@UserID", ObjBOL.UserID);
            param[3] = new SqlParameter("@Payment_Amount", ObjBOL.Payment_Amount);
            param[4] = new SqlParameter("@Payment_Mode", ObjBOL.Payment_Mode);
            param[5] = new SqlParameter("@Payment_ChequeDDNo", ObjBOL.Payment_ChequeDDNo);
            param[6] = new SqlParameter("@Payment_DateDD", ObjBOL.Payment_DateDD);
            param[7] = new SqlParameter("@Payment_BankNameDD", ObjBOL.Payment_BankNameDD);
            param[8] = new SqlParameter("@Payment_AccountNoDD", ObjBOL.Payment_AccountNoDD);
            param[9] = new SqlParameter("@Payment_ScanCopyDD", ObjBOL.Payment_ScanCopyDD);
            param[10] = new SqlParameter("@Payment_StatusDD", ObjBOL.Payment_StatusDD);
            param[11] = new SqlParameter("@Payment_RemarksDD", ObjBOL.Payment_RemarksDD);
            param[12] = new SqlParameter("@Payment_DateOnline", ObjBOL.Payment_DateOnline);
            param[13] = new SqlParameter("@Payment_BankNameOnline", ObjBOL.Payment_BankNameOnline);
            param[14] = new SqlParameter("@Payment_PlaceOnline", ObjBOL.Payment_PlaceOnline);
            param[15] = new SqlParameter("@Payment_StatusOnline", ObjBOL.Payment_StatusOnline);
            param[16] = new SqlParameter("@Payment_RemarksOnline", ObjBOL.Payment_RemarksOnline);
            param[17] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPPaymentDetails", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetPaymentDetails(BOLPaymentDetails ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[18];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Payment_ID", ObjBOL.Payment_ID);
            param[2] = new SqlParameter("@UserID", ObjBOL.UserID);
            param[3] = new SqlParameter("@Payment_Amount", ObjBOL.Payment_Amount);
            param[4] = new SqlParameter("@Payment_Mode", ObjBOL.Payment_Mode);
            param[5] = new SqlParameter("@Payment_ChequeDDNo", ObjBOL.Payment_ChequeDDNo);
            param[6] = new SqlParameter("@Payment_DateDD", ObjBOL.Payment_DateDD);
            param[7] = new SqlParameter("@Payment_BankNameDD", ObjBOL.Payment_BankNameDD);
            param[8] = new SqlParameter("@Payment_AccountNoDD", ObjBOL.Payment_AccountNoDD);
            param[9] = new SqlParameter("@Payment_ScanCopyDD", ObjBOL.Payment_ScanCopyDD);
            param[10] = new SqlParameter("@Payment_StatusDD", ObjBOL.Payment_StatusDD);
            param[11] = new SqlParameter("@Payment_RemarksDD", ObjBOL.Payment_RemarksDD);
            param[12] = new SqlParameter("@Payment_DateOnline", ObjBOL.Payment_DateOnline);
            param[13] = new SqlParameter("@Payment_BankNameOnline", ObjBOL.Payment_BankNameOnline);
            param[14] = new SqlParameter("@Payment_PlaceOnline", ObjBOL.Payment_PlaceOnline);
            param[15] = new SqlParameter("@Payment_StatusOnline", ObjBOL.Payment_StatusOnline);
            param[16] = new SqlParameter("@Payment_RemarksOnline", ObjBOL.Payment_RemarksOnline);
            param[17] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPPaymentDetails", param);
            return ds;
        }
    }

    public class DALPatientMaster : Connection
    {
        public string SavePatientMaster(BOLPatientMaster ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Patient_ID", ObjBOL.Patient_ID);
            param[2] = new SqlParameter("@Patient_Name", ObjBOL.Patient_Name);
            param[3] = new SqlParameter("@Patient_CrNo", ObjBOL.Patient_CrNo);
            param[4] = new SqlParameter("@Patient_DateOfBirth", ObjBOL.Patient_DateOfBirth);
            param[5] = new SqlParameter("@Patient_Gender", ObjBOL.Patient_Gender);
            param[6] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPPatientMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetPatientMaster(BOLPatientMaster ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Patient_ID", ObjBOL.Patient_ID);
            param[2] = new SqlParameter("@Patient_Name", ObjBOL.Patient_Name);
            param[3] = new SqlParameter("@Patient_CrNo", ObjBOL.Patient_CrNo);
            param[4] = new SqlParameter("@Patient_DateOfBirth", ObjBOL.Patient_DateOfBirth);
            param[5] = new SqlParameter("@Patient_Gender", ObjBOL.Patient_Gender);
            param[6] = new SqlParameter("@op", ObjBOL.op);

            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPPatientMaster", param);
            return ds;
        }

        public DataSet GetPatientMasterMaxID(BOLPatientMaster ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Patient_ID", ObjBOL.Patient_ID);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPManageSurgicalPathologyReport", param);
            return ds;
        }

        public DataSet GetPatientMasterCount(BOLPatientMaster ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Patient_ID", ObjBOL.Patient_ID);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPManageSurgicalPathologyReport", param);
            return ds;
        }

        public String DeletePatientMaster(BOLPatientMaster ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Patient_ID", ObjBOL.Patient_ID);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPManageSurgicalPathologyReport", param);
            string Msg = "Successfully Deleted !";
            return Msg;
        }
        public DataSet GetAllPatientMaster(BOLPatientMaster ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Patient_ID", ObjBOL.Patient_ID);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPManageSurgicalPathologyReport", param);
            return ds;
        }
        public DataSet SearchPatientMaster(BOLPatientMaster ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Patient_CrNo", ObjBOL.Patient_CrNo);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPSearchPatient", param);
            return ds;
        }
    }

    public class DALSurgicalPathologyReport : Connection
    {
        public string SaveSurgicalPathologyReport(BOLSurgicalPathologyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[35];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Sur_Path_ID", ObjBOL.Sur_Path_ID);
            param[2] = new SqlParameter("@Sur_Path_BiopsyNo", ObjBOL.Sur_Path_BiopsyNo);
            param[3] = new SqlParameter("@Sur_Path_ClinicNo", ObjBOL.Sur_Path_ClinicNo);
            param[4] = new SqlParameter("@Sur_Path_ReqDate", ObjBOL.Sur_Path_ReqDate);
            param[5] = new SqlParameter("@Sur_Path_Clinician", ObjBOL.Sur_Path_Clinician);
            param[6] = new SqlParameter("@Sur_Path_AdmissionNo", ObjBOL.Sur_Path_AdmissionNo);
            param[7] = new SqlParameter("@Sur_Path_ClinicalDiag", ObjBOL.Sur_Path_ClinicalDiag);
            param[8] = new SqlParameter("@Sur_Path_AdditionalInfo", ObjBOL.Sur_Path_AdditionalInfo);
            param[9] = new SqlParameter("@Sur_Path_Address", ObjBOL.Sur_Path_Address);
            param[10] = new SqlParameter("@Sur_Path_PrvBiopsie", ObjBOL.Sur_Path_PrvBiopsie);
            param[11] = new SqlParameter("@Sur_Path_AgeY", ObjBOL.Sur_Path_AgeY);
            param[12] = new SqlParameter("@Sur_Path_AgeM", ObjBOL.Sur_Path_AgeM);
            param[13] = new SqlParameter("@Sur_Path_AgeD", ObjBOL.Sur_Path_AgeD);
            param[14] = new SqlParameter("@Sur_Path_Typist", ObjBOL.Sur_Path_Typist);
            param[15] = new SqlParameter("@Sur_Path_Location", ObjBOL.Sur_Path_Location);
            param[16] = new SqlParameter("@Sur_Path_RecDate", ObjBOL.Sur_Path_RecDate);
            param[17] = new SqlParameter("@Sur_Path_RecCooments", ObjBOL.Sur_Path_RecCooments);
            param[18] = new SqlParameter("@Sur_Path_GrossedDate", ObjBOL.Sur_Path_GrossedDate);
            param[19] = new SqlParameter("@Sur_Path_GrossedComments", ObjBOL.Sur_Path_GrossedComments);
            param[20] = new SqlParameter("@Sur_Path_ProcessedDate", ObjBOL.Sur_Path_ProcessedDate);
            param[21] = new SqlParameter("@Sur_Path_ProcessedComments", ObjBOL.Sur_Path_ProcessedComments);
            param[22] = new SqlParameter("@Sur_Path_BlockedDate", ObjBOL.Sur_Path_BlockedDate);
            param[23] = new SqlParameter("@Sur_Path_BlockedComments", ObjBOL.Sur_Path_BlockedComments);
            param[24] = new SqlParameter("@Sur_Path_SectionedDate", ObjBOL.Sur_Path_SectionedDate);
            param[25] = new SqlParameter("@Sur_Path_SectionedComments", ObjBOL.Sur_Path_SectionedComments);
            param[26] = new SqlParameter("@Sur_Path_StainedDate", ObjBOL.Sur_Path_StainedDate);
            param[27] = new SqlParameter("@Sur_Path_StainedComments", ObjBOL.Sur_Path_StainedComments);
            param[28] = new SqlParameter("@Sur_Path_ReportedDate", ObjBOL.Sur_Path_ReportedDate);
            param[29] = new SqlParameter("@Sur_Path_ReportedComments", ObjBOL.Sur_Path_ReportedComments);
            param[30] = new SqlParameter("@Sur_Path_SpecialStain", ObjBOL.Sur_Path_SpecialStain);
            param[31] = new SqlParameter("@Sur_Path_Immunohistochemistry", ObjBOL.Sur_Path_Immunohistochemistry);
            param[32] = new SqlParameter("@Patient_ID", ObjBOL.PatientID);
            param[33] = new SqlParameter("@Sur_Path_BedNo", ObjBOL.Sur_Path_BedNo);
            //Sur_Path_BedNo
            param[34] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPSurgicalPathologyReport", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetSurgicalPathologyReport(BOLSurgicalPathologyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[37];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Sur_Path_ID", ObjBOL.Sur_Path_ID);
            param[2] = new SqlParameter("@Sur_Path_BiopsyNo", ObjBOL.Sur_Path_BiopsyNo);
            param[3] = new SqlParameter("@Sur_Path_ClinicNo", ObjBOL.Sur_Path_ClinicNo);
            param[4] = new SqlParameter("@Sur_Path_ReqDate", ObjBOL.Sur_Path_ReqDate);
            param[5] = new SqlParameter("@Sur_Path_Clinician", ObjBOL.Sur_Path_Clinician);
            param[6] = new SqlParameter("@Sur_Path_CrNo", ObjBOL.Sur_Path_CrNo);
            param[7] = new SqlParameter("@Sur_Path_AdmissionNo", ObjBOL.Sur_Path_AdmissionNo);
            param[8] = new SqlParameter("@Sur_Path_ClinicalDiag", ObjBOL.Sur_Path_ClinicalDiag);
            param[9] = new SqlParameter("@Sur_Path_PatientName", ObjBOL.Sur_Path_PatientName);
            param[10] = new SqlParameter("@Sur_Path_AdditionalInfo", ObjBOL.Sur_Path_AdditionalInfo);
            param[11] = new SqlParameter("@Sur_Path_Address", ObjBOL.Sur_Path_Address);
            param[12] = new SqlParameter("@Sur_Path_PrvBiopsie", ObjBOL.Sur_Path_PrvBiopsie);
            param[13] = new SqlParameter("@Sur_Path_AgeY", ObjBOL.Sur_Path_AgeY);
            param[14] = new SqlParameter("@Sur_Path_AgeM", ObjBOL.Sur_Path_AgeM);
            param[15] = new SqlParameter("@Sur_Path_AgeD", ObjBOL.Sur_Path_AgeD);
            param[17] = new SqlParameter("@Sur_Path_Typist", ObjBOL.Sur_Path_Typist);
            param[18] = new SqlParameter("@Sur_Path_Location", ObjBOL.Sur_Path_Location);
            param[19] = new SqlParameter("@Sur_Path_RecDate", ObjBOL.Sur_Path_RecDate);
            param[20] = new SqlParameter("@Sur_Path_RecCooments", ObjBOL.Sur_Path_RecCooments);
            param[21] = new SqlParameter("@Sur_Path_GrossedDate", ObjBOL.Sur_Path_GrossedDate);
            param[22] = new SqlParameter("@Sur_Path_GrossedComments", ObjBOL.Sur_Path_GrossedComments);
            param[23] = new SqlParameter("@Sur_Path_ProcessedDate", ObjBOL.Sur_Path_ProcessedDate);
            param[24] = new SqlParameter("@Sur_Path_ProcessedComments", ObjBOL.Sur_Path_ProcessedComments);
            param[25] = new SqlParameter("@Sur_Path_BlockedDate", ObjBOL.Sur_Path_BlockedDate);
            param[26] = new SqlParameter("@Sur_Path_BlockedComments", ObjBOL.Sur_Path_BlockedComments);
            param[27] = new SqlParameter("@Sur_Path_SectionedDate", ObjBOL.Sur_Path_SectionedDate);
            param[28] = new SqlParameter("@Sur_Path_SectionedComments", ObjBOL.Sur_Path_SectionedComments);
            param[29] = new SqlParameter("@Sur_Path_StainedDate", ObjBOL.Sur_Path_StainedDate);
            param[30] = new SqlParameter("@Sur_Path_StainedComments", ObjBOL.Sur_Path_StainedComments);
            param[31] = new SqlParameter("@Sur_Path_ReportedDate", ObjBOL.Sur_Path_ReportedDate);
            param[32] = new SqlParameter("@Sur_Path_ReportedComments", ObjBOL.Sur_Path_ReportedComments);
            param[33] = new SqlParameter("@Sur_Path_SpecialStain", ObjBOL.Sur_Path_SpecialStain);
            param[34] = new SqlParameter("@Sur_Path_Immunohistochemistry", ObjBOL.Sur_Path_Immunohistochemistry);
            param[35] = new SqlParameter("@Patient_ID", ObjBOL.PatientID);
            param[36] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPSurgicalPathologyReport", param);
            return ds;
        }

        public DataSet GetSurgicalPathologyReportMaxID(BOLSurgicalPathologyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Sur_Path_ID", ObjBOL.Sur_Path_ID);

            param[2] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPManageSurgicalPathologyReport", param);
            return ds;
        }

        public DataSet GetSurgicalPathologyReportCount(BOLSurgicalPathologyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Patient_ID", ObjBOL.PatientID);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPManageSurgicalPathologyReport", param);
            return ds;
        }

        public String DeleteSurgicalPathologyReport(BOLSurgicalPathologyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Sur_Path_ID", ObjBOL.Sur_Path_ID);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPManageSurgicalPathologyReport", param);
            string Msg = "Successfully Deleted !";
            return Msg;
        }
        public DataSet GetPatientDetail_2011(BOLSurgicalPathologyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Patient_ID", ObjBOL.PatientID);
            param[2] = new SqlParameter("@Sur_Path_ID", ObjBOL.Sur_Path_ID);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPManagePatientDetail_2011", param);
            return ds;
        }
        public DataSet GetPatientDetail(BOLSurgicalPathologyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Patient_ID", ObjBOL.PatientID);
            param[2] = new SqlParameter("@Sur_Path_ID", ObjBOL.Sur_Path_ID);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPManagePatientDetail", param);
            return ds;
        }
        public DataSet GetAllSurgicalPathologyReport(BOLSurgicalPathologyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Patient_ID", ObjBOL.PatientID);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPManageSurgicalPathologyReport", param);
            return ds;
        }

        public DataSet GetAllSurgicalPathologyReport_2011(BOLSurgicalPathologyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Patient_ID", ObjBOL.PatientID);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPManageSurgicalPathologyReport_2011", param);
            return ds;
        }

        //SearchPathologyReport
        public DataSet SearchPathologyReport(BOLSurgicalPathologyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Sur_Path_BiopsyNo", ObjBOL.Sur_Path_BiopsyNo);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPSearchSurgicalPathologyReport", param);
            return ds;
        }
    }

    public class DALSurgicalPathologyReportDetail : Connection
    {
        public string SaveSurgicalPathologyReportDetail(BOLSurgicalPathologyReportDetail ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Sur_Path_ID_Detail", ObjBOL.Sur_Path_ID_Detail);
            param[2] = new SqlParameter("@Sur_Path_ID", ObjBOL.Sur_Path_ID);
            param[3] = new SqlParameter("@Sur_Path_Gross", ObjBOL.Sur_Path_Gross);
            param[4] = new SqlParameter("@Sur_Path_Micro", ObjBOL.Sur_Path_Micro);
            param[5] = new SqlParameter("@Sur_Path_Immunohistology", ObjBOL.Sur_Path_Immunohistology);
            param[6] = new SqlParameter("@Sur_Path_SupplementaryReport", ObjBOL.Sur_Path_SupplementaryReport);
            param[7] = new SqlParameter("@Sur_Path_Remarks", ObjBOL.Sur_Path_Remarks);
            param[8] = new SqlParameter("@Sur_Path_Dated", ObjBOL.Sur_Path_Dated);
            param[9] = new SqlParameter("@Sur_Path_Res", ObjBOL.Sur_Path_Res);
            param[10] = new SqlParameter("@Sur_Path_Faculty1", ObjBOL.Sur_Path_Faculty1);
            param[11] = new SqlParameter("@Sur_Path_Faculty2", ObjBOL.Sur_Path_Faculty2);
            param[12] = new SqlParameter("@Sur_Path_Faculty3", ObjBOL.Sur_Path_Faculty3);
            param[13] = new SqlParameter("@Sur_Path_Ok", ObjBOL.Sur_Path_Ok);
            param[14] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPSurgicalPathologyReport_Detail", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetSurgicalPathologyReportDetail(BOLSurgicalPathologyReportDetail ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Sur_Path_ID_Detail", ObjBOL.Sur_Path_ID_Detail);
            param[2] = new SqlParameter("@Sur_Path_ID", ObjBOL.Sur_Path_ID);
            param[3] = new SqlParameter("@Sur_Path_Gross", ObjBOL.Sur_Path_Gross);
            param[4] = new SqlParameter("@Sur_Path_Micro", ObjBOL.Sur_Path_Micro);
            param[5] = new SqlParameter("@Sur_Path_Immunohistology", ObjBOL.Sur_Path_Immunohistology);
            param[6] = new SqlParameter("@Sur_Path_SupplementaryReport", ObjBOL.Sur_Path_SupplementaryReport);
            param[7] = new SqlParameter("@Sur_Path_Remarks", ObjBOL.Sur_Path_Remarks);
            param[8] = new SqlParameter("@Sur_Path_Dated", ObjBOL.Sur_Path_Dated);
            param[9] = new SqlParameter("@Sur_Path_Res", ObjBOL.Sur_Path_Res);
            param[10] = new SqlParameter("@Sur_Path_Faculty1", ObjBOL.Sur_Path_Faculty1);
            param[11] = new SqlParameter("@Sur_Path_Faculty2", ObjBOL.Sur_Path_Faculty2);
            param[12] = new SqlParameter("@Sur_Path_Faculty3", ObjBOL.Sur_Path_Faculty3);
            param[13] = new SqlParameter("@Sur_Path_Ok", ObjBOL.Sur_Path_Ok);
            param[14] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPSurgicalPathologyReport_Detail", param);
            return ds;
        }

        public String DeleteSurgicalPathologyReportDetail(BOLSurgicalPathologyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Sur_Path_ID", ObjBOL.Sur_Path_ID);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPManageSurgicalPathologyReport", param);
            string Msg = "Successfully Deleted !";
            return Msg;
        }
        public DataSet GetAllSurgicalPathologyReportDetail(BOLSurgicalPathologyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Sur_Path_ID", ObjBOL.Sur_Path_ID);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPManageSurgicalPathologyReport", param);
            return ds;
        }
        //SearchPathologyReport
        public DataSet SearchPathologyReportDetail(BOLSurgicalPathologyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Sur_Path_BiopsyNo", ObjBOL.Sur_Path_BiopsyNo);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPSearchSurgicalPathologyReport", param);
            return ds;
        }
    }

    public class DALDiagnosisAutopsy : Connection
    {
        public string SaveDiagnosisAutopsy(BOLDiagnosisAutopsy ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@DiagIDAutopsy", ObjBOL.DiagIDAutopsy);
            param[2] = new SqlParameter("@Autopsy_Path_ID", ObjBOL.Autopsy_Path_ID);
            param[3] = new SqlParameter("@TopographyID", ObjBOL.TopographyID);
            param[4] = new SqlParameter("@MorphologyID", ObjBOL.MorphologyID);
            param[5] = new SqlParameter("@AdditionalInfoAutopsy", ObjBOL.AdditionalInfoAutopsy);
            param[6] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPDiagnosisAutopsy", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetDiagnosisAutopsy(BOLDiagnosisAutopsy ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@DiagIDAutopsy", ObjBOL.DiagIDAutopsy);
            param[2] = new SqlParameter("@Autopsy_Path_ID", ObjBOL.Autopsy_Path_ID);
            param[3] = new SqlParameter("@TopographyID", ObjBOL.TopographyID);
            param[4] = new SqlParameter("@MorphologyID", ObjBOL.MorphologyID);
            param[5] = new SqlParameter("@AdditionalInfoAutopsy", ObjBOL.AdditionalInfoAutopsy);
            param[6] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPDiagnosisAutopsy", param);
            return ds;
        }
    }

    public class DALCPCAutopsy : Connection
    {
        public string SaveCPCAutopsy(BOLCPCAutopsy ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CPCID", ObjBOL.CPCID);
            param[2] = new SqlParameter("@CPCDone", ObjBOL.CPCDone);
            param[3] = new SqlParameter("@CPCDoneBy", ObjBOL.CPCDoneBy);
            param[4] = new SqlParameter("@CPCDoneName", ObjBOL.CPCDoneName);
            param[5] = new SqlParameter("@CPCDoneDate", ObjBOL.CPCDoneDate);
            param[6] = new SqlParameter("@Autopsy_Path_ID", ObjBOL.Autopsy_Path_ID);
            param[7] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPCPCDetail", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetCPCAutopsy(BOLCPCAutopsy ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CPCID", ObjBOL.CPCID);
            param[2] = new SqlParameter("@CPCDone", ObjBOL.CPCDone);
            param[3] = new SqlParameter("@CPCDoneBy", ObjBOL.CPCDoneBy);
            param[4] = new SqlParameter("@CPCDoneName", ObjBOL.CPCDoneName);
            param[5] = new SqlParameter("@CPCDoneDate", ObjBOL.CPCDoneDate);
            param[6] = new SqlParameter("@Autopsy_Path_ID", ObjBOL.Autopsy_Path_ID);
            param[7] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPCPCDetail", param);
            return ds;
        }
    }

    public class DALAutopsyReport : Connection
    {
        public string SaveAutopsyPathologyReport(BOLAutopsyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[87];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Autopsy_Path_ID", ObjBOL.Autopsy_Path_ID);
            param[2] = new SqlParameter("@Autopsy_Path_PMNo", ObjBOL.Autopsy_Path_PMNo);
            param[3] = new SqlParameter("@Autopsy_Path_AdmissionNo", ObjBOL.Autopsy_Path_AdmissionNo);
            param[4] = new SqlParameter("@Autopsy_Path_CategoryID", ObjBOL.Autopsy_Path_CategoryID);
            param[5] = new SqlParameter("@Autopsy_Path_Location", ObjBOL.Autopsy_Path_Location);
            param[6] = new SqlParameter("@Autopsy_Path_CategoryTypeID", ObjBOL.Autopsy_Path_CategoryTypeID);
            param[7] = new SqlParameter("@Autopsy_Path_BedNo", ObjBOL.Autopsy_Path_BedNo);
            param[8] = new SqlParameter("@Autopsy_Path_PatientName", ObjBOL.Autopsy_Path_PatientName);
            param[9] = new SqlParameter("@Autopsy_Path_ClinicNo", ObjBOL.Autopsy_Path_ClinicNo);
            param[10] = new SqlParameter("@Autopsy_Path_AgeY", ObjBOL.Autopsy_Path_AgeY);
            param[11] = new SqlParameter("@Autopsy_Path_AgeM", ObjBOL.Autopsy_Path_AgeM);
            param[12] = new SqlParameter("@Autopsy_Path_AgeD", ObjBOL.Autopsy_Path_AgeD);
            param[13] = new SqlParameter("@Autopsy_Path_Clinician", ObjBOL.Autopsy_Path_Clinician);
            param[14] = new SqlParameter("@Autopsy_Path_Sex", ObjBOL.Autopsy_Path_Sex);
            param[15] = new SqlParameter("@Autopsy_Path_CrNo", ObjBOL.Autopsy_Path_CrNo);
            param[16] = new SqlParameter("@Autopsy_Path_ClinicalDiag", ObjBOL.Autopsy_Path_ClinicalDiag);
            param[17] = new SqlParameter("@Autopsy_Path_Address", ObjBOL.Autopsy_Path_Address);
            param[18] = new SqlParameter("@Autopsy_Path_Biopsies", ObjBOL.Autopsy_Path_Biopsies);
            param[19] = new SqlParameter("@Autopsy_Path_AddDate", ObjBOL.Autopsy_Path_AddDate);
            param[20] = new SqlParameter("@Autopsy_Path_DeathDate", ObjBOL.Autopsy_Path_DeathDate);
            param[21] = new SqlParameter("@Autopsy_Path_DeathTime", ObjBOL.Autopsy_Path_DeathTime);
            param[22] = new SqlParameter("@Autopsy_Path_Prosector", ObjBOL.Autopsy_Path_Prosector);
            param[23] = new SqlParameter("@Autopsy_Path_AutopsyDate", ObjBOL.Autopsy_Path_AutopsyDate);
            param[24] = new SqlParameter("@Autopsy_Path_AutopsyTime", ObjBOL.Autopsy_Path_AutopsyTime);
            param[25] = new SqlParameter("@Autopsy_Path_Typist", ObjBOL.Autopsy_Path_Typist);
            param[26] = new SqlParameter("@Autopsy_Path_Incision", ObjBOL.Autopsy_Path_Incision);
            param[27] = new SqlParameter("@Autopsy_Path_ExternalFeature", ObjBOL.Autopsy_Path_ExternalFeature);
            param[28] = new SqlParameter("@Autopsy_Path_QuantityPericardial", ObjBOL.Autopsy_Path_QuantityPericardial);
            param[29] = new SqlParameter("@Autopsy_Path_QuantityLPleural", ObjBOL.Autopsy_Path_QuantityLPleural);
            param[30] = new SqlParameter("@Autopsy_Path_QuantityRPleural", ObjBOL.Autopsy_Path_QuantityRPleural);
            param[31] = new SqlParameter("@Autopsy_Path_QuantityPeritonal", ObjBOL.Autopsy_Path_QuantityPeritonal);
            param[32] = new SqlParameter("@Autopsy_Path_CharacterPericardial", ObjBOL.Autopsy_Path_CharacterPericardial);
            param[33] = new SqlParameter("@Autopsy_Path_CharacterLPleural", ObjBOL.Autopsy_Path_CharacterLPleural);
            param[34] = new SqlParameter("@Autopsy_Path_CharacterRPleural", ObjBOL.Autopsy_Path_CharacterRPleural);
            param[35] = new SqlParameter("@Autopsy_Path_CharacterPeritonal", ObjBOL.Autopsy_Path_CharacterPeritonal);
            param[36] = new SqlParameter("@Autopsy_Path_Material", ObjBOL.Autopsy_Path_Material);
            param[37] = new SqlParameter("@Autopsy_Path_Serology1", ObjBOL.Autopsy_Path_Serology1);
            param[38] = new SqlParameter("@Autopsy_Path_Serology2", ObjBOL.Autopsy_Path_Serology2);
            param[39] = new SqlParameter("@Autopsy_Path_Immunoflourescence", ObjBOL.Autopsy_Path_Immunoflourescence);
            param[40] = new SqlParameter("@Autopsy_Path_Immunoglobulins", ObjBOL.Autopsy_Path_Immunoglobulins);
            param[41] = new SqlParameter("@Autopsy_Path_EMStudies", ObjBOL.Autopsy_Path_EMStudies);
            param[42] = new SqlParameter("@Autopsy_Path_TypeofMaterial", ObjBOL.Autopsy_Path_TypeofMaterial);
            param[43] = new SqlParameter("@Autopsy_Path_Micro", ObjBOL.Autopsy_Path_Micro);
            param[44] = new SqlParameter("@Autopsy_Path_FinalAutopsyDiagnosis", ObjBOL.Autopsy_Path_FinalAutopsyDiagnosis);
            param[45] = new SqlParameter("@Autopsy_Path_Dated", ObjBOL.Autopsy_Path_Dated);
            param[46] = new SqlParameter("@Autopsy_Path_Res", ObjBOL.Autopsy_Path_Res);
            param[47] = new SqlParameter("@Autopsy_Path_Faculty1", ObjBOL.Autopsy_Path_Faculty1);
            param[48] = new SqlParameter("@Autopsy_Path_Faculty2", ObjBOL.Autopsy_Path_Faculty2);
            param[49] = new SqlParameter("@Autopsy_Path_Faculty3", ObjBOL.Autopsy_Path_Faculty3);
            param[50] = new SqlParameter("@Autopsy_Path_Ok", ObjBOL.Autopsy_Path_Ok);
            param[51] = new SqlParameter("@Autopsy_Path_GestationalAge", ObjBOL.Autopsy_Path_GestationalAge);
            param[52] = new SqlParameter("@Autopsy_Path_Facies", ObjBOL.Autopsy_Path_Facies);
            param[53] = new SqlParameter("@Autopsy_Path_UmbilicalCordNo", ObjBOL.Autopsy_Path_UmbilicalCordNo);
            param[54] = new SqlParameter("@Autopsy_Path_Veins", ObjBOL.Autopsy_Path_Veins);
            param[55] = new SqlParameter("@Autopsy_Path_Catheter", ObjBOL.Autopsy_Path_Catheter);
            param[56] = new SqlParameter("@Autopsy_Path_Haemorrhage", ObjBOL.Autopsy_Path_Haemorrhage);
            param[57] = new SqlParameter("@Autopsy_Path_Exudate", ObjBOL.Autopsy_Path_Exudate);
            param[58] = new SqlParameter("@Autopsy_Path_OtherAbnormality", ObjBOL.Autopsy_Path_OtherAbnormality);
            param[59] = new SqlParameter("@Autopsy_Path_Pneumothorax", ObjBOL.Autopsy_Path_Pneumothorax);
            param[60] = new SqlParameter("@Autopsy_Path_NoOfLobesLeft", ObjBOL.Autopsy_Path_NoOfLobesLeft);
            param[61] = new SqlParameter("@Autopsy_Path_NoOfLobesRight", ObjBOL.Autopsy_Path_NoOfLobesRight);
            param[62] = new SqlParameter("@Autopsy_Path_DuctusArteriosus", ObjBOL.Autopsy_Path_DuctusArteriosus);
            param[63] = new SqlParameter("@Autopsy_Path_Diameter", ObjBOL.Autopsy_Path_Diameter);
            param[64] = new SqlParameter("@Autopsy_Path_Placenta", ObjBOL.Autopsy_Path_Placenta);
            param[65] = new SqlParameter("@Autopsy_Path_CrowntoHeelLengthResult", ObjBOL.Autopsy_Path_CrowntoHeelLengthResult);
            param[66] = new SqlParameter("@Autopsy_Path_CrowntoHeelLengthNormal", ObjBOL.Autopsy_Path_CrowntoHeelLengthNormal);
            param[67] = new SqlParameter("@Autopsy_Path_CrowntoRumpLengthResult", ObjBOL.Autopsy_Path_CrowntoRumpLengthResult);
            param[68] = new SqlParameter("@Autopsy_Path_CrowntoRumpLengthNormal", ObjBOL.Autopsy_Path_CrowntoRumpLengthNormal);
            param[69] = new SqlParameter("@Autopsy_Path_HeadCircumferenceResult", ObjBOL.Autopsy_Path_HeadCircumferenceResult);
            param[70] = new SqlParameter("@Autopsy_Path_HeadCircumferenceNormal", ObjBOL.Autopsy_Path_HeadCircumferenceNormal);
            param[71] = new SqlParameter("@Autopsy_Path_ChestCircumferenceResult", ObjBOL.Autopsy_Path_ChestCircumferenceResult);
            param[72] = new SqlParameter("@Autopsy_Path_ChestCircumferenceNormal", ObjBOL.Autopsy_Path_ChestCircumferenceNormal);
            param[73] = new SqlParameter("@Autopsy_Path_FootLengthResult", ObjBOL.Autopsy_Path_FootLengthResult);
            param[74] = new SqlParameter("@Autopsy_Path_FootLengthNormal", ObjBOL.Autopsy_Path_FootLengthNormal);
            param[75] = new SqlParameter("@Autopsy_Path_WeightAtBirthResult", ObjBOL.Autopsy_Path_WeightAtBirthResult);
            param[76] = new SqlParameter("@Autopsy_Path_WeightAtBirthNormal", ObjBOL.Autopsy_Path_WeightAtBirthNormal);
            param[77] = new SqlParameter("@Autopsy_Path_WeightAtAutopsyResult", ObjBOL.Autopsy_Path_WeightAtAutopsyResult);
            param[78] = new SqlParameter("@Autopsy_Path_WeightAtAutopsyNormal", ObjBOL.Autopsy_Path_WeightAtAutopsyNormal);
            param[79] = new SqlParameter("@Autopsy_Path_Remarks", ObjBOL.Autopsy_Path_Remarks);
            param[80] = new SqlParameter("@Autopsy_Path_GrossAutopsyDiagnose", ObjBOL.Autopsy_Path_GrossAutopsyDiagnose);
            param[81] = new SqlParameter("@Autopsy_Path_Residents", ObjBOL.Autopsy_Path_Residents);
            param[82] = new SqlParameter("@Autopsy_Path_GrossAutopsyDiagnose2", ObjBOL.Autopsy_Path_GrossAutopsyDiagnose2);
            param[83] = new SqlParameter("@Autopsy_Path_GrossAutopsyDiagnose2Faculty1", ObjBOL.Autopsy_Path_GrossAutopsyDiagnose2Faculty1);
            param[84] = new SqlParameter("@Autopsy_Path_GrossAutopsyDiagnose2Faculty2", ObjBOL.Autopsy_Path_GrossAutopsyDiagnose2Faculty2);
            param[85] = new SqlParameter("@Autopsy_Path_GrossAutopsyDiagnose2Faculty3", ObjBOL.Autopsy_Path_GrossAutopsyDiagnose2Faculty3);
            param[86] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPAutopsyPathologyReport", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetAutopsyPathologyReport(BOLAutopsyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[88];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Autopsy_Path_ID", ObjBOL.Autopsy_Path_ID);
            param[2] = new SqlParameter("@Autopsy_Path_PMNo", ObjBOL.Autopsy_Path_PMNo);
            param[3] = new SqlParameter("@Autopsy_Path_AdmissionNo", ObjBOL.Autopsy_Path_AdmissionNo);
            param[4] = new SqlParameter("@Autopsy_Path_CategoryID", ObjBOL.Autopsy_Path_CategoryID);
            param[5] = new SqlParameter("@Autopsy_Path_Location", ObjBOL.Autopsy_Path_Location);
            param[6] = new SqlParameter("@Autopsy_Path_CategoryTypeID", ObjBOL.Autopsy_Path_CategoryTypeID);
            param[7] = new SqlParameter("@Autopsy_Path_BedNo", ObjBOL.Autopsy_Path_BedNo);
            param[8] = new SqlParameter("@Autopsy_Path_PatientName", ObjBOL.Autopsy_Path_PatientName);
            param[9] = new SqlParameter("@Autopsy_Path_ClinicNo", ObjBOL.Autopsy_Path_ClinicNo);
            param[10] = new SqlParameter("@Autopsy_Path_AgeY", ObjBOL.Autopsy_Path_AgeY);
            param[11] = new SqlParameter("@Autopsy_Path_AgeM", ObjBOL.Autopsy_Path_AgeM);
            param[12] = new SqlParameter("@Autopsy_Path_AgeD", ObjBOL.Autopsy_Path_AgeD);
            param[13] = new SqlParameter("@Autopsy_Path_Clinician", ObjBOL.Autopsy_Path_Clinician);
            param[14] = new SqlParameter("@Autopsy_Path_Sex", ObjBOL.Autopsy_Path_Sex);
            param[15] = new SqlParameter("@Autopsy_Path_CrNo", ObjBOL.Autopsy_Path_CrNo);
            param[16] = new SqlParameter("@Autopsy_Path_ClinicalDiag", ObjBOL.Autopsy_Path_ClinicalDiag);
            param[17] = new SqlParameter("@Autopsy_Path_Address", ObjBOL.Autopsy_Path_Address);
            param[18] = new SqlParameter("@Autopsy_Path_Biopsies", ObjBOL.Autopsy_Path_Biopsies);
            param[19] = new SqlParameter("@Autopsy_Path_AddDate", ObjBOL.Autopsy_Path_AddDate);
            param[20] = new SqlParameter("@Autopsy_Path_DeathDate", ObjBOL.Autopsy_Path_DeathDate);
            param[21] = new SqlParameter("@Autopsy_Path_DeathTime", ObjBOL.Autopsy_Path_DeathTime);
            param[22] = new SqlParameter("@Autopsy_Path_Prosector", ObjBOL.Autopsy_Path_Prosector);
            param[23] = new SqlParameter("@Autopsy_Path_AutopsyDate", ObjBOL.Autopsy_Path_AutopsyDate);
            param[24] = new SqlParameter("@Autopsy_Path_AutopsyTime", ObjBOL.Autopsy_Path_AutopsyTime);
            param[25] = new SqlParameter("@Autopsy_Path_Typist", ObjBOL.Autopsy_Path_Typist);
            param[26] = new SqlParameter("@Autopsy_Path_Incision", ObjBOL.Autopsy_Path_Incision);
            param[27] = new SqlParameter("@Autopsy_Path_ExternalFeature", ObjBOL.Autopsy_Path_ExternalFeature);
            param[28] = new SqlParameter("@Autopsy_Path_QuantityPericardial", ObjBOL.Autopsy_Path_QuantityPericardial);
            param[29] = new SqlParameter("@Autopsy_Path_QuantityLPleural", ObjBOL.Autopsy_Path_QuantityLPleural);
            param[30] = new SqlParameter("@Autopsy_Path_QuantityRPleural", ObjBOL.Autopsy_Path_QuantityRPleural);
            param[31] = new SqlParameter("@Autopsy_Path_QuantityPeritonal", ObjBOL.Autopsy_Path_QuantityPeritonal);
            param[32] = new SqlParameter("@Autopsy_Path_CharacterPericardial", ObjBOL.Autopsy_Path_CharacterPericardial);
            param[33] = new SqlParameter("@Autopsy_Path_CharacterLPleural", ObjBOL.Autopsy_Path_CharacterLPleural);
            param[34] = new SqlParameter("@Autopsy_Path_CharacterRPleural", ObjBOL.Autopsy_Path_CharacterRPleural);
            param[35] = new SqlParameter("@Autopsy_Path_CharacterPeritonal", ObjBOL.Autopsy_Path_CharacterPeritonal);
            param[36] = new SqlParameter("@Autopsy_Path_Material", ObjBOL.Autopsy_Path_Material);
            param[37] = new SqlParameter("@Autopsy_Path_Serology1", ObjBOL.Autopsy_Path_Serology1);
            param[38] = new SqlParameter("@Autopsy_Path_Serology2", ObjBOL.Autopsy_Path_Serology2);
            param[39] = new SqlParameter("@Autopsy_Path_Immunoflourescence", ObjBOL.Autopsy_Path_Immunoflourescence);
            param[40] = new SqlParameter("@Autopsy_Path_Immunoglobulins", ObjBOL.Autopsy_Path_Immunoglobulins);
            param[41] = new SqlParameter("@Autopsy_Path_EMStudies", ObjBOL.Autopsy_Path_EMStudies);
            param[42] = new SqlParameter("@Autopsy_Path_TypeofMaterial", ObjBOL.Autopsy_Path_TypeofMaterial);
            param[43] = new SqlParameter("@Autopsy_Path_Micro", ObjBOL.Autopsy_Path_Micro);
            param[44] = new SqlParameter("@Autopsy_Path_FinalAutopsyDiagnosis", ObjBOL.Autopsy_Path_FinalAutopsyDiagnosis);
            param[45] = new SqlParameter("@Autopsy_Path_Dated", ObjBOL.Autopsy_Path_Dated);
            param[46] = new SqlParameter("@Autopsy_Path_Res", ObjBOL.Autopsy_Path_Res);
            param[47] = new SqlParameter("@Autopsy_Path_Faculty1", ObjBOL.Autopsy_Path_Faculty1);
            param[48] = new SqlParameter("@Autopsy_Path_Faculty2", ObjBOL.Autopsy_Path_Faculty2);
            param[49] = new SqlParameter("@Autopsy_Path_Faculty3", ObjBOL.Autopsy_Path_Faculty3);
            param[50] = new SqlParameter("@Autopsy_Path_Ok", ObjBOL.Autopsy_Path_Ok);
            param[51] = new SqlParameter("@Autopsy_Path_GestationalAge", ObjBOL.Autopsy_Path_GestationalAge);
            param[52] = new SqlParameter("@Autopsy_Path_Facies", ObjBOL.Autopsy_Path_Facies);
            param[53] = new SqlParameter("@Autopsy_Path_UmbilicalCordNo", ObjBOL.Autopsy_Path_UmbilicalCordNo);
            param[54] = new SqlParameter("@Autopsy_Path_Veins", ObjBOL.Autopsy_Path_Veins);
            param[55] = new SqlParameter("@Autopsy_Path_Catheter", ObjBOL.Autopsy_Path_Catheter);
            param[56] = new SqlParameter("@Autopsy_Path_Haemorrhage", ObjBOL.Autopsy_Path_Haemorrhage);
            param[57] = new SqlParameter("@Autopsy_Path_Exudate", ObjBOL.Autopsy_Path_Exudate);
            param[58] = new SqlParameter("@Autopsy_Path_OtherAbnormality", ObjBOL.Autopsy_Path_OtherAbnormality);
            param[59] = new SqlParameter("@Autopsy_Path_Pneumothorax", ObjBOL.Autopsy_Path_Pneumothorax);
            param[60] = new SqlParameter("@Autopsy_Path_NoOfLobesLeft", ObjBOL.Autopsy_Path_NoOfLobesLeft);
            param[61] = new SqlParameter("@Autopsy_Path_NoOfLobesRight", ObjBOL.Autopsy_Path_NoOfLobesRight);
            param[62] = new SqlParameter("@Autopsy_Path_DuctusArteriosus", ObjBOL.Autopsy_Path_DuctusArteriosus);
            param[63] = new SqlParameter("@Autopsy_Path_Diameter", ObjBOL.Autopsy_Path_Diameter);
            param[64] = new SqlParameter("@Autopsy_Path_Placenta", ObjBOL.Autopsy_Path_Placenta);
            param[65] = new SqlParameter("@Autopsy_Path_CrowntoHeelLengthResult", ObjBOL.Autopsy_Path_CrowntoHeelLengthResult);
            param[66] = new SqlParameter("@Autopsy_Path_CrowntoHeelLengthNormal", ObjBOL.Autopsy_Path_CrowntoHeelLengthNormal);
            param[67] = new SqlParameter("@Autopsy_Path_CrowntoRumpLengthResult", ObjBOL.Autopsy_Path_CrowntoRumpLengthResult);
            param[68] = new SqlParameter("@Autopsy_Path_CrowntoRumpLengthNormal", ObjBOL.Autopsy_Path_CrowntoRumpLengthNormal);
            param[69] = new SqlParameter("@Autopsy_Path_HeadCircumferenceResult", ObjBOL.Autopsy_Path_HeadCircumferenceResult);
            param[70] = new SqlParameter("@Autopsy_Path_HeadCircumferenceNormal", ObjBOL.Autopsy_Path_HeadCircumferenceNormal);
            param[71] = new SqlParameter("@Autopsy_Path_ChestCircumferenceResult", ObjBOL.Autopsy_Path_ChestCircumferenceResult);
            param[72] = new SqlParameter("@Autopsy_Path_ChestCircumferenceNormal", ObjBOL.Autopsy_Path_ChestCircumferenceNormal);
            param[73] = new SqlParameter("@Autopsy_Path_FootLengthResult", ObjBOL.Autopsy_Path_FootLengthResult);
            param[74] = new SqlParameter("@Autopsy_Path_FootLengthNormal", ObjBOL.Autopsy_Path_FootLengthNormal);
            param[75] = new SqlParameter("@Autopsy_Path_WeightAtBirthResult", ObjBOL.Autopsy_Path_WeightAtBirthResult);
            param[76] = new SqlParameter("@Autopsy_Path_WeightAtBirthNormal", ObjBOL.Autopsy_Path_WeightAtBirthNormal);
            param[77] = new SqlParameter("@Autopsy_Path_WeightAtAutopsyResult", ObjBOL.Autopsy_Path_WeightAtAutopsyResult);
            param[78] = new SqlParameter("@Autopsy_Path_WeightAtAutopsyNormal", ObjBOL.Autopsy_Path_WeightAtAutopsyNormal);
            param[79] = new SqlParameter("@Autopsy_Path_Remarks", ObjBOL.Autopsy_Path_Remarks);
            param[80] = new SqlParameter("@Autopsy_Path_GrossAutopsyDiagnose", ObjBOL.Autopsy_Path_GrossAutopsyDiagnose);
            param[81] = new SqlParameter("@Autopsy_Path_Residents", ObjBOL.Autopsy_Path_Residents);
            param[82] = new SqlParameter("@Autopsy_Path_GrossAutopsyDiagnose2", ObjBOL.Autopsy_Path_GrossAutopsyDiagnose2);
            param[83] = new SqlParameter("@Autopsy_Path_GrossAutopsyDiagnose2Faculty1", ObjBOL.Autopsy_Path_GrossAutopsyDiagnose2Faculty1);
            param[84] = new SqlParameter("@Autopsy_Path_GrossAutopsyDiagnose2Faculty2", ObjBOL.Autopsy_Path_GrossAutopsyDiagnose2Faculty2);
            param[85] = new SqlParameter("@Autopsy_Path_GrossAutopsyDiagnose2Faculty3", ObjBOL.Autopsy_Path_GrossAutopsyDiagnose2Faculty3);
            param[86] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPAutopsyPathologyReport", param);
            return ds;
        }

        public DataSet GetAutopsyPathologyReportMaxID(BOLAutopsyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Autopsy_Path_ID", ObjBOL.Autopsy_Path_ID);

            param[2] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPManageAutopsyPathologyReport", param);
            return ds;
        }

        public DataSet GetAutopsyPathologyReportCount(BOLAutopsyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Autopsy_Path_ID", ObjBOL.Autopsy_Path_ID);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPManageAutopsyPathologyReport", param);
            return ds;
        }

        public String DeleteAutopsyPathologyReport(BOLAutopsyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Autopsy_Path_ID", ObjBOL.Autopsy_Path_ID);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPManageAutopsyPathologyReport", param);
            string Msg = "Successfully Deleted !";
            return Msg;
        }
        public DataSet GetAllAutopsyPathologyReport(BOLAutopsyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Autopsy_Path_ID", ObjBOL.Autopsy_Path_ID);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPManageAutopsyPathologyReport", param);
            return ds;
        }

        public DataSet SearchAutopsyPathologyReport(BOLAutopsyReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Autopsy_Path_PMNo", ObjBOL.Autopsy_Path_PMNo);
            param[2] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPSearchAutopsyPathologyReport", param);
            return ds;
        }
    }

    public class DALCustomerCategoryMaster : Connection
    {
        public string SaveCustomerCategory(BOLCustomerCategoryMaster ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CustomerCategoryID", ObjBOL.CustomerCategoryID);
            param[2] = new SqlParameter("@CustomerCategoryName", ObjBOL.CustomerCategoryName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPCustomerCategoryMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetCustomerCategory(BOLCustomerCategoryMaster ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CustomerCategoryID", ObjBOL.CustomerCategoryID);
            param[2] = new SqlParameter("@CustomerCategoryName", ObjBOL.CustomerCategoryName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPCustomerCategoryMaster", param);
            return ds;
        }
    }

    public class DALProductMaster : Connection
    {
        public string SaveProduct(BOLProductMaster ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ProductID", ObjBOL.ProductID);
            param[2] = new SqlParameter("@ProductName", ObjBOL.ProductName);
            param[3] = new SqlParameter("@ParentID", ObjBOL.ParentID);
            param[4] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPProductMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetProducts(BOLProductMaster ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ProductID", ObjBOL.ProductID);
            param[2] = new SqlParameter("@ProductName", ObjBOL.ProductName);
            param[3] = new SqlParameter("@ParentID", ObjBOL.ParentID);
            param[4] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPProductMaster", param);
            return ds;
        }
    }

    public class DALTrainingDetailMaster : Connection
    {
        public string SaveTrainingDetail(BOLTrainingDetailMaster ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@TrainingDetailID", ObjBOL.TrainingDetailID);
            param[2] = new SqlParameter("@TrainingDetailName", ObjBOL.TrainingDetailName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPTrainingDetailMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetTrainingDetail(BOLTrainingDetailMaster ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@TrainingDetailID", ObjBOL.TrainingDetailID);
            param[2] = new SqlParameter("@TrainingDetailName", ObjBOL.TrainingDetailName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPTrainingDetailMaster", param);
            return ds;
        }
    }

    public class DALProductSubtitle : Connection
    {
        public string SaveProductSubtitle(BOLProductSubtitle ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ProductSubtitleID", ObjBOL.ProductSubtitleID);
            param[2] = new SqlParameter("@ProductSubtitleName", ObjBOL.ProductSubtitleName);
            param[3] = new SqlParameter("@ProductID", ObjBOL.ProductID);
            param[4] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPProductSubtitleMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetProductSubtitle(BOLProductSubtitle ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ProductSubtitleID", ObjBOL.ProductSubtitleID);
            param[2] = new SqlParameter("@ProductSubtitleName", ObjBOL.ProductSubtitleName);
            param[3] = new SqlParameter("@ProductID", ObjBOL.ProductID);
            param[4] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPProductSubtitleMaster", param);
            return ds;
        }
    }

    public class DALStateDistCity : Connection
    {
        public string SaveState(BOLStateDistCity ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[2] = new SqlParameter("@StateName", ObjBOL.StateName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPStateMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetState(BOLStateDistCity ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[2] = new SqlParameter("@StateName", ObjBOL.StateName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPStateMaster", param);
            return ds;
        }

        public DataSet GetCountry(BOLStateDistCity ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Get_CommonData", param);
            return ds;
        }

        public string SaveDistrict(BOLStateDistCity ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@DistrictID", ObjBOL.DistrictID);
            param[2] = new SqlParameter("@DistrictName", ObjBOL.DistrictName);
            param[3] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[4] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPDistrictMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetDistrict(BOLStateDistCity ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@DistrictID", ObjBOL.DistrictID);
            param[2] = new SqlParameter("@DistrictName", ObjBOL.DistrictName);
            param[3] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[4] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPDistrictMaster", param);
            return ds;
        }

        public string SaveCity(BOLStateDistCity ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CityID", ObjBOL.CityID);
            param[2] = new SqlParameter("@CityName", ObjBOL.CityName);
            param[3] = new SqlParameter("@DistrictID", ObjBOL.DistrictID);
            param[4] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[5] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPCityMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetCity(BOLStateDistCity ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CityID", ObjBOL.CityID);
            param[2] = new SqlParameter("@CityName", ObjBOL.CityName);
            param[3] = new SqlParameter("@DistrictID", ObjBOL.DistrictID);
            param[4] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[5] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPCityMaster", param);
            return ds;
        }
    }

    public class DALTopography : Connection
    {
        public string SaveTopography(BOLTopography ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@TopographyID", ObjBOL.TopographyID);
            param[2] = new SqlParameter("@TopographyCode", ObjBOL.TopographyCode);
            param[3] = new SqlParameter("@TopographyName", ObjBOL.TopographyName);
            param[4] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPTopographyMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetTopography(BOLTopography ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@TopographyID", ObjBOL.TopographyID);
            param[2] = new SqlParameter("@TopographyCode", ObjBOL.TopographyCode);
            param[3] = new SqlParameter("@TopographyName", ObjBOL.TopographyName);
            param[4] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPTopographyMaster", param);
            return ds;
        }
    }

    public class DALCategory : Connection
    {
        public string SaveCategory(BOLCategory ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CategoryID", ObjBOL.CategoryID);
            param[2] = new SqlParameter("@CategoryName", ObjBOL.CategoryName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPCategoryMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetCategory(BOLCategory ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CategoryID", ObjBOL.CategoryID);
            param[2] = new SqlParameter("@CategoryName", ObjBOL.CategoryName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPCategoryMaster", param);
            return ds;
        }
    }

    public class DALCategoryType : Connection
    {
        public string SaveCategoryType(BOLCategoryType ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CategoryTypeID", ObjBOL.CategoryTypeID);
            param[2] = new SqlParameter("@CategoryTypeName", ObjBOL.CategoryTypeName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPCategoryTypeMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetCategoryType(BOLCategoryType ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CategoryTypeID", ObjBOL.CategoryTypeID);
            param[2] = new SqlParameter("@CategoryTypeName", ObjBOL.CategoryTypeName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPCategoryTypeMaster", param);
            return ds;
        }
    }

    public class DALFaculty : Connection
    {
        public string SaveFaculty(BOLFaculty ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@FacultyID", ObjBOL.FacultyID);
            param[2] = new SqlParameter("@FacultyCode", ObjBOL.FacultyCode);
            param[3] = new SqlParameter("@FacultyName", ObjBOL.FacultyName);
            param[4] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPFacultyMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetFaculty(BOLFaculty ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@FacultyID", ObjBOL.FacultyID);
            param[2] = new SqlParameter("@FacultyCode", ObjBOL.FacultyCode);
            param[3] = new SqlParameter("@FacultyName", ObjBOL.FacultyName);
            param[4] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPFacultyMaster", param);
            return ds;
        }
    }

    public class DALOrgan : Connection
    {
        public string SaveOrgan(BOLOrgan ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@OrganID", ObjBOL.OrganID);
            param[2] = new SqlParameter("@OrganName", ObjBOL.OrganName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPOrganMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetOrgan(BOLOrgan ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@OrganID", ObjBOL.OrganID);
            param[2] = new SqlParameter("@OrganName", ObjBOL.OrganName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPOrganMaster", param);
            return ds;
        }
    }

    public class DALSufix : Connection
    {
        public string SaveSufix(BOLSufix ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@SufixID", ObjBOL.SufixID);
            param[2] = new SqlParameter("@SufixName", ObjBOL.SufixName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPSufixMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet Getsufix(BOLSufix ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@SufixID", ObjBOL.SufixID);
            param[2] = new SqlParameter("@SufixName", ObjBOL.SufixName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPSufixMaster", param);
            return ds;
        }
    }

    public class DALPrefix : Connection
    {
        public string SavePrefix(BOLPrefix ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@PrefixID", ObjBOL.PrefixID);
            param[2] = new SqlParameter("@PrefixName", ObjBOL.PrefixName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPPrefixMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetPrefix(BOLPrefix ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@PrefixID", ObjBOL.PrefixID);
            param[2] = new SqlParameter("@PrefixName", ObjBOL.PrefixName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPPrefixMaster", param);
            return ds;
        }
    }
    public class DALMorphology : Connection
    {
        public string SaveMorphology(BOLMorphology ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@MorphologyID", ObjBOL.MarphologyID);
            param[2] = new SqlParameter("@MorphologyCode", ObjBOL.MorphologyCode);
            param[3] = new SqlParameter("@MorphologyName", ObjBOL.MorphologyName);
            param[4] = new SqlParameter("@TopographyID", ObjBOL.TopographyID);
            param[5] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPMorphologyMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetMorphology(BOLMorphology ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@MorphologyID", ObjBOL.MarphologyID);
            param[2] = new SqlParameter("@MorphologyCode", ObjBOL.MorphologyCode);
            param[3] = new SqlParameter("@MorphologyName", ObjBOL.MorphologyName);
            param[4] = new SqlParameter("@TopographyID", ObjBOL.TopographyID);
            param[5] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPMorphologyMaster", param);
            return ds;
        }
    }



    public class DALRoles : Connection
    {
        public string SaveRoles(BOLRoles ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@RoleID", ObjBOL.RoleID);
            param[2] = new SqlParameter("@RoleName", ObjBOL.RoleName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPEmployeeRoleMaster", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetRoles(BOLRoles ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@RoleID", ObjBOL.RoleID);
            param[2] = new SqlParameter("@RoleName", ObjBOL.RoleName);
            param[3] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPEmployeeRoleMaster", param);
            return ds;
        }
    }

    public class DALManageEmployees : Connection
    {
        public string SaveEmployees(BOLManageEmployees ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[21];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[2] = new SqlParameter("@Branch", ObjBOL.Branch);
            param[3] = new SqlParameter("@Passwd", ObjBOL.Passwd);
            param[4] = new SqlParameter("@Username", ObjBOL.Username);
            param[5] = new SqlParameter("@Department", ObjBOL.Department);
            param[6] = new SqlParameter("@FirstName", ObjBOL.FirstName);
            param[7] = new SqlParameter("@LastName", ObjBOL.LastName);
            param[8] = new SqlParameter("@Address", ObjBOL.Address);
            param[9] = new SqlParameter("@City", ObjBOL.City);
            param[10] = new SqlParameter("@StateOrProvince", ObjBOL.StateOrProvince);
            param[11] = new SqlParameter("@CountryId", ObjBOL.CountryId);
            param[12] = new SqlParameter("@PostalCode", ObjBOL.PostalCode);
            param[13] = new SqlParameter("@HomePhone", ObjBOL.HomePhone);
            param[14] = new SqlParameter("@OfficeExtension", ObjBOL.OfficeExtension);
            param[15] = new SqlParameter("@CellPhone", ObjBOL.CellPhone);
            param[16] = new SqlParameter("@Notes", ObjBOL.Notes);
            param[17] = new SqlParameter("@Active", ObjBOL.Active);
            param[18] = new SqlParameter("@Email", ObjBOL.Email);
            param[20] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageEmployees", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetEmployees(BOLManageEmployees ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Passwd", ObjBOL.Passwd);
            param[2] = new SqlParameter("@Username", ObjBOL.Username);
            param[3] = new SqlParameter("@operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageEmployees", param);
            return ds;
        }

        public DataSet GetEmployee(BOLManageEmployees ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageEmployees", param);
            return ds;
        }
    }

    public class DALManageShipper : Connection
    {
        public string SaveShipper(BOLManageShippers ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ShipperID", ObjBOL.ShipperID);
            param[2] = new SqlParameter("@FirstName", ObjBOL.FirstName);
            param[3] = new SqlParameter("@LastName", ObjBOL.LastName);
            param[4] = new SqlParameter("@CompanyName", ObjBOL.CompanyName);
            param[5] = new SqlParameter("@StreetAddress", ObjBOL.StreetAddress);
            param[6] = new SqlParameter("@City", ObjBOL.City);
            param[7] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[8] = new SqlParameter("@Phone", ObjBOL.Phone);
            param[9] = new SqlParameter("@Fax", ObjBOL.Fax);
            param[10] = new SqlParameter("@TollFree", ObjBOL.TollFree);
            param[11] = new SqlParameter("@TollFax", ObjBOL.TollFax);
            param[12] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageShippers", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public string SaveShipperMember(BOLManageShippers ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@operation", ObjBOL.operation);
            param[2] = new SqlParameter("@ShipperID", ObjBOL.ShipperID);
            param[3] = new SqlParameter("@FirstName", ObjBOL.FirstName);
            param[4] = new SqlParameter("@LastName", ObjBOL.LastName);
            param[5] = new SqlParameter("@Phone", ObjBOL.Phone);
            param[6] = new SqlParameter("@Email", ObjBOL.Email);
            param[7] = new SqlParameter("@ShipperMemberID", ObjBOL.ShipperMemberID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageShippers", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public string DeleteShipperMember(BOLManageShippers ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ShipperID", ObjBOL.ShipperID);
            param[2] = new SqlParameter("@ShipperMemberID", ObjBOL.ShipperMemberID);
            param[3] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageShippers", param);
            string msg = param[0].Value.ToString();
            return msg;
        }


        public DataSet GetShipper(BOLManageShippers ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ShipperID", ObjBOL.ShipperID);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            param[3] = new SqlParameter("@ShipperMemberID", ObjBOL.ShipperMemberID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageShippers", param);
            return ds;
        }
    }

    public class DALManageGillRegions : Connection
    {
        public string SaveGillRegion(BOLManageGillRegions ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@RegionId", ObjBOL.RegionId);
            param[2] = new SqlParameter("@Region", ObjBOL.Region);
            param[3] = new SqlParameter("@CompanyName", ObjBOL.CompanyName);
            param[4] = new SqlParameter("@StreetAddress", ObjBOL.StreetAddress);
            param[5] = new SqlParameter("@City", ObjBOL.City);
            param[6] = new SqlParameter("@State", ObjBOL.State);
            param[7] = new SqlParameter("@Country", ObjBOL.Country);
            param[8] = new SqlParameter("@ZipCode", ObjBOL.ZipCode);
            param[9] = new SqlParameter("@Phone1", ObjBOL.Phone1);
            param[10] = new SqlParameter("@Phone2", ObjBOL.Phone2);
            param[11] = new SqlParameter("@Fax", ObjBOL.Fax);
            param[12] = new SqlParameter("@Email", ObjBOL.Email);
            param[13] = new SqlParameter("@TollFax", ObjBOL.TollFax);
            param[14] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageGillRegion", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetGillRegion(BOLManageGillRegions ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@RegionId", ObjBOL.RegionId);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageGillRegion", param);
            return ds;
        }
    }

    public class DALManageGillTerr : Connection
    {
        public string SaveGillTerr(BOLManageGillTerr ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@TerritoryId", ObjBOL.TerritoryId);
            param[2] = new SqlParameter("@EmployeeId", ObjBOL.EmployeeId);
            param[3] = new SqlParameter("@TerritoryName", ObjBOL.TerritoryName);
            param[4] = new SqlParameter("@TerrAddID", ObjBOL.TerrAddID);
            param[5] = new SqlParameter("@StreetAddress", ObjBOL.StreetAddress);
            param[6] = new SqlParameter("@City", ObjBOL.City);
            param[7] = new SqlParameter("@State", ObjBOL.State);
            param[8] = new SqlParameter("@Country", ObjBOL.Country);
            param[9] = new SqlParameter("@ZipCode", ObjBOL.ZipCode);
            param[10] = new SqlParameter("@Phone1", ObjBOL.Phone1);
            param[11] = new SqlParameter("@Phone2", ObjBOL.Phone2);
            param[12] = new SqlParameter("@Fax", ObjBOL.Fax);
            param[13] = new SqlParameter("@Email", ObjBOL.Email);
            param[14] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[aero_ManageGillTerr]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetGillTerr(BOLManageGillTerr ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@TerritoryId", ObjBOL.TerritoryId);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[aero_ManageGillTerr]", param);
            return ds;
        }
    }


    public class DALManageCity : Connection
    {
        public string SaveCity(BOLManageCity ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CityID", ObjBOL.CityID);
            param[2] = new SqlParameter("@CityName", ObjBOL.CityName);
            param[3] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCity", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetCity(BOLManageCity ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CityID", ObjBOL.CityID);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageCity", param);
            return ds;
        }


        public string SaveTest(BOLManageCity ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ShipDate", ObjBOL.ShipDate);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_Test", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetTest(BOLManageCity ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ShipDate", ObjBOL.ShipDate);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_Test", param);
            return ds;
        }
    }


    public class DALManageState : Connection
    {
        public string SaveState(BOLManageState ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@State", ObjBOL.State);
            param[2] = new SqlParameter("@Sabb", ObjBOL.Sabb);
            param[3] = new SqlParameter("@operation", ObjBOL.operation);
            param[4] = new SqlParameter("@CountryID", ObjBOL.CountryID);
            param[5] = new SqlParameter("@StateID", ObjBOL.StateID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageState", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetState(BOLManageState ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            param[3] = new SqlParameter("@CountryID", ObjBOL.CountryID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageState", param);
            return ds;
        }
    }

    public class DALManageCountry : Connection
    {
        public string SaveCountry(BOLManageCountry ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CountryID", ObjBOL.CountryID);
            param[2] = new SqlParameter("@Country", ObjBOL.Country);
            param[3] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCountry", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetCountry(BOLManageCountry ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CountryID", ObjBOL.CountryID);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageCountry", param);
            return ds;
        }
    }

    public class DALManageCompetitor : Connection
    {
        public string SaveCompetitor(BOLManageCompetitor ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CompetitorID", ObjBOL.CompetitorID);
            param[2] = new SqlParameter("@CompetitorName", ObjBOL.CompetitorName);
            param[3] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCompetitor", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetCompetitor(BOLManageCompetitor ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CompetitorID", ObjBOL.CompetitorID);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageCompetitor", param);
            return ds;
        }
    }



    public class DALManageCusTitle : Connection
    {
        public string SaveCusTitle(BOLManageCusTitle ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ID", ObjBOL.ID);
            param[2] = new SqlParameter("@Title", ObjBOL.Title);
            param[3] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCustomerTitle", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetCusTitle(BOLManageCusTitle ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ID", ObjBOL.ID);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageCustomerTitle", param);
            return ds;
        }
    }

    public class DALEmpCode : Connection
    {
        public String GetNextEmployeeCode()
        {
            String EmployeeCode = Convert.ToString(SqlHelper1.ExecuteScalar(con, CommandType.Text, "Select dbo.GetEmployeeCode()"));
            return EmployeeCode;
        }
    }

    //Start CategoryPage DAL 
    //DAL Class for Save and Select Category Form Data
    public class DALfrmCategory : Connection
    {
        public String SaveCategory(BOLfrmCategory objBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CategoryID", objBOL.CategoryID);
            param[2] = new SqlParameter("@Category", objBOL.Category);
            param[3] = new SqlParameter("@CategoryDescription", objBOL.CategoryDescription);
            param[4] = new SqlParameter("@Operation", objBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCategory", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public DataSet GetCategory(BOLfrmCategory objBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CategoryID", objBOL.CategoryID);
            param[2] = new SqlParameter("@Category", objBOL.Category);
            param[3] = new SqlParameter("@CategoryDescription", objBOL.CategoryDescription);
            param[4] = new SqlParameter("@Operation", objBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageCategory", param);
            return ds;

        }
    }
    //End DAL



    public class DALEMPLOYEELISTING : Connection
    {
        public string SaveEmployeeDetail(BOLEmployeeListing ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@RepID", ObjBOL.RepID);
            param[2] = new SqlParameter("@BranchID", ObjBOL.BranchID);
            param[3] = new SqlParameter("@FirstName", ObjBOL.FirstName);
            param[4] = new SqlParameter("@LastName", ObjBOL.LastName);
            param[5] = new SqlParameter("@AbbreviationID", ObjBOL.AbbreviationID);
            param[6] = new SqlParameter("@Phone", ObjBOL.Phone);
            param[7] = new SqlParameter("@PhoneMail", ObjBOL.PhoneMail);
            param[8] = new SqlParameter("@Fax", ObjBOL.Fax);
            param[9] = new SqlParameter("@CellPhone", ObjBOL.CellPhone);
            param[10] = new SqlParameter("@Email", ObjBOL.Email);
            param[11] = new SqlParameter("@Status", ObjBOL.Status);
            param[12] = new SqlParameter("@HomeAddress", ObjBOL.HomeAddress);
            param[13] = new SqlParameter("@HomeCity", ObjBOL.HomeCity);
            param[14] = new SqlParameter("@HomeState", ObjBOL.HomeState);
            param[15] = new SqlParameter("@HomePostalCode", ObjBOL.HomePostalCode);
            param[16] = new SqlParameter("@Homephone", ObjBOL.HomePhone);
            param[17] = new SqlParameter("@HomeFax", ObjBOL.HomeFax);
            param[18] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageATEmployeeListing", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public DataSet GetEmployeeDetail(BOLEmployeeListing ObjBOL)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@RepID", ObjBOL.RepID);
            param[2] = new SqlParameter("@BranchID", ObjBOL.BranchID);
            param[3] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageATEmployeeListing", param);
            return ds;
        }

    }
    //END DAL

    //START REPS AND TROYS FORM DAL

    public class DALRepsAndTroy : Connection
    {
        public String SaveRepsDetail(BOLEmployeeListing ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[22];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@RepID", ObjBOL.RepID);
            param[2] = new SqlParameter("@BranchID", ObjBOL.BranchID);
            param[3] = new SqlParameter("@FirstName", ObjBOL.FirstName);
            param[4] = new SqlParameter("@LastName", ObjBOL.LastName);
            param[5] = new SqlParameter("@AbbreviationID", ObjBOL.AbbreviationID);
            param[6] = new SqlParameter("@Phone", ObjBOL.Phone);
            param[7] = new SqlParameter("@PhoneMail", ObjBOL.PhoneMail);
            param[8] = new SqlParameter("@Fax", ObjBOL.Fax);
            param[9] = new SqlParameter("@CellPhone", ObjBOL.CellPhone);
            param[10] = new SqlParameter("@Email", ObjBOL.Email);
            param[11] = new SqlParameter("@Status", ObjBOL.Status);
            param[12] = new SqlParameter("@HomeAddress", ObjBOL.HomeAddress);
            param[13] = new SqlParameter("@HomeCity", ObjBOL.HomeCity);
            param[14] = new SqlParameter("@HomeState", ObjBOL.HomeState);
            param[15] = new SqlParameter("@HomePostalCode", ObjBOL.HomePostalCode);
            param[16] = new SqlParameter("@Homephone", ObjBOL.HomePhone);
            param[17] = new SqlParameter("@HomeFax", ObjBOL.HomeFax);
            param[18] = new SqlParameter("@TSM", ObjBOL.TSM);
            param[19] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[20] = new SqlParameter("@HomeOffice", ObjBOL.HomeOffice);
            param[21] = new SqlParameter("@ProductLine", ObjBOL.ProductLine);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_RepsAndTroys", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public DataSet GetRepsDetail(BOLEmployeeListing ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@RepID", ObjBOL.RepID);
            param[2] = new SqlParameter("@BranchID", ObjBOL.BranchID);
            param[3] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_RepsAndTroys", param);
            return ds;
        }
    }
    //END DAL

    public class DALBrowseDetail : Connection
    {
        public string SaveBrowseDetail(BOLBrowseDetail ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@BrowseID", ObjBOL.BrowseID);
            param[2] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[3] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
            param[4] = new SqlParameter("@CurrentSessionID", ObjBOL.CurrentSessionID);
            param[5] = new SqlParameter("@BrowserType", ObjBOL.BrowserType);
            param[6] = new SqlParameter("@op", ObjBOL.op);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "SPManageBrowseDetails", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetBrowseDetail(BOLBrowseDetail ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@BrowseID", ObjBOL.BrowseID);
            param[2] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[3] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
            param[4] = new SqlParameter("@CurrentSessionID", ObjBOL.CurrentSessionID);
            param[5] = new SqlParameter("@BrowserType", ObjBOL.BrowserType);
            param[6] = new SqlParameter("@op", ObjBOL.op);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "SPManageBrowseDetails", param);
            return ds;
        }
    }

    public class DALManageUserGroup : Connection
    {
        public string SaveUserGroup(BOLManageUserGroup ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", ObjBOL.id);
            param[2] = new SqlParameter("@name", ObjBOL.name);
            param[3] = new SqlParameter("@description", ObjBOL.description);
            param[4] = new SqlParameter("@status", ObjBOL.status);
            param[5] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageUserGroup", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetUserGroup(BOLManageUserGroup ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", ObjBOL.id);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageUserGroup", param);
            return ds;
        }
    }

    //DALSTANDARDPARTS START
    public class DALStandardParts : Connection
    {
        public DataSet GetStandardParts(BOLStandardParts ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@operation", ObjBOL.operation);
            param[2] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[3] = new SqlParameter("@StandardPartid", ObjBOL.PartDescid);
            param[4] = new SqlParameter("@ItemID", ObjBOL.Itemid);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_StandardParts", param);
            return ds;
        }
        public String SaveStandardParts(BOLStandardParts ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@PartId", ObjBOL.PartId);
            param[3] = new SqlParameter("@ItemID", ObjBOL.Itemid);
            param[4] = new SqlParameter("@Qty", ObjBOL.Qty);
            param[5] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_StandardParts", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public string DeleteStandardParts(BOLStandardParts ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ID", ObjBOL.ID);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_StandardParts", param);
            string msg = "Successfully Deleted !";
            return msg;
        }

    }
    //DAL END
    //START DAL ASSIGN MENU TO GROUPS
    public class DALGroupName : Connection
    {
        public DataSet GetRightsToGroups(BOLGroupName ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", ObjBOL.id);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageUsers", param);
            return ds;
        }
        public String AssignRightsToGroups(BOLGroupName ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@menuid", ObjBOL.menuid);
            param[2] = new SqlParameter("@groupid", ObjBOL.groupid);
            param[3] = new SqlParameter("@status", ObjBOL.status);
            param[4] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageUsers", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }
    //End Assign Menu To Groups

    //Start Assign Groups To Users
    public class DALAddUsersToGroups : Connection
    {
        public DataSet GetAddUsersToGroups(BOLAddUsersToGroups ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", ObjBOL.id);
            param[2] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[3] = new SqlParameter("@operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_AddUsersToGroups", param);
            return ds;

        }
        public String SaveAddUsersToGroups(BOLAddUsersToGroups ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@userid", ObjBOL.userid);
            param[2] = new SqlParameter("@groupid", ObjBOL.groupid);
            param[3] = new SqlParameter("@status", ObjBOL.status);
            param[4] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_AddUsersToGroups", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }
    //End Assign Users To Groups
    public class DALOpenProposalReports : Connection
    {
        public DataSet GetOpenProposalReportDataSearch(BOLOpenProposalReports ObjBOLOpenProposalReport)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Operation", ObjBOLOpenProposalReport.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Get_OpenProposalDateWise", param);
            return ds;
        }

        public DataSet GetSalesReport(BOLOpenProposalReports ObjBOLOpenProposalReport)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Operation", ObjBOLOpenProposalReport.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Get_SalesRepGroupwithStates", param);
            return ds;
        }
    }

    public class DALINVPartsInfo : Connection
    {
        public DataSet GetINVParts(BOLINVPartsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@operation", ObjBOL.operation);
            param[2] = new SqlParameter("@Productid", ObjBOL.product);
            param[3] = new SqlParameter("@projectid", ObjBOL.projectid);
            param[4] = new SqlParameter("@PartId", ObjBOL.PartId);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "INV_PartsInformation", param);
            return ds;
        }
        public String SaveINVParts(BOLINVPartsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.operation);
            param[2] = new SqlParameter("@projectid", ObjBOL.projectid);
            param[3] = new SqlParameter("@PartId", ObjBOL.PartId);
            param[4] = new SqlParameter("@Qty", ObjBOL.Qty);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "INV_PartsInformation", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        //UpdateINVParts
        public String UpdateINVParts(BOLINVPartsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.operation);
            param[2] = new SqlParameter("@projectid", ObjBOL.projectid);
            param[3] = new SqlParameter("@PartId", ObjBOL.PartId);
            param[4] = new SqlParameter("@Qty", ObjBOL.Qty);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "INV_PartsInformation", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public string DeleteINVPartsInfo(BOLINVPartsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@PartId", ObjBOL.PartId);
            param[2] = new SqlParameter("@Operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "INV_PartsInformation", param);
            string msg = "Successfully Deleted !";
            return msg;
        }

        //GetJobs
        public DataSet GetJobs(BOLINVPartsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@JobID", ObjBOL.projectid);
            param[2] = new SqlParameter("@Operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Inv_StockTransactions_V1", param);
            return ds;
        }
        //ReleaseProject
        public String ReleaseProject(BOLINVPartsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.operation);
            param[2] = new SqlParameter("@JobID", ObjBOL.projectid);
            param[3] = new SqlParameter("@userid", ObjBOL.userid);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[Inv_ProjectReleaseAndRollback_V1]", param);
            //SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Inv_StockTransactoions", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        //StockAdjustment
        public String StockAdjustment(BOLINVPartsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.operation);
            param[2] = new SqlParameter("@PartIdS", ObjBOL.PartId);
            param[3] = new SqlParameter("@Qty", ObjBOL.Qty);
            param[4] = new SqlParameter("@adjustmentreasonid", ObjBOL.adjustmentreasonid);
            param[5] = new SqlParameter("@transactsummary", ObjBOL.transactsummary);
            param[6] = new SqlParameter("@userid", ObjBOL.userid);
            param[7] = new SqlParameter("@WarehouseId", ObjBOL.WarehouseId);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Inv_StockTransactions_V1", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public DataSet GetStockAdjustment(BOLINVPartsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@PartIdS", ObjBOL.PartId);
            param[2] = new SqlParameter("@Operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Inv_StockTransactions_V1", param);
            return ds;
        }
        //GetPartsCount
        public DataSet GetPartsCount(BOLINVPartsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Productid", ObjBOL.Productid);
            param[2] = new SqlParameter("@Operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "INV_PartsInformation", param);
            return ds;
        }
        //CheckWeeklyCount
        public DataSet CheckWeeklyCount(BOLINVPartsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@shipdate", ObjBOL.shipdate);
            param[2] = new SqlParameter("@Operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_GetWeeklyCount", param);
            return ds;
        }
    }
    //Parts Maintainance
    public class DALINVParts : Connection
    {
        public DataSet GetPartsInfo(BOLPartMaintainanace ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PartInfo", ObjBOL.PartInfo);
            param[3] = new SqlParameter("@partid", ObjBOL.Partid);
            param[4] = new SqlParameter("@revisionnum", ObjBOL.RevisionNo);
            param[5] = new SqlParameter("@LoginUserID", ObjBOL.LoginUserId);
            param[6] = new SqlParameter("@ProductCode", ObjBOL.ProductCode);
            param[7] = new SqlParameter("@CategoryID", ObjBOL.CategoryID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "INV_PartsMaintainance", param);
            return ds;
        }
        public String SaveINVPartsDetail(BOLPartMaintainanace ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[30];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@PartNumber", ObjBOL.PartNumber);
            param[2] = new SqlParameter("@PartDes", ObjBOL.PartDes);
            param[3] = new SqlParameter("@SourceId", ObjBOL.SourceId);
            param[4] = new SqlParameter("@DepartmentId", ObjBOL.DepartmentId);
            param[5] = new SqlParameter("@Typeid", ObjBOL.Typeid);
            param[6] = new SqlParameter("@stockinhand", ObjBOL.stockinhand);
            param[7] = new SqlParameter("@min", ObjBOL.min);
            param[8] = new SqlParameter("@max", ObjBOL.max);
            param[9] = new SqlParameter("@reorderpoint", ObjBOL.reorderpoint);
            param[10] = new SqlParameter("@reorderqty", ObjBOL.reorderqty);
            param[11] = new SqlParameter("@leadtime", ObjBOL.leadtime);
            param[12] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[13] = new SqlParameter("@partid", ObjBOL.Partid);
            param[14] = new SqlParameter("@revisionnum", ObjBOL.RevisionNo);
            param[15] = new SqlParameter("@PartStatus", ObjBOL.PartStatus);
            param[16] = new SqlParameter("@UMId", ObjBOL.UMId);
            param[17] = new SqlParameter("@partimage", ObjBOL.PathImage);
            param[18] = new SqlParameter("@shopdrawing", ObjBOL.PathShopDrawing);
            param[19] = new SqlParameter("@StockItem", ObjBOL.StockItem);
            param[20] = new SqlParameter("@ForecastItem", ObjBOL.ForecastItem);
            param[21] = new SqlParameter("@LineStopper", ObjBOL.LineStopper);
            param[22] = new SqlParameter("@customerpartnumber", ObjBOL.CustomerPartNumber);
            param[23] = new SqlParameter("@productcode", ObjBOL.ProductCode);
            param[24] = new SqlParameter("@ProductId", ObjBOL.ProductId);
            param[25] = new SqlParameter("@Size", ObjBOL.Size);
            param[26] = new SqlParameter("@Direction", ObjBOL.Direction);
            param[27] = new SqlParameter("@OptionID", ObjBOL.OptionID);
            param[28] = new SqlParameter("@CategoryID", ObjBOL.CategoryID);
            param[29] = new SqlParameter("@LineStopperPriority", ObjBOL.LineStopperPriority);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "INV_PartsMaintainance", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public String DeleteINVParts(BOLPartMaintainanace ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@partid", ObjBOL.Partid);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "INV_PartsMaintainance", param);
            string Msg = "Successfully Deleted !";
            return Msg;
        }
        public DataSet GetINVPartsDetails(BOLPartMaintainanace ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@PartInfo", ObjBOL.PartInfo);
            param[2] = new SqlParameter("@LoginUserID", ObjBOL.LoginUserId);
            param[3] = new SqlParameter("@productcode", ObjBOL.ProductCode);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "INV_PartsDetails", param);
            return ds;
        }
    }

    public class DALQuotes : Connection
    {
        public DataSet GetQuotesInfo(BOLManageQuotes ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PQuoteNumber", ObjBOL.PQuoteNo);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageQuotesInfo", param);
            return ds;
        }
        public String SaveQuoteInfoData(BOLManageQuotes ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PQuoteNumber", ObjBOL.PQuoteNo);
            param[3] = new SqlParameter("@RevisionFormat", ObjBOL.RevisionFormat);
            param[4] = new SqlParameter("@RevisionNo", ObjBOL.RevisionNo);
            param[5] = new SqlParameter("@QuoteReqRec", ObjBOL.QuoteReqDate);
            param[6] = new SqlParameter("@QuoteReqAck", ObjBOL.QuoteAckDate);
            param[7] = new SqlParameter("@QuoteSent", ObjBOL.QuoteSent);
            param[8] = new SqlParameter("@Amount", ObjBOL.EqAmount);
            param[9] = new SqlParameter("@QuoteNo", ObjBOL.QuoteNo);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageQuotesInfo", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public string DeleteQuote(BOLManageQuotes ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@QuoteNo", ObjBOL.QuoteNo);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageQuotesInfo", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALForecasting : Connection
    {
        public DataSet GetData(BOLManageForecasting ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageForecasting", param);
            return ds;
        }

    }

    public class DALCustCareTickets : Connection
    {
        public DataSet GetControls(BOLCustCareTickets ObjBoL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBoL.Operation);
            param[2] = new SqlParameter("@TJobID", ObjBoL.TJobID);
            param[3] = new SqlParameter("@TicketNo", ObjBoL.TicketNo);
            param[4] = new SqlParameter("@TicketID", ObjBoL.TicketID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageCustCareTickets", param);
            return ds;
        }

        //Ticket Generation
        public string GetCustCareTicketNo(BOLCustCareTickets ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@TJobID", ObjBOL.TJobID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCustCareTickets", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }

        //Save Operation
        public string SaveCustCareTicketDetail(BOLCustCareTickets ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[36];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@TJobID", ObjBOL.TJobID);
            param[3] = new SqlParameter("@TicketNo", ObjBOL.TicketNo);
            param[4] = new SqlParameter("@CategoryID", ObjBOL.Category);
            param[5] = new SqlParameter("@CategoryOther", ObjBOL.CategoryOther);
            param[6] = new SqlParameter("@Task", ObjBOL.Task);
            param[7] = new SqlParameter("@IssueCategoryID", ObjBOL.IssueCategory);
            param[8] = new SqlParameter("@IssueCategoryOther", ObjBOL.IssueCategoryOther);
            param[9] = new SqlParameter("@OpenDate", ObjBOL.OpenDate);
            param[10] = new SqlParameter("@CloseDate", ObjBOL.IssueClosedDate);
            param[11] = new SqlParameter("@SubAssemblyID", ObjBOL.SubAssemblyID);
            param[12] = new SqlParameter("@SubAssemblyOther", ObjBOL.SubAssemblyOther);
            param[13] = new SqlParameter("@ReportedBy", ObjBOL.IssueReportedBy);
            param[14] = new SqlParameter("@Solution", ObjBOL.Solution);
            param[15] = new SqlParameter("@StatusID", ObjBOL.Status);
            param[16] = new SqlParameter("@AssignedTo", ObjBOL.AssignedTo);
            param[17] = new SqlParameter("@ServicePO", ObjBOL.ServicePO);
            param[18] = new SqlParameter("@TotalCost", ObjBOL.TotalCost);
            param[19] = new SqlParameter("@TicketID", ObjBOL.TicketID);
            param[20] = new SqlParameter("@summarydate", ObjBOL.SummaryDate);
            param[21] = new SqlParameter("@summary", ObjBOL.Summary);
            //param[22] = new SqlParameter("@CCTTicketSummaryDetail", ObjBOL.CCTTicketSummaryDetail);
            param[23] = new SqlParameter("@FollowUpDate", ObjBOL.FollowUpDate);
            param[24] = new SqlParameter("@InvoiceDate", ObjBOL.InvoiceDate);
            param[25] = new SqlParameter("@InvoiceNo", ObjBOL.InvoiceNo);
            param[26] = new SqlParameter("@PointOfContactOnSite", ObjBOL.PCS);
            param[27] = new SqlParameter("@Technician_1", ObjBOL.Technician_1);
            param[28] = new SqlParameter("@Technician_2", ObjBOL.Technician_2);
            param[29] = new SqlParameter("@OtherContacts", ObjBOL.OtherContacts);
            param[30] = new SqlParameter("@StartDateAndTime", ObjBOL.SDT);
            param[31] = new SqlParameter("@WorkingWindow", ObjBOL.WorkingWindow);
            param[32] = new SqlParameter("@FileAddress", ObjBOL.FileAddress);
            param[33] = new SqlParameter("@QuoteNo", ObjBOL.QuoteNo);
            param[34] = new SqlParameter("@QuoteAmt", ObjBOL.QuoteAmt);
            param[35] = new SqlParameter("@PORecDate", ObjBOL.PORecDate);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCustCareTickets", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }

        public string SaveCustCareTicketSummary(BOLCustCareTickets ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@TicketID", ObjBOL.TicketID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[3] = new SqlParameter("@summary", ObjBOL.Summary);
            param[4] = new SqlParameter("@summarydate", ObjBOL.SummaryDate);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCustCareTickets", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        public string DeleteTicketRecord(BOLCustCareTickets ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@TicketID", ObjBOL.TicketID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCustCareTickets", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALManageModel : Connection
    {
        public String SaveModel(BOLManageModel ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ModelID", ObjBOL.ModelID);
            param[2] = new SqlParameter("@ModelName", ObjBOL.ModelName);
            param[3] = new SqlParameter("@ModelDescription", ObjBOL.ModelDescription);
            param[4] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageModels", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public DataSet GetModel(BOLManageModel ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ModelID", ObjBOL.ModelID);
            param[2] = new SqlParameter("@ModelName", ObjBOL.ModelName);
            param[3] = new SqlParameter("@ModelDescription", ObjBOL.ModelDescription);
            param[4] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageModels", param);
            return ds;
        }
    }
    public class DALManageConveyor : Connection
    {
        public String SaveConveyor(BOLManageConveyor ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ConveyorTypeID", ObjBOL.ConveyorTypeID);
            param[2] = new SqlParameter("@ConveyorType", ObjBOL.ConveyorType);
            param[3] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageConveyor", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public DataSet GetConveyor(BOLManageConveyor ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ConveyorTypeID", ObjBOL.ConveyorTypeID);
            param[2] = new SqlParameter("@ConveyorType", ObjBOL.ConveyorType);
            param[3] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageConveyor", param);
            return ds;
        }
    }

    public class DALRequisition : Connection
    {
        public DataSet GetBindControls(BOLRequisition ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Reqid", ObjBOL.Reqid);
            param[3] = new SqlParameter("@PreparedBy", ObjBOL.PreparedBy);
            param[4] = new SqlParameter("@Productid", ObjBOL.Productid);
            param[5] = new SqlParameter("@LoginUserId", ObjBOL.LoginUserId);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManageRequisition]", param);
            return ds;
        }
        public DataSet GetPartDetails(BOLRequisition ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@partid", ObjBOL.partid);
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ReqDetailId", ObjBOL.ReqDetailID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManageRequisition]", param);
            return ds;
        }
        public DataSet GetTransitionData(BOLRequisition ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@partid", ObjBOL.partid);
            //@Operation
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_Requisition_PopupTransit]", param);
            return ds;
        }
        public DataSet GetInShopData(BOLRequisition ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@partid", ObjBOL.partid);
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_Requisition_PopupInShop]", param);
            return ds;
        }
        public string GetRequisitionNumber(BOLRequisition ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@LoginUserId", ObjBOL.LoginUserId);
            param[3] = new SqlParameter("@Reqid", ObjBOL.Reqid);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManageRequisition]", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        //CheckApprovedStatus
        public string CheckApprovedStatus(BOLRequisition ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Reqid", ObjBOL.Reqid);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManageRequisition]", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        public string SaveRequisition(BOLRequisition ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ReqNo", ObjBOL.ReqNo);
            param[3] = new SqlParameter("@ReqForId", ObjBOL.ReqForId);
            param[4] = new SqlParameter("@PreparedBy", ObjBOL.PreparedBy);
            param[5] = new SqlParameter("@AppBy", ObjBOL.AppBy);
            param[6] = new SqlParameter("@TentativeShipDate", ObjBOL.TentativeShipDate);
            param[7] = new SqlParameter("@ActualShipDate", ObjBOL.ActualShipDate);
            param[8] = new SqlParameter("@ReqStatus", ObjBOL.ReqStatus);
            param[9] = new SqlParameter("@Reqid", ObjBOL.Reqid);
            param[10] = new SqlParameter("@LoginUserId", ObjBOL.LoginUserId);
            param[11] = new SqlParameter("@Partid", ObjBOL.PartId);
            param[12] = new SqlParameter("@OrderType", ObjBOL.OrderType);
            param[13] = new SqlParameter("@ShipBy", ObjBOL.ShipBy);
            param[14] = new SqlParameter("@Requestor", ObjBOL.Requestor);
            param[15] = new SqlParameter("@PartQty", ObjBOL.PartQty);
            param[16] = new SqlParameter("@Priority", ObjBOL.Priority);
            param[17] = new SqlParameter("@Remarks", ObjBOL.Remarks);
            param[18] = new SqlParameter("@ReqDetailId", ObjBOL.ReqDetailID);
            param[19] = new SqlParameter("@VendorID", ObjBOL.VendorID);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManageRequisition]", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        public string DeleteRequisition(BOLRequisition ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ReqDetailID", ObjBOL.ReqDetailID);
            param[3] = new SqlParameter("@LoginUserId", ObjBOL.LoginUserId);
            param[4] = new SqlParameter("@Reqid", ObjBOL.Reqid);
            param[5] = new SqlParameter("@Partid", ObjBOL.PartId);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManageRequisition]", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        public string UpdateRequisitionIsSubmitted(BOLRequisition ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Reqid", ObjBOL.Reqid);
            param[3] = new SqlParameter("@LoginUserId", ObjBOL.LoginUserId);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManageRequisition]", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        public DataSet GetRequisitionPartno(BOLRequisition ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Productid", ObjBOL.Productid);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManageRequisition]", param);
            return ds;
        }
        //SavePopUpParts
        public string SavePopUpParts(BOLRequisition ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@dtPopUpParts", ObjBOL.dtPopUpParts);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManageRequisition]", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
    }

    public class DALManageBranchInformation : Connection
    {
        public string SaveBranchInformation(BOLManageBranchInformation ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[22];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@BranchID", ObjBOL.BranchID);
            param[2] = new SqlParameter("@BranchLocation", ObjBOL.BranchLocation);
            param[3] = new SqlParameter("@BranchName", ObjBOL.BranchName);
            param[4] = new SqlParameter("@RegionID", ObjBOL.RegionID);
            param[5] = new SqlParameter("@CompanyName", ObjBOL.CompanyName);
            param[6] = new SqlParameter("@StreetAddress", ObjBOL.StreetAddress);
            param[7] = new SqlParameter("@CityID", ObjBOL.City);
            param[8] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[9] = new SqlParameter("@CountryID", ObjBOL.CountryID);
            param[10] = new SqlParameter("@ZipCode", ObjBOL.ZipCode);
            param[11] = new SqlParameter("@Telephone", ObjBOL.Telephone);
            param[12] = new SqlParameter("@FaxNumber", ObjBOL.FaxNumber);
            param[13] = new SqlParameter("@TollFree", ObjBOL.TollFree);
            param[14] = new SqlParameter("@TollFax", ObjBOL.TollFax);
            param[16] = new SqlParameter("@ISSID ", ObjBOL.InsideSalesSupportID);
            param[17] = new SqlParameter("@HobartGroup", ObjBOL.HobartGroup);
            param[18] = new SqlParameter("@SteroGroup", ObjBOL.SteroGroup);
            param[19] = new SqlParameter("Operation", ObjBOL.Operation);
            param[20] = new SqlParameter("@RepGroupID", ObjBOL.RepGroupID);
            param[21] = new SqlParameter("@StatesCovered", ObjBOL.StatesCovered);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageBranchInformation", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetBranchInformation(BOLManageBranchInformation ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@BranchID", ObjBOL.BranchID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[3] = new SqlParameter("@RepGroupID", ObjBOL.RepGroupID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageBranchInformation", param);
            return ds;
        }
        public DataSet GetBranchState(BOLManageBranchInformation ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CountryID", ObjBOL.CountryID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageBranchInformation", param);
            return ds;
        }
    }

    public class DALManageShopEmployees : Connection
    {
        public string SaveShopEmployees(BOLManageShopEmployees ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[32];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", ObjBOL.id);
            param[2] = new SqlParameter("@FirstName", ObjBOL.FirstName);
            param[3] = new SqlParameter("@LastName", ObjBOL.LastName);
            param[4] = new SqlParameter("@Address", ObjBOL.Address);
            param[5] = new SqlParameter("@DateHired", ObjBOL.DateHired);
            param[6] = new SqlParameter("@Position", ObjBOL.Position);
            param[7] = new SqlParameter("@Status", ObjBOL.Status);
            param[8] = new SqlParameter("@Notes", ObjBOL.Notes);
            param[9] = new SqlParameter("@ImagePath", ObjBOL.ImagePath);
            param[10] = new SqlParameter("@Laser", ObjBOL.Laser);
            param[11] = new SqlParameter("@LaserType", ObjBOL.LaserType);
            param[12] = new SqlParameter("@BrakePress", ObjBOL.BrakePress);
            param[13] = new SqlParameter("@BrakePressType", ObjBOL.BrakePressType);
            param[14] = new SqlParameter("@Welding", ObjBOL.Welding);
            param[15] = new SqlParameter("@WeldingType", ObjBOL.WeldingType);
            param[16] = new SqlParameter("@Polishing", ObjBOL.Polishing);
            param[17] = new SqlParameter("@PolishingType", ObjBOL.PolishingType);
            param[18] = new SqlParameter("@MachineShop", ObjBOL.MachineShop);
            param[19] = new SqlParameter("@MachineShopType", ObjBOL.MachineShopType);
            param[20] = new SqlParameter("@Elecrical", ObjBOL.Elecrical);
            param[21] = new SqlParameter("@ElecricalType", ObjBOL.ElecricalType);
            param[22] = new SqlParameter("@Shipping", ObjBOL.Shipping);
            param[23] = new SqlParameter("@ShippingType", ObjBOL.ShippingType);
            param[24] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[25] = new SqlParameter("@Countryid", ObjBOL.Countryid);
            param[26] = new SqlParameter("@Stateid", ObjBOL.Stateid);
            param[27] = new SqlParameter("@City", ObjBOL.City);
            param[28] = new SqlParameter("@PostalCode", ObjBOL.PostalCode);
            param[29] = new SqlParameter("@Phone", ObjBOL.Phone);
            param[30] = new SqlParameter("@EmployeeCurrentStatus", ObjBOL.EmployeeCurrentStatus);
            param[31] = new SqlParameter("@ShopEmployeeTraining", ObjBOL.ShopEmployeeTraining);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageShopEmployees", param);
            string msg = param[0].Value.ToString();
            return msg;

        }

        public string UpdateShopEmployees(BOLManageShopEmployees ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[31];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ShopEmployeeTrainingid", ObjBOL.ShopEmployeeTrainingid);
            param[2] = new SqlParameter("@FirstName", ObjBOL.FirstName);
            param[3] = new SqlParameter("@LastName", ObjBOL.LastName);
            param[4] = new SqlParameter("@Address", ObjBOL.Address);
            param[5] = new SqlParameter("@DateHired", ObjBOL.DateHired);
            param[6] = new SqlParameter("@Position", ObjBOL.Position);
            param[7] = new SqlParameter("@Status", ObjBOL.Status);
            param[8] = new SqlParameter("@Notes", ObjBOL.Notes);
            param[9] = new SqlParameter("@ImagePath", ObjBOL.ImagePath);
            param[10] = new SqlParameter("@Laser", ObjBOL.Laser);
            param[11] = new SqlParameter("@LaserType", ObjBOL.LaserType);
            param[12] = new SqlParameter("@BrakePress", ObjBOL.BrakePress);
            param[13] = new SqlParameter("@BrakePressType", ObjBOL.BrakePressType);
            param[14] = new SqlParameter("@Welding", ObjBOL.Welding);
            param[15] = new SqlParameter("@WeldingType", ObjBOL.WeldingType);
            param[16] = new SqlParameter("@Polishing", ObjBOL.Polishing);
            param[17] = new SqlParameter("@PolishingType", ObjBOL.PolishingType);
            param[18] = new SqlParameter("@MachineShop", ObjBOL.MachineShop);
            param[19] = new SqlParameter("@MachineShopType", ObjBOL.MachineShopType);
            param[20] = new SqlParameter("@Elecrical", ObjBOL.Elecrical);
            param[21] = new SqlParameter("@ElecricalType", ObjBOL.ElecricalType);
            param[22] = new SqlParameter("@Shipping", ObjBOL.Shipping);
            param[23] = new SqlParameter("@ShippingType", ObjBOL.ShippingType);
            param[24] = new SqlParameter("Operation", ObjBOL.Operation);
            param[25] = new SqlParameter("@Countryid", ObjBOL.Countryid);
            param[26] = new SqlParameter("@Stateid", ObjBOL.Stateid);
            param[27] = new SqlParameter("@City", ObjBOL.City);
            param[28] = new SqlParameter("@PostalCode", ObjBOL.PostalCode);
            param[29] = new SqlParameter("@Phone", ObjBOL.Phone);
            param[30] = new SqlParameter("@EmployeeCurrentStatus", ObjBOL.EmployeeCurrentStatus);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageShopEmployees", param);
            string msg = param[0].Value.ToString();
            return msg;

        }

        public string AddShopEmployeesTraining(BOLManageShopEmployees ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ShopEmployeeTrainingid", ObjBOL.ShopEmployeeTrainingid);
            param[2] = new SqlParameter("@Description", ObjBOL.Description);
            param[3] = new SqlParameter("@Categoryid", ObjBOL.Categoryid);
            param[4] = new SqlParameter("@Trainer", ObjBOL.Trainer);
            param[5] = new SqlParameter("@TrainingDate", ObjBOL.TrainingDate);
            param[6] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[7] = new SqlParameter("@Employeeid", ObjBOL.Employeeid);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageShopEmployees", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetEmployeeInformation(BOLManageShopEmployees ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", ObjBOL.id);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[3] = new SqlParameter("@Employeeid", ObjBOL.Employeeid);
            param[4] = new SqlParameter("@Countryid", ObjBOL.Countryid);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageShopEmployees", param);
            return ds;
        }

    }
    public class DALIssueCategory : Connection
    {
        public String SaveIssueCategory(BOLIssueCategory objBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", objBOL.id);
            param[2] = new SqlParameter("@name", objBOL.name);
            param[3] = new SqlParameter("@status", objBOL.status);
            param[4] = new SqlParameter("@Operation", objBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageIssueCategory", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public DataSet GetIssueCategory(BOLIssueCategory objBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", objBOL.id);
            param[2] = new SqlParameter("@name", objBOL.name);
            param[3] = new SqlParameter("@status", objBOL.status);
            param[4] = new SqlParameter("@Operation", objBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageIssueCategory", param);
            return ds;

        }
    }
    public class DALCCT_SubAssembly : Connection
    {
        public String SaveCCT_SubAssembly(BOLCCT_SubAssembly objBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", objBOL.id);
            param[2] = new SqlParameter("@name", objBOL.name);
            param[3] = new SqlParameter("@status", objBOL.status);
            param[4] = new SqlParameter("@Operation", objBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCCT_SubAssebmbly", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public DataSet GetCCT_SubAssembly(BOLCCT_SubAssembly objBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", objBOL.id);
            param[2] = new SqlParameter("@name", objBOL.name);
            param[3] = new SqlParameter("@status", objBOL.status);
            param[4] = new SqlParameter("@Operation", objBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageCCT_SubAssebmbly", param);
            return ds;
        }
    }
    public class DALCCT_Category : Connection
    {
        public String SaveCCT_Category(BOLCCT_Category objBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", objBOL.id);
            param[2] = new SqlParameter("@name", objBOL.name);
            param[3] = new SqlParameter("@status", objBOL.status);
            param[4] = new SqlParameter("@Operation", objBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCCT_Category", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public DataSet GetCCT_Category(BOLCCT_Category objBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", objBOL.id);
            param[2] = new SqlParameter("@name", objBOL.name);
            param[3] = new SqlParameter("@status", objBOL.status);
            param[4] = new SqlParameter("@Operation", objBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageCCT_Category", param);
            return ds;
        }
    }
    public class DALCCT_IssueReportedBy : Connection
    {
        public String SaveCCT_IssueReportedBy(BOLCCT_IssueReportedBy objBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", objBOL.id);
            param[2] = new SqlParameter("@name", objBOL.name);
            param[3] = new SqlParameter("@status", objBOL.status);
            param[4] = new SqlParameter("@Operation", objBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCCT_IssueReportedBy", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public DataSet GetCCT_IssueReportedBy(BOLCCT_IssueReportedBy objBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", objBOL.id);
            param[2] = new SqlParameter("@name", objBOL.name);
            param[3] = new SqlParameter("@status", objBOL.status);
            param[4] = new SqlParameter("@Operation", objBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageCCT_IssueReportedBy", param);
            return ds;
        }
    }
    public class DALCalculateEngHours : Connection
    {
        public DataSet BindControls(BOLEngHoursCalculate ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ProposalID", ObjBOL.ProposalID);
            param[3] = new SqlParameter("@Timesheetid", ObjBOL.TimeSheetid);
            param[4] = new SqlParameter("@DepartmentID", ObjBOL.DepartmentID);
            param[5] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_CalculateEngHours]", param);
            return ds;
        }
        public string SaveEngTime(BOLEngHoursCalculate ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 150);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ProposalID", ObjBOL.ProposalID);
            param[3] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[4] = new SqlParameter("@TaskDate", ObjBOL.TaskDate);
            param[5] = new SqlParameter("@TaskNature", ObjBOL.TaskNature);
            param[6] = new SqlParameter("@TaskCategory", ObjBOL.TaskCategory);
            param[7] = new SqlParameter("@StartTime", ObjBOL.StartTime);
            param[8] = new SqlParameter("@EndTime", ObjBOL.EndTime);
            param[9] = new SqlParameter("@TotalTime", ObjBOL.TotalTime);
            param[10] = new SqlParameter("@DepartmentID", ObjBOL.DepartmentID);
            param[11] = new SqlParameter("@Timesheetid", ObjBOL.TimeSheetid);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_CalculateEngHours]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }
    public class DALContainer : Connection
    {
        public DataSet GetBindControl(BOLContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Reqid", ObjBOL.Reqid);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Inv_ManageContainerDetail]", param);
            return ds;
        }

        public string SaveContainerInfo(BOLContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@InvoiceNo", ObjBOL.InvoiceNo);
            param[2] = new SqlParameter("@ContainerNo", ObjBOL.ContainerNo);
            param[3] = new SqlParameter("@SealNo", ObjBOL.SealNo);
            param[4] = new SqlParameter("@SentDate", ObjBOL.SentDate);
            param[5] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[6] = new SqlParameter("@ContainerDetails", ObjBOL.ContainerDetails);
            param[7] = new SqlParameter("@LoginUserId", ObjBOL.LoginUserId);
            param[8] = new SqlParameter("@ArrivalinAerowerks", ObjBOL.ArrivalinAerowerks);
            param[9] = new SqlParameter("@ContainerSize", ObjBOL.ContainerSize);
            param[10] = new SqlParameter("@Attn", ObjBOL.Attn);
            param[11] = new SqlParameter("@Issuedby", ObjBOL.Issuedby);
            param[12] = new SqlParameter("@ReqForid", ObjBOL.ReqForid);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[Inv_ManageContainerNew]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALManageDesg : Connection
    {
        public string SaveDesg(BOLManageDesg ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Desgid", ObjBOL.id);
            param[2] = new SqlParameter("@DesgName", ObjBOL.DesgName);
            param[3] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[NACUF_ManageDesignation]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public DataSet GetDesg(BOLManageDesg ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Desgid", ObjBOL.id);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[NACUF_ManageDesignation]", param);
            return ds;


        }
    }
    public class DALManageUniv : Connection
    {
        public string SaveUniv(BOLManageUniv ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@UniId", ObjBOL.id);
            param[2] = new SqlParameter("@UniName", ObjBOL.UniName);
            param[3] = new SqlParameter("@operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[NACUF_ManageUniversity]", param);
            string msg = param[0].Value.ToString();
            return msg;

        }
        public DataSet GetUniv(BOLManageUniv ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@UniId", ObjBOL.id);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[NACUF_ManageUniversity]", param);
            return ds;
        }
    }


    public class DALCampuses : Connection
    {
        public String SaveCampusDetails(BOLCampusListing ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@UniId", ObjBOL.UniID);
            param[2] = new SqlParameter("@CampusId", ObjBOL.CampusID);
            param[3] = new SqlParameter("@CampusName", ObjBOL.CampusName);
            param[4] = new SqlParameter("@Country", ObjBOL.CountryID);
            param[5] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[6] = new SqlParameter("@City", ObjBOL.City);
            param[7] = new SqlParameter("@ZipCode", ObjBOL.PostalCode);
            param[8] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[NACUF_ManageCampus]", param);
            string msg = param[0].Value.ToString();
            return msg;

        }
        public DataSet GetCampusDetails(BOLCampusListing ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@UniId", ObjBOL.id);
            param[2] = new SqlParameter("@CampusId", ObjBOL.CampusID);
            param[3] = new SqlParameter("@CampusName", ObjBOL.CampusName);
            param[4] = new SqlParameter("@Country", ObjBOL.CountryID);
            param[5] = new SqlParameter("@StateID", ObjBOL.StateID);
            param[6] = new SqlParameter("@City", ObjBOL.City);
            param[7] = new SqlParameter("@ZipCode", ObjBOL.PostalCode);
            param[8] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[NACUF_ManageCampus]", param);
            return ds;
        }
    }

    public class DALPreventativeMaintenanceCallLogs : Connection
    {
        public DataSet Return_DataSet(BOLPreventativeMaintenanceCallLogs ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@WarrantyEndFromDate", ObjBOL.WarrantyEndFromDate);
            param[3] = new SqlParameter("@WarrantyEndToDate", ObjBOL.WarrantyEndToDate);
            param[4] = new SqlParameter("@DateCalled", ObjBOL.DateCalled);
            param[5] = new SqlParameter("@Contact", ObjBOL.Contact);
            param[6] = new SqlParameter("@CallDetails", ObjBOL.CallDetails);
            param[7] = new SqlParameter("@Notes", ObjBOL.Notes);
            param[8] = new SqlParameter("@PMResponse", ObjBOL.PMResponse);
            param[9] = new SqlParameter("@ID", ObjBOL.ID);
            param[10] = new SqlParameter("@ContactID", ObjBOL.ContactID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManagePreventativeMaintenanceCallLogs]", param);
            return ds;
        }

        public string Return_String(BOLPreventativeMaintenanceCallLogs ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@WarrantyEndFromDate", ObjBOL.WarrantyEndFromDate);
            param[3] = new SqlParameter("@WarrantyEndToDate", ObjBOL.WarrantyEndToDate);
            param[4] = new SqlParameter("@DateCalled", ObjBOL.DateCalled);
            param[5] = new SqlParameter("@Contact", ObjBOL.Contact);
            param[6] = new SqlParameter("@CallDetails", ObjBOL.CallDetails);
            param[7] = new SqlParameter("@Notes", ObjBOL.Notes);
            param[8] = new SqlParameter("@PMResponse", ObjBOL.PMResponse);
            param[9] = new SqlParameter("@ID", ObjBOL.ID);
            param[10] = new SqlParameter("@ContactID", ObjBOL.ContactID);
            param[11] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[11].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ManagePreventativeMaintenanceCallLogs]", param);
            string msg = param[11].Value.ToString();
            return msg;
        }
    }

    public class DALContacts : Connection
    {
        public String SaveContectDetails(BOLContactListing ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ContactId", ObjBOL.ContactId);
            param[2] = new SqlParameter("@UniId", ObjBOL.UniID);
            param[3] = new SqlParameter("@CampusId", ObjBOL.CampusID);
            param[4] = new SqlParameter("@FirstName", ObjBOL.FirstName);
            param[5] = new SqlParameter("@LastName", ObjBOL.LastName);
            param[6] = new SqlParameter("@DesgID", ObjBOL.DesgID);
            param[7] = new SqlParameter("@Phone", ObjBOL.Phone);
            param[8] = new SqlParameter("@Email", ObjBOL.Email);
            param[9] = new SqlParameter("@City", ObjBOL.City);
            param[10] = new SqlParameter("@Street", ObjBOL.StreetAddress);
            param[11] = new SqlParameter("@Zip", ObjBOL.ZipCode);
            param[12] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[NACUF_ManageContacts]", param);
            string msg = param[0].Value.ToString();
            return msg;

        }
        public DataSet GetContectDetails(BOLContactListing ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@UniId", ObjBOL.UniID);
            param[2] = new SqlParameter("@CampusId", ObjBOL.CampusID);
            param[3] = new SqlParameter("@ContactId", ObjBOL.ContactId);
            param[4] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[NACUF_ManageContacts]", param);
            return ds;
        }
    }

    //START DAL Rep Search
    public class DALRepSearch : Connection
    {
        public DataSet GetRepSearch(BOLRepSearch ObjBOLRepSearch)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOLRepSearch.Operation);
            param[2] = new SqlParameter("@country", ObjBOLRepSearch.country);
            param[3] = new SqlParameter("@SearchVar", ObjBOLRepSearch.SearchVar);
            param[4] = new SqlParameter("@PNumber", ObjBOLRepSearch.PNumber);


            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_GetProposal", param);
            return ds;
        }

        public DataSet GetCustomerSearch(BOLRepSearch ObjBOLRepSearch)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOLRepSearch.Operation);
            param[2] = new SqlParameter("@SearchVar", ObjBOLRepSearch.SearchVar);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_GetCutomers", param);
            return ds;
        }
        //GetProjects
        public DataSet GetProjects(BOLRepSearch ObjBOLRepSearch)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOLRepSearch.Operation);
            param[2] = new SqlParameter("@SearchVar", ObjBOLRepSearch.SearchVar);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_GetCutomers", param);
            return ds;
        }
    }
    public class DALGaylordQuote : Connection
    {
        public DataSet GetGaylordQuote(BOLGaylordQuote ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@GPNPartid", ObjBOL.GPNPartid);
            param[3] = new SqlParameter("@Gayquoteid", ObjBOL.Gayquoteid);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Gay_Quote", param);
            return ds;
        }
        public String GenerateQuote(BOLGaylordQuote ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Gay_Quote", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public String SaveGaylordQuote(BOLGaylordQuote ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Quoteno", ObjBOL.Quoteno);
            param[3] = new SqlParameter("@Quotedate", ObjBOL.Quotedate);
            param[4] = new SqlParameter("@Quoteby", ObjBOL.Quoteby);
            param[5] = new SqlParameter("@partid", ObjBOL.partid);
            param[6] = new SqlParameter("@partqty", ObjBOL.partqty);
            param[7] = new SqlParameter("@finalcost", ObjBOL.finalcost);
            param[8] = new SqlParameter("@Gayquoteid", ObjBOL.Gayquoteid);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Gay_Quote", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public String UpdateGaylordQuote(BOLGaylordQuote ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@partid", ObjBOL.partid);
            param[3] = new SqlParameter("@partqty", ObjBOL.partqty);
            param[4] = new SqlParameter("@GayquoteDetailid", ObjBOL.GayquoteDetailid);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Gay_Quote", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public String DeletePartInfo(BOLGaylordQuote ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@GayquoteDetailid", ObjBOL.GayquoteDetailid);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Gay_Quote", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALShipmentTracker : Connection
    {
        public DataSet GetShipmentDetails(BOLShipmentTracker ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Containerid", ObjBOL.Containerid);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageShipmentTracker", param);
            return ds;
        }



        public String SaveShipmentDetails(BOLShipmentTracker ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ShipFromID", ObjBOL.ShipFromID);
            param[3] = new SqlParameter("@ShipByID", ObjBOL.ShipByID);
            param[4] = new SqlParameter("@ContainerNo", ObjBOL.ContainerNo);
            param[5] = new SqlParameter("@ShipDate", ObjBOL.ShipDate);
            param[6] = new SqlParameter("@ETA", ObjBOL.ETA);
            param[7] = new SqlParameter("@RecDate", ObjBOL.RecDate);
            param[8] = new SqlParameter("@PackingList", ObjBOL.PackingList);
            param[9] = new SqlParameter("@RevisedETA", ObjBOL.RevisedETA);
            param[10] = new SqlParameter("@Comments", ObjBOL.Comments);
            param[11] = new SqlParameter("@Containerid", ObjBOL.Containerid);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageShipmentTracker", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public String SaveShipmentInfoDetails(BOLShipmentTracker ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ShipInfo", ObjBOL.ShipInfo);
            param[3] = new SqlParameter("@RevisedETA", ObjBOL.RevisedETA);
            param[4] = new SqlParameter("@Comments", ObjBOL.Comments);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageShipmentTracker", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public String UpdateShipmentInfoDetails(BOLShipmentTracker ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ShipInfo", ObjBOL.ShipInfo);
            param[3] = new SqlParameter("@RevisedETA", ObjBOL.RevisedETA);
            param[4] = new SqlParameter("@Comments", ObjBOL.Comments);
            param[5] = new SqlParameter("@ShipInfoDetailid", ObjBOL.ShipInfoDetailid);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageShipmentTracker", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public String DeleteShipmentInfoDetails(BOLShipmentTracker ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ShipInfoDetailid", ObjBOL.ShipInfoDetailid);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageShipmentTracker", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetShipmentDetailsReport(BOLShipmentTracker ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@SearchVar", ObjBOL.SearchVar);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_Get_ShipmentTracker", param);
            return ds;
        }
    }

    public class DALGetProjectInfo : Connection
    {
        public DataSet GetProjectInfo(BOLManageProjectsInfo ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@JobID", ObjBOL.JobID);
                param[3] = new SqlParameter("@id", ObjBOL.ID);
                param[4] = new SqlParameter("@ProjectName", ObjBOL.ProjectName);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjectInfo", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        public string GenrateJNumber(BOLManageProjectsInfo ObjBOL)
        {
            string jnumber = string.Empty;
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@operation", ObjBOL.Operation);
                SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageProjectInfo", param);
                jnumber = param[0].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return jnumber;
        }

        public string SaveProjectInfo(BOLManageProjectsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@PNumber", ObjBOL.ProjectNumber);
            param[3] = new SqlParameter("@ProjectName", ObjBOL.ProjectName);
            param[4] = new SqlParameter("@ProjectDate", ObjBOL.ProjectDate);
            param[5] = new SqlParameter("@ShipToArriveDate", ObjBOL.ShipToArriveDate);
            param[6] = new SqlParameter("@FabDateIssue", ObjBOL.FabDateIssue);
            param[7] = new SqlParameter("@NestDateIssue", ObjBOL.NestDateIssue);
            param[8] = new SqlParameter("@ProjectEng", ObjBOL.ProjectEng);
            param[9] = new SqlParameter("@ReviewedBy", ObjBOL.ReviewedBy);
            param[10] = new SqlParameter("@ModelID", ObjBOL.ModelID);
            param[11] = new SqlParameter("@ConveyorID", ObjBOL.ConveyorID);
            param[12] = new SqlParameter("@CurrencyID", ObjBOL.CurrencyID);
            param[13] = new SqlParameter("@EqPrice", ObjBOL.EqPrice);
            param[14] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageProjectInfo", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public DataSet GetProjects(BOLManageProjectsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@id", ObjBOL.ID);
            param[3] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageProjectInfo", param);
            return ds;
        }
    }
    public class DALManageHobartSalesbyTSM : Connection
    {
        public DataSet GetSalesTSM(BOLHobartSalesbyTSM ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Get_YTD_SalesbyTSM", param);
            return ds;
        }
    }

    public class DALStockIn : Connection
    {
        public DataSet GetBindControl(BOLContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Reqid", ObjBOL.Reqid);
            param[3] = new SqlParameter("@Containerid", ObjBOL.Containerid);
            param[4] = new SqlParameter("@ReqForid", ObjBOL.ReqForid);
            param[5] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[6] = new SqlParameter("@SourceID", ObjBOL.SourceID);
            param[7] = new SqlParameter("@PartId", ObjBOL.PartId);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Inv_ManageStockIn]", param);
            return ds;
        }

        public string StockIN(BOLContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Containerid", ObjBOL.Containerid);
            param[3] = new SqlParameter("@ContainerNo", ObjBOL.ContainerNo);
            param[4] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[5] = new SqlParameter("@ReceiveDate", ObjBOL.ReceivedDate);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[Inv_ManageStockIn]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALManageSerProjcts : Connection
    {
        public string GetServiceProjects(BOLSerProjects ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Service_Projects", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        public DataSet GetSerProjectsControls(BOLSerProjects ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@JNo", ObjBOL.JNo);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Service_Projects", param);
            return ds;
        }
        public string SaveSerProjects(BOLSerProjects ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@JNo", ObjBOL.JNo);
            param[3] = new SqlParameter("@PNo", ObjBOL.PNo);
            param[4] = new SqlParameter("@PORecDate", ObjBOL.PORecDate);
            param[5] = new SqlParameter("@POAmount", ObjBOL.POAmount);
            param[6] = new SqlParameter("@PONo", ObjBOL.PONo);
            param[7] = new SqlParameter("@RepairDate", ObjBOL.RepairDate);
            param[8] = new SqlParameter("@FollowupDate", ObjBOL.FollowupDate);
            param[9] = new SqlParameter("@AssignedTo", ObjBOL.AssignedTo);
            param[10] = new SqlParameter("@InvoiceDate", ObjBOL.InvoiceDate);
            param[11] = new SqlParameter("@InvoiceNo", ObjBOL.InvoiceNo);
            param[13] = new SqlParameter("@JobNo", ObjBOL.JobNo);
            param[14] = new SqlParameter("@Technician", ObjBOL.Technician);
            param[15] = new SqlParameter("@AssessmentDate", ObjBOL.AssessmentDate);
            param[16] = new SqlParameter("@QuoteSentDate", ObjBOL.QuoteSentDate);
            param[17] = new SqlParameter("@QuoteAmount", ObjBOL.QuoteAmount);
            param[18] = new SqlParameter("@SerProposal", ObjBOL.SerProposal);
            param[19] = new SqlParameter("@Status", ObjBOL.Status);
            param[20] = new SqlParameter("@DATE", ObjBOL.Date);
            param[21] = new SqlParameter("@SUMMARY", ObjBOL.SUMMARY);
            param[22] = new SqlParameter("@ActualAmount", ObjBOL.ActualAmount);
            param[23] = new SqlParameter("@ConveyorSpecID", ObjBOL.ConveyorSpecID);
            param[24] = new SqlParameter("@Comments", ObjBOL.Comments);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Service_Projects", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
    }

    public class DALManageSerProposals : Connection
    {
        public string GetServiceProposals(BOLSerProposals ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@RefJobID", ObjBOL.RefJobID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Service_Proposals", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        //GetSerProposalsControls
        public DataSet GetSerProposalsControls(BOLSerProposals ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PNo", ObjBOL.PNo);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Service_Proposals", param);
            return ds;
        }

        public string SaveSerProposals(BOLSerProposals ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[17];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PNo", ObjBOL.PNo);
            param[3] = new SqlParameter("@ConveyorSpecID", ObjBOL.ConveyorSpecID);
            param[4] = new SqlParameter("@Comments", ObjBOL.Comments);
            param[5] = new SqlParameter("@RefJobID", ObjBOL.RefJobID);
            param[6] = new SqlParameter("@Technician", ObjBOL.Technician);
            param[7] = new SqlParameter("@AssessmentDate", ObjBOL.AssessmentDate);
            param[8] = new SqlParameter("@QuoteSentDate", ObjBOL.QuoteSentDate);
            param[9] = new SqlParameter("@QuoteAmount", ObjBOL.QuoteAmount);
            param[10] = new SqlParameter("@SerProposal", ObjBOL.SerProposal);
            param[11] = new SqlParameter("@Status", ObjBOL.Status);
            param[12] = new SqlParameter("@DATE", ObjBOL.Date);
            param[13] = new SqlParameter("@SUMMARY", ObjBOL.SUMMARY);
            param[14] = new SqlParameter("@AssignedTo", ObjBOL.AssignedTo);
            param[15] = new SqlParameter("@Nature", ObjBOL.Nature);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Service_Proposals", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        public string DeleteSerProposals(BOLSerProposals ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@SerProposalDetailid", ObjBOL.SerProposalDetailid);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Service_Proposals", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        //UpdateSerProposalDetail
        public string UpdateSerProposalDetail(BOLSerProposals ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@SerProposalDetailid", ObjBOL.SerProposalDetailid);
            param[3] = new SqlParameter("@DATE", ObjBOL.Date);
            param[4] = new SqlParameter("@SUMMARY", ObjBOL.SUMMARY);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Service_Proposals", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }

        public DataSet GetSerProposalsSearch(BOLSerProposals ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@SearchVar", ObjBOL.SearchVar);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Service_Proposals", param);
            return ds;
        }
    }
    public class DALManageRepGroup : Connection
    {
        public string SaveRepGroup(BOLManageRepGroup ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@id", ObjBOL.ID);
            param[2] = new SqlParameter("@Name", ObjBOL.Name);
            //param[3] = new SqlParameter("@SortOrder", ObjBOL.SortOrder);
            param[4] = new SqlParameter("@IsActive", ObjBOL.IsActive);
            param[5] = new SqlParameter("@operation", ObjBOL.operation);
            param[6] = new SqlParameter("@productLineID", ObjBOL.ProductLineID);
            param[7] = new SqlParameter("@HobartGroup", ObjBOL.HobartGroup);
            param[8] = new SqlParameter("@SteroGroup", ObjBOL.SteroGroup);
            param[9] = new SqlParameter("@pmid", ObjBOL.pmid);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_RepGroup", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetRepGroup(BOLManageRepGroup ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@ID", ObjBOL.ID);
            param[2] = new SqlParameter("@operation", ObjBOL.operation);
            param[3] = new SqlParameter("@IsActive", ObjBOL.IsActive);
            param[4] = new SqlParameter("@productLineID", ObjBOL.ProductLineID);
            param[5] = new SqlParameter("@HobartGroup", ObjBOL.HobartGroup);
            param[6] = new SqlParameter("@SteroGroup", ObjBOL.SteroGroup);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_RepGroup", param);
            return ds;
        }
    }
    public class DALModel : Connection
    {
        public DataSet GetBindControls(BOLModel ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Id", ObjBOL.id);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[model_Main]", param);
            return ds;
        }
        public DataSet GetModelName(BOLModel ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Id", ObjBOL.id);
            //@Operation
            param[2] = new SqlParameter("@PNumber", ObjBOL.PNumber);
            param[3] = new SqlParameter("@ChildModelID", ObjBOL.ChildModelID);
            param[4] = new SqlParameter("@operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[model_Main]", param);
            return ds;
        }
        public string SaveModel(BOLModel ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Id", ObjBOL.id);
            param[3] = new SqlParameter("@PNumber", ObjBOL.PNumber);
            param[4] = new SqlParameter("@ChildModelID", ObjBOL.ChildModelID);
            param[5] = new SqlParameter("@SelecteDetails", ObjBOL.SelectDetails);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "model_Main", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

    }

    public class DALSchedule : Connection
    {
        public DataSet GetBindControls(BOLSchedule ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
            param[3] = new SqlParameter("@JobID", ObjBOL.JobID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Aero_AwSchedule]", param);
            return ds;
        }
        public DataSet GetSchedule(BOLSchedule ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@JobID ", ObjBOL.JobID);
            param[3] = new SqlParameter("@ServiceScheduleID", ObjBOL.ServiceScheduleID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Aero_AwSchedule", param);
            return ds;
        }
        public string SaveSchedule(BOLSchedule ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ID", ObjBOL.ID);
            param[3] = new SqlParameter("@CustomerID", ObjBOL.CustomerID);
            param[4] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[5] = new SqlParameter("@ReqShipDate", ObjBOL.ReqShipDate);
            param[6] = new SqlParameter("@NestingStatus", ObjBOL.NestingStatus);
            param[7] = new SqlParameter("@LaserStatus", ObjBOL.LaserStatus);
            param[8] = new SqlParameter("@FormingStatus", ObjBOL.FormingStatus);
            param[9] = new SqlParameter("@WeldingStatus", ObjBOL.WeldingStatus);
            param[10] = new SqlParameter("@PolishingStatus", ObjBOL.PolishingStatus);
            param[11] = new SqlParameter("@ShippingStatus", ObjBOL.ShippingStatus);
            param[12] = new SqlParameter("@Status", ObjBOL.Status);


            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Aero_AwSchedule", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

    }

    public class DALScheduleDetails : Connection
    {
        public DataSet GetScheduleDetails(BOLScheduleDetails ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[3] = new SqlParameter("@ServiceScheduleID", ObjBOL.ServiceScheduleID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Aero_AwSchedule", param);
            return ds;
        }
        public string SaveScheduleDetails(BOLScheduleDetails ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@ServiceScheduleID", ObjBOL.ServiceScheduleID);
            param[3] = new SqlParameter("@ID", ObjBOL.ID);
            param[4] = new SqlParameter("@PackNo", ObjBOL.PackNo);
            param[5] = new SqlParameter("@PartNumber", ObjBOL.PartNumber);
            param[6] = new SqlParameter("@PartDescription", ObjBOL.PartDescription);
            param[7] = new SqlParameter("@ReleaseDate", ObjBOL.ReleaseDate);
            param[8] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Aero_AwSchedule", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public String DeleteScheduleDetails(BOLScheduleDetails ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@ServiceScheduleID", ObjBOL.ServiceScheduleID);
            param[1] = new SqlParameter("@ID", ObjBOL.ID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Aero_AwSchedule", param);
            string Msg = "Successfully Deleted !";
            return Msg;
        }
    }

    public class DALServiceSchedule : Connection
    {
        public DataSet BindDropDowns(BOLServiceSchedule ObjBOL)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Id", ObjBOL.ID);
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ServiceSchedule", param);
            return ds;
        }

        public string GetPackInfo(BOLServiceSchedule ObjBOL)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@JobID", ObjBOL.JobID);
            // ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_CustCare_ManageTickets", param);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ServiceSchedule", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }

        public DataSet GetDataSet(BOLServiceSchedule ObjBOL)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@JobID", ObjBOL.JobID);
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ServiceSchedule", param);
            return ds;
        }

        public string SavePack(BOLServiceSchedule ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[22];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PackNo", ObjBOL.PackNo);
            param[3] = new SqlParameter("@ReleaseDate", ObjBOL.ReleaseDate);
            param[4] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[5] = new SqlParameter("@Id", ObjBOL.ID);
            //param[6] = new SqlParameter("@PackDetails", ObjBOL.PackDetail);
            param[7] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[8] = new SqlParameter("@ServiceScheduleID", ObjBOL.ServiceScheduleID);
            param[9] = new SqlParameter("@PartNumber", ObjBOL.PartNumber);
            param[10] = new SqlParameter("@PartDescription", ObjBOL.PartDescription);
            param[11] = new SqlParameter("@PartQty", ObjBOL.PartQty);
            param[12] = new SqlParameter("@ReqShipDate", ObjBOL.ReqShipDate);
            param[13] = new SqlParameter("@PartReqOnSite", ObjBOL.PartReqOnSite);
            param[14] = new SqlParameter("@ShipDate", ObjBOL.ShipDate);
            param[15] = new SqlParameter("@NestingStatus", ObjBOL.NestingStatus);
            param[16] = new SqlParameter("@LaserStatus", ObjBOL.LaserStatus);
            param[17] = new SqlParameter("@FormingStatus", ObjBOL.FormingStatus);
            param[18] = new SqlParameter("@WeldingStatus", ObjBOL.WeldingStatus);
            param[19] = new SqlParameter("@PolishingStatus", ObjBOL.PolishingStatus);
            param[20] = new SqlParameter("@FinalStatus", ObjBOL.FinalStatus);
            param[21] = new SqlParameter("@ShippingStatus", ObjBOL.ShippingStatus);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ServiceSchedule]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public string SavePackInfo(BOLServiceSchedule ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PackNo", ObjBOL.PackNo);
            param[3] = new SqlParameter("@ReleaseDate", ObjBOL.ReleaseDate);
            param[4] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[5] = new SqlParameter("@Id", ObjBOL.ID);
            param[6] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ServiceSchedule]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public string DeletePackNoDetail(BOLServiceSchedule ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[5] = new SqlParameter("@Id", ObjBOL.ID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ServiceSchedule]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public string SavePacktSummary(BOLServiceSchedule ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            //param[2] = new SqlParameter("@RepairID", ObjBOL.RepairID);
            //param[3] = new SqlParameter("@SummDate", ObjBOL.SummDate);
            //param[4] = new SqlParameter("@Summary", ObjBOL.Summary);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_CustCare_ManageTickets]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public string UpdatepacktSummary(BOLServiceSchedule ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            //param[2] = new SqlParameter("@RepairID", ObjBOL.RepairID);
            //param[3] = new SqlParameter("@id", ObjBOL.id);
            //param[4] = new SqlParameter("@SummDate", ObjBOL.SummDate);
            //param[5] = new SqlParameter("@Summary", ObjBOL.Summary);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_CustCare_ManageTickets]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }
    public class DALPurchaseOrder : Connection
    {
        public DataSet GetBindControl(BOLPurchaseOrder ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PurchaseOrderID", ObjBOL.PONumberID);
            param[3] = new SqlParameter("@ReqForId", ObjBOL.ReqForId);
            param[4] = new SqlParameter("@ReqId", ObjBOL.ReqId);
            param[5] = new SqlParameter("@SourceID", ObjBOL.SourceID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[INV_ManagePurchaseOrder]", param);
            return ds;
        }

        public string SavePurchaseOrderInfo(BOLPurchaseOrder ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PurchaseOrderNo", ObjBOL.PONumber);
            param[3] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[4] = new SqlParameter("@IssueDate", ObjBOL.IssueDate);
            param[5] = new SqlParameter("@SourceID", ObjBOL.SourceID);
            param[6] = new SqlParameter("@PurchaseOrderID", ObjBOL.PONumberID);
            param[7] = new SqlParameter("@PreparedBy", ObjBOL.PreparedBy);
            param[8] = new SqlParameter("@PurchaseOrderDetail", ObjBOL.PurchaseOrderDetails);

            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[INV_ManagePurchaseOrder]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public string UpdateStatus(BOLPurchaseOrder ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ReqId", ObjBOL.ReqId);
            param[3] = new SqlParameter("@ReqStatus", ObjBOL.ReqStatus);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[INV_ManagePurchaseOrder]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public string UpdatePurchaseOrderStatus(BOLPurchaseOrder ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PurchaseOrderID", ObjBOL.PONumberID);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[INV_ManagePurchaseOrder]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALPurchaseOrderManual : Connection
    {
        public DataSet GetBindControl(BOLPurchaseOrder ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PurchaseOrderID", ObjBOL.PONumberID);
            param[3] = new SqlParameter("@ReqForId", ObjBOL.ReqForId);
            param[4] = new SqlParameter("@ReqId", ObjBOL.ReqId);
            param[5] = new SqlParameter("@SourceID", ObjBOL.SourceID);
            param[6] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[7] = new SqlParameter("@PartId", ObjBOL.PartId);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManagePurchaseOrderManual_V1]", param);
            return ds;
        }

        public string SavePurchaseOrderInfo(BOLPurchaseOrder ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PurchaseOrderNo", ObjBOL.PONumber);
            param[3] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[4] = new SqlParameter("@IssueDate", ObjBOL.IssueDate);
            param[5] = new SqlParameter("@SourceID", ObjBOL.SourceID);
            param[6] = new SqlParameter("@PurchaseOrderID", ObjBOL.PONumberID);
            param[7] = new SqlParameter("@PreparedBy", ObjBOL.PreparedBy);
            param[8] = new SqlParameter("@ReqId", ObjBOL.ReqId);
            param[9] = new SqlParameter("@PartId", ObjBOL.PartId);
            param[10] = new SqlParameter("@Remarks", ObjBOL.Remarks);
            param[11] = new SqlParameter("@ReqForId", ObjBOL.ReqForId);
            param[12] = new SqlParameter("@Status", ObjBOL.Status);
            param[13] = new SqlParameter("@PORemarks", ObjBOL.PORemarks);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManagePurchaseOrderManual_V1]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public string SavePurchaseOrderInfoAndDetail(BOLPurchaseOrder ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[17];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PurchaseOrderNo", ObjBOL.PONumber);
            param[3] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[4] = new SqlParameter("@IssueDate", ObjBOL.IssueDate);
            param[5] = new SqlParameter("@SourceID", ObjBOL.SourceID);
            param[6] = new SqlParameter("@PurchaseOrderID", ObjBOL.PONumberID);
            param[7] = new SqlParameter("@PreparedBy", ObjBOL.PreparedBy);
            param[8] = new SqlParameter("@ReqId", ObjBOL.ReqId);
            param[9] = new SqlParameter("@PartId", ObjBOL.PartId);
            param[10] = new SqlParameter("@Remarks", ObjBOL.Remarks);
            param[11] = new SqlParameter("@ReqForId", ObjBOL.ReqForId);
            param[12] = new SqlParameter("@PurchaseOrderDetail", ObjBOL.PurchaseOrderDetails);
            param[13] = new SqlParameter("@Status", ObjBOL.Status);
            param[14] = new SqlParameter("@RequestedBy", ObjBOL.RequestedBy);
            param[15] = new SqlParameter("@PORemarks", ObjBOL.PORemarks);
            param[16] = new SqlParameter("@WareHouseID", ObjBOL.WareHouseID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManagePurchaseOrderManual_V1]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public string UpdateStatus(BOLPurchaseOrder ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ReqId", ObjBOL.ReqId);
            param[3] = new SqlParameter("@ReqStatus", ObjBOL.ReqStatus);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManagePurchaseOrderManual_V1]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public string UpdatePurchaseOrderStatus(BOLPurchaseOrder ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PurchaseOrderID", ObjBOL.PONumberID);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManagePurchaseOrderManual_V1]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public string GetPurchaseOrderNumber(BOLPurchaseOrder ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManagePurchaseOrderManual_V1]", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        //GetTransitionData
        public DataSet GetTransitionData(BOLPurchaseOrder ObjBOL)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@partid", ObjBOL.PartId);
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_PurchaseOrderDetail_PopupTransit]", param);
            return ds;
        }
        //GetInStockData
        public DataSet GetInStockData(BOLPurchaseOrder ObjBOL)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@partid", ObjBOL.PartId);
            ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Inv_PurchaseOrderDetail_PopupInStock]", param);
            return ds;
        }
        public DataSet GetInShopData(BOLPurchaseOrder ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@partid", ObjBOL.PartId);
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_Requisition_PopupInShop]", param);
            return ds;
        }
    }

    public class DALContainerNew : Connection
    {
        public DataSet GetBindControl(BOLContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@POid", ObjBOL.POid);
            param[3] = new SqlParameter("@Containerid", ObjBOL.Containerid);
            param[4] = new SqlParameter("@POForId", ObjBOL.POForId);
            param[5] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[6] = new SqlParameter("@SourceID", ObjBOL.SourceID);
            param[7] = new SqlParameter("@JobID", ObjBOL.JobID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Inv_ManageContainerNew]", param);
            return ds;
        }

        public string SaveContainerInfo(BOLContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[18];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@InvoiceNo", ObjBOL.InvoiceNo);
            param[2] = new SqlParameter("@ContainerNo", ObjBOL.ContainerNo);
            param[3] = new SqlParameter("@SealNo", ObjBOL.SealNo);
            param[4] = new SqlParameter("@SentDate", ObjBOL.SentDate);
            param[5] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[6] = new SqlParameter("@ContainerDetails", ObjBOL.ContainerDetails);
            param[7] = new SqlParameter("@LoginUserId", ObjBOL.LoginUserId);
            param[8] = new SqlParameter("@ArrivalinAerowerks", ObjBOL.ArrivalinAerowerks);
            param[9] = new SqlParameter("@ContainerSize", ObjBOL.ContainerSize);
            param[10] = new SqlParameter("@Attn", ObjBOL.Attn);
            param[11] = new SqlParameter("@Issuedby", ObjBOL.Issuedby);
            param[12] = new SqlParameter("@Containerid", ObjBOL.Containerid);
            param[13] = new SqlParameter("@SourceID", ObjBOL.SourceID);
            param[14] = new SqlParameter("@ShipmentBy", ObjBOL.ShipmentBy);
            param[15] = new SqlParameter("@TentativeSentDate", ObjBOL.TentativeSentDate);
            param[16] = new SqlParameter("@ApprovedBy", ObjBOL.ApprovedBy);
            param[17] = new SqlParameter("@UploadDocument", ObjBOL.UploadDocument);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[Inv_ManageContainerNew]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public string UpdateStatus(BOLContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@POid", ObjBOL.POid);
            param[3] = new SqlParameter("@POStatus", ObjBOL.ReqStatus);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Inv_ManageContainerNew]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        //UpdateContainerStatus
        public string UpdateContainerStatus(BOLContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Containerid", ObjBOL.Containerid);
            param[3] = new SqlParameter("@LoginUserId", ObjBOL.LoginUserId);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Inv_ManageContainerNew]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public string SaveJobDetails(BOLContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Containerid", ObjBOL.Containerid);
            param[3] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[4] = new SqlParameter("@Qty", ObjBOL.JobQty);
            param[5] = new SqlParameter("@Remarks", ObjBOL.JobRemarks);
            param[6] = new SqlParameter("@SourceID", ObjBOL.SourceID);
            param[7] = new SqlParameter("@desc", ObjBOL.Desc);
            param[8] = new SqlParameter("@requestor", ObjBOL.Requestor);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Inv_ManageContainerNew]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public string DeleteJobDetails(BOLContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ContainerProjectsID", ObjBOL.ContainerProjectsID);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Inv_ManageContainerNew]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }


    public class DALVendorMaintenance : Connection
    {

        public DataSet Return_DataSet(BOLVendorMaintenance ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@Msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Name", ObjBOL.Name);
            //param[3] = new SqlParameter("@LoginUserId", ObjBOL.EmployeeID);
            param[4] = new SqlParameter("@LeadTimeDays", ObjBOL.LeadTimeDays);
            param[5] = new SqlParameter("@Notes", ObjBOL.Notes);
            param[7] = new SqlParameter("@StreetAddress", ObjBOL.StreetAddress);
            param[8] = new SqlParameter("@Contact", ObjBOL.Contact);
            param[9] = new SqlParameter("@Phone", ObjBOL.Phone);
            param[10] = new SqlParameter("@Email", ObjBOL.Email);
            param[11] = new SqlParameter("@Id", ObjBOL.Id);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Inv_ManageVendor]", param);
            return ds;
        }

        public string Return_String(BOLVendorMaintenance ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@Msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Name", ObjBOL.Name);
            //param[3] = new SqlParameter("@LoginUserId", ObjBOL.EmployeeID);
            param[4] = new SqlParameter("@LeadTimeDays", ObjBOL.LeadTimeDays);
            param[5] = new SqlParameter("@Notes", ObjBOL.Notes);
            param[7] = new SqlParameter("@StreetAddress", ObjBOL.StreetAddress);
            param[8] = new SqlParameter("@Contact", ObjBOL.Contact);
            param[9] = new SqlParameter("@Phone", ObjBOL.Phone);
            param[10] = new SqlParameter("@Email", ObjBOL.Email);
            param[11] = new SqlParameter("@Id", ObjBOL.Id);

            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[Inv_ManageVendor]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }
    public class DALRegions : Connection
    {
        public DataSet BindControls(BOLRegions ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@CountryID", ObjBOL.CountryId);
            param[2] = new SqlParameter("@RegionID", ObjBOL.RegionId);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[ManageRegions]", param);
            return ds;
        }

        public string SaveAndUpdate(BOLRegions ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@Msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@CountryID", ObjBOL.CountryId);
            param[3] = new SqlParameter("@RegionID", ObjBOL.RegionId);
            param[4] = new SqlParameter("@DirectorName", ObjBOL.Director);
            param[5] = new SqlParameter("@DirectorPhone", ObjBOL.DirectorPhone);
            param[6] = new SqlParameter("@DirectorEmail", ObjBOL.DirectorEmail);
            param[7] = new SqlParameter("@RegionName", ObjBOL.RegionName);

            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[ManageRegions]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DAL_ITWProjects : Connection
    {
        public DataSet BindControls(BOL_ITWProjects ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@POID", ObjBOL.POID);
            param[2] = new SqlParameter("@DepartmentID", ObjBOL.DepartmentID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[ManageITWProjects]", param);
            return ds;
        }

        public string SaveAndUpdate(BOL_ITWProjects ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@POID", ObjBOL.POID);
            param[3] = new SqlParameter("@DepartmentID", ObjBOL.DepartmentID);
            param[4] = new SqlParameter("@PONumber", ObjBOL.PONumber);
            param[5] = new SqlParameter("@PORecDate", ObjBOL.PORecDate);
            param[6] = new SqlParameter("@POReleaseDate", ObjBOL.POReleaseDate);
            param[7] = new SqlParameter("@VMOrderID", ObjBOL.VMOrderID);
            param[8] = new SqlParameter("@POCost", ObjBOL.POCost);
            param[9] = new SqlParameter("@Comments", ObjBOL.Comments);

            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[ManageITWProjects]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }
    public class DALManageReps : Connection
    {
        public string SaveAndUpdate(BOLManageReps ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ProductLineID", ObjBOL.ProductLineID);
            param[3] = new SqlParameter("@RepGroupID", ObjBOL.RepGroupID);
            param[4] = new SqlParameter("@BranchID", ObjBOL.BranchID);
            param[5] = new SqlParameter("@FirstName", ObjBOL.FirstName);
            param[6] = new SqlParameter("@LastName", ObjBOL.LastName);
            param[7] = new SqlParameter("@AbbreviationID", ObjBOL.AbbreviationID);
            param[8] = new SqlParameter("@Phone", ObjBOL.Phone);
            param[9] = new SqlParameter("@Email", ObjBOL.Email);
            param[10] = new SqlParameter("@Status", ObjBOL.Status);
            param[11] = new SqlParameter("@SalesRepID", ObjBOL.SalesRepID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageReps", param);
            string msg = param[0].Value.ToString();
            return msg;

        }
        public DataSet GetBranchInformation(BOLManageReps ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@BranchID", ObjBOL.BranchID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[3] = new SqlParameter("@RepGroupID", ObjBOL.RepGroupID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageReps", param);
            return ds;
        }

        public DataSet GetControls(BOLManageReps ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageReps", param);
            return ds;
        }
    }

    public class DALPreventiveMaintenance : Connection
    {
        public string SaveAndUpdate(BOLPreventiveMaintenance ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[21];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[3] = new SqlParameter("@OrderNo", ObjBOL.OrderNo);
            param[4] = new SqlParameter("@StatusID", ObjBOL.StatusID);
            param[5] = new SqlParameter("@QuoteSentDate", ObjBOL.QuoteSentDate);
            param[6] = new SqlParameter("@QuoteAmount", ObjBOL.QuoteAmount);
            param[7] = new SqlParameter("@PONumber", ObjBOL.PONumber);
            param[8] = new SqlParameter("@PORecDate", ObjBOL.PORecDate);
            param[9] = new SqlParameter("@ContractStartDate", ObjBOL.ContractStartDate);
            param[10] = new SqlParameter("@ContractEndDate", ObjBOL.ContractEndDate);
            param[11] = new SqlParameter("@LastTuneDate", ObjBOL.LastTuneUpDate);
            param[12] = new SqlParameter("@NextTuneDate", ObjBOL.NextTuneUpDate);
            param[13] = new SqlParameter("@InvoiceDate", ObjBOL.InvoiceDate);
            param[14] = new SqlParameter("@InvoiceNo", ObjBOL.InvoiceNo);
            param[15] = new SqlParameter("@FollowUpDate", ObjBOL.FollowUpDate);
            param[16] = new SqlParameter("@Remarks", ObjBOL.Remarks);
            param[17] = new SqlParameter("@ID", ObjBOL.ID);
            param[18] = new SqlParameter("@CategoryID", ObjBOL.CategoryID);
            param[19] = new SqlParameter("@QuoteDetails", ObjBOL.QuoteDetails);
            param[20] = new SqlParameter("@Attention", ObjBOL.Attention);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManagePreventiveMaintenance", param);
            string msg = param[0].Value.ToString();
            return msg;

        }
        public DataSet GetInformation(BOLPreventiveMaintenance ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[3] = new SqlParameter("@ID", ObjBOL.ID);
            param[4] = new SqlParameter("@OrderNo", ObjBOL.OrderNo);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManagePreventiveMaintenance", param);
            return ds;
        }

        public DataSet GetControls(BOLPreventiveMaintenance ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManagePreventiveMaintenance", param);
            return ds;
        }
    }

    public class DALDailyCADReport : Connection
    {
        public string SaveAndUpdate(BOLDailyCADReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[18];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ID", ObjBOL.ID);
            param[3] = new SqlParameter("@ReportDate", ObjBOL.ReportDate);
            param[4] = new SqlParameter("@PNumber", ObjBOL.PNumber);
            param[5] = new SqlParameter("@CADReportID", ObjBOL.CADReportID);
            param[6] = new SqlParameter("@NatureID", ObjBOL.NatureID);
            param[7] = new SqlParameter("@ReqRCD", ObjBOL.ReqRCD);
            param[8] = new SqlParameter("@SentCAD", ObjBOL.SentCAD);
            param[9] = new SqlParameter("@SentRCD", ObjBOL.SentRCD);
            param[10] = new SqlParameter("@StatusID", ObjBOL.StatusID);
            param[11] = new SqlParameter("@Comments", ObjBOL.Comments);
            param[12] = new SqlParameter("@Remarks", ObjBOL.Remarks);
            param[13] = new SqlParameter("@DetailID", ObjBOL.DetailID);
            param[14] = new SqlParameter("@ProjectEngineerID", ObjBOL.ProjectEngineerID);
            param[15] = new SqlParameter("@Priority", ObjBOL.Priority);
            param[16] = new SqlParameter("@Progress", ObjBOL.Progress);
            param[17] = new SqlParameter("@Correction", ObjBOL.Correction);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageCADReport", param);
            string msg = param[0].Value.ToString();
            return msg;

        }
        public DataSet GetInformation(BOLDailyCADReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@CADReportID", ObjBOL.CADReportID);
            param[2] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[3] = new SqlParameter("@ID", ObjBOL.ID);
            param[4] = new SqlParameter("@PNumber", ObjBOL.PNumber);
            param[5] = new SqlParameter("@ReportDate", ObjBOL.ReportDate);
            param[6] = new SqlParameter("@DetailID", ObjBOL.DetailID);
            param[7] = new SqlParameter("@Priority", ObjBOL.Priority);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageCADReport", param);
            return ds;
        }

        public DataSet GetControls(BOLDailyCADReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageCADReport", param);
            return ds;
        }

        public DataSet BindReport(BOLDailyCADReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ID", ObjBOL.ID);
            param[1] = new SqlParameter("@ProjectEngineerID", ObjBOL.ProjectEngineerID);
            param[2] = new SqlParameter("@PNumber", ObjBOL.PNumber);
            param[3] = new SqlParameter("@NatureID", ObjBOL.NatureID);
            param[4] = new SqlParameter("@StatusID", ObjBOL.StatusID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Get_CADReport", param);
            return ds;
        }
    }

    public class DALManageSearchPO : Connection
    {
        public DataSet GetSearchRecords(BOLSearchPO ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@SearchVar", ObjBOL.SearchVar);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Get_SearchPO]", param);
            return ds;
        }
        //GetSearchReportData
        public DataSet GetSearchReportData(BOLSearchPO ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@SearchVar", ObjBOL.SearchVar);
            param[3] = new SqlParameter("@PurchaseOrderID", ObjBOL.PurchaseOrderID);
            param[4] = new SqlParameter("@PartID", ObjBOL.PartID);
            param[5] = new SqlParameter("@SourceID", ObjBOL.SourceID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Get_Inv_RT_POReport]", param);
            return ds;
        }
    }

    public class DALAeroInvoice : Connection
    {
        public DataSet GetReportData(BOLAeroInvoice ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@FromDate", ObjBOL.FromDate);
            param[3] = new SqlParameter("@ToDate", ObjBOL.ToDate);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Get_AeroInvoice", param);
            return ds;
        }
    }

    public class DALManagePartWiseDetail : Connection
    {
        public DataSet GetPartDetails(BOLPartWiseDetails ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PartId", ObjBOL.PartId);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Get_PO_PartDetails", param);
            return ds;
        }
    }

    public class DALManageInboundInspectionSummary : Connection
    {
        public DataSet GetInboundInspectionSummaryDetails(BOLInboundInspectionSummary ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PartID", ObjBOL.PartID);
            param[3] = new SqlParameter("@InspectionDetailID", ObjBOL.InspectionDetailID);
            param[4] = new SqlParameter("@plant", ObjBOL.plant);
            param[5] = new SqlParameter("@ProductCode", ObjBOL.ProductCode);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "INV_InboundInspections", param);
            return ds;
        }
        public string SaveSummaryDetails(BOLInboundInspectionSummary ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@PartID", ObjBOL.PartID);
            param[2] = new SqlParameter("@plant", ObjBOL.plant);
            param[3] = new SqlParameter("@containerno", ObjBOL.containerno);
            param[4] = new SqlParameter("@inspectiondate", ObjBOL.inspectiondate);
            param[5] = new SqlParameter("@qtyinspected", ObjBOL.qtyinspected);
            param[6] = new SqlParameter("@qtyreceived", ObjBOL.qtyreceived);
            param[7] = new SqlParameter("@qtyapproved", ObjBOL.qtyapproved);
            param[8] = new SqlParameter("@remarks", ObjBOL.summary);
            param[9] = new SqlParameter("@userid", ObjBOL.userid);
            param[10] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[11] = new SqlParameter("@InspectionDetailID", ObjBOL.InspectionDetailID);
            param[12] = new SqlParameter("@filename", ObjBOL.filename);
            param[13] = new SqlParameter("@status", ObjBOL.status);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "INV_InboundInspections", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        //DeleteDetails
        public string DeleteDetails(BOLInboundInspectionSummary ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@InspectionDetailID", ObjBOL.InspectionDetailID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "INV_InboundInspections", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALManageSearchContainer : Connection
    {
        public DataSet GetSearchRecords(BOLSearchContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@SearchVar", ObjBOL.SearchVar);
            param[3] = new SqlParameter("@SourceID", ObjBOL.SourceID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Get_SearchContainer]", param);
            return ds;
        }
        //DeletePOData
        public string DeletePOData(BOLSearchContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@POId", ObjBOL.POId);
            param[3] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[Inv_PurchaseOrder_Delete]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALForecastingSubParts : Connection
    {
        public DataSet Return_DataSet(BOLForecastingSubParts ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@Product", ObjBOL.Product);
            param[2] = new SqlParameter("@StartDate", ObjBOL.StartDate);
            param[3] = new SqlParameter("@EndDate", ObjBOL.EndDate);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManageForecastingSubParts]", param);
            return ds;
        }
    }

    public class DALPrepareContainerNew : Connection
    {
        public DataSet GetBindControl(BOLPrepareContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@POid", ObjBOL.POid);
            param[3] = new SqlParameter("@Containerid", ObjBOL.Containerid);
            param[4] = new SqlParameter("@POForId", ObjBOL.POForId);
            param[5] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[6] = new SqlParameter("@SourceID", ObjBOL.SourceID);
            param[7] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[8] = new SqlParameter("@PartID", ObjBOL.PartId);
            param[9] = new SqlParameter("@PODetailid", ObjBOL.PODetailid);
            param[10] = new SqlParameter("@WarehouseID", ObjBOL.WarehouseID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManagePrepareContainerNew_V1]", param);
            return ds;
        }

        public string SaveContainerInfo(BOLPrepareContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[19];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@InvoiceNo", ObjBOL.InvoiceNo);
            param[2] = new SqlParameter("@ContainerNo", ObjBOL.ContainerNo);
            param[3] = new SqlParameter("@SealNo", ObjBOL.SealNo);
            param[4] = new SqlParameter("@SentDate", ObjBOL.SentDate);
            param[5] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[6] = new SqlParameter("@ContainerDetails", ObjBOL.ContainerDetails);
            param[7] = new SqlParameter("@LoginUserId", ObjBOL.LoginUserId);
            param[8] = new SqlParameter("@ArrivalinAerowerks", ObjBOL.ArrivalinAerowerks);
            param[9] = new SqlParameter("@ContainerSize", ObjBOL.ContainerSize);
            param[10] = new SqlParameter("@Attn", ObjBOL.Attn);
            param[11] = new SqlParameter("@Issuedby", ObjBOL.Issuedby);
            param[12] = new SqlParameter("@Containerid", ObjBOL.Containerid);
            param[13] = new SqlParameter("@SourceID", ObjBOL.SourceID);
            param[14] = new SqlParameter("@ShipmentBy", ObjBOL.ShipmentBy);
            param[15] = new SqlParameter("@TentativeSentDate", ObjBOL.TentativeSentDate);
            param[16] = new SqlParameter("@ApprovedBy", ObjBOL.ApprovedBy);
            param[17] = new SqlParameter("@UploadDocument", ObjBOL.UploadDocument);
            param[18] = new SqlParameter("@WarehouseID", ObjBOL.WarehouseID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[IV].[Inv_ManagePrepareContainerNew_V1]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        //CheckContainerStatus
        public string CheckContainerStatus(BOLPrepareContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[3] = new SqlParameter("@Containerid", ObjBOL.Containerid);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManagePrepareContainerNew_V1]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public string UpdateStatus(BOLPrepareContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@POid", ObjBOL.POid);
            param[3] = new SqlParameter("@POStatus", ObjBOL.ReqStatus);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManagePrepareContainerNew_V1]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        //UpdateContainerStatus
        public string UpdateContainerStatus(BOLPrepareContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Containerid", ObjBOL.Containerid);
            param[3] = new SqlParameter("@LoginUserId", ObjBOL.LoginUserId);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManagePrepareContainerNew_V1]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public string SaveJobDetails(BOLPrepareContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Containerid", ObjBOL.Containerid);
            param[3] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[4] = new SqlParameter("@Qty", ObjBOL.JobQty);
            param[5] = new SqlParameter("@Remarks", ObjBOL.JobRemarks);
            param[6] = new SqlParameter("@SourceID", ObjBOL.SourceID);
            param[7] = new SqlParameter("@desc", ObjBOL.Desc);
            param[8] = new SqlParameter("@requestor", ObjBOL.Requestor);
            param[9] = new SqlParameter("@LoginUserId", ObjBOL.LoginUserId);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManagePrepareContainerNew_V1]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public string DeleteJobDetails(BOLPrepareContainer ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@Containerid", ObjBOL.Containerid);
            param[3] = new SqlParameter("@LoginUserId", ObjBOL.LoginUserId);
            param[4] = new SqlParameter("@ContainerProjectsID", ObjBOL.ContainerProjectsID);
            SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManagePrepareContainerNew_V1]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALDailyQuoteReport : Connection
    {
        public string GetString(BOLDailyQuoteReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ID", ObjBOL.ID);
            param[3] = new SqlParameter("@PNumber", ObjBOL.PNumber);
            param[4] = new SqlParameter("@QuoteReportID", ObjBOL.QuoteReportID);
            param[5] = new SqlParameter("@NatureID", ObjBOL.NatureID);
            param[6] = new SqlParameter("@Priority", ObjBOL.Priority);
            param[7] = new SqlParameter("@ProjectEngineerID", ObjBOL.ProjectEngineerID);
            param[8] = new SqlParameter("@ReqByCustomer", ObjBOL.ReqByCustomer);
            param[9] = new SqlParameter("@SentQuoteRequest", ObjBOL.SentQuoteRequest);
            param[10] = new SqlParameter("@SentToCustomer", ObjBOL.SentToCustomer);
            param[11] = new SqlParameter("@StatusID", ObjBOL.StatusID);
            param[12] = new SqlParameter("@Remarks", ObjBOL.Remarks);
            param[13] = new SqlParameter("@RemarksByTL", ObjBOL.RemarksByTL);
            param[14] = new SqlParameter("@OptionID", ObjBOL.OptionID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ManageQuoteReport", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

        public DataSet GetDataset(BOLDailyQuoteReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ID", ObjBOL.ID);
            param[3] = new SqlParameter("@PNumber", ObjBOL.PNumber);
            param[4] = new SqlParameter("@QuoteReportID", ObjBOL.QuoteReportID);
            param[5] = new SqlParameter("@NatureID", ObjBOL.NatureID);
            param[6] = new SqlParameter("@Priority", ObjBOL.Priority);
            param[7] = new SqlParameter("@ProjectEngineerID", ObjBOL.ProjectEngineerID);
            param[8] = new SqlParameter("@ReqByCustomer", ObjBOL.ReqByCustomer);
            param[9] = new SqlParameter("@SentQuoteRequest", ObjBOL.SentQuoteRequest);
            param[10] = new SqlParameter("@SentToCustomer", ObjBOL.SentToCustomer);
            param[11] = new SqlParameter("@StatusID", ObjBOL.StatusID);
            param[12] = new SqlParameter("@Remarks", ObjBOL.Remarks);
            param[13] = new SqlParameter("@RemarksByTL", ObjBOL.RemarksByTL);
            param[14] = new SqlParameter("@OptionID", ObjBOL.OptionID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ManageQuoteReport", param);
            return ds;
        }

        public DataSet BindReport(BOLDailyQuoteReport ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ID", ObjBOL.ID);
            param[1] = new SqlParameter("@ProjectEngineerID", ObjBOL.ProjectEngineerID);
            param[2] = new SqlParameter("@PNumber", ObjBOL.PNumber);
            param[3] = new SqlParameter("@NatureID", ObjBOL.NatureID);
            param[4] = new SqlParameter("@StatusID", ObjBOL.StatusID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Get_QuoteReport", param);
            return ds;
        }
    }

    //DALManageCADDYProjectInfo
    public class DALManageCADDYProjectInfo : Connection
    {
        public DataSet GetControls(BOLCADDYProjectInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ProjectID", ObjBOL.ProjectID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Caddy_ProjectInfo", param);
            return ds;
        }
        public string SaveProjectInfo(BOLCADDYProjectInfo ObjBOL)
        {

            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@JobNo", ObjBOL.JobNo);
            param[3] = new SqlParameter("@JobName", ObjBOL.JobName);
            param[4] = new SqlParameter("@JobType", ObjBOL.JobType);
            param[5] = new SqlParameter("@PMCaddy", ObjBOL.PMCaddy);
            param[6] = new SqlParameter("@ProjectID", ObjBOL.ProjectID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Caddy_ProjectInfo", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        public string SaveModelInfo(BOLCADDYProjectInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ProjectID", ObjBOL.ProjectID);
            param[3] = new SqlParameter("@SelectedItems", ObjBOL.SelectedItems);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Caddy_ProjectInfo", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        //BindModelsDescriptionToolTip
        public DataSet BindModelsDescriptionToolTip(BOLCADDYProjectInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ModelID", ObjBOL.ModelID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Caddy_ProjectInfo", param);
            return ds;
        }
        //BindConveyorDescriptionToolTip
        public DataSet BindConveyorDescriptionToolTip(BOLCADDYProjectInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ModelID", ObjBOL.ModelID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Get_CaddyModelsConveyor", param);
            return ds;
        }
        public string CheckProjectType(BOLCADDYProjectInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ProjectID", ObjBOL.ProjectID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Caddy_ProjectInfo", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        //BindModels
        public DataSet BindModels(BOLCADDYProjectInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Get_CaddyModelsConveyor", param);
            return ds;
        }
    }

    public class DALManageCADDYENGTasks : Connection
    {
        public DataSet GetControls(BOLCADDYENGTasks ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ProjectID", ObjBOL.ProjectID);
            param[3] = new SqlParameter("@JobNo", ObjBOL.JobNo);
            param[4] = new SqlParameter("@EngProjectID", ObjBOL.EngProjectID);
            param[5] = new SqlParameter("@EngDepID", ObjBOL.EngDepID);
            param[6] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[7] = new SqlParameter("@JobType", ObjBOL.JobType);
            param[8] = new SqlParameter("@ProjectType", ObjBOL.ProjectType);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Caddy_EngTasks", param);
            return ds;
        }
        //AutoFillProjectInfo
        public DataSet AutoFillProjectInfo(BOLCADDYENGTasks ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@JobNo", ObjBOL.JobNo);
            param[3] = new SqlParameter("@JobName", ObjBOL.JobName);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Caddy_EngTasks", param);
            return ds;
        }
        //SaveEngTaskDetails
        public string SaveEngTaskDetails(BOLCADDYENGTasks ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[19];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ProjectID", ObjBOL.ProjectID);
            param[3] = new SqlParameter("@ProjectType", ObjBOL.ProjectType);
            param[4] = new SqlParameter("@Nature", ObjBOL.Nature);
            param[5] = new SqlParameter("@ReqFWDToIndia", ObjBOL.ReqFWDToIndia);
            param[6] = new SqlParameter("@AssingedTo", ObjBOL.AssingedTo);
            param[7] = new SqlParameter("@SentToCaddy", ObjBOL.SentToCaddy);
            param[8] = new SqlParameter("@Remarks", ObjBOL.Remarks);
            param[9] = new SqlParameter("@RemarksByPM", ObjBOL.RemarksByPM);
            param[10] = new SqlParameter("@EngProjectID", ObjBOL.EngProjectID);
            param[11] = new SqlParameter("@StatusID", ObjBOL.StatusID);
            param[12] = new SqlParameter("@ProjectDueDate", ObjBOL.ProjectDueDate);
            param[13] = new SqlParameter("@Progress", ObjBOL.Progress);
            param[14] = new SqlParameter("@Priority", ObjBOL.Priority);
            param[15] = new SqlParameter("@ItemNo", ObjBOL.ItemNo);
            param[16] = new SqlParameter("@ModelId", ObjBOL.ModelId);
            param[17] = new SqlParameter("@Correction", ObjBOL.Correction);
            param[18] = new SqlParameter("@ProjectManagerID", ObjBOL.ProjectManagerID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Caddy_EngTasks", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        //DeleteTaskDetails
        public string DeleteTaskDetails(BOLCADDYENGTasks ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@EngProjectID", ObjBOL.EngProjectID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Caddy_EngTasks", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        public string CheckPermission(BOLCADDYENGTasks ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "Caddy_EngTasks", param);
            string msg = Convert.ToString(param[0].Value);
            return msg;
        }
        public DataSet GetCADDYJobNumber(BOLCADDYENGTasks ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@JobNo", ObjBOL.JobNo);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Caddy_EngTasks", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetCADDYJobName(BOLCADDYENGTasks ObjBOL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                param[0].Direction = ParameterDirection.Output;
                param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
                param[2] = new SqlParameter("@JobName", ObjBOL.JobName);
                ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Caddy_EngTasks", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        //GetFilterData
        public DataSet GetFilterData(BOLCADDYENGTasks ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@JobTypeID", ObjBOL.JobTypeID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "Caddy_EngTasks", param);
            return ds;
        }
    }

    public class DALStockIn_New : Connection
    {
        public DataSet Return_DataSet(BOLStockIn_New ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ReceivedDate", ObjBOL.ReceivedDate);
            param[2] = new SqlParameter("@ID", ObjBOL.ID);
            param[3] = new SqlParameter("@RevisedETA", ObjBOL.RevisedETA);
            param[4] = new SqlParameter("@Comments", ObjBOL.Comments);
            param[5] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[6] = new SqlParameter("@ContainerID", ObjBOL.ContainerID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[IV].[Inv_ManageStockInNew_V1]", param);
            return ds;
        }

        public string Return_String(BOLStockIn_New ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ReceivedDate", ObjBOL.ReceivedDate);
            param[3] = new SqlParameter("@ID", ObjBOL.ID);
            param[4] = new SqlParameter("@RevisedETA", ObjBOL.RevisedETA);
            param[5] = new SqlParameter("@Comments", ObjBOL.Comments);
            param[6] = new SqlParameter("@EmployeeID", ObjBOL.EmployeeID);
            param[7] = new SqlParameter("@ContainerID", ObjBOL.ContainerID);
            param[8] = new SqlParameter("@Status", ObjBOL.Status);
            param[9] = new SqlParameter("@ContainerDetailID", ObjBOL.ContainerDetailID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[IV].[Inv_ManageStockInNew_V1]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public string UploadPackingList(BOLStockIn_New ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ID", ObjBOL.ID);
            param[3] = new SqlParameter("@PackingList", ObjBOL.PackingList);
            param[4] = new SqlParameter("@ReceivedDate", ObjBOL.ReceivedDate);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[IV].[Inv_ManageStockInNew_V1]", param);
            string msg = param[0].Value.ToString();
            return msg;
        }

    }

    // TW START

    public class DALTurboWashPart : Connection
    {
        public DataSet GetDataSet(BOLTurboWashPart ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ID", ObjBOL.ID);
            param[3] = new SqlParameter("@CategoryID", ObjBOL.CategoryID);
            param[4] = new SqlParameter("@PartNo", ObjBOL.PartNo);
            param[6] = new SqlParameter("@StockInHand", ObjBOL.StockInHand);
            param[7] = new SqlParameter("@Size", ObjBOL.Size);
            param[8] = new SqlParameter("@Direction", ObjBOL.Direction);
            param[9] = new SqlParameter("@OptionID", ObjBOL.OptionID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "TW_ManageTurboWashPart", param);
            return ds;
        }

        public string GetString(BOLTurboWashPart ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ID", ObjBOL.ID);
            param[3] = new SqlParameter("@CategoryID", ObjBOL.CategoryID);
            param[4] = new SqlParameter("@PartNo", ObjBOL.PartNo);
            param[6] = new SqlParameter("@StockInHand", ObjBOL.StockInHand);
            param[7] = new SqlParameter("@Size", ObjBOL.Size);
            param[8] = new SqlParameter("@Direction", ObjBOL.Direction);
            param[9] = new SqlParameter("@OptionID", ObjBOL.OptionID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "TW_ManageTurboWashPart", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    public class DALTurboWashTransaction : Connection
    {
        public DataSet GetDataSet(BOLTurboWashTransaction ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PartID", ObjBOL.PartID);
            param[3] = new SqlParameter("@CategoryID", ObjBOL.CategoryID);
            param[4] = new SqlParameter("@OpeningStock", ObjBOL.OpeningStock);
            param[5] = new SqlParameter("@TransactQty", ObjBOL.TransactQty);
            param[6] = new SqlParameter("@ClosingStock", ObjBOL.ClosingStock);
            param[7] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[8] = new SqlParameter("@LoginUserID", ObjBOL.LoginUserID);
            param[9] = new SqlParameter("@TransactType", ObjBOL.TransactType);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "TW_ManageTurboWashTransaction", param);
            return ds;
        }

        public string GetString(BOLTurboWashTransaction ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@PartID", ObjBOL.PartID);
            param[3] = new SqlParameter("@CategoryID", ObjBOL.CategoryID);
            param[4] = new SqlParameter("@OpeningStock", ObjBOL.OpeningStock);
            param[5] = new SqlParameter("@TransactQty", ObjBOL.TransactQty);
            param[6] = new SqlParameter("@ClosingStock", ObjBOL.ClosingStock);
            param[7] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[8] = new SqlParameter("@LoginUserID", ObjBOL.LoginUserID);
            param[9] = new SqlParameter("@TransactType", ObjBOL.TransactType);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "TW_ManageTurboWashTransaction", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }

    // TW END

    public class DALMiscellaneousTasks : Connection
    {
        public DataSet Return_DataSet(BOLMiscellaneousTasks ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ID", ObjBOL.ID);
            param[2] = new SqlParameter("@CompanyName", ObjBOL.CompanyName);
            param[3] = new SqlParameter("@Location", ObjBOL.Location);
            param[4] = new SqlParameter("@RefNo", ObjBOL.RefNo);
            param[5] = new SqlParameter("@Contact", ObjBOL.Contact);
            param[6] = new SqlParameter("@Issue", ObjBOL.Issue);
            param[7] = new SqlParameter("@IssueDate", ObjBOL.IssueDate);
            param[8] = new SqlParameter("@IssueBy", ObjBOL.IssueBy);
            param[9] = new SqlParameter("@Solution", ObjBOL.Solution);
            param[10] = new SqlParameter("@SolutionDate", ObjBOL.SolutionDate);
            param[11] = new SqlParameter("@Description", ObjBOL.Description);
            param[12] = new SqlParameter("@DocPath", ObjBOL.DocPath);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[aero_ManageMiscellaneousTasks]", param);
            return ds;
        }

        public string Return_String(BOLMiscellaneousTasks ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@ID", ObjBOL.ID);
            param[2] = new SqlParameter("@CompanyName", ObjBOL.CompanyName);
            param[3] = new SqlParameter("@Location", ObjBOL.Location);
            param[4] = new SqlParameter("@RefNo", ObjBOL.RefNo);
            param[5] = new SqlParameter("@Contact", ObjBOL.Contact);
            param[6] = new SqlParameter("@Issue", ObjBOL.Issue);
            param[7] = new SqlParameter("@IssueDate", ObjBOL.IssueDate);
            param[8] = new SqlParameter("@IssueBy", ObjBOL.IssueBy);
            param[9] = new SqlParameter("@Solution", ObjBOL.Solution);
            param[10] = new SqlParameter("@SolutionDate", ObjBOL.SolutionDate);
            param[11] = new SqlParameter("@Description", ObjBOL.Description);
            param[12] = new SqlParameter("@DocPath", ObjBOL.DocPath);
            param[13] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[13].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[aero_ManageMiscellaneousTasks]", param);
            string msg = param[13].Value.ToString();
            return msg;
        }
    }
    public class DALUserOTP : Connection
    {
        public String SaveDataUserOTP(BOLUserOTP ObjBOLUserOTP)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 150);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOLUserOTP.Operation);
            param[2] = new SqlParameter("@EmployeeID", ObjBOLUserOTP.EmployeeID);
            param[3] = new SqlParameter("@UserInputOTP", ObjBOLUserOTP.UserInputOTP);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_VerifyOTP", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }
    public class DALINVPartsInfo_CAD : Connection
    {
        public DataSet GetINVParts(BOLINVPartsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@operation", ObjBOL.operation);
            param[2] = new SqlParameter("@Productid", ObjBOL.product);
            param[3] = new SqlParameter("@projectid", ObjBOL.projectid);
            param[4] = new SqlParameter("@PartId", ObjBOL.PartId);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "INV_PartsInformation_CAD", param);
            return ds;
        }
        public String SaveINVParts(BOLINVPartsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.operation);
            param[2] = new SqlParameter("@projectid", ObjBOL.projectid);
            param[3] = new SqlParameter("@PartId", ObjBOL.PartId);
            param[4] = new SqlParameter("@Qty", ObjBOL.Qty);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "INV_PartsInformation_CAD", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        //UpdateINVParts
        public String UpdateINVParts(BOLINVPartsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.operation);
            param[2] = new SqlParameter("@projectid", ObjBOL.projectid);
            param[3] = new SqlParameter("@PartId", ObjBOL.PartId);
            param[4] = new SqlParameter("@Qty", ObjBOL.Qty);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "INV_PartsInformation_CAD", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
        public string DeleteINVPartsInfo(BOLINVPartsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@PartId", ObjBOL.PartId);
            param[2] = new SqlParameter("@Operation", ObjBOL.operation);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "INV_PartsInformation_CAD", param);
            string msg = "Successfully Deleted !";
            return msg;
        }
        //GetPartsCount
        public DataSet GetPartsCount(BOLINVPartsInfo ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Productid", ObjBOL.Productid);
            param[2] = new SqlParameter("@Operation", ObjBOL.operation);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "INV_PartsInformation_CAD", param);
            return ds;
        }
    }

    public class DALManageITWProjects : Connection
    {
        public DataSet Return_DataSet(BOLManageITWProjects ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@HobartDrawingNumber", ObjBOL.HobartDrawingNumber);
            param[3] = new SqlParameter("@ProjectName", ObjBOL.ProjectName);
            param[4] = new SqlParameter("@Orientation", ObjBOL.Orientation);
            param[5] = new SqlParameter("@OptionID", ObjBOL.OptionID);
            param[6] = new SqlParameter("@POReceivedDate", ObjBOL.POReceivedDate);
            param[7] = new SqlParameter("@ReqShipDate", ObjBOL.ReqShipDate);
            param[8] = new SqlParameter("@ShipDate", ObjBOL.ShipDate);
            param[9] = new SqlParameter("@EqPrice", ObjBOL.EqPrice);
            param[10] = new SqlParameter("@Release", ObjBOL.Release);
            param[11] = new SqlParameter("@ReleaseDate", ObjBOL.ReleaseDate);
            param[12] = new SqlParameter("@LoginUserID", ObjBOL.LoginUserID);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[TW_ManageITWProjects]", param);
            return ds;
        }

        public string Return_String(BOLManageITWProjects ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@HobartDrawingNumber", ObjBOL.HobartDrawingNumber);
            param[3] = new SqlParameter("@ProjectName", ObjBOL.ProjectName);
            param[4] = new SqlParameter("@Orientation", ObjBOL.Orientation);
            param[5] = new SqlParameter("@OptionID", ObjBOL.OptionID);
            param[6] = new SqlParameter("@POReceivedDate", ObjBOL.POReceivedDate);
            param[7] = new SqlParameter("@ReqShipDate", ObjBOL.ReqShipDate);
            param[8] = new SqlParameter("@ShipDate", ObjBOL.ShipDate);
            param[9] = new SqlParameter("@EqPrice", ObjBOL.EqPrice);
            param[10] = new SqlParameter("@Release", ObjBOL.Release);
            param[11] = new SqlParameter("@ReleaseDate", ObjBOL.ReleaseDate);
            param[12] = new SqlParameter("@LoginUserID", ObjBOL.LoginUserID);
            param[13] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[13].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[TW_ManageITWProjects]", param);
            string msg = param[13].Value.ToString();
            return msg;
        }
    }

    public class DALManageITWProjectParts : Connection
    {
        public DataSet Return_DataSet(BOLManageITWProjectParts ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@CategoryID", ObjBOL.CategoryID);
            param[3] = new SqlParameter("@PartID", ObjBOL.PartID);
            param[4] = new SqlParameter("@Qty", ObjBOL.Qty);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "[dbo].[TW_ManageProjectParts]", param);
            return ds;
        }

        public string Return_String(BOLManageITWProjectParts ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[1] = new SqlParameter("@JobID", ObjBOL.JobID);
            param[2] = new SqlParameter("@CategoryID", ObjBOL.CategoryID);
            param[3] = new SqlParameter("@PartID", ObjBOL.PartID);
            param[4] = new SqlParameter("@Qty", ObjBOL.Qty);
            param[5] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[5].Direction = ParameterDirection.Output;
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "[dbo].[TW_ManageProjectParts]", param);
            string msg = param[5].Value.ToString();
            return msg;
        }
    }

    public class DALManageProductLine : Connection
    {
        public DataSet GetBindControls(BOLManageProductLine ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@msg", SqlDbType.Char, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ProductCode", ObjBOL.ProductCode);
            param[3] = new SqlParameter("@Product", ObjBOL.Product);
            DataSet ds = SqlHelper1.ExecuteDataset(con, CommandType.StoredProcedure, "aero_ProductLine", param);
            return ds;
        }
        public string SaveProductLine(BOLManageProductLine ObjBOL)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@msg", SqlDbType.VarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            param[1] = new SqlParameter("@Operation", ObjBOL.Operation);
            param[2] = new SqlParameter("@ProductCode", ObjBOL.ProductCode);
            param[3] = new SqlParameter("@Product", ObjBOL.Product);
            param[4] = new SqlParameter("@ProductLineID", ObjBOL.ProductLineID);
            SqlHelper1.ExecuteNonQuery(con, CommandType.StoredProcedure, "aero_ProductLine", param);
            string msg = param[0].Value.ToString();
            return msg;
        }
    }
}