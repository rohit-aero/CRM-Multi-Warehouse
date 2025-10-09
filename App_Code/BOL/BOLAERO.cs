using System;
using System.Data;
/// <summary>
/// Summary description for BOLAERO
/// </summary>
namespace BOLAERO
{
    public class BOLInstallers
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        string _CompanyName;
        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        Int32 _CountryID;
        public Int32 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        Int32 _StateID;
        public Int32 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }

        string _City;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        string _ZipCode;
        public string ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }

        string _BankDetails;
        public string BankDetails
        {
            get { return _BankDetails; }
            set { _BankDetails = value; }
        }

        Int32 _StatusID;
        public Int32 StatusID
        {
            get { return _StatusID; }
            set { _StatusID = value; }
        }

        string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        string _Extension;
        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }

        string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        string _Cell;
        public string Cell
        {
            get { return _Cell; }
            set { _Cell = value; }
        }

        string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }
    public class BOLProjectsFabricationAndNestingTasks
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        String _JobId;
        public String JobId
        {
            get { return _JobId; }
            set { _JobId = value; }
        }

        String _TaskNumber;
        public String TaskNumber
        {
            get { return _TaskNumber; }
            set { _TaskNumber = value; }
        }

        String _NatureOfTask;
        public String NatureOfTask
        {
            get { return _NatureOfTask; }
            set { _NatureOfTask = value; }
        }

        String _ReleaseType;
        public String ReleaseType
        {
            get { return _ReleaseType; }
            set { _ReleaseType = value; }
        }

        Int32 _ProjectDesigner;
        public Int32 ProjectDesigner
        {
            get { return _ProjectDesigner; }
            set { _ProjectDesigner = value; }
        }

        Int32 _AssistedBy;
        public Int32 AssistedBy
        {
            get { return _AssistedBy; }
            set { _AssistedBy = value; }
        }

        DateTime? _StartDate;
        public DateTime? StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }

        DateTime? _EndDate;
        public DateTime? EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }

        Int32 _ReviewedBy;
        public Int32 ReviewedBy
        {
            get { return _ReviewedBy; }
            set { _ReviewedBy = value; }
        }

        String _AssignedFrom;
        public String AssignedFrom
        {
            get { return _AssignedFrom; }
            set { _AssignedFrom = value; }
        }

        Int32 _TaskType;
        public Int32 TaskType
        {
            get { return _TaskType; }
            set { _TaskType = value; }
        }

        Int32 _ProjectEngineer;
        public Int32 ProjectEngineer
        {
            get { return _ProjectEngineer; }
            set { _ProjectEngineer = value; }
        }

        DateTime? _SentDate;
        public DateTime? SentDate
        {
            get { return _SentDate; }
            set { _SentDate = value; }
        }

        Int32 _Status;
        public Int32 Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }

    public class BOLSalesOpportunity
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _SalesOpportunity;
        public Int32 SalesOpportunity
        {
            get { return _SalesOpportunity; }
            set { _SalesOpportunity = value; }
        }

        Int32 _SalesOpportunityStatus;
        public Int32 SalesOpportunityStatus
        {
            get { return _SalesOpportunityStatus; }
            set { _SalesOpportunityStatus = value; }
        }

        DateTime? _FromDate;
        public DateTime? FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        DateTime? _ToDate;
        public DateTime? ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }
    }

    public class BOLShippingHistory
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _CountryId;
        public Int32 CountryId
        {
            get { return _CountryId; }
            set { _CountryId = value; }
        }

        Int32 _IndustryId;
        public Int32 IndustryId
        {
            get { return _IndustryId; }
            set { _IndustryId = value; }
        }

        Int32 _StateId;
        public Int32 StateId
        {
            get { return _StateId; }
            set { _StateId = value; }
        }

        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }

        DateTime? _FromDate;
        public DateTime? FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        DateTime? _ToDate;
        public DateTime? ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }
    }

    public class BOLQuotesandOrders
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }

    public class BOLShopDrawingCategory
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        String _Category;
        public String Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        bool _Active;
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
    }

    public class BOLShopDrawingImpact
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        String _Impact;
        public String Impact
        {
            get { return _Impact; }
            set { _Impact = value; }
        }

        bool _Active;
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
    }

    public class BOLManageShopDwgIssueLog
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        String _IssueNo;
        public String IssueNo
        {
            get { return _IssueNo; }
            set { _IssueNo = value; }
        }

        String _JobId;
        public String JobId
        {
            get { return _JobId; }
            set { _JobId = value; }
        }

        DateTime? _DateIdentified;
        public DateTime? DateIdentified
        {
            get { return _DateIdentified; }
            set { _DateIdentified = value; }
        }

        Int32 _Id;
        public Int32 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        String _IssueDescription;
        public String IssueDescription
        {
            get { return _IssueDescription; }
            set { _IssueDescription = value; }
        }

        String _RootCause;
        public String RootCause
        {
            get { return _RootCause; }
            set { _RootCause = value; }
        }

        Int32 _ImpactId;
        public Int32 ImpactId
        {
            get { return _ImpactId; }
            set { _ImpactId = value; }
        }

        Int32 _CategoryId;
        public Int32 CategoryId
        {
            get { return _CategoryId; }
            set { _CategoryId = value; }
        }

        String _InitialActionTaken;
        public String InitialActionTaken
        {
            get { return _InitialActionTaken; }
            set { _InitialActionTaken = value; }
        }

        String _CorrectiveAction;
        public String CorrectiveAction
        {
            get { return _CorrectiveAction; }
            set { _CorrectiveAction = value; }
        }

        String _PreventiveAction;
        public String PreventiveAction
        {
            get { return _PreventiveAction; }
            set { _PreventiveAction = value; }
        }

        Int32 _ResponsiblePerson;
        public Int32 ResponsiblePerson
        {
            get { return _ResponsiblePerson; }
            set { _ResponsiblePerson = value; }
        }

        DateTime? _VerificationDate;
        public DateTime? VerificationDate
        {
            get { return _VerificationDate; }
            set { _VerificationDate = value; }
        }

        Int32 _VerificationOutcomeId;
        public Int32 VerificationOutcomeId
        {
            get { return _VerificationOutcomeId; }
            set { _VerificationOutcomeId = value; }
        }

        Int32 _FollowupRequired;
        public Int32 FollowupRequired
        {
            get { return _FollowupRequired; }
            set { _FollowupRequired = value; }
        }

        DateTime? _FollowupDate;
        public DateTime? FollowupDate
        {
            get { return _FollowupDate; }
            set { _FollowupDate = value; }
        }

        String _Comments;
        public String Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }

        Int32 _StatusId;
        public Int32 StatusId
        {
            get { return _StatusId; }
            set { _StatusId = value; }
        }

        String _GroupBy;
        public String GroupBy
        {
            get { return _GroupBy; }
            set { _GroupBy = value; }
        }
    }

    public class BOLManageDealersRebate
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _DealerID;
        public Int32 DealerID
        {
            get { return _DealerID; }
            set { _DealerID = value; }
        }
        Int32 _DealerRebateID;
        public Int32 DealerRebateID
        {
            get { return _DealerRebateID; }
            set { _DealerRebateID = value; }
        }
        Decimal _SalesFrom;
        public Decimal SalesFrom
        {
            get { return _SalesFrom; }
            set { _SalesFrom = value; }
        }
        Decimal _SalesTo;
        public Decimal SalesTo
        {
            get { return _SalesTo; }
            set { _SalesTo = value; }
        }
        Decimal _Percent;
        public Decimal Percent
        {
            get { return _Percent; }
            set { _Percent = value; }
        }
        DateTime? _EffectiveDate;
        public DateTime? EffectiveDate
        {
            get { return _EffectiveDate; }
            set { _EffectiveDate = value; }
        }

        String _Calculated;
        public String Calculated
        {
            get { return _Calculated; }
            set { _Calculated = value; }
        }
    }

    public class BOLManageCompanyOfficeDepartment
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _OfficeID;
        public Int32 OfficeID
        {
            get { return _OfficeID; }
            set { _OfficeID = value; }
        }
        Int32 _DepartmentID;
        public Int32 DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }
        String _Department;
        public String Department
        {
            get { return _Department; }
            set { _Department = value; }
        }
        Boolean? _IsActive;
        public Boolean? IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
    }

    public class BOLManageExtensions
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _SearchVar;
        public String SearchVar
        {
            get { return _SearchVar; }
            set { _SearchVar = value; }
        }
        Int32 _EmployeeDetailID;
        public Int32 EmployeeDetailID
        {
            get { return _EmployeeDetailID; }
            set { _EmployeeDetailID = value; }
        }
        Int32 _CompanyID;
        public Int32 CompanyID
        {
            get { return _CompanyID; }
            set { _CompanyID = value; }
        }
        Int32 _CompanyOfficeID;
        public Int32 CompanyOfficeID
        {
            get { return _CompanyOfficeID; }
            set { _CompanyOfficeID = value; }
        }
        Int32 _CompanyOfficeDepartmentID;
        public Int32 CompanyOfficeDepartmentID
        {
            get { return _CompanyOfficeDepartmentID; }
            set { _CompanyOfficeDepartmentID = value; }
        }
        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
    }

    public class BOLITWSize
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Boolean _Active;
        public Boolean Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        Int32 _Category;
        public Int32 Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        String _Size;
        public String Size
        {
            get { return _Size; }
            set { _Size = value; }
        }
    }

    public class BOLITWCategory
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Boolean _OptionsApplicable;
        public Boolean OptionsApplicable
        {
            get { return _OptionsApplicable; }
            set { _OptionsApplicable = value; }
        }

        String _Category;
        public String Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        Boolean _Active;
        public Boolean Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
    }

    public class BOLExtensions
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _CompanyID;
        public Int32 CompanyID
        {
            get { return _CompanyID; }
            set { _CompanyID = value; }
        }

        Int32 _OfficeID;
        public Int32 OfficeID
        {
            get { return _OfficeID; }
            set { _OfficeID = value; }
        }

        Int32 _DepartmentID;
        public Int32 DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }

        Int32 _EmployeeDetailID;
        public Int32 EmployeeDetailID
        {
            get { return _EmployeeDetailID; }
            set { _EmployeeDetailID = value; }
        }

        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        Int32 _Extension;
        public Int32 Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }

        String _FirstName;
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        String _LastName;
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        String _Abbreviation;
        public String Abbreviation
        {
            get { return _Abbreviation; }
            set { _Abbreviation = value; }
        }

        String _Direct;
        public String Direct
        {
            get { return _Direct; }
            set { _Direct = value; }
        }

        String _CellNumber;
        public String CellNumber
        {
            get { return _CellNumber; }
            set { _CellNumber = value; }
        }

        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        Boolean _Active;
        public Boolean Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        Boolean _ShowExt;
        public Boolean ShowExt
        {
            get { return _ShowExt; }
            set { _ShowExt = value; }
        }
    }

    public class BOLAddMenu
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _MenuID;
        public Int32 MenuID
        {
            get { return _MenuID; }
            set { _MenuID = value; }
        }
        String _Name;
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        String _Description;
        public String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        String _Url;
        public String Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        Int32 _ParentID;
        public Int32 ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }
        Int32 _Status;
        public Int32 Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        Int32 _SortOrder;
        public Int32 SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }
    }

    public class BOLDailyPurchaseRequester
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        String _FirstName;
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        String _LastName;
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        Int32 _Active;
        public Int32 Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
    }

    public class BOLPurchaseHistoryDetails
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _SearchVar;
        public String SearchVar
        {
            get { return _SearchVar; }
            set { _SearchVar = value; }
        }
        DateTime? _ShipDateFrom;
        public DateTime? ShipDateFrom
        {
            get { return _ShipDateFrom; }
            set { _ShipDateFrom = value; }
        }
        DateTime? _ShipDateTo;
        public DateTime? ShipDateTo
        {
            get { return _ShipDateTo; }
            set { _ShipDateTo = value; }
        }
    }

    public class BOLPurchaseHistory
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _SearchVar;
        public String SearchVar
        {
            get { return _SearchVar; }
            set { _SearchVar = value; }
        }

    }

    public class BOLTrackContainerJobs
    {
        Int32 _ProjectManagerID;
        public Int32 ProjectManagerID
        {
            get { return _ProjectManagerID; }
            set { _ProjectManagerID = value; }
        }
    }

    public class BOLShipmentReport
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        String _SearchVar;
        public String SearchVar
        {
            get { return _SearchVar; }
            set { _SearchVar = value; }
        }
    }

    public class BOLForecastingMonthlyEmailData
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
    }

    public class BOLDailyPurchaseParts
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        String _PartNumber;
        public String PartNumber
        {
            get { return _PartNumber; }
            set { _PartNumber = value; }
        }

        String _PartDescription;
        public String PartDescription
        {
            get { return _PartDescription; }
            set { _PartDescription = value; }
        }

        Int32 _UM;
        public Int32 UM
        {
            get { return _UM; }
            set { _UM = value; }
        }

        Int32 _MinOrderQty;
        public Int32 MinOrderQty
        {
            get { return _MinOrderQty; }
            set { _MinOrderQty = value; }
        }

        Int32 _MaxStockQty;
        public Int32 MaxStockQty
        {
            get { return _MaxStockQty; }
            set { _MaxStockQty = value; }
        }

        Int32 _ReOrderPoint;
        public Int32 ReOrderPoint
        {
            get { return _ReOrderPoint; }
            set { _ReOrderPoint = value; }
        }

        Int32 _LeadTimeDays;
        public Int32 LeadTimeDays
        {
            get { return _LeadTimeDays; }
            set { _LeadTimeDays = value; }
        }

        Int32 _PreferredVendorID;
        public Int32 PreferredVendorID
        {
            get { return _PreferredVendorID; }
            set { _PreferredVendorID = value; }
        }

        Int32 _ProductLine;
        public Int32 ProductLine
        {
            get { return _ProductLine; }
            set { _ProductLine = value; }
        }

        Decimal _UnitPrice;
        public Decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        Int32 _SortOrder;
        public Int32 SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }
    }

    public class BOLDailyPurchase
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        string _PONo;
        public string PONo
        {
            get { return _PONo; }
            set { _PONo = value; }
        }

        Int32 _Id;
        public Int32 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        Int32 _DailyPurchaseId;
        public Int32 DailyPurchaseId
        {
            get { return _DailyPurchaseId; }
            set { _DailyPurchaseId = value; }
        }

        Int32 _VendorId;
        public Int32 VendorId
        {
            get { return _VendorId; }
            set { _VendorId = value; }
        }

        Int32 _PartId;
        public Int32 PartId
        {
            get { return _PartId; }
            set { _PartId = value; }
        }

        Int32 _RequesterId;
        public Int32 RequesterId
        {
            get { return _RequesterId; }
            set { _RequesterId = value; }
        }

        Int32 _ProjectId;
        public Int32 ProjectId
        {
            get { return _ProjectId; }
            set { _ProjectId = value; }
        }

        String _DepartmentId;
        public String DepartmentId
        {
            get { return _DepartmentId; }
            set { _DepartmentId = value; }
        }

        string _Department;
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        Int32 _OrderQty;
        public Int32 OrderQty
        {
            get { return _OrderQty; }
            set { _OrderQty = value; }
        }

        Int32 _ReceivedQty;
        public Int32 ReceivedQty
        {
            get { return _ReceivedQty; }
            set { _ReceivedQty = value; }
        }

        Decimal _UnitPrice;
        public Decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        Decimal _TotalCost;
        public Decimal TotalCost
        {
            get { return _TotalCost; }
            set { _TotalCost = value; }
        }

        Int32 _UM;
        public Int32 UM
        {
            get { return _UM; }
            set { _UM = value; }
        }

        DateTime? _OrderDate;
        public DateTime? OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }

        string _OrderStatus;
        public string OrderStatus
        {
            get { return _OrderStatus; }
            set { _OrderStatus = value; }
        }

        DateTime? _ETA;
        public DateTime? ETA
        {
            get { return _ETA; }
            set { _ETA = value; }
        }

        DateTime? _ReceivedDate;
        public DateTime? ReceivedDate
        {
            get { return _ReceivedDate; }
            set { _ReceivedDate = value; }
        }

        string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
    }

    public class BOLSalesActivity
    {
        string _RegionalIndustryUpdates;
        public string RegionalIndustryUpdates
        {
            get { return _RegionalIndustryUpdates; }
            set { _RegionalIndustryUpdates = value; }
        }

        string _TypeOfContact;
        public string TypeOfContact
        {
            get { return _TypeOfContact; }
            set { _TypeOfContact = value; }
        }

        string _PNumber;
        public string PNumber
        {
            get { return _PNumber; }
            set { _PNumber = value; }
        }

        string _ProjectName;
        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }

        DateTime? _NextFollowupDate;
        public DateTime? NextFollowupDate
        {
            get { return _NextFollowupDate; }
            set { _NextFollowupDate = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        Int32 _UserID;
        public Int32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        Int32 _StakeHolderId;
        public Int32 StakeHolderId
        {
            get { return _StakeHolderId; }
            set { _StakeHolderId = value; }
        }

        Int32 _CompanyId;
        public Int32 CompanyId
        {
            get { return _CompanyId; }
            set { _CompanyId = value; }
        }

        Int32 _ActivityId;
        public Int32 ActivityId
        {
            get { return _ActivityId; }
            set { _ActivityId = value; }
        }

        DateTime? _Date;
        public DateTime? Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        DateTime? _Date1;
        public DateTime? Date1
        {
            get { return _Date1; }
            set { _Date1 = value; }
        }

        String _Objective;
        public String Objective
        {
            get { return _Objective; }
            set { _Objective = value; }
        }

        String _Outcome;
        public String Outcome
        {
            get { return _Outcome; }
            set { _Outcome = value; }
        }

        Int32 _ActivityDetailId;
        public Int32 ActivityDetailId
        {
            get { return _ActivityDetailId; }
            set { _ActivityDetailId = value; }
        }

        String _Task;
        public String Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        Int32 _ResponsiblePerson;
        public Int32 ResponsiblePerson
        {
            get { return _ResponsiblePerson; }
            set { _ResponsiblePerson = value; }
        }

        string _Deadline;
        public string Deadline
        {
            get { return _Deadline; }
            set { _Deadline = value; }
        }

        Int32 _Status;
        public Int32 Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        String _Destination;
        public String Destination
        {
            get { return _Destination; }
            set { _Destination = value; }
        }

        String _Purpose;
        public String Purpose
        {
            get { return _Purpose; }
            set { _Purpose = value; }
        }
    }

    public class BOLBindEmailAddress
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _group;
        public String group
        {
            get { return _group; }
            set { _group = value; }
        }
        String _displayNameFilter;
        public String displayNameFilter
        {
            get { return _displayNameFilter; }
            set { _displayNameFilter = value; }
        }
        String _formName;
        public String formName
        {
            get { return _formName; }
            set { _formName = value; }
        }
        //emailType
        String _emailType;
        public String emailType
        {
            get { return _emailType; }
            set { _emailType = value; }
        }
        String _formOperation;
        public String formOperation
        {
            get { return _formOperation; }
            set { _formOperation = value; }
        }

    }

    public class BOLReportDashboard
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _searchvar;
        public String searchvar
        {
            get { return _searchvar; }
            set { _searchvar = value; }
        }

        Int32 _ProductLine;
        public Int32 ProductLine
        {
            get { return _ProductLine; }
            set { _ProductLine = value; }
        }
        Int32 _ReportTypeID;
        public Int32 ReportTypeID
        {
            get { return _ReportTypeID; }
            set { _ReportTypeID = value; }
        }
    }

    public class BOLStockInHandAdjustment
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _ContainerID;
        public Int32 ContainerID
        {
            get { return _ContainerID; }
            set { _ContainerID = value; }
        }
        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        Int32 _SourceID;
        public Int32 SourceID
        {
            get { return _SourceID; }
            set { _SourceID = value; }
        }
        DataTable _TempDataStockInHand;
        public DataTable TempDataStockInHand
        {
            get { return _TempDataStockInHand; }
            set { _TempDataStockInHand = value; }
        }
    }

    public class BOLStockInDashboard
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }

    public class BOLPostInstallFollowups
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        DateTime? _FromDate;
        public DateTime? FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        DateTime? _ToDate;
        public DateTime? ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }

        string _JobID;
        public string JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        string _FollowupWith;
        public string FollowupWith
        {
            get { return _FollowupWith; }
            set { _FollowupWith = value; }
        }

        DateTime? _FollowupDate;
        public DateTime? FollowupDate
        {
            get { return _FollowupDate; }
            set { _FollowupDate = value; }
        }

        DateTime? _ScheduledFollowupDate;
        public DateTime? ScheduledFollowupDate
        {
            get { return _ScheduledFollowupDate; }
            set { _ScheduledFollowupDate = value; }
        }

        string _Notes;
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        string _FollowupType;
        public string FollowupType
        {
            get { return _FollowupType; }
            set { _FollowupType = value; }
        }
    }

    public class BOLForecastingModelSizeMapping
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        string _Size;
        public string Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        Int32 _ModelID;
        public Int32 ModelID
        {
            get { return _ModelID; }
            set { _ModelID = value; }
        }

        Int32 _TypeID;
        public Int32 TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }

        Int32 _SizeID;
        public Int32 SizeID
        {
            get { return _SizeID; }
            set { _SizeID = value; }
        }

        Int32 _IsActive;
        public Int32 IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
    }

    public class BOLForecastingModelPartMapping
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ModelID;
        public Int32 ModelID
        {
            get { return _ModelID; }
            set { _ModelID = value; }
        }

        Int32 _TypeID;
        public Int32 TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }

        Int32 _SizeID;
        public Int32 SizeID
        {
            get { return _SizeID; }
            set { _SizeID = value; }
        }

        Int32 _ParentPartID;
        public Int32 ParentPartID
        {
            get { return _ParentPartID; }
            set { _ParentPartID = value; }
        }

        Int32 _ChildPartID;
        public Int32 ChildPartID
        {
            get { return _ChildPartID; }
            set { _ChildPartID = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        Decimal _Qty;
        public Decimal Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }

        Int32 _IsActive;
        public Int32 IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        Int32 _IsBackendEntry;
        public Int32 IsBackendEntry
        {
            get { return _IsBackendEntry; }
            set { _IsBackendEntry = value; }
        }
    }

    public class BOLForecastingModelTypeMapping
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        string _Type;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        string _TypeDesc;
        public string TypeDesc
        {
            get { return _TypeDesc; }
            set { _TypeDesc = value; }
        }

        Int32 _ModelID;
        public Int32 ModelID
        {
            get { return _ModelID; }
            set { _ModelID = value; }
        }

        Int32 _TypeID;
        public Int32 TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }

        Int32 _IsActive;
        public Int32 IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
    }

    public class BOLForecastingJobModels
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        string _JobID;
        public string JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }

        Int32 _UserID;
        public Int32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        Int32 _AWProductSubID;
        public Int32 AWProductSubID
        {
            get { return _AWProductSubID; }
            set { _AWProductSubID = value; }
        }

        Int32 _SizeID;
        public Int32 SizeID
        {
            get { return _SizeID; }
            set { _SizeID = value; }
        }

        Int32 _ProjectsID;
        public Int32 ProjectsID
        {
            get { return _ProjectsID; }
            set { _ProjectsID = value; }
        }

        Int32 _ParentPartID;
        public Int32 ParentPartID
        {
            get { return _ParentPartID; }
            set { _ParentPartID = value; }
        }

        Decimal _Qty;
        public Decimal Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }

    public class BOLEmployeeMaintain
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        //EmployeeID
        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        //Branch
        String _Branch;
        public String Branch
        {
            get { return _Branch; }
            set { _Branch = value; }
        }

        String _FirstName;
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        String _LastName;
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        String _UserName;
        public String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        String _Password;
        public String Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        String _Address;
        public String Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        String _Department;
        public String Department
        {
            get { return _Department; }
            set { _Department = value; }
        }
        Int32 _CountryId;
        public Int32 CountryId
        {
            get { return _CountryId; }
            set { _CountryId = value; }
        }
        String _StateOrProvince;
        public String StateOrProvince
        {
            get { return _StateOrProvince; }
            set { _StateOrProvince = value; }
        }
        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
        String _PostalCode;
        public String PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }
        String _HomePhone;
        public String HomePhone
        {
            get { return _HomePhone; }
            set { _HomePhone = value; }
        }
        String _OfficeExtension;
        public String OfficeExtension
        {
            get { return _OfficeExtension; }
            set { _OfficeExtension = value; }
        }
        String _CellPhone;
        public String CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
        Boolean _Status;
        public Boolean Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        String _Abbrivation;
        public String Abbrivation
        {
            get { return _Abbrivation; }
            set { _Abbrivation = value; }
        }
        DateTime? _DOB;
        public DateTime? DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }
        Int32 _EngDepID;
        public Int32 EngDepID
        {
            get { return _EngDepID; }
            set { _EngDepID = value; }
        }
        Int32 _DivisionID;
        public Int32 DivisionID
        {
            get { return _DivisionID; }
            set { _DivisionID = value; }
        }
        String _Notes;
        public String Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        Boolean _Full;
        public Boolean Full
        {
            get { return _Full; }
            set { _Full = value; }
        }

        Boolean _Half;
        public Boolean Half
        {
            get { return _Half; }
            set { _Half = value; }
        }

        Boolean _ViewandMinimum;
        public Boolean ViewandMinimum
        {
            get { return _ViewandMinimum; }
            set { _ViewandMinimum = value; }
        }

        Boolean _Restrict;
        public Boolean Restrict
        {
            get { return _Restrict; }
            set { _Restrict = value; }
        }

        Boolean _ViewOnly;
        public Boolean ViewOnly
        {
            get { return _ViewOnly; }
            set { _ViewOnly = value; }
        }
    }
    //Customer Care Forms
    public class BOLCustCareRepairForm
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _TJobID;
        public String TJobID
        {
            get { return _TJobID; }
            set { _TJobID = value; }
        }
        String _TicketNo;
        public String TicketNo
        {
            get { return _TicketNo; }
            set { _TicketNo = value; }
        }
        String _Task;
        public String Task
        {
            get { return _Task; }
            set { _Task = value; }
        }
        String _Issue;
        public String Issue
        {
            get { return _Issue; }
            set { _Issue = value; }
        }
        DateTime? _IssueOpenDate;
        public DateTime? IssueOpenDate
        {
            get { return _IssueOpenDate; }
            set { _IssueOpenDate = value; }
        }
        DateTime? _PromisedDate;
        public DateTime? PromisedDate
        {
            get { return _PromisedDate; }
            set { _PromisedDate = value; }
        }
        DateTime? _IssueCloseDate;
        public DateTime? IssueCloseDate
        {
            get { return _IssueCloseDate; }
            set { _IssueCloseDate = value; }
        }
        String _Status;
        public String Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        String _AssignTo;
        public String AssignTo
        {
            get { return _AssignTo; }
            set { _AssignTo = value; }
        }
        DateTime? _FollowUpDate;
        public DateTime? FollowUpDate
        {
            get { return _FollowUpDate; }
            set { _FollowUpDate = value; }
        }
        String _ServicePO;
        public String ServicePO
        {
            get { return _ServicePO; }
            set { _ServicePO = value; }
        }
        Int32 _HobartServiceBranch;
        public Int32 HobartServiceBranch
        {
            get { return _HobartServiceBranch; }
            set { _HobartServiceBranch = value; }
        }
    }

    public class BOLSiteVisitInformation
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        string _PNumber;
        public string PNumber
        {
            get { return _PNumber; }
            set { _PNumber = value; }
        }

        Int32 _PurposeID;
        public Int32 PurposeID
        {
            get { return _PurposeID; }
            set { _PurposeID = value; }
        }

        Int32 _RegionID;
        public Int32 RegionID
        {
            get { return _RegionID; }
            set { _RegionID = value; }
        }

        string _SiteAddress;
        public string SiteAddress
        {
            get { return _SiteAddress; }
            set { _SiteAddress = value; }
        }

        Int32 _CountryID;
        public Int32 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        Int32 _StateID;
        public Int32 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }

        string _City;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        DateTime? _SiteVisitDate;
        public DateTime? SiteVisitDate
        {
            get { return _SiteVisitDate; }
            set { _SiteVisitDate = value; }
        }

        DateTime? _NextVisitDate;
        public DateTime? NextVisitDate
        {
            get { return _NextVisitDate; }
            set { _NextVisitDate = value; }
        }

        string _SiteContactName;
        public string SiteContactName
        {
            get { return _SiteContactName; }
            set { _SiteContactName = value; }
        }

        string _SiteContactNumber;
        public string SiteContactNumber
        {
            get { return _SiteContactNumber; }
            set { _SiteContactNumber = value; }
        }

        string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        string _EmployeeIDs;
        public string EmployeeIDs
        {
            get { return _EmployeeIDs; }
            set { _EmployeeIDs = value; }
        }

        bool _SameAsProjectLocation;
        public bool SameAsProjectLocation
        {
            get { return _SameAsProjectLocation; }
            set { _SameAsProjectLocation = value; }
        }
        Int32 _RequestorID;
        public Int32 RequestorID
        {
            get { return _RequestorID; }
            set { _RequestorID = value; }
        }
    }

    public class BOLAppSetting
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }

    //Customer Care Manage Tickets
    public class BOLManageTickets
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        String _TicketNo;
        public String TicketNo
        {
            get { return _TicketNo; }
            set { _TicketNo = value; }
        }

        String _RepairID;
        public String RepairID
        {
            get { return _RepairID; }
            set { _RepairID = value; }
        }
        Int32 _id;
        public Int32 id
        {
            get { return _id; }
            set { _id = value; }
        }
        DateTime? _SummDate;
        public DateTime? SummDate
        {
            get { return _SummDate; }
            set { _SummDate = value; }
        }
        String _Summary;
        public String Summary
        {
            get { return _Summary; }
            set { _Summary = value; }
        }
    }
    public class BOLWasteEq_New
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _id;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        Int32 _ManufacturerId;
        public Int32 ManufacturerId
        {
            get { return _ManufacturerId; }
            set { _ManufacturerId = value; }
        }

        Int32 _WasteEqId;
        public Int32 WasteEqId
        {
            get { return _WasteEqId; }
            set { _WasteEqId = value; }
        }

        Int32 _AccessoryId;
        public Int32 AccessoryId
        {
            get { return _AccessoryId; }
            set { _AccessoryId = value; }
        }

        String _UsedFromStock;
        public String UsedFromStock
        {
            get { return _UsedFromStock; }
            set { _UsedFromStock = value; }
        }

        String _JobID;
        public String JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }

        String _TrackingNo;
        public String TrackingNo
        {
            get { return _TrackingNo; }
            set { _TrackingNo = value; }
        }

        String _ServiceProvider;
        public String ServiceProvider
        {
            get { return _ServiceProvider; }
            set { _ServiceProvider = value; }
        }

        DateTime? _EstimatedDeliveryDate;
        public DateTime? EstimatedDeliveryDate
        {
            get { return _EstimatedDeliveryDate; }
            set { _EstimatedDeliveryDate = value; }
        }

        DateTime? _RequestedByShop;
        public DateTime? RequestedByShop
        {
            get { return _RequestedByShop; }
            set { _RequestedByShop = value; }
        }

        DateTime? _ReceivedDate;
        public DateTime? ReceivedDate
        {
            get { return _ReceivedDate; }
            set { _ReceivedDate = value; }
        }

        String _Remarks;
        public String Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        Int32 _EmployeeId;
        public Int32 EmployeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }
    }

    //Wsste Eq Details
    //Wsste Eq Details
    public class BOLWasteEq
    {
        DateTime? _estimatecomplitiondate;
        public DateTime? estimatecomplitiondate
        {
            get { return _estimatecomplitiondate; }
            set { _estimatecomplitiondate = value; }
        }

        DateTime? _requestondate;
        public DateTime? requestondate
        {
            get { return _requestondate; }
            set { _requestondate = value; }
        }

        String _TrackingNo;
        public String TrackingNo
        {
            get { return _TrackingNo; }
            set { _TrackingNo = value; }
        }
        //estimatdeliverydate

        DateTime? _estimatdeliverydate;
        public DateTime? estimatdeliverydate
        {
            get { return _estimatdeliverydate; }
            set { _estimatdeliverydate = value; }
        }

        String _requestonshopon;
        public String requestonshopon
        {
            get { return _requestonshopon; }
            set { _requestonshopon = value; }
        }

        Int32 _Status;
        public Int32 Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        Int32 _Employeeid;
        public Int32 Employeeid
        {
            get { return _Employeeid; }
            set { _Employeeid = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _JobID;
        public String JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }
        Int32 _Detailid;
        public Int32 Detailid
        {
            get { return _Detailid; }
            set { _Detailid = value; }
        }




        Int32 _WasteEq_id;
        public Int32 WasteEq_id
        {
            get { return _WasteEq_id; }
            set { _WasteEq_id = value; }
        }
        Int32 _makerid;
        public Int32 makerid
        {
            get { return _makerid; }
            set { _makerid = value; }
        }
        Int32 _eqid;
        public Int32 eqid
        {
            get { return _eqid; }
            set { _eqid = value; }
        }
        Int32 _accid;
        public Int32 accid
        {
            get { return _accid; }
            set { _accid = value; }
        }
        DateTime? _acc_recieved;
        public DateTime? acc_recieved
        {
            get { return _acc_recieved; }
            set { _acc_recieved = value; }
        }
        String _usedfromstock;
        public String usedfromstock
        {
            get { return _usedfromstock; }
            set { _usedfromstock = value; }
        }
        String _remarks;
        public String remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
        Int32 _id;
        public Int32 id
        {
            get { return _id; }
            set { _id = value; }
        }
    }

    public class BOLDealers
    {
        Int32 _Dealerid;
        public Int32 Dealerid
        {
            get { return _Dealerid; }
            set { _Dealerid = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLStockAdjustment
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _Opt;
        public String Opt
        {
            get { return _Opt; }
            set { _Opt = value; }
        }
        Int32 _Makerid;
        public Int32 Makerid
        {
            get { return _Makerid; }
            set { _Makerid = value; }
        }
        Int32 _WasteEqid;
        public Int32 WasteEqid
        {
            get { return _WasteEqid; }
            set { _WasteEqid = value; }
        }
        //StockAccid
        Int32 _StockAccid;
        public Int32 StockAccid
        {
            get { return _StockAccid; }
            set { _StockAccid = value; }
        }
        Int32 _manuf;
        public Int32 manuf
        {
            get { return _manuf; }
            set { _manuf = value; }
        }
        Int32 _wasteeq;
        public Int32 wasteeq
        {
            get { return _wasteeq; }
            set { _wasteeq = value; }
        }
        Int32 _accessory;
        public Int32 accessory
        {
            get { return _accessory; }
            set { _accessory = value; }
        }
        Int32 _stockinhand;
        public Int32 stockinhand
        {
            get { return _stockinhand; }
            set { _stockinhand = value; }
        }
        Int32 _stockin;
        public Int32 stockin
        {
            get { return _stockin; }
            set { _stockin = value; }
        }
        Int32 _stockinby;
        public Int32 stockinby
        {
            get { return _stockinby; }
            set { _stockinby = value; }
        }
        DateTime? _stockindate;
        public DateTime? stockindate
        {
            get { return _stockindate; }
            set { _stockindate = value; }
        }
        String _stockinoption;
        public String stockinoption
        {
            get { return _stockinoption; }
            set { _stockinoption = value; }
        }
        String _summary;
        public String summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
    }

    public class BOLRepActiveSales
    {
        Int32 _BranchID;
        public Int32 BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _FirstName;
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        String _LastName;
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        Int32 _AbbreviationID;
        public Int32 AbbreviationID
        {
            get { return _AbbreviationID; }
            set { _AbbreviationID = value; }
        }
        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        String _CellPhone;
        public String CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        Int32 _PhoneMail;
        public Int32 PhoneMail
        {
            get { return _PhoneMail; }
            set { _PhoneMail = value; }
        }
        String _Status;
        public String Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        Boolean _HomeOffice;
        public Boolean HomeOffice
        {
            get { return _HomeOffice; }
            set { _HomeOffice = value; }
        }
        String _HomeAddress;
        public String HomeAddress
        {
            get { return _HomeAddress; }
            set { _HomeAddress = value; }
        }
        String _HomeCity;
        public String HomeCity
        {
            get { return _HomeCity; }
            set { _HomeCity = value; }
        }
        String _HomeState;
        public String HomeState
        {
            get { return _HomeState; }
            set { _HomeState = value; }
        }
        String _HomePostalCode;
        public String HomePostalCode
        {
            get { return _HomePostalCode; }
            set { _HomePostalCode = value; }
        }
        String _HomePhone;
        public String HomePhone
        {
            get { return _HomePhone; }
            set { _HomePhone = value; }
        }
        String _HomeFax;
        public String HomeFax
        {
            get { return _HomeFax; }
            set { _HomeFax = value; }
        }
    }
    public class BOLException
    {
        Int32 _id;
        public Int32 id
        {
            get { return _id; }
            set { _id = value; }
        }
        Char _Action;
        public Char Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
        String _module_name;
        public String module_name
        {
            get { return _module_name; }
            set { _module_name = value; }
        }
        String _source;
        public String source
        {
            get { return _source; }
            set { _source = value; }
        }
        String _message;
        public String message
        {
            get { return _message; }
            set { _message = value; }
        }
        String _data;
        public String data
        {
            get { return _data; }
            set { _data = value; }
        }
        String _target_site;
        public String target_site
        {
            get { return _target_site; }
            set { _target_site = value; }
        }
        String _stack_trace;
        public String stack_trace
        {
            get { return _stack_trace; }
            set { _stack_trace = value; }
        }
        DateTime _date;
        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }
        Int32 _counts;
        public Int32 counts
        {
            get { return _counts; }
            set { _counts = value; }
        }

    }
    //START BOL
    public class BOLSalesRepGroup
    {
        String _companyname;
        public String companyname
        {
            get { return _companyname; }
            set { _companyname = value; }
        }

    }
    //START BOL Proposal Search Page
    public class BOLProposalSearch
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _country;
        public Int32 country
        {
            get { return _country; }
            set { _country = value; }
        }
        String _SearchVar;
        public String SearchVar
        {
            get { return _SearchVar; }
            set { _SearchVar = value; }
        }
        String _PNumber;
        public String PNumber
        {
            get { return _PNumber; }
            set { _PNumber = value; }
        }
        String _RepID;
        public String RepID
        {
            get { return _RepID; }
            set { _RepID = value; }
        }
        DateTime _FromDate;
        public DateTime FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
        DateTime _toDate;
        public DateTime toDate
        {
            get { return _toDate; }
            set { _toDate = value; }
        }
    }
    //Start BOL Project Search Page
    public class BOLProjectSearch
    {
        String _JobID;
        public String JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        //country
        Int32 _country;
        public Int32 country
        {
            get { return _country; }
            set { _country = value; }
        }
        String _SearchVar;
        public String SearchVar
        {
            get { return _SearchVar; }
            set { _SearchVar = value; }
        }
    }
    //Start BOL Shop Drawing    
    public class BOLShpDrg
    {
        String _sDrgNum;
        public String sDrgNum
        {
            get { return _sDrgNum; }
            set { _sDrgNum = value; }
        }
        String _sDrgJID;
        public String sDrgJID
        {
            get { return _sDrgJID; }
            set { _sDrgJID = value; }
        }
        DateTime? _sDrgSentToRCD;
        public DateTime? sDrgSentToRCD
        {
            get { return _sDrgSentToRCD; }
            set { _sDrgSentToRCD = value; }
        }
        DateTime? _sDrgWantDate;
        public DateTime? sDrgWantDate
        {
            get { return _sDrgWantDate; }
            set { _sDrgWantDate = value; }
        }
        DateTime? _sDrgPromiseDate;
        public DateTime? sDrgPromiseDate
        {
            get { return _sDrgPromiseDate; }
            set { _sDrgPromiseDate = value; }
        }
        DateTime? _sDrgExpecApprovalDate;
        public DateTime? sDrgExpecApprovalDate
        {
            get { return _sDrgExpecApprovalDate; }
            set { _sDrgExpecApprovalDate = value; }
        }
        DateTime? _sDrgAppDate;
        public DateTime? sDrgAppDate
        {
            get { return _sDrgAppDate; }
            set { _sDrgAppDate = value; }
        }
        DateTime? _sDateFollowedUp;
        public DateTime? sDateFollowedUp
        {
            get { return _sDateFollowedUp; }
            set { _sDateFollowedUp = value; }
        }
        DateTime? _sNextFolowupDate;
        public DateTime? sNextFolowupDate
        {
            get { return _sNextFolowupDate; }
            set { _sNextFolowupDate = value; }
        }

        //sDateReleasedToFab
        DateTime? _sDateReleasedToFab;
        public DateTime? sDateReleasedToFab
        {
            get { return _sDateReleasedToFab; }
            set { _sDateReleasedToFab = value; }
        }

        String _sDrgComment;
        public String sDrgComment
        {
            get { return _sDrgComment; }
            set { _sDrgComment = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _JobID;
        public String JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }
        Char _sReleasedTo;
        public Char sReleasedTo
        {
            get { return _sReleasedTo; }
            set { _sReleasedTo = value; }
        }
        DateTime? _sReleasedToFabDate;
        public DateTime? sReleasedToFabDate
        {
            get { return _sReleasedToFabDate; }
            set { _sReleasedToFabDate = value; }
        }
        DateTime? _sReleasedToShopDate;
        public DateTime? sReleasedToShopDate
        {
            get { return _sReleasedToShopDate; }
            set { _sReleasedToShopDate = value; }
        }
    }
    //End BOL Shop Drawing
    public class BOLMenu
    {
        Int32 _id;
        public Int32 id
        {
            get { return _id; }
            set { _id = value; }
        }
        String _name;
        public String name
        {
            get { return _name; }
            set { _name = value; }
        }
        String _description;
        public String description
        {
            get { return _description; }
            set { _description = value; }
        }
        String _url;
        public String url
        {
            get { return _url; }
            set { _url = value; }
        }
        Int32 _parent_id;
        public Int32 parent_id
        {
            get { return _parent_id; }
            set { _parent_id = value; }
        }
        Boolean _status;
        public Boolean status
        {
            get { return _status; }
            set { _status = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }

    // BLL For Customer Members
    public class BOLManageLogs
    {
        Int32 _userid;
        public Int32 userid
        {
            get { return _userid; }
            set { _userid = value; }
        }

        String _formname;
        public String formname
        {
            get { return _formname; }
            set { _formname = value; }
        }

        String _logoperation;
        public String logoperation
        {
            get { return _logoperation; }
            set { _logoperation = value; }
        }

        String _pk;
        public String pk
        {
            get { return _pk; }
            set { _pk = value; }
        }

        DateTime? _logdate;
        public DateTime? logdate
        {
            get { return _logdate; }
            set { _logdate = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }

    public class BOLManageProposals
    {
        Int32 _ProjectManagerid;
        public Int32 ProjectManagerid
        {
            get { return _ProjectManagerid; }
            set { _ProjectManagerid = value; }
        }


        String _FProposalNumber;
        public String FProposalNumber
        {
            get { return _FProposalNumber; }
            set { _FProposalNumber = value; }
        }

        DateTime? _FFollowUpDate;
        public DateTime? FFollowUpDate
        {
            get { return _FFollowUpDate; }
            set { _FFollowUpDate = value; }
        }

        DateTime? _FFollowedUpDate;
        public DateTime? FFollowedUpDate
        {
            get { return _FFollowedUpDate; }
            set { _FFollowedUpDate = value; }
        }

        DateTime? _FNextFollowedUpDate;
        public DateTime? FNextFollowedUpDate
        {
            get { return _FNextFollowedUpDate; }
            set { _FNextFollowedUpDate = value; }
        }
        DateTime? _FExpectedPOReceivedDate;
        public DateTime? FExpectedPOReceivedDate
        {
            get { return _FExpectedPOReceivedDate; }
            set { _FExpectedPOReceivedDate = value; }
        }

        Int32 _Followupid;
        public Int32 Followupid
        {
            get { return _Followupid; }
            set { _Followupid = value; }
        }

        String _FFollowUpWith;
        public String FFollowUpWith
        {
            get { return _FFollowUpWith; }
            set { _FFollowUpWith = value; }
        }

        String _FFollowUpNature;
        public String FFollowUpNature
        {
            get { return _FFollowUpNature; }
            set { _FFollowUpNature = value; }
        }

        String _FNotes;
        public String FNotes
        {
            get { return _FNotes; }
            set { _FNotes = value; }
        }
        Boolean _Fshowninreports;
        public Boolean Fshowninreports
        {
            get { return _Fshowninreports; }
            set { _Fshowninreports = value; }
        }


        Int32 _bidproject;
        public Int32 bidproject
        {
            get { return _bidproject; }
            set { _bidproject = value; }
        }

        Int32 _projectmanagerid;
        public Int32 projectmanagerid
        {
            get { return _projectmanagerid; }
            set { _projectmanagerid = value; }
        }

        Int32 _conveyorprimespec;
        public Int32 conveyorprimespec
        {
            get { return _conveyorprimespec; }
            set { _conveyorprimespec = value; }
        }

        String _conveyorprimespecother;
        public String conveyorprimespecother
        {
            get { return _conveyorprimespecother; }
            set { _conveyorprimespecother = value; }
        }

        Int32 _conveyoralternate;
        public Int32 conveyoralternate
        {
            get { return _conveyoralternate; }
            set { _conveyoralternate = value; }
        }

        //@dealermemberid
        Int32 _dealermemberid;
        public Int32 dealermemberid
        {
            get { return _dealermemberid; }
            set { _dealermemberid = value; }
        }

        Int32 _sourceleadid;
        public Int32 sourceleadid
        {
            get { return _sourceleadid; }
            set { _sourceleadid = value; }
        }

        Int32 _sourceleadref;
        public Int32 sourceleadref
        {
            get { return _sourceleadref; }
            set { _sourceleadref = value; }
        }

        Int32 _Industry;
        public Int32 Industry
        {
            get { return _Industry; }
            set { _Industry = value; }
        }

        String _conveyoralternateother;
        public String conveyoralternateother
        {
            get { return _conveyoralternateother; }
            set { _conveyoralternateother = value; }
        }

        DateTime? _shipdate;
        public DateTime? shipdate
        {
            get { return _shipdate; }
            set { _shipdate = value; }
        }

        DateTime? _biddate;
        public DateTime? biddate
        {
            get { return _biddate; }
            set { _biddate = value; }
        }

        //WasteEqTypeid
        Int32 _WasteEqTypeid;
        public Int32 WasteEqTypeid
        {
            get { return _WasteEqTypeid; }
            set { _WasteEqTypeid = value; }
        }

        Int32 _typeid;
        public Int32 typeid
        {
            get { return _typeid; }
            set { _typeid = value; }
        }

        DateTime? _DateofProposal;
        public DateTime? DateofProposal
        {
            get { return _DateofProposal; }
            set { _DateofProposal = value; }
        }
        String _JobType;
        public String JobType
        {
            get { return _JobType; }
            set { _JobType = value; }
        }
        String _ExistingJobID;
        public String ExistingJobID
        {
            get { return _ExistingJobID; }
            set { _ExistingJobID = value; }
        }
        Int32 _ConsultantMemberID;
        public Int32 ConsultantMemberID
        {
            get { return _ConsultantMemberID; }
            set { _ConsultantMemberID = value; }
        }
        String _PNumber;
        public String PNumber
        {
            get { return _PNumber; }
            set { _PNumber = value; }
        }
        String _ProjectName;
        public String ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }

        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
        Int32 _StateID;
        public Int32 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }

        double _Price;
        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        double? _Freight;
        public double? Freight
        {
            get { return _Freight; }
            set { _Freight = value; }
        }

        Double _Installation;
        public Double Installation
        {
            get { return _Installation; }
            set { _Installation = value; }
        }
        Int32 _CurrencyID;
        public Int32 CurrencyID
        {
            get { return _CurrencyID; }
            set { _CurrencyID = value; }
        }

        DateTime? _ProposalDate;
        public DateTime? ProposalDate
        {
            get { return _ProposalDate; }
            set { _ProposalDate = value; }
        }
        Boolean _QuoteRequired;
        public Boolean QuoteRequired
        {
            get { return _QuoteRequired; }
            set { _QuoteRequired = value; }
        }
        Boolean _DrqRequired;
        public Boolean DrqRequired
        {
            get { return _DrqRequired; }
            set { _DrqRequired = value; }
        }
        Boolean _HobartIssTag;
        public Boolean HobartIssTag
        {
            get { return _HobartIssTag; }
            set { _HobartIssTag = value; }
        }
        Boolean _QuoteSTERO;
        public Boolean QuoteSTERO
        {
            get { return _QuoteSTERO; }
            set { _QuoteSTERO = value; }
        }
        String _QuoteID;
        public String QuoteID
        {
            get { return _QuoteID; }
            set { _QuoteID = value; }
        }
        DateTime? _QuoteReqDate;
        public DateTime? QuoteReqDate
        {
            get { return _QuoteReqDate; }
            set { _QuoteReqDate = value; }
        }
        DateTime? _QuoteAckDate;
        public DateTime? QuoteAckDate
        {
            get { return _QuoteAckDate; }
            set { _QuoteAckDate = value; }
        }
        DateTime? _QuotePrepDate;
        public DateTime? QuotePrepDate
        {
            get { return _QuotePrepDate; }
            set { _QuotePrepDate = value; }
        }
        DateTime? _QuoteSentDate;
        public DateTime? QuoteSentDate
        {
            get { return _QuoteSentDate; }
            set { _QuoteSentDate = value; }
        }
        String _ShpDrgNum;
        public String ShpDrgNum
        {
            get { return _ShpDrgNum; }
            set { _ShpDrgNum = value; }
        }
        Int32 _ProjectDesignerID;
        public Int32 ProjectDesignerID
        {
            get { return _ProjectDesignerID; }
            set { _ProjectDesignerID = value; }
        }

        Int32 _OriginRepID;
        public Int32 OriginRepID
        {
            get { return _OriginRepID; }
            set { _OriginRepID = value; }
        }
        Int32 _ConsultRepID;
        public Int32 ConsultRepID
        {
            get { return _ConsultRepID; }
            set { _ConsultRepID = value; }
        }

        Int32 _InitialRepId;
        public Int32 InitialRepId
        {
            get { return _InitialRepId; }
            set { _InitialRepId = value; }
        }
        Int32 _RepID;
        public Int32 RepID
        {
            get { return _RepID; }
            set { _RepID = value; }
        }
        Int32 _ModelID;
        public Int32 ModelID
        {
            get { return _ModelID; }
            set { _ModelID = value; }
        }
        Int32 _ConveyorTypeID;
        public Int32 ConveyorTypeID
        {
            get { return _ConveyorTypeID; }
            set { _ConveyorTypeID = value; }
        }

        Int32 _PrimeSpec;
        public Int32 PrimeSpec
        {
            get { return _PrimeSpec; }
            set { _PrimeSpec = value; }
        }
        Boolean _Specifications;
        public Boolean Specifications
        {
            get { return _Specifications; }
            set { _Specifications = value; }
        }
        Boolean _DetailedQuote;
        public Boolean DetailedQuote
        {
            get { return _DetailedQuote; }
            set { _DetailedQuote = value; }
        }
        Int32 _OrderProbabilityID;
        public Int32 OrderProbabilityID
        {
            get { return _OrderProbabilityID; }
            set { _OrderProbabilityID = value; }
        }

        Int32 _SalesCategoryID;
        public Int32 SalesCategoryID
        {
            get { return _SalesCategoryID; }
            set { _SalesCategoryID = value; }
        }
        DateTime? _EstimatedEquipmentWantDate;
        public DateTime? EstimatedEquipmentWantDate
        {
            get { return _EstimatedEquipmentWantDate; }
            set { _EstimatedEquipmentWantDate = value; }
        }
        Int32 _ConsultantID;
        public Int32 ConsultantID
        {
            get { return _ConsultantID; }
            set { _ConsultantID = value; }
        }

        Int32 _DealerID;
        public Int32 DealerID
        {
            get { return _DealerID; }
            set { _DealerID = value; }
        }
        String _Notes;
        public String Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        String _Compitetor;
        public String Compitetor
        {
            get { return _Compitetor; }
            set { _Compitetor = value; }
        }
        String _LostedReason;
        public String LostedReason
        {
            get { return _LostedReason; }
            set { _LostedReason = value; }
        }
        String _CurrentStatus;
        public String CurrentStatus
        {
            get { return _CurrentStatus; }
            set { _CurrentStatus = value; }
        }
        String _Country;
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        Boolean _DPics;
        public Boolean DPics
        {
            get { return _DPics; }
            set { _DPics = value; }
        }
        Boolean _RefDrawing;
        public Boolean RefDrawing
        {
            get { return _RefDrawing; }
            set { _RefDrawing = value; }
        }
        Double _EqDiscount;
        public Double EqDiscount
        {
            get { return _EqDiscount; }
            set { _EqDiscount = value; }
        }
        Double _EqDisAmount;
        public Double EqDisAmount
        {
            get { return _EqDisAmount; }
            set { _EqDisAmount = value; }
        }

        Double _NetEqPrice;
        public Double NetEqPrice
        {
            get { return _NetEqPrice; }
            set { _NetEqPrice = value; }
        }
        String _SiteFloor;
        public String SiteFloor
        {
            get { return _SiteFloor; }
            set { _SiteFloor = value; }
        }
        Boolean _DoorOpen;
        public Boolean DoorOpen
        {
            get { return _DoorOpen; }
            set { _DoorOpen = value; }
        }
        Double _Width;
        public Double Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        Double _Height;
        public Double Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        Double _Depth;
        public Double Depth
        {
            get { return _Depth; }
            set { _Depth = value; }
        }
        String _Comment;
        public String Comment
        {
            get { return _Comment; }
            set { _Comment = value; }
        }
        Int32 _PreparedBy;
        public Int32 PreparedBy
        {
            get { return _PreparedBy; }
            set { _PreparedBy = value; }
        }
        Boolean _IsGillProject;
        public Boolean IsGillProject
        {
            get { return _IsGillProject; }
            set { _IsGillProject = value; }
        }
        Int32? _SpecCredits;
        public Int32? SpecCredits
        {
            get { return _SpecCredits; }
            set { _SpecCredits = value; }
        }
        Int32 _SpecCreditPercentID;
        public Int32 SpecCreditPercentID
        {
            get { return _SpecCreditPercentID; }
            set { _SpecCreditPercentID = value; }
        }

        Double _SpecCreditAmount;
        public Double SpecCreditAmount
        {
            get { return _SpecCreditAmount; }
            set { _SpecCreditAmount = value; }
        }
        String _SpecCreditCheckNo;
        public String SpecCreditCheckNo
        {
            get { return _SpecCreditCheckNo; }
            set { _SpecCreditCheckNo = value; }
        }

        DateTime? _SpecCreditPaidDate;
        public DateTime? SpecCreditPaidDate
        {
            get { return _SpecCreditPaidDate; }
            set { _SpecCreditPaidDate = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _OrderBelongsTo;
        public Int32 OrderBelongsTo
        {
            get { return _OrderBelongsTo; }
            set { _OrderBelongsTo = value; }
        }
        String _alternate1;
        public String alternate1
        {
            get { return _alternate1; }
            set { _alternate1 = value; }

        }
        String _alternate2;
        public String alternate2
        {
            get { return _alternate2; }
            set { _alternate2 = value; }

        }
        String _alternate3;
        public String alternate3
        {
            get { return _alternate3; }
            set { _alternate3 = value; }

        }
        Int32 _dishwasherprimespec;
        public Int32 dishwasherprimespec
        {
            get { return _dishwasherprimespec; }
            set { _dishwasherprimespec = value; }
        }
        String _dishwasherprimespecother;
        public String dishwasherprimespecother
        {
            get { return _dishwasherprimespecother; }
            set { _dishwasherprimespecother = value; }
        }
        Int32 _dishmachinetype;
        public Int32 dishmachinetype
        {
            get { return _dishmachinetype; }
            set { _dishmachinetype = value; }
        }
        String _dishmachinetypeother;
        public String dishmachinetypeother
        {
            get { return _dishmachinetypeother; }
            set { _dishmachinetypeother = value; }
        }
        Int32 _dishmachinemodel;
        public Int32 dishmachinemodel
        {
            get { return _dishmachinemodel; }
            set { _dishmachinemodel = value; }
        }
        String _dishwashermodelother;
        public String dishwashermodelother
        {
            get { return _dishwashermodelother; }
            set { _dishwashermodelother = value; }
        }
        Int32 _dishmachinestyle;
        public Int32 dishmachinestyle
        {
            get { return _dishmachinestyle; }
            set { _dishmachinestyle = value; }
        }
        String _dishmachinestyleother;
        public String dishmachinestyleother
        {
            get { return _dishmachinestyleother; }
            set { _dishmachinestyleother = value; }
        }
        Int32 _ddishwasheralternate;
        public Int32 dishwasheralternate
        {
            get { return _ddishwasheralternate; }
            set { _ddishwasheralternate = value; }
        }
        String _dishwasheralternateother;
        public String dishwasheralternateother
        {
            get { return _dishwasheralternateother; }
            set { _dishwasheralternateother = value; }
        }
        Int32 _dishmachinetypealternate;
        public Int32 dishmachinetypealternate
        {
            get { return _dishmachinetypealternate; }
            set { _dishmachinetypealternate = value; }
        }
        String _dishmachinetypealternateother;
        public String dishmachinetypealternateother
        {
            get { return _dishmachinetypealternateother; }
            set { _dishmachinetypealternateother = value; }
        }
        Int32 _dishwashermodelalternate;
        public Int32 dishwashermodelalternate
        {
            get { return _dishwashermodelalternate; }
            set { _dishwashermodelalternate = value; }
        }
        String _dishwashermodelalternateother;
        public String dishwashermodelalternateother
        {
            get { return _dishwashermodelalternateother; }
            set { _dishwashermodelalternateother = value; }
        }
        Int32 _dishmachinestylealternate;
        public Int32 dishmachinestylealternate
        {
            get { return _dishmachinestylealternate; }
            set { _dishmachinestylealternate = value; }
        }
        String _dishmachinestylealternateother;
        public String dishmachinestylealternateother
        {
            get { return _dishmachinestylealternateother; }
            set { _dishmachinestylealternateother = value; }
        }
        Int32 _wasteeqprimespec;
        public Int32 wasteeqprimespec
        {
            get { return _wasteeqprimespec; }
            set { _wasteeqprimespec = value; }
        }
        String _wasteeqprimespecother;
        public String wasteeqprimespecother
        {
            get { return _wasteeqprimespecother; }
            set { _wasteeqprimespecother = value; }
        }
        Int32 _wasteeqtype;
        public Int32 wasteeqtype
        {
            get { return _wasteeqtype; }
            set { _wasteeqtype = value; }
        }
        String _wasteeqtypeother;
        public String wasteeqtypeother
        {
            get { return _wasteeqtypeother; }
            set { _wasteeqtypeother = value; }
        }
        Int32 _wasteeqmodel;
        public Int32 wasteeqmodel
        {
            get { return _wasteeqmodel; }
            set { _wasteeqmodel = value; }
        }
        String _wasteeqmodelother;
        public String wasteeqmodelother
        {
            get { return _wasteeqmodelother; }
            set { _wasteeqmodelother = value; }
        }
        Int32 _wasteeqstyle;
        public Int32 wasteeqstyle
        {
            get { return _wasteeqstyle; }
            set { _wasteeqstyle = value; }
        }
        String _wasteeqstyleother;
        public String wasteeqstyleother
        {
            get { return _wasteeqstyleother; }
            set { _wasteeqstyleother = value; }
        }
        Int32 _wasteeqalternate;
        public Int32 wasteeqalternate
        {
            get { return _wasteeqalternate; }
            set { _wasteeqalternate = value; }
        }
        String _wasteeqalternateother;
        public String wasteeqalternateother
        {
            get { return _wasteeqalternateother; }
            set { _wasteeqalternateother = value; }
        }
        Int32 _wasteeqalternatetype;
        public Int32 wasteeqalternatetype
        {
            get { return _wasteeqalternatetype; }
            set { _wasteeqalternatetype = value; }
        }
        String _wasteeqalternatetypeother;
        public String wasteeqalternatetypeother
        {
            get { return _wasteeqalternatetypeother; }
            set { _wasteeqalternatetypeother = value; }
        }
        Int32 _wasteeqmodelalternate;
        public Int32 wasteeqmodelalternate
        {
            get { return _wasteeqmodelalternate; }
            set { _wasteeqmodelalternate = value; }
        }
        String _wasteeqmodelalternateother;
        public String wasteeqmodelalternateother
        {
            get { return _wasteeqmodelalternateother; }
            set { _wasteeqmodelalternateother = value; }
        }
        Int32 _wasteeqstylealternate;
        public Int32 wasteeqstylealternate
        {
            get { return _wasteeqstylealternate; }
            set { _wasteeqstylealternate = value; }
        }
        String _wasteeqstylealternateother;
        public String wasteeqstylealternateother
        {
            get { return _wasteeqstylealternateother; }
            set { _wasteeqstylealternateother = value; }
        }
        //Start Proposal Drawings
        String _pDrgNum;
        public String pDrgNum
        {
            get { return _pDrgNum; }
            set { _pDrgNum = value; }
        }
        Int32 _pEngID;
        public Int32 pEngID
        {
            get { return _pEngID; }
            set { _pEngID = value; }
        }
        Int32 _ProDwgid;
        public Int32 ProDwgid
        {
            get { return _ProDwgid; }
            set { _ProDwgid = value; }
        }
        DateTime? _pReqByRcd;
        public DateTime? pReqByRcd
        {
            get { return _pReqByRcd; }
            set { _pReqByRcd = value; }
        }
        DateTime? _pReqFwdtoCAD;
        public DateTime? pReqFwdtoCAD
        {
            get { return _pReqFwdtoCAD; }
            set { _pReqFwdtoCAD = value; }
        }
        DateTime? _pDwgSenttoManager;
        public DateTime? pDwgSenttoManager
        {
            get { return _pDwgSenttoManager; }
            set { _pDwgSenttoManager = value; }
        }
        DateTime? _pDwgFwdtoRCD;
        public DateTime? pDwgFwdtoRCD
        {
            get { return _pDwgFwdtoRCD; }
            set { _pDwgFwdtoRCD = value; }
        }
        String _Remarks;
        public String Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        Boolean _PriceProtectionRequired;
        public Boolean PriceProtectionRequired
        {
            get { return _PriceProtectionRequired; }
            set { _PriceProtectionRequired = value; }
        }
        String _SpecialInstr;
        public String SpecialInstr
        {
            get { return _SpecialInstr; }
            set { _SpecialInstr = value; }
        }
        Boolean _ElevenFour;
        public Boolean ElevenFour
        {
            get { return _ElevenFour; }
            set { _ElevenFour = value; }
        }
    }

    // BOL For Customers
    public class BOLManageCustomers
    {

        Int32 _CustomerID;
        public Int32 CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        String _CompanyName;
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        String _BusinessType;
        public String BusinessType
        {
            get { return _BusinessType; }
            set { _BusinessType = value; }
        }

        String _StreetAddress;
        public String StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }

        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }

        Int16 _StateID;
        public Int16 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }

        String _ZipCode;
        public String ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }

        Int16 _CountryID;
        public Int16 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        String _TollFree;
        public String TollFree
        {
            get { return _TollFree; }
            set { _TollFree = value; }
        }

        String _TollFax;
        public String TollFax
        {
            get { return _TollFax; }
            set { _TollFax = value; }
        }

        String _MainPhone;
        public String MainPhone
        {
            get { return _MainPhone; }
            set { _MainPhone = value; }
        }
        String _MainFax;
        public String MainFax
        {
            get { return _MainFax; }
            set { _MainFax = value; }
        }
        Int16 _TSM;
        public Int16 TSM
        {
            get { return _TSM; }
            set { _TSM = value; }
        }

        Int16 _SerRep;
        public Int16 SerRep
        {
            get { return _SerRep; }
            set { _SerRep = value; }
        }

        String _References;
        public String References
        {
            get { return _References; }
            set { _References = value; }
        }
        String _Memo;
        public String Memo
        {
            get { return _Memo; }
            set { _Memo = value; }
        }

        DataTable _dtMember;
        public DataTable dtMember
        {
            get { return _dtMember; }
            set { _dtMember = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        String _SiteAddress;
        public String SiteAddress
        {
            get { return _SiteAddress; }
            set { _SiteAddress = value; }
        }
    }

    // BLL For Customer Members
    public class BOLManageCustomerMember
    {

        Int32 _ContactID;
        public Int32 ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }

        Int16 _CustomerID;
        public Int16 CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        String _Title;
        public String Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        String _FName;
        public String FName
        {
            get { return _FName; }
            set { _FName = value; }
        }

        String _LName;
        public String LName
        {
            get { return _LName; }
            set { _LName = value; }
        }

        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        String _OfficePhone;
        public String OfficePhone
        {
            get { return _OfficePhone; }
            set { _OfficePhone = value; }
        }
        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        Boolean _MainContact;
        public Boolean MainContact
        {
            get { return _MainContact; }
            set { _MainContact = value; }
        }

        Boolean _ReferenceContact;
        public Boolean ReferenceContact
        {
            get { return _ReferenceContact; }
            set { _ReferenceContact = value; }
        }

        String _email;
        public String email
        {
            get { return _email; }
            set { _email = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }


    //BOL For Consultant
    public class BOLManageConsultant
    {

        Int32 _ConsultantID;
        public Int32 ConsultantID
        {
            get { return _ConsultantID; }
            set { _ConsultantID = value; }
        }

        String _CompanyName;
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }


        String _StreetAdd;
        public String StreetAdd
        {
            get { return _StreetAdd; }
            set { _StreetAdd = value; }
        }

        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }

        Int32 _StateID;
        public Int32 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }

        String _ZipCode;
        public String ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }

        String _Country;
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        String _TollFree;
        public String TollFree
        {
            get { return _TollFree; }
            set { _TollFree = value; }
        }

        String _TollFax;
        public String TollFax
        {
            get { return _TollFax; }
            set { _TollFax = value; }
        }

        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        Int16 _TSM;
        public Int16 TSM
        {
            get { return _TSM; }
            set { _TSM = value; }
        }

        Int32 _CountryID;
        public Int32 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        String _ConsPref;
        public String ConsPref
        {
            get { return _ConsPref; }
            set { _ConsPref = value; }
        }

        Int32 _PrefVendor1;
        public Int32 PrefVendor1
        {
            get { return _PrefVendor1; }
            set { _PrefVendor1 = value; }
        }
        Int32 _PrefVendor2;
        public Int32 PrefVendor2
        {
            get { return _PrefVendor2; }
            set { _PrefVendor2 = value; }
        }
        Int32 _PrefVendor3;
        public Int32 PrefVendor3
        {
            get { return _PrefVendor3; }
            set { _PrefVendor3 = value; }
        }

        Int32 _PrefFood;
        public Int32 PrefFood
        {
            get { return _PrefFood; }
            set { _PrefFood = value; }
        }

        String _NatureofConsultant;
        public String NatureofConsultant
        {
            get { return _NatureofConsultant; }
            set { _NatureofConsultant = value; }
        }

        Int32 _status;
        public Int32 status
        {
            get { return _status; }
            set { _status = value; }
        }

        String _Emailpath;
        public String Emailpath
        {
            get { return _Emailpath; }
            set { _Emailpath = value; }
        }

        String _CompanyEmail;
        public String CompanyEmail
        {
            get { return _CompanyEmail; }
            set { _CompanyEmail = value; }
        }

        DataTable _dtMember;
        public DataTable dtMember
        {
            get { return _dtMember; }
            set { _dtMember = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }

    // BOL For Consultant Members
    public class BOLManageConsultantMember
    {

        Int32 _ConsultantMemberID;
        public Int32 ConsultantMemberID
        {
            get { return _ConsultantMemberID; }
            set { _ConsultantMemberID = value; }
        }

        Int16 _ConsultantID;
        public Int16 ConsultantID
        {
            get { return _ConsultantID; }
            set { _ConsultantID = value; }
        }

        String _JobTitle;
        public String JobTitle
        {
            get { return _JobTitle; }
            set { _JobTitle = value; }
        }

        String _FirstName;
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        String _LastName;
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        String _TelephoneExtension;
        public String TelephoneExtension
        {
            get { return _TelephoneExtension; }
            set { _TelephoneExtension = value; }
        }

        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        String _DirectLine;
        public String DirectLine
        {
            get { return _DirectLine; }
            set { _DirectLine = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }

    // BLL For Dealers
    public class BOLManageDealers
    {
        Int32 _FoodPref;
        public Int32 FoodPref
        {
            get { return _FoodPref; }
            set { _FoodPref = value; }
        }
        Int32 _status;
        public Int32 status
        {
            get { return _status; }
            set { _status = value; }
        }

        Int32 _DealerID;
        public Int32 DealerID
        {
            get { return _DealerID; }
            set { _DealerID = value; }
        }
        String _FederalID;
        public String FederalID
        {
            get { return _FederalID; }
            set { _FederalID = value; }
        }

        String _CompanyName;
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        String _GroupName;
        public String GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }

        String _StreetAddress;
        public String StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }

        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }

        Int16 _StateID;
        public Int16 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }

        String _Country;
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        String _ZipCode;
        public String ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }

        String _TollFree;
        public String TollFree
        {
            get { return _TollFree; }
            set { _TollFree = value; }
        }

        String _TollFax;
        public String TollFax
        {
            get { return _TollFax; }
            set { _TollFax = value; }
        }

        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        Int16 _RegionID;
        public Int16 RegionID
        {
            get { return _RegionID; }
            set { _RegionID = value; }
        }

        Int16 _HobartDealer;
        public Int16 HobartDealer
        {
            get { return _HobartDealer; }
            set { _HobartDealer = value; }
        }
        String _ChristmasCard;
        public String ChristmasCard
        {
            get { return _ChristmasCard; }
            set { _ChristmasCard = value; }
        }
        String _TSM;
        public String TSM
        {
            get { return _TSM; }
            set { _TSM = value; }
        }
        String _HeadOffice;
        public String HeadOffice
        {
            get { return _HeadOffice; }
            set { _HeadOffice = value; }
        }
        Boolean _Agreement;
        public Boolean Agreement
        {
            get { return _Agreement; }
            set { _Agreement = value; }
        }
        String _AgreedDiscount;
        public String AgreedDiscount
        {
            get { return _AgreedDiscount; }
            set { _AgreedDiscount = value; }
        }
        String _DealerPref;
        public String DealerPref
        {
            get { return _DealerPref; }
            set { _DealerPref = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _W9form;
        public String W9form
        {
            get { return _W9form; }
            set { _W9form = value; }
        }
        DateTime? _LastUpdatedDate;
        public DateTime? LastUpdatedDate
        {
            get { return _LastUpdatedDate; }
            set { _LastUpdatedDate = value; }
        }
    }

    // BLL For Dealer Member
    public class BOLManageDealerMember
    {

        Int32 _ContactID;
        public Int32 ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }

        Int16 _DealerID;
        public Int16 DealerID
        {
            get { return _DealerID; }
            set { _DealerID = value; }
        }

        String _Title;
        public String Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        String _FName;
        public String FName
        {
            get { return _FName; }
            set { _FName = value; }
        }

        String _LName;
        public String LName
        {
            get { return _LName; }
            set { _LName = value; }
        }

        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        Boolean _MainContact;
        public Boolean MainContact
        {
            get { return _MainContact; }
            set { _MainContact = value; }
        }

        Boolean _Attention;
        public Boolean Attention
        {
            get { return _Attention; }
            set { _Attention = value; }
        }
        String _Extension;
        public String Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }
        String _email;
        public String email
        {
            get { return _email; }
            set { _email = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _Cell;
        public String Cell
        {
            get { return _Cell; }
            set { _Cell = value; }
        }
    }

    public class BOLManageProjects
    {
        DateTime? _AssignedDate;
        public DateTime? AssignedDate
        {
            get { return _AssignedDate; }
            set { _AssignedDate = value; }
        }

        DateTime? _ExpectedSubmissionDate_FabCanada;
        public DateTime? ExpectedSubmissionDate_FabCanada
        {
            get { return _ExpectedSubmissionDate_FabCanada; }
            set { _ExpectedSubmissionDate_FabCanada = value; }
        }
        String _ProjectQuality;
        public String ProjectQuality
        {
            get { return _ProjectQuality; }
            set { _ProjectQuality = value; }
        }

        Int32 _CorrectedBy_ProjectFeedback;
        public Int32 CorrectedBy_ProjectFeedback
        {
            get { return _CorrectedBy_ProjectFeedback; }
            set { _CorrectedBy_ProjectFeedback = value; }
        }

        Int32 _CorrectedByEngineer;
        public Int32 CorrectedByEngineer
        {
            get { return _CorrectedByEngineer; }
            set { _CorrectedByEngineer = value; }
        }

        DateTime? _QCReportSentDate;
        public DateTime? QCReportSentDate
        {
            get { return _QCReportSentDate; }
            set { _QCReportSentDate = value; }
        }

        DateTime? _QCReportReceivedDate;
        public DateTime? QCReportReceivedDate
        {
            get { return _QCReportReceivedDate; }
            set { _QCReportReceivedDate = value; }
        }

        Decimal _InstallationAmount;
        public Decimal InstallationAmount
        {
            get { return _InstallationAmount; }
            set { _InstallationAmount = value; }
        }

        Int32 _ThirdPartyInstaller;
        public Int32 ThirdPartyInstaller
        {
            get { return _ThirdPartyInstaller; }
            set { _ThirdPartyInstaller = value; }
        }
        int _WarehouseId;
        public int WarehouseId
        {
            get { return _WarehouseId; }
            set { _WarehouseId = value; }
        }

        DateTime? _ExpectedSalesDate;
        public DateTime? ExpectedSalesDate
        {
            get { return _ExpectedSalesDate; }
            set { _ExpectedSalesDate = value; }
        }

        Int32 _SalesOpportunity;
        public Int32 SalesOpportunity
        {
            get { return _SalesOpportunity; }
            set { _SalesOpportunity = value; }
        }

        Int32 _SalesOpportunityStatus;
        public Int32 SalesOpportunityStatus
        {
            get { return _SalesOpportunityStatus; }
            set { _SalesOpportunityStatus = value; }
        }

        String _ShipperContactName;
        public String ShipperContactName
        {
            get { return _ShipperContactName; }
            set { _ShipperContactName = value; }
        }

        String _ShipperPhone;
        public String ShipperPhone
        {
            get { return _ShipperPhone; }
            set { _ShipperPhone = value; }
        }

        String _ShipperEmail;
        public String ShipperEmail
        {
            get { return _ShipperEmail; }
            set { _ShipperEmail = value; }
        }

        String _ShipperTrackingNo;
        public String ShipperTrackingNo
        {
            get { return _ShipperTrackingNo; }
            set { _ShipperTrackingNo = value; }
        }

        String _ShipperPickupFromShop;
        public String ShipperPickupFromShop
        {
            get { return _ShipperPickupFromShop; }
            set { _ShipperPickupFromShop = value; }
        }

        String _ShipperNotes;
        public String ShipperNotes
        {
            get { return _ShipperNotes; }
            set { _ShipperNotes = value; }
        }

        String _ShippedVia;
        public String ShippedVia
        {
            get { return _ShippedVia; }
            set { _ShippedVia = value; }
        }

        Decimal _ActualShippingCost;
        public Decimal ActualShippingCost
        {
            get { return _ActualShippingCost; }
            set { _ActualShippingCost = value; }
        }

        Decimal _AdditionalCharges;
        public Decimal AdditionalCharges
        {
            get { return _AdditionalCharges; }
            set { _AdditionalCharges = value; }
        }

        Boolean _Osha;
        public Boolean Osha
        {
            get { return _Osha; }
            set { _Osha = value; }
        }

        String _OshaDetails;
        public String OshaDetails
        {
            get { return _OshaDetails; }
            set { _OshaDetails = value; }
        }

        Boolean _StateCertificate;
        public Boolean StateCertificate
        {
            get { return _StateCertificate; }
            set { _StateCertificate = value; }
        }

        String _StateCertificateDetails;
        public String StateCertificateDetails
        {
            get { return _StateCertificateDetails; }
            set { _StateCertificateDetails = value; }
        }

        Boolean _DrugTestingCertificate;
        public Boolean DrugTestingCertificate
        {
            get { return _DrugTestingCertificate; }
            set { _DrugTestingCertificate = value; }
        }

        String _DrugTestingCertificateDetails;
        public String DrugTestingCertificateDetails
        {
            get { return _DrugTestingCertificateDetails; }
            set { _DrugTestingCertificateDetails = value; }
        }

        Boolean _WHMIS;
        public Boolean WHMIS
        {
            get { return _WHMIS; }
            set { _WHMIS = value; }
        }

        String _WHMISDetails;
        public String WHMISDetails
        {
            get { return _WHMISDetails; }
            set { _WHMISDetails = value; }
        }

        Boolean _FallProtection;
        public Boolean FallProtection
        {
            get { return _FallProtection; }
            set { _FallProtection = value; }
        }

        String _FallProtectionDetails;
        public String FallProtectionDetails
        {
            get { return _FallProtectionDetails; }
            set { _FallProtectionDetails = value; }
        }

        Boolean _MedicalCertificate;
        public Boolean MedicalCertificate
        {
            get { return _MedicalCertificate; }
            set { _MedicalCertificate = value; }
        }

        String _MedicalCertificateDetails;
        public String MedicalCertificateDetails
        {
            get { return _MedicalCertificateDetails; }
            set { _MedicalCertificateDetails = value; }
        }

        Boolean _InsuranceCertificate;
        public Boolean InsuranceCertificate
        {
            get { return _InsuranceCertificate; }
            set { _InsuranceCertificate = value; }
        }

        String _InsuranceCertificateDetails;
        public String InsuranceCertificateDetails
        {
            get { return _InsuranceCertificateDetails; }
            set { _InsuranceCertificateDetails = value; }
        }

        DateTime? _StartupDate;
        public DateTime? StartupDate
        {
            get { return _StartupDate; }
            set { _StartupDate = value; }
        }

        DateTime? _CommissioningDate;
        public DateTime? CommissioningDate
        {
            get { return _CommissioningDate; }
            set { _CommissioningDate = value; }
        }

        String _ShippingReq;
        public String ShippingReq
        {
            get { return _ShippingReq; }
            set { _ShippingReq = value; }
        }

        String _ShippingReqDetails;
        public String ShippingReqDetails
        {
            get { return _ShippingReqDetails; }
            set { _ShippingReqDetails = value; }
        }

        String _CertificateReq;
        public String CertificateReq
        {
            get { return _CertificateReq; }
            set { _CertificateReq = value; }
        }

        String _CertificateReqDetails;
        public String CertificateReqDetails
        {
            get { return _CertificateReqDetails; }
            set { _CertificateReqDetails = value; }
        }

        Boolean _MannedFireWatch;
        public Boolean MannedFireWatch
        {
            get { return _MannedFireWatch; }
            set { _MannedFireWatch = value; }
        }

        String _MannedFireWatchDetails;
        public String MannedFireWatchDetails
        {
            get { return _MannedFireWatchDetails; }
            set { _MannedFireWatchDetails = value; }
        }

        Boolean _HotWorkPermit;
        public Boolean HotWorkPermit
        {
            get { return _HotWorkPermit; }
            set { _HotWorkPermit = value; }
        }

        String _HotWorkPermitDetails;
        public String HotWorkPermitDetails
        {
            get { return _HotWorkPermitDetails; }
            set { _HotWorkPermitDetails = value; }
        }

        Int32 _OrientTraining;
        public Int32 OrientTraining
        {
            get { return _OrientTraining; }
            set { _OrientTraining = value; }
        }

        String _OrientTrainingDetails;
        public String OrientTrainingDetails
        {
            get { return _OrientTrainingDetails; }
            set { _OrientTrainingDetails = value; }
        }

        Boolean _CanTechAccess;
        public Boolean CanTechAccess
        {
            get { return _CanTechAccess; }
            set { _CanTechAccess = value; }
        }

        String _CanTechAccessDetails;
        public String CanTechAccessDetails
        {
            get { return _CanTechAccessDetails; }
            set { _CanTechAccessDetails = value; }
        }

        DateTime? _ScopeDate;
        public DateTime? ScopeDate
        {
            get { return _ScopeDate; }
            set { _ScopeDate = value; }
        }

        String _ScopeOfWork;
        public String ScopeOfWork
        {
            get { return _ScopeOfWork; }
            set { _ScopeOfWork = value; }
        }

        String _PlumbingElectricalSupply;
        public String PlumbingElectricalSupply
        {
            get { return _PlumbingElectricalSupply; }
            set { _PlumbingElectricalSupply = value; }
        }

        //---------------------------
        String _ProjectTechnician;
        public String ProjectTechnician
        {
            get { return _ProjectTechnician; }
            set { _ProjectTechnician = value; }
        }

        String _InstallationPriority;
        public String InstallationPriority
        {
            get { return _InstallationPriority; }
            set { _InstallationPriority = value; }
        }

        String _InstallationCommitment;
        public String InstallationCommitment
        {
            get { return _InstallationCommitment; }
            set { _InstallationCommitment = value; }
        }

        String _ProductionStatus;
        public String ProductionStatus
        {
            get { return _ProductionStatus; }
            set { _ProductionStatus = value; }
        }

        String _ProductionRemarks;
        public String ProductionRemarks
        {
            get { return _ProductionRemarks; }
            set { _ProductionRemarks = value; }
        }

        Boolean _InvoiceNotRequired;
        public Boolean InvoiceNotRequired
        {
            get { return _InvoiceNotRequired; }
            set { _InvoiceNotRequired = value; }
        }

        Boolean _ConfirmedFromGover;
        public Boolean ConfirmedFromGover
        {
            get { return _ConfirmedFromGover; }
            set { _ConfirmedFromGover = value; }
        }

        Boolean _UpdatedOnVisual;
        public Boolean UpdatedOnVisual
        {
            get { return _UpdatedOnVisual; }
            set { _UpdatedOnVisual = value; }
        }

        String _ReasonForPriceUpdate;
        public String ReasonForPriceUpdate
        {
            get { return _ReasonForPriceUpdate; }
            set { _ReasonForPriceUpdate = value; }
        }

        String _ContainerNo;
        public String ContainerNo
        {
            get { return _ContainerNo; }
            set { _ContainerNo = value; }
        }
        DateTime? _ShipDateFromChina;
        public DateTime? ShipDateFromChina
        {
            get { return _ShipDateFromChina; }
            set { _ShipDateFromChina = value; }
        }
        DateTime? _FabSentToCanada_China;
        public DateTime? FabSentToCanada_China
        {
            get { return _FabSentToCanada_China; }
            set { _FabSentToCanada_China = value; }
        }
        DateTime? _DateAssignedChina;
        public DateTime? DateAssignedChina
        {
            get { return _DateAssignedChina; }
            set { _DateAssignedChina = value; }
        }

        DateTime? _ReleaseDateChina;
        public DateTime? ReleaseDateChina
        {
            get { return _ReleaseDateChina; }
            set { _ReleaseDateChina = value; }
        }

        DateTime? _ExpectedSubmissionDate;
        public DateTime? ExpectedSubmissionDate
        {
            get { return _ExpectedSubmissionDate; }
            set { _ExpectedSubmissionDate = value; }
        }

        DateTime? _ActualSubmissionDate;
        public DateTime? ActualSubmissionDate
        {
            get { return _ActualSubmissionDate; }
            set { _ActualSubmissionDate = value; }
        }

        Int32 _ProjectDesignerChinaID;
        public Int32 ProjectDesignerChinaID
        {
            get { return _ProjectDesignerChinaID; }
            set { _ProjectDesignerChinaID = value; }
        }

        Int32 _ProjectReviewerChinaID;
        public Int32 ProjectReviewerChinaID
        {
            get { return _ProjectReviewerChinaID; }
            set { _ProjectReviewerChinaID = value; }
        }

        Int32 _FabDrawingPercentage;
        public Int32 FabDrawingPercentage
        {
            get { return _FabDrawingPercentage; }
            set { _FabDrawingPercentage = value; }
        }

        String _ProjectCommNotes;
        public String ProjectCommNotes
        {
            get { return _ProjectCommNotes; }
            set { _ProjectCommNotes = value; }
        }
        String _PurchasedItems;
        public String PurchasedItems
        {
            get { return _PurchasedItems; }
            set { _PurchasedItems = value; }
        }
        String _PurchasedItemsCAD;
        public String PurchasedItemsCAD
        {
            get { return _PurchasedItemsCAD; }
            set { _PurchasedItemsCAD = value; }
        }
        String _Issued;
        public String Issued
        {
            get { return _Issued; }
            set { _Issued = value; }
        }
        Int32 _ProjectStatus;
        public Int32 ProjectStatus
        {
            get { return _ProjectStatus; }
            set { _ProjectStatus = value; }
        }
        Int32 _ProjectManager;
        public Int32 ProjectManager
        {
            get { return _ProjectManager; }
            set { _ProjectManager = value; }
        }
        String _JobType;
        public String JobType
        {
            get { return _JobType; }
            set { _JobType = value; }
        }
        String _ExistingJobID;
        public String ExistingJobID
        {
            get { return _ExistingJobID; }
            set { _ExistingJobID = value; }
        }
        Int32 _ConsultantMemberId;
        public Int32 ConsultantMemberId
        {
            get { return _ConsultantMemberId; }
            set { _ConsultantMemberId = value; }
        }
        String _SearchBy;
        public String SearchBy
        {
            get { return _SearchBy; }
            set { _SearchBy = value; }
        }
        String _CompanyName;
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }

        }
        String _JobID;
        public String JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }

        DateTime? _JobOrderDate;
        public DateTime? JobOrderDate
        {
            get { return _JobOrderDate; }
            set { _JobOrderDate = value; }
        }
        Int32 _OrderBelongsToDELETE;
        public Int32 OrderBelongsToDELETE
        {
            get { return _OrderBelongsToDELETE; }
            set { _OrderBelongsToDELETE = value; }
        }

        DateTime? _PORec;
        public DateTime? PORec
        {
            get { return _PORec; }
            set { _PORec = value; }
        }
        String _OASentTo;
        public String OASentTo
        {
            get { return _OASentTo; }
            set { _OASentTo = value; }
        }
        String _OASentToContact;
        public String OASentToContact
        {
            get { return _OASentToContact; }
            set { _OASentToContact = value; }
        }
        String _QuoteSelected;
        public String QuoteSelected
        {
            get { return _QuoteSelected; }
            set { _QuoteSelected = value; }
        }

        DateTime? _JobOrderAck;
        public DateTime? JobOrderAck
        {
            get { return _JobOrderAck; }
            set { _JobOrderAck = value; }
        }
        DateTime? _JobOADis;
        public DateTime? JobOADis
        {
            get { return _JobOADis; }
            set { _JobOADis = value; }
        }

        String _ProposalID;
        public String ProposalID
        {
            get { return _ProposalID; }
            set { _ProposalID = value; }
        }
        Int32 _CustomerID;
        public Int32 CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        Int32 _ModelID;
        public Int32 ModelID
        {
            get { return _ModelID; }
            set { _ModelID = value; }
        }

        Int32 _ConveyorTypeID;
        public Int32 ConveyorTypeID
        {
            get { return _ConveyorTypeID; }
            set { _ConveyorTypeID = value; }
        }
        Int32 _ServiceRepID;
        public Int32 ServiceRepID
        {
            get { return _ServiceRepID; }
            set { _ServiceRepID = value; }
        }
        Int32 _ShipperID;
        public Int32 ShipperID
        {
            get { return _ShipperID; }
            set { _ShipperID = value; }
        }
        String _ShippingCommit;
        public String ShippingCommit
        {
            get { return _ShippingCommit; }
            set { _ShippingCommit = value; }
        }
        String _ShipStatus;
        public String ShipStatus
        {
            get { return _ShipStatus; }
            set { _ShipStatus = value; }
        }
        String _SiteContact;
        public String SiteContact
        {
            get { return _SiteContact; }
            set { _SiteContact = value; }
        }
        String _SiteContactTelephone;
        public String SiteContactTelephone
        {
            get { return _SiteContactTelephone; }
            set { _SiteContactTelephone = value; }
        }

        String _SiteContactEmail;
        public String SiteContactEmail
        {
            get { return _SiteContactEmail; }
            set { _SiteContactEmail = value; }
        }

        DateTime? _DateAsBuiltDrgsSent;
        public DateTime? DateAsBuiltDrgsSent
        {
            get { return _DateAsBuiltDrgsSent; }
            set { _DateAsBuiltDrgsSent = value; }
        }
        DateTime? _EstReleaseDate;
        public DateTime? EstReleaseDate
        {
            get { return _EstReleaseDate; }
            set { _EstReleaseDate = value; }
        }

        DateTime? _ReleaseDate;
        public DateTime? ReleaseDate
        {
            get { return _ReleaseDate; }
            set { _ReleaseDate = value; }
        }

        //ExpectedArrivalDatefromChina
        DateTime? _ExpectedArrivalDatefromChina;
        public DateTime? ExpectedArrivalDatefromChina
        {
            get { return _ExpectedArrivalDatefromChina; }
            set { _ExpectedArrivalDatefromChina = value; }
        }

        DateTime? _TestRunDate;
        public DateTime? TestRunDate
        {
            get { return _TestRunDate; }
            set { _TestRunDate = value; }
        }

        DateTime? _EstCompletionDate;
        public DateTime? EstCompletionDate
        {
            get { return _EstCompletionDate; }
            set { _EstCompletionDate = value; }
        }

        DateTime? _ActualCompletionDate;
        public DateTime? ActualCompletionDate
        {
            get { return _ActualCompletionDate; }
            set { _ActualCompletionDate = value; }
        }
        DateTime? _ShipDate;
        public DateTime? ShipDate
        {
            get { return _ShipDate; }
            set { _ShipDate = value; }
        }
        DateTime? _ShipToArriveDate;
        public DateTime? ShipToArriveDate
        {
            get { return _ShipToArriveDate; }
            set { _ShipToArriveDate = value; }
        }
        DateTime? _ArrivalDate;
        public DateTime? ArrivalDate
        {
            get { return _ArrivalDate; }
            set { _ArrivalDate = value; }
        }
        DateTime? _ManualDispatchDate;
        public DateTime? ManualDispatchDate
        {
            get { return _ManualDispatchDate; }
            set { _ManualDispatchDate = value; }
        }
        Int16 _InstallationBy;
        public Int16 InstallationBy
        {
            get { return _InstallationBy; }
            set { _InstallationBy = value; }
        }
        DateTime? _InstallDate;
        public DateTime? InstallDate
        {
            get { return _InstallDate; }
            set { _InstallDate = value; }
        }
        DateTime? _InstallationCompletionDate;
        public DateTime? InstallationCompletionDate
        {
            get { return _InstallationCompletionDate; }
            set { _InstallationCompletionDate = value; }
        }
        Boolean _NoInstallation;
        public Boolean NoInstallation
        {
            get { return _NoInstallation; }
            set { _NoInstallation = value; }
        }

        DateTime? _DemoDate;
        public DateTime? DemoDate
        {
            get { return _DemoDate; }
            set { _DemoDate = value; }
        }
        DateTime? _WarrantyStartDate;
        public DateTime? WarrantyStartDate
        {
            get { return _WarrantyStartDate; }
            set { _WarrantyStartDate = value; }
        }
        DateTime? _WarrantyEndDate;
        public DateTime? WarrantyEndDate
        {
            get { return _WarrantyEndDate; }
            set { _WarrantyEndDate = value; }
        }

        DateTime? _FollowUpDate;
        public DateTime? FollowUpDate
        {
            get { return _FollowUpDate; }
            set { _FollowUpDate = value; }
        }

        DateTime? _CustCarePackageSendDate;
        public DateTime? CustCarePackageSendDate
        {
            get { return _CustCarePackageSendDate; }
            set { _CustCarePackageSendDate = value; }
        }

        String _PONumber;
        public String PONumber
        {
            get { return _PONumber; }
            set { _PONumber = value; }
        }

        String _InvoiceNumber;
        public String InvoiceNumber
        {
            get { return _InvoiceNumber; }
            set { _InvoiceNumber = value; }
        }
        DateTime? _DateInvoiceSent;
        public DateTime? DateInvoiceSent
        {
            get { return _DateInvoiceSent; }
            set { _DateInvoiceSent = value; }
        }
        DateTime? _DatePaymentReceived;
        public DateTime? DatePaymentReceived
        {
            get { return _DatePaymentReceived; }
            set { _DatePaymentReceived = value; }
        }
        DateTime? _DateCommissionPaid;
        public DateTime? DateCommissionPaid
        {
            get { return _DateCommissionPaid; }
            set { _DateCommissionPaid = value; }
        }
        String _KflexCheckNumber;
        public String KflexCheckNumber
        {
            get { return _KflexCheckNumber; }
            set { _KflexCheckNumber = value; }
        }
        String _CommissionType;
        public String CommissionType
        {
            get { return _CommissionType; }
            set { _CommissionType = value; }
        }
        Int32 _SalesSourceID;
        public Int32 SalesSourceID
        {
            get { return _SalesSourceID; }
            set { _SalesSourceID = value; }
        }


        String _ShipToName;
        public String ShipToName
        {
            get { return _ShipToName; }
            set { _ShipToName = value; }
        }
        String _ShipToStreet;
        public String ShipToStreet
        {
            get { return _ShipToStreet; }
            set { _ShipToStreet = value; }
        }
        String _ShipToCity;
        public String ShipToCity
        {
            get { return _ShipToCity; }
            set { _ShipToCity = value; }
        }

        String _ShipToState;
        public String ShipToState
        {
            get { return _ShipToState; }
            set { _ShipToState = value; }
        }
        String _ShipToCountry;
        public String ShipToCountry
        {
            get { return _ShipToCountry; }
            set { _ShipToCountry = value; }
        }

        String _ShipToZipCode;
        public String ShipToZipCode
        {
            get { return _ShipToZipCode; }
            set { _ShipToZipCode = value; }
        }
        Decimal _discount;
        public Decimal discount
        {
            get { return _discount; }
            set { _discount = value; }
        }
        Int32 _fob;
        public Int32 fob
        {
            get { return _fob; }
            set { _fob = value; }
        }
        Int32 _term;
        public Int32 term
        {
            get { return _term; }
            set { _term = value; }
        }

        DateTime? _IndComDate;
        public DateTime? IndComDate
        {
            get { return _IndComDate; }
            set { _IndComDate = value; }
        }
        String _AeroChequeNum;
        public String AeroChequeNum
        {
            get { return _AeroChequeNum; }
            set { _AeroChequeNum = value; }
        }
        DateTime? _PreInspectionDate;
        public DateTime? PreInspectionDate
        {
            get { return _PreInspectionDate; }
            set { _PreInspectionDate = value; }
        }
        String _CheckedByOffice;
        public String CheckedByOffice
        {
            get { return _CheckedByOffice; }
            set { _CheckedByOffice = value; }
        }

        String _CheckedByPlant;
        public String CheckedByPlant
        {
            get { return _CheckedByPlant; }
            set { _CheckedByPlant = value; }
        }
        Boolean _CancelJob;
        public Boolean CancelJob
        {
            get { return _CancelJob; }
            set { _CancelJob = value; }
        }

        Boolean _DigitalPicOnServer;
        public Boolean DigitalPicOnServer
        {
            get { return _DigitalPicOnServer; }
            set { _DigitalPicOnServer = value; }
        }
        Boolean _ReferenceDrawing;
        public Boolean ReferenceDrawing
        {
            get { return _ReferenceDrawing; }
            set { _ReferenceDrawing = value; }
        }
        Int16 _DealerMember;
        public Int16 DealerMember
        {
            get { return _DealerMember; }
            set { _DealerMember = value; }
        }

        Decimal _BuyOutCost;
        public Decimal BuyOutCost
        {
            get { return _BuyOutCost; }
            set { _BuyOutCost = value; }
        }
        Decimal _RawMaterial;
        public Decimal RawMaterial
        {
            get { return _RawMaterial; }
            set { _RawMaterial = value; }
        }
        Decimal _ExWarrantyPrice;
        public Decimal ExWarrantyPrice
        {
            get { return _ExWarrantyPrice; }
            set { _ExWarrantyPrice = value; }
        }

        Decimal _NetAmount;
        public Decimal NetAmount
        {
            get { return _NetAmount; }
            set { _NetAmount = value; }
        }
        Decimal _FreightPaid;
        public Decimal FreightPaid
        {
            get { return _FreightPaid; }
            set { _FreightPaid = value; }
        }

        Decimal _GST;
        public Decimal GST
        {
            get { return _GST; }
            set { _GST = value; }
        }
        Int16 _InstallatorA;
        public Int16 InstallatorA
        {
            get { return _InstallatorA; }
            set { _InstallatorA = value; }
        }
        Int16 _InstallatorB;
        public Int16 InstallatorB
        {
            get { return _InstallatorB; }
            set { _InstallatorB = value; }
        }
        Int16 _InstallatorC;
        public Int16 InstallatorC
        {
            get { return _InstallatorC; }
            set { _InstallatorC = value; }
        }
        Decimal _ConCost;
        public Decimal ConCost
        {
            get { return _ConCost; }
            set { _ConCost = value; }
        }
        Decimal _ConRoylAmt;
        public Decimal ConRoylAmt
        {
            get { return _ConRoylAmt; }
            set { _ConRoylAmt = value; }
        }

        String _ConCheckNo;
        public String ConCheckNo
        {
            get { return _ConCheckNo; }
            set { _ConCheckNo = value; }
        }
        DateTime? _ConChqPaidDt;
        public DateTime? ConChqPaidDt
        {
            get { return _ConChqPaidDt; }
            set { _ConChqPaidDt = value; }
        }
        String _Comments;
        public String Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }
        Int32 _ReviewedBy;
        public Int32 ReviewedBy
        {
            get { return _ReviewedBy; }
            set { _ReviewedBy = value; }
        }
        Int32 _CorrectedBy;
        public Int32 CorrectedBy
        {
            get { return _CorrectedBy; }
            set { _CorrectedBy = value; }
        }
        Int32 _Status;
        public Int32 Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        DateTime? _DrgSentOutforApproval;
        public DateTime? DrgSentOutforApproval
        {
            get { return _DrgSentOutforApproval; }
            set { _DrgSentOutforApproval = value; }
        }
        DateTime? _AppDrgWithFieldDimension;
        public DateTime? AppDrgWithFieldDimension
        {
            get { return _AppDrgWithFieldDimension; }
            set { _AppDrgWithFieldDimension = value; }
        }

        DateTime? _AppDrgAck;
        public DateTime? AppDrgAck
        {
            get { return _AppDrgAck; }
            set { _AppDrgAck = value; }
        }
        DateTime? _EquipDelConfirmed;
        public DateTime? EquipDelConfirmed
        {
            get { return _EquipDelConfirmed; }
            set { _EquipDelConfirmed = value; }
        }
        DateTime? _AccReqFromCustomer;
        public DateTime? AccReqFromCustomer
        {
            get { return _AccReqFromCustomer; }
            set { _AccReqFromCustomer = value; }
        }

        DateTime? _BuiltDrgWithUnderStruSent;
        public DateTime? BuiltDrgWithUnderStruSent
        {
            get { return _BuiltDrgWithUnderStruSent; }
            set { _BuiltDrgWithUnderStruSent = value; }
        }
        Int32 _ProjDataPrepBy;
        public Int32 ProjDataPrepBy
        {
            get { return _ProjDataPrepBy; }
            set { _ProjDataPrepBy = value; }
        }
        Int32 _ProjFormReviewByAI;
        public Int32 ProjFormReviewByAI
        {
            get { return _ProjFormReviewByAI; }
            set { _ProjFormReviewByAI = value; }
        }
        Int32 _ProjFormReviewByHO;
        public Int32 ProjFormReviewByHO
        {
            get { return _ProjFormReviewByHO; }
            set { _ProjFormReviewByHO = value; }
        }
        DateTime? _FabDrgReviewByAI;
        public DateTime? FabDrgReviewByAI
        {
            get { return _FabDrgReviewByAI; }
            set { _FabDrgReviewByAI = value; }
        }
        Int32 _FabDrgReviewByHO;
        public Int32 FabDrgReviewByHO
        {
            get { return _FabDrgReviewByHO; }
            set { _FabDrgReviewByHO = value; }
        }
        DateTime? _PFRBAIDate;
        public DateTime? PFRBAIDate
        {
            get { return _PFRBAIDate; }
            set { _PFRBAIDate = value; }
        }
        DateTime? _PFRBHODate;
        public DateTime? PFRBHODate
        {
            get { return _PFRBHODate; }
            set { _PFRBHODate = value; }
        }
        DateTime? _FDRBAIDate;
        public DateTime? FDRBAIDate
        {
            get { return _FDRBAIDate; }
            set { _FDRBAIDate = value; }
        }
        DateTime? _FDRBHODate;
        public DateTime? FDRBHODate
        {
            get { return _FDRBHODate; }
            set { _FDRBHODate = value; }
        }
        String _FeedBackConsultant;
        public String FeedBackConsultant
        {
            get { return _FeedBackConsultant; }
            set { _FeedBackConsultant = value; }
        }
        String _FeedBackDealer;
        public String FeedBackDealer
        {
            get { return _FeedBackDealer; }
            set { _FeedBackDealer = value; }
        }

        String _SummofSugg;
        public String SummofSugg
        {
            get { return _SummofSugg; }
            set { _SummofSugg = value; }
        }
        Boolean _SpecCredit;
        public Boolean SpecCredit
        {
            get { return _SpecCredit; }
            set { _SpecCredit = value; }
        }
        Int32 _SpecCredits;
        public Int32 SpecCredits
        {
            get { return _SpecCredits; }
            set { _SpecCredits = value; }
        }

        Int32 _SpecCreditPercentID;
        public Int32 SpecCreditPercentID
        {
            get { return _SpecCreditPercentID; }
            set { _SpecCreditPercentID = value; }
        }
        Decimal _SpecCreditAmount;
        public Decimal SpecCreditAmount
        {
            get { return _SpecCreditAmount; }
            set { _SpecCreditAmount = value; }
        }
        String _SpecCreditCheckNo;
        public String SpecCreditCheckNo
        {
            get { return _SpecCreditCheckNo; }
            set { _SpecCreditCheckNo = value; }
        }
        //
        DateTime? _SpecCreditPaidDate;
        public DateTime? SpecCreditPaidDate
        {
            get { return _SpecCreditPaidDate; }
            set { _SpecCreditPaidDate = value; }
        }
        String _GSICommissionType;
        public String GSICommissionType
        {
            get { return _GSICommissionType; }
            set { _GSICommissionType = value; }
        }
        Decimal _GSICommissionAmount;
        public Decimal GSICommissionAmount
        {
            get { return _GSICommissionAmount; }
            set { _GSICommissionAmount = value; }
        }
        String _GSICommissionCheckNo;
        public String GSICommissionCheckNo
        {
            get { return _GSICommissionCheckNo; }
            set { _GSICommissionCheckNo = value; }
        }
        DateTime? _GSICommissionSentDate;
        public DateTime? GSICommissionSentDate
        {
            get { return _GSICommissionSentDate; }
            set { _GSICommissionSentDate = value; }
        }
        String _ProjectName;
        public String ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }

        // Pfile Tables Colmuns start
        Int16 _DealerID;
        public Int16 DealerID
        {
            get { return _DealerID; }
            set { _DealerID = value; }
        }

        Int32 _OriginRepID;
        public Int32 OriginRepID
        {
            get { return _OriginRepID; }
            set { _OriginRepID = value; }
        }
        Int32 _ConsultRepID;
        public Int32 ConsultRepID
        {
            get { return _ConsultRepID; }
            set { _ConsultRepID = value; }
        }
        Int32 _RepID;
        public Int32 RepID
        {
            get { return _RepID; }
            set { _RepID = value; }
        }

        Int32 _ConsultantID;
        public Int32 ConsultantID
        {
            get { return _ConsultantID; }
            set { _ConsultantID = value; }
        }
        Decimal _Price;
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        Decimal _Freight;
        public Decimal Freight
        {
            get { return _Freight; }
            set { _Freight = value; }
        }
        Decimal _Installation;
        public Decimal Installation
        {
            get { return _Installation; }
            set { _Installation = value; }
        }
        Int32 _CurrencyID;
        public Int32 CurrencyID
        {
            get { return _CurrencyID; }
            set { _CurrencyID = value; }
        }
        String _CurrentStatus;
        public String CurrentStatus
        {
            get { return _CurrentStatus; }
            set { _CurrentStatus = value; }
        }
        Int32 _OrderProbabilityID;
        public Int32 OrderProbabilityID
        {
            get { return _OrderProbabilityID; }
            set { _OrderProbabilityID = value; }
        }
        Boolean _DetailedQuote;
        public Boolean DetailedQuote
        {
            get { return _DetailedQuote; }
            set { _DetailedQuote = value; }
        }
        Boolean _Specifications;
        public Boolean Specifications
        {
            get { return _Specifications; }
            set { _Specifications = value; }
        }
        Boolean _DPics;
        public Boolean DPics
        {
            get { return _DPics; }
            set { _DPics = value; }
        }
        Boolean _RefDrawing;
        public Boolean RefDrawing
        {
            get { return _RefDrawing; }
            set { _RefDrawing = value; }
        }

        Decimal _EqDisAmount;
        public Decimal EqDisAmount
        {
            get { return _EqDisAmount; }
            set { _EqDisAmount = value; }
        }
        Decimal _EqDiscount;
        public Decimal EqDiscount
        {
            get { return _EqDiscount; }
            set { _EqDiscount = value; }
        }
        Decimal _NetEqPrice;
        public Decimal NetEqPrice
        {
            get { return _NetEqPrice; }
            set { _NetEqPrice = value; }
        }

        //Fabrication Tab
        //MfgFacilityID 
        Int32 _MfgFacilityID;
        public Int32 MfgFacilityID
        {
            get { return _MfgFacilityID; }
            set { _MfgFacilityID = value; }
        }
        Int32 _ProjectDesignerID;
        public Int32 ProjectDesignerID
        {
            get { return _ProjectDesignerID; }
            set { _ProjectDesignerID = value; }
        }
        DateTime? _DateAssigned;
        public DateTime? DateAssigned
        {
            get { return _DateAssigned; }
            set { _DateAssigned = value; }
        }
        DateTime? _DueDateCanada;
        public DateTime? DueDateCanada
        {
            get { return _DueDateCanada; }
            set { _DueDateCanada = value; }
        }
        //FabSentToCanada
        DateTime? _FabSentToCanada;
        public DateTime? FabSentToCanada
        {
            get { return _FabSentToCanada; }
            set { _FabSentToCanada = value; }
        }
        //EngineerCanada
        String _EngineerCanada;
        public String EngineerCanada
        {
            get { return _EngineerCanada; }
            set { _EngineerCanada = value; }
        }

        Decimal _NetCommissionRate;
        public Decimal NetCommissionRate
        {
            get { return _NetCommissionRate; }
            set { _NetCommissionRate = value; }
        }
        // Pfile Tables Colmuns End


        //Nesting
        DateTime? _ReleasedToNesting;
        public DateTime? ReleasedToNesting
        {
            get { return _ReleasedToNesting; }
            set { _ReleasedToNesting = value; }
        }

        DateTime? _ReleasedToShop;
        public DateTime? ReleasedToShop
        {
            get { return _ReleasedToShop; }
            set { _ReleasedToShop = value; }
        }

        String _NestingStatus;
        public String NestingStatus
        {
            get { return _NestingStatus; }
            set { _NestingStatus = value; }
        }

        Int32 _UserID;
        public Int32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        Decimal _TotalAmtInv;
        public Decimal TotalAmtInv
        {
            get { return _TotalAmtInv; }
            set { _TotalAmtInv = value; }
        }

        Decimal _CashDisAmt;
        public Decimal CashDisAmt
        {
            get { return _CashDisAmt; }
            set { _CashDisAmt = value; }
        }
        Decimal _CashDisPer;
        public Decimal CashDisPer
        {
            get { return _CashDisPer; }
            set { _CashDisPer = value; }
        }
        Decimal _CashAmtRec;
        public Decimal CashAmtRec
        {
            get { return _CashAmtRec; }
            set { _CashAmtRec = value; }
        }

        Decimal _AmountForComission;
        public Decimal AmountForComission
        {
            get { return _AmountForComission; }
            set { _AmountForComission = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Boolean _PMPack;
        public Boolean PMPack
        {
            get { return _PMPack; }
            set { _PMPack = value; }
        }

        string _fileName;
        public string fileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        //Shipping Form Properties

        Int32 _DeliveryPref;
        public Int32 DeliveryPref
        {
            get { return _DeliveryPref; }
            set { _DeliveryPref = value; }
        }

        Int32 _CustomerSiteContact;
        public Int32 CustomerSiteContact
        {
            get { return _CustomerSiteContact; }
            set { _CustomerSiteContact = value; }
        }

        Int32 _DealerProjectManager;
        public Int32 DealerProjectManager
        {
            get { return _DealerProjectManager; }
            set { _DealerProjectManager = value; }
        }

        Int32 _WorkingHours;
        public Int32 WorkingHours
        {
            get { return _WorkingHours; }
            set { _WorkingHours = value; }
        }
        String _MontoFriTime;
        public String MontoFriTime
        {
            get { return _MontoFriTime; }
            set { _MontoFriTime = value; }
        }
        String _SatSunTime;
        public String SatSunTime
        {
            get { return _SatSunTime; }
            set { _SatSunTime = value; }
        }
        Int32? _ProjectReviewedBy;
        public Int32? ProjectReviewedBy
        {
            get { return _ProjectReviewedBy; }
            set { _ProjectReviewedBy = value; }
        }
        DateTime? _ProjectReviewedDate;
        public DateTime? ProjectReviewedDate
        {
            get { return _ProjectReviewedDate; }
            set { _ProjectReviewedDate = value; }
        }

        Int32 _ContactID;
        public Int32 ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }
    }

    // For Rep Branches
    // BLL For Customers
    public class BOLManageRepBranches
    {
        Int32 _BranchID;
        public Int32 BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }

        String _BranchLocation;
        public String BranchLocation
        {
            get { return _BranchLocation; }
            set { _BranchLocation = value; }
        }

        String _BranchName;
        public String BranchName
        {
            get { return _BranchName; }
            set { _BranchName = value; }
        }

        Int16 _RegionID;
        public Int16 RegionID
        {
            get { return _RegionID; }
            set { _RegionID = value; }
        }

        String _CompanyName;
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        String _StreetAddress;
        public String StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }

        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }

        Int16 _StateID;
        public Int16 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }

        Int16 _CountryID;
        public Int16 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        String _ZipCode;
        public String ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }

        String _Telephone;
        public String Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }


        String _TollFree;
        public String TollFree
        {
            get { return _TollFree; }
            set { _TollFree = value; }
        }
        String _TollFax;
        public String TollFax
        {
            get { return _TollFax; }
            set { _TollFax = value; }
        }
        String _FaxNumber;
        public String FaxNumber
        {
            get { return _FaxNumber; }
            set { _FaxNumber = value; }
        }

        Int16 _ChristmasCard;
        public Int16 ChristmasCard
        {
            get { return _ChristmasCard; }
            set { _ChristmasCard = value; }
        }

        Int32 _InsideSalesSupportID;
        public Int32 InsideSalesSupportID
        {
            get { return _InsideSalesSupportID; }
            set { _InsideSalesSupportID = value; }
        }

        Boolean _HobartGroup;
        public Boolean HobartGroup
        {
            get { return _HobartGroup; }
            set { _HobartGroup = value; }
        }
        Boolean _SteroGroup;
        public Boolean SteroGroup
        {
            get { return _SteroGroup; }
            set { _SteroGroup = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }

    public class BOLReps
    {
        Int32 _RepID;
        public Int32 RepID
        {
            get { return _RepID; }
            set { _RepID = value; }
        }

        Int32 _BranchID;
        public Int32 BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }

        String _FirstName;
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        String _LastName;
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        Int32 _AbbreviationID;
        public Int32 AbbreviationID
        {
            get { return _AbbreviationID; }
            set { _AbbreviationID = value; }
        }

        Int32 _PhoneMail;
        public Int32 PhoneMail
        {
            get { return _PhoneMail; }
            set { _PhoneMail = value; }
        }

        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        String _CellPhone;
        public String CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }

        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        String _HomePhone;
        public String HomePhone
        {
            get { return _HomePhone; }
            set { _HomePhone = value; }
        }

        String _HomeFax;
        public String HomeFax
        {
            get { return _HomeFax; }
            set { _HomeFax = value; }
        }

        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        Boolean _HomeOffice;
        public Boolean HomeOffice
        {
            get { return _HomeOffice; }
            set { _HomeOffice = value; }
        }

        String _HomeAddress;
        public String HomeAddress
        {
            get { return _HomeAddress; }
            set { _HomeAddress = value; }
        }

        String _HomeCity;
        public String HomeCity
        {
            get { return _HomeCity; }
            set { _HomeCity = value; }
        }

        String _HomeState;
        public String HomeState
        {
            get { return _HomeState; }
            set { _HomeState = value; }
        }

        String _HomePostalCode;
        public String HomePostalCode
        {
            get { return _HomePostalCode; }
            set { _HomePostalCode = value; }
        }
        String _Status;
        public String Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

    }

    //Start Category BOL
    //FrmCategory
    public class BOLfrmCategory
    {
        Int32 _CategoryID;
        public Int32 CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        String _Category;
        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        String _CategoryDescription;
        public String CategoryDescription
        {
            get { return _CategoryDescription; }
            set { _CategoryDescription = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }

    public class BOLEmployeeListing
    {
        Int32 _BranchID;
        public Int32 BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }
        Int32 _RepID;
        public Int32 RepID
        {
            get { return _RepID; }
            set { _RepID = value; }

        }
        string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        Int32 _AbbreviationID;
        public Int32 AbbreviationID
        {
            get { return _AbbreviationID; }
            set { _AbbreviationID = value; }
        }
        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        String _PhoneMail;
        public String PhoneMail
        {
            get { return _PhoneMail; }
            set { _PhoneMail = value; }
        }
        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        string _CellPhone;
        public string CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
        string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        string _ProductLine;
        public string ProductLine
        {
            get { return _ProductLine; }
            set { _ProductLine = value; }
        }
        string _BranchName;
        public string BranchName
        {
            get { return _BranchName; }
            set { _BranchName = value; }
        }
        string _CompanyName;
        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
        Int32 _HobartBranchID;
        public Int32 HobartBranchID
        {
            get { return _HobartBranchID; }
            set { _HobartBranchID = value; }
        }
        string _HomeAddress;
        public string HomeAddress
        {
            get { return _HomeAddress; }
            set { _HomeAddress = value; }
        }
        String _HomeCity;
        public String HomeCity
        {
            get { return _HomeCity; }
            set { _HomeCity = value; }
        }
        String _HomeState;
        public String HomeState
        {
            get { return _HomeState; }
            set { _HomeState = value; }
        }
        string _HomePhone;
        public String HomePhone
        {
            get { return _HomePhone; }
            set { _HomePhone = value; }
        }
        string _HomeFax;
        public string HomeFax
        {
            get { return _HomeFax; }
            set { _HomeFax = value; }
        }
        string _HomePostalCode;
        public string HomePostalCode
        {
            get { return _HomePostalCode; }
            set { _HomePostalCode = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _TSM;
        public String TSM
        {
            get { return _TSM; }
            set { _TSM = value; }
        }
        Boolean _HomeOffice;
        public Boolean HomeOffice
        {
            get { return _HomeOffice; }
            set { _HomeOffice = value; }
        }
        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
        Int32 _StateID;
        public Int32 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }
        Int32 _CountryID;
        public Int32 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        String _CompanyBranchName;
        public String CompanyBranchName
        {
            get { return _CompanyBranchName; }
        }
        Int32 _CompanyRegionID;
        public Int32 CompanyRegionID
        {
            get { return _CompanyRegionID; }
        }
        String _CompanyAddress;
        public String CompanyAddress
        {
            get { return _CompanyAddress; }
        }
        String _CompanyCity;
        public String CompanyCity
        {
            get { return _CompanyCity; }
        }
        Int32 _CompanyStateID;
        public Int32 CompanyStateID
        {
            get { return _CompanyStateID; }
        }
        Int32 _CompanyCountryId;
        public Int32 CompanyCountryId
        {
            get { return _CompanyCountryId; }
        }
        String _CompanyTollFree;
        public String CompanyTollFree
        {
            get { return _CompanyTollFree; }
        }
        String _CompanyFax;
        public String CompanyFax
        {
            get { return _CompanyFax; }
        }
    }

    public class BOLDistributors
    {
        Int32 _DistributorID;
        public Int32 DistributorID
        {
            get { return _DistributorID; }
            set { _DistributorID = value; }
        }

        String _Name;
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        Int32 _StateID;
        public Int32 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }

        Int32 _DistrictID;
        public Int32 DistrictID
        {
            get { return _DistrictID; }
            set { _DistrictID = value; }
        }

        Int32 _CityID;
        public Int32 CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }

        Int32 _ProductID;
        public Int32 ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }

        String _Address;
        public String Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        String _ContactNumber;
        public String ContactNumber
        {
            get { return _ContactNumber; }
            set { _ContactNumber = value; }
        }

        String _EmailAddress;
        public String EmailAddress
        {
            get { return _EmailAddress; }
            set { _EmailAddress = value; }
        }

        Int32 _IsActive;
        public Int32 IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        Int32 _UserID;
        public Int32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        Int32 _Action;
        public Int32 Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
    }

    public class BOLPackage
    {
        DataTable _dt;
        public DataTable dt
        {
            get { return _dt; }
            set { _dt = value; }
        }

        Int32 _PackageID;
        public Int32 PackageID
        {
            get { return _PackageID; }
            set { _PackageID = value; }
        }

        Int32 _UserID;
        public Int32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        String _WholePackageName;
        public String WholePackageName
        {
            get { return _WholePackageName; }
            set { _WholePackageName = value; }
        }

        Int32 _PackageNameID;
        public Int32 PackageNameID
        {
            get { return _PackageNameID; }
            set { _PackageNameID = value; }
        }

        Int32 _Action;
        public Int32 Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
    }

    public class BOLPackageDispatchSchedule
    {
        Int32 _DispatchID;
        public Int32 DispatchID
        {
            get { return _DispatchID; }
            set { _DispatchID = value; }
        }

        Int32 _PackageID;
        public Int32 PackageID
        {
            get { return _PackageID; }
            set { _PackageID = value; }
        }

        Int32 _CustomerID;
        public Int32 CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        Int32 _state_id;
        public Int32 state_id
        {
            get { return _state_id; }
            set { _state_id = value; }
        }

        Int32 _district_id;
        public Int32 district_id
        {
            get { return _district_id; }
            set { _district_id = value; }
        }

        Int32 _city_id;
        public Int32 city_id
        {
            get { return _city_id; }
            set { _city_id = value; }
        }

        Int32 _SessionID;
        public Int32 SessionID
        {
            get { return _SessionID; }
            set { _SessionID = value; }
        }

        DateTime? _SessionStartDate;
        public DateTime? SessionStartDate
        {
            get { return _SessionStartDate; }
            set { _SessionStartDate = value; }
        }

        DateTime? _SessionEndDate;
        public DateTime? SessionEndDate
        {
            get { return _SessionEndDate; }
            set { _SessionEndDate = value; }
        }

        DateTime? _PackStartDate;
        public DateTime? PackStartDate
        {
            get { return _PackStartDate; }
            set { _PackStartDate = value; }
        }

        DateTime? _PackEndDate;
        public DateTime? PackEndDate
        {
            get { return _PackEndDate; }
            set { _PackEndDate = value; }
        }

        Int32 _UserID;
        public Int32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        Int32 _Action;
        public Int32 Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        String _ItemType;
        public String ItemType
        {
            get { return _ItemType; }
            set { _ItemType = value; }
        }
    }

    public class BOLDesignation
    {
        Int32 _Desg_ID;
        public Int32 Desg_ID
        {
            get { return _Desg_ID; }
            set { _Desg_ID = value; }
        }
        string _Desg_Name;
        public string Desg_Name
        {
            get { return _Desg_Name; }
            set { _Desg_Name = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLWorkStatus
    {
        Int32 _WorkStatus_ID;
        public Int32 WorkStatus_ID
        {
            get { return _WorkStatus_ID; }
            set { _WorkStatus_ID = value; }
        }
        string _WorkStatus_Name;
        public string WorkStatus_Name
        {
            get { return _WorkStatus_Name; }
            set { _WorkStatus_Name = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLWorkType
    {
        Int32 _WorkType_ID;
        public Int32 WorkType_ID
        {
            get { return _WorkType_ID; }
            set { _WorkType_ID = value; }
        }
        string _WorkType_Name;
        public string WorkType_Name
        {
            get { return _WorkType_Name; }
            set { _WorkType_Name = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLPatientMaster
    {

        Int32 _Patient_ID;
        public Int32 Patient_ID
        {
            get { return _Patient_ID; }
            set { _Patient_ID = value; }
        }
        string _Patient_Name;
        public string Patient_Name
        {
            get { return _Patient_Name; }
            set { _Patient_Name = value; }
        }
        decimal _Patient_CrNo;
        public decimal Patient_CrNo
        {
            get { return _Patient_CrNo; }
            set { _Patient_CrNo = value; }
        }
        DateTime? _Patient_DateOfBirth;
        public DateTime? Patient_DateOfBirth
        {
            get { return _Patient_DateOfBirth; }
            set { _Patient_DateOfBirth = value; }
        }
        string _Patient_Gender;
        public string Patient_Gender
        {
            get { return _Patient_Gender; }
            set { _Patient_Gender = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }

    }

    public class BOLSurgicalPathologyReport
    {

        Int32 _Sur_Path_ID;
        public Int32 Sur_Path_ID
        {
            get { return _Sur_Path_ID; }
            set { _Sur_Path_ID = value; }
        }
        string _Sur_Path_BiopsyNo;
        public string Sur_Path_BiopsyNo
        {
            get { return _Sur_Path_BiopsyNo; }
            set { _Sur_Path_BiopsyNo = value; }
        }
        string _Sur_Path_ClinicNo;
        public string Sur_Path_ClinicNo
        {
            get { return _Sur_Path_ClinicNo; }
            set { _Sur_Path_ClinicNo = value; }
        }
        DateTime? _Sur_Path_ReqDate;
        public DateTime? Sur_Path_ReqDate
        {
            get { return _Sur_Path_ReqDate; }
            set { _Sur_Path_ReqDate = value; }
        }
        string _Sur_Path_Clinician;
        public string Sur_Path_Clinician
        {
            get { return _Sur_Path_Clinician; }
            set { _Sur_Path_Clinician = value; }
        }

        string _Sur_Path_CrNo;
        public string Sur_Path_CrNo
        {
            get { return _Sur_Path_CrNo; }
            set { _Sur_Path_CrNo = value; }
        }

        string _Sur_Path_AdmissionNo;
        public string Sur_Path_AdmissionNo
        {
            get { return _Sur_Path_AdmissionNo; }
            set { _Sur_Path_AdmissionNo = value; }
        }

        string _Sur_Path_ClinicalDiag;
        public string Sur_Path_ClinicalDiag
        {
            get { return _Sur_Path_ClinicalDiag; }
            set { _Sur_Path_ClinicalDiag = value; }
        }

        string _Sur_Path_PatientName;
        public string Sur_Path_PatientName
        {
            get { return _Sur_Path_PatientName; }
            set { _Sur_Path_PatientName = value; }
        }

        string _Sur_Path_AdditionalInfo;
        public string Sur_Path_AdditionalInfo
        {
            get { return _Sur_Path_AdditionalInfo; }
            set { _Sur_Path_AdditionalInfo = value; }
        }

        string _Sur_Path_Address;
        public string Sur_Path_Address
        {
            get { return _Sur_Path_Address; }
            set { _Sur_Path_Address = value; }
        }


        string _Sur_Path_PrvBiopsie;
        public string Sur_Path_PrvBiopsie
        {
            get { return _Sur_Path_PrvBiopsie; }
            set { _Sur_Path_PrvBiopsie = value; }
        }

        string _Sur_Path_AgeY;
        public string Sur_Path_AgeY
        {
            get { return _Sur_Path_AgeY; }
            set { _Sur_Path_AgeY = value; }
        }

        string _Sur_Path_AgeM;
        public string Sur_Path_AgeM
        {
            get { return _Sur_Path_AgeM; }
            set { _Sur_Path_AgeM = value; }
        }

        string _Sur_Path_AgeD;
        public string Sur_Path_AgeD
        {
            get { return _Sur_Path_AgeD; }
            set { _Sur_Path_AgeD = value; }
        }

        string _Sur_Path_Sex;
        public string Sur_Path_Sex
        {
            get { return _Sur_Path_Sex; }
            set { _Sur_Path_Sex = value; }
        }

        string _Sur_Path_Typist;
        public string Sur_Path_Typist
        {
            get { return _Sur_Path_Typist; }
            set { _Sur_Path_Typist = value; }
        }

        string _Sur_Path_Location;
        public string Sur_Path_Location
        {
            get { return _Sur_Path_Location; }
            set { _Sur_Path_Location = value; }
        }

        string _Sur_Path_BedNo;
        public string Sur_Path_BedNo
        {
            get { return _Sur_Path_BedNo; }
            set { _Sur_Path_BedNo = value; }
        }

        string _Sur_Path_Gross;
        public string Sur_Path_Gross
        {
            get { return _Sur_Path_Gross; }
            set { _Sur_Path_Gross = value; }
        }

        string _Sur_Path_Micro;
        public string Sur_Path_Micro
        {
            get { return _Sur_Path_Micro; }
            set { _Sur_Path_Micro = value; }
        }

        string _Sur_Path_Immunohistology;
        public string Sur_Path_Immunohistology
        {
            get { return _Sur_Path_Immunohistology; }
            set { _Sur_Path_Immunohistology = value; }
        }

        string _Sur_Path_SupplementaryReport;
        public string Sur_Path_SupplementaryReport
        {
            get { return _Sur_Path_SupplementaryReport; }
            set { _Sur_Path_SupplementaryReport = value; }
        }

        string _Sur_Path_Remarks;
        public string Sur_Path_Remarks
        {
            get { return _Sur_Path_Remarks; }
            set { _Sur_Path_Remarks = value; }
        }

        DateTime? _Sur_Path_Dated;
        public DateTime? Sur_Path_Dated
        {
            get { return _Sur_Path_Dated; }
            set { _Sur_Path_Dated = value; }
        }

        string _Sur_Path_Res;
        public string Sur_Path_Res
        {
            get { return _Sur_Path_Res; }
            set { _Sur_Path_Res = value; }
        }

        string _Sur_Path_Faculty1;
        public string Sur_Path_Faculty1
        {
            get { return _Sur_Path_Faculty1; }
            set { _Sur_Path_Faculty1 = value; }
        }

        string _Sur_Path_Faculty2;
        public string Sur_Path_Faculty2
        {
            get { return _Sur_Path_Faculty2; }
            set { _Sur_Path_Faculty2 = value; }
        }

        string _Sur_Path_Faculty3;
        public string Sur_Path_Faculty3
        {
            get { return _Sur_Path_Faculty3; }
            set { _Sur_Path_Faculty3 = value; }
        }

        Boolean _Sur_Path_Ok;
        public Boolean Sur_Path_Ok
        {
            get { return _Sur_Path_Ok; }
            set { _Sur_Path_Ok = value; }
        }

        DateTime? _Sur_Path_RecDate;
        public DateTime? Sur_Path_RecDate
        {
            get { return _Sur_Path_RecDate; }
            set { _Sur_Path_RecDate = value; }
        }
        string _Sur_Path_RecCooments;
        public string Sur_Path_RecCooments
        {
            get { return _Sur_Path_RecCooments; }
            set { _Sur_Path_RecCooments = value; }
        }

        DateTime? _Sur_Path_GrossedDate;
        public DateTime? Sur_Path_GrossedDate
        {
            get { return _Sur_Path_GrossedDate; }
            set { _Sur_Path_GrossedDate = value; }
        }
        string _Sur_Path_GrossedComments;
        public string Sur_Path_GrossedComments
        {
            get { return _Sur_Path_GrossedComments; }
            set { _Sur_Path_GrossedComments = value; }
        }

        DateTime? _Sur_Path_ProcessedDate;
        public DateTime? Sur_Path_ProcessedDate
        {
            get { return _Sur_Path_ProcessedDate; }
            set { _Sur_Path_ProcessedDate = value; }
        }
        string _Sur_Path_ProcessedComments;
        public string Sur_Path_ProcessedComments
        {
            get { return _Sur_Path_ProcessedComments; }
            set { _Sur_Path_ProcessedComments = value; }
        }

        DateTime? _Sur_Path_BlockedDate;
        public DateTime? Sur_Path_BlockedDate
        {
            get { return _Sur_Path_BlockedDate; }
            set { _Sur_Path_BlockedDate = value; }
        }
        string _Sur_Path_BlockedComments;
        public string Sur_Path_BlockedComments
        {
            get { return _Sur_Path_BlockedComments; }
            set { _Sur_Path_BlockedComments = value; }
        }

        DateTime? _Sur_Path_SectionedDate;
        public DateTime? Sur_Path_SectionedDate
        {
            get { return _Sur_Path_SectionedDate; }
            set { _Sur_Path_SectionedDate = value; }
        }
        string _Sur_Path_SectionedComments;
        public string Sur_Path_SectionedComments
        {
            get { return _Sur_Path_SectionedComments; }
            set { _Sur_Path_SectionedComments = value; }
        }

        DateTime? _Sur_Path_StainedDate;
        public DateTime? Sur_Path_StainedDate
        {
            get { return _Sur_Path_StainedDate; }
            set { _Sur_Path_StainedDate = value; }
        }
        string _Sur_Path_StainedComments;
        public string Sur_Path_StainedComments
        {
            get { return _Sur_Path_StainedComments; }
            set { _Sur_Path_StainedComments = value; }
        }
        DateTime? _Sur_Path_ReportedDate;
        public DateTime? Sur_Path_ReportedDate
        {
            get { return _Sur_Path_ReportedDate; }
            set { _Sur_Path_ReportedDate = value; }
        }
        string _Sur_Path_ReportedComments;
        public string Sur_Path_ReportedComments
        {
            get { return _Sur_Path_ReportedComments; }
            set { _Sur_Path_ReportedComments = value; }
        }

        string _Sur_Path_SpecialStain;
        public string Sur_Path_SpecialStain
        {
            get { return _Sur_Path_SpecialStain; }
            set { _Sur_Path_SpecialStain = value; }
        }
        string _Sur_Path_Immunohistochemistry;
        public string Sur_Path_Immunohistochemistry
        {
            get { return _Sur_Path_Immunohistochemistry; }
            set { _Sur_Path_Immunohistochemistry = value; }
        }
        Int32 _PatientID;
        public Int32 PatientID
        {
            get { return _PatientID; }
            set { _PatientID = value; }
        }

        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLSurgicalPathologyReportDetail
    {

        Int32 _Sur_Path_ID_Detail;
        public Int32 Sur_Path_ID_Detail
        {
            get { return _Sur_Path_ID_Detail; }
            set { _Sur_Path_ID_Detail = value; }
        }

        Int32 _Sur_Path_ID;
        public Int32 Sur_Path_ID
        {
            get { return _Sur_Path_ID; }
            set { _Sur_Path_ID = value; }
        }

        string _Sur_Path_Gross;
        public string Sur_Path_Gross
        {
            get { return _Sur_Path_Gross; }
            set { _Sur_Path_Gross = value; }
        }

        string _Sur_Path_Micro;
        public string Sur_Path_Micro
        {
            get { return _Sur_Path_Micro; }
            set { _Sur_Path_Micro = value; }
        }

        string _Sur_Path_Immunohistology;
        public string Sur_Path_Immunohistology
        {
            get { return _Sur_Path_Immunohistology; }
            set { _Sur_Path_Immunohistology = value; }
        }

        string _Sur_Path_SupplementaryReport;
        public string Sur_Path_SupplementaryReport
        {
            get { return _Sur_Path_SupplementaryReport; }
            set { _Sur_Path_SupplementaryReport = value; }
        }

        string _Sur_Path_Remarks;
        public string Sur_Path_Remarks
        {
            get { return _Sur_Path_Remarks; }
            set { _Sur_Path_Remarks = value; }
        }

        DateTime? _Sur_Path_Dated;
        public DateTime? Sur_Path_Dated
        {
            get { return _Sur_Path_Dated; }
            set { _Sur_Path_Dated = value; }
        }

        string _Sur_Path_Res;
        public string Sur_Path_Res
        {
            get { return _Sur_Path_Res; }
            set { _Sur_Path_Res = value; }
        }

        string _Sur_Path_Faculty1;
        public string Sur_Path_Faculty1
        {
            get { return _Sur_Path_Faculty1; }
            set { _Sur_Path_Faculty1 = value; }
        }

        string _Sur_Path_Faculty2;
        public string Sur_Path_Faculty2
        {
            get { return _Sur_Path_Faculty2; }
            set { _Sur_Path_Faculty2 = value; }
        }

        string _Sur_Path_Faculty3;
        public string Sur_Path_Faculty3
        {
            get { return _Sur_Path_Faculty3; }
            set { _Sur_Path_Faculty3 = value; }
        }

        Boolean _Sur_Path_Ok;
        public Boolean Sur_Path_Ok
        {
            get { return _Sur_Path_Ok; }
            set { _Sur_Path_Ok = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLAutopsyReport
    {

        Int32 _Autopsy_Path_ID;
        public Int32 Autopsy_Path_ID
        {
            get { return _Autopsy_Path_ID; }
            set { _Autopsy_Path_ID = value; }
        }
        string _Autopsy_Path_PMNo;
        public string Autopsy_Path_PMNo
        {
            get { return _Autopsy_Path_PMNo; }
            set { _Autopsy_Path_PMNo = value; }
        }
        string _Autopsy_Path_AdmissionNo;
        public string Autopsy_Path_AdmissionNo
        {
            get { return _Autopsy_Path_AdmissionNo; }
            set { _Autopsy_Path_AdmissionNo = value; }
        }
        Int32 _Autopsy_Path_CategoryID;
        public Int32 Autopsy_Path_CategoryID
        {
            get { return _Autopsy_Path_CategoryID; }
            set { _Autopsy_Path_CategoryID = value; }
        }
        string _Autopsy_Path_Location;
        public string Autopsy_Path_Location
        {
            get { return _Autopsy_Path_Location; }
            set { _Autopsy_Path_Location = value; }
        }

        Int32 _Autopsy_Path_CategoryTypeID;
        public Int32 Autopsy_Path_CategoryTypeID
        {
            get { return _Autopsy_Path_CategoryTypeID; }
            set { _Autopsy_Path_CategoryTypeID = value; }
        }

        string _Autopsy_Path_BedNo;
        public string Autopsy_Path_BedNo
        {
            get { return _Autopsy_Path_BedNo; }
            set { _Autopsy_Path_BedNo = value; }
        }

        string _Autopsy_Path_PatientName;
        public string Autopsy_Path_PatientName
        {
            get { return _Autopsy_Path_PatientName; }
            set { _Autopsy_Path_PatientName = value; }
        }

        string _Autopsy_Path_ClinicNo;
        public string Autopsy_Path_ClinicNo
        {
            get { return _Autopsy_Path_ClinicNo; }
            set { _Autopsy_Path_ClinicNo = value; }
        }

        string _Sur_Path_AdditionalInfo;
        public string Sur_Path_AdditionalInfo
        {
            get { return _Sur_Path_AdditionalInfo; }
            set { _Sur_Path_AdditionalInfo = value; }
        }

        string _Autopsy_Path_AgeY;
        public string Autopsy_Path_AgeY
        {
            get { return _Autopsy_Path_AgeY; }
            set { _Autopsy_Path_AgeY = value; }
        }

        string _Autopsy_Path_AgeM;
        public string Autopsy_Path_AgeM
        {
            get { return _Autopsy_Path_AgeM; }
            set { _Autopsy_Path_AgeM = value; }
        }

        string _Autopsy_Path_AgeD;
        public string Autopsy_Path_AgeD
        {
            get { return _Autopsy_Path_AgeD; }
            set { _Autopsy_Path_AgeD = value; }
        }
        string _Autopsy_Path_Clinician;
        public string Autopsy_Path_Clinician
        {
            get { return _Autopsy_Path_Clinician; }
            set { _Autopsy_Path_Clinician = value; }
        }
        string _Autopsy_Path_Sex;
        public string Autopsy_Path_Sex
        {
            get { return _Autopsy_Path_Sex; }
            set { _Autopsy_Path_Sex = value; }
        }
        string _Autopsy_Path_CrNo;
        public string Autopsy_Path_CrNo
        {
            get { return _Autopsy_Path_CrNo; }
            set { _Autopsy_Path_CrNo = value; }
        }
        string _Autopsy_Path_ClinicalDiag;
        public string Autopsy_Path_ClinicalDiag
        {
            get { return _Autopsy_Path_ClinicalDiag; }
            set { _Autopsy_Path_ClinicalDiag = value; }
        }

        string _Autopsy_Path_Address;
        public string Autopsy_Path_Address
        {
            get { return _Autopsy_Path_Address; }
            set { _Autopsy_Path_Address = value; }
        }

        string _Autopsy_Path_Biopsies;
        public string Autopsy_Path_Biopsies
        {
            get { return _Autopsy_Path_Biopsies; }
            set { _Autopsy_Path_Biopsies = value; }
        }

        DateTime? _Autopsy_Path_AddDate;
        public DateTime? Autopsy_Path_AddDate
        {
            get { return _Autopsy_Path_AddDate; }
            set { _Autopsy_Path_AddDate = value; }
        }

        DateTime? _Autopsy_Path_DeathDate;
        public DateTime? Autopsy_Path_DeathDate
        {
            get { return _Autopsy_Path_DeathDate; }
            set { _Autopsy_Path_DeathDate = value; }
        }

        string _Autopsy_Path_DeathTime;
        public string Autopsy_Path_DeathTime
        {
            get { return _Autopsy_Path_DeathTime; }
            set { _Autopsy_Path_DeathTime = value; }
        }

        string _Autopsy_Path_Prosector;
        public string Autopsy_Path_Prosector
        {
            get { return _Autopsy_Path_Prosector; }
            set { _Autopsy_Path_Prosector = value; }
        }
        DateTime? _Autopsy_Path_AutopsyDate;
        public DateTime? Autopsy_Path_AutopsyDate
        {
            get { return _Autopsy_Path_AutopsyDate; }
            set { _Autopsy_Path_AutopsyDate = value; }
        }
        string _Autopsy_Path_AutopsyTime;
        public string Autopsy_Path_AutopsyTime
        {
            get { return _Autopsy_Path_AutopsyTime; }
            set { _Autopsy_Path_AutopsyTime = value; }
        }
        string _Autopsy_Path_Typist;
        public string Autopsy_Path_Typist
        {
            get { return _Autopsy_Path_Typist; }
            set { _Autopsy_Path_Typist = value; }
        }
        string _Autopsy_Path_Incision;
        public string Autopsy_Path_Incision
        {
            get { return _Autopsy_Path_Incision; }
            set { _Autopsy_Path_Incision = value; }
        }
        String _Autopsy_Path_ExternalFeature;
        public String Autopsy_Path_ExternalFeature
        {
            get { return _Autopsy_Path_ExternalFeature; }
            set { _Autopsy_Path_ExternalFeature = value; }
        }

        string _Autopsy_Path_QuantityPericardial;
        public string Autopsy_Path_QuantityPericardial
        {
            get { return _Autopsy_Path_QuantityPericardial; }
            set { _Autopsy_Path_QuantityPericardial = value; }
        }

        string _Autopsy_Path_QuantityLPleural;
        public string Autopsy_Path_QuantityLPleural
        {
            get { return _Autopsy_Path_QuantityLPleural; }
            set { _Autopsy_Path_QuantityLPleural = value; }
        }

        string _Autopsy_Path_QuantityRPleural;
        public string Autopsy_Path_QuantityRPleural
        {
            get { return _Autopsy_Path_QuantityRPleural; }
            set { _Autopsy_Path_QuantityRPleural = value; }
        }

        string _Autopsy_Path_QuantityPeritonal;
        public string Autopsy_Path_QuantityPeritonal
        {
            get { return _Autopsy_Path_QuantityPeritonal; }
            set { _Autopsy_Path_QuantityPeritonal = value; }
        }

        string _Autopsy_Path_CharacterPericardial;
        public string Autopsy_Path_CharacterPericardial
        {
            get { return _Autopsy_Path_CharacterPericardial; }
            set { _Autopsy_Path_CharacterPericardial = value; }
        }

        String _Autopsy_Path_CharacterLPleural;
        public String Autopsy_Path_CharacterLPleural
        {
            get { return _Autopsy_Path_CharacterLPleural; }
            set { _Autopsy_Path_CharacterLPleural = value; }
        }
        string _Autopsy_Path_CharacterRPleural;
        public string Autopsy_Path_CharacterRPleural
        {
            get { return _Autopsy_Path_CharacterRPleural; }
            set { _Autopsy_Path_CharacterRPleural = value; }
        }

        string _Autopsy_Path_CharacterPeritonal;
        public string Autopsy_Path_CharacterPeritonal
        {
            get { return _Autopsy_Path_CharacterPeritonal; }
            set { _Autopsy_Path_CharacterPeritonal = value; }
        }

        String _Autopsy_Path_Material;
        public String Autopsy_Path_Material
        {
            get { return _Autopsy_Path_Material; }
            set { _Autopsy_Path_Material = value; }
        }

        string _Autopsy_Path_Serology1;
        public string Autopsy_Path_Serology1
        {
            get { return _Autopsy_Path_Serology1; }
            set { _Autopsy_Path_Serology1 = value; }
        }

        String _Autopsy_Path_Serology2;
        public String Autopsy_Path_Serology2
        {
            get { return _Autopsy_Path_Serology2; }
            set { _Autopsy_Path_Serology2 = value; }
        }
        string _Autopsy_Path_Immunoflourescence;
        public string Autopsy_Path_Immunoflourescence
        {
            get { return _Autopsy_Path_Immunoflourescence; }
            set { _Autopsy_Path_Immunoflourescence = value; }
        }

        String _Autopsy_Path_Immunoglobulins;
        public String Autopsy_Path_Immunoglobulins
        {
            get { return _Autopsy_Path_Immunoglobulins; }
            set { _Autopsy_Path_Immunoglobulins = value; }
        }
        string _Autopsy_Path_EMStudies;
        public string Autopsy_Path_EMStudies
        {
            get { return _Autopsy_Path_EMStudies; }
            set { _Autopsy_Path_EMStudies = value; }
        }
        String _Autopsy_Path_TypeofMaterial;
        public String Autopsy_Path_TypeofMaterial
        {
            get { return _Autopsy_Path_TypeofMaterial; }
            set { _Autopsy_Path_TypeofMaterial = value; }
        }
        string _Autopsy_Path_Micro;
        public string Autopsy_Path_Micro
        {
            get { return _Autopsy_Path_Micro; }
            set { _Autopsy_Path_Micro = value; }
        }

        string _Autopsy_Path_FinalAutopsyDiagnosis;
        public string Autopsy_Path_FinalAutopsyDiagnosis
        {
            get { return _Autopsy_Path_FinalAutopsyDiagnosis; }
            set { _Autopsy_Path_FinalAutopsyDiagnosis = value; }
        }
        DateTime? _Autopsy_Path_Dated;
        public DateTime? Autopsy_Path_Dated
        {
            get { return _Autopsy_Path_Dated; }
            set { _Autopsy_Path_Dated = value; }
        }
        string _Autopsy_Path_Res;
        public string Autopsy_Path_Res
        {
            get { return _Autopsy_Path_Res; }
            set { _Autopsy_Path_Res = value; }
        }

        string _Autopsy_Path_Faculty1;
        public string Autopsy_Path_Faculty1
        {
            get { return _Autopsy_Path_Faculty1; }
            set { _Autopsy_Path_Faculty1 = value; }
        }
        string _Autopsy_Path_Faculty2;
        public string Autopsy_Path_Faculty2
        {
            get { return _Autopsy_Path_Faculty2; }
            set { _Autopsy_Path_Faculty2 = value; }
        }

        string _Autopsy_Path_Faculty3;
        public string Autopsy_Path_Faculty3
        {
            get { return _Autopsy_Path_Faculty3; }
            set { _Autopsy_Path_Faculty3 = value; }
        }
        Boolean _Autopsy_Path_Ok;
        public Boolean Autopsy_Path_Ok
        {
            get { return _Autopsy_Path_Ok; }
            set { _Autopsy_Path_Ok = value; }
        }
        string _Autopsy_Path_GestationalAge;
        public string Autopsy_Path_GestationalAge
        {
            get { return _Autopsy_Path_GestationalAge; }
            set { _Autopsy_Path_GestationalAge = value; }
        }

        string _Autopsy_Path_Facies;
        public string Autopsy_Path_Facies
        {
            get { return _Autopsy_Path_Facies; }
            set { _Autopsy_Path_Facies = value; }
        }

        string _Autopsy_Path_UmbilicalCordNo;
        public string Autopsy_Path_UmbilicalCordNo
        {
            get { return _Autopsy_Path_UmbilicalCordNo; }
            set { _Autopsy_Path_UmbilicalCordNo = value; }
        }

        string _Autopsy_Path_Veins;
        public string Autopsy_Path_Veins
        {
            get { return _Autopsy_Path_Veins; }
            set { _Autopsy_Path_Veins = value; }
        }
        string _Autopsy_Path_Catheter;
        public string Autopsy_Path_Catheter
        {
            get { return _Autopsy_Path_Catheter; }
            set { _Autopsy_Path_Catheter = value; }
        }

        string _Autopsy_Path_Haemorrhage;
        public string Autopsy_Path_Haemorrhage
        {
            get { return _Autopsy_Path_Haemorrhage; }
            set { _Autopsy_Path_Haemorrhage = value; }
        }

        string _Autopsy_Path_Exudate;
        public string Autopsy_Path_Exudate
        {
            get { return _Autopsy_Path_Exudate; }
            set { _Autopsy_Path_Exudate = value; }
        }


        string _Autopsy_Path_OtherAbnormality;
        public string Autopsy_Path_OtherAbnormality
        {
            get { return _Autopsy_Path_OtherAbnormality; }
            set { _Autopsy_Path_OtherAbnormality = value; }
        }

        string _Autopsy_Path_Pneumothorax;
        public string Autopsy_Path_Pneumothorax
        {
            get { return _Autopsy_Path_Pneumothorax; }
            set { _Autopsy_Path_Pneumothorax = value; }
        }

        string _Autopsy_Path_NoOfLobesLeft;
        public string Autopsy_Path_NoOfLobesLeft
        {
            get { return _Autopsy_Path_NoOfLobesLeft; }
            set { _Autopsy_Path_NoOfLobesLeft = value; }
        }
        string _Autopsy_Path_NoOfLobesRight;
        public string Autopsy_Path_NoOfLobesRight
        {
            get { return _Autopsy_Path_NoOfLobesRight; }
            set { _Autopsy_Path_NoOfLobesRight = value; }
        }
        string _Autopsy_Path_DuctusArteriosus;
        public string Autopsy_Path_DuctusArteriosus
        {
            get { return _Autopsy_Path_DuctusArteriosus; }
            set { _Autopsy_Path_DuctusArteriosus = value; }
        }
        string _Autopsy_Path_Diameter;
        public string Autopsy_Path_Diameter
        {
            get { return _Autopsy_Path_Diameter; }
            set { _Autopsy_Path_Diameter = value; }
        }

        string _Autopsy_Path_Placenta;
        public string Autopsy_Path_Placenta
        {
            get { return _Autopsy_Path_Placenta; }
            set { _Autopsy_Path_Placenta = value; }
        }

        string _Autopsy_Path_CrowntoHeelLengthResult;
        public string Autopsy_Path_CrowntoHeelLengthResult
        {
            get { return _Autopsy_Path_CrowntoHeelLengthResult; }
            set { _Autopsy_Path_CrowntoHeelLengthResult = value; }
        }
        string _Autopsy_Path_CrowntoHeelLengthNormal;
        public string Autopsy_Path_CrowntoHeelLengthNormal
        {
            get { return _Autopsy_Path_CrowntoHeelLengthNormal; }
            set { _Autopsy_Path_CrowntoHeelLengthNormal = value; }
        }

        string _Autopsy_Path_CrowntoRumpLengthResult;
        public string Autopsy_Path_CrowntoRumpLengthResult
        {
            get { return _Autopsy_Path_CrowntoRumpLengthResult; }
            set { _Autopsy_Path_CrowntoRumpLengthResult = value; }
        }
        string _Autopsy_Path_CrowntoRumpLengthNormal;
        public string Autopsy_Path_CrowntoRumpLengthNormal
        {
            get { return _Autopsy_Path_CrowntoRumpLengthNormal; }
            set { _Autopsy_Path_CrowntoRumpLengthNormal = value; }
        }
        string _Autopsy_Path_HeadCircumferenceResult;
        public string Autopsy_Path_HeadCircumferenceResult
        {
            get { return _Autopsy_Path_HeadCircumferenceResult; }
            set { _Autopsy_Path_HeadCircumferenceResult = value; }
        }
        string _Autopsy_Path_HeadCircumferenceNormal;
        public string Autopsy_Path_HeadCircumferenceNormal
        {
            get { return _Autopsy_Path_HeadCircumferenceNormal; }
            set { _Autopsy_Path_HeadCircumferenceNormal = value; }
        }
        string _Autopsy_Path_ChestCircumferenceResult;
        public string Autopsy_Path_ChestCircumferenceResult
        {
            get { return _Autopsy_Path_ChestCircumferenceResult; }
            set { _Autopsy_Path_ChestCircumferenceResult = value; }
        }
        string _Autopsy_Path_ChestCircumferenceNormal;
        public string Autopsy_Path_ChestCircumferenceNormal
        {
            get { return _Autopsy_Path_ChestCircumferenceNormal; }
            set { _Autopsy_Path_ChestCircumferenceNormal = value; }
        }

        string _Autopsy_Path_FootLengthResult;
        public string Autopsy_Path_FootLengthResult
        {
            get { return _Autopsy_Path_FootLengthResult; }
            set { _Autopsy_Path_FootLengthResult = value; }
        }

        string _Autopsy_Path_FootLengthNormal;
        public string Autopsy_Path_FootLengthNormal
        {
            get { return _Autopsy_Path_FootLengthNormal; }
            set { _Autopsy_Path_FootLengthNormal = value; }
        }
        string _Autopsy_Path_WeightAtBirthResult;
        public string Autopsy_Path_WeightAtBirthResult
        {
            get { return _Autopsy_Path_WeightAtBirthResult; }
            set { _Autopsy_Path_WeightAtBirthResult = value; }
        }
        string _Autopsy_Path_WeightAtBirthNormal;
        public string Autopsy_Path_WeightAtBirthNormal
        {
            get { return _Autopsy_Path_WeightAtBirthNormal; }
            set { _Autopsy_Path_WeightAtBirthNormal = value; }
        }
        string _Autopsy_Path_WeightAtAutopsyResult;
        public string Autopsy_Path_WeightAtAutopsyResult
        {
            get { return _Autopsy_Path_WeightAtAutopsyResult; }
            set { _Autopsy_Path_WeightAtAutopsyResult = value; }
        }
        string _Autopsy_Path_WeightAtAutopsyNormal;
        public string Autopsy_Path_WeightAtAutopsyNormal
        {
            get { return _Autopsy_Path_WeightAtAutopsyNormal; }
            set { _Autopsy_Path_WeightAtAutopsyNormal = value; }
        }
        string _Autopsy_Path_Remarks;
        public string Autopsy_Path_Remarks
        {
            get { return _Autopsy_Path_Remarks; }
            set { _Autopsy_Path_Remarks = value; }
        }
        string _Autopsy_Path_GrossAutopsyDiagnose;
        public string Autopsy_Path_GrossAutopsyDiagnose
        {
            get { return _Autopsy_Path_GrossAutopsyDiagnose; }
            set { _Autopsy_Path_GrossAutopsyDiagnose = value; }
        }
        string _Autopsy_Path_Residents;
        public string Autopsy_Path_Residents
        {
            get { return _Autopsy_Path_Residents; }
            set { _Autopsy_Path_Residents = value; }
        }
        string _Autopsy_Path_GrossAutopsyDiagnose2;
        public string Autopsy_Path_GrossAutopsyDiagnose2
        {
            get { return _Autopsy_Path_GrossAutopsyDiagnose2; }
            set { _Autopsy_Path_GrossAutopsyDiagnose2 = value; }
        }
        string _Autopsy_Path_GrossAutopsyDiagnose2Faculty1;
        public string Autopsy_Path_GrossAutopsyDiagnose2Faculty1
        {
            get { return _Autopsy_Path_GrossAutopsyDiagnose2Faculty1; }
            set { _Autopsy_Path_GrossAutopsyDiagnose2Faculty1 = value; }
        }
        string _Autopsy_Path_GrossAutopsyDiagnose2Faculty2;
        public string Autopsy_Path_GrossAutopsyDiagnose2Faculty2
        {
            get { return _Autopsy_Path_GrossAutopsyDiagnose2Faculty2; }
            set { _Autopsy_Path_GrossAutopsyDiagnose2Faculty2 = value; }
        }
        string _Autopsy_Path_GrossAutopsyDiagnose2Faculty3;
        public string Autopsy_Path_GrossAutopsyDiagnose2Faculty3
        {
            get { return _Autopsy_Path_GrossAutopsyDiagnose2Faculty3; }
            set { _Autopsy_Path_GrossAutopsyDiagnose2Faculty3 = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLDiagnosis
    {
        Int32 _DiagID;
        public Int32 DiagID
        {
            get { return _DiagID; }
            set { _DiagID = value; }
        }
        Int32 _Sur_Path_ID_Detail;
        public Int32 Sur_Path_ID_Detail
        {
            get { return _Sur_Path_ID_Detail; }
            set { _Sur_Path_ID_Detail = value; }
        }

        Int32 _TopographyID;
        public Int32 TopographyID
        {
            get { return _TopographyID; }
            set { _TopographyID = value; }
        }
        Int32 _MorphologyID;
        public Int32 MorphologyID
        {
            get { return _MorphologyID; }
            set { _MorphologyID = value; }
        }

        String _AdditionalInfo;
        public String AdditionalInfo
        {
            get { return _AdditionalInfo; }
            set { _AdditionalInfo = value; }
        }

        String _Prefix;
        public String Prefix
        {
            get { return _Prefix; }
            set { _Prefix = value; }
        }

        String _Sufix;
        public String Sufix
        {
            get { return _Sufix; }
            set { _Sufix = value; }
        }


        Int32 _PatientID;
        public Int32 PatientID
        {
            get { return _PatientID; }
            set { _PatientID = value; }
        }

        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLDiagnosisAutopsy
    {
        Int32 _DiagIDAutopsy;
        public Int32 DiagIDAutopsy
        {
            get { return _DiagIDAutopsy; }
            set { _DiagIDAutopsy = value; }
        }
        Int32 _Autopsy_Path_ID;
        public Int32 Autopsy_Path_ID
        {
            get { return _Autopsy_Path_ID; }
            set { _Autopsy_Path_ID = value; }
        }

        Int32 _TopographyID;
        public Int32 TopographyID
        {
            get { return _TopographyID; }
            set { _TopographyID = value; }
        }
        Int32 _MorphologyID;
        public Int32 MorphologyID
        {
            get { return _MorphologyID; }
            set { _MorphologyID = value; }
        }

        String _AdditionalInfoAutopsy;
        public String AdditionalInfoAutopsy
        {
            get { return _AdditionalInfoAutopsy; }
            set { _AdditionalInfoAutopsy = value; }
        }

        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLCPCAutopsy
    {

        Int32 _CPCID;
        public Int32 CPCID
        {
            get { return _CPCID; }
            set { _CPCID = value; }
        }

        Boolean _CPCDone;
        public Boolean CPCDone
        {
            get { return _CPCDone; }
            set { _CPCDone = value; }
        }

        String _CPCDoneBy;
        public String CPCDoneBy
        {
            get { return _CPCDoneBy; }
            set { _CPCDoneBy = value; }
        }

        String _CPCDoneName;
        public String CPCDoneName
        {
            get { return _CPCDoneName; }
            set { _CPCDoneName = value; }
        }
        DateTime? _CPCDoneDate;
        public DateTime? CPCDoneDate
        {
            get { return _CPCDoneDate; }
            set { _CPCDoneDate = value; }
        }

        Int32 _Autopsy_Path_ID;
        public Int32 Autopsy_Path_ID
        {
            get { return _Autopsy_Path_ID; }
            set { _Autopsy_Path_ID = value; }
        }

        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLNotepad
    {
        Int32 _Work_ID;
        public Int32 Work_ID
        {
            get { return _Work_ID; }
            set { _Work_ID = value; }
        }
        string _Work_Name;
        public string Work_Name
        {
            get { return _Work_Name; }
            set { _Work_Name = value; }
        }
        Boolean _Work_Status;
        public Boolean Work_Status
        {
            get { return _Work_Status; }
            set { _Work_Status = value; }
        }
        Int32 _UserID;
        public Int32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLPaymentDetails
    {

        Int32 _Payment_ID;
        public Int32 Payment_ID
        {
            get { return _Payment_ID; }
            set { _Payment_ID = value; }
        }

        Int32 _UserID;
        public Int32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        Decimal _Payment_Amount;
        public Decimal Payment_Amount
        {
            get { return _Payment_Amount; }
            set { _Payment_Amount = value; }
        }

        string _Payment_Mode;
        public string Payment_Mode
        {
            get { return _Payment_Mode; }
            set { _Payment_Mode = value; }
        }
        string _Payment_ChequeDDNo;
        public string Payment_ChequeDDNo
        {
            get { return _Payment_ChequeDDNo; }
            set { _Payment_ChequeDDNo = value; }
        }
        DateTime? _Payment_DateDD;
        public DateTime? Payment_DateDD
        {
            get { return _Payment_DateDD; }
            set { _Payment_DateDD = value; }
        }
        string _Payment_BankNameDD;
        public string Payment_BankNameDD
        {
            get { return _Payment_BankNameDD; }
            set { _Payment_BankNameDD = value; }
        }
        string _Payment_AccountNoDD;
        public string Payment_AccountNoDD
        {
            get { return _Payment_AccountNoDD; }
            set { _Payment_AccountNoDD = value; }
        }

        string _Payment_ScanCopyDD;
        public string Payment_ScanCopyDD
        {
            get { return _Payment_ScanCopyDD; }
            set { _Payment_ScanCopyDD = value; }
        }

        string _Payment_StatusDD;
        public string Payment_StatusDD
        {
            get { return _Payment_StatusDD; }
            set { _Payment_StatusDD = value; }
        }
        string _Payment_RemarksDD;
        public string Payment_RemarksDD
        {
            get { return _Payment_RemarksDD; }
            set { _Payment_RemarksDD = value; }
        }

        DateTime? _Payment_DateOnline;
        public DateTime? Payment_DateOnline
        {
            get { return _Payment_DateOnline; }
            set { _Payment_DateOnline = value; }
        }

        string _Payment_BankNameOnline;
        public string Payment_BankNameOnline
        {
            get { return _Payment_BankNameOnline; }
            set { _Payment_BankNameOnline = value; }
        }

        string _Payment_PlaceOnline;
        public string Payment_PlaceOnline
        {
            get { return _Payment_PlaceOnline; }
            set { _Payment_PlaceOnline = value; }
        }
        string _Payment_StatusOnline;
        public string Payment_StatusOnline
        {
            get { return _Payment_StatusOnline; }
            set { _Payment_StatusOnline = value; }
        }
        string _Payment_RemarksOnline;
        public string Payment_RemarksOnline
        {
            get { return _Payment_RemarksOnline; }
            set { _Payment_RemarksOnline = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLCustomerCategoryMaster
    {
        Int32 _CustomerCategoryID;
        public Int32 CustomerCategoryID
        {
            get { return _CustomerCategoryID; }
            set { _CustomerCategoryID = value; }
        }
        string _CustomerCategoryName;
        public string CustomerCategoryName
        {
            get { return _CustomerCategoryName; }
            set { _CustomerCategoryName = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLProductMaster
    {
        Int32 _ProductID;
        public Int32 ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        string _ProductName;
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        Int32 _ParentID;
        public Int32 ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLTrainingDetailMaster
    {
        Int32 _TrainingDetailID;
        public Int32 TrainingDetailID
        {
            get { return _TrainingDetailID; }
            set { _TrainingDetailID = value; }
        }
        string _TrainingDetailName;
        public string TrainingDetailName
        {
            get { return _TrainingDetailName; }
            set { _TrainingDetailName = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLProductSubtitle
    {
        Int32 _ProductSubtitleID;
        public Int32 ProductSubtitleID
        {
            get { return _ProductSubtitleID; }
            set { _ProductSubtitleID = value; }
        }
        Int32 _ProductID;
        public Int32 ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        string _ProductSubtitleName;
        public string ProductSubtitleName
        {
            get { return _ProductSubtitleName; }
            set { _ProductSubtitleName = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLStateDistCity
    {
        Int32 _StateID;
        public Int32 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }
        Int32 _DistrictID;
        public Int32 DistrictID
        {
            get { return _DistrictID; }
            set { _DistrictID = value; }
        }
        Int32 _CityID;
        public Int32 CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }
        String _StateName;
        public String StateName
        {
            get { return _StateName; }
            set { _StateName = value; }
        }
        String _DistrictName;
        public String DistrictName
        {
            get { return _DistrictName; }
            set { _DistrictName = value; }
        }
        String _CityName;
        public String CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLFaculty
    {
        Int32 _FacultyID;
        public Int32 FacultyID
        {
            get { return _FacultyID; }
            set { _FacultyID = value; }
        }
        String _FacultyCode;
        public String FacultyCode
        {
            get { return _FacultyCode; }
            set { _FacultyCode = value; }
        }
        String _FacultyName;
        public String FacultyName
        {
            get { return _FacultyName; }
            set { _FacultyName = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLTopography
    {
        Int32 _TopographyID;
        public Int32 TopographyID
        {
            get { return _TopographyID; }
            set { _TopographyID = value; }
        }
        String _TopographyCode;
        public String TopographyCode
        {
            get { return _TopographyCode; }
            set { _TopographyCode = value; }
        }
        String _TopographyName;
        public String TopographyName
        {
            get { return _TopographyName; }
            set { _TopographyName = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLMorphology
    {

        Int32 _MorphologyID;
        public Int32 MarphologyID
        {
            get { return _MorphologyID; }
            set { _MorphologyID = value; }
        }
        String _MorphologyCode;
        public String MorphologyCode
        {
            get { return _MorphologyCode; }
            set { _MorphologyCode = value; }
        }
        String _MorphologyName;
        public String MorphologyName
        {
            get { return _MorphologyName; }
            set { _MorphologyName = value; }
        }

        Int32 _TopographyID;
        public Int32 TopographyID
        {
            get { return _TopographyID; }
            set { _TopographyID = value; }
        }

        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLCategory
    {
        Int32 _CategoryID;
        public Int32 CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        String _CategoryName;
        public String CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLCategoryType
    {
        Int32 _CategoryTypeID;
        public Int32 CategoryTypeID
        {
            get { return _CategoryTypeID; }
            set { _CategoryTypeID = value; }
        }
        String _CategoryTypeName;
        public String CategoryTypeName
        {
            get { return _CategoryTypeName; }
            set { _CategoryTypeName = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLOrgan
    {
        Int32 _OrganID;
        public Int32 OrganID
        {
            get { return _OrganID; }
            set { _OrganID = value; }
        }
        String _OrganName;
        public String OrganName
        {
            get { return _OrganName; }
            set { _OrganName = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLSufix
    {
        Int32 _SufixID;
        public Int32 SufixID
        {
            get { return _SufixID; }
            set { _SufixID = value; }
        }
        String _SufixName;
        public String SufixName
        {
            get { return _SufixName; }
            set { _SufixName = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLPrefix
    {
        Int32 _PrefixID;
        public Int32 PrefixID
        {
            get { return _PrefixID; }
            set { _PrefixID = value; }
        }
        String _PrefixName;
        public String PrefixName
        {
            get { return _PrefixName; }
            set { _PrefixName = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLRoles
    {
        Int32 _RoleID;
        public Int32 RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; }
        }
        string _RoleName;
        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }
        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLManageEmployees
    {
        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        //Int32 _CustomerID;
        //public Int32 CustomerID
        //{
        //    get { return _CustomerID; }
        //    set { _CustomerID = value; }
        //}

        String _Branch;
        public String Branch
        {
            get { return _Branch; }
            set { _Branch = value; }
        }

        String _Passwd;
        public String Passwd
        {
            get { return _Passwd; }
            set { _Passwd = value; }
        }

        String _Username;
        public String Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        String _Department;
        public String Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        String _FirstName;
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        String _LastName;
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        String _Address;
        public String Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }

        String _StateOrProvince;
        public String StateOrProvince
        {
            get { return _StateOrProvince; }
            set { _StateOrProvince = value; }
        }

        String _CountryId;
        public String CountryId
        {
            get { return _CountryId; }
            set { _CountryId = value; }
        }

        String _PostalCode;
        public String PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }

        String _HomePhone;
        public String HomePhone
        {
            get { return _HomePhone; }
            set { _HomePhone = value; }
        }

        String _OfficeExtension;
        public String OfficeExtension
        {
            get { return _OfficeExtension; }
            set { _OfficeExtension = value; }
        }

        String _CellPhone;
        public String CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }

        String _Notes;
        public String Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        Boolean _Active;
        public Boolean Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
    }


    public class BOLManageShippers
    {
        Int32 _ShipperID;
        public Int32 ShipperID
        {
            get { return _ShipperID; }
            set { _ShipperID = value; }
        }

        Int32 _ShipperMemberID;
        public Int32 ShipperMemberID
        {
            get { return _ShipperMemberID; }
            set { _ShipperMemberID = value; }
        }


        String _FirstName;
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        String _LastName;
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        String _CompanyName;
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        String _StreetAddress;
        public String StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }
        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }

        String _StateID;
        public String StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }

        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        String _TollFree;
        public String TollFree
        {
            get { return _TollFree; }
            set { _TollFree = value; }
        }

        String _TollFax;
        public String TollFax
        {
            get { return _TollFax; }
            set { _TollFax = value; }
        }

        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }

    public class BOLManageCity
    {
        Int32 _CityID;
        public Int32 CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }

        String _CityName;
        public String CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }
        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        // Not dependent 
        DateTime? _ShipDate;
        public DateTime? ShipDate
        {
            get { return _ShipDate; }
            set { _ShipDate = value; }
        }

    }


    public class BOLManageState
    {
        Int32 _StateID;
        public Int32 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }

        String _State;
        public String State
        {
            get { return _State; }
            set { _State = value; }
        }

        String _Sabb;
        public String Sabb
        {
            get { return _Sabb; }
            set { _Sabb = value; }
        }

        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
        Int32 _CountryID;
        public Int32 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
    }

    public class BOLManageCountry
    {
        Int32 _CountryID;
        public Int32 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        String _Country;
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
    }

    public class BOLManageCompetitor
    {
        Int32 _CompetitorID;
        public Int32 CompetitorID
        {
            get { return _CompetitorID; }
            set { _CompetitorID = value; }
        }

        String _CompetitorName;
        public String CompetitorName
        {
            get { return _CompetitorName; }
            set { _CompetitorName = value; }
        }

        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
    }

    public class BOLManageCusTitle
    {
        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        String _Title;
        public String Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
    }

    public class BOLManageGillRegions
    {
        Int32 _RegionId;
        public Int32 RegionId
        {
            get { return _RegionId; }
            set { _RegionId = value; }
        }

        String _Region;
        public String Region
        {
            get { return _Region; }
            set { _Region = value; }
        }

        String _CompanyName;
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        String _StreetAddress;
        public String StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }

        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }

        String _State;
        public String State
        {
            get { return _State; }
            set { _State = value; }
        }

        String _Country;
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        String _ZipCode;
        public String ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }

        String _Phone1;
        public String Phone1
        {
            get { return _Phone1; }
            set { _Phone1 = value; }
        }

        String _Phone2;
        public String Phone2
        {
            get { return _Phone2; }
            set { _Phone2 = value; }
        }

        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        String _TollFax;
        public String TollFax
        {
            get { return _TollFax; }
            set { _TollFax = value; }
        }

        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
    }

    public class BOLManageGillTerr
    {
        Int32 _TerritoryId;
        public Int32 TerritoryId
        {
            get { return _TerritoryId; }
            set { _TerritoryId = value; }
        }

        Int32 _EmployeeId;
        public Int32 EmployeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }

        String _TerritoryName;
        public String TerritoryName
        {
            get { return _TerritoryName; }
            set { _TerritoryName = value; }
        }

        Int32 _TerrAddID;
        public Int32 TerrAddID
        {
            get { return _TerrAddID; }
            set { _TerrAddID = value; }
        }

        String _StreetAddress;
        public String StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }

        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
        String _State;
        public String State
        {
            get { return _State; }
            set { _State = value; }
        }

        String _Country;
        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        String _ZipCode;
        public String ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }
        String _Phone1;
        public String Phone1
        {
            get { return _Phone1; }
            set { _Phone1 = value; }
        }

        String _Phone2;
        public String Phone2
        {
            get { return _Phone2; }
            set { _Phone2 = value; }
        }

        String _Fax;
        public String Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
    }

    public class BOLManageUserGroup
    {
        Int32 _id;
        public Int32 id
        {
            get { return _id; }
            set { _id = value; }
        }

        String _name;
        public String name
        {
            get { return _name; }
            set { _name = value; }
        }

        String _description;
        public String description
        {
            get { return _description; }
            set { _description = value; }
        }

        Boolean _status;
        public Boolean status
        {
            get { return _status; }
            set { _status = value; }
        }

        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
    }

    //BOL Assign Menu To Groups
    public class BOLGroupName
    {
        Int32 _id;
        public Int32 id
        {
            get { return _id; }
            set { _id = value; }
        }
        String _name;
        public String name
        {
            get { return _name; }
            set { _name = value; }
        }
        String _description;
        public String description
        {
            get { return _description; }
            set { _description = value; }
        }
        Boolean _status;
        public Boolean status
        {
            get { return _status; }
            set { _status = value; }
        }
        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
        Boolean _menustatus;
        public Boolean menustatus
        {
            get { return _menustatus; }
            set { _menustatus = value; }
        }
        Int32 _menurightsid;
        public Int32 menurightsid
        {
            get { return _menurightsid; }
            set { _menurightsid = value; }
        }
        Int32 _groupid;
        public Int32 groupid
        {
            get { return _groupid; }
            set { _groupid = value; }
        }
        Int32 _menuid;
        public Int32 menuid
        {
            get { return _menuid; }
            set { _menuid = value; }
        }
        Boolean _menurightsstatus;
        public Boolean menurightsstatus
        {
            get { return _menurightsstatus; }
            set { _menurightsstatus = value; }
        }
    }
    //End BOL Assign Menu To Groups
    //Start BOL Add Users To Groups
    public class BOLAddUsersToGroups
    {
        Int32 _id;
        public Int32 id
        {
            get { return _id; }
            set { _id = value; }
        }
        Int32 _groupid;
        public Int32 groupid
        {
            get { return _groupid; }
            set { _groupid = value; }
        }
        Int32 _userid;
        public Int32 userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        Boolean _Active;
        public Boolean Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
        Boolean _status;
        public Boolean status
        {
            get { return _status; }
            set { _status = value; }
        }
        Int32 _EMPLOYEEID;
        public Int32 EmployeeID
        {
            get { return _EMPLOYEEID; }
            set { _EMPLOYEEID = value; }
        }
    }
    //End Add Users To Groups


    //BOLSTANDARDPARTS START
    public class BOLStandardParts
    {
        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
        Int32 _PartDescid;
        public Int32 PartDescid
        {
            get { return _PartDescid; }
            set { _PartDescid = value; }
        }
        Int32 _PartId;
        public Int32 PartId
        {
            get { return _PartId; }
            set { _PartId = value; }
        }
        //Itemid
        Int32 _Itemid;
        public Int32 Itemid
        {
            get { return _Itemid; }
            set { _Itemid = value; }
        }
        Int32 _Qty;
        public Int32 Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        String _JobID;
        public String JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }
        String _ProjectName;
        public String ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }
        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        Boolean _status;
        public Boolean status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
    //BOLEND


    public class BOLLoginInfo
    {
        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        String _EmployeeName;
        public String EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }

        Int32 _CustomerID;
        public Int32 CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        String _CustomerName;
        public String CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        Int32 _RoleID;
        public Int32 RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; }
        }

        String _RoleName;
        public String RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }

        String _LoginActiveStatus;
        public String LoginActiveStatus
        {
            get { return _LoginActiveStatus; }
            set { _LoginActiveStatus = value; }
        }

        String _CustomerActiveStatus;
        public String CustomerActiveStatus
        {
            get { return _CustomerActiveStatus; }
            set { _CustomerActiveStatus = value; }
        }

        Int32 _CountryID;
        public Int32 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }

    public class BOLBrowseDetail
    {
        Int32 _BrowseID;
        public Int32 BrowseID
        {
            get { return _BrowseID; }
            set { _BrowseID = value; }
        }

        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        Int32 _CustomerID;
        public Int32 CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        String _CurrentSessionID;
        public String CurrentSessionID
        {
            get { return _CurrentSessionID; }
            set { _CurrentSessionID = value; }
        }

        String _BrowserType;
        public String BrowserType
        {
            get { return _BrowserType; }
            set { _BrowserType = value; }
        }

        Int32 _op;
        public Int32 op
        {
            get { return _op; }
            set { _op = value; }
        }
    }

    public class BOLOpenProposalReports
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

    }

    public class BOLPartMaintainanace
    {
        Int32 _MOQ;
        public Int32 MOQ
        {
            get { return _MOQ; }
            set { _MOQ = value; }
        }

        Int32 _EAU;
        public Int32 EAU
        {
            get { return _EAU; }
            set { _EAU = value; }
        }

        Int32 _Batch;
        public Int32 Batch
        {
            get { return _Batch; }
            set { _Batch = value; }
        }
        Int32 _CompanyID;
        public Int32 CompanyID
        {
            get { return _CompanyID; }
            set { _CompanyID = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _CategoryID;
        public Int32 CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }

        Int32 _OptionID;
        public Int32 OptionID
        {
            get { return _OptionID; }
            set { _OptionID = value; }
        }

        Int32 _Size;
        public Int32 Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        string _Direction;
        public string Direction
        {
            get { return _Direction; }
            set { _Direction = value; }
        }

        string _LineStopperPriority;
        public string LineStopperPriority
        {
            get { return _LineStopperPriority; }
            set { _LineStopperPriority = value; }
        }

        Int32 _Partid;
        public Int32 Partid
        {
            get { return _Partid; }
            set { _Partid = value; }
        }
        String _PartNumber;
        public String PartNumber
        {
            get { return _PartNumber; }
            set { _PartNumber = value; }
        }
        String _CustomerPartNumber;
        public String CustomerPartNumber
        {
            get { return _CustomerPartNumber; }
            set { _CustomerPartNumber = value; }
        }
        String _PartInfo;
        public String PartInfo
        {
            get { return _PartInfo; }
            set { _PartInfo = value; }
        }
        String _PartDes;
        public String PartDes
        {
            get { return _PartDes; }
            set { _PartDes = value; }
        }
        Int32 _ProductLineId;
        public Int32 ProductLineId
        {
            get { return _ProductLineId; }
            set { _ProductLineId = value; }
        }
        Int32 _ProductLineSubId;
        public Int32 ProductLineSubId
        {
            get { return _ProductLineSubId; }
            set { _ProductLineSubId = value; }
        }
        Int32 _ProductId;
        public Int32 ProductId
        {
            get { return _ProductId; }
            set { _ProductId = value; }
        }
        Int32 _SourceId;
        public Int32 SourceId
        {
            get { return _SourceId; }
            set { _SourceId = value; }
        }
        Int32 _LoginUserId;
        public Int32 LoginUserId
        {
            get { return _LoginUserId; }
            set { _LoginUserId = value; }
        }
        Int32 _DepartmentId;
        public Int32 DepartmentId
        {
            get { return _DepartmentId; }
            set { _DepartmentId = value; }
        }
        Int32 _Typeid;
        public Int32 Typeid
        {
            get { return _Typeid; }
            set { _Typeid = value; }
        }
        Int32 _stockinhand;
        public Int32 stockinhand
        {
            get { return _stockinhand; }
            set { _stockinhand = value; }
        }
        string _RevisionNo;
        public string RevisionNo
        {
            get { return _RevisionNo; }
            set { _RevisionNo = value; }
        }
        Int32 _min;
        public Int32 min
        {
            get { return _min; }
            set { _min = value; }
        }
        Int32 _max;
        public Int32 max
        {
            get { return _max; }
            set { _max = value; }
        }
        Int32 _reorderpoint;
        public Int32 reorderpoint
        {
            get { return _reorderpoint; }
            set { _reorderpoint = value; }
        }
        Int32 _reorderqty;
        public Int32 reorderqty
        {
            get { return _reorderqty; }
            set { _reorderqty = value; }
        }
        Int32 _leadtime;
        public Int32 leadtime
        {
            get { return _leadtime; }
            set { _leadtime = value; }
        }



        Int32 _PartStatus;
        public Int32 PartStatus
        {
            get { return _PartStatus; }
            set { _PartStatus = value; }
        }
        Int32 _UMId;
        public Int32 UMId
        {
            get { return _UMId; }
            set { _UMId = value; }
        }
        String _PathImage;
        public String PathImage
        {
            get { return _PathImage; }
            set { _PathImage = value; }
        }
        String _PathShopDrawing;
        public String PathShopDrawing
        {
            get { return _PathShopDrawing; }
            set { _PathShopDrawing = value; }
        }
        String _ShopDrawingName;
        public String ShopDrawingName
        {
            get { return _ShopDrawingName; }
            set { _ShopDrawingName = value; }
        }
        Boolean _StockItem;
        public Boolean StockItem
        {
            get { return _StockItem; }
            set { _StockItem = value; }
        }
        Boolean _ForecastItem;
        public Boolean ForecastItem
        {
            get { return _ForecastItem; }
            set { _ForecastItem = value; }
        }
        Boolean _LineStopper;
        public Boolean LineStopper
        {
            get { return _LineStopper; }
            set { _LineStopper = value; }
        }
        Int32 _ProductCode;
        public Int32 ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }
    }

    public class BOLINVPartsInfo
    {
        int _WarehouseId;
        public int WarehouseId
        {
            get { return _WarehouseId; }
            set { _WarehouseId = value; }
        }

        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
        Int32 _product;
        public Int32 product
        {
            get { return _product; }
            set { _product = value; }
        }
        String _projectid;
        public String projectid
        {
            get { return _projectid; }
            set { _projectid = value; }
        }

        int _PartId;
        public int PartId
        {
            get { return _PartId; }
            set { _PartId = value; }
        }
        int _userid;
        public int userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        Int32 _Qty;
        public Int32 Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }

        string _transactsummary;
        public string transactsummary
        {
            get { return _transactsummary; }
            set { _transactsummary = value; }
        }
        Int32 _adjustmentreasonid;
        public Int32 adjustmentreasonid
        {
            get { return _adjustmentreasonid; }
            set { _adjustmentreasonid = value; }
        }
        Int32 _Productid;
        public Int32 Productid
        {
            get { return _Productid; }
            set { _Productid = value; }
        }
        DateTime? _shipdate;
        public DateTime? shipdate
        {
            get { return _shipdate; }
            set { _shipdate = value; }
        }
    }

    public class BOLManageQuotes
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _QuoteNo;
        public String QuoteNo
        {
            get { return _QuoteNo; }
            set { _QuoteNo = value; }
        }
        String _PQuoteNo;
        public String PQuoteNo
        {
            get { return _PQuoteNo; }
            set { _PQuoteNo = value; }
        }
        String __RevisionFormat;
        public String RevisionFormat
        {
            get { return __RevisionFormat; }
            set { __RevisionFormat = value; }
        }
        String _RevisionNo;
        public String RevisionNo
        {
            get { return _RevisionNo; }
            set { _RevisionNo = value; }
        }
        DateTime? _QuoteReqDate;
        public DateTime? QuoteReqDate
        {
            get { return _QuoteReqDate; }
            set { _QuoteReqDate = value; }
        }
        DateTime? _QuoteAckDate;
        public DateTime? QuoteAckDate
        {
            get { return _QuoteAckDate; }
            set { _QuoteAckDate = value; }
        }
        DateTime? _QuoteSent;
        public DateTime? QuoteSent
        {
            get { return _QuoteSent; }
            set { _QuoteSent = value; }
        }
        Decimal _EqAmount;
        public Decimal EqAmount
        {
            get { return _EqAmount; }
            set { _EqAmount = value; }
        }


    }

    public class BOLManageForecasting
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

    }

    public class BOLCustCareTickets
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _Ticmess;
        public String Ticmess
        {
            get { return _Ticmess; }
            set { _Ticmess = value; }
        }
        String _TJobID;
        public String TJobID
        {
            get { return _TJobID; }
            set { _TJobID = value; }
        }
        String _TicketNo;
        public String TicketNo
        {
            get { return _TicketNo; }
            set { _TicketNo = value; }
        }
        Int32 _Category;
        public Int32 Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        String _CategoryOther;
        public String CategoryOther
        {
            get { return _CategoryOther; }
            set { _CategoryOther = value; }
        }
        String _Task;
        public String Task
        {
            get { return _Task; }
            set { _Task = value; }
        }
        String _IssueCategory;
        public String IssueCategory
        {
            get { return _IssueCategory; }
            set { _IssueCategory = value; }
        }
        String _IssueCategoryOther;
        public String IssueCategoryOther
        {
            get { return _IssueCategoryOther; }
            set { _IssueCategoryOther = value; }
        }
        DateTime? _OpenDate;
        public DateTime? OpenDate
        {
            get { return _OpenDate; }
            set { _OpenDate = value; }
        }
        Int32 _SubAssemblyID;
        public Int32 SubAssemblyID
        {
            get { return _SubAssemblyID; }
            set { _SubAssemblyID = value; }
        }
        String _SubAssemblyOther;
        public String SubAssemblyOther
        {
            get { return _SubAssemblyOther; }
            set { _SubAssemblyOther = value; }
        }
        Int32 _IssueReportedBy;
        public Int32 IssueReportedBy
        {
            get { return _IssueReportedBy; }
            set { _IssueReportedBy = value; }
        }
        String _Solution;
        public String Solution
        {
            get { return _Solution; }
            set { _Solution = value; }
        }
        Int32 _Status;
        public Int32 Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        Int32 _AssignedTo;
        public Int32 AssignedTo
        {
            get { return _AssignedTo; }
            set { _AssignedTo = value; }
        }
        String _ServicePO;
        public String ServicePO
        {
            get { return _ServicePO; }
            set { _ServicePO = value; }
        }
        DateTime? _FollowUpDate;
        public DateTime? FollowUpDate
        {
            get { return _FollowUpDate; }
            set { _FollowUpDate = value; }
        }
        DateTime? _IssueClosedDate;
        public DateTime? IssueClosedDate
        {
            get { return _IssueClosedDate; }
            set { _IssueClosedDate = value; }
        }
        Decimal _TotalCost;
        public Decimal TotalCost
        {
            get { return _TotalCost; }
            set { _TotalCost = value; }
        }
        DateTime? _InvoiceDate;
        public DateTime? InvoiceDate
        {
            get { return _InvoiceDate; }
            set { _InvoiceDate = value; }
        }
        String _InvoiceNo;
        public String InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }
        Int32 _TicketID;
        public Int32 TicketID
        {
            get { return _TicketID; }
            set { _TicketID = value; }
        }
        String _Summary;
        public String Summary
        {
            get { return _Summary; }
            set { _Summary = value; }
        }
        DateTime? _SummaryDate;
        public DateTime? SummaryDate
        {
            get { return _SummaryDate; }
            set { _SummaryDate = value; }
        }
        DataTable _CCTTicketSummaryDetail;
        public DataTable CCTTicketSummaryDetail
        {
            get { return _CCTTicketSummaryDetail; }
            set { _CCTTicketSummaryDetail = value; }
        }

        String _PCS;
        public String PCS
        {
            get { return _PCS; }
            set { _PCS = value; }
        }

        Int32 _Technician_1;
        public Int32 Technician_1
        {
            get { return _Technician_1; }
            set { _Technician_1 = value; }
        }

        Int32 _Technician_2;
        public Int32 Technician_2
        {
            get { return _Technician_2; }
            set { _Technician_2 = value; }
        }

        String _OtherContacts;
        public String OtherContacts
        {
            get { return _OtherContacts; }
            set { _OtherContacts = value; }
        }

        String _SDT;
        public String SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }

        String _WorkingWindow;
        public String WorkingWindow
        {
            get { return _WorkingWindow; }
            set { _WorkingWindow = value; }
        }
        String _FileAddress;
        public String FileAddress
        {
            get { return _FileAddress; }
            set { _FileAddress = value; }
        }
        String _QuoteNo;
        public String QuoteNo
        {
            get { return _QuoteNo; }
            set { _QuoteNo = value; }
        }
        Decimal _QuoteAmt;
        public Decimal QuoteAmt
        {
            get { return _QuoteAmt; }
            set { _QuoteAmt = value; }
        }
        DateTime? _PORecDate;
        public DateTime? PORecDate
        {
            get { return _PORecDate; }
            set { _PORecDate = value; }
        }

    }


    public class BOLManageModel
    {
        Int32 _ModelID;
        public int ModelID
        {
            get { return _ModelID; }
            set { _ModelID = value; }
        }
        String _ModelName;
        public string ModelName
        {
            get { return _ModelName; }
            set { _ModelName = value; }
        }
        String _ModelDescription;
        public string ModelDescription
        {
            get { return _ModelDescription; }
            set { _ModelDescription = value; }
        }
        Int32 _Operation;
        public int Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }
    public class BOLManageConveyor
    {
        Int32 _ConveyorTypeID;
        public int ConveyorTypeID
        {
            get
            { return _ConveyorTypeID; }

            set
            { _ConveyorTypeID = value; }
        }
        String _ConveyorType;
        public string ConveyorType
        {
            get { return _ConveyorType; }

            set { _ConveyorType = value; }
        }
        Int32 _Operation;
        public int Operation
        {
            get { return _Operation; }

            set { _Operation = value; }
        }
    }

    public class BOLRequisition
    {
        DataTable _ReqDetails;
        public DataTable ReqDetails
        {
            get { return _ReqDetails; }
            set { _ReqDetails = value; }
        }
        Int32 _partid;
        public Int32 partid
        {
            get { return _partid; }
            set { _partid = value; }
        }
        //@Productid
        Int32 _Productid;
        public Int32 Productid
        {
            get { return _Productid; }
            set { _Productid = value; }
        }
        Int32 _qty;
        public Int32 qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        //revisionno
        String _revisionno;
        public String revisionno
        {
            get { return _revisionno; }
            set { _revisionno = value; }
        }
        String _ReqNo;
        public String ReqNo
        {
            get { return _ReqNo; }
            set { _ReqNo = value; }
        }
        Int32 _ReqForId;
        public Int32 ReqForId
        {
            get { return _ReqForId; }
            set { _ReqForId = value; }
        }
        Int32 _PreparedBy;
        public Int32 PreparedBy
        {
            get { return _PreparedBy; }
            set { _PreparedBy = value; }
        }
        Int32 _AppBy;
        public Int32 AppBy
        {
            get { return _AppBy; }
            set { _AppBy = value; }
        }
        DateTime? _TentativeShipDate;
        public DateTime? TentativeShipDate
        {
            get { return _TentativeShipDate; }
            set { _TentativeShipDate = value; }
        }
        DateTime? _ActualShipDate;
        public DateTime? ActualShipDate
        {
            get { return _ActualShipDate; }
            set { _ActualShipDate = value; }
        }
        Int32 _Reqid;
        public Int32 Reqid
        {
            get { return _Reqid; }
            set { _Reqid = value; }
        }
        Boolean _IsSubmitted;
        public Boolean IsSubmitted
        {
            get { return _IsSubmitted; }
            set { _IsSubmitted = value; }
        }
        Int32 _LoginUserId;
        public Int32 LoginUserId
        {
            get { return _LoginUserId; }
            set { _LoginUserId = value; }
        }
        Int32 _ProductLineID;
        public Int32 ProductLineID
        {
            get { return _ProductLineID; }
            set { _ProductLineID = value; }
        }
        Int32 _ProductLineSubID;
        public Int32 ProductLineSubID
        {
            get { return _ProductLineSubID; }
            set { _ProductLineSubID = value; }
        }
        Int32 _PartId;
        public Int32 PartId
        {
            get { return _PartId; }
            set { _PartId = value; }
        }
        Int32 _OrderType;
        public Int32 OrderType
        {
            get { return _OrderType; }
            set { _OrderType = value; }
        }
        Int32 _ShipBy;
        public Int32 ShipBy
        {
            get { return _ShipBy; }
            set { _ShipBy = value; }
        }
        Int32 _Requestor;
        public Int32 Requestor
        {
            get { return _Requestor; }
            set { _Requestor = value; }
        }
        Int32 _PartQty;
        public Int32 PartQty
        {
            get { return _PartQty; }
            set { _PartQty = value; }
        }
        Boolean _Priority;
        public Boolean Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }
        String _Remarks;
        public String Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        Int32 _ReqDetailID;
        public Int32 ReqDetailID
        {
            get { return _ReqDetailID; }
            set { _ReqDetailID = value; }
        }
        Int32 _VendorID;
        public Int32 VendorID
        {
            get { return _VendorID; }
            set { _VendorID = value; }
        }
        Int32 _ReqStatus;
        public Int32 ReqStatus
        {
            get { return _ReqStatus; }
            set { _ReqStatus = value; }
        }
        DataTable _dtPopUpParts;
        public DataTable dtPopUpParts
        {
            get { return _dtPopUpParts; }
            set { _dtPopUpParts = value; }
        }
    }


    public class BOLContainer
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        //@Reqid
        Int32 _Reqid;
        public Int32 Reqid
        {
            get { return _Reqid; }
            set { _Reqid = value; }
        }
        Int32 _ReqForid;
        public Int32 ReqForid
        {
            get { return _ReqForid; }
            set { _ReqForid = value; }
        }

        Int32 _POid;
        public Int32 POid
        {
            get { return _POid; }
            set { _POid = value; }
        }
        Int32 _PartId;
        public Int32 PartId
        {
            get { return _PartId; }
            set { _PartId = value; }
        }
        Int32 _POForId;
        public Int32 POForId
        {
            get { return _POForId; }
            set { _POForId = value; }
        }

        Int32 _ReqStatus;
        public Int32 ReqStatus
        {
            get { return _ReqStatus; }
            set { _ReqStatus = value; }
        }
        String _InvoiceNo;
        public String InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }
        String _ContainerNo;
        public String ContainerNo
        {
            get { return _ContainerNo; }
            set { _ContainerNo = value; }
        }
        Int32 _Containerid;
        public Int32 Containerid
        {
            get { return _Containerid; }
            set { _Containerid = value; }
        }
        String _SealNo;
        public String SealNo
        {
            get { return _SealNo; }
            set { _SealNo = value; }
        }
        DateTime? _TentativeSentDate;
        public DateTime? TentativeSentDate
        {
            get { return _TentativeSentDate; }
            set { _TentativeSentDate = value; }
        }
        Int32 _ApprovedBy;
        public Int32 ApprovedBy
        {
            get { return _ApprovedBy; }
            set { _ApprovedBy = value; }
        }
        DateTime? _SentDate;
        public DateTime? SentDate
        {
            get { return _SentDate; }
            set { _SentDate = value; }
        }
        DateTime? _ArrivalinAerowerks;
        public DateTime? ArrivalinAerowerks
        {
            get { return _ArrivalinAerowerks; }
            set { _ArrivalinAerowerks = value; }
        }
        String _ContainerSize;
        public String ContainerSize
        {
            get { return _ContainerSize; }
            set { _ContainerSize = value; }
        }
        Int32 _Attn;
        public Int32 Attn
        {
            get { return _Attn; }
            set { _Attn = value; }
        }

        Int32 _Issuedby;
        public Int32 Issuedby
        {
            get { return _Issuedby; }
            set { _Issuedby = value; }
        }

        Int32 _ShipmentBy;
        public Int32 ShipmentBy
        {
            get { return _ShipmentBy; }
            set { _ShipmentBy = value; }
        }

        Int32 _SourceID;
        public Int32 SourceID
        {
            get { return _SourceID; }
            set { _SourceID = value; }
        }

        DataTable _ContainerDetails;
        public DataTable ContainerDetails
        {
            get { return _ContainerDetails; }
            set { _ContainerDetails = value; }
        }
        Int32 _LoginUserId;
        public Int32 LoginUserId
        {
            get { return _LoginUserId; }
            set { _LoginUserId = value; }
        }
        String _Desc;
        public String Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }
        String _Requestor;
        public String Requestor
        {
            get { return _Requestor; }
            set { _Requestor = value; }
        }
        String _JobID;
        public String JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }
        Int32 _JobQty;
        public Int32 JobQty
        {
            get { return _JobQty; }
            set { _JobQty = value; }
        }
        String _JobRemarks;
        public String JobRemarks
        {
            get { return _JobRemarks; }
            set { _JobRemarks = value; }
        }
        Int32 _ContainerProjectsID;
        public Int32 ContainerProjectsID
        {
            get { return _ContainerProjectsID; }
            set { _ContainerProjectsID = value; }
        }
        DateTime? _ReceivedDate;
        public DateTime? ReceivedDate
        {
            get { return _ReceivedDate; }
            set { _ReceivedDate = value; }
        }
        String _UploadDocument;
        public String UploadDocument
        {
            get { return _UploadDocument; }
            set { _UploadDocument = value; }
        }
    }

    public class BOLPurchaseOrder
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        Int32 _RequestedBy;
        public Int32 RequestedBy
        {
            get { return _RequestedBy; }
            set { _RequestedBy = value; }
        }

        Int32 _PONumberID;
        public Int32 PONumberID
        {
            get { return _PONumberID; }
            set { _PONumberID = value; }
        }

        String _PONumber;
        public String PONumber
        {
            get { return _PONumber; }
            set { _PONumber = value; }
        }

        String _SourceID;
        public String SourceID
        {
            get { return _SourceID; }
            set { _SourceID = value; }
        }

        String _Remarks;
        public String Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        DateTime? _IssueDate;
        public DateTime? IssueDate
        {
            get { return _IssueDate; }
            set { _IssueDate = value; }
        }

        Int32 _ReqForId;
        public Int32 ReqForId
        {
            get { return _ReqForId; }
            set { _ReqForId = value; }
        }

        Int32 _PartId;
        public Int32 PartId
        {
            get { return _PartId; }
            set { _PartId = value; }
        }

        Int32 _ReqId;
        public Int32 ReqId
        {
            get { return _ReqId; }
            set { _ReqId = value; }
        }

        Int32 _ReqDetailId;
        public Int32 ReqDetailId
        {
            get { return _ReqDetailId; }
            set { _ReqDetailId = value; }
        }

        DataTable _PurchaseOrderDetails;
        public DataTable PurchaseOrderDetails
        {
            get { return _PurchaseOrderDetails; }
            set { _PurchaseOrderDetails = value; }
        }

        Int32 _ReqStatus;
        public Int32 ReqStatus
        {
            get { return _ReqStatus; }
            set { _ReqStatus = value; }
        }

        String _PreparedBy;
        public String PreparedBy
        {
            get { return _PreparedBy; }
            set { _PreparedBy = value; }
        }
        Int32 _Status;
        public Int32 Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        Int32 _ProductLineID;
        public Int32 ProductLineID
        {
            get { return _ProductLineID; }
            set { _ProductLineID = value; }
        }
        Int32 _ProductLineSubID;
        public Int32 ProductLineSubID
        {
            get { return _ProductLineSubID; }
            set { _ProductLineSubID = value; }
        }
        String _PORemarks;
        public String PORemarks
        {
            get { return _PORemarks; }
            set { _PORemarks = value; }
        }
        Int32 _WareHouseID;
        public Int32 WareHouseID
        {
            get { return _WareHouseID; }
            set { _WareHouseID = value; }
        }

    }

    public class BOLManageBranchInformation
    {
        Int32 _BranchID;
        public Int32 BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }
        String _BranchLocation;
        public string BranchLocation
        {
            get { return _BranchLocation; }

            set { _BranchLocation = value; }
        }
        String _BranchName;
        public string BranchName
        {
            get
            { return _BranchName; }

            set
            { _BranchName = value; }
        }

        Int16 _RegionID;
        public Int16 RegionID
        {
            get { return _RegionID; }
            set { _RegionID = value; }
        }
        String _CompanyName;
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
        String _StreetAddress;
        public String StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }
        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }

        Int16 _StateID;
        public Int16 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }

        Int16 _CountryID;
        public Int16 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        String _ZipCode;
        public String ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }

        String _Telephone;
        public String Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }


        String _TollFree;
        public String TollFree
        {
            get { return _TollFree; }
            set { _TollFree = value; }
        }
        String _TollFax;
        public String TollFax
        {
            get { return _TollFax; }
            set { _TollFax = value; }
        }
        String _FaxNumber;
        public String FaxNumber
        {
            get { return _FaxNumber; }
            set { _FaxNumber = value; }
        }
        Int32 _InsideSalesSupportID;
        public Int32 InsideSalesSupportID
        {
            get { return _InsideSalesSupportID; }
            set { _InsideSalesSupportID = value; }
        }
        Boolean _HobartGroup;
        public Boolean HobartGroup
        {
            get { return _HobartGroup; }
            set { _HobartGroup = value; }
        }
        Boolean _SteroGroup;
        public Boolean SteroGroup
        {
            get { return _SteroGroup; }
            set { _SteroGroup = value; }
        }

        String _CellPhone;
        public String CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }


        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _RepGroupID;
        public Int32 RepGroupID
        {
            get { return _RepGroupID; }
            set { _RepGroupID = value; }
        }
        String _StatesCovered;
        public string StatesCovered
        {
            get { return _StatesCovered; }

            set { _StatesCovered = value; }
        }
    }

    public class BOLManageShopEmployees
    {
        Int32 _id;
        public Int32 id
        {
            get { return _id; }
            set { _id = value; }
        }

        String _FirstName;
        public string FirstName
        {
            get { return _FirstName; }

            set { _FirstName = value; }
        }

        String _LastName;
        public string LastName
        {
            get { return _LastName; }

            set { _LastName = value; }
        }

        Int32 _Countryid;
        public Int32 Countryid
        {
            get { return _Countryid; }
            set { _Countryid = value; }
        }

        Int32 _Stateid;
        public Int32 Stateid
        {
            get { return _Stateid; }
            set { _Stateid = value; }
        }


        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }


        String _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        String _PostalCode;
        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }

        String _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        DateTime? _DateHired;
        public DateTime? DateHired
        {
            get { return _DateHired; }

            set { _DateHired = value; }
        }

        Int32 _Position;
        public Int32 Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        Int32 _Status;
        public Int32 Status
        {
            get { return _Status; }
            set { _Status = value; }
        }


        Int32 _EmployeeCurrentStatus;
        public Int32 EmployeeCurrentStatus
        {
            get { return _EmployeeCurrentStatus; }
            set { _EmployeeCurrentStatus = value; }
        }

        String _Notes;
        public String Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        String _ImagePath;
        public String ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        Boolean _Laser;
        public Boolean Laser
        {
            get { return _Laser; }
            set { _Laser = value; }
        }
        Int32 _LaserType;
        public Int32 LaserType
        {
            get { return _LaserType; }
            set { _LaserType = value; }
        }

        Boolean _BrakePress;
        public Boolean BrakePress
        {
            get { return _BrakePress; }
            set { _BrakePress = value; }
        }
        Int32 _BrakePressType;
        public Int32 BrakePressType
        {
            get { return _BrakePressType; }
            set { _BrakePressType = value; }
        }

        Boolean _Welding;
        public Boolean Welding
        {
            get { return _Welding; }
            set { _Welding = value; }
        }
        Int32 _WeldingType;
        public Int32 WeldingType
        {
            get { return _WeldingType; }
            set { _WeldingType = value; }
        }

        Boolean _Polishing;
        public Boolean Polishing
        {
            get { return _Polishing; }
            set { _Polishing = value; }
        }
        Int32 _PolishingType;
        public Int32 PolishingType
        {
            get { return _PolishingType; }
            set { _PolishingType = value; }
        }

        Boolean _MachineShop;
        public Boolean MachineShop
        {
            get { return _MachineShop; }
            set { _MachineShop = value; }
        }
        Int32 _MachineShopType;
        public Int32 MachineShopType
        {
            get { return _MachineShopType; }
            set { _MachineShopType = value; }
        }

        Boolean _Elecrical;
        public Boolean Elecrical
        {
            get { return _Elecrical; }
            set { _Elecrical = value; }
        }
        Int32 _ElecricalType;
        public Int32 ElecricalType
        {
            get { return _ElecricalType; }
            set { _ElecricalType = value; }
        }

        Boolean _Shipping;
        public Boolean Shipping
        {
            get { return _Shipping; }
            set { _Shipping = value; }
        }
        Int32 _ShippingType;
        public Int32 ShippingType
        {
            get { return _ShippingType; }
            set { _ShippingType = value; }
        }
        //Operation
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _Employeeid;
        public Int32 Employeeid
        {
            get { return _Employeeid; }
            set { _Employeeid = value; }
        }
        DataTable _ShopEmployeeTraining;
        public DataTable ShopEmployeeTraining
        {
            get { return _ShopEmployeeTraining; }
            set { _ShopEmployeeTraining = value; }
        }

        Int32 _ShopEmployeeTrainingid;
        public Int32 ShopEmployeeTrainingid
        {
            get { return _ShopEmployeeTrainingid; }
            set { _ShopEmployeeTrainingid = value; }
        }


        String _Description;
        public String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        Int32 _Categoryid;
        public Int32 Categoryid
        {
            get { return _Categoryid; }
            set { _Categoryid = value; }
        }

        String _Trainer;
        public String Trainer
        {
            get { return _Trainer; }
            set { _Trainer = value; }
        }

        DateTime? _TrainingDate;
        public DateTime? TrainingDate
        {
            get { return _TrainingDate; }
            set { _TrainingDate = value; }
        }
    }
    public class BOLIssueCategory
    {
        Int32 _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        String _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        Int32 _status;
        public Int32 status
        {
            get { return _status; }
            set { _status = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

    }
    public class BOLCCT_SubAssembly
    {
        Int32 _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        String _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        Int32 _status;
        public Int32 status
        {
            get { return _status; }
            set { _status = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

    }
    public class BOLCCT_Category
    {
        Int32 _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        String _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        Int32 _status;
        public Int32 status
        {
            get { return _status; }
            set { _status = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

    }
    public class BOLCCT_IssueReportedBy
    {
        Int32 _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        String _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        Int32 _status;
        public Int32 status
        {
            get { return _status; }
            set { _status = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

    }

    public class BOLEngHoursCalculate
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _ProposalID;
        public String ProposalID
        {
            get { return _ProposalID; }
            set { _ProposalID = value; }
        }
        Int32 _DepartmentID;
        public Int32 DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }
        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        Int32 _TimeSheetid;
        public Int32 TimeSheetid
        {
            get { return _TimeSheetid; }
            set { _TimeSheetid = value; }
        }
        DateTime? _TaskDate;
        public DateTime? TaskDate
        {
            get { return _TaskDate; }
            set { _TaskDate = value; }
        }
        Int32 _TaskNature;
        public Int32 TaskNature
        {
            get { return _TaskNature; }
            set { _TaskNature = value; }
        }
        Int32 _TaskCategory;
        public Int32 TaskCategory
        {
            get { return _TaskCategory; }
            set { _TaskCategory = value; }
        }
        DateTime? _StartTime;
        public DateTime? StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }
        DateTime? _EndTime;
        public DateTime? EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }
        DateTime? _TotalTime;
        public DateTime? TotalTime
        {
            get { return _TotalTime; }
            set { _TotalTime = value; }
        }


    }

    public class BOLManageDesg
    {
        Int32 _id;
        public Int32 id
        {
            get { return _id; }
            set { _id = value; }

        }
        String _DesgName;
        public String DesgName
        {
            get { return _DesgName; }
            set { _DesgName = value; }
        }
        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
    }

    public class BOLManageUniv
    {
        Int32 _id;
        public Int32 id
        {
            get { return _id; }
            set { _id = value; }

        }
        String _UniName;
        public String UniName
        {
            get { return _UniName; }
            set { _UniName = value; }
        }
        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
    }

    public class BOLCampusListing
    {
        Int32 _id;
        public Int32 id
        {
            get { return _id; }
            set { _id = value; }
        }
        Int32 _UniID;
        public Int32 UniID
        {
            get { return _UniID; }
            set { _UniID = value; }
        }
        Int32 _CampusID;
        public Int32 CampusID
        {
            get { return _CampusID; }
            set { _CampusID = value; }
        }
        string _CampusName;
        public string CampusName
        {
            get { return _CampusName; }
            set { _CampusName = value; }
        }
        String _City;
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
        Int32 _StateID;
        public Int32 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }
        Int32 _CountryID;
        public Int32 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        String _PostalCode;
        public String PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

    }


    public class BOLContactListing
    {
        Int32 _id;
        public Int32 id
        {
            get { return _id; }
            set { _id = value; }
        }
        Int32 _UniID;
        public Int32 UniID
        {
            get { return _UniID; }
            set { _UniID = value; }
        }
        Int32 _CampusID;
        public Int32 CampusID
        {
            get { return _CampusID; }
            set { _CampusID = value; }

        }
        Int32 _ContactId;
        public Int32 ContactId
        {
            get { return _ContactId; }
            set { _ContactId = value; }

        }
        Int32 _DesgID;
        public Int32 DesgID
        {
            get { return _DesgID; }
            set { _DesgID = value; }

        }
        string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        string _DesgName;
        public string DesgName
        {
            get { return _DesgName; }
            set { _DesgName = value; }
        }

        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        string _City;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        string _StreetAddress;
        public string StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }
        String _ZipCode;
        public String ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }
    //START BOL Rep Search Page
    public class BOLRepSearch
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _country;
        public Int32 country
        {
            get { return _country; }
            set { _country = value; }
        }
        String _SearchVar;
        public String SearchVar
        {
            get { return _SearchVar; }
            set { _SearchVar = value; }
        }
        String _PNumber;
        public String PNumber
        {
            get { return _PNumber; }
            set { _PNumber = value; }
        }
        String _RepID;
        public String RepID
        {
            get { return _RepID; }
            set { _RepID = value; }
        }
        DateTime _FromDate;
        public DateTime FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
        DateTime _toDate;
        public DateTime toDate
        {
            get { return _toDate; }
            set { _toDate = value; }
        }
    }
    public class BOLGaylordQuote
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        //GayquoteDetailid
        Int32 _GayquoteDetailid;
        public Int32 GayquoteDetailid
        {
            get { return _GayquoteDetailid; }
            set { _GayquoteDetailid = value; }
        }
        //GPNPartid
        Int32 _GPNPartid;
        public Int32 GPNPartid
        {
            get { return _GPNPartid; }
            set { _GPNPartid = value; }
        }
        //Quoteno
        String _Quoteno;
        public String Quoteno
        {
            get { return _Quoteno; }
            set { _Quoteno = value; }
        }
        //Quotedate
        DateTime? _Quotedate;
        public DateTime? Quotedate
        {
            get { return _Quotedate; }
            set { _Quotedate = value; }
        }
        Int32 _Quoteby;
        public Int32 Quoteby
        {
            get { return _Quoteby; }
            set { _Quoteby = value; }
        }
        //partid
        Int32 _partid;
        public Int32 partid
        {
            get { return _partid; }
            set { _partid = value; }
        }
        //partqty
        decimal _partqty;
        public decimal partqty
        {
            get { return _partqty; }
            set { _partqty = value; }
        }
        //finalcost
        Int32 _finalcost;
        public Int32 finalcost
        {
            get { return _finalcost; }
            set { _finalcost = value; }
        }
        //@Gayquoteid
        Int32 _Gayquoteid;
        public Int32 Gayquoteid
        {
            get { return _Gayquoteid; }
            set { _Gayquoteid = value; }
        }
    }

    public class BOLShipmentTracker
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        //shipinfoid
        Int32 _shipinfoid;
        public Int32 shipinfoid
        {
            get { return _shipinfoid; }
            set { _shipinfoid = value; }
        }
        //ShipInfoDetailid
        Int32 _ShipInfoDetailid;
        public Int32 ShipInfoDetailid
        {
            get { return _ShipInfoDetailid; }
            set { _ShipInfoDetailid = value; }
        }
        Int32 _ShipInfo;
        public Int32 ShipInfo
        {
            get { return _ShipInfo; }
            set { _ShipInfo = value; }
        }
        Int32 _Containerid;
        public Int32 Containerid
        {
            get { return _Containerid; }
            set { _Containerid = value; }
        }
        Int32 _ShipFromID;
        public Int32 ShipFromID
        {
            get { return _ShipFromID; }
            set { _ShipFromID = value; }
        }
        Int32 _ShipByID;
        public Int32 ShipByID
        {
            get { return _ShipByID; }
            set { _ShipByID = value; }
        }
        String _ContainerNo;
        public String ContainerNo
        {
            get { return _ContainerNo; }
            set { _ContainerNo = value; }
        }
        DateTime? _ShipDate;
        public DateTime? ShipDate
        {
            get { return _ShipDate; }
            set { _ShipDate = value; }
        }
        DateTime? _ETA;
        public DateTime? ETA
        {
            get { return _ETA; }
            set { _ETA = value; }
        }
        DateTime? _RecDate;
        public DateTime? RecDate
        {
            get { return _RecDate; }
            set { _RecDate = value; }
        }
        String _PackingList;
        public String PackingList
        {
            get { return _PackingList; }
            set { _PackingList = value; }
        }
        DateTime? _RevisedETA;
        public DateTime? RevisedETA
        {
            get { return _RevisedETA; }
            set { _RevisedETA = value; }
        }
        String _Comments;
        public String Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }
        string _SearchVar;
        public String SearchVar
        {
            get { return _SearchVar; }
            set { _SearchVar = value; }
        }
    }

    public class BOLManageProjectsInfo
    {
        String _Issued;
        public String Issued
        {
            get { return _Issued; }
            set { _Issued = value; }
        }
        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        String _JobID;
        public String JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }

        Int32 _ConveyorID;
        public Int32 ConveyorID
        {
            get { return _ConveyorID; }
            set { _ConveyorID = value; }
        }
        DateTime? _ShipToArriveDate;
        public DateTime? ShipToArriveDate
        {
            get { return _ShipToArriveDate; }
            set { _ShipToArriveDate = value; }
        }

        String _ProjectName;
        public String ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }

        String _ProjectNumber;
        public String ProjectNumber
        {
            get { return _ProjectNumber; }
            set { _ProjectNumber = value; }
        }
        DateTime? _ProjectDate;
        public DateTime? ProjectDate
        {
            get { return _ProjectDate; }
            set { _ProjectDate = value; }
        }
        DateTime? _FabDateIssue;
        public DateTime? FabDateIssue
        {
            get { return _FabDateIssue; }
            set { _FabDateIssue = value; }
        }
        DateTime? _NestDateIssue;
        public DateTime? NestDateIssue
        {
            get { return _NestDateIssue; }
            set { _NestDateIssue = value; }
        }
        Int32 _ProjectEng;
        public Int32 ProjectEng
        {
            get { return _ProjectEng; }
            set { _ProjectEng = value; }
        }
        Int32 _ReviewedBy;
        public Int32 ReviewedBy
        {
            get { return _ReviewedBy; }
            set { _ReviewedBy = value; }
        }
        Int32 _ModelID;
        public Int32 ModelID
        {
            get { return _ModelID; }
            set { _ModelID = value; }
        }
        Int32 _CurrencyID;
        public Int32 CurrencyID
        {
            get { return _CurrencyID; }
            set { _CurrencyID = value; }
        }
        Double _EqPrice;
        public Double EqPrice
        {
            get { return _EqPrice; }
            set { _EqPrice = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }
    public class BOLHobartSalesbyTSM
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }

    public class BOLSerProposals
    {
        //SerProposalDetailid
        Int32 _SerProposalDetailid;
        public Int32 SerProposalDetailid
        {
            get { return _SerProposalDetailid; }
            set { _SerProposalDetailid = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        //@SerProposal
        String _SerProposal;
        public String SerProposal
        {
            get { return _SerProposal; }
            set { _SerProposal = value; }
        }
        String _PNo;
        public String PNo
        {
            get { return _PNo; }
            set { _PNo = value; }
        }
        Int32 _ConveyorSpecID;
        public Int32 ConveyorSpecID
        {
            get { return _ConveyorSpecID; }
            set { _ConveyorSpecID = value; }
        }
        String _Comments;
        public String Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }
        String _RefJobID;
        public String RefJobID
        {
            get { return _RefJobID; }
            set { _RefJobID = value; }
        }
        Int32 _AssignedTo;
        public Int32 AssignedTo
        {
            get { return _AssignedTo; }
            set { _AssignedTo = value; }
        }
        Int32 _Technician;
        public Int32 Technician
        {
            get { return _Technician; }
            set { _Technician = value; }
        }
        DateTime? _AssessmentDate;
        public DateTime? AssessmentDate
        {
            get { return _AssessmentDate; }
            set { _AssessmentDate = value; }
        }
        DateTime? _QuoteSentDate;
        public DateTime? QuoteSentDate
        {
            get { return _QuoteSentDate; }
            set { _QuoteSentDate = value; }
        }
        Decimal _QuoteAmount;
        public Decimal QuoteAmount
        {
            get { return _QuoteAmount; }
            set { _QuoteAmount = value; }
        }
        Int32 _Status;
        public Int32 Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        Int32 _Nature;
        public Int32 Nature
        {
            get { return _Nature; }
            set { _Nature = value; }
        }
        DateTime? _Date;
        public DateTime? Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        //SUMMARY
        String _SUMMARY;
        public String SUMMARY
        {
            get { return _SUMMARY; }
            set { _SUMMARY = value; }
        }
        String _SearchVar;
        public String SearchVar
        {
            get { return _SearchVar; }
            set { _SearchVar = value; }
        }

    }

    public class BOLSerProjects
    {
        String _SerProposal;
        public String SerProposal
        {
            get { return _SerProposal; }
            set { _SerProposal = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        //@JobNo
        String _JobNo;
        public String JobNo
        {
            get { return _JobNo; }
            set { _JobNo = value; }
        }
        String _JNo;
        public String JNo
        {
            get { return _JNo; }
            set { _JNo = value; }
        }
        String _PNo;
        public String PNo
        {
            get { return _PNo; }
            set { _PNo = value; }
        }
        DateTime? _PORecDate;
        public DateTime? PORecDate
        {
            get { return _PORecDate; }
            set { _PORecDate = value; }
        }
        Decimal _POAmount;
        public Decimal POAmount
        {
            get { return _POAmount; }
            set { _POAmount = value; }
        }
        String _PONo;
        public String PONo
        {
            get { return _PONo; }
            set { _PONo = value; }
        }
        DateTime? _RepairDate;
        public DateTime? RepairDate
        {
            get { return _RepairDate; }
            set { _RepairDate = value; }
        }
        Int32 _Status;
        public Int32 Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        DateTime? _FollowupDate;
        public DateTime? FollowupDate
        {
            get { return _FollowupDate; }
            set { _FollowupDate = value; }
        }

        DateTime? _InvoiceDate;
        public DateTime? InvoiceDate
        {
            get { return _InvoiceDate; }
            set { _InvoiceDate = value; }
        }
        String _InvoiceNo;
        public String InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }

        Decimal _ActualAmount;
        public Decimal ActualAmount
        {
            get { return _ActualAmount; }
            set { _ActualAmount = value; }
        }

        Int32 _Technician;
        public Int32 Technician
        {
            get { return _Technician; }
            set { _Technician = value; }
        }
        Int32 _AssignedTo;
        public Int32 AssignedTo
        {
            get { return _AssignedTo; }
            set { _AssignedTo = value; }
        }
        Int32 _ConveyorSpecID;
        public Int32 ConveyorSpecID
        {
            get { return _ConveyorSpecID; }
            set { _ConveyorSpecID = value; }
        }
        String _Comments;
        public String Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }
        DateTime? _AssessmentDate;
        public DateTime? AssessmentDate
        {
            get { return _AssessmentDate; }
            set { _AssessmentDate = value; }
        }
        DateTime? _QuoteSentDate;
        public DateTime? QuoteSentDate
        {
            get { return _QuoteSentDate; }
            set { _QuoteSentDate = value; }
        }
        Decimal _QuoteAmount;
        public Decimal QuoteAmount
        {
            get { return _QuoteAmount; }
            set { _QuoteAmount = value; }
        }
        DateTime? _Date;
        public DateTime? Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        //SUMMARY
        String _SUMMARY;
        public String SUMMARY
        {
            get { return _SUMMARY; }
            set { _SUMMARY = value; }
        }
    }

    public class BOLManageRepGroup
    {
        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        String _Name;
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        Int32 _SortOrder;
        public Int32 SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }

        Boolean _IsActive;
        public Boolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        Int32 _ProductLineID;
        public Int32 ProductLineID
        {
            get { return _ProductLineID; }
            set { _ProductLineID = value; }
        }

        Int32 _pmid;
        public Int32 pmid
        {
            get { return _pmid; }
            set { _pmid = value; }
        }

        Int32 _operation;
        public Int32 operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        Boolean _HobartGroup;
        public Boolean HobartGroup
        {
            get { return _HobartGroup; }
            set { _HobartGroup = value; }
        }
        Boolean _SteroGroup;
        public Boolean SteroGroup
        {
            get { return _SteroGroup; }
            set { _SteroGroup = value; }
        }
    }

    public class BOLModel
    {
        Int32 _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        Int32 _modelid;
        public int modelid
        {
            get { return _modelid; }
            set { _modelid = value; }
        }
        String _Category;
        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        String _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        Int32 _status;
        public Int32 status
        {
            get { return _status; }
            set { _status = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _ChildModelID;
        public Int32 ChildModelID
        {
            get { return _ChildModelID; }
            set { _ChildModelID = value; }
        }

        string _PNumber;
        public string PNumber
        {
            get { return _PNumber; }
            set { _PNumber = value; }
        }

        DataTable _SelectDetails;
        public DataTable SelectDetails
        {
            get { return _SelectDetails; }
            set { _SelectDetails = value; }
        }
    }
    public class BOLSchedule
    {
        Int32 _ServiceScheduleID;
        public Int32 ServiceScheduleID
        {
            get { return _ServiceScheduleID; }
            set { _ServiceScheduleID = value; }
        }
        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        Int32 _CustomerID;
        public Int32 CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        String _JobID;
        public String JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }
        DateTime? _ReqShipDate;
        public DateTime? ReqShipDate
        {
            get { return _ReqShipDate; }
            set { _ReqShipDate = value; }
        }
        Int32 _NestingStatus;
        public Int32 NestingStatus
        {
            get { return _NestingStatus; }
            set { _NestingStatus = value; }
        }
        Int32 _LaserStatus;
        public Int32 LaserStatus
        {
            get { return _LaserStatus; }
            set { _LaserStatus = value; }
        }
        Int32 _FormingStatus;
        public Int32 FormingStatus
        {
            get { return _FormingStatus; }
            set { _FormingStatus = value; }
        }
        Int32 _WeldingStatus;
        public Int32 WeldingStatus
        {
            get { return _WeldingStatus; }
            set { _WeldingStatus = value; }
        }
        Int32 _PolishingStatus;
        public Int32 PolishingStatus
        {
            get { return _PolishingStatus; }
            set { _PolishingStatus = value; }
        }
        Int32 _ShippingStatus;
        public Int32 ShippingStatus
        {
            get { return _ShippingStatus; }
            set { _ShippingStatus = value; }
        }
        Int32 _Status;
        public Int32 Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }
    public class BOLScheduleDetails
    {
        Int32 _CustomerID;
        public Int32 CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        String _JobID;
        public String JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }
        String _PackNo;
        public String PackNo
        {
            get { return _PackNo; }
            set { _PackNo = value; }
        }
        String _PartNumber;
        public String PartNumber
        {
            get { return _PartNumber; }
            set { _PartNumber = value; }
        }
        String _PartDescription;
        public String PartDescription
        {
            get { return _PartDescription; }
            set { _PartDescription = value; }
        }
        DateTime? _ReleaseDate;
        public DateTime? ReleaseDate
        {
            get { return _ReleaseDate; }
            set { _ReleaseDate = value; }
        }
        Int32 _ServiceScheduleID;
        public Int32 ServiceScheduleID
        {
            get { return _ServiceScheduleID; }
            set { _ServiceScheduleID = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
    }

    public class BOLPrepareContainer
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        //@Reqid
        Int32 _Reqid;
        public Int32 Reqid
        {
            get { return _Reqid; }
            set { _Reqid = value; }
        }
        Int32 _ReqForid;
        public Int32 ReqForid
        {
            get { return _ReqForid; }
            set { _ReqForid = value; }
        }
        Int32 _PartId;
        public Int32 PartId
        {
            get { return _PartId; }
            set { _PartId = value; }
        }
        Int32 _POid;
        public Int32 POid
        {
            get { return _POid; }
            set { _POid = value; }
        }
        Int32 _PODetailid;
        public Int32 PODetailid
        {
            get { return _PODetailid; }
            set { _PODetailid = value; }
        }
        Int32 _POForId;
        public Int32 POForId
        {
            get { return _POForId; }
            set { _POForId = value; }
        }

        Int32 _ReqStatus;
        public Int32 ReqStatus
        {
            get { return _ReqStatus; }
            set { _ReqStatus = value; }
        }
        String _InvoiceNo;
        public String InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }
        String _ContainerNo;
        public String ContainerNo
        {
            get { return _ContainerNo; }
            set { _ContainerNo = value; }
        }
        Int32 _Containerid;
        public Int32 Containerid
        {
            get { return _Containerid; }
            set { _Containerid = value; }
        }
        String _SealNo;
        public String SealNo
        {
            get { return _SealNo; }
            set { _SealNo = value; }
        }
        DateTime? _TentativeSentDate;
        public DateTime? TentativeSentDate
        {
            get { return _TentativeSentDate; }
            set { _TentativeSentDate = value; }
        }
        Int32 _ApprovedBy;
        public Int32 ApprovedBy
        {
            get { return _ApprovedBy; }
            set { _ApprovedBy = value; }
        }
        DateTime? _SentDate;
        public DateTime? SentDate
        {
            get { return _SentDate; }
            set { _SentDate = value; }
        }
        DateTime? _ArrivalinAerowerks;
        public DateTime? ArrivalinAerowerks
        {
            get { return _ArrivalinAerowerks; }
            set { _ArrivalinAerowerks = value; }
        }
        String _ContainerSize;
        public String ContainerSize
        {
            get { return _ContainerSize; }
            set { _ContainerSize = value; }
        }
        Int32 _Attn;
        public Int32 Attn
        {
            get { return _Attn; }
            set { _Attn = value; }
        }

        Int32 _Issuedby;
        public Int32 Issuedby
        {
            get { return _Issuedby; }
            set { _Issuedby = value; }
        }

        Int32 _ShipmentBy;
        public Int32 ShipmentBy
        {
            get { return _ShipmentBy; }
            set { _ShipmentBy = value; }
        }

        Int32 _SourceID;
        public Int32 SourceID
        {
            get { return _SourceID; }
            set { _SourceID = value; }
        }

        Int32 _Status;
        public Int32 Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        DataTable _ContainerDetails;
        public DataTable ContainerDetails
        {
            get { return _ContainerDetails; }
            set { _ContainerDetails = value; }
        }
        Int32 _LoginUserId;
        public Int32 LoginUserId
        {
            get { return _LoginUserId; }
            set { _LoginUserId = value; }
        }
        String _Desc;
        public String Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }
        String _Requestor;
        public String Requestor
        {
            get { return _Requestor; }
            set { _Requestor = value; }
        }
        String _JobID;
        public String JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }
        Int32 _JobQty;
        public Int32 JobQty
        {
            get { return _JobQty; }
            set { _JobQty = value; }
        }
        String _JobRemarks;
        public String JobRemarks
        {
            get { return _JobRemarks; }
            set { _JobRemarks = value; }
        }
        Int32 _ContainerProjectsID;
        public Int32 ContainerProjectsID
        {
            get { return _ContainerProjectsID; }
            set { _ContainerProjectsID = value; }
        }
        DateTime? _ReceivedDate;
        public DateTime? ReceivedDate
        {
            get { return _ReceivedDate; }
            set { _ReceivedDate = value; }
        }
        String _UploadDocument;
        public String UploadDocument
        {
            get { return _UploadDocument; }
            set { _UploadDocument = value; }
        }
        Int32 _WarehouseID;
        public Int32 WarehouseID
        {
            get { return _WarehouseID; }
            set { _WarehouseID = value; }
        }
    }

    public class BOLForecastingSubParts
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _Product;
        public Int32 Product
        {
            get { return _Product; }
            set { _Product = value; }
        }

        string _StartDate;
        public string StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }

        string _EndDate;
        public string EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
    }

    public class BOLServiceSchedule
    {

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        String _JobID;
        public String JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }
        String _PackNo;
        public String PackNo
        {
            get { return _PackNo; }
            set { _PackNo = value; }
        }
        DateTime? _ReleaseDate;
        public DateTime? ReleaseDate
        {
            get { return _ReleaseDate; }
            set { _ReleaseDate = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        DataTable _PackDetail;
        public DataTable PackDetail
        {
            get { return _PackDetail; }
            set { _PackDetail = value; }
        }
        Int32 _ServiceScheduleID;
        public Int32 ServiceScheduleID
        {
            get { return _ServiceScheduleID; }
            set { _ServiceScheduleID = value; }
        }

        String _PartNumber;
        public String PartNumber
        {
            get { return _PartNumber; }
            set { _PartNumber = value; }
        }

        String _PartDescription;
        public String PartDescription
        {
            get { return _PartDescription; }
            set { _PartDescription = value; }
        }

        Int32 _PartQty;
        public Int32 PartQty
        {
            get { return _PartQty; }
            set { _PartQty = value; }
        }

        DateTime? _ReqShipDate;
        public DateTime? ReqShipDate
        {
            get { return _ReqShipDate; }
            set { _ReqShipDate = value; }
        }

        DateTime? _PartReqOnSite;
        public DateTime? PartReqOnSite
        {
            get { return _PartReqOnSite; }
            set { _PartReqOnSite = value; }
        }

        DateTime? _ShipDate;
        public DateTime? ShipDate
        {
            get { return _ShipDate; }
            set { _ShipDate = value; }
        }

        Int32 _NestingStatus;
        public Int32 NestingStatus
        {
            get { return _NestingStatus; }
            set { _NestingStatus = value; }
        }

        Int32 _LaserStatus;
        public Int32 LaserStatus
        {
            get { return _LaserStatus; }
            set { _LaserStatus = value; }
        }

        Int32 _FormingStatus;
        public Int32 FormingStatus
        {
            get { return _FormingStatus; }
            set { _FormingStatus = value; }
        }

        Int32 _WeldingStatus;
        public Int32 WeldingStatus
        {
            get { return _WeldingStatus; }
            set { _WeldingStatus = value; }
        }

        Int32 _PolishingStatus;
        public Int32 PolishingStatus
        {
            get { return _PolishingStatus; }
            set { _PolishingStatus = value; }
        }

        Int32 _FinalStatus;
        public Int32 FinalStatus
        {
            get { return _FinalStatus; }
            set { _FinalStatus = value; }
        }

        Int32 _ShippingStatus;
        public Int32 ShippingStatus
        {
            get { return _ShippingStatus; }
            set { _ShippingStatus = value; }
        }
    }

    public class BOLServiceScheduleDetail
    {
        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        Int32 _ServiceScheduleID;
        public Int32 ServiceScheduleID
        {
            get { return _ServiceScheduleID; }
            set { _ServiceScheduleID = value; }
        }

        String _PartNumber;
        public String PartNumber
        {
            get { return _PartNumber; }
            set { _PartNumber = value; }
        }
        String _PartDescription;
        public String PartDescription
        {
            get { return _PartDescription; }
            set { _PartDescription = value; }
        }

        DateTime _ReqShipDate;
        public DateTime ReqShipDate
        {
            get { return _ReqShipDate; }
            set { _ReqShipDate = value; }
        }
        Int32 _NestingStatus;
        public Int32 NestingStatus
        {
            get { return _NestingStatus; }
            set { _NestingStatus = value; }
        }
        Int32 _LaserStatus;
        public Int32 LaserStatus
        {
            get { return _LaserStatus; }
            set { _LaserStatus = value; }
        }
        Int32 _FormingStatus;
        public Int32 FormingStatus
        {
            get { return _FormingStatus; }
            set { _FormingStatus = value; }
        }
        Int32 _WeldingStatus;
        public Int32 WeldingStatus
        {
            get { return _WeldingStatus; }
            set { _WeldingStatus = value; }
        }
        Int32 _PolishingStatus;
        public Int32 PolishingStatus
        {
            get { return _PolishingStatus; }
            set { _PolishingStatus = value; }
        }
        Int32 _ShippingStatus;
        public Int32 ShippingStatus
        {
            get { return _ShippingStatus; }
            set { _ShippingStatus = value; }
        }
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

    }

    public class BOLVendorMaintenance
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _Id;
        public Int32 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        String _Name;
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        Int32 _LeadTimeDays;
        public Int32 LeadTimeDays
        {
            get { return _LeadTimeDays; }
            set { _LeadTimeDays = value; }
        }

        String _Notes;
        public String Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        String _StreetAddress;
        public String StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }

        String _Contact;
        public String Contact
        {
            get { return _Contact; }
            set { _Contact = value; }
        }

        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }
    public class BOLRegions
    {

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _CountryId;
        public Int32 CountryId
        {
            get { return _CountryId; }
            set { _CountryId = value; }
        }

        Int32 _RegionId;
        public Int32 RegionId
        {
            get { return _RegionId; }
            set { _RegionId = value; }
        }


        String _RegionName;
        public String RegionName
        {
            get { return _RegionName; }
            set { _RegionName = value; }
        }

        String _Director;
        public String Director
        {
            get { return _Director; }
            set { _Director = value; }
        }

        String _DirectorEmail;
        public String DirectorEmail
        {
            get { return _DirectorEmail; }
            set { _DirectorEmail = value; }
        }

        String _DirectorPhone;
        public String DirectorPhone
        {
            get { return _DirectorPhone; }
            set { _DirectorPhone = value; }
        }

    }

    public class BOL_ITWProjects
    {

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }


        Int32 _POID;
        public Int32 POID
        {
            get { return _POID; }
            set { _POID = value; }
        }

        Int32 _DepartmentID;
        public Int32 DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }

        Decimal _POCost;
        public Decimal POCost
        {
            get { return _POCost; }
            set { _POCost = value; }
        }

        DateTime? _PORecDate;
        public DateTime? PORecDate
        {
            get { return _PORecDate; }
            set { _PORecDate = value; }
        }

        DateTime? _POReleaseDate;
        public DateTime? POReleaseDate
        {
            get { return _POReleaseDate; }
            set { _POReleaseDate = value; }
        }

        String _VMOrderID;
        public String VMOrderID
        {
            get { return _VMOrderID; }
            set { _VMOrderID = value; }
        }

        String _Comments;
        public String Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }

        String _PONumber;
        public String PONumber
        {
            get { return _PONumber; }
            set { _PONumber = value; }
        }
    }
    public class BOLManageReps
    {

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        string _ProductLineID;
        public string ProductLineID
        {
            get { return _ProductLineID; }
            set { _ProductLineID = value; }
        }

        Int32 _RepGroupID;
        public Int32 RepGroupID
        {
            get { return _RepGroupID; }
            set { _RepGroupID = value; }

        }

        Int32 _BranchID;
        public Int32 BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }

        Int32 _SalesRepID;
        public Int32 SalesRepID
        {
            get { return _SalesRepID; }
            set { _SalesRepID = value; }
        }

        string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        Int32 _AbbreviationID;
        public Int32 AbbreviationID
        {
            get { return _AbbreviationID; }
            set { _AbbreviationID = value; }
        }

        String _Phone;
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

    }
    public class BOLPreventiveMaintenance
    {

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        string _JobID;
        public string JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }

        }

        string _OrderNo;
        public string OrderNo
        {
            get { return _OrderNo; }
            set { _OrderNo = value; }
        }

        Int32 _StatusID;
        public Int32 StatusID
        {
            get { return _StatusID; }
            set { _StatusID = value; }
        }

        string _Attention;
        public string Attention
        {
            get { return _Attention; }
            set { _Attention = value; }
        }

        Int32 _CategoryID;
        public Int32 CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }

        DateTime? _QuoteSentDate;
        public DateTime? QuoteSentDate
        {
            get { return _QuoteSentDate; }
            set { _QuoteSentDate = value; }
        }

        Decimal _QuoteAmount;
        public Decimal QuoteAmount
        {
            get { return _QuoteAmount; }
            set { _QuoteAmount = value; }
        }

        string _PONumber;
        public string PONumber
        {
            get { return _PONumber; }
            set { _PONumber = value; }
        }

        DateTime? _PORecDate;
        public DateTime? PORecDate
        {
            get { return _PORecDate; }
            set { _PORecDate = value; }
        }

        DateTime? _ContractStartDate;
        public DateTime? ContractStartDate
        {
            get { return _ContractStartDate; }
            set { _ContractStartDate = value; }
        }

        DateTime? _ContractEndDate;
        public DateTime? ContractEndDate
        {
            get { return _ContractEndDate; }
            set { _ContractEndDate = value; }
        }

        DateTime? _LastTuneUpDate;
        public DateTime? LastTuneUpDate
        {
            get { return _LastTuneUpDate; }
            set { _LastTuneUpDate = value; }
        }

        DateTime? _NextTuneUpDate;
        public DateTime? NextTuneUpDate
        {
            get { return _NextTuneUpDate; }
            set { _NextTuneUpDate = value; }
        }

        DateTime? _InvoiceDate;
        public DateTime? InvoiceDate
        {
            get { return _InvoiceDate; }
            set { _InvoiceDate = value; }
        }

        string _InvoiceNo;
        public string InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }

        DateTime? _FollowUpDate;
        public DateTime? FollowUpDate
        {
            get { return _FollowUpDate; }
            set { _FollowUpDate = value; }
        }

        string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        string _QuoteDetails;
        public string QuoteDetails
        {
            get { return _QuoteDetails; }
            set { _QuoteDetails = value; }
        }
    }
    public class BOLDailyCADReport
    {

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }

        }

        Int32 _DetailID;
        public Int32 DetailID
        {
            get { return _DetailID; }
            set { _DetailID = value; }

        }

        Int32 _CADReportID;
        public Int32 CADReportID
        {
            get { return _CADReportID; }
            set { _CADReportID = value; }

        }

        Int32 _ProjectEngineerID;
        public Int32 ProjectEngineerID
        {
            get { return _ProjectEngineerID; }
            set { _ProjectEngineerID = value; }

        }

        Int32 _NatureID;
        public Int32 NatureID
        {
            get { return _NatureID; }
            set { _NatureID = value; }

        }

        string _Correction;
        public string Correction
        {
            get { return _Correction; }
            set { _Correction = value; }
        }

        Int32 _StatusID;
        public Int32 StatusID
        {
            get { return _StatusID; }
            set { _StatusID = value; }
        }

        string _PNumber;
        public string PNumber
        {
            get { return _PNumber; }
            set { _PNumber = value; }
        }

        DateTime? _ReportDate;
        public DateTime? ReportDate
        {
            get { return _ReportDate; }
            set { _ReportDate = value; }
        }

        DateTime? _ReqRCD;
        public DateTime? ReqRCD
        {
            get { return _ReqRCD; }
            set { _ReqRCD = value; }
        }

        DateTime? _SentCAD;
        public DateTime? SentCAD
        {
            get { return _SentCAD; }
            set { _SentCAD = value; }
        }

        DateTime? _SentRCD;
        public DateTime? SentRCD
        {
            get { return _SentRCD; }
            set { _SentRCD = value; }
        }

        string _Comments;
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }
        string _Priority;
        public string Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }
        string _Progress;
        public string Progress
        {
            get { return _Progress; }
            set { _Progress = value; }
        }
        string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        Int32 _OptionID;
        public Int32 OptionID
        {
            get { return _OptionID; }
            set { _OptionID = value; }
        }
    }

    public class BOLSearchPO
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _SearchVar;
        public String SearchVar
        {
            get { return _SearchVar; }
            set { _SearchVar = value; }
        }
        Int32 _PurchaseOrderID;
        public Int32 PurchaseOrderID
        {
            get { return _PurchaseOrderID; }
            set { _PurchaseOrderID = value; }
        }
        Int32 _PartID;
        public Int32 PartID
        {
            get { return _PartID; }
            set { _PartID = value; }
        }
        Int32 _SourceID;
        public Int32 SourceID
        {
            get { return _SourceID; }
            set { _SourceID = value; }
        }
    }

    public class BOLAeroInvoice
    {

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        DateTime? _FromDate;
        public DateTime? FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        DateTime? _ToDate;
        public DateTime? ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }
    }

    public class BOLPartWiseDetails
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _PartId;
        public Int32 PartId
        {
            get { return _PartId; }
            set { _PartId = value; }
        }
    }

    public class BOLInboundInspectionSummary
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _PartID;
        public Int32 PartID
        {
            get { return _PartID; }
            set { _PartID = value; }
        }
        Int32 _ProductCode;
        public Int32 ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }
        Int32 _plant;
        public Int32 plant
        {
            get { return _plant; }
            set { _plant = value; }
        }
        Int32 _containerno;
        public Int32 containerno
        {
            get { return _containerno; }
            set { _containerno = value; }
        }
        DateTime? _inspectiondate;
        public DateTime? inspectiondate
        {
            get { return _inspectiondate; }
            set { _inspectiondate = value; }
        }
        Int32 _qtyreceived;
        public Int32 qtyreceived
        {
            get { return _qtyreceived; }
            set { _qtyreceived = value; }
        }
        Int32 _qtyinspected;
        public Int32 qtyinspected
        {
            get { return _qtyinspected; }
            set { _qtyinspected = value; }
        }
        Int32 _qtyapproved;
        public Int32 qtyapproved
        {
            get { return _qtyapproved; }
            set { _qtyapproved = value; }
        }
        String _summary;
        public String summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
        Int32 _userid;
        public Int32 userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        Int32 _InspectionDetailID;
        public Int32 InspectionDetailID
        {
            get { return _InspectionDetailID; }
            set { _InspectionDetailID = value; }
        }
        String _filename;
        public String filename
        {
            get { return _filename; }
            set { _filename = value; }
        }
        Int32 _status;
        public Int32 status
        {
            get { return _status; }
            set { _status = value; }
        }
    }

    public class BOLDailyQuoteReport
    {

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }

        }

        Int32 _DetailID;
        public Int32 DetailID
        {
            get { return _DetailID; }
            set { _DetailID = value; }

        }

        Int32 _QuoteReportID;
        public Int32 QuoteReportID
        {
            get { return _QuoteReportID; }
            set { _QuoteReportID = value; }

        }

        Int32 _ProjectEngineerID;
        public Int32 ProjectEngineerID
        {
            get { return _ProjectEngineerID; }
            set { _ProjectEngineerID = value; }

        }

        Int32 _OptionID;
        public Int32 OptionID
        {
            get { return _OptionID; }
            set { _OptionID = value; }
        }

        Int32 _NatureID;
        public Int32 NatureID
        {
            get { return _NatureID; }
            set { _NatureID = value; }

        }

        Int32 _StatusID;
        public Int32 StatusID
        {
            get { return _StatusID; }
            set { _StatusID = value; }
        }

        string _PNumber;
        public string PNumber
        {
            get { return _PNumber; }
            set { _PNumber = value; }
        }

        DateTime? _SentToCustomer;
        public DateTime? SentToCustomer
        {
            get { return _SentToCustomer; }
            set { _SentToCustomer = value; }
        }

        DateTime? _ReqByCustomer;
        public DateTime? ReqByCustomer
        {
            get { return _ReqByCustomer; }
            set { _ReqByCustomer = value; }
        }

        DateTime? _SentQuoteRequest;
        public DateTime? SentQuoteRequest
        {
            get { return _SentQuoteRequest; }
            set { _SentQuoteRequest = value; }
        }

        string _Priority;
        public string Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }

        string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        string _RemarksByTL;
        public string RemarksByTL
        {
            get { return _RemarksByTL; }
            set { _RemarksByTL = value; }
        }
    }
    public class BOLManageProductLine
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _ProductCode;
        public Int32 ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }

        String _Product;
        public String Product
        {
            get { return _Product; }
            set { _Product = value; }
        }
        Int32 _ProductLineID;
        public Int32 ProductLineID
        {
            get { return _ProductLineID; }
            set { _ProductLineID = value; }
        }
    }
    public class BOLStockIn_New
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ContainerID;
        public Int32 ContainerID
        {
            get { return _ContainerID; }
            set { _ContainerID = value; }
        }

        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        DateTime? _ReceivedDate;
        public DateTime? ReceivedDate
        {
            get { return _ReceivedDate; }
            set { _ReceivedDate = value; }
        }

        DateTime? _RevisedETA;
        public DateTime? RevisedETA
        {
            get { return _RevisedETA; }
            set { _RevisedETA = value; }
        }

        String _Comments;
        public String Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }
        String _PackingList;
        public String PackingList
        {
            get { return _PackingList; }
            set { _PackingList = value; }
        }
        Int32 _Status;
        public Int32 Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        Int32 _ContainerDetailID;
        public Int32 ContainerDetailID
        {
            get { return _ContainerDetailID; }
            set { _ContainerDetailID = value; }
        }
    }

    public class BOLPreventativeMaintenanceCallLogs
    {
        Int32 _StatusId;
        public Int32 StatusId
        {
            get { return _StatusId; }
            set { _StatusId = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        String _JobID;
        public String JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }

        DateTime? _WarrantyEndFromDate;
        public DateTime? WarrantyEndFromDate
        {
            get { return _WarrantyEndFromDate; }
            set { _WarrantyEndFromDate = value; }
        }

        DateTime? _WarrantyEndToDate;
        public DateTime? WarrantyEndToDate
        {
            get { return _WarrantyEndToDate; }
            set { _WarrantyEndToDate = value; }
        }

        DateTime? _DateCalled;
        public DateTime? DateCalled
        {
            get { return _DateCalled; }
            set { _DateCalled = value; }
        }

        String _Contact;
        public String Contact
        {
            get { return _Contact; }
            set { _Contact = value; }
        }
        Int32 _ContactID;
        public Int32 ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }

        String _CallDetails;
        public String CallDetails
        {
            get { return _CallDetails; }
            set { _CallDetails = value; }
        }

        String _Notes;
        public String Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        bool? _PMResponse;
        public bool? PMResponse
        {
            get { return _PMResponse; }
            set { _PMResponse = value; }
        }
    }

    #region Caddy
    public class BOLCADDYProjectInfo
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        String _JobNo;
        public String JobNo
        {
            get { return _JobNo; }
            set { _JobNo = value; }
        }
        String _JobName;
        public String JobName
        {
            get { return _JobName; }
            set { _JobName = value; }
        }
        Int32 _JobType;
        public Int32 JobType
        {
            get { return _JobType; }
            set { _JobType = value; }
        }
        Int32 _PMAero;
        public Int32 PMAero
        {
            get { return _PMAero; }
            set { _PMAero = value; }
        }
        Int32 _PMCaddy;
        public Int32 PMCaddy
        {
            get { return _PMCaddy; }
            set { _PMCaddy = value; }
        }
        Int32 _ProjectID;
        public Int32 ProjectID
        {
            get { return _ProjectID; }
            set { _ProjectID = value; }
        }
        Int32 _ChildModelID;
        public Int32 ChildModelID
        {
            get { return _ChildModelID; }
            set { _ChildModelID = value; }
        }
        DataTable _SelectedItems;
        public DataTable SelectedItems
        {
            get { return _SelectedItems; }
            set { _SelectedItems = value; }
        }
        Int32 _ModelID;
        public Int32 ModelID
        {
            get { return _ModelID; }
            set { _ModelID = value; }
        }
    }

    public class BOLCADDYENGTasks
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _ProjectID;
        public Int32 ProjectID
        {
            get { return _ProjectID; }
            set { _ProjectID = value; }
        }
        String _JobNo;
        public String JobNo
        {
            get { return _JobNo; }
            set { _JobNo = value; }
        }
        String _JobName;
        public String JobName
        {
            get { return _JobName; }
            set { _JobName = value; }
        }
        Int32 _ProjectType;
        public Int32 ProjectType
        {
            get { return _ProjectType; }
            set { _ProjectType = value; }
        }
        Int32 _Nature;
        public Int32 Nature
        {
            get { return _Nature; }
            set { _Nature = value; }
        }
        String _Correction;
        public String Correction
        {
            get { return _Correction; }
            set { _Correction = value; }
        }
        DateTime? _ReqFWDToIndia;
        public DateTime? ReqFWDToIndia
        {
            get { return _ReqFWDToIndia; }
            set { _ReqFWDToIndia = value; }
        }
        DateTime? _ProjectDueDate;
        public DateTime? ProjectDueDate
        {
            get { return _ProjectDueDate; }
            set { _ProjectDueDate = value; }
        }
        Int32 _AssingedTo;
        public Int32 AssingedTo
        {
            get { return _AssingedTo; }
            set { _AssingedTo = value; }
        }
        DateTime? _SentToCaddy;
        public DateTime? SentToCaddy
        {
            get { return _SentToCaddy; }
            set { _SentToCaddy = value; }
        }
        String _Remarks;
        public String Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        String _RemarksByPM;
        public String RemarksByPM
        {
            get { return _RemarksByPM; }
            set { _RemarksByPM = value; }
        }
        String _JobType;
        public String JobType
        {
            get { return _JobType; }
            set { _JobType = value; }
        }
        //EngProjectID
        Int32 _EngProjectID;
        public Int32 EngProjectID
        {
            get { return _EngProjectID; }
            set { _EngProjectID = value; }
        }
        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        //@StatusID
        Int32 _StatusID;
        public Int32 StatusID
        {
            get { return _StatusID; }
            set { _StatusID = value; }
        }
        Int32 _Progress;
        public Int32 Progress
        {
            get { return _Progress; }
            set { _Progress = value; }
        }
        Int32 _JobTypeID;
        public Int32 JobTypeID
        {
            get { return _JobTypeID; }
            set { _JobTypeID = value; }
        }
        //Priority
        Int32 _Priority;
        public Int32 Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }
        Int32 _EngDepID;
        public Int32 EngDepID
        {
            get { return _EngDepID; }
            set { _EngDepID = value; }
        }
        String _ItemNo;
        public String ItemNo
        {
            get { return _ItemNo; }
            set { _ItemNo = value; }
        }
        Int32 _ModelId;
        public Int32 ModelId
        {
            get { return _ModelId; }
            set { _ModelId = value; }
        }
        Int32 _ProjectManagerID;
        public Int32 ProjectManagerID
        {
            get { return _ProjectManagerID; }
            set { _ProjectManagerID = value; }
        }
    }

    #endregion Caddy

    // TW START

    public class BOLTurboWashPart
    {
        Int32 _CompanyID;
        public Int32 CompanyID
        {
            get { return _CompanyID; }
            set { _CompanyID = value; }
        }

        string _PartDescription;
        public string PartDescription
        {
            get { return _PartDescription; }
            set { _PartDescription = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        Int32 _CategoryID;
        public Int32 CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }

        Int32 _OptionID;
        public Int32 OptionID
        {
            get { return _OptionID; }
            set { _OptionID = value; }
        }

        string _PartNo;
        public string PartNo
        {
            get { return _PartNo; }
            set { _PartNo = value; }
        }

        Int32 _Size;
        public Int32 Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        string _Direction;
        public string Direction
        {
            get { return _Direction; }
            set { _Direction = value; }
        }

        Int32 _StockInHand;
        public Int32 StockInHand
        {
            get { return _StockInHand; }
            set { _StockInHand = value; }
        }
    }
    public class BOLSearchContainer
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        Int32 _POId;
        public Int32 POId
        {
            get { return _POId; }
            set { _POId = value; }
        }
        String _SearchVar;
        public String SearchVar
        {
            get { return _SearchVar; }
            set { _SearchVar = value; }
        }
        Int32 _SourceID;
        public Int32 SourceID
        {
            get { return _SourceID; }
            set { _SourceID = value; }
        }
    }

    public class BOLTurboWashTransaction
    {

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _CategoryID;
        public Int32 CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }

        Int32 _PartID;
        public Int32 PartID
        {
            get { return _PartID; }
            set { _PartID = value; }
        }

        Int32 _OpeningStock;
        public Int32 OpeningStock
        {
            get { return _OpeningStock; }
            set { _OpeningStock = value; }
        }

        Int32 _TransactQty;
        public Int32 TransactQty
        {
            get { return _TransactQty; }
            set { _TransactQty = value; }
        }

        Int32 _ClosingStock;
        public Int32 ClosingStock
        {
            get { return _ClosingStock; }
            set { _ClosingStock = value; }
        }

        Int32 _TransactType;
        public Int32 TransactType
        {
            get { return _TransactType; }
            set { _TransactType = value; }
        }

        string _JobID;
        public string JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }

        Int32 _LoginUserID;
        public Int32 LoginUserID
        {
            get { return _LoginUserID; }
            set { _LoginUserID = value; }
        }
    }


    // TW END

    public class BOLMiscellaneousTasks
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        string _CompanyName;
        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        string _Location;
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        string _RefNo;
        public string RefNo
        {
            get { return _RefNo; }
            set { _RefNo = value; }
        }

        string _Contact;
        public string Contact
        {
            get { return _Contact; }
            set { _Contact = value; }
        }

        string _Issue;
        public string Issue
        {
            get { return _Issue; }
            set { _Issue = value; }
        }

        DateTime? _IssueDate;
        public DateTime? IssueDate
        {
            get { return _IssueDate; }
            set { _IssueDate = value; }
        }

        string _IssueBy;
        public string IssueBy
        {
            get { return _IssueBy; }
            set { _IssueBy = value; }
        }

        string _Solution;
        public string Solution
        {
            get { return _Solution; }
            set { _Solution = value; }
        }

        DateTime? _SolutionDate;
        public DateTime? SolutionDate
        {
            get { return _SolutionDate; }
            set { _SolutionDate = value; }
        }

        string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        string _DocPath;
        public string DocPath
        {
            get { return _DocPath; }
            set { _DocPath = value; }
        }
    }

    public class BOLUserOTP
    {
        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }
        Int32 _EmployeeID;
        public Int32 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        //UserInputOTP
        String _UserInputOTP;
        public String UserInputOTP
        {
            get { return _UserInputOTP; }
            set { _UserInputOTP = value; }
        }
    }
    public class BOLManageITWProjects
    {
        String _RefId;
        public String RefId
        {
            get { return _RefId; }
            set { _RefId = value; }
        }

        Int32 _Company;
        public Int32 Company
        {
            get { return _Company; }
            set { _Company = value; }
        }

        String _HobartDrawingRevisionNo;
        public String HobartDrawingRevisionNo
        {
            get { return _HobartDrawingRevisionNo; }
            set { _HobartDrawingRevisionNo = value; }
        }

        String _PONumber;
        public String PONumber
        {
            get { return _PONumber; }
            set { _PONumber = value; }
        }

        Int32 _POType;
        public Int32 POType
        {
            get { return _POType; }
            set { _POType = value; }
        }

        String _CI;
        public String CI
        {
            get { return _CI; }
            set { _CI = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        String _JobID;
        public String JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }

        String _ProjectName;
        public String ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }

        String _HobartDrawingNumber;
        public String HobartDrawingNumber
        {
            get { return _HobartDrawingNumber; }
            set { _HobartDrawingNumber = value; }
        }

        DateTime? _POReceivedDate;
        public DateTime? POReceivedDate
        {
            get { return _POReceivedDate; }
            set { _POReceivedDate = value; }
        }

        DateTime? _ReqShipDate;
        public DateTime? ReqShipDate
        {
            get { return _ReqShipDate; }
            set { _ReqShipDate = value; }
        }

        DateTime? _ShipDate;
        public DateTime? ShipDate
        {
            get { return _ShipDate; }
            set { _ShipDate = value; }
        }

        Decimal _EqPrice;
        public Decimal EqPrice
        {
            get { return _EqPrice; }
            set { _EqPrice = value; }
        }

        bool _Release;
        public bool Release
        {
            get { return _Release; }
            set { _Release = value; }
        }

        bool _SendToProduction;
        public bool SendToProduction
        {
            get { return _SendToProduction; }
            set { _SendToProduction = value; }
        }

        DateTime? _DrawingReleaseDate;
        public DateTime? DrawingReleaseDate
        {
            get { return _DrawingReleaseDate; }
            set { _DrawingReleaseDate = value; }
        }

        Int32 _LoginUserID;
        public Int32 LoginUserID
        {
            get { return _LoginUserID; }
            set { _LoginUserID = value; }
        }

        String _Comments;
        public String Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }

        Int32 _Id;
        public Int32 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        Int32 _PartId;
        public Int32 PartId
        {
            get { return _PartId; }
            set { _PartId = value; }
        }

        Int32 _Qty;
        public Int32 Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }

        Int32 _ShipQty;
        public Int32 ShipQty
        {
            get { return _ShipQty; }
            set { _ShipQty = value; }
        }

        DateTime? _NestingStartDate;
        public DateTime? NestingStartDate
        {
            get { return _NestingStartDate; }
            set { _NestingStartDate = value; }
        }

        DateTime? _NestingEndDate;
        public DateTime? NestingEndDate
        {
            get { return _NestingEndDate; }
            set { _NestingEndDate = value; }
        }

        DateTime? _SentDate;
        public DateTime? SentDate
        {
            get { return _SentDate; }
            set { _SentDate = value; }
        }

        Int32 _NestingStatusId;
        public Int32 NestingStatusId
        {
            get { return _NestingStatusId; }
            set { _NestingStatusId = value; }
        }

        Int32 _WarehouseId;
        public Int32 WarehouseId
        {
            get { return _WarehouseId; }
            set { _WarehouseId = value; }
        }
    }

    public class BOLManageITWProjectParts
    {
        Int32 _StatusId;
        public Int32 StatusId
        {
            get { return _StatusId; }
            set { _StatusId = value; }
        }

        DateTime? _ShipDate;
        public DateTime? ShipDate
        {
            get { return _ShipDate; }
            set { _ShipDate = value; }
        }

        Int32? _ShipQty;
        public Int32? ShipQty
        {
            get { return _ShipQty; }
            set { _ShipQty = value; }
        }
        String _Comments;
        public String Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }
        Int32 _Id;
        public Int32 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        Int32 _Operation;
        public Int32 Operation
        {
            get { return _Operation; }
            set { _Operation = value; }
        }

        String _JobID;
        public String JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }

        Int32 _CategoryID;
        public Int32 CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }

        Int32 _PartID;
        public Int32 PartID
        {
            get { return _PartID; }
            set { _PartID = value; }
        }

        Int32 _Qty;
        public Int32 Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
    }
}
